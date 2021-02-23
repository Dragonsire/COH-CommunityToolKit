Namespace CodeManagement.Interfaces.Structures
    Public Interface ISupport_COH_DisplayName
        ReadOnly Property InternalDisplayName As String
    End Interface
    Public Interface ISupport_COH_LocalizeContent
        Function CreateKey(ByRef Value As String) As String
        Function CreateKey(ByRef Value As String, MessageStoreName As String) As String
        Function RetrieveLocalizedString(ByRef Search As String) As String
    End Interface
    Public Interface ISupport_COH_Localized
        Sub UpdateLocalizations(ByRef LocalizeController As ISupport_COH_LocalizeContent)
    End Interface
End Namespace