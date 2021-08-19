<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_reparto_recojo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_reparto_recojo))
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox
        Me.cmbAgencia = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_tipo_consulta = New System.Windows.Forms.ComboBox
        Me.BtnFiltrar = New System.Windows.Forms.Button
        Me.labtipo_reporte = New System.Windows.Forms.Label
        Me.cmbtiporeporte = New System.Windows.Forms.ComboBox
        Me.lab_nro_registro = New System.Windows.Forms.Label
        Me.dgv_datos = New System.Windows.Forms.DataGridView
        Me.txt_costo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_total_peso = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmb_ciudad = New System.Windows.Forms.ComboBox
        Me.chk_cantidad_envio = New System.Windows.Forms.CheckBox
        Me.txtbultos = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_tot_sobres = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
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
        CType(Me.dgv_datos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.dgv_datos)
        Me.Panel.Location = New System.Drawing.Point(2, 120)
        Me.Panel.Size = New System.Drawing.Size(728, 304)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.chk_cantidad_envio)
        Me.TabLista.Controls.Add(Me.txt_tot_sobres)
        Me.TabLista.Controls.Add(Me.Label8)
        Me.TabLista.Controls.Add(Me.txtbultos)
        Me.TabLista.Controls.Add(Me.Label5)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.cmb_ciudad)
        Me.TabLista.Controls.Add(Me.txt_total_peso)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.txt_costo)
        Me.TabLista.Controls.Add(Me.lab_nro_registro)
        Me.TabLista.Controls.Add(Me.labtipo_reporte)
        Me.TabLista.Controls.Add(Me.cmbtiporeporte)
        Me.TabLista.Controls.Add(Me.BtnFiltrar)
        Me.TabLista.Controls.Add(Me.cmb_tipo_consulta)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.Label7)
        Me.TabLista.Controls.Add(Me.Label6)
        Me.TabLista.Controls.Add(Me.cmbUsuarios)
        Me.TabLista.Controls.Add(Me.cmbAgencia)
        Me.TabLista.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.TabLista.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.TabLista.Controls.Add(Me.Label12)
        Me.TabLista.Controls.Add(Me.Label13)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label13, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DTPFECHAINICIOFACTURA, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DTPFECHAFINALFACTURA, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbAgencia, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbUsuarios, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmb_tipo_consulta, 0)
        Me.TabLista.Controls.SetChildIndex(Me.BtnFiltrar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbtiporeporte, 0)
        Me.TabLista.Controls.SetChildIndex(Me.labtipo_reporte, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lab_nro_registro, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_costo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_total_peso, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmb_ciudad, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtbultos, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_sobres, 0)
        Me.TabLista.Controls.SetChildIndex(Me.chk_cantidad_envio, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(559, 12)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 2
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(403, 12)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(493, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(326, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Fecha Inicio :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(17, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "Responsable :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(328, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Agencia :"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(98, 66)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(208, 21)
        Me.cmbUsuarios.TabIndex = 4
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(403, 39)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(240, 21)
        Me.cmbAgencia.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Consulta : "
        '
        'cmb_tipo_consulta
        '
        Me.cmb_tipo_consulta.BackColor = System.Drawing.SystemColors.Info
        Me.cmb_tipo_consulta.Enabled = False
        Me.cmb_tipo_consulta.FormattingEnabled = True
        Me.cmb_tipo_consulta.Location = New System.Drawing.Point(98, 12)
        Me.cmb_tipo_consulta.Name = "cmb_tipo_consulta"
        Me.cmb_tipo_consulta.Size = New System.Drawing.Size(208, 21)
        Me.cmb_tipo_consulta.TabIndex = 0
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.BackColor = System.Drawing.Color.Moccasin
        Me.BtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Maroon
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFiltrar.Location = New System.Drawing.Point(655, 10)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(71, 28)
        Me.BtnFiltrar.TabIndex = 88
        Me.BtnFiltrar.Text = "&Filtrar"
        Me.BtnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnFiltrar.UseVisualStyleBackColor = False
        '
        'labtipo_reporte
        '
        Me.labtipo_reporte.AutoSize = True
        Me.labtipo_reporte.BackColor = System.Drawing.Color.Transparent
        Me.labtipo_reporte.ForeColor = System.Drawing.Color.Maroon
        Me.labtipo_reporte.Location = New System.Drawing.Point(14, 97)
        Me.labtipo_reporte.Name = "labtipo_reporte"
        Me.labtipo_reporte.Size = New System.Drawing.Size(78, 13)
        Me.labtipo_reporte.TabIndex = 90
        Me.labtipo_reporte.Text = "Tipo Reporte : "
        '
        'cmbtiporeporte
        '
        Me.cmbtiporeporte.FormattingEnabled = True
        Me.cmbtiporeporte.Location = New System.Drawing.Point(98, 93)
        Me.cmbtiporeporte.Name = "cmbtiporeporte"
        Me.cmbtiporeporte.Size = New System.Drawing.Size(208, 21)
        Me.cmbtiporeporte.TabIndex = 5
        '
        'lab_nro_registro
        '
        Me.lab_nro_registro.AutoSize = True
        Me.lab_nro_registro.BackColor = System.Drawing.Color.Transparent
        Me.lab_nro_registro.ForeColor = System.Drawing.Color.Maroon
        Me.lab_nro_registro.Location = New System.Drawing.Point(566, 70)
        Me.lab_nro_registro.Name = "lab_nro_registro"
        Me.lab_nro_registro.Size = New System.Drawing.Size(0, 13)
        Me.lab_nro_registro.TabIndex = 91
        Me.lab_nro_registro.Visible = False
        '
        'dgv_datos
        '
        Me.dgv_datos.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_datos.Location = New System.Drawing.Point(0, 0)
        Me.dgv_datos.Name = "dgv_datos"
        Me.dgv_datos.Size = New System.Drawing.Size(728, 303)
        Me.dgv_datos.TabIndex = 0
        '
        'txt_costo
        '
        Me.txt_costo.BackColor = System.Drawing.SystemColors.Info
        Me.txt_costo.Location = New System.Drawing.Point(626, 436)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(100, 20)
        Me.txt_costo.TabIndex = 92
        Me.txt_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(556, 439)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Total Costo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(386, 439)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Total Peso :"
        '
        'txt_total_peso
        '
        Me.txt_total_peso.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total_peso.Location = New System.Drawing.Point(453, 436)
        Me.txt_total_peso.Name = "txt_total_peso"
        Me.txt_total_peso.Size = New System.Drawing.Size(100, 20)
        Me.txt_total_peso.TabIndex = 95
        Me.txt_total_peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(17, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Ciudad :"
        '
        'cmb_ciudad
        '
        Me.cmb_ciudad.FormattingEnabled = True
        Me.cmb_ciudad.Location = New System.Drawing.Point(98, 39)
        Me.cmb_ciudad.Name = "cmb_ciudad"
        Me.cmb_ciudad.Size = New System.Drawing.Size(208, 21)
        Me.cmb_ciudad.TabIndex = 96
        '
        'chk_cantidad_envio
        '
        Me.chk_cantidad_envio.AutoSize = True
        Me.chk_cantidad_envio.BackColor = System.Drawing.Color.Transparent
        Me.chk_cantidad_envio.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chk_cantidad_envio.ForeColor = System.Drawing.Color.Maroon
        Me.chk_cantidad_envio.Location = New System.Drawing.Point(403, 70)
        Me.chk_cantidad_envio.Name = "chk_cantidad_envio"
        Me.chk_cantidad_envio.Size = New System.Drawing.Size(148, 17)
        Me.chk_cantidad_envio.TabIndex = 98
        Me.chk_cantidad_envio.Text = "Reporte en punto entrega"
        Me.chk_cantidad_envio.UseVisualStyleBackColor = False
        '
        'txtbultos
        '
        Me.txtbultos.BackColor = System.Drawing.SystemColors.Info
        Me.txtbultos.Location = New System.Drawing.Point(271, 436)
        Me.txtbultos.Name = "txtbultos"
        Me.txtbultos.Size = New System.Drawing.Size(100, 20)
        Me.txtbultos.TabIndex = 100
        Me.txtbultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(204, 439)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Total Bultos :"
        '
        'txt_tot_sobres
        '
        Me.txt_tot_sobres.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_sobres.Location = New System.Drawing.Point(88, 436)
        Me.txt_tot_sobres.Name = "txt_tot_sobres"
        Me.txt_tot_sobres.Size = New System.Drawing.Size(100, 20)
        Me.txt_tot_sobres.TabIndex = 102
        Me.txt_tot_sobres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(6, 439)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Total Sobres :"
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(626, 104)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(104, 13)
        Me.lblRegistros.TabIndex = 131
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_consulta_reparto_recojo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "frm_consulta_reparto_recojo"
        Me.Text = " Consulta Reparto"
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
        CType(Me.dgv_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_tipo_consulta As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents labtipo_reporte As System.Windows.Forms.Label
    Friend WithEvents cmbtiporeporte As System.Windows.Forms.ComboBox
    Friend WithEvents lab_nro_registro As System.Windows.Forms.Label
    Friend WithEvents dgv_datos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_total_peso As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_ciudad As System.Windows.Forms.ComboBox
    Friend WithEvents chk_cantidad_envio As System.Windows.Forms.CheckBox
    Friend WithEvents txt_tot_sobres As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtbultos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
