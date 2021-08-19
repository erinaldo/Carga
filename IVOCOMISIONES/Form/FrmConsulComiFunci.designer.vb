<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulComiFunci
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsulComiFunci))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.DTPFECHA_FINAL = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHA_INI = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.BtnListarComisiones = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtSubTotalConsulFunci = New System.Windows.Forms.TextBox()
        Me.TxtTotalConsulFunci = New System.Windows.Forms.TextBox()
        Me.TxtCargoConsulFunci = New System.Windows.Forms.TextBox()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.LblRegistros2 = New System.Windows.Forms.Label()
        Me.CBIDFUNCIONARIO = New System.Windows.Forms.ComboBox()
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
        Me.Panel.Controls.Add(Me.dgv1)
        Me.Panel.Location = New System.Drawing.Point(15, 58)
        Me.Panel.Size = New System.Drawing.Size(705, 160)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.CBIDFUNCIONARIO)
        Me.TabLista.Controls.Add(Me.LblRegistros2)
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.Label22)
        Me.TabLista.Controls.Add(Me.Label23)
        Me.TabLista.Controls.Add(Me.Label24)
        Me.TabLista.Controls.Add(Me.TxtSubTotalConsulFunci)
        Me.TabLista.Controls.Add(Me.TxtTotalConsulFunci)
        Me.TabLista.Controls.Add(Me.TxtCargoConsulFunci)
        Me.TabLista.Controls.Add(Me.BtnListarComisiones)
        Me.TabLista.Controls.Add(Me.GroupBox8)
        Me.TabLista.Controls.Add(Me.Label7)
        Me.TabLista.Controls.Add(Me.Panel2)
        Me.TabLista.Controls.SetChildIndex(Me.Panel2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox8, 0)
        Me.TabLista.Controls.SetChildIndex(Me.BtnListarComisiones, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtCargoConsulFunci, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtTotalConsulFunci, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtSubTotalConsulFunci, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label24, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label23, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label22, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LblRegistros2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CBIDFUNCIONARIO, 0)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.dgv2)
        Me.Panel2.Location = New System.Drawing.Point(15, 234)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(705, 190)
        Me.Panel2.TabIndex = 1
        '
        'dgv2
        '
        Me.dgv2.BackgroundColor = System.Drawing.Color.White
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv2.Location = New System.Drawing.Point(0, 0)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.Size = New System.Drawing.Size(705, 190)
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
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(500, 430)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 24)
        Me.Label22.TabIndex = 86
        Me.Label22.Text = "Total a Pagar:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(277, 430)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 24)
        Me.Label23.TabIndex = 87
        Me.Label23.Text = "Igv Comisión:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(77, 432)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 24)
        Me.Label24.TabIndex = 88
        Me.Label24.Text = "Comisión :"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtSubTotalConsulFunci
        '
        Me.TxtSubTotalConsulFunci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubTotalConsulFunci.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotalConsulFunci.Location = New System.Drawing.Point(167, 430)
        Me.TxtSubTotalConsulFunci.Name = "TxtSubTotalConsulFunci"
        Me.TxtSubTotalConsulFunci.ReadOnly = True
        Me.TxtSubTotalConsulFunci.Size = New System.Drawing.Size(104, 26)
        Me.TxtSubTotalConsulFunci.TabIndex = 83
        Me.TxtSubTotalConsulFunci.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalConsulFunci
        '
        Me.TxtTotalConsulFunci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalConsulFunci.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalConsulFunci.Location = New System.Drawing.Point(616, 430)
        Me.TxtTotalConsulFunci.Name = "TxtTotalConsulFunci"
        Me.TxtTotalConsulFunci.ReadOnly = True
        Me.TxtTotalConsulFunci.Size = New System.Drawing.Size(104, 26)
        Me.TxtTotalConsulFunci.TabIndex = 84
        Me.TxtTotalConsulFunci.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCargoConsulFunci
        '
        Me.TxtCargoConsulFunci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCargoConsulFunci.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCargoConsulFunci.Location = New System.Drawing.Point(390, 430)
        Me.TxtCargoConsulFunci.Name = "TxtCargoConsulFunci"
        Me.TxtCargoConsulFunci.ReadOnly = True
        Me.TxtCargoConsulFunci.Size = New System.Drawing.Size(104, 26)
        Me.TxtCargoConsulFunci.TabIndex = 85
        Me.TxtCargoConsulFunci.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(640, 221)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(80, 13)
        Me.lblRegistros.TabIndex = 131
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblRegistros2
        '
        Me.LblRegistros2.BackColor = System.Drawing.Color.Transparent
        Me.LblRegistros2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros2.ForeColor = System.Drawing.Color.Black
        Me.LblRegistros2.Location = New System.Drawing.Point(640, 42)
        Me.LblRegistros2.Name = "LblRegistros2"
        Me.LblRegistros2.Size = New System.Drawing.Size(80, 13)
        Me.LblRegistros2.TabIndex = 132
        Me.LblRegistros2.Text = "0"
        Me.LblRegistros2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBIDFUNCIONARIO
        '
        Me.CBIDFUNCIONARIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIDFUNCIONARIO.FormattingEnabled = True
        Me.CBIDFUNCIONARIO.Location = New System.Drawing.Point(73, 12)
        Me.CBIDFUNCIONARIO.Name = "CBIDFUNCIONARIO"
        Me.CBIDFUNCIONARIO.Size = New System.Drawing.Size(223, 21)
        Me.CBIDFUNCIONARIO.TabIndex = 133
        '
        'FrmConsulComiFunci
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmConsulComiFunci"
        Me.Text = ""
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
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFECHA_FINAL As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHA_INI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents BtnListarComisiones As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotalConsulFunci As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalConsulFunci As System.Windows.Forms.TextBox
    Friend WithEvents TxtCargoConsulFunci As System.Windows.Forms.TextBox
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents LblRegistros2 As System.Windows.Forms.Label
    Friend WithEvents CBIDFUNCIONARIO As System.Windows.Forms.ComboBox


End Class
