<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaContable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentaContable))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboConcepto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoAfectacion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboVenta = New System.Windows.Forms.ComboBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(7, 68)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1062, 506)
        Me.dgv.TabIndex = 0
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(985, 27)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(84, 34)
        Me.btnConsultar.TabIndex = 30
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.toolStripSeparator2, Me.tsbEditar, Me.tsbAnular, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1077, 25)
        Me.toolStrip1.TabIndex = 38
        Me.toolStrip1.Text = "toolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.ForeColor = System.Drawing.Color.Black
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbEditar
        '
        Me.tsbEditar.Enabled = False
        Me.tsbEditar.ForeColor = System.Drawing.Color.Black
        Me.tsbEditar.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "Editar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.ForeColor = System.Drawing.Color.Black
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources.delete_16
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSalir
        '
        Me.tsbSalir.ForeColor = System.Drawing.Color.Black
        Me.tsbSalir.Image = Global.INTEGRACION.My.Resources.Resources._1323
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(139, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Concepto"
        '
        'cboConcepto
        '
        Me.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConcepto.FormattingEnabled = True
        Me.cboConcepto.Items.AddRange(New Object() {"(TODO)", "ESPECIAL", "CARGA", "PASAJES"})
        Me.cboConcepto.Location = New System.Drawing.Point(195, 35)
        Me.cboConcepto.Name = "cboConcepto"
        Me.cboConcepto.Size = New System.Drawing.Size(121, 21)
        Me.cboConcepto.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(327, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Tipo Comprobante"
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"(TODO)", "ESPECIAL", "CARGA", "PASAJES"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(427, 35)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoComprobante.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(570, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Tipo Afectación"
        '
        'cboTipoAfectacion
        '
        Me.cboTipoAfectacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAfectacion.FormattingEnabled = True
        Me.cboTipoAfectacion.Items.AddRange(New Object() {"(TODO)", "AFECTO", "EXONERADO", "INAFECTO"})
        Me.cboTipoAfectacion.Location = New System.Drawing.Point(658, 35)
        Me.cboTipoAfectacion.Name = "cboTipoAfectacion"
        Me.cboTipoAfectacion.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoAfectacion.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(799, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Items.AddRange(New Object() {"(TODO)", "SOL", "DOLAR"})
        Me.cboMoneda.Location = New System.Drawing.Point(849, 35)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(121, 21)
        Me.cboMoneda.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Venta"
        '
        'cboVenta
        '
        Me.cboVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVenta.FormattingEnabled = True
        Me.cboVenta.Items.AddRange(New Object() {"(TODO)", "CONTADO", "CREDITO"})
        Me.cboVenta.Location = New System.Drawing.Point(45, 35)
        Me.cboVenta.Name = "cboVenta"
        Me.cboVenta.Size = New System.Drawing.Size(88, 21)
        Me.cboVenta.TabIndex = 40
        '
        'frmCuentaContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 579)
        Me.Controls.Add(Me.cboMoneda)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTipoAfectacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTipoComprobante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboVenta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboConcepto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmCuentaContable"
        Me.Text = "Cuenta Contable"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAfectacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVenta As System.Windows.Forms.ComboBox
End Class
