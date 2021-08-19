<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaseVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaseVentas))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.MenuTab = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.TabMante = New System.Windows.Forms.TabControl
        Me.TabLista = New System.Windows.Forms.TabPage
        Me.TabDatos = New System.Windows.Forms.TabPage
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Panel1.SuspendLayout()
        Me.MenuTab.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.MenuTab)
        Me.Panel1.Controls.Add(Me.TabMante)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(717, 497)
        Me.Panel1.TabIndex = 6
        '
        'MenuTab
        '
        Me.MenuTab.AutoSize = False
        Me.MenuTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.MenuTab.Location = New System.Drawing.Point(0, 0)
        Me.MenuTab.Name = "MenuTab"
        Me.MenuTab.Size = New System.Drawing.Size(715, 28)
        Me.MenuTab.TabIndex = 1000
        Me.MenuTab.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(28, 24)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(28, 24)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem3.Text = " "
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem4.Text = " "
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem5.Text = " "
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem6.Text = " "
        '
        'TabMante
        '
        Me.TabMante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMante.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabMante.Controls.Add(Me.TabLista)
        Me.TabMante.Controls.Add(Me.TabDatos)
        Me.TabMante.Controls.Add(Me.TabPage1)
        Me.TabMante.Controls.Add(Me.TabPage2)
        Me.TabMante.Controls.Add(Me.TabPage3)
        Me.TabMante.Controls.Add(Me.TabPage4)
        Me.TabMante.Location = New System.Drawing.Point(0, 3)
        Me.TabMante.Name = "TabMante"
        Me.TabMante.SelectedIndex = 0
        Me.TabMante.Size = New System.Drawing.Size(712, 521)
        Me.TabMante.TabIndex = 0
        '
        'TabLista
        '
        Me.TabLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabLista.Location = New System.Drawing.Point(4, 25)
        Me.TabLista.Name = "TabLista"
        Me.TabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLista.Size = New System.Drawing.Size(704, 492)
        Me.TabLista.TabIndex = 0
        Me.TabLista.Text = "TabPage1"
        Me.TabLista.UseVisualStyleBackColor = True
        '
        'TabDatos
        '
        Me.TabDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabDatos.Location = New System.Drawing.Point(4, 25)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDatos.Size = New System.Drawing.Size(704, 492)
        Me.TabDatos.TabIndex = 1
        Me.TabDatos.Text = "TabPage2"
        Me.TabDatos.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(704, 492)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(704, 492)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(704, 492)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(704, 492)
        Me.TabPage4.TabIndex = 5
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'frmBaseVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 490)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmBaseVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBaseVentas"
        Me.Panel1.ResumeLayout(False)
        Me.MenuTab.ResumeLayout(False)
        Me.MenuTab.PerformLayout()
        Me.TabMante.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuTab As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents TabMante As System.Windows.Forms.TabControl
    Protected WithEvents TabLista As System.Windows.Forms.TabPage
    Protected WithEvents TabDatos As System.Windows.Forms.TabPage
    Protected WithEvents TabPage1 As System.Windows.Forms.TabPage
    Protected WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Public WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class
