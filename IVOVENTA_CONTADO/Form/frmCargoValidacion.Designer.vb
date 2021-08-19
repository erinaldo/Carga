<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargoValidacion
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
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtSi = New System.Windows.Forms.RadioButton()
        Me.rbtNo = New System.Windows.Forms.RadioButton()
        Me.txtMensaje = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(31, 106)
        Me.txtMotivo.MaxLength = 100
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(293, 79)
        Me.txtMotivo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Motivo"
        '
        'rbtSi
        '
        Me.rbtSi.AutoSize = True
        Me.rbtSi.Checked = True
        Me.rbtSi.Location = New System.Drawing.Point(31, 60)
        Me.rbtSi.Name = "rbtSi"
        Me.rbtSi.Size = New System.Drawing.Size(34, 17)
        Me.rbtSi.TabIndex = 0
        Me.rbtSi.TabStop = True
        Me.rbtSi.Text = "Si"
        Me.rbtSi.UseVisualStyleBackColor = True
        '
        'rbtNo
        '
        Me.rbtNo.AutoSize = True
        Me.rbtNo.Location = New System.Drawing.Point(82, 60)
        Me.rbtNo.Name = "rbtNo"
        Me.rbtNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtNo.TabIndex = 1
        Me.rbtNo.Text = "No"
        Me.rbtNo.UseVisualStyleBackColor = True
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(28, 15)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(296, 41)
        Me.txtMensaje.TabIndex = 2
        Me.txtMensaje.Text = "Mensaje"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(137, 198)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 29)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmCargoValidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 241)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rbtNo)
        Me.Controls.Add(Me.rbtSi)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMotivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCargoValidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar Cargos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtSi As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNo As System.Windows.Forms.RadioButton
    Friend WithEvents txtMensaje As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
