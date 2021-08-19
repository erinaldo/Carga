<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistro_auto_guias
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
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtNro_Grupo_result = New System.Windows.Forms.TextBox
        Me.TxtGuiaEnvio = New System.Windows.Forms.TextBox
        Me.BtnRegis = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.TxtRutaArchi = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscarArchi = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtNroGuiaIni = New System.Windows.Forms.TextBox
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertirSeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SeleccionarNingunoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.txtNro_guia = New System.Windows.Forms.TextBox
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RBREIMPRE = New System.Windows.Forms.RadioButton
        Me.RBAMBOS = New System.Windows.Forms.RadioButton
        Me.btnImpri = New System.Windows.Forms.Button
        Me.RBSINIMPRE = New System.Windows.Forms.RadioButton
        Me.RBIMPRE = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtNro_grupo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CBIDESTADO_ENVIO = New System.Windows.Forms.ComboBox
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox
        Me.cmbAgencia = New System.Windows.Forms.ComboBox
        Me.txtidpersona = New System.Windows.Forms.TextBox
        Me.tbnro_factura = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(822, 480)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(816, 474)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(808, 448)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro de Guias de Envio..."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pb)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.TxtNro_Grupo_result)
        Me.Panel4.Controls.Add(Me.TxtGuiaEnvio)
        Me.Panel4.Controls.Add(Me.BtnRegis)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.DGV)
        Me.Panel4.Controls.Add(Me.TxtRutaArchi)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.BtnBuscarArchi)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(802, 442)
        Me.Panel4.TabIndex = 7
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(9, 422)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(700, 10)
        Me.pb.TabIndex = 10
        Me.pb.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(713, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 12)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Nro. de Grupo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 409)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'TxtNro_Grupo_result
        '
        Me.TxtNro_Grupo_result.BackColor = System.Drawing.Color.White
        Me.TxtNro_Grupo_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNro_Grupo_result.Location = New System.Drawing.Point(716, 27)
        Me.TxtNro_Grupo_result.Name = "TxtNro_Grupo_result"
        Me.TxtNro_Grupo_result.ReadOnly = True
        Me.TxtNro_Grupo_result.Size = New System.Drawing.Size(72, 20)
        Me.TxtNro_Grupo_result.TabIndex = 7
        '
        'TxtGuiaEnvio
        '
        Me.TxtGuiaEnvio.BackColor = System.Drawing.Color.LightCyan
        Me.TxtGuiaEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGuiaEnvio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGuiaEnvio.Location = New System.Drawing.Point(9, 26)
        Me.TxtGuiaEnvio.MaxLength = 13
        Me.TxtGuiaEnvio.Name = "TxtGuiaEnvio"
        Me.TxtGuiaEnvio.Size = New System.Drawing.Size(98, 20)
        Me.TxtGuiaEnvio.TabIndex = 5
        Me.TxtGuiaEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnRegis
        '
        Me.BtnRegis.BackColor = System.Drawing.Color.Transparent
        Me.BtnRegis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegis.Location = New System.Drawing.Point(716, 409)
        Me.BtnRegis.Name = "BtnRegis"
        Me.BtnRegis.Size = New System.Drawing.Size(72, 23)
        Me.BtnRegis.TabIndex = 4
        Me.BtnRegis.Text = "Registrar"
        Me.BtnRegis.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 37)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Siguiente. Nro. de Guía:"
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(6, 52)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(782, 351)
        Me.DGV.TabIndex = 3
        '
        'TxtRutaArchi
        '
        Me.TxtRutaArchi.Location = New System.Drawing.Point(113, 26)
        Me.TxtRutaArchi.Name = "TxtRutaArchi"
        Me.TxtRutaArchi.ReadOnly = True
        Me.TxtRutaArchi.Size = New System.Drawing.Size(498, 20)
        Me.TxtRutaArchi.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(113, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(628, 11)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ruta de Archivo:"
        '
        'BtnBuscarArchi
        '
        Me.BtnBuscarArchi.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscarArchi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscarArchi.Location = New System.Drawing.Point(617, 26)
        Me.BtnBuscarArchi.Name = "BtnBuscarArchi"
        Me.BtnBuscarArchi.Size = New System.Drawing.Size(55, 23)
        Me.BtnBuscarArchi.TabIndex = 1
        Me.BtnBuscarArchi.Text = "Buscar"
        Me.BtnBuscarArchi.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(808, 448)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Impresion de Guias de Envio..."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(802, 442)
        Me.Panel2.TabIndex = 61
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Location = New System.Drawing.Point(5, 157)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(794, 285)
        Me.TabControl2.TabIndex = 61
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.TxtNroGuiaIni)
        Me.TabPage3.Controls.Add(Me.dgv1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(786, 259)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Impresión de guias de envio..."
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(366, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 18)
        Me.Label22.TabIndex = 65
        Me.Label22.Text = "Nro. Guia Final:"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(218, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 18)
        Me.Label21.TabIndex = 64
        Me.Label21.Text = "Cantidad de Guias:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(6, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 18)
        Me.Label20.TabIndex = 63
        Me.Label20.Text = "Nro Guia Inicial:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(6, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(331, 13)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Ingrese el número inicial de la guia de envio sin el digito de checkeo."
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(453, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 20)
        Me.Label15.TabIndex = 62
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(322, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 20)
        Me.Label18.TabIndex = 62
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.White
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(549, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(18, 20)
        Me.Label23.TabIndex = 62
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(194, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 20)
        Me.Label11.TabIndex = 62
        '
        'TxtNroGuiaIni
        '
        Me.TxtNroGuiaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNroGuiaIni.Location = New System.Drawing.Point(98, 19)
        Me.TxtNroGuiaIni.Name = "TxtNroGuiaIni"
        Me.TxtNroGuiaIni.Size = New System.Drawing.Size(94, 20)
        Me.TxtNroGuiaIni.TabIndex = 61
        Me.TxtNroGuiaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.ContextMenuStrip = Me.cms
        Me.dgv1.Location = New System.Drawing.Point(0, 42)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(780, 211)
        Me.dgv1.TabIndex = 60
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarTodoToolStripMenuItem, Me.InvertirSeleccionToolStripMenuItem, Me.SeleccionarNingunoToolStripMenuItem, Me.ImprimirToolStripMenuItem})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(181, 92)
        '
        'SeleccionarTodoToolStripMenuItem
        '
        Me.SeleccionarTodoToolStripMenuItem.Name = "SeleccionarTodoToolStripMenuItem"
        Me.SeleccionarTodoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SeleccionarTodoToolStripMenuItem.Text = "Seleccionar todo"
        '
        'InvertirSeleccionToolStripMenuItem
        '
        Me.InvertirSeleccionToolStripMenuItem.Name = "InvertirSeleccionToolStripMenuItem"
        Me.InvertirSeleccionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.InvertirSeleccionToolStripMenuItem.Text = "Invertir selección"
        '
        'SeleccionarNingunoToolStripMenuItem
        '
        Me.SeleccionarNingunoToolStripMenuItem.Name = "SeleccionarNingunoToolStripMenuItem"
        Me.SeleccionarNingunoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SeleccionarNingunoToolStripMenuItem.Text = "Seleccionar ninguno"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtNro_guia)
        Me.TabPage4.Controls.Add(Me.DGV2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(786, 259)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Confirmación de registro de guias de envio..."
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtNro_guia
        '
        Me.txtNro_guia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNro_guia.Location = New System.Drawing.Point(638, 6)
        Me.txtNro_guia.Name = "txtNro_guia"
        Me.txtNro_guia.Size = New System.Drawing.Size(142, 20)
        Me.txtNro_guia.TabIndex = 62
        Me.txtNro_guia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DGV2
        '
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.ContextMenuStrip = Me.cms
        Me.DGV2.Location = New System.Drawing.Point(5, 32)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.Size = New System.Drawing.Size(780, 220)
        Me.DGV2.TabIndex = 61
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RBREIMPRE)
        Me.GroupBox1.Controls.Add(Me.RBAMBOS)
        Me.GroupBox1.Controls.Add(Me.btnImpri)
        Me.GroupBox1.Controls.Add(Me.RBSINIMPRE)
        Me.GroupBox1.Controls.Add(Me.RBIMPRE)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TxtNro_grupo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CBIDESTADO_ENVIO)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.tbnro_factura)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 151)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        '
        'RBREIMPRE
        '
        Me.RBREIMPRE.AutoSize = True
        Me.RBREIMPRE.Location = New System.Drawing.Point(310, 126)
        Me.RBREIMPRE.Name = "RBREIMPRE"
        Me.RBREIMPRE.Size = New System.Drawing.Size(83, 17)
        Me.RBREIMPRE.TabIndex = 99
        Me.RBREIMPRE.Text = "Reimpresión"
        Me.RBREIMPRE.UseVisualStyleBackColor = True
        '
        'RBAMBOS
        '
        Me.RBAMBOS.AutoSize = True
        Me.RBAMBOS.Location = New System.Drawing.Point(202, 126)
        Me.RBAMBOS.Name = "RBAMBOS"
        Me.RBAMBOS.Size = New System.Drawing.Size(102, 17)
        Me.RBAMBOS.TabIndex = 98
        Me.RBAMBOS.Text = "Ambos Inclusive"
        Me.RBAMBOS.UseVisualStyleBackColor = True
        '
        'btnImpri
        '
        Me.btnImpri.Enabled = False
        Me.btnImpri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpri.Location = New System.Drawing.Point(664, 123)
        Me.btnImpri.Name = "btnImpri"
        Me.btnImpri.Size = New System.Drawing.Size(55, 23)
        Me.btnImpri.TabIndex = 12
        Me.btnImpri.Text = "Imprimir"
        Me.btnImpri.UseVisualStyleBackColor = True
        '
        'RBSINIMPRE
        '
        Me.RBSINIMPRE.AutoSize = True
        Me.RBSINIMPRE.Location = New System.Drawing.Point(106, 126)
        Me.RBSINIMPRE.Name = "RBSINIMPRE"
        Me.RBSINIMPRE.Size = New System.Drawing.Size(78, 17)
        Me.RBSINIMPRE.TabIndex = 98
        Me.RBSINIMPRE.Text = "Sin Imprimir"
        Me.RBSINIMPRE.UseVisualStyleBackColor = True
        '
        'RBIMPRE
        '
        Me.RBIMPRE.AutoSize = True
        Me.RBIMPRE.Checked = True
        Me.RBIMPRE.Location = New System.Drawing.Point(10, 126)
        Me.RBIMPRE.Name = "RBIMPRE"
        Me.RBIMPRE.Size = New System.Drawing.Size(67, 17)
        Me.RBIMPRE.TabIndex = 98
        Me.RBIMPRE.TabStop = True
        Me.RBIMPRE.Text = "Impresos"
        Me.RBIMPRE.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(624, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 27)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "Nro. Grupo:"
        '
        'TxtNro_grupo
        '
        Me.TxtNro_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNro_grupo.Location = New System.Drawing.Point(671, 96)
        Me.TxtNro_grupo.Name = "TxtNro_grupo"
        Me.TxtNro_grupo.Size = New System.Drawing.Size(43, 20)
        Me.TxtNro_grupo.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(323, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Destino:"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(375, 96)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(243, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(307, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 93
        Me.Label16.Text = "Est. Env.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(4, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Origen:"
        '
        'CBIDESTADO_ENVIO
        '
        Me.CBIDESTADO_ENVIO.FormattingEnabled = True
        Me.CBIDESTADO_ENVIO.Location = New System.Drawing.Point(366, 42)
        Me.CBIDESTADO_ENVIO.Name = "CBIDESTADO_ENVIO"
        Me.CBIDESTADO_ENVIO.Size = New System.Drawing.Size(241, 21)
        Me.CBIDESTADO_ENVIO.TabIndex = 9
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(73, 99)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(243, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(429, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Usuario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(132, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia:"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(476, 69)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(243, 21)
        Me.cmbUsuarios.TabIndex = 8
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(184, 69)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(243, 21)
        Me.cmbAgencia.TabIndex = 7
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.Location = New System.Drawing.Point(271, 13)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(317, 20)
        Me.txtidpersona.TabIndex = 1
        '
        'tbnro_factura
        '
        Me.tbnro_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbnro_factura.Location = New System.Drawing.Point(62, 70)
        Me.tbnro_factura.Name = "tbnro_factura"
        Me.tbnro_factura.Size = New System.Drawing.Size(70, 20)
        Me.tbnro_factura.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(7, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Nro. Doc.:"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(92, 13)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(6, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "Codigo Cliente :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(220, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Cliente :"
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(217, 41)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(73, 41)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(159, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(5, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio :"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmRegistro_auto_guias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 480)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmRegistro_auto_guias"
        Me.Text = "Registro Automático de Guias..."
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnBuscarArchi As System.Windows.Forms.Button
    Friend WithEvents TxtRutaArchi As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRegis As System.Windows.Forms.Button
    Friend WithEvents TxtGuiaEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBIDESTADO_ENVIO As System.Windows.Forms.ComboBox
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents tbnro_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtNro_grupo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtNro_Grupo_result As System.Windows.Forms.TextBox
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertirSeleccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeleccionarNingunoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RBAMBOS As System.Windows.Forms.RadioButton
    Friend WithEvents RBSINIMPRE As System.Windows.Forms.RadioButton
    Friend WithEvents RBIMPRE As System.Windows.Forms.RadioButton
    Friend WithEvents RBREIMPRE As System.Windows.Forms.RadioButton
    Friend WithEvents btnImpri As System.Windows.Forms.Button
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtNro_guia As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents TxtNroGuiaIni As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
