<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacionVehiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramacionVehiculo))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripmenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreComisionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCProgramacionBuses = New System.Windows.Forms.TabControl()
        Me.TPListaBuses = New System.Windows.Forms.TabPage()
        Me.pnlListadoBuses = New System.Windows.Forms.Panel()
        Me.grpListadoBuses = New System.Windows.Forms.GroupBox()
        Me.dgdListadoBuses = New System.Windows.Forms.DataGridView()
        Me.pnlConsultaBuses = New System.Windows.Forms.Panel()
        Me.grpConsultaBuses = New System.Windows.Forms.GroupBox()
        Me.dtpFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaProgramada = New System.Windows.Forms.Label()
        Me.cboUnidadAgenciaOrigen = New System.Windows.Forms.ComboBox()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.TPGenerarSalidaBuses = New System.Windows.Forms.TabPage()
        Me.pnlRuta = New System.Windows.Forms.Panel()
        Me.grpProgramacion = New System.Windows.Forms.GroupBox()
        Me.pnlKilometro = New System.Windows.Forms.Panel()
        Me.lblDatoKilometro = New System.Windows.Forms.Label()
        Me.lblDatoMargen = New System.Windows.Forms.Label()
        Me.lblKilometro = New System.Windows.Forms.Label()
        Me.lblMargen = New System.Windows.Forms.Label()
        Me.pnlDetalleCiudades = New System.Windows.Forms.Panel()
        Me.dgdCiudades = New System.Windows.Forms.DataGridView()
        Me.pnlCiudad = New System.Windows.Forms.Panel()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cboCiudadOrigen = New System.Windows.Forms.ComboBox()
        Me.cboCiudadIntermedia = New System.Windows.Forms.ComboBox()
        Me.lblCiudadIntermedia = New System.Windows.Forms.Label()
        Me.lblCiudadOrigen = New System.Windows.Forms.Label()
        Me.cboCiudadDestino = New System.Windows.Forms.ComboBox()
        Me.lblCiudadDestino = New System.Windows.Forms.Label()
        Me.pnlDatosAdicionales = New System.Windows.Forms.Panel()
        Me.grpDatosAdicionales = New System.Windows.Forms.GroupBox()
        Me.txtLicenciaTercero = New System.Windows.Forms.TextBox()
        Me.txtPlacaTercero = New System.Windows.Forms.TextBox()
        Me.txtMarcaTercero = New System.Windows.Forms.TextBox()
        Me.txtEmpresaTercero = New System.Windows.Forms.TextBox()
        Me.txtRucTercero = New System.Windows.Forms.TextBox()
        Me.lblLicenciaTercero = New System.Windows.Forms.Label()
        Me.lblPlacaTercero = New System.Windows.Forms.Label()
        Me.lblMarcaTercero = New System.Windows.Forms.Label()
        Me.lblEmpresaTercero = New System.Windows.Forms.Label()
        Me.lblRucTercero = New System.Windows.Forms.Label()
        Me.pnlDatosGenerales = New System.Windows.Forms.Panel()
        Me.grpPiloto = New System.Windows.Forms.GroupBox()
        Me.lblDatoLicencia = New System.Windows.Forms.Label()
        Me.lblLicencia = New System.Windows.Forms.Label()
        Me.cboPiloto = New System.Windows.Forms.ComboBox()
        Me.lblPiloto = New System.Windows.Forms.Label()
        Me.grpRuta = New System.Windows.Forms.GroupBox()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.txtHoraSalida = New System.Windows.Forms.TextBox()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.dtpFechaLlegadaBus = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaSalidaBus = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaSalidaBus = New System.Windows.Forms.Label()
        Me.lblFechaLLegadaBus = New System.Windows.Forms.Label()
        Me.grpBus = New System.Windows.Forms.GroupBox()
        Me.lblDatoMarca = New System.Windows.Forms.Label()
        Me.lblDatoPlaca = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblPlaca = New System.Windows.Forms.Label()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.cboBus = New System.Windows.Forms.ComboBox()
        Me.lblBus = New System.Windows.Forms.Label()
        Me.CMSEstados = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_AperturaBodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_CierreBodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TCProgramacionBuses.SuspendLayout()
        Me.TPListaBuses.SuspendLayout()
        Me.pnlListadoBuses.SuspendLayout()
        Me.grpListadoBuses.SuspendLayout()
        CType(Me.dgdListadoBuses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsultaBuses.SuspendLayout()
        Me.grpConsultaBuses.SuspendLayout()
        Me.TPGenerarSalidaBuses.SuspendLayout()
        Me.pnlRuta.SuspendLayout()
        Me.grpProgramacion.SuspendLayout()
        Me.pnlKilometro.SuspendLayout()
        Me.pnlDetalleCiudades.SuspendLayout()
        CType(Me.dgdCiudades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCiudad.SuspendLayout()
        Me.pnlDatosAdicionales.SuspendLayout()
        Me.grpDatosAdicionales.SuspendLayout()
        Me.pnlDatosGenerales.SuspendLayout()
        Me.grpPiloto.SuspendLayout()
        Me.grpRuta.SuspendLayout()
        Me.grpBus.SuspendLayout()
        Me.CMSEstados.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1292, 38)
        Me.pnlTitulo.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1177, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(115, 38)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Image = CType(resources.GetObject("lblTitulo.Image"), System.Drawing.Image)
        Me.lblTitulo.Location = New System.Drawing.Point(31, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(372, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "LISTA DE BUSES PARA DESPACHO DE CARGA"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(1292, 38)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'pnlBarra
        '
        Me.pnlBarra.Controls.Add(Me.MenuStrip1)
        Me.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBarra.Location = New System.Drawing.Point(0, 38)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(1292, 37)
        Me.pnlBarra.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EdicionToolStripMenuItem, Me.GrabarToolStripMenuItem, Me.CancelarToolStripmenuItem, Me.ExportarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ConsultarToolStripMenuItem, Me.AnularToolStripMenuItem, Me.ReporteToolStripMenuItem, Me.CierreComisionesToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1292, 37)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = CType(resources.GetObject("NuevoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(78, 33)
        Me.NuevoToolStripMenuItem.Text = "&Nuevo"
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.Image = CType(resources.GetObject("EdicionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EdicionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(82, 33)
        Me.EdicionToolStripMenuItem.Text = "&Edicion"
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Image = CType(resources.GetObject("GrabarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GrabarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(78, 33)
        Me.GrabarToolStripMenuItem.Text = "&Grabar"
        '
        'CancelarToolStripmenuItem
        '
        Me.CancelarToolStripmenuItem.Image = CType(resources.GetObject("CancelarToolStripmenuItem.Image"), System.Drawing.Image)
        Me.CancelarToolStripmenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CancelarToolStripmenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CancelarToolStripmenuItem.Name = "CancelarToolStripmenuItem"
        Me.CancelarToolStripmenuItem.Size = New System.Drawing.Size(89, 33)
        Me.CancelarToolStripmenuItem.Text = "&Cancelar"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WordToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem, Me.EmailToolStripMenuItem})
        Me.ExportarToolStripMenuItem.Image = CType(resources.GetObject("ExportarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(86, 33)
        Me.ExportarToolStripMenuItem.Text = "E&xportar"
        '
        'WordToolStripMenuItem
        '
        Me.WordToolStripMenuItem.Image = CType(resources.GetObject("WordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WordToolStripMenuItem.Name = "WordToolStripMenuItem"
        Me.WordToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.WordToolStripMenuItem.Text = "Word"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = CType(resources.GetObject("ExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Image = CType(resources.GetObject("PDFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PDFToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'EmailToolStripMenuItem
        '
        Me.EmailToolStripMenuItem.Image = CType(resources.GetObject("EmailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EmailToolStripMenuItem.Name = "EmailToolStripMenuItem"
        Me.EmailToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.EmailToolStripMenuItem.Text = "Email"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = CType(resources.GetObject("ImprimirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(89, 33)
        Me.ImprimirToolStripMenuItem.Text = "Im&primir"
        '
        'ConsultarToolStripMenuItem
        '
        Me.ConsultarToolStripMenuItem.Image = CType(resources.GetObject("ConsultarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConsultarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConsultarToolStripMenuItem.Name = "ConsultarToolStripMenuItem"
        Me.ConsultarToolStripMenuItem.Size = New System.Drawing.Size(94, 33)
        Me.ConsultarToolStripMenuItem.Text = "Consultar"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = CType(resources.GetObject("AnularToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(78, 33)
        Me.AnularToolStripMenuItem.Text = "&Anular"
        '
        'ReporteToolStripMenuItem
        '
        Me.ReporteToolStripMenuItem.Image = CType(resources.GetObject("ReporteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReporteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ReporteToolStripMenuItem.Name = "ReporteToolStripMenuItem"
        Me.ReporteToolStripMenuItem.Size = New System.Drawing.Size(84, 33)
        Me.ReporteToolStripMenuItem.Text = "Reporte"
        '
        'CierreComisionesToolStripMenuItem
        '
        Me.CierreComisionesToolStripMenuItem.Image = CType(resources.GetObject("CierreComisionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CierreComisionesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CierreComisionesToolStripMenuItem.Name = "CierreComisionesToolStripMenuItem"
        Me.CierreComisionesToolStripMenuItem.Size = New System.Drawing.Size(139, 33)
        Me.CierreComisionesToolStripMenuItem.Text = "Cierre Comisiones"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Image = CType(resources.GetObject("AyudaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AyudaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(77, 33)
        Me.AyudaToolStripMenuItem.Text = "&Ayuda"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(65, 33)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'TCProgramacionBuses
        '
        Me.TCProgramacionBuses.Controls.Add(Me.TPListaBuses)
        Me.TCProgramacionBuses.Controls.Add(Me.TPGenerarSalidaBuses)
        Me.TCProgramacionBuses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCProgramacionBuses.Location = New System.Drawing.Point(0, 75)
        Me.TCProgramacionBuses.Name = "TCProgramacionBuses"
        Me.TCProgramacionBuses.SelectedIndex = 0
        Me.TCProgramacionBuses.Size = New System.Drawing.Size(1292, 610)
        Me.TCProgramacionBuses.TabIndex = 4
        '
        'TPListaBuses
        '
        Me.TPListaBuses.Controls.Add(Me.pnlListadoBuses)
        Me.TPListaBuses.Controls.Add(Me.pnlConsultaBuses)
        Me.TPListaBuses.Location = New System.Drawing.Point(4, 22)
        Me.TPListaBuses.Name = "TPListaBuses"
        Me.TPListaBuses.Padding = New System.Windows.Forms.Padding(3)
        Me.TPListaBuses.Size = New System.Drawing.Size(1284, 584)
        Me.TPListaBuses.TabIndex = 0
        Me.TPListaBuses.Text = "Listado de Buses Programados"
        Me.TPListaBuses.UseVisualStyleBackColor = True
        '
        'pnlListadoBuses
        '
        Me.pnlListadoBuses.Controls.Add(Me.grpListadoBuses)
        Me.pnlListadoBuses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListadoBuses.Location = New System.Drawing.Point(3, 73)
        Me.pnlListadoBuses.Name = "pnlListadoBuses"
        Me.pnlListadoBuses.Size = New System.Drawing.Size(1278, 508)
        Me.pnlListadoBuses.TabIndex = 1
        '
        'grpListadoBuses
        '
        Me.grpListadoBuses.Controls.Add(Me.dgdListadoBuses)
        Me.grpListadoBuses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpListadoBuses.Location = New System.Drawing.Point(0, 0)
        Me.grpListadoBuses.Name = "grpListadoBuses"
        Me.grpListadoBuses.Size = New System.Drawing.Size(1278, 508)
        Me.grpListadoBuses.TabIndex = 0
        Me.grpListadoBuses.TabStop = False
        Me.grpListadoBuses.Text = "Listado de Buses Programados"
        '
        'dgdListadoBuses
        '
        Me.dgdListadoBuses.AllowUserToAddRows = False
        Me.dgdListadoBuses.AllowUserToDeleteRows = False
        Me.dgdListadoBuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdListadoBuses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdListadoBuses.Location = New System.Drawing.Point(3, 16)
        Me.dgdListadoBuses.Name = "dgdListadoBuses"
        Me.dgdListadoBuses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdListadoBuses.Size = New System.Drawing.Size(1272, 489)
        Me.dgdListadoBuses.TabIndex = 0
        '
        'pnlConsultaBuses
        '
        Me.pnlConsultaBuses.Controls.Add(Me.grpConsultaBuses)
        Me.pnlConsultaBuses.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConsultaBuses.Location = New System.Drawing.Point(3, 3)
        Me.pnlConsultaBuses.Name = "pnlConsultaBuses"
        Me.pnlConsultaBuses.Size = New System.Drawing.Size(1278, 70)
        Me.pnlConsultaBuses.TabIndex = 0
        '
        'grpConsultaBuses
        '
        Me.grpConsultaBuses.Controls.Add(Me.dtpFechaSalida)
        Me.grpConsultaBuses.Controls.Add(Me.lblFechaProgramada)
        Me.grpConsultaBuses.Controls.Add(Me.cboUnidadAgenciaOrigen)
        Me.grpConsultaBuses.Controls.Add(Me.lblOrigen)
        Me.grpConsultaBuses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpConsultaBuses.Location = New System.Drawing.Point(0, 0)
        Me.grpConsultaBuses.Name = "grpConsultaBuses"
        Me.grpConsultaBuses.Size = New System.Drawing.Size(1278, 70)
        Me.grpConsultaBuses.TabIndex = 0
        Me.grpConsultaBuses.TabStop = False
        Me.grpConsultaBuses.Text = "Parametros de Consulta de Buses"
        '
        'dtpFechaSalida
        '
        Me.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSalida.Location = New System.Drawing.Point(538, 27)
        Me.dtpFechaSalida.Name = "dtpFechaSalida"
        Me.dtpFechaSalida.Size = New System.Drawing.Size(127, 20)
        Me.dtpFechaSalida.TabIndex = 3
        '
        'lblFechaProgramada
        '
        Me.lblFechaProgramada.AutoSize = True
        Me.lblFechaProgramada.Location = New System.Drawing.Point(444, 30)
        Me.lblFechaProgramada.Name = "lblFechaProgramada"
        Me.lblFechaProgramada.Size = New System.Drawing.Size(87, 13)
        Me.lblFechaProgramada.TabIndex = 2
        Me.lblFechaProgramada.Text = "Fecha de Salida:"
        '
        'cboUnidadAgenciaOrigen
        '
        Me.cboUnidadAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadAgenciaOrigen.FormattingEnabled = True
        Me.cboUnidadAgenciaOrigen.Location = New System.Drawing.Point(118, 26)
        Me.cboUnidadAgenciaOrigen.Name = "cboUnidadAgenciaOrigen"
        Me.cboUnidadAgenciaOrigen.Size = New System.Drawing.Size(274, 21)
        Me.cboUnidadAgenciaOrigen.TabIndex = 1
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Location = New System.Drawing.Point(25, 30)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(92, 13)
        Me.lblOrigen.TabIndex = 0
        Me.lblOrigen.Text = "Ciudad de Origen:"
        '
        'TPGenerarSalidaBuses
        '
        Me.TPGenerarSalidaBuses.Controls.Add(Me.pnlRuta)
        Me.TPGenerarSalidaBuses.Controls.Add(Me.pnlDatosAdicionales)
        Me.TPGenerarSalidaBuses.Controls.Add(Me.pnlDatosGenerales)
        Me.TPGenerarSalidaBuses.Location = New System.Drawing.Point(4, 22)
        Me.TPGenerarSalidaBuses.Name = "TPGenerarSalidaBuses"
        Me.TPGenerarSalidaBuses.Padding = New System.Windows.Forms.Padding(3)
        Me.TPGenerarSalidaBuses.Size = New System.Drawing.Size(1284, 584)
        Me.TPGenerarSalidaBuses.TabIndex = 1
        Me.TPGenerarSalidaBuses.Text = "Generación de Salida de Buses"
        Me.TPGenerarSalidaBuses.UseVisualStyleBackColor = True
        '
        'pnlRuta
        '
        Me.pnlRuta.Controls.Add(Me.grpProgramacion)
        Me.pnlRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRuta.Location = New System.Drawing.Point(3, 236)
        Me.pnlRuta.Name = "pnlRuta"
        Me.pnlRuta.Size = New System.Drawing.Size(1278, 345)
        Me.pnlRuta.TabIndex = 3
        '
        'grpProgramacion
        '
        Me.grpProgramacion.Controls.Add(Me.pnlKilometro)
        Me.grpProgramacion.Controls.Add(Me.pnlDetalleCiudades)
        Me.grpProgramacion.Controls.Add(Me.pnlCiudad)
        Me.grpProgramacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpProgramacion.Location = New System.Drawing.Point(0, 0)
        Me.grpProgramacion.Name = "grpProgramacion"
        Me.grpProgramacion.Size = New System.Drawing.Size(1278, 345)
        Me.grpProgramacion.TabIndex = 0
        Me.grpProgramacion.TabStop = False
        Me.grpProgramacion.Text = "Destino y Ciudades Intemedias de la Ruta del Bus"
        '
        'pnlKilometro
        '
        Me.pnlKilometro.Controls.Add(Me.lblDatoKilometro)
        Me.pnlKilometro.Controls.Add(Me.lblDatoMargen)
        Me.pnlKilometro.Controls.Add(Me.lblKilometro)
        Me.pnlKilometro.Controls.Add(Me.lblMargen)
        Me.pnlKilometro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlKilometro.Location = New System.Drawing.Point(1143, 16)
        Me.pnlKilometro.Name = "pnlKilometro"
        Me.pnlKilometro.Size = New System.Drawing.Size(132, 326)
        Me.pnlKilometro.TabIndex = 24
        '
        'lblDatoKilometro
        '
        Me.lblDatoKilometro.AutoSize = True
        Me.lblDatoKilometro.Location = New System.Drawing.Point(114, 59)
        Me.lblDatoKilometro.Name = "lblDatoKilometro"
        Me.lblDatoKilometro.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoKilometro.TabIndex = 3
        Me.lblDatoKilometro.Text = "0.00"
        '
        'lblDatoMargen
        '
        Me.lblDatoMargen.AutoSize = True
        Me.lblDatoMargen.Location = New System.Drawing.Point(84, 29)
        Me.lblDatoMargen.Name = "lblDatoMargen"
        Me.lblDatoMargen.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoMargen.TabIndex = 2
        Me.lblDatoMargen.Text = "0.00"
        '
        'lblKilometro
        '
        Me.lblKilometro.AutoSize = True
        Me.lblKilometro.Location = New System.Drawing.Point(18, 59)
        Me.lblKilometro.Name = "lblKilometro"
        Me.lblKilometro.Size = New System.Drawing.Size(90, 13)
        Me.lblKilometro.TabIndex = 1
        Me.lblKilometro.Text = "Recorrido ( kms ):"
        '
        'lblMargen
        '
        Me.lblMargen.AutoSize = True
        Me.lblMargen.Location = New System.Drawing.Point(18, 29)
        Me.lblMargen.Name = "lblMargen"
        Me.lblMargen.Size = New System.Drawing.Size(46, 13)
        Me.lblMargen.TabIndex = 0
        Me.lblMargen.Text = "Margen:"
        '
        'pnlDetalleCiudades
        '
        Me.pnlDetalleCiudades.Controls.Add(Me.dgdCiudades)
        Me.pnlDetalleCiudades.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDetalleCiudades.Location = New System.Drawing.Point(315, 16)
        Me.pnlDetalleCiudades.Name = "pnlDetalleCiudades"
        Me.pnlDetalleCiudades.Size = New System.Drawing.Size(828, 326)
        Me.pnlDetalleCiudades.TabIndex = 23
        '
        'dgdCiudades
        '
        Me.dgdCiudades.AllowUserToAddRows = False
        Me.dgdCiudades.AllowUserToDeleteRows = False
        Me.dgdCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCiudades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdCiudades.Location = New System.Drawing.Point(0, 0)
        Me.dgdCiudades.Name = "dgdCiudades"
        Me.dgdCiudades.Size = New System.Drawing.Size(828, 326)
        Me.dgdCiudades.TabIndex = 0
        '
        'pnlCiudad
        '
        Me.pnlCiudad.Controls.Add(Me.btnQuitar)
        Me.pnlCiudad.Controls.Add(Me.btnAgregar)
        Me.pnlCiudad.Controls.Add(Me.cboCiudadOrigen)
        Me.pnlCiudad.Controls.Add(Me.cboCiudadIntermedia)
        Me.pnlCiudad.Controls.Add(Me.lblCiudadIntermedia)
        Me.pnlCiudad.Controls.Add(Me.lblCiudadOrigen)
        Me.pnlCiudad.Controls.Add(Me.cboCiudadDestino)
        Me.pnlCiudad.Controls.Add(Me.lblCiudadDestino)
        Me.pnlCiudad.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCiudad.Location = New System.Drawing.Point(3, 16)
        Me.pnlCiudad.Name = "pnlCiudad"
        Me.pnlCiudad.Size = New System.Drawing.Size(312, 326)
        Me.pnlCiudad.TabIndex = 22
        '
        'btnQuitar
        '
        Me.btnQuitar.Location = New System.Drawing.Point(161, 147)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(122, 23)
        Me.btnQuitar.TabIndex = 22
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(23, 147)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(122, 23)
        Me.btnAgregar.TabIndex = 21
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'cboCiudadOrigen
        '
        Me.cboCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudadOrigen.Enabled = False
        Me.cboCiudadOrigen.FormattingEnabled = True
        Me.cboCiudadOrigen.Location = New System.Drawing.Point(119, 27)
        Me.cboCiudadOrigen.Name = "cboCiudadOrigen"
        Me.cboCiudadOrigen.Size = New System.Drawing.Size(164, 21)
        Me.cboCiudadOrigen.TabIndex = 17
        '
        'cboCiudadIntermedia
        '
        Me.cboCiudadIntermedia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudadIntermedia.FormattingEnabled = True
        Me.cboCiudadIntermedia.Location = New System.Drawing.Point(119, 87)
        Me.cboCiudadIntermedia.Name = "cboCiudadIntermedia"
        Me.cboCiudadIntermedia.Size = New System.Drawing.Size(164, 21)
        Me.cboCiudadIntermedia.TabIndex = 20
        '
        'lblCiudadIntermedia
        '
        Me.lblCiudadIntermedia.AutoSize = True
        Me.lblCiudadIntermedia.Location = New System.Drawing.Point(21, 89)
        Me.lblCiudadIntermedia.Name = "lblCiudadIntermedia"
        Me.lblCiudadIntermedia.Size = New System.Drawing.Size(92, 13)
        Me.lblCiudadIntermedia.TabIndex = 19
        Me.lblCiudadIntermedia.Text = "Ciudad Intermedia"
        '
        'lblCiudadOrigen
        '
        Me.lblCiudadOrigen.AutoSize = True
        Me.lblCiudadOrigen.Location = New System.Drawing.Point(21, 29)
        Me.lblCiudadOrigen.Name = "lblCiudadOrigen"
        Me.lblCiudadOrigen.Size = New System.Drawing.Size(74, 13)
        Me.lblCiudadOrigen.TabIndex = 15
        Me.lblCiudadOrigen.Text = "Ciudad Origen"
        '
        'cboCiudadDestino
        '
        Me.cboCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudadDestino.Enabled = False
        Me.cboCiudadDestino.FormattingEnabled = True
        Me.cboCiudadDestino.Location = New System.Drawing.Point(119, 57)
        Me.cboCiudadDestino.Name = "cboCiudadDestino"
        Me.cboCiudadDestino.Size = New System.Drawing.Size(164, 21)
        Me.cboCiudadDestino.TabIndex = 18
        '
        'lblCiudadDestino
        '
        Me.lblCiudadDestino.AutoSize = True
        Me.lblCiudadDestino.Location = New System.Drawing.Point(21, 59)
        Me.lblCiudadDestino.Name = "lblCiudadDestino"
        Me.lblCiudadDestino.Size = New System.Drawing.Size(79, 13)
        Me.lblCiudadDestino.TabIndex = 16
        Me.lblCiudadDestino.Text = "Ciudad Destino"
        '
        'pnlDatosAdicionales
        '
        Me.pnlDatosAdicionales.Controls.Add(Me.grpDatosAdicionales)
        Me.pnlDatosAdicionales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosAdicionales.Location = New System.Drawing.Point(3, 156)
        Me.pnlDatosAdicionales.Name = "pnlDatosAdicionales"
        Me.pnlDatosAdicionales.Size = New System.Drawing.Size(1278, 80)
        Me.pnlDatosAdicionales.TabIndex = 2
        '
        'grpDatosAdicionales
        '
        Me.grpDatosAdicionales.Controls.Add(Me.txtLicenciaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.txtPlacaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.txtMarcaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.txtEmpresaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.txtRucTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.lblLicenciaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.lblPlacaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.lblMarcaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.lblEmpresaTercero)
        Me.grpDatosAdicionales.Controls.Add(Me.lblRucTercero)
        Me.grpDatosAdicionales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDatosAdicionales.Location = New System.Drawing.Point(0, 0)
        Me.grpDatosAdicionales.Name = "grpDatosAdicionales"
        Me.grpDatosAdicionales.Size = New System.Drawing.Size(1278, 80)
        Me.grpDatosAdicionales.TabIndex = 0
        Me.grpDatosAdicionales.TabStop = False
        Me.grpDatosAdicionales.Text = "Datos de Tercero y Chofer"
        '
        'txtLicenciaTercero
        '
        Me.txtLicenciaTercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLicenciaTercero.Enabled = False
        Me.txtLicenciaTercero.Location = New System.Drawing.Point(1131, 27)
        Me.txtLicenciaTercero.Name = "txtLicenciaTercero"
        Me.txtLicenciaTercero.Size = New System.Drawing.Size(124, 20)
        Me.txtLicenciaTercero.TabIndex = 10
        '
        'txtPlacaTercero
        '
        Me.txtPlacaTercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlacaTercero.Enabled = False
        Me.txtPlacaTercero.Location = New System.Drawing.Point(895, 27)
        Me.txtPlacaTercero.Name = "txtPlacaTercero"
        Me.txtPlacaTercero.Size = New System.Drawing.Size(135, 20)
        Me.txtPlacaTercero.TabIndex = 9
        '
        'txtMarcaTercero
        '
        Me.txtMarcaTercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarcaTercero.Enabled = False
        Me.txtMarcaTercero.Location = New System.Drawing.Point(670, 27)
        Me.txtMarcaTercero.Name = "txtMarcaTercero"
        Me.txtMarcaTercero.Size = New System.Drawing.Size(135, 20)
        Me.txtMarcaTercero.TabIndex = 8
        '
        'txtEmpresaTercero
        '
        Me.txtEmpresaTercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpresaTercero.Enabled = False
        Me.txtEmpresaTercero.Location = New System.Drawing.Point(274, 27)
        Me.txtEmpresaTercero.Name = "txtEmpresaTercero"
        Me.txtEmpresaTercero.Size = New System.Drawing.Size(307, 20)
        Me.txtEmpresaTercero.TabIndex = 7
        '
        'txtRucTercero
        '
        Me.txtRucTercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRucTercero.Enabled = False
        Me.txtRucTercero.Location = New System.Drawing.Point(89, 27)
        Me.txtRucTercero.Name = "txtRucTercero"
        Me.txtRucTercero.Size = New System.Drawing.Size(83, 20)
        Me.txtRucTercero.TabIndex = 6
        '
        'lblLicenciaTercero
        '
        Me.lblLicenciaTercero.AutoSize = True
        Me.lblLicenciaTercero.Location = New System.Drawing.Point(1042, 30)
        Me.lblLicenciaTercero.Name = "lblLicenciaTercero"
        Me.lblLicenciaTercero.Size = New System.Drawing.Size(87, 13)
        Me.lblLicenciaTercero.TabIndex = 5
        Me.lblLicenciaTercero.Text = "Licencia Tercero"
        '
        'lblPlacaTercero
        '
        Me.lblPlacaTercero.AutoSize = True
        Me.lblPlacaTercero.Location = New System.Drawing.Point(820, 30)
        Me.lblPlacaTercero.Name = "lblPlacaTercero"
        Me.lblPlacaTercero.Size = New System.Drawing.Size(74, 13)
        Me.lblPlacaTercero.TabIndex = 4
        Me.lblPlacaTercero.Text = "Placa Tercero"
        '
        'lblMarcaTercero
        '
        Me.lblMarcaTercero.AutoSize = True
        Me.lblMarcaTercero.Location = New System.Drawing.Point(591, 30)
        Me.lblMarcaTercero.Name = "lblMarcaTercero"
        Me.lblMarcaTercero.Size = New System.Drawing.Size(77, 13)
        Me.lblMarcaTercero.TabIndex = 3
        Me.lblMarcaTercero.Text = "Marca Tercero"
        '
        'lblEmpresaTercero
        '
        Me.lblEmpresaTercero.AutoSize = True
        Me.lblEmpresaTercero.Location = New System.Drawing.Point(185, 30)
        Me.lblEmpresaTercero.Name = "lblEmpresaTercero"
        Me.lblEmpresaTercero.Size = New System.Drawing.Size(88, 13)
        Me.lblEmpresaTercero.TabIndex = 2
        Me.lblEmpresaTercero.Text = "Empresa Tercero"
        '
        'lblRucTercero
        '
        Me.lblRucTercero.AutoSize = True
        Me.lblRucTercero.Location = New System.Drawing.Point(21, 30)
        Me.lblRucTercero.Name = "lblRucTercero"
        Me.lblRucTercero.Size = New System.Drawing.Size(67, 13)
        Me.lblRucTercero.TabIndex = 1
        Me.lblRucTercero.Text = "Ruc Tercero"
        '
        'pnlDatosGenerales
        '
        Me.pnlDatosGenerales.Controls.Add(Me.grpPiloto)
        Me.pnlDatosGenerales.Controls.Add(Me.grpRuta)
        Me.pnlDatosGenerales.Controls.Add(Me.grpBus)
        Me.pnlDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosGenerales.Location = New System.Drawing.Point(3, 3)
        Me.pnlDatosGenerales.Name = "pnlDatosGenerales"
        Me.pnlDatosGenerales.Size = New System.Drawing.Size(1278, 153)
        Me.pnlDatosGenerales.TabIndex = 1
        '
        'grpPiloto
        '
        Me.grpPiloto.Controls.Add(Me.lblDatoLicencia)
        Me.grpPiloto.Controls.Add(Me.lblLicencia)
        Me.grpPiloto.Controls.Add(Me.cboPiloto)
        Me.grpPiloto.Controls.Add(Me.lblPiloto)
        Me.grpPiloto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPiloto.Location = New System.Drawing.Point(850, 0)
        Me.grpPiloto.Name = "grpPiloto"
        Me.grpPiloto.Size = New System.Drawing.Size(428, 153)
        Me.grpPiloto.TabIndex = 2
        Me.grpPiloto.TabStop = False
        Me.grpPiloto.Text = "Piloto del Bus"
        '
        'lblDatoLicencia
        '
        Me.lblDatoLicencia.AutoSize = True
        Me.lblDatoLicencia.Location = New System.Drawing.Point(59, 58)
        Me.lblDatoLicencia.Name = "lblDatoLicencia"
        Me.lblDatoLicencia.Size = New System.Drawing.Size(80, 13)
        Me.lblDatoLicencia.TabIndex = 25
        Me.lblDatoLicencia.Text = "lblDatoLicencia"
        '
        'lblLicencia
        '
        Me.lblLicencia.AutoSize = True
        Me.lblLicencia.Location = New System.Drawing.Point(10, 58)
        Me.lblLicencia.Name = "lblLicencia"
        Me.lblLicencia.Size = New System.Drawing.Size(47, 13)
        Me.lblLicencia.TabIndex = 24
        Me.lblLicencia.Text = "Licencia"
        '
        'cboPiloto
        '
        Me.cboPiloto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPiloto.FormattingEnabled = True
        Me.cboPiloto.Location = New System.Drawing.Point(58, 25)
        Me.cboPiloto.Name = "cboPiloto"
        Me.cboPiloto.Size = New System.Drawing.Size(347, 21)
        Me.cboPiloto.TabIndex = 23
        '
        'lblPiloto
        '
        Me.lblPiloto.AutoSize = True
        Me.lblPiloto.Location = New System.Drawing.Point(10, 28)
        Me.lblPiloto.Name = "lblPiloto"
        Me.lblPiloto.Size = New System.Drawing.Size(33, 13)
        Me.lblPiloto.TabIndex = 22
        Me.lblPiloto.Text = "Piloto"
        '
        'grpRuta
        '
        Me.grpRuta.Controls.Add(Me.cboRuta)
        Me.grpRuta.Controls.Add(Me.lblRuta)
        Me.grpRuta.Controls.Add(Me.txtHoraSalida)
        Me.grpRuta.Controls.Add(Me.lblHora)
        Me.grpRuta.Controls.Add(Me.dtpFechaLlegadaBus)
        Me.grpRuta.Controls.Add(Me.dtpFechaSalidaBus)
        Me.grpRuta.Controls.Add(Me.lblFechaSalidaBus)
        Me.grpRuta.Controls.Add(Me.lblFechaLLegadaBus)
        Me.grpRuta.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpRuta.Location = New System.Drawing.Point(425, 0)
        Me.grpRuta.Name = "grpRuta"
        Me.grpRuta.Size = New System.Drawing.Size(425, 153)
        Me.grpRuta.TabIndex = 1
        Me.grpRuta.TabStop = False
        Me.grpRuta.Text = "Ruta del Bus"
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.FormattingEnabled = True
        Me.cboRuta.Location = New System.Drawing.Point(131, 25)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(187, 21)
        Me.cboRuta.TabIndex = 19
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(26, 28)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(30, 13)
        Me.lblRuta.TabIndex = 18
        Me.lblRuta.Text = "Ruta"
        '
        'txtHoraSalida
        '
        Me.txtHoraSalida.Location = New System.Drawing.Point(131, 114)
        Me.txtHoraSalida.MaxLength = 10
        Me.txtHoraSalida.Name = "txtHoraSalida"
        Me.txtHoraSalida.Size = New System.Drawing.Size(81, 20)
        Me.txtHoraSalida.TabIndex = 17
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Location = New System.Drawing.Point(26, 118)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(30, 13)
        Me.lblHora.TabIndex = 16
        Me.lblHora.Text = "Hora"
        '
        'dtpFechaLlegadaBus
        '
        Me.dtpFechaLlegadaBus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaLlegadaBus.Location = New System.Drawing.Point(131, 85)
        Me.dtpFechaLlegadaBus.Name = "dtpFechaLlegadaBus"
        Me.dtpFechaLlegadaBus.Size = New System.Drawing.Size(187, 20)
        Me.dtpFechaLlegadaBus.TabIndex = 11
        '
        'dtpFechaSalidaBus
        '
        Me.dtpFechaSalidaBus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSalidaBus.Location = New System.Drawing.Point(131, 55)
        Me.dtpFechaSalidaBus.Name = "dtpFechaSalidaBus"
        Me.dtpFechaSalidaBus.Size = New System.Drawing.Size(187, 20)
        Me.dtpFechaSalidaBus.TabIndex = 10
        '
        'lblFechaSalidaBus
        '
        Me.lblFechaSalidaBus.AutoSize = True
        Me.lblFechaSalidaBus.Location = New System.Drawing.Point(26, 58)
        Me.lblFechaSalidaBus.Name = "lblFechaSalidaBus"
        Me.lblFechaSalidaBus.Size = New System.Drawing.Size(84, 13)
        Me.lblFechaSalidaBus.TabIndex = 8
        Me.lblFechaSalidaBus.Text = "Fecha de Salida"
        '
        'lblFechaLLegadaBus
        '
        Me.lblFechaLLegadaBus.AutoSize = True
        Me.lblFechaLLegadaBus.Location = New System.Drawing.Point(26, 88)
        Me.lblFechaLLegadaBus.Name = "lblFechaLLegadaBus"
        Me.lblFechaLLegadaBus.Size = New System.Drawing.Size(93, 13)
        Me.lblFechaLLegadaBus.TabIndex = 9
        Me.lblFechaLLegadaBus.Text = "Fecha de Llegada"
        '
        'grpBus
        '
        Me.grpBus.Controls.Add(Me.lblDatoMarca)
        Me.grpBus.Controls.Add(Me.lblDatoPlaca)
        Me.grpBus.Controls.Add(Me.lblMarca)
        Me.grpBus.Controls.Add(Me.lblPlaca)
        Me.grpBus.Controls.Add(Me.cboServicio)
        Me.grpBus.Controls.Add(Me.lblServicio)
        Me.grpBus.Controls.Add(Me.cboBus)
        Me.grpBus.Controls.Add(Me.lblBus)
        Me.grpBus.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpBus.Location = New System.Drawing.Point(0, 0)
        Me.grpBus.Name = "grpBus"
        Me.grpBus.Size = New System.Drawing.Size(425, 153)
        Me.grpBus.TabIndex = 0
        Me.grpBus.TabStop = False
        Me.grpBus.Text = "Bus"
        '
        'lblDatoMarca
        '
        Me.lblDatoMarca.AutoSize = True
        Me.lblDatoMarca.Location = New System.Drawing.Point(73, 88)
        Me.lblDatoMarca.Name = "lblDatoMarca"
        Me.lblDatoMarca.Size = New System.Drawing.Size(70, 13)
        Me.lblDatoMarca.TabIndex = 20
        Me.lblDatoMarca.Text = "lblDatoMarca"
        '
        'lblDatoPlaca
        '
        Me.lblDatoPlaca.AutoSize = True
        Me.lblDatoPlaca.Location = New System.Drawing.Point(73, 118)
        Me.lblDatoPlaca.Name = "lblDatoPlaca"
        Me.lblDatoPlaca.Size = New System.Drawing.Size(67, 13)
        Me.lblDatoPlaca.TabIndex = 19
        Me.lblDatoPlaca.Text = "lblDatoPlaca"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(21, 88)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 18
        Me.lblMarca.Text = "Marca"
        '
        'lblPlaca
        '
        Me.lblPlaca.AutoSize = True
        Me.lblPlaca.Location = New System.Drawing.Point(21, 118)
        Me.lblPlaca.Name = "lblPlaca"
        Me.lblPlaca.Size = New System.Drawing.Size(34, 13)
        Me.lblPlaca.TabIndex = 16
        Me.lblPlaca.Text = "Placa"
        '
        'cboServicio
        '
        Me.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicio.Enabled = False
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(76, 55)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(195, 21)
        Me.cboServicio.TabIndex = 3
        '
        'lblServicio
        '
        Me.lblServicio.AutoSize = True
        Me.lblServicio.Location = New System.Drawing.Point(21, 58)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(45, 13)
        Me.lblServicio.TabIndex = 2
        Me.lblServicio.Text = "Servicio"
        '
        'cboBus
        '
        Me.cboBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBus.FormattingEnabled = True
        Me.cboBus.Location = New System.Drawing.Point(76, 25)
        Me.cboBus.Name = "cboBus"
        Me.cboBus.Size = New System.Drawing.Size(195, 21)
        Me.cboBus.TabIndex = 1
        '
        'lblBus
        '
        Me.lblBus.AutoSize = True
        Me.lblBus.Location = New System.Drawing.Point(21, 28)
        Me.lblBus.Name = "lblBus"
        Me.lblBus.Size = New System.Drawing.Size(36, 13)
        Me.lblBus.TabIndex = 0
        Me.lblBus.Text = "Buses"
        '
        'CMSEstados
        '
        Me.CMSEstados.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_AperturaBodega, Me.TSMI_CierreBodega})
        Me.CMSEstados.Name = "CMSEstados"
        Me.CMSEstados.Size = New System.Drawing.Size(164, 70)
        '
        'TSMI_AperturaBodega
        '
        Me.TSMI_AperturaBodega.Name = "TSMI_AperturaBodega"
        Me.TSMI_AperturaBodega.Size = New System.Drawing.Size(163, 22)
        Me.TSMI_AperturaBodega.Text = "Apertura Bodega"
        '
        'TSMI_CierreBodega
        '
        Me.TSMI_CierreBodega.Name = "TSMI_CierreBodega"
        Me.TSMI_CierreBodega.Size = New System.Drawing.Size(163, 22)
        Me.TSMI_CierreBodega.Text = "Cierre Bodega"
        '
        'frmProgramacionVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1292, 685)
        Me.Controls.Add(Me.TCProgramacionBuses)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "frmProgramacionVehiculo"
        Me.Text = "frmProgramacionVehiculo"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnlBarra.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TCProgramacionBuses.ResumeLayout(False)
        Me.TPListaBuses.ResumeLayout(False)
        Me.pnlListadoBuses.ResumeLayout(False)
        Me.grpListadoBuses.ResumeLayout(False)
        CType(Me.dgdListadoBuses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsultaBuses.ResumeLayout(False)
        Me.grpConsultaBuses.ResumeLayout(False)
        Me.grpConsultaBuses.PerformLayout()
        Me.TPGenerarSalidaBuses.ResumeLayout(False)
        Me.pnlRuta.ResumeLayout(False)
        Me.grpProgramacion.ResumeLayout(False)
        Me.pnlKilometro.ResumeLayout(False)
        Me.pnlKilometro.PerformLayout()
        Me.pnlDetalleCiudades.ResumeLayout(False)
        CType(Me.dgdCiudades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCiudad.ResumeLayout(False)
        Me.pnlCiudad.PerformLayout()
        Me.pnlDatosAdicionales.ResumeLayout(False)
        Me.grpDatosAdicionales.ResumeLayout(False)
        Me.grpDatosAdicionales.PerformLayout()
        Me.pnlDatosGenerales.ResumeLayout(False)
        Me.grpPiloto.ResumeLayout(False)
        Me.grpPiloto.PerformLayout()
        Me.grpRuta.ResumeLayout(False)
        Me.grpRuta.PerformLayout()
        Me.grpBus.ResumeLayout(False)
        Me.grpBus.PerformLayout()
        Me.CMSEstados.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Protected WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Protected WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripmenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CierreComisionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TCProgramacionBuses As System.Windows.Forms.TabControl
    Friend WithEvents TPListaBuses As System.Windows.Forms.TabPage
    Friend WithEvents TPGenerarSalidaBuses As System.Windows.Forms.TabPage
    Friend WithEvents pnlConsultaBuses As System.Windows.Forms.Panel
    Friend WithEvents grpConsultaBuses As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaProgramada As System.Windows.Forms.Label
    Friend WithEvents cboUnidadAgenciaOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents dtpFechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlListadoBuses As System.Windows.Forms.Panel
    Friend WithEvents grpListadoBuses As System.Windows.Forms.GroupBox
    Friend WithEvents dgdListadoBuses As System.Windows.Forms.DataGridView
    Friend WithEvents pnlDatosGenerales As System.Windows.Forms.Panel
    Friend WithEvents grpBus As System.Windows.Forms.GroupBox
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents cboBus As System.Windows.Forms.ComboBox
    Friend WithEvents lblBus As System.Windows.Forms.Label
    Friend WithEvents lblFechaSalidaBus As System.Windows.Forms.Label
    Friend WithEvents lblFechaLLegadaBus As System.Windows.Forms.Label
    Friend WithEvents dtpFechaLlegadaBus As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaSalidaBus As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlDatosAdicionales As System.Windows.Forms.Panel
    Friend WithEvents grpDatosAdicionales As System.Windows.Forms.GroupBox
    Friend WithEvents pnlRuta As System.Windows.Forms.Panel
    Friend WithEvents grpProgramacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblPlaca As System.Windows.Forms.Label
    Friend WithEvents lblDatoMarca As System.Windows.Forms.Label
    Friend WithEvents lblDatoPlaca As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents grpRuta As System.Windows.Forms.GroupBox
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents txtHoraSalida As System.Windows.Forms.TextBox
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents grpPiloto As System.Windows.Forms.GroupBox
    Friend WithEvents cboPiloto As System.Windows.Forms.ComboBox
    Friend WithEvents lblPiloto As System.Windows.Forms.Label
    Friend WithEvents lblLicencia As System.Windows.Forms.Label
    Friend WithEvents lblDatoLicencia As System.Windows.Forms.Label
    Friend WithEvents pnlKilometro As System.Windows.Forms.Panel
    Friend WithEvents lblKilometro As System.Windows.Forms.Label
    Friend WithEvents lblMargen As System.Windows.Forms.Label
    Friend WithEvents pnlDetalleCiudades As System.Windows.Forms.Panel
    Friend WithEvents dgdCiudades As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCiudad As System.Windows.Forms.Panel
    Friend WithEvents cboCiudadOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents cboCiudadIntermedia As System.Windows.Forms.ComboBox
    Friend WithEvents lblCiudadIntermedia As System.Windows.Forms.Label
    Friend WithEvents lblCiudadOrigen As System.Windows.Forms.Label
    Friend WithEvents cboCiudadDestino As System.Windows.Forms.ComboBox
    Friend WithEvents lblCiudadDestino As System.Windows.Forms.Label
    Friend WithEvents lblRucTercero As System.Windows.Forms.Label
    Friend WithEvents lblEmpresaTercero As System.Windows.Forms.Label
    Friend WithEvents lblLicenciaTercero As System.Windows.Forms.Label
    Friend WithEvents lblPlacaTercero As System.Windows.Forms.Label
    Friend WithEvents lblMarcaTercero As System.Windows.Forms.Label
    Friend WithEvents txtLicenciaTercero As System.Windows.Forms.TextBox
    Friend WithEvents txtPlacaTercero As System.Windows.Forms.TextBox
    Friend WithEvents txtMarcaTercero As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresaTercero As System.Windows.Forms.TextBox
    Friend WithEvents txtRucTercero As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblDatoKilometro As System.Windows.Forms.Label
    Friend WithEvents lblDatoMargen As System.Windows.Forms.Label
    Friend WithEvents CMSEstados As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_AperturaBodega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_CierreBodega As System.Windows.Forms.ToolStripMenuItem
End Class
