<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmexcesoequipaje
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmexcesoequipaje))
        Me.cmbtipocomprobante = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtp_fec_emision = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTNRO_COMPROBANTE = New System.Windows.Forms.TextBox
        Me.TXTSER_COMPROBANTE = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Txtdni = New System.Windows.Forms.TextBox
        Me.txtpasajero = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPfec_viaje = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_ciudad_origen = New System.Windows.Forms.TextBox
        Me.cmb_agencia_origen = New System.Windows.Forms.ComboBox
        Me.cmb_agencia_origen_l = New System.Windows.Forms.Label
        Me.txthora = New System.Windows.Forms.TextBox
        Me.txtidunidadagencia = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.cmbagenciadestino = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtiWinDestino = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtpeso = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Labtarjeta = New System.Windows.Forms.Label
        Me.cmbtarjeta = New System.Windows.Forms.ComboBox
        Me.btngrabar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lbNroRegistro = New System.Windows.Forms.Label
        Me.lbNroRegistros = New System.Windows.Forms.Label
        Me.btneditar = New System.Windows.Forms.Button
        Me.btnVerData = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.dtGridViewControl_pasaje = New System.Windows.Forms.DataGridView
        Me.CMenueliminar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.grpbotones = New System.Windows.Forms.GroupBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtNroSerieDoc = New System.Windows.Forms.MaskedTextBox
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.ApellidosyNombres = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtpasajerobusqueda = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.cmbEstados = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmbDestino = New System.Windows.Forms.ComboBox
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox
        Me.cmbAgencia = New System.Windows.Forms.ComboBox
        Me.cmbOrigen = New System.Windows.Forms.ComboBox
        Me.txtidventa_pasaje = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtGridViewControl_pasaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenueliminar.SuspendLayout()
        Me.grpbotones.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(777, 497)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(772, 521)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.GroupBox7)
        Me.TabLista.Controls.Add(Me.btnNuevo)
        Me.TabLista.Controls.Add(Me.lbNroRegistro)
        Me.TabLista.Controls.Add(Me.lbNroRegistros)
        Me.TabLista.Controls.Add(Me.btneditar)
        Me.TabLista.Controls.Add(Me.btnVerData)
        Me.TabLista.Controls.Add(Me.btnImprimir)
        Me.TabLista.Controls.Add(Me.dtGridViewControl_pasaje)
        Me.TabLista.Controls.Add(Me.grpbotones)
        Me.TabLista.Size = New System.Drawing.Size(764, 492)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.txtidventa_pasaje)
        Me.TabDatos.Controls.Add(Me.btngrabar)
        Me.TabDatos.Controls.Add(Me.btnSalir)
        Me.TabDatos.Controls.Add(Me.cmbtipocomprobante)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.TXTNRO_COMPROBANTE)
        Me.TabDatos.Controls.Add(Me.TXTSER_COMPROBANTE)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        Me.TabDatos.Controls.Add(Me.GroupBox3)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Size = New System.Drawing.Size(764, 492)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(764, 492)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(764, 492)
        '
        'cmbtipocomprobante
        '
        Me.cmbtipocomprobante.FormattingEnabled = True
        Me.cmbtipocomprobante.Location = New System.Drawing.Point(120, 21)
        Me.cmbtipocomprobante.Name = "cmbtipocomprobante"
        Me.cmbtipocomprobante.Size = New System.Drawing.Size(182, 21)
        Me.cmbtipocomprobante.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(12, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 150
        Me.Label13.Text = "Dcto (F1) :"
        '
        'dtp_fec_emision
        '
        Me.dtp_fec_emision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fec_emision.Location = New System.Drawing.Point(110, 93)
        Me.dtp_fec_emision.Name = "dtp_fec_emision"
        Me.dtp_fec_emision.Size = New System.Drawing.Size(92, 20)
        Me.dtp_fec_emision.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(12, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 200
        Me.Label8.Text = "Fec Emisión  :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(6, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 230
        Me.Label5.Text = "DNI :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(398, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Condición (F11)  :"
        Me.Label4.Visible = False
        '
        'TXTNRO_COMPROBANTE
        '
        Me.TXTNRO_COMPROBANTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTNRO_COMPROBANTE.Location = New System.Drawing.Point(635, 21)
        Me.TXTNRO_COMPROBANTE.Name = "TXTNRO_COMPROBANTE"
        Me.TXTNRO_COMPROBANTE.Size = New System.Drawing.Size(109, 20)
        Me.TXTNRO_COMPROBANTE.TabIndex = 3
        '
        'TXTSER_COMPROBANTE
        '
        Me.TXTSER_COMPROBANTE.BackColor = System.Drawing.SystemColors.Info
        Me.TXTSER_COMPROBANTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTSER_COMPROBANTE.Location = New System.Drawing.Point(591, 21)
        Me.TXTSER_COMPROBANTE.Name = "TXTSER_COMPROBANTE"
        Me.TXTSER_COMPROBANTE.ReadOnly = True
        Me.TXTSER_COMPROBANTE.Size = New System.Drawing.Size(42, 20)
        Me.TXTSER_COMPROBANTE.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txtdni)
        Me.GroupBox1.Controls.Add(Me.txtpasajero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(749, 41)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        '
        'Txtdni
        '
        Me.Txtdni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtdni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtdni.Location = New System.Drawing.Point(97, 13)
        Me.Txtdni.MaxLength = 8
        Me.Txtdni.Name = "Txtdni"
        Me.Txtdni.Size = New System.Drawing.Size(93, 20)
        Me.Txtdni.TabIndex = 10
        '
        'txtpasajero
        '
        Me.txtpasajero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpasajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpasajero.Location = New System.Drawing.Point(497, 13)
        Me.txtpasajero.MaxLength = 60
        Me.txtpasajero.Name = "txtpasajero"
        Me.txtpasajero.Size = New System.Drawing.Size(240, 20)
        Me.txtpasajero.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(411, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 240
        Me.Label3.Text = "Pasajero :"
        '
        'DTPfec_viaje
        '
        Me.DTPfec_viaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfec_viaje.Location = New System.Drawing.Point(372, 91)
        Me.DTPfec_viaje.Name = "DTPfec_viaje"
        Me.DTPfec_viaje.Size = New System.Drawing.Size(86, 20)
        Me.DTPfec_viaje.TabIndex = 8
        Me.DTPfec_viaje.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(282, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 210
        Me.Label9.Text = "Fec Viaje  :"
        Me.Label9.Visible = False
        '
        'txttotal
        '
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotal.Location = New System.Drawing.Point(270, 39)
        Me.txttotal.MaxLength = 30
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(107, 20)
        Me.txttotal.TabIndex = 14
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(270, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 270
        Me.Label15.Text = "Total :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txt_ciudad_origen)
        Me.GroupBox3.Controls.Add(Me.cmb_agencia_origen)
        Me.GroupBox3.Controls.Add(Me.cmb_agencia_origen_l)
        Me.GroupBox3.Controls.Add(Me.txthora)
        Me.GroupBox3.Controls.Add(Me.txtidunidadagencia)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.dtp_fec_emision)
        Me.GroupBox3.Controls.Add(Me.cmbagenciadestino)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtiWinDestino)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.DTPfec_viaje)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(748, 126)
        Me.GroupBox3.TabIndex = 50
        Me.GroupBox3.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(388, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 13)
        Me.Label10.TabIndex = 242
        Me.Label10.Text = "Ciudad Origen : "
        '
        'txt_ciudad_origen
        '
        Me.txt_ciudad_origen.BackColor = System.Drawing.SystemColors.Info
        Me.txt_ciudad_origen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ciudad_origen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ciudad_origen.Location = New System.Drawing.Point(496, 38)
        Me.txt_ciudad_origen.MaxLength = 60
        Me.txt_ciudad_origen.Name = "txt_ciudad_origen"
        Me.txt_ciudad_origen.ReadOnly = True
        Me.txt_ciudad_origen.Size = New System.Drawing.Size(240, 20)
        Me.txt_ciudad_origen.TabIndex = 241
        '
        'cmb_agencia_origen
        '
        Me.cmb_agencia_origen.FormattingEnabled = True
        Me.cmb_agencia_origen.Location = New System.Drawing.Point(112, 38)
        Me.cmb_agencia_origen.Name = "cmb_agencia_origen"
        Me.cmb_agencia_origen.Size = New System.Drawing.Size(182, 21)
        Me.cmb_agencia_origen.TabIndex = 201
        '
        'cmb_agencia_origen_l
        '
        Me.cmb_agencia_origen_l.AutoSize = True
        Me.cmb_agencia_origen_l.BackColor = System.Drawing.Color.Transparent
        Me.cmb_agencia_origen_l.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_agencia_origen_l.ForeColor = System.Drawing.Color.Maroon
        Me.cmb_agencia_origen_l.Location = New System.Drawing.Point(5, 40)
        Me.cmb_agencia_origen_l.Name = "cmb_agencia_origen_l"
        Me.cmb_agencia_origen_l.Size = New System.Drawing.Size(102, 13)
        Me.cmb_agencia_origen_l.TabIndex = 222
        Me.cmb_agencia_origen_l.Text = "Agencia Origen :"
        '
        'txthora
        '
        Me.txthora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txthora.Location = New System.Drawing.Point(583, 93)
        Me.txthora.Name = "txthora"
        Me.txthora.Size = New System.Drawing.Size(42, 20)
        Me.txthora.TabIndex = 9
        Me.txthora.Visible = False
        '
        'txtidunidadagencia
        '
        Me.txtidunidadagencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidunidadagencia.Location = New System.Drawing.Point(110, 64)
        Me.txtidunidadagencia.MaxLength = 4
        Me.txtidunidadagencia.Name = "txtidunidadagencia"
        Me.txtidunidadagencia.Size = New System.Drawing.Size(42, 20)
        Me.txtidunidadagencia.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(490, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 220
        Me.Label11.Text = "Hora Salida :"
        Me.Label11.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Maroon
        Me.Label27.Location = New System.Drawing.Point(3, 70)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(101, 13)
        Me.Label27.TabIndex = 170
        Me.Label27.Text = "Ciudad Destino :"
        '
        'cmbagenciadestino
        '
        Me.cmbagenciadestino.FormattingEnabled = True
        Me.cmbagenciadestino.Location = New System.Drawing.Point(583, 66)
        Me.cmbagenciadestino.Name = "cmbagenciadestino"
        Me.cmbagenciadestino.Size = New System.Drawing.Size(153, 21)
        Me.cmbagenciadestino.TabIndex = 6
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Maroon
        Me.Label25.Location = New System.Drawing.Point(493, 70)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 190
        Me.Label25.Text = "Ag. Dest :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(491, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Documento :"
        '
        'txtiWinDestino
        '
        Me.txtiWinDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiWinDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtiWinDestino.Location = New System.Drawing.Point(300, 66)
        Me.txtiWinDestino.MaxLength = 30
        Me.txtiWinDestino.Name = "txtiWinDestino"
        Me.txtiWinDestino.Size = New System.Drawing.Size(158, 20)
        Me.txtiWinDestino.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(203, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Destino (F10) :"
        '
        'txtpeso
        '
        Me.txtpeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpeso.Location = New System.Drawing.Point(147, 39)
        Me.txtpeso.MaxLength = 30
        Me.txtpeso.Name = "txtpeso"
        Me.txtpeso.Size = New System.Drawing.Size(107, 20)
        Me.txtpeso.TabIndex = 13
        Me.txtpeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtpeso.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(147, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 260
        Me.Label6.Text = "Peso  :"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(9, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 250
        Me.Label7.Text = "Cantidad :"
        '
        'txtcantidad
        '
        Me.txtcantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantidad.Location = New System.Drawing.Point(9, 37)
        Me.txtcantidad.MaxLength = 30
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(107, 20)
        Me.txtcantidad.TabIndex = 12
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Labtarjeta)
        Me.GroupBox2.Controls.Add(Me.cmbtarjeta)
        Me.GroupBox2.Controls.Add(Me.txtpeso)
        Me.GroupBox2.Controls.Add(Me.txtcantidad)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txttotal)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 180)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(750, 67)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        '
        'Labtarjeta
        '
        Me.Labtarjeta.AutoSize = True
        Me.Labtarjeta.BackColor = System.Drawing.Color.Transparent
        Me.Labtarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labtarjeta.ForeColor = System.Drawing.Color.Maroon
        Me.Labtarjeta.Location = New System.Drawing.Point(500, 18)
        Me.Labtarjeta.Name = "Labtarjeta"
        Me.Labtarjeta.Size = New System.Drawing.Size(59, 13)
        Me.Labtarjeta.TabIndex = 334
        Me.Labtarjeta.Text = "Tarjeta : "
        '
        'cmbtarjeta
        '
        Me.cmbtarjeta.FormattingEnabled = True
        Me.cmbtarjeta.Location = New System.Drawing.Point(498, 36)
        Me.cmbtarjeta.Name = "cmbtarjeta"
        Me.cmbtarjeta.Size = New System.Drawing.Size(220, 21)
        Me.cmbtarjeta.TabIndex = 333
        '
        'btngrabar
        '
        Me.btngrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btngrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngrabar.ForeColor = System.Drawing.Color.Maroon
        Me.btngrabar.Location = New System.Drawing.Point(477, 263)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(84, 23)
        Me.btngrabar.TabIndex = 100
        Me.btngrabar.Text = "Grabar (F5)"
        Me.btngrabar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Maroon
        Me.btnSalir.Location = New System.Drawing.Point(584, 263)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(84, 23)
        Me.btnSalir.TabIndex = 110
        Me.btnSalir.Text = "Salir (Esc)"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lbNroRegistro
        '
        Me.lbNroRegistro.AutoSize = True
        Me.lbNroRegistro.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistro.Location = New System.Drawing.Point(732, 411)
        Me.lbNroRegistro.Name = "lbNroRegistro"
        Me.lbNroRegistro.Size = New System.Drawing.Size(14, 13)
        Me.lbNroRegistro.TabIndex = 48
        Me.lbNroRegistro.Text = "0"
        '
        'lbNroRegistros
        '
        Me.lbNroRegistros.AutoSize = True
        Me.lbNroRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistros.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistros.Location = New System.Drawing.Point(697, 389)
        Me.lbNroRegistros.Name = "lbNroRegistros"
        Me.lbNroRegistros.Size = New System.Drawing.Size(58, 13)
        Me.lbNroRegistros.TabIndex = 49
        Me.lbNroRegistros.Text = "Nro Reg."
        '
        'btneditar
        '
        Me.btneditar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btneditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneditar.Location = New System.Drawing.Point(684, 130)
        Me.btneditar.Name = "btneditar"
        Me.btneditar.Size = New System.Drawing.Size(72, 26)
        Me.btneditar.TabIndex = 47
        Me.btneditar.Text = "&Editar"
        Me.btneditar.UseVisualStyleBackColor = False
        '
        'btnVerData
        '
        Me.btnVerData.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnVerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerData.Location = New System.Drawing.Point(684, 162)
        Me.btnVerData.Name = "btnVerData"
        Me.btnVerData.Size = New System.Drawing.Size(72, 26)
        Me.btnVerData.TabIndex = 45
        Me.btnVerData.Text = "&Ver Data"
        Me.btnVerData.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Location = New System.Drawing.Point(684, 194)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(72, 26)
        Me.btnImprimir.TabIndex = 46
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'dtGridViewControl_pasaje
        '
        Me.dtGridViewControl_pasaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtGridViewControl_pasaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViewControl_pasaje.ContextMenuStrip = Me.CMenueliminar
        Me.dtGridViewControl_pasaje.Location = New System.Drawing.Point(3, 85)
        Me.dtGridViewControl_pasaje.MultiSelect = False
        Me.dtGridViewControl_pasaje.Name = "dtGridViewControl_pasaje"
        Me.dtGridViewControl_pasaje.ReadOnly = True
        Me.dtGridViewControl_pasaje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtGridViewControl_pasaje.Size = New System.Drawing.Size(672, 378)
        Me.dtGridViewControl_pasaje.TabIndex = 43
        Me.dtGridViewControl_pasaje.VirtualMode = True
        '
        'CMenueliminar
        '
        Me.CMenueliminar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.CMenueliminar.Name = "CMenueliminar"
        Me.CMenueliminar.Size = New System.Drawing.Size(122, 48)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Location = New System.Drawing.Point(7, 345)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(72, 26)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'grpbotones
        '
        Me.grpbotones.BackColor = System.Drawing.Color.Transparent
        Me.grpbotones.Controls.Add(Me.btnCerrar)
        Me.grpbotones.Location = New System.Drawing.Point(678, 85)
        Me.grpbotones.Name = "grpbotones"
        Me.grpbotones.Size = New System.Drawing.Size(82, 377)
        Me.grpbotones.TabIndex = 50
        Me.grpbotones.TabStop = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Location = New System.Drawing.Point(684, 101)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 26)
        Me.btnNuevo.TabIndex = 44
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.txtNroSerieDoc)
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
        Me.GroupBox7.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(758, 82)
        Me.GroupBox7.TabIndex = 51
        Me.GroupBox7.TabStop = False
        '
        'txtNroSerieDoc
        '
        Me.txtNroSerieDoc.Location = New System.Drawing.Point(322, 56)
        Me.txtNroSerieDoc.Mask = "000-0000000"
        Me.txtNroSerieDoc.Name = "txtNroSerieDoc"
        Me.txtNroSerieDoc.ResetOnPrompt = False
        Me.txtNroSerieDoc.Size = New System.Drawing.Size(106, 20)
        Me.txtNroSerieDoc.TabIndex = 42
        Me.txtNroSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(322, 33)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(106, 20)
        Me.dtFechaFin.TabIndex = 41
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
        'txtidventa_pasaje
        '
        Me.txtidventa_pasaje.Location = New System.Drawing.Point(17, 260)
        Me.txtidventa_pasaje.Name = "txtidventa_pasaje"
        Me.txtidventa_pasaje.Size = New System.Drawing.Size(58, 20)
        Me.txtidventa_pasaje.TabIndex = 55
        Me.txtidventa_pasaje.Visible = False
        '
        'Frmexcesoequipaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 521)
        Me.Name = "Frmexcesoequipaje"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtGridViewControl_pasaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenueliminar.ResumeLayout(False)
        Me.grpbotones.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbtipocomprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtp_fec_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTNRO_COMPROBANTE As System.Windows.Forms.TextBox
    Friend WithEvents TXTSER_COMPROBANTE As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPfec_viaje As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txtdni As System.Windows.Forms.TextBox
    Friend WithEvents txtpasajero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtiWinDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtpeso As System.Windows.Forms.TextBox
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbagenciadestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lbNroRegistro As System.Windows.Forms.Label
    Friend WithEvents lbNroRegistros As System.Windows.Forms.Label
    Friend WithEvents btneditar As System.Windows.Forms.Button
    Friend WithEvents btnVerData As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents dtGridViewControl_pasaje As System.Windows.Forms.DataGridView
    Friend WithEvents grpbotones As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNroSerieDoc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ApellidosyNombres As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtpasajerobusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents txtidventa_pasaje As System.Windows.Forms.TextBox
    Friend WithEvents txtidunidadagencia As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txthora As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CMenueliminar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Labtarjeta As System.Windows.Forms.Label
    Friend WithEvents cmbtarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_agencia_origen_l As System.Windows.Forms.Label
    Friend WithEvents cmb_agencia_origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_ciudad_origen As System.Windows.Forms.TextBox

End Class
