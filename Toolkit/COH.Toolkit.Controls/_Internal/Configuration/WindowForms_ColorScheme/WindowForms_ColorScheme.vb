Imports System.ComponentModel
Imports System.IO

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class WindowFormsConfiguration_ColorScheme

#Region "Properties"
        Public Property Form_Background As Wrapped_Color
        Public Property Form_TabPages_Background As Wrapped_Color
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
        Public Sub ResetToDefault()
            Form_Background = Color.YellowGreen
            Form_TabPages_Background = Color.CornflowerBlue
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As Object Implements ICloneable.Clone
            Dim Result As New WindowFormsConfiguration_ColorScheme
            CloneTo(Result)
            Return Result
        End Function
        Public Overloads Function CreateClone() As WindowFormsConfiguration_ColorScheme
            Dim Destination As New WindowFormsConfiguration_ColorScheme
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As WindowFormsConfiguration_ColorScheme)
            With Destination
                .Form_Background = Form_Background.Clone
                .Form_TabPages_Background = Form_TabPages_Background.Clone
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
            Dim Version As DS_CFS_IDent = DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_ColorScheme))
            Version.WriteToStream(CurrentWriter)
            Form_Background.Write_ToStream(CurrentWriter)
            Form_TabPages_Background.Write_ToStream(CurrentWriter)
            Return True
        End Function
#End Region

#Region "Import"
        Public Function Read_FromStream(ByRef CurrentReader As FlexStreamEditor) As Boolean Implements IDS_Structure.Read_FromStream
            Dim Version As New DS_CFS_IDent(CurrentReader)
            If DS_CFS_IDent.Validate(Version, DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_ColorScheme))) = False Then Return False
            'ADD VERSION LOGIC
            Form_Background = New Wrapped_Color(CurrentReader)
            Form_TabPages_Background = New Wrapped_Color(CurrentReader)
            Return True
        End Function
#End Region
    End Class
End Namespace

