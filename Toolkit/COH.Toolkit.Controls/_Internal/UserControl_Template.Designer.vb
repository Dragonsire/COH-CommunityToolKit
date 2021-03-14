Namespace Toolkit.Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UserControl_Template
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    DisposeAdditional()
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
            Me.components = New System.ComponentModel.Container()
            Me.Content_FormTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.SuspendLayout()
            '
            'COH_UserControl_Template
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Name = "COH_UserControl_Template"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Content_FormTip As ToolTip
    End Class
End Namespace
