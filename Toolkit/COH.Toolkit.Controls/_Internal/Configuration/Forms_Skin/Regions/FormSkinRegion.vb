Imports System.ComponentModel
Imports COH.CodeManagement.Enums.Toolkit

Namespace Controls.Configuration
    Public MustInherit Class FormSkinRegion
        Inherits COH_ObservableObject

#Region "Properties - Display"
        <DefaultValue("")> Public Property FormRegionID As FormRegions
            Get
                Return pFormRegionID
            End Get
            Set(value As FormRegions)
                UpdatePrivateProperty(pFormRegionID, value)
            End Set
        End Property
        <DefaultValue(False)> Public Property Is_MouseRegion As Boolean
            Get
                Return pIsMouseRegion
            End Get
            Set(value As Boolean)
                UpdatePrivateProperty(pIsMouseRegion, value)
            End Set
        End Property
        <DefaultValue(GetType(Rectangle), "0, 0, 0, 0")> Public Property Location As Rectangle
            Get
                Return pLocation
            End Get
            Set(value As Rectangle)
                pLocation = value
                UpdatePrivateProperty(pLocation, value)
            End Set
        End Property
        Public ReadOnly Property CurrentState As CurrentImageState
            Get
                Return pCurrentState
            End Get
        End Property
        <DefaultValue(True)> Public ReadOnly Property Enabled As Boolean
            Get
                Return (pCurrentState > CurrentImageState.None) AndAlso (pCurrentState < CurrentImageState.Disabled)
            End Get
        End Property
        Private pCurrentState As CurrentImageState
        Private pFormRegionID As FormRegions
        Private pIsMouseRegion As Boolean
        Private pLocation As Rectangle
#End Region

#Region "Initialize"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ID As FormRegions, Optional IsVisible As Boolean = True, Optional IsEnabled As Boolean = True, Optional IsMouseRegion As Boolean = True)
            MyBase.New
            MyBase.Update_CurrentState(ObjectState_Enum.Modifying)
            pFormRegionID = ID
            pIsMouseRegion = IsMouseRegion
            If IsEnabled = False Then
                pCurrentState = CurrentImageState.Disabled
            Else
                pCurrentState = CurrentImageState.Normal
            End If
            pLocation = New Rectangle(0, 0, 0, 0)
            MyBase.Update_CurrentState(ObjectState_Enum.Ready)
        End Sub
#End Region
#Region "Check Location"
        Public Function Check_MouseLocation_WithinDrawArea(Location As Point) As Boolean
            If pIsMouseRegion = False Then Return False
            If pCurrentState = CurrentImageState.Disabled Then Return False
            Return pLocation.Contains(Location)
        End Function
#End Region

#Region "Update Current State"
        Public Sub Update_ImageState(NextState As CurrentImageState)
            If pCurrentState = CurrentImageState.Pressed AndAlso NextState = CurrentImageState.Hilited Then Exit Sub
            pCurrentState = NextState
        End Sub
#End Region

#Region "Drawing - Sources"
        Public MustOverride Sub LoadImages_FromFolder(Folder As String, Format As Imaging.ImageFormat)
        Public Function Determine_FormRegion_FileName(Folder As String, Format As Imaging.ImageFormat, Optional Tag As String = "") As String
            Dim FileExt As String = HelperFunctions.Imaging.RetrieveFileExtention_ForFormat(Format)
            Dim Key As String = pFormRegionID.ToString
            If String.IsNullOrEmpty(Tag) = False Then Key = (Key & "_" & Tag)
            Return IO.Path.Combine(Folder, Key & FileExt)
        End Function
        Public Function LoadImage(Folder As String, Format As Imaging.ImageFormat, Tag As CurrentImageState) As Image
            Dim FilePath As String = Determine_FormRegion_FileName(Folder, Format, Tag.ToString)
            If IO.File.Exists(FilePath) = False Then Return Nothing
            Return HelperFunctions.Imaging.SafeLoadImage_FromFile(FilePath)
        End Function
#End Region

#Region "Drawing"
        Public MustOverride Function Draw(ByRef CurrentDrawing As Drawing.Graphics, Optional Forced As Boolean = False) As Boolean
        Public Overridable Sub Draw_LayoutBox(CurrentDrawing As Drawing.Graphics, BorderColor As Color, DestinationArea As RectangleF, Optional PenSize As Single = 1)
            Dim SelectedPen As New Pen(BorderColor, PenSize)
            CurrentDrawing.DrawRectangle(SelectedPen, DestinationArea.X, DestinationArea.Y, DestinationArea.Width, DestinationArea.Height)
        End Sub
        Public Sub Update_DrawingLocation(DesiredLocation As Rectangle, Optional Offset As Rectangle = Nothing)
            pLocation = DesiredLocation
            If Not (Offset = Nothing) Then Calculate_Final_DrawingLocation(Offset)
        End Sub
        Private Sub Calculate_Final_DrawingLocation(ByRef Offset As Rectangle)
            Dim TempLocation = New Rectangle()
            With TempLocation
                .X = Offset.X + Location.X
                .Y = Offset.Y + Location.Y
                If Offset.Width = 0 And Offset.Height = 0 Then
                    .Height = Location.Height
                    .Width = Location.Width
                Else
                    If (Offset.X + Offset.Width) <= Offset.X + Location.X + Location.Width Then
                        .Width = Location.Width + ((Offset.X + Offset.Width) < Offset.X + Location.X + Location.Width)
                    Else
                        .Width = Location.Width
                    End If
                    If (Offset.Y + Offset.Height) <= Offset.Y + Location.Y + Location.Height Then
                        .Height = Location.Height + ((Offset.Y + Offset.Height) < Offset.Y + Location.Y + Location.Height)
                    Else
                        .Height = Location.Height
                    End If
                End If
                .X = Math.Round(.X, 2)
                .Y = Math.Round(.Y, 2)
                .Width = Math.Round(.Width, 2)
                .Height = Math.Round(.Height, 2)
            End With
            pLocation = TempLocation
        End Sub
#End Region

#Region "Clone/Write"
        Public MustOverride Function Clone() As Object
        Protected Sub CloneTo(ByRef Destination As FormSkinRegion)
            With Destination
                .pIsMouseRegion = pIsMouseRegion
                .pFormRegionID = pFormRegionID
                .pLocation = New Rectangle(pLocation.Location, pLocation.Size)
            End With
        End Sub
#End Region
    End Class
End Namespace