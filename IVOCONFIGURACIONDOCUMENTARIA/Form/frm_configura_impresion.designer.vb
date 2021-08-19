<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_configura_impresion
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.lstIP = New System.Windows.Forms.ListBox
        Me.GrbOpciones = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.NudTamaño = New System.Windows.Forms.NumericUpDown
        Me.NudSuperior = New System.Windows.Forms.NumericUpDown
        Me.NudIzquierda = New System.Windows.Forms.NumericUpDown
        Me.GrbOpciones.SuspendLayout()
        CType(Me.NudTamaño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudSuperior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudIzquierda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(74, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(205, 191)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 29)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lstIP
        '
        Me.lstIP.FormattingEnabled = True
        Me.lstIP.Location = New System.Drawing.Point(12, 12)
        Me.lstIP.Name = "lstIP"
        Me.lstIP.Size = New System.Drawing.Size(329, 173)
        Me.lstIP.TabIndex = 2
        '
        'GrbOpciones
        '
        Me.GrbOpciones.Controls.Add(Me.NudIzquierda)
        Me.GrbOpciones.Controls.Add(Me.NudSuperior)
        Me.GrbOpciones.Controls.Add(Me.NudTamaño)
        Me.GrbOpciones.Controls.Add(Me.Label3)
        Me.GrbOpciones.Controls.Add(Me.Label2)
        Me.GrbOpciones.Controls.Add(Me.Label1)
        Me.GrbOpciones.Location = New System.Drawing.Point(347, 12)
        Me.GrbOpciones.Name = "GrbOpciones"
        Me.GrbOpciones.Size = New System.Drawing.Size(161, 173)
        Me.GrbOpciones.TabIndex = 3
        Me.GrbOpciones.TabStop = False
        Me.GrbOpciones.Text = "Opciones de Página"
        Me.GrbOpciones.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tamaño:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Superior:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Izquierda:"
        '
        'NudTamaño
        '
        Me.NudTamaño.Location = New System.Drawing.Point(88, 27)
        Me.NudTamaño.Name = "NudTamaño"
        Me.NudTamaño.Size = New System.Drawing.Size(52, 20)
        Me.NudTamaño.TabIndex = 1
        '
        'NudSuperior
        '
        Me.NudSuperior.Location = New System.Drawing.Point(88, 59)
        Me.NudSuperior.Name = "NudSuperior"
        Me.NudSuperior.Size = New System.Drawing.Size(52, 20)
        Me.NudSuperior.TabIndex = 1
        '
        'NudIzquierda
        '
        Me.NudIzquierda.Location = New System.Drawing.Point(88, 91)
        Me.NudIzquierda.Name = "NudIzquierda"
        Me.NudIzquierda.Size = New System.Drawing.Size(52, 20)
        Me.NudIzquierda.TabIndex = 1
        '
        'frm_configura_impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 229)
        Me.Controls.Add(Me.GrbOpciones)
        Me.Controls.Add(Me.lstIP)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_configura_impresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prueba Correlativo"
        Me.GrbOpciones.ResumeLayout(False)
        Me.GrbOpciones.PerformLayout()
        CType(Me.NudTamaño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudSuperior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudIzquierda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lstIP As System.Windows.Forms.ListBox
    Friend WithEvents GrbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NudIzquierda As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudSuperior As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudTamaño As System.Windows.Forms.NumericUpDown
End Class
