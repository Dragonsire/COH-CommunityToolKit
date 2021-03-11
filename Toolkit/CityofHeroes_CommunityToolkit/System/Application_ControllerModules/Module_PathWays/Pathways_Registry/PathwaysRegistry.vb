Namespace ControllerModules.Pathways
    Public NotInheritable Class ControllerModule_PathwaysRegistry

#Region "Properties"
        Public ReadOnly Property ProgramID As String
            Get
                Return "CityofHeroes_CommunityToolKit"
            End Get
        End Property
        Public ReadOnly Property InstalledPath As String
            Get
                Return pInstalledPath
            End Get
        End Property
        Public ReadOnly Property Version As String
            Get
                Return pVersion
            End Get
        End Property
        Public ReadOnly Property WasUpdatedSinceLastLaunched As Boolean
            Get
                Return pWasUpdatedSinceLastLaunched
            End Get
        End Property
        Public ReadOnly Property InstalledPathChanged As Boolean
            Get
                Return pInstalledPathChanged
            End Get
        End Property
        Private pWasUpdatedSinceLastLaunched As Boolean
        Private pInstalledPathChanged As Boolean
        Private pVersion As String
        Private pInstalledPath As String
#End Region

#Region "Initialize"
        Public Sub New(Path As String)
            pInstalledPath = Path
            EnsureRegisryEntry()
        End Sub
        Private Sub EnsureRegisryEntry()
            Dim Result As Microsoft.Win32.RegistryKey = Nothing
            If CheckProgramRegistryExists(ProgramID, Result) = False Then
                CreateRegistryEntry(Me)
            Else
                Update_FromRegistry(Result)
            End If
        End Sub
        Private Sub Update_FromRegistry(ByRef Source As Microsoft.Win32.RegistryKey)
            Dim LastPath As String = Source.GetValue("InstalledPath")
            If Not String.Equals(LastPath, InstalledPath) Then
                pInstalledPathChanged = True
            End If
            pVersion = Source.GetValue("Version")
            Dim EXEVersion = Retrieve_VersionInfo()
            If Not (EXEVersion = pVersion) Then
                pWasUpdatedSinceLastLaunched = True
            End If
        End Sub
        Private Sub Update_ToRegistry(ByRef Source As Microsoft.Win32.RegistryKey)
            If pInstalledPathChanged = True Then Source.SetValue("InstalledPath", pInstalledPath)
            If pWasUpdatedSinceLastLaunched = True Then Source.SetValue("Version", pVersion)
        End Sub
#End Region

#Region "VersionDetails"
        Public Shared Function Retrieve_Version() As FileVersionInfo
            Return FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        End Function
        Public Shared Function Retrieve_VersionInfo_Relevant(ByRef Info As FileVersionInfo) As String
            If Info Is Nothing Then Return ""
            Dim Result As String = Info.FileMajorPart.ToString & "." & Info.FileMinorPart.ToString & "." & Info.FileBuildPart.ToString & ".0"
            Return Result
        End Function
        Public Shared Function Retrieve_VersionInfo() As String
            Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
            Return Retrieve_VersionInfo_Relevant(myBuildInfo)
        End Function
#End Region

#Region "Windows Registry Settings"
        Public Shared Function CheckProgramRegistryExists(ProgramNameKey As String, ByRef Result As Microsoft.Win32.RegistryKey) As Boolean
            Dim DSKey As Microsoft.Win32.RegistryKey = Nothing
            If CheckExists("DragonSireSoftware", WindowsRegistryBranches.CurrentUser_Software, False, DSKey) = False Then Return False
            Dim ProgramKey As Microsoft.Win32.RegistryKey = DSKey.OpenSubKey(ProgramNameKey, False)
            If (ProgramKey Is Nothing) Then Return False
            Result = ProgramKey
            Return True
        End Function
        Public Shared Function CreateRegistryEntry(ByRef Details As ControllerModule_PathwaysRegistry) As Boolean
            Dim DSKey As Microsoft.Win32.RegistryKey = Nothing
            If CreateRegistryEntry("DragonSireSoftware", WindowsRegistryBranches.CurrentUser_Software, DSKey) = False Then Return False
            Dim ProgramKey = DSKey.CreateSubKey(Details.ProgramID)
            ProgramKey.SetValue("InstalledPath", Details.InstalledPath)
            ProgramKey.SetValue("Version", Retrieve_VersionInfo)
            Return True
        End Function
#End Region

#Region "Generic Functions"
        Public Enum WindowsRegistryBranches
            LocalMachine
            Users
            CurrentConfig
            ClassesRoot
            CurrentUser
            CurrentUser_Software
        End Enum
        Public Shared Function CreateRegistryEntry(Name As String, Branch As WindowsRegistryBranches, ByRef Result As Microsoft.Win32.RegistryKey) As Boolean
            If CheckExists(Name, Branch, True, Result) = True Then Return True
            Result = Retrieve_RegistryBranch(Branch, True).CreateSubKey(Name)
            Return Not (Result Is Nothing)
        End Function
        Public Shared Function CheckExists(Name As String, Branch As WindowsRegistryBranches, RequireWriteAccess As Boolean, ByRef Result As Microsoft.Win32.RegistryKey) As Boolean
            Result = Retrieve_RegistryBranch(Branch, RequireWriteAccess).OpenSubKey(Name, RequireWriteAccess)
            Return Not (Result Is Nothing)
            Dim T As Microsoft.Win32.RegistryKeyPermissionCheck
        End Function
        Public Shared Function Retrieve_RegistryBranch(Branch As WindowsRegistryBranches, RequireWriteAccess As Boolean) As Microsoft.Win32.RegistryKey
            Select Case Branch
                Case WindowsRegistryBranches.Users
                    Return Microsoft.Win32.Registry.Users
                Case WindowsRegistryBranches.LocalMachine
                    Return Microsoft.Win32.Registry.LocalMachine
                Case WindowsRegistryBranches.CurrentUser
                    Return Microsoft.Win32.Registry.CurrentUser
                Case WindowsRegistryBranches.CurrentConfig
                    Return Microsoft.Win32.Registry.CurrentConfig
                Case WindowsRegistryBranches.ClassesRoot
                    Return Microsoft.Win32.Registry.ClassesRoot
                Case WindowsRegistryBranches.CurrentUser_Software
                    Return Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE", RequireWriteAccess)
                Case Else
                    Return Nothing
            End Select
        End Function
#End Region
    End Class
End Namespace
