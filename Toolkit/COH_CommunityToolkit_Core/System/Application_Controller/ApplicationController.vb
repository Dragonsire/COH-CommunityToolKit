Imports COH.ControllerModules

Public NotInheritable Class ApplicationController

#Region "Identification"
    Public Const ProgramName As String = "ControlFreak Controller Template"
    Public Const DefaultFolderName As String = "ControlFreak_Template_DefaultFolder"
#End Region

#Region "Properties"
    Public Shared ReadOnly Property Instance As ApplicationController
        Get
            Return sInstance
        End Get
    End Property
    Public ReadOnly Property Pathways() As ControllerModule_Pathways
        Get
            Return rPathways
        End Get
    End Property
    Public ReadOnly Property Settings() As ApplicationController_Settings
        Get
            Return pSettings
        End Get
    End Property
    Public ReadOnly Property WindowManager() As ControllerModule_WindowManager
        Get
            Return rWindowManager
        End Get
    End Property
    Private WithEvents rPathways As ControllerModule_Pathways
    Private WithEvents rWindowManager As ControllerModule_WindowManager
    Private WithEvents pSettings As ApplicationController_Settings
    Private Shared sInstance As ApplicationController
#End Region

#Region "Create New Instance"
    Public Sub New(ByRef StartupFolder As String)
        PerformStartup_Intial(StartupFolder)
        PerformStartup_ConfigureMainWindow_Standard()
        PerformStartup_Final()
    End Sub
    Public Sub New(ByRef StartupFolder As String, MainForm As Control, ByRef TheMenu As Controls.Menu.COH_Toolkit_MenuStrip, DefaultParent_Area As Drawing.Rectangle)
        PerformStartup_Intial(StartupFolder)
        PerformStartup_ConfigureMainWindow_Custom(MainForm, TheMenu, DefaultParent_Area)
        PerformStartup_Final()
    End Sub
#End Region

#Region "Startup"
    Private Sub PerformStartup_Intial(ByRef StartupFolder As String)
        InstanceMe()
        PrepareSplashScreen()
        UpdateSplashScreen("LoadingSettings", 5, True)
        ConfigureSettings(StartupFolder)
        UpdateSplashScreen("Configuring Folders", 10, True)
        ConfigurePathways(StartupFolder)
        UpdateSplashScreen("Configuring UI", 20, True)
    End Sub
    Private Sub PerformStartup_ConfigureMainWindow_Standard()
        Dim ParentForm = Create_ParentForm()
        ConfigureWindowController(ParentForm, ParentForm.ChildFormArea)
        ConfigureMenu(ParentForm.MainMenuStrip)
    End Sub
    Private Sub PerformStartup_ConfigureMainWindow_Custom(MainForm As Control, ByRef TheMenu As Controls.Menu.COH_Toolkit_MenuStrip, DefaultParent_Area As Drawing.Rectangle)
        ConfigureWindowController(MainForm, DefaultParent_Area)
        ConfigureMenu(TheMenu)
    End Sub
    Private Sub PerformStartup_Final()
        UpdateSplashScreen("Configuring Logging", 30, True)
        ConfigureEventManager()
        UpdateSplashScreen("Configuring Program Specific", 50, True)
        OnLoadContent()
        UpdateSplashScreen("Done", 100, True)
        UnloadSplash()
    End Sub
    Private Sub InstanceMe()
        If (sInstance Is Nothing) Then
            sInstance = Me
            Exit Sub
        End If
        '///UNLOAD INSTANCE ???
    End Sub
#End Region

#Region "Configure Modules"
    Protected Sub ConfigurePathways(ByRef StartupFolder As String)
        rPathways = New ControllerModule_Pathways(Me)
        rPathways.ConfigureModule(StartupFolder, DefaultFolderName)
    End Sub
    Protected Sub ConfigureSettings(StartupFolder As String)
        Dim ExpectedFileLocation As String = IO.Path.Combine(StartupFolder, "Settings.xml")
        If IO.File.Exists(ExpectedFileLocation) = False Then
            Dim Result As New ApplicationController_Settings(True)
            pSettings = Result
        Else
            '// If ApplicationController_Settings.Import_FromXML_File(ExpectedFileLocation, pSettings) = False Then TriggerEvent_ErrorOccured(New ArgumentException("Unable to Load Settings File"), "Control Freak Manager")
        End If
    End Sub
    Protected Sub ConfigureWindowController(ByRef DefaultParentControl As Control, DefaultParent_Area As Drawing.Rectangle)
        rWindowManager = New ControllerModule_WindowManager(Me)
        rWindowManager.ConfigureModule(DefaultParentControl, DefaultParent_Area)
    End Sub
#End Region
End Class