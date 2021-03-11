Namespace Toolkit.Controls
    Public Class COH_Toolkit_SplashScreen

#Region "Prepare USage"
        Public Sub PrepareUsage(Version As String, Max As Integer)
            DoubleBuffered = True
            StartPosition = FormStartPosition.CenterScreen
            VersionLabel.Text = "Version : " & Version
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = Max
            ProgressBar1.Value = 0
            ProgressBar1.ForeColor = Drawing.Color.Red
        End Sub
        Public Sub UpdateProgress(Name As String, NewValue As Integer, Optional Sleep As Boolean = False, Optional SleepAmount As Integer = 300)
            Label_Progress.Text = Name
            ProgressBar1.Value = NewValue
            Application.DoEvents()
            If Sleep = True Then Threading.Thread.Sleep(SleepAmount)
        End Sub
#End Region


    End Class
End Namespace