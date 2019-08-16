Imports COH.GameContent.Internal.Structures
Imports COH.GameContent.Structures
Imports COH.GameContent.Structures.COH_Struct
Imports COH.GameContent.Utilities

Namespace Interfaces
    Public Interface ISupport_MasterController
        Function Retrieve_ModableContent(ContentType As COH_ProjectContent) As List(Of Interfaces.ISupport_COH_OriginolSources)
        Function Retrieve_ModableContent(ByRef Search As String, ContentType As COH_ProjectContent) As Interfaces.ISupport_COH_OriginolSources
        Function Retrieve_Structs(ContentType As COH_ProjectContent) As List(Of COH_Struct)
        Function RetrieveStruct(ByRef Search As String, ContentType As COH_ProjectContent, SelectedFormat As COH_Struct.COH_ExportFormat, ByRef Result As Structures.COH_Struct) As Boolean
        Function RetrieveStruct_FilePath(ByRef Search As String, ContentType As COH_ProjectContent, SelectedFormat As COH_Struct.COH_ExportFormat) As String
        Function Retrieve_Content_FromFileName_NoPath(ContentType As COH_ProjectContent, RelativePath As String, SelectedFormat As COH_Struct.COH_ExportFormat, ByRef Result As COH_Struct) As Boolean
        Function Retrieve_Content_FromFileName_RelativePath(ContentType As COH_ProjectContent, RelativePath As String, SelectedFormat As COH_Struct.COH_ExportFormat, ByRef Result As COH_Struct) As Boolean
        Function Retrieve_Content_FromFileName(TheType As Type, FilePath As String, SelectedFormat As COH_Struct.COH_ExportFormat, ByRef Result As COH_Struct) As Boolean
        Function Retrieve_AllContent_FromFileNames_RelativePath(ContentType As COH_ProjectContent, SelectedFormat As COH_Struct.COH_ExportFormat) As List(Of COH_Struct)
        ReadOnly Property TheController_Assets As ISupport_COH_AssetRetrieval
        ReadOnly Property TheController_Localize As ISupport_COH_LocalizeContent
        ReadOnly Property TheController_SupportedStructures As COH_FileStructureIndex_Controller
        ReadOnly Property CurrentProjectFile As ProjectFiles.COH_ProjectFile
    End Interface
    Public Interface ISupport_COH_DisplayName
        ReadOnly Property InternalDisplayName As String
    End Interface
    Public Interface ISupport_COH_OriginolSources
        Property FullName As String
        Property IsCustom As Boolean
        Property WasModified_FromSource As Boolean
        Property RelativePath_Current As String
        Property RelativePath_Originol As String
        Property Content As COH_Struct
        Sub Initialize_DefaultRelativePath()
    End Interface
    Public Interface ISupport_COH_LocalizeContent
        Function CreateKey(ByRef Value As String) As String
        Function CreateKey(ByRef Value As String, MessageStoreName As String) As String
        Function RetrieveLocalizedString(ByRef Search As String) As String
    End Interface
    Public Interface ISupport_COH_Localized
        Sub UpdateLocalizations(ByRef LocalizeController As ISupport_COH_LocalizeContent)
    End Interface
    Public Interface ISupport_COH_AssetRetrieval
        Function RetrieveAsset_ImageStruct(FilePath As String) As COH_Struct
        Function RetrieveAsset(ByRef Search As String) As Structures.COH_Struct
        Function RetrieveAsset(ByRef Search As String, Type As COH_Supported_ContentType)
        Function RetrieveAsset_FilePath(ByRef Search As String, Optional TheType As COH_Supported_ContentType = COH_Supported_ContentType.Unknown) As String
    End Interface
    Public Interface ISupport_COH_Struct
        Inherits ISupport_COH_Localized, ISupport_COH_Export, ISupport_COH_Import
        Function Export_To_MemoryStream(Optional Version As Integer = 0, Optional Format As COH_StreamFormat = COH_StreamFormat.Unspecified, Optional BuildType As COH_BuildType = COH_BuildType.Either) As IO.MemoryStream
        Function Export_To_File(Format As COH_StreamFormat, Folder As String, Optional FileName As String = Nothing, Optional Version As Integer = 0, Optional BuildType As COH_BuildType = COH_BuildType.Either) As Boolean
        Function Export_To_TextFormat(ByRef Result As String, Optional Version As Integer = 0, Optional Format As COH_TextFormat = COH_TextFormat.XML, Optional BuildType As COH_BuildType = COH_BuildType.Either) As Boolean
        Property FilePathReference_Current As String
        Function Determine_DefaultRelativeFilePath(Format As COH_StreamFormat) As String
    End Interface
    Public Interface ISupport_COH_Export
        Function Export_To_Stream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
    End Interface
    Public Interface ISupport_COH_Import
        Function Import_From_Stream(ByRef CurrentReader As COH_BinaryReader) As Boolean
    End Interface
    Public Interface ISupport_COH_ExportToDEF
        Function Export_To_Def() As String
    End Interface
End Namespace