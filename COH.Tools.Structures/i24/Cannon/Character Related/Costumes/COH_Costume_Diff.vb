Namespace Costumes
    Public NotInheritable Class COH_Costume_Diff
        Inherits COH_Struct

#Region "Properties - Override"
        Public Overrides ReadOnly Property InternalDisplayName As String
            Get
                Return "Costume"
            End Get
        End Property
#End Region

#Region "Properties"
        Property EntTypeFile As String
            Get
                Return mEntTypeFile
            End Get
            Set(value As String)
                mEntTypeFile = value
            End Set
        End Property
        Property CostumeFilePrefix As String
            Get
                Return mCostumeFilePrefix
            End Get
            Set(value As String)
                mCostumeFilePrefix = value
            End Set
        End Property
        Property Scale As Single
            Get
                Return mScale
            End Get
            Set(value As Single)
                mScale = value
            End Set
        End Property
        Property BoneScale As Single
            Get
                Return mBoneScale
            End Get
            Set(value As Single)
                mBoneScale = value
            End Set
        End Property
        Property HeadScale As Single
            Get
                Return mHeadScale
            End Get
            Set(value As Single)
                mHeadScale = value
            End Set
        End Property
        Property ShoulderScale As Single
            Get
                Return mShoulderScale
            End Get
            Set(value As Single)
                mShoulderScale = value
            End Set
        End Property
        Property ChestScale As Single
            Get
                Return mChestScale
            End Get
            Set(value As Single)
                mChestScale = value
            End Set
        End Property
        Property WaistScale As Single
            Get
                Return mWaistScale
            End Get
            Set(value As Single)
                mWaistScale = value
            End Set
        End Property
        Property HipScale As Single
            Get
                Return mHipScale
            End Get
            Set(value As Single)
                mHipScale = value
            End Set
        End Property
        Property LegScale As Single
            Get
                Return mLegScale
            End Get
            Set(value As Single)
                mLegScale = value
            End Set
        End Property
        Property ArmScale As Single
            Get
                Return mArmScale
            End Get
            Set(value As Single)
                mArmScale = value
            End Set
        End Property
        Property HeadScales As Vector3
            Get
                Return mHeadScales
            End Get
            Set(value As Vector3)
                mHeadScales = value
            End Set
        End Property
        Property BrowScales As Vector3
            Get
                Return mBrowScales
            End Get
            Set(value As Vector3)
                mBrowScales = value
            End Set
        End Property
        Property CheekScales As Vector3
            Get
                Return mCheekScales
            End Get
            Set(value As Vector3)
                mCheekScales = value
            End Set
        End Property
        Property ChinScales As Vector3
            Get
                Return mChinScales
            End Get
            Set(value As Vector3)
                mChinScales = value
            End Set
        End Property
        Property CraniumScales As Vector3
            Get
                Return mCraniumScales
            End Get
            Set(value As Vector3)
                mCraniumScales = value
            End Set
        End Property
        Property JawScales As Vector3
            Get
                Return mJawScales
            End Get
            Set(value As Vector3)
                mJawScales = value
            End Set
        End Property
        Property NoseScales As Vector3
            Get
                Return mNoseScales
            End Get
            Set(value As Vector3)
                mNoseScales = value
            End Set
        End Property
        Property SkinColor As COH_XML_Color
            Get
                Return mSkinColor
            End Get
            Set(value As COH_XML_Color)
                mSkinColor = value
            End Set
        End Property
        Property NumParts As Int32
            Get
                Return mNumParts
            End Get
            Set(value As Int32)
                mNumParts = value
            End Set
        End Property
        Property BodyType As Int32
            Get
                Return mBodyType
            End Get
            Set(value As Int32)
                mBodyType = value
            End Set
        End Property
        Property BaseCostumeNum As Int32
            Get
                Return mBaseCostumeNum
            End Get
            Set(value As Int32)
                mBaseCostumeNum = value
            End Set
        End Property
        Property DiffCostumePart As COH_CostumePart_Diff()
            Get
                Return mDiffCostumePart
            End Get
            Set(value As COH_CostumePart_Diff())
                mDiffCostumePart = value
            End Set
        End Property
#End Region

#Region "Properties - Localized"
#End Region

#Region "Private Properties"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mEntTypeFile As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mCostumeFilePrefix As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBoneScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mHeadScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mShoulderScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mChestScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mWaistScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mHipScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mLegScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mArmScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mHeadScales As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBrowScales As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mCheekScales As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mChinScales As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mCraniumScales As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mJawScales As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mNoseScales As Vector3
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mSkinColor As Drawing.Color
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mNumParts As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBodyType As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBaseCostumeNum As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDiffCostumePart As COH_CostumePart_Diff()
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(SetDefaults As Boolean, Optional Version As Integer = 0, Optional BuildType As COH_BuildType = COH_BuildType.Either)
            MyBase.New(SetDefaults, Version)
        End Sub
        Public Overrides Sub ResetDefaults(Optional Version As Integer = 0)
            MyBase.ResetDefaults()
            mEntTypeFile = String.Empty
            mCostumeFilePrefix = String.Empty
            mScale = 0
            mBoneScale = 0
            mHeadScale = 0
            mShoulderScale = 0
            mChestScale = 0
            mWaistScale = 0
            mHipScale = 0
            mLegScale = 0
            mArmScale = 0
            mHeadScales = New Vector3  ' No Default Defined
            mBrowScales = New Vector3  ' No Default Defined
            mCheekScales = New Vector3  ' No Default Defined
            mChinScales = New Vector3  ' No Default Defined
            mCraniumScales = New Vector3  ' No Default Defined
            mJawScales = New Vector3 ' No Default Defined
            mNoseScales = New Vector3  ' No Default Defined
            mSkinColor = New Drawing.Color  ' No Default Defined
            mNumParts = 0
            mBodyType = 0
            mDiffCostumePart = New COH_CostumePart_Diff() {}
        End Sub
#End Region

#Region "Update From MAP"
        Public Overrides Sub UpdateLocalizations(ByRef LocalizeController As ISupport_COH_LocalizeContent)
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As COH_Costume_Diff
            Dim Result As COH_Costume_Diff = New COH_Costume_Diff
            MyBase.CloneTo(TryCast(Result, COH_Struct))
            With Result
                .mEntTypeFile = String.Copy(mEntTypeFile)
                .mCostumeFilePrefix = String.Copy(mCostumeFilePrefix)
                .mScale = mScale
                .mBoneScale = mBoneScale
                .mHeadScale = mHeadScale
                .mShoulderScale = mShoulderScale
                .mChestScale = mChestScale
                .mWaistScale = mWaistScale
                .mHipScale = mHipScale
                .mLegScale = mLegScale
                .mArmScale = mArmScale
                .mHeadScales = mHeadScales
                .mBrowScales = mBrowScales
                .mCheekScales = mCheekScales
                .mChinScales = mChinScales
                .mCraniumScales = mCraniumScales
                .mJawScales = mJawScales
                .mNoseScales = mNoseScales
                .mSkinColor = mSkinColor
                .mNumParts = mNumParts
                .mBodyType = mBodyType
                .mBaseCostumeNum = mBaseCostumeNum
                .mDiffCostumePart = New COH_CostumePart_Diff(mDiffCostumePart.Count - 1) {}
                For X = 0 To mDiffCostumePart.Count - 1
                    .mDiffCostumePart(X) = mDiffCostumePart(X).Clone
                Next
                Return Result
            End With
        End Function
#End Region

#Region "Import/Export - CrypticS"
      Protected Overrides Function Write_ToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            CurrentWriter.Write_CrypticS_String(mEntTypeFile)
            CurrentWriter.Write_CrypticS_String(mCostumeFilePrefix)
            CurrentWriter.Write(mScale)
            CurrentWriter.Write(mBoneScale)
            CurrentWriter.Write(mHeadScale)
            CurrentWriter.Write(mShoulderScale)
            CurrentWriter.Write(mChestScale)
            CurrentWriter.Write(mWaistScale)
            CurrentWriter.Write(mHipScale)
            CurrentWriter.Write(mLegScale)
            CurrentWriter.Write(mArmScale)
            CurrentWriter.Write_CrypticS_Vector3(mHeadScales)
            CurrentWriter.Write_CrypticS_Vector3(mBrowScales)
            CurrentWriter.Write_CrypticS_Vector3(mCheekScales)
            CurrentWriter.Write_CrypticS_Vector3(mChinScales)
            CurrentWriter.Write_CrypticS_Vector3(mCraniumScales)
            CurrentWriter.Write_CrypticS_Vector3(mJawScales)
            CurrentWriter.Write_CrypticS_Vector3(mNoseScales)
            CurrentWriter.Write_CrypticS_RGB(mSkinColor)
            CurrentWriter.Write(mNumParts)
            CurrentWriter.Write(mBodyType)
            CurrentWriter.Write(mBaseCostumeNum)
            If CurrentWriter.Write_CrypticS_StructArray(mDiffCostumePart) = False Then Return False
            Return True
        End Function
        Protected Overrides Function Read_FromStream(ByRef CurrentReader As COH_BinaryReader) As Boolean
            mEntTypeFile = CurrentReader.Read_CrypticS_String
            mCostumeFilePrefix = CurrentReader.Read_CrypticS_String
            mScale = CurrentReader.ReadSingle
            mBoneScale = CurrentReader.ReadSingle
            mHeadScale = CurrentReader.ReadSingle
            mShoulderScale = CurrentReader.ReadSingle
            mChestScale = CurrentReader.ReadSingle
            mWaistScale = CurrentReader.ReadSingle
            mHipScale = CurrentReader.ReadSingle
            mLegScale = CurrentReader.ReadSingle
            mArmScale = CurrentReader.ReadSingle
            mHeadScales = CurrentReader.Read_CrypticS_Vector3
            mBrowScales = CurrentReader.Read_CrypticS_Vector3
            mCheekScales = CurrentReader.Read_CrypticS_Vector3
            mChinScales = CurrentReader.Read_CrypticS_Vector3
            mCraniumScales = CurrentReader.Read_CrypticS_Vector3
            mJawScales = CurrentReader.Read_CrypticS_Vector3
            mNoseScales = CurrentReader.Read_CrypticS_Vector3
            mSkinColor = CurrentReader.Read_CrypticS_RGB
            mNumParts = CurrentReader.ReadInt32
            mBodyType = CurrentReader.ReadInt32
            mBaseCostumeNum = CurrentReader.ReadInt32
            If CurrentReader.Read_CrypticS_StructArray(GetType(COH_CostumePart_Diff), mDiffCostumePart) = False Then Return False
            Return True
        End Function
#End Region
    End Class
End Namespace
