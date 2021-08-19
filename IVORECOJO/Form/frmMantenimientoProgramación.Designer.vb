<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoProgramacion
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
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDia = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtVolumen = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtBultos = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpHora1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpHora2 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(52, 217)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 26)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(178, 217)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 26)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Día"
        '
        'cboDia
        '
        Me.cboDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDia.FormattingEnabled = True
        Me.cboDia.Items.AddRange(New Object() {"(SELECCIONE)", "LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO", "DOMINGO"})
        Me.cboDia.Location = New System.Drawing.Point(128, 17)
        Me.cboDia.Name = "cboDia"
        Me.cboDia.Size = New System.Drawing.Size(112, 21)
        Me.cboDia.TabIndex = 0
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Location = New System.Drawing.Point(56, 59)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 13)
        Me.Label38.TabIndex = 165
        Me.Label38.Text = "Hora Listo"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(56, 85)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(60, 13)
        Me.Label26.TabIndex = 166
        Me.Label26.Text = "Hora Cierre"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(56, 172)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 187
        Me.Label20.Text = "Volúmen"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(56, 146)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "Peso"
        '
        'txtVolumen
        '
        Me.txtVolumen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVolumen.Location = New System.Drawing.Point(128, 169)
        Me.txtVolumen.MaxLength = 10
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(90, 20)
        Me.txtVolumen.TabIndex = 5
        Me.txtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeso
        '
        Me.txtPeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPeso.Location = New System.Drawing.Point(128, 143)
        Me.txtPeso.MaxLength = 10
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(90, 20)
        Me.txtPeso.TabIndex = 4
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBultos
        '
        Me.txtBultos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBultos.Location = New System.Drawing.Point(128, 117)
        Me.txtBultos.MaxLength = 5
        Me.txtBultos.Name = "txtBultos"
        Me.txtBultos.Size = New System.Drawing.Size(90, 20)
        Me.txtBultos.TabIndex = 3
        Me.txtBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(56, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 185
        Me.Label13.Text = "Cantidad"
        '
        'dtpHora1
        '
        Me.dtpHora1.CustomFormat = "HH:mm"
        Me.dtpHora1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHora1.Location = New System.Drawing.Point(128, 55)
        Me.dtpHora1.Name = "dtpHora1"
        Me.dtpHora1.Size = New System.Drawing.Size(86, 20)
        Me.dtpHora1.TabIndex = 1
        '
        'dtpHora2
        '
        Me.dtpHora2.CustomFormat = "HH:mm"
        Me.dtpHora2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHora2.Location = New System.Drawing.Point(127, 82)
        Me.dtpHora2.Name = "dtpHora2"
        Me.dtpHora2.Size = New System.Drawing.Size(87, 20)
        Me.dtpHora2.TabIndex = 2
        '
        'frmMantenimientoProgramacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 259)
        Me.Controls.Add(Me.dtpHora2)
        Me.Controls.Add(Me.dtpHora1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtVolumen)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.txtBultos)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cboDia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMantenimientoProgramacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Programación"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDia As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtBultos As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpHora1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHora2 As System.Windows.Forms.DateTimePicker
End Class
