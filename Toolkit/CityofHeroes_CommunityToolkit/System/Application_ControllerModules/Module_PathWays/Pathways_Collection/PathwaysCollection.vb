Imports System.Collections.ObjectModel
Imports COH.CodeManagement.Enums

Namespace ControllerModules.Pathways
    Public NotInheritable Class DS_PathwaysCollection
        Inherits Collection(Of DS_PathwaysCollectionEntry)

#Region "Properties"
        Public ReadOnly Property RootPath As String
            Get
                Return pRoot
            End Get
        End Property
        Private pRoot As String
#End Region

#Region "Create New Instance"
        Public Sub New(RootPath As String)
            MyBase.New()
            pRoot = RootPath
        End Sub
        Public Sub New(RootPath As String, list As IList(Of DS_PathwaysCollectionEntry))
            MyBase.New(list)
            pRoot = RootPath
        End Sub
#End Region

#Region "Usage - Add/Remove/Insert"
        Public Sub Pathway_AddRange(ByVal values As List(Of DS_PathwaysCollectionEntry))
            For Each Entry In values
                MyBase.Add(Entry)
            Next
        End Sub
#End Region

#Region "Add Resources"
        Public Sub AddResource(UniqueID As String, Type As CF_Enum_PathwayType, FileLocation As String)
            MyBase.Add(New DS_PathwaysCollectionEntry(UniqueID, MakePath_Relative(FileLocation), Type))
        End Sub
        Public Sub AddAllFileResources_FromFolder(Folder As String, Type As CF_Enum_PathwayType, SearchPattern As String, DirectorySearch As IO.SearchOption)
            For Each Entry In IO.Directory.GetFiles(Folder, SearchPattern, DirectorySearch)
                AddResource(IO.Path.GetFileNameWithoutExtension(Entry), Type, MakePath_Relative(Entry))
            Next
        End Sub
        Public Sub AddAllFolderResources_FromFolder(Folder As String, Type As CF_Enum_PathwayType, SearchPattern As String, DirectorySearch As IO.SearchOption)
            For Each Entry In IO.Directory.GetDirectories(Folder, SearchPattern, DirectorySearch)
                AddResource(GetFolderName(Entry), Type, MakePath_Relative(Entry))
            Next
        End Sub
        Private Function GetFolderName(Source As String) As String
            Dim FileSplit As String() = Split(Source, "\")
            Dim Parent As String = FileSplit(FileSplit.Length - 1)
            If String.IsNullOrEmpty(Parent) = True OrElse Parent = "\" Then Parent = FileSplit(FileSplit.Length - 2)
            If String.IsNullOrEmpty(Parent) = True OrElse Parent = "\" Then Parent = FileSplit(FileSplit.Length - 3)
            Return Parent.Replace("\", "")
        End Function
        Private Function MakePath_Relative(Source As String) As String
            If Not Source.Contains(":") Then Return Source
            Return IO.Path.GetRelativePath(RootPath, Source)
        End Function
#End Region

#Region "Search"
        Public Function Check_Contains(ByVal ID As String, ByRef Found As DS_PathwaysCollectionEntry) As Boolean
            For Each Entry In Items
                If Entry.ID = ID Then
                    Found = Entry
                    Return True
                End If
            Next
            Return False
        End Function
        Public Function RetrieveAll(SelectedType As CF_Enum_PathwayType) As List(Of DS_PathwaysCollectionEntry)
            Dim Result As New List(Of DS_PathwaysCollectionEntry)
            For Each Entry In Items
                If Entry.Type = SelectedType Then Result.Add(Entry)
            Next
            Return Result
        End Function
#End Region
    End Class
End Namespace
