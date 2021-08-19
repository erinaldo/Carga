<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItinerarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItinerarios))
        Me.CbOrigen = New System.Windows.Forms.ComboBox
        Me.CbDestino = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtBusca = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.CbServicio = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtID = New System.Windows.Forms.TextBox
        Me.CbOriDet = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CbRuta = New System.Windows.Forms.ComboBox
        Me.CbSerDet = New System.Windows.Forms.ComboBox
        Me.TxtFecInicio = New ControlsTepsa.DataPickerMasked
        Me.TxtHora = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.CbAge1 = New System.Windows.Forms.ComboBox
        Me.CbAge2 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.DataGridDeta = New System.Windows.Forms.DataGridView
        Me.BtnAgrega = New System.Windows.Forms.Button
        Me.BtnElimina = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.BtnAyuRut = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.BtnAyuAge2 = New System.Windows.Forms.Button
        Me.BtnAyuAge1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ChkVigente = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.TxtFechaIni = New ControlsTepsa.DataPickerMasked
        Me.TxtFechaFin = New ControlsTepsa.DataPickerMasked
        Me.BtnInserta = New System.Windows.Forms.Button
        Me.TxtFecIni = New ControlsTepsa.DataPickerMasked
        Me.TxtFecFin = New ControlsTepsa.DataPickerMasked
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
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
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridDeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
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
        Me.SplitContainer2.Panel1Collapsed = True
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(11, 18)
        Me.Panel1.Size = New System.Drawing.Size(754, 503)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(752, 498)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.BtBusca)
        Me.TabLista.Controls.Add(Me.DataGridViewLista)
        Me.TabLista.Controls.Add(Me.Label5)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.CbDestino)
        Me.TabLista.Controls.Add(Me.CbOrigen)
        Me.TabLista.Controls.Add(Me.TxtFechaFin)
        Me.TabLista.Controls.Add(Me.TxtFechaIni)
        Me.TabLista.Controls.Add(Me.GroupBox2)
        Me.TabLista.Controls.Add(Me.GroupBox3)
        Me.TabLista.Controls.Add(Me.GroupBox8)
        Me.TabLista.Size = New System.Drawing.Size(744, 469)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtFechaIni, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtFechaFin, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CbOrigen, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CbDestino, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridViewLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.BtBusca, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.Label16)
        Me.TabDatos.Controls.Add(Me.Label15)
        Me.TabDatos.Controls.Add(Me.TxtFecFin)
        Me.TabDatos.Controls.Add(Me.TxtFecIni)
        Me.TabDatos.Controls.Add(Me.BtnInserta)
        Me.TabDatos.Controls.Add(Me.BtnElimina)
        Me.TabDatos.Controls.Add(Me.BtnAgrega)
        Me.TabDatos.Controls.Add(Me.DataGridDeta)
        Me.TabDatos.Controls.Add(Me.Label12)
        Me.TabDatos.Controls.Add(Me.Label11)
        Me.TabDatos.Controls.Add(Me.Label10)
        Me.TabDatos.Controls.Add(Me.Label9)
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.TxtHora)
        Me.TabDatos.Controls.Add(Me.TxtFecInicio)
        Me.TabDatos.Controls.Add(Me.CbSerDet)
        Me.TabDatos.Controls.Add(Me.CbRuta)
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.CbOriDet)
        Me.TabDatos.Controls.Add(Me.TxtID)
        Me.TabDatos.Controls.Add(Me.GroupBox4)
        Me.TabDatos.Controls.Add(Me.GroupBox5)
        Me.TabDatos.Controls.Add(Me.GroupBox6)
        Me.TabDatos.Controls.Add(Me.GroupBox7)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Controls.Add(Me.GroupBox9)
        Me.TabDatos.Size = New System.Drawing.Size(744, 469)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox9, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox7, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox6, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtID, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbOriDet, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbRuta, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbSerDet, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtFecInicio, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtHora, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label11, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.DataGridDeta, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.BtnAgrega, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtMensaje, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.BtnElimina, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.BtnInserta, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtFecIni, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtFecFin, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label15, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label16, 0)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridLista.Location = New System.Drawing.Point(253, 233)
        Me.DataGridLista.Size = New System.Drawing.Size(60, 50)
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(616, 127)
        Me.TxtBusca.Size = New System.Drawing.Size(27, 20)
        Me.TxtBusca.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(744, 469)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(744, 469)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'TxtMensaje
        '
        Me.TxtMensaje.Location = New System.Drawing.Point(643, 18)
        '
        'CbOrigen
        '
        Me.CbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbOrigen.FormattingEnabled = True
        Me.CbOrigen.Location = New System.Drawing.Point(99, 18)
        Me.CbOrigen.Name = "CbOrigen"
        Me.CbOrigen.Size = New System.Drawing.Size(131, 21)
        Me.CbOrigen.TabIndex = 8
        '
        'CbDestino
        '
        Me.CbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDestino.FormattingEnabled = True
        Me.CbDestino.Location = New System.Drawing.Point(99, 45)
        Me.CbDestino.Name = "CbDestino"
        Me.CbDestino.Size = New System.Drawing.Size(131, 21)
        Me.CbDestino.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(27, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Origen"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(27, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Destino"
        '
        'BtBusca
        '
        Me.BtBusca.BackColor = System.Drawing.Color.Moccasin
        Me.BtBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtBusca.ForeColor = System.Drawing.Color.Maroon
        Me.BtBusca.Image = CType(resources.GetObject("BtBusca.Image"), System.Drawing.Image)
        Me.BtBusca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtBusca.Location = New System.Drawing.Point(594, 53)
        Me.BtBusca.Name = "BtBusca"
        Me.BtBusca.Size = New System.Drawing.Size(121, 35)
        Me.BtBusca.TabIndex = 12
        Me.BtBusca.Text = "Buscar"
        Me.BtBusca.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(11, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Servicio"
        '
        'CbServicio
        '
        Me.CbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbServicio.FormattingEnabled = True
        Me.CbServicio.Location = New System.Drawing.Point(66, 11)
        Me.CbServicio.Name = "CbServicio"
        Me.CbServicio.Size = New System.Drawing.Size(121, 21)
        Me.CbServicio.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Location = New System.Drawing.Point(21, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 70)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.CbServicio)
        Me.GroupBox3.Location = New System.Drawing.Point(512, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(203, 43)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(284, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha Inicio"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(284, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Fecha Fin"
        '
        'TxtID
        '
        Me.TxtID.Location = New System.Drawing.Point(124, 47)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.ReadOnly = True
        Me.TxtID.Size = New System.Drawing.Size(80, 20)
        Me.TxtID.TabIndex = 0
        '
        'CbOriDet
        '
        Me.CbOriDet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbOriDet.FormattingEnabled = True
        Me.CbOriDet.Location = New System.Drawing.Point(124, 88)
        Me.CbOriDet.Name = "CbOriDet"
        Me.CbOriDet.Size = New System.Drawing.Size(121, 21)
        Me.CbOriDet.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Nro.Itinerario"
        '
        'CbRuta
        '
        Me.CbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbRuta.FormattingEnabled = True
        Me.CbRuta.Location = New System.Drawing.Point(319, 88)
        Me.CbRuta.Name = "CbRuta"
        Me.CbRuta.Size = New System.Drawing.Size(165, 21)
        Me.CbRuta.TabIndex = 3
        '
        'CbSerDet
        '
        Me.CbSerDet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbSerDet.FormattingEnabled = True
        Me.CbSerDet.Location = New System.Drawing.Point(580, 88)
        Me.CbSerDet.Name = "CbSerDet"
        Me.CbSerDet.Size = New System.Drawing.Size(121, 21)
        Me.CbSerDet.TabIndex = 4
        '
        'TxtFecInicio
        '
        Me.TxtFecInicio._MyFecha = Nothing
        Me.TxtFecInicio.BackColor = System.Drawing.Color.Transparent
        Me.TxtFecInicio.Location = New System.Drawing.Point(124, 132)
        Me.TxtFecInicio.Name = "TxtFecInicio"
        Me.TxtFecInicio.Size = New System.Drawing.Size(106, 20)
        Me.TxtFecInicio.TabIndex = 5
        '
        'TxtHora
        '
        Me.TxtHora.Location = New System.Drawing.Point(124, 161)
        Me.TxtHora.Mask = "00:00"
        Me.TxtHora.Name = "TxtHora"
        Me.TxtHora.Size = New System.Drawing.Size(44, 20)
        Me.TxtHora.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(37, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Origen"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(277, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Ruta"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(518, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Servicio"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(37, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Fecha Partida"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(37, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Hora Partida"
        '
        'CbAge1
        '
        Me.CbAge1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAge1.FormattingEnabled = True
        Me.CbAge1.Location = New System.Drawing.Point(515, 12)
        Me.CbAge1.Name = "CbAge1"
        Me.CbAge1.Size = New System.Drawing.Size(164, 21)
        Me.CbAge1.TabIndex = 7
        '
        'CbAge2
        '
        Me.CbAge2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAge2.FormattingEnabled = True
        Me.CbAge2.Location = New System.Drawing.Point(515, 41)
        Me.CbAge2.Name = "CbAge2"
        Me.CbAge2.Size = New System.Drawing.Size(164, 21)
        Me.CbAge2.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(413, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Agencia Origen"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(413, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Agencia Destino"
        '
        'DataGridDeta
        '
        Me.DataGridDeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDeta.Location = New System.Drawing.Point(12, 272)
        Me.DataGridDeta.Name = "DataGridDeta"
        Me.DataGridDeta.Size = New System.Drawing.Size(712, 176)
        Me.DataGridDeta.TabIndex = 16
        '
        'BtnAgrega
        '
        Me.BtnAgrega.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnAgrega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgrega.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnAgrega.Image = CType(resources.GetObject("BtnAgrega.Image"), System.Drawing.Image)
        Me.BtnAgrega.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgrega.Location = New System.Drawing.Point(361, 218)
        Me.BtnAgrega.Name = "BtnAgrega"
        Me.BtnAgrega.Size = New System.Drawing.Size(110, 23)
        Me.BtnAgrega.TabIndex = 9
        Me.BtnAgrega.Text = "&Agregar"
        Me.BtnAgrega.UseVisualStyleBackColor = False
        '
        'BtnElimina
        '
        Me.BtnElimina.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnElimina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnElimina.Location = New System.Drawing.Point(480, 218)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(110, 23)
        Me.BtnElimina.TabIndex = 10
        Me.BtnElimina.Text = "&Eliminar"
        Me.BtnElimina.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(344, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 47)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tramos"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Location = New System.Drawing.Point(6, 34)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(226, 43)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.BtnAyuRut)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 76)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(724, 43)
        Me.GroupBox5.TabIndex = 21
        Me.GroupBox5.TabStop = False
        '
        'BtnAyuRut
        '
        Me.BtnAyuRut.AutoSize = True
        Me.BtnAyuRut.Image = CType(resources.GetObject("BtnAyuRut.Image"), System.Drawing.Image)
        Me.BtnAyuRut.Location = New System.Drawing.Point(482, 11)
        Me.BtnAyuRut.Name = "BtnAyuRut"
        Me.BtnAyuRut.Size = New System.Drawing.Size(28, 24)
        Me.BtnAyuRut.TabIndex = 30
        Me.BtnAyuRut.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.BtnAyuAge2)
        Me.GroupBox6.Controls.Add(Me.BtnAyuAge1)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.ChkVigente)
        Me.GroupBox6.Controls.Add(Me.CbAge1)
        Me.GroupBox6.Controls.Add(Me.CbAge2)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 117)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(724, 72)
        Me.GroupBox6.TabIndex = 22
        Me.GroupBox6.TabStop = False
        '
        'BtnAyuAge2
        '
        Me.BtnAyuAge2.AutoSize = True
        Me.BtnAyuAge2.Image = CType(resources.GetObject("BtnAyuAge2.Image"), System.Drawing.Image)
        Me.BtnAyuAge2.Location = New System.Drawing.Point(685, 41)
        Me.BtnAyuAge2.Name = "BtnAyuAge2"
        Me.BtnAyuAge2.Size = New System.Drawing.Size(28, 24)
        Me.BtnAyuAge2.TabIndex = 32
        Me.BtnAyuAge2.UseVisualStyleBackColor = True
        '
        'BtnAyuAge1
        '
        Me.BtnAyuAge1.AutoSize = True
        Me.BtnAyuAge1.Image = CType(resources.GetObject("BtnAyuAge1.Image"), System.Drawing.Image)
        Me.BtnAyuAge1.Location = New System.Drawing.Point(685, 11)
        Me.BtnAyuAge1.Name = "BtnAyuAge1"
        Me.BtnAyuAge1.Size = New System.Drawing.Size(28, 24)
        Me.BtnAyuAge1.TabIndex = 31
        Me.BtnAyuAge1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(274, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Vigente"
        '
        'ChkVigente
        '
        Me.ChkVigente.AutoSize = True
        Me.ChkVigente.Checked = True
        Me.ChkVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkVigente.Location = New System.Drawing.Point(328, 44)
        Me.ChkVigente.Name = "ChkVigente"
        Me.ChkVigente.Size = New System.Drawing.Size(15, 14)
        Me.ChkVigente.TabIndex = 26
        Me.ChkVigente.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Location = New System.Drawing.Point(6, 257)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(724, 200)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Relacion de Tramos"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Location = New System.Drawing.Point(269, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(221, 70)
        Me.GroupBox8.TabIndex = 23
        Me.GroupBox8.TabStop = False
        '
        'TxtFechaIni
        '
        Me.TxtFechaIni._MyFecha = Nothing
        Me.TxtFechaIni.BackColor = System.Drawing.Color.Transparent
        Me.TxtFechaIni.Location = New System.Drawing.Point(369, 18)
        Me.TxtFechaIni.Name = "TxtFechaIni"
        Me.TxtFechaIni.Size = New System.Drawing.Size(106, 20)
        Me.TxtFechaIni.TabIndex = 0
        '
        'TxtFechaFin
        '
        Me.TxtFechaFin._MyFecha = Nothing
        Me.TxtFechaFin.BackColor = System.Drawing.Color.Transparent
        Me.TxtFechaFin.Location = New System.Drawing.Point(369, 48)
        Me.TxtFechaFin.Name = "TxtFechaFin"
        Me.TxtFechaFin.Size = New System.Drawing.Size(106, 20)
        Me.TxtFechaFin.TabIndex = 1
        '
        'BtnInserta
        '
        Me.BtnInserta.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnInserta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInserta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnInserta.Image = CType(resources.GetObject("BtnInserta.Image"), System.Drawing.Image)
        Me.BtnInserta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnInserta.Location = New System.Drawing.Point(600, 218)
        Me.BtnInserta.Name = "BtnInserta"
        Me.BtnInserta.Size = New System.Drawing.Size(110, 23)
        Me.BtnInserta.TabIndex = 11
        Me.BtnInserta.Text = "&Insertar"
        Me.BtnInserta.UseVisualStyleBackColor = False
        '
        'TxtFecIni
        '
        Me.TxtFecIni._MyFecha = Nothing
        Me.TxtFecIni.BackColor = System.Drawing.Color.Transparent
        Me.TxtFecIni.Location = New System.Drawing.Point(120, 203)
        Me.TxtFecIni.Name = "TxtFecIni"
        Me.TxtFecIni.Size = New System.Drawing.Size(106, 20)
        Me.TxtFecIni.TabIndex = 25
        '
        'TxtFecFin
        '
        Me.TxtFecFin._MyFecha = Nothing
        Me.TxtFecFin.BackColor = System.Drawing.Color.Transparent
        Me.TxtFecFin.Location = New System.Drawing.Point(120, 227)
        Me.TxtFecFin.Name = "TxtFecFin"
        Me.TxtFecFin.Size = New System.Drawing.Size(106, 20)
        Me.TxtFecFin.TabIndex = 26
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(37, 207)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Fecha Inicio"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(37, 230)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Fecha Fin"
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Location = New System.Drawing.Point(6, 188)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(288, 67)
        Me.GroupBox9.TabIndex = 29
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Programación"
        '
        'DataGridViewLista
        '
        Me.DataGridViewLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLista.Location = New System.Drawing.Point(21, 94)
        Me.DataGridViewLista.Name = "DataGridViewLista"
        Me.DataGridViewLista.Size = New System.Drawing.Size(694, 348)
        Me.DataGridViewLista.TabIndex = 24
        '
        'FrmItinerarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "FrmItinerarios"
        Me.Text = "FrmItinerarios"
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
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridDeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.DataGridViewLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents CbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents BtBusca As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CbServicio As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CbOriDet As System.Windows.Forms.ComboBox
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecInicio As ControlsTepsa.DataPickerMasked
    Friend WithEvents CbSerDet As System.Windows.Forms.ComboBox
    Friend WithEvents CbRuta As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DataGridDeta As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CbAge2 As System.Windows.Forms.ComboBox
    Friend WithEvents CbAge1 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnElimina As System.Windows.Forms.Button
    Friend WithEvents BtnAgrega As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFechaFin As ControlsTepsa.DataPickerMasked
    Friend WithEvents TxtFechaIni As ControlsTepsa.DataPickerMasked
    Friend WithEvents BtnInserta As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkVigente As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFecIni As ControlsTepsa.DataPickerMasked
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtFecFin As ControlsTepsa.DataPickerMasked
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAyuRut As System.Windows.Forms.Button
    Friend WithEvents BtnAyuAge1 As System.Windows.Forms.Button
    Friend WithEvents BtnAyuAge2 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewLista As System.Windows.Forms.DataGridView
End Class
