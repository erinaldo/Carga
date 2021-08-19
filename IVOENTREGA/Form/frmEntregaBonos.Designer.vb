<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregaBonos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntregaBonos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboOperacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboAgencia = New System.Windows.Forms.ComboBox()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.tabBono = New System.Windows.Forms.TabControl()
        Me.tabCalculo = New System.Windows.Forms.TabPage()
        Me.dgvBono = New System.Windows.Forms.DataGridView()
        Me.tabConsulta = New System.Windows.Forms.TabPage()
        Me.dgvBonoConsulta = New System.Windows.Forms.DataGridView()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabBono.SuspendLayout()
        Me.tabCalculo.SuspendLayout()
        CType(Me.dgvBono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConsulta.SuspendLayout()
        CType(Me.dgvBonoConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(257, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Período"
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.DropDownWidth = 200
        Me.cboPeriodo.FormattingEnabled = True
        Me.cboPeriodo.Location = New System.Drawing.Point(306, 37)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(212, 21)
        Me.cboPeriodo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(540, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Operación"
        '
        'cboOperacion
        '
        Me.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperacion.FormattingEnabled = True
        Me.cboOperacion.Items.AddRange(New Object() {" (SELECCIONE)", "INGRESO ALMACEN", "SALIDA ALMACEN", "ENTREGA"})
        Me.cboOperacion.Location = New System.Drawing.Point(602, 37)
        Me.cboOperacion.Name = "cboOperacion"
        Me.cboOperacion.Size = New System.Drawing.Size(170, 21)
        Me.cboOperacion.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Agencia"
        '
        'cboAgencia
        '
        Me.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgencia.FormattingEnabled = True
        Me.cboAgencia.Location = New System.Drawing.Point(68, 37)
        Me.cboAgencia.Name = "cboAgencia"
        Me.cboAgencia.Size = New System.Drawing.Size(170, 21)
        Me.cboAgencia.TabIndex = 1
        '
        'btnCalcular
        '
        Me.btnCalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalcular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalcular.Image = CType(resources.GetObject("btnCalcular.Image"), System.Drawing.Image)
        Me.btnCalcular.Location = New System.Drawing.Point(919, 29)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(80, 35)
        Me.btnCalcular.TabIndex = 88
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'tabBono
        '
        Me.tabBono.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabBono.Controls.Add(Me.tabCalculo)
        Me.tabBono.Controls.Add(Me.tabConsulta)
        Me.tabBono.Location = New System.Drawing.Point(12, 69)
        Me.tabBono.Name = "tabBono"
        Me.tabBono.SelectedIndex = 0
        Me.tabBono.Size = New System.Drawing.Size(991, 525)
        Me.tabBono.TabIndex = 89
        '
        'tabCalculo
        '
        Me.tabCalculo.Controls.Add(Me.dgvBono)
        Me.tabCalculo.Location = New System.Drawing.Point(4, 22)
        Me.tabCalculo.Name = "tabCalculo"
        Me.tabCalculo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCalculo.Size = New System.Drawing.Size(983, 499)
        Me.tabCalculo.TabIndex = 0
        Me.tabCalculo.Text = "Cálculo"
        Me.tabCalculo.UseVisualStyleBackColor = True
        '
        'dgvBono
        '
        Me.dgvBono.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBono.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBono.Location = New System.Drawing.Point(11, 12)
        Me.dgvBono.Name = "dgvBono"
        Me.dgvBono.Size = New System.Drawing.Size(959, 471)
        Me.dgvBono.TabIndex = 3
        '
        'tabConsulta
        '
        Me.tabConsulta.Controls.Add(Me.dgvBonoConsulta)
        Me.tabConsulta.Location = New System.Drawing.Point(4, 22)
        Me.tabConsulta.Name = "tabConsulta"
        Me.tabConsulta.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConsulta.Size = New System.Drawing.Size(983, 499)
        Me.tabConsulta.TabIndex = 1
        Me.tabConsulta.Text = "Consulta"
        Me.tabConsulta.UseVisualStyleBackColor = True
        '
        'dgvBonoConsulta
        '
        Me.dgvBonoConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBonoConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBonoConsulta.Location = New System.Drawing.Point(11, 12)
        Me.dgvBonoConsulta.Name = "dgvBonoConsulta"
        Me.dgvBonoConsulta.Size = New System.Drawing.Size(959, 471)
        Me.dgvBonoConsulta.TabIndex = 4
        '
        'tool
        '
        Me.tool.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbAnular, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(1016, 25)
        Me.tool.TabIndex = 90
        Me.tool.Text = "ToolStrip1"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(69, 22)
        Me.tsbGrabar.Text = "Grabar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1322
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(65, 22)
        Me.tsbAnular.Text = "Anular"
        Me.tsbAnular.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'frmEntregaBonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 596)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabBono)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.cboOperacion)
        Me.Controls.Add(Me.cboAgencia)
        Me.Controls.Add(Me.cboPeriodo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEntregaBonos"
        Me.Text = "Bonos"
        Me.tabBono.ResumeLayout(False)
        Me.tabCalculo.ResumeLayout(False)
        CType(Me.dgvBono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConsulta.ResumeLayout(False)
        CType(Me.dgvBonoConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents tabBono As System.Windows.Forms.TabControl
    Friend WithEvents tabCalculo As System.Windows.Forms.TabPage
    Friend WithEvents dgvBono As System.Windows.Forms.DataGridView
    Friend WithEvents tabConsulta As System.Windows.Forms.TabPage
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvBonoConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
End Class
