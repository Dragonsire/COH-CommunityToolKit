Imports System.Reflection
Imports COH.CodeManagement.Extentions

Namespace HelperFunctions.Databases.SQL
    Public Class DatabaseBuilder_DatabaseOptions

#Region "Properties"
        Public Property ANSI_NULL_DEFAULT As DatabaseOption_OnOffEnum
        Public Property ANSI_NULLS As DatabaseOption_OnOffEnum
        Public Property ANSI_PADDING As DatabaseOption_OnOffEnum
        Public Property ANSI_WARNINGS As DatabaseOption_OnOffEnum
        Public Property ARITHABORT As DatabaseOption_OnOffEnum
        Public Property AUTO_CLOSE As DatabaseOption_OnOffEnum
        Public Property AUTO_SHRINK As DatabaseOption_OnOffEnum
        Public Property AUTO_UPDATE_STATISTICS As DatabaseOption_OnOffEnum
        Public Property CURSOR_CLOSE_ON_COMMIT As DatabaseOption_OnOffEnum
        Public Property CURSOR_DEFAULT As String ' Global 
        Public Property CONCAT_NULL_YIELDS_NULL As DatabaseOption_OnOffEnum
        Public Property NUMERIC_ROUNDABORT As DatabaseOption_OnOffEnum
        Public Property QUOTED_IDENTIFIER As DatabaseOption_OnOffEnum
        Public Property RECURSIVE_TRIGGERS As DatabaseOption_OnOffEnum
        Public Property DISABLE_BROKER As DatabaseOption_OnOffEnum
        Public Property AUTO_UPDATE_STATISTICS_ASYNC As DatabaseOption_OnOffEnum
        Public Property DATE_CORRELATION_OPTIMIZATION As DatabaseOption_OnOffEnum
        Public Property TRUSTWORTHY As DatabaseOption_OnOffEnum
        Public Property ALLOW_SNAPSHOT_ISOLATION As DatabaseOption_OnOffEnum
        Public Property PARAMETERIZATION As String 'SIMPLE 
        Public Property READ_COMMITTED_SNAPSHOT As DatabaseOption_OnOffEnum
        Public Property HONOR_BROKER_PRIORITY As DatabaseOption_OnOffEnum
        Public Property RECOVERY As String ' FULL
        Public Property MULTI_USER As DatabaseOption_OnOffEnum
        Public Property PAGE_VERIFY As String 'CHECKSUM   
        Public Property DB_CHAINING As DatabaseOption_OnOffEnum
        Public Property READ_WRITE As DatabaseOption_OnOffEnum
        Public Enum DatabaseOption_OnOffEnum
            [ON]
            OFF
        End Enum
        Public Enum DataBaseOptionsEnum
            ANSI_NULL_DEFAULT
            ANSI_NULLS
            ANSI_PADDING
            ANSI_WARNINGS
            ARITHABORT
            AUTO_CLOSE
            AUTO_SHRINK
            AUTO_UPDATE_STATISTICS
            CURSOR_CLOSE_ON_COMMIT
            CURSOR_DEFAULT '  Global 
            CONCAT_NULL_YIELDS_NULL
            NUMERIC_ROUNDABORT
            QUOTED_IDENTIFIER
            RECURSIVE_TRIGGERS
            DISABLE_BROKER
            AUTO_UPDATE_STATISTICS_ASYNC
            DATE_CORRELATION_OPTIMIZATION
            TRUSTWORTHY
            ALLOW_SNAPSHOT_ISOLATION
            PARAMETERIZATION ' SIMPLE 
            READ_COMMITTED_SNAPSHOT
            HONOR_BROKER_PRIORITY
            RECOVERY ' FULL 
            MULTI_USER
            PAGE_VERIFY ' CHECKSUM  
            DB_CHAINING
            READ_WRITE
        End Enum
#End Region

#Region "Create New Instance"
        Public Sub New()
        End Sub
#End Region

#Region "Export"
        Public Function Export_CommandString_Options(DatabaseName As String) As String
            ''//ALTER DATABASE [cohacc] SET ANSI_NULL_DEFAULT OFF 
            Dim SB As New Text.StringBuilder
            SB.Append("ALTER DATABASE " & DatabaseName.BracketTheString & " SET ANSI_NULL_DEFAULT " & ANSI_NULL_DEFAULT.ToString)
            SB.Append("ALTER DATABASE " & DatabaseName.BracketTheString & " SET ANSI_NULLS " & ANSI_NULLS.ToString)
            Return SB.ToString
        End Function
        Public Shared Function SetPropertyValueByName(obj As [Object], name As String, value As [Object]) As Boolean
            Dim prop = obj.[GetType]().GetProperty(name, BindingFlags.[Public] Or BindingFlags.Instance)
            If prop Is Nothing OrElse Not prop.CanWrite Then Return False
            prop.SetValue(obj, value, Nothing)
            Return True
        End Function
        Public Shared Function GetPropertyValueByName(obj As [Object], name As String, ByRef value As [Object]) As Boolean
            Dim prop = obj.[GetType]().GetProperty(name, BindingFlags.[Public] Or BindingFlags.Instance)
            If prop Is Nothing OrElse Not prop.CanRead Then Return False
            value = prop.GetValue(obj)
            Return (value IsNot Nothing)
        End Function
#End Region

    End Class
End Namespace
