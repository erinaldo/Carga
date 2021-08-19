<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulguiasPendfact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsulguiasPendfact))
        Me.cmbtipofacturacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadBConsguiasinfacturar = New System.Windows.Forms.RadioButton()
        Me.Radbguiasinprefacturar1 = New System.Windows.Forms.RadioButton()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        Me.dgvguiosenvio = New System.Windows.Forms.DataGridView()
        Me.Dtpfechasta = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dtpfecdesde = New System.Windows.Forms.DateTimePicker()
        Me.Radbguiasprefactura1 = New System.Windows.Forms.RadioButton()
        Me.Radbprefactura = New System.Windows.Forms.RadioButton()
        Me.cmbtiporeporte = New System.Windows.Forms.ComboBox()
        Me.labtipo_reporte = New System.Windows.Forms.Label()
        Me.cmbfuncionario = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_subcuenta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox()
        Me.txt_tot_total = New System.Windows.Forms.TextBox()
        Me.txt_tot_igv = New System.Windows.Forms.TextBox()
        Me.txt_tot_peso = New System.Windows.Forms.TextBox()
        Me.Txt_tot_volumen = New System.Windows.Forms.TextBox()
        Me.txt_tot_sub_total = New System.Windows.Forms.TextBox()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboTipoProducto = New System.Windows.Forms.ComboBox()
        Me.rbtSinFacturar = New System.Windows.Forms.RadioButton()
        Me.chkDetalle = New System.Windows.Forms.CheckBox()
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
        CType(Me.dgvguiosenvio, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.dgvguiosenvio)
        Me.Panel.Location = New System.Drawing.Point(6, 136)
        Me.Panel.Size = New System.Drawing.Size(720, 298)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.chkDetalle)
        Me.TabLista.Controls.Add(Me.cboTipoProducto)
        Me.TabLista.Controls.Add(Me.Label22)
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.Label14)
        Me.TabLista.Controls.Add(Me.Label13)
        Me.TabLista.Controls.Add(Me.Label12)
        Me.TabLista.Controls.Add(Me.Label11)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.txt_tot_sub_total)
        Me.TabLista.Controls.Add(Me.Txt_tot_volumen)
        Me.TabLista.Controls.Add(Me.txt_tot_peso)
        Me.TabLista.Controls.Add(Me.txt_tot_igv)
        Me.TabLista.Controls.Add(Me.txt_tot_total)
        Me.TabLista.Controls.Add(Me.Label8)
        Me.TabLista.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.TabLista.Controls.Add(Me.Label7)
        Me.TabLista.Controls.Add(Me.cmb_subcuenta)
        Me.TabLista.Controls.Add(Me.Label6)
        Me.TabLista.Controls.Add(Me.cmbfuncionario)
        Me.TabLista.Controls.Add(Me.labtipo_reporte)
        Me.TabLista.Controls.Add(Me.cmbtiporeporte)
        Me.TabLista.Controls.Add(Me.rbtSinFacturar)
        Me.TabLista.Controls.Add(Me.Radbprefactura)
        Me.TabLista.Controls.Add(Me.Radbguiasprefactura1)
        Me.TabLista.Controls.Add(Me.Dtpfecdesde)
        Me.TabLista.Controls.Add(Me.Label5)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.Dtpfechasta)
        Me.TabLista.Controls.Add(Me.BtnFiltrar)
        Me.TabLista.Controls.Add(Me.txtidpersona)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.Radbguiasinprefacturar1)
        Me.TabLista.Controls.Add(Me.txtCodigoCliente)
        Me.TabLista.Controls.Add(Me.cmbtipofacturacion)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.RadBConsguiasinfacturar)
        Me.TabLista.Controls.SetChildIndex(Me.RadBConsguiasinfacturar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbtipofacturacion, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtCodigoCliente, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Radbguiasinprefacturar1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtidpersona, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.BtnFiltrar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Dtpfechasta, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Dtpfecdesde, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Radbguiasprefactura1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Radbprefactura, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rbtSinFacturar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbtiporeporte, 0)
        Me.TabLista.Controls.SetChildIndex(Me.labtipo_reporte, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbfuncionario, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmb_subcuenta, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CBIDUNIDAD_AGENCIA, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CBIDUNIDAD_AGENCIA_DESTINO, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_total, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_igv, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_peso, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Txt_tot_volumen, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_sub_total, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label11, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label13, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label22, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cboTipoProducto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.chkDetalle, 0)
        '
        'cmbtipofacturacion
        '
        Me.cmbtipofacturacion.FormattingEnabled = True
        Me.cmbtipofacturacion.Location = New System.Drawing.Point(90, 10)
        Me.cmbtipofacturacion.Name = "cmbtipofacturacion"
        Me.cmbtipofacturacion.Size = New System.Drawing.Size(179, 21)
        Me.cmbtipofacturacion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(-6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo facturación :"
        '
        'RadBConsguiasinfacturar
        '
        Me.RadBConsguiasinfacturar.AutoSize = True
        Me.RadBConsguiasinfacturar.BackColor = System.Drawing.Color.Transparent
        Me.RadBConsguiasinfacturar.Location = New System.Drawing.Point(4, 2)
        Me.RadBConsguiasinfacturar.Name = "RadBConsguiasinfacturar"
        Me.RadBConsguiasinfacturar.Size = New System.Drawing.Size(86, 17)
        Me.RadBConsguiasinfacturar.TabIndex = 3
        Me.RadBConsguiasinfacturar.TabStop = True
        Me.RadBConsguiasinfacturar.Text = "Consolidado "
        Me.RadBConsguiasinfacturar.UseVisualStyleBackColor = False
        Me.RadBConsguiasinfacturar.Visible = False
        '
        'Radbguiasinprefacturar1
        '
        Me.Radbguiasinprefacturar1.AutoSize = True
        Me.Radbguiasinprefacturar1.BackColor = System.Drawing.Color.Transparent
        Me.Radbguiasinprefacturar1.Location = New System.Drawing.Point(280, 88)
        Me.Radbguiasinprefacturar1.Name = "Radbguiasinprefacturar1"
        Me.Radbguiasinprefacturar1.Size = New System.Drawing.Size(120, 17)
        Me.Radbguiasinprefacturar1.TabIndex = 7
        Me.Radbguiasinprefacturar1.TabStop = True
        Me.Radbguiasinprefacturar1.Text = "Guía sin Prefacturar"
        Me.Radbguiasinprefacturar1.UseVisualStyleBackColor = False
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(90, 35)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(179, 20)
        Me.txtCodigoCliente.TabIndex = 4
        '
        'txtidpersona
        '
        Me.txtidpersona.Location = New System.Drawing.Point(327, 35)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(313, 20)
        Me.txtidpersona.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(4, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Código cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(277, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Cliente :"
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.BackColor = System.Drawing.Color.Moccasin
        Me.BtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Maroon
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFiltrar.Location = New System.Drawing.Point(655, 23)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(71, 28)
        Me.BtnFiltrar.TabIndex = 11
        Me.BtnFiltrar.Text = "&Filtrar"
        Me.BtnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnFiltrar.UseVisualStyleBackColor = False
        '
        'dgvguiosenvio
        '
        Me.dgvguiosenvio.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvguiosenvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvguiosenvio.Location = New System.Drawing.Point(0, 5)
        Me.dgvguiosenvio.Name = "dgvguiosenvio"
        Me.dgvguiosenvio.Size = New System.Drawing.Size(720, 299)
        Me.dgvguiosenvio.TabIndex = 0
        '
        'Dtpfechasta
        '
        Me.Dtpfechasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtpfechasta.Location = New System.Drawing.Point(555, 10)
        Me.Dtpfechasta.Name = "Dtpfechasta"
        Me.Dtpfechasta.Size = New System.Drawing.Size(85, 20)
        Me.Dtpfechasta.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(496, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Hasta :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(277, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Desde : "
        '
        'Dtpfecdesde
        '
        Me.Dtpfecdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtpfecdesde.Location = New System.Drawing.Point(328, 10)
        Me.Dtpfecdesde.Name = "Dtpfecdesde"
        Me.Dtpfecdesde.Size = New System.Drawing.Size(85, 20)
        Me.Dtpfecdesde.TabIndex = 2
        '
        'Radbguiasprefactura1
        '
        Me.Radbguiasprefactura1.AutoSize = True
        Me.Radbguiasprefactura1.BackColor = System.Drawing.Color.Transparent
        Me.Radbguiasprefactura1.Location = New System.Drawing.Point(402, 88)
        Me.Radbguiasprefactura1.Name = "Radbguiasprefactura1"
        Me.Radbguiasprefactura1.Size = New System.Drawing.Size(113, 17)
        Me.Radbguiasprefactura1.TabIndex = 8
        Me.Radbguiasprefactura1.TabStop = True
        Me.Radbguiasprefactura1.Text = "Guía Prefacturada"
        Me.Radbguiasprefactura1.UseVisualStyleBackColor = False
        '
        'Radbprefactura
        '
        Me.Radbprefactura.AutoSize = True
        Me.Radbprefactura.BackColor = System.Drawing.Color.Transparent
        Me.Radbprefactura.Location = New System.Drawing.Point(515, 88)
        Me.Radbprefactura.Name = "Radbprefactura"
        Me.Radbprefactura.Size = New System.Drawing.Size(100, 17)
        Me.Radbprefactura.TabIndex = 9
        Me.Radbprefactura.TabStop = True
        Me.Radbprefactura.Text = "Guía Facturada"
        Me.Radbprefactura.UseVisualStyleBackColor = False
        '
        'cmbtiporeporte
        '
        Me.cmbtiporeporte.FormattingEnabled = True
        Me.cmbtiporeporte.Location = New System.Drawing.Point(90, 84)
        Me.cmbtiporeporte.Name = "cmbtiporeporte"
        Me.cmbtiporeporte.Size = New System.Drawing.Size(179, 21)
        Me.cmbtiporeporte.TabIndex = 6
        '
        'labtipo_reporte
        '
        Me.labtipo_reporte.AutoSize = True
        Me.labtipo_reporte.BackColor = System.Drawing.Color.Transparent
        Me.labtipo_reporte.Location = New System.Drawing.Point(6, 87)
        Me.labtipo_reporte.Name = "labtipo_reporte"
        Me.labtipo_reporte.Size = New System.Drawing.Size(78, 13)
        Me.labtipo_reporte.TabIndex = 17
        Me.labtipo_reporte.Text = "Tipo Reporte : "
        '
        'cmbfuncionario
        '
        Me.cmbfuncionario.FormattingEnabled = True
        Me.cmbfuncionario.Location = New System.Drawing.Point(90, 60)
        Me.cmbfuncionario.Name = "cmbfuncionario"
        Me.cmbfuncionario.Size = New System.Drawing.Size(179, 21)
        Me.cmbfuncionario.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(16, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Funcionario :"
        '
        'cmb_subcuenta
        '
        Me.cmb_subcuenta.FormattingEnabled = True
        Me.cmb_subcuenta.Location = New System.Drawing.Point(355, 59)
        Me.cmb_subcuenta.Name = "cmb_subcuenta"
        Me.cmb_subcuenta.Size = New System.Drawing.Size(285, 21)
        Me.cmb_subcuenta.TabIndex = 106
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(279, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Sub Cuenta : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(279, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Destino:"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(326, 109)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(156, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 110
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(43, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Origen:"
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(91, 109)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(178, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 108
        '
        'txt_tot_total
        '
        Me.txt_tot_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_total.Location = New System.Drawing.Point(631, 440)
        Me.txt_tot_total.Name = "txt_tot_total"
        Me.txt_tot_total.ReadOnly = True
        Me.txt_tot_total.Size = New System.Drawing.Size(96, 20)
        Me.txt_tot_total.TabIndex = 112
        Me.txt_tot_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tot_igv
        '
        Me.txt_tot_igv.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_igv.Location = New System.Drawing.Point(503, 440)
        Me.txt_tot_igv.Name = "txt_tot_igv"
        Me.txt_tot_igv.ReadOnly = True
        Me.txt_tot_igv.Size = New System.Drawing.Size(96, 20)
        Me.txt_tot_igv.TabIndex = 113
        Me.txt_tot_igv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tot_peso
        '
        Me.txt_tot_peso.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_peso.Location = New System.Drawing.Point(66, 440)
        Me.txt_tot_peso.MaxLength = 12
        Me.txt_tot_peso.Name = "txt_tot_peso"
        Me.txt_tot_peso.ReadOnly = True
        Me.txt_tot_peso.Size = New System.Drawing.Size(96, 20)
        Me.txt_tot_peso.TabIndex = 114
        Me.txt_tot_peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_tot_volumen
        '
        Me.Txt_tot_volumen.BackColor = System.Drawing.SystemColors.Info
        Me.Txt_tot_volumen.Location = New System.Drawing.Point(223, 440)
        Me.Txt_tot_volumen.MaxLength = 12
        Me.Txt_tot_volumen.Name = "Txt_tot_volumen"
        Me.Txt_tot_volumen.ReadOnly = True
        Me.Txt_tot_volumen.Size = New System.Drawing.Size(96, 20)
        Me.Txt_tot_volumen.TabIndex = 115
        Me.Txt_tot_volumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tot_sub_total
        '
        Me.txt_tot_sub_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_sub_total.Location = New System.Drawing.Point(375, 440)
        Me.txt_tot_sub_total.Name = "txt_tot_sub_total"
        Me.txt_tot_sub_total.ReadOnly = True
        Me.txt_tot_sub_total.Size = New System.Drawing.Size(96, 20)
        Me.txt_tot_sub_total.TabIndex = 116
        Me.txt_tot_sub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(6, 443)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Tot. Peso : "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(165, 443)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Tot. Vol. : "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(319, 443)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "Sub Tot. : "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(474, 443)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Igv : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(600, 443)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 121
        Me.Label14.Text = "Tot :"
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(633, 114)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 122
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(489, 112)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(50, 13)
        Me.Label22.TabIndex = 123
        Me.Label22.Text = "Producto"
        '
        'cboTipoProducto
        '
        Me.cboTipoProducto.FormattingEnabled = True
        Me.cboTipoProducto.Location = New System.Drawing.Point(544, 109)
        Me.cboTipoProducto.Name = "cboTipoProducto"
        Me.cboTipoProducto.Size = New System.Drawing.Size(130, 21)
        Me.cboTipoProducto.TabIndex = 124
        '
        'rbtSinFacturar
        '
        Me.rbtSinFacturar.AutoSize = True
        Me.rbtSinFacturar.BackColor = System.Drawing.Color.Transparent
        Me.rbtSinFacturar.Location = New System.Drawing.Point(618, 88)
        Me.rbtSinFacturar.Name = "rbtSinFacturar"
        Me.rbtSinFacturar.Size = New System.Drawing.Size(107, 17)
        Me.rbtSinFacturar.TabIndex = 9
        Me.rbtSinFacturar.TabStop = True
        Me.rbtSinFacturar.Text = "Guía sin Facturar"
        Me.rbtSinFacturar.UseVisualStyleBackColor = False
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.Enabled = False
        Me.chkDetalle.Location = New System.Drawing.Point(663, 61)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(59, 17)
        Me.chkDetalle.TabIndex = 125
        Me.chkDetalle.Text = "Detalle"
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'FrmConsulguiasPendfact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmConsulguiasPendfact"
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
        CType(Me.dgvguiosenvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbtipofacturacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadBConsguiasinfacturar As System.Windows.Forms.RadioButton
    Friend WithEvents Radbguiasinprefacturar1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents dgvguiosenvio As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dtpfechasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Radbprefactura As System.Windows.Forms.RadioButton
    Friend WithEvents Radbguiasprefactura1 As System.Windows.Forms.RadioButton
    Friend WithEvents Dtpfecdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents labtipo_reporte As System.Windows.Forms.Label
    Friend WithEvents cmbtiporeporte As System.Windows.Forms.ComboBox
    Friend WithEvents cmbfuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_subcuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_sub_total As System.Windows.Forms.TextBox
    Friend WithEvents Txt_tot_volumen As System.Windows.Forms.TextBox
    Friend WithEvents txt_tot_peso As System.Windows.Forms.TextBox
    Friend WithEvents txt_tot_igv As System.Windows.Forms.TextBox
    Friend WithEvents txt_tot_total As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents cboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents rbtSinFacturar As System.Windows.Forms.RadioButton
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox
End Class
