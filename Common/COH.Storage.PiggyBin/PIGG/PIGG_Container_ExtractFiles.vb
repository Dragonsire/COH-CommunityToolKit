Imports System.IO
Imports COH.CodeManagement.Enums.Pigg
Imports COH.CodeManagement.Enums.Structures
Imports COH.GameContent
Imports COH.GameContent.Structures.Resources.Anim
Imports COH.GameContent.Structures.Resources.BIN
Imports COH.GameContent.Structures.Resources.GEO
Imports COH.GameContent.Structures.Resources.Other
Imports COH.GameContent.Structures.Resources.Textures
Imports COH.Storage.Containers.PIGG.Structures
Imports COH.Storage.Containers.PIGG.Structures.Contents
Imports COH.Storage.Serialization
Imports COH.Storage.Structures

Namespace Storage.Containers.PIGG
    Partial Public Class PIGG_Container

#Region "Extract PiggInfo"
        Public Shared Function Identify_SlotType(ByRef FileName As String) As COH_Supported_ContentType
            Dim Result = PIGG_Container_SlotTypes.Unknown
            Dim EXT As String = IO.Path.GetExtension(FileName).ToUpper
            If EXT = ".TEXTURE" Or EXT = ".DDS" Then
                Return COH_Supported_ContentType.Resource_Texture
            ElseIf EXT = ".BIN" Then
                Return COH_Supported_ContentType.Resource_BIN_CrypticS
            ElseIf EXT = ".GEO" Then
                Return COH_Supported_ContentType.Resource_GEO
            ElseIf EXT = ".ANIM" Then
                Return COH_Supported_ContentType.Resource_ANIMATION
            ElseIf EXT = ".TGA" Then
                Return COH_Supported_ContentType.Resource_TGA
            Else
                Return COH_Supported_ContentType.Unknown
            End If
            Return True
        End Function
#End Region

#Region "Extract All Files"
        Event ProgressUpdate(EventType As COH_Event_ProgressUpdate.COH_ProgressEvent, UpdateAmount As Double, Message As String)
        Private Sub ShowProgressUpdate(EventType As COH_Event_ProgressUpdate.COH_ProgressEvent, Optional UpdateAmount As Double = 0, Optional Message As String = Nothing)
            RaiseEvent ProgressUpdate(EventType, UpdateAmount, Message)
        End Sub
        Private Function Extract_AllEntries_ToDirectory(RootPath As String, Optional ProcessEntry As Boolean = False) As Boolean
            ShowProgressUpdate(COH_Event_ProgressUpdate.COH_ProgressEvent.Begin, Directories.Count, "Extracting PIGG - " & FileName)
            rCurrentReader.Settings.Option_SelectedFormat = COH_ExportFormat.Binary
            For X = 0 To Directories.Count - 1
                ShowProgressUpdate(COH_Event_ProgressUpdate.COH_ProgressEvent.Update, 1, "Extracting PIGG - " & StringTable.Items(X))
                Dim DestinationFile As String = DeterminePath(RootPath, X)
                Dim Result As Byte() = Nothing
                Dim ResultSlot As Contents.COH_PIGG_SlotTableEntry = Nothing
                If Extract_RawEntry(X, Result, ResultSlot) = False Then Return False
                If Not Result Is Nothing Then
                    WriteData(Result, DestinationFile)
                    If ProcessEntry = True Then
                        Dim ResourceResult As COH_FileStructure = Nothing
                        If ConvertRawData_ToResource(Result, X, ResourceResult) = True Then
                            ResourceResult.Export_To_File(IO.Path.GetFileNameWithoutExtension(DestinationFile) & "." & ResourceResult.Default_BinaryExtention, IO.Path.GetDirectoryName(DestinationFile), COH_StreamFormat.Binary)
                        End If
                    End If
                    If Directories(X).SecondarySlotIndex >= 0 Then
                        Dim SlotFile As String = DestinationFile & "_Slot.raw"
                        WriteData_Slot(ResultSlot, SlotFile)
                    End If
                Else
                    ShowErrorOccured("Nothing Extracted : " & DestinationFile)
                End If
            Next
            ShowProgressUpdate(COH_Event_ProgressUpdate.COH_ProgressEvent.Finish, Directories.Count, "Extracting PIGG - " & FileName)
            Return True
        End Function
        Private Function DeterminePath(RootPath As String, Index As Int32) As String
            Dim FilePath As String = RootPath & StringTable.Items(Directories(Index).Index).ToString.Replace("/", "\")
            FilePath = FilePath.Replace(ChrW(0), "")
            'Dim L1 As String = FilePath.Length
            If File.Exists(FilePath) = True Then IO.File.Delete(FilePath)
            Dim Folder As String = IO.Path.GetDirectoryName(FilePath)
            If IO.Directory.Exists(Folder) = False Then IO.Directory.CreateDirectory(Folder)
            Return FilePath
        End Function
#End Region

#Region "Extract Single Files"
        Private Function Extract_Entry(Index As Integer, ByRef Result As COH_FileStructure) As Boolean
            Dim RawBytes As Byte() = Nothing
            Dim ResultSlot As COH_PIGG_SlotTableEntry = Nothing
            If Extract_RawEntry(Index, RawBytes, ResultSlot) Then
                Return ConvertRawData_ToResource(RawBytes, Index, Result)
            End If
            Return True
        End Function
        Private Function Extract_RawEntry(Index As Integer, ByRef Result As Byte(), ByRef Slot As COH_PIGG_SlotTableEntry) As Boolean
            Result = Extract_RawData(Index, Directories(Index).IsCompressed)
            If Directories(Index).SecondarySlotIndex >= 0 Then
                Slot = SlotTable.Items(Directories(Index).SecondarySlotIndex)
            Else
                Slot = Nothing
            End If
            Return True
        End Function
        Private Function Extract_RawData(Index As Int32, Optional Decompress As Boolean = False) As Byte()
            rCurrentReader.BaseStream.Position = Directories(Index).File_Offset
            If Decompress = True And Directories(Index).File_Size_Compressed > 0 Then
                Return HelperFunctions.Compression.DecompressBytes(rCurrentReader.ReadBytes(Directories(Index).File_Size_Stored))
            Else
                Return rCurrentReader.ReadBytes(Directories(Index).File_Size_Stored)
            End If
        End Function
#End Region

#Region "Process Raw Data"
        Private Function ConvertRawData_ToResource(ByRef RawBytes As Byte(), Index As Integer, ByRef Result As COH_FileStructure) As Boolean
            Select Case Directories(Index).EntryType
                Case COH_Supported_ContentType.Resource_Texture
                    Return ConvertRawData_ToResource_Texture(RawBytes, Result)
                Case COH_Supported_ContentType.Resource_BIN_CrypticS
                    Return ConvertRawData_ToResource_BIN(RawBytes, Result)
                Case COH_Supported_ContentType.Resource_GEO
                    Return ConvertRawData_ToResource_GEO(RawBytes, Result)
                Case COH_Supported_ContentType.Resource_ANIMATION
                    Return ConvertRawData_ToResource_ANIM(RawBytes, Result)
                Case COH_Supported_ContentType.Resource_TGA
                    Return ConvertRawData_ToResource_TGA(RawBytes, Result)
                Case COH_Supported_ContentType.Unknown
                    Return ConvertRawData_ToResource_Unknown(RawBytes, Result)
                Case Else
                    Return False
            End Select
        End Function
        Private Function ConvertRawData_ToResource_TGA(ByRef RawBytes As Byte(), ByRef Result As COH_FileStructure) As Boolean
            Dim NewResource As New COH_Resource_TGA()
            NewResource.Update_FromBytes(RawBytes)
            Result = NewResource
            Return True
        End Function
        Private Function ConvertRawData_ToResource_Texture(ByRef RawBytes As Byte(), ByRef Result As COH_FileStructure) As Boolean
            Dim NewResource As New COH_Resource_Texture()
            NewResource.Update_FromBytes(RawBytes)
            Result = NewResource
            Return True
        End Function
        Private Function ConvertRawData_ToResource_BIN(ByRef RawBytes As Byte(), ByRef Result As COH_FileStructure) As Boolean
            Dim NewResource As New COH_Resource_BIN()
            NewResource.Update_FromBytes(RawBytes)
            Result = NewResource
            Return True
        End Function
        Private Function ConvertRawData_ToResource_GEO(ByRef RawBytes As Byte(), ByRef Result As COH_FileStructure) As Boolean
            Dim NewResource As New COH_Resource_GEO()
            NewResource.Import_From_Buffer(RawBytes)
            Result = NewResource
            Return True
        End Function
        Private Function ConvertRawData_ToResource_ANIM(ByRef RawBytes As Byte(), ByRef Result As COH_FileStructure) As Boolean
            Dim NewResource As New COH_Resource_Anim()
            NewResource.Import_From_Buffer(RawBytes)
            Result = NewResource
            Return True
        End Function
        Private Function ConvertRawData_ToResource_Unknown(ByRef RawBytes As Byte(), ByRef Result As COH_FileStructure) As Boolean
            Dim NewResource As New COH_Resource_Unknown()
            NewResource.Update_FromBytes(RawBytes)
            Result = NewResource
            Return True
        End Function
#End Region

#Region "Write File"
        Private Shared Function WriteData(ByRef RawBytes As Byte(), DestinationFile As String) As Boolean
            Dim CurrentStream As FileStream = New FileStream(DestinationFile, FileMode.Create)
            Try
                Using CurrentWriter As New COH_BinaryWriter(CurrentStream, Text.Encoding.ASCII)
                    CurrentWriter.Write(RawBytes)
                    CurrentWriter.Flush()
                End Using
                CurrentStream.Close()
                CurrentStream = Nothing
            Catch ex As Exception
                ShowErrorOccured_Exception(COH_Event_Error.COH_ErrorEvent.ControlledError, "Unable to Extract PIGG Entry", ex, True)
            End Try
            Return True
        End Function
        Private Shared Function WriteData_Slot(Entry As COH_PIGG_SlotTableEntry, DestinationFile As String) As Boolean
            Dim CurrentStream As FileStream
            CurrentStream = New FileStream(DestinationFile, FileMode.Create)
            Using CurrentWriter As New COH_BinaryWriter(CurrentStream, Text.Encoding.ASCII)
                Entry.WriteToStream(CurrentWriter)
                CurrentWriter.Flush()
            End Using
            Return True
        End Function
#End Region
    End Class
End Namespace