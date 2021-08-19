<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUnidadAgencia
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUnidadAgencia))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ShadowLabel1 = New Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TabUsuarios = New System.Windows.Forms.TabControl
        Me.TabListaUser = New System.Windows.Forms.TabPage
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DataGridUnd = New System.Windows.Forms.DataGrid
        Me.TabDatosUsuario = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNomUnd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtIdUnd = New System.Windows.Forms.TextBox
        Me.TabROLES = New System.Windows.Forms.TabPage
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.NuevoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabUsuarios.SuspendLayout()
        Me.TabListaUser.SuspendLayout()
        CType(Me.DataGridUnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDatosUsuario.SuspendLayout()
        Me.TabROLES.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuStrip1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ShadowLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainer1, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 303.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(715, 503)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem1, Me.EdicionToolStripMenuItem, Me.GrabarToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 33)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(715, 32)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShadowLabel1.BackColor = System.Drawing.SystemColors.Window
        Me.ShadowLabel1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShadowLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ShadowLabel1.Location = New System.Drawing.Point(3, 3)
        Me.ShadowLabel1.Name = "ShadowLabel1"
        Me.ShadowLabel1.ShadowColor = System.Drawing.Color.Silver
        Me.ShadowLabel1.Size = New System.Drawing.Size(709, 26)
        Me.ShadowLabel1.TabIndex = 3
        Me.ShadowLabel1.Text = "Registro de Unidades de Agencia"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 68)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1Collapsed = True
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabUsuarios)
        Me.SplitContainer1.Size = New System.Drawing.Size(709, 432)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.TabIndex = 0
        '
        'TabUsuarios
        '
        Me.TabUsuarios.Controls.Add(Me.TabListaUser)
        Me.TabUsuarios.Controls.Add(Me.TabDatosUsuario)
        Me.TabUsuarios.Controls.Add(Me.TabROLES)
        Me.TabUsuarios.Location = New System.Drawing.Point(23, 20)
        Me.TabUsuarios.Name = "TabUsuarios"
        Me.TabUsuarios.SelectedIndex = 0
        Me.TabUsuarios.Size = New System.Drawing.Size(653, 365)
        Me.TabUsuarios.TabIndex = 6
        '
        'TabListaUser
        '
        Me.TabListaUser.BackColor = System.Drawing.SystemColors.Desktop
        Me.TabListaUser.Controls.Add(Me.TextBox1)
        Me.TabListaUser.Controls.Add(Me.DataGridUnd)
        Me.TabListaUser.Location = New System.Drawing.Point(4, 22)
        Me.TabListaUser.Name = "TabListaUser"
        Me.TabListaUser.Padding = New System.Windows.Forms.Padding(3)
        Me.TabListaUser.Size = New System.Drawing.Size(645, 339)
        Me.TabListaUser.TabIndex = 0
        Me.TabListaUser.Text = "UNIDADES"
        Me.TabListaUser.ToolTipText = "Lista todos los usuarios x Agencias"
        Me.TabListaUser.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(97, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 1
        '
        'DataGridUnd
        '
        Me.DataGridUnd.DataMember = ""
        Me.DataGridUnd.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridUnd.Location = New System.Drawing.Point(6, 66)
        Me.DataGridUnd.Name = "DataGridUnd"
        Me.DataGridUnd.Size = New System.Drawing.Size(633, 267)
        Me.DataGridUnd.TabIndex = 0
        '
        'TabDatosUsuario
        '
        Me.TabDatosUsuario.BackColor = System.Drawing.SystemColors.Desktop
        Me.TabDatosUsuario.Controls.Add(Me.Label2)
        Me.TabDatosUsuario.Controls.Add(Me.TxtNomUnd)
        Me.TabDatosUsuario.Controls.Add(Me.Label1)
        Me.TabDatosUsuario.Controls.Add(Me.TxtIdUnd)
        Me.TabDatosUsuario.Location = New System.Drawing.Point(4, 22)
        Me.TabDatosUsuario.Name = "TabDatosUsuario"
        Me.TabDatosUsuario.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDatosUsuario.Size = New System.Drawing.Size(645, 339)
        Me.TabDatosUsuario.TabIndex = 1
        Me.TabDatosUsuario.Text = "DATOS GENERALES"
        Me.TabDatosUsuario.ToolTipText = "Muestra los Datos del usuario del Sistema"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(185, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "UNIDAD"
        '
        'TxtNomUnd
        '
        Me.TxtNomUnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomUnd.ForeColor = System.Drawing.Color.Black
        Me.TxtNomUnd.Location = New System.Drawing.Point(258, 142)
        Me.TxtNomUnd.Name = "TxtNomUnd"
        Me.TxtNomUnd.Size = New System.Drawing.Size(314, 20)
        Me.TxtNomUnd.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(185, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID"
        '
        'TxtIdUnd
        '
        Me.TxtIdUnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdUnd.Location = New System.Drawing.Point(258, 105)
        Me.TxtIdUnd.Name = "TxtIdUnd"
        Me.TxtIdUnd.ReadOnly = True
        Me.TxtIdUnd.Size = New System.Drawing.Size(48, 20)
        Me.TxtIdUnd.TabIndex = 1
        '
        'TabROLES
        '
        Me.TabROLES.BackColor = System.Drawing.SystemColors.Desktop
        Me.TabROLES.Controls.Add(Me.DataGridView1)
        Me.TabROLES.Location = New System.Drawing.Point(4, 22)
        Me.TabROLES.Name = "TabROLES"
        Me.TabROLES.Padding = New System.Windows.Forms.Padding(3)
        Me.TabROLES.Size = New System.Drawing.Size(645, 339)
        Me.TabROLES.TabIndex = 2
        Me.TabROLES.Text = "ROLES"
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(633, 346)
        Me.DataGridView1.TabIndex = 0
        '
        'NuevoToolStripMenuItem1
        '
        Me.NuevoToolStripMenuItem1.Image = CType(resources.GetObject("NuevoToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.NuevoToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoToolStripMenuItem1.Name = "NuevoToolStripMenuItem1"
        Me.NuevoToolStripMenuItem1.Size = New System.Drawing.Size(74, 28)
        Me.NuevoToolStripMenuItem1.Text = "Nuevo"
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.Image = CType(resources.GetObject("EdicionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EdicionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(76, 28)
        Me.EdicionToolStripMenuItem.Text = "Edicion"
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Image = CType(resources.GetObject("GrabarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GrabarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(76, 28)
        Me.GrabarToolStripMenuItem.Text = "Grabar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Image = CType(resources.GetObject("EliminarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EliminarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(79, 28)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Image = CType(resources.GetObject("ExportarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(85, 28)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = CType(resources.GetObject("ImprimirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(81, 28)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(63, 28)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'FrmUnidadAgencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 502)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmUnidadAgencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabUsuarios.ResumeLayout(False)
        Me.TabListaUser.ResumeLayout(False)
        Me.TabListaUser.PerformLayout()
        CType(Me.DataGridUnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDatosUsuario.ResumeLayout(False)
        Me.TabDatosUsuario.PerformLayout()
        Me.TabROLES.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ShadowLabel1 As Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NuevoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents TabUsuarios As System.Windows.Forms.TabControl
    Friend WithEvents TabListaUser As System.Windows.Forms.TabPage
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridUnd As System.Windows.Forms.DataGrid
    Friend WithEvents TabDatosUsuario As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNomUnd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtIdUnd As System.Windows.Forms.TextBox
    Friend WithEvents TabROLES As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
