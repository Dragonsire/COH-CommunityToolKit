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

		Public Shared Function CreateWrapper_AccountDatabase(Name As String, FileName As String) As DatabaseBuilder
			Dim TheDatabase As New DatabaseBuilder(Name, FileName)
			Dim AccountTable = TheDatabase.AddTable(GDEnum_AccountTables.Account.ToString)
			AccountTable.AddColumn(GDEnum_Account_AccountColumn.Auth_ID, SQL_Types.INT, False)
			AccountTable.AddColumn_VarChar(GDEnum_Account_AccountColumn.Auth_Name, 14)
			AccountTable.AddColumn_Blob(GDEnum_Account_AccountColumn.LoyaltyPoints_Balance, 16)
			AccountTable.AddColumn_SmallInt(GDEnum_Account_AccountColumn.LoyaltyPoints_Earned)
			AccountTable.AddColumn_SmallInt(GDEnum_Account_AccountColumn.LoyaltyPoints_Spent)
			AccountTable.AddColumn_Date(GDEnum_Account_AccountColumn.Email_Lastsent)
			AccountTable.AddColumn_SmallInt(GDEnum_Account_AccountColumn.Email_LastsentNumber)
			AccountTable.AddColumn_Date(GDEnum_Account_AccountColumn.FreeTransfer_LastRecieved)
			AccountTable.Constraint = New DatabaseBuilder_DatabaseTableConstraint(GDEnum_Account_AccountColumn.UniqueKey.ToString, GDEnum_Account_AccountColumn.Auth_ID.ToString)
			AccountTable.Clustered = True
			Return TheDatabase
		End Function

#End Region
	End Class
End Namespace
