Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Image
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmunidadtransporte
    Inherits INTEGRACION.FrmPlantillaunidadtransporte

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmunidadtransporte))
        Me.TxtUnidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtplaca = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txteje = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpisos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtbanios = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttv = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbResponsable = New System.Windows.Forms.ComboBox()
        Me.cmbmodelo = New System.Windows.Forms.ComboBox()
        Me.Cmbtipounidadm = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btntipo_servicio = New System.Windows.Forms.Button()
        Me.cmbtipo_servicio = New System.Windows.Forms.ComboBox()
        Me.txtcerhabilitavehicular = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Btntipounidad = New System.Windows.Forms.Button()
        Me.btnmodelo = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRecojo = New System.Windows.Forms.CheckBox()
        Me.Labcapacidad = New System.Windows.Forms.Label()
        Me.txtcapacidad = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtcargamaxima = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtpesounidad = New System.Windows.Forms.TextBox()
        Me.btnbus = New System.Windows.Forms.Button()
        Me.btnAgregaagencia = New System.Windows.Forms.Button()
        Me.DGVAsociaagencia = New System.Windows.Forms.DataGridView()
        Me.Labplaca = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Labnrounidad = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbTipounidad = New System.Windows.Forms.ComboBox()
        Me.Txtidunitransporte = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BTNeliminar = New System.Windows.Forms.Button()
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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGVAsociaagencia, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.TextBox9)
        Me.TabLista.Controls.Add(Me.CmbTipounidad)
        Me.TabLista.Controls.Add(Me.Labplaca)
        Me.TabLista.Controls.Add(Me.Label12)
        Me.TabLista.Controls.Add(Me.Labnrounidad)
        Me.TabLista.Controls.Add(Me.TextBox10)
        Me.TabLista.Controls.SetChildIndex(Me.TextBox10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Labnrounidad, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Labplaca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CmbTipounidad, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TextBox9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LabeloSCAR, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.BTNeliminar)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.Txtidunitransporte)
        Me.TabDatos.Controls.Add(Me.DGVAsociaagencia)
        Me.TabDatos.Controls.Add(Me.btnAgregaagencia)
        Me.TabDatos.Controls.Add(Me.btnbus)
        Me.TabDatos.Controls.Add(Me.CmbResponsable)
        Me.TabDatos.Controls.Add(Me.Label3)
        Me.TabDatos.Controls.Add(Me.TxtUnidad)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(64, 11)
        Me.TxtBusca.Visible = False
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        Me.TreeLista.Location = New System.Drawing.Point(3, 18)
        Me.TreeLista.Size = New System.Drawing.Size(184, 502)
        '
        'TxtUnidad
        '
        Me.TxtUnidad.Location = New System.Drawing.Point(120, 75)
        Me.TxtUnidad.MaxLength = 4
        Me.TxtUnidad.Name = "TxtUnidad"
        Me.TxtUnidad.Size = New System.Drawing.Size(76, 20)
        Me.TxtUnidad.TabIndex = 2
        Me.TxtUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Unidad : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Placa :"
        '
        'Txtplaca
        '
        Me.Txtplaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtplaca.Location = New System.Drawing.Point(114, 42)
        Me.Txtplaca.MaxLength = 6
        Me.Txtplaca.Name = "Txtplaca"
        Me.Txtplaca.Size = New System.Drawing.Size(76, 20)
        Me.Txtplaca.TabIndex = 4
        Me.Txtplaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(346, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nº Ejes :"
        '
        'txteje
        '
        Me.txteje.Location = New System.Drawing.Point(410, 14)
        Me.txteje.MaxLength = 2
        Me.txteje.Name = "txteje"
        Me.txteje.Size = New System.Drawing.Size(62, 20)
        Me.txteje.TabIndex = 7
        Me.txteje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(268, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Modelo : "
        '
        'txtpisos
        '
        Me.txtpisos.Location = New System.Drawing.Point(114, 36)
        Me.txtpisos.MaxLength = 1
        Me.txtpisos.Name = "txtpisos"
        Me.txtpisos.Size = New System.Drawing.Size(62, 20)
        Me.txtpisos.TabIndex = 8
        Me.txtpisos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(253, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tipo unidad : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(12, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Nº pisos : "
        '
        'txtbanios
        '
        Me.txtbanios.Location = New System.Drawing.Point(410, 36)
        Me.txtbanios.MaxLength = 1
        Me.txtbanios.Name = "txtbanios"
        Me.txtbanios.Size = New System.Drawing.Size(62, 20)
        Me.txtbanios.TabIndex = 12
        Me.txtbanios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(204, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Nº Tv. : "
        '
        'txttv
        '
        Me.txttv.Location = New System.Drawing.Point(257, 36)
        Me.txttv.MaxLength = 2
        Me.txttv.Name = "txttv"
        Me.txttv.Size = New System.Drawing.Size(62, 20)
        Me.txttv.TabIndex = 9
        Me.txttv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(17, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Responsable : "
        '
        'CmbResponsable
        '
        Me.CmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbResponsable.FormattingEnabled = True
        Me.CmbResponsable.Location = New System.Drawing.Point(120, 35)
        Me.CmbResponsable.Name = "CmbResponsable"
        Me.CmbResponsable.Size = New System.Drawing.Size(358, 21)
        Me.CmbResponsable.TabIndex = 1
        '
        'cmbmodelo
        '
        Me.cmbmodelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmodelo.DropDownWidth = 161
        Me.cmbmodelo.FormattingEnabled = True
        Me.cmbmodelo.Location = New System.Drawing.Point(331, 41)
        Me.cmbmodelo.Name = "cmbmodelo"
        Me.cmbmodelo.Size = New System.Drawing.Size(141, 21)
        Me.cmbmodelo.TabIndex = 5
        '
        'Cmbtipounidadm
        '
        Me.Cmbtipounidadm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbtipounidadm.DropDownWidth = 161
        Me.Cmbtipounidadm.FormattingEnabled = True
        Me.Cmbtipounidadm.Location = New System.Drawing.Point(331, 12)
        Me.Cmbtipounidadm.Name = "Cmbtipounidadm"
        Me.Cmbtipounidadm.Size = New System.Drawing.Size(141, 21)
        Me.Cmbtipounidadm.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.btntipo_servicio)
        Me.GroupBox1.Controls.Add(Me.cmbtipo_servicio)
        Me.GroupBox1.Controls.Add(Me.txtcerhabilitavehicular)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Btntipounidad)
        Me.GroupBox1.Controls.Add(Me.btnmodelo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbmodelo)
        Me.GroupBox1.Controls.Add(Me.Cmbtipounidadm)
        Me.GroupBox1.Controls.Add(Me.Txtplaca)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(509, 99)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(247, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Tipo Servicio : "
        '
        'btntipo_servicio
        '
        Me.btntipo_servicio.Location = New System.Drawing.Point(478, 66)
        Me.btntipo_servicio.Name = "btntipo_servicio"
        Me.btntipo_servicio.Size = New System.Drawing.Size(24, 23)
        Me.btntipo_servicio.TabIndex = 17
        Me.btntipo_servicio.UseVisualStyleBackColor = True
        '
        'cmbtipo_servicio
        '
        Me.cmbtipo_servicio.DropDownWidth = 161
        Me.cmbtipo_servicio.FormattingEnabled = True
        Me.cmbtipo_servicio.Location = New System.Drawing.Point(331, 69)
        Me.cmbtipo_servicio.Name = "cmbtipo_servicio"
        Me.cmbtipo_servicio.Size = New System.Drawing.Size(141, 21)
        Me.cmbtipo_servicio.TabIndex = 16
        '
        'txtcerhabilitavehicular
        '
        Me.txtcerhabilitavehicular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcerhabilitavehicular.Location = New System.Drawing.Point(114, 67)
        Me.txtcerhabilitavehicular.MaxLength = 20
        Me.txtcerhabilitavehicular.Name = "txtcerhabilitavehicular"
        Me.txtcerhabilitavehicular.Size = New System.Drawing.Size(85, 20)
        Me.txtcerhabilitavehicular.TabIndex = 15
        Me.txtcerhabilitavehicular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(12, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 30)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Cert. Habilitación Vehicular :"
        '
        'Btntipounidad
        '
        Me.Btntipounidad.Image = CType(resources.GetObject("Btntipounidad.Image"), System.Drawing.Image)
        Me.Btntipounidad.Location = New System.Drawing.Point(478, 12)
        Me.Btntipounidad.Name = "Btntipounidad"
        Me.Btntipounidad.Size = New System.Drawing.Size(24, 23)
        Me.Btntipounidad.TabIndex = 13
        Me.Btntipounidad.UseVisualStyleBackColor = True
        '
        'btnmodelo
        '
        Me.btnmodelo.Location = New System.Drawing.Point(478, 40)
        Me.btnmodelo.Name = "btnmodelo"
        Me.btnmodelo.Size = New System.Drawing.Size(24, 23)
        Me.btnmodelo.TabIndex = 12
        Me.btnmodelo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(346, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Nº Baños :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.chkRecojo)
        Me.GroupBox2.Controls.Add(Me.Labcapacidad)
        Me.GroupBox2.Controls.Add(Me.txtcapacidad)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtcargamaxima)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtpesounidad)
        Me.GroupBox2.Controls.Add(Me.txttv)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtpisos)
        Me.GroupBox2.Controls.Add(Me.txteje)
        Me.GroupBox2.Controls.Add(Me.txtbanios)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 123)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'chkRecojo
        '
        Me.chkRecojo.AutoSize = True
        Me.chkRecojo.Location = New System.Drawing.Point(209, 91)
        Me.chkRecojo.Name = "chkRecojo"
        Me.chkRecojo.Size = New System.Drawing.Size(60, 17)
        Me.chkRecojo.TabIndex = 29
        Me.chkRecojo.Text = "Recojo"
        Me.chkRecojo.UseVisualStyleBackColor = True
        '
        'Labcapacidad
        '
        Me.Labcapacidad.AutoSize = True
        Me.Labcapacidad.Location = New System.Drawing.Point(11, 18)
        Me.Labcapacidad.Name = "Labcapacidad"
        Me.Labcapacidad.Size = New System.Drawing.Size(67, 13)
        Me.Labcapacidad.TabIndex = 28
        Me.Labcapacidad.Text = "Capacidad : "
        '
        'txtcapacidad
        '
        Me.txtcapacidad.Location = New System.Drawing.Point(114, 14)
        Me.txtcapacidad.MaxLength = 3
        Me.txtcapacidad.Name = "txtcapacidad"
        Me.txtcapacidad.Size = New System.Drawing.Size(62, 20)
        Me.txtcapacidad.TabIndex = 6
        Me.txtcapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(302, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Carga Máxima (Kg) : "
        '
        'txtcargamaxima
        '
        Me.txtcargamaxima.Location = New System.Drawing.Point(410, 59)
        Me.txtcargamaxima.MaxLength = 8
        Me.txtcargamaxima.Name = "txtcargamaxima"
        Me.txtcargamaxima.Size = New System.Drawing.Size(62, 20)
        Me.txtcargamaxima.TabIndex = 25
        Me.txtcargamaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(11, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Peso Unidad (Tm) :"
        '
        'txtpesounidad
        '
        Me.txtpesounidad.Location = New System.Drawing.Point(114, 59)
        Me.txtpesounidad.MaxLength = 8
        Me.txtpesounidad.Name = "txtpesounidad"
        Me.txtpesounidad.Size = New System.Drawing.Size(62, 20)
        Me.txtpesounidad.TabIndex = 23
        Me.txtpesounidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnbus
        '
        Me.btnbus.BackColor = System.Drawing.Color.Transparent
        Me.btnbus.Location = New System.Drawing.Point(101, 302)
        Me.btnbus.Name = "btnbus"
        Me.btnbus.Size = New System.Drawing.Size(75, 23)
        Me.btnbus.TabIndex = 23
        Me.btnbus.Text = "Bus..."
        Me.btnbus.UseVisualStyleBackColor = False
        Me.btnbus.Visible = False
        '
        'btnAgregaagencia
        '
        Me.btnAgregaagencia.BackColor = System.Drawing.Color.Transparent
        Me.btnAgregaagencia.Location = New System.Drawing.Point(20, 302)
        Me.btnAgregaagencia.Name = "btnAgregaagencia"
        Me.btnAgregaagencia.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregaagencia.TabIndex = 24
        Me.btnAgregaagencia.Text = "Agencia..."
        Me.btnAgregaagencia.UseVisualStyleBackColor = False
        '
        'DGVAsociaagencia
        '
        Me.DGVAsociaagencia.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGVAsociaagencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVAsociaagencia.Location = New System.Drawing.Point(20, 331)
        Me.DGVAsociaagencia.Name = "DGVAsociaagencia"
        Me.DGVAsociaagencia.Size = New System.Drawing.Size(495, 134)
        Me.DGVAsociaagencia.TabIndex = 25
        '
        'Labplaca
        '
        Me.Labplaca.AutoSize = True
        Me.Labplaca.BackColor = System.Drawing.Color.Transparent
        Me.Labplaca.Location = New System.Drawing.Point(18, 31)
        Me.Labplaca.Name = "Labplaca"
        Me.Labplaca.Size = New System.Drawing.Size(43, 13)
        Me.Labplaca.TabIndex = 9
        Me.Labplaca.Text = "Placa : "
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(64, 31)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(75, 20)
        Me.TextBox9.TabIndex = 10
        '
        'Labnrounidad
        '
        Me.Labnrounidad.AutoSize = True
        Me.Labnrounidad.BackColor = System.Drawing.Color.Transparent
        Me.Labnrounidad.Location = New System.Drawing.Point(167, 34)
        Me.Labnrounidad.Name = "Labnrounidad"
        Me.Labnrounidad.Size = New System.Drawing.Size(65, 13)
        Me.Labnrounidad.TabIndex = 11
        Me.Labnrounidad.Text = "Nº Unidad : "
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(238, 31)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(75, 20)
        Me.TextBox10.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(328, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Tipo unidad : "
        '
        'CmbTipounidad
        '
        Me.CmbTipounidad.FormattingEnabled = True
        Me.CmbTipounidad.Location = New System.Drawing.Point(396, 31)
        Me.CmbTipounidad.Name = "CmbTipounidad"
        Me.CmbTipounidad.Size = New System.Drawing.Size(132, 21)
        Me.CmbTipounidad.TabIndex = 14
        '
        'Txtidunitransporte
        '
        Me.Txtidunitransporte.Location = New System.Drawing.Point(355, 9)
        Me.Txtidunitransporte.Name = "Txtidunitransporte"
        Me.Txtidunitransporte.Size = New System.Drawing.Size(123, 20)
        Me.Txtidunitransporte.TabIndex = 26
        Me.Txtidunitransporte.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(243, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Id Unidad Vehicular :"
        Me.Label13.Visible = False
        '
        'BTNeliminar
        '
        Me.BTNeliminar.Location = New System.Drawing.Point(440, 301)
        Me.BTNeliminar.Name = "BTNeliminar"
        Me.BTNeliminar.Size = New System.Drawing.Size(68, 23)
        Me.BTNeliminar.TabIndex = 28
        Me.BTNeliminar.Text = "Eliminar"
        Me.BTNeliminar.UseVisualStyleBackColor = True
        '
        'Frmunidadtransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "Frmunidadtransporte"
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGVAsociaagencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttv As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtbanios As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtpisos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txteje As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txtplaca As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUnidad As System.Windows.Forms.TextBox
    Friend WithEvents cmbmodelo As System.Windows.Forms.ComboBox
    Friend WithEvents CmbResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmbtipounidadm As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtcargamaxima As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtpesounidad As System.Windows.Forms.TextBox
    Friend WithEvents btnbus As System.Windows.Forms.Button
    Friend WithEvents btnAgregaagencia As System.Windows.Forms.Button
    Friend WithEvents DGVAsociaagencia As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Labplaca As System.Windows.Forms.Label
    Friend WithEvents Labnrounidad As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbTipounidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txtidunitransporte As System.Windows.Forms.TextBox
    Friend WithEvents txtcapacidad As System.Windows.Forms.TextBox
    Friend WithEvents Labcapacidad As System.Windows.Forms.Label
    Friend WithEvents btnmodelo As System.Windows.Forms.Button
    Friend WithEvents Btntipounidad As System.Windows.Forms.Button
    Friend WithEvents BTNeliminar As System.Windows.Forms.Button
    Friend WithEvents txtcerhabilitavehicular As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbtipo_servicio As System.Windows.Forms.ComboBox
    Friend WithEvents btntipo_servicio As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkRecojo As System.Windows.Forms.CheckBox

End Class
