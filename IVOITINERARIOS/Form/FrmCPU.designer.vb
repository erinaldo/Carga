<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCPU
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNomRed = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNomEquipo = New System.Windows.Forms.TextBox()
        Me.TxtIP = New System.Windows.Forms.TextBox()
        Me.CbArea = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CbMaquina = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtReloj = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtRam = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtParticion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtHD = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CbAgencia = New System.Windows.Forms.ComboBox()
        Me.CbEstado = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtServidor = New System.Windows.Forms.TextBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.DataGridViewLista = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboMaquina = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboTipoIp = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboTipoAlmacen = New System.Windows.Forms.ComboBox()
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(546, 503)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(544, 498)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.Label12)
        Me.TabLista.Controls.Add(Me.DataGridViewLista)
        Me.TabLista.Controls.Add(Me.CbEstado)
        Me.TabLista.Size = New System.Drawing.Size(536, 469)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CbEstado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridViewLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.cboTipoIp)
        Me.TabDatos.Controls.Add(Me.Label14)
        Me.TabDatos.Controls.Add(Me.Label15)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.cboTipoAlmacen)
        Me.TabDatos.Controls.Add(Me.cboMaquina)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.TxtServidor)
        Me.TabDatos.Controls.Add(Me.Label11)
        Me.TabDatos.Controls.Add(Me.CbAgencia)
        Me.TabDatos.Controls.Add(Me.Label10)
        Me.TabDatos.Controls.Add(Me.TxtHD)
        Me.TabDatos.Controls.Add(Me.Label9)
        Me.TabDatos.Controls.Add(Me.TxtParticion)
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.TxtRam)
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.TxtReloj)
        Me.TabDatos.Controls.Add(Me.Label6)
        Me.TabDatos.Controls.Add(Me.CbMaquina)
        Me.TabDatos.Controls.Add(Me.Label5)
        Me.TabDatos.Controls.Add(Me.CbArea)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Controls.Add(Me.TxtNomRed)
        Me.TabDatos.Controls.Add(Me.Label3)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.TxtNomEquipo)
        Me.TabDatos.Controls.Add(Me.TxtIP)
        Me.TabDatos.Size = New System.Drawing.Size(536, 469)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtIP, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomEquipo, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomRed, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbArea, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbMaquina, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtReloj, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtRam, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtParticion, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtHD, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbAgencia, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label11, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtServidor, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtMensaje, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.cboMaquina, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.cboTipoAlmacen, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label13, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label15, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.cboTipoIp, 0)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridLista.Location = New System.Drawing.Point(249, 173)
        '
        'TxtBusca
        '
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(536, 469)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(536, 469)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(61, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Nombre Red"
        '
        'TxtNomRed
        '
        Me.TxtNomRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomRed.Location = New System.Drawing.Point(203, 141)
        Me.TxtNomRed.Name = "TxtNomRed"
        Me.TxtNomRed.Size = New System.Drawing.Size(132, 20)
        Me.TxtNomRed.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(61, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nombre Equipo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "IP"
        '
        'TxtNomEquipo
        '
        Me.TxtNomEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomEquipo.Location = New System.Drawing.Point(203, 111)
        Me.TxtNomEquipo.Name = "TxtNomEquipo"
        Me.TxtNomEquipo.Size = New System.Drawing.Size(305, 20)
        Me.TxtNomEquipo.TabIndex = 2
        '
        'TxtIP
        '
        Me.TxtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIP.Location = New System.Drawing.Point(203, 75)
        Me.TxtIP.Name = "TxtIP"
        Me.TxtIP.Size = New System.Drawing.Size(93, 20)
        Me.TxtIP.TabIndex = 1
        '
        'CbArea
        '
        Me.CbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbArea.FormattingEnabled = True
        Me.CbArea.Location = New System.Drawing.Point(203, 172)
        Me.CbArea.Name = "CbArea"
        Me.CbArea.Size = New System.Drawing.Size(132, 21)
        Me.CbArea.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(61, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Area"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(61, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Procesador"
        '
        'CbMaquina
        '
        Me.CbMaquina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbMaquina.FormattingEnabled = True
        Me.CbMaquina.Location = New System.Drawing.Point(203, 203)
        Me.CbMaquina.Name = "CbMaquina"
        Me.CbMaquina.Size = New System.Drawing.Size(132, 21)
        Me.CbMaquina.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(61, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Frecuencia Reloj"
        '
        'TxtReloj
        '
        Me.TxtReloj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtReloj.Location = New System.Drawing.Point(203, 262)
        Me.TxtReloj.Name = "TxtReloj"
        Me.TxtReloj.Size = New System.Drawing.Size(93, 20)
        Me.TxtReloj.TabIndex = 7
        Me.TxtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(61, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "RAM en Mb"
        '
        'TxtRam
        '
        Me.TxtRam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRam.Location = New System.Drawing.Point(203, 293)
        Me.TxtRam.Name = "TxtRam"
        Me.TxtRam.Size = New System.Drawing.Size(93, 20)
        Me.TxtRam.TabIndex = 8
        Me.TxtRam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(61, 326)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Nro.Particiones"
        '
        'TxtParticion
        '
        Me.TxtParticion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtParticion.Location = New System.Drawing.Point(203, 323)
        Me.TxtParticion.Name = "TxtParticion"
        Me.TxtParticion.Size = New System.Drawing.Size(93, 20)
        Me.TxtParticion.TabIndex = 9
        Me.TxtParticion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(61, 357)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Disco Duro en Gb"
        '
        'TxtHD
        '
        Me.TxtHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtHD.Location = New System.Drawing.Point(203, 354)
        Me.TxtHD.Name = "TxtHD"
        Me.TxtHD.Size = New System.Drawing.Size(93, 20)
        Me.TxtHD.TabIndex = 10
        Me.TxtHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(61, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Agencia"
        '
        'CbAgencia
        '
        Me.CbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAgencia.FormattingEnabled = True
        Me.CbAgencia.Location = New System.Drawing.Point(203, 231)
        Me.CbAgencia.Name = "CbAgencia"
        Me.CbAgencia.Size = New System.Drawing.Size(132, 21)
        Me.CbAgencia.TabIndex = 6
        '
        'CbEstado
        '
        Me.CbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEstado.FormattingEnabled = True
        Me.CbEstado.Location = New System.Drawing.Point(382, 34)
        Me.CbEstado.Name = "CbEstado"
        Me.CbEstado.Size = New System.Drawing.Size(121, 21)
        Me.CbEstado.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(325, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Estado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(61, 385)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Es Servidor ?"
        '
        'TxtServidor
        '
        Me.TxtServidor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtServidor.Location = New System.Drawing.Point(203, 382)
        Me.TxtServidor.Name = "TxtServidor"
        Me.TxtServidor.Size = New System.Drawing.Size(22, 20)
        Me.TxtServidor.TabIndex = 11
        '
        'DataGridViewLista
        '
        Me.DataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLista.Location = New System.Drawing.Point(21, 72)
        Me.DataGridViewLista.Name = "DataGridViewLista"
        Me.DataGridViewLista.Size = New System.Drawing.Size(482, 368)
        Me.DataGridViewLista.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(61, 411)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Tipo de Máquina"
        '
        'cboMaquina
        '
        Me.cboMaquina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaquina.FormattingEnabled = True
        Me.cboMaquina.Location = New System.Drawing.Point(203, 408)
        Me.cboMaquina.Name = "cboMaquina"
        Me.cboMaquina.Size = New System.Drawing.Size(132, 21)
        Me.cboMaquina.TabIndex = 53
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(356, 411)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "Tipo de IP"
        '
        'cboTipoIp
        '
        Me.cboTipoIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIp.FormattingEnabled = True
        Me.cboTipoIp.Location = New System.Drawing.Point(430, 408)
        Me.cboTipoIp.Name = "cboTipoIp"
        Me.cboTipoIp.Size = New System.Drawing.Size(93, 21)
        Me.cboTipoIp.TabIndex = 55
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(61, 438)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Tipo Almacén"
        '
        'cboTipoAlmacen
        '
        Me.cboTipoAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAlmacen.FormattingEnabled = True
        Me.cboTipoAlmacen.Items.AddRange(New Object() {"(SELECCIONE)", "ALMACEN", "RAMPA"})
        Me.cboTipoAlmacen.Location = New System.Drawing.Point(203, 434)
        Me.cboTipoAlmacen.Name = "cboTipoAlmacen"
        Me.cboTipoAlmacen.Size = New System.Drawing.Size(132, 21)
        Me.cboTipoAlmacen.TabIndex = 53
        '
        'FrmCPU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "FrmCPU"
        Me.Text = "FrmCPU"
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNomRed As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNomEquipo As System.Windows.Forms.TextBox
    Friend WithEvents TxtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtReloj As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CbMaquina As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtHD As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtParticion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtRam As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtServidor As System.Windows.Forms.TextBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents DataGridViewLista As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboMaquina As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboTipoIp As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAlmacen As System.Windows.Forms.ComboBox
End Class
