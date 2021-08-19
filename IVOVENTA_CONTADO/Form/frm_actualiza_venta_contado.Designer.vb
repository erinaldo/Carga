<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_actualiza_venta_contado
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ChkAcompaña = New System.Windows.Forms.CheckBox()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_documento_identidad = New System.Windows.Forms.TextBox()
        Me.txt_documento = New System.Windows.Forms.TextBox()
        Me.txtrazon_cliente = New System.Windows.Forms.TextBox()
        Me.lab_tipo_comprobante = New System.Windows.Forms.Label()
        Me.txtidcomprobante = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnConsignado = New System.Windows.Forms.Button()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txtmonto_impuesto = New System.Windows.Forms.TextBox()
        Me.txtmonto_sub_total = New System.Windows.Forms.TextBox()
        Me.dgvConsignado = New System.Windows.Forms.DataGridView()
        Me.cmb_agencia_origen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTP_fecha_dcto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbagencias_destinos = New System.Windows.Forms.ComboBox()
        Me.cmbforma_pago = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtidunidad_agencia = New System.Windows.Forms.TextBox()
        Me.txt_idunida_agencia_origen = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvConsignado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ChkAcompaña)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 329)
        Me.Panel1.TabIndex = 0
        '
        'ChkAcompaña
        '
        Me.ChkAcompaña.AutoSize = True
        Me.ChkAcompaña.Enabled = False
        Me.ChkAcompaña.Location = New System.Drawing.Point(18, 299)
        Me.ChkAcompaña.Name = "ChkAcompaña"
        Me.ChkAcompaña.Size = New System.Drawing.Size(120, 17)
        Me.ChkAcompaña.TabIndex = 25
        Me.ChkAcompaña.Text = "Carga Acompañada"
        Me.ChkAcompaña.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_aceptar.Location = New System.Drawing.Point(146, 288)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(78, 30)
        Me.btn_aceptar.TabIndex = 20
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_cancelar.Location = New System.Drawing.Point(309, 288)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(78, 30)
        Me.btn_cancelar.TabIndex = 19
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_documento_identidad)
        Me.GroupBox1.Controls.Add(Me.txt_documento)
        Me.GroupBox1.Controls.Add(Me.txtrazon_cliente)
        Me.GroupBox1.Controls.Add(Me.lab_tipo_comprobante)
        Me.GroupBox1.Controls.Add(Me.txtidcomprobante)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 69)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(7, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Cliente :"
        '
        'txt_documento_identidad
        '
        Me.txt_documento_identidad.BackColor = System.Drawing.Color.White
        Me.txt_documento_identidad.Location = New System.Drawing.Point(84, 13)
        Me.txt_documento_identidad.MaxLength = 11
        Me.txt_documento_identidad.Name = "txt_documento_identidad"
        Me.txt_documento_identidad.ReadOnly = True
        Me.txt_documento_identidad.Size = New System.Drawing.Size(93, 20)
        Me.txt_documento_identidad.TabIndex = 1
        '
        'txt_documento
        '
        Me.txt_documento.BackColor = System.Drawing.Color.White
        Me.txt_documento.Location = New System.Drawing.Point(84, 39)
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.ReadOnly = True
        Me.txt_documento.Size = New System.Drawing.Size(116, 20)
        Me.txt_documento.TabIndex = 1
        '
        'txtrazon_cliente
        '
        Me.txtrazon_cliente.BackColor = System.Drawing.Color.White
        Me.txtrazon_cliente.Location = New System.Drawing.Point(178, 13)
        Me.txtrazon_cliente.Name = "txtrazon_cliente"
        Me.txtrazon_cliente.ReadOnly = True
        Me.txtrazon_cliente.Size = New System.Drawing.Size(313, 20)
        Me.txtrazon_cliente.TabIndex = 7
        '
        'lab_tipo_comprobante
        '
        Me.lab_tipo_comprobante.AutoSize = True
        Me.lab_tipo_comprobante.ForeColor = System.Drawing.Color.Maroon
        Me.lab_tipo_comprobante.Location = New System.Drawing.Point(7, 42)
        Me.lab_tipo_comprobante.Name = "lab_tipo_comprobante"
        Me.lab_tipo_comprobante.Size = New System.Drawing.Size(77, 13)
        Me.lab_tipo_comprobante.TabIndex = 0
        Me.lab_tipo_comprobante.Text = "Boleta Venta : "
        '
        'txtidcomprobante
        '
        Me.txtidcomprobante.BackColor = System.Drawing.Color.White
        Me.txtidcomprobante.Location = New System.Drawing.Point(201, 39)
        Me.txtidcomprobante.Name = "txtidcomprobante"
        Me.txtidcomprobante.ReadOnly = True
        Me.txtidcomprobante.Size = New System.Drawing.Size(116, 20)
        Me.txtidcomprobante.TabIndex = 2
        Me.txtidcomprobante.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnConsignado)
        Me.GroupBox3.Controls.Add(Me.txt_total)
        Me.GroupBox3.Controls.Add(Me.txtmonto_impuesto)
        Me.GroupBox3.Controls.Add(Me.txtmonto_sub_total)
        Me.GroupBox3.Controls.Add(Me.dgvConsignado)
        Me.GroupBox3.Controls.Add(Me.cmb_agencia_origen)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.DTP_fecha_dcto)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmbagencias_destinos)
        Me.GroupBox3.Controls.Add(Me.cmbforma_pago)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 72)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(497, 204)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        '
        'btnConsignado
        '
        Me.btnConsignado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsignado.Image = Global.INTEGRACION.My.Resources.Resources._001
        Me.btnConsignado.Location = New System.Drawing.Point(463, 44)
        Me.btnConsignado.Name = "btnConsignado"
        Me.btnConsignado.Size = New System.Drawing.Size(29, 21)
        Me.btnConsignado.TabIndex = 278
        Me.btnConsignado.UseVisualStyleBackColor = True
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Enabled = False
        Me.txt_total.Location = New System.Drawing.Point(401, 175)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(87, 20)
        Me.txt_total.TabIndex = 27
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmonto_impuesto
        '
        Me.txtmonto_impuesto.BackColor = System.Drawing.Color.White
        Me.txtmonto_impuesto.Enabled = False
        Me.txtmonto_impuesto.Location = New System.Drawing.Point(240, 175)
        Me.txtmonto_impuesto.Name = "txtmonto_impuesto"
        Me.txtmonto_impuesto.Size = New System.Drawing.Size(87, 20)
        Me.txtmonto_impuesto.TabIndex = 26
        Me.txtmonto_impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmonto_sub_total
        '
        Me.txtmonto_sub_total.BackColor = System.Drawing.Color.White
        Me.txtmonto_sub_total.Enabled = False
        Me.txtmonto_sub_total.Location = New System.Drawing.Point(84, 175)
        Me.txtmonto_sub_total.Name = "txtmonto_sub_total"
        Me.txtmonto_sub_total.Size = New System.Drawing.Size(87, 20)
        Me.txtmonto_sub_total.TabIndex = 25
        Me.txtmonto_sub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvConsignado
        '
        Me.dgvConsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsignado.Location = New System.Drawing.Point(84, 45)
        Me.dgvConsignado.Name = "dgvConsignado"
        Me.dgvConsignado.Size = New System.Drawing.Size(375, 94)
        Me.dgvConsignado.TabIndex = 19
        '
        'cmb_agencia_origen
        '
        Me.cmb_agencia_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_agencia_origen.Enabled = False
        Me.cmb_agencia_origen.FormattingEnabled = True
        Me.cmb_agencia_origen.Location = New System.Drawing.Point(84, 13)
        Me.cmb_agencia_origen.Name = "cmb_agencia_origen"
        Me.cmb_agencia_origen.Size = New System.Drawing.Size(161, 21)
        Me.cmb_agencia_origen.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Ag. Origen : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(348, 177)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Total "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(179, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Impuesto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(7, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Sub Total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(7, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha : "
        '
        'DTP_fecha_dcto
        '
        Me.DTP_fecha_dcto.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DTP_fecha_dcto.Enabled = False
        Me.DTP_fecha_dcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_fecha_dcto.Location = New System.Drawing.Point(84, 148)
        Me.DTP_fecha_dcto.Name = "DTP_fecha_dcto"
        Me.DTP_fecha_dcto.Size = New System.Drawing.Size(87, 20)
        Me.DTP_fecha_dcto.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(285, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Forma Pago :"
        '
        'cmbagencias_destinos
        '
        Me.cmbagencias_destinos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbagencias_destinos.FormattingEnabled = True
        Me.cmbagencias_destinos.Location = New System.Drawing.Point(329, 13)
        Me.cmbagencias_destinos.Name = "cmbagencias_destinos"
        Me.cmbagencias_destinos.Size = New System.Drawing.Size(161, 21)
        Me.cmbagencias_destinos.TabIndex = 11
        '
        'cmbforma_pago
        '
        Me.cmbforma_pago.BackColor = System.Drawing.Color.White
        Me.cmbforma_pago.Enabled = False
        Me.cmbforma_pago.FormattingEnabled = True
        Me.cmbforma_pago.Location = New System.Drawing.Point(367, 147)
        Me.cmbforma_pago.Name = "cmbforma_pago"
        Me.cmbforma_pago.Size = New System.Drawing.Size(121, 21)
        Me.cmbforma_pago.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(253, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Ag. Destino : "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(7, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Consignado"
        '
        'txtidunidad_agencia
        '
        Me.txtidunidad_agencia.BackColor = System.Drawing.SystemColors.Info
        Me.txtidunidad_agencia.Location = New System.Drawing.Point(259, 363)
        Me.txtidunidad_agencia.Name = "txtidunidad_agencia"
        Me.txtidunidad_agencia.ReadOnly = True
        Me.txtidunidad_agencia.Size = New System.Drawing.Size(100, 20)
        Me.txtidunidad_agencia.TabIndex = 22
        Me.txtidunidad_agencia.Visible = False
        '
        'txt_idunida_agencia_origen
        '
        Me.txt_idunida_agencia_origen.BackColor = System.Drawing.SystemColors.Info
        Me.txt_idunida_agencia_origen.Location = New System.Drawing.Point(261, 363)
        Me.txt_idunida_agencia_origen.Name = "txt_idunida_agencia_origen"
        Me.txt_idunida_agencia_origen.ReadOnly = True
        Me.txt_idunida_agencia_origen.Size = New System.Drawing.Size(100, 20)
        Me.txt_idunida_agencia_origen.TabIndex = 25
        Me.txt_idunida_agencia_origen.Visible = False
        '
        'frm_actualiza_venta_contado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 337)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtidunidad_agencia)
        Me.Controls.Add(Me.txt_idunida_agencia_origen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_actualiza_venta_contado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualiza Comprobante"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvConsignado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents lab_tipo_comprobante As System.Windows.Forms.Label
    Friend WithEvents txtrazon_cliente As System.Windows.Forms.TextBox
    Friend WithEvents DTP_fecha_dcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtidcomprobante As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_documento_identidad As System.Windows.Forms.TextBox
    Friend WithEvents cmbforma_pago As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbagencias_destinos As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtidunidad_agencia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_agencia_origen As System.Windows.Forms.ComboBox
    Friend WithEvents txt_idunida_agencia_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkAcompaña As System.Windows.Forms.CheckBox
    Friend WithEvents dgvConsignado As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_impuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_sub_total As System.Windows.Forms.TextBox
    Friend WithEvents btnConsignado As System.Windows.Forms.Button
End Class
