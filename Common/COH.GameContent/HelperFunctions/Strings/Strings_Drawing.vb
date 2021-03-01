Namespace HelperFunctions.StringsAndThings
    <HideModuleName()> Public Module DS_StringsANDThings_Desktop

#Region "Drawing"
        Public Function Return_StringPadded_ToLength(ByRef e As Drawing.Graphics, ByVal FontUsed As Drawing.Font, ByVal Desired_StringLength As Single, value As String) As String
            Dim Result As String = value
            Dim ResultLength As Single
            Do Until ResultLength >= Desired_StringLength
                ResultLength = e.MeasureString(Result, FontUsed, New Drawing.PointF(0, 0), New Drawing.StringFormat(Drawing.StringFormatFlags.MeasureTrailingSpaces)).Width
                Result += " "
            Loop
            Return Result
        End Function
        Public Function Calculate_NumberCharactersNeeded(ByRef e As Drawing.Graphics, ByVal FontUsed As Drawing.Font, ByVal Desired_StringLength As Single, Tag As String, Optional PaddingChar As Char = " ") As Integer
            Dim Result As String = ""
            Dim LengthTag As Integer = e.MeasureString(Tag, FontUsed, New Drawing.PointF(0, 0), New Drawing.StringFormat(Drawing.StringFormatFlags.MeasureTrailingSpaces)).Width

            Dim RemainingLengthRequired As Integer = Desired_StringLength - LengthTag
            Dim ResultLength As Single
            Do Until ResultLength >= RemainingLengthRequired
                ResultLength = e.MeasureString(Result, FontUsed, New Drawing.PointF(0, 0), New Drawing.StringFormat(Drawing.StringFormatFlags.MeasureTrailingSpaces)).Width
                Result += PaddingChar
            Loop
            Return Result.Length
        End Function
#End Region
    End Module
End Namespace