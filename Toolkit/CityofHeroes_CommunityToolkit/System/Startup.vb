Imports COH.Toolkit
Imports COH.Toolkit.Helpers

Public Module Startup
    Public CurrentApplication As Toolkit_ApplicationLauncher
    Public MasterControl As ToolkitController
    Public MainForm As Toolkit.Controls.COH_CommunityToolkit_Main
    Sub Main(Arguments As String())
        MasterControl = New ToolkitController(Application.StartupPath)
        MainForm = MasterControl.WindowManager.UIController.MainForm
        CurrentApplication = New Toolkit_ApplicationLauncher(MainForm)
        CurrentApplication.Run(Arguments)
    End Sub
End Module