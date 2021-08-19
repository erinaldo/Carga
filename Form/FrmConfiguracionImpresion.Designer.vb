<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracionImpresion
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboImpresora = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RbtPaginas = New System.Windows.Forms.RadioButton
        Me.PnlIntervalo = New System.Windows.Forms.Panel
        Me.Txta = New System.Windows.Forms.TextBox
        Me.TxtDe = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RbtTodo = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtCopias = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnAceptar = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.PnlIntervalo.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TxtCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboImpresora)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(409, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impresora"
        '
        'CboImpresora
        '
        Me.CboImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboImpresora.FormattingEnabled = True
        Me.CboImpresora.Location = New System.Drawing.Point(68, 25)
        Me.CboImpresora.Name = "CboImpresora"
        Me.CboImpresora.Size = New System.Drawing.Size(335, 21)
        Me.CboImpresora.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbtPaginas)
        Me.GroupBox2.Controls.Add(Me.PnlIntervalo)
        Me.GroupBox2.Controls.Add(Me.RbtTodo)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(225, 72)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Intervalo de Impresión"
        '
        'RbtPaginas
        '
        Me.RbtPaginas.AutoSize = True
        Me.RbtPaginas.Location = New System.Drawing.Point(8, 42)
        Me.RbtPaginas.Name = "RbtPaginas"
        Me.RbtPaginas.Size = New System.Drawing.Size(63, 17)
        Me.RbtPaginas.TabIndex = 5
        Me.RbtPaginas.TabStop = True
        Me.RbtPaginas.Text = "Páginas"
        Me.RbtPaginas.UseVisualStyleBackColor = True
        '
        'PnlIntervalo
        '
        Me.PnlIntervalo.Controls.Add(Me.Txta)
        Me.PnlIntervalo.Controls.Add(Me.TxtDe)
        Me.PnlIntervalo.Controls.Add(Me.Label3)
        Me.PnlIntervalo.Controls.Add(Me.Label2)
        Me.PnlIntervalo.Enabled = False
        Me.PnlIntervalo.Location = New System.Drawing.Point(77, 40)
        Me.PnlIntervalo.Name = "PnlIntervalo"
        Me.PnlIntervalo.Size = New System.Drawing.Size(142, 26)
        Me.PnlIntervalo.TabIndex = 4
        '
        'Txta
        '
        Me.Txta.Location = New System.Drawing.Point(101, 0)
        Me.Txta.MaxLength = 3
        Me.Txta.Name = "Txta"
        Me.Txta.Size = New System.Drawing.Size(38, 20)
        Me.Txta.TabIndex = 7
        '
        'TxtDe
        '
        Me.TxtDe.Location = New System.Drawing.Point(30, 0)
        Me.TxtDe.MaxLength = 3
        Me.TxtDe.Name = "TxtDe"
        Me.TxtDe.Size = New System.Drawing.Size(38, 20)
        Me.TxtDe.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(79, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "a:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "de:"
        '
        'RbtTodo
        '
        Me.RbtTodo.AutoSize = True
        Me.RbtTodo.Checked = True
        Me.RbtTodo.Location = New System.Drawing.Point(8, 19)
        Me.RbtTodo.Name = "RbtTodo"
        Me.RbtTodo.Size = New System.Drawing.Size(50, 17)
        Me.RbtTodo.TabIndex = 0
        Me.RbtTodo.TabStop = True
        Me.RbtTodo.Text = "Todo"
        Me.RbtTodo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtCopias)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(243, 83)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(178, 72)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Copias"
        '
        'TxtCopias
        '
        Me.TxtCopias.Location = New System.Drawing.Point(125, 29)
        Me.TxtCopias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtCopias.Name = "TxtCopias"
        Me.TxtCopias.Size = New System.Drawing.Size(47, 20)
        Me.TxtCopias.TabIndex = 1
        Me.TxtCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Número de Copias:"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(265, 171)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(346, 171)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'FrmConfiguracionImpresion
        '
        Me.AcceptButton = Me.BtnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(430, 205)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfiguracionImpresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PnlIntervalo.ResumeLayout(False)
        Me.PnlIntervalo.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TxtCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RbtTodo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents TxtCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PnlIntervalo As System.Windows.Forms.Panel
    Friend WithEvents Txta As System.Windows.Forms.TextBox
    Friend WithEvents TxtDe As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RbtPaginas As System.Windows.Forms.RadioButton
End Class
