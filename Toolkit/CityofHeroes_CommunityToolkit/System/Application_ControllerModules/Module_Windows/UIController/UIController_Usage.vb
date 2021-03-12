Imports System.Drawing

Namespace Toolkit.ControllerModules.WindowForms
    Partial Public NotInheritable Class UIController

#Region "Open/Create WindowForm From Configuration"
        Public Sub OpenWindow(ByRef SelectedForm As Form)
            'Handle_Event_WindowAdded(SelectedForm)
            SelectedForm.Show()
        End Sub
        Public Function OpenDialog(ByRef SelectedForm As Form) As DialogResult
            'Handle_Event_WindowAdded(SelectedForm)
            Return SelectedForm.ShowDialog
        End Function
#End Region

#If CONTROLFREAK_REMOVED Then
#Region "Create Forms - Windows Standard"
        Public Sub ModifyWindow_CustomConfiguration(ByRef TheWindow As WindowForms_Window, Optional AsDialog As TriBoolean = TriBoolean.Unknown)
            ModifyWindow_CustomConfiguration(TheWindow, True, SkinningEnabled, AlwaysUseSkinnedForms, AlwaysAplyColorScheme, IIf(AsDialog = TriBoolean.Unknown, AlwaysForceDock, (AsDialog = TriBoolean.False)))
        End Sub
        Public Sub ModifyWindow_CustomConfiguration(ByRef TheWindow As WindowForms_Window, UseControlDefaults As Boolean, ApplySkin As Boolean, OverrideSkin As Boolean, ApplyColorScheme As Boolean, Optional UseParentControl As Boolean = False)
            Dim CurrentConfiguration As WindowFormsConfiguration = Nothing
            If UseControlDefaults = False Then
                CurrentConfiguration = Default_WindowsFormsConfiguration.Clone
                CurrentConfiguration.Skin.WindowSkin_DialogButtons = TheWindow.Return_DefaultFormConfiguration.Skin_DialogButtons
                CurrentConfiguration.UpdateFromControl(TheWindow)
            ElseIf UseControlDefaults = True Then
                CurrentConfiguration = TheWindow.Return_DefaultFormConfiguration
                If OverrideSkin = True Then
                    CurrentConfiguration.Skin = Default_WindowsFormsConfiguration.Skin.Clone
                    CurrentConfiguration.Skin.WindowSkin_DialogButtons = CurrentConfiguration.Skin_DialogButtons
                End If
            End If
            If UseParentControl = True Then AdjustConfiguration_ForParent(CurrentConfiguration)
            If SkinningEnabled = False Then ApplySkin = False
            TheWindow.ApplyConfiguration(CurrentConfiguration, ApplySkin, ApplyColorScheme)
        End Sub
        Public Function CreateWindow_ForControl(ByRef SelectedControl As WindowForms_UserControl, Optional UseControlDefaults As Boolean = True, Optional UseDefaultSkin As Boolean = False, Optional UseParentControl As Boolean = False) As Form
            Dim CurrentConfiguration As WindowFormsConfiguration = Nothing
            If UseControlDefaults = True Then
                CurrentConfiguration = SelectedControl.Return_DefaultFormConfiguration()
                If UseDefaultSkin = False Then Default_WindowsFormsConfiguration.Skin.CloneTo(CurrentConfiguration.Skin, True)
            Else
                CurrentConfiguration = Default_WindowsFormsConfiguration.Clone
                CurrentConfiguration.UpdateFromControl(SelectedControl)
            End If
            CurrentConfiguration.Skin.WindowSkin_DialogButtons = CurrentConfiguration.Skin_DialogButtons
            If UseParentControl = True Then AdjustConfiguration_ForParent(CurrentConfiguration)
            Dim TheForm As WindowForms_Window = CurrentConfiguration.CreateSkinnedForm(SelectedControl)
            Return TheForm
        End Function
        Public Function CreateWindow_ForControl(ByRef SelectedControl As Control, Optional UseParentControl As Boolean = False) As Form
            Dim CurrentConfiguration As WindowFormsConfiguration = Default_WindowsFormsConfiguration.Clone
            CurrentConfiguration.UpdateFromControl(SelectedControl)
            If UseParentControl = True Then AdjustConfiguration_ForParent(CurrentConfiguration)
            Return CreateWindow_ForControl_FromConfiguration(CurrentConfiguration, SelectedControl)
        End Function
        Public Function CreateWindow_ForControl_FromConfiguration(ByRef CurrentConfiguration As WindowFormsConfiguration, ByRef SelectedControl As Control) As Form
            Dim TheForm As Form = Nothing
            If AlwaysUseSkinnedForms = True Then
                CurrentConfiguration.Skin_DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.None
                TheForm = CurrentConfiguration.CreateSkinnedForm(SelectedControl)
            Else
                TheForm = CurrentConfiguration.CreateForm(SelectedControl)
            End If
            Return TheForm
        End Function
#End Region

#Region "Make Adjustments"
        Private Sub AdjustConfiguration_ForParent(ByRef CurrentConfiguration As WindowFormsConfiguration)
            CurrentConfiguration.Parenting = rParentSettings.Clone
            If AlwaysForceDock = True Then
                rParentSettings.Form_StartPosition = FormStartPosition.CenterParent
                rParentSettings.ParentFormDock = DockStyle.Fill
            End If
        End Sub
        Private Function AdjustFormToSize(S1 As Size, S2 As Size, S3 As Size) As Size
            Dim W, H As Integer
            W = (S1.Width - S2.Width) + 5
            H = (S1.Height - S2.Height) + 5
            Return New Size(S3.Width - W, S3.Height - H)
        End Function
        Private Function ShouldForceControlResize(S1 As Size, S2 As Size) As Boolean
            If (S1.Width > S2.Width) Or (S1.Height > S2.Height) Then Return True
            Return False
        End Function
#End Region

#Region "Open Windows Form - Generics"
        Public Sub OpenWindow(ByRef SelectedForm As Form, UseParentControl As Boolean, WindowState As ControlFreak_ParentControl_Location, Optional AlternativeParentControl As Control = Nothing, Optional ParentControlArea As Drawing.Rectangle = Nothing, Optional HideButtons As Boolean = False)
            Handle_Event_WindowAdded(SelectedForm)
            If UseParentControl = True AndAlso (AlternativeParentControl Is Nothing) = True Then
                ShowWindow_HasParent(SelectedForm, rParentControl, WindowState, rParentSettings.ParentLocation, HideButtons)
            ElseIf UseParentControl = True AndAlso (AlternativeParentControl Is Nothing) = False Then
                ShowWindow_HasParent(SelectedForm, AlternativeParentControl, WindowState, ParentControlArea, HideButtons)
            Else
                ShowWindow_Independent(SelectedForm)
            End If
        End Sub
        Private Sub ShowWindow_Independent(ByRef SelectedForm As Form)
            '//SPECIAL THEMING / HANDLE CUSTOM FORM DIALOGS HERE
            SelectedForm.Show()
        End Sub
        Private Sub ShowWindow_HasParent(ByRef SelectedForm As Form, ByRef ParentControl As Control, WindowState As ControlFreak_ParentControl_Location, ParentControlArea As Drawing.Rectangle, HideButtons As Boolean)
            If HideButtons = True Then SelectedForm.ControlBox = False
            Select Case WindowState
                Case ControlFreak_ParentControl_Location.Center
                    Dim CenterFormLocation As Drawing.Point = DS._CoreLibrary_.v6.HelperFunctions.Controls.FindCenterLocation_Control(SelectedForm, ParentControl.ClientRectangle)
                    SelectedForm.Visible = False
                    ParentControl.Controls.Add(SelectedForm)
                    SelectedForm.Location = CenterFormLocation
                Case ControlFreak_ParentControl_Location.DockFill
                    SelectedForm.Visible = False
                    SelectedForm.Dock = DockStyle.None
                    SelectedForm.TopLevel = False
                    ParentControl.Controls.Add(SelectedForm)
                    SelectedForm.Location = ParentControlArea.Location
                    SelectedForm.Size = ParentControlArea.Size
                    SelectedForm.MinimizeBox = False
                    SelectedForm.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            End Select
            SelectedForm.Show()
        End Sub
#End Region

#Region "Events"
        Event AllWindowsClosed()
        Event PrimaryWindowsIsOpen()
        Private Sub Handle_Event_WindowAdded(ByRef SelectedForm As Form)
            If rFormsInUse Is Nothing Then rFormsInUse = New List(Of Form)
            AddHandler SelectedForm.Disposed, AddressOf Handle_Event_WindowDisposed
            rFormsInUse.Add(SelectedForm)
            RaiseEvent PrimaryWindowsIsOpen()
        End Sub
        Private Sub Handle_Event_WindowDisposed(sender As Object, e As EventArgs)
            Dim NewForm As Form = sender
            RemoveHandler NewForm.Disposed, AddressOf Handle_Event_WindowDisposed
            rFormsInUse.Remove(NewForm)
            If rFormsInUse.Count = 0 Then RaiseEvent AllWindowsClosed()
        End Sub
#End Region

#End If
    End Class
End Namespace
