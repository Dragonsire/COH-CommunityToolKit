Imports COH.Storage.PiggyBin.Enums

Namespace FileStructures.PIGG.Contents
    Public Class PIGG_SlotEntry_Geo
        Inherits COH_PIGG_SlotTableEntry

#Region "Properties"
        Public Overrides ReadOnly Property SlotType As SlotTypes
            Get
                Return SlotTypes.GEO
            End Get
        End Property
#End Region

#Region "Private Properties"
        Private mRawBytes As Byte()
#End Region

#Region "Create New Instance"
        Public Sub New()
        End Sub
        Sub New(ByRef CurrentReader As COH_BinaryReader)
            MyBase.New(CurrentReader)
        End Sub
        Public Overrides Function Extract_EntryInfo(ByRef CurrentReader As COH_BinaryReader, ExpectedSize As Integer) As Boolean
            mRawBytes = CurrentReader.ReadBytes(ExpectedSize)
            Return True
        End Function
        Public Overrides Function WriteToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            CurrentWriter.Write(mRawBytes)
            Return True
        End Function
#End Region
    End Class
End Namespace