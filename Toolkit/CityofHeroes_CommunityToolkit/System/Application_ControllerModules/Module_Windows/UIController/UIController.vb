Namespace ControllerModules.WindowForms
    Public NotInheritable Class UIController

#Region "Enum"
        Public Enum ControlFreak_ParentControl_Location
            Center = 0
            DockFill = 1
        End Enum
#End Region

#Region "Properties"
        Public ReadOnly Property ListWindows_InUse As List(Of Form)
            Get
                Return rFormsInUse
            End Get
        End Property
        Public ReadOnly Property Default_WindowsFormsConfiguration 'As WindowFormsConfiguration
            Get
                ' Return rDefaultConfiguration
            End Get
        End Property
        Public ReadOnly Property MainForm As Form
            Get
                Return rParentControl
            End Get
        End Property
        Public ReadOnly Property SkinningEnabled As Boolean
            Get
                Return pSkinningEnabled
            End Get
        End Property
        Public ReadOnly Property AlwaysUseSkinnedForms As Boolean
            Get
                Return pAlwaysUseSkinnedForms
            End Get
        End Property
        Public ReadOnly Property AlwaysAplyColorScheme As Boolean
            Get
                Return pAlwaysAplyColorScheme
            End Get
        End Property
        Public ReadOnly Property AlwaysForceDock As Boolean
            Get
                Return pAlwaysForceDock
            End Get
        End Property
        '//LOADED FROM SETTINGS
        Private pAlwaysForceDock As Boolean
        Private pAlwaysAplyColorScheme As Boolean
        Private pAlwaysUseSkinnedForms As Boolean
        Private pSkinningEnabled As Boolean
        '//REFERENCE
        Private rFormsInUse As List(Of Form)
        Private rParentControl As Form
        Private rParentSettings 'As WindowFormsConfiguration_Parenting
        Private rDefaultConfiguration 'As WindowFormsConfiguration
#End Region

#Region "Create New Instance"
        Public Sub New(ByRef DefaultParent As Control, DefaultParent_Area As Drawing.Rectangle)
            rFormsInUse = New List(Of Form)
            rParentControl = DefaultParent
            ' rParentSettings '= New WindowFormsConfiguration_Parenting
            rParentSettings.ParentForm = DefaultParent
            rParentSettings.ParentLocation = DefaultParent_Area
            rParentSettings.ParentFormDock = DockStyle.None
            rParentSettings.Form_StartPosition = FormStartPosition.Manual
        End Sub
#End Region

#Region "Update"
        ' Public Sub Update_Configuration(ByRef DefaultConfiguration As WindowFormsConfiguration)
        '     rDefaultConfiguration = DefaultConfiguration
        ' End Sub
        Public Sub Update_FromSettings(ByRef Settings As ApplicationController_Settings)

        End Sub
#End Region
    End Class
End Namespace