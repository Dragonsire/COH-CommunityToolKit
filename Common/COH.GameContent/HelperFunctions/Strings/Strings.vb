Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Security
Imports COH.CodeManagement.Enums.DataTypes

Namespace HelperFunctions.StringsAndThings
    <HideModuleName> Public Module HelperFunctions_Strings
        Public Const VisibleCharacters_UTF As String = "`~!@#$%^&*()-_+=|\1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ[]{};:',.<>/?abcdefghijklmnopqrstuvwxyzÇüéâäàåçêëèïîìÄÅÉæôöòûùÿÖÜ¢£¥₧ƒáíóúñÑ½¼" & ChrW(34)
        Public Const VisibleCharacters_Ascii As String = "`~!@#$%^&*()-_+=|\1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ[]{};:',.<>/?abcdefghijklmnopqrstuvwxyz" & ChrW(34)

#Region "Checking"
        Public Function SafeCompareStrings(ByVal string1 As String, ByVal string2 As String, ByVal ignoreCase As Boolean) As Boolean
            If (string1 Is Nothing) OrElse (string2 Is Nothing) Then Return False
            If string1.Length <> string2.Length Then Return False
            Return String.Compare(string1, string2, ignoreCase, CultureInfo.InvariantCulture) = 0
        End Function
#End Region

#Region "Random Characters"
        Public Function Generate_RandomString(Count As Integer, ByRef ValidCharacterString As String) As String
            Return String.Concat(Generate_RandomChars(Count, ValidCharacterString))
        End Function
        Public Function Generate_RandomChars(Count As Integer, ByRef ValidCharacterString As String) As Char()
            Dim Result As Char() = New Char(Count - 1) {}
            For X = 1 To Count
                Result(X - 1) = Generate_RandomChar(ValidCharacterString)
            Next
            Return Result
        End Function
        Public Function Generate_RandomChar(ByRef ValidCharacterString As String) As Char
            If ValidCharacterString Is Nothing Then ValidCharacterString = VisibleCharacters_UTF
            Dim Generator As System.Random = New System.Random(Guid.NewGuid().GetHashCode())
            Dim Result As Char = ValidCharacterString.Chars(Generator.Next(0, ValidCharacterString.Length)) '-1 removed
            Return Result
        End Function
#End Region

#Region "File Read/Write"
        Public Function WriteStringList_ToFile(FilePath As String, ByRef Values As List(Of String)) As Boolean
            If IO.File.Exists(FilePath) = False Then Return False
            IO.File.WriteAllLines(FilePath, Values.ToArray)
            Return True
        End Function
        Public Function WriteStringList_ToFile(ByVal FilePath As String, ByRef Values As String()) As Boolean
            If IO.File.Exists(FilePath) = False Then Return False
            IO.File.WriteAllLines(FilePath, Values)
            Return True
        End Function
        Public Function ReadFile_ToString(FilePath As String) As String
            Dim Result As String = ""
            Try
                Using sr As New IO.StreamReader(New IO.FileStream(FilePath, IO.FileMode.Open, IO.FileAccess.Read))
                    Result = sr.ReadToEnd()
                End Using
            Catch e As Exception
            End Try
            Return Result
        End Function
        Public Function ReadFile_ToStringList(FilePath As String) As List(Of String)
            If IO.File.Exists(FilePath) = False Then Return Nothing
            Return IO.File.ReadLines(FilePath).ToList()
        End Function
#End Region

#Region "Permitted Characters"
        Public Sub Retrieve_PermittedCharacters(Style As TextPermittedStyle, ByRef MaxLength As Decimal, ByRef AllowCharacters As String, ByRef Casing As TextCharacterCasing)
            Casing = TextCharacterCasing.Normal
            Select Case Style
                Case TextPermittedStyle.Hex_8
                    MaxLength = 8
                    AllowCharacters = "abcdefABCDEF0123456789"
                    Casing = TextCharacterCasing.Upper
                Case TextPermittedStyle.Hex_16
                    MaxLength = 16
                    AllowCharacters = "abcdefABCDEF0123456789"
                    Casing = TextCharacterCasing.Upper
                Case TextPermittedStyle.ProperName
                    MaxLength = 256
                    AllowCharacters = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ-"
                Case TextPermittedStyle.AllVisibleCharacters
                    MaxLength = 32767
                    AllowCharacters = "`~!@#$%^&*()-_+=|\1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ[]{};:',.<>/?abcdefghijklmnopqrstuvwxyzÇüéâäàåçêëèïîìÄÅÉæôöòûùÿÖÜ¢£¥₧ƒáíóúñÑ½¼" & Chr(34)
                Case TextPermittedStyle.Numbers
                    MaxLength = 32767
                    AllowCharacters = "0123456789"
                Case TextPermittedStyle.PostalCode
                    MaxLength = 7
                    AllowCharacters = "0123456789abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                    Casing = TextCharacterCasing.Upper
                Case TextPermittedStyle.ZipCode
                    MaxLength = 10
                    AllowCharacters = "0123456789-"
                Case TextPermittedStyle.SIN
                    MaxLength = 12
                    AllowCharacters = "0123456789-"
                Case TextPermittedStyle.FinancialNumbers
                    MaxLength = 12
                    AllowCharacters = "0123456789.-"
            End Select
        End Sub
#End Region

#Region "Security"
        Public Function Convert_SecureString_ToString(ByVal value As SecureString) As String
            Dim bstr As IntPtr = Marshal.SecureStringToBSTR(value)
            Try
                Return Marshal.PtrToStringBSTR(bstr)
            Finally
                Marshal.FreeBSTR(bstr)
            End Try
        End Function
#End Region

#Region "Joining Functions"
        Public Function Join_StringList_ToArrayList(Message As String) As String
            Dim Combined As String = Chr(34) & Message.Replace(Environment.NewLine, Chr(34) & "," & Chr(34))
            If String.IsNullOrEmpty(Combined) = True Then Return ""
            Return Combined
        End Function
#End Region

#Region "Other"
        Public Function QuoteString(Source As String) As String
            Return (Chr(34) & Source & Chr(34))
        End Function
        Public Function SingleQuoteString(Source As String) As String
            Return ("'" & Source & "'")
        End Function
#End Region
    End Module
End Namespace