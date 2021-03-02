Imports System.Data
Imports System.Data.SQLite
Imports COH.CodeManagement.Enums.Databases

Namespace Storage.DataBases.SQL_Lite
    Public NotInheritable Class GameDatabase_SQL_Lite
        Inherits GameDatabases_Accounts

#Region "Properties"
        Public ReadOnly Property DataBase_FileSource As String
            Get
                Return pDatabase_Filesource
            End Get
        End Property
        Public ReadOnly Property Connection As SQLiteConnection
            Get
                Return pConnection
            End Get
        End Property
        Private pDatabase_Filesource As String
        Private pConnection As SQLiteConnection
#End Region

#Region "Create New Instance"
        Public Sub New(LocalFilePath As String, Optional DeleteExisting As Boolean = False)
            Database_CreateNew(LocalFilePath, DeleteExisting)
        End Sub
        Private Function Database_CreateNew(FilePath As String, DeleteExisting As Boolean) As Boolean
            pDatabase_Filesource = FilePath
            If IO.File.Exists(pDatabase_Filesource) = True Then
                If DeleteExisting = True Then
                    IO.File.Delete(pDatabase_Filesource)
                Else
                    Return False
                End If
            End If
            Dim Result As Boolean = True
            Try
                SQLiteConnection.CreateFile(pDatabase_Filesource)
                If Database_OpenConnection() = False Then Return False
                CreateTables(True)
            Catch ex As Exception
                Result = False
                Throw New ArgumentException(ex.ToString)
            End Try
            Return Result
        End Function
#End Region

#Region "Initialize"
        Private Sub SetDefaults()
        End Sub
        Protected Overrides Function CreateTables(IncludeRealtionships As Boolean) As Boolean
            Dim Command As SQLiteCommand = Commands_CreateNew()
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
            Dim Command As SQLiteCommand = Commands_CreateNew()
            Return CreateTable(Command, TheTable, IncludeRealtionships)
        End Function
        Protected Overloads Function CreateTable(ByRef ExistingCommand As SQLiteCommand, TheTable As GDEnum_AccountTables, IncludeRealtionships As Boolean) As Boolean
            Try
                ExistingCommand.CommandText = Retrieve_CommandString_CreateTable(TheTable)
                ExistingCommand.ExecuteNonQuery()
            Catch ex As Exception
                Throw New SQLiteException(ex.ToString)
                Return False
            End Try
            Return True
        End Function
#End Region

#Region "Connect / Disconnect"
        Private Function Database_OpenExisting(FilePath As IO.FileInfo) As Data.DataSet
            pDatabase_Filesource = FilePath.FullName
            If Database_OpenConnection() = False Then Return Nothing
            'Return Retrieve_DataSet()
        End Function
        Private Function Database_OpenConnection() As Boolean
            If Connection_AlreadyExists() = True Then Return True
            If System.IO.File.Exists(pDatabase_Filesource) = False Then Return False
            Dim ConnectString As SQLiteConnectionStringBuilder = New SQLiteConnectionStringBuilder()
            ConnectString.DataSource = pDatabase_Filesource
            ConnectString.ForeignKeys = True
            ConnectString.JournalMode = SQLiteJournalModeEnum.Default
            pConnection = New SQLiteConnection(ConnectString.ToString())
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
        Private Function Commands_CreateNew() As SQLiteCommand
            If Not pConnection.State = Data.ConnectionState.Open Then pConnection.Open()
            Return pConnection.CreateCommand()
        End Function
#End Region

#Region "Transactions"
        Public Function Transactions_CreateNew() As SQLiteTransaction
            Return pConnection.BeginTransaction()
        End Function
#End Region

    End Class
End Namespace
