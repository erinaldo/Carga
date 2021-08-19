<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevolucionDinero
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
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.cboDevolucionDinero = New System.Windows.Forms.ComboBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(176, 117)
        Me.txtMonto.MaxLength = 9
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(107, 20)
        Me.txtMonto.TabIndex = 1
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDevolucionDinero
        '
        Me.cboDevolucionDinero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevolucionDinero.FormattingEnabled = True
        Me.cboDevolucionDinero.Items.AddRange(New Object() {"(SELECCIONE)", "SI ", "NO"})
        Me.cboDevolucionDinero.Location = New System.Drawing.Point(176, 65)
        Me.cboDevolucionDinero.Name = "cboDevolucionDinero"
        Me.cboDevolucionDinero.Size = New System.Drawing.Size(107, 21)
        Me.cboDevolucionDinero.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(173, 22)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(95, 13)
        Me.lblTotal.TabIndex = 114
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(42, 120)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(37, 13)
        Me.Label49.TabIndex = 115
        Me.Label49.Text = "Monto"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(42, 69)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(110, 13)
        Me.Label36.TabIndex = 116
        Me.Label36.Text = "Devolución de Dinero"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(42, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(97, 13)
        Me.Label29.TabIndex = 117
        Me.Label29.Text = "Total Comprobante"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(54, 206)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 33)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(189, 206)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 33)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Monto a devolver"
        '
        'lblMonto
        '
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(173, 161)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(110, 13)
        Me.lblMonto.TabIndex = 115
        Me.lblMonto.Text = "0.00"
        Me.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDevolucionDinero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 257)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.cboDevolucionDinero)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label29)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDevolucionDinero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolución de Dinero"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents cboDevolucionDinero As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
End Class
