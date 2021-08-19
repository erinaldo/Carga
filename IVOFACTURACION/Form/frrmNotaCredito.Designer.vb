<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaCredito))
        Me.tabNotaCredito = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.rbtBoleta = New System.Windows.Forms.RadioButton()
        Me.rbtFactura = New System.Windows.Forms.RadioButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.tabEmision = New System.Windows.Forms.TabPage()
        Me.cboOperacion = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabComprobante = New System.Windows.Forms.TabControl()
        Me.tabNC = New System.Windows.Forms.TabPage()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtGlosaNotaCredito = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtImpuesto = New System.Windows.Forms.TextBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpFechaNotaCredito = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabFactura = New System.Windows.Forms.TabPage()
        Me.txtTotalNuevo = New System.Windows.Forms.TextBox()
        Me.txtImpuestoNuevo = New System.Windows.Forms.TextBox()
        Me.txtSubtotalNuevo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtpFechaNuevo = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.grbClienteNuevo = New System.Windows.Forms.GroupBox()
        Me.txtNombreNuevo = New System.Windows.Forms.TextBox()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboDireccionNuevo = New System.Windows.Forms.ComboBox()
        Me.txtNumeroDocumentoNuevo = New System.Windows.Forms.TextBox()
        Me.lblNumeroNuevo = New System.Windows.Forms.Label()
        Me.lblSerieNuevo = New System.Windows.Forms.Label()
        Me.lblComprobanteNuevo = New System.Windows.Forms.Label()
        Me.cboTipoComprobanteNuevo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNumeroDocumento = New System.Windows.Forms.Label()
        Me.grbComprobante = New System.Windows.Forms.GroupBox()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabNotaCredito.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmision.SuspendLayout()
        Me.tabComprobante.SuspendLayout()
        Me.tabNC.SuspendLayout()
        Me.tabFactura.SuspendLayout()
        Me.grbClienteNuevo.SuspendLayout()
        Me.grbCliente.SuspendLayout()
        Me.grbComprobante.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabNotaCredito
        '
        Me.tabNotaCredito.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabNotaCredito.Controls.Add(Me.tabLista)
        Me.tabNotaCredito.Controls.Add(Me.tabEmision)
        Me.tabNotaCredito.Location = New System.Drawing.Point(10, 30)
        Me.tabNotaCredito.Name = "tabNotaCredito"
        Me.tabNotaCredito.SelectedIndex = 0
        Me.tabNotaCredito.Size = New System.Drawing.Size(708, 433)
        Me.tabNotaCredito.TabIndex = 2
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.rbtBoleta)
        Me.tabLista.Controls.Add(Me.rbtFactura)
        Me.tabLista.Controls.Add(Me.btnBuscar)
        Me.tabLista.Controls.Add(Me.txtNumeroComprobante)
        Me.tabLista.Controls.Add(Me.Label15)
        Me.tabLista.Controls.Add(Me.dtpFechaFin)
        Me.tabLista.Controls.Add(Me.dtpFechaInicio)
        Me.tabLista.Controls.Add(Me.Label16)
        Me.tabLista.Controls.Add(Me.Label25)
        Me.tabLista.Controls.Add(Me.dgvLista)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(700, 407)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'rbtBoleta
        '
        Me.rbtBoleta.AutoSize = True
        Me.rbtBoleta.Location = New System.Drawing.Point(373, 14)
        Me.rbtBoleta.Name = "rbtBoleta"
        Me.rbtBoleta.Size = New System.Drawing.Size(55, 17)
        Me.rbtBoleta.TabIndex = 54
        Me.rbtBoleta.Text = "Boleta"
        Me.rbtBoleta.UseVisualStyleBackColor = True
        '
        'rbtFactura
        '
        Me.rbtFactura.AutoSize = True
        Me.rbtFactura.Checked = True
        Me.rbtFactura.Location = New System.Drawing.Point(287, 14)
        Me.rbtFactura.Name = "rbtFactura"
        Me.rbtFactura.Size = New System.Drawing.Size(61, 17)
        Me.rbtFactura.TabIndex = 54
        Me.rbtFactura.TabStop = True
        Me.rbtFactura.Text = "Factura"
        Me.rbtFactura.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(609, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(76, 33)
        Me.btnBuscar.TabIndex = 53
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(373, 41)
        Me.txtNumeroComprobante.MaxLength = 20
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(128, 20)
        Me.txtNumeroComprobante.TabIndex = 52
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(284, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Comprobante"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(95, 44)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(83, 20)
        Me.dtpFechaFin.TabIndex = 50
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(95, 17)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtpFechaInicio.TabIndex = 49
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Fecha Fin"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 19)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 46
        Me.Label25.Text = "Fecha Inicio"
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.Location = New System.Drawing.Point(16, 75)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(669, 321)
        Me.dgvLista.TabIndex = 0
        '
        'tabEmision
        '
        Me.tabEmision.Controls.Add(Me.cboOperacion)
        Me.tabEmision.Controls.Add(Me.Label5)
        Me.tabEmision.Controls.Add(Me.tabComprobante)
        Me.tabEmision.Controls.Add(Me.grbCliente)
        Me.tabEmision.Controls.Add(Me.grbComprobante)
        Me.tabEmision.Location = New System.Drawing.Point(4, 22)
        Me.tabEmision.Name = "tabEmision"
        Me.tabEmision.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEmision.Size = New System.Drawing.Size(700, 407)
        Me.tabEmision.TabIndex = 1
        Me.tabEmision.Text = "Emisión"
        Me.tabEmision.UseVisualStyleBackColor = True
        '
        'cboOperacion
        '
        Me.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperacion.FormattingEnabled = True
        Me.cboOperacion.Location = New System.Drawing.Point(86, 152)
        Me.cboOperacion.Name = "cboOperacion"
        Me.cboOperacion.Size = New System.Drawing.Size(219, 21)
        Me.cboOperacion.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Operación"
        '
        'tabComprobante
        '
        Me.tabComprobante.Controls.Add(Me.tabNC)
        Me.tabComprobante.Controls.Add(Me.tabFactura)
        Me.tabComprobante.Location = New System.Drawing.Point(15, 188)
        Me.tabComprobante.Name = "tabComprobante"
        Me.tabComprobante.SelectedIndex = 0
        Me.tabComprobante.Size = New System.Drawing.Size(665, 216)
        Me.tabComprobante.TabIndex = 5
        '
        'tabNC
        '
        Me.tabNC.Controls.Add(Me.lblNumero)
        Me.tabNC.Controls.Add(Me.lblSerie)
        Me.tabNC.Controls.Add(Me.Label27)
        Me.tabNC.Controls.Add(Me.txtGlosaNotaCredito)
        Me.tabNC.Controls.Add(Me.txtTotal)
        Me.tabNC.Controls.Add(Me.txtImpuesto)
        Me.tabNC.Controls.Add(Me.txtSubtotal)
        Me.tabNC.Controls.Add(Me.Label13)
        Me.tabNC.Controls.Add(Me.dtpFechaNotaCredito)
        Me.tabNC.Controls.Add(Me.Label12)
        Me.tabNC.Controls.Add(Me.Label11)
        Me.tabNC.Controls.Add(Me.Label18)
        Me.tabNC.Controls.Add(Me.Label7)
        Me.tabNC.Location = New System.Drawing.Point(4, 22)
        Me.tabNC.Name = "tabNC"
        Me.tabNC.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNC.Size = New System.Drawing.Size(657, 190)
        Me.tabNC.TabIndex = 0
        Me.tabNC.Text = "Nota de Crédito"
        Me.tabNC.UseVisualStyleBackColor = True
        '
        'lblNumero
        '
        Me.lblNumero.BackColor = System.Drawing.Color.White
        Me.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.ForeColor = System.Drawing.Color.Black
        Me.lblNumero.Location = New System.Drawing.Point(564, 28)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(66, 18)
        Me.lblNumero.TabIndex = 110
        Me.lblNumero.Text = "00000001"
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSerie
        '
        Me.lblSerie.BackColor = System.Drawing.Color.White
        Me.lblSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSerie.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerie.ForeColor = System.Drawing.Color.Black
        Me.lblSerie.Location = New System.Drawing.Point(525, 28)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(40, 18)
        Me.lblSerie.TabIndex = 109
        Me.lblSerie.Text = "001"
        Me.lblSerie.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.MidnightBlue
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(525, 4)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 24)
        Me.Label27.TabIndex = 108
        Me.Label27.Text = "NOTA CREDITO"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtGlosaNotaCredito
        '
        Me.txtGlosaNotaCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosaNotaCredito.Location = New System.Drawing.Point(67, 54)
        Me.txtGlosaNotaCredito.Multiline = True
        Me.txtGlosaNotaCredito.Name = "txtGlosaNotaCredito"
        Me.txtGlosaNotaCredito.Size = New System.Drawing.Size(560, 82)
        Me.txtGlosaNotaCredito.TabIndex = 107
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(545, 151)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(82, 20)
        Me.txtTotal.TabIndex = 106
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImpuesto
        '
        Me.txtImpuesto.Location = New System.Drawing.Point(318, 151)
        Me.txtImpuesto.Name = "txtImpuesto"
        Me.txtImpuesto.ReadOnly = True
        Me.txtImpuesto.Size = New System.Drawing.Size(82, 20)
        Me.txtImpuesto.TabIndex = 106
        Me.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(67, 151)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(82, 20)
        Me.txtSubtotal.TabIndex = 106
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(478, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Total"
        '
        'dtpFechaNotaCredito
        '
        Me.dtpFechaNotaCredito.Enabled = False
        Me.dtpFechaNotaCredito.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNotaCredito.Location = New System.Drawing.Point(67, 14)
        Me.dtpFechaNotaCredito.Name = "dtpFechaNotaCredito"
        Me.dtpFechaNotaCredito.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaNotaCredito.TabIndex = 105
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(236, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Impuesto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Subtotal"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Glosa"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fecha"
        '
        'tabFactura
        '
        Me.tabFactura.Controls.Add(Me.txtTotalNuevo)
        Me.tabFactura.Controls.Add(Me.txtImpuestoNuevo)
        Me.tabFactura.Controls.Add(Me.txtSubtotalNuevo)
        Me.tabFactura.Controls.Add(Me.Label22)
        Me.tabFactura.Controls.Add(Me.Label23)
        Me.tabFactura.Controls.Add(Me.Label24)
        Me.tabFactura.Controls.Add(Me.dtpFechaNuevo)
        Me.tabFactura.Controls.Add(Me.Label21)
        Me.tabFactura.Controls.Add(Me.grbClienteNuevo)
        Me.tabFactura.Controls.Add(Me.lblNumeroNuevo)
        Me.tabFactura.Controls.Add(Me.lblSerieNuevo)
        Me.tabFactura.Controls.Add(Me.lblComprobanteNuevo)
        Me.tabFactura.Controls.Add(Me.cboTipoComprobanteNuevo)
        Me.tabFactura.Controls.Add(Me.Label14)
        Me.tabFactura.Location = New System.Drawing.Point(4, 22)
        Me.tabFactura.Name = "tabFactura"
        Me.tabFactura.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFactura.Size = New System.Drawing.Size(657, 190)
        Me.tabFactura.TabIndex = 1
        Me.tabFactura.Text = "Nuevo Comprobante"
        Me.tabFactura.UseVisualStyleBackColor = True
        '
        'txtTotalNuevo
        '
        Me.txtTotalNuevo.Location = New System.Drawing.Point(549, 155)
        Me.txtTotalNuevo.Name = "txtTotalNuevo"
        Me.txtTotalNuevo.ReadOnly = True
        Me.txtTotalNuevo.Size = New System.Drawing.Size(82, 20)
        Me.txtTotalNuevo.TabIndex = 114
        Me.txtTotalNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImpuestoNuevo
        '
        Me.txtImpuestoNuevo.Location = New System.Drawing.Point(329, 155)
        Me.txtImpuestoNuevo.Name = "txtImpuestoNuevo"
        Me.txtImpuestoNuevo.ReadOnly = True
        Me.txtImpuestoNuevo.Size = New System.Drawing.Size(82, 20)
        Me.txtImpuestoNuevo.TabIndex = 115
        Me.txtImpuestoNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotalNuevo
        '
        Me.txtSubtotalNuevo.Location = New System.Drawing.Point(71, 155)
        Me.txtSubtotalNuevo.Name = "txtSubtotalNuevo"
        Me.txtSubtotalNuevo.ReadOnly = True
        Me.txtSubtotalNuevo.Size = New System.Drawing.Size(82, 20)
        Me.txtSubtotalNuevo.TabIndex = 116
        Me.txtSubtotalNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(478, 158)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "Total"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(240, 158)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Impuesto"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(16, 158)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(46, 13)
        Me.Label24.TabIndex = 113
        Me.Label24.Text = "Subtotal"
        '
        'dtpFechaNuevo
        '
        Me.dtpFechaNuevo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNuevo.Location = New System.Drawing.Point(336, 21)
        Me.dtpFechaNuevo.Name = "dtpFechaNuevo"
        Me.dtpFechaNuevo.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaNuevo.TabIndex = 110
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(281, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 109
        Me.Label21.Text = "Fecha"
        '
        'grbClienteNuevo
        '
        Me.grbClienteNuevo.Controls.Add(Me.txtNombreNuevo)
        Me.grbClienteNuevo.Controls.Add(Me.btnCliente)
        Me.grbClienteNuevo.Controls.Add(Me.Label19)
        Me.grbClienteNuevo.Controls.Add(Me.Label20)
        Me.grbClienteNuevo.Controls.Add(Me.cboDireccionNuevo)
        Me.grbClienteNuevo.Controls.Add(Me.txtNumeroDocumentoNuevo)
        Me.grbClienteNuevo.Location = New System.Drawing.Point(9, 58)
        Me.grbClienteNuevo.Name = "grbClienteNuevo"
        Me.grbClienteNuevo.Size = New System.Drawing.Size(633, 75)
        Me.grbClienteNuevo.TabIndex = 108
        Me.grbClienteNuevo.TabStop = False
        Me.grbClienteNuevo.Text = "Cliente"
        '
        'txtNombreNuevo
        '
        Me.txtNombreNuevo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreNuevo.Enabled = False
        Me.txtNombreNuevo.Location = New System.Drawing.Point(188, 18)
        Me.txtNombreNuevo.MaxLength = 11
        Me.txtNombreNuevo.Name = "txtNombreNuevo"
        Me.txtNombreNuevo.Size = New System.Drawing.Size(408, 20)
        Me.txtNombreNuevo.TabIndex = 96
        '
        'btnCliente
        '
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCliente.Location = New System.Drawing.Point(600, 16)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(24, 23)
        Me.btnCliente.TabIndex = 97
        Me.btnCliente.TabStop = False
        Me.btnCliente.Text = "..."
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Dirección"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Nº Documento"
        '
        'cboDireccionNuevo
        '
        Me.cboDireccionNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDireccionNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDireccionNuevo.FormattingEnabled = True
        Me.cboDireccionNuevo.Location = New System.Drawing.Point(95, 44)
        Me.cboDireccionNuevo.Name = "cboDireccionNuevo"
        Me.cboDireccionNuevo.Size = New System.Drawing.Size(527, 21)
        Me.cboDireccionNuevo.TabIndex = 103
        '
        'txtNumeroDocumentoNuevo
        '
        Me.txtNumeroDocumentoNuevo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroDocumentoNuevo.Location = New System.Drawing.Point(95, 18)
        Me.txtNumeroDocumentoNuevo.MaxLength = 11
        Me.txtNumeroDocumentoNuevo.Name = "txtNumeroDocumentoNuevo"
        Me.txtNumeroDocumentoNuevo.Size = New System.Drawing.Size(92, 20)
        Me.txtNumeroDocumentoNuevo.TabIndex = 96
        '
        'lblNumeroNuevo
        '
        Me.lblNumeroNuevo.BackColor = System.Drawing.Color.White
        Me.lblNumeroNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumeroNuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroNuevo.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroNuevo.Location = New System.Drawing.Point(581, 29)
        Me.lblNumeroNuevo.Name = "lblNumeroNuevo"
        Me.lblNumeroNuevo.Size = New System.Drawing.Size(62, 18)
        Me.lblNumeroNuevo.TabIndex = 107
        Me.lblNumeroNuevo.Text = "0000001"
        Me.lblNumeroNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSerieNuevo
        '
        Me.lblSerieNuevo.BackColor = System.Drawing.Color.White
        Me.lblSerieNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSerieNuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerieNuevo.ForeColor = System.Drawing.Color.Black
        Me.lblSerieNuevo.Location = New System.Drawing.Point(542, 29)
        Me.lblSerieNuevo.Name = "lblSerieNuevo"
        Me.lblSerieNuevo.Size = New System.Drawing.Size(40, 18)
        Me.lblSerieNuevo.TabIndex = 106
        Me.lblSerieNuevo.Text = "001"
        Me.lblSerieNuevo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblComprobanteNuevo
        '
        Me.lblComprobanteNuevo.BackColor = System.Drawing.Color.MidnightBlue
        Me.lblComprobanteNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobanteNuevo.ForeColor = System.Drawing.Color.White
        Me.lblComprobanteNuevo.Location = New System.Drawing.Point(542, 5)
        Me.lblComprobanteNuevo.Name = "lblComprobanteNuevo"
        Me.lblComprobanteNuevo.Size = New System.Drawing.Size(102, 24)
        Me.lblComprobanteNuevo.TabIndex = 105
        Me.lblComprobanteNuevo.Text = "NOTA CREDITO"
        Me.lblComprobanteNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboTipoComprobanteNuevo
        '
        Me.cboTipoComprobanteNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobanteNuevo.FormattingEnabled = True
        Me.cboTipoComprobanteNuevo.Items.AddRange(New Object() {"(SELECCIONE)", "FACTURA", "BOLETA"})
        Me.cboTipoComprobanteNuevo.Location = New System.Drawing.Point(71, 18)
        Me.cboTipoComprobanteNuevo.Name = "cboTipoComprobanteNuevo"
        Me.cboTipoComprobanteNuevo.Size = New System.Drawing.Size(110, 21)
        Me.cboTipoComprobanteNuevo.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Tipo"
        '
        'grbCliente
        '
        Me.grbCliente.Controls.Add(Me.Label9)
        Me.grbCliente.Controls.Add(Me.lblRazonSocial)
        Me.grbCliente.Controls.Add(Me.lblNumeroDocumento)
        Me.grbCliente.Controls.Add(Me.Label8)
        Me.grbCliente.Controls.Add(Me.txtNumeroDocumento)
        Me.grbCliente.Location = New System.Drawing.Point(15, 90)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(665, 47)
        Me.grbCliente.TabIndex = 3
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Cliente"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(220, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Razón Social"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(304, 21)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(342, 13)
        Me.lblRazonSocial.TabIndex = 0
        Me.lblRazonSocial.Text = "XXX"
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(94, 21)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(107, 13)
        Me.lblNumeroDocumento.TabIndex = 0
        Me.lblNumeroDocumento.Text = "12345678"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Nº Documento"
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(94, 25)
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(107, 13)
        Me.txtNumeroDocumento.TabIndex = 0
        '
        'grbComprobante
        '
        Me.grbComprobante.Controls.Add(Me.cboTipoComprobante)
        Me.grbComprobante.Controls.Add(Me.txtComprobante)
        Me.grbComprobante.Controls.Add(Me.lblTotal)
        Me.grbComprobante.Controls.Add(Me.lblImpuesto)
        Me.grbComprobante.Controls.Add(Me.Label6)
        Me.grbComprobante.Controls.Add(Me.lblSubtotal)
        Me.grbComprobante.Controls.Add(Me.Label4)
        Me.grbComprobante.Controls.Add(Me.lblFecha)
        Me.grbComprobante.Controls.Add(Me.Label3)
        Me.grbComprobante.Controls.Add(Me.Label2)
        Me.grbComprobante.Controls.Add(Me.Label10)
        Me.grbComprobante.Controls.Add(Me.Label1)
        Me.grbComprobante.Location = New System.Drawing.Point(15, 9)
        Me.grbComprobante.Name = "grbComprobante"
        Me.grbComprobante.Size = New System.Drawing.Size(665, 72)
        Me.grbComprobante.TabIndex = 2
        Me.grbComprobante.TabStop = False
        Me.grbComprobante.Text = "Comprobante"
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"FACTURA", "BOLETA"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(71, 20)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(110, 21)
        Me.cboTipoComprobante.TabIndex = 0
        '
        'txtComprobante
        '
        Me.txtComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobante.Location = New System.Drawing.Point(306, 19)
        Me.txtComprobante.MaxLength = 15
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(130, 20)
        Me.txtComprobante.TabIndex = 1
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(565, 50)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(81, 13)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "0.00"
        '
        'lblImpuesto
        '
        Me.lblImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpuesto.Location = New System.Drawing.Point(303, 50)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(81, 13)
        Me.lblImpuesto.TabIndex = 0
        Me.lblImpuesto.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(478, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.Location = New System.Drawing.Point(72, 50)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(81, 13)
        Me.lblSubtotal.TabIndex = 0
        Me.lblSubtotal.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(220, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Impuesto"
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(565, 23)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(81, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "12/05/2016"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Subtotal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(478, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Emisión"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Tipo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comprobante"
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbConsultar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(726, 25)
        Me.tool.TabIndex = 9
        Me.tool.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "Nuevo"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "Consultar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "Grabar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'frmNotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 470)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabNotaCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNotaCredito"
        Me.Text = "Nota de Crédito / Anulación"
        Me.tabNotaCredito.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        Me.tabLista.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmision.ResumeLayout(False)
        Me.tabEmision.PerformLayout()
        Me.tabComprobante.ResumeLayout(False)
        Me.tabNC.ResumeLayout(False)
        Me.tabNC.PerformLayout()
        Me.tabFactura.ResumeLayout(False)
        Me.tabFactura.PerformLayout()
        Me.grbClienteNuevo.ResumeLayout(False)
        Me.grbClienteNuevo.PerformLayout()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.grbComprobante.ResumeLayout(False)
        Me.grbComprobante.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabNotaCredito As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents tabEmision As System.Windows.Forms.TabPage
    Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents grbComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblImpuesto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents cboOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNotaCredito As System.Windows.Forms.DateTimePicker
    Friend WithEvents tabComprobante As System.Windows.Forms.TabControl
    Friend WithEvents tabNC As System.Windows.Forms.TabPage
    Friend WithEvents tabFactura As System.Windows.Forms.TabPage
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboTipoComprobanteNuevo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroNuevo As System.Windows.Forms.Label
    Friend WithEvents lblSerieNuevo As System.Windows.Forms.Label
    Friend WithEvents lblComprobanteNuevo As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtGlosaNotaCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents grbClienteNuevo As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreNuevo As System.Windows.Forms.TextBox
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboDireccionNuevo As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumeroDocumentoNuevo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNuevo As System.Windows.Forms.TextBox
    Friend WithEvents txtImpuestoNuevo As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotalNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNuevo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents rbtBoleta As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFactura As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
