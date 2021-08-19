<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlantillaJ
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlantillaJ))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ShadowLabel1 = New Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TreeLista = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuTab = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMante = New System.Windows.Forms.TabControl()
        Me.TabLista = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBusca = New System.Windows.Forms.TextBox()
        Me.DataGridLista = New System.Windows.Forms.DataGrid()
        Me.TabDatos = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuTab.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ShadowLabel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(782, 623)
        Me.SplitContainer1.SplitterDistance = 33
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.BackColor = System.Drawing.SystemColors.Window
        Me.ShadowLabel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ShadowLabel1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShadowLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ShadowLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ShadowLabel1.Name = "ShadowLabel1"
        Me.ShadowLabel1.ShadowColor = System.Drawing.Color.Silver
        Me.ShadowLabel1.Size = New System.Drawing.Size(782, 33)
        Me.ShadowLabel1.TabIndex = 4
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TreeLista)
        Me.SplitContainer2.Panel1MinSize = 200
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Size = New System.Drawing.Size(782, 557)
        Me.SplitContainer2.SplitterDistance = 200
        Me.SplitContainer2.SplitterWidth = 2
        Me.SplitContainer2.TabIndex = 6
        '
        'TreeLista
        '
        Me.TreeLista.BackColor = System.Drawing.SystemColors.Info
        Me.TreeLista.ImageIndex = 0
        Me.TreeLista.ImageList = Me.ImageList1
        Me.TreeLista.Location = New System.Drawing.Point(11, 19)
        Me.TreeLista.Name = "TreeLista"
        Me.TreeLista.SelectedImageIndex = 0
        Me.TreeLista.ShowRootLines = False
        Me.TreeLista.Size = New System.Drawing.Size(173, 518)
        Me.TreeLista.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "arrow-up_16.ico")
        Me.ImageList1.Images.SetKeyName(1, "arrow-forward_16.ico")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.MenuTab)
        Me.Panel1.Controls.Add(Me.TabMante)
        Me.Panel1.Location = New System.Drawing.Point(21, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 520)
        Me.Panel1.TabIndex = 0
        '
        'MenuTab
        '
        Me.MenuTab.AutoSize = False
        Me.MenuTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.MenuTab.Location = New System.Drawing.Point(0, 0)
        Me.MenuTab.Name = "MenuTab"
        Me.MenuTab.Size = New System.Drawing.Size(544, 28)
        Me.MenuTab.TabIndex = 1
        Me.MenuTab.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem1.Text = " "
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem2.Text = " "
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem3.Text = " "
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem4.Text = " "
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem5.Text = " "
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(22, 24)
        Me.ToolStripMenuItem6.Text = " "
        '
        'TabMante
        '
        Me.TabMante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMante.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabMante.Controls.Add(Me.TabLista)
        Me.TabMante.Controls.Add(Me.TabDatos)
        Me.TabMante.Controls.Add(Me.TabPage1)
        Me.TabMante.Controls.Add(Me.TabPage2)
        Me.TabMante.Controls.Add(Me.TabPage3)
        Me.TabMante.Controls.Add(Me.TabPage4)
        Me.TabMante.Location = New System.Drawing.Point(0, 3)
        Me.TabMante.Name = "TabMante"
        Me.TabMante.SelectedIndex = 0
        Me.TabMante.Size = New System.Drawing.Size(544, 515)
        Me.TabMante.TabIndex = 0
        '
        'TabLista
        '
        Me.TabLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.TxtBusca)
        Me.TabLista.Controls.Add(Me.DataGridLista)
        Me.TabLista.Location = New System.Drawing.Point(4, 25)
        Me.TabLista.Name = "TabLista"
        Me.TabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLista.Size = New System.Drawing.Size(536, 486)
        Me.TabLista.TabIndex = 0
        Me.TabLista.Text = "TabPage1"
        Me.TabLista.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(18, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Buscar"
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(21, 34)
        Me.TxtBusca.Name = "TxtBusca"
        Me.TxtBusca.Size = New System.Drawing.Size(138, 20)
        Me.TxtBusca.TabIndex = 1
        '
        'DataGridLista
        '
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataGridLista.DataMember = ""
        Me.DataGridLista.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridLista.Location = New System.Drawing.Point(21, 77)
        Me.DataGridLista.Name = "DataGridLista"
        Me.DataGridLista.Size = New System.Drawing.Size(494, 380)
        Me.DataGridLista.TabIndex = 0
        '
        'TabDatos
        '
        Me.TabDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabDatos.Location = New System.Drawing.Point(4, 25)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDatos.Size = New System.Drawing.Size(536, 486)
        Me.TabDatos.TabIndex = 1
        Me.TabDatos.Text = "TabPage2"
        Me.TabDatos.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(536, 486)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(536, 486)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(536, 486)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(536, 486)
        Me.TabPage4.TabIndex = 5
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem1, Me.EdicionToolStripMenuItem, Me.GrabarToolStripMenuItem, Me.CancelarToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.AyudaToolStripMenuItem1, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(782, 32)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NuevoToolStripMenuItem1
        '
        Me.NuevoToolStripMenuItem1.Image = CType(resources.GetObject("NuevoToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.NuevoToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoToolStripMenuItem1.Name = "NuevoToolStripMenuItem1"
        Me.NuevoToolStripMenuItem1.Size = New System.Drawing.Size(78, 28)
        Me.NuevoToolStripMenuItem1.Text = "Nuevo"
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.Image = CType(resources.GetObject("EdicionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EdicionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(82, 28)
        Me.EdicionToolStripMenuItem.Text = "Edicion"
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Image = CType(resources.GetObject("GrabarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GrabarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(78, 28)
        Me.GrabarToolStripMenuItem.Text = "Grabar"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Image = CType(resources.GetObject("CancelarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CancelarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(89, 28)
        Me.CancelarToolStripMenuItem.Text = "&Cancelar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Image = CType(resources.GetObject("EliminarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EliminarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(86, 28)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WordToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem, Me.EmailToolStripMenuItem})
        Me.ExportarToolStripMenuItem.Image = CType(resources.GetObject("ExportarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(86, 28)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'WordToolStripMenuItem
        '
        Me.WordToolStripMenuItem.Image = CType(resources.GetObject("WordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WordToolStripMenuItem.Name = "WordToolStripMenuItem"
        Me.WordToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.WordToolStripMenuItem.Text = "Word"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = CType(resources.GetObject("ExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Image = CType(resources.GetObject("PDFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PDFToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'EmailToolStripMenuItem
        '
        Me.EmailToolStripMenuItem.Image = CType(resources.GetObject("EmailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EmailToolStripMenuItem.Name = "EmailToolStripMenuItem"
        Me.EmailToolStripMenuItem.Size = New System.Drawing.Size(119, 38)
        Me.EmailToolStripMenuItem.Text = "Email"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = CType(resources.GetObject("ImprimirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(89, 28)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'AyudaToolStripMenuItem1
        '
        Me.AyudaToolStripMenuItem1.Image = CType(resources.GetObject("AyudaToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.AyudaToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaToolStripMenuItem1.Name = "AyudaToolStripMenuItem1"
        Me.AyudaToolStripMenuItem1.Size = New System.Drawing.Size(77, 28)
        Me.AyudaToolStripMenuItem1.Text = "Ayuda"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(65, 28)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'FrmPlantillaJ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuTab
        Me.Name = "FrmPlantillaJ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
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
        Me.MenuTab.ResumeLayout(False)
        Me.MenuTab.PerformLayout()
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Protected WithEvents ShadowLabel1 As Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
    Protected WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents TabMante As System.Windows.Forms.TabControl
    Protected WithEvents TabLista As System.Windows.Forms.TabPage
    Protected WithEvents TabDatos As System.Windows.Forms.TabPage
    Protected WithEvents DataGridLista As System.Windows.Forms.DataGrid
    Friend WithEvents MenuTab As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Protected WithEvents TxtBusca As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents TabPage1 As System.Windows.Forms.TabPage
    Protected WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Public WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents EmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents NuevoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents AyudaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TreeLista As System.Windows.Forms.TreeView
End Class
