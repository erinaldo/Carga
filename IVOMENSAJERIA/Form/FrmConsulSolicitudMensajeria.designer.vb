<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulSolicitudMensajeria
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBAMBOS = New System.Windows.Forms.RadioButton()
        Me.RBSINMSG = New System.Windows.Forms.RadioButton()
        Me.RBCONMSG = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbidtipo_entrega = New System.Windows.Forms.ComboBox()
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox()
        Me.cbidforma_pago = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbidtipo_comprobante = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTOTALMSG = New System.Windows.Forms.TextBox()
        Me.txtCONMSG = New System.Windows.Forms.TextBox()
        Me.txtSINMSG = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer2.Size = New System.Drawing.Size(782, 556)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(17, 18)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.DGV3)
        Me.Panel.Controls.Add(Me.cmbAgencia)
        Me.Panel.Controls.Add(Me.Label6)
        Me.Panel.Location = New System.Drawing.Point(6, 198)
        Me.Panel.Size = New System.Drawing.Size(720, 222)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.txtTOTALMSG)
        Me.TabLista.Controls.Add(Me.txtCONMSG)
        Me.TabLista.Controls.Add(Me.txtSINMSG)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.Label7)
        Me.TabLista.Controls.Add(Me.Label14)
        Me.TabLista.Controls.Add(Me.Label16)
        Me.TabLista.Controls.Add(Me.cboEstado)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cboEstado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label16, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtSINMSG, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtCONMSG, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtTOTALMSG, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_entrega)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.cbidforma_pago)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_comprobante)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
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
        Me.GroupBox1.Size = New System.Drawing.Size(725, 166)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(634, 174)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(90, 13)
        Me.lblRegistros.TabIndex = 131
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBAMBOS)
        Me.GroupBox2.Controls.Add(Me.RBSINMSG)
        Me.GroupBox2.Controls.Add(Me.RBCONMSG)
        Me.GroupBox2.Location = New System.Drawing.Point(355, 135)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 41)
        Me.GroupBox2.TabIndex = 96
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta..."
        '
        'RBAMBOS
        '
        Me.RBAMBOS.AutoSize = True
        Me.RBAMBOS.Location = New System.Drawing.Point(210, 15)
        Me.RBAMBOS.Name = "RBAMBOS"
        Me.RBAMBOS.Size = New System.Drawing.Size(102, 17)
        Me.RBAMBOS.TabIndex = 0
        Me.RBAMBOS.Text = "Ambos Inclusive"
        Me.RBAMBOS.UseVisualStyleBackColor = True
        '
        'RBSINMSG
        '
        Me.RBSINMSG.AutoSize = True
        Me.RBSINMSG.Location = New System.Drawing.Point(111, 15)
        Me.RBSINMSG.Name = "RBSINMSG"
        Me.RBSINMSG.Size = New System.Drawing.Size(96, 17)
        Me.RBSINMSG.TabIndex = 0
        Me.RBSINMSG.Text = "Sin Mensajería"
        Me.RBSINMSG.UseVisualStyleBackColor = True
        '
        'RBCONMSG
        '
        Me.RBCONMSG.AutoSize = True
        Me.RBCONMSG.Checked = True
        Me.RBCONMSG.Location = New System.Drawing.Point(6, 15)
        Me.RBCONMSG.Name = "RBCONMSG"
        Me.RBCONMSG.Size = New System.Drawing.Size(100, 17)
        Me.RBCONMSG.TabIndex = 0
        Me.RBCONMSG.TabStop = True
        Me.RBCONMSG.Text = "Con Mensajería"
        Me.RBCONMSG.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(336, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Destino:"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(411, 87)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(228, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(6, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Tipo Entrega:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(6, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Origen:"
        '
        'cbidtipo_entrega
        '
        Me.cbidtipo_entrega.FormattingEnabled = True
        Me.cbidtipo_entrega.Location = New System.Drawing.Point(81, 126)
        Me.cbidtipo_entrega.Name = "cbidtipo_entrega"
        Me.cbidtipo_entrega.Size = New System.Drawing.Size(228, 21)
        Me.cbidtipo_entrega.TabIndex = 9
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(78, 87)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(231, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 9
        '
        'cbidforma_pago
        '
        Me.cbidforma_pago.FormattingEnabled = True
        Me.cbidforma_pago.Location = New System.Drawing.Point(606, 55)
        Me.cbidforma_pago.Name = "cbidforma_pago"
        Me.cbidforma_pago.Size = New System.Drawing.Size(113, 21)
        Me.cbidforma_pago.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(553, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "F. Pago:"
        '
        'cbidtipo_comprobante
        '
        Me.cbidtipo_comprobante.FormattingEnabled = True
        Me.cbidtipo_comprobante.Location = New System.Drawing.Point(411, 56)
        Me.cbidtipo_comprobante.Name = "cbidtipo_comprobante"
        Me.cbidtipo_comprobante.Size = New System.Drawing.Size(120, 21)
        Me.cbidtipo_comprobante.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(324, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "T. Comprobante:"
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.Location = New System.Drawing.Point(271, 22)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(317, 20)
        Me.txtidpersona.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(92, 22)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Codigo Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(220, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cliente :"
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(225, 55)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(78, 55)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(162, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(6, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio :"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(227, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia:"
        Me.Label6.Visible = False
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(314, 60)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(243, 21)
        Me.cmbAgencia.TabIndex = 7
        Me.cmbAgencia.Visible = False
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
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(650, 172)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 23)
        Me.Label9.TabIndex = 59
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTOTALMSG
        '
        Me.txtTOTALMSG.Location = New System.Drawing.Point(625, 430)
        Me.txtTOTALMSG.Name = "txtTOTALMSG"
        Me.txtTOTALMSG.ReadOnly = True
        Me.txtTOTALMSG.Size = New System.Drawing.Size(100, 20)
        Me.txtTOTALMSG.TabIndex = 71
        Me.txtTOTALMSG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCONMSG
        '
        Me.txtCONMSG.Location = New System.Drawing.Point(195, 430)
        Me.txtCONMSG.Name = "txtCONMSG"
        Me.txtCONMSG.ReadOnly = True
        Me.txtCONMSG.Size = New System.Drawing.Size(100, 20)
        Me.txtCONMSG.TabIndex = 70
        Me.txtCONMSG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSINMSG
        '
        Me.txtSINMSG.Location = New System.Drawing.Point(410, 430)
        Me.txtSINMSG.Name = "txtSINMSG"
        Me.txtSINMSG.ReadOnly = True
        Me.txtSINMSG.Size = New System.Drawing.Size(100, 20)
        Me.txtSINMSG.TabIndex = 69
        Me.txtSINMSG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(96, 433)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Con Mensajería"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(317, 433)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Sin Mensajería"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(532, 433)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 72
        Me.Label16.Text = "Total Mensajería"
        '
        'cboEstado
        '
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(83, 163)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(228, 21)
        Me.cboEstado.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(6, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Estado"
        '
        'FrmConsulSolicitudMensajeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulSolicitudMensajeria"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cbidforma_pago As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
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
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_entrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTOTALMSG As System.Windows.Forms.TextBox
    Friend WithEvents txtCONMSG As System.Windows.Forms.TextBox
    Friend WithEvents txtSINMSG As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBAMBOS As System.Windows.Forms.RadioButton
    Friend WithEvents RBSINMSG As System.Windows.Forms.RadioButton
    Friend WithEvents RBCONMSG As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox

End Class
