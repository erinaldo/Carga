Imports System
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoContacto_Cliente
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
        Me.txtRubro = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Lista = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRubro
        '
        Me.txtRubro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRubro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRubro.Location = New System.Drawing.Point(169, 66)
        Me.txtRubro.Name = "txtRubro"
        Me.txtRubro.Size = New System.Drawing.Size(214, 20)
        Me.txtRubro.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Lista)
        Me.Panel1.Location = New System.Drawing.Point(36, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 325)
        Me.Panel1.TabIndex = 16
        '
        'Lista
        '
        Me.Lista.BackgroundColor = System.Drawing.Color.White
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lista.Location = New System.Drawing.Point(0, 0)
        Me.Lista.Name = "Lista"
        Me.Lista.Size = New System.Drawing.Size(359, 325)
        Me.Lista.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(55, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Rubro Empresarial :"
        '
        'FrmTipoContacto_Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(436, 472)
        Me.Controls.Add(Me.txtRubro)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmTipoContacto_Cliente"
        Me.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.txtRubro, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRubro As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lista As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
