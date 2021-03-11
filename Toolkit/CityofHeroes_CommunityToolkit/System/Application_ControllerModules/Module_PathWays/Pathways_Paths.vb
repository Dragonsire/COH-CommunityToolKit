Imports COH.ControllerModules.Pathways

Namespace ControllerModules
    Partial Public NotInheritable Class ControllerModule_Pathways

#Region "Search"
        Public Function RetrievePath(ByVal ID As String) As String
            Dim Found As DS_PathwaysCollectionEntry = Nothing
            Dim Result As String = ""
            If pPaths.Check_Contains(ID, Found) = True Then
                Result = IO.Path.Combine(RootPath, Found.RelativePath)
            End If
            Return Result
        End Function
        Public Function RetrievePath(ByRef Found As DS_PathwaysCollectionEntry) As String
            Return IO.Path.Combine(RootPath, Found.RelativePath)
        End Function
        Public Function RetrieveEntry(ID As String) As DS_PathwaysCollectionEntry
            Dim Found As DS_PathwaysCollectionEntry = Nothing
            If pPaths.Check_Contains(ID, Found) = True Then
                Return Found
            Else
                Return Nothing
            End If
        End Function
#End Region
    End Class
End Namespace
