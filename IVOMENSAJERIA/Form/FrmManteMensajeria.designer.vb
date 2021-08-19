<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManteMensajeria
    Inherits INTEGRACION.FrmPlantillaFacturacion
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
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.GB1 = New System.Windows.Forms.GroupBox
        Me.RBMENSA_CORPO = New System.Windows.Forms.RadioButton
        Me.RBMENSA_PUBLI = New System.Windows.Forms.RadioButton
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.GB1)
        Me.TabLista.Controls.SetChildIndex(Me.GB1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.dgv1)
        '
        'dgv1
        '
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(0, 0)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(705, 369)
        Me.dgv1.TabIndex = 0
        '
        'GB1
        '
        Me.GB1.BackColor = System.Drawing.Color.Transparent
        Me.GB1.Controls.Add(Me.RBMENSA_CORPO)
        Me.GB1.Controls.Add(Me.RBMENSA_PUBLI)
        Me.GB1.Location = New System.Drawing.Point(15, 6)
        Me.GB1.Name = "GB1"
        Me.GB1.Size = New System.Drawing.Size(290, 51)
        Me.GB1.TabIndex = 1
        Me.GB1.TabStop = False
        Me.GB1.Text = "Mensajeria..."
        '
        'RBMENSA_CORPO
        '
        Me.RBMENSA_CORPO.AutoSize = True
        Me.RBMENSA_CORPO.Location = New System.Drawing.Point(149, 19)
        Me.RBMENSA_CORPO.Name = "RBMENSA_CORPO"
        Me.RBMENSA_CORPO.Size = New System.Drawing.Size(122, 17)
        Me.RBMENSA_CORPO.TabIndex = 1
        Me.RBMENSA_CORPO.Text = "Mensaje Corporativo"
        Me.RBMENSA_CORPO.UseVisualStyleBackColor = True
        '
        'RBMENSA_PUBLI
        '
        Me.RBMENSA_PUBLI.AutoSize = True
        Me.RBMENSA_PUBLI.Checked = True
        Me.RBMENSA_PUBLI.Location = New System.Drawing.Point(16, 19)
        Me.RBMENSA_PUBLI.Name = "RBMENSA_PUBLI"
        Me.RBMENSA_PUBLI.Size = New System.Drawing.Size(103, 17)
        Me.RBMENSA_PUBLI.TabIndex = 0
        Me.RBMENSA_PUBLI.TabStop = True
        Me.RBMENSA_PUBLI.Text = "Mensaje Público"
        Me.RBMENSA_PUBLI.UseVisualStyleBackColor = True
        '
        'FrmManteMensajeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmManteMensajeria"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB1.ResumeLayout(False)
        Me.GB1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GB1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBMENSA_CORPO As System.Windows.Forms.RadioButton
    Friend WithEvents RBMENSA_PUBLI As System.Windows.Forms.RadioButton

End Class
