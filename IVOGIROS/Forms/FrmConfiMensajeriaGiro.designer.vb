<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiMensajeriaGiro
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBIDTIPO_COMUNICACION = New System.Windows.Forms.ComboBox
        Me.TXTNRO_MOVIL = New System.Windows.Forms.TextBox
        Me.TXTE_MAIL = New System.Windows.Forms.TextBox
        Me.BTNACEP = New System.Windows.Forms.Button
        Me.BTNCANCE = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RBENVIO_MENSAJERIA_ACTI = New System.Windows.Forms.RadioButton
        Me.RBENVIO_MENSAJERIA_DESAC = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTE_MAIL2 = New System.Windows.Forms.TextBox
        Me.TXTNRO_MOVIL2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CBIDTIPO_COMUNICACION2 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(281, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "E - Mail:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(143, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Número:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Tipo de Comunicación:"
        '
        'CBIDTIPO_COMUNICACION
        '
        Me.CBIDTIPO_COMUNICACION.FormattingEnabled = True
        Me.CBIDTIPO_COMUNICACION.Location = New System.Drawing.Point(7, 32)
        Me.CBIDTIPO_COMUNICACION.Name = "CBIDTIPO_COMUNICACION"
        Me.CBIDTIPO_COMUNICACION.Size = New System.Drawing.Size(132, 21)
        Me.CBIDTIPO_COMUNICACION.TabIndex = 2
        '
        'TXTNRO_MOVIL
        '
        Me.TXTNRO_MOVIL.Location = New System.Drawing.Point(146, 33)
        Me.TXTNRO_MOVIL.MaxLength = 10
        Me.TXTNRO_MOVIL.Name = "TXTNRO_MOVIL"
        Me.TXTNRO_MOVIL.Size = New System.Drawing.Size(132, 20)
        Me.TXTNRO_MOVIL.TabIndex = 3
        '
        'TXTE_MAIL
        '
        Me.TXTE_MAIL.Location = New System.Drawing.Point(284, 33)
        Me.TXTE_MAIL.MaxLength = 60
        Me.TXTE_MAIL.Name = "TXTE_MAIL"
        Me.TXTE_MAIL.Size = New System.Drawing.Size(170, 20)
        Me.TXTE_MAIL.TabIndex = 4
        '
        'BTNACEP
        '
        Me.BTNACEP.BackColor = System.Drawing.Color.AliceBlue
        Me.BTNACEP.Location = New System.Drawing.Point(316, 208)
        Me.BTNACEP.Name = "BTNACEP"
        Me.BTNACEP.Size = New System.Drawing.Size(75, 23)
        Me.BTNACEP.TabIndex = 5
        Me.BTNACEP.Text = "Aceptar"
        Me.BTNACEP.UseVisualStyleBackColor = False
        '
        'BTNCANCE
        '
        Me.BTNCANCE.BackColor = System.Drawing.Color.AliceBlue
        Me.BTNCANCE.Location = New System.Drawing.Point(397, 208)
        Me.BTNCANCE.Name = "BTNCANCE"
        Me.BTNCANCE.Size = New System.Drawing.Size(75, 23)
        Me.BTNCANCE.TabIndex = 10
        Me.BTNCANCE.Text = "Cancelar"
        Me.BTNCANCE.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RBENVIO_MENSAJERIA_ACTI)
        Me.GroupBox1.Controls.Add(Me.RBENVIO_MENSAJERIA_DESAC)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 36)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensajeria..."
        '
        'RBENVIO_MENSAJERIA_ACTI
        '
        Me.RBENVIO_MENSAJERIA_ACTI.AutoSize = True
        Me.RBENVIO_MENSAJERIA_ACTI.Checked = True
        Me.RBENVIO_MENSAJERIA_ACTI.Location = New System.Drawing.Point(8, 13)
        Me.RBENVIO_MENSAJERIA_ACTI.Name = "RBENVIO_MENSAJERIA_ACTI"
        Me.RBENVIO_MENSAJERIA_ACTI.Size = New System.Drawing.Size(67, 17)
        Me.RBENVIO_MENSAJERIA_ACTI.TabIndex = 0
        Me.RBENVIO_MENSAJERIA_ACTI.TabStop = True
        Me.RBENVIO_MENSAJERIA_ACTI.Text = "Activado"
        Me.RBENVIO_MENSAJERIA_ACTI.UseVisualStyleBackColor = True
        '
        'RBENVIO_MENSAJERIA_DESAC
        '
        Me.RBENVIO_MENSAJERIA_DESAC.AutoSize = True
        Me.RBENVIO_MENSAJERIA_DESAC.Location = New System.Drawing.Point(104, 13)
        Me.RBENVIO_MENSAJERIA_DESAC.Name = "RBENVIO_MENSAJERIA_DESAC"
        Me.RBENVIO_MENSAJERIA_DESAC.Size = New System.Drawing.Size(85, 17)
        Me.RBENVIO_MENSAJERIA_DESAC.TabIndex = 1
        Me.RBENVIO_MENSAJERIA_DESAC.Text = "Desactivado"
        Me.RBENVIO_MENSAJERIA_DESAC.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.BTNCANCE)
        Me.Panel1.Controls.Add(Me.BTNACEP)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 243)
        Me.Panel1.TabIndex = 91
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.TXTE_MAIL)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TXTNRO_MOVIL)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.CBIDTIPO_COMUNICACION)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 44)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(469, 61)
        Me.GroupBox3.TabIndex = 92
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Remitente..."
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TXTE_MAIL2)
        Me.GroupBox2.Controls.Add(Me.TXTNRO_MOVIL2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.CBIDTIPO_COMUNICACION2)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 80)
        Me.GroupBox2.TabIndex = 91
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consignado..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Tipo de Comunicación:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(287, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "E - Mail:"
        '
        'TXTE_MAIL2
        '
        Me.TXTE_MAIL2.Location = New System.Drawing.Point(290, 33)
        Me.TXTE_MAIL2.MaxLength = 60
        Me.TXTE_MAIL2.Name = "TXTE_MAIL2"
        Me.TXTE_MAIL2.Size = New System.Drawing.Size(170, 20)
        Me.TXTE_MAIL2.TabIndex = 7
        '
        'TXTNRO_MOVIL2
        '
        Me.TXTNRO_MOVIL2.Location = New System.Drawing.Point(152, 33)
        Me.TXTNRO_MOVIL2.MaxLength = 10
        Me.TXTNRO_MOVIL2.Name = "TXTNRO_MOVIL2"
        Me.TXTNRO_MOVIL2.Size = New System.Drawing.Size(132, 20)
        Me.TXTNRO_MOVIL2.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(149, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Número:"
        '
        'CBIDTIPO_COMUNICACION2
        '
        Me.CBIDTIPO_COMUNICACION2.FormattingEnabled = True
        Me.CBIDTIPO_COMUNICACION2.Location = New System.Drawing.Point(13, 32)
        Me.CBIDTIPO_COMUNICACION2.Name = "CBIDTIPO_COMUNICACION2"
        Me.CBIDTIPO_COMUNICACION2.Size = New System.Drawing.Size(132, 21)
        Me.CBIDTIPO_COMUNICACION2.TabIndex = 5
        '
        'FrmConfiMensajeriaGiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 243)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmConfiMensajeriaGiro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registro de Datos para Mensajería..."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBIDTIPO_COMUNICACION As System.Windows.Forms.ComboBox
    Friend WithEvents TXTNRO_MOVIL As System.Windows.Forms.TextBox
    Friend WithEvents TXTE_MAIL As System.Windows.Forms.TextBox
    Friend WithEvents BTNACEP As System.Windows.Forms.Button
    Friend WithEvents BTNCANCE As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBENVIO_MENSAJERIA_ACTI As System.Windows.Forms.RadioButton
    Friend WithEvents RBENVIO_MENSAJERIA_DESAC As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBIDTIPO_COMUNICACION2 As System.Windows.Forms.ComboBox
    Friend WithEvents TXTNRO_MOVIL2 As System.Windows.Forms.TextBox
    Friend WithEvents TXTE_MAIL2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
