<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturacionEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturacionEspecial))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripmenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCFacturacionEspecial = New System.Windows.Forms.TabControl()
        Me.TPGuias = New System.Windows.Forms.TabPage()
        Me.grpResumen = New System.Windows.Forms.GroupBox()
        Me.lblIGV = New System.Windows.Forms.Label()
        Me.lblTotalGuias = New System.Windows.Forms.Label()
        Me.lblMontoTotal = New System.Windows.Forms.Label()
        Me.lblSubTotalGuias = New System.Windows.Forms.Label()
        Me.lblMontoIgv = New System.Windows.Forms.Label()
        Me.lblMontoSubTotal = New System.Windows.Forms.Label()
        Me.grpLeyenda = New System.Windows.Forms.GroupBox()
        Me.lblPrecioReal = New System.Windows.Forms.Label()
        Me.lblDatoCalulado = New System.Windows.Forms.Label()
        Me.lblDatoReal = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.pctDatoOriginal = New System.Windows.Forms.PictureBox()
        Me.grpDetalle = New System.Windows.Forms.GroupBox()
        Me.dgvGuias = New System.Windows.Forms.DataGridView()
        Me.grpFiltros = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionTodos = New System.Windows.Forms.CheckBox()
        Me.cboRazonSocial = New System.Windows.Forms.ComboBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.TPFactura = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lblTotalFactura = New System.Windows.Forms.Label()
        Me.lblIgvFactura = New System.Windows.Forms.Label()
        Me.lblSubTotalFactura = New System.Windows.Forms.Label()
        Me.lblTotalFac = New System.Windows.Forms.Label()
        Me.lblIGVFac = New System.Windows.Forms.Label()
        Me.lblSubtotalFac = New System.Windows.Forms.Label()
        Me.grpDetallefactura = New System.Windows.Forms.GroupBox()
        Me.dgvDetalleFactura = New System.Windows.Forms.DataGridView()
        Me.grpCabecera = New System.Windows.Forms.GroupBox()
        Me.cboDireccion = New System.Windows.Forms.ComboBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.lblFechaVencimiento = New System.Windows.Forms.Label()
        Me.dtFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFactura = New System.Windows.Forms.Label()
        Me.dtFechaFactura = New System.Windows.Forms.DateTimePicker()
        Me.lblClienteFactura = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblSerieNumeroDV = New System.Windows.Forms.Label()
        Me.lblFormaPago = New System.Windows.Forms.Label()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.lblDatoFormaPago = New System.Windows.Forms.Label()
        Me.TPConsulta = New System.Windows.Forms.TabPage()
        Me.grpEstadistica = New System.Windows.Forms.GroupBox()
        Me.grpGuiaFacturada = New System.Windows.Forms.GroupBox()
        Me.dgvGuiaFacturada = New System.Windows.Forms.DataGridView()
        Me.grpConsultaFactura = New System.Windows.Forms.GroupBox()
        Me.dgvFacturaEmitida = New System.Windows.Forms.DataGridView()
        Me.grpFiltro = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.lblRangoFecha = New System.Windows.Forms.Label()
        Me.dtFacturaFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtFacturaFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TCFacturacionEspecial.SuspendLayout()
        Me.TPGuias.SuspendLayout()
        Me.grpResumen.SuspendLayout()
        Me.grpLeyenda.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctDatoOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetalle.SuspendLayout()
        CType(Me.dgvGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltros.SuspendLayout()
        Me.TPFactura.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetallefactura.SuspendLayout()
        CType(Me.dgvDetalleFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCabecera.SuspendLayout()
        Me.TPConsulta.SuspendLayout()
        Me.grpGuiaFacturada.SuspendLayout()
        CType(Me.dgvGuiaFacturada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpConsultaFactura.SuspendLayout()
        CType(Me.dgvFacturaEmitida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltro.SuspendLayout()
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
        Me.pnlTitulo.Size = New System.Drawing.Size(845, 38)
        Me.pnlTitulo.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(730, 0)
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
        Me.lblTitulo.Size = New System.Drawing.Size(207, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "FACTURACION ESPECIAL"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(845, 38)
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
        Me.pnlBarra.Size = New System.Drawing.Size(845, 37)
        Me.pnlBarra.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EdicionToolStripMenuItem, Me.CancelarToolStripmenuItem, Me.GrabarToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(845, 37)
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
        'CancelarToolStripmenuItem
        '
        Me.CancelarToolStripmenuItem.Image = CType(resources.GetObject("CancelarToolStripmenuItem.Image"), System.Drawing.Image)
        Me.CancelarToolStripmenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CancelarToolStripmenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CancelarToolStripmenuItem.Name = "CancelarToolStripmenuItem"
        Me.CancelarToolStripmenuItem.Size = New System.Drawing.Size(89, 33)
        Me.CancelarToolStripmenuItem.Text = "&Cancelar"
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Image = CType(resources.GetObject("GrabarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GrabarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(78, 33)
        Me.GrabarToolStripMenuItem.Text = "&Grabar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Image = CType(resources.GetObject("EliminarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EliminarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(86, 33)
        Me.EliminarToolStripMenuItem.Text = "E&liminar"
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
        'TCFacturacionEspecial
        '
        Me.TCFacturacionEspecial.Controls.Add(Me.TPGuias)
        Me.TCFacturacionEspecial.Controls.Add(Me.TPFactura)
        Me.TCFacturacionEspecial.Controls.Add(Me.TPConsulta)
        Me.TCFacturacionEspecial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCFacturacionEspecial.Location = New System.Drawing.Point(0, 75)
        Me.TCFacturacionEspecial.Name = "TCFacturacionEspecial"
        Me.TCFacturacionEspecial.SelectedIndex = 0
        Me.TCFacturacionEspecial.Size = New System.Drawing.Size(845, 586)
        Me.TCFacturacionEspecial.TabIndex = 2
        '
        'TPGuias
        '
        Me.TPGuias.Controls.Add(Me.grpResumen)
        Me.TPGuias.Controls.Add(Me.grpLeyenda)
        Me.TPGuias.Controls.Add(Me.grpDetalle)
        Me.TPGuias.Controls.Add(Me.grpFiltros)
        Me.TPGuias.Location = New System.Drawing.Point(4, 22)
        Me.TPGuias.Name = "TPGuias"
        Me.TPGuias.Padding = New System.Windows.Forms.Padding(3)
        Me.TPGuias.Size = New System.Drawing.Size(837, 560)
        Me.TPGuias.TabIndex = 0
        Me.TPGuias.Text = "Consulta de Guías Pendientes de Facturar"
        Me.TPGuias.UseVisualStyleBackColor = True
        '
        'grpResumen
        '
        Me.grpResumen.Controls.Add(Me.lblIGV)
        Me.grpResumen.Controls.Add(Me.lblTotalGuias)
        Me.grpResumen.Controls.Add(Me.lblMontoTotal)
        Me.grpResumen.Controls.Add(Me.lblSubTotalGuias)
        Me.grpResumen.Controls.Add(Me.lblMontoIgv)
        Me.grpResumen.Controls.Add(Me.lblMontoSubTotal)
        Me.grpResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpResumen.ForeColor = System.Drawing.Color.Navy
        Me.grpResumen.Location = New System.Drawing.Point(244, 467)
        Me.grpResumen.Name = "grpResumen"
        Me.grpResumen.Size = New System.Drawing.Size(590, 90)
        Me.grpResumen.TabIndex = 12
        Me.grpResumen.TabStop = False
        Me.grpResumen.Text = "Resumén:"
        '
        'lblIGV
        '
        Me.lblIGV.AutoSize = True
        Me.lblIGV.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIGV.Location = New System.Drawing.Point(412, 45)
        Me.lblIGV.Name = "lblIGV"
        Me.lblIGV.Size = New System.Drawing.Size(58, 13)
        Me.lblIGV.TabIndex = 3
        Me.lblIGV.Text = "IGV Guias:"
        '
        'lblTotalGuias
        '
        Me.lblTotalGuias.AutoSize = True
        Me.lblTotalGuias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalGuias.Location = New System.Drawing.Point(406, 67)
        Me.lblTotalGuias.Name = "lblTotalGuias"
        Me.lblTotalGuias.Size = New System.Drawing.Size(64, 13)
        Me.lblTotalGuias.TabIndex = 2
        Me.lblTotalGuias.Text = "Total Guias:"
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.AutoSize = True
        Me.lblMontoTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMontoTotal.Location = New System.Drawing.Point(509, 67)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(46, 13)
        Me.lblMontoTotal.TabIndex = 7
        Me.lblMontoTotal.Text = "S/. 0.00"
        Me.lblMontoTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubTotalGuias
        '
        Me.lblSubTotalGuias.AutoSize = True
        Me.lblSubTotalGuias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSubTotalGuias.Location = New System.Drawing.Point(387, 23)
        Me.lblSubTotalGuias.Name = "lblSubTotalGuias"
        Me.lblSubTotalGuias.Size = New System.Drawing.Size(83, 13)
        Me.lblSubTotalGuias.TabIndex = 4
        Me.lblSubTotalGuias.Text = "SubTotal Guias:"
        '
        'lblMontoIgv
        '
        Me.lblMontoIgv.AutoSize = True
        Me.lblMontoIgv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMontoIgv.Location = New System.Drawing.Point(509, 45)
        Me.lblMontoIgv.Name = "lblMontoIgv"
        Me.lblMontoIgv.Size = New System.Drawing.Size(46, 13)
        Me.lblMontoIgv.TabIndex = 6
        Me.lblMontoIgv.Text = "S/. 0.00"
        Me.lblMontoIgv.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMontoSubTotal
        '
        Me.lblMontoSubTotal.AutoSize = True
        Me.lblMontoSubTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMontoSubTotal.Location = New System.Drawing.Point(509, 23)
        Me.lblMontoSubTotal.Name = "lblMontoSubTotal"
        Me.lblMontoSubTotal.Size = New System.Drawing.Size(46, 13)
        Me.lblMontoSubTotal.TabIndex = 5
        Me.lblMontoSubTotal.Text = "S/. 0.00"
        Me.lblMontoSubTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpLeyenda
        '
        Me.grpLeyenda.Controls.Add(Me.lblPrecioReal)
        Me.grpLeyenda.Controls.Add(Me.lblDatoCalulado)
        Me.grpLeyenda.Controls.Add(Me.lblDatoReal)
        Me.grpLeyenda.Controls.Add(Me.PictureBox3)
        Me.grpLeyenda.Controls.Add(Me.PictureBox4)
        Me.grpLeyenda.Controls.Add(Me.pctDatoOriginal)
        Me.grpLeyenda.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpLeyenda.ForeColor = System.Drawing.Color.Navy
        Me.grpLeyenda.Location = New System.Drawing.Point(3, 467)
        Me.grpLeyenda.Name = "grpLeyenda"
        Me.grpLeyenda.Size = New System.Drawing.Size(241, 90)
        Me.grpLeyenda.TabIndex = 11
        Me.grpLeyenda.TabStop = False
        Me.grpLeyenda.Text = "Leyenda:"
        '
        'lblPrecioReal
        '
        Me.lblPrecioReal.AutoSize = True
        Me.lblPrecioReal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioReal.Location = New System.Drawing.Point(22, 67)
        Me.lblPrecioReal.Name = "lblPrecioReal"
        Me.lblPrecioReal.Size = New System.Drawing.Size(146, 13)
        Me.lblPrecioReal.TabIndex = 13
        Me.lblPrecioReal.Text = "Datos de Precio de las Guías"
        '
        'lblDatoCalulado
        '
        Me.lblDatoCalulado.AutoSize = True
        Me.lblDatoCalulado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDatoCalulado.Location = New System.Drawing.Point(22, 45)
        Me.lblDatoCalulado.Name = "lblDatoCalulado"
        Me.lblDatoCalulado.Size = New System.Drawing.Size(166, 13)
        Me.lblDatoCalulado.TabIndex = 12
        Me.lblDatoCalulado.Text = "Datos Recálculados de las Guías"
        '
        'lblDatoReal
        '
        Me.lblDatoReal.AutoSize = True
        Me.lblDatoReal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDatoReal.Location = New System.Drawing.Point(22, 23)
        Me.lblDatoReal.Name = "lblDatoReal"
        Me.lblDatoReal.Size = New System.Drawing.Size(147, 13)
        Me.lblDatoReal.TabIndex = 11
        Me.lblDatoReal.Text = "Datos Originales de las Guías"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.LightYellow
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(193, 45)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(29, 13)
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(193, 67)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(29, 13)
        Me.PictureBox4.TabIndex = 10
        Me.PictureBox4.TabStop = False
        '
        'pctDatoOriginal
        '
        Me.pctDatoOriginal.BackColor = System.Drawing.Color.LightPink
        Me.pctDatoOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctDatoOriginal.Location = New System.Drawing.Point(193, 23)
        Me.pctDatoOriginal.Name = "pctDatoOriginal"
        Me.pctDatoOriginal.Size = New System.Drawing.Size(29, 13)
        Me.pctDatoOriginal.TabIndex = 8
        Me.pctDatoOriginal.TabStop = False
        '
        'grpDetalle
        '
        Me.grpDetalle.Controls.Add(Me.dgvGuias)
        Me.grpDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDetalle.ForeColor = System.Drawing.Color.Navy
        Me.grpDetalle.Location = New System.Drawing.Point(3, 77)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(831, 390)
        Me.grpDetalle.TabIndex = 1
        Me.grpDetalle.TabStop = False
        Me.grpDetalle.Text = "Detalle de Guías:"
        '
        'dgvGuias
        '
        Me.dgvGuias.AllowUserToAddRows = False
        Me.dgvGuias.AllowUserToDeleteRows = False
        Me.dgvGuias.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvGuias.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGuias.Location = New System.Drawing.Point(3, 16)
        Me.dgvGuias.Name = "dgvGuias"
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvGuias.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGuias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGuias.Size = New System.Drawing.Size(825, 371)
        Me.dgvGuias.TabIndex = 0
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.chkSeleccionTodos)
        Me.grpFiltros.Controls.Add(Me.cboRazonSocial)
        Me.grpFiltros.Controls.Add(Me.btnProcesar)
        Me.grpFiltros.Controls.Add(Me.txtRuc)
        Me.grpFiltros.Controls.Add(Me.lblCliente)
        Me.grpFiltros.Controls.Add(Me.Label1)
        Me.grpFiltros.Controls.Add(Me.lblFecha)
        Me.grpFiltros.Controls.Add(Me.dtFechaFinal)
        Me.grpFiltros.Controls.Add(Me.dtFechaInicio)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.ForeColor = System.Drawing.Color.Navy
        Me.grpFiltros.Location = New System.Drawing.Point(3, 3)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(831, 74)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Parametros de Busqueda:"
        '
        'chkSeleccionTodos
        '
        Me.chkSeleccionTodos.AutoSize = True
        Me.chkSeleccionTodos.Enabled = False
        Me.chkSeleccionTodos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkSeleccionTodos.Location = New System.Drawing.Point(340, 47)
        Me.chkSeleccionTodos.Name = "chkSeleccionTodos"
        Me.chkSeleccionTodos.Size = New System.Drawing.Size(92, 17)
        Me.chkSeleccionTodos.TabIndex = 16
        Me.chkSeleccionTodos.Text = "Marcar Todos"
        Me.chkSeleccionTodos.UseVisualStyleBackColor = True
        '
        'cboRazonSocial
        '
        Me.cboRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRazonSocial.FormattingEnabled = True
        Me.cboRazonSocial.Location = New System.Drawing.Point(206, 20)
        Me.cboRazonSocial.Name = "cboRazonSocial"
        Me.cboRazonSocial.Size = New System.Drawing.Size(407, 21)
        Me.cboRazonSocial.TabIndex = 15
        '
        'btnProcesar
        '
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnProcesar.Location = New System.Drawing.Point(700, 18)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 14
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'txtRuc
        '
        Me.txtRuc.Location = New System.Drawing.Point(63, 19)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(136, 20)
        Me.txtRuc.TabIndex = 12
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCliente.Location = New System.Drawing.Point(13, 22)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 11
        Me.lblCliente.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(174, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "al"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblFecha.Location = New System.Drawing.Point(13, 48)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 9
        Me.lblFecha.Text = "Fecha"
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFinal.Location = New System.Drawing.Point(194, 45)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtFechaFinal.TabIndex = 8
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(64, 45)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(104, 20)
        Me.dtFechaInicio.TabIndex = 7
        '
        'TPFactura
        '
        Me.TPFactura.Controls.Add(Me.GroupBox1)
        Me.TPFactura.Controls.Add(Me.lblTotalFactura)
        Me.TPFactura.Controls.Add(Me.lblIgvFactura)
        Me.TPFactura.Controls.Add(Me.lblSubTotalFactura)
        Me.TPFactura.Controls.Add(Me.lblTotalFac)
        Me.TPFactura.Controls.Add(Me.lblIGVFac)
        Me.TPFactura.Controls.Add(Me.lblSubtotalFac)
        Me.TPFactura.Controls.Add(Me.grpDetallefactura)
        Me.TPFactura.Controls.Add(Me.grpCabecera)
        Me.TPFactura.Location = New System.Drawing.Point(4, 22)
        Me.TPFactura.Name = "TPFactura"
        Me.TPFactura.Padding = New System.Windows.Forms.Padding(3)
        Me.TPFactura.Size = New System.Drawing.Size(837, 560)
        Me.TPFactura.TabIndex = 1
        Me.TPFactura.Text = "Generación de Factura"
        Me.TPFactura.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.PictureBox6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(3, 468)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(241, 89)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Leyenda:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(22, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Datos de Precio de las Guías"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(22, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Datos Recálculados de las Guías"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(22, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Datos Originales de las Guías"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.LightYellow
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(193, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 13)
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Location = New System.Drawing.Point(193, 67)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(29, 13)
        Me.PictureBox5.TabIndex = 10
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.LightPink
        Me.PictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox6.Location = New System.Drawing.Point(193, 23)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(29, 13)
        Me.PictureBox6.TabIndex = 8
        Me.PictureBox6.TabStop = False
        '
        'lblTotalFactura
        '
        Me.lblTotalFactura.AutoSize = True
        Me.lblTotalFactura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalFactura.Location = New System.Drawing.Point(631, 528)
        Me.lblTotalFactura.Name = "lblTotalFactura"
        Me.lblTotalFactura.Size = New System.Drawing.Size(73, 13)
        Me.lblTotalFactura.TabIndex = 15
        Me.lblTotalFactura.Text = "Total Factura:"
        '
        'lblIgvFactura
        '
        Me.lblIgvFactura.AutoSize = True
        Me.lblIgvFactura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIgvFactura.Location = New System.Drawing.Point(637, 506)
        Me.lblIgvFactura.Name = "lblIgvFactura"
        Me.lblIgvFactura.Size = New System.Drawing.Size(67, 13)
        Me.lblIgvFactura.TabIndex = 14
        Me.lblIgvFactura.Text = "IGV Factura:"
        '
        'lblSubTotalFactura
        '
        Me.lblSubTotalFactura.AutoSize = True
        Me.lblSubTotalFactura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSubTotalFactura.Location = New System.Drawing.Point(612, 484)
        Me.lblSubTotalFactura.Name = "lblSubTotalFactura"
        Me.lblSubTotalFactura.Size = New System.Drawing.Size(92, 13)
        Me.lblSubTotalFactura.TabIndex = 13
        Me.lblSubTotalFactura.Text = "SubTotal Factura:"
        '
        'lblTotalFac
        '
        Me.lblTotalFac.AutoSize = True
        Me.lblTotalFac.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalFac.Location = New System.Drawing.Point(748, 528)
        Me.lblTotalFac.Name = "lblTotalFac"
        Me.lblTotalFac.Size = New System.Drawing.Size(46, 13)
        Me.lblTotalFac.TabIndex = 12
        Me.lblTotalFac.Text = "S/. 0.00"
        Me.lblTotalFac.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIGVFac
        '
        Me.lblIGVFac.AutoSize = True
        Me.lblIGVFac.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIGVFac.Location = New System.Drawing.Point(748, 506)
        Me.lblIGVFac.Name = "lblIGVFac"
        Me.lblIGVFac.Size = New System.Drawing.Size(46, 13)
        Me.lblIGVFac.TabIndex = 11
        Me.lblIGVFac.Text = "S/. 0.00"
        Me.lblIGVFac.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotalFac
        '
        Me.lblSubtotalFac.AutoSize = True
        Me.lblSubtotalFac.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSubtotalFac.Location = New System.Drawing.Point(748, 484)
        Me.lblSubtotalFac.Name = "lblSubtotalFac"
        Me.lblSubtotalFac.Size = New System.Drawing.Size(46, 13)
        Me.lblSubtotalFac.TabIndex = 10
        Me.lblSubtotalFac.Text = "S/. 0.00"
        Me.lblSubtotalFac.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpDetallefactura
        '
        Me.grpDetallefactura.Controls.Add(Me.dgvDetalleFactura)
        Me.grpDetallefactura.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDetallefactura.ForeColor = System.Drawing.Color.Navy
        Me.grpDetallefactura.Location = New System.Drawing.Point(3, 99)
        Me.grpDetallefactura.Name = "grpDetallefactura"
        Me.grpDetallefactura.Size = New System.Drawing.Size(831, 369)
        Me.grpDetallefactura.TabIndex = 9
        Me.grpDetallefactura.TabStop = False
        Me.grpDetallefactura.Text = "Detalle de Factura"
        '
        'dgvDetalleFactura
        '
        Me.dgvDetalleFactura.AllowUserToAddRows = False
        Me.dgvDetalleFactura.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvDetalleFactura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleFactura.Location = New System.Drawing.Point(3, 16)
        Me.dgvDetalleFactura.Name = "dgvDetalleFactura"
        Me.dgvDetalleFactura.ReadOnly = True
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvDetalleFactura.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleFactura.Size = New System.Drawing.Size(825, 350)
        Me.dgvDetalleFactura.TabIndex = 0
        '
        'grpCabecera
        '
        Me.grpCabecera.Controls.Add(Me.cboDireccion)
        Me.grpCabecera.Controls.Add(Me.lblDireccion)
        Me.grpCabecera.Controls.Add(Me.lblFechaVencimiento)
        Me.grpCabecera.Controls.Add(Me.dtFechaVencimiento)
        Me.grpCabecera.Controls.Add(Me.lblFechaFactura)
        Me.grpCabecera.Controls.Add(Me.dtFechaFactura)
        Me.grpCabecera.Controls.Add(Me.lblClienteFactura)
        Me.grpCabecera.Controls.Add(Me.lblRazonSocial)
        Me.grpCabecera.Controls.Add(Me.lblSerieNumeroDV)
        Me.grpCabecera.Controls.Add(Me.lblFormaPago)
        Me.grpCabecera.Controls.Add(Me.lblDocumento)
        Me.grpCabecera.Controls.Add(Me.lblDatoFormaPago)
        Me.grpCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCabecera.ForeColor = System.Drawing.Color.Navy
        Me.grpCabecera.Location = New System.Drawing.Point(3, 3)
        Me.grpCabecera.Name = "grpCabecera"
        Me.grpCabecera.Size = New System.Drawing.Size(831, 96)
        Me.grpCabecera.TabIndex = 8
        Me.grpCabecera.TabStop = False
        Me.grpCabecera.Text = "Datos de Factura"
        '
        'cboDireccion
        '
        Me.cboDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDireccion.FormattingEnabled = True
        Me.cboDireccion.Location = New System.Drawing.Point(330, 37)
        Me.cboDireccion.Name = "cboDireccion"
        Me.cboDireccion.Size = New System.Drawing.Size(336, 21)
        Me.cboDireccion.TabIndex = 11
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDireccion.Location = New System.Drawing.Point(235, 44)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(55, 13)
        Me.lblDireccion.TabIndex = 10
        Me.lblDireccion.Text = "Dirección:"
        '
        'lblFechaVencimiento
        '
        Me.lblFechaVencimiento.AutoSize = True
        Me.lblFechaVencimiento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaVencimiento.Location = New System.Drawing.Point(235, 67)
        Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
        Me.lblFechaVencimiento.Size = New System.Drawing.Size(92, 13)
        Me.lblFechaVencimiento.TabIndex = 8
        Me.lblFechaVencimiento.Text = "Fec. Vencimiento:"
        '
        'dtFechaVencimiento
        '
        Me.dtFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaVencimiento.Location = New System.Drawing.Point(330, 63)
        Me.dtFechaVencimiento.Name = "dtFechaVencimiento"
        Me.dtFechaVencimiento.Size = New System.Drawing.Size(100, 20)
        Me.dtFechaVencimiento.TabIndex = 9
        '
        'lblFechaFactura
        '
        Me.lblFechaFactura.AutoSize = True
        Me.lblFechaFactura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaFactura.Location = New System.Drawing.Point(8, 67)
        Me.lblFechaFactura.Name = "lblFechaFactura"
        Me.lblFechaFactura.Size = New System.Drawing.Size(70, 13)
        Me.lblFechaFactura.TabIndex = 6
        Me.lblFechaFactura.Text = "Fec. Factura:"
        '
        'dtFechaFactura
        '
        Me.dtFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFactura.Location = New System.Drawing.Point(85, 63)
        Me.dtFechaFactura.Name = "dtFechaFactura"
        Me.dtFechaFactura.Size = New System.Drawing.Size(100, 20)
        Me.dtFechaFactura.TabIndex = 7
        '
        'lblClienteFactura
        '
        Me.lblClienteFactura.AutoSize = True
        Me.lblClienteFactura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblClienteFactura.Location = New System.Drawing.Point(8, 21)
        Me.lblClienteFactura.Name = "lblClienteFactura"
        Me.lblClienteFactura.Size = New System.Drawing.Size(45, 13)
        Me.lblClienteFactura.TabIndex = 0
        Me.lblClienteFactura.Text = "Cliente: "
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRazonSocial.Location = New System.Drawing.Point(81, 21)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(122, 13)
        Me.lblRazonSocial.TabIndex = 1
        Me.lblRazonSocial.Text = "Razón Social del Cliente"
        '
        'lblSerieNumeroDV
        '
        Me.lblSerieNumeroDV.AutoSize = True
        Me.lblSerieNumeroDV.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSerieNumeroDV.Location = New System.Drawing.Point(639, 21)
        Me.lblSerieNumeroDV.Name = "lblSerieNumeroDV"
        Me.lblSerieNumeroDV.Size = New System.Drawing.Size(183, 13)
        Me.lblSerieNumeroDV.TabIndex = 5
        Me.lblSerieNumeroDV.Text = "Serie y Numero Documento de Venta"
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFormaPago.Location = New System.Drawing.Point(8, 44)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(67, 13)
        Me.lblFormaPago.TabIndex = 2
        Me.lblFormaPago.Text = "Forma Pago:"
        '
        'lblDocumento
        '
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDocumento.Location = New System.Drawing.Point(587, 21)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(46, 13)
        Me.lblDocumento.TabIndex = 4
        Me.lblDocumento.Text = "Factura:"
        '
        'lblDatoFormaPago
        '
        Me.lblDatoFormaPago.AutoSize = True
        Me.lblDatoFormaPago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDatoFormaPago.Location = New System.Drawing.Point(81, 44)
        Me.lblDatoFormaPago.Name = "lblDatoFormaPago"
        Me.lblDatoFormaPago.Size = New System.Drawing.Size(131, 13)
        Me.lblDatoFormaPago.TabIndex = 3
        Me.lblDatoFormaPago.Text = "Forma de Pago del Cliente"
        '
        'TPConsulta
        '
        Me.TPConsulta.Controls.Add(Me.grpEstadistica)
        Me.TPConsulta.Controls.Add(Me.grpGuiaFacturada)
        Me.TPConsulta.Controls.Add(Me.grpConsultaFactura)
        Me.TPConsulta.Controls.Add(Me.grpFiltro)
        Me.TPConsulta.Location = New System.Drawing.Point(4, 22)
        Me.TPConsulta.Name = "TPConsulta"
        Me.TPConsulta.Size = New System.Drawing.Size(837, 560)
        Me.TPConsulta.TabIndex = 2
        Me.TPConsulta.Text = "Consulta de Facturas Generadas"
        Me.TPConsulta.UseVisualStyleBackColor = True
        '
        'grpEstadistica
        '
        Me.grpEstadistica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpEstadistica.ForeColor = System.Drawing.Color.Navy
        Me.grpEstadistica.Location = New System.Drawing.Point(0, 418)
        Me.grpEstadistica.Name = "grpEstadistica"
        Me.grpEstadistica.Size = New System.Drawing.Size(837, 142)
        Me.grpEstadistica.TabIndex = 3
        Me.grpEstadistica.TabStop = False
        Me.grpEstadistica.Text = "Estadística"
        '
        'grpGuiaFacturada
        '
        Me.grpGuiaFacturada.Controls.Add(Me.dgvGuiaFacturada)
        Me.grpGuiaFacturada.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpGuiaFacturada.ForeColor = System.Drawing.Color.Navy
        Me.grpGuiaFacturada.Location = New System.Drawing.Point(0, 246)
        Me.grpGuiaFacturada.Name = "grpGuiaFacturada"
        Me.grpGuiaFacturada.Size = New System.Drawing.Size(837, 172)
        Me.grpGuiaFacturada.TabIndex = 2
        Me.grpGuiaFacturada.TabStop = False
        Me.grpGuiaFacturada.Text = "Cantidad de Guías Facturadas:"
        '
        'dgvGuiaFacturada
        '
        Me.dgvGuiaFacturada.AllowUserToAddRows = False
        Me.dgvGuiaFacturada.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvGuiaFacturada.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvGuiaFacturada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuiaFacturada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGuiaFacturada.Location = New System.Drawing.Point(3, 16)
        Me.dgvGuiaFacturada.Name = "dgvGuiaFacturada"
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvGuiaFacturada.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvGuiaFacturada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGuiaFacturada.Size = New System.Drawing.Size(831, 153)
        Me.dgvGuiaFacturada.TabIndex = 0
        '
        'grpConsultaFactura
        '
        Me.grpConsultaFactura.Controls.Add(Me.dgvFacturaEmitida)
        Me.grpConsultaFactura.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpConsultaFactura.ForeColor = System.Drawing.Color.Navy
        Me.grpConsultaFactura.Location = New System.Drawing.Point(0, 74)
        Me.grpConsultaFactura.Name = "grpConsultaFactura"
        Me.grpConsultaFactura.Size = New System.Drawing.Size(837, 172)
        Me.grpConsultaFactura.TabIndex = 1
        Me.grpConsultaFactura.TabStop = False
        Me.grpConsultaFactura.Text = "Cantidad de Facturas:"
        '
        'dgvFacturaEmitida
        '
        Me.dgvFacturaEmitida.AllowUserToAddRows = False
        Me.dgvFacturaEmitida.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvFacturaEmitida.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvFacturaEmitida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturaEmitida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFacturaEmitida.Location = New System.Drawing.Point(3, 16)
        Me.dgvFacturaEmitida.Name = "dgvFacturaEmitida"
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Window
        Me.dgvFacturaEmitida.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvFacturaEmitida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFacturaEmitida.Size = New System.Drawing.Size(831, 153)
        Me.dgvFacturaEmitida.TabIndex = 0
        '
        'grpFiltro
        '
        Me.grpFiltro.Controls.Add(Me.btnConsultar)
        Me.grpFiltro.Controls.Add(Me.lblFechaFin)
        Me.grpFiltro.Controls.Add(Me.lblRangoFecha)
        Me.grpFiltro.Controls.Add(Me.dtFacturaFechaFin)
        Me.grpFiltro.Controls.Add(Me.dtFacturaFechaIni)
        Me.grpFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltro.ForeColor = System.Drawing.Color.Navy
        Me.grpFiltro.Location = New System.Drawing.Point(0, 0)
        Me.grpFiltro.Name = "grpFiltro"
        Me.grpFiltro.Size = New System.Drawing.Size(837, 74)
        Me.grpFiltro.TabIndex = 0
        Me.grpFiltro.TabStop = False
        Me.grpFiltro.Text = "Filtros"
        '
        'btnConsultar
        '
        Me.btnConsultar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnConsultar.Location = New System.Drawing.Point(700, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaFin.Location = New System.Drawing.Point(232, 21)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(16, 13)
        Me.lblFechaFin.TabIndex = 3
        Me.lblFechaFin.Text = "Al"
        '
        'lblRangoFecha
        '
        Me.lblRangoFecha.AutoSize = True
        Me.lblRangoFecha.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRangoFecha.Location = New System.Drawing.Point(26, 20)
        Me.lblRangoFecha.Name = "lblRangoFecha"
        Me.lblRangoFecha.Size = New System.Drawing.Size(92, 13)
        Me.lblRangoFecha.TabIndex = 2
        Me.lblRangoFecha.Text = "Rango de fechas:"
        '
        'dtFacturaFechaFin
        '
        Me.dtFacturaFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFacturaFechaFin.Location = New System.Drawing.Point(256, 18)
        Me.dtFacturaFechaFin.Name = "dtFacturaFechaFin"
        Me.dtFacturaFechaFin.Size = New System.Drawing.Size(99, 20)
        Me.dtFacturaFechaFin.TabIndex = 1
        '
        'dtFacturaFechaIni
        '
        Me.dtFacturaFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFacturaFechaIni.Location = New System.Drawing.Point(124, 17)
        Me.dtFacturaFechaIni.Name = "dtFacturaFechaIni"
        Me.dtFacturaFechaIni.Size = New System.Drawing.Size(99, 20)
        Me.dtFacturaFechaIni.TabIndex = 0
        '
        'FrmFacturacionEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 661)
        Me.Controls.Add(Me.TCFacturacionEspecial)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "FrmFacturacionEspecial"
        Me.Text = "FrmFacturacionEspecial"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnlBarra.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TCFacturacionEspecial.ResumeLayout(False)
        Me.TPGuias.ResumeLayout(False)
        Me.grpResumen.ResumeLayout(False)
        Me.grpResumen.PerformLayout()
        Me.grpLeyenda.ResumeLayout(False)
        Me.grpLeyenda.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctDatoOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetalle.ResumeLayout(False)
        CType(Me.dgvGuias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.TPFactura.ResumeLayout(False)
        Me.TPFactura.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetallefactura.ResumeLayout(False)
        CType(Me.dgvDetalleFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCabecera.ResumeLayout(False)
        Me.grpCabecera.PerformLayout()
        Me.TPConsulta.ResumeLayout(False)
        Me.grpGuiaFacturada.ResumeLayout(False)
        CType(Me.dgvGuiaFacturada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpConsultaFactura.ResumeLayout(False)
        CType(Me.dgvFacturaEmitida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltro.ResumeLayout(False)
        Me.grpFiltro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents TCFacturacionEspecial As System.Windows.Forms.TabControl
    Friend WithEvents TPGuias As System.Windows.Forms.TabPage
    Friend WithEvents TPFactura As System.Windows.Forms.TabPage
    Protected WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Protected WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripmenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents TPConsulta As System.Windows.Forms.TabPage
    Friend WithEvents grpFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents grpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgvGuias As System.Windows.Forms.DataGridView
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents cboRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents chkSeleccionTodos As System.Windows.Forms.CheckBox
    Friend WithEvents lblClienteFactura As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblFormaPago As System.Windows.Forms.Label
    Friend WithEvents lblDatoFormaPago As System.Windows.Forms.Label
    Friend WithEvents lblSerieNumeroDV As System.Windows.Forms.Label
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents dtFechaFactura As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFactura As System.Windows.Forms.Label
    Friend WithEvents grpCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents grpDetallefactura As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalleFactura As System.Windows.Forms.DataGridView
    Friend WithEvents lblSubTotalGuias As System.Windows.Forms.Label
    Friend WithEvents lblIGV As System.Windows.Forms.Label
    Friend WithEvents lblTotalGuias As System.Windows.Forms.Label
    Friend WithEvents lblMontoSubTotal As System.Windows.Forms.Label
    Friend WithEvents lblMontoTotal As System.Windows.Forms.Label
    Friend WithEvents lblMontoIgv As System.Windows.Forms.Label
    Friend WithEvents lblTotalFac As System.Windows.Forms.Label
    Friend WithEvents lblIGVFac As System.Windows.Forms.Label
    Friend WithEvents lblSubtotalFac As System.Windows.Forms.Label
    Friend WithEvents lblIgvFactura As System.Windows.Forms.Label
    Friend WithEvents lblSubTotalFactura As System.Windows.Forms.Label
    Friend WithEvents lblTotalFactura As System.Windows.Forms.Label
    Friend WithEvents pctDatoOriginal As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents grpLeyenda As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrecioReal As System.Windows.Forms.Label
    Friend WithEvents lblDatoCalulado As System.Windows.Forms.Label
    Friend WithEvents lblDatoReal As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents grpResumen As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaVencimiento As System.Windows.Forms.Label
    Friend WithEvents dtFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents dtFacturaFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFacturaFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents lblRangoFecha As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents grpConsultaFactura As System.Windows.Forms.GroupBox
    Friend WithEvents dgvFacturaEmitida As System.Windows.Forms.DataGridView
    Friend WithEvents grpGuiaFacturada As System.Windows.Forms.GroupBox
    Friend WithEvents dgvGuiaFacturada As System.Windows.Forms.DataGridView
    Friend WithEvents grpEstadistica As System.Windows.Forms.GroupBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents cboDireccion As System.Windows.Forms.ComboBox

End Class
