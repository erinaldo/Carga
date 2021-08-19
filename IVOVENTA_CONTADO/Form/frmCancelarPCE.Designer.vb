<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelarPCE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarPCE))
        Me.TabGuia = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnDescuento = New System.Windows.Forms.Button()
        Me.BtnConsultar = New System.Windows.Forms.Button()
        Me.BtnCA = New System.Windows.Forms.Button()
        Me.BtnPCE = New System.Windows.Forms.Button()
        Me.LblRegistros = New System.Windows.Forms.Label()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtGuia = New System.Windows.Forms.TextBox()
        Me.TxtDocumento = New System.Windows.Forms.TextBox()
        Me.DgvLista = New System.Windows.Forms.DataGridView()
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.CboUsuario = New System.Windows.Forms.ComboBox()
        Me.CboEstado = New System.Windows.Forms.ComboBox()
        Me.CboCiudadDestino = New System.Windows.Forms.ComboBox()
        Me.CboAgenciaOrigen = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CboCiudadOrigen = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrdDocumentosCliente = New System.Windows.Forms.DataGridView()
        Me.ID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seguro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrpOrigen = New System.Windows.Forms.GroupBox()
        Me.LblCiudad = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblAgencia = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CboProducto = New System.Windows.Forms.ComboBox()
        Me.GrpCondicionVenta = New System.Windows.Forms.GroupBox()
        Me.TxtNroTarjeta = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.LblNroTarj = New System.Windows.Forms.Label()
        Me.CboTipoEntrega = New System.Windows.Forms.ComboBox()
        Me.LblTarjeta = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CboTarjeta = New System.Windows.Forms.ComboBox()
        Me.CboFormaPago = New System.Windows.Forms.ComboBox()
        Me.GrpDestino = New System.Windows.Forms.GroupBox()
        Me.TxtCiudadDestino = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CboAgenciaDest = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LblNroBoletaFact = New System.Windows.Forms.Label()
        Me.LblFechaServidor = New System.Windows.Forms.Label()
        Me.LblSerie = New System.Windows.Forms.Label()
        Me.GrpDescuento = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtDescuento = New System.Windows.Forms.TextBox()
        Me.lbDescDescto = New System.Windows.Forms.Label()
        Me.txtDescDescto = New System.Windows.Forms.TextBox()
        Me.LblTipoComprobante = New System.Windows.Forms.Label()
        Me.ChkVolumetrico = New System.Windows.Forms.CheckBox()
        Me.CboTipoTarifa = New System.Windows.Forms.ComboBox()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.LblTipoTarifa = New System.Windows.Forms.Label()
        Me.TxtImpuesto = New System.Windows.Forms.TextBox()
        Me.TxtSubtotal = New System.Windows.Forms.TextBox()
        Me.BtnCargAseg = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.txtMontoBase = New System.Windows.Forms.TextBox()
        Me.lblMontoBase = New System.Windows.Forms.Label()
        Me.txtTotalSobre = New System.Windows.Forms.TextBox()
        Me.chkSobres = New System.Windows.Forms.CheckBox()
        Me.txtCantidadSobres = New System.Windows.Forms.TextBox()
        Me.ChkCargo = New System.Windows.Forms.CheckBox()
        Me.Grpa = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtBoleto = New System.Windows.Forms.MaskedTextBox()
        Me.GrdDetalleVenta = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Volumen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sub_Neto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtVuelto = New System.Windows.Forms.Label()
        Me.txtTotalPagado = New System.Windows.Forms.Label()
        Me.txtTotalVenta = New System.Windows.Forms.Label()
        Me.lblVuelto = New System.Windows.Forms.Label()
        Me.lblTotalPagado = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.LbldetalleVenta = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GrpConsignado = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.txtTelfConsignado = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RbtNombre3 = New System.Windows.Forms.RadioButton()
        Me.RbtDocumento3 = New System.Windows.Forms.RadioButton()
        Me.BtnConsignado = New System.Windows.Forms.Button()
        Me.CboDireccion2 = New System.Windows.Forms.ComboBox()
        Me.ChkCliente2 = New System.Windows.Forms.CheckBox()
        Me.TxtConsignado = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtNombConsignado = New System.Windows.Forms.TextBox()
        Me.TxtNroDocConsignado = New System.Windows.Forms.TextBox()
        Me.ChkArticulos = New System.Windows.Forms.CheckBox()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.RbtNombre = New System.Windows.Forms.RadioButton()
        Me.RbtDocumento = New System.Windows.Forms.RadioButton()
        Me.LblPasajero = New System.Windows.Forms.Label()
        Me.TxtTelfCliente = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CboContacto = New System.Windows.Forms.ComboBox()
        Me.CboDireccion = New System.Windows.Forms.ComboBox()
        Me.ChkCliente1 = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtNomCliente = New System.Windows.Forms.TextBox()
        Me.TxtNroDocContacto = New System.Windows.Forms.TextBox()
        Me.TxtNroDocCliente = New System.Windows.Forms.TextBox()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabGuia.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.GrdDocumentosCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpOrigen.SuspendLayout()
        Me.GrpCondicionVenta.SuspendLayout()
        Me.GrpDestino.SuspendLayout()
        Me.GrpDescuento.SuspendLayout()
        Me.Grpa.SuspendLayout()
        CType(Me.GrdDetalleVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpConsignado.SuspendLayout()
        Me.GrpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabGuia
        '
        Me.TabGuia.Controls.Add(Me.TabPage1)
        Me.TabGuia.Controls.Add(Me.TabPage2)
        Me.TabGuia.Location = New System.Drawing.Point(1, 3)
        Me.TabGuia.Name = "TabGuia"
        Me.TabGuia.SelectedIndex = 0
        Me.TabGuia.Size = New System.Drawing.Size(853, 631)
        Me.TabGuia.TabIndex = 0
        Me.TabGuia.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnDescuento)
        Me.TabPage1.Controls.Add(Me.BtnConsultar)
        Me.TabPage1.Controls.Add(Me.BtnCA)
        Me.TabPage1.Controls.Add(Me.BtnPCE)
        Me.TabPage1.Controls.Add(Me.LblRegistros)
        Me.TabPage1.Controls.Add(Me.BtnSalir)
        Me.TabPage1.Controls.Add(Me.btnBuscarCliente)
        Me.TabPage1.Controls.Add(Me.BtnBuscar)
        Me.TabPage1.Controls.Add(Me.TxtGuia)
        Me.TabPage1.Controls.Add(Me.TxtDocumento)
        Me.TabPage1.Controls.Add(Me.DgvLista)
        Me.TabPage1.Controls.Add(Me.DtpFechaFin)
        Me.TabPage1.Controls.Add(Me.DtpFechaInicio)
        Me.TabPage1.Controls.Add(Me.CboUsuario)
        Me.TabPage1.Controls.Add(Me.CboEstado)
        Me.TabPage1.Controls.Add(Me.CboCiudadDestino)
        Me.TabPage1.Controls.Add(Me.CboAgenciaOrigen)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.CboCiudadOrigen)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(845, 605)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Buscar"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnDescuento
        '
        Me.btnDescuento.Enabled = False
        Me.btnDescuento.Location = New System.Drawing.Point(765, 268)
        Me.btnDescuento.Name = "btnDescuento"
        Me.btnDescuento.Size = New System.Drawing.Size(74, 30)
        Me.btnDescuento.TabIndex = 26
        Me.btnDescuento.Text = "Descuento"
        Me.btnDescuento.UseVisualStyleBackColor = True
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Enabled = False
        Me.BtnConsultar.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.BtnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConsultar.Location = New System.Drawing.Point(765, 142)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(74, 30)
        Me.BtnConsultar.TabIndex = 22
        Me.BtnConsultar.Text = "     Consultar"
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'BtnCA
        '
        Me.BtnCA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCA.Enabled = False
        Me.BtnCA.Location = New System.Drawing.Point(765, 405)
        Me.BtnCA.Name = "BtnCA"
        Me.BtnCA.Size = New System.Drawing.Size(74, 30)
        Me.BtnCA.TabIndex = 21
        Me.BtnCA.Text = "Canje CA"
        Me.BtnCA.UseVisualStyleBackColor = True
        '
        'BtnPCE
        '
        Me.BtnPCE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPCE.Enabled = False
        Me.BtnPCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPCE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPCE.Location = New System.Drawing.Point(765, 88)
        Me.BtnPCE.Name = "BtnPCE"
        Me.BtnPCE.Size = New System.Drawing.Size(74, 30)
        Me.BtnPCE.TabIndex = 20
        Me.BtnPCE.Text = "Canje PCE"
        Me.BtnPCE.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnPCE.UseVisualStyleBackColor = True
        '
        'LblRegistros
        '
        Me.LblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros.ForeColor = System.Drawing.Color.Red
        Me.LblRegistros.Location = New System.Drawing.Point(769, 524)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(68, 13)
        Me.LblRegistros.TabIndex = 23
        Me.LblRegistros.Text = "0"
        Me.LblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSalir
        '
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(765, 546)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(74, 30)
        Me.BtnSalir.TabIndex = 24
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarCliente.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.btnBuscarCliente.Location = New System.Drawing.Point(793, 41)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(31, 26)
        Me.btnBuscarCliente.TabIndex = 19
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.Location = New System.Drawing.Point(793, 6)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(31, 26)
        Me.BtnBuscar.TabIndex = 18
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'TxtGuia
        '
        Me.TxtGuia.Location = New System.Drawing.Point(344, 59)
        Me.TxtGuia.MaxLength = 15
        Me.TxtGuia.Name = "TxtGuia"
        Me.TxtGuia.Size = New System.Drawing.Size(155, 20)
        Me.TxtGuia.TabIndex = 11
        '
        'TxtDocumento
        '
        Me.TxtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocumento.Location = New System.Drawing.Point(59, 59)
        Me.TxtDocumento.MaxLength = 20
        Me.TxtDocumento.Name = "TxtDocumento"
        Me.TxtDocumento.Size = New System.Drawing.Size(171, 20)
        Me.TxtDocumento.TabIndex = 5
        '
        'DgvLista
        '
        Me.DgvLista.BackgroundColor = System.Drawing.Color.MidnightBlue
        Me.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLista.Location = New System.Drawing.Point(7, 87)
        Me.DgvLista.Name = "DgvLista"
        Me.DgvLista.Size = New System.Drawing.Size(749, 490)
        Me.DgvLista.TabIndex = 25
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaFin.Location = New System.Drawing.Point(344, 33)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(155, 20)
        Me.DtpFechaFin.TabIndex = 9
        '
        'DtpFechaInicio
        '
        Me.DtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaInicio.Location = New System.Drawing.Point(344, 7)
        Me.DtpFechaInicio.Name = "DtpFechaInicio"
        Me.DtpFechaInicio.Size = New System.Drawing.Size(155, 20)
        Me.DtpFechaInicio.TabIndex = 7
        '
        'CboUsuario
        '
        Me.CboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboUsuario.FormattingEnabled = True
        Me.CboUsuario.Location = New System.Drawing.Point(567, 33)
        Me.CboUsuario.Name = "CboUsuario"
        Me.CboUsuario.Size = New System.Drawing.Size(188, 21)
        Me.CboUsuario.TabIndex = 15
        '
        'CboEstado
        '
        Me.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstado.FormattingEnabled = True
        Me.CboEstado.Location = New System.Drawing.Point(567, 59)
        Me.CboEstado.Name = "CboEstado"
        Me.CboEstado.Size = New System.Drawing.Size(188, 21)
        Me.CboEstado.TabIndex = 17
        '
        'CboCiudadDestino
        '
        Me.CboCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCiudadDestino.FormattingEnabled = True
        Me.CboCiudadDestino.Location = New System.Drawing.Point(59, 33)
        Me.CboCiudadDestino.Name = "CboCiudadDestino"
        Me.CboCiudadDestino.Size = New System.Drawing.Size(173, 21)
        Me.CboCiudadDestino.TabIndex = 3
        '
        'CboAgenciaOrigen
        '
        Me.CboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAgenciaOrigen.FormattingEnabled = True
        Me.CboAgenciaOrigen.Location = New System.Drawing.Point(567, 6)
        Me.CboAgenciaOrigen.Name = "CboAgenciaOrigen"
        Me.CboAgenciaOrigen.Size = New System.Drawing.Size(188, 21)
        Me.CboAgenciaOrigen.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(505, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Usuario"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(270, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Nº Guía"
        '
        'CboCiudadOrigen
        '
        Me.CboCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCiudadOrigen.FormattingEnabled = True
        Me.CboCiudadOrigen.Location = New System.Drawing.Point(59, 6)
        Me.CboCiudadOrigen.Name = "CboCiudadOrigen"
        Me.CboCiudadOrigen.Size = New System.Drawing.Size(174, 21)
        Me.CboCiudadOrigen.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(508, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Estado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Nº Doc."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destino"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(270, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha Fin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(505, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Agencia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(270, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha Inicio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Origen"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GrdDocumentosCliente)
        Me.TabPage2.Controls.Add(Me.GrpOrigen)
        Me.TabPage2.Controls.Add(Me.CboProducto)
        Me.TabPage2.Controls.Add(Me.GrpCondicionVenta)
        Me.TabPage2.Controls.Add(Me.GrpDestino)
        Me.TabPage2.Controls.Add(Me.LblNroBoletaFact)
        Me.TabPage2.Controls.Add(Me.LblFechaServidor)
        Me.TabPage2.Controls.Add(Me.LblSerie)
        Me.TabPage2.Controls.Add(Me.GrpDescuento)
        Me.TabPage2.Controls.Add(Me.LblTipoComprobante)
        Me.TabPage2.Controls.Add(Me.ChkVolumetrico)
        Me.TabPage2.Controls.Add(Me.CboTipoTarifa)
        Me.TabPage2.Controls.Add(Me.TxtTotal)
        Me.TabPage2.Controls.Add(Me.LblTipoTarifa)
        Me.TabPage2.Controls.Add(Me.TxtImpuesto)
        Me.TabPage2.Controls.Add(Me.TxtSubtotal)
        Me.TabPage2.Controls.Add(Me.BtnCargAseg)
        Me.TabPage2.Controls.Add(Me.BtnNuevo)
        Me.TabPage2.Controls.Add(Me.txtMontoBase)
        Me.TabPage2.Controls.Add(Me.lblMontoBase)
        Me.TabPage2.Controls.Add(Me.txtTotalSobre)
        Me.TabPage2.Controls.Add(Me.chkSobres)
        Me.TabPage2.Controls.Add(Me.txtCantidadSobres)
        Me.TabPage2.Controls.Add(Me.ChkCargo)
        Me.TabPage2.Controls.Add(Me.Grpa)
        Me.TabPage2.Controls.Add(Me.GrdDetalleVenta)
        Me.TabPage2.Controls.Add(Me.BtnGrabar)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.txtVuelto)
        Me.TabPage2.Controls.Add(Me.txtTotalPagado)
        Me.TabPage2.Controls.Add(Me.txtTotalVenta)
        Me.TabPage2.Controls.Add(Me.lblVuelto)
        Me.TabPage2.Controls.Add(Me.lblTotalPagado)
        Me.TabPage2.Controls.Add(Me.lblTotalVenta)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.LbldetalleVenta)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.GrpConsignado)
        Me.TabPage2.Controls.Add(Me.ChkArticulos)
        Me.TabPage2.Controls.Add(Me.GrpCliente)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(845, 605)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Guía de Envío"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GrdDocumentosCliente
        '
        Me.GrdDocumentosCliente.BackgroundColor = System.Drawing.Color.MidnightBlue
        Me.GrdDocumentosCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GrdDocumentosCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDocumentosCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID1, Me.ID2, Me.Cargo, Me.Seguro})
        Me.GrdDocumentosCliente.Location = New System.Drawing.Point(3, 374)
        Me.GrdDocumentosCliente.Name = "GrdDocumentosCliente"
        Me.GrdDocumentosCliente.RowTemplate.DefaultCellStyle.Format = "N0"
        Me.GrdDocumentosCliente.Size = New System.Drawing.Size(307, 153)
        Me.GrdDocumentosCliente.TabIndex = 114
        '
        'ID1
        '
        Me.ID1.DataPropertyName = "ID1"
        Me.ID1.HeaderText = "ID1"
        Me.ID1.Name = "ID1"
        Me.ID1.Visible = False
        '
        'ID2
        '
        Me.ID2.DataPropertyName = "ID2"
        Me.ID2.HeaderText = "ID2"
        Me.ID2.Name = "ID2"
        Me.ID2.Visible = False
        '
        'Cargo
        '
        Me.Cargo.DataPropertyName = "Cargo"
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        '
        'Seguro
        '
        Me.Seguro.DataPropertyName = "Seguro"
        Me.Seguro.HeaderText = "Seguro"
        Me.Seguro.Name = "Seguro"
        '
        'GrpOrigen
        '
        Me.GrpOrigen.Controls.Add(Me.LblCiudad)
        Me.GrpOrigen.Controls.Add(Me.Label10)
        Me.GrpOrigen.Controls.Add(Me.LblAgencia)
        Me.GrpOrigen.Controls.Add(Me.Label11)
        Me.GrpOrigen.Location = New System.Drawing.Point(3, 56)
        Me.GrpOrigen.Name = "GrpOrigen"
        Me.GrpOrigen.Size = New System.Drawing.Size(417, 37)
        Me.GrpOrigen.TabIndex = 120
        Me.GrpOrigen.TabStop = False
        Me.GrpOrigen.Text = "Orígen"
        '
        'LblCiudad
        '
        Me.LblCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCiudad.Location = New System.Drawing.Point(64, 16)
        Me.LblCiudad.Name = "LblCiudad"
        Me.LblCiudad.Size = New System.Drawing.Size(131, 15)
        Me.LblCiudad.TabIndex = 1
        Me.LblCiudad.Text = "CIUDAD"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Ciudad"
        '
        'LblAgencia
        '
        Me.LblAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAgencia.Location = New System.Drawing.Point(273, 16)
        Me.LblAgencia.Name = "LblAgencia"
        Me.LblAgencia.Size = New System.Drawing.Size(142, 18)
        Me.LblAgencia.TabIndex = 3
        Me.LblAgencia.Text = "AGENCIA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(217, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Agencia"
        '
        'CboProducto
        '
        Me.CboProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProducto.DropDownWidth = 135
        Me.CboProducto.FormattingEnabled = True
        Me.CboProducto.Location = New System.Drawing.Point(69, 11)
        Me.CboProducto.Name = "CboProducto"
        Me.CboProducto.Size = New System.Drawing.Size(136, 21)
        Me.CboProducto.TabIndex = 92
        '
        'GrpCondicionVenta
        '
        Me.GrpCondicionVenta.Controls.Add(Me.TxtNroTarjeta)
        Me.GrpCondicionVenta.Controls.Add(Me.Label33)
        Me.GrpCondicionVenta.Controls.Add(Me.LblNroTarj)
        Me.GrpCondicionVenta.Controls.Add(Me.CboTipoEntrega)
        Me.GrpCondicionVenta.Controls.Add(Me.LblTarjeta)
        Me.GrpCondicionVenta.Controls.Add(Me.Label12)
        Me.GrpCondicionVenta.Controls.Add(Me.CboTarjeta)
        Me.GrpCondicionVenta.Controls.Add(Me.CboFormaPago)
        Me.GrpCondicionVenta.Location = New System.Drawing.Point(3, 94)
        Me.GrpCondicionVenta.Name = "GrpCondicionVenta"
        Me.GrpCondicionVenta.Size = New System.Drawing.Size(840, 37)
        Me.GrpCondicionVenta.TabIndex = 96
        Me.GrpCondicionVenta.TabStop = False
        Me.GrpCondicionVenta.Text = "Condición"
        '
        'TxtNroTarjeta
        '
        Me.TxtNroTarjeta.Location = New System.Drawing.Point(690, 12)
        Me.TxtNroTarjeta.MaxLength = 13
        Me.TxtNroTarjeta.Name = "TxtNroTarjeta"
        Me.TxtNroTarjeta.Size = New System.Drawing.Size(141, 20)
        Me.TxtNroTarjeta.TabIndex = 7
        Me.TxtNroTarjeta.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(44, 13)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Entrega"
        '
        'LblNroTarj
        '
        Me.LblNroTarj.AutoSize = True
        Me.LblNroTarj.Location = New System.Drawing.Point(622, 16)
        Me.LblNroTarj.Name = "LblNroTarj"
        Me.LblNroTarj.Size = New System.Drawing.Size(55, 13)
        Me.LblNroTarj.TabIndex = 6
        Me.LblNroTarj.Text = "Nº Tarjeta"
        Me.LblNroTarj.Visible = False
        '
        'CboTipoEntrega
        '
        Me.CboTipoEntrega.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboTipoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoEntrega.FormattingEnabled = True
        Me.CboTipoEntrega.Location = New System.Drawing.Point(66, 11)
        Me.CboTipoEntrega.Name = "CboTipoEntrega"
        Me.CboTipoEntrega.Size = New System.Drawing.Size(136, 21)
        Me.CboTipoEntrega.TabIndex = 1
        '
        'LblTarjeta
        '
        Me.LblTarjeta.AutoSize = True
        Me.LblTarjeta.Location = New System.Drawing.Point(430, 15)
        Me.LblTarjeta.Name = "LblTarjeta"
        Me.LblTarjeta.Size = New System.Drawing.Size(40, 13)
        Me.LblTarjeta.TabIndex = 4
        Me.LblTarjeta.Text = "Tarjeta"
        Me.LblTarjeta.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(217, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "For. Pago"
        Me.Label12.Visible = False
        '
        'CboTarjeta
        '
        Me.CboTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTarjeta.FormattingEnabled = True
        Me.CboTarjeta.Location = New System.Drawing.Point(487, 11)
        Me.CboTarjeta.Name = "CboTarjeta"
        Me.CboTarjeta.Size = New System.Drawing.Size(129, 21)
        Me.CboTarjeta.TabIndex = 5
        Me.CboTarjeta.Visible = False
        '
        'CboFormaPago
        '
        Me.CboFormaPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFormaPago.FormattingEnabled = True
        Me.CboFormaPago.Location = New System.Drawing.Point(276, 12)
        Me.CboFormaPago.Name = "CboFormaPago"
        Me.CboFormaPago.Size = New System.Drawing.Size(134, 21)
        Me.CboFormaPago.TabIndex = 3
        Me.CboFormaPago.Visible = False
        '
        'GrpDestino
        '
        Me.GrpDestino.Controls.Add(Me.TxtCiudadDestino)
        Me.GrpDestino.Controls.Add(Me.Label23)
        Me.GrpDestino.Controls.Add(Me.CboAgenciaDest)
        Me.GrpDestino.Controls.Add(Me.Label29)
        Me.GrpDestino.Location = New System.Drawing.Point(425, 56)
        Me.GrpDestino.Name = "GrpDestino"
        Me.GrpDestino.Size = New System.Drawing.Size(417, 37)
        Me.GrpDestino.TabIndex = 95
        Me.GrpDestino.TabStop = False
        Me.GrpDestino.Text = "Destino"
        '
        'TxtCiudadDestino
        '
        Me.TxtCiudadDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCiudadDestino.Location = New System.Drawing.Point(65, 11)
        Me.TxtCiudadDestino.MaxLength = 30
        Me.TxtCiudadDestino.Name = "TxtCiudadDestino"
        Me.TxtCiudadDestino.Size = New System.Drawing.Size(128, 20)
        Me.TxtCiudadDestino.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Ciudad"
        '
        'CboAgenciaDest
        '
        Me.CboAgenciaDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAgenciaDest.FormattingEnabled = True
        Me.CboAgenciaDest.Location = New System.Drawing.Point(268, 11)
        Me.CboAgenciaDest.Name = "CboAgenciaDest"
        Me.CboAgenciaDest.Size = New System.Drawing.Size(143, 21)
        Me.CboAgenciaDest.TabIndex = 3
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(200, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(46, 13)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "Agencia"
        '
        'LblNroBoletaFact
        '
        Me.LblNroBoletaFact.BackColor = System.Drawing.Color.White
        Me.LblNroBoletaFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNroBoletaFact.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNroBoletaFact.ForeColor = System.Drawing.Color.Black
        Me.LblNroBoletaFact.Location = New System.Drawing.Point(768, 33)
        Me.LblNroBoletaFact.Name = "LblNroBoletaFact"
        Me.LblNroBoletaFact.Size = New System.Drawing.Size(72, 18)
        Me.LblNroBoletaFact.TabIndex = 119
        Me.LblNroBoletaFact.Text = "0000001"
        Me.LblNroBoletaFact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFechaServidor
        '
        Me.LblFechaServidor.AutoSize = True
        Me.LblFechaServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaServidor.ForeColor = System.Drawing.Color.Red
        Me.LblFechaServidor.Location = New System.Drawing.Point(433, 27)
        Me.LblFechaServidor.Name = "LblFechaServidor"
        Me.LblFechaServidor.Size = New System.Drawing.Size(75, 13)
        Me.LblFechaServidor.TabIndex = 116
        Me.LblFechaServidor.Text = "01/03/2011"
        '
        'LblSerie
        '
        Me.LblSerie.BackColor = System.Drawing.Color.White
        Me.LblSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSerie.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSerie.ForeColor = System.Drawing.Color.Black
        Me.LblSerie.Location = New System.Drawing.Point(740, 33)
        Me.LblSerie.Name = "LblSerie"
        Me.LblSerie.Size = New System.Drawing.Size(31, 18)
        Me.LblSerie.TabIndex = 118
        Me.LblSerie.Text = "001"
        Me.LblSerie.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GrpDescuento
        '
        Me.GrpDescuento.Controls.Add(Me.Label15)
        Me.GrpDescuento.Controls.Add(Me.TxtDescuento)
        Me.GrpDescuento.Controls.Add(Me.lbDescDescto)
        Me.GrpDescuento.Controls.Add(Me.txtDescDescto)
        Me.GrpDescuento.Location = New System.Drawing.Point(423, 279)
        Me.GrpDescuento.Name = "GrpDescuento"
        Me.GrpDescuento.Size = New System.Drawing.Size(419, 42)
        Me.GrpDescuento.TabIndex = 99
        Me.GrpDescuento.TabStop = False
        Me.GrpDescuento.Text = "Descuento"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Porcentaje"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescuento.Location = New System.Drawing.Point(83, 15)
        Me.TxtDescuento.MaxLength = 7
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(88, 20)
        Me.TxtDescuento.TabIndex = 1
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbDescDescto
        '
        Me.lbDescDescto.AutoSize = True
        Me.lbDescDescto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescDescto.ForeColor = System.Drawing.Color.Black
        Me.lbDescDescto.Location = New System.Drawing.Point(187, 19)
        Me.lbDescDescto.Name = "lbDescDescto"
        Me.lbDescDescto.Size = New System.Drawing.Size(45, 13)
        Me.lbDescDescto.TabIndex = 2
        Me.lbDescDescto.Text = "Autoriza"
        '
        'txtDescDescto
        '
        Me.txtDescDescto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescDescto.Location = New System.Drawing.Point(238, 14)
        Me.txtDescDescto.MaxLength = 50
        Me.txtDescDescto.Name = "txtDescDescto"
        Me.txtDescDescto.Size = New System.Drawing.Size(175, 20)
        Me.txtDescDescto.TabIndex = 3
        '
        'LblTipoComprobante
        '
        Me.LblTipoComprobante.BackColor = System.Drawing.Color.MidnightBlue
        Me.LblTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoComprobante.ForeColor = System.Drawing.Color.White
        Me.LblTipoComprobante.Location = New System.Drawing.Point(740, 9)
        Me.LblTipoComprobante.Name = "LblTipoComprobante"
        Me.LblTipoComprobante.Size = New System.Drawing.Size(100, 24)
        Me.LblTipoComprobante.TabIndex = 117
        Me.LblTipoComprobante.Text = "BOLETA"
        Me.LblTipoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkVolumetrico
        '
        Me.ChkVolumetrico.AutoSize = True
        Me.ChkVolumetrico.Location = New System.Drawing.Point(434, 353)
        Me.ChkVolumetrico.Name = "ChkVolumetrico"
        Me.ChkVolumetrico.Size = New System.Drawing.Size(81, 17)
        Me.ChkVolumetrico.TabIndex = 102
        Me.ChkVolumetrico.Text = "Volumétrico"
        Me.ChkVolumetrico.UseVisualStyleBackColor = True
        '
        'CboTipoTarifa
        '
        Me.CboTipoTarifa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoTarifa.FormattingEnabled = True
        Me.CboTipoTarifa.Items.AddRange(New Object() {"ESTANDAR", "24 HORAS"})
        Me.CboTipoTarifa.Location = New System.Drawing.Point(69, 35)
        Me.CboTipoTarifa.Name = "CboTipoTarifa"
        Me.CboTipoTarifa.Size = New System.Drawing.Size(136, 21)
        Me.CboTipoTarifa.TabIndex = 93
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(721, 542)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(116, 20)
        Me.TxtTotal.TabIndex = 132
        Me.TxtTotal.TabStop = False
        Me.TxtTotal.Text = "0.00"
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTipoTarifa
        '
        Me.LblTipoTarifa.AutoSize = True
        Me.LblTipoTarifa.Location = New System.Drawing.Point(4, 37)
        Me.LblTipoTarifa.Name = "LblTipoTarifa"
        Me.LblTipoTarifa.Size = New System.Drawing.Size(34, 13)
        Me.LblTipoTarifa.TabIndex = 115
        Me.LblTipoTarifa.Text = "Tarifa"
        '
        'TxtImpuesto
        '
        Me.TxtImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImpuesto.Location = New System.Drawing.Point(564, 542)
        Me.TxtImpuesto.Name = "TxtImpuesto"
        Me.TxtImpuesto.ReadOnly = True
        Me.TxtImpuesto.Size = New System.Drawing.Size(102, 20)
        Me.TxtImpuesto.TabIndex = 130
        Me.TxtImpuesto.TabStop = False
        Me.TxtImpuesto.Text = "0.00"
        Me.TxtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(373, 542)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(116, 20)
        Me.TxtSubtotal.TabIndex = 128
        Me.TxtSubtotal.TabStop = False
        Me.TxtSubtotal.Text = "0.00"
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnCargAseg
        '
        Me.BtnCargAseg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCargAseg.Enabled = False
        Me.BtnCargAseg.Image = CType(resources.GetObject("BtnCargAseg.Image"), System.Drawing.Image)
        Me.BtnCargAseg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCargAseg.Location = New System.Drawing.Point(774, 569)
        Me.BtnCargAseg.Name = "BtnCargAseg"
        Me.BtnCargAseg.Size = New System.Drawing.Size(63, 28)
        Me.BtnCargAseg.TabIndex = 110
        Me.BtnCargAseg.Text = "&Seguro"
        Me.BtnCargAseg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCargAseg.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.Enabled = False
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(7, 569)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(63, 28)
        Me.BtnNuevo.TabIndex = 111
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'txtMontoBase
        '
        Me.txtMontoBase.BackColor = System.Drawing.Color.White
        Me.txtMontoBase.Location = New System.Drawing.Point(790, 326)
        Me.txtMontoBase.MaxLength = 20
        Me.txtMontoBase.Name = "txtMontoBase"
        Me.txtMontoBase.ReadOnly = True
        Me.txtMontoBase.Size = New System.Drawing.Size(52, 20)
        Me.txtMontoBase.TabIndex = 104
        Me.txtMontoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMontoBase.Visible = False
        '
        'lblMontoBase
        '
        Me.lblMontoBase.AutoSize = True
        Me.lblMontoBase.Location = New System.Drawing.Point(737, 329)
        Me.lblMontoBase.Name = "lblMontoBase"
        Me.lblMontoBase.Size = New System.Drawing.Size(31, 13)
        Me.lblMontoBase.TabIndex = 133
        Me.lblMontoBase.Text = "Base"
        Me.lblMontoBase.Visible = False
        '
        'txtTotalSobre
        '
        Me.txtTotalSobre.BackColor = System.Drawing.Color.White
        Me.txtTotalSobre.Location = New System.Drawing.Point(790, 350)
        Me.txtTotalSobre.MaxLength = 20
        Me.txtTotalSobre.Name = "txtTotalSobre"
        Me.txtTotalSobre.ReadOnly = True
        Me.txtTotalSobre.Size = New System.Drawing.Size(52, 20)
        Me.txtTotalSobre.TabIndex = 107
        Me.txtTotalSobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalSobre.Visible = False
        '
        'chkSobres
        '
        Me.chkSobres.AutoSize = True
        Me.chkSobres.Location = New System.Drawing.Point(666, 353)
        Me.chkSobres.Name = "chkSobres"
        Me.chkSobres.Size = New System.Drawing.Size(54, 17)
        Me.chkSobres.TabIndex = 101
        Me.chkSobres.Text = "&Sobre"
        Me.chkSobres.UseVisualStyleBackColor = True
        Me.chkSobres.Visible = False
        '
        'txtCantidadSobres
        '
        Me.txtCantidadSobres.Enabled = False
        Me.txtCantidadSobres.Location = New System.Drawing.Point(726, 350)
        Me.txtCantidadSobres.MaxLength = 10
        Me.txtCantidadSobres.Name = "txtCantidadSobres"
        Me.txtCantidadSobres.Size = New System.Drawing.Size(52, 20)
        Me.txtCantidadSobres.TabIndex = 105
        Me.txtCantidadSobres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCantidadSobres.Visible = False
        '
        'ChkCargo
        '
        Me.ChkCargo.AutoSize = True
        Me.ChkCargo.Location = New System.Drawing.Point(434, 329)
        Me.ChkCargo.Name = "ChkCargo"
        Me.ChkCargo.Size = New System.Drawing.Size(54, 17)
        Me.ChkCargo.TabIndex = 100
        Me.ChkCargo.Text = "Cargo"
        Me.ChkCargo.UseVisualStyleBackColor = True
        '
        'Grpa
        '
        Me.Grpa.Controls.Add(Me.Label17)
        Me.Grpa.Controls.Add(Me.TxtBoleto)
        Me.Grpa.Location = New System.Drawing.Point(243, 12)
        Me.Grpa.Name = "Grpa"
        Me.Grpa.Size = New System.Drawing.Size(177, 37)
        Me.Grpa.TabIndex = 94
        Me.Grpa.TabStop = False
        Me.Grpa.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Nº Boleto"
        '
        'TxtBoleto
        '
        Me.TxtBoleto.Location = New System.Drawing.Point(65, 11)
        Me.TxtBoleto.Mask = "999-9999999"
        Me.TxtBoleto.Name = "TxtBoleto"
        Me.TxtBoleto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBoleto.Size = New System.Drawing.Size(104, 20)
        Me.TxtBoleto.TabIndex = 1
        Me.TxtBoleto.Visible = False
        '
        'GrdDetalleVenta
        '
        Me.GrdDetalleVenta.BackgroundColor = System.Drawing.Color.MidnightBlue
        Me.GrdDetalleVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GrdDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDetalleVenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Bulto, Me.Volumen, Me.Costo, Me.Sub_Neto})
        Me.GrdDetalleVenta.Location = New System.Drawing.Point(318, 374)
        Me.GrdDetalleVenta.Name = "GrdDetalleVenta"
        Me.GrdDetalleVenta.Size = New System.Drawing.Size(525, 160)
        Me.GrdDetalleVenta.TabIndex = 108
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 80
        '
        'Bulto
        '
        Me.Bulto.HeaderText = "Bulto"
        Me.Bulto.Name = "Bulto"
        Me.Bulto.Width = 70
        '
        'Volumen
        '
        Me.Volumen.HeaderText = "Peso/Volumen"
        Me.Volumen.Name = "Volumen"
        Me.Volumen.Width = 130
        '
        'Costo
        '
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        '
        'Sub_Neto
        '
        Me.Sub_Neto.HeaderText = "Sub Neto"
        Me.Sub_Neto.Name = "Sub_Neto"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(401, 569)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(63, 28)
        Me.BtnGrabar.TabIndex = 109
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGrabar.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(5, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 13)
        Me.Label31.TabIndex = 113
        Me.Label31.Text = "Producto"
        '
        'txtVuelto
        '
        Me.txtVuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVuelto.ForeColor = System.Drawing.Color.Red
        Me.txtVuelto.Location = New System.Drawing.Point(213, 576)
        Me.txtVuelto.Name = "txtVuelto"
        Me.txtVuelto.Size = New System.Drawing.Size(77, 17)
        Me.txtVuelto.TabIndex = 126
        Me.txtVuelto.Text = "0.00"
        Me.txtVuelto.Visible = False
        '
        'txtTotalPagado
        '
        Me.txtTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagado.ForeColor = System.Drawing.Color.Red
        Me.txtTotalPagado.Location = New System.Drawing.Point(213, 555)
        Me.txtTotalPagado.Name = "txtTotalPagado"
        Me.txtTotalPagado.Size = New System.Drawing.Size(97, 15)
        Me.txtTotalPagado.TabIndex = 124
        Me.txtTotalPagado.Text = "0.00"
        Me.txtTotalPagado.Visible = False
        '
        'txtTotalVenta
        '
        Me.txtTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVenta.ForeColor = System.Drawing.Color.Red
        Me.txtTotalVenta.Location = New System.Drawing.Point(213, 533)
        Me.txtTotalVenta.Name = "txtTotalVenta"
        Me.txtTotalVenta.Size = New System.Drawing.Size(93, 15)
        Me.txtTotalVenta.TabIndex = 122
        Me.txtTotalVenta.Text = "0.00"
        Me.txtTotalVenta.Visible = False
        '
        'lblVuelto
        '
        Me.lblVuelto.AutoSize = True
        Me.lblVuelto.BackColor = System.Drawing.Color.Transparent
        Me.lblVuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVuelto.ForeColor = System.Drawing.Color.Black
        Me.lblVuelto.Location = New System.Drawing.Point(124, 579)
        Me.lblVuelto.Name = "lblVuelto"
        Me.lblVuelto.Size = New System.Drawing.Size(43, 13)
        Me.lblVuelto.TabIndex = 125
        Me.lblVuelto.Text = "Vuelto"
        Me.lblVuelto.Visible = False
        '
        'lblTotalPagado
        '
        Me.lblTotalPagado.AutoSize = True
        Me.lblTotalPagado.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPagado.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPagado.Location = New System.Drawing.Point(124, 557)
        Me.lblTotalPagado.Name = "lblTotalPagado"
        Me.lblTotalPagado.Size = New System.Drawing.Size(83, 13)
        Me.lblTotalPagado.TabIndex = 123
        Me.lblTotalPagado.Text = "Total Pagado"
        Me.lblTotalPagado.Visible = False
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.AutoSize = True
        Me.lblTotalVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.ForeColor = System.Drawing.Color.Black
        Me.lblTotalVenta.Location = New System.Drawing.Point(124, 535)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(73, 13)
        Me.lblTotalVenta.TabIndex = 121
        Me.lblTotalVenta.Text = "Total Venta"
        Me.lblTotalVenta.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(2, 356)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(97, 13)
        Me.Label25.TabIndex = 112
        Me.Label25.Text = "Documento Cliente"
        '
        'LbldetalleVenta
        '
        Me.LbldetalleVenta.AutoSize = True
        Me.LbldetalleVenta.Location = New System.Drawing.Point(316, 356)
        Me.LbldetalleVenta.Name = "LbldetalleVenta"
        Me.LbldetalleVenta.Size = New System.Drawing.Size(71, 13)
        Me.LbldetalleVenta.TabIndex = 106
        Me.LbldetalleVenta.Text = "Detalle Venta"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Maroon
        Me.Label24.Location = New System.Drawing.Point(684, 546)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(36, 13)
        Me.Label24.TabIndex = 131
        Me.Label24.Text = "Total"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Maroon
        Me.Label26.Location = New System.Drawing.Point(503, 546)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 13)
        Me.Label26.TabIndex = 129
        Me.Label26.Text = "Impuesto"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Maroon
        Me.Label27.Location = New System.Drawing.Point(316, 546)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(54, 13)
        Me.Label27.TabIndex = 127
        Me.Label27.Text = "Subtotal"
        '
        'GrpConsignado
        '
        Me.GrpConsignado.Controls.Add(Me.Label28)
        Me.GrpConsignado.Controls.Add(Me.TxtReferencia)
        Me.GrpConsignado.Controls.Add(Me.txtTelfConsignado)
        Me.GrpConsignado.Controls.Add(Me.Label13)
        Me.GrpConsignado.Controls.Add(Me.RbtNombre3)
        Me.GrpConsignado.Controls.Add(Me.RbtDocumento3)
        Me.GrpConsignado.Controls.Add(Me.BtnConsignado)
        Me.GrpConsignado.Controls.Add(Me.CboDireccion2)
        Me.GrpConsignado.Controls.Add(Me.ChkCliente2)
        Me.GrpConsignado.Controls.Add(Me.TxtConsignado)
        Me.GrpConsignado.Controls.Add(Me.Label14)
        Me.GrpConsignado.Controls.Add(Me.Label16)
        Me.GrpConsignado.Controls.Add(Me.TxtNombConsignado)
        Me.GrpConsignado.Controls.Add(Me.TxtNroDocConsignado)
        Me.GrpConsignado.Location = New System.Drawing.Point(425, 133)
        Me.GrpConsignado.Name = "GrpConsignado"
        Me.GrpConsignado.Size = New System.Drawing.Size(417, 145)
        Me.GrpConsignado.TabIndex = 98
        Me.GrpConsignado.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(8, 123)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(59, 13)
        Me.Label28.TabIndex = 104
        Me.Label28.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(81, 121)
        Me.TxtReferencia.MaxLength = 85
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.ReadOnly = True
        Me.TxtReferencia.Size = New System.Drawing.Size(329, 20)
        Me.TxtReferencia.TabIndex = 103
        '
        'txtTelfConsignado
        '
        Me.txtTelfConsignado.Location = New System.Drawing.Point(81, 74)
        Me.txtTelfConsignado.Name = "txtTelfConsignado"
        Me.txtTelfConsignado.ReadOnly = True
        Me.txtTelfConsignado.Size = New System.Drawing.Size(330, 20)
        Me.txtTelfConsignado.TabIndex = 98
        Me.txtTelfConsignado.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 97
        Me.Label13.Text = "Teléfono"
        '
        'RbtNombre3
        '
        Me.RbtNombre3.AutoSize = True
        Me.RbtNombre3.Location = New System.Drawing.Point(69, 29)
        Me.RbtNombre3.Name = "RbtNombre3"
        Me.RbtNombre3.Size = New System.Drawing.Size(62, 17)
        Me.RbtNombre3.TabIndex = 3
        Me.RbtNombre3.Text = "Nombre"
        Me.RbtNombre3.UseVisualStyleBackColor = True
        '
        'RbtDocumento3
        '
        Me.RbtDocumento3.AutoSize = True
        Me.RbtDocumento3.Checked = True
        Me.RbtDocumento3.Location = New System.Drawing.Point(8, 29)
        Me.RbtDocumento3.Name = "RbtDocumento3"
        Me.RbtDocumento3.Size = New System.Drawing.Size(60, 17)
        Me.RbtDocumento3.TabIndex = 2
        Me.RbtDocumento3.TabStop = True
        Me.RbtDocumento3.Text = "Nº Doc"
        Me.RbtDocumento3.UseVisualStyleBackColor = True
        '
        'BtnConsignado
        '
        Me.BtnConsignado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsignado.Image = CType(resources.GetObject("BtnConsignado.Image"), System.Drawing.Image)
        Me.BtnConsignado.Location = New System.Drawing.Point(388, 28)
        Me.BtnConsignado.Name = "BtnConsignado"
        Me.BtnConsignado.Size = New System.Drawing.Size(24, 21)
        Me.BtnConsignado.TabIndex = 5
        Me.BtnConsignado.TabStop = False
        Me.BtnConsignado.UseVisualStyleBackColor = True
        '
        'CboDireccion2
        '
        Me.CboDireccion2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboDireccion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDireccion2.DropDownWidth = 370
        Me.CboDireccion2.FormattingEnabled = True
        Me.CboDireccion2.Items.AddRange(New Object() {" (SELECCIONE)"})
        Me.CboDireccion2.Location = New System.Drawing.Point(81, 97)
        Me.CboDireccion2.Name = "CboDireccion2"
        Me.CboDireccion2.Size = New System.Drawing.Size(330, 21)
        Me.CboDireccion2.TabIndex = 9
        '
        'ChkCliente2
        '
        Me.ChkCliente2.AutoSize = True
        Me.ChkCliente2.Location = New System.Drawing.Point(331, 10)
        Me.ChkCliente2.Name = "ChkCliente2"
        Me.ChkCliente2.Size = New System.Drawing.Size(84, 17)
        Me.ChkCliente2.TabIndex = 1
        Me.ChkCliente2.Text = "Es el Cliente"
        Me.ChkCliente2.UseVisualStyleBackColor = True
        '
        'TxtConsignado
        '
        Me.TxtConsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConsignado.Location = New System.Drawing.Point(133, 28)
        Me.TxtConsignado.MaxLength = 11
        Me.TxtConsignado.Name = "TxtConsignado"
        Me.TxtConsignado.Size = New System.Drawing.Size(253, 20)
        Me.TxtConsignado.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Consignado"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Dirección"
        '
        'TxtNombConsignado
        '
        Me.TxtNombConsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombConsignado.Location = New System.Drawing.Point(81, 52)
        Me.TxtNombConsignado.Name = "TxtNombConsignado"
        Me.TxtNombConsignado.ReadOnly = True
        Me.TxtNombConsignado.Size = New System.Drawing.Size(330, 20)
        Me.TxtNombConsignado.TabIndex = 7
        Me.TxtNombConsignado.TabStop = False
        '
        'TxtNroDocConsignado
        '
        Me.TxtNroDocConsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroDocConsignado.Location = New System.Drawing.Point(6, 52)
        Me.TxtNroDocConsignado.MaxLength = 11
        Me.TxtNroDocConsignado.Name = "TxtNroDocConsignado"
        Me.TxtNroDocConsignado.ReadOnly = True
        Me.TxtNroDocConsignado.Size = New System.Drawing.Size(74, 20)
        Me.TxtNroDocConsignado.TabIndex = 6
        Me.TxtNroDocConsignado.TabStop = False
        '
        'ChkArticulos
        '
        Me.ChkArticulos.AutoSize = True
        Me.ChkArticulos.Enabled = False
        Me.ChkArticulos.Location = New System.Drawing.Point(521, 353)
        Me.ChkArticulos.Name = "ChkArticulos"
        Me.ChkArticulos.Size = New System.Drawing.Size(63, 17)
        Me.ChkArticulos.TabIndex = 103
        Me.ChkArticulos.Text = "Artículo"
        Me.ChkArticulos.UseVisualStyleBackColor = True
        '
        'GrpCliente
        '
        Me.GrpCliente.Controls.Add(Me.RbtNombre)
        Me.GrpCliente.Controls.Add(Me.RbtDocumento)
        Me.GrpCliente.Controls.Add(Me.LblPasajero)
        Me.GrpCliente.Controls.Add(Me.TxtTelfCliente)
        Me.GrpCliente.Controls.Add(Me.Label18)
        Me.GrpCliente.Controls.Add(Me.CboContacto)
        Me.GrpCliente.Controls.Add(Me.CboDireccion)
        Me.GrpCliente.Controls.Add(Me.ChkCliente1)
        Me.GrpCliente.Controls.Add(Me.Label19)
        Me.GrpCliente.Controls.Add(Me.Label20)
        Me.GrpCliente.Controls.Add(Me.Label21)
        Me.GrpCliente.Controls.Add(Me.TxtNomCliente)
        Me.GrpCliente.Controls.Add(Me.TxtNroDocContacto)
        Me.GrpCliente.Controls.Add(Me.TxtNroDocCliente)
        Me.GrpCliente.Controls.Add(Me.BtnCliente)
        Me.GrpCliente.Controls.Add(Me.TxtCliente)
        Me.GrpCliente.Controls.Add(Me.Label22)
        Me.GrpCliente.Location = New System.Drawing.Point(3, 133)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(417, 188)
        Me.GrpCliente.TabIndex = 97
        Me.GrpCliente.TabStop = False
        '
        'RbtNombre
        '
        Me.RbtNombre.AutoSize = True
        Me.RbtNombre.Location = New System.Drawing.Point(68, 29)
        Me.RbtNombre.Name = "RbtNombre"
        Me.RbtNombre.Size = New System.Drawing.Size(62, 17)
        Me.RbtNombre.TabIndex = 2
        Me.RbtNombre.Text = "Nombre"
        Me.RbtNombre.UseVisualStyleBackColor = True
        '
        'RbtDocumento
        '
        Me.RbtDocumento.AutoSize = True
        Me.RbtDocumento.Checked = True
        Me.RbtDocumento.Location = New System.Drawing.Point(7, 29)
        Me.RbtDocumento.Name = "RbtDocumento"
        Me.RbtDocumento.Size = New System.Drawing.Size(60, 17)
        Me.RbtDocumento.TabIndex = 1
        Me.RbtDocumento.TabStop = True
        Me.RbtDocumento.Text = "Nº Doc"
        Me.RbtDocumento.UseVisualStyleBackColor = True
        '
        'LblPasajero
        '
        Me.LblPasajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPasajero.ForeColor = System.Drawing.Color.Red
        Me.LblPasajero.Location = New System.Drawing.Point(325, 55)
        Me.LblPasajero.Name = "LblPasajero"
        Me.LblPasajero.Size = New System.Drawing.Size(81, 13)
        Me.LblPasajero.TabIndex = 94
        Me.LblPasajero.Text = "FRECUENTE"
        Me.LblPasajero.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LblPasajero.Visible = False
        '
        'TxtTelfCliente
        '
        Me.TxtTelfCliente.Location = New System.Drawing.Point(80, 74)
        Me.TxtTelfCliente.Name = "TxtTelfCliente"
        Me.TxtTelfCliente.ReadOnly = True
        Me.TxtTelfCliente.Size = New System.Drawing.Size(330, 20)
        Me.TxtTelfCliente.TabIndex = 96
        Me.TxtTelfCliente.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 95
        Me.Label18.Text = "Teléfono"
        '
        'CboContacto
        '
        Me.CboContacto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboContacto.Enabled = False
        Me.CboContacto.FormattingEnabled = True
        Me.CboContacto.Items.AddRange(New Object() {" (SELECCIONE)"})
        Me.CboContacto.Location = New System.Drawing.Point(80, 139)
        Me.CboContacto.Name = "CboContacto"
        Me.CboContacto.Size = New System.Drawing.Size(330, 21)
        Me.CboContacto.TabIndex = 12
        '
        'CboDireccion
        '
        Me.CboDireccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDireccion.DropDownWidth = 450
        Me.CboDireccion.FormattingEnabled = True
        Me.CboDireccion.Items.AddRange(New Object() {" (SELECCIONE)"})
        Me.CboDireccion.Location = New System.Drawing.Point(80, 97)
        Me.CboDireccion.Name = "CboDireccion"
        Me.CboDireccion.Size = New System.Drawing.Size(330, 21)
        Me.CboDireccion.TabIndex = 8
        '
        'ChkCliente1
        '
        Me.ChkCliente1.AutoSize = True
        Me.ChkCliente1.Enabled = False
        Me.ChkCliente1.Location = New System.Drawing.Point(330, 122)
        Me.ChkCliente1.Name = "ChkCliente1"
        Me.ChkCliente1.Size = New System.Drawing.Size(84, 17)
        Me.ChkCliente1.TabIndex = 9
        Me.ChkCliente1.Text = "Es el Cliente"
        Me.ChkCliente1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(4, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Cliente"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(4, 123)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 13)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Contacto"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(4, 100)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Dirección"
        '
        'TxtNomCliente
        '
        Me.TxtNomCliente.Location = New System.Drawing.Point(80, 51)
        Me.TxtNomCliente.Name = "TxtNomCliente"
        Me.TxtNomCliente.ReadOnly = True
        Me.TxtNomCliente.Size = New System.Drawing.Size(330, 20)
        Me.TxtNomCliente.TabIndex = 6
        Me.TxtNomCliente.TabStop = False
        '
        'TxtNroDocContacto
        '
        Me.TxtNroDocContacto.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNroDocContacto.Location = New System.Drawing.Point(5, 140)
        Me.TxtNroDocContacto.Name = "TxtNroDocContacto"
        Me.TxtNroDocContacto.Size = New System.Drawing.Size(74, 20)
        Me.TxtNroDocContacto.TabIndex = 11
        Me.TxtNroDocContacto.TabStop = False
        '
        'TxtNroDocCliente
        '
        Me.TxtNroDocCliente.Location = New System.Drawing.Point(5, 51)
        Me.TxtNroDocCliente.Name = "TxtNroDocCliente"
        Me.TxtNroDocCliente.ReadOnly = True
        Me.TxtNroDocCliente.Size = New System.Drawing.Size(74, 20)
        Me.TxtNroDocCliente.TabIndex = 5
        Me.TxtNroDocCliente.TabStop = False
        '
        'BtnCliente
        '
        Me.BtnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCliente.Image = CType(resources.GetObject("BtnCliente.Image"), System.Drawing.Image)
        Me.BtnCliente.Location = New System.Drawing.Point(387, 28)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(24, 21)
        Me.BtnCliente.TabIndex = 4
        Me.BtnCliente.TabStop = False
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'TxtCliente
        '
        Me.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCliente.Location = New System.Drawing.Point(134, 28)
        Me.TxtCliente.MaxLength = 11
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(252, 20)
        Me.TxtCliente.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(30, -16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Tipo Entrega"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID1"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ID2"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Bulto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Cargo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Peso/Volumen"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 130
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Seguro"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Costo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Sub Neto"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cargo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Seguro"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 130
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ID1"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ID2"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Bulto"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 70
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Costo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Cargo"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 122
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Seguro"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Costo"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 70
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Seguro"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 118
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Cargo"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Peso/Volumen"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 130
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Sub Neto"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 130
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Sub Neto"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'frmCancelarPCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 637)
        Me.Controls.Add(Me.TabGuia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCancelarPCE"
        Me.Text = "Canje Guía de Envío"
        Me.TabGuia.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GrdDocumentosCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpOrigen.ResumeLayout(False)
        Me.GrpOrigen.PerformLayout()
        Me.GrpCondicionVenta.ResumeLayout(False)
        Me.GrpCondicionVenta.PerformLayout()
        Me.GrpDestino.ResumeLayout(False)
        Me.GrpDestino.PerformLayout()
        Me.GrpDescuento.ResumeLayout(False)
        Me.GrpDescuento.PerformLayout()
        Me.Grpa.ResumeLayout(False)
        Me.Grpa.PerformLayout()
        CType(Me.GrdDetalleVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpConsignado.ResumeLayout(False)
        Me.GrpConsignado.PerformLayout()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabGuia As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents TxtGuia As System.Windows.Forms.TextBox
    Friend WithEvents TxtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents DgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents DtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents CboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents CboCiudadDestino As System.Windows.Forms.ComboBox
    Friend WithEvents CboAgenciaOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CboCiudadOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnCA As System.Windows.Forms.Button
    Friend WithEvents BtnPCE As System.Windows.Forms.Button
    Friend WithEvents LblRegistros As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GrdDocumentosCliente As System.Windows.Forms.DataGridView
    Friend WithEvents ID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seguro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrpOrigen As System.Windows.Forms.GroupBox
    Friend WithEvents LblCiudad As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblAgencia As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents GrpCondicionVenta As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNroTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents LblNroTarj As System.Windows.Forms.Label
    Friend WithEvents CboTipoEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents LblTarjeta As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CboTarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents CboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents GrpDestino As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCiudadDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CboAgenciaDest As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents LblNroBoletaFact As System.Windows.Forms.Label
    Friend WithEvents LblFechaServidor As System.Windows.Forms.Label
    Friend WithEvents LblSerie As System.Windows.Forms.Label
    Friend WithEvents GrpDescuento As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents lbDescDescto As System.Windows.Forms.Label
    Friend WithEvents txtDescDescto As System.Windows.Forms.TextBox
    Friend WithEvents LblTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents ChkVolumetrico As System.Windows.Forms.CheckBox
    Friend WithEvents CboTipoTarifa As System.Windows.Forms.ComboBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblTipoTarifa As System.Windows.Forms.Label
    Friend WithEvents TxtImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents BtnCargAseg As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtMontoBase As System.Windows.Forms.TextBox
    Friend WithEvents lblMontoBase As System.Windows.Forms.Label
    Friend WithEvents txtTotalSobre As System.Windows.Forms.TextBox
    Friend WithEvents chkSobres As System.Windows.Forms.CheckBox
    Friend WithEvents txtCantidadSobres As System.Windows.Forms.TextBox
    Friend WithEvents ChkCargo As System.Windows.Forms.CheckBox
    Friend WithEvents Grpa As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtBoleto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GrdDetalleVenta As System.Windows.Forms.DataGridView
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bulto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Volumen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sub_Neto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtVuelto As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagado As System.Windows.Forms.Label
    Friend WithEvents txtTotalVenta As System.Windows.Forms.Label
    Friend WithEvents lblVuelto As System.Windows.Forms.Label
    Friend WithEvents lblTotalPagado As System.Windows.Forms.Label
    Friend WithEvents lblTotalVenta As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents LbldetalleVenta As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GrpConsignado As System.Windows.Forms.GroupBox
    Friend WithEvents txtTelfConsignado As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents RbtNombre3 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtDocumento3 As System.Windows.Forms.RadioButton
    Friend WithEvents BtnConsignado As System.Windows.Forms.Button
    Friend WithEvents CboDireccion2 As System.Windows.Forms.ComboBox
    Friend WithEvents ChkCliente2 As System.Windows.Forms.CheckBox
    Friend WithEvents TxtConsignado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtNombConsignado As System.Windows.Forms.TextBox
    Friend WithEvents TxtNroDocConsignado As System.Windows.Forms.TextBox
    Friend WithEvents ChkArticulos As System.Windows.Forms.CheckBox
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents RbtNombre As System.Windows.Forms.RadioButton
    Friend WithEvents RbtDocumento As System.Windows.Forms.RadioButton
    Friend WithEvents LblPasajero As System.Windows.Forms.Label
    Friend WithEvents TxtTelfCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CboContacto As System.Windows.Forms.ComboBox
    Friend WithEvents CboDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents ChkCliente1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtNomCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtNroDocContacto As System.Windows.Forms.TextBox
    Friend WithEvents TxtNroDocCliente As System.Windows.Forms.TextBox
    Friend WithEvents BtnCliente As System.Windows.Forms.Button
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents btnDescuento As System.Windows.Forms.Button
End Class
