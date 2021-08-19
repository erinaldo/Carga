Imports System
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaRespFactura
    Inherits INTEGRACION.FrmPlantillaBusqueda

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
        Me.txtNombreRespfactura = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvRespFactura = New System.Windows.Forms.DataGridView
        CType(Me.dgvRespFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreRespfactura
        '
        Me.txtNombreRespfactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreRespfactura.Location = New System.Drawing.Point(61, 59)
        Me.txtNombreRespfactura.Name = "txtNombreRespfactura"
        Me.txtNombreRespfactura.Size = New System.Drawing.Size(352, 20)
        Me.txtNombreRespfactura.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(13, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Buscar :"
        '
        'dgvRespFactura
        '
        Me.dgvRespFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRespFactura.Location = New System.Drawing.Point(16, 95)
        Me.dgvRespFactura.Name = "dgvRespFactura"
        Me.dgvRespFactura.Size = New System.Drawing.Size(397, 350)
        Me.dgvRespFactura.TabIndex = 7
        '
        'FrmBusquedaRespFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(430, 466)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreRespfactura)
        Me.Controls.Add(Me.dgvRespFactura)
        Me.Name = "FrmBusquedaRespFactura"
        Me.Controls.SetChildIndex(Me.dgvRespFactura, 0)
        Me.Controls.SetChildIndex(Me.txtNombreRespfactura, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblTitulo, 0)
        CType(Me.dgvRespFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreRespfactura As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvRespFactura As System.Windows.Forms.DataGridView

End Class
