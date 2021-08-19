<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcargofactura
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
        Me.txtcomprobante = New System.Windows.Forms.TextBox
        Me.txtmensajero = New System.Windows.Forms.TextBox
        Me.txtidfactura = New System.Windows.Forms.TextBox
        Me.DTP_fecha_cargo = New System.Windows.Forms.DateTimePicker
        Me.labFactura = New System.Windows.Forms.Label
        Me.labidfactura = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtidpersona = New System.Windows.Forms.TextBox
        Me.txtrazon_social = New System.Windows.Forms.TextBox
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtcomprobante
        '
        Me.txtcomprobante.BackColor = System.Drawing.SystemColors.Info
        Me.txtcomprobante.Location = New System.Drawing.Point(92, 44)
        Me.txtcomprobante.Name = "txtcomprobante"
        Me.txtcomprobante.ReadOnly = True
        Me.txtcomprobante.Size = New System.Drawing.Size(106, 20)
        Me.txtcomprobante.TabIndex = 13
        '
        'txtmensajero
        '
        Me.txtmensajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmensajero.Location = New System.Drawing.Point(92, 97)
        Me.txtmensajero.MaxLength = 100
        Me.txtmensajero.Name = "txtmensajero"
        Me.txtmensajero.Size = New System.Drawing.Size(326, 20)
        Me.txtmensajero.TabIndex = 1
        '
        'txtidfactura
        '
        Me.txtidfactura.BackColor = System.Drawing.SystemColors.Info
        Me.txtidfactura.Location = New System.Drawing.Point(318, 44)
        Me.txtidfactura.Name = "txtidfactura"
        Me.txtidfactura.ReadOnly = True
        Me.txtidfactura.Size = New System.Drawing.Size(100, 20)
        Me.txtidfactura.TabIndex = 14
        Me.txtidfactura.Visible = False
        '
        'DTP_fecha_cargo
        '
        Me.DTP_fecha_cargo.AllowDrop = True
        Me.DTP_fecha_cargo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_fecha_cargo.Location = New System.Drawing.Point(92, 69)
        Me.DTP_fecha_cargo.Name = "DTP_fecha_cargo"
        Me.DTP_fecha_cargo.Size = New System.Drawing.Size(106, 20)
        Me.DTP_fecha_cargo.TabIndex = 0
        Me.DTP_fecha_cargo.Value = New Date(2007, 2, 12, 0, 0, 0, 0)
        '
        'labFactura
        '
        Me.labFactura.AutoSize = True
        Me.labFactura.ForeColor = System.Drawing.Color.Maroon
        Me.labFactura.Location = New System.Drawing.Point(12, 48)
        Me.labFactura.Name = "labFactura"
        Me.labFactura.Size = New System.Drawing.Size(52, 13)
        Me.labFactura.TabIndex = 5
        Me.labFactura.Text = "Factura : "
        '
        'labidfactura
        '
        Me.labidfactura.AutoSize = True
        Me.labidfactura.ForeColor = System.Drawing.Color.Maroon
        Me.labidfactura.Location = New System.Drawing.Point(251, 48)
        Me.labidfactura.Name = "labidfactura"
        Me.labidfactura.Size = New System.Drawing.Size(58, 13)
        Me.labidfactura.TabIndex = 6
        Me.labidfactura.Text = "Idfactura : "
        Me.labidfactura.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(12, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fecha Cargo  : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Mensajero  : "
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtidpersona)
        Me.GroupBox1.Controls.Add(Me.txtrazon_social)
        Me.GroupBox1.Location = New System.Drawing.Point(5, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 129)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(246, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Idpersona : "
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(7, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Razón Social : "
        '
        'txtidpersona
        '
        Me.txtidpersona.BackColor = System.Drawing.SystemColors.Info
        Me.txtidpersona.Location = New System.Drawing.Point(313, 71)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.ReadOnly = True
        Me.txtidpersona.Size = New System.Drawing.Size(100, 20)
        Me.txtidpersona.TabIndex = 15
        Me.txtidpersona.Visible = False
        '
        'txtrazon_social
        '
        Me.txtrazon_social.BackColor = System.Drawing.SystemColors.Info
        Me.txtrazon_social.Location = New System.Drawing.Point(87, 19)
        Me.txtrazon_social.Name = "txtrazon_social"
        Me.txtrazon_social.ReadOnly = True
        Me.txtrazon_social.Size = New System.Drawing.Size(326, 20)
        Me.txtrazon_social.TabIndex = 12
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btnAceptar.Location = New System.Drawing.Point(254, 135)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Maroon
        Me.BtnCancelar.Location = New System.Drawing.Point(343, 135)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 11
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'frmcargofactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(430, 171)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.labidfactura)
        Me.Controls.Add(Me.labFactura)
        Me.Controls.Add(Me.DTP_fecha_cargo)
        Me.Controls.Add(Me.txtidfactura)
        Me.Controls.Add(Me.txtmensajero)
        Me.Controls.Add(Me.txtcomprobante)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmcargofactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fecha cargo factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtcomprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtmensajero As System.Windows.Forms.TextBox
    Friend WithEvents txtidfactura As System.Windows.Forms.TextBox
    Friend WithEvents DTP_fecha_cargo As System.Windows.Forms.DateTimePicker
    Friend WithEvents labFactura As System.Windows.Forms.Label
    Friend WithEvents labidfactura As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtrazon_social As System.Windows.Forms.TextBox
End Class
