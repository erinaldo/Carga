<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbusquedaiata
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ShadowLabel1 = New Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
        Me.btnadicionar = New System.Windows.Forms.Button
        Me.btncancelar = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 51)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(262, 360)
        Me.DataGridView1.TabIndex = 0
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShadowLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ShadowLabel1.Location = New System.Drawing.Point(12, 13)
        Me.ShadowLabel1.Name = "ShadowLabel1"
        Me.ShadowLabel1.ShadowColor = System.Drawing.Color.White
        Me.ShadowLabel1.Size = New System.Drawing.Size(262, 32)
        Me.ShadowLabel1.TabIndex = 1
        Me.ShadowLabel1.Text = "ShadowLabel1"
        '
        'btnadicionar
        '
        Me.btnadicionar.Location = New System.Drawing.Point(90, 423)
        Me.btnadicionar.Name = "btnadicionar"
        Me.btnadicionar.Size = New System.Drawing.Size(75, 23)
        Me.btnadicionar.TabIndex = 2
        Me.btnadicionar.Text = "&Add..."
        Me.btnadicionar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(184, 422)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(88, 23)
        Me.btncancelar.TabIndex = 3
        Me.btncancelar.Text = "&Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'frmbusquedaiata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 459)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnadicionar)
        Me.Controls.Add(Me.ShadowLabel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmbusquedaiata"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ShadowLabel1 As Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
    Friend WithEvents btnadicionar As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
End Class
