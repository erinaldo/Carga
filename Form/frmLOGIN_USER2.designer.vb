<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLOGIN_USER
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Labversion = New System.Windows.Forms.Label()
        Me.PBImagen = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboAgencia = New System.Windows.Forms.ComboBox()
        Me.CboRol = New System.Windows.Forms.ComboBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.lblAgencia = New System.Windows.Forms.Label()
        Me.lblRol = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.txtPasswor = New System.Windows.Forms.TextBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PBImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Labversion)
        Me.Panel1.Controls.Add(Me.PBImagen)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(510, 191)
        Me.Panel1.TabIndex = 8
        Me.Panel1.TabStop = True
        '
        'Labversion
        '
        Me.Labversion.AutoSize = True
        Me.Labversion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labversion.ForeColor = System.Drawing.Color.Maroon
        Me.Labversion.Location = New System.Drawing.Point(12, 164)
        Me.Labversion.Name = "Labversion"
        Me.Labversion.Size = New System.Drawing.Size(178, 13)
        Me.Labversion.TabIndex = 21
        Me.Labversion.Text = "Ver.1.0.0.0  Fec. : 12/06/2020"
        '
        'PBImagen
        '
        Me.PBImagen.BackColor = System.Drawing.Color.Transparent
        Me.PBImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PBImagen.Location = New System.Drawing.Point(12, 10)
        Me.PBImagen.Name = "PBImagen"
        Me.PBImagen.Size = New System.Drawing.Size(159, 140)
        Me.PBImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PBImagen.TabIndex = 20
        Me.PBImagen.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Moccasin
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancelar.Location = New System.Drawing.Point(370, 153)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(123, 31)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar/Salir"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Moccasin
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btnAceptar.Location = New System.Drawing.Point(204, 153)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(123, 31)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cboAgencia)
        Me.GroupBox1.Controls.Add(Me.CboRol)
        Me.GroupBox1.Controls.Add(Me.txtLogin)
        Me.GroupBox1.Controls.Add(Me.lblAgencia)
        Me.GroupBox1.Controls.Add(Me.lblRol)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.lblLogin)
        Me.GroupBox1.Controls.Add(Me.txtPasswor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(191, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 142)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'cboAgencia
        '
        Me.cboAgencia.BackColor = System.Drawing.SystemColors.Info
        Me.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgencia.DropDownWidth = 220
        Me.cboAgencia.Enabled = False
        Me.cboAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgencia.FormattingEnabled = True
        Me.cboAgencia.Location = New System.Drawing.Point(114, 110)
        Me.cboAgencia.Name = "cboAgencia"
        Me.cboAgencia.Size = New System.Drawing.Size(177, 23)
        Me.cboAgencia.TabIndex = 3
        Me.cboAgencia.Visible = False
        '
        'CboRol
        '
        Me.CboRol.BackColor = System.Drawing.SystemColors.Info
        Me.CboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRol.DropDownWidth = 240
        Me.CboRol.Enabled = False
        Me.CboRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRol.FormattingEnabled = True
        Me.CboRol.Location = New System.Drawing.Point(114, 77)
        Me.CboRol.Name = "CboRol"
        Me.CboRol.Size = New System.Drawing.Size(177, 23)
        Me.CboRol.TabIndex = 2
        '
        'txtLogin
        '
        Me.txtLogin.AcceptsTab = True
        Me.txtLogin.BackColor = System.Drawing.SystemColors.Info
        Me.txtLogin.Location = New System.Drawing.Point(114, 17)
        Me.txtLogin.MaxLength = 30
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(177, 22)
        Me.txtLogin.TabIndex = 0
        '
        'lblAgencia
        '
        Me.lblAgencia.AutoSize = True
        Me.lblAgencia.BackColor = System.Drawing.Color.Transparent
        Me.lblAgencia.ForeColor = System.Drawing.Color.Maroon
        Me.lblAgencia.Location = New System.Drawing.Point(10, 113)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.Size = New System.Drawing.Size(74, 16)
        Me.lblAgencia.TabIndex = 15
        Me.lblAgencia.Text = "AGENCIA"
        Me.lblAgencia.Visible = False
        '
        'lblRol
        '
        Me.lblRol.AutoSize = True
        Me.lblRol.BackColor = System.Drawing.Color.Transparent
        Me.lblRol.ForeColor = System.Drawing.Color.Maroon
        Me.lblRol.Location = New System.Drawing.Point(10, 80)
        Me.lblRol.Name = "lblRol"
        Me.lblRol.Size = New System.Drawing.Size(38, 16)
        Me.lblRol.TabIndex = 15
        Me.lblRol.Text = "ROL"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.ForeColor = System.Drawing.Color.Maroon
        Me.lblPassword.Location = New System.Drawing.Point(10, 47)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(95, 16)
        Me.lblPassword.TabIndex = 15
        Me.lblPassword.Text = "PASSWORD"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.BackColor = System.Drawing.Color.Transparent
        Me.lblLogin.ForeColor = System.Drawing.Color.Maroon
        Me.lblLogin.Location = New System.Drawing.Point(8, 17)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(76, 16)
        Me.lblLogin.TabIndex = 18
        Me.lblLogin.Text = "USUARIO"
        '
        'txtPasswor
        '
        Me.txtPasswor.BackColor = System.Drawing.SystemColors.Info
        Me.txtPasswor.Location = New System.Drawing.Point(114, 47)
        Me.txtPasswor.MaxLength = 15
        Me.txtPasswor.Name = "txtPasswor"
        Me.txtPasswor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswor.Size = New System.Drawing.Size(177, 22)
        Me.txtPasswor.TabIndex = 1
        '
        'Timer
        '
        Me.Timer.Interval = 10
        '
        'frmLOGIN_USER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(506, 197)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLOGIN_USER"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACCESO"
        Me.TransparencyKey = System.Drawing.Color.DarkCyan
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PBImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents txtPasswor As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PBImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Labversion As System.Windows.Forms.Label
    Friend WithEvents CboRol As System.Windows.Forms.ComboBox
    Friend WithEvents lblRol As System.Windows.Forms.Label
    Friend WithEvents cboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgencia As System.Windows.Forms.Label
End Class
