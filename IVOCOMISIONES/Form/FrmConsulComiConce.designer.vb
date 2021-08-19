<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulComiConce
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsulComiConce))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgv2 = New System.Windows.Forms.DataGridView
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.CBIDAGENCIAS = New System.Windows.Forms.ComboBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.DTPFECHA_FINAL = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHA_INI = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.BtnListarComisiones = New System.Windows.Forms.Button
        Me.TxtCargoConsulConce = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtTotalConsulConce = New System.Windows.Forms.TextBox
        Me.TxtSubTotalConsulConce = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblRegistros = New System.Windows.Forms.Label
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
        Me.Panel2.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
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
        Me.Panel.BackColor = System.Drawing.Color.Transparent
        Me.Panel.Controls.Add(Me.dgv1)
        Me.Panel.Location = New System.Drawing.Point(15, 58)
        Me.Panel.Size = New System.Drawing.Size(705, 160)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.LblRegistros2)
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.TxtCargoConsulConce)
        Me.TabLista.Controls.Add(Me.Label16)
        Me.TabLista.Controls.Add(Me.TxtTotalConsulConce)
        Me.TabLista.Controls.Add(Me.TxtSubTotalConsulConce)
        Me.TabLista.Controls.Add(Me.Label18)
        Me.TabLista.Controls.Add(Me.Label17)
        Me.TabLista.Controls.Add(Me.BtnListarComisiones)
        Me.TabLista.Controls.Add(Me.GroupBox8)
        Me.TabLista.Controls.Add(Me.Label7)
        Me.TabLista.Controls.Add(Me.CBIDAGENCIAS)
        Me.TabLista.Controls.Add(Me.Panel2)
        Me.TabLista.Controls.SetChildIndex(Me.Panel2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CBIDAGENCIAS, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.BtnListarComisiones, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label17, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label18, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtSubTotalConsulConce, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtTotalConsulConce, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label16, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtCargoConsulConce, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LblRegistros2, 0)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.dgv2)
        Me.Panel2.Location = New System.Drawing.Point(15, 235)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(705, 186)
        Me.Panel2.TabIndex = 1
        '
        'dgv2
        '
        Me.dgv2.BackgroundColor = System.Drawing.Color.White
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv2.Location = New System.Drawing.Point(0, 0)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.Size = New System.Drawing.Size(705, 186)
        Me.dgv2.TabIndex = 0
        '
        'dgv1
        '
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv1.Location = New System.Drawing.Point(0, 0)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(705, 160)
        Me.dgv1.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(2, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Funcionario:"
        '
        'CBIDAGENCIAS
        '
        Me.CBIDAGENCIAS.FormattingEnabled = True
        Me.CBIDAGENCIAS.Location = New System.Drawing.Point(74, 13)
        Me.CBIDAGENCIAS.Name = "CBIDAGENCIAS"
        Me.CBIDAGENCIAS.Size = New System.Drawing.Size(222, 21)
        Me.CBIDAGENCIAS.TabIndex = 10
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.DTPFECHA_FINAL)
        Me.GroupBox8.Controls.Add(Me.DTPFECHA_INI)
        Me.GroupBox8.Controls.Add(Me.Label25)
        Me.GroupBox8.Controls.Add(Me.Label26)
        Me.GroupBox8.Location = New System.Drawing.Point(302, 2)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(329, 36)
        Me.GroupBox8.TabIndex = 11
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Rago de Fechas..."
        '
        'DTPFECHA_FINAL
        '
        Me.DTPFECHA_FINAL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHA_FINAL.Location = New System.Drawing.Point(238, 11)
        Me.DTPFECHA_FINAL.Name = "DTPFECHA_FINAL"
        Me.DTPFECHA_FINAL.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHA_FINAL.TabIndex = 65
        '
        'DTPFECHA_INI
        '
        Me.DTPFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHA_INI.Location = New System.Drawing.Point(82, 11)
        Me.DTPFECHA_INI.Name = "DTPFECHA_INI"
        Me.DTPFECHA_INI.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHA_INI.TabIndex = 64
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(172, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 13)
        Me.Label25.TabIndex = 67
        Me.Label25.Text = "Fecha Fin :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(5, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(71, 13)
        Me.Label26.TabIndex = 66
        Me.Label26.Text = "Fecha Inicio :"
        '
        'BtnListarComisiones
        '
        Me.BtnListarComisiones.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtnListarComisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnListarComisiones.Image = CType(resources.GetObject("BtnListarComisiones.Image"), System.Drawing.Image)
        Me.BtnListarComisiones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnListarComisiones.Location = New System.Drawing.Point(640, 10)
        Me.BtnListarComisiones.Name = "BtnListarComisiones"
        Me.BtnListarComisiones.Size = New System.Drawing.Size(80, 28)
        Me.BtnListarComisiones.TabIndex = 29
        Me.BtnListarComisiones.Text = "&Filtrar"
        Me.BtnListarComisiones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnListarComisiones.UseVisualStyleBackColor = False
        '
        'TxtCargoConsulConce
        '
        Me.TxtCargoConsulConce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCargoConsulConce.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCargoConsulConce.Location = New System.Drawing.Point(386, 427)
        Me.TxtCargoConsulConce.Name = "TxtCargoConsulConce"
        Me.TxtCargoConsulConce.ReadOnly = True
        Me.TxtCargoConsulConce.Size = New System.Drawing.Size(104, 26)
        Me.TxtCargoConsulConce.TabIndex = 85
        Me.TxtCargoConsulConce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(496, 427)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 24)
        Me.Label16.TabIndex = 88
        Me.Label16.Text = "Total a Pagar:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtTotalConsulConce
        '
        Me.TxtTotalConsulConce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalConsulConce.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalConsulConce.Location = New System.Drawing.Point(616, 427)
        Me.TxtTotalConsulConce.Name = "TxtTotalConsulConce"
        Me.TxtTotalConsulConce.ReadOnly = True
        Me.TxtTotalConsulConce.Size = New System.Drawing.Size(104, 26)
        Me.TxtTotalConsulConce.TabIndex = 83
        Me.TxtTotalConsulConce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubTotalConsulConce
        '
        Me.TxtSubTotalConsulConce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubTotalConsulConce.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotalConsulConce.Location = New System.Drawing.Point(154, 427)
        Me.TxtSubTotalConsulConce.Name = "TxtSubTotalConsulConce"
        Me.TxtSubTotalConsulConce.ReadOnly = True
        Me.TxtSubTotalConsulConce.Size = New System.Drawing.Size(104, 26)
        Me.TxtSubTotalConsulConce.TabIndex = 84
        Me.TxtSubTotalConsulConce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 429)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(145, 24)
        Me.Label18.TabIndex = 87
        Me.Label18.Text = "Comisión :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(264, 427)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(116, 24)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Igv Comisión:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(629, 41)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(91, 13)
        Me.lblRegistros.TabIndex = 131
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblRegistros2
        '
        Me.LblRegistros2.BackColor = System.Drawing.Color.Transparent
        Me.LblRegistros2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros2.ForeColor = System.Drawing.Color.Black
        Me.LblRegistros2.Location = New System.Drawing.Point(629, 219)
        Me.LblRegistros2.Name = "LblRegistros2"
        Me.LblRegistros2.Size = New System.Drawing.Size(91, 13)
        Me.LblRegistros2.TabIndex = 132
        Me.LblRegistros2.Text = "0"
        Me.LblRegistros2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmConsulComiConce
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmConsulComiConce"
        Me.Text = ""
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
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CBIDAGENCIAS As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFECHA_FINAL As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHA_INI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents BtnListarComisiones As System.Windows.Forms.Button
    Friend WithEvents TxtCargoConsulConce As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalConsulConce As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubTotalConsulConce As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents LblRegistros2 As System.Windows.Forms.Label

End Class
