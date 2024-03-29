﻿Imports COH.CodeManagement.Enums.Toolkit
Imports COH.Controls.Configuration

Namespace Controls
    Public Class ToolkitForm
        Inherits Form
        Implements IDisposable

#Region "Properties"
        Public Shadows Property Enabled As Boolean
            Get
                Return MyBase.Enabled
            End Get
            Set(value As Boolean)
                MyBase.Enabled = value
                If RenderingEnabled() = True Then rFormSkin.UpdateFormEnabled(value)
            End Set
        End Property
        Protected Property CurrentEditMode As UserControls_EditMode
        Protected Property IsLoaded As Boolean = False
        Protected Property IsModified As Boolean = False
        Protected Property Changes_Locked As Boolean
        Friend WithEvents Content_FormTip As ToolTip
        Protected ReadOnly Property ContentController As ISupport_ToolkitController
            Get
                Return rContentController
            End Get
        End Property
        Private WithEvents rContentController As ISupport_ToolkitController
        Private rFormSkin As FormsConfiguration_FormSkin
        Private rRenderingEnabled As Boolean
        Private components As System.ComponentModel.IContainer
        Private rRenderSections As FormRegions_DrawSections
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(Nothing)
        End Sub
        Public Sub New(ByRef TheContentController As ISupport_ToolkitController)
            rContentController = TheContentController
            Changes_Locked = True
            InitializeComponent()
            ConfigureUI_Defaults()
        End Sub
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Content_FormTip = New ToolTip(Me.components)
            Me.SuspendLayout()
            '
            'ToolkitForm
            '
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.Name = "ToolkitForm"
            Me.ResumeLayout(False)
        End Sub
#End Region

#Region "Overridable Functions"
        Protected Overridable Sub ConfigureUI_Defaults()
            CurrentEditMode = UserControls_EditMode.ViewOnly
            Changes_Locked = True
            With Content_FormTip
                .AutoPopDelay = 5000
                .InitialDelay = 1000
                .ReshowDelay = 200
                .ShowAlways = True
            End With
        End Sub
        Protected Overridable Sub ConfigureUI_Begin()
            Changes_Locked = True
        End Sub
        Protected Overridable Sub ConfigureUI_Finish()
            Changes_Locked = False
        End Sub
        Protected Overridable Sub DisposeAdditional()
        End Sub
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                    If rFormSkin IsNot Nothing Then rFormSkin.dispose
                    DisposeAdditional()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub
#End Region

#Region "Modified"
        Public Overridable Sub ContentWasModified() Handles rContentController.ContentWasModified
            If IsLoaded = False Then Exit Sub
            IsModified = True
        End Sub
#End Region

#Region "Checks"
        Private Function RenderingEnabled() As Boolean
            If DesignMode Then Return False
            If rFormSkin Is Nothing Then Return False
            Return rRenderingEnabled
        End Function
#End Region

#Region "External Commands"
        Public Event DialogButtonPressed(Key As String)
        Public Sub PressButton_Close()
            Close()
        End Sub
        Public Sub PressButton_ToggleMax()
            If WindowState = FormWindowState.Maximized Then
                WindowState = FormWindowState.Normal
            Else
                WindowState = FormWindowState.Maximized
            End If
        End Sub
        Public Sub PressButton_ToggleMin()
            If WindowState = FormWindowState.Minimized Then
                WindowState = FormWindowState.Normal
            Else
                WindowState = FormWindowState.Minimized
            End If
        End Sub
        Public Sub DockControl(ByRef TheControl As Control)
            If RenderingEnabled() = True Then
                TheControl.Font = Me.Font
                TheControl.Size = rFormSkin.AvailableFormArea.Size
                Controls.Add(TheControl)
                TheControl.Location = rFormSkin.AvailableFormArea.Location
            Else
                TheControl.Font = Me.Font
                TheControl.Dock = DockStyle.Fill
                Controls.Add(TheControl)
            End If
        End Sub
        Public Sub SetMousePosition()
            'Dim Currentposition As Drawing.Point = HelperFunctions.MousePointer.GetMousePosition
            'HelperFunctions.MousePointer.SendClick()
            ' HelperFunctions.MousePointer.SetMousePosition(Currentposition.X, Currentposition.Y)
        End Sub
#End Region

#Region "Form Events"
        Private Sub UserControl_Loaded(sender As Object, e As EventArgs) Handles Me.Load
            IsLoaded = True
        End Sub
        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            If RenderingEnabled() = False Then Exit Sub
            rFormSkin.Calculate_DrawableLocations(ClientRectangle)
            InvalidateWindow()
        End Sub
#End Region

#Region "Mouse Events"
        Private Sub WindowEvent_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            If RenderingEnabled() = False Then Exit Sub
            rFormSkin.ProcessMouseEvent_MouseMove(e)
        End Sub
        Private Sub WindowEvent_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            If RenderingEnabled() = False Then Exit Sub
            rFormSkin.ProcessMouseEvent_MouseDown(e)
        End Sub
        Private Sub WindowEvent_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            If RenderingEnabled() = False Then Exit Sub
            rFormSkin.ProcessMouseEvent_MouseUp(e)
        End Sub
        Private Sub WindowEvent_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
            If RenderingEnabled() = False Then Exit Sub
            rFormSkin.ProcessMouseEvent_MouseLeave(e)
        End Sub
        Private Sub WindowEvent_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
            If RenderingEnabled() = False Then Exit Sub
            rFormSkin.ProcessMouseEvent_MouseHover(e)
        End Sub
        Public Sub RefreshMouse()
            ResetMouseEventArgs()
        End Sub
#End Region

#Region "Drawing"
        Public Sub InvalidateButtons()
            InvalidateWindow()
            Exit Sub

            RefreshMouse()
            rRenderSections = FormRegions_DrawSections.WindowButtons
            DrawWindow(Me.CreateGraphics)
            rRenderSections = FormRegions_DrawSections.All
        End Sub
        Public Sub InvalidateWindow()
            RefreshMouse()
            rRenderSections = FormRegions_DrawSections.All
            Invalidate()
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            If RenderingEnabled() = False Then Exit Sub
            DrawWindow(e.Graphics)
        End Sub
        Private Sub DrawWindow(ByVal CurrentGraphics As Graphics)
            If ClientRectangle.Width = 0 Or ClientRectangle.Height = 0 Then Exit Sub
            If rRenderSections = FormRegions_DrawSections.All Then
                rFormSkin.Draw_Window(Me.Text, CurrentGraphics)
            Else
                'If rRenderSections.HasFlag(FormRegions_DrawSections.WindowButtons) Then rFormSkin.Draw_Window_Buttons(CurrentGraphics)
                'If rRenderSections.HasFlag(FormRegions_DrawSections.TitleBar) Then rFormSkin.Draw_TitleBar(Me.Text, CurrentGraphics)
                'If rRenderSections.HasFlag(FormRegions_DrawSections.TitleBar) Then Draw_TitleBar(Me.Text, CurrentGraphics)
                '//If rRenderSections.HasFlag(FormRegions_DrawSections.DialogButtons) Then Draw_DialogButtons(Me.Text, CurrentGraphics)
            End If
        End Sub
#End Region

#Region "Update Configurations"
        Public Overridable Function Return_DefaultFormConfiguration() As FormsConfiguration
            Return New FormsConfiguration(Me)
        End Function
        Public Sub ApplyConfiguration(ByRef Configuration As FormsConfiguration, Optional ApplySkin As Boolean = False, Optional ApplyColorScheme As Boolean = False)
            If (Configuration.Settings IsNot Nothing) Then Configuration.Settings.ModifyForm_FromSettings(Me)
            If (Configuration.Parenting IsNot Nothing) Then Configuration.Parenting.ModifyForm_FromSettings(Me)
            If ApplyColorScheme = True AndAlso (Configuration.ColorScheme IsNot Nothing) Then Configuration.ColorScheme.ApplyColorScheme(Me)
            If ApplySkin = True AndAlso (Configuration.WindowSkin IsNot Nothing) Then UpdateSkin(Configuration.WindowSkin, True)
        End Sub
        Public Sub UpdateSkin(ByRef SelectedSkin As FormsConfiguration_FormSkin, Optional Enabled As Boolean = True)
            If rRenderingEnabled = True AndAlso (rFormSkin IsNot Nothing) Then
                If (SelectedSkin Is Nothing) Then FormRendering_DisableSkinning()
            End If
            If SelectedSkin Is Nothing Then Exit Sub
            rFormSkin = SelectedSkin
            rFormSkin.LinkForm(Me)
            If Enabled = True Then FormRendering_EnableSkinning()
        End Sub
        Private Sub FormRendering_EnableSkinning()
            rRenderingEnabled = True
            DoubleBuffered = True
            SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
            FormBorderStyle = FormBorderStyle.None
            rFormSkin.Calculate_DrawableLocations(ClientRectangle)
            InvalidateWindow()
        End Sub
        Private Sub FormRendering_DisableSkinning()
            SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, False)
            rRenderingEnabled = False
        End Sub
#End Region

#Region "Create Window Shortcuts"
        Public Sub ShowMe_AsForm(Optional ApplyDefaultSkin As Boolean = False, Optional ApplyColorScheme As Boolean = False)
            ShowMe_AsForm(Return_DefaultFormConfiguration, ApplyDefaultSkin, ApplyColorScheme)
        End Sub
        Public Sub ShowMe_AsForm(ByRef Configuration As FormsConfiguration, Optional ApplySkin As Boolean = False, Optional ApplyColorScheme As Boolean = False)
            ApplyConfiguration(Configuration, ApplySkin, ApplyColorScheme)
            Show()
        End Sub
        Public Function ShowMe_AsDialog(Optional ApplyDefaultSkin As Boolean = False, Optional ApplyColorScheme As Boolean = False) As DialogResult
            Return ShowMe_AsDialog(Return_DefaultFormConfiguration, ApplyDefaultSkin, ApplyColorScheme)
        End Function
        Public Function ShowMe_AsDialog(ByRef Configuration As FormsConfiguration, Optional ApplySkin As Boolean = False, Optional ApplyColorScheme As Boolean = False) As DialogResult
            ApplyConfiguration(Configuration, ApplySkin, ApplyColorScheme)
            Return ShowDialog()
        End Function
        Public Sub ShowMe_AsChildForm(Parent As FormsConfiguration_Parenting, Optional ApplyDefaultSkin As Boolean = False, Optional ApplyColorScheme As Boolean = False)
            Dim Settings = Return_DefaultFormConfiguration()
            Settings.Parenting = Parent
            ShowMe_AsForm(Settings, ApplyDefaultSkin, ApplyColorScheme)
        End Sub
        Public Sub ShowMe_AsChildForm(ByRef MDIParent As Form, Optional Docking As DockStyle = DockStyle.Fill, Optional Location As Rectangle = Nothing, Optional ApplyDefaultSkin As Boolean = False, Optional ApplyColorScheme As Boolean = False)
            Dim Settings = Return_DefaultFormConfiguration()
            Settings.Parenting.ParentForm = MDIParent
            Settings.Parenting.ParentFormDock = Docking
            Settings.Parenting.ParentLocation = Location
            Settings.Parenting.Form_StartPosition = FormStartPosition.CenterParent
            If Not (MDIParent Is Nothing) Then
                Settings.Parenting.ParentForm = MDIParent
                Settings.Parenting.ParentFormDock = Docking
                Settings.Parenting.Form_StartPosition = FormStartPosition.CenterParent
            End If
            If Not (Location = Nothing) Then
                Settings.Parenting.ParentLocation = Location
                Settings.Parenting.Form_StartPosition = FormStartPosition.Manual
            End If
            ShowMe_AsForm(Settings, ApplyDefaultSkin, ApplyColorScheme)
        End Sub
#End Region
    End Class
End Namespace