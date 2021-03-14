Namespace Toolkit.ControllerModules
    Partial Public NotInheritable Class ControllerModule_WindowManager

#Region "Containers - PIGGs"
        Public Sub OpenContainer_PIGG(FileSource As String)
            Dim NewControl = Create_Control_PiggView(FileSource)
            '//WrapControl Here
            'Open Window
        End Sub
        Private Function Create_Control_PiggView(FileSource As String) As Controls.ContainerTools.ContainerTools_PiggView
            Dim NewControl As New Controls.ContainerTools.ContainerTools_PiggView
            NewControl.Prepare_Editor(FileSource)
            Return NewControl
        End Function
#End Region




    End Class
End Namespace