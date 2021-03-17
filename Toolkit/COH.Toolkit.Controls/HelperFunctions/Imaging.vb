Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Namespace HelperFunctions.Imaging
    <HideModuleName()> Public Module DS_Image_HelperFunctions

#Region "Formats"
        Public Function RetrieveFileExtention_ForFormat(Format As ImageFormat) As String
            Return ImageCodecInfo.GetImageEncoders().First(Function(x) x.FormatID = Format.Guid).FilenameExtension.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries).First().Trim("*"c)
        End Function
#End Region

#Region "Converting"
        Public Function CopyImage_To_Bitmap(source As Image, Optional PixelFormat As PixelFormat = PixelFormat.Format32bppArgb) As Bitmap
            Dim Result As New Bitmap(source.Width, source.Height, PixelFormat)
            Using CurrnentDrawing As Graphics = Graphics.FromImage(Result)
                CurrnentDrawing.DrawImage(source, New Rectangle(0, 0, Result.Width, Result.Height), New Rectangle(0, 0, Result.Width, Result.Height), GraphicsUnit.Pixel)
                CurrnentDrawing.Flush()
            End Using
            Return Result
        End Function
#End Region

#Region "Color Matrix"
        Public Function ApplyColorMatrix_To_Bitmap(Source As Image, ColorMatrix As ColorMatrix, Optional PixelFormat As PixelFormat = PixelFormat.Format32bppArgb) As Bitmap
            Dim ImageSource_Copy As Bitmap = CopyImage_To_Bitmap(Source, PixelFormat)
            Dim Result As New Bitmap(ImageSource_Copy.Width, ImageSource_Copy.Height, PixelFormat)
            Using CurrnentDrawing As Graphics = Graphics.FromImage(Result)
                Dim BMPAttributes As New Drawing.Imaging.ImageAttributes()
                BMPAttributes.SetColorMatrix(ColorMatrix)
                CurrnentDrawing.DrawImage(ImageSource_Copy, New Rectangle(0, 0, ImageSource_Copy.Width, ImageSource_Copy.Height), 0, 0, ImageSource_Copy.Width, ImageSource_Copy.Height, GraphicsUnit.Pixel, BMPAttributes)
            End Using
            ImageSource_Copy.Dispose()
            Return Result
        End Function
#End Region

#Region "Opacity"
        Public Function Blend_TwoImages(ByRef DestinationImage As Image, ByRef BackgroundImage As Image, ByRef ForegroundImage2 As Image, Opacity As Single, Destination As Rectangle) As Image
            If BackgroundImage Is Nothing Then Return ForegroundImage2
            If ForegroundImage2 Is Nothing Then Return BackgroundImage
            Dim CurrentGraphics As Graphics = Graphics.FromImage(DestinationImage)
            Blend_TwoImages(CurrentGraphics, BackgroundImage, ForegroundImage2, Opacity, Destination)
            CurrentGraphics.Dispose()
            Return DestinationImage
        End Function
        Public Sub Blend_TwoImages(CurrentGraphics As Graphics, ByRef BackgroundImage As Image, ByRef ForegroundImage2 As Image, Opacity As Single, Destination As Rectangle)
            Dim Current_ColorMatrix As New ColorMatrix()
            Dim Current_ImageAttributes As New Drawing.Imaging.ImageAttributes()
            Current_ColorMatrix.Matrix33 = Opacity
            Current_ImageAttributes.SetColorMatrix(Current_ColorMatrix)
            CurrentGraphics.DrawImage(ForegroundImage2, Destination, 0, 0, ForegroundImage2.Width, ForegroundImage2.Height, GraphicsUnit.Pixel, Current_ImageAttributes)
            Current_ColorMatrix.Matrix33 = 1.0F - Opacity
            Current_ImageAttributes.SetColorMatrix(Current_ColorMatrix)
            CurrentGraphics.DrawImage(BackgroundImage, Destination, 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, Current_ImageAttributes)
        End Sub
#End Region

#Region "Adjust Colors"
        Public Function ConvertBitmap_GreyScale(SourceImage As Bitmap) As Bitmap
            Dim result As New Bitmap(SourceImage)
            Dim X As Integer, Y As Integer, clr As Integer
            For X = 0 To result.Width - 1
                For Y = 0 To result.Height - 1
                    clr = (CInt(result.GetPixel(X, Y).R) + result.GetPixel(X, Y).G + result.GetPixel(X, Y).B) / 3
                    result.SetPixel(X, Y, Color.FromArgb(clr, clr, clr))
                Next Y
            Next X
            Return result
        End Function
        Public Function ConvertBitmap_GreyScale_MakeTransparent(SourceImage As Bitmap, TransparentColor As Color) As Bitmap
            Dim result As Bitmap = ConvertBitmap_GreyScale(SourceImage)
            result.MakeTransparent(TransparentColor)
            Return result
        End Function
        Public Function ConvertBitmap_GreyScale2(SourceImage As Bitmap) As Bitmap
            Dim result As New Bitmap(SourceImage)
            Dim X As Integer, Y As Integer, clr As Integer
            For X = 0 To result.Width - 1
                For Y = 0 To result.Height - 1
                    clr = (CInt(result.GetPixel(X, Y).R) + result.GetPixel(X, Y).G + result.GetPixel(X, Y).B) \ 3
                    result.SetPixel(X, Y, Color.FromArgb(clr, clr, clr))
                Next Y
            Next X
            Return result
        End Function
        Public Function ConvertImage_GreyScale(SourceImage As Image) As Image
            Return ConvertBitmap_GreyScale(New Bitmap(SourceImage))
        End Function
        Public Function ConvertImage_GreyScale_MakeTransparent(SourceImage As Image, TransparentColor As Color) As Image
            Return ConvertBitmap_GreyScale_MakeTransparent(New Bitmap(SourceImage), TransparentColor)
        End Function
        Public Function ConvertImage_AdjustBrigtness(SourceImage As Image, Brightness As Single) As Image
            Dim result As New Bitmap(SourceImage)
            Dim Newgraphics As Graphics = Graphics.FromImage(result)
            Dim brt As Single = Brightness
            Dim image_attr As New Drawing.Imaging.ImageAttributes
            Dim cm As ColorMatrix = New ColorMatrix(New Single()() {New Single() {brt, 0.0, 0.0, 0.0, 0.0}, New Single() {0.0, brt, 0.0, 0.0, 0.0}, New Single() {0.0, 0.0, brt, 0.0, 0.0}, New Single() {0.0, 0.0, 0.0, 1.0, 0.0}, New Single() {0.0, 0.0, 0.0, 0.0, 1.0}})
            Dim rect As Rectangle = Rectangle.Round(SourceImage.GetBounds(GraphicsUnit.Pixel))
            Dim wid As Integer = SourceImage.Width
            Dim hgt As Integer = SourceImage.Height
            image_attr.SetColorMatrix(cm)
            Newgraphics.DrawImage(SourceImage, rect, 0, 0, wid, hgt, GraphicsUnit.Pixel, image_attr)
            Return result
        End Function
#End Region

#Region "Adjust Size"
        Public Function ResizeImage_Stretched(ByRef SelectedImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer) As Image
            Return New Bitmap(SelectedImage, TargetWidth, TargetHeight)
        End Function
        Public Function ResizeImage_Scaled(ByRef SelectedImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer) As Image
            Dim NewHeight As Integer = TargetHeight
            Dim NewWidth As Integer = NewHeight / SelectedImage.Height * SelectedImage.Width
            If NewWidth > TargetWidth Then
                NewWidth = TargetWidth
                NewHeight = NewWidth / SelectedImage.Width * SelectedImage.Height
            End If
            Return New Bitmap(SelectedImage, NewWidth, NewHeight)
        End Function
        Public Function ResizeImage_Scaled_Height(ByRef SelectedImage As Image, ByVal TargetHeight As Integer) As Image
            Dim NewHeight As Integer = TargetHeight
            Dim NewWidth As Integer = NewHeight / SelectedImage.Height * SelectedImage.Width
            Return New Bitmap(SelectedImage, NewWidth, NewHeight)
        End Function
        Public Function ResizeImage_Scaled_Width(ByRef SelectedImage As Image, ByVal TargetWidth As Integer) As Image
            Dim NewWidth As Integer = TargetWidth
            Dim NewHeight As Integer = NewWidth / SelectedImage.Width * SelectedImage.Height
            Return New Bitmap(SelectedImage, NewWidth, NewHeight)
        End Function
#End Region

#Region "Draw Functions - RectangleF"
        Public Sub DrawBackground(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As RectangleF)
            If SelectedImage Is Nothing Then Exit Sub
            CurrentDrawing.DrawImage(SelectedImage, DestinationArea)
        End Sub
        Public Sub DrawBackground_Repeated(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As RectangleF)
            If SelectedImage Is Nothing Then Exit Sub
            Dim tBrush As New TextureBrush(SelectedImage)
            CurrentDrawing.FillRectangle(tBrush, DestinationArea)
        End Sub
#End Region

#Region "Draw Functions"
        Public Sub DrawBackground(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As Rectangle)
            If SelectedImage Is Nothing Then Exit Sub
            CurrentDrawing.DrawImage(SelectedImage, DestinationArea)
        End Sub
        Public Sub DrawBackground(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As Rectangle, Opacity As Single)
            If SelectedImage Is Nothing Then Exit Sub
            Dim Current_ColorMatrix As New ColorMatrix()
            Dim Current_ImageAttributes As New Drawing.Imaging.ImageAttributes()
            Current_ColorMatrix.Matrix33 = Opacity
            Current_ImageAttributes.SetColorMatrix(Current_ColorMatrix)
            CurrentDrawing.DrawImage(SelectedImage, DestinationArea, 0, 0, SelectedImage.Width, SelectedImage.Height, GraphicsUnit.Pixel, Current_ImageAttributes)
        End Sub
        Public Sub DrawBackground(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As RectangleF, Opacity As Single)
            Dim NewRectangle As Rectangle = New Rectangle(DestinationArea.X, DestinationArea.Y, DestinationArea.Width, DestinationArea.Height)
            DrawBackground(CurrentDrawing, SelectedImage, NewRectangle, Opacity)
        End Sub
        Public Sub DrawImage_Stretched(CurrentDrawing As Graphics, SelectedImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer)
            Dim TemporaryImage As Image = ResizeImage_Stretched(SelectedImage, TargetHeight, TargetWidth)
            Dim OutPosition As PointF = New PointF(0, 0)
            Dim OutSize As SizeF = New SizeF(TargetWidth, TargetHeight)
            CurrentDrawing.DrawImage(TemporaryImage, New RectangleF(OutPosition, OutSize))
            TemporaryImage.Dispose()
        End Sub
        Public Sub DrawImage_Scaled(CurrentDrawing As Graphics, SelectedImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer)
            Dim TemporaryImage As Image = ResizeImage_Scaled(SelectedImage, TargetHeight, TargetWidth)
            Dim OutPosition As PointF = Nothing
            If TemporaryImage.Width > TemporaryImage.Height Then
                OutPosition = New PointF(0, (TargetHeight - TemporaryImage.Height) / 2)
            Else
                OutPosition = New PointF((TargetWidth - TemporaryImage.Width) / 2, 0)
            End If
            Dim OutSize As SizeF = TemporaryImage.Size
            CurrentDrawing.DrawImage(TemporaryImage, New RectangleF(OutPosition, OutSize))
            TemporaryImage.Dispose()
        End Sub
        Public Sub DrawImage_Scaled_Height(CurrentDrawing As Graphics, SelectedImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer)
            Dim TemporaryImage As Image = ResizeImage_Scaled_Height(SelectedImage, TargetHeight)
            Dim OutPosition As PointF = New PointF((TargetWidth - TemporaryImage.Width) / 2, 0)
            Dim OutSize As SizeF = New SizeF(TemporaryImage.Width, TemporaryImage.Height)
            CurrentDrawing.DrawImage(TemporaryImage, New RectangleF(OutPosition, OutSize))
            TemporaryImage.Dispose()
        End Sub
        Public Sub DrawImage_Clipped(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As Rectangle)
            If SelectedImage Is Nothing Then Exit Sub
            CurrentDrawing.DrawImageUnscaledAndClipped(SelectedImage, DestinationArea)
        End Sub
        Public Sub DrawImage_Clipped(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As RectangleF)
            If SelectedImage Is Nothing Then Exit Sub
            CurrentDrawing.DrawImageUnscaledAndClipped(SelectedImage, New Rectangle(DestinationArea.X, DestinationArea.Y, DestinationArea.Width, DestinationArea.Height))
        End Sub
        Public Sub DrawImage_Unscaled(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As RectangleF)
            If SelectedImage Is Nothing Then Exit Sub
            CurrentDrawing.DrawImageUnscaled(SelectedImage, DestinationArea.X, DestinationArea.Y, DestinationArea.Width, DestinationArea.Height)
        End Sub
        Public Sub DrawImage_Unscaled(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As RectangleF, Opacity As Single)
            If SelectedImage Is Nothing Then Exit Sub
            Dim Current_ColorMatrix As New ColorMatrix()
            Dim Current_ImageAttributes As New Drawing.Imaging.ImageAttributes()
            Current_ColorMatrix.Matrix33 = Opacity
            Current_ImageAttributes.SetColorMatrix(Current_ColorMatrix)
            Dim Dest As Rectangle = New Rectangle(DestinationArea.X, DestinationArea.Y, DestinationArea.Width, DestinationArea.Height)
            CurrentDrawing.DrawImage(SelectedImage, Dest, 0, 0, SelectedImage.Width, SelectedImage.Height, CurrentDrawing.PageUnit, Current_ImageAttributes)
        End Sub
        Public Sub DrawImage_Unscaled(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As Rectangle)
            If SelectedImage Is Nothing Then Exit Sub
            CurrentDrawing.DrawImageUnscaled(SelectedImage, DestinationArea)
        End Sub
        Public Sub DrawImage_Unscaled(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As Rectangle, Opacity As Single)
            If SelectedImage Is Nothing Then Exit Sub
            Dim Current_ColorMatrix As New ColorMatrix()
            Dim Current_ImageAttributes As New Drawing.Imaging.ImageAttributes()
            Current_ColorMatrix.Matrix33 = Opacity
            Current_ImageAttributes.SetColorMatrix(Current_ColorMatrix)
            CurrentDrawing.DrawImage(SelectedImage, DestinationArea, 0, 0, SelectedImage.Width, SelectedImage.Height, CurrentDrawing.PageUnit, Current_ImageAttributes)
        End Sub
        Public Sub DrawBackground_Repeated(CurrentDrawing As Graphics, SelectedImage As Image, DestinationArea As Rectangle)
            If SelectedImage Is Nothing Then Exit Sub
            Dim tBrush As New TextureBrush(SelectedImage)
            CurrentDrawing.FillRectangle(tBrush, DestinationArea)
        End Sub
        Public Sub DrawImage_Tiled(g As Graphics, Image As Bitmap, Destination As RectangleF)
            If Image Is Nothing Then Exit Sub
            If Image.Width = Destination.Width Then
                DrawImage_Tiled_Down(g, Image, Destination)
            ElseIf Image.Height = Destination.Height Then
                DrawImage_Tiled_Across(g, Image, Destination)
            Else
                Dim tBrush As New TextureBrush(Image)
                g.FillRectangle(tBrush, Destination)
            End If
        End Sub
        Public Sub DrawImage_Tiled(g As Graphics, Image As Bitmap, Destination As Rectangle)
            If Image Is Nothing Then Exit Sub
            If Image.Width = Destination.Width Then
                DrawImage_Tiled_Down(g, Image, Destination)
            ElseIf Image.Height = Destination.Height Then
                DrawImage_Tiled_Across(g, Image, Destination)
            Else
                Dim tBrush As New TextureBrush(Image)
                g.FillRectangle(tBrush, Destination)
            End If
        End Sub
        Public Sub DrawImage_Tiled_Down(g As Graphics, Image As Bitmap, Destination As RectangleF)
            If Image Is Nothing Then Exit Sub
            Dim SelectedSize As SizeF = Image.Size
            Dim CurrentRect As RectangleF = New RectangleF(Destination.Location, SelectedSize)
            Dim SourceRect As RectangleF = New RectangleF(0, 0, Image.Size.Width, Image.Size.Height)
            Dim HeightMax As Integer = SelectedSize.Height
            Do While CurrentRect.Location.Y < Destination.Bottom
                If (CurrentRect.Y + SelectedSize.Height) > Destination.Bottom Then
                    HeightMax = Destination.Bottom - CurrentRect.Y
                    SourceRect.Size = New Size(CurrentRect.Width, HeightMax)
                    g.DrawImageUnscaledAndClipped(Image, New Rectangle(CurrentRect.X, CurrentRect.Y, CurrentRect.Width, CurrentRect.Height))
                Else
                    g.DrawImage(Image, CurrentRect)
                End If
                CurrentRect.Location = New Point(CurrentRect.Location.X, CurrentRect.Location.Y + SelectedSize.Height)
            Loop
        End Sub
        Public Sub DrawImage_Tiled_Down(g As Graphics, Image As Bitmap, Destination As Rectangle)
            If Image Is Nothing Then Exit Sub
            Dim SelectedSize As Size = Image.Size
            Dim CurrentRect As Rectangle = New Rectangle(Destination.Location, SelectedSize)
            Dim SourceRect As Rectangle = New Rectangle(0, 0, Image.Size.Width, Image.Size.Height)
            Dim HeightMax As Integer = SelectedSize.Height
            Do While CurrentRect.Location.Y < Destination.Bottom
                If (CurrentRect.Y + SelectedSize.Height) > Destination.Bottom Then
                    HeightMax = Destination.Bottom - CurrentRect.Y
                    SourceRect.Size = New Size(CurrentRect.Width, HeightMax)
                    g.DrawImageUnscaledAndClipped(Image, CurrentRect)
                Else
                    g.DrawImage(Image, CurrentRect)
                End If
                CurrentRect.Location = New Point(CurrentRect.Location.X, CurrentRect.Location.Y + SelectedSize.Height)
            Loop
        End Sub
        Public Sub DrawImage_Tiled_Across(g As Graphics, Image As Bitmap, Destination As RectangleF)
            If Image Is Nothing Then Exit Sub
            Dim SelectedSize As SizeF = Image.Size
            Dim CurrentRect As RectangleF = New RectangleF(Destination.Location, SelectedSize)
            Dim SourceRect As RectangleF = New RectangleF(0, 0, SelectedSize.Width, SelectedSize.Height)
            Dim WidthMax As Integer = SelectedSize.Width
            Do While CurrentRect.Location.X < Destination.Right
                If (CurrentRect.X + SelectedSize.Width) > Destination.Right Then
                    WidthMax = Destination.Right - CurrentRect.X
                    CurrentRect.Size = New Size(WidthMax, CurrentRect.Height)
                    g.DrawImageUnscaledAndClipped(Image, New Rectangle(CurrentRect.X, CurrentRect.Y, CurrentRect.Width, CurrentRect.Height))
                Else
                    g.DrawImage(Image, CurrentRect)
                End If
                CurrentRect.Location = New Point(CurrentRect.Location.X + SelectedSize.Width, CurrentRect.Location.Y)
            Loop
        End Sub
        Public Sub DrawImage_Tiled_Across(g As Graphics, Image As Bitmap, Destination As Rectangle)
            If Image Is Nothing Then Exit Sub
            Dim SelectedSize As Size = Image.Size
            Dim CurrentRect As Rectangle = New Rectangle(Destination.Location, SelectedSize)
            Dim SourceRect As Rectangle = New Rectangle(0, 0, SelectedSize.Width, SelectedSize.Height)
            Dim WidthMax As Integer = SelectedSize.Width
            Do While CurrentRect.Location.X < Destination.Right
                If (CurrentRect.X + SelectedSize.Width) > Destination.Right Then
                    WidthMax = Destination.Right - CurrentRect.X
                    CurrentRect.Size = New Size(WidthMax, CurrentRect.Height)
                    'SourceRect.Size = New Size(WidthMax, SelectedSize.Height)
                    'g.DrawImage(Image, CurrentRect, SourceRect, GraphicsUnit.Display)
                    g.DrawImageUnscaledAndClipped(Image, CurrentRect)
                Else
                    g.DrawImage(Image, CurrentRect)
                End If
                CurrentRect.Location = New Point(CurrentRect.Location.X + SelectedSize.Width, CurrentRect.Location.Y)
            Loop
        End Sub
        Public Function ConvertImage_ToIcon(value As Image) As Icon
            Dim BitmapResult As Bitmap = New Bitmap(value)
            Dim Result As Icon = Icon.FromHandle(BitmapResult.GetHicon)
            Return Result
        End Function
        Public Function ConvertIcon_ToImage(value As Icon) As Image
            Dim BitmapResult As Bitmap = value.ToBitmap()
            Return Image.FromHbitmap(BitmapResult.GetHbitmap)
        End Function
        Public Function ConvertIcon_ToBytes(ByRef value As Icon) As Byte()
            Using CurrentStream As New MemoryStream()
                value.Save(CurrentStream)
                Return CurrentStream.ToArray()
            End Using
        End Function
        Public Function ConvertBytes_ToIcon(ByVal bytes() As Byte) As Icon
            Using ms As New MemoryStream(bytes)
                Return New Icon(ms)
            End Using
        End Function
#End Region

#Region "Thumbnail Stuff"
        Private Const THUMBNAIL_DATA As Integer = 20507
        Public Function Return_ThumbnailFromImage(ByVal TheImage As Image, ByVal TheThumnailSize As System.Drawing.Size) As Image
            If Return_DoesImage_HaveThumbnail(TheImage) = True Then
                Return Return_GetExistingThumbnail(TheImage)
            Else
                Return Return_NewImageThumbnail(TheImage, TheThumnailSize)
            End If
        End Function
        Public Function Return_DoesImage_HaveThumbnail(ByVal theImage As Image) As Boolean
            Try
                If Array.IndexOf(theImage.PropertyIdList, THUMBNAIL_DATA) > -1 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function Return_NewImageThumbnail_FromFile_ToTempFile(ByVal TheFileName As String, ByVal TheThumnailSize As System.Drawing.Size) As String
            Dim TempFileName As String = IO.Path.GetTempFileName
            Dim SourceImage As Bitmap = SafeLoadImage_FromFile(TheFileName)
            Dim NewImage As New Bitmap(TheThumnailSize.Width, TheThumnailSize.Height)
            Dim NewGraphics As Graphics = Graphics.FromImage(NewImage)
            NewGraphics.DrawImage(SourceImage, 0, 0, TheThumnailSize.Width + 1, TheThumnailSize.Height + 1)
            NewImage.Save(TempFileName, Drawing.Imaging.ImageFormat.Jpeg)
            NewImage.Dispose()
            SourceImage.Dispose()
            NewGraphics.Dispose()
            Return TempFileName
        End Function
        Public Function Return_NewImageThumbnail(ByVal TheImage As Image, ByVal TheThumnailSize As System.Drawing.Size) As Image
            Try
                If Not TheImage Is Nothing Then
                    Return TheImage.GetThumbnailImage(TheThumnailSize.Width, TheThumnailSize.Height, Nothing, New IntPtr())
                End If
            Catch
                Return Nothing
            End Try
            Return Nothing
        End Function
        Public Function Return_GetExistingThumbnail(ByVal theImage As Image) As Image
            Try
                If Array.IndexOf(theImage.PropertyIdList, THUMBNAIL_DATA) > -1 Then
                    Dim item1 As Drawing.Imaging.PropertyItem = theImage.GetPropertyItem(THUMBNAIL_DATA)
                    Dim buffer1 As Byte() = item1.Value
                    Dim strm As New IO.MemoryStream(buffer1.Length)
                    strm.Write(buffer1, 0, buffer1.Length)
                    Return (Image.FromStream(strm))
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
#End Region

#Region "ResizeStuff"
        Public Function ResizeImage(Image As Image, Size As Size, Optional KeepAspectRatio As Boolean = True) As Image
            If Size.Width = 0 Or Size.Height = 0 Then Return Image
            If Image Is Nothing Then Return Nothing
            Dim newWidth As Integer
            Dim newHeight As Integer
            If KeepAspectRatio Then
                Dim originalWidth As Integer = Image.Width
                Dim originalHeight As Integer = Image.Height
                Dim percentWidth As Single = CSng(Size.Width) / CSng(originalWidth)
                Dim percentHeight As Single = CSng(Size.Height) / CSng(originalHeight)
                Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)
                newWidth = CInt(originalWidth * percent)
                newHeight = CInt(originalHeight * percent)
            Else
                newWidth = Size.Width
                newHeight = Size.Height
            End If
            Dim newImage As Image = New Bitmap(newWidth, newHeight)
            Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
                graphicsHandle.InterpolationMode = Drawing2D.InterpolationMode.Bicubic
                graphicsHandle.DrawImage(Image, 0, 0, newWidth, newHeight)
            End Using
            Return newImage
        End Function
#End Region

#Region "Convert To Bytes"
        Public Function CloneImage(ByRef SourceImage As Image) As Image
            If SourceImage Is Nothing Then Return Nothing
            Return SourceImage.Clone
        End Function
        Public Function CloneImage2(ByRef SourceImage As Image) As Image
            If SourceImage Is Nothing Then Return Nothing
            Dim ImageData As Byte() = Convert_Image_ToBytes(SourceImage)
            Return Convert_Image_FromBytes(ImageData)
        End Function
        Public Function Convert_Image_ToBytes(value As Image) As Byte()
            If value Is Nothing Then Return Nothing
            Dim V1 As String = value.RawFormat.ToString
            Using mStream As New MemoryStream()
                If V1 = "MemoryBMP" Then
                    value.Save(mStream, ImageFormat.Bmp)
                Else
                    value.Save(mStream, value.RawFormat)
                End If
                Return mStream.ToArray()
            End Using
        End Function
        Public Function Convert_Image_FromBytes(Bytes As Byte()) As Image
            Dim ImageStream As MemoryStream = New MemoryStream(Bytes)
            Return Image.FromStream(ImageStream)
        End Function
        Public Function Convert_ImageFormat_ToBytes(value As Image, format As Drawing.Imaging.ImageFormat) As Byte()
            Dim ms = New MemoryStream()
            value.Save(ms, format)
            Return ms.ToArray()
        End Function
        Public Function Convert_ImageFormat(value As Image, format As Drawing.Imaging.ImageFormat) As Image
            Dim ms = New MemoryStream()
            Dim newImage As Image
            Using ms
                value.Save(ms, format)
                newImage = Image.FromStream(ms)
            End Using
            Return newImage
        End Function
#End Region

#Region "Load Images"
        Public Function SafeLoadImage_FromFile(path As String) As System.Drawing.Image
            Dim Result As System.Drawing.Image = Nothing
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read)
                Dim Result2 = Image.FromStream(fs)
                Result = New Bitmap(Result2)
            End Using
            Return Result
        End Function
#End Region

#Region "Icons"
        Private Declare Function DestroyIcon Lib "user32.dll" (ByVal handle As IntPtr) As Boolean
        Public Function ConvertImageToIcon(ByRef SourceImage As Image, IconSize As Size) As Icon
            Dim B As New Bitmap(IconSize.Width, IconSize.Height)
            Dim C As Graphics = Graphics.FromImage(B)
            C.Clear(Color.Fuchsia)
            C.DrawImage(SourceImage, 0, 0, IconSize.Width, IconSize.Height)
            C.Flush()
            B.MakeTransparent(Color.Fuchsia)
            Return Icon.FromHandle(B.GetHicon()) 'B.GetHicon()
        End Function
#End Region
    End Module
End Namespace