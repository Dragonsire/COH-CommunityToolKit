Imports System.Drawing
Imports COH.CodeManagement.Enums

Namespace Toolkit.Controls.Menu
    Public NotInheritable Class COH_Toolkit_MenuStrip
        Inherits MenuStrip

#Region "Designer Code"
        Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub
        Private Sub InitializeComponent()
            SuspendLayout()
            AutoSize = False
            BackColor = Color.Transparent
            Dock = DockStyle.None
            Font = New Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Location = New System.Drawing.Point(0, 0)
            ImageScalingSize = mImageSize
            BackgroundImage = Nothing
            BackgroundImageLayout = ImageLayout.Stretch
            Size = New System.Drawing.Size(400, 48)
            ResumeLayout(False)
            PerformLayout()
        End Sub
#End Region

#Region "Properties"
        Private mColor_Background_Menu_NotSelected As Color = Color.Gold
        Private mColor_Background_Menu_Selected As Color = Color.Green
        Private mColor_ForeGround_Menu_NotSelected As Color = Color.Black
        Private mColor_ForeGround_Menu_Selected As Color = Color.Green
        Private mImageSize As Size = New Size(32, 32)
        Private mImageScaling As ToolStripItemImageScaling = ToolStripItemImageScaling.SizeToFit
        Private mMenuSize_RootItems As Size = New System.Drawing.Size(81, 44)
        Private mMenuSize_DropDownItems As Size = New System.Drawing.Size(81, 44)
#End Region

#Region "Create New Instance"
        Public Sub PrepareUsage(ByRef MenuItems As List(Of ToolStripItem))
            Me.PrepareUsage(MenuItems.ToArray)
        End Sub
        Public Sub PrepareUsage(ByRef MenuItems As ToolStripItem())
            Items.AddRange(MenuItems)
        End Sub
#End Region

#Region "Update Menu Items - Visibility"
        Public Sub UpdateSecurityLevel(SecurityCredentials As Object, SecurityLevel As SecurityRole)
            '//Verify HERE
            For Each Item As ToolStripItem In Items
                If Item.GetType Is GetType(ToolStripMenuItem) Then
                    UpdateSecurityLevel_MenuItem(Item, SecurityLevel)
                Else
                    Dim theTag As ControlFreak_MenuStrip_Tag = Item.Tag
                    Item.Visible = (SecurityLevel >= theTag.Visibility)
                End If
            Next
        End Sub
        Private Sub UpdateSecurityLevel_MenuItem(ByRef Item As ToolStripMenuItem, ByRef SecurityLevel As SecurityRole)
            Dim theTag As ControlFreak_MenuStrip_Tag = Item.Tag
            Item.Visible = (SecurityLevel >= theTag.Visibility)
            For Each Item In Item.DropDownItems
                UpdateSecurityLevel_MenuItem(Item, SecurityLevel)
            Next
        End Sub
#End Region

#Region "Update Menu Items - Enabled"
        Public Sub UpdateEditorCondition(IsOpen As Boolean)
            Dim Enabled As Boolean = (IsOpen = False)
            For Each Item As ToolStripItem In Items
                If Item.GetType Is GetType(ToolStripMenuItem) Then
                    UpdateEditorCondition_MenuItem(Item, Enabled)
                Else
                    Dim theTag As ControlFreak_MenuStrip_Tag = Item.Tag
                    If theTag.DisablesDuringEditing = True Then Item.Enabled = Enabled
                End If
            Next
        End Sub
        Private Sub UpdateEditorCondition_MenuItem(ByRef Item As ToolStripMenuItem, Enabled As Boolean)
            Dim theTag As ControlFreak_MenuStrip_Tag = Item.Tag
            If theTag.DisablesDuringEditing = True Then Item.Enabled = Enabled
            For Each Item In Item.DropDownItems
                UpdateEditorCondition_MenuItem(Item, Enabled)
            Next
        End Sub
#End Region
    End Class
End Namespace
