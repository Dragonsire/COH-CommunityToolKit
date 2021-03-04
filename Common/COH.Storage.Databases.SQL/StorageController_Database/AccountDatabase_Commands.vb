Imports COH.CodeManagement.Enums.Databases
Imports COH.CodeManagement.Extentions
Imports COH.HelperFunctions.Databases.SQL
Namespace Storage.DataBases.SQL
	Partial Public NotInheritable Class GameDatabase_SQL

#Region "Commands"
		Public Shared Function Retrieve_CommandString_CreateDatabase(Name As String, FileName As String) As String
			Dim CommandString As String = "" &
			"CREATE DATABASE " & Name.BracketTheString & "ON PRIMARY (Name= N'" & Name & "', FILENAME= N'" & FileName & "')"
			Return CommandString
		End Function
		Public Shared Function Retrieve_CommandString_DeleteDatabase(Name As String) As String
			Dim CommandString As String = "" &
			"DROP DATABASE IF EXISTS" & Name & ")"
			Return CommandString
		End Function
#End Region
	End Class
End Namespace
