<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_genera_incidencia_despacho
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtorigen = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_destino = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_dcto_cliente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtp_fec_recepciona = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.lab_tip_documento = New System.Windows.Forms.Label
        Me.cmb_agencia_origen = New System.Windows.Forms.ComboBox
        Me.cmb_agencia_destino = New System.Windows.Forms.ComboBox
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btn_salir)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 197)
        Me.Panel1.TabIndex = 0
        '
        'btn_salir
        '
        Me.btn_salir.Enabled = False
        Me.btn_salir.ForeColor = System.Drawing.Color.Maroon
        Me.btn_salir.Location = New System.Drawing.Point(487, 159)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(75, 23)
        Me.btn_salir.TabIndex = 5
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        Me.btn_salir.Visible = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_aceptar.Location = New System.Drawing.Point(384, 159)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 4
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Documento : "
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtorigen)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_destino)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_cliente)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_dcto_cliente)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtp_fec_recepciona)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lab_tip_documento)
        Me.GroupBox1.Controls.Add(Me.cmb_agencia_origen)
        Me.GroupBox1.Controls.Add(Me.cmb_agencia_destino)
        Me.GroupBox1.Controls.Add(Me.txt_documento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(567, 150)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'txtorigen
        '
        Me.txtorigen.BackColor = System.Drawing.SystemColors.Info
        Me.txtorigen.Location = New System.Drawing.Point(98, 62)
        Me.txtorigen.MaxLength = 20
        Me.txtorigen.Name = "txtorigen"
        Me.txtorigen.ReadOnly = True
        Me.txtorigen.Size = New System.Drawing.Size(117, 20)
        Me.txtorigen.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(7, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Origen : "
        '
        'txt_destino
        '
        Me.txt_destino.BackColor = System.Drawing.SystemColors.Info
        Me.txt_destino.Location = New System.Drawing.Point(442, 62)
        Me.txt_destino.MaxLength = 20
        Me.txt_destino.Name = "txt_destino"
        Me.txt_destino.ReadOnly = True
        Me.txt_destino.Size = New System.Drawing.Size(117, 20)
        Me.txt_destino.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(378, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Destino :"
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cliente.Location = New System.Drawing.Point(292, 34)
        Me.txt_cliente.MaxLength = 20
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(267, 20)
        Me.txt_cliente.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(241, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Cliente :"
        '
        'txt_dcto_cliente
        '
        Me.txt_dcto_cliente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_dcto_cliente.Location = New System.Drawing.Point(98, 34)
        Me.txt_dcto_cliente.MaxLength = 20
        Me.txt_dcto_cliente.Name = "txt_dcto_cliente"
        Me.txt_dcto_cliente.ReadOnly = True
        Me.txt_dcto_cliente.Size = New System.Drawing.Size(117, 20)
        Me.txt_dcto_cliente.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(7, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "RUC/DNI : "
        '
        'dtp_fec_recepciona
        '
        Me.dtp_fec_recepciona.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fec_recepciona.Location = New System.Drawing.Point(155, 115)
        Me.dtp_fec_recepciona.Name = "dtp_fec_recepciona"
        Me.dtp_fec_recepciona.Size = New System.Drawing.Size(107, 20)
        Me.dtp_fec_recepciona.TabIndex = 2
        Me.dtp_fec_recepciona.Value = New Date(2008, 3, 26, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(7, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha Recepciona : "
        '
        'lab_tip_documento
        '
        Me.lab_tip_documento.AutoSize = True
        Me.lab_tip_documento.ForeColor = System.Drawing.Color.Maroon
        Me.lab_tip_documento.Location = New System.Drawing.Point(386, 12)
        Me.lab_tip_documento.Name = "lab_tip_documento"
        Me.lab_tip_documento.Size = New System.Drawing.Size(10, 13)
        Me.lab_tip_documento.TabIndex = 2
        Me.lab_tip_documento.Text = "."
        '
        'cmb_agencia_origen
        '
        Me.cmb_agencia_origen.BackColor = System.Drawing.Color.White
        Me.cmb_agencia_origen.FormattingEnabled = True
        Me.cmb_agencia_origen.Location = New System.Drawing.Point(97, 89)
        Me.cmb_agencia_origen.Name = "cmb_agencia_origen"
        Me.cmb_agencia_origen.Size = New System.Drawing.Size(165, 21)
        Me.cmb_agencia_origen.TabIndex = 0
        '
        'cmb_agencia_destino
        '
        Me.cmb_agencia_destino.FormattingEnabled = True
        Me.cmb_agencia_destino.Location = New System.Drawing.Point(381, 91)
        Me.cmb_agencia_destino.Name = "cmb_agencia_destino"
        Me.cmb_agencia_destino.Size = New System.Drawing.Size(178, 21)
        Me.cmb_agencia_destino.TabIndex = 1
        '
        'txt_documento
        '
        Me.txt_documento.BackColor = System.Drawing.SystemColors.Info
        Me.txt_documento.Location = New System.Drawing.Point(98, 9)
        Me.txt_documento.MaxLength = 20
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.ReadOnly = True
        Me.txt_documento.Size = New System.Drawing.Size(117, 20)
        Me.txt_documento.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(269, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Agencia Recepciona : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(6, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Agencia Envia : "
        '
        'frm_genera_incidencia_despacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 201)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_genera_incidencia_despacho"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recepción sin Guía Transportista"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lab_tip_documento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_agencia_origen As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_agencia_destino As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fec_recepciona As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_dcto_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents txtorigen As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_destino As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
