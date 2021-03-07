Imports COH.CodeManagement.Extentions
Namespace HelperFunctions.Databases.SQL
	<HideModuleName> Public Module HelperFunctions_SQL

#Region "Database Functions"
		Public Function Retrieve_CommandString_CreateDatabase(Name As String, FileName As String) As String
			Dim CommandString As String = "" &
			"CREATE DATABASE " & Name.BracketTheString & "ON PRIMARY (Name= N'" & Name & "', FILENAME= N'" & FileName & "')"
			Return CommandString
		End Function
		Public Function Retrieve_CommandString_DeleteDatabase(Name As String) As String
			Dim CommandString As String = "" &
			"DROP DATABASE IF EXISTS" & Name & ")"
			Return CommandString
		End Function
#End Region

#Region "Columns"
		Public Function SQL_FormatLine_ColumnCreate(ColumnName As String, TheType As System.Data.SqlDbType, Optional AllowNull As Boolean = True, Optional Length As UInt32 = 0, Optional HasDefault As Boolean = False, Optional TheDefault As String = "", Optional IsLast As Boolean = False) As String
			Dim Result As String = Nothing
			Dim SB As New Text.StringBuilder
			SB.Append(Environment.NewLine & Chr(9) & ColumnName.ToString.BracketTheString)
			SB.Append(" " & TheType.ToString.BracketTheString)
			If Length > 0 Then SB.Append("(" & Length & ")")
			If AllowNull = True Then
				SB.Append(" NULL")
			Else
				SB.Append(" NOT NULL")
			End If
			If HasDefault = True Then SB.Append(" DEFAULT " & TheDefault)
			If IsLast = False Then SB.Append(",")
			Return SB.ToString
		End Function
		Public Function SQL_FormatLine_ColumnCreate(ColumnName As [Enum], TheType As System.Data.SqlDbType, Optional AllowNull As Boolean = True, Optional Length As UInt32 = 0, Optional HasDefault As Boolean = False, Optional TheDefault As String = "", Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName.ToString, TheType, AllowNull, Length, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_Date(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Date = #01/01/2000#, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, System.Data.SqlDbType.DateTime, AllowNull, 0, HasDefault, TheDefault.ToString.SingleQuoteTheString, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_SmallInt(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, System.Data.SqlDbType.SmallInt, AllowNull, 0, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_Int(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, System.Data.SqlDbType.Int, AllowNull, 0, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_VarChars(ColumnName As [Enum], Length As UInt32, Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, System.Data.SqlDbType.VarChar, AllowNull, Length, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_Blob(ColumnName As [Enum], Length As UInt32, Optional AllowNull As Boolean = True, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, System.Data.SqlDbType.Binary, AllowNull, Length, False, "", IsLast)
		End Function
#End Region

#Region "Formatting"
		Public Function FormatLine() As String
			Return (Environment.NewLine & Chr(9))
		End Function
		Public Function FormatLine_ColumnName(TheV As [Enum]) As String
			Return (Environment.NewLine & Chr(9) & TheV.ToString.QuoteTheString)
		End Function
		Public Function FormatLine_EndTable(Clustered As Boolean) As String
			If Clustered = False Then
				Return (Environment.NewLine & ");")
			Else
				Return (Environment.NewLine & ") WITHOUT ROWID;")
			End If
		End Function
		Public Function FormatLine_Constraint(Name As [Enum], Key As [Enum]) As String
			Return (Environment.NewLine & Chr(9) & "CONSTRAINT " & Name.ToString.QuoteTheString) & " PRIMARY KEY(" & Key.ToString.QuoteTheString & ")"
		End Function
#End Region
	End Module
End Namespace