<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoCheckpoint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoCheckpoint))
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
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreComisionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCCheckpoint = New System.Windows.Forms.TabControl()
        Me.TPConsultaCheckpoint = New System.Windows.Forms.TabPage()
        Me.grpCheckpointConfigurado = New System.Windows.Forms.GroupBox()
        Me.dgdCheckpointConfigurado = New System.Windows.Forms.DataGridView()
        Me.grpListaCheckpoint = New System.Windows.Forms.GroupBox()
        Me.dgdCheckpoint = New System.Windows.Forms.DataGridView()
        Me.TPMantenimientoCheckpoint = New System.Windows.Forms.TabPage()
        Me.pnlConfiguracion = New System.Windows.Forms.Panel()
        Me.grpConfiguracion = New System.Windows.Forms.GroupBox()
        Me.pnlConfigurarPrecedencia = New System.Windows.Forms.Panel()
        Me.dgdPrecedencia = New System.Windows.Forms.DataGridView()
        Me.pnlConfigurarVisibilidad = New System.Windows.Forms.Panel()
        Me.chkVisibleCliente = New System.Windows.Forms.CheckBox()
        Me.txtDescripcionUsuario = New System.Windows.Forms.TextBox()
        Me.chkVisibleUsuario = New System.Windows.Forms.CheckBox()
        Me.lblDescripcionUsuario = New System.Windows.Forms.Label()
        Me.txtDescripcionWeb = New System.Windows.Forms.TextBox()
        Me.lblDescripciónWeb = New System.Windows.Forms.Label()
        Me.pnlDatosGenerales = New System.Windows.Forms.Panel()
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtAbreviatura = New System.Windows.Forms.TextBox()
        Me.lblAbreviacion = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cboProceso = New System.Windows.Forms.ComboBox()
        Me.lblProceso = New System.Windows.Forms.Label()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TCCheckpoint.SuspendLayout()
        Me.TPConsultaCheckpoint.SuspendLayout()
        Me.grpCheckpointConfigurado.SuspendLayout()
        CType(Me.dgdCheckpointConfigurado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpListaCheckpoint.SuspendLayout()
        CType(Me.dgdCheckpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPMantenimientoCheckpoint.SuspendLayout()
        Me.pnlConfiguracion.SuspendLayout()
        Me.grpConfiguracion.SuspendLayout()
        Me.pnlConfigurarPrecedencia.SuspendLayout()
        CType(Me.dgdPrecedencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConfigurarVisibilidad.SuspendLayout()
        Me.pnlDatosGenerales.SuspendLayout()
        Me.grpDatosGenerales.SuspendLayout()
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
        Me.pnlTitulo.TabIndex = 2
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
        Me.lblTitulo.Size = New System.Drawing.Size(274, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "MANTENIMIENTO DE CHECKPOINT"
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
        Me.pnlBarra.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EdicionToolStripMenuItem, Me.GrabarToolStripMenuItem, Me.AnularToolStripMenuItem, Me.CancelarToolStripmenuItem, Me.ExportarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ConsultarToolStripMenuItem, Me.ReporteToolStripMenuItem, Me.CierreComisionesToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        Me.WordToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
        Me.WordToolStripMenuItem.Text = "Word"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = CType(resources.GetObject("ExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Image = CType(resources.GetObject("PDFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PDFToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'EmailToolStripMenuItem
        '
        Me.EmailToolStripMenuItem.Image = CType(resources.GetObject("EmailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EmailToolStripMenuItem.Name = "EmailToolStripMenuItem"
        Me.EmailToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
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
        'TCCheckpoint
        '
        Me.TCCheckpoint.Controls.Add(Me.TPConsultaCheckpoint)
        Me.TCCheckpoint.Controls.Add(Me.TPMantenimientoCheckpoint)
        Me.TCCheckpoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCCheckpoint.Location = New System.Drawing.Point(0, 75)
        Me.TCCheckpoint.Name = "TCCheckpoint"
        Me.TCCheckpoint.SelectedIndex = 0
        Me.TCCheckpoint.Size = New System.Drawing.Size(1287, 610)
        Me.TCCheckpoint.TabIndex = 4
        '
        'TPConsultaCheckpoint
        '
        Me.TPConsultaCheckpoint.Controls.Add(Me.grpCheckpointConfigurado)
        Me.TPConsultaCheckpoint.Controls.Add(Me.grpListaCheckpoint)
        Me.TPConsultaCheckpoint.Location = New System.Drawing.Point(4, 22)
        Me.TPConsultaCheckpoint.Name = "TPConsultaCheckpoint"
        Me.TPConsultaCheckpoint.Padding = New System.Windows.Forms.Padding(3)
        Me.TPConsultaCheckpoint.Size = New System.Drawing.Size(1279, 584)
        Me.TPConsultaCheckpoint.TabIndex = 0
        Me.TPConsultaCheckpoint.Text = "Listado de Checkpoint"
        Me.TPConsultaCheckpoint.UseVisualStyleBackColor = True
        '
        'grpCheckpointConfigurado
        '
        Me.grpCheckpointConfigurado.Controls.Add(Me.dgdCheckpointConfigurado)
        Me.grpCheckpointConfigurado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCheckpointConfigurado.Location = New System.Drawing.Point(3, 401)
        Me.grpCheckpointConfigurado.Name = "grpCheckpointConfigurado"
        Me.grpCheckpointConfigurado.Size = New System.Drawing.Size(1273, 180)
        Me.grpCheckpointConfigurado.TabIndex = 1
        Me.grpCheckpointConfigurado.TabStop = False
        Me.grpCheckpointConfigurado.Text = "Detalle Checkpoint Configurados"
        '
        'dgdCheckpointConfigurado
        '
        Me.dgdCheckpointConfigurado.AllowUserToAddRows = False
        Me.dgdCheckpointConfigurado.AllowUserToDeleteRows = False
        Me.dgdCheckpointConfigurado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCheckpointConfigurado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdCheckpointConfigurado.Location = New System.Drawing.Point(3, 16)
        Me.dgdCheckpointConfigurado.Name = "dgdCheckpointConfigurado"
        Me.dgdCheckpointConfigurado.Size = New System.Drawing.Size(1267, 161)
        Me.dgdCheckpointConfigurado.TabIndex = 0
        '
        'grpListaCheckpoint
        '
        Me.grpListaCheckpoint.Controls.Add(Me.dgdCheckpoint)
        Me.grpListaCheckpoint.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpListaCheckpoint.Location = New System.Drawing.Point(3, 3)
        Me.grpListaCheckpoint.Name = "grpListaCheckpoint"
        Me.grpListaCheckpoint.Size = New System.Drawing.Size(1273, 398)
        Me.grpListaCheckpoint.TabIndex = 0
        Me.grpListaCheckpoint.TabStop = False
        Me.grpListaCheckpoint.Text = "Listado de Checkpoint"
        '
        'dgdCheckpoint
        '
        Me.dgdCheckpoint.AllowUserToAddRows = False
        Me.dgdCheckpoint.AllowUserToDeleteRows = False
        Me.dgdCheckpoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCheckpoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdCheckpoint.Location = New System.Drawing.Point(3, 16)
        Me.dgdCheckpoint.MultiSelect = False
        Me.dgdCheckpoint.Name = "dgdCheckpoint"
        Me.dgdCheckpoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdCheckpoint.Size = New System.Drawing.Size(1267, 379)
        Me.dgdCheckpoint.TabIndex = 0
        '
        'TPMantenimientoCheckpoint
        '
        Me.TPMantenimientoCheckpoint.Controls.Add(Me.pnlConfiguracion)
        Me.TPMantenimientoCheckpoint.Controls.Add(Me.pnlDatosGenerales)
        Me.TPMantenimientoCheckpoint.Location = New System.Drawing.Point(4, 22)
        Me.TPMantenimientoCheckpoint.Name = "TPMantenimientoCheckpoint"
        Me.TPMantenimientoCheckpoint.Padding = New System.Windows.Forms.Padding(3)
        Me.TPMantenimientoCheckpoint.Size = New System.Drawing.Size(1279, 584)
        Me.TPMantenimientoCheckpoint.TabIndex = 1
        Me.TPMantenimientoCheckpoint.Text = "Generación / Edición de Checkpoint"
        Me.TPMantenimientoCheckpoint.UseVisualStyleBackColor = True
        '
        'pnlConfiguracion
        '
        Me.pnlConfiguracion.Controls.Add(Me.grpConfiguracion)
        Me.pnlConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConfiguracion.Location = New System.Drawing.Point(3, 78)
        Me.pnlConfiguracion.Name = "pnlConfiguracion"
        Me.pnlConfiguracion.Size = New System.Drawing.Size(1273, 503)
        Me.pnlConfiguracion.TabIndex = 1
        '
        'grpConfiguracion
        '
        Me.grpConfiguracion.Controls.Add(Me.pnlConfigurarPrecedencia)
        Me.grpConfiguracion.Controls.Add(Me.pnlConfigurarVisibilidad)
        Me.grpConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpConfiguracion.Location = New System.Drawing.Point(0, 0)
        Me.grpConfiguracion.Name = "grpConfiguracion"
        Me.grpConfiguracion.Size = New System.Drawing.Size(1273, 503)
        Me.grpConfiguracion.TabIndex = 0
        Me.grpConfiguracion.TabStop = False
        Me.grpConfiguracion.Text = "Configuración"
        '
        'pnlConfigurarPrecedencia
        '
        Me.pnlConfigurarPrecedencia.Controls.Add(Me.dgdPrecedencia)
        Me.pnlConfigurarPrecedencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConfigurarPrecedencia.Location = New System.Drawing.Point(3, 77)
        Me.pnlConfigurarPrecedencia.Name = "pnlConfigurarPrecedencia"
        Me.pnlConfigurarPrecedencia.Size = New System.Drawing.Size(1267, 423)
        Me.pnlConfigurarPrecedencia.TabIndex = 13
        '
        'dgdPrecedencia
        '
        Me.dgdPrecedencia.AllowUserToAddRows = False
        Me.dgdPrecedencia.AllowUserToDeleteRows = False
        Me.dgdPrecedencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPrecedencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdPrecedencia.Location = New System.Drawing.Point(0, 0)
        Me.dgdPrecedencia.Name = "dgdPrecedencia"
        Me.dgdPrecedencia.Size = New System.Drawing.Size(1267, 423)
        Me.dgdPrecedencia.TabIndex = 0
        '
        'pnlConfigurarVisibilidad
        '
        Me.pnlConfigurarVisibilidad.Controls.Add(Me.chkVisibleCliente)
        Me.pnlConfigurarVisibilidad.Controls.Add(Me.txtDescripcionUsuario)
        Me.pnlConfigurarVisibilidad.Controls.Add(Me.chkVisibleUsuario)
        Me.pnlConfigurarVisibilidad.Controls.Add(Me.lblDescripcionUsuario)
        Me.pnlConfigurarVisibilidad.Controls.Add(Me.txtDescripcionWeb)
        Me.pnlConfigurarVisibilidad.Controls.Add(Me.lblDescripciónWeb)
        Me.pnlConfigurarVisibilidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConfigurarVisibilidad.Location = New System.Drawing.Point(3, 16)
        Me.pnlConfigurarVisibilidad.Name = "pnlConfigurarVisibilidad"
        Me.pnlConfigurarVisibilidad.Size = New System.Drawing.Size(1267, 61)
        Me.pnlConfigurarVisibilidad.TabIndex = 12
        '
        'chkVisibleCliente
        '
        Me.chkVisibleCliente.AutoSize = True
        Me.chkVisibleCliente.Location = New System.Drawing.Point(16, 20)
        Me.chkVisibleCliente.Name = "chkVisibleCliente"
        Me.chkVisibleCliente.Size = New System.Drawing.Size(101, 17)
        Me.chkVisibleCliente.TabIndex = 0
        Me.chkVisibleCliente.Text = "Visible al cliente"
        Me.chkVisibleCliente.UseVisualStyleBackColor = True
        '
        'txtDescripcionUsuario
        '
        Me.txtDescripcionUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionUsuario.Location = New System.Drawing.Point(844, 18)
        Me.txtDescripcionUsuario.MaxLength = 100
        Me.txtDescripcionUsuario.Name = "txtDescripcionUsuario"
        Me.txtDescripcionUsuario.Size = New System.Drawing.Size(405, 20)
        Me.txtDescripcionUsuario.TabIndex = 11
        '
        'chkVisibleUsuario
        '
        Me.chkVisibleUsuario.AutoSize = True
        Me.chkVisibleUsuario.Location = New System.Drawing.Point(633, 20)
        Me.chkVisibleUsuario.Name = "chkVisibleUsuario"
        Me.chkVisibleUsuario.Size = New System.Drawing.Size(104, 17)
        Me.chkVisibleUsuario.TabIndex = 1
        Me.chkVisibleUsuario.Text = "Visible al usuario"
        Me.chkVisibleUsuario.UseVisualStyleBackColor = True
        '
        'lblDescripcionUsuario
        '
        Me.lblDescripcionUsuario.AutoSize = True
        Me.lblDescripcionUsuario.Location = New System.Drawing.Point(737, 21)
        Me.lblDescripcionUsuario.Name = "lblDescripcionUsuario"
        Me.lblDescripcionUsuario.Size = New System.Drawing.Size(102, 13)
        Me.lblDescripcionUsuario.TabIndex = 10
        Me.lblDescripcionUsuario.Text = "Descripción Usuario"
        '
        'txtDescripcionWeb
        '
        Me.txtDescripcionWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionWeb.Location = New System.Drawing.Point(204, 18)
        Me.txtDescripcionWeb.MaxLength = 100
        Me.txtDescripcionWeb.Name = "txtDescripcionWeb"
        Me.txtDescripcionWeb.Size = New System.Drawing.Size(405, 20)
        Me.txtDescripcionWeb.TabIndex = 8
        '
        'lblDescripciónWeb
        '
        Me.lblDescripciónWeb.AutoSize = True
        Me.lblDescripciónWeb.Location = New System.Drawing.Point(114, 21)
        Me.lblDescripciónWeb.Name = "lblDescripciónWeb"
        Me.lblDescripciónWeb.Size = New System.Drawing.Size(89, 13)
        Me.lblDescripciónWeb.TabIndex = 9
        Me.lblDescripciónWeb.Text = "Descripción Web"
        '
        'pnlDatosGenerales
        '
        Me.pnlDatosGenerales.Controls.Add(Me.grpDatosGenerales)
        Me.pnlDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosGenerales.Location = New System.Drawing.Point(3, 3)
        Me.pnlDatosGenerales.Name = "pnlDatosGenerales"
        Me.pnlDatosGenerales.Size = New System.Drawing.Size(1273, 75)
        Me.pnlDatosGenerales.TabIndex = 0
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.txtNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblNombre)
        Me.grpDatosGenerales.Controls.Add(Me.txtAbreviatura)
        Me.grpDatosGenerales.Controls.Add(Me.lblAbreviacion)
        Me.grpDatosGenerales.Controls.Add(Me.cboTipo)
        Me.grpDatosGenerales.Controls.Add(Me.lblTipo)
        Me.grpDatosGenerales.Controls.Add(Me.cboProceso)
        Me.grpDatosGenerales.Controls.Add(Me.lblProceso)
        Me.grpDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(1273, 75)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Generales"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(847, 23)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(405, 20)
        Me.txtNombre.TabIndex = 7
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(799, 26)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 6
        Me.lblNombre.Text = "Nombre"
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbreviatura.Location = New System.Drawing.Point(700, 23)
        Me.txtAbreviatura.MaxLength = 10
        Me.txtAbreviatura.Name = "txtAbreviatura"
        Me.txtAbreviatura.Size = New System.Drawing.Size(82, 20)
        Me.txtAbreviatura.TabIndex = 5
        '
        'lblAbreviacion
        '
        Me.lblAbreviacion.AutoSize = True
        Me.lblAbreviacion.Location = New System.Drawing.Point(633, 26)
        Me.lblAbreviacion.Name = "lblAbreviacion"
        Me.lblAbreviacion.Size = New System.Drawing.Size(61, 13)
        Me.lblAbreviacion.TabIndex = 4
        Me.lblAbreviacion.Text = "Abreviatura"
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(432, 23)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(180, 21)
        Me.cboTipo.TabIndex = 3
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(331, 26)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(95, 13)
        Me.lblTipo.TabIndex = 2
        Me.lblTipo.Text = "Seleccione el Tipo"
        '
        'cboProceso
        '
        Me.cboProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProceso.FormattingEnabled = True
        Me.cboProceso.Location = New System.Drawing.Point(134, 23)
        Me.cboProceso.Name = "cboProceso"
        Me.cboProceso.Size = New System.Drawing.Size(180, 21)
        Me.cboProceso.TabIndex = 1
        '
        'lblProceso
        '
        Me.lblProceso.AutoSize = True
        Me.lblProceso.Location = New System.Drawing.Point(16, 26)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(113, 13)
        Me.lblProceso.TabIndex = 0
        Me.lblProceso.Text = "Seleccione el Proceso"
        '
        'frmMantenimientoCheckpoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 685)
        Me.Controls.Add(Me.TCCheckpoint)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "frmMantenimientoCheckpoint"
        Me.Text = "frmMantenimientoCheckpoint"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnlBarra.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TCCheckpoint.ResumeLayout(False)
        Me.TPConsultaCheckpoint.ResumeLayout(False)
        Me.grpCheckpointConfigurado.ResumeLayout(False)
        CType(Me.dgdCheckpointConfigurado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpListaCheckpoint.ResumeLayout(False)
        CType(Me.dgdCheckpoint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPMantenimientoCheckpoint.ResumeLayout(False)
        Me.pnlConfiguracion.ResumeLayout(False)
        Me.grpConfiguracion.ResumeLayout(False)
        Me.pnlConfigurarPrecedencia.ResumeLayout(False)
        CType(Me.dgdPrecedencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConfigurarVisibilidad.ResumeLayout(False)
        Me.pnlConfigurarVisibilidad.PerformLayout()
        Me.pnlDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
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
    Friend WithEvents ConsultarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CierreComisionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TCCheckpoint As System.Windows.Forms.TabControl
    Friend WithEvents TPConsultaCheckpoint As System.Windows.Forms.TabPage
    Friend WithEvents TPMantenimientoCheckpoint As System.Windows.Forms.TabPage
    Friend WithEvents pnlDatosGenerales As System.Windows.Forms.Panel
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cboProceso As System.Windows.Forms.ComboBox
    Friend WithEvents lblProceso As System.Windows.Forms.Label
    Friend WithEvents txtAbreviatura As System.Windows.Forms.TextBox
    Friend WithEvents lblAbreviacion As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents pnlConfiguracion As System.Windows.Forms.Panel
    Friend WithEvents grpConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents chkVisibleUsuario As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisibleCliente As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescripcionUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcionUsuario As System.Windows.Forms.Label
    Friend WithEvents lblDescripciónWeb As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionWeb As System.Windows.Forms.TextBox
    Friend WithEvents pnlConfigurarPrecedencia As System.Windows.Forms.Panel
    Friend WithEvents pnlConfigurarVisibilidad As System.Windows.Forms.Panel
    Friend WithEvents dgdPrecedencia As System.Windows.Forms.DataGridView
    Friend WithEvents grpListaCheckpoint As System.Windows.Forms.GroupBox
    Friend WithEvents dgdCheckpoint As System.Windows.Forms.DataGridView
    Friend WithEvents grpCheckpointConfigurado As System.Windows.Forms.GroupBox
    Friend WithEvents dgdCheckpointConfigurado As System.Windows.Forms.DataGridView
End Class
