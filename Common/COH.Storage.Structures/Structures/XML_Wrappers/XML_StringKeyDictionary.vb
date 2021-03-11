Imports System.Xml.Serialization
Namespace Storage.Structures.Wrappers
    <XmlRoot("COH_StringKeyDictionary")> Public Class COH_StringKeyDictionary(Of TValue)
        Inherits Dictionary(Of String, TValue)
        Implements IXmlSerializable

#Region "Properties"
        Public ReadOnly Property Entry(Index As Integer) As KeyValuePair(Of String, TValue)
            Get
                Dim TheKey As String = Keys(Index)
                Return New KeyValuePair(Of String, TValue)(TheKey, Item(TheKey))
            End Get
        End Property
        Private mValue_Serializer As XmlSerializer = New XmlSerializer(GetType(TValue))
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New()
            mValue_Serializer = New XmlSerializer(GetType(TValue))
        End Sub
        Public Function AddEntry(Key As String, ByRef Value As TValue) As Boolean
            Return Me.TryAdd(Key, Value)
        End Function
#End Region

#Region "Serialize"
        Public Sub WriteXml(ByVal CurrentWriter As System.Xml.XmlWriter) Implements IXmlSerializable.WriteXml
            Dim emptyNamespaces = New XmlSerializerNamespaces({System.Xml.XmlQualifiedName.Empty})
            CurrentWriter.WriteAttributeString("Count", Me.Keys.Count)
            For Each Key As String In Me.Keys
                CurrentWriter.WriteStartElement("Entry")
                CurrentWriter.WriteAttributeString("Key", Key)
                Dim value As TValue = Me(Key)
                Try
                    mValue_Serializer.Serialize(CurrentWriter, value, emptyNamespaces)
                Catch ex As Exception
                    CurrentWriter.Flush()
                End Try
                CurrentWriter.WriteEndElement()
            Next Key
        End Sub
        Public Sub ReadXml(ByVal CurrentReader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
            Dim IsEmpty As Boolean = CurrentReader.IsEmptyElement
            CurrentReader.Read()
            If (IsEmpty) Then Return
            While (CurrentReader.NodeType <> System.Xml.XmlNodeType.EndElement)
                Dim key As String = CurrentReader.GetAttribute("Key")
                CurrentReader.Read()
                Dim value As TValue = CType(mValue_Serializer.Deserialize(CurrentReader), TValue)
                CurrentReader.ReadEndElement()
                Add(key, value)
                CurrentReader.MoveToContent()
            End While
            CurrentReader.ReadEndElement()
        End Sub
#End Region

#Region "Schema"
        Public Function GetSchema() As System.Xml.Schema.XmlSchema Implements IXmlSerializable.GetSchema
            Return Nothing
        End Function
#End Region
    End Class
End Namespace