<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDireccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDireccion))
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.TabDatos = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnBuscarDir = New System.Windows.Forms.Button()
        Me.DtgDireccion = New System.Windows.Forms.DataGridView()
        Me.txtdir = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGoogle = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblLongitud = New System.Windows.Forms.Label()
        Me.lblUrl = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblLatitud = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtZona = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.txtManzana = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtClasificacion = New System.Windows.Forms.TextBox()
        Me.txtNivel = New System.Windows.Forms.TextBox()
        Me.txtVia = New System.Windows.Forms.TextBox()
        Me.cboClasificacion = New System.Windows.Forms.ComboBox()
        Me.cboZona = New System.Windows.Forms.ComboBox()
        Me.cboNivel = New System.Windows.Forms.ComboBox()
        Me.cboVia = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboDistrito = New System.Windows.Forms.ComboBox()
        Me.CboProvincia = New System.Windows.Forms.ComboBox()
        Me.CboDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboPais = New System.Windows.Forms.ComboBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.TabDatos.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DtgDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(597, 331)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.BtnCancelar.TabIndex = 16
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnAceptar.Location = New System.Drawing.Point(513, 331)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.BtnAceptar.TabIndex = 15
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.TabPage3)
        Me.TabDatos.Controls.Add(Me.TabPage1)
        Me.TabDatos.Location = New System.Drawing.Point(4, 8)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.SelectedIndex = 0
        Me.TabDatos.Size = New System.Drawing.Size(671, 317)
        Me.TabDatos.TabIndex = 10
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.BtnBuscarDir)
        Me.TabPage3.Controls.Add(Me.DtgDireccion)
        Me.TabPage3.Controls.Add(Me.txtdir)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(663, 291)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Búsqueda"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Dirección"
        '
        'BtnBuscarDir
        '
        Me.BtnBuscarDir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarDir.Image = CType(resources.GetObject("BtnBuscarDir.Image"), System.Drawing.Image)
        Me.BtnBuscarDir.Location = New System.Drawing.Point(589, 11)
        Me.BtnBuscarDir.Name = "BtnBuscarDir"
        Me.BtnBuscarDir.Size = New System.Drawing.Size(67, 29)
        Me.BtnBuscarDir.TabIndex = 3
        Me.BtnBuscarDir.Text = "Buscar"
        Me.BtnBuscarDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBuscarDir.UseVisualStyleBackColor = True
        '
        'DtgDireccion
        '
        Me.DtgDireccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtgDireccion.Location = New System.Drawing.Point(9, 50)
        Me.DtgDireccion.Name = "DtgDireccion"
        Me.DtgDireccion.Size = New System.Drawing.Size(646, 234)
        Me.DtgDireccion.TabIndex = 2
        '
        'txtdir
        '
        Me.txtdir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdir.Location = New System.Drawing.Point(68, 16)
        Me.txtdir.MaxLength = 200
        Me.txtdir.Name = "txtdir"
        Me.txtdir.Size = New System.Drawing.Size(510, 20)
        Me.txtdir.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.txtZona)
        Me.TabPage1.Controls.Add(Me.txtLote)
        Me.TabPage1.Controls.Add(Me.txtManzana)
        Me.TabPage1.Controls.Add(Me.txtNumero)
        Me.TabPage1.Controls.Add(Me.txtClasificacion)
        Me.TabPage1.Controls.Add(Me.txtNivel)
        Me.TabPage1.Controls.Add(Me.txtVia)
        Me.TabPage1.Controls.Add(Me.cboClasificacion)
        Me.TabPage1.Controls.Add(Me.cboZona)
        Me.TabPage1.Controls.Add(Me.cboNivel)
        Me.TabPage1.Controls.Add(Me.cboVia)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.TxtReferencia)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CboDistrito)
        Me.TabPage1.Controls.Add(Me.CboProvincia)
        Me.TabPage1.Controls.Add(Me.CboDepartamento)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(663, 291)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dirección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGoogle)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.lblLongitud)
        Me.GroupBox1.Controls.Add(Me.lblUrl)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblLatitud)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(640, 49)
        Me.GroupBox1.TabIndex = 144
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicar en Google Maps"
        '
        'btnGoogle
        '
        Me.btnGoogle.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnGoogle.Location = New System.Drawing.Point(556, 12)
        Me.btnGoogle.Name = "btnGoogle"
        Me.btnGoogle.Size = New System.Drawing.Size(78, 28)
        Me.btnGoogle.TabIndex = 116
        Me.btnGoogle.Text = "Google Maps"
        Me.btnGoogle.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(407, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Longitud"
        '
        'lblLongitud
        '
        Me.lblLongitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLongitud.Location = New System.Drawing.Point(455, 21)
        Me.lblLongitud.Name = "lblLongitud"
        Me.lblLongitud.Size = New System.Drawing.Size(91, 13)
        Me.lblLongitud.TabIndex = 115
        Me.lblLongitud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUrl
        '
        Me.lblUrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUrl.Location = New System.Drawing.Point(35, 21)
        Me.lblUrl.Name = "lblUrl"
        Me.lblUrl.Size = New System.Drawing.Size(215, 13)
        Me.lblUrl.TabIndex = 112
        Me.lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "Url"
        '
        'lblLatitud
        '
        Me.lblLatitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLatitud.Location = New System.Drawing.Point(297, 21)
        Me.lblLatitud.Name = "lblLatitud"
        Me.lblLatitud.Size = New System.Drawing.Size(91, 13)
        Me.lblLatitud.TabIndex = 112
        Me.lblLatitud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(258, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "Latitud"
        '
        'txtZona
        '
        Me.txtZona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZona.Location = New System.Drawing.Point(236, 129)
        Me.txtZona.MaxLength = 50
        Me.txtZona.Name = "txtZona"
        Me.txtZona.ReadOnly = True
        Me.txtZona.Size = New System.Drawing.Size(127, 20)
        Me.txtZona.TabIndex = 11
        '
        'txtLote
        '
        Me.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLote.Location = New System.Drawing.Point(319, 96)
        Me.txtLote.MaxLength = 3
        Me.txtLote.Name = "txtLote"
        Me.txtLote.ReadOnly = True
        Me.txtLote.Size = New System.Drawing.Size(44, 20)
        Me.txtLote.TabIndex = 7
        '
        'txtManzana
        '
        Me.txtManzana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtManzana.Location = New System.Drawing.Point(236, 96)
        Me.txtManzana.MaxLength = 10
        Me.txtManzana.Name = "txtManzana"
        Me.txtManzana.ReadOnly = True
        Me.txtManzana.Size = New System.Drawing.Size(44, 20)
        Me.txtManzana.TabIndex = 6
        '
        'txtNumero
        '
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Location = New System.Drawing.Point(62, 94)
        Me.txtNumero.MaxLength = 5
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(126, 20)
        Me.txtNumero.TabIndex = 5
        '
        'txtClasificacion
        '
        Me.txtClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClasificacion.Location = New System.Drawing.Point(543, 128)
        Me.txtClasificacion.MaxLength = 50
        Me.txtClasificacion.Name = "txtClasificacion"
        Me.txtClasificacion.ReadOnly = True
        Me.txtClasificacion.Size = New System.Drawing.Size(111, 20)
        Me.txtClasificacion.TabIndex = 13
        '
        'txtNivel
        '
        Me.txtNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNivel.Location = New System.Drawing.Point(543, 96)
        Me.txtNivel.MaxLength = 50
        Me.txtNivel.Name = "txtNivel"
        Me.txtNivel.ReadOnly = True
        Me.txtNivel.Size = New System.Drawing.Size(111, 20)
        Me.txtNivel.TabIndex = 9
        '
        'txtVia
        '
        Me.txtVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVia.Location = New System.Drawing.Point(236, 59)
        Me.txtVia.MaxLength = 50
        Me.txtVia.Name = "txtVia"
        Me.txtVia.ReadOnly = True
        Me.txtVia.Size = New System.Drawing.Size(418, 20)
        Me.txtVia.TabIndex = 4
        '
        'cboClasificacion
        '
        Me.cboClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClasificacion.Enabled = False
        Me.cboClasificacion.FormattingEnabled = True
        Me.cboClasificacion.Location = New System.Drawing.Point(408, 129)
        Me.cboClasificacion.Name = "cboClasificacion"
        Me.cboClasificacion.Size = New System.Drawing.Size(127, 21)
        Me.cboClasificacion.TabIndex = 12
        '
        'cboZona
        '
        Me.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZona.DropDownWidth = 150
        Me.cboZona.Enabled = False
        Me.cboZona.FormattingEnabled = True
        Me.cboZona.Location = New System.Drawing.Point(62, 128)
        Me.cboZona.Name = "cboZona"
        Me.cboZona.Size = New System.Drawing.Size(127, 21)
        Me.cboZona.TabIndex = 10
        '
        'cboNivel
        '
        Me.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNivel.Enabled = False
        Me.cboNivel.FormattingEnabled = True
        Me.cboNivel.Location = New System.Drawing.Point(408, 97)
        Me.cboNivel.Name = "cboNivel"
        Me.cboNivel.Size = New System.Drawing.Size(127, 21)
        Me.cboNivel.TabIndex = 8
        '
        'cboVia
        '
        Me.cboVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVia.DropDownWidth = 127
        Me.cboVia.Enabled = False
        Me.cboVia.FormattingEnabled = True
        Me.cboVia.Location = New System.Drawing.Point(62, 59)
        Me.cboVia.Name = "cboVia"
        Me.cboVia.Size = New System.Drawing.Size(127, 21)
        Me.cboVia.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 13)
        Me.Label15.TabIndex = 143
        Me.Label15.Text = "Nº"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(287, 99)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(19, 13)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "Lt."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 129)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 141
        Me.Label17.Text = "Zona"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(199, 99)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 13)
        Me.Label18.TabIndex = 139
        Me.Label18.Text = "Mz."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(11, 61)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(24, 13)
        Me.Label19.TabIndex = 140
        Me.Label19.Text = "Vía"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "Refe."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(374, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Dist."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 108
        Me.Label8.Text = "Dpto."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(199, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Prov."
        '
        'TxtReferencia
        '
        Me.TxtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReferencia.Location = New System.Drawing.Point(62, 168)
        Me.TxtReferencia.MaxLength = 100
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(592, 20)
        Me.TxtReferencia.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 102
        '
        'CboDistrito
        '
        Me.CboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDistrito.DropDownWidth = 165
        Me.CboDistrito.FormattingEnabled = True
        Me.CboDistrito.Location = New System.Drawing.Point(408, 23)
        Me.CboDistrito.Name = "CboDistrito"
        Me.CboDistrito.Size = New System.Drawing.Size(246, 21)
        Me.CboDistrito.TabIndex = 2
        '
        'CboProvincia
        '
        Me.CboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProvincia.FormattingEnabled = True
        Me.CboProvincia.Location = New System.Drawing.Point(236, 23)
        Me.CboProvincia.Name = "CboProvincia"
        Me.CboProvincia.Size = New System.Drawing.Size(127, 21)
        Me.CboProvincia.TabIndex = 1
        '
        'CboDepartamento
        '
        Me.CboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDepartamento.FormattingEnabled = True
        Me.CboDepartamento.Location = New System.Drawing.Point(62, 23)
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.Size = New System.Drawing.Size(127, 21)
        Me.CboDepartamento.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(525, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(171, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 12
        '
        'CboPais
        '
        Me.CboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPais.FormattingEnabled = True
        Me.CboPais.Location = New System.Drawing.Point(274, 435)
        Me.CboPais.Name = "CboPais"
        Me.CboPais.Size = New System.Drawing.Size(139, 21)
        Me.CboPais.TabIndex = 1
        Me.CboPais.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnNuevo.Location = New System.Drawing.Point(8, 331)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 27)
        Me.btnNuevo.TabIndex = 15
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'FrmDireccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 367)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.TabDatos)
        Me.Controls.Add(Me.CboPais)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDireccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dirección"
        Me.TabDatos.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DtgDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents TabDatos As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents BtnBuscarDir As System.Windows.Forms.Button
    Friend WithEvents DtgDireccion As System.Windows.Forms.DataGridView
    Friend WithEvents txtdir As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents CboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents CboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents CboPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtZona As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtManzana As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents txtNivel As System.Windows.Forms.TextBox
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents cboClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents cboZona As System.Windows.Forms.ComboBox
    Friend WithEvents cboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents cboVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGoogle As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblLongitud As System.Windows.Forms.Label
    Friend WithEvents lblLatitud As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblUrl As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
