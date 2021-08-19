<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulFactuEmi
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.cbidforma_pago = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbidtipo_moneda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.CMS_cargofactura = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CargoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblRegistros2 = New System.Windows.Forms.DataGridView()
        Me.rbgene = New System.Windows.Forms.RadioButton()
        Me.rbdeta = New System.Windows.Forms.RadioButton()
        Me.rbcobra = New System.Windows.Forms.RadioButton()
        Me.RBLISTA_GENE = New System.Windows.Forms.RadioButton()
        Me.RBACU_MENSU = New System.Windows.Forms.RadioButton()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.LblRegistros3 = New System.Windows.Forms.Label()
        Me.rbPersonalizado = New System.Windows.Forms.RadioButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_cargofactura.SuspendLayout()
        CType(Me.LblRegistros2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(782, 556)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(17, 18)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.Transparent
        Me.Panel.Controls.Add(Me.LblRegistros3)
        Me.Panel.Controls.Add(Me.DGV3)
        Me.Panel.Controls.Add(Me.LblRegistros2)
        Me.Panel.Location = New System.Drawing.Point(6, 129)
        Me.Panel.Size = New System.Drawing.Size(720, 327)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.rbPersonalizado)
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.RBLISTA_GENE)
        Me.TabLista.Controls.Add(Me.rbgene)
        Me.TabLista.Controls.Add(Me.rbcobra)
        Me.TabLista.Controls.Add(Me.rbdeta)
        Me.TabLista.Controls.Add(Me.RBACU_MENSU)
        Me.TabLista.Controls.SetChildIndex(Me.RBACU_MENSU, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rbdeta, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rbcobra, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rbgene, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBLISTA_GENE, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rbPersonalizado, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbProducto)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.cbidforma_pago)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbidtipo_moneda)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
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
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Items.AddRange(New Object() {"COURIER"})
        Me.cmbProducto.Location = New System.Drawing.Point(518, 74)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(201, 21)
        Me.cmbProducto.TabIndex = 106
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(456, 78)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 13)
        Me.Label28.TabIndex = 105
        Me.Label28.Text = "Producto :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(235, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Usuario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(9, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia:"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(291, 73)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(144, 21)
        Me.cmbUsuarios.TabIndex = 7
        '
        'cmbAgencia
        '
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(65, 73)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(157, 21)
        Me.cmbAgencia.TabIndex = 6
        '
        'cbidforma_pago
        '
        Me.cbidforma_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbidforma_pago.FormattingEnabled = True
        Me.cbidforma_pago.Location = New System.Drawing.Point(594, 40)
        Me.cbidforma_pago.Name = "cbidforma_pago"
        Me.cbidforma_pago.Size = New System.Drawing.Size(126, 21)
        Me.cbidforma_pago.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(520, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Forma Pago:"
        '
        'cbidtipo_moneda
        '
        Me.cbidtipo_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbidtipo_moneda.FormattingEnabled = True
        Me.cbidtipo_moneda.Location = New System.Drawing.Point(380, 40)
        Me.cbidtipo_moneda.Name = "cbidtipo_moneda"
        Me.cbidtipo_moneda.Size = New System.Drawing.Size(132, 21)
        Me.cbidtipo_moneda.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(325, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Moneda:"
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.Location = New System.Drawing.Point(271, 13)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(317, 20)
        Me.txtidpersona.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(92, 13)
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
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Codigo Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(220, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cliente :"
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.CustomFormat = ""
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(238, 40)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.CustomFormat = ""
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(82, 40)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(172, 44)
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
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.BackgroundColor = System.Drawing.Color.White
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.ContextMenuStrip = Me.CMS_cargofactura
        Me.DGV3.Location = New System.Drawing.Point(0, 0)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(719, 133)
        Me.DGV3.TabIndex = 59
        '
        'CMS_cargofactura
        '
        Me.CMS_cargofactura.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargoToolStripMenuItem})
        Me.CMS_cargofactura.Name = "CMS_cargofactura"
        Me.CMS_cargofactura.Size = New System.Drawing.Size(107, 26)
        '
        'CargoToolStripMenuItem
        '
        Me.CargoToolStripMenuItem.Name = "CargoToolStripMenuItem"
        Me.CargoToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.CargoToolStripMenuItem.Text = "Cargo"
        '
        'LblRegistros2
        '
        Me.LblRegistros2.BackgroundColor = System.Drawing.Color.White
        Me.LblRegistros2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LblRegistros2.Location = New System.Drawing.Point(0, 155)
        Me.LblRegistros2.Name = "LblRegistros2"
        Me.LblRegistros2.Size = New System.Drawing.Size(719, 172)
        Me.LblRegistros2.TabIndex = 59
        '
        'rbgene
        '
        Me.rbgene.AutoSize = True
        Me.rbgene.BackColor = System.Drawing.Color.Transparent
        Me.rbgene.Location = New System.Drawing.Point(67, 109)
        Me.rbgene.Name = "rbgene"
        Me.rbgene.Size = New System.Drawing.Size(98, 17)
        Me.rbgene.TabIndex = 60
        Me.rbgene.Text = "Factura Emitida"
        Me.rbgene.UseVisualStyleBackColor = False
        '
        'rbdeta
        '
        Me.rbdeta.AutoSize = True
        Me.rbdeta.BackColor = System.Drawing.Color.Transparent
        Me.rbdeta.Location = New System.Drawing.Point(171, 109)
        Me.rbdeta.Name = "rbdeta"
        Me.rbdeta.Size = New System.Drawing.Size(97, 17)
        Me.rbdeta.TabIndex = 61
        Me.rbdeta.Text = "Detalle Factura"
        Me.rbdeta.UseVisualStyleBackColor = False
        '
        'rbcobra
        '
        Me.rbcobra.AutoSize = True
        Me.rbcobra.BackColor = System.Drawing.Color.Transparent
        Me.rbcobra.Location = New System.Drawing.Point(274, 109)
        Me.rbcobra.Name = "rbcobra"
        Me.rbcobra.Size = New System.Drawing.Size(111, 17)
        Me.rbcobra.TabIndex = 62
        Me.rbcobra.Text = "Formato Cobranza"
        Me.rbcobra.UseVisualStyleBackColor = False
        '
        'RBLISTA_GENE
        '
        Me.RBLISTA_GENE.AutoSize = True
        Me.RBLISTA_GENE.BackColor = System.Drawing.Color.Transparent
        Me.RBLISTA_GENE.Checked = True
        Me.RBLISTA_GENE.Location = New System.Drawing.Point(2, 109)
        Me.RBLISTA_GENE.Name = "RBLISTA_GENE"
        Me.RBLISTA_GENE.Size = New System.Drawing.Size(62, 17)
        Me.RBLISTA_GENE.TabIndex = 60
        Me.RBLISTA_GENE.TabStop = True
        Me.RBLISTA_GENE.Text = "General"
        Me.RBLISTA_GENE.UseVisualStyleBackColor = False
        '
        'RBACU_MENSU
        '
        Me.RBACU_MENSU.AutoSize = True
        Me.RBACU_MENSU.BackColor = System.Drawing.Color.Transparent
        Me.RBACU_MENSU.Location = New System.Drawing.Point(394, 109)
        Me.RBACU_MENSU.Name = "RBACU_MENSU"
        Me.RBACU_MENSU.Size = New System.Drawing.Size(120, 17)
        Me.RBACU_MENSU.TabIndex = 62
        Me.RBACU_MENSU.Text = "Factura Crédito Mes"
        Me.RBACU_MENSU.UseVisualStyleBackColor = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(659, 113)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(67, 13)
        Me.lblRegistros.TabIndex = 129
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblRegistros3
        '
        Me.LblRegistros3.BackColor = System.Drawing.Color.Transparent
        Me.LblRegistros3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros3.ForeColor = System.Drawing.Color.Black
        Me.LblRegistros3.Location = New System.Drawing.Point(649, 139)
        Me.LblRegistros3.Name = "LblRegistros3"
        Me.LblRegistros3.Size = New System.Drawing.Size(67, 13)
        Me.LblRegistros3.TabIndex = 130
        Me.LblRegistros3.Text = "0"
        Me.LblRegistros3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbPersonalizado
        '
        Me.rbPersonalizado.AutoSize = True
        Me.rbPersonalizado.BackColor = System.Drawing.Color.Transparent
        Me.rbPersonalizado.Location = New System.Drawing.Point(525, 109)
        Me.rbPersonalizado.Name = "rbPersonalizado"
        Me.rbPersonalizado.Size = New System.Drawing.Size(101, 17)
        Me.rbPersonalizado.TabIndex = 130
        Me.rbPersonalizado.Text = "Subcuenta SAP"
        Me.rbPersonalizado.UseVisualStyleBackColor = False
        Me.rbPersonalizado.Visible = False
        '
        'FrmConsulFactuEmi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmConsulFactuEmi"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
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
        Me.Panel.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_cargofactura.ResumeLayout(False)
        CType(Me.LblRegistros2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cbidforma_pago As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbidtipo_moneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents LblRegistros2 As System.Windows.Forms.DataGridView
    Friend WithEvents rbgene As System.Windows.Forms.RadioButton
    Friend WithEvents rbcobra As System.Windows.Forms.RadioButton
    Friend WithEvents rbdeta As System.Windows.Forms.RadioButton
    Friend WithEvents CMS_cargofactura As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CargoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RBLISTA_GENE As System.Windows.Forms.RadioButton
    Friend WithEvents RBACU_MENSU As System.Windows.Forms.RadioButton

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents LblRegistros3 As System.Windows.Forms.Label
    Friend WithEvents rbPersonalizado As System.Windows.Forms.RadioButton
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label

End Class
