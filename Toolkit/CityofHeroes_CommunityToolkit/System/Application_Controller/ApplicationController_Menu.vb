Imports COH.Toolkit.Controls.Menu

Namespace Toolkit
    Partial Public Class ToolkitController

#Region "Properties"
        Public ReadOnly Property WindowMenu() As COH_Toolkit_MenuStrip
            Get
                Return pTheMenu
            End Get
        End Property
        Private WithEvents pTheMenu As COH_Toolkit_MenuStrip
#End Region

#Region "Create Menu"
        Protected Sub ConfigureMenu(ByRef TheMenu As COH_Toolkit_MenuStrip)
            pTheMenu = OnCreate_Menu()
            OnUpdate_MenuItems(pTheMenu)
        End Sub
        Private Function OnCreate_Menu() As COH_Toolkit_MenuStrip
            '//  Return MainForm.BannerMenu.MenuStrip
        End Function
        Private Sub OnUpdate_MenuItems(ByRef TheMenu As COH_Toolkit_MenuStrip)
            TheMenu.PrepareUsage(BuildMenuItems_Root(TheMenu))
        End Sub
#End Region

#Region "Add Root Menu Items"
        Private Function BuildMenuItems_Root(ByRef TheMenu As COH_Toolkit_MenuStrip) As ToolStripMenuItem()
            Dim Result As New List(Of ToolStripMenuItem)
            '// Result.Add(TheMenu.CreateLinked_Root_ToolStripMenuItem("&File Menu", MenuFunction_Enum.RootMenu_FileMenu.ToString))
            '// Result.Add(TheMenu.CreateLinked_Root_ToolStripMenuItem("&Tools Menu", MenuFunction_Enum.RootMenu_ToolsMenu.ToString, BuildMenuItems_Tools(TheMenu)))
            Return Result.ToArray
        End Function
#End Region

#Region "Add Menu Items"
        Private Function BuildMenuItems_Tools(ByRef TheMenu As COH_Toolkit_MenuStrip) As ToolStripMenuItem()
            Dim Result As New List(Of ToolStripMenuItem)
            '//Result.Add(TheMenu.CreateLinked_MenuItem_ToolStripMenuItem("Assembly Examiner", MenuFunction_Enum.Menu_Tools_AssemblyExamine.ToString))
            Return Result.ToArray
        End Function
#End Region
    End Class
End Namespace