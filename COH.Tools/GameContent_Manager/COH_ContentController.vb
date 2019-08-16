Namespace Internal.ContentController
    Public NotInheritable Class COH_ContentController
        Implements ISupport_MasterController

#Region "Instance"
        Public ReadOnly Property ProgramFolders As COH_ProgramPathsManager
            Get
                Return mProgramFolders
            End Get
        End Property
        Public ReadOnly Property Settings As ContentManager_Settings
            Get
                Return mSettings
            End Get
        End Property
        Public Shared ReadOnly Property Instance As COH_ContentController
            Get
                Return sInstance
            End Get
        End Property
#End Region

#Region "Private Properties"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private Shared sInstance As COH_ContentController
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private sMainForm As COH_Tools
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mProgramFolders As COH_ProgramPathsManager
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mSettings As ContentManager_Settings
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mLoadScreenVisible As Boolean
#End Region

#Region "Initialize"
        Public Sub New(ByRef MainForm As COH_Tools, InstalledProgramPath As String, Optional PrepareCache As Boolean = True)
            sMainForm = MainForm
            PrepareUsage(InstalledProgramPath)
            If PrepareCache = True Then CacheFiles()
            SplashScreen_Destroy()
        End Sub
        Private Sub PrepareUsage(InstalledProgramPath As String)
            sInstance = Me
            mCached_Structs = New Dictionary(Of COH_ProjectContent, List(Of COH_Struct))
            SplashScreen_Create()
            SplashScreen_Update("Initializing", 5, True)
            mCached_ProjectMapping = CreateListProjectMapping()
            mCahced_ModMapping = CreateListProjectMapping_ModType()
            mEventController = GameContent.Internal.Events.COH_LibraryEventControl.Instance
            SplashScreen_Update("Preparing Folders", 5, True)
            mProgramFolders = New COH_ProgramPathsManager(InstalledProgramPath)
            If PrepareUsage_Settings() = False Then Environment.Exit(0)
            If Check_PrepareFirstTimeUsage() = True Then
                If PrepareUsage_FirstTime() = False Then Environment.Exit(0)
            Else
                CacheFiles()
            End If
            'If PrepareUsage_Localization() = False Then ThrowError(New Logging.BTC_EventResponse(BTC_ResponseCodeSeverity.SevereError, BTC_ResponseCodes.Unknown, ""))
        End Sub
        Private Function PrepareUsage_Settings() As Boolean
            Dim FilePath As String = ProgramFolders.LookupFolder(COH_ProgramPaths.Resources_Settings) & "Settings.xml"
            If IO.File.Exists(FilePath) = False Then
                mSettings = New ContentManager_Settings(True)
                mSettings.Save()
            Else
                If ContentManager_Settings.Import_XMLFile(FilePath, mSettings) = False Then
                    mSettings = New ContentManager_Settings(True)
                    mSettings.Save()
                End If
            End If
            mProgramFolders.EnsureAllProjectFoldersExist(mSettings.CurrentProject_RootFolder)
            Return True
        End Function
        Private Function Check_PrepareFirstTimeUsage() As Boolean
            Dim FilePath As String = mSettings.CurrentProject_FilePath
            If IO.File.Exists(FilePath) = False Then Return True
            Return False
        End Function
        Private Function PrepareUsage_FirstTime() As Boolean
            SplashScreen_Update("Registering Structures", 10, False)
            Prepare_StructuresController()
            SplashScreen_Update("Extracting Piggs", 10, True)
            If ExtractPiggs_FreshInstall(False) = False Then Return False
            SplashScreen_Update("Extracting Bins", 10, True)
            If ExtractBins_All(False) = False Then Return False
            SplashScreen_Update("Creating Standard Project", 5, True)
            If Start_FreshProjectFile_Standard(False) = False Then Return False
            Return True
        End Function
        Private Sub CacheFiles()
            SplashScreen_Update("Registering Structures", 10, False)
            Prepare_StructuresController()
            SplashScreen_Update("Loading Message Stores", 10, False)
            Prepare_MessageStoreController()
            SplashScreen_Update("Searching Available Assets", 10, True)
            Prepare_AssetsController()
            SplashScreen_Update("Loading Project File", 10, False)
            Retrieve_CurrentPoject(False)
        End Sub
#End Region

#Region "Splash Screen"
        Protected Friend Sub LoadScreen_AddMessage(message As String)
            If mLoadScreenVisible = False Then Exit Sub
        End Sub
#End Region

    End Class
End Namespace