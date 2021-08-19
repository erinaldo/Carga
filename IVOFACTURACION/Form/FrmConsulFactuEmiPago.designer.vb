<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulFactuEmiPago
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
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.rd_imprime_pantalla = New System.Windows.Forms.RadioButton()
        Me.Lab_funcionario = New System.Windows.Forms.Label()
        Me.radB_linea_credito = New System.Windows.Forms.RadioButton()
        Me.RadB_Saldo = New System.Windows.Forms.RadioButton()
        Me.cmb_tipo_facturacion = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_saldo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.cmb_funcionario = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_linea_credito = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.cbidforma_pago = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbidtipo_moneda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHAinicioFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txt_saldo_cliente = New System.Windows.Forms.TextBox()
        Me.CMS_cargofactura = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CargoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblguias = New System.Windows.Forms.Label()
        Me.lblprefacturas = New System.Windows.Forms.Label()
        Me.lblfacturas = New System.Windows.Forms.Label()
        Me.lab_pagos = New System.Windows.Forms.Label()
        Me.Lab_cta_corriente = New System.Windows.Forms.Label()
        Me.lbltotal_guias = New System.Windows.Forms.Label()
        Me.lbltotal_prefacturas = New System.Windows.Forms.Label()
        Me.lbltotal_facturas = New System.Windows.Forms.Label()
        Me.lbltotal_pagoS = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TPGUIAS = New System.Windows.Forms.TabPage()
        Me.Lab_Nro_guia_envio = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DGVGUIAS = New System.Windows.Forms.DataGridView()
        Me.TPPREFAC = New System.Windows.Forms.TabPage()
        Me.Lab_pendiente_x_facturar = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DGVPREFACTURAS = New System.Windows.Forms.DataGridView()
        Me.TPFACTU = New System.Windows.Forms.TabPage()
        Me.Lab_pendiente_x_cobrar = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.DGVFACTURAS = New System.Windows.Forms.DataGridView()
        Me.TPABO = New System.Windows.Forms.TabPage()
        Me.Lab_cobranza = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.DGVPAGOS = New System.Windows.Forms.DataGridView()
        Me.TPFACTURA_OFISIS = New System.Windows.Forms.TabPage()
        Me.Lab_registro_detalle = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lab_nro_cta_corriente = New System.Windows.Forms.Label()
        Me.lab_cuenta_corriente = New System.Windows.Forms.Label()
        Me.DGV_cta_corriente_det = New System.Windows.Forms.DataGridView()
        Me.rb_ambas_ctacorriente = New System.Windows.Forms.RadioButton()
        Me.RbtLegal = New System.Windows.Forms.RadioButton()
        Me.rb_vencido_ctacorriente = New System.Windows.Forms.RadioButton()
        Me.rb_por_vencer_ctacorriente = New System.Windows.Forms.RadioButton()
        Me.DGV_cuenta_corriente = New System.Windows.Forms.DataGridView()
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
        Me.CMS_cargofactura.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TPGUIAS.SuspendLayout()
        CType(Me.DGVGUIAS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPPREFAC.SuspendLayout()
        CType(Me.DGVPREFACTURAS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPFACTU.SuspendLayout()
        CType(Me.DGVFACTURAS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPABO.SuspendLayout()
        CType(Me.DGVPAGOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPFACTURA_OFISIS.SuspendLayout()
        CType(Me.DGV_cta_corriente_det, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_cuenta_corriente, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.TabControl1)
        Me.Panel.Location = New System.Drawing.Point(4, 123)
        Me.Panel.Size = New System.Drawing.Size(725, 311)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lbltotal_pagoS)
        Me.TabLista.Controls.Add(Me.lbltotal_facturas)
        Me.TabLista.Controls.Add(Me.lbltotal_prefacturas)
        Me.TabLista.Controls.Add(Me.lbltotal_guias)
        Me.TabLista.Controls.Add(Me.txt_saldo_cliente)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.Label14)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.Label15)
        Me.TabLista.Controls.Add(Me.Label16)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label16, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label15, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_saldo_cliente, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lbltotal_guias, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lbltotal_prefacturas, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lbltotal_facturas, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lbltotal_pagoS, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbProducto)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.rd_imprime_pantalla)
        Me.GroupBox1.Controls.Add(Me.Lab_funcionario)
        Me.GroupBox1.Controls.Add(Me.radB_linea_credito)
        Me.GroupBox1.Controls.Add(Me.RadB_Saldo)
        Me.GroupBox1.Controls.Add(Me.cmb_tipo_facturacion)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txt_saldo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.cmb_funcionario)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_linea_credito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.cbidforma_pago)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_moneda)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAinicioFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 115)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Items.AddRange(New Object() {"COURIER"})
        Me.cmbProducto.Location = New System.Drawing.Point(423, 88)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(296, 21)
        Me.cmbProducto.TabIndex = 104
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(344, 92)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 13)
        Me.Label28.TabIndex = 103
        Me.Label28.Text = "Producto :"
        '
        'rd_imprime_pantalla
        '
        Me.rd_imprime_pantalla.AutoSize = True
        Me.rd_imprime_pantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rd_imprime_pantalla.Location = New System.Drawing.Point(7, 90)
        Me.rd_imprime_pantalla.Name = "rd_imprime_pantalla"
        Me.rd_imprime_pantalla.Size = New System.Drawing.Size(132, 17)
        Me.rd_imprime_pantalla.TabIndex = 96
        Me.rd_imprime_pantalla.Text = "Guía Envío Pendiente"
        Me.rd_imprime_pantalla.UseVisualStyleBackColor = True
        '
        'Lab_funcionario
        '
        Me.Lab_funcionario.AutoSize = True
        Me.Lab_funcionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_funcionario.Location = New System.Drawing.Point(425, 90)
        Me.Lab_funcionario.Name = "Lab_funcionario"
        Me.Lab_funcionario.Size = New System.Drawing.Size(0, 15)
        Me.Lab_funcionario.TabIndex = 95
        '
        'radB_linea_credito
        '
        Me.radB_linea_credito.AutoSize = True
        Me.radB_linea_credito.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.radB_linea_credito.Location = New System.Drawing.Point(139, 90)
        Me.radB_linea_credito.Name = "radB_linea_credito"
        Me.radB_linea_credito.Size = New System.Drawing.Size(88, 17)
        Me.radB_linea_credito.TabIndex = 94
        Me.radB_linea_credito.Text = "Línea crédito"
        Me.radB_linea_credito.UseVisualStyleBackColor = True
        Me.radB_linea_credito.Visible = False
        '
        'RadB_Saldo
        '
        Me.RadB_Saldo.AutoSize = True
        Me.RadB_Saldo.Checked = True
        Me.RadB_Saldo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadB_Saldo.Location = New System.Drawing.Point(233, 90)
        Me.RadB_Saldo.Name = "RadB_Saldo"
        Me.RadB_Saldo.Size = New System.Drawing.Size(95, 17)
        Me.RadB_Saldo.TabIndex = 93
        Me.RadB_Saldo.TabStop = True
        Me.RadB_Saldo.Text = "Saldo x Cliente"
        Me.RadB_Saldo.UseVisualStyleBackColor = True
        Me.RadB_Saldo.Visible = False
        '
        'cmb_tipo_facturacion
        '
        Me.cmb_tipo_facturacion.FormattingEnabled = True
        Me.cmb_tipo_facturacion.Location = New System.Drawing.Point(624, 38)
        Me.cmb_tipo_facturacion.Name = "cmb_tipo_facturacion"
        Me.cmb_tipo_facturacion.Size = New System.Drawing.Size(95, 21)
        Me.cmb_tipo_facturacion.TabIndex = 92
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(522, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 13)
        Me.Label17.TabIndex = 91
        Me.Label17.Text = "Tipo Facturación :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(550, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Saldo :"
        '
        'txt_saldo
        '
        Me.txt_saldo.BackColor = System.Drawing.SystemColors.Info
        Me.txt_saldo.Location = New System.Drawing.Point(594, 64)
        Me.txt_saldo.MaxLength = 10
        Me.txt_saldo.Name = "txt_saldo"
        Me.txt_saldo.ReadOnly = True
        Me.txt_saldo.Size = New System.Drawing.Size(126, 20)
        Me.txt_saldo.TabIndex = 89
        Me.txt_saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(195, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Fecha Fin : "
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DTPFECHAFINALFACTURA.CustomFormat = ""
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(259, 64)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 87
        '
        'cmb_funcionario
        '
        Me.cmb_funcionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmb_funcionario.FormattingEnabled = True
        Me.cmb_funcionario.Location = New System.Drawing.Point(109, 37)
        Me.cmb_funcionario.Name = "cmb_funcionario"
        Me.cmb_funcionario.Size = New System.Drawing.Size(405, 21)
        Me.cmb_funcionario.TabIndex = 86
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Funcionario :"
        '
        'txt_linea_credito
        '
        Me.txt_linea_credito.BackColor = System.Drawing.SystemColors.Info
        Me.txt_linea_credito.Location = New System.Drawing.Point(423, 64)
        Me.txt_linea_credito.MaxLength = 10
        Me.txt_linea_credito.Name = "txt_linea_credito"
        Me.txt_linea_credito.ReadOnly = True
        Me.txt_linea_credito.Size = New System.Drawing.Size(126, 20)
        Me.txt_linea_credito.TabIndex = 83
        Me.txt_linea_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(344, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Línea Crédito :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Enabled = False
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(347, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Usuario:"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Enabled = False
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(263, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia :"
        Me.Label6.Visible = False
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.Enabled = False
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(403, 33)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(24, 21)
        Me.cmbUsuarios.TabIndex = 7
        Me.cmbUsuarios.Visible = False
        '
        'cmbAgencia
        '
        Me.cmbAgencia.Enabled = False
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(319, 40)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(22, 21)
        Me.cmbAgencia.TabIndex = 6
        Me.cmbAgencia.Visible = False
        '
        'cbidforma_pago
        '
        Me.cbidforma_pago.Enabled = False
        Me.cbidforma_pago.FormattingEnabled = True
        Me.cbidforma_pago.Location = New System.Drawing.Point(594, 31)
        Me.cbidforma_pago.Name = "cbidforma_pago"
        Me.cbidforma_pago.Size = New System.Drawing.Size(126, 21)
        Me.cbidforma_pago.TabIndex = 5
        Me.cbidforma_pago.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Enabled = False
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(520, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Forma Pago :"
        Me.Label11.Visible = False
        '
        'cbidtipo_moneda
        '
        Me.cbidtipo_moneda.Enabled = False
        Me.cbidtipo_moneda.FormattingEnabled = True
        Me.cbidtipo_moneda.Location = New System.Drawing.Point(488, 33)
        Me.cbidtipo_moneda.Name = "cbidtipo_moneda"
        Me.cbidtipo_moneda.Size = New System.Drawing.Size(24, 21)
        Me.cbidtipo_moneda.TabIndex = 4
        Me.cbidtipo_moneda.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Enabled = False
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(433, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Moneda:"
        Me.Label4.Visible = False
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidpersona.Location = New System.Drawing.Point(271, 10)
        Me.txtidpersona.MaxLength = 150
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(317, 20)
        Me.txtidpersona.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(109, 10)
        Me.txtCodigoCliente.MaxLength = 11
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Codigo Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(220, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cliente :"
        '
        'DTPFECHAinicioFACTURA
        '
        Me.DTPFECHAinicioFACTURA.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DTPFECHAinicioFACTURA.CustomFormat = ""
        Me.DTPFECHAinicioFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAinicioFACTURA.Location = New System.Drawing.Point(109, 64)
        Me.DTPFECHAinicioFACTURA.Name = "DTPFECHAinicioFACTURA"
        Me.DTPFECHAinicioFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAinicioFACTURA.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(6, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Inicio : "
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txt_saldo_cliente
        '
        Me.txt_saldo_cliente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_saldo_cliente.Location = New System.Drawing.Point(581, 440)
        Me.txt_saldo_cliente.MaxLength = 10
        Me.txt_saldo_cliente.Name = "txt_saldo_cliente"
        Me.txt_saldo_cliente.ReadOnly = True
        Me.txt_saldo_cliente.Size = New System.Drawing.Size(125, 20)
        Me.txt_saldo_cliente.TabIndex = 81
        Me.txt_saldo_cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMS_cargofactura
        '
        Me.CMS_cargofactura.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargoToolStripMenuItem})
        Me.CMS_cargofactura.Name = "CMS_cargofactura"
        Me.CMS_cargofactura.Size = New System.Drawing.Size(107, 26)
        '
        'CargoToolStripMenuItem
        '
        Me.CargoToolStripMenuItem.Enabled = False
        Me.CargoToolStripMenuItem.Name = "CargoToolStripMenuItem"
        Me.CargoToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.CargoToolStripMenuItem.Text = "Cargo"
        Me.CargoToolStripMenuItem.Visible = False
        '
        'lblguias
        '
        Me.lblguias.BackColor = System.Drawing.Color.Transparent
        Me.lblguias.Location = New System.Drawing.Point(609, 6)
        Me.lblguias.Name = "lblguias"
        Me.lblguias.Size = New System.Drawing.Size(100, 21)
        Me.lblguias.TabIndex = 63
        Me.lblguias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblprefacturas
        '
        Me.lblprefacturas.BackColor = System.Drawing.Color.Transparent
        Me.lblprefacturas.Location = New System.Drawing.Point(609, 5)
        Me.lblprefacturas.Name = "lblprefacturas"
        Me.lblprefacturas.Size = New System.Drawing.Size(100, 21)
        Me.lblprefacturas.TabIndex = 64
        Me.lblprefacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblfacturas
        '
        Me.lblfacturas.BackColor = System.Drawing.Color.Transparent
        Me.lblfacturas.Location = New System.Drawing.Point(607, 5)
        Me.lblfacturas.Name = "lblfacturas"
        Me.lblfacturas.Size = New System.Drawing.Size(100, 21)
        Me.lblfacturas.TabIndex = 65
        Me.lblfacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lab_pagos
        '
        Me.lab_pagos.BackColor = System.Drawing.Color.Transparent
        Me.lab_pagos.Location = New System.Drawing.Point(608, 2)
        Me.lab_pagos.Name = "lab_pagos"
        Me.lab_pagos.Size = New System.Drawing.Size(100, 21)
        Me.lab_pagos.TabIndex = 67
        Me.lab_pagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lab_cta_corriente
        '
        Me.Lab_cta_corriente.BackColor = System.Drawing.Color.Transparent
        Me.Lab_cta_corriente.Location = New System.Drawing.Point(606, 6)
        Me.Lab_cta_corriente.Name = "Lab_cta_corriente"
        Me.Lab_cta_corriente.Size = New System.Drawing.Size(100, 21)
        Me.Lab_cta_corriente.TabIndex = 66
        Me.Lab_cta_corriente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotal_guias
        '
        Me.lbltotal_guias.BackColor = System.Drawing.SystemColors.Info
        Me.lbltotal_guias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltotal_guias.Location = New System.Drawing.Point(11, 441)
        Me.lbltotal_guias.Name = "lbltotal_guias"
        Me.lbltotal_guias.Size = New System.Drawing.Size(106, 19)
        Me.lbltotal_guias.TabIndex = 59
        Me.lbltotal_guias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotal_prefacturas
        '
        Me.lbltotal_prefacturas.BackColor = System.Drawing.SystemColors.Info
        Me.lbltotal_prefacturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltotal_prefacturas.Location = New System.Drawing.Point(123, 441)
        Me.lbltotal_prefacturas.Name = "lbltotal_prefacturas"
        Me.lbltotal_prefacturas.Size = New System.Drawing.Size(100, 19)
        Me.lbltotal_prefacturas.TabIndex = 59
        Me.lbltotal_prefacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotal_facturas
        '
        Me.lbltotal_facturas.BackColor = System.Drawing.SystemColors.Info
        Me.lbltotal_facturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltotal_facturas.Location = New System.Drawing.Point(239, 441)
        Me.lbltotal_facturas.Name = "lbltotal_facturas"
        Me.lbltotal_facturas.Size = New System.Drawing.Size(105, 19)
        Me.lbltotal_facturas.TabIndex = 59
        Me.lbltotal_facturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotal_pagoS
        '
        Me.lbltotal_pagoS.BackColor = System.Drawing.SystemColors.Info
        Me.lbltotal_pagoS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltotal_pagoS.Location = New System.Drawing.Point(373, 441)
        Me.lbltotal_pagoS.Name = "lbltotal_pagoS"
        Me.lbltotal_pagoS.Size = New System.Drawing.Size(109, 19)
        Me.lbltotal_pagoS.TabIndex = 59
        Me.lbltotal_pagoS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(13, 428)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Guias Envio:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(129, 427)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 13)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "Prefacturas"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(239, 427)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Facturas"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(372, 427)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 13)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "Cobranza"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(578, 427)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Cuenta Corriente "
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPGUIAS)
        Me.TabControl1.Controls.Add(Me.TPPREFAC)
        Me.TabControl1.Controls.Add(Me.TPFACTU)
        Me.TabControl1.Controls.Add(Me.TPABO)
        Me.TabControl1.Controls.Add(Me.TPFACTURA_OFISIS)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(725, 311)
        Me.TabControl1.TabIndex = 61
        '
        'TPGUIAS
        '
        Me.TPGUIAS.BackColor = System.Drawing.SystemColors.Info
        Me.TPGUIAS.Controls.Add(Me.Lab_Nro_guia_envio)
        Me.TPGUIAS.Controls.Add(Me.Label18)
        Me.TPGUIAS.Controls.Add(Me.DGVGUIAS)
        Me.TPGUIAS.Location = New System.Drawing.Point(4, 22)
        Me.TPGUIAS.Name = "TPGUIAS"
        Me.TPGUIAS.Padding = New System.Windows.Forms.Padding(3)
        Me.TPGUIAS.Size = New System.Drawing.Size(717, 285)
        Me.TPGUIAS.TabIndex = 1
        Me.TPGUIAS.Text = "Guias"
        Me.TPGUIAS.UseVisualStyleBackColor = True
        '
        'Lab_Nro_guia_envio
        '
        Me.Lab_Nro_guia_envio.AutoSize = True
        Me.Lab_Nro_guia_envio.BackColor = System.Drawing.Color.Transparent
        Me.Lab_Nro_guia_envio.ForeColor = System.Drawing.Color.Black
        Me.Lab_Nro_guia_envio.Location = New System.Drawing.Point(287, 9)
        Me.Lab_Nro_guia_envio.Name = "Lab_Nro_guia_envio"
        Me.Lab_Nro_guia_envio.Size = New System.Drawing.Size(0, 13)
        Me.Lab_Nro_guia_envio.TabIndex = 97
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(6, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(262, 15)
        Me.Label18.TabIndex = 97
        Me.Label18.Text = "Guías Pendiente por Facturar y/o Pre-Facturar :"
        '
        'DGVGUIAS
        '
        Me.DGVGUIAS.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVGUIAS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVGUIAS.ContextMenuStrip = Me.CMS_cargofactura
        Me.DGVGUIAS.Location = New System.Drawing.Point(2, 30)
        Me.DGVGUIAS.Name = "DGVGUIAS"
        Me.DGVGUIAS.Size = New System.Drawing.Size(714, 255)
        Me.DGVGUIAS.TabIndex = 61
        '
        'TPPREFAC
        '
        Me.TPPREFAC.BackColor = System.Drawing.SystemColors.Info
        Me.TPPREFAC.Controls.Add(Me.Lab_pendiente_x_facturar)
        Me.TPPREFAC.Controls.Add(Me.Label19)
        Me.TPPREFAC.Controls.Add(Me.DGVPREFACTURAS)
        Me.TPPREFAC.Location = New System.Drawing.Point(4, 22)
        Me.TPPREFAC.Name = "TPPREFAC"
        Me.TPPREFAC.Size = New System.Drawing.Size(717, 285)
        Me.TPPREFAC.TabIndex = 4
        Me.TPPREFAC.Text = "Prefacturas"
        Me.TPPREFAC.UseVisualStyleBackColor = True
        '
        'Lab_pendiente_x_facturar
        '
        Me.Lab_pendiente_x_facturar.AutoSize = True
        Me.Lab_pendiente_x_facturar.BackColor = System.Drawing.Color.Transparent
        Me.Lab_pendiente_x_facturar.ForeColor = System.Drawing.Color.Black
        Me.Lab_pendiente_x_facturar.Location = New System.Drawing.Point(230, 10)
        Me.Lab_pendiente_x_facturar.Name = "Lab_pendiente_x_facturar"
        Me.Lab_pendiente_x_facturar.Size = New System.Drawing.Size(0, 13)
        Me.Lab_pendiente_x_facturar.TabIndex = 99
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(7, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(217, 15)
        Me.Label19.TabIndex = 98
        Me.Label19.Text = "Pre - Factura  Pendiente por Facturar : "
        '
        'DGVPREFACTURAS
        '
        Me.DGVPREFACTURAS.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVPREFACTURAS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPREFACTURAS.ContextMenuStrip = Me.CMS_cargofactura
        Me.DGVPREFACTURAS.Location = New System.Drawing.Point(3, 33)
        Me.DGVPREFACTURAS.Name = "DGVPREFACTURAS"
        Me.DGVPREFACTURAS.Size = New System.Drawing.Size(713, 252)
        Me.DGVPREFACTURAS.TabIndex = 63
        '
        'TPFACTU
        '
        Me.TPFACTU.BackColor = System.Drawing.SystemColors.Info
        Me.TPFACTU.Controls.Add(Me.Lab_pendiente_x_cobrar)
        Me.TPFACTU.Controls.Add(Me.Label20)
        Me.TPFACTU.Controls.Add(Me.DGVFACTURAS)
        Me.TPFACTU.Location = New System.Drawing.Point(4, 22)
        Me.TPFACTU.Name = "TPFACTU"
        Me.TPFACTU.Size = New System.Drawing.Size(717, 285)
        Me.TPFACTU.TabIndex = 2
        Me.TPFACTU.Text = "Facturas"
        Me.TPFACTU.UseVisualStyleBackColor = True
        '
        'Lab_pendiente_x_cobrar
        '
        Me.Lab_pendiente_x_cobrar.AutoSize = True
        Me.Lab_pendiente_x_cobrar.BackColor = System.Drawing.Color.Transparent
        Me.Lab_pendiente_x_cobrar.ForeColor = System.Drawing.Color.Black
        Me.Lab_pendiente_x_cobrar.Location = New System.Drawing.Point(184, 9)
        Me.Lab_pendiente_x_cobrar.Name = "Lab_pendiente_x_cobrar"
        Me.Lab_pendiente_x_cobrar.Size = New System.Drawing.Size(0, 13)
        Me.Lab_pendiente_x_cobrar.TabIndex = 100
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(4, 7)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(174, 15)
        Me.Label20.TabIndex = 98
        Me.Label20.Text = "Factura Pendiente por Cobrar :"
        '
        'DGVFACTURAS
        '
        Me.DGVFACTURAS.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVFACTURAS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVFACTURAS.ContextMenuStrip = Me.CMS_cargofactura
        Me.DGVFACTURAS.Location = New System.Drawing.Point(-1, 30)
        Me.DGVFACTURAS.Name = "DGVFACTURAS"
        Me.DGVFACTURAS.Size = New System.Drawing.Size(713, 255)
        Me.DGVFACTURAS.TabIndex = 64
        '
        'TPABO
        '
        Me.TPABO.BackColor = System.Drawing.SystemColors.Info
        Me.TPABO.Controls.Add(Me.Lab_cobranza)
        Me.TPABO.Controls.Add(Me.Label21)
        Me.TPABO.Controls.Add(Me.DGVPAGOS)
        Me.TPABO.Location = New System.Drawing.Point(4, 22)
        Me.TPABO.Name = "TPABO"
        Me.TPABO.Size = New System.Drawing.Size(717, 285)
        Me.TPABO.TabIndex = 3
        Me.TPABO.Text = "Cobranzas"
        Me.TPABO.UseVisualStyleBackColor = True
        '
        'Lab_cobranza
        '
        Me.Lab_cobranza.AutoSize = True
        Me.Lab_cobranza.BackColor = System.Drawing.Color.Transparent
        Me.Lab_cobranza.ForeColor = System.Drawing.Color.Black
        Me.Lab_cobranza.Location = New System.Drawing.Point(83, 7)
        Me.Lab_cobranza.Name = "Lab_cobranza"
        Me.Lab_cobranza.Size = New System.Drawing.Size(0, 13)
        Me.Lab_cobranza.TabIndex = 101
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(4, 7)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 15)
        Me.Label21.TabIndex = 98
        Me.Label21.Text = "Cobranzas :"
        '
        'DGVPAGOS
        '
        Me.DGVPAGOS.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVPAGOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPAGOS.ContextMenuStrip = Me.CMS_cargofactura
        Me.DGVPAGOS.Location = New System.Drawing.Point(-1, 27)
        Me.DGVPAGOS.Name = "DGVPAGOS"
        Me.DGVPAGOS.Size = New System.Drawing.Size(714, 262)
        Me.DGVPAGOS.TabIndex = 66
        '
        'TPFACTURA_OFISIS
        '
        Me.TPFACTURA_OFISIS.BackColor = System.Drawing.SystemColors.Info
        Me.TPFACTURA_OFISIS.Controls.Add(Me.Lab_registro_detalle)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.Label22)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.lab_nro_cta_corriente)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.lab_cuenta_corriente)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.DGV_cta_corriente_det)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.rb_ambas_ctacorriente)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.RbtLegal)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.rb_vencido_ctacorriente)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.rb_por_vencer_ctacorriente)
        Me.TPFACTURA_OFISIS.Controls.Add(Me.DGV_cuenta_corriente)
        Me.TPFACTURA_OFISIS.Location = New System.Drawing.Point(4, 22)
        Me.TPFACTURA_OFISIS.Name = "TPFACTURA_OFISIS"
        Me.TPFACTURA_OFISIS.Padding = New System.Windows.Forms.Padding(3)
        Me.TPFACTURA_OFISIS.Size = New System.Drawing.Size(717, 285)
        Me.TPFACTURA_OFISIS.TabIndex = 5
        Me.TPFACTURA_OFISIS.Text = "Cuenta Corriente"
        '
        'Lab_registro_detalle
        '
        Me.Lab_registro_detalle.BackColor = System.Drawing.Color.Transparent
        Me.Lab_registro_detalle.Location = New System.Drawing.Point(611, 181)
        Me.Lab_registro_detalle.Name = "Lab_registro_detalle"
        Me.Lab_registro_detalle.Size = New System.Drawing.Size(100, 13)
        Me.Lab_registro_detalle.TabIndex = 103
        Me.Lab_registro_detalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(614, 159)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 13)
        Me.Label22.TabIndex = 83
        Me.Label22.Text = "Nº Registro"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lab_nro_cta_corriente
        '
        Me.lab_nro_cta_corriente.AutoSize = True
        Me.lab_nro_cta_corriente.BackColor = System.Drawing.Color.Transparent
        Me.lab_nro_cta_corriente.ForeColor = System.Drawing.Color.Black
        Me.lab_nro_cta_corriente.Location = New System.Drawing.Point(107, 10)
        Me.lab_nro_cta_corriente.Name = "lab_nro_cta_corriente"
        Me.lab_nro_cta_corriente.Size = New System.Drawing.Size(0, 13)
        Me.lab_nro_cta_corriente.TabIndex = 102
        '
        'lab_cuenta_corriente
        '
        Me.lab_cuenta_corriente.AutoSize = True
        Me.lab_cuenta_corriente.BackColor = System.Drawing.Color.Transparent
        Me.lab_cuenta_corriente.ForeColor = System.Drawing.Color.Black
        Me.lab_cuenta_corriente.Location = New System.Drawing.Point(9, 8)
        Me.lab_cuenta_corriente.Name = "lab_cuenta_corriente"
        Me.lab_cuenta_corriente.Size = New System.Drawing.Size(95, 13)
        Me.lab_cuenta_corriente.TabIndex = 97
        Me.lab_cuenta_corriente.Text = "Cuenta Corriente : "
        '
        'DGV_cta_corriente_det
        '
        Me.DGV_cta_corriente_det.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGV_cta_corriente_det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_cta_corriente_det.Location = New System.Drawing.Point(1, 159)
        Me.DGV_cta_corriente_det.Name = "DGV_cta_corriente_det"
        Me.DGV_cta_corriente_det.Size = New System.Drawing.Size(610, 127)
        Me.DGV_cta_corriente_det.TabIndex = 85
        '
        'rb_ambas_ctacorriente
        '
        Me.rb_ambas_ctacorriente.AutoSize = True
        Me.rb_ambas_ctacorriente.Location = New System.Drawing.Point(654, 8)
        Me.rb_ambas_ctacorriente.Name = "rb_ambas_ctacorriente"
        Me.rb_ambas_ctacorriente.Size = New System.Drawing.Size(57, 17)
        Me.rb_ambas_ctacorriente.TabIndex = 84
        Me.rb_ambas_ctacorriente.TabStop = True
        Me.rb_ambas_ctacorriente.Text = "Ambas"
        Me.rb_ambas_ctacorriente.UseVisualStyleBackColor = True
        '
        'RbtLegal
        '
        Me.RbtLegal.AutoSize = True
        Me.RbtLegal.Location = New System.Drawing.Point(597, 8)
        Me.RbtLegal.Name = "RbtLegal"
        Me.RbtLegal.Size = New System.Drawing.Size(51, 17)
        Me.RbtLegal.TabIndex = 83
        Me.RbtLegal.TabStop = True
        Me.RbtLegal.Text = "Legal"
        Me.RbtLegal.UseVisualStyleBackColor = True
        '
        'rb_vencido_ctacorriente
        '
        Me.rb_vencido_ctacorriente.AutoSize = True
        Me.rb_vencido_ctacorriente.Location = New System.Drawing.Point(527, 8)
        Me.rb_vencido_ctacorriente.Name = "rb_vencido_ctacorriente"
        Me.rb_vencido_ctacorriente.Size = New System.Drawing.Size(64, 17)
        Me.rb_vencido_ctacorriente.TabIndex = 83
        Me.rb_vencido_ctacorriente.TabStop = True
        Me.rb_vencido_ctacorriente.Text = "Vencido"
        Me.rb_vencido_ctacorriente.UseVisualStyleBackColor = True
        '
        'rb_por_vencer_ctacorriente
        '
        Me.rb_por_vencer_ctacorriente.AutoSize = True
        Me.rb_por_vencer_ctacorriente.Location = New System.Drawing.Point(440, 8)
        Me.rb_por_vencer_ctacorriente.Name = "rb_por_vencer_ctacorriente"
        Me.rb_por_vencer_ctacorriente.Size = New System.Drawing.Size(78, 17)
        Me.rb_por_vencer_ctacorriente.TabIndex = 82
        Me.rb_por_vencer_ctacorriente.TabStop = True
        Me.rb_por_vencer_ctacorriente.Text = "Por Vencer"
        Me.rb_por_vencer_ctacorriente.UseVisualStyleBackColor = True
        '
        'DGV_cuenta_corriente
        '
        Me.DGV_cuenta_corriente.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGV_cuenta_corriente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_cuenta_corriente.Location = New System.Drawing.Point(3, 31)
        Me.DGV_cuenta_corriente.Name = "DGV_cuenta_corriente"
        Me.DGV_cuenta_corriente.Size = New System.Drawing.Size(714, 125)
        Me.DGV_cuenta_corriente.TabIndex = 0
        '
        'FrmConsulFactuEmiPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulFactuEmiPago"
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
        Me.CMS_cargofactura.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TPGUIAS.ResumeLayout(False)
        Me.TPGUIAS.PerformLayout()
        CType(Me.DGVGUIAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPPREFAC.ResumeLayout(False)
        Me.TPPREFAC.PerformLayout()
        CType(Me.DGVPREFACTURAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPFACTU.ResumeLayout(False)
        Me.TPFACTU.PerformLayout()
        CType(Me.DGVFACTURAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPABO.ResumeLayout(False)
        Me.TPABO.PerformLayout()
        CType(Me.DGVPAGOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPFACTURA_OFISIS.ResumeLayout(False)
        Me.TPFACTURA_OFISIS.PerformLayout()
        CType(Me.DGV_cta_corriente_det, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_cuenta_corriente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cbidforma_pago As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_moneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAinicioFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CMS_cargofactura As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CargoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbltotal_guias As System.Windows.Forms.Label
    Friend WithEvents lbltotal_pagoS As System.Windows.Forms.Label
    Friend WithEvents lbltotal_prefacturas As System.Windows.Forms.Label
    Friend WithEvents lbltotal_facturas As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_saldo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_linea_credito As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmb_funcionario As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lab_cta_corriente As System.Windows.Forms.Label
    Friend WithEvents lblguias As System.Windows.Forms.Label
    Friend WithEvents lblprefacturas As System.Windows.Forms.Label
    Friend WithEvents lblfacturas As System.Windows.Forms.Label
    Friend WithEvents lab_pagos As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_saldo As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipo_facturacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents RadB_Saldo As System.Windows.Forms.RadioButton
    Friend WithEvents radB_linea_credito As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TPGUIAS As System.Windows.Forms.TabPage
    Friend WithEvents DGVGUIAS As System.Windows.Forms.DataGridView
    Friend WithEvents TPPREFAC As System.Windows.Forms.TabPage
    Friend WithEvents DGVPREFACTURAS As System.Windows.Forms.DataGridView
    Friend WithEvents TPFACTU As System.Windows.Forms.TabPage
    Friend WithEvents DGVFACTURAS As System.Windows.Forms.DataGridView
    Friend WithEvents TPABO As System.Windows.Forms.TabPage
    Friend WithEvents DGVPAGOS As System.Windows.Forms.DataGridView
    Friend WithEvents TPFACTURA_OFISIS As System.Windows.Forms.TabPage
    Friend WithEvents DGV_cuenta_corriente As System.Windows.Forms.DataGridView
    Friend WithEvents Lab_funcionario As System.Windows.Forms.Label
    Friend WithEvents rb_ambas_ctacorriente As System.Windows.Forms.RadioButton
    Friend WithEvents rb_vencido_ctacorriente As System.Windows.Forms.RadioButton
    Friend WithEvents rb_por_vencer_ctacorriente As System.Windows.Forms.RadioButton
    Friend WithEvents DGV_cta_corriente_det As System.Windows.Forms.DataGridView
    Friend WithEvents rd_imprime_pantalla As System.Windows.Forms.RadioButton
    Friend WithEvents Lab_Nro_guia_envio As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Lab_pendiente_x_facturar As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Lab_pendiente_x_cobrar As System.Windows.Forms.Label
    Friend WithEvents Lab_cobranza As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lab_nro_cta_corriente As System.Windows.Forms.Label
    Friend WithEvents lab_cuenta_corriente As System.Windows.Forms.Label
    Friend WithEvents Lab_registro_detalle As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label

    Friend Shadows WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RbtLegal As System.Windows.Forms.RadioButton
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label

End Class
