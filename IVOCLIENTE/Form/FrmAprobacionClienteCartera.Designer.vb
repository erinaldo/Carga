<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAprobacionClienteCartera
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
        Me.tab = New System.Windows.Forms.TabControl()
        Me.TabLista = New System.Windows.Forms.TabPage()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.TabAprobacion = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblFuncionarioNuevo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaActivacion = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblSustento = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFuncionarioActual = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.RbtNo = New System.Windows.Forms.RadioButton()
        Me.RbtSi = New System.Windows.Forms.RadioButton()
        Me.LblAprobar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabTransferencia = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnEliminarSeleccion = New System.Windows.Forms.Button()
        Me.btnSeleccionarTodo = New System.Windows.Forms.Button()
        Me.lblNumero2 = New System.Windows.Forms.Label()
        Me.LblNumero1 = New System.Windows.Forms.Label()
        Me.btnRetirar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.cmbFuncionario2 = New System.Windows.Forms.ComboBox()
        Me.cmbFuncionario1 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tab.SuspendLayout()
        Me.TabLista.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAprobacion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabTransferencia.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab.Controls.Add(Me.TabLista)
        Me.tab.Controls.Add(Me.TabAprobacion)
        Me.tab.Controls.Add(Me.TabTransferencia)
        Me.tab.Location = New System.Drawing.Point(12, 5)
        Me.tab.Name = "tab"
        Me.tab.SelectedIndex = 0
        Me.tab.Size = New System.Drawing.Size(1017, 516)
        Me.tab.TabIndex = 0
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.dgv)
        Me.TabLista.Location = New System.Drawing.Point(4, 22)
        Me.TabLista.Name = "TabLista"
        Me.TabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLista.Size = New System.Drawing.Size(1009, 490)
        Me.TabLista.TabIndex = 0
        Me.TabLista.Text = "Lista"
        Me.TabLista.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(6, 20)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(987, 462)
        Me.dgv.TabIndex = 0
        '
        'TabAprobacion
        '
        Me.TabAprobacion.Controls.Add(Me.GroupBox2)
        Me.TabAprobacion.Controls.Add(Me.lblRazonSocial)
        Me.TabAprobacion.Controls.Add(Me.GroupBox1)
        Me.TabAprobacion.Controls.Add(Me.lblCodigo)
        Me.TabAprobacion.Controls.Add(Me.Panel1)
        Me.TabAprobacion.Controls.Add(Me.Label1)
        Me.TabAprobacion.Location = New System.Drawing.Point(4, 22)
        Me.TabAprobacion.Name = "TabAprobacion"
        Me.TabAprobacion.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAprobacion.Size = New System.Drawing.Size(1009, 490)
        Me.TabAprobacion.TabIndex = 1
        Me.TabAprobacion.Text = "Aprobación"
        Me.TabAprobacion.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblFuncionarioNuevo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtpFechaActivacion)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblSustento)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(722, 120)
        Me.GroupBox2.TabIndex = 198
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Nueva Cuenta"
        '
        'lblFuncionarioNuevo
        '
        Me.lblFuncionarioNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionarioNuevo.Location = New System.Drawing.Point(77, 22)
        Me.lblFuncionarioNuevo.Name = "lblFuncionarioNuevo"
        Me.lblFuncionarioNuevo.Size = New System.Drawing.Size(611, 13)
        Me.lblFuncionarioNuevo.TabIndex = 4
        Me.lblFuncionarioNuevo.Text = "Label2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Responsable"
        '
        'dtpFechaActivacion
        '
        Me.dtpFechaActivacion.Checked = False
        Me.dtpFechaActivacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion.Location = New System.Drawing.Point(352, 90)
        Me.dtpFechaActivacion.Name = "dtpFechaActivacion"
        Me.dtpFechaActivacion.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaActivacion.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(241, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Fecha Inicio"
        '
        'lblSustento
        '
        Me.lblSustento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSustento.Location = New System.Drawing.Point(77, 45)
        Me.lblSustento.Name = "lblSustento"
        Me.lblSustento.Size = New System.Drawing.Size(639, 35)
        Me.lblSustento.TabIndex = 0
        Me.lblSustento.Text = "Sustento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Sustento"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.Red
        Me.lblRazonSocial.Location = New System.Drawing.Point(189, 16)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(547, 13)
        Me.lblRazonSocial.TabIndex = 5
        Me.lblRazonSocial.Text = "Label2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFuncionarioActual)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.lblFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(722, 70)
        Me.GroupBox1.TabIndex = 197
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuenta Actual"
        '
        'lblFuncionarioActual
        '
        Me.lblFuncionarioActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionarioActual.Location = New System.Drawing.Point(77, 22)
        Me.lblFuncionarioActual.Name = "lblFuncionarioActual"
        Me.lblFuncionarioActual.Size = New System.Drawing.Size(639, 13)
        Me.lblFuncionarioActual.TabIndex = 4
        Me.lblFuncionarioActual.Text = "Label2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(241, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Hasta"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Checked = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(352, 38)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaFin.TabIndex = 37
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.Location = New System.Drawing.Point(77, 44)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(75, 13)
        Me.lblFechaInicio.TabIndex = 2
        Me.lblFechaInicio.Text = "01/01/2014"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Responsable"
        '
        'lblCodigo
        '
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Red
        Me.lblCodigo.Location = New System.Drawing.Point(95, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(90, 13)
        Me.lblCodigo.TabIndex = 6
        Me.lblCodigo.Text = "12345678901"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtObservacion)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.RbtNo)
        Me.Panel1.Controls.Add(Me.RbtSi)
        Me.Panel1.Controls.Add(Me.LblAprobar)
        Me.Panel1.Location = New System.Drawing.Point(203, 285)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 91)
        Me.Panel1.TabIndex = 196
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Enabled = False
        Me.TxtObservacion.Location = New System.Drawing.Point(110, 35)
        Me.TxtObservacion.MaxLength = 100
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(272, 20)
        Me.TxtObservacion.TabIndex = 15
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(112, 61)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.BtnAceptar.TabIndex = 16
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'RbtNo
        '
        Me.RbtNo.AutoSize = True
        Me.RbtNo.Location = New System.Drawing.Point(65, 35)
        Me.RbtNo.Name = "RbtNo"
        Me.RbtNo.Size = New System.Drawing.Size(39, 17)
        Me.RbtNo.TabIndex = 14
        Me.RbtNo.Text = "No"
        Me.RbtNo.UseVisualStyleBackColor = True
        '
        'RbtSi
        '
        Me.RbtSi.AutoSize = True
        Me.RbtSi.Checked = True
        Me.RbtSi.Location = New System.Drawing.Point(16, 35)
        Me.RbtSi.Name = "RbtSi"
        Me.RbtSi.Size = New System.Drawing.Size(34, 17)
        Me.RbtSi.TabIndex = 13
        Me.RbtSi.TabStop = True
        Me.RbtSi.Text = "Si"
        Me.RbtSi.UseVisualStyleBackColor = True
        '
        'LblAprobar
        '
        Me.LblAprobar.AutoSize = True
        Me.LblAprobar.Location = New System.Drawing.Point(13, 9)
        Me.LblAprobar.Name = "LblAprobar"
        Me.LblAprobar.Size = New System.Drawing.Size(44, 13)
        Me.LblAprobar.TabIndex = 12
        Me.LblAprobar.Text = "Aprobar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cliente"
        '
        'TabTransferencia
        '
        Me.TabTransferencia.Controls.Add(Me.Panel3)
        Me.TabTransferencia.Controls.Add(Me.Panel2)
        Me.TabTransferencia.Controls.Add(Me.lblNumero2)
        Me.TabTransferencia.Controls.Add(Me.LblNumero1)
        Me.TabTransferencia.Controls.Add(Me.btnRetirar)
        Me.TabTransferencia.Controls.Add(Me.btnAgregar)
        Me.TabTransferencia.Controls.Add(Me.dgv2)
        Me.TabTransferencia.Controls.Add(Me.dgv1)
        Me.TabTransferencia.Controls.Add(Me.cmbFuncionario2)
        Me.TabTransferencia.Controls.Add(Me.cmbFuncionario1)
        Me.TabTransferencia.Controls.Add(Me.Label10)
        Me.TabTransferencia.Controls.Add(Me.Label7)
        Me.TabTransferencia.Controls.Add(Me.Label9)
        Me.TabTransferencia.Controls.Add(Me.Label5)
        Me.TabTransferencia.Location = New System.Drawing.Point(4, 22)
        Me.TabTransferencia.Name = "TabTransferencia"
        Me.TabTransferencia.Size = New System.Drawing.Size(1009, 490)
        Me.TabTransferencia.TabIndex = 2
        Me.TabTransferencia.Text = "Transferencia"
        Me.TabTransferencia.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.btnCancelar)
        Me.Panel3.Location = New System.Drawing.Point(918, 457)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(82, 30)
        Me.Panel3.TabIndex = 49
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(3, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 26)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnEliminarSeleccion)
        Me.Panel2.Controls.Add(Me.btnSeleccionarTodo)
        Me.Panel2.Location = New System.Drawing.Point(9, 457)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(287, 30)
        Me.Panel2.TabIndex = 48
        '
        'btnEliminarSeleccion
        '
        Me.btnEliminarSeleccion.Location = New System.Drawing.Point(84, 3)
        Me.btnEliminarSeleccion.Name = "btnEliminarSeleccion"
        Me.btnEliminarSeleccion.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminarSeleccion.TabIndex = 0
        Me.btnEliminarSeleccion.Text = "Eliminar Sel."
        Me.btnEliminarSeleccion.UseVisualStyleBackColor = True
        '
        'btnSeleccionarTodo
        '
        Me.btnSeleccionarTodo.Location = New System.Drawing.Point(3, 4)
        Me.btnSeleccionarTodo.Name = "btnSeleccionarTodo"
        Me.btnSeleccionarTodo.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionarTodo.TabIndex = 0
        Me.btnSeleccionarTodo.Text = "Sel. Todo"
        Me.btnSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'lblNumero2
        '
        Me.lblNumero2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero2.ForeColor = System.Drawing.Color.Red
        Me.lblNumero2.Location = New System.Drawing.Point(930, 68)
        Me.lblNumero2.Name = "lblNumero2"
        Me.lblNumero2.Size = New System.Drawing.Size(65, 13)
        Me.lblNumero2.TabIndex = 47
        Me.lblNumero2.Text = "0"
        Me.lblNumero2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNumero1
        '
        Me.LblNumero1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero1.ForeColor = System.Drawing.Color.Red
        Me.LblNumero1.Location = New System.Drawing.Point(360, 68)
        Me.LblNumero1.Name = "LblNumero1"
        Me.LblNumero1.Size = New System.Drawing.Size(95, 13)
        Me.LblNumero1.TabIndex = 47
        Me.LblNumero1.Text = "0/0"
        Me.LblNumero1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRetirar
        '
        Me.btnRetirar.Enabled = False
        Me.btnRetirar.Location = New System.Drawing.Point(466, 237)
        Me.btnRetirar.Name = "btnRetirar"
        Me.btnRetirar.Size = New System.Drawing.Size(75, 26)
        Me.btnRetirar.TabIndex = 3
        Me.btnRetirar.Text = "Retirar"
        Me.btnRetirar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Location = New System.Drawing.Point(464, 84)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 26)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Transferir a"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Location = New System.Drawing.Point(552, 84)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.Size = New System.Drawing.Size(443, 371)
        Me.dgv2.TabIndex = 2
        '
        'dgv1
        '
        Me.dgv1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(12, 84)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(443, 371)
        Me.dgv1.TabIndex = 2
        '
        'cmbFuncionario2
        '
        Me.cmbFuncionario2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFuncionario2.FormattingEnabled = True
        Me.cmbFuncionario2.Location = New System.Drawing.Point(552, 38)
        Me.cmbFuncionario2.Name = "cmbFuncionario2"
        Me.cmbFuncionario2.Size = New System.Drawing.Size(443, 21)
        Me.cmbFuncionario2.TabIndex = 1
        '
        'cmbFuncionario1
        '
        Me.cmbFuncionario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFuncionario1.FormattingEnabled = True
        Me.cmbFuncionario1.Location = New System.Drawing.Point(12, 38)
        Me.cmbFuncionario1.Name = "cmbFuncionario1"
        Me.cmbFuncionario1.Size = New System.Drawing.Size(443, 21)
        Me.cmbFuncionario1.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(549, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Cartera de Clientes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cartera de Clientes"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(549, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Responsable"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Responsable"
        '
        'FrmAprobacionClienteCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 528)
        Me.Controls.Add(Me.tab)
        Me.Name = "FrmAprobacionClienteCartera"
        Me.Text = "Aprobación Cliente a Cuenta de Responsable"
        Me.tab.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAprobacion.ResumeLayout(False)
        Me.TabAprobacion.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabTransferencia.ResumeLayout(False)
        Me.TabTransferencia.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents TabLista As System.Windows.Forms.TabPage
    Friend WithEvents TabAprobacion As System.Windows.Forms.TabPage
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents RbtNo As System.Windows.Forms.RadioButton
    Friend WithEvents RbtSi As System.Windows.Forms.RadioButton
    Friend WithEvents LblAprobar As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFuncionarioActual As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSustento As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFuncionarioNuevo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaActivacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabTransferencia As System.Windows.Forms.TabPage
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmbFuncionario1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFuncionario2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnRetirar As System.Windows.Forms.Button
    Friend WithEvents lblNumero2 As System.Windows.Forms.Label
    Friend WithEvents LblNumero1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnEliminarSeleccion As System.Windows.Forms.Button
    Friend WithEvents btnSeleccionarTodo As System.Windows.Forms.Button
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
