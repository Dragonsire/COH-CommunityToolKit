Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class DatabaseBuilder_DatabaseTableColumn

#Region "Properties"
        Public Property ColumnName As String
        Public Property ColumnType As String
        Public Property Length As Integer
        Public Property AllowNull As Boolean
        Public Property HasDefault As Boolean
        Public Property DefaultValue As String
#End Region

#Region "Create New Instance"
        Public Sub New(Name As String, TheType As String, Optional Allow_Null As Boolean = True, Optional TypeLength As UInt32 = 0, Optional Has_Default As Boolean = False, Optional TheDefault As String = "")
            ColumnName = Name
            ColumnType = TheType
            AllowNull = Allow_Null
            Length = TypeLength
            HasDefault = Has_Default
            DefaultValue = TheDefault
        End Sub
#End Region

#Region "Export"
        Public Function Export_CommandString_Create() As String
            Dim SB As New Text.StringBuilder
            SB.Append(Chr(9) & ColumnName.ToString.BracketTheString)
            SB.Append(" " & ColumnType.ToString.BracketTheString)
            If Length > 0 Then SB.Append("(" & Length & ")")
            If AllowNull = True Then
                SB.Append(" NULL")
            Else
                SB.Append(" NOT NULL")
            End If
            If HasDefault = True Then SB.Append(" DEFAULT " & DefaultValue)
            Return SB.ToString
        End Function
#End Region

    End Class
End Namespace
