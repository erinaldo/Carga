<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsignado
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsignado))
        Me.TabConsignado = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LblBuscar = New System.Windows.Forms.Label()
        Me.txtrazon = New System.Windows.Forms.TextBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.dgvBuscar = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrbConsignado = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.LblApePat = New System.Windows.Forms.Label()
        Me.txtapePConsig = New System.Windows.Forms.TextBox()
        Me.txtapeMConsig = New System.Windows.Forms.TextBox()
        Me.lblApeMat = New System.Windows.Forms.Label()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.labnroidentidad = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.LblConsignado = New System.Windows.Forms.Label()
        Me.TxtConsignado = New System.Windows.Forms.TextBox()
        Me.GrbDireccion = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtZona = New System.Windows.Forms.TextBox()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.TxtManzana = New System.Windows.Forms.TextBox()
        Me.TxtNumero2 = New System.Windows.Forms.TextBox()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
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
        Me.lblLlamada4 = New System.Windows.Forms.Label()
        Me.lblLlamada3 = New System.Windows.Forms.Label()
        Me.lblLlamada2 = New System.Windows.Forms.Label()
        Me.lblMensajeLlamada = New System.Windows.Forms.Label()
        Me.lblLlamada1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabConsignado.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GrbConsignado.SuspendLayout()
        Me.GrbDireccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabConsignado
        '
        Me.TabConsignado.Controls.Add(Me.TabPage1)
        Me.TabConsignado.Controls.Add(Me.TabPage2)
        Me.TabConsignado.Location = New System.Drawing.Point(4, 3)
        Me.TabConsignado.Name = "TabConsignado"
        Me.TabConsignado.SelectedIndex = 0
        Me.TabConsignado.Size = New System.Drawing.Size(678, 293)
        Me.TabConsignado.TabIndex = 26
        Me.TabConsignado.TabStop = False
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
        Me.TabPage1.Size = New System.Drawing.Size(670, 267)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Buscar"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Location = New System.Drawing.Point(4, 9)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(49, 13)
        Me.LblBuscar.TabIndex = 9
        Me.LblBuscar.Text = "Nombres"
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
        Me.dgvBuscar.Size = New System.Drawing.Size(659, 230)
        Me.dgvBuscar.TabIndex = 6
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GrbConsignado)
        Me.TabPage2.Controls.Add(Me.GrbDireccion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(670, 267)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Consignado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GrbConsignado
        '
        Me.GrbConsignado.Controls.Add(Me.Label2)
        Me.GrbConsignado.Controls.Add(Me.txtTelefono)
        Me.GrbConsignado.Controls.Add(Me.LblApePat)
        Me.GrbConsignado.Controls.Add(Me.txtapePConsig)
        Me.GrbConsignado.Controls.Add(Me.txtapeMConsig)
        Me.GrbConsignado.Controls.Add(Me.lblApeMat)
        Me.GrbConsignado.Controls.Add(Me.ChkCliente)
        Me.GrbConsignado.Controls.Add(Me.CboTipoDocumento)
        Me.GrbConsignado.Controls.Add(Me.Label18)
        Me.GrbConsignado.Controls.Add(Me.labnroidentidad)
        Me.GrbConsignado.Controls.Add(Me.TxtNumero)
        Me.GrbConsignado.Controls.Add(Me.LblConsignado)
        Me.GrbConsignado.Controls.Add(Me.TxtConsignado)
        Me.GrbConsignado.Location = New System.Drawing.Point(7, 15)
        Me.GrbConsignado.Name = "GrbConsignado"
        Me.GrbConsignado.Size = New System.Drawing.Size(656, 87)
        Me.GrbConsignado.TabIndex = 0
        Me.GrbConsignado.TabStop = False
        Me.GrbConsignado.Text = "Consignado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(388, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Telefono"
        '
        'txtTelefono
        '
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Location = New System.Drawing.Point(437, 13)
        Me.txtTelefono.MaxLength = 30
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(114, 20)
        Me.txtTelefono.TabIndex = 5
        '
        'LblApePat
        '
        Me.LblApePat.AutoSize = True
        Me.LblApePat.Location = New System.Drawing.Point(6, 63)
        Me.LblApePat.Name = "LblApePat"
        Me.LblApePat.Size = New System.Drawing.Size(55, 13)
        Me.LblApePat.TabIndex = 9
        Me.LblApePat.Text = "Apell. Pat."
        '
        'txtapePConsig
        '
        Me.txtapePConsig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapePConsig.Location = New System.Drawing.Point(66, 60)
        Me.txtapePConsig.MaxLength = 40
        Me.txtapePConsig.Name = "txtapePConsig"
        Me.txtapePConsig.Size = New System.Drawing.Size(249, 20)
        Me.txtapePConsig.TabIndex = 10
        '
        'txtapeMConsig
        '
        Me.txtapeMConsig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapeMConsig.Location = New System.Drawing.Point(400, 60)
        Me.txtapeMConsig.MaxLength = 40
        Me.txtapeMConsig.Name = "txtapeMConsig"
        Me.txtapeMConsig.Size = New System.Drawing.Size(249, 20)
        Me.txtapeMConsig.TabIndex = 12
        '
        'lblApeMat
        '
        Me.lblApeMat.AutoSize = True
        Me.lblApeMat.BackColor = System.Drawing.Color.Transparent
        Me.lblApeMat.Location = New System.Drawing.Point(340, 63)
        Me.lblApeMat.Name = "lblApeMat"
        Me.lblApeMat.Size = New System.Drawing.Size(57, 13)
        Me.lblApeMat.TabIndex = 11
        Me.lblApeMat.Text = "Apell. Mat."
        Me.lblApeMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkCliente
        '
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Location = New System.Drawing.Point(565, 16)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(84, 17)
        Me.ChkCliente.TabIndex = 6
        Me.ChkCliente.Text = "Es el Cliente"
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Location = New System.Drawing.Point(66, 13)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(127, 21)
        Me.CboTipoDocumento.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Tipo Doc."
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(211, 16)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(45, 13)
        Me.labnroidentidad.TabIndex = 2
        Me.labnroidentidad.Text = "Nº Doc."
        '
        'TxtNumero
        '
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Location = New System.Drawing.Point(268, 13)
        Me.TxtNumero.MaxLength = 8
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(117, 20)
        Me.TxtNumero.TabIndex = 3
        '
        'LblConsignado
        '
        Me.LblConsignado.AutoSize = True
        Me.LblConsignado.Location = New System.Drawing.Point(6, 39)
        Me.LblConsignado.Name = "LblConsignado"
        Me.LblConsignado.Size = New System.Drawing.Size(49, 13)
        Me.LblConsignado.TabIndex = 7
        Me.LblConsignado.Text = "Nombres"
        '
        'TxtConsignado
        '
        Me.TxtConsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConsignado.Location = New System.Drawing.Point(66, 37)
        Me.TxtConsignado.MaxLength = 80
        Me.TxtConsignado.Name = "TxtConsignado"
        Me.TxtConsignado.Size = New System.Drawing.Size(583, 20)
        Me.TxtConsignado.TabIndex = 8
        '
        'GrbDireccion
        '
        Me.GrbDireccion.Controls.Add(Me.Label1)
        Me.GrbDireccion.Controls.Add(Me.TxtZona)
        Me.GrbDireccion.Controls.Add(Me.TxtLote)
        Me.GrbDireccion.Controls.Add(Me.TxtManzana)
        Me.GrbDireccion.Controls.Add(Me.TxtNumero2)
        Me.GrbDireccion.Controls.Add(Me.TxtReferencia)
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
        Me.GrbDireccion.Controls.Add(Me.lblLlamada4)
        Me.GrbDireccion.Controls.Add(Me.lblLlamada3)
        Me.GrbDireccion.Controls.Add(Me.lblLlamada2)
        Me.GrbDireccion.Controls.Add(Me.lblMensajeLlamada)
        Me.GrbDireccion.Controls.Add(Me.lblLlamada1)
        Me.GrbDireccion.Controls.Add(Me.Label16)
        Me.GrbDireccion.Controls.Add(Me.Label12)
        Me.GrbDireccion.Controls.Add(Me.Label9)
        Me.GrbDireccion.Controls.Add(Me.Label7)
        Me.GrbDireccion.Controls.Add(Me.Label8)
        Me.GrbDireccion.Enabled = False
        Me.GrbDireccion.Location = New System.Drawing.Point(7, 116)
        Me.GrbDireccion.Name = "GrbDireccion"
        Me.GrbDireccion.Size = New System.Drawing.Size(656, 148)
        Me.GrbDireccion.TabIndex = 1
        Me.GrbDireccion.TabStop = False
        Me.GrbDireccion.Text = "Dirección"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Referencia"
        '
        'TxtZona
        '
        Me.TxtZona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZona.Location = New System.Drawing.Point(229, 81)
        Me.TxtZona.MaxLength = 50
        Me.TxtZona.Name = "TxtZona"
        Me.TxtZona.Size = New System.Drawing.Size(127, 20)
        Me.TxtZona.TabIndex = 19
        '
        'TxtLote
        '
        Me.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLote.Location = New System.Drawing.Point(312, 58)
        Me.TxtLote.MaxLength = 3
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(44, 20)
        Me.TxtLote.TabIndex = 14
        '
        'TxtManzana
        '
        Me.TxtManzana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtManzana.Location = New System.Drawing.Point(229, 58)
        Me.TxtManzana.MaxLength = 10
        Me.TxtManzana.Name = "TxtManzana"
        Me.TxtManzana.Size = New System.Drawing.Size(44, 20)
        Me.TxtManzana.TabIndex = 12
        '
        'TxtNumero2
        '
        Me.TxtNumero2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero2.Location = New System.Drawing.Point(66, 58)
        Me.TxtNumero2.MaxLength = 5
        Me.TxtNumero2.Name = "TxtNumero2"
        Me.TxtNumero2.Size = New System.Drawing.Size(115, 20)
        Me.TxtNumero2.TabIndex = 10
        '
        'TxtReferencia
        '
        Me.TxtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReferencia.Location = New System.Drawing.Point(66, 107)
        Me.TxtReferencia.MaxLength = 100
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(583, 20)
        Me.TxtReferencia.TabIndex = 22
        '
        'TxtClasificacion
        '
        Me.TxtClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtClasificacion.Location = New System.Drawing.Point(522, 80)
        Me.TxtClasificacion.MaxLength = 50
        Me.TxtClasificacion.Name = "TxtClasificacion"
        Me.TxtClasificacion.Size = New System.Drawing.Size(127, 20)
        Me.TxtClasificacion.TabIndex = 21
        '
        'TxtNivel
        '
        Me.TxtNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNivel.Location = New System.Drawing.Point(522, 58)
        Me.TxtNivel.MaxLength = 50
        Me.TxtNivel.Name = "TxtNivel"
        Me.TxtNivel.Size = New System.Drawing.Size(127, 20)
        Me.TxtNivel.TabIndex = 16
        '
        'TxtVia
        '
        Me.TxtVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVia.Location = New System.Drawing.Point(229, 35)
        Me.TxtVia.MaxLength = 50
        Me.TxtVia.Name = "TxtVia"
        Me.TxtVia.Size = New System.Drawing.Size(127, 20)
        Me.TxtVia.TabIndex = 8
        '
        'CboDistrito
        '
        Me.CboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDistrito.DropDownWidth = 180
        Me.CboDistrito.FormattingEnabled = True
        Me.CboDistrito.Location = New System.Drawing.Point(66, 12)
        Me.CboDistrito.Name = "CboDistrito"
        Me.CboDistrito.Size = New System.Drawing.Size(290, 21)
        Me.CboDistrito.TabIndex = 5
        '
        'CboProvincia
        '
        Me.CboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProvincia.DropDownWidth = 180
        Me.CboProvincia.FormattingEnabled = True
        Me.CboProvincia.Location = New System.Drawing.Point(229, 12)
        Me.CboProvincia.Name = "CboProvincia"
        Me.CboProvincia.Size = New System.Drawing.Size(127, 21)
        Me.CboProvincia.TabIndex = 3
        Me.CboProvincia.Visible = False
        '
        'CboClasificacion
        '
        Me.CboClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
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
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(66, 80)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(115, 21)
        Me.CboZona.TabIndex = 18
        '
        'CboNivel
        '
        Me.CboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboNivel.FormattingEnabled = True
        Me.CboNivel.Location = New System.Drawing.Point(387, 58)
        Me.CboNivel.Name = "CboNivel"
        Me.CboNivel.Size = New System.Drawing.Size(127, 21)
        Me.CboNivel.TabIndex = 15
        '
        'CboVia
        '
        Me.CboVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboVia.DropDownWidth = 127
        Me.CboVia.FormattingEnabled = True
        Me.CboVia.Location = New System.Drawing.Point(66, 35)
        Me.CboVia.Name = "CboVia"
        Me.CboVia.Size = New System.Drawing.Size(115, 21)
        Me.CboVia.TabIndex = 7
        '
        'CboDepartamento
        '
        Me.CboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDepartamento.Enabled = False
        Me.CboDepartamento.FormattingEnabled = True
        Me.CboDepartamento.Location = New System.Drawing.Point(66, 12)
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.Size = New System.Drawing.Size(127, 21)
        Me.CboDepartamento.TabIndex = 1
        Me.CboDepartamento.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Nº"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(280, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Lt."
        '
        'lblLlamada4
        '
        Me.lblLlamada4.AutoSize = True
        Me.lblLlamada4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLlamada4.ForeColor = System.Drawing.Color.Red
        Me.lblLlamada4.Location = New System.Drawing.Point(182, 61)
        Me.lblLlamada4.Name = "lblLlamada4"
        Me.lblLlamada4.Size = New System.Drawing.Size(17, 13)
        Me.lblLlamada4.TabIndex = 4
        Me.lblLlamada4.Text = "(*)"
        Me.lblLlamada4.Visible = False
        '
        'lblLlamada3
        '
        Me.lblLlamada3.AutoSize = True
        Me.lblLlamada3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLlamada3.ForeColor = System.Drawing.Color.Red
        Me.lblLlamada3.Location = New System.Drawing.Point(359, 37)
        Me.lblLlamada3.Name = "lblLlamada3"
        Me.lblLlamada3.Size = New System.Drawing.Size(17, 13)
        Me.lblLlamada3.TabIndex = 4
        Me.lblLlamada3.Text = "(*)"
        Me.lblLlamada3.Visible = False
        '
        'lblLlamada2
        '
        Me.lblLlamada2.AutoSize = True
        Me.lblLlamada2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLlamada2.ForeColor = System.Drawing.Color.Red
        Me.lblLlamada2.Location = New System.Drawing.Point(182, 37)
        Me.lblLlamada2.Name = "lblLlamada2"
        Me.lblLlamada2.Size = New System.Drawing.Size(17, 13)
        Me.lblLlamada2.TabIndex = 4
        Me.lblLlamada2.Text = "(*)"
        Me.lblLlamada2.Visible = False
        '
        'lblMensajeLlamada
        '
        Me.lblMensajeLlamada.AutoSize = True
        Me.lblMensajeLlamada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeLlamada.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeLlamada.Location = New System.Drawing.Point(562, 16)
        Me.lblMensajeLlamada.Name = "lblMensajeLlamada"
        Me.lblMensajeLlamada.Size = New System.Drawing.Size(70, 13)
        Me.lblMensajeLlamada.TabIndex = 4
        Me.lblMensajeLlamada.Text = "(*) Obligatorio"
        Me.lblMensajeLlamada.Visible = False
        '
        'lblLlamada1
        '
        Me.lblLlamada1.AutoSize = True
        Me.lblLlamada1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLlamada1.ForeColor = System.Drawing.Color.Red
        Me.lblLlamada1.Location = New System.Drawing.Point(359, 15)
        Me.lblLlamada1.Name = "lblLlamada1"
        Me.lblLlamada1.Size = New System.Drawing.Size(17, 13)
        Me.lblLlamada1.TabIndex = 4
        Me.lblLlamada1.Text = "(*)"
        Me.lblLlamada1.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Zona"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(199, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Mz."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Vía"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Ubigeo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(198, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Prov."
        Me.Label8.Visible = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.Location = New System.Drawing.Point(4, 300)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(106, 26)
        Me.BtnNuevo.TabIndex = 27
        Me.BtnNuevo.TabStop = False
        Me.BtnNuevo.Text = "Nuevo Consignado"
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(605, 300)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(76, 26)
        Me.BtnCancelar.TabIndex = 19
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAceptar.Location = New System.Drawing.Point(523, 300)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(77, 26)
        Me.BtnAceptar.TabIndex = 18
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'FrmConsignado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 330)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.TabConsignado)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsignado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consignado"
        Me.TabConsignado.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GrbConsignado.ResumeLayout(False)
        Me.GrbConsignado.PerformLayout()
        Me.GrbDireccion.ResumeLayout(False)
        Me.GrbDireccion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabConsignado As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents LblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtrazon As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvBuscar As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ChkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents GrbConsignado As System.Windows.Forms.GroupBox
    Friend WithEvents CboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents LblConsignado As System.Windows.Forms.Label
    Friend WithEvents TxtConsignado As System.Windows.Forms.TextBox
    Friend WithEvents GrbDireccion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtZona As System.Windows.Forms.TextBox
    Friend WithEvents TxtLote As System.Windows.Forms.TextBox
    Friend WithEvents TxtManzana As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumero2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNivel As System.Windows.Forms.TextBox
    Friend WithEvents TxtVia As System.Windows.Forms.TextBox
    Friend WithEvents CboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents CboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents CboClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents CboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents CboVia As System.Windows.Forms.ComboBox
    Friend WithEvents CboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents LblApePat As System.Windows.Forms.Label
    Friend WithEvents txtapePConsig As System.Windows.Forms.TextBox
    Friend WithEvents txtapeMConsig As System.Windows.Forms.TextBox
    Friend WithEvents lblApeMat As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents lblLlamada4 As System.Windows.Forms.Label
    Friend WithEvents lblLlamada3 As System.Windows.Forms.Label
    Friend WithEvents lblLlamada2 As System.Windows.Forms.Label
    Friend WithEvents lblMensajeLlamada As System.Windows.Forms.Label
    Friend WithEvents lblLlamada1 As System.Windows.Forms.Label
End Class
