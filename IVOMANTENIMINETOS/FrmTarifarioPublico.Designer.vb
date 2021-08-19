<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTarifarioPublico
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarifarioPublico))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcTarifario = New System.Windows.Forms.TabControl()
        Me.TabCliente = New System.Windows.Forms.TabPage()
        Me.tcListaTarifas = New System.Windows.Forms.TabControl()
        Me.tpTarifasPeso = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCantRegXPeso = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.DgvTarifasPeso = New System.Windows.Forms.DataGridView()
        Me.tpTarifasArticulo = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblCantRegXArticulos = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.DgvTarifaArticulos = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tspAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboBusq_TipoTarifa = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CboBusq_Producto = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CboBusq_TipoVisibildad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.cboBusq_Destino = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBusq_Origen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabMantenimiento = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.tcTipo = New System.Windows.Forms.TabControl()
        Me.tpNormal = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboProducto_Peso = New System.Windows.Forms.ComboBox()
        Me.cboTipoTarifa_Peso = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCiudad = New System.Windows.Forms.ComboBox()
        Me.cboVisibilidad_Peso = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaActivacion_Peso = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtVolumenMinimo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFleteMinimoVolumen = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPesoMinimo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFleteMinimoPeso = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSobre = New System.Windows.Forms.TextBox()
        Me.txtVolumen = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tpArticulos = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DgvMntTarifaArticulos = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboTipoEntrega = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dtpFechaActivacion_Articulos = New System.Windows.Forms.DateTimePicker()
        Me.cboProducto_Articulos = New System.Windows.Forms.ComboBox()
        Me.cboTipoTarifa_Articulos = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckbTarifaArticulos = New System.Windows.Forms.CheckBox()
        Me.ckbTarifaNormal = New System.Windows.Forms.CheckBox()
        Me.CboOrigen_Mnt = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboDestino_Mnt = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tcTarifario.SuspendLayout()
        Me.TabCliente.SuspendLayout()
        Me.tcListaTarifas.SuspendLayout()
        Me.tpTarifasPeso.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.DgvTarifasPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTarifasArticulo.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.DgvTarifaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabMantenimiento.SuspendLayout()
        Me.tcTipo.SuspendLayout()
        Me.tpNormal.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tpArticulos.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DgvMntTarifaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcTarifario
        '
        Me.tcTarifario.Controls.Add(Me.TabCliente)
        Me.tcTarifario.Controls.Add(Me.TabMantenimiento)
        Me.tcTarifario.Location = New System.Drawing.Point(0, 0)
        Me.tcTarifario.Name = "tcTarifario"
        Me.tcTarifario.SelectedIndex = 0
        Me.tcTarifario.Size = New System.Drawing.Size(867, 470)
        Me.tcTarifario.TabIndex = 0
        '
        'TabCliente
        '
        Me.TabCliente.Controls.Add(Me.tcListaTarifas)
        Me.TabCliente.Controls.Add(Me.MenuStrip1)
        Me.TabCliente.Controls.Add(Me.GroupBox1)
        Me.TabCliente.Location = New System.Drawing.Point(4, 22)
        Me.TabCliente.Name = "TabCliente"
        Me.TabCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCliente.Size = New System.Drawing.Size(859, 444)
        Me.TabCliente.TabIndex = 0
        Me.TabCliente.Text = "Lista de tarifas"
        Me.TabCliente.UseVisualStyleBackColor = True
        '
        'tcListaTarifas
        '
        Me.tcListaTarifas.Controls.Add(Me.tpTarifasPeso)
        Me.tcListaTarifas.Controls.Add(Me.tpTarifasArticulo)
        Me.tcListaTarifas.Location = New System.Drawing.Point(4, 99)
        Me.tcListaTarifas.Name = "tcListaTarifas"
        Me.tcListaTarifas.SelectedIndex = 0
        Me.tcListaTarifas.Size = New System.Drawing.Size(849, 345)
        Me.tcListaTarifas.TabIndex = 28
        '
        'tpTarifasPeso
        '
        Me.tpTarifasPeso.Controls.Add(Me.Label5)
        Me.tpTarifasPeso.Controls.Add(Me.lblCantRegXPeso)
        Me.tpTarifasPeso.Controls.Add(Me.GroupBox7)
        Me.tpTarifasPeso.Location = New System.Drawing.Point(4, 22)
        Me.tpTarifasPeso.Name = "tpTarifasPeso"
        Me.tpTarifasPeso.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTarifasPeso.Size = New System.Drawing.Size(841, 319)
        Me.tpTarifasPeso.TabIndex = 0
        Me.tpTarifasPeso.Text = "Tarifas por peso"
        Me.tpTarifasPeso.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(4, 303)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Cantidad de Registros :"
        '
        'lblCantRegXPeso
        '
        Me.lblCantRegXPeso.AutoSize = True
        Me.lblCantRegXPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantRegXPeso.Location = New System.Drawing.Point(146, 303)
        Me.lblCantRegXPeso.Name = "lblCantRegXPeso"
        Me.lblCantRegXPeso.Size = New System.Drawing.Size(14, 13)
        Me.lblCantRegXPeso.TabIndex = 31
        Me.lblCantRegXPeso.Text = "0"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.DgvTarifasPeso)
        Me.GroupBox7.Location = New System.Drawing.Point(3, -2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(835, 302)
        Me.GroupBox7.TabIndex = 27
        Me.GroupBox7.TabStop = False
        '
        'DgvTarifasPeso
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTarifasPeso.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTarifasPeso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTarifasPeso.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTarifasPeso.Location = New System.Drawing.Point(4, 11)
        Me.DgvTarifasPeso.Name = "DgvTarifasPeso"
        Me.DgvTarifasPeso.Size = New System.Drawing.Size(825, 285)
        Me.DgvTarifasPeso.TabIndex = 0
        '
        'tpTarifasArticulo
        '
        Me.tpTarifasArticulo.Controls.Add(Me.Label24)
        Me.tpTarifasArticulo.Controls.Add(Me.lblCantRegXArticulos)
        Me.tpTarifasArticulo.Controls.Add(Me.GroupBox8)
        Me.tpTarifasArticulo.Location = New System.Drawing.Point(4, 22)
        Me.tpTarifasArticulo.Name = "tpTarifasArticulo"
        Me.tpTarifasArticulo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTarifasArticulo.Size = New System.Drawing.Size(841, 319)
        Me.tpTarifasArticulo.TabIndex = 1
        Me.tpTarifasArticulo.Text = "Tarifas por artículos"
        Me.tpTarifasArticulo.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Maroon
        Me.Label24.Location = New System.Drawing.Point(5, 303)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(140, 13)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Cantidad de Registros :"
        '
        'lblCantRegXArticulos
        '
        Me.lblCantRegXArticulos.AutoSize = True
        Me.lblCantRegXArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantRegXArticulos.Location = New System.Drawing.Point(147, 303)
        Me.lblCantRegXArticulos.Name = "lblCantRegXArticulos"
        Me.lblCantRegXArticulos.Size = New System.Drawing.Size(14, 13)
        Me.lblCantRegXArticulos.TabIndex = 33
        Me.lblCantRegXArticulos.Text = "0"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.DgvTarifaArticulos)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(835, 300)
        Me.GroupBox8.TabIndex = 28
        Me.GroupBox8.TabStop = False
        '
        'DgvTarifaArticulos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTarifaArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTarifaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTarifaArticulos.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvTarifaArticulos.Location = New System.Drawing.Point(4, 11)
        Me.DgvTarifaArticulos.Name = "DgvTarifaArticulos"
        Me.DgvTarifaArticulos.Size = New System.Drawing.Size(825, 283)
        Me.DgvTarifaArticulos.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbNuevo, Me.tspAnular, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(853, 27)
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
        'tspAnular
        '
        Me.tspAnular.Image = Global.INTEGRACION.My.Resources.Resources.delete_16
        Me.tspAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tspAnular.Name = "tspAnular"
        Me.tspAnular.Size = New System.Drawing.Size(70, 23)
        Me.tspAnular.Text = "Anular"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(57, 23)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboBusq_TipoTarifa)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.CboBusq_Producto)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.CboBusq_TipoVisibildad)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.cboBusq_Destino)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboBusq_Origen)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(849, 65)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro Busqueda"
        '
        'cboBusq_TipoTarifa
        '
        Me.cboBusq_TipoTarifa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBusq_TipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBusq_TipoTarifa.FormattingEnabled = True
        Me.cboBusq_TipoTarifa.Location = New System.Drawing.Point(281, 40)
        Me.cboBusq_TipoTarifa.Name = "cboBusq_TipoTarifa"
        Me.cboBusq_TipoTarifa.Size = New System.Drawing.Size(166, 21)
        Me.cboBusq_TipoTarifa.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(467, 17)
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
        Me.CboBusq_Producto.Location = New System.Drawing.Point(281, 13)
        Me.CboBusq_Producto.Name = "CboBusq_Producto"
        Me.CboBusq_Producto.Size = New System.Drawing.Size(166, 21)
        Me.CboBusq_Producto.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(222, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Producto :"
        '
        'CboBusq_TipoVisibildad
        '
        Me.CboBusq_TipoVisibildad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboBusq_TipoVisibildad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBusq_TipoVisibildad.FormattingEnabled = True
        Me.CboBusq_TipoVisibildad.Location = New System.Drawing.Point(527, 13)
        Me.CboBusq_TipoVisibildad.Name = "CboBusq_TipoVisibildad"
        Me.CboBusq_TipoVisibildad.Size = New System.Drawing.Size(122, 21)
        Me.CboBusq_TipoVisibildad.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(214, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Tipo Tarifa :"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnConsultar.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(527, 34)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(89, 30)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboBusq_Destino
        '
        Me.cboBusq_Destino.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBusq_Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBusq_Destino.FormattingEnabled = True
        Me.cboBusq_Destino.Location = New System.Drawing.Point(59, 40)
        Me.cboBusq_Destino.Name = "cboBusq_Destino"
        Me.cboBusq_Destino.Size = New System.Drawing.Size(150, 21)
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
        Me.cboBusq_Origen.Size = New System.Drawing.Size(150, 21)
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
        'TabMantenimiento
        '
        Me.TabMantenimiento.Controls.Add(Me.btnCancelar)
        Me.TabMantenimiento.Controls.Add(Me.btnGuardar)
        Me.TabMantenimiento.Controls.Add(Me.tcTipo)
        Me.TabMantenimiento.Controls.Add(Me.GroupBox2)
        Me.TabMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.TabMantenimiento.Name = "TabMantenimiento"
        Me.TabMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMantenimiento.Size = New System.Drawing.Size(859, 444)
        Me.TabMantenimiento.TabIndex = 1
        Me.TabMantenimiento.Text = "Mantenimiento"
        Me.TabMantenimiento.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.INTEGRACION.My.Resources.Resources.IzquierdaTodos
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(318, 401)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 32)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.INTEGRACION.My.Resources.Resources.mp_toolbarGuardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(430, 401)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 32)
        Me.btnGuardar.TabIndex = 28
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'tcTipo
        '
        Me.tcTipo.Controls.Add(Me.tpNormal)
        Me.tcTipo.Controls.Add(Me.tpArticulos)
        Me.tcTipo.Location = New System.Drawing.Point(3, 66)
        Me.tcTipo.Name = "tcTipo"
        Me.tcTipo.SelectedIndex = 0
        Me.tcTipo.Size = New System.Drawing.Size(853, 327)
        Me.tcTipo.TabIndex = 27
        '
        'tpNormal
        '
        Me.tpNormal.Controls.Add(Me.GroupBox6)
        Me.tpNormal.Controls.Add(Me.GroupBox3)
        Me.tpNormal.Location = New System.Drawing.Point(4, 22)
        Me.tpNormal.Name = "tpNormal"
        Me.tpNormal.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNormal.Size = New System.Drawing.Size(845, 301)
        Me.tpNormal.TabIndex = 0
        Me.tpNormal.Text = "Normal"
        Me.tpNormal.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboProducto_Peso)
        Me.GroupBox6.Controls.Add(Me.cboTipoTarifa_Peso)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.cboCiudad)
        Me.GroupBox6.Controls.Add(Me.cboVisibilidad_Peso)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.dtpFechaActivacion_Peso)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Location = New System.Drawing.Point(3, -2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(278, 297)
        Me.GroupBox6.TabIndex = 27
        Me.GroupBox6.TabStop = False
        '
        'cboProducto_Peso
        '
        Me.cboProducto_Peso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboProducto_Peso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto_Peso.FormattingEnabled = True
        Me.cboProducto_Peso.Location = New System.Drawing.Point(93, 19)
        Me.cboProducto_Peso.Name = "cboProducto_Peso"
        Me.cboProducto_Peso.Size = New System.Drawing.Size(165, 21)
        Me.cboProducto_Peso.TabIndex = 1
        '
        'cboTipoTarifa_Peso
        '
        Me.cboTipoTarifa_Peso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTipoTarifa_Peso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarifa_Peso.FormattingEnabled = True
        Me.cboTipoTarifa_Peso.Location = New System.Drawing.Point(93, 46)
        Me.cboTipoTarifa_Peso.Name = "cboTipoTarifa_Peso"
        Me.cboTipoTarifa_Peso.Size = New System.Drawing.Size(165, 21)
        Me.cboTipoTarifa_Peso.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Producto :"
        '
        'cboCiudad
        '
        Me.cboCiudad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudad.FormattingEnabled = True
        Me.cboCiudad.Location = New System.Drawing.Point(93, 105)
        Me.cboCiudad.Name = "cboCiudad"
        Me.cboCiudad.Size = New System.Drawing.Size(165, 21)
        Me.cboCiudad.TabIndex = 5
        '
        'cboVisibilidad_Peso
        '
        Me.cboVisibilidad_Peso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVisibilidad_Peso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisibilidad_Peso.FormattingEnabled = True
        Me.cboVisibilidad_Peso.Location = New System.Drawing.Point(93, 76)
        Me.cboVisibilidad_Peso.Name = "cboVisibilidad_Peso"
        Me.cboVisibilidad_Peso.Size = New System.Drawing.Size(165, 21)
        Me.cboVisibilidad_Peso.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tipo Tarifa :"
        '
        'dtpFechaActivacion_Peso
        '
        Me.dtpFechaActivacion_Peso.Enabled = False
        Me.dtpFechaActivacion_Peso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion_Peso.Location = New System.Drawing.Point(93, 144)
        Me.dtpFechaActivacion_Peso.Name = "dtpFechaActivacion_Peso"
        Me.dtpFechaActivacion_Peso.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaActivacion_Peso.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(49, 108)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 13)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Ciudad :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Tipo Visibilidad :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(0, 146)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Fecha Activacion :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtVolumenMinimo)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtFleteMinimoVolumen)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtPesoMinimo)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtFleteMinimoPeso)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtSobre)
        Me.GroupBox3.Controls.Add(Me.txtVolumen)
        Me.GroupBox3.Controls.Add(Me.txtPeso)
        Me.GroupBox3.Controls.Add(Me.txtBase)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(284, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 296)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        '
        'txtVolumenMinimo
        '
        Me.txtVolumenMinimo.Location = New System.Drawing.Point(328, 78)
        Me.txtVolumenMinimo.Name = "txtVolumenMinimo"
        Me.txtVolumenMinimo.Size = New System.Drawing.Size(100, 20)
        Me.txtVolumenMinimo.TabIndex = 15
        Me.txtVolumenMinimo.Text = ".00"
        Me.txtVolumenMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(235, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 13)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Volumen mínimo :"
        '
        'txtFleteMinimoVolumen
        '
        Me.txtFleteMinimoVolumen.Location = New System.Drawing.Point(328, 104)
        Me.txtFleteMinimoVolumen.Name = "txtFleteMinimoVolumen"
        Me.txtFleteMinimoVolumen.Size = New System.Drawing.Size(100, 20)
        Me.txtFleteMinimoVolumen.TabIndex = 13
        Me.txtFleteMinimoVolumen.Text = ".00"
        Me.txtFleteMinimoVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(213, 107)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(113, 13)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "Flete mínimo volumen:"
        '
        'txtPesoMinimo
        '
        Me.txtPesoMinimo.Location = New System.Drawing.Point(328, 21)
        Me.txtPesoMinimo.Name = "txtPesoMinimo"
        Me.txtPesoMinimo.Size = New System.Drawing.Size(100, 20)
        Me.txtPesoMinimo.TabIndex = 11
        Me.txtPesoMinimo.Text = ".00"
        Me.txtPesoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(252, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Peso mínimo :"
        '
        'txtFleteMinimoPeso
        '
        Me.txtFleteMinimoPeso.Location = New System.Drawing.Point(328, 50)
        Me.txtFleteMinimoPeso.Name = "txtFleteMinimoPeso"
        Me.txtFleteMinimoPeso.Size = New System.Drawing.Size(100, 20)
        Me.txtFleteMinimoPeso.TabIndex = 9
        Me.txtFleteMinimoPeso.Text = ".00"
        Me.txtFleteMinimoPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(230, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Flete mínimo peso:"
        '
        'txtSobre
        '
        Me.txtSobre.Location = New System.Drawing.Point(80, 78)
        Me.txtSobre.Name = "txtSobre"
        Me.txtSobre.Size = New System.Drawing.Size(100, 20)
        Me.txtSobre.TabIndex = 7
        Me.txtSobre.Text = ".00"
        Me.txtSobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVolumen
        '
        Me.txtVolumen.Location = New System.Drawing.Point(80, 50)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(100, 20)
        Me.txtVolumen.TabIndex = 6
        Me.txtVolumen.Text = ".00"
        Me.txtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(80, 21)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(100, 20)
        Me.txtPeso.TabIndex = 5
        Me.txtPeso.Text = ".00"
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBase
        '
        Me.txtBase.Location = New System.Drawing.Point(80, 104)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(100, 20)
        Me.txtBase.TabIndex = 4
        Me.txtBase.Text = ".00"
        Me.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Sobre :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Volumen :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Peso :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Base :"
        '
        'tpArticulos
        '
        Me.tpArticulos.Controls.Add(Me.GroupBox5)
        Me.tpArticulos.Controls.Add(Me.GroupBox4)
        Me.tpArticulos.Location = New System.Drawing.Point(4, 22)
        Me.tpArticulos.Name = "tpArticulos"
        Me.tpArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpArticulos.Size = New System.Drawing.Size(845, 301)
        Me.tpArticulos.TabIndex = 1
        Me.tpArticulos.Text = "Artículos"
        Me.tpArticulos.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.DgvMntTarifaArticulos)
        Me.GroupBox5.Location = New System.Drawing.Point(285, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(554, 295)
        Me.GroupBox5.TabIndex = 27
        Me.GroupBox5.TabStop = False
        '
        'DgvMntTarifaArticulos
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvMntTarifaArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvMntTarifaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvMntTarifaArticulos.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgvMntTarifaArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMntTarifaArticulos.Location = New System.Drawing.Point(3, 16)
        Me.DgvMntTarifaArticulos.Name = "DgvMntTarifaArticulos"
        Me.DgvMntTarifaArticulos.Size = New System.Drawing.Size(548, 276)
        Me.DgvMntTarifaArticulos.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboTipoEntrega)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.dtpFechaActivacion_Articulos)
        Me.GroupBox4.Controls.Add(Me.cboProducto_Articulos)
        Me.GroupBox4.Controls.Add(Me.cboTipoTarifa_Articulos)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(276, 296)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        '
        'cboTipoEntrega
        '
        Me.cboTipoEntrega.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTipoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEntrega.FormattingEnabled = True
        Me.cboTipoEntrega.Location = New System.Drawing.Point(98, 73)
        Me.cboTipoEntrega.Name = "cboTipoEntrega"
        Me.cboTipoEntrega.Size = New System.Drawing.Size(165, 21)
        Me.cboTipoEntrega.TabIndex = 11
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(18, 76)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 13)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "Tipo Entrega :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(1, 107)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(96, 13)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "Fecha Activacion :"
        '
        'dtpFechaActivacion_Articulos
        '
        Me.dtpFechaActivacion_Articulos.Enabled = False
        Me.dtpFechaActivacion_Articulos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion_Articulos.Location = New System.Drawing.Point(98, 104)
        Me.dtpFechaActivacion_Articulos.Name = "dtpFechaActivacion_Articulos"
        Me.dtpFechaActivacion_Articulos.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaActivacion_Articulos.TabIndex = 8
        '
        'cboProducto_Articulos
        '
        Me.cboProducto_Articulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto_Articulos.FormattingEnabled = True
        Me.cboProducto_Articulos.Location = New System.Drawing.Point(98, 19)
        Me.cboProducto_Articulos.Name = "cboProducto_Articulos"
        Me.cboProducto_Articulos.Size = New System.Drawing.Size(165, 21)
        Me.cboProducto_Articulos.TabIndex = 5
        '
        'cboTipoTarifa_Articulos
        '
        Me.cboTipoTarifa_Articulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarifa_Articulos.FormattingEnabled = True
        Me.cboTipoTarifa_Articulos.Location = New System.Drawing.Point(98, 46)
        Me.cboTipoTarifa_Articulos.Name = "cboTipoTarifa_Articulos"
        Me.cboTipoTarifa_Articulos.Size = New System.Drawing.Size(165, 21)
        Me.cboTipoTarifa_Articulos.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(41, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Producto :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(33, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 13)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Tipo Tarifa :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckbTarifaArticulos)
        Me.GroupBox2.Controls.Add(Me.ckbTarifaNormal)
        Me.GroupBox2.Controls.Add(Me.CboOrigen_Mnt)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cboDestino_Mnt)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(853, 65)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'ckbTarifaArticulos
        '
        Me.ckbTarifaArticulos.AutoSize = True
        Me.ckbTarifaArticulos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ckbTarifaArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbTarifaArticulos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ckbTarifaArticulos.Location = New System.Drawing.Point(340, 41)
        Me.ckbTarifaArticulos.Name = "ckbTarifaArticulos"
        Me.ckbTarifaArticulos.Size = New System.Drawing.Size(113, 17)
        Me.ckbTarifaArticulos.TabIndex = 7
        Me.ckbTarifaArticulos.Text = "Tarifa artículos"
        Me.ckbTarifaArticulos.UseVisualStyleBackColor = True
        '
        'ckbTarifaNormal
        '
        Me.ckbTarifaNormal.AutoSize = True
        Me.ckbTarifaNormal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ckbTarifaNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbTarifaNormal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ckbTarifaNormal.Location = New System.Drawing.Point(165, 41)
        Me.ckbTarifaNormal.Name = "ckbTarifaNormal"
        Me.ckbTarifaNormal.Size = New System.Drawing.Size(100, 17)
        Me.ckbTarifaNormal.TabIndex = 6
        Me.ckbTarifaNormal.Text = "Tarifa normal"
        Me.ckbTarifaNormal.UseVisualStyleBackColor = True
        '
        'CboOrigen_Mnt
        '
        Me.CboOrigen_Mnt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboOrigen_Mnt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboOrigen_Mnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboOrigen_Mnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboOrigen_Mnt.FormattingEnabled = True
        Me.CboOrigen_Mnt.Location = New System.Drawing.Point(100, 14)
        Me.CboOrigen_Mnt.Name = "CboOrigen_Mnt"
        Me.CboOrigen_Mnt.Size = New System.Drawing.Size(165, 21)
        Me.CboOrigen_Mnt.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(50, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Origen :"
        '
        'cboDestino_Mnt
        '
        Me.cboDestino_Mnt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDestino_Mnt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDestino_Mnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDestino_Mnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino_Mnt.FormattingEnabled = True
        Me.cboDestino_Mnt.Location = New System.Drawing.Point(340, 14)
        Me.cboDestino_Mnt.Name = "cboDestino_Mnt"
        Me.cboDestino_Mnt.Size = New System.Drawing.Size(176, 21)
        Me.cboDestino_Mnt.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(286, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Destino :"
        '
        'FrmTarifarioPublico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 471)
        Me.Controls.Add(Me.tcTarifario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTarifarioPublico"
        Me.ShowIcon = False
        Me.Text = "TARIFARIO PÚBLICO"
        Me.tcTarifario.ResumeLayout(False)
        Me.TabCliente.ResumeLayout(False)
        Me.TabCliente.PerformLayout()
        Me.tcListaTarifas.ResumeLayout(False)
        Me.tpTarifasPeso.ResumeLayout(False)
        Me.tpTarifasPeso.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.DgvTarifasPeso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTarifasArticulo.ResumeLayout(False)
        Me.tpTarifasArticulo.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.DgvTarifaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabMantenimiento.ResumeLayout(False)
        Me.tcTipo.ResumeLayout(False)
        Me.tpNormal.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tpArticulos.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DgvMntTarifaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcTarifario As System.Windows.Forms.TabControl
    Friend WithEvents TabCliente As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboBusq_Destino As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBusq_Origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TsbNuevo As System.Windows.Forms.ToolStripButton
    Protected WithEvents tspAnular As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoTarifa_Peso As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSobre As System.Windows.Forms.TextBox
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaActivacion_Peso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboDestino_Mnt As System.Windows.Forms.ComboBox
    Friend WithEvents CboOrigen_Mnt As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboBusq_TipoVisibildad As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFleteMinimoPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboVisibilidad_Peso As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CboBusq_Producto As System.Windows.Forms.ComboBox
    Friend WithEvents txtPesoMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboBusq_TipoTarifa As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboProducto_Peso As System.Windows.Forms.ComboBox
    Friend WithEvents ckbTarifaArticulos As System.Windows.Forms.CheckBox
    Friend WithEvents ckbTarifaNormal As System.Windows.Forms.CheckBox
    Friend WithEvents tcTipo As System.Windows.Forms.TabControl
    Friend WithEvents tpNormal As System.Windows.Forms.TabPage
    Friend WithEvents tpArticulos As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVolumenMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFleteMinimoVolumen As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvTarifasPeso As System.Windows.Forms.DataGridView
    Friend WithEvents tcListaTarifas As System.Windows.Forms.TabControl
    Friend WithEvents tpTarifasPeso As System.Windows.Forms.TabPage
    Friend WithEvents tpTarifasArticulo As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvTarifaArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFechaActivacion_Articulos As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboProducto_Articulos As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoTarifa_Articulos As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DgvMntTarifaArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCantRegXPeso As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblCantRegXArticulos As System.Windows.Forms.Label
    Friend WithEvents cboTipoEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class
