<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LblNc
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
        Me.GrbFactura = New System.Windows.Forms.GroupBox
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.LblAcuenta = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.LblFecha = New System.Windows.Forms.Label
        Me.LblNumero = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrbCobranza = New System.Windows.Forms.GroupBox
        Me.dgvCobranza = New System.Windows.Forms.DataGridView
        Me.GrbTipo = New System.Windows.Forms.GroupBox
        Me.DgvHistorico = New System.Windows.Forms.DataGridView
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RbtTodo = New System.Windows.Forms.RadioButton
        Me.RbtCanje = New System.Windows.Forms.RadioButton
        Me.RbtAnticipo = New System.Windows.Forms.RadioButton
        Me.RbtCaja = New System.Windows.Forms.RadioButton
        Me.RbtCredito = New System.Windows.Forms.RadioButton
        Me.RbtBanco = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblBanco = New System.Windows.Forms.Label
        Me.LblCredito = New System.Windows.Forms.Label
        Me.LblCaja = New System.Windows.Forms.Label
        Me.LblAnticipo = New System.Windows.Forms.Label
        Me.LblCanje = New System.Windows.Forms.Label
        Me.GrbFactura.SuspendLayout()
        Me.GrbCobranza.SuspendLayout()
        CType(Me.dgvCobranza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrbTipo.SuspendLayout()
        CType(Me.DgvHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrbFactura
        '
        Me.GrbFactura.Controls.Add(Me.LblSaldo)
        Me.GrbFactura.Controls.Add(Me.LblAcuenta)
        Me.GrbFactura.Controls.Add(Me.LblTotal)
        Me.GrbFactura.Controls.Add(Me.LblFecha)
        Me.GrbFactura.Controls.Add(Me.LblNumero)
        Me.GrbFactura.Controls.Add(Me.Label5)
        Me.GrbFactura.Controls.Add(Me.Label4)
        Me.GrbFactura.Controls.Add(Me.Label3)
        Me.GrbFactura.Controls.Add(Me.Label2)
        Me.GrbFactura.Controls.Add(Me.Label1)
        Me.GrbFactura.Location = New System.Drawing.Point(3, 3)
        Me.GrbFactura.Name = "GrbFactura"
        Me.GrbFactura.Size = New System.Drawing.Size(671, 39)
        Me.GrbFactura.TabIndex = 3
        Me.GrbFactura.TabStop = False
        Me.GrbFactura.Text = "Factura"
        '
        'LblSaldo
        '
        Me.LblSaldo.AutoSize = True
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.Color.Red
        Me.LblSaldo.Location = New System.Drawing.Point(593, 16)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(32, 13)
        Me.LblSaldo.TabIndex = 5
        Me.LblSaldo.Text = "0.00"
        '
        'LblAcuenta
        '
        Me.LblAcuenta.AutoSize = True
        Me.LblAcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcuenta.ForeColor = System.Drawing.Color.Navy
        Me.LblAcuenta.Location = New System.Drawing.Point(469, 16)
        Me.LblAcuenta.Name = "LblAcuenta"
        Me.LblAcuenta.Size = New System.Drawing.Size(32, 13)
        Me.LblAcuenta.TabIndex = 4
        Me.LblAcuenta.Text = "0.00"
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Navy
        Me.LblTotal.Location = New System.Drawing.Point(320, 16)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(32, 13)
        Me.LblTotal.TabIndex = 3
        Me.LblTotal.Text = "0.00"
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.Navy
        Me.LblFecha.Location = New System.Drawing.Point(164, 16)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(45, 13)
        Me.LblFecha.TabIndex = 2
        Me.LblFecha.Text = "Label6"
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero.ForeColor = System.Drawing.Color.Navy
        Me.LblNumero.Location = New System.Drawing.Point(34, 16)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(45, 13)
        Me.LblNumero.TabIndex = 1
        Me.LblNumero.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(553, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Saldo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(412, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "A Cuenta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(283, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº"
        '
        'GrbCobranza
        '
        Me.GrbCobranza.Controls.Add(Me.dgvCobranza)
        Me.GrbCobranza.Location = New System.Drawing.Point(3, 98)
        Me.GrbCobranza.Name = "GrbCobranza"
        Me.GrbCobranza.Size = New System.Drawing.Size(671, 188)
        Me.GrbCobranza.TabIndex = 4
        Me.GrbCobranza.TabStop = False
        Me.GrbCobranza.Text = "Cobranzas"
        '
        'dgvCobranza
        '
        Me.dgvCobranza.AllowUserToAddRows = False
        Me.dgvCobranza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCobranza.Location = New System.Drawing.Point(6, 19)
        Me.dgvCobranza.Name = "dgvCobranza"
        Me.dgvCobranza.Size = New System.Drawing.Size(659, 163)
        Me.dgvCobranza.TabIndex = 1
        '
        'GrbTipo
        '
        Me.GrbTipo.Controls.Add(Me.DgvHistorico)
        Me.GrbTipo.Location = New System.Drawing.Point(3, 318)
        Me.GrbTipo.Name = "GrbTipo"
        Me.GrbTipo.Size = New System.Drawing.Size(671, 128)
        Me.GrbTipo.TabIndex = 5
        Me.GrbTipo.TabStop = False
        Me.GrbTipo.Text = "Histórico"
        '
        'DgvHistorico
        '
        Me.DgvHistorico.AllowUserToAddRows = False
        Me.DgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvHistorico.Location = New System.Drawing.Point(6, 18)
        Me.DgvHistorico.Name = "DgvHistorico"
        Me.DgvHistorico.Size = New System.Drawing.Size(659, 104)
        Me.DgvHistorico.TabIndex = 2
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(314, 452)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(76, 29)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RbtTodo)
        Me.GroupBox3.Controls.Add(Me.RbtCanje)
        Me.GroupBox3.Controls.Add(Me.RbtAnticipo)
        Me.GroupBox3.Controls.Add(Me.RbtCaja)
        Me.GroupBox3.Controls.Add(Me.RbtCredito)
        Me.GroupBox3.Controls.Add(Me.RbtBanco)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(671, 44)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Cobranza"
        '
        'RbtTodo
        '
        Me.RbtTodo.AutoSize = True
        Me.RbtTodo.Location = New System.Drawing.Point(510, 19)
        Me.RbtTodo.Name = "RbtTodo"
        Me.RbtTodo.Size = New System.Drawing.Size(50, 17)
        Me.RbtTodo.TabIndex = 5
        Me.RbtTodo.Text = "Todo"
        Me.RbtTodo.UseVisualStyleBackColor = True
        '
        'RbtCanje
        '
        Me.RbtCanje.AutoSize = True
        Me.RbtCanje.Location = New System.Drawing.Point(421, 19)
        Me.RbtCanje.Name = "RbtCanje"
        Me.RbtCanje.Size = New System.Drawing.Size(52, 17)
        Me.RbtCanje.TabIndex = 4
        Me.RbtCanje.Text = "Canje"
        Me.RbtCanje.UseVisualStyleBackColor = True
        '
        'RbtAnticipo
        '
        Me.RbtAnticipo.AutoSize = True
        Me.RbtAnticipo.Location = New System.Drawing.Point(321, 19)
        Me.RbtAnticipo.Name = "RbtAnticipo"
        Me.RbtAnticipo.Size = New System.Drawing.Size(63, 17)
        Me.RbtAnticipo.TabIndex = 3
        Me.RbtAnticipo.Text = "Anticipo"
        Me.RbtAnticipo.UseVisualStyleBackColor = True
        '
        'RbtCaja
        '
        Me.RbtCaja.AutoSize = True
        Me.RbtCaja.Location = New System.Drawing.Point(238, 19)
        Me.RbtCaja.Name = "RbtCaja"
        Me.RbtCaja.Size = New System.Drawing.Size(46, 17)
        Me.RbtCaja.TabIndex = 2
        Me.RbtCaja.Text = "Caja"
        Me.RbtCaja.UseVisualStyleBackColor = True
        '
        'RbtCredito
        '
        Me.RbtCredito.AutoSize = True
        Me.RbtCredito.Location = New System.Drawing.Point(102, 19)
        Me.RbtCredito.Name = "RbtCredito"
        Me.RbtCredito.Size = New System.Drawing.Size(99, 17)
        Me.RbtCredito.TabIndex = 1
        Me.RbtCredito.Text = "Nota de Crédito"
        Me.RbtCredito.UseVisualStyleBackColor = True
        '
        'RbtBanco
        '
        Me.RbtBanco.AutoSize = True
        Me.RbtBanco.Location = New System.Drawing.Point(9, 19)
        Me.RbtBanco.Name = "RbtBanco"
        Me.RbtBanco.Size = New System.Drawing.Size(56, 17)
        Me.RbtBanco.TabIndex = 0
        Me.RbtBanco.Text = "Banco"
        Me.RbtBanco.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 295)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Banco"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(148, 295)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "N.C."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(275, 295)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Caja"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(399, 295)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Anticipo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(547, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Canje"
        '
        'LblBanco
        '
        Me.LblBanco.AutoSize = True
        Me.LblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBanco.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblBanco.Location = New System.Drawing.Point(53, 295)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(43, 13)
        Me.LblBanco.TabIndex = 8
        Me.LblBanco.Text = "Banco"
        '
        'LblCredito
        '
        Me.LblCredito.AutoSize = True
        Me.LblCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCredito.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCredito.Location = New System.Drawing.Point(196, 295)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(32, 13)
        Me.LblCredito.TabIndex = 8
        Me.LblCredito.Text = "N.C."
        '
        'LblCaja
        '
        Me.LblCaja.AutoSize = True
        Me.LblCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCaja.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCaja.Location = New System.Drawing.Point(321, 295)
        Me.LblCaja.Name = "LblCaja"
        Me.LblCaja.Size = New System.Drawing.Size(32, 13)
        Me.LblCaja.TabIndex = 8
        Me.LblCaja.Text = "Caja"
        '
        'LblAnticipo
        '
        Me.LblAnticipo.AutoSize = True
        Me.LblAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAnticipo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblAnticipo.Location = New System.Drawing.Point(463, 295)
        Me.LblAnticipo.Name = "LblAnticipo"
        Me.LblAnticipo.Size = New System.Drawing.Size(53, 13)
        Me.LblAnticipo.TabIndex = 8
        Me.LblAnticipo.Text = "Anticipo"
        '
        'LblCanje
        '
        Me.LblCanje.AutoSize = True
        Me.LblCanje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCanje.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCanje.Location = New System.Drawing.Point(609, 295)
        Me.LblCanje.Name = "LblCanje"
        Me.LblCanje.Size = New System.Drawing.Size(39, 13)
        Me.LblCanje.TabIndex = 8
        Me.LblCanje.Text = "Canje"
        '
        'LblNc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(679, 486)
        Me.Controls.Add(Me.LblCanje)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblAnticipo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LblCaja)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblCredito)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblBanco)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrbTipo)
        Me.Controls.Add(Me.GrbCobranza)
        Me.Controls.Add(Me.GrbFactura)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LblNc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Cobranzas"
        Me.GrbFactura.ResumeLayout(False)
        Me.GrbFactura.PerformLayout()
        Me.GrbCobranza.ResumeLayout(False)
        CType(Me.dgvCobranza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrbTipo.ResumeLayout(False)
        CType(Me.DgvHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrbFactura As System.Windows.Forms.GroupBox
    Friend WithEvents GrbCobranza As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCobranza As System.Windows.Forms.DataGridView
    Friend WithEvents GrbTipo As System.Windows.Forms.GroupBox
    Friend WithEvents DgvHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblAcuenta As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RbtCredito As System.Windows.Forms.RadioButton
    Friend WithEvents RbtBanco As System.Windows.Forms.RadioButton
    Friend WithEvents RbtCaja As System.Windows.Forms.RadioButton
    Friend WithEvents RbtCanje As System.Windows.Forms.RadioButton
    Friend WithEvents RbtAnticipo As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblBanco As System.Windows.Forms.Label
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents LblCaja As System.Windows.Forms.Label
    Friend WithEvents LblAnticipo As System.Windows.Forms.Label
    Friend WithEvents LblCanje As System.Windows.Forms.Label
    Friend WithEvents RbtTodo As System.Windows.Forms.RadioButton
End Class
