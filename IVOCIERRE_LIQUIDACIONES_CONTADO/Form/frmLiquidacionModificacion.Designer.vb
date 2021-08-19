<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiquidacionModificacion
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
        Me.tabLiquidacion = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.dgvPago = New System.Windows.Forms.DataGridView()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.tabMantenimiento = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.cboTipoTarjeta = New System.Windows.Forms.ComboBox()
        Me.cboTipoPago = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTarjeta = New System.Windows.Forms.ComboBox()
        Me.tabLiquidacion.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgvPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMantenimiento.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabLiquidacion
        '
        Me.tabLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLiquidacion.Controls.Add(Me.tabLista)
        Me.tabLiquidacion.Controls.Add(Me.tabMantenimiento)
        Me.tabLiquidacion.Location = New System.Drawing.Point(10, 8)
        Me.tabLiquidacion.Name = "tabLiquidacion"
        Me.tabLiquidacion.SelectedIndex = 0
        Me.tabLiquidacion.Size = New System.Drawing.Size(718, 409)
        Me.tabLiquidacion.TabIndex = 1
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.dgvPago)
        Me.tabLista.Controls.Add(Me.dgv)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(710, 383)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'dgvPago
        '
        Me.dgvPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPago.Location = New System.Drawing.Point(6, 234)
        Me.dgvPago.Name = "dgvPago"
        Me.dgvPago.Size = New System.Drawing.Size(695, 143)
        Me.dgvPago.TabIndex = 1
        '
        'dgv
        '
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(6, 10)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(695, 218)
        Me.dgv.TabIndex = 1
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.Controls.Add(Me.btnCancelar)
        Me.tabMantenimiento.Controls.Add(Me.btnGrabar)
        Me.tabMantenimiento.Controls.Add(Me.cboTarjeta)
        Me.tabMantenimiento.Controls.Add(Me.cboTipoTarjeta)
        Me.tabMantenimiento.Controls.Add(Me.cboTipoPago)
        Me.tabMantenimiento.Controls.Add(Me.Label3)
        Me.tabMantenimiento.Controls.Add(Me.Label2)
        Me.tabMantenimiento.Controls.Add(Me.Label1)
        Me.tabMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMantenimiento.Size = New System.Drawing.Size(710, 383)
        Me.tabMantenimiento.TabIndex = 1
        Me.tabMantenimiento.Text = "Mantenimiento"
        Me.tabMantenimiento.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(410, 230)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 29)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(260, 230)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(77, 29)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'cboTipoTarjeta
        '
        Me.cboTipoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarjeta.FormattingEnabled = True
        Me.cboTipoTarjeta.Location = New System.Drawing.Point(326, 122)
        Me.cboTipoTarjeta.Name = "cboTipoTarjeta"
        Me.cboTipoTarjeta.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoTarjeta.TabIndex = 1
        '
        'cboTipoPago
        '
        Me.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago.FormattingEnabled = True
        Me.cboTipoPago.Location = New System.Drawing.Point(326, 81)
        Me.cboTipoPago.Name = "cboTipoPago"
        Me.cboTipoPago.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoPago.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(248, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tarjeta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(247, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo Tarjeta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(247, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Pago"
        '
        'cboTarjeta
        '
        Me.cboTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTarjeta.FormattingEnabled = True
        Me.cboTarjeta.Location = New System.Drawing.Point(326, 161)
        Me.cboTarjeta.Name = "cboTarjeta"
        Me.cboTarjeta.Size = New System.Drawing.Size(150, 21)
        Me.cboTarjeta.TabIndex = 1
        '
        'frmLiquidacionModificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 425)
        Me.Controls.Add(Me.tabLiquidacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLiquidacionModificacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidación Detalle"
        Me.tabLiquidacion.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        CType(Me.dgvPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabMantenimiento.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabLiquidacion As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents tabMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cboTipoTarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvPago As System.Windows.Forms.DataGridView
    Friend WithEvents cboTarjeta As System.Windows.Forms.ComboBox
End Class
