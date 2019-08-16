Namespace MeshRelated
    Public NotInheritable Class COH_Mesh_GroupList
        Inherits COH_Struct

#Region "Properties - Override"
        Public Overrides ReadOnly Property InternalDisplayName As String
            Get
                Return Scenefile
            End Get
        End Property
#End Region

#Region "Properties"
        Property Version As Int32
            Get
                Return mVersion
            End Get
            Set(value As Int32)
                mVersion = value
            End Set
        End Property
        Property Scenefile As String
            Get
                Return mScenefile
            End Get
            Set(value As String)
                mScenefile = value
            End Set
        End Property
        Property Loadscreen As String
            Get
                Return mLoadscreen
            End Get
            Set(value As String)
                mLoadscreen = value
            End Set
        End Property
        Property Def As COH_Def()
            Get
                Return mDef
            End Get
            Set(value As COH_Def())
                mDef = value
            End Set
        End Property
        Property Ref As COH_Ref()
            Get
                Return mRef
            End Get
            Set(value As COH_Ref())
                mRef = value
            End Set
        End Property
        Property Import As String()
            Get
                Return mImport
            End Get
            Set(value As String())
                mImport = value
            End Set
        End Property
#End Region

#Region "Properties - Localized"
#End Region

#Region "Private Properties"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mVersion As Int32
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mScenefile As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mLoadscreen As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mDef As COH_Def()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mRef As COH_Ref()
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mImport As String()
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
            mVersion = 0
            mScenefile = String.Empty
            mLoadscreen = String.Empty
            mDef = New COH_Def() {}
            mRef = New COH_Ref() {}
            mImport = New String() {}
        End Sub
#End Region

#Region "Update From MAP"
        Public Overrides Sub UpdateLocalizations(ByRef LocalizeController as ISupport_COH_LocalizeContent)
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As COH_Mesh_GroupList
            Dim Result As COH_Mesh_GroupList = New COH_Mesh_GroupList
            MyBase.CloneTo(TryCast(Result, COH_Struct))
            With Result
                .mVersion = mVersion
                .mScenefile = String.Copy(mScenefile)
                .mLoadscreen = String.Copy(mLoadscreen)
                .mDef = New COH_Def(mDef.Count - 1) {}
                For X = 0 To mDef.Count - 1
                    .mDef(X) = mDef(X).Clone
                Next
                .mRef = New COH_Ref(mRef.Count - 1) {}
                For X = 0 To mRef.Count - 1
                    .mRef(X) = mRef(X).Clone
                Next
                .mImport = mImport.CloneTheStrings
                Return Result
            End With
        End Function
#End Region

#Region "Import/Export - CrypticS"
      Protected Overrides Function Write_ToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            CurrentWriter.Write(mVersion)
            CurrentWriter.Write_CrypticS_String(mScenefile)
            CurrentWriter.Write_CrypticS_String(mLoadscreen)
            If CurrentWriter.Write_CrypticS_StructArray(mDef) = False Then Return False
            '!!REDUNDENT!! If CurrentWriter.Write_CrypticS_StructArray(mRootMod) = False Then Return False
            If CurrentWriter.Write_CrypticS_StructArray(mRef) = False Then Return False
            CurrentWriter.Write_CrypticS_StringArray(mImport)
            Return True
        End Function
        Protected Overrides Function Read_FromStream(ByRef CurrentReader As COH_BinaryReader) As Boolean
            mVersion = CurrentReader.ReadInt32
            mScenefile = CurrentReader.Read_CrypticS_String
            mLoadscreen = CurrentReader.Read_CrypticS_String
            If CurrentReader.Read_CrypticS_StructArray(GetType(COH_Def), mDef) = False Then Return False
            '!!REDUNDENT!!If CurrentReader.Read_CrypticS_StructArray(GetType('!!REDUNDANTNAME!! - COH_Def()), mRootMod) = False Then Return False
            If CurrentReader.Read_CrypticS_StructArray(GetType(COH_Ref), mRef) = False Then Return False
            mImport = CurrentReader.Read_CrypticS_StringArray()
            Return True
        End Function
#End Region

    End Class
End Namespace
