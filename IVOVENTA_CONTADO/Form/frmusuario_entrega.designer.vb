<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmusuario_entrega
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_destino = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_dcto = New System.Windows.Forms.TextBox()
        Me.Lab_tip_dcto = New System.Windows.Forms.TextBox()
        Me.txt_origen = New System.Windows.Forms.TextBox()
        Me.Btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPasswor = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_destino)
        Me.Panel1.Controls.Add(Me.label14)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_dcto)
        Me.Panel1.Controls.Add(Me.Lab_tip_dcto)
        Me.Panel1.Controls.Add(Me.txt_origen)
        Me.Panel1.Controls.Add(Me.Btn_cancelar)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 193)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(191, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Destino"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Origen "
        '
        'txt_destino
        '
        Me.txt_destino.BackColor = System.Drawing.Color.White
        Me.txt_destino.Enabled = False
        Me.txt_destino.HideSelection = False
        Me.txt_destino.Location = New System.Drawing.Point(240, 35)
        Me.txt_destino.MaxLength = 30
        Me.txt_destino.Name = "txt_destino"
        Me.txt_destino.ReadOnly = True
        Me.txt_destino.Size = New System.Drawing.Size(139, 20)
        Me.txt_destino.TabIndex = 103
        '
        'label14
        '
        Me.label14.BackColor = System.Drawing.Color.Transparent
        Me.label14.ForeColor = System.Drawing.Color.Black
        Me.label14.Location = New System.Drawing.Point(9, 10)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(54, 13)
        Me.label14.TabIndex = 23
        Me.label14.Text = "Tipo Doc."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(190, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Nº Doc."
        '
        'txt_dcto
        '
        Me.txt_dcto.AcceptsTab = True
        Me.txt_dcto.BackColor = System.Drawing.Color.White
        Me.txt_dcto.Enabled = False
        Me.txt_dcto.Location = New System.Drawing.Point(240, 7)
        Me.txt_dcto.MaxLength = 30
        Me.txt_dcto.Name = "txt_dcto"
        Me.txt_dcto.ReadOnly = True
        Me.txt_dcto.Size = New System.Drawing.Size(139, 20)
        Me.txt_dcto.TabIndex = 100
        '
        'Lab_tip_dcto
        '
        Me.Lab_tip_dcto.BackColor = System.Drawing.Color.White
        Me.Lab_tip_dcto.Enabled = False
        Me.Lab_tip_dcto.HideSelection = False
        Me.Lab_tip_dcto.Location = New System.Drawing.Point(63, 7)
        Me.Lab_tip_dcto.MaxLength = 30
        Me.Lab_tip_dcto.Name = "Lab_tip_dcto"
        Me.Lab_tip_dcto.ReadOnly = True
        Me.Lab_tip_dcto.Size = New System.Drawing.Size(125, 20)
        Me.Lab_tip_dcto.TabIndex = 101
        '
        'txt_origen
        '
        Me.txt_origen.BackColor = System.Drawing.Color.White
        Me.txt_origen.Enabled = False
        Me.txt_origen.HideSelection = False
        Me.txt_origen.Location = New System.Drawing.Point(63, 35)
        Me.txt_origen.MaxLength = 30
        Me.txt_origen.Name = "txt_origen"
        Me.txt_origen.ReadOnly = True
        Me.txt_origen.Size = New System.Drawing.Size(125, 20)
        Me.txt_origen.TabIndex = 101
        '
        'Btn_cancelar
        '
        Me.Btn_cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_cancelar.Location = New System.Drawing.Point(219, 149)
        Me.Btn_cancelar.Name = "Btn_cancelar"
        Me.Btn_cancelar.Size = New System.Drawing.Size(77, 30)
        Me.Btn_cancelar.TabIndex = 3
        Me.Btn_cancelar.Text = "&Cancelar"
        Me.Btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Black
        Me.btn_aceptar.Location = New System.Drawing.Point(106, 149)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(77, 30)
        Me.btn_aceptar.TabIndex = 2
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtLogin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPasswor)
        Me.GroupBox1.Location = New System.Drawing.Point(44, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(291, 65)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'txtLogin
        '
        Me.txtLogin.AcceptsTab = True
        Me.txtLogin.BackColor = System.Drawing.Color.White
        Me.txtLogin.Location = New System.Drawing.Point(109, 12)
        Me.txtLogin.MaxLength = 30
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(177, 20)
        Me.txtLogin.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Contraseña"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Usuario"
        '
        'txtPasswor
        '
        Me.txtPasswor.BackColor = System.Drawing.Color.White
        Me.txtPasswor.Location = New System.Drawing.Point(109, 37)
        Me.txtPasswor.MaxLength = 15
        Me.txtPasswor.Name = "txtPasswor"
        Me.txtPasswor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswor.Size = New System.Drawing.Size(177, 20)
        Me.txtPasswor.TabIndex = 1
        '
        'frmusuario_entrega
        '
        Me.AcceptButton = Me.btn_aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmusuario_entrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuario Entrega Carga"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPasswor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents txt_destino As System.Windows.Forms.TextBox
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_dcto As System.Windows.Forms.TextBox
    Friend WithEvents txt_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lab_tip_dcto As System.Windows.Forms.TextBox
End Class
