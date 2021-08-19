<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoraExtraConvenio
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
        Me.txtConvenio = New System.Windows.Forms.RichTextBox()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.chkAceptar = New System.Windows.Forms.CheckBox()
        Me.pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtConvenio
        '
        Me.txtConvenio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConvenio.Location = New System.Drawing.Point(7, 8)
        Me.txtConvenio.Name = "txtConvenio"
        Me.txtConvenio.Size = New System.Drawing.Size(1053, 403)
        Me.txtConvenio.TabIndex = 0
        Me.txtConvenio.Text = ""
        '
        'pnl
        '
        Me.pnl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl.Controls.Add(Me.btnCancelar)
        Me.pnl.Controls.Add(Me.btnAceptar)
        Me.pnl.Controls.Add(Me.chkAceptar)
        Me.pnl.Location = New System.Drawing.Point(7, 415)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(1055, 48)
        Me.pnl.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(721, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 28)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(572, 10)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 28)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'chkAceptar
        '
        Me.chkAceptar.AutoSize = True
        Me.chkAceptar.Location = New System.Drawing.Point(338, 17)
        Me.chkAceptar.Name = "chkAceptar"
        Me.chkAceptar.Size = New System.Drawing.Size(111, 17)
        Me.chkAceptar.TabIndex = 0
        Me.chkAceptar.Text = "Aceptar Convenio"
        Me.chkAceptar.UseVisualStyleBackColor = True
        '
        'frmHoraExtraConvenio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 468)
        Me.Controls.Add(Me.txtConvenio)
        Me.Controls.Add(Me.pnl)
        Me.Name = "frmHoraExtraConvenio"
        Me.Text = "Convenio Privado de Compensación de Horas Extras"
        Me.pnl.ResumeLayout(False)
        Me.pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtConvenio As System.Windows.Forms.RichTextBox
    Friend WithEvents pnl As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents chkAceptar As System.Windows.Forms.CheckBox
End Class
