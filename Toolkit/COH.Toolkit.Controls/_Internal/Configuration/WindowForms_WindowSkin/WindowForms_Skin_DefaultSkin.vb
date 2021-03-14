Imports System.Drawing
Imports DS._CoreLibrary_.v6.FileStructures.BitsANDBytes
Imports DS._CoreLibrary_.v6.Utilities.ControlRegions

Namespace Controls.WinForms._WindowForms_
    Partial Public NotInheritable Class WindowFormsConfiguration_Skin

        Public Shared Function DefineTheme_DEFAULT() As WindowFormsConfiguration_Skin
            Dim LoadedSkin As New WindowFormsConfiguration_Skin
            With LoadedSkin
                '//SET To DEFAULT EMPTY STATES
                .pWindowSkin_Edge_Left = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Left.ToString, True, True, False)
                .pWindowSkin_Edge_Right = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Right.ToString, True, True, False)
                .pWindowSkin_Edge_Bottom = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Bottom.ToString, True, True, False)
                .pWindowSkin_Corner_BottomLeft = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_BottomLeft.ToString, True, True, False)
                .pWindowSkin_Corner_BottomRight = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_BottomRight.ToString, True, True, False)
                .pWindowSkin_Corner_TopLeft = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_TopLeft.ToString, True, True, False)
                .pWindowSkin_Corner_TopRight = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_TopRight.ToString, True, True, False)
                .pWindowSkin_TitleBar = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.TitleBar.ToString, True, True, True)
                .pWindowSkin_Button_Icon = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Icon.ToString, True, True, True)
                .pWindowSkin_Button_Max = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Maximize.ToString, True, True, True)
                .pWindowSkin_Button_Min = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Minimize.ToString, True, True, True)
                .pWindowSkin_Button_Close = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Close.ToString, True, True, True)
                .pWindowSkin_Button_Help = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Help.ToString, True, False, True)
                .pWindowSkin_Button_Special = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Special.ToString, True, False, True)
                .pWindowSkin_DialogButtons = New WindowFormsConfiguration_Skin_DialogButtons

                '//DIALOGS ADDED
                .pWindowSkin_DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.None
                .WindowSkin_Dialog_Bar = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.DialogBar.ToString, True, False, False)
                .WindowSkin_Editor_Bar = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.EditorBar.ToString, True, False, False)
                .pWindowSkin_DialogButtons.WindowSkin_DialogButtons = New Wrapped_XML_Dictionary(Of ControlRegion_ImageStates)

                '//UPDATE APPEARANCES
                .pWindowSkin_Edge_Left.Update_Image(ControlRegion_ImageScaling.TiledDown, Internal.Resources.ControlSkins_FormOverlay_EdgeLeft)
                .pWindowSkin_Edge_Right.Update_Image(ControlRegion_ImageScaling.TiledDown, Internal.Resources.ControlSkins_FormOverlay_EdgeRight)
                .pWindowSkin_Edge_Bottom.Update_Image(ControlRegion_ImageScaling.TiledAcross, Internal.Resources.ControlSkins_FormOverlay_EdgeBottom)
                .pWindowSkin_Corner_BottomLeft.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Internal.Resources.ControlSkins_FormOverlay_BottomCorner_Left)
                .pWindowSkin_Corner_BottomRight.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Internal.Resources.ControlSkins_FormOverlay_BottomCorner_Right)
                .pWindowSkin_Corner_TopLeft.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Internal.Resources.ControlSkins_FormOverlay_Left)
                .pWindowSkin_Corner_TopRight.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Internal.Resources.ControlSkins_FormOverlay_Right)
                .pWindowSkin_TitleBar.Update_Image(ControlRegion_ImageScaling.TiledAcross, Internal.Resources.ControlSkins_FormOverlay_Middle)
                .pWindowSkin_Button_Icon.Update_Layer_Background(Internal.Resources.ControlSkin_Icon.ToString)
                .pWindowSkin_Button_Max.Update_Layer_Background(Internal.Resources.ControlSkins_FormOverlay_ButtonMiddle.ToString)
                .pWindowSkin_Button_Min.Update_Layer_Background(Internal.Resources.ControlSkins_FormOverlay_ButtonLeft.ToString)
                .pWindowSkin_Button_Close.Update_Layer_Background(Internal.Resources.ControlSkins_FormOverlay_ButtonRight.ToString)
                .pWindowSkin_Button_Help.Update_Layer_Background("None")
                .pWindowSkin_Button_Special.Update_Layer_Background("None")
                '//UPDATE APPEARANCES DIALOG BUTTONS
                .WindowSkin_Dialog_Bar.Update_Image(ControlRegion_ImageScaling.TiledAcross, Nothing)
                .WindowSkin_Editor_Bar.Update_Image(ControlRegion_ImageScaling.TiledDown, Nothing)
            End With
            Return LoadedSkin
        End Function
        Public Shared Function DefineTheme_FromFolder(Folder As String) As WindowFormsConfiguration_Skin
            If IO.File.Exists(IO.Path.Combine(Folder, "Close.png")) = True Then Return DefineTheme_FromFolder(Folder, Imaging.ImageFormat.Png)
            If IO.File.Exists(IO.Path.Combine(Folder, "Close.bmp")) = True Then Return DefineTheme_FromFolder(Folder, Imaging.ImageFormat.Bmp)
            Return Nothing
        End Function
        Public Shared Function DefineTheme_FromFolder(Folder As String, Format As Imaging.ImageFormat) As WindowFormsConfiguration_Skin
            Dim LoadedSkin As New WindowFormsConfiguration_Skin
            With LoadedSkin
                .pWindowSkin_Edge_Left.Update_Image(ControlRegion_ImageScaling.TiledDown, Retrieve_SkinImage(Folder, .pWindowSkin_Edge_Left.UniqueKey, Format))
                .pWindowSkin_Edge_Right.Update_Image(ControlRegion_ImageScaling.TiledDown, Retrieve_SkinImage(Folder, .pWindowSkin_Edge_Right.UniqueKey, Format))
                .pWindowSkin_Edge_Bottom.Update_Image(ControlRegion_ImageScaling.TiledAcross, Retrieve_SkinImage(Folder, .pWindowSkin_Edge_Bottom.UniqueKey, Format))
                .pWindowSkin_Corner_BottomLeft.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Retrieve_SkinImage(Folder, .pWindowSkin_Corner_BottomLeft.UniqueKey, Format))
                .pWindowSkin_Corner_BottomRight.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Retrieve_SkinImage(Folder, .pWindowSkin_Corner_BottomRight.UniqueKey, Format))
                .pWindowSkin_Corner_TopLeft.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Retrieve_SkinImage(Folder, .pWindowSkin_Corner_TopLeft.UniqueKey, Format))
                .pWindowSkin_Corner_TopRight.Update_Image(ControlRegion_ImageScaling.MaintainOriginalSize, Retrieve_SkinImage(Folder, .pWindowSkin_Corner_TopRight.UniqueKey, Format))
                .pWindowSkin_TitleBar.Update_Image(ControlRegion_ImageScaling.TiledAcross, Retrieve_SkinImage(Folder, .pWindowSkin_TitleBar.UniqueKey, Format))
                .WindowSkin_Dialog_Bar.Update_Image(ControlRegion_ImageScaling.TiledAcross, Retrieve_SkinImage(Folder, .WindowSkin_Dialog_Bar.UniqueKey, Format))
                .WindowSkin_Editor_Bar.Update_Image(ControlRegion_ImageScaling.TiledDown, Retrieve_SkinImage(Folder, .WindowSkin_Editor_Bar.UniqueKey, Format))

                .pWindowSkin_Button_Icon.Update_Layer_Background(Retrieve_SkinImages(Folder, WindowForms_WindowSkin_FormRegions.Icon.ToString, Format))
                .pWindowSkin_Button_Max.Update_Layer_Background(Retrieve_SkinImages(Folder, WindowForms_WindowSkin_FormRegions.Maximize.ToString, Format))
                .pWindowSkin_Button_Min.Update_Layer_Background(Retrieve_SkinImages(Folder, WindowForms_WindowSkin_FormRegions.Minimize.ToString, Format))
                .pWindowSkin_Button_Close.Update_Layer_Background(Retrieve_SkinImages(Folder, WindowForms_WindowSkin_FormRegions.Close.ToString, Format))
                .pWindowSkin_Button_Help.Update_Layer_Background(Retrieve_SkinImages(Folder, WindowForms_WindowSkin_FormRegions.Help.ToString, Format))
                .pWindowSkin_Button_Help.Visible = Not (.pWindowSkin_Button_Help.Layer_Background.ImageState_Normal Is Nothing)
                .pWindowSkin_Button_Special.Update_Layer_Background(Retrieve_SkinImages(Folder, WindowForms_WindowSkin_FormRegions.Special.ToString, Format))
                .pWindowSkin_Button_Special.Visible = Not (.pWindowSkin_Button_Special.Layer_Background.ImageState_Normal Is Nothing)

                .pWindowSkin_DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.None
                .pWindowSkin_DialogButtons.WindowSkin_DialogButtons = New Wrapped_XML_Dictionary(Of ControlRegion_ImageStates)
            End With
            Return LoadedSkin
        End Function
        Private Shared Function Retrieve_SkinImages(Folder As String, Key As String, Format As Imaging.ImageFormat) As Image()
            Return ResourceLoaderEntry_ImageStates_Folder.Retrieve_Images_FromFolder(Folder, Key, Format)
        End Function
        Private Shared Function Retrieve_SkinImage(Folder As String, Key As String, Format As Imaging.ImageFormat, Optional Tag As String = "") As Image
            Dim FileExt As String = HelperFunctions.Imaging.RetrieveFileExtention_ForFormat(Format)
            If String.IsNullOrEmpty(Tag) = False Then Key = (Key & Tag)
            Dim FilePath As String = IO.Path.Combine(Folder, Key & FileExt)
            If IO.File.Exists(FilePath) = False Then Return Nothing
            Return HelperFunctions.Imaging.SafeLoadImage_FromFile(FilePath)
        End Function
        Private Shared Function Retrieve_SkinFileName(Folder As String, Key As String, Format As Imaging.ImageFormat) As String
            Dim FileExt As String = HelperFunctions.Imaging.RetrieveFileExtention_ForFormat(Format)
            Dim FilePath As String = IO.Path.Combine(Folder, Key & FileExt)
            If IO.File.Exists(FilePath) = False Then Return String.Empty
            Return FilePath
        End Function
        Public Shared Sub Save_SkinImages_ToFolder(ByRef SelectectedSkin As WindowFormsConfiguration_Skin, Folder As String, Format As Imaging.ImageFormat)
            Dim Regions As New List(Of ControlRegion)
            SelectectedSkin.Handle_OnRequest_ReturnRegions(Regions)
            For Each Item In Regions
                If TypeOf (Item) Is ControlRegion_Image_WithGrey Then
                    Save_SkinImages_ToFolder_ImageWithGrey(Item, Folder, Format)
                Else
                    Save_SkinImages_ToFolder_ImageStates(Item, Folder, Format)
                End If
            Next
        End Sub
        Public Shared Sub Save_SkinImages_ToFolder_ImageWithGrey(ByRef Selected As ControlRegion_Image_WithGrey, Folder As String, Format As Imaging.ImageFormat)
            Dim FileExt As String = HelperFunctions.Imaging.RetrieveFileExtention_ForFormat(Format)
            If Not (Selected.LoadedImage Is Nothing) Then
                Dim FilePath As String = IO.Path.Combine(Folder, Selected.UniqueKey.ToString & FileExt)
                If IO.File.Exists(FilePath) = True Then IO.File.Delete(FilePath)
                Selected.LoadedImage.Save(FilePath, Format)
            End If
            If Not (Selected.Image_GreyScale Is Nothing) Then
                Dim FilePath As String = IO.Path.Combine(Folder, Selected.UniqueKey.ToString & "_Disabled" & FileExt)
                If IO.File.Exists(FilePath) = True Then IO.File.Delete(FilePath)
                Selected.Image_GreyScale.Save(FilePath, Format)
            End If
        End Sub
        Public Shared Sub Save_SkinImages_ToFolder_ImageStates(ByRef Selected As ControlRegion_ImageStates, Folder As String, Format As Imaging.ImageFormat)
            Dim FileExt As String = HelperFunctions.Imaging.RetrieveFileExtention_ForFormat(Format)
            If Not (Selected.Layer_Background.ImageState_Normal Is Nothing) Then
                Dim FilePath As String = IO.Path.Combine(Folder, Selected.UniqueKey.ToString & FileExt)
                If IO.File.Exists(FilePath) = True Then IO.File.Delete(FilePath)
                Selected.Layer_Background.ImageState_Normal.Save(FilePath, Format)
            End If
            If Not (Selected.Layer_Background.ImageState_Disabled Is Nothing) Then
                Dim FilePath As String = IO.Path.Combine(Folder, Selected.UniqueKey.ToString & "_Disabled" & FileExt)
                If IO.File.Exists(FilePath) = True Then IO.File.Delete(FilePath)
                Selected.Layer_Background.ImageState_Disabled.Save(FilePath, Format)
            End If
            If Not (Selected.Layer_Background.ImageState_Hilited Is Nothing) Then
                Dim FilePath As String = IO.Path.Combine(Folder, Selected.UniqueKey.ToString & "_Hilited" & FileExt)
                If IO.File.Exists(FilePath) = True Then IO.File.Delete(FilePath)
                Selected.Layer_Background.ImageState_Hilited.Save(FilePath, Format)
            End If
            If Not (Selected.Layer_Background.ImageState_Pressed Is Nothing) Then
                Dim FilePath As String = IO.Path.Combine(Folder, Selected.UniqueKey.ToString & "_Pressed" & FileExt)
                If IO.File.Exists(FilePath) = True Then IO.File.Delete(FilePath)
                Selected.Layer_Background.ImageState_Pressed.Save(FilePath, Format)
            End If
        End Sub
    End Class
End Namespace