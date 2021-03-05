Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class DatabaseBuilder

#Region "Properties"
        Public Property DatabaseName As String
        Public Property FileName As String
        Public Property Tables As List(Of DatabaseBuilder_DatabaseTable)
        Public Property ANSI_NULL_DEFAULT As DatabaseOptionEnum
        Public Property ANSI_NULLS As DatabaseOptionEnum
        Public Property ANSI_PADDING As DatabaseOptionEnum
        Public Property ANSI_WARNINGS As DatabaseOptionEnum
        Public Property ARITHABORT As DatabaseOptionEnum
        Public Property AUTO_CLOSE As DatabaseOptionEnum
        Public Property AUTO_SHRINK As DatabaseOptionEnum
        Public Property AUTO_UPDATE_STATISTICS As DatabaseOptionEnum
        Public Property CURSOR_CLOSE_ON_COMMIT As DatabaseOptionEnum
        Public Property CURSOR_DEFAULT As String ' Global 
        Public Property CONCAT_NULL_YIELDS_NULL As DatabaseOptionEnum
        Public Property NUMERIC_ROUNDABORT As DatabaseOptionEnum
        Public Property QUOTED_IDENTIFIER As DatabaseOptionEnum
        Public Property RECURSIVE_TRIGGERS As DatabaseOptionEnum
        Public Property DISABLE_BROKER As DatabaseOptionEnum
        Public Property AUTO_UPDATE_STATISTICS_ASYNC As DatabaseOptionEnum
        Public Property DATE_CORRELATION_OPTIMIZATION As DatabaseOptionEnum
        Public Property TRUSTWORTHY As DatabaseOptionEnum
        Public Property ALLOW_SNAPSHOT_ISOLATION As DatabaseOptionEnum
        Public Property PARAMETERIZATION As String 'SIMPLE 
        Public Property READ_COMMITTED_SNAPSHOT As DatabaseOptionEnum
        Public Property HONOR_BROKER_PRIORITY As DatabaseOptionEnum
        Public Property RECOVERY As String ' FULL
        Public Property MULTI_USER As DatabaseOptionEnum
        Public Property PAGE_VERIFY As String 'CHECKSUM   
        Public Property DB_CHAINING As DatabaseOptionEnum
        Public Property READ_WRITE As DatabaseOptionEnum
        Public Enum DatabaseOptionEnum
            [ON]
            OFF
        End Enum
#End Region

#Region "Create New Instance"
        Public Sub New(Name As String, Location As String)
            DatabaseName = Name
            FileName = Location
            Tables = New List(Of DatabaseBuilder_DatabaseTable)
        End Sub
#End Region

#Region "Tables"
        Public Function AddTable(Name As String) As DatabaseBuilder_DatabaseTable
            Dim NewTable As New DatabaseBuilder_DatabaseTable(Name)
            Tables.Add(NewTable)
            Return NewTable
        End Function
#End Region

#Region "Export"
        Public Function Export_CommandString_Create() As String
            Dim SB As New Text.StringBuilder
            SB.Append("CREATE DATABASE " & DatabaseName.BracketTheString & " ON PRIMARY (Name= N'" & DatabaseName & "', FILENAME= N'" & FileName & "')")
            Return SB.ToString
        End Function
        Public Function Export_CommandString_Options() As String
            ''//ALTER DATABASE [cohacc] SET ANSI_NULL_DEFAULT OFF 
            Dim SB As New Text.StringBuilder
            SB.Append("ALTER DATABASE " & DatabaseName.BracketTheString & " SET ANSI_NULL_DEFAULT " & ANSI_NULL_DEFAULT.ToString)
            SB.Append("ALTER DATABASE " & DatabaseName.BracketTheString & " SET ANSI_NULLS " & ANSI_NULLS.ToString)
            Return SB.ToString
        End Function
#End Region

    End Class
End Namespace
