<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsolicitudrecojo
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
        Me.Labfecha = New System.Windows.Forms.Label
        Me.Labagencia = New System.Windows.Forms.Label
        Me.cmbagencia = New System.Windows.Forms.ComboBox
        Me.chksol = New System.Windows.Forms.CheckBox
        Me.DTimePickersol = New System.Windows.Forms.DateTimePicker
        Me.DTimePickerAsigna = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chk_asigna = New System.Windows.Forms.CheckBox
        Me.Cmbagenciaasigna = New System.Windows.Forms.ComboBox
        Me.DGVAsigna = New System.Windows.Forms.DataGridView
        Me.Labruta = New System.Windows.Forms.Label
        Me.cmbrutaasigna = New System.Windows.Forms.ComboBox
        Me.cmbrutaresumen = New System.Windows.Forms.ComboBox
        Me.DTimePickerresumen = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkresumen = New System.Windows.Forms.CheckBox
        Me.cmbagenciaresumen = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGVResumen = New System.Windows.Forms.DataGridView
        Me.DGVSolicita = New System.Windows.Forms.DataGridView
        Me.DGVCliente = New System.Windows.Forms.DataGridView
        Me.DGVDireccion = New System.Windows.Forms.DataGridView
        Me.DGVContacto = New System.Windows.Forms.DataGridView
        Me.labayuda = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.DTimePickerfecprox = New System.Windows.Forms.DateTimePicker
        Me.GBoxproxfecha = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
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
        CType(Me.DGVAsigna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVSolicita, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxproxfecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Location = New System.Drawing.Point(0, -2)
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Panel1Collapsed = True
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(11, 18)
        Me.Panel1.Size = New System.Drawing.Size(762, 520)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(760, 512)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.Label6)
        Me.TabLista.Controls.Add(Me.labayuda)
        Me.TabLista.Controls.Add(Me.DGVContacto)
        Me.TabLista.Controls.Add(Me.DGVDireccion)
        Me.TabLista.Controls.Add(Me.DGVCliente)
        Me.TabLista.Controls.Add(Me.DGVSolicita)
        Me.TabLista.Controls.Add(Me.DTimePickersol)
        Me.TabLista.Controls.Add(Me.Labfecha)
        Me.TabLista.Controls.Add(Me.Labagencia)
        Me.TabLista.Controls.Add(Me.chksol)
        Me.TabLista.Controls.Add(Me.cmbagencia)
        Me.TabLista.Size = New System.Drawing.Size(752, 483)
        Me.TabLista.Controls.SetChildIndex(Me.LabeloSCAR, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbagencia, 0)
        Me.TabLista.Controls.SetChildIndex(Me.chksol, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Labagencia, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Labfecha, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DTimePickersol, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGVSolicita, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGVCliente, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGVDireccion, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGVContacto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.labayuda, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label6, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.cmbrutaasigna)
        Me.TabDatos.Controls.Add(Me.Labruta)
        Me.TabDatos.Controls.Add(Me.DGVAsigna)
        Me.TabDatos.Controls.Add(Me.DTimePickerAsigna)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.chk_asigna)
        Me.TabDatos.Controls.Add(Me.Cmbagenciaasigna)
        Me.TabDatos.Size = New System.Drawing.Size(752, 483)
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(21, 17)
        Me.TxtBusca.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.GBoxproxfecha)
        Me.TabPage1.Controls.Add(Me.DGVResumen)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmbrutaresumen)
        Me.TabPage1.Controls.Add(Me.DTimePickerresumen)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.chkresumen)
        Me.TabPage1.Controls.Add(Me.cmbagenciaresumen)
        Me.TabPage1.Size = New System.Drawing.Size(752, 483)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(752, 483)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'LabeloSCAR
        '
        Me.LabeloSCAR.Location = New System.Drawing.Point(21, 25)
        Me.LabeloSCAR.Visible = False
        '
        'Labfecha
        '
        Me.Labfecha.AutoSize = True
        Me.Labfecha.BackColor = System.Drawing.Color.Transparent
        Me.Labfecha.Location = New System.Drawing.Point(22, 18)
        Me.Labfecha.Name = "Labfecha"
        Me.Labfecha.Size = New System.Drawing.Size(46, 13)
        Me.Labfecha.TabIndex = 10
        Me.Labfecha.Text = "Fecha : "
        '
        'Labagencia
        '
        Me.Labagencia.AutoSize = True
        Me.Labagencia.BackColor = System.Drawing.Color.Transparent
        Me.Labagencia.Location = New System.Drawing.Point(382, 18)
        Me.Labagencia.Name = "Labagencia"
        Me.Labagencia.Size = New System.Drawing.Size(55, 13)
        Me.Labagencia.TabIndex = 11
        Me.Labagencia.Text = "Agencia : "
        '
        'cmbagencia
        '
        Me.cmbagencia.FormattingEnabled = True
        Me.cmbagencia.Location = New System.Drawing.Point(443, 15)
        Me.cmbagencia.Name = "cmbagencia"
        Me.cmbagencia.Size = New System.Drawing.Size(121, 21)
        Me.cmbagencia.TabIndex = 12
        '
        'chksol
        '
        Me.chksol.AutoSize = True
        Me.chksol.BackColor = System.Drawing.Color.Transparent
        Me.chksol.Location = New System.Drawing.Point(598, 17)
        Me.chksol.Name = "chksol"
        Me.chksol.Size = New System.Drawing.Size(56, 17)
        Me.chksol.TabIndex = 13
        Me.chksol.Text = "Todos"
        Me.chksol.UseVisualStyleBackColor = False
        '
        'DTimePickersol
        '
        Me.DTimePickersol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTimePickersol.Location = New System.Drawing.Point(75, 17)
        Me.DTimePickersol.Name = "DTimePickersol"
        Me.DTimePickersol.Size = New System.Drawing.Size(84, 20)
        Me.DTimePickersol.TabIndex = 14
        '
        'DTimePickerAsigna
        '
        Me.DTimePickerAsigna.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTimePickerAsigna.Location = New System.Drawing.Point(59, 20)
        Me.DTimePickerAsigna.Name = "DTimePickerAsigna"
        Me.DTimePickerAsigna.Size = New System.Drawing.Size(84, 20)
        Me.DTimePickerAsigna.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Fecha : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(225, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Agencia : "
        '
        'chk_asigna
        '
        Me.chk_asigna.AutoSize = True
        Me.chk_asigna.BackColor = System.Drawing.Color.Transparent
        Me.chk_asigna.Location = New System.Drawing.Point(423, 20)
        Me.chk_asigna.Name = "chk_asigna"
        Me.chk_asigna.Size = New System.Drawing.Size(56, 17)
        Me.chk_asigna.TabIndex = 18
        Me.chk_asigna.Text = "Todos"
        Me.chk_asigna.UseVisualStyleBackColor = False
        '
        'Cmbagenciaasigna
        '
        Me.Cmbagenciaasigna.FormattingEnabled = True
        Me.Cmbagenciaasigna.Location = New System.Drawing.Point(286, 18)
        Me.Cmbagenciaasigna.Name = "Cmbagenciaasigna"
        Me.Cmbagenciaasigna.Size = New System.Drawing.Size(131, 21)
        Me.Cmbagenciaasigna.TabIndex = 17
        '
        'DGVAsigna
        '
        Me.DGVAsigna.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVAsigna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVAsigna.Location = New System.Drawing.Point(7, 58)
        Me.DGVAsigna.Name = "DGVAsigna"
        Me.DGVAsigna.Size = New System.Drawing.Size(737, 384)
        Me.DGVAsigna.TabIndex = 20
        '
        'Labruta
        '
        Me.Labruta.AutoSize = True
        Me.Labruta.BackColor = System.Drawing.Color.Transparent
        Me.Labruta.Location = New System.Drawing.Point(539, 21)
        Me.Labruta.Name = "Labruta"
        Me.Labruta.Size = New System.Drawing.Size(36, 13)
        Me.Labruta.TabIndex = 21
        Me.Labruta.Text = "Ruta :"
        '
        'cmbrutaasigna
        '
        Me.cmbrutaasigna.FormattingEnabled = True
        Me.cmbrutaasigna.Location = New System.Drawing.Point(581, 18)
        Me.cmbrutaasigna.Name = "cmbrutaasigna"
        Me.cmbrutaasigna.Size = New System.Drawing.Size(163, 21)
        Me.cmbrutaasigna.TabIndex = 22
        '
        'cmbrutaresumen
        '
        Me.cmbrutaresumen.FormattingEnabled = True
        Me.cmbrutaresumen.Location = New System.Drawing.Point(580, 34)
        Me.cmbrutaresumen.Name = "cmbrutaresumen"
        Me.cmbrutaresumen.Size = New System.Drawing.Size(163, 21)
        Me.cmbrutaresumen.TabIndex = 28
        '
        'DTimePickerresumen
        '
        Me.DTimePickerresumen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTimePickerresumen.Location = New System.Drawing.Point(61, 33)
        Me.DTimePickerresumen.Name = "DTimePickerresumen"
        Me.DTimePickerresumen.Size = New System.Drawing.Size(84, 20)
        Me.DTimePickerresumen.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(8, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Fecha : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(227, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Agencia : "
        '
        'chkresumen
        '
        Me.chkresumen.AutoSize = True
        Me.chkresumen.BackColor = System.Drawing.Color.Transparent
        Me.chkresumen.Location = New System.Drawing.Point(443, 36)
        Me.chkresumen.Name = "chkresumen"
        Me.chkresumen.Size = New System.Drawing.Size(56, 17)
        Me.chkresumen.TabIndex = 26
        Me.chkresumen.Text = "Todos"
        Me.chkresumen.UseVisualStyleBackColor = False
        '
        'cmbagenciaresumen
        '
        Me.cmbagenciaresumen.FormattingEnabled = True
        Me.cmbagenciaresumen.Location = New System.Drawing.Point(288, 34)
        Me.cmbagenciaresumen.Name = "cmbagenciaresumen"
        Me.cmbagenciaresumen.Size = New System.Drawing.Size(131, 21)
        Me.cmbagenciaresumen.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(535, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Ruta : "
        '
        'DGVResumen
        '
        Me.DGVResumen.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVResumen.Location = New System.Drawing.Point(4, 74)
        Me.DGVResumen.Name = "DGVResumen"
        Me.DGVResumen.Size = New System.Drawing.Size(739, 375)
        Me.DGVResumen.TabIndex = 30
        '
        'DGVSolicita
        '
        Me.DGVSolicita.AllowUserToOrderColumns = True
        Me.DGVSolicita.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVSolicita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSolicita.Location = New System.Drawing.Point(6, 60)
        Me.DGVSolicita.Name = "DGVSolicita"
        Me.DGVSolicita.Size = New System.Drawing.Size(738, 381)
        Me.DGVSolicita.TabIndex = 15
        '
        'DGVCliente
        '
        Me.DGVCliente.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCliente.Location = New System.Drawing.Point(195, 118)
        Me.DGVCliente.Name = "DGVCliente"
        Me.DGVCliente.Size = New System.Drawing.Size(240, 150)
        Me.DGVCliente.TabIndex = 16
        '
        'DGVDireccion
        '
        Me.DGVDireccion.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVDireccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDireccion.Location = New System.Drawing.Point(303, 118)
        Me.DGVDireccion.Name = "DGVDireccion"
        Me.DGVDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVDireccion.Size = New System.Drawing.Size(240, 150)
        Me.DGVDireccion.TabIndex = 17
        '
        'DGVContacto
        '
        Me.DGVContacto.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVContacto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVContacto.Location = New System.Drawing.Point(414, 118)
        Me.DGVContacto.Name = "DGVContacto"
        Me.DGVContacto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVContacto.Size = New System.Drawing.Size(240, 150)
        Me.DGVContacto.TabIndex = 18
        '
        'labayuda
        '
        Me.labayuda.AutoSize = True
        Me.labayuda.BackColor = System.Drawing.Color.Transparent
        Me.labayuda.Location = New System.Drawing.Point(21, 44)
        Me.labayuda.Name = "labayuda"
        Me.labayuda.Size = New System.Drawing.Size(137, 13)
        Me.labayuda.TabIndex = 19
        Me.labayuda.Text = "F1 - Consulta       Esc - Salir"
        Me.labayuda.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(18, 451)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(395, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Nuevo [ F1 ]                Editar [ F2 ]               Suspender  [ F3 ]        " & _
            "       Salir [ F12 ] "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(4, 457)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(435, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Editar [ F2 ]                                     Suspender  [ F3 ]              " & _
            "                             Salir [ F12 ]"
        '
        'DTimePickerfecprox
        '
        Me.DTimePickerfecprox.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTimePickerfecprox.Location = New System.Drawing.Point(24, 29)
        Me.DTimePickerfecprox.Name = "DTimePickerfecprox"
        Me.DTimePickerfecprox.Size = New System.Drawing.Size(97, 20)
        Me.DTimePickerfecprox.TabIndex = 0
        Me.DTimePickerfecprox.Visible = False
        '
        'GBoxproxfecha
        '
        Me.GBoxproxfecha.BackColor = System.Drawing.Color.Transparent
        Me.GBoxproxfecha.Controls.Add(Me.DTimePickerfecprox)
        Me.GBoxproxfecha.Location = New System.Drawing.Point(580, 145)
        Me.GBoxproxfecha.Name = "GBoxproxfecha"
        Me.GBoxproxfecha.Size = New System.Drawing.Size(137, 67)
        Me.GBoxproxfecha.TabIndex = 31
        Me.GBoxproxfecha.TabStop = False
        Me.GBoxproxfecha.Text = "      Próxima fecha   "
        Me.GBoxproxfecha.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(20, 460)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(435, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Editar [ F2 ]                                     Suspender  [ F3 ]              " & _
            "                             Salir [ F12 ]"
        '
        'frmsolicitudrecojo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "frmsolicitudrecojo"
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
        Me.TabDatos.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DGVAsigna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVResumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVSolicita, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxproxfecha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Labfecha As System.Windows.Forms.Label
    Friend WithEvents Labagencia As System.Windows.Forms.Label
    Friend WithEvents cmbagencia As System.Windows.Forms.ComboBox
    Friend WithEvents chksol As System.Windows.Forms.CheckBox
    Friend WithEvents DTimePickersol As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGVAsigna As System.Windows.Forms.DataGridView
    Friend WithEvents DTimePickerAsigna As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chk_asigna As System.Windows.Forms.CheckBox
    Friend WithEvents Cmbagenciaasigna As System.Windows.Forms.ComboBox
    Friend WithEvents Labruta As System.Windows.Forms.Label
    Friend WithEvents cmbrutaasigna As System.Windows.Forms.ComboBox
    Friend WithEvents DGVResumen As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbrutaresumen As System.Windows.Forms.ComboBox
    Friend WithEvents DTimePickerresumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkresumen As System.Windows.Forms.CheckBox
    Friend WithEvents cmbagenciaresumen As System.Windows.Forms.ComboBox
    Friend WithEvents DGVSolicita As System.Windows.Forms.DataGridView
    Friend WithEvents DGVCliente As System.Windows.Forms.DataGridView
    Friend WithEvents DGVDireccion As System.Windows.Forms.DataGridView
    Friend WithEvents DGVContacto As System.Windows.Forms.DataGridView
    Friend WithEvents labayuda As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GBoxproxfecha As System.Windows.Forms.GroupBox
    Friend WithEvents DTimePickerfecprox As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
