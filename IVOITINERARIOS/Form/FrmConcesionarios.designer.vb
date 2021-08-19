<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConcesionarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConcesionarios))
        Me.TxtID = New System.Windows.Forms.TextBox
        Me.TxtNomEmp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtNomCorto = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtNomCon = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtApePat = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtApeMat = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtCelular = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtRPM = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtFax = New System.Windows.Forms.TextBox
        Me.DataGridAge1 = New System.Windows.Forms.DataGridView
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.CbDist = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.CbProv = New System.Windows.Forms.ComboBox
        Me.CbDepar = New System.Windows.Forms.ComboBox
        Me.CbPais = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtRUC = New System.Windows.Forms.MaskedTextBox
        Me.DataGridAge2 = New System.Windows.Forms.DataGridView
        Me.BtAgregar = New System.Windows.Forms.Button
        Me.BtSacar = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.CbUnidad = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtConcesion = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.CbEstado = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.CbStatus = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DataGridViewLista = New System.Windows.Forms.DataGridView
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridAge1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridAge2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabMante.Size = New System.Drawing.Size(544, 498)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.DataGridViewLista)
        Me.TabLista.Controls.Add(Me.Label21)
        Me.TabLista.Controls.Add(Me.CbEstado)
        Me.TabLista.Size = New System.Drawing.Size(536, 469)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CbEstado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label21, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridViewLista, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.Label22)
        Me.TabDatos.Controls.Add(Me.CbStatus)
        Me.TabDatos.Controls.Add(Me.TxtRUC)
        Me.TabDatos.Controls.Add(Me.Label19)
        Me.TabDatos.Controls.Add(Me.Label18)
        Me.TabDatos.Controls.Add(Me.Label17)
        Me.TabDatos.Controls.Add(Me.CbDist)
        Me.TabDatos.Controls.Add(Me.Label16)
        Me.TabDatos.Controls.Add(Me.CbProv)
        Me.TabDatos.Controls.Add(Me.CbDepar)
        Me.TabDatos.Controls.Add(Me.CbPais)
        Me.TabDatos.Controls.Add(Me.Label12)
        Me.TabDatos.Controls.Add(Me.TxtRPM)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.TxtFax)
        Me.TabDatos.Controls.Add(Me.Label10)
        Me.TabDatos.Controls.Add(Me.TxtCelular)
        Me.TabDatos.Controls.Add(Me.Label11)
        Me.TabDatos.Controls.Add(Me.TxtTelefono)
        Me.TabDatos.Controls.Add(Me.Label9)
        Me.TabDatos.Controls.Add(Me.TxtDireccion)
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.TxtNomCon)
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.TxtApePat)
        Me.TabDatos.Controls.Add(Me.Label6)
        Me.TabDatos.Controls.Add(Me.TxtApeMat)
        Me.TabDatos.Controls.Add(Me.Label5)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Controls.Add(Me.TxtNomCorto)
        Me.TabDatos.Controls.Add(Me.Label3)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.TxtNomEmp)
        Me.TabDatos.Controls.Add(Me.TxtID)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Size = New System.Drawing.Size(536, 469)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtID, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomEmp, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomCorto, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtApeMat, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtApePat, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomCon, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtDireccion, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtTelefono, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label11, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtCelular, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtFax, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label13, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtRPM, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbPais, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbDepar, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbProv, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label16, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbDist, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label17, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label18, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label19, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtRUC, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtMensaje, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbStatus, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label22, 0)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridLista.Location = New System.Drawing.Point(255, 151)
        Me.DataGridLista.Size = New System.Drawing.Size(54, 53)
        '
        'TxtBusca
        '
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TxtConcesion)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.CbUnidad)
        Me.TabPage1.Controls.Add(Me.BtSacar)
        Me.TabPage1.Controls.Add(Me.BtAgregar)
        Me.TabPage1.Controls.Add(Me.DataGridAge2)
        Me.TabPage1.Controls.Add(Me.DataGridAge1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.Size = New System.Drawing.Size(536, 469)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(536, 469)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'TxtID
        '
        Me.TxtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtID.Enabled = False
        Me.TxtID.Location = New System.Drawing.Point(204, 51)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(55, 20)
        Me.TxtID.TabIndex = 0
        Me.TxtID.Visible = False
        '
        'TxtNomEmp
        '
        Me.TxtNomEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomEmp.Location = New System.Drawing.Point(204, 87)
        Me.TxtNomEmp.Name = "TxtNomEmp"
        Me.TxtNomEmp.Size = New System.Drawing.Size(305, 20)
        Me.TxtNomEmp.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(62, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ID"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(62, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre Empresa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(62, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Nombre Corto"
        '
        'TxtNomCorto
        '
        Me.TxtNomCorto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomCorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomCorto.Location = New System.Drawing.Point(204, 117)
        Me.TxtNomCorto.Name = "TxtNomCorto"
        Me.TxtNomCorto.Size = New System.Drawing.Size(99, 20)
        Me.TxtNomCorto.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(62, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "RUC"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(62, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Nombre Contacto"
        '
        'TxtNomCon
        '
        Me.TxtNomCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomCon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomCon.Location = New System.Drawing.Point(204, 237)
        Me.TxtNomCon.Name = "TxtNomCon"
        Me.TxtNomCon.Size = New System.Drawing.Size(305, 20)
        Me.TxtNomCon.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(62, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Apellido Paterno Contacto"
        '
        'TxtApePat
        '
        Me.TxtApePat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApePat.Location = New System.Drawing.Point(204, 177)
        Me.TxtApePat.Name = "TxtApePat"
        Me.TxtApePat.Size = New System.Drawing.Size(305, 20)
        Me.TxtApePat.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(62, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Apellido Materno Contacto"
        '
        'TxtApeMat
        '
        Me.TxtApeMat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApeMat.Location = New System.Drawing.Point(204, 207)
        Me.TxtApeMat.Name = "TxtApeMat"
        Me.TxtApeMat.Size = New System.Drawing.Size(305, 20)
        Me.TxtApeMat.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(62, 270)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Direccion"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDireccion.Location = New System.Drawing.Point(204, 267)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(305, 20)
        Me.TxtDireccion.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(348, 300)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Celular"
        '
        'TxtCelular
        '
        Me.TxtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCelular.Location = New System.Drawing.Point(428, 297)
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.Size = New System.Drawing.Size(81, 20)
        Me.TxtCelular.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(62, 300)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Telefono"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTelefono.Location = New System.Drawing.Point(204, 297)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(81, 20)
        Me.TxtTelefono.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(348, 331)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "RPM"
        '
        'TxtRPM
        '
        Me.TxtRPM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRPM.Location = New System.Drawing.Point(428, 328)
        Me.TxtRPM.Name = "TxtRPM"
        Me.TxtRPM.Size = New System.Drawing.Size(81, 20)
        Me.TxtRPM.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(62, 331)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Fax"
        '
        'TxtFax
        '
        Me.TxtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFax.Location = New System.Drawing.Point(204, 328)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(81, 20)
        Me.TxtFax.TabIndex = 10
        '
        'DataGridAge1
        '
        Me.DataGridAge1.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridAge1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridAge1.Location = New System.Drawing.Point(30, 96)
        Me.DataGridAge1.Name = "DataGridAge1"
        Me.DataGridAge1.Size = New System.Drawing.Size(192, 323)
        Me.DataGridAge1.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(303, 407)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Distrito"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(303, 383)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Provincia"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(73, 404)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Departamento"
        '
        'CbDist
        '
        Me.CbDist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDist.FormattingEnabled = True
        Me.CbDist.Location = New System.Drawing.Point(361, 404)
        Me.CbDist.Name = "CbDist"
        Me.CbDist.Size = New System.Drawing.Size(135, 21)
        Me.CbDist.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(73, 378)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Pais"
        '
        'CbProv
        '
        Me.CbProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbProv.FormattingEnabled = True
        Me.CbProv.Location = New System.Drawing.Point(361, 380)
        Me.CbProv.Name = "CbProv"
        Me.CbProv.Size = New System.Drawing.Size(135, 21)
        Me.CbProv.TabIndex = 14
        '
        'CbDepar
        '
        Me.CbDepar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDepar.FormattingEnabled = True
        Me.CbDepar.Location = New System.Drawing.Point(153, 401)
        Me.CbDepar.Name = "CbDepar"
        Me.CbDepar.Size = New System.Drawing.Size(135, 21)
        Me.CbDepar.TabIndex = 13
        '
        'CbPais
        '
        Me.CbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPais.FormattingEnabled = True
        Me.CbPais.Location = New System.Drawing.Point(153, 377)
        Me.CbPais.Name = "CbPais"
        Me.CbPais.Size = New System.Drawing.Size(135, 21)
        Me.CbPais.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(65, 359)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 75)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        '
        'TxtRUC
        '
        Me.TxtRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRUC.Location = New System.Drawing.Point(204, 148)
        Me.TxtRUC.Mask = "###########"
        Me.TxtRUC.Name = "TxtRUC"
        Me.TxtRUC.Size = New System.Drawing.Size(74, 20)
        Me.TxtRUC.TabIndex = 3
        '
        'DataGridAge2
        '
        Me.DataGridAge2.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridAge2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridAge2.Location = New System.Drawing.Point(321, 96)
        Me.DataGridAge2.Name = "DataGridAge2"
        Me.DataGridAge2.Size = New System.Drawing.Size(192, 323)
        Me.DataGridAge2.TabIndex = 1
        '
        'BtAgregar
        '
        Me.BtAgregar.Image = CType(resources.GetObject("BtAgregar.Image"), System.Drawing.Image)
        Me.BtAgregar.Location = New System.Drawing.Point(254, 188)
        Me.BtAgregar.Name = "BtAgregar"
        Me.BtAgregar.Size = New System.Drawing.Size(38, 33)
        Me.BtAgregar.TabIndex = 2
        Me.BtAgregar.UseVisualStyleBackColor = True
        '
        'BtSacar
        '
        Me.BtSacar.Image = CType(resources.GetObject("BtSacar.Image"), System.Drawing.Image)
        Me.BtSacar.Location = New System.Drawing.Point(254, 277)
        Me.BtSacar.Name = "BtSacar"
        Me.BtSacar.Size = New System.Drawing.Size(38, 33)
        Me.BtSacar.TabIndex = 3
        Me.BtSacar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(34, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Ciudad"
        '
        'CbUnidad
        '
        Me.CbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbUnidad.FormattingEnabled = True
        Me.CbUnidad.Location = New System.Drawing.Point(83, 53)
        Me.CbUnidad.Name = "CbUnidad"
        Me.CbUnidad.Size = New System.Drawing.Size(139, 21)
        Me.CbUnidad.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(30, 420)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 25)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Marcar Todos"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtConcesion
        '
        Me.TxtConcesion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtConcesion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConcesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConcesion.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.TxtConcesion.Location = New System.Drawing.Point(30, 18)
        Me.TxtConcesion.Name = "TxtConcesion"
        Me.TxtConcesion.ReadOnly = True
        Me.TxtConcesion.Size = New System.Drawing.Size(483, 20)
        Me.TxtConcesion.TabIndex = 9
        Me.TxtConcesion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(337, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Estado"
        '
        'CbEstado
        '
        Me.CbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEstado.FormattingEnabled = True
        Me.CbEstado.Location = New System.Drawing.Point(394, 34)
        Me.CbEstado.Name = "CbEstado"
        Me.CbEstado.Size = New System.Drawing.Size(121, 21)
        Me.CbEstado.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(331, 150)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 46
        Me.Label22.Text = "Estado"
        '
        'CbStatus
        '
        Me.CbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbStatus.FormattingEnabled = True
        Me.CbStatus.Location = New System.Drawing.Point(388, 147)
        Me.CbStatus.Name = "CbStatus"
        Me.CbStatus.Size = New System.Drawing.Size(121, 21)
        Me.CbStatus.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(24, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(203, 343)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agencias Disponibles"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(316, 81)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(201, 343)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Agencias Asociadas"
        '
        'DataGridViewLista
        '
        Me.DataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLista.Location = New System.Drawing.Point(21, 77)
        Me.DataGridViewLista.Name = "DataGridViewLista"
        Me.DataGridViewLista.Size = New System.Drawing.Size(494, 365)
        Me.DataGridViewLista.TabIndex = 14
        '
        'FrmConcesionarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "FrmConcesionarios"
        Me.Text = "FrmConcesionarios"
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridAge1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridAge2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNomCorto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNomCon As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtApePat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtApeMat As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtRPM As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtFax As System.Windows.Forms.TextBox
    Friend WithEvents DataGridAge1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CbDist As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CbProv As System.Windows.Forms.ComboBox
    Friend WithEvents CbDepar As System.Windows.Forms.ComboBox
    Friend WithEvents CbPais As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRUC As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DataGridAge2 As System.Windows.Forms.DataGridView
    Friend WithEvents BtAgregar As System.Windows.Forms.Button
    Friend WithEvents BtSacar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtConcesion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewLista As System.Windows.Forms.DataGridView
End Class
