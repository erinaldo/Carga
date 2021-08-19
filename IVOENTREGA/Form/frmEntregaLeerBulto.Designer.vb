<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregaSalidaBulto
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grbDocumento = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblConsignado = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblFechaDocumento = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTipoAlmacen = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.chkTeclado = New System.Windows.Forms.CheckBox()
        Me.grbDocumento.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(248, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código Bulto"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(348, 120)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(159, 22)
        Me.txtCodigo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Doc."
        '
        'grbDocumento
        '
        Me.grbDocumento.Controls.Add(Me.Label11)
        Me.grbDocumento.Controls.Add(Me.Label7)
        Me.grbDocumento.Controls.Add(Me.Label4)
        Me.grbDocumento.Controls.Add(Me.lblConsignado)
        Me.grbDocumento.Controls.Add(Me.lblPeso)
        Me.grbDocumento.Controls.Add(Me.lblCantidad)
        Me.grbDocumento.Controls.Add(Me.lblFechaDocumento)
        Me.grbDocumento.Controls.Add(Me.Label8)
        Me.grbDocumento.Controls.Add(Me.lblTipoDocumento)
        Me.grbDocumento.Controls.Add(Me.Label5)
        Me.grbDocumento.Controls.Add(Me.lblTipoAlmacen)
        Me.grbDocumento.Controls.Add(Me.Label3)
        Me.grbDocumento.Controls.Add(Me.lblNumeroDocumento)
        Me.grbDocumento.Controls.Add(Me.Label2)
        Me.grbDocumento.Location = New System.Drawing.Point(10, 8)
        Me.grbDocumento.Name = "grbDocumento"
        Me.grbDocumento.Size = New System.Drawing.Size(753, 93)
        Me.grbDocumento.TabIndex = 2
        Me.grbDocumento.TabStop = False
        Me.grbDocumento.Text = "Documento"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(183, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Peso Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cantidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Consignado"
        '
        'lblConsignado
        '
        Me.lblConsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsignado.Location = New System.Drawing.Point(85, 69)
        Me.lblConsignado.Name = "lblConsignado"
        Me.lblConsignado.Size = New System.Drawing.Size(515, 13)
        Me.lblConsignado.TabIndex = 0
        '
        'lblPeso
        '
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.Location = New System.Drawing.Point(280, 45)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(73, 13)
        Me.lblPeso.TabIndex = 0
        '
        'lblCantidad
        '
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(85, 45)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(73, 13)
        Me.lblCantidad.TabIndex = 0
        '
        'lblFechaDocumento
        '
        Me.lblFechaDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaDocumento.Location = New System.Drawing.Point(85, 21)
        Me.lblFechaDocumento.Name = "lblFechaDocumento"
        Me.lblFechaDocumento.Size = New System.Drawing.Size(88, 13)
        Me.lblFechaDocumento.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(401, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Nº Documento"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento.Location = New System.Drawing.Point(280, 21)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(119, 13)
        Me.lblTipoDocumento.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(183, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tipo Documento"
        '
        'lblTipoAlmacen
        '
        Me.lblTipoAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoAlmacen.ForeColor = System.Drawing.Color.Red
        Me.lblTipoAlmacen.Location = New System.Drawing.Point(609, 11)
        Me.lblTipoAlmacen.Name = "lblTipoAlmacen"
        Me.lblTipoAlmacen.Size = New System.Drawing.Size(139, 76)
        Me.lblTipoAlmacen.TabIndex = 0
        Me.lblTipoAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(634, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 61)
        Me.Label3.TabIndex = 0
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(491, 21)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(99, 13)
        Me.lblNumeroDocumento.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 164)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(753, 368)
        Me.dgv.TabIndex = 3
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(513, 109)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(250, 41)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkTeclado
        '
        Me.chkTeclado.AutoSize = True
        Me.chkTeclado.Location = New System.Drawing.Point(23, 126)
        Me.chkTeclado.Name = "chkTeclado"
        Me.chkTeclado.Size = New System.Drawing.Size(65, 17)
        Me.chkTeclado.TabIndex = 4
        Me.chkTeclado.Text = "Teclado"
        Me.chkTeclado.UseVisualStyleBackColor = True
        Me.chkTeclado.Visible = False
        '
        'frmEntregaSalidaBulto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 544)
        Me.Controls.Add(Me.chkTeclado)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.grbDocumento)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblEstado)
        Me.Name = "frmEntregaSalidaBulto"
        Me.Text = "Salida Bulto de Almacén"
        Me.grbDocumento.ResumeLayout(False)
        Me.grbDocumento.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grbDocumento As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblConsignado As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblFechaDocumento As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTipoAlmacen As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents chkTeclado As System.Windows.Forms.CheckBox
End Class
