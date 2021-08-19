<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulFactuEmiContaGerencia
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBAMBOS_INCLU = New System.Windows.Forms.RadioButton
        Me.RBSIN_ENTRE = New System.Windows.Forms.RadioButton
        Me.RBENTRE = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbidtipo_entrega = New System.Windows.Forms.ComboBox
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox
        Me.cmbAgencia = New System.Windows.Forms.ComboBox
        Me.cbidtipo_comprobante = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtidpersona = New System.Windows.Forms.TextBox
        Me.tbnro_factura = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.txttotal_costo = New System.Windows.Forms.TextBox
        Me.txtsub_total = New System.Windows.Forms.TextBox
        Me.txtmonto_impuesto = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblRegistros = New System.Windows.Forms.Label
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
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel.Location = New System.Drawing.Point(6, 198)
        Me.Panel.Size = New System.Drawing.Size(720, 222)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.txttotal_costo)
        Me.TabLista.Controls.Add(Me.txtsub_total)
        Me.TabLista.Controls.Add(Me.txtmonto_impuesto)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.Label14)
        Me.TabLista.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtmonto_impuesto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtsub_total, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txttotal_costo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_entrega)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_comprobante)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.tbnro_factura)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 167)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBAMBOS_INCLU)
        Me.GroupBox2.Controls.Add(Me.RBSIN_ENTRE)
        Me.GroupBox2.Controls.Add(Me.RBENTRE)
        Me.GroupBox2.Location = New System.Drawing.Point(335, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 43)
        Me.GroupBox2.TabIndex = 96
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'RBAMBOS_INCLU
        '
        Me.RBAMBOS_INCLU.AutoSize = True
        Me.RBAMBOS_INCLU.BackColor = System.Drawing.Color.Transparent
        Me.RBAMBOS_INCLU.Checked = True
        Me.RBAMBOS_INCLU.Location = New System.Drawing.Point(180, 12)
        Me.RBAMBOS_INCLU.Name = "RBAMBOS_INCLU"
        Me.RBAMBOS_INCLU.Size = New System.Drawing.Size(101, 17)
        Me.RBAMBOS_INCLU.TabIndex = 69
        Me.RBAMBOS_INCLU.TabStop = True
        Me.RBAMBOS_INCLU.Text = "Ambos inclusive"
        Me.RBAMBOS_INCLU.UseVisualStyleBackColor = False
        '
        'RBSIN_ENTRE
        '
        Me.RBSIN_ENTRE.AutoSize = True
        Me.RBSIN_ENTRE.BackColor = System.Drawing.Color.Transparent
        Me.RBSIN_ENTRE.Location = New System.Drawing.Point(91, 12)
        Me.RBSIN_ENTRE.Name = "RBSIN_ENTRE"
        Me.RBSIN_ENTRE.Size = New System.Drawing.Size(83, 17)
        Me.RBSIN_ENTRE.TabIndex = 69
        Me.RBSIN_ENTRE.Text = "Sin Entregar"
        Me.RBSIN_ENTRE.UseVisualStyleBackColor = False
        '
        'RBENTRE
        '
        Me.RBENTRE.AutoSize = True
        Me.RBENTRE.BackColor = System.Drawing.Color.Transparent
        Me.RBENTRE.Location = New System.Drawing.Point(9, 12)
        Me.RBENTRE.Name = "RBENTRE"
        Me.RBENTRE.Size = New System.Drawing.Size(79, 17)
        Me.RBENTRE.TabIndex = 69
        Me.RBENTRE.Text = "Entregados"
        Me.RBENTRE.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(323, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Destino:"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(375, 96)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(243, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(2, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Tipo Entraga:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(4, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Origen:"
        '
        'cbidtipo_entrega
        '
        Me.cbidtipo_entrega.FormattingEnabled = True
        Me.cbidtipo_entrega.Location = New System.Drawing.Point(73, 126)
        Me.cbidtipo_entrega.Name = "cbidtipo_entrega"
        Me.cbidtipo_entrega.Size = New System.Drawing.Size(241, 21)
        Me.cbidtipo_entrega.TabIndex = 9
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(73, 99)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(243, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(429, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Usuario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(132, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia:"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(476, 69)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(243, 21)
        Me.cmbUsuarios.TabIndex = 8
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(184, 69)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(243, 21)
        Me.cmbAgencia.TabIndex = 7
        '
        'cbidtipo_comprobante
        '
        Me.cbidtipo_comprobante.FormattingEnabled = True
        Me.cbidtipo_comprobante.Location = New System.Drawing.Point(395, 41)
        Me.cbidtipo_comprobante.Name = "cbidtipo_comprobante"
        Me.cbidtipo_comprobante.Size = New System.Drawing.Size(135, 21)
        Me.cbidtipo_comprobante.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(303, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "T. Comprobante:"
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.Location = New System.Drawing.Point(271, 13)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(317, 20)
        Me.txtidpersona.TabIndex = 1
        '
        'tbnro_factura
        '
        Me.tbnro_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbnro_factura.Location = New System.Drawing.Point(62, 70)
        Me.tbnro_factura.Name = "tbnro_factura"
        Me.tbnro_factura.Size = New System.Drawing.Size(62, 20)
        Me.tbnro_factura.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(7, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Nro. Doc.:"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(92, 13)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Codigo Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(220, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cliente :"
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(217, 41)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(73, 41)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(159, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(5, 44)
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
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.BackgroundColor = System.Drawing.Color.White
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV3.Location = New System.Drawing.Point(0, 0)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(720, 222)
        Me.DGV3.TabIndex = 11
        '
        'txttotal_costo
        '
        Me.txttotal_costo.Location = New System.Drawing.Point(626, 436)
        Me.txttotal_costo.Name = "txttotal_costo"
        Me.txttotal_costo.ReadOnly = True
        Me.txttotal_costo.Size = New System.Drawing.Size(100, 20)
        Me.txttotal_costo.TabIndex = 59
        Me.txttotal_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsub_total
        '
        Me.txtsub_total.Location = New System.Drawing.Point(417, 436)
        Me.txtsub_total.Name = "txtsub_total"
        Me.txtsub_total.ReadOnly = True
        Me.txtsub_total.Size = New System.Drawing.Size(100, 20)
        Me.txtsub_total.TabIndex = 59
        Me.txtsub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmonto_impuesto
        '
        Me.txtmonto_impuesto.Location = New System.Drawing.Point(520, 436)
        Me.txtmonto_impuesto.Name = "txtmonto_impuesto"
        Me.txtmonto_impuesto.ReadOnly = True
        Me.txtmonto_impuesto.Size = New System.Drawing.Size(100, 20)
        Me.txtmonto_impuesto.TabIndex = 59
        Me.txtmonto_impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(414, 423)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 13)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "Sub Total"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(517, 423)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Monto Impuesto"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(623, 423)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Total Costo"
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(633, 182)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 85
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmConsulFactuEmiContaGerencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulFactuEmiContaGerencia"
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
        Me.TabLista.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cbidtipo_comprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents tbnro_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttotal_costo As System.Windows.Forms.TextBox
    Friend WithEvents txtsub_total As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_impuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBENTRE As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_entrega As System.Windows.Forms.ComboBox
    Friend WithEvents RBAMBOS_INCLU As System.Windows.Forms.RadioButton
    Friend WithEvents RBSIN_ENTRE As System.Windows.Forms.RadioButton

    Friend Shadows WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
