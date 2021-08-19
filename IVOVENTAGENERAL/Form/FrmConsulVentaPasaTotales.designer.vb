<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulVentaPasaTotales
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbAgenciaDesti = New System.Windows.Forms.ComboBox()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.rbgene = New System.Windows.Forms.RadioButton()
        Me.rb2 = New System.Windows.Forms.RadioButton()
        Me.RBresuMensuDiaVentas = New System.Windows.Forms.RadioButton()
        Me.RBResuMensuVentasSegunLiqui = New System.Windows.Forms.RadioButton()
        Me.RBResuMensuVentasSegunLiquiMeses = New System.Windows.Forms.RadioButton()
        Me.RBEstaVentaPasa = New System.Windows.Forms.RadioButton()
        Me.RBMoviVentaDesti = New System.Windows.Forms.RadioButton()
        Me.RBControlCorreDocu = New System.Windows.Forms.RadioButton()
        Me.lblRegistros = New System.Windows.Forms.Label()
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
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Controls.Add(Me.DGV3)
        Me.Panel.Location = New System.Drawing.Point(6, 144)
        Me.Panel.Size = New System.Drawing.Size(720, 312)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.RBControlCorreDocu)
        Me.TabLista.Controls.Add(Me.RBMoviVentaDesti)
        Me.TabLista.Controls.Add(Me.RBEstaVentaPasa)
        Me.TabLista.Controls.Add(Me.RBResuMensuVentasSegunLiquiMeses)
        Me.TabLista.Controls.Add(Me.RBResuMensuVentasSegunLiqui)
        Me.TabLista.Controls.Add(Me.RBresuMensuDiaVentas)
        Me.TabLista.Controls.Add(Me.rb2)
        Me.TabLista.Controls.Add(Me.rbgene)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rbgene, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.rb2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBresuMensuDiaVentas, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBResuMensuVentasSegunLiqui, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBResuMensuVentasSegunLiquiMeses, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBEstaVentaPasa, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBMoviVentaDesti, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBControlCorreDocu, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgenciaDesti)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.GroupBox1.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 73)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(312, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Usuario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(9, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Agencia:"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(368, 46)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(238, 21)
        Me.cmbUsuarios.TabIndex = 7
        '
        'cmbAgenciaDesti
        '
        Me.cmbAgenciaDesti.FormattingEnabled = True
        Me.cmbAgenciaDesti.Location = New System.Drawing.Point(399, 14)
        Me.cmbAgenciaDesti.Name = "cmbAgenciaDesti"
        Me.cmbAgenciaDesti.Size = New System.Drawing.Size(238, 21)
        Me.cmbAgenciaDesti.TabIndex = 6
        Me.cmbAgenciaDesti.Visible = False
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(65, 46)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(238, 21)
        Me.cmbAgencia.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(347, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Destino:"
        Me.Label4.Visible = False
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
        Me.Label13.Location = New System.Drawing.Point(5, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Fecha Inicio :"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.BackgroundColor = System.Drawing.Color.White
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV3.Location = New System.Drawing.Point(0, 0)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(720, 312)
        Me.DGV3.TabIndex = 59
        '
        'rbgene
        '
        Me.rbgene.AutoSize = True
        Me.rbgene.BackColor = System.Drawing.Color.Transparent
        Me.rbgene.Checked = True
        Me.rbgene.Location = New System.Drawing.Point(2, 81)
        Me.rbgene.Name = "rbgene"
        Me.rbgene.Size = New System.Drawing.Size(174, 17)
        Me.rbgene.TabIndex = 60
        Me.rbgene.TabStop = True
        Me.rbgene.Text = "Resumen de Ingreso de Ventas"
        Me.rbgene.UseVisualStyleBackColor = False
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.BackColor = System.Drawing.Color.Transparent
        Me.rb2.Location = New System.Drawing.Point(177, 81)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(156, 17)
        Me.rb2.TabIndex = 61
        Me.rb2.Text = "Resumen Ingresos/Egresos"
        Me.rb2.UseVisualStyleBackColor = False
        '
        'RBresuMensuDiaVentas
        '
        Me.RBresuMensuDiaVentas.AutoSize = True
        Me.RBresuMensuDiaVentas.BackColor = System.Drawing.Color.Transparent
        Me.RBresuMensuDiaVentas.Location = New System.Drawing.Point(339, 81)
        Me.RBresuMensuDiaVentas.Name = "RBresuMensuDiaVentas"
        Me.RBresuMensuDiaVentas.Size = New System.Drawing.Size(179, 17)
        Me.RBresuMensuDiaVentas.TabIndex = 61
        Me.RBresuMensuDiaVentas.Text = "Resumen Mensual Diario Ventas"
        Me.RBresuMensuDiaVentas.UseVisualStyleBackColor = False
        '
        'RBResuMensuVentasSegunLiqui
        '
        Me.RBResuMensuVentasSegunLiqui.AutoSize = True
        Me.RBResuMensuVentasSegunLiqui.BackColor = System.Drawing.Color.Transparent
        Me.RBResuMensuVentasSegunLiqui.Location = New System.Drawing.Point(2, 104)
        Me.RBResuMensuVentasSegunLiqui.Name = "RBResuMensuVentasSegunLiqui"
        Me.RBResuMensuVentasSegunLiqui.Size = New System.Drawing.Size(266, 17)
        Me.RBResuMensuVentasSegunLiqui.TabIndex = 61
        Me.RBResuMensuVentasSegunLiqui.Text = "Resumen Mensual de Ventas Segun Liquidaciones"
        Me.RBResuMensuVentasSegunLiqui.UseVisualStyleBackColor = False
        '
        'RBResuMensuVentasSegunLiquiMeses
        '
        Me.RBResuMensuVentasSegunLiquiMeses.AutoSize = True
        Me.RBResuMensuVentasSegunLiquiMeses.BackColor = System.Drawing.Color.Transparent
        Me.RBResuMensuVentasSegunLiquiMeses.Location = New System.Drawing.Point(274, 104)
        Me.RBResuMensuVentasSegunLiquiMeses.Name = "RBResuMensuVentasSegunLiquiMeses"
        Me.RBResuMensuVentasSegunLiquiMeses.Size = New System.Drawing.Size(318, 17)
        Me.RBResuMensuVentasSegunLiquiMeses.TabIndex = 61
        Me.RBResuMensuVentasSegunLiquiMeses.Text = "Resumen Mensual de Ventas Según Liquidaciones por Meses"
        Me.RBResuMensuVentasSegunLiquiMeses.UseVisualStyleBackColor = False
        '
        'RBEstaVentaPasa
        '
        Me.RBEstaVentaPasa.AutoSize = True
        Me.RBEstaVentaPasa.BackColor = System.Drawing.Color.Transparent
        Me.RBEstaVentaPasa.Location = New System.Drawing.Point(2, 127)
        Me.RBEstaVentaPasa.Name = "RBEstaVentaPasa"
        Me.RBEstaVentaPasa.Size = New System.Drawing.Size(179, 17)
        Me.RBEstaVentaPasa.TabIndex = 61
        Me.RBEstaVentaPasa.Text = "Estadística de Venta de Pasajes"
        Me.RBEstaVentaPasa.UseVisualStyleBackColor = False
        '
        'RBMoviVentaDesti
        '
        Me.RBMoviVentaDesti.AutoSize = True
        Me.RBMoviVentaDesti.BackColor = System.Drawing.Color.Transparent
        Me.RBMoviVentaDesti.Location = New System.Drawing.Point(187, 127)
        Me.RBMoviVentaDesti.Name = "RBMoviVentaDesti"
        Me.RBMoviVentaDesti.Size = New System.Drawing.Size(192, 17)
        Me.RBMoviVentaDesti.TabIndex = 61
        Me.RBMoviVentaDesti.Text = "Movimientos de Ventas por Destino"
        Me.RBMoviVentaDesti.UseVisualStyleBackColor = False
        '
        'RBControlCorreDocu
        '
        Me.RBControlCorreDocu.AutoSize = True
        Me.RBControlCorreDocu.BackColor = System.Drawing.Color.Transparent
        Me.RBControlCorreDocu.Location = New System.Drawing.Point(524, 81)
        Me.RBControlCorreDocu.Name = "RBControlCorreDocu"
        Me.RBControlCorreDocu.Size = New System.Drawing.Size(195, 17)
        Me.RBControlCorreDocu.TabIndex = 61
        Me.RBControlCorreDocu.Text = "Control de Correlativo Documentario"
        Me.RBControlCorreDocu.UseVisualStyleBackColor = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(633, 127)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 89
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmConsulVentaPasaTotales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulVentaPasaTotales"
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents rbgene As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents RBresuMensuDiaVentas As System.Windows.Forms.RadioButton
    Friend WithEvents RBResuMensuVentasSegunLiqui As System.Windows.Forms.RadioButton
    Friend WithEvents RBResuMensuVentasSegunLiquiMeses As System.Windows.Forms.RadioButton
    Friend WithEvents RBEstaVentaPasa As System.Windows.Forms.RadioButton
    Friend WithEvents cmbAgenciaDesti As System.Windows.Forms.ComboBox
    Friend WithEvents RBMoviVentaDesti As System.Windows.Forms.RadioButton
    Friend WithEvents RBControlCorreDocu As System.Windows.Forms.RadioButton

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
