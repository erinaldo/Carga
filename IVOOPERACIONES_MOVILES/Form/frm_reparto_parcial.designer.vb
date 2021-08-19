<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reparto_parcial
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
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_id = New System.Windows.Forms.TextBox
        Me.lab_documento = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_por_entregar = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_repartir = New System.Windows.Forms.TextBox
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_consignado = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_responsable = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_nro_dcto = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_reparto = New System.Windows.Forms.TextBox
        Me.txt_tot_bultos_dcto = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_entregado = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_cancelar.Location = New System.Drawing.Point(230, 252)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 0
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_aceptar.Location = New System.Drawing.Point(133, 252)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.txt_id)
        Me.Panel1.Controls.Add(Me.lab_documento)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_por_entregar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_repartir)
        Me.Panel1.Controls.Add(Me.txt_cliente)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 286)
        Me.Panel1.TabIndex = 2
        '
        'txt_id
        '
        Me.txt_id.BackColor = System.Drawing.SystemColors.Info
        Me.txt_id.Location = New System.Drawing.Point(12, 255)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(75, 20)
        Me.txt_id.TabIndex = 15
        Me.txt_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id.Visible = False
        '
        'lab_documento
        '
        Me.lab_documento.AutoSize = True
        Me.lab_documento.BackColor = System.Drawing.Color.Transparent
        Me.lab_documento.ForeColor = System.Drawing.Color.Maroon
        Me.lab_documento.Location = New System.Drawing.Point(190, 100)
        Me.lab_documento.Name = "lab_documento"
        Me.lab_documento.Size = New System.Drawing.Size(0, 13)
        Me.lab_documento.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(12, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "A Repartir : "
        '
        'txt_por_entregar
        '
        Me.txt_por_entregar.BackColor = System.Drawing.SystemColors.Info
        Me.txt_por_entregar.Location = New System.Drawing.Point(260, 169)
        Me.txt_por_entregar.Name = "txt_por_entregar"
        Me.txt_por_entregar.ReadOnly = True
        Me.txt_por_entregar.Size = New System.Drawing.Size(48, 20)
        Me.txt_por_entregar.TabIndex = 10
        Me.txt_por_entregar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Dcto : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Cliente : "
        '
        'txt_repartir
        '
        Me.txt_repartir.Location = New System.Drawing.Point(104, 195)
        Me.txt_repartir.Name = "txt_repartir"
        Me.txt_repartir.Size = New System.Drawing.Size(48, 20)
        Me.txt_repartir.TabIndex = 5
        Me.txt_repartir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cliente.Location = New System.Drawing.Point(86, 45)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(222, 20)
        Me.txt_cliente.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_consignado)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_responsable)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_nro_dcto)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 122)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'txt_consignado
        '
        Me.txt_consignado.BackColor = System.Drawing.SystemColors.Info
        Me.txt_consignado.Location = New System.Drawing.Point(83, 68)
        Me.txt_consignado.Name = "txt_consignado"
        Me.txt_consignado.ReadOnly = True
        Me.txt_consignado.Size = New System.Drawing.Size(222, 20)
        Me.txt_consignado.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(9, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Consignado : "
        '
        'txt_responsable
        '
        Me.txt_responsable.BackColor = System.Drawing.SystemColors.Info
        Me.txt_responsable.Location = New System.Drawing.Point(83, 16)
        Me.txt_responsable.Name = "txt_responsable"
        Me.txt_responsable.ReadOnly = True
        Me.txt_responsable.Size = New System.Drawing.Size(222, 20)
        Me.txt_responsable.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Responsable : "
        '
        'txt_nro_dcto
        '
        Me.txt_nro_dcto.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nro_dcto.Location = New System.Drawing.Point(83, 94)
        Me.txt_nro_dcto.Name = "txt_nro_dcto"
        Me.txt_nro_dcto.ReadOnly = True
        Me.txt_nro_dcto.Size = New System.Drawing.Size(92, 20)
        Me.txt_nro_dcto.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txt_reparto)
        Me.GroupBox2.Controls.Add(Me.txt_tot_bultos_dcto)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_entregado)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(308, 95)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(6, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Reparto : "
        '
        'txt_reparto
        '
        Me.txt_reparto.BackColor = System.Drawing.SystemColors.Info
        Me.txt_reparto.Location = New System.Drawing.Point(98, 39)
        Me.txt_reparto.Name = "txt_reparto"
        Me.txt_reparto.ReadOnly = True
        Me.txt_reparto.Size = New System.Drawing.Size(48, 20)
        Me.txt_reparto.TabIndex = 17
        Me.txt_reparto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tot_bultos_dcto
        '
        Me.txt_tot_bultos_dcto.BackColor = System.Drawing.SystemColors.Info
        Me.txt_tot_bultos_dcto.Location = New System.Drawing.Point(97, 13)
        Me.txt_tot_bultos_dcto.Name = "txt_tot_bultos_dcto"
        Me.txt_tot_bultos_dcto.ReadOnly = True
        Me.txt_tot_bultos_dcto.Size = New System.Drawing.Size(48, 20)
        Me.txt_tot_bultos_dcto.TabIndex = 16
        Me.txt_tot_bultos_dcto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total Dcto : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(162, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Por entregar : "
        '
        'txt_entregado
        '
        Me.txt_entregado.BackColor = System.Drawing.SystemColors.Info
        Me.txt_entregado.Location = New System.Drawing.Point(254, 12)
        Me.txt_entregado.Name = "txt_entregado"
        Me.txt_entregado.ReadOnly = True
        Me.txt_entregado.Size = New System.Drawing.Size(48, 20)
        Me.txt_entregado.TabIndex = 2
        Me.txt_entregado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(162, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Entregado : "
        '
        'frm_reparto_parcial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 288)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_reparto_parcial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reparto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_repartir As System.Windows.Forms.TextBox
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_nro_dcto As System.Windows.Forms.TextBox
    Friend WithEvents txt_entregado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lab_documento As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_por_entregar As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_responsable As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_consignado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_bultos_dcto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_reparto As System.Windows.Forms.TextBox
End Class
