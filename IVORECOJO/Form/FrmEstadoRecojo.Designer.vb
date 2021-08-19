<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadoRecojo
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
        Me.LblMensaje = New System.Windows.Forms.Label
        Me.BtnSi = New System.Windows.Forms.Button
        Me.BtnNo = New System.Windows.Forms.Button
        Me.TxtObservacion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LblMensaje
        '
        Me.LblMensaje.Location = New System.Drawing.Point(12, 9)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(254, 45)
        Me.LblMensaje.TabIndex = 0
        Me.LblMensaje.Text = "Label1"
        '
        'BtnSi
        '
        Me.BtnSi.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.BtnSi.Location = New System.Drawing.Point(110, 146)
        Me.BtnSi.Name = "BtnSi"
        Me.BtnSi.Size = New System.Drawing.Size(75, 25)
        Me.BtnSi.TabIndex = 1
        Me.BtnSi.Text = "&Si"
        Me.BtnSi.UseVisualStyleBackColor = True
        '
        'BtnNo
        '
        Me.BtnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.BtnNo.Location = New System.Drawing.Point(191, 146)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(75, 25)
        Me.BtnNo.TabIndex = 2
        Me.BtnNo.Text = "&No"
        Me.BtnNo.UseVisualStyleBackColor = True
        '
        'TxtObservacion
        '
        Me.TxtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservacion.Location = New System.Drawing.Point(12, 83)
        Me.TxtObservacion.MaxLength = 100
        Me.TxtObservacion.Multiline = True
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(254, 56)
        Me.TxtObservacion.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Observación"
        '
        'FrmEstado
        '
        Me.AcceptButton = Me.BtnSi
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnNo
        Me.ClientSize = New System.Drawing.Size(279, 179)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtObservacion)
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.BtnSi)
        Me.Controls.Add(Me.LblMensaje)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEstado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents BtnSi As System.Windows.Forms.Button
    Friend WithEvents BtnNo As System.Windows.Forms.Button
    Friend WithEvents TxtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
