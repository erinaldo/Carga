<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTarifaServicio
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarifaServicio))
        Me.tabTarifario = New System.Windows.Forms.TabControl()
        Me.TabCliente = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.grbFiltro = New System.Windows.Forms.GroupBox()
        Me.cboBusq_TipoTarifa = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CboBusq_Producto = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CboBusq_Servicio = New System.Windows.Forms.ComboBox()
        Me.CboBusq_TipoVisibildad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboBusq_Destino = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBusq_Origen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMantenimiento = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.cboTipoTarifa = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoVisibilidad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaActivacion = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvTarifa = New System.Windows.Forms.DataGridView()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.tabTarifario.SuspendLayout()
        Me.TabCliente.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltro.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabMantenimiento.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvTarifa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabTarifario
        '
        Me.tabTarifario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTarifario.Controls.Add(Me.TabCliente)
        Me.tabTarifario.Controls.Add(Me.TabMantenimiento)
        Me.tabTarifario.Location = New System.Drawing.Point(12, 8)
        Me.tabTarifario.Name = "tabTarifario"
        Me.tabTarifario.SelectedIndex = 0
        Me.tabTarifario.Size = New System.Drawing.Size(888, 578)
        Me.tabTarifario.TabIndex = 1
        '
        'TabCliente
        '
        Me.TabCliente.Controls.Add(Me.GroupBox7)
        Me.TabCliente.Controls.Add(Me.grbFiltro)
        Me.TabCliente.Controls.Add(Me.btnConsultar)
        Me.TabCliente.Controls.Add(Me.MenuStrip1)
        Me.TabCliente.Location = New System.Drawing.Point(4, 22)
        Me.TabCliente.Name = "TabCliente"
        Me.TabCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCliente.Size = New System.Drawing.Size(880, 552)
        Me.TabCliente.TabIndex = 0
        Me.TabCliente.Text = "Lista"
        Me.TabCliente.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.dgvLista)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 114)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(868, 429)
        Me.GroupBox7.TabIndex = 28
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tarifas"
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
        Me.dgvLista.Location = New System.Drawing.Point(6, 19)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(856, 397)
        Me.dgvLista.TabIndex = 0
        '
        'grbFiltro
        '
        Me.grbFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltro.Controls.Add(Me.cboBusq_TipoTarifa)
        Me.grbFiltro.Controls.Add(Me.Label6)
        Me.grbFiltro.Controls.Add(Me.Label18)
        Me.grbFiltro.Controls.Add(Me.CboBusq_Producto)
        Me.grbFiltro.Controls.Add(Me.Label16)
        Me.grbFiltro.Controls.Add(Me.CboBusq_Servicio)
        Me.grbFiltro.Controls.Add(Me.CboBusq_TipoVisibildad)
        Me.grbFiltro.Controls.Add(Me.Label13)
        Me.grbFiltro.Controls.Add(Me.cboBusq_Destino)
        Me.grbFiltro.Controls.Add(Me.Label2)
        Me.grbFiltro.Controls.Add(Me.cboBusq_Origen)
        Me.grbFiltro.Controls.Add(Me.Label1)
        Me.grbFiltro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grbFiltro.Location = New System.Drawing.Point(4, 33)
        Me.grbFiltro.Name = "grbFiltro"
        Me.grbFiltro.Size = New System.Drawing.Size(870, 75)
        Me.grbFiltro.TabIndex = 23
        Me.grbFiltro.TabStop = False
        Me.grbFiltro.Text = "Filtro Busqueda"
        '
        'cboBusq_TipoTarifa
        '
        Me.cboBusq_TipoTarifa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBusq_TipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBusq_TipoTarifa.FormattingEnabled = True
        Me.cboBusq_TipoTarifa.Location = New System.Drawing.Point(373, 40)
        Me.cboBusq_TipoTarifa.Name = "cboBusq_TipoTarifa"
        Me.cboBusq_TipoTarifa.Size = New System.Drawing.Size(176, 21)
        Me.cboBusq_TipoTarifa.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(624, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Servicio :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(624, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Visibilidad :"
        '
        'CboBusq_Producto
        '
        Me.CboBusq_Producto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboBusq_Producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBusq_Producto.FormattingEnabled = True
        Me.CboBusq_Producto.Location = New System.Drawing.Point(373, 13)
        Me.CboBusq_Producto.Name = "CboBusq_Producto"
        Me.CboBusq_Producto.Size = New System.Drawing.Size(176, 21)
        Me.CboBusq_Producto.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(296, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Producto :"
        '
        'CboBusq_Servicio
        '
        Me.CboBusq_Servicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboBusq_Servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBusq_Servicio.FormattingEnabled = True
        Me.CboBusq_Servicio.Location = New System.Drawing.Point(689, 46)
        Me.CboBusq_Servicio.Name = "CboBusq_Servicio"
        Me.CboBusq_Servicio.Size = New System.Drawing.Size(175, 21)
        Me.CboBusq_Servicio.TabIndex = 6
        '
        'CboBusq_TipoVisibildad
        '
        Me.CboBusq_TipoVisibildad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboBusq_TipoVisibildad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBusq_TipoVisibildad.FormattingEnabled = True
        Me.CboBusq_TipoVisibildad.Location = New System.Drawing.Point(689, 13)
        Me.CboBusq_TipoVisibildad.Name = "CboBusq_TipoVisibildad"
        Me.CboBusq_TipoVisibildad.Size = New System.Drawing.Size(175, 21)
        Me.CboBusq_TipoVisibildad.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(288, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Tipo Tarifa :"
        '
        'cboBusq_Destino
        '
        Me.cboBusq_Destino.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBusq_Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBusq_Destino.FormattingEnabled = True
        Me.cboBusq_Destino.Location = New System.Drawing.Point(59, 40)
        Me.cboBusq_Destino.Name = "cboBusq_Destino"
        Me.cboBusq_Destino.Size = New System.Drawing.Size(173, 21)
        Me.cboBusq_Destino.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(4, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destino :"
        '
        'cboBusq_Origen
        '
        Me.cboBusq_Origen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBusq_Origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBusq_Origen.FormattingEnabled = True
        Me.cboBusq_Origen.Location = New System.Drawing.Point(59, 13)
        Me.cboBusq_Origen.Name = "cboBusq_Origen"
        Me.cboBusq_Origen.Size = New System.Drawing.Size(173, 21)
        Me.cboBusq_Origen.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Origen :"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnConsultar.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(779, 6)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(89, 25)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbNuevo, Me.tsbEditar, Me.tsbAnular, Me.tsbSalir})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(874, 27)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TsbNuevo
        '
        Me.TsbNuevo.Image = CType(resources.GetObject("TsbNuevo.Image"), System.Drawing.Image)
        Me.TsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbNuevo.Name = "TsbNuevo"
        Me.TsbNuevo.Size = New System.Drawing.Size(62, 20)
        Me.TsbNuevo.Text = "&Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Checked = True
        Me.tsbEditar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsbEditar.Enabled = False
        Me.tsbEditar.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(65, 23)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources.delete_16
        Me.tsbAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(70, 23)
        Me.tsbAnular.Text = "Anular"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(57, 23)
        Me.tsbSalir.Text = "&Salir"
        '
        'TabMantenimiento
        '
        Me.TabMantenimiento.Controls.Add(Me.GroupBox3)
        Me.TabMantenimiento.Controls.Add(Me.btnCancelar)
        Me.TabMantenimiento.Controls.Add(Me.btnGuardar)
        Me.TabMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.TabMantenimiento.Name = "TabMantenimiento"
        Me.TabMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMantenimiento.Size = New System.Drawing.Size(880, 552)
        Me.TabMantenimiento.TabIndex = 1
        Me.TabMantenimiento.Text = "Mantenimiento"
        Me.TabMantenimiento.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboOrigen)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.cboDestino)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cboServicio)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cboProducto)
        Me.GroupBox3.Controls.Add(Me.cboTipoTarifa)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cboTipoVisibilidad)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.dtpFechaActivacion)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.dgvTarifa)
        Me.GroupBox3.Location = New System.Drawing.Point(100, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(682, 462)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'cboOrigen
        '
        Me.cboOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOrigen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Location = New System.Drawing.Point(95, 19)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(191, 21)
        Me.cboOrigen.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Origen :"
        '
        'cboDestino
        '
        Me.cboDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDestino.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(394, 19)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(222, 21)
        Me.cboDestino.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(317, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Destino :"
        '
        'cboServicio
        '
        Me.cboServicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(395, 101)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(222, 21)
        Me.cboServicio.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(318, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Servicio :"
        '
        'cboProducto
        '
        Me.cboProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(96, 59)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(192, 21)
        Me.cboProducto.TabIndex = 31
        '
        'cboTipoTarifa
        '
        Me.cboTipoTarifa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarifa.FormattingEnabled = True
        Me.cboTipoTarifa.Location = New System.Drawing.Point(395, 59)
        Me.cboTipoTarifa.Name = "cboTipoTarifa"
        Me.cboTipoTarifa.Size = New System.Drawing.Size(222, 21)
        Me.cboTipoTarifa.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Producto :"
        '
        'cboTipoVisibilidad
        '
        Me.cboTipoVisibilidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTipoVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVisibilidad.FormattingEnabled = True
        Me.cboTipoVisibilidad.Location = New System.Drawing.Point(97, 101)
        Me.cboTipoVisibilidad.Name = "cboTipoVisibilidad"
        Me.cboTipoVisibilidad.Size = New System.Drawing.Size(191, 21)
        Me.cboTipoVisibilidad.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(318, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Tipo Tarifa :"
        '
        'dtpFechaActivacion
        '
        Me.dtpFechaActivacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion.Location = New System.Drawing.Point(321, 142)
        Me.dtpFechaActivacion.Name = "dtpFechaActivacion"
        Me.dtpFechaActivacion.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaActivacion.TabIndex = 35
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Tipo Visibilidad :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(192, 144)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Fecha Activacion :"
        '
        'dgvTarifa
        '
        Me.dgvTarifa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTarifa.Location = New System.Drawing.Point(11, 180)
        Me.dgvTarifa.Name = "dgvTarifa"
        Me.dgvTarifa.Size = New System.Drawing.Size(657, 272)
        Me.dgvTarifa.TabIndex = 36
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.INTEGRACION.My.Resources.Resources.IzquierdaTodos
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(503, 504)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 32)
        Me.btnCancelar.TabIndex = 38
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.INTEGRACION.My.Resources.Resources.mp_toolbarGuardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(295, 504)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 32)
        Me.btnGuardar.TabIndex = 37
        Me.btnGuardar.Text = "&Grabar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'FrmTarifaServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 594)
        Me.Controls.Add(Me.tabTarifario)
        Me.Name = "FrmTarifaServicio"
        Me.Text = "Tarifario de Servicios"
        Me.tabTarifario.ResumeLayout(False)
        Me.TabCliente.ResumeLayout(False)
        Me.TabCliente.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltro.ResumeLayout(False)
        Me.grbFiltro.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabMantenimiento.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvTarifa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabTarifario As System.Windows.Forms.TabControl
    Friend WithEvents TabCliente As System.Windows.Forms.TabPage
    Protected WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TsbNuevo As System.Windows.Forms.ToolStripButton
    Protected WithEvents tsbAnular As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents tsbSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents cboBusq_TipoTarifa As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CboBusq_Producto As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CboBusq_TipoVisibildad As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboBusq_Destino As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBusq_Origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoTarifa As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoVisibilidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaActivacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvTarifa As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboBusq_Servicio As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripMenuItem
End Class
