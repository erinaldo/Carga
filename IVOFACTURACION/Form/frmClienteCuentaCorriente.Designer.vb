<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClienteCuentaCorriente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClienteCuentaCorriente))
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.grbLineaCredito = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        Me.btnActualizarPagos = New System.Windows.Forms.Button()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbLineaCredito.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvResultado
        '
        Me.dgvResultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Location = New System.Drawing.Point(10, 60)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(954, 372)
        Me.dgvResultado.TabIndex = 0
        '
        'grbLineaCredito
        '
        Me.grbLineaCredito.Controls.Add(Me.Label1)
        Me.grbLineaCredito.Controls.Add(Me.cboEstado)
        Me.grbLineaCredito.Location = New System.Drawing.Point(213, 6)
        Me.grbLineaCredito.Name = "grbLineaCredito"
        Me.grbLineaCredito.Size = New System.Drawing.Size(195, 48)
        Me.grbLineaCredito.TabIndex = 201
        Me.grbLineaCredito.TabStop = False
        Me.grbLineaCredito.Text = "Línea de Crédito"
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnExportar)
        Me.Panel2.Controls.Add(Me.BtnFiltrar)
        Me.Panel2.Location = New System.Drawing.Point(560, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(194, 31)
        Me.Panel2.TabIndex = 208
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(114, 0)
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
        'btnActualizarPagos
        '
        Me.btnActualizarPagos.Image = CType(resources.GetObject("btnActualizarPagos.Image"), System.Drawing.Image)
        Me.btnActualizarPagos.Location = New System.Drawing.Point(919, 15)
        Me.btnActualizarPagos.Name = "btnActualizarPagos"
        Me.btnActualizarPagos.Size = New System.Drawing.Size(44, 37)
        Me.btnActualizarPagos.TabIndex = 209
        Me.btnActualizarPagos.UseVisualStyleBackColor = True
        '
        'frmClienteCuentaCorriente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 444)
        Me.Controls.Add(Me.btnActualizarPagos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grbLineaCredito)
        Me.Controls.Add(Me.dgvResultado)
        Me.Name = "frmClienteCuentaCorriente"
        Me.Text = "frmClienteCuentaCorriente"
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbLineaCredito.ResumeLayout(False)
        Me.grbLineaCredito.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents grbLineaCredito As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnActualizarPagos As System.Windows.Forms.Button
End Class
