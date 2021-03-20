Imports COH.CodeManagement.Enums.Toolkit

Namespace Controls.Configuration
    Partial Public NotInheritable Class FormsConfiguration_FormSkin

#Region "Check Locations"
        Public Function Check_MouseOverAnyButton(MouseLocation As Point, ByRef ButtonSelected As FormSkinRegion_ImageRegion_Hilitable) As Boolean
            ButtonSelected = Button_Min : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            ButtonSelected = Button_Max : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            ButtonSelected = Button_Close : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            Return False
        End Function
        Public Function Check_MouseOverMoveBar(MouseLocation As Point) As Boolean
            If TitleBar.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            Return False
        End Function
        Public Function Check_MouseOverEdge(MouseLocation As Point, Optional ForResize As Boolean = True) As Boolean
            If ForResize = False Then If Edge_Left.Check_MouseLocation_WithinDrawArea(MouseLocation) Then Return True
            If Edge_Right.Check_MouseLocation_WithinDrawArea(MouseLocation) Then Return True
            If Edge_Bottom.Check_MouseLocation_WithinDrawArea(MouseLocation) Then Return True
            Return False
        End Function
        Public Function Check_MouseOverAnyDialogButton(MouseLocation As Point, ByRef ButtonSelected As FormSkinRegion_ImageRegion_Hilitable) As Boolean
        End Function
#End Region

#Region "CalculateLocations"
        Public Sub Calculate_DrawableLocations(ClientRectangle As Rectangle)
            TitleBar.Update_DrawingLocation(New Rectangle(New Point(Corner_TopLeft.ImageState_Normal.Width, 0), New Size(ClientRectangle.Width - (Corner_TopRight.ImageState_Normal.Width + Corner_TopLeft.ImageState_Normal.Width), TitleBar.ImageState_Normal.Height)))
            Corner_TopLeft.Update_DrawingLocation(New Rectangle(New Point(0, 0), Corner_TopLeft.ImageState_Normal.Size))
            Corner_TopRight.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - Corner_TopRight.ImageState_Normal.Size.Width, 0), Corner_TopRight.ImageState_Normal.Size))
            Edge_Left.Update_DrawingLocation(New Rectangle(New Point(0, Corner_TopLeft.ImageState_Normal.Height), New Size(Edge_Left.ImageState_Normal.Size.Width, ClientRectangle.Height - (Corner_TopLeft.ImageState_Normal.Height + Corner_BottomLeft.ImageState_Normal.Height))))
            Edge_Right.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - Corner_TopRight.ImageState_Normal.Size.Width, Corner_TopRight.ImageState_Normal.Height), New Size(Edge_Right.ImageState_Normal.Size.Width, ClientRectangle.Height - (Corner_TopRight.ImageState_Normal.Height + Corner_BottomRight.ImageState_Normal.Height))))
            Edge_Bottom.Update_DrawingLocation(New Rectangle(New Point(Corner_BottomLeft.ImageState_Normal.Width, ClientRectangle.Height - Edge_Bottom.ImageState_Normal.Height), New Size(ClientRectangle.Width - (Corner_BottomLeft.ImageState_Normal.Width + Corner_BottomLeft.ImageState_Normal.Width), Edge_Bottom.ImageState_Normal.Height)))
            Corner_BottomLeft.Update_DrawingLocation(New Rectangle(New Point(0, ClientRectangle.Height - Corner_BottomLeft.ImageState_Normal.Height), Corner_BottomLeft.ImageState_Normal.Size))
            Corner_BottomRight.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - Corner_BottomRight.ImageState_Normal.Size.Width, ClientRectangle.Height - Corner_BottomRight.ImageState_Normal.Height), Corner_BottomRight.ImageState_Normal.Size))
            Icon.Update_DrawingLocation(New Rectangle(Corner_TopLeft.ImageState_Normal.Width, 0, TitleBar.ImageState_Normal.Height - 0, TitleBar.ImageState_Normal.Height))
            Button_Close.Update_DrawingLocation(New Rectangle(New Point(Corner_TopRight.Location.Left - Button_Close.ImageState_Normal.Size.Width, 0), Button_Close.ImageState_Normal.Size))
            Button_Max.Update_DrawingLocation(New Rectangle(New Point(Button_Close.Location.Left - Button_Max.ImageState_Normal.Size.Width, 0), Button_Max.ImageState_Normal.Size))
            Button_Min.Update_DrawingLocation(New Rectangle(New Point(Button_Max.Location.Left - Button_Min.ImageState_Normal.Size.Width, 0), Button_Min.ImageState_Normal.Size))
            '//pDialogButtons.Calculate_DrawableLocations(ClientRectangle, rUsableClientArea, Me)
            '//rUsableButtonArea = Rectangle.Union(Button_Min.ClientLocation, Button_Max.ClientLocation)
            '//rUsableButtonArea = Rectangle.Union(rUsableButtonArea, Button_Close.ClientLocation)
        End Sub
#End Region

#Region "Process Mouse Events"
        Public Sub ProcessMouseEvent_MouseLeave(e As EventArgs)
            Update_Buttons_Unselected(Nothing)
            'pLoadedSkin.Update_DialogButtons_Unselected("")
            rControlledForm.InvalidateWindow()
        End Sub
        Public Sub ProcessMouseEvent_MouseMove(e As MouseEventArgs)
            If rMouseLocation.Equals(e.Location) Then Exit Sub
            Dim ForceRedraw As Boolean = False
            If rIsMoving Or rIsResizing Then
                If (MouseButtons.Left And e.Button) = MouseButtons.Left Then
                    If rIsResizing Then
                        ControlledForm_Resize(e.Location)
                    ElseIf rIsMoving Then
                        ControlledForm_Move(e.Location)
                    End If
                Else
                    rMouseLocation = e.Location
                    'Process_MouseEvent_MovedOverButton(e.Location)
                    'Process_MouseEvent_MovedOverDialogButton(e.Location)
                End If
            Else
                rMouseLocation = e.Location
                If ProcessButtonEvent_MovedOverButton(e.Location) = True Then
                    ForceRedraw = True
                ElseIf Check_MouseOverEdge(e.Location, True) Then
                    If pAllowResize = True Then Cursor.Current = Cursors.SizeAll
                Else
                    Cursor.Current = Cursors.Default
                End If
                '// If Process_MouseEvent_MovedOverDialogButton(e.Location) = True Then ForceRedraw = True
            End If
            If ForceRedraw = True Then rControlledForm.InvalidateWindow()
        End Sub
        Public Sub ProcessMouseEvent_MouseDown(e As MouseEventArgs)
            rMouseLocation = e.Location
            Dim Key As String = ""
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
            If Check_MouseOverAnyButton(e.Location, Button) Then
                ProcessButtonEvent_PressedButton(Button, e.Location)
            ElseIf Check_MouseOverAnyDialogButton(e.Location, Button) Then
                'Process_MouseEvent_PressedDialogButton(Key, Button, e.Location)
            ElseIf Check_MouseOverMoveBar(e.Location) Then
                If rControlledForm.WindowState = FormWindowState.Maximized Then Exit Sub
                rIsMoving = True
            ElseIf pAllowResize = True AndAlso Check_MouseOverEdge(e.Location, True) Then
                If rControlledForm.WindowState = FormWindowState.Maximized Then Exit Sub
                rIsResizing = True
                Cursor.Current = Cursors.SizeAll
            End If
        End Sub
        Public Sub ProcessMouseEvent_MouseUp(e As MouseEventArgs)
            rMouseLocation = e.Location
            Dim WasMoving As Boolean = rIsMoving
            rIsMoving = False : rIsResizing = False
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
            Dim Key As String = ""
            Update_Buttons_Unselected(Nothing)
            'pLoadedSkin.Update_DialogButtons_Unselected("")
            If Check_MouseOverAnyButton(e.Location, Button) = True Then
                rControlledForm.InvalidateWindow()
                ControlledForm_Trigger_ButtonPressed(Button)
            End If
            If Check_MouseOverAnyDialogButton(e.Location, Button) = True Then
                rControlledForm.InvalidateWindow()
                'ControlledForm_Trigger_DialogButtonPressed(Key)
            End If
        End Sub
        Public Sub ProcessMouseEvent_MouseHover(e As EventArgs)
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
            If Check_MouseOverAnyButton(rMouseLocation, Button) = False Then Exit Sub
            'ToolTip_Update(Button.UniqueKey, Button.ToolTip_String, rMouseLocation)
        End Sub
        Private Sub UpdateButtons_Unselect()
        End Sub
#End Region

#Region "Process Button Events"
        Private Sub ProcessButtonEvent_PressedButton(Button As FormSkinRegion_ImageRegion_Hilitable, Location As Point)
            If rMouseLastPosition_WasOverButon = False Then
                Update_Button_Pressed(Button)
            Else
                Update_Button_Pressed(Button)
            End If
            rMouseLastPosition_WasOverButon = True
            rMouseLastButon = Button
            rControlledForm.InvalidateButtons()
        End Sub
        Private Function ProcessButtonEvent_MovedOverButton(Location As Point) As Boolean
            Dim ShouldDraw As Boolean = False
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
            If Check_MouseOverAnyButton(Location, Button) Then
                If rMouseLastPosition_WasOverButon = False Then
                    Update_Button_Hilited(Button)
                    ShouldDraw = True
                ElseIf Not (rMouseLastButon Is Button) Then
                    Update_Button_Hilited(Button)
                    ShouldDraw = True
                End If
                rMouseLastPosition_WasOverButon = True : rMouseLastButon = Button
                rMouseLastPosition_WasOverDialogButon = False ': rMouseLastKey = String.Empty
            Else
                If rMouseLastPosition_WasOverButon = True Then
                    Update_Buttons_Unselected(Nothing)
                    ShouldDraw = True
                End If
                rMouseLastPosition_WasOverButon = False : rMouseLastButon = Button
            End If
            Return ShouldDraw
        End Function
#End Region

#Region "Process Dialog Buttons"
        Private Sub ProcessButtonEvent_PressedDialogButton(SelectedButton As String, Button As FormSkinRegion_ImageRegion_Hilitable, Location As Point)
            If rMouseLastPosition_WasOverButon = False Then
                'pLoadedSkin.Update_DialogButton_Pressed(SelectedButton)
            Else
                'pLoadedSkin.Update_DialogButton_Pressed(SelectedButton)
            End If
            rMouseLastPosition_WasOverButon = True
            'rMouseLastButon = FormRegionArea.DialogButtons
            'InvalidateRegion_DialogButton(Button)
        End Sub
        Private Sub ProcessButtonEvent_MovedOverDialogButton(Location As Point)
            ' If pLoadedSkin.WindowSkin_DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.None Then Exit Sub
            Dim ShouldDraw As Boolean = False
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
            If Check_MouseOverAnyDialogButton(Location, Button) Then
                If rMouseLastPosition_WasOverDialogButon = False Then
                    ' pLoadedSkin.Update_DialogButton_Hilited(SelectedButton)
                    ShouldDraw = True
                    'ElseIf Not (rMouseLastKey = SelectedButton) Then
                    '    pLoadedSkin.Update_DialogButton_Hilited(SelectedButton)
                    '    ShouldDraw = True
                End If
                'rMouseLastPosition_WasOverButon = False : rMouseLastButon = FormRegionArea.None
                ' rMouseLastPosition_WasOverDialogButon = True : rMouseLastKey = SelectedButton
            Else
                'If rMouseLastPosition_WasOverDialogButon = True Then
                'pLoadedSkin.Update_DialogButtons_Unselected(FormRegionArea.None)
                'ShouldDraw = True
                'End If
                'rMouseLastPosition_WasOverDialogButon = False : rMouseLastKey = String.Empty
            End If
            ' If ShouldDraw = True Then InvalidateRegion_DialogButton(Button)
        End Sub
#End Region

#Region "Modifying - Button States"
        Private Sub Update_Buttons_Unselected(Except As FormSkinRegion_ImageRegion_Hilitable)
            If (Except IsNot Button_Close) Then Button_Close.Update_ImageState(CurrentImageState.Normal)
            If (Except IsNot Button_Min) Then Button_Min.Update_ImageState(CurrentImageState.Normal)
            If (Except IsNot Button_Max) Then Button_Max.Update_ImageState(CurrentImageState.Normal)
        End Sub
        Private Sub Update_Button_Hilited(Button As FormSkinRegion_ImageRegion_Hilitable)
            Button.Update_ImageState(CurrentImageState.Hilited)
            Update_Buttons_Unselected(Button)
        End Sub
        Private Sub Update_Button_Pressed(Button As FormSkinRegion_ImageRegion_Hilitable)
            Button.Update_ImageState(CurrentImageState.Pressed)
            Update_Buttons_Unselected(Button)
        End Sub
#End Region

#Region "Control Form - Move/Resize"
        Private Sub ControlledForm_Move(NewLocation As Point)
            Dim Threshold As Integer = 1
            Dim XChange As Integer = (NewLocation.X - rMouseLocation.X)
            Dim YChange As Integer = (NewLocation.Y - rMouseLocation.Y)
            Dim TXChange As Integer = If(XChange < 0, XChange * -1, XChange)
            Dim TYChange As Integer = If(YChange < 0, YChange * -1, YChange)
            If (TXChange < Threshold) AndAlso (TYChange < Threshold) Then
                Exit Sub
            Else
                Dim Destination As Point = New Drawing.Point(rControlledForm.Location.X + XChange, rControlledForm.Location.Y + YChange)
                rControlledForm.Location = Destination
            End If
        End Sub
        Private Sub ControlledForm_Resize(NewLocation As Point)
            Dim NewSize As Size = New Size(NewLocation.X + rMouseOffset.X, NewLocation.Y + rMouseOffset.Y)
            rControlledForm.Size = NewSize
        End Sub
        Private Sub ControlledForm_Trigger_ButtonPressed(ByRef SelectedButton As FormSkinRegion_ImageRegion_Hilitable)
            rMouseLastPosition_WasOverButon = False : rMouseLastPosition_WasOverDialogButon = False
            '//ToolTip_Hide()
            Select Case SelectedButton.FormRegionID
                Case FormRegions.Button_Min
                    rControlledForm.PressButton_ToggleMin()
                Case FormRegions.Button_Max
                    rControlledForm.PressButton_ToggleMax()
                Case FormRegions.Button_Close
                    rControlledForm.PressButton_Close()
                Case FormRegions.Button_Help
            End Select
        End Sub
        Private Sub ControlledForm_Trigger_DialogButtonPressed(Key As String)
            '//ToolTip_Hide()
            '// RaiseEvent DialogButtonPressed(Key)
        End Sub
#End Region
    End Class
End Namespace