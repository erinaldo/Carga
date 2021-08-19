<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulGuiaIdaRetorno
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblRegistros = New System.Windows.Forms.Label
        Me.RBINTER = New System.Windows.Forms.RadioButton
        Me.RBAMBOS = New System.Windows.Forms.RadioButton
        Me.RBRETORNO = New System.Windows.Forms.RadioButton
        Me.RBIDA = New System.Windows.Forms.RadioButton
        Me.ChkMani = New System.Windows.Forms.CheckBox
        Me.ChkGuiaTranspor = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbidtipo_servicio = New System.Windows.Forms.ComboBox
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.L1 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.DGV3)
        Me.Panel.Location = New System.Drawing.Point(5, 85)
        Me.Panel.Size = New System.Drawing.Size(720, 375)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.L1)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.L1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.RBINTER)
        Me.GroupBox1.Controls.Add(Me.RBAMBOS)
        Me.GroupBox1.Controls.Add(Me.RBRETORNO)
        Me.GroupBox1.Controls.Add(Me.RBIDA)
        Me.GroupBox1.Controls.Add(Me.ChkMani)
        Me.GroupBox1.Controls.Add(Me.ChkGuiaTranspor)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_servicio)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 77)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(384, 55)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 98
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RBINTER
        '
        Me.RBINTER.AutoSize = True
        Me.RBINTER.Location = New System.Drawing.Point(123, 53)
        Me.RBINTER.Name = "RBINTER"
        Me.RBINTER.Size = New System.Drawing.Size(79, 17)
        Me.RBINTER.TabIndex = 97
        Me.RBINTER.TabStop = True
        Me.RBINTER.Text = "Intermedios"
        Me.RBINTER.UseVisualStyleBackColor = True
        '
        'RBAMBOS
        '
        Me.RBAMBOS.AutoSize = True
        Me.RBAMBOS.Location = New System.Drawing.Point(208, 53)
        Me.RBAMBOS.Name = "RBAMBOS"
        Me.RBAMBOS.Size = New System.Drawing.Size(102, 17)
        Me.RBAMBOS.TabIndex = 96
        Me.RBAMBOS.Text = "Ambos Inclusive"
        Me.RBAMBOS.UseVisualStyleBackColor = True
        '
        'RBRETORNO
        '
        Me.RBRETORNO.AutoSize = True
        Me.RBRETORNO.Location = New System.Drawing.Point(54, 53)
        Me.RBRETORNO.Name = "RBRETORNO"
        Me.RBRETORNO.Size = New System.Drawing.Size(68, 17)
        Me.RBRETORNO.TabIndex = 96
        Me.RBRETORNO.Text = "Retornos"
        Me.RBRETORNO.UseVisualStyleBackColor = True
        '
        'RBIDA
        '
        Me.RBIDA.AutoSize = True
        Me.RBIDA.Checked = True
        Me.RBIDA.Location = New System.Drawing.Point(8, 53)
        Me.RBIDA.Name = "RBIDA"
        Me.RBIDA.Size = New System.Drawing.Size(45, 17)
        Me.RBIDA.TabIndex = 96
        Me.RBIDA.TabStop = True
        Me.RBIDA.Text = "Idas"
        Me.RBIDA.UseVisualStyleBackColor = True
        '
        'ChkMani
        '
        Me.ChkMani.AutoSize = True
        Me.ChkMani.BackColor = System.Drawing.Color.Transparent
        Me.ChkMani.Location = New System.Drawing.Point(634, 54)
        Me.ChkMani.Name = "ChkMani"
        Me.ChkMani.Size = New System.Drawing.Size(74, 17)
        Me.ChkMani.TabIndex = 82
        Me.ChkMani.Text = "Manifiesto"
        Me.ChkMani.UseVisualStyleBackColor = False
        '
        'ChkGuiaTranspor
        '
        Me.ChkGuiaTranspor.AutoSize = True
        Me.ChkGuiaTranspor.BackColor = System.Drawing.Color.Transparent
        Me.ChkGuiaTranspor.Checked = True
        Me.ChkGuiaTranspor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkGuiaTranspor.Location = New System.Drawing.Point(634, 38)
        Me.ChkGuiaTranspor.Name = "ChkGuiaTranspor"
        Me.ChkGuiaTranspor.Size = New System.Drawing.Size(85, 17)
        Me.ChkGuiaTranspor.TabIndex = 82
        Me.ChkGuiaTranspor.Text = "G. Transpor."
        Me.ChkGuiaTranspor.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(437, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "T. Servicio:"
        '
        'cbidtipo_servicio
        '
        Me.cbidtipo_servicio.FormattingEnabled = True
        Me.cbidtipo_servicio.Location = New System.Drawing.Point(504, 15)
        Me.cbidtipo_servicio.Name = "cbidtipo_servicio"
        Me.cbidtipo_servicio.Size = New System.Drawing.Size(152, 21)
        Me.cbidtipo_servicio.TabIndex = 94
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(238, 13)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(82, 13)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(172, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(5, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio :"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.BackgroundColor = System.Drawing.Color.White
        Me.DGV3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV3.Location = New System.Drawing.Point(0, 0)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(720, 375)
        Me.DGV3.TabIndex = 59
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.Transparent
        Me.L1.Location = New System.Drawing.Point(663, 111)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(59, 13)
        Me.L1.TabIndex = 60
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmConsulGuiaIdaRetorno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulGuiaIdaRetorno"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_servicio As System.Windows.Forms.ComboBox
    Friend WithEvents ChkMani As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGuiaTranspor As System.Windows.Forms.CheckBox
    Friend WithEvents RBAMBOS As System.Windows.Forms.RadioButton
    Friend WithEvents RBRETORNO As System.Windows.Forms.RadioButton
    Friend WithEvents RBIDA As System.Windows.Forms.RadioButton
    Friend WithEvents RBINTER As System.Windows.Forms.RadioButton

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
