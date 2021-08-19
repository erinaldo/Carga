<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBase
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
        Me.btnNo = New System.Windows.Forms.Button
        Me.btnSi = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtDocumento = New System.Windows.Forms.TextBox
        Me.chkMontoBase = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.SystemColors.Control
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNo.ForeColor = System.Drawing.Color.Maroon
        Me.btnNo.Location = New System.Drawing.Point(375, 106)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 32)
        Me.btnNo.TabIndex = 2
        Me.btnNo.Text = "&Cancelar"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'btnSi
        '
        Me.btnSi.BackColor = System.Drawing.SystemColors.Control
        Me.btnSi.ForeColor = System.Drawing.Color.Maroon
        Me.btnSi.Location = New System.Drawing.Point(269, 106)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(75, 32)
        Me.btnSi.TabIndex = 1
        Me.btnSi.Text = "&Aceptar"
        Me.btnSi.UseVisualStyleBackColor = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(132, 12)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(321, 20)
        Me.txtCliente.TabIndex = 7
        Me.txtCliente.TabStop = False
        '
        'txtDocumento
        '
        Me.txtDocumento.BackColor = System.Drawing.SystemColors.Info
        Me.txtDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Location = New System.Drawing.Point(57, 12)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.ReadOnly = True
        Me.txtDocumento.Size = New System.Drawing.Size(77, 20)
        Me.txtDocumento.TabIndex = 6
        Me.txtDocumento.TabStop = False
        '
        'chkMontoBase
        '
        Me.chkMontoBase.AutoSize = True
        Me.chkMontoBase.BackColor = System.Drawing.Color.Transparent
        Me.chkMontoBase.ForeColor = System.Drawing.Color.Maroon
        Me.chkMontoBase.Location = New System.Drawing.Point(206, 59)
        Me.chkMontoBase.Name = "chkMontoBase"
        Me.chkMontoBase.Size = New System.Drawing.Size(138, 17)
        Me.chkMontoBase.TabIndex = 0
        Me.chkMontoBase.Text = "¿Afecto a Monto Base?"
        Me.chkMontoBase.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkMontoBase)
        Me.Panel1.Controls.Add(Me.btnSi)
        Me.Panel1.Controls.Add(Me.btnNo)
        Me.Panel1.Location = New System.Drawing.Point(3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(461, 149)
        Me.Panel1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(9, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cliente"
        '
        'FrmBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 153)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtDocumento)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Monto Base"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents btnSi As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents chkMontoBase As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
