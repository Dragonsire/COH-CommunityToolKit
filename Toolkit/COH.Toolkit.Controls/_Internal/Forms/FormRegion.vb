Namespace Controls
    Public MustInherit Class Toolkit_FormRegion

#Region "Properties - Display"
        <DefaultValue(True)> Public Property Enabled As Boolean
                Get
                    Return pEnabled
                End Get
                Set(value As Boolean)
                    Update_Enabled(value)
                End Set
            End Property
            <DefaultValue(True)> Public Property Visible As Boolean
                Get
                    Return pVisible
                End Get
                Set(value As Boolean)
                    Update_Visible(value)
                End Set
            End Property
            <DefaultValue("")> Public Property UniqueKey As String
                Get
                    Return pUniqueKey
                End Get
                Set(value As String)
                    UpdatePrivateProperty(pUniqueKey, value)
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
            Public ReadOnly Property ClientLocation As Rectangle
                Get
                    Return rDrawingLocation
                End Get
            End Property
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pUniqueKey As String
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pEnabled As Boolean
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pVisible As Boolean
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pIsMouseRegion As Boolean
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private pLocation As Rectangle
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private rDrawingLocation As Rectangle
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private rDrawingLocation_Offset As Rectangle
            <EditorBrowsable(DS_DeveloperMode_ShowPrivate)> Private rCurrentState As ObjectState_Enum
#End Region

#Region "Initialize"
            Public Sub New()
                MyBase.New
                ResetToDefault()
                rCurrentState = ObjectState_Enum.[New]
            End Sub
            Public Sub New(ByRef CurrentReader As FlexStreamEditor)
                MyBase.New
                Read_FromStream(CurrentReader)
                rCurrentState = ObjectState_Enum.Ready
            End Sub
            Public Sub New(UniqueTag As String, IsEnabled As Boolean, IsVisible As Boolean, Optional IsMouseRegion As Boolean = True)
                Me.New()
                pUniqueKey = UniqueTag
                pEnabled = IsEnabled
                pVisible = IsVisible
                pIsMouseRegion = IsMouseRegion
                rCurrentState = ObjectState_Enum.Ready
            End Sub
            Public Sub BeginInit() Implements ISupportInitialize.BeginInit
                rCurrentState = ObjectState_Enum.Initializing
            End Sub
            Public Sub EndInit() Implements ISupportInitialize.EndInit
                rCurrentState = ObjectState_Enum.Ready
            End Sub
            Public Overridable Sub ResetToDefault()
                pUniqueKey = ""
                pEnabled = True
                pVisible = True
                pIsMouseRegion = False
                pLocation = New Rectangle(0, 0, 0, 0)
                rDrawingLocation = New Rectangle(0, 0, 0, 0)
                OnModified()
            End Sub
#End Region

#Region "Modifications - Enabled/Disabled, Visible"
            Protected Sub Update_Enabled(EnabledState As Boolean)
                '//  If pEnabled.Equals(EnabledState) Then Exit Sub
                pEnabled = EnabledState
                OnHandleModified_Enabled()
            End Sub
            Protected Overridable Sub OnHandleModified_Enabled()
                OnModified("Enabled")
            End Sub
            Protected Sub Update_Visible(VisibleState As Boolean)
                '//  If pEnabled.Equals(VisibleState) Then Exit Sub
                pVisible = VisibleState
                OnHandleModified_Visible()
            End Sub
            Protected Overridable Sub OnHandleModified_Visible()
                OnModified("Visible")
            End Sub
#End Region

#Region "Modifications"
            Public Event WasModified As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
            Protected Function UpdatePrivateProperty(Of T)(ByRef PrivateValue As T, ByVal value As T, <Runtime.CompilerServices.CallerMemberName> ByVal Optional PropertyName As String = "") As Boolean
                If Object.Equals(PrivateValue, value) Then Return False
                PrivateValue = value
                OnModified(PropertyName)
                Return True
            End Function
            Protected Sub OnModified(Optional PropertyName As String = "")
                If rCurrentState = ObjectState_Enum.Ready Then rCurrentState = ObjectState_Enum.Modified
                If rCurrentState = ObjectState_Enum.Modified Then RaiseEvent WasModified(Me, New PropertyChangedEventArgs(PropertyName))
            End Sub
            Public Function Check_WasModified() As Boolean
                If rCurrentState = ObjectState_Enum.Modified Then Return True
                Return False
            End Function
            Public Function Check_WasInitialized() As Boolean
                If rCurrentState = ObjectState_Enum.Initializing Then Return False
                Return True
            End Function
            Public Sub SetState_Modifying()
                rCurrentState = ObjectState_Enum.Modifying
            End Sub
            Public Sub SetState_Ready()
                rCurrentState = ObjectState_Enum.Ready
            End Sub
            Public Function Check_CurrentState() As ObjectState_Enum
                Return rCurrentState
            End Function
#End Region

#Region "Drawing"
            Public Function Check_MouseLocation_WithinDrawArea(Location As Point) As Boolean
                If pIsMouseRegion = False Then Return False
                Return rDrawingLocation.Contains(Location)
            End Function
            Protected Function Check_ClientArea_ContainsDesiredArea(ByRef ClientArea As Rectangle) As Boolean
                Return ClientArea.Contains(pLocation)
            End Function
            Public MustOverride Function Draw(ByRef CurrentDrawing As Drawing.Graphics, Optional Forced As Boolean = False) As Boolean
            Public Overridable Sub Draw_LayoutBox(CurrentDrawing As Drawing.Graphics, BorderColor As Color, DestinationArea As RectangleF, Optional PenSize As Single = 1)
                Dim SelectedPen As New Pen(BorderColor, PenSize)
                CurrentDrawing.DrawRectangle(SelectedPen, DestinationArea.X, DestinationArea.Y, DestinationArea.Width, DestinationArea.Height)
            End Sub
            Public Sub Update_DrawingLocation(DesiredLocation As Rectangle)
                pLocation = DesiredLocation
                Calculate_Final_DrawingLocation(rDrawingLocation_Offset)
            End Sub
            Public Sub Update_DrawingLocation_Offset(ByRef OffSet As Rectangle)
                rDrawingLocation_Offset = OffSet
                Calculate_Final_DrawingLocation(rDrawingLocation_Offset)
            End Sub
            Private Sub Calculate_Final_DrawingLocation(ByRef Offset As Rectangle)
                rDrawingLocation = New Rectangle()
                With rDrawingLocation
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
            End Sub
#End Region

#Region "Clone/Write"
            Public MustOverride Function Clone() As Object Implements ICloneable.Clone
            Protected Sub CloneTo(ByRef Destination As ControlRegion)
                With Destination
                    .pEnabled = pEnabled
                    .pIsMouseRegion = pIsMouseRegion
                    .pUniqueKey = pUniqueKey.CloneString
                    .pVisible = pVisible
                    .pLocation = New Rectangle(pLocation.Location, pLocation.Size)
                End With
            End Sub
#End Region

#Region "Export"
            Function Export_ToStream_File(FilePath As String) As Boolean Implements IDS_ConvertTo_Binary.Export_ToStream_File
                Dim File As New IO.FileStream(FilePath, IO.FileMode.Create, IO.FileAccess.Write)
                Dim CurrentWriter As New FlexStreamEditor(File)
                Return Write_ToStream(CurrentWriter)
            End Function
            Public Function Export_ToStream() As IO.MemoryStream Implements IDS_Structure.Export_ToStream
                Using Result As New IO.MemoryStream()
                    Dim CurrentWriter As New FlexStreamEditor(Result)
                    Write_ToStream(CurrentWriter)
                    Return Result
                End Using
            End Function
            Public Overridable Function Write_ToStream(ByRef CurrentWriter As FlexStreamEditor) As Boolean Implements IDS_Structure.Write_ToStream
                Dim Version As DS_CFS_IDent = DS_CFS_IDent.GetAttribute(GetType(ControlRegion))
                Version.WriteToStream(CurrentWriter)
                CurrentWriter.Write(pUniqueKey)
                CurrentWriter.Write(pEnabled)
                CurrentWriter.Write(pVisible)
                CurrentWriter.Write(pLocation)
                CurrentWriter.Write(pIsMouseRegion)
                Return True
            End Function
#End Region

#Region "Import"
            Public Overridable Function Read_FromStream(ByRef CurrentReader As FlexStreamEditor) As Boolean Implements IDS_Structure.Read_FromStream
                Dim Version As New DS_CFS_IDent(CurrentReader)
                If DS_CFS_IDent.Validate(Version, DS_CFS_IDent.GetAttribute(GetType(ControlRegion))) = False Then Return False
                'ADD VERSION LOGIC
                pUniqueKey = CurrentReader.ReadString()
                pEnabled = CurrentReader.ReadBoolean()
                pVisible = CurrentReader.ReadBoolean()
                pLocation = CurrentReader.ReadRectangle()
                pIsMouseRegion = CurrentReader.ReadBoolean()
                Return True
            End Function
#End Region
        End Class
    End Namespace


    End Class
End Namespace