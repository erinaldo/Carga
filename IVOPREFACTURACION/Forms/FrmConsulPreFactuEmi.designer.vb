<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulPreFactuEmi
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
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.grbReportes = New System.Windows.Forms.GroupBox()
        Me.rbPorDt = New System.Windows.Forms.RadioButton()
        Me.rbPorOrigen = New System.Windows.Forms.RadioButton()
        Me.rbtSubcuenta = New System.Windows.Forms.RadioButton()
        Me.rbPorDesti = New System.Windows.Forms.RadioButton()
        Me.rbgene = New System.Windows.Forms.RadioButton()
        Me.rbde = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RBGUIAS_ENVI = New System.Windows.Forms.RadioButton()
        Me.RBPREFACTU = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbtodos = New System.Windows.Forms.RadioButton()
        Me.rbfactu = New System.Windows.Forms.RadioButton()
        Me.rbpendi = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBNRO_PREFACTURA = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.menuprefactura = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnularPreFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgv4 = New System.Windows.Forms.DataGridView()
        Me.LblRegistros2 = New System.Windows.Forms.Label()
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
        Me.grbReportes.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuprefactura.SuspendLayout()
        CType(Me.dgv4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.dgv4)
        Me.Panel.Location = New System.Drawing.Point(3, 268)
        Me.Panel.Size = New System.Drawing.Size(724, 165)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.LblRegistros2)
        Me.TabLista.Controls.Add(Me.DGV3)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGV3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LblRegistros2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbProducto)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.grbReportes)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.rbtodos)
        Me.GroupBox1.Controls.Add(Me.rbfactu)
        Me.GroupBox1.Controls.Add(Me.rbpendi)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TBNRO_PREFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 127)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Items.AddRange(New Object() {"COURIER"})
        Me.cmbProducto.Location = New System.Drawing.Point(498, 100)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(201, 21)
        Me.cmbProducto.TabIndex = 129
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(436, 105)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 13)
        Me.Label28.TabIndex = 128
        Me.Label28.Text = "Producto :"
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(630, 110)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 127
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grbReportes
        '
        Me.grbReportes.Controls.Add(Me.rbPorDt)
        Me.grbReportes.Controls.Add(Me.rbPorOrigen)
        Me.grbReportes.Controls.Add(Me.rbtSubcuenta)
        Me.grbReportes.Controls.Add(Me.rbPorDesti)
        Me.grbReportes.Controls.Add(Me.rbgene)
        Me.grbReportes.Controls.Add(Me.rbde)
        Me.grbReportes.Location = New System.Drawing.Point(326, 59)
        Me.grbReportes.Name = "grbReportes"
        Me.grbReportes.Size = New System.Drawing.Size(326, 35)
        Me.grbReportes.TabIndex = 86
        Me.grbReportes.TabStop = False
        Me.grbReportes.Text = "Reportes"
        '
        'rbPorDt
        '
        Me.rbPorDt.AutoSize = True
        Me.rbPorDt.Location = New System.Drawing.Point(327, 11)
        Me.rbPorDt.Name = "rbPorDt"
        Me.rbPorDt.Size = New System.Drawing.Size(40, 17)
        Me.rbPorDt.TabIndex = 2
        Me.rbPorDt.Text = "DT"
        Me.rbPorDt.UseVisualStyleBackColor = True
        Me.rbPorDt.Visible = False
        '
        'rbPorOrigen
        '
        Me.rbPorOrigen.AutoSize = True
        Me.rbPorOrigen.Location = New System.Drawing.Point(127, 12)
        Me.rbPorOrigen.Name = "rbPorOrigen"
        Me.rbPorOrigen.Size = New System.Drawing.Size(56, 17)
        Me.rbPorOrigen.TabIndex = 1
        Me.rbPorOrigen.Text = "Origen"
        Me.rbPorOrigen.UseVisualStyleBackColor = True
        '
        'rbtSubcuenta
        '
        Me.rbtSubcuenta.AutoSize = True
        Me.rbtSubcuenta.Location = New System.Drawing.Point(245, 12)
        Me.rbtSubcuenta.Name = "rbtSubcuenta"
        Me.rbtSubcuenta.Size = New System.Drawing.Size(77, 17)
        Me.rbtSubcuenta.TabIndex = 0
        Me.rbtSubcuenta.Text = "Subcuenta"
        Me.rbtSubcuenta.UseVisualStyleBackColor = True
        '
        'rbPorDesti
        '
        Me.rbPorDesti.AutoSize = True
        Me.rbPorDesti.Location = New System.Drawing.Point(183, 12)
        Me.rbPorDesti.Name = "rbPorDesti"
        Me.rbPorDesti.Size = New System.Drawing.Size(61, 17)
        Me.rbPorDesti.TabIndex = 0
        Me.rbPorDesti.Text = "Destino"
        Me.rbPorDesti.UseVisualStyleBackColor = True
        '
        'rbgene
        '
        Me.rbgene.AutoSize = True
        Me.rbgene.Checked = True
        Me.rbgene.Location = New System.Drawing.Point(4, 12)
        Me.rbgene.Name = "rbgene"
        Me.rbgene.Size = New System.Drawing.Size(62, 17)
        Me.rbgene.TabIndex = 0
        Me.rbgene.TabStop = True
        Me.rbgene.Text = "General"
        Me.rbgene.UseVisualStyleBackColor = True
        '
        'rbde
        '
        Me.rbde.AutoSize = True
        Me.rbde.Location = New System.Drawing.Point(68, 12)
        Me.rbde.Name = "rbde"
        Me.rbde.Size = New System.Drawing.Size(58, 17)
        Me.rbde.TabIndex = 0
        Me.rbde.Text = "Detalle"
        Me.rbde.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox2.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.RBGUIAS_ENVI)
        Me.GroupBox2.Controls.Add(Me.RBPREFACTU)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 58)
        Me.GroupBox2.TabIndex = 85
        Me.GroupBox2.TabStop = False
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(231, 29)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(79, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 5
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(68, 29)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(79, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(2, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio"
        '
        'RBGUIAS_ENVI
        '
        Me.RBGUIAS_ENVI.AutoSize = True
        Me.RBGUIAS_ENVI.Location = New System.Drawing.Point(142, 11)
        Me.RBGUIAS_ENVI.Name = "RBGUIAS_ENVI"
        Me.RBGUIAS_ENVI.Size = New System.Drawing.Size(147, 17)
        Me.RBGUIAS_ENVI.TabIndex = 3
        Me.RBGUIAS_ENVI.Text = "Rango en Guias de Envio"
        Me.RBGUIAS_ENVI.UseVisualStyleBackColor = True
        '
        'RBPREFACTU
        '
        Me.RBPREFACTU.AutoSize = True
        Me.RBPREFACTU.Checked = True
        Me.RBPREFACTU.Location = New System.Drawing.Point(4, 11)
        Me.RBPREFACTU.Name = "RBPREFACTU"
        Me.RBPREFACTU.Size = New System.Drawing.Size(124, 17)
        Me.RBPREFACTU.TabIndex = 2
        Me.RBPREFACTU.TabStop = True
        Me.RBPREFACTU.Text = "Rango en Prefactura"
        Me.RBPREFACTU.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(166, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Fin"
        '
        'rbtodos
        '
        Me.rbtodos.AutoSize = True
        Me.rbtodos.Location = New System.Drawing.Point(661, 40)
        Me.rbtodos.Name = "rbtodos"
        Me.rbtodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtodos.TabIndex = 9
        Me.rbtodos.Text = "Todos"
        Me.rbtodos.UseVisualStyleBackColor = True
        '
        'rbfactu
        '
        Me.rbfactu.AutoSize = True
        Me.rbfactu.Location = New System.Drawing.Point(582, 40)
        Me.rbfactu.Name = "rbfactu"
        Me.rbfactu.Size = New System.Drawing.Size(73, 17)
        Me.rbfactu.TabIndex = 8
        Me.rbfactu.Text = "Facturado"
        Me.rbfactu.UseVisualStyleBackColor = True
        '
        'rbpendi
        '
        Me.rbpendi.AutoSize = True
        Me.rbpendi.Checked = True
        Me.rbpendi.Location = New System.Drawing.Point(498, 40)
        Me.rbpendi.Name = "rbpendi"
        Me.rbpendi.Size = New System.Drawing.Size(78, 17)
        Me.rbpendi.TabIndex = 7
        Me.rbpendi.TabStop = True
        Me.rbpendi.Text = "Pendientes"
        Me.rbpendi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(328, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Nº Prefac."
        '
        'TBNRO_PREFACTURA
        '
        Me.TBNRO_PREFACTURA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBNRO_PREFACTURA.Location = New System.Drawing.Point(387, 38)
        Me.TBNRO_PREFACTURA.Name = "TBNRO_PREFACTURA"
        Me.TBNRO_PREFACTURA.Size = New System.Drawing.Size(96, 20)
        Me.TBNRO_PREFACTURA.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(219, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Usuario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia:"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(271, 102)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(150, 21)
        Me.cmbUsuarios.TabIndex = 11
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(61, 102)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(145, 21)
        Me.cmbAgencia.TabIndex = 10
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
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.BackgroundColor = System.Drawing.Color.White
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.ContextMenuStrip = Me.menuprefactura
        Me.DGV3.Location = New System.Drawing.Point(-1, 135)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(728, 112)
        Me.DGV3.TabIndex = 14
        '
        'menuprefactura
        '
        Me.menuprefactura.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularPreFacturaToolStripMenuItem})
        Me.menuprefactura.Name = "menuprefactura"
        Me.menuprefactura.Size = New System.Drawing.Size(174, 26)
        '
        'AnularPreFacturaToolStripMenuItem
        '
        Me.AnularPreFacturaToolStripMenuItem.Name = "AnularPreFacturaToolStripMenuItem"
        Me.AnularPreFacturaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AnularPreFacturaToolStripMenuItem.Text = "Anular Pre-Factura"
        '
        'dgv4
        '
        Me.dgv4.BackgroundColor = System.Drawing.Color.White
        Me.dgv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv4.Location = New System.Drawing.Point(-2, 0)
        Me.dgv4.Name = "dgv4"
        Me.dgv4.Size = New System.Drawing.Size(728, 168)
        Me.dgv4.TabIndex = 15
        '
        'LblRegistros2
        '
        Me.LblRegistros2.BackColor = System.Drawing.Color.Transparent
        Me.LblRegistros2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros2.ForeColor = System.Drawing.Color.Black
        Me.LblRegistros2.Location = New System.Drawing.Point(633, 252)
        Me.LblRegistros2.Name = "LblRegistros2"
        Me.LblRegistros2.Size = New System.Drawing.Size(93, 13)
        Me.LblRegistros2.TabIndex = 128
        Me.LblRegistros2.Text = "0"
        Me.LblRegistros2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmConsulPreFactuEmi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.ControlBox = True
        Me.Name = "FrmConsulPreFactuEmi"
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbReportes.ResumeLayout(False)
        Me.grbReportes.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuprefactura.ResumeLayout(False)
        CType(Me.dgv4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
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
    Friend WithEvents dgv4 As System.Windows.Forms.DataGridView
    Friend WithEvents rbtodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbfactu As System.Windows.Forms.RadioButton
    Friend WithEvents rbpendi As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBNRO_PREFACTURA As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGUIAS_ENVI As System.Windows.Forms.RadioButton
    Friend WithEvents RBPREFACTU As System.Windows.Forms.RadioButton
    Friend WithEvents menuprefactura As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AnularPreFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grbReportes As System.Windows.Forms.GroupBox
    Friend WithEvents rbPorDesti As System.Windows.Forms.RadioButton
    Friend WithEvents rbde As System.Windows.Forms.RadioButton
    Friend WithEvents rbgene As System.Windows.Forms.RadioButton

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents LblRegistros2 As System.Windows.Forms.Label
    Friend WithEvents rbPorDt As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorOrigen As System.Windows.Forms.RadioButton
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents rbtSubcuenta As System.Windows.Forms.RadioButton

End Class
