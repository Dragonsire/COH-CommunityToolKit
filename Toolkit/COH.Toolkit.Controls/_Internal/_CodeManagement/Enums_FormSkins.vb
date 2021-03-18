Namespace CodeManagement.Enums.Toolkit
    Public Enum FormRegions
        None
        TitleBar
        Button_Min
        Button_Max
        Button_Close
        Button_Help
        Icon
        Edge_Left
        Edge_Right
        Edge_Bottom
        Corner_TopLeft
        Corner_TopRight
        Corner_BottomLeft
        Corner_BottomRight
    End Enum
    Public Enum CurrentImageState
        None = 0
        Normal
        Hilited
        Pressed
        Disabled
    End Enum
    <Flags> Public Enum FormRegions_DrawSections
        None = 0
        Window
        TitleBar
        DialogButtons
        All = Int32.MaxValue
    End Enum
    Public Enum FormRegions_ImageScaling
        MaintainOriginalSize = 0
        FitToRectangle = 1
        ClipToRectangle = 2
        FillRectangle = 3
        TiledDown = 4
        TiledAcross = 5
        ShowAll = Integer.MaxValue
    End Enum
End Namespace