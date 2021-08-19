<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLineaCredito2
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.grbLineaCredito = New System.Windows.Forms.GroupBox()
        Me.grbVenta = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbLineaCredito.SuspendLayout()
        Me.grbVenta.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(160, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Fecha Fin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Fecha Inicio"
        '
        'dgvResultado
        '
        Me.dgvResultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Location = New System.Drawing.Point(9, 76)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1052, 387)
        Me.dgvResultado.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Estado"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"(TODO)", "ACTIVO", "DESACTIVADO", "CANCELADO"})
        Me.cboEstado.Location = New System.Drawing.Point(54, 17)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(134, 21)
        Me.cboEstado.TabIndex = 198
        '
        'grbLineaCredito
        '
        Me.grbLineaCredito.Controls.Add(Me.Label1)
        Me.grbLineaCredito.Controls.Add(Me.cboEstado)
        Me.grbLineaCredito.Location = New System.Drawing.Point(318, 11)
        Me.grbLineaCredito.Name = "grbLineaCredito"
        Me.grbLineaCredito.Size = New System.Drawing.Size(195, 48)
        Me.grbLineaCredito.TabIndex = 200
        Me.grbLineaCredito.TabStop = False
        Me.grbLineaCredito.Text = "Línea de Crédito"
        '
        'grbVenta
        '
        Me.grbVenta.Controls.Add(Me.dtpFechaFin)
        Me.grbVenta.Controls.Add(Me.dtpFechaInicio)
        Me.grbVenta.Controls.Add(Me.Label3)
        Me.grbVenta.Controls.Add(Me.Label11)
        Me.grbVenta.Location = New System.Drawing.Point(9, 11)
        Me.grbVenta.Name = "grbVenta"
        Me.grbVenta.Size = New System.Drawing.Size(304, 48)
        Me.grbVenta.TabIndex = 201
        Me.grbVenta.TabStop = False
        Me.grbVenta.Text = "Venta"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "MMM - yyyy"
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(216, 17)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(82, 20)
        Me.dtpFechaFin.TabIndex = 18
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = "MMM - yyyy"
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicio.Location = New System.Drawing.Point(74, 17)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtpFechaInicio.TabIndex = 18
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCliente.Location = New System.Drawing.Point(573, 28)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(98, 20)
        Me.txtCodigoCliente.TabIndex = 205
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Location = New System.Drawing.Point(671, 28)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(296, 20)
        Me.txtCliente.TabIndex = 206
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(531, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 204
        Me.Label8.Text = "Cliente"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnExportar)
        Me.Panel2.Controls.Add(Me.BtnFiltrar)
        Me.Panel2.Location = New System.Drawing.Point(981, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(84, 64)
        Me.Panel2.TabIndex = 207
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(3, 34)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(77, 29)
        Me.btnExportar.TabIndex = 14
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltrar.Location = New System.Drawing.Point(3, 0)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(77, 29)
        Me.BtnFiltrar.TabIndex = 13
        Me.BtnFiltrar.Text = "Filtrar"
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'frmLineaCredito2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 475)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtCodigoCliente)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.grbVenta)
        Me.Controls.Add(Me.grbLineaCredito)
        Me.Controls.Add(Me.dgvResultado)
        Me.Name = "frmLineaCredito2"
        Me.Text = "Línea de Crédito"
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbLineaCredito.ResumeLayout(False)
        Me.grbLineaCredito.PerformLayout()
        Me.grbVenta.ResumeLayout(False)
        Me.grbVenta.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents grbLineaCredito As System.Windows.Forms.GroupBox
    Friend WithEvents grbVenta As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
End Class
