<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTarifarioPerso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarifarioPerso))
        Me.tcTarifas = New System.Windows.Forms.TabControl()
        Me.TabListar = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DgvClientes = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbRazonSocial = New System.Windows.Forms.RadioButton()
        Me.rbRuc = New System.Windows.Forms.RadioButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtCliente_Buscar = New System.Windows.Forms.TextBox()
        Me.TabCliente = New System.Windows.Forms.TabPage()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboSubCuenta_Cliente = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtCliente_Cliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarTarifas = New System.Windows.Forms.Button()
        Me.cboDestino_Cliente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboOrigen_Cliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tcListaTarifas = New System.Windows.Forms.TabControl()
        Me.tpListTarifasPeso = New System.Windows.Forms.TabPage()
        Me.DgvListTarifasPeso = New System.Windows.Forms.DataGridView()
        Me.lblCantRegXPeso = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tpTarifasArticulos = New System.Windows.Forms.TabPage()
        Me.lblCantRegXArticulos = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DgvListTarifasArticulos = New System.Windows.Forms.DataGridView()
        Me.TabTarifa = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ckbTarifaArticulos = New System.Windows.Forms.CheckBox()
        Me.ckbTarifaNormal = New System.Windows.Forms.CheckBox()
        Me.cboOrigen_Mnt = New System.Windows.Forms.ComboBox()
        Me.cboDestino_Mnt = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tcTipo = New System.Windows.Forms.TabControl()
        Me.tpNormal = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaActivacion_Peso = New System.Windows.Forms.DateTimePicker()
        Me.cboProducto_peso = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSubCuenta_Peso = New System.Windows.Forms.ComboBox()
        Me.cboTipoTarifa = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.gbxMntTarifaNormal = New System.Windows.Forms.GroupBox()
        Me.txtVolumenMinimo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFleteMinimoVolumen = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPesoMinimo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtFleteMinimoPeso = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TxtVolumen = New System.Windows.Forms.TextBox()
        Me.TxtSobre = New System.Windows.Forms.TextBox()
        Me.TxtPeso = New System.Windows.Forms.TextBox()
        Me.TxtBase = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tpArticulo = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaActivacion_Articulos = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboProducto_Articulos = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboSubCuenta_Articulos = New System.Windows.Forms.ComboBox()
        Me.lblSubCuenta = New System.Windows.Forms.Label()
        Me.GbxMntTarifaArticulos = New System.Windows.Forms.GroupBox()
        Me.DgvMntTarifaArticulos = New System.Windows.Forms.DataGridView()
        Me.tcTarifas.SuspendLayout()
        Me.TabListar.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabCliente.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tcListaTarifas.SuspendLayout()
        Me.tpListTarifasPeso.SuspendLayout()
        CType(Me.DgvListTarifasPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTarifasArticulos.SuspendLayout()
        CType(Me.DgvListTarifasArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabTarifa.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.tcTipo.SuspendLayout()
        Me.tpNormal.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gbxMntTarifaNormal.SuspendLayout()
        Me.tpArticulo.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GbxMntTarifaArticulos.SuspendLayout()
        CType(Me.DgvMntTarifaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcTarifas
        '
        Me.tcTarifas.Controls.Add(Me.TabListar)
        Me.tcTarifas.Controls.Add(Me.TabCliente)
        Me.tcTarifas.Controls.Add(Me.TabTarifa)
        Me.tcTarifas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcTarifas.Location = New System.Drawing.Point(0, 0)
        Me.tcTarifas.Name = "tcTarifas"
        Me.tcTarifas.SelectedIndex = 0
        Me.tcTarifas.Size = New System.Drawing.Size(898, 478)
        Me.tcTarifas.TabIndex = 0
        '
        'TabListar
        '
        Me.TabListar.Controls.Add(Me.Label8)
        Me.TabListar.Controls.Add(Me.Label6)
        Me.TabListar.Controls.Add(Me.GroupBox4)
        Me.TabListar.Controls.Add(Me.GroupBox3)
        Me.TabListar.Location = New System.Drawing.Point(4, 22)
        Me.TabListar.Name = "TabListar"
        Me.TabListar.Padding = New System.Windows.Forms.Padding(3)
        Me.TabListar.Size = New System.Drawing.Size(890, 452)
        Me.TabListar.TabIndex = 1
        Me.TabListar.Text = "Listado de Clientes"
        Me.TabListar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(120, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(4, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Cantidad Clientes :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DgvClientes)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 66)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(883, 372)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'DgvClientes
        '
        Me.DgvClientes.Location = New System.Drawing.Point(5, 12)
        Me.DgvClientes.Name = "DgvClientes"
        Me.DgvClientes.Size = New System.Drawing.Size(872, 350)
        Me.DgvClientes.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbRazonSocial)
        Me.GroupBox3.Controls.Add(Me.rbRuc)
        Me.GroupBox3.Controls.Add(Me.btnBuscar)
        Me.GroupBox3.Controls.Add(Me.txtCliente_Buscar)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(2, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(885, 51)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar por:"
        '
        'rbRazonSocial
        '
        Me.rbRazonSocial.AutoSize = True
        Me.rbRazonSocial.Checked = True
        Me.rbRazonSocial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRazonSocial.ForeColor = System.Drawing.SystemColors.Desktop
        Me.rbRazonSocial.Location = New System.Drawing.Point(74, 18)
        Me.rbRazonSocial.Name = "rbRazonSocial"
        Me.rbRazonSocial.Size = New System.Drawing.Size(88, 17)
        Me.rbRazonSocial.TabIndex = 1
        Me.rbRazonSocial.TabStop = True
        Me.rbRazonSocial.Text = "Razòn Social"
        Me.rbRazonSocial.UseVisualStyleBackColor = True
        '
        'rbRuc
        '
        Me.rbRuc.AutoSize = True
        Me.rbRuc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRuc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.rbRuc.Location = New System.Drawing.Point(6, 19)
        Me.rbRuc.Name = "rbRuc"
        Me.rbRuc.Size = New System.Drawing.Size(48, 17)
        Me.rbRuc.TabIndex = 0
        Me.rbRuc.Text = "RUC"
        Me.rbRuc.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnBuscar.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(492, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 29)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtCliente_Buscar
        '
        Me.txtCliente_Buscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente_Buscar.Location = New System.Drawing.Point(162, 18)
        Me.txtCliente_Buscar.Name = "txtCliente_Buscar"
        Me.txtCliente_Buscar.Size = New System.Drawing.Size(324, 20)
        Me.txtCliente_Buscar.TabIndex = 2
        '
        'TabCliente
        '
        Me.TabCliente.Controls.Add(Me.toolStrip1)
        Me.TabCliente.Controls.Add(Me.GroupBox1)
        Me.TabCliente.Controls.Add(Me.GroupBox2)
        Me.TabCliente.Location = New System.Drawing.Point(4, 22)
        Me.TabCliente.Name = "TabCliente"
        Me.TabCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCliente.Size = New System.Drawing.Size(890, 452)
        Me.TabCliente.TabIndex = 0
        Me.TabCliente.Text = "Listado de tarifas x Cliente"
        Me.TabCliente.UseVisualStyleBackColor = True
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.toolStripSeparator2, Me.AnularToolStripMenuItem, Me.ToolStripSeparator1, Me.CancelarToolStripMenuItem, Me.SalirToolStripMenuItem, Me.EditarToolStripMenuItem})
        Me.toolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(884, 25)
        Me.toolStrip1.TabIndex = 33
        Me.toolStrip1.Text = "toolStrip1"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = CType(resources.GetObject("NuevoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(62, 22)
        Me.NuevoToolStripMenuItem.Text = "&Nuevo"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources.delete_16
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(62, 22)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources.IzquierdaTodos
        Me.CancelarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(73, 22)
        Me.CancelarToolStripMenuItem.Text = "&Cancelar"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources._1323
        Me.SalirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(49, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.EditarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(57, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        Me.EditarToolStripMenuItem.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSubCuenta_Cliente)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtCliente_Cliente)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnBuscarTarifas)
        Me.GroupBox1.Controls.Add(Me.cboDestino_Cliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboOrigen_Cliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(882, 62)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'cboSubCuenta_Cliente
        '
        Me.cboSubCuenta_Cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSubCuenta_Cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSubCuenta_Cliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSubCuenta_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubCuenta_Cliente.FormattingEnabled = True
        Me.cboSubCuenta_Cliente.Location = New System.Drawing.Point(71, 35)
        Me.cboSubCuenta_Cliente.Name = "cboSubCuenta_Cliente"
        Me.cboSubCuenta_Cliente.Size = New System.Drawing.Size(162, 21)
        Me.cboSubCuenta_Cliente.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(4, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "SubCuenta :"
        '
        'txtCliente_Cliente
        '
        Me.txtCliente_Cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente_Cliente.Enabled = False
        Me.txtCliente_Cliente.Location = New System.Drawing.Point(71, 11)
        Me.txtCliente_Cliente.Name = "txtCliente_Cliente"
        Me.txtCliente_Cliente.Size = New System.Drawing.Size(337, 20)
        Me.txtCliente_Cliente.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(28, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cliente:"
        '
        'btnBuscarTarifas
        '
        Me.btnBuscarTarifas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarTarifas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarTarifas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarTarifas.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnBuscarTarifas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarTarifas.Location = New System.Drawing.Point(596, 25)
        Me.btnBuscarTarifas.Name = "btnBuscarTarifas"
        Me.btnBuscarTarifas.Size = New System.Drawing.Size(90, 32)
        Me.btnBuscarTarifas.TabIndex = 8
        Me.btnBuscarTarifas.Text = "Consultar"
        Me.btnBuscarTarifas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarTarifas.UseVisualStyleBackColor = True
        '
        'cboDestino_Cliente
        '
        Me.cboDestino_Cliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDestino_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino_Cliente.FormattingEnabled = True
        Me.cboDestino_Cliente.Location = New System.Drawing.Point(468, 35)
        Me.cboDestino_Cliente.Name = "cboDestino_Cliente"
        Me.cboDestino_Cliente.Size = New System.Drawing.Size(123, 21)
        Me.cboDestino_Cliente.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(421, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Destino :"
        '
        'cboOrigen_Cliente
        '
        Me.cboOrigen_Cliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOrigen_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen_Cliente.FormattingEnabled = True
        Me.cboOrigen_Cliente.Location = New System.Drawing.Point(281, 35)
        Me.cboOrigen_Cliente.Name = "cboOrigen_Cliente"
        Me.cboOrigen_Cliente.Size = New System.Drawing.Size(127, 21)
        Me.cboOrigen_Cliente.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(240, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Origen :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tcListaTarifas)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(882, 365)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        '
        'tcListaTarifas
        '
        Me.tcListaTarifas.Controls.Add(Me.tpListTarifasPeso)
        Me.tcListaTarifas.Controls.Add(Me.tpTarifasArticulos)
        Me.tcListaTarifas.Location = New System.Drawing.Point(3, 10)
        Me.tcListaTarifas.Name = "tcListaTarifas"
        Me.tcListaTarifas.SelectedIndex = 0
        Me.tcListaTarifas.Size = New System.Drawing.Size(876, 352)
        Me.tcListaTarifas.TabIndex = 0
        '
        'tpListTarifasPeso
        '
        Me.tpListTarifasPeso.Controls.Add(Me.DgvListTarifasPeso)
        Me.tpListTarifasPeso.Controls.Add(Me.lblCantRegXPeso)
        Me.tpListTarifasPeso.Controls.Add(Me.Label5)
        Me.tpListTarifasPeso.Location = New System.Drawing.Point(4, 22)
        Me.tpListTarifasPeso.Name = "tpListTarifasPeso"
        Me.tpListTarifasPeso.Padding = New System.Windows.Forms.Padding(3)
        Me.tpListTarifasPeso.Size = New System.Drawing.Size(868, 326)
        Me.tpListTarifasPeso.TabIndex = 0
        Me.tpListTarifasPeso.Text = "Tarifas por peso"
        Me.tpListTarifasPeso.UseVisualStyleBackColor = True
        '
        'DgvListTarifasPeso
        '
        Me.DgvListTarifasPeso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvListTarifasPeso.Location = New System.Drawing.Point(0, 6)
        Me.DgvListTarifasPeso.Name = "DgvListTarifasPeso"
        Me.DgvListTarifasPeso.Size = New System.Drawing.Size(865, 299)
        Me.DgvListTarifasPeso.TabIndex = 0
        '
        'lblCantRegXPeso
        '
        Me.lblCantRegXPeso.AutoSize = True
        Me.lblCantRegXPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantRegXPeso.ForeColor = System.Drawing.Color.Maroon
        Me.lblCantRegXPeso.Location = New System.Drawing.Point(123, 308)
        Me.lblCantRegXPeso.Name = "lblCantRegXPeso"
        Me.lblCantRegXPeso.Size = New System.Drawing.Size(14, 13)
        Me.lblCantRegXPeso.TabIndex = 30
        Me.lblCantRegXPeso.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(3, 308)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Cantidad Registros :"
        '
        'tpTarifasArticulos
        '
        Me.tpTarifasArticulos.Controls.Add(Me.lblCantRegXArticulos)
        Me.tpTarifasArticulos.Controls.Add(Me.Label22)
        Me.tpTarifasArticulos.Controls.Add(Me.DgvListTarifasArticulos)
        Me.tpTarifasArticulos.Location = New System.Drawing.Point(4, 22)
        Me.tpTarifasArticulos.Name = "tpTarifasArticulos"
        Me.tpTarifasArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTarifasArticulos.Size = New System.Drawing.Size(868, 326)
        Me.tpTarifasArticulos.TabIndex = 1
        Me.tpTarifasArticulos.Text = "Tarifas por artículos"
        Me.tpTarifasArticulos.UseVisualStyleBackColor = True
        '
        'lblCantRegXArticulos
        '
        Me.lblCantRegXArticulos.AutoSize = True
        Me.lblCantRegXArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantRegXArticulos.ForeColor = System.Drawing.Color.Maroon
        Me.lblCantRegXArticulos.Location = New System.Drawing.Point(125, 308)
        Me.lblCantRegXArticulos.Name = "lblCantRegXArticulos"
        Me.lblCantRegXArticulos.Size = New System.Drawing.Size(14, 13)
        Me.lblCantRegXArticulos.TabIndex = 32
        Me.lblCantRegXArticulos.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Maroon
        Me.Label22.Location = New System.Drawing.Point(3, 308)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 13)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "Cantidad Registros :"
        '
        'DgvListTarifasArticulos
        '
        Me.DgvListTarifasArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvListTarifasArticulos.Location = New System.Drawing.Point(1, 6)
        Me.DgvListTarifasArticulos.Name = "DgvListTarifasArticulos"
        Me.DgvListTarifasArticulos.Size = New System.Drawing.Size(865, 299)
        Me.DgvListTarifasArticulos.TabIndex = 1
        '
        'TabTarifa
        '
        Me.TabTarifa.Controls.Add(Me.btnCancelar)
        Me.TabTarifa.Controls.Add(Me.btnGuardar)
        Me.TabTarifa.Controls.Add(Me.GroupBox5)
        Me.TabTarifa.Controls.Add(Me.GroupBox7)
        Me.TabTarifa.Controls.Add(Me.tcTipo)
        Me.TabTarifa.Location = New System.Drawing.Point(4, 22)
        Me.TabTarifa.Name = "TabTarifa"
        Me.TabTarifa.Size = New System.Drawing.Size(890, 452)
        Me.TabTarifa.TabIndex = 2
        Me.TabTarifa.Text = "Mantenimiento"
        Me.TabTarifa.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.INTEGRACION.My.Resources.Resources.IzquierdaTodos
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(298, 415)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.INTEGRACION.My.Resources.Resources.mp_toolbarGuardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(410, 415)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtCliente)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.TxtCodigo)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(882, 45)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(338, 15)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(180, 20)
        Me.txtCliente.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(261, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Razon Social :"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Enabled = False
        Me.TxtCodigo.Location = New System.Drawing.Point(91, 15)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(162, 20)
        Me.TxtCodigo.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Codigo Cliente :"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ckbTarifaArticulos)
        Me.GroupBox7.Controls.Add(Me.ckbTarifaNormal)
        Me.GroupBox7.Controls.Add(Me.cboOrigen_Mnt)
        Me.GroupBox7.Controls.Add(Me.cboDestino_Mnt)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox7.Location = New System.Drawing.Point(5, 39)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(882, 59)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        '
        'ckbTarifaArticulos
        '
        Me.ckbTarifaArticulos.AutoSize = True
        Me.ckbTarifaArticulos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ckbTarifaArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbTarifaArticulos.Location = New System.Drawing.Point(254, 36)
        Me.ckbTarifaArticulos.Name = "ckbTarifaArticulos"
        Me.ckbTarifaArticulos.Size = New System.Drawing.Size(113, 17)
        Me.ckbTarifaArticulos.TabIndex = 5
        Me.ckbTarifaArticulos.Text = "Tarifa artículos"
        Me.ckbTarifaArticulos.UseVisualStyleBackColor = True
        '
        'ckbTarifaNormal
        '
        Me.ckbTarifaNormal.AutoSize = True
        Me.ckbTarifaNormal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ckbTarifaNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbTarifaNormal.Location = New System.Drawing.Point(91, 36)
        Me.ckbTarifaNormal.Name = "ckbTarifaNormal"
        Me.ckbTarifaNormal.Size = New System.Drawing.Size(100, 17)
        Me.ckbTarifaNormal.TabIndex = 4
        Me.ckbTarifaNormal.Text = "Tarifa normal"
        Me.ckbTarifaNormal.UseVisualStyleBackColor = True
        '
        'cboOrigen_Mnt
        '
        Me.cboOrigen_Mnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOrigen_Mnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen_Mnt.FormattingEnabled = True
        Me.cboOrigen_Mnt.Location = New System.Drawing.Point(91, 9)
        Me.cboOrigen_Mnt.Name = "cboOrigen_Mnt"
        Me.cboOrigen_Mnt.Size = New System.Drawing.Size(162, 21)
        Me.cboOrigen_Mnt.TabIndex = 1
        '
        'cboDestino_Mnt
        '
        Me.cboDestino_Mnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDestino_Mnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino_Mnt.FormattingEnabled = True
        Me.cboDestino_Mnt.Location = New System.Drawing.Point(338, 9)
        Me.cboDestino_Mnt.Name = "cboDestino_Mnt"
        Me.cboDestino_Mnt.Size = New System.Drawing.Size(180, 21)
        Me.cboDestino_Mnt.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(286, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Destino :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(38, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Origen :"
        '
        'tcTipo
        '
        Me.tcTipo.Controls.Add(Me.tpNormal)
        Me.tcTipo.Controls.Add(Me.tpArticulo)
        Me.tcTipo.Location = New System.Drawing.Point(6, 101)
        Me.tcTipo.Name = "tcTipo"
        Me.tcTipo.SelectedIndex = 0
        Me.tcTipo.Size = New System.Drawing.Size(881, 311)
        Me.tcTipo.TabIndex = 2
        '
        'tpNormal
        '
        Me.tpNormal.Controls.Add(Me.GroupBox6)
        Me.tpNormal.Controls.Add(Me.gbxMntTarifaNormal)
        Me.tpNormal.Location = New System.Drawing.Point(4, 22)
        Me.tpNormal.Name = "tpNormal"
        Me.tpNormal.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNormal.Size = New System.Drawing.Size(873, 285)
        Me.tpNormal.TabIndex = 0
        Me.tpNormal.Text = "Normal"
        Me.tpNormal.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaActivacion_Peso)
        Me.GroupBox6.Controls.Add(Me.cboProducto_peso)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.cboSubCuenta_Peso)
        Me.GroupBox6.Controls.Add(Me.cboTipoTarifa)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(283, 276)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'dtpFechaActivacion_Peso
        '
        Me.dtpFechaActivacion_Peso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaActivacion_Peso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion_Peso.Location = New System.Drawing.Point(114, 104)
        Me.dtpFechaActivacion_Peso.Name = "dtpFechaActivacion_Peso"
        Me.dtpFechaActivacion_Peso.Size = New System.Drawing.Size(149, 20)
        Me.dtpFechaActivacion_Peso.TabIndex = 7
        '
        'cboProducto_peso
        '
        Me.cboProducto_peso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboProducto_peso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto_peso.FormattingEnabled = True
        Me.cboProducto_peso.Location = New System.Drawing.Point(83, 17)
        Me.cboProducto_peso.Name = "cboProducto_peso"
        Me.cboProducto_peso.Size = New System.Drawing.Size(180, 21)
        Me.cboProducto_peso.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(21, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Producto :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(12, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fecha Activacion :"
        '
        'cboSubCuenta_Peso
        '
        Me.cboSubCuenta_Peso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSubCuenta_Peso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubCuenta_Peso.FormattingEnabled = True
        Me.cboSubCuenta_Peso.Location = New System.Drawing.Point(83, 75)
        Me.cboSubCuenta_Peso.Name = "cboSubCuenta_Peso"
        Me.cboSubCuenta_Peso.Size = New System.Drawing.Size(180, 21)
        Me.cboSubCuenta_Peso.TabIndex = 5
        '
        'cboTipoTarifa
        '
        Me.cboTipoTarifa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarifa.FormattingEnabled = True
        Me.cboTipoTarifa.Location = New System.Drawing.Point(83, 46)
        Me.cboTipoTarifa.Name = "cboTipoTarifa"
        Me.cboTipoTarifa.Size = New System.Drawing.Size(180, 21)
        Me.cboTipoTarifa.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(13, 51)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Tipo Tarifa :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(5, 78)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Sub Cuenta :"
        '
        'gbxMntTarifaNormal
        '
        Me.gbxMntTarifaNormal.Controls.Add(Me.txtVolumenMinimo)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label4)
        Me.gbxMntTarifaNormal.Controls.Add(Me.txtFleteMinimoVolumen)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label25)
        Me.gbxMntTarifaNormal.Controls.Add(Me.txtPesoMinimo)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label26)
        Me.gbxMntTarifaNormal.Controls.Add(Me.txtFleteMinimoPeso)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label27)
        Me.gbxMntTarifaNormal.Controls.Add(Me.TxtVolumen)
        Me.gbxMntTarifaNormal.Controls.Add(Me.TxtSobre)
        Me.gbxMntTarifaNormal.Controls.Add(Me.TxtPeso)
        Me.gbxMntTarifaNormal.Controls.Add(Me.TxtBase)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label12)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label13)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label14)
        Me.gbxMntTarifaNormal.Controls.Add(Me.Label11)
        Me.gbxMntTarifaNormal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gbxMntTarifaNormal.Location = New System.Drawing.Point(289, 3)
        Me.gbxMntTarifaNormal.Name = "gbxMntTarifaNormal"
        Me.gbxMntTarifaNormal.Size = New System.Drawing.Size(581, 276)
        Me.gbxMntTarifaNormal.TabIndex = 1
        Me.gbxMntTarifaNormal.TabStop = False
        '
        'txtVolumenMinimo
        '
        Me.txtVolumenMinimo.Location = New System.Drawing.Point(310, 74)
        Me.txtVolumenMinimo.Name = "txtVolumenMinimo"
        Me.txtVolumenMinimo.Size = New System.Drawing.Size(100, 20)
        Me.txtVolumenMinimo.TabIndex = 10
        Me.txtVolumenMinimo.Text = ".00"
        Me.txtVolumenMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(217, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Volumen mínimo :"
        '
        'txtFleteMinimoVolumen
        '
        Me.txtFleteMinimoVolumen.Location = New System.Drawing.Point(310, 103)
        Me.txtFleteMinimoVolumen.Name = "txtFleteMinimoVolumen"
        Me.txtFleteMinimoVolumen.Size = New System.Drawing.Size(100, 20)
        Me.txtFleteMinimoVolumen.TabIndex = 11
        Me.txtFleteMinimoVolumen.Text = ".00"
        Me.txtFleteMinimoVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(195, 105)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(113, 13)
        Me.Label25.TabIndex = 20
        Me.Label25.Text = "Flete mínimo volumen:"
        '
        'txtPesoMinimo
        '
        Me.txtPesoMinimo.Location = New System.Drawing.Point(310, 15)
        Me.txtPesoMinimo.Name = "txtPesoMinimo"
        Me.txtPesoMinimo.Size = New System.Drawing.Size(100, 20)
        Me.txtPesoMinimo.TabIndex = 8
        Me.txtPesoMinimo.Text = ".00"
        Me.txtPesoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(234, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(74, 13)
        Me.Label26.TabIndex = 18
        Me.Label26.Text = "Peso mínimo :"
        '
        'txtFleteMinimoPeso
        '
        Me.txtFleteMinimoPeso.Location = New System.Drawing.Point(310, 47)
        Me.txtFleteMinimoPeso.Name = "txtFleteMinimoPeso"
        Me.txtFleteMinimoPeso.Size = New System.Drawing.Size(100, 20)
        Me.txtFleteMinimoPeso.TabIndex = 9
        Me.txtFleteMinimoPeso.Text = ".00"
        Me.txtFleteMinimoPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(212, 50)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(96, 13)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "Flete mínimo peso:"
        '
        'TxtVolumen
        '
        Me.TxtVolumen.Location = New System.Drawing.Point(76, 47)
        Me.TxtVolumen.Name = "TxtVolumen"
        Me.TxtVolumen.Size = New System.Drawing.Size(100, 20)
        Me.TxtVolumen.TabIndex = 3
        Me.TxtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSobre
        '
        Me.TxtSobre.Location = New System.Drawing.Point(76, 74)
        Me.TxtSobre.Name = "TxtSobre"
        Me.TxtSobre.Size = New System.Drawing.Size(100, 20)
        Me.TxtSobre.TabIndex = 5
        Me.TxtSobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPeso
        '
        Me.TxtPeso.Location = New System.Drawing.Point(76, 15)
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(100, 20)
        Me.TxtPeso.TabIndex = 1
        Me.TxtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtBase
        '
        Me.TxtBase.Location = New System.Drawing.Point(76, 103)
        Me.TxtBase.Name = "TxtBase"
        Me.TxtBase.Size = New System.Drawing.Size(100, 20)
        Me.TxtBase.TabIndex = 7
        Me.TxtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(36, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Peso :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(34, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Sobre :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(21, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Volumen :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(38, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Base :"
        '
        'tpArticulo
        '
        Me.tpArticulo.Controls.Add(Me.GroupBox8)
        Me.tpArticulo.Controls.Add(Me.GbxMntTarifaArticulos)
        Me.tpArticulo.Location = New System.Drawing.Point(4, 22)
        Me.tpArticulo.Name = "tpArticulo"
        Me.tpArticulo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpArticulo.Size = New System.Drawing.Size(873, 285)
        Me.tpArticulo.TabIndex = 1
        Me.tpArticulo.Text = "Artículos"
        Me.tpArticulo.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.dtpFechaActivacion_Articulos)
        Me.GroupBox8.Controls.Add(Me.Label24)
        Me.GroupBox8.Controls.Add(Me.cboProducto_Articulos)
        Me.GroupBox8.Controls.Add(Me.Label23)
        Me.GroupBox8.Controls.Add(Me.cboSubCuenta_Articulos)
        Me.GroupBox8.Controls.Add(Me.lblSubCuenta)
        Me.GroupBox8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox8.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(274, 275)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        '
        'dtpFechaActivacion_Articulos
        '
        Me.dtpFechaActivacion_Articulos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaActivacion_Articulos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion_Articulos.Location = New System.Drawing.Point(82, 67)
        Me.dtpFechaActivacion_Articulos.Name = "dtpFechaActivacion_Articulos"
        Me.dtpFechaActivacion_Articulos.Size = New System.Drawing.Size(180, 20)
        Me.dtpFechaActivacion_Articulos.TabIndex = 5
        '
        'Label24
        '
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(3, 66)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 28)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Fecha Activacion :"
        '
        'cboProducto_Articulos
        '
        Me.cboProducto_Articulos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboProducto_Articulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto_Articulos.FormattingEnabled = True
        Me.cboProducto_Articulos.Location = New System.Drawing.Point(82, 13)
        Me.cboProducto_Articulos.Name = "cboProducto_Articulos"
        Me.cboProducto_Articulos.Size = New System.Drawing.Size(180, 21)
        Me.cboProducto_Articulos.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(3, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Producto :"
        '
        'cboSubCuenta_Articulos
        '
        Me.cboSubCuenta_Articulos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSubCuenta_Articulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubCuenta_Articulos.FormattingEnabled = True
        Me.cboSubCuenta_Articulos.Location = New System.Drawing.Point(82, 40)
        Me.cboSubCuenta_Articulos.Name = "cboSubCuenta_Articulos"
        Me.cboSubCuenta_Articulos.Size = New System.Drawing.Size(180, 21)
        Me.cboSubCuenta_Articulos.TabIndex = 3
        '
        'lblSubCuenta
        '
        Me.lblSubCuenta.AutoSize = True
        Me.lblSubCuenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSubCuenta.Location = New System.Drawing.Point(3, 44)
        Me.lblSubCuenta.Name = "lblSubCuenta"
        Me.lblSubCuenta.Size = New System.Drawing.Size(69, 13)
        Me.lblSubCuenta.TabIndex = 2
        Me.lblSubCuenta.Text = "Sub Cuenta :"
        '
        'GbxMntTarifaArticulos
        '
        Me.GbxMntTarifaArticulos.Controls.Add(Me.DgvMntTarifaArticulos)
        Me.GbxMntTarifaArticulos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GbxMntTarifaArticulos.Location = New System.Drawing.Point(281, 4)
        Me.GbxMntTarifaArticulos.Name = "GbxMntTarifaArticulos"
        Me.GbxMntTarifaArticulos.Size = New System.Drawing.Size(589, 275)
        Me.GbxMntTarifaArticulos.TabIndex = 1
        Me.GbxMntTarifaArticulos.TabStop = False
        '
        'DgvMntTarifaArticulos
        '
        Me.DgvMntTarifaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMntTarifaArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMntTarifaArticulos.Location = New System.Drawing.Point(3, 16)
        Me.DgvMntTarifaArticulos.Name = "DgvMntTarifaArticulos"
        Me.DgvMntTarifaArticulos.Size = New System.Drawing.Size(583, 256)
        Me.DgvMntTarifaArticulos.TabIndex = 0
        '
        'FrmTarifarioPerso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 478)
        Me.Controls.Add(Me.tcTarifas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmTarifarioPerso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TARIFARIO PERSONALIZADO POR CLIENTE"
        Me.tcTarifas.ResumeLayout(False)
        Me.TabListar.ResumeLayout(False)
        Me.TabListar.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabCliente.ResumeLayout(False)
        Me.TabCliente.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.tcListaTarifas.ResumeLayout(False)
        Me.tpListTarifasPeso.ResumeLayout(False)
        Me.tpListTarifasPeso.PerformLayout()
        CType(Me.DgvListTarifasPeso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTarifasArticulos.ResumeLayout(False)
        Me.tpTarifasArticulos.PerformLayout()
        CType(Me.DgvListTarifasArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabTarifa.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.tcTipo.ResumeLayout(False)
        Me.tpNormal.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.gbxMntTarifaNormal.ResumeLayout(False)
        Me.gbxMntTarifaNormal.PerformLayout()
        Me.tpArticulo.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GbxMntTarifaArticulos.ResumeLayout(False)
        CType(Me.DgvMntTarifaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcTarifas As System.Windows.Forms.TabControl
    Friend WithEvents TabCliente As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCantRegXPeso As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarTarifas As System.Windows.Forms.Button
    Friend WithEvents cboDestino_Cliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboOrigen_Cliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabListar As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCliente_Buscar As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabTarifa As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gbxMntTarifaNormal As System.Windows.Forms.GroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents TxtSobre As System.Windows.Forms.TextBox
    Friend WithEvents TxtPeso As System.Windows.Forms.TextBox
    Friend WithEvents TxtBase As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cboOrigen_Mnt As System.Windows.Forms.ComboBox
    Friend WithEvents cboDestino_Mnt As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCliente_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaActivacion_Peso As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboProducto_peso As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboTipoTarifa As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSubCuenta_Articulos As System.Windows.Forms.ComboBox
    Friend WithEvents lblSubCuenta As System.Windows.Forms.Label
    Friend WithEvents DgvClientes As System.Windows.Forms.DataGridView
    Friend WithEvents DgvListTarifasPeso As System.Windows.Forms.DataGridView
    Friend WithEvents cboSubCuenta_Cliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents GbxMntTarifaArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents DgvMntTarifaArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents tcTipo As System.Windows.Forms.TabControl
    Friend WithEvents tpNormal As System.Windows.Forms.TabPage
    Friend WithEvents tpArticulo As System.Windows.Forms.TabPage
    Friend WithEvents tcListaTarifas As System.Windows.Forms.TabControl
    Friend WithEvents tpListTarifasPeso As System.Windows.Forms.TabPage
    Friend WithEvents tpTarifasArticulos As System.Windows.Forms.TabPage
    Friend WithEvents DgvListTarifasArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents lblCantRegXArticulos As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSubCuenta_Peso As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboProducto_Articulos As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaActivacion_Articulos As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ckbTarifaArticulos As System.Windows.Forms.CheckBox
    Friend WithEvents ckbTarifaNormal As System.Windows.Forms.CheckBox
    Friend WithEvents rbRazonSocial As System.Windows.Forms.RadioButton
    Friend WithEvents rbRuc As System.Windows.Forms.RadioButton
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtVolumenMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFleteMinimoVolumen As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPesoMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtFleteMinimoPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
