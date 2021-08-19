<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfirmarBolFac
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnacep = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbboleta = New System.Windows.Forms.RadioButton
        Me.rbfactura = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnacep)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(223, 102)
        Me.Panel1.TabIndex = 1
        '
        'btnacep
        '
        Me.btnacep.Location = New System.Drawing.Point(136, 69)
        Me.btnacep.Name = "btnacep"
        Me.btnacep.Size = New System.Drawing.Size(75, 23)
        Me.btnacep.TabIndex = 0
        Me.btnacep.Text = "Aceptar"
        Me.btnacep.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbboleta)
        Me.GroupBox1.Controls.Add(Me.rbfactura)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rbboleta
        '
        Me.rbboleta.AutoSize = True
        Me.rbboleta.Location = New System.Drawing.Point(125, 19)
        Me.rbboleta.Name = "rbboleta"
        Me.rbboleta.Size = New System.Drawing.Size(67, 17)
        Me.rbboleta.TabIndex = 0
        Me.rbboleta.TabStop = True
        Me.rbboleta.Text = "BOLETA"
        Me.rbboleta.UseVisualStyleBackColor = True
        '
        'rbfactura
        '
        Me.rbfactura.AutoSize = True
        Me.rbfactura.Location = New System.Drawing.Point(6, 19)
        Me.rbfactura.Name = "rbfactura"
        Me.rbfactura.Size = New System.Drawing.Size(75, 17)
        Me.rbfactura.TabIndex = 0
        Me.rbfactura.TabStop = True
        Me.rbfactura.Text = "FACTURA"
        Me.rbfactura.UseVisualStyleBackColor = True
        '
        'FrmConfirmarBolFac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(223, 102)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfirmarBolFac"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Comprobante..."
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnacep As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbfactura As System.Windows.Forms.RadioButton
    Friend WithEvents rbboleta As System.Windows.Forms.RadioButton

End Class
