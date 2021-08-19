<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulClienFunci
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsulClienFunci))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbtipopersona = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCargarClientes = New System.Windows.Forms.Button()
        Me.DGVFuncionario_x_clte = New System.Windows.Forms.DataGridView()
        Me.Labnroregistro = New System.Windows.Forms.Label()
        Me.Cmbestado = New System.Windows.Forms.ComboBox()
        Me.Labestado = New System.Windows.Forms.Label()
        Me.cmbcorporativo = New System.Windows.Forms.ComboBox()
        Me.labcorporativo = New System.Windows.Forms.Label()
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
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        CType(Me.DGVFuncionario_x_clte, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Size = New System.Drawing.Size(705, 361)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.lblRegistros)
        Me.TabLista.Controls.Add(Me.DGVFuncionario_x_clte)
        Me.TabLista.Controls.Add(Me.labcorporativo)
        Me.TabLista.Controls.Add(Me.cmbcorporativo)
        Me.TabLista.Controls.Add(Me.Labestado)
        Me.TabLista.Controls.Add(Me.Cmbestado)
        Me.TabLista.Controls.Add(Me.Labnroregistro)
        Me.TabLista.Controls.Add(Me.btnCargarClientes)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.cmbtipopersona)
        Me.TabLista.Controls.Add(Me.Label7)
        Me.TabLista.Controls.Add(Me.cmbUsuarios)
        Me.TabLista.Controls.SetChildIndex(Me.cmbUsuarios, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbtipopersona, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnCargarClientes, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Labnroregistro, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Cmbestado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Labestado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbcorporativo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.labcorporativo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGVFuncionario_x_clte, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblRegistros, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(12, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Funcionario :"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(15, 17)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(238, 21)
        Me.cmbUsuarios.TabIndex = 39
        '
        'cmbtipopersona
        '
        Me.cmbtipopersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtipopersona.Enabled = False
        Me.cmbtipopersona.FormattingEnabled = True
        Me.cmbtipopersona.Location = New System.Drawing.Point(410, 62)
        Me.cmbtipopersona.Name = "cmbtipopersona"
        Me.cmbtipopersona.Size = New System.Drawing.Size(238, 21)
        Me.cmbtipopersona.TabIndex = 41
        Me.cmbtipopersona.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(407, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Tipo Persona:"
        Me.Label1.Visible = False
        '
        'btnCargarClientes
        '
        Me.btnCargarClientes.BackColor = System.Drawing.Color.Transparent
        Me.btnCargarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargarClientes.Image = CType(resources.GetObject("btnCargarClientes.Image"), System.Drawing.Image)
        Me.btnCargarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargarClientes.Location = New System.Drawing.Point(640, 13)
        Me.btnCargarClientes.Name = "btnCargarClientes"
        Me.btnCargarClientes.Size = New System.Drawing.Size(80, 28)
        Me.btnCargarClientes.TabIndex = 43
        Me.btnCargarClientes.Text = "&Cargar"
        Me.btnCargarClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargarClientes.UseVisualStyleBackColor = False
        '
        'DGVFuncionario_x_clte
        '
        Me.DGVFuncionario_x_clte.BackgroundColor = System.Drawing.Color.White
        Me.DGVFuncionario_x_clte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVFuncionario_x_clte.Location = New System.Drawing.Point(15, 44)
        Me.DGVFuncionario_x_clte.Name = "DGVFuncionario_x_clte"
        Me.DGVFuncionario_x_clte.Size = New System.Drawing.Size(705, 412)
        Me.DGVFuncionario_x_clte.TabIndex = 60
        '
        'Labnroregistro
        '
        Me.Labnroregistro.AutoSize = True
        Me.Labnroregistro.BackColor = System.Drawing.Color.Transparent
        Me.Labnroregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labnroregistro.Location = New System.Drawing.Point(520, 442)
        Me.Labnroregistro.MinimumSize = New System.Drawing.Size(200, 0)
        Me.Labnroregistro.Name = "Labnroregistro"
        Me.Labnroregistro.Size = New System.Drawing.Size(200, 13)
        Me.Labnroregistro.TabIndex = 83
        Me.Labnroregistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmbestado
        '
        Me.Cmbestado.Enabled = False
        Me.Cmbestado.FormattingEnabled = True
        Me.Cmbestado.Location = New System.Drawing.Point(152, 62)
        Me.Cmbestado.Name = "Cmbestado"
        Me.Cmbestado.Size = New System.Drawing.Size(238, 21)
        Me.Cmbestado.TabIndex = 84
        Me.Cmbestado.Visible = False
        '
        'Labestado
        '
        Me.Labestado.AutoSize = True
        Me.Labestado.BackColor = System.Drawing.Color.Transparent
        Me.Labestado.Enabled = False
        Me.Labestado.Location = New System.Drawing.Point(149, 48)
        Me.Labestado.Name = "Labestado"
        Me.Labestado.Size = New System.Drawing.Size(46, 13)
        Me.Labestado.TabIndex = 85
        Me.Labestado.Text = "Estado: "
        Me.Labestado.Visible = False
        '
        'cmbcorporativo
        '
        Me.cmbcorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcorporativo.FormattingEnabled = True
        Me.cmbcorporativo.Location = New System.Drawing.Point(259, 17)
        Me.cmbcorporativo.Name = "cmbcorporativo"
        Me.cmbcorporativo.Size = New System.Drawing.Size(238, 21)
        Me.cmbcorporativo.TabIndex = 86
        '
        'labcorporativo
        '
        Me.labcorporativo.AutoSize = True
        Me.labcorporativo.BackColor = System.Drawing.Color.Transparent
        Me.labcorporativo.Location = New System.Drawing.Point(256, 3)
        Me.labcorporativo.Name = "labcorporativo"
        Me.labcorporativo.Size = New System.Drawing.Size(72, 13)
        Me.labcorporativo.TabIndex = 87
        Me.labcorporativo.Text = "Tipo Cliente : "
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(520, 25)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 88
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmConsulClienFunci
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmConsulClienFunci"
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
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        CType(Me.DGVFuncionario_x_clte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbtipopersona As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents btnCargarClientes As System.Windows.Forms.Button
    Friend WithEvents DGVFuncionario_x_clte As System.Windows.Forms.DataGridView
    Friend WithEvents Labnroregistro As System.Windows.Forms.Label
    Friend WithEvents Cmbestado As System.Windows.Forms.ComboBox
    Friend WithEvents Labestado As System.Windows.Forms.Label
    Friend WithEvents cmbcorporativo As System.Windows.Forms.ComboBox
    Friend WithEvents labcorporativo As System.Windows.Forms.Label

    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
