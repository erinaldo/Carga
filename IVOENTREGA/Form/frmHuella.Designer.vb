<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHuella
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblConsignado = New System.Windows.Forms.Label()
        Me.btnCapturar = New System.Windows.Forms.Button()
        Me.picHuella = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblSeguro = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnVerificar = New System.Windows.Forms.Button()
        Me.barra = New System.Windows.Forms.Label()
        Me.progreso = New System.Windows.Forms.ProgressBar()
        Me.lblCalidad = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnHuella = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblConsignado
        '
        Me.lblConsignado.Location = New System.Drawing.Point(85, 20)
        Me.lblConsignado.Name = "lblConsignado"
        Me.lblConsignado.Size = New System.Drawing.Size(295, 12)
        Me.lblConsignado.TabIndex = 7
        '
        'btnCapturar
        '
        Me.btnCapturar.Location = New System.Drawing.Point(119, 353)
        Me.btnCapturar.Name = "btnCapturar"
        Me.btnCapturar.Size = New System.Drawing.Size(85, 31)
        Me.btnCapturar.TabIndex = 8
        Me.btnCapturar.Text = "Capturar"
        Me.btnCapturar.UseVisualStyleBackColor = True
        '
        'picHuella
        '
        Me.picHuella.BackColor = System.Drawing.SystemColors.ControlLight
        Me.picHuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picHuella.Location = New System.Drawing.Point(21, 91)
        Me.picHuella.Name = "picHuella"
        Me.picHuella.Size = New System.Drawing.Size(260, 227)
        Me.picHuella.TabIndex = 9
        Me.picHuella.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Consignado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Monto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Seguro"
        '
        'lblMonto
        '
        Me.lblMonto.Location = New System.Drawing.Point(85, 50)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(77, 12)
        Me.lblMonto.TabIndex = 7
        '
        'lblSeguro
        '
        Me.lblSeguro.Location = New System.Drawing.Point(246, 50)
        Me.lblSeguro.Name = "lblSeguro"
        Me.lblSeguro.Size = New System.Drawing.Size(35, 12)
        Me.lblSeguro.TabIndex = 7
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(291, 244)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(85, 31)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnVerificar
        '
        Me.btnVerificar.Enabled = False
        Me.btnVerificar.Location = New System.Drawing.Point(291, 91)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(85, 31)
        Me.btnVerificar.TabIndex = 8
        Me.btnVerificar.Text = "Verificar"
        Me.btnVerificar.UseVisualStyleBackColor = True
        '
        'barra
        '
        Me.barra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.barra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barra.ForeColor = System.Drawing.Color.Black
        Me.barra.Location = New System.Drawing.Point(0, 400)
        Me.barra.Name = "barra"
        Me.barra.Size = New System.Drawing.Size(394, 24)
        Me.barra.TabIndex = 13
        Me.barra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'progreso
        '
        Me.progreso.Location = New System.Drawing.Point(21, 320)
        Me.progreso.Name = "progreso"
        Me.progreso.Size = New System.Drawing.Size(260, 12)
        Me.progreso.TabIndex = 29
        '
        'lblCalidad
        '
        Me.lblCalidad.AutoSize = True
        Me.lblCalidad.Location = New System.Drawing.Point(158, 334)
        Me.lblCalidad.Name = "lblCalidad"
        Me.lblCalidad.Size = New System.Drawing.Size(0, 13)
        Me.lblCalidad.TabIndex = 30
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(291, 301)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 31)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnHuella
        '
        Me.btnHuella.Enabled = False
        Me.btnHuella.Location = New System.Drawing.Point(291, 162)
        Me.btnHuella.Name = "btnHuella"
        Me.btnHuella.Size = New System.Drawing.Size(85, 36)
        Me.btnHuella.TabIndex = 31
        Me.btnHuella.Text = "Huella con Problemas"
        Me.btnHuella.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(291, 358)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 26)
        Me.Button1.TabIndex = 32
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'frmHuella
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 424)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnHuella)
        Me.Controls.Add(Me.lblCalidad)
        Me.Controls.Add(Me.progreso)
        Me.Controls.Add(Me.barra)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picHuella)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnVerificar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCapturar)
        Me.Controls.Add(Me.lblSeguro)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.lblConsignado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHuella"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Huella"
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblConsignado As System.Windows.Forms.Label
    Friend WithEvents btnCapturar As System.Windows.Forms.Button
    Friend WithEvents picHuella As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblSeguro As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnVerificar As System.Windows.Forms.Button
    Friend WithEvents barra As System.Windows.Forms.Label
    Friend WithEvents progreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCalidad As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnHuella As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
