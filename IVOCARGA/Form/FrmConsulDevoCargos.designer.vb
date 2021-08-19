<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulDevoCargos
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNRO_LIQUI_DEVO_CARGO = New System.Windows.Forms.TextBox()
        Me.tbnro_factura = New System.Windows.Forms.TextBox()
        Me.cbidtipo_entrega = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkENCO = New System.Windows.Forms.CheckBox()
        Me.chkPEND = New System.Windows.Forms.CheckBox()
        Me.chkDEVO = New System.Windows.Forms.CheckBox()
        Me.chkENOB = New System.Windows.Forms.CheckBox()
        Me.btnacep = New System.Windows.Forms.Button()
        Me.rbimpri = New System.Windows.Forms.RadioButton()
        Me.rbproce = New System.Windows.Forms.RadioButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtNro_guia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.cbidforma_pago = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbidtipo_comprobante = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertirSeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionarNingunoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AgregarDocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txttotal_costo = New System.Windows.Forms.TextBox()
        Me.txtsub_total = New System.Windows.Forms.TextBox()
        Me.txtmonto_impuesto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
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
        Me.cms.SuspendLayout()
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
        Me.Panel.Location = New System.Drawing.Point(6, 198)
        Me.Panel.Size = New System.Drawing.Size(720, 222)
        '
        'TabLista
        '
        Me.TabLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.Label23)
        Me.TabLista.Controls.Add(Me.Label18)
        Me.TabLista.Controls.Add(Me.Label19)
        Me.TabLista.Controls.Add(Me.txttotal_costo)
        Me.TabLista.Controls.Add(Me.txtsub_total)
        Me.TabLista.Controls.Add(Me.txtmonto_impuesto)
        Me.TabLista.Controls.Add(Me.Label17)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.Label14)
        Me.TabLista.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label17, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtmonto_impuesto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtsub_total, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txttotal_costo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label19, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label18, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label23, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtNRO_LIQUI_DEVO_CARGO)
        Me.GroupBox1.Controls.Add(Me.tbnro_factura)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_entrega)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnacep)
        Me.GroupBox1.Controls.Add(Me.rbimpri)
        Me.GroupBox1.Controls.Add(Me.rbproce)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtNro_guia)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.cbidforma_pago)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_comprobante)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.Label21)
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
        Me.GroupBox1.Size = New System.Drawing.Size(725, 190)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'txtNRO_LIQUI_DEVO_CARGO
        '
        Me.txtNRO_LIQUI_DEVO_CARGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNRO_LIQUI_DEVO_CARGO.Location = New System.Drawing.Point(73, 96)
        Me.txtNRO_LIQUI_DEVO_CARGO.MaxLength = 10
        Me.txtNRO_LIQUI_DEVO_CARGO.Name = "txtNRO_LIQUI_DEVO_CARGO"
        Me.txtNRO_LIQUI_DEVO_CARGO.Size = New System.Drawing.Size(76, 20)
        Me.txtNRO_LIQUI_DEVO_CARGO.TabIndex = 6
        '
        'tbnro_factura
        '
        Me.tbnro_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbnro_factura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbnro_factura.Location = New System.Drawing.Point(73, 70)
        Me.tbnro_factura.MaxLength = 13
        Me.tbnro_factura.Name = "tbnro_factura"
        Me.tbnro_factura.Size = New System.Drawing.Size(76, 20)
        Me.tbnro_factura.TabIndex = 6
        '
        'cbidtipo_entrega
        '
        Me.cbidtipo_entrega.FormattingEnabled = True
        Me.cbidtipo_entrega.Location = New System.Drawing.Point(73, 126)
        Me.cbidtipo_entrega.Name = "cbidtipo_entrega"
        Me.cbidtipo_entrega.Size = New System.Drawing.Size(240, 21)
        Me.cbidtipo_entrega.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkENCO)
        Me.GroupBox2.Controls.Add(Me.chkPEND)
        Me.GroupBox2.Controls.Add(Me.chkDEVO)
        Me.GroupBox2.Controls.Add(Me.chkENOB)
        Me.GroupBox2.Location = New System.Drawing.Point(383, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(254, 65)
        Me.GroupBox2.TabIndex = 106
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Situación Cargos"
        '
        'chkENCO
        '
        Me.chkENCO.AutoSize = True
        Me.chkENCO.Location = New System.Drawing.Point(6, 22)
        Me.chkENCO.Name = "chkENCO"
        Me.chkENCO.Size = New System.Drawing.Size(96, 17)
        Me.chkENCO.TabIndex = 103
        Me.chkENCO.Text = "Recepcionado"
        Me.chkENCO.UseVisualStyleBackColor = True
        '
        'chkPEND
        '
        Me.chkPEND.AutoSize = True
        Me.chkPEND.Checked = True
        Me.chkPEND.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPEND.Location = New System.Drawing.Point(114, 40)
        Me.chkPEND.Name = "chkPEND"
        Me.chkPEND.Size = New System.Drawing.Size(118, 17)
        Me.chkPEND.TabIndex = 105
        Me.chkPEND.Text = "Pendiente devolver"
        Me.chkPEND.UseVisualStyleBackColor = True
        '
        'chkDEVO
        '
        Me.chkDEVO.AutoSize = True
        Me.chkDEVO.Location = New System.Drawing.Point(6, 40)
        Me.chkDEVO.Name = "chkDEVO"
        Me.chkDEVO.Size = New System.Drawing.Size(69, 17)
        Me.chkDEVO.TabIndex = 102
        Me.chkDEVO.Text = "Devuelto"
        Me.chkDEVO.UseVisualStyleBackColor = True
        '
        'chkENOB
        '
        Me.chkENOB.AutoSize = True
        Me.chkENOB.Checked = True
        Me.chkENOB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkENOB.Location = New System.Drawing.Point(114, 22)
        Me.chkENOB.Name = "chkENOB"
        Me.chkENOB.Size = New System.Drawing.Size(121, 17)
        Me.chkENOB.TabIndex = 104
        Me.chkENOB.Text = "Obs. Recepcionado"
        Me.chkENOB.UseVisualStyleBackColor = True
        '
        'btnacep
        '
        Me.btnacep.Enabled = False
        Me.btnacep.Location = New System.Drawing.Point(643, 129)
        Me.btnacep.Name = "btnacep"
        Me.btnacep.Size = New System.Drawing.Size(75, 55)
        Me.btnacep.TabIndex = 101
        Me.btnacep.Text = "Cerrar"
        Me.btnacep.UseVisualStyleBackColor = True
        '
        'rbimpri
        '
        Me.rbimpri.AutoSize = True
        Me.rbimpri.Location = New System.Drawing.Point(225, 170)
        Me.rbimpri.Name = "rbimpri"
        Me.rbimpri.Size = New System.Drawing.Size(131, 17)
        Me.rbimpri.TabIndex = 100
        Me.rbimpri.Text = "Imprimir seleccionados"
        Me.rbimpri.UseVisualStyleBackColor = True
        '
        'rbproce
        '
        Me.rbproce.AutoSize = True
        Me.rbproce.Location = New System.Drawing.Point(225, 154)
        Me.rbproce.Name = "rbproce"
        Me.rbproce.Size = New System.Drawing.Size(104, 17)
        Me.rbproce.TabIndex = 99
        Me.rbproce.Text = "Devolver Cargos"
        Me.rbproce.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(4, 161)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 30)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Nro. Doc. en la lista:"
        '
        'txtNro_guia
        '
        Me.txtNro_guia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNro_guia.Location = New System.Drawing.Point(73, 170)
        Me.txtNro_guia.Name = "txtNro_guia"
        Me.txtNro_guia.Size = New System.Drawing.Size(142, 20)
        Me.txtNro_guia.TabIndex = 96
        Me.txtNro_guia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(418, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Destino:"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(476, 69)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(243, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(4, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Tipo Entrega:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(156, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Origen:"
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(203, 71)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(209, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(418, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 29)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Usuario Entrega:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(147, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 30)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia Destino:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(476, 96)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(243, 21)
        Me.cmbUsuarios.TabIndex = 8
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(203, 96)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(209, 21)
        Me.cmbAgencia.TabIndex = 7
        '
        'cbidforma_pago
        '
        Me.cbidforma_pago.FormattingEnabled = True
        Me.cbidforma_pago.Location = New System.Drawing.Point(584, 41)
        Me.cbidforma_pago.Name = "cbidforma_pago"
        Me.cbidforma_pago.Size = New System.Drawing.Size(135, 21)
        Me.cbidforma_pago.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(531, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "F. Pago:"
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
        Me.Label4.Location = New System.Drawing.Point(307, 44)
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
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(4, 96)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 27)
        Me.Label21.TabIndex = 68
        Me.Label21.Text = "Nro. Liquid. Dev. Cargo:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(4, 71)
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
        Me.Label2.Location = New System.Drawing.Point(4, 15)
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
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(225, 40)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(82, 41)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(163, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 28)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Entrega Fin :"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(4, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 30)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Entrega Inicio :"
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
        Me.DGV3.ContextMenuStrip = Me.cms
        Me.DGV3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV3.Location = New System.Drawing.Point(0, 0)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(720, 222)
        Me.DGV3.TabIndex = 11
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarTodoToolStripMenuItem, Me.InvertirSeleccionToolStripMenuItem, Me.SeleccionarNingunoToolStripMenuItem, Me.ToolStripMenuItem2, Me.AgregarDocumentosToolStripMenuItem})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(186, 98)
        '
        'SeleccionarTodoToolStripMenuItem
        '
        Me.SeleccionarTodoToolStripMenuItem.Name = "SeleccionarTodoToolStripMenuItem"
        Me.SeleccionarTodoToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SeleccionarTodoToolStripMenuItem.Text = "Seleccionar todo"
        '
        'InvertirSeleccionToolStripMenuItem
        '
        Me.InvertirSeleccionToolStripMenuItem.Name = "InvertirSeleccionToolStripMenuItem"
        Me.InvertirSeleccionToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.InvertirSeleccionToolStripMenuItem.Text = "Invertir selección"
        '
        'SeleccionarNingunoToolStripMenuItem
        '
        Me.SeleccionarNingunoToolStripMenuItem.Name = "SeleccionarNingunoToolStripMenuItem"
        Me.SeleccionarNingunoToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SeleccionarNingunoToolStripMenuItem.Text = "Seleccionar ninguno"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(182, 6)
        '
        'AgregarDocumentosToolStripMenuItem
        '
        Me.AgregarDocumentosToolStripMenuItem.Name = "AgregarDocumentosToolStripMenuItem"
        Me.AgregarDocumentosToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AgregarDocumentosToolStripMenuItem.Text = "Agregar documentos"
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
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.White
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(186, 436)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 19)
        Me.Label23.TabIndex = 69
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Location = New System.Drawing.Point(7, 434)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 19)
        Me.Label17.TabIndex = 69
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(4, 419)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 15)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "Total en la lista:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(183, 421)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(133, 15)
        Me.Label19.TabIndex = 70
        Me.Label19.Text = "Total Seleccionados:"
        '
        'FrmConsulDevoCargos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulDevoCargos"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
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
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
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
    Friend WithEvents tbnro_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttotal_costo As System.Windows.Forms.TextBox
    Friend WithEvents txtsub_total As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_impuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_entrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertirSeleccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeleccionarNingunoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtNro_guia As System.Windows.Forms.TextBox
    Friend WithEvents rbimpri As System.Windows.Forms.RadioButton
    Friend WithEvents rbproce As System.Windows.Forms.RadioButton
    Friend WithEvents btnacep As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AgregarDocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtNRO_LIQUI_DEVO_CARGO As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents chkPEND As System.Windows.Forms.CheckBox
    Friend WithEvents chkENOB As System.Windows.Forms.CheckBox
    Friend WithEvents chkENCO As System.Windows.Forms.CheckBox
    Friend WithEvents chkDEVO As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
