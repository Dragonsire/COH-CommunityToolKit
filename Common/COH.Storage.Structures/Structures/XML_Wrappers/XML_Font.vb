Imports System.ComponentModel
Imports System.Drawing
Imports System.Xml.Serialization
Imports COH.Storage.Structures

Namespace HelperClasses.Wrappers
    <TypeConverter(GetType(ExpandableObjectConverter))> Public NotInheritable Class COH_XML_Font
        Inherits COH_ObservableObject

#Region "Properties"
        <DefaultValue("Microsoft Sans Serif")> Public Property FontName As String
            Get
                Return pFontName
            End Get
            Set(Value As String)
                UpdatePrivateProperty(pFontName, Value)
            End Set
        End Property
        <DefaultValue(8.25)> Public Property FontSize As Single
            Get
                Return pFontSize
            End Get
            Set(Value As Single)
                UpdatePrivateProperty(pFontSize, Value)
            End Set
        End Property
        <DefaultValue(GraphicsUnit.Point)> Public Property FontScale As GraphicsUnit
            Get
                Return pFontScale
            End Get
            Set(Value As GraphicsUnit)
                UpdatePrivateProperty(pFontScale, Value)
            End Set
        End Property
        <DefaultValue(FontStyle.Regular)> Public Property FontStyle As FontStyle
            Get
                Return pFontStyle
            End Get
            Set(Value As FontStyle)
                UpdatePrivateProperty(pFontStyle, Value)
            End Set
        End Property
        <DefaultValue(GetType(Color), "Black")> Public Property FontColor As COH_XML_Color
            Get
                Return pFontColor
            End Get
            Set(Value As COH_XML_Color)
                UpdatePrivateProperty(pFontColor, Value)
            End Set
        End Property
        <Xml.Serialization.XmlIgnoreAttribute> Public Property CurrentFont As Font
            Get
                Return Return_Font()
            End Get
            Set(Value As Font)
                UpdateFont(Value, pFontColor)
                OnModified("CurrentFont")
            End Set
        End Property
#End Region

#Region "Private Properties"
        Private pFontName As String
        Private pFontSize As Single
        Private pFontScale As GraphicsUnit
        Private pFontStyle As FontStyle
        Private WithEvents pFontColor As COH_XML_Color
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New(ResetDefaults)
        End Sub
        Sub New(FontFamilyName As String, FontSize As Single, FontColor As Color, Optional FontStyle As FontStyle = FontStyle.Regular, Optional FontScale As GraphicsUnit = GraphicsUnit.Display)
            MyBase.New
            pFontName = FontFamilyName
            pFontSize = FontSize
            pFontColor = FontColor
            pFontStyle = FontStyle
            pFontScale = FontScale
        End Sub
#End Region

#Region "Initialize"
        Public Overrides Sub ResetToDefault()
            pFontName = "Microsoft Sans Serif"
            pFontSize = 8.25
            pFontScale = GraphicsUnit.Point
            pFontStyle = FontStyle.Regular
            pFontColor = Color.Black
            MyBase.ResetToDefault()
        End Sub
        Public Overrides Function ToString() As String
            Dim TempFont As Font = Return_Font()
            If TempFont Is Nothing Then Return "Invalid Font"
            Return TempFont.ToString
        End Function
        Public Shared Widening Operator CType(ByVal value As Font) As COH_XML_Font
            Dim Result As New COH_XML_Font
            Result.UpdateFont(value, Color.Black)
            Return Result
        End Operator
        Public Shared Widening Operator CType(ByVal value As COH_XML_Font) As Font
            Dim Result As New Font(value.FontName, value.FontSize, value.FontStyle, value.FontScale)
            Return Result
        End Operator
#End Region

#Region "Events"
        Private Sub ColorChanged() Handles pFontColor.ColorWasModified
            OnModified()
        End Sub
#End Region

#Region "Update Functions"
        Sub UpdateFont(ByVal value As Font, FontColor As Color)
            pFontColor = New COH_XML_Color(FontColor)
            pFontScale = value.Unit
            pFontName = value.Name
            pFontSize = value.Size
            pFontStyle = value.Style
            OnModified()
        End Sub
        Sub UpdateFont(FontFamilyName As String, FontSize As Single, FontColor As Color, Optional FontStyle As FontStyle = Drawing.FontStyle.Regular, Optional FontScale As GraphicsUnit = GraphicsUnit.Display)
            pFontName = FontFamilyName
            pFontSize = FontSize
            pFontColor = FontColor
            pFontStyle = FontStyle
            pFontScale = FontScale
            OnModified()
        End Sub
        Public Function Return_Font() As Font
            Dim Valid As Boolean = True
            Dim Result As Font = Nothing
            Try
                Result = New Font(pFontName, pFontSize, pFontStyle, pFontScale)
            Catch ex As Exception
                Valid = False
            End Try
            If Valid = True Then Return Result
            Try
                Result = New Font(pFontName, pFontSize, pFontStyle)
            Catch ex As Exception
                Result = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular)
            End Try
            Return Result
        End Function
        Public Function Return_Font_SolidBrush() As Brush
            Return New SolidBrush(pFontColor)
        End Function
#End Region

#Region "Clone"
        Public Overloads Function CreateClone() As COH_XML_Font
            Dim Destination As New COH_XML_Font
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As COH_XML_Font)
            With Destination
                .pFontName = New String(pFontName)
                .pFontSize = pFontSize
                .pFontScale = pFontScale
                .pFontStyle = pFontStyle
                .pFontColor = pFontColor.CreateClone
            End With
        End Sub
#End Region
    End Class
End Namespace