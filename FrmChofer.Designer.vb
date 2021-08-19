<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChofer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChofer))
        Me.tabChofer = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvChofer = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtLicencia = New System.Windows.Forms.TextBox()
        Me.lblLicencia = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAM = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAP = New System.Windows.Forms.TextBox()
        Me.LblAP = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.tabChofer.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvChofer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabChofer
        '
        Me.tabChofer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabChofer.Controls.Add(Me.TabPage1)
        Me.tabChofer.Controls.Add(Me.TabPage2)
        Me.tabChofer.Location = New System.Drawing.Point(12, 37)
        Me.tabChofer.Name = "tabChofer"
        Me.tabChofer.SelectedIndex = 0
        Me.tabChofer.Size = New System.Drawing.Size(667, 448)
        Me.tabChofer.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvChofer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(659, 422)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvChofer
        '
        Me.dgvChofer.AllowUserToAddRows = False
        Me.dgvChofer.AllowUserToDeleteRows = False
        Me.dgvChofer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvChofer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChofer.Location = New System.Drawing.Point(6, 6)
        Me.dgvChofer.Name = "dgvChofer"
        Me.dgvChofer.Size = New System.Drawing.Size(647, 410)
        Me.dgvChofer.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnCancelar)
        Me.TabPage2.Controls.Add(Me.btnGuardar)
        Me.TabPage2.Controls.Add(Me.txtLicencia)
        Me.TabPage2.Controls.Add(Me.lblLicencia)
        Me.TabPage2.Controls.Add(Me.txtNombres)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtAM)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtAP)
        Me.TabPage2.Controls.Add(Me.LblAP)
        Me.TabPage2.Controls.Add(Me.txtCodigo)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(659, 422)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mantenimiento"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Image = Global.INTEGRACION.My.Resources.Resources.IzquierdaTodos
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(358, 277)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 33)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = Global.INTEGRACION.My.Resources.Resources.mp_toolbarGuardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(153, 277)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 33)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtLicencia
        '
        Me.txtLicencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLicencia.Location = New System.Drawing.Point(118, 177)
        Me.txtLicencia.MaxLength = 15
        Me.txtLicencia.Name = "txtLicencia"
        Me.txtLicencia.Size = New System.Drawing.Size(142, 20)
        Me.txtLicencia.TabIndex = 5
        '
        'lblLicencia
        '
        Me.lblLicencia.AutoSize = True
        Me.lblLicencia.Location = New System.Drawing.Point(19, 180)
        Me.lblLicencia.Name = "lblLicencia"
        Me.lblLicencia.Size = New System.Drawing.Size(62, 13)
        Me.lblLicencia.TabIndex = 1
        Me.lblLicencia.Text = "Nº Licencia"
        '
        'txtNombres
        '
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Location = New System.Drawing.Point(118, 140)
        Me.txtNombres.MaxLength = 40
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(422, 20)
        Me.txtNombres.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nombres"
        '
        'txtAM
        '
        Me.txtAM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAM.Location = New System.Drawing.Point(118, 105)
        Me.txtAM.MaxLength = 40
        Me.txtAM.Name = "txtAM"
        Me.txtAM.Size = New System.Drawing.Size(422, 20)
        Me.txtAM.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Apellido Mat."
        '
        'txtAP
        '
        Me.txtAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAP.Location = New System.Drawing.Point(118, 70)
        Me.txtAP.MaxLength = 40
        Me.txtAP.Name = "txtAP"
        Me.txtAP.Size = New System.Drawing.Size(422, 20)
        Me.txtAP.TabIndex = 2
        '
        'LblAP
        '
        Me.LblAP.AutoSize = True
        Me.LblAP.Location = New System.Drawing.Point(19, 73)
        Me.LblAP.Name = "LblAP"
        Me.LblAP.Size = New System.Drawing.Size(66, 13)
        Me.LblAP.TabIndex = 1
        Me.LblAP.Text = "Apellido Pat."
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(118, 31)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código"
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.toolStripSeparator2, Me.EditarToolStripMenuItem, Me.AnularToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(685, 25)
        Me.toolStrip1.TabIndex = 37
        Me.toolStrip1.Text = "toolStrip1"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.NuevoToolStripMenuItem.Image = CType(resources.GetObject("NuevoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(62, 22)
        Me.NuevoToolStripMenuItem.Text = "&Nuevo"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Enabled = False
        Me.EditarToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.EditarToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.EditarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(57, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Enabled = False
        Me.AnularToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AnularToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources.delete_16
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(62, 22)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.SalirToolStripMenuItem.Image = Global.INTEGRACION.My.Resources.Resources._1323
        Me.SalirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(49, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'FrmChofer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 489)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.tabChofer)
        Me.Name = "FrmChofer"
        Me.Text = "Piloto"
        Me.tabChofer.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvChofer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabChofer As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvChofer As System.Windows.Forms.DataGridView
    Friend WithEvents txtLicencia As System.Windows.Forms.TextBox
    Friend WithEvents lblLicencia As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAM As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAP As System.Windows.Forms.TextBox
    Friend WithEvents LblAP As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripButton
End Class
