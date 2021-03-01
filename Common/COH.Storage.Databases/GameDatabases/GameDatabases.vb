Imports COH.CodeManagement.Enums.Databases
Imports COH.CodeManagement.Interfaces.Databases

Namespace Storage.DataBases
    Public MustInherit Class GameDatabase_Generic

#Region "Properties"
        Public MustOverride ReadOnly Property DataBase_Name As String
        'Friend ReadOnly Property DataSet As Data.DataSet 'IN MEMORY
        'get
        'Return pDatabase
        'End Get
        'End Property
        'Private pDatabase As Data.DataSet
#End Region

        Protected MustOverride Function CreateTables(IncludeRealtionships As Boolean) As Boolean

    End Class
End Namespace