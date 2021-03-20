Imports COH.CodeManagement.Enums.Toolkit

Namespace Controls.Configuration
    Public NotInheritable Class FormSkinRegion_ImageRegion_Hilitable
        Inherits FormSkinRegion_ImageRegion

#Region "Properties"
        Public Property ImageState_Hilited As Image
            Get
                Return pImageState_Hilited
            End Get
            Set(Value As Image)
                UpdatePrivateProperty(pImageState_Hilited, Value)
            End Set
        End Property
        Private pImageState_Hilited As Image
#End Region

#Region "Initialize"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ID As FormRegions, ImageScaling As FormRegions_ImageScaling, Optional IsVisible As Boolean = True, Optional IsEnabled As Boolean = True, Optional IsMouseRegion As Boolean = True)
            MyBase.New(ID, ImageScaling, IsVisible, IsEnabled, IsMouseRegion)
        End Sub
        Public Overrides Sub LoadImages_FromFolder(Folder As String, Format As ImageFormat)
            pImageState_Hilited = MyBase.LoadImage(Folder, Format, CurrentImageState.Hilited)
            MyBase.LoadImages_FromFolder(Folder, Format)
        End Sub
#End Region

#Region "Update Appearance"
        Public Overloads Sub Update_ImageState_Images(ByRef Normal As Image, ByRef Disabled As Image, ByRef Pressed As Image, ByRef Hilited As Image)
            Update_ImageState_Images(Normal, Disabled, Pressed)
            pImageState_Hilited = Hilited
            RebuildImages()
        End Sub
        Public Overrides Sub Update_Images(ByRef Images As Image())
            MyBase.Update_Images(Images)
            If (Images Is Nothing) Then
                pImageState_Hilited = Nothing
            Else
                pImageState_Hilited = Images(3)
            End If
            RebuildImages()
        End Sub
        Private Sub RebuildImages()
            If Not ImageState_Normal Is Nothing Then
                If ImageState_Hilited Is Nothing Then pImageState_Hilited = Me.Generate_HilitedButton(ImageState_Normal)
            End If
        End Sub
        Public Overrides Sub ResizeImages(DesiredSize As Size)
            If DesiredSize.Width = 0 Or DesiredSize.Height = 0 Then Exit Sub
            MyBase.ResizeImages(DesiredSize)
            If Not ImageState_Hilited Is Nothing AndAlso Equals(DesiredSize, ImageState_Hilited.Size) = False Then ImageState_Hilited = HelperFunctions.Imaging.ResizeImage(ImageState_Hilited, DesiredSize)
        End Sub
#End Region

#Region "Generate Images"
        Private Function Generate_HilitedButton(Optional value As Drawing.Image = Nothing) As Drawing.Image
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
            Return MyBase.Draw(CurrentDrawing, Forced)
        End Function
        Public Overrides Function RetrieveImage_FromState() As Image
            If CurrentState = CurrentImageState.Hilited Then
                If ImageState_Hilited Is Nothing Then
                    Return ImageState_Normal
                Else
                    Return ImageState_Hilited
                End If
            Else
                Return MyBase.RetrieveImage_FromState
            End If
        End Function
#End Region

#Region "Clone/Write"
        Public Overrides Function Clone() As Object
            Dim Destination As New FormSkinRegion_ImageRegion_Hilitable()
            CloneTo(Destination)
            Return Destination
        End Function
        Protected Overloads Sub CloneTo(ByRef Destination As FormSkinRegion_ImageRegion_Hilitable)
            With Destination
                MyBase.CloneTo(CType(Destination, FormSkinRegion_ImageRegion))
                .pImageState_Hilited = HelperFunctions.Imaging.CloneImage(pImageState_Hilited)
            End With
        End Sub
#End Region
    End Class
End Namespace