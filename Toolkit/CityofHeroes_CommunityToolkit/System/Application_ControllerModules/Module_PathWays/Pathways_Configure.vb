Imports COH.ControllerModules.Pathways

Namespace ControllerModules
    Partial Public NotInheritable Class ControllerModule_Pathways

#Region "Registry"
        Private Function OnConfigureRegistry(ProgramFolder As String, DefaultFolderName As String) As ControllerModule_PathwaysRegistry
            Dim Result As New ControllerModule_PathwaysRegistry(ProgramFolder)
            With Result
                '// .InstalledPath 
                '// 
            End With
            Return Result
        End Function
#End Region

#Region "Configure Folder Paths"
        Private Function OnConfigurePathways() As List(Of DS_PathwaysCollectionEntry)
            Dim Result As New List(Of DS_PathwaysCollectionEntry)
            '// Result.Add(New ControllerModule_PathwaysEntry(MBT_XRS_DataStructure.Data.ToString, "Data\", PathwayTypeEnum.Folder))
            Return Result
        End Function
        Private Sub OnConfigurePathwaysResources()
            '// AddAllFolderResources_FromFolder(RetrievePath(MBT_XRS_DataStructure.Resources_Skin.ToString), PathwayTypeEnum.Folder_Skin, "", IO.SearchOption.TopDirectoryOnly)
        End Sub
#End Region
    End Class
End Namespace