Imports COH.CodeManagement.Enums.Toolkit

Namespace Toolkit
    Partial Public Class ToolkitController

#Region "Menu Events"
        Private Sub OnHandleMenuClicked(MenuCommand As [Enum]) Handles pTheMenu.MenuClicked
            Dim TheType = MenuCommand.GetType
            If TheType = GetType(MenuEnum_PIGGMenu) Then
                OnMenuClicked(CType(MenuCommand, MenuEnum_PIGGMenu))
            ElseIf TheType = GetType(MenuEnum_PIGGMenu_OpenSpecified) Then
                OnMenuClicked(CType(MenuCommand, MenuEnum_PIGGMenu_OpenSpecified))
            ElseIf TheType = GetType(MenuEnum_PIGGMenu_ExtractSpecified) Then
                OnMenuClicked(CType(MenuCommand, MenuEnum_PIGGMenu_ExtractSpecified))
            End If
        End Sub
#End Region

#Region "Menu Commands  - File Menu"
        Private Sub OnMenuClicked(MenuCommand As CodeManagement.Enums.Toolkit.MenuEnum_FileMenu)
            MsgBox(MenuCommand.ToString)
        End Sub
#End Region

#Region "Menu Commands  - PIGG Menu"
        Private Sub OnMenuClicked(MenuCommand As MenuEnum_PIGGMenu)
            Select Case MenuCommand
                Case MenuEnum_PIGGMenu.OpenPigg_LocateFile
                    rContentController.OpenPigg_LocateFile()
            End Select
        End Sub
        Private Sub OnMenuClicked(MenuCommand As MenuEnum_PIGGMenu_ExtractSpecified)
            MsgBox(MenuCommand.ToString)
        End Sub
        Private Sub OnMenuClicked(MenuCommand As MenuEnum_PIGGMenu_OpenSpecified)
            MsgBox(MenuCommand.ToString)
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