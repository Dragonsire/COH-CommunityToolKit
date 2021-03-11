Imports COH.CodeManagement.Enums

Namespace Controls.Menu
    Public Class ControlFreak_MenuStrip_Tag
        Property Visibility As SecurityRole
        Property DisablesDuringEditing As Boolean
        Public Sub New()
            Visibility = SecurityRole.User
            DisablesDuringEditing = True
        End Sub




        Public Shared Function GenerateTag_DeveloperOnly() As ControlFreak_MenuStrip_Tag
            Dim Result As New ControlFreak_MenuStrip_Tag
            Result.Visibility = SecurityRole.Developer
            Return Result
        End Function


    End Class
End Namespace