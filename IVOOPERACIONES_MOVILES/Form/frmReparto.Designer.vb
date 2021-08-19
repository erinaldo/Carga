<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReparto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReparto))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabReparto = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.dtpFechaLista = New System.Windows.Forms.DateTimePicker()
        Me.cboMovilLista = New System.Windows.Forms.ComboBox()
        Me.cboResponsableLista = New System.Windows.Forms.ComboBox()
        Me.cboCiudadLista = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.tabAsignar = New System.Windows.Forms.TabPage()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.grbReparto = New System.Windows.Forms.GroupBox()
        Me.dgvReparto = New System.Windows.Forms.DataGridView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dtpHoraSalida = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.cboMovil = New System.Windows.Forms.ComboBox()
        Me.cboCiudad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tool.SuspendLayout()
        Me.tabReparto.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAsignar.SuspendLayout()
        Me.grbReparto.SuspendLayout()
        CType(Me.dgvReparto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(905, 25)
        Me.tool.TabIndex = 8
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
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "Editar"
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
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'tabReparto
        '
        Me.tabReparto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabReparto.Controls.Add(Me.tabLista)
        Me.tabReparto.Controls.Add(Me.tabAsignar)
        Me.tabReparto.Location = New System.Drawing.Point(4, 34)
        Me.tabReparto.Name = "tabReparto"
        Me.tabReparto.SelectedIndex = 0
        Me.tabReparto.Size = New System.Drawing.Size(889, 437)
        Me.tabReparto.TabIndex = 9
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.btnFiltrar)
        Me.tabLista.Controls.Add(Me.dtpFechaLista)
        Me.tabLista.Controls.Add(Me.cboMovilLista)
        Me.tabLista.Controls.Add(Me.cboResponsableLista)
        Me.tabLista.Controls.Add(Me.cboCiudadLista)
        Me.tabLista.Controls.Add(Me.Label11)
        Me.tabLista.Controls.Add(Me.Label6)
        Me.tabLista.Controls.Add(Me.Label8)
        Me.tabLista.Controls.Add(Me.Label7)
        Me.tabLista.Controls.Add(Me.dgvLista)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(881, 411)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltrar.Location = New System.Drawing.Point(792, 7)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(71, 30)
        Me.btnFiltrar.TabIndex = 3
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'dtpFechaLista
        '
        Me.dtpFechaLista.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaLista.CustomFormat = ""
        Me.dtpFechaLista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaLista.Location = New System.Drawing.Point(59, 12)
        Me.dtpFechaLista.Name = "dtpFechaLista"
        Me.dtpFechaLista.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaLista.TabIndex = 0
        '
        'cboMovilLista
        '
        Me.cboMovilLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMovilLista.DropDownWidth = 230
        Me.cboMovilLista.FormattingEnabled = True
        Me.cboMovilLista.Location = New System.Drawing.Point(393, 12)
        Me.cboMovilLista.Name = "cboMovilLista"
        Me.cboMovilLista.Size = New System.Drawing.Size(93, 21)
        Me.cboMovilLista.TabIndex = 2
        '
        'cboResponsableLista
        '
        Me.cboResponsableLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResponsableLista.DropDownWidth = 230
        Me.cboResponsableLista.FormattingEnabled = True
        Me.cboResponsableLista.Location = New System.Drawing.Point(579, 12)
        Me.cboResponsableLista.Name = "cboResponsableLista"
        Me.cboResponsableLista.Size = New System.Drawing.Size(198, 21)
        Me.cboResponsableLista.TabIndex = 2
        '
        'cboCiudadLista
        '
        Me.cboCiudadLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudadLista.FormattingEnabled = True
        Me.cboCiudadLista.Location = New System.Drawing.Point(203, 12)
        Me.cboCiudadLista.Name = "cboCiudadLista"
        Me.cboCiudadLista.Size = New System.Drawing.Size(134, 21)
        Me.cboCiudadLista.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Móvil"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(503, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Responsable"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(152, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Ciudad"
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(16, 43)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(848, 353)
        Me.dgvLista.TabIndex = 14
        '
        'tabAsignar
        '
        Me.tabAsignar.Controls.Add(Me.cboTipoComprobante)
        Me.tabAsignar.Controls.Add(Me.Label19)
        Me.tabAsignar.Controls.Add(Me.txtComprobante)
        Me.tabAsignar.Controls.Add(Me.grbReparto)
        Me.tabAsignar.Controls.Add(Me.btnAgregar)
        Me.tabAsignar.Controls.Add(Me.dtpHoraSalida)
        Me.tabAsignar.Controls.Add(Me.Label5)
        Me.tabAsignar.Controls.Add(Me.lblNumero)
        Me.tabAsignar.Controls.Add(Me.lblFecha)
        Me.tabAsignar.Controls.Add(Me.cboResponsable)
        Me.tabAsignar.Controls.Add(Me.cboMovil)
        Me.tabAsignar.Controls.Add(Me.cboCiudad)
        Me.tabAsignar.Controls.Add(Me.Label4)
        Me.tabAsignar.Controls.Add(Me.Label9)
        Me.tabAsignar.Controls.Add(Me.Label3)
        Me.tabAsignar.Controls.Add(Me.Label10)
        Me.tabAsignar.Controls.Add(Me.Label2)
        Me.tabAsignar.Controls.Add(Me.Label1)
        Me.tabAsignar.Location = New System.Drawing.Point(4, 22)
        Me.tabAsignar.Name = "tabAsignar"
        Me.tabAsignar.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAsignar.Size = New System.Drawing.Size(881, 411)
        Me.tabAsignar.TabIndex = 1
        Me.tabAsignar.Text = "Reparto"
        Me.tabAsignar.UseVisualStyleBackColor = True
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"(TODO)", "FACTURA", "BOLETA"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(275, 88)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(137, 21)
        Me.cboTipoComprobante.TabIndex = 104
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(234, 92)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 103
        Me.Label19.Text = "Tipo"
        '
        'txtComprobante
        '
        Me.txtComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobante.Location = New System.Drawing.Point(513, 89)
        Me.txtComprobante.MaxLength = 13
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(102, 20)
        Me.txtComprobante.TabIndex = 4
        '
        'grbReparto
        '
        Me.grbReparto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbReparto.Controls.Add(Me.dgvReparto)
        Me.grbReparto.Location = New System.Drawing.Point(22, 126)
        Me.grbReparto.Name = "grbReparto"
        Me.grbReparto.Size = New System.Drawing.Size(837, 269)
        Me.grbReparto.TabIndex = 17
        Me.grbReparto.TabStop = False
        Me.grbReparto.Text = "Reparto"
        '
        'dgvReparto
        '
        Me.dgvReparto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReparto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReparto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReparto.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReparto.Location = New System.Drawing.Point(7, 19)
        Me.dgvReparto.Name = "dgvReparto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReparto.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReparto.Size = New System.Drawing.Size(819, 242)
        Me.dgvReparto.TabIndex = 0
        Me.dgvReparto.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(627, 85)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(68, 27)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dtpHoraSalida
        '
        Me.dtpHoraSalida.CustomFormat = ""
        Me.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraSalida.Location = New System.Drawing.Point(89, 89)
        Me.dtpHoraSalida.Name = "dtpHoraSalida"
        Me.dtpHoraSalida.Size = New System.Drawing.Size(87, 20)
        Me.dtpHoraSalida.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(436, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Comprobante"
        '
        'lblNumero
        '
        Me.lblNumero.Location = New System.Drawing.Point(181, 18)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(37, 13)
        Me.lblNumero.TabIndex = 11
        Me.lblNumero.Text = "1000"
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(67, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(65, 13)
        Me.lblFecha.TabIndex = 11
        Me.lblFecha.Text = "01/01/2015"
        '
        'cboResponsable
        '
        Me.cboResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResponsable.DropDownWidth = 230
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(513, 44)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(181, 21)
        Me.cboResponsable.TabIndex = 2
        '
        'cboMovil
        '
        Me.cboMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMovil.FormattingEnabled = True
        Me.cboMovil.Location = New System.Drawing.Point(275, 44)
        Me.cboMovil.Name = "cboMovil"
        Me.cboMovil.Size = New System.Drawing.Size(137, 21)
        Me.cboMovil.TabIndex = 1
        '
        'cboCiudad
        '
        Me.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudad.FormattingEnabled = True
        Me.cboCiudad.Location = New System.Drawing.Point(70, 45)
        Me.cboCiudad.Name = "cboCiudad"
        Me.cboCiudad.Size = New System.Drawing.Size(148, 21)
        Me.cboCiudad.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Hora Salida"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(166, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Nº"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(436, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Responsable"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(234, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Movil"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Ciudad"
        '
        'frmReparto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 483)
        Me.Controls.Add(Me.tabReparto)
        Me.Controls.Add(Me.tool)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmReparto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Carga a Reparto"
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.tabReparto.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        Me.tabLista.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAsignar.ResumeLayout(False)
        Me.tabAsignar.PerformLayout()
        Me.grbReparto.ResumeLayout(False)
        CType(Me.dgvReparto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabReparto As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents tabAsignar As System.Windows.Forms.TabPage
    Friend WithEvents dtpHoraSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents cboCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grbReparto As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvReparto As System.Windows.Forms.DataGridView
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboResponsableLista As System.Windows.Forms.ComboBox
    Friend WithEvents cboCiudadLista As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaLista As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMovil As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMovilLista As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
