Imports System.Xml.Serialization
Imports COH.GameContent.Utilities

Namespace Structures
    <Serializable()> <TypeConverter(GetType(COH_Struct_ExpandableObjectCoverter))> Public MustInherit Class COH_Struct
        Implements ISupport_COH_DisplayName, ICloneable, INotifyPropertyChanged

#Region "Enums"
        Public Enum COH_BuildType
            Either = 0
            ClientOnly = 1
            ServerOnly = 2
        End Enum
        Public Enum COH_TextFormat
            XML = 0
            CrypticS_TextFormat = 1
        End Enum
        Public Enum COH_ContentSource
            Vol1_i24 = 0
            Vol1_i25_Score = 1
        End Enum
        Public Enum COH_StreamFormat
            CrypticS_BINFormat = 2
            Binary = 3
            Unspecified = 255
        End Enum
        Public Enum COH_ExportFormat
            XML = 0
            CrypticS_TextFormat = 1
            CrypticS_BINFormat = 2
            Binary = 3
            Unspecified = 255
        End Enum
#End Region

#Region "Properties - Project Handling"
        <Browsable(False)> MustOverride ReadOnly Property InternalDisplayName As String Implements ISupport_COH_DisplayName.InternalDisplayName
        <XmlAttribute> <Category("_ProjectFile")> Property Build As COH_BuildType
            Get
                Return mBuild
            End Get
            Set(value As COH_BuildType)
                mBuild = value
            End Set
        End Property
        <XmlAttribute> <Category("_ProjectFile")> Property BinVersion As COH_Supported_CrypticS_ParseVersion
            Get
                Return mBinVersion
            End Get
            Set(value As COH_Supported_CrypticS_ParseVersion)
                mBinVersion = value
            End Set
        End Property
#End Region

#Region "Private Properties"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mValid As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBuild As COH_BuildType
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBinVersion As COH_Supported_CrypticS_ParseVersion
#End Region

#Region "Create New Instances"
        Public Sub New()
            Me.New(True)
            mValid = True
        End Sub
        Public Sub New(SetDefaults As Boolean, Optional Version As Integer = 0, Optional BuildType As COH_BuildType = COH_BuildType.Either)
            If SetDefaults = True Then ResetDefaults(Version)
            mValid = True
            mBuild = BuildType
            mBinVersion = Version
        End Sub
        Public Sub New(ByRef Buffer As Byte(), Optional Settings As COH_Serialization_Settings = Nothing)
            If Settings Is Nothing Then Settings = New COH_Serialization_Settings(True, COH_ExportFormat.Unspecified)
            ResetDefaults(Settings.Option_Version)
            mValid = Import_From_Buffer(Buffer, Settings)
            Update_FromSettings(Settings)
        End Sub
        Public Sub New(ByRef Stream As IO.MemoryStream, Optional Settings As COH_Serialization_Settings = Nothing)
            If Settings Is Nothing Then Settings = New COH_Serialization_Settings(True, COH_ExportFormat.Unspecified)
            ResetDefaults(Settings.Option_Version)
            mValid = Import_From_MemoryStream(Stream, Settings)
            Update_FromSettings(Settings)
        End Sub
        Public Sub New(ByRef CurrentReader As COH_BinaryReader)
            If CurrentReader.Settings Is Nothing Then CurrentReader.Settings = New COH_Serialization_Settings(True, COH_ExportFormat.Unspecified)
            ResetDefaults(CurrentReader.Settings.Option_Version)
            mValid = Import_From_Stream(CurrentReader)
            Update_FromSettings(CurrentReader.Settings)
        End Sub
        Public Sub Update_FromSettings(ByRef Settings As COH_Serialization_Settings)
            mBinVersion = Settings.Option_Version
            mBuild = Settings.Option_Build
        End Sub
#End Region

#Region "Property Changed"
        Public Event WasModified As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Function SetValue(Of T)(ByRef backingField As T, ByVal value As T, <Runtime.CompilerServices.CallerMemberName> ByVal Optional PropertyName As String = "") As Boolean
            If Object.Equals(backingField, value) Then
                Return False
            End If
            backingField = value
            UpdateModified(PropertyName)
            OnModified()
            Return True
        End Function
        Protected Sub UpdateModified(Optional PropertyName As String = "")
            RaiseEvent WasModified(Me, New PropertyChangedEventArgs(PropertyName))
        End Sub
        Protected Overridable Sub OnModified()
        End Sub
#End Region

#Region "ProjectRelated"
        Public Overridable Function EntryType() As COH_Supported_ContentType
            Return COH_Supported_ContentType.GameContent_Struct
        End Function
        Public Overridable Function Default_CrypricSExtention() As String
            Return "DEF"
        End Function
        Public Overridable Function Default_BinaryExtention() As String
            Return "RAW"
        End Function
        Public Overridable Function Retrieve_OriginolSourceReference() As String
            Return ""
        End Function
        Public Overridable Function Retrieve_LookupName() As String
            Return InternalDisplayName
        End Function
        Public Function CurrentInstance_Valid() As Boolean
            Return mValid
        End Function
#End Region

#Region "Initialize"
        Public Overridable Sub ResetDefaults(Optional Version As Integer = 0)
            mBuild = COH_BuildType.Either
            mBinVersion = COH_Supported_CrypticS_ParseVersion.Parse6
        End Sub
        Public Overrides Function ToString() As String
            Return InternalDisplayName
        End Function
        Public Sub ForceNotValid()
            mValid = False
        End Sub
#End Region

#Region "Update From MAP"
        Public Overridable Sub UpdateLocalizations(ByRef LocalizeController As ISupport_COH_LocalizeContent)
        End Sub
#End Region

#Region "Clone"
        Public Overridable Function CloneMe() As Object Implements ICloneable.Clone
            Return CreateClone(Me)
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As COH_Struct)
            With Destination
                .mBuild = mBuild
                .mValid = mValid
                .mBinVersion = mBinVersion
            End With
        End Sub
        Protected Shared Function CreateClone(ByRef Source As Object) As Object
            Dim m As New IO.MemoryStream()
            Dim f As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            f.Serialize(m, Source)
            m.Seek(0, IO.SeekOrigin.Begin)
            Return f.Deserialize(m)
        End Function
#End Region
    End Class
End Namespace