Partial Public Class ToolkitController

#Region "Properties"
    Private UseCustomParentForm As Boolean
#End Region

#Region "Create ParentForm"
    'Private Function Create_ParentForm() As ControlFreak_ParentForm
    'Dim ParentFormConfiguration As WindowFormsConfiguration = ConfigureDefaultConfiguration_ParmForm()
    'Dim ParentForm As New ControlFreak_ParentForm()
    'ParentForm.ApplyConfiguration(ParentFormConfiguration, Not (ParentFormConfiguration.Skin Is Nothing), Not (ParentFormConfiguration.ColorScheme Is Nothing))
    'OnModify_ParentForm_BannerMenu(ParentForm.BannerMenu)
    'Return ParentForm
    'End Function
    'Protected Function ConfigureDefaultConfiguration_ParmForm() As WindowFormsConfiguration
    'Dim Skin As WindowFormsConfiguration_Skin = Pathways.RetrieveResource_FormSkin(Settings.Skinning_TemplateUsed)
    'If Skin Is Nothing Then Skin = Pathways.RetrieveResource_FormSkin_Default
    'Dim Result As New WindowFormsConfiguration(True)
    'Result.Skin = Skin
    'OnModify_DefaultConfiguration_ParentForm(Result)
    'Return Result
    'End Function
    'Protected Overridable Sub OnModify_DefaultConfiguration_ParentForm(ByRef DefaultConfiguration As WindowFormsConfiguration)
    'End Sub
    'Protected Sub OnModify_ParentForm_BannerMenu(ByRef BannerMenu As ControlFreak_MenuBanner)
    'End Sub
#End Region
End Class