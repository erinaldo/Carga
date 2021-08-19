<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulTariClien
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
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBIDUSUARIO_PERSONAL = New System.Windows.Forms.ComboBox()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA_DESTINO = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBIDUNIDAD_AGENCIA = New System.Windows.Forms.ComboBox()
        Me.RBPUBLI = New System.Windows.Forms.RadioButton()
        Me.RBCLIEN = New System.Windows.Forms.RadioButton()
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
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel.Controls.Add(Me.DGV3)
        Me.Panel.Controls.Add(Me.GroupBox2)
        Me.Panel.Location = New System.Drawing.Point(6, 80)
        Me.Panel.Size = New System.Drawing.Size(720, 380)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.RBCLIEN)
        Me.TabLista.Controls.Add(Me.RBPUBLI)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBPUBLI, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBCLIEN, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRegistros)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBIDUSUARIO_PERSONAL)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 68)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(626, 42)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 87
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(664, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 86
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Funcionario:"
        Me.Label1.Visible = False
        '
        'CBIDUSUARIO_PERSONAL
        '
        Me.CBIDUSUARIO_PERSONAL.FormattingEnabled = True
        Me.CBIDUSUARIO_PERSONAL.Location = New System.Drawing.Point(92, 39)
        Me.CBIDUSUARIO_PERSONAL.Name = "CBIDUSUARIO_PERSONAL"
        Me.CBIDUSUARIO_PERSONAL.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUSUARIO_PERSONAL.TabIndex = 84
        Me.CBIDUSUARIO_PERSONAL.Visible = False
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.Location = New System.Drawing.Point(271, 13)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(317, 20)
        Me.txtidpersona.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(92, 13)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Codigo Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(220, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cliente :"
        '
        'DGV3
        '
        Me.DGV3.BackgroundColor = System.Drawing.Color.White
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(0, 0)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(720, 380)
        Me.DGV3.TabIndex = 59
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.CBIDUNIDAD_AGENCIA_DESTINO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.CBIDUNIDAD_AGENCIA)
        Me.GroupBox2.Location = New System.Drawing.Point(660, 177)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(725, 39)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(407, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Destino:"
        '
        'CBIDUNIDAD_AGENCIA_DESTINO
        '
        Me.CBIDUNIDAD_AGENCIA_DESTINO.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Location = New System.Drawing.Point(481, 436)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Name = "CBIDUNIDAD_AGENCIA_DESTINO"
        Me.CBIDUNIDAD_AGENCIA_DESTINO.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUNIDAD_AGENCIA_DESTINO.TabIndex = 82
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Origen:"
        '
        'CBIDUNIDAD_AGENCIA
        '
        Me.CBIDUNIDAD_AGENCIA.FormattingEnabled = True
        Me.CBIDUNIDAD_AGENCIA.Location = New System.Drawing.Point(92, 12)
        Me.CBIDUNIDAD_AGENCIA.Name = "CBIDUNIDAD_AGENCIA"
        Me.CBIDUNIDAD_AGENCIA.Size = New System.Drawing.Size(238, 21)
        Me.CBIDUNIDAD_AGENCIA.TabIndex = 80
        '
        'RBPUBLI
        '
        Me.RBPUBLI.AutoSize = True
        Me.RBPUBLI.BackColor = System.Drawing.Color.Transparent
        Me.RBPUBLI.Location = New System.Drawing.Point(225, 468)
        Me.RBPUBLI.Name = "RBPUBLI"
        Me.RBPUBLI.Size = New System.Drawing.Size(60, 17)
        Me.RBPUBLI.TabIndex = 60
        Me.RBPUBLI.Text = "Público"
        Me.RBPUBLI.UseVisualStyleBackColor = False
        Me.RBPUBLI.Visible = False
        '
        'RBCLIEN
        '
        Me.RBCLIEN.AutoSize = True
        Me.RBCLIEN.BackColor = System.Drawing.Color.Transparent
        Me.RBCLIEN.Checked = True
        Me.RBCLIEN.Location = New System.Drawing.Point(11, 468)
        Me.RBCLIEN.Name = "RBCLIEN"
        Me.RBCLIEN.Size = New System.Drawing.Size(57, 17)
        Me.RBCLIEN.TabIndex = 60
        Me.RBCLIEN.TabStop = True
        Me.RBCLIEN.Text = "Cliente"
        Me.RBCLIEN.UseVisualStyleBackColor = False
        Me.RBCLIEN.Visible = False
        '
        'FrmConsulTariClien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulTariClien"
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBIDUSUARIO_PERSONAL As System.Windows.Forms.ComboBox
    Friend WithEvents RBCLIEN As System.Windows.Forms.RadioButton
    Friend WithEvents RBPUBLI As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA_DESTINO As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBIDUNIDAD_AGENCIA As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
