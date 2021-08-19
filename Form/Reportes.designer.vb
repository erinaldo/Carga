<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Me.PanelReports = New System.Windows.Forms.Panel
        Me.Zoom = New System.Windows.Forms.HScrollBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.pd = New System.Windows.Forms.PrintPreviewControl
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelReports.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelReports
        '
        Me.PanelReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelReports.BackColor = System.Drawing.Color.Transparent
        Me.PanelReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelReports.Controls.Add(Me.pd)
        Me.PanelReports.Location = New System.Drawing.Point(12, 41)
        Me.PanelReports.Name = "PanelReports"
        Me.PanelReports.Size = New System.Drawing.Size(543, 220)
        Me.PanelReports.TabIndex = 0
        '
        'Zoom
        '
        Me.Zoom.Location = New System.Drawing.Point(0, 0)
        Me.Zoom.Maximum = 209
        Me.Zoom.Minimum = 1
        Me.Zoom.Name = "Zoom"
        Me.Zoom.Size = New System.Drawing.Size(195, 16)
        Me.Zoom.SmallChange = 5
        Me.Zoom.TabIndex = 1
        Me.Zoom.Value = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(334, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Zoom :"
        '
        'pd
        '
        Me.pd.AutoZoom = False
        Me.pd.BackColor = System.Drawing.SystemColors.Info
        Me.pd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pd.Location = New System.Drawing.Point(0, 0)
        Me.pd.Name = "pd"
        Me.pd.Size = New System.Drawing.Size(541, 218)
        Me.pd.TabIndex = 0
        Me.pd.Zoom = 0.1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(288, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Zoom :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Vizualizar a :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Zoom)
        Me.Panel1.Location = New System.Drawing.Point(87, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(195, 16)
        Me.Panel1.TabIndex = 3
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 273)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelReports)
        Me.Name = "Reportes"
        Me.Text = "Reportes"
        Me.PanelReports.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelReports As System.Windows.Forms.Panel
    Friend WithEvents Zoom As System.Windows.Forms.HScrollBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pd As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
