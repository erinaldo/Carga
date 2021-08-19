<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContacto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContacto))
        Me.TabDatos = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.DtgContacto = New System.Windows.Forms.DataGridView()
        Me.BtnBuscarCont = New System.Windows.Forms.Button()
        Me.rdbdoc = New System.Windows.Forms.RadioButton()
        Me.txtcontacto = New System.Windows.Forms.TextBox()
        Me.rdbnom = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CboDocContacto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CboMovil = New System.Windows.Forms.ComboBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtmovil = New System.Windows.Forms.TextBox()
        Me.txtfijo = New System.Windows.Forms.TextBox()
        Me.labnroidentidad = New System.Windows.Forms.Label()
        Me.txtnrodocumento = New System.Windows.Forms.TextBox()
        Me.txtnomc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.TabDatos.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.DtgContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.TabPage4)
        Me.TabDatos.Controls.Add(Me.TabPage2)
        Me.TabDatos.Location = New System.Drawing.Point(3, 5)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.SelectedIndex = 0
        Me.TabDatos.Size = New System.Drawing.Size(654, 283)
        Me.TabDatos.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DtgContacto)
        Me.TabPage4.Controls.Add(Me.BtnBuscarCont)
        Me.TabPage4.Controls.Add(Me.rdbdoc)
        Me.TabPage4.Controls.Add(Me.txtcontacto)
        Me.TabPage4.Controls.Add(Me.rdbnom)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(646, 257)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Búsqueda"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DtgContacto
        '
        Me.DtgContacto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtgContacto.Location = New System.Drawing.Point(7, 54)
        Me.DtgContacto.Name = "DtgContacto"
        Me.DtgContacto.Size = New System.Drawing.Size(632, 198)
        Me.DtgContacto.TabIndex = 5
        '
        'BtnBuscarCont
        '
        Me.BtnBuscarCont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarCont.Image = CType(resources.GetObject("BtnBuscarCont.Image"), System.Drawing.Image)
        Me.BtnBuscarCont.Location = New System.Drawing.Point(572, 27)
        Me.BtnBuscarCont.Name = "BtnBuscarCont"
        Me.BtnBuscarCont.Size = New System.Drawing.Size(67, 23)
        Me.BtnBuscarCont.TabIndex = 4
        Me.BtnBuscarCont.Text = "Buscar"
        Me.BtnBuscarCont.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBuscarCont.UseVisualStyleBackColor = True
        '
        'rdbdoc
        '
        Me.rdbdoc.AutoSize = True
        Me.rdbdoc.Location = New System.Drawing.Point(137, 9)
        Me.rdbdoc.Name = "rdbdoc"
        Me.rdbdoc.Size = New System.Drawing.Size(164, 17)
        Me.rdbdoc.TabIndex = 3
        Me.rdbdoc.Text = "Buscar por Nº de Documento"
        Me.rdbdoc.UseVisualStyleBackColor = True
        '
        'txtcontacto
        '
        Me.txtcontacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontacto.Location = New System.Drawing.Point(7, 29)
        Me.txtcontacto.MaxLength = 100
        Me.txtcontacto.Name = "txtcontacto"
        Me.txtcontacto.Size = New System.Drawing.Size(553, 20)
        Me.txtcontacto.TabIndex = 2
        '
        'rdbnom
        '
        Me.rdbnom.AutoSize = True
        Me.rdbnom.Checked = True
        Me.rdbnom.Location = New System.Drawing.Point(7, 9)
        Me.rdbnom.Name = "rdbnom"
        Me.rdbnom.Size = New System.Drawing.Size(121, 17)
        Me.rdbnom.TabIndex = 0
        Me.rdbnom.TabStop = True
        Me.rdbnom.Text = "Buscar por Nombres"
        Me.rdbnom.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CboDocContacto)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.ChkCliente)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.labnroidentidad)
        Me.TabPage2.Controls.Add(Me.txtnrodocumento)
        Me.TabPage2.Controls.Add(Me.txtnomc)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(646, 257)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Contacto"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CboDocContacto
        '
        Me.CboDocContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocContacto.FormattingEnabled = True
        Me.CboDocContacto.Location = New System.Drawing.Point(71, 16)
        Me.CboDocContacto.Name = "CboDocContacto"
        Me.CboDocContacto.Size = New System.Drawing.Size(154, 21)
        Me.CboDocContacto.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Tipo Doc."
        '
        'ChkCliente
        '
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Location = New System.Drawing.Point(546, 18)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(84, 17)
        Me.ChkCliente.TabIndex = 2
        Me.ChkCliente.Text = "Es el Cliente"
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboMovil)
        Me.GroupBox1.Controls.Add(Me.txtemail)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtmovil)
        Me.GroupBox1.Controls.Add(Me.txtfijo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(628, 76)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comunicación"
        '
        'CboMovil
        '
        Me.CboMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMovil.FormattingEnabled = True
        Me.CboMovil.Location = New System.Drawing.Point(288, 46)
        Me.CboMovil.Name = "CboMovil"
        Me.CboMovil.Size = New System.Drawing.Size(157, 21)
        Me.CboMovil.TabIndex = 6
        '
        'txtemail
        '
        Me.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtemail.Location = New System.Drawing.Point(65, 20)
        Me.txtemail.MaxLength = 50
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(559, 20)
        Me.txtemail.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(451, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Móvil"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(226, 49)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Tipo Móvil"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(23, 13)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Fijo"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 13)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Email"
        '
        'txtmovil
        '
        Me.txtmovil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmovil.Enabled = False
        Me.txtmovil.Location = New System.Drawing.Point(489, 46)
        Me.txtmovil.MaxLength = 10
        Me.txtmovil.Name = "txtmovil"
        Me.txtmovil.Size = New System.Drawing.Size(135, 20)
        Me.txtmovil.TabIndex = 7
        '
        'txtfijo
        '
        Me.txtfijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfijo.Location = New System.Drawing.Point(65, 46)
        Me.txtfijo.MaxLength = 10
        Me.txtfijo.Name = "txtfijo"
        Me.txtfijo.Size = New System.Drawing.Size(152, 20)
        Me.txtfijo.TabIndex = 5
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(234, 20)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(45, 13)
        Me.labnroidentidad.TabIndex = 38
        Me.labnroidentidad.Text = "Nº Doc."
        '
        'txtnrodocumento
        '
        Me.txtnrodocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnrodocumento.Location = New System.Drawing.Point(296, 18)
        Me.txtnrodocumento.MaxLength = 11
        Me.txtnrodocumento.Name = "txtnrodocumento"
        Me.txtnrodocumento.Size = New System.Drawing.Size(157, 20)
        Me.txtnrodocumento.TabIndex = 1
        '
        'txtnomc
        '
        Me.txtnomc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomc.Location = New System.Drawing.Point(71, 42)
        Me.txtnomc.MaxLength = 100
        Me.txtnomc.Name = "txtnomc"
        Me.txtnomc.Size = New System.Drawing.Size(559, 20)
        Me.txtnomc.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(5, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Nombres"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnaceptar
        '
        Me.btnaceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnaceptar.Location = New System.Drawing.Point(497, 292)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnaceptar.TabIndex = 8
        Me.btnaceptar.Text = "&Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Location = New System.Drawing.Point(578, 292)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 27)
        Me.btncancelar.TabIndex = 9
        Me.btncancelar.Text = "&Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnNuevo.Location = New System.Drawing.Point(8, 292)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 27)
        Me.btnNuevo.TabIndex = 16
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'FrmContacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 325)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.TabDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmContacto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Contacto"
        Me.TabDatos.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DtgContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabDatos As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents DtgContacto As System.Windows.Forms.DataGridView
    Friend WithEvents BtnBuscarCont As System.Windows.Forms.Button
    Friend WithEvents rdbdoc As System.Windows.Forms.RadioButton
    Friend WithEvents txtcontacto As System.Windows.Forms.TextBox
    Friend WithEvents rdbnom As System.Windows.Forms.RadioButton
    Friend WithEvents txtnomc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
    Friend WithEvents txtnrodocumento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtmovil As System.Windows.Forms.TextBox
    Friend WithEvents txtfijo As System.Windows.Forms.TextBox
    Friend WithEvents ChkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents CboDocContacto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CboMovil As System.Windows.Forms.ComboBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
End Class
