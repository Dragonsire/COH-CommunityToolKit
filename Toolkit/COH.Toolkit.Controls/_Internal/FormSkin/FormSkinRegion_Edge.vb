Namespace Controls
    Public NotInheritable Class FormSkinRegion_Edge
        Inherits FormSkinRegion

#Region "Properties"
        Public Enum CurrentEdgeState
            None = 0
            Normal
            Pressed
            Disabled
        End Enum
        Public Property ButtonState_Normal As Image
            Get
                Return pButtonState_Normal
            End Get
            Set(Value As Image)
                UpdatePrivateProperty(pButtonState_Normal, Value)
            End Set
        End Property
        Public Property ButtonState_Disabled As Image
            Get
                Return pButtonState_Disabled
            End Get
            Set(Value As Image)
                UpdatePrivateProperty(pButtonState_Disabled, Value)
            End Set
        End Property
        Public Property ButtonState_Pressed As Image
            Get
                Return pButtonState_Pressed
            End Get
            Set(Value As Image)
                UpdatePrivateProperty(pButtonState_Pressed, Value)
            End Set
        End Property
        Public ReadOnly Property CurrentState As CurrentEdgeState
            Get
                Return pCurrentState
            End Get
        End Property
        Private pCurrentState As CurrentEdgeState
        Private pButtonState_Normal As Image
        Private pButtonState_Pressed As Image
        Private pButtonState_Disabled As Image
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New(ResetDefaults)
        End Sub
        Public Sub New(UniqueTag As String, IsEnabled As Boolean, IsVisible As Boolean, Optional IsMouseRegion As Boolean = True, Optional ByRef Images As Image() = Nothing)
            MyBase.New(UniqueTag, IsEnabled, IsVisible, IsMouseRegion)
            Update_Images(Images)
        End Sub
        Public Overrides Sub ResetToDefault()
            '///ALL HERE
            pCurrentState = CurrentEdgeState.None
            MyBase.ResetToDefault()
        End Sub
#End Region

#Region "Update Appearance"
        Public Sub Update_Images(ByRef Normal As Image, ByRef Disabled As Image, ByRef Hilited As Image, ByRef Pressed As Image)
            pButtonState_Normal = Normal
            pButtonState_Disabled = Disabled
            pButtonState_Pressed = Pressed
            RebuildImages()
        End Sub
        Public Sub Update_Images(ByRef Images As Image())
            If (Images Is Nothing) Then
                pButtonState_Normal = Nothing
                pButtonState_Disabled = Nothing
                pButtonState_Pressed = Nothing
            Else
                pButtonState_Normal = Images(0)
                pButtonState_Pressed = Images(1)
                pButtonState_Disabled = Images(2)
            End If
            RebuildImages()
        End Sub
        Private Sub RebuildImages()
            If Not ButtonState_Normal Is Nothing Then
                If ButtonState_Disabled Is Nothing Then pButtonState_Disabled = Me.Generate_DisabledButton(pButtonState_Normal)
                If ButtonState_Pressed Is Nothing Then pButtonState_Pressed = pButtonState_Normal
            End If
            If Not pButtonState_Normal Is Nothing Then ResizeImages(pButtonState_Normal.Size)
        End Sub
        Public Sub ResizeImages(DesiredSize As Size)
            If DesiredSize.Width = 0 Or DesiredSize.Height = 0 Then Exit Sub
            'If Not ButtonState_Normal Is Nothing AndAlso Equals(DesiredSize, ButtonState_Normal.Size) = False Then pButtonState_Normal = HelperFunctions.Imaging.ResizeImage(ButtonState_Normal, DesiredSize)
            'If Not ButtonState_Disabled Is Nothing AndAlso Equals(DesiredSize, ButtonState_Disabled.Size) = False Then pButtonState_Disabled = HelperFunctions.Imaging.ResizeImage(ButtonState_Disabled, DesiredSize)
            'If Not ButtonState_Hilited Is Nothing AndAlso Equals(DesiredSize, ButtonState_Hilited.Size) = False Then pButtonState_Hilited = HelperFunctions.Imaging.ResizeImage(ButtonState_Hilited, DesiredSize)
            'If Not ButtonState_Pressed Is Nothing AndAlso Equals(DesiredSize, ButtonState_Pressed.Size) = False Then pButtonState_Pressed = HelperFunctions.Imaging.ResizeImage(ButtonState_Pressed, DesiredSize)
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
        Public Function RetrieveImage_FromButtonState(Enabled As Boolean, SelectedState As CurrentEdgeState) As Image
            Select Case SelectedState
                Case CurrentEdgeState.None
                    If Enabled = False Then
                        Return ButtonState_Disabled
                    Else
                        Return ButtonState_Normal
                    End If
                Case CurrentEdgeState.Disabled
                    Return ButtonState_Disabled
                Case CurrentEdgeState.Normal
                    Return ButtonState_Normal
                Case CurrentEdgeState.Pressed
                    If ButtonState_Pressed Is Nothing Then
                        Return ButtonState_Normal
                    Else
                        Return ButtonState_Pressed
                    End If
                Case Else
                    Return ButtonState_Normal
            End Select
        End Function
#End Region

#Region "Should Serialize"
        Public Function ShouldSerializeImageState_Normal() As Boolean
            'If Not pTemplate_Background = "Current" Then Return False
            Return Not (pButtonState_Normal Is Nothing)
        End Function
        Public Function ShouldSerializeImageState_Disabled() As Boolean
            'If Not pTemplate_Background = "Current" Then Return False
            Return Not (pButtonState_Disabled Is Nothing)
        End Function
        Public Function ShouldSerializeImageState_Pressed() As Boolean
            'If Not pTemplate_Background = "Current" Then Return False
            Return Not (pButtonState_Pressed Is Nothing)
        End Function
#End Region

#Region "Drawing"
        Public Overrides Function Draw(ByRef CurrentDrawing As Graphics, Optional Forced As Boolean = False) As Boolean
            Throw New NotImplementedException()
        End Function
#End Region

#Region "Clone/Write"
        Public Overrides Function Clone() As Object
            Dim Destination As New FormSkinRegion_Button()
            CloneTo(Destination)
            Return Destination
        End Function
        Protected Overloads Sub CloneTo(ByRef Destination As FormSkinRegion_Button)
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