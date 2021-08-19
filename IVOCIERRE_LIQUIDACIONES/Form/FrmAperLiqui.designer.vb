<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAperLiqui
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.bcance = New System.Windows.Forms.Button
        Me.BTNACEP = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox
        Me.cmbAgencia = New System.Windows.Forms.ComboBox
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtpfecha)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.bcance)
        Me.Panel1.Controls.Add(Me.BTNACEP)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbUsuarios)
        Me.Panel1.Controls.Add(Me.cmbAgencia)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(309, 184)
        Me.Panel1.TabIndex = 0
        '
        'bcance
        '
        Me.bcance.BackColor = System.Drawing.Color.Transparent
        Me.bcance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bcance.Location = New System.Drawing.Point(218, 144)
        Me.bcance.Name = "bcance"
        Me.bcance.Size = New System.Drawing.Size(79, 28)
        Me.bcance.TabIndex = 48
        Me.bcance.Text = "&Cancelar"
        Me.bcance.UseVisualStyleBackColor = False
        '
        'BTNACEP
        '
        Me.BTNACEP.BackColor = System.Drawing.Color.Transparent
        Me.BTNACEP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNACEP.Location = New System.Drawing.Point(133, 144)
        Me.BTNACEP.Name = "BTNACEP"
        Me.BTNACEP.Size = New System.Drawing.Size(79, 28)
        Me.BTNACEP.TabIndex = 47
        Me.BTNACEP.Text = "&Aceptar"
        Me.BTNACEP.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 43)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Usted no tiene ninguna apertura de TURNO CREDITO para realizar ventas, aperture T" & _
            "URNO CREDITO si desea realizar VENTAS CREDITO."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(3, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(3, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Agencia"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.Enabled = False
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(59, 117)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(238, 21)
        Me.cmbUsuarios.TabIndex = 41
        '
        'cmbAgencia
        '
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.Enabled = False
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(59, 92)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(238, 21)
        Me.cmbAgencia.TabIndex = 40
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(59, 66)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpfecha.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Fecha"
        '
        'FrmAperLiqui
        '
        Me.ClientSize = New System.Drawing.Size(309, 184)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAperLiqui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aperturar TURNO CREDITO..."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bcance As System.Windows.Forms.Button
    Friend WithEvents BTNACEP As System.Windows.Forms.Button
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
