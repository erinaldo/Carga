<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmmantenimientosimpleunitrans
    Inherits FrmPlantillaBusqueda
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
        Me.LabMANTENIMIENTO = New System.Windows.Forms.Label
        Me.txtMANTENIMIENTO = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Lista = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabMANTENIMIENTO
        '
        Me.LabMANTENIMIENTO.AutoSize = True
        Me.LabMANTENIMIENTO.BackColor = System.Drawing.Color.Transparent
        Me.LabMANTENIMIENTO.Location = New System.Drawing.Point(22, 68)
        Me.LabMANTENIMIENTO.Name = "LabMANTENIMIENTO"
        Me.LabMANTENIMIENTO.Size = New System.Drawing.Size(99, 13)
        Me.LabMANTENIMIENTO.TabIndex = 5
        Me.LabMANTENIMIENTO.Text = "Rubro Empresarial :"
        '
        'txtMANTENIMIENTO
        '
        Me.txtMANTENIMIENTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMANTENIMIENTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMANTENIMIENTO.Location = New System.Drawing.Point(160, 68)
        Me.txtMANTENIMIENTO.Name = "txtMANTENIMIENTO"
        Me.txtMANTENIMIENTO.Size = New System.Drawing.Size(214, 20)
        Me.txtMANTENIMIENTO.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Lista)
        Me.Panel1.Location = New System.Drawing.Point(36, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 325)
        Me.Panel1.TabIndex = 7
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
        'Frmmantenimientosimple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(436, 472)
        Me.Controls.Add(Me.txtMANTENIMIENTO)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LabMANTENIMIENTO)
        Me.Name = "Frmmantenimientosimple"
        Me.Controls.SetChildIndex(Me.LabMANTENIMIENTO, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.txtMANTENIMIENTO, 0)
        Me.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabMANTENIMIENTO As System.Windows.Forms.Label
    Friend WithEvents txtMANTENIMIENTO As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lista As System.Windows.Forms.DataGridView

End Class
