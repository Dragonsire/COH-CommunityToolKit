Imports System.Drawing
Imports COH.CodeManagement.Enums.Structures

Namespace Toolkit.ControllerModules
    Partial Public NotInheritable Class ControllerModule_WindowManager

#Region "Locate Files"
        Private pLastLocated As String
        Public Function LocateFile_CopyTo(DesiredType As COH_Supported_ContentType, ByRef FileName As String, Destination As String) As Boolean
            If LocateFile(DesiredType, FileName) = True Then
                IO.File.Copy(FileName, Destination)
                pLastLocated = IO.Path.GetDirectoryName(FileName)
                Return True
            Else
                Return False
            End If
        End Function
        Public Function LocateFile(DesiredType As COH_Supported_ContentType, ByRef FileName As String) As Boolean
            Select Case DesiredType
                Case COH_Supported_ContentType.ResourceContainer_PIGG
                    Return LocateFileType_PIGG(FileName)
                Case COH_Supported_ContentType.Resource_BIN_CrypticS
                    Return LocateFileType_BIN(FileName)
                Case COH_Supported_ContentType.Resource_GEO
                    Return LocateFileType_GEO(FileName)
                Case COH_Supported_ContentType.Resource_Texture
                    Return LocateFileType_Texture(FileName)
                Case COH_Supported_ContentType.Resource_BIN_MessageStore
                    '//Return LocateFileType_(FileName)
                Case COH_Supported_ContentType.Resource_TGA
                    '//Return LocateFileType_(FileName)
                Case COH_Supported_ContentType.Resource_ANIMATION
                    '//Return LocateFileType_(FileName)
                Case Else
                    Return False
            End Select
        End Function
        Public Function LocateFileType_PIGG(ByRef FileName As String) As Boolean
            Dim Dialog = New OpenFileDialog()
            With Dialog
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "pigg"
                .FileName = FileName
                .Filter = "PIGG (*.pigg)|*.pigg"
                .FilterIndex = 0
                If String.IsNullOrEmpty(pLastLocated) = False Then
                    .InitialDirectory = IO.Path.GetDirectoryName(pLastLocated)
                Else
                    .InitialDirectory = ""
                End If
                .Title = "Select File to Continue"
            End With
            Return LocateFileType(Dialog, FileName)
        End Function
        Public Function LocateFileType_BIN(ByRef FileName As String) As Boolean
            Dim Dialog = New OpenFileDialog()
            With Dialog
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "bin"
                .FileName = FileName
                .Filter = "BIN (*.bin)|*.bin"
                .FilterIndex = 0
                If String.IsNullOrEmpty(pLastLocated) = False Then
                    .InitialDirectory = IO.Path.GetDirectoryName(pLastLocated)
                Else
                    .InitialDirectory = ""
                End If
                .Title = "Select File to Continue"
            End With
            Return LocateFileType(Dialog, FileName)
        End Function
        Public Function LocateFileType_GEO(ByRef FileName As String) As Boolean
            Dim Dialog = New OpenFileDialog()
            With Dialog
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "geo"
                .FileName = FileName
                .Filter = "GEO (*.geo)|*.geo"
                .FilterIndex = 0
                If String.IsNullOrEmpty(pLastLocated) = False Then
                    .InitialDirectory = IO.Path.GetDirectoryName(pLastLocated)
                Else
                    .InitialDirectory = ""
                End If
                .Title = "Select File to Continue"
            End With
            Return LocateFileType(Dialog, FileName)
        End Function
        Public Function LocateFileType_Texture(ByRef FileName As String) As Boolean
            Dim Dialog = New OpenFileDialog()
            With Dialog
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "Textue"
                .FileName = FileName
                .Filter = "Texture (*.Texture)|*.texture"
                .FilterIndex = 0
                If String.IsNullOrEmpty(pLastLocated) = False Then
                    .InitialDirectory = IO.Path.GetDirectoryName(pLastLocated)
                Else
                    .InitialDirectory = ""
                End If
                .Title = "Select File to Continue"
            End With
            Return LocateFileType(Dialog, FileName)
        End Function
        Public Function LocateFileType(ByRef Dialog As OpenFileDialog, Found As String) As Boolean
            Do
                Select Case Dialog.ShowDialog()
                    Case DialogResult.OK
                        If IO.File.Exists(Dialog.FileName) Then
                            If IO.File.Exists(Dialog.FileName) = True Then
                                Found = Dialog.FileName
                                Return True
                                Exit Do
                            End If
                        End If
                    Case Else
                        Return False
                End Select
            Loop
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
