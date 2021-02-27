Imports COH.CodeManagement.Enums.Databases

Namespace CodeManagement.Interfaces.Databases
    Public Interface I_DatabaseSupports_DataRow
        ReadOnly Property DB_Table As DB_Tables
        Function Retrieve_Item(ColumnName As String) As Object
        Function Retrieve_Items() As Object()
    End Interface

End Namespace