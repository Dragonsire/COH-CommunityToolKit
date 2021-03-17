Imports COH.CodeManagement.Enums.Toolkit

Namespace Controls
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
        Private pImageState_Normal As Image
        Private pImageState_Pressed As Image
        Private pImageState_Disabled As Image
#End Region

#Region "Initialize"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ID As FormRegions, Optional IsVisible As Boolean = True, Optional IsEnabled As Boolean = True, Optional IsMouseRegion As Boolean = True)
            MyBase.New(ID, IsVisible, IsEnabled, IsMouseRegion)
        End Sub
        Public Overrides Sub LoadImages_FromFolder(Folder As String, Format As ImageFormat)
            pImageState_Normal = MyBase.LoadImage(Folder, Format, CurrentImageState.Normal)
            pImageState_Pressed = MyBase.LoadImage(Folder, Format, CurrentImageState.Pressed)
            pImageState_Disabled = MyBase.LoadImage(Folder, Format, CurrentImageState.Disabled)
        End Sub
#End Region

#Region "Update Appearance"
        Public Sub Update_ImageStates(ByRef Normal As Image, ByRef Disabled As Image, ByRef Pressed As Image)
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

#Region "Generate Images"
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

#Region "Retrieve Appropriate Image"
        Public Function RetrieveImage_FromButtonState(Enabled As Boolean, SelectedState As CurrentImageState) As Image
            Select Case SelectedState
                Case CurrentImageState.None
                    If Enabled = False Then
                        Return ImageState_Disabled
                    Else
                        Return ImageState_Normal
                    End If
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
#End Region

#Region "Should Serialize"
        Public Function ShouldSerializeImageState_Normal() As Boolean
            'If Not pTemplate_Background = "Current" Then Return False
            Return Not (pImageState_Normal Is Nothing)
        End Function
        Public Function ShouldSerializeImageState_Disabled() As Boolean
            'If Not pTemplate_Background = "Current" Then Return False
            Return Not (pImageState_Disabled Is Nothing)
        End Function
        Public Function ShouldSerializeImageState_Pressed() As Boolean
            'If Not pTemplate_Background = "Current" Then Return False
            Return Not (pImageState_Pressed Is Nothing)
        End Function
#End Region

#Region "Drawing"
        Public Overrides Function Draw(ByRef CurrentDrawing As Graphics, Optional Forced As Boolean = False) As Boolean
            Throw New NotImplementedException()
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