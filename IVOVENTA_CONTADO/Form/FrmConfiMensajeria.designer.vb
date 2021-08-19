<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiMensajeria
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
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtActivado = New System.Windows.Forms.RadioButton()
        Me.rbtDesactivado = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.txtNumero)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 181)
        Me.Panel1.TabIndex = 91
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(9, 76)
        Me.txtNumero.MaxLength = 12
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(226, 20)
        Me.txtNumero.TabIndex = 3
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnAceptar.Location = New System.Drawing.Point(78, 122)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 34)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbtActivado)
        Me.GroupBox1.Controls.Add(Me.rbtDesactivado)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 44)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensajeria"
        '
        'rbtActivado
        '
        Me.rbtActivado.AutoSize = True
        Me.rbtActivado.Checked = True
        Me.rbtActivado.Location = New System.Drawing.Point(8, 17)
        Me.rbtActivado.Name = "rbtActivado"
        Me.rbtActivado.Size = New System.Drawing.Size(67, 17)
        Me.rbtActivado.TabIndex = 0
        Me.rbtActivado.TabStop = True
        Me.rbtActivado.Text = "Activado"
        Me.rbtActivado.UseVisualStyleBackColor = True
        '
        'rbtDesactivado
        '
        Me.rbtDesactivado.AutoSize = True
        Me.rbtDesactivado.Location = New System.Drawing.Point(123, 17)
        Me.rbtDesactivado.Name = "rbtDesactivado"
        Me.rbtDesactivado.Size = New System.Drawing.Size(85, 17)
        Me.rbtDesactivado.TabIndex = 1
        Me.rbtDesactivado.Text = "Desactivado"
        Me.rbtDesactivado.UseVisualStyleBackColor = True
        '
        'FrmConfiMensajeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(247, 181)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmConfiMensajeria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Datos para Mensajería"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtActivado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDesactivado As System.Windows.Forms.RadioButton
End Class
