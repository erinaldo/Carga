<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgencias
    Inherits INTEGRACION.FrmFormBase
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
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.TxtNomAgencia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbUnidad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNomCorto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtApeMat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtApePat = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtNomCon = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtTele1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtTele2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtFax2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtFax1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtRPM2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtRPM1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtEMail = New System.Windows.Forms.TextBox()
        Me.CbPais = New System.Windows.Forms.ComboBox()
        Me.CbDepar = New System.Windows.Forms.ComboBox()
        Me.CbProv = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CbDist = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtCelular = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CbEstado = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.CbStatus = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.DataGridViewLista = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_tipo_agencia = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboPortavalor = New System.Windows.Forms.ComboBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(546, 503)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(544, 499)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.DataGridViewLista)
        Me.TabLista.Controls.Add(Me.Label23)
        Me.TabLista.Controls.Add(Me.Label21)
        Me.TabLista.Controls.Add(Me.CbEstado)
        Me.TabLista.Size = New System.Drawing.Size(536, 470)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CbEstado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label21, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label23, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridViewLista, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.cboPortavalor)
        Me.TabDatos.Controls.Add(Me.cmb_tipo_agencia)
        Me.TabDatos.Controls.Add(Me.Label24)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.Label22)
        Me.TabDatos.Controls.Add(Me.CbStatus)
        Me.TabDatos.Controls.Add(Me.Label20)
        Me.TabDatos.Controls.Add(Me.TxtCelular)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.TxtDireccion)
        Me.TabDatos.Controls.Add(Me.Label19)
        Me.TabDatos.Controls.Add(Me.Label18)
        Me.TabDatos.Controls.Add(Me.Label17)
        Me.TabDatos.Controls.Add(Me.CbDist)
        Me.TabDatos.Controls.Add(Me.Label16)
        Me.TabDatos.Controls.Add(Me.CbProv)
        Me.TabDatos.Controls.Add(Me.CbDepar)
        Me.TabDatos.Controls.Add(Me.CbPais)
        Me.TabDatos.Controls.Add(Me.Label15)
        Me.TabDatos.Controls.Add(Me.TxtEMail)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.TxtRPM2)
        Me.TabDatos.Controls.Add(Me.Label14)
        Me.TabDatos.Controls.Add(Me.TxtRPM1)
        Me.TabDatos.Controls.Add(Me.Label11)
        Me.TabDatos.Controls.Add(Me.TxtFax2)
        Me.TabDatos.Controls.Add(Me.Label12)
        Me.TabDatos.Controls.Add(Me.TxtFax1)
        Me.TabDatos.Controls.Add(Me.Label10)
        Me.TabDatos.Controls.Add(Me.TxtTele2)
        Me.TabDatos.Controls.Add(Me.Label9)
        Me.TabDatos.Controls.Add(Me.TxtTele1)
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.TxtNomCon)
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.TxtApePat)
        Me.TabDatos.Controls.Add(Me.Label6)
        Me.TabDatos.Controls.Add(Me.TxtApeMat)
        Me.TabDatos.Controls.Add(Me.Label5)
        Me.TabDatos.Controls.Add(Me.txtNomCorto)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Controls.Add(Me.CbUnidad)
        Me.TabDatos.Controls.Add(Me.Label3)
        Me.TabDatos.Controls.Add(Me.TxtNomAgencia)
        Me.TabDatos.Controls.Add(Me.TxtID)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Size = New System.Drawing.Size(536, 470)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtID, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomAgencia, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbUnidad, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.txtNomCorto, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtApeMat, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtApePat, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomCon, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtTele1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtTele2, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtFax1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtFax2, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label11, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtRPM1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtRPM2, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label13, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtEMail, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label15, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbPais, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbDepar, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbProv, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label16, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbDist, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label17, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label18, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label19, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtDireccion, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtCelular, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label20, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbStatus, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label22, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label24, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.cmb_tipo_agencia, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtMensaje, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.cboPortavalor, 0)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridLista.Location = New System.Drawing.Point(232, 191)
        Me.DataGridLista.Size = New System.Drawing.Size(48, 47)
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(83, 34)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(536, 470)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(536, 470)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        Me.TreeLista.Size = New System.Drawing.Size(173, 482)
        '
        'TxtMensaje
        '
        Me.TxtMensaje.Location = New System.Drawing.Point(427, 8)
        '
        'TxtID
        '
        Me.TxtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtID.Enabled = False
        Me.TxtID.Location = New System.Drawing.Point(437, 32)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(42, 20)
        Me.TxtID.TabIndex = 0
        Me.TxtID.Visible = False
        '
        'TxtNomAgencia
        '
        Me.TxtNomAgencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomAgencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomAgencia.Location = New System.Drawing.Point(175, 52)
        Me.TxtNomAgencia.Name = "TxtNomAgencia"
        Me.TxtNomAgencia.Size = New System.Drawing.Size(305, 20)
        Me.TxtNomAgencia.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(33, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre de Agencia"
        '
        'CbUnidad
        '
        Me.CbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbUnidad.FormattingEnabled = True
        Me.CbUnidad.Location = New System.Drawing.Point(341, 82)
        Me.CbUnidad.Name = "CbUnidad"
        Me.CbUnidad.Size = New System.Drawing.Size(139, 21)
        Me.CbUnidad.Sorted = True
        Me.CbUnidad.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(292, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Ciudad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(33, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Nombre Corto"
        '
        'txtNomCorto
        '
        Me.txtNomCorto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomCorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomCorto.Location = New System.Drawing.Point(175, 82)
        Me.txtNomCorto.Name = "txtNomCorto"
        Me.txtNomCorto.Size = New System.Drawing.Size(81, 20)
        Me.txtNomCorto.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(33, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Apellido Materno Contacto"
        '
        'TxtApeMat
        '
        Me.TxtApeMat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApeMat.Location = New System.Drawing.Point(175, 171)
        Me.TxtApeMat.Name = "TxtApeMat"
        Me.TxtApeMat.Size = New System.Drawing.Size(305, 20)
        Me.TxtApeMat.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(33, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Apellido Paterno Contacto"
        '
        'TxtApePat
        '
        Me.TxtApePat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApePat.Location = New System.Drawing.Point(175, 140)
        Me.TxtApePat.Name = "TxtApePat"
        Me.TxtApePat.Size = New System.Drawing.Size(305, 20)
        Me.TxtApePat.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(33, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Nombre Contacto"
        '
        'TxtNomCon
        '
        Me.TxtNomCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomCon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomCon.Location = New System.Drawing.Point(175, 201)
        Me.TxtNomCon.Name = "TxtNomCon"
        Me.TxtNomCon.Size = New System.Drawing.Size(134, 20)
        Me.TxtNomCon.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(33, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Telefono (1)"
        '
        'TxtTele1
        '
        Me.TxtTele1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTele1.Location = New System.Drawing.Point(175, 229)
        Me.TxtTele1.Name = "TxtTele1"
        Me.TxtTele1.Size = New System.Drawing.Size(81, 20)
        Me.TxtTele1.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(319, 232)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Telefono (2)"
        '
        'TxtTele2
        '
        Me.TxtTele2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTele2.Location = New System.Drawing.Point(399, 229)
        Me.TxtTele2.Name = "TxtTele2"
        Me.TxtTele2.Size = New System.Drawing.Size(81, 20)
        Me.TxtTele2.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(319, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Fax (2)"
        '
        'TxtFax2
        '
        Me.TxtFax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFax2.Location = New System.Drawing.Point(399, 255)
        Me.TxtFax2.Name = "TxtFax2"
        Me.TxtFax2.Size = New System.Drawing.Size(81, 20)
        Me.TxtFax2.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(33, 256)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Fax (1)"
        '
        'TxtFax1
        '
        Me.TxtFax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFax1.Location = New System.Drawing.Point(175, 255)
        Me.TxtFax1.Name = "TxtFax1"
        Me.TxtFax1.Size = New System.Drawing.Size(81, 20)
        Me.TxtFax1.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(319, 284)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "RPM (2)"
        '
        'TxtRPM2
        '
        Me.TxtRPM2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRPM2.Location = New System.Drawing.Point(399, 281)
        Me.TxtRPM2.Name = "TxtRPM2"
        Me.TxtRPM2.Size = New System.Drawing.Size(81, 20)
        Me.TxtRPM2.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(33, 282)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "RPM (1)"
        '
        'TxtRPM1
        '
        Me.TxtRPM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRPM1.Location = New System.Drawing.Point(175, 281)
        Me.TxtRPM1.Name = "TxtRPM1"
        Me.TxtRPM1.Size = New System.Drawing.Size(81, 20)
        Me.TxtRPM1.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(33, 310)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "E_Mail"
        '
        'TxtEMail
        '
        Me.TxtEMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEMail.Location = New System.Drawing.Point(175, 309)
        Me.TxtEMail.Name = "TxtEMail"
        Me.TxtEMail.Size = New System.Drawing.Size(304, 20)
        Me.TxtEMail.TabIndex = 16
        '
        'CbPais
        '
        Me.CbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPais.FormattingEnabled = True
        Me.CbPais.Location = New System.Drawing.Point(128, 401)
        Me.CbPais.Name = "CbPais"
        Me.CbPais.Size = New System.Drawing.Size(135, 21)
        Me.CbPais.TabIndex = 19
        '
        'CbDepar
        '
        Me.CbDepar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDepar.FormattingEnabled = True
        Me.CbDepar.Location = New System.Drawing.Point(128, 425)
        Me.CbDepar.Name = "CbDepar"
        Me.CbDepar.Size = New System.Drawing.Size(135, 21)
        Me.CbDepar.TabIndex = 20
        '
        'CbProv
        '
        Me.CbProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbProv.FormattingEnabled = True
        Me.CbProv.Location = New System.Drawing.Point(336, 404)
        Me.CbProv.Name = "CbProv"
        Me.CbProv.Size = New System.Drawing.Size(135, 21)
        Me.CbProv.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(48, 402)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Pais"
        '
        'CbDist
        '
        Me.CbDist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDist.FormattingEnabled = True
        Me.CbDist.Location = New System.Drawing.Point(336, 428)
        Me.CbDist.Name = "CbDist"
        Me.CbDist.Size = New System.Drawing.Size(135, 21)
        Me.CbDist.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(48, 428)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Departamento"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(278, 407)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Provincia"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(278, 431)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "Distrito"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(32, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Direccion"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDireccion.Location = New System.Drawing.Point(174, 111)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(305, 20)
        Me.TxtDireccion.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(319, 206)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Celular"
        '
        'TxtCelular
        '
        Me.TxtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCelular.Location = New System.Drawing.Point(399, 203)
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.Size = New System.Drawing.Size(81, 20)
        Me.TxtCelular.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(35, 389)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 66)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(337, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Estado"
        '
        'CbEstado
        '
        Me.CbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEstado.FormattingEnabled = True
        Me.CbEstado.Location = New System.Drawing.Point(394, 34)
        Me.CbEstado.Name = "CbEstado"
        Me.CbEstado.Size = New System.Drawing.Size(121, 21)
        Me.CbEstado.TabIndex = 10
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(302, 339)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 43
        Me.Label22.Text = "Estado"
        '
        'CbStatus
        '
        Me.CbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbStatus.FormattingEnabled = True
        Me.CbStatus.Location = New System.Drawing.Point(359, 335)
        Me.CbStatus.Name = "CbStatus"
        Me.CbStatus.Size = New System.Drawing.Size(121, 21)
        Me.CbStatus.TabIndex = 18
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(18, 37)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Buscar"
        '
        'DataGridViewLista
        '
        Me.DataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLista.Location = New System.Drawing.Point(21, 69)
        Me.DataGridViewLista.Name = "DataGridViewLista"
        Me.DataGridViewLista.Size = New System.Drawing.Size(494, 374)
        Me.DataGridViewLista.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(33, 339)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Tipo agencia "
        '
        'cmb_tipo_agencia
        '
        Me.cmb_tipo_agencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_agencia.FormattingEnabled = True
        Me.cmb_tipo_agencia.Location = New System.Drawing.Point(174, 335)
        Me.cmb_tipo_agencia.Name = "cmb_tipo_agencia"
        Me.cmb_tipo_agencia.Size = New System.Drawing.Size(121, 21)
        Me.cmb_tipo_agencia.TabIndex = 17
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(33, 366)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(55, 13)
        Me.Label24.TabIndex = 44
        Me.Label24.Text = "Portavalor"
        '
        'cboPortavalor
        '
        Me.cboPortavalor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPortavalor.FormattingEnabled = True
        Me.cboPortavalor.Items.AddRange(New Object() {"(SELECCIONE)", "EXTERNO", "INTERNO"})
        Me.cboPortavalor.Location = New System.Drawing.Point(175, 362)
        Me.cboPortavalor.Name = "cboPortavalor"
        Me.cboPortavalor.Size = New System.Drawing.Size(121, 21)
        Me.cboPortavalor.TabIndex = 45
        '
        'FrmAgencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "FrmAgencias"
        Me.Text = "FrmAgencias"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNomAgencia As System.Windows.Forms.TextBox
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNomCorto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNomCon As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtApePat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtApeMat As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTele2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTele1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtRPM2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtRPM1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtFax2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtFax1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtEMail As System.Windows.Forms.TextBox
    Friend WithEvents CbDepar As System.Windows.Forms.ComboBox
    Friend WithEvents CbPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CbDist As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CbProv As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtCelular As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewLista As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_tipo_agencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPortavalor As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
