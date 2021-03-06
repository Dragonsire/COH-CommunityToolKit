﻿Imports COH.CodeManagement.Enums.Databases
Imports COH.CodeManagement.Extentions
Imports COH.HelperFunctions.Databases.SQL

Namespace Storage.DataBases.SQL
	Partial Public NotInheritable Class GameDatabase_SQL

#Region "Commands"
		Public Shared Function Retrieve_CommandString_CreateTable(Table As GDEnum_AccountTables) As String
			Select Case Table
				Case GDEnum_AccountTables.Account
					Return Retrieve_CommandString_CreateTable_Account()
				Case GDEnum_AccountTables.Product_Type
					Return Retrieve_CommandString_CreateTable_ProductType()
			End Select
			Return ""
		End Function
#End Region

#Region "Commands - Individual Tables"
		Public Shared Function Retrieve_CommandString_CreateTable_Account() As String
			Dim CommandString As String = "" &
			"CREATE TABLE IF NOT EXISTS " & GDEnum_AccountTables.Account.ToString.QuoteTheString & " (" &
			SQL_FormatLine_ColumnCreate(GDEnum_Account_AccountColumn.Auth_ID, System.Data.SqlDbType.Int, False) &
			SQL_FormatLine_ColumnCreate_VarChars(GDEnum_Account_AccountColumn.Auth_Name, 14) &
			SQL_FormatLine_ColumnCreate_Blob(GDEnum_Account_AccountColumn.LoyaltyPoints_Balance, 16) &
			SQL_FormatLine_ColumnCreate_SmallInt(GDEnum_Account_AccountColumn.LoyaltyPoints_Earned) &
			SQL_FormatLine_ColumnCreate_SmallInt(GDEnum_Account_AccountColumn.LoyaltyPoints_Spent) &
			SQL_FormatLine_ColumnCreate_Date(GDEnum_Account_AccountColumn.Email_Lastsent) &
			SQL_FormatLine_ColumnCreate_SmallInt(GDEnum_Account_AccountColumn.Email_LastsentNumber) &
			SQL_FormatLine_ColumnCreate_Date(GDEnum_Account_AccountColumn.FreeTransfer_LastRecieved) &
			FormatLine_Constraint(GDEnum_Account_AccountColumn.UniqueKey, GDEnum_Account_AccountColumn.Auth_ID) &
			FormatLine_EndTable(True)
			Return CommandString
		End Function
		Public Shared Function Retrieve_CommandString_CreateTable_ProductType() As String
			Dim CommandString As String = "" &
			"CREATE TABLE IF NOT EXISTS " & GDEnum_AccountTables.Product_Type.ToString.QuoteTheString & " (" &
			SQL_FormatLine_ColumnCreate(GDEnum_Account_ProductTypeColumn.Product_TypeID, System.Data.SqlDbType.Int, False) &
			SQL_FormatLine_ColumnCreate_VarChars(GDEnum_Account_ProductTypeColumn.Product_Name, 128) &
			FormatLine_Constraint(GDEnum_Account_ProductTypeColumn.UniqueKey, GDEnum_Account_ProductTypeColumn.Product_TypeID) &
			FormatLine_EndTable(True)
			Return CommandString
		End Function
#End Region
	End Class
End Namespace
