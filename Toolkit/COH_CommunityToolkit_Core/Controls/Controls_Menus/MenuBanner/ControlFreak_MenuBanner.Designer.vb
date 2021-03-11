Namespace  Controls.Menu
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ControlFreak_MenuBanner
        Inherits System.Windows.Forms.UserControl
        Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        'UserControl overrides dispose to clean up the component list.
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
            Me.ProductState = New Label
            Me.MenuStrip = New Controls.Menu.COH_Toolkit_MenuStrip
            Me.MenuStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'MainMenu
            '
            Me.MenuStrip.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.MenuStrip.AutoSize = False
            Me.MenuStrip.BackColor = System.Drawing.Color.White
            Me.MenuStrip.Dock = System.Windows.Forms.DockStyle.None
            Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.MenuStrip.Location = New System.Drawing.Point(0, 160)
            Me.MenuStrip.Name = "MainMenu"
            Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
            Me.MenuStrip.Size = New System.Drawing.Size(1416, 25)
            Me.MenuStrip.TabIndex = 0
            Me.MenuStrip.Text = "MenuStrip1"
            '
            'Label_ProductState
            '
            Me.ProductState.AutoSize = True
            Me.ProductState.BackColor = System.Drawing.Color.Transparent
            Me.ProductState.Font = New System.Drawing.Font("Pristina", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.ProductState.ForeColor = System.Drawing.Color.White
            Me.ProductState.Location = New System.Drawing.Point(445, 17)
            Me.ProductState.Name = "Label_ProductState"
            Me.ProductState.Size = New System.Drawing.Size(68, 32)
            Me.ProductState.TabIndex = 3
            Me.ProductState.Text = "In Development"
            '
            'DS_MainMenu
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Controls.Add(Me.MenuStrip)
            Me.Controls.Add(Me.ProductState)
            Me.DoubleBuffered = True
            Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.Name = "DS_MainMenu"
            Me.Size = New System.Drawing.Size(1416, 184)
            Me.MenuStrip.ResumeLayout(False)
            Me.MenuStrip.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents MenuStrip As COH_Toolkit_MenuStrip
        Public WithEvents ProductState As Label
    End Class
End Namespace