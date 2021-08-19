<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmseguimiento_despacho_x_dia
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
        Me.DGV_destino_x_fecha = New System.Windows.Forms.DataGridView
        Me.DGV_seg_x_fecha = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblRegistros = New System.Windows.Forms.Label
        Me.Txtsaldoalafecha = New System.Windows.Forms.TextBox
        Me.lab_saldofecha = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btn_filtrar = New System.Windows.Forms.Button
        Me.LblRegistros2 = New System.Windows.Forms.Label
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
        CType(Me.DGV_destino_x_fecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_seg_x_fecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.LblRegistros2)
        Me.Panel.Controls.Add(Me.DGV_seg_x_fecha)
        Me.Panel.Location = New System.Drawing.Point(-2, 78)
        Me.Panel.Size = New System.Drawing.Size(735, 382)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.DGV_destino_x_fecha)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGV_destino_x_fecha, 0)
        '
        'DGV_destino_x_fecha
        '
        Me.DGV_destino_x_fecha.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGV_destino_x_fecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_destino_x_fecha.Location = New System.Drawing.Point(2, 307)
        Me.DGV_destino_x_fecha.Name = "DGV_destino_x_fecha"
        Me.DGV_destino_x_fecha.Size = New System.Drawing.Size(731, 149)
        Me.DGV_destino_x_fecha.TabIndex = 62
        '
        'DGV_seg_x_fecha
        '
        Me.DGV_seg_x_fecha.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGV_seg_x_fecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_seg_x_fecha.Location = New System.Drawing.Point(4, 3)
        Me.DGV_seg_x_fecha.Name = "DGV_seg_x_fecha"
        Me.DGV_seg_x_fecha.Size = New System.Drawing.Size(729, 207)
        Me.DGV_seg_x_fecha.TabIndex = 61
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.Txtsaldoalafecha)
        Me.GroupBox1.Controls.Add(Me.lab_saldofecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btn_filtrar)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 63)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(644, 47)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(81, 13)
        Me.lblRegistros.TabIndex = 131
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txtsaldoalafecha
        '
        Me.Txtsaldoalafecha.Location = New System.Drawing.Point(420, 37)
        Me.Txtsaldoalafecha.MaxLength = 10
        Me.Txtsaldoalafecha.Name = "Txtsaldoalafecha"
        Me.Txtsaldoalafecha.Size = New System.Drawing.Size(100, 20)
        Me.Txtsaldoalafecha.TabIndex = 95
        Me.Txtsaldoalafecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lab_saldofecha
        '
        Me.lab_saldofecha.AutoSize = True
        Me.lab_saldofecha.ForeColor = System.Drawing.Color.Maroon
        Me.lab_saldofecha.Location = New System.Drawing.Point(299, 40)
        Me.lab_saldofecha.Name = "lab_saldofecha"
        Me.lab_saldofecha.Size = New System.Drawing.Size(0, 13)
        Me.lab_saldofecha.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(343, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Origen :"
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(420, 12)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 92
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
        'LblRegistros2
        '
        Me.LblRegistros2.BackColor = System.Drawing.Color.Transparent
        Me.LblRegistros2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros2.ForeColor = System.Drawing.Color.Black
        Me.LblRegistros2.Location = New System.Drawing.Point(648, 213)
        Me.LblRegistros2.Name = "LblRegistros2"
        Me.LblRegistros2.Size = New System.Drawing.Size(84, 13)
        Me.LblRegistros2.TabIndex = 132
        Me.LblRegistros2.Text = "0"
        Me.LblRegistros2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmseguimiento_despacho_x_dia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "frmseguimiento_despacho_x_dia"
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
        CType(Me.DGV_destino_x_fecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_seg_x_fecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV_destino_x_fecha As System.Windows.Forms.DataGridView
    Friend WithEvents DGV_seg_x_fecha As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_filtrar As System.Windows.Forms.Button
    Friend WithEvents Txtsaldoalafecha As System.Windows.Forms.TextBox
    Friend WithEvents lab_saldofecha As System.Windows.Forms.Label

    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents LblRegistros2 As System.Windows.Forms.Label

End Class
