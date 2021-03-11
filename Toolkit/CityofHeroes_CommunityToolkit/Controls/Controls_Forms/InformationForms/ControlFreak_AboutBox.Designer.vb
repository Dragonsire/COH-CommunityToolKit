Namespace  Toolkit.Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ControlFreak_AboutBox
        Inherits Toolkit_Window

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
            Me.Label_Version = New System.Windows.Forms.Label()
            Me.Label_ProgramName = New System.Windows.Forms.Label()
            Me.ImageBox_ProgramIcon = New System.Windows.Forms.PictureBox()
            Me.Label_ChangeLog = New System.Windows.Forms.Label()
            Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
            CType(Me.ImageBox_ProgramIcon, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label_Version
            '
            Me.Label_Version.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.Label_Version.ForeColor = System.Drawing.Color.White
            Me.Label_Version.Location = New System.Drawing.Point(95, 24)
            Me.Label_Version.Name = "Label_Version"
            Me.Label_Version.Size = New System.Drawing.Size(625, 36)
            Me.Label_Version.TabIndex = 40
            Me.Label_Version.Text = "Version"
            '
            'Label_ProgramName
            '
            Me.Label_ProgramName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.Label_ProgramName.ForeColor = System.Drawing.Color.White
            Me.Label_ProgramName.Location = New System.Drawing.Point(95, 3)
            Me.Label_ProgramName.Name = "Label_ProgramName"
            Me.Label_ProgramName.Size = New System.Drawing.Size(625, 19)
            Me.Label_ProgramName.TabIndex = 39
            Me.Label_ProgramName.Text = "Program Name"
            '
            'ImageBox_ProgramIcon
            '
            Me.ImageBox_ProgramIcon.BackColor = System.Drawing.Color.Transparent
            Me.ImageBox_ProgramIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.ImageBox_ProgramIcon.Cursor = System.Windows.Forms.Cursors.Default
            Me.ImageBox_ProgramIcon.Location = New System.Drawing.Point(4, 3)
            Me.ImageBox_ProgramIcon.Name = "ImageBox_ProgramIcon"
            Me.ImageBox_ProgramIcon.Size = New System.Drawing.Size(85, 67)
            Me.ImageBox_ProgramIcon.TabIndex = 38
            Me.ImageBox_ProgramIcon.TabStop = False
            '
            'Label_ChangeLog
            '
            Me.Label_ChangeLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label_ChangeLog.BackColor = System.Drawing.Color.Black
            Me.Label_ChangeLog.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.Label_ChangeLog.ForeColor = System.Drawing.Color.White
            Me.Label_ChangeLog.Location = New System.Drawing.Point(4, 73)
            Me.Label_ChangeLog.Name = "Label_ChangeLog"
            Me.Label_ChangeLog.Size = New System.Drawing.Size(716, 22)
            Me.Label_ChangeLog.TabIndex = 41
            Me.Label_ChangeLog.Text = "CHANGE LOG"
            Me.Label_ChangeLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'RichTextBox1
            '
            Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RichTextBox1.Location = New System.Drawing.Point(4, 98)
            Me.RichTextBox1.Name = "RichTextBox1"
            Me.RichTextBox1.Size = New System.Drawing.Size(716, 277)
            Me.RichTextBox1.TabIndex = 42
            Me.RichTextBox1.Text = ""
            '
            'LinkLabel1
            '
            Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LinkLabel1.AutoSize = True
            Me.LinkLabel1.BackColor = System.Drawing.Color.Black
            Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.LinkLabel1.ForeColor = System.Drawing.Color.White
            Me.LinkLabel1.LinkColor = System.Drawing.Color.White
            Me.LinkLabel1.Location = New System.Drawing.Point(593, 77)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.Size = New System.Drawing.Size(119, 16)
            Me.LinkLabel1.TabIndex = 43
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "Check For Update"
            Me.LinkLabel1.Visible = False
            '
            'ControlFreak_AboutBox
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(724, 377)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Controls.Add(Me.RichTextBox1)
            Me.Controls.Add(Me.Label_ChangeLog)
            Me.Controls.Add(Me.Label_Version)
            Me.Controls.Add(Me.Label_ProgramName)
            Me.Controls.Add(Me.ImageBox_ProgramIcon)
            Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(408, 215)
            Me.Name = "ControlFreak_AboutBox"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "About"
            CType(Me.ImageBox_ProgramIcon, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Protected WithEvents Label_Version As System.Windows.Forms.Label
        Protected WithEvents Label_ProgramName As System.Windows.Forms.Label
        Protected WithEvents ImageBox_ProgramIcon As System.Windows.Forms.PictureBox
        Protected WithEvents Label_ChangeLog As System.Windows.Forms.Label
        Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
        Friend LinkLabel1 As LinkLabel
    End Class
End Namespace