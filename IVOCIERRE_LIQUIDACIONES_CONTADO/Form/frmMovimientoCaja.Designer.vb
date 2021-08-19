<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoCaja
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientoCaja))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabMovimientoCaja = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.tabMovimiento = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.TxtDepositante = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPeaje = New System.Windows.Forms.TextBox()
        Me.TxtNroBus = New System.Windows.Forms.TextBox()
        Me.TxtNroOperacion = New System.Windows.Forms.TextBox()
        Me.TxtNroDocumento = New System.Windows.Forms.TextBox()
        Me.CboPiloto = New System.Windows.Forms.ComboBox()
        Me.CboDestino = New System.Windows.Forms.ComboBox()
        Me.CboTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.LblContTepsa = New System.Windows.Forms.Label()
        Me.LblDepositante = New System.Windows.Forms.Label()
        Me.LblPiloto = New System.Windows.Forms.Label()
        Me.LblDestino = New System.Windows.Forms.Label()
        Me.LblMonto = New System.Windows.Forms.Label()
        Me.lblCodPeaje = New System.Windows.Forms.Label()
        Me.LblNroBus = New System.Windows.Forms.Label()
        Me.LblNroOperacion = New System.Windows.Forms.Label()
        Me.LblNroDocumento = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabMovimientoCaja.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMovimiento.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMovimientoCaja
        '
        Me.tabMovimientoCaja.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMovimientoCaja.Controls.Add(Me.tabLista)
        Me.tabMovimientoCaja.Controls.Add(Me.tabMovimiento)
        Me.tabMovimientoCaja.Location = New System.Drawing.Point(6, 31)
        Me.tabMovimientoCaja.Name = "tabMovimientoCaja"
        Me.tabMovimientoCaja.SelectedIndex = 0
        Me.tabMovimientoCaja.Size = New System.Drawing.Size(659, 417)
        Me.tabMovimientoCaja.TabIndex = 0
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.btnConsultar)
        Me.tabLista.Controls.Add(Me.Label3)
        Me.tabLista.Controls.Add(Me.Label2)
        Me.tabLista.Controls.Add(Me.dtpFin)
        Me.tabLista.Controls.Add(Me.dtpInicio)
        Me.tabLista.Controls.Add(Me.dgvLista)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(651, 391)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(567, 6)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 38)
        Me.btnConsultar.TabIndex = 55
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(184, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Fecha Fin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Fecha Inicio"
        '
        'dtpFin
        '
        Me.dtpFin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(244, 17)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(88, 20)
        Me.dtpFin.TabIndex = 53
        '
        'dtpInicio
        '
        Me.dtpInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(77, 17)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(88, 20)
        Me.dtpInicio.TabIndex = 53
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
        Me.dgvLista.Location = New System.Drawing.Point(9, 52)
        Me.dgvLista.Name = "dgvLista"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLista.Size = New System.Drawing.Size(633, 330)
        Me.dgvLista.TabIndex = 0
        '
        'tabMovimiento
        '
        Me.tabMovimiento.Controls.Add(Me.Label6)
        Me.tabMovimiento.Controls.Add(Me.TxtMonto)
        Me.tabMovimiento.Controls.Add(Me.TxtObservaciones)
        Me.tabMovimiento.Controls.Add(Me.TxtContacto)
        Me.tabMovimiento.Controls.Add(Me.TxtDepositante)
        Me.tabMovimiento.Controls.Add(Me.TxtCodigoPeaje)
        Me.tabMovimiento.Controls.Add(Me.TxtNroBus)
        Me.tabMovimiento.Controls.Add(Me.TxtNroOperacion)
        Me.tabMovimiento.Controls.Add(Me.TxtNroDocumento)
        Me.tabMovimiento.Controls.Add(Me.CboPiloto)
        Me.tabMovimiento.Controls.Add(Me.CboDestino)
        Me.tabMovimiento.Controls.Add(Me.CboTipoMovimiento)
        Me.tabMovimiento.Controls.Add(Me.LblObservaciones)
        Me.tabMovimiento.Controls.Add(Me.LblContTepsa)
        Me.tabMovimiento.Controls.Add(Me.LblDepositante)
        Me.tabMovimiento.Controls.Add(Me.LblPiloto)
        Me.tabMovimiento.Controls.Add(Me.LblDestino)
        Me.tabMovimiento.Controls.Add(Me.LblMonto)
        Me.tabMovimiento.Controls.Add(Me.lblCodPeaje)
        Me.tabMovimiento.Controls.Add(Me.LblNroBus)
        Me.tabMovimiento.Controls.Add(Me.LblNroOperacion)
        Me.tabMovimiento.Controls.Add(Me.LblNroDocumento)
        Me.tabMovimiento.Controls.Add(Me.lblFecha)
        Me.tabMovimiento.Controls.Add(Me.Label1)
        Me.tabMovimiento.Controls.Add(Me.Label7)
        Me.tabMovimiento.Location = New System.Drawing.Point(4, 22)
        Me.tabMovimiento.Name = "tabMovimiento"
        Me.tabMovimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMovimiento.Size = New System.Drawing.Size(651, 391)
        Me.tabMovimiento.TabIndex = 1
        Me.tabMovimiento.Text = "Movimiento"
        Me.tabMovimiento.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(84, 284)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "máx ( 200 Caracteres )"
        '
        'TxtMonto
        '
        Me.TxtMonto.BackColor = System.Drawing.Color.White
        Me.TxtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMonto.Enabled = False
        Me.TxtMonto.Location = New System.Drawing.Point(201, 130)
        Me.TxtMonto.MaxLength = 10
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(112, 20)
        Me.TxtMonto.TabIndex = 4
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BackColor = System.Drawing.Color.White
        Me.TxtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservaciones.Enabled = False
        Me.TxtObservaciones.Location = New System.Drawing.Point(201, 268)
        Me.TxtObservaciones.MaxLength = 200
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(299, 102)
        Me.TxtObservaciones.TabIndex = 10
        '
        'TxtContacto
        '
        Me.TxtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContacto.Enabled = False
        Me.TxtContacto.Location = New System.Drawing.Point(201, 239)
        Me.TxtContacto.MaxLength = 200
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(299, 20)
        Me.TxtContacto.TabIndex = 9
        '
        'TxtDepositante
        '
        Me.TxtDepositante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDepositante.Enabled = False
        Me.TxtDepositante.Location = New System.Drawing.Point(201, 213)
        Me.TxtDepositante.MaxLength = 200
        Me.TxtDepositante.Name = "TxtDepositante"
        Me.TxtDepositante.Size = New System.Drawing.Size(299, 20)
        Me.TxtDepositante.TabIndex = 8
        '
        'TxtCodigoPeaje
        '
        Me.TxtCodigoPeaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigoPeaje.Enabled = False
        Me.TxtCodigoPeaje.Location = New System.Drawing.Point(201, 103)
        Me.TxtCodigoPeaje.MaxLength = 10
        Me.TxtCodigoPeaje.Name = "TxtCodigoPeaje"
        Me.TxtCodigoPeaje.Size = New System.Drawing.Size(112, 20)
        Me.TxtCodigoPeaje.TabIndex = 3
        '
        'TxtNroBus
        '
        Me.TxtNroBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroBus.Enabled = False
        Me.TxtNroBus.Location = New System.Drawing.Point(444, 158)
        Me.TxtNroBus.MaxLength = 3
        Me.TxtNroBus.Name = "TxtNroBus"
        Me.TxtNroBus.Size = New System.Drawing.Size(56, 20)
        Me.TxtNroBus.TabIndex = 6
        '
        'TxtNroOperacion
        '
        Me.TxtNroOperacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroOperacion.Enabled = False
        Me.TxtNroOperacion.Location = New System.Drawing.Point(407, 81)
        Me.TxtNroOperacion.MaxLength = 10
        Me.TxtNroOperacion.Name = "TxtNroOperacion"
        Me.TxtNroOperacion.Size = New System.Drawing.Size(98, 20)
        Me.TxtNroOperacion.TabIndex = 2
        '
        'TxtNroDocumento
        '
        Me.TxtNroDocumento.BackColor = System.Drawing.Color.White
        Me.TxtNroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroDocumento.Enabled = False
        Me.TxtNroDocumento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtNroDocumento.Location = New System.Drawing.Point(201, 77)
        Me.TxtNroDocumento.MaxLength = 12
        Me.TxtNroDocumento.Name = "TxtNroDocumento"
        Me.TxtNroDocumento.Size = New System.Drawing.Size(112, 20)
        Me.TxtNroDocumento.TabIndex = 1
        '
        'CboPiloto
        '
        Me.CboPiloto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPiloto.Enabled = False
        Me.CboPiloto.FormattingEnabled = True
        Me.CboPiloto.Location = New System.Drawing.Point(201, 185)
        Me.CboPiloto.Name = "CboPiloto"
        Me.CboPiloto.Size = New System.Drawing.Size(191, 21)
        Me.CboPiloto.TabIndex = 7
        '
        'CboDestino
        '
        Me.CboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDestino.Enabled = False
        Me.CboDestino.FormattingEnabled = True
        Me.CboDestino.Location = New System.Drawing.Point(201, 157)
        Me.CboDestino.Name = "CboDestino"
        Me.CboDestino.Size = New System.Drawing.Size(191, 21)
        Me.CboDestino.TabIndex = 5
        '
        'CboTipoMovimiento
        '
        Me.CboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoMovimiento.Enabled = False
        Me.CboTipoMovimiento.FormattingEnabled = True
        Me.CboTipoMovimiento.Location = New System.Drawing.Point(201, 51)
        Me.CboTipoMovimiento.Name = "CboTipoMovimiento"
        Me.CboTipoMovimiento.Size = New System.Drawing.Size(304, 21)
        Me.CboTipoMovimiento.TabIndex = 0
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.Location = New System.Drawing.Point(114, 271)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.LblObservaciones.TabIndex = 48
        Me.LblObservaciones.Text = "Observaciones:"
        '
        'LblContTepsa
        '
        Me.LblContTepsa.AutoSize = True
        Me.LblContTepsa.Location = New System.Drawing.Point(104, 242)
        Me.LblContTepsa.Name = "LblContTepsa"
        Me.LblContTepsa.Size = New System.Drawing.Size(94, 13)
        Me.LblContTepsa.TabIndex = 46
        Me.LblContTepsa.Text = "Contacto :"
        '
        'LblDepositante
        '
        Me.LblDepositante.AutoSize = True
        Me.LblDepositante.Location = New System.Drawing.Point(129, 216)
        Me.LblDepositante.Name = "LblDepositante"
        Me.LblDepositante.Size = New System.Drawing.Size(70, 13)
        Me.LblDepositante.TabIndex = 44
        Me.LblDepositante.Text = "Depositante :"
        '
        'LblPiloto
        '
        Me.LblPiloto.AutoSize = True
        Me.LblPiloto.Location = New System.Drawing.Point(159, 188)
        Me.LblPiloto.Name = "LblPiloto"
        Me.LblPiloto.Size = New System.Drawing.Size(39, 13)
        Me.LblPiloto.TabIndex = 42
        Me.LblPiloto.Text = "Piloto :"
        '
        'LblDestino
        '
        Me.LblDestino.AutoSize = True
        Me.LblDestino.Location = New System.Drawing.Point(149, 160)
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Size = New System.Drawing.Size(49, 13)
        Me.LblDestino.TabIndex = 38
        Me.LblDestino.Text = "Destino :"
        '
        'LblMonto
        '
        Me.LblMonto.AutoSize = True
        Me.LblMonto.Location = New System.Drawing.Point(155, 133)
        Me.LblMonto.Name = "LblMonto"
        Me.LblMonto.Size = New System.Drawing.Size(43, 13)
        Me.LblMonto.TabIndex = 36
        Me.LblMonto.Text = "Monto :"
        '
        'lblCodPeaje
        '
        Me.lblCodPeaje.AutoSize = True
        Me.lblCodPeaje.Location = New System.Drawing.Point(122, 106)
        Me.lblCodPeaje.Name = "lblCodPeaje"
        Me.lblCodPeaje.Size = New System.Drawing.Size(76, 13)
        Me.lblCodPeaje.TabIndex = 34
        Me.lblCodPeaje.Text = "Codigo Peaje :"
        '
        'LblNroBus
        '
        Me.LblNroBus.AutoSize = True
        Me.LblNroBus.Location = New System.Drawing.Point(395, 161)
        Me.LblNroBus.Name = "LblNroBus"
        Me.LblNroBus.Size = New System.Drawing.Size(51, 13)
        Me.LblNroBus.TabIndex = 40
        Me.LblNroBus.Text = "Nro Bus :"
        '
        'LblNroOperacion
        '
        Me.LblNroOperacion.AutoSize = True
        Me.LblNroOperacion.Location = New System.Drawing.Point(326, 85)
        Me.LblNroOperacion.Name = "LblNroOperacion"
        Me.LblNroOperacion.Size = New System.Drawing.Size(82, 13)
        Me.LblNroOperacion.TabIndex = 32
        Me.LblNroOperacion.Text = "Nro Operacion :"
        '
        'LblNroDocumento
        '
        Me.LblNroDocumento.AutoSize = True
        Me.LblNroDocumento.Location = New System.Drawing.Point(96, 81)
        Me.LblNroDocumento.Name = "LblNroDocumento"
        Me.LblNroDocumento.Size = New System.Drawing.Size(103, 13)
        Me.LblNroDocumento.TabIndex = 30
        Me.LblNroDocumento.Text = "Nro de Documento :"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(198, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(65, 13)
        Me.lblFecha.TabIndex = 28
        Me.lblFecha.Text = "01/01/2017"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(93, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(92, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Tipo de Movimiento :"
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(665, 25)
        Me.tool.TabIndex = 10
        Me.tool.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Enabled = False
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Enabled = False
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "Grabar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Enabled = False
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
        'frmMovimientoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 447)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabMovimientoCaja)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimientoCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Movimiento de Caja"
        Me.tabMovimientoCaja.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        Me.tabLista.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMovimiento.ResumeLayout(False)
        Me.tabMovimiento.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabMovimientoCaja As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents tabMovimiento As System.Windows.Forms.TabPage
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents TxtDepositante As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPeaje As System.Windows.Forms.TextBox
    Friend WithEvents TxtNroBus As System.Windows.Forms.TextBox
    Friend WithEvents TxtNroOperacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents CboPiloto As System.Windows.Forms.ComboBox
    Friend WithEvents CboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents CboTipoMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents LblObservaciones As System.Windows.Forms.Label
    Friend WithEvents LblContTepsa As System.Windows.Forms.Label
    Friend WithEvents LblDepositante As System.Windows.Forms.Label
    Friend WithEvents LblPiloto As System.Windows.Forms.Label
    Friend WithEvents LblDestino As System.Windows.Forms.Label
    Friend WithEvents LblMonto As System.Windows.Forms.Label
    Friend WithEvents lblCodPeaje As System.Windows.Forms.Label
    Friend WithEvents LblNroBus As System.Windows.Forms.Label
    Friend WithEvents LblNroOperacion As System.Windows.Forms.Label
    Friend WithEvents LblNroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
