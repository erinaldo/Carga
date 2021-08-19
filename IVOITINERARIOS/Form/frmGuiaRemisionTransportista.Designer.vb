<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemisionTransportista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemisionTransportista))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripmenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreComisionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCGuiaRemisionTransportista = New System.Windows.Forms.TabControl()
        Me.TPListaGuiaRemision = New System.Windows.Forms.TabPage()
        Me.pnlListadoGuiaRemision = New System.Windows.Forms.Panel()
        Me.grpListadoGuiaRemision = New System.Windows.Forms.GroupBox()
        Me.dgdListadoGuiasRemision = New System.Windows.Forms.DataGridView()
        Me.pnlConsultaGuiaRemision = New System.Windows.Forms.Panel()
        Me.grpConsultaGuiaRemision = New System.Windows.Forms.GroupBox()
        Me.optManifiestoCarga = New System.Windows.Forms.RadioButton()
        Me.optGuiaRemision = New System.Windows.Forms.RadioButton()
        Me.cboUnidadAgenciaDestino = New System.Windows.Forms.ComboBox()
        Me.lblUnidadAgenciaDestino = New System.Windows.Forms.Label()
        Me.cboAgenciaOrigen = New System.Windows.Forms.ComboBox()
        Me.lblAgenciaOrigen = New System.Windows.Forms.Label()
        Me.dtpFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaProgramada = New System.Windows.Forms.Label()
        Me.cboUnidadAgenciaOrigen = New System.Windows.Forms.ComboBox()
        Me.lblUnidadAgenciaOrigen = New System.Windows.Forms.Label()
        Me.TPGenerarGuiaRemision = New System.Windows.Forms.TabPage()
        Me.grpCorrelativo = New System.Windows.Forms.GroupBox()
        Me.lblNroGuiaRemision = New System.Windows.Forms.Label()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TCGuiaRemisionTransportista.SuspendLayout()
        Me.TPListaGuiaRemision.SuspendLayout()
        Me.pnlListadoGuiaRemision.SuspendLayout()
        Me.grpListadoGuiaRemision.SuspendLayout()
        CType(Me.dgdListadoGuiasRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsultaGuiaRemision.SuspendLayout()
        Me.grpConsultaGuiaRemision.SuspendLayout()
        Me.TPGenerarGuiaRemision.SuspendLayout()
        Me.grpCorrelativo.SuspendLayout()
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
        Me.pnlTitulo.TabIndex = 3
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
        Me.lblTitulo.Size = New System.Drawing.Size(325, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "GUIA DE REMISION DE TRANSPORTISTA"
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
        Me.pnlBarra.TabIndex = 4
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EdicionToolStripMenuItem, Me.GrabarToolStripMenuItem, Me.AnularToolStripMenuItem, Me.CancelarToolStripmenuItem, Me.ExportarToolStripMenuItem, Me.ConsultarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ReporteToolStripMenuItem, Me.CierreComisionesToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = CType(resources.GetObject("AnularToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(78, 33)
        Me.AnularToolStripMenuItem.Text = "&Anular"
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
        'ConsultarToolStripMenuItem
        '
        Me.ConsultarToolStripMenuItem.Image = CType(resources.GetObject("ConsultarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConsultarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConsultarToolStripMenuItem.Name = "ConsultarToolStripMenuItem"
        Me.ConsultarToolStripMenuItem.Size = New System.Drawing.Size(94, 33)
        Me.ConsultarToolStripMenuItem.Text = "Consultar"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = CType(resources.GetObject("ImprimirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(89, 33)
        Me.ImprimirToolStripMenuItem.Text = "Im&primir"
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
        'TCGuiaRemisionTransportista
        '
        Me.TCGuiaRemisionTransportista.Controls.Add(Me.TPListaGuiaRemision)
        Me.TCGuiaRemisionTransportista.Controls.Add(Me.TPGenerarGuiaRemision)
        Me.TCGuiaRemisionTransportista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCGuiaRemisionTransportista.Location = New System.Drawing.Point(0, 75)
        Me.TCGuiaRemisionTransportista.Name = "TCGuiaRemisionTransportista"
        Me.TCGuiaRemisionTransportista.SelectedIndex = 0
        Me.TCGuiaRemisionTransportista.Size = New System.Drawing.Size(1292, 610)
        Me.TCGuiaRemisionTransportista.TabIndex = 5
        '
        'TPListaGuiaRemision
        '
        Me.TPListaGuiaRemision.Controls.Add(Me.pnlListadoGuiaRemision)
        Me.TPListaGuiaRemision.Controls.Add(Me.pnlConsultaGuiaRemision)
        Me.TPListaGuiaRemision.Location = New System.Drawing.Point(4, 22)
        Me.TPListaGuiaRemision.Name = "TPListaGuiaRemision"
        Me.TPListaGuiaRemision.Padding = New System.Windows.Forms.Padding(3)
        Me.TPListaGuiaRemision.Size = New System.Drawing.Size(1284, 584)
        Me.TPListaGuiaRemision.TabIndex = 0
        Me.TPListaGuiaRemision.Text = "Listar Guias de Remisión de Transportista"
        Me.TPListaGuiaRemision.UseVisualStyleBackColor = True
        '
        'pnlListadoGuiaRemision
        '
        Me.pnlListadoGuiaRemision.Controls.Add(Me.grpListadoGuiaRemision)
        Me.pnlListadoGuiaRemision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListadoGuiaRemision.Location = New System.Drawing.Point(3, 73)
        Me.pnlListadoGuiaRemision.Name = "pnlListadoGuiaRemision"
        Me.pnlListadoGuiaRemision.Size = New System.Drawing.Size(1278, 508)
        Me.pnlListadoGuiaRemision.TabIndex = 2
        '
        'grpListadoGuiaRemision
        '
        Me.grpListadoGuiaRemision.Controls.Add(Me.dgdListadoGuiasRemision)
        Me.grpListadoGuiaRemision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpListadoGuiaRemision.Location = New System.Drawing.Point(0, 0)
        Me.grpListadoGuiaRemision.Name = "grpListadoGuiaRemision"
        Me.grpListadoGuiaRemision.Size = New System.Drawing.Size(1278, 508)
        Me.grpListadoGuiaRemision.TabIndex = 0
        Me.grpListadoGuiaRemision.TabStop = False
        Me.grpListadoGuiaRemision.Text = "Listado de Guías de Remisión"
        '
        'dgdListadoGuiasRemision
        '
        Me.dgdListadoGuiasRemision.AllowUserToAddRows = False
        Me.dgdListadoGuiasRemision.AllowUserToDeleteRows = False
        Me.dgdListadoGuiasRemision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdListadoGuiasRemision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdListadoGuiasRemision.Location = New System.Drawing.Point(3, 16)
        Me.dgdListadoGuiasRemision.Name = "dgdListadoGuiasRemision"
        Me.dgdListadoGuiasRemision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdListadoGuiasRemision.Size = New System.Drawing.Size(1272, 489)
        Me.dgdListadoGuiasRemision.TabIndex = 0
        '
        'pnlConsultaGuiaRemision
        '
        Me.pnlConsultaGuiaRemision.Controls.Add(Me.grpConsultaGuiaRemision)
        Me.pnlConsultaGuiaRemision.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConsultaGuiaRemision.Location = New System.Drawing.Point(3, 3)
        Me.pnlConsultaGuiaRemision.Name = "pnlConsultaGuiaRemision"
        Me.pnlConsultaGuiaRemision.Size = New System.Drawing.Size(1278, 70)
        Me.pnlConsultaGuiaRemision.TabIndex = 1
        '
        'grpConsultaGuiaRemision
        '
        Me.grpConsultaGuiaRemision.Controls.Add(Me.optManifiestoCarga)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.optGuiaRemision)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.cboUnidadAgenciaDestino)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.lblUnidadAgenciaDestino)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.cboAgenciaOrigen)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.lblAgenciaOrigen)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.dtpFechaSalida)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.lblFechaProgramada)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.cboUnidadAgenciaOrigen)
        Me.grpConsultaGuiaRemision.Controls.Add(Me.lblUnidadAgenciaOrigen)
        Me.grpConsultaGuiaRemision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpConsultaGuiaRemision.Location = New System.Drawing.Point(0, 0)
        Me.grpConsultaGuiaRemision.Name = "grpConsultaGuiaRemision"
        Me.grpConsultaGuiaRemision.Size = New System.Drawing.Size(1278, 70)
        Me.grpConsultaGuiaRemision.TabIndex = 0
        Me.grpConsultaGuiaRemision.TabStop = False
        Me.grpConsultaGuiaRemision.Text = "Parametros de Consulta de Guías de Remisión"
        '
        'optManifiestoCarga
        '
        Me.optManifiestoCarga.AutoSize = True
        Me.optManifiestoCarga.Location = New System.Drawing.Point(1190, 24)
        Me.optManifiestoCarga.Name = "optManifiestoCarga"
        Me.optManifiestoCarga.Size = New System.Drawing.Size(119, 17)
        Me.optManifiestoCarga.TabIndex = 9
        Me.optManifiestoCarga.Text = "Manifiesto de Carga"
        Me.optManifiestoCarga.UseVisualStyleBackColor = True
        '
        'optGuiaRemision
        '
        Me.optGuiaRemision.AutoSize = True
        Me.optGuiaRemision.Checked = True
        Me.optGuiaRemision.Location = New System.Drawing.Point(1085, 24)
        Me.optGuiaRemision.Name = "optGuiaRemision"
        Me.optGuiaRemision.Size = New System.Drawing.Size(95, 17)
        Me.optGuiaRemision.TabIndex = 8
        Me.optGuiaRemision.TabStop = True
        Me.optGuiaRemision.Text = "Guía Remisión"
        Me.optGuiaRemision.UseVisualStyleBackColor = True
        '
        'cboUnidadAgenciaDestino
        '
        Me.cboUnidadAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadAgenciaDestino.FormattingEnabled = True
        Me.cboUnidadAgenciaDestino.Location = New System.Drawing.Point(659, 24)
        Me.cboUnidadAgenciaDestino.Name = "cboUnidadAgenciaDestino"
        Me.cboUnidadAgenciaDestino.Size = New System.Drawing.Size(170, 21)
        Me.cboUnidadAgenciaDestino.TabIndex = 7
        '
        'lblUnidadAgenciaDestino
        '
        Me.lblUnidadAgenciaDestino.AutoSize = True
        Me.lblUnidadAgenciaDestino.Location = New System.Drawing.Point(559, 28)
        Me.lblUnidadAgenciaDestino.Name = "lblUnidadAgenciaDestino"
        Me.lblUnidadAgenciaDestino.Size = New System.Drawing.Size(97, 13)
        Me.lblUnidadAgenciaDestino.TabIndex = 6
        Me.lblUnidadAgenciaDestino.Text = "Ciudad de Destino:"
        '
        'cboAgenciaOrigen
        '
        Me.cboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgenciaOrigen.FormattingEnabled = True
        Me.cboAgenciaOrigen.Location = New System.Drawing.Point(373, 24)
        Me.cboAgenciaOrigen.Name = "cboAgenciaOrigen"
        Me.cboAgenciaOrigen.Size = New System.Drawing.Size(170, 21)
        Me.cboAgenciaOrigen.TabIndex = 5
        '
        'lblAgenciaOrigen
        '
        Me.lblAgenciaOrigen.AutoSize = True
        Me.lblAgenciaOrigen.Location = New System.Drawing.Point(288, 28)
        Me.lblAgenciaOrigen.Name = "lblAgenciaOrigen"
        Me.lblAgenciaOrigen.Size = New System.Drawing.Size(83, 13)
        Me.lblAgenciaOrigen.TabIndex = 4
        Me.lblAgenciaOrigen.Text = "Agencia Origen:"
        '
        'dtpFechaSalida
        '
        Me.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSalida.Location = New System.Drawing.Point(940, 24)
        Me.dtpFechaSalida.Name = "dtpFechaSalida"
        Me.dtpFechaSalida.Size = New System.Drawing.Size(127, 20)
        Me.dtpFechaSalida.TabIndex = 3
        '
        'lblFechaProgramada
        '
        Me.lblFechaProgramada.AutoSize = True
        Me.lblFechaProgramada.Location = New System.Drawing.Point(846, 28)
        Me.lblFechaProgramada.Name = "lblFechaProgramada"
        Me.lblFechaProgramada.Size = New System.Drawing.Size(87, 13)
        Me.lblFechaProgramada.TabIndex = 2
        Me.lblFechaProgramada.Text = "Fecha de Salida:"
        '
        'cboUnidadAgenciaOrigen
        '
        Me.cboUnidadAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadAgenciaOrigen.FormattingEnabled = True
        Me.cboUnidadAgenciaOrigen.Location = New System.Drawing.Point(102, 24)
        Me.cboUnidadAgenciaOrigen.Name = "cboUnidadAgenciaOrigen"
        Me.cboUnidadAgenciaOrigen.Size = New System.Drawing.Size(170, 21)
        Me.cboUnidadAgenciaOrigen.TabIndex = 1
        '
        'lblUnidadAgenciaOrigen
        '
        Me.lblUnidadAgenciaOrigen.AutoSize = True
        Me.lblUnidadAgenciaOrigen.Location = New System.Drawing.Point(9, 28)
        Me.lblUnidadAgenciaOrigen.Name = "lblUnidadAgenciaOrigen"
        Me.lblUnidadAgenciaOrigen.Size = New System.Drawing.Size(92, 13)
        Me.lblUnidadAgenciaOrigen.TabIndex = 0
        Me.lblUnidadAgenciaOrigen.Text = "Ciudad de Origen:"
        '
        'TPGenerarGuiaRemision
        '
        Me.TPGenerarGuiaRemision.Controls.Add(Me.grpCorrelativo)
        Me.TPGenerarGuiaRemision.Location = New System.Drawing.Point(4, 22)
        Me.TPGenerarGuiaRemision.Name = "TPGenerarGuiaRemision"
        Me.TPGenerarGuiaRemision.Padding = New System.Windows.Forms.Padding(3)
        Me.TPGenerarGuiaRemision.Size = New System.Drawing.Size(1284, 584)
        Me.TPGenerarGuiaRemision.TabIndex = 1
        Me.TPGenerarGuiaRemision.Text = "Generación de Guía de Remisión de Transportista"
        Me.TPGenerarGuiaRemision.UseVisualStyleBackColor = True
        '
        'grpCorrelativo
        '
        Me.grpCorrelativo.Controls.Add(Me.lblNroGuiaRemision)
        Me.grpCorrelativo.Location = New System.Drawing.Point(17, 17)
        Me.grpCorrelativo.Name = "grpCorrelativo"
        Me.grpCorrelativo.Size = New System.Drawing.Size(335, 105)
        Me.grpCorrelativo.TabIndex = 0
        Me.grpCorrelativo.TabStop = False
        Me.grpCorrelativo.Text = "Nro. Guia Transportista"
        '
        'lblNroGuiaRemision
        '
        Me.lblNroGuiaRemision.AutoSize = True
        Me.lblNroGuiaRemision.Location = New System.Drawing.Point(36, 31)
        Me.lblNroGuiaRemision.Name = "lblNroGuiaRemision"
        Me.lblNroGuiaRemision.Size = New System.Drawing.Size(76, 13)
        Me.lblNroGuiaRemision.TabIndex = 0
        Me.lblNroGuiaRemision.Text = "000 - 0000000"
        '
        'frmGuiaRemisionTransportista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1292, 685)
        Me.Controls.Add(Me.TCGuiaRemisionTransportista)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "frmGuiaRemisionTransportista"
        Me.Text = "frmGuiaRemisionTransportista"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnlBarra.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TCGuiaRemisionTransportista.ResumeLayout(False)
        Me.TPListaGuiaRemision.ResumeLayout(False)
        Me.pnlListadoGuiaRemision.ResumeLayout(False)
        Me.grpListadoGuiaRemision.ResumeLayout(False)
        CType(Me.dgdListadoGuiasRemision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsultaGuiaRemision.ResumeLayout(False)
        Me.grpConsultaGuiaRemision.ResumeLayout(False)
        Me.grpConsultaGuiaRemision.PerformLayout()
        Me.TPGenerarGuiaRemision.ResumeLayout(False)
        Me.grpCorrelativo.ResumeLayout(False)
        Me.grpCorrelativo.PerformLayout()
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
    Protected WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripmenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents TCGuiaRemisionTransportista As System.Windows.Forms.TabControl
    Friend WithEvents TPListaGuiaRemision As System.Windows.Forms.TabPage
    Friend WithEvents TPGenerarGuiaRemision As System.Windows.Forms.TabPage
    Friend WithEvents pnlConsultaGuiaRemision As System.Windows.Forms.Panel
    Friend WithEvents grpConsultaGuiaRemision As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaProgramada As System.Windows.Forms.Label
    Friend WithEvents cboUnidadAgenciaOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnidadAgenciaOrigen As System.Windows.Forms.Label
    Friend WithEvents cboAgenciaOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgenciaOrigen As System.Windows.Forms.Label
    Friend WithEvents cboUnidadAgenciaDestino As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnidadAgenciaDestino As System.Windows.Forms.Label
    Friend WithEvents optManifiestoCarga As System.Windows.Forms.RadioButton
    Friend WithEvents optGuiaRemision As System.Windows.Forms.RadioButton
    Friend WithEvents pnlListadoGuiaRemision As System.Windows.Forms.Panel
    Friend WithEvents grpListadoGuiaRemision As System.Windows.Forms.GroupBox
    Friend WithEvents dgdListadoGuiasRemision As System.Windows.Forms.DataGridView
    Friend WithEvents grpCorrelativo As System.Windows.Forms.GroupBox
    Friend WithEvents lblNroGuiaRemision As System.Windows.Forms.Label
End Class
