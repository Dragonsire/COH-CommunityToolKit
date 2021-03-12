Namespace CodeManagement.Enums.Toolkit
    Public Enum CF_Enum_PathwayType
        Folder '//Undefined
        Folder_Skin

        File  '//Undefined
        FileResource_Image
        FileResource_Font
    End Enum
    Public Enum SecurityRole
        User = 0
        RegisteredUser = 1
        Administer = 2
        Developer = 3
    End Enum
    Public Enum RootMenusEnum
        FileMenu
        PIGG
    End Enum
    Public Enum MenuEnum_FileMenu
        Quit
    End Enum
    Public Enum MenuEnum_PIGGMenu
        OpenPigg_LocateFile
        OpenPigg_Specified
        ExtractPigg_Specified
    End Enum
    Public Enum MenuEnum_PIGGMenu_OpenSpecified
        OpenPigg_Specified_UI
    End Enum
    Public Enum MenuEnum_PIGGMenu_ExtractSpecified
        ExtractPigg_Specified_UI
    End Enum
End Namespace