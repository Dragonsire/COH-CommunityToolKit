Namespace World
    Public NotInheritable Class COH_Enviroment_Wind
        Inherits COH_FileStructure

#Region "Properties - Override"
        Public Overrides ReadOnly Property InternalDisplayName As String
            Get
                Return "Wind"
            End Get
        End Property
#End Region

#Region "Properties"
        Property WorldFactor As Single
            Get
                Return mWorldFactor
            End Get
            Set(value As Single)
                mWorldFactor = value
            End Set
        End Property
        Property LocalFactor As Single
            Get
                Return mLocalFactor
            End Get
            Set(value As Single)
                mLocalFactor = value
            End Set
        End Property
        Property Ripple As Single
            Get
                Return mRipple
            End Get
            Set(value As Single)
                mRipple = value
            End Set
        End Property
        Property Gravity As Single
            Get
                Return mGravity
            End Get
            Set(value As Single)
                mGravity = value
            End Set
        End Property
        Property MinWind As Single
            Get
                Return mMinWind
            End Get
            Set(value As Single)
                mMinWind = value
            End Set
        End Property
        Property LocalDir As Vector3
            Get
                Return mLocalDir
            End Get
            Set(value As Vector3)
                mLocalDir = value
            End Set
        End Property
        Property SpecialCollision As Boolean
            Get
                Return mSpecialCollision
            End Get
            Set(value As Boolean)
                mSpecialCollision = value
            End Set
        End Property
        Property WindInMovementDirection As Boolean
            Get
                Return mWindInMovementDirection
            End Get
            Set(value As Boolean)
                mWindInMovementDirection = value
            End Set
        End Property
#End Region

#Region "Properties - Localized"
#End Region

#Region "Private Properties"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mWorldFactor As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mLocalFactor As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mRipple As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mGravity As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mMinWind As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mLocalDir As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mSpecialCollision As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mWindInMovementDirection As Boolean
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(SetDefaults As Boolean, Optional Version As Integer = 0, Optional BuildType As COH_BuildType = COH_BuildType.Either)
            MyBase.New(SetDefaults, Version)
        End Sub
        Public Sub New(ByRef Buffer As Byte(), Optional Settings as COH_Serialization_Settings = Nothing)
            MyBase.New(Buffer, Settings)
        End Sub
        Public Sub New(ByRef Stream As IO.MemoryStream, Optional Settings as COH_Serialization_Settings = Nothing)
             MyBase.New(Stream, Settings)
        End Sub
        Public Sub New(ByRef CurrentReader As COH_BinaryReader)
             MyBase.New(CurrentReader)
        End Sub
        Public Overrides Sub ResetDefaults(Optional Version As Integer = 0)
            MyBase.ResetDefaults()
            mLocalDir = New Vector3
        End Sub
#End Region

#Region "Update From MAP"
        Public Overrides Sub UpdateLocalizations(ByRef LocalizeController As ISupport_COH_LocalizeContent)
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As COH_Enviroment_Wind
            Dim Result As COH_Enviroment_Wind = New COH_Enviroment_Wind
            'MyBase.CloneTo(TryCast(Result, COH_FileStructure))
            With Result
                .mWorldFactor = mWorldFactor
                .mLocalFactor = mLocalFactor
                .mRipple = mRipple
                .mGravity = mGravity
                .mMinWind = mMinWind
                .mLocalDir = mLocalDir
                .mSpecialCollision = mSpecialCollision
                .mWindInMovementDirection = mWindInMovementDirection
                Return Result
            End With
        End Function
#End Region

#Region "Import/Export - CrypticS"
      Protected Overrides Function Write_ToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            CurrentWriter.Write(mWorldFactor)
            CurrentWriter.Write(mLocalFactor)
            CurrentWriter.Write(mRipple)
            CurrentWriter.Write(mGravity)
            CurrentWriter.Write(mMinWind)
            CurrentWriter.Write_CrypticS_Vector3(mLocalDir)
            CurrentWriter.Write_CrypticS_Boolean(mSpecialCollision)
            CurrentWriter.Write_CrypticS_Boolean(mWindInMovementDirection)
            Return True
        End Function
        Protected Overrides Function Read_FromStream(ByRef CurrentReader As COH_BinaryReader) As Boolean
            mWorldFactor = CurrentReader.ReadSingle
            mLocalFactor = CurrentReader.ReadSingle
            mRipple = CurrentReader.ReadSingle
            mGravity = CurrentReader.ReadSingle
            mMinWind = CurrentReader.ReadSingle
            mLocalDir = CurrentReader.Read_CrypticS_Vector3
            mSpecialCollision = CurrentReader.Read_CrypticS_Boolean
            mWindInMovementDirection = CurrentReader.Read_CrypticS_Boolean
            Return True
        End Function
#End Region

    End Class
End Namespace
