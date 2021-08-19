<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecojoReprogramado
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.DtpHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.DtpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.LblHoraInicio = New System.Windows.Forms.Label()
        Me.LblHoraFin = New System.Windows.Forms.Label()
        Me.GrbDe = New System.Windows.Forms.GroupBox()
        Me.GrbA = New System.Windows.Forms.GroupBox()
        Me.ChkFecha = New System.Windows.Forms.CheckBox()
        Me.BtnSi = New System.Windows.Forms.Button()
        Me.BtnNo = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.GrbB = New System.Windows.Forms.GroupBox()
        Me.ChkRuta = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CboRuta = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMovil = New System.Windows.Forms.TextBox()
        Me.TxtChofer = New System.Windows.Forms.TextBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.BtnSiaTodo = New System.Windows.Forms.Button()
        Me.GrbDe.SuspendLayout()
        Me.GrbA.SuspendLayout()
        Me.GrbB.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Hora Listo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(315, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Hora Cierre"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(161, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Hora Listo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(315, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Hora Cierre"
        '
        'DtpFecha
        '
        Me.DtpFecha.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DtpFecha.CustomFormat = ""
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(55, 15)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(83, 20)
        Me.DtpFecha.TabIndex = 0
        '
        'DtpHoraInicio
        '
        Me.DtpHoraInicio.CustomFormat = "hh:mm tt"
        Me.DtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHoraInicio.Location = New System.Drawing.Point(216, 15)
        Me.DtpHoraInicio.Name = "DtpHoraInicio"
        Me.DtpHoraInicio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DtpHoraInicio.ShowUpDown = True
        Me.DtpHoraInicio.Size = New System.Drawing.Size(75, 20)
        Me.DtpHoraInicio.TabIndex = 1
        '
        'DtpHoraFin
        '
        Me.DtpHoraFin.CustomFormat = "hh:mm tt"
        Me.DtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHoraFin.Location = New System.Drawing.Point(375, 15)
        Me.DtpHoraFin.Name = "DtpHoraFin"
        Me.DtpHoraFin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DtpHoraFin.ShowUpDown = True
        Me.DtpHoraFin.Size = New System.Drawing.Size(75, 20)
        Me.DtpHoraFin.TabIndex = 2
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.Red
        Me.LblFecha.Location = New System.Drawing.Point(52, 18)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(75, 13)
        Me.LblFecha.TabIndex = 22
        Me.LblFecha.Text = "22/02/2011"
        '
        'LblHoraInicio
        '
        Me.LblHoraInicio.AutoSize = True
        Me.LblHoraInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHoraInicio.ForeColor = System.Drawing.Color.Red
        Me.LblHoraInicio.Location = New System.Drawing.Point(222, 18)
        Me.LblHoraInicio.Name = "LblHoraInicio"
        Me.LblHoraInicio.Size = New System.Drawing.Size(67, 13)
        Me.LblHoraInicio.TabIndex = 22
        Me.LblHoraInicio.Text = "10:00 a.m."
        '
        'LblHoraFin
        '
        Me.LblHoraFin.AutoSize = True
        Me.LblHoraFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHoraFin.ForeColor = System.Drawing.Color.Red
        Me.LblHoraFin.Location = New System.Drawing.Point(381, 18)
        Me.LblHoraFin.Name = "LblHoraFin"
        Me.LblHoraFin.Size = New System.Drawing.Size(67, 13)
        Me.LblHoraFin.TabIndex = 22
        Me.LblHoraFin.Text = "12:00 p.m."
        '
        'GrbDe
        '
        Me.GrbDe.Controls.Add(Me.LblHoraInicio)
        Me.GrbDe.Controls.Add(Me.LblHoraFin)
        Me.GrbDe.Controls.Add(Me.Label4)
        Me.GrbDe.Controls.Add(Me.Label5)
        Me.GrbDe.Controls.Add(Me.LblFecha)
        Me.GrbDe.Controls.Add(Me.Label6)
        Me.GrbDe.Location = New System.Drawing.Point(12, 69)
        Me.GrbDe.Name = "GrbDe"
        Me.GrbDe.Size = New System.Drawing.Size(458, 43)
        Me.GrbDe.TabIndex = 23
        Me.GrbDe.TabStop = False
        Me.GrbDe.Text = "De : "
        '
        'GrbA
        '
        Me.GrbA.Controls.Add(Me.DtpFecha)
        Me.GrbA.Controls.Add(Me.Label7)
        Me.GrbA.Controls.Add(Me.Label8)
        Me.GrbA.Controls.Add(Me.DtpHoraFin)
        Me.GrbA.Controls.Add(Me.DtpHoraInicio)
        Me.GrbA.Controls.Add(Me.Label9)
        Me.GrbA.Location = New System.Drawing.Point(12, 129)
        Me.GrbA.Name = "GrbA"
        Me.GrbA.Size = New System.Drawing.Size(458, 43)
        Me.GrbA.TabIndex = 24
        Me.GrbA.TabStop = False
        Me.GrbA.Text = "A : "
        '
        'ChkFecha
        '
        Me.ChkFecha.AutoSize = True
        Me.ChkFecha.Checked = True
        Me.ChkFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkFecha.Location = New System.Drawing.Point(455, 118)
        Me.ChkFecha.Name = "ChkFecha"
        Me.ChkFecha.Size = New System.Drawing.Size(15, 14)
        Me.ChkFecha.TabIndex = 6
        Me.ChkFecha.UseVisualStyleBackColor = True
        '
        'BtnSi
        '
        Me.BtnSi.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.BtnSi.Location = New System.Drawing.Point(84, 270)
        Me.BtnSi.Name = "BtnSi"
        Me.BtnSi.Size = New System.Drawing.Size(75, 24)
        Me.BtnSi.TabIndex = 3
        Me.BtnSi.Text = "&Aceptar"
        Me.BtnSi.UseVisualStyleBackColor = True
        '
        'BtnNo
        '
        Me.BtnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.BtnNo.Location = New System.Drawing.Point(177, 270)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(75, 24)
        Me.BtnNo.TabIndex = 4
        Me.BtnNo.Text = "&Omitir"
        Me.BtnNo.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(363, 270)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Cliente"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(67, 9)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(403, 20)
        Me.TxtCliente.TabIndex = 26
        Me.TxtCliente.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Dirección"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(67, 35)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(403, 20)
        Me.TxtDireccion.TabIndex = 26
        Me.TxtDireccion.TabStop = False
        '
        'GrbB
        '
        Me.GrbB.Controls.Add(Me.Label11)
        Me.GrbB.Controls.Add(Me.Label10)
        Me.GrbB.Controls.Add(Me.CboRuta)
        Me.GrbB.Controls.Add(Me.Label3)
        Me.GrbB.Controls.Add(Me.TxtMovil)
        Me.GrbB.Controls.Add(Me.TxtChofer)
        Me.GrbB.Enabled = False
        Me.GrbB.Location = New System.Drawing.Point(12, 187)
        Me.GrbB.Name = "GrbB"
        Me.GrbB.Size = New System.Drawing.Size(458, 74)
        Me.GrbB.TabIndex = 27
        Me.GrbB.TabStop = False
        Me.GrbB.Text = "Asignar"
        '
        'ChkRuta
        '
        Me.ChkRuta.AutoSize = True
        Me.ChkRuta.Location = New System.Drawing.Point(457, 177)
        Me.ChkRuta.Name = "ChkRuta"
        Me.ChkRuta.Size = New System.Drawing.Size(15, 14)
        Me.ChkRuta.TabIndex = 27
        Me.ChkRuta.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(247, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Móvil"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Chofer"
        '
        'CboRuta
        '
        Me.CboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRuta.FormattingEnabled = True
        Me.CboRuta.Location = New System.Drawing.Point(55, 18)
        Me.CboRuta.Name = "CboRuta"
        Me.CboRuta.Size = New System.Drawing.Size(187, 21)
        Me.CboRuta.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ruta"
        '
        'TxtMovil
        '
        Me.TxtMovil.Location = New System.Drawing.Point(283, 18)
        Me.TxtMovil.Name = "TxtMovil"
        Me.TxtMovil.ReadOnly = True
        Me.TxtMovil.Size = New System.Drawing.Size(167, 20)
        Me.TxtMovil.TabIndex = 26
        Me.TxtMovil.TabStop = False
        '
        'TxtChofer
        '
        Me.TxtChofer.Location = New System.Drawing.Point(55, 46)
        Me.TxtChofer.Name = "TxtChofer"
        Me.TxtChofer.ReadOnly = True
        Me.TxtChofer.Size = New System.Drawing.Size(395, 20)
        Me.TxtChofer.TabIndex = 26
        Me.TxtChofer.TabStop = False
        '
        'LblNumero
        '
        Me.LblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero.ForeColor = System.Drawing.Color.Red
        Me.LblNumero.Location = New System.Drawing.Point(409, 58)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(61, 13)
        Me.LblNumero.TabIndex = 40
        Me.LblNumero.Text = "1/1"
        Me.LblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnSiaTodo
        '
        Me.BtnSiaTodo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnSiaTodo.Location = New System.Drawing.Point(270, 270)
        Me.BtnSiaTodo.Name = "BtnSiaTodo"
        Me.BtnSiaTodo.Size = New System.Drawing.Size(75, 24)
        Me.BtnSiaTodo.TabIndex = 41
        Me.BtnSiaTodo.Text = "&Todo"
        Me.BtnSiaTodo.UseVisualStyleBackColor = True
        '
        'FrmRecojoReprogramado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(480, 301)
        Me.Controls.Add(Me.ChkFecha)
        Me.Controls.Add(Me.ChkRuta)
        Me.Controls.Add(Me.BtnSiaTodo)
        Me.Controls.Add(Me.LblNumero)
        Me.Controls.Add(Me.GrbB)
        Me.Controls.Add(Me.TxtDireccion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.BtnSi)
        Me.Controls.Add(Me.GrbA)
        Me.Controls.Add(Me.GrbDe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRecojoReprogramado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reprogramar"
        Me.GrbDe.ResumeLayout(False)
        Me.GrbDe.PerformLayout()
        Me.GrbA.ResumeLayout(False)
        Me.GrbA.PerformLayout()
        Me.GrbB.ResumeLayout(False)
        Me.GrbB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpHoraInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpHoraFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents LblHoraInicio As System.Windows.Forms.Label
    Friend WithEvents LblHoraFin As System.Windows.Forms.Label
    Friend WithEvents GrbDe As System.Windows.Forms.GroupBox
    Friend WithEvents GrbA As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSi As System.Windows.Forms.Button
    Friend WithEvents BtnNo As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents GrbB As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtMovil As System.Windows.Forms.TextBox
    Friend WithEvents TxtChofer As System.Windows.Forms.TextBox
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents BtnSiaTodo As System.Windows.Forms.Button
    Friend WithEvents ChkFecha As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRuta As System.Windows.Forms.CheckBox
End Class
