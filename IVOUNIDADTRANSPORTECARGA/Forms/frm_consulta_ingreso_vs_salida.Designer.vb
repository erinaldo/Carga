<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_ingreso_vs_salida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_ingreso_vs_salida))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblRegistros = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_agencia_destino = New System.Windows.Forms.ComboBox
        Me.cmb_ciudad_destino = New System.Windows.Forms.ComboBox
        Me.cmb_ciudad_origen = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmb_agencia_origen = New System.Windows.Forms.ComboBox
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btn_filtrar = New System.Windows.Forms.Button
        Me.dgv_consulta = New System.Windows.Forms.DataGridView
        Me.lab_registro = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_tot_bultos_ingresado = New System.Windows.Forms.TextBox
        Me.txt_tot_despa_dia = New System.Windows.Forms.TextBox
        Me.txt_tot_desp_anterior = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_porc_anterior = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_porc_dia = New System.Windows.Forms.TextBox
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
        CType(Me.dgv_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.dgv_consulta)
        Me.Panel.Location = New System.Drawing.Point(3, 97)
        Me.Panel.Size = New System.Drawing.Size(725, 333)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.txt_porc_dia)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.lab_registro)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.Label5)
        Me.TabLista.Controls.Add(Me.Label6)
        Me.TabLista.Controls.Add(Me.txt_porc_anterior)
        Me.TabLista.Controls.Add(Me.txt_tot_bultos_ingresado)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.txt_tot_despa_dia)
        Me.TabLista.Controls.Add(Me.Label8)
        Me.TabLista.Controls.Add(Me.txt_tot_desp_anterior)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_desp_anterior, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_despa_dia, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_bultos_ingresado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_porc_anterior, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lab_registro, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_porc_dia, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmb_agencia_destino)
        Me.GroupBox1.Controls.Add(Me.cmb_ciudad_destino)
        Me.GroupBox1.Controls.Add(Me.cmb_ciudad_origen)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmb_agencia_origen)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btn_filtrar)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 85)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(622, 69)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(94, 13)
        Me.lblRegistros.TabIndex = 131
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(312, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Agencia Destino : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(321, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Ciudad Destino :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Ciudad Origen :"
        '
        'cmb_agencia_destino
        '
        Me.cmb_agencia_destino.FormattingEnabled = True
        Me.cmb_agencia_destino.Location = New System.Drawing.Point(409, 34)
        Me.cmb_agencia_destino.Name = "cmb_agencia_destino"
        Me.cmb_agencia_destino.Size = New System.Drawing.Size(214, 21)
        Me.cmb_agencia_destino.TabIndex = 98
        '
        'cmb_ciudad_destino
        '
        Me.cmb_ciudad_destino.FormattingEnabled = True
        Me.cmb_ciudad_destino.Location = New System.Drawing.Point(409, 8)
        Me.cmb_ciudad_destino.Name = "cmb_ciudad_destino"
        Me.cmb_ciudad_destino.Size = New System.Drawing.Size(214, 21)
        Me.cmb_ciudad_destino.TabIndex = 97
        '
        'cmb_ciudad_origen
        '
        Me.cmb_ciudad_origen.FormattingEnabled = True
        Me.cmb_ciudad_origen.Location = New System.Drawing.Point(94, 8)
        Me.cmb_ciudad_origen.Name = "cmb_ciudad_origen"
        Me.cmb_ciudad_origen.Size = New System.Drawing.Size(214, 21)
        Me.cmb_ciudad_origen.TabIndex = 96
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(-1, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Agencia Origen : "
        '
        'cmb_agencia_origen
        '
        Me.cmb_agencia_origen.FormattingEnabled = True
        Me.cmb_agencia_origen.Location = New System.Drawing.Point(94, 33)
        Me.cmb_agencia_origen.Name = "cmb_agencia_origen"
        Me.cmb_agencia_origen.Size = New System.Drawing.Size(214, 21)
        Me.cmb_agencia_origen.TabIndex = 94
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(224, 58)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 3
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(94, 58)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(178, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fec Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(15, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio :"
        '
        'btn_filtrar
        '
        Me.btn_filtrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_filtrar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_filtrar.Image = CType(resources.GetObject("btn_filtrar.Image"), System.Drawing.Image)
        Me.btn_filtrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_filtrar.Location = New System.Drawing.Point(646, 20)
        Me.btn_filtrar.Name = "btn_filtrar"
        Me.btn_filtrar.Size = New System.Drawing.Size(70, 23)
        Me.btn_filtrar.TabIndex = 8
        Me.btn_filtrar.Text = "Filtrar"
        Me.btn_filtrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_filtrar.UseVisualStyleBackColor = True
        '
        'dgv_consulta
        '
        Me.dgv_consulta.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgv_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_consulta.Location = New System.Drawing.Point(0, 1)
        Me.dgv_consulta.Name = "dgv_consulta"
        Me.dgv_consulta.Size = New System.Drawing.Size(725, 332)
        Me.dgv_consulta.TabIndex = 0
        '
        'lab_registro
        '
        Me.lab_registro.AutoSize = True
        Me.lab_registro.BackColor = System.Drawing.Color.Transparent
        Me.lab_registro.ForeColor = System.Drawing.Color.Maroon
        Me.lab_registro.Location = New System.Drawing.Point(110, 440)
        Me.lab_registro.Name = "lab_registro"
        Me.lab_registro.Size = New System.Drawing.Size(10, 13)
        Me.lab_registro.TabIndex = 105
        Me.lab_registro.Text = "."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(9, 439)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Nº de Registros : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(143, 440)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Bultos Ing. : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(274, 441)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Desp. Día : "
        '
        'txt_tot_bultos_ingresado
        '
        Me.txt_tot_bultos_ingresado.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_bultos_ingresado.Location = New System.Drawing.Point(206, 437)
        Me.txt_tot_bultos_ingresado.Name = "txt_tot_bultos_ingresado"
        Me.txt_tot_bultos_ingresado.ReadOnly = True
        Me.txt_tot_bultos_ingresado.Size = New System.Drawing.Size(64, 20)
        Me.txt_tot_bultos_ingresado.TabIndex = 99
        Me.txt_tot_bultos_ingresado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tot_despa_dia
        '
        Me.txt_tot_despa_dia.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_despa_dia.Location = New System.Drawing.Point(338, 437)
        Me.txt_tot_despa_dia.Name = "txt_tot_despa_dia"
        Me.txt_tot_despa_dia.ReadOnly = True
        Me.txt_tot_despa_dia.Size = New System.Drawing.Size(51, 20)
        Me.txt_tot_despa_dia.TabIndex = 96
        Me.txt_tot_despa_dia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tot_desp_anterior
        '
        Me.txt_tot_desp_anterior.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_desp_anterior.Location = New System.Drawing.Point(454, 437)
        Me.txt_tot_desp_anterior.MaxLength = 7
        Me.txt_tot_desp_anterior.Name = "txt_tot_desp_anterior"
        Me.txt_tot_desp_anterior.ReadOnly = True
        Me.txt_tot_desp_anterior.Size = New System.Drawing.Size(51, 20)
        Me.txt_tot_desp_anterior.TabIndex = 98
        Me.txt_tot_desp_anterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(393, 440)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Desp. Ant : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(622, 441)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "%Desp. ant  : "
        '
        'txt_porc_anterior
        '
        Me.txt_porc_anterior.BackColor = System.Drawing.SystemColors.Info
        Me.txt_porc_anterior.Location = New System.Drawing.Point(687, 437)
        Me.txt_porc_anterior.MaxLength = 7
        Me.txt_porc_anterior.Name = "txt_porc_anterior"
        Me.txt_porc_anterior.ReadOnly = True
        Me.txt_porc_anterior.Size = New System.Drawing.Size(39, 20)
        Me.txt_porc_anterior.TabIndex = 97
        Me.txt_porc_anterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(507, 440)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "% Desp. Dia : "
        '
        'txt_porc_dia
        '
        Me.txt_porc_dia.BackColor = System.Drawing.SystemColors.Info
        Me.txt_porc_dia.Location = New System.Drawing.Point(581, 437)
        Me.txt_porc_dia.MaxLength = 7
        Me.txt_porc_dia.Name = "txt_porc_dia"
        Me.txt_porc_dia.ReadOnly = True
        Me.txt_porc_dia.Size = New System.Drawing.Size(39, 20)
        Me.txt_porc_dia.TabIndex = 107
        Me.txt_porc_dia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frm_consulta_ingreso_vs_salida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "frm_consulta_ingreso_vs_salida"
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
        CType(Me.dgv_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_agencia_origen As System.Windows.Forms.ComboBox
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_filtrar As System.Windows.Forms.Button
    Friend WithEvents cmb_ciudad_destino As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_ciudad_origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_agencia_destino As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents lab_registro As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_porc_anterior As System.Windows.Forms.TextBox
    Friend WithEvents txt_tot_bultos_ingresado As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_despa_dia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_desp_anterior As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_porc_dia As System.Windows.Forms.TextBox

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
