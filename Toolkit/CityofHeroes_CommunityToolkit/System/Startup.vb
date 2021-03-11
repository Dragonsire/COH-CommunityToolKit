Imports COH.Controls
Imports COH.Helpers

Public Module Startup
    Public mApplication As Toolkit_ApplicationLauncher
    Public MasterControl As ApplicationController
    Public mMainForm As ControlFreak_ParentForm
    Sub Main(Arguments As String())
        MasterControl = New ApplicationController(Application.StartupPath)
        '//mMainForm = MasterControl.MainForm
        mApplication = New Toolkit_ApplicationLauncher(mMainForm)
        mApplication.Run(Arguments)
    End Sub
End Module