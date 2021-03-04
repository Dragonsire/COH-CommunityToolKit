﻿Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class SQL_DatabaseTable

#Region "Properties"
        Public Property TableName As String
        Public Property TableColumns As List(Of SQL_DatabaseTableColumn)
        Public Property Constraint As SQL_DatabaseTableConstraint
        Public Property Clustered As Boolean
#End Region

#Region "Create New Instance"
        Public Sub New(Name As String)
            Clustered = False
            TableName = Name
            TableColumns = New List(Of SQL_DatabaseTableColumn)
            Constraint = Nothing
        End Sub
#End Region

#Region "Table Columns"
        Public Sub AddColumn(ColumnName As [Enum], TheType As SQL_Types, Optional AllowNull As Boolean = True, Optional Length As UInt32 = 0, Optional HasDefault As Boolean = False, Optional TheDefault As String = "")
            TableColumns.Add(New SQL_DatabaseTableColumn(ColumnName.ToString, TheType.ToString, AllowNull, Length, HasDefault, TheDefault))
        End Sub
        Public Sub AddColumn_Date(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Date = #01/01/2000#)
            TableColumns.Add(New SQL_DatabaseTableColumn(ColumnName.ToString, SQL_Types.DATETIME.ToString, AllowNull, 0, HasDefault, TheDefault.ToString.SingleQuoteTheString))
        End Sub
        Public Sub AddColumn_SmallInt(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0)
            TableColumns.Add(New SQL_DatabaseTableColumn(ColumnName.ToString, SQL_Types.SMALLINT.ToString, AllowNull, 0, HasDefault, TheDefault))
        End Sub
        Public Sub AddColumn_Integer(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0)
            TableColumns.Add(New SQL_DatabaseTableColumn(ColumnName.ToString, SQL_Types.INT.ToString, AllowNull, 0, HasDefault, TheDefault))
        End Sub
        Public Sub AddColumn_VarChar(ColumnName As [Enum], Length As UInt32, Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0)
            TableColumns.Add(New SQL_DatabaseTableColumn(ColumnName.ToString, SQL_Types.VARCHAR.ToString, AllowNull, Length, HasDefault, TheDefault))
        End Sub
        Public Sub AddColumn_Blob(ColumnName As [Enum], Length As UInt32, Optional AllowNull As Boolean = True)
            TableColumns.Add(New SQL_DatabaseTableColumn(ColumnName.ToString, SQL_Types.BLOB.ToString, AllowNull, Length, False, ""))
        End Sub
#End Region

#Region "Export"
        Public Function Export_CommandString_Create() As String
            Dim SB As New Text.StringBuilder
            SB.Append("CREATE TABLE IF NOT EXISTS " & TableName.ToString.QuoteTheString & " (")
            For X = 0 To TableColumns.Count - 1
                SB.AppendLine(TableColumns(X).Export_CommandString_Create & ",")
            Next
            SB.AppendLine(Constraint.Export_CommandString_Create)
            If Clustered = False Then
                SB.Append(");")
            Else
                SB.Append(") WITHOUT ROWID;")
            End If
            Return SB.ToString
        End Function
#End Region

    End Class
End Namespace
