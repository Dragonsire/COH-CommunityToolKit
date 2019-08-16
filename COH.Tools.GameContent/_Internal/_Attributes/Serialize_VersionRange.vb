Namespace Internal.Attributes
    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Class)>
    Public Class COH_VersionRange
        Inherits System.Attribute

        Public Const MAX_PARSEVERSION = 7
        Property MinVersion As Integer
        Property MaxVersion As Integer
        Property Build As GameContent.Structures.COH_Struct.COH_BuildType

        Public Sub New()
            MinVersion = 0
            MaxVersion = 6
            Build = GameContent.Structures.COH_Struct.COH_BuildType.Either
        End Sub
        Public Sub New(Min_Version As Integer)
            MinVersion = Min_Version
            MaxVersion = MAX_PARSEVERSION
            Build = GameContent.Structures.COH_Struct.COH_BuildType.Either
        End Sub
        Public Sub New(Min_Version As Integer, Max_Version As Integer, Optional ForBuild As GameContent.Structures.COH_Struct.COH_BuildType = GameContent.Structures.COH_Struct.COH_BuildType.Either)
            MinVersion = Min_Version
            MaxVersion = MaxVersion
            Build = ForBuild
        End Sub
    End Class
End Namespace