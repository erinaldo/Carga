<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoraExtraCompensar
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
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoCompensacion = New System.Windows.Forms.ComboBox()
        Me.cboHoras = New System.Windows.Forms.ComboBox()
        Me.lblVacaciones = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblDescanso = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(80, 279)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 29)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(209, 279)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(29, 131)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(100, 13)
        Me.Label72.TabIndex = 239
        Me.Label72.Text = "Horas a Compensar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(32, 186)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(297, 77)
        Me.txtObservacion.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 239
        Me.Label2.Text = "Fecha Compensación"
        '
        'dtpFecha
        '
        Me.dtpFecha.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFecha.Checked = False
        Me.dtpFecha.CustomFormat = ""
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(171, 64)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.ShowCheckBox = True
        Me.dtpFecha.Size = New System.Drawing.Size(102, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Tipo de Compensación"
        '
        'cboTipoCompensacion
        '
        Me.cboTipoCompensacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCompensacion.FormattingEnabled = True
        Me.cboTipoCompensacion.Items.AddRange(New Object() {"(SELECCIONE)", "EFECTIVO", "DESCANSO"})
        Me.cboTipoCompensacion.Location = New System.Drawing.Point(171, 95)
        Me.cboTipoCompensacion.Name = "cboTipoCompensacion"
        Me.cboTipoCompensacion.Size = New System.Drawing.Size(126, 21)
        Me.cboTipoCompensacion.TabIndex = 1
        '
        'cboHoras
        '
        Me.cboHoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHoras.FormattingEnabled = True
        Me.cboHoras.Location = New System.Drawing.Point(171, 127)
        Me.cboHoras.Name = "cboHoras"
        Me.cboHoras.Size = New System.Drawing.Size(126, 21)
        Me.cboHoras.TabIndex = 240
        '
        'lblVacaciones
        '
        Me.lblVacaciones.AutoSize = True
        Me.lblVacaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVacaciones.ForeColor = System.Drawing.Color.Red
        Me.lblVacaciones.Location = New System.Drawing.Point(256, 12)
        Me.lblVacaciones.Name = "lblVacaciones"
        Me.lblVacaciones.Size = New System.Drawing.Size(85, 13)
        Me.lblVacaciones.TabIndex = 239
        Me.lblVacaciones.Text = "VACACIONES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Horas a Compensar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "Efectivo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(126, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 239
        Me.Label7.Text = "Descanso"
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Location = New System.Drawing.Point(80, 37)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(34, 13)
        Me.lblEfectivo.TabIndex = 239
        Me.lblEfectivo.Text = "00:00"
        '
        'lblDescanso
        '
        Me.lblDescanso.AutoSize = True
        Me.lblDescanso.Location = New System.Drawing.Point(187, 37)
        Me.lblDescanso.Name = "lblDescanso"
        Me.lblDescanso.Size = New System.Drawing.Size(34, 13)
        Me.lblDescanso.TabIndex = 239
        Me.lblDescanso.Text = "00:00"
        '
        'frmHoraExtraCompensar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 326)
        Me.Controls.Add(Me.cboHoras)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.cboTipoCompensacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVacaciones)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblDescanso)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHoraExtraCompensar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compensación Horas Extras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCompensacion As System.Windows.Forms.ComboBox
    Friend WithEvents cboHoras As System.Windows.Forms.ComboBox
    Friend WithEvents lblVacaciones As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblDescanso As System.Windows.Forms.Label
End Class
