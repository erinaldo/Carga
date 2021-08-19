<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambiarPasswordInicio
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
        Me.BTNACEP = New System.Windows.Forms.Button
        Me.BTNCANCE = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTPASSWORD_CONFIRMAR = New System.Windows.Forms.TextBox
        Me.TXTPASSWORD_NUEVO = New System.Windows.Forms.TextBox
        Me.txtlogin = New System.Windows.Forms.TextBox
        Me.TXTPASSWORD = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTNACEP
        '
        Me.BTNACEP.Location = New System.Drawing.Point(202, 185)
        Me.BTNACEP.Name = "BTNACEP"
        Me.BTNACEP.Size = New System.Drawing.Size(75, 23)
        Me.BTNACEP.TabIndex = 0
        Me.BTNACEP.Text = "Aceptar"
        Me.BTNACEP.UseVisualStyleBackColor = True
        '
        'BTNCANCE
        '
        Me.BTNCANCE.Location = New System.Drawing.Point(283, 185)
        Me.BTNCANCE.Name = "BTNCANCE"
        Me.BTNCANCE.Size = New System.Drawing.Size(75, 23)
        Me.BTNCANCE.TabIndex = 1
        Me.BTNCANCE.Text = "Cancelar"
        Me.BTNCANCE.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TXTPASSWORD_CONFIRMAR)
        Me.Panel1.Controls.Add(Me.BTNACEP)
        Me.Panel1.Controls.Add(Me.TXTPASSWORD_NUEVO)
        Me.Panel1.Controls.Add(Me.BTNCANCE)
        Me.Panel1.Controls.Add(Me.txtlogin)
        Me.Panel1.Controls.Add(Me.TXTPASSWORD)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(466, 242)
        Me.Panel1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(40, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Confirmar Nuevo Password:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(40, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nuevo Password:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(40, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 23)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Usuario:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(40, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Password Anterior:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTPASSWORD_CONFIRMAR
        '
        Me.TXTPASSWORD_CONFIRMAR.Location = New System.Drawing.Point(192, 133)
        Me.TXTPASSWORD_CONFIRMAR.Name = "TXTPASSWORD_CONFIRMAR"
        Me.TXTPASSWORD_CONFIRMAR.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTPASSWORD_CONFIRMAR.Size = New System.Drawing.Size(166, 20)
        Me.TXTPASSWORD_CONFIRMAR.TabIndex = 5
        '
        'TXTPASSWORD_NUEVO
        '
        Me.TXTPASSWORD_NUEVO.Location = New System.Drawing.Point(192, 95)
        Me.TXTPASSWORD_NUEVO.Name = "TXTPASSWORD_NUEVO"
        Me.TXTPASSWORD_NUEVO.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTPASSWORD_NUEVO.Size = New System.Drawing.Size(166, 20)
        Me.TXTPASSWORD_NUEVO.TabIndex = 4
        '
        'txtlogin
        '
        Me.txtlogin.Location = New System.Drawing.Point(192, 12)
        Me.txtlogin.Name = "txtlogin"
        Me.txtlogin.ReadOnly = True
        Me.txtlogin.Size = New System.Drawing.Size(166, 20)
        Me.txtlogin.TabIndex = 3
        '
        'TXTPASSWORD
        '
        Me.TXTPASSWORD.Location = New System.Drawing.Point(192, 55)
        Me.TXTPASSWORD.Name = "TXTPASSWORD"
        Me.TXTPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTPASSWORD.Size = New System.Drawing.Size(166, 20)
        Me.TXTPASSWORD.TabIndex = 3
        '
        'FrmCambiarPasswordInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 242)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCambiarPasswordInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Password..."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTNACEP As System.Windows.Forms.Button
    Friend WithEvents BTNCANCE As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTPASSWORD_CONFIRMAR As System.Windows.Forms.TextBox
    Friend WithEvents TXTPASSWORD_NUEVO As System.Windows.Forms.TextBox
    Friend WithEvents TXTPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtlogin As System.Windows.Forms.TextBox
End Class
