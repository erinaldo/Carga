<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcesosVentaContadoGiros
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
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gboxPROCESOS = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNroDoc = New System.Windows.Forms.TextBox
        Me.txtfecha = New System.Windows.Forms.TextBox
        Me.txtDevolucion = New System.Windows.Forms.TextBox
        Me.txtTotalCosto = New System.Windows.Forms.TextBox
        Me.txtPorcentage = New System.Windows.Forms.TextBox
        Me.txtMONTO_FLETE = New System.Windows.Forms.TextBox
        Me.txtMONTO_BASE = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.gboxPROCESOS.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(349, 199)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(101, 28)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(182, 199)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 28)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gboxPROCESOS
        '
        Me.gboxPROCESOS.Controls.Add(Me.Label8)
        Me.gboxPROCESOS.Controls.Add(Me.Label7)
        Me.gboxPROCESOS.Controls.Add(Me.Label6)
        Me.gboxPROCESOS.Controls.Add(Me.Label5)
        Me.gboxPROCESOS.Controls.Add(Me.Label4)
        Me.gboxPROCESOS.Controls.Add(Me.Label3)
        Me.gboxPROCESOS.Controls.Add(Me.Label2)
        Me.gboxPROCESOS.Controls.Add(Me.Label1)
        Me.gboxPROCESOS.Controls.Add(Me.txtNroDoc)
        Me.gboxPROCESOS.Controls.Add(Me.txtfecha)
        Me.gboxPROCESOS.Controls.Add(Me.txtDevolucion)
        Me.gboxPROCESOS.Controls.Add(Me.txtTotalCosto)
        Me.gboxPROCESOS.Controls.Add(Me.txtPorcentage)
        Me.gboxPROCESOS.Controls.Add(Me.txtMONTO_FLETE)
        Me.gboxPROCESOS.Controls.Add(Me.txtMONTO_BASE)
        Me.gboxPROCESOS.Controls.Add(Me.txtCliente)
        Me.gboxPROCESOS.Location = New System.Drawing.Point(3, 0)
        Me.gboxPROCESOS.Name = "gboxPROCESOS"
        Me.gboxPROCESOS.Size = New System.Drawing.Size(628, 193)
        Me.gboxPROCESOS.TabIndex = 1
        Me.gboxPROCESOS.TabStop = False
        Me.gboxPROCESOS.Text = "PROCESO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(372, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Total Devolucion"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "TotalCosto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "% Descuento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Monto Flete"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Base"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(463, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FECHA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(413, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nro Doc"
        '
        'txtNroDoc
        '
        Me.txtNroDoc.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtNroDoc.Location = New System.Drawing.Point(466, 19)
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.Size = New System.Drawing.Size(155, 20)
        Me.txtNroDoc.TabIndex = 0
        '
        'txtfecha
        '
        Me.txtfecha.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtfecha.Location = New System.Drawing.Point(515, 53)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(106, 20)
        Me.txtfecha.TabIndex = 0
        '
        'txtDevolucion
        '
        Me.txtDevolucion.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevolucion.Location = New System.Drawing.Point(480, 157)
        Me.txtDevolucion.Name = "txtDevolucion"
        Me.txtDevolucion.Size = New System.Drawing.Size(141, 21)
        Me.txtDevolucion.TabIndex = 0
        Me.txtDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCosto
        '
        Me.txtTotalCosto.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtTotalCosto.Location = New System.Drawing.Point(82, 158)
        Me.txtTotalCosto.Name = "txtTotalCosto"
        Me.txtTotalCosto.Size = New System.Drawing.Size(87, 20)
        Me.txtTotalCosto.TabIndex = 0
        Me.txtTotalCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorcentage
        '
        Me.txtPorcentage.BackColor = System.Drawing.SystemColors.Info
        Me.txtPorcentage.Enabled = False
        Me.txtPorcentage.Location = New System.Drawing.Point(82, 132)
        Me.txtPorcentage.Name = "txtPorcentage"
        Me.txtPorcentage.Size = New System.Drawing.Size(87, 20)
        Me.txtPorcentage.TabIndex = 0
        Me.txtPorcentage.Text = "100"
        Me.txtPorcentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMONTO_FLETE
        '
        Me.txtMONTO_FLETE.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtMONTO_FLETE.Location = New System.Drawing.Point(82, 110)
        Me.txtMONTO_FLETE.Name = "txtMONTO_FLETE"
        Me.txtMONTO_FLETE.Size = New System.Drawing.Size(87, 20)
        Me.txtMONTO_FLETE.TabIndex = 0
        Me.txtMONTO_FLETE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMONTO_BASE
        '
        Me.txtMONTO_BASE.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtMONTO_BASE.Location = New System.Drawing.Point(82, 84)
        Me.txtMONTO_BASE.Name = "txtMONTO_BASE"
        Me.txtMONTO_BASE.Size = New System.Drawing.Size(87, 20)
        Me.txtMONTO_BASE.TabIndex = 0
        Me.txtMONTO_BASE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtCliente.Location = New System.Drawing.Point(82, 53)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(311, 20)
        Me.txtCliente.TabIndex = 0
        '
        'FrmProcesosVentaContadoGiros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 232)
        Me.Controls.Add(Me.gboxPROCESOS)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "FrmProcesosVentaContadoGiros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procesos Venta Contado"
        Me.gboxPROCESOS.ResumeLayout(False)
        Me.gboxPROCESOS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gboxPROCESOS As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNroDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtfecha As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentage As System.Windows.Forms.TextBox
    Friend WithEvents txtMONTO_FLETE As System.Windows.Forms.TextBox
    Friend WithEvents txtMONTO_BASE As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDevolucion As System.Windows.Forms.TextBox
End Class
