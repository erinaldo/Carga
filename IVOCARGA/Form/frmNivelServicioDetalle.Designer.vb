<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNivelServicioDetalle
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
        Me.dgvNivelServicioDetalle = New System.Windows.Forms.DataGridView()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grbResultado = New System.Windows.Forms.GroupBox()
        Me.lblPromedio = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEnvios = New System.Windows.Forms.Label()
        Me.lblTiempo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvNivelServicioDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbResultado.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvNivelServicioDetalle
        '
        Me.dgvNivelServicioDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNivelServicioDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNivelServicioDetalle.Location = New System.Drawing.Point(12, 12)
        Me.dgvNivelServicioDetalle.Name = "dgvNivelServicioDetalle"
        Me.dgvNivelServicioDetalle.Size = New System.Drawing.Size(1126, 440)
        Me.dgvNivelServicioDetalle.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(519, 497)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 34)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'grbResultado
        '
        Me.grbResultado.Controls.Add(Me.lblPromedio)
        Me.grbResultado.Controls.Add(Me.Label10)
        Me.grbResultado.Controls.Add(Me.Label9)
        Me.grbResultado.Controls.Add(Me.lblEnvios)
        Me.grbResultado.Controls.Add(Me.lblTiempo)
        Me.grbResultado.Controls.Add(Me.Label2)
        Me.grbResultado.Location = New System.Drawing.Point(12, 450)
        Me.grbResultado.Name = "grbResultado"
        Me.grbResultado.Size = New System.Drawing.Size(1126, 40)
        Me.grbResultado.TabIndex = 196
        Me.grbResultado.TabStop = False
        '
        'lblPromedio
        '
        Me.lblPromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromedio.Location = New System.Drawing.Point(637, 16)
        Me.lblPromedio.Name = "lblPromedio"
        Me.lblPromedio.Size = New System.Drawing.Size(67, 13)
        Me.lblPromedio.TabIndex = 0
        Me.lblPromedio.Text = "0.00"
        Me.lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(588, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Promedio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(410, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Envíos"
        '
        'lblEnvios
        '
        Me.lblEnvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnvios.Location = New System.Drawing.Point(449, 16)
        Me.lblEnvios.Name = "lblEnvios"
        Me.lblEnvios.Size = New System.Drawing.Size(67, 13)
        Me.lblEnvios.TabIndex = 0
        Me.lblEnvios.Text = "0"
        Me.lblEnvios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTiempo
        '
        Me.lblTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiempo.Location = New System.Drawing.Point(204, 16)
        Me.lblTiempo.Name = "lblTiempo"
        Me.lblTiempo.Size = New System.Drawing.Size(67, 13)
        Me.lblTiempo.TabIndex = 0
        Me.lblTiempo.Text = "0.00"
        Me.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTiempo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(163, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tiempo"
        Me.Label2.Visible = False
        '
        'frmNivelServicioDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1148, 541)
        Me.Controls.Add(Me.grbResultado)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvNivelServicioDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNivelServicioDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nivel Servicio Detalle"
        CType(Me.dgvNivelServicioDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbResultado.ResumeLayout(False)
        Me.grbResultado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvNivelServicioDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents grbResultado As System.Windows.Forms.GroupBox
    Friend WithEvents lblPromedio As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblEnvios As System.Windows.Forms.Label
    Friend WithEvents lblTiempo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
