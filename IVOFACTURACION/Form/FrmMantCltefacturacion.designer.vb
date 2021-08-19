<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantCltefacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantCltefacturacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdireccion = New System.Windows.Forms.TextBox()
        Me.cmbpais = New System.Windows.Forms.ComboBox()
        Me.cmbprovincia = New System.Windows.Forms.ComboBox()
        Me.cmbdistrito = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbdepartamento = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btndistrito = New System.Windows.Forms.Button()
        Me.btnprovincia = New System.Windows.Forms.Button()
        Me.btndepartamento = New System.Windows.Forms.Button()
        Me.btndireccion = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbtipodireccion = New System.Windows.Forms.ComboBox()
        Me.Btnaceptar = New System.Windows.Forms.Button()
        Me.Btncancelar = New System.Windows.Forms.Button()
        Me.txtiddireccionconsignado = New System.Windows.Forms.TextBox()
        Me.Labayuda = New System.Windows.Forms.Label()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.txtruc = New System.Windows.Forms.TextBox()
        Me.cmbrubro_frmmantclte = New System.Windows.Forms.ComboBox()
        Me.txtrepresentante_legal = New System.Windows.Forms.TextBox()
        Me.labtxtrepresentante_legal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(12, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dirección (Av. Jr. Psj. Call.) :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtdireccion
        '
        Me.txtdireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdireccion.Location = New System.Drawing.Point(177, 220)
        Me.txtdireccion.MaxLength = 100
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(469, 20)
        Me.txtdireccion.TabIndex = 2
        '
        'cmbpais
        '
        Me.cmbpais.BackColor = System.Drawing.SystemColors.Info
        Me.cmbpais.Enabled = False
        Me.cmbpais.FormattingEnabled = True
        Me.cmbpais.Location = New System.Drawing.Point(12, 185)
        Me.cmbpais.Name = "cmbpais"
        Me.cmbpais.Size = New System.Drawing.Size(139, 21)
        Me.cmbpais.TabIndex = 6
        '
        'cmbprovincia
        '
        Me.cmbprovincia.FormattingEnabled = True
        Me.cmbprovincia.Location = New System.Drawing.Point(341, 185)
        Me.cmbprovincia.Name = "cmbprovincia"
        Me.cmbprovincia.Size = New System.Drawing.Size(139, 21)
        Me.cmbprovincia.TabIndex = 8
        '
        'cmbdistrito
        '
        Me.cmbdistrito.FormattingEnabled = True
        Me.cmbdistrito.Location = New System.Drawing.Point(507, 185)
        Me.cmbdistrito.Name = "cmbdistrito"
        Me.cmbdistrito.Size = New System.Drawing.Size(139, 21)
        Me.cmbdistrito.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(12, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "País :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(341, 169)
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
        Me.cmbdepartamento.Location = New System.Drawing.Point(177, 185)
        Me.cmbdepartamento.Name = "cmbdepartamento"
        Me.cmbdepartamento.Size = New System.Drawing.Size(139, 21)
        Me.cmbdepartamento.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(177, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Departamento :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(507, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Distrito :"
        '
        'btndistrito
        '
        Me.btndistrito.Image = CType(resources.GetObject("btndistrito.Image"), System.Drawing.Image)
        Me.btndistrito.Location = New System.Drawing.Point(648, 184)
        Me.btndistrito.Name = "btndistrito"
        Me.btndistrito.Size = New System.Drawing.Size(21, 23)
        Me.btndistrito.TabIndex = 12
        Me.btndistrito.UseVisualStyleBackColor = True
        '
        'btnprovincia
        '
        Me.btnprovincia.Image = CType(resources.GetObject("btnprovincia.Image"), System.Drawing.Image)
        Me.btnprovincia.Location = New System.Drawing.Point(483, 185)
        Me.btnprovincia.Name = "btnprovincia"
        Me.btnprovincia.Size = New System.Drawing.Size(21, 23)
        Me.btnprovincia.TabIndex = 13
        Me.btnprovincia.UseVisualStyleBackColor = True
        '
        'btndepartamento
        '
        Me.btndepartamento.Enabled = False
        Me.btndepartamento.Image = CType(resources.GetObject("btndepartamento.Image"), System.Drawing.Image)
        Me.btndepartamento.Location = New System.Drawing.Point(317, 185)
        Me.btndepartamento.Name = "btndepartamento"
        Me.btndepartamento.Size = New System.Drawing.Size(21, 23)
        Me.btndepartamento.TabIndex = 14
        Me.btndepartamento.UseVisualStyleBackColor = True
        '
        'btndireccion
        '
        Me.btndireccion.Enabled = False
        Me.btndireccion.Image = CType(resources.GetObject("btndireccion.Image"), System.Drawing.Image)
        Me.btndireccion.Location = New System.Drawing.Point(152, 184)
        Me.btndireccion.Name = "btndireccion"
        Me.btndireccion.Size = New System.Drawing.Size(24, 23)
        Me.btndireccion.TabIndex = 15
        Me.btndireccion.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(12, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Tipo dirección :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbtipodireccion)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(3, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(681, 144)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dirección"
        '
        'cmbtipodireccion
        '
        Me.cmbtipodireccion.BackColor = System.Drawing.SystemColors.Info
        Me.cmbtipodireccion.Enabled = False
        Me.cmbtipodireccion.FormattingEnabled = True
        Me.cmbtipodireccion.Location = New System.Drawing.Point(95, 25)
        Me.cmbtipodireccion.Name = "cmbtipodireccion"
        Me.cmbtipodireccion.Size = New System.Drawing.Size(139, 21)
        Me.cmbtipodireccion.TabIndex = 5
        '
        'Btnaceptar
        '
        Me.Btnaceptar.Location = New System.Drawing.Point(496, 265)
        Me.Btnaceptar.Name = "Btnaceptar"
        Me.Btnaceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btnaceptar.TabIndex = 14
        Me.Btnaceptar.Text = "&Aceptar"
        Me.Btnaceptar.UseVisualStyleBackColor = True
        '
        'Btncancelar
        '
        Me.Btncancelar.Location = New System.Drawing.Point(589, 265)
        Me.Btncancelar.Name = "Btncancelar"
        Me.Btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btncancelar.TabIndex = 40
        Me.Btncancelar.Text = "&Cancelar"
        Me.Btncancelar.UseVisualStyleBackColor = True
        '
        'txtiddireccionconsignado
        '
        Me.txtiddireccionconsignado.BackColor = System.Drawing.SystemColors.Info
        Me.txtiddireccionconsignado.Location = New System.Drawing.Point(380, 264)
        Me.txtiddireccionconsignado.Name = "txtiddireccionconsignado"
        Me.txtiddireccionconsignado.ReadOnly = True
        Me.txtiddireccionconsignado.Size = New System.Drawing.Size(100, 20)
        Me.txtiddireccionconsignado.TabIndex = 42
        Me.txtiddireccionconsignado.Visible = False
        '
        'Labayuda
        '
        Me.Labayuda.AutoSize = True
        Me.Labayuda.BackColor = System.Drawing.Color.Transparent
        Me.Labayuda.ForeColor = System.Drawing.Color.Maroon
        Me.Labayuda.Location = New System.Drawing.Point(9, 267)
        Me.Labayuda.Name = "Labayuda"
        Me.Labayuda.Size = New System.Drawing.Size(151, 13)
        Me.Labayuda.TabIndex = 201
        Me.Labayuda.Text = "Aceptar [ F5 ]        Salir [ F12  ]"
        '
        'txtidpersona
        '
        Me.txtidpersona.BackColor = System.Drawing.SystemColors.Info
        Me.txtidpersona.Location = New System.Drawing.Point(263, 264)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.ReadOnly = True
        Me.txtidpersona.Size = New System.Drawing.Size(100, 20)
        Me.txtidpersona.TabIndex = 202
        Me.txtidpersona.Visible = False
        '
        'txtcliente
        '
        Me.txtcliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcliente.Location = New System.Drawing.Point(195, 23)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(469, 20)
        Me.txtcliente.TabIndex = 2
        '
        'txtruc
        '
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Location = New System.Drawing.Point(81, 23)
        Me.txtruc.MaxLength = 11
        Me.txtruc.Name = "txtruc"
        Me.txtruc.Size = New System.Drawing.Size(108, 20)
        Me.txtruc.TabIndex = 0
        '
        'cmbrubro_frmmantclte
        '
        Me.cmbrubro_frmmantclte.FormattingEnabled = True
        Me.cmbrubro_frmmantclte.Location = New System.Drawing.Point(81, 62)
        Me.cmbrubro_frmmantclte.Name = "cmbrubro_frmmantclte"
        Me.cmbrubro_frmmantclte.Size = New System.Drawing.Size(108, 21)
        Me.cmbrubro_frmmantclte.TabIndex = 3
        '
        'txtrepresentante_legal
        '
        Me.txtrepresentante_legal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrepresentante_legal.Location = New System.Drawing.Point(310, 63)
        Me.txtrepresentante_legal.MaxLength = 100
        Me.txtrepresentante_legal.Name = "txtrepresentante_legal"
        Me.txtrepresentante_legal.Size = New System.Drawing.Size(354, 20)
        Me.txtrepresentante_legal.TabIndex = 4
        '
        'labtxtrepresentante_legal
        '
        Me.labtxtrepresentante_legal.AutoSize = True
        Me.labtxtrepresentante_legal.BackColor = System.Drawing.Color.Transparent
        Me.labtxtrepresentante_legal.ForeColor = System.Drawing.Color.Maroon
        Me.labtxtrepresentante_legal.Location = New System.Drawing.Point(196, 66)
        Me.labtxtrepresentante_legal.Name = "labtxtrepresentante_legal"
        Me.labtxtrepresentante_legal.Size = New System.Drawing.Size(112, 13)
        Me.labtxtrepresentante_legal.TabIndex = 207
        Me.labtxtrepresentante_legal.Text = "Representante Legal :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(12, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 208
        Me.Label7.Text = "Rubro :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(9, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 209
        Me.Label8.Text = "Cliente : "
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 94)
        Me.GroupBox2.TabIndex = 210
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Labayuda)
        Me.Panel1.Controls.Add(Me.labtxtrepresentante_legal)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 323)
        Me.Panel1.TabIndex = 211
        '
        'FrmMantCltefacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(690, 324)
        Me.Controls.Add(Me.txtrepresentante_legal)
        Me.Controls.Add(Me.cmbrubro_frmmantclte)
        Me.Controls.Add(Me.txtruc)
        Me.Controls.Add(Me.txtcliente)
        Me.Controls.Add(Me.txtidpersona)
        Me.Controls.Add(Me.txtiddireccionconsignado)
        Me.Controls.Add(Me.Btncancelar)
        Me.Controls.Add(Me.Btnaceptar)
        Me.Controls.Add(Me.btndireccion)
        Me.Controls.Add(Me.btndepartamento)
        Me.Controls.Add(Me.btnprovincia)
        Me.Controls.Add(Me.cmbdepartamento)
        Me.Controls.Add(Me.cmbdistrito)
        Me.Controls.Add(Me.cmbprovincia)
        Me.Controls.Add(Me.cmbpais)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.btndistrito)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantCltefacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mantenimiento Cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btnaceptar As System.Windows.Forms.Button
    Friend WithEvents Btncancelar As System.Windows.Forms.Button
    Friend WithEvents txtiddireccionconsignado As System.Windows.Forms.TextBox
    Friend WithEvents Labayuda As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtruc As System.Windows.Forms.TextBox
    Friend WithEvents cmbrubro_frmmantclte As System.Windows.Forms.ComboBox
    Friend WithEvents txtrepresentante_legal As System.Windows.Forms.TextBox
    Friend WithEvents labtxtrepresentante_legal As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbtipodireccion As System.Windows.Forms.ComboBox
End Class
