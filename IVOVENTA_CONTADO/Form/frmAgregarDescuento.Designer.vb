<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarDescuento
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
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtDescuento = New System.Windows.Forms.TextBox()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.lbDescDescto = New System.Windows.Forms.Label()
        Me.txtDescDescto = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(62, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Porcentaje"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescuento.Location = New System.Drawing.Point(129, 33)
        Me.TxtDescuento.MaxLength = 7
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(84, 20)
        Me.TxtDescuento.TabIndex = 0
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Enabled = False
        Me.btnAutorizar.Image = Global.INTEGRACION.My.Resources.Resources.ocupado
        Me.btnAutorizar.Location = New System.Drawing.Point(319, 81)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(25, 23)
        Me.btnAutorizar.TabIndex = 1
        Me.btnAutorizar.Text = "..."
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'lbDescDescto
        '
        Me.lbDescDescto.AutoSize = True
        Me.lbDescDescto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescDescto.ForeColor = System.Drawing.Color.Black
        Me.lbDescDescto.Location = New System.Drawing.Point(62, 84)
        Me.lbDescDescto.Name = "lbDescDescto"
        Me.lbDescDescto.Size = New System.Drawing.Size(45, 13)
        Me.lbDescDescto.TabIndex = 50
        Me.lbDescDescto.Text = "Autoriza"
        '
        'txtDescDescto
        '
        Me.txtDescDescto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescDescto.Enabled = False
        Me.txtDescDescto.Location = New System.Drawing.Point(129, 82)
        Me.txtDescDescto.MaxLength = 50
        Me.txtDescDescto.Name = "txtDescDescto"
        Me.txtDescDescto.Size = New System.Drawing.Size(187, 20)
        Me.txtDescDescto.TabIndex = 51
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(72, 144)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 31)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(230, 144)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 31)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmAgregarDescuento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 210)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnAutorizar)
        Me.Controls.Add(Me.lbDescDescto)
        Me.Controls.Add(Me.txtDescDescto)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtDescuento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarDescuento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descuento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents lbDescDescto As System.Windows.Forms.Label
    Friend WithEvents txtDescDescto As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
