Namespace Controls.Configuration
    Partial Public Class WindowFormsConfiguration_Settings
        Public Function CreateForm_FromSettings(FormTemplate As WindowForms_Skin_FormTemplates) As Form
            Return CreateForm_FromSettings(Me, FormTemplate)
        End Function
        Public Function CreateForm_FromSettings(ByRef FormTemplate As Form) As Form
            Return ModifyForm_FromSettings(Me, FormTemplate.Clone)
        End Function
        Public Function ModifyForm_FromSettings(ByRef SelectedForm As Form) As Form
            Return ModifyForm_FromSettings(Me, SelectedForm)
        End Function
        Public Shared Function CreateForm_FromSettings(ByRef Settings As WindowFormsConfiguration_Settings, Optional FormTemplate As WindowForms_Skin_FormTemplates = WindowForms_Skin_FormTemplates.Standard) As Form
            Dim Template As Form = Nothing
            Select Case FormTemplate
                Case WindowForms_Skin_FormTemplates.Standard
                    Template = New Form
                Case WindowForms_Skin_FormTemplates.WindowForms_Standard
                    Template = New WindowForms_Window
            End Select
            Return ModifyForm_FromSettings(Settings, Template)
        End Function
        Public Shared Function ModifyForm_FromSettings(ByRef Settings As WindowFormsConfiguration_Settings, ByRef SelectedForm As Form) As Form
            With SelectedForm
                .SuspendLayout()
                If SelectedForm Is GetType(ISupportInitialize) Then CType(SelectedForm, ISupportInitialize).BeginInit()
                .FormBorderStyle = Settings.Form_BorderStyle
                .MinimumSize = Settings.Form_Size_Minimal
                .ClientSize = Settings.Form_Size
                .MaximumSize = Settings.Form_Size_Maximum
                .TopMost = Settings.Form_StartPosition_TopMost
                .HelpButton = Settings.ShowButton_Help
                .MinimizeBox = Settings.ShowButton_Min
                .MaximizeBox = Settings.ShowButton_Max
                .Text = Settings.Form_Text
                .Icon = Settings.Form_Icon
                .Font = Settings.Window_Font.Return_Font
                .ForeColor = Settings.Window_Font.FontColor.Color
                .StartPosition = Settings.Form_StartPosition
                .WindowState = Settings.Form_State
                If SelectedForm Is GetType(ISupportInitialize) Then CType(SelectedForm, ISupportInitialize).EndInit()
                .ResumeLayout()
            End With
            Return SelectedForm
        End Function
    End Class
End Namespace
