Namespace Toolkit.ControllerModules
    Public NotInheritable Class ControllerModule_WindowManager
        Inherits ControllerModule

#Region "Properties"
        Public ReadOnly Property ListWindows_InUse As List(Of Form)
            Get
                Return rUIController.ListWindows_InUse
            End Get
        End Property
        Public ReadOnly Property UIController As WindowForms.UIController
            Get
                Return rUIController
            End Get
        End Property
        Public ReadOnly Property Dialog_ProgramName As String
            Get
                Return pDialog_ProgramName
            End Get
        End Property
        Private pDialog_ProgramName As String
        Private rUIController As WindowForms.UIController
#End Region

#Region "Create New Instance"
        Public Sub New(ByRef ParentController As ToolkitController)
            MyBase.New(ParentController)
        End Sub
        Public Sub ConfigureModule(ByRef DefaultParent As Control)
            rUIController = New WindowForms.UIController(DefaultParent)
            Dim DefaultConfiguration = ConfigureDefaultConfiguration_ChildForms()
            'rUIController.Update_Configuration(DefaultConfiguration)
            rUIController.Update_FromSettings(ParentController.Settings)
        End Sub
        Private Function ConfigureDefaultConfiguration_ChildForms() 'As WindowFormsConfiguration
            'Dim Skin As WindowFormsConfiguration_Skin = ParentController.Pathways.RetrieveResource_FormSkin(ParentController.Settings.Skinning_TemplateUsed)
            'If Skin Is Nothing Then Skin = ParentController.Pathways.RetrieveResource_FormSkin_Default
            'Dim Result As New WindowFormsConfiguration(True)
            'Result.Skin = Skin
            'Return Result
        End Function
#End Region
    End Class
End Namespace
