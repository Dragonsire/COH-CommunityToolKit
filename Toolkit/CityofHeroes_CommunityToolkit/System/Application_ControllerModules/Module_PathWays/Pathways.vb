Imports COH.CodeManagement.Enums
Imports COH.Toolkit.ControllerModules.Pathways

Namespace Toolkit.ControllerModules
    Public NotInheritable Class ControllerModule_Pathways
        Inherits ControllerModule

#Region "Properties"
        Public ReadOnly Property RootPath As String
            Get
                Return pPaths.RootPath
            End Get
        End Property
        Public ReadOnly Property LoadedFonts As Drawing.Text.PrivateFontCollection
            Get
                Return pFonts
            End Get
        End Property
        Public ReadOnly Property RegistryDetails As ControllerModule_PathwaysRegistry
            Get
                Return pRegistryDetails
            End Get
        End Property
        Private pRegistryDetails As ControllerModule_PathwaysRegistry
        Private pDefaultImageFormat As Drawing.Imaging.ImageFormat
        Private pFonts As Drawing.Text.PrivateFontCollection
        Private pPaths As DS_PathwaysCollection
#End Region

#Region "Create New Instance"
        Public Sub New(ByRef ParentController As ToolkitController)
            MyBase.New(ParentController)
        End Sub
        Public Sub ConfigureModule(StartupFolder As String)
            Dim InstalledPath As String = IdentifyInstalledPath(StartupFolder)
            pRegistryDetails = OnConfigureRegistry(InstalledPath, "")
            pPaths = New DS_PathwaysCollection(pRegistryDetails.InstalledPath)
            pFonts = New Drawing.Text.PrivateFontCollection
            pPaths.Pathway_AddRange(OnConfigurePathways)
            EnsureAllFoldersExist()
            OnConfigurePathwaysResources()
        End Sub
#End Region

#Region "Configure Pathways"
        Private Function IdentifyInstalledPath(StartupPath As String) As String
            Dim Root As String = StartupPath
            If StartupPath.Contains("_Compiled Code") Then '//DEVELOPER VERSION
                Dim RemovePath As String = StartupPath.Substring(StartupPath.IndexOf("_Compiled Code"))
                Dim NewPath As String = StartupPath.Replace(RemovePath, "")
                Root = IO.Path.Combine(NewPath, "Program Data\" & "COH_CommunityToolkit" & "\")
                Return Root
            End If
            '/// CHECK FOR INSTALLED INDICATORS HERE
            Return StartupPath
        End Function
#End Region

#Region "Usage"
        Public Sub EnsureAllFoldersExist()
            For Each Entry In pPaths
                If (Entry.Type = CF_Enum_PathwayType.Folder) Then
                    Dim FolderPath As String = IO.Path.Combine(RootPath, Entry.RelativePath)
                    If IO.Directory.Exists(FolderPath) = False Then IO.Directory.CreateDirectory(FolderPath)
                End If
            Next
        End Sub
#End Region
    End Class
End Namespace