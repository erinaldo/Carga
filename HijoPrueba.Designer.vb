<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HijoPrueba
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MenuHijoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HijitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.HolaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.NadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuHijoToolStripMenuItem, Me.NadaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(292, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuHijoToolStripMenuItem
        '
        Me.MenuHijoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HijitoToolStripMenuItem, Me.ToolStripMenuItem2, Me.HolaToolStripMenuItem, Me.ToolStripMenuItem3})
        Me.MenuHijoToolStripMenuItem.Name = "MenuHijoToolStripMenuItem"
        Me.MenuHijoToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.MenuHijoToolStripMenuItem.Text = "Menu Hijo"
        '
        'HijitoToolStripMenuItem
        '
        Me.HijitoToolStripMenuItem.Name = "HijitoToolStripMenuItem"
        Me.HijitoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HijitoToolStripMenuItem.Text = "Hijito"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem2.Text = "\"
        '
        'HolaToolStripMenuItem
        '
        Me.HolaToolStripMenuItem.Name = "HolaToolStripMenuItem"
        Me.HolaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HolaToolStripMenuItem.Text = "Hola"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem3.Text = "\"
        '
        'NadaToolStripMenuItem
        '
        Me.NadaToolStripMenuItem.Name = "NadaToolStripMenuItem"
        Me.NadaToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.NadaToolStripMenuItem.Text = "Nada\"
        '
        'HijoPrueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "HijoPrueba"
        Me.Text = "HijoPrueba"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuHijoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HijitoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HolaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
