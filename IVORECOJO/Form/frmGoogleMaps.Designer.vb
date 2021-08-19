<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoogleMaps
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGoogleMaps))
        Me.web = New System.Windows.Forms.WebBrowser()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.toolUrl = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.toolLatitud = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.toolLongitud = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolInicio = New System.Windows.Forms.ToolStripButton()
        Me.toolActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAtras = New System.Windows.Forms.ToolStripButton()
        Me.toolAdelante = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'web
        '
        Me.web.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.web.Location = New System.Drawing.Point(0, 28)
        Me.web.MinimumSize = New System.Drawing.Size(20, 20)
        Me.web.Name = "web"
        Me.web.Size = New System.Drawing.Size(1262, 458)
        Me.web.TabIndex = 0
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.toolUrl, Me.ToolStripLabel2, Me.toolLatitud, Me.ToolStripLabel3, Me.toolLongitud, Me.ToolStripSeparator1, Me.ToolStripSeparator4, Me.toolInicio, Me.toolActualizar, Me.ToolStripSeparator2, Me.ToolStripSeparator3, Me.toolAtras, Me.toolAdelante, Me.ToolStripSeparator5, Me.ToolStripSeparator7, Me.toolAceptar, Me.ToolStripSeparator8, Me.toolCancelar})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(1262, 25)
        Me.tool.TabIndex = 1
        Me.tool.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripLabel1.Text = "URL"
        '
        'toolUrl
        '
        Me.toolUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toolUrl.Name = "toolUrl"
        Me.toolUrl.ReadOnly = True
        Me.toolUrl.Size = New System.Drawing.Size(300, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripLabel2.Text = "Latitud"
        '
        'toolLatitud
        '
        Me.toolLatitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toolLatitud.Name = "toolLatitud"
        Me.toolLatitud.ReadOnly = True
        Me.toolLatitud.Size = New System.Drawing.Size(90, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripLabel3.Text = "Longitud"
        '
        'toolLongitud
        '
        Me.toolLongitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toolLongitud.Name = "toolLongitud"
        Me.toolLongitud.ReadOnly = True
        Me.toolLongitud.Size = New System.Drawing.Size(90, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolInicio
        '
        Me.toolInicio.Image = CType(resources.GetObject("toolInicio.Image"), System.Drawing.Image)
        Me.toolInicio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolInicio.Name = "toolInicio"
        Me.toolInicio.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.toolInicio.Size = New System.Drawing.Size(76, 22)
        Me.toolInicio.Text = "Inicio"
        '
        'toolActualizar
        '
        Me.toolActualizar.Image = CType(resources.GetObject("toolActualizar.Image"), System.Drawing.Image)
        Me.toolActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolActualizar.Name = "toolActualizar"
        Me.toolActualizar.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.toolActualizar.Size = New System.Drawing.Size(99, 22)
        Me.toolActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolAtras
        '
        Me.toolAtras.Image = Global.INTEGRACION.My.Resources.Resources.arrow_back_24
        Me.toolAtras.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAtras.Name = "toolAtras"
        Me.toolAtras.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.toolAtras.Size = New System.Drawing.Size(74, 22)
        Me.toolAtras.Text = "Atrás"
        '
        'toolAdelante
        '
        Me.toolAdelante.Image = Global.INTEGRACION.My.Resources.Resources.arrow_forward_24
        Me.toolAdelante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdelante.Name = "toolAdelante"
        Me.toolAdelante.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.toolAdelante.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.toolAdelante.Size = New System.Drawing.Size(94, 22)
        Me.toolAdelante.Text = "Adelante"
        Me.toolAdelante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Margin = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolAceptar
        '
        Me.toolAceptar.Image = CType(resources.GetObject("toolAceptar.Image"), System.Drawing.Image)
        Me.toolAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAceptar.Name = "toolAceptar"
        Me.toolAceptar.Padding = New System.Windows.Forms.Padding(30, 0, 10, 0)
        Me.toolAceptar.Size = New System.Drawing.Size(108, 22)
        Me.toolAceptar.Text = "Aceptar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'toolCancelar
        '
        Me.toolCancelar.Image = CType(resources.GetObject("toolCancelar.Image"), System.Drawing.Image)
        Me.toolCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCancelar.Name = "toolCancelar"
        Me.toolCancelar.Padding = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.toolCancelar.Size = New System.Drawing.Size(103, 22)
        Me.toolCancelar.Text = "Cancelar"
        '
        'frmGoogleMaps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 486)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.web)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmGoogleMaps"
        Me.Text = "Google Maps"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents web As System.Windows.Forms.WebBrowser
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolUrl As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolLatitud As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolLongitud As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents toolInicio As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAtras As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAdelante As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
