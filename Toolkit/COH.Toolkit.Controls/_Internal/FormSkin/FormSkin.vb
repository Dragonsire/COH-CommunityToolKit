Imports COH.CodeManagement.Enums.Toolkit

Namespace Controls.Configuration
    Public NotInheritable Class FormSkin

#Region "Properties"
        Public ReadOnly Property TitleBar As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.TitleBar)
            End Get
        End Property
        Public ReadOnly Property Button_Icon As FormSkinRegion_ImageRegion_Hilitable
            Get
                Return pFormSkinRegions(FormRegions.Button_Icon)
            End Get
        End Property
        Public ReadOnly Property Button_Help As FormSkinRegion_ImageRegion_Hilitable
            Get
                Return pFormSkinRegions(FormRegions.Button_Help)
            End Get
        End Property
        Public ReadOnly Property Button_Min As FormSkinRegion_ImageRegion_Hilitable
            Get
                Return pFormSkinRegions(FormRegions.Button_Min)
            End Get
        End Property
        Public ReadOnly Property Button_Max As FormSkinRegion_ImageRegion_Hilitable
            Get
                Return pFormSkinRegions(FormRegions.Button_Max)
            End Get
        End Property
        Public ReadOnly Property Button_Close As FormSkinRegion_ImageRegion_Hilitable
            Get
                Return pFormSkinRegions(FormRegions.Button_Close)
            End Get
        End Property
        Public ReadOnly Property Edge_Left As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Edge_Left)
            End Get
        End Property
        Public ReadOnly Property Edge_Right As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Edge_Right)
            End Get
        End Property
        Public ReadOnly Property Edge_Bottom As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Edge_Bottom)
            End Get
        End Property
        Public ReadOnly Property Corner_TopLeft As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Corner_TopLeft)
            End Get
        End Property
        Public ReadOnly Property Corner_TopRight As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Corner_TopRight)
            End Get
        End Property
        Public ReadOnly Property Corner_BottomLeft As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Corner_BottomLeft)
            End Get
        End Property
        Public ReadOnly Property Corner_BottomRight As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Corner_BottomRight)
            End Get
        End Property
        Public ReadOnly Property SkinRegion(Key As FormRegions) As FormSkinRegion
            Get
                Return pFormSkinRegions(Key)
            End Get
        End Property
        Public ReadOnly Property SkinRegions() As Dictionary(Of FormRegions, FormSkinRegion)
            Get
                Return pFormSkinRegions
            End Get
        End Property
        Private pAllowResize As Boolean
        Private rMouseLocation As Point
        Private rIsMoving As Boolean
        Private rIsResizing As Boolean
        Private rMouseLastPosition_WasOverButon As Boolean
        Private rMouseLastPosition_WasOverDialogButon As Boolean
        Private rMouseLastButon As FormSkinRegion_ImageRegion_Hilitable
        Private pFormSkinRegions As Dictionary(Of FormRegions, FormSkinRegion)
#End Region

#Region "Initialize"
        Public Sub New()
            MyBase.New
            ResetToDefault()
        End Sub
        Public Sub ResetToDefault()
            pFormSkinRegions = New Dictionary(Of FormRegions, FormSkinRegion)
            pFormSkinRegions.Add(FormRegions.Edge_Left, New FormSkinRegion_ImageRegion(FormRegions.Edge_Left))
            pFormSkinRegions.Add(FormRegions.Edge_Right, New FormSkinRegion_ImageRegion(FormRegions.Edge_Right))
            pFormSkinRegions.Add(FormRegions.Edge_Bottom, New FormSkinRegion_ImageRegion(FormRegions.Edge_Bottom))
        End Sub
        Public Shared Function LoadTheme_FromFolder(Folder As String) As FormSkin
            Dim UsedFormat As Imaging.ImageFormat = Imaging.ImageFormat.Png
            If IO.File.Exists(IO.Path.Combine(Folder, "Button_Close_Normal.png")) = True Then
                UsedFormat = Imaging.ImageFormat.Png
            ElseIf IO.File.Exists(IO.Path.Combine(Folder, "Button_Close_Normal.bmp")) = True Then
                UsedFormat = Imaging.ImageFormat.Bmp
            Else
                Return Nothing
            End If
            Return LoadTheme_FromFolder(Folder, UsedFormat)
        End Function
        Public Shared Function LoadTheme_FromFolder(Folder As String, Format As Imaging.ImageFormat) As FormSkin
            Dim LoadedSkin As New FormSkin
            For Each SkinArea In LoadedSkin.SkinRegions
                SkinArea.Value.LoadImages_FromFolder(Folder, Format)
            Next
            Return LoadedSkin
        End Function
#End Region

#Region "Check Locations"
        Public Function Check_MouseOverAnyButton(MouseLocation As Point, ByRef ButtonSelected As FormSkinRegion_ImageRegion_Hilitable) As Boolean
            ButtonSelected = Button_Min : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            ButtonSelected = Button_Max : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            ButtonSelected = Button_Close : If ButtonSelected.Check_MouseLocation_WithinDrawArea(MouseLocation) = True Then Return True
            Return False
        End Function
        Public Function Check_MouseOverAnyDialogButton(MouseLocation As Point, ByRef ButtonSelected As FormSkinRegion_ImageRegion_Hilitable) As Boolean
        End Function
        Public Function Check_MouseOverMoveBar(MouseLocation As Point) As Boolean
        End Function
        Public Function Check_MouseOverEdge(MouseLocation As Point) As Boolean
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
            Button_Icon.Update_DrawingLocation(New Rectangle(Corner_TopLeft.ImageState_Normal.Width, 0, TitleBar.ImageState_Normal.Height - 0, TitleBar.ImageState_Normal.Height))
            Button_Close.Update_DrawingLocation(New Rectangle(New Point(Corner_TopRight.ClientLocation.Left - Button_Close.ImageState_Normal.Size.Width, 0), Button_Close.ImageState_Normal.Size))
            Button_Max.Update_DrawingLocation(New Rectangle(New Point(Button_Close.ClientLocation.Left - Button_Max.ImageState_Normal.Size.Width, 0), Button_Max.ImageState_Normal.Size))
            Button_Min.Update_DrawingLocation(New Rectangle(New Point(Button_Max.ClientLocation.Left - Button_Min.ImageState_Normal.Size.Width, 0), Button_Min.ImageState_Normal.Size))
            '//pDialogButtons.Calculate_DrawableLocations(ClientRectangle, rUsableClientArea, Me)
            '//rUsableButtonArea = Rectangle.Union(Button_Min.ClientLocation, Button_Max.ClientLocation)
            '//rUsableButtonArea = Rectangle.Union(rUsableButtonArea, Button_Close.ClientLocation)
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
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
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
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
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
            'InvalidateRegion_Button(SelectedButton)
        End Sub
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
        Private Sub ProcessButtonEvent_MovedOverButton(Location As Point)
            Dim ShouldDraw As Boolean = False
            Dim Button As FormSkinRegion_ImageRegion_Hilitable = Nothing
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
        Public Sub Update_Buttons_Unselected(Except As FormSkinRegion_ImageRegion_Hilitable)
            'If (Except IsNot Button_Close) Then Button_Close.Update_ImageState_UnHilited()
            'If (Except IsNot Button_Min) Then Button_Min.Update_ImageState_UnHilited()
            'If (Except IsNot Button_Max) Then Button_Max.Update_ImageState_UnHilited()
            'HELP, ICON ETC
        End Sub
        Public Sub Update_Button_Hilited(Button As FormSkinRegion_ImageRegion_Hilitable)
            'Button.Update_ImageState_Hilited()
            Update_Buttons_Unselected(Button)
        End Sub
        Public Sub Update_Button_Pressed(Button As FormSkinRegion_ImageRegion_Hilitable)
            'Button.Update_ImageState_Pressed()
            Update_Buttons_Unselected(Button)
        End Sub
#End Region

    End Class
End Namespace