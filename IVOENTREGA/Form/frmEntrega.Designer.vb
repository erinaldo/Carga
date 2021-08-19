<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntrega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntrega))
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumeroDocumento = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.rbtConsignado = New System.Windows.Forms.RadioButton()
        Me.rbtCliente = New System.Windows.Forms.RadioButton()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dgvAlmacen = New System.Windows.Forms.DataGridView()
        Me.btnEntregar = New System.Windows.Forms.Button()
        Me.btnAtender = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnConsultaDocumento = New System.Windows.Forms.Button()
        Me.btnIncidencia = New System.Windows.Forms.Button()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(12, 104)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(930, 315)
        Me.dgvLista.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(951, 18)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(74, 39)
        Me.btnBuscar.TabIndex = 87
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Location = New System.Drawing.Point(77, 8)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(158, 21)
        Me.cboOrigen.TabIndex = 88
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Orígen"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(299, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Fecha Inicio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(541, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Fecha Fin"
        '
        'dtpFin
        '
        Me.dtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFin.CustomFormat = ""
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(614, 8)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(93, 20)
        Me.dtpFin.TabIndex = 92
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(387, 8)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(93, 20)
        Me.dtpInicio.TabIndex = 91
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Ruc/DNI"
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(78, 70)
        Me.txtNumeroDocumento.MaxLength = 11
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(142, 20)
        Me.txtNumeroDocumento.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(583, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Comprobante"
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(656, 70)
        Me.txtNumeroComprobante.MaxLength = 13
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(135, 20)
        Me.txtNumeroComprobante.TabIndex = 95
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Location = New System.Drawing.Point(229, 74)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 93
        Me.lblEstado.Text = "Estado"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.DropDownWidth = 175
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"(TODO)", "LLEGADA", "EN ATENCION", "DISPONIBLE", "ENTREGADO"})
        Me.cboEstado.Location = New System.Drawing.Point(276, 70)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(141, 21)
        Me.cboEstado.TabIndex = 94
        '
        'rbtConsignado
        '
        Me.rbtConsignado.AutoSize = True
        Me.rbtConsignado.Checked = True
        Me.rbtConsignado.Location = New System.Drawing.Point(78, 42)
        Me.rbtConsignado.Name = "rbtConsignado"
        Me.rbtConsignado.Size = New System.Drawing.Size(81, 17)
        Me.rbtConsignado.TabIndex = 98
        Me.rbtConsignado.TabStop = True
        Me.rbtConsignado.Text = "Consignado"
        Me.rbtConsignado.UseVisualStyleBackColor = True
        '
        'rbtCliente
        '
        Me.rbtCliente.AutoSize = True
        Me.rbtCliente.Location = New System.Drawing.Point(14, 42)
        Me.rbtCliente.Name = "rbtCliente"
        Me.rbtCliente.Size = New System.Drawing.Size(57, 17)
        Me.rbtCliente.TabIndex = 97
        Me.rbtCliente.Text = "Cliente"
        Me.rbtCliente.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.ForeColor = System.Drawing.Color.Black
        Me.txtBuscar.Location = New System.Drawing.Point(168, 40)
        Me.txtBuscar.MaxLength = 50
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(541, 20)
        Me.txtBuscar.TabIndex = 96
        '
        'dgvAlmacen
        '
        Me.dgvAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlmacen.Location = New System.Drawing.Point(12, 447)
        Me.dgvAlmacen.Name = "dgvAlmacen"
        Me.dgvAlmacen.Size = New System.Drawing.Size(932, 127)
        Me.dgvAlmacen.TabIndex = 99
        '
        'btnEntregar
        '
        Me.btnEntregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEntregar.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.btnEntregar.Location = New System.Drawing.Point(3, 151)
        Me.btnEntregar.Name = "btnEntregar"
        Me.btnEntregar.Size = New System.Drawing.Size(78, 31)
        Me.btnEntregar.TabIndex = 87
        Me.btnEntregar.Text = "Entregar"
        Me.btnEntregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEntregar.UseVisualStyleBackColor = True
        '
        'btnAtender
        '
        Me.btnAtender.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAtender.Image = Global.INTEGRACION.My.Resources.Resources.ocupado
        Me.btnAtender.Location = New System.Drawing.Point(4, 105)
        Me.btnAtender.Name = "btnAtender"
        Me.btnAtender.Size = New System.Drawing.Size(79, 31)
        Me.btnAtender.TabIndex = 87
        Me.btnAtender.Text = "Atender"
        Me.btnAtender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAtender.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnAnular)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnMostrar)
        Me.GroupBox1.Controls.Add(Me.btnAtender)
        Me.GroupBox1.Controls.Add(Me.btnConsultaDocumento)
        Me.GroupBox1.Controls.Add(Me.btnIncidencia)
        Me.GroupBox1.Controls.Add(Me.btnEntregar)
        Me.GroupBox1.Location = New System.Drawing.Point(948, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(86, 478)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        '
        'btnAnular
        '
        Me.btnAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnular.ForeColor = System.Drawing.Color.Black
        Me.btnAnular.Image = Global.INTEGRACION.My.Resources.Resources._1325
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(6, 384)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(75, 31)
        Me.btnAnular.TabIndex = 88
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(4, 439)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 31)
        Me.btnSalir.TabIndex = 88
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.Location = New System.Drawing.Point(4, 14)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(79, 31)
        Me.btnMostrar.TabIndex = 87
        Me.btnMostrar.Text = "Mostrar"
        Me.btnMostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnConsultaDocumento
        '
        Me.btnConsultaDocumento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultaDocumento.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnConsultaDocumento.Location = New System.Drawing.Point(3, 288)
        Me.btnConsultaDocumento.Name = "btnConsultaDocumento"
        Me.btnConsultaDocumento.Size = New System.Drawing.Size(80, 35)
        Me.btnConsultaDocumento.TabIndex = 87
        Me.btnConsultaDocumento.Text = "Consulta Doc."
        Me.btnConsultaDocumento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsultaDocumento.UseVisualStyleBackColor = True
        '
        'btnIncidencia
        '
        Me.btnIncidencia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncidencia.Image = Global.INTEGRACION.My.Resources.Resources.delete_161
        Me.btnIncidencia.Location = New System.Drawing.Point(3, 233)
        Me.btnIncidencia.Name = "btnIncidencia"
        Me.btnIncidencia.Size = New System.Drawing.Size(80, 31)
        Me.btnIncidencia.TabIndex = 87
        Me.btnIncidencia.Text = "Incidencia"
        Me.btnIncidencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncidencia.UseVisualStyleBackColor = True
        '
        'lblRegistros
        '
        Me.lblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(872, 72)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(70, 13)
        Me.lblRegistros.TabIndex = 102
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label53
        '
        Me.Label53.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(808, 72)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(66, 13)
        Me.Label53.TabIndex = 101
        Me.Label53.Text = "Nº Registros"
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"(TODO)", "FACTURA", "BOLETA"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(468, 69)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(109, 21)
        Me.cboTipoComprobante.TabIndex = 104
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(436, 72)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(28, 13)
        Me.Label27.TabIndex = 103
        Me.Label27.Text = "Tipo"
        '
        'frmEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 582)
        Me.Controls.Add(Me.cboTipoComprobante)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvAlmacen)
        Me.Controls.Add(Me.rbtConsignado)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.rbtCliente)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.txtNumeroComprobante)
        Me.Controls.Add(Me.txtNumeroDocumento)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.dtpFin)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboOrigen)
        Me.Controls.Add(Me.dgvLista)
        Me.Name = "frmEntrega"
        Me.Text = "Entrega de Carga"
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents rbtConsignado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCliente As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents dgvAlmacen As System.Windows.Forms.DataGridView
    Friend WithEvents btnEntregar As System.Windows.Forms.Button
    Friend WithEvents btnAtender As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnConsultaDocumento As System.Windows.Forms.Button
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents btnIncidencia As System.Windows.Forms.Button
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
