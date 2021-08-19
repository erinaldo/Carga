<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCliente2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCliente2))
        Me.TabCliente = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LblBuscar = New System.Windows.Forms.Label()
        Me.txtrazon = New System.Windows.Forms.TextBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.dgvBuscar = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrbContacto = New System.Windows.Forms.GroupBox()
        Me.LblAPContacto = New System.Windows.Forms.Label()
        Me.TxtAPContacto = New System.Windows.Forms.TextBox()
        Me.TxtAMContacto = New System.Windows.Forms.TextBox()
        Me.LblAMContacto = New System.Windows.Forms.Label()
        Me.CboDocContacto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.LblContacto = New System.Windows.Forms.Label()
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnrodocumento = New System.Windows.Forms.TextBox()
        Me.GrbCliente = New System.Windows.Forms.GroupBox()
        Me.ChkTelefono = New System.Windows.Forms.CheckBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblAPCliente = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtAPCliente = New System.Windows.Forms.TextBox()
        Me.TxtAMCliente = New System.Windows.Forms.TextBox()
        Me.LblAMCliente = New System.Windows.Forms.Label()
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.labnroidentidad = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.GrbDireccion = New System.Windows.Forms.GroupBox()
        Me.TxtZona = New System.Windows.Forms.TextBox()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.TxtManzana = New System.Windows.Forms.TextBox()
        Me.TxtNumero2 = New System.Windows.Forms.TextBox()
        Me.TxtClasificacion = New System.Windows.Forms.TextBox()
        Me.TxtNivel = New System.Windows.Forms.TextBox()
        Me.TxtVia = New System.Windows.Forms.TextBox()
        Me.CboDistrito = New System.Windows.Forms.ComboBox()
        Me.CboProvincia = New System.Windows.Forms.ComboBox()
        Me.CboClasificacion = New System.Windows.Forms.ComboBox()
        Me.CboZona = New System.Windows.Forms.ComboBox()
        Me.CboNivel = New System.Windows.Forms.ComboBox()
        Me.CboVia = New System.Windows.Forms.ComboBox()
        Me.CboDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.TabCliente.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GrbContacto.SuspendLayout()
        Me.GrbCliente.SuspendLayout()
        Me.GrbDireccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabCliente
        '
        Me.TabCliente.Controls.Add(Me.TabPage1)
        Me.TabCliente.Controls.Add(Me.TabPage2)
        Me.TabCliente.Location = New System.Drawing.Point(5, 3)
        Me.TabCliente.Name = "TabCliente"
        Me.TabCliente.SelectedIndex = 0
        Me.TabCliente.Size = New System.Drawing.Size(678, 345)
        Me.TabCliente.TabIndex = 23
        Me.TabCliente.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LblBuscar)
        Me.TabPage1.Controls.Add(Me.txtrazon)
        Me.TabPage1.Controls.Add(Me.BtnBuscar)
        Me.TabPage1.Controls.Add(Me.dgvBuscar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(670, 319)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Buscar"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Location = New System.Drawing.Point(4, 9)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(39, 13)
        Me.LblBuscar.TabIndex = 9
        Me.LblBuscar.Text = "Cliente"
        '
        'txtrazon
        '
        Me.txtrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazon.Location = New System.Drawing.Point(58, 6)
        Me.txtrazon.MaxLength = 100
        Me.txtrazon.Name = "txtrazon"
        Me.txtrazon.Size = New System.Drawing.Size(532, 20)
        Me.txtrazon.TabIndex = 8
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscar.Enabled = False
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.Location = New System.Drawing.Point(598, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(66, 23)
        Me.BtnBuscar.TabIndex = 7
        Me.BtnBuscar.TabStop = False
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'dgvBuscar
        '
        Me.dgvBuscar.BackgroundColor = System.Drawing.Color.MidnightBlue
        Me.dgvBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBuscar.Location = New System.Drawing.Point(6, 33)
        Me.dgvBuscar.Name = "dgvBuscar"
        Me.dgvBuscar.Size = New System.Drawing.Size(659, 285)
        Me.dgvBuscar.TabIndex = 6
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GrbContacto)
        Me.TabPage2.Controls.Add(Me.GrbCliente)
        Me.TabPage2.Controls.Add(Me.GrbDireccion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(670, 319)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cliente"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GrbContacto
        '
        Me.GrbContacto.Controls.Add(Me.LblAPContacto)
        Me.GrbContacto.Controls.Add(Me.TxtAPContacto)
        Me.GrbContacto.Controls.Add(Me.TxtAMContacto)
        Me.GrbContacto.Controls.Add(Me.LblAMContacto)
        Me.GrbContacto.Controls.Add(Me.CboDocContacto)
        Me.GrbContacto.Controls.Add(Me.Label4)
        Me.GrbContacto.Controls.Add(Me.ChkCliente)
        Me.GrbContacto.Controls.Add(Me.LblContacto)
        Me.GrbContacto.Controls.Add(Me.TxtContacto)
        Me.GrbContacto.Controls.Add(Me.Label2)
        Me.GrbContacto.Controls.Add(Me.txtnrodocumento)
        Me.GrbContacto.Location = New System.Drawing.Point(7, 225)
        Me.GrbContacto.Name = "GrbContacto"
        Me.GrbContacto.Size = New System.Drawing.Size(656, 86)
        Me.GrbContacto.TabIndex = 3
        Me.GrbContacto.TabStop = False
        Me.GrbContacto.Text = "Contacto"
        '
        'LblAPContacto
        '
        Me.LblAPContacto.AutoSize = True
        Me.LblAPContacto.Location = New System.Drawing.Point(7, 63)
        Me.LblAPContacto.Name = "LblAPContacto"
        Me.LblAPContacto.Size = New System.Drawing.Size(55, 13)
        Me.LblAPContacto.TabIndex = 104
        Me.LblAPContacto.Text = "Apell. Pat."
        '
        'TxtAPContacto
        '
        Me.TxtAPContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAPContacto.Location = New System.Drawing.Point(67, 60)
        Me.TxtAPContacto.MaxLength = 50
        Me.TxtAPContacto.Name = "TxtAPContacto"
        Me.TxtAPContacto.Size = New System.Drawing.Size(249, 20)
        Me.TxtAPContacto.TabIndex = 26
        '
        'TxtAMContacto
        '
        Me.TxtAMContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAMContacto.Location = New System.Drawing.Point(400, 60)
        Me.TxtAMContacto.MaxLength = 50
        Me.TxtAMContacto.Name = "TxtAMContacto"
        Me.TxtAMContacto.Size = New System.Drawing.Size(249, 20)
        Me.TxtAMContacto.TabIndex = 27
        '
        'LblAMContacto
        '
        Me.LblAMContacto.AutoSize = True
        Me.LblAMContacto.BackColor = System.Drawing.Color.Transparent
        Me.LblAMContacto.Location = New System.Drawing.Point(340, 63)
        Me.LblAMContacto.Name = "LblAMContacto"
        Me.LblAMContacto.Size = New System.Drawing.Size(57, 13)
        Me.LblAMContacto.TabIndex = 105
        Me.LblAMContacto.Text = "Apell. Mat."
        Me.LblAMContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboDocContacto
        '
        Me.CboDocContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocContacto.FormattingEnabled = True
        Me.CboDocContacto.Location = New System.Drawing.Point(66, 14)
        Me.CboDocContacto.Name = "CboDocContacto"
        Me.CboDocContacto.Size = New System.Drawing.Size(127, 21)
        Me.CboDocContacto.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Tipo Doc."
        '
        'ChkCliente
        '
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Location = New System.Drawing.Point(565, 15)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(84, 17)
        Me.ChkCliente.TabIndex = 22
        Me.ChkCliente.Text = "Es el Cliente"
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'LblContacto
        '
        Me.LblContacto.AutoSize = True
        Me.LblContacto.BackColor = System.Drawing.Color.Transparent
        Me.LblContacto.Location = New System.Drawing.Point(9, 41)
        Me.LblContacto.Name = "LblContacto"
        Me.LblContacto.Size = New System.Drawing.Size(49, 13)
        Me.LblContacto.TabIndex = 99
        Me.LblContacto.Text = "Nombres"
        Me.LblContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtContacto
        '
        Me.TxtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContacto.Location = New System.Drawing.Point(66, 38)
        Me.TxtContacto.MaxLength = 100
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(583, 20)
        Me.TxtContacto.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Nº Doc."
        '
        'txtnrodocumento
        '
        Me.txtnrodocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnrodocumento.Location = New System.Drawing.Point(268, 14)
        Me.txtnrodocumento.MaxLength = 11
        Me.txtnrodocumento.Name = "txtnrodocumento"
        Me.txtnrodocumento.Size = New System.Drawing.Size(117, 20)
        Me.txtnrodocumento.TabIndex = 24
        '
        'GrbCliente
        '
        Me.GrbCliente.Controls.Add(Me.ChkTelefono)
        Me.GrbCliente.Controls.Add(Me.txtTelefono)
        Me.GrbCliente.Controls.Add(Me.LblEmail)
        Me.GrbCliente.Controls.Add(Me.LblAPCliente)
        Me.GrbCliente.Controls.Add(Me.TxtEmail)
        Me.GrbCliente.Controls.Add(Me.TxtAPCliente)
        Me.GrbCliente.Controls.Add(Me.TxtAMCliente)
        Me.GrbCliente.Controls.Add(Me.LblAMCliente)
        Me.GrbCliente.Controls.Add(Me.CboTipoDocumento)
        Me.GrbCliente.Controls.Add(Me.Label18)
        Me.GrbCliente.Controls.Add(Me.labnroidentidad)
        Me.GrbCliente.Controls.Add(Me.TxtNumero)
        Me.GrbCliente.Controls.Add(Me.LblCliente)
        Me.GrbCliente.Controls.Add(Me.TxtCliente)
        Me.GrbCliente.Location = New System.Drawing.Point(7, 5)
        Me.GrbCliente.Name = "GrbCliente"
        Me.GrbCliente.Size = New System.Drawing.Size(656, 105)
        Me.GrbCliente.TabIndex = 0
        Me.GrbCliente.TabStop = False
        Me.GrbCliente.Text = "Cliente"
        '
        'ChkTelefono
        '
        Me.ChkTelefono.AutoSize = True
        Me.ChkTelefono.Checked = True
        Me.ChkTelefono.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTelefono.Location = New System.Drawing.Point(446, 12)
        Me.ChkTelefono.Name = "ChkTelefono"
        Me.ChkTelefono.Size = New System.Drawing.Size(68, 17)
        Me.ChkTelefono.TabIndex = 2
        Me.ChkTelefono.Text = "Telefono"
        Me.ChkTelefono.UseVisualStyleBackColor = True
        '
        'txtTelefono
        '
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Location = New System.Drawing.Point(523, 11)
        Me.txtTelefono.MaxLength = 30
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(126, 20)
        Me.txtTelefono.TabIndex = 3
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(6, 81)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(32, 13)
        Me.LblEmail.TabIndex = 97
        Me.LblEmail.Text = "Email"
        '
        'LblAPCliente
        '
        Me.LblAPCliente.AutoSize = True
        Me.LblAPCliente.Location = New System.Drawing.Point(6, 59)
        Me.LblAPCliente.Name = "LblAPCliente"
        Me.LblAPCliente.Size = New System.Drawing.Size(55, 13)
        Me.LblAPCliente.TabIndex = 97
        Me.LblAPCliente.Text = "Apell. Pat."
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(66, 79)
        Me.TxtEmail.MaxLength = 40
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(583, 20)
        Me.TxtEmail.TabIndex = 7
        '
        'TxtAPCliente
        '
        Me.TxtAPCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAPCliente.Location = New System.Drawing.Point(66, 56)
        Me.TxtAPCliente.MaxLength = 50
        Me.TxtAPCliente.Name = "TxtAPCliente"
        Me.TxtAPCliente.Size = New System.Drawing.Size(249, 20)
        Me.TxtAPCliente.TabIndex = 5
        '
        'TxtAMCliente
        '
        Me.TxtAMCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAMCliente.Location = New System.Drawing.Point(400, 56)
        Me.TxtAMCliente.MaxLength = 50
        Me.TxtAMCliente.Name = "TxtAMCliente"
        Me.TxtAMCliente.Size = New System.Drawing.Size(249, 20)
        Me.TxtAMCliente.TabIndex = 6
        '
        'LblAMCliente
        '
        Me.LblAMCliente.AutoSize = True
        Me.LblAMCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblAMCliente.Location = New System.Drawing.Point(340, 59)
        Me.LblAMCliente.Name = "LblAMCliente"
        Me.LblAMCliente.Size = New System.Drawing.Size(57, 13)
        Me.LblAMCliente.TabIndex = 98
        Me.LblAMCliente.Text = "Apell. Mat."
        Me.LblAMCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Location = New System.Drawing.Point(66, 11)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(127, 21)
        Me.CboTipoDocumento.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "Tipo Doc."
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(211, 15)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(45, 13)
        Me.labnroidentidad.TabIndex = 76
        Me.labnroidentidad.Text = "Nº Doc."
        '
        'TxtNumero
        '
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Location = New System.Drawing.Point(268, 11)
        Me.TxtNumero.MaxLength = 8
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(117, 20)
        Me.TxtNumero.TabIndex = 1
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(6, 37)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(49, 13)
        Me.LblCliente.TabIndex = 62
        Me.LblCliente.Text = "Nombres"
        '
        'TxtCliente
        '
        Me.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCliente.Location = New System.Drawing.Point(66, 34)
        Me.TxtCliente.MaxLength = 80
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(583, 20)
        Me.TxtCliente.TabIndex = 4
        '
        'GrbDireccion
        '
        Me.GrbDireccion.Controls.Add(Me.TxtZona)
        Me.GrbDireccion.Controls.Add(Me.TxtLote)
        Me.GrbDireccion.Controls.Add(Me.TxtManzana)
        Me.GrbDireccion.Controls.Add(Me.TxtNumero2)
        Me.GrbDireccion.Controls.Add(Me.TxtClasificacion)
        Me.GrbDireccion.Controls.Add(Me.TxtNivel)
        Me.GrbDireccion.Controls.Add(Me.TxtVia)
        Me.GrbDireccion.Controls.Add(Me.CboDistrito)
        Me.GrbDireccion.Controls.Add(Me.CboProvincia)
        Me.GrbDireccion.Controls.Add(Me.CboClasificacion)
        Me.GrbDireccion.Controls.Add(Me.CboZona)
        Me.GrbDireccion.Controls.Add(Me.CboNivel)
        Me.GrbDireccion.Controls.Add(Me.CboVia)
        Me.GrbDireccion.Controls.Add(Me.CboDepartamento)
        Me.GrbDireccion.Controls.Add(Me.Label10)
        Me.GrbDireccion.Controls.Add(Me.Label14)
        Me.GrbDireccion.Controls.Add(Me.Label5)
        Me.GrbDireccion.Controls.Add(Me.Label16)
        Me.GrbDireccion.Controls.Add(Me.Label12)
        Me.GrbDireccion.Controls.Add(Me.Label9)
        Me.GrbDireccion.Controls.Add(Me.Label7)
        Me.GrbDireccion.Controls.Add(Me.Label8)
        Me.GrbDireccion.Location = New System.Drawing.Point(7, 114)
        Me.GrbDireccion.Name = "GrbDireccion"
        Me.GrbDireccion.Size = New System.Drawing.Size(656, 106)
        Me.GrbDireccion.TabIndex = 2
        Me.GrbDireccion.TabStop = False
        Me.GrbDireccion.Text = "Dirección"
        '
        'TxtZona
        '
        Me.TxtZona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZona.Location = New System.Drawing.Point(229, 81)
        Me.TxtZona.MaxLength = 50
        Me.TxtZona.Name = "TxtZona"
        Me.TxtZona.ReadOnly = True
        Me.TxtZona.Size = New System.Drawing.Size(127, 20)
        Me.TxtZona.TabIndex = 19
        '
        'TxtLote
        '
        Me.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLote.Location = New System.Drawing.Point(312, 58)
        Me.TxtLote.MaxLength = 3
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.ReadOnly = True
        Me.TxtLote.Size = New System.Drawing.Size(44, 20)
        Me.TxtLote.TabIndex = 15
        '
        'TxtManzana
        '
        Me.TxtManzana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtManzana.Location = New System.Drawing.Point(229, 58)
        Me.TxtManzana.MaxLength = 10
        Me.TxtManzana.Name = "TxtManzana"
        Me.TxtManzana.ReadOnly = True
        Me.TxtManzana.Size = New System.Drawing.Size(44, 20)
        Me.TxtManzana.TabIndex = 14
        '
        'TxtNumero2
        '
        Me.TxtNumero2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero2.Location = New System.Drawing.Point(66, 58)
        Me.TxtNumero2.MaxLength = 5
        Me.TxtNumero2.Name = "TxtNumero2"
        Me.TxtNumero2.ReadOnly = True
        Me.TxtNumero2.Size = New System.Drawing.Size(126, 20)
        Me.TxtNumero2.TabIndex = 13
        '
        'TxtClasificacion
        '
        Me.TxtClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtClasificacion.Location = New System.Drawing.Point(522, 80)
        Me.TxtClasificacion.MaxLength = 50
        Me.TxtClasificacion.Name = "TxtClasificacion"
        Me.TxtClasificacion.ReadOnly = True
        Me.TxtClasificacion.Size = New System.Drawing.Size(127, 20)
        Me.TxtClasificacion.TabIndex = 21
        '
        'TxtNivel
        '
        Me.TxtNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNivel.Location = New System.Drawing.Point(522, 58)
        Me.TxtNivel.MaxLength = 50
        Me.TxtNivel.Name = "TxtNivel"
        Me.TxtNivel.ReadOnly = True
        Me.TxtNivel.Size = New System.Drawing.Size(127, 20)
        Me.TxtNivel.TabIndex = 17
        '
        'TxtVia
        '
        Me.TxtVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVia.Location = New System.Drawing.Point(229, 35)
        Me.TxtVia.MaxLength = 50
        Me.TxtVia.Name = "TxtVia"
        Me.TxtVia.ReadOnly = True
        Me.TxtVia.Size = New System.Drawing.Size(127, 20)
        Me.TxtVia.TabIndex = 12
        '
        'CboDistrito
        '
        Me.CboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDistrito.DropDownWidth = 180
        Me.CboDistrito.FormattingEnabled = True
        Me.CboDistrito.Location = New System.Drawing.Point(387, 12)
        Me.CboDistrito.Name = "CboDistrito"
        Me.CboDistrito.Size = New System.Drawing.Size(262, 21)
        Me.CboDistrito.TabIndex = 10
        '
        'CboProvincia
        '
        Me.CboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProvincia.DropDownWidth = 180
        Me.CboProvincia.FormattingEnabled = True
        Me.CboProvincia.Location = New System.Drawing.Point(229, 12)
        Me.CboProvincia.Name = "CboProvincia"
        Me.CboProvincia.Size = New System.Drawing.Size(127, 21)
        Me.CboProvincia.TabIndex = 9
        '
        'CboClasificacion
        '
        Me.CboClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboClasificacion.Enabled = False
        Me.CboClasificacion.FormattingEnabled = True
        Me.CboClasificacion.Location = New System.Drawing.Point(387, 80)
        Me.CboClasificacion.Name = "CboClasificacion"
        Me.CboClasificacion.Size = New System.Drawing.Size(127, 21)
        Me.CboClasificacion.TabIndex = 20
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.DropDownWidth = 150
        Me.CboZona.Enabled = False
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(66, 80)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(127, 21)
        Me.CboZona.TabIndex = 18
        '
        'CboNivel
        '
        Me.CboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboNivel.Enabled = False
        Me.CboNivel.FormattingEnabled = True
        Me.CboNivel.Location = New System.Drawing.Point(387, 58)
        Me.CboNivel.Name = "CboNivel"
        Me.CboNivel.Size = New System.Drawing.Size(127, 21)
        Me.CboNivel.TabIndex = 16
        '
        'CboVia
        '
        Me.CboVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboVia.DropDownWidth = 127
        Me.CboVia.Enabled = False
        Me.CboVia.FormattingEnabled = True
        Me.CboVia.Location = New System.Drawing.Point(66, 35)
        Me.CboVia.Name = "CboVia"
        Me.CboVia.Size = New System.Drawing.Size(127, 21)
        Me.CboVia.TabIndex = 11
        '
        'CboDepartamento
        '
        Me.CboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDepartamento.FormattingEnabled = True
        Me.CboDepartamento.Location = New System.Drawing.Point(66, 12)
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.Size = New System.Drawing.Size(127, 21)
        Me.CboDepartamento.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 13)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Nº"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(280, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 13)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "Lt."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(359, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Dist."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "Zona"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(198, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Mz."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Vía"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Dpto."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(198, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Prov."
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(606, 353)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(76, 26)
        Me.BtnCancelar.TabIndex = 30
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAceptar.Location = New System.Drawing.Point(524, 353)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(77, 26)
        Me.BtnAceptar.TabIndex = 29
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.Location = New System.Drawing.Point(5, 353)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(88, 26)
        Me.BtnNuevo.TabIndex = 28
        Me.BtnNuevo.TabStop = False
        Me.BtnNuevo.Text = "Nuevo Cliente"
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'FrmCliente2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 383)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.TabCliente)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCliente2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente"
        Me.TabCliente.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GrbContacto.ResumeLayout(False)
        Me.GrbContacto.PerformLayout()
        Me.GrbCliente.ResumeLayout(False)
        Me.GrbCliente.PerformLayout()
        Me.GrbDireccion.ResumeLayout(False)
        Me.GrbDireccion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabCliente As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtrazon As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvBuscar As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GrbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents CboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents GrbDireccion As System.Windows.Forms.GroupBox
    Friend WithEvents CboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents CboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents CboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents TxtNumero2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtVia As System.Windows.Forms.TextBox
    Friend WithEvents CboVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtManzana As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtZona As System.Windows.Forms.TextBox
    Friend WithEvents TxtLote As System.Windows.Forms.TextBox
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents CboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNivel As System.Windows.Forms.TextBox
    Friend WithEvents CboClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents LblBuscar As System.Windows.Forms.Label
    Friend WithEvents GrbContacto As System.Windows.Forms.GroupBox
    Friend WithEvents CboDocContacto As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents LblContacto As System.Windows.Forms.Label
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnrodocumento As System.Windows.Forms.TextBox
    Friend WithEvents LblAPCliente As System.Windows.Forms.Label
    Friend WithEvents TxtAPCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtAMCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblAMCliente As System.Windows.Forms.Label
    Friend WithEvents LblAPContacto As System.Windows.Forms.Label
    Friend WithEvents TxtAPContacto As System.Windows.Forms.TextBox
    Friend WithEvents TxtAMContacto As System.Windows.Forms.TextBox
    Friend WithEvents LblAMContacto As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents ChkTelefono As System.Windows.Forms.CheckBox
End Class
