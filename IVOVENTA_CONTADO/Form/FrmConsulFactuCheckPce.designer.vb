<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulFactuCheckPce
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBIDAGENCIAS_DESTINO = New System.Windows.Forms.ComboBox
        Me.ChkRangoFecha = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MTBNro_factura = New System.Windows.Forms.MaskedTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbidtipo_entrega = New System.Windows.Forms.ComboBox
        Me.cbidtipo_comprobante = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.txttotal_costo = New System.Windows.Forms.TextBox
        Me.txtsub_total = New System.Windows.Forms.TextBox
        Me.txtmonto_impuesto = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.BtnActu = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.BtnActu)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.txttotal_costo)
        Me.TabLista.Controls.Add(Me.txtsub_total)
        Me.TabLista.Controls.Add(Me.txtmonto_impuesto)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.Label14)
        Me.TabLista.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtmonto_impuesto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtsub_total, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txttotal_costo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.BtnActu, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.DGV3)
        Me.Panel.Location = New System.Drawing.Point(6, 126)
        Me.Panel.Size = New System.Drawing.Size(720, 294)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CBIDAGENCIAS_DESTINO)
        Me.GroupBox1.Controls.Add(Me.ChkRangoFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.MTBNro_factura)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_entrega)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_comprobante)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 101)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(301, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Agencia entrega:"
        '
        'CBIDAGENCIAS_DESTINO
        '
        Me.CBIDAGENCIAS_DESTINO.FormattingEnabled = True
        Me.CBIDAGENCIAS_DESTINO.Location = New System.Drawing.Point(390, 15)
        Me.CBIDAGENCIAS_DESTINO.Name = "CBIDAGENCIAS_DESTINO"
        Me.CBIDAGENCIAS_DESTINO.Size = New System.Drawing.Size(243, 21)
        Me.CBIDAGENCIAS_DESTINO.TabIndex = 97
        '
        'ChkRangoFecha
        '
        Me.ChkRangoFecha.AutoSize = True
        Me.ChkRangoFecha.Checked = True
        Me.ChkRangoFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRangoFecha.Location = New System.Drawing.Point(73, 19)
        Me.ChkRangoFecha.Name = "ChkRangoFecha"
        Me.ChkRangoFecha.Size = New System.Drawing.Size(188, 17)
        Me.ChkRangoFecha.TabIndex = 96
        Me.ChkRangoFecha.Text = "Utilizar fechas como rango de filtro"
        Me.ChkRangoFecha.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(220, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Nro. Factura/Boleta:"
        '
        'MTBNro_factura
        '
        Me.MTBNro_factura.Location = New System.Drawing.Point(330, 68)
        Me.MTBNro_factura.Mask = "999-9999999"
        Me.MTBNro_factura.Name = "MTBNro_factura"
        Me.MTBNro_factura.Size = New System.Drawing.Size(75, 20)
        Me.MTBNro_factura.TabIndex = 94
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(2, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Tipo Entraga:"
        '
        'cbidtipo_entrega
        '
        Me.cbidtipo_entrega.FormattingEnabled = True
        Me.cbidtipo_entrega.Location = New System.Drawing.Point(73, 68)
        Me.cbidtipo_entrega.Name = "cbidtipo_entrega"
        Me.cbidtipo_entrega.Size = New System.Drawing.Size(135, 21)
        Me.cbidtipo_entrega.TabIndex = 9
        '
        'cbidtipo_comprobante
        '
        Me.cbidtipo_comprobante.FormattingEnabled = True
        Me.cbidtipo_comprobante.Location = New System.Drawing.Point(390, 43)
        Me.cbidtipo_comprobante.Name = "cbidtipo_comprobante"
        Me.cbidtipo_comprobante.Size = New System.Drawing.Size(135, 21)
        Me.cbidtipo_comprobante.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(303, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "T. Comprobante:"
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(217, 42)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(73, 42)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(159, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(5, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio :"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 32)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.BackgroundColor = System.Drawing.Color.White
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV3.Location = New System.Drawing.Point(0, 0)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(720, 294)
        Me.DGV3.TabIndex = 11
        '
        'txttotal_costo
        '
        Me.txttotal_costo.Location = New System.Drawing.Point(626, 436)
        Me.txttotal_costo.Name = "txttotal_costo"
        Me.txttotal_costo.ReadOnly = True
        Me.txttotal_costo.Size = New System.Drawing.Size(100, 20)
        Me.txttotal_costo.TabIndex = 59
        Me.txttotal_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsub_total
        '
        Me.txtsub_total.Location = New System.Drawing.Point(417, 436)
        Me.txtsub_total.Name = "txtsub_total"
        Me.txtsub_total.ReadOnly = True
        Me.txtsub_total.Size = New System.Drawing.Size(100, 20)
        Me.txtsub_total.TabIndex = 59
        Me.txtsub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmonto_impuesto
        '
        Me.txtmonto_impuesto.Location = New System.Drawing.Point(520, 436)
        Me.txtmonto_impuesto.Name = "txtmonto_impuesto"
        Me.txtmonto_impuesto.ReadOnly = True
        Me.txtmonto_impuesto.Size = New System.Drawing.Size(100, 20)
        Me.txtmonto_impuesto.TabIndex = 59
        Me.txtmonto_impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(414, 423)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 13)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "Sub Total"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(517, 423)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Monto Impuesto"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(623, 423)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Total Costo"
        '
        'BtnActu
        '
        Me.BtnActu.BackColor = System.Drawing.Color.Transparent
        Me.BtnActu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnActu.Location = New System.Drawing.Point(6, 426)
        Me.BtnActu.Name = "BtnActu"
        Me.BtnActu.Size = New System.Drawing.Size(153, 23)
        Me.BtnActu.TabIndex = 99
        Me.BtnActu.Text = "Actualizar Fecha"
        Me.BtnActu.UseVisualStyleBackColor = False
        '
        'FrmConsulFactuCheckPce
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulFactuCheckPce"
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
        Me.Panel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbidtipo_comprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents txttotal_costo As System.Windows.Forms.TextBox
    Friend WithEvents txtsub_total As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_impuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_entrega As System.Windows.Forms.ComboBox
    Friend WithEvents MTBNro_factura As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkRangoFecha As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBIDAGENCIAS_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents BtnActu As System.Windows.Forms.Button

End Class
