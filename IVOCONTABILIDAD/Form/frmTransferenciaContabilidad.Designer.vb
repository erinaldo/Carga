<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciaContabilidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferenciaContabilidad))
        Me.dgvVenta = New System.Windows.Forms.DataGridView()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.cboTipoVenta = New System.Windows.Forms.ComboBox()
        Me.cboTipoTransferencia = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblNoTransferido = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTransferido = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCredito = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblContado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnTransferir = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvVenta
        '
        Me.dgvVenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVenta.Location = New System.Drawing.Point(12, 50)
        Me.dgvVenta.Name = "dgvVenta"
        Me.dgvVenta.Size = New System.Drawing.Size(1108, 378)
        Me.dgvVenta.TabIndex = 0
        '
        'Label145
        '
        Me.Label145.AutoSize = True
        Me.Label145.Location = New System.Drawing.Point(57, 20)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(23, 13)
        Me.Label145.TabIndex = 24
        Me.Label145.Text = "Del"
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(86, 17)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(84, 20)
        Me.dtpInicio.TabIndex = 25
        '
        'Label147
        '
        Me.Label147.AutoSize = True
        Me.Label147.Location = New System.Drawing.Point(176, 20)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(16, 13)
        Me.Label147.TabIndex = 26
        Me.Label147.Text = "Al"
        '
        'dtpFin
        '
        Me.dtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFin.CustomFormat = ""
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(198, 17)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(84, 20)
        Me.dtpFin.TabIndex = 27
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(1036, 8)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(84, 34)
        Me.btnConsultar.TabIndex = 29
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboTipoVenta
        '
        Me.cboTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVenta.FormattingEnabled = True
        Me.cboTipoVenta.Items.AddRange(New Object() {"(TODO)", "CONTADO", "CREDITO"})
        Me.cboTipoVenta.Location = New System.Drawing.Point(386, 16)
        Me.cboTipoVenta.Name = "cboTipoVenta"
        Me.cboTipoVenta.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoVenta.TabIndex = 30
        '
        'cboTipoTransferencia
        '
        Me.cboTipoTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTransferencia.FormattingEnabled = True
        Me.cboTipoTransferencia.Items.AddRange(New Object() {"(TODO)", "SI", "NO"})
        Me.cboTipoTransferencia.Location = New System.Drawing.Point(612, 16)
        Me.cboTipoTransferencia.Name = "cboTipoTransferencia"
        Me.cboTipoTransferencia.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoTransferencia.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(324, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Tipo Venta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(550, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Transferido"
        '
        'dgvLog
        '
        Me.dgvLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Location = New System.Drawing.Point(12, 434)
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.Size = New System.Drawing.Size(1108, 113)
        Me.dgvLog.TabIndex = 32
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblNoTransferido)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblTransferido)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblCredito)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblContado)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblTotalVenta)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblNumero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 546)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1107, 36)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'lblNoTransferido
        '
        Me.lblNoTransferido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoTransferido.Location = New System.Drawing.Point(1004, 14)
        Me.lblNoTransferido.Name = "lblNoTransferido"
        Me.lblNoTransferido.Size = New System.Drawing.Size(91, 13)
        Me.lblNoTransferido.TabIndex = 0
        Me.lblNoTransferido.Text = "0.00"
        Me.lblNoTransferido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(929, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "No Transferido"
        '
        'lblTransferido
        '
        Me.lblTransferido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransferido.Location = New System.Drawing.Point(809, 14)
        Me.lblTransferido.Name = "lblTransferido"
        Me.lblTransferido.Size = New System.Drawing.Size(91, 13)
        Me.lblTransferido.TabIndex = 0
        Me.lblTransferido.Text = "0.00"
        Me.lblTransferido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(749, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Transferido"
        '
        'lblCredito
        '
        Me.lblCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredito.Location = New System.Drawing.Point(601, 14)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(91, 13)
        Me.lblCredito.TabIndex = 0
        Me.lblCredito.Text = "0.00"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(554, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Crédito"
        '
        'lblContado
        '
        Me.lblContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContado.Location = New System.Drawing.Point(452, 14)
        Me.lblContado.Name = "lblContado"
        Me.lblContado.Size = New System.Drawing.Size(91, 13)
        Me.lblContado.TabIndex = 0
        Me.lblContado.Text = "0.00"
        Me.lblContado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(405, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Contado"
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.Location = New System.Drawing.Point(265, 14)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(106, 13)
        Me.lblTotalVenta.TabIndex = 0
        Me.lblTotalVenta.Text = "0.00"
        Me.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(200, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total Venta"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(243, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "0.00"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumero
        '
        Me.lblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.Location = New System.Drawing.Point(73, 14)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(63, 13)
        Me.lblNumero.TabIndex = 0
        Me.lblNumero.Text = "0"
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nº Registros"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Fecha"
        '
        'btnTransferir
        '
        Me.btnTransferir.Image = Global.INTEGRACION.My.Resources.Resources.arrow_forward_24
        Me.btnTransferir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTransferir.Location = New System.Drawing.Point(799, 8)
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Size = New System.Drawing.Size(84, 34)
        Me.btnTransferir.TabIndex = 29
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTransferir.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.Image = Global.INTEGRACION.My.Resources.Resources.delete_161
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(911, 8)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(84, 34)
        Me.btnAnular.TabIndex = 29
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'frmTransferenciaContabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 586)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTipoTransferencia)
        Me.Controls.Add(Me.cboTipoVenta)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btnTransferir)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label145)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.Label147)
        Me.Controls.Add(Me.dtpFin)
        Me.Controls.Add(Me.dgvVenta)
        Me.Name = "frmTransferenciaContabilidad"
        Me.Text = "Transferencia a Contabilidad"
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvVenta As System.Windows.Forms.DataGridView
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboTipoVenta As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoTransferencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblContado As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalVenta As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNoTransferido As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTransferido As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblCredito As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnTransferir As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
End Class
