<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmacionEntrega
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAgenciaDestino = New System.Windows.Forms.TextBox()
        Me.txtAgenciaOrigen = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtSubcuenta = New System.Windows.Forms.TextBox()
        Me.txtNumeroDocumento = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTipoComprobante = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvBulto = New System.Windows.Forms.DataGridView()
        Me.dgvDocumento = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFormaPago = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumeroTarjeta = New System.Windows.Forms.TextBox()
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.txtAutorizado = New System.Windows.Forms.TextBox()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDestinatario = New System.Windows.Forms.TextBox()
        Me.txtDireccionDestinatario = New System.Windows.Forms.TextBox()
        Me.txtDireccionRemitente = New System.Windows.Forms.TextBox()
        Me.txtRemitente = New System.Windows.Forms.TextBox()
        Me.grbEntrega = New System.Windows.Forms.GroupBox()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraEntrega = New System.Windows.Forms.DateTimePicker()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.cboConsignado = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtCantidadEntregar = New System.Windows.Forms.TextBox()
        Me.txtCantidadEntregada = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblCantidadEntregar = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblCantidadEntregada = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAgregarHuella = New System.Windows.Forms.Button()
        Me.picHuella = New System.Windows.Forms.PictureBox()
        Me.btnVerHuella = New System.Windows.Forms.Button()
        Me.grbHuella = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvBulto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grbEntrega.SuspendLayout()
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbHuella.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDestino)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtOrigen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAgenciaDestino)
        Me.GroupBox1.Controls.Add(Me.txtAgenciaOrigen)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.txtSubcuenta)
        Me.GroupBox1.Controls.Add(Me.txtNumeroDocumento)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNumeroComprobante)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTipoComprobante)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(733, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtDestino
        '
        Me.txtDestino.BackColor = System.Drawing.Color.White
        Me.txtDestino.Enabled = False
        Me.txtDestino.Location = New System.Drawing.Point(534, 13)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(190, 20)
        Me.txtDestino.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(467, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Destino"
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.Color.White
        Me.txtOrigen.Enabled = False
        Me.txtOrigen.Location = New System.Drawing.Point(263, 13)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(190, 20)
        Me.txtOrigen.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Origen"
        '
        'txtAgenciaDestino
        '
        Me.txtAgenciaDestino.BackColor = System.Drawing.Color.White
        Me.txtAgenciaDestino.Enabled = False
        Me.txtAgenciaDestino.Location = New System.Drawing.Point(535, 39)
        Me.txtAgenciaDestino.Name = "txtAgenciaDestino"
        Me.txtAgenciaDestino.Size = New System.Drawing.Size(190, 20)
        Me.txtAgenciaDestino.TabIndex = 1
        '
        'txtAgenciaOrigen
        '
        Me.txtAgenciaOrigen.BackColor = System.Drawing.Color.White
        Me.txtAgenciaOrigen.Enabled = False
        Me.txtAgenciaOrigen.Location = New System.Drawing.Point(263, 39)
        Me.txtAgenciaOrigen.Name = "txtAgenciaOrigen"
        Me.txtAgenciaOrigen.Size = New System.Drawing.Size(190, 20)
        Me.txtAgenciaOrigen.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(467, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ag. Destino"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(190, 89)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(263, 20)
        Me.txtCliente.TabIndex = 1
        '
        'txtSubcuenta
        '
        Me.txtSubcuenta.BackColor = System.Drawing.Color.White
        Me.txtSubcuenta.Enabled = False
        Me.txtSubcuenta.Location = New System.Drawing.Point(535, 89)
        Me.txtSubcuenta.Name = "txtSubcuenta"
        Me.txtSubcuenta.Size = New System.Drawing.Size(189, 20)
        Me.txtSubcuenta.TabIndex = 1
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.BackColor = System.Drawing.Color.White
        Me.txtNumeroDocumento.Enabled = False
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(87, 89)
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroDocumento.TabIndex = 1
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.Enabled = False
        Me.txtFecha.Location = New System.Drawing.Point(87, 39)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(201, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ag. Origen"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(467, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Subcuenta"
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.BackColor = System.Drawing.Color.White
        Me.txtNumeroComprobante.Enabled = False
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(87, 13)
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroComprobante.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Cliente"
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComprobante.ForeColor = System.Drawing.Color.Red
        Me.lblTipoComprobante.Location = New System.Drawing.Point(6, 62)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(721, 22)
        Me.lblTipoComprobante.TabIndex = 0
        Me.lblTipoComprobante.Text = "BOLETA DE VENTA"
        Me.lblTipoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº Documento"
        '
        'dgvBulto
        '
        Me.dgvBulto.Location = New System.Drawing.Point(9, 249)
        Me.dgvBulto.Name = "dgvBulto"
        Me.dgvBulto.Size = New System.Drawing.Size(274, 133)
        Me.dgvBulto.TabIndex = 23
        '
        'dgvDocumento
        '
        Me.dgvDocumento.Location = New System.Drawing.Point(288, 249)
        Me.dgvDocumento.Name = "dgvDocumento"
        Me.dgvDocumento.Size = New System.Drawing.Size(454, 133)
        Me.dgvDocumento.TabIndex = 22
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtFormaPago)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtNumeroTarjeta)
        Me.GroupBox2.Controls.Add(Me.txtTarjeta)
        Me.GroupBox2.Controls.Add(Me.txtAutorizado)
        Me.GroupBox2.Controls.Add(Me.txtDescuento)
        Me.GroupBox2.Controls.Add(Me.txtCondicion)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 181)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(734, 62)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Forma Pago"
        '
        'txtFormaPago
        '
        Me.txtFormaPago.BackColor = System.Drawing.Color.White
        Me.txtFormaPago.Enabled = False
        Me.txtFormaPago.Location = New System.Drawing.Point(87, 37)
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.Size = New System.Drawing.Size(100, 20)
        Me.txtFormaPago.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(518, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Nº Tarjeta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(518, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Autorizado"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(261, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Tarjeta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(261, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Descuento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Condición"
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.BackColor = System.Drawing.Color.White
        Me.txtNumeroTarjeta.Enabled = False
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(601, 37)
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(127, 20)
        Me.txtNumeroTarjeta.TabIndex = 1
        '
        'txtTarjeta
        '
        Me.txtTarjeta.BackColor = System.Drawing.Color.White
        Me.txtTarjeta.Enabled = False
        Me.txtTarjeta.Location = New System.Drawing.Point(341, 37)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Size = New System.Drawing.Size(110, 20)
        Me.txtTarjeta.TabIndex = 1
        '
        'txtAutorizado
        '
        Me.txtAutorizado.BackColor = System.Drawing.Color.White
        Me.txtAutorizado.Enabled = False
        Me.txtAutorizado.Location = New System.Drawing.Point(601, 12)
        Me.txtAutorizado.Name = "txtAutorizado"
        Me.txtAutorizado.Size = New System.Drawing.Size(127, 20)
        Me.txtAutorizado.TabIndex = 1
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.White
        Me.txtDescuento.Enabled = False
        Me.txtDescuento.Location = New System.Drawing.Point(341, 12)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(110, 20)
        Me.txtDescuento.TabIndex = 1
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCondicion
        '
        Me.txtCondicion.BackColor = System.Drawing.Color.White
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Location = New System.Drawing.Point(87, 12)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.Size = New System.Drawing.Size(100, 20)
        Me.txtCondicion.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtDestinatario)
        Me.GroupBox3.Controls.Add(Me.txtDireccionDestinatario)
        Me.GroupBox3.Controls.Add(Me.txtDireccionRemitente)
        Me.GroupBox3.Controls.Add(Me.txtRemitente)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 117)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(733, 64)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(373, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Destinatario"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(373, 42)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Dirección"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 42)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Dirección"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Remitente"
        '
        'txtDestinatario
        '
        Me.txtDestinatario.BackColor = System.Drawing.Color.White
        Me.txtDestinatario.Enabled = False
        Me.txtDestinatario.Location = New System.Drawing.Point(446, 13)
        Me.txtDestinatario.Name = "txtDestinatario"
        Me.txtDestinatario.Size = New System.Drawing.Size(281, 20)
        Me.txtDestinatario.TabIndex = 3
        '
        'txtDireccionDestinatario
        '
        Me.txtDireccionDestinatario.BackColor = System.Drawing.Color.White
        Me.txtDireccionDestinatario.Enabled = False
        Me.txtDireccionDestinatario.Location = New System.Drawing.Point(446, 39)
        Me.txtDireccionDestinatario.Name = "txtDireccionDestinatario"
        Me.txtDireccionDestinatario.Size = New System.Drawing.Size(281, 20)
        Me.txtDireccionDestinatario.TabIndex = 3
        '
        'txtDireccionRemitente
        '
        Me.txtDireccionRemitente.BackColor = System.Drawing.Color.White
        Me.txtDireccionRemitente.Enabled = False
        Me.txtDireccionRemitente.Location = New System.Drawing.Point(87, 39)
        Me.txtDireccionRemitente.Name = "txtDireccionRemitente"
        Me.txtDireccionRemitente.Size = New System.Drawing.Size(274, 20)
        Me.txtDireccionRemitente.TabIndex = 3
        '
        'txtRemitente
        '
        Me.txtRemitente.BackColor = System.Drawing.Color.White
        Me.txtRemitente.Enabled = False
        Me.txtRemitente.Location = New System.Drawing.Point(87, 13)
        Me.txtRemitente.Name = "txtRemitente"
        Me.txtRemitente.Size = New System.Drawing.Size(274, 20)
        Me.txtRemitente.TabIndex = 3
        '
        'grbEntrega
        '
        Me.grbEntrega.Controls.Add(Me.dtpFechaEntrega)
        Me.grbEntrega.Controls.Add(Me.dtpHoraEntrega)
        Me.grbEntrega.Controls.Add(Me.txtObservaciones)
        Me.grbEntrega.Controls.Add(Me.txtDNI)
        Me.grbEntrega.Controls.Add(Me.cboConsignado)
        Me.grbEntrega.Controls.Add(Me.Label23)
        Me.grbEntrega.Controls.Add(Me.txtCantidadEntregar)
        Me.grbEntrega.Controls.Add(Me.txtCantidadEntregada)
        Me.grbEntrega.Controls.Add(Me.Label25)
        Me.grbEntrega.Controls.Add(Me.Label24)
        Me.grbEntrega.Controls.Add(Me.Label22)
        Me.grbEntrega.Controls.Add(Me.lblCantidadEntregar)
        Me.grbEntrega.Controls.Add(Me.Label21)
        Me.grbEntrega.Controls.Add(Me.lblCantidadEntregada)
        Me.grbEntrega.Controls.Add(Me.txtTotal)
        Me.grbEntrega.Controls.Add(Me.Label19)
        Me.grbEntrega.Location = New System.Drawing.Point(8, 383)
        Me.grbEntrega.Name = "grbEntrega"
        Me.grbEntrega.Size = New System.Drawing.Size(734, 102)
        Me.grbEntrega.TabIndex = 18
        Me.grbEntrega.TabStop = False
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Enabled = False
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(278, 44)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(79, 20)
        Me.dtpFechaEntrega.TabIndex = 295
        '
        'dtpHoraEntrega
        '
        Me.dtpHoraEntrega.Enabled = False
        Me.dtpHoraEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraEntrega.Location = New System.Drawing.Point(432, 44)
        Me.dtpHoraEntrega.Name = "dtpHoraEntrega"
        Me.dtpHoraEntrega.ShowUpDown = True
        Me.dtpHoraEntrega.Size = New System.Drawing.Size(86, 20)
        Me.dtpHoraEntrega.TabIndex = 294
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Location = New System.Drawing.Point(92, 72)
        Me.txtObservaciones.MaxLength = 80
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(426, 20)
        Me.txtObservaciones.TabIndex = 2
        '
        'txtDNI
        '
        Me.txtDNI.BackColor = System.Drawing.Color.White
        Me.txtDNI.Location = New System.Drawing.Point(92, 44)
        Me.txtDNI.MaxLength = 8
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(98, 20)
        Me.txtDNI.TabIndex = 1
        '
        'cboConsignado
        '
        Me.cboConsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsignado.FormattingEnabled = True
        Me.cboConsignado.Location = New System.Drawing.Point(90, 15)
        Me.cboConsignado.Name = "cboConsignado"
        Me.cboConsignado.Size = New System.Drawing.Size(428, 21)
        Me.cboConsignado.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 75)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 284
        Me.Label23.Text = "Observación"
        '
        'txtCantidadEntregar
        '
        Me.txtCantidadEntregar.BackColor = System.Drawing.Color.White
        Me.txtCantidadEntregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadEntregar.Location = New System.Drawing.Point(608, 72)
        Me.txtCantidadEntregar.MaxLength = 10
        Me.txtCantidadEntregar.Name = "txtCantidadEntregar"
        Me.txtCantidadEntregar.Size = New System.Drawing.Size(120, 20)
        Me.txtCantidadEntregar.TabIndex = 3
        Me.txtCantidadEntregar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidadEntregada
        '
        Me.txtCantidadEntregada.BackColor = System.Drawing.Color.White
        Me.txtCantidadEntregada.Enabled = False
        Me.txtCantidadEntregada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadEntregada.Location = New System.Drawing.Point(608, 44)
        Me.txtCantidadEntregada.MaxLength = 10
        Me.txtCantidadEntregada.Name = "txtCantidadEntregada"
        Me.txtCantidadEntregada.Size = New System.Drawing.Size(120, 20)
        Me.txtCantidadEntregada.TabIndex = 291
        Me.txtCantidadEntregada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(361, 47)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 283
        Me.Label25.Text = "Hora Entrega"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(200, 47)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 281
        Me.Label24.Text = "Fecha Entrega"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 13)
        Me.Label22.TabIndex = 282
        Me.Label22.Text = "Doc. Identidad"
        '
        'lblCantidadEntregar
        '
        Me.lblCantidadEntregar.AutoSize = True
        Me.lblCantidadEntregar.Location = New System.Drawing.Point(524, 75)
        Me.lblCantidadEntregar.Name = "lblCantidadEntregar"
        Me.lblCantidadEntregar.Size = New System.Drawing.Size(84, 13)
        Me.lblCantidadEntregar.TabIndex = 286
        Me.lblCantidadEntregar.Text = "Cant. a Entregar"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 287
        Me.Label21.Text = "Entregado a"
        '
        'lblCantidadEntregada
        '
        Me.lblCantidadEntregada.AutoSize = True
        Me.lblCantidadEntregada.Location = New System.Drawing.Point(524, 46)
        Me.lblCantidadEntregada.Name = "lblCantidadEntregada"
        Me.lblCantidadEntregada.Size = New System.Drawing.Size(84, 13)
        Me.lblCantidadEntregada.TabIndex = 286
        Me.lblCantidadEntregada.Text = "Cant. Entregada"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(608, 15)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(120, 20)
        Me.txtTotal.TabIndex = 288
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(524, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 285
        Me.Label19.Text = "Total S/."
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(780, 387)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(106, 38)
        Me.btnAceptar.TabIndex = 19
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(780, 444)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 38)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregarHuella
        '
        Me.btnAgregarHuella.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarHuella.Location = New System.Drawing.Point(8, 201)
        Me.btnAgregarHuella.Name = "btnAgregarHuella"
        Me.btnAgregarHuella.Size = New System.Drawing.Size(72, 31)
        Me.btnAgregarHuella.TabIndex = 20
        Me.btnAgregarHuella.Text = "Agregar"
        Me.btnAgregarHuella.UseVisualStyleBackColor = True
        '
        'picHuella
        '
        Me.picHuella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picHuella.Location = New System.Drawing.Point(8, 18)
        Me.picHuella.Name = "picHuella"
        Me.picHuella.Size = New System.Drawing.Size(169, 176)
        Me.picHuella.TabIndex = 0
        Me.picHuella.TabStop = False
        '
        'btnVerHuella
        '
        Me.btnVerHuella.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerHuella.Location = New System.Drawing.Point(105, 201)
        Me.btnVerHuella.Name = "btnVerHuella"
        Me.btnVerHuella.Size = New System.Drawing.Size(72, 31)
        Me.btnVerHuella.TabIndex = 20
        Me.btnVerHuella.Text = "Ver"
        Me.btnVerHuella.UseVisualStyleBackColor = True
        '
        'grbHuella
        '
        Me.grbHuella.Controls.Add(Me.picHuella)
        Me.grbHuella.Controls.Add(Me.btnVerHuella)
        Me.grbHuella.Controls.Add(Me.btnAgregarHuella)
        Me.grbHuella.Location = New System.Drawing.Point(747, 3)
        Me.grbHuella.Name = "grbHuella"
        Me.grbHuella.Size = New System.Drawing.Size(183, 240)
        Me.grbHuella.TabIndex = 24
        Me.grbHuella.TabStop = False
        Me.grbHuella.Text = "Huella"
        '
        'frmConfirmacionEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 495)
        Me.Controls.Add(Me.grbHuella)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.grbEntrega)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvDocumento)
        Me.Controls.Add(Me.dgvBulto)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfirmacionEntrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirmación Entrega de Carga"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvBulto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grbEntrega.ResumeLayout(False)
        Me.grbEntrega.PerformLayout()
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbHuella.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAgenciaDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtAgenciaOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents txtNumeroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtSubcuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvBulto As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDocumento As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFormaPago As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAutorizado As System.Windows.Forms.TextBox
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents txtTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionRemitente As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitente As System.Windows.Forms.TextBox
    Friend WithEvents grbEntrega As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHoraEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtDNI As System.Windows.Forms.TextBox
    Friend WithEvents cboConsignado As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadEntregada As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblCantidadEntregada As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadEntregar As System.Windows.Forms.TextBox
    Friend WithEvents lblCantidadEntregar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarHuella As System.Windows.Forms.Button
    Friend WithEvents picHuella As System.Windows.Forms.PictureBox
    Friend WithEvents btnVerHuella As System.Windows.Forms.Button
    Friend WithEvents grbHuella As System.Windows.Forms.GroupBox
End Class
