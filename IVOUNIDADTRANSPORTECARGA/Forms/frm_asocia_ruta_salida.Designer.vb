<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_asocia_ruta_salida
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmb_destino = New System.Windows.Forms.ComboBox
        Me.cmb_origen = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_nro_salida = New System.Windows.Forms.TextBox
        Me.dgv_asocia_ruta = New System.Windows.Forms.DataGridView
        Me.lab_nro_salida = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.cmb_ruta_asociar = New System.Windows.Forms.ComboBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.cmb_asocia_ciudad = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_asocia_ruta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmb_destino)
        Me.Panel1.Controls.Add(Me.cmb_origen)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txt_nro_salida)
        Me.Panel1.Controls.Add(Me.dgv_asocia_ruta)
        Me.Panel1.Controls.Add(Me.lab_nro_salida)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Controls.Add(Me.cmb_ruta_asociar)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Controls.Add(Me.cmb_asocia_ciudad)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 286)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(10, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Eliminar [Supr]"
        '
        'cmb_destino
        '
        Me.cmb_destino.BackColor = System.Drawing.SystemColors.Info
        Me.cmb_destino.Enabled = False
        Me.cmb_destino.FormattingEnabled = True
        Me.cmb_destino.Location = New System.Drawing.Point(167, 46)
        Me.cmb_destino.Name = "cmb_destino"
        Me.cmb_destino.Size = New System.Drawing.Size(149, 21)
        Me.cmb_destino.TabIndex = 13
        '
        'cmb_origen
        '
        Me.cmb_origen.BackColor = System.Drawing.SystemColors.Info
        Me.cmb_origen.Enabled = False
        Me.cmb_origen.FormattingEnabled = True
        Me.cmb_origen.Location = New System.Drawing.Point(3, 46)
        Me.cmb_origen.Name = "cmb_origen"
        Me.cmb_origen.Size = New System.Drawing.Size(149, 21)
        Me.cmb_origen.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(168, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Ciudad Destino :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(7, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Ciudad Origen :"
        '
        'txt_nro_salida
        '
        Me.txt_nro_salida.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nro_salida.Location = New System.Drawing.Point(64, 4)
        Me.txt_nro_salida.Name = "txt_nro_salida"
        Me.txt_nro_salida.ReadOnly = True
        Me.txt_nro_salida.Size = New System.Drawing.Size(88, 20)
        Me.txt_nro_salida.TabIndex = 9
        '
        'dgv_asocia_ruta
        '
        Me.dgv_asocia_ruta.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgv_asocia_ruta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_asocia_ruta.Location = New System.Drawing.Point(3, 118)
        Me.dgv_asocia_ruta.Name = "dgv_asocia_ruta"
        Me.dgv_asocia_ruta.Size = New System.Drawing.Size(321, 127)
        Me.dgv_asocia_ruta.TabIndex = 8
        '
        'lab_nro_salida
        '
        Me.lab_nro_salida.AutoSize = True
        Me.lab_nro_salida.ForeColor = System.Drawing.Color.Maroon
        Me.lab_nro_salida.Location = New System.Drawing.Point(7, 6)
        Me.lab_nro_salida.Name = "lab_nro_salida"
        Me.lab_nro_salida.Size = New System.Drawing.Size(57, 13)
        Me.lab_nro_salida.TabIndex = 7
        Me.lab_nro_salida.Text = "Nº Salida :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(168, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Asociar Ciudad : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(3, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ruta Ciudad :"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_cancelar.Location = New System.Drawing.Point(241, 253)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 4
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'cmb_ruta_asociar
        '
        Me.cmb_ruta_asociar.FormattingEnabled = True
        Me.cmb_ruta_asociar.Location = New System.Drawing.Point(3, 90)
        Me.cmb_ruta_asociar.Name = "cmb_ruta_asociar"
        Me.cmb_ruta_asociar.Size = New System.Drawing.Size(149, 21)
        Me.cmb_ruta_asociar.TabIndex = 1
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Enabled = False
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_aceptar.Location = New System.Drawing.Point(160, 253)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 3
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        Me.btn_aceptar.Visible = False
        '
        'cmb_asocia_ciudad
        '
        Me.cmb_asocia_ciudad.FormattingEnabled = True
        Me.cmb_asocia_ciudad.Location = New System.Drawing.Point(168, 90)
        Me.cmb_asocia_ciudad.Name = "cmb_asocia_ciudad"
        Me.cmb_asocia_ciudad.Size = New System.Drawing.Size(149, 21)
        Me.cmb_asocia_ciudad.TabIndex = 2
        '
        'frm_asocia_ruta_salida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_asocia_ruta_salida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asociar ciudad a la ruta del bus"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_asocia_ruta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmb_ruta_asociar As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_asocia_ciudad As System.Windows.Forms.ComboBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents dgv_asocia_ruta As System.Windows.Forms.DataGridView
    Friend WithEvents lab_nro_salida As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nro_salida As System.Windows.Forms.TextBox
    Friend WithEvents cmb_destino As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
