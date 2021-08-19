<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTarifarioCliente
    Inherits INTEGRACION.FrmPlantilla

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarifarioCliente))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnCargarClientes = New System.Windows.Forms.Button()
        Me.cmbFiltroGrilla = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdbTodos = New System.Windows.Forms.RadioButton()
        Me.rdbnaturales = New System.Windows.Forms.RadioButton()
        Me.rdbJuridicos = New System.Windows.Forms.RadioButton()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.DataGridLista = New System.Windows.Forms.DataGridView()
        Me.rdbAmbos = New System.Windows.Forms.RadioButton()
        Me.rdbCondicionales = New System.Windows.Forms.RadioButton()
        Me.rdbArticulos = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ContenedorGrillas = New System.Windows.Forms.SplitContainer()
        Me.dgvArticulo = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvCondicional = New System.Windows.Forms.DataGridView()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gruCarga = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_cg_sobre = New System.Windows.Forms.TextBox()
        Me.txtPrecioSobreCargaFinal = New System.Windows.Forms.TextBox()
        Me.txtMontoBaseCarga = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtMontoBaseCargaFinal = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtPrecioPesoCargaFinal = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtPrecioPesoCarga = New System.Windows.Forms.TextBox()
        Me.txtPrecioVolumenCarga = New System.Windows.Forms.TextBox()
        Me.txtPrecioVolumenCargaFinal = New System.Windows.Forms.TextBox()
        Me.gruPostales = New System.Windows.Forms.GroupBox()
        Me.txtPrecioPostalVolumenFinal = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalVolumen = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalPesoFinal = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalPeso = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrecioPostalFinal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrecioPostalBase = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.chkCondicional = New System.Windows.Forms.CheckBox()
        Me.rdbPostales = New System.Windows.Forms.RadioButton()
        Me.ChkVigente = New System.Windows.Forms.CheckBox()
        Me.rdbGiros = New System.Windows.Forms.RadioButton()
        Me.TxtFecIni = New ControlsTepsa.DataPickerMasked()
        Me.rdbEncomiendas = New System.Windows.Forms.RadioButton()
        Me.rdbCarga = New System.Windows.Forms.RadioButton()
        Me.TxtFecFin = New ControlsTepsa.DataPickerMasked()
        Me.gruTiempo = New System.Windows.Forms.GroupBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_porcentaje_descuento = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblCodigoCliente = New System.Windows.Forms.Label()
        Me.txtFuncionarioActual = New System.Windows.Forms.TextBox()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.txtCodigoCLiente = New System.Windows.Forms.TextBox()
        Me.gruGiros = New System.Windows.Forms.GroupBox()
        Me.txtMontoBaseGiro = New System.Windows.Forms.TextBox()
        Me.txtPorctTelefono = New System.Windows.Forms.TextBox()
        Me.txtPorctTelefonoFinal = New System.Windows.Forms.TextBox()
        Me.txtPorctNormal = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtPorctNormalFinal = New System.Windows.Forms.TextBox()
        Me.txtMontoBaseGiroFinal = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.gruEncomienda = New System.Windows.Forms.GroupBox()
        Me.txtPrecioVolumenEncomienda = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtMontoBaseEncomienda = New System.Windows.Forms.TextBox()
        Me.txtMontoBaseEncomiendaFinal = New System.Windows.Forms.TextBox()
        Me.txtPrecioPesoEncomiendaFinal = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtPrecioPesoEncomienda = New System.Windows.Forms.TextBox()
        Me.txtPrecioVolumenEncomiendaFinal = New System.Windows.Forms.TextBox()
        Me.gruCalculos = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtMontoFinalCal = New System.Windows.Forms.TextBox()
        Me.txtDecuentoCal = New System.Windows.Forms.TextBox()
        Me.MyImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelTarifaCliente = New System.Windows.Forms.Panel()
        Me.dgvTarifasCliente = New System.Windows.Forms.DataGridView()
        Me.btncargaTarifa = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbSubCuenta = New System.Windows.Forms.ComboBox()
        Me.btn_tarifa_masiva = New System.Windows.Forms.Button()
        Me.txt_codigo_cliente_1 = New System.Windows.Forms.Label()
        Me.txt_codigo_cliente1 = New System.Windows.Forms.TextBox()
        Me.txt_razon_social1 = New System.Windows.Forms.TextBox()
        Me.txt_funcionario1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_descuento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ContenedorGrillas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContenedorGrillas.Panel1.SuspendLayout()
        Me.ContenedorGrillas.Panel2.SuspendLayout()
        Me.ContenedorGrillas.SuspendLayout()
        CType(Me.dgvArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCondicional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gruCarga.SuspendLayout()
        Me.gruPostales.SuspendLayout()
        Me.gruTiempo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gruGiros.SuspendLayout()
        Me.gruEncomienda.SuspendLayout()
        Me.gruCalculos.SuspendLayout()
        Me.PanelTarifaCliente.SuspendLayout()
        CType(Me.dgvTarifasCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(788, 648)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(788, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(788, 556)
        Me.SplitContainer2.SplitterDistance = 201
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(563, 520)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(763, 493)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.txtBusqueda)
        Me.TabLista.Controls.Add(Me.btnCargarClientes)
        Me.TabLista.Controls.Add(Me.cmbFiltroGrilla)
        Me.TabLista.Controls.Add(Me.Label5)
        Me.TabLista.Controls.Add(Me.rdbTodos)
        Me.TabLista.Controls.Add(Me.rdbnaturales)
        Me.TabLista.Controls.Add(Me.rdbJuridicos)
        Me.TabLista.Size = New System.Drawing.Size(755, 464)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rdbJuridicos, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rdbnaturales, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rdbTodos, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbFiltroGrilla, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnCargarClientes, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtBusqueda, 0)
        '
        'TabDatos
        '
        Me.TabDatos.BackColor = System.Drawing.Color.Transparent
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.txt_descuento)
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.Label6)
        Me.TabDatos.Controls.Add(Me.txt_razon_social1)
        Me.TabDatos.Controls.Add(Me.txt_codigo_cliente1)
        Me.TabDatos.Controls.Add(Me.txt_funcionario1)
        Me.TabDatos.Controls.Add(Me.txt_codigo_cliente_1)
        Me.TabDatos.Controls.Add(Me.btn_tarifa_masiva)
        Me.TabDatos.Controls.Add(Me.PanelTarifaCliente)
        Me.TabDatos.Size = New System.Drawing.Size(755, 464)
        Me.TabDatos.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gruCalculos)
        Me.TabPage1.Controls.Add(Me.btncargaTarifa)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.chkCondicional)
        Me.TabPage1.Controls.Add(Me.rdbPostales)
        Me.TabPage1.Controls.Add(Me.ChkVigente)
        Me.TabPage1.Controls.Add(Me.rdbGiros)
        Me.TabPage1.Controls.Add(Me.TxtFecIni)
        Me.TabPage1.Controls.Add(Me.rdbEncomiendas)
        Me.TabPage1.Controls.Add(Me.rdbCarga)
        Me.TabPage1.Controls.Add(Me.TxtFecFin)
        Me.TabPage1.Controls.Add(Me.gruTiempo)
        Me.TabPage1.Controls.Add(Me.txtID)
        Me.TabPage1.Controls.Add(Me.Label38)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.cmbDestino)
        Me.TabPage1.Controls.Add(Me.cmbOrigen)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.gruCarga)
        Me.TabPage1.Controls.Add(Me.gruGiros)
        Me.TabPage1.Controls.Add(Me.gruEncomienda)
        Me.TabPage1.Size = New System.Drawing.Size(755, 464)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(755, 464)
        '
        'TabPage3
        '
        Me.TabPage3.Size = New System.Drawing.Size(755, 464)
        '
        'TabPage4
        '
        Me.TabPage4.Size = New System.Drawing.Size(755, 464)
        '
        'MyTreeView
        '
        Me.MyTreeView.ImageIndex = 0
        Me.MyTreeView.ImageList = Me.MyImageList
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Location = New System.Drawing.Point(7, 8)
        Me.MyTreeView.SelectedImageIndex = 1
        Me.MyTreeView.Size = New System.Drawing.Size(183, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.DataGridLista)
        Me.Panel.Size = New System.Drawing.Size(933, 369)
        '
        'btnCargarClientes
        '
        Me.btnCargarClientes.BackColor = System.Drawing.Color.Transparent
        Me.btnCargarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargarClientes.Image = CType(resources.GetObject("btnCargarClientes.Image"), System.Drawing.Image)
        Me.btnCargarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargarClientes.Location = New System.Drawing.Point(17, 12)
        Me.btnCargarClientes.Name = "btnCargarClientes"
        Me.btnCargarClientes.Size = New System.Drawing.Size(80, 28)
        Me.btnCargarClientes.TabIndex = 41
        Me.btnCargarClientes.Text = "&Cargar"
        Me.btnCargarClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargarClientes.UseVisualStyleBackColor = False
        '
        'cmbFiltroGrilla
        '
        Me.cmbFiltroGrilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFiltroGrilla.FormattingEnabled = True
        Me.cmbFiltroGrilla.Location = New System.Drawing.Point(85, 50)
        Me.cmbFiltroGrilla.Name = "cmbFiltroGrilla"
        Me.cmbFiltroGrilla.Size = New System.Drawing.Size(122, 21)
        Me.cmbFiltroGrilla.TabIndex = 40
        Me.cmbFiltroGrilla.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(14, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Buscar Por :"
        '
        'rdbTodos
        '
        Me.rdbTodos.AutoSize = True
        Me.rdbTodos.BackColor = System.Drawing.Color.Transparent
        Me.rdbTodos.Enabled = False
        Me.rdbTodos.Location = New System.Drawing.Point(324, 12)
        Me.rdbTodos.Name = "rdbTodos"
        Me.rdbTodos.Size = New System.Drawing.Size(57, 17)
        Me.rdbTodos.TabIndex = 38
        Me.rdbTodos.TabStop = True
        Me.rdbTodos.Text = "Ambas"
        Me.rdbTodos.UseVisualStyleBackColor = False
        Me.rdbTodos.Visible = False
        '
        'rdbnaturales
        '
        Me.rdbnaturales.AutoSize = True
        Me.rdbnaturales.BackColor = System.Drawing.Color.Transparent
        Me.rdbnaturales.Enabled = False
        Me.rdbnaturales.Location = New System.Drawing.Point(229, 12)
        Me.rdbnaturales.Name = "rdbnaturales"
        Me.rdbnaturales.Size = New System.Drawing.Size(70, 17)
        Me.rdbnaturales.TabIndex = 36
        Me.rdbnaturales.TabStop = True
        Me.rdbnaturales.Text = "Naturales"
        Me.rdbnaturales.UseVisualStyleBackColor = False
        Me.rdbnaturales.Visible = False
        '
        'rdbJuridicos
        '
        Me.rdbJuridicos.AutoSize = True
        Me.rdbJuridicos.BackColor = System.Drawing.Color.Transparent
        Me.rdbJuridicos.Location = New System.Drawing.Point(133, 12)
        Me.rdbJuridicos.Name = "rdbJuridicos"
        Me.rdbJuridicos.Size = New System.Drawing.Size(66, 17)
        Me.rdbJuridicos.TabIndex = 37
        Me.rdbJuridicos.TabStop = True
        Me.rdbJuridicos.Text = "Juridicos"
        Me.rdbJuridicos.UseVisualStyleBackColor = False
        '
        'txtBusqueda
        '
        Me.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusqueda.Location = New System.Drawing.Point(85, 50)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(433, 20)
        Me.txtBusqueda.TabIndex = 35
        '
        'DataGridLista
        '
        Me.DataGridLista.BackgroundColor = System.Drawing.Color.White
        Me.DataGridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridLista.Location = New System.Drawing.Point(-1, 0)
        Me.DataGridLista.Name = "DataGridLista"
        Me.DataGridLista.Size = New System.Drawing.Size(713, 369)
        Me.DataGridLista.TabIndex = 1
        '
        'rdbAmbos
        '
        Me.rdbAmbos.AutoSize = True
        Me.rdbAmbos.BackColor = System.Drawing.Color.Transparent
        Me.rdbAmbos.Location = New System.Drawing.Point(287, 14)
        Me.rdbAmbos.Name = "rdbAmbos"
        Me.rdbAmbos.Size = New System.Drawing.Size(126, 17)
        Me.rdbAmbos.TabIndex = 3
        Me.rdbAmbos.TabStop = True
        Me.rdbAmbos.Text = "Mostrar Ambas Grillas"
        Me.rdbAmbos.UseVisualStyleBackColor = False
        '
        'rdbCondicionales
        '
        Me.rdbCondicionales.AutoSize = True
        Me.rdbCondicionales.BackColor = System.Drawing.Color.Transparent
        Me.rdbCondicionales.Location = New System.Drawing.Point(134, 14)
        Me.rdbCondicionales.Name = "rdbCondicionales"
        Me.rdbCondicionales.Size = New System.Drawing.Size(153, 17)
        Me.rdbCondicionales.TabIndex = 2
        Me.rdbCondicionales.TabStop = True
        Me.rdbCondicionales.Text = "Mostrar Solo Condicionales"
        Me.rdbCondicionales.UseVisualStyleBackColor = False
        '
        'rdbArticulos
        '
        Me.rdbArticulos.AutoSize = True
        Me.rdbArticulos.BackColor = System.Drawing.Color.Transparent
        Me.rdbArticulos.Location = New System.Drawing.Point(6, 14)
        Me.rdbArticulos.Name = "rdbArticulos"
        Me.rdbArticulos.Size = New System.Drawing.Size(127, 17)
        Me.rdbArticulos.TabIndex = 1
        Me.rdbArticulos.TabStop = True
        Me.rdbArticulos.Text = "Mostrar Solo Articulos"
        Me.rdbArticulos.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.ContenedorGrillas)
        Me.Panel2.Location = New System.Drawing.Point(18, 286)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(699, 167)
        Me.Panel2.TabIndex = 195
        '
        'ContenedorGrillas
        '
        Me.ContenedorGrillas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContenedorGrillas.Location = New System.Drawing.Point(0, 0)
        Me.ContenedorGrillas.Name = "ContenedorGrillas"
        '
        'ContenedorGrillas.Panel1
        '
        Me.ContenedorGrillas.Panel1.Controls.Add(Me.dgvArticulo)
        '
        'ContenedorGrillas.Panel2
        '
        Me.ContenedorGrillas.Panel2.Controls.Add(Me.dgvCondicional)
        Me.ContenedorGrillas.Size = New System.Drawing.Size(699, 167)
        Me.ContenedorGrillas.SplitterDistance = 336
        Me.ContenedorGrillas.TabIndex = 0
        '
        'dgvArticulo
        '
        Me.dgvArticulo.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArticulo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.Column1, Me.Column2})
        Me.dgvArticulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvArticulo.Location = New System.Drawing.Point(0, 0)
        Me.dgvArticulo.Name = "dgvArticulo"
        Me.dgvArticulo.RowHeadersVisible = False
        Me.dgvArticulo.Size = New System.Drawing.Size(336, 167)
        Me.dgvArticulo.TabIndex = 161
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn8.Frozen = True
        Me.DataGridViewTextBoxColumn8.HeaderText = "ARTICULO"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.HeaderText = "PRECIO BASE"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "% DESC."
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "PRECIO FINAL"
        Me.Column2.Name = "Column2"
        '
        'dgvCondicional
        '
        Me.dgvCondicional.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCondicional.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCondicional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCondicional.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn10})
        Me.dgvCondicional.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCondicional.Location = New System.Drawing.Point(0, 0)
        Me.dgvCondicional.Name = "dgvCondicional"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCondicional.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCondicional.RowHeadersVisible = False
        Me.dgvCondicional.Size = New System.Drawing.Size(359, 167)
        Me.dgvCondicional.TabIndex = 160
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn1.Frozen = True
        Me.DataGridViewComboBoxColumn1.HeaderText = "UNIDAD"
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"PESO", "VOLUMEN", "CANTIDAD"})
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "INICIO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "FIN"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.HeaderText = "% DESC."
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.HeaderText = "PRECIO FINAL"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'gruCarga
        '
        Me.gruCarga.BackColor = System.Drawing.Color.Transparent
        Me.gruCarga.Controls.Add(Me.Label10)
        Me.gruCarga.Controls.Add(Me.txt_cg_sobre)
        Me.gruCarga.Controls.Add(Me.txtPrecioSobreCargaFinal)
        Me.gruCarga.Controls.Add(Me.txtMontoBaseCarga)
        Me.gruCarga.Controls.Add(Me.Label37)
        Me.gruCarga.Controls.Add(Me.txtMontoBaseCargaFinal)
        Me.gruCarga.Controls.Add(Me.Label36)
        Me.gruCarga.Controls.Add(Me.txtPrecioPesoCargaFinal)
        Me.gruCarga.Controls.Add(Me.Label34)
        Me.gruCarga.Controls.Add(Me.txtPrecioPesoCarga)
        Me.gruCarga.Controls.Add(Me.txtPrecioVolumenCarga)
        Me.gruCarga.Controls.Add(Me.txtPrecioVolumenCargaFinal)
        Me.gruCarga.Controls.Add(Me.gruPostales)
        Me.gruCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gruCarga.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gruCarga.Location = New System.Drawing.Point(70, 144)
        Me.gruCarga.Name = "gruCarga"
        Me.gruCarga.Size = New System.Drawing.Size(271, 101)
        Me.gruCarga.TabIndex = 185
        Me.gruCarga.TabStop = False
        Me.gruCarga.Text = "Tarifa Carga"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(31, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 187
        Me.Label10.Text = "Precio x Sobre : "
        '
        'txt_cg_sobre
        '
        Me.txt_cg_sobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cg_sobre.Location = New System.Drawing.Point(122, 80)
        Me.txt_cg_sobre.Name = "txt_cg_sobre"
        Me.txt_cg_sobre.Size = New System.Drawing.Size(61, 20)
        Me.txt_cg_sobre.TabIndex = 185
        Me.txt_cg_sobre.TabStop = False
        Me.txt_cg_sobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioSobreCargaFinal
        '
        Me.txtPrecioSobreCargaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioSobreCargaFinal.Location = New System.Drawing.Point(189, 80)
        Me.txtPrecioSobreCargaFinal.Name = "txtPrecioSobreCargaFinal"
        Me.txtPrecioSobreCargaFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioSobreCargaFinal.TabIndex = 186
        Me.txtPrecioSobreCargaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoBaseCarga
        '
        Me.txtMontoBaseCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoBaseCarga.Location = New System.Drawing.Point(122, 11)
        Me.txtMontoBaseCarga.Name = "txtMontoBaseCarga"
        Me.txtMontoBaseCarga.Size = New System.Drawing.Size(61, 20)
        Me.txtMontoBaseCarga.TabIndex = 0
        Me.txtMontoBaseCarga.TabStop = False
        Me.txtMontoBaseCarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Location = New System.Drawing.Point(38, 38)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(78, 13)
        Me.Label37.TabIndex = 143
        Me.Label37.Text = "Precio x Peso :"
        '
        'txtMontoBaseCargaFinal
        '
        Me.txtMontoBaseCargaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoBaseCargaFinal.Location = New System.Drawing.Point(189, 11)
        Me.txtMontoBaseCargaFinal.Name = "txtMontoBaseCargaFinal"
        Me.txtMontoBaseCargaFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtMontoBaseCargaFinal.TabIndex = 1
        Me.txtMontoBaseCargaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Location = New System.Drawing.Point(21, 62)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(95, 13)
        Me.Label36.TabIndex = 144
        Me.Label36.Text = "Precio x Volumen :"
        '
        'txtPrecioPesoCargaFinal
        '
        Me.txtPrecioPesoCargaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPesoCargaFinal.Location = New System.Drawing.Point(189, 34)
        Me.txtPrecioPesoCargaFinal.Name = "txtPrecioPesoCargaFinal"
        Me.txtPrecioPesoCargaFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPesoCargaFinal.TabIndex = 2
        Me.txtPrecioPesoCargaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Location = New System.Drawing.Point(46, 15)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(70, 13)
        Me.Label34.TabIndex = 142
        Me.Label34.Text = "Monto Base :"
        '
        'txtPrecioPesoCarga
        '
        Me.txtPrecioPesoCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPesoCarga.Location = New System.Drawing.Point(122, 34)
        Me.txtPrecioPesoCarga.Name = "txtPrecioPesoCarga"
        Me.txtPrecioPesoCarga.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPesoCarga.TabIndex = 0
        Me.txtPrecioPesoCarga.TabStop = False
        Me.txtPrecioPesoCarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioVolumenCarga
        '
        Me.txtPrecioVolumenCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioVolumenCarga.Location = New System.Drawing.Point(122, 58)
        Me.txtPrecioVolumenCarga.Name = "txtPrecioVolumenCarga"
        Me.txtPrecioVolumenCarga.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioVolumenCarga.TabIndex = 0
        Me.txtPrecioVolumenCarga.TabStop = False
        Me.txtPrecioVolumenCarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioVolumenCargaFinal
        '
        Me.txtPrecioVolumenCargaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioVolumenCargaFinal.Location = New System.Drawing.Point(189, 58)
        Me.txtPrecioVolumenCargaFinal.Name = "txtPrecioVolumenCargaFinal"
        Me.txtPrecioVolumenCargaFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioVolumenCargaFinal.TabIndex = 3
        Me.txtPrecioVolumenCargaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gruPostales
        '
        Me.gruPostales.BackColor = System.Drawing.Color.Transparent
        Me.gruPostales.Controls.Add(Me.txtPrecioPostalVolumenFinal)
        Me.gruPostales.Controls.Add(Me.txtPrecioPostalVolumen)
        Me.gruPostales.Controls.Add(Me.txtPrecioPostalPesoFinal)
        Me.gruPostales.Controls.Add(Me.txtPrecioPostalPeso)
        Me.gruPostales.Controls.Add(Me.Label4)
        Me.gruPostales.Controls.Add(Me.txtPrecioPostalFinal)
        Me.gruPostales.Controls.Add(Me.Label2)
        Me.gruPostales.Controls.Add(Me.txtPrecioPostalBase)
        Me.gruPostales.Controls.Add(Me.Label29)
        Me.gruPostales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gruPostales.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gruPostales.Location = New System.Drawing.Point(0, 0)
        Me.gruPostales.Name = "gruPostales"
        Me.gruPostales.Size = New System.Drawing.Size(271, 101)
        Me.gruPostales.TabIndex = 184
        Me.gruPostales.TabStop = False
        Me.gruPostales.Text = "Tarifa Postales"
        '
        'txtPrecioPostalVolumenFinal
        '
        Me.txtPrecioPostalVolumenFinal.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioPostalVolumenFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalVolumenFinal.Location = New System.Drawing.Point(189, 74)
        Me.txtPrecioPostalVolumenFinal.Name = "txtPrecioPostalVolumenFinal"
        Me.txtPrecioPostalVolumenFinal.ReadOnly = True
        Me.txtPrecioPostalVolumenFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalVolumenFinal.TabIndex = 3
        Me.txtPrecioPostalVolumenFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalVolumen
        '
        Me.txtPrecioPostalVolumen.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioPostalVolumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalVolumen.Location = New System.Drawing.Point(122, 74)
        Me.txtPrecioPostalVolumen.Name = "txtPrecioPostalVolumen"
        Me.txtPrecioPostalVolumen.ReadOnly = True
        Me.txtPrecioPostalVolumen.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalVolumen.TabIndex = 0
        Me.txtPrecioPostalVolumen.TabStop = False
        Me.txtPrecioPostalVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalPesoFinal
        '
        Me.txtPrecioPostalPesoFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalPesoFinal.Location = New System.Drawing.Point(189, 48)
        Me.txtPrecioPostalPesoFinal.Name = "txtPrecioPostalPesoFinal"
        Me.txtPrecioPostalPesoFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalPesoFinal.TabIndex = 2
        Me.txtPrecioPostalPesoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalPeso
        '
        Me.txtPrecioPostalPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalPeso.Location = New System.Drawing.Point(122, 48)
        Me.txtPrecioPostalPeso.Name = "txtPrecioPostalPeso"
        Me.txtPrecioPostalPeso.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalPeso.TabIndex = 0
        Me.txtPrecioPostalPeso.TabStop = False
        Me.txtPrecioPostalPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(21, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "Precio x Volumen :"
        '
        'txtPrecioPostalFinal
        '
        Me.txtPrecioPostalFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalFinal.Location = New System.Drawing.Point(189, 22)
        Me.txtPrecioPostalFinal.Name = "txtPrecioPostalFinal"
        Me.txtPrecioPostalFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalFinal.TabIndex = 1
        Me.txtPrecioPostalFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(28, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Precio x Unidad :"
        '
        'txtPrecioPostalBase
        '
        Me.txtPrecioPostalBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalBase.Location = New System.Drawing.Point(122, 22)
        Me.txtPrecioPostalBase.Name = "txtPrecioPostalBase"
        Me.txtPrecioPostalBase.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalBase.TabIndex = 0
        Me.txtPrecioPostalBase.TabStop = False
        Me.txtPrecioPostalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(46, 26)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(70, 13)
        Me.Label29.TabIndex = 141
        Me.Label29.Text = "Monto Base :"
        '
        'chkCondicional
        '
        Me.chkCondicional.AutoSize = True
        Me.chkCondicional.BackColor = System.Drawing.Color.Transparent
        Me.chkCondicional.Enabled = False
        Me.chkCondicional.Location = New System.Drawing.Point(518, 96)
        Me.chkCondicional.Name = "chkCondicional"
        Me.chkCondicional.Size = New System.Drawing.Size(154, 17)
        Me.chkCondicional.TabIndex = 5
        Me.chkCondicional.Text = "Asignar los mismos valores."
        Me.chkCondicional.UseVisualStyleBackColor = False
        Me.chkCondicional.Visible = False
        '
        'rdbPostales
        '
        Me.rdbPostales.AutoSize = True
        Me.rdbPostales.BackColor = System.Drawing.Color.Transparent
        Me.rdbPostales.Enabled = False
        Me.rdbPostales.Location = New System.Drawing.Point(372, 125)
        Me.rdbPostales.Name = "rdbPostales"
        Me.rdbPostales.Size = New System.Drawing.Size(58, 17)
        Me.rdbPostales.TabIndex = 8
        Me.rdbPostales.TabStop = True
        Me.rdbPostales.Text = "Sobres"
        Me.rdbPostales.UseVisualStyleBackColor = False
        Me.rdbPostales.Visible = False
        '
        'ChkVigente
        '
        Me.ChkVigente.AutoSize = True
        Me.ChkVigente.BackColor = System.Drawing.Color.Transparent
        Me.ChkVigente.Checked = True
        Me.ChkVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkVigente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkVigente.Location = New System.Drawing.Point(443, 217)
        Me.ChkVigente.Name = "ChkVigente"
        Me.ChkVigente.Size = New System.Drawing.Size(71, 17)
        Me.ChkVigente.TabIndex = 0
        Me.ChkVigente.TabStop = False
        Me.ChkVigente.Text = "¿Vigente?"
        Me.ChkVigente.UseVisualStyleBackColor = False
        '
        'rdbGiros
        '
        Me.rdbGiros.AutoSize = True
        Me.rdbGiros.BackColor = System.Drawing.Color.Transparent
        Me.rdbGiros.Enabled = False
        Me.rdbGiros.Location = New System.Drawing.Point(458, 125)
        Me.rdbGiros.Name = "rdbGiros"
        Me.rdbGiros.Size = New System.Drawing.Size(49, 17)
        Me.rdbGiros.TabIndex = 9
        Me.rdbGiros.TabStop = True
        Me.rdbGiros.Text = "Giros"
        Me.rdbGiros.UseVisualStyleBackColor = False
        Me.rdbGiros.Visible = False
        '
        'TxtFecIni
        '
        Me.TxtFecIni._MyFecha = Nothing
        Me.TxtFecIni.BackColor = System.Drawing.Color.Transparent
        Me.TxtFecIni.Location = New System.Drawing.Point(465, 163)
        Me.TxtFecIni.Name = "TxtFecIni"
        Me.TxtFecIni.Size = New System.Drawing.Size(106, 20)
        Me.TxtFecIni.TabIndex = 0
        Me.TxtFecIni.TabStop = False
        '
        'rdbEncomiendas
        '
        Me.rdbEncomiendas.AutoSize = True
        Me.rdbEncomiendas.BackColor = System.Drawing.Color.Transparent
        Me.rdbEncomiendas.Enabled = False
        Me.rdbEncomiendas.Location = New System.Drawing.Point(256, 125)
        Me.rdbEncomiendas.Name = "rdbEncomiendas"
        Me.rdbEncomiendas.Size = New System.Drawing.Size(89, 17)
        Me.rdbEncomiendas.TabIndex = 7
        Me.rdbEncomiendas.TabStop = True
        Me.rdbEncomiendas.Text = "Encomiendas"
        Me.rdbEncomiendas.UseVisualStyleBackColor = False
        Me.rdbEncomiendas.Visible = False
        '
        'rdbCarga
        '
        Me.rdbCarga.AutoSize = True
        Me.rdbCarga.BackColor = System.Drawing.Color.Transparent
        Me.rdbCarga.Location = New System.Drawing.Point(179, 125)
        Me.rdbCarga.Name = "rdbCarga"
        Me.rdbCarga.Size = New System.Drawing.Size(53, 17)
        Me.rdbCarga.TabIndex = 6
        Me.rdbCarga.TabStop = True
        Me.rdbCarga.Text = "Carga"
        Me.rdbCarga.UseVisualStyleBackColor = False
        '
        'TxtFecFin
        '
        Me.TxtFecFin._MyFecha = Nothing
        Me.TxtFecFin.BackColor = System.Drawing.Color.Transparent
        Me.TxtFecFin.Location = New System.Drawing.Point(465, 189)
        Me.TxtFecFin.Name = "TxtFecFin"
        Me.TxtFecFin.Size = New System.Drawing.Size(106, 20)
        Me.TxtFecFin.TabIndex = 0
        Me.TxtFecFin.TabStop = False
        '
        'gruTiempo
        '
        Me.gruTiempo.BackColor = System.Drawing.Color.Transparent
        Me.gruTiempo.Controls.Add(Me.Label42)
        Me.gruTiempo.Controls.Add(Me.Label41)
        Me.gruTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gruTiempo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gruTiempo.Location = New System.Drawing.Point(362, 144)
        Me.gruTiempo.Name = "gruTiempo"
        Me.gruTiempo.Size = New System.Drawing.Size(292, 101)
        Me.gruTiempo.TabIndex = 182
        Me.gruTiempo.TabStop = False
        Me.gruTiempo.Text = "Fecha Vigencia"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Location = New System.Drawing.Point(22, 24)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(71, 13)
        Me.Label42.TabIndex = 163
        Me.Label42.Text = "Fecha Inicio :"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Location = New System.Drawing.Point(33, 49)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(60, 13)
        Me.Label41.TabIndex = 164
        Me.Label41.Text = "Fecha Fin :"
        '
        'txtID
        '
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtID.Location = New System.Drawing.Point(93, 94)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(38, 20)
        Me.txtID.TabIndex = 1
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Location = New System.Drawing.Point(42, 127)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(131, 13)
        Me.Label38.TabIndex = 176
        Me.Label38.Text = "Especificar Tarifario Para :"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(21, 98)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(71, 13)
        Me.Label27.TabIndex = 175
        Me.Label27.Text = "Nro Tarifario :"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDestino
        '
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Location = New System.Drawing.Point(336, 94)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(148, 21)
        Me.cmbDestino.TabIndex = 3
        '
        'cmbOrigen
        '
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(178, 94)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(108, 21)
        Me.cmbOrigen.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(289, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Destino :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(134, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "Origen :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txt_porcentaje_descuento)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.lblCodigoCliente)
        Me.GroupBox2.Controls.Add(Me.txtFuncionarioActual)
        Me.GroupBox2.Controls.Add(Me.txtNombreCliente)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblRazonSocial)
        Me.GroupBox2.Controls.Add(Me.txtCodigoCLiente)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(18, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1319, 75)
        Me.GroupBox2.TabIndex = 178
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Cliente :"
        '
        'txt_porcentaje_descuento
        '
        Me.txt_porcentaje_descuento.BackColor = System.Drawing.SystemColors.Control
        Me.txt_porcentaje_descuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_porcentaje_descuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_porcentaje_descuento.Location = New System.Drawing.Point(603, 46)
        Me.txt_porcentaje_descuento.MaxLength = 15
        Me.txt_porcentaje_descuento.Name = "txt_porcentaje_descuento"
        Me.txt_porcentaje_descuento.Size = New System.Drawing.Size(81, 20)
        Me.txt_porcentaje_descuento.TabIndex = 201
        Me.txt_porcentaje_descuento.TabStop = False
        Me.txt_porcentaje_descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(9, 48)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(111, 13)
        Me.Label26.TabIndex = 122
        Me.Label26.Text = "Funcionario Negocio :"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigoCliente.Location = New System.Drawing.Point(9, 24)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(98, 13)
        Me.lblCodigoCliente.TabIndex = 122
        Me.lblCodigoCliente.Text = "Código del Cliente :"
        Me.lblCodigoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFuncionarioActual
        '
        Me.txtFuncionarioActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFuncionarioActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFuncionarioActual.Location = New System.Drawing.Point(121, 46)
        Me.txtFuncionarioActual.Name = "txtFuncionarioActual"
        Me.txtFuncionarioActual.ReadOnly = True
        Me.txtFuncionarioActual.Size = New System.Drawing.Size(295, 20)
        Me.txtFuncionarioActual.TabIndex = 0
        Me.txtFuncionarioActual.TabStop = False
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCliente.Location = New System.Drawing.Point(286, 20)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(399, 20)
        Me.txtNombreCliente.TabIndex = 0
        Me.txtNombreCliente.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(502, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 202
        Me.Label9.Text = "Porcentaje Dscto :"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.BackColor = System.Drawing.Color.Transparent
        Me.lblRazonSocial.Location = New System.Drawing.Point(206, 24)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(76, 13)
        Me.lblRazonSocial.TabIndex = 121
        Me.lblRazonSocial.Text = "Razon Social :"
        Me.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodigoCLiente
        '
        Me.txtCodigoCLiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCLiente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCLiente.Location = New System.Drawing.Point(107, 20)
        Me.txtCodigoCLiente.MaxLength = 11
        Me.txtCodigoCLiente.Name = "txtCodigoCLiente"
        Me.txtCodigoCLiente.ReadOnly = True
        Me.txtCodigoCLiente.Size = New System.Drawing.Size(96, 20)
        Me.txtCodigoCLiente.TabIndex = 0
        Me.txtCodigoCLiente.TabStop = False
        '
        'gruGiros
        '
        Me.gruGiros.BackColor = System.Drawing.Color.Transparent
        Me.gruGiros.Controls.Add(Me.txtMontoBaseGiro)
        Me.gruGiros.Controls.Add(Me.txtPorctTelefono)
        Me.gruGiros.Controls.Add(Me.txtPorctTelefonoFinal)
        Me.gruGiros.Controls.Add(Me.txtPorctNormal)
        Me.gruGiros.Controls.Add(Me.Label35)
        Me.gruGiros.Controls.Add(Me.txtPorctNormalFinal)
        Me.gruGiros.Controls.Add(Me.txtMontoBaseGiroFinal)
        Me.gruGiros.Controls.Add(Me.Label30)
        Me.gruGiros.Controls.Add(Me.Label28)
        Me.gruGiros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gruGiros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gruGiros.Location = New System.Drawing.Point(70, 144)
        Me.gruGiros.Name = "gruGiros"
        Me.gruGiros.Size = New System.Drawing.Size(271, 101)
        Me.gruGiros.TabIndex = 184
        Me.gruGiros.TabStop = False
        Me.gruGiros.Text = "Tarifa Giros"
        '
        'txtMontoBaseGiro
        '
        Me.txtMontoBaseGiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoBaseGiro.Location = New System.Drawing.Point(122, 22)
        Me.txtMontoBaseGiro.Name = "txtMontoBaseGiro"
        Me.txtMontoBaseGiro.Size = New System.Drawing.Size(61, 20)
        Me.txtMontoBaseGiro.TabIndex = 0
        Me.txtMontoBaseGiro.TabStop = False
        Me.txtMontoBaseGiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorctTelefono
        '
        Me.txtPorctTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorctTelefono.Location = New System.Drawing.Point(122, 74)
        Me.txtPorctTelefono.Name = "txtPorctTelefono"
        Me.txtPorctTelefono.Size = New System.Drawing.Size(61, 20)
        Me.txtPorctTelefono.TabIndex = 0
        Me.txtPorctTelefono.TabStop = False
        Me.txtPorctTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorctTelefonoFinal
        '
        Me.txtPorctTelefonoFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorctTelefonoFinal.Location = New System.Drawing.Point(189, 74)
        Me.txtPorctTelefonoFinal.Name = "txtPorctTelefonoFinal"
        Me.txtPorctTelefonoFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPorctTelefonoFinal.TabIndex = 3
        Me.txtPorctTelefonoFinal.Text = "0"
        Me.txtPorctTelefonoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorctNormal
        '
        Me.txtPorctNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorctNormal.Location = New System.Drawing.Point(122, 48)
        Me.txtPorctNormal.Name = "txtPorctNormal"
        Me.txtPorctNormal.Size = New System.Drawing.Size(61, 20)
        Me.txtPorctNormal.TabIndex = 0
        Me.txtPorctNormal.TabStop = False
        Me.txtPorctNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Location = New System.Drawing.Point(46, 26)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 13)
        Me.Label35.TabIndex = 155
        Me.Label35.Text = "Monto Base :"
        '
        'txtPorctNormalFinal
        '
        Me.txtPorctNormalFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorctNormalFinal.Location = New System.Drawing.Point(189, 48)
        Me.txtPorctNormalFinal.Name = "txtPorctNormalFinal"
        Me.txtPorctNormalFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPorctNormalFinal.TabIndex = 2
        Me.txtPorctNormalFinal.Text = "0"
        Me.txtPorctNormalFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoBaseGiroFinal
        '
        Me.txtMontoBaseGiroFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoBaseGiroFinal.Location = New System.Drawing.Point(189, 22)
        Me.txtMontoBaseGiroFinal.Name = "txtMontoBaseGiroFinal"
        Me.txtMontoBaseGiroFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtMontoBaseGiroFinal.TabIndex = 1
        Me.txtMontoBaseGiroFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(42, 78)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(74, 13)
        Me.Label30.TabIndex = 152
        Me.Label30.Text = "% Telefonico :"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(59, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 13)
        Me.Label28.TabIndex = 148
        Me.Label28.Text = "% Normal :"
        '
        'gruEncomienda
        '
        Me.gruEncomienda.BackColor = System.Drawing.Color.Transparent
        Me.gruEncomienda.Controls.Add(Me.txtPrecioVolumenEncomienda)
        Me.gruEncomienda.Controls.Add(Me.Label31)
        Me.gruEncomienda.Controls.Add(Me.txtMontoBaseEncomienda)
        Me.gruEncomienda.Controls.Add(Me.txtMontoBaseEncomiendaFinal)
        Me.gruEncomienda.Controls.Add(Me.txtPrecioPesoEncomiendaFinal)
        Me.gruEncomienda.Controls.Add(Me.Label32)
        Me.gruEncomienda.Controls.Add(Me.Label33)
        Me.gruEncomienda.Controls.Add(Me.txtPrecioPesoEncomienda)
        Me.gruEncomienda.Controls.Add(Me.txtPrecioVolumenEncomiendaFinal)
        Me.gruEncomienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gruEncomienda.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gruEncomienda.Location = New System.Drawing.Point(70, 144)
        Me.gruEncomienda.Name = "gruEncomienda"
        Me.gruEncomienda.Size = New System.Drawing.Size(271, 101)
        Me.gruEncomienda.TabIndex = 183
        Me.gruEncomienda.TabStop = False
        Me.gruEncomienda.Text = "Tarifa Encomienda"
        '
        'txtPrecioVolumenEncomienda
        '
        Me.txtPrecioVolumenEncomienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioVolumenEncomienda.Location = New System.Drawing.Point(122, 74)
        Me.txtPrecioVolumenEncomienda.Name = "txtPrecioVolumenEncomienda"
        Me.txtPrecioVolumenEncomienda.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioVolumenEncomienda.TabIndex = 0
        Me.txtPrecioVolumenEncomienda.TabStop = False
        Me.txtPrecioVolumenEncomienda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(38, 52)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(78, 13)
        Me.Label31.TabIndex = 143
        Me.Label31.Text = "Precio x Peso :"
        '
        'txtMontoBaseEncomienda
        '
        Me.txtMontoBaseEncomienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoBaseEncomienda.Location = New System.Drawing.Point(122, 22)
        Me.txtMontoBaseEncomienda.Name = "txtMontoBaseEncomienda"
        Me.txtMontoBaseEncomienda.Size = New System.Drawing.Size(61, 20)
        Me.txtMontoBaseEncomienda.TabIndex = 0
        Me.txtMontoBaseEncomienda.TabStop = False
        Me.txtMontoBaseEncomienda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoBaseEncomiendaFinal
        '
        Me.txtMontoBaseEncomiendaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoBaseEncomiendaFinal.Location = New System.Drawing.Point(189, 22)
        Me.txtMontoBaseEncomiendaFinal.Name = "txtMontoBaseEncomiendaFinal"
        Me.txtMontoBaseEncomiendaFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtMontoBaseEncomiendaFinal.TabIndex = 1
        Me.txtMontoBaseEncomiendaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPesoEncomiendaFinal
        '
        Me.txtPrecioPesoEncomiendaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPesoEncomiendaFinal.Location = New System.Drawing.Point(189, 48)
        Me.txtPrecioPesoEncomiendaFinal.Name = "txtPrecioPesoEncomiendaFinal"
        Me.txtPrecioPesoEncomiendaFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPesoEncomiendaFinal.TabIndex = 2
        Me.txtPrecioPesoEncomiendaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Location = New System.Drawing.Point(21, 78)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(95, 13)
        Me.Label32.TabIndex = 144
        Me.Label32.Text = "Precio x Volumen :"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Location = New System.Drawing.Point(46, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 142
        Me.Label33.Text = "Monto Base :"
        '
        'txtPrecioPesoEncomienda
        '
        Me.txtPrecioPesoEncomienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPesoEncomienda.Location = New System.Drawing.Point(122, 48)
        Me.txtPrecioPesoEncomienda.Name = "txtPrecioPesoEncomienda"
        Me.txtPrecioPesoEncomienda.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPesoEncomienda.TabIndex = 0
        Me.txtPrecioPesoEncomienda.TabStop = False
        Me.txtPrecioPesoEncomienda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioVolumenEncomiendaFinal
        '
        Me.txtPrecioVolumenEncomiendaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioVolumenEncomiendaFinal.Location = New System.Drawing.Point(189, 74)
        Me.txtPrecioVolumenEncomiendaFinal.Name = "txtPrecioVolumenEncomiendaFinal"
        Me.txtPrecioVolumenEncomiendaFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioVolumenEncomiendaFinal.TabIndex = 3
        Me.txtPrecioVolumenEncomiendaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gruCalculos
        '
        Me.gruCalculos.BackColor = System.Drawing.SystemColors.Info
        Me.gruCalculos.Controls.Add(Me.Label43)
        Me.gruCalculos.Controls.Add(Me.Label39)
        Me.gruCalculos.Controls.Add(Me.txtMontoFinalCal)
        Me.gruCalculos.Controls.Add(Me.txtDecuentoCal)
        Me.gruCalculos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gruCalculos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gruCalculos.Location = New System.Drawing.Point(346, 159)
        Me.gruCalculos.Name = "gruCalculos"
        Me.gruCalculos.Size = New System.Drawing.Size(196, 79)
        Me.gruCalculos.TabIndex = 181
        Me.gruCalculos.TabStop = False
        Me.gruCalculos.Visible = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Location = New System.Drawing.Point(17, 47)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(68, 13)
        Me.Label43.TabIndex = 157
        Me.Label43.Text = "Precio Final :"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Location = New System.Drawing.Point(24, 18)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(61, 13)
        Me.Label39.TabIndex = 157
        Me.Label39.Text = "% Inc-Des :"
        '
        'txtMontoFinalCal
        '
        Me.txtMontoFinalCal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoFinalCal.Location = New System.Drawing.Point(99, 43)
        Me.txtMontoFinalCal.Name = "txtMontoFinalCal"
        Me.txtMontoFinalCal.Size = New System.Drawing.Size(72, 20)
        Me.txtMontoFinalCal.TabIndex = 2
        '
        'txtDecuentoCal
        '
        Me.txtDecuentoCal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDecuentoCal.Location = New System.Drawing.Point(99, 14)
        Me.txtDecuentoCal.Name = "txtDecuentoCal"
        Me.txtDecuentoCal.Size = New System.Drawing.Size(72, 20)
        Me.txtDecuentoCal.TabIndex = 1
        '
        'MyImageList
        '
        Me.MyImageList.ImageStream = CType(resources.GetObject("MyImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.MyImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.MyImageList.Images.SetKeyName(0, "arrow-up_16.ico")
        Me.MyImageList.Images.SetKeyName(1, "arrow-forward_16.ico")
        '
        'PanelTarifaCliente
        '
        Me.PanelTarifaCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelTarifaCliente.Controls.Add(Me.dgvTarifasCliente)
        Me.PanelTarifaCliente.Location = New System.Drawing.Point(15, 78)
        Me.PanelTarifaCliente.Name = "PanelTarifaCliente"
        Me.PanelTarifaCliente.Size = New System.Drawing.Size(727, 369)
        Me.PanelTarifaCliente.TabIndex = 142
        '
        'dgvTarifasCliente
        '
        Me.dgvTarifasCliente.BackgroundColor = System.Drawing.Color.White
        Me.dgvTarifasCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTarifasCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTarifasCliente.Location = New System.Drawing.Point(0, 0)
        Me.dgvTarifasCliente.Name = "dgvTarifasCliente"
        Me.dgvTarifasCliente.Size = New System.Drawing.Size(727, 369)
        Me.dgvTarifasCliente.TabIndex = 0
        '
        'btncargaTarifa
        '
        Me.btncargaTarifa.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btncargaTarifa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncargaTarifa.Image = CType(resources.GetObject("btncargaTarifa.Image"), System.Drawing.Image)
        Me.btncargaTarifa.Location = New System.Drawing.Point(488, 94)
        Me.btncargaTarifa.Name = "btncargaTarifa"
        Me.btncargaTarifa.Size = New System.Drawing.Size(22, 20)
        Me.btncargaTarifa.TabIndex = 4
        Me.btncargaTarifa.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.cmbSubCuenta)
        Me.GroupBox1.Controls.Add(Me.rdbAmbos)
        Me.GroupBox1.Controls.Add(Me.rdbArticulos)
        Me.GroupBox1.Controls.Add(Me.rdbCondicionales)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 244)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(699, 37)
        Me.GroupBox1.TabIndex = 200
        Me.GroupBox1.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(444, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 241
        Me.Label19.Text = "Sub.Cuenta"
        '
        'cmbSubCuenta
        '
        Me.cmbSubCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubCuenta.FormattingEnabled = True
        Me.cmbSubCuenta.Location = New System.Drawing.Point(510, 10)
        Me.cmbSubCuenta.MaxDropDownItems = 9
        Me.cmbSubCuenta.Name = "cmbSubCuenta"
        Me.cmbSubCuenta.Size = New System.Drawing.Size(183, 21)
        Me.cmbSubCuenta.TabIndex = 240
        '
        'btn_tarifa_masiva
        '
        Me.btn_tarifa_masiva.ForeColor = System.Drawing.Color.Maroon
        Me.btn_tarifa_masiva.Location = New System.Drawing.Point(636, 10)
        Me.btn_tarifa_masiva.Name = "btn_tarifa_masiva"
        Me.btn_tarifa_masiva.Size = New System.Drawing.Size(97, 23)
        Me.btn_tarifa_masiva.TabIndex = 143
        Me.btn_tarifa_masiva.Text = "Tarifa Masiva..."
        Me.btn_tarifa_masiva.UseVisualStyleBackColor = True
        '
        'txt_codigo_cliente_1
        '
        Me.txt_codigo_cliente_1.AutoSize = True
        Me.txt_codigo_cliente_1.Location = New System.Drawing.Point(12, 15)
        Me.txt_codigo_cliente_1.Name = "txt_codigo_cliente_1"
        Me.txt_codigo_cliente_1.Size = New System.Drawing.Size(83, 13)
        Me.txt_codigo_cliente_1.TabIndex = 144
        Me.txt_codigo_cliente_1.Text = "Código cliente : "
        '
        'txt_codigo_cliente1
        '
        Me.txt_codigo_cliente1.Location = New System.Drawing.Point(94, 12)
        Me.txt_codigo_cliente1.Name = "txt_codigo_cliente1"
        Me.txt_codigo_cliente1.ReadOnly = True
        Me.txt_codigo_cliente1.Size = New System.Drawing.Size(100, 20)
        Me.txt_codigo_cliente1.TabIndex = 145
        '
        'txt_razon_social1
        '
        Me.txt_razon_social1.Location = New System.Drawing.Point(276, 12)
        Me.txt_razon_social1.Name = "txt_razon_social1"
        Me.txt_razon_social1.ReadOnly = True
        Me.txt_razon_social1.Size = New System.Drawing.Size(354, 20)
        Me.txt_razon_social1.TabIndex = 146
        '
        'txt_funcionario1
        '
        Me.txt_funcionario1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_funcionario1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_funcionario1.Location = New System.Drawing.Point(94, 38)
        Me.txt_funcionario1.Name = "txt_funcionario1"
        Me.txt_funcionario1.ReadOnly = True
        Me.txt_funcionario1.Size = New System.Drawing.Size(348, 20)
        Me.txt_funcionario1.TabIndex = 147
        Me.txt_funcionario1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(196, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Razón Social : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Funcionario :"
        '
        'txt_descuento
        '
        Me.txt_descuento.BackColor = System.Drawing.SystemColors.Control
        Me.txt_descuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_descuento.Location = New System.Drawing.Point(549, 40)
        Me.txt_descuento.MaxLength = 15
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.Size = New System.Drawing.Size(81, 20)
        Me.txt_descuento.TabIndex = 150
        Me.txt_descuento.TabStop = False
        Me.txt_descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(448, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 151
        Me.Label8.Text = "Porcentaje Dscto :"
        '
        'FrmTarifarioCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmTarifarioCliente"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel.ResumeLayout(False)
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ContenedorGrillas.Panel1.ResumeLayout(False)
        Me.ContenedorGrillas.Panel2.ResumeLayout(False)
        CType(Me.ContenedorGrillas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContenedorGrillas.ResumeLayout(False)
        CType(Me.dgvArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCondicional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gruCarga.ResumeLayout(False)
        Me.gruCarga.PerformLayout()
        Me.gruPostales.ResumeLayout(False)
        Me.gruPostales.PerformLayout()
        Me.gruTiempo.ResumeLayout(False)
        Me.gruTiempo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gruGiros.ResumeLayout(False)
        Me.gruGiros.PerformLayout()
        Me.gruEncomienda.ResumeLayout(False)
        Me.gruEncomienda.PerformLayout()
        Me.gruCalculos.ResumeLayout(False)
        Me.gruCalculos.PerformLayout()
        Me.PanelTarifaCliente.ResumeLayout(False)
        CType(Me.dgvTarifasCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCargarClientes As System.Windows.Forms.Button
    Friend WithEvents cmbFiltroGrilla As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdbnaturales As System.Windows.Forms.RadioButton
    Friend WithEvents rdbJuridicos As System.Windows.Forms.RadioButton
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents DataGridLista As System.Windows.Forms.DataGridView
    Friend WithEvents rdbAmbos As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCondicionales As System.Windows.Forms.RadioButton
    Friend WithEvents rdbArticulos As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ContenedorGrillas As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvArticulo As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCondicional As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gruCarga As System.Windows.Forms.GroupBox
    Friend WithEvents txtMontoBaseCarga As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtMontoBaseCargaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioPesoCargaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioPesoCarga As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioVolumenCarga As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioVolumenCargaFinal As System.Windows.Forms.TextBox
    Friend WithEvents chkCondicional As System.Windows.Forms.CheckBox
    Friend WithEvents rdbPostales As System.Windows.Forms.RadioButton
    Friend WithEvents ChkVigente As System.Windows.Forms.CheckBox
    Friend WithEvents rdbGiros As System.Windows.Forms.RadioButton
    Friend WithEvents TxtFecIni As ControlsTepsa.DataPickerMasked
    Friend WithEvents rdbEncomiendas As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCarga As System.Windows.Forms.RadioButton
    Friend WithEvents TxtFecFin As ControlsTepsa.DataPickerMasked
    Friend WithEvents gruTiempo As System.Windows.Forms.GroupBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblCodigoCliente As System.Windows.Forms.Label
    Friend WithEvents txtFuncionarioActual As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCLiente As System.Windows.Forms.TextBox
    Friend WithEvents gruGiros As System.Windows.Forms.GroupBox
    Friend WithEvents txtMontoBaseGiro As System.Windows.Forms.TextBox
    Friend WithEvents txtPorctTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtPorctTelefonoFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPorctNormal As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtPorctNormalFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoBaseGiroFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents gruEncomienda As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrecioVolumenEncomienda As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtMontoBaseEncomienda As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoBaseEncomiendaFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPesoEncomiendaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioPesoEncomienda As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioVolumenEncomiendaFinal As System.Windows.Forms.TextBox
    Friend WithEvents gruPostales As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrecioPostalVolumenFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalPesoFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioPostalFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioPostalBase As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents gruCalculos As System.Windows.Forms.GroupBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtMontoFinalCal As System.Windows.Forms.TextBox
    Friend WithEvents txtDecuentoCal As System.Windows.Forms.TextBox
    Friend WithEvents MyImageList As System.Windows.Forms.ImageList
    Friend WithEvents PanelTarifaCliente As System.Windows.Forms.Panel
    Friend WithEvents dgvTarifasCliente As System.Windows.Forms.DataGridView
    Friend WithEvents btncargaTarifa As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbSubCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents btn_tarifa_masiva As System.Windows.Forms.Button
    Friend WithEvents txt_codigo_cliente_1 As System.Windows.Forms.Label
    Friend WithEvents txt_razon_social1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_cliente1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_funcionario1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento As System.Windows.Forms.TextBox
    Friend WithEvents txt_porcentaje_descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_cg_sobre As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioSobreCargaFinal As System.Windows.Forms.TextBox

   
End Class
