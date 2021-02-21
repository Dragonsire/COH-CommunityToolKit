Namespace Structures.GEO
    Public Class COH_Resource_GEO_Model_MeshDetails
        Inherits COH_FileStructure

#Region "Properties"
        <Category("_ProjectFile")> Public Overrides ReadOnly Property InternalDisplayName As String
            Get
                Return "MeshDetails"
            End Get
        End Property
        <Category("ModelDetails")> Property Vertexs As Vector3()
        <Category("ModelDetails")> Property TriangleIndices As TriangleIndice()
        <Category("ModelDetails")> Property Normals As Vector3()
        <Category("ModelDetails")> Property Bones As GEO_Enums_MESH_BoneId()
        <Category("ModelDetails")> Property BoneWeights As Weight()
        <Category("ModelDetails")> Property BoneMatIndex As MaterialIndex()
        <Category("ModelDetails")> Property UV As Vector2()
        <Category("ModelDetails")> Property TextureNames As String()
        <Category("ModelDetails")> Property TextureSTSCounts As Integer()
#End Region

#Region "Private Properties"
#End Region

#Region "Create New Instances"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(SetDefaults As Boolean, Optional Version As Integer = 0, Optional BuildType As COH_BuildType = COH_BuildType.Either)
            MyBase.New(SetDefaults, Version)
        End Sub
        Public Overrides Sub ResetDefaults(Optional Version As Integer = 0)
            UV = New Vector2() {}
            Vertexs = New Vector3() {}
            Normals = New Vector3() {}
            TriangleIndices = New TriangleIndice() {}
            TextureSTSCounts = New Integer() {}
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As COH_Resource_GEO_Model_MeshDetails
            Dim Result As COH_Resource_GEO_Model_MeshDetails = New COH_Resource_GEO_Model_MeshDetails
            'MyBase.CloneTo(Result)
            With Result
            End With
            Return Result
        End Function
        Protected Overrides Function Read_FromStream(ByRef CurrentReader As COH_BinaryReader) As Boolean
            Throw New NotImplementedException()
        End Function
    Protected Overrides Function Write_ToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            Throw New NotImplementedException()
        End Function
#End Region
    End Class
End Namespace