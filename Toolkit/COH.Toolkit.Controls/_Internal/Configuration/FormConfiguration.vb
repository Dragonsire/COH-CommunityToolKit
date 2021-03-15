Imports System.ComponentModel
Imports COH.Toolkit.Controls

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class FormConfiguration

#Region "Properties"
        Public Property ColorScheme As FormsConfiguration_ColorScheme
        Public Property Settings As FormsConfiguration_Settings
        '//Public Property Skin As WindowFormsConfiguration_Skin
        '//Public Property Skin_DialogButtons As WindowFormsConfiguration_Skin_DialogButtons
        Public Property Parenting As FormsConfiguration_Parenting
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            If ResetDefaults = True Then ResetToDefault()
        End Sub
        Public Sub New(ByRef SourceControl As Control)
            Me.New(True)
            Settings.UpdateSettings_FromControl(SourceControl)
        End Sub
        Public Sub New(ByRef SourceControl As UserControl)
            Me.New(True)
            Settings.UpdateSettings_FromControl(SourceControl)
        End Sub

#End Region

#Region "Initialize"
        Public Sub ResetToDefault()
            ColorScheme = New FormsConfiguration_ColorScheme()
            Settings = New FormsConfiguration_Settings()
            '//Skin = New WindowFormsConfiguration_Skin()
            '//Skin_DialogButtons = New WindowFormsConfiguration_Skin_DialogButtons
            Parenting = New FormsConfiguration_Parenting
        End Sub
        Public Sub UpdateFromControl(ByRef SourceControl As Control)
            Settings.UpdateSettings_FromControl(SourceControl)
        End Sub
#End Region

#Region "Crate Window Forms"
        Public Function CreateSkinnedForm(ByRef Control As Control) As FormWrapper
            Dim NewForm As FormWrapper = Nothing
            If Control.GetType.IsSubclassOf(GetType(FormWrapper)) Then
                NewForm = Control '// Do Nothing Not Being Skinned
                ' Settings.ModifyForm_FromSettings(NewForm)
            Else
                If Control.GetType.IsSubclassOf(GetType(Form)) Then
                    NewForm = CreateSkinnedForm(CType(Control, Form), Me)
                ElseIf Control.GetType.IsSubclassOf(GetType(UserControl_Template)) Then
                    NewForm = CreateSkinnedForm(CType(Control, UserControl_Template), Me)
                Else
                    NewForm = CreateSkinnedForm(Control, Me)
                End If
            End If
            Return NewForm
        End Function
        Public Function CreateForm(ByRef Control As Control) As Form
            Dim NewForm As Form = Nothing
            If Control.GetType.IsSubclassOf(GetType(Form)) Then
                NewForm = Control '// Do Nothing Not Being Skinned
                'Settings.ModifyForm_FromSettings(NewForm)
                If (Parenting.ParentForm Is Nothing) = False Then
                    NewForm.Dock = DockStyle.None
                    NewForm.TopLevel = False
                    NewForm.StartPosition = FormStartPosition.Manual
                    NewForm.MinimizeBox = False
                    NewForm.MaximizeBox = False
                    NewForm.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
                End If
            Else
                NewForm = CreateForm(Control, Me)
            End If
            Return NewForm
        End Function
#End Region

#Region "Create Window Forms From Configuration"
        Public Shared Function CreateSkinnedForm(ByRef Control As UserControl_Template, ByRef CurrentConfiguration As FormConfiguration) As FormWrapper
            Dim NewForm As FormWrapper '= CurrentConfiguration.Settings.CreateForm_FromSettings(WindowForms_Skin_FormTemplates.WindowForms_Standard)
            LinkControlToForm(Control, NewForm, CurrentConfiguration, True)
            Return NewForm
        End Function
        Public Shared Function CreateSkinnedForm(ByRef Control As Control, ByRef CurrentConfiguration As FormConfiguration) As FormWrapper
            Dim NewForm As FormWrapper '= CurrentConfiguration.Settings.CreateForm_FromSettings(WindowForms_Skin_FormTemplates.WindowForms_Standard)
            LinkControlToForm(Control, NewForm, CurrentConfiguration, False)
            Return NewForm
        End Function
        Public Shared Function CreateSkinnedForm(ByRef Control As Form, ByRef CurrentConfiguration As FormConfiguration) As FormWrapper
            Dim NewForm As FormWrapper '= CurrentConfiguration.Settings.CreateForm_FromSettings(WindowForms_Skin_FormTemplates.WindowForms_Standard)
            Control.TopMost = False
            Control.TopLevel = False
            Control.FormBorderStyle = FormBorderStyle.None
            LinkControlToForm(Control, NewForm, CurrentConfiguration, False)
            Return NewForm
        End Function
        Public Shared Function CreateForm(ByRef Control As Form, ByRef CurrentConfiguration As FormConfiguration, Optional UseParentControl As Form = Nothing) As Form
            Dim NewForm As Form '= CurrentConfiguration.Settings.CreateForm_FromSettings(WindowForms_Skin_FormTemplates.Standard)
            Control.TopMost = False
            Control.TopLevel = False
            Control.FormBorderStyle = FormBorderStyle.None
            LinkControlToForm_StandardForm(Control, NewForm, CurrentConfiguration)
            Return NewForm
        End Function
        Public Shared Function CreateForm(ByRef Control As Control, ByRef CurrentConfiguration As FormConfiguration, Optional UseParentControl As Form = Nothing) As Form
            Dim NewForm As Form '= CurrentConfiguration.Settings.CreateForm_FromSettings(WindowForms_Skin_FormTemplates.Standard)
            LinkControlToForm_StandardForm(Control, NewForm, CurrentConfiguration)
            Return NewForm
        End Function
#End Region

#Region "Link Control to Form"
        Private Shared Sub LinkControlToForm(ByRef SelectedControl As Control, ByRef SourceForm As FormWrapper, ByRef CurrentConfiguration As FormConfiguration, Optional AllowDialogButtons As Boolean = False)
            SelectedControl.Dock = DockStyle.Fill
            SelectedControl.Visible = True
            SourceForm.Controls.Add(SelectedControl)
            CurrentConfiguration.ColorScheme.ApplyColorScheme(SourceForm)
            If AllowDialogButtons = True Then
            Else
            End If
            '//UPDATE BUTTONS
            'SourceForm.Link_MainControl(SelectedControl)
            'SourceForm.UpdateSkin(CurrentConfiguration.Skin, True)
        End Sub
        Private Shared Sub LinkControlToForm_StandardForm(ByRef SelectedControl As Control, ByRef SourceForm As Form, ByRef CurrentConfiguration As FormConfiguration)
            SelectedControl.Dock = DockStyle.Fill
            SelectedControl.Visible = True
            SourceForm.Controls.Add(SelectedControl)
            CurrentConfiguration.ColorScheme.ApplyColorScheme(SourceForm)
        End Sub
#End Region

#Region "Clone"
        Public Function CreateClone() As FormConfiguration
            Dim Destination As New FormConfiguration
            CloneTo(Destination)
            Return Destination
        End Function
        Public Sub CloneTo(ByRef Destination As FormConfiguration)
            With Destination
                .ColorScheme = ColorScheme.Clone
                '.Settings = Settings.Clone
                'If (Skin Is Nothing) Then
                '.Skin = Nothing
                'Else
                ''.Skin = Skin.Clone
                'End If
                ' If (Skin_DialogButtons Is Nothing) Then
                ' .Skin_DialogButtons = Nothing
                'Else
                ' .Skin_DialogButtons = Skin_DialogButtons.Clone
                ' End If
                'If Not (Parenting Is Nothing) Then .Parenting = Parenting.Clone
            End With
        End Sub
#End Region

    End Class
End Namespace