<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAtencionCliente
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.DataGridViewDocumentos = New System.Windows.Forms.DataGridView
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtHoraFin = New System.Windows.Forms.MaskedTextBox
        Me.txtHoraIni = New System.Windows.Forms.MaskedTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox
        Me.cmbAtendido = New System.Windows.Forms.ComboBox
        Me.cmbResponsableMovil = New System.Windows.Forms.ComboBox
        Me.cmbEstados = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtFechaOperacion = New System.Windows.Forms.DateTimePicker
        Me.txtDistritos = New System.Windows.Forms.TextBox
        Me.txtOperador = New System.Windows.Forms.TextBox
        Me.TxtRasonSocial = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.txtCiudad = New System.Windows.Forms.TextBox
        Me.txtDNIRemitente = New System.Windows.Forms.TextBox
        Me.TxtRuc = New System.Windows.Forms.TextBox
        Me.txtLugarReferencia = New System.Windows.Forms.TextBox
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDireccionRemitente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.txtPeso = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtDestino = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridViewDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.PeachPuff
        Me.GroupBox1.Controls.Add(Me.txtPeso)
        Me.GroupBox1.Controls.Add(Me.txtDestino)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.txtObs)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.DataGridViewDocumentos)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 333)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(83, 309)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 247
        Me.Label12.Text = "F4 EDITAR"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 310)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 247
        Me.Label11.Text = "F3 NUEVO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 290)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(293, 13)
        Me.Label10.TabIndex = 247
        Me.Label10.Text = "F7 PESO/VOLUMEN    F6  DISTRITO   F10 HORA"
        '
        'DataGridViewDocumentos
        '
        Me.DataGridViewDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDocumentos.Location = New System.Drawing.Point(12, 275)
        Me.DataGridViewDocumentos.Name = "DataGridViewDocumentos"
        Me.DataGridViewDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewDocumentos.Size = New System.Drawing.Size(734, 10)
        Me.DataGridViewDocumentos.TabIndex = 246
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.SandyBrown
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Location = New System.Drawing.Point(611, 296)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(135, 24)
        Me.btnSalir.TabIndex = 245
        Me.btnSalir.Text = "(F12)  Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.SandyBrown
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Location = New System.Drawing.Point(470, 296)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 24)
        Me.btnCancelar.TabIndex = 245
        Me.btnCancelar.Text = "( ESC )    Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.SandyBrown
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Location = New System.Drawing.Point(338, 296)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(126, 24)
        Me.btnGrabar.TabIndex = 245
        Me.btnGrabar.Text = "(F5)    Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtHoraFin)
        Me.GroupBox2.Controls.Add(Me.txtHoraIni)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cmbTipoOperacion)
        Me.GroupBox2.Controls.Add(Me.cmbAtendido)
        Me.GroupBox2.Controls.Add(Me.cmbResponsableMovil)
        Me.GroupBox2.Controls.Add(Me.cmbEstados)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtFechaOperacion)
        Me.GroupBox2.Controls.Add(Me.txtDistritos)
        Me.GroupBox2.Controls.Add(Me.txtOperador)
        Me.GroupBox2.Controls.Add(Me.TxtRasonSocial)
        Me.GroupBox2.Controls.Add(Me.TextBox6)
        Me.GroupBox2.Controls.Add(Me.txtCiudad)
        Me.GroupBox2.Controls.Add(Me.txtDNIRemitente)
        Me.GroupBox2.Controls.Add(Me.TxtRuc)
        Me.GroupBox2.Controls.Add(Me.txtLugarReferencia)
        Me.GroupBox2.Controls.Add(Me.txtTelefono)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtDireccionRemitente)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(746, 205)
        Me.GroupBox2.TabIndex = 244
        Me.GroupBox2.TabStop = False
        '
        'txtHoraFin
        '
        Me.txtHoraFin.Location = New System.Drawing.Point(332, 149)
        Me.txtHoraFin.Mask = "00:00"
        Me.txtHoraFin.Name = "txtHoraFin"
        Me.txtHoraFin.Size = New System.Drawing.Size(53, 20)
        Me.txtHoraFin.TabIndex = 12
        Me.txtHoraFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoraFin.ValidatingType = GetType(Date)
        '
        'txtHoraIni
        '
        Me.txtHoraIni.Location = New System.Drawing.Point(136, 147)
        Me.txtHoraIni.Mask = "00:00"
        Me.txtHoraIni.Name = "txtHoraIni"
        Me.txtHoraIni.Size = New System.Drawing.Size(55, 20)
        Me.txtHoraIni.TabIndex = 11
        Me.txtHoraIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoraIni.ValidatingType = GetType(Date)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(553, 156)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 252
        Me.Label13.Text = "T.Operacion"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(394, 154)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 253
        Me.Label16.Text = "Atendido"
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(627, 151)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(113, 21)
        Me.cmbTipoOperacion.TabIndex = 250
        '
        'cmbAtendido
        '
        Me.cmbAtendido.BackColor = System.Drawing.SystemColors.Info
        Me.cmbAtendido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAtendido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAtendido.FormattingEnabled = True
        Me.cmbAtendido.Location = New System.Drawing.Point(449, 151)
        Me.cmbAtendido.Name = "cmbAtendido"
        Me.cmbAtendido.Size = New System.Drawing.Size(86, 21)
        Me.cmbAtendido.TabIndex = 251
        '
        'cmbResponsableMovil
        '
        Me.cmbResponsableMovil.BackColor = System.Drawing.SystemColors.Info
        Me.cmbResponsableMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsableMovil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbResponsableMovil.FormattingEnabled = True
        Me.cmbResponsableMovil.Location = New System.Drawing.Point(136, 178)
        Me.cmbResponsableMovil.Name = "cmbResponsableMovil"
        Me.cmbResponsableMovil.Size = New System.Drawing.Size(399, 21)
        Me.cmbResponsableMovil.TabIndex = 13
        '
        'cmbEstados
        '
        Me.cmbEstados.BackColor = System.Drawing.SystemColors.Info
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(449, 72)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(149, 21)
        Me.cmbEstados.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(253, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 247
        Me.Label5.Text = "Hora Fin"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "Hora Inicio"
        '
        'dtFechaOperacion
        '
        Me.dtFechaOperacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaOperacion.Location = New System.Drawing.Point(657, 73)
        Me.dtFechaOperacion.Name = "dtFechaOperacion"
        Me.dtFechaOperacion.Size = New System.Drawing.Size(83, 20)
        Me.dtFechaOperacion.TabIndex = 7
        '
        'txtDistritos
        '
        Me.txtDistritos.BackColor = System.Drawing.Color.LightCyan
        Me.txtDistritos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistritos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistritos.Location = New System.Drawing.Point(449, 124)
        Me.txtDistritos.MaxLength = 40
        Me.txtDistritos.Name = "txtDistritos"
        Me.txtDistritos.Size = New System.Drawing.Size(291, 20)
        Me.txtDistritos.TabIndex = 10
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.Color.LightCyan
        Me.txtOperador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperador.Location = New System.Drawing.Point(136, 46)
        Me.txtOperador.MaxLength = 40
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(250, 20)
        Me.txtOperador.TabIndex = 3
        '
        'TxtRasonSocial
        '
        Me.TxtRasonSocial.BackColor = System.Drawing.Color.LightCyan
        Me.TxtRasonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRasonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRasonSocial.Location = New System.Drawing.Point(136, 20)
        Me.TxtRasonSocial.MaxLength = 40
        Me.TxtRasonSocial.Name = "TxtRasonSocial"
        Me.TxtRasonSocial.Size = New System.Drawing.Size(250, 20)
        Me.TxtRasonSocial.TabIndex = 1
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.LightCyan
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox6.Location = New System.Drawing.Point(627, 44)
        Me.TextBox6.MaxLength = 11
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(113, 20)
        Me.TextBox6.TabIndex = 243
        '
        'txtCiudad
        '
        Me.txtCiudad.BackColor = System.Drawing.Color.LightCyan
        Me.txtCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCiudad.Location = New System.Drawing.Point(627, 20)
        Me.txtCiudad.MaxLength = 11
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(113, 20)
        Me.txtCiudad.TabIndex = 243
        '
        'txtDNIRemitente
        '
        Me.txtDNIRemitente.BackColor = System.Drawing.Color.LightCyan
        Me.txtDNIRemitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDNIRemitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDNIRemitente.Location = New System.Drawing.Point(391, 45)
        Me.txtDNIRemitente.MaxLength = 11
        Me.txtDNIRemitente.Name = "txtDNIRemitente"
        Me.txtDNIRemitente.Size = New System.Drawing.Size(124, 20)
        Me.txtDNIRemitente.TabIndex = 4
        '
        'TxtRuc
        '
        Me.TxtRuc.BackColor = System.Drawing.Color.LightCyan
        Me.TxtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRuc.Location = New System.Drawing.Point(391, 20)
        Me.TxtRuc.MaxLength = 11
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Size = New System.Drawing.Size(124, 20)
        Me.TxtRuc.TabIndex = 2
        '
        'txtLugarReferencia
        '
        Me.txtLugarReferencia.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtLugarReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLugarReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLugarReferencia.Location = New System.Drawing.Point(136, 123)
        Me.txtLugarReferencia.MaxLength = 100
        Me.txtLugarReferencia.Name = "txtLugarReferencia"
        Me.txtLugarReferencia.Size = New System.Drawing.Size(250, 20)
        Me.txtLugarReferencia.TabIndex = 9
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Location = New System.Drawing.Point(136, 73)
        Me.txtTelefono.MaxLength = 100
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(250, 20)
        Me.txtTelefono.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(52, 126)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 242
        Me.Label14.Text = "Referencia"
        '
        'txtDireccionRemitente
        '
        Me.txtDireccionRemitente.BackColor = System.Drawing.Color.LightCyan
        Me.txtDireccionRemitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccionRemitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccionRemitente.Location = New System.Drawing.Point(136, 99)
        Me.txtDireccionRemitente.MaxLength = 100
        Me.txtDireccionRemitente.Name = "txtDireccionRemitente"
        Me.txtDireccionRemitente.Size = New System.Drawing.Size(604, 20)
        Me.txtDireccionRemitente.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Telefono"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(396, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 242
        Me.Label6.Text = "Distrito"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(515, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 13)
        Me.Label15.TabIndex = 242
        Me.Label15.Text = "NRO GUIA E.(F9)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 181)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 13)
        Me.Label17.TabIndex = 242
        Me.Label17.Text = "Responsable de Movil"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(521, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 242
        Me.Label9.Text = "Nro Solicitud"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(391, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 242
        Me.Label8.Text = "Estado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(604, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "F.Oper"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 242
        Me.Label2.Text = "Operador (Cliente)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 13)
        Me.Label1.TabIndex = 242
        Me.Label1.Text = "Direc. de Recojo (F1)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(25, 23)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 13)
        Me.Label21.TabIndex = 242
        Me.Label21.Text = "RUC/Cliente (F2)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(83, 211)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 248
        Me.Label18.Text = "Cantidad"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(283, 211)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 248
        Me.Label19.Text = "Peso"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(84, 232)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 13)
        Me.Label20.TabIndex = 248
        Me.Label20.Text = "OBS."
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(142, 231)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(604, 41)
        Me.txtObs.TabIndex = 249
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(142, 208)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(115, 20)
        Me.txtCantidad.TabIndex = 250
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(320, 208)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(72, 20)
        Me.txtPeso.TabIndex = 250
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(398, 211)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(20, 13)
        Me.Label22.TabIndex = 248
        Me.Label22.Text = "Kg"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(446, 211)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 13)
        Me.Label23.TabIndex = 248
        Me.Label23.Text = "Destino"
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(502, 208)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(244, 20)
        Me.txtDestino.TabIndex = 250
        '
        'FrmAtencionCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 330)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmAtencionCliente"
        Me.Opacity = 0.95
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud De Recojo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridViewDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRasonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtRuc As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionRemitente As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents dtFechaOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDistritos As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents txtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLugarReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDNIRemitente As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAtendido As System.Windows.Forms.ComboBox
    Friend WithEvents cmbResponsableMovil As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtHoraIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
