Namespace CodeManagement.Enums.Pigg
    Public Enum PIGG_Container_SlotTypes As Byte
        Unknown = 0
        DDS_Header = 1
        GEO = 2
    End Enum
    Public Enum PIGG_EventTypes
        None = 0
        BeginExtract_Multiple
        BeginExtract_Single
        FinishExtract_Multiple
        FinishExtract_Single
        Update
    End Enum
End Namespace