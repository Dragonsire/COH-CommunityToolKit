Namespace Toolkit
    Partial Public Class ToolkitController

#Region "Properties"
        Public ReadOnly Property EventManager() 'As Metatron_EventManager
            Get
                ' Return pMetaron
            End Get
        End Property
        Public ReadOnly Property EnableLogging As Boolean
            Get
                'Return pSettings.Enable_Logging
            End Get
        End Property
        Public ReadOnly Property UseXML_ForLogging As Boolean
            Get
                ' Return pSettings.UseXML_ForLogging
            End Get
        End Property
        'Private WithEvents pMetaron 'As Metatron_EventManager
#End Region

#Region "Initialize Logging"
        Protected Sub ConfigureEventManager()
            ' pMetaron '= Metatron_EventManager.Instance
            If EnableLogging = False Then Exit Sub
            If UseXML_ForLogging = True Then
                ' pMetaron.ConfigureNewScribe_XML(OnConfigureEventManager())
            Else
                ' pMetaron.ConfigureNewScribe_TXT(OnConfigureEventManager())
            End If
        End Sub
        Public Function OnConfigureEventManager() ' As Metatron_Configuration
            Throw New Exception("NOT YET IMPLEMENTED")
        End Function
#End Region

#Region "Events"
        ' Protected Overridable Sub ErrorOccured(ByRef e As Metatron_Event_ErrorOccured) Handles pMetaron.OnErrorOccured
        ' Select Case e.LoggingErrorLevel
        ' Case SourceLevels.Warning, SourceLevels.Information, SourceLevels.Verbose
        ' Case SourceLevels.Error
        ' Case SourceLevels.Critical
        ' End Select
        ' End Sub
#End Region
    End Class
End Namespace