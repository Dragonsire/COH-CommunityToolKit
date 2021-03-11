Imports Microsoft.VisualBasic.ApplicationServices

Namespace Toolkit.Helpers
    Public Class Toolkit_ApplicationLauncher
        Inherits WindowsFormsApplicationBase

#Region "Private Properties"
        Private pMainForm As Form
#End Region

#Region "Initialize"
        Sub New(ByRef StartupForm As Form)
            '//MyBase.New
            pMainForm = StartupForm
            IsSingleInstance = True
            EnableVisualStyles = True
            ShutdownStyle = ShutdownMode.AfterMainFormCloses
        End Sub
        Protected Overrides Function OnInitialize(commandLineArgs As ObjectModel.ReadOnlyCollection(Of String)) As Boolean
            Return MyBase.OnInitialize(commandLineArgs)
        End Function
#End Region

#Region "Splash Screen"
        Protected Overrides Sub OnCreateSplashScreen()
            MyBase.OnCreateSplashScreen()
        End Sub
#End Region

#Region "Startup"
        Protected Overrides Function OnStartup(eventArgs As StartupEventArgs) As Boolean
            Return MyBase.OnStartup(eventArgs)
        End Function
        Protected Overrides Sub OnRun()
            Try
                MyBase.OnRun()
            Catch ex As Exception
                Dim ot As Integer = 0
            End Try
        End Sub
        Protected Overrides Sub OnCreateMainForm()
            MainForm = pMainForm
            MyBase.OnCreateMainForm()
        End Sub
        Protected Overrides Sub OnStartupNextInstance(eventArgs As ApplicationServices.StartupNextInstanceEventArgs)
            MyBase.OnStartupNextInstance(eventArgs)
        End Sub
        Protected Overrides Sub OnShutdown()
            MyBase.OnShutdown()
        End Sub
#End Region

#Region "Errors"
        Protected Overrides Function OnUnhandledException(e As UnhandledExceptionEventArgs) As Boolean
            Return MyBase.OnUnhandledException(e)
        End Function
#End Region
    End Class
End Namespace