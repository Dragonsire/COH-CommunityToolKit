Imports COH.CodeManagement.Extentions
Namespace HelperFunctions.Databases.SQL
	<HideModuleName> Public Module HelperFunctions_SQL
		Public Enum SQL_Types
			INT
			VARCHAR
			SMALLINT
			BLOB
			DATETIME
		End Enum
		Public Function SQL_FormatLine_ColumnCreate(ColumnName As String, TheType As SQL_Types, Optional AllowNull As Boolean = True, Optional Length As UInt32 = 0, Optional HasDefault As Boolean = False, Optional TheDefault As String = "", Optional IsLast As Boolean = False) As String
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
		Public Function SQL_FormatLine_ColumnCreate(ColumnName As [Enum], TheType As SQL_Types, Optional AllowNull As Boolean = True, Optional Length As UInt32 = 0, Optional HasDefault As Boolean = False, Optional TheDefault As String = "", Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName.ToString, TheType, AllowNull, Length, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_Date(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Date = #01/01/2000#, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, SQL_Types.DATETIME, AllowNull, 0, HasDefault, TheDefault.ToString.SingleQuoteTheString, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_SmallInt(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, SQL_Types.SMALLINT, AllowNull, 0, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_Int(ColumnName As [Enum], Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, SQL_Types.INT, AllowNull, 0, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_VarChars(ColumnName As [Enum], Length As UInt32, Optional HasDefault As Boolean = True, Optional AllowNull As Boolean = True, Optional TheDefault As Integer = 0, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, SQL_Types.VARCHAR, AllowNull, Length, HasDefault, TheDefault, IsLast)
		End Function
		Public Function SQL_FormatLine_ColumnCreate_Blob(ColumnName As [Enum], Length As UInt32, Optional AllowNull As Boolean = True, Optional IsLast As Boolean = False) As String
			Return SQL_FormatLine_ColumnCreate(ColumnName, SQL_Types.BLOB, AllowNull, Length, False, "", IsLast)
		End Function
	End Module
End Namespace