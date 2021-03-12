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
                Return pVersion_UpdatedSinceLastLaunched
            End Get
        End Property
        Public ReadOnly Property InstalledPathChanged As Boolean
            Get
                Return pInstalledPath_Changed
            End Get
        End Property
        Private pVersion As String
        Private pVersion_UpdatedSinceLastLaunched As Boolean
        Private pInstalledPath As String
        Private pInstalledPath_Changed As Boolean
#End Region

#Region "Initialize"
        Public Sub New(Path As String)
            pInstalledPath = Path
            EnsureRegistryExists()
        End Sub
#End Region

#Region "Registry Functions" '//Dim T As Microsoft.Win32.RegistryKeyPermissionCheck
        Private Sub EnsureRegistryExists()
            Dim Root = Retrieve_RegistryBranch(WindowsRegistryBranches.CurrentUser_Software, True)
            Dim Toolkit = Root.OpenSubKey(ProgramID, True)
            If Toolkit Is Nothing Then
                Toolkit = Root.CreateSubKey(ProgramID)
                pInstalledPath_Changed = True
                pVersion_UpdatedSinceLastLaunched = True
                pVersion = Retrieve_VersionInfo()
            Else
                Update_FromRegistry(Toolkit)
            End If
            Update_ToRegistry(Toolkit)
        End Sub
        Private Sub Update_FromRegistry(ByRef Source As Microsoft.Win32.RegistryKey)
            Dim LastPath As String = Source.GetValue("InstalledPath")
            If Not String.Equals(LastPath, InstalledPath) Then pInstalledPath_Changed = True
            pVersion = Source.GetValue("Version")
            Dim EXEVersion = Retrieve_VersionInfo()
            If Not (EXEVersion = pVersion) Then pVersion_UpdatedSinceLastLaunched = True
        End Sub
        Private Sub Update_ToRegistry(ByRef Source As Microsoft.Win32.RegistryKey)
            If pInstalledPath_Changed = True Then Source.SetValue("InstalledPath", pInstalledPath)
            If pVersion_UpdatedSinceLastLaunched = True Then Source.SetValue("Version", pVersion)
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

#Region "Generic Functions"
        Public Enum WindowsRegistryBranches
            LocalMachine
            Users
            CurrentConfig
            ClassesRoot
            CurrentUser
            CurrentUser_Software
        End Enum
        Private Function CheckExists(Name As String, Branch As WindowsRegistryBranches, RequireWriteAccess As Boolean, ByRef Result As Microsoft.Win32.RegistryKey) As Boolean
            Result = Retrieve_RegistryBranch(Branch, RequireWriteAccess).OpenSubKey(Name, RequireWriteAccess)
            Return Not (Result Is Nothing)
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
