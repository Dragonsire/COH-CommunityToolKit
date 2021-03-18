Imports System.ComponentModel

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class FormsConfiguration

#Region "Properties"
        Public Property Settings As FormsConfiguration_Settings
        Public Property ColorScheme As FormsConfiguration_ColorScheme
        Public Property WindowSkin As FormsConfiguration_FormSkin
        Public Property Parenting As FormsConfiguration_Parenting
        '//Public Property Skin_DialogButtons As WindowFormsConfiguration_Skin_DialogButtons
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            If ResetDefaults = True Then ResetToDefault()
        End Sub
        Public Sub New(ByRef ParentControl As Control)
            Settings = New FormsConfiguration_Settings(ParentControl)
        End Sub
        Public Sub ResetToDefault()
            ColorScheme = New FormsConfiguration_ColorScheme
            Settings = New FormsConfiguration_Settings
            WindowSkin = New FormsConfiguration_FormSkin
            Parenting = New FormsConfiguration_Parenting
            '//Skin_DialogButtons = New WindowFormsConfiguration_Skin_DialogButtons
        End Sub
        Public Sub UpdateFromControl(ByRef SourceControl As Control)
            Settings.UpdateSettings_FromControl(SourceControl)
        End Sub
#End Region

#Region "Clone"
        Public Function CreateClone() As FormsConfiguration
            Dim Destination As New FormsConfiguration
            CloneTo(Destination)
            Return Destination
        End Function
        Public Sub CloneTo(ByRef Destination As FormsConfiguration)
            With Destination
                .ColorScheme = ColorScheme.CreateClone
                .Settings = Settings.CreateClone
                If Not (WindowSkin Is Nothing) Then .WindowSkin = WindowSkin.CreateClone
                If Not (Parenting Is Nothing) Then .Parenting = Parenting.CreateClone
            End With
        End Sub
#End Region

    End Class
End Namespace