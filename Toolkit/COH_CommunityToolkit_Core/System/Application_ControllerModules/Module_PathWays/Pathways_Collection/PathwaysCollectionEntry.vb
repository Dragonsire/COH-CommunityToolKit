Imports COH.CodeManagement.Enums

Namespace ControllerModules.Pathways
    Public NotInheritable Class DS_PathwaysCollectionEntry

#Region "Properties"
        Public Property ID As String
        Public Property RelativePath As String
        Public Property Type As CF_Enum_PathwayType
        Public Property ShouldBackup As Boolean
        Public Property RecordLength As Int32
#End Region

#Region "Initialize"
        Public Sub New(Entry_ID As String, Relative_Path As String, EntryType As CF_Enum_PathwayType, Optional Should_Backup As Boolean = False)
            ID = Entry_ID
            RelativePath = Relative_Path
            Type = EntryType
            ShouldBackup = Should_Backup
            RecordLength = 0
        End Sub
        Public Sub New(Entry_ID As String, Relative_Path As String, EntryType As CF_Enum_PathwayType, Length As Int32, Optional Should_Backup As Boolean = False)
            ID = Entry_ID
            RelativePath = Relative_Path
            Type = EntryType
            ShouldBackup = Should_Backup
            RecordLength = Length
        End Sub
        Public Overrides Function ToString() As String
            Return ID
        End Function
#End Region
    End Class
End Namespace
