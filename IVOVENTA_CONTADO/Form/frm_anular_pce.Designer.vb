<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_anular_pce
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
        Me.txt_idfactura = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_obs = New System.Windows.Forms.TextBox
        Me.txt_fecha_registro = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_totales = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_fecha_documento = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_agencia_destino = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_agencia_origen = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_ciudad_destino = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_ciudad_origen = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_consignado = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_codigo_cliente = New System.Windows.Forms.Label
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.lab_tipo_comp = New System.Windows.Forms.Label
        Me.txt_comprobante = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_nu_documento = New System.Windows.Forms.TextBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.txt_idfactura)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(-3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(535, 246)
        Me.Panel1.TabIndex = 0
        '
        'txt_idfactura
        '
        Me.txt_idfactura.BackColor = System.Drawing.SystemColors.Info
        Me.txt_idfactura.Location = New System.Drawing.Point(15, 208)
        Me.txt_idfactura.Name = "txt_idfactura"
        Me.txt_idfactura.ReadOnly = True
        Me.txt_idfactura.Size = New System.Drawing.Size(100, 20)
        Me.txt_idfactura.TabIndex = 24
        Me.txt_idfactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_idfactura.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_nu_documento)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txt_obs)
        Me.GroupBox1.Controls.Add(Me.txt_fecha_registro)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_totales)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_fecha_documento)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_agencia_destino)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_agencia_origen)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_ciudad_destino)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_ciudad_origen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_consignado)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_cliente)
        Me.GroupBox1.Controls.Add(Me.txt_cliente)
        Me.GroupBox1.Controls.Add(Me.lab_tipo_comp)
        Me.GroupBox1.Controls.Add(Me.txt_comprobante)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 206)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(17, 172)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Obs : "
        '
        'txt_obs
        '
        Me.txt_obs.BackColor = System.Drawing.Color.White
        Me.txt_obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_obs.Location = New System.Drawing.Point(60, 169)
        Me.txt_obs.MaxLength = 60
        Me.txt_obs.Name = "txt_obs"
        Me.txt_obs.Size = New System.Drawing.Size(449, 20)
        Me.txt_obs.TabIndex = 0
        '
        'txt_fecha_registro
        '
        Me.txt_fecha_registro.BackColor = System.Drawing.SystemColors.Info
        Me.txt_fecha_registro.Location = New System.Drawing.Point(234, 141)
        Me.txt_fecha_registro.Name = "txt_fecha_registro"
        Me.txt_fecha_registro.ReadOnly = True
        Me.txt_fecha_registro.Size = New System.Drawing.Size(129, 20)
        Me.txt_fecha_registro.TabIndex = 25
        Me.txt_fecha_registro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(159, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Fec. Registro : "
        '
        'txt_totales
        '
        Me.txt_totales.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totales.Location = New System.Drawing.Point(438, 141)
        Me.txt_totales.Name = "txt_totales"
        Me.txt_totales.ReadOnly = True
        Me.txt_totales.Size = New System.Drawing.Size(68, 20)
        Me.txt_totales.TabIndex = 23
        Me.txt_totales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(392, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Total : "
        '
        'txt_fecha_documento
        '
        Me.txt_fecha_documento.BackColor = System.Drawing.SystemColors.Info
        Me.txt_fecha_documento.Location = New System.Drawing.Point(60, 141)
        Me.txt_fecha_documento.Name = "txt_fecha_documento"
        Me.txt_fecha_documento.ReadOnly = True
        Me.txt_fecha_documento.Size = New System.Drawing.Size(86, 20)
        Me.txt_fecha_documento.TabIndex = 21
        Me.txt_fecha_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(2, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Fec. Dcto : "
        '
        'txt_agencia_destino
        '
        Me.txt_agencia_destino.BackColor = System.Drawing.SystemColors.Info
        Me.txt_agencia_destino.Location = New System.Drawing.Point(356, 114)
        Me.txt_agencia_destino.Name = "txt_agencia_destino"
        Me.txt_agencia_destino.ReadOnly = True
        Me.txt_agencia_destino.Size = New System.Drawing.Size(153, 20)
        Me.txt_agencia_destino.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(283, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Ag. Destino : "
        '
        'txt_agencia_origen
        '
        Me.txt_agencia_origen.BackColor = System.Drawing.SystemColors.Info
        Me.txt_agencia_origen.Location = New System.Drawing.Point(60, 111)
        Me.txt_agencia_origen.Name = "txt_agencia_origen"
        Me.txt_agencia_origen.ReadOnly = True
        Me.txt_agencia_origen.Size = New System.Drawing.Size(153, 20)
        Me.txt_agencia_origen.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(3, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Ag. Origen : "
        '
        'txt_ciudad_destino
        '
        Me.txt_ciudad_destino.BackColor = System.Drawing.SystemColors.Info
        Me.txt_ciudad_destino.Location = New System.Drawing.Point(355, 85)
        Me.txt_ciudad_destino.MaxLength = 11
        Me.txt_ciudad_destino.Name = "txt_ciudad_destino"
        Me.txt_ciudad_destino.ReadOnly = True
        Me.txt_ciudad_destino.Size = New System.Drawing.Size(153, 20)
        Me.txt_ciudad_destino.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(297, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Destino : "
        '
        'txt_ciudad_origen
        '
        Me.txt_ciudad_origen.BackColor = System.Drawing.SystemColors.Info
        Me.txt_ciudad_origen.Location = New System.Drawing.Point(60, 85)
        Me.txt_ciudad_origen.MaxLength = 11
        Me.txt_ciudad_origen.Name = "txt_ciudad_origen"
        Me.txt_ciudad_origen.ReadOnly = True
        Me.txt_ciudad_origen.Size = New System.Drawing.Size(153, 20)
        Me.txt_ciudad_origen.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(5, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Origen : "
        '
        'txt_consignado
        '
        Me.txt_consignado.BackColor = System.Drawing.SystemColors.Info
        Me.txt_consignado.Location = New System.Drawing.Point(60, 61)
        Me.txt_consignado.Name = "txt_consignado"
        Me.txt_consignado.ReadOnly = True
        Me.txt_consignado.Size = New System.Drawing.Size(449, 20)
        Me.txt_consignado.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(6, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Consig : "
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.AutoSize = True
        Me.txt_codigo_cliente.ForeColor = System.Drawing.Color.Maroon
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(5, 40)
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(57, 13)
        Me.txt_codigo_cliente.TabIndex = 2
        Me.txt_codigo_cliente.Text = "Ruc/Dni : "
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cliente.Location = New System.Drawing.Point(212, 37)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(296, 20)
        Me.txt_cliente.TabIndex = 1
        '
        'lab_tipo_comp
        '
        Me.lab_tipo_comp.AutoSize = True
        Me.lab_tipo_comp.ForeColor = System.Drawing.Color.Maroon
        Me.lab_tipo_comp.Location = New System.Drawing.Point(324, 16)
        Me.lab_tipo_comp.Name = "lab_tipo_comp"
        Me.lab_tipo_comp.Size = New System.Drawing.Size(10, 13)
        Me.lab_tipo_comp.TabIndex = 7
        Me.lab_tipo_comp.Text = "."
        Me.lab_tipo_comp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_comprobante
        '
        Me.txt_comprobante.BackColor = System.Drawing.SystemColors.Info
        Me.txt_comprobante.Location = New System.Drawing.Point(60, 13)
        Me.txt_comprobante.Name = "txt_comprobante"
        Me.txt_comprobante.ReadOnly = True
        Me.txt_comprobante.Size = New System.Drawing.Size(86, 20)
        Me.txt_comprobante.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(5, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nº Comp. :  "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(163, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cliente : "
        '
        'txt_nu_documento
        '
        Me.txt_nu_documento.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nu_documento.Location = New System.Drawing.Point(60, 37)
        Me.txt_nu_documento.MaxLength = 11
        Me.txt_nu_documento.Name = "txt_nu_documento"
        Me.txt_nu_documento.ReadOnly = True
        Me.txt_nu_documento.Size = New System.Drawing.Size(86, 20)
        Me.txt_nu_documento.TabIndex = 0
        '
        'btn_aceptar
        '
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_aceptar.Location = New System.Drawing.Point(345, 216)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_cancelar.Location = New System.Drawing.Point(437, 216)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 2
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'frm_anular_pce
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 249)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_anular_pce"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Anular PCE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_comprobante As System.Windows.Forms.TextBox
    Friend WithEvents lab_tipo_comp As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ciudad_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_consignado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.Label
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nu_documento As System.Windows.Forms.TextBox
    Friend WithEvents txt_agencia_destino As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_agencia_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_ciudad_destino As System.Windows.Forms.TextBox
    Friend WithEvents txt_totales As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_fecha_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_idfactura As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha_registro As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_obs As System.Windows.Forms.TextBox
End Class
