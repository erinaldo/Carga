<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMigrarGuias
    Inherits INTEGRACION.FrmPlantillaFacturacion

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
        Me.TBRUTA = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.OFD = New System.Windows.Forms.OpenFileDialog
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.TBRUTA)
        Me.TabLista.Controls.Add(Me.pb)
        Me.TabLista.Controls.Add(Me.Button1)
        Me.TabLista.Controls.Add(Me.Button2)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.Button3)
        Me.TabLista.Controls.SetChildIndex(Me.Button3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Button2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Button1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.pb, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TBRUTA, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage3
        '
        Me.TabPage3.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage4
        '
        Me.TabPage4.Size = New System.Drawing.Size(734, 464)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.dgv1)
        Me.Panel.Location = New System.Drawing.Point(6, 90)
        Me.Panel.Size = New System.Drawing.Size(720, 316)
        '
        'TBRUTA
        '
        Me.TBRUTA.Location = New System.Drawing.Point(6, 6)
        Me.TBRUTA.Name = "TBRUTA"
        Me.TBRUTA.Size = New System.Drawing.Size(383, 20)
        Me.TBRUTA.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(395, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 24)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Examinar..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OFD
        '
        Me.OFD.FileName = "OpenFileDialog1"
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(0, 0)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(720, 318)
        Me.dgv1.TabIndex = 0
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(6, 431)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(364, 29)
        Me.pb.TabIndex = 3
        Me.pb.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(500, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(622, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 24)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Importar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(622, 35)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 24)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Exportar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmMigrarGuias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmMigrarGuias"
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
        Me.Panel.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TBRUTA As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
