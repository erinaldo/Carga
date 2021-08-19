<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaEntrega
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboOficina = New System.Windows.Forms.ComboBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboProblema = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.rbtResumen = New System.Windows.Forms.RadioButton()
        Me.rbtDetalle = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl5 = New System.Windows.Forms.Label()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.lbl4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboHuella = New System.Windows.Forms.ComboBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Oficina"
        '
        'cboOficina
        '
        Me.cboOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOficina.FormattingEnabled = True
        Me.cboOficina.Location = New System.Drawing.Point(79, 16)
        Me.cboOficina.Name = "cboOficina"
        Me.cboOficina.Size = New System.Drawing.Size(165, 21)
        Me.cboOficina.TabIndex = 1
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 101)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1043, 455)
        Me.dgv.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(304, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Problema"
        '
        'cboProblema
        '
        Me.cboProblema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProblema.FormattingEnabled = True
        Me.cboProblema.Items.AddRange(New Object() {"(TODO)", "CON PROBLEMA", "SIN PROBLEMA"})
        Me.cboProblema.Location = New System.Drawing.Point(371, 61)
        Me.cboProblema.Name = "cboProblema"
        Me.cboProblema.Size = New System.Drawing.Size(165, 21)
        Me.cboProblema.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha Inicio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha Fin"
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(78, 18)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(84, 20)
        Me.dtpInicio.TabIndex = 12
        '
        'dtpFin
        '
        Me.dtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFin.CustomFormat = ""
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(240, 18)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(84, 20)
        Me.dtpFin.TabIndex = 12
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(685, 14)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 32)
        Me.btnFiltrar.TabIndex = 13
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'rbtResumen
        '
        Me.rbtResumen.AutoSize = True
        Me.rbtResumen.Checked = True
        Me.rbtResumen.Location = New System.Drawing.Point(600, 65)
        Me.rbtResumen.Name = "rbtResumen"
        Me.rbtResumen.Size = New System.Drawing.Size(70, 17)
        Me.rbtResumen.TabIndex = 14
        Me.rbtResumen.TabStop = True
        Me.rbtResumen.Text = "Resumen"
        Me.rbtResumen.UseVisualStyleBackColor = True
        '
        'rbtDetalle
        '
        Me.rbtDetalle.AutoSize = True
        Me.rbtDetalle.Location = New System.Drawing.Point(702, 65)
        Me.rbtDetalle.Name = "rbtDetalle"
        Me.rbtDetalle.Size = New System.Drawing.Size(58, 17)
        Me.rbtDetalle.TabIndex = 14
        Me.rbtDetalle.Text = "Detalle"
        Me.rbtDetalle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpInicio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpFin)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(306, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 47)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha Entrega"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lbl5)
        Me.GroupBox2.Controls.Add(Me.lbl3)
        Me.GroupBox2.Controls.Add(Me.lbl2)
        Me.GroupBox2.Controls.Add(Me.lbl4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lbl1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 552)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1043, 34)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(392, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "% Entregas sin Huella"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(824, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "% Entregas con Problema"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(607, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Entregas con Problema"
        '
        'lbl5
        '
        Me.lbl5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5.Location = New System.Drawing.Point(499, 13)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(76, 13)
        Me.lbl5.TabIndex = 1
        Me.lbl5.Text = "0.00"
        Me.lbl5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl3
        '
        Me.lbl3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3.Location = New System.Drawing.Point(955, 13)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(76, 13)
        Me.lbl3.TabIndex = 1
        Me.lbl3.Text = "0.00"
        Me.lbl3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl2
        '
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.Location = New System.Drawing.Point(720, 13)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(76, 13)
        Me.lbl2.TabIndex = 1
        Me.lbl2.Text = "0"
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl4
        '
        Me.lbl4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4.Location = New System.Drawing.Point(297, 13)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(76, 13)
        Me.lbl4.TabIndex = 1
        Me.lbl4.Text = "0"
        Me.lbl4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(196, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Entregas sin Huella"
        '
        'lbl1
        '
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(86, 13)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(76, 13)
        Me.lbl1.TabIndex = 1
        Me.lbl1.Text = "0"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total Entregas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Huella"
        '
        'cboHuella
        '
        Me.cboHuella.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHuella.FormattingEnabled = True
        Me.cboHuella.Items.AddRange(New Object() {"(TODO)", "SI", "NO"})
        Me.cboHuella.Location = New System.Drawing.Point(79, 61)
        Me.cboHuella.Name = "cboHuella"
        Me.cboHuella.Size = New System.Drawing.Size(165, 21)
        Me.cboHuella.TabIndex = 1
        '
        'frmConsultaEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 591)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rbtDetalle)
        Me.Controls.Add(Me.rbtResumen)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.cboHuella)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboProblema)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboOficina)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmConsultaEntrega"
        Me.Text = "Entrega de Carga en Agencia"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboOficina As System.Windows.Forms.ComboBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboProblema As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents rbtResumen As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboHuella As System.Windows.Forms.ComboBox
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
End Class
