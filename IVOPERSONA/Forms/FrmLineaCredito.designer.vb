<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLineaCredito
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
        Me.btnSi = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtSobregiro = New System.Windows.Forms.TextBox()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.cmbTipoFacturacion = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTipoFacturacion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFechaDesactivacion = New System.Windows.Forms.Label()
        Me.lblDatoFecha = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSi
        '
        Me.btnSi.ForeColor = System.Drawing.Color.Maroon
        Me.btnSi.Location = New System.Drawing.Point(273, 146)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(75, 32)
        Me.btnSi.TabIndex = 0
        Me.btnSi.Text = "&Aceptar"
        Me.btnSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNo.ForeColor = System.Drawing.Color.Maroon
        Me.btnNo.Location = New System.Drawing.Point(376, 146)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 32)
        Me.btnNo.TabIndex = 1
        Me.btnNo.Text = "&Cancelar"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'txtDocumento
        '
        Me.txtDocumento.BackColor = System.Drawing.SystemColors.Info
        Me.txtDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Location = New System.Drawing.Point(57, 15)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.ReadOnly = True
        Me.txtDocumento.Size = New System.Drawing.Size(77, 20)
        Me.txtDocumento.TabIndex = 1
        Me.txtDocumento.TabStop = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(132, 15)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(321, 20)
        Me.txtCliente.TabIndex = 2
        Me.txtCliente.TabStop = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(95, 47)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(77, 20)
        Me.txtTotal.TabIndex = 6
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSobregiro
        '
        Me.txtSobregiro.BackColor = System.Drawing.SystemColors.Info
        Me.txtSobregiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSobregiro.Location = New System.Drawing.Point(236, 47)
        Me.txtSobregiro.Name = "txtSobregiro"
        Me.txtSobregiro.ReadOnly = True
        Me.txtSobregiro.Size = New System.Drawing.Size(77, 20)
        Me.txtSobregiro.TabIndex = 7
        Me.txtSobregiro.TabStop = False
        Me.txtSobregiro.Text = "0.00"
        Me.txtSobregiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldo
        '
        Me.txtSaldo.BackColor = System.Drawing.SystemColors.Info
        Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.Location = New System.Drawing.Point(367, 47)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(86, 20)
        Me.txtSaldo.TabIndex = 8
        Me.txtSaldo.TabStop = False
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoFacturacion
        '
        Me.cmbTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFacturacion.FormattingEnabled = True
        Me.cmbTipoFacturacion.Location = New System.Drawing.Point(148, 116)
        Me.cmbTipoFacturacion.Name = "cmbTipoFacturacion"
        Me.cmbTipoFacturacion.Size = New System.Drawing.Size(202, 21)
        Me.cmbTipoFacturacion.TabIndex = 119
        Me.cmbTipoFacturacion.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblDatoFecha)
        Me.Panel1.Controls.Add(Me.lblFechaDesactivacion)
        Me.Panel1.Controls.Add(Me.lblTipoFacturacion)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnNo)
        Me.Panel1.Controls.Add(Me.btnSi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(460, 188)
        Me.Panel1.TabIndex = 121
        '
        'lblTipoFacturacion
        '
        Me.lblTipoFacturacion.AutoSize = True
        Me.lblTipoFacturacion.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoFacturacion.ForeColor = System.Drawing.Color.Maroon
        Me.lblTipoFacturacion.Location = New System.Drawing.Point(10, 116)
        Me.lblTipoFacturacion.Name = "lblTipoFacturacion"
        Me.lblTipoFacturacion.Size = New System.Drawing.Size(87, 13)
        Me.lblTipoFacturacion.TabIndex = 6
        Me.lblTipoFacturacion.Text = "Tipo Facturación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(325, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Saldo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(176, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sobregiro"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(10, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Total asignado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cliente "
        '
        'lblFechaDesactivacion
        '
        Me.lblFechaDesactivacion.AutoSize = True
        Me.lblFechaDesactivacion.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaDesactivacion.ForeColor = System.Drawing.Color.Maroon
        Me.lblFechaDesactivacion.Location = New System.Drawing.Point(10, 85)
        Me.lblFechaDesactivacion.Name = "lblFechaDesactivacion"
        Me.lblFechaDesactivacion.Size = New System.Drawing.Size(123, 13)
        Me.lblFechaDesactivacion.TabIndex = 7
        Me.lblFechaDesactivacion.Text = "Fecha de Desactivación"
        '
        'lblDatoFecha
        '
        Me.lblDatoFecha.AutoSize = True
        Me.lblDatoFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblDatoFecha.ForeColor = System.Drawing.Color.Maroon
        Me.lblDatoFecha.Location = New System.Drawing.Point(145, 85)
        Me.lblDatoFecha.Name = "lblDatoFecha"
        Me.lblDatoFecha.Size = New System.Drawing.Size(65, 13)
        Me.lblDatoFecha.TabIndex = 8
        Me.lblDatoFecha.Text = "01/01/1900"
        '
        'FrmLineaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 188)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbTipoFacturacion)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.txtSobregiro)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtDocumento)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLineaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Línea de Credito"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSi As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSobregiro As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoFacturacion As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTipoFacturacion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDatoFecha As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesactivacion As System.Windows.Forms.Label
End Class
