Namespace CodeManagement.Enums.Databases.SQL
    Public Enum DatabaseOption_OnOffEnum
        [ON]
        OFF
    End Enum
    Public Enum DatabaseOption_CursorEnum
        [Global]
        [Local]
    End Enum
    Public Enum DatabaseOption_ParamEnum
        Forced
        Simple
    End Enum
    Public Enum DatabaseOption_PageVerifyEnum
        CHECKSUM
        TORN_PAGE_DETECTION
        NONE
    End Enum
    Public Enum DatabaseOption_AccessEnum
        MULTI_USER
        SINGLE_USER
        RESTRICTED_USER
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
        CONCAT_NULL_YIELDS_NULL
        NUMERIC_ROUNDABORT
        QUOTED_IDENTIFIER
        RECURSIVE_TRIGGERS
        DISABLE_BROKER
        AUTO_UPDATE_STATISTICS_ASYNC
        DATE_CORRELATION_OPTIMIZATION
        TRUSTWORTHY
        ALLOW_SNAPSHOT_ISOLATION
        READ_COMMITTED_SNAPSHOT
        HONOR_BROKER_PRIORITY
        'MULTI_USER
        DB_CHAINING
        'READ_WRITE
        ''//
        'CURSOR_DEFAULT '  Global 
        'PARAMETERIZATION ' SIMPLE 
        'RECOVERY ' FULL 
        'PAGE_VERIFY ' CHECKSUM  
    End Enum
End Namespace