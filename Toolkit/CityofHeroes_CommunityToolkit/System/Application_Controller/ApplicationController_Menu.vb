Imports COH.CodeManagement.Enums.Toolkit
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
            pTheMenu = TheMenu
            OnUpdate_MenuItems(pTheMenu)
        End Sub
        Private Sub OnUpdate_MenuItems(ByRef TheMenu As COH_Toolkit_MenuStrip)
            TheMenu.PrepareUsage(BuildMenuItems_Root(TheMenu))
        End Sub
#End Region

#Region "Add Root Menu Items"
        Private Function BuildMenuItems_Root(ByRef TheMenu As COH_Toolkit_MenuStrip) As ToolStripItem()
            Dim Result As New List(Of ToolStripItem)
            Result.Add(TheMenu.CreateLinked_Root_ToolStripMenuItem("&File Menu", RootMenusEnum.FileMenu))
            Result.Add(TheMenu.CreateLinked_Root_ToolStripMenuItem("&PIGG Menu", RootMenusEnum.PIGG, BuildMenuItems_PIGG()))
            Return Result.ToArray
        End Function
#End Region

#Region "Add Menu Items"
        Private Function BuildMenuItems_PIGG() As ToolStripItem()
            Dim Result As New List(Of ToolStripItem)
            Result.Add(pTheMenu.CreateLinked_MenuItem_ToolStripMenuItem("Open PIGG File", MenuEnum_PIGGMenu.OpenPigg_LocateFile))
            Result.Add(New ToolStripSeparator())
            Result.Add(pTheMenu.CreateLinked_MenuItem_ToolStripMenuItem("Open Specified PIGG File", MenuEnum_PIGGMenu.OpenPigg_Specified, BuildMenuItems_PIGG_OpenSpecified()))
            Result.Add(pTheMenu.CreateLinked_MenuItem_ToolStripMenuItem("Extract Specified PIGG File", MenuEnum_PIGGMenu.ExtractPigg_Specified, BuildMenuItems_PIGG_ExtractSpecified()))
            Return Result.ToArray
        End Function
        Private Function BuildMenuItems_PIGG_OpenSpecified() As ToolStripItem()
            Dim Result As New List(Of ToolStripItem)
            Result.Add(pTheMenu.CreateLinked_MenuItem_ToolStripMenuItem("Open PIGG File (UI.PIGG)", MenuEnum_PIGGMenu_OpenSpecified.OpenPigg_Specified_UI))
            Return Result.ToArray
        End Function
        Private Function BuildMenuItems_PIGG_ExtractSpecified() As ToolStripItem()
            Dim Result As New List(Of ToolStripItem)
            Result.Add(pTheMenu.CreateLinked_MenuItem_ToolStripMenuItem("Extract PIGG File (UI.PIGG)", MenuEnum_PIGGMenu_ExtractSpecified.ExtractPigg_Specified_UI))
            Return Result.ToArray
        End Function
#End Region
    End Class
End Namespace