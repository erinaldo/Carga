<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecojoEntrega
    Inherits INTEGRACION.frmBaseVentas

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecojoEntrega))
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtNroSolicitud = New System.Windows.Forms.TextBox()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbAtendido = New System.Windows.Forms.ComboBox()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.dtGridViewControl_FACBOL = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbNroRegistro1 = New System.Windows.Forms.Label()
        Me.lbNroRegistros = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lbNroRegistro = New System.Windows.Forms.Label()
        Me.btnMovil = New System.Windows.Forms.Button()
        Me.btnEntregar = New System.Windows.Forms.Button()
        Me.btnImpresion = New System.Windows.Forms.Button()
        Me.btnSolicitud = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbRutas = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dtFecha_Operacion = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBuscarRasonSocial = New System.Windows.Forms.TextBox()
        Me.MnuControlUsuario = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAsignarControl = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesmarcarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmdProcedencia = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dtGridViewControl_FACBOL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MnuControlUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(830, 535)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(825, 559)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.cmdProcedencia)
        Me.TabLista.Controls.Add(Me.dtGridViewControl_FACBOL)
        Me.TabLista.Controls.Add(Me.txtBuscarRasonSocial)
        Me.TabLista.Controls.Add(Me.GroupBox4)
        Me.TabLista.Controls.Add(Me.GroupBox7)
        Me.TabLista.Controls.Add(Me.Label16)
        Me.TabLista.Controls.Add(Me.Label15)
        Me.TabLista.Size = New System.Drawing.Size(817, 530)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Controls.Add(Me.DataGridView1)
        Me.TabDatos.Size = New System.Drawing.Size(817, 530)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(817, 530)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(817, 530)
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox7.Controls.Add(Me.TextBox3)
        Me.GroupBox7.Controls.Add(Me.txtNroSolicitud)
        Me.GroupBox7.Controls.Add(Me.dtFechaFin)
        Me.GroupBox7.Controls.Add(Me.dtFechaInicio)
        Me.GroupBox7.Controls.Add(Me.btnBuscar)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.Label29)
        Me.GroupBox7.Controls.Add(Me.Label30)
        Me.GroupBox7.Controls.Add(Me.cmbEstados)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Controls.Add(Me.cmbAtendido)
        Me.GroupBox7.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox7.Controls.Add(Me.cmbAgencia)
        Me.GroupBox7.Controls.Add(Me.cmbTipoOperacion)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox7.Location = New System.Drawing.Point(-1, 2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(814, 87)
        Me.GroupBox7.TabIndex = 7
        Me.GroupBox7.TabStop = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(108, 59)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(119, 20)
        Me.TextBox3.TabIndex = 43
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNroSolicitud
        '
        Me.txtNroSolicitud.Location = New System.Drawing.Point(352, 56)
        Me.txtNroSolicitud.Name = "txtNroSolicitud"
        Me.txtNroSolicitud.Size = New System.Drawing.Size(106, 20)
        Me.txtNroSolicitud.TabIndex = 43
        Me.txtNroSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(352, 33)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(106, 20)
        Me.dtFechaFin.TabIndex = 41
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(352, 9)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(106, 20)
        Me.dtFechaInicio.TabIndex = 41
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(466, 51)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 22)
        Me.btnBuscar.TabIndex = 40
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(7, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "NroMovil"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(264, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Nro Solicitud"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(264, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Fecha Fin"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(7, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Atendido"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(523, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Estado"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Enabled = False
        Me.Label23.Location = New System.Drawing.Point(519, 37)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 13)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "Usuario"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Enabled = False
        Me.Label29.Location = New System.Drawing.Point(519, 10)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 31
        Me.Label29.Text = "Agencia"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(7, 15)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(88, 13)
        Me.Label30.TabIndex = 31
        Me.Label30.Text = "T.Opereracion"
        '
        'cmbEstados
        '
        Me.cmbEstados.BackColor = System.Drawing.SystemColors.Info
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(576, 56)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(229, 21)
        Me.cmbEstados.TabIndex = 35
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(267, 12)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(77, 13)
        Me.Label31.TabIndex = 34
        Me.Label31.Text = "Fecha Inicio"
        '
        'cmbAtendido
        '
        Me.cmbAtendido.BackColor = System.Drawing.SystemColors.Info
        Me.cmbAtendido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAtendido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAtendido.FormattingEnabled = True
        Me.cmbAtendido.Location = New System.Drawing.Point(108, 33)
        Me.cmbAtendido.Name = "cmbAtendido"
        Me.cmbAtendido.Size = New System.Drawing.Size(121, 21)
        Me.cmbAtendido.TabIndex = 30
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.BackColor = System.Drawing.SystemColors.Info
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.Enabled = False
        Me.cmbUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(576, 32)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(229, 21)
        Me.cmbUsuarios.TabIndex = 29
        '
        'cmbAgencia
        '
        Me.cmbAgencia.BackColor = System.Drawing.SystemColors.Info
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.Enabled = False
        Me.cmbAgencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(576, 7)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(229, 21)
        Me.cmbAgencia.TabIndex = 29
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(108, 10)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoOperacion.TabIndex = 29
        '
        'dtGridViewControl_FACBOL
        '
        Me.dtGridViewControl_FACBOL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtGridViewControl_FACBOL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViewControl_FACBOL.Location = New System.Drawing.Point(-1, 119)
        Me.dtGridViewControl_FACBOL.MultiSelect = False
        Me.dtGridViewControl_FACBOL.Name = "dtGridViewControl_FACBOL"
        Me.dtGridViewControl_FACBOL.ReadOnly = True
        Me.dtGridViewControl_FACBOL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtGridViewControl_FACBOL.Size = New System.Drawing.Size(723, 382)
        Me.dtGridViewControl_FACBOL.TabIndex = 9
        Me.dtGridViewControl_FACBOL.VirtualMode = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox4.Controls.Add(Me.lbNroRegistro1)
        Me.GroupBox4.Controls.Add(Me.lbNroRegistros)
        Me.GroupBox4.Controls.Add(Me.PictureBox1)
        Me.GroupBox4.Controls.Add(Me.PictureBox2)
        Me.GroupBox4.Controls.Add(Me.PictureBox11)
        Me.GroupBox4.Controls.Add(Me.PictureBox7)
        Me.GroupBox4.Controls.Add(Me.PictureBox10)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label41)
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.lbNroRegistro)
        Me.GroupBox4.Controls.Add(Me.btnMovil)
        Me.GroupBox4.Controls.Add(Me.btnEntregar)
        Me.GroupBox4.Controls.Add(Me.btnImpresion)
        Me.GroupBox4.Controls.Add(Me.btnSolicitud)
        Me.GroupBox4.Controls.Add(Me.btnCerrar)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(728, 82)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(85, 413)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        '
        'lbNroRegistro1
        '
        Me.lbNroRegistro1.AutoSize = True
        Me.lbNroRegistro1.BackColor = System.Drawing.Color.DodgerBlue
        Me.lbNroRegistro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistro1.Location = New System.Drawing.Point(13, 265)
        Me.lbNroRegistro1.Name = "lbNroRegistro1"
        Me.lbNroRegistro1.Size = New System.Drawing.Size(14, 13)
        Me.lbNroRegistro1.TabIndex = 5
        Me.lbNroRegistro1.Text = "0"
        '
        'lbNroRegistros
        '
        Me.lbNroRegistros.AutoSize = True
        Me.lbNroRegistros.BackColor = System.Drawing.Color.DodgerBlue
        Me.lbNroRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistros.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistros.Location = New System.Drawing.Point(13, 252)
        Me.lbNroRegistros.Name = "lbNroRegistros"
        Me.lbNroRegistros.Size = New System.Drawing.Size(58, 13)
        Me.lbNroRegistros.TabIndex = 4
        Me.lbNroRegistros.Text = "Nro Reg."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Blue
        Me.PictureBox1.Location = New System.Drawing.Point(8, 197)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 12)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Red
        Me.PictureBox2.Location = New System.Drawing.Point(6, 179)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 12)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'PictureBox11
        '
        Me.PictureBox11.BackColor = System.Drawing.Color.Cyan
        Me.PictureBox11.Location = New System.Drawing.Point(3, 161)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(19, 12)
        Me.PictureBox11.TabIndex = 3
        Me.PictureBox11.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Black
        Me.PictureBox7.Location = New System.Drawing.Point(3, 215)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(76, 2)
        Me.PictureBox7.TabIndex = 3
        Me.PictureBox7.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.Lime
        Me.PictureBox10.Location = New System.Drawing.Point(3, 143)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(19, 12)
        Me.PictureBox10.TabIndex = 3
        Me.PictureBox10.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ENTRE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CANCEL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "OP. NORMAL"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(28, 160)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(44, 13)
        Me.Label41.TabIndex = 2
        Me.Label41.Text = "REPAR"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(25, 142)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(42, 13)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "RECOJ"
        '
        'lbNroRegistro
        '
        Me.lbNroRegistro.AutoSize = True
        Me.lbNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistro.Location = New System.Drawing.Point(13, 278)
        Me.lbNroRegistro.Name = "lbNroRegistro"
        Me.lbNroRegistro.Size = New System.Drawing.Size(14, 13)
        Me.lbNroRegistro.TabIndex = 1
        Me.lbNroRegistro.Text = "0"
        '
        'btnMovil
        '
        Me.btnMovil.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnMovil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMovil.Location = New System.Drawing.Point(6, 46)
        Me.btnMovil.Name = "btnMovil"
        Me.btnMovil.Size = New System.Drawing.Size(72, 26)
        Me.btnMovil.TabIndex = 0
        Me.btnMovil.Text = "&Movil"
        Me.btnMovil.UseVisualStyleBackColor = False
        '
        'btnEntregar
        '
        Me.btnEntregar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntregar.Location = New System.Drawing.Point(6, 80)
        Me.btnEntregar.Name = "btnEntregar"
        Me.btnEntregar.Size = New System.Drawing.Size(72, 26)
        Me.btnEntregar.TabIndex = 0
        Me.btnEntregar.Text = "&Recepcion"
        Me.btnEntregar.UseVisualStyleBackColor = False
        '
        'btnImpresion
        '
        Me.btnImpresion.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresion.Location = New System.Drawing.Point(6, 223)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(72, 26)
        Me.btnImpresion.TabIndex = 0
        Me.btnImpresion.Text = "&Impresion"
        Me.btnImpresion.UseVisualStyleBackColor = False
        '
        'btnSolicitud
        '
        Me.btnSolicitud.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSolicitud.Location = New System.Drawing.Point(6, 14)
        Me.btnSolicitud.Name = "btnSolicitud"
        Me.btnSolicitud.Size = New System.Drawing.Size(72, 26)
        Me.btnSolicitud.TabIndex = 0
        Me.btnSolicitud.Text = "&Solicitud"
        Me.btnSolicitud.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Location = New System.Drawing.Point(9, 294)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(72, 26)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(2, 96)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(753, 311)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbRutas)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.dtFecha_Operacion)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(753, 84)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(3, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Responsable Movil"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.SystemColors.Info
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(109, 50)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(168, 21)
        Me.ComboBox2.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(287, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Ruta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Ruta"
        '
        'cmbRutas
        '
        Me.cmbRutas.BackColor = System.Drawing.SystemColors.Info
        Me.cmbRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRutas.FormattingEnabled = True
        Me.cmbRutas.Location = New System.Drawing.Point(109, 20)
        Me.cmbRutas.Name = "cmbRutas"
        Me.cmbRutas.Size = New System.Drawing.Size(168, 21)
        Me.cmbRutas.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(521, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Nro Solicitud"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(544, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "NroDoc"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(600, 19)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(147, 20)
        Me.TextBox2.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(600, 45)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 20)
        Me.TextBox1.TabIndex = 5
        '
        'dtFecha_Operacion
        '
        Me.dtFecha_Operacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha_Operacion.Location = New System.Drawing.Point(322, 22)
        Me.dtFecha_Operacion.Name = "dtFecha_Operacion"
        Me.dtFecha_Operacion.Size = New System.Drawing.Size(90, 20)
        Me.dtFecha_Operacion.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(2, 407)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(753, 67)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(15, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Responsable Movil"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(17, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Ruta"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkRed
        Me.Label15.Location = New System.Drawing.Point(6, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Razon Social"
        '
        'txtBuscarRasonSocial
        '
        Me.txtBuscarRasonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarRasonSocial.Location = New System.Drawing.Point(107, 92)
        Me.txtBuscarRasonSocial.Name = "txtBuscarRasonSocial"
        Me.txtBuscarRasonSocial.Size = New System.Drawing.Size(250, 20)
        Me.txtBuscarRasonSocial.TabIndex = 43
        Me.txtBuscarRasonSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MnuControlUsuario
        '
        Me.MnuControlUsuario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAsignarControl, Me.mnuEditar, Me.SeleccionarTodosToolStripMenuItem, Me.DesmarcarTodosToolStripMenuItem})
        Me.MnuControlUsuario.Name = "MnuControlUsuario"
        Me.MnuControlUsuario.Size = New System.Drawing.Size(172, 92)
        '
        'mnuAsignarControl
        '
        Me.mnuAsignarControl.Name = "mnuAsignarControl"
        Me.mnuAsignarControl.Size = New System.Drawing.Size(171, 22)
        Me.mnuAsignarControl.Text = "Asociar Movil"
        '
        'mnuEditar
        '
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(171, 22)
        Me.mnuEditar.Text = "Editar"
        '
        'SeleccionarTodosToolStripMenuItem
        '
        Me.SeleccionarTodosToolStripMenuItem.Name = "SeleccionarTodosToolStripMenuItem"
        Me.SeleccionarTodosToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SeleccionarTodosToolStripMenuItem.Text = "Seleccionar Todos"
        '
        'DesmarcarTodosToolStripMenuItem
        '
        Me.DesmarcarTodosToolStripMenuItem.Name = "DesmarcarTodosToolStripMenuItem"
        Me.DesmarcarTodosToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DesmarcarTodosToolStripMenuItem.Text = "Desmarcar Todos"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkRed
        Me.Label16.Location = New System.Drawing.Point(372, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Procedencia"
        '
        'cmdProcedencia
        '
        Me.cmdProcedencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProcedencia.FormattingEnabled = True
        Me.cmdProcedencia.Location = New System.Drawing.Point(463, 92)
        Me.cmdProcedencia.Name = "cmdProcedencia"
        Me.cmdProcedencia.Size = New System.Drawing.Size(259, 21)
        Me.cmdProcedencia.TabIndex = 44
        '
        'FrmRecojoEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(822, 534)
        Me.Name = "FrmRecojoEntrega"
        Me.Text = "RECOJO ENTREGAS DE CARGA"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.dtGridViewControl_FACBOL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MnuControlUsuario.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNroSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbAtendido As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents dtGridViewControl_FACBOL As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbNroRegistro1 As System.Windows.Forms.Label
    Friend WithEvents lbNroRegistros As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbNroRegistro As System.Windows.Forms.Label
    Friend WithEvents btnEntregar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnImpresion As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSolicitud As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dtFecha_Operacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbRutas As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarRasonSocial As System.Windows.Forms.TextBox
    Friend WithEvents MnuControlUsuario As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAsignarControl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMovil As System.Windows.Forms.Button
    Friend WithEvents SeleccionarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesmarcarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdProcedencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
