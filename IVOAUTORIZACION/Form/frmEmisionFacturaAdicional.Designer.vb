<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmisionFacturaAdicional
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmisionFacturaAdicional))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabFacturaAdicional = New System.Windows.Forms.TabControl()
        Me.tabBuscar = New System.Windows.Forms.TabPage()
        Me.cboFacturado = New System.Windows.Forms.ComboBox()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.tabEmision = New System.Windows.Forms.TabPage()
        Me.grbOperacion = New System.Windows.Forms.GroupBox()
        Me.dgvOperacion = New System.Windows.Forms.DataGridView()
        Me.grbFormaPago = New System.Windows.Forms.GroupBox()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumeroTarjeta = New System.Windows.Forms.TextBox()
        Me.LblNroTarj = New System.Windows.Forms.Label()
        Me.cboTarjeta = New System.Windows.Forms.ComboBox()
        Me.LblTarjeta = New System.Windows.Forms.Label()
        Me.LblFechaServidor = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.lblTipoComprobante = New System.Windows.Forms.Label()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDireccion = New System.Windows.Forms.ComboBox()
        Me.txtNumeroDocumento = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabFacturaAdicional.SuspendLayout()
        Me.tabBuscar.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmision.SuspendLayout()
        Me.grbOperacion.SuspendLayout()
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFormaPago.SuspendLayout()
        Me.grbCliente.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabFacturaAdicional
        '
        Me.tabFacturaAdicional.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabFacturaAdicional.Controls.Add(Me.tabBuscar)
        Me.tabFacturaAdicional.Controls.Add(Me.tabEmision)
        Me.tabFacturaAdicional.Location = New System.Drawing.Point(8, 32)
        Me.tabFacturaAdicional.Name = "tabFacturaAdicional"
        Me.tabFacturaAdicional.SelectedIndex = 0
        Me.tabFacturaAdicional.Size = New System.Drawing.Size(1005, 567)
        Me.tabFacturaAdicional.TabIndex = 0
        '
        'tabBuscar
        '
        Me.tabBuscar.Controls.Add(Me.cboFacturado)
        Me.tabBuscar.Controls.Add(Me.cboTipoComprobante)
        Me.tabBuscar.Controls.Add(Me.cboDestino)
        Me.tabBuscar.Controls.Add(Me.cboOrigen)
        Me.tabBuscar.Controls.Add(Me.Label8)
        Me.tabBuscar.Controls.Add(Me.Label7)
        Me.tabBuscar.Controls.Add(Me.btnConsultar)
        Me.tabBuscar.Controls.Add(Me.btnAgregar)
        Me.tabBuscar.Controls.Add(Me.btnBuscar)
        Me.tabBuscar.Controls.Add(Me.txtNumeroComprobante)
        Me.tabBuscar.Controls.Add(Me.Label13)
        Me.tabBuscar.Controls.Add(Me.Label12)
        Me.tabBuscar.Controls.Add(Me.Label11)
        Me.tabBuscar.Controls.Add(Me.dtpFechaFin)
        Me.tabBuscar.Controls.Add(Me.dtpFechaInicio)
        Me.tabBuscar.Controls.Add(Me.Label4)
        Me.tabBuscar.Controls.Add(Me.Label3)
        Me.tabBuscar.Controls.Add(Me.Label2)
        Me.tabBuscar.Controls.Add(Me.txtCliente)
        Me.tabBuscar.Controls.Add(Me.txtCodigoCliente)
        Me.tabBuscar.Controls.Add(Me.Label15)
        Me.tabBuscar.Controls.Add(Me.dgvLista)
        Me.tabBuscar.Location = New System.Drawing.Point(4, 22)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBuscar.Size = New System.Drawing.Size(997, 541)
        Me.tabBuscar.TabIndex = 0
        Me.tabBuscar.Text = "Buscar"
        Me.tabBuscar.UseVisualStyleBackColor = True
        '
        'cboFacturado
        '
        Me.cboFacturado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFacturado.FormattingEnabled = True
        Me.cboFacturado.Items.AddRange(New Object() {"(TODO)", "SI", "NO"})
        Me.cboFacturado.Location = New System.Drawing.Point(779, 55)
        Me.cboFacturado.Name = "cboFacturado"
        Me.cboFacturado.Size = New System.Drawing.Size(114, 21)
        Me.cboFacturado.TabIndex = 51
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"(TODO)", "FACTURA", "BOLETA"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(47, 56)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(86, 21)
        Me.cboTipoComprobante.TabIndex = 51
        '
        'cboDestino
        '
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(676, 18)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(217, 21)
        Me.cboDestino.TabIndex = 50
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Location = New System.Drawing.Point(396, 18)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(189, 21)
        Me.cboOrigen.TabIndex = 49
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(618, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Destino"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(351, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Origen"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.btnConsultar.Location = New System.Drawing.Point(905, 260)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(76, 35)
        Me.btnConsultar.TabIndex = 46
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Image = Global.INTEGRACION.My.Resources.Resources.paste_16
        Me.btnAgregar.Location = New System.Drawing.Point(905, 204)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(76, 35)
        Me.btnAgregar.TabIndex = 46
        Me.btnAgregar.Text = "Canjear"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(905, 91)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(76, 43)
        Me.btnBuscar.TabIndex = 46
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(222, 56)
        Me.txtNumeroComprobante.MaxLength = 20
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(120, 20)
        Me.txtNumeroComprobante.TabIndex = 45
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(719, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Facturado"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(13, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Tipo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(144, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Comprobante"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(239, 19)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(103, 20)
        Me.dtpFechaFin.TabIndex = 22
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(107, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(103, 20)
        Me.dtpFechaInicio.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(79, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "De"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Fecha Doc."
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Location = New System.Drawing.Point(472, 56)
        Me.txtCliente.MaxLength = 50
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(240, 20)
        Me.txtCliente.TabIndex = 17
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(396, 56)
        Me.txtCodigoCliente.MaxLength = 20
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(76, 20)
        Me.txtCodigoCliente.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(351, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Cliente"
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLista.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLista.Location = New System.Drawing.Point(13, 91)
        Me.dgvLista.Name = "dgvLista"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLista.Size = New System.Drawing.Size(880, 440)
        Me.dgvLista.TabIndex = 0
        '
        'tabEmision
        '
        Me.tabEmision.Controls.Add(Me.grbOperacion)
        Me.tabEmision.Controls.Add(Me.grbFormaPago)
        Me.tabEmision.Controls.Add(Me.LblFechaServidor)
        Me.tabEmision.Controls.Add(Me.lblNumero)
        Me.tabEmision.Controls.Add(Me.lblSerie)
        Me.tabEmision.Controls.Add(Me.lblTipoComprobante)
        Me.tabEmision.Controls.Add(Me.grbCliente)
        Me.tabEmision.Controls.Add(Me.btnCancelar)
        Me.tabEmision.Controls.Add(Me.btnGrabar)
        Me.tabEmision.Controls.Add(Me.Label19)
        Me.tabEmision.Controls.Add(Me.Label18)
        Me.tabEmision.Controls.Add(Me.Label10)
        Me.tabEmision.Controls.Add(Me.lblComprobante)
        Me.tabEmision.Controls.Add(Me.Label9)
        Me.tabEmision.Controls.Add(Me.Label17)
        Me.tabEmision.Controls.Add(Me.lblTotal)
        Me.tabEmision.Controls.Add(Me.lblImpuesto)
        Me.tabEmision.Controls.Add(Me.lblSubtotal)
        Me.tabEmision.Location = New System.Drawing.Point(4, 22)
        Me.tabEmision.Name = "tabEmision"
        Me.tabEmision.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEmision.Size = New System.Drawing.Size(997, 541)
        Me.tabEmision.TabIndex = 1
        Me.tabEmision.Text = "Emisión"
        Me.tabEmision.UseVisualStyleBackColor = True
        '
        'grbOperacion
        '
        Me.grbOperacion.Controls.Add(Me.dgvOperacion)
        Me.grbOperacion.Location = New System.Drawing.Point(27, 194)
        Me.grbOperacion.Name = "grbOperacion"
        Me.grbOperacion.Size = New System.Drawing.Size(633, 209)
        Me.grbOperacion.TabIndex = 110
        Me.grbOperacion.TabStop = False
        Me.grbOperacion.Text = "Operaciones"
        '
        'dgvOperacion
        '
        Me.dgvOperacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOperacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOperacion.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvOperacion.Location = New System.Drawing.Point(13, 21)
        Me.dgvOperacion.Name = "dgvOperacion"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOperacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvOperacion.Size = New System.Drawing.Size(608, 178)
        Me.dgvOperacion.TabIndex = 1
        '
        'grbFormaPago
        '
        Me.grbFormaPago.Controls.Add(Me.cboFormaPago)
        Me.grbFormaPago.Controls.Add(Me.Label6)
        Me.grbFormaPago.Controls.Add(Me.txtNumeroTarjeta)
        Me.grbFormaPago.Controls.Add(Me.LblNroTarj)
        Me.grbFormaPago.Controls.Add(Me.cboTarjeta)
        Me.grbFormaPago.Controls.Add(Me.LblTarjeta)
        Me.grbFormaPago.Location = New System.Drawing.Point(27, 152)
        Me.grbFormaPago.Name = "grbFormaPago"
        Me.grbFormaPago.Size = New System.Drawing.Size(633, 58)
        Me.grbFormaPago.TabIndex = 109
        Me.grbFormaPago.TabStop = False
        Me.grbFormaPago.Text = "Forma Pago"
        Me.grbFormaPago.Visible = False
        '
        'cboFormaPago
        '
        Me.cboFormaPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(95, 23)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(139, 21)
        Me.cboFormaPago.TabIndex = 103
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(7, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Forma Pago"
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.Enabled = False
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(495, 24)
        Me.txtNumeroTarjeta.MaxLength = 13
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(127, 20)
        Me.txtNumeroTarjeta.TabIndex = 107
        '
        'LblNroTarj
        '
        Me.LblNroTarj.AutoSize = True
        Me.LblNroTarj.Location = New System.Drawing.Point(436, 26)
        Me.LblNroTarj.Name = "LblNroTarj"
        Me.LblNroTarj.Size = New System.Drawing.Size(55, 13)
        Me.LblNroTarj.TabIndex = 106
        Me.LblNroTarj.Text = "Nº Tarjeta"
        '
        'cboTarjeta
        '
        Me.cboTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTarjeta.Enabled = False
        Me.cboTarjeta.FormattingEnabled = True
        Me.cboTarjeta.Location = New System.Drawing.Point(292, 23)
        Me.cboTarjeta.Name = "cboTarjeta"
        Me.cboTarjeta.Size = New System.Drawing.Size(129, 21)
        Me.cboTarjeta.TabIndex = 105
        '
        'LblTarjeta
        '
        Me.LblTarjeta.AutoSize = True
        Me.LblTarjeta.Location = New System.Drawing.Point(245, 26)
        Me.LblTarjeta.Name = "LblTarjeta"
        Me.LblTarjeta.Size = New System.Drawing.Size(40, 13)
        Me.LblTarjeta.TabIndex = 104
        Me.LblTarjeta.Text = "Tarjeta"
        '
        'LblFechaServidor
        '
        Me.LblFechaServidor.AutoSize = True
        Me.LblFechaServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaServidor.ForeColor = System.Drawing.Color.Black
        Me.LblFechaServidor.Location = New System.Drawing.Point(383, 25)
        Me.LblFechaServidor.Name = "LblFechaServidor"
        Me.LblFechaServidor.Size = New System.Drawing.Size(75, 13)
        Me.LblFechaServidor.TabIndex = 108
        Me.LblFechaServidor.Text = "01/03/2011"
        '
        'lblNumero
        '
        Me.lblNumero.BackColor = System.Drawing.Color.White
        Me.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.ForeColor = System.Drawing.Color.Black
        Me.lblNumero.Location = New System.Drawing.Point(724, 38)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(72, 18)
        Me.lblNumero.TabIndex = 101
        Me.lblNumero.Text = "0000001"
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSerie
        '
        Me.lblSerie.BackColor = System.Drawing.Color.White
        Me.lblSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSerie.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerie.ForeColor = System.Drawing.Color.Black
        Me.lblSerie.Location = New System.Drawing.Point(696, 38)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(31, 18)
        Me.lblSerie.TabIndex = 100
        Me.lblSerie.Text = "001"
        Me.lblSerie.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.BackColor = System.Drawing.Color.MidnightBlue
        Me.lblTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComprobante.ForeColor = System.Drawing.Color.White
        Me.lblTipoComprobante.Location = New System.Drawing.Point(696, 14)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(100, 24)
        Me.lblTipoComprobante.TabIndex = 99
        Me.lblTipoComprobante.Text = "BOLETA"
        Me.lblTipoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbCliente
        '
        Me.grbCliente.Controls.Add(Me.txtNombre)
        Me.grbCliente.Controls.Add(Me.BtnCliente)
        Me.grbCliente.Controls.Add(Me.Label5)
        Me.grbCliente.Controls.Add(Me.Label1)
        Me.grbCliente.Controls.Add(Me.cboDireccion)
        Me.grbCliente.Controls.Add(Me.txtNumeroDocumento)
        Me.grbCliente.Location = New System.Drawing.Point(27, 69)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(633, 103)
        Me.grbCliente.TabIndex = 98
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Cliente"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(188, 25)
        Me.txtNombre.MaxLength = 11
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNombre.Size = New System.Drawing.Size(408, 20)
        Me.txtNombre.TabIndex = 96
        '
        'BtnCliente
        '
        Me.BtnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCliente.Location = New System.Drawing.Point(600, 23)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(24, 23)
        Me.BtnCliente.TabIndex = 97
        Me.BtnCliente.TabStop = False
        Me.BtnCliente.Text = "..."
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Dirección"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nº Documento"
        '
        'cboDireccion
        '
        Me.cboDireccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDireccion.FormattingEnabled = True
        Me.cboDireccion.Location = New System.Drawing.Point(95, 63)
        Me.cboDireccion.Name = "cboDireccion"
        Me.cboDireccion.Size = New System.Drawing.Size(527, 21)
        Me.cboDireccion.TabIndex = 103
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroDocumento.Enabled = False
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(95, 25)
        Me.txtNumeroDocumento.MaxLength = 11
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(92, 20)
        Me.txtNumeroDocumento.TabIndex = 96
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(704, 131)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(86, 38)
        Me.btnCancelar.TabIndex = 95
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(704, 77)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(86, 38)
        Me.btnGrabar.TabIndex = 95
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(490, 409)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 94
        Me.Label19.Text = "Total"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(317, 409)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 13)
        Me.Label18.TabIndex = 92
        Me.Label18.Text = "Impuesto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(327, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Fecha"
        '
        'lblComprobante
        '
        Me.lblComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.Black
        Me.lblComprobante.Location = New System.Drawing.Point(118, 25)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(194, 13)
        Me.lblComprobante.TabIndex = 90
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(34, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Comprobante"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(128, 410)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "Subtotal"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(552, 409)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(96, 13)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpuesto.Location = New System.Drawing.Point(373, 411)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(96, 13)
        Me.lblImpuesto.TabIndex = 1
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.Location = New System.Drawing.Point(191, 411)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(96, 13)
        Me.lblSubtotal.TabIndex = 1
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(1021, 25)
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
        Me.tsbNuevo.Visible = False
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(69, 22)
        Me.tsbEditar.Text = "Agregar"
        Me.tsbEditar.ToolTipText = "Agregar Factura Adicional"
        Me.tsbEditar.Visible = False
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "Grabar"
        Me.tsbGrabar.Visible = False
        '
        'tsbAnular
        '
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        Me.tsbAnular.Visible = False
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
        'frmEmisionFacturaAdicional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 602)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabFacturaAdicional)
        Me.Name = "frmEmisionFacturaAdicional"
        Me.Text = "Factura Adicional"
        Me.tabFacturaAdicional.ResumeLayout(False)
        Me.tabBuscar.ResumeLayout(False)
        Me.tabBuscar.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmision.ResumeLayout(False)
        Me.tabEmision.PerformLayout()
        Me.grbOperacion.ResumeLayout(False)
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFormaPago.ResumeLayout(False)
        Me.grbFormaPago.PerformLayout()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabFacturaAdicional As System.Windows.Forms.TabControl
    Friend WithEvents tabBuscar As System.Windows.Forms.TabPage
    Friend WithEvents tabEmision As System.Windows.Forms.TabPage
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblImpuesto As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnCliente As System.Windows.Forms.Button
    Friend WithEvents txtNumeroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents lblTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents cboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents LblNroTarj As System.Windows.Forms.Label
    Friend WithEvents LblTarjeta As System.Windows.Forms.Label
    Friend WithEvents cboTarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents cboDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents LblFechaServidor As System.Windows.Forms.Label
    Friend WithEvents grbFormaPago As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grbOperacion As System.Windows.Forms.GroupBox
    Friend WithEvents dgvOperacion As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents cboFacturado As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
