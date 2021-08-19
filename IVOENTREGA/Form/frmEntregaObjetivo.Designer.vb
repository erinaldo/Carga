<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregaObjetivo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntregaObjetivo))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabObjetivoEntrega = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.grbFiltro = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.cboOperacion = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabMantenimiento = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtAdicionalPCE = New System.Windows.Forms.TextBox()
        Me.txtAdicional = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboOperacion2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaActivacion = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvObjetivo = New System.Windows.Forms.DataGridView()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.tabObjetivoEntrega.SuspendLayout()
        Me.tabLista.SuspendLayout()
        Me.grbFiltro.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.tabMantenimiento.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvObjetivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabObjetivoEntrega
        '
        Me.tabObjetivoEntrega.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabObjetivoEntrega.Controls.Add(Me.tabLista)
        Me.tabObjetivoEntrega.Controls.Add(Me.tabMantenimiento)
        Me.tabObjetivoEntrega.Location = New System.Drawing.Point(7, 6)
        Me.tabObjetivoEntrega.Name = "tabObjetivoEntrega"
        Me.tabObjetivoEntrega.SelectedIndex = 0
        Me.tabObjetivoEntrega.Size = New System.Drawing.Size(796, 463)
        Me.tabObjetivoEntrega.TabIndex = 32
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.grbFiltro)
        Me.tabLista.Controls.Add(Me.GroupBox7)
        Me.tabLista.Controls.Add(Me.MenuStrip1)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(788, 437)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'grbFiltro
        '
        Me.grbFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltro.Controls.Add(Me.btnConsultar)
        Me.grbFiltro.Controls.Add(Me.cboOperacion)
        Me.grbFiltro.Controls.Add(Me.Label13)
        Me.grbFiltro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grbFiltro.Location = New System.Drawing.Point(6, 34)
        Me.grbFiltro.Name = "grbFiltro"
        Me.grbFiltro.Size = New System.Drawing.Size(772, 48)
        Me.grbFiltro.TabIndex = 33
        Me.grbFiltro.TabStop = False
        Me.grbFiltro.Text = "Filtro Busqueda"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnConsultar.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(677, 11)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(89, 31)
        Me.btnConsultar.TabIndex = 34
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboOperacion
        '
        Me.cboOperacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperacion.FormattingEnabled = True
        Me.cboOperacion.Items.AddRange(New Object() {" (TODO)", "INGRESO ALMACEN", "SALIDA ALMACEN", "ENTREGA"})
        Me.cboOperacion.Location = New System.Drawing.Point(342, 17)
        Me.cboOperacion.Name = "cboOperacion"
        Me.cboOperacion.Size = New System.Drawing.Size(186, 21)
        Me.cboOperacion.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(235, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Tipo Operación"
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.dgvLista)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 87)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(772, 343)
        Me.GroupBox7.TabIndex = 32
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Lista"
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLista.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLista.Location = New System.Drawing.Point(6, 19)
        Me.dgvLista.Name = "dgvLista"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLista.Size = New System.Drawing.Size(760, 315)
        Me.dgvLista.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbAnular, Me.tsbSalir})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(782, 27)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 20)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Checked = True
        Me.tsbEditar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsbEditar.Enabled = False
        Me.tsbEditar.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(65, 23)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources.delete_16
        Me.tsbAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(70, 23)
        Me.tsbAnular.Text = "Anular"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(57, 23)
        Me.tsbSalir.Text = "&Salir"
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.Controls.Add(Me.GroupBox3)
        Me.tabMantenimiento.Controls.Add(Me.btnCancelar)
        Me.tabMantenimiento.Controls.Add(Me.btnGuardar)
        Me.tabMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMantenimiento.Size = New System.Drawing.Size(788, 437)
        Me.tabMantenimiento.TabIndex = 1
        Me.tabMantenimiento.Text = "Mantenimiento"
        Me.tabMantenimiento.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAdicionalPCE)
        Me.GroupBox3.Controls.Add(Me.txtAdicional)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cboOperacion2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.dtpFechaActivacion)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.dgvObjetivo)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(759, 368)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        '
        'txtAdicionalPCE
        '
        Me.txtAdicionalPCE.Location = New System.Drawing.Point(517, 55)
        Me.txtAdicionalPCE.MaxLength = 5
        Me.txtAdicionalPCE.Name = "txtAdicionalPCE"
        Me.txtAdicionalPCE.Size = New System.Drawing.Size(73, 20)
        Me.txtAdicionalPCE.TabIndex = 3
        Me.txtAdicionalPCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdicional
        '
        Me.txtAdicional.Location = New System.Drawing.Point(181, 55)
        Me.txtAdicional.MaxLength = 5
        Me.txtAdicional.Name = "txtAdicional"
        Me.txtAdicional.Size = New System.Drawing.Size(73, 20)
        Me.txtAdicional.TabIndex = 2
        Me.txtAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(416, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Adicional PCE"
        '
        'cboOperacion2
        '
        Me.cboOperacion2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOperacion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperacion2.FormattingEnabled = True
        Me.cboOperacion2.Items.AddRange(New Object() {" (SELECCIONE)", "INGRESO ALMACEN", "SALIDA ALMACEN", "ENTREGA"})
        Me.cboOperacion2.Location = New System.Drawing.Point(181, 21)
        Me.cboOperacion2.Name = "cboOperacion2"
        Me.cboOperacion2.Size = New System.Drawing.Size(186, 21)
        Me.cboOperacion2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Adicional"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Tipo Operación"
        '
        'dtpFechaActivacion
        '
        Me.dtpFechaActivacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion.Location = New System.Drawing.Point(517, 21)
        Me.dtpFechaActivacion.Name = "dtpFechaActivacion"
        Me.dtpFechaActivacion.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaActivacion.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(415, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Fecha Activacion"
        '
        'dgvObjetivo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvObjetivo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvObjetivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvObjetivo.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvObjetivo.Location = New System.Drawing.Point(78, 91)
        Me.dgvObjetivo.Name = "dgvObjetivo"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvObjetivo.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvObjetivo.Size = New System.Drawing.Size(590, 262)
        Me.dgvObjetivo.TabIndex = 36
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.INTEGRACION.My.Resources.Resources.IzquierdaTodos
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(480, 390)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.INTEGRACION.My.Resources.Resources.mp_toolbarGuardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(272, 390)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "&Grabar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmEntregaObjetivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 475)
        Me.Controls.Add(Me.tabObjetivoEntrega)
        Me.Name = "frmEntregaObjetivo"
        Me.Text = "Objetivo Entrega"
        Me.tabObjetivoEntrega.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        Me.tabLista.PerformLayout()
        Me.grbFiltro.ResumeLayout(False)
        Me.grbFiltro.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvObjetivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabObjetivoEntrega As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents grbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Protected WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents tsbAnular As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents tsbSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboOperacion2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaActivacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvObjetivo As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtAdicionalPCE As System.Windows.Forms.TextBox
    Friend WithEvents txtAdicional As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
