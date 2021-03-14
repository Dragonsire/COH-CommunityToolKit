Imports System.ComponentModel
Imports System.IO

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class WindowFormsConfiguration_Settings

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
        Public Property Window_Font As Wrapped_Font
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            If ResetDefaults = True Then ResetToDefault()
        End Sub
        Public Sub New(ByRef CurrentReader As FlexStreamEditor)
            Read_FromStream(CurrentReader)
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
        Public Function Clone() As Object Implements ICloneable.Clone
            Dim Result As New WindowFormsConfiguration_Settings
            CloneTo(Result)
            Return Result
        End Function
        Public Overloads Function CreateClone() As WindowFormsConfiguration_Settings
            Dim Destination As New WindowFormsConfiguration_Settings
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As WindowFormsConfiguration_Settings)
            With Destination
                .Form_StartPosition_TopMost = Form_StartPosition_TopMost
                .Form_StartPosition = Form_StartPosition
                .Form_Text = Form_Text.CloneString
                .Form_BorderStyle = Form_BorderStyle
                .Form_Icon = Form_Icon
                .ShowButton_Min = ShowButton_Min
                .ShowButton_Max = ShowButton_Max
                .ShowButton_Help = ShowButton_Help
                .Form_Size_Minimal = New Size(Form_Size_Minimal.Width, Form_Size_Minimal.Height)
                .Form_Size_Maximum = New Size(Form_Size_Maximum.Width, Form_Size_Maximum.Height)
                .Form_Size = New Size(Form_Size.Width, Form_Size.Height)
                .Window_Font = Window_Font.Clone
                .Form_State = Form_State
            End With
        End Sub
#End Region

#Region "Export"
        Function Export_ToStream_File(FilePath As String) As Boolean Implements IDS_ConvertTo_Binary.Export_ToStream_File
            Dim File As New IO.FileStream(FilePath, IO.FileMode.Create, IO.FileAccess.Write)
            Dim CurrentWriter As New FlexStreamEditor(File)
            Return Write_ToStream(CurrentWriter)
        End Function
        Public Function Export_ToStream() As MemoryStream Implements IDS_Structure.Export_ToStream
            Throw New NotImplementedException()
        End Function
        Public Function Write_ToStream(ByRef CurrentWriter As FlexStreamEditor) As Boolean Implements IDS_Structure.Write_ToStream
            Dim Version As DS_CFS_IDent = DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_Settings))
            Version.WriteToStream(CurrentWriter)
            CurrentWriter.Write(Form_StartPosition_TopMost)
            CurrentWriter.Write(Form_StartPosition)
            CurrentWriter.Write(Form_Text)
            CurrentWriter.Write(Form_BorderStyle)
            CurrentWriter.Write(Form_Icon)
            CurrentWriter.Write(ShowButton_Min)
            CurrentWriter.Write(ShowButton_Max)
            CurrentWriter.Write(ShowButton_Help)
            CurrentWriter.Write(Form_Size_Minimal)
            CurrentWriter.Write(Form_Size_Maximum)
            CurrentWriter.Write(Form_Size)
            CurrentWriter.Write(Form_State)
            Window_Font.Write_ToStream(CurrentWriter)
            Return True
        End Function
#End Region

#Region "Import"
        Public Function Read_FromStream(ByRef CurrentReader As FlexStreamEditor) As Boolean Implements IDS_Structure.Read_FromStream
            Dim Version As New DS_CFS_IDent(CurrentReader)
            If DS_CFS_IDent.Validate(Version, DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_Settings))) = False Then Return False
            'ADD VERSION LOGIC
            Form_StartPosition_TopMost = CurrentReader.ReadBoolean()
            Form_StartPosition = CurrentReader.ReadInt32()
            Form_Text = CurrentReader.ReadString()
            Form_BorderStyle = CurrentReader.ReadInt32()
            Form_Icon = CurrentReader.ReadIcon
            ShowButton_Min = CurrentReader.ReadBoolean()
            ShowButton_Max = CurrentReader.ReadBoolean()
            ShowButton_Help = CurrentReader.ReadBoolean()
            Form_Size_Minimal = CurrentReader.ReadSize()
            Form_Size_Maximum = CurrentReader.ReadSize()
            Form_Size = CurrentReader.ReadSize()
            Form_State = CurrentReader.ReadInt32
            Window_Font = New Wrapped_Font(CurrentReader)
            Return True
        End Function
#End Region
    End Class
End Namespace
