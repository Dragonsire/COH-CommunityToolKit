Imports System.ComponentModel
Imports COH.GameContent.Structures.Resources.Anim
Imports COH.GameContent.Structures.Resources.BIN
Imports COH.GameContent.Structures.Resources.GEO
Imports COH.GameContent.Structures.Resources.Textures
Imports COH.Storage.Containers.PIGG
Imports COH.Storage.Controllers

Namespace Toolkit.Controls.ContainerTools
    Public Class ContainerTools_PiggView
        Const COH_DeveloperMode_AllowEdit = False '//TEMP

#Region "Private Properties"
        Private pFileSource As String
        Private pCurrentPIGG As PIGG_Container
        Private pCurrentResource As COH_FileStructure
        Private rPreviewControl As Control
        Private CurrentlyPreviewing As COH_Supported_ContentType = COH_Supported_ContentType.Unknown
#End Region

#Region "Initialize"
        Public Sub New()
            Me.New(Nothing)
        End Sub
        Public Sub New(ByRef TheContentController As ISupport_ToolkitController)
            MyBase.New(TheContentController)
            InitializeComponent()
            ConfigureUI_Begin()
            ConfigureUI_Finish()
        End Sub
        Protected Overrides Sub ConfigureUI_Begin()
            MyBase.ConfigureUI_Begin()
        End Sub
        Protected Overrides Sub ConfigureUI_Finish()
            MyBase.ConfigureUI_Finish()
        End Sub
#End Region

#Region "Prepare Usage"
        Public Sub Prepare_Editor(FilePath As String)
            pCurrentPIGG = New PIGG_Container
            pCurrentPIGG.OpenExisting_PiggFile(FilePath)
            DisplayInfo()
        End Sub
        Public Sub Prepare_Editor(ByRef Source As PIGG_Container)
            pCurrentPIGG = Source
            DisplayInfo()
        End Sub
#End Region

#Region "Display Info"
        Private Sub DisplayInfo()
            Changes_Locked = True
            DisplayInfo_Pigg_InTree()
            DisplayInfo_ContentDetails()
            DisplayInfo_SlotDetails()
            Dim CurrentNode As TreeNode = PiggTree.Nodes(0)
            Do
                CurrentNode.Expand()
                If CurrentNode.Nodes.Count = 1 Then
                    CurrentNode = CurrentNode.Nodes(0)
                Else
                    Exit Do
                End If
            Loop
            Changes_Locked = False
        End Sub
        Private Sub DisplayInfo_ContentDetails()
            ListView1.Items.Clear()
            ListView1.BeginUpdate()
            For X = 0 To pCurrentPIGG.Directories.Count - 1
                Dim Newitem As New ListViewItem(pCurrentPIGG.Directories(X).Index)
                Newitem.Name = X
                Newitem.SubItems.Add(pCurrentPIGG.StringTable.Items(X))
                Newitem.SubItems.Add(pCurrentPIGG.Directories(X).EntryType.ToString)
                Newitem.SubItems.Add(pCurrentPIGG.Directories(X).File_Offset)
                Newitem.SubItems.Add(pCurrentPIGG.Directories(X).File_Size_Stored)
                'Newitem.SubItems.Add(mTool.Content.Directories(X).File_Size)
                Newitem.SubItems.Add(pCurrentPIGG.Directories(X).IsCompressed)
                'Newitem.SubItems.Add(mTool.Content.Directories(X).File_Size_Compressed)
                Newitem.SubItems.Add(pCurrentPIGG.Directories(X).TimeStamp)
                Newitem.SubItems.Add(pCurrentPIGG.Directories(X).SecondarySlotIndex)
                ListView1.Items.Add(Newitem)
            Next
            ListView1.EndUpdate()
        End Sub
        Private Sub DisplayInfo_SlotDetails()
            ListView2.Items.Clear()
            ListView2.BeginUpdate()
            If pCurrentPIGG.SlotTable.Items Is Nothing Then Exit Sub
            For X = 0 To pCurrentPIGG.SlotTable.Items.Count - 1
                Dim Newitem As New ListViewItem(X.ToString)
                Newitem.Name = X
                Newitem.SubItems.Add(pCurrentPIGG.SlotTable.Items(X).SlotType.ToString)
                Newitem.SubItems.Add(pCurrentPIGG.SlotTable.Items(X).Offset)
                Newitem.SubItems.Add(pCurrentPIGG.SlotTable.Items(X).Size_Stored)
                Newitem.SubItems.Add(pCurrentPIGG.SlotTable.Items(X).IsCompressed)
                ListView2.Items.Add(Newitem)
            Next
            ListView2.EndUpdate()
        End Sub
#End Region

#Region "DisplayInfo - TreeView Details"
        Private Sub DisplayInfo_Pigg_InTree()
            Dim RootNode As TreeNode = Fill_TreeView_GetNodes(New TreeNode("Root"), pCurrentPIGG.StringTable.Items, "/", ".")
            PiggTree.BeginUpdate()
            PiggTree.Nodes.Clear()
            PiggTree.Nodes.Add(RootNode)
            PiggTree.EndUpdate()
        End Sub
        Private Function Fill_TreeView_GetNodes(ByVal parent As TreeNode, ByRef PathList As List(Of String), ByVal pathSeparator As Char, FileNameExt As String) As TreeNode
            Dim Index As Integer = 0
            For Each strPath In PathList
                Dim thisParent As TreeNode = parent
                For Each pathPart As String In strPath.Split(pathSeparator)
                    Dim tn As TreeNode() = thisParent.Nodes.Find("_Folder_" & pathPart, False)
                    If tn.Length = 0 Then
                        If pathPart.ToLower.Contains(FileNameExt) Then
                            thisParent = thisParent.Nodes.Add(Index, pathPart)
                            Determine_NodeColor(thisParent)
                            Index += 1
                        Else
                            thisParent = thisParent.Nodes.Add("_Folder_" & pathPart, pathPart)
                        End If
                    Else
                        thisParent = tn(0)
                    End If
                Next
            Next
            Return parent
        End Function
        Private Sub Determine_NodeColor(ByRef Node As TreeNode)
            Dim Result = PIGG_Container.Identify_SlotType(Node.Text)
            Select Case Result
                Case COH_Supported_ContentType.Resource_BIN_CrypticS
                    Node.ForeColor = Color.Black
                Case COH_Supported_ContentType.Resource_BIN_MessageStore
                    Node.ForeColor = Color.DarkOrange
                Case COH_Supported_ContentType.Resource_GEO
                    Node.ForeColor = Color.Green
                Case COH_Supported_ContentType.Resource_Texture
                    Node.ForeColor = Color.Blue
                Case COH_Supported_ContentType.Resource_TGA
                    Node.ForeColor = Color.BlueViolet
                Case COH_Supported_ContentType.Unknown
                    Node.ForeColor = Color.Gray
                Case Else
                    Node.ForeColor = Color.Red
            End Select
        End Sub
        Private Sub Determine_NodeColor2(ByRef Node As TreeNode) 'Identify_SlotType
            Dim TheType As COH_FSI_Entry = Nothing
            If COH_FSI_Entry.Retrieve_SupportedType(Nothing, Node.Text, TheType) = False Then
                If Node.Text.ToUpper.Contains(".GEO") Then
                    Node.ForeColor = Color.Green
                Else
                    Node.ForeColor = Color.Red
                End If
            Else
                Select Case TheType.ContentType
                    Case COH_Supported_ContentType.Resource_BIN_CrypticS
                        Node.ForeColor = Color.Black
                    Case COH_Supported_ContentType.Resource_BIN_MessageStore
                        Node.ForeColor = Color.DarkOrange
                    Case COH_Supported_ContentType.Resource_GEO
                        Node.ForeColor = Color.Green
                    Case COH_Supported_ContentType.Resource_Texture
                        Node.ForeColor = Color.Blue
                    Case COH_Supported_ContentType.Resource_TGA
                        Node.ForeColor = Color.BlueViolet
                    Case COH_Supported_ContentType.Unknown
                        Node.ForeColor = Color.Gray
                End Select
            End If
        End Sub
#End Region

#Region "Control Usage"
        Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles PiggTree.AfterSelect
            If Changes_Locked = True Then Exit Sub
            If e.Node.Name.Contains("_Folder_") = True Then Exit Sub
            If e.Node.Name = "" Then Exit Sub
            Dim Index As String = e.Node.Name
            Preview_Contents(Index, e.Node.Text)
        End Sub
        Private Sub Preview_Contents(Index As Integer, Name As String)
            If pCurrentPIGG.ExtractEntry(Index, pCurrentResource) = False Then
                Exit Sub
            End If
            Select Case pCurrentResource.EntryType
                Case COH_Supported_ContentType.Resource_Texture
                    CreatePreviewControl_DDS()
                Case COH_Supported_ContentType.Resource_TGA
                    CreatePreviewControl_TGA()
                Case COH_Supported_ContentType.Resource_BIN_CrypticS
                    CreatePreviewControl_BinTool(Name)
                Case COH_Supported_ContentType.Resource_BIN_MessageStore
                    CreatePreviewControl_MessageStore(Name)
                Case COH_Supported_ContentType.Resource_GEO
                    CreatePreviewControl_3DView()
                Case COH_Supported_ContentType.Resource_ANIMATION
                    CreatePreviewControl_Animation(Name)
            End Select
        End Sub
#End Region

#Region "Preview Section"
        Private Sub CreatePreviewControl_DDS()
            Dim PreviewControl As PictureBox = Nothing
            If Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_Texture And Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_TGA Then
                DestroyPreviewControl()
                PreviewControl = New PictureBox
                Tab_Preview.Controls.Add(PreviewControl)
                PreviewControl.Dock = DockStyle.Fill
                PreviewControl.Visible = True
                rPreviewControl = PreviewControl
            Else
                PreviewControl = rPreviewControl
            End If
            PreviewControl.BackgroundImage = DirectCast(pCurrentResource, COH_Resource_Texture).Extract_Resource_Texture()
            PreviewControl.BackgroundImageLayout = ImageLayout.Zoom
            CurrentlyPreviewing = COH_Supported_ContentType.Resource_Texture
            Dim Temp = DirectCast(pCurrentResource, COH_Resource_Texture)
            If COH_DeveloperMode_AllowEdit = False Then TypeDescriptor.AddAttributes(Temp, New Attribute() {New ReadOnlyAttribute(True)})
            PropertyGrid1.SelectedObject = Temp
        End Sub
        Private Sub CreatePreviewControl_TGA()
            Dim PreviewControl As PictureBox = Nothing
            If Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_Texture And Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_TGA Then
                DestroyPreviewControl()
                PreviewControl = New PictureBox
                Tab_Preview.Controls.Add(PreviewControl)
                PreviewControl.Dock = DockStyle.Fill
                PreviewControl.Visible = True
                rPreviewControl = PreviewControl
            Else
                PreviewControl = rPreviewControl
            End If
            PreviewControl.BackgroundImage = DirectCast(pCurrentResource, COH_Resource_TGA).Extract_Resource_Texture()
            PreviewControl.BackgroundImageLayout = ImageLayout.Zoom
            CurrentlyPreviewing = COH_Supported_ContentType.Resource_TGA
            Dim Temp = DirectCast(pCurrentResource, COH_Resource_TGA)
            If COH_DeveloperMode_AllowEdit = False Then TypeDescriptor.AddAttributes(Temp, New Attribute() {New ReadOnlyAttribute(True)})
            PropertyGrid1.SelectedObject = Temp
        End Sub
        Private Sub CreatePreviewControl_BinTool(Name As String)
            ' Dim PreviewControl As COH_Control_ViewBin = Nothing
            If Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_BIN_CrypticS Then
                DestroyPreviewControl()
                'PreviewControl = New COH_Control_ViewBin(Me.ContentController)
                'Tab_Preview.Controls.Add(PreviewControl)
                'PreviewControl.Dock = DockStyle.Fill
                'PreviewControl.Visible = True
                'mPreviewControl = PreviewControl
            Else
                'PreviewControl = mPreviewControl
            End If
            Dim Temp = DirectCast(pCurrentResource, COH_Resource_BIN)
            ' PreviewControl.LinkControllers(ContentController)
            ' PreviewControl.Prepare_Editor(Name, Temp.EntryType, Temp.RawBytes)
            CurrentlyPreviewing = COH_Supported_ContentType.Resource_BIN_CrypticS

            If COH_DeveloperMode_AllowEdit = False Then TypeDescriptor.AddAttributes(Temp, New Attribute() {New ReadOnlyAttribute(True)})
            PropertyGrid1.SelectedObject = Temp
        End Sub
        Private Sub CreatePreviewControl_MessageStore(Name As String)
            ' Dim PreviewControl As COH_Control_MessageStore = Nothing
            If Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_BIN_MessageStore Then
                DestroyPreviewControl()
                '  PreviewControl = New COH_Control_MessageStore
                ' Tab_Preview.Controls.Add(PreviewControl)
                ' PreviewControl.Dock = DockStyle.Fill
                ' PreviewControl.Visible = True
                ' mPreviewControl = PreviewControl
            Else
                ' PreviewControl = mPreviewControl
            End If
            Dim Temp = DirectCast(pCurrentResource, COH_Resource_BIN)
            ' PreviewControl.Prepare_Editor(Name, Temp.EntryType, Temp.RawBytes)
            CurrentlyPreviewing = COH_Supported_ContentType.Resource_BIN_MessageStore

            If COH_DeveloperMode_AllowEdit = False Then TypeDescriptor.AddAttributes(Temp, New Attribute() {New ReadOnlyAttribute(True)})
            PropertyGrid1.SelectedObject = Temp
        End Sub
        Private Sub CreatePreviewControl_3DView()
            ' Dim PreviewControl As COH_GeoModelViewer = Nothing
            If Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_GEO Then
                DestroyPreviewControl()
                ' PreviewControl = New COH_GeoModelViewer(Me.ContentController)
                '  PreviewControl.LinkControllers(Me.ContentController)
                ' Tab_Preview.Controls.Add(PreviewControl)
                ' PreviewControl.Dock = DockStyle.Fill
                ' PreviewControl.Visible = True
                '  mPreviewControl = PreviewControl
            Else
                '  PreviewControl = mPreviewControl
            End If

            Dim Temp = DirectCast(pCurrentResource, COH_Resource_GEO)
            If COH_DeveloperMode_AllowEdit = False Then TypeDescriptor.AddAttributes(Temp, New Attribute() {New ReadOnlyAttribute(True)})
            PropertyGrid1.SelectedObject = Temp
            ' PreviewControl.LoadModel(Temp)
            CurrentlyPreviewing = COH_Supported_ContentType.Resource_GEO
        End Sub
        Private Sub CreatePreviewControl_Animation(Name As String)
            ' Dim PreviewControl As COH_ResourceView_ANIM = Nothing
            If Not CurrentlyPreviewing = COH_Supported_ContentType.Resource_ANIMATION Then
                DestroyPreviewControl()
                ' PreviewControl = New COH_ResourceView_ANIM
                ' Tab_Preview.Controls.Add(PreviewControl)
                ' PreviewControl.Dock = DockStyle.Fill
                ' PreviewControl.Visible = True
                ' mPreviewControl = PreviewControl
            Else
                ' PreviewControl = mPreviewControl
            End If
            Dim Temp = DirectCast(pCurrentResource, COH_Resource_Anim)
            ' PreviewControl.Prepare_Editor(Name, Temp)
            CurrentlyPreviewing = COH_Supported_ContentType.Resource_ANIMATION
            If COH_DeveloperMode_AllowEdit = False Then TypeDescriptor.AddAttributes(Temp, New Attribute() {New ReadOnlyAttribute(True)})
            PropertyGrid1.SelectedObject = Temp
        End Sub
        Private Sub DestroyPreviewControl()
            If Tab_Preview.Controls.Count = 0 Then Exit Sub
            Tab_Preview.Controls.RemoveAt(0)
            rPreviewControl.Dispose()
            rPreviewControl = Nothing
        End Sub
#End Region
    End Class
End Namespace