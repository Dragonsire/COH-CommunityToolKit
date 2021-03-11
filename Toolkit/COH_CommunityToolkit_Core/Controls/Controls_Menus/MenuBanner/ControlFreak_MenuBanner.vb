Namespace  Controls.Menu
    Public Class ControlFreak_MenuBanner

#Region "Properties"

#End Region




#Region "Menus - Main"
        Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) ' Handles ExitToolStripMenuItem.Click
            System.Environment.Exit(0)
        End Sub
#End Region
#Region "Menus - About"
        Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) 'Handles AboutToolStripMenuItem.Click
            UpdateCursor(True)
            '//ContentController.Instance.OpenAboutBox()
            UpdateCursor(False)
        End Sub
#End Region
#Region "Cursor"
        Private Sub UpdateCursor(Wait As Boolean)
            If Wait = True Then
                Cursor.Current = Cursors.WaitCursor
                UseWaitCursor = True
                ParentForm.UseWaitCursor = True
            Else
                Cursor.Current = Cursors.Default
                UseWaitCursor = False
                ParentForm.UseWaitCursor = False
            End If
        End Sub
#End Region
    End Class
End Namespace