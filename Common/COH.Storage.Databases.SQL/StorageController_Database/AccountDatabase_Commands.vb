Imports COH.CodeManagement.Enums.Databases
Imports COH.CodeManagement.Extentions
Imports COH.HelperFunctions.Databases.SQL
Imports COH.HelperFunctions.Databases.SQL.DatabaseBuilder_DatabaseOptions

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
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.ANSI_NULL_DEFAULT, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.ANSI_NULLS, DatabaseOption_OnOffEnum.ON)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.ANSI_PADDING, DatabaseOption_OnOffEnum.ON)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.ANSI_WARNINGS, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.ARITHABORT, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.AUTO_CLOSE, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.AUTO_SHRINK, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.AUTO_UPDATE_STATISTICS, DatabaseOption_OnOffEnum.ON)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.CURSOR_CLOSE_ON_COMMIT, DatabaseOption_OnOffEnum.OFF)
            'TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.CURSOR_DEFAULT  GLOBAL 
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.CONCAT_NULL_YIELDS_NULL, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.NUMERIC_ROUNDABORT, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.QUOTED_IDENTIFIER, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.RECURSIVE_TRIGGERS, DatabaseOption_OnOffEnum.OFF)
            'TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.DISABLE_BROKER 
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.AUTO_UPDATE_STATISTICS_ASYNC, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.DATE_CORRELATION_OPTIMIZATION, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.TRUSTWORTHY, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.ALLOW_SNAPSHOT_ISOLATION, DatabaseOption_OnOffEnum.OFF)
            'TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.PARAMETERIZATION SIMPLE 
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.READ_COMMITTED_SNAPSHOT, DatabaseOption_OnOffEnum.OFF)
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.HONOR_BROKER_PRIORITY, DatabaseOption_OnOffEnum.OFF)
            'TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.RECOVERY FULL 
            'TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.MULTI_USER 
            'TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.PAGE_VERIFY CHECKSUM  
            TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.DB_CHAINING, DatabaseOption_OnOffEnum.OFF)
            'TheDatabase.TheOptions.UpdateOption(DataBaseOptionsEnum.READ_WRITE 




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
