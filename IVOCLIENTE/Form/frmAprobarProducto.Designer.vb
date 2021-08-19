<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobarProducto
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
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.chkActualizar = New System.Windows.Forms.CheckBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.lblMensaje2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(42, 145)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 32)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(195, 145)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 32)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'chkActualizar
        '
        Me.chkActualizar.AutoSize = True
        Me.chkActualizar.Location = New System.Drawing.Point(102, 85)
        Me.chkActualizar.Name = "chkActualizar"
        Me.chkActualizar.Size = New System.Drawing.Size(103, 17)
        Me.chkActualizar.TabIndex = 1
        Me.chkActualizar.Text = "Actualizar Venta"
        Me.chkActualizar.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(30, 21)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(270, 53)
        Me.lblMensaje.TabIndex = 2
        Me.lblMensaje.Text = "Label1"
        '
        'lblMensaje2
        '
        Me.lblMensaje2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje2.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje2.Location = New System.Drawing.Point(16, 106)
        Me.lblMensaje2.Name = "lblMensaje2"
        Me.lblMensaje2.Size = New System.Drawing.Size(285, 33)
        Me.lblMensaje2.TabIndex = 3
        Me.lblMensaje2.Text = "No se Actualizará las Ventas"
        Me.lblMensaje2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAprobarProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 190)
        Me.Controls.Add(Me.lblMensaje2)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.chkActualizar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAprobarProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aprobar Solicitud: Asignar Producto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents chkActualizar As System.Windows.Forms.CheckBox
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblMensaje2 As System.Windows.Forms.Label
End Class
