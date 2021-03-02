Namespace CodeManagement.Enums.Databases
    Public Enum GameDataBase_Tables
        PlayerAccount
    End Enum

    Public Enum GDEnum_AccountTables
        Account
        Product_Type
        Product
        Game_Log
        Inventory
        MTX_Log
        GameTransactions
    End Enum
    Public Enum GDEnum_Account_AccountColumn
        Auth_ID
        Auth_Name
        LoyaltyPoints_Balance
        LoyaltyPoints_Earned
        LoyaltyPoints_Spent
        Email_Lastsent
        Email_LastsentNumber
        FreeTransfer_LastRecieved
        UniqueKey
    End Enum
    Public Enum GDEnum_Account_ProductTypeColumn
        Product_TypeID ' [product_type_id] [int] Not NULL,
        Product_Name '[name] [varchar](128) NULL,
        UniqueKey
        'CONSTRAINT [PK_product_type] PRIMARY KEY CLUSTERED 
    End Enum

End Namespace