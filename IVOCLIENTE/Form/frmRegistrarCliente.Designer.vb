<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistrarCliente
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
        Me.GrbCliente = New System.Windows.Forms.GroupBox()
        Me.LblApep = New System.Windows.Forms.Label()
        Me.TxtAPCliente = New System.Windows.Forms.TextBox()
        Me.TxtAMCliente = New System.Windows.Forms.TextBox()
        Me.LblApeM = New System.Windows.Forms.Label()
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.CboTipoPersona = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GrbCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrbCliente
        '
        Me.GrbCliente.Controls.Add(Me.LblApep)
        Me.GrbCliente.Controls.Add(Me.TxtAPCliente)
        Me.GrbCliente.Controls.Add(Me.TxtAMCliente)
        Me.GrbCliente.Controls.Add(Me.LblApeM)
        Me.GrbCliente.Controls.Add(Me.cboTipoDocumento)
        Me.GrbCliente.Controls.Add(Me.CboTipoPersona)
        Me.GrbCliente.Controls.Add(Me.Label2)
        Me.GrbCliente.Controls.Add(Me.Label18)
        Me.GrbCliente.Controls.Add(Me.Label1)
        Me.GrbCliente.Controls.Add(Me.txtNumero)
        Me.GrbCliente.Controls.Add(Me.LblCliente)
        Me.GrbCliente.Controls.Add(Me.TxtCliente)
        Me.GrbCliente.Location = New System.Drawing.Point(10, 19)
        Me.GrbCliente.Name = "GrbCliente"
        Me.GrbCliente.Size = New System.Drawing.Size(549, 146)
        Me.GrbCliente.TabIndex = 1
        Me.GrbCliente.TabStop = False
        Me.GrbCliente.Text = "Cliente"
        '
        'LblApep
        '
        Me.LblApep.AutoSize = True
        Me.LblApep.Location = New System.Drawing.Point(6, 84)
        Me.LblApep.Name = "LblApep"
        Me.LblApep.Size = New System.Drawing.Size(55, 13)
        Me.LblApep.TabIndex = 8
        Me.LblApep.Text = "Apell. Pat."
        '
        'TxtAPCliente
        '
        Me.TxtAPCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAPCliente.Location = New System.Drawing.Point(82, 81)
        Me.TxtAPCliente.MaxLength = 50
        Me.TxtAPCliente.Name = "TxtAPCliente"
        Me.TxtAPCliente.Size = New System.Drawing.Size(188, 20)
        Me.TxtAPCliente.TabIndex = 2
        '
        'TxtAMCliente
        '
        Me.TxtAMCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAMCliente.Location = New System.Drawing.Point(348, 81)
        Me.TxtAMCliente.MaxLength = 50
        Me.TxtAMCliente.Name = "TxtAMCliente"
        Me.TxtAMCliente.Size = New System.Drawing.Size(188, 20)
        Me.TxtAMCliente.TabIndex = 3
        '
        'LblApeM
        '
        Me.LblApeM.AutoSize = True
        Me.LblApeM.BackColor = System.Drawing.Color.Transparent
        Me.LblApeM.Location = New System.Drawing.Point(283, 84)
        Me.LblApeM.Name = "LblApeM"
        Me.LblApeM.Size = New System.Drawing.Size(57, 13)
        Me.LblApeM.TabIndex = 10
        Me.LblApeM.Text = "Apell. Mat."
        Me.LblApeM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocumento.FormattingEnabled = True
        Me.cboTipoDocumento.Location = New System.Drawing.Point(82, 113)
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(152, 21)
        Me.cboTipoDocumento.TabIndex = 4
        '
        'CboTipoPersona
        '
        Me.CboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoPersona.FormattingEnabled = True
        Me.CboTipoPersona.Items.AddRange(New Object() {"JURIDICA", "NATURAL"})
        Me.CboTipoPersona.Location = New System.Drawing.Point(82, 18)
        Me.CboTipoPersona.Name = "CboTipoPersona"
        Me.CboTipoPersona.Size = New System.Drawing.Size(152, 21)
        Me.CboTipoPersona.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo Doc."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Tipo Persona"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(283, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nº Doc."
        '
        'txtNumero
        '
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Location = New System.Drawing.Point(348, 113)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(117, 20)
        Me.txtNumero.TabIndex = 5
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(6, 54)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(49, 13)
        Me.LblCliente.TabIndex = 6
        Me.LblCliente.Text = "Nombres"
        '
        'TxtCliente
        '
        Me.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCliente.Location = New System.Drawing.Point(82, 51)
        Me.TxtCliente.MaxLength = 80
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(454, 20)
        Me.TxtCliente.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(159, 180)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 30)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(349, 180)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 30)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRegistrarCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 224)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GrbCliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistrarCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Cliente"
        Me.GrbCliente.ResumeLayout(False)
        Me.GrbCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents LblApep As System.Windows.Forms.Label
    Friend WithEvents TxtAPCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtAMCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblApeM As System.Windows.Forms.Label
    Friend WithEvents CboTipoPersona As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
End Class
