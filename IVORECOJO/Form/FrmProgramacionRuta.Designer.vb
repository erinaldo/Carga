<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProgramacionRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProgramacionRuta))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolSalir = New System.Windows.Forms.ToolStripButton()
        Me.TabProgramacion = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.CboTipo = New System.Windows.Forms.ComboBox()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DgvLista = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtNumeroMovil = New System.Windows.Forms.TextBox()
        Me.dtpFechaProgramacion = New System.Windows.Forms.DateTimePicker()
        Me.btnVerRuta = New System.Windows.Forms.Button()
        Me.CboTipoRuta = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.DgvAyudante = New System.Windows.Forms.DataGridView()
        Me.DtpHora = New System.Windows.Forms.DateTimePicker()
        Me.CboAyudante = New System.Windows.Forms.ComboBox()
        Me.CboChofer = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.CboMovil = New System.Windows.Forms.ComboBox()
        Me.CboRuta = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.TabProgramacion.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvAyudante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNuevo, Me.ToolEditar, Me.ToolGrabar, Me.ToolAnular, Me.ToolStripButton6, Me.ToolSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(10)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(531, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolNuevo
        '
        Me.ToolNuevo.Image = CType(resources.GetObject("ToolNuevo.Image"), System.Drawing.Image)
        Me.ToolNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNuevo.Name = "ToolNuevo"
        Me.ToolNuevo.Size = New System.Drawing.Size(62, 22)
        Me.ToolNuevo.Text = "Nuevo"
        '
        'ToolEditar
        '
        Me.ToolEditar.Image = CType(resources.GetObject("ToolEditar.Image"), System.Drawing.Image)
        Me.ToolEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEditar.Name = "ToolEditar"
        Me.ToolEditar.Size = New System.Drawing.Size(57, 22)
        Me.ToolEditar.Text = "Editar"
        '
        'ToolGrabar
        '
        Me.ToolGrabar.Image = CType(resources.GetObject("ToolGrabar.Image"), System.Drawing.Image)
        Me.ToolGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolGrabar.Name = "ToolGrabar"
        Me.ToolGrabar.Size = New System.Drawing.Size(62, 22)
        Me.ToolGrabar.Text = "Grabar"
        '
        'ToolAnular
        '
        Me.ToolAnular.Image = CType(resources.GetObject("ToolAnular.Image"), System.Drawing.Image)
        Me.ToolAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAnular.Name = "ToolAnular"
        Me.ToolAnular.Size = New System.Drawing.Size(62, 22)
        Me.ToolAnular.Text = "Anular"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripButton6.Text = "Actualizar"
        Me.ToolStripButton6.Visible = False
        '
        'ToolSalir
        '
        Me.ToolSalir.Image = CType(resources.GetObject("ToolSalir.Image"), System.Drawing.Image)
        Me.ToolSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSalir.Name = "ToolSalir"
        Me.ToolSalir.Size = New System.Drawing.Size(49, 22)
        Me.ToolSalir.Text = "Salir"
        '
        'TabProgramacion
        '
        Me.TabProgramacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabProgramacion.Controls.Add(Me.TabPage1)
        Me.TabProgramacion.Controls.Add(Me.TabPage2)
        Me.TabProgramacion.Location = New System.Drawing.Point(5, 27)
        Me.TabProgramacion.Multiline = True
        Me.TabProgramacion.Name = "TabProgramacion"
        Me.TabProgramacion.SelectedIndex = 0
        Me.TabProgramacion.Size = New System.Drawing.Size(519, 434)
        Me.TabProgramacion.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnConsultar)
        Me.TabPage1.Controls.Add(Me.CboTipo)
        Me.TabPage1.Controls.Add(Me.dtpFin)
        Me.TabPage1.Controls.Add(Me.dtpInicio)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.DgvLista)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(511, 408)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(433, 7)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(72, 36)
        Me.btnConsultar.TabIndex = 36
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'CboTipo
        '
        Me.CboTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipo.FormattingEnabled = True
        Me.CboTipo.Location = New System.Drawing.Point(205, 206)
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.Size = New System.Drawing.Size(145, 21)
        Me.CboTipo.TabIndex = 35
        Me.CboTipo.Visible = False
        '
        'dtpFin
        '
        Me.dtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFin.CustomFormat = ""
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(205, 16)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(82, 20)
        Me.dtpFin.TabIndex = 34
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(82, 16)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtpInicio.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(181, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Al"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(171, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Tipo"
        Me.Label8.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(53, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Del"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Fecha"
        '
        'DgvLista
        '
        Me.DgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column4, Me.Column10})
        Me.DgvLista.Location = New System.Drawing.Point(6, 50)
        Me.DgvLista.Name = "DgvLista"
        Me.DgvLista.Size = New System.Drawing.Size(499, 352)
        Me.DgvLista.TabIndex = 32
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtNumeroMovil)
        Me.TabPage2.Controls.Add(Me.dtpFechaProgramacion)
        Me.TabPage2.Controls.Add(Me.btnVerRuta)
        Me.TabPage2.Controls.Add(Me.CboTipoRuta)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.BtnEliminar)
        Me.TabPage2.Controls.Add(Me.BtnAgregar)
        Me.TabPage2.Controls.Add(Me.DgvAyudante)
        Me.TabPage2.Controls.Add(Me.DtpHora)
        Me.TabPage2.Controls.Add(Me.CboAyudante)
        Me.TabPage2.Controls.Add(Me.CboChofer)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.cboProveedor)
        Me.TabPage2.Controls.Add(Me.CboMovil)
        Me.TabPage2.Controls.Add(Me.CboRuta)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(511, 408)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Programación"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtNumeroMovil
        '
        Me.txtNumeroMovil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumeroMovil.Location = New System.Drawing.Point(395, 133)
        Me.txtNumeroMovil.MaxLength = 10
        Me.txtNumeroMovil.Name = "txtNumeroMovil"
        Me.txtNumeroMovil.Size = New System.Drawing.Size(102, 20)
        Me.txtNumeroMovil.TabIndex = 5
        '
        'dtpFechaProgramacion
        '
        Me.dtpFechaProgramacion.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaProgramacion.CustomFormat = ""
        Me.dtpFechaProgramacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProgramacion.Location = New System.Drawing.Point(69, 10)
        Me.dtpFechaProgramacion.Name = "dtpFechaProgramacion"
        Me.dtpFechaProgramacion.Size = New System.Drawing.Size(82, 20)
        Me.dtpFechaProgramacion.TabIndex = 0
        '
        'btnVerRuta
        '
        Me.btnVerRuta.Location = New System.Drawing.Point(280, 37)
        Me.btnVerRuta.Name = "btnVerRuta"
        Me.btnVerRuta.Size = New System.Drawing.Size(26, 23)
        Me.btnVerRuta.TabIndex = 171
        Me.btnVerRuta.Text = "..."
        Me.btnVerRuta.UseVisualStyleBackColor = True
        '
        'CboTipoRuta
        '
        Me.CboTipoRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoRuta.FormattingEnabled = True
        Me.CboTipoRuta.Location = New System.Drawing.Point(131, 258)
        Me.CboTipoRuta.Name = "CboTipoRuta"
        Me.CboTipoRuta.Size = New System.Drawing.Size(175, 21)
        Me.CboTipoRuta.TabIndex = 0
        Me.CboTipoRuta.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(143, 261)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 170
        Me.Label9.Text = "Tipo"
        Me.Label9.Visible = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.BtnEliminar.Location = New System.Drawing.Point(465, 233)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(33, 23)
        Me.BtnEliminar.TabIndex = 8
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Enabled = False
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(465, 204)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(33, 23)
        Me.BtnAgregar.TabIndex = 7
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'DgvAyudante
        '
        Me.DgvAyudante.AllowDrop = True
        Me.DgvAyudante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvAyudante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAyudante.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5})
        Me.DgvAyudante.Location = New System.Drawing.Point(69, 206)
        Me.DgvAyudante.Name = "DgvAyudante"
        Me.DgvAyudante.Size = New System.Drawing.Size(390, 183)
        Me.DgvAyudante.TabIndex = 9
        '
        'DtpHora
        '
        Me.DtpHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpHora.CustomFormat = "hh:mm tt"
        Me.DtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHora.Location = New System.Drawing.Point(407, 37)
        Me.DtpHora.Name = "DtpHora"
        Me.DtpHora.ShowUpDown = True
        Me.DtpHora.Size = New System.Drawing.Size(90, 20)
        Me.DtpHora.TabIndex = 1
        '
        'CboAyudante
        '
        Me.CboAyudante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboAyudante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAyudante.FormattingEnabled = True
        Me.CboAyudante.Location = New System.Drawing.Point(69, 172)
        Me.CboAyudante.Name = "CboAyudante"
        Me.CboAyudante.Size = New System.Drawing.Size(428, 21)
        Me.CboAyudante.TabIndex = 6
        '
        'CboChofer
        '
        Me.CboChofer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboChofer.DropDownWidth = 428
        Me.CboChofer.FormattingEnabled = True
        Me.CboChofer.Location = New System.Drawing.Point(69, 134)
        Me.CboChofer.Name = "CboChofer"
        Me.CboChofer.Size = New System.Drawing.Size(250, 21)
        Me.CboChofer.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(335, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 162
        Me.Label5.Text = "Hora Salida"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 164
        Me.Label6.Text = "Ayudante"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 163
        Me.Label3.Text = "Chofer"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(335, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 166
        Me.Label13.Text = "Nº Celular"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 166
        Me.Label4.Text = "Fecha"
        '
        'cboProveedor
        '
        Me.cboProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(69, 69)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(428, 21)
        Me.cboProveedor.TabIndex = 2
        '
        'CboMovil
        '
        Me.CboMovil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMovil.FormattingEnabled = True
        Me.CboMovil.Location = New System.Drawing.Point(69, 101)
        Me.CboMovil.Name = "CboMovil"
        Me.CboMovil.Size = New System.Drawing.Size(428, 21)
        Me.CboMovil.TabIndex = 3
        '
        'CboRuta
        '
        Me.CboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRuta.FormattingEnabled = True
        Me.CboRuta.Location = New System.Drawing.Point(69, 38)
        Me.CboRuta.Name = "CboRuta"
        Me.CboRuta.Size = New System.Drawing.Size(207, 21)
        Me.CboRuta.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 165
        Me.Label12.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Ruta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "Móvil"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Ruta"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Móvil"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Chofer"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Activo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nombres"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.Width = 300
        '
        'Column1
        '
        Me.Column1.HeaderText = "Ruta"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Móvil"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Chofer"
        Me.Column4.Name = "Column4"
        '
        'Column10
        '
        Me.Column10.HeaderText = "Activo"
        Me.Column10.Name = "Column10"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nombres"
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.Width = 300
        '
        'FrmProgramacionRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 462)
        Me.Controls.Add(Me.TabProgramacion)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "FrmProgramacionRuta"
        Me.Text = "Programación de Ruta"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabProgramacion.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DgvAyudante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabProgramacion As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DgvAyudante As System.Windows.Forms.DataGridView
    Friend WithEvents DtpHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboChofer As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CboMovil As System.Windows.Forms.ComboBox
    Friend WithEvents CboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents CboAyudante As System.Windows.Forms.ComboBox
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CboTipoRuta As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnVerRuta As System.Windows.Forms.Button
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaProgramacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumeroMovil As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
