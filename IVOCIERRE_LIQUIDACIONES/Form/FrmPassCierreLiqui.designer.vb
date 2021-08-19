<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPassCierreLiqui
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
        Me.BtnCance = New System.Windows.Forms.Button()
        Me.BtnAcep = New System.Windows.Forms.Button()
        Me.TBPass = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCance
        '
        Me.BtnCance.BackColor = System.Drawing.Color.Transparent
        Me.BtnCance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCance.Location = New System.Drawing.Point(201, 41)
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
        Me.BtnAcep.Location = New System.Drawing.Point(201, 7)
        Me.BtnAcep.Name = "BtnAcep"
        Me.BtnAcep.Size = New System.Drawing.Size(79, 28)
        Me.BtnAcep.TabIndex = 1
        Me.BtnAcep.Text = "Aceptar"
        Me.BtnAcep.UseVisualStyleBackColor = False
        '
        'TBPass
        '
        Me.TBPass.Location = New System.Drawing.Point(63, 12)
        Me.TBPass.Name = "TBPass"
        Me.TBPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TBPass.Size = New System.Drawing.Size(132, 20)
        Me.TBPass.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnCance)
        Me.Panel1.Controls.Add(Me.BtnAcep)
        Me.Panel1.Controls.Add(Me.TBPass)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 80)
        Me.Panel1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Password:"
        '
        'FrmPassCierreLiqui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuBar
        Me.ClientSize = New System.Drawing.Size(292, 80)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmPassCierreLiqui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Password"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCance As System.Windows.Forms.Button
    Friend WithEvents BtnAcep As System.Windows.Forms.Button
    Friend WithEvents TBPass As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
