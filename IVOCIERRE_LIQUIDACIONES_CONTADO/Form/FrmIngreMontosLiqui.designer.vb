<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngreMontosLiqui
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btncance = New System.Windows.Forms.Button()
        Me.BTNACEP = New System.Windows.Forms.Button()
        Me.txttotal_sole = New System.Windows.Forms.TextBox()
        Me.txten_soles = New System.Windows.Forms.TextBox()
        Me.txtmonto_soles = New System.Windows.Forms.TextBox()
        Me.txttipo_cambi = New System.Windows.Forms.TextBox()
        Me.txtmonto_dola = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btncance)
        Me.Panel1.Controls.Add(Me.BTNACEP)
        Me.Panel1.Controls.Add(Me.txttotal_sole)
        Me.Panel1.Controls.Add(Me.txten_soles)
        Me.Panel1.Controls.Add(Me.txtmonto_soles)
        Me.Panel1.Controls.Add(Me.txttipo_cambi)
        Me.Panel1.Controls.Add(Me.txtmonto_dola)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(353, 171)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(242, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Total Soles (S/.)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(139, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Tipo de Cambio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(38, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Monto ($/.)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(244, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Monto (S/.)"
        '
        'btncance
        '
        Me.btncance.BackColor = System.Drawing.Color.Transparent
        Me.btncance.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncance.Location = New System.Drawing.Point(262, 132)
        Me.btncance.Name = "btncance"
        Me.btncance.Size = New System.Drawing.Size(79, 28)
        Me.btncance.TabIndex = 6
        Me.btncance.Text = "&Cancelar"
        Me.btncance.UseVisualStyleBackColor = False
        '
        'BTNACEP
        '
        Me.BTNACEP.BackColor = System.Drawing.Color.Transparent
        Me.BTNACEP.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BTNACEP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNACEP.Location = New System.Drawing.Point(177, 132)
        Me.BTNACEP.Name = "BTNACEP"
        Me.BTNACEP.Size = New System.Drawing.Size(79, 28)
        Me.BTNACEP.TabIndex = 5
        Me.BTNACEP.Text = "&Aceptar"
        Me.BTNACEP.UseVisualStyleBackColor = False
        '
        'txttotal_sole
        '
        Me.txttotal_sole.Location = New System.Drawing.Point(245, 106)
        Me.txttotal_sole.Name = "txttotal_sole"
        Me.txttotal_sole.ReadOnly = True
        Me.txttotal_sole.Size = New System.Drawing.Size(97, 20)
        Me.txttotal_sole.TabIndex = 4
        Me.txttotal_sole.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txten_soles
        '
        Me.txten_soles.Location = New System.Drawing.Point(245, 65)
        Me.txten_soles.Name = "txten_soles"
        Me.txten_soles.ReadOnly = True
        Me.txten_soles.Size = New System.Drawing.Size(97, 20)
        Me.txten_soles.TabIndex = 3
        Me.txten_soles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmonto_soles
        '
        Me.txtmonto_soles.Location = New System.Drawing.Point(245, 26)
        Me.txtmonto_soles.Name = "txtmonto_soles"
        Me.txtmonto_soles.Size = New System.Drawing.Size(97, 20)
        Me.txtmonto_soles.TabIndex = 0
        Me.txtmonto_soles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttipo_cambi
        '
        Me.txttipo_cambi.Location = New System.Drawing.Point(142, 65)
        Me.txttipo_cambi.Name = "txttipo_cambi"
        Me.txttipo_cambi.Size = New System.Drawing.Size(97, 20)
        Me.txttipo_cambi.TabIndex = 2
        Me.txttipo_cambi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmonto_dola
        '
        Me.txtmonto_dola.Location = New System.Drawing.Point(39, 65)
        Me.txtmonto_dola.Name = "txtmonto_dola"
        Me.txtmonto_dola.Size = New System.Drawing.Size(97, 20)
        Me.txtmonto_dola.TabIndex = 1
        Me.txtmonto_dola.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmIngreMontosLiqui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 171)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmIngreMontosLiqui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Montos..."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txten_soles As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_soles As System.Windows.Forms.TextBox
    Friend WithEvents txttipo_cambi As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_dola As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btncance As System.Windows.Forms.Button
    Friend WithEvents BTNACEP As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttotal_sole As System.Windows.Forms.TextBox
End Class
