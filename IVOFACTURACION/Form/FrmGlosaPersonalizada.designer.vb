<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlosaPersonalizada
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
        Me.BtnCance = New System.Windows.Forms.Button()
        Me.BtnAcep = New System.Windows.Forms.Button()
        Me.RTB = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnCance)
        Me.Panel1.Controls.Add(Me.BtnAcep)
        Me.Panel1.Controls.Add(Me.RTB)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(465, 180)
        Me.Panel1.TabIndex = 0
        '
        'BtnCance
        '
        Me.BtnCance.Location = New System.Drawing.Point(382, 144)
        Me.BtnCance.Name = "BtnCance"
        Me.BtnCance.Size = New System.Drawing.Size(75, 30)
        Me.BtnCance.TabIndex = 2
        Me.BtnCance.Text = "Cancelar"
        Me.BtnCance.UseVisualStyleBackColor = True
        '
        'BtnAcep
        '
        Me.BtnAcep.Location = New System.Drawing.Point(301, 144)
        Me.BtnAcep.Name = "BtnAcep"
        Me.BtnAcep.Size = New System.Drawing.Size(75, 30)
        Me.BtnAcep.TabIndex = 1
        Me.BtnAcep.Text = "Aceptar"
        Me.BtnAcep.UseVisualStyleBackColor = True
        '
        'RTB
        '
        Me.RTB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTB.Location = New System.Drawing.Point(3, 12)
        Me.RTB.MaxLength = 255
        Me.RTB.Name = "RTB"
        Me.RTB.Size = New System.Drawing.Size(454, 127)
        Me.RTB.TabIndex = 0
        Me.RTB.Text = ""
        '
        'FrmGlosaPersonalizada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 180)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGlosaPersonalizada"
        Me.Text = "Glosa"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCance As System.Windows.Forms.Button
    Friend WithEvents BtnAcep As System.Windows.Forms.Button
    Friend WithEvents RTB As System.Windows.Forms.RichTextBox
End Class
