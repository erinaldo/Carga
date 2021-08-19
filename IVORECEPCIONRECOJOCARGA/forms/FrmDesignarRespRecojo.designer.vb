<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesignarRespRecojo
    Inherits INTEGRACION.FrmPlantillasolrecojocarga
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
        Me.CmbAgencia = New System.Windows.Forms.ComboBox
        Me.cmbruta = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DTPicker_resumen = New System.Windows.Forms.DateTimePicker
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbrutaresumen = New System.Windows.Forms.ComboBox
        Me.cmbagenciaresumen = New System.Windows.Forms.ComboBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 600)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Panel1Collapsed = True
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 534)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(744, 520)
        '
        'TabMante
        '
        Me.TabMante.Location = New System.Drawing.Point(-2, 3)
        Me.TabMante.Size = New System.Drawing.Size(742, 515)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.DateTimePicker1)
        Me.TabLista.Controls.Add(Me.CheckBox1)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.cmbruta)
        Me.TabLista.Controls.Add(Me.CmbAgencia)
        Me.TabLista.Size = New System.Drawing.Size(734, 486)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LabeloSCAR, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CmbAgencia, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbruta, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DateTimePicker1, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Size = New System.Drawing.Size(734, 486)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.DTPicker_resumen)
        Me.TabPage1.Controls.Add(Me.CheckBox2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cmbrutaresumen)
        Me.TabPage1.Controls.Add(Me.cmbagenciaresumen)
        Me.TabPage1.Size = New System.Drawing.Size(734, 486)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(734, 486)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'CmbAgencia
        '
        Me.CmbAgencia.FormattingEnabled = True
        Me.CmbAgencia.Location = New System.Drawing.Point(298, 24)
        Me.CmbAgencia.Name = "CmbAgencia"
        Me.CmbAgencia.Size = New System.Drawing.Size(127, 21)
        Me.CmbAgencia.TabIndex = 2
        '
        'cmbruta
        '
        Me.cmbruta.FormattingEnabled = True
        Me.cmbruta.Location = New System.Drawing.Point(592, 24)
        Me.cmbruta.Name = "cmbruta"
        Me.cmbruta.Size = New System.Drawing.Size(121, 21)
        Me.cmbruta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(26, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(240, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Agencia :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(548, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Ruta :"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Location = New System.Drawing.Point(441, 28)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Todos"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(75, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePicker1.TabIndex = 9
        '
        'DTPicker_resumen
        '
        Me.DTPicker_resumen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPicker_resumen.Location = New System.Drawing.Point(72, 19)
        Me.DTPicker_resumen.Name = "DTPicker_resumen"
        Me.DTPicker_resumen.Size = New System.Drawing.Size(95, 20)
        Me.DTPicker_resumen.TabIndex = 16
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Location = New System.Drawing.Point(438, 19)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox2.TabIndex = 15
        Me.CheckBox2.Text = "Todos"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(237, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Agencia :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(23, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Fecha :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(545, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Ruta :"
        '
        'cmbrutaresumen
        '
        Me.cmbrutaresumen.FormattingEnabled = True
        Me.cmbrutaresumen.Location = New System.Drawing.Point(587, 15)
        Me.cmbrutaresumen.Name = "cmbrutaresumen"
        Me.cmbrutaresumen.Size = New System.Drawing.Size(132, 21)
        Me.cmbrutaresumen.TabIndex = 11
        '
        'cmbagenciaresumen
        '
        Me.cmbagenciaresumen.FormattingEnabled = True
        Me.cmbagenciaresumen.Location = New System.Drawing.Point(295, 15)
        Me.cmbagenciaresumen.Name = "cmbagenciaresumen"
        Me.cmbagenciaresumen.Size = New System.Drawing.Size(127, 21)
        Me.cmbagenciaresumen.TabIndex = 10
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 60)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(706, 421)
        Me.DataGridView1.TabIndex = 17
        '
        'FrmDesignarRespRecojo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "FrmDesignarRespRecojo"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbruta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DTPicker_resumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbrutaresumen As System.Windows.Forms.ComboBox
    Friend WithEvents cmbagenciaresumen As System.Windows.Forms.ComboBox

End Class
