<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComisionPasajes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComisionPasajes))
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
        Me.TCComisionPasajes = New System.Windows.Forms.TabControl()
        Me.TPCalculoComision = New System.Windows.Forms.TabPage()
        Me.pnlCalculoComision = New System.Windows.Forms.Panel()
        Me.grpComision = New System.Windows.Forms.GroupBox()
        Me.pnlTotalComision = New System.Windows.Forms.Panel()
        Me.lblDatoTotalComision = New System.Windows.Forms.Label()
        Me.lblTotalComision = New System.Windows.Forms.Label()
        Me.dgdComision = New System.Windows.Forms.DataGridView()
        Me.pnlProcesoComision = New System.Windows.Forms.Panel()
        Me.grpCobranza = New System.Windows.Forms.GroupBox()
        Me.pnlCobranza = New System.Windows.Forms.Panel()
        Me.lblDatoCobroDocProvNuevo = New System.Windows.Forms.Label()
        Me.lblDatoCobroDocLimaNuevo = New System.Windows.Forms.Label()
        Me.lblCobroDocProvNuevo = New System.Windows.Forms.Label()
        Me.lblCobroDocLimaNuevo = New System.Windows.Forms.Label()
        Me.lblDatoCantDocProvNuevo = New System.Windows.Forms.Label()
        Me.lblDatoCantDocLimaNuevo = New System.Windows.Forms.Label()
        Me.lblCantDocProvNuevo = New System.Windows.Forms.Label()
        Me.lblCantDocLimaNuevo = New System.Windows.Forms.Label()
        Me.lblComisionDocumentoNuevo = New System.Windows.Forms.Label()
        Me.lblDatoCobroDocProvAnt = New System.Windows.Forms.Label()
        Me.lblDatoCobroDocLimaAnt = New System.Windows.Forms.Label()
        Me.lblCobroDocProvAnt = New System.Windows.Forms.Label()
        Me.lblDatoCantDocProvAnt = New System.Windows.Forms.Label()
        Me.lblCantDocProvAnterior = New System.Windows.Forms.Label()
        Me.lblCobroDocLimaAnt = New System.Windows.Forms.Label()
        Me.lblDatoCantDocLimaAnt = New System.Windows.Forms.Label()
        Me.lblCantDocLimaAnterior = New System.Windows.Forms.Label()
        Me.lblComisionDocumentoAnterior = New System.Windows.Forms.Label()
        Me.dgdCobranza = New System.Windows.Forms.DataGridView()
        Me.GrpMetaFuncionario = New System.Windows.Forms.GroupBox()
        Me.pnlPorcentaje = New System.Windows.Forms.Panel()
        Me.lblDatoBonoProvNuevo = New System.Windows.Forms.Label()
        Me.lblDatoBonoLimaNuevo = New System.Windows.Forms.Label()
        Me.lblDatoBonoProvAnt = New System.Windows.Forms.Label()
        Me.lblDatoBonoLimaAnt = New System.Windows.Forms.Label()
        Me.lblBonoProvNuevo = New System.Windows.Forms.Label()
        Me.lblBonoLimaNuevo = New System.Windows.Forms.Label()
        Me.lblBonoProvAnt = New System.Windows.Forms.Label()
        Me.lblBonoLimaAnt = New System.Windows.Forms.Label()
        Me.lblDatoPorcProvNuevo = New System.Windows.Forms.Label()
        Me.lblDatoPorcLimaNuevo = New System.Windows.Forms.Label()
        Me.lblDatoPorcProvAnt = New System.Windows.Forms.Label()
        Me.lblDatoPorcLimaAnt = New System.Windows.Forms.Label()
        Me.lblPorcentajeProvNuevo = New System.Windows.Forms.Label()
        Me.lblPorcentajeLimaNuevo = New System.Windows.Forms.Label()
        Me.lblPorcentajeProvAnt = New System.Windows.Forms.Label()
        Me.lblPorcentajeLimaAnt = New System.Windows.Forms.Label()
        Me.lblComisionPorcentajeNuevo = New System.Windows.Forms.Label()
        Me.lblComisionPorcentajeAnterior = New System.Windows.Forms.Label()
        Me.dgdRangoFuncionario = New System.Windows.Forms.DataGridView()
        Me.grpVenta = New System.Windows.Forms.GroupBox()
        Me.pnlMeta = New System.Windows.Forms.Panel()
        Me.lblDatoBaseProv = New System.Windows.Forms.Label()
        Me.lblBaseProvincia = New System.Windows.Forms.Label()
        Me.lblDatoBaseCalculo = New System.Windows.Forms.Label()
        Me.lblBaseCalculo = New System.Windows.Forms.Label()
        Me.lblDatoBaseLima = New System.Windows.Forms.Label()
        Me.lblBaseLima = New System.Windows.Forms.Label()
        Me.lblDatoTotalVentaProv = New System.Windows.Forms.Label()
        Me.lblTotalventaProvincia = New System.Windows.Forms.Label()
        Me.lblDatoMetaProv = New System.Windows.Forms.Label()
        Me.lblMetaProvincia = New System.Windows.Forms.Label()
        Me.lblDatoTotalVentaLima = New System.Windows.Forms.Label()
        Me.lblTotalventa = New System.Windows.Forms.Label()
        Me.lblMeta = New System.Windows.Forms.Label()
        Me.lblDatoMetaLima = New System.Windows.Forms.Label()
        Me.dgdVenta = New System.Windows.Forms.DataGridView()
        Me.pnlVentaCobranza = New System.Windows.Forms.Panel()
        Me.lblFuncionario = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.grpFuncionario = New System.Windows.Forms.GroupBox()
        Me.TVFuncionario = New System.Windows.Forms.TreeView()
        Me.grpRangoFecha = New System.Windows.Forms.GroupBox()
        Me.DTPFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.lblFechaIni = New System.Windows.Forms.Label()
        Me.DTPFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.TPConsultaComision = New System.Windows.Forms.TabPage()
        Me.pnlReporte = New System.Windows.Forms.Panel()
        Me.pnlConsultaTotalComision = New System.Windows.Forms.Panel()
        Me.lblDatoConsultaTotalComision = New System.Windows.Forms.Label()
        Me.lblConsultaTotalComision = New System.Windows.Forms.Label()
        Me.pnlComisionConsulta = New System.Windows.Forms.Panel()
        Me.grpConsultaDetalleComision = New System.Windows.Forms.GroupBox()
        Me.dgdConsultaDetalleComision = New System.Windows.Forms.DataGridView()
        Me.grpConsultaCabeceraComision = New System.Windows.Forms.GroupBox()
        Me.dgdConsultaCabeceraComision = New System.Windows.Forms.DataGridView()
        Me.pnlFiltroConsulta = New System.Windows.Forms.Panel()
        Me.grpFiltroConsulta = New System.Windows.Forms.GroupBox()
        Me.DTPFechaFinalConsulta = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFinalConsulta = New System.Windows.Forms.Label()
        Me.DTPFechaInicioConsulta = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicioConsulta = New System.Windows.Forms.Label()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TCComisionPasajes.SuspendLayout()
        Me.TPCalculoComision.SuspendLayout()
        Me.pnlCalculoComision.SuspendLayout()
        Me.grpComision.SuspendLayout()
        Me.pnlTotalComision.SuspendLayout()
        CType(Me.dgdComision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProcesoComision.SuspendLayout()
        Me.grpCobranza.SuspendLayout()
        Me.pnlCobranza.SuspendLayout()
        CType(Me.dgdCobranza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetaFuncionario.SuspendLayout()
        Me.pnlPorcentaje.SuspendLayout()
        CType(Me.dgdRangoFuncionario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVenta.SuspendLayout()
        Me.pnlMeta.SuspendLayout()
        CType(Me.dgdVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVentaCobranza.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.grpFuncionario.SuspendLayout()
        Me.grpRangoFecha.SuspendLayout()
        Me.TPConsultaComision.SuspendLayout()
        Me.pnlConsultaTotalComision.SuspendLayout()
        Me.pnlComisionConsulta.SuspendLayout()
        Me.grpConsultaDetalleComision.SuspendLayout()
        CType(Me.dgdConsultaDetalleComision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpConsultaCabeceraComision.SuspendLayout()
        CType(Me.dgdConsultaCabeceraComision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltroConsulta.SuspendLayout()
        Me.grpFiltroConsulta.SuspendLayout()
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
        Me.pnlTitulo.Size = New System.Drawing.Size(1287, 38)
        Me.pnlTitulo.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1172, 0)
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
        Me.lblTitulo.Size = New System.Drawing.Size(193, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "COMISION DE PASAJES"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(1287, 38)
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
        Me.pnlBarra.Size = New System.Drawing.Size(1287, 37)
        Me.pnlBarra.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EdicionToolStripMenuItem, Me.CancelarToolStripmenuItem, Me.GrabarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ConsultarToolStripMenuItem, Me.AnularToolStripMenuItem, Me.ReporteToolStripMenuItem, Me.CierreComisionesToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1287, 37)
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
        'TCComisionPasajes
        '
        Me.TCComisionPasajes.Controls.Add(Me.TPCalculoComision)
        Me.TCComisionPasajes.Controls.Add(Me.TPConsultaComision)
        Me.TCComisionPasajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCComisionPasajes.Location = New System.Drawing.Point(0, 75)
        Me.TCComisionPasajes.Name = "TCComisionPasajes"
        Me.TCComisionPasajes.SelectedIndex = 0
        Me.TCComisionPasajes.Size = New System.Drawing.Size(1287, 610)
        Me.TCComisionPasajes.TabIndex = 3
        '
        'TPCalculoComision
        '
        Me.TPCalculoComision.Controls.Add(Me.pnlCalculoComision)
        Me.TPCalculoComision.Controls.Add(Me.pnlProcesoComision)
        Me.TPCalculoComision.Controls.Add(Me.pnlVentaCobranza)
        Me.TPCalculoComision.Controls.Add(Me.pnlFiltros)
        Me.TPCalculoComision.Location = New System.Drawing.Point(4, 22)
        Me.TPCalculoComision.Name = "TPCalculoComision"
        Me.TPCalculoComision.Padding = New System.Windows.Forms.Padding(3)
        Me.TPCalculoComision.Size = New System.Drawing.Size(1279, 584)
        Me.TPCalculoComision.TabIndex = 0
        Me.TPCalculoComision.Text = "Cálculo de Comisión"
        Me.TPCalculoComision.UseVisualStyleBackColor = True
        '
        'pnlCalculoComision
        '
        Me.pnlCalculoComision.Controls.Add(Me.grpComision)
        Me.pnlCalculoComision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCalculoComision.Location = New System.Drawing.Point(237, 378)
        Me.pnlCalculoComision.Name = "pnlCalculoComision"
        Me.pnlCalculoComision.Size = New System.Drawing.Size(1039, 203)
        Me.pnlCalculoComision.TabIndex = 3
        '
        'grpComision
        '
        Me.grpComision.Controls.Add(Me.pnlTotalComision)
        Me.grpComision.Controls.Add(Me.dgdComision)
        Me.grpComision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpComision.Location = New System.Drawing.Point(0, 0)
        Me.grpComision.Name = "grpComision"
        Me.grpComision.Size = New System.Drawing.Size(1039, 203)
        Me.grpComision.TabIndex = 0
        Me.grpComision.TabStop = False
        Me.grpComision.Text = "Comisión"
        '
        'pnlTotalComision
        '
        Me.pnlTotalComision.Controls.Add(Me.lblDatoTotalComision)
        Me.pnlTotalComision.Controls.Add(Me.lblTotalComision)
        Me.pnlTotalComision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTotalComision.Location = New System.Drawing.Point(3, 171)
        Me.pnlTotalComision.Name = "pnlTotalComision"
        Me.pnlTotalComision.Size = New System.Drawing.Size(1033, 29)
        Me.pnlTotalComision.TabIndex = 1
        '
        'lblDatoTotalComision
        '
        Me.lblDatoTotalComision.AutoSize = True
        Me.lblDatoTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoTotalComision.Location = New System.Drawing.Point(831, 6)
        Me.lblDatoTotalComision.Name = "lblDatoTotalComision"
        Me.lblDatoTotalComision.Size = New System.Drawing.Size(36, 16)
        Me.lblDatoTotalComision.TabIndex = 1
        Me.lblDatoTotalComision.Text = "0.00"
        '
        'lblTotalComision
        '
        Me.lblTotalComision.AutoSize = True
        Me.lblTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalComision.Location = New System.Drawing.Point(672, 6)
        Me.lblTotalComision.Name = "lblTotalComision"
        Me.lblTotalComision.Size = New System.Drawing.Size(149, 16)
        Me.lblTotalComision.TabIndex = 0
        Me.lblTotalComision.Text = "Total Comisión (S/.):"
        '
        'dgdComision
        '
        Me.dgdComision.AllowUserToAddRows = False
        Me.dgdComision.AllowUserToDeleteRows = False
        Me.dgdComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdComision.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgdComision.Location = New System.Drawing.Point(3, 16)
        Me.dgdComision.Name = "dgdComision"
        Me.dgdComision.Size = New System.Drawing.Size(1033, 155)
        Me.dgdComision.TabIndex = 0
        '
        'pnlProcesoComision
        '
        Me.pnlProcesoComision.Controls.Add(Me.grpCobranza)
        Me.pnlProcesoComision.Controls.Add(Me.GrpMetaFuncionario)
        Me.pnlProcesoComision.Controls.Add(Me.grpVenta)
        Me.pnlProcesoComision.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProcesoComision.Location = New System.Drawing.Point(237, 74)
        Me.pnlProcesoComision.Name = "pnlProcesoComision"
        Me.pnlProcesoComision.Size = New System.Drawing.Size(1039, 304)
        Me.pnlProcesoComision.TabIndex = 2
        '
        'grpCobranza
        '
        Me.grpCobranza.Controls.Add(Me.pnlCobranza)
        Me.grpCobranza.Controls.Add(Me.dgdCobranza)
        Me.grpCobranza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCobranza.Location = New System.Drawing.Point(640, 0)
        Me.grpCobranza.Name = "grpCobranza"
        Me.grpCobranza.Size = New System.Drawing.Size(399, 304)
        Me.grpCobranza.TabIndex = 3
        Me.grpCobranza.TabStop = False
        Me.grpCobranza.Text = "Cobranza por Funcionario"
        '
        'pnlCobranza
        '
        Me.pnlCobranza.Controls.Add(Me.lblDatoCobroDocProvNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblDatoCobroDocLimaNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblCobroDocProvNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblCobroDocLimaNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblDatoCantDocProvNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblDatoCantDocLimaNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblCantDocProvNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblCantDocLimaNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblComisionDocumentoNuevo)
        Me.pnlCobranza.Controls.Add(Me.lblDatoCobroDocProvAnt)
        Me.pnlCobranza.Controls.Add(Me.lblDatoCobroDocLimaAnt)
        Me.pnlCobranza.Controls.Add(Me.lblCobroDocProvAnt)
        Me.pnlCobranza.Controls.Add(Me.lblDatoCantDocProvAnt)
        Me.pnlCobranza.Controls.Add(Me.lblCantDocProvAnterior)
        Me.pnlCobranza.Controls.Add(Me.lblCobroDocLimaAnt)
        Me.pnlCobranza.Controls.Add(Me.lblDatoCantDocLimaAnt)
        Me.pnlCobranza.Controls.Add(Me.lblCantDocLimaAnterior)
        Me.pnlCobranza.Controls.Add(Me.lblComisionDocumentoAnterior)
        Me.pnlCobranza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCobranza.Location = New System.Drawing.Point(3, 176)
        Me.pnlCobranza.Name = "pnlCobranza"
        Me.pnlCobranza.Size = New System.Drawing.Size(393, 125)
        Me.pnlCobranza.TabIndex = 1
        '
        'lblDatoCobroDocProvNuevo
        '
        Me.lblDatoCobroDocProvNuevo.AutoSize = True
        Me.lblDatoCobroDocProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCobroDocProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCobroDocProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCobroDocProvNuevo.Location = New System.Drawing.Point(318, 102)
        Me.lblDatoCobroDocProvNuevo.Name = "lblDatoCobroDocProvNuevo"
        Me.lblDatoCobroDocProvNuevo.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoCobroDocProvNuevo.TabIndex = 91
        Me.lblDatoCobroDocProvNuevo.Text = "0.00"
        '
        'lblDatoCobroDocLimaNuevo
        '
        Me.lblDatoCobroDocLimaNuevo.AutoSize = True
        Me.lblDatoCobroDocLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCobroDocLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCobroDocLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCobroDocLimaNuevo.Location = New System.Drawing.Point(318, 84)
        Me.lblDatoCobroDocLimaNuevo.Name = "lblDatoCobroDocLimaNuevo"
        Me.lblDatoCobroDocLimaNuevo.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoCobroDocLimaNuevo.TabIndex = 90
        Me.lblDatoCobroDocLimaNuevo.Text = "0.00"
        '
        'lblCobroDocProvNuevo
        '
        Me.lblCobroDocProvNuevo.AutoSize = True
        Me.lblCobroDocProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblCobroDocProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobroDocProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobroDocProvNuevo.Location = New System.Drawing.Point(197, 102)
        Me.lblCobroDocProvNuevo.Name = "lblCobroDocProvNuevo"
        Me.lblCobroDocProvNuevo.Size = New System.Drawing.Size(104, 13)
        Me.lblCobroDocProvNuevo.TabIndex = 89
        Me.lblCobroDocProvNuevo.Text = "Cobranza Prov (S/.):"
        '
        'lblCobroDocLimaNuevo
        '
        Me.lblCobroDocLimaNuevo.AutoSize = True
        Me.lblCobroDocLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblCobroDocLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobroDocLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobroDocLimaNuevo.Location = New System.Drawing.Point(197, 84)
        Me.lblCobroDocLimaNuevo.Name = "lblCobroDocLimaNuevo"
        Me.lblCobroDocLimaNuevo.Size = New System.Drawing.Size(104, 13)
        Me.lblCobroDocLimaNuevo.TabIndex = 88
        Me.lblCobroDocLimaNuevo.Text = "Cobranza Lima (S/.):"
        '
        'lblDatoCantDocProvNuevo
        '
        Me.lblDatoCantDocProvNuevo.AutoSize = True
        Me.lblDatoCantDocProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCantDocProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCantDocProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCantDocProvNuevo.Location = New System.Drawing.Point(132, 102)
        Me.lblDatoCantDocProvNuevo.Name = "lblDatoCantDocProvNuevo"
        Me.lblDatoCantDocProvNuevo.Size = New System.Drawing.Size(13, 13)
        Me.lblDatoCantDocProvNuevo.TabIndex = 87
        Me.lblDatoCantDocProvNuevo.Text = "0"
        '
        'lblDatoCantDocLimaNuevo
        '
        Me.lblDatoCantDocLimaNuevo.AutoSize = True
        Me.lblDatoCantDocLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCantDocLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCantDocLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCantDocLimaNuevo.Location = New System.Drawing.Point(132, 84)
        Me.lblDatoCantDocLimaNuevo.Name = "lblDatoCantDocLimaNuevo"
        Me.lblDatoCantDocLimaNuevo.Size = New System.Drawing.Size(13, 13)
        Me.lblDatoCantDocLimaNuevo.TabIndex = 86
        Me.lblDatoCantDocLimaNuevo.Text = "0"
        '
        'lblCantDocProvNuevo
        '
        Me.lblCantDocProvNuevo.AutoSize = True
        Me.lblCantDocProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblCantDocProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantDocProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCantDocProvNuevo.Location = New System.Drawing.Point(34, 102)
        Me.lblCantDocProvNuevo.Name = "lblCantDocProvNuevo"
        Me.lblCantDocProvNuevo.Size = New System.Drawing.Size(91, 13)
        Me.lblCantDocProvNuevo.TabIndex = 85
        Me.lblCantDocProvNuevo.Text = "Cant. Docs. Prov:"
        '
        'lblCantDocLimaNuevo
        '
        Me.lblCantDocLimaNuevo.AutoSize = True
        Me.lblCantDocLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblCantDocLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantDocLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCantDocLimaNuevo.Location = New System.Drawing.Point(34, 84)
        Me.lblCantDocLimaNuevo.Name = "lblCantDocLimaNuevo"
        Me.lblCantDocLimaNuevo.Size = New System.Drawing.Size(91, 13)
        Me.lblCantDocLimaNuevo.TabIndex = 84
        Me.lblCantDocLimaNuevo.Text = "Cant. Docs. Lima:"
        '
        'lblComisionDocumentoNuevo
        '
        Me.lblComisionDocumentoNuevo.AutoSize = True
        Me.lblComisionDocumentoNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblComisionDocumentoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisionDocumentoNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblComisionDocumentoNuevo.Location = New System.Drawing.Point(54, 66)
        Me.lblComisionDocumentoNuevo.Name = "lblComisionDocumentoNuevo"
        Me.lblComisionDocumentoNuevo.Size = New System.Drawing.Size(273, 13)
        Me.lblComisionDocumentoNuevo.TabIndex = 83
        Me.lblComisionDocumentoNuevo.Text = "Documentos Cancelados Desde el 26/09/2012"
        '
        'lblDatoCobroDocProvAnt
        '
        Me.lblDatoCobroDocProvAnt.AutoSize = True
        Me.lblDatoCobroDocProvAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCobroDocProvAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCobroDocProvAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCobroDocProvAnt.Location = New System.Drawing.Point(318, 46)
        Me.lblDatoCobroDocProvAnt.Name = "lblDatoCobroDocProvAnt"
        Me.lblDatoCobroDocProvAnt.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoCobroDocProvAnt.TabIndex = 82
        Me.lblDatoCobroDocProvAnt.Text = "0.00"
        '
        'lblDatoCobroDocLimaAnt
        '
        Me.lblDatoCobroDocLimaAnt.AutoSize = True
        Me.lblDatoCobroDocLimaAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCobroDocLimaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCobroDocLimaAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCobroDocLimaAnt.Location = New System.Drawing.Point(318, 28)
        Me.lblDatoCobroDocLimaAnt.Name = "lblDatoCobroDocLimaAnt"
        Me.lblDatoCobroDocLimaAnt.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoCobroDocLimaAnt.TabIndex = 81
        Me.lblDatoCobroDocLimaAnt.Text = "0.00"
        '
        'lblCobroDocProvAnt
        '
        Me.lblCobroDocProvAnt.AutoSize = True
        Me.lblCobroDocProvAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblCobroDocProvAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobroDocProvAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobroDocProvAnt.Location = New System.Drawing.Point(197, 46)
        Me.lblCobroDocProvAnt.Name = "lblCobroDocProvAnt"
        Me.lblCobroDocProvAnt.Size = New System.Drawing.Size(104, 13)
        Me.lblCobroDocProvAnt.TabIndex = 80
        Me.lblCobroDocProvAnt.Text = "Cobranza Prov (S/.):"
        '
        'lblDatoCantDocProvAnt
        '
        Me.lblDatoCantDocProvAnt.AutoSize = True
        Me.lblDatoCantDocProvAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCantDocProvAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCantDocProvAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCantDocProvAnt.Location = New System.Drawing.Point(132, 46)
        Me.lblDatoCantDocProvAnt.Name = "lblDatoCantDocProvAnt"
        Me.lblDatoCantDocProvAnt.Size = New System.Drawing.Size(13, 13)
        Me.lblDatoCantDocProvAnt.TabIndex = 79
        Me.lblDatoCantDocProvAnt.Text = "0"
        '
        'lblCantDocProvAnterior
        '
        Me.lblCantDocProvAnterior.AutoSize = True
        Me.lblCantDocProvAnterior.BackColor = System.Drawing.Color.Transparent
        Me.lblCantDocProvAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantDocProvAnterior.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCantDocProvAnterior.Location = New System.Drawing.Point(34, 46)
        Me.lblCantDocProvAnterior.Name = "lblCantDocProvAnterior"
        Me.lblCantDocProvAnterior.Size = New System.Drawing.Size(91, 13)
        Me.lblCantDocProvAnterior.TabIndex = 78
        Me.lblCantDocProvAnterior.Text = "Cant. Docs. Prov:"
        '
        'lblCobroDocLimaAnt
        '
        Me.lblCobroDocLimaAnt.AutoSize = True
        Me.lblCobroDocLimaAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblCobroDocLimaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobroDocLimaAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobroDocLimaAnt.Location = New System.Drawing.Point(197, 28)
        Me.lblCobroDocLimaAnt.Name = "lblCobroDocLimaAnt"
        Me.lblCobroDocLimaAnt.Size = New System.Drawing.Size(104, 13)
        Me.lblCobroDocLimaAnt.TabIndex = 77
        Me.lblCobroDocLimaAnt.Text = "Cobranza Lima (S/.):"
        '
        'lblDatoCantDocLimaAnt
        '
        Me.lblDatoCantDocLimaAnt.AutoSize = True
        Me.lblDatoCantDocLimaAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoCantDocLimaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoCantDocLimaAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoCantDocLimaAnt.Location = New System.Drawing.Point(132, 28)
        Me.lblDatoCantDocLimaAnt.Name = "lblDatoCantDocLimaAnt"
        Me.lblDatoCantDocLimaAnt.Size = New System.Drawing.Size(13, 13)
        Me.lblDatoCantDocLimaAnt.TabIndex = 76
        Me.lblDatoCantDocLimaAnt.Text = "0"
        '
        'lblCantDocLimaAnterior
        '
        Me.lblCantDocLimaAnterior.AutoSize = True
        Me.lblCantDocLimaAnterior.BackColor = System.Drawing.Color.Transparent
        Me.lblCantDocLimaAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantDocLimaAnterior.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCantDocLimaAnterior.Location = New System.Drawing.Point(34, 28)
        Me.lblCantDocLimaAnterior.Name = "lblCantDocLimaAnterior"
        Me.lblCantDocLimaAnterior.Size = New System.Drawing.Size(91, 13)
        Me.lblCantDocLimaAnterior.TabIndex = 72
        Me.lblCantDocLimaAnterior.Text = "Cant. Docs. Lima:"
        '
        'lblComisionDocumentoAnterior
        '
        Me.lblComisionDocumentoAnterior.AutoSize = True
        Me.lblComisionDocumentoAnterior.BackColor = System.Drawing.Color.Transparent
        Me.lblComisionDocumentoAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisionDocumentoAnterior.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblComisionDocumentoAnterior.Location = New System.Drawing.Point(55, 10)
        Me.lblComisionDocumentoAnterior.Name = "lblComisionDocumentoAnterior"
        Me.lblComisionDocumentoAnterior.Size = New System.Drawing.Size(270, 13)
        Me.lblComisionDocumentoAnterior.TabIndex = 70
        Me.lblComisionDocumentoAnterior.Text = "Documentos Cancelados Hasta el 26/09/2012"
        '
        'dgdCobranza
        '
        Me.dgdCobranza.AllowUserToAddRows = False
        Me.dgdCobranza.AllowUserToDeleteRows = False
        Me.dgdCobranza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCobranza.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgdCobranza.Location = New System.Drawing.Point(3, 16)
        Me.dgdCobranza.Name = "dgdCobranza"
        Me.dgdCobranza.Size = New System.Drawing.Size(393, 160)
        Me.dgdCobranza.TabIndex = 0
        '
        'GrpMetaFuncionario
        '
        Me.GrpMetaFuncionario.Controls.Add(Me.pnlPorcentaje)
        Me.GrpMetaFuncionario.Controls.Add(Me.dgdRangoFuncionario)
        Me.GrpMetaFuncionario.Dock = System.Windows.Forms.DockStyle.Left
        Me.GrpMetaFuncionario.Location = New System.Drawing.Point(320, 0)
        Me.GrpMetaFuncionario.Name = "GrpMetaFuncionario"
        Me.GrpMetaFuncionario.Size = New System.Drawing.Size(320, 304)
        Me.GrpMetaFuncionario.TabIndex = 2
        Me.GrpMetaFuncionario.TabStop = False
        Me.GrpMetaFuncionario.Text = "Rango de Metas por Funcionario"
        '
        'pnlPorcentaje
        '
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoBonoProvNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoBonoLimaNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoBonoProvAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoBonoLimaAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblBonoProvNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblBonoLimaNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblBonoProvAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblBonoLimaAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoPorcProvNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoPorcLimaNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoPorcProvAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblDatoPorcLimaAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblPorcentajeProvNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblPorcentajeLimaNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblPorcentajeProvAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblPorcentajeLimaAnt)
        Me.pnlPorcentaje.Controls.Add(Me.lblComisionPorcentajeNuevo)
        Me.pnlPorcentaje.Controls.Add(Me.lblComisionPorcentajeAnterior)
        Me.pnlPorcentaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPorcentaje.Location = New System.Drawing.Point(3, 176)
        Me.pnlPorcentaje.Name = "pnlPorcentaje"
        Me.pnlPorcentaje.Size = New System.Drawing.Size(314, 125)
        Me.pnlPorcentaje.TabIndex = 1
        '
        'lblDatoBonoProvNuevo
        '
        Me.lblDatoBonoProvNuevo.AutoSize = True
        Me.lblDatoBonoProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoBonoProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoBonoProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoBonoProvNuevo.Location = New System.Drawing.Point(255, 102)
        Me.lblDatoBonoProvNuevo.Name = "lblDatoBonoProvNuevo"
        Me.lblDatoBonoProvNuevo.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoBonoProvNuevo.TabIndex = 86
        Me.lblDatoBonoProvNuevo.Text = "0.00"
        '
        'lblDatoBonoLimaNuevo
        '
        Me.lblDatoBonoLimaNuevo.AutoSize = True
        Me.lblDatoBonoLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoBonoLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoBonoLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoBonoLimaNuevo.Location = New System.Drawing.Point(255, 84)
        Me.lblDatoBonoLimaNuevo.Name = "lblDatoBonoLimaNuevo"
        Me.lblDatoBonoLimaNuevo.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoBonoLimaNuevo.TabIndex = 85
        Me.lblDatoBonoLimaNuevo.Text = "0.00"
        '
        'lblDatoBonoProvAnt
        '
        Me.lblDatoBonoProvAnt.AutoSize = True
        Me.lblDatoBonoProvAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoBonoProvAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoBonoProvAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoBonoProvAnt.Location = New System.Drawing.Point(255, 46)
        Me.lblDatoBonoProvAnt.Name = "lblDatoBonoProvAnt"
        Me.lblDatoBonoProvAnt.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoBonoProvAnt.TabIndex = 84
        Me.lblDatoBonoProvAnt.Text = "0.00"
        '
        'lblDatoBonoLimaAnt
        '
        Me.lblDatoBonoLimaAnt.AutoSize = True
        Me.lblDatoBonoLimaAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoBonoLimaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoBonoLimaAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoBonoLimaAnt.Location = New System.Drawing.Point(255, 28)
        Me.lblDatoBonoLimaAnt.Name = "lblDatoBonoLimaAnt"
        Me.lblDatoBonoLimaAnt.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoBonoLimaAnt.TabIndex = 83
        Me.lblDatoBonoLimaAnt.Text = "0.00"
        '
        'lblBonoProvNuevo
        '
        Me.lblBonoProvNuevo.AutoSize = True
        Me.lblBonoProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblBonoProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonoProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBonoProvNuevo.Location = New System.Drawing.Point(172, 102)
        Me.lblBonoProvNuevo.Name = "lblBonoProvNuevo"
        Me.lblBonoProvNuevo.Size = New System.Drawing.Size(77, 13)
        Me.lblBonoProvNuevo.TabIndex = 82
        Me.lblBonoProvNuevo.Text = "Bono Prov (%):"
        '
        'lblBonoLimaNuevo
        '
        Me.lblBonoLimaNuevo.AutoSize = True
        Me.lblBonoLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblBonoLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonoLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBonoLimaNuevo.Location = New System.Drawing.Point(172, 84)
        Me.lblBonoLimaNuevo.Name = "lblBonoLimaNuevo"
        Me.lblBonoLimaNuevo.Size = New System.Drawing.Size(77, 13)
        Me.lblBonoLimaNuevo.TabIndex = 81
        Me.lblBonoLimaNuevo.Text = "Bono Lima (%):"
        '
        'lblBonoProvAnt
        '
        Me.lblBonoProvAnt.AutoSize = True
        Me.lblBonoProvAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblBonoProvAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonoProvAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBonoProvAnt.Location = New System.Drawing.Point(172, 46)
        Me.lblBonoProvAnt.Name = "lblBonoProvAnt"
        Me.lblBonoProvAnt.Size = New System.Drawing.Size(77, 13)
        Me.lblBonoProvAnt.TabIndex = 80
        Me.lblBonoProvAnt.Text = "Bono Prov (%):"
        '
        'lblBonoLimaAnt
        '
        Me.lblBonoLimaAnt.AutoSize = True
        Me.lblBonoLimaAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblBonoLimaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonoLimaAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBonoLimaAnt.Location = New System.Drawing.Point(172, 28)
        Me.lblBonoLimaAnt.Name = "lblBonoLimaAnt"
        Me.lblBonoLimaAnt.Size = New System.Drawing.Size(77, 13)
        Me.lblBonoLimaAnt.TabIndex = 79
        Me.lblBonoLimaAnt.Text = "Bono Lima (%):"
        '
        'lblDatoPorcProvNuevo
        '
        Me.lblDatoPorcProvNuevo.AutoSize = True
        Me.lblDatoPorcProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoPorcProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoPorcProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoPorcProvNuevo.Location = New System.Drawing.Point(116, 102)
        Me.lblDatoPorcProvNuevo.Name = "lblDatoPorcProvNuevo"
        Me.lblDatoPorcProvNuevo.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoPorcProvNuevo.TabIndex = 78
        Me.lblDatoPorcProvNuevo.Text = "0.00"
        '
        'lblDatoPorcLimaNuevo
        '
        Me.lblDatoPorcLimaNuevo.AutoSize = True
        Me.lblDatoPorcLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoPorcLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoPorcLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoPorcLimaNuevo.Location = New System.Drawing.Point(116, 84)
        Me.lblDatoPorcLimaNuevo.Name = "lblDatoPorcLimaNuevo"
        Me.lblDatoPorcLimaNuevo.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoPorcLimaNuevo.TabIndex = 77
        Me.lblDatoPorcLimaNuevo.Text = "0.00"
        '
        'lblDatoPorcProvAnt
        '
        Me.lblDatoPorcProvAnt.AutoSize = True
        Me.lblDatoPorcProvAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoPorcProvAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoPorcProvAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoPorcProvAnt.Location = New System.Drawing.Point(116, 46)
        Me.lblDatoPorcProvAnt.Name = "lblDatoPorcProvAnt"
        Me.lblDatoPorcProvAnt.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoPorcProvAnt.TabIndex = 76
        Me.lblDatoPorcProvAnt.Text = "0.00"
        '
        'lblDatoPorcLimaAnt
        '
        Me.lblDatoPorcLimaAnt.AutoSize = True
        Me.lblDatoPorcLimaAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoPorcLimaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoPorcLimaAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoPorcLimaAnt.Location = New System.Drawing.Point(116, 28)
        Me.lblDatoPorcLimaAnt.Name = "lblDatoPorcLimaAnt"
        Me.lblDatoPorcLimaAnt.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoPorcLimaAnt.TabIndex = 75
        Me.lblDatoPorcLimaAnt.Text = "0.00"
        '
        'lblPorcentajeProvNuevo
        '
        Me.lblPorcentajeProvNuevo.AutoSize = True
        Me.lblPorcentajeProvNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblPorcentajeProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeProvNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPorcentajeProvNuevo.Location = New System.Drawing.Point(33, 102)
        Me.lblPorcentajeProvNuevo.Name = "lblPorcentajeProvNuevo"
        Me.lblPorcentajeProvNuevo.Size = New System.Drawing.Size(77, 13)
        Me.lblPorcentajeProvNuevo.TabIndex = 74
        Me.lblPorcentajeProvNuevo.Text = "Porc. Prov (%):"
        '
        'lblPorcentajeLimaNuevo
        '
        Me.lblPorcentajeLimaNuevo.AutoSize = True
        Me.lblPorcentajeLimaNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblPorcentajeLimaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeLimaNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPorcentajeLimaNuevo.Location = New System.Drawing.Point(33, 84)
        Me.lblPorcentajeLimaNuevo.Name = "lblPorcentajeLimaNuevo"
        Me.lblPorcentajeLimaNuevo.Size = New System.Drawing.Size(77, 13)
        Me.lblPorcentajeLimaNuevo.TabIndex = 73
        Me.lblPorcentajeLimaNuevo.Text = "Porc. Lima (%):"
        '
        'lblPorcentajeProvAnt
        '
        Me.lblPorcentajeProvAnt.AutoSize = True
        Me.lblPorcentajeProvAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblPorcentajeProvAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeProvAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPorcentajeProvAnt.Location = New System.Drawing.Point(33, 46)
        Me.lblPorcentajeProvAnt.Name = "lblPorcentajeProvAnt"
        Me.lblPorcentajeProvAnt.Size = New System.Drawing.Size(77, 13)
        Me.lblPorcentajeProvAnt.TabIndex = 72
        Me.lblPorcentajeProvAnt.Text = "Porc. Prov (%):"
        '
        'lblPorcentajeLimaAnt
        '
        Me.lblPorcentajeLimaAnt.AutoSize = True
        Me.lblPorcentajeLimaAnt.BackColor = System.Drawing.Color.Transparent
        Me.lblPorcentajeLimaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeLimaAnt.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPorcentajeLimaAnt.Location = New System.Drawing.Point(33, 28)
        Me.lblPorcentajeLimaAnt.Name = "lblPorcentajeLimaAnt"
        Me.lblPorcentajeLimaAnt.Size = New System.Drawing.Size(77, 13)
        Me.lblPorcentajeLimaAnt.TabIndex = 71
        Me.lblPorcentajeLimaAnt.Text = "Porc. Lima (%):"
        '
        'lblComisionPorcentajeNuevo
        '
        Me.lblComisionPorcentajeNuevo.AutoSize = True
        Me.lblComisionPorcentajeNuevo.BackColor = System.Drawing.Color.Transparent
        Me.lblComisionPorcentajeNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisionPorcentajeNuevo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblComisionPorcentajeNuevo.Location = New System.Drawing.Point(36, 66)
        Me.lblComisionPorcentajeNuevo.Name = "lblComisionPorcentajeNuevo"
        Me.lblComisionPorcentajeNuevo.Size = New System.Drawing.Size(244, 13)
        Me.lblComisionPorcentajeNuevo.TabIndex = 70
        Me.lblComisionPorcentajeNuevo.Text = "Cáculo de Comisión Desde el 26/09/2012"
        '
        'lblComisionPorcentajeAnterior
        '
        Me.lblComisionPorcentajeAnterior.AutoSize = True
        Me.lblComisionPorcentajeAnterior.BackColor = System.Drawing.Color.Transparent
        Me.lblComisionPorcentajeAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisionPorcentajeAnterior.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblComisionPorcentajeAnterior.Location = New System.Drawing.Point(39, 10)
        Me.lblComisionPorcentajeAnterior.Name = "lblComisionPorcentajeAnterior"
        Me.lblComisionPorcentajeAnterior.Size = New System.Drawing.Size(241, 13)
        Me.lblComisionPorcentajeAnterior.TabIndex = 69
        Me.lblComisionPorcentajeAnterior.Text = "Cáculo de Comisión Hasta el 26/09/2012"
        '
        'dgdRangoFuncionario
        '
        Me.dgdRangoFuncionario.AllowUserToAddRows = False
        Me.dgdRangoFuncionario.AllowUserToDeleteRows = False
        Me.dgdRangoFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdRangoFuncionario.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgdRangoFuncionario.Location = New System.Drawing.Point(3, 16)
        Me.dgdRangoFuncionario.Name = "dgdRangoFuncionario"
        Me.dgdRangoFuncionario.Size = New System.Drawing.Size(314, 160)
        Me.dgdRangoFuncionario.TabIndex = 0
        '
        'grpVenta
        '
        Me.grpVenta.Controls.Add(Me.pnlMeta)
        Me.grpVenta.Controls.Add(Me.dgdVenta)
        Me.grpVenta.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpVenta.Location = New System.Drawing.Point(0, 0)
        Me.grpVenta.Name = "grpVenta"
        Me.grpVenta.Size = New System.Drawing.Size(320, 304)
        Me.grpVenta.TabIndex = 1
        Me.grpVenta.TabStop = False
        Me.grpVenta.Text = "Venta por Funcionario"
        '
        'pnlMeta
        '
        Me.pnlMeta.Controls.Add(Me.lblDatoBaseProv)
        Me.pnlMeta.Controls.Add(Me.lblBaseProvincia)
        Me.pnlMeta.Controls.Add(Me.lblDatoBaseCalculo)
        Me.pnlMeta.Controls.Add(Me.lblBaseCalculo)
        Me.pnlMeta.Controls.Add(Me.lblDatoBaseLima)
        Me.pnlMeta.Controls.Add(Me.lblBaseLima)
        Me.pnlMeta.Controls.Add(Me.lblDatoTotalVentaProv)
        Me.pnlMeta.Controls.Add(Me.lblTotalventaProvincia)
        Me.pnlMeta.Controls.Add(Me.lblDatoMetaProv)
        Me.pnlMeta.Controls.Add(Me.lblMetaProvincia)
        Me.pnlMeta.Controls.Add(Me.lblDatoTotalVentaLima)
        Me.pnlMeta.Controls.Add(Me.lblTotalventa)
        Me.pnlMeta.Controls.Add(Me.lblMeta)
        Me.pnlMeta.Controls.Add(Me.lblDatoMetaLima)
        Me.pnlMeta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMeta.Location = New System.Drawing.Point(3, 176)
        Me.pnlMeta.Name = "pnlMeta"
        Me.pnlMeta.Size = New System.Drawing.Size(314, 125)
        Me.pnlMeta.TabIndex = 93
        '
        'lblDatoBaseProv
        '
        Me.lblDatoBaseProv.AutoSize = True
        Me.lblDatoBaseProv.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoBaseProv.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoBaseProv.Location = New System.Drawing.Point(255, 46)
        Me.lblDatoBaseProv.Name = "lblDatoBaseProv"
        Me.lblDatoBaseProv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatoBaseProv.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoBaseProv.TabIndex = 85
        Me.lblDatoBaseProv.Text = "0.00"
        Me.lblDatoBaseProv.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBaseProvincia
        '
        Me.lblBaseProvincia.AutoSize = True
        Me.lblBaseProvincia.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseProvincia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseProvincia.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBaseProvincia.Location = New System.Drawing.Point(163, 46)
        Me.lblBaseProvincia.Name = "lblBaseProvincia"
        Me.lblBaseProvincia.Size = New System.Drawing.Size(83, 13)
        Me.lblBaseProvincia.TabIndex = 84
        Me.lblBaseProvincia.Text = "Base Prov (S/.):"
        '
        'lblDatoBaseCalculo
        '
        Me.lblDatoBaseCalculo.AutoSize = True
        Me.lblDatoBaseCalculo.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoBaseCalculo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoBaseCalculo.Location = New System.Drawing.Point(100, 77)
        Me.lblDatoBaseCalculo.Name = "lblDatoBaseCalculo"
        Me.lblDatoBaseCalculo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatoBaseCalculo.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoBaseCalculo.TabIndex = 81
        Me.lblDatoBaseCalculo.Text = "0.00"
        Me.lblDatoBaseCalculo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBaseCalculo
        '
        Me.lblBaseCalculo.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseCalculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseCalculo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBaseCalculo.Location = New System.Drawing.Point(8, 75)
        Me.lblBaseCalculo.Name = "lblBaseCalculo"
        Me.lblBaseCalculo.Size = New System.Drawing.Size(70, 31)
        Me.lblBaseCalculo.TabIndex = 80
        Me.lblBaseCalculo.Text = "Base Cálculo (S/.):"
        Me.lblBaseCalculo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDatoBaseLima
        '
        Me.lblDatoBaseLima.AutoSize = True
        Me.lblDatoBaseLima.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoBaseLima.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoBaseLima.Location = New System.Drawing.Point(100, 46)
        Me.lblDatoBaseLima.Name = "lblDatoBaseLima"
        Me.lblDatoBaseLima.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatoBaseLima.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoBaseLima.TabIndex = 81
        Me.lblDatoBaseLima.Text = "0.00"
        Me.lblDatoBaseLima.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBaseLima
        '
        Me.lblBaseLima.AutoSize = True
        Me.lblBaseLima.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseLima.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseLima.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBaseLima.Location = New System.Drawing.Point(9, 46)
        Me.lblBaseLima.Name = "lblBaseLima"
        Me.lblBaseLima.Size = New System.Drawing.Size(83, 13)
        Me.lblBaseLima.TabIndex = 80
        Me.lblBaseLima.Text = "Base Lima (S/.):"
        '
        'lblDatoTotalVentaProv
        '
        Me.lblDatoTotalVentaProv.AutoSize = True
        Me.lblDatoTotalVentaProv.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoTotalVentaProv.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoTotalVentaProv.Location = New System.Drawing.Point(255, 28)
        Me.lblDatoTotalVentaProv.Name = "lblDatoTotalVentaProv"
        Me.lblDatoTotalVentaProv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatoTotalVentaProv.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoTotalVentaProv.TabIndex = 75
        Me.lblDatoTotalVentaProv.Text = "0.00"
        Me.lblDatoTotalVentaProv.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalventaProvincia
        '
        Me.lblTotalventaProvincia.AutoSize = True
        Me.lblTotalventaProvincia.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalventaProvincia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalventaProvincia.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotalventaProvincia.Location = New System.Drawing.Point(163, 28)
        Me.lblTotalventaProvincia.Name = "lblTotalventaProvincia"
        Me.lblTotalventaProvincia.Size = New System.Drawing.Size(87, 13)
        Me.lblTotalventaProvincia.TabIndex = 74
        Me.lblTotalventaProvincia.Text = "Venta Prov (S/.):"
        '
        'lblDatoMetaProv
        '
        Me.lblDatoMetaProv.AutoSize = True
        Me.lblDatoMetaProv.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoMetaProv.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoMetaProv.Location = New System.Drawing.Point(255, 10)
        Me.lblDatoMetaProv.Name = "lblDatoMetaProv"
        Me.lblDatoMetaProv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatoMetaProv.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoMetaProv.TabIndex = 73
        Me.lblDatoMetaProv.Text = "0.00"
        Me.lblDatoMetaProv.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMetaProvincia
        '
        Me.lblMetaProvincia.AutoSize = True
        Me.lblMetaProvincia.BackColor = System.Drawing.Color.Transparent
        Me.lblMetaProvincia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMetaProvincia.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMetaProvincia.Location = New System.Drawing.Point(163, 10)
        Me.lblMetaProvincia.Name = "lblMetaProvincia"
        Me.lblMetaProvincia.Size = New System.Drawing.Size(83, 13)
        Me.lblMetaProvincia.TabIndex = 72
        Me.lblMetaProvincia.Text = "Meta Prov (S/.):"
        '
        'lblDatoTotalVentaLima
        '
        Me.lblDatoTotalVentaLima.AutoSize = True
        Me.lblDatoTotalVentaLima.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoTotalVentaLima.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoTotalVentaLima.Location = New System.Drawing.Point(100, 28)
        Me.lblDatoTotalVentaLima.Name = "lblDatoTotalVentaLima"
        Me.lblDatoTotalVentaLima.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatoTotalVentaLima.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoTotalVentaLima.TabIndex = 71
        Me.lblDatoTotalVentaLima.Text = "0.00"
        Me.lblDatoTotalVentaLima.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalventa
        '
        Me.lblTotalventa.AutoSize = True
        Me.lblTotalventa.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalventa.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotalventa.Location = New System.Drawing.Point(9, 28)
        Me.lblTotalventa.Name = "lblTotalventa"
        Me.lblTotalventa.Size = New System.Drawing.Size(87, 13)
        Me.lblTotalventa.TabIndex = 70
        Me.lblTotalventa.Text = "Venta Lima (S/.):"
        '
        'lblMeta
        '
        Me.lblMeta.AutoSize = True
        Me.lblMeta.BackColor = System.Drawing.Color.Transparent
        Me.lblMeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeta.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMeta.Location = New System.Drawing.Point(9, 10)
        Me.lblMeta.Name = "lblMeta"
        Me.lblMeta.Size = New System.Drawing.Size(83, 13)
        Me.lblMeta.TabIndex = 68
        Me.lblMeta.Text = "Meta Lima (S/.):"
        '
        'lblDatoMetaLima
        '
        Me.lblDatoMetaLima.AutoSize = True
        Me.lblDatoMetaLima.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoMetaLima.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDatoMetaLima.Location = New System.Drawing.Point(100, 10)
        Me.lblDatoMetaLima.Name = "lblDatoMetaLima"
        Me.lblDatoMetaLima.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatoMetaLima.Size = New System.Drawing.Size(28, 13)
        Me.lblDatoMetaLima.TabIndex = 69
        Me.lblDatoMetaLima.Text = "0.00"
        Me.lblDatoMetaLima.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dgdVenta
        '
        Me.dgdVenta.AllowUserToAddRows = False
        Me.dgdVenta.AllowUserToDeleteRows = False
        Me.dgdVenta.AllowUserToOrderColumns = True
        Me.dgdVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVenta.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgdVenta.Location = New System.Drawing.Point(3, 16)
        Me.dgdVenta.Name = "dgdVenta"
        Me.dgdVenta.Size = New System.Drawing.Size(314, 160)
        Me.dgdVenta.TabIndex = 0
        '
        'pnlVentaCobranza
        '
        Me.pnlVentaCobranza.Controls.Add(Me.lblFuncionario)
        Me.pnlVentaCobranza.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVentaCobranza.Location = New System.Drawing.Point(237, 3)
        Me.pnlVentaCobranza.Name = "pnlVentaCobranza"
        Me.pnlVentaCobranza.Size = New System.Drawing.Size(1039, 71)
        Me.pnlVentaCobranza.TabIndex = 1
        '
        'lblFuncionario
        '
        Me.lblFuncionario.AutoSize = True
        Me.lblFuncionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionario.Location = New System.Drawing.Point(83, 25)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(225, 18)
        Me.lblFuncionario.TabIndex = 0
        Me.lblFuncionario.Text = "Codigo - Nombre de Funcionario"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.grpFuncionario)
        Me.pnlFiltros.Controls.Add(Me.grpRangoFecha)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlFiltros.Location = New System.Drawing.Point(3, 3)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(234, 578)
        Me.pnlFiltros.TabIndex = 0
        '
        'grpFuncionario
        '
        Me.grpFuncionario.Controls.Add(Me.TVFuncionario)
        Me.grpFuncionario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpFuncionario.Location = New System.Drawing.Point(0, 71)
        Me.grpFuncionario.Name = "grpFuncionario"
        Me.grpFuncionario.Size = New System.Drawing.Size(234, 507)
        Me.grpFuncionario.TabIndex = 2
        Me.grpFuncionario.TabStop = False
        Me.grpFuncionario.Text = "Funcionario"
        '
        'TVFuncionario
        '
        Me.TVFuncionario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TVFuncionario.Location = New System.Drawing.Point(3, 16)
        Me.TVFuncionario.Name = "TVFuncionario"
        Me.TVFuncionario.Size = New System.Drawing.Size(228, 488)
        Me.TVFuncionario.TabIndex = 0
        '
        'grpRangoFecha
        '
        Me.grpRangoFecha.Controls.Add(Me.DTPFechaFinal)
        Me.grpRangoFecha.Controls.Add(Me.lblFechaFinal)
        Me.grpRangoFecha.Controls.Add(Me.lblFechaIni)
        Me.grpRangoFecha.Controls.Add(Me.DTPFechaInicio)
        Me.grpRangoFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRangoFecha.Location = New System.Drawing.Point(0, 0)
        Me.grpRangoFecha.Name = "grpRangoFecha"
        Me.grpRangoFecha.Size = New System.Drawing.Size(234, 71)
        Me.grpRangoFecha.TabIndex = 1
        Me.grpRangoFecha.TabStop = False
        Me.grpRangoFecha.Text = "Rango de Fechas"
        '
        'DTPFechaFinal
        '
        Me.DTPFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFinal.Location = New System.Drawing.Point(104, 42)
        Me.DTPFechaFinal.Name = "DTPFechaFinal"
        Me.DTPFechaFinal.Size = New System.Drawing.Size(92, 20)
        Me.DTPFechaFinal.TabIndex = 3
        '
        'lblFechaFinal
        '
        Me.lblFechaFinal.AutoSize = True
        Me.lblFechaFinal.Location = New System.Drawing.Point(39, 42)
        Me.lblFechaFinal.Name = "lblFechaFinal"
        Me.lblFechaFinal.Size = New System.Drawing.Size(32, 13)
        Me.lblFechaFinal.TabIndex = 2
        Me.lblFechaFinal.Text = "Final:"
        '
        'lblFechaIni
        '
        Me.lblFechaIni.AutoSize = True
        Me.lblFechaIni.Location = New System.Drawing.Point(39, 22)
        Me.lblFechaIni.Name = "lblFechaIni"
        Me.lblFechaIni.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaIni.TabIndex = 1
        Me.lblFechaIni.Text = "Inicio:"
        '
        'DTPFechaInicio
        '
        Me.DTPFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicio.Location = New System.Drawing.Point(104, 16)
        Me.DTPFechaInicio.Name = "DTPFechaInicio"
        Me.DTPFechaInicio.Size = New System.Drawing.Size(92, 20)
        Me.DTPFechaInicio.TabIndex = 0
        '
        'TPConsultaComision
        '
        Me.TPConsultaComision.Controls.Add(Me.pnlReporte)
        Me.TPConsultaComision.Controls.Add(Me.pnlConsultaTotalComision)
        Me.TPConsultaComision.Controls.Add(Me.pnlComisionConsulta)
        Me.TPConsultaComision.Controls.Add(Me.pnlFiltroConsulta)
        Me.TPConsultaComision.Location = New System.Drawing.Point(4, 22)
        Me.TPConsultaComision.Name = "TPConsultaComision"
        Me.TPConsultaComision.Padding = New System.Windows.Forms.Padding(3)
        Me.TPConsultaComision.Size = New System.Drawing.Size(1279, 584)
        Me.TPConsultaComision.TabIndex = 1
        Me.TPConsultaComision.Text = "Consulta de Comisión"
        Me.TPConsultaComision.UseVisualStyleBackColor = True
        '
        'pnlReporte
        '
        Me.pnlReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReporte.Location = New System.Drawing.Point(576, 505)
        Me.pnlReporte.Name = "pnlReporte"
        Me.pnlReporte.Size = New System.Drawing.Size(700, 76)
        Me.pnlReporte.TabIndex = 3
        '
        'pnlConsultaTotalComision
        '
        Me.pnlConsultaTotalComision.Controls.Add(Me.lblDatoConsultaTotalComision)
        Me.pnlConsultaTotalComision.Controls.Add(Me.lblConsultaTotalComision)
        Me.pnlConsultaTotalComision.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConsultaTotalComision.Location = New System.Drawing.Point(3, 505)
        Me.pnlConsultaTotalComision.Name = "pnlConsultaTotalComision"
        Me.pnlConsultaTotalComision.Size = New System.Drawing.Size(573, 76)
        Me.pnlConsultaTotalComision.TabIndex = 2
        '
        'lblDatoConsultaTotalComision
        '
        Me.lblDatoConsultaTotalComision.AutoSize = True
        Me.lblDatoConsultaTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoConsultaTotalComision.Location = New System.Drawing.Point(504, 28)
        Me.lblDatoConsultaTotalComision.Name = "lblDatoConsultaTotalComision"
        Me.lblDatoConsultaTotalComision.Size = New System.Drawing.Size(36, 16)
        Me.lblDatoConsultaTotalComision.TabIndex = 3
        Me.lblDatoConsultaTotalComision.Text = "0.00"
        '
        'lblConsultaTotalComision
        '
        Me.lblConsultaTotalComision.AutoSize = True
        Me.lblConsultaTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsultaTotalComision.Location = New System.Drawing.Point(342, 28)
        Me.lblConsultaTotalComision.Name = "lblConsultaTotalComision"
        Me.lblConsultaTotalComision.Size = New System.Drawing.Size(149, 16)
        Me.lblConsultaTotalComision.TabIndex = 2
        Me.lblConsultaTotalComision.Text = "Total Comisión (S/.):"
        '
        'pnlComisionConsulta
        '
        Me.pnlComisionConsulta.Controls.Add(Me.grpConsultaDetalleComision)
        Me.pnlComisionConsulta.Controls.Add(Me.grpConsultaCabeceraComision)
        Me.pnlComisionConsulta.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlComisionConsulta.Location = New System.Drawing.Point(3, 55)
        Me.pnlComisionConsulta.Name = "pnlComisionConsulta"
        Me.pnlComisionConsulta.Size = New System.Drawing.Size(1273, 450)
        Me.pnlComisionConsulta.TabIndex = 1
        '
        'grpConsultaDetalleComision
        '
        Me.grpConsultaDetalleComision.Controls.Add(Me.dgdConsultaDetalleComision)
        Me.grpConsultaDetalleComision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpConsultaDetalleComision.Location = New System.Drawing.Point(0, 163)
        Me.grpConsultaDetalleComision.Name = "grpConsultaDetalleComision"
        Me.grpConsultaDetalleComision.Size = New System.Drawing.Size(1273, 287)
        Me.grpConsultaDetalleComision.TabIndex = 1
        Me.grpConsultaDetalleComision.TabStop = False
        Me.grpConsultaDetalleComision.Text = "Comisión Detallada por Funcionario"
        '
        'dgdConsultaDetalleComision
        '
        Me.dgdConsultaDetalleComision.AllowUserToAddRows = False
        Me.dgdConsultaDetalleComision.AllowUserToDeleteRows = False
        Me.dgdConsultaDetalleComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdConsultaDetalleComision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdConsultaDetalleComision.Location = New System.Drawing.Point(3, 16)
        Me.dgdConsultaDetalleComision.Name = "dgdConsultaDetalleComision"
        Me.dgdConsultaDetalleComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdConsultaDetalleComision.Size = New System.Drawing.Size(1267, 268)
        Me.dgdConsultaDetalleComision.TabIndex = 0
        '
        'grpConsultaCabeceraComision
        '
        Me.grpConsultaCabeceraComision.Controls.Add(Me.dgdConsultaCabeceraComision)
        Me.grpConsultaCabeceraComision.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpConsultaCabeceraComision.Location = New System.Drawing.Point(0, 0)
        Me.grpConsultaCabeceraComision.Name = "grpConsultaCabeceraComision"
        Me.grpConsultaCabeceraComision.Size = New System.Drawing.Size(1273, 163)
        Me.grpConsultaCabeceraComision.TabIndex = 0
        Me.grpConsultaCabeceraComision.TabStop = False
        Me.grpConsultaCabeceraComision.Text = "Comisión Procesada por Funcionario"
        '
        'dgdConsultaCabeceraComision
        '
        Me.dgdConsultaCabeceraComision.AllowUserToAddRows = False
        Me.dgdConsultaCabeceraComision.AllowUserToDeleteRows = False
        Me.dgdConsultaCabeceraComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdConsultaCabeceraComision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdConsultaCabeceraComision.Location = New System.Drawing.Point(3, 16)
        Me.dgdConsultaCabeceraComision.Name = "dgdConsultaCabeceraComision"
        Me.dgdConsultaCabeceraComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdConsultaCabeceraComision.Size = New System.Drawing.Size(1267, 144)
        Me.dgdConsultaCabeceraComision.TabIndex = 0
        '
        'pnlFiltroConsulta
        '
        Me.pnlFiltroConsulta.Controls.Add(Me.grpFiltroConsulta)
        Me.pnlFiltroConsulta.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltroConsulta.Location = New System.Drawing.Point(3, 3)
        Me.pnlFiltroConsulta.Name = "pnlFiltroConsulta"
        Me.pnlFiltroConsulta.Size = New System.Drawing.Size(1273, 52)
        Me.pnlFiltroConsulta.TabIndex = 0
        '
        'grpFiltroConsulta
        '
        Me.grpFiltroConsulta.Controls.Add(Me.DTPFechaFinalConsulta)
        Me.grpFiltroConsulta.Controls.Add(Me.lblFechaFinalConsulta)
        Me.grpFiltroConsulta.Controls.Add(Me.DTPFechaInicioConsulta)
        Me.grpFiltroConsulta.Controls.Add(Me.lblFechaInicioConsulta)
        Me.grpFiltroConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpFiltroConsulta.Location = New System.Drawing.Point(0, 0)
        Me.grpFiltroConsulta.Name = "grpFiltroConsulta"
        Me.grpFiltroConsulta.Size = New System.Drawing.Size(1273, 52)
        Me.grpFiltroConsulta.TabIndex = 0
        Me.grpFiltroConsulta.TabStop = False
        Me.grpFiltroConsulta.Text = "Filtros Consulta"
        '
        'DTPFechaFinalConsulta
        '
        Me.DTPFechaFinalConsulta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFinalConsulta.Location = New System.Drawing.Point(236, 16)
        Me.DTPFechaFinalConsulta.Name = "DTPFechaFinalConsulta"
        Me.DTPFechaFinalConsulta.Size = New System.Drawing.Size(92, 20)
        Me.DTPFechaFinalConsulta.TabIndex = 3
        '
        'lblFechaFinalConsulta
        '
        Me.lblFechaFinalConsulta.AutoSize = True
        Me.lblFechaFinalConsulta.Location = New System.Drawing.Point(198, 20)
        Me.lblFechaFinalConsulta.Name = "lblFechaFinalConsulta"
        Me.lblFechaFinalConsulta.Size = New System.Drawing.Size(32, 13)
        Me.lblFechaFinalConsulta.TabIndex = 2
        Me.lblFechaFinalConsulta.Text = "Final:"
        '
        'DTPFechaInicioConsulta
        '
        Me.DTPFechaInicioConsulta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicioConsulta.Location = New System.Drawing.Point(84, 16)
        Me.DTPFechaInicioConsulta.Name = "DTPFechaInicioConsulta"
        Me.DTPFechaInicioConsulta.Size = New System.Drawing.Size(92, 20)
        Me.DTPFechaInicioConsulta.TabIndex = 1
        '
        'lblFechaInicioConsulta
        '
        Me.lblFechaInicioConsulta.AutoSize = True
        Me.lblFechaInicioConsulta.Location = New System.Drawing.Point(38, 20)
        Me.lblFechaInicioConsulta.Name = "lblFechaInicioConsulta"
        Me.lblFechaInicioConsulta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaInicioConsulta.TabIndex = 0
        Me.lblFechaInicioConsulta.Text = "Inicio:"
        '
        'frmComisionPasajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 685)
        Me.Controls.Add(Me.TCComisionPasajes)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "frmComisionPasajes"
        Me.Text = "frmComisionPasajes"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnlBarra.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TCComisionPasajes.ResumeLayout(False)
        Me.TPCalculoComision.ResumeLayout(False)
        Me.pnlCalculoComision.ResumeLayout(False)
        Me.grpComision.ResumeLayout(False)
        Me.pnlTotalComision.ResumeLayout(False)
        Me.pnlTotalComision.PerformLayout()
        CType(Me.dgdComision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProcesoComision.ResumeLayout(False)
        Me.grpCobranza.ResumeLayout(False)
        Me.pnlCobranza.ResumeLayout(False)
        Me.pnlCobranza.PerformLayout()
        CType(Me.dgdCobranza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetaFuncionario.ResumeLayout(False)
        Me.pnlPorcentaje.ResumeLayout(False)
        Me.pnlPorcentaje.PerformLayout()
        CType(Me.dgdRangoFuncionario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVenta.ResumeLayout(False)
        Me.pnlMeta.ResumeLayout(False)
        Me.pnlMeta.PerformLayout()
        CType(Me.dgdVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVentaCobranza.ResumeLayout(False)
        Me.pnlVentaCobranza.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.grpFuncionario.ResumeLayout(False)
        Me.grpRangoFecha.ResumeLayout(False)
        Me.grpRangoFecha.PerformLayout()
        Me.TPConsultaComision.ResumeLayout(False)
        Me.pnlConsultaTotalComision.ResumeLayout(False)
        Me.pnlConsultaTotalComision.PerformLayout()
        Me.pnlComisionConsulta.ResumeLayout(False)
        Me.grpConsultaDetalleComision.ResumeLayout(False)
        CType(Me.dgdConsultaDetalleComision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpConsultaCabeceraComision.ResumeLayout(False)
        CType(Me.dgdConsultaCabeceraComision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltroConsulta.ResumeLayout(False)
        Me.grpFiltroConsulta.ResumeLayout(False)
        Me.grpFiltroConsulta.PerformLayout()
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
    Protected WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TCComisionPasajes As System.Windows.Forms.TabControl
    Friend WithEvents TPCalculoComision As System.Windows.Forms.TabPage
    Friend WithEvents TPConsultaComision As System.Windows.Forms.TabPage
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents TVFuncionario As System.Windows.Forms.TreeView
    Friend WithEvents grpRangoFecha As System.Windows.Forms.GroupBox
    Friend WithEvents grpFuncionario As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
    Friend WithEvents lblFechaIni As System.Windows.Forms.Label
    Friend WithEvents DTPFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlVentaCobranza As System.Windows.Forms.Panel
    Friend WithEvents pnlProcesoComision As System.Windows.Forms.Panel
    Friend WithEvents grpVenta As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMeta As System.Windows.Forms.Panel
    Friend WithEvents lblDatoTotalVentaProv As System.Windows.Forms.Label
    Friend WithEvents lblTotalventaProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDatoMetaProv As System.Windows.Forms.Label
    Friend WithEvents lblMetaProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDatoTotalVentaLima As System.Windows.Forms.Label
    Friend WithEvents lblTotalventa As System.Windows.Forms.Label
    Friend WithEvents lblMeta As System.Windows.Forms.Label
    Friend WithEvents lblDatoMetaLima As System.Windows.Forms.Label
    Friend WithEvents dgdVenta As System.Windows.Forms.DataGridView
    Friend WithEvents lblFuncionario As System.Windows.Forms.Label
    Friend WithEvents lblDatoBaseProv As System.Windows.Forms.Label
    Friend WithEvents lblBaseProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDatoBaseLima As System.Windows.Forms.Label
    Friend WithEvents lblBaseLima As System.Windows.Forms.Label
    Friend WithEvents GrpMetaFuncionario As System.Windows.Forms.GroupBox
    Friend WithEvents dgdRangoFuncionario As System.Windows.Forms.DataGridView
    Friend WithEvents pnlPorcentaje As System.Windows.Forms.Panel
    Friend WithEvents lblComisionPorcentajeNuevo As System.Windows.Forms.Label
    Friend WithEvents lblComisionPorcentajeAnterior As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeProvAnt As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeLimaAnt As System.Windows.Forms.Label
    Friend WithEvents lblDatoPorcLimaAnt As System.Windows.Forms.Label
    Friend WithEvents lblDatoPorcProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoPorcLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoPorcProvAnt As System.Windows.Forms.Label
    Friend WithEvents lblBonoProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblBonoLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents lblBonoProvAnt As System.Windows.Forms.Label
    Friend WithEvents lblBonoLimaAnt As System.Windows.Forms.Label
    Friend WithEvents lblDatoBonoProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoBonoLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoBonoProvAnt As System.Windows.Forms.Label
    Friend WithEvents lblDatoBonoLimaAnt As System.Windows.Forms.Label
    Friend WithEvents grpCobranza As System.Windows.Forms.GroupBox
    Friend WithEvents dgdCobranza As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCobranza As System.Windows.Forms.Panel
    Friend WithEvents lblComisionDocumentoAnterior As System.Windows.Forms.Label
    Friend WithEvents lblCantDocLimaAnterior As System.Windows.Forms.Label
    Friend WithEvents lblDatoCantDocLimaAnt As System.Windows.Forms.Label
    Friend WithEvents lblCobroDocLimaAnt As System.Windows.Forms.Label
    Friend WithEvents lblCantDocProvAnterior As System.Windows.Forms.Label
    Friend WithEvents lblDatoCantDocProvAnt As System.Windows.Forms.Label
    Friend WithEvents lblCobroDocProvAnt As System.Windows.Forms.Label
    Friend WithEvents lblDatoCobroDocLimaAnt As System.Windows.Forms.Label
    Friend WithEvents lblDatoCobroDocProvAnt As System.Windows.Forms.Label
    Friend WithEvents lblComisionDocumentoNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoCantDocLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents lblCantDocProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblCantDocLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoCantDocProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblCobroDocProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblCobroDocLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoCobroDocProvNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDatoCobroDocLimaNuevo As System.Windows.Forms.Label
    Friend WithEvents pnlCalculoComision As System.Windows.Forms.Panel
    Friend WithEvents grpComision As System.Windows.Forms.GroupBox
    Friend WithEvents dgdComision As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTotalComision As System.Windows.Forms.Panel
    Friend WithEvents lblDatoTotalComision As System.Windows.Forms.Label
    Friend WithEvents lblTotalComision As System.Windows.Forms.Label
    Friend WithEvents pnlFiltroConsulta As System.Windows.Forms.Panel
    Friend WithEvents grpFiltroConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaInicioConsulta As System.Windows.Forms.Label
    Friend WithEvents lblFechaFinalConsulta As System.Windows.Forms.Label
    Friend WithEvents DTPFechaInicioConsulta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaFinalConsulta As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlComisionConsulta As System.Windows.Forms.Panel
    Friend WithEvents grpConsultaCabeceraComision As System.Windows.Forms.GroupBox
    Friend WithEvents dgdConsultaCabeceraComision As System.Windows.Forms.DataGridView
    Friend WithEvents grpConsultaDetalleComision As System.Windows.Forms.GroupBox
    Friend WithEvents dgdConsultaDetalleComision As System.Windows.Forms.DataGridView
    Friend WithEvents ConsultarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlConsultaTotalComision As System.Windows.Forms.Panel
    Friend WithEvents lblDatoConsultaTotalComision As System.Windows.Forms.Label
    Friend WithEvents lblConsultaTotalComision As System.Windows.Forms.Label
    Friend WithEvents pnlReporte As System.Windows.Forms.Panel
    Friend WithEvents ReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CierreComisionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDatoBaseCalculo As System.Windows.Forms.Label
    Friend WithEvents lblBaseCalculo As System.Windows.Forms.Label
End Class
