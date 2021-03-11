Imports System.Drawing

Namespace  Toolkit.Controls.Menu
    Partial Public NotInheritable Class COH_Toolkit_MenuStrip

#Region "Configure Menu Items"
        Public Function CreateLinked_Root_ToolStripMenuItem(DisplayName As String, Key As String, Optional ByRef SubItems As ToolStripItem() = Nothing, Optional Tag As ControlFreak_MenuStrip_Tag = Nothing) As ToolStripMenuItem
            Dim Result As ToolStripMenuItem = New ToolStripMenuItem()
            Result.Name = Key
            Result.Size = mMenuSize_RootItems
            Result.Text = DisplayName
            '//Result.Image = Internal.EmbeddedResources.WindowDetails
            Result.ImageScaling = mImageScaling
            AddHandler Result.DropDownOpening, Sub(sender, e) RootMenuItem_DroppedDown(Result)
            AddHandler Result.DropDownClosed, Sub(sender, e) RootMenuItem_DropDownClosed(Result)
            If Not (SubItems Is Nothing) Then
                Result.DropDownItems.AddRange(SubItems)
            Else
                AddHandler Result.Click, Sub(sender, e) MenuItem_Clicked(Result)
            End If
            If (Tag Is Nothing) Then Tag = New ControlFreak_MenuStrip_Tag
            Result.Tag = Tag
            'Result.Visible = (Tag.Visibility = SecurityRole.User)
            Return Result
        End Function
        Public Function CreateLinked_MenuItem_ToolStripMenuItem(DisplayName As String, Key As String, Optional SubItems As ToolStripItem() = Nothing, Optional Tag As ControlFreak_MenuStrip_Tag = Nothing) As ToolStripMenuItem
            Dim Result As New ToolStripMenuItem
            With Result
                .Name = Key.ToString
                .Size = mMenuSize_DropDownItems
                .Text = DisplayName
                If (Tag Is Nothing) Then Tag = New ControlFreak_MenuStrip_Tag
                .Tag = Tag
                '.Visible = (Tag.Visibility = SecurityRole.User)
                If Not (SubItems Is Nothing) Then
                    Result.DropDownItems.AddRange(SubItems)
                Else
                    AddHandler Result.Click, Sub(sender, e) MenuItem_Clicked(Result)
                End If
            End With
            Return Result
        End Function
#End Region

#Region "Events"
        Public Event MenuClicked(ID As String)
        Private Sub RootMenuItem_DroppedDown(ByRef Menu As ToolStripMenuItem)
            SetMenu_Colors_Selected(Menu, True)
        End Sub
        Private Sub RootMenuItem_DropDownClosed(ByRef Menu As ToolStripMenuItem)
            SetMenu_Colors_Selected(Menu, False)
        End Sub
        Private Sub SetMenu_Colors_Selected(Menu As ToolStripMenuItem, Optional Opening As Boolean = False)
            If Opening = True Then
                Menu.ForeColor = mColor_Background_Menu_Selected
            Else
                Menu.ForeColor = mColor_ForeGround_Menu_NotSelected
            End If
        End Sub
        Private Sub MenuItem_Clicked(ByRef Menu As ToolStripMenuItem)
            Mouse_ShowWait()
            RaiseEvent MenuClicked(Menu.Name)
            '//Threading.Thread.Sleep(5000)
            If Me.IsDisposed = False Then Mouse_ShowReady()
        End Sub
#End Region

#Region "Cursor Events"
        Private MouseWaitCount As Integer
        Private Sub Mouse_ShowWait()
            MouseWaitCount += 1
            If MouseWaitCount >= 1 Then Cursor.Current = Cursors.WaitCursor
        End Sub
        Private Sub Mouse_ShowReady()
            MouseWaitCount -= 1
            If MouseWaitCount = 0 Then Cursor.Current = Cursors.Default
        End Sub
#End Region
    End Class
End Namespace
