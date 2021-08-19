<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciaCartera
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
        Me.grbOrigen = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFuncionario1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grbDestino = New System.Windows.Forms.GroupBox()
        Me.dtpFechaVigencia = New System.Windows.Forms.DateTimePicker()
        Me.lblFuncionario2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grbOrigen.SuspendLayout()
        Me.grbDestino.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(92, 176)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 34)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(251, 176)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 34)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'grbOrigen
        '
        Me.grbOrigen.Controls.Add(Me.dtpFechaFin)
        Me.grbOrigen.Controls.Add(Me.Label8)
        Me.grbOrigen.Controls.Add(Me.lblFuncionario1)
        Me.grbOrigen.Controls.Add(Me.Label3)
        Me.grbOrigen.Location = New System.Drawing.Point(12, 12)
        Me.grbOrigen.Name = "grbOrigen"
        Me.grbOrigen.Size = New System.Drawing.Size(396, 73)
        Me.grbOrigen.TabIndex = 39
        Me.grbOrigen.TabStop = False
        Me.grbOrigen.Text = "Cartera Actual"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Checked = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(203, 41)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaFin.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(126, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Fecha Fin"
        '
        'lblFuncionario1
        '
        Me.lblFuncionario1.Location = New System.Drawing.Point(78, 19)
        Me.lblFuncionario1.Name = "lblFuncionario1"
        Me.lblFuncionario1.Size = New System.Drawing.Size(311, 13)
        Me.lblFuncionario1.TabIndex = 41
        Me.lblFuncionario1.Text = "Funcionario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Responsable"
        '
        'grbDestino
        '
        Me.grbDestino.Controls.Add(Me.dtpFechaVigencia)
        Me.grbDestino.Controls.Add(Me.lblFuncionario2)
        Me.grbDestino.Controls.Add(Me.Label6)
        Me.grbDestino.Controls.Add(Me.Label7)
        Me.grbDestino.Location = New System.Drawing.Point(13, 91)
        Me.grbDestino.Name = "grbDestino"
        Me.grbDestino.Size = New System.Drawing.Size(396, 73)
        Me.grbDestino.TabIndex = 40
        Me.grbDestino.TabStop = False
        Me.grbDestino.Text = "Nueva Cartera"
        '
        'dtpFechaVigencia
        '
        Me.dtpFechaVigencia.Checked = False
        Me.dtpFechaVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVigencia.Location = New System.Drawing.Point(203, 38)
        Me.dtpFechaVigencia.Name = "dtpFechaVigencia"
        Me.dtpFechaVigencia.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaVigencia.TabIndex = 1
        '
        'lblFuncionario2
        '
        Me.lblFuncionario2.Location = New System.Drawing.Point(78, 19)
        Me.lblFuncionario2.Name = "lblFuncionario2"
        Me.lblFuncionario2.Size = New System.Drawing.Size(312, 13)
        Me.lblFuncionario2.TabIndex = 41
        Me.lblFuncionario2.Text = "Funcionario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(126, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Fecha Inicio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Responsable"
        '
        'frmTransferenciaCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 228)
        Me.Controls.Add(Me.grbDestino)
        Me.Controls.Add(Me.grbOrigen)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferenciaCartera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencia de Clientes entre Carteras"
        Me.grbOrigen.ResumeLayout(False)
        Me.grbOrigen.PerformLayout()
        Me.grbDestino.ResumeLayout(False)
        Me.grbDestino.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grbOrigen As System.Windows.Forms.GroupBox
    Friend WithEvents lblFuncionario1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grbDestino As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFuncionario2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
