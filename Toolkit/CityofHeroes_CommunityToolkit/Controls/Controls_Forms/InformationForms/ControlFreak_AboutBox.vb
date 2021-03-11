Imports System.Drawing

Namespace  Controls
    <ToolboxItem(True)> <ToolboxBitmap(GetType(FileDialog))> Public Class ControlFreak_AboutBox

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
            'Update_CurrentState(CurrentState_Enum.ModifyingUI)
            'Update_CurrentState(CurrentState_Enum.Ready)
        End Sub
        Protected Sub Handle_InitializeComponents()
            InitializeComponent()
        End Sub
        Protected Sub Handle_InitializeDefaults()
        End Sub
        Protected Sub Handle_OnShown(sender As Object, e As EventArgs) Handles Me.Shown
        End Sub
#End Region

#Region "Private Usage"
        Private pChangeLogPath As String
        Private pVersion As String
        Private pProgramName As String
        Private pProgramIcon As Image
#End Region

#Region "PrepareUsage"
        Public Sub PrepareUsage(ProgramName As String, Icon As Image, Version As String, ChangeLogPath As String)
            pProgramName = ProgramName
            pProgramIcon = Icon
            pVersion = Version
            pChangeLogPath = ChangeLogPath
            DisplayDetails()
        End Sub
        Private Sub DisplayDetails()
            Label_ChangeLog.Text = "CHANGE LOG - " & pVersion
            ImageBox_ProgramIcon.BackgroundImage = pProgramIcon
            Label_ProgramName.Text = pProgramName
            Label_Version.Text = pVersion
            If IO.File.Exists(pChangeLogPath) = True Then
                Try
                    RichTextBox1.LoadFile(pChangeLogPath)
                Catch ex As Exception

                End Try
            End If
            RichTextBox1.ReadOnly = True
        End Sub
#End Region

    End Class
End Namespace