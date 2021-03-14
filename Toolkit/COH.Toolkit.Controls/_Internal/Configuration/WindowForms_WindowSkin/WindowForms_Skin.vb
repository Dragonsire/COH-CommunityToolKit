Imports System.ComponentModel

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public NotInheritable Class WindowFormsConfiguration_Skin
        Inherits DS_CFS_MonitorChanges
        Implements IDisposable

#Region "Properties"
        Public Property TitleBarFont As Wrapped_Font
            Get
                Return pTitleBarFont
            End Get
            Set(Value As Wrapped_Font)
                UpdatePrivateProperty(pTitleBarFont, Value)
            End Set
        End Property
        Public Property WindowSkin_Edge_Left As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Edge_Left
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Edge_Left, Value)
            End Set
        End Property
        Public Property WindowSkin_Edge_Right As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Edge_Right
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Edge_Right, Value)
            End Set
        End Property
        Public Property WindowSkin_Edge_Bottom As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Edge_Bottom
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Edge_Bottom, Value)
            End Set
        End Property
        Public Property WindowSkin_Corner_BottomLeft As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Corner_BottomLeft
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Corner_BottomLeft, Value)
            End Set
        End Property
        Public Property WindowSkin_Corner_BottomRight As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Corner_BottomRight
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Corner_BottomRight, Value)
            End Set
        End Property
        Public Property WindowSkin_Corner_TopLeft As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Corner_TopLeft
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Corner_TopLeft, Value)
            End Set
        End Property
        Public Property WindowSkin_Corner_TopRight As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Corner_TopRight
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Corner_TopRight, Value)
            End Set
        End Property
        Public Property WindowSkin_TitleBar As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_TitleBar
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_TitleBar, Value)
            End Set
        End Property
        Public Property WindowSkin_Button_Icon As ControlRegion_ImageStates
            Get
                Return pWindowSkin_Button_Icon
            End Get
            Set(Value As ControlRegion_ImageStates)
                UpdatePrivateProperty(pWindowSkin_Button_Icon, Value)
            End Set
        End Property
        Public Property WindowSkin_Button_Max As ControlRegion_ImageStates
            Get
                Return pWindowSkin_Button_Max
            End Get
            Set(Value As ControlRegion_ImageStates)
                UpdatePrivateProperty(pWindowSkin_Button_Max, Value)
            End Set
        End Property
        Public Property WindowSkin_Button_Min As ControlRegion_ImageStates
            Get
                Return pWindowSkin_Button_Min
            End Get
            Set(Value As ControlRegion_ImageStates)
                UpdatePrivateProperty(pWindowSkin_Button_Min, Value)
            End Set
        End Property
        Public Property WindowSkin_Button_Close As ControlRegion_ImageStates
            Get
                Return pWindowSkin_Button_Close
            End Get
            Set(Value As ControlRegion_ImageStates)
                UpdatePrivateProperty(pWindowSkin_Button_Close, Value)
            End Set
        End Property
        Public Property WindowSkin_Button_Help As ControlRegion_ImageStates
            Get
                Return pWindowSkin_Button_Help
            End Get
            Set(Value As ControlRegion_ImageStates)
                UpdatePrivateProperty(pWindowSkin_Button_Help, Value)
            End Set
        End Property
        Public Property WindowSkin_Button_Special As ControlRegion_ImageStates
            Get
                Return pWindowSkin_Button_Special
            End Get
            Set(Value As ControlRegion_ImageStates)
                UpdatePrivateProperty(pWindowSkin_Button_Special, Value)
            End Set
        End Property
        Public ReadOnly Property Form_UsableArea() As Rectangle
            Get
                Return rUsableClientArea
            End Get
        End Property
        Public ReadOnly Property Form_ButtonRegion() As Rectangle
            Get
                Return rUsableButtonArea
            End Get
        End Property
#End Region
#Region "Properties - Dialog Area"
        Public Property WindowSkin_Dialog_Bar As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Dialog_Bar
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Dialog_Bar, Value)
            End Set
        End Property
        Public Property WindowSkin_Editor_Bar As ControlRegion_Image_WithGrey
            Get
                Return pWindowSkin_Editor_Bar
            End Get
            Set(Value As ControlRegion_Image_WithGrey)
                UpdatePrivateProperty(pWindowSkin_Editor_Bar, Value)
            End Set
        End Property
        Public Property WindowSkin_DialogButtons As WindowFormsConfiguration_Skin_DialogButtons
            Get
                Return pWindowSkin_DialogButtons
            End Get
            Set(Value As WindowFormsConfiguration_Skin_DialogButtons)
                UpdatePrivateProperty(pWindowSkin_DialogButtons, Value)
            End Set
        End Property
#End Region

#Region "Private Properties"
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private WithEvents pTitleBarFont As Wrapped_Font
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Edge_Left As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Edge_Right As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Edge_Bottom As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Corner_BottomLeft As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Corner_BottomRight As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Corner_TopLeft As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Corner_TopRight As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_TitleBar As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Button_Icon As ControlRegion_ImageStates
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Button_Max As ControlRegion_ImageStates
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Button_Min As ControlRegion_ImageStates
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Button_Close As ControlRegion_ImageStates
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Button_Help As ControlRegion_ImageStates
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Button_Special As ControlRegion_ImageStates

        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_DialogButtons As WindowFormsConfiguration_Skin_DialogButtons
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Dialog_Bar As ControlRegion_Image_WithGrey
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_Editor_Bar As ControlRegion_Image_WithGrey

        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private rUsableClientArea As Rectangle
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private rUsableButtonArea As Rectangle
        Private disposedValue As Boolean
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            If ResetDefaults = True Then ResetToDefault()
        End Sub
        Public Sub New(ByRef CurrentReader As FlexStreamEditor)
            Read_FromStream(CurrentReader)
        End Sub
#End Region
#Region "Initialize"
        Public Overrides Sub ResetToDefault()
            pTitleBarFont = New Wrapped_Font
            pWindowSkin_Edge_Left = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Left.ToString, True, True, True)
            pWindowSkin_Edge_Right = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Right.ToString, True, True, True)
            pWindowSkin_Edge_Bottom = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Bottom.ToString, True, True, True)
            pWindowSkin_Corner_BottomLeft = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_BottomLeft.ToString, True, True, False)
            pWindowSkin_Corner_BottomRight = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_BottomRight.ToString, True, True, False)
            pWindowSkin_Corner_TopLeft = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_TopLeft.ToString, True, True, False)
            pWindowSkin_Corner_TopRight = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.WindowEdge_Corner_TopRight.ToString, True, True, False)
            pWindowSkin_TitleBar = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.TitleBar.ToString, True, True, True)
            pWindowSkin_Button_Icon = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Icon.ToString, True, True, True)
            pWindowSkin_Button_Max = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Maximize.ToString, True, True, True)
            pWindowSkin_Button_Min = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Minimize.ToString, True, True, True)
            pWindowSkin_Button_Close = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Close.ToString, True, True, True)
            pWindowSkin_Button_Help = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Help.ToString, True, False, True)
            pWindowSkin_Button_Special = New ControlRegion_ImageStates(WindowForms_WindowSkin_FormRegions.Special.ToString, True, False, True)

            pWindowSkin_DialogButtons = New WindowFormsConfiguration_Skin_DialogButtons
            pWindowSkin_Dialog_Bar = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.DialogBar.ToString, True, False, False)
            pWindowSkin_Editor_Bar = New ControlRegion_Image_WithGrey(WindowForms_WindowSkin_FormRegions.EditorBar.ToString, True, False, False)
            MyBase.ResetToDefault()
        End Sub
        Public Function Varify() As Boolean
            If pWindowSkin_Corner_BottomLeft Is Nothing OrElse pWindowSkin_Corner_BottomLeft.LoadedImage Is Nothing Then Return False
            If pWindowSkin_Corner_BottomRight Is Nothing OrElse pWindowSkin_Corner_BottomRight.LoadedImage Is Nothing Then Return False
            If pWindowSkin_Corner_TopLeft Is Nothing OrElse pWindowSkin_Corner_TopLeft.LoadedImage Is Nothing Then Return False
            If pWindowSkin_Corner_TopRight Is Nothing OrElse pWindowSkin_Corner_TopRight.LoadedImage Is Nothing Then Return False
            Return True
        End Function
#End Region

#Region "Internal Functions"
        Public Function Handle_OnRequest_ReturnRegions(ByRef Regions As List(Of ControlRegion)) As Boolean
            Regions.Add(pWindowSkin_Edge_Left)
            Regions.Add(pWindowSkin_Edge_Right)
            Regions.Add(pWindowSkin_Edge_Bottom)
            Regions.Add(pWindowSkin_Corner_BottomLeft)
            Regions.Add(pWindowSkin_Corner_BottomRight)
            Regions.Add(pWindowSkin_Corner_TopLeft)
            Regions.Add(pWindowSkin_Corner_TopRight)
            Regions.Add(pWindowSkin_TitleBar)
            Regions.Add(pWindowSkin_Button_Icon)
            Regions.Add(pWindowSkin_Button_Max)
            Regions.Add(pWindowSkin_Button_Min)
            Regions.Add(pWindowSkin_Button_Close)
            Regions.Add(pWindowSkin_Button_Help)
            Regions.Add(pWindowSkin_Button_Special)
            Return (Regions.Count > 0)
        End Function
        Public Function Check_IsMouse_OverButton(Location As Point, ByRef Result As WindowForms_WindowSkin_FormRegions, ByRef Button As ControlRegion_ImageStates) As Boolean
            Result = WindowForms_WindowSkin_FormRegions.None
            If Check_IsMouse_OverAvailableButton(Location, pWindowSkin_Button_Close) Then Result = WindowForms_WindowSkin_FormRegions.Close : Button = pWindowSkin_Button_Close : Return True
            If Check_IsMouse_OverAvailableButton(Location, pWindowSkin_Button_Help) Then Result = WindowForms_WindowSkin_FormRegions.Help : Button = pWindowSkin_Button_Help : Return True
            If Check_IsMouse_OverAvailableButton(Location, pWindowSkin_Button_Special) Then Result = WindowForms_WindowSkin_FormRegions.Special : Button = pWindowSkin_Button_Special : Return True
            If Check_IsMouse_OverAvailableButton(Location, pWindowSkin_Button_Min) Then Result = WindowForms_WindowSkin_FormRegions.Minimize : Button = pWindowSkin_Button_Min : Return True
            If Check_IsMouse_OverAvailableButton(Location, pWindowSkin_Button_Max) Then Result = WindowForms_WindowSkin_FormRegions.Maximize : Button = pWindowSkin_Button_Max : Return True
            Return False
        End Function
        Public Function Check_IsMouse_OverMoveBar(Location As Point) As Boolean
            Dim Result As WindowForms_WindowSkin_FormRegions = WindowForms_WindowSkin_FormRegions.None
            '//If Check_IsMouse_OverButton(Location, Result) = True Then Return False
            If pWindowSkin_TitleBar.Is_MouseRegion = False Then Return False
            If pWindowSkin_TitleBar.Enabled = False Then Return False
            If pWindowSkin_TitleBar.Visible = False Then Return False
            Return pWindowSkin_TitleBar.Check_MouseLocation_WithinDrawArea(Location)
        End Function
        Public Function Check_IsMouse_OverEdge(Location As Point) As Boolean
            Dim Result As WindowForms_WindowSkin_FormRegions = WindowForms_WindowSkin_FormRegions.None
            If pWindowSkin_Edge_Left.Check_MouseLocation_WithinDrawArea(Location) Then Return True
            If pWindowSkin_Edge_Right.Check_MouseLocation_WithinDrawArea(Location) Then Return True
            If pWindowSkin_Edge_Bottom.Check_MouseLocation_WithinDrawArea(Location) Then Return True
            Return False
        End Function
        Public Function Check_IsMouse_OverAvailableButton(Location As Point, ByRef SelectedButton As ControlRegion_ImageStates) As Boolean
            If SelectedButton.Is_MouseRegion = False Then Return False
            If SelectedButton.Visible = False Then Return False
            If SelectedButton.Enabled = False Then Return False
            Return SelectedButton.Check_MouseLocation_WithinDrawArea(Location)
        End Function
        Public Function Check_IsMouse_OverDialogButton(Location As Point, ByRef Result As String, ByRef SelectedButton As ControlRegion_ImageStates) As Boolean
            Return pWindowSkin_DialogButtons.Check_IsMouse_OverDialogButton(Location, Result, SelectedButton)
        End Function
#End Region

#Region "Events"
        Event SkinModified_FontChanged()
        Private Sub FontUpdated() Handles pTitleBarFont.WasModified
            RaiseEvent SkinModified_FontChanged()
        End Sub
#End Region

#Region "Modifying - Locations"
        Public Sub Calculate_DrawableLocations(ClientRectangle As Rectangle)
            pWindowSkin_TitleBar.Update_DrawingLocation(New Rectangle(New Point(WindowSkin_Corner_TopLeft.LoadedImage.Width, 0), New Size(ClientRectangle.Width - (WindowSkin_Corner_TopRight.LoadedImage.Width + pWindowSkin_Corner_TopLeft.LoadedImage.Width), pWindowSkin_TitleBar.LoadedImage.Height)))
            pWindowSkin_Corner_TopLeft.Update_DrawingLocation(New Rectangle(New Point(0, 0), pWindowSkin_Corner_TopLeft.LoadedImage.Size))
            pWindowSkin_Corner_TopRight.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - pWindowSkin_Corner_TopRight.LoadedImage.Size.Width, 0), pWindowSkin_Corner_TopRight.LoadedImage.Size))
            pWindowSkin_Edge_Left.Update_DrawingLocation(New Rectangle(New Point(0, pWindowSkin_Corner_TopLeft.LoadedImage.Height), New Size(WindowSkin_Edge_Left.LoadedImage.Size.Width, ClientRectangle.Height - (WindowSkin_Corner_TopLeft.LoadedImage.Height + pWindowSkin_Corner_BottomLeft.LoadedImage.Height))))
            pWindowSkin_Edge_Right.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - pWindowSkin_Corner_TopRight.LoadedImage.Size.Width, pWindowSkin_Corner_TopRight.LoadedImage.Height), New Size(WindowSkin_Edge_Right.LoadedImage.Size.Width, ClientRectangle.Height - (WindowSkin_Corner_TopRight.LoadedImage.Height + pWindowSkin_Corner_BottomRight.LoadedImage.Height))))
            pWindowSkin_Edge_Bottom.Update_DrawingLocation(New Rectangle(New Point(WindowSkin_Corner_BottomLeft.LoadedImage.Width, ClientRectangle.Height - pWindowSkin_Edge_Bottom.LoadedImage.Height), New Size(ClientRectangle.Width - (WindowSkin_Corner_BottomLeft.LoadedImage.Width + pWindowSkin_Corner_BottomLeft.LoadedImage.Width), pWindowSkin_Edge_Bottom.LoadedImage.Height)))
            pWindowSkin_Corner_BottomLeft.Update_DrawingLocation(New Rectangle(New Point(0, ClientRectangle.Height - pWindowSkin_Corner_BottomLeft.LoadedImage.Height), pWindowSkin_Corner_BottomLeft.LoadedImage.Size))
            pWindowSkin_Corner_BottomRight.Update_DrawingLocation(New Rectangle(New Point(ClientRectangle.Width - pWindowSkin_Corner_BottomRight.LoadedImage.Size.Width, ClientRectangle.Height - pWindowSkin_Corner_BottomRight.LoadedImage.Height), pWindowSkin_Corner_BottomRight.LoadedImage.Size))
            pWindowSkin_Button_Icon.Update_DrawingLocation(New Rectangle(WindowSkin_Corner_TopLeft.LoadedImage.Width, 0, pWindowSkin_TitleBar.LoadedImage.Height - 0, pWindowSkin_TitleBar.LoadedImage.Height))
            pWindowSkin_Button_Close.Update_DrawingLocation(New Rectangle(New Point(pWindowSkin_Corner_TopRight.ClientLocation.Left - pWindowSkin_Button_Close.Layer_Background.ImageState_Normal.Size.Width, 0), pWindowSkin_Button_Close.Layer_Background.ImageState_Normal.Size))
            pWindowSkin_Button_Max.Update_DrawingLocation(New Rectangle(New Point(pWindowSkin_Button_Close.ClientLocation.Left - pWindowSkin_Button_Max.Layer_Background.ImageState_Normal.Size.Width, 0), pWindowSkin_Button_Max.Layer_Background.ImageState_Normal.Size))
            pWindowSkin_Button_Min.Update_DrawingLocation(New Rectangle(New Point(pWindowSkin_Button_Max.ClientLocation.Left - pWindowSkin_Button_Min.Layer_Background.ImageState_Normal.Size.Width, 0), pWindowSkin_Button_Min.Layer_Background.ImageState_Normal.Size))
            pWindowSkin_Button_Help.Update_DrawingLocation(New Rectangle(0, 0, 0, 0))
            pWindowSkin_Button_Special.Update_DrawingLocation(New Rectangle(0, 0, 0, 0))

            pWindowSkin_DialogButtons.Calculate_DrawableLocations(ClientRectangle, rUsableClientArea, Me)
            rUsableButtonArea = Rectangle.Union(pWindowSkin_Button_Min.ClientLocation, pWindowSkin_Button_Max.ClientLocation)
            rUsableButtonArea = Rectangle.Union(rUsableButtonArea, pWindowSkin_Button_Close.ClientLocation)
        End Sub
#End Region
#Region "Modifying - Enable/Disable Form"
        Public Sub EnableForm()
            ChangeAll_Buttons_Enabled(True)
            ChangeAll_Borders_Enabled(True)
            pWindowSkin_DialogButtons.ChangeAll_DialogButtons_Enabled(True)
        End Sub
        Public Sub DisableForm()
            ChangeAll_Buttons_Enabled(False)
            ChangeAll_Borders_Enabled(False)
            pWindowSkin_DialogButtons.ChangeAll_DialogButtons_Enabled(False)
        End Sub
        Public Sub EnableFormButtons_FromForm(ByRef TheForm As Form)
            pWindowSkin_Button_Close.Enabled = True
            pWindowSkin_Button_Close.Visible = TheForm.ControlBox
            pWindowSkin_Button_Min.Enabled = True
            pWindowSkin_Button_Min.Visible = TheForm.MinimizeBox
            pWindowSkin_Button_Max.Enabled = True
            pWindowSkin_Button_Max.Visible = TheForm.MaximizeBox
            pWindowSkin_Button_Help.Enabled = True
            pWindowSkin_Button_Help.Visible = TheForm.HelpButton
            pWindowSkin_Button_Special.Enabled = True
            pWindowSkin_Button_Special.Visible = False
        End Sub
        Private Sub ChangeAll_Buttons_Enabled(Optional Enabled As Boolean = True)
            pWindowSkin_Button_Close.Enabled = Enabled
            pWindowSkin_Button_Help.Enabled = Enabled
            pWindowSkin_Button_Max.Enabled = Enabled
            pWindowSkin_Button_Min.Enabled = Enabled
            pWindowSkin_Button_Special.Enabled = Enabled
            '//WindowSkin_Button_Icon.Enabled = Enabled
        End Sub
        Private Sub ChangeAll_Borders_Enabled(Optional Enabled As Boolean = True)
            pWindowSkin_Corner_BottomLeft.Enabled = Enabled
            pWindowSkin_Corner_BottomRight.Enabled = Enabled
            pWindowSkin_Corner_TopLeft.Enabled = Enabled
            pWindowSkin_Corner_TopRight.Enabled = Enabled
            pWindowSkin_Edge_Bottom.Enabled = Enabled
            pWindowSkin_Edge_Left.Enabled = Enabled
            pWindowSkin_Edge_Right.Enabled = Enabled
            pWindowSkin_TitleBar.Enabled = Enabled
        End Sub
#End Region
#Region "Modifying - Button States"
        Public Sub Update_Buttons_Unselected(Except As WindowForms_WindowSkin_FormRegions)
            If Not Except = WindowForms_WindowSkin_FormRegions.Close Then pWindowSkin_Button_Close.Update_ImageState_UnHilited()
            If Not Except = WindowForms_WindowSkin_FormRegions.Help Then pWindowSkin_Button_Help.Update_ImageState_UnHilited()
            If Not Except = WindowForms_WindowSkin_FormRegions.Icon Then pWindowSkin_Button_Icon.Update_ImageState_UnHilited()
            If Not Except = WindowForms_WindowSkin_FormRegions.Maximize Then pWindowSkin_Button_Max.Update_ImageState_UnHilited()
            If Not Except = WindowForms_WindowSkin_FormRegions.Minimize Then pWindowSkin_Button_Min.Update_ImageState_UnHilited()
            If Not Except = WindowForms_WindowSkin_FormRegions.Special Then pWindowSkin_Button_Special.Update_ImageState_UnHilited()
        End Sub
        Public Sub Update_Button_Hilited(Button As WindowForms_WindowSkin_FormRegions)
            If Button = WindowForms_WindowSkin_FormRegions.Close Then pWindowSkin_Button_Close.Update_ImageState_Hilited()
            If Button = WindowForms_WindowSkin_FormRegions.Help Then pWindowSkin_Button_Help.Update_ImageState_Hilited()
            If Button = WindowForms_WindowSkin_FormRegions.Icon Then pWindowSkin_Button_Icon.Update_ImageState_Hilited()
            If Button = WindowForms_WindowSkin_FormRegions.Maximize Then pWindowSkin_Button_Max.Update_ImageState_Hilited()
            If Button = WindowForms_WindowSkin_FormRegions.Minimize Then pWindowSkin_Button_Min.Update_ImageState_Hilited()
            If Button = WindowForms_WindowSkin_FormRegions.Special Then pWindowSkin_Button_Special.Update_ImageState_Hilited()
            Update_Buttons_Unselected(Button)
        End Sub
        Public Sub Update_Button_Pressed(Button As WindowForms_WindowSkin_FormRegions)
            If Button = WindowForms_WindowSkin_FormRegions.Close Then pWindowSkin_Button_Close.Update_ImageState_Pressed()
            If Button = WindowForms_WindowSkin_FormRegions.Help Then pWindowSkin_Button_Help.Update_ImageState_Pressed()
            If Button = WindowForms_WindowSkin_FormRegions.Icon Then pWindowSkin_Button_Icon.Update_ImageState_Pressed()
            If Button = WindowForms_WindowSkin_FormRegions.Maximize Then pWindowSkin_Button_Max.Update_ImageState_Pressed()
            If Button = WindowForms_WindowSkin_FormRegions.Minimize Then pWindowSkin_Button_Min.Update_ImageState_Pressed()
            If Button = WindowForms_WindowSkin_FormRegions.Special Then pWindowSkin_Button_Special.Update_ImageState_Pressed()
            Update_Buttons_Unselected(Button)
        End Sub
#End Region

#Region "Modifying - Dialog Button States"
        Public Sub Update_DialogButtons_Unselected(ExceptKey As String)
            pWindowSkin_DialogButtons.Update_DialogButtons_Unselected(ExceptKey)
        End Sub
        Public Sub Update_DialogButton_Hilited(Key As String)
            pWindowSkin_DialogButtons.Update_DialogButton_Hilited(Key)
        End Sub
        Public Sub Update_DialogButton_Pressed(Key As String)
            pWindowSkin_DialogButtons.Update_DialogButton_Pressed(Key)
        End Sub
#End Region

#Region "Drawing"
        Public Sub Draw_Window(Text As String, CurrentDrawing As Graphics)
            pWindowSkin_Edge_Bottom.Draw(CurrentDrawing)
            pWindowSkin_Edge_Left.Draw(CurrentDrawing)
            pWindowSkin_Edge_Right.Draw(CurrentDrawing)
            pWindowSkin_Corner_BottomLeft.Draw(CurrentDrawing)
            pWindowSkin_Corner_BottomRight.Draw(CurrentDrawing)
            pWindowSkin_TitleBar.Draw(CurrentDrawing)
            pWindowSkin_Corner_TopLeft.Draw(CurrentDrawing)
            pWindowSkin_Corner_TopRight.Draw(CurrentDrawing)
            Draw_Window_Buttons(CurrentDrawing)
            CurrentDrawing.DrawString(Text, pTitleBarFont, pTitleBarFont.Return_Font_SolidBrush, New Rectangle(pWindowSkin_Button_Icon.ClientLocation.Right + 2, 0, pWindowSkin_TitleBar.ClientLocation.Width - pWindowSkin_Button_Icon.ClientLocation.Width, pWindowSkin_TitleBar.ClientLocation.Height))
        End Sub
        Public Sub Draw_Only_TitleBar(Text As String, CurrentDrawing As Drawing.Graphics)
            WindowSkin_TitleBar.Draw(CurrentDrawing)
            Draw_Window_Buttons(CurrentDrawing)
            CurrentDrawing.DrawString(Text, pTitleBarFont, pTitleBarFont.Return_Font_SolidBrush, New Rectangle(pWindowSkin_Button_Icon.ClientLocation.Right + 2, 0, pWindowSkin_TitleBar.ClientLocation.Width - pWindowSkin_Button_Icon.ClientLocation.Width, pWindowSkin_TitleBar.ClientLocation.Height))
        End Sub
        Public Sub Draw_WindowDialog(CurrentDrawing As Drawing.Graphics)
            If pWindowSkin_DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.DialogBar Then
                Draw_DialogBar(CurrentDrawing)
            ElseIf pWindowSkin_DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.EditorBar Then
                Draw_EditorBar(CurrentDrawing)
            End If
        End Sub
        Public Sub Draw_DialogBar(CurrentDrawing As Drawing.Graphics)
            WindowSkin_Dialog_Bar.Draw(CurrentDrawing)
            Draw_Dialog_Buttons(CurrentDrawing)
        End Sub
        Public Sub Draw_EditorBar(CurrentDrawing As Drawing.Graphics)
            WindowSkin_Editor_Bar.Draw(CurrentDrawing)
            Draw_Dialog_Buttons(CurrentDrawing)
        End Sub
#End Region

#Region "Drawing Buttons"
        Public Sub Draw_Window_Buttons(CurrentDrawing As Drawing.Graphics)
            If CurrentDrawing Is Nothing Then Exit Sub
            pWindowSkin_Button_Close.Draw(CurrentDrawing, True)
            pWindowSkin_Button_Help.Draw(CurrentDrawing, True)
            pWindowSkin_Button_Icon.Draw(CurrentDrawing, True)
            pWindowSkin_Button_Max.Draw(CurrentDrawing, True)
            pWindowSkin_Button_Min.Draw(CurrentDrawing, True)
            pWindowSkin_Button_Special.Draw(CurrentDrawing, True)
        End Sub
        Public Sub Draw_Window_Button(ByRef CurrentDrawing As Drawing.Graphics, Button As WindowForms_WindowSkin_FormRegions)
            Retrieve_FormButon(Button).Draw(CurrentDrawing, True)
        End Sub
        Public Sub Draw_Dialog_Buttons(CurrentDrawing As Drawing.Graphics)
            pWindowSkin_DialogButtons.Draw_Dialog_Buttons(CurrentDrawing)
        End Sub
#End Region

#Region "Search"
        Public Function Retrieve_FormButon(Button As WindowForms_WindowSkin_FormRegions) As ControlRegion_ImageStates
            Select Case Button
                Case WindowForms_WindowSkin_FormRegions.Close
                    Return pWindowSkin_Button_Close
                Case WindowForms_WindowSkin_FormRegions.Help
                    Return pWindowSkin_Button_Help
                Case WindowForms_WindowSkin_FormRegions.Icon
                    Return pWindowSkin_Button_Icon
                Case WindowForms_WindowSkin_FormRegions.Maximize
                    Return pWindowSkin_Button_Max
                Case WindowForms_WindowSkin_FormRegions.Minimize
                    Return pWindowSkin_Button_Min
                Case WindowForms_WindowSkin_FormRegions.Special
                    Return pWindowSkin_Button_Special
                Case Else
                    Return Nothing
            End Select
        End Function
#End Region
#Region "Clone"
        Public Overrides Function Clone() As Object
            Dim Result As New WindowFormsConfiguration_Skin
            CloneTo(Result)
            Return Result
        End Function
        Public Overloads Function CreateClone() As WindowFormsConfiguration_Skin
            Dim Destination As New WindowFormsConfiguration_Skin
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As WindowFormsConfiguration_Skin, Optional ExceptIcon As Boolean = False)
            With Destination
                .pTitleBarFont = pTitleBarFont.Clone
                .pWindowSkin_Edge_Left = pWindowSkin_Edge_Left.Clone
                .pWindowSkin_Edge_Right = pWindowSkin_Edge_Right.Clone
                .pWindowSkin_Edge_Bottom = pWindowSkin_Edge_Bottom.Clone
                .pWindowSkin_Corner_BottomLeft = pWindowSkin_Corner_BottomLeft.Clone
                .pWindowSkin_Corner_BottomRight = pWindowSkin_Corner_BottomRight.Clone
                .pWindowSkin_Corner_TopLeft = pWindowSkin_Corner_TopLeft.Clone
                .pWindowSkin_Corner_TopRight = pWindowSkin_Corner_TopRight.Clone
                .pWindowSkin_TitleBar = pWindowSkin_TitleBar.Clone
                If ExceptIcon = False Then .pWindowSkin_Button_Icon = pWindowSkin_Button_Icon.Clone
                .pWindowSkin_Button_Max = pWindowSkin_Button_Max.Clone
                .pWindowSkin_Button_Min = pWindowSkin_Button_Min.Clone
                .pWindowSkin_Button_Close = pWindowSkin_Button_Close.Clone
                .pWindowSkin_Button_Help = pWindowSkin_Button_Help.Clone
                .pWindowSkin_Button_Special = pWindowSkin_Button_Special.Clone
                .pWindowSkin_DialogButtons = pWindowSkin_DialogButtons.Clone
                .pWindowSkin_Dialog_Bar = pWindowSkin_Dialog_Bar.Clone
                .pWindowSkin_Editor_Bar = pWindowSkin_Dialog_Bar.Clone
            End With
            CloneTo(TryCast(Destination, DS_CFS_MonitorChanges))
        End Sub
#End Region
#Region "Export"
        Public Overrides Function Write_ToStream(ByRef CurrentWriter As FlexStreamEditor) As Boolean
            Dim Version As DS_CFS_IDent = DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_Skin))
            Version.WriteToStream(CurrentWriter)
            pTitleBarFont.Write_ToStream(CurrentWriter)
            pWindowSkin_Edge_Left.Write_ToStream(CurrentWriter)
            pWindowSkin_Edge_Right.Write_ToStream(CurrentWriter)
            pWindowSkin_Edge_Bottom.Write_ToStream(CurrentWriter)
            pWindowSkin_Corner_BottomLeft.Write_ToStream(CurrentWriter)
            pWindowSkin_Corner_BottomRight.Write_ToStream(CurrentWriter)
            pWindowSkin_Corner_TopLeft.Write_ToStream(CurrentWriter)
            pWindowSkin_Corner_TopRight.Write_ToStream(CurrentWriter)
            pWindowSkin_TitleBar.Write_ToStream(CurrentWriter)
            pWindowSkin_Button_Icon.Write_ToStream(CurrentWriter)
            pWindowSkin_Button_Max.Write_ToStream(CurrentWriter)
            pWindowSkin_Button_Min.Write_ToStream(CurrentWriter)
            pWindowSkin_Button_Close.Write_ToStream(CurrentWriter)
            pWindowSkin_Button_Help.Write_ToStream(CurrentWriter)
            pWindowSkin_Button_Special.Write_ToStream(CurrentWriter)
            pWindowSkin_DialogButtons.Write_ToStream(CurrentWriter)
            pWindowSkin_Dialog_Bar.Write_ToStream(CurrentWriter)
            pWindowSkin_Editor_Bar.Write_ToStream(CurrentWriter)
            Return True
        End Function
#End Region
#Region "Import"
        Public Overrides Function Read_FromStream(ByRef CurrentReader As FlexStreamEditor) As Boolean
            Dim Version As New DS_CFS_IDent(CurrentReader)
            If DS_CFS_IDent.Validate(Version, DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_Skin))) = False Then Return False
            'ADD VERSION LOGIC
            pTitleBarFont = New Wrapped_Font(CurrentReader)
            pWindowSkin_Edge_Left = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Edge_Right = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Edge_Bottom = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Corner_BottomLeft = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Corner_BottomRight = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Corner_TopLeft = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Corner_TopRight = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_TitleBar = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Button_Icon = New ControlRegion_ImageStates(CurrentReader)
            pWindowSkin_Button_Max = New ControlRegion_ImageStates(CurrentReader)
            pWindowSkin_Button_Min = New ControlRegion_ImageStates(CurrentReader)
            pWindowSkin_Button_Close = New ControlRegion_ImageStates(CurrentReader)
            pWindowSkin_Button_Help = New ControlRegion_ImageStates(CurrentReader)
            pWindowSkin_Button_Special = New ControlRegion_ImageStates(CurrentReader)

            pWindowSkin_DialogButtons = New WindowFormsConfiguration_Skin_DialogButtons(CurrentReader)
            pWindowSkin_Dialog_Bar = New ControlRegion_Image_WithGrey(CurrentReader)
            pWindowSkin_Editor_Bar = New ControlRegion_Image_WithGrey(CurrentReader)
            Return True
        End Function
#End Region
#Region "Disposing"
        Private Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                End If
                ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
                ' TODO: set large fields to null
                disposedValue = True
            End If
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace
