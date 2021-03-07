Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class DatabaseBuilder

#Region "Properties"
        Public Property DatabaseName As String
        Public Property FileName As String
        Public Property Tables As List(Of DatabaseBuilder_DatabaseTable)
        Public Property TheOptions As DatabaseBuilder_DatabaseOptions
#End Region

#Region "Create New Instance"
        Public Sub New(Name As String, Location As String)
            DatabaseName = Name
            FileName = Location
            Tables = New List(Of DatabaseBuilder_DatabaseTable)
            TheOptions = New DatabaseBuilder_DatabaseOptions
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
            Return TheOptions.Export_CommandString_Options(DatabaseName)
        End Function
#End Region

    End Class
End Namespace
