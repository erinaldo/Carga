<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmventapasaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmventapasaje))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTNRO_COMPROBANTE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtiWinDestino = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtpasajero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbcondicion = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txtdni = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtruc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtrazon_social = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DTPfec_viaje = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_fec_emision = New System.Windows.Forms.DateTimePicker()
        Me.txtedad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txthora = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtnroasiento = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbtipocomprobante = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtigv = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_fec_viaje_tmp = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cmbformapago = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Labtarjeta = New System.Windows.Forms.Label()
        Me.cmbtarjeta = New System.Windows.Forms.ComboBox()
        Me.txtmemo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtidunidadagorigen = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbagencia_origen = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtidunidadagencia = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtcuenta = New System.Windows.Forms.TextBox()
        Me.labcodcuenta = New System.Windows.Forms.Label()
        Me.cmbagenciadestino = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtdctoreferencia_serie = New System.Windows.Forms.TextBox()
        Me.txtdctoreferencia_nrodcto = New System.Windows.Forms.TextBox()
        Me.Labboleto_ref = New System.Windows.Forms.Label()
        Me.TXTSER_COMPROBANTE = New System.Windows.Forms.TextBox()
        Me.txtiWinorigen = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtNroSerieDoc = New System.Windows.Forms.TextBox()
        Me.RBCaja = New System.Windows.Forms.RadioButton()
        Me.RBPasaje = New System.Windows.Forms.RadioButton()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ApellidosyNombres = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtpasajerobusqueda = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.dtGridViewControl_pasaje = New System.Windows.Forms.DataGridView()
        Me.CMenuS_eliminar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CambiarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnVerData = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btneditar = New System.Windows.Forms.Button()
        Me.lbNroRegistro = New System.Windows.Forms.Label()
        Me.lbNroRegistros = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grpbotones = New System.Windows.Forms.GroupBox()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.txtidventa_pasaje = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Labrazon_social_cta = New System.Windows.Forms.Label()
        Me.txtrazon_social_cuenta = New System.Windows.Forms.TextBox()
        Me.chk_es_fecha_abierta = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dtGridViewControl_pasaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuS_eliminar.SuspendLayout()
        Me.grpbotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(780, 497)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(775, 521)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lbNroRegistro)
        Me.TabLista.Controls.Add(Me.lbNroRegistros)
        Me.TabLista.Controls.Add(Me.btneditar)
        Me.TabLista.Controls.Add(Me.btnImprimir)
        Me.TabLista.Controls.Add(Me.btnVerData)
        Me.TabLista.Controls.Add(Me.btnNuevo)
        Me.TabLista.Controls.Add(Me.dtGridViewControl_pasaje)
        Me.TabLista.Controls.Add(Me.GroupBox7)
        Me.TabLista.Controls.Add(Me.grpbotones)
        Me.TabLista.Size = New System.Drawing.Size(767, 492)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.chk_es_fecha_abierta)
        Me.TabDatos.Controls.Add(Me.txtrazon_social_cuenta)
        Me.TabDatos.Controls.Add(Me.Labrazon_social_cta)
        Me.TabDatos.Controls.Add(Me.Label19)
        Me.TabDatos.Controls.Add(Me.txtidventa_pasaje)
        Me.TabDatos.Controls.Add(Me.btngrabar)
        Me.TabDatos.Controls.Add(Me.btnSalir)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.GroupBox3)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        Me.TabDatos.Size = New System.Drawing.Size(767, 492)
        Me.TabDatos.Text = "0"
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(767, 492)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(767, 492)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(295, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Dcto : "
        '
        'TXTNRO_COMPROBANTE
        '
        Me.TXTNRO_COMPROBANTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTNRO_COMPROBANTE.Location = New System.Drawing.Point(411, 41)
        Me.TXTNRO_COMPROBANTE.MaxLength = 7
        Me.TXTNRO_COMPROBANTE.Name = "TXTNRO_COMPROBANTE"
        Me.TXTNRO_COMPROBANTE.Size = New System.Drawing.Size(97, 20)
        Me.TXTNRO_COMPROBANTE.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(250, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Destino (F10) :"
        '
        'txtiWinDestino
        '
        Me.txtiWinDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiWinDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtiWinDestino.Location = New System.Drawing.Point(350, 69)
        Me.txtiWinDestino.MaxLength = 5
        Me.txtiWinDestino.Name = "txtiWinDestino"
        Me.txtiWinDestino.Size = New System.Drawing.Size(158, 20)
        Me.txtiWinDestino.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(223, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "Pasajero :"
        '
        'txtpasajero
        '
        Me.txtpasajero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpasajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpasajero.Location = New System.Drawing.Point(316, 10)
        Me.txtpasajero.MaxLength = 50
        Me.txtpasajero.Name = "txtpasajero"
        Me.txtpasajero.Size = New System.Drawing.Size(285, 20)
        Me.txtpasajero.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(6, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Condición (F11)  :"
        '
        'cmbcondicion
        '
        Me.cmbcondicion.FormattingEnabled = True
        Me.cmbcondicion.Location = New System.Drawing.Point(116, 95)
        Me.cmbcondicion.Name = "cmbcondicion"
        Me.cmbcondicion.Size = New System.Drawing.Size(156, 21)
        Me.cmbcondicion.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(8, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "DNI :"
        '
        'Txtdni
        '
        Me.Txtdni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtdni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtdni.Location = New System.Drawing.Point(99, 10)
        Me.Txtdni.MaxLength = 11
        Me.Txtdni.Name = "Txtdni"
        Me.Txtdni.Size = New System.Drawing.Size(93, 20)
        Me.Txtdni.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(7, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 240
        Me.Label6.Text = "RUC (F2) :"
        '
        'txtruc
        '
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Location = New System.Drawing.Point(100, 33)
        Me.txtruc.MaxLength = 11
        Me.txtruc.Name = "txtruc"
        Me.txtruc.Size = New System.Drawing.Size(92, 20)
        Me.txtruc.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(223, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 250
        Me.Label7.Text = "Razón Social : "
        '
        'txtrazon_social
        '
        Me.txtrazon_social.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrazon_social.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazon_social.Location = New System.Drawing.Point(316, 33)
        Me.txtrazon_social.MaxLength = 50
        Me.txtrazon_social.Name = "txtrazon_social"
        Me.txtrazon_social.Size = New System.Drawing.Size(285, 20)
        Me.txtrazon_social.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(273, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 190
        Me.Label8.Text = "Fec Emisión  :"
        '
        'DTPfec_viaje
        '
        Me.DTPfec_viaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfec_viaje.Location = New System.Drawing.Point(98, 59)
        Me.DTPfec_viaje.Name = "DTPfec_viaje"
        Me.DTPfec_viaje.Size = New System.Drawing.Size(94, 20)
        Me.DTPfec_viaje.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(8, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 260
        Me.Label9.Text = "Fec Viaje  :"
        '
        'dtp_fec_emision
        '
        Me.dtp_fec_emision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fec_emision.Location = New System.Drawing.Point(363, 97)
        Me.dtp_fec_emision.Name = "dtp_fec_emision"
        Me.dtp_fec_emision.Size = New System.Drawing.Size(92, 20)
        Me.dtp_fec_emision.TabIndex = 13
        '
        'txtedad
        '
        Me.txtedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtedad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtedad.Location = New System.Drawing.Point(701, 12)
        Me.txtedad.MaxLength = 2
        Me.txtedad.Name = "txtedad"
        Me.txtedad.Size = New System.Drawing.Size(42, 20)
        Me.txtedad.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(647, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 230
        Me.Label10.Text = "Edad : "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(223, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 270
        Me.Label11.Text = "Hora Salida :"
        '
        'txthora
        '
        Me.txthora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txthora.Location = New System.Drawing.Point(316, 59)
        Me.txthora.Name = "txthora"
        Me.txthora.Size = New System.Drawing.Size(42, 20)
        Me.txthora.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(496, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 280
        Me.Label12.Text = "Asiento :"
        '
        'txtnroasiento
        '
        Me.txtnroasiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnroasiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnroasiento.Location = New System.Drawing.Point(559, 56)
        Me.txtnroasiento.MaxLength = 2
        Me.txtnroasiento.Name = "txtnroasiento"
        Me.txtnroasiento.Size = New System.Drawing.Size(42, 20)
        Me.txtnroasiento.TabIndex = 22
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(6, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Dcto (F1) :"
        '
        'cmbtipocomprobante
        '
        Me.cmbtipocomprobante.FormattingEnabled = True
        Me.cmbtipocomprobante.Location = New System.Drawing.Point(116, 42)
        Me.cmbtipocomprobante.Name = "cmbtipocomprobante"
        Me.cmbtipocomprobante.Size = New System.Drawing.Size(158, 21)
        Me.cmbtipocomprobante.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(6, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 13)
        Me.Label14.TabIndex = 290
        Me.Label14.Text = "Dscto (F8) :"
        '
        'txtdescuento
        '
        Me.txtdescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescuento.Location = New System.Drawing.Point(99, 12)
        Me.txtdescuento.MaxLength = 30
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(107, 20)
        Me.txtdescuento.TabIndex = 25
        '
        'txttotal
        '
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotal.Location = New System.Drawing.Point(635, 9)
        Me.txttotal.MaxLength = 10
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(107, 20)
        Me.txttotal.TabIndex = 23
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(556, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 300
        Me.Label15.Text = "Total :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(557, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 330
        Me.Label16.Text = "IGV :"
        Me.Label16.Visible = False
        '
        'txtigv
        '
        Me.txtigv.BackColor = System.Drawing.SystemColors.Info
        Me.txtigv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtigv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtigv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtigv.Location = New System.Drawing.Point(635, 63)
        Me.txtigv.MaxLength = 30
        Me.txtigv.Name = "txtigv"
        Me.txtigv.ReadOnly = True
        Me.txtigv.Size = New System.Drawing.Size(107, 20)
        Me.txtigv.TabIndex = 35
        Me.txtigv.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_fec_viaje_tmp)
        Me.GroupBox1.Controls.Add(Me.txthora)
        Me.GroupBox1.Controls.Add(Me.txtnroasiento)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.DTPfec_viaje)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtrazon_social)
        Me.GroupBox1.Controls.Add(Me.txtedad)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Txtdni)
        Me.GroupBox1.Controls.Add(Me.txtruc)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtpasajero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 150)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(758, 86)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        '
        'txt_fec_viaje_tmp
        '
        Me.txt_fec_viaje_tmp.BackColor = System.Drawing.SystemColors.Info
        Me.txt_fec_viaje_tmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fec_viaje_tmp.CausesValidation = False
        Me.txt_fec_viaje_tmp.Enabled = False
        Me.txt_fec_viaje_tmp.Location = New System.Drawing.Point(100, 58)
        Me.txt_fec_viaje_tmp.MaxLength = 4
        Me.txt_fec_viaje_tmp.Name = "txt_fec_viaje_tmp"
        Me.txt_fec_viaje_tmp.Size = New System.Drawing.Size(92, 20)
        Me.txt_fec_viaje_tmp.TabIndex = 207
        Me.txt_fec_viaje_tmp.Text = "00/00/0000"
        Me.txt_fec_viaje_tmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmbformapago)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Labtarjeta)
        Me.GroupBox2.Controls.Add(Me.cmbtarjeta)
        Me.GroupBox2.Controls.Add(Me.txtmemo)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtsubtotal)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtigv)
        Me.GroupBox2.Controls.Add(Me.txttotal)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtdescuento)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 234)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(757, 87)
        Me.GroupBox2.TabIndex = 80
        Me.GroupBox2.TabStop = False
        '
        'Cmbformapago
        '
        Me.Cmbformapago.FormattingEnabled = True
        Me.Cmbformapago.Location = New System.Drawing.Point(315, 43)
        Me.Cmbformapago.Name = "Cmbformapago"
        Me.Cmbformapago.Size = New System.Drawing.Size(151, 21)
        Me.Cmbformapago.TabIndex = 334
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(222, 46)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(86, 13)
        Me.Label33.TabIndex = 333
        Me.Label33.Text = "Forma Pago : "
        '
        'Labtarjeta
        '
        Me.Labtarjeta.AutoSize = True
        Me.Labtarjeta.BackColor = System.Drawing.Color.Transparent
        Me.Labtarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labtarjeta.ForeColor = System.Drawing.Color.Maroon
        Me.Labtarjeta.Location = New System.Drawing.Point(222, 16)
        Me.Labtarjeta.Name = "Labtarjeta"
        Me.Labtarjeta.Size = New System.Drawing.Size(59, 13)
        Me.Labtarjeta.TabIndex = 332
        Me.Labtarjeta.Text = "Tarjeta : "
        '
        'cmbtarjeta
        '
        Me.cmbtarjeta.FormattingEnabled = True
        Me.cmbtarjeta.Location = New System.Drawing.Point(315, 12)
        Me.cmbtarjeta.Name = "cmbtarjeta"
        Me.cmbtarjeta.Size = New System.Drawing.Size(151, 21)
        Me.cmbtarjeta.TabIndex = 331
        '
        'txtmemo
        '
        Me.txtmemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmemo.Location = New System.Drawing.Point(98, 39)
        Me.txtmemo.MaxLength = 30
        Me.txtmemo.Name = "txtmemo"
        Me.txtmemo.Size = New System.Drawing.Size(108, 20)
        Me.txtmemo.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(6, 41)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 310
        Me.Label18.Text = "Memo :"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtsubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubtotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsubtotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtsubtotal.Location = New System.Drawing.Point(635, 37)
        Me.txtsubtotal.MaxLength = 30
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.ReadOnly = True
        Me.txtsubtotal.Size = New System.Drawing.Size(107, 20)
        Me.txtsubtotal.TabIndex = 37
        Me.txtsubtotal.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(557, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 320
        Me.Label17.Text = "Sub Total :"
        Me.Label17.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtidunidadagorigen)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.cmbagencia_origen)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.txtidunidadagencia)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.cmbtipocomprobante)
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Controls.Add(Me.labcodcuenta)
        Me.GroupBox3.Controls.Add(Me.cmbagenciadestino)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.dtp_fec_emision)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtdctoreferencia_serie)
        Me.GroupBox3.Controls.Add(Me.txtdctoreferencia_nrodcto)
        Me.GroupBox3.Controls.Add(Me.Labboleto_ref)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtiWinDestino)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmbcondicion)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TXTSER_COMPROBANTE)
        Me.GroupBox3.Controls.Add(Me.TXTNRO_COMPROBANTE)
        Me.GroupBox3.Controls.Add(Me.txtiWinorigen)
        Me.GroupBox3.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(757, 124)
        Me.GroupBox3.TabIndex = 60
        Me.GroupBox3.TabStop = False
        '
        'txtidunidadagorigen
        '
        Me.txtidunidadagorigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidunidadagorigen.CausesValidation = False
        Me.txtidunidadagorigen.Location = New System.Drawing.Point(116, 9)
        Me.txtidunidadagorigen.MaxLength = 4
        Me.txtidunidadagorigen.Name = "txtidunidadagorigen"
        Me.txtidunidadagorigen.Size = New System.Drawing.Size(42, 20)
        Me.txtidunidadagorigen.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Maroon
        Me.Label32.Location = New System.Drawing.Point(7, 13)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(91, 13)
        Me.Label32.TabIndex = 206
        Me.Label32.Text = "Ciudad Origen:"
        '
        'cmbagencia_origen
        '
        Me.cmbagencia_origen.FormattingEnabled = True
        Me.cmbagencia_origen.Location = New System.Drawing.Point(596, 10)
        Me.cmbagencia_origen.Name = "cmbagencia_origen"
        Me.cmbagencia_origen.Size = New System.Drawing.Size(145, 21)
        Me.cmbagencia_origen.TabIndex = 3
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Maroon
        Me.Label26.Location = New System.Drawing.Point(518, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(75, 13)
        Me.Label26.TabIndex = 204
        Me.Label26.Text = "Ag. Origen :"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Maroon
        Me.Label28.Location = New System.Drawing.Point(240, 13)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(82, 13)
        Me.Label28.TabIndex = 203
        Me.Label28.Text = "Origen  (F4) :"
        '
        'txtidunidadagencia
        '
        Me.txtidunidadagencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidunidadagencia.CausesValidation = False
        Me.txtidunidadagencia.Location = New System.Drawing.Point(116, 69)
        Me.txtidunidadagencia.MaxLength = 4
        Me.txtidunidadagencia.Name = "txtidunidadagencia"
        Me.txtidunidadagencia.Size = New System.Drawing.Size(42, 20)
        Me.txtidunidadagencia.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Maroon
        Me.Label27.Location = New System.Drawing.Point(7, 73)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(97, 13)
        Me.Label27.TabIndex = 150
        Me.Label27.Text = "Código Ciudad :"
        '
        'txtcuenta
        '
        Me.txtcuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcuenta.Location = New System.Drawing.Point(609, 95)
        Me.txtcuenta.MaxLength = 11
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(132, 20)
        Me.txtcuenta.TabIndex = 14
        Me.txtcuenta.Visible = False
        '
        'labcodcuenta
        '
        Me.labcodcuenta.AutoSize = True
        Me.labcodcuenta.BackColor = System.Drawing.Color.Transparent
        Me.labcodcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labcodcuenta.ForeColor = System.Drawing.Color.Maroon
        Me.labcodcuenta.Location = New System.Drawing.Point(505, 100)
        Me.labcodcuenta.Name = "labcodcuenta"
        Me.labcodcuenta.Size = New System.Drawing.Size(82, 13)
        Me.labcodcuenta.TabIndex = 200
        Me.labcodcuenta.Text = "Ruc Cuenta :"
        Me.labcodcuenta.Visible = False
        '
        'cmbagenciadestino
        '
        Me.cmbagenciadestino.FormattingEnabled = True
        Me.cmbagenciadestino.Location = New System.Drawing.Point(596, 69)
        Me.cmbagenciadestino.Name = "cmbagenciadestino"
        Me.cmbagenciadestino.Size = New System.Drawing.Size(145, 21)
        Me.cmbagenciadestino.TabIndex = 11
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Maroon
        Me.Label25.Location = New System.Drawing.Point(526, 73)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 170
        Me.Label25.Text = "Ag. Dest :"
        '
        'txtdctoreferencia_serie
        '
        Me.txtdctoreferencia_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdctoreferencia_serie.Location = New System.Drawing.Point(596, 39)
        Me.txtdctoreferencia_serie.MaxLength = 3
        Me.txtdctoreferencia_serie.Name = "txtdctoreferencia_serie"
        Me.txtdctoreferencia_serie.Size = New System.Drawing.Size(42, 20)
        Me.txtdctoreferencia_serie.TabIndex = 7
        '
        'txtdctoreferencia_nrodcto
        '
        Me.txtdctoreferencia_nrodcto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdctoreferencia_nrodcto.Location = New System.Drawing.Point(644, 39)
        Me.txtdctoreferencia_nrodcto.MaxLength = 7
        Me.txtdctoreferencia_nrodcto.Name = "txtdctoreferencia_nrodcto"
        Me.txtdctoreferencia_nrodcto.Size = New System.Drawing.Size(97, 20)
        Me.txtdctoreferencia_nrodcto.TabIndex = 8
        '
        'Labboleto_ref
        '
        Me.Labboleto_ref.AutoSize = True
        Me.Labboleto_ref.BackColor = System.Drawing.Color.Transparent
        Me.Labboleto_ref.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labboleto_ref.ForeColor = System.Drawing.Color.Maroon
        Me.Labboleto_ref.Location = New System.Drawing.Point(520, 42)
        Me.Labboleto_ref.Name = "Labboleto_ref"
        Me.Labboleto_ref.Size = New System.Drawing.Size(70, 13)
        Me.Labboleto_ref.TabIndex = 140
        Me.Labboleto_ref.Text = "Dcto Ref  :"
        '
        'TXTSER_COMPROBANTE
        '
        Me.TXTSER_COMPROBANTE.BackColor = System.Drawing.SystemColors.Info
        Me.TXTSER_COMPROBANTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTSER_COMPROBANTE.Enabled = False
        Me.TXTSER_COMPROBANTE.Location = New System.Drawing.Point(363, 41)
        Me.TXTSER_COMPROBANTE.Name = "TXTSER_COMPROBANTE"
        Me.TXTSER_COMPROBANTE.Size = New System.Drawing.Size(42, 20)
        Me.TXTSER_COMPROBANTE.TabIndex = 5
        '
        'txtiWinorigen
        '
        Me.txtiWinorigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiWinorigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtiWinorigen.Location = New System.Drawing.Point(350, 10)
        Me.txtiWinorigen.MaxLength = 5
        Me.txtiWinorigen.Name = "txtiWinorigen"
        Me.txtiWinorigen.Size = New System.Drawing.Size(158, 20)
        Me.txtiWinorigen.TabIndex = 2
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Maroon
        Me.btnSalir.Location = New System.Drawing.Point(659, 332)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(84, 22)
        Me.btnSalir.TabIndex = 100
        Me.btnSalir.Text = "Salir (Esc)"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btngrabar
        '
        Me.btngrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btngrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngrabar.ForeColor = System.Drawing.Color.Maroon
        Me.btngrabar.Location = New System.Drawing.Point(552, 332)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(84, 22)
        Me.btngrabar.TabIndex = 24
        Me.btngrabar.Text = "Grabar (F5)"
        Me.btngrabar.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.txtNroSerieDoc)
        Me.GroupBox7.Controls.Add(Me.RBCaja)
        Me.GroupBox7.Controls.Add(Me.RBPasaje)
        Me.GroupBox7.Controls.Add(Me.dtFechaFin)
        Me.GroupBox7.Controls.Add(Me.dtFechaInicio)
        Me.GroupBox7.Controls.Add(Me.btnBuscar)
        Me.GroupBox7.Controls.Add(Me.ApellidosyNombres)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Controls.Add(Me.txtpasajerobusqueda)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Controls.Add(Me.Label29)
        Me.GroupBox7.Controls.Add(Me.Label30)
        Me.GroupBox7.Controls.Add(Me.cmbEstados)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Controls.Add(Me.cmbDestino)
        Me.GroupBox7.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox7.Controls.Add(Me.cmbAgencia)
        Me.GroupBox7.Controls.Add(Me.cmbOrigen)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox7.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(758, 82)
        Me.GroupBox7.TabIndex = 6
        Me.GroupBox7.TabStop = False
        '
        'txtNroSerieDoc
        '
        Me.txtNroSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroSerieDoc.Location = New System.Drawing.Point(322, 57)
        Me.txtNroSerieDoc.MaxLength = 13
        Me.txtNroSerieDoc.Name = "txtNroSerieDoc"
        Me.txtNroSerieDoc.Size = New System.Drawing.Size(104, 20)
        Me.txtNroSerieDoc.TabIndex = 95
        '
        'RBCaja
        '
        Me.RBCaja.AutoSize = True
        Me.RBCaja.Location = New System.Drawing.Point(628, 57)
        Me.RBCaja.Name = "RBCaja"
        Me.RBCaja.Size = New System.Drawing.Size(94, 17)
        Me.RBCaja.TabIndex = 44
        Me.RBCaja.TabStop = True
        Me.RBCaja.Text = "Recibo Caja"
        Me.RBCaja.UseVisualStyleBackColor = True
        '
        'RBPasaje
        '
        Me.RBPasaje.AutoSize = True
        Me.RBPasaje.Location = New System.Drawing.Point(510, 57)
        Me.RBPasaje.Name = "RBPasaje"
        Me.RBPasaje.Size = New System.Drawing.Size(63, 17)
        Me.RBPasaje.TabIndex = 43
        Me.RBPasaje.TabStop = True
        Me.RBPasaje.Text = "Pasaje"
        Me.RBPasaje.UseVisualStyleBackColor = True
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(322, 33)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(106, 20)
        Me.dtFechaFin.TabIndex = 42
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(322, 9)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(106, 20)
        Me.dtFechaInicio.TabIndex = 41
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(434, 54)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 22)
        Me.btnBuscar.TabIndex = 40
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'ApellidosyNombres
        '
        Me.ApellidosyNombres.AutoSize = True
        Me.ApellidosyNombres.BackColor = System.Drawing.Color.Transparent
        Me.ApellidosyNombres.Location = New System.Drawing.Point(0, 60)
        Me.ApellidosyNombres.Name = "ApellidosyNombres"
        Me.ApellidosyNombres.Size = New System.Drawing.Size(56, 13)
        Me.ApellidosyNombres.TabIndex = 39
        Me.ApellidosyNombres.Text = "Pasajero"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(234, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "Dcto. "
        '
        'txtpasajerobusqueda
        '
        Me.txtpasajerobusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpasajerobusqueda.Location = New System.Drawing.Point(61, 58)
        Me.txtpasajerobusqueda.MaxLength = 30
        Me.txtpasajerobusqueda.Name = "txtpasajerobusqueda"
        Me.txtpasajerobusqueda.Size = New System.Drawing.Size(168, 20)
        Me.txtpasajerobusqueda.TabIndex = 38
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(233, 34)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "Fecha Fin"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(0, 36)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(50, 13)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Destino"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(559, 59)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(46, 13)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "Estado"
        Me.Label23.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(449, 37)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 13)
        Me.Label24.TabIndex = 31
        Me.Label24.Text = "Usuario"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(449, 10)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 31
        Me.Label29.Text = "Agencia"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(0, 15)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 13)
        Me.Label30.TabIndex = 31
        Me.Label30.Text = "Origen"
        '
        'cmbEstados
        '
        Me.cmbEstados.BackColor = System.Drawing.SystemColors.Info
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(613, 56)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(135, 21)
        Me.cmbEstados.TabIndex = 35
        Me.cmbEstados.Visible = False
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(233, 8)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(77, 13)
        Me.Label31.TabIndex = 34
        Me.Label31.Text = "Fecha Inicio"
        '
        'cmbDestino
        '
        Me.cmbDestino.BackColor = System.Drawing.SystemColors.Info
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Location = New System.Drawing.Point(61, 33)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(168, 21)
        Me.cmbDestino.TabIndex = 30
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.BackColor = System.Drawing.SystemColors.Info
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(510, 32)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(238, 21)
        Me.cmbUsuarios.TabIndex = 29
        '
        'cmbAgencia
        '
        Me.cmbAgencia.BackColor = System.Drawing.SystemColors.Info
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(510, 7)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(238, 21)
        Me.cmbAgencia.TabIndex = 29
        '
        'cmbOrigen
        '
        Me.cmbOrigen.BackColor = System.Drawing.SystemColors.Info
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(61, 10)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(168, 21)
        Me.cmbOrigen.TabIndex = 29
        '
        'dtGridViewControl_pasaje
        '
        Me.dtGridViewControl_pasaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtGridViewControl_pasaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViewControl_pasaje.ContextMenuStrip = Me.CMenuS_eliminar
        Me.dtGridViewControl_pasaje.Location = New System.Drawing.Point(2, 86)
        Me.dtGridViewControl_pasaje.Name = "dtGridViewControl_pasaje"
        Me.dtGridViewControl_pasaje.ReadOnly = True
        Me.dtGridViewControl_pasaje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtGridViewControl_pasaje.Size = New System.Drawing.Size(672, 377)
        Me.dtGridViewControl_pasaje.TabIndex = 7
        Me.dtGridViewControl_pasaje.VirtualMode = True
        '
        'CMenuS_eliminar
        '
        Me.CMenuS_eliminar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem, Me.ToolStripSeparator1, Me.CambiarUsuarioToolStripMenuItem, Me.ToolStripSeparator2})
        Me.CMenuS_eliminar.Name = "CMenuS_eliminar"
        Me.CMenuS_eliminar.Size = New System.Drawing.Size(163, 60)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'CambiarUsuarioToolStripMenuItem
        '
        Me.CambiarUsuarioToolStripMenuItem.Name = "CambiarUsuarioToolStripMenuItem"
        Me.CambiarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CambiarUsuarioToolStripMenuItem.Text = "Cambiar Usuario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(159, 6)
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Location = New System.Drawing.Point(683, 195)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(72, 26)
        Me.btnImprimir.TabIndex = 10
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnVerData
        '
        Me.btnVerData.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnVerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerData.Location = New System.Drawing.Point(683, 163)
        Me.btnVerData.Name = "btnVerData"
        Me.btnVerData.Size = New System.Drawing.Size(72, 26)
        Me.btnVerData.TabIndex = 9
        Me.btnVerData.Text = "&Ver Data"
        Me.btnVerData.UseVisualStyleBackColor = False
        Me.btnVerData.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Location = New System.Drawing.Point(683, 102)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 26)
        Me.btnNuevo.TabIndex = 8
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btneditar
        '
        Me.btneditar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btneditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneditar.Location = New System.Drawing.Point(683, 131)
        Me.btneditar.Name = "btneditar"
        Me.btneditar.Size = New System.Drawing.Size(72, 26)
        Me.btneditar.TabIndex = 11
        Me.btneditar.Text = "&Editar"
        Me.btneditar.UseVisualStyleBackColor = False
        '
        'lbNroRegistro
        '
        Me.lbNroRegistro.AutoSize = True
        Me.lbNroRegistro.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistro.Location = New System.Drawing.Point(736, 412)
        Me.lbNroRegistro.Name = "lbNroRegistro"
        Me.lbNroRegistro.Size = New System.Drawing.Size(14, 13)
        Me.lbNroRegistro.TabIndex = 13
        Me.lbNroRegistro.Text = "0"
        '
        'lbNroRegistros
        '
        Me.lbNroRegistros.AutoSize = True
        Me.lbNroRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistros.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistros.Location = New System.Drawing.Point(701, 390)
        Me.lbNroRegistros.Name = "lbNroRegistros"
        Me.lbNroRegistros.Size = New System.Drawing.Size(58, 13)
        Me.lbNroRegistros.TabIndex = 14
        Me.lbNroRegistros.Text = "Nro Reg."
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Location = New System.Drawing.Point(8, 351)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(72, 26)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'grpbotones
        '
        Me.grpbotones.BackColor = System.Drawing.Color.Transparent
        Me.grpbotones.Controls.Add(Me.btnAnular)
        Me.grpbotones.Controls.Add(Me.btnCerrar)
        Me.grpbotones.Location = New System.Drawing.Point(677, 80)
        Me.grpbotones.Name = "grpbotones"
        Me.grpbotones.Size = New System.Drawing.Size(86, 383)
        Me.grpbotones.TabIndex = 15
        Me.grpbotones.TabStop = False
        '
        'btnAnular
        '
        Me.btnAnular.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnular.Location = New System.Drawing.Point(6, 147)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(72, 26)
        Me.btnAnular.TabIndex = 13
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'txtidventa_pasaje
        '
        Me.txtidventa_pasaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidventa_pasaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidventa_pasaje.Location = New System.Drawing.Point(124, 327)
        Me.txtidventa_pasaje.MaxLength = 2
        Me.txtidventa_pasaje.Name = "txtidventa_pasaje"
        Me.txtidventa_pasaje.Size = New System.Drawing.Size(69, 20)
        Me.txtidventa_pasaje.TabIndex = 110
        Me.txtidventa_pasaje.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Maroon
        Me.Label19.Location = New System.Drawing.Point(46, 332)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 13)
        Me.Label19.TabIndex = 340
        Me.Label19.Text = "idvtapasaje"
        Me.Label19.Visible = False
        '
        'Labrazon_social_cta
        '
        Me.Labrazon_social_cta.AutoSize = True
        Me.Labrazon_social_cta.BackColor = System.Drawing.Color.Transparent
        Me.Labrazon_social_cta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labrazon_social_cta.ForeColor = System.Drawing.Color.Maroon
        Me.Labrazon_social_cta.Location = New System.Drawing.Point(227, 134)
        Me.Labrazon_social_cta.Name = "Labrazon_social_cta"
        Me.Labrazon_social_cta.Size = New System.Drawing.Size(134, 13)
        Me.Labrazon_social_cta.TabIndex = 207
        Me.Labrazon_social_cta.Text = "Razón Social Cuenta :"
        Me.Labrazon_social_cta.Visible = False
        '
        'txtrazon_social_cuenta
        '
        Me.txtrazon_social_cuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrazon_social_cuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazon_social_cuenta.Location = New System.Drawing.Point(365, 129)
        Me.txtrazon_social_cuenta.MaxLength = 50
        Me.txtrazon_social_cuenta.Name = "txtrazon_social_cuenta"
        Me.txtrazon_social_cuenta.Size = New System.Drawing.Size(378, 20)
        Me.txtrazon_social_cuenta.TabIndex = 281
        Me.txtrazon_social_cuenta.Visible = False
        '
        'chk_es_fecha_abierta
        '
        Me.chk_es_fecha_abierta.AutoSize = True
        Me.chk_es_fecha_abierta.BackColor = System.Drawing.Color.Transparent
        Me.chk_es_fecha_abierta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_es_fecha_abierta.ForeColor = System.Drawing.Color.Maroon
        Me.chk_es_fecha_abierta.Location = New System.Drawing.Point(11, 130)
        Me.chk_es_fecha_abierta.Name = "chk_es_fecha_abierta"
        Me.chk_es_fecha_abierta.Size = New System.Drawing.Size(105, 17)
        Me.chk_es_fecha_abierta.TabIndex = 341
        Me.chk_es_fecha_abierta.Text = "Fecha Abierta"
        Me.chk_es_fecha_abierta.UseVisualStyleBackColor = False
        '
        'frmventapasaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 521)
        Me.Name = "frmventapasaje"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.dtGridViewControl_pasaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuS_eliminar.ResumeLayout(False)
        Me.grpbotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTNRO_COMPROBANTE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtiWinDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtpasajero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbcondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtruc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txtdni As System.Windows.Forms.TextBox
    Friend WithEvents DTPfec_viaje As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtrazon_social As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fec_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtedad As System.Windows.Forms.TextBox
    Friend WithEvents txtnroasiento As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txthora As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbtipocomprobante As System.Windows.Forms.ComboBox
    Friend WithEvents txtigv As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtmemo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtdctoreferencia_nrodcto As System.Windows.Forms.TextBox
    Friend WithEvents Labboleto_ref As System.Windows.Forms.Label
    Friend WithEvents TXTSER_COMPROBANTE As System.Windows.Forms.TextBox
    Friend WithEvents txtdctoreferencia_serie As System.Windows.Forms.TextBox
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ApellidosyNombres As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtpasajerobusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbagenciadestino As System.Windows.Forms.ComboBox
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents labcodcuenta As System.Windows.Forms.Label
    Friend WithEvents txtidunidadagencia As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dtGridViewControl_pasaje As System.Windows.Forms.DataGridView
    Friend WithEvents btneditar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnVerData As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lbNroRegistro As System.Windows.Forms.Label
    Friend WithEvents lbNroRegistros As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents grpbotones As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtidventa_pasaje As System.Windows.Forms.TextBox
    Friend WithEvents txtidunidadagorigen As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmbagencia_origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtiWinorigen As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents RBCaja As System.Windows.Forms.RadioButton
    Friend WithEvents RBPasaje As System.Windows.Forms.RadioButton
    Friend WithEvents CMenuS_eliminar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Labtarjeta As System.Windows.Forms.Label
    Friend WithEvents cmbtarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Cmbformapago As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CambiarUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtrazon_social_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents Labrazon_social_cta As System.Windows.Forms.Label
    Friend WithEvents chk_es_fecha_abierta As System.Windows.Forms.CheckBox
    Friend WithEvents txt_fec_viaje_tmp As System.Windows.Forms.TextBox
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents txtNroSerieDoc As System.Windows.Forms.TextBox

End Class
