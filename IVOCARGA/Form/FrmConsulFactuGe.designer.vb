<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulFactuGe
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbidtipo_entrega = New System.Windows.Forms.ComboBox()
        Me.cbidforma_pago = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbidtipo_comprobante = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBAGRU_FUNCI = New System.Windows.Forms.RadioButton()
        Me.RBGENE = New System.Windows.Forms.RadioButton()
        Me.LPages = New System.Windows.Forms.Label()
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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(814, 459)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Location = New System.Drawing.Point(0, 23)
        Me.ShadowLabel1.Size = New System.Drawing.Size(814, 10)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 38)
        Me.SplitContainer2.Size = New System.Drawing.Size(870, 361)
        Me.SplitContainer2.SplitterDistance = 19
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(-1, 17)
        Me.Panel1.Size = New System.Drawing.Size(744, 461)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(734, 449)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(734, 449)
        '
        'TabPage3
        '
        Me.TabPage3.Size = New System.Drawing.Size(734, 449)
        '
        'TabPage4
        '
        Me.TabPage4.Size = New System.Drawing.Size(734, 449)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Location = New System.Drawing.Point(26, 8)
        Me.MyTreeView.Size = New System.Drawing.Size(32743, 539)
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.Transparent
        Me.Panel.Location = New System.Drawing.Point(2, 219)
        Me.Panel.Size = New System.Drawing.Size(724, 19)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(742, 505)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.LPages)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.GroupBox2)
        Me.TabLista.Size = New System.Drawing.Size(734, 476)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LPages, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Size = New System.Drawing.Size(734, 449)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CboTipoProducto)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_entrega)
        Me.GroupBox1.Controls.Add(Me.cbidforma_pago)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_comprobante)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 163)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Location = New System.Drawing.Point(82, 125)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(243, 21)
        Me.CboTipoProducto.TabIndex = 109
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(5, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 13)
        Me.Label22.TabIndex = 108
        Me.Label22.Text = "Tipo Producto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(354, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Destino:"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(406, 94)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(243, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(4, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Origen:"
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(82, 94)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(243, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 98
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(225, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Funcionario:"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(293, 67)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(243, 21)
        Me.cmbUsuarios.TabIndex = 97
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(2, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Tipo Entrega:"
        '
        'cbidtipo_entrega
        '
        Me.cbidtipo_entrega.FormattingEnabled = True
        Me.cbidtipo_entrega.Location = New System.Drawing.Point(82, 67)
        Me.cbidtipo_entrega.Name = "cbidtipo_entrega"
        Me.cbidtipo_entrega.Size = New System.Drawing.Size(135, 21)
        Me.cbidtipo_entrega.TabIndex = 9
        '
        'cbidforma_pago
        '
        Me.cbidforma_pago.FormattingEnabled = True
        Me.cbidforma_pago.Location = New System.Drawing.Point(595, 41)
        Me.cbidforma_pago.Name = "cbidforma_pago"
        Me.cbidforma_pago.Size = New System.Drawing.Size(124, 21)
        Me.cbidforma_pago.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(542, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "F. Pago:"
        '
        'cbidtipo_comprobante
        '
        Me.cbidtipo_comprobante.FormattingEnabled = True
        Me.cbidtipo_comprobante.Location = New System.Drawing.Point(401, 42)
        Me.cbidtipo_comprobante.Name = "cbidtipo_comprobante"
        Me.cbidtipo_comprobante.Size = New System.Drawing.Size(135, 21)
        Me.cbidtipo_comprobante.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(314, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "T. Comprobante:"
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.Location = New System.Drawing.Point(228, 13)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(490, 20)
        Me.txtidpersona.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(82, 13)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Codigo Cli :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(185, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cliente :"
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.CustomFormat = "MMM - yyyy"
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(228, 41)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.CustomFormat = "MMM - yyyy"
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(82, 41)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(170, 44)
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
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RBAGRU_FUNCI)
        Me.GroupBox2.Controls.Add(Me.RBGENE)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 171)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(725, 42)
        Me.GroupBox2.TabIndex = 69
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reportes"
        '
        'RBAGRU_FUNCI
        '
        Me.RBAGRU_FUNCI.AutoSize = True
        Me.RBAGRU_FUNCI.Location = New System.Drawing.Point(73, 19)
        Me.RBAGRU_FUNCI.Name = "RBAGRU_FUNCI"
        Me.RBAGRU_FUNCI.Size = New System.Drawing.Size(144, 17)
        Me.RBAGRU_FUNCI.TabIndex = 0
        Me.RBAGRU_FUNCI.TabStop = True
        Me.RBAGRU_FUNCI.Text = "Agrupado por funcionario"
        Me.RBAGRU_FUNCI.UseVisualStyleBackColor = True
        '
        'RBGENE
        '
        Me.RBGENE.AutoSize = True
        Me.RBGENE.Checked = True
        Me.RBGENE.Location = New System.Drawing.Point(11, 19)
        Me.RBGENE.Name = "RBGENE"
        Me.RBGENE.Size = New System.Drawing.Size(62, 17)
        Me.RBGENE.TabIndex = 0
        Me.RBGENE.TabStop = True
        Me.RBGENE.Text = "General"
        Me.RBGENE.UseVisualStyleBackColor = True
        '
        'LPages
        '
        Me.LPages.AutoSize = True
        Me.LPages.BackColor = System.Drawing.Color.Transparent
        Me.LPages.Location = New System.Drawing.Point(326, 433)
        Me.LPages.Name = "LPages"
        Me.LPages.Size = New System.Drawing.Size(0, 13)
        Me.LPages.TabIndex = 74
        '
        'FrmConsulFactuGe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(808, 427)
        Me.Name = "FrmConsulFactuGe"
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbidforma_pago As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_comprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_entrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGENE As System.Windows.Forms.RadioButton
    Friend WithEvents RBAGRU_FUNCI As System.Windows.Forms.RadioButton
    Friend WithEvents LPages As System.Windows.Forms.Label

    Friend Shadows WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend Shadows WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label

End Class
