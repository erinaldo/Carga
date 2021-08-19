<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnvioCarga
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
        Me.components = New System.ComponentModel.Container()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.cboFuncionario = New System.Windows.Forms.ComboBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSegmento = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEnvios = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmsOpcion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExpandirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColapsarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExpandirNodoSeleccionadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColapsarNodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tree = New WinControls.ListView.TreeListView()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboTipoEntrega = New System.Windows.Forms.ComboBox()
        Me.cboAgenciaOrigen = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboAgenciaDestino = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.cmsOpcion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(522, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Destino"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(272, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Origen"
        '
        'cboDestino
        '
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(586, 8)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(183, 21)
        Me.cboDestino.TabIndex = 7
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Location = New System.Drawing.Point(331, 8)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(183, 21)
        Me.cboOrigen.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Producto"
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(85, 40)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(183, 21)
        Me.cboProducto.TabIndex = 9
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(189, 75)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(79, 20)
        Me.dtpFechaFin.TabIndex = 13
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(85, 75)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(79, 20)
        Me.dtpFechaInicio.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(167, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Fin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Fecha Ini"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnExportar)
        Me.Panel2.Controls.Add(Me.BtnFiltrar)
        Me.Panel2.Location = New System.Drawing.Point(844, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(84, 70)
        Me.Panel2.TabIndex = 195
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(3, 35)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(77, 29)
        Me.btnExportar.TabIndex = 14
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltrar.Location = New System.Drawing.Point(3, 0)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(77, 29)
        Me.BtnFiltrar.TabIndex = 13
        Me.BtnFiltrar.Text = "Filtrar"
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 197
        Me.Label1.Text = "Estado Carga"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(85, 8)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(183, 21)
        Me.cboEstado.TabIndex = 196
        '
        'cboFuncionario
        '
        Me.cboFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFuncionario.FormattingEnabled = True
        Me.cboFuncionario.Location = New System.Drawing.Point(85, 108)
        Me.cboFuncionario.Name = "cboFuncionario"
        Me.cboFuncionario.Size = New System.Drawing.Size(183, 21)
        Me.cboFuncionario.TabIndex = 201
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCliente.Location = New System.Drawing.Point(586, 108)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(93, 20)
        Me.txtCodigoCliente.TabIndex = 202
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Location = New System.Drawing.Point(679, 108)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(246, 20)
        Me.txtCliente.TabIndex = 203
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 199
        Me.Label12.Text = "Funcionario"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(522, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 200
        Me.Label8.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(272, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Segmento"
        '
        'cboSegmento
        '
        Me.cboSegmento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmento.FormattingEnabled = True
        Me.cboSegmento.Location = New System.Drawing.Point(331, 108)
        Me.cboSegmento.Name = "cboSegmento"
        Me.cboSegmento.Size = New System.Drawing.Size(183, 21)
        Me.cboSegmento.TabIndex = 201
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lblEnvios)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblPeso)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(14, 540)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1314, 27)
        Me.Panel1.TabIndex = 210
        '
        'lblEnvios
        '
        Me.lblEnvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnvios.Location = New System.Drawing.Point(733, 6)
        Me.lblEnvios.Name = "lblEnvios"
        Me.lblEnvios.Size = New System.Drawing.Size(69, 13)
        Me.lblEnvios.TabIndex = 200
        Me.lblEnvios.Text = "0"
        Me.lblEnvios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(676, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 200
        Me.Label9.Text = "Envíos"
        '
        'lblPeso
        '
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.Location = New System.Drawing.Point(459, 6)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(106, 13)
        Me.lblPeso.TabIndex = 200
        Me.lblPeso.Text = "0.00"
        Me.lblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(409, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 200
        Me.Label7.Text = "Peso"
        '
        'cmsOpcion
        '
        Me.cmsOpcion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExpandirToolStripMenuItem, Me.ColapsarToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExpandirNodoSeleccionadoToolStripMenuItem, Me.ColapsarNodoToolStripMenuItem})
        Me.cmsOpcion.Name = "cmsOpcion"
        Me.cmsOpcion.Size = New System.Drawing.Size(178, 98)
        '
        'ExpandirToolStripMenuItem
        '
        Me.ExpandirToolStripMenuItem.Name = "ExpandirToolStripMenuItem"
        Me.ExpandirToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ExpandirToolStripMenuItem.Text = "Expandir"
        '
        'ColapsarToolStripMenuItem
        '
        Me.ColapsarToolStripMenuItem.Name = "ColapsarToolStripMenuItem"
        Me.ColapsarToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ColapsarToolStripMenuItem.Text = "Colapsar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(174, 6)
        '
        'ExpandirNodoSeleccionadoToolStripMenuItem
        '
        Me.ExpandirNodoSeleccionadoToolStripMenuItem.Name = "ExpandirNodoSeleccionadoToolStripMenuItem"
        Me.ExpandirNodoSeleccionadoToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ExpandirNodoSeleccionadoToolStripMenuItem.Text = "Expandir este Nodo"
        '
        'ColapsarNodoToolStripMenuItem
        '
        Me.ColapsarNodoToolStripMenuItem.Name = "ColapsarNodoToolStripMenuItem"
        Me.ColapsarNodoToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ColapsarNodoToolStripMenuItem.Text = "Colapsar este Nodo"
        '
        'tree
        '
        Me.tree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tree.ColumnTracking = True
        Me.tree.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(2, Byte))
        Me.tree.GridLines = WinControls.ListView.ContainerListView.GridLineSelections.Both
        Me.tree.Location = New System.Drawing.Point(12, 144)
        Me.tree.MultiSelect = True
        Me.tree.Name = "tree"
        Me.tree.Padding = New System.Windows.Forms.Padding(0, 0, 100, 0)
        Me.tree.Size = New System.Drawing.Size(1006, 378)
        Me.tree.TabIndex = 209
        '
        'lblGrupo
        '
        Me.lblGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupo.ForeColor = System.Drawing.Color.Red
        Me.lblGrupo.Location = New System.Drawing.Point(12, 526)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(1006, 15)
        Me.lblGrupo.TabIndex = 211
        Me.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Column2"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Column3"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(272, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Entrega"
        '
        'cboTipoEntrega
        '
        Me.cboTipoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEntrega.FormattingEnabled = True
        Me.cboTipoEntrega.Items.AddRange(New Object() {"(TODO)", "AGENCIA", "DOMICILIO"})
        Me.cboTipoEntrega.Location = New System.Drawing.Point(331, 75)
        Me.cboTipoEntrega.Name = "cboTipoEntrega"
        Me.cboTipoEntrega.Size = New System.Drawing.Size(183, 21)
        Me.cboTipoEntrega.TabIndex = 7
        '
        'cboAgenciaOrigen
        '
        Me.cboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgenciaOrigen.FormattingEnabled = True
        Me.cboAgenciaOrigen.Location = New System.Drawing.Point(331, 40)
        Me.cboAgenciaOrigen.Name = "cboAgenciaOrigen"
        Me.cboAgenciaOrigen.Size = New System.Drawing.Size(183, 21)
        Me.cboAgenciaOrigen.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(272, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Ag. Origen"
        '
        'cboAgenciaDestino
        '
        Me.cboAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgenciaDestino.FormattingEnabled = True
        Me.cboAgenciaDestino.Location = New System.Drawing.Point(586, 42)
        Me.cboAgenciaDestino.Name = "cboAgenciaDestino"
        Me.cboAgenciaDestino.Size = New System.Drawing.Size(183, 21)
        Me.cboAgenciaDestino.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(522, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Ag. Destino"
        '
        'frmEnvioCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 573)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tree)
        Me.Controls.Add(Me.cboSegmento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFuncionario)
        Me.Controls.Add(Me.txtCodigoCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboProducto)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboDestino)
        Me.Controls.Add(Me.cboOrigen)
        Me.Controls.Add(Me.cboAgenciaOrigen)
        Me.Controls.Add(Me.cboAgenciaDestino)
        Me.Controls.Add(Me.cboTipoEntrega)
        Me.Name = "frmEnvioCarga"
        Me.Text = "Tablero de Control"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.cmsOpcion.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    'Friend WithEvents FloatComboBox1 As CommonTools.FloatComboBox
    Friend WithEvents cboFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSegmento As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEnvios As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmsOpcion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExpandirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColapsarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpandirNodoSeleccionadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColapsarNodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tree As WinControls.ListView.TreeListView
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTipoEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents cboAgenciaOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboAgenciaDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
