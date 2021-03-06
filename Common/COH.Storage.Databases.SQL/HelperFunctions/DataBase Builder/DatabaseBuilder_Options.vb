Imports COH.CodeManagement.Enums.Databases.SQL
Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class DatabaseBuilder_DatabaseOptions

#Region "Properties"
        Public Property CURSOR_DEFAULT As String ' Global 
        Public Property PARAMETERIZATION As String 'SIMPLE 
        Public Property RECOVERY As String ' FULL
        Public Property PAGE_VERIFY As String 'CHECKSUM   
        Public Property OnOff_Options As Dictionary(Of DataBaseOptionsEnum, DatabaseOption_OnOffEnum)
        Public Property MULTI_USER
        Public Property READ_WRITE
#End Region

#Region "Create New Instance"
        Public Sub New()
            ConfigureOptions()
        End Sub
        Private Sub ConfigureOptions()
            OnOff_Options = New Dictionary(Of DataBaseOptionsEnum, DatabaseOption_OnOffEnum)
            For Each Item In [Enum].GetNames(GetType(DataBaseOptionsEnum))
                OnOff_Options.Add(Item, DatabaseOption_OnOffEnum.OFF)
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
            ''//ALTER DATABASE [cohacc] SET ANSI_NULL_DEFAULT OFF 
            Dim SB As New Text.StringBuilder
            For Each Item In OnOff_Options
                SB.AppendLine("ALTER DATABASE " & DatabaseName.BracketTheString & " SET " & Item.Key.ToString & Item.Value.ToString)
            Next
            Return SB.ToString
        End Function
#End Region

    End Class
End Namespace
