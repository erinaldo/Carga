<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedorOperacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedorOperacion))
        Me.tabProveedor = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.tabMantenimiento = New System.Windows.Forms.TabPage()
        Me.txtRazonSocialProveedor = New System.Windows.Forms.TextBox()
        Me.txtRucProveedor = New System.Windows.Forms.TextBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.cboOperacion = New System.Windows.Forms.ComboBox()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabProveedor.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMantenimiento.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabProveedor
        '
        Me.tabProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabProveedor.Controls.Add(Me.tabLista)
        Me.tabProveedor.Controls.Add(Me.tabMantenimiento)
        Me.tabProveedor.Location = New System.Drawing.Point(8, 32)
        Me.tabProveedor.Name = "tabProveedor"
        Me.tabProveedor.SelectedIndex = 0
        Me.tabProveedor.Size = New System.Drawing.Size(659, 400)
        Me.tabProveedor.TabIndex = 1
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.dgvLista)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(651, 374)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'dgvLista
        '
        Me.dgvLista.AllowUserToAddRows = False
        Me.dgvLista.AllowUserToDeleteRows = False
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(6, 6)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(639, 362)
        Me.dgvLista.TabIndex = 0
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.Controls.Add(Me.txtRazonSocialProveedor)
        Me.tabMantenimiento.Controls.Add(Me.txtRucProveedor)
        Me.tabMantenimiento.Controls.Add(Me.Label107)
        Me.tabMantenimiento.Controls.Add(Me.cboOperacion)
        Me.tabMantenimiento.Controls.Add(Me.Label137)
        Me.tabMantenimiento.Controls.Add(Me.lblCiudad)
        Me.tabMantenimiento.Controls.Add(Me.Label1)
        Me.tabMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMantenimiento.Size = New System.Drawing.Size(651, 374)
        Me.tabMantenimiento.TabIndex = 1
        Me.tabMantenimiento.Text = "Mantenimiento"
        Me.tabMantenimiento.UseVisualStyleBackColor = True
        '
        'txtRazonSocialProveedor
        '
        Me.txtRazonSocialProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocialProveedor.Location = New System.Drawing.Point(300, 186)
        Me.txtRazonSocialProveedor.MaxLength = 100
        Me.txtRazonSocialProveedor.Name = "txtRazonSocialProveedor"
        Me.txtRazonSocialProveedor.Size = New System.Drawing.Size(259, 20)
        Me.txtRazonSocialProveedor.TabIndex = 251
        '
        'txtRucProveedor
        '
        Me.txtRucProveedor.Location = New System.Drawing.Point(222, 186)
        Me.txtRucProveedor.MaxLength = 11
        Me.txtRucProveedor.Name = "txtRucProveedor"
        Me.txtRucProveedor.Size = New System.Drawing.Size(78, 20)
        Me.txtRucProveedor.TabIndex = 250
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(152, 189)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(56, 13)
        Me.Label107.TabIndex = 252
        Me.Label107.Text = "Proveedor"
        '
        'cboOperacion
        '
        Me.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperacion.DropDownWidth = 180
        Me.cboOperacion.FormattingEnabled = True
        Me.cboOperacion.Location = New System.Drawing.Point(222, 143)
        Me.cboOperacion.Name = "cboOperacion"
        Me.cboOperacion.Size = New System.Drawing.Size(179, 21)
        Me.cboOperacion.TabIndex = 248
        '
        'Label137
        '
        Me.Label137.AutoSize = True
        Me.Label137.Location = New System.Drawing.Point(152, 147)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(56, 13)
        Me.Label137.TabIndex = 249
        Me.Label137.Text = "Operación"
        '
        'lblCiudad
        '
        Me.lblCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCiudad.Location = New System.Drawing.Point(219, 98)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(182, 13)
        Me.lblCiudad.TabIndex = 1
        Me.lblCiudad.Text = "CUSCO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(152, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ciudad"
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(673, 25)
        Me.tool.TabIndex = 10
        Me.tool.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Enabled = False
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "Grabar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Enabled = False
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'frmProveedorOperacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 434)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabProveedor)
        Me.Name = "frmProveedorOperacion"
        Me.Text = "Asociar Proveedor a Operación"
        Me.tabProveedor.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabMantenimiento.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabProveedor As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents tabMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtRazonSocialProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtRucProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
End Class
