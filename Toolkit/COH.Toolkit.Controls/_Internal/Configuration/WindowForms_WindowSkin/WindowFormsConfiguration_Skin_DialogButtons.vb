Imports System.Drawing
Imports DS._CoreLibrary_.v6.FileStructures.BitsANDBytes

Namespace Controls.WinForms._WindowForms_
    <TypeConverter(GetType(ExpandableObjectConverter))> <DS_CFS_IDent(WinForms_LibraryClasses.WindowForms_Skin_DialogButtons, 1)> Public NotInheritable Class WindowFormsConfiguration_Skin_DialogButtons
        Inherits DS_CFS_MonitorChanges

#Region "Properties - Dialog Area"
        Public Property FormDialogStyle As WindowForms_WindowSkin_DialogStyle
            Get
                Return pFormDialogStyle
            End Get
            Set(Value As WindowForms_WindowSkin_DialogStyle)
                UpdatePrivateProperty(pFormDialogStyle, Value)
            End Set
        End Property
        Public Property FormDialogButtonLayout As WindowForms_WindowSkin_ButtonLayouts
            Get
                Return pFormDialogButtonLayout
            End Get
            Set(Value As WindowForms_WindowSkin_ButtonLayouts)
                UpdatePrivateProperty(pFormDialogButtonLayout, Value)
            End Set
        End Property
        Public Property FormDialogButtonPadding As Integer
            Get
                Return pFormDialogButtonPadding
            End Get
            Set(Value As Integer)
                UpdatePrivateProperty(pFormDialogButtonPadding, Value)
            End Set
        End Property
        Public Property WindowSkin_DialogButtons As Wrapped_XML_Dictionary(Of ControlRegion_ImageStates)
            Get
                Return pWindowSkin_DialogButtons
            End Get
            Set(Value As Wrapped_XML_Dictionary(Of ControlRegion_ImageStates))
                UpdatePrivateProperty(pWindowSkin_DialogButtons, Value)
            End Set
        End Property
#End Region

#Region "Private Properties"
        '///DIALOG AREA
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pFormDialogStyle As WindowForms_WindowSkin_DialogStyle
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pFormDialogButtonLayout As WindowForms_WindowSkin_ButtonLayouts
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pFormDialogButtonPadding As Integer
        <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pWindowSkin_DialogButtons As Wrapped_XML_Dictionary(Of ControlRegion_ImageStates)
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
            pFormDialogStyle = WindowForms_WindowSkin_DialogStyle.None
            pFormDialogButtonPadding = 10
            pFormDialogButtonLayout = WindowForms_WindowSkin_ButtonLayouts.NoAux
            pWindowSkin_DialogButtons = New Wrapped_XML_Dictionary(Of ControlRegion_ImageStates)
            MyBase.ResetToDefault()
        End Sub
#End Region

#Region "Internal Functions"
        Public Function Check_IsMouse_OverAvailableButton(Location As Point, ByRef SelectedButton As ControlRegion_ImageStates) As Boolean
            If SelectedButton.Is_MouseRegion = False Then Return False
            If SelectedButton.Visible = False Then Return False
            If SelectedButton.Enabled = False Then Return False
            Return SelectedButton.Check_MouseLocation_WithinDrawArea(Location)
        End Function
        Public Function Check_IsMouse_OverDialogButton(Location As Point, ByRef Result As String, ByRef SelectedButton As ControlRegion_ImageStates) As Boolean
            Result = String.Empty
            For Each Button In pWindowSkin_DialogButtons
                If Check_IsMouse_OverAvailableButton(Location, Button.Value) Then
                    Result = Button.Key
                    SelectedButton = Button.Value
                    Return True
                End If
            Next
            Return False
        End Function
#End Region

#Region "Modifying - Locations"
        Public Sub Calculate_DrawableLocations(ClientRectangle As Rectangle, ByRef rUsableClientArea As Rectangle, ByRef ParentSkin As WindowFormsConfiguration_Skin)
            If FormDialogStyle = WindowForms_WindowSkin_DialogStyle.None Then
                rUsableClientArea = New Rectangle(ParentSkin.WindowSkin_Edge_Right.LoadedImage.Size.Width, ParentSkin.WindowSkin_TitleBar.LoadedImage.Height, ClientRectangle.Width - (ParentSkin.WindowSkin_Edge_Right.LoadedImage.Size.Width * 2), ClientRectangle.Height - (ParentSkin.WindowSkin_Edge_Bottom.LoadedImage.Size.Height + ParentSkin.WindowSkin_TitleBar.LoadedImage.Height))
                ParentSkin.WindowSkin_Dialog_Bar.Visible = False
                ParentSkin.WindowSkin_Editor_Bar.Visible = False
            ElseIf pFormDialogStyle = WindowForms_WindowSkin_DialogStyle.DialogBar Then
                rUsableClientArea = New Rectangle(ParentSkin.WindowSkin_Edge_Right.LoadedImage.Size.Width, ParentSkin.WindowSkin_TitleBar.LoadedImage.Height, ClientRectangle.Width - (ParentSkin.WindowSkin_Edge_Right.LoadedImage.Size.Width * 2), ClientRectangle.Height - (ParentSkin.WindowSkin_Edge_Bottom.LoadedImage.Size.Height + ParentSkin.WindowSkin_TitleBar.LoadedImage.Height + ParentSkin.WindowSkin_Dialog_Bar.LoadedImage.Height))
                ParentSkin.WindowSkin_Dialog_Bar.Visible = True
                ParentSkin.WindowSkin_Editor_Bar.Visible = False
                ParentSkin.WindowSkin_Dialog_Bar.Update_DrawingLocation(New Rectangle(ParentSkin.WindowSkin_Edge_Right.LoadedImage.Size.Width, ClientRectangle.Height - (ParentSkin.WindowSkin_Dialog_Bar.LoadedImage.Height + ParentSkin.WindowSkin_Edge_Bottom.LoadedImage.Height), ClientRectangle.Width - (ParentSkin.WindowSkin_Edge_Right.LoadedImage.Size.Width * 2), ParentSkin.WindowSkin_Dialog_Bar.LoadedImage.Height))
                Calculate_DrawableLocations_DialogButtons(ParentSkin.WindowSkin_Dialog_Bar.ClientLocation)
            ElseIf pFormDialogStyle = WindowForms_WindowSkin_DialogStyle.EditorBar Then
                ParentSkin.WindowSkin_Dialog_Bar.Visible = False
                ParentSkin.WindowSkin_Editor_Bar.Visible = True
                ' rUsableClientArea = New Rectangle(ClientRectangle.Width - (pWindowSkin_Editor_Bar.LoadedImage.Width + pWindowSkin_Edge_Right.LoadedImage.Width), pWindowSkin_TitleBar.LoadedImage.Height, pWindowSkin_Editor_Bar.LoadedImage.Width, ClientRectangle.Height - (pWindowSkin_Edge_Bottom.LoadedImage.Size.Height + pWindowSkin_TitleBar.LoadedImage.Height))
                '/ pWindowSkin_Editor_Bar.Update_DrawingLocation(New Rectangle(ClientRectangle.Width - pWindowSkin_Edge_Right.LoadedImage.Width, pWindowSkin_TitleBar.LoadedImage.Height, pWindowSkin_Editor_Bar.LoadedImage.Width, ClientRectangle.Height - (pWindowSkin_Edge_Bottom.LoadedImage.Size.Height + pWindowSkin_TitleBar.LoadedImage.Height)))
                '//Calculate_DrawableLocations_EditorButtons(pWindowSkin_Dialog_Bar.ClientLocation)
            End If
        End Sub
        Public Sub Calculate_DrawableLocations_DialogButtons(ParentArea As RectangleF)
            If pWindowSkin_DialogButtons.Count = 0 Then Exit Sub
            Dim NumberButtonsLeft As Integer, NumberButtonsRight As Integer
            Determine_ButtonLayoutNumbers(pFormDialogButtonLayout, NumberButtonsLeft, NumberButtonsRight)
            Dim ButtonIndex As Integer = 0
            Dim Padding As Integer = pFormDialogButtonPadding, ButtonSize As Size, ButtonLocationStart As Point
            Determine_ButtonSize_Squared(ParentArea.Height, Padding, ButtonSize, ButtonLocationStart)
            ButtonLocationStart = New Point(ParentArea.X + ButtonLocationStart.X, ParentArea.Y + ButtonLocationStart.Y)
            For X = 0 To NumberButtonsLeft - 1
                If ButtonIndex = pWindowSkin_DialogButtons.Count Then Exit For
                Dim CurrentButton = pWindowSkin_DialogButtons.ElementAt(ButtonIndex)
                Dim NewPoint As Point = New Point(ButtonLocationStart.X + ((X * ButtonSize.Width) + (X * (Padding * 1))), ButtonLocationStart.Y)
                Dim NewLocation As Rectangle = New Rectangle(NewPoint, ButtonSize)
                CurrentButton.Value.Update_DrawingLocation(NewLocation)
                ButtonIndex += 1
            Next
            ButtonLocationStart = New Point(ParentArea.Width - (ButtonLocationStart.X + ButtonSize.Width), ButtonLocationStart.Y)
            For X = 0 To NumberButtonsRight - 1
                If ButtonIndex = pWindowSkin_DialogButtons.Count Then Exit For
                Dim CurrentButton = pWindowSkin_DialogButtons.ElementAt(ButtonIndex)
                Dim NewPoint As Point = New Point(ButtonLocationStart.X - ((X * ButtonSize.Width) + (X * (Padding * 1))), ButtonLocationStart.Y)
                Dim NewLocation As Rectangle = New Rectangle(NewPoint, ButtonSize)
                CurrentButton.Value.Update_DrawingLocation(NewLocation)
                ButtonIndex += 1
            Next
        End Sub
        Private Sub Determine_ButtonSize_Squared(Value As Integer, ByRef Padding As Integer, ByRef ResultSize As Size, ByRef ResultPoint As Point)
            Dim Result As Integer = Value - (Padding * 2)
            If Result < 0 Then
                Padding = 2
                ResultSize = New Size(Value - 2, Value - 2)
                ResultPoint = New Point(2, 2)
            Else
                ResultSize = New Size(Result, Result)
                ResultPoint = New Point(Padding, Padding)
            End If
        End Sub
        Public Sub Calculate_DrawableLocations_EditorButtons(ParentArea As RectangleF)
            If pWindowSkin_DialogButtons.Count = 0 Then Exit Sub
        End Sub
        Private Sub Determine_ButtonLayoutNumbers(Layout As WindowForms_WindowSkin_ButtonLayouts, ByRef V1 As Integer, ByRef V2 As Integer)
            Select Case Layout
                Case WindowForms_WindowSkin_ButtonLayouts.NoAux
                    V1 = 0 : V2 = pWindowSkin_DialogButtons.Count
                Case WindowForms_WindowSkin_ButtonLayouts.OneAux
                    V1 = 1 : V2 = pWindowSkin_DialogButtons.Count - 1
                Case WindowForms_WindowSkin_ButtonLayouts.TwoAux
                    V1 = 2 : V2 = pWindowSkin_DialogButtons.Count - 2
            End Select
        End Sub
#End Region

#Region "Modifying - Enable/Disable Form"
        Public Sub ChangeAll_DialogButtons_Enabled(Optional Enabled As Boolean = True)
            For Each Button In pWindowSkin_DialogButtons
                Button.Value.Enabled = Enabled
            Next
        End Sub
#End Region

#Region "Modifying - Dialog Button States"
        Public Sub Update_DialogButtons_Unselected(ExceptKey As String)
            For Each Button In pWindowSkin_DialogButtons
                If Not String.Equals(Button.Key, ExceptKey) Then Button.Value.Update_ImageState_UnHilited()
            Next
        End Sub
        Public Sub Update_DialogButton_Hilited(Key As String)
            pWindowSkin_DialogButtons(Key).Update_ImageState_Hilited()
            Update_DialogButtons_Unselected(Key)
        End Sub
        Public Sub Update_DialogButton_Pressed(Key As String)
            pWindowSkin_DialogButtons(Key).Update_ImageState_Pressed()
            Update_DialogButtons_Unselected(Key)
        End Sub
#End Region

#Region "Drawing Buttons"
        Public Sub Draw_Dialog_Buttons(CurrentDrawing As Drawing.Graphics)
            If CurrentDrawing Is Nothing Then Exit Sub
            For Each Button In pWindowSkin_DialogButtons
                Button.Value.Draw(CurrentDrawing, True)
            Next
        End Sub
#End Region

#Region "Clone"
        Public Overrides Function Clone() As Object
            Dim Result As New WindowFormsConfiguration_Skin_DialogButtons
            CloneTo(Result)
            Return Result
        End Function
        Public Overloads Function CreateClone() As WindowFormsConfiguration_Skin_DialogButtons
            Dim Destination As New WindowFormsConfiguration_Skin_DialogButtons
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As WindowFormsConfiguration_Skin_DialogButtons)
            With Destination
                .pFormDialogStyle = pFormDialogStyle
                .pFormDialogButtonLayout = pFormDialogButtonLayout
                .pFormDialogButtonPadding = pFormDialogButtonPadding
                .pWindowSkin_DialogButtons = New Wrapped_XML_Dictionary(Of ControlRegion_ImageStates)
                For Each Entry In pWindowSkin_DialogButtons
                    .pWindowSkin_DialogButtons.Add(Entry.Key, Entry.Value.Clone)
                Next
            End With
            CloneTo(TryCast(Destination, DS_CFS_MonitorChanges))
        End Sub
#End Region
#Region "Export"
        Public Overrides Function Write_ToStream(ByRef CurrentWriter As FlexStreamEditor) As Boolean
            Dim Version As DS_CFS_IDent = DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_Skin_DialogButtons))
            Version.WriteToStream(CurrentWriter)
            CurrentWriter.Write(pFormDialogStyle)
            CurrentWriter.Write(pFormDialogButtonLayout)
            CurrentWriter.Write(pFormDialogButtonPadding)

            CurrentWriter.Write(CInt(pWindowSkin_DialogButtons.Count))
            For Each Entry In pWindowSkin_DialogButtons
                CurrentWriter.Write(Entry.Key)
                Entry.Value.Write_ToStream(CurrentWriter)
            Next

            Return True
        End Function
#End Region

#Region "Import"
        Public Overrides Function Read_FromStream(ByRef CurrentReader As FlexStreamEditor) As Boolean
            Dim Version As New DS_CFS_IDent(CurrentReader)
            If DS_CFS_IDent.Validate(Version, DS_CFS_IDent.GetAttribute(GetType(WindowFormsConfiguration_Skin_DialogButtons))) = False Then Return False
            'ADD VERSION LOGIC
            pFormDialogStyle = CurrentReader.ReadInt32
            pFormDialogButtonLayout = CurrentReader.ReadInt32
            pFormDialogButtonPadding = CurrentReader.ReadInt32

            Dim Count As Integer = CurrentReader.ReadInt32
            pWindowSkin_DialogButtons = New Wrapped_XML_Dictionary(Of ControlRegion_ImageStates)
            For X = 0 To Count - 1
                pWindowSkin_DialogButtons.Add(CurrentReader.ReadString, New ControlRegion_ImageStates(CurrentReader))
            Next

            Return True
        End Function
#End Region
    End Class
End Namespace
