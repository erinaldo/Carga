<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaSolicitudesEntregas
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaSolicitudesEntregas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtGridViewControl_FACBOL = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbAgencias = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNroMovil = New System.Windows.Forms.TextBox()
        Me.txtNroSerieDoc = New System.Windows.Forms.TextBox()
        Me.txtNroSolicitud = New System.Windows.Forms.TextBox()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbAtendido = New System.Windows.Forms.ComboBox()
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.cmbResponsableMovil = New System.Windows.Forms.ComboBox()
        Me.MnuControlUsuario = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.SiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoOperacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntregaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecojoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAnulacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfirmacionEntregasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirManifiestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarDireccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolicitudRecojoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvioMSM2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerGuiasDeEnvioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReasignacionDeRecojosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecojosProgramadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepartoParcialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grbOpcion = New System.Windows.Forms.GroupBox()
        Me.lbNroRegistro = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtGridViewControl_FACBOL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.MnuControlUsuario.SuspendLayout()
        Me.grbOpcion.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtGridViewControl_FACBOL)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 393)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dtGridViewControl_FACBOL
        '
        Me.dtGridViewControl_FACBOL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtGridViewControl_FACBOL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViewControl_FACBOL.Location = New System.Drawing.Point(6, 19)
        Me.dtGridViewControl_FACBOL.Name = "dtGridViewControl_FACBOL"
        Me.dtGridViewControl_FACBOL.Size = New System.Drawing.Size(760, 367)
        Me.dtGridViewControl_FACBOL.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.cmbAgencias)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.txtNroMovil)
        Me.GroupBox2.Controls.Add(Me.txtNroSerieDoc)
        Me.GroupBox2.Controls.Add(Me.txtNroSolicitud)
        Me.GroupBox2.Controls.Add(Me.dtFechaFin)
        Me.GroupBox2.Controls.Add(Me.dtFechaInicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.cmbAtendido)
        Me.GroupBox2.Controls.Add(Me.cmbTipoOperacion)
        Me.GroupBox2.Controls.Add(Me.cmbResponsableMovil)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(775, 107)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'cmbAgencias
        '
        Me.cmbAgencias.BackColor = System.Drawing.Color.White
        Me.cmbAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAgencias.FormattingEnabled = True
        Me.cmbAgencias.Location = New System.Drawing.Point(468, 16)
        Me.cmbAgencias.Name = "cmbAgencias"
        Me.cmbAgencias.Size = New System.Drawing.Size(300, 21)
        Me.cmbAgencias.TabIndex = 57
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Location = New System.Drawing.Point(394, 67)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(72, 26)
        Me.btnBuscar.TabIndex = 56
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Location = New System.Drawing.Point(697, 67)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(72, 26)
        Me.btnAgregar.TabIndex = 56
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        Me.btnAgregar.Visible = False
        '
        'txtNroMovil
        '
        Me.txtNroMovil.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtNroMovil.Location = New System.Drawing.Point(87, 71)
        Me.txtNroMovil.Name = "txtNroMovil"
        Me.txtNroMovil.Size = New System.Drawing.Size(119, 20)
        Me.txtNroMovil.TabIndex = 54
        Me.txtNroMovil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNroSerieDoc
        '
        Me.txtNroSerieDoc.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtNroSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroSerieDoc.Location = New System.Drawing.Point(586, 71)
        Me.txtNroSerieDoc.Name = "txtNroSerieDoc"
        Me.txtNroSerieDoc.Size = New System.Drawing.Size(106, 20)
        Me.txtNroSerieDoc.TabIndex = 55
        Me.txtNroSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNroSerieDoc.Visible = False
        '
        'txtNroSolicitud
        '
        Me.txtNroSolicitud.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtNroSolicitud.Location = New System.Drawing.Point(286, 71)
        Me.txtNroSolicitud.Name = "txtNroSolicitud"
        Me.txtNroSolicitud.Size = New System.Drawing.Size(95, 20)
        Me.txtNroSolicitud.TabIndex = 55
        Me.txtNroSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(286, 45)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.dtFechaFin.TabIndex = 52
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(286, 18)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(95, 20)
        Me.dtFechaInicio.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(8, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "NroMovil"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(512, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Nº Comprob."
        Me.Label2.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(214, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Nº Solicitud"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(217, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Fecha Fin"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(8, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Atendido"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(8, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(75, 13)
        Me.Label30.TabIndex = 46
        Me.Label30.Text = "T.Opereracion"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(391, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Agencias"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(391, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Resp. Movil"
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(217, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 13)
        Me.Label31.TabIndex = 48
        Me.Label31.Text = "Fecha Inicio"
        '
        'cmbAtendido
        '
        Me.cmbAtendido.BackColor = System.Drawing.Color.White
        Me.cmbAtendido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAtendido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAtendido.FormattingEnabled = True
        Me.cmbAtendido.Location = New System.Drawing.Point(87, 40)
        Me.cmbAtendido.Name = "cmbAtendido"
        Me.cmbAtendido.Size = New System.Drawing.Size(121, 21)
        Me.cmbAtendido.TabIndex = 45
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BackColor = System.Drawing.Color.White
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(87, 14)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoOperacion.TabIndex = 44
        '
        'cmbResponsableMovil
        '
        Me.cmbResponsableMovil.BackColor = System.Drawing.Color.White
        Me.cmbResponsableMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsableMovil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbResponsableMovil.FormattingEnabled = True
        Me.cmbResponsableMovil.Location = New System.Drawing.Point(468, 40)
        Me.cmbResponsableMovil.Name = "cmbResponsableMovil"
        Me.cmbResponsableMovil.Size = New System.Drawing.Size(301, 21)
        Me.cmbResponsableMovil.TabIndex = 2
        '
        'MnuControlUsuario
        '
        Me.MnuControlUsuario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditar, Me.TipoOperacionToolStripMenuItem, Me.mnuAnulacion, Me.ExportarExcelToolStripMenuItem, Me.ConfirmacionEntregasToolStripMenuItem, Me.ImprimirManifiestoToolStripMenuItem, Me.EditarDireccionToolStripMenuItem, Me.SolicitudRecojoToolStripMenuItem, Me.EnvioMSM2ToolStripMenuItem, Me.VerGuiasDeEnvioToolStripMenuItem, Me.ReasignacionDeRecojosToolStripMenuItem, Me.RecojosProgramadosToolStripMenuItem, Me.RepartoParcialToolStripMenuItem})
        Me.MnuControlUsuario.Name = "MnuControlUsuario"
        Me.MnuControlUsuario.Size = New System.Drawing.Size(230, 290)
        '
        'mnuEditar
        '
        Me.mnuEditar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SiToolStripMenuItem, Me.NOToolStripMenuItem})
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(229, 22)
        Me.mnuEditar.Text = "Atendido"
        '
        'SiToolStripMenuItem
        '
        Me.SiToolStripMenuItem.Name = "SiToolStripMenuItem"
        Me.SiToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.SiToolStripMenuItem.Text = "SI"
        '
        'NOToolStripMenuItem
        '
        Me.NOToolStripMenuItem.Name = "NOToolStripMenuItem"
        Me.NOToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.NOToolStripMenuItem.Text = "NO"
        '
        'TipoOperacionToolStripMenuItem
        '
        Me.TipoOperacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntregaToolStripMenuItem, Me.RecojoToolStripMenuItem})
        Me.TipoOperacionToolStripMenuItem.Name = "TipoOperacionToolStripMenuItem"
        Me.TipoOperacionToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.TipoOperacionToolStripMenuItem.Text = "Tipo Operacion"
        '
        'EntregaToolStripMenuItem
        '
        Me.EntregaToolStripMenuItem.Name = "EntregaToolStripMenuItem"
        Me.EntregaToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.EntregaToolStripMenuItem.Text = "Entrega"
        '
        'RecojoToolStripMenuItem
        '
        Me.RecojoToolStripMenuItem.Name = "RecojoToolStripMenuItem"
        Me.RecojoToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.RecojoToolStripMenuItem.Text = "Recojo"
        '
        'mnuAnulacion
        '
        Me.mnuAnulacion.Name = "mnuAnulacion"
        Me.mnuAnulacion.Size = New System.Drawing.Size(229, 22)
        Me.mnuAnulacion.Text = "Anulacion"
        '
        'ExportarExcelToolStripMenuItem
        '
        Me.ExportarExcelToolStripMenuItem.Name = "ExportarExcelToolStripMenuItem"
        Me.ExportarExcelToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ExportarExcelToolStripMenuItem.Text = "Exportar Excel"
        '
        'ConfirmacionEntregasToolStripMenuItem
        '
        Me.ConfirmacionEntregasToolStripMenuItem.Name = "ConfirmacionEntregasToolStripMenuItem"
        Me.ConfirmacionEntregasToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ConfirmacionEntregasToolStripMenuItem.Text = "Confirmacion Entregas"
        '
        'ImprimirManifiestoToolStripMenuItem
        '
        Me.ImprimirManifiestoToolStripMenuItem.Name = "ImprimirManifiestoToolStripMenuItem"
        Me.ImprimirManifiestoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ImprimirManifiestoToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ImprimirManifiestoToolStripMenuItem.Text = "Imprimir Manifiesto"
        '
        'EditarDireccionToolStripMenuItem
        '
        Me.EditarDireccionToolStripMenuItem.Name = "EditarDireccionToolStripMenuItem"
        Me.EditarDireccionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.EditarDireccionToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.EditarDireccionToolStripMenuItem.Text = "Editar Direccion"
        '
        'SolicitudRecojoToolStripMenuItem
        '
        Me.SolicitudRecojoToolStripMenuItem.Name = "SolicitudRecojoToolStripMenuItem"
        Me.SolicitudRecojoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.SolicitudRecojoToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.SolicitudRecojoToolStripMenuItem.Text = "Solicitud Recojo"
        '
        'EnvioMSM2ToolStripMenuItem
        '
        Me.EnvioMSM2ToolStripMenuItem.Name = "EnvioMSM2ToolStripMenuItem"
        Me.EnvioMSM2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.EnvioMSM2ToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.EnvioMSM2ToolStripMenuItem.Text = "Envio MSM2"
        '
        'VerGuiasDeEnvioToolStripMenuItem
        '
        Me.VerGuiasDeEnvioToolStripMenuItem.Name = "VerGuiasDeEnvioToolStripMenuItem"
        Me.VerGuiasDeEnvioToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.VerGuiasDeEnvioToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.VerGuiasDeEnvioToolStripMenuItem.Text = "Ver Guias de Envio"
        '
        'ReasignacionDeRecojosToolStripMenuItem
        '
        Me.ReasignacionDeRecojosToolStripMenuItem.Name = "ReasignacionDeRecojosToolStripMenuItem"
        Me.ReasignacionDeRecojosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.ReasignacionDeRecojosToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ReasignacionDeRecojosToolStripMenuItem.Text = "Reasignacion de Recojos"
        '
        'RecojosProgramadosToolStripMenuItem
        '
        Me.RecojosProgramadosToolStripMenuItem.Name = "RecojosProgramadosToolStripMenuItem"
        Me.RecojosProgramadosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.RecojosProgramadosToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.RecojosProgramadosToolStripMenuItem.Text = "Recojos Programados"
        '
        'RepartoParcialToolStripMenuItem
        '
        Me.RepartoParcialToolStripMenuItem.Name = "RepartoParcialToolStripMenuItem"
        Me.RepartoParcialToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.RepartoParcialToolStripMenuItem.Text = "Reparto Parcial"
        '
        'grbOpcion
        '
        Me.grbOpcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbOpcion.Controls.Add(Me.lbNroRegistro)
        Me.grbOpcion.Controls.Add(Me.Label5)
        Me.grbOpcion.Controls.Add(Me.btnImprimir)
        Me.grbOpcion.Location = New System.Drawing.Point(9, 539)
        Me.grbOpcion.Name = "grbOpcion"
        Me.grbOpcion.Size = New System.Drawing.Size(775, 43)
        Me.grbOpcion.TabIndex = 3
        Me.grbOpcion.TabStop = False
        '
        'lbNroRegistro
        '
        Me.lbNroRegistro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNroRegistro.AutoSize = True
        Me.lbNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro.Location = New System.Drawing.Point(722, 17)
        Me.lbNroRegistro.Name = "lbNroRegistro"
        Me.lbNroRegistro.Size = New System.Drawing.Size(43, 13)
        Me.lbNroRegistro.TabIndex = 3
        Me.lbNroRegistro.Text = "........."
        Me.lbNroRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(662, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Nro Reg"
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(6, 10)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(136, 26)
        Me.btnImprimir.TabIndex = 0
        Me.btnImprimir.Text = "(F5) Imprimir Manifiesto"
        Me.btnImprimir.UseVisualStyleBackColor = True
        Me.btnImprimir.Visible = False
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(795, 25)
        Me.tool.TabIndex = 9
        Me.tool.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "Nuevo"
        Me.tsbNuevo.Visible = False
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "Editar"
        Me.tsbEditar.Visible = False
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "Grabar"
        Me.tsbGrabar.Visible = False
        '
        'tsbAnular
        '
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        Me.tsbAnular.Visible = False
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(154, 22)
        Me.tsbImprimir.Text = "Asignar Carga a Reparto"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'FrmListaSolicitudesEntregas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(795, 584)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbOpcion)
        Me.Name = "FrmListaSolicitudesEntregas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asociacion de Documentos a Entregas"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dtGridViewControl_FACBOL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MnuControlUsuario.ResumeLayout(False)
        Me.grbOpcion.ResumeLayout(False)
        Me.grbOpcion.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtGridViewControl_FACBOL As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbResponsableMovil As System.Windows.Forms.ComboBox
    Friend WithEvents txtNroMovil As System.Windows.Forms.TextBox
    Friend WithEvents txtNroSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbAtendido As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNroSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MnuControlUsuario As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoOperacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntregaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecojoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAnulacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfirmacionEntregasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirManifiestoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarDireccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnvioMSM2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolicitudRecojoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerGuiasDeEnvioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbAgencias As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ReasignacionDeRecojosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecojosProgramadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RepartoParcialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grbOpcion As System.Windows.Forms.GroupBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbNroRegistro As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
