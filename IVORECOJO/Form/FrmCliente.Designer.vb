<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCliente))
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabCliente = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtrazon = New System.Windows.Forms.TextBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.Dtgcliente = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.labnroidentidad = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.LblApep = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.txtapep = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.txtapem = New System.Windows.Forms.TextBox()
        Me.LblApeM = New System.Windows.Forms.Label()
        Me.CboTipoCliente = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtZona = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.txtManzana = New System.Windows.Forms.TextBox()
        Me.txtNumero2 = New System.Windows.Forms.TextBox()
        Me.txtClasificacion = New System.Windows.Forms.TextBox()
        Me.txtNivel = New System.Windows.Forms.TextBox()
        Me.txtVia = New System.Windows.Forms.TextBox()
        Me.cboClasificacion = New System.Windows.Forms.ComboBox()
        Me.cboZona = New System.Windows.Forms.ComboBox()
        Me.cboNivel = New System.Windows.Forms.ComboBox()
        Me.cboVia = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtrefllegada = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CboDistrito = New System.Windows.Forms.ComboBox()
        Me.CboProvincia = New System.Windows.Forms.ComboBox()
        Me.CboDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CboDocContacto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtmovil = New System.Windows.Forms.TextBox()
        Me.CboMovil = New System.Windows.Forms.ComboBox()
        Me.txtfijo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtnom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnrodocumento = New System.Windows.Forms.TextBox()
        Me.CboPais = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.TabCliente.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Dtgcliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(-98, 194)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 57
        Me.Label15.Text = "Teléfono Fijo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(-98, 170)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "Email"
        '
        'TabCliente
        '
        Me.TabCliente.Controls.Add(Me.TabPage1)
        Me.TabCliente.Controls.Add(Me.TabPage2)
        Me.TabCliente.Location = New System.Drawing.Point(0, 2)
        Me.TabCliente.Name = "TabCliente"
        Me.TabCliente.SelectedIndex = 0
        Me.TabCliente.Size = New System.Drawing.Size(660, 436)
        Me.TabCliente.TabIndex = 20
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtrazon)
        Me.TabPage1.Controls.Add(Me.BtnBuscar)
        Me.TabPage1.Controls.Add(Me.Dtgcliente)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(652, 414)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Buscar"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtrazon
        '
        Me.txtrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazon.Location = New System.Drawing.Point(56, 13)
        Me.txtrazon.MaxLength = 100
        Me.txtrazon.Name = "txtrazon"
        Me.txtrazon.Size = New System.Drawing.Size(517, 20)
        Me.txtrazon.TabIndex = 8
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscar.Enabled = False
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.Location = New System.Drawing.Point(579, 9)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(67, 27)
        Me.BtnBuscar.TabIndex = 7
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'Dtgcliente
        '
        Me.Dtgcliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dtgcliente.Location = New System.Drawing.Point(6, 46)
        Me.Dtgcliente.Name = "Dtgcliente"
        Me.Dtgcliente.Size = New System.Drawing.Size(640, 362)
        Me.Dtgcliente.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cliente"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.CboTipoCliente)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(652, 410)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cliente"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CboTipoDocumento)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.labnroidentidad)
        Me.GroupBox3.Controls.Add(Me.TxtNumero)
        Me.GroupBox3.Controls.Add(Me.LblApep)
        Me.GroupBox3.Controls.Add(Me.LblCliente)
        Me.GroupBox3.Controls.Add(Me.txtapep)
        Me.GroupBox3.Controls.Add(Me.TxtCliente)
        Me.GroupBox3.Controls.Add(Me.txtapem)
        Me.GroupBox3.Controls.Add(Me.LblApeM)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 36)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(636, 89)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cliente"
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Location = New System.Drawing.Point(75, 12)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(129, 21)
        Me.CboTipoDocumento.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "Tipo Doc."
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(334, 16)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(45, 13)
        Me.labnroidentidad.TabIndex = 76
        Me.labnroidentidad.Text = "Nº Doc."
        '
        'TxtNumero
        '
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Location = New System.Drawing.Point(415, 12)
        Me.TxtNumero.MaxLength = 11
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(117, 20)
        Me.TxtNumero.TabIndex = 2
        '
        'LblApep
        '
        Me.LblApep.AutoSize = True
        Me.LblApep.Location = New System.Drawing.Point(9, 67)
        Me.LblApep.Name = "LblApep"
        Me.LblApep.Size = New System.Drawing.Size(66, 13)
        Me.LblApep.TabIndex = 62
        Me.LblApep.Text = "Apellido Pat."
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(9, 41)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(63, 13)
        Me.LblCliente.TabIndex = 62
        Me.LblCliente.Text = "Razón Soc."
        '
        'txtapep
        '
        Me.txtapep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapep.Location = New System.Drawing.Point(75, 64)
        Me.txtapep.MaxLength = 50
        Me.txtapep.Name = "txtapep"
        Me.txtapep.Size = New System.Drawing.Size(210, 20)
        Me.txtapep.TabIndex = 4
        '
        'TxtCliente
        '
        Me.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCliente.Location = New System.Drawing.Point(75, 38)
        Me.TxtCliente.MaxLength = 80
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(551, 20)
        Me.TxtCliente.TabIndex = 3
        '
        'txtapem
        '
        Me.txtapem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapem.Location = New System.Drawing.Point(416, 64)
        Me.txtapem.MaxLength = 50
        Me.txtapem.Name = "txtapem"
        Me.txtapem.Size = New System.Drawing.Size(210, 20)
        Me.txtapem.TabIndex = 5
        '
        'LblApeM
        '
        Me.LblApeM.AutoSize = True
        Me.LblApeM.BackColor = System.Drawing.Color.Transparent
        Me.LblApeM.Location = New System.Drawing.Point(334, 67)
        Me.LblApeM.Name = "LblApeM"
        Me.LblApeM.Size = New System.Drawing.Size(68, 13)
        Me.LblApeM.TabIndex = 70
        Me.LblApeM.Text = "Apellido Mat."
        Me.LblApeM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboTipoCliente
        '
        Me.CboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCliente.DropDownWidth = 130
        Me.CboTipoCliente.FormattingEnabled = True
        Me.CboTipoCliente.Location = New System.Drawing.Point(84, 10)
        Me.CboTipoCliente.Name = "CboTipoCliente"
        Me.CboTipoCliente.Size = New System.Drawing.Size(129, 21)
        Me.CboTipoCliente.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Tipo Cliente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtZona)
        Me.GroupBox2.Controls.Add(Me.txtLote)
        Me.GroupBox2.Controls.Add(Me.txtManzana)
        Me.GroupBox2.Controls.Add(Me.txtNumero2)
        Me.GroupBox2.Controls.Add(Me.txtClasificacion)
        Me.GroupBox2.Controls.Add(Me.txtNivel)
        Me.GroupBox2.Controls.Add(Me.txtVia)
        Me.GroupBox2.Controls.Add(Me.cboClasificacion)
        Me.GroupBox2.Controls.Add(Me.cboZona)
        Me.GroupBox2.Controls.Add(Me.cboNivel)
        Me.GroupBox2.Controls.Add(Me.cboVia)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtrefllegada)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.CboDistrito)
        Me.GroupBox2.Controls.Add(Me.CboProvincia)
        Me.GroupBox2.Controls.Add(Me.CboDepartamento)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 258)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(634, 147)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dirección"
        '
        'txtZona
        '
        Me.txtZona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZona.Location = New System.Drawing.Point(244, 94)
        Me.txtZona.MaxLength = 50
        Me.txtZona.Name = "txtZona"
        Me.txtZona.ReadOnly = True
        Me.txtZona.Size = New System.Drawing.Size(127, 20)
        Me.txtZona.TabIndex = 152
        '
        'txtLote
        '
        Me.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLote.Location = New System.Drawing.Point(327, 69)
        Me.txtLote.MaxLength = 3
        Me.txtLote.Name = "txtLote"
        Me.txtLote.ReadOnly = True
        Me.txtLote.Size = New System.Drawing.Size(44, 20)
        Me.txtLote.TabIndex = 148
        '
        'txtManzana
        '
        Me.txtManzana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtManzana.Location = New System.Drawing.Point(244, 69)
        Me.txtManzana.MaxLength = 10
        Me.txtManzana.Name = "txtManzana"
        Me.txtManzana.ReadOnly = True
        Me.txtManzana.Size = New System.Drawing.Size(44, 20)
        Me.txtManzana.TabIndex = 147
        '
        'txtNumero2
        '
        Me.txtNumero2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero2.Location = New System.Drawing.Point(73, 67)
        Me.txtNumero2.MaxLength = 5
        Me.txtNumero2.Name = "txtNumero2"
        Me.txtNumero2.ReadOnly = True
        Me.txtNumero2.Size = New System.Drawing.Size(126, 20)
        Me.txtNumero2.TabIndex = 146
        '
        'txtClasificacion
        '
        Me.txtClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClasificacion.Location = New System.Drawing.Point(548, 94)
        Me.txtClasificacion.MaxLength = 50
        Me.txtClasificacion.Name = "txtClasificacion"
        Me.txtClasificacion.ReadOnly = True
        Me.txtClasificacion.Size = New System.Drawing.Size(77, 20)
        Me.txtClasificacion.TabIndex = 154
        '
        'txtNivel
        '
        Me.txtNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNivel.Location = New System.Drawing.Point(548, 70)
        Me.txtNivel.MaxLength = 50
        Me.txtNivel.Name = "txtNivel"
        Me.txtNivel.ReadOnly = True
        Me.txtNivel.Size = New System.Drawing.Size(77, 20)
        Me.txtNivel.TabIndex = 150
        '
        'txtVia
        '
        Me.txtVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVia.Location = New System.Drawing.Point(244, 41)
        Me.txtVia.MaxLength = 50
        Me.txtVia.Name = "txtVia"
        Me.txtVia.ReadOnly = True
        Me.txtVia.Size = New System.Drawing.Size(127, 20)
        Me.txtVia.TabIndex = 145
        '
        'cboClasificacion
        '
        Me.cboClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClasificacion.Enabled = False
        Me.cboClasificacion.FormattingEnabled = True
        Me.cboClasificacion.Location = New System.Drawing.Point(413, 94)
        Me.cboClasificacion.Name = "cboClasificacion"
        Me.cboClasificacion.Size = New System.Drawing.Size(127, 21)
        Me.cboClasificacion.TabIndex = 153
        '
        'cboZona
        '
        Me.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZona.DropDownWidth = 150
        Me.cboZona.Enabled = False
        Me.cboZona.FormattingEnabled = True
        Me.cboZona.Location = New System.Drawing.Point(73, 93)
        Me.cboZona.Name = "cboZona"
        Me.cboZona.Size = New System.Drawing.Size(127, 21)
        Me.cboZona.TabIndex = 151
        '
        'cboNivel
        '
        Me.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNivel.Enabled = False
        Me.cboNivel.FormattingEnabled = True
        Me.cboNivel.Location = New System.Drawing.Point(413, 69)
        Me.cboNivel.Name = "cboNivel"
        Me.cboNivel.Size = New System.Drawing.Size(127, 21)
        Me.cboNivel.TabIndex = 149
        '
        'cboVia
        '
        Me.cboVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVia.DropDownWidth = 127
        Me.cboVia.Enabled = False
        Me.cboVia.FormattingEnabled = True
        Me.cboVia.Location = New System.Drawing.Point(73, 41)
        Me.cboVia.Name = "cboVia"
        Me.cboVia.Size = New System.Drawing.Size(127, 21)
        Me.cboVia.TabIndex = 144
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 13)
        Me.Label10.TabIndex = 159
        Me.Label10.Text = "Nº"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(295, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(19, 13)
        Me.Label16.TabIndex = 158
        Me.Label16.Text = "Lt."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 94)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 157
        Me.Label17.Text = "Zona"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(206, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 155
        Me.Label12.Text = "Mz."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 13)
        Me.Label22.TabIndex = 156
        Me.Label22.Text = "Vía"
        '
        'txtrefllegada
        '
        Me.txtrefllegada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrefllegada.Location = New System.Drawing.Point(73, 120)
        Me.txtrefllegada.MaxLength = 100
        Me.txtrefllegada.Name = "txtrefllegada"
        Me.txtrefllegada.Size = New System.Drawing.Size(551, 20)
        Me.txtrefllegada.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 123)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 113
        Me.Label13.Text = "Referencia"
        '
        'CboDistrito
        '
        Me.CboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDistrito.FormattingEnabled = True
        Me.CboDistrito.Location = New System.Drawing.Point(413, 15)
        Me.CboDistrito.Name = "CboDistrito"
        Me.CboDistrito.Size = New System.Drawing.Size(211, 21)
        Me.CboDistrito.TabIndex = 17
        '
        'CboProvincia
        '
        Me.CboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProvincia.FormattingEnabled = True
        Me.CboProvincia.Location = New System.Drawing.Point(244, 15)
        Me.CboProvincia.Name = "CboProvincia"
        Me.CboProvincia.Size = New System.Drawing.Size(126, 21)
        Me.CboProvincia.TabIndex = 16
        '
        'CboDepartamento
        '
        Me.CboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDepartamento.FormattingEnabled = True
        Me.CboDepartamento.Location = New System.Drawing.Point(73, 15)
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.Size = New System.Drawing.Size(126, 21)
        Me.CboDepartamento.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(383, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Dist."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Dpto."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(206, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Prov."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboDocContacto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ChkCliente)
        Me.GroupBox1.Controls.Add(Me.txtemail)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtmovil)
        Me.GroupBox1.Controls.Add(Me.CboMovil)
        Me.GroupBox1.Controls.Add(Me.txtfijo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtnom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtnrodocumento)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(636, 118)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contacto"
        '
        'CboDocContacto
        '
        Me.CboDocContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocContacto.FormattingEnabled = True
        Me.CboDocContacto.Location = New System.Drawing.Point(76, 12)
        Me.CboDocContacto.Name = "CboDocContacto"
        Me.CboDocContacto.Size = New System.Drawing.Size(129, 21)
        Me.CboDocContacto.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Tipo Doc."
        '
        'ChkCliente
        '
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Location = New System.Drawing.Point(481, 14)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(84, 17)
        Me.ChkCliente.TabIndex = 6
        Me.ChkCliente.Text = "Es el Cliente"
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'txtemail
        '
        Me.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtemail.Location = New System.Drawing.Point(75, 64)
        Me.txtemail.MaxLength = 40
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(551, 20)
        Me.txtemail.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(475, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Móvil"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(208, 94)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "Tipo Móvil"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 94)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(23, 13)
        Me.Label20.TabIndex = 79
        Me.Label20.Text = "Fijo"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 68)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 13)
        Me.Label21.TabIndex = 78
        Me.Label21.Text = "Email"
        '
        'txtmovil
        '
        Me.txtmovil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmovil.Enabled = False
        Me.txtmovil.Location = New System.Drawing.Point(509, 90)
        Me.txtmovil.MaxLength = 15
        Me.txtmovil.Name = "txtmovil"
        Me.txtmovil.Size = New System.Drawing.Size(117, 20)
        Me.txtmovil.TabIndex = 13
        '
        'CboMovil
        '
        Me.CboMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMovil.FormattingEnabled = True
        Me.CboMovil.Location = New System.Drawing.Point(268, 90)
        Me.CboMovil.Name = "CboMovil"
        Me.CboMovil.Size = New System.Drawing.Size(177, 21)
        Me.CboMovil.TabIndex = 12
        '
        'txtfijo
        '
        Me.txtfijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfijo.Location = New System.Drawing.Point(75, 90)
        Me.txtfijo.MaxLength = 15
        Me.txtfijo.Name = "txtfijo"
        Me.txtfijo.Size = New System.Drawing.Size(127, 20)
        Me.txtfijo.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(9, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Nombres"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtnom
        '
        Me.txtnom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnom.Location = New System.Drawing.Point(75, 38)
        Me.txtnom.MaxLength = 100
        Me.txtnom.Name = "txtnom"
        Me.txtnom.Size = New System.Drawing.Size(551, 20)
        Me.txtnom.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Nº Doc."
        '
        'txtnrodocumento
        '
        Me.txtnrodocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnrodocumento.Location = New System.Drawing.Point(268, 12)
        Me.txtnrodocumento.MaxLength = 11
        Me.txtnrodocumento.Name = "txtnrodocumento"
        Me.txtnrodocumento.Size = New System.Drawing.Size(177, 20)
        Me.txtnrodocumento.TabIndex = 8
        '
        'CboPais
        '
        Me.CboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPais.FormattingEnabled = True
        Me.CboPais.Location = New System.Drawing.Point(182, 486)
        Me.CboPais.Name = "CboPais"
        Me.CboPais.Size = New System.Drawing.Size(182, 21)
        Me.CboPais.TabIndex = 14
        Me.CboPais.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(130, 490)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "País"
        Me.Label9.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(580, 441)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(76, 26)
        Me.BtnCancelar.TabIndex = 21
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnGrabar
        '
        Me.BtnGrabar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(498, 441)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(77, 26)
        Me.BtnGrabar.TabIndex = 20
        Me.BtnGrabar.Text = "&Aceptar"
        Me.BtnGrabar.UseVisualStyleBackColor = True
        '
        'FrmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 475)
        Me.Controls.Add(Me.TabCliente)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGrabar)
        Me.Controls.Add(Me.CboPais)
        Me.Controls.Add(Me.Label9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente"
        Me.TabCliente.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.Dtgcliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabCliente As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents Dtgcliente As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents LblApep As System.Windows.Forms.Label
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents txtapep As System.Windows.Forms.TextBox
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnrodocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtnom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtmovil As System.Windows.Forms.TextBox
    Friend WithEvents CboMovil As System.Windows.Forms.ComboBox
    Friend WithEvents txtfijo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents CboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents CboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents CboPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtrefllegada As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtapem As System.Windows.Forms.TextBox
    Friend WithEvents LblApeM As System.Windows.Forms.Label
    Friend WithEvents ChkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents CboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtrazon As System.Windows.Forms.TextBox
    Friend WithEvents CboTipoCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboDocContacto As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtZona As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtManzana As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero2 As System.Windows.Forms.TextBox
    Friend WithEvents txtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents txtNivel As System.Windows.Forms.TextBox
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents cboClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents cboZona As System.Windows.Forms.ComboBox
    Friend WithEvents cboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents cboVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
