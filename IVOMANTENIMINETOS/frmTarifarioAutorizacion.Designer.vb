<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarifarioAutorizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTarifarioAutorizacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabTarifario = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.pnlEstadoReparto = New System.Windows.Forms.Panel()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.cboCiudad = New System.Windows.Forms.ComboBox()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label151 = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Label176 = New System.Windows.Forms.Label()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.tabSolicitud = New System.Windows.Forms.TabPage()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.grbTarifa = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvTarifa = New System.Windows.Forms.DataGridView()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.lblSolicitante = New System.Windows.Forms.Label()
        Me.lblNumeroSolicitud = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.Label134 = New System.Windows.Forms.Label()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.tabAprobacion = New System.Windows.Forms.TabPage()
        Me.lblObservacionAprobacion = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtObservacionAprobacion = New System.Windows.Forms.TextBox()
        Me.btnAceptarAprobacion = New System.Windows.Forms.Button()
        Me.rbtNoAprobacion = New System.Windows.Forms.RadioButton()
        Me.rbtSiAprobacion = New System.Windows.Forms.RadioButton()
        Me.lblAprobarAprobacion = New System.Windows.Forms.Label()
        Me.grbEstibaAprobacion = New System.Windows.Forms.GroupBox()
        Me.dgvTarifaAprobacion = New System.Windows.Forms.DataGridView()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.lblSolicitanteAprobacion = New System.Windows.Forms.Label()
        Me.lblFechaAprobacion = New System.Windows.Forms.Label()
        Me.lblCiudadAprobacion = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tabTarifario.SuspendLayout()
        Me.tabLista.SuspendLayout()
        Me.pnlEstadoReparto.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSolicitud.SuspendLayout()
        Me.grbTarifa.SuspendLayout()
        CType(Me.dgvTarifa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAprobacion.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.grbEstibaAprobacion.SuspendLayout()
        CType(Me.dgvTarifaAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabTarifario
        '
        Me.tabTarifario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTarifario.Controls.Add(Me.tabLista)
        Me.tabTarifario.Controls.Add(Me.tabSolicitud)
        Me.tabTarifario.Controls.Add(Me.tabAprobacion)
        Me.tabTarifario.Location = New System.Drawing.Point(12, 31)
        Me.tabTarifario.Name = "tabTarifario"
        Me.tabTarifario.SelectedIndex = 0
        Me.tabTarifario.Size = New System.Drawing.Size(817, 457)
        Me.tabTarifario.TabIndex = 0
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.pnlEstadoReparto)
        Me.tabLista.Controls.Add(Me.dgvLista)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(809, 431)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'pnlEstadoReparto
        '
        Me.pnlEstadoReparto.Controls.Add(Me.btnConsultar)
        Me.pnlEstadoReparto.Controls.Add(Me.cboCiudad)
        Me.pnlEstadoReparto.Controls.Add(Me.Label145)
        Me.pnlEstadoReparto.Controls.Add(Me.dtpInicio)
        Me.pnlEstadoReparto.Controls.Add(Me.Label151)
        Me.pnlEstadoReparto.Controls.Add(Me.Label147)
        Me.pnlEstadoReparto.Controls.Add(Me.dtpFin)
        Me.pnlEstadoReparto.Controls.Add(Me.cboEstado)
        Me.pnlEstadoReparto.Controls.Add(Me.Label176)
        Me.pnlEstadoReparto.Location = New System.Drawing.Point(16, 12)
        Me.pnlEstadoReparto.Name = "pnlEstadoReparto"
        Me.pnlEstadoReparto.Size = New System.Drawing.Size(775, 35)
        Me.pnlEstadoReparto.TabIndex = 23
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(686, 1)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(86, 31)
        Me.btnConsultar.TabIndex = 25
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboCiudad
        '
        Me.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudad.FormattingEnabled = True
        Me.cboCiudad.Location = New System.Drawing.Point(289, 7)
        Me.cboCiudad.Name = "cboCiudad"
        Me.cboCiudad.Size = New System.Drawing.Size(173, 21)
        Me.cboCiudad.TabIndex = 24
        Me.cboCiudad.TabStop = False
        '
        'Label145
        '
        Me.Label145.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label145.AutoSize = True
        Me.Label145.Location = New System.Drawing.Point(7, 10)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(23, 13)
        Me.Label145.TabIndex = 19
        Me.Label145.Text = "Del"
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(36, 7)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(84, 20)
        Me.dtpInicio.TabIndex = 20
        '
        'Label151
        '
        Me.Label151.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label151.AutoSize = True
        Me.Label151.Location = New System.Drawing.Point(245, 10)
        Me.Label151.Name = "Label151"
        Me.Label151.Size = New System.Drawing.Size(40, 13)
        Me.Label151.TabIndex = 21
        Me.Label151.Text = "Ciudad"
        '
        'Label147
        '
        Me.Label147.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label147.AutoSize = True
        Me.Label147.Location = New System.Drawing.Point(126, 10)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(16, 13)
        Me.Label147.TabIndex = 22
        Me.Label147.Text = "Al"
        '
        'dtpFin
        '
        Me.dtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFin.CustomFormat = ""
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(148, 7)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(84, 20)
        Me.dtpFin.TabIndex = 23
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"(TODO)", "PENDIENTE", "APROBADO", "DESAPROBADO", "ANULADO"})
        Me.cboEstado.Location = New System.Drawing.Point(520, 6)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(147, 21)
        Me.cboEstado.TabIndex = 18
        Me.cboEstado.TabStop = False
        '
        'Label176
        '
        Me.Label176.AutoSize = True
        Me.Label176.Location = New System.Drawing.Point(476, 9)
        Me.Label176.Name = "Label176"
        Me.Label176.Size = New System.Drawing.Size(40, 13)
        Me.Label176.TabIndex = 17
        Me.Label176.Text = "Estado"
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(16, 53)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(775, 362)
        Me.dgvLista.TabIndex = 0
        '
        'tabSolicitud
        '
        Me.tabSolicitud.Controls.Add(Me.txtObservacion)
        Me.tabSolicitud.Controls.Add(Me.grbTarifa)
        Me.tabSolicitud.Controls.Add(Me.lblCiudad)
        Me.tabSolicitud.Controls.Add(Me.lblSolicitante)
        Me.tabSolicitud.Controls.Add(Me.lblNumeroSolicitud)
        Me.tabSolicitud.Controls.Add(Me.Label1)
        Me.tabSolicitud.Controls.Add(Me.Label131)
        Me.tabSolicitud.Controls.Add(Me.lblFecha)
        Me.tabSolicitud.Controls.Add(Me.Label133)
        Me.tabSolicitud.Controls.Add(Me.Label134)
        Me.tabSolicitud.Controls.Add(Me.Label135)
        Me.tabSolicitud.Location = New System.Drawing.Point(4, 22)
        Me.tabSolicitud.Name = "tabSolicitud"
        Me.tabSolicitud.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSolicitud.Size = New System.Drawing.Size(809, 431)
        Me.tabSolicitud.TabIndex = 1
        Me.tabSolicitud.Text = "Solicitud"
        Me.tabSolicitud.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(109, 78)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(682, 64)
        Me.txtObservacion.TabIndex = 25
        '
        'grbTarifa
        '
        Me.grbTarifa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbTarifa.Controls.Add(Me.btnEliminar)
        Me.grbTarifa.Controls.Add(Me.btnAgregar)
        Me.grbTarifa.Controls.Add(Me.dgvTarifa)
        Me.grbTarifa.Location = New System.Drawing.Point(19, 153)
        Me.grbTarifa.Name = "grbTarifa"
        Me.grbTarifa.Size = New System.Drawing.Size(772, 264)
        Me.grbTarifa.TabIndex = 24
        Me.grbTarifa.TabStop = False
        Me.grbTarifa.Text = "Tarifa"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(693, 15)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 30)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(604, 15)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(68, 30)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvTarifa
        '
        Me.dgvTarifa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTarifa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTarifa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTarifa.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTarifa.Location = New System.Drawing.Point(6, 51)
        Me.dgvTarifa.Name = "dgvTarifa"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTarifa.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTarifa.Size = New System.Drawing.Size(755, 206)
        Me.dgvTarifa.TabIndex = 0
        Me.dgvTarifa.TabStop = False
        '
        'lblCiudad
        '
        Me.lblCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCiudad.Location = New System.Drawing.Point(106, 53)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(183, 13)
        Me.lblCiudad.TabIndex = 22
        Me.lblCiudad.Text = "CUSCO"
        '
        'lblSolicitante
        '
        Me.lblSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicitante.Location = New System.Drawing.Point(391, 53)
        Me.lblSolicitante.Name = "lblSolicitante"
        Me.lblSolicitante.Size = New System.Drawing.Size(271, 13)
        Me.lblSolicitante.TabIndex = 23
        Me.lblSolicitante.Text = "JUAN ANTONIO BACA"
        '
        'lblNumeroSolicitud
        '
        Me.lblNumeroSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSolicitud.Location = New System.Drawing.Point(106, 26)
        Me.lblNumeroSolicitud.Name = "lblNumeroSolicitud"
        Me.lblNumeroSolicitud.Size = New System.Drawing.Size(42, 13)
        Me.lblNumeroSolicitud.TabIndex = 21
        Me.lblNumeroSolicitud.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Observación"
        '
        'Label131
        '
        Me.Label131.AutoSize = True
        Me.Label131.Location = New System.Drawing.Point(16, 53)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(40, 13)
        Me.Label131.TabIndex = 19
        Me.Label131.Text = "Oficina"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(220, 26)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(75, 13)
        Me.lblFecha.TabIndex = 20
        Me.lblFecha.Text = "10/12/2013"
        '
        'Label133
        '
        Me.Label133.AutoSize = True
        Me.Label133.Location = New System.Drawing.Point(299, 53)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(56, 13)
        Me.Label133.TabIndex = 18
        Me.Label133.Text = "Solicitante"
        '
        'Label134
        '
        Me.Label134.AutoSize = True
        Me.Label134.Location = New System.Drawing.Point(167, 26)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(37, 13)
        Me.Label134.TabIndex = 16
        Me.Label134.Text = "Fecha"
        '
        'Label135
        '
        Me.Label135.AutoSize = True
        Me.Label135.Location = New System.Drawing.Point(16, 26)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(62, 13)
        Me.Label135.TabIndex = 17
        Me.Label135.Text = "Nº Solicitud"
        '
        'tabAprobacion
        '
        Me.tabAprobacion.Controls.Add(Me.lblObservacionAprobacion)
        Me.tabAprobacion.Controls.Add(Me.Label117)
        Me.tabAprobacion.Controls.Add(Me.Panel10)
        Me.tabAprobacion.Controls.Add(Me.grbEstibaAprobacion)
        Me.tabAprobacion.Controls.Add(Me.Label127)
        Me.tabAprobacion.Controls.Add(Me.Label128)
        Me.tabAprobacion.Controls.Add(Me.Label130)
        Me.tabAprobacion.Controls.Add(Me.lblSolicitanteAprobacion)
        Me.tabAprobacion.Controls.Add(Me.lblFechaAprobacion)
        Me.tabAprobacion.Controls.Add(Me.lblCiudadAprobacion)
        Me.tabAprobacion.Location = New System.Drawing.Point(4, 22)
        Me.tabAprobacion.Name = "tabAprobacion"
        Me.tabAprobacion.Size = New System.Drawing.Size(809, 431)
        Me.tabAprobacion.TabIndex = 2
        Me.tabAprobacion.Text = "Aprobación"
        Me.tabAprobacion.UseVisualStyleBackColor = True
        '
        'lblObservacionAprobacion
        '
        Me.lblObservacionAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacionAprobacion.Location = New System.Drawing.Point(480, 23)
        Me.lblObservacionAprobacion.Name = "lblObservacionAprobacion"
        Me.lblObservacionAprobacion.Size = New System.Drawing.Size(322, 50)
        Me.lblObservacionAprobacion.TabIndex = 314
        Me.lblObservacionAprobacion.Text = "PR"
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.Location = New System.Drawing.Point(409, 23)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(67, 13)
        Me.Label117.TabIndex = 307
        Me.Label117.Text = "Observación"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.txtObservacionAprobacion)
        Me.Panel10.Controls.Add(Me.btnAceptarAprobacion)
        Me.Panel10.Controls.Add(Me.rbtNoAprobacion)
        Me.Panel10.Controls.Add(Me.rbtSiAprobacion)
        Me.Panel10.Controls.Add(Me.lblAprobarAprobacion)
        Me.Panel10.Location = New System.Drawing.Point(230, 101)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(390, 91)
        Me.Panel10.TabIndex = 306
        '
        'txtObservacionAprobacion
        '
        Me.txtObservacionAprobacion.Enabled = False
        Me.txtObservacionAprobacion.Location = New System.Drawing.Point(110, 35)
        Me.txtObservacionAprobacion.MaxLength = 100
        Me.txtObservacionAprobacion.Name = "txtObservacionAprobacion"
        Me.txtObservacionAprobacion.Size = New System.Drawing.Size(272, 20)
        Me.txtObservacionAprobacion.TabIndex = 15
        '
        'btnAceptarAprobacion
        '
        Me.btnAceptarAprobacion.Location = New System.Drawing.Point(112, 61)
        Me.btnAceptarAprobacion.Name = "btnAceptarAprobacion"
        Me.btnAceptarAprobacion.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptarAprobacion.TabIndex = 16
        Me.btnAceptarAprobacion.Text = "&Aceptar"
        Me.btnAceptarAprobacion.UseVisualStyleBackColor = True
        '
        'rbtNoAprobacion
        '
        Me.rbtNoAprobacion.AutoSize = True
        Me.rbtNoAprobacion.Location = New System.Drawing.Point(65, 35)
        Me.rbtNoAprobacion.Name = "rbtNoAprobacion"
        Me.rbtNoAprobacion.Size = New System.Drawing.Size(39, 17)
        Me.rbtNoAprobacion.TabIndex = 14
        Me.rbtNoAprobacion.Text = "No"
        Me.rbtNoAprobacion.UseVisualStyleBackColor = True
        '
        'rbtSiAprobacion
        '
        Me.rbtSiAprobacion.AutoSize = True
        Me.rbtSiAprobacion.Checked = True
        Me.rbtSiAprobacion.Location = New System.Drawing.Point(16, 35)
        Me.rbtSiAprobacion.Name = "rbtSiAprobacion"
        Me.rbtSiAprobacion.Size = New System.Drawing.Size(34, 17)
        Me.rbtSiAprobacion.TabIndex = 13
        Me.rbtSiAprobacion.TabStop = True
        Me.rbtSiAprobacion.Text = "Si"
        Me.rbtSiAprobacion.UseVisualStyleBackColor = True
        '
        'lblAprobarAprobacion
        '
        Me.lblAprobarAprobacion.AutoSize = True
        Me.lblAprobarAprobacion.Location = New System.Drawing.Point(13, 9)
        Me.lblAprobarAprobacion.Name = "lblAprobarAprobacion"
        Me.lblAprobarAprobacion.Size = New System.Drawing.Size(44, 13)
        Me.lblAprobarAprobacion.TabIndex = 12
        Me.lblAprobarAprobacion.Text = "Aprobar"
        '
        'grbEstibaAprobacion
        '
        Me.grbEstibaAprobacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbEstibaAprobacion.Controls.Add(Me.dgvTarifaAprobacion)
        Me.grbEstibaAprobacion.Location = New System.Drawing.Point(16, 213)
        Me.grbEstibaAprobacion.Name = "grbEstibaAprobacion"
        Me.grbEstibaAprobacion.Size = New System.Drawing.Size(786, 205)
        Me.grbEstibaAprobacion.TabIndex = 305
        Me.grbEstibaAprobacion.TabStop = False
        Me.grbEstibaAprobacion.Text = "Tarifa"
        '
        'dgvTarifaAprobacion
        '
        Me.dgvTarifaAprobacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTarifaAprobacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTarifaAprobacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTarifaAprobacion.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTarifaAprobacion.Location = New System.Drawing.Point(5, 16)
        Me.dgvTarifaAprobacion.Name = "dgvTarifaAprobacion"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTarifaAprobacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTarifaAprobacion.Size = New System.Drawing.Size(775, 183)
        Me.dgvTarifaAprobacion.TabIndex = 0
        Me.dgvTarifaAprobacion.TabStop = False
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.Location = New System.Drawing.Point(13, 56)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(56, 13)
        Me.Label127.TabIndex = 297
        Me.Label127.Text = "Solicitante"
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.Location = New System.Drawing.Point(13, 23)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(37, 13)
        Me.Label128.TabIndex = 296
        Me.Label128.Text = "Fecha"
        '
        'Label130
        '
        Me.Label130.AutoSize = True
        Me.Label130.Location = New System.Drawing.Point(174, 23)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(40, 13)
        Me.Label130.TabIndex = 294
        Me.Label130.Text = "Ciudad"
        '
        'lblSolicitanteAprobacion
        '
        Me.lblSolicitanteAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicitanteAprobacion.ForeColor = System.Drawing.Color.Black
        Me.lblSolicitanteAprobacion.Location = New System.Drawing.Point(74, 56)
        Me.lblSolicitanteAprobacion.Name = "lblSolicitanteAprobacion"
        Me.lblSolicitanteAprobacion.Size = New System.Drawing.Size(318, 13)
        Me.lblSolicitanteAprobacion.TabIndex = 304
        Me.lblSolicitanteAprobacion.Text = "JUAN PEREZ MARTINEZ"
        '
        'lblFechaAprobacion
        '
        Me.lblFechaAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaAprobacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaAprobacion.Location = New System.Drawing.Point(74, 23)
        Me.lblFechaAprobacion.Name = "lblFechaAprobacion"
        Me.lblFechaAprobacion.Size = New System.Drawing.Size(97, 13)
        Me.lblFechaAprobacion.TabIndex = 303
        Me.lblFechaAprobacion.Text = "01/01/2015"
        '
        'lblCiudadAprobacion
        '
        Me.lblCiudadAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCiudadAprobacion.ForeColor = System.Drawing.Color.Black
        Me.lblCiudadAprobacion.Location = New System.Drawing.Point(233, 23)
        Me.lblCiudadAprobacion.Name = "lblCiudadAprobacion"
        Me.lblCiudadAprobacion.Size = New System.Drawing.Size(160, 13)
        Me.lblCiudadAprobacion.TabIndex = 299
        Me.lblCiudadAprobacion.Text = "CUSCO"
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbSalir, Me.tsbImprimir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(838, 25)
        Me.tool.TabIndex = 8
        Me.tool.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Enabled = False
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "Grabar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.Visible = False
        '
        'frmTarifarioAutorizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 495)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabTarifario)
        Me.Name = "frmTarifarioAutorizacion"
        Me.Text = "Autorización de Tarifas"
        Me.tabTarifario.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        Me.pnlEstadoReparto.ResumeLayout(False)
        Me.pnlEstadoReparto.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSolicitud.ResumeLayout(False)
        Me.tabSolicitud.PerformLayout()
        Me.grbTarifa.ResumeLayout(False)
        CType(Me.dgvTarifa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAprobacion.ResumeLayout(False)
        Me.tabAprobacion.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.grbEstibaAprobacion.ResumeLayout(False)
        CType(Me.dgvTarifaAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabTarifario As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents tabSolicitud As System.Windows.Forms.TabPage
    Friend WithEvents tabAprobacion As System.Windows.Forms.TabPage
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents lblSolicitante As System.Windows.Forms.Label
    Friend WithEvents lblNumeroSolicitud As System.Windows.Forms.Label
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents grbTarifa As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvTarifa As System.Windows.Forms.DataGridView
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlEstadoReparto As System.Windows.Forms.Panel
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label176 As System.Windows.Forms.Label
    Friend WithEvents lblObservacionAprobacion As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents txtObservacionAprobacion As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptarAprobacion As System.Windows.Forms.Button
    Friend WithEvents rbtNoAprobacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSiAprobacion As System.Windows.Forms.RadioButton
    Friend WithEvents lblAprobarAprobacion As System.Windows.Forms.Label
    Friend WithEvents grbEstibaAprobacion As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTarifaAprobacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents lblSolicitanteAprobacion As System.Windows.Forms.Label
    Friend WithEvents lblFechaAprobacion As System.Windows.Forms.Label
    Friend WithEvents lblCiudadAprobacion As System.Windows.Forms.Label
End Class
