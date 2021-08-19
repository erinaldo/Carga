<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngreCargoAdi
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
        Me.MTBNRO_FACTURA = New System.Windows.Forms.MaskedTextBox
        Me.BTNCANCE = New System.Windows.Forms.Button
        Me.btnACEP = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MTBNRO_FACTURA
        '
        Me.MTBNRO_FACTURA.Location = New System.Drawing.Point(13, 31)
        Me.MTBNRO_FACTURA.Mask = "###-########"
        Me.MTBNRO_FACTURA.Name = "MTBNRO_FACTURA"
        Me.MTBNRO_FACTURA.Size = New System.Drawing.Size(77, 20)
        Me.MTBNRO_FACTURA.TabIndex = 22
        '
        'BTNCANCE
        '
        Me.BTNCANCE.Location = New System.Drawing.Point(91, 60)
        Me.BTNCANCE.Name = "BTNCANCE"
        Me.BTNCANCE.Size = New System.Drawing.Size(75, 31)
        Me.BTNCANCE.TabIndex = 24
        Me.BTNCANCE.Text = "Cancelar"
        Me.BTNCANCE.UseVisualStyleBackColor = True
        '
        'btnACEP
        '
        Me.btnACEP.Location = New System.Drawing.Point(10, 60)
        Me.btnACEP.Name = "btnACEP"
        Me.btnACEP.Size = New System.Drawing.Size(75, 31)
        Me.btnACEP.TabIndex = 23
        Me.btnACEP.Text = "Aceptar"
        Me.btnACEP.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(10, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Nro. Comprobante:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnACEP)
        Me.Panel1.Controls.Add(Me.BTNCANCE)
        Me.Panel1.Controls.Add(Me.MTBNRO_FACTURA)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(169, 103)
        Me.Panel1.TabIndex = 26
        '
        'FrmIngreCargoAdi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(169, 103)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmIngreCargoAdi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar cargos..."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MTBNRO_FACTURA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BTNCANCE As System.Windows.Forms.Button
    Friend WithEvents btnACEP As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
