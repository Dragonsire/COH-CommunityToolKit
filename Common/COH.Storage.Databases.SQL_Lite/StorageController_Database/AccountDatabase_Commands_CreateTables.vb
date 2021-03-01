Imports COH.CodeManagement.Enums.Databases

Namespace Storage.DataBases.SQL_Lite
    Partial Public NotInheritable Class GameDatabase_SQL_Lite

#Region "Commands"
        Public Shared Function Retrieve_CommandString_CreateTable(Table As GDEnum_AccountTables) As String
			Select Case Table
				Case GDEnum_AccountTables.Account
					Return Retrieve_CommandString_CreateTable_Account()
			End Select
			Return ""
		End Function
#End Region

#Region "Commands - Individual Tables"
		Private Shared Function FormatName(TheV As [Enum]) As String
			Return (Environment.NewLine & Chr(9) & TheV.ToString.QuoteTheString)
		End Function
		Private Shared Function FormatLine() As String
			Return (Environment.NewLine & Chr(9))
		End Function
		Private Shared Function FormatLine_EndTable(Clustered As Boolean) As String
			If Clustered = False Then
				Return (Environment.NewLine & ");")
			Else
				Return (Environment.NewLine & ") WITHOUT ROWID;")
			End If
		End Function
		Private Shared Function FormatConstraintLine(Name As [Enum], Key As [Enum]) As String
			Return (Environment.NewLine & Chr(9) & "CONSTRAINT " & Name.ToString.QuoteTheString) & " PRIMARY KEY(" & Key.ToString.QuoteTheString & ")"
		End Function
		Public Shared Function Retrieve_CommandString_CreateTable_Account() As String
			Dim CommandString As String = "" &
			"CREATE TABLE IF NOT EXISTS " & GDEnum_AccountTables.Account.ToString.QuoteTheString & " (" &
			FormatName(GDEnum_AccountTables_Account.Auth_ID) & " INT NOT NULL, " &
			FormatName(GDEnum_AccountTables_Account.Auth_Name) & " VARCHAR(14) NULL, " &
			FormatName(GDEnum_AccountTables_Account.LoyaltyPoints_Balance) & " BLOB(16) NULL, " &
			FormatName(GDEnum_AccountTables_Account.LoyaltyPoints_Earned) & " SMALLINT NULL DEFAULT 0, " &
			FormatName(GDEnum_AccountTables_Account.LoyaltyPoints_Spent) & " SMALLINT NULL DEFAULT 0, " &
			FormatName(GDEnum_AccountTables_Account.Email_Lastsent) & " DATETIME NULL DEFAULT '2000.01.01'," &
			FormatName(GDEnum_AccountTables_Account.Email_LastsentNumber) & " SMALLINT NULL DEFAULT 0, " &
			FormatName(GDEnum_AccountTables_Account.FreeTransfer_LastRecieved) & " DATETIME NULL DEFAULT '2000.01.01'," &
			FormatConstraintLine(GDEnum_AccountTables_Account.UniqueKey, GDEnum_AccountTables_Account.Auth_ID) &
			FormatLine_EndTable(True)
			Return CommandString
		End Function
		Public Shared Function Retrieve_CommandString_CreateTable_Account2() As String
			Dim CommandString As String = "" &
			"CREATE TABLE IF NOT EXISTS " & GDEnum_AccountTables.Account.ToString & " (" &
			GDEnum_AccountTables_Account.Auth_ID.ToString & " INT NOT NULL, " &
			GDEnum_AccountTables_Account.Auth_Name.ToString & " VARCHAR(14) NULL, " &
			GDEnum_AccountTables_Account.LoyaltyPoints_Balance.ToString & " BLOB(16) NULL, " &
			GDEnum_AccountTables_Account.LoyaltyPoints_Earned.ToString & " SMALLINT NULL, " &
			GDEnum_AccountTables_Account.LoyaltyPoints_Spent.ToString & " SMALLINT NULL, " &
			GDEnum_AccountTables_Account.Email_Lastsent.ToString & " DATETIME NULL DEFAULT '2000.01.01'," &
			GDEnum_AccountTables_Account.Email_LastsentNumber.ToString & " SMALLINT NULL, " &
			GDEnum_AccountTables_Account.FreeTransfer_LastRecieved.ToString & " DATETIME NULL DEFAULT '2000.01.01'," &
			"CONSTRAINT " & GDEnum_AccountTables_Account.UniqueKey.ToString & " PRIMARY KEY(" & GDEnum_AccountTables_Account.Auth_ID.ToString & "))"
			Return CommandString
		End Function
#End Region
	End Class
End Namespace
