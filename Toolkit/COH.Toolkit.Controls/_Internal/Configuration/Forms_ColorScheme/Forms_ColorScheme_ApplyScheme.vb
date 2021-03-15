Namespace Controls.Configuration
    Partial Public Class FormsConfiguration_ColorScheme

        Public Sub ApplyColorScheme(ByRef SourceForm As Form)
            ApplyColorScheme(Me, SourceForm)
        End Sub
        Public Shared Sub ApplyColorScheme(ByRef ColorScheme As FormsConfiguration_ColorScheme, ByRef SourceForm As Form)
            SourceForm.BackColor = ColorScheme.Form_Background.Color
            ApplyColorScheme_ToControls(ColorScheme, SourceForm)
        End Sub
        Private Shared Sub ApplyColorScheme_ToControls(ByRef ColorScheme As FormsConfiguration_ColorScheme, ByRef SourceControl As Control)
            ApplyColorScheme_ToControl(ColorScheme, SourceControl)
            For Each ChildControl As Control In SourceControl.Controls
                ApplyColorScheme_ToControls(ColorScheme, ChildControl)
            Next
        End Sub
        Private Shared Sub ApplyColorScheme_ToControl(ByRef ColorScheme As FormsConfiguration_ColorScheme, ByRef SourceControl As Control)
            If SourceControl Is GetType(TabControl) Then
                ApplyColorScheme_ToControl_TabControl(ColorScheme, SourceControl)
            End If
        End Sub

#Region "Individual Controls"
        Private Shared Sub ApplyColorScheme_ToControl_TabControl(ByRef ColorScheme As FormsConfiguration_ColorScheme, ByRef SourceControl As TabControl)
            For Each Page As TabPage In SourceControl.TabPages
                Page.BackColor = ColorScheme.Form_TabPages_Background
                ApplyColorScheme_ToControls(ColorScheme, Page)
            Next
        End Sub
#End Region

    End Class
End Namespace

