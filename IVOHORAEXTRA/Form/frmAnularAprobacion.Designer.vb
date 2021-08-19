<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnularAprobacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rbtAutorizacion = New System.Windows.Forms.RadioButton()
        Me.rbtSolicitud = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rbtAutorizacion
        '
        Me.rbtAutorizacion.AutoSize = True
        Me.rbtAutorizacion.Checked = True
        Me.rbtAutorizacion.Location = New System.Drawing.Point(54, 42)
        Me.rbtAutorizacion.Name = "rbtAutorizacion"
        Me.rbtAutorizacion.Size = New System.Drawing.Size(83, 17)
        Me.rbtAutorizacion.TabIndex = 0
        Me.rbtAutorizacion.TabStop = True
        Me.rbtAutorizacion.Text = "Autorización"
        Me.rbtAutorizacion.UseVisualStyleBackColor = True
        '
        'rbtSolicitud
        '
        Me.rbtSolicitud.AutoSize = True
        Me.rbtSolicitud.Location = New System.Drawing.Point(184, 42)
        Me.rbtSolicitud.Name = "rbtSolicitud"
        Me.rbtSolicitud.Size = New System.Drawing.Size(65, 17)
        Me.rbtSolicitud.TabIndex = 0
        Me.rbtSolicitud.Text = "Solicitud"
        Me.rbtSolicitud.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(44, 114)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 30)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(189, 114)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 30)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmAnularAprobacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 178)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rbtSolicitud)
        Me.Controls.Add(Me.rbtAutorizacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnularAprobacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anular"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtAutorizacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSolicitud As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
