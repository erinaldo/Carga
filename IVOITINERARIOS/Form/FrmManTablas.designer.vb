<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManTablas
    Inherits INTEGRACION.FrmFormBase

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
        Me.TxtNomUnd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtIdUnd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridViewLista = New System.Windows.Forms.DataGridView
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.LbCampo3 = New System.Windows.Forms.Label
        Me.TxtCampo3 = New System.Windows.Forms.TextBox
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 611)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 545)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(23, 23)
        '
        'TabMante
        '
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.DataGridViewLista)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridViewLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.LbCampo3)
        Me.TabDatos.Controls.Add(Me.TxtCampo3)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.TxtNomUnd)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.TxtIdUnd)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtIdUnd, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtNomUnd, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtMensaje, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtCampo3, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.LbCampo3, 0)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(74, 34)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'TxtNomUnd
        '
        Me.TxtNomUnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomUnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomUnd.ForeColor = System.Drawing.Color.Black
        Me.TxtNomUnd.Location = New System.Drawing.Point(126, 118)
        Me.TxtNomUnd.Name = "TxtNomUnd"
        Me.TxtNomUnd.Size = New System.Drawing.Size(314, 20)
        Me.TxtNomUnd.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(53, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ID"
        '
        'TxtIdUnd
        '
        Me.TxtIdUnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdUnd.Location = New System.Drawing.Point(126, 81)
        Me.TxtIdUnd.Name = "TxtIdUnd"
        Me.TxtIdUnd.ReadOnly = True
        Me.TxtIdUnd.Size = New System.Drawing.Size(48, 20)
        Me.TxtIdUnd.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(53, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(18, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Buscar"
        '
        'DataGridViewLista
        '
        Me.DataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLista.Location = New System.Drawing.Point(21, 75)
        Me.DataGridViewLista.Name = "DataGridViewLista"
        Me.DataGridViewLista.Size = New System.Drawing.Size(492, 393)
        Me.DataGridViewLista.TabIndex = 3
        '
        'LbCampo3
        '
        Me.LbCampo3.AutoSize = True
        Me.LbCampo3.BackColor = System.Drawing.Color.Transparent
        Me.LbCampo3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LbCampo3.Location = New System.Drawing.Point(53, 158)
        Me.LbCampo3.Name = "LbCampo3"
        Me.LbCampo3.Size = New System.Drawing.Size(44, 13)
        Me.LbCampo3.TabIndex = 10
        Me.LbCampo3.Text = "Nombre"
        '
        'TxtCampo3
        '
        Me.TxtCampo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCampo3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCampo3.ForeColor = System.Drawing.Color.Black
        Me.TxtCampo3.Location = New System.Drawing.Point(126, 156)
        Me.TxtCampo3.MaxLength = 3
        Me.TxtCampo3.Name = "TxtCampo3"
        Me.TxtCampo3.Size = New System.Drawing.Size(106, 20)
        Me.TxtCampo3.TabIndex = 9
        '
        'FrmManTablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmManTablas"
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    'Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents TxtNomUnd As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents TxtIdUnd As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewLista As System.Windows.Forms.DataGridView
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Private WithEvents LbCampo3 As System.Windows.Forms.Label
    Private WithEvents TxtCampo3 As System.Windows.Forms.TextBox
End Class
