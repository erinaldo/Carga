<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobacionMultiple
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
        Me.lblFechaActivacion = New System.Windows.Forms.Label()
        Me.dtpFechaActivacion = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(97, 150)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 28)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(241, 150)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 28)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblFechaActivacion
        '
        Me.lblFechaActivacion.AutoSize = True
        Me.lblFechaActivacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaActivacion.ForeColor = System.Drawing.Color.Red
        Me.lblFechaActivacion.Location = New System.Drawing.Point(144, 86)
        Me.lblFechaActivacion.Name = "lblFechaActivacion"
        Me.lblFechaActivacion.Size = New System.Drawing.Size(130, 25)
        Me.lblFechaActivacion.TabIndex = 41
        Me.lblFechaActivacion.Text = "01/01/2014"
        '
        'dtpFechaActivacion
        '
        Me.dtpFechaActivacion.CalendarForeColor = System.Drawing.Color.Black
        Me.dtpFechaActivacion.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.dtpFechaActivacion.Checked = False
        Me.dtpFechaActivacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaActivacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActivacion.Location = New System.Drawing.Point(204, 43)
        Me.dtpFechaActivacion.Name = "dtpFechaActivacion"
        Me.dtpFechaActivacion.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaActivacion.TabIndex = 40
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(70, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(121, 13)
        Me.Label23.TabIndex = 39
        Me.Label23.Text = "Fecha Ingreso a Cartera"
        '
        'frmAprobacionMultiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 197)
        Me.Controls.Add(Me.lblFechaActivacion)
        Me.Controls.Add(Me.dtpFechaActivacion)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAprobacionMultiple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aprobación"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblFechaActivacion As System.Windows.Forms.Label
    Friend WithEvents dtpFechaActivacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
