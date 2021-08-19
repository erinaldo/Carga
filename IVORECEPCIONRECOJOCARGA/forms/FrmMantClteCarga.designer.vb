<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantClteCarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantClteCarga))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtdireccion = New System.Windows.Forms.TextBox
        Me.cmbpais = New System.Windows.Forms.ComboBox
        Me.cmbprovincia = New System.Windows.Forms.ComboBox
        Me.cmbdistrito = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbdepartamento = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btndistrito = New System.Windows.Forms.Button
        Me.btnprovincia = New System.Windows.Forms.Button
        Me.btndepartamento = New System.Windows.Forms.Button
        Me.btndireccion = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtrefllegada = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtubigeografica = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbtipdireccion = New System.Windows.Forms.ComboBox
        Me.cmbsubcuenta = New System.Windows.Forms.ComboBox
        Me.btnsubcuenta = New System.Windows.Forms.Button
        Me.cmbcargo = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnCargocontacto = New System.Windows.Forms.Button
        Me.rbtmasculino = New System.Windows.Forms.RadioButton
        Me.rbtfemenino = New System.Windows.Forms.RadioButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.labapellidosynombres = New System.Windows.Forms.Label
        Me.Btnaceptar = New System.Windows.Forms.Button
        Me.Btncancelar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.labnroidentidad = New System.Windows.Forms.Label
        Me.txtapellidos_y_nombres = New System.Windows.Forms.TextBox
        Me.btndctoidentidad = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtnrodocumento = New System.Windows.Forms.TextBox
        Me.cmbtipodcto = New System.Windows.Forms.ComboBox
        Me.txtiddireccionconsignado = New System.Windows.Forms.TextBox
        Me.Labayuda = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dirección (Av. Jr. Psj. Call.) :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtdireccion
        '
        Me.txtdireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdireccion.Location = New System.Drawing.Point(177, 103)
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(469, 20)
        Me.txtdireccion.TabIndex = 2
        '
        'cmbpais
        '
        Me.cmbpais.BackColor = System.Drawing.SystemColors.Info
        Me.cmbpais.Enabled = False
        Me.cmbpais.FormattingEnabled = True
        Me.cmbpais.Location = New System.Drawing.Point(12, 68)
        Me.cmbpais.Name = "cmbpais"
        Me.cmbpais.Size = New System.Drawing.Size(139, 21)
        Me.cmbpais.TabIndex = 5
        '
        'cmbprovincia
        '
        Me.cmbprovincia.FormattingEnabled = True
        Me.cmbprovincia.Location = New System.Drawing.Point(341, 68)
        Me.cmbprovincia.Name = "cmbprovincia"
        Me.cmbprovincia.Size = New System.Drawing.Size(139, 21)
        Me.cmbprovincia.TabIndex = 100
        '
        'cmbdistrito
        '
        Me.cmbdistrito.FormattingEnabled = True
        Me.cmbdistrito.Location = New System.Drawing.Point(507, 68)
        Me.cmbdistrito.Name = "cmbdistrito"
        Me.cmbdistrito.Size = New System.Drawing.Size(139, 21)
        Me.cmbdistrito.TabIndex = 200
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "País :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(341, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Provincia :"
        '
        'cmbdepartamento
        '
        Me.cmbdepartamento.BackColor = System.Drawing.SystemColors.Info
        Me.cmbdepartamento.Enabled = False
        Me.cmbdepartamento.FormattingEnabled = True
        Me.cmbdepartamento.Location = New System.Drawing.Point(177, 68)
        Me.cmbdepartamento.Name = "cmbdepartamento"
        Me.cmbdepartamento.Size = New System.Drawing.Size(139, 21)
        Me.cmbdepartamento.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(177, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Departamento :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(507, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Distrito :"
        '
        'btndistrito
        '
        Me.btndistrito.Image = CType(resources.GetObject("btndistrito.Image"), System.Drawing.Image)
        Me.btndistrito.Location = New System.Drawing.Point(650, 68)
        Me.btndistrito.Name = "btndistrito"
        Me.btndistrito.Size = New System.Drawing.Size(21, 23)
        Me.btndistrito.TabIndex = 12
        Me.btndistrito.UseVisualStyleBackColor = True
        '
        'btnprovincia
        '
        Me.btnprovincia.Image = CType(resources.GetObject("btnprovincia.Image"), System.Drawing.Image)
        Me.btnprovincia.Location = New System.Drawing.Point(483, 68)
        Me.btnprovincia.Name = "btnprovincia"
        Me.btnprovincia.Size = New System.Drawing.Size(21, 23)
        Me.btnprovincia.TabIndex = 13
        Me.btnprovincia.UseVisualStyleBackColor = True
        '
        'btndepartamento
        '
        Me.btndepartamento.Enabled = False
        Me.btndepartamento.Image = CType(resources.GetObject("btndepartamento.Image"), System.Drawing.Image)
        Me.btndepartamento.Location = New System.Drawing.Point(317, 68)
        Me.btndepartamento.Name = "btndepartamento"
        Me.btndepartamento.Size = New System.Drawing.Size(21, 23)
        Me.btndepartamento.TabIndex = 14
        Me.btndepartamento.UseVisualStyleBackColor = True
        '
        'btndireccion
        '
        Me.btndireccion.Enabled = False
        Me.btndireccion.Image = CType(resources.GetObject("btndireccion.Image"), System.Drawing.Image)
        Me.btndireccion.Location = New System.Drawing.Point(152, 67)
        Me.btndireccion.Name = "btndireccion"
        Me.btndireccion.Size = New System.Drawing.Size(24, 23)
        Me.btndireccion.TabIndex = 15
        Me.btndireccion.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Tipo dirección :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Referencia llegada :"
        '
        'txtrefllegada
        '
        Me.txtrefllegada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrefllegada.Location = New System.Drawing.Point(177, 130)
        Me.txtrefllegada.Name = "txtrefllegada"
        Me.txtrefllegada.Size = New System.Drawing.Size(469, 20)
        Me.txtrefllegada.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(356, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Código ubicación geográfica :"
        '
        'txtubigeografica
        '
        Me.txtubigeografica.BackColor = System.Drawing.SystemColors.Info
        Me.txtubigeografica.Location = New System.Drawing.Point(507, 17)
        Me.txtubigeografica.Name = "txtubigeografica"
        Me.txtubigeografica.ReadOnly = True
        Me.txtubigeografica.Size = New System.Drawing.Size(139, 20)
        Me.txtubigeografica.TabIndex = 0
        Me.txtubigeografica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbtipdireccion)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(681, 163)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dirección"
        '
        'cmbtipdireccion
        '
        Me.cmbtipdireccion.BackColor = System.Drawing.SystemColors.Info
        Me.cmbtipdireccion.Enabled = False
        Me.cmbtipdireccion.FormattingEnabled = True
        Me.cmbtipdireccion.Location = New System.Drawing.Point(92, 14)
        Me.cmbtipdireccion.Name = "cmbtipdireccion"
        Me.cmbtipdireccion.Size = New System.Drawing.Size(146, 21)
        Me.cmbtipdireccion.TabIndex = 1
        '
        'cmbsubcuenta
        '
        Me.cmbsubcuenta.BackColor = System.Drawing.SystemColors.Info
        Me.cmbsubcuenta.Enabled = False
        Me.cmbsubcuenta.FormattingEnabled = True
        Me.cmbsubcuenta.Location = New System.Drawing.Point(12, 203)
        Me.cmbsubcuenta.Name = "cmbsubcuenta"
        Me.cmbsubcuenta.Size = New System.Drawing.Size(139, 21)
        Me.cmbsubcuenta.TabIndex = 24
        '
        'btnsubcuenta
        '
        Me.btnsubcuenta.Enabled = False
        Me.btnsubcuenta.Image = CType(resources.GetObject("btnsubcuenta.Image"), System.Drawing.Image)
        Me.btnsubcuenta.Location = New System.Drawing.Point(151, 202)
        Me.btnsubcuenta.Name = "btnsubcuenta"
        Me.btnsubcuenta.Size = New System.Drawing.Size(24, 23)
        Me.btnsubcuenta.TabIndex = 25
        Me.btnsubcuenta.UseVisualStyleBackColor = True
        '
        'cmbcargo
        '
        Me.cmbcargo.BackColor = System.Drawing.Color.White
        Me.cmbcargo.FormattingEnabled = True
        Me.cmbcargo.Location = New System.Drawing.Point(174, 33)
        Me.cmbcargo.Name = "cmbcargo"
        Me.cmbcargo.Size = New System.Drawing.Size(139, 21)
        Me.cmbcargo.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Sub Cuenta :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(175, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Cargo contacto :"
        '
        'btnCargocontacto
        '
        Me.btnCargocontacto.Image = CType(resources.GetObject("btnCargocontacto.Image"), System.Drawing.Image)
        Me.btnCargocontacto.Location = New System.Drawing.Point(315, 32)
        Me.btnCargocontacto.Name = "btnCargocontacto"
        Me.btnCargocontacto.Size = New System.Drawing.Size(21, 23)
        Me.btnCargocontacto.TabIndex = 29
        Me.btnCargocontacto.UseVisualStyleBackColor = True
        '
        'rbtmasculino
        '
        Me.rbtmasculino.AutoSize = True
        Me.rbtmasculino.Location = New System.Drawing.Point(510, 248)
        Me.rbtmasculino.Name = "rbtmasculino"
        Me.rbtmasculino.Size = New System.Drawing.Size(73, 17)
        Me.rbtmasculino.TabIndex = 8
        Me.rbtmasculino.TabStop = True
        Me.rbtmasculino.Text = "Masculino"
        Me.rbtmasculino.UseVisualStyleBackColor = True
        '
        'rbtfemenino
        '
        Me.rbtfemenino.AutoSize = True
        Me.rbtfemenino.Location = New System.Drawing.Point(590, 248)
        Me.rbtfemenino.Name = "rbtfemenino"
        Me.rbtfemenino.Size = New System.Drawing.Size(71, 17)
        Me.rbtfemenino.TabIndex = 9
        Me.rbtfemenino.TabStop = True
        Me.rbtfemenino.Text = "Femenino"
        Me.rbtfemenino.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(507, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Sexo :"
        '
        'labapellidosynombres
        '
        Me.labapellidosynombres.AutoSize = True
        Me.labapellidosynombres.Location = New System.Drawing.Point(15, 231)
        Me.labapellidosynombres.Name = "labapellidosynombres"
        Me.labapellidosynombres.Size = New System.Drawing.Size(109, 13)
        Me.labapellidosynombres.TabIndex = 36
        Me.labapellidosynombres.Text = "Apellidos y nombres : "
        '
        'Btnaceptar
        '
        Me.Btnaceptar.Location = New System.Drawing.Point(496, 284)
        Me.Btnaceptar.Name = "Btnaceptar"
        Me.Btnaceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btnaceptar.TabIndex = 14
        Me.Btnaceptar.Text = "&Aceptar"
        Me.Btnaceptar.UseVisualStyleBackColor = True
        '
        'Btncancelar
        '
        Me.Btncancelar.Location = New System.Drawing.Point(589, 284)
        Me.Btncancelar.Name = "Btncancelar"
        Me.Btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btncancelar.TabIndex = 40
        Me.Btncancelar.Text = "&Cancelar"
        Me.Btncancelar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.labnroidentidad)
        Me.GroupBox2.Controls.Add(Me.txtapellidos_y_nombres)
        Me.GroupBox2.Controls.Add(Me.btndctoidentidad)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtnrodocumento)
        Me.GroupBox2.Controls.Add(Me.cmbtipodcto)
        Me.GroupBox2.Controls.Add(Me.cmbcargo)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.btnCargocontacto)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(3, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 104)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos personales contacto"
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(525, 13)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(71, 13)
        Me.labnroidentidad.TabIndex = 34
        Me.labnroidentidad.Text = "Nº identidad :"
        '
        'txtapellidos_y_nombres
        '
        Me.txtapellidos_y_nombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapellidos_y_nombres.Location = New System.Drawing.Point(9, 78)
        Me.txtapellidos_y_nombres.Name = "txtapellidos_y_nombres"
        Me.txtapellidos_y_nombres.Size = New System.Drawing.Size(492, 20)
        Me.txtapellidos_y_nombres.TabIndex = 33
        '
        'btndctoidentidad
        '
        Me.btndctoidentidad.Image = CType(resources.GetObject("btndctoidentidad.Image"), System.Drawing.Image)
        Me.btndctoidentidad.Location = New System.Drawing.Point(503, 32)
        Me.btndctoidentidad.Name = "btndctoidentidad"
        Me.btndctoidentidad.Size = New System.Drawing.Size(21, 23)
        Me.btndctoidentidad.TabIndex = 30
        Me.btndctoidentidad.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(338, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Documento identidad :"
        '
        'txtnrodocumento
        '
        Me.txtnrodocumento.Location = New System.Drawing.Point(528, 32)
        Me.txtnrodocumento.Name = "txtnrodocumento"
        Me.txtnrodocumento.Size = New System.Drawing.Size(115, 20)
        Me.txtnrodocumento.TabIndex = 4
        '
        'cmbtipodcto
        '
        Me.cmbtipodcto.FormattingEnabled = True
        Me.cmbtipodcto.Location = New System.Drawing.Point(338, 33)
        Me.cmbtipodcto.Name = "cmbtipodcto"
        Me.cmbtipodcto.Size = New System.Drawing.Size(163, 21)
        Me.cmbtipodcto.TabIndex = 11
        '
        'txtiddireccionconsignado
        '
        Me.txtiddireccionconsignado.BackColor = System.Drawing.SystemColors.Info
        Me.txtiddireccionconsignado.Location = New System.Drawing.Point(380, 283)
        Me.txtiddireccionconsignado.Name = "txtiddireccionconsignado"
        Me.txtiddireccionconsignado.ReadOnly = True
        Me.txtiddireccionconsignado.Size = New System.Drawing.Size(100, 20)
        Me.txtiddireccionconsignado.TabIndex = 42
        Me.txtiddireccionconsignado.Visible = False
        '
        'Labayuda
        '
        Me.Labayuda.AutoSize = True
        Me.Labayuda.Location = New System.Drawing.Point(9, 286)
        Me.Labayuda.Name = "Labayuda"
        Me.Labayuda.Size = New System.Drawing.Size(151, 13)
        Me.Labayuda.TabIndex = 201
        Me.Labayuda.Text = "Aceptar [ F5 ]        Salir [ F12  ]"
        '
        'FrmMantClteCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 324)
        Me.Controls.Add(Me.Labayuda)
        Me.Controls.Add(Me.txtiddireccionconsignado)
        Me.Controls.Add(Me.Btncancelar)
        Me.Controls.Add(Me.Btnaceptar)
        Me.Controls.Add(Me.labapellidosynombres)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.rbtfemenino)
        Me.Controls.Add(Me.rbtmasculino)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnsubcuenta)
        Me.Controls.Add(Me.cmbsubcuenta)
        Me.Controls.Add(Me.txtubigeografica)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtrefllegada)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btndireccion)
        Me.Controls.Add(Me.btndepartamento)
        Me.Controls.Add(Me.btnprovincia)
        Me.Controls.Add(Me.btndistrito)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbdepartamento)
        Me.Controls.Add(Me.cmbdistrito)
        Me.Controls.Add(Me.cmbprovincia)
        Me.Controls.Add(Me.cmbpais)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantClteCarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mantenimiento Cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdireccion As System.Windows.Forms.TextBox
    Friend WithEvents cmbpais As System.Windows.Forms.ComboBox
    Friend WithEvents cmbprovincia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbdistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbdepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btndistrito As System.Windows.Forms.Button
    Friend WithEvents btnprovincia As System.Windows.Forms.Button
    Friend WithEvents btndepartamento As System.Windows.Forms.Button
    Friend WithEvents btndireccion As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtrefllegada As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtubigeografica As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbsubcuenta As System.Windows.Forms.ComboBox
    Friend WithEvents btnsubcuenta As System.Windows.Forms.Button
    Friend WithEvents cmbcargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCargocontacto As System.Windows.Forms.Button
    Friend WithEvents rbtmasculino As System.Windows.Forms.RadioButton
    Friend WithEvents rbtfemenino As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents labapellidosynombres As System.Windows.Forms.Label
    Friend WithEvents Btnaceptar As System.Windows.Forms.Button
    Friend WithEvents Btncancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnrodocumento As System.Windows.Forms.TextBox
    Friend WithEvents cmbtipodcto As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbtipdireccion As System.Windows.Forms.ComboBox
    Friend WithEvents txtiddireccionconsignado As System.Windows.Forms.TextBox
    Friend WithEvents btndctoidentidad As System.Windows.Forms.Button
    Friend WithEvents txtapellidos_y_nombres As System.Windows.Forms.TextBox
    Friend WithEvents Labayuda As System.Windows.Forms.Label
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
End Class
