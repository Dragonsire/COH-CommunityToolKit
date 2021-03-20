Imports COH.CodeManagement.Enums.Toolkit
Imports COH.HelperClasses.Wrappers

Namespace Controls.Configuration
    Public NotInheritable Class FormsConfiguration_FormSkin

#Region "Properties"
        Public ReadOnly Property TitleBar As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.TitleBar)
            End Get
        End Property
        Public ReadOnly Property Icon As FormSkinRegion_ImageRegion
            Get
                Return pFormSkinRegions(FormRegions.Icon)
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
        Public Property TitleBarFont As COH_XML_Font
        Private pAllowResize As Boolean = True
        Private rMouseLocation As Point
        Private rMouseOffset As Point
        Private rIsMoving As Boolean
        Private rIsResizing As Boolean
        Private rMouseLastPosition_WasOverButon As Boolean
        Private rMouseLastPosition_WasOverDialogButon As Boolean
        Private rMouseLastButon As FormSkinRegion_ImageRegion_Hilitable
        Private pFormSkinRegions As Dictionary(Of FormRegions, FormSkinRegion)
        Private rControlledForm As ToolkitForm
#End Region

#Region "Initialize"
        Public Sub New()
            MyBase.New
            ResetToDefault()
        End Sub
        Public Sub LinkForm(ByRef ParentForm As ToolkitForm)
            rControlledForm = ParentForm
        End Sub
        Public Sub ResetToDefault()
            TitleBarFont = New COH_XML_Font
            pFormSkinRegions = New Dictionary(Of FormRegions, FormSkinRegion)
            pFormSkinRegions.Add(FormRegions.TitleBar, New FormSkinRegion_ImageRegion(FormRegions.TitleBar, FormRegions_ImageScaling.TiledAcross))
            pFormSkinRegions.Add(FormRegions.Edge_Left, New FormSkinRegion_ImageRegion(FormRegions.Edge_Left, FormRegions_ImageScaling.TiledDown))
            pFormSkinRegions.Add(FormRegions.Edge_Right, New FormSkinRegion_ImageRegion(FormRegions.Edge_Right, FormRegions_ImageScaling.TiledDown))
            pFormSkinRegions.Add(FormRegions.Edge_Bottom, New FormSkinRegion_ImageRegion(FormRegions.Edge_Bottom, FormRegions_ImageScaling.TiledAcross))
            pFormSkinRegions.Add(FormRegions.Corner_BottomLeft, New FormSkinRegion_ImageRegion(FormRegions.Corner_BottomLeft, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Corner_BottomRight, New FormSkinRegion_ImageRegion(FormRegions.Corner_BottomRight, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Corner_TopLeft, New FormSkinRegion_ImageRegion(FormRegions.Corner_TopLeft, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Corner_TopRight, New FormSkinRegion_ImageRegion(FormRegions.Corner_TopRight, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Button_Min, New FormSkinRegion_ImageRegion_Hilitable(FormRegions.Button_Min, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Button_Max, New FormSkinRegion_ImageRegion_Hilitable(FormRegions.Button_Max, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Button_Close, New FormSkinRegion_ImageRegion_Hilitable(FormRegions.Button_Close, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Icon, New FormSkinRegion_ImageRegion(FormRegions.Icon, FormRegions_ImageScaling.MaintainOriginalSize))
            pFormSkinRegions.Add(FormRegions.Button_Help, New FormSkinRegion_ImageRegion_Hilitable(FormRegions.Button_Help, FormRegions_ImageScaling.MaintainOriginalSize))
        End Sub
#End Region

#Region "General"
        Public Sub UpdateFormEnabled(IsEnabled As Boolean)
            For Each SkinArea In pFormSkinRegions
                If IsEnabled = False Then
                    SkinArea.Value.Update_ImageState(CurrentImageState.Disabled)
                Else
                    SkinArea.Value.Update_ImageState(CurrentImageState.Normal)
                End If
            Next
        End Sub
#End Region

#Region "Theme"
        Public Shared Function LoadTheme_FromFolder(Folder As String) As FormsConfiguration_FormSkin
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
        Public Shared Function LoadTheme_FromFolder(Folder As String, Format As Imaging.ImageFormat) As FormsConfiguration_FormSkin
            Dim LoadedSkin As New FormsConfiguration_FormSkin
            For Each SkinArea In LoadedSkin.SkinRegions
                SkinArea.Value.LoadImages_FromFolder(Folder, Format)
            Next
            Return LoadedSkin
        End Function
#End Region

#Region "Drawing - Form Sections"
        Public Sub Draw_Window(Text As String, CurrentDrawing As Graphics)
            Edge_Bottom.Draw(CurrentDrawing)
            Edge_Left.Draw(CurrentDrawing)
            Edge_Right.Draw(CurrentDrawing)
            Corner_BottomLeft.Draw(CurrentDrawing)
            Corner_BottomRight.Draw(CurrentDrawing)
            TitleBar.Draw(CurrentDrawing)
            Draw_Icon(CurrentDrawing)
            Corner_TopLeft.Draw(CurrentDrawing)
            Corner_TopRight.Draw(CurrentDrawing)
            Draw_Window_Buttons(CurrentDrawing)
            CurrentDrawing.DrawString(Text, TitleBarFont, TitleBarFont.Return_Font_SolidBrush, New Rectangle(Icon.Location.Right + 2, 0, TitleBar.Location.Width - Icon.Location.Width, TitleBar.Location.Height))
        End Sub
        Public Sub Draw_TitleBar(Text As String, CurrentDrawing As Drawing.Graphics)
            TitleBar.Draw(CurrentDrawing)
            Draw_Window_Buttons(CurrentDrawing)
            Draw_Icon(CurrentDrawing)
            CurrentDrawing.DrawString(Text, TitleBarFont, TitleBarFont.Return_Font_SolidBrush, New Rectangle(Icon.Location.Right + 2, 0, TitleBar.Location.Width - Icon.Location.Width, TitleBar.Location.Height))
        End Sub
        Public Sub Draw_WindowDialog(CurrentDrawing As Drawing.Graphics)
            'If DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.DialogBar Then
            ' Draw_DialogBar(CurrentDrawing)
            'ElseIf DialogButtons.FormDialogStyle = WindowForms_WindowSkin_DialogStyle.EditorBar Then
            'Draw_EditorBar(CurrentDrawing)
            'End If
        End Sub
        Public Sub Draw_DialogBar(CurrentDrawing As Drawing.Graphics)
            'WindowSkin_Dialog_Bar.Draw(CurrentDrawing)
            'Draw_Dialog_Buttons(CurrentDrawing)
        End Sub
        Public Sub Draw_EditorBar(CurrentDrawing As Drawing.Graphics)
            'WindowSkin_Editor_Bar.Draw(CurrentDrawing)
            'Draw_Dialog_Buttons(CurrentDrawing)
        End Sub
#End Region

#Region "Drawing Buttons"
        Public Sub Draw_Icon(CurrentDrawing As Drawing.Graphics)
            If CurrentDrawing Is Nothing Then Exit Sub
            Icon.Draw(CurrentDrawing, True)
            End Sub
        Public Sub Draw_Window_Buttons(CurrentDrawing As Drawing.Graphics)
            If CurrentDrawing Is Nothing Then Exit Sub
            Button_Close.Draw(CurrentDrawing, True)
            If rControlledForm.HelpButton = True Then Button_Help.Draw(CurrentDrawing, True)
            If rControlledForm.MaximizeBox = True Then Button_Max.Draw(CurrentDrawing, True)
            If rControlledForm.MinimizeBox = True Then Button_Min.Draw(CurrentDrawing, True)
            '/Button_Special.Draw(CurrentDrawing, True)
        End Sub
        Public Sub Draw_Dialog_Buttons(CurrentDrawing As Drawing.Graphics)
            'DialogButtons.Draw_Dialog_Buttons(CurrentDrawing)
        End Sub
#End Region

#Region "Clone"
        Public Function CreateClone() As FormsConfiguration_FormSkin
            Dim Destination As New FormsConfiguration_FormSkin
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As FormsConfiguration_FormSkin)
            With Destination
                .pFormSkinRegions = New Dictionary(Of FormRegions, FormSkinRegion)
                For Each Entry In .pFormSkinRegions
                    .pFormSkinRegions.Add(Entry.Key, Entry.Value.Clone)
                Next
            End With
        End Sub
#End Region
    End Class
End Namespace