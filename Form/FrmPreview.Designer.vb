<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPreview))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Imprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripSeparator()
        Me.salir = New System.Windows.Forms.ToolStripButton()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ini = New System.Windows.Forms.ToolStripButton()
        Me.ant = New System.Windows.Forms.ToolStripButton()
        Me.pagina = New System.Windows.Forms.ToolStripTextBox()
        Me.sig = New System.Windows.Forms.ToolStripButton()
        Me.fin = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Texto = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Imprimir, Me.ToolStripButton3, Me.salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(920, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Imprimir
        '
        Me.Imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Imprimir.Image = CType(resources.GetObject("Imprimir.Image"), System.Drawing.Image)
        Me.Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Size = New System.Drawing.Size(23, 22)
        Me.Imprimir.ToolTipText = "Imprimir"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(6, 25)
        '
        'salir
        '
        Me.salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.salir.Image = CType(resources.GetObject("salir.Image"), System.Drawing.Image)
        Me.salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(23, 22)
        Me.salir.ToolTipText = "Salir"
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 150)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 21)
        Me.ToolStripButton6.Text = "ToolStripButton6"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ini, Me.ant, Me.pagina, Me.sig, Me.fin, Me.ToolStripButton10})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 581)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(920, 25)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.AutoSize = False
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(420, 25)
        '
        'ini
        '
        Me.ini.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ini.Image = Global.INTEGRACION.My.Resources.Resources.arrow_first_24
        Me.ini.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ini.Name = "ini"
        Me.ini.Size = New System.Drawing.Size(23, 22)
        Me.ini.Text = "ToolStripButton5"
        '
        'ant
        '
        Me.ant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ant.Image = Global.INTEGRACION.My.Resources.Resources.arrow_back_24
        Me.ant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ant.Name = "ant"
        Me.ant.Size = New System.Drawing.Size(23, 22)
        Me.ant.Text = "ToolStripButton7"
        '
        'pagina
        '
        Me.pagina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pagina.Name = "pagina"
        Me.pagina.Size = New System.Drawing.Size(30, 25)
        '
        'sig
        '
        Me.sig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sig.Image = Global.INTEGRACION.My.Resources.Resources.arrow_forward_24
        Me.sig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sig.Name = "sig"
        Me.sig.Size = New System.Drawing.Size(23, 22)
        Me.sig.Text = "ToolStripButton4"
        '
        'fin
        '
        Me.fin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.fin.Image = Global.INTEGRACION.My.Resources.Resources.arrow_last_24
        Me.fin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fin.Name = "fin"
        Me.fin.Size = New System.Drawing.Size(23, 22)
        Me.fin.Text = "ToolStripButton8"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.AutoSize = False
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(400, 25)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Texto)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(920, 606)
        Me.Panel1.TabIndex = 2
        '
        'Texto
        '
        Me.Texto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Texto.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Texto.Location = New System.Drawing.Point(0, 0)
        Me.Texto.Name = "Texto"
        Me.Texto.Size = New System.Drawing.Size(920, 581)
        Me.Texto.TabIndex = 2
        Me.Texto.Text = ""
        Me.Texto.Visible = False
        '
        'FrmPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 631)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmPreview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPreview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Imprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ini As System.Windows.Forms.ToolStripButton
    Friend WithEvents ant As System.Windows.Forms.ToolStripButton
    Friend WithEvents pagina As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents sig As System.Windows.Forms.ToolStripButton
    Friend WithEvents fin As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Texto As System.Windows.Forms.RichTextBox
    Friend WithEvents salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripSeparator
End Class
