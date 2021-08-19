<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramaRecojo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramaRecojo))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NuevoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelarToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AyudaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShadowLabel1 = New Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
        Me.MenuTab = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.TabLista = New System.Windows.Forms.TabPage
        Me.txtFuncionario = New System.Windows.Forms.TextBox
        Me.DataGridViewClientes = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBusca = New System.Windows.Forms.TextBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.TreeLista = New System.Windows.Forms.TreeView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabMante = New System.Windows.Forms.TabControl
        Me.TabDatos = New System.Windows.Forms.TabPage
        Me.txtDireccionRemitente = New System.Windows.Forms.TextBox
        Me.txtOperador = New System.Windows.Forms.TextBox
        Me.txtPeso = New System.Windows.Forms.TextBox
        Me.txtHoraFin = New System.Windows.Forms.MaskedTextBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.txtHoraIni = New System.Windows.Forms.MaskedTextBox
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.btnInactivar = New System.Windows.Forms.Button
        Me.btnModificar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.txtDistrito = New System.Windows.Forms.TextBox
        Me.txtVolumen = New System.Windows.Forms.TextBox
        Me.txtDias = New System.Windows.Forms.TextBox
        Me.txtDestino = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtGridViweRecojos = New System.Windows.Forms.DataGridView
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.MenuStrip1.SuspendLayout()
        Me.MenuTab.SuspendLayout()
        Me.TabLista.SuspendLayout()
        CType(Me.DataGridViewClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        CType(Me.dtGridViweRecojos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem1, Me.EdicionToolStripMenuItem, Me.GrabarToolStripMenuItem, Me.CancelarToolStripMenuItem7, Me.EliminarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.AyudaToolStripMenuItem1, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 35)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(756, 32)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
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
        'CancelarToolStripMenuItem7
        '
        Me.CancelarToolStripMenuItem7.Image = CType(resources.GetObject("CancelarToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.CancelarToolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CancelarToolStripMenuItem7.Name = "CancelarToolStripMenuItem7"
        Me.CancelarToolStripMenuItem7.Size = New System.Drawing.Size(85, 28)
        Me.CancelarToolStripMenuItem7.Text = "Cancelar"
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
        Me.ExportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WordToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem, Me.EmailToolStripMenuItem})
        Me.ExportarToolStripMenuItem.Image = CType(resources.GetObject("ExportarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(85, 28)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'WordToolStripMenuItem
        '
        Me.WordToolStripMenuItem.Image = CType(resources.GetObject("WordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WordToolStripMenuItem.Name = "WordToolStripMenuItem"
        Me.WordToolStripMenuItem.Size = New System.Drawing.Size(127, 38)
        Me.WordToolStripMenuItem.Text = "Word"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = CType(resources.GetObject("ExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(127, 38)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Image = CType(resources.GetObject("PDFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PDFToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(127, 38)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'EmailToolStripMenuItem
        '
        Me.EmailToolStripMenuItem.Image = CType(resources.GetObject("EmailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EmailToolStripMenuItem.Name = "EmailToolStripMenuItem"
        Me.EmailToolStripMenuItem.Size = New System.Drawing.Size(127, 38)
        Me.EmailToolStripMenuItem.Text = "Email"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = CType(resources.GetObject("ImprimirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(81, 28)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'AyudaToolStripMenuItem1
        '
        Me.AyudaToolStripMenuItem1.Image = CType(resources.GetObject("AyudaToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.AyudaToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaToolStripMenuItem1.Name = "AyudaToolStripMenuItem1"
        Me.AyudaToolStripMenuItem1.Size = New System.Drawing.Size(74, 28)
        Me.AyudaToolStripMenuItem1.Text = "Ayuda"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(63, 28)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.BackColor = System.Drawing.SystemColors.Window
        Me.ShadowLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ShadowLabel1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShadowLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ShadowLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ShadowLabel1.Name = "ShadowLabel1"
        Me.ShadowLabel1.ShadowColor = System.Drawing.Color.Silver
        Me.ShadowLabel1.Size = New System.Drawing.Size(756, 35)
        Me.ShadowLabel1.TabIndex = 7
        '
        'MenuTab
        '
        Me.MenuTab.AutoSize = False
        Me.MenuTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.MenuTab.Location = New System.Drawing.Point(0, 0)
        Me.MenuTab.Name = "MenuTab"
        Me.MenuTab.Size = New System.Drawing.Size(553, 28)
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
        'TabLista
        '
        Me.TabLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabLista.Controls.Add(Me.txtFuncionario)
        Me.TabLista.Controls.Add(Me.DataGridViewClientes)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.TxtBusca)
        Me.TabLista.Location = New System.Drawing.Point(4, 25)
        Me.TabLista.Name = "TabLista"
        Me.TabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLista.Size = New System.Drawing.Size(546, 486)
        Me.TabLista.TabIndex = 0
        Me.TabLista.Text = "TabPage1"
        Me.TabLista.UseVisualStyleBackColor = True
        '
        'txtFuncionario
        '
        Me.txtFuncionario.BackColor = System.Drawing.SystemColors.Info
        Me.txtFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFuncionario.Location = New System.Drawing.Point(293, 5)
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.Size = New System.Drawing.Size(245, 20)
        Me.txtFuncionario.TabIndex = 4
        '
        'DataGridViewClientes
        '
        Me.DataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewClientes.Location = New System.Drawing.Point(9, 34)
        Me.DataGridViewClientes.Name = "DataGridViewClientes"
        Me.DataGridViewClientes.Size = New System.Drawing.Size(533, 448)
        Me.DataGridViewClientes.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(241, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Buscar"
        '
        'TxtBusca
        '
        Me.TxtBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBusca.Location = New System.Drawing.Point(2, 5)
        Me.TxtBusca.Name = "TxtBusca"
        Me.TxtBusca.Size = New System.Drawing.Size(233, 20)
        Me.TxtBusca.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Location = New System.Drawing.Point(1, 71)
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
        Me.SplitContainer2.Size = New System.Drawing.Size(865, 557)
        Me.SplitContainer2.SplitterDistance = 200
        Me.SplitContainer2.SplitterWidth = 2
        Me.SplitContainer2.TabIndex = 9
        '
        'TreeLista
        '
        Me.TreeLista.BackColor = System.Drawing.SystemColors.Info
        Me.TreeLista.Location = New System.Drawing.Point(3, 3)
        Me.TreeLista.Name = "TreeLista"
        Me.TreeLista.ShowRootLines = False
        Me.TreeLista.Size = New System.Drawing.Size(193, 519)
        Me.TreeLista.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.MenuTab)
        Me.Panel1.Controls.Add(Me.TabMante)
        Me.Panel1.Location = New System.Drawing.Point(-1, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 520)
        Me.Panel1.TabIndex = 0
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
        Me.TabMante.Size = New System.Drawing.Size(554, 515)
        Me.TabMante.TabIndex = 0
        '
        'TabDatos
        '
        Me.TabDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabDatos.Controls.Add(Me.txtDireccionRemitente)
        Me.TabDatos.Controls.Add(Me.txtOperador)
        Me.TabDatos.Controls.Add(Me.txtPeso)
        Me.TabDatos.Controls.Add(Me.txtHoraFin)
        Me.TabDatos.Controls.Add(Me.txtObs)
        Me.TabDatos.Controls.Add(Me.txtHoraIni)
        Me.TabDatos.Controls.Add(Me.txtCantidad)
        Me.TabDatos.Controls.Add(Me.btnInactivar)
        Me.TabDatos.Controls.Add(Me.btnModificar)
        Me.TabDatos.Controls.Add(Me.btnAgregar)
        Me.TabDatos.Controls.Add(Me.txtDistrito)
        Me.TabDatos.Controls.Add(Me.txtVolumen)
        Me.TabDatos.Controls.Add(Me.txtDias)
        Me.TabDatos.Controls.Add(Me.txtDestino)
        Me.TabDatos.Controls.Add(Me.Label12)
        Me.TabDatos.Controls.Add(Me.Label11)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.txtRazonSocial)
        Me.TabDatos.Controls.Add(Me.Label10)
        Me.TabDatos.Controls.Add(Me.Label5)
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.Label14)
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.Label9)
        Me.TabDatos.Controls.Add(Me.Label6)
        Me.TabDatos.Controls.Add(Me.Label3)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.dtGridViweRecojos)
        Me.TabDatos.Location = New System.Drawing.Point(4, 25)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDatos.Size = New System.Drawing.Size(546, 486)
        Me.TabDatos.TabIndex = 1
        Me.TabDatos.Text = "TabPage2"
        Me.TabDatos.UseVisualStyleBackColor = True
        '
        'txtDireccionRemitente
        '
        Me.txtDireccionRemitente.BackColor = System.Drawing.Color.White
        Me.txtDireccionRemitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccionRemitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccionRemitente.Location = New System.Drawing.Point(93, 53)
        Me.txtDireccionRemitente.MaxLength = 100
        Me.txtDireccionRemitente.Name = "txtDireccionRemitente"
        Me.txtDireccionRemitente.Size = New System.Drawing.Size(442, 20)
        Me.txtDireccionRemitente.TabIndex = 257
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.Color.White
        Me.txtOperador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperador.Location = New System.Drawing.Point(93, 77)
        Me.txtOperador.MaxLength = 40
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(178, 20)
        Me.txtOperador.TabIndex = 256
        '
        'txtPeso
        '
        Me.txtPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeso.Location = New System.Drawing.Point(218, 127)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(53, 20)
        Me.txtPeso.TabIndex = 255
        '
        'txtHoraFin
        '
        Me.txtHoraFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoraFin.Location = New System.Drawing.Point(216, 101)
        Me.txtHoraFin.Mask = "00:00"
        Me.txtHoraFin.Name = "txtHoraFin"
        Me.txtHoraFin.Size = New System.Drawing.Size(55, 20)
        Me.txtHoraFin.TabIndex = 252
        Me.txtHoraFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoraFin.ValidatingType = GetType(Date)
        '
        'txtObs
        '
        Me.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObs.Location = New System.Drawing.Point(93, 153)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(442, 63)
        Me.txtObs.TabIndex = 253
        '
        'txtHoraIni
        '
        Me.txtHoraIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoraIni.Location = New System.Drawing.Point(93, 101)
        Me.txtHoraIni.Mask = "00:00"
        Me.txtHoraIni.Name = "txtHoraIni"
        Me.txtHoraIni.Size = New System.Drawing.Size(53, 20)
        Me.txtHoraIni.TabIndex = 251
        Me.txtHoraIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoraIni.ValidatingType = GetType(Date)
        '
        'txtCantidad
        '
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Location = New System.Drawing.Point(93, 126)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(55, 20)
        Me.txtCantidad.TabIndex = 254
        '
        'btnInactivar
        '
        Me.btnInactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInactivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInactivar.Location = New System.Drawing.Point(460, 224)
        Me.btnInactivar.Name = "btnInactivar"
        Me.btnInactivar.Size = New System.Drawing.Size(75, 26)
        Me.btnInactivar.TabIndex = 5
        Me.btnInactivar.Text = "Eliminar"
        Me.btnInactivar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(350, 224)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(104, 26)
        Me.btnModificar.TabIndex = 5
        Me.btnModificar.Text = "(F5) Actualizar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(243, 224)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(103, 26)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Text = "(F3) Agregar "
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtDistrito
        '
        Me.txtDistrito.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistrito.Location = New System.Drawing.Point(93, 29)
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Size = New System.Drawing.Size(213, 20)
        Me.txtDistrito.TabIndex = 3
        '
        'txtVolumen
        '
        Me.txtVolumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVolumen.Location = New System.Drawing.Point(403, 127)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(74, 20)
        Me.txtVolumen.TabIndex = 3
        '
        'txtDias
        '
        Me.txtDias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDias.Location = New System.Drawing.Point(322, 101)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(155, 20)
        Me.txtDias.TabIndex = 3
        '
        'txtDestino
        '
        Me.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestino.Location = New System.Drawing.Point(322, 77)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(213, 20)
        Me.txtDestino.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Cantidad"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(319, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Volumen(m3)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 156)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "OBS"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.SystemColors.Info
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.Location = New System.Drawing.Point(94, 5)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(338, 20)
        Me.txtRazonSocial.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(153, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Peso (Kg)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Distrito"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(148, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Hora Final"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(274, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Destino"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Contacto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(287, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Dia "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Hora Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Direccion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Razon Social"
        '
        'dtGridViweRecojos
        '
        Me.dtGridViweRecojos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtGridViweRecojos.Location = New System.Drawing.Point(5, 256)
        Me.dtGridViweRecojos.Name = "dtGridViweRecojos"
        Me.dtGridViweRecojos.Size = New System.Drawing.Size(533, 226)
        Me.dtGridViweRecojos.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(546, 486)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(546, 486)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(546, 486)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(546, 486)
        Me.TabPage4.TabIndex = 5
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'frmProgramaRecojo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 597)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ShadowLabel1)
        Me.Name = "frmProgramaRecojo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programacion de Recojo"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MenuTab.ResumeLayout(False)
        Me.MenuTab.PerformLayout()
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        CType(Me.DataGridViewClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        CType(Me.dtGridViweRecojos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Protected WithEvents NuevoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents EmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents ShadowLabel1 As Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
    Friend WithEvents MenuTab As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents TabLista As System.Windows.Forms.TabPage
    Protected WithEvents TxtBusca As System.Windows.Forms.TextBox
    Protected WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Protected WithEvents TreeLista As System.Windows.Forms.TreeView
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents TabMante As System.Windows.Forms.TabControl
    Protected WithEvents TabDatos As System.Windows.Forms.TabPage
    Protected WithEvents TabPage1 As System.Windows.Forms.TabPage
    Protected WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridViewClientes As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtGridViweRecojos As System.Windows.Forms.DataGridView
    Friend WithEvents txtDistrito As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnInactivar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Protected WithEvents txtFuncionario As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionRemitente As System.Windows.Forms.TextBox
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
End Class
