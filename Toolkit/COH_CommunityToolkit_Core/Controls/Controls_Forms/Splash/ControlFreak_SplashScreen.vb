Imports System.Drawing

Namespace  Controls
    Public Class COH_Toolkit_SplashScreen

#Region "Prepare USage"
        Public Sub PrepareUsage(Background As Image, ProgressBarColor As Color, Version As String, Max As Integer)
            DoubleBuffered = True
            StartPosition = FormStartPosition.CenterScreen
            BackgroundImageLayout = ImageLayout.Stretch
            Dim NewSize As Size = New Size(Background.Width, Background.Height + Me.ProgressBar1.Height)
            ClientSize = NewSize
            BackgroundImage = Background
            VersionLabel.Text = "Version : " & Version
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = Max
            ProgressBar1.Value = 0
            ProgressBar1.ForeColor = ProgressBarColor
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