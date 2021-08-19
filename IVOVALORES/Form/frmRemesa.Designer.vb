<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemesa
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRemesa))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabRemesas = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.cboAgencia = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.tabRemesa = New System.Windows.Forms.TabPage()
        Me.btnRetirar = New System.Windows.Forms.Button()
        Me.grbDatos = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grbPortavalor = New System.Windows.Forms.GroupBox()
        Me.lblDni = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.cboPortavalor = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grbDestino = New System.Windows.Forms.GroupBox()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCuentaCorriente = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grbTotal = New System.Windows.Forms.GroupBox()
        Me.lblDolar = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBolsas = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSoles = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvBolsa = New System.Windows.Forms.DataGridView()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabRemesas.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRemesa.SuspendLayout()
        Me.grbDatos.SuspendLayout()
        Me.grbPortavalor.SuspendLayout()
        Me.grbDestino.SuspendLayout()
        Me.grbTotal.SuspendLayout()
        CType(Me.dgvBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabRemesas
        '
        Me.tabRemesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabRemesas.Controls.Add(Me.tabLista)
        Me.tabRemesas.Controls.Add(Me.tabRemesa)
        Me.tabRemesas.Location = New System.Drawing.Point(10, 30)
        Me.tabRemesas.Name = "tabRemesas"
        Me.tabRemesas.SelectedIndex = 0
        Me.tabRemesas.Size = New System.Drawing.Size(863, 563)
        Me.tabRemesas.TabIndex = 0
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.btnConsultar)
        Me.tabLista.Controls.Add(Me.cboAgencia)
        Me.tabLista.Controls.Add(Me.Label13)
        Me.tabLista.Controls.Add(Me.Label14)
        Me.tabLista.Controls.Add(Me.Label15)
        Me.tabLista.Controls.Add(Me.Label147)
        Me.tabLista.Controls.Add(Me.dtpFin)
        Me.tabLista.Controls.Add(Me.dtpInicio)
        Me.tabLista.Controls.Add(Me.dgvLista)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(855, 537)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(764, 7)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 38)
        Me.btnConsultar.TabIndex = 37
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboAgencia
        '
        Me.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgencia.Enabled = False
        Me.cboAgencia.FormattingEnabled = True
        Me.cboAgencia.Items.AddRange(New Object() {"(TODO)", "CARGA", "PASAJES"})
        Me.cboAgencia.Location = New System.Drawing.Point(481, 18)
        Me.cboAgencia.Name = "cboAgencia"
        Me.cboAgencia.Size = New System.Drawing.Size(242, 21)
        Me.cboAgencia.TabIndex = 36
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(418, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Agencia"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(230, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(16, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Al"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(73, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Del"
        '
        'Label147
        '
        Me.Label147.AutoSize = True
        Me.Label147.Location = New System.Drawing.Point(20, 24)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(37, 13)
        Me.Label147.TabIndex = 33
        Me.Label147.Text = "Fecha"
        '
        'dtpFin
        '
        Me.dtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFin.CustomFormat = ""
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(263, 20)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(92, 20)
        Me.dtpFin.TabIndex = 35
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(116, 20)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(92, 20)
        Me.dtpInicio.TabIndex = 35
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLista.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvLista.Location = New System.Drawing.Point(14, 56)
        Me.dgvLista.Name = "dgvLista"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvLista.Size = New System.Drawing.Size(825, 470)
        Me.dgvLista.TabIndex = 0
        '
        'tabRemesa
        '
        Me.tabRemesa.Controls.Add(Me.btnRetirar)
        Me.tabRemesa.Controls.Add(Me.grbDatos)
        Me.tabRemesa.Controls.Add(Me.grbPortavalor)
        Me.tabRemesa.Controls.Add(Me.grbDestino)
        Me.tabRemesa.Controls.Add(Me.txtCodigo)
        Me.tabRemesa.Controls.Add(Me.Label1)
        Me.tabRemesa.Controls.Add(Me.grbTotal)
        Me.tabRemesa.Controls.Add(Me.lblFecha)
        Me.tabRemesa.Controls.Add(Me.Label5)
        Me.tabRemesa.Controls.Add(Me.dgvBolsa)
        Me.tabRemesa.Location = New System.Drawing.Point(4, 22)
        Me.tabRemesa.Name = "tabRemesa"
        Me.tabRemesa.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRemesa.Size = New System.Drawing.Size(855, 537)
        Me.tabRemesa.TabIndex = 1
        Me.tabRemesa.Text = "Remesa"
        Me.tabRemesa.UseVisualStyleBackColor = True
        '
        'btnRetirar
        '
        Me.btnRetirar.Enabled = False
        Me.btnRetirar.Image = Global.INTEGRACION.My.Resources.Resources._1325
        Me.btnRetirar.Location = New System.Drawing.Point(813, 161)
        Me.btnRetirar.Name = "btnRetirar"
        Me.btnRetirar.Size = New System.Drawing.Size(28, 23)
        Me.btnRetirar.TabIndex = 13
        Me.btnRetirar.UseVisualStyleBackColor = True
        '
        'grbDatos
        '
        Me.grbDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbDatos.Controls.Add(Me.txtObservacion)
        Me.grbDatos.Controls.Add(Me.Label12)
        Me.grbDatos.Controls.Add(Me.txtComprobante)
        Me.grbDatos.Controls.Add(Me.Label7)
        Me.grbDatos.Location = New System.Drawing.Point(12, 109)
        Me.grbDatos.Name = "grbDatos"
        Me.grbDatos.Size = New System.Drawing.Size(829, 45)
        Me.grbDatos.TabIndex = 3
        Me.grbDatos.TabStop = False
        Me.grbDatos.Text = "Datos adicionales"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(285, 14)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(533, 20)
        Me.txtObservacion.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(210, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Observación"
        '
        'txtComprobante
        '
        Me.txtComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobante.Location = New System.Drawing.Point(101, 16)
        Me.txtComprobante.MaxLength = 15
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(103, 20)
        Me.txtComprobante.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Nº Comprobante"
        '
        'grbPortavalor
        '
        Me.grbPortavalor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPortavalor.Controls.Add(Me.lblDni)
        Me.grbPortavalor.Controls.Add(Me.lblCodigo)
        Me.grbPortavalor.Controls.Add(Me.cboPortavalor)
        Me.grbPortavalor.Controls.Add(Me.Label11)
        Me.grbPortavalor.Controls.Add(Me.Label10)
        Me.grbPortavalor.Controls.Add(Me.Label6)
        Me.grbPortavalor.Location = New System.Drawing.Point(297, 34)
        Me.grbPortavalor.Name = "grbPortavalor"
        Me.grbPortavalor.Size = New System.Drawing.Size(544, 71)
        Me.grbPortavalor.TabIndex = 2
        Me.grbPortavalor.TabStop = False
        Me.grbPortavalor.Text = "Portavalor"
        '
        'lblDni
        '
        Me.lblDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDni.Location = New System.Drawing.Point(424, 16)
        Me.lblDni.Name = "lblDni"
        Me.lblDni.Size = New System.Drawing.Size(83, 18)
        Me.lblDni.TabIndex = 12
        Me.lblDni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCodigo
        '
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCodigo.Location = New System.Drawing.Point(87, 44)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(84, 18)
        Me.lblCodigo.TabIndex = 11
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPortavalor
        '
        Me.cboPortavalor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPortavalor.FormattingEnabled = True
        Me.cboPortavalor.Location = New System.Drawing.Point(86, 15)
        Me.cboPortavalor.Name = "cboPortavalor"
        Me.cboPortavalor.Size = New System.Drawing.Size(271, 21)
        Me.cboPortavalor.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Código"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(387, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "DNI"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Nombres"
        '
        'grbDestino
        '
        Me.grbDestino.Controls.Add(Me.cboBanco)
        Me.grbDestino.Controls.Add(Me.Label8)
        Me.grbDestino.Controls.Add(Me.cboCuentaCorriente)
        Me.grbDestino.Controls.Add(Me.Label9)
        Me.grbDestino.Location = New System.Drawing.Point(12, 34)
        Me.grbDestino.Name = "grbDestino"
        Me.grbDestino.Size = New System.Drawing.Size(277, 71)
        Me.grbDestino.TabIndex = 1
        Me.grbDestino.TabStop = False
        Me.grbDestino.Text = "Destino"
        '
        'cboBanco
        '
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(63, 16)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(206, 21)
        Me.cboBanco.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Banco"
        '
        'cboCuentaCorriente
        '
        Me.cboCuentaCorriente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuentaCorriente.FormattingEnabled = True
        Me.cboCuentaCorriente.Location = New System.Drawing.Point(63, 42)
        Me.cboCuentaCorriente.Name = "cboCuentaCorriente"
        Me.cboCuentaCorriente.Size = New System.Drawing.Size(206, 21)
        Me.cboCuentaCorriente.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Cuenta"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(384, 160)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(159, 22)
        Me.txtCodigo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(308, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Código Bolsa"
        '
        'grbTotal
        '
        Me.grbTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbTotal.Controls.Add(Me.lblDolar)
        Me.grbTotal.Controls.Add(Me.Label3)
        Me.grbTotal.Controls.Add(Me.lblBolsas)
        Me.grbTotal.Controls.Add(Me.Label4)
        Me.grbTotal.Controls.Add(Me.lblSoles)
        Me.grbTotal.Controls.Add(Me.Label2)
        Me.grbTotal.Location = New System.Drawing.Point(12, 479)
        Me.grbTotal.Name = "grbTotal"
        Me.grbTotal.Size = New System.Drawing.Size(829, 50)
        Me.grbTotal.TabIndex = 1
        Me.grbTotal.TabStop = False
        Me.grbTotal.Text = "Total"
        '
        'lblDolar
        '
        Me.lblDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDolar.ForeColor = System.Drawing.Color.Maroon
        Me.lblDolar.Location = New System.Drawing.Point(630, 17)
        Me.lblDolar.Name = "lblDolar"
        Me.lblDolar.Size = New System.Drawing.Size(129, 17)
        Me.lblDolar.TabIndex = 0
        Me.lblDolar.Text = "0.00"
        Me.lblDolar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(538, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Monto Dólares"
        '
        'lblBolsas
        '
        Me.lblBolsas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBolsas.ForeColor = System.Drawing.Color.Maroon
        Me.lblBolsas.Location = New System.Drawing.Point(79, 17)
        Me.lblBolsas.Name = "lblBolsas"
        Me.lblBolsas.Size = New System.Drawing.Size(85, 17)
        Me.lblBolsas.TabIndex = 0
        Me.lblBolsas.Text = "0"
        Me.lblBolsas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total Bolsas"
        '
        'lblSoles
        '
        Me.lblSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoles.ForeColor = System.Drawing.Color.Maroon
        Me.lblSoles.Location = New System.Drawing.Point(332, 17)
        Me.lblSoles.Name = "lblSoles"
        Me.lblSoles.Size = New System.Drawing.Size(127, 17)
        Me.lblSoles.TabIndex = 0
        Me.lblSoles.Text = "0.00"
        Me.lblSoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Monto Soles"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(72, 12)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(75, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "08/08/2017"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha"
        '
        'dgvBolsa
        '
        Me.dgvBolsa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBolsa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBolsa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBolsa.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvBolsa.Location = New System.Drawing.Point(12, 192)
        Me.dgvBolsa.Name = "dgvBolsa"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBolsa.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvBolsa.Size = New System.Drawing.Size(829, 277)
        Me.dgvBolsa.TabIndex = 6
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(883, 25)
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'frmRemesa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 601)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabRemesas)
        Me.Name = "frmRemesa"
        Me.Text = "Remesa"
        Me.tabRemesas.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        Me.tabLista.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRemesa.ResumeLayout(False)
        Me.tabRemesa.PerformLayout()
        Me.grbDatos.ResumeLayout(False)
        Me.grbDatos.PerformLayout()
        Me.grbPortavalor.ResumeLayout(False)
        Me.grbPortavalor.PerformLayout()
        Me.grbDestino.ResumeLayout(False)
        Me.grbDestino.PerformLayout()
        Me.grbTotal.ResumeLayout(False)
        Me.grbTotal.PerformLayout()
        CType(Me.dgvBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabRemesas As System.Windows.Forms.TabControl
    Friend WithEvents tabRemesa As System.Windows.Forms.TabPage
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvBolsa As System.Windows.Forms.DataGridView
    Friend WithEvents grbTotal As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSoles As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDolar As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBolsas As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPortavalor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents cboCuentaCorriente As System.Windows.Forms.ComboBox
    Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grbDestino As System.Windows.Forms.GroupBox
    Friend WithEvents grbPortavalor As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDni As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents grbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRetirar As System.Windows.Forms.Button
End Class
