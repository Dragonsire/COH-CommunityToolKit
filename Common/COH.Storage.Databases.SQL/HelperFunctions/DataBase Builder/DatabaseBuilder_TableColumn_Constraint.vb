Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class DatabaseBuilder_DatabaseTableConstraint

#Region "Properties"
        Public Property Name As String
        Public Property Key As String
#End Region

#Region "Create New Instance"
        Public Sub New(ConstraintName As String, ConstraintKey As String)
            Name = ConstraintName
            Key = ConstraintKey
        End Sub
#End Region

#Region "Export"
        Public Function Export_CommandString_Create() As String
            Return (Chr(9) & "CONSTRAINT " & Name.ToString.QuoteTheString) & " PRIMARY KEY(" & Key.ToString.QuoteTheString & ")"
        End Function
#End Region

    End Class
End Namespace
