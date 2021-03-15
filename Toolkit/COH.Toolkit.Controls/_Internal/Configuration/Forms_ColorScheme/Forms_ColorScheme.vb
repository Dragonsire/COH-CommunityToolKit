Imports System.ComponentModel
Imports COH.HelperClasses.Wrappers

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class FormsConfiguration_ColorScheme

#Region "Properties"
        Public Property Form_Background As COH_XML_Color
        Public Property Form_TabPages_Background As COH_XML_Color
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            If ResetDefaults = True Then ResetToDefault()
        End Sub
        Public Sub ResetToDefault()
            Form_Background = Color.YellowGreen
            Form_TabPages_Background = Color.CornflowerBlue
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As Object
            Dim Result As New FormsConfiguration_ColorScheme
            CloneTo(Result)
            Return Result
        End Function
        Public Overloads Function CreateClone() As FormsConfiguration_ColorScheme
            Dim Destination As New FormsConfiguration_ColorScheme
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As FormsConfiguration_ColorScheme)
            With Destination
                .Form_Background = Form_Background.CreateClone
                .Form_TabPages_Background = Form_TabPages_Background.CreateClone
            End With
        End Sub
#End Region
    End Class
End Namespace

