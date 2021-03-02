Imports System.Runtime.CompilerServices

Namespace CodeManagement.Extentions
    <HideModuleName> Public Module Extention_Strings
        <Extension> Public Function QuoteTheString(ByRef Source As String) As String
            Return HelperFunctions.StringsAndThings.QuoteString(Source)
        End Function
        <Extension> Public Function SingleQuoteTheString(ByRef Source As String) As String
            Return HelperFunctions.StringsAndThings.SingleQuoteString(Source)
        End Function
        <Extension> Public Function BracketTheString(ByRef Source As String) As String
            Return HelperFunctions.StringsAndThings.BracketString(Source)
        End Function
    End Module
End Namespace