<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GestionporDXLT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GestionporDXLT))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TlbNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DgvGestionDXLT = New System.Windows.Forms.DataGridView()
        Me.lblCantidadRegistros = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CkpAccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DgvGestionDXLT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TlbNuevo, Me.ExportarToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 32)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TlbNuevo
        '
        Me.TlbNuevo.Image = CType(resources.GetObject("TlbNuevo.Image"), System.Drawing.Image)
        Me.TlbNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TlbNuevo.Name = "TlbNuevo"
        Me.TlbNuevo.Size = New System.Drawing.Size(78, 28)
        Me.TlbNuevo.Text = "&Nuevo"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelToolStripMenuItem})
        Me.ExportarToolStripMenuItem.Image = CType(resources.GetObject("ExportarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(86, 28)
        Me.ExportarToolStripMenuItem.Text = "E&xportar"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = CType(resources.GetObject("ExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(116, 38)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(65, 28)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'DgvGestionDXLT
        '
        Me.DgvGestionDXLT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgvGestionDXLT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvGestionDXLT.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DgvGestionDXLT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvGestionDXLT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CkpAccion})
        Me.DgvGestionDXLT.Location = New System.Drawing.Point(12, 58)
        Me.DgvGestionDXLT.Name = "DgvGestionDXLT"
        Me.DgvGestionDXLT.Size = New System.Drawing.Size(984, 396)
        Me.DgvGestionDXLT.TabIndex = 10
        '
        'lblCantidadRegistros
        '
        Me.lblCantidadRegistros.AutoSize = True
        Me.lblCantidadRegistros.Location = New System.Drawing.Point(118, 42)
        Me.lblCantidadRegistros.Name = "lblCantidadRegistros"
        Me.lblCantidadRegistros.Size = New System.Drawing.Size(13, 13)
        Me.lblCantidadRegistros.TabIndex = 17
        Me.lblCantidadRegistros.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Cantidad Registros :"
        '
        'CkpAccion
        '
        Me.CkpAccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CkpAccion.HeaderText = "Acciòn"
        Me.CkpAccion.Name = "CkpAccion"
        Me.CkpAccion.Width = 46
        '
        'Frm_GestionporDXLT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 466)
        Me.Controls.Add(Me.lblCantidadRegistros)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DgvGestionDXLT)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_GestionporDXLT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion de Proyectos por Limite de Tiempo"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DgvGestionDXLT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Protected WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents TlbNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgvGestionDXLT As System.Windows.Forms.DataGridView
    Friend WithEvents lblCantidadRegistros As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CkpAccion As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
