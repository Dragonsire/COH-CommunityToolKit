Namespace CodeManagement.Constants.Accounts
    <HideModuleName> Public Module DefinedConstants_Accounts
        Public Const ACCOUNTDB_UPDATE_SQL_ACCOUNT As Integer = 1 ' /// Object needs the [account] table updated in SQL
        Public Const ACCOUNTDB_UPDATE_NETWORK As Integer = 2 '/// /// Object needs to be transmitted to the active shard
        Public Const MAX_SLOTS_PER_SHARD As Integer = 36
        Public Const MAX_SLOTS_TOTAL As Integer = MAX_SLOTS_PER_SHARD * 15
        Public Const REFUND_TIME_OUT As Integer = 2592000 '3600 * 24 * 30 ' 30 days


    End Module
End Namespace
