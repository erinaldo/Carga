<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrefacturacion
    Inherits INTEGRACION.frmBaseVentas

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrefacturacion))
        Me.txtserfactura_act = New System.Windows.Forms.TextBox()
        Me.txtnrofactura_actual = New System.Windows.Forms.TextBox()
        Me.txtrazon_social = New System.Windows.Forms.TextBox()
        Me.txtruc = New System.Windows.Forms.TextBox()
        Me.txtnro_nota_cred = New System.Windows.Forms.TextBox()
        Me.txtserie_nota_cred = New System.Windows.Forms.TextBox()
        Me.txtnro_factura_new = New System.Windows.Forms.TextBox()
        Me.txtserie_factura_new = New System.Windows.Forms.TextBox()
        Me.txtigv = New System.Windows.Forms.TextBox()
        Me.txtsub_total = New System.Windows.Forms.TextBox()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_fecha_emision = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtEspecial = New System.Windows.Forms.RadioButton()
        Me.rbtCredito = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpfecha_notacredito = New System.Windows.Forms.DateTimePicker()
        Me.dtpfecha_factura_new = New System.Windows.Forms.DateTimePicker()
        Me.gb = New System.Windows.Forms.GroupBox()
        Me.cboOperacion = New System.Windows.Forms.ComboBox()
        Me.btnTipoDocumentoCliente = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CBIDTIPO_NOTA_CREDI = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.rbrefac = New System.Windows.Forms.RadioButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rbdife = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtigv_nc = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsub_total_nc = New System.Windows.Forms.TextBox()
        Me.txttotal_nc = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtigv_new = New System.Windows.Forms.TextBox()
        Me.txtsubtotal_new = New System.Windows.Forms.TextBox()
        Me.txttotal_new = New System.Windows.Forms.TextBox()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtGridViewControl_refactura = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbNroRegistro = New System.Windows.Forms.Label()
        Me.lbNroRegistros = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnVerData = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grpbotones = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtNroSerieDoc = New System.Windows.Forms.TextBox()
        Me.txtidfactura = New System.Windows.Forms.TextBox()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gb.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dtGridViewControl_refactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grpbotones.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lbNroRegistro)
        Me.TabLista.Controls.Add(Me.lbNroRegistros)
        Me.TabLista.Controls.Add(Me.grpbotones)
        Me.TabLista.Controls.Add(Me.dtGridViewControl_refactura)
        Me.TabLista.Controls.Add(Me.Label24)
        Me.TabLista.Controls.Add(Me.dtFechaFin)
        Me.TabLista.Controls.Add(Me.dtFechaInicio)
        Me.TabLista.Controls.Add(Me.btnBuscar)
        Me.TabLista.Controls.Add(Me.Label20)
        Me.TabLista.Controls.Add(Me.Label21)
        Me.TabLista.Controls.Add(Me.Label31)
        Me.TabLista.Controls.Add(Me.cmbUsuarios)
        Me.TabLista.Controls.Add(Me.GroupBox5)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.txtidfactura)
        Me.TabDatos.Controls.Add(Me.btngrabar)
        Me.TabDatos.Controls.Add(Me.btnSalir)
        Me.TabDatos.Controls.Add(Me.Label5)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Controls.Add(Me.dtp_fecha_emision)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.txtruc)
        Me.TabDatos.Controls.Add(Me.txtrazon_social)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        Me.TabDatos.Controls.Add(Me.gb)
        Me.TabDatos.Controls.Add(Me.GroupBox4)
        '
        'txtserfactura_act
        '
        Me.txtserfactura_act.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtserfactura_act.Location = New System.Drawing.Point(63, 37)
        Me.txtserfactura_act.MaxLength = 4
        Me.txtserfactura_act.Name = "txtserfactura_act"
        Me.txtserfactura_act.Size = New System.Drawing.Size(43, 20)
        Me.txtserfactura_act.TabIndex = 0
        '
        'txtnrofactura_actual
        '
        Me.txtnrofactura_actual.Location = New System.Drawing.Point(174, 38)
        Me.txtnrofactura_actual.MaxLength = 7
        Me.txtnrofactura_actual.Name = "txtnrofactura_actual"
        Me.txtnrofactura_actual.Size = New System.Drawing.Size(100, 20)
        Me.txtnrofactura_actual.TabIndex = 1
        '
        'txtrazon_social
        '
        Me.txtrazon_social.BackColor = System.Drawing.SystemColors.Info
        Me.txtrazon_social.Location = New System.Drawing.Point(116, 118)
        Me.txtrazon_social.Name = "txtrazon_social"
        Me.txtrazon_social.ReadOnly = True
        Me.txtrazon_social.Size = New System.Drawing.Size(222, 20)
        Me.txtrazon_social.TabIndex = 2
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.SystemColors.Info
        Me.txtruc.Location = New System.Drawing.Point(383, 118)
        Me.txtruc.MaxLength = 11
        Me.txtruc.Name = "txtruc"
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(84, 20)
        Me.txtruc.TabIndex = 3
        '
        'txtnro_nota_cred
        '
        Me.txtnro_nota_cred.BackColor = System.Drawing.SystemColors.Info
        Me.txtnro_nota_cred.Location = New System.Drawing.Point(174, 67)
        Me.txtnro_nota_cred.MaxLength = 7
        Me.txtnro_nota_cred.Name = "txtnro_nota_cred"
        Me.txtnro_nota_cred.ReadOnly = True
        Me.txtnro_nota_cred.Size = New System.Drawing.Size(100, 20)
        Me.txtnro_nota_cred.TabIndex = 5
        '
        'txtserie_nota_cred
        '
        Me.txtserie_nota_cred.BackColor = System.Drawing.SystemColors.Info
        Me.txtserie_nota_cred.Location = New System.Drawing.Point(63, 66)
        Me.txtserie_nota_cred.MaxLength = 3
        Me.txtserie_nota_cred.Name = "txtserie_nota_cred"
        Me.txtserie_nota_cred.ReadOnly = True
        Me.txtserie_nota_cred.Size = New System.Drawing.Size(43, 20)
        Me.txtserie_nota_cred.TabIndex = 4
        '
        'txtnro_factura_new
        '
        Me.txtnro_factura_new.BackColor = System.Drawing.SystemColors.Info
        Me.txtnro_factura_new.Location = New System.Drawing.Point(174, 18)
        Me.txtnro_factura_new.MaxLength = 7
        Me.txtnro_factura_new.Name = "txtnro_factura_new"
        Me.txtnro_factura_new.ReadOnly = True
        Me.txtnro_factura_new.Size = New System.Drawing.Size(100, 20)
        Me.txtnro_factura_new.TabIndex = 7
        '
        'txtserie_factura_new
        '
        Me.txtserie_factura_new.BackColor = System.Drawing.SystemColors.Info
        Me.txtserie_factura_new.Location = New System.Drawing.Point(63, 16)
        Me.txtserie_factura_new.MaxLength = 3
        Me.txtserie_factura_new.Name = "txtserie_factura_new"
        Me.txtserie_factura_new.ReadOnly = True
        Me.txtserie_factura_new.Size = New System.Drawing.Size(43, 20)
        Me.txtserie_factura_new.TabIndex = 6
        '
        'txtigv
        '
        Me.txtigv.BackColor = System.Drawing.SystemColors.Info
        Me.txtigv.Location = New System.Drawing.Point(197, 63)
        Me.txtigv.Name = "txtigv"
        Me.txtigv.ReadOnly = True
        Me.txtigv.Size = New System.Drawing.Size(77, 20)
        Me.txtigv.TabIndex = 9
        Me.txtigv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsub_total
        '
        Me.txtsub_total.BackColor = System.Drawing.SystemColors.Info
        Me.txtsub_total.Location = New System.Drawing.Point(63, 63)
        Me.txtsub_total.Name = "txtsub_total"
        Me.txtsub_total.ReadOnly = True
        Me.txtsub_total.Size = New System.Drawing.Size(77, 20)
        Me.txtsub_total.TabIndex = 8
        Me.txtsub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.Info
        Me.txttotal.Location = New System.Drawing.Point(363, 63)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(77, 20)
        Me.txttotal.TabIndex = 10
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(26, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Serie :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(118, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Número :"
        '
        'dtp_fecha_emision
        '
        Me.dtp_fecha_emision.CalendarForeColor = System.Drawing.SystemColors.Info
        Me.dtp_fecha_emision.Enabled = False
        Me.dtp_fecha_emision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_emision.Location = New System.Drawing.Point(383, 46)
        Me.dtp_fecha_emision.Name = "dtp_fecha_emision"
        Me.dtp_fecha_emision.Size = New System.Drawing.Size(84, 20)
        Me.dtp_fecha_emision.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(295, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Fec. Emisión :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbtEspecial)
        Me.GroupBox1.Controls.Add(Me.rbtCredito)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtigv)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtsub_total)
        Me.GroupBox1.Controls.Add(Me.txttotal)
        Me.GroupBox1.Controls.Add(Me.txtnrofactura_actual)
        Me.GroupBox1.Controls.Add(Me.txtserfactura_act)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(20, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(463, 88)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Factura actual : "
        '
        'rbtEspecial
        '
        Me.rbtEspecial.AutoSize = True
        Me.rbtEspecial.Location = New System.Drawing.Point(82, 16)
        Me.rbtEspecial.Name = "rbtEspecial"
        Me.rbtEspecial.Size = New System.Drawing.Size(50, 17)
        Me.rbtEspecial.TabIndex = 23
        Me.rbtEspecial.Text = "Otros"
        Me.rbtEspecial.UseVisualStyleBackColor = True
        '
        'rbtCredito
        '
        Me.rbtCredito.AutoSize = True
        Me.rbtCredito.Checked = True
        Me.rbtCredito.Location = New System.Drawing.Point(7, 16)
        Me.rbtCredito.Name = "rbtCredito"
        Me.rbtCredito.Size = New System.Drawing.Size(58, 17)
        Me.rbtCredito.TabIndex = 23
        Me.rbtCredito.TabStop = True
        Me.rbtCredito.Text = "Crédito"
        Me.rbtCredito.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(284, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Total : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(157, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "IGV : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(5, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Sub total : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(31, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Razón Social : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(344, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "RUC : "
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(20, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(463, 45)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'dtpfecha_notacredito
        '
        Me.dtpfecha_notacredito.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha_notacredito.Location = New System.Drawing.Point(363, 65)
        Me.dtpfecha_notacredito.Name = "dtpfecha_notacredito"
        Me.dtpfecha_notacredito.Size = New System.Drawing.Size(84, 20)
        Me.dtpfecha_notacredito.TabIndex = 20
        '
        'dtpfecha_factura_new
        '
        Me.dtpfecha_factura_new.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha_factura_new.Location = New System.Drawing.Point(363, 15)
        Me.dtpfecha_factura_new.Name = "dtpfecha_factura_new"
        Me.dtpfecha_factura_new.Size = New System.Drawing.Size(84, 20)
        Me.dtpfecha_factura_new.TabIndex = 21
        '
        'gb
        '
        Me.gb.BackColor = System.Drawing.Color.Transparent
        Me.gb.Controls.Add(Me.cboOperacion)
        Me.gb.Controls.Add(Me.btnTipoDocumentoCliente)
        Me.gb.Controls.Add(Me.Label23)
        Me.gb.Controls.Add(Me.CBIDTIPO_NOTA_CREDI)
        Me.gb.Controls.Add(Me.Label22)
        Me.gb.Controls.Add(Me.rtb)
        Me.gb.Controls.Add(Me.rbrefac)
        Me.gb.Controls.Add(Me.Label19)
        Me.gb.Controls.Add(Me.rbdife)
        Me.gb.Controls.Add(Me.Label11)
        Me.gb.Controls.Add(Me.Label18)
        Me.gb.Controls.Add(Me.Label9)
        Me.gb.Controls.Add(Me.dtpfecha_notacredito)
        Me.gb.Controls.Add(Me.txtigv_nc)
        Me.gb.Controls.Add(Me.Label25)
        Me.gb.Controls.Add(Me.Label10)
        Me.gb.Controls.Add(Me.txtsub_total_nc)
        Me.gb.Controls.Add(Me.txtnro_nota_cred)
        Me.gb.Controls.Add(Me.txtserie_nota_cred)
        Me.gb.Controls.Add(Me.txttotal_nc)
        Me.gb.ForeColor = System.Drawing.Color.Maroon
        Me.gb.Location = New System.Drawing.Point(20, 148)
        Me.gb.Name = "gb"
        Me.gb.Size = New System.Drawing.Size(463, 187)
        Me.gb.TabIndex = 22
        Me.gb.TabStop = False
        Me.gb.Text = "Nota Crédito"
        '
        'cboOperacion
        '
        Me.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperacion.FormattingEnabled = True
        Me.cboOperacion.Location = New System.Drawing.Point(96, 16)
        Me.cboOperacion.Name = "cboOperacion"
        Me.cboOperacion.Size = New System.Drawing.Size(350, 21)
        Me.cboOperacion.TabIndex = 105
        '
        'btnTipoDocumentoCliente
        '
        Me.btnTipoDocumentoCliente.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnTipoDocumentoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTipoDocumentoCliente.Image = CType(resources.GetObject("btnTipoDocumentoCliente.Image"), System.Drawing.Image)
        Me.btnTipoDocumentoCliente.Location = New System.Drawing.Point(424, 43)
        Me.btnTipoDocumentoCliente.Name = "btnTipoDocumentoCliente"
        Me.btnTipoDocumentoCliente.Size = New System.Drawing.Size(22, 20)
        Me.btnTipoDocumentoCliente.TabIndex = 104
        Me.btnTipoDocumentoCliente.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Maroon
        Me.Label23.Location = New System.Drawing.Point(171, 45)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 30
        Me.Label23.Text = "Tipo NC:"
        '
        'CBIDTIPO_NOTA_CREDI
        '
        Me.CBIDTIPO_NOTA_CREDI.FormattingEnabled = True
        Me.CBIDTIPO_NOTA_CREDI.Location = New System.Drawing.Point(226, 42)
        Me.CBIDTIPO_NOTA_CREDI.Name = "CBIDTIPO_NOTA_CREDI"
        Me.CBIDTIPO_NOTA_CREDI.Size = New System.Drawing.Size(192, 21)
        Me.CBIDTIPO_NOTA_CREDI.TabIndex = 29
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Maroon
        Me.Label22.Location = New System.Drawing.Point(285, 162)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 28
        Me.Label22.Text = "Total : "
        '
        'rtb
        '
        Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtb.Location = New System.Drawing.Point(63, 92)
        Me.rtb.Name = "rtb"
        Me.rtb.Size = New System.Drawing.Size(383, 59)
        Me.rtb.TabIndex = 27
        Me.rtb.Text = ""
        '
        'rbrefac
        '
        Me.rbrefac.AutoSize = True
        Me.rbrefac.Location = New System.Drawing.Point(6, 43)
        Me.rbrefac.Name = "rbrefac"
        Me.rbrefac.Size = New System.Drawing.Size(92, 17)
        Me.rbrefac.TabIndex = 26
        Me.rbrefac.Text = "Refacturación"
        Me.rbrefac.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Maroon
        Me.Label19.Location = New System.Drawing.Point(158, 162)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "IGV : "
        '
        'rbdife
        '
        Me.rbdife.AutoSize = True
        Me.rbdife.Checked = True
        Me.rbdife.Location = New System.Drawing.Point(99, 43)
        Me.rbdife.Name = "rbdife"
        Me.rbdife.Size = New System.Drawing.Size(73, 17)
        Me.rbdife.TabIndex = 25
        Me.rbdife.TabStop = True
        Me.rbdife.Text = "Diferencia"
        Me.rbdife.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(280, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Fec. Emisión :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(6, 162)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Sub total : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(118, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Número :"
        '
        'txtigv_nc
        '
        Me.txtigv_nc.BackColor = System.Drawing.SystemColors.Info
        Me.txtigv_nc.Location = New System.Drawing.Point(198, 159)
        Me.txtigv_nc.Name = "txtigv_nc"
        Me.txtigv_nc.ReadOnly = True
        Me.txtigv_nc.Size = New System.Drawing.Size(77, 20)
        Me.txtigv_nc.TabIndex = 24
        Me.txtigv_nc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Maroon
        Me.Label25.Location = New System.Drawing.Point(11, 22)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(62, 13)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "Operación :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(11, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Serie :"
        '
        'txtsub_total_nc
        '
        Me.txtsub_total_nc.BackColor = System.Drawing.Color.White
        Me.txtsub_total_nc.Location = New System.Drawing.Point(64, 159)
        Me.txtsub_total_nc.Name = "txtsub_total_nc"
        Me.txtsub_total_nc.Size = New System.Drawing.Size(77, 20)
        Me.txtsub_total_nc.TabIndex = 23
        Me.txtsub_total_nc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotal_nc
        '
        Me.txttotal_nc.BackColor = System.Drawing.SystemColors.Info
        Me.txttotal_nc.Location = New System.Drawing.Point(370, 161)
        Me.txttotal_nc.Name = "txttotal_nc"
        Me.txttotal_nc.ReadOnly = True
        Me.txttotal_nc.Size = New System.Drawing.Size(77, 20)
        Me.txttotal_nc.TabIndex = 25
        Me.txttotal_nc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtigv_new)
        Me.GroupBox4.Controls.Add(Me.txtsubtotal_new)
        Me.GroupBox4.Controls.Add(Me.dtpfecha_factura_new)
        Me.GroupBox4.Controls.Add(Me.txttotal_new)
        Me.GroupBox4.Controls.Add(Me.txtnro_factura_new)
        Me.GroupBox4.Controls.Add(Me.txtserie_factura_new)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(20, 341)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(463, 72)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Factura Nueva"
        Me.GroupBox4.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(284, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Total : "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(118, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Número :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(157, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "IGV : "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(280, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Fec. Emisión :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(5, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Sub total : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(11, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Serie :"
        '
        'txtigv_new
        '
        Me.txtigv_new.BackColor = System.Drawing.SystemColors.Info
        Me.txtigv_new.Location = New System.Drawing.Point(197, 44)
        Me.txtigv_new.Name = "txtigv_new"
        Me.txtigv_new.ReadOnly = True
        Me.txtigv_new.Size = New System.Drawing.Size(77, 20)
        Me.txtigv_new.TabIndex = 24
        Me.txtigv_new.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsubtotal_new
        '
        Me.txtsubtotal_new.BackColor = System.Drawing.Color.White
        Me.txtsubtotal_new.Location = New System.Drawing.Point(63, 44)
        Me.txtsubtotal_new.Name = "txtsubtotal_new"
        Me.txtsubtotal_new.Size = New System.Drawing.Size(77, 20)
        Me.txtsubtotal_new.TabIndex = 23
        Me.txtsubtotal_new.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotal_new
        '
        Me.txttotal_new.BackColor = System.Drawing.SystemColors.Info
        Me.txttotal_new.Location = New System.Drawing.Point(369, 46)
        Me.txttotal_new.Name = "txttotal_new"
        Me.txttotal_new.ReadOnly = True
        Me.txttotal_new.Size = New System.Drawing.Size(77, 20)
        Me.txttotal_new.TabIndex = 25
        Me.txttotal_new.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btngrabar
        '
        Me.btngrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btngrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngrabar.ForeColor = System.Drawing.Color.Maroon
        Me.btngrabar.Location = New System.Drawing.Point(276, 419)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(84, 29)
        Me.btngrabar.TabIndex = 101
        Me.btngrabar.Text = "Grabar (F5)"
        Me.btngrabar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Maroon
        Me.btnSalir.Location = New System.Drawing.Point(383, 419)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(84, 29)
        Me.btnSalir.TabIndex = 102
        Me.btnSalir.Text = "Salir (Esc)"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(107, 35)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(90, 20)
        Me.dtFechaFin.TabIndex = 50
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(107, 9)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(90, 20)
        Me.dtFechaInicio.TabIndex = 49
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(550, 34)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 22)
        Me.btnBuscar.TabIndex = 48
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Maroon
        Me.Label20.Location = New System.Drawing.Point(380, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 13)
        Me.Label20.TabIndex = 47
        Me.Label20.Text = "Factura :"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.Location = New System.Drawing.Point(18, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 46
        Me.Label21.Text = "Fecha Fin"
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.ForeColor = System.Drawing.Color.Maroon
        Me.Label31.Location = New System.Drawing.Point(18, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 13)
        Me.Label31.TabIndex = 45
        Me.Label31.Text = "Fecha Inicio"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.BackColor = System.Drawing.SystemColors.Info
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(438, 9)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(238, 21)
        Me.cmbUsuarios.TabIndex = 44
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Maroon
        Me.Label24.Location = New System.Drawing.Point(380, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 13)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "Usuario"
        '
        'dtGridViewControl_refactura
        '
        Me.dtGridViewControl_refactura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtGridViewControl_refactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViewControl_refactura.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dtGridViewControl_refactura.GridColor = System.Drawing.SystemColors.Info
        Me.dtGridViewControl_refactura.Location = New System.Drawing.Point(6, 71)
        Me.dtGridViewControl_refactura.MultiSelect = False
        Me.dtGridViewControl_refactura.Name = "dtGridViewControl_refactura"
        Me.dtGridViewControl_refactura.ReadOnly = True
        Me.dtGridViewControl_refactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtGridViewControl_refactura.Size = New System.Drawing.Size(598, 377)
        Me.dtGridViewControl_refactura.TabIndex = 53
        Me.dtGridViewControl_refactura.VirtualMode = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 48)
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        Me.EliminarToolStripMenuItem.Visible = False
        '
        'lbNroRegistro
        '
        Me.lbNroRegistro.AutoSize = True
        Me.lbNroRegistro.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistro.Location = New System.Drawing.Point(669, 397)
        Me.lbNroRegistro.Name = "lbNroRegistro"
        Me.lbNroRegistro.Size = New System.Drawing.Size(14, 13)
        Me.lbNroRegistro.TabIndex = 58
        Me.lbNroRegistro.Text = "0"
        '
        'lbNroRegistros
        '
        Me.lbNroRegistros.AutoSize = True
        Me.lbNroRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistros.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistros.Location = New System.Drawing.Point(634, 375)
        Me.lbNroRegistros.Name = "lbNroRegistros"
        Me.lbNroRegistros.Size = New System.Drawing.Size(58, 13)
        Me.lbNroRegistros.TabIndex = 59
        Me.lbNroRegistros.Text = "Nro Reg."
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.ForeColor = System.Drawing.Color.Maroon
        Me.btnImprimir.Location = New System.Drawing.Point(8, 86)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(72, 26)
        Me.btnImprimir.TabIndex = 56
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        Me.btnImprimir.Visible = False
        '
        'btnVerData
        '
        Me.btnVerData.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnVerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerData.ForeColor = System.Drawing.Color.Maroon
        Me.btnVerData.Location = New System.Drawing.Point(8, 54)
        Me.btnVerData.Name = "btnVerData"
        Me.btnVerData.Size = New System.Drawing.Size(72, 26)
        Me.btnVerData.TabIndex = 55
        Me.btnVerData.Text = "&Ver Data"
        Me.btnVerData.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.ForeColor = System.Drawing.Color.Maroon
        Me.btnCerrar.Location = New System.Drawing.Point(8, 351)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(72, 26)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.Text = "&Salir"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.ForeColor = System.Drawing.Color.Maroon
        Me.btnNuevo.Location = New System.Drawing.Point(8, 22)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 26)
        Me.btnNuevo.TabIndex = 54
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'grpbotones
        '
        Me.grpbotones.BackColor = System.Drawing.Color.Transparent
        Me.grpbotones.Controls.Add(Me.btnCerrar)
        Me.grpbotones.Controls.Add(Me.btnVerData)
        Me.grpbotones.Controls.Add(Me.btnNuevo)
        Me.grpbotones.Controls.Add(Me.btnImprimir)
        Me.grpbotones.Location = New System.Drawing.Point(610, 65)
        Me.grpbotones.Name = "grpbotones"
        Me.grpbotones.Size = New System.Drawing.Size(86, 383)
        Me.grpbotones.TabIndex = 60
        Me.grpbotones.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtNroSerieDoc)
        Me.GroupBox5.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(690, 66)
        Me.GroupBox5.TabIndex = 61
        Me.GroupBox5.TabStop = False
        '
        'txtNroSerieDoc
        '
        Me.txtNroSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroSerieDoc.Location = New System.Drawing.Point(432, 37)
        Me.txtNroSerieDoc.MaxLength = 15
        Me.txtNroSerieDoc.Name = "txtNroSerieDoc"
        Me.txtNroSerieDoc.Size = New System.Drawing.Size(106, 20)
        Me.txtNroSerieDoc.TabIndex = 0
        '
        'txtidfactura
        '
        Me.txtidfactura.Location = New System.Drawing.Point(43, 423)
        Me.txtidfactura.Name = "txtidfactura"
        Me.txtidfactura.Size = New System.Drawing.Size(100, 20)
        Me.txtidfactura.TabIndex = 103
        Me.txtidfactura.Visible = False
        '
        'frmrefacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(716, 490)
        Me.Name = "frmrefacturacion"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb.ResumeLayout(False)
        Me.gb.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dtGridViewControl_refactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grpbotones.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtserfactura_act As System.Windows.Forms.TextBox
    Friend WithEvents txtnrofactura_actual As System.Windows.Forms.TextBox
    Friend WithEvents txtnro_factura_new As System.Windows.Forms.TextBox
    Friend WithEvents txtserie_factura_new As System.Windows.Forms.TextBox
    Friend WithEvents txtnro_nota_cred As System.Windows.Forms.TextBox
    Friend WithEvents txtserie_nota_cred As System.Windows.Forms.TextBox
    Friend WithEvents txtruc As System.Windows.Forms.TextBox
    Friend WithEvents txtrazon_social As System.Windows.Forms.TextBox
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents txtigv As System.Windows.Forms.TextBox
    Friend WithEvents txtsub_total As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpfecha_factura_new As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfecha_notacredito As System.Windows.Forms.DateTimePicker
    Friend WithEvents gb As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtGridViewControl_refactura As System.Windows.Forms.DataGridView
    Friend WithEvents lbNroRegistro As System.Windows.Forms.Label
    Friend WithEvents lbNroRegistros As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnVerData As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents grpbotones As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtidfactura As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtigv_new As System.Windows.Forms.TextBox
    Friend WithEvents txtsubtotal_new As System.Windows.Forms.TextBox
    Friend WithEvents txttotal_new As System.Windows.Forms.TextBox
    Friend WithEvents rbdife As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents rbrefac As System.Windows.Forms.RadioButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtigv_nc As System.Windows.Forms.TextBox
    Friend WithEvents txtsub_total_nc As System.Windows.Forms.TextBox
    Friend WithEvents txttotal_nc As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CBIDTIPO_NOTA_CREDI As System.Windows.Forms.ComboBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnTipoDocumentoCliente As System.Windows.Forms.Button
    Friend WithEvents cboOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents rbtEspecial As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCredito As System.Windows.Forms.RadioButton
    Friend WithEvents txtNroSerieDoc As System.Windows.Forms.TextBox

End Class
