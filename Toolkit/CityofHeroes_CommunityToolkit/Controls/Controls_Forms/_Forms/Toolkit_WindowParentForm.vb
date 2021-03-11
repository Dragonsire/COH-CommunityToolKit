Imports System.Drawing

Namespace Toolkit.Controls
    Public Class ControlFreak_ParentForm

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
            MainMenuStrip = BannerMenu.MenuStrip
        End Sub
#End Region

#Region "Internal Functions"
        Private Function Calculate_ChildFormsArea() As Rectangle
            Dim HeightAdjust As Integer = BannerMenu.Height
            Return New Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height - HeightAdjust)
        End Function
#End Region


    End Class
End Namespace