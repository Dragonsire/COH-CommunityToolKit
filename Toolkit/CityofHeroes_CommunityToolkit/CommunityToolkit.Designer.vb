Imports COH.Toolkit.Controls.Menu

Namespace Toolkit.Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class COH_CommunityToolkit_Main
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(COH_CommunityToolkit_Main))
            Me.BannerMenu = New COH.Toolkit.Controls.Menu.ControlFreak_MenuBanner()
            Me.SuspendLayout()
            '
            'BannerMenu
            '
            Me.BannerMenu.BackColor = System.Drawing.Color.Black
            Me.BannerMenu.BackgroundImage = CType(resources.GetObject("BannerMenu.BackgroundImage"), System.Drawing.Image)
            Me.BannerMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BannerMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.BannerMenu.Dock = System.Windows.Forms.DockStyle.Top
            Me.BannerMenu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.BannerMenu.Location = New System.Drawing.Point(0, 0)
            Me.BannerMenu.Name = "BannerMenu"
            Me.BannerMenu.Size = New System.Drawing.Size(800, 188)
            Me.BannerMenu.TabIndex = 1
            '
            'COH_CommunityToolkit_Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 450)
            Me.Controls.Add(Me.BannerMenu)
            Me.IsMdiContainer = True
            Me.Name = "COH_CommunityToolkit_Main"
            Me.Text = "ControlFreak_ParentForm"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents BannerMenu As ControlFreak_MenuBanner
    End Class
End Namespace