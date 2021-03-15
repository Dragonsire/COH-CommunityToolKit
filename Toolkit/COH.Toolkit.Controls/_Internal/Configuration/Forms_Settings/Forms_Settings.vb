Imports System.ComponentModel
Imports COH.HelperClasses.Wrappers

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class FormsConfiguration_Settings

#Region "Properties"
        Public Property Form_StartPosition_TopMost As Boolean
        Public Property Form_StartPosition As FormStartPosition
        Public Property Form_State As FormWindowState
        Public Property Form_Text As String
        Public Property Form_BorderStyle As FormBorderStyle
        Public Property Form_Icon As Icon
        Public Property ShowButton_Min As Boolean
        Public Property ShowButton_Max As Boolean
        Public Property ShowButton_Help As Boolean
        Public Property Form_Size As Size
        Public Property Form_Size_Minimal As Size
        Public Property Form_Size_Maximum As Size
        Public Property Window_Font As COH_XML_Font
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            If ResetDefaults = True Then ResetToDefault()
        End Sub
#End Region

#Region "Initialize"
        Public Sub ResetToDefault()
            Form_State = FormWindowState.Normal
            Form_BorderStyle = FormBorderStyle.FixedSingle
            Form_Size = New Size(800, 600)
            Form_Size_Minimal = New Size(640, 480)
            Form_Size_Maximum = New Size(1920, 1080)
            Form_StartPosition = FormStartPosition.CenterScreen
            Form_StartPosition_TopMost = False
            Form_Text = "New Window"
            Form_Icon = Nothing
            Window_Font = New Font("Segoe UI Symbol", 10)
            ShowButton_Min = True
            ShowButton_Max = True
            ShowButton_Help = False
        End Sub
#End Region

#Region "Modify From"
        Public Sub UpdateSettings_FromControl(ByRef SourceControl As Control)
            If SourceControl.GetType.IsSubclassOf(GetType(Form)) = False Then
                UpdateSettings_FromControl_Common(SourceControl)
            Else
                UpdateSettings_FromControl_Form(CType(SourceControl, Form))
            End If
        End Sub
        Private Sub UpdateSettings_FromControl_Common(ByRef SourceControl As Control)
            With Me
                .Form_Size_Minimal = SourceControl.ClientSize
                .Form_Size = SourceControl.ClientSize
                .Form_Text = SourceControl.Name
                .Window_Font = SourceControl.Font
                .Window_Font.FontColor = SourceControl.ForeColor
            End With
        End Sub
        Private Sub UpdateSettings_FromControl_Form(ByRef SourceControl As Form)
            With Me
                .Form_Size_Minimal = SourceControl.MinimumSize
                .Form_Size = SourceControl.ClientSize
                .Form_Size_Maximum = SourceControl.MaximumSize
                .Form_Text = SourceControl.Text
                .Window_Font = SourceControl.Font
                .Window_Font.FontColor = SourceControl.ForeColor
                .Form_BorderStyle = SourceControl.FormBorderStyle
                .ShowButton_Help = SourceControl.HelpButton
                .ShowButton_Min = SourceControl.MinimizeBox
                .ShowButton_Max = SourceControl.MaximizeBox
                .Form_Icon = SourceControl.Icon
                .Form_State = SourceControl.WindowState
            End With
        End Sub
#End Region

#Region "Clone"
        Public Overloads Function CreateClone() As FormsConfiguration_Settings
            Dim Destination As New FormsConfiguration_Settings
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As FormsConfiguration_Settings)
            With Destination
                .Form_StartPosition_TopMost = Form_StartPosition_TopMost
                .Form_StartPosition = Form_StartPosition
                .Form_Text = New String(Form_Text)
                .Form_BorderStyle = Form_BorderStyle
                .Form_Icon = Form_Icon
                .ShowButton_Min = ShowButton_Min
                .ShowButton_Max = ShowButton_Max
                .ShowButton_Help = ShowButton_Help
                .Form_Size_Minimal = New Size(Form_Size_Minimal.Width, Form_Size_Minimal.Height)
                .Form_Size_Maximum = New Size(Form_Size_Maximum.Width, Form_Size_Maximum.Height)
                .Form_Size = New Size(Form_Size.Width, Form_Size.Height)
                .Window_Font = Window_Font.CreateClone
                .Form_State = Form_State
            End With
        End Sub
#End Region

    End Class
End Namespace
