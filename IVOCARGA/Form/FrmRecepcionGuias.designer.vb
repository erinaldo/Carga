<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecepcionGuias
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.dtFechaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.txtFechaRecepcion = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNroGuia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtMonto_Base = New System.Windows.Forms.TextBox()
        Me.txtSub_Total = New System.Windows.Forms.TextBox()
        Me.txtMonto_IGV = New System.Windows.Forms.TextBox()
        Me.txtCosto_Total = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabArticulos = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.txtPrecio_Sobre = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.txtPrecio_Vol = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtSubTotal_Sobre = New System.Windows.Forms.TextBox()
        Me.txtTota_Sobre = New System.Windows.Forms.TextBox()
        Me.txtPieza_Sobre = New System.Windows.Forms.TextBox()
        Me.txtSubTotal_Vol = New System.Windows.Forms.TextBox()
        Me.txtTota_Vol = New System.Windows.Forms.TextBox()
        Me.txtSubTotal_Peso = New System.Windows.Forms.TextBox()
        Me.txtPieza_Vol = New System.Windows.Forms.TextBox()
        Me.txtTota_Peso = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.txtPieza_Peso = New System.Windows.Forms.TextBox()
        Me.txtPrecio_Peso = New System.Windows.Forms.TextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.dtGridViewArt = New System.Windows.Forms.DataGridView()
        Me.dtGridViewDocumentos = New System.Windows.Forms.DataGridView()
        Me.TxtDestino = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFecha_Cargo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFecha_Guia = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNroRuc = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabArticulos.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.dtGridViewArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtGridViewDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.GroupBox4)
        Me.TabLista.Controls.Add(Me.GroupBox3)
        Me.TabLista.Controls.Add(Me.GroupBox2)
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmbTipoDocumento)
        Me.GroupBox2.Controls.Add(Me.dtFechaRecepcion)
        Me.GroupBox2.Controls.Add(Me.btnReporte)
        Me.GroupBox2.Controls.Add(Me.txtFechaRecepcion)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNroGuia)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(8, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(680, 47)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.Enabled = False
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Items.AddRange(New Object() {"GUIAS ENVIO"})
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(421, 19)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(151, 21)
        Me.cmbTipoDocumento.TabIndex = 11
        '
        'dtFechaRecepcion
        '
        Me.dtFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaRecepcion.Location = New System.Drawing.Point(398, 20)
        Me.dtFechaRecepcion.Name = "dtFechaRecepcion"
        Me.dtFechaRecepcion.Size = New System.Drawing.Size(19, 20)
        Me.dtFechaRecepcion.TabIndex = 10
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.Color.Moccasin
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReporte.Location = New System.Drawing.Point(576, 16)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(99, 26)
        Me.btnReporte.TabIndex = 9
        Me.btnReporte.Text = "&Genera Reporte"
        Me.btnReporte.UseVisualStyleBackColor = False
        '
        'txtFechaRecepcion
        '
        Me.txtFechaRecepcion.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtFechaRecepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaRecepcion.Location = New System.Drawing.Point(317, 19)
        Me.txtFechaRecepcion.Mask = "00/00/0000"
        Me.txtFechaRecepcion.Name = "txtFechaRecepcion"
        Me.txtFechaRecepcion.Size = New System.Drawing.Size(80, 20)
        Me.txtFechaRecepcion.TabIndex = 7
        Me.txtFechaRecepcion.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(4, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Nro Documento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(222, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha Recepcion"
        '
        'txtNroGuia
        '
        Me.txtNroGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroGuia.Location = New System.Drawing.Point(92, 20)
        Me.txtNroGuia.MaxLength = 13
        Me.txtNroGuia.Name = "txtNroGuia"
        Me.txtNroGuia.Size = New System.Drawing.Size(127, 20)
        Me.txtNroGuia.TabIndex = 4
        Me.txtNroGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(43, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Buscar"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(3, 408)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(680, 40)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(216, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "( F6 )"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(112, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "( F5 )"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(596, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "( F12 )"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(7, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "( F1 )"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(249, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Reporte"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(145, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Nuevo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(639, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Salir"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.lblContador)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.txtMonto_Base)
        Me.GroupBox4.Controls.Add(Me.txtSub_Total)
        Me.GroupBox4.Controls.Add(Me.txtMonto_IGV)
        Me.GroupBox4.Controls.Add(Me.txtCosto_Total)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.TabArticulos)
        Me.GroupBox4.Controls.Add(Me.dtGridViewDocumentos)
        Me.GroupBox4.Controls.Add(Me.TxtDestino)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtOrigen)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.txtFecha_Cargo)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.txtFecha_Guia)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.txtEstado)
        Me.GroupBox4.Controls.Add(Me.lblProducto)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.txtNroRuc)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txtCliente)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(2, 47)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(681, 374)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"COURIER"})
        Me.ComboBox1.Location = New System.Drawing.Point(511, 68)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(155, 21)
        Me.ComboBox1.TabIndex = 47
        Me.ComboBox1.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(443, 277)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(74, 13)
        Me.Label28.TabIndex = 46
        Me.Label28.Text = "Monto Base"
        '
        'txtMonto_Base
        '
        Me.txtMonto_Base.BackColor = System.Drawing.SystemColors.Info
        Me.txtMonto_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonto_Base.Location = New System.Drawing.Point(548, 272)
        Me.txtMonto_Base.MaxLength = 7
        Me.txtMonto_Base.Name = "txtMonto_Base"
        Me.txtMonto_Base.ReadOnly = True
        Me.txtMonto_Base.Size = New System.Drawing.Size(114, 20)
        Me.txtMonto_Base.TabIndex = 41
        Me.txtMonto_Base.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSub_Total
        '
        Me.txtSub_Total.BackColor = System.Drawing.Color.Azure
        Me.txtSub_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSub_Total.Location = New System.Drawing.Point(548, 296)
        Me.txtSub_Total.MaxLength = 7
        Me.txtSub_Total.Name = "txtSub_Total"
        Me.txtSub_Total.ReadOnly = True
        Me.txtSub_Total.Size = New System.Drawing.Size(114, 20)
        Me.txtSub_Total.TabIndex = 40
        Me.txtSub_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonto_IGV
        '
        Me.txtMonto_IGV.BackColor = System.Drawing.Color.Azure
        Me.txtMonto_IGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonto_IGV.Location = New System.Drawing.Point(548, 320)
        Me.txtMonto_IGV.MaxLength = 7
        Me.txtMonto_IGV.Name = "txtMonto_IGV"
        Me.txtMonto_IGV.ReadOnly = True
        Me.txtMonto_IGV.Size = New System.Drawing.Size(114, 20)
        Me.txtMonto_IGV.TabIndex = 42
        Me.txtMonto_IGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCosto_Total
        '
        Me.txtCosto_Total.BackColor = System.Drawing.Color.Azure
        Me.txtCosto_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCosto_Total.Location = New System.Drawing.Point(548, 343)
        Me.txtCosto_Total.MaxLength = 7
        Me.txtCosto_Total.Name = "txtCosto_Total"
        Me.txtCosto_Total.ReadOnly = True
        Me.txtCosto_Total.Size = New System.Drawing.Size(114, 20)
        Me.txtCosto_Total.TabIndex = 39
        Me.txtCosto_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(443, 303)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 13)
        Me.Label27.TabIndex = 45
        Me.Label27.Text = "Sub Total"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(443, 327)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 44
        Me.Label26.Text = "IGV"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(443, 350)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 13)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "Total"
        '
        'TabArticulos
        '
        Me.TabArticulos.Controls.Add(Me.TabPage5)
        Me.TabArticulos.Controls.Add(Me.TabPage6)
        Me.TabArticulos.Location = New System.Drawing.Point(212, 123)
        Me.TabArticulos.Name = "TabArticulos"
        Me.TabArticulos.SelectedIndex = 0
        Me.TabArticulos.Size = New System.Drawing.Size(455, 147)
        Me.TabArticulos.TabIndex = 16
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.PictureBox2)
        Me.TabPage5.Controls.Add(Me.PictureBox3)
        Me.TabPage5.Controls.Add(Me.PictureBox5)
        Me.TabPage5.Controls.Add(Me.PictureBox1)
        Me.TabPage5.Controls.Add(Me.TextBox15)
        Me.TabPage5.Controls.Add(Me.txtPrecio_Sobre)
        Me.TabPage5.Controls.Add(Me.TextBox14)
        Me.TabPage5.Controls.Add(Me.txtPrecio_Vol)
        Me.TabPage5.Controls.Add(Me.Label25)
        Me.TabPage5.Controls.Add(Me.Label24)
        Me.TabPage5.Controls.Add(Me.Label22)
        Me.TabPage5.Controls.Add(Me.Label21)
        Me.TabPage5.Controls.Add(Me.txtSubTotal_Sobre)
        Me.TabPage5.Controls.Add(Me.txtTota_Sobre)
        Me.TabPage5.Controls.Add(Me.txtPieza_Sobre)
        Me.TabPage5.Controls.Add(Me.txtSubTotal_Vol)
        Me.TabPage5.Controls.Add(Me.txtTota_Vol)
        Me.TabPage5.Controls.Add(Me.txtSubTotal_Peso)
        Me.TabPage5.Controls.Add(Me.txtPieza_Vol)
        Me.TabPage5.Controls.Add(Me.txtTota_Peso)
        Me.TabPage5.Controls.Add(Me.TextBox13)
        Me.TabPage5.Controls.Add(Me.txtPieza_Peso)
        Me.TabPage5.Controls.Add(Me.txtPrecio_Peso)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(447, 121)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "PESO/VOLUMEN"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(0, 72)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(446, 2)
        Me.PictureBox2.TabIndex = 43
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Black
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(0, 47)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(446, 2)
        Me.PictureBox3.TabIndex = 42
        Me.PictureBox3.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Black
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Location = New System.Drawing.Point(1, 23)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(446, 1)
        Me.PictureBox5.TabIndex = 45
        Me.PictureBox5.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 96)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(447, 2)
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'TextBox15
        '
        Me.TextBox15.BackColor = System.Drawing.Color.LightCyan
        Me.TextBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox15.Location = New System.Drawing.Point(0, 75)
        Me.TextBox15.MaxLength = 7
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(87, 20)
        Me.TextBox15.TabIndex = 29
        Me.TextBox15.Text = "SOBRES"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio_Sobre
        '
        Me.txtPrecio_Sobre.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecio_Sobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio_Sobre.Location = New System.Drawing.Point(88, 75)
        Me.txtPrecio_Sobre.MaxLength = 7
        Me.txtPrecio_Sobre.Name = "txtPrecio_Sobre"
        Me.txtPrecio_Sobre.ReadOnly = True
        Me.txtPrecio_Sobre.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecio_Sobre.TabIndex = 26
        Me.txtPrecio_Sobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox14
        '
        Me.TextBox14.BackColor = System.Drawing.Color.LightCyan
        Me.TextBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(0, 50)
        Me.TextBox14.MaxLength = 7
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(87, 20)
        Me.TextBox14.TabIndex = 27
        Me.TextBox14.Text = "VOLUMEN"
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio_Vol
        '
        Me.txtPrecio_Vol.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecio_Vol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio_Vol.Location = New System.Drawing.Point(88, 50)
        Me.txtPrecio_Vol.MaxLength = 7
        Me.txtPrecio_Vol.Name = "txtPrecio_Vol"
        Me.txtPrecio_Vol.ReadOnly = True
        Me.txtPrecio_Vol.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecio_Vol.TabIndex = 32
        Me.txtPrecio_Vol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(380, 5)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(62, 13)
        Me.Label25.TabIndex = 37
        Me.Label25.Text = "Sub Total"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(240, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 13)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "Peso/Volumen"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(175, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(44, 13)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "Piezas"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(97, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 40
        Me.Label21.Text = "Costo"
        '
        'txtSubTotal_Sobre
        '
        Me.txtSubTotal_Sobre.BackColor = System.Drawing.SystemColors.Info
        Me.txtSubTotal_Sobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal_Sobre.Location = New System.Drawing.Point(333, 75)
        Me.txtSubTotal_Sobre.MaxLength = 7
        Me.txtSubTotal_Sobre.Name = "txtSubTotal_Sobre"
        Me.txtSubTotal_Sobre.ReadOnly = True
        Me.txtSubTotal_Sobre.Size = New System.Drawing.Size(114, 20)
        Me.txtSubTotal_Sobre.TabIndex = 17
        Me.txtSubTotal_Sobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTota_Sobre
        '
        Me.txtTota_Sobre.BackColor = System.Drawing.SystemColors.Info
        Me.txtTota_Sobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTota_Sobre.Location = New System.Drawing.Point(231, 75)
        Me.txtTota_Sobre.MaxLength = 7
        Me.txtTota_Sobre.Name = "txtTota_Sobre"
        Me.txtTota_Sobre.ReadOnly = True
        Me.txtTota_Sobre.Size = New System.Drawing.Size(99, 20)
        Me.txtTota_Sobre.TabIndex = 15
        Me.txtTota_Sobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPieza_Sobre
        '
        Me.txtPieza_Sobre.BackColor = System.Drawing.SystemColors.Info
        Me.txtPieza_Sobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieza_Sobre.Location = New System.Drawing.Point(158, 75)
        Me.txtPieza_Sobre.MaxLength = 7
        Me.txtPieza_Sobre.Name = "txtPieza_Sobre"
        Me.txtPieza_Sobre.ReadOnly = True
        Me.txtPieza_Sobre.Size = New System.Drawing.Size(72, 20)
        Me.txtPieza_Sobre.TabIndex = 16
        Me.txtPieza_Sobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal_Vol
        '
        Me.txtSubTotal_Vol.BackColor = System.Drawing.SystemColors.Info
        Me.txtSubTotal_Vol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal_Vol.Location = New System.Drawing.Point(333, 50)
        Me.txtSubTotal_Vol.MaxLength = 7
        Me.txtSubTotal_Vol.Name = "txtSubTotal_Vol"
        Me.txtSubTotal_Vol.ReadOnly = True
        Me.txtSubTotal_Vol.Size = New System.Drawing.Size(114, 20)
        Me.txtSubTotal_Vol.TabIndex = 20
        Me.txtSubTotal_Vol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTota_Vol
        '
        Me.txtTota_Vol.BackColor = System.Drawing.SystemColors.Info
        Me.txtTota_Vol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTota_Vol.Location = New System.Drawing.Point(231, 50)
        Me.txtTota_Vol.MaxLength = 7
        Me.txtTota_Vol.Name = "txtTota_Vol"
        Me.txtTota_Vol.ReadOnly = True
        Me.txtTota_Vol.Size = New System.Drawing.Size(99, 20)
        Me.txtTota_Vol.TabIndex = 24
        Me.txtTota_Vol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal_Peso
        '
        Me.txtSubTotal_Peso.BackColor = System.Drawing.SystemColors.Info
        Me.txtSubTotal_Peso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal_Peso.Location = New System.Drawing.Point(333, 26)
        Me.txtSubTotal_Peso.MaxLength = 7
        Me.txtSubTotal_Peso.Name = "txtSubTotal_Peso"
        Me.txtSubTotal_Peso.ReadOnly = True
        Me.txtSubTotal_Peso.Size = New System.Drawing.Size(114, 20)
        Me.txtSubTotal_Peso.TabIndex = 25
        Me.txtSubTotal_Peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPieza_Vol
        '
        Me.txtPieza_Vol.BackColor = System.Drawing.SystemColors.Info
        Me.txtPieza_Vol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieza_Vol.Location = New System.Drawing.Point(158, 50)
        Me.txtPieza_Vol.MaxLength = 7
        Me.txtPieza_Vol.Name = "txtPieza_Vol"
        Me.txtPieza_Vol.ReadOnly = True
        Me.txtPieza_Vol.Size = New System.Drawing.Size(72, 20)
        Me.txtPieza_Vol.TabIndex = 23
        Me.txtPieza_Vol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTota_Peso
        '
        Me.txtTota_Peso.BackColor = System.Drawing.SystemColors.Info
        Me.txtTota_Peso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTota_Peso.Location = New System.Drawing.Point(231, 26)
        Me.txtTota_Peso.MaxLength = 7
        Me.txtTota_Peso.Name = "txtTota_Peso"
        Me.txtTota_Peso.ReadOnly = True
        Me.txtTota_Peso.Size = New System.Drawing.Size(99, 20)
        Me.txtTota_Peso.TabIndex = 21
        Me.txtTota_Peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox13
        '
        Me.TextBox13.BackColor = System.Drawing.Color.LightCyan
        Me.TextBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(0, 26)
        Me.TextBox13.MaxLength = 7
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(87, 20)
        Me.TextBox13.TabIndex = 22
        Me.TextBox13.Text = "PESO"
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPieza_Peso
        '
        Me.txtPieza_Peso.BackColor = System.Drawing.SystemColors.Info
        Me.txtPieza_Peso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieza_Peso.Location = New System.Drawing.Point(158, 26)
        Me.txtPieza_Peso.MaxLength = 7
        Me.txtPieza_Peso.Name = "txtPieza_Peso"
        Me.txtPieza_Peso.ReadOnly = True
        Me.txtPieza_Peso.Size = New System.Drawing.Size(72, 20)
        Me.txtPieza_Peso.TabIndex = 19
        Me.txtPieza_Peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio_Peso
        '
        Me.txtPrecio_Peso.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecio_Peso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio_Peso.Location = New System.Drawing.Point(88, 26)
        Me.txtPrecio_Peso.MaxLength = 7
        Me.txtPrecio_Peso.Name = "txtPrecio_Peso"
        Me.txtPrecio_Peso.ReadOnly = True
        Me.txtPrecio_Peso.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecio_Peso.TabIndex = 18
        Me.txtPrecio_Peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.dtGridViewArt)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(447, 121)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "ARTICULOS"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'dtGridViewArt
        '
        Me.dtGridViewArt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViewArt.Location = New System.Drawing.Point(3, 6)
        Me.dtGridViewArt.Name = "dtGridViewArt"
        Me.dtGridViewArt.Size = New System.Drawing.Size(440, 114)
        Me.dtGridViewArt.TabIndex = 0
        '
        'dtGridViewDocumentos
        '
        Me.dtGridViewDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViewDocumentos.Location = New System.Drawing.Point(9, 123)
        Me.dtGridViewDocumentos.Name = "dtGridViewDocumentos"
        Me.dtGridViewDocumentos.Size = New System.Drawing.Size(197, 226)
        Me.dtGridViewDocumentos.TabIndex = 15
        '
        'TxtDestino
        '
        Me.TxtDestino.BackColor = System.Drawing.SystemColors.Info
        Me.TxtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDestino.Location = New System.Drawing.Point(511, 38)
        Me.TxtDestino.MaxLength = 7
        Me.TxtDestino.Name = "TxtDestino"
        Me.TxtDestino.ReadOnly = True
        Me.TxtDestino.Size = New System.Drawing.Size(155, 20)
        Me.TxtDestino.TabIndex = 9
        Me.TxtDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(459, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Destino"
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.SystemColors.Info
        Me.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrigen.Location = New System.Drawing.Point(511, 8)
        Me.txtOrigen.MaxLength = 7
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(155, 20)
        Me.txtOrigen.TabIndex = 8
        Me.txtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(459, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Origen"
        '
        'txtFecha_Cargo
        '
        Me.txtFecha_Cargo.BackColor = System.Drawing.SystemColors.Info
        Me.txtFecha_Cargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha_Cargo.Location = New System.Drawing.Point(91, 59)
        Me.txtFecha_Cargo.MaxLength = 7
        Me.txtFecha_Cargo.Name = "txtFecha_Cargo"
        Me.txtFecha_Cargo.ReadOnly = True
        Me.txtFecha_Cargo.Size = New System.Drawing.Size(127, 20)
        Me.txtFecha_Cargo.TabIndex = 7
        Me.txtFecha_Cargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(9, 105)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 11
        Me.Label19.Text = "Documentos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(7, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Fecha Cargo"
        '
        'txtFecha_Guia
        '
        Me.txtFecha_Guia.BackColor = System.Drawing.SystemColors.Info
        Me.txtFecha_Guia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha_Guia.Location = New System.Drawing.Point(296, 34)
        Me.txtFecha_Guia.MaxLength = 7
        Me.txtFecha_Guia.Name = "txtFecha_Guia"
        Me.txtFecha_Guia.ReadOnly = True
        Me.txtFecha_Guia.Size = New System.Drawing.Size(127, 20)
        Me.txtFecha_Guia.TabIndex = 7
        Me.txtFecha_Guia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(231, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Fecha Doc"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstado.Location = New System.Drawing.Point(296, 61)
        Me.txtEstado.MaxLength = 7
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(127, 20)
        Me.txtEstado.TabIndex = 7
        Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.Color.Transparent
        Me.lblProducto.Location = New System.Drawing.Point(460, 68)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 11
        Me.lblProducto.Text = "Producto"
        Me.lblProducto.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(229, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Estado"
        '
        'txtNroRuc
        '
        Me.txtNroRuc.BackColor = System.Drawing.SystemColors.Info
        Me.txtNroRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroRuc.Location = New System.Drawing.Point(91, 33)
        Me.txtNroRuc.MaxLength = 7
        Me.txtNroRuc.Name = "txtNroRuc"
        Me.txtNroRuc.ReadOnly = True
        Me.txtNroRuc.Size = New System.Drawing.Size(127, 20)
        Me.txtNroRuc.TabIndex = 7
        Me.txtNroRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(6, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "RUC"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(91, 8)
        Me.txtCliente.MaxLength = 7
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(332, 20)
        Me.txtCliente.TabIndex = 6
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(6, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Cliente"
        '
        'lblContador
        '
        Me.lblContador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContador.ForeColor = System.Drawing.Color.Red
        Me.lblContador.Location = New System.Drawing.Point(369, 95)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(54, 13)
        Me.lblContador.TabIndex = 49
        Me.lblContador.Text = "0"
        Me.lblContador.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(274, 95)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 13)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Recepcionado"
        '
        'FrmRecepcionGuias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(707, 490)
        Me.Name = "FrmRecepcionGuias"
        Me.Text = "Recepción de Guías de Envío"
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabArticulos.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.dtGridViewArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtGridViewDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaRecepcion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNroGuia As System.Windows.Forms.TextBox
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtFechaRecepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNroRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFecha_Guia As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFecha_Cargo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtGridViewDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TabArticulos As System.Windows.Forms.TabControl
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio_Sobre As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio_Vol As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal_Sobre As System.Windows.Forms.TextBox
    Friend WithEvents txtTota_Sobre As System.Windows.Forms.TextBox
    Friend WithEvents txtPieza_Sobre As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal_Vol As System.Windows.Forms.TextBox
    Friend WithEvents txtTota_Vol As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal_Peso As System.Windows.Forms.TextBox
    Friend WithEvents txtPieza_Vol As System.Windows.Forms.TextBox
    Friend WithEvents txtTota_Peso As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents txtPieza_Peso As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio_Peso As System.Windows.Forms.TextBox
    Friend WithEvents dtGridViewArt As System.Windows.Forms.DataGridView
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtMonto_Base As System.Windows.Forms.TextBox
    Friend WithEvents txtSub_Total As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto_IGV As System.Windows.Forms.TextBox
    Friend WithEvents txtCosto_Total As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label

End Class
