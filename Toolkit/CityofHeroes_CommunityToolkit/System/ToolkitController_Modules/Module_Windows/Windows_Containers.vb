Namespace Toolkit.ControllerModules
    Partial Public NotInheritable Class ControllerModule_WindowManager

#Region "Containers - PIGGs"
        Public Sub OpenContainer_PIGG(FileSource As String)

            Dim NewControl = New TextBox
            NewControl.Text = "This is a test"

            '''Dim NewControl = Create_Control_PiggView(FileSource)
            Dim NewForm = UIController.CreateToolWindow_ForControl(NewControl, False)
            UIController.OpenDialog(NewForm)

            'Dim TEST = COH.Controls.Configuration.FormsConfiguration_FormSkin.LoadTheme_FromFolder("E:\Project_COH_ToolKit\Tools\Skins\DS_Skin_Default\")
            'Dim CreateTestForm As New COH.Controls.ToolkitForm
            'CreateTestForm.Text = "New Window"
            'CreateTestForm.UpdateSkin(TEST, True)
            'CreateTestForm.Show()
            '//CreateTestForm.Enabled = False


            Exit Sub



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