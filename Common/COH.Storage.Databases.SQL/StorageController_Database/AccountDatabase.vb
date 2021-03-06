Imports System.Data
Imports COH.CodeManagement.Enums.Databases

Namespace Storage.DataBases.SQL
    Public NotInheritable Class GameDatabase_SQL
        Inherits GameDatabases_Accounts

#Region "Properties"
        Public ReadOnly Property Connection As SqlClient.SqlConnection
            Get
                Return pConnection
            End Get
        End Property
        Private pConnection As SqlClient.SqlConnection
#End Region

#Region "Create New Instance"
        Public Sub New()

        End Sub
        Public Sub New(ConnectionString As String)
            pConnection = New SqlClient.SqlConnection(ConnectionString)
        End Sub
        Private Function Database_CreateNew(FilePath As String, DeleteExisting As Boolean) As Boolean
        End Function
#End Region

#Region "Initialize"
        Private Sub SetDefaults()
        End Sub
        Public Function CreateDatabase() As Boolean
            Dim Command As SqlClient.SqlCommand = Commands_CreateNew()
            'Command.Transaction = Transactions_CreateNew()
            Command.CommandText = Retrieve_CommandString_CreateDatabase("COH_ACC", "E:\COH_TEST.MDF")
            Try
                Command.ExecuteNonQuery()
                ' Command.Transaction.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try

            Return True
        End Function
        Public Function DeleteDatabase() As Boolean
            Return True
            Dim Command As SqlClient.SqlCommand = Commands_CreateNew()
            Command.Transaction = Transactions_CreateNew()
            Command.CommandText = Retrieve_CommandString_DeleteDatabase("COH_ACC")
            Try
                Command.ExecuteNonQuery()
                Command.Transaction.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try
            Return True
        End Function
        Protected Overrides Function CreateTables(IncludeRealtionships As Boolean) As Boolean
            Dim Command As SqlClient.SqlCommand = Commands_CreateNew()
            Command.Transaction = Transactions_CreateNew()
            Dim Result As Boolean = True
            If CreateTable(Command, GDEnum_AccountTables.Account, IncludeRealtionships) = False Then Return False
            If CreateTable(Command, GDEnum_AccountTables.Product_Type, IncludeRealtionships) = False Then Return False
            'If CreateTable(Command, GDEnum_AccountTables.Product, IncludeRealtionships) = False Then Return False
            'If CreateTable(Command, GDEnum_AccountTables.Game_Log, IncludeRealtionships) = False Then Return False
            'If CreateTable(Command, GDEnum_AccountTables.Inventory, IncludeRealtionships) = False Then Return False
            'If CreateTable(Command, GDEnum_AccountTables.MTX_Log, IncludeRealtionships) = False Then Return False
            'If CreateTable(Command, GDEnum_AccountTables.GameTransactions, IncludeRealtionships) = False Then Return False
            Command.Transaction.Commit()
            Return Result
        End Function
        Protected Overrides Function CreateTable(TheTable As GDEnum_AccountTables, IncludeRealtionships As Boolean) As Boolean
            Dim Command As SqlClient.SqlCommand = Commands_CreateNew()
            Return CreateTable(Command, TheTable, IncludeRealtionships)
        End Function
        Protected Overloads Function CreateTable(ByRef ExistingCommand As SqlClient.SqlCommand, TheTable As GDEnum_AccountTables, IncludeRealtionships As Boolean) As Boolean
            Try
                ExistingCommand.CommandText = Retrieve_CommandString_CreateTable(TheTable)
                ExistingCommand.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception(ex.ToString)
                Return False
            End Try
            Return True
        End Function
#End Region

#Region "Connect / Disconnect"
        Private Function Database_OpenExisting() As Data.DataSet
            If Database_OpenConnection() = False Then Return Nothing
            'Return Retrieve_DataSet()
        End Function
        Public Function Database_OpenConnection_WinAuth() As Boolean
            If Connection_AlreadyExists() = True Then Return True
            Dim Builder As SqlClient.SqlConnectionStringBuilder = New SqlClient.SqlConnectionStringBuilder
            With Builder
                '//DRAGONSIRELAPTO\SQLEXPRESS01
                .PersistSecurityInfo = True
                .IntegratedSecurity = True
                '.InitialCatalog = "cohacc"
                '.DataSource = "(local)\SQLExpress"
                '.DataSource = ".\SQLExpress"
                .DataSource = "DRAGONSIRELAPTO\SQLEXPRESS"
                '.UserID = "NT Service\MSSQL$SQLEXPRESS"
                '.Password = "MyPass1"
                ' .ConnectTimeout = 30
            End With
            Dim TheConnectionString As String = Builder.ToString
            pConnection = New SqlClient.SqlConnection(Builder.ToString())
            Try
                pConnection.Open()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return (pConnection.State = Data.ConnectionState.Open)
        End Function
        Private Function Database_OpenConnection() As Boolean
            If Connection_AlreadyExists() = True Then Return True
            Dim ConnectString As SqlClient.SqlConnectionStringBuilder = New SqlClient.SqlConnectionStringBuilder
            With ConnectString
                .UserID = ""
                .Password = ""
                .InitialCatalog = ""
                .DataSource = "localhost"
                .ConnectTimeout = 30
            End With
            ConnectString.DataSource = ""
            pConnection = New SqlClient.SqlConnection(ConnectString.ToString())
            pConnection.Open()
            Return (pConnection.State = Data.ConnectionState.Open)
        End Function
        Public Sub Connection_Close()
            pConnection.Close()
            pConnection = Nothing
            'Transactions_Clear()
        End Sub
#End Region

#Region "Connection Status"
        Private Function Connection_AlreadyExists() As Boolean
            If (pConnection Is Nothing) Then Return False
            Select Case pConnection.State
                Case Data.ConnectionState.Broken, Data.ConnectionState.Closed
                    Return Connection_Repair()
                Case Data.ConnectionState.Open
                    Return True
                Case Data.ConnectionState.Executing, Data.ConnectionState.Fetching
                    Return True
                Case Data.ConnectionState.Connecting
                    Return True
                Case Else
                    Return False
            End Select
        End Function
        Private Function Connection_Repair() As Boolean
            If (pConnection Is Nothing) Then Return False
            Dim Result As Boolean = False
            Try
                pConnection.Close()
                pConnection.Open()
                'Transactions_Clear()
                Result = True
            Catch ex As Exception
            End Try
            Return Result
        End Function
#End Region

#Region "Commands"
        Private Function Commands_CreateNew() As SqlClient.SqlCommand
            If Not pConnection.State = Data.ConnectionState.Open Then pConnection.Open()
            Return pConnection.CreateCommand()
        End Function
        Public Sub SendCommand(value As String)
            Dim Command As SqlClient.SqlCommand = Commands_CreateNew()
            Command.CommandText = value
            Try
                Command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Sub
#End Region

#Region "Transactions"
        Public Function Transactions_CreateNew() As SqlClient.SqlTransaction
            Return pConnection.BeginTransaction()
        End Function
#End Region

    End Class
End Namespace
