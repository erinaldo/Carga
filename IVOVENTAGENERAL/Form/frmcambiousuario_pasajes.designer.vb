<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcambiousuario_pasajes
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
        Me.txtidusuario_personal_actual = New System.Windows.Forms.TextBox
        Me.txtusuario_actual = New System.Windows.Forms.TextBox
        Me.cmbusuario_nuevo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.txtidventa_pasaje = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtidusuario_personal_actual
        '
        Me.txtidusuario_personal_actual.BackColor = System.Drawing.SystemColors.Info
        Me.txtidusuario_personal_actual.Location = New System.Drawing.Point(12, 3)
        Me.txtidusuario_personal_actual.Name = "txtidusuario_personal_actual"
        Me.txtidusuario_personal_actual.ReadOnly = True
        Me.txtidusuario_personal_actual.Size = New System.Drawing.Size(81, 20)
        Me.txtidusuario_personal_actual.TabIndex = 0
        Me.txtidusuario_personal_actual.Visible = False
        '
        'txtusuario_actual
        '
        Me.txtusuario_actual.BackColor = System.Drawing.SystemColors.Info
        Me.txtusuario_actual.Location = New System.Drawing.Point(93, 37)
        Me.txtusuario_actual.Name = "txtusuario_actual"
        Me.txtusuario_actual.ReadOnly = True
        Me.txtusuario_actual.Size = New System.Drawing.Size(196, 20)
        Me.txtusuario_actual.TabIndex = 1
        '
        'cmbusuario_nuevo
        '
        Me.cmbusuario_nuevo.FormattingEnabled = True
        Me.cmbusuario_nuevo.Location = New System.Drawing.Point(93, 74)
        Me.cmbusuario_nuevo.Name = "cmbusuario_nuevo"
        Me.cmbusuario_nuevo.Size = New System.Drawing.Size(196, 21)
        Me.cmbusuario_nuevo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Location = New System.Drawing.Point(4, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usuario Actual : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label2.Location = New System.Drawing.Point(4, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Usuario Nuevo : "
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(214, 107)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnaceptar
        '
        Me.btnaceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnaceptar.Location = New System.Drawing.Point(133, 107)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnaceptar.TabIndex = 6
        Me.btnaceptar.Text = "&Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = False
        '
        'txtidventa_pasaje
        '
        Me.txtidventa_pasaje.BackColor = System.Drawing.SystemColors.Info
        Me.txtidventa_pasaje.Location = New System.Drawing.Point(208, 3)
        Me.txtidventa_pasaje.Name = "txtidventa_pasaje"
        Me.txtidventa_pasaje.ReadOnly = True
        Me.txtidventa_pasaje.Size = New System.Drawing.Size(81, 20)
        Me.txtidventa_pasaje.TabIndex = 7
        Me.txtidventa_pasaje.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnaceptar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 141)
        Me.Panel1.TabIndex = 0
        '
        'frmcambiousuario_pasajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 142)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtidventa_pasaje)
        Me.Controls.Add(Me.cmbusuario_nuevo)
        Me.Controls.Add(Me.txtusuario_actual)
        Me.Controls.Add(Me.txtidusuario_personal_actual)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcambiousuario_pasajes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Usuario - Venta Pasaje"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtidusuario_personal_actual As System.Windows.Forms.TextBox
    Friend WithEvents txtusuario_actual As System.Windows.Forms.TextBox
    Friend WithEvents cmbusuario_nuevo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents txtidventa_pasaje As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
