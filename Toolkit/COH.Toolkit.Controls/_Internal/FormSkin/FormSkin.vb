Imports COH.Controls.FormSkinRegion_Button

Namespace Controls.Configuration
    Public NotInheritable Class FormSkin

#Region "Properties"
        Public Property TitleBar As FormSkinRegion_TitleBar
            Get
                Return pTitleBar
            End Get
            Set(value As FormSkinRegion_TitleBar)
                pTitleBar = value
            End Set
        End Property
        Public Property Button_Min As FormSkinRegion_Button
            Get
                Return pButton_Min
            End Get
            Set(value As FormSkinRegion_Button)
                pButton_Min = value
            End Set
        End Property
        Public Property Button_Max As FormSkinRegion_Button
            Get
                Return pButton_Max
            End Get
            Set(value As FormSkinRegion_Button)
                pButton_Max = value
            End Set
        End Property
        Public Property Button_Close As FormSkinRegion_Button
            Get
                Return pButton_Close
            End Get
            Set(value As FormSkinRegion_Button)
                pButton_Close = value
            End Set
        End Property
        Private WithEvents pTitleBar As FormSkinRegion_TitleBar
        Private WithEvents pButton_Min As FormSkinRegion_Button
        Private WithEvents pButton_Max As FormSkinRegion_Button
        Private WithEvents pButton_Close As FormSkinRegion_Button
        Private pAllowResize As Boolean
        Private rMouseLocation As Point
        Private rIsMoving As Boolean
        Private rIsResizing As Boolean
        Private rMouseLastPosition_WasOverButon As Boolean
        Private rMouseLastPosition_WasOverDialogButon As Boolean
        Private rMouseLastButon As FormSkinRegion_Button
#End Region




        Public Sub Updated() Handles pTitleBar.WasModified, pButton_Min.WasModified, pButton_Max.WasModified, pButton_Close.WasModified

        End Sub

#Region "Check Locations"
        Public Function Check_MouseOverAnyButton(MouseLocation As Point, ByRef ButtonSelected As FormSkinRegion_Button) As Boolean
            ButtonSelected = pButton_Min : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            ButtonSelected = pButton_Max : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            ButtonSelected = pButton_Close : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            Return False
        End Function
        Public Function Check_MouseOverAnyDialogButton(MouseLocation As Point, ByRef ButtonSelected As FormSkinRegion_Button) As Boolean
        End Function
        Public Function Check_MouseOverMoveBar(MouseLocation As Point) As Boolean
        End Function
        Public Function Check_MouseOverEdge(MouseLocation As Point) As Boolean
        End Function
#End Region

#Region "CalculateLocations"
        Public Sub Calculate_DrawableLocations(ClientRectangle As Rectangle)
            'pTitleBar.Update_DrawingLocation(New Rectangle(New Point(pCorner_TopLeft.LoadedImage.Width, 0), New Size(ClientRectangle.Width - (pCorner_TopRight.LoadedImage.Width + pCorner_TopLeft.LoadedImage.Width), pTitleBar.ButtonState_Normal.Height)))
            'pCorner_TopLeft.Update_DrawingLocation(New Rectangle(New Point(0, 0), pCorner_TopLeft.LoadedImage.Size))
            'pCorner_TopRight.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - pCorner_TopRight.LoadedImage.Size.Width, 0), pCorner_TopRight.LoadedImage.Size))
            'pEdge_Left.Update_DrawingLocation(New Rectangle(New Point(0, pCorner_TopLeft.LoadedImage.Height), New Size(pEdge_Left.LoadedImage.Size.Width, ClientRectangle.Height - (pCorner_TopLeft.LoadedImage.Height + pCorner_BottomLeft.LoadedImage.Height))))
            'pEdge_Right.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - pCorner_TopRight.LoadedImage.Size.Width, pCorner_TopRight.LoadedImage.Height), New Size(pEdge_Right.LoadedImage.Size.Width, ClientRectangle.Height - (pCorner_TopRight.LoadedImage.Height + pCorner_BottomRight.LoadedImage.Height))))
            'pEdge_Bottom.Update_DrawingLocation(New Rectangle(New Point(pCorner_BottomLeft.LoadedImage.Width, ClientRectangle.Height - pEdge_Bottom.LoadedImage.Height), New Size(ClientRectangle.Width - (pCorner_BottomLeft.LoadedImage.Width + pCorner_BottomLeft.LoadedImage.Width), pEdge_Bottom.LoadedImage.Height)))
            'pCorner_BottomLeft.Update_DrawingLocation(New Rectangle(New Point(0, ClientRectangle.Height - pCorner_BottomLeft.LoadedImage.Height), pCorner_BottomLeft.LoadedImage.Size))
            'pCorner_BottomRight.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - pCorner_BottomRight.LoadedImage.Size.Width, ClientRectangle.Height - pCorner_BottomRight.LoadedImage.Height), pCorner_BottomRight.LoadedImage.Size))
            'pButton_Icon.Update_DrawingLocation(New Rectangle(pCorner_TopLeft.LoadedImage.Width, 0, pTitleBar.ButtonState_Normal.Height - 0, pTitleBar.ButtonState_Normal.Height))
            'pButton_Close.Update_DrawingLocation(New Rectangle(New Point(pCorner_TopRight.ClientLocation.Left - pButton_Close.ButtonState_Normal.Size.Width, 0), pButton_Close.ButtonState_Normal.Size))
            pButton_Max.Update_DrawingLocation(New Rectangle(New Point(pButton_Close.ClientLocation.Left - pButton_Max.ButtonState_Normal.Size.Width, 0), pButton_Max.ButtonState_Normal.Size))
            pButton_Min.Update_DrawingLocation(New Rectangle(New Point(pButton_Max.ClientLocation.Left - pButton_Min.ButtonState_Normal.Size.Width, 0), pButton_Min.ButtonState_Normal.Size))

            '//pDialogButtons.Calculate_DrawableLocations(ClientRectangle, rUsableClientArea, Me)
            '//rUsableButtonArea = Rectangle.Union(pButton_Min.ClientLocation, pButton_Max.ClientLocation)
            '//rUsableButtonArea = Rectangle.Union(rUsableButtonArea, pButton_Close.ClientLocation)
        End Sub
#End Region

#Region "Process Mouse Events"
        Public Sub ProcessMouseEvent_MouseMove(ByRef Sender As Form, e As MouseEventArgs)
            If rMouseLocation.Equals(e.Location) Then Exit Sub
            If rIsMoving Or rIsResizing Then
                If (MouseButtons.Left And e.Button) = MouseButtons.Left Then
                    If rIsResizing Then
                        'ControlledForm_Resize(e.Location)
                    ElseIf rIsMoving Then
                        'ControlledForm_Move(e.Location)
                    End If
                Else
                    rMouseLocation = e.Location
                    'Process_MouseEvent_MovedOverButton(e.Location)
                    'Process_MouseEvent_MovedOverDialogButton(e.Location)
                End If
            Else
                rMouseLocation = e.Location
                'Process_MouseEvent_MovedOverButton(e.Location)
                'Process_MouseEvent_MovedOverDialogButton(e.Location)
            End If
        End Sub
        Public Sub ProcessMouseEvent_MouseDown(ByRef Sender As Form, e As MouseEventArgs)
            rMouseLocation = e.Location
            Dim Key As String = ""
            Dim Button As FormSkinRegion_Button = Nothing
            If Check_MouseOverAnyButton(e.Location, Button) Then
                ProcessButtonEvent_PressedButton(Button, e.Location)
            ElseIf Check_MouseOverAnyDialogButton(e.Location, Button) Then
                'Process_MouseEvent_PressedDialogButton(Key, Button, e.Location)
            ElseIf Check_MouseOverMoveBar(e.Location) Then
                If Sender.WindowState = FormWindowState.Maximized Then Exit Sub
                rIsMoving = True
            ElseIf pAllowResize = True AndAlso Check_MouseOverEdge(e.Location) Then
                If Sender.WindowState = FormWindowState.Maximized Then Exit Sub
                rIsResizing = True
                Cursor.Current = Cursors.SizeAll
            End If
        End Sub
        Public Sub ProcessMouseEvent_MouseUp(ByRef Sender As Form, e As MouseEventArgs)
            rMouseLocation = e.Location
            Dim WasMoving As Boolean = rIsMoving
            rIsMoving = False : rIsResizing = False
            Dim Button As FormSkinRegion_Button = Nothing
            Dim Key As String = ""
            Update_Buttons_Unselected(Nothing)
            'pLoadedSkin.Update_DialogButtons_Unselected("")
            If Check_MouseOverAnyButton(e.Location, Button) = True Then
                Sender.Invalidate()
                'ControlledForm_Trigger_ButtonPressed(SelectedButton)
                Exit Sub
            End If
            If Check_MouseOverAnyDialogButton(e.Location, Button) = True Then
                Sender.Invalidate()
                'ControlledForm_Trigger_DialogButtonPressed(Key)
            End If
        End Sub
        Public Sub ProcessMouseEvent_MouseLeave(ByRef Sender As Form, e As EventArgs)
            Update_Buttons_Unselected(Nothing)
            'pLoadedSkin.Update_DialogButtons_Unselected("")
            Sender.Invalidate()
        End Sub
        Public Sub ProcessMouseEvent_MouseHover(ByRef Sender As Form, e As EventArgs)
            Dim Button As FormSkinRegion_Button = Nothing
            If Check_MouseOverAnyButton(rMouseLocation, Button) = False Then Exit Sub
            'ToolTip_Update(Button.UniqueKey, Button.ToolTip_String, rMouseLocation)
        End Sub
        Private Sub UpdateButtons_Unselect()
        End Sub
#End Region

#Region "Process Button Events"
        Private Sub ProcessButtonEvent_PressedButton(Button As FormSkinRegion_Button, Location As Point)
            If rMouseLastPosition_WasOverButon = False Then
                Update_Button_Pressed(Button)
            Else
                Update_Button_Pressed(Button)
            End If
            rMouseLastPosition_WasOverButon = True
            rMouseLastButon = Button
            'InvalidateRegion_Button(SelectedButton)
        End Sub
        Private Sub ProcessButtonEvent_PressedDialogButton(SelectedButton As String, Button As FormSkinRegion_Button, Location As Point)
            If rMouseLastPosition_WasOverButon = False Then
                'pLoadedSkin.Update_DialogButton_Pressed(SelectedButton)
            Else
                'pLoadedSkin.Update_DialogButton_Pressed(SelectedButton)
            End If
            rMouseLastPosition_WasOverButon = True
            'rMouseLastButon = FormRegionArea.DialogButtons
            'InvalidateRegion_DialogButton(Button)
        End Sub
        Private Sub ProcessButtonEvent_MovedOverButton(Location As Point)
            Dim ShouldDraw As Boolean = False
            Dim Button As FormSkinRegion_Button = Nothing
            If Check_MouseOverAnyButton(Location, Button) Then
                If rMouseLastPosition_WasOverButon = False Then
                    'pLoadedSkin.Update_Button_Hilited(SelectedButton)
                    ShouldDraw = True
                ElseIf Not (rMouseLastButon Is Button) Then
                    'pLoadedSkin.Update_Button_Hilited(SelectedButton)
                    ShouldDraw = True
                End If
                rMouseLastPosition_WasOverButon = True : rMouseLastButon = Button
                rMouseLastPosition_WasOverDialogButon = False ': rMouseLastKey = String.Empty
            Else
                If rMouseLastPosition_WasOverButon = True Then
                    'pLoadedSkin.Update_Buttons_Unselected(FormRegionArea.None)
                    ShouldDraw = True
                    'SelectedButton = FormRegionArea.ShowAll
                End If
                rMouseLastPosition_WasOverButon = False : rMouseLastButon = Button
            End If
            If ShouldDraw = True Then
                'InvalidateRegion_Button(SelectedButton)
                'ControlledForm_ResetMouseEventArgs()
            End If
        End Sub
        Private Sub ProcessButtonEvent_MovedOverDialogButton(Location As Point)
            ' If pLoadedSkin.WindowSkin_DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.None Then Exit Sub
            Dim ShouldDraw As Boolean = False
            Dim Button As FormSkinRegion_Button = Nothing
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
        Public Sub Update_Buttons_Unselected(Except As FormSkinRegion_Button)
            If (Except IsNot pButton_Close) Then pButton_Close.Update_ImageState_UnHilited()
            If (Except IsNot pButton_Min) Then pButton_Min.Update_ImageState_UnHilited()
            If (Except IsNot pButton_Max) Then pButton_Max.Update_ImageState_UnHilited()
            'HELP, ICON ETC
        End Sub
        Public Sub Update_Button_Hilited(Button As FormSkinRegion_Button)
            Button.Update_ImageState_Hilited()
            Update_Buttons_Unselected(Button)
        End Sub
        Public Sub Update_Button_Pressed(Button As FormSkinRegion_Button)
            Button.Update_ImageState_Pressed()
            Update_Buttons_Unselected(Button)
        End Sub
#End Region

    End Class
End Namespace