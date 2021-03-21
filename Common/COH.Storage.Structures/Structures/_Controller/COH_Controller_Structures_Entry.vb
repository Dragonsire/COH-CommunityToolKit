Imports COH.CodeManagement.Enums.Structures

Namespace Storage.Controllers
    Public Class COH_FSI_Entry
        Property EntryName As String
        Property ContentType As COH_Supported_ContentType = COH_Supported_ContentType.Resource_BIN_CrypticS
        Property SingleRoot As Boolean
        Property BuildChecks As List(Of UInt32)
        Property Sections As List(Of COH_FSI_Section)
        Sub New()
            Sections = New List(Of COH_FSI_Section)
            BuildChecks = New List(Of UInt32)
        End Sub
        Sub New(Name As String, TheType As COH_Supported_ContentType, Optional ListIds As List(Of UInt32) = Nothing, Optional TheSections As List(Of COH_FSI_Section) = Nothing, Optional SingleOnly As Boolean = False)
            EntryName = Name
            ContentType = TheType
            SingleRoot = SingleOnly
            BuildChecks = ListIds
            Sections = TheSections
            If ListIds Is Nothing Then BuildChecks = New List(Of UInt32)
            If Sections Is Nothing Then Sections = New List(Of COH_FSI_Section)
        End Sub

#Region "Search"
        Public Shared Function Retrieve_SupportedType(ByRef RegisteredFileStructures As List(Of COH_FSI_Entry), Search As String, ByRef SupportedType As COH_FSI_Entry) As Boolean
            If RegisteredFileStructures Is Nothing Then Return False
            For Each Entry In RegisteredFileStructures
                If String.Equals(Search, Entry.EntryName, StringComparison.CurrentCultureIgnoreCase) Then
                    SupportedType = Entry
                    Return True
                End If
            Next
            Return False
        End Function
        Public Shared Function Retrieve_SupportedType(ByRef RegisteredFileStructures As List(Of COH_FSI_Entry), search As Int32, ByRef SupportedType As COH_FSI_Entry) As Boolean
            If RegisteredFileStructures Is Nothing Then Return False
            For Each Entry In RegisteredFileStructures
                For Each BUild In Entry.BuildChecks
                    If search = BUild Then
                        SupportedType = Entry
                        Return True
                    End If
                Next
            Next
            Return False
        End Function
#End Region

    End Class
End Namespace
