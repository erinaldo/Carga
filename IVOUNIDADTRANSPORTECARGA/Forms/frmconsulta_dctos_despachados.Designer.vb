<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconsulta_dctos_despachados
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_agencia_destino = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmb_agencia_origen = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_gt = New System.Windows.Forms.ComboBox
        Me.btn_filtrar = New System.Windows.Forms.Button
        Me.DGV_DCTO_DESPACHADOS = New System.Windows.Forms.DataGridView
        Me.lblRegistros = New System.Windows.Forms.Label
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
        CType(Me.DGV_DCTO_DESPACHADOS, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.DGV_DCTO_DESPACHADOS)
        Me.Panel.Location = New System.Drawing.Point(2, 114)
        Me.Panel.Size = New System.Drawing.Size(728, 346)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(329, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Ag. Destino :"
        '
        'cmb_agencia_destino
        '
        Me.cmb_agencia_destino.FormattingEnabled = True
        Me.cmb_agencia_destino.Location = New System.Drawing.Point(418, 64)
        Me.cmb_agencia_destino.Name = "cmb_agencia_destino"
        Me.cmb_agencia_destino.Size = New System.Drawing.Size(238, 21)
        Me.cmb_agencia_destino.TabIndex = 100
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(5, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Ag. Origen :"
        '
        'cmb_agencia_origen
        '
        Me.cmb_agencia_origen.FormattingEnabled = True
        Me.cmb_agencia_origen.Location = New System.Drawing.Point(82, 64)
        Me.cmb_agencia_origen.Name = "cmb_agencia_origen"
        Me.cmb_agencia_origen.Size = New System.Drawing.Size(238, 21)
        Me.cmb_agencia_origen.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(329, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Destino :"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(418, 37)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(5, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Origen :"
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(82, 37)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 92
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
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
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
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(238, 13)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_agencia_destino)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmb_agencia_origen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_gt)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btn_filtrar)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 94)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(329, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Estado gt : "
        '
        'cmb_gt
        '
        Me.cmb_gt.FormattingEnabled = True
        Me.cmb_gt.Location = New System.Drawing.Point(418, 10)
        Me.cmb_gt.Name = "cmb_gt"
        Me.cmb_gt.Size = New System.Drawing.Size(238, 21)
        Me.cmb_gt.TabIndex = 96
        '
        'btn_filtrar
        '
        Me.btn_filtrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_filtrar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_filtrar.Location = New System.Drawing.Point(664, 10)
        Me.btn_filtrar.Name = "btn_filtrar"
        Me.btn_filtrar.Size = New System.Drawing.Size(55, 23)
        Me.btn_filtrar.TabIndex = 8
        Me.btn_filtrar.Text = "Filtrar"
        Me.btn_filtrar.UseVisualStyleBackColor = True
        '
        'DGV_DCTO_DESPACHADOS
        '
        Me.DGV_DCTO_DESPACHADOS.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGV_DCTO_DESPACHADOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DCTO_DESPACHADOS.Location = New System.Drawing.Point(0, 3)
        Me.DGV_DCTO_DESPACHADOS.Name = "DGV_DCTO_DESPACHADOS"
        Me.DGV_DCTO_DESPACHADOS.Size = New System.Drawing.Size(726, 352)
        Me.DGV_DCTO_DESPACHADOS.TabIndex = 0
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(637, 98)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 85
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmconsulta_dctos_despachados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "frmconsulta_dctos_despachados"
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_DCTO_DESPACHADOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_agencia_destino As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_agencia_origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_gt As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_filtrar As System.Windows.Forms.Button
    Friend WithEvents DGV_DCTO_DESPACHADOS As System.Windows.Forms.DataGridView

    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
