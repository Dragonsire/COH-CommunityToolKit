Imports System.Drawing
Imports COH.ControllerModules.Pathways
Imports COH.Toolkit.ControllerModules.Pathways
Imports COH.Toolkit.Controls

Namespace Toolkit
    Partial Public Class ToolkitController

#Region "Properties"
        Private ProgramIcon As Image
        Private rSplashScreen As COH_Toolkit_SplashScreen
#End Region

#Region "Splash Screen"
        Private Sub PrepareSplashScreen(Optional UseSplash As Boolean = True)
            If UseSplash = False Then Exit Sub
            rSplashScreen = New COH_Toolkit_SplashScreen
            rSplashScreen.PrepareUsage(ControllerModule_PathwaysRegistry.Retrieve_VersionInfo, 100)
            rSplashScreen.TopMost = True
            rSplashScreen.Show()
            Application.DoEvents()
            rSplashScreen.Refresh()
        End Sub
        Private Sub UnloadSplash()
            If Not (rSplashScreen Is Nothing) Then Exit Sub
            rSplashScreen.Close()
        End Sub
        Protected Sub UpdateSplashScreen(Text As String, NewValue As Integer, Optional Sleep As Boolean = False, Optional SleepAmount As Integer = 300)
            If Not (rSplashScreen Is Nothing) Then Exit Sub
            If rSplashScreen Is Nothing Then Exit Sub
            rSplashScreen.UpdateProgress(Text, NewValue, Sleep, SleepAmount)
        End Sub
        Private Sub SplashScreenUpdate(Text As String, NewValue As Integer, Sleep As Boolean, SleepAmount As Integer) Handles rPathways.SplashScreenUpdate, rWindowManager.SplashScreenUpdate
            UpdateSplashScreen(Text, NewValue, Sleep, SleepAmount)
        End Sub
        Protected Overridable Sub OnLoadContent()
        End Sub
#End Region

#Region "AboutBox"
        Protected Function OpenAboutBox()
            Dim ExpectedFileLocation As String = IO.Path.Combine(rPathways.RootPath, "ChangeLog.rtf")
            Dim SelectedForm = New ControlFreak_AboutBox
            'WindowManager.UIController.ModifyWindow_CustomConfiguration(SelectedForm)
            SelectedForm.PrepareUsage(ProgramName, ProgramIcon, ControllerModule_PathwaysRegistry.Retrieve_VersionInfo, ExpectedFileLocation)
            WindowManager.UIController.OpenWindow(SelectedForm)
            Return True
        End Function
#End Region
    End Class
End Namespace