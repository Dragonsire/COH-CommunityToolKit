Namespace CodeManagement.Enums.DataTypes
    <Flags> Public Enum Supported_CleanStringFlags
        None = 0
        Trim = 1
        Remove_NonVisibleCharacters = 2
        Remove_Spaces = 4
        Remove_DoubleSpaces = 8
        Remove_NewLines = 16
        Remove_SingleSpacedLines = 32
        Remove_DoubleSpacedLines = 64
        AllowNull = 128
        ReturnOnZero = 256
    End Enum
    Public Enum TextPermittedStyle
        Hex_8 = 0
        Hex_16 = 1
        ProperName = 2
        Numbers = 3
        PostalCode = 4
        ZipCode = 5
        SIN = 6
        FinancialNumbers = 7
        Custom = 254
        AllVisibleCharacters = 255
    End Enum
    Public Enum TextCharacterCasing
        Normal = 0
        Upper = 1
        Lower = 2
    End Enum
    Public Enum Supported_StringEncoding
        [Default] = 0
        UTF7 = 1
        UTF8 = 2
        UTF16 = 3
        UTF16_BigEndian = 4
        UTF32 = 5
        ASCII = 6
        UTF16_Fixed2Bytes = 7
        CP1252 = 8
    End Enum
    Public Enum Supported_BinaryByteOrder
        LittleEndian = 0
        BigEndian = 1
        [Default] = 254
        ShowAll = 255
    End Enum
End Namespace