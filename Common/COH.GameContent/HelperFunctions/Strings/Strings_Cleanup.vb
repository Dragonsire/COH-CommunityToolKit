Imports System.Globalization
Imports COH.CodeManagement.Enums.DataTypes

Namespace HelperFunctions.StringsAndThings.Cleanup
    <HideModuleName> Module DS_HelperFunctionsStrings_Cleanup

#Region "Checking"
        Public Function Check_IsCharacterPrintable(ByRef value As Char) As Boolean
            Dim Result As Boolean = Not Char.IsControl(value)
            If Result = True Then Result = Not Char.IsWhiteSpace(value)
            Return Result
        End Function
        Public Function Check_IsNullorEquivalent(value As String) As Boolean
            If (value Is Nothing) = True Then Return True
            If String.IsNullOrEmpty(value) = True Then Return True
            If String.IsNullOrWhiteSpace(value) = True Then Return True
            Return False
        End Function
#End Region

#Region "Cloning"
        Public Function CloneChar(value As Char) As Char
            If Check_IsNullorEquivalent(value) = True Then Return String.Empty
            Return New Text.StringBuilder(value).ToString
        End Function
        Public Function CloneString(value As String) As String
            If Check_IsNullorEquivalent(value) = True Then Return String.Empty
            Return New Text.StringBuilder(value).ToString
        End Function
#End Region

#Region "Cleaning / Fix"'":;.\/"
        Public Function Fix_IsNullorEquivalent(value As String) As String
            If Check_IsNullorEquivalent(value) = True Then Return String.Empty
            Return value
        End Function
        Public Function Fix_ReturnAtZero(value As String) As String
            If value.Contains(ChrW(0)) = False Then Return value
            Dim Pos1 As Integer = value.IndexOf(ChrW(0))
            If Pos1 = 0 Then Return ""
            Dim Cleaned = value.Substring(0, Pos1)
            Return Cleaned
        End Function
        Public Function Fix_RemoveDoubleSpaces(value As String) As String
            Do While value.Contains("  ")
                value = value.Replace("  ", " ")
            Loop
            Return value
        End Function
        Public Function Fix_RemoveOnlyUnwantedCharacters(value As String, NotAllowedCharacters As String) As String
            Dim Result As String = "", CurrentCharacter As Char = ""
            For X = 0 To value.Length - 1
                CurrentCharacter = value.Substring(X, 1)
                If NotAllowedCharacters.Contains(CurrentCharacter) = False Then Result += CurrentCharacter
            Next
            Return Result
        End Function
        Public Function Fix_RemoveUnwantedCharacters(value As String, AllowedCharacters As String) As String
            Dim Result As String = "", CurrentCharacter As Char = ""
            For X = 0 To value.Length - 1
                CurrentCharacter = value.Substring(X, 1)
                If AllowedCharacters.Contains(CurrentCharacter) = True Then Result += CurrentCharacter
            Next
            Return Result
        End Function
        Public Function Fix_RemoveSingleSpacing(value As String) As String
            Dim ExitNow As Boolean = False
            Do While ExitNow = False
                Dim PosN As Int16 = value.IndexOf(vbCrLf & vbCrLf)
                If PosN > -1 Then
                    value = value.Replace(vbCrLf & vbCrLf, vbCrLf)
                Else
                    ExitNow = True
                End If
            Loop
            Return value
        End Function
        Public Function Fix_RemoveDoubleSpacing(value As String) As String
            Dim ExitNow As Boolean = False
            Do While ExitNow = False
                Dim PosN As Int32 = value.IndexOf(vbCrLf & vbCrLf & vbCrLf)
                If PosN > -1 Then
                    value = value.Replace(vbCrLf & vbCrLf & vbCrLf, vbCrLf & vbCrLf)
                Else
                    ExitNow = True
                End If
            Loop
            Return value
        End Function
        Public Function Fix_RemoveUntilVisibleCharacter(value As String) As String
            Return Fix_RemoveUntilSpecifiedCharacter(value, VisibleCharacters_UTF)
        End Function
        Public Function Fix_RemoveUntilSpecifiedCharacter(value As String, SpecifiedCharacters As String) As String
            If SpecifiedCharacters Is Nothing OrElse SpecifiedCharacters = "" Then SpecifiedCharacters = VisibleCharacters_UTF
            For X = 0 To value.Length - 1
                Dim CharV As Char = value.Substring(X, 1)
                If SpecifiedCharacters.Contains(CharV) = True Then Return value.Substring(X)
            Next
            Return String.Empty
        End Function
        Public Function Fix_RemoveUntilVisibleCharacter_Reverse(value As String) As String
            Return Fix_RemoveUntilSpecifiedCharacter_Reverse(value, VisibleCharacters_UTF)
        End Function
        Public Function Fix_RemoveUntilSpecifiedCharacter_Reverse(value As String, SpecifiedCharacters As String) As String
            If SpecifiedCharacters Is Nothing OrElse SpecifiedCharacters = "" Then SpecifiedCharacters = VisibleCharacters_UTF
            For X = value.Length - 1 To 0 Step -1
                Dim CharV As Char = value.Substring(X, 1)
                If SpecifiedCharacters.Contains(CharV) = True Then Return value.Substring(0, X + 1)
            Next
            Return String.Empty
        End Function
        Public Function Fix_TrimToMaxLength(value As String, Optional MaxLength As UInteger = UInt32.MaxValue, Optional CleanStringSettings As Supported_CleanStringFlags = 331) As String
            If MaxLength = 0 Then Return ""
            If Not (CleanStringSettings = 0) Then value = CleanString(value, CleanStringSettings)
            If value.Length > MaxLength Then value = value.Substring(0, MaxLength)
            If (CleanStringSettings And Supported_CleanStringFlags.Trim) = True Then value = value.Trim
            Return value
        End Function
        Public Function Fix_TrimWhiteSpacesNull(value As String) As String
            Dim Start As Integer = 0, Finish As Integer = value.Length - 1
            While Start < value.Length
                If Not Char.IsWhiteSpace(value(Start)) AndAlso value(Start) <> ChrW(&H0) Then Exit While
                Start += 1
            End While
            While Finish >= Start
                If Not Char.IsWhiteSpace(value(Finish)) AndAlso value(Finish) <> ChrW(&H0) Then Exit While
                Finish -= 1
            End While
            Return value.Substring(Start, Finish - Start + 1)
        End Function
        Public Function CleanString(value As String, Optional Settings As Supported_CleanStringFlags = 331) As String
            If Check_IsNullorEquivalent(value) = True Then
                If (Settings And Supported_CleanStringFlags.AllowNull) = False Then
                    Return ""
                Else
                    Return value
                End If
            End If
            Dim ViewAbleCharactersSource As String = VisibleCharacters_UTF
            If Settings.HasFlag(Supported_CleanStringFlags.Remove_NewLines) = False Then ViewAbleCharactersSource = ViewAbleCharactersSource & vbLf & vbCr & vbCrLf & Environment.NewLine
            If Settings.HasFlag(Supported_CleanStringFlags.Remove_NewLines) = True Then
                value = value.Replace(ChrW(13) & ChrW(10), " ")
                value = value.Replace(Environment.NewLine, " ")
            End If
            If Settings.HasFlag(Supported_CleanStringFlags.ReturnOnZero) = True Then
                value = Fix_ReturnAtZero(value)
            End If
            value.Replace("&nbsp;", vbCrLf)    'changes to newline and return
            If Settings.HasFlag(Supported_CleanStringFlags.Remove_DoubleSpaces) = True Then
                value = Fix_RemoveDoubleSpaces(value)
            ElseIf Settings.HasFlag(Supported_CleanStringFlags.Remove_Spaces) = True Then
                value = value.Replace(" ", "")
            End If
            If Settings.HasFlag(Supported_CleanStringFlags.Remove_NonVisibleCharacters) = True Then
                value = Fix_RemoveUnwantedCharacters(value, ViewAbleCharactersSource)
            End If
            If Settings.HasFlag(Supported_CleanStringFlags.Remove_DoubleSpacedLines) = True Then
                value = Fix_RemoveDoubleSpacing(value)
            End If
            If Settings.HasFlag(Supported_CleanStringFlags.Remove_SingleSpacedLines) = True Then
                value = Fix_RemoveSingleSpacing(value)
            End If
            If Settings.HasFlag(Supported_CleanStringFlags.Trim) = True Then
                Return value.Trim
            Else
                Return value
            End If
        End Function
#End Region

#Region "Fix Pathing"
        Public Function Fix_RemoveInvalidFileNameCharacters(value As String, Optional IncludePeriod As Boolean = False) As String
            Dim NotAllowedCharacters As String = IO.Path.GetInvalidFileNameChars()
            If IncludePeriod = True Then NotAllowedCharacters += "."
            Return Fix_RemoveOnlyUnwantedCharacters(value, NotAllowedCharacters)
        End Function
        Public Function Fix_RemoveInvalidPathCharacters(value As String) As String
            Dim NotAllowedCharacters As String = IO.Path.GetInvalidPathChars()
            Return Fix_RemoveOnlyUnwantedCharacters(value, NotAllowedCharacters)
        End Function
#End Region

    End Module
End Namespace