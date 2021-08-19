<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaClientes
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
        Me.txtNombreFuncionario = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRUC = New System.Windows.Forms.RadioButton
        Me.chkNombre = New System.Windows.Forms.RadioButton
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView
        Me.lblTitulo = New Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreFuncionario
        '
        Me.txtNombreFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreFuncionario.Location = New System.Drawing.Point(73, 71)
        Me.txtNombreFuncionario.Name = "txtNombreFuncionario"
        Me.txtNombreFuncionario.Size = New System.Drawing.Size(343, 20)
        Me.txtNombreFuncionario.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(18, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar :"
        '
        'chkRUC
        '
        Me.chkRUC.AutoSize = True
        Me.chkRUC.BackColor = System.Drawing.Color.Transparent
        Me.chkRUC.Location = New System.Drawing.Point(21, 46)
        Me.chkRUC.Name = "chkRUC"
        Me.chkRUC.Size = New System.Drawing.Size(102, 17)
        Me.chkRUC.TabIndex = 0
        Me.chkRUC.Text = "Buscar por RUC"
        Me.chkRUC.UseVisualStyleBackColor = False
        '
        'chkNombre
        '
        Me.chkNombre.AutoSize = True
        Me.chkNombre.BackColor = System.Drawing.Color.Transparent
        Me.chkNombre.Location = New System.Drawing.Point(188, 46)
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Size = New System.Drawing.Size(116, 17)
        Me.chkNombre.TabIndex = 0
        Me.chkNombre.Text = "Buscar por Nombre"
        Me.chkNombre.UseVisualStyleBackColor = False
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncionarios.Location = New System.Drawing.Point(21, 102)
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.Size = New System.Drawing.Size(395, 349)
        Me.dgvFuncionarios.TabIndex = 2
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.SystemColors.Window
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblTitulo.Location = New System.Drawing.Point(0, 7)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.ShadowColor = System.Drawing.Color.Silver
        Me.lblTitulo.Size = New System.Drawing.Size(438, 29)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.Text = "Busqueda de Clientes"
        '
        'FrmBusquedaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.dgvFuncionarios)
        Me.Controls.Add(Me.chkNombre)
        Me.Controls.Add(Me.chkRUC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreFuncionario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaClientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreFuncionario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRUC As System.Windows.Forms.RadioButton
    Friend WithEvents chkNombre As System.Windows.Forms.RadioButton
    Friend WithEvents dgvFuncionarios As System.Windows.Forms.DataGridView
    Friend WithEvents lblTitulo As Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
End Class
