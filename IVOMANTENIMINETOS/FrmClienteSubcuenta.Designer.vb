<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClienteSubcuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClienteSubcuenta))
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tpSubCuentasAsociadas = New System.Windows.Forms.TabPage()
        Me.dgvSubcuentas = New System.Windows.Forms.DataGridView()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCliente_Busq = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbCiudadCobertura_Busq = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabSubcuenta = New System.Windows.Forms.TabControl()
        Me.tpMantenimiento = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoSap = New System.Windows.Forms.TextBox()
        Me.lblCodigoSap = New System.Windows.Forms.Label()
        Me.cmbCiudadCobertura = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSubCuenta = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tpActualizar = New System.Windows.Forms.TabPage()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscar2 = New System.Windows.Forms.Button()
        Me.cmbSubcuenta = New System.Windows.Forms.ComboBox()
        Me.dgvVenta = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuContextSelTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuContextSelEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpSubCuentasAsociadas.SuspendLayout()
        CType(Me.dgvSubcuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSubcuenta.SuspendLayout()
        Me.tpMantenimiento.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tpActualizar.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.BackColor = System.Drawing.Color.WhiteSmoke
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.Location = New System.Drawing.Point(324, 3)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(757, 25)
        Me.miniToolStrip.TabIndex = 36
        '
        'tpSubCuentasAsociadas
        '
        Me.tpSubCuentasAsociadas.Controls.Add(Me.dgvSubcuentas)
        Me.tpSubCuentasAsociadas.Controls.Add(Me.toolStrip1)
        Me.tpSubCuentasAsociadas.Controls.Add(Me.GroupBox1)
        Me.tpSubCuentasAsociadas.Location = New System.Drawing.Point(4, 22)
        Me.tpSubCuentasAsociadas.Name = "tpSubCuentasAsociadas"
        Me.tpSubCuentasAsociadas.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSubCuentasAsociadas.Size = New System.Drawing.Size(845, 466)
        Me.tpSubCuentasAsociadas.TabIndex = 1
        Me.tpSubCuentasAsociadas.Text = "Lista"
        Me.tpSubCuentasAsociadas.UseVisualStyleBackColor = True
        '
        'dgvSubcuentas
        '
        Me.dgvSubcuentas.AllowUserToAddRows = False
        Me.dgvSubcuentas.AllowUserToDeleteRows = False
        Me.dgvSubcuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSubcuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubcuentas.Location = New System.Drawing.Point(6, 92)
        Me.dgvSubcuentas.Name = "dgvSubcuentas"
        Me.dgvSubcuentas.Size = New System.Drawing.Size(835, 368)
        Me.dgvSubcuentas.TabIndex = 37
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.toolStripSeparator2, Me.EditarToolStripMenuItem, Me.AnularToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.toolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(254, 25)
        Me.toolStrip1.TabIndex = 36
        Me.toolStrip1.Text = "toolStrip1"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.ForeColor = System.Drawing.Color.Black
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
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Enabled = False
        Me.EditarToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.EditarToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.EditarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(57, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Enabled = False
        Me.AnularToolStripMenuItem.ForeColor = System.Drawing.Color.Black
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
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.SalirToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources._1323
        Me.SalirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(49, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbCliente_Busq)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.cmbCiudadCobertura_Busq)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(834, 62)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'cmbCliente_Busq
        '
        Me.cmbCliente_Busq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCliente_Busq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente_Busq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente_Busq.FormattingEnabled = True
        Me.cmbCliente_Busq.Location = New System.Drawing.Point(65, 11)
        Me.cmbCliente_Busq.Name = "cmbCliente_Busq"
        Me.cmbCliente_Busq.Size = New System.Drawing.Size(339, 21)
        Me.cmbCliente_Busq.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cliente:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(445, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "Buscar   "
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbCiudadCobertura_Busq
        '
        Me.cmbCiudadCobertura_Busq.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCiudadCobertura_Busq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudadCobertura_Busq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudadCobertura_Busq.FormattingEnabled = True
        Me.cmbCiudadCobertura_Busq.Location = New System.Drawing.Point(65, 35)
        Me.cmbCiudadCobertura_Busq.Name = "cmbCiudadCobertura_Busq"
        Me.cmbCiudadCobertura_Busq.Size = New System.Drawing.Size(196, 21)
        Me.cmbCiudadCobertura_Busq.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ciudad"
        '
        'tabSubcuenta
        '
        Me.tabSubcuenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabSubcuenta.Controls.Add(Me.tpSubCuentasAsociadas)
        Me.tabSubcuenta.Controls.Add(Me.tpMantenimiento)
        Me.tabSubcuenta.Controls.Add(Me.tpActualizar)
        Me.tabSubcuenta.Location = New System.Drawing.Point(2, 3)
        Me.tabSubcuenta.Name = "tabSubcuenta"
        Me.tabSubcuenta.SelectedIndex = 0
        Me.tabSubcuenta.Size = New System.Drawing.Size(853, 492)
        Me.tabSubcuenta.TabIndex = 3
        '
        'tpMantenimiento
        '
        Me.tpMantenimiento.Controls.Add(Me.btnCancelar)
        Me.tpMantenimiento.Controls.Add(Me.btnGuardar)
        Me.tpMantenimiento.Controls.Add(Me.GroupBox2)
        Me.tpMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.tpMantenimiento.Name = "tpMantenimiento"
        Me.tpMantenimiento.Size = New System.Drawing.Size(845, 466)
        Me.tpMantenimiento.TabIndex = 2
        Me.tpMantenimiento.Text = "Mantenimiento"
        Me.tpMantenimiento.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Image = Global.INTEGRACION.My.Resources.Resources.IzquierdaTodos
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(486, 385)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 33)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = Global.INTEGRACION.My.Resources.Resources.mp_toolbarGuardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(281, 385)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 33)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtCodigoSap)
        Me.GroupBox2.Controls.Add(Me.lblCodigoSap)
        Me.GroupBox2.Controls.Add(Me.cmbCiudadCobertura)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmbCliente)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtSubCuenta)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(833, 349)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mantenimiento de la SubCuenta"
        '
        'txtCodigoSap
        '
        Me.txtCodigoSap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSap.Enabled = False
        Me.txtCodigoSap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoSap.Location = New System.Drawing.Point(344, 142)
        Me.txtCodigoSap.MaxLength = 10
        Me.txtCodigoSap.Name = "txtCodigoSap"
        Me.txtCodigoSap.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoSap.TabIndex = 4
        Me.txtCodigoSap.Visible = False
        '
        'lblCodigoSap
        '
        Me.lblCodigoSap.AutoSize = True
        Me.lblCodigoSap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoSap.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodigoSap.Location = New System.Drawing.Point(264, 145)
        Me.lblCodigoSap.Name = "lblCodigoSap"
        Me.lblCodigoSap.Size = New System.Drawing.Size(64, 13)
        Me.lblCodigoSap.TabIndex = 8
        Me.lblCodigoSap.Text = "Código SAP"
        Me.lblCodigoSap.Visible = False
        '
        'cmbCiudadCobertura
        '
        Me.cmbCiudadCobertura.DropDownHeight = 200
        Me.cmbCiudadCobertura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudadCobertura.Enabled = False
        Me.cmbCiudadCobertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudadCobertura.FormattingEnabled = True
        Me.cmbCiudadCobertura.IntegralHeight = False
        Me.cmbCiudadCobertura.Location = New System.Drawing.Point(94, 142)
        Me.cmbCiudadCobertura.Name = "cmbCiudadCobertura"
        Me.cmbCiudadCobertura.Size = New System.Drawing.Size(148, 21)
        Me.cmbCiudadCobertura.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(40, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Ciudad"
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.Enabled = False
        Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(94, 69)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(333, 21)
        Me.cmbCliente.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(41, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Cliente"
        '
        'txtSubCuenta
        '
        Me.txtSubCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSubCuenta.Enabled = False
        Me.txtSubCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubCuenta.Location = New System.Drawing.Point(94, 105)
        Me.txtSubCuenta.MaxLength = 40
        Me.txtSubCuenta.Name = "txtSubCuenta"
        Me.txtSubCuenta.Size = New System.Drawing.Size(333, 20)
        Me.txtSubCuenta.TabIndex = 2
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(94, 34)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(89, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(40, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(20, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Subcuenta"
        '
        'tpActualizar
        '
        Me.tpActualizar.Controls.Add(Me.btnActualizar)
        Me.tpActualizar.Controls.Add(Me.Label2)
        Me.tpActualizar.Controls.Add(Me.GroupBox3)
        Me.tpActualizar.Controls.Add(Me.dgvVenta)
        Me.tpActualizar.Location = New System.Drawing.Point(4, 22)
        Me.tpActualizar.Name = "tpActualizar"
        Me.tpActualizar.Padding = New System.Windows.Forms.Padding(3)
        Me.tpActualizar.Size = New System.Drawing.Size(845, 466)
        Me.tpActualizar.TabIndex = 3
        Me.tpActualizar.Text = "Actualizar Subcuenta"
        Me.tpActualizar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.SystemColors.Control
        Me.btnActualizar.Enabled = False
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.ForeColor = System.Drawing.Color.Black
        Me.btnActualizar.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizar.Location = New System.Drawing.Point(729, 80)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.btnActualizar.TabIndex = 15
        Me.btnActualizar.Text = "&Actualizar Subcuenta"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(13, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Guías de Envío no Facturadas"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cmbCiudad)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.btnBuscar2)
        Me.GroupBox3.Controls.Add(Me.cmbSubcuenta)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(809, 66)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtro Subcuenta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(318, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Subcuenta"
        '
        'cmbCiudad
        '
        Me.cmbCiudad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(52, 28)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(231, 21)
        Me.cmbCiudad.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Ciudad"
        '
        'btnBuscar2
        '
        Me.btnBuscar2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar2.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnBuscar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar2.Location = New System.Drawing.Point(725, 24)
        Me.btnBuscar2.Name = "btnBuscar2"
        Me.btnBuscar2.Size = New System.Drawing.Size(78, 27)
        Me.btnBuscar2.TabIndex = 9
        Me.btnBuscar2.Text = "Buscar   "
        Me.btnBuscar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar2.UseVisualStyleBackColor = True
        '
        'cmbSubcuenta
        '
        Me.cmbSubcuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSubcuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSubcuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubcuenta.FormattingEnabled = True
        Me.cmbSubcuenta.Location = New System.Drawing.Point(383, 28)
        Me.cmbSubcuenta.Name = "cmbSubcuenta"
        Me.cmbSubcuenta.Size = New System.Drawing.Size(267, 21)
        Me.cmbSubcuenta.TabIndex = 4
        '
        'dgvVenta
        '
        Me.dgvVenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgvVenta.Location = New System.Drawing.Point(16, 123)
        Me.dgvVenta.Name = "dgvVenta"
        Me.dgvVenta.Size = New System.Drawing.Size(809, 324)
        Me.dgvVenta.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuContextSelTodo, Me.MnuContextSelEliminar})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(171, 48)
        '
        'MnuContextSelTodo
        '
        Me.MnuContextSelTodo.Name = "MnuContextSelTodo"
        Me.MnuContextSelTodo.Size = New System.Drawing.Size(170, 22)
        Me.MnuContextSelTodo.Text = "Seleccionar Todo"
        '
        'MnuContextSelEliminar
        '
        Me.MnuContextSelEliminar.Name = "MnuContextSelEliminar"
        Me.MnuContextSelEliminar.Size = New System.Drawing.Size(170, 22)
        Me.MnuContextSelEliminar.Text = "Eliminar Selección"
        '
        'FrmClienteSubcuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 501)
        Me.Controls.Add(Me.tabSubcuenta)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmClienteSubcuenta"
        Me.Text = "Asociar Subcuenta a Cliente"
        Me.tpSubCuentasAsociadas.ResumeLayout(False)
        Me.tpSubCuentasAsociadas.PerformLayout()
        CType(Me.dgvSubcuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSubcuenta.ResumeLayout(False)
        Me.tpMantenimiento.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpActualizar.ResumeLayout(False)
        Me.tpActualizar.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents miniToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tpSubCuentasAsociadas As System.Windows.Forms.TabPage
    Friend WithEvents dgvSubcuentas As System.Windows.Forms.DataGridView
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbCiudadCobertura_Busq As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabSubcuenta As System.Windows.Forms.TabControl
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbCliente_Busq As System.Windows.Forms.ComboBox
    Friend WithEvents tpMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCiudadCobertura As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoSap As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoSap As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents tpActualizar As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSubcuenta As System.Windows.Forms.ComboBox
    Friend WithEvents dgvVenta As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar2 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuContextSelTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuContextSelEliminar As System.Windows.Forms.ToolStripMenuItem
End Class
