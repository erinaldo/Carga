<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarioClave
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabClave = New System.Windows.Forms.TabControl()
        Me.tabGenerar = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabProbar = New System.Windows.Forms.TabPage()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnCancelar2 = New System.Windows.Forms.Button()
        Me.btnProbar = New System.Windows.Forms.Button()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.txtPatron = New System.Windows.Forms.TextBox()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tabClave.SuspendLayout()
        Me.tabGenerar.SuspendLayout()
        Me.tabProbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabClave
        '
        Me.tabClave.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabClave.Controls.Add(Me.tabGenerar)
        Me.tabClave.Controls.Add(Me.tabProbar)
        Me.tabClave.Location = New System.Drawing.Point(9, 9)
        Me.tabClave.Name = "tabClave"
        Me.tabClave.SelectedIndex = 0
        Me.tabClave.Size = New System.Drawing.Size(436, 228)
        Me.tabClave.TabIndex = 29
        '
        'tabGenerar
        '
        Me.tabGenerar.Controls.Add(Me.btnCancelar)
        Me.tabGenerar.Controls.Add(Me.btnAceptar)
        Me.tabGenerar.Controls.Add(Me.txtClave)
        Me.tabGenerar.Controls.Add(Me.lblUsuario)
        Me.tabGenerar.Controls.Add(Me.Label2)
        Me.tabGenerar.Controls.Add(Me.Label1)
        Me.tabGenerar.Location = New System.Drawing.Point(4, 22)
        Me.tabGenerar.Name = "tabGenerar"
        Me.tabGenerar.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGenerar.Size = New System.Drawing.Size(428, 202)
        Me.tabGenerar.TabIndex = 0
        Me.tabGenerar.Text = "Generar Clave"
        Me.tabGenerar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Location = New System.Drawing.Point(239, 150)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 31)
        Me.btnCancelar.TabIndex = 34
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.ForeColor = System.Drawing.Color.Black
        Me.btnAceptar.Location = New System.Drawing.Point(98, 150)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 31)
        Me.btnAceptar.TabIndex = 33
        Me.btnAceptar.Text = "&Grabar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(146, 78)
        Me.txtClave.MaxLength = 20
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(171, 20)
        Me.txtClave.TabIndex = 32
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(143, 31)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(174, 16)
        Me.lblUsuario.TabIndex = 29
        Me.lblUsuario.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(84, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Clave"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Usuario"
        '
        'tabProbar
        '
        Me.tabProbar.Controls.Add(Me.btnGenerar)
        Me.tabProbar.Controls.Add(Me.btnCancelar2)
        Me.tabProbar.Controls.Add(Me.btnProbar)
        Me.tabProbar.Controls.Add(Me.lblPatron)
        Me.tabProbar.Controls.Add(Me.txtPatron)
        Me.tabProbar.Controls.Add(Me.lblClave)
        Me.tabProbar.Controls.Add(Me.Label4)
        Me.tabProbar.Controls.Add(Me.Label3)
        Me.tabProbar.Location = New System.Drawing.Point(4, 22)
        Me.tabProbar.Name = "tabProbar"
        Me.tabProbar.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProbar.Size = New System.Drawing.Size(428, 202)
        Me.tabProbar.TabIndex = 1
        Me.tabProbar.Text = "Probar Clave"
        Me.tabProbar.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Enabled = False
        Me.btnGenerar.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.btnGenerar.Location = New System.Drawing.Point(329, 64)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(28, 23)
        Me.btnGenerar.TabIndex = 34
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnCancelar2
        '
        Me.btnCancelar2.Location = New System.Drawing.Point(282, 141)
        Me.btnCancelar2.Name = "btnCancelar2"
        Me.btnCancelar2.Size = New System.Drawing.Size(75, 28)
        Me.btnCancelar2.TabIndex = 2
        Me.btnCancelar2.Text = "Cancelar"
        Me.btnCancelar2.UseVisualStyleBackColor = True
        '
        'btnProbar
        '
        Me.btnProbar.Enabled = False
        Me.btnProbar.Location = New System.Drawing.Point(179, 141)
        Me.btnProbar.Name = "btnProbar"
        Me.btnProbar.Size = New System.Drawing.Size(75, 28)
        Me.btnProbar.TabIndex = 1
        Me.btnProbar.Text = "Probar"
        Me.btnProbar.UseVisualStyleBackColor = True
        '
        'lblPatron
        '
        Me.lblPatron.BackColor = System.Drawing.Color.Transparent
        Me.lblPatron.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatron.ForeColor = System.Drawing.Color.Black
        Me.lblPatron.Location = New System.Drawing.Point(179, 69)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(144, 13)
        Me.lblPatron.TabIndex = 33
        '
        'txtPatron
        '
        Me.txtPatron.BackColor = System.Drawing.Color.White
        Me.txtPatron.Enabled = False
        Me.txtPatron.Location = New System.Drawing.Point(179, 90)
        Me.txtPatron.MaxLength = 20
        Me.txtPatron.Name = "txtPatron"
        Me.txtPatron.Size = New System.Drawing.Size(178, 20)
        Me.txtPatron.TabIndex = 0
        '
        'lblClave
        '
        Me.lblClave.Location = New System.Drawing.Point(176, 38)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(181, 13)
        Me.lblClave.TabIndex = 31
        Me.lblClave.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Clave"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(89, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Clave"
        '
        'frmUsuarioClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 249)
        Me.Controls.Add(Me.tabClave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmUsuarioClave"
        Me.Text = "Clave"
        Me.tabClave.ResumeLayout(False)
        Me.tabGenerar.ResumeLayout(False)
        Me.tabGenerar.PerformLayout()
        Me.tabProbar.ResumeLayout(False)
        Me.tabProbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabClave As System.Windows.Forms.TabControl
    Friend WithEvents tabGenerar As System.Windows.Forms.TabPage
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabProbar As System.Windows.Forms.TabPage
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPatron As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPatron As System.Windows.Forms.Label
    Friend WithEvents btnProbar As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar2 As System.Windows.Forms.Button
End Class
