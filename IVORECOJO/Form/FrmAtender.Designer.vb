<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAtender
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
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAtendidoPor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.RbtAtendido = New System.Windows.Forms.RadioButton()
        Me.RbtNoAtendido = New System.Windows.Forms.RadioButton()
        Me.PnlAtendido = New System.Windows.Forms.Panel()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.ChkParcial = New System.Windows.Forms.CheckBox()
        Me.BtnSi = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.PnlNoAtendido = New System.Windows.Forms.Panel()
        Me.CboIncidencia = New System.Windows.Forms.ComboBox()
        Me.TxtObservacion2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DtpHora2 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.GrbAtender = New System.Windows.Forms.GroupBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.BtnNo = New System.Windows.Forms.Button()
        Me.BtnSiaTodo = New System.Windows.Forms.Button()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PnlAtendido.SuspendLayout()
        Me.PnlNoAtendido.SuspendLayout()
        Me.GrbAtender.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtContacto
        '
        Me.TxtContacto.Location = New System.Drawing.Point(83, 34)
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.ReadOnly = True
        Me.TxtContacto.Size = New System.Drawing.Size(324, 20)
        Me.TxtContacto.TabIndex = 1
        Me.TxtContacto.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Contacto"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(83, 9)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(324, 20)
        Me.TxtCliente.TabIndex = 0
        Me.TxtCliente.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Cliente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Dirección"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(83, 60)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(324, 20)
        Me.TxtDireccion.TabIndex = 2
        Me.TxtDireccion.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Atendido por"
        '
        'TxtAtendidoPor
        '
        Me.TxtAtendidoPor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAtendidoPor.Location = New System.Drawing.Point(76, 43)
        Me.TxtAtendidoPor.MaxLength = 60
        Me.TxtAtendidoPor.Name = "TxtAtendidoPor"
        Me.TxtAtendidoPor.Size = New System.Drawing.Size(316, 20)
        Me.TxtAtendidoPor.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Fecha"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Observación"
        '
        'TxtObservacion
        '
        Me.TxtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservacion.Location = New System.Drawing.Point(76, 78)
        Me.TxtObservacion.MaxLength = 100
        Me.TxtObservacion.Multiline = True
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(316, 20)
        Me.TxtObservacion.TabIndex = 7
        '
        'RbtAtendido
        '
        Me.RbtAtendido.AutoSize = True
        Me.RbtAtendido.Checked = True
        Me.RbtAtendido.Location = New System.Drawing.Point(8, 14)
        Me.RbtAtendido.Name = "RbtAtendido"
        Me.RbtAtendido.Size = New System.Drawing.Size(67, 17)
        Me.RbtAtendido.TabIndex = 0
        Me.RbtAtendido.TabStop = True
        Me.RbtAtendido.Text = "Atendido"
        Me.RbtAtendido.UseVisualStyleBackColor = True
        '
        'RbtNoAtendido
        '
        Me.RbtNoAtendido.AutoSize = True
        Me.RbtNoAtendido.Location = New System.Drawing.Point(78, 14)
        Me.RbtNoAtendido.Name = "RbtNoAtendido"
        Me.RbtNoAtendido.Size = New System.Drawing.Size(84, 17)
        Me.RbtNoAtendido.TabIndex = 1
        Me.RbtNoAtendido.Text = "No Atendido"
        Me.RbtNoAtendido.UseVisualStyleBackColor = True
        '
        'PnlAtendido
        '
        Me.PnlAtendido.Controls.Add(Me.LblFecha)
        Me.PnlAtendido.Controls.Add(Me.ChkParcial)
        Me.PnlAtendido.Controls.Add(Me.TxtObservacion)
        Me.PnlAtendido.Controls.Add(Me.Label6)
        Me.PnlAtendido.Controls.Add(Me.Label7)
        Me.PnlAtendido.Controls.Add(Me.Label9)
        Me.PnlAtendido.Controls.Add(Me.TxtAtendidoPor)
        Me.PnlAtendido.Location = New System.Drawing.Point(2, 37)
        Me.PnlAtendido.Name = "PnlAtendido"
        Me.PnlAtendido.Size = New System.Drawing.Size(400, 146)
        Me.PnlAtendido.TabIndex = 35
        '
        'LblFecha
        '
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.Red
        Me.LblFecha.Location = New System.Drawing.Point(76, 7)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(100, 15)
        Me.LblFecha.TabIndex = 32
        Me.LblFecha.Text = "01/01/2011"
        '
        'ChkParcial
        '
        Me.ChkParcial.AutoSize = True
        Me.ChkParcial.Location = New System.Drawing.Point(338, 6)
        Me.ChkParcial.Name = "ChkParcial"
        Me.ChkParcial.Size = New System.Drawing.Size(58, 17)
        Me.ChkParcial.TabIndex = 0
        Me.ChkParcial.Text = "Parcial"
        Me.ChkParcial.UseVisualStyleBackColor = True
        '
        'BtnSi
        '
        Me.BtnSi.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.BtnSi.Location = New System.Drawing.Point(47, 277)
        Me.BtnSi.Name = "BtnSi"
        Me.BtnSi.Size = New System.Drawing.Size(75, 24)
        Me.BtnSi.TabIndex = 12
        Me.BtnSi.Text = "&Aceptar"
        Me.BtnSi.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(314, 277)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'PnlNoAtendido
        '
        Me.PnlNoAtendido.Controls.Add(Me.cboTipo)
        Me.PnlNoAtendido.Controls.Add(Me.CboIncidencia)
        Me.PnlNoAtendido.Controls.Add(Me.TxtObservacion2)
        Me.PnlNoAtendido.Controls.Add(Me.Label12)
        Me.PnlNoAtendido.Controls.Add(Me.Label3)
        Me.PnlNoAtendido.Controls.Add(Me.Label4)
        Me.PnlNoAtendido.Controls.Add(Me.Label10)
        Me.PnlNoAtendido.Controls.Add(Me.DtpHora2)
        Me.PnlNoAtendido.Controls.Add(Me.Label11)
        Me.PnlNoAtendido.Controls.Add(Me.DtpFecha2)
        Me.PnlNoAtendido.Location = New System.Drawing.Point(2, 37)
        Me.PnlNoAtendido.Name = "PnlNoAtendido"
        Me.PnlNoAtendido.Size = New System.Drawing.Size(400, 142)
        Me.PnlNoAtendido.TabIndex = 35
        '
        'CboIncidencia
        '
        Me.CboIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboIncidencia.FormattingEnabled = True
        Me.CboIncidencia.Location = New System.Drawing.Point(231, 38)
        Me.CboIncidencia.Name = "CboIncidencia"
        Me.CboIncidencia.Size = New System.Drawing.Size(161, 21)
        Me.CboIncidencia.TabIndex = 10
        '
        'TxtObservacion2
        '
        Me.TxtObservacion2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservacion2.Location = New System.Drawing.Point(76, 76)
        Me.TxtObservacion2.MaxLength = 100
        Me.TxtObservacion2.Multiline = True
        Me.TxtObservacion2.Name = "TxtObservacion2"
        Me.TxtObservacion2.Size = New System.Drawing.Size(317, 46)
        Me.TxtObservacion2.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(185, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Motivo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Fecha"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Observación"
        '
        'DtpHora2
        '
        Me.DtpHora2.CustomFormat = "hh:mm tt"
        Me.DtpHora2.Enabled = False
        Me.DtpHora2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHora2.Location = New System.Drawing.Point(231, 3)
        Me.DtpHora2.Name = "DtpHora2"
        Me.DtpHora2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DtpHora2.ShowUpDown = True
        Me.DtpHora2.Size = New System.Drawing.Size(77, 20)
        Me.DtpHora2.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(185, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Hora"
        '
        'DtpFecha2
        '
        Me.DtpFecha2.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DtpFecha2.CustomFormat = ""
        Me.DtpFecha2.Enabled = False
        Me.DtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha2.Location = New System.Drawing.Point(76, 3)
        Me.DtpFecha2.Name = "DtpFecha2"
        Me.DtpFecha2.Size = New System.Drawing.Size(87, 20)
        Me.DtpFecha2.TabIndex = 7
        '
        'GrbAtender
        '
        Me.GrbAtender.Controls.Add(Me.LblNumero)
        Me.GrbAtender.Controls.Add(Me.RbtAtendido)
        Me.GrbAtender.Controls.Add(Me.RbtNoAtendido)
        Me.GrbAtender.Controls.Add(Me.PnlNoAtendido)
        Me.GrbAtender.Controls.Add(Me.PnlAtendido)
        Me.GrbAtender.Location = New System.Drawing.Point(5, 87)
        Me.GrbAtender.Name = "GrbAtender"
        Me.GrbAtender.Size = New System.Drawing.Size(405, 185)
        Me.GrbAtender.TabIndex = 38
        Me.GrbAtender.TabStop = False
        '
        'LblNumero
        '
        Me.LblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero.ForeColor = System.Drawing.Color.Red
        Me.LblNumero.Location = New System.Drawing.Point(339, 14)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(61, 13)
        Me.LblNumero.TabIndex = 39
        Me.LblNumero.Text = "1/1"
        Me.LblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnNo
        '
        Me.BtnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.BtnNo.Location = New System.Drawing.Point(136, 277)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(75, 24)
        Me.BtnNo.TabIndex = 13
        Me.BtnNo.Text = "&Omitir"
        Me.BtnNo.UseVisualStyleBackColor = True
        '
        'BtnSiaTodo
        '
        Me.BtnSiaTodo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnSiaTodo.Location = New System.Drawing.Point(225, 277)
        Me.BtnSiaTodo.Name = "BtnSiaTodo"
        Me.BtnSiaTodo.Size = New System.Drawing.Size(75, 24)
        Me.BtnSiaTodo.TabIndex = 14
        Me.BtnSiaTodo.Text = "&Todo"
        Me.BtnSiaTodo.UseVisualStyleBackColor = True
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {" (SELECCIONE)", "INCIDENCIA", "DEFINITIVO"})
        Me.cboTipo.Location = New System.Drawing.Point(76, 38)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(103, 21)
        Me.cboTipo.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Tipo"
        '
        'FrmAtender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(417, 306)
        Me.Controls.Add(Me.BtnSiaTodo)
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnSi)
        Me.Controls.Add(Me.TxtDireccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtContacto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GrbAtender)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAtender"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atender"
        Me.PnlAtendido.ResumeLayout(False)
        Me.PnlAtendido.PerformLayout()
        Me.PnlNoAtendido.ResumeLayout(False)
        Me.PnlNoAtendido.PerformLayout()
        Me.GrbAtender.ResumeLayout(False)
        Me.GrbAtender.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtAtendidoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents RbtAtendido As System.Windows.Forms.RadioButton
    Friend WithEvents RbtNoAtendido As System.Windows.Forms.RadioButton
    Friend WithEvents PnlAtendido As System.Windows.Forms.Panel
    Friend WithEvents ChkParcial As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSi As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents PnlNoAtendido As System.Windows.Forms.Panel
    Friend WithEvents CboIncidencia As System.Windows.Forms.ComboBox
    Friend WithEvents TxtObservacion2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DtpHora2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GrbAtender As System.Windows.Forms.GroupBox
    Friend WithEvents BtnNo As System.Windows.Forms.Button
    Friend WithEvents BtnSiaTodo As System.Windows.Forms.Button
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
