<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaFuncionarios
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
        Me.chkNegocio = New System.Windows.Forms.RadioButton
        Me.chkTeleventa = New System.Windows.Forms.RadioButton
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView
        Me.chkTodos = New System.Windows.Forms.RadioButton
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
        'chkNegocio
        '
        Me.chkNegocio.AutoSize = True
        Me.chkNegocio.BackColor = System.Drawing.Color.Transparent
        Me.chkNegocio.Location = New System.Drawing.Point(21, 46)
        Me.chkNegocio.Name = "chkNegocio"
        Me.chkNegocio.Size = New System.Drawing.Size(123, 17)
        Me.chkNegocio.TabIndex = 0
        Me.chkNegocio.Text = "Funcionario Negocio"
        Me.chkNegocio.UseVisualStyleBackColor = False
        '
        'chkTeleventa
        '
        Me.chkTeleventa.AutoSize = True
        Me.chkTeleventa.BackColor = System.Drawing.Color.Transparent
        Me.chkTeleventa.Location = New System.Drawing.Point(188, 46)
        Me.chkTeleventa.Name = "chkTeleventa"
        Me.chkTeleventa.Size = New System.Drawing.Size(136, 17)
        Me.chkTeleventa.TabIndex = 0
        Me.chkTeleventa.Text = "Funcionario Televentas"
        Me.chkTeleventa.UseVisualStyleBackColor = False
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncionarios.Location = New System.Drawing.Point(21, 102)
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.Size = New System.Drawing.Size(395, 349)
        Me.dgvFuncionarios.TabIndex = 2
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.BackColor = System.Drawing.Color.Transparent
        Me.chkTodos.Location = New System.Drawing.Point(361, 46)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(55, 17)
        Me.chkTodos.TabIndex = 0
        Me.chkTodos.Text = "Todos"
        Me.chkTodos.UseVisualStyleBackColor = False
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
        Me.lblTitulo.Text = "Busqueda de Funcionarios"
        '
        'FrmBusquedaFuncionarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.dgvFuncionarios)
        Me.Controls.Add(Me.chkTodos)
        Me.Controls.Add(Me.chkTeleventa)
        Me.Controls.Add(Me.chkNegocio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreFuncionario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaFuncionarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreFuncionario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkNegocio As System.Windows.Forms.RadioButton
    Friend WithEvents chkTeleventa As System.Windows.Forms.RadioButton
    Friend WithEvents dgvFuncionarios As System.Windows.Forms.DataGridView
    Friend WithEvents chkTodos As System.Windows.Forms.RadioButton
    Friend WithEvents lblTitulo As Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
End Class
