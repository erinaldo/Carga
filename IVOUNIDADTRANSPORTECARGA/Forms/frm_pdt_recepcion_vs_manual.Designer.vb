<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pdt_recepcion_vs_manual
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
        Me.lblRegistros = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbm_agencias = New System.Windows.Forms.ComboBox
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btn_filtrar = New System.Windows.Forms.Button
        Me.lab_registro = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_tot_manual = New System.Windows.Forms.TextBox
        Me.txt_porc_manual = New System.Windows.Forms.TextBox
        Me.txt_porc_pda = New System.Windows.Forms.TextBox
        Me.txt_tot_pda = New System.Windows.Forms.TextBox
        Me.dgv_pdt_vs_manual = New System.Windows.Forms.DataGridView
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
        CType(Me.dgv_pdt_vs_manual, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.dgv_pdt_vs_manual)
        Me.Panel.Location = New System.Drawing.Point(2, 51)
        Me.Panel.Size = New System.Drawing.Size(725, 381)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lab_registro)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.txt_tot_pda)
        Me.TabLista.Controls.Add(Me.Label6)
        Me.TabLista.Controls.Add(Me.txt_porc_pda)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.txt_porc_manual)
        Me.TabLista.Controls.Add(Me.txt_tot_manual)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_manual, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_porc_manual, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_porc_pda, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_tot_pda, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lab_registro, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbm_agencias)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btn_filtrar)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 43)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(581, 20)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(77, 13)
        Me.lblRegistros.TabIndex = 96
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(328, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Agencia :"
        '
        'cbm_agencias
        '
        Me.cbm_agencias.FormattingEnabled = True
        Me.cbm_agencias.Location = New System.Drawing.Point(385, 13)
        Me.cbm_agencias.Name = "cbm_agencias"
        Me.cbm_agencias.Size = New System.Drawing.Size(193, 21)
        Me.cbm_agencias.TabIndex = 94
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
        'lab_registro
        '
        Me.lab_registro.AutoSize = True
        Me.lab_registro.BackColor = System.Drawing.Color.Transparent
        Me.lab_registro.ForeColor = System.Drawing.Color.Maroon
        Me.lab_registro.Location = New System.Drawing.Point(108, 441)
        Me.lab_registro.Name = "lab_registro"
        Me.lab_registro.Size = New System.Drawing.Size(10, 13)
        Me.lab_registro.TabIndex = 85
        Me.lab_registro.Text = "."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(7, 440)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Nº de Registros : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(233, 441)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Total Manual : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(384, 441)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Total Pda : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(518, 441)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "% Manual : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(631, 441)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "% Pda : "
        '
        'txt_tot_manual
        '
        Me.txt_tot_manual.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_manual.Location = New System.Drawing.Point(312, 438)
        Me.txt_tot_manual.Name = "txt_tot_manual"
        Me.txt_tot_manual.ReadOnly = True
        Me.txt_tot_manual.Size = New System.Drawing.Size(64, 20)
        Me.txt_tot_manual.TabIndex = 79
        Me.txt_tot_manual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_porc_manual
        '
        Me.txt_porc_manual.BackColor = System.Drawing.SystemColors.Info
        Me.txt_porc_manual.Location = New System.Drawing.Point(583, 438)
        Me.txt_porc_manual.MaxLength = 7
        Me.txt_porc_manual.Name = "txt_porc_manual"
        Me.txt_porc_manual.ReadOnly = True
        Me.txt_porc_manual.Size = New System.Drawing.Size(45, 20)
        Me.txt_porc_manual.TabIndex = 78
        Me.txt_porc_manual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_porc_pda
        '
        Me.txt_porc_pda.BackColor = System.Drawing.SystemColors.Info
        Me.txt_porc_pda.Location = New System.Drawing.Point(681, 438)
        Me.txt_porc_pda.MaxLength = 7
        Me.txt_porc_pda.Name = "txt_porc_pda"
        Me.txt_porc_pda.ReadOnly = True
        Me.txt_porc_pda.Size = New System.Drawing.Size(45, 20)
        Me.txt_porc_pda.TabIndex = 77
        Me.txt_porc_pda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tot_pda
        '
        Me.txt_tot_pda.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_pda.Location = New System.Drawing.Point(452, 438)
        Me.txt_tot_pda.Name = "txt_tot_pda"
        Me.txt_tot_pda.ReadOnly = True
        Me.txt_tot_pda.Size = New System.Drawing.Size(64, 20)
        Me.txt_tot_pda.TabIndex = 76
        Me.txt_tot_pda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_pdt_vs_manual
        '
        Me.dgv_pdt_vs_manual.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgv_pdt_vs_manual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pdt_vs_manual.Location = New System.Drawing.Point(2, 0)
        Me.dgv_pdt_vs_manual.Name = "dgv_pdt_vs_manual"
        Me.dgv_pdt_vs_manual.Size = New System.Drawing.Size(726, 381)
        Me.dgv_pdt_vs_manual.TabIndex = 3
        '
        'frm_pdt_recepcion_vs_manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "frm_pdt_recepcion_vs_manual"
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
        CType(Me.dgv_pdt_vs_manual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbm_agencias As System.Windows.Forms.ComboBox
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_filtrar As System.Windows.Forms.Button
    Friend WithEvents lab_registro As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_pda As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_porc_pda As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_porc_manual As System.Windows.Forms.TextBox
    Friend WithEvents txt_tot_manual As System.Windows.Forms.TextBox
    Friend WithEvents dgv_pdt_vs_manual As System.Windows.Forms.DataGridView

    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
