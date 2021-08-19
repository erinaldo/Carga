<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMSM2Movil
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbResponsableMovil = New System.Windows.Forms.ComboBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnSENDMSM2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtNroFono = New System.Windows.Forms.TextBox
        Me.txtMensaje = New System.Windows.Forms.TextBox
        Me.checkTodos = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.GroupBox1.Controls.Add(Me.checkTodos)
        Me.GroupBox1.Controls.Add(Me.cmbResponsableMovil)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnSENDMSM2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtNroFono)
        Me.GroupBox1.Controls.Add(Me.txtMensaje)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(4, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 196)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbResponsableMovil
        '
        Me.cmbResponsableMovil.BackColor = System.Drawing.SystemColors.Info
        Me.cmbResponsableMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsableMovil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbResponsableMovil.FormattingEnabled = True
        Me.cmbResponsableMovil.Location = New System.Drawing.Point(146, 14)
        Me.cmbResponsableMovil.Name = "cmbResponsableMovil"
        Me.cmbResponsableMovil.Size = New System.Drawing.Size(268, 21)
        Me.cmbResponsableMovil.TabIndex = 253
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.SandyBrown
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Location = New System.Drawing.Point(238, 154)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(135, 24)
        Me.btnSalir.TabIndex = 252
        Me.btnSalir.Text = "( ESC )    Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnSENDMSM2
        '
        Me.btnSENDMSM2.BackColor = System.Drawing.Color.SandyBrown
        Me.btnSENDMSM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSENDMSM2.Location = New System.Drawing.Point(79, 154)
        Me.btnSENDMSM2.Name = "btnSENDMSM2"
        Me.btnSENDMSM2.Size = New System.Drawing.Size(126, 24)
        Me.btnSENDMSM2.TabIndex = 251
        Me.btnSENDMSM2.Text = "(F5)    SEND MSM2"
        Me.btnSENDMSM2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(215, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 250
        Me.Label1.Text = "Nro Movil"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(8, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 13)
        Me.Label17.TabIndex = 250
        Me.Label17.Text = "Responsable de Movil"
        '
        'txtNroFono
        '
        Me.txtNroFono.Location = New System.Drawing.Point(285, 41)
        Me.txtNroFono.MaxLength = 8
        Me.txtNroFono.Name = "txtNroFono"
        Me.txtNroFono.Size = New System.Drawing.Size(129, 20)
        Me.txtNroFono.TabIndex = 1
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(6, 67)
        Me.txtMensaje.MaxLength = 150
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(408, 81)
        Me.txtMensaje.TabIndex = 0
        '
        'checkTodos
        '
        Me.checkTodos.AutoSize = True
        Me.checkTodos.Enabled = False
        Me.checkTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkTodos.ForeColor = System.Drawing.Color.Transparent
        Me.checkTodos.Location = New System.Drawing.Point(11, 43)
        Me.checkTodos.Name = "checkTodos"
        Me.checkTodos.Size = New System.Drawing.Size(61, 17)
        Me.checkTodos.TabIndex = 254
        Me.checkTodos.Text = "Todos"
        Me.checkTodos.UseVisualStyleBackColor = True
        '
        'FrmMSM2Movil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 189)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmMSM2Movil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MSM2 Movil"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents txtNroFono As System.Windows.Forms.TextBox
    Friend WithEvents cmbResponsableMovil As System.Windows.Forms.ComboBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnSENDMSM2 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents checkTodos As System.Windows.Forms.CheckBox
End Class
