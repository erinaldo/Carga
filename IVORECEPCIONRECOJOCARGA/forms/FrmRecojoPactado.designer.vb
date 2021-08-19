<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmrecojopactado
    Inherits INTEGRACION.FrmPlantillasolrecojocarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmrecojopactado))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtidentregarecojo = New System.Windows.Forms.TextBox
        Me.btncontacto = New System.Windows.Forms.Button
        Me.btndireccion = New System.Windows.Forms.Button
        Me.btnBuscarcliente = New System.Windows.Forms.Button
        Me.txtcontacto = New System.Windows.Forms.TextBox
        Me.Txtdireccion = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPfecfinal = New System.Windows.Forms.DateTimePicker
        Me.DTPFecinicial = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbagencia = New System.Windows.Forms.ComboBox
        Me.txtidcliente = New System.Windows.Forms.TextBox
        Me.txtiddireccion = New System.Windows.Forms.TextBox
        Me.txtidcontacto = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.IDDIA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.hora_inicio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hora_fin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.diainactivo = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IDCONTACTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dirección = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DGVdiarecojo = New System.Windows.Forms.DataGridView
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btneliminar = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGVdiarecojo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Location = New System.Drawing.Point(0, 3)
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 30)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 26)
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.Button5)
        Me.TabDatos.Controls.Add(Me.btneliminar)
        Me.TabDatos.Controls.Add(Me.btnAdd)
        Me.TabDatos.Controls.Add(Me.GroupBox3)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Size = New System.Drawing.Size(536, 507)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Size = New System.Drawing.Size(536, 507)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(536, 507)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        Me.TreeLista.Location = New System.Drawing.Point(11, 22)
        Me.TreeLista.Size = New System.Drawing.Size(173, 511)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtidentregarecojo)
        Me.GroupBox1.Controls.Add(Me.btncontacto)
        Me.GroupBox1.Controls.Add(Me.btndireccion)
        Me.GroupBox1.Controls.Add(Me.btnBuscarcliente)
        Me.GroupBox1.Controls.Add(Me.txtcontacto)
        Me.GroupBox1.Controls.Add(Me.Txtdireccion)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DTPfecfinal)
        Me.GroupBox1.Controls.Add(Me.DTPFecinicial)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbagencia)
        Me.GroupBox1.Controls.Add(Me.txtidcliente)
        Me.GroupBox1.Controls.Add(Me.txtiddireccion)
        Me.GroupBox1.Controls.Add(Me.txtidcontacto)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(21, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 201)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MANTENIMIENTO"
        '
        'txtidentregarecojo
        '
        Me.txtidentregarecojo.Location = New System.Drawing.Point(305, 7)
        Me.txtidentregarecojo.Name = "txtidentregarecojo"
        Me.txtidentregarecojo.Size = New System.Drawing.Size(100, 20)
        Me.txtidentregarecojo.TabIndex = 29
        Me.txtidentregarecojo.Visible = False
        '
        'btncontacto
        '
        Me.btncontacto.Image = CType(resources.GetObject("btncontacto.Image"), System.Drawing.Image)
        Me.btncontacto.Location = New System.Drawing.Point(417, 159)
        Me.btncontacto.Name = "btncontacto"
        Me.btncontacto.Size = New System.Drawing.Size(26, 23)
        Me.btncontacto.TabIndex = 28
        Me.btncontacto.Text = "..."
        Me.btncontacto.UseVisualStyleBackColor = True
        '
        'btndireccion
        '
        Me.btndireccion.Image = CType(resources.GetObject("btndireccion.Image"), System.Drawing.Image)
        Me.btndireccion.Location = New System.Drawing.Point(417, 132)
        Me.btndireccion.Name = "btndireccion"
        Me.btndireccion.Size = New System.Drawing.Size(26, 23)
        Me.btndireccion.TabIndex = 28
        Me.btndireccion.Text = "..."
        Me.btndireccion.UseVisualStyleBackColor = True
        '
        'btnBuscarcliente
        '
        Me.btnBuscarcliente.Image = CType(resources.GetObject("btnBuscarcliente.Image"), System.Drawing.Image)
        Me.btnBuscarcliente.Location = New System.Drawing.Point(417, 70)
        Me.btnBuscarcliente.Name = "btnBuscarcliente"
        Me.btnBuscarcliente.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscarcliente.TabIndex = 28
        Me.btnBuscarcliente.Text = "..."
        Me.btnBuscarcliente.UseVisualStyleBackColor = True
        '
        'txtcontacto
        '
        Me.txtcontacto.BackColor = System.Drawing.Color.White
        Me.txtcontacto.Location = New System.Drawing.Point(138, 161)
        Me.txtcontacto.Name = "txtcontacto"
        Me.txtcontacto.Size = New System.Drawing.Size(273, 20)
        Me.txtcontacto.TabIndex = 27
        '
        'Txtdireccion
        '
        Me.Txtdireccion.BackColor = System.Drawing.Color.White
        Me.Txtdireccion.Location = New System.Drawing.Point(138, 135)
        Me.Txtdireccion.Name = "Txtdireccion"
        Me.Txtdireccion.Size = New System.Drawing.Size(273, 20)
        Me.Txtdireccion.TabIndex = 27
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Location = New System.Drawing.Point(138, 73)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(273, 20)
        Me.txtCliente.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(31, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "CONTACTO :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(33, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "DIRECCION :"
        '
        'DTPfecfinal
        '
        Me.DTPfecfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfecfinal.Location = New System.Drawing.Point(305, 101)
        Me.DTPfecfinal.Name = "DTPfecfinal"
        Me.DTPfecfinal.Size = New System.Drawing.Size(106, 20)
        Me.DTPfecfinal.TabIndex = 23
        '
        'DTPFecinicial
        '
        Me.DTPFecinicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecinicial.Location = New System.Drawing.Point(138, 101)
        Me.DTPFecinicial.Name = "DTPFecinicial"
        Me.DTPFecinicial.Size = New System.Drawing.Size(88, 20)
        Me.DTPFecinicial.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(236, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "F. FIN :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(36, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "F. INICIO :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(36, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "CLIENTE :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(37, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "AGENCIA : "
        '
        'cmbagencia
        '
        Me.cmbagencia.FormattingEnabled = True
        Me.cmbagencia.Location = New System.Drawing.Point(138, 33)
        Me.cmbagencia.Name = "cmbagencia"
        Me.cmbagencia.Size = New System.Drawing.Size(273, 21)
        Me.cmbagencia.TabIndex = 18
        '
        'txtidcliente
        '
        Me.txtidcliente.Location = New System.Drawing.Point(100, 73)
        Me.txtidcliente.Name = "txtidcliente"
        Me.txtidcliente.Size = New System.Drawing.Size(43, 20)
        Me.txtidcliente.TabIndex = 30
        Me.txtidcliente.Visible = False
        '
        'txtiddireccion
        '
        Me.txtiddireccion.Location = New System.Drawing.Point(100, 135)
        Me.txtiddireccion.Name = "txtiddireccion"
        Me.txtiddireccion.Size = New System.Drawing.Size(43, 20)
        Me.txtiddireccion.TabIndex = 31
        Me.txtiddireccion.Visible = False
        '
        'txtidcontacto
        '
        Me.txtidcontacto.Location = New System.Drawing.Point(100, 161)
        Me.txtidcontacto.Name = "txtidcontacto"
        Me.txtidcontacto.Size = New System.Drawing.Size(43, 20)
        Me.txtidcontacto.TabIndex = 32
        Me.txtidcontacto.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(3, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(499, 460)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Control"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDIA, Me.hora_inicio, Me.Hora_fin, Me.diainactivo})
        Me.DataGridView2.Location = New System.Drawing.Point(6, 187)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(495, 284)
        Me.DataGridView2.TabIndex = 12
        '
        'IDDIA
        '
        Me.IDDIA.HeaderText = "Día"
        Me.IDDIA.Name = "IDDIA"
        '
        'hora_inicio
        '
        Me.hora_inicio.HeaderText = "Hora inicio"
        Me.hora_inicio.Name = "hora_inicio"
        '
        'Hora_fin
        '
        Me.Hora_fin.HeaderText = "Hora final"
        Me.Hora_fin.Name = "Hora_fin"
        '
        'diainactivo
        '
        Me.diainactivo.HeaderText = "Activo"
        Me.diainactivo.Name = "diainactivo"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCONTACTO, Me.Dirección, Me.Telefono})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(495, 141)
        Me.DataGridView1.TabIndex = 11
        '
        'IDCONTACTO
        '
        Me.IDCONTACTO.HeaderText = "Contacto"
        Me.IDCONTACTO.Name = "IDCONTACTO"
        '
        'Dirección
        '
        Me.Dirección.HeaderText = "Direccion"
        Me.Dirección.Name = "Dirección"
        '
        'Telefono
        '
        Me.Telefono.HeaderText = "Teléfono"
        Me.Telefono.Name = "Telefono"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.DGVdiarecojo)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(19, 254)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(509, 219)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CONTROL DIARIO"
        '
        'DGVdiarecojo
        '
        Me.DGVdiarecojo.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVdiarecojo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVdiarecojo.Location = New System.Drawing.Point(15, 19)
        Me.DGVdiarecojo.Name = "DGVdiarecojo"
        Me.DGVdiarecojo.Size = New System.Drawing.Size(480, 194)
        Me.DGVdiarecojo.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(326, 222)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(56, 26)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.Visible = False
        '
        'btneliminar
        '
        Me.btneliminar.BackColor = System.Drawing.Color.Transparent
        Me.btneliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneliminar.Location = New System.Drawing.Point(450, 222)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(64, 26)
        Me.btneliminar.TabIndex = 2
        Me.btneliminar.Text = "&Eliminar"
        Me.btneliminar.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(388, 222)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(56, 26)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "&Editar"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'Frmrecojopactado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "Frmrecojopactado"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DGVdiarecojo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPFecinicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbagencia As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscarcliente As System.Windows.Forms.Button
    Friend WithEvents btndireccion As System.Windows.Forms.Button
    Friend WithEvents Txtdireccion As System.Windows.Forms.TextBox
    Friend WithEvents btncontacto As System.Windows.Forms.Button
    Friend WithEvents txtcontacto As System.Windows.Forms.TextBox
    Friend WithEvents DTPfecfinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents IDDIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hora_inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents diainactivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents IDCONTACTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dirección As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents DGVdiarecojo As System.Windows.Forms.DataGridView
    Friend WithEvents txtidentregarecojo As System.Windows.Forms.TextBox
    Friend WithEvents txtidcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtiddireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtidcontacto As System.Windows.Forms.TextBox

End Class
