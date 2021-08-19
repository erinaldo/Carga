<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedor))
        Me.tabProveedor = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.cboEstadoProveedor = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkActivoProveedor = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.btnCancelarProveedor = New System.Windows.Forms.Button()
        Me.btnGrabarProveedor = New System.Windows.Forms.Button()
        Me.btnModificarProveedor = New System.Windows.Forms.Button()
        Me.btnNuevoProveedor = New System.Windows.Forms.Button()
        Me.dgvListaProveedor = New System.Windows.Forms.DataGridView()
        Me.txtRazonSocialProveedor = New System.Windows.Forms.TextBox()
        Me.txtRucProveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cboModeloMovil = New System.Windows.Forms.ComboBox()
        Me.cboTipoMovil = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cboEstadoMovil = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnCancelarMovil = New System.Windows.Forms.Button()
        Me.btnGrabarMovil = New System.Windows.Forms.Button()
        Me.btnModificarMovil = New System.Windows.Forms.Button()
        Me.btnNuevoMovil = New System.Windows.Forms.Button()
        Me.dgvListaMovil = New System.Windows.Forms.DataGridView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCapacidadMovil = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkActivoMovil = New System.Windows.Forms.CheckBox()
        Me.txtPlacaMovil = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboEstadoChofer = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancelarChofer = New System.Windows.Forms.Button()
        Me.btnGrabarChofer = New System.Windows.Forms.Button()
        Me.btnModificarChofer = New System.Windows.Forms.Button()
        Me.btnNuevoChofer = New System.Windows.Forms.Button()
        Me.dgvListaChofer = New System.Windows.Forms.DataGridView()
        Me.txtLicenciaChofer = New System.Windows.Forms.TextBox()
        Me.lblLicencia = New System.Windows.Forms.Label()
        Me.chkActivoChofer = New System.Windows.Forms.CheckBox()
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNombresChofer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboEstadoAyudante = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnCancelarAyudante = New System.Windows.Forms.Button()
        Me.btnGrabarAyudante = New System.Windows.Forms.Button()
        Me.btnModificarAyudante = New System.Windows.Forms.Button()
        Me.btnNuevoAyudante = New System.Windows.Forms.Button()
        Me.dgvListaAyudante = New System.Windows.Forms.DataGridView()
        Me.chkActivoAyudante = New System.Windows.Forms.CheckBox()
        Me.txtApellidosAyudante = New System.Windows.Forms.TextBox()
        Me.txtNombresAyudante = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.tabProveedor.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel16.SuspendLayout()
        CType(Me.dgvListaProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvListaMovil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvListaChofer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvListaAyudante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabProveedor
        '
        Me.tabProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabProveedor.Controls.Add(Me.TabPage1)
        Me.tabProveedor.Controls.Add(Me.TabPage2)
        Me.tabProveedor.Controls.Add(Me.TabPage8)
        Me.tabProveedor.Controls.Add(Me.TabPage9)
        Me.tabProveedor.Location = New System.Drawing.Point(9, 22)
        Me.tabProveedor.Name = "tabProveedor"
        Me.tabProveedor.SelectedIndex = 0
        Me.tabProveedor.Size = New System.Drawing.Size(833, 453)
        Me.tabProveedor.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel18)
        Me.TabPage1.Controls.Add(Me.chkActivoProveedor)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Panel16)
        Me.TabPage1.Controls.Add(Me.dgvListaProveedor)
        Me.TabPage1.Controls.Add(Me.txtRazonSocialProveedor)
        Me.TabPage1.Controls.Add(Me.txtRucProveedor)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(825, 427)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Proveedor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel18
        '
        Me.Panel18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel18.Controls.Add(Me.cboEstadoProveedor)
        Me.Panel18.Controls.Add(Me.Label10)
        Me.Panel18.Location = New System.Drawing.Point(564, 109)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(245, 27)
        Me.Panel18.TabIndex = 223
        '
        'cboEstadoProveedor
        '
        Me.cboEstadoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoProveedor.FormattingEnabled = True
        Me.cboEstadoProveedor.Items.AddRange(New Object() {"(TODO)", "ACTIVO", "INACTIVO"})
        Me.cboEstadoProveedor.Location = New System.Drawing.Point(51, 3)
        Me.cboEstadoProveedor.Name = "cboEstadoProveedor"
        Me.cboEstadoProveedor.Size = New System.Drawing.Size(190, 21)
        Me.cboEstadoProveedor.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Estado"
        '
        'chkActivoProveedor
        '
        Me.chkActivoProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActivoProveedor.AutoSize = True
        Me.chkActivoProveedor.Location = New System.Drawing.Point(753, 21)
        Me.chkActivoProveedor.Name = "chkActivoProveedor"
        Me.chkActivoProveedor.Size = New System.Drawing.Size(56, 17)
        Me.chkActivoProveedor.TabIndex = 196
        Me.chkActivoProveedor.Text = "Activo"
        Me.chkActivoProveedor.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 13)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Lista de Proveedores"
        '
        'Panel16
        '
        Me.Panel16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel16.Controls.Add(Me.btnCancelarProveedor)
        Me.Panel16.Controls.Add(Me.btnGrabarProveedor)
        Me.Panel16.Controls.Add(Me.btnModificarProveedor)
        Me.Panel16.Controls.Add(Me.btnNuevoProveedor)
        Me.Panel16.Location = New System.Drawing.Point(11, 384)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(798, 35)
        Me.Panel16.TabIndex = 79
        '
        'btnCancelarProveedor
        '
        Me.btnCancelarProveedor.Location = New System.Drawing.Point(276, 3)
        Me.btnCancelarProveedor.Name = "btnCancelarProveedor"
        Me.btnCancelarProveedor.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelarProveedor.TabIndex = 24
        Me.btnCancelarProveedor.Text = "&Cancelar"
        Me.btnCancelarProveedor.UseVisualStyleBackColor = True
        '
        'btnGrabarProveedor
        '
        Me.btnGrabarProveedor.Location = New System.Drawing.Point(183, 3)
        Me.btnGrabarProveedor.Name = "btnGrabarProveedor"
        Me.btnGrabarProveedor.Size = New System.Drawing.Size(75, 29)
        Me.btnGrabarProveedor.TabIndex = 23
        Me.btnGrabarProveedor.Text = "&Grabar"
        Me.btnGrabarProveedor.UseVisualStyleBackColor = True
        '
        'btnModificarProveedor
        '
        Me.btnModificarProveedor.Location = New System.Drawing.Point(93, 3)
        Me.btnModificarProveedor.Name = "btnModificarProveedor"
        Me.btnModificarProveedor.Size = New System.Drawing.Size(75, 29)
        Me.btnModificarProveedor.TabIndex = 22
        Me.btnModificarProveedor.Text = "Modificar"
        Me.btnModificarProveedor.UseVisualStyleBackColor = True
        '
        'btnNuevoProveedor
        '
        Me.btnNuevoProveedor.Location = New System.Drawing.Point(5, 3)
        Me.btnNuevoProveedor.Name = "btnNuevoProveedor"
        Me.btnNuevoProveedor.Size = New System.Drawing.Size(75, 29)
        Me.btnNuevoProveedor.TabIndex = 21
        Me.btnNuevoProveedor.Text = "Nuevo"
        Me.btnNuevoProveedor.UseVisualStyleBackColor = True
        '
        'dgvListaProveedor
        '
        Me.dgvListaProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListaProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaProveedor.Location = New System.Drawing.Point(11, 142)
        Me.dgvListaProveedor.Name = "dgvListaProveedor"
        Me.dgvListaProveedor.Size = New System.Drawing.Size(798, 233)
        Me.dgvListaProveedor.TabIndex = 78
        '
        'txtRazonSocialProveedor
        '
        Me.txtRazonSocialProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRazonSocialProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocialProveedor.Location = New System.Drawing.Point(287, 57)
        Me.txtRazonSocialProveedor.MaxLength = 100
        Me.txtRazonSocialProveedor.Name = "txtRazonSocialProveedor"
        Me.txtRazonSocialProveedor.Size = New System.Drawing.Size(522, 20)
        Me.txtRazonSocialProveedor.TabIndex = 75
        '
        'txtRucProveedor
        '
        Me.txtRucProveedor.Location = New System.Drawing.Point(65, 57)
        Me.txtRucProveedor.MaxLength = 11
        Me.txtRucProveedor.Name = "txtRucProveedor"
        Me.txtRucProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtRucProveedor.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Razón Social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Ruc"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cboModeloMovil)
        Me.TabPage2.Controls.Add(Me.cboTipoMovil)
        Me.TabPage2.Controls.Add(Me.Panel5)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Panel6)
        Me.TabPage2.Controls.Add(Me.dgvListaMovil)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtCapacidadMovil)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.chkActivoMovil)
        Me.TabPage2.Controls.Add(Me.txtPlacaMovil)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(825, 427)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Móvil"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cboModeloMovil
        '
        Me.cboModeloMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModeloMovil.FormattingEnabled = True
        Me.cboModeloMovil.Location = New System.Drawing.Point(536, 51)
        Me.cboModeloMovil.Name = "cboModeloMovil"
        Me.cboModeloMovil.Size = New System.Drawing.Size(200, 21)
        Me.cboModeloMovil.TabIndex = 239
        '
        'cboTipoMovil
        '
        Me.cboTipoMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovil.FormattingEnabled = True
        Me.cboTipoMovil.Location = New System.Drawing.Point(252, 51)
        Me.cboTipoMovil.Name = "cboTipoMovil"
        Me.cboTipoMovil.Size = New System.Drawing.Size(200, 21)
        Me.cboTipoMovil.TabIndex = 239
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.Controls.Add(Me.cboEstadoMovil)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Location = New System.Drawing.Point(568, 108)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(245, 27)
        Me.Panel5.TabIndex = 238
        '
        'cboEstadoMovil
        '
        Me.cboEstadoMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoMovil.FormattingEnabled = True
        Me.cboEstadoMovil.Items.AddRange(New Object() {"(TODO)", "ACTIVO", "INACTIVO"})
        Me.cboEstadoMovil.Location = New System.Drawing.Point(51, 3)
        Me.cboEstadoMovil.Name = "cboEstadoMovil"
        Me.cboEstadoMovil.Size = New System.Drawing.Size(190, 21)
        Me.cboEstadoMovil.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Estado"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 121)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 237
        Me.Label14.Text = "Lista de Móviles"
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.btnCancelarMovil)
        Me.Panel6.Controls.Add(Me.btnGrabarMovil)
        Me.Panel6.Controls.Add(Me.btnModificarMovil)
        Me.Panel6.Controls.Add(Me.btnNuevoMovil)
        Me.Panel6.Location = New System.Drawing.Point(15, 383)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(798, 35)
        Me.Panel6.TabIndex = 236
        '
        'btnCancelarMovil
        '
        Me.btnCancelarMovil.Location = New System.Drawing.Point(276, 3)
        Me.btnCancelarMovil.Name = "btnCancelarMovil"
        Me.btnCancelarMovil.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelarMovil.TabIndex = 24
        Me.btnCancelarMovil.Text = "&Cancelar"
        Me.btnCancelarMovil.UseVisualStyleBackColor = True
        '
        'btnGrabarMovil
        '
        Me.btnGrabarMovil.Location = New System.Drawing.Point(183, 3)
        Me.btnGrabarMovil.Name = "btnGrabarMovil"
        Me.btnGrabarMovil.Size = New System.Drawing.Size(75, 29)
        Me.btnGrabarMovil.TabIndex = 23
        Me.btnGrabarMovil.Text = "&Grabar"
        Me.btnGrabarMovil.UseVisualStyleBackColor = True
        '
        'btnModificarMovil
        '
        Me.btnModificarMovil.Location = New System.Drawing.Point(93, 3)
        Me.btnModificarMovil.Name = "btnModificarMovil"
        Me.btnModificarMovil.Size = New System.Drawing.Size(75, 29)
        Me.btnModificarMovil.TabIndex = 22
        Me.btnModificarMovil.Text = "Modificar"
        Me.btnModificarMovil.UseVisualStyleBackColor = True
        '
        'btnNuevoMovil
        '
        Me.btnNuevoMovil.Location = New System.Drawing.Point(5, 3)
        Me.btnNuevoMovil.Name = "btnNuevoMovil"
        Me.btnNuevoMovil.Size = New System.Drawing.Size(75, 29)
        Me.btnNuevoMovil.TabIndex = 21
        Me.btnNuevoMovil.Text = "Nuevo"
        Me.btnNuevoMovil.UseVisualStyleBackColor = True
        '
        'dgvListaMovil
        '
        Me.dgvListaMovil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListaMovil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaMovil.Location = New System.Drawing.Point(15, 141)
        Me.dgvListaMovil.Name = "dgvListaMovil"
        Me.dgvListaMovil.Size = New System.Drawing.Size(798, 233)
        Me.dgvListaMovil.TabIndex = 235
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(486, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 13)
        Me.Label18.TabIndex = 234
        Me.Label18.Text = "Modelo"
        '
        'txtCapacidadMovil
        '
        Me.txtCapacidadMovil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapacidadMovil.Location = New System.Drawing.Point(86, 52)
        Me.txtCapacidadMovil.MaxLength = 5
        Me.txtCapacidadMovil.Name = "txtCapacidadMovil"
        Me.txtCapacidadMovil.Size = New System.Drawing.Size(97, 20)
        Me.txtCapacidadMovil.TabIndex = 230
        Me.txtCapacidadMovil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(215, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(28, 13)
        Me.Label16.TabIndex = 234
        Me.Label16.Text = "Tipo"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 234
        Me.Label15.Text = "Capacidad"
        '
        'chkActivoMovil
        '
        Me.chkActivoMovil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActivoMovil.AutoSize = True
        Me.chkActivoMovil.Location = New System.Drawing.Point(757, 18)
        Me.chkActivoMovil.Name = "chkActivoMovil"
        Me.chkActivoMovil.Size = New System.Drawing.Size(56, 17)
        Me.chkActivoMovil.TabIndex = 233
        Me.chkActivoMovil.Text = "Activo"
        Me.chkActivoMovil.UseVisualStyleBackColor = True
        '
        'txtPlacaMovil
        '
        Me.txtPlacaMovil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlacaMovil.Location = New System.Drawing.Point(86, 18)
        Me.txtPlacaMovil.MaxLength = 15
        Me.txtPlacaMovil.Name = "txtPlacaMovil"
        Me.txtPlacaMovil.Size = New System.Drawing.Size(97, 20)
        Me.txtPlacaMovil.TabIndex = 228
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 232
        Me.Label17.Text = "Nº Placa"
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.txtContraseña)
        Me.TabPage8.Controls.Add(Me.Label19)
        Me.TabPage8.Controls.Add(Me.txtUsuario)
        Me.TabPage8.Controls.Add(Me.Label20)
        Me.TabPage8.Controls.Add(Me.Panel1)
        Me.TabPage8.Controls.Add(Me.Label6)
        Me.TabPage8.Controls.Add(Me.Panel2)
        Me.TabPage8.Controls.Add(Me.dgvListaChofer)
        Me.TabPage8.Controls.Add(Me.txtLicenciaChofer)
        Me.TabPage8.Controls.Add(Me.lblLicencia)
        Me.TabPage8.Controls.Add(Me.chkActivoChofer)
        Me.TabPage8.Controls.Add(Me.txtApellidoMaterno)
        Me.TabPage8.Controls.Add(Me.txtApellidoPaterno)
        Me.TabPage8.Controls.Add(Me.Label21)
        Me.TabPage8.Controls.Add(Me.txtNombresChofer)
        Me.TabPage8.Controls.Add(Me.Label3)
        Me.TabPage8.Controls.Add(Me.Label4)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(825, 427)
        Me.TabPage8.TabIndex = 2
        Me.TabPage8.Text = "Chofer"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(374, 78)
        Me.txtContraseña.MaxLength = 15
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(209, 20)
        Me.txtContraseña.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(304, 81)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 13)
        Me.Label19.TabIndex = 229
        Me.Label19.Text = "Contraseña"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(81, 78)
        Me.txtUsuario.MaxLength = 15
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(209, 20)
        Me.txtUsuario.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 82)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 13)
        Me.Label20.TabIndex = 228
        Me.Label20.Text = "Usuario"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cboEstadoChofer)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(563, 111)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(245, 27)
        Me.Panel1.TabIndex = 227
        '
        'cboEstadoChofer
        '
        Me.cboEstadoChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoChofer.FormattingEnabled = True
        Me.cboEstadoChofer.Items.AddRange(New Object() {"(TODO)", "ACTIVO", "INACTIVO"})
        Me.cboEstadoChofer.Location = New System.Drawing.Point(51, 3)
        Me.cboEstadoChofer.Name = "cboEstadoChofer"
        Me.cboEstadoChofer.Size = New System.Drawing.Size(190, 21)
        Me.cboEstadoChofer.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Estado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "Lista de Choferes"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnCancelarChofer)
        Me.Panel2.Controls.Add(Me.btnGrabarChofer)
        Me.Panel2.Controls.Add(Me.btnModificarChofer)
        Me.Panel2.Controls.Add(Me.btnNuevoChofer)
        Me.Panel2.Location = New System.Drawing.Point(10, 386)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(798, 35)
        Me.Panel2.TabIndex = 225
        '
        'btnCancelarChofer
        '
        Me.btnCancelarChofer.Location = New System.Drawing.Point(276, 3)
        Me.btnCancelarChofer.Name = "btnCancelarChofer"
        Me.btnCancelarChofer.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelarChofer.TabIndex = 24
        Me.btnCancelarChofer.Text = "&Cancelar"
        Me.btnCancelarChofer.UseVisualStyleBackColor = True
        '
        'btnGrabarChofer
        '
        Me.btnGrabarChofer.Location = New System.Drawing.Point(183, 3)
        Me.btnGrabarChofer.Name = "btnGrabarChofer"
        Me.btnGrabarChofer.Size = New System.Drawing.Size(75, 29)
        Me.btnGrabarChofer.TabIndex = 23
        Me.btnGrabarChofer.Text = "&Grabar"
        Me.btnGrabarChofer.UseVisualStyleBackColor = True
        '
        'btnModificarChofer
        '
        Me.btnModificarChofer.Location = New System.Drawing.Point(93, 3)
        Me.btnModificarChofer.Name = "btnModificarChofer"
        Me.btnModificarChofer.Size = New System.Drawing.Size(75, 29)
        Me.btnModificarChofer.TabIndex = 22
        Me.btnModificarChofer.Text = "Modificar"
        Me.btnModificarChofer.UseVisualStyleBackColor = True
        '
        'btnNuevoChofer
        '
        Me.btnNuevoChofer.Location = New System.Drawing.Point(5, 3)
        Me.btnNuevoChofer.Name = "btnNuevoChofer"
        Me.btnNuevoChofer.Size = New System.Drawing.Size(75, 29)
        Me.btnNuevoChofer.TabIndex = 21
        Me.btnNuevoChofer.Text = "Nuevo"
        Me.btnNuevoChofer.UseVisualStyleBackColor = True
        '
        'dgvListaChofer
        '
        Me.dgvListaChofer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListaChofer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaChofer.Location = New System.Drawing.Point(10, 144)
        Me.dgvListaChofer.Name = "dgvListaChofer"
        Me.dgvListaChofer.Size = New System.Drawing.Size(798, 233)
        Me.dgvListaChofer.TabIndex = 224
        '
        'txtLicenciaChofer
        '
        Me.txtLicenciaChofer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLicenciaChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLicenciaChofer.Location = New System.Drawing.Point(694, 46)
        Me.txtLicenciaChofer.MaxLength = 15
        Me.txtLicenciaChofer.Name = "txtLicenciaChofer"
        Me.txtLicenciaChofer.Size = New System.Drawing.Size(114, 20)
        Me.txtLicenciaChofer.TabIndex = 3
        '
        'lblLicencia
        '
        Me.lblLicencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLicencia.AutoSize = True
        Me.lblLicencia.Location = New System.Drawing.Point(624, 49)
        Me.lblLicencia.Name = "lblLicencia"
        Me.lblLicencia.Size = New System.Drawing.Size(62, 13)
        Me.lblLicencia.TabIndex = 202
        Me.lblLicencia.Text = "Nº Licencia"
        '
        'chkActivoChofer
        '
        Me.chkActivoChofer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActivoChofer.AutoSize = True
        Me.chkActivoChofer.Location = New System.Drawing.Point(752, 15)
        Me.chkActivoChofer.Name = "chkActivoChofer"
        Me.chkActivoChofer.Size = New System.Drawing.Size(56, 17)
        Me.chkActivoChofer.TabIndex = 201
        Me.chkActivoChofer.Text = "Activo"
        Me.chkActivoChofer.UseVisualStyleBackColor = True
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(374, 46)
        Me.txtApellidoMaterno.MaxLength = 100
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(209, 20)
        Me.txtApellidoMaterno.TabIndex = 2
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(81, 46)
        Me.txtApellidoPaterno.MaxLength = 100
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(209, 20)
        Me.txtApellidoPaterno.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(304, 49)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 13)
        Me.Label21.TabIndex = 197
        Me.Label21.Text = "Apellido Mat."
        '
        'txtNombresChofer
        '
        Me.txtNombresChofer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombresChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombresChofer.Location = New System.Drawing.Point(81, 14)
        Me.txtNombresChofer.MaxLength = 40
        Me.txtNombresChofer.Name = "txtNombresChofer"
        Me.txtNombresChofer.Size = New System.Drawing.Size(502, 20)
        Me.txtNombresChofer.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 197
        Me.Label3.Text = "Apellido Pat."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 198
        Me.Label4.Text = "Nombres"
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.Panel3)
        Me.TabPage9.Controls.Add(Me.Label12)
        Me.TabPage9.Controls.Add(Me.Panel4)
        Me.TabPage9.Controls.Add(Me.dgvListaAyudante)
        Me.TabPage9.Controls.Add(Me.chkActivoAyudante)
        Me.TabPage9.Controls.Add(Me.txtApellidosAyudante)
        Me.TabPage9.Controls.Add(Me.txtNombresAyudante)
        Me.TabPage9.Controls.Add(Me.Label8)
        Me.TabPage9.Controls.Add(Me.Label11)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(825, 427)
        Me.TabPage9.TabIndex = 3
        Me.TabPage9.Text = "Ayudante"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.cboEstadoAyudante)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(566, 110)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(245, 27)
        Me.Panel3.TabIndex = 231
        '
        'cboEstadoAyudante
        '
        Me.cboEstadoAyudante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoAyudante.FormattingEnabled = True
        Me.cboEstadoAyudante.Items.AddRange(New Object() {"(TODO)", "ACTIVO", "INACTIVO"})
        Me.cboEstadoAyudante.Location = New System.Drawing.Point(51, 3)
        Me.cboEstadoAyudante.Name = "cboEstadoAyudante"
        Me.cboEstadoAyudante.Size = New System.Drawing.Size(190, 21)
        Me.cboEstadoAyudante.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Estado"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 13)
        Me.Label12.TabIndex = 230
        Me.Label12.Text = "Lista de Ayudantes"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.btnCancelarAyudante)
        Me.Panel4.Controls.Add(Me.btnGrabarAyudante)
        Me.Panel4.Controls.Add(Me.btnModificarAyudante)
        Me.Panel4.Controls.Add(Me.btnNuevoAyudante)
        Me.Panel4.Location = New System.Drawing.Point(13, 385)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(798, 35)
        Me.Panel4.TabIndex = 229
        '
        'btnCancelarAyudante
        '
        Me.btnCancelarAyudante.Location = New System.Drawing.Point(276, 3)
        Me.btnCancelarAyudante.Name = "btnCancelarAyudante"
        Me.btnCancelarAyudante.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelarAyudante.TabIndex = 24
        Me.btnCancelarAyudante.Text = "&Cancelar"
        Me.btnCancelarAyudante.UseVisualStyleBackColor = True
        '
        'btnGrabarAyudante
        '
        Me.btnGrabarAyudante.Location = New System.Drawing.Point(183, 3)
        Me.btnGrabarAyudante.Name = "btnGrabarAyudante"
        Me.btnGrabarAyudante.Size = New System.Drawing.Size(75, 29)
        Me.btnGrabarAyudante.TabIndex = 23
        Me.btnGrabarAyudante.Text = "&Grabar"
        Me.btnGrabarAyudante.UseVisualStyleBackColor = True
        '
        'btnModificarAyudante
        '
        Me.btnModificarAyudante.Location = New System.Drawing.Point(93, 3)
        Me.btnModificarAyudante.Name = "btnModificarAyudante"
        Me.btnModificarAyudante.Size = New System.Drawing.Size(75, 29)
        Me.btnModificarAyudante.TabIndex = 22
        Me.btnModificarAyudante.Text = "Modificar"
        Me.btnModificarAyudante.UseVisualStyleBackColor = True
        '
        'btnNuevoAyudante
        '
        Me.btnNuevoAyudante.Location = New System.Drawing.Point(5, 3)
        Me.btnNuevoAyudante.Name = "btnNuevoAyudante"
        Me.btnNuevoAyudante.Size = New System.Drawing.Size(75, 29)
        Me.btnNuevoAyudante.TabIndex = 21
        Me.btnNuevoAyudante.Text = "Nuevo"
        Me.btnNuevoAyudante.UseVisualStyleBackColor = True
        '
        'dgvListaAyudante
        '
        Me.dgvListaAyudante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListaAyudante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaAyudante.Location = New System.Drawing.Point(13, 143)
        Me.dgvListaAyudante.Name = "dgvListaAyudante"
        Me.dgvListaAyudante.Size = New System.Drawing.Size(798, 233)
        Me.dgvListaAyudante.TabIndex = 228
        '
        'chkActivoAyudante
        '
        Me.chkActivoAyudante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActivoAyudante.AutoSize = True
        Me.chkActivoAyudante.Location = New System.Drawing.Point(755, 19)
        Me.chkActivoAyudante.Name = "chkActivoAyudante"
        Me.chkActivoAyudante.Size = New System.Drawing.Size(56, 17)
        Me.chkActivoAyudante.TabIndex = 208
        Me.chkActivoAyudante.Text = "Activo"
        Me.chkActivoAyudante.UseVisualStyleBackColor = True
        '
        'txtApellidosAyudante
        '
        Me.txtApellidosAyudante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApellidosAyudante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidosAyudante.Location = New System.Drawing.Point(84, 56)
        Me.txtApellidosAyudante.MaxLength = 100
        Me.txtApellidosAyudante.Name = "txtApellidosAyudante"
        Me.txtApellidosAyudante.Size = New System.Drawing.Size(502, 20)
        Me.txtApellidosAyudante.TabIndex = 204
        '
        'txtNombresAyudante
        '
        Me.txtNombresAyudante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombresAyudante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombresAyudante.Location = New System.Drawing.Point(84, 19)
        Me.txtNombresAyudante.MaxLength = 100
        Me.txtNombresAyudante.Name = "txtNombresAyudante"
        Me.txtNombresAyudante.Size = New System.Drawing.Size(502, 20)
        Me.txtNombresAyudante.TabIndex = 203
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "Apellidos"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 207
        Me.Label11.Text = "Nombres"
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.Controls.Add(Me.btnSalir)
        Me.Panel11.Location = New System.Drawing.Point(764, 5)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(78, 31)
        Me.Panel11.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(5, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(69, 31)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 482)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.tabProveedor)
        Me.Name = "frmProveedor"
        Me.Text = "Proveedor"
        Me.tabProveedor.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        CType(Me.dgvListaProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.dgvListaMovil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvListaChofer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvListaAyudante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabProveedor As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvListaProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents txtRazonSocialProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtRucProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarProveedor As System.Windows.Forms.Button
    Friend WithEvents btnGrabarProveedor As System.Windows.Forms.Button
    Friend WithEvents btnModificarProveedor As System.Windows.Forms.Button
    Friend WithEvents btnNuevoProveedor As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents chkActivoProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents cboEstadoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkActivoChofer As System.Windows.Forms.CheckBox
    Friend WithEvents txtApellidoPaterno As System.Windows.Forms.TextBox
    Friend WithEvents txtNombresChofer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboEstadoChofer As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarChofer As System.Windows.Forms.Button
    Friend WithEvents btnGrabarChofer As System.Windows.Forms.Button
    Friend WithEvents btnModificarChofer As System.Windows.Forms.Button
    Friend WithEvents btnNuevoChofer As System.Windows.Forms.Button
    Friend WithEvents dgvListaChofer As System.Windows.Forms.DataGridView
    Friend WithEvents txtLicenciaChofer As System.Windows.Forms.TextBox
    Friend WithEvents lblLicencia As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cboEstadoAyudante As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarAyudante As System.Windows.Forms.Button
    Friend WithEvents btnGrabarAyudante As System.Windows.Forms.Button
    Friend WithEvents btnModificarAyudante As System.Windows.Forms.Button
    Friend WithEvents btnNuevoAyudante As System.Windows.Forms.Button
    Friend WithEvents dgvListaAyudante As System.Windows.Forms.DataGridView
    Friend WithEvents chkActivoAyudante As System.Windows.Forms.CheckBox
    Friend WithEvents txtApellidosAyudante As System.Windows.Forms.TextBox
    Friend WithEvents txtNombresAyudante As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboModeloMovil As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoMovil As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents cboEstadoMovil As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarMovil As System.Windows.Forms.Button
    Friend WithEvents btnGrabarMovil As System.Windows.Forms.Button
    Friend WithEvents btnModificarMovil As System.Windows.Forms.Button
    Friend WithEvents btnNuevoMovil As System.Windows.Forms.Button
    Friend WithEvents dgvListaMovil As System.Windows.Forms.DataGridView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCapacidadMovil As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkActivoMovil As System.Windows.Forms.CheckBox
    Friend WithEvents txtPlacaMovil As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtApellidoMaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
