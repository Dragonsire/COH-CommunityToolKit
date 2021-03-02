Imports COH.CodeManagement.Enums.Databases
Imports COH.HelperFunctions.Databases.SQL_Lite

Namespace Storage.DataBases.SQL_Lite
    Partial Public NotInheritable Class GameDatabase_SQL_Lite

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

#Region "SQL - Formatting"

		Private Shared Function FormatLine() As String
			Return (Environment.NewLine & Chr(9))
		End Function
		Private Shared Function FormatLine_ColumnName(TheV As [Enum]) As String
			Return (Environment.NewLine & Chr(9) & TheV.ToString.QuoteTheString)
		End Function

		Private Shared Function FormatLine_EndTable(Clustered As Boolean) As String
			If Clustered = False Then
				Return (Environment.NewLine & ");")
			Else
				Return (Environment.NewLine & ") WITHOUT ROWID;")
			End If
		End Function
		Private Shared Function FormatLine_Constraint(Name As [Enum], Key As [Enum]) As String
			Return (Environment.NewLine & Chr(9) & "CONSTRAINT " & Name.ToString.QuoteTheString) & " PRIMARY KEY(" & Key.ToString.QuoteTheString & ")"
		End Function
#End Region

#Region "Commands - Individual Tables"
		Public Shared Function Retrieve_CommandString_CreateTable_Account() As String
			Dim CommandString As String = "" &
			"CREATE TABLE IF NOT EXISTS " & GDEnum_AccountTables.Account.ToString.QuoteTheString & " (" &
			SQLLite_FormatLine_ColumnCreate(GDEnum_Account_AccountColumn.Auth_ID, SQL_Types.INT, False) &
			SQLLite_FormatLine_ColumnCreate_VarChars(GDEnum_Account_AccountColumn.Auth_Name, 14) &
			SQLLite_FormatLine_ColumnCreate_Blob(GDEnum_Account_AccountColumn.LoyaltyPoints_Balance, 16) &
			SQLLite_FormatLine_ColumnCreate_SmallInt(GDEnum_Account_AccountColumn.LoyaltyPoints_Earned) &
			SQLLite_FormatLine_ColumnCreate_SmallInt(GDEnum_Account_AccountColumn.LoyaltyPoints_Spent) &
			SQLLite_FormatLine_ColumnCreate_Date(GDEnum_Account_AccountColumn.Email_Lastsent) &
			SQLLite_FormatLine_ColumnCreate_SmallInt(GDEnum_Account_AccountColumn.Email_LastsentNumber) &
			SQLLite_FormatLine_ColumnCreate_Date(GDEnum_Account_AccountColumn.FreeTransfer_LastRecieved) &
			FormatLine_Constraint(GDEnum_Account_AccountColumn.UniqueKey, GDEnum_Account_AccountColumn.Auth_ID) &
			FormatLine_EndTable(True)
			Return CommandString
		End Function
		Public Shared Function Retrieve_CommandString_CreateTable_ProductType() As String
			Dim CommandString As String = "" &
			"CREATE TABLE IF NOT EXISTS " & GDEnum_AccountTables.Product_Type.ToString.QuoteTheString & " (" &
			SQLLite_FormatLine_ColumnCreate(GDEnum_Account_ProductTypeColumn.Product_TypeID, SQL_Types.INT, False) &
			SQLLite_FormatLine_ColumnCreate_VarChars(GDEnum_Account_ProductTypeColumn.Product_Name, 128) &
			FormatLine_Constraint(GDEnum_Account_ProductTypeColumn.UniqueKey, GDEnum_Account_ProductTypeColumn.Product_TypeID) &
			FormatLine_EndTable(True)
			Return CommandString
		End Function
#End Region
	End Class
End Namespace
