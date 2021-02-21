Imports COH.GameContent.Resources.Structures.Textures

Namespace FileStructures.PIGG.Contents
    Public Class PIGG_SlotEntry_TextureDDS
        Inherits COH_PIGG_SlotTableEntry

#Region "Properties"
        Public Overrides ReadOnly Property SlotType As Enums.SlotTypes
            Get
                Return SlotTypes.DDS_Header
            End Get
        End Property
#End Region

#Region "Private Properties"
       Private mHeader As COH_Resource_Texture_Header
#End Region

#Region "Create New Instance"
        Public Sub New()
        End Sub
        Sub New(ByRef CurrentReader As COH_BinaryReader)
            MyBase.New(CurrentReader)
        End Sub
        Public Overrides Function Extract_EntryInfo(ByRef CurrentReader As COH_BinaryReader, ExpectedSize As Integer) As Boolean
            mHeader = New COH_Resource_Texture_Header(CurrentReader)
            Return True
        End Function
        Public Overrides Function WriteToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            Return mHeader.WriteToStream(CurrentWriter)
        End Function
#End Region
    End Class
End Namespace

