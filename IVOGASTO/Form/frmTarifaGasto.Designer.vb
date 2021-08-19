<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarifaGasto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTarifaGasto))
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabTarifaPago = New System.Windows.Forms.TabControl()
        Me.tabTarifa = New System.Windows.Forms.TabPage()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.cboTipoPago1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTipoTarifa1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCiudad1 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvTarifa = New System.Windows.Forms.DataGridView()
        Me.tabDetalle = New System.Windows.Forms.TabPage()
        Me.chkBono = New System.Windows.Forms.CheckBox()
        Me.dtpFechaActivacion = New System.Windows.Forms.DateTimePicker()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.cboTipoPago2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoTarifa2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCiudad2 = New System.Windows.Forms.ComboBox()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.tool.SuspendLayout()
        Me.tabTarifaPago.SuspendLayout()
        Me.tabTarifa.SuspendLayout()
        CType(Me.dgvTarifa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbAnular, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(806, 25)
        Me.tool.TabIndex = 8
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'tabTarifaPago
        '
        Me.tabTarifaPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTarifaPago.Controls.Add(Me.tabTarifa)
        Me.tabTarifaPago.Controls.Add(Me.tabDetalle)
        Me.tabTarifaPago.Location = New System.Drawing.Point(12, 28)
        Me.tabTarifaPago.Name = "tabTarifaPago"
        Me.tabTarifaPago.SelectedIndex = 0
        Me.tabTarifaPago.Size = New System.Drawing.Size(786, 544)
        Me.tabTarifaPago.TabIndex = 9
        '
        'tabTarifa
        '
        Me.tabTarifa.Controls.Add(Me.btnFiltrar)
        Me.tabTarifa.Controls.Add(Me.cboTipoPago1)
        Me.tabTarifa.Controls.Add(Me.Label6)
        Me.tabTarifa.Controls.Add(Me.cboTipoTarifa1)
        Me.tabTarifa.Controls.Add(Me.Label7)
        Me.tabTarifa.Controls.Add(Me.cboCiudad1)
        Me.tabTarifa.Controls.Add(Me.Label8)
        Me.tabTarifa.Controls.Add(Me.dgvTarifa)
        Me.tabTarifa.Location = New System.Drawing.Point(4, 22)
        Me.tabTarifa.Name = "tabTarifa"
        Me.tabTarifa.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTarifa.Size = New System.Drawing.Size(778, 518)
        Me.tabTarifa.TabIndex = 0
        Me.tabTarifa.Text = "Tarifa"
        Me.tabTarifa.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(695, 11)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(73, 31)
        Me.btnFiltrar.TabIndex = 3
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'cboTipoPago1
        '
        Me.cboTipoPago1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago1.FormattingEnabled = True
        Me.cboTipoPago1.Location = New System.Drawing.Point(492, 16)
        Me.cboTipoPago1.Name = "cboTipoPago1"
        Me.cboTipoPago1.Size = New System.Drawing.Size(115, 21)
        Me.cboTipoPago1.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(431, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Tipo Pago"
        '
        'cboTipoTarifa1
        '
        Me.cboTipoTarifa1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarifa1.FormattingEnabled = True
        Me.cboTipoTarifa1.Items.AddRange(New Object() {"(TODO)", "PUBLICO", "PRIVADO"})
        Me.cboTipoTarifa1.Location = New System.Drawing.Point(73, 16)
        Me.cboTipoTarifa1.Name = "cboTipoTarifa1"
        Me.cboTipoTarifa1.Size = New System.Drawing.Size(115, 21)
        Me.cboTipoTarifa1.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Tipo Tarifa"
        '
        'cboCiudad1
        '
        Me.cboCiudad1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudad1.FormattingEnabled = True
        Me.cboCiudad1.Location = New System.Drawing.Point(260, 16)
        Me.cboCiudad1.Name = "cboCiudad1"
        Me.cboCiudad1.Size = New System.Drawing.Size(148, 21)
        Me.cboCiudad1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(212, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Ciudad"
        '
        'dgvTarifa
        '
        Me.dgvTarifa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTarifa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTarifa.Location = New System.Drawing.Point(9, 56)
        Me.dgvTarifa.Name = "dgvTarifa"
        Me.dgvTarifa.Size = New System.Drawing.Size(759, 453)
        Me.dgvTarifa.TabIndex = 1
        '
        'tabDetalle
        '
        Me.tabDetalle.Controls.Add(Me.chkBono)
        Me.tabDetalle.Controls.Add(Me.dtpFechaActivacion)
        Me.tabDetalle.Controls.Add(Me.txtMonto)
        Me.tabDetalle.Controls.Add(Me.cboTipoPago2)
        Me.tabDetalle.Controls.Add(Me.Label3)
        Me.tabDetalle.Controls.Add(Me.cboTipoTarifa2)
        Me.tabDetalle.Controls.Add(Me.Label5)
        Me.tabDetalle.Controls.Add(Me.Label4)
        Me.tabDetalle.Controls.Add(Me.Label2)
        Me.tabDetalle.Controls.Add(Me.cboCiudad2)
        Me.tabDetalle.Controls.Add(Me.lblCiudad)
        Me.tabDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tabDetalle.Name = "tabDetalle"
        Me.tabDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetalle.Size = New System.Drawing.Size(778, 518)
        Me.tabDetalle.TabIndex = 1
        Me.tabDetalle.Text = "Detalle"
        Me.tabDetalle.UseVisualStyleBackColor = True
        '
        'chkBono
        '
        Me.chkBono.AutoSize = True
        Me.chkBono.Location = New System.Drawing.Point(516, 272)
        Me.chkBono.Name = "chkBono"
        Me.chkBono.Size = New System.Drawing.Size(51, 17)
        Me.chkBono.TabIndex = 4
        Me.chkBono.Text = "Bono"
        Me.chkBono.UseVisualStyleBackColor = True
        Me.chkBono.Visible = False
        '
        'dtpFechaActivacion
        '
        Me.dtpFechaActivacion.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaActivacion.CustomFormat = ""
        Me.dtpFechaActivacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion.Location = New System.Drawing.Point(659, 398)
        Me.dtpFechaActivacion.Name = "dtpFechaActivacion"
        Me.dtpFechaActivacion.Size = New System.Drawing.Size(89, 20)
        Me.dtpFechaActivacion.TabIndex = 3
        Me.dtpFechaActivacion.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(318, 273)
        Me.txtMonto.MaxLength = 8
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(120, 20)
        Me.txtMonto.TabIndex = 3
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTipoPago2
        '
        Me.cboTipoPago2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago2.FormattingEnabled = True
        Me.cboTipoPago2.Location = New System.Drawing.Point(318, 231)
        Me.cboTipoPago2.Name = "cboTipoPago2"
        Me.cboTipoPago2.Size = New System.Drawing.Size(249, 21)
        Me.cboTipoPago2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 238)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tipo Pago"
        '
        'cboTipoTarifa2
        '
        Me.cboTipoTarifa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarifa2.FormattingEnabled = True
        Me.cboTipoTarifa2.Items.AddRange(New Object() {"(SELECCIONE)", "PUBLICO", "PRIVADO"})
        Me.cboTipoTarifa2.Location = New System.Drawing.Point(318, 138)
        Me.cboTipoTarifa2.Name = "cboTipoTarifa2"
        Me.cboTipoTarifa2.Size = New System.Drawing.Size(249, 21)
        Me.cboTipoTarifa2.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(563, 398)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Activación"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(217, 277)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Monto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo Tarifa"
        '
        'cboCiudad2
        '
        Me.cboCiudad2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudad2.FormattingEnabled = True
        Me.cboCiudad2.Location = New System.Drawing.Point(318, 184)
        Me.cboCiudad2.Name = "cboCiudad2"
        Me.cboCiudad2.Size = New System.Drawing.Size(249, 21)
        Me.cboCiudad2.TabIndex = 1
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Location = New System.Drawing.Point(217, 187)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(40, 13)
        Me.lblCiudad.TabIndex = 0
        Me.lblCiudad.Text = "Ciudad"
        '
        'frmTarifaGasto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 578)
        Me.Controls.Add(Me.tabTarifaPago)
        Me.Controls.Add(Me.tool)
        Me.Name = "frmTarifaGasto"
        Me.Text = "Tarifa"
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.tabTarifaPago.ResumeLayout(False)
        Me.tabTarifa.ResumeLayout(False)
        Me.tabTarifa.PerformLayout()
        CType(Me.dgvTarifa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDetalle.ResumeLayout(False)
        Me.tabDetalle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabTarifaPago As System.Windows.Forms.TabControl
    Friend WithEvents tabTarifa As System.Windows.Forms.TabPage
    Friend WithEvents dgvTarifa As System.Windows.Forms.DataGridView
    Friend WithEvents tabDetalle As System.Windows.Forms.TabPage
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoPago2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoTarifa2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCiudad2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents dtpFechaActivacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPago1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTipoTarifa1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCiudad1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents chkBono As System.Windows.Forms.CheckBox
End Class
