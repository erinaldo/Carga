<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRangoEtiquetas2
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
        Me.rbtodos = New System.Windows.Forms.RadioButton()
        Me.rbrango = New System.Windows.Forms.RadioButton()
        Me.NumeUDini = New System.Windows.Forms.NumericUpDown()
        Me.NumeUDfinal = New System.Windows.Forms.NumericUpDown()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCance = New System.Windows.Forms.Button()
        Me.btnAcep = New System.Windows.Forms.Button()
        CType(Me.NumeUDini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumeUDfinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbtodos
        '
        Me.rbtodos.AutoSize = True
        Me.rbtodos.BackColor = System.Drawing.Color.Transparent
        Me.rbtodos.Checked = True
        Me.rbtodos.Location = New System.Drawing.Point(10, 37)
        Me.rbtodos.Name = "rbtodos"
        Me.rbtodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtodos.TabIndex = 0
        Me.rbtodos.TabStop = True
        Me.rbtodos.Text = "Todos"
        Me.rbtodos.UseVisualStyleBackColor = False
        '
        'rbrango
        '
        Me.rbrango.AutoSize = True
        Me.rbrango.BackColor = System.Drawing.Color.Transparent
        Me.rbrango.Location = New System.Drawing.Point(71, 37)
        Me.rbrango.Name = "rbrango"
        Me.rbrango.Size = New System.Drawing.Size(57, 17)
        Me.rbrango.TabIndex = 1
        Me.rbrango.Text = "Rango"
        Me.rbrango.UseVisualStyleBackColor = False
        '
        'NumeUDini
        '
        Me.NumeUDini.Enabled = False
        Me.NumeUDini.Location = New System.Drawing.Point(49, 60)
        Me.NumeUDini.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumeUDini.Name = "NumeUDini"
        Me.NumeUDini.Size = New System.Drawing.Size(68, 20)
        Me.NumeUDini.TabIndex = 3
        '
        'NumeUDfinal
        '
        Me.NumeUDfinal.Enabled = False
        Me.NumeUDfinal.Location = New System.Drawing.Point(164, 60)
        Me.NumeUDfinal.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumeUDfinal.Name = "NumeUDfinal"
        Me.NumeUDfinal.Size = New System.Drawing.Size(68, 20)
        Me.NumeUDfinal.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnCance)
        Me.Panel1.Controls.Add(Me.btnAcep)
        Me.Panel1.Controls.Add(Me.NumeUDfinal)
        Me.Panel1.Controls.Add(Me.NumeUDini)
        Me.Panel1.Controls.Add(Me.rbrango)
        Me.Panel1.Controls.Add(Me.rbtodos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 116)
        Me.Panel1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(7, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(225, 25)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(120, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(4, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Desde:"
        '
        'btnCance
        '
        Me.btnCance.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCance.Location = New System.Drawing.Point(157, 86)
        Me.btnCance.Name = "btnCance"
        Me.btnCance.Size = New System.Drawing.Size(75, 23)
        Me.btnCance.TabIndex = 5
        Me.btnCance.Text = "Cancelar"
        Me.btnCance.UseVisualStyleBackColor = True
        '
        'btnAcep
        '
        Me.btnAcep.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAcep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAcep.Location = New System.Drawing.Point(76, 86)
        Me.btnAcep.Name = "btnAcep"
        Me.btnAcep.Size = New System.Drawing.Size(75, 23)
        Me.btnAcep.TabIndex = 4
        Me.btnAcep.Text = "Aceptar"
        Me.btnAcep.UseVisualStyleBackColor = True
        '
        'FrmRangoEtiquetas2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 116)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "FrmRangoEtiquetas2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.NumeUDini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumeUDfinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rbtodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbrango As System.Windows.Forms.RadioButton
    Friend WithEvents NumeUDini As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumeUDfinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCance As System.Windows.Forms.Button
    Friend WithEvents btnAcep As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
