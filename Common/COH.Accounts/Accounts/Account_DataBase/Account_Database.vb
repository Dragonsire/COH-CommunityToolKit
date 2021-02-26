Imports COH.CodeManagement.Constants.Accounts
Imports COH.CodeManagement.Enums.Accounts

Namespace Accounts
    Public Class adbGlobals
        Public Shared ReadOnly Property adb As New adbGlobals()
        Public Property Accounts() As GameAccount ' EArray
        Public Property updateListHead As GameAccount ' Linked list connected via the via the nextDirty pointer
        Public Property byAuthId As New StashTable()
        Public Property byAuthName As New StashTable()
    End Class

    Public Class Account_DataBase
        Public Shared Sub AccountDb_Init()
            '// Create Memory Space for Account
            'MP_CREATE(Account, ACCOUNT_INITIAL_CONTAINER_SIZE)

            'Some kind of Lookup Table by AuthID
            'adbGlobals.adb.byAuthId = stashTableCreateInt(stashOptimalSize(ACCOUNT_INITIAL_CONTAINER_SIZE))
            'Some kind of Lookup Table by Name
            'adbGlobals.adb.byAuthName = stashTableCreateWithStringKeys(stashOptimalSize(ACCOUNT_INITIAL_CONTAINER_SIZE), StashDefault)
        End Sub

        Public Shared Sub AccountDb_Shutdown()
            'stashTableDestroy(adbGlobals.adb.byAuthId)
            'stashTableDestroy(adbGlobals.adb.byAuthName)
            adbGlobals.adb.updateListHead = Nothing
            'MP_DESTROY(Account)
        End Sub
        Public Shared Function AccountDb_GetCount() As Integer
            'Return NumberofAccounts
            'Return eaSize(adbGlobals.adb.Accounts)
        End Function
        Friend Shared Sub AccountDb_Send(ByRef Account As GameAccount)
            Dim pak_out As Packet
            Dim i As Integer
            Dim size As Integer

            If Not SAFE_MEMBER(Account.shard, link.connected) Then
                Return
            End If

            ' send back account and inventory information
            pak_out = pktCreateEx(Account.shard.link, ACCOUNT_SVR_INVENTORY)
            'pktSendBitsAuto(pak_out, account.Auth_ID)

            size = eaSize(Account.invSet.invArr)
            'pktSendBitsAuto(pak_out, size)
            For i = 0 To size - 1
                AccountInventorySendItem(pak_out, Account.invSet.invArr(i))
            Next i

            'pktSendBits(pak_out, 1, If(g_accountServerState.cfg.bFreeShardXfersOnlyEnabled, 1, 0))
            'pktSendBitsAuto(pak_out, updateShardXferTokenCount(account))
            'pktSendBitsArray(pak_out, LOYALTY_BITS, AccountDb_GetLoyaltyBits(account))
            'pktSendBitsAuto(pak_out, account.loyaltyPointsUnspent)
            'pktSendBitsAuto(pak_out, account.loyaltyPointsEarned)
            'pktSendBitsAuto(pak_out, account.virtualCurrencyBal)
            'pktSendBitsAuto(pak_out, account.lastEmailTime)
            'pktSendBitsAuto(pak_out, account.lastNumEmailsSent)
            'pktSend(pak_out, account.shard.link)
        End Sub
        Public Shared Function AccountDb_Tick() As Boolean
            Dim prev As GameAccount = Nothing
            Dim [next] As GameAccount = Nothing
            Dim account As GameAccount = adbGlobals.adb.updateListHead
            Do
                [next] = account.NextUpdate

                If (account.NextUpdate_Flags And AccountUpdateFlags.ACCOUNTDB_UPDATE_SQL_ACCOUNT) <> 0 Then
                    AccountDb_CommitAsync(account)
                    account.NextUpdate_Flags = account.NextUpdate_Flags And Not AccountUpdateFlags.ACCOUNTDB_UPDATE_SQL_ACCOUNT
                End If

                If (account.NextUpdate_Flags And AccountUpdateFlags.ACCOUNTDB_UPDATE_NETWORK) <> 0 AndAlso AccountDb_IsDataLoaded(account) Then
                    AccountDb_Send(account)
                    account.NextUpdate_Flags = account.NextUpdate_Flags And Not AccountUpdateFlags.ACCOUNTDB_UPDATE_NETWORK
                End If

                If Not account.NextUpdate_Flags Then
                    ' remove from dirty list
                    account.PrepareNextUpdate(Nothing)
                    If prev Is Nothing Then
                        adbGlobals.adb.updateListHead = [next]
                    Else
                        account.PrepareNextUpdate([next])
                    End If
                Else
                    prev = account
                End If
                account = [next]
                If account Is Nothing Then Exit Do
            Loop
            Return (adbGlobals.adb.updateListHead Is Nothing)
        End Function
        Public Shared Function AccountDb_IsDataLoaded(ByRef Account As GameAccount) As Boolean
            Return Account.StorageAccount IsNot Nothing
        End Function
        Public Shared Function AccountDb_LoadOrCreateAccount(ByVal auth_id As UInt32, ByVal auth_name As String) As GameAccount
            Dim account As GameAccount = Nothing
            'devassert(auth_id)

            If Not stashIntFindPointer(adb.byAuthId, auth_id, DirectCast(account, Object)) Then
                'account = MP_ALLOC(account)
                account = New GameAccount(auth_id, auth_name)
                'account.Auth_ID = auth_id
                If auth_name IsNot Nothing Then
                    'account.Auth_Name = auth_name
                Else
                    'account.Auth_Name(0) = 0
                End If
                '//Add New Account to List and then to Stash
                'eaPush(adbGlobals.adb.Accounts, account)
                'Debug.Assert(stashIntAddPointer(adbGlobals.adb.byAuthId, auth_id, account, False))
                asql_find_or_create_account_async(account)
            End If
            Return account
        End Function
        Public Shared Function AccountDb_GetAccount(ByVal auth_id As UInt32) As GameAccount
            Dim account As GameAccount = Nothing
            If stashIntFindPointer(adbGlobals.adb.byAuthId, auth_id, DirectCast(account, GameAccount)) Then
                Return account
            End If
            Return Nothing
        End Function
        Public Shared Function AccountDb_SearchForOnlineAccount(ByVal auth_name_or_id As String) As GameAccount
            Dim account As GameAccount
            If stashFindPointer(adbGlobals.adb.byAuthName, auth_name_or_id, DirectCast(account, Object)) Then
                Return account
            End If
            Return AccountDb_GetAccount(Convert.ToInt32(auth_name_or_id))
        End Function
        Public Shared Sub AccountDb_SearchForOfflineAccount(ByVal auth_name_or_id As String)
            asql_search_for_account_async(auth_name_or_id)
        End Sub
        Public Shared Sub AccountDb_WaitFor(ByRef Account As GameAccount)
            devassertmsg(Account.asql, "Performance Warning: AccountDb_WaitFor is going to block because the account data has not arrived yet")
            Do While Not Account.asql
                asql_wait_for_tick()
            Loop
        End Sub
        Public Shared Function AccountDb_GetLoyaltyBits(ByRef Account As GameAccount) As Byte
            AccountDb_WaitFor(Account)
            Return Account.asql.loyalty_bits
        End Function
        Public Shared Sub AccountDb_MarkUpdate(ByRef Account As GameAccount, ByVal addFlags As AccountUpdateFlags)
            Debug.Assert(addFlags)

            ' It is invalid to update the account before it has been retrieved
            If addFlags.HasFlag(AccountUpdateFlags.ACCOUNTDB_UPDATE_SQL_ACCOUNT) Then
                Debug.Assert(Account.asql)
            End If

            If Not Account.NextUpdate_Flags Then
                ' Insert at linked list head
                Account.PrepareNextUpdate(adbGlobals.adb.updateListHead)
                adbGlobals.adb.updateListHead = Account
            End If

            Account.NextUpdate_Flags = (Account.NextUpdate_Flags Or addFlags)
        End Sub
        Public Shared Sub AccountDb_LoadFinished(ByRef Account As GameAccount)
            Debug.Assert(Account.asql)
            '//Populate AuthName From SQL / DATABASE
            'account.Auth_Name = account.asql.name.Substring(0, sizeof(account.Auth_Name))
            If String.IsNullOrEmpty(Account.Auth_Name) Then
                ' Debug.Assert(stashAddPointer(adb.byAuthName, account.Auth_Name, account, True))
            End If

            ' This is difficult to check inside SQL so do the check here
            'devassert(account.asql.loyalty_points_spent >= accountLoyaltyRewardGetNodesBought(account.asql.loyalty_bits))

            'Populate From SQL / DATABASE
            'account.loyaltyPointsEarned = account.asql.last_loyalty_point_count
            'account.loyaltyPointsUnspent = account.loyaltyPointsEarned - account.asql.loyalty_points_spent
            'account.lastEmailTime = timerGetSecondsSince2000FromSQLTimestamp(account.asql.last_email_date)
            'account.lastNumEmailsSent = account.asql.last_num_emails_sent
            'account.freeXferMonths = timerGetMonthsSinceZeroFromSQLTimestamp(account.asql.free_xfer_date)

            ' CSR might be waiting for this account to load
            AccountServer_SlashNotifyAccountLoaded(Account)
        End Sub
        Public Shared Sub AccountDb_CommitAsync(ByRef Account As GameAccount)
            Debug.Assert(Account.asql)
            Account.asql.last_loyalty_point_count = Account.loyaltyPointsEarned
            Account.asql.loyalty_points_spent = Account.loyaltyPointsEarned - Account.loyaltyPointsUnspent
            timerMakeSQLTimestampFromSecondsSince2000(Account.lastEmailTime, Account.asql.last_email_date)
            Account.asql.last_num_emails_sent = Account.lastNumEmailsSent
            timerMakeSQLTimestampFromMonthsSinceZero(Account.freeXferMonths, Account.asql.free_xfer_date)

            ' This is difficult to check inside SQL so do the check here
            devassert(Account.asql.loyalty_points_spent >= accountLoyaltyRewardGetNodesBought(Account.asql.loyalty_bits))
            asql_update_account_async(Account)
        End Sub
    End Class

End Namespace