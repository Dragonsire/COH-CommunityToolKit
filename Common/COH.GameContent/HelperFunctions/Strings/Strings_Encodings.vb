Imports System.Text
Imports COH.CodeManagement.Enums.DataTypes

Namespace HelperFunctions.StringsAndThings
    <HideModuleName> Public Module DS_HelperFunctions_StringFunctions
        Public Const StringEncoding_FallBack As Supported_StringEncoding = Supported_StringEncoding.UTF8

#Region "Encodings"
        Public Function Lookup_StringEncoding(StringEncoding As Supported_StringEncoding) As Text.Encoding
            If StringEncoding = Supported_StringEncoding.Default Then StringEncoding = StringEncoding_FallBack
            Select Case StringEncoding
                Case Supported_StringEncoding.ASCII
                    Return Text.Encoding.ASCII
                Case Supported_StringEncoding.UTF7
                    Return Text.Encoding.UTF7
                Case Supported_StringEncoding.UTF8
                    Return Text.Encoding.UTF8
                Case Supported_StringEncoding.UTF16
                    Return Text.Encoding.Unicode
                Case Supported_StringEncoding.UTF16_BigEndian
                    Return Text.Encoding.BigEndianUnicode
                Case Supported_StringEncoding.UTF32
                    Return Text.Encoding.UTF32
                Case Supported_StringEncoding.CP1252
                    Return EnsureCodePageExists(1252)
                Case Else
                    Return Text.Encoding.Unicode
            End Select
        End Function
        Private Function EnsureCodePageExists(CodePage As Integer) As Encoding
            Try
                Dim Result = Encoding.GetEncoding(CodePage)
                Return Result
            Catch ex As Exception
            End Try
            Dim EncodingProvider = CodePagesEncodingProvider.Instance
            Encoding.RegisterProvider(EncodingProvider)
            Try
                Dim Result = Encoding.GetEncoding(CodePage)
                Return Result
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            Return Text.Encoding.UTF8
        End Function
        Public Function ConvertTo_String(ByRef TheBytes As Byte(), UsedEncoding As Supported_StringEncoding) As String
            Return ConvertTo_String(TheBytes, 0, TheBytes.Length, UsedEncoding)
        End Function
        Public Function ConvertTo_String(ByRef TheBytes As Byte(), Offset As Integer, Count As Integer, UsedEncoding As Supported_StringEncoding) As String
            Select Case UsedEncoding
                Case Supported_StringEncoding.ASCII
                    Return New String(Text.Encoding.ASCII.GetChars(TheBytes, Offset, Count))
                Case Supported_StringEncoding.UTF16
                    Return New String(Text.Encoding.Unicode.GetChars(TheBytes, Offset, Count))
                Case Supported_StringEncoding.UTF32
                    Return New String(Text.Encoding.UTF32.GetChars(TheBytes, Offset, Count))
                Case Supported_StringEncoding.UTF7
                    Return New String(Text.Encoding.UTF7.GetChars(TheBytes, Offset, Count))
                Case Supported_StringEncoding.UTF8
                    Return New String(Text.Encoding.UTF8.GetChars(TheBytes, Offset, Count))
                    'Case DS_Supported_StringEncoding.UTF16_Fixed2Bytes
                    'Return New String(Text.Encoding.ASCII.GetChars(TheBytes, Offset, Count))
            End Select
            Return Nothing
        End Function
        Public Function ConvertTo_Bytes(ByRef value As String, UsedEncoding As Supported_StringEncoding) As Byte()
            Dim Encoder As Text.Encoding = Lookup_StringEncoding(UsedEncoding)
            Dim Result As Byte() = Encoder.GetBytes(value)
            Return Result
        End Function
#End Region

#Region "BOM"
        Public Function BOM_Create(StringEncoding As Supported_StringEncoding) As Byte()
            Dim Encoder As Text.Encoding = Lookup_StringEncoding(StringEncoding)
            Return Encoder.GetPreamble
        End Function
        Public Function Check_BOM_Length(StringEncoding As Supported_StringEncoding) As Integer
            Dim Encoder As Text.Encoding = Lookup_StringEncoding(StringEncoding)
            Dim BOM() As Byte = Encoder.GetPreamble
            If BOM Is Nothing Then Return 0
            Return BOM.Length
        End Function
        Public Function Check_UTF8_ByteOrder(Bytes() As Byte) As Supported_BinaryByteOrder
            Dim BOM() As Byte = Encoding.UTF8.GetPreamble()
            If (Bytes(0) = BOM(0)) And (Bytes(1) = BOM(1)) And (Bytes(2) = BOM(2)) Then
                Return Supported_BinaryByteOrder.LittleEndian
            Else
                Return Supported_BinaryByteOrder.BigEndian
            End If
        End Function
        Public Function Check_UTF16_ByteOrder(Bytes() As Byte) As Supported_BinaryByteOrder
            Dim BOM() As Byte = Encoding.Unicode.GetPreamble()
            If (Bytes(0) = BOM(0)) And (Bytes(1) = BOM(1)) Then
                Return Supported_BinaryByteOrder.LittleEndian
            Else
                Return Supported_BinaryByteOrder.BigEndian
            End If
        End Function
        Public Function Check_UTF32_ByteOrder(data() As Byte) As Supported_BinaryByteOrder
            Dim bom() As Byte = Encoding.UTF32.GetPreamble()
            If (data(0) = bom(0)) And (data(1) = bom(1)) And (data(2) = bom(2)) And (data(3) = bom(3)) Then
                Return Supported_BinaryByteOrder.LittleEndian
            Else
                Return Supported_BinaryByteOrder.BigEndian
            End If
        End Function
#End Region

    End Module
End Namespace