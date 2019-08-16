Imports COH.GameContent.Structures.COH_Struct
Imports COH.GameContent.Utilities.COH_XML_Serialization

Namespace Utilities
    Public NotInheritable Class COH_Serialization_Settings

#Region "Enums"
        Public Enum COH_CombineStructs_Option
            SeperateFiles = 0
            AllCombined = 1
            '// Combine_WhereAppropriate = 2
        End Enum
#End Region

#Region "Property Options"
        Public Property Option_Export_DontWriteEmpty As Boolean
            Get
                Return mExportOption_DontWriteEmpty
            End Get
            Set(value As Boolean)
                mExportOption_DontWriteEmpty = value
            End Set
        End Property
        Public Property Option_Export_DontWriteDefaults As Boolean
            Get
                Return mExportOption_DontWriteDefaults
            End Get
            Set(value As Boolean)
                mExportOption_DontWriteDefaults = value
            End Set
        End Property
        Public Property Option_Export_DontWriteProject As Boolean
            Get
                If mFormat = COH_TextFormat.XML Then Return mExportOption_DontWriteProject
                Return True
            End Get
            Set(value As Boolean)
                mExportOption_DontWriteProject = value
            End Set
        End Property
        Public Property Option_Export_DontWriteEnumOverrides As Boolean
            Get
                Return mExportOption_DontWriteEnumOverrides
            End Get
            Set(value As Boolean)
                mExportOption_DontWriteEnumOverrides = value
            End Set
        End Property
        Public Property Option_Export_DontWriteDebug As Boolean
            Get
                If mFormat = COH_TextFormat.XML Then Return mExportOption_DontWriteDebug
                Return False
            End Get
            Set(value As Boolean)
                mExportOption_DontWriteDebug = value
            End Set
        End Property
        Public Property Option_DateFormat As DateTimeSerializationMode
            Get
                Return mDateFormat
            End Get
            Set(value As DateTimeSerializationMode)
                mDateFormat = value
            End Set
        End Property
        Public Property Option_Version As Integer
            Get
                Return mVersion
            End Get
            Set(value As Integer)
                mVersion = value
            End Set
        End Property
        Public Property Option_Build As COH_BuildType
            Get
                Return mBuildType
            End Get
            Set(value As COH_BuildType)
                mBuildType = value
            End Set
        End Property
        Public Property Option_SelectedFormat As COH_ExportFormat
            Get
                Return mFormat
            End Get
            Set(value As COH_ExportFormat)
                mFormat = value
            End Set
        End Property
        Public Property Options_TextEncoding As Text.Encoding
            Get
                Return mTextEncoding
            End Get
            Set(value As Text.Encoding)
                mTextEncoding = value
            End Set
        End Property
        Public ReadOnly Property LocalizeController As ISupport_COH_LocalizeContent
            Get
                Return mLocalizeController
            End Get
        End Property
        Public Property Argument As String
            Get
                Return mArgument
            End Get
            Set(value As String)
                mArgument = value
            End Set
        End Property
#End Region

#Region "Private Properties"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mVersion As Integer
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mFormat As COH_TextFormat
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBuildType As COH_BuildType = COH_BuildType.Either
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mExportOption_DontWriteProject As Boolean = False
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mExportOption_DontWriteDefaults As Boolean = False
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mExportOption_DontWriteDebug As Boolean = True
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mExportOption_DontWriteEmpty As Boolean = False
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mExportOption_DontWriteEnumOverrides As Boolean = True
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDateFormat As DateTimeSerializationMode = DateTimeSerializationMode.Local
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mTextEncoding As Text.Encoding
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mLocalizeController As ISupport_COH_LocalizeContent
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mArgument As String
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(Reset_Defaults As Boolean)
            Me.New(Reset_Defaults, COH_ExportFormat.Unspecified)
        End Sub
        Public Sub New(Reset_Defaults As Boolean, Format As COH_ExportFormat)
            Me.New(Reset_Defaults, Format, Nothing)
        End Sub
        Public Sub New(Reset_Defaults As Boolean, Format As COH_ExportFormat, ByRef Localize_Controller As ISupport_COH_LocalizeContent)
            If Reset_Defaults = True Then ResetDefaults()
            mFormat = Format
            mLocalizeController = Localize_Controller
        End Sub
        Public Sub ResetDefaults()
            mDateFormat = DateTimeSerializationMode.Local
            mExportOption_DontWriteProject = False
            mExportOption_DontWriteDefaults = False
            mExportOption_DontWriteEmpty = False
            mExportOption_DontWriteDebug = True
            mBuildType = COH_BuildType.Either
            mVersion = 0
            mFormat = COH_TextFormat.XML
            mTextEncoding = Text.Encoding.UTF8
            mArgument = String.Empty
        End Sub
#End Region
    End Class
End Namespace