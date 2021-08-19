<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmhorariosalida
    Inherits INTEGRACION.FrmPlantilla

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
        Me.components = New System.ComponentModel.Container
        Dim Myimage As System.Windows.Forms.ImageList
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmhorariosalida))
        Me.txtorigen = New System.Windows.Forms.TextBox
        Me.txtDestino = New System.Windows.Forms.TextBox
        Me.cmbruta = New System.Windows.Forms.ComboBox
        Me.Labruta = New System.Windows.Forms.Label
        Me.laborigen = New System.Windows.Forms.Label
        Me.LabDestino = New System.Windows.Forms.Label
        Me.chkvigente = New System.Windows.Forms.CheckBox
        Me.txthorasalida = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GBoxSalidas = New System.Windows.Forms.GroupBox
        Me.Dgvrutahorario = New System.Windows.Forms.DataGridView
        Me.txtidrutahorario = New System.Windows.Forms.TextBox
        Myimage = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.Dgvrutahorario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.txtidrutahorario)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.txthorasalida)
        Me.TabDatos.Controls.Add(Me.chkvigente)
        Me.TabDatos.Controls.Add(Me.LabDestino)
        Me.TabDatos.Controls.Add(Me.laborigen)
        Me.TabDatos.Controls.Add(Me.Labruta)
        Me.TabDatos.Controls.Add(Me.cmbruta)
        Me.TabDatos.Controls.Add(Me.txtDestino)
        Me.TabDatos.Controls.Add(Me.txtorigen)
        Me.TabDatos.Controls.Add(Me.GBoxSalidas)
        '
        'MyTreeView
        '
        Me.MyTreeView.HideSelection = False
        Me.MyTreeView.ImageIndex = 0
        Me.MyTreeView.ImageList = Myimage
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.SelectedImageIndex = 1
        Me.MyTreeView.ShowLines = False
        Me.MyTreeView.ShowPlusMinus = False
        Me.MyTreeView.ShowRootLines = False
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Dgvrutahorario)
        Me.Panel.Location = New System.Drawing.Point(7, 54)
        Me.Panel.Size = New System.Drawing.Size(520, 402)
        '
        'Myimage
        '
        Myimage.ImageStream = CType(resources.GetObject("Myimage.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Myimage.TransparentColor = System.Drawing.Color.Transparent
        Myimage.Images.SetKeyName(0, "arrow-up_16.ico")
        Myimage.Images.SetKeyName(1, "arrow-forward_16.ico")
        '
        'txtorigen
        '
        Me.txtorigen.BackColor = System.Drawing.SystemColors.Info
        Me.txtorigen.Location = New System.Drawing.Point(146, 203)
        Me.txtorigen.Name = "txtorigen"
        Me.txtorigen.ReadOnly = True
        Me.txtorigen.Size = New System.Drawing.Size(158, 20)
        Me.txtorigen.TabIndex = 0
        '
        'txtDestino
        '
        Me.txtDestino.BackColor = System.Drawing.SystemColors.Info
        Me.txtDestino.Location = New System.Drawing.Point(146, 242)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.ReadOnly = True
        Me.txtDestino.Size = New System.Drawing.Size(158, 20)
        Me.txtDestino.TabIndex = 1
        '
        'cmbruta
        '
        Me.cmbruta.FormattingEnabled = True
        Me.cmbruta.Location = New System.Drawing.Point(146, 161)
        Me.cmbruta.Name = "cmbruta"
        Me.cmbruta.Size = New System.Drawing.Size(278, 21)
        Me.cmbruta.TabIndex = 2
        '
        'Labruta
        '
        Me.Labruta.AutoSize = True
        Me.Labruta.BackColor = System.Drawing.Color.Transparent
        Me.Labruta.Location = New System.Drawing.Point(93, 161)
        Me.Labruta.Name = "Labruta"
        Me.Labruta.Size = New System.Drawing.Size(39, 13)
        Me.Labruta.TabIndex = 4
        Me.Labruta.Text = "Ruta : "
        '
        'laborigen
        '
        Me.laborigen.AutoSize = True
        Me.laborigen.BackColor = System.Drawing.Color.Transparent
        Me.laborigen.Location = New System.Drawing.Point(93, 209)
        Me.laborigen.Name = "laborigen"
        Me.laborigen.Size = New System.Drawing.Size(44, 13)
        Me.laborigen.TabIndex = 5
        Me.laborigen.Text = "Origen :"
        '
        'LabDestino
        '
        Me.LabDestino.AutoSize = True
        Me.LabDestino.BackColor = System.Drawing.Color.Transparent
        Me.LabDestino.Location = New System.Drawing.Point(93, 248)
        Me.LabDestino.Name = "LabDestino"
        Me.LabDestino.Size = New System.Drawing.Size(43, 13)
        Me.LabDestino.TabIndex = 6
        Me.LabDestino.Text = "Destino"
        '
        'chkvigente
        '
        Me.chkvigente.AutoSize = True
        Me.chkvigente.BackColor = System.Drawing.Color.Transparent
        Me.chkvigente.Location = New System.Drawing.Point(362, 287)
        Me.chkvigente.Name = "chkvigente"
        Me.chkvigente.Size = New System.Drawing.Size(62, 17)
        Me.chkvigente.TabIndex = 7
        Me.chkvigente.Text = "Vigente"
        Me.chkvigente.UseVisualStyleBackColor = False
        '
        'txthorasalida
        '
        Me.txthorasalida.Location = New System.Drawing.Point(146, 282)
        Me.txthorasalida.Name = "txthorasalida"
        Me.txthorasalida.Size = New System.Drawing.Size(62, 20)
        Me.txthorasalida.TabIndex = 8
        Me.txthorasalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(96, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Hora : "
        '
        'GBoxSalidas
        '
        Me.GBoxSalidas.BackColor = System.Drawing.Color.Transparent
        Me.GBoxSalidas.Location = New System.Drawing.Point(75, 133)
        Me.GBoxSalidas.Name = "GBoxSalidas"
        Me.GBoxSalidas.Size = New System.Drawing.Size(401, 184)
        Me.GBoxSalidas.TabIndex = 10
        Me.GBoxSalidas.TabStop = False
        Me.GBoxSalidas.Text = "Salida"
        '
        'Dgvrutahorario
        '
        Me.Dgvrutahorario.BackgroundColor = System.Drawing.SystemColors.Info
        Me.Dgvrutahorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvrutahorario.Location = New System.Drawing.Point(0, 0)
        Me.Dgvrutahorario.Name = "Dgvrutahorario"
        Me.Dgvrutahorario.Size = New System.Drawing.Size(520, 402)
        Me.Dgvrutahorario.TabIndex = 0
        '
        'txtidrutahorario
        '
        Me.txtidrutahorario.Location = New System.Drawing.Point(87, 97)
        Me.txtidrutahorario.Name = "txtidrutahorario"
        Me.txtidrutahorario.Size = New System.Drawing.Size(100, 20)
        Me.txtidrutahorario.TabIndex = 11
        '
        'Frmhorariosalida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "Frmhorariosalida"
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
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.Panel.ResumeLayout(False)
        CType(Me.Dgvrutahorario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyImageList As System.Windows.Forms.ImageList
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtorigen As System.Windows.Forms.TextBox
    Friend WithEvents LabDestino As System.Windows.Forms.Label
    Friend WithEvents laborigen As System.Windows.Forms.Label
    Friend WithEvents Labruta As System.Windows.Forms.Label
    Friend WithEvents cmbruta As System.Windows.Forms.ComboBox
    Friend WithEvents chkvigente As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txthorasalida As System.Windows.Forms.TextBox
    Friend WithEvents GBoxSalidas As System.Windows.Forms.GroupBox
    Friend WithEvents Dgvrutahorario As System.Windows.Forms.DataGridView
    Friend WithEvents txtidrutahorario As System.Windows.Forms.TextBox
End Class
