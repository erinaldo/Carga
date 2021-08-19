<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesicionSeguridad
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
        Me.BtnCance = New System.Windows.Forms.Button
        Me.BtnAcep = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rbcontra = New System.Windows.Forms.RadioButton
        Me.rbpregun = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCance
        '
        Me.BtnCance.BackColor = System.Drawing.Color.Transparent
        Me.BtnCance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCance.Location = New System.Drawing.Point(165, 49)
        Me.BtnCance.Name = "BtnCance"
        Me.BtnCance.Size = New System.Drawing.Size(79, 28)
        Me.BtnCance.TabIndex = 2
        Me.BtnCance.Text = "Cancelar"
        Me.BtnCance.UseVisualStyleBackColor = False
        '
        'BtnAcep
        '
        Me.BtnAcep.BackColor = System.Drawing.Color.Transparent
        Me.BtnAcep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAcep.Location = New System.Drawing.Point(80, 49)
        Me.BtnAcep.Name = "BtnAcep"
        Me.BtnAcep.Size = New System.Drawing.Size(79, 28)
        Me.BtnAcep.TabIndex = 1
        Me.BtnAcep.Text = "Aceptar"
        Me.BtnAcep.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbpregun)
        Me.Panel1.Controls.Add(Me.rbcontra)
        Me.Panel1.Controls.Add(Me.BtnCance)
        Me.Panel1.Controls.Add(Me.BtnAcep)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(252, 83)
        Me.Panel1.TabIndex = 6
        '
        'rbcontra
        '
        Me.rbcontra.AutoSize = True
        Me.rbcontra.BackColor = System.Drawing.Color.Transparent
        Me.rbcontra.Location = New System.Drawing.Point(12, 3)
        Me.rbcontra.Name = "rbcontra"
        Me.rbcontra.Size = New System.Drawing.Size(79, 17)
        Me.rbcontra.TabIndex = 3
        Me.rbcontra.TabStop = True
        Me.rbcontra.Text = "Contraseña"
        Me.rbcontra.UseVisualStyleBackColor = False
        '
        'rbpregun
        '
        Me.rbpregun.AutoSize = True
        Me.rbpregun.BackColor = System.Drawing.Color.Transparent
        Me.rbpregun.Location = New System.Drawing.Point(12, 26)
        Me.rbpregun.Name = "rbpregun"
        Me.rbpregun.Size = New System.Drawing.Size(163, 17)
        Me.rbpregun.TabIndex = 3
        Me.rbpregun.TabStop = True
        Me.rbpregun.Text = "Pregunta y respuesta secreta"
        Me.rbpregun.UseVisualStyleBackColor = False
        '
        'FrmDesicionSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuBar
        Me.ClientSize = New System.Drawing.Size(252, 83)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmDesicionSeguridad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seguridad de Giro...."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCance As System.Windows.Forms.Button
    Friend WithEvents BtnAcep As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbpregun As System.Windows.Forms.RadioButton
    Friend WithEvents rbcontra As System.Windows.Forms.RadioButton
End Class
