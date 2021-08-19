<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsalidamovil
    Inherits INTEGRACION.FrmFormBase
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
        Me.components = New System.ComponentModel.Container
        Me.cmbagencia = New System.Windows.Forms.ComboBox
        Me.LabOrigen = New System.Windows.Forms.Label
        Me.DTPFechaSeleccion = New System.Windows.Forms.DateTimePicker
        Me.labfecsalidaprin = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.MenuEstado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RepartoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerradoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.AnuladoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.txtidnrosalida = New System.Windows.Forms.TextBox
        Me.Labnrosalida = New System.Windows.Forms.Label
        Me.cmbmovil = New System.Windows.Forms.ComboBox
        Me.labbus = New System.Windows.Forms.Label
        Me.txthorasalida = New System.Windows.Forms.TextBox
        Me.dtpfec_salida = New System.Windows.Forms.DateTimePicker
        Me.labfecha = New System.Windows.Forms.Label
        Me.labhora = New System.Windows.Forms.Label
        Me.cmbestado = New System.Windows.Forms.ComboBox
        Me.LabEstado = New System.Windows.Forms.Label
        Me.LabChofer = New System.Windows.Forms.Label
        Me.cmbchoferusuario = New System.Windows.Forms.ComboBox
        Me.GBSalidaBus = New System.Windows.Forms.GroupBox
        Me.Btnmovil = New System.Windows.Forms.Button
        Me.btnestado = New System.Windows.Forms.Button
        Me.btnchoferusuario = New System.Windows.Forms.Button
        Me.gpbdatosadicional = New System.Windows.Forms.GroupBox
        Me.txtplacabus = New System.Windows.Forms.TextBox
        Me.txtmarcabus = New System.Windows.Forms.TextBox
        Me.txtlicencia = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.trefresco = New System.Windows.Forms.Timer(Me.components)
        Me.btnrefrescar = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuEstado.SuspendLayout()
        Me.GBSalidaBus.SuspendLayout()
        Me.gpbdatosadicional.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Panel1Collapsed = True
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Size = New System.Drawing.Size(771, 520)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(766, 515)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.btnrefrescar)
        Me.TabLista.Controls.Add(Me.DataGridView1)
        Me.TabLista.Controls.Add(Me.cmbagencia)
        Me.TabLista.Controls.Add(Me.LabOrigen)
        Me.TabLista.Controls.Add(Me.labfecsalidaprin)
        Me.TabLista.Controls.Add(Me.DTPFechaSeleccion)
        Me.TabLista.Size = New System.Drawing.Size(758, 486)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DTPFechaSeleccion, 0)
        Me.TabLista.Controls.SetChildIndex(Me.labfecsalidaprin, 0)
        Me.TabLista.Controls.SetChildIndex(Me.LabOrigen, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbagencia, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnrefrescar, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.gpbdatosadicional)
        Me.TabDatos.Controls.Add(Me.labhora)
        Me.TabDatos.Controls.Add(Me.labfecha)
        Me.TabDatos.Controls.Add(Me.dtpfec_salida)
        Me.TabDatos.Controls.Add(Me.cmbmovil)
        Me.TabDatos.Controls.Add(Me.labbus)
        Me.TabDatos.Controls.Add(Me.GBSalidaBus)
        Me.TabDatos.Size = New System.Drawing.Size(758, 486)
        Me.TabDatos.Controls.SetChildIndex(Me.GBSalidaBus, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.labbus, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.cmbmovil, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtMensaje, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.dtpfec_salida, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.labfecha, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.labhora, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.gpbdatosadicional, 0)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridLista.Location = New System.Drawing.Point(360, 182)
        '
        'TxtBusca
        '
        Me.TxtBusca.Enabled = False
        Me.TxtBusca.Location = New System.Drawing.Point(422, 144)
        Me.TxtBusca.Size = New System.Drawing.Size(26, 20)
        Me.TxtBusca.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(758, 486)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(758, 486)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'TxtMensaje
        '
        Me.TxtMensaje.Location = New System.Drawing.Point(651, 13)
        '
        'cmbagencia
        '
        Me.cmbagencia.FormattingEnabled = True
        Me.cmbagencia.Location = New System.Drawing.Point(79, 30)
        Me.cmbagencia.Name = "cmbagencia"
        Me.cmbagencia.Size = New System.Drawing.Size(154, 21)
        Me.cmbagencia.TabIndex = 2
        '
        'LabOrigen
        '
        Me.LabOrigen.AutoSize = True
        Me.LabOrigen.BackColor = System.Drawing.Color.Transparent
        Me.LabOrigen.Location = New System.Drawing.Point(18, 33)
        Me.LabOrigen.Name = "LabOrigen"
        Me.LabOrigen.Size = New System.Drawing.Size(55, 13)
        Me.LabOrigen.TabIndex = 3
        Me.LabOrigen.Text = "Agencia : "
        '
        'DTPFechaSeleccion
        '
        Me.DTPFechaSeleccion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaSeleccion.Location = New System.Drawing.Point(426, 29)
        Me.DTPFechaSeleccion.Name = "DTPFechaSeleccion"
        Me.DTPFechaSeleccion.Size = New System.Drawing.Size(93, 20)
        Me.DTPFechaSeleccion.TabIndex = 4
        '
        'labfecsalidaprin
        '
        Me.labfecsalidaprin.AutoSize = True
        Me.labfecsalidaprin.BackColor = System.Drawing.Color.Transparent
        Me.labfecsalidaprin.Location = New System.Drawing.Point(342, 33)
        Me.labfecsalidaprin.Name = "labfecsalidaprin"
        Me.labfecsalidaprin.Size = New System.Drawing.Size(78, 13)
        Me.labfecsalidaprin.TabIndex = 5
        Me.labfecsalidaprin.Text = "Fecha Salida : "
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.MenuEstado
        Me.DataGridView1.Location = New System.Drawing.Point(6, 68)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(744, 410)
        Me.DataGridView1.TabIndex = 6
        '
        'MenuEstado
        '
        Me.MenuEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreadoToolStripMenuItem, Me.ActivoToolStripMenuItem, Me.RepartoToolStripMenuItem, Me.CerradoToolStripMenuItem, Me.ToolStripSeparator1, Me.AnuladoToolStripMenuItem})
        Me.MenuEstado.Name = "MenuEstado"
        Me.MenuEstado.Size = New System.Drawing.Size(125, 120)
        '
        'CreadoToolStripMenuItem
        '
        Me.CreadoToolStripMenuItem.Enabled = False
        Me.CreadoToolStripMenuItem.Name = "CreadoToolStripMenuItem"
        Me.CreadoToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.CreadoToolStripMenuItem.Text = "Creado"
        Me.CreadoToolStripMenuItem.Visible = False
        '
        'ActivoToolStripMenuItem
        '
        Me.ActivoToolStripMenuItem.Name = "ActivoToolStripMenuItem"
        Me.ActivoToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ActivoToolStripMenuItem.Text = "Activo"
        '
        'RepartoToolStripMenuItem
        '
        Me.RepartoToolStripMenuItem.Name = "RepartoToolStripMenuItem"
        Me.RepartoToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.RepartoToolStripMenuItem.Text = "Reparto"
        '
        'CerradoToolStripMenuItem
        '
        Me.CerradoToolStripMenuItem.Name = "CerradoToolStripMenuItem"
        Me.CerradoToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.CerradoToolStripMenuItem.Text = "Cerrado"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(121, 6)
        '
        'AnuladoToolStripMenuItem
        '
        Me.AnuladoToolStripMenuItem.Name = "AnuladoToolStripMenuItem"
        Me.AnuladoToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.AnuladoToolStripMenuItem.Text = "Anulado"
        '
        'txtidnrosalida
        '
        Me.txtidnrosalida.BackColor = System.Drawing.SystemColors.Info
        Me.txtidnrosalida.Location = New System.Drawing.Point(96, 18)
        Me.txtidnrosalida.Name = "txtidnrosalida"
        Me.txtidnrosalida.ReadOnly = True
        Me.txtidnrosalida.Size = New System.Drawing.Size(91, 20)
        Me.txtidnrosalida.TabIndex = 3
        '
        'Labnrosalida
        '
        Me.Labnrosalida.AutoSize = True
        Me.Labnrosalida.BackColor = System.Drawing.Color.Transparent
        Me.Labnrosalida.Location = New System.Drawing.Point(15, 22)
        Me.Labnrosalida.Name = "Labnrosalida"
        Me.Labnrosalida.Size = New System.Drawing.Size(62, 13)
        Me.Labnrosalida.TabIndex = 4
        Me.Labnrosalida.Text = "Nro Salida :"
        '
        'cmbmovil
        '
        Me.cmbmovil.FormattingEnabled = True
        Me.cmbmovil.Location = New System.Drawing.Point(114, 101)
        Me.cmbmovil.Name = "cmbmovil"
        Me.cmbmovil.Size = New System.Drawing.Size(219, 21)
        Me.cmbmovil.TabIndex = 5
        '
        'labbus
        '
        Me.labbus.AutoSize = True
        Me.labbus.BackColor = System.Drawing.Color.Transparent
        Me.labbus.Location = New System.Drawing.Point(30, 105)
        Me.labbus.Name = "labbus"
        Me.labbus.Size = New System.Drawing.Size(38, 13)
        Me.labbus.TabIndex = 6
        Me.labbus.Text = "Móvil :"
        '
        'txthorasalida
        '
        Me.txthorasalida.Location = New System.Drawing.Point(424, 41)
        Me.txthorasalida.MaxLength = 5
        Me.txthorasalida.Name = "txthorasalida"
        Me.txthorasalida.Size = New System.Drawing.Size(91, 20)
        Me.txthorasalida.TabIndex = 10
        '
        'dtpfec_salida
        '
        Me.dtpfec_salida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfec_salida.Location = New System.Drawing.Point(114, 75)
        Me.dtpfec_salida.Name = "dtpfec_salida"
        Me.dtpfec_salida.Size = New System.Drawing.Size(91, 20)
        Me.dtpfec_salida.TabIndex = 11
        '
        'labfecha
        '
        Me.labfecha.AutoSize = True
        Me.labfecha.BackColor = System.Drawing.Color.Transparent
        Me.labfecha.Location = New System.Drawing.Point(30, 79)
        Me.labfecha.Name = "labfecha"
        Me.labfecha.Size = New System.Drawing.Size(78, 13)
        Me.labfecha.TabIndex = 12
        Me.labfecha.Text = "Fecha Salida : "
        '
        'labhora
        '
        Me.labhora.AutoSize = True
        Me.labhora.BackColor = System.Drawing.Color.Transparent
        Me.labhora.Location = New System.Drawing.Point(372, 79)
        Me.labhora.Name = "labhora"
        Me.labhora.Size = New System.Drawing.Size(39, 13)
        Me.labhora.TabIndex = 13
        Me.labhora.Text = "Hora : "
        '
        'cmbestado
        '
        Me.cmbestado.BackColor = System.Drawing.SystemColors.Info
        Me.cmbestado.Enabled = False
        Me.cmbestado.FormattingEnabled = True
        Me.cmbestado.Location = New System.Drawing.Point(424, 93)
        Me.cmbestado.Name = "cmbestado"
        Me.cmbestado.Size = New System.Drawing.Size(121, 21)
        Me.cmbestado.TabIndex = 14
        '
        'LabEstado
        '
        Me.LabEstado.AutoSize = True
        Me.LabEstado.BackColor = System.Drawing.Color.Transparent
        Me.LabEstado.Location = New System.Drawing.Point(352, 96)
        Me.LabEstado.Name = "LabEstado"
        Me.LabEstado.Size = New System.Drawing.Size(49, 13)
        Me.LabEstado.TabIndex = 15
        Me.LabEstado.Text = "Estado : "
        '
        'LabChofer
        '
        Me.LabChofer.AutoSize = True
        Me.LabChofer.BackColor = System.Drawing.Color.Transparent
        Me.LabChofer.Location = New System.Drawing.Point(351, 71)
        Me.LabChofer.Name = "LabChofer"
        Me.LabChofer.Size = New System.Drawing.Size(68, 13)
        Me.LabChofer.TabIndex = 16
        Me.LabChofer.Text = "Conductor  : "
        '
        'cmbchoferusuario
        '
        Me.cmbchoferusuario.FormattingEnabled = True
        Me.cmbchoferusuario.Location = New System.Drawing.Point(424, 67)
        Me.cmbchoferusuario.Name = "cmbchoferusuario"
        Me.cmbchoferusuario.Size = New System.Drawing.Size(275, 21)
        Me.cmbchoferusuario.TabIndex = 17
        '
        'GBSalidaBus
        '
        Me.GBSalidaBus.BackColor = System.Drawing.Color.Transparent
        Me.GBSalidaBus.Controls.Add(Me.Btnmovil)
        Me.GBSalidaBus.Controls.Add(Me.btnestado)
        Me.GBSalidaBus.Controls.Add(Me.btnchoferusuario)
        Me.GBSalidaBus.Controls.Add(Me.LabEstado)
        Me.GBSalidaBus.Controls.Add(Me.txthorasalida)
        Me.GBSalidaBus.Controls.Add(Me.cmbestado)
        Me.GBSalidaBus.Controls.Add(Me.cmbchoferusuario)
        Me.GBSalidaBus.Controls.Add(Me.LabChofer)
        Me.GBSalidaBus.Controls.Add(Me.Labnrosalida)
        Me.GBSalidaBus.Controls.Add(Me.txtidnrosalida)
        Me.GBSalidaBus.Location = New System.Drawing.Point(18, 32)
        Me.GBSalidaBus.Name = "GBSalidaBus"
        Me.GBSalidaBus.Size = New System.Drawing.Size(732, 123)
        Me.GBSalidaBus.TabIndex = 20
        Me.GBSalidaBus.TabStop = False
        Me.GBSalidaBus.Text = "Salida del Móvil"
        '
        'Btnmovil
        '
        Me.Btnmovil.Enabled = False
        Me.Btnmovil.Location = New System.Drawing.Point(321, 69)
        Me.Btnmovil.Name = "Btnmovil"
        Me.Btnmovil.Size = New System.Drawing.Size(21, 21)
        Me.Btnmovil.TabIndex = 24
        Me.Btnmovil.Text = "Bus"
        Me.Btnmovil.UseVisualStyleBackColor = True
        Me.Btnmovil.Visible = False
        '
        'btnestado
        '
        Me.btnestado.Enabled = False
        Me.btnestado.Location = New System.Drawing.Point(551, 92)
        Me.btnestado.Name = "btnestado"
        Me.btnestado.Size = New System.Drawing.Size(21, 21)
        Me.btnestado.TabIndex = 23
        Me.btnestado.Text = "Button3"
        Me.btnestado.UseVisualStyleBackColor = True
        Me.btnestado.Visible = False
        '
        'btnchoferusuario
        '
        Me.btnchoferusuario.Enabled = False
        Me.btnchoferusuario.Location = New System.Drawing.Point(705, 65)
        Me.btnchoferusuario.Name = "btnchoferusuario"
        Me.btnchoferusuario.Size = New System.Drawing.Size(21, 21)
        Me.btnchoferusuario.TabIndex = 22
        Me.btnchoferusuario.Text = "Button2"
        Me.btnchoferusuario.UseVisualStyleBackColor = True
        Me.btnchoferusuario.Visible = False
        '
        'gpbdatosadicional
        '
        Me.gpbdatosadicional.BackColor = System.Drawing.Color.Transparent
        Me.gpbdatosadicional.Controls.Add(Me.txtplacabus)
        Me.gpbdatosadicional.Controls.Add(Me.txtmarcabus)
        Me.gpbdatosadicional.Controls.Add(Me.txtlicencia)
        Me.gpbdatosadicional.Controls.Add(Me.Label8)
        Me.gpbdatosadicional.Controls.Add(Me.Label7)
        Me.gpbdatosadicional.Controls.Add(Me.Label5)
        Me.gpbdatosadicional.Location = New System.Drawing.Point(18, 160)
        Me.gpbdatosadicional.Name = "gpbdatosadicional"
        Me.gpbdatosadicional.Size = New System.Drawing.Size(732, 83)
        Me.gpbdatosadicional.TabIndex = 24
        Me.gpbdatosadicional.TabStop = False
        Me.gpbdatosadicional.Text = "Datos adicionales"
        '
        'txtplacabus
        '
        Me.txtplacabus.BackColor = System.Drawing.SystemColors.Info
        Me.txtplacabus.Location = New System.Drawing.Point(411, 47)
        Me.txtplacabus.Name = "txtplacabus"
        Me.txtplacabus.ReadOnly = True
        Me.txtplacabus.Size = New System.Drawing.Size(91, 20)
        Me.txtplacabus.TabIndex = 108
        '
        'txtmarcabus
        '
        Me.txtmarcabus.BackColor = System.Drawing.SystemColors.Info
        Me.txtmarcabus.Location = New System.Drawing.Point(88, 47)
        Me.txtmarcabus.Name = "txtmarcabus"
        Me.txtmarcabus.ReadOnly = True
        Me.txtmarcabus.Size = New System.Drawing.Size(244, 20)
        Me.txtmarcabus.TabIndex = 107
        '
        'txtlicencia
        '
        Me.txtlicencia.BackColor = System.Drawing.SystemColors.Info
        Me.txtlicencia.Location = New System.Drawing.Point(88, 17)
        Me.txtlicencia.Name = "txtlicencia"
        Me.txtlicencia.ReadOnly = True
        Me.txtlicencia.Size = New System.Drawing.Size(91, 20)
        Me.txtlicencia.TabIndex = 106
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(6, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Marca Bus :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(354, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Placa  :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(6, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "Licencia :"
        '
        'trefresco
        '
        Me.trefresco.Interval = 300000
        '
        'btnrefrescar
        '
        Me.btnrefrescar.Location = New System.Drawing.Point(675, 28)
        Me.btnrefrescar.Name = "btnrefrescar"
        Me.btnrefrescar.Size = New System.Drawing.Size(75, 23)
        Me.btnrefrescar.TabIndex = 7
        Me.btnrefrescar.Text = "&Refrescar"
        Me.btnrefrescar.UseVisualStyleBackColor = True
        '
        'frmsalidamovil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "frmsalidamovil"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuEstado.ResumeLayout(False)
        Me.GBSalidaBus.ResumeLayout(False)
        Me.GBSalidaBus.PerformLayout()
        Me.gpbdatosadicional.ResumeLayout(False)
        Me.gpbdatosadicional.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbagencia As System.Windows.Forms.ComboBox
    Friend WithEvents LabOrigen As System.Windows.Forms.Label
    Friend WithEvents labfecsalidaprin As System.Windows.Forms.Label
    Friend WithEvents DTPFechaSeleccion As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtidnrosalida As System.Windows.Forms.TextBox
    Friend WithEvents Labnrosalida As System.Windows.Forms.Label
    Friend WithEvents cmbmovil As System.Windows.Forms.ComboBox
    Friend WithEvents labbus As System.Windows.Forms.Label
    Friend WithEvents LabEstado As System.Windows.Forms.Label
    Friend WithEvents cmbestado As System.Windows.Forms.ComboBox
    Friend WithEvents labhora As System.Windows.Forms.Label
    Friend WithEvents labfecha As System.Windows.Forms.Label
    Friend WithEvents dtpfec_salida As System.Windows.Forms.DateTimePicker
    Friend WithEvents txthorasalida As System.Windows.Forms.TextBox
    Friend WithEvents cmbchoferusuario As System.Windows.Forms.ComboBox
    Friend WithEvents LabChofer As System.Windows.Forms.Label
    Friend WithEvents GBSalidaBus As System.Windows.Forms.GroupBox
    Friend WithEvents gpbdatosadicional As System.Windows.Forms.GroupBox
    Friend WithEvents txtlicencia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtplacabus As System.Windows.Forms.TextBox
    Friend WithEvents txtmarcabus As System.Windows.Forms.TextBox
    Friend WithEvents Btnmovil As System.Windows.Forms.Button
    Friend WithEvents btnestado As System.Windows.Forms.Button
    Friend WithEvents btnchoferusuario As System.Windows.Forms.Button
    Friend WithEvents MenuEstado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CreadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerradoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AnuladoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RepartoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents trefresco As System.Windows.Forms.Timer
    Friend WithEvents btnrefrescar As System.Windows.Forms.Button

End Class
