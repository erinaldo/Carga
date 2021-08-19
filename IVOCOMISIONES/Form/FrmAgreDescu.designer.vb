<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgreDescu
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
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.BSalir = New System.Windows.Forms.Button
        Me.BCance = New System.Windows.Forms.Button
        Me.TxtOtrosDescu = New System.Windows.Forms.TextBox
        Me.TxtMontoOtrosDescu = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.dgv1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.BSalir)
        Me.Panel1.Controls.Add(Me.BCance)
        Me.Panel1.Controls.Add(Me.TxtOtrosDescu)
        Me.Panel1.Controls.Add(Me.TxtMontoOtrosDescu)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 256)
        Me.Panel1.TabIndex = 0
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(13, 30)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(89, 20)
        Me.dtpFecha.TabIndex = 5
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(12, 56)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(523, 159)
        Me.dgv1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(445, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Monto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(105, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Descuento"
        '
        'Button4
        '
        Me.Button4.Image = Global.INTEGRACION.My.Resources.Resources._1323
        Me.Button4.Location = New System.Drawing.Point(541, 56)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(47, 36)
        Me.Button4.TabIndex = 1
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.INTEGRACION.My.Resources.Resources.YES01A
        Me.Button3.Location = New System.Drawing.Point(541, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(47, 35)
        Me.Button3.TabIndex = 1
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BSalir
        '
        Me.BSalir.Location = New System.Drawing.Point(460, 221)
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(75, 23)
        Me.BSalir.TabIndex = 2
        Me.BSalir.Text = "Salir"
        Me.BSalir.UseVisualStyleBackColor = True
        '
        'BCance
        '
        Me.BCance.Location = New System.Drawing.Point(378, 221)
        Me.BCance.Name = "BCance"
        Me.BCance.Size = New System.Drawing.Size(75, 23)
        Me.BCance.TabIndex = 2
        Me.BCance.Text = "Cancelar"
        Me.BCance.UseVisualStyleBackColor = True
        '
        'TxtOtrosDescu
        '
        Me.TxtOtrosDescu.Location = New System.Drawing.Point(108, 30)
        Me.TxtOtrosDescu.Name = "TxtOtrosDescu"
        Me.TxtOtrosDescu.Size = New System.Drawing.Size(334, 20)
        Me.TxtOtrosDescu.TabIndex = 0
        '
        'TxtMontoOtrosDescu
        '
        Me.TxtMontoOtrosDescu.Location = New System.Drawing.Point(448, 30)
        Me.TxtMontoOtrosDescu.Name = "TxtMontoOtrosDescu"
        Me.TxtMontoOtrosDescu.Size = New System.Drawing.Size(87, 20)
        Me.TxtMontoOtrosDescu.TabIndex = 0
        Me.TxtMontoOtrosDescu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmAgreDescu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 256)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmAgreDescu"
        Me.Text = "FrmAgreDeecu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BCance As System.Windows.Forms.Button
    Friend WithEvents TxtOtrosDescu As System.Windows.Forms.TextBox
    Friend WithEvents TxtMontoOtrosDescu As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BSalir As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
