<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitudRecojo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitudRecojo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabRecojo = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.DgvLista = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrpEnvio = New System.Windows.Forms.GroupBox()
        Me.lblFuncionario = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvDestino = New System.Windows.Forms.DataGridView()
        Me.CboDestino = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtVolumen = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtBultos = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grpdatos = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.DtpHora1 = New System.Windows.Forms.DateTimePicker()
        Me.DtpHora2 = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.LblSobregiro = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.grpnom = New System.Windows.Forms.GroupBox()
        Me.TxtSolicitante = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtitem = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.grpcontacto = New System.Windows.Forms.GroupBox()
        Me.BtnContacto = New System.Windows.Forms.Button()
        Me.txtmovil = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtnom = New System.Windows.Forms.TextBox()
        Me.txttel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.grpdireccion = New System.Windows.Forms.GroupBox()
        Me.txtdist = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtpro = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtdepar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnDireccion = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtref = New System.Windows.Forms.TextBox()
        Me.txtdir = New System.Windows.Forms.TextBox()
        Me.Grpcliente = New System.Windows.Forms.GroupBox()
        Me.cboTipoCliente = New System.Windows.Forms.ComboBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.labnroidentidad = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.Tsbeditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGrabar = New System.Windows.Forms.ToolStripButton()
        Me.Tsbanular = New System.Windows.Forms.ToolStripButton()
        Me.Tsbactualizar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGeocodificar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCalaculadora = New System.Windows.Forms.ToolStripButton()
        Me.TsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabRecojo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GrpEnvio.SuspendLayout()
        CType(Me.dgvDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        Me.grpnom.SuspendLayout()
        Me.grpcontacto.SuspendLayout()
        Me.grpdireccion.SuspendLayout()
        Me.Grpcliente.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabRecojo
        '
        Me.TabRecojo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabRecojo.Controls.Add(Me.TabPage1)
        Me.TabRecojo.Controls.Add(Me.TabPage2)
        Me.TabRecojo.Location = New System.Drawing.Point(3, 27)
        Me.TabRecojo.Name = "TabRecojo"
        Me.TabRecojo.SelectedIndex = 0
        Me.TabRecojo.Size = New System.Drawing.Size(774, 568)
        Me.TabRecojo.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnConsultar)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtpFin)
        Me.TabPage1.Controls.Add(Me.dtpInicio)
        Me.TabPage1.Controls.Add(Me.DgvLista)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(766, 542)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(687, 3)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(72, 36)
        Me.btnConsultar.TabIndex = 34
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(228, 14)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 13)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "Al"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(90, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(23, 13)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Del"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Fecha Recojo"
        '
        'dtpFin
        '
        Me.dtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFin.CustomFormat = ""
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(252, 11)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(84, 20)
        Me.dtpFin.TabIndex = 11
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(119, 11)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(84, 20)
        Me.dtpInicio.TabIndex = 11
        '
        'DgvLista
        '
        Me.DgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column6, Me.Column7, Me.Column9, Me.Column10, Me.Column12, Me.Column8, Me.Column11})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvLista.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvLista.Location = New System.Drawing.Point(6, 43)
        Me.DgvLista.Name = "DgvLista"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvLista.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvLista.Size = New System.Drawing.Size(754, 493)
        Me.DgvLista.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.HeaderText = "Id"
        Me.Column2.Name = "Column2"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Cliente"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Dirección"
        Me.Column7.Name = "Column7"
        '
        'Column9
        '
        Me.Column9.HeaderText = "Hora Listo"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "Hora Cierre"
        Me.Column10.Name = "Column10"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Distrito"
        Me.Column12.Name = "Column12"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Contacto"
        Me.Column8.Name = "Column8"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Estado"
        Me.Column11.Name = "Column11"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GrpEnvio)
        Me.TabPage2.Controls.Add(Me.grpdatos)
        Me.TabPage2.Controls.Add(Me.LblSobregiro)
        Me.TabPage2.Controls.Add(Me.lblfecha)
        Me.TabPage2.Controls.Add(Me.grpnom)
        Me.TabPage2.Controls.Add(Me.txtitem)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.grpcontacto)
        Me.TabPage2.Controls.Add(Me.grpdireccion)
        Me.TabPage2.Controls.Add(Me.Grpcliente)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(766, 542)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Solicitud de Recojo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GrpEnvio
        '
        Me.GrpEnvio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEnvio.Controls.Add(Me.lblFuncionario)
        Me.GrpEnvio.Controls.Add(Me.btnEliminar)
        Me.GrpEnvio.Controls.Add(Me.btnAgregar)
        Me.GrpEnvio.Controls.Add(Me.dgvDestino)
        Me.GrpEnvio.Controls.Add(Me.CboDestino)
        Me.GrpEnvio.Controls.Add(Me.Label20)
        Me.GrpEnvio.Controls.Add(Me.Label19)
        Me.GrpEnvio.Controls.Add(Me.txtVolumen)
        Me.GrpEnvio.Controls.Add(Me.txtPeso)
        Me.GrpEnvio.Controls.Add(Me.txtBultos)
        Me.GrpEnvio.Controls.Add(Me.Label13)
        Me.GrpEnvio.Controls.Add(Me.Label17)
        Me.GrpEnvio.Location = New System.Drawing.Point(8, 395)
        Me.GrpEnvio.Name = "GrpEnvio"
        Me.GrpEnvio.Size = New System.Drawing.Size(747, 140)
        Me.GrpEnvio.TabIndex = 5
        Me.GrpEnvio.TabStop = False
        Me.GrpEnvio.Text = "Envío de Carga"
        '
        'lblFuncionario
        '
        Me.lblFuncionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionario.ForeColor = System.Drawing.Color.Red
        Me.lblFuncionario.Location = New System.Drawing.Point(5, 119)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(342, 13)
        Me.lblFuncionario.TabIndex = 185
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.btnEliminar.Location = New System.Drawing.Point(708, 69)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(33, 23)
        Me.btnEliminar.TabIndex = 184
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(708, 40)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(33, 23)
        Me.btnAgregar.TabIndex = 183
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvDestino
        '
        Me.dgvDestino.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDestino.Location = New System.Drawing.Point(356, 40)
        Me.dgvDestino.Name = "dgvDestino"
        Me.dgvDestino.Size = New System.Drawing.Size(346, 93)
        Me.dgvDestino.TabIndex = 182
        '
        'CboDestino
        '
        Me.CboDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDestino.FormattingEnabled = True
        Me.CboDestino.Location = New System.Drawing.Point(356, 12)
        Me.CboDestino.Name = "CboDestino"
        Me.CboDestino.Size = New System.Drawing.Size(382, 21)
        Me.CboDestino.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(149, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 181
        Me.Label20.Text = "Volúmen"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 180
        Me.Label19.Text = "Peso"
        '
        'txtVolumen
        '
        Me.txtVolumen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVolumen.Location = New System.Drawing.Point(201, 16)
        Me.txtVolumen.MaxLength = 10
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(78, 20)
        Me.txtVolumen.TabIndex = 10
        Me.txtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeso
        '
        Me.txtPeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPeso.Location = New System.Drawing.Point(60, 16)
        Me.txtPeso.MaxLength = 10
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(78, 20)
        Me.txtPeso.TabIndex = 9
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBultos
        '
        Me.txtBultos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBultos.Location = New System.Drawing.Point(60, 44)
        Me.txtBultos.MaxLength = 5
        Me.txtBultos.Name = "txtBultos"
        Me.txtBultos.Size = New System.Drawing.Size(78, 20)
        Me.txtBultos.TabIndex = 11
        Me.txtBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 176
        Me.Label13.Text = "Bultos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(304, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Destino"
        '
        'grpdatos
        '
        Me.grpdatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpdatos.Controls.Add(Me.Label21)
        Me.grpdatos.Controls.Add(Me.DtpFecha)
        Me.grpdatos.Controls.Add(Me.TxtObservacion)
        Me.grpdatos.Controls.Add(Me.Label15)
        Me.grpdatos.Controls.Add(Me.Label38)
        Me.grpdatos.Controls.Add(Me.DtpHora1)
        Me.grpdatos.Controls.Add(Me.DtpHora2)
        Me.grpdatos.Controls.Add(Me.Label26)
        Me.grpdatos.Location = New System.Drawing.Point(8, 276)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(747, 69)
        Me.grpdatos.TabIndex = 3
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Datos Recojo"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 45)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 13)
        Me.Label21.TabIndex = 188
        Me.Label21.Text = "Fecha Recojo"
        '
        'DtpFecha
        '
        Me.DtpFecha.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DtpFecha.CustomFormat = ""
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(80, 43)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(87, 20)
        Me.DtpFecha.TabIndex = 189
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservacion.Location = New System.Drawing.Point(425, 17)
        Me.TxtObservacion.MaxLength = 100
        Me.TxtObservacion.Multiline = True
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(314, 46)
        Me.TxtObservacion.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(353, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 187
        Me.Label15.Text = "Observación"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Location = New System.Drawing.Point(3, 20)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 13)
        Me.Label38.TabIndex = 161
        Me.Label38.Text = "Hora Listo"
        '
        'DtpHora1
        '
        Me.DtpHora1.CustomFormat = "HH:mm"
        Me.DtpHora1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHora1.Location = New System.Drawing.Point(80, 17)
        Me.DtpHora1.Name = "DtpHora1"
        Me.DtpHora1.ShowUpDown = True
        Me.DtpHora1.Size = New System.Drawing.Size(90, 20)
        Me.DtpHora1.TabIndex = 5
        '
        'DtpHora2
        '
        Me.DtpHora2.CustomFormat = "HH:mm"
        Me.DtpHora2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHora2.Location = New System.Drawing.Point(248, 18)
        Me.DtpHora2.Name = "DtpHora2"
        Me.DtpHora2.ShowUpDown = True
        Me.DtpHora2.Size = New System.Drawing.Size(86, 20)
        Me.DtpHora2.TabIndex = 6
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(182, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(60, 13)
        Me.Label26.TabIndex = 162
        Me.Label26.Text = "Hora Cierre"
        '
        'LblSobregiro
        '
        Me.LblSobregiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSobregiro.ForeColor = System.Drawing.Color.Red
        Me.LblSobregiro.Location = New System.Drawing.Point(280, 10)
        Me.LblSobregiro.Name = "LblSobregiro"
        Me.LblSobregiro.Size = New System.Drawing.Size(276, 15)
        Me.LblSobregiro.TabIndex = 173
        Me.LblSobregiro.Text = "Cliente con Sobregiro de S/. "
        Me.LblSobregiro.Visible = False
        '
        'lblfecha
        '
        Me.lblfecha.AutoSize = True
        Me.lblfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha.ForeColor = System.Drawing.Color.Red
        Me.lblfecha.Location = New System.Drawing.Point(69, 10)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(79, 15)
        Me.lblfecha.TabIndex = 173
        Me.lblfecha.Text = "01/01/2011"
        '
        'grpnom
        '
        Me.grpnom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpnom.Controls.Add(Me.TxtSolicitante)
        Me.grpnom.Controls.Add(Me.Label9)
        Me.grpnom.Location = New System.Drawing.Point(8, 349)
        Me.grpnom.Name = "grpnom"
        Me.grpnom.Size = New System.Drawing.Size(748, 43)
        Me.grpnom.TabIndex = 4
        Me.grpnom.TabStop = False
        Me.grpnom.Text = "Solicitante"
        '
        'TxtSolicitante
        '
        Me.TxtSolicitante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSolicitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSolicitante.Location = New System.Drawing.Point(67, 15)
        Me.TxtSolicitante.MaxLength = 50
        Me.TxtSolicitante.Name = "TxtSolicitante"
        Me.TxtSolicitante.Size = New System.Drawing.Size(671, 20)
        Me.TxtSolicitante.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Nombres"
        '
        'txtitem
        '
        Me.txtitem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtitem.BackColor = System.Drawing.Color.White
        Me.txtitem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitem.ForeColor = System.Drawing.Color.Red
        Me.txtitem.Location = New System.Drawing.Point(686, 9)
        Me.txtitem.Name = "txtitem"
        Me.txtitem.Size = New System.Drawing.Size(66, 17)
        Me.txtitem.TabIndex = 170
        Me.txtitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(662, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(19, 13)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Nº"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Fecha"
        '
        'grpcontacto
        '
        Me.grpcontacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpcontacto.Controls.Add(Me.BtnContacto)
        Me.grpcontacto.Controls.Add(Me.txtmovil)
        Me.grpcontacto.Controls.Add(Me.Label7)
        Me.grpcontacto.Controls.Add(Me.txtnom)
        Me.grpcontacto.Controls.Add(Me.txttel)
        Me.grpcontacto.Controls.Add(Me.Label4)
        Me.grpcontacto.Controls.Add(Me.Label6)
        Me.grpcontacto.Controls.Add(Me.Label8)
        Me.grpcontacto.Controls.Add(Me.txtemail)
        Me.grpcontacto.Location = New System.Drawing.Point(8, 106)
        Me.grpcontacto.Name = "grpcontacto"
        Me.grpcontacto.Size = New System.Drawing.Size(746, 71)
        Me.grpcontacto.TabIndex = 1
        Me.grpcontacto.TabStop = False
        Me.grpcontacto.Text = "Contacto"
        '
        'BtnContacto
        '
        Me.BtnContacto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnContacto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnContacto.Enabled = False
        Me.BtnContacto.Location = New System.Drawing.Point(715, 17)
        Me.BtnContacto.Name = "BtnContacto"
        Me.BtnContacto.Size = New System.Drawing.Size(26, 21)
        Me.BtnContacto.TabIndex = 3
        Me.BtnContacto.Text = "..."
        Me.BtnContacto.UseVisualStyleBackColor = True
        '
        'txtmovil
        '
        Me.txtmovil.Location = New System.Drawing.Point(579, 43)
        Me.txtmovil.Name = "txtmovil"
        Me.txtmovil.ReadOnly = True
        Me.txtmovil.Size = New System.Drawing.Size(130, 20)
        Me.txtmovil.TabIndex = 1
        Me.txtmovil.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(545, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Móvil"
        '
        'txtnom
        '
        Me.txtnom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtnom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnom.Location = New System.Drawing.Point(67, 18)
        Me.txtnom.Name = "txtnom"
        Me.txtnom.ReadOnly = True
        Me.txtnom.Size = New System.Drawing.Size(642, 20)
        Me.txtnom.TabIndex = 1
        Me.txtnom.TabStop = False
        '
        'txttel
        '
        Me.txttel.Location = New System.Drawing.Point(344, 43)
        Me.txttel.Name = "txttel"
        Me.txttel.ReadOnly = True
        Me.txttel.Size = New System.Drawing.Size(130, 20)
        Me.txttel.TabIndex = 1
        Me.txttel.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nombres"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(298, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tel. Fijo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Email"
        '
        'txtemail
        '
        Me.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtemail.Location = New System.Drawing.Point(67, 43)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.ReadOnly = True
        Me.txtemail.Size = New System.Drawing.Size(227, 20)
        Me.txtemail.TabIndex = 1
        Me.txtemail.TabStop = False
        '
        'grpdireccion
        '
        Me.grpdireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpdireccion.Controls.Add(Me.txtdist)
        Me.grpdireccion.Controls.Add(Me.Label1)
        Me.grpdireccion.Controls.Add(Me.txtpro)
        Me.grpdireccion.Controls.Add(Me.Label12)
        Me.grpdireccion.Controls.Add(Me.txtdepar)
        Me.grpdireccion.Controls.Add(Me.Label5)
        Me.grpdireccion.Controls.Add(Me.BtnDireccion)
        Me.grpdireccion.Controls.Add(Me.Label3)
        Me.grpdireccion.Controls.Add(Me.Label11)
        Me.grpdireccion.Controls.Add(Me.txtref)
        Me.grpdireccion.Controls.Add(Me.txtdir)
        Me.grpdireccion.Location = New System.Drawing.Point(8, 179)
        Me.grpdireccion.Name = "grpdireccion"
        Me.grpdireccion.Size = New System.Drawing.Size(746, 93)
        Me.grpdireccion.TabIndex = 2
        Me.grpdireccion.TabStop = False
        Me.grpdireccion.Text = "Dirección"
        '
        'txtdist
        '
        Me.txtdist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdist.Location = New System.Drawing.Point(516, 62)
        Me.txtdist.Name = "txtdist"
        Me.txtdist.ReadOnly = True
        Me.txtdist.Size = New System.Drawing.Size(194, 20)
        Me.txtdist.TabIndex = 16
        Me.txtdist.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(478, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Distrito"
        '
        'txtpro
        '
        Me.txtpro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpro.Location = New System.Drawing.Point(296, 63)
        Me.txtpro.Name = "txtpro"
        Me.txtpro.ReadOnly = True
        Me.txtpro.Size = New System.Drawing.Size(178, 20)
        Me.txtpro.TabIndex = 14
        Me.txtpro.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(239, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Provincia"
        '
        'txtdepar
        '
        Me.txtdepar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdepar.Location = New System.Drawing.Point(67, 63)
        Me.txtdepar.Name = "txtdepar"
        Me.txtdepar.ReadOnly = True
        Me.txtdepar.Size = New System.Drawing.Size(163, 20)
        Me.txtdepar.TabIndex = 12
        Me.txtdepar.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Depart."
        '
        'BtnDireccion
        '
        Me.BtnDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDireccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDireccion.Enabled = False
        Me.BtnDireccion.Location = New System.Drawing.Point(715, 13)
        Me.BtnDireccion.Name = "BtnDireccion"
        Me.BtnDireccion.Size = New System.Drawing.Size(26, 21)
        Me.BtnDireccion.TabIndex = 4
        Me.BtnDireccion.Text = "..."
        Me.BtnDireccion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Referencia"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Dirección"
        '
        'txtref
        '
        Me.txtref.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtref.Location = New System.Drawing.Point(67, 38)
        Me.txtref.Name = "txtref"
        Me.txtref.ReadOnly = True
        Me.txtref.Size = New System.Drawing.Size(643, 20)
        Me.txtref.TabIndex = 1
        Me.txtref.TabStop = False
        '
        'txtdir
        '
        Me.txtdir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdir.Location = New System.Drawing.Point(67, 14)
        Me.txtdir.Name = "txtdir"
        Me.txtdir.ReadOnly = True
        Me.txtdir.Size = New System.Drawing.Size(643, 20)
        Me.txtdir.TabIndex = 1
        Me.txtdir.TabStop = False
        '
        'Grpcliente
        '
        Me.Grpcliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grpcliente.Controls.Add(Me.cboTipoCliente)
        Me.Grpcliente.Controls.Add(Me.cboProducto)
        Me.Grpcliente.Controls.Add(Me.TxtNumero)
        Me.Grpcliente.Controls.Add(Me.BtnCliente)
        Me.Grpcliente.Controls.Add(Me.Label14)
        Me.Grpcliente.Controls.Add(Me.Label18)
        Me.Grpcliente.Controls.Add(Me.labnroidentidad)
        Me.Grpcliente.Controls.Add(Me.Label10)
        Me.Grpcliente.Controls.Add(Me.TxtCliente)
        Me.Grpcliente.Location = New System.Drawing.Point(8, 30)
        Me.Grpcliente.Name = "Grpcliente"
        Me.Grpcliente.Size = New System.Drawing.Size(746, 73)
        Me.Grpcliente.TabIndex = 0
        Me.Grpcliente.TabStop = False
        Me.Grpcliente.Text = "Cliente"
        '
        'cboTipoCliente
        '
        Me.cboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCliente.FormattingEnabled = True
        Me.cboTipoCliente.Items.AddRange(New Object() {"(SELECCIONE)", "CONTADO", "CREDITO"})
        Me.cboTipoCliente.Location = New System.Drawing.Point(273, 14)
        Me.cboTipoCliente.Name = "cboTipoCliente"
        Me.cboTipoCliente.Size = New System.Drawing.Size(149, 21)
        Me.cboTipoCliente.TabIndex = 42
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(529, 14)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(209, 21)
        Me.cboProducto.TabIndex = 42
        '
        'TxtNumero
        '
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Location = New System.Drawing.Point(67, 15)
        Me.TxtNumero.MaxLength = 11
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(103, 20)
        Me.TxtNumero.TabIndex = 0
        '
        'BtnCliente
        '
        Me.BtnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCliente.Location = New System.Drawing.Point(713, 41)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(26, 21)
        Me.BtnCliente.TabIndex = 2
        Me.BtnCliente.Text = "..."
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(473, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Producto"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(200, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Tipo Cliente"
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(3, 18)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(45, 13)
        Me.labnroidentidad.TabIndex = 41
        Me.labnroidentidad.Text = "Nº Doc."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Nombres"
        '
        'TxtCliente
        '
        Me.TxtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCliente.Location = New System.Drawing.Point(67, 42)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(642, 20)
        Me.TxtCliente.TabIndex = 1
        Me.TxtCliente.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbNuevo, Me.Tsbeditar, Me.TSBGrabar, Me.Tsbanular, Me.Tsbactualizar, Me.tsbGeocodificar, Me.TSBCalaculadora, Me.TsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(10)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(779, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TsbNuevo
        '
        Me.TsbNuevo.Image = CType(resources.GetObject("TsbNuevo.Image"), System.Drawing.Image)
        Me.TsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbNuevo.Name = "TsbNuevo"
        Me.TsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.TsbNuevo.Text = "Nuevo"
        '
        'Tsbeditar
        '
        Me.Tsbeditar.Enabled = False
        Me.Tsbeditar.Image = CType(resources.GetObject("Tsbeditar.Image"), System.Drawing.Image)
        Me.Tsbeditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbeditar.Name = "Tsbeditar"
        Me.Tsbeditar.Size = New System.Drawing.Size(57, 22)
        Me.Tsbeditar.Text = "Editar"
        '
        'TSBGrabar
        '
        Me.TSBGrabar.Image = CType(resources.GetObject("TSBGrabar.Image"), System.Drawing.Image)
        Me.TSBGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGrabar.Name = "TSBGrabar"
        Me.TSBGrabar.Size = New System.Drawing.Size(62, 22)
        Me.TSBGrabar.Text = "Grabar"
        '
        'Tsbanular
        '
        Me.Tsbanular.Enabled = False
        Me.Tsbanular.Image = CType(resources.GetObject("Tsbanular.Image"), System.Drawing.Image)
        Me.Tsbanular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbanular.Name = "Tsbanular"
        Me.Tsbanular.Size = New System.Drawing.Size(73, 22)
        Me.Tsbanular.Text = "Cancelar"
        '
        'Tsbactualizar
        '
        Me.Tsbactualizar.Enabled = False
        Me.Tsbactualizar.Image = CType(resources.GetObject("Tsbactualizar.Image"), System.Drawing.Image)
        Me.Tsbactualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbactualizar.Name = "Tsbactualizar"
        Me.Tsbactualizar.Size = New System.Drawing.Size(79, 22)
        Me.Tsbactualizar.Text = "Actualizar"
        Me.Tsbactualizar.Visible = False
        '
        'tsbGeocodificar
        '
        Me.tsbGeocodificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbGeocodificar.Image = CType(resources.GetObject("tsbGeocodificar.Image"), System.Drawing.Image)
        Me.tsbGeocodificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGeocodificar.Name = "tsbGeocodificar"
        Me.tsbGeocodificar.Size = New System.Drawing.Size(131, 22)
        Me.tsbGeocodificar.Text = "Geocodificar Dirección"
        '
        'TSBCalaculadora
        '
        Me.TSBCalaculadora.Image = CType(resources.GetObject("TSBCalaculadora.Image"), System.Drawing.Image)
        Me.TSBCalaculadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCalaculadora.Name = "TSBCalaculadora"
        Me.TSBCalaculadora.Size = New System.Drawing.Size(90, 22)
        Me.TSBCalaculadora.Text = "Calculadora"
        Me.TSBCalaculadora.Visible = False
        '
        'TsbSalir
        '
        Me.TsbSalir.Image = CType(resources.GetObject("TsbSalir.Image"), System.Drawing.Image)
        Me.TsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbSalir.Name = "TsbSalir"
        Me.TsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.TsbSalir.Text = "Salir"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cliente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dirección"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Hora Listo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Hora Cierre"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Distrito"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Contacto"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'FrmSolicitudRecojo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 598)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabRecojo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "FrmSolicitudRecojo"
        Me.Text = "Solicitud de Recojo"
        Me.TabRecojo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GrpEnvio.ResumeLayout(False)
        Me.GrpEnvio.PerformLayout()
        CType(Me.dgvDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        Me.grpnom.ResumeLayout(False)
        Me.grpnom.PerformLayout()
        Me.grpcontacto.ResumeLayout(False)
        Me.grpcontacto.PerformLayout()
        Me.grpdireccion.ResumeLayout(False)
        Me.grpdireccion.PerformLayout()
        Me.Grpcliente.ResumeLayout(False)
        Me.Grpcliente.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabRecojo As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents grpcontacto As System.Windows.Forms.GroupBox
    Friend WithEvents txttel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtmovil As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Grpcliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtpHora2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpHora1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtnom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grpdireccion As System.Windows.Forms.GroupBox
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDireccion As System.Windows.Forms.Button
    Friend WithEvents txtdir As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents BtnContacto As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtitem As System.Windows.Forms.Label
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents BtnCliente As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents TxtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbeditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbanular As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbactualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCalaculadora As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpnom As System.Windows.Forms.GroupBox
    Friend WithEvents txtpro As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtdepar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblfecha As System.Windows.Forms.Label
    Friend WithEvents txtdist As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GrpEnvio As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtBultos As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblSobregiro As System.Windows.Forms.Label
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dgvDestino As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblFuncionario As System.Windows.Forms.Label
    Friend WithEvents tsbGeocodificar As System.Windows.Forms.ToolStripButton

End Class
