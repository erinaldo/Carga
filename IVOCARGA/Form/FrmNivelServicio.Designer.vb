<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNivelServicio
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
        Me.cboEstadoOrigen = New System.Windows.Forms.ComboBox()
        Me.cboEstadoDestino = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        Me.grbResultado = New System.Windows.Forms.GroupBox()
        Me.lblPromedio = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEnvios = New System.Windows.Forms.Label()
        Me.lblTiempo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboFuncionario = New System.Windows.Forms.ComboBox()
        Me.btnVerInconsistencia = New System.Windows.Forms.Button()
        Me.cboAgenciaOrigen = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboAgenciaDestino = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboTipoEntrega = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkTodo = New System.Windows.Forms.CheckBox()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.grbResultado.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboEstadoOrigen
        '
        Me.cboEstadoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoOrigen.FormattingEnabled = True
        Me.cboEstadoOrigen.Location = New System.Drawing.Point(95, 9)
        Me.cboEstadoOrigen.Name = "cboEstadoOrigen"
        Me.cboEstadoOrigen.Size = New System.Drawing.Size(170, 21)
        Me.cboEstadoOrigen.TabIndex = 0
        '
        'cboEstadoDestino
        '
        Me.cboEstadoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoDestino.FormattingEnabled = True
        Me.cboEstadoDestino.Location = New System.Drawing.Point(353, 9)
        Me.cboEstadoDestino.Name = "cboEstadoDestino"
        Me.cboEstadoDestino.Size = New System.Drawing.Size(170, 21)
        Me.cboEstadoDestino.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Carga Inicio"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(283, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(52, 13)
        Me.label7.TabIndex = 1
        Me.label7.Text = "Carga Fin"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(353, 101)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaInicio.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Fecha Inicio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Producto"
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(95, 101)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(169, 21)
        Me.cboProducto.TabIndex = 6
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Location = New System.Drawing.Point(95, 38)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(170, 21)
        Me.cboOrigen.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Origen"
        '
        'cboDestino
        '
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(353, 38)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(170, 21)
        Me.cboDestino.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(283, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Destino"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(283, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Cliente"
        '
        'dgvResultado
        '
        Me.dgvResultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Location = New System.Drawing.Point(12, 167)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(720, 272)
        Me.dgvResultado.TabIndex = 12
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Location = New System.Drawing.Point(452, 134)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(278, 20)
        Me.txtCliente.TabIndex = 11
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCliente.Location = New System.Drawing.Point(353, 134)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(99, 20)
        Me.txtCodigoCliente.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnFiltrar)
        Me.Panel2.Location = New System.Drawing.Point(651, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(82, 32)
        Me.Panel2.TabIndex = 194
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltrar.Location = New System.Drawing.Point(3, 0)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(77, 29)
        Me.BtnFiltrar.TabIndex = 13
        Me.BtnFiltrar.Text = "Filtrar"
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'grbResultado
        '
        Me.grbResultado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbResultado.Controls.Add(Me.lblPromedio)
        Me.grbResultado.Controls.Add(Me.Label10)
        Me.grbResultado.Controls.Add(Me.Label9)
        Me.grbResultado.Controls.Add(Me.lblEnvios)
        Me.grbResultado.Controls.Add(Me.lblTiempo)
        Me.grbResultado.Controls.Add(Me.Label2)
        Me.grbResultado.Location = New System.Drawing.Point(12, 443)
        Me.grbResultado.Name = "grbResultado"
        Me.grbResultado.Size = New System.Drawing.Size(720, 40)
        Me.grbResultado.TabIndex = 195
        Me.grbResultado.TabStop = False
        '
        'lblPromedio
        '
        Me.lblPromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromedio.Location = New System.Drawing.Point(461, 16)
        Me.lblPromedio.Name = "lblPromedio"
        Me.lblPromedio.Size = New System.Drawing.Size(67, 13)
        Me.lblPromedio.TabIndex = 0
        Me.lblPromedio.Text = "0.00"
        Me.lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(407, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Promedio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(194, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Envíos"
        '
        'lblEnvios
        '
        Me.lblEnvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnvios.Location = New System.Drawing.Point(243, 16)
        Me.lblEnvios.Name = "lblEnvios"
        Me.lblEnvios.Size = New System.Drawing.Size(67, 13)
        Me.lblEnvios.TabIndex = 0
        Me.lblEnvios.Text = "0.00"
        Me.lblEnvios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTiempo
        '
        Me.lblTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiempo.Location = New System.Drawing.Point(49, 16)
        Me.lblTiempo.Name = "lblTiempo"
        Me.lblTiempo.Size = New System.Drawing.Size(67, 13)
        Me.lblTiempo.TabIndex = 0
        Me.lblTiempo.Text = "0.00"
        Me.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTiempo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tiempo"
        Me.Label2.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(465, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Fecha Fin"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(525, 101)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaFin.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 139)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Funcionario"
        '
        'cboFuncionario
        '
        Me.cboFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFuncionario.FormattingEnabled = True
        Me.cboFuncionario.Location = New System.Drawing.Point(95, 134)
        Me.cboFuncionario.Name = "cboFuncionario"
        Me.cboFuncionario.Size = New System.Drawing.Size(170, 21)
        Me.cboFuncionario.TabIndex = 9
        '
        'btnVerInconsistencia
        '
        Me.btnVerInconsistencia.Location = New System.Drawing.Point(641, 96)
        Me.btnVerInconsistencia.Name = "btnVerInconsistencia"
        Me.btnVerInconsistencia.Size = New System.Drawing.Size(89, 31)
        Me.btnVerInconsistencia.TabIndex = 14
        Me.btnVerInconsistencia.Text = "Inconsistencias"
        Me.btnVerInconsistencia.UseVisualStyleBackColor = True
        '
        'cboAgenciaOrigen
        '
        Me.cboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgenciaOrigen.FormattingEnabled = True
        Me.cboAgenciaOrigen.Location = New System.Drawing.Point(95, 69)
        Me.cboAgenciaOrigen.Name = "cboAgenciaOrigen"
        Me.cboAgenciaOrigen.Size = New System.Drawing.Size(170, 21)
        Me.cboAgenciaOrigen.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Ag. Origen"
        '
        'cboAgenciaDestino
        '
        Me.cboAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgenciaDestino.FormattingEnabled = True
        Me.cboAgenciaDestino.Location = New System.Drawing.Point(353, 69)
        Me.cboAgenciaDestino.Name = "cboAgenciaDestino"
        Me.cboAgenciaDestino.Size = New System.Drawing.Size(170, 21)
        Me.cboAgenciaDestino.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(281, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Ag. Destino"
        '
        'cboTipoEntrega
        '
        Me.cboTipoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEntrega.FormattingEnabled = True
        Me.cboTipoEntrega.Items.AddRange(New Object() {"(TODO)", "AGENCIA", "DOMICILIO"})
        Me.cboTipoEntrega.Location = New System.Drawing.Point(618, 69)
        Me.cboTipoEntrega.Name = "cboTipoEntrega"
        Me.cboTipoEntrega.Size = New System.Drawing.Size(112, 21)
        Me.cboTipoEntrega.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(544, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Tipo Entrega"
        '
        'chkTodo
        '
        Me.chkTodo.AutoSize = True
        Me.chkTodo.Location = New System.Drawing.Point(547, 11)
        Me.chkTodo.Name = "chkTodo"
        Me.chkTodo.Size = New System.Drawing.Size(82, 17)
        Me.chkTodo.TabIndex = 196
        Me.chkTodo.Text = "Incluir Todo"
        Me.chkTodo.UseVisualStyleBackColor = True
        '
        'FrmNivelServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 487)
        Me.Controls.Add(Me.chkTodo)
        Me.Controls.Add(Me.btnVerInconsistencia)
        Me.Controls.Add(Me.cboFuncionario)
        Me.Controls.Add(Me.grbResultado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtCodigoCliente)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.dgvResultado)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEstadoDestino)
        Me.Controls.Add(Me.cboDestino)
        Me.Controls.Add(Me.cboTipoEntrega)
        Me.Controls.Add(Me.cboAgenciaDestino)
        Me.Controls.Add(Me.cboAgenciaOrigen)
        Me.Controls.Add(Me.cboOrigen)
        Me.Controls.Add(Me.cboProducto)
        Me.Controls.Add(Me.cboEstadoOrigen)
        Me.Name = "FrmNivelServicio"
        Me.Text = "Nivel de Servicio"
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.grbResultado.ResumeLayout(False)
        Me.grbResultado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboEstadoOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstadoDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents grbResultado As System.Windows.Forms.GroupBox
    Friend WithEvents lblPromedio As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblEnvios As System.Windows.Forms.Label
    Friend WithEvents lblTiempo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents btnVerInconsistencia As System.Windows.Forms.Button
    Friend WithEvents cboAgenciaOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboAgenciaDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboTipoEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkTodo As System.Windows.Forms.CheckBox
End Class
