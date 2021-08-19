<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconsultaguiatransportista_xdcto
    Inherits INTEGRACION.FrmPlantillaFacturacion

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
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbidtipo_servicio = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblRegistros = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbestado = New System.Windows.Forms.ComboBox
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TBnro_unidad_transporte = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btn_filtrar = New System.Windows.Forms.Button
        Me.dvg_guia_transportista_xdcto = New System.Windows.Forms.DataGridView
        Me.CMS_consultas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Labnroreg = New System.Windows.Forms.Label
        Me.txttotrecepcionado = New System.Windows.Forms.TextBox
        Me.Txttot_cantidad = New System.Windows.Forms.TextBox
        Me.txttotdespacho = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txttotal_entregado = New System.Windows.Forms.TextBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dvg_guia_transportista_xdcto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_consultas.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.ForeColor = System.Drawing.Color.Maroon
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.dvg_guia_transportista_xdcto)
        Me.Panel.Location = New System.Drawing.Point(6, 106)
        Me.Panel.Size = New System.Drawing.Size(720, 310)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.txttotal_entregado)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.Label8)
        Me.TabLista.Controls.Add(Me.Label6)
        Me.TabLista.Controls.Add(Me.txttotdespacho)
        Me.TabLista.Controls.Add(Me.Txttot_cantidad)
        Me.TabLista.Controls.Add(Me.txttotrecepcionado)
        Me.TabLista.Controls.Add(Me.Labnroreg)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Labnroreg, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txttotrecepcionado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Txttot_cantidad, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txttotdespacho, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txttotal_entregado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(437, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "T. Servicio :"
        '
        'cbidtipo_servicio
        '
        Me.cbidtipo_servicio.FormattingEnabled = True
        Me.cbidtipo_servicio.Location = New System.Drawing.Point(504, 15)
        Me.cbidtipo_servicio.Name = "cbidtipo_servicio"
        Me.cbidtipo_servicio.Size = New System.Drawing.Size(152, 21)
        Me.cbidtipo_servicio.TabIndex = 94
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(329, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Destino :"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(418, 39)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 94
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(82, 39)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 92
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbestado)
        Me.GroupBox1.Controls.Add(Me.txtcliente)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TBnro_unidad_transporte)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_servicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btn_filtrar)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 94)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(654, 74)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(67, 13)
        Me.lblRegistros.TabIndex = 130
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(329, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Estado :"
        '
        'cmbestado
        '
        Me.cmbestado.FormattingEnabled = True
        Me.cmbestado.Location = New System.Drawing.Point(418, 66)
        Me.cmbestado.Name = "cmbestado"
        Me.cmbestado.Size = New System.Drawing.Size(238, 21)
        Me.cmbestado.TabIndex = 102
        '
        'txtcliente
        '
        Me.txtcliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcliente.Location = New System.Drawing.Point(82, 66)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(238, 20)
        Me.txtcliente.TabIndex = 101
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(5, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Cliente : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(331, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Nº Buss :"
        '
        'TBnro_unidad_transporte
        '
        Me.TBnro_unidad_transporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBnro_unidad_transporte.Location = New System.Drawing.Point(385, 15)
        Me.TBnro_unidad_transporte.Name = "TBnro_unidad_transporte"
        Me.TBnro_unidad_transporte.Size = New System.Drawing.Size(46, 20)
        Me.TBnro_unidad_transporte.TabIndex = 98
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(5, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Origen :"
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(238, 13)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(82, 13)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(172, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(5, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio :"
        '
        'btn_filtrar
        '
        Me.btn_filtrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_filtrar.Location = New System.Drawing.Point(664, 10)
        Me.btn_filtrar.Name = "btn_filtrar"
        Me.btn_filtrar.Size = New System.Drawing.Size(55, 23)
        Me.btn_filtrar.TabIndex = 8
        Me.btn_filtrar.Text = "Filtrar"
        Me.btn_filtrar.UseVisualStyleBackColor = True
        '
        'dvg_guia_transportista_xdcto
        '
        Me.dvg_guia_transportista_xdcto.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dvg_guia_transportista_xdcto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvg_guia_transportista_xdcto.ContextMenuStrip = Me.CMS_consultas
        Me.dvg_guia_transportista_xdcto.Location = New System.Drawing.Point(-1, 0)
        Me.dvg_guia_transportista_xdcto.Name = "dvg_guia_transportista_xdcto"
        Me.dvg_guia_transportista_xdcto.Size = New System.Drawing.Size(721, 309)
        Me.dvg_guia_transportista_xdcto.TabIndex = 0
        '
        'CMS_consultas
        '
        Me.CMS_consultas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerDToolStripMenuItem})
        Me.CMS_consultas.Name = "ContextMenuStrip1"
        Me.CMS_consultas.Size = New System.Drawing.Size(159, 26)
        '
        'VerDToolStripMenuItem
        '
        Me.VerDToolStripMenuItem.Name = "VerDToolStripMenuItem"
        Me.VerDToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.VerDToolStripMenuItem.Text = "Ver Documento"
        '
        'Labnroreg
        '
        Me.Labnroreg.AutoSize = True
        Me.Labnroreg.BackColor = System.Drawing.Color.Transparent
        Me.Labnroreg.Location = New System.Drawing.Point(3, 421)
        Me.Labnroreg.Name = "Labnroreg"
        Me.Labnroreg.Size = New System.Drawing.Size(0, 13)
        Me.Labnroreg.TabIndex = 60
        '
        'txttotrecepcionado
        '
        Me.txttotrecepcionado.BackColor = System.Drawing.SystemColors.Info
        Me.txttotrecepcionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotrecepcionado.Location = New System.Drawing.Point(623, 418)
        Me.txttotrecepcionado.MaxLength = 20
        Me.txttotrecepcionado.Name = "txttotrecepcionado"
        Me.txttotrecepcionado.ReadOnly = True
        Me.txttotrecepcionado.Size = New System.Drawing.Size(100, 20)
        Me.txttotrecepcionado.TabIndex = 61
        Me.txttotrecepcionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txttot_cantidad
        '
        Me.Txttot_cantidad.BackColor = System.Drawing.SystemColors.Info
        Me.Txttot_cantidad.Location = New System.Drawing.Point(267, 418)
        Me.Txttot_cantidad.Name = "Txttot_cantidad"
        Me.Txttot_cantidad.ReadOnly = True
        Me.Txttot_cantidad.Size = New System.Drawing.Size(100, 20)
        Me.Txttot_cantidad.TabIndex = 62
        Me.Txttot_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotdespacho
        '
        Me.txttotdespacho.BackColor = System.Drawing.SystemColors.Info
        Me.txttotdespacho.Location = New System.Drawing.Point(445, 418)
        Me.txttotdespacho.Name = "txttotdespacho"
        Me.txttotdespacho.ReadOnly = True
        Me.txttotdespacho.Size = New System.Drawing.Size(100, 20)
        Me.txttotdespacho.TabIndex = 63
        Me.txttotdespacho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(551, 421)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Tot. Recep. :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(373, 421)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Tot. Desp.:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(173, 421)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Tot. Cant. Bultos :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(533, 446)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Tot. Entregado. :"
        '
        'txttotal_entregado
        '
        Me.txttotal_entregado.BackColor = System.Drawing.SystemColors.Info
        Me.txttotal_entregado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotal_entregado.Location = New System.Drawing.Point(623, 443)
        Me.txttotal_entregado.MaxLength = 20
        Me.txttotal_entregado.Name = "txttotal_entregado"
        Me.txttotal_entregado.ReadOnly = True
        Me.txttotal_entregado.Size = New System.Drawing.Size(100, 20)
        Me.txttotal_entregado.TabIndex = 67
        Me.txttotal_entregado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmconsultaguiatransportista_xdcto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "frmconsultaguiatransportista_xdcto"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dvg_guia_transportista_xdcto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_consultas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_servicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_filtrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TBnro_unidad_transporte As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbestado As System.Windows.Forms.ComboBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents dvg_guia_transportista_xdcto As System.Windows.Forms.DataGridView
    Friend WithEvents Labnroreg As System.Windows.Forms.Label
    Friend WithEvents CMS_consultas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VerDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txttotdespacho As System.Windows.Forms.TextBox
    Friend WithEvents Txttot_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txttotrecepcionado As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txttotal_entregado As System.Windows.Forms.TextBox

    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
