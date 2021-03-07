Imports COH.CodeManagement.Enums.Databases.SQL
Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class DatabaseBuilder_DatabaseOptions

#Region "Properties"
        Public Property COMPATIBILITY_LEVEL As Integer '= 100
        Public Property CURSOR_DEFAULT As DatabaseOption_CursorEnum ' Global 
        Public Property PARAMETERIZATION As DatabaseOption_ParamEnum 'SIMPLE 
        Public Property RECOVERY As String ' FULL
        Public Property PAGE_VERIFY As DatabaseOption_PageVerifyEnum 'CHECKSUM   
        Public Property OnOff_Options As Dictionary(Of DataBaseOptionsEnum, DatabaseOption_OnOffEnum)
        Public Property RestrictAccess As DatabaseOption_AccessEnum
        Public Property READ_WRITE
#End Region

#Region "Create New Instance"
        Public Sub New()
            ConfigureOptions()
        End Sub
        Private Sub ConfigureOptions()
            OnOff_Options = New Dictionary(Of DataBaseOptionsEnum, DatabaseOption_OnOffEnum)
            For Each item In System.Enum.GetValues(GetType(FirstDayOfWeek))
                OnOff_Options.Add(item, DatabaseOption_OnOffEnum.OFF)
            Next
        End Sub
        Public Sub UpdateOption(TheProperty As DataBaseOptionsEnum, value As DatabaseOption_OnOffEnum)
            OnOff_Options.Item(TheProperty) = value
        End Sub
        Public Function RetrieveOption(TheProperty As DataBaseOptionsEnum) As DatabaseOption_OnOffEnum
            Return OnOff_Options.Item(TheProperty)
        End Function
#End Region

#Region "Export"
        Public Function Export_CommandString_Options(DatabaseName As String) As String
            Dim SB As New Text.StringBuilder
            Dim SETCommand As String = "ALTER DATABASE " & DatabaseName.BracketTheString & " SET "
            SB.AppendLine(SETCommand & "COMPATIBILITY_LEVEL " & COMPATIBILITY_LEVEL.ToString)
            For Each Item In OnOff_Options
                SB.AppendLine(SETCommand & Item.Key.ToString & " " & Item.Value.ToString)
            Next
            SB.AppendLine(SETCommand & "CURSOR_DEFAULT " & CURSOR_DEFAULT.ToString)
            SB.AppendLine(SETCommand & "PARAMETERIZATION " & PARAMETERIZATION.ToString)
            SB.AppendLine(SETCommand & "RECOVERY " & RECOVERY.ToString)
            SB.AppendLine(SETCommand & "PAGE_VERIFY " & PAGE_VERIFY.ToString)
            Return SB.ToString
        End Function
#End Region

    End Class
End Namespace
