<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTarifasSubCuenta
    Inherits INTEGRACION.frmBaseVentas

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarifasSubCuenta))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmb_subcuenta = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.cmbFuncionario = New System.Windows.Forms.ComboBox()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.DataGridViewTarifa = New System.Windows.Forms.DataGridView()
        Me.btnVerData = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.lbNroRegistro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPrecioPostalVolumenFinal = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalVolumen = New System.Windows.Forms.TextBox()
        Me.txtPrecio_Sobre = New System.Windows.Forms.TextBox()
        Me.txtPrecio_Sobre_public = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalPesoFinal = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalPeso = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalFinal = New System.Windows.Forms.TextBox()
        Me.txtPrecioPostalBase = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.checkVigente = New System.Windows.Forms.CheckBox()
        Me.dtFecha_Activacion = New System.Windows.Forms.DateTimePicker()
        Me.cmbDestino_SubCta = New System.Windows.Forms.ComboBox()
        Me.cmbOrigen_SubCta = New System.Windows.Forms.ComboBox()
        Me.cmbCentroCosto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_masiva = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridViewTarifa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(726, 497)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(721, 521)
        '
        'TabLista
        '
        Me.TabLista.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabLista.Controls.Add(Me.btn_masiva)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.lbNroRegistro)
        Me.TabLista.Controls.Add(Me.btnAnular)
        Me.TabLista.Controls.Add(Me.btnCerrar)
        Me.TabLista.Controls.Add(Me.btnVerData)
        Me.TabLista.Controls.Add(Me.btnEditar)
        Me.TabLista.Controls.Add(Me.btnNuevo)
        Me.TabLista.Controls.Add(Me.DataGridViewTarifa)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Size = New System.Drawing.Size(713, 492)
        Me.TabLista.UseVisualStyleBackColor = False
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.GroupBox3)
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        Me.TabDatos.Size = New System.Drawing.Size(713, 492)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(713, 492)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(713, 492)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmb_subcuenta)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbDestino)
        Me.GroupBox1.Controls.Add(Me.cmbCliente)
        Me.GroupBox1.Controls.Add(Me.cmbFuncionario)
        Me.GroupBox1.Controls.Add(Me.cmbOrigen)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(707, 90)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'cmb_subcuenta
        '
        Me.cmb_subcuenta.BackColor = System.Drawing.SystemColors.HighlightText
        Me.cmb_subcuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_subcuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_subcuenta.FormattingEnabled = True
        Me.cmb_subcuenta.Location = New System.Drawing.Point(84, 64)
        Me.cmb_subcuenta.Name = "cmb_subcuenta"
        Me.cmb_subcuenta.Size = New System.Drawing.Size(323, 21)
        Me.cmb_subcuenta.TabIndex = 57
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(5, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "Sub Cuenta :"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(666, 61)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 22)
        Me.btnBuscar.TabIndex = 55
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(431, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Destino :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(5, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Funcionario :"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(431, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 13)
        Me.Label30.TabIndex = 53
        Me.Label30.Text = "Origen :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(3, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Razon Social :"
        '
        'cmbDestino
        '
        Me.cmbDestino.BackColor = System.Drawing.SystemColors.HighlightText
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Location = New System.Drawing.Point(492, 38)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(209, 21)
        Me.cmbDestino.TabIndex = 52
        '
        'cmbCliente
        '
        Me.cmbCliente.BackColor = System.Drawing.SystemColors.HighlightText
        Me.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(84, 37)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(323, 21)
        Me.cmbCliente.TabIndex = 51
        '
        'cmbFuncionario
        '
        Me.cmbFuncionario.BackColor = System.Drawing.SystemColors.HighlightText
        Me.cmbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFuncionario.FormattingEnabled = True
        Me.cmbFuncionario.Location = New System.Drawing.Point(84, 10)
        Me.cmbFuncionario.Name = "cmbFuncionario"
        Me.cmbFuncionario.Size = New System.Drawing.Size(323, 21)
        Me.cmbFuncionario.TabIndex = 51
        '
        'cmbOrigen
        '
        Me.cmbOrigen.BackColor = System.Drawing.SystemColors.HighlightText
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(492, 11)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(209, 21)
        Me.cmbOrigen.TabIndex = 51
        '
        'DataGridViewTarifa
        '
        Me.DataGridViewTarifa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridViewTarifa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTarifa.Location = New System.Drawing.Point(2, 96)
        Me.DataGridViewTarifa.Name = "DataGridViewTarifa"
        Me.DataGridViewTarifa.Size = New System.Drawing.Size(625, 350)
        Me.DataGridViewTarifa.TabIndex = 52
        '
        'btnVerData
        '
        Me.btnVerData.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnVerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerData.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnVerData.Location = New System.Drawing.Point(633, 164)
        Me.btnVerData.Name = "btnVerData"
        Me.btnVerData.Size = New System.Drawing.Size(72, 26)
        Me.btnVerData.TabIndex = 55
        Me.btnVerData.Text = "&Ver Data"
        Me.btnVerData.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEditar.Location = New System.Drawing.Point(634, 132)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(72, 26)
        Me.btnEditar.TabIndex = 54
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNuevo.Location = New System.Drawing.Point(634, 100)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 26)
        Me.btnNuevo.TabIndex = 53
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCerrar.Location = New System.Drawing.Point(631, 420)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(72, 26)
        Me.btnCerrar.TabIndex = 55
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnAnular
        '
        Me.btnAnular.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnular.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAnular.Location = New System.Drawing.Point(633, 196)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(72, 26)
        Me.btnAnular.TabIndex = 55
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'lbNroRegistro
        '
        Me.lbNroRegistro.AutoSize = True
        Me.lbNroRegistro.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistro.Location = New System.Drawing.Point(635, 290)
        Me.lbNroRegistro.Name = "lbNroRegistro"
        Me.lbNroRegistro.Size = New System.Drawing.Size(32, 13)
        Me.lbNroRegistro.TabIndex = 56
        Me.lbNroRegistro.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(633, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Nro Reg:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtPrecioPostalVolumenFinal)
        Me.GroupBox2.Controls.Add(Me.txtPrecioPostalVolumen)
        Me.GroupBox2.Controls.Add(Me.txtPrecio_Sobre)
        Me.GroupBox2.Controls.Add(Me.txtPrecio_Sobre_public)
        Me.GroupBox2.Controls.Add(Me.txtPrecioPostalPesoFinal)
        Me.GroupBox2.Controls.Add(Me.txtPrecioPostalPeso)
        Me.GroupBox2.Controls.Add(Me.txtPrecioPostalFinal)
        Me.GroupBox2.Controls.Add(Me.txtPrecioPostalBase)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.checkVigente)
        Me.GroupBox2.Controls.Add(Me.dtFecha_Activacion)
        Me.GroupBox2.Controls.Add(Me.cmbDestino_SubCta)
        Me.GroupBox2.Controls.Add(Me.cmbOrigen_SubCta)
        Me.GroupBox2.Controls.Add(Me.cmbCentroCosto)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtRuc)
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(699, 200)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtPrecioPostalVolumenFinal
        '
        Me.txtPrecioPostalVolumenFinal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtPrecioPostalVolumenFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalVolumenFinal.Location = New System.Drawing.Point(170, 175)
        Me.txtPrecioPostalVolumenFinal.Name = "txtPrecioPostalVolumenFinal"
        Me.txtPrecioPostalVolumenFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalVolumenFinal.TabIndex = 12
        Me.txtPrecioPostalVolumenFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalVolumen
        '
        Me.txtPrecioPostalVolumen.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioPostalVolumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalVolumen.Location = New System.Drawing.Point(103, 175)
        Me.txtPrecioPostalVolumen.Name = "txtPrecioPostalVolumen"
        Me.txtPrecioPostalVolumen.ReadOnly = True
        Me.txtPrecioPostalVolumen.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalVolumen.TabIndex = 8
        Me.txtPrecioPostalVolumen.TabStop = False
        Me.txtPrecioPostalVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio_Sobre
        '
        Me.txtPrecio_Sobre.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPrecio_Sobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio_Sobre.Location = New System.Drawing.Point(170, 127)
        Me.txtPrecio_Sobre.Name = "txtPrecio_Sobre"
        Me.txtPrecio_Sobre.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecio_Sobre.TabIndex = 11
        Me.txtPrecio_Sobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio_Sobre_public
        '
        Me.txtPrecio_Sobre_public.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecio_Sobre_public.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio_Sobre_public.Location = New System.Drawing.Point(103, 127)
        Me.txtPrecio_Sobre_public.Name = "txtPrecio_Sobre_public"
        Me.txtPrecio_Sobre_public.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecio_Sobre_public.TabIndex = 7
        Me.txtPrecio_Sobre_public.TabStop = False
        Me.txtPrecio_Sobre_public.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalPesoFinal
        '
        Me.txtPrecioPostalPesoFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalPesoFinal.Location = New System.Drawing.Point(170, 151)
        Me.txtPrecioPostalPesoFinal.Name = "txtPrecioPostalPesoFinal"
        Me.txtPrecioPostalPesoFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalPesoFinal.TabIndex = 11
        Me.txtPrecioPostalPesoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalPeso
        '
        Me.txtPrecioPostalPeso.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioPostalPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalPeso.Location = New System.Drawing.Point(103, 151)
        Me.txtPrecioPostalPeso.Name = "txtPrecioPostalPeso"
        Me.txtPrecioPostalPeso.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalPeso.TabIndex = 7
        Me.txtPrecioPostalPeso.TabStop = False
        Me.txtPrecioPostalPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalFinal
        '
        Me.txtPrecioPostalFinal.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPrecioPostalFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalFinal.Location = New System.Drawing.Point(170, 104)
        Me.txtPrecioPostalFinal.Name = "txtPrecioPostalFinal"
        Me.txtPrecioPostalFinal.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalFinal.TabIndex = 10
        Me.txtPrecioPostalFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioPostalBase
        '
        Me.txtPrecioPostalBase.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioPostalBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioPostalBase.Location = New System.Drawing.Point(103, 104)
        Me.txtPrecioPostalBase.Name = "txtPrecioPostalBase"
        Me.txtPrecioPostalBase.Size = New System.Drawing.Size(61, 20)
        Me.txtPrecioPostalBase.TabIndex = 9
        Me.txtPrecioPostalBase.TabStop = False
        Me.txtPrecioPostalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightGray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(550, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Actualizar Tarifario"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'checkVigente
        '
        Me.checkVigente.AutoSize = True
        Me.checkVigente.Location = New System.Drawing.Point(596, 170)
        Me.checkVigente.Name = "checkVigente"
        Me.checkVigente.Size = New System.Drawing.Size(87, 17)
        Me.checkVigente.TabIndex = 5
        Me.checkVigente.Text = "Es Vigente"
        Me.checkVigente.UseVisualStyleBackColor = True
        '
        'dtFecha_Activacion
        '
        Me.dtFecha_Activacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha_Activacion.Location = New System.Drawing.Point(471, 168)
        Me.dtFecha_Activacion.Name = "dtFecha_Activacion"
        Me.dtFecha_Activacion.Size = New System.Drawing.Size(104, 20)
        Me.dtFecha_Activacion.TabIndex = 4
        '
        'cmbDestino_SubCta
        '
        Me.cmbDestino_SubCta.FormattingEnabled = True
        Me.cmbDestino_SubCta.Location = New System.Drawing.Point(325, 37)
        Me.cmbDestino_SubCta.Name = "cmbDestino_SubCta"
        Me.cmbDestino_SubCta.Size = New System.Drawing.Size(161, 21)
        Me.cmbDestino_SubCta.TabIndex = 3
        '
        'cmbOrigen_SubCta
        '
        Me.cmbOrigen_SubCta.FormattingEnabled = True
        Me.cmbOrigen_SubCta.Location = New System.Drawing.Point(103, 38)
        Me.cmbOrigen_SubCta.Name = "cmbOrigen_SubCta"
        Me.cmbOrigen_SubCta.Size = New System.Drawing.Size(161, 21)
        Me.cmbOrigen_SubCta.TabIndex = 3
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.Location = New System.Drawing.Point(103, 63)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(232, 21)
        Me.cmbCentroCosto.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Precio x Sobre"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Precio x Vol"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Precio x Peso"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(172, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Costo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(106, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Publico"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Monto Base"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(359, 172)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Fecha Activacion"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(270, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Destino"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Centro de Costo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Cliente"
        '
        'txtRuc
        '
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Location = New System.Drawing.Point(531, 11)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(160, 20)
        Me.txtRuc.TabIndex = 1
        '
        'txtCliente
        '
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(104, 11)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(412, 20)
        Me.txtCliente.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.btnGrabar)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(-1, 399)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(706, 47)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.LightGray
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(566, 15)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(125, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "SALIR"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LightGray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(201, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(125, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "CANCELAR"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.LightGray
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Location = New System.Drawing.Point(16, 15)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(125, 23)
        Me.btnGrabar.TabIndex = 6
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(609, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 13)
        Me.Label15.TabIndex = 2
        '
        'btn_masiva
        '
        Me.btn_masiva.BackColor = System.Drawing.Color.RoyalBlue
        Me.btn_masiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_masiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_masiva.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_masiva.Location = New System.Drawing.Point(634, 230)
        Me.btn_masiva.Name = "btn_masiva"
        Me.btn_masiva.Size = New System.Drawing.Size(72, 26)
        Me.btn_masiva.TabIndex = 57
        Me.btn_masiva.Text = "&Masiva"
        Me.btn_masiva.UseVisualStyleBackColor = False
        '
        'FrmTarifasSubCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(715, 479)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmTarifasSubCuenta"
        Me.Text = "TARIFARIO SUB CUENTA"
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridViewTarifa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTarifa As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnVerData As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbNroRegistro As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents checkVigente As System.Windows.Forms.CheckBox
    Friend WithEvents dtFecha_Activacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtPrecioPostalVolumenFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio_Sobre As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio_Sobre_public As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalPesoFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioPostalBase As System.Windows.Forms.TextBox
    Friend WithEvents cmbDestino_SubCta As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen_SubCta As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn_masiva As System.Windows.Forms.Button
    Friend WithEvents cmb_subcuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
