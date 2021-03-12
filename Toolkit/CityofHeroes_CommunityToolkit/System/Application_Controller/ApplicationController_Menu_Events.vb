Namespace Toolkit
    Partial Public Class ToolkitController

#Region "Menu Events"
        Protected Overridable Sub OnMenuClicked(ID As String)
        End Sub
        Private Sub OnHandleMenuClicked(ID As String) Handles pTheMenu.MenuClicked
            OnMenuClicked(ID)
        End Sub
#End Region

#Region "Standard Menus"
        Public Sub ExitProgram()
            '//LOgging
            '//Disposing
            OnHandleShutDown()
            Environment.Exit(0)
        End Sub
        Public Overridable Sub OnHandleShutDown()
        End Sub
#End Region

    End Class
End Namespace