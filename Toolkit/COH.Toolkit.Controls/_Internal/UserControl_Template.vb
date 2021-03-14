Imports COH.CodeManagement.Enums.Toolkit

Namespace Toolkit.Controls
    Public Class UserControl_Template

#Region "Protected Properties"
        Protected Property CurrentEditMode As UserControls_EditMode
        Protected Property IsLoaded As Boolean = False
        Protected Property IsModified As Boolean = False
        Protected Property Changes_Locked As Boolean
        Protected ReadOnly Property ContentController As ISupport_ToolkitController
            Get
                Return pContentController
            End Get
        End Property
        Private WithEvents pContentController As ISupport_ToolkitController
#End Region

#Region "Initialize"
        Public Sub New()
            Me.New(Nothing)
        End Sub
        Public Sub New(ByRef TheContentController As ISupport_ToolkitController)
            pContentController = TheContentController
            Changes_Locked = True
            InitializeComponent()
            SetDefaults()
        End Sub
        Private Sub SetDefaults()
            CurrentEditMode = UserControls_EditMode.ViewOnly
            Changes_Locked = True
            With Content_FormTip
                .AutoPopDelay = 5000
                .InitialDelay = 1000
                .ReshowDelay = 200
                .ShowAlways = True
            End With
        End Sub
        Private Sub UserControl_Loaded(sender As Object, e As EventArgs) Handles Me.Load
            IsLoaded = True
        End Sub
        Protected Overridable Sub DisposeAdditional()
        End Sub
#End Region

#Region "Modified"
        Public Overridable Sub ContentWasModified() Handles pContentController.ContentWasModified
            If IsLoaded = False Then Exit Sub
            IsModified = True
        End Sub
#End Region

#Region "Overridable Functions"
        Public Overridable Sub ConfigureUI_Begin()
            Changes_Locked = True
        End Sub
        Public Overridable Sub ConfigureUI_Finish()
            Changes_Locked = False
        End Sub
#End Region

#Region "Set Appearance - Controls"
        'Public Sub ApplyColorScheme()
        '//Settings.ApplyColorScheme(Me)
        'End Sub
#End Region
    End Class
End Namespace