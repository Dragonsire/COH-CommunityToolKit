Imports COH.CodeManagement.Enums.Toolkit
Imports COH.Toolkit.ControllerModules.Pathways

Namespace Toolkit.ControllerModules
    Partial Public NotInheritable Class ControllerModule_Pathways

#Region "Images"
        Public Function RetrieveExternal_Image(RootFolder As String, RelativePath As String) As Drawing.Image
            Dim CompleteFilePath As String = IO.Path.Combine(RootFolder, RelativePath)
            If IO.File.Exists(CompleteFilePath) = False Then Return Nothing
            ' Return DS._CoreLibrary_.v6.HelperFunctions.Imaging.SafeLoadImage_FromFile(CompleteFilePath)
        End Function
        Public Function RetrieveExternal_Image(CompleteFilePath As String) As Drawing.Image
            If IO.File.Exists(CompleteFilePath) = False Then Return Nothing
            ' Return DS._CoreLibrary_.v6.HelperFunctions.Imaging.SafeLoadImage_FromFile(CompleteFilePath)
        End Function
#End Region

#Region "Fonts"
        Public Sub LoadAllFonts_FromFolder(Folder As String)
            For Each File In IO.Directory.GetFiles(Folder, "*.ttf", IO.SearchOption.TopDirectoryOnly)
                pFonts.AddFontFile(File)
            Next
        End Sub
#End Region

#Region "Retrieve Resource"
        Public Function RetrieveResource_Image(Key As String) As Drawing.Image
            Dim Result As DS_PathwaysCollectionEntry = Nothing
            If pPaths.Check_Contains(Key, Result) = False Then Return Nothing
            'Dim FilePath As String = RetrievePath(Result)
            'If IO.File.Exists(FilePath) = False Then Return Nothing
            'Return DS._CoreLibrary_.v6.HelperFunctions.Imaging.SafeLoadImage_FromFile(FilePath)
        End Function
        Public Function RetrieveResource_FormSkin(Key As String) ' As WindowFormsConfiguration_Skin
            Dim Result As DS_PathwaysCollectionEntry = Nothing
            If pPaths.Check_Contains(Key, Result) = False Then Return Nothing
            If Not Result.Type = CF_Enum_PathwayType.Folder_Skin Then Return Nothing
            Return RetrieveResource_FormSkin(Result)
        End Function
        Public Function RetrieveResource_FormSkin(Entry As DS_PathwaysCollectionEntry) ' As WindowFormsConfiguration_Skin
            ' Dim FolderPath As String = RetrievePath(Entry)
            ' If IO.Directory.Exists(FolderPath) = False Then Return Nothing
            ' Dim SkinResult As WindowFormsConfiguration_Skin = WindowFormsConfiguration_Skin.DefineTheme_FromFolder(FolderPath)
            ' Return SkinResult
        End Function
        Public Function RetrieveResource_FormSkin_Default() ' As WindowFormsConfiguration_Skin
            '  Dim AllAvailable As List(Of DS_PathwaysCollectionEntry) = pPaths.RetrieveAll(CF_Enum_PathwayType.Folder_Skin)
            ' If AllAvailable.Count = 0 Then Return Nothing
            ' Return RetrieveResource_FormSkin(AllAvailable(0))
        End Function
        Public Function RetrieveResource_ImageStates_Layer(Entry As DS_PathwaysCollectionEntry, Key As String) 'As ControlRegion_ImageStates_Layer
            'Dim FolderPath As String = RetrievePath(Entry)
            'If IO.Directory.Exists(FolderPath) = False Then Return Nothing
            'Dim ImageState As ControlRegion_ImageStates_Layer = ControlRegion_ImageStates.Retrieve_ImageLayer_FromFolder(FolderPath, Key, pDefaultImageFormat)
            'Return ImageState
        End Function
        Public Function RetrieveResource_Font(Name As String, Size As Single, Style As Drawing.FontStyle) As Drawing.Font
            For Each LoadedFont In pFonts.Families
                If LoadedFont.Name = Name Then Return New Drawing.Font(LoadedFont, Size, Style)
            Next
            Return Nothing
        End Function
#End Region

    End Class
End Namespace