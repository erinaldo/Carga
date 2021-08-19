<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonitoreos
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonitoreos))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabLiquidacion = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DgvUsuario = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DgvAgencia = New System.Windows.Forms.DataGridView()
        Me.BtnPrvVtaCounter = New System.Windows.Forms.Button()
        Me.BtnPrv = New System.Windows.Forms.Button()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.DtpFin = New System.Windows.Forms.DateTimePicker()
        Me.DtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.CboAgencia = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnBuscar2 = New System.Windows.Forms.Button()
        Me.DgvLiquidacionesAgencias = New System.Windows.Forms.DataGridView()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LblMontoGasto = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DgvGastosXCounter = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabLiquidacion.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvLiquidacionesAgencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvGastosXCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabLiquidacion
        '
        Me.TabLiquidacion.Controls.Add(Me.TabPage1)
        Me.TabLiquidacion.Controls.Add(Me.TabPage2)
        Me.TabLiquidacion.Controls.Add(Me.TabPage3)
        Me.TabLiquidacion.Location = New System.Drawing.Point(7, 6)
        Me.TabLiquidacion.Name = "TabLiquidacion"
        Me.TabLiquidacion.SelectedIndex = 0
        Me.TabLiquidacion.Size = New System.Drawing.Size(790, 534)
        Me.TabLiquidacion.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.BtnPrvVtaCounter)
        Me.TabPage1.Controls.Add(Me.BtnPrv)
        Me.TabPage1.Controls.Add(Me.BtnImp)
        Me.TabPage1.Controls.Add(Me.BtnBuscar)
        Me.TabPage1.Controls.Add(Me.DtpFin)
        Me.TabPage1.Controls.Add(Me.DtpInicio)
        Me.TabPage1.Controls.Add(Me.CboAgencia)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(782, 508)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Liquidación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvUsuario)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 291)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(699, 211)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle Oficina"
        '
        'DgvUsuario
        '
        Me.DgvUsuario.BackgroundColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvUsuario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvUsuario.DefaultCellStyle = DataGridViewCellStyle16
        Me.DgvUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvUsuario.Location = New System.Drawing.Point(3, 16)
        Me.DgvUsuario.Name = "DgvUsuario"
        Me.DgvUsuario.Size = New System.Drawing.Size(693, 192)
        Me.DgvUsuario.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DgvAgencia)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(753, 217)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listado Oficinas Liquidadas"
        '
        'DgvAgencia
        '
        Me.DgvAgencia.BackgroundColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvAgencia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DgvAgencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvAgencia.DefaultCellStyle = DataGridViewCellStyle18
        Me.DgvAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAgencia.Location = New System.Drawing.Point(3, 16)
        Me.DgvAgencia.Name = "DgvAgencia"
        Me.DgvAgencia.Size = New System.Drawing.Size(747, 198)
        Me.DgvAgencia.TabIndex = 4
        '
        'BtnPrvVtaCounter
        '
        Me.BtnPrvVtaCounter.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.BtnPrvVtaCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrvVtaCounter.Location = New System.Drawing.Point(718, 306)
        Me.BtnPrvVtaCounter.Name = "BtnPrvVtaCounter"
        Me.BtnPrvVtaCounter.Size = New System.Drawing.Size(54, 28)
        Me.BtnPrvVtaCounter.TabIndex = 33
        Me.BtnPrvVtaCounter.Text = "  Prv"
        Me.BtnPrvVtaCounter.UseVisualStyleBackColor = True
        '
        'BtnPrv
        '
        Me.BtnPrv.Enabled = False
        Me.BtnPrv.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.BtnPrv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrv.Location = New System.Drawing.Point(714, 34)
        Me.BtnPrv.Name = "BtnPrv"
        Me.BtnPrv.Size = New System.Drawing.Size(54, 28)
        Me.BtnPrv.TabIndex = 7
        Me.BtnPrv.Text = "   Prv"
        Me.BtnPrv.UseVisualStyleBackColor = True
        '
        'BtnImp
        '
        Me.BtnImp.Enabled = False
        Me.BtnImp.Image = CType(resources.GetObject("BtnImp.Image"), System.Drawing.Image)
        Me.BtnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImp.Location = New System.Drawing.Point(656, 34)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(54, 28)
        Me.BtnImp.TabIndex = 6
        Me.BtnImp.Text = "    Imp"
        Me.BtnImp.UseVisualStyleBackColor = True
        Me.BtnImp.Visible = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.BtnBuscar.Location = New System.Drawing.Point(386, 30)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(64, 31)
        Me.BtnBuscar.TabIndex = 3
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'DtpFin
        '
        Me.DtpFin.CustomFormat = ""
        Me.DtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFin.Location = New System.Drawing.Point(274, 41)
        Me.DtpFin.Name = "DtpFin"
        Me.DtpFin.Size = New System.Drawing.Size(103, 20)
        Me.DtpFin.TabIndex = 2
        '
        'DtpInicio
        '
        Me.DtpInicio.CustomFormat = ""
        Me.DtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpInicio.Location = New System.Drawing.Point(88, 41)
        Me.DtpInicio.Name = "DtpInicio"
        Me.DtpInicio.Size = New System.Drawing.Size(103, 20)
        Me.DtpInicio.TabIndex = 2
        '
        'CboAgencia
        '
        Me.CboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAgencia.FormattingEnabled = True
        Me.CboAgencia.Location = New System.Drawing.Point(87, 13)
        Me.CboAgencia.Name = "CboAgencia"
        Me.CboAgencia.Size = New System.Drawing.Size(289, 21)
        Me.CboAgencia.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha Fin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Inicio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agencia"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.BtnBuscar2)
        Me.TabPage2.Controls.Add(Me.DgvLiquidacionesAgencias)
        Me.TabPage2.Controls.Add(Me.DtpFecha)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(782, 508)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "A Depositar"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(717, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(54, 28)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "    Prv"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(652, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(54, 28)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "      Imp"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'BtnBuscar2
        '
        Me.BtnBuscar2.Image = CType(resources.GetObject("BtnBuscar2.Image"), System.Drawing.Image)
        Me.BtnBuscar2.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.BtnBuscar2.Location = New System.Drawing.Point(172, 7)
        Me.BtnBuscar2.Name = "BtnBuscar2"
        Me.BtnBuscar2.Size = New System.Drawing.Size(64, 31)
        Me.BtnBuscar2.TabIndex = 3
        Me.BtnBuscar2.Text = "Buscar"
        Me.BtnBuscar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar2.UseVisualStyleBackColor = True
        '
        'DgvLiquidacionesAgencias
        '
        Me.DgvLiquidacionesAgencias.BackgroundColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvLiquidacionesAgencias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DgvLiquidacionesAgencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvLiquidacionesAgencias.DefaultCellStyle = DataGridViewCellStyle14
        Me.DgvLiquidacionesAgencias.Location = New System.Drawing.Point(12, 43)
        Me.DgvLiquidacionesAgencias.Name = "DgvLiquidacionesAgencias"
        Me.DgvLiquidacionesAgencias.Size = New System.Drawing.Size(759, 460)
        Me.DgvLiquidacionesAgencias.TabIndex = 2
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(67, 13)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(96, 20)
        Me.DtpFecha.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.LblNombre)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(782, 508)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Gastos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(14, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Gastos :"
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblNombre.Location = New System.Drawing.Point(68, 12)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(9, 12)
        Me.LblNombre.TabIndex = 8
        Me.LblNombre.Text = "."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LblMontoGasto)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.DgvGastosXCounter)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 30)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(755, 464)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'LblMontoGasto
        '
        Me.LblMontoGasto.AutoSize = True
        Me.LblMontoGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoGasto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblMontoGasto.Location = New System.Drawing.Point(76, 386)
        Me.LblMontoGasto.Name = "LblMontoGasto"
        Me.LblMontoGasto.Size = New System.Drawing.Size(27, 12)
        Me.LblMontoGasto.TabIndex = 2
        Me.LblMontoGasto.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(6, 385)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Monto Total :"
        '
        'DgvGastosXCounter
        '
        Me.DgvGastosXCounter.BackgroundColor = System.Drawing.Color.MidnightBlue
        Me.DgvGastosXCounter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvGastosXCounter.Location = New System.Drawing.Point(6, 19)
        Me.DgvGastosXCounter.Name = "DgvGastosXCounter"
        Me.DgvGastosXCounter.Size = New System.Drawing.Size(743, 360)
        Me.DgvGastosXCounter.TabIndex = 0
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Administrador"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Agencia"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'FrmMonitoreos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 544)
        Me.Controls.Add(Me.TabLiquidacion)
        Me.Name = "FrmMonitoreos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidaciones"
        Me.TabLiquidacion.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DgvAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DgvLiquidacionesAgencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DgvGastosXCounter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabLiquidacion As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvAgencia As System.Windows.Forms.DataGridView
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents DtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgvUsuario As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnBuscar2 As System.Windows.Forms.Button
    Friend WithEvents DgvLiquidacionesAgencias As System.Windows.Forms.DataGridView
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnPrv As System.Windows.Forms.Button
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LblMontoGasto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DgvGastosXCounter As System.Windows.Forms.DataGridView
    Friend WithEvents BtnPrvVtaCounter As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
