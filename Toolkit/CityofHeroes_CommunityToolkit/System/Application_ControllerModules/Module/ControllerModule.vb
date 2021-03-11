Namespace ControllerModules
    Public MustInherit Class ControllerModule

#Region "Properties"
        Public ReadOnly Property ParentController As ToolkitController
            Get
                Return rParent
            End Get
        End Property
        Private rParent As ToolkitController
#End Region

#Region "Create New Instance"
        Public Sub New(ByRef ParentController As ToolkitController)
            rParent = ParentController
        End Sub
#End Region

#Region "Event"
        Public Event SplashScreenUpdate(Text As String, NewValue As Integer, Sleep As Boolean, SleepAmount As Integer)
        Protected Sub TriggerEvent_UpdateSplashScreen(Text As String, NewValue As Integer, Optional Sleep As Boolean = False, Optional SleepAmount As Integer = 300)
            RaiseEvent SplashScreenUpdate(Text, NewValue, Sleep, SleepAmount)
        End Sub
#End Region
    End Class
End Namespace