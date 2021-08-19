<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmarEntregas
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
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtConsignado = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtEntregado = New System.Windows.Forms.TextBox()
        Me.txtDNIEntrega = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtHoraEntrega = New System.Windows.Forms.DateTimePicker()
        Me.txtNroDocumento = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtFecha_Entrega = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbTipoComprobante = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.CboConsignado = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFecha_Doc = New System.Windows.Forms.MaskedTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtObsNoAtencion = New System.Windows.Forms.TextBox()
        Me.ChkAtendido = New System.Windows.Forms.CheckBox()
        Me.cmbTipoNoAtencion = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btnAceptar.Location = New System.Drawing.Point(335, 265)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(106, 26)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "(F5) &Grabar "
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Maroon
        Me.btnSalir.Location = New System.Drawing.Point(588, 265)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(106, 26)
        Me.btnSalir.TabIndex = 57
        Me.btnSalir.Text = "(F12) &Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Maroon
        Me.btnAgregar.Location = New System.Drawing.Point(460, 265)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(106, 26)
        Me.btnAgregar.TabIndex = 57
        Me.btnAgregar.Text = "(F2) &Editar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(91, 19)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(349, 20)
        Me.txtCliente.TabIndex = 1
        '
        'txtConsignado
        '
        Me.txtConsignado.BackColor = System.Drawing.SystemColors.Info
        Me.txtConsignado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsignado.Location = New System.Drawing.Point(91, 41)
        Me.txtConsignado.Name = "txtConsignado"
        Me.txtConsignado.Size = New System.Drawing.Size(349, 20)
        Me.txtConsignado.TabIndex = 3
        '
        'txtDireccion
        '
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Location = New System.Drawing.Point(91, 106)
        Me.txtDireccion.MaxLength = 200
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(601, 20)
        Me.txtDireccion.TabIndex = 7
        '
        'txtEntregado
        '
        Me.txtEntregado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntregado.Location = New System.Drawing.Point(91, 133)
        Me.txtEntregado.MaxLength = 100
        Me.txtEntregado.Name = "txtEntregado"
        Me.txtEntregado.Size = New System.Drawing.Size(329, 20)
        Me.txtEntregado.TabIndex = 1
        Me.txtEntregado.Visible = False
        '
        'txtDNIEntrega
        '
        Me.txtDNIEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDNIEntrega.Enabled = False
        Me.txtDNIEntrega.Location = New System.Drawing.Point(91, 160)
        Me.txtDNIEntrega.MaxLength = 15
        Me.txtDNIEntrega.Name = "txtDNIEntrega"
        Me.txtDNIEntrega.Size = New System.Drawing.Size(123, 20)
        Me.txtDNIEntrega.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(454, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Origen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(453, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Destino"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(248, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Fecha Documento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(453, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "NroDoc"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Cliente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Consignado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Direccion (F3)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Entregado a:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "DNI (F6)"
        '
        'dtHoraEntrega
        '
        Me.dtHoraEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtHoraEntrega.Location = New System.Drawing.Point(584, 160)
        Me.dtHoraEntrega.Name = "dtHoraEntrega"
        Me.dtHoraEntrega.ShowUpDown = True
        Me.dtHoraEntrega.Size = New System.Drawing.Size(106, 20)
        Me.dtHoraEntrega.TabIndex = 11
        '
        'txtNroDocumento
        '
        Me.txtNroDocumento.BackColor = System.Drawing.SystemColors.Info
        Me.txtNroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroDocumento.Location = New System.Drawing.Point(510, 18)
        Me.txtNroDocumento.Name = "txtNroDocumento"
        Me.txtNroDocumento.Size = New System.Drawing.Size(182, 20)
        Me.txtNroDocumento.TabIndex = 2
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.SystemColors.Info
        Me.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrigen.Location = New System.Drawing.Point(510, 40)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(182, 20)
        Me.txtOrigen.TabIndex = 4
        '
        'txtDestino
        '
        Me.txtDestino.BackColor = System.Drawing.SystemColors.Info
        Me.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestino.Location = New System.Drawing.Point(510, 63)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(182, 20)
        Me.txtDestino.TabIndex = 6
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstado.Location = New System.Drawing.Point(510, 133)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(182, 20)
        Me.txtEstado.TabIndex = 3
        '
        'txtFecha_Entrega
        '
        Me.txtFecha_Entrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha_Entrega.Location = New System.Drawing.Point(365, 160)
        Me.txtFecha_Entrega.Mask = "00/00/0000"
        Me.txtFecha_Entrega.Name = "txtFecha_Entrega"
        Me.txtFecha_Entrega.Size = New System.Drawing.Size(81, 20)
        Me.txtFecha_Entrega.TabIndex = 10
        Me.txtFecha_Entrega.ValidatingType = GetType(Date)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(451, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Estado"
        '
        'lbTipoComprobante
        '
        Me.lbTipoComprobante.AutoSize = True
        Me.lbTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipoComprobante.ForeColor = System.Drawing.Color.Maroon
        Me.lbTipoComprobante.Location = New System.Drawing.Point(25, 73)
        Me.lbTipoComprobante.Name = "lbTipoComprobante"
        Me.lbTipoComprobante.Size = New System.Drawing.Size(201, 24)
        Me.lbTipoComprobante.TabIndex = 6
        Me.lbTipoComprobante.Text = "BOLETA DE VENTA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Controls.Add(Me.CboConsignado)
        Me.GroupBox1.Controls.Add(Me.lbTipoComprobante)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtFecha_Doc)
        Me.GroupBox1.Controls.Add(Me.txtFecha_Entrega)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.txtDestino)
        Me.GroupBox1.Controls.Add(Me.txtOrigen)
        Me.GroupBox1.Controls.Add(Me.txtNroDocumento)
        Me.GroupBox1.Controls.Add(Me.dtHoraEntrega)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDNIEntrega)
        Me.GroupBox1.Controls.Add(Me.txtEntregado)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.txtConsignado)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(698, 192)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.Image = Global.INTEGRACION.My.Resources.Resources._001
        Me.BtnNuevo.Location = New System.Drawing.Point(423, 132)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(23, 21)
        Me.BtnNuevo.TabIndex = 279
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'CboConsignado
        '
        Me.CboConsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboConsignado.Enabled = False
        Me.CboConsignado.FormattingEnabled = True
        Me.CboConsignado.Location = New System.Drawing.Point(91, 132)
        Me.CboConsignado.Name = "CboConsignado"
        Me.CboConsignado.Size = New System.Drawing.Size(329, 21)
        Me.CboConsignado.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(451, 166)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Hora [ F8 ]"
        '
        'txtFecha_Doc
        '
        Me.txtFecha_Doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha_Doc.Location = New System.Drawing.Point(365, 65)
        Me.txtFecha_Doc.Mask = "00/00/0000"
        Me.txtFecha_Doc.Name = "txtFecha_Doc"
        Me.txtFecha_Doc.Size = New System.Drawing.Size(75, 20)
        Me.txtFecha_Doc.TabIndex = 5
        Me.txtFecha_Doc.ValidatingType = GetType(Date)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(255, 164)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Fecha Entrega"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtObsNoAtencion)
        Me.GroupBox2.Controls.Add(Me.ChkAtendido)
        Me.GroupBox2.Controls.Add(Me.cmbTipoNoAtencion)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(1, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 64)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Atención"
        '
        'txtObsNoAtencion
        '
        Me.txtObsNoAtencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObsNoAtencion.Location = New System.Drawing.Point(89, 37)
        Me.txtObsNoAtencion.MaxLength = 80
        Me.txtObsNoAtencion.Name = "txtObsNoAtencion"
        Me.txtObsNoAtencion.Size = New System.Drawing.Size(598, 20)
        Me.txtObsNoAtencion.TabIndex = 1
        '
        'ChkAtendido
        '
        Me.ChkAtendido.AutoSize = True
        Me.ChkAtendido.Location = New System.Drawing.Point(90, 13)
        Me.ChkAtendido.Name = "ChkAtendido"
        Me.ChkAtendido.Size = New System.Drawing.Size(68, 17)
        Me.ChkAtendido.TabIndex = 7
        Me.ChkAtendido.Text = "&Atendido"
        Me.ChkAtendido.UseVisualStyleBackColor = True
        '
        'cmbTipoNoAtencion
        '
        Me.cmbTipoNoAtencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNoAtencion.FormattingEnabled = True
        Me.cmbTipoNoAtencion.Location = New System.Drawing.Point(303, 11)
        Me.cmbTipoNoAtencion.Name = "cmbTipoNoAtencion"
        Me.cmbTipoNoAtencion.Size = New System.Drawing.Size(273, 21)
        Me.cmbTipoNoAtencion.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Observacion"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(207, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Tipo No Atencion"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(10, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 15)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "[ F4 ] Entregar  a:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(9, 275)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(301, 15)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "[ ALT + A ] Atendido  - -  [ ALT + N ] No Atenido"
        '
        'frmConfirmarEntregas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(700, 298)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfirmarEntregas"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirmación de Entregas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtConsignado As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtEntregado As System.Windows.Forms.TextBox
    Friend WithEvents txtDNIEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtHoraEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha_Entrega As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObsNoAtencion As System.Windows.Forms.TextBox
    Friend WithEvents ChkAtendido As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoNoAtencion As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFecha_Doc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CboConsignado As System.Windows.Forms.ComboBox
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
End Class
