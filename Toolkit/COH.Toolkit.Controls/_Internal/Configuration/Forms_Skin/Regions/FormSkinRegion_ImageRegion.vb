Imports COH.CodeManagement.Enums.Toolkit

Namespace Controls.Configuration
    Public Class FormSkinRegion_ImageRegion
        Inherits FormSkinRegion

#Region "Properties"
        Public Property ImageState_Normal As Image
            Get
                Return pImageState_Normal
            End Get
            Set(Value As Image)
                UpdatePrivateProperty(pImageState_Normal, Value)
            End Set
        End Property
        Public Property ImageState_Disabled As Image
            Get
                Return pImageState_Disabled
            End Get
            Set(Value As Image)
                UpdatePrivateProperty(pImageState_Disabled, Value)
            End Set
        End Property
        Public Property ImageState_Pressed As Image
            Get
                Return pImageState_Pressed
            End Get
            Set(Value As Image)
                UpdatePrivateProperty(pImageState_Pressed, Value)
            End Set
        End Property
        Public Property ImageScaling As FormRegions_ImageScaling
            Get
                Return pImageScaling
            End Get
            Set(value As FormRegions_ImageScaling)
                UpdatePrivateProperty(pImageScaling, value)
            End Set
        End Property
        Private pImageState_Normal As Image
        Private pImageState_Pressed As Image
        Private pImageState_Disabled As Image
        Private pImageScaling As FormRegions_ImageScaling
        Private pImageOpacity As Single
#End Region

#Region "Initialize"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ID As FormRegions, ImageScaling As FormRegions_ImageScaling, Optional IsVisible As Boolean = True, Optional IsEnabled As Boolean = True, Optional IsMouseRegion As Boolean = True)
            MyBase.New(ID, IsVisible, IsEnabled, IsMouseRegion)
            pImageScaling = ImageScaling
            pImageOpacity = 1
        End Sub
#End Region

#Region "Update Image Sources"
        Public Overrides Sub LoadImages_FromFolder(Folder As String, Format As ImageFormat)
            pImageState_Normal = MyBase.LoadImage(Folder, Format, CurrentImageState.Normal)
            pImageState_Pressed = MyBase.LoadImage(Folder, Format, CurrentImageState.Pressed)
            pImageState_Disabled = MyBase.LoadImage(Folder, Format, CurrentImageState.Disabled)
        End Sub
        Public Sub Update_ImageState_Images(ByRef Normal As Image, ByRef Disabled As Image, ByRef Pressed As Image)
            pImageState_Normal = Normal
            pImageState_Disabled = Disabled
            pImageState_Pressed = Pressed
            RebuildImages()
        End Sub
        Public Overridable Sub Update_Images(ByRef Images As Image())
            If (Images Is Nothing) Then
                pImageState_Normal = Nothing
                pImageState_Disabled = Nothing
                pImageState_Pressed = Nothing
            Else
                pImageState_Normal = Images(0)
                pImageState_Pressed = Images(1)
                pImageState_Disabled = Images(2)
            End If
            RebuildImages()
        End Sub
        Private Sub RebuildImages()
            If Not ImageState_Normal Is Nothing Then
                If ImageState_Disabled Is Nothing Then pImageState_Disabled = Me.Generate_DisabledButton(pImageState_Normal)
                If ImageState_Pressed Is Nothing Then pImageState_Pressed = pImageState_Normal
            End If
            If Not pImageState_Normal Is Nothing Then ResizeImages(pImageState_Normal.Size)
        End Sub
        Public Overridable Sub ResizeImages(DesiredSize As Size)
            If DesiredSize.Width = 0 Or DesiredSize.Height = 0 Then Exit Sub
            If Not ImageState_Normal Is Nothing AndAlso Equals(DesiredSize, ImageState_Normal.Size) = False Then pImageState_Normal = HelperFunctions.Imaging.ResizeImage(ImageState_Normal, DesiredSize)
            If Not ImageState_Disabled Is Nothing AndAlso Equals(DesiredSize, ImageState_Disabled.Size) = False Then pImageState_Disabled = HelperFunctions.Imaging.ResizeImage(ImageState_Disabled, DesiredSize)
            If Not ImageState_Pressed Is Nothing AndAlso Equals(DesiredSize, ImageState_Pressed.Size) = False Then pImageState_Pressed = HelperFunctions.Imaging.ResizeImage(ImageState_Pressed, DesiredSize)
        End Sub
#End Region

#Region "Update Image Sources - Generate Missing Images"
        Private Function Generate_PressedButton(Optional value As Drawing.Image = Nothing) As Drawing.Image
            If value Is Nothing Then Return Nothing
            'Dim NewImage As Image = HelperFunctions.Imaging.ConvertImage_AdjustBrigtness(value, 2)
            'Return NewImage
        End Function
        Private Function Generate_DisabledButton(Optional value As Image = Nothing) As Image
            If value Is Nothing Then Return Nothing
            'Dim NewImage As Image = HelperFunctions.Imaging.ConvertImage_GreyScale(value)
            'Return NewImage
        End Function 'New 
#End Region

#Region "Drawing"
        Public Overrides Function Draw(ByRef CurrentDrawing As Drawing.Graphics, Optional Forced As Boolean = False) As Boolean
            Dim SourceImage = RetrieveImage_FromState()
            Return DrawImage(SourceImage, CurrentDrawing, ClientLocation, Forced)
        End Function
        Public Overridable Function RetrieveImage_FromState() As Image
            Select Case CurrentState
                Case CurrentImageState.Disabled
                    Return ImageState_Disabled
                Case CurrentImageState.Normal
                    Return ImageState_Normal
                Case CurrentImageState.Pressed
                    If ImageState_Pressed Is Nothing Then
                        Return ImageState_Normal
                    Else
                        Return ImageState_Pressed
                    End If
                Case Else
                    Return ImageState_Normal
            End Select
        End Function
        Private Function DrawImage(ByRef SelectedImage As Image, CurrentDrawing As Drawing.Graphics, Area As RectangleF, Optional Forced As Boolean = False) As Boolean
            If pImageOpacity = 1 Then
                Return DrawImage_Solid(SelectedImage, CurrentDrawing, Area, Forced)
            Else
                Return DrawImage_WithOpacity(SelectedImage, CurrentDrawing, Area, Forced)
            End If
        End Function
        Private Function DrawImage_Solid(ByRef SelectedImage As Image, CurrentDrawing As Drawing.Graphics, Area As RectangleF, Optional Forced As Boolean = False) As Boolean
            If Visible = False Then Return True
            Select Case pImageScaling
                Case FormRegions_ImageScaling.MaintainOriginalSize
                    HelperFunctions.Imaging.DrawImage_Unscaled(CurrentDrawing, SelectedImage, Area)
                Case FormRegions_ImageScaling.FillRectangle
                    HelperFunctions.Imaging.DrawBackground_Repeated(CurrentDrawing, SelectedImage, Area)
                Case FormRegions_ImageScaling.TiledDown
                    HelperFunctions.Imaging.DrawImage_Tiled_Down(CurrentDrawing, SelectedImage, Area)
                Case FormRegions_ImageScaling.TiledAcross
                    HelperFunctions.Imaging.DrawImage_Tiled_Across(CurrentDrawing, SelectedImage, Area)
                Case FormRegions_ImageScaling.FitToRectangle
                    HelperFunctions.Imaging.DrawBackground(CurrentDrawing, SelectedImage, Area)
                Case FormRegions_ImageScaling.ClipToRectangle
                    HelperFunctions.Imaging.DrawImage_Clipped(CurrentDrawing, SelectedImage, Area)
            End Select
            Return True
        End Function
        Private Function DrawImage_WithOpacity(ByRef SelectedImage As Image, CurrentDrawing As Drawing.Graphics, Area As RectangleF, Optional Forced As Boolean = False) As Boolean
            If Visible = False Then Return True
            Select Case pImageScaling
                Case FormRegions_ImageScaling.MaintainOriginalSize
                    HelperFunctions.Imaging.DrawImage_Unscaled(CurrentDrawing, SelectedImage, Area, pImageOpacity)
                Case FormRegions_ImageScaling.FitToRectangle
                    HelperFunctions.Imaging.DrawBackground(CurrentDrawing, SelectedImage, Area, pImageOpacity)
                    '//NOT UPDATED YET
                Case FormRegions_ImageScaling.FillRectangle
                    HelperFunctions.Imaging.DrawBackground_Repeated(CurrentDrawing, SelectedImage, Area)
                Case FormRegions_ImageScaling.TiledDown
                    HelperFunctions.Imaging.DrawImage_Tiled_Down(CurrentDrawing, SelectedImage, Area)
                Case FormRegions_ImageScaling.TiledAcross
                    HelperFunctions.Imaging.DrawImage_Tiled_Across(CurrentDrawing, SelectedImage, Area)
            End Select
            Return True
        End Function
#End Region

#Region "Clone/Write"
        Public Overrides Function Clone() As Object
            Dim Destination As New FormSkinRegion_ImageRegion()
            CloneTo(Destination)
            Return Destination
        End Function
        Protected Overloads Sub CloneTo(ByRef Destination As FormSkinRegion_ImageRegion)
            With Destination
                MyBase.CloneTo(Destination)
                '.pImageState_Normal = pButtonState_Normal.CloneImage
                '.pImageState_Disabled = pButtonState_Disabled.CloneImage
                '.pImageState_Hilited = pButtonState_Hilited.CloneImage
                '.pImageState_Pressed = pButtonState_Pressed.CloneImage
            End With
        End Sub


#End Region
    End Class
End Namespace