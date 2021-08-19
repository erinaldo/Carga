<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaContableDetalle
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoAfectacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboVenta = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboConcepto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCuentaCliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCuentaImpuesto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCuentaVenta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCuentaCosto = New System.Windows.Forms.TextBox()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.rbtAbonoCliente = New System.Windows.Forms.RadioButton()
        Me.rbtCargoCliente = New System.Windows.Forms.RadioButton()
        Me.grbImpuesto = New System.Windows.Forms.GroupBox()
        Me.rbtAbonoImpuesto = New System.Windows.Forms.RadioButton()
        Me.rbtCargoImpuesto = New System.Windows.Forms.RadioButton()
        Me.grbVenta = New System.Windows.Forms.GroupBox()
        Me.rbtAbonoVenta = New System.Windows.Forms.RadioButton()
        Me.rbtCargoVenta = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCuentaActividad = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboSubtipo = New System.Windows.Forms.ComboBox()
        Me.grbCliente.SuspendLayout()
        Me.grbImpuesto.SuspendLayout()
        Me.grbVenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGrabar
        '
        Me.btnGrabar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGrabar.Location = New System.Drawing.Point(155, 280)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(88, 36)
        Me.btnGrabar.TabIndex = 17
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(362, 280)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(88, 36)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Items.AddRange(New Object() {"(SELECCIONE)", "SOL", "DOLAR"})
        Me.cboMoneda.Location = New System.Drawing.Point(410, 76)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(159, 21)
        Me.cboMoneda.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Moneda"
        '
        'cboTipoAfectacion
        '
        Me.cboTipoAfectacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAfectacion.FormattingEnabled = True
        Me.cboTipoAfectacion.Items.AddRange(New Object() {"(SELECCIONE)", "AFECTO", "EXONERADO", "INAFECTO"})
        Me.cboTipoAfectacion.Location = New System.Drawing.Point(127, 76)
        Me.cboTipoAfectacion.Name = "cboTipoAfectacion"
        Me.cboTipoAfectacion.Size = New System.Drawing.Size(159, 21)
        Me.cboTipoAfectacion.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Tipo Afectación"
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.DropDownWidth = 200
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Location = New System.Drawing.Point(127, 44)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(159, 21)
        Me.cboTipoComprobante.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Tipo Comprobante"
        '
        'cboVenta
        '
        Me.cboVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVenta.FormattingEnabled = True
        Me.cboVenta.Items.AddRange(New Object() {"(SELECCIONE)", "CONTADO", "CREDITO"})
        Me.cboVenta.Location = New System.Drawing.Point(127, 12)
        Me.cboVenta.Name = "cboVenta"
        Me.cboVenta.Size = New System.Drawing.Size(159, 21)
        Me.cboVenta.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Tipo Venta"
        '
        'cboConcepto
        '
        Me.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConcepto.FormattingEnabled = True
        Me.cboConcepto.Items.AddRange(New Object() {"(SELECCIONE)", "ESPECIAL", "CARGA", "PASAJES"})
        Me.cboConcepto.Location = New System.Drawing.Point(410, 12)
        Me.cboConcepto.Name = "cboConcepto"
        Me.cboConcepto.Size = New System.Drawing.Size(159, 21)
        Me.cboConcepto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(324, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Concepto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Cuenta Cliente"
        '
        'txtCuentaCliente
        '
        Me.txtCuentaCliente.Location = New System.Drawing.Point(127, 117)
        Me.txtCuentaCliente.MaxLength = 8
        Me.txtCuentaCliente.Name = "txtCuentaCliente"
        Me.txtCuentaCliente.Size = New System.Drawing.Size(81, 20)
        Me.txtCuentaCliente.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(220, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Cuenta Impuesto"
        '
        'txtCuentaImpuesto
        '
        Me.txtCuentaImpuesto.Location = New System.Drawing.Point(313, 118)
        Me.txtCuentaImpuesto.MaxLength = 8
        Me.txtCuentaImpuesto.Name = "txtCuentaImpuesto"
        Me.txtCuentaImpuesto.Size = New System.Drawing.Size(81, 20)
        Me.txtCuentaImpuesto.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(409, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Cuenta Venta"
        '
        'txtCuentaVenta
        '
        Me.txtCuentaVenta.Location = New System.Drawing.Point(487, 117)
        Me.txtCuentaVenta.MaxLength = 8
        Me.txtCuentaVenta.Name = "txtCuentaVenta"
        Me.txtCuentaVenta.Size = New System.Drawing.Size(81, 20)
        Me.txtCuentaVenta.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Centro Costo"
        '
        'txtCuentaCosto
        '
        Me.txtCuentaCosto.Location = New System.Drawing.Point(127, 154)
        Me.txtCuentaCosto.MaxLength = 8
        Me.txtCuentaCosto.Name = "txtCuentaCosto"
        Me.txtCuentaCosto.Size = New System.Drawing.Size(81, 20)
        Me.txtCuentaCosto.TabIndex = 9
        '
        'grbCliente
        '
        Me.grbCliente.Controls.Add(Me.rbtAbonoCliente)
        Me.grbCliente.Controls.Add(Me.rbtCargoCliente)
        Me.grbCliente.Location = New System.Drawing.Point(24, 198)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(167, 49)
        Me.grbCliente.TabIndex = 52
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Movimiento Cliente"
        '
        'rbtAbonoCliente
        '
        Me.rbtAbonoCliente.AutoSize = True
        Me.rbtAbonoCliente.Location = New System.Drawing.Point(92, 20)
        Me.rbtAbonoCliente.Name = "rbtAbonoCliente"
        Me.rbtAbonoCliente.Size = New System.Drawing.Size(56, 17)
        Me.rbtAbonoCliente.TabIndex = 12
        Me.rbtAbonoCliente.TabStop = True
        Me.rbtAbonoCliente.Text = "Abono"
        Me.rbtAbonoCliente.UseVisualStyleBackColor = True
        '
        'rbtCargoCliente
        '
        Me.rbtCargoCliente.AutoSize = True
        Me.rbtCargoCliente.Location = New System.Drawing.Point(9, 20)
        Me.rbtCargoCliente.Name = "rbtCargoCliente"
        Me.rbtCargoCliente.Size = New System.Drawing.Size(53, 17)
        Me.rbtCargoCliente.TabIndex = 11
        Me.rbtCargoCliente.TabStop = True
        Me.rbtCargoCliente.Text = "Cargo"
        Me.rbtCargoCliente.UseVisualStyleBackColor = True
        '
        'grbImpuesto
        '
        Me.grbImpuesto.Controls.Add(Me.rbtAbonoImpuesto)
        Me.grbImpuesto.Controls.Add(Me.rbtCargoImpuesto)
        Me.grbImpuesto.Location = New System.Drawing.Point(212, 198)
        Me.grbImpuesto.Name = "grbImpuesto"
        Me.grbImpuesto.Size = New System.Drawing.Size(167, 49)
        Me.grbImpuesto.TabIndex = 52
        Me.grbImpuesto.TabStop = False
        Me.grbImpuesto.Text = "Movimiento Impuesto"
        '
        'rbtAbonoImpuesto
        '
        Me.rbtAbonoImpuesto.AutoSize = True
        Me.rbtAbonoImpuesto.Location = New System.Drawing.Point(92, 20)
        Me.rbtAbonoImpuesto.Name = "rbtAbonoImpuesto"
        Me.rbtAbonoImpuesto.Size = New System.Drawing.Size(56, 17)
        Me.rbtAbonoImpuesto.TabIndex = 14
        Me.rbtAbonoImpuesto.TabStop = True
        Me.rbtAbonoImpuesto.Text = "Abono"
        Me.rbtAbonoImpuesto.UseVisualStyleBackColor = True
        '
        'rbtCargoImpuesto
        '
        Me.rbtCargoImpuesto.AutoSize = True
        Me.rbtCargoImpuesto.Location = New System.Drawing.Point(9, 20)
        Me.rbtCargoImpuesto.Name = "rbtCargoImpuesto"
        Me.rbtCargoImpuesto.Size = New System.Drawing.Size(53, 17)
        Me.rbtCargoImpuesto.TabIndex = 13
        Me.rbtCargoImpuesto.TabStop = True
        Me.rbtCargoImpuesto.Text = "Cargo"
        Me.rbtCargoImpuesto.UseVisualStyleBackColor = True
        '
        'grbVenta
        '
        Me.grbVenta.Controls.Add(Me.rbtAbonoVenta)
        Me.grbVenta.Controls.Add(Me.rbtCargoVenta)
        Me.grbVenta.Location = New System.Drawing.Point(401, 198)
        Me.grbVenta.Name = "grbVenta"
        Me.grbVenta.Size = New System.Drawing.Size(167, 49)
        Me.grbVenta.TabIndex = 52
        Me.grbVenta.TabStop = False
        Me.grbVenta.Text = "Movimiento Venta"
        '
        'rbtAbonoVenta
        '
        Me.rbtAbonoVenta.AutoSize = True
        Me.rbtAbonoVenta.Location = New System.Drawing.Point(92, 20)
        Me.rbtAbonoVenta.Name = "rbtAbonoVenta"
        Me.rbtAbonoVenta.Size = New System.Drawing.Size(56, 17)
        Me.rbtAbonoVenta.TabIndex = 16
        Me.rbtAbonoVenta.TabStop = True
        Me.rbtAbonoVenta.Text = "Abono"
        Me.rbtAbonoVenta.UseVisualStyleBackColor = True
        '
        'rbtCargoVenta
        '
        Me.rbtCargoVenta.AutoSize = True
        Me.rbtCargoVenta.Location = New System.Drawing.Point(9, 20)
        Me.rbtCargoVenta.Name = "rbtCargoVenta"
        Me.rbtCargoVenta.Size = New System.Drawing.Size(53, 17)
        Me.rbtCargoVenta.TabIndex = 15
        Me.rbtCargoVenta.TabStop = True
        Me.rbtCargoVenta.Text = "Cargo"
        Me.rbtCargoVenta.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(220, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Cuenta Actividad"
        '
        'txtCuentaActividad
        '
        Me.txtCuentaActividad.Location = New System.Drawing.Point(313, 154)
        Me.txtCuentaActividad.MaxLength = 8
        Me.txtCuentaActividad.Name = "txtCuentaActividad"
        Me.txtCuentaActividad.Size = New System.Drawing.Size(81, 20)
        Me.txtCuentaActividad.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(324, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Subtipo"
        '
        'cboSubtipo
        '
        Me.cboSubtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubtipo.FormattingEnabled = True
        Me.cboSubtipo.Items.AddRange(New Object() {"(SEELCCIONE)", "AFECTO", "EXONERADO", "INAFECTO"})
        Me.cboSubtipo.Location = New System.Drawing.Point(410, 44)
        Me.cboSubtipo.Name = "cboSubtipo"
        Me.cboSubtipo.Size = New System.Drawing.Size(159, 21)
        Me.cboSubtipo.TabIndex = 3
        '
        'frmCuentaContableDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 342)
        Me.Controls.Add(Me.grbVenta)
        Me.Controls.Add(Me.grbImpuesto)
        Me.Controls.Add(Me.grbCliente)
        Me.Controls.Add(Me.txtCuentaActividad)
        Me.Controls.Add(Me.txtCuentaCosto)
        Me.Controls.Add(Me.txtCuentaVenta)
        Me.Controls.Add(Me.txtCuentaImpuesto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCuentaCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboMoneda)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboSubtipo)
        Me.Controls.Add(Me.cboTipoAfectacion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTipoComprobante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboVenta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboConcepto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentaContableDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta Contable"
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.grbImpuesto.ResumeLayout(False)
        Me.grbImpuesto.PerformLayout()
        Me.grbVenta.ResumeLayout(False)
        Me.grbVenta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAfectacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboVenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCosto As System.Windows.Forms.TextBox
    Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAbonoCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCargoCliente As System.Windows.Forms.RadioButton
    Friend WithEvents grbImpuesto As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAbonoImpuesto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCargoImpuesto As System.Windows.Forms.RadioButton
    Friend WithEvents grbVenta As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAbonoVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCargoVenta As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaActividad As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboSubtipo As System.Windows.Forms.ComboBox
End Class
