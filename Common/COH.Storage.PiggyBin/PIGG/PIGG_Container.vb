Imports COH.Storage.Containers.PIGG.Structures
Imports COH.Storage.Serialization

Namespace Storage.Containers.PIGG
    Public Class PIGG_Container
        Implements IDisposable

#Region "Properties"
        Public Property ContainerName As String
            Get
                Return pContainerName
            End Get
            Set(value As String)
                pContainerName = value
            End Set
        End Property
        Public Property FileHeader As COH_PIGG_FileHeader
            Get
                Return pHeader
            End Get
            Set(value As COH_PIGG_FileHeader)
                pHeader = value
            End Set
        End Property
        Public Property Directories As List(Of COH_PIGG_DirectoryEntry)
            Get
                Return pDirectories
            End Get
            Set(value As List(Of COH_PIGG_DirectoryEntry))
                pDirectories = value
            End Set
        End Property
        Public Property StringTable As COH_PIGG_StringTable
            Get
                Return pStringTable
            End Get
            Set(value As COH_PIGG_StringTable)
                pStringTable = value
            End Set
        End Property
        Public Property SlotTable As COH_PIGG_SlotTable
            Get
                Return pSlotTable
            End Get
            Set(value As COH_PIGG_SlotTable)
                pSlotTable = value
            End Set
        End Property
        Public ReadOnly Property FileName As String
            Get
                Return pFileName
            End Get
        End Property
        Private pContainerName As String
        Private pFileName As String
        Private pHeader As COH_PIGG_FileHeader
        Private pDirectories As List(Of COH_PIGG_DirectoryEntry)
        Private pStringTable As COH_PIGG_StringTable
        Private pSlotTable As COH_PIGG_SlotTable
        Private DisposedValue As Boolean
        '// Private rCurrentReader As COH_BinaryReader
        Private pValid As Boolean
#End Region

#Region "Create New Instance"
        Sub New()
            pContainerName = "NewContainer"
        End Sub
        Sub New(Name As String)
            pContainerName = Name
        End Sub
#End Region

#Region "Open Existing PIGG File"
        Public Function OpenExisting_PiggFile(FilePath As String) As Boolean
            If IO.File.Exists(FilePath) = False Then
                Throw New IO.FileNotFoundException("PIGG File Was Not Found", FilePath)
                Return False
            End If
            Dim CurrentStream As New IO.FileStream(FilePath, IO.FileMode.Open)
            Using CurrentReader As New COH_BinaryReader(CurrentStream, Text.Encoding.ASCII)
                pValid = OpenExisting_PiggFile_FromStream(CurrentReader)
            End Using
            CurrentStream = Nothing
            Return pValid
        End Function
        Private Function OpenExisting_PiggFile_FromStream(ByRef CurrentReader As COH_BinaryReader) As Boolean
            If COH_PIGG_FileHeader.CreateFromStream(CurrentReader, pHeader) = False Then Return False
            pDirectories = New List(Of COH_PIGG_DirectoryEntry)
            Dim NewItem As COH_PIGG_DirectoryEntry = Nothing
            For X = 0 To pHeader.Number_DirectoryEntries - 1
                If COH_PIGG_DirectoryEntry.CreateFromStream(CurrentReader, NewItem) = False Then Return False
                pDirectories.Add(NewItem)
            Next
            If COH_PIGG_StringTable.CreateFromStream(CurrentReader, pStringTable) = False Then Return False
            If COH_PIGG_SlotTable.CreateFromStream(CurrentReader, Me, pSlotTable) = False Then Return False
            For X = 0 To pHeader.Number_DirectoryEntries - 1
                pDirectories(X).EntryType = Identify_SlotType(pStringTable.Items(X))
            Next
            Return True
        End Function
        Public Shared Function OpenExisting_PiggFile(Name As String, FilePath As String, ByRef Result As PIGG_Container) As Boolean
            Result = New PIGG_Container(Name)
            Return Result.OpenExisting_PiggFile(FilePath)
        End Function
#End Region




#Region "Extraction"
        Public Function ExtractAllFiles_ToDirectory(RootPath As String, Optional ProcessRecord As Boolean = False, Optional ShowProgress As Boolean = False) As Boolean
            'ExtractAllFiles_ToDirectory(mCurrentReader, RootPath, mPiggInfo, ProcessRecord, ShowProgress)
            Return True
        End Function
        'Public Function ExtractEntry(Index As Integer, ByRef Result As COH_FileStructure) As Boolean
        'Return Extract_Entry(mCurrentReader, mPiggInfo, Index, Result)
        'End Function
#End Region

#Region "IDisposable Support"
        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not DisposedValue Then
                If disposing Then
                    'rCurrentReader.Close()
                    'rCurrentReader = Nothing
                End If
            End If
            Me.DisposedValue = True
        End Sub
        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace