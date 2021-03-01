Imports System.Data
Imports COH.CodeManagement.Enums.Databases

Namespace Storage.DataBases
    Partial Public MustInherit Class GameDatabases_Accounts
        Inherits GameDatabase_Generic

#Region "Create New Instance"
        Public Overrides ReadOnly Property DataBase_Name As String
            Get
                Return "GameDatabase_Accounts"
            End Get
        End Property
        '// TablesUsed As [Enum] = GDEnum_AccountTables
#End Region

#Region "Create Table"
        Protected Overrides Function CreateTables(IncludeRealtionships As Boolean) As Boolean
            If CreateTable(GDEnum_AccountTables.Account, IncludeRealtionships) = False Then Return False
            If CreateTable(GDEnum_AccountTables.Product_Type, IncludeRealtionships) = False Then Return False
            If CreateTable(GDEnum_AccountTables.Product, IncludeRealtionships) = False Then Return False
            If CreateTable(GDEnum_AccountTables.Game_Log, IncludeRealtionships) = False Then Return False
            If CreateTable(GDEnum_AccountTables.Inventory, IncludeRealtionships) = False Then Return False
            If CreateTable(GDEnum_AccountTables.MTX_Log, IncludeRealtionships) = False Then Return False
            If CreateTable(GDEnum_AccountTables.GameTransactions, IncludeRealtionships) = False Then Return False
            Return True
        End Function
        Protected MustOverride Function CreateTable(TheTable As GDEnum_AccountTables, IncludeRealtionships As Boolean) As Boolean



#End Region
    End Class
End Namespace
