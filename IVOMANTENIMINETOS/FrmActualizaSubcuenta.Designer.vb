<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActualizaSubcuenta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSubcuenta = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rbOrigen = New System.Windows.Forms.RadioButton()
        Me.rbDestino = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(32, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Nueva Subcuenta"
        '
        'cmbCiudad
        '
        Me.cmbCiudad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(150, 41)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(231, 21)
        Me.cmbCiudad.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(66, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ciudad"
        '
        'cmbSubcuenta
        '
        Me.cmbSubcuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSubcuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSubcuenta.DropDownHeight = 150
        Me.cmbSubcuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubcuenta.FormattingEnabled = True
        Me.cmbSubcuenta.IntegralHeight = False
        Me.cmbSubcuenta.Location = New System.Drawing.Point(150, 85)
        Me.cmbSubcuenta.Name = "cmbSubcuenta"
        Me.cmbSubcuenta.Size = New System.Drawing.Size(231, 21)
        Me.cmbSubcuenta.TabIndex = 13
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(103, 183)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 31)
        Me.btnAceptar.TabIndex = 17
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(286, 183)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 31)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'rbOrigen
        '
        Me.rbOrigen.AutoSize = True
        Me.rbOrigen.Location = New System.Drawing.Point(150, 136)
        Me.rbOrigen.Name = "rbOrigen"
        Me.rbOrigen.Size = New System.Drawing.Size(56, 17)
        Me.rbOrigen.TabIndex = 18
        Me.rbOrigen.Text = "Origen"
        Me.rbOrigen.UseVisualStyleBackColor = True
        '
        'rbDestino
        '
        Me.rbDestino.AutoSize = True
        Me.rbDestino.Checked = True
        Me.rbDestino.Location = New System.Drawing.Point(258, 136)
        Me.rbDestino.Name = "rbDestino"
        Me.rbDestino.Size = New System.Drawing.Size(61, 17)
        Me.rbDestino.TabIndex = 18
        Me.rbDestino.TabStop = True
        Me.rbDestino.Text = "Destino"
        Me.rbDestino.UseVisualStyleBackColor = True
        '
        'FrmActualizaSubcuenta
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(444, 235)
        Me.Controls.Add(Me.rbDestino)
        Me.Controls.Add(Me.rbOrigen)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbCiudad)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbSubcuenta)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmActualizaSubcuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar Subcuenta de Ventas no Facturadas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSubcuenta As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rbOrigen As System.Windows.Forms.RadioButton
    Friend WithEvents rbDestino As System.Windows.Forms.RadioButton
End Class
