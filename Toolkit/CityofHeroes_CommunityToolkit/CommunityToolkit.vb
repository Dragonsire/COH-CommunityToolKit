Imports System.Drawing

Namespace Toolkit.Controls
    Public Class COH_CommunityToolkit_Main

#Region "References"
        Protected Friend ReadOnly Property ProgramController As ToolkitController
            Get
                Return ToolkitController.Instance
            End Get
        End Property
#End Region

#Region "Properties"
        Public ReadOnly Property ChildFormArea As Rectangle
            Get
                Return Calculate_ChildFormsArea()
            End Get
        End Property
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
            'Update_CurrentState(CurrentState_Enum.ModifyingUI)
            'Update_CurrentState(CurrentState_Enum.Ready)
        End Sub
        Protected Sub Handle_InitializeDefaults()
            'MyBase.Handle_InitializeDefaults()
        End Sub
        Protected Sub Handle_InitializeComponents()
            'MyBase.Handle_InitializeComponents()
            InitializeComponent()
            '  MainMenuStrip = BannerMenu.MenuStrip
        End Sub
#End Region

#Region "Internal Functions"
        Private Function Calculate_ChildFormsArea() As Rectangle
            ' Dim HeightAdjust As Integer = BannerMenu.Height
            ' Return New Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height - HeightAdjust)
        End Function
#End Region



#Region "Startup"
        Private Sub COH_Tools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        End Sub
#End Region

#Region "Display"
        Public Function AvailableClientArea() As Rectangle
            Return New Rectangle(Me.ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height - Me.BannerMenu.Height)
        End Function
#End Region

#Region "FileMenu"
        Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
            End
        End Sub
#End Region

#Region "Menu - Editors"
        Private Sub CharacterClassEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Cursor.Current = Cursors.WaitCursor
            ' COH_ContentController.Instance.OpenEditor_ModdableContentEditor()
            Cursor.Current = Cursors.Default
        End Sub
        Private Sub RebuildStandardProjectToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Cursor.Current = Cursors.WaitCursor
            ' COH_ContentController.Instance.Start_FreshProjectFile_Standard(True)
            Cursor.Current = Cursors.Default
        End Sub
        Private Sub PowerSetsToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Cursor.Current = Cursors.WaitCursor
            ' COH_ContentController.Instance.BuildXML_FromDef_PowerSets_All(Nothing, True)
            Cursor.Current = Cursors.Default
        End Sub
        Private Sub PowerCategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Cursor.Current = Cursors.WaitCursor
            ' COH_ContentController.Instance.BuildXML_FromDef_PowerCategory_All(Nothing, True)
            Cursor.Current = Cursors.Default
        End Sub
        Private Sub MessageStoreEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Cursor.Current = Cursors.WaitCursor
            ' COH_ContentController.Instance.BuildXML_FromDef_PowerCategory_All(Nothing, True)
            Cursor.Current = Cursors.Default
        End Sub
#End Region

    End Class
End Namespace