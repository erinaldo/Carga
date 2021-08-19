<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerHuella
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.picHuella = New System.Windows.Forms.PictureBox()
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picHuella
        '
        Me.picHuella.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picHuella.BackColor = System.Drawing.SystemColors.ControlLight
        Me.picHuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picHuella.Location = New System.Drawing.Point(3, 1)
        Me.picHuella.Name = "picHuella"
        Me.picHuella.Size = New System.Drawing.Size(324, 259)
        Me.picHuella.TabIndex = 10
        Me.picHuella.TabStop = False
        '
        'frmVerHuella
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 264)
        Me.Controls.Add(Me.picHuella)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVerHuella"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Huella"
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picHuella As System.Windows.Forms.PictureBox
End Class
