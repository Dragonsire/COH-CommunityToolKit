Namespace Storage.Controllers
    Public NotInheritable Class COH_FileStructureIndex_Controller

#Region "Properties"
        Property RegisteredFileStructures As List(Of COH_FSI_Entry)
#End Region

#Region "Initialized"
        Public Sub New()
            RegisteredFileStructures = New List(Of COH_FSI_Entry)
        End Sub
#End Region

#Region "Usage"
        Public Sub Add_ListSupportedFiles(ByRef TheItems As List(Of COH_FSI_Entry))
            RegisteredFileStructures.AddRange(TheItems)
        End Sub
#End Region

#Region "Search"
        Public Function Retrieve_SupportedType(Search As String, ByRef SupportedType As COH_FSI_Entry) As Boolean
            Return COH_FSI_Entry.Retrieve_SupportedType(RegisteredFileStructures, Search, SupportedType)
        End Function
        Public Function Retrieve_SupportedType(search As Int32, ByRef SupportedType As COH_FSI_Entry) As Boolean
            Return COH_FSI_Entry.Retrieve_SupportedType(RegisteredFileStructures, search, SupportedType)
        End Function
#End Region

    End Class
End Namespace
