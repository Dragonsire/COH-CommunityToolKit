Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class SQL_Database

#Region "Properties"
        Public Property DatabaseName As String
        Public Property FileName As String
        Public Property Tables As List(Of SQL_DatabaseTable)
#End Region

#Region "Create New Instance"
        Public Sub New(Name As String, Location As String)
            DatabaseName = Name
            FileName = Location
            Tables = New List(Of SQL_DatabaseTable)
        End Sub
#End Region

#Region "Tables"
        Public Function AddTable(Name As String) As SQL_DatabaseTable
            Dim NewTable As New SQL_DatabaseTable(Name)
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
#End Region

    End Class
End Namespace
