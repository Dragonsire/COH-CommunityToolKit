Imports System.Drawing

Namespace ControllerModules
    Partial Public NotInheritable Class ControllerModule_WindowManager

#Region "Locate Files"
        Public Function LocateFilePath_Open(Title As String, Filter As String, ByRef Result As String) As Boolean
            Dim InitialDirectory As String = ""
            If String.IsNullOrEmpty(Result) = False Then
                InitialDirectory = IO.Path.GetDirectoryName(Result)
                If IO.Directory.Exists(InitialDirectory) = False Then InitialDirectory = ""
            End If
            ' Return Dialogs.LocateFilePath_Open(Title, Filter, Result, InitialDirectory)
        End Function
        Public Function LocateRecordPath_Open(InitialFolder As String, ByRef Result As String) As Boolean
            ' Dim Filter As String = Dialogs.GenerateFilter("XRS Record", "Records")
            ' Return Dialogs.LocateFilePath_Open("Open Record Container", Filter, Result, InitialFolder)
        End Function
#End Region

#Region "Dialogs"
        Public Function OpenDialog_SelectColor(DefaultColor As Color, Optional UseAlpha As Boolean = False) 'As Wrapped_Color
            ' Dim SelectedForm = New DS_DialogBox_ColorSelector
            ' UIController.ModifyWindow_CustomConfiguration(SelectedForm)
            ' SelectedForm.PrepareUsage(DefaultColor, UseAlpha)
            ' UIController.OpenWindow(SelectedForm)
            ' Return SelectedForm.SelectedColor
        End Function
        Public Function OpenDialog_SelectColor(SourceImage As Image, DefaultColor As Color, Optional UseAlpha As Boolean = False) ' As Wrapped_Color
            ' Dim SelectedForm = New DS_DialogBox_ColorSelector
            ' UIController.ModifyWindow_CustomConfiguration(SelectedForm)
            ' SelectedForm.PrepareUsage(SourceImage, DefaultColor, UseAlpha)
            ' UIController.OpenWindow(SelectedForm)
            ' Return SelectedForm.SelectedColor
        End Function
#End Region

#Region "Common Dialog Choices"
        Public Function ShowQuestion_YesNo(Description As String) As MsgBoxResult
            Return MsgBox(Description, MsgBoxStyle.YesNo, pDialog_ProgramName)
        End Function
        Public Function ShowQuestion_YesNoCancel(Description As String) As MsgBoxResult
            Return MsgBox(Description, MsgBoxStyle.YesNoCancel, pDialog_ProgramName)
        End Function
        Public Sub ShowMessage(Description As String)
            MsgBox(Description, MsgBoxStyle.OkOnly, pDialog_ProgramName)
        End Sub
        Public Sub ShowError(Description As String)
            MsgBox(Description, MsgBoxStyle.Critical, pDialog_ProgramName)
        End Sub
        Public Function ShowQuestion(Description As String) As Boolean
            Select Case MsgBox(Description, MsgBoxStyle.OkCancel, pDialog_ProgramName)
                Case MsgBoxResult.Ok
                    Return True
                Case Else
                    Return False
            End Select
        End Function
#End Region
    End Class
End Namespace
