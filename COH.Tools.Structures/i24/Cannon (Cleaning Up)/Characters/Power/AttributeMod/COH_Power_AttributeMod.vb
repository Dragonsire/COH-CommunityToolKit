Imports COH.GameContent.Structures.Powers

Namespace Characters.Powers
    Public NotInheritable Class COH_Power_AttributeMod
        Inherits COH_Struct

#Region "Properties - Override"
        Public Overrides ReadOnly Property InternalDisplayName As String
            Get
                Return mName
            End Get
        End Property
#End Region

#Region "Properties"
        Property Name As String
            Get
                Return mName
            End Get
            Set(value As String)
                SetValue(mName, value)
            End Set
        End Property
        Property DisplayAttackerHit As CrypticS_String
            Get
                Return mDisplayAttackerHit
            End Get
            Set(value As CrypticS_String)
                SetValue(mDisplayAttackerHit, value)
            End Set
        End Property
        Property DisplayVictimHit As CrypticS_String
            Get
                Return mDisplayVictimHit
            End Get
            Set(value As CrypticS_String)
                SetValue(mDisplayVictimHit, value)
            End Set
        End Property
        Property DisplayFloat As CrypticS_String
            Get
                Return mDisplayFloat
            End Get
            Set(value As CrypticS_String)
                SetValue(mDisplayFloat, value)
            End Set
        End Property
        Property DisplayAttribDefenseFloat As CrypticS_String
            Get
                Return mDisplayAttribDefenseFloat
            End Get
            Set(value As CrypticS_String)
                SetValue(mDisplayAttribDefenseFloat, value)
            End Set
        End Property
        <DefaultValue(True)> Property ShowFloaters As Boolean
            Get
                Return mShowFloaters
            End Get
            Set(value As Boolean)
                SetValue(mShowFloaters, value)
            End Set
        End Property
        Property Attrib As COH_Enum_Attrib_CharacterAll
            Get
                Return mAttrib
            End Get
            Set(value As COH_Enum_Attrib_CharacterAll)
                SetValue(mAttrib, value)
            End Set
        End Property
        Property Aspect As COH_Enum_Aspect
            Get
                Return mAspect
            End Get
            Set(value As COH_Enum_Aspect)
                SetValue(mAspect, value)
            End Set
        End Property
        Property BoostIgnoreDiminishing As Boolean
            Get
                Return mBoostIgnoreDiminishing
            End Get
            Set(value As Boolean)
                SetValue(mBoostIgnoreDiminishing, value)
            End Set
        End Property
        Property Target As COH_Enum_ModTarget
            Get
                Return mTarget
            End Get
            Set(value As COH_Enum_ModTarget)
                SetValue(mTarget, value)
            End Set
        End Property
        Property Table As String
            Get
                Return mTable
            End Get
            Set(value As String)
                SetValue(mTable, value)
            End Set
        End Property
        Property Scale As Single
            Get
                Return mScale
            End Get
            Set(value As Single)
                SetValue(mScale, value)
            End Set
        End Property
        Property ApplicationType As COH_Enum_ModApplication
            Get
                Return mApplicationType
            End Get
            Set(value As COH_Enum_ModApplication)
                SetValue(mApplicationType, value)
            End Set
        End Property
        Property Type As COH_Enum_ModType
            Get
                Return mType
            End Get
            Set(value As COH_Enum_ModType)
                SetValue(mType, value)
            End Set
        End Property
        Property Delay As Single
            Get
                Return mDelay
            End Get
            Set(value As Single)
                SetValue(mDelay, value)
            End Set
        End Property
        Property Period As Single
            Get
                Return mPeriod
            End Get
            Set(value As Single)
                SetValue(mPeriod, value)
            End Set
        End Property
        Property Chance As Single
            Get
                Return mChance
            End Get
            Set(value As Single)
                SetValue(mChance, value)
            End Set
        End Property
        Property CancelOnMiss As Boolean
            Get
                Return mCancelOnMiss
            End Get
            Set(value As Boolean)
                SetValue(mCancelOnMiss, value)
            End Set
        End Property
        Property CancelEvents As COH_Enum_PowerEvent()
            Get
                Return mCancelEvents
            End Get
            Set(value As COH_Enum_PowerEvent())
                SetValue(mCancelEvents, value)
            End Set
        End Property
        Property NearGround As Boolean
            Get
                Return mNearGround
            End Get
            Set(value As Boolean)
                SetValue(mNearGround, value)
            End Set
        End Property
        <DefaultValue(True)> Property AllowStrength As Boolean
            Get
                Return mAllowStrength
            End Get
            Set(value As Boolean)
                SetValue(mAllowStrength, value)
            End Set
        End Property
        <DefaultValue(True)> Property AllowResistance As Boolean
            Get
                Return mAllowResistance
            End Get
            Set(value As Boolean)
                SetValue(mAllowResistance, value)
            End Set
        End Property
        Property UseMagnitudeResistance As Boolean
            Get
                Return mUseMagnitudeResistance
            End Get
            Set(value As Boolean)
                SetValue(mUseMagnitudeResistance, value)
            End Set
        End Property
        Property UseDurationResistance As Boolean
            Get
                Return mUseDurationResistance
            End Get
            Set(value As Boolean)
                SetValue(mUseDurationResistance, value)
            End Set
        End Property
        <DefaultValue(True)> Property AllowCombatMods As Boolean
            Get
                Return mAllowCombatMods
            End Get
            Set(value As Boolean)
                SetValue(mAllowCombatMods, value)
            End Set
        End Property
        Property UseMagnitudeCombatMods As Boolean
            Get
                Return mUseMagnitudeCombatMods
            End Get
            Set(value As Boolean)
                SetValue(mUseMagnitudeCombatMods, value)
            End Set
        End Property
        Property UseDurationCombatMods As Boolean
            Get
                Return mUseDurationCombatMods
            End Get
            Set(value As Boolean)
                SetValue(mUseDurationCombatMods, value)
            End Set
        End Property
        Property BoostTemplate As Boolean
            Get
                Return mBoostTemplate
            End Get
            Set(value As Boolean)
                SetValue(mBoostTemplate, value)
            End Set
        End Property
        Property Requires As String()
            Get
                Return mRequires
            End Get
            Set(value As String())
                SetValue(mRequires, value)
            End Set
        End Property
        Property PrimaryStringList As String()
            Get
                Return mPrimaryStringList
            End Get
            Set(value As String())
                SetValue(mPrimaryStringList, value)
            End Set
        End Property
        Property SecondaryStringList As String()
            Get
                Return mSecondaryStringList
            End Get
            Set(value As String())
                SetValue(mSecondaryStringList, value)
            End Set
        End Property
        Property CasterStackType As COH_Enum_CasterStackType
            Get
                Return mCasterStackType
            End Get
            Set(value As COH_Enum_CasterStackType)
                SetValue(mCasterStackType, value)
            End Set
        End Property
        Property StackType As COH_Enum_StackType
            Get
                Return mStackType
            End Get
            Set(value As COH_Enum_StackType)
                SetValue(mStackType, value)
            End Set
        End Property
        <DefaultValue(2)> Property StackLimit As Int32
            Get
                Return mStackLimit
            End Get
            Set(value As Int32)
                SetValue(mStackLimit, value)
            End Set
        End Property
        <DefaultValue(-1)> Property StackKey As Int32
            Get
                Return mStackKey
            End Get
            Set(value As Int32)
                SetValue(mStackKey, value)
            End Set
        End Property
        <DefaultValue(-1)> Property Duration As Single
            Get
                Return mDuration
            End Get
            Set(value As Single)
                SetValue(mDuration, value)
            End Set
        End Property
        Property DurationExpr As String()
            Get
                Return mDurationExpr
            End Get
            Set(value As String())
                SetValue(mDurationExpr, value)
            End Set
        End Property
        Property Magnitude As Single
            Get
                Return mMagnitude
            End Get
            Set(value As Single)
                SetValue(mMagnitude, value)
            End Set
        End Property
        Property MagnitudeExpr As String()
            Get
                Return mMagnitudeExpr
            End Get
            Set(value As String())
                SetValue(mMagnitudeExpr, value)
            End Set
        End Property
        <DefaultValue(-1)> Property RadiusInner As Single
            Get
                Return mRadiusInner
            End Get
            Set(value As Single)
                SetValue(mRadiusInner, value)
            End Set
        End Property
        <DefaultValue(-1)> Property RadiusOuter As Single
            Get
                Return mRadiusOuter
            End Get
            Set(value As Single)
                SetValue(mRadiusOuter, value)
            End Set
        End Property
        Property Suppress As COH_SuppressPairs()
            Get
                Return mSuppress
            End Get
            Set(value As COH_SuppressPairs())
                SetValue(mSuppress, value)
            End Set
        End Property
        Property IgnoreSuppressErrors As String
            Get
                Return mIgnoreSuppressErrors
            End Get
            Set(value As String)
                SetValue(mIgnoreSuppressErrors, value)
            End Set
        End Property
        Property ContinuingBits As Int32()
            Get
                Return mContinuingBits
            End Get
            Set(value As Int32())
                SetValue(mContinuingBits, value)
            End Set
        End Property
        Property ContinuingFX As String
            Get
                Return mContinuingFX
            End Get
            Set(value As String)
                SetValue(mContinuingFX, value)
            End Set
        End Property
        Property ConditionalBits As Int32()
            Get
                Return mConditionalBits
            End Get
            Set(value As Int32())
                SetValue(mConditionalBits, value)
            End Set
        End Property
        Property ConditionalFX As String
            Get
                Return mConditionalFX
            End Get
            Set(value As String)
                SetValue(mConditionalFX, value)
            End Set
        End Property
        Property CostumeName As String
            Get
                Return mCostumeName
            End Get
            Set(value As String)
                SetValue(mCostumeName, value)
            End Set
        End Property
        Property Reward As String
            Get
                Return mReward
            End Get
            Set(value As String)
                SetValue(mReward, value)
            End Set
        End Property
        Property Params As String
            Get
                Return mParams
            End Get
            Set(value As String)
                SetValue(mParams, value)
            End Set
        End Property
        Property EntityDef As String
            Get
                Return mEntityDef
            End Get
            Set(value As String)
                SetValue(mEntityDef, value)
            End Set
        End Property
        Property PriorityListDefense As String
            Get
                Return mPriorityListDefense
            End Get
            Set(value As String)
                SetValue(mPriorityListDefense, value)
            End Set
        End Property
        Property PriorityListOffense As String
            Get
                Return mPriorityListOffense
            End Get
            Set(value As String)
                SetValue(mPriorityListOffense, value)
            End Set
        End Property
        Property PriorityListPassive As String
            Get
                Return mPriorityListPassive
            End Get
            Set(value As String)
                SetValue(mPriorityListPassive, value)
            End Set
        End Property
        Property DisplayOnlyIfNotZero As Boolean
            Get
                Return mDisplayOnlyIfNotZero
            End Get
            Set(value As Boolean)
                SetValue(mDisplayOnlyIfNotZero, value)
            End Set
        End Property
        Property MatchExactPower As Boolean
            Get
                Return mMatchExactPower
            End Get
            Set(value As Boolean)
                SetValue(mMatchExactPower, value)
            End Set
        End Property
        Property VanishEntOnTimeout As Boolean
            Get
                Return mVanishEntOnTimeout
            End Get
            Set(value As Boolean)
                SetValue(mVanishEntOnTimeout, value)
            End Set
        End Property
        Property DoNotTint As Boolean
            Get
                Return mDoNotTint
            End Get
            Set(value As Boolean)
                SetValue(mDoNotTint, value)
            End Set
        End Property
        Property KeepThroughDeath As Boolean
            Get
                Return mKeepThroughDeath
            End Get
            Set(value As Boolean)
                SetValue(mKeepThroughDeath, value)
            End Set
        End Property
        Property DelayEval As Boolean
            Get
                Return mDelayEval
            End Get
            Set(value As Boolean)
                SetValue(mDelayEval, value)
            End Set
        End Property
        Property BoostModAllowed As Int32
            Get
                Return mBoostModAllowed
            End Get
            Set(value As Int32)
                SetValue(mBoostModAllowed, value)
            End Set
        End Property
        Property EvalFlags As Int32
            Get
                Return mEvalFlags
            End Get
            Set(value As Int32)
                SetValue(mEvalFlags, value)
            End Set
        End Property
        Property ProcsPerMinute As Single
            Get
                Return mProcsPerMinute
            End Get
            Set(value As Single)
                SetValue(mProcsPerMinute, value)
            End Set
        End Property
#End Region

#Region "Properties - Localized"
#End Region

#Region "Private Properties"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mName As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDisplayAttackerHit As CrypticS_String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDisplayVictimHit As CrypticS_String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDisplayFloat As CrypticS_String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDisplayAttribDefenseFloat As CrypticS_String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mShowFloaters As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mAttrib As COH_Enum_Attrib_CharacterAll
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mAspect As COH_Enum_Aspect
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBoostIgnoreDiminishing As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mTarget As COH_Enum_ModTarget
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mTable As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mScale As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mApplicationType As COH_Enum_ModApplication
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mType As COH_Enum_ModType
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDelay As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mPeriod As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mChance As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mCancelOnMiss As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mCancelEvents As COH_Enum_PowerEvent()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mNearGround As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mAllowStrength As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mAllowResistance As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mUseMagnitudeResistance As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mUseDurationResistance As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mAllowCombatMods As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mUseMagnitudeCombatMods As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mUseDurationCombatMods As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBoostTemplate As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mRequires As String()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mPrimaryStringList As String()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mSecondaryStringList As String()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mCasterStackType As COH_Enum_CasterStackType
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mStackType As COH_Enum_StackType
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mStackLimit As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mStackKey As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDuration As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDurationExpr As String()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mMagnitude As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mMagnitudeExpr As String()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mRadiusInner As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mRadiusOuter As Single
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mSuppress As COH_SuppressPairs()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mIgnoreSuppressErrors As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mContinuingBits As Int32()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mContinuingFX As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mConditionalBits As Int32()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mConditionalFX As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mCostumeName As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mReward As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mParams As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mEntityDef As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mPriorityListDefense As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mPriorityListOffense As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mPriorityListPassive As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDisplayOnlyIfNotZero As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mMatchExactPower As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mVanishEntOnTimeout As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDoNotTint As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mKeepThroughDeath As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDelayEval As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mBoostModAllowed As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mEvalFlags As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mProcsPerMinute As Single
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(SetDefaults As Boolean, Optional Version As Integer = 0)
            MyBase.New(SetDefaults, Version)
        End Sub
        Public Sub New(ByRef Buffer As Byte(), Optional Settings As COH_Serialization_Settings = Nothing)
            MyBase.New(Buffer, Settings)
        End Sub
        Public Sub New(ByRef Stream As IO.MemoryStream, Optional Settings As COH_Serialization_Settings = Nothing)
            MyBase.New(Stream, Settings)
        End Sub
        Public Sub New(ByRef CurrentReader As COH_BinaryReader)
            MyBase.New(CurrentReader)
        End Sub
        Public Overrides Sub ResetDefaults(Optional Version As Integer = 0)
            MyBase.ResetDefaults()
            mName = String.Empty
            mAspect = 0
            mTarget = COH_Enum_ModTarget.kModTarget_Affected
            mTable = String.Empty
            mApplicationType = COH_Enum_ModApplication.kModApplicationType_OnTick
            mType = COH_Enum_ModType.kModType_Magnitude
            mCancelEvents = New COH_Enum_PowerEvent() {} '0' No Default Defined
            mRequires = New String() {}
            mPrimaryStringList = New String() {}
            mSecondaryStringList = New String() {}
            mCasterStackType = COH_Enum_CasterStackType.kCasterStackType_Individual
            mStackType = COH_Enum_StackType.kStackType_Replace
            mDurationExpr = New String() {}
            mMagnitudeExpr = New String() {}
            mSuppress = New COH_SuppressPairs() {}
            mIgnoreSuppressErrors = String.Empty
            mContinuingBits = New Int32() {}
            mContinuingFX = String.Empty
            mConditionalBits = New Int32() {}
            mConditionalFX = String.Empty
            mCostumeName = String.Empty
            mReward = String.Empty
            mParams = String.Empty
            mEntityDef = String.Empty
            mPriorityListDefense = String.Empty
            mPriorityListOffense = String.Empty
            mPriorityListPassive = String.Empty
        End Sub
#End Region

#Region "Update From MAP"
        Public Overrides Sub UpdateLocalizations(ByRef LocalizeController As ISupport_COH_LocalizeContent)
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As COH_Power_AttributeMod
            Dim Result As COH_Power_AttributeMod = New COH_Power_AttributeMod
            MyBase.CloneTo(TryCast(Result, COH_Struct))
            With Result
                .mName = CloneString(mName)
                .mDisplayAttackerHit = mDisplayAttackerHit.Clone
                .mDisplayVictimHit = mDisplayVictimHit.Clone
                .mDisplayFloat = mDisplayFloat.Clone
                .mDisplayAttribDefenseFloat = mDisplayAttribDefenseFloat.Clone
                .mShowFloaters = mShowFloaters
                .mAttrib = mAttrib
                .mAspect = mAspect
                .mBoostIgnoreDiminishing = mBoostIgnoreDiminishing
                .mTarget = mTarget
                .mTable = CloneString(mTable)
                .mScale = mScale
                .mApplicationType = mApplicationType
                .mType = mType
                .mDelay = mDelay
                .mPeriod = mPeriod
                .mChance = mChance
                .mCancelOnMiss = mCancelOnMiss
                .mCancelEvents = New COH_Enum_PowerEvent(mCancelEvents.Count - 1) {} : mCancelEvents.CopyTo(.mCancelEvents, 0)
                .mNearGround = mNearGround
                .mAllowStrength = mAllowStrength
                .mAllowResistance = mAllowResistance
                .mUseMagnitudeResistance = mUseMagnitudeResistance
                .mUseDurationResistance = mUseDurationResistance
                .mAllowCombatMods = mAllowCombatMods
                .mUseMagnitudeCombatMods = mUseMagnitudeCombatMods
                .mUseDurationCombatMods = mUseDurationCombatMods
                .mBoostTemplate = mBoostTemplate
                .mRequires = CloneStrings(mRequires)
                .mPrimaryStringList = CloneStrings(mPrimaryStringList)
                .mSecondaryStringList = CloneStrings(mSecondaryStringList)
                .mCasterStackType = mCasterStackType
                .mStackType = mStackType
                .mStackLimit = mStackLimit
                .mStackKey = mStackKey
                .mDuration = mDuration
                .mDurationExpr = CloneStrings(mDurationExpr)
                .mMagnitude = mMagnitude
                .mMagnitudeExpr = CloneStrings(mMagnitudeExpr)
                .mRadiusInner = mRadiusInner
                .mRadiusOuter = mRadiusOuter
                .mSuppress = New COH_SuppressPairs(mSuppress.Count - 1) {}
                For X = 0 To mSuppress.Count - 1
                    .mSuppress(X) = mSuppress(X).Clone
                Next
                .mIgnoreSuppressErrors = CloneString(mIgnoreSuppressErrors)
                .mContinuingBits = New Int32(mContinuingBits.Count - 1) {} : mContinuingBits.CopyTo(.mContinuingBits, 0)
                .mContinuingFX = CloneString(mContinuingFX)
                .mConditionalBits = New Int32(mConditionalBits.Count - 1) {} : mConditionalBits.CopyTo(.mConditionalBits, 0)
                .mConditionalFX = CloneString(mConditionalFX)
                .mCostumeName = CloneString(mCostumeName)
                .mReward = CloneString(mReward)
                .mParams = CloneString(mParams)
                .mEntityDef = CloneString(mEntityDef)
                .mPriorityListDefense = CloneString(mPriorityListDefense)
                .mPriorityListOffense = CloneString(mPriorityListOffense)
                .mPriorityListPassive = CloneString(mPriorityListPassive)
                .mDisplayOnlyIfNotZero = mDisplayOnlyIfNotZero
                .mMatchExactPower = mMatchExactPower
                .mVanishEntOnTimeout = mVanishEntOnTimeout
                .mDoNotTint = mDoNotTint
                .mKeepThroughDeath = mKeepThroughDeath
                .mDelayEval = mDelayEval
                .mBoostModAllowed = mBoostModAllowed
                .mEvalFlags = mEvalFlags
                .mProcsPerMinute = mProcsPerMinute
                Return Result
            End With
        End Function
#End Region

#Region "Import/Export - CrypticS"
        Protected Overrides Function Write_ToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            CurrentWriter.Write_CrypticS_String(mName)
            mDisplayAttackerHit.Export_To_Stream(CurrentWriter)
            mDisplayVictimHit.Export_To_Stream(CurrentWriter)
            mDisplayFloat.Export_To_Stream(CurrentWriter)
            mDisplayAttribDefenseFloat.Export_To_Stream(CurrentWriter)
            CurrentWriter.Write_CrypticS_Boolean(mShowFloaters)
            CurrentWriter.Write(mAttrib)
            CurrentWriter.Write(CInt(mAspect))
            CurrentWriter.Write_CrypticS_Boolean(mBoostIgnoreDiminishing)
            CurrentWriter.Write(CInt(mTarget))
            CurrentWriter.Write_CrypticS_String(mTable)
            CurrentWriter.Write(mScale)
            CurrentWriter.Write(CInt(mApplicationType))
            CurrentWriter.Write(CInt(mType))
            CurrentWriter.Write(mDelay)
            CurrentWriter.Write(mPeriod)
            CurrentWriter.Write(mChance)
            CurrentWriter.Write_CrypticS_Boolean(mCancelOnMiss)
            CurrentWriter.Write_CrypticS_IntegerArray(mCancelEvents)
            CurrentWriter.Write_CrypticS_Boolean(mNearGround)
            CurrentWriter.Write_CrypticS_Boolean(mAllowStrength)
            CurrentWriter.Write_CrypticS_Boolean(mAllowResistance)
            CurrentWriter.Write_CrypticS_Boolean(mUseMagnitudeResistance)
            CurrentWriter.Write_CrypticS_Boolean(mUseDurationResistance)
            CurrentWriter.Write_CrypticS_Boolean(mAllowCombatMods)
            CurrentWriter.Write_CrypticS_Boolean(mUseMagnitudeCombatMods)
            CurrentWriter.Write_CrypticS_Boolean(mUseDurationCombatMods)
            CurrentWriter.Write_CrypticS_Boolean(mBoostTemplate)
            CurrentWriter.Write_CrypticS_StringArray(mRequires)
            CurrentWriter.Write_CrypticS_StringArray(mPrimaryStringList)
            CurrentWriter.Write_CrypticS_StringArray(mSecondaryStringList)
            CurrentWriter.Write(CInt(mCasterStackType))
            CurrentWriter.Write(CInt(mStackType))
            CurrentWriter.Write(mStackLimit)
            CurrentWriter.Write(mStackKey)
            CurrentWriter.Write(mDuration)
            CurrentWriter.Write_CrypticS_StringArray(mDurationExpr)
            CurrentWriter.Write(mMagnitude)
            CurrentWriter.Write_CrypticS_StringArray(mMagnitudeExpr)
            CurrentWriter.Write(mRadiusInner)
            CurrentWriter.Write(mRadiusOuter)
            If CurrentWriter.Write_CrypticS_StructArray(mSuppress) = False Then Return False
            CurrentWriter.Write_CrypticS_String(mIgnoreSuppressErrors)
            CurrentWriter.Write_CrypticS_IntegerArray(mContinuingBits)
            CurrentWriter.Write_CrypticS_String(mContinuingFX)
            CurrentWriter.Write_CrypticS_IntegerArray(mConditionalBits)
            CurrentWriter.Write_CrypticS_String(mConditionalFX)
            CurrentWriter.Write_CrypticS_String(mCostumeName)
            '!!REDUNDENT!!CurrentWriter.Write_CrypticS_String(mPower)
            CurrentWriter.Write_CrypticS_String(mReward)
            CurrentWriter.Write_CrypticS_String(mParams)
            CurrentWriter.Write_CrypticS_String(mEntityDef)
            CurrentWriter.Write_CrypticS_String(mPriorityListDefense)
            CurrentWriter.Write_CrypticS_String(mPriorityListOffense)
            CurrentWriter.Write_CrypticS_String(mPriorityListPassive)
            '!!REDUNDENT!!CurrentWriter.Write_CrypticS_String(mPriorityList)
            CurrentWriter.Write_CrypticS_Boolean(mDisplayOnlyIfNotZero)
            CurrentWriter.Write_CrypticS_Boolean(mMatchExactPower)
            CurrentWriter.Write_CrypticS_Boolean(mVanishEntOnTimeout)
            CurrentWriter.Write_CrypticS_Boolean(mDoNotTint)
            CurrentWriter.Write_CrypticS_Boolean(mKeepThroughDeath)
            CurrentWriter.Write_CrypticS_Boolean(mDelayEval)
            CurrentWriter.Write(mBoostModAllowed)
            CurrentWriter.Write(mEvalFlags)
            CurrentWriter.Write(mProcsPerMinute)
            Return True
        End Function
        Protected Overrides Function Read_FromStream(ByRef CurrentReader As COH_BinaryReader) As Boolean
            mName = CurrentReader.Read_CrypticS_String
            mDisplayAttackerHit = New CrypticS_String(CurrentReader)
            mDisplayVictimHit = New CrypticS_String(CurrentReader)
            mDisplayFloat = New CrypticS_String(CurrentReader)
            mDisplayAttribDefenseFloat = New CrypticS_String(CurrentReader)
            mShowFloaters = CurrentReader.Read_CrypticS_Boolean
            mAttrib = CurrentReader.ReadInt32
            mAspect = CurrentReader.ReadInt32
            mBoostIgnoreDiminishing = CurrentReader.Read_CrypticS_Boolean
            mTarget = CurrentReader.ReadInt32
            mTable = CurrentReader.Read_CrypticS_String
            mScale = CurrentReader.ReadSingle
            mApplicationType = CurrentReader.ReadInt32
            mType = CurrentReader.ReadInt32
            mDelay = CurrentReader.ReadSingle
            mPeriod = CurrentReader.ReadSingle
            mChance = CurrentReader.ReadSingle
            mCancelOnMiss = CurrentReader.Read_CrypticS_Boolean
            mCancelEvents = CurrentReader.Read_CrypticS_IntegerArray()
            mNearGround = CurrentReader.Read_CrypticS_Boolean
            mAllowStrength = CurrentReader.Read_CrypticS_Boolean
            mAllowResistance = CurrentReader.Read_CrypticS_Boolean
            mUseMagnitudeResistance = CurrentReader.Read_CrypticS_Boolean
            mUseDurationResistance = CurrentReader.Read_CrypticS_Boolean
            mAllowCombatMods = CurrentReader.Read_CrypticS_Boolean
            mUseMagnitudeCombatMods = CurrentReader.Read_CrypticS_Boolean
            mUseDurationCombatMods = CurrentReader.Read_CrypticS_Boolean
            mBoostTemplate = CurrentReader.Read_CrypticS_Boolean
            mRequires = CurrentReader.Read_CrypticS_StringArray
            mPrimaryStringList = CurrentReader.Read_CrypticS_StringArray
            mSecondaryStringList = CurrentReader.Read_CrypticS_StringArray
            mCasterStackType = CurrentReader.ReadInt32
            mStackType = CurrentReader.ReadInt32
            mStackLimit = CurrentReader.ReadInt32
            mStackKey = CurrentReader.ReadInt32
            mDuration = CurrentReader.ReadSingle
            mDurationExpr = CurrentReader.Read_CrypticS_StringArray
            mMagnitude = CurrentReader.ReadSingle
            mMagnitudeExpr = CurrentReader.Read_CrypticS_StringArray
            mRadiusInner = CurrentReader.ReadSingle
            mRadiusOuter = CurrentReader.ReadSingle
            If CurrentReader.Read_CrypticS_StructArray(GetType(COH_SuppressPairs), mSuppress) = False Then Return False
            mIgnoreSuppressErrors = CurrentReader.Read_CrypticS_String
            mContinuingBits = CurrentReader.Read_CrypticS_IntegerArray()
            mContinuingFX = CurrentReader.Read_CrypticS_String
            mConditionalBits = CurrentReader.Read_CrypticS_IntegerArray()
            mConditionalFX = CurrentReader.Read_CrypticS_String
            mCostumeName = CurrentReader.Read_CrypticS_String
            '!!REDUNDENT!!mPower = CurrentReader.Read_CrypticS_String
            mReward = CurrentReader.Read_CrypticS_String
            mParams = CurrentReader.Read_CrypticS_String
            mEntityDef = CurrentReader.Read_CrypticS_String
            mPriorityListDefense = CurrentReader.Read_CrypticS_String
            mPriorityListOffense = CurrentReader.Read_CrypticS_String
            mPriorityListPassive = CurrentReader.Read_CrypticS_String
            '!!REDUNDENT!!mPriorityList = CurrentReader.Read_CrypticS_String
            mDisplayOnlyIfNotZero = CurrentReader.Read_CrypticS_Boolean
            mMatchExactPower = CurrentReader.Read_CrypticS_Boolean
            mVanishEntOnTimeout = CurrentReader.Read_CrypticS_Boolean
            mDoNotTint = CurrentReader.Read_CrypticS_Boolean
            mKeepThroughDeath = CurrentReader.Read_CrypticS_Boolean
            mDelayEval = CurrentReader.Read_CrypticS_Boolean
            mBoostModAllowed = CurrentReader.ReadInt32
            mEvalFlags = CurrentReader.ReadInt32
            mProcsPerMinute = CurrentReader.ReadSingle
            Return True
        End Function
#End Region

    End Class
End Namespace
