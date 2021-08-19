<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaDebito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaDebito))
        Me.tabNotaDebito = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tabEmision = New System.Windows.Forms.TabPage()
        Me.grbDebito = New System.Windows.Forms.GroupBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.lblImpuestoDebito = New System.Windows.Forms.Label()
        Me.dtpFechaDebito = New System.Windows.Forms.DateTimePicker()
        Me.cboOperacion = New System.Windows.Forms.ComboBox()
        Me.lblTotalDebito = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblNumeroDebito = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblSerieDebito = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grbComprobante = New System.Windows.Forms.GroupBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtOtros = New System.Windows.Forms.RadioButton()
        Me.rbtCredito = New System.Windows.Forms.RadioButton()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTipoAfectacion = New System.Windows.Forms.Label()
        Me.tabNotaDebito.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmision.SuspendLayout()
        Me.grbDebito.SuspendLayout()
        Me.grbCliente.SuspendLayout()
        Me.grbComprobante.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabNotaDebito
        '
        Me.tabNotaDebito.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabNotaDebito.Controls.Add(Me.tabLista)
        Me.tabNotaDebito.Controls.Add(Me.tabEmision)
        Me.tabNotaDebito.Location = New System.Drawing.Point(11, 28)
        Me.tabNotaDebito.Name = "tabNotaDebito"
        Me.tabNotaDebito.SelectedIndex = 0
        Me.tabNotaDebito.Size = New System.Drawing.Size(723, 460)
        Me.tabNotaDebito.TabIndex = 0
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.btnBuscar)
        Me.tabLista.Controls.Add(Me.dtpFechaFin)
        Me.tabLista.Controls.Add(Me.dgvLista)
        Me.tabLista.Controls.Add(Me.Label21)
        Me.tabLista.Controls.Add(Me.dtpFechaInicio)
        Me.tabLista.Controls.Add(Me.Label31)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(715, 434)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(620, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 34)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(262, 18)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(90, 20)
        Me.dtpFechaFin.TabIndex = 54
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(16, 55)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(679, 367)
        Me.dgvLista.TabIndex = 0
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(196, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 52
        Me.Label21.Text = "Fecha Fin"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(86, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(90, 20)
        Me.dtpFechaInicio.TabIndex = 53
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(13, 22)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 13)
        Me.Label31.TabIndex = 51
        Me.Label31.Text = "Fecha Inicio"
        '
        'tabEmision
        '
        Me.tabEmision.Controls.Add(Me.grbDebito)
        Me.tabEmision.Controls.Add(Me.btnCancelar)
        Me.tabEmision.Controls.Add(Me.btnGrabar)
        Me.tabEmision.Controls.Add(Me.grbCliente)
        Me.tabEmision.Controls.Add(Me.grbComprobante)
        Me.tabEmision.Location = New System.Drawing.Point(4, 22)
        Me.tabEmision.Name = "tabEmision"
        Me.tabEmision.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEmision.Size = New System.Drawing.Size(715, 434)
        Me.tabEmision.TabIndex = 1
        Me.tabEmision.Text = "Emisión"
        Me.tabEmision.UseVisualStyleBackColor = True
        '
        'grbDebito
        '
        Me.grbDebito.Controls.Add(Me.txtSubtotal)
        Me.grbDebito.Controls.Add(Me.Label5)
        Me.grbDebito.Controls.Add(Me.Label15)
        Me.grbDebito.Controls.Add(Me.Label17)
        Me.grbDebito.Controls.Add(Me.txtGlosa)
        Me.grbDebito.Controls.Add(Me.lblImpuestoDebito)
        Me.grbDebito.Controls.Add(Me.dtpFechaDebito)
        Me.grbDebito.Controls.Add(Me.cboOperacion)
        Me.grbDebito.Controls.Add(Me.lblTotalDebito)
        Me.grbDebito.Controls.Add(Me.Label18)
        Me.grbDebito.Controls.Add(Me.lblNumeroDebito)
        Me.grbDebito.Controls.Add(Me.Label25)
        Me.grbDebito.Controls.Add(Me.Label16)
        Me.grbDebito.Controls.Add(Me.Label3)
        Me.grbDebito.Controls.Add(Me.Label14)
        Me.grbDebito.Controls.Add(Me.lblSerieDebito)
        Me.grbDebito.Location = New System.Drawing.Point(22, 194)
        Me.grbDebito.Name = "grbDebito"
        Me.grbDebito.Size = New System.Drawing.Size(502, 232)
        Me.grbDebito.TabIndex = 3
        Me.grbDebito.TabStop = False
        Me.grbDebito.Text = "Nota de Débito"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(64, 196)
        Me.txtSubtotal.MaxLength = 9
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(90, 20)
        Me.txtSubtotal.TabIndex = 7
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Total"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(196, 199)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 110
        Me.Label15.Text = "Impuesto"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 199)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 111
        Me.Label17.Text = "Subtotal"
        '
        'txtGlosa
        '
        Me.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa.Location = New System.Drawing.Point(60, 94)
        Me.txtGlosa.MaxLength = 100
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(416, 86)
        Me.txtGlosa.TabIndex = 6
        '
        'lblImpuestoDebito
        '
        Me.lblImpuestoDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpuestoDebito.Location = New System.Drawing.Point(253, 200)
        Me.lblImpuestoDebito.Name = "lblImpuestoDebito"
        Me.lblImpuestoDebito.Size = New System.Drawing.Size(66, 13)
        Me.lblImpuestoDebito.TabIndex = 2
        Me.lblImpuestoDebito.Text = "0.00"
        Me.lblImpuestoDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaDebito
        '
        Me.dtpFechaDebito.CalendarForeColor = System.Drawing.SystemColors.Info
        Me.dtpFechaDebito.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDebito.Location = New System.Drawing.Point(355, 57)
        Me.dtpFechaDebito.Name = "dtpFechaDebito"
        Me.dtpFechaDebito.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaDebito.TabIndex = 5
        '
        'cboOperacion
        '
        Me.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperacion.FormattingEnabled = True
        Me.cboOperacion.Location = New System.Drawing.Point(98, 22)
        Me.cboOperacion.Name = "cboOperacion"
        Me.cboOperacion.Size = New System.Drawing.Size(378, 21)
        Me.cboOperacion.TabIndex = 4
        '
        'lblTotalDebito
        '
        Me.lblTotalDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDebito.Location = New System.Drawing.Point(402, 199)
        Me.lblTotalDebito.Name = "lblTotalDebito"
        Me.lblTotalDebito.Size = New System.Drawing.Size(74, 13)
        Me.lblTotalDebito.TabIndex = 2
        Me.lblTotalDebito.Text = "0.00"
        Me.lblTotalDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(267, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Fecha emisión"
        '
        'lblNumeroDebito
        '
        Me.lblNumeroDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDebito.Location = New System.Drawing.Point(171, 62)
        Me.lblNumeroDebito.Name = "lblNumeroDebito"
        Me.lblNumeroDebito.Size = New System.Drawing.Size(63, 13)
        Me.lblNumeroDebito.TabIndex = 2
        Me.lblNumeroDebito.Text = "0000001"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(9, 25)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 13)
        Me.Label25.TabIndex = 106
        Me.Label25.Text = "Operación"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(115, 62)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Número"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Glosa"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Serie"
        '
        'lblSerieDebito
        '
        Me.lblSerieDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerieDebito.Location = New System.Drawing.Point(51, 62)
        Me.lblSerieDebito.Name = "lblSerieDebito"
        Me.lblSerieDebito.Size = New System.Drawing.Size(48, 13)
        Me.lblSerieDebito.TabIndex = 2
        Me.lblSerieDebito.Text = "F002"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(579, 69)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 33)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(579, 21)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 33)
        Me.btnGrabar.TabIndex = 8
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'grbCliente
        '
        Me.grbCliente.Controls.Add(Me.lblRazonSocial)
        Me.grbCliente.Controls.Add(Me.Label11)
        Me.grbCliente.Controls.Add(Me.lblNumeroDocumento)
        Me.grbCliente.Controls.Add(Me.Label8)
        Me.grbCliente.Location = New System.Drawing.Point(22, 126)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(502, 54)
        Me.grbCliente.TabIndex = 1
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Cliente"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(215, 22)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(278, 13)
        Me.lblRazonSocial.TabIndex = 2
        Me.lblRazonSocial.Text = "TRANSPORTES EL PINO SAC"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(141, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Razón social"
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(45, 22)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(87, 13)
        Me.lblNumeroDocumento.TabIndex = 2
        Me.lblNumeroDocumento.Text = "10255774501"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Ruc"
        '
        'grbComprobante
        '
        Me.grbComprobante.Controls.Add(Me.txtNumero)
        Me.grbComprobante.Controls.Add(Me.txtSerie)
        Me.grbComprobante.Controls.Add(Me.lblFecha)
        Me.grbComprobante.Controls.Add(Me.Label4)
        Me.grbComprobante.Controls.Add(Me.Label2)
        Me.grbComprobante.Controls.Add(Me.lblImpuesto)
        Me.grbComprobante.Controls.Add(Me.Label7)
        Me.grbComprobante.Controls.Add(Me.lblTotal)
        Me.grbComprobante.Controls.Add(Me.Label9)
        Me.grbComprobante.Controls.Add(Me.lblSubtotal)
        Me.grbComprobante.Controls.Add(Me.Label6)
        Me.grbComprobante.Controls.Add(Me.lblTipoAfectacion)
        Me.grbComprobante.Controls.Add(Me.lblMoneda)
        Me.grbComprobante.Controls.Add(Me.Label10)
        Me.grbComprobante.Controls.Add(Me.Label13)
        Me.grbComprobante.Controls.Add(Me.Label1)
        Me.grbComprobante.Controls.Add(Me.rbtOtros)
        Me.grbComprobante.Controls.Add(Me.rbtCredito)
        Me.grbComprobante.Location = New System.Drawing.Point(22, 13)
        Me.grbComprobante.Name = "grbComprobante"
        Me.grbComprobante.Size = New System.Drawing.Size(502, 103)
        Me.grbComprobante.TabIndex = 0
        Me.grbComprobante.TabStop = False
        Me.grbComprobante.Text = "Comprobante actual"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(165, 44)
        Me.txtNumero.MaxLength = 7
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(92, 20)
        Me.txtNumero.TabIndex = 3
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(48, 44)
        Me.txtSerie.MaxLength = 4
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(52, 20)
        Me.txtSerie.TabIndex = 2
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(352, 47)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(79, 13)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "01/05/2017"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(267, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fecha emisión"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Número"
        '
        'lblImpuesto
        '
        Me.lblImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpuesto.Location = New System.Drawing.Point(307, 72)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(66, 13)
        Me.lblImpuesto.TabIndex = 2
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(255, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Impuesto"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(417, 71)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(74, 13)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(382, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Total"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.Location = New System.Drawing.Point(165, 72)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(74, 13)
        Me.lblSubtotal.TabIndex = 2
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(114, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Subtotal"
        '
        'lblMoneda
        '
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.Location = New System.Drawing.Point(52, 73)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(59, 13)
        Me.lblMoneda.TabIndex = 2
        Me.lblMoneda.Text = "SOLES"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Moneda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Serie"
        '
        'rbtOtros
        '
        Me.rbtOtros.AutoSize = True
        Me.rbtOtros.Checked = True
        Me.rbtOtros.Location = New System.Drawing.Point(94, 20)
        Me.rbtOtros.Name = "rbtOtros"
        Me.rbtOtros.Size = New System.Drawing.Size(50, 17)
        Me.rbtOtros.TabIndex = 1
        Me.rbtOtros.TabStop = True
        Me.rbtOtros.Text = "Otros"
        Me.rbtOtros.UseVisualStyleBackColor = True
        '
        'rbtCredito
        '
        Me.rbtCredito.AutoSize = True
        Me.rbtCredito.Location = New System.Drawing.Point(8, 21)
        Me.rbtCredito.Name = "rbtCredito"
        Me.rbtCredito.Size = New System.Drawing.Size(58, 17)
        Me.rbtCredito.TabIndex = 0
        Me.rbtCredito.Text = "Crédito"
        Me.rbtCredito.UseVisualStyleBackColor = True
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(745, 25)
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(267, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Tipo de afectación"
        '
        'lblTipoAfectacion
        '
        Me.lblTipoAfectacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoAfectacion.Location = New System.Drawing.Point(369, 16)
        Me.lblTipoAfectacion.Name = "lblTipoAfectacion"
        Me.lblTipoAfectacion.Size = New System.Drawing.Size(124, 13)
        Me.lblTipoAfectacion.TabIndex = 2
        Me.lblTipoAfectacion.Text = "AFECTO"
        '
        'frmNotaDebito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 496)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabNotaDebito)
        Me.Name = "frmNotaDebito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota de Débito"
        Me.tabNotaDebito.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        Me.tabLista.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmision.ResumeLayout(False)
        Me.grbDebito.ResumeLayout(False)
        Me.grbDebito.PerformLayout()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.grbComprobante.ResumeLayout(False)
        Me.grbComprobante.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabNotaDebito As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents tabEmision As System.Windows.Forms.TabPage
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents grbComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents rbtOtros As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCredito As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblImpuesto As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grbDebito As System.Windows.Forms.GroupBox
    Friend WithEvents cboOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDebito As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblSerieDebito As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDebito As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblImpuestoDebito As System.Windows.Forms.Label
    Friend WithEvents lblTotalDebito As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTipoAfectacion As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
