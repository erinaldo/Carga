<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmactualizar_datos_entrega
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
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DTp_hora_entrega = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtp_fecha_entrega = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_dcto_identidad = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_entregado = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lab_tipo_comprobante = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_comprobante = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(375, 149)
        Me.Panel1.TabIndex = 0
        '
        'btn_cancelar
        '
        Me.btn_cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_cancelar.Location = New System.Drawing.Point(290, 119)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 2
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_aceptar.Location = New System.Drawing.Point(190, 119)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DTp_hora_entrega)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_entrega)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_dcto_identidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_entregado)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lab_tipo_comprobante)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_comprobante)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 110)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DTp_hora_entrega
        '
        Me.DTp_hora_entrega.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTp_hora_entrega.Location = New System.Drawing.Point(277, 84)
        Me.DTp_hora_entrega.Name = "DTp_hora_entrega"
        Me.DTp_hora_entrega.Size = New System.Drawing.Size(85, 20)
        Me.DTp_hora_entrega.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(204, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Hora Entrega :"
        '
        'dtp_fecha_entrega
        '
        Me.dtp_fecha_entrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_entrega.Location = New System.Drawing.Point(106, 83)
        Me.dtp_fecha_entrega.Name = "dtp_fecha_entrega"
        Me.dtp_fecha_entrega.Size = New System.Drawing.Size(100, 20)
        Me.dtp_fecha_entrega.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(4, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Fec. Entrega :"
        '
        'txt_dcto_identidad
        '
        Me.txt_dcto_identidad.Location = New System.Drawing.Point(106, 58)
        Me.txt_dcto_identidad.MaxLength = 15
        Me.txt_dcto_identidad.Name = "txt_dcto_identidad"
        Me.txt_dcto_identidad.Size = New System.Drawing.Size(100, 20)
        Me.txt_dcto_identidad.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(4, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Con Dcto Identidad :"
        '
        'txt_entregado
        '
        Me.txt_entregado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_entregado.Location = New System.Drawing.Point(106, 34)
        Me.txt_entregado.MaxLength = 100
        Me.txt_entregado.Name = "txt_entregado"
        Me.txt_entregado.Size = New System.Drawing.Size(255, 20)
        Me.txt_entregado.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(4, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Entregado a :"
        '
        'lab_tipo_comprobante
        '
        Me.lab_tipo_comprobante.AutoSize = True
        Me.lab_tipo_comprobante.ForeColor = System.Drawing.Color.Maroon
        Me.lab_tipo_comprobante.Location = New System.Drawing.Point(265, 12)
        Me.lab_tipo_comprobante.Name = "lab_tipo_comprobante"
        Me.lab_tipo_comprobante.Size = New System.Drawing.Size(10, 13)
        Me.lab_tipo_comprobante.TabIndex = 2
        Me.lab_tipo_comprobante.Text = "."
        Me.lab_tipo_comprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(4, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nº Comprobante :"
        '
        'txt_comprobante
        '
        Me.txt_comprobante.BackColor = System.Drawing.SystemColors.Info
        Me.txt_comprobante.Location = New System.Drawing.Point(106, 9)
        Me.txt_comprobante.MaxLength = 13
        Me.txt_comprobante.Name = "txt_comprobante"
        Me.txt_comprobante.ReadOnly = True
        Me.txt_comprobante.Size = New System.Drawing.Size(100, 20)
        Me.txt_comprobante.TabIndex = 0
        '
        'Frmactualizar_datos_entrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frmactualizar_datos_entrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Actualiza datos de entrega"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lab_tipo_comprobante As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_comprobante As System.Windows.Forms.TextBox
    Friend WithEvents txt_dcto_identidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_entregado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_entrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTp_hora_entrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
