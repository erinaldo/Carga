Imports System
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrutasrecojoentrega
    Inherits INTEGRACION.FrmPlantillaunidadtransporte
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
        Me.Labidruta = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Labruta = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtidruta = New System.Windows.Forms.TextBox
        Me.dgvdetalle = New System.Windows.Forms.DataGridView
        Me.cmboperacion = New System.Windows.Forms.ComboBox
        Me.txtruta = New System.Windows.Forms.TextBox
        Me.cmbdepartamento = New System.Windows.Forms.ComboBox
        Me.txtidpais = New System.Windows.Forms.TextBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        CType(Me.dgvdetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.txtidpais)
        Me.TabDatos.Controls.Add(Me.cmbdepartamento)
        Me.TabDatos.Controls.Add(Me.txtruta)
        Me.TabDatos.Controls.Add(Me.cmboperacion)
        Me.TabDatos.Controls.Add(Me.dgvdetalle)
        Me.TabDatos.Controls.Add(Me.txtidruta)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Controls.Add(Me.Labruta)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.Labidruta)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'Labidruta
        '
        Me.Labidruta.AutoSize = True
        Me.Labidruta.BackColor = System.Drawing.Color.Transparent
        Me.Labidruta.Location = New System.Drawing.Point(5, 80)
        Me.Labidruta.Name = "Labidruta"
        Me.Labidruta.Size = New System.Drawing.Size(45, 13)
        Me.Labidruta.TabIndex = 0
        Me.Labidruta.Text = "Id. Ruta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(287, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Operación : "
        '
        'Labruta
        '
        Me.Labruta.AutoSize = True
        Me.Labruta.BackColor = System.Drawing.Color.Transparent
        Me.Labruta.Location = New System.Drawing.Point(5, 117)
        Me.Labruta.Name = "Labruta"
        Me.Labruta.Size = New System.Drawing.Size(36, 13)
        Me.Labruta.TabIndex = 2
        Me.Labruta.Text = "Ruta :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Departamento : "
        '
        'txtidruta
        '
        Me.txtidruta.BackColor = System.Drawing.SystemColors.Info
        Me.txtidruta.Enabled = False
        Me.txtidruta.Location = New System.Drawing.Point(87, 76)
        Me.txtidruta.Name = "txtidruta"
        Me.txtidruta.Size = New System.Drawing.Size(138, 20)
        Me.txtidruta.TabIndex = 5
        Me.txtidruta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvdetalle
        '
        Me.dgvdetalle.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvdetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvdetalle.Location = New System.Drawing.Point(9, 204)
        Me.dgvdetalle.Name = "dgvdetalle"
        Me.dgvdetalle.Size = New System.Drawing.Size(519, 234)
        Me.dgvdetalle.TabIndex = 6
        '
        'cmboperacion
        '
        Me.cmboperacion.FormattingEnabled = True
        Me.cmboperacion.Location = New System.Drawing.Point(358, 75)
        Me.cmboperacion.Name = "cmboperacion"
        Me.cmboperacion.Size = New System.Drawing.Size(164, 21)
        Me.cmboperacion.TabIndex = 7
        '
        'txtruta
        '
        Me.txtruta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruta.Location = New System.Drawing.Point(87, 117)
        Me.txtruta.MaximumSize = New System.Drawing.Size(440, 100)
        Me.txtruta.MaxLength = 30
        Me.txtruta.Name = "txtruta"
        Me.txtruta.Size = New System.Drawing.Size(435, 20)
        Me.txtruta.TabIndex = 8
        '
        'cmbdepartamento
        '
        Me.cmbdepartamento.FormattingEnabled = True
        Me.cmbdepartamento.Location = New System.Drawing.Point(87, 152)
        Me.cmbdepartamento.Name = "cmbdepartamento"
        Me.cmbdepartamento.Size = New System.Drawing.Size(138, 21)
        Me.cmbdepartamento.TabIndex = 9
        '
        'txtidpais
        '
        Me.txtidpais.Enabled = False
        Me.txtidpais.Location = New System.Drawing.Point(458, 29)
        Me.txtidpais.Name = "txtidpais"
        Me.txtidpais.Size = New System.Drawing.Size(64, 20)
        Me.txtidpais.TabIndex = 10
        Me.txtidpais.Visible = False
        '
        'frmrutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 593)
        Me.Name = "frmrutas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        CType(Me.dgvdetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtidruta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Labruta As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Labidruta As System.Windows.Forms.Label
    Friend WithEvents dgvdetalle As System.Windows.Forms.DataGridView
    Friend WithEvents cmboperacion As System.Windows.Forms.ComboBox
    Friend WithEvents txtruta As System.Windows.Forms.TextBox
    Friend WithEvents cmbdepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents txtidpais As System.Windows.Forms.TextBox

End Class
