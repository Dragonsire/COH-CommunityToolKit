Imports System.Xml.Serialization
Imports COH.GameContent.Internal.Structures

Partial Public Class COH_CrypticS

#Region "Read Structures Parse7"
    Public Function Import_FromStream_Parse7(ByRef CurrentReader As COH_BinaryReader, Optional ShowProgress As Boolean = False) As Boolean
        mParseVersionUsed = COH_Supported_CrypticS_ParseVersion.Parse7
        CurrentReader.Settings.Argument = CurrentReader.Read_CrypticS_String_Parse7BIN
        CurrentReader.Settings.Option_Version = 7
        Entries = New List(Of COH_CrypticS_FileEntry)
        Return Create_FromStream_RootSections(CurrentReader, ShowProgress)
    End Function
#End Region
End Class
