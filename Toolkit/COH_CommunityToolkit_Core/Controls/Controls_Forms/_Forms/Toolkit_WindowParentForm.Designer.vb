Namespace  Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ControlFreak_ParentForm
        Inherits Toolkit_Window

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
            Me.BannerMenu = New Controls.Menu.ControlFreak_MenuBanner()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ControlFreak_MenuBanner1
            '
            Me.BannerMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.BannerMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BannerMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.BannerMenu.Dock = System.Windows.Forms.DockStyle.Top
            Me.BannerMenu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.BannerMenu.Location = New System.Drawing.Point(0, 0)
            Me.BannerMenu.Name = "ControlFreak_MenuBanner1"
            Me.BannerMenu.Size = New System.Drawing.Size(800, 188)
            Me.BannerMenu.TabIndex = 1
            '
            'ControlFreak_ParentForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 450)
            Me.Controls.Add(Me.BannerMenu)
            Me.IsMdiContainer = True
            Me.Name = "ControlFreak_ParentForm"
            Me.Text = "ControlFreak_ParentForm"
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Public BannerMenu As Menu.ControlFreak_MenuBanner
    End Class
End Namespace
