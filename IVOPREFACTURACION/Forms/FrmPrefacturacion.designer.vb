<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrefacturacion
    Inherits INTEGRACION.FrmPlantillaFacturacion

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrefacturacion))
        Me.dgvGuiasEnvio = New System.Windows.Forms.DataGridView()
        Me.MenuSeleccionGuias = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionarHastaEstaPosicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestablecerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitarTodoFiltroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.NoPrefacturarGuíaDeEnvíoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fecha2 = New ControlsTepsa.DataPickerMasked()
        Me.Fecha1 = New ControlsTepsa.DataPickerMasked()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.txtNroPreFactura = New System.Windows.Forms.TextBox()
        Me.txtMontoFinalPreFacturar = New System.Windows.Forms.TextBox()
        Me.LabelProducto = New System.Windows.Forms.Label()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRazonSocialCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSumatoriaMonto = New System.Windows.Forms.TextBox()
        Me.chkSoloPendientes = New System.Windows.Forms.CheckBox()
        Me.cmbCentroCosto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbDestinos = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCodigoClienteFinal = New System.Windows.Forms.TextBox()
        Me.txtNroPreFacturaFinal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRazonSocialClienteFinal = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvGuiasFinal = New System.Windows.Forms.DataGridView()
        Me.txtMontoPreFacturaFinal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTipofacturacion = New System.Windows.Forms.TextBox()
        Me.TimerSuma = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.labnroregselecciona = New System.Windows.Forms.Label()
        Me.Labreggrabar = New System.Windows.Forms.Label()
        Me.LblDt = New System.Windows.Forms.Label()
        Me.TxtDt = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        CType(Me.dgvGuiasEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuSeleccionGuias.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvGuiasFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Size = New System.Drawing.Size(1102, 599)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(1102, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Location = New System.Drawing.Point(13, 48)
        Me.SplitContainer2.Size = New System.Drawing.Size(7828, 254)
        Me.SplitContainer2.SplitterDistance = 0
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(162, -41)
        Me.Panel1.Size = New System.Drawing.Size(1684, 524)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(1138, 491)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(1138, 491)
        '
        'TabPage3
        '
        Me.TabPage3.Size = New System.Drawing.Size(1138, 491)
        '
        'TabPage4
        '
        Me.TabPage4.Size = New System.Drawing.Size(1138, 491)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.dgvGuiasEnvio)
        Me.Panel.Location = New System.Drawing.Point(6, 133)
        Me.Panel.Size = New System.Drawing.Size(712, 290)
        '
        'TabMante
        '
        Me.TabMante.Location = New System.Drawing.Point(3, 67)
        Me.TabMante.Size = New System.Drawing.Size(1714, 520)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.TxtDt)
        Me.TabLista.Controls.Add(Me.LblDt)
        Me.TabLista.Controls.Add(Me.labnroregselecciona)
        Me.TabLista.Controls.Add(Me.Button1)
        Me.TabLista.Controls.Add(Me.cmbDestinos)
        Me.TabLista.Controls.Add(Me.cmbCentroCosto)
        Me.TabLista.Controls.Add(Me.chkSoloPendientes)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.txtSumatoriaMonto)
        Me.TabLista.Controls.Add(Me.Fecha2)
        Me.TabLista.Controls.Add(Me.Fecha1)
        Me.TabLista.Controls.Add(Me.btnGenerar)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.txtTipofacturacion)
        Me.TabLista.Controls.Add(Me.txtCodigoCliente)
        Me.TabLista.Controls.Add(Me.txtNroPreFactura)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.txtMontoFinalPreFacturar)
        Me.TabLista.Controls.Add(Me.Label8)
        Me.TabLista.Controls.Add(Me.Label7)
        Me.TabLista.Controls.Add(Me.cmbProducto)
        Me.TabLista.Controls.Add(Me.LabelProducto)
        Me.TabLista.Controls.Add(Me.Label11)
        Me.TabLista.Controls.Add(Me.Label5)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.Label6)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.txtRazonSocialCliente)
        Me.TabLista.Size = New System.Drawing.Size(1706, 491)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtRazonSocialCliente, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label11, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LabelProducto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbProducto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtMontoFinalPreFacturar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtNroPreFactura, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtCodigoCliente, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtTipofacturacion, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnGenerar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Fecha1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Fecha2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtSumatoriaMonto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.chkSoloPendientes, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbCentroCosto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbDestinos, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Button1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.labnroregselecciona, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LblDt, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtDt, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.Labreggrabar)
        Me.TabDatos.Controls.Add(Me.txtMontoPreFacturaFinal)
        Me.TabDatos.Controls.Add(Me.Label18)
        Me.TabDatos.Controls.Add(Me.Label10)
        Me.TabDatos.Controls.Add(Me.Panel2)
        Me.TabDatos.Controls.Add(Me.txtCodigoClienteFinal)
        Me.TabDatos.Controls.Add(Me.txtNroPreFacturaFinal)
        Me.TabDatos.Controls.Add(Me.Label15)
        Me.TabDatos.Controls.Add(Me.Label16)
        Me.TabDatos.Controls.Add(Me.txtRazonSocialClienteFinal)
        Me.TabDatos.Size = New System.Drawing.Size(1138, 491)
        '
        'dgvGuiasEnvio
        '
        Me.dgvGuiasEnvio.BackgroundColor = System.Drawing.Color.White
        Me.dgvGuiasEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuiasEnvio.ContextMenuStrip = Me.MenuSeleccionGuias
        Me.dgvGuiasEnvio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGuiasEnvio.Location = New System.Drawing.Point(0, 0)
        Me.dgvGuiasEnvio.Name = "dgvGuiasEnvio"
        Me.dgvGuiasEnvio.Size = New System.Drawing.Size(712, 290)
        Me.dgvGuiasEnvio.TabIndex = 1
        '
        'MenuSeleccionGuias
        '
        Me.MenuSeleccionGuias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarTodosToolStripMenuItem, Me.SeleccionarHastaEstaPosicionToolStripMenuItem, Me.RestablecerToolStripMenuItem, Me.ToolStripMenuItem1, Me.QuitarTodoFiltroToolStripMenuItem, Me.ToolStripMenuItem2, Me.NoPrefacturarGuíaDeEnvíoToolStripMenuItem})
        Me.MenuSeleccionGuias.Name = "MenuSeleccionGuias"
        Me.MenuSeleccionGuias.Size = New System.Drawing.Size(227, 126)
        '
        'SeleccionarTodosToolStripMenuItem
        '
        Me.SeleccionarTodosToolStripMenuItem.Name = "SeleccionarTodosToolStripMenuItem"
        Me.SeleccionarTodosToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SeleccionarTodosToolStripMenuItem.Text = "Seleccionar Todos"
        '
        'SeleccionarHastaEstaPosicionToolStripMenuItem
        '
        Me.SeleccionarHastaEstaPosicionToolStripMenuItem.Name = "SeleccionarHastaEstaPosicionToolStripMenuItem"
        Me.SeleccionarHastaEstaPosicionToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SeleccionarHastaEstaPosicionToolStripMenuItem.Text = "Seleccionar hasta Aqui"
        '
        'RestablecerToolStripMenuItem
        '
        Me.RestablecerToolStripMenuItem.Name = "RestablecerToolStripMenuItem"
        Me.RestablecerToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.RestablecerToolStripMenuItem.Text = "Restablecer"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(223, 6)
        '
        'QuitarTodoFiltroToolStripMenuItem
        '
        Me.QuitarTodoFiltroToolStripMenuItem.Name = "QuitarTodoFiltroToolStripMenuItem"
        Me.QuitarTodoFiltroToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.QuitarTodoFiltroToolStripMenuItem.Text = "Quitar Todo Filtro"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(223, 6)
        '
        'NoPrefacturarGuíaDeEnvíoToolStripMenuItem
        '
        Me.NoPrefacturarGuíaDeEnvíoToolStripMenuItem.Name = "NoPrefacturarGuíaDeEnvíoToolStripMenuItem"
        Me.NoPrefacturarGuíaDeEnvíoToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.NoPrefacturarGuíaDeEnvíoToolStripMenuItem.Text = "No Prefacturar Guía de Envío"
        '
        'Fecha2
        '
        Me.Fecha2._MyFecha = Nothing
        Me.Fecha2.BackColor = System.Drawing.Color.Transparent
        Me.Fecha2.Location = New System.Drawing.Point(391, 16)
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.Size = New System.Drawing.Size(106, 20)
        Me.Fecha2.TabIndex = 7
        '
        'Fecha1
        '
        Me.Fecha1._MyFecha = Nothing
        Me.Fecha1.BackColor = System.Drawing.Color.Transparent
        Me.Fecha1.Location = New System.Drawing.Point(224, 16)
        Me.Fecha1.Name = "Fecha1"
        Me.Fecha1.Size = New System.Drawing.Size(106, 20)
        Me.Fecha1.TabIndex = 6
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(640, 71)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(86, 31)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(2, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Nº PreFactura :"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(88, 45)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(68, 20)
        Me.txtCodigoCliente.TabIndex = 1
        '
        'txtNroPreFactura
        '
        Me.txtNroPreFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroPreFactura.Location = New System.Drawing.Point(88, 16)
        Me.txtNroPreFactura.Name = "txtNroPreFactura"
        Me.txtNroPreFactura.Size = New System.Drawing.Size(68, 20)
        Me.txtNroPreFactura.TabIndex = 17
        '
        'txtMontoFinalPreFacturar
        '
        Me.txtMontoFinalPreFacturar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoFinalPreFacturar.Location = New System.Drawing.Point(112, 429)
        Me.txtMontoFinalPreFacturar.Name = "txtMontoFinalPreFacturar"
        Me.txtMontoFinalPreFacturar.Size = New System.Drawing.Size(110, 20)
        Me.txtMontoFinalPreFacturar.TabIndex = 20
        Me.txtMontoFinalPreFacturar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelProducto
        '
        Me.LabelProducto.AutoSize = True
        Me.LabelProducto.BackColor = System.Drawing.Color.Transparent
        Me.LabelProducto.Location = New System.Drawing.Point(503, 18)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(53, 13)
        Me.LabelProducto.TabIndex = 26
        Me.LabelProducto.Text = "Producto:"
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(562, 15)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(168, 21)
        Me.cmbProducto.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(334, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Fec. Fin :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(160, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Fec. Inicio :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(2, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Codigo Cliente :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 433)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Monto a Facturar :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(162, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Cliente :"
        '
        'txtRazonSocialCliente
        '
        Me.txtRazonSocialCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocialCliente.Location = New System.Drawing.Point(224, 45)
        Me.txtRazonSocialCliente.Name = "txtRazonSocialCliente"
        Me.txtRazonSocialCliente.Size = New System.Drawing.Size(312, 20)
        Me.txtRazonSocialCliente.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(308, 435)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Monto a Pre Facturar :"
        '
        'txtSumatoriaMonto
        '
        Me.txtSumatoriaMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSumatoriaMonto.Location = New System.Drawing.Point(425, 431)
        Me.txtSumatoriaMonto.Name = "txtSumatoriaMonto"
        Me.txtSumatoriaMonto.Size = New System.Drawing.Size(110, 20)
        Me.txtSumatoriaMonto.TabIndex = 30
        Me.txtSumatoriaMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSoloPendientes
        '
        Me.chkSoloPendientes.AutoSize = True
        Me.chkSoloPendientes.BackColor = System.Drawing.Color.Transparent
        Me.chkSoloPendientes.Location = New System.Drawing.Point(211, 80)
        Me.chkSoloPendientes.Name = "chkSoloPendientes"
        Me.chkSoloPendientes.Size = New System.Drawing.Size(103, 17)
        Me.chkSoloPendientes.TabIndex = 4
        Me.chkSoloPendientes.Text = "Solo Pendientes"
        Me.chkSoloPendientes.UseVisualStyleBackColor = False
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.Location = New System.Drawing.Point(416, 78)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(135, 21)
        Me.cmbCentroCosto.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(320, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Centro de Costos :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(2, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Destinos :"
        '
        'cmbDestinos
        '
        Me.cmbDestinos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestinos.DropDownWidth = 300
        Me.cmbDestinos.FormattingEnabled = True
        Me.cmbDestinos.Location = New System.Drawing.Point(70, 78)
        Me.cmbDestinos.Name = "cmbDestinos"
        Me.cmbDestinos.Size = New System.Drawing.Size(135, 21)
        Me.cmbDestinos.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(12, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Nro Pre Factura :"
        '
        'txtCodigoClienteFinal
        '
        Me.txtCodigoClienteFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoClienteFinal.Location = New System.Drawing.Point(269, 19)
        Me.txtCodigoClienteFinal.Name = "txtCodigoClienteFinal"
        Me.txtCodigoClienteFinal.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoClienteFinal.TabIndex = 35
        '
        'txtNroPreFacturaFinal
        '
        Me.txtNroPreFacturaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroPreFacturaFinal.Location = New System.Drawing.Point(100, 19)
        Me.txtNroPreFacturaFinal.Name = "txtNroPreFacturaFinal"
        Me.txtNroPreFacturaFinal.Size = New System.Drawing.Size(82, 20)
        Me.txtNroPreFacturaFinal.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(188, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Codigo Cliente :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(365, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Cliente :"
        '
        'txtRazonSocialClienteFinal
        '
        Me.txtRazonSocialClienteFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocialClienteFinal.Location = New System.Drawing.Point(410, 19)
        Me.txtRazonSocialClienteFinal.Name = "txtRazonSocialClienteFinal"
        Me.txtRazonSocialClienteFinal.Size = New System.Drawing.Size(312, 20)
        Me.txtRazonSocialClienteFinal.TabIndex = 36
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvGuiasFinal)
        Me.Panel2.Location = New System.Drawing.Point(19, 74)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(714, 332)
        Me.Panel2.TabIndex = 50
        '
        'dgvGuiasFinal
        '
        Me.dgvGuiasFinal.AllowUserToAddRows = False
        Me.dgvGuiasFinal.AllowUserToDeleteRows = False
        Me.dgvGuiasFinal.BackgroundColor = System.Drawing.Color.White
        Me.dgvGuiasFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuiasFinal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGuiasFinal.Location = New System.Drawing.Point(0, 0)
        Me.dgvGuiasFinal.Name = "dgvGuiasFinal"
        Me.dgvGuiasFinal.ReadOnly = True
        Me.dgvGuiasFinal.Size = New System.Drawing.Size(714, 332)
        Me.dgvGuiasFinal.TabIndex = 2
        '
        'txtMontoPreFacturaFinal
        '
        Me.txtMontoPreFacturaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoPreFacturaFinal.Location = New System.Drawing.Point(609, 429)
        Me.txtMontoPreFacturaFinal.Name = "txtMontoPreFacturaFinal"
        Me.txtMontoPreFacturaFinal.Size = New System.Drawing.Size(110, 20)
        Me.txtMontoPreFacturaFinal.TabIndex = 53
        Me.txtMontoPreFacturaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(509, 433)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 13)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Total Pre Factura :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(548, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Tipo Facturación :"
        '
        'txtTipofacturacion
        '
        Me.txtTipofacturacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipofacturacion.Location = New System.Drawing.Point(636, 45)
        Me.txtTipofacturacion.Name = "txtTipofacturacion"
        Me.txtTipofacturacion.Size = New System.Drawing.Size(94, 20)
        Me.txtTipofacturacion.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(564, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Filtrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'labnroregselecciona
        '
        Me.labnroregselecciona.AutoSize = True
        Me.labnroregselecciona.BackColor = System.Drawing.Color.Transparent
        Me.labnroregselecciona.Location = New System.Drawing.Point(561, 435)
        Me.labnroregselecciona.Name = "labnroregselecciona"
        Me.labnroregselecciona.Size = New System.Drawing.Size(0, 13)
        Me.labnroregselecciona.TabIndex = 32
        '
        'Labreggrabar
        '
        Me.Labreggrabar.AutoSize = True
        Me.Labreggrabar.BackColor = System.Drawing.Color.Transparent
        Me.Labreggrabar.Location = New System.Drawing.Point(12, 433)
        Me.Labreggrabar.Name = "Labreggrabar"
        Me.Labreggrabar.Size = New System.Drawing.Size(0, 13)
        Me.Labreggrabar.TabIndex = 54
        '
        'LblDt
        '
        Me.LblDt.AutoSize = True
        Me.LblDt.BackColor = System.Drawing.Color.Transparent
        Me.LblDt.Location = New System.Drawing.Point(6, 110)
        Me.LblDt.Name = "LblDt"
        Me.LblDt.Size = New System.Drawing.Size(28, 13)
        Me.LblDt.TabIndex = 33
        Me.LblDt.Text = "DT :"
        Me.LblDt.Visible = False
        '
        'TxtDt
        '
        Me.TxtDt.Location = New System.Drawing.Point(70, 107)
        Me.TxtDt.MaxLength = 7
        Me.TxtDt.Name = "TxtDt"
        Me.TxtDt.Size = New System.Drawing.Size(135, 20)
        Me.TxtDt.TabIndex = 34
        Me.TxtDt.Visible = False
        '
        'FrmPrefacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1100, 623)
        Me.Name = "FrmPrefacturacion"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
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
        Me.Panel.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        CType(Me.dgvGuiasEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuSeleccionGuias.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvGuiasFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvGuiasEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha2 As ControlsTepsa.DataPickerMasked
    Friend WithEvents Fecha1 As ControlsTepsa.DataPickerMasked
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNroPreFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoFinalPreFacturar As System.Windows.Forms.TextBox
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocialCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSumatoriaMonto As System.Windows.Forms.TextBox
    Friend WithEvents chkSoloPendientes As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbDestinos As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoClienteFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtNroPreFacturaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocialClienteFinal As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvGuiasFinal As System.Windows.Forms.DataGridView
    Friend WithEvents txtMontoPreFacturaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTipofacturacion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents MenuSeleccionGuias As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeleccionarHastaEstaPosicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestablecerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerSuma As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuitarTodoFiltroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents labnroregselecciona As System.Windows.Forms.Label
    Friend WithEvents Labreggrabar As System.Windows.Forms.Label
    Friend WithEvents LblDt As System.Windows.Forms.Label
    Friend WithEvents TxtDt As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NoPrefacturarGuíaDeEnvíoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
