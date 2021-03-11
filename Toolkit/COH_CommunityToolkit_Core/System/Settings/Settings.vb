Imports System.Runtime.Serialization
Imports System.Xml

Namespace ControllerModules
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class ApplicationController_Settings

#Region "Properties - Project Related"
        Public Property CurrentProject_HasActive As Boolean
            Get
                Return pCurrentProject_HasActive
            End Get
            Set(value As Boolean)
                pCurrentProject_HasActive = value
            End Set
        End Property

        Public Property CurrentProject_FileName As String
            Get
                Return pCurrentProject_FileName
            End Get
            Set(value As String)
                pCurrentProject_FileName = value
            End Set
        End Property
        Public Property CurrentProject_RootFolder As String
            Get
                Return pCurrentProject_RootPath
            End Get
            Set(value As String)
                pCurrentProject_RootPath = value
            End Set
        End Property
        Public ReadOnly Property CurrentProject_FilePath As String
            Get
                Return pCurrentProject_RootPath & pCurrentProject_FileName
            End Get
        End Property
        Private pCurrentProject_RootPath As String
        Private pCurrentProject_FileName As String
        Private pCurrentProject_HasActive As Boolean
#End Region

#Region "Properties - Game Code Source Related"
        Public Property Ouroboros_RepoPathRoot As String
            Get
                Return pOuroboros_RepoPath
            End Get
            Set(value As String)
                pOuroboros_RepoPath = value
            End Set
        End Property
        Private pOuroboros_RepoPath As String
#End Region

#Region "Properties - Update Check"
        Public Property GitReleaseFeed As String
            Get
                Return pGit_ReleaseFeed
            End Get
            Set(value As String)
                pGit_ReleaseFeed = value
            End Set
        End Property
        Public Property GitReleaseDate As Date
            Get
                Return pGit_ReleaseDate
            End Get
            Set(value As Date)
                pGit_ReleaseDate = value
            End Set
        End Property
        Private pGit_ReleaseFeed As String
        Private pGit_ReleaseDate As Date
#End Region

#Region "Properties - Options"
        Public Property Option_BINs_UpdateTimeStamps As String
            Get
                Return pOption_UpdateBin_TimeStamps
            End Get
            Set(value As String)
                pOption_UpdateBin_TimeStamps = value
            End Set
        End Property
        Private pOption_UpdateBin_TimeStamps As Boolean
#End Region

#Region "Create New Instance"
        Public Sub New()
        End Sub
        Public Sub New(ResetToDefaults As Boolean)
            If ResetToDefaults = True Then ResetDefaults()
        End Sub
        Private Sub ResetDefaults()
            pCurrentProject_HasActive = False
            pOption_UpdateBin_TimeStamps = False
            Reset_ToDefaultProject(False)
        End Sub
        Public Sub Reset_ToDefaultProject(Optional SaveFile As Boolean = True)
            pGit_ReleaseFeed = "https://github.com/Dragon-Sire/COH-CommunityToolKit/releases.atom"
            pGit_ReleaseDate = "01/01/2019"
            pCurrentProject_FileName = "CityofHeroes_StandardProject.xml"
            'pCurrentProject_RootPath = COH_ContentController.Instance.ProgramFolders.LookupFolder(COH_ProgramPaths.ProgramData) & "StandardPackage\"
            'pOuroboros_RepoPath = COH_ContentController.Instance.ProgramFolders.LookupFolder(COH_ProgramPaths.Repo)
            If SaveFile = True Then Save()
        End Sub
#End Region

#Region "Save Changes"
        Public Function Save() As Boolean
            ' Dim FilePath As String = COH_ContentController.Instance.ProgramFolders.LookupFolder(COH_ProgramPaths.Resources_Settings) & "Settings.xml"
            'Return Export_XML_Settings(FilePath, Me)
        End Function
#End Region

#Region "Export"
#End Region

#Region "Import"
        <OnDeserializing()> Friend Sub OnDeserializingMethod(ByVal context As StreamingContext)
        End Sub
        <OnDeserialized()> Friend Sub OnDeserializedMethod(ByVal context As StreamingContext)
        End Sub
#End Region
    End Class
End Namespace