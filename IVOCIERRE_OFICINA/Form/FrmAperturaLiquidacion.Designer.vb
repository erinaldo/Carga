<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAperturaLiquidacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturaLiquidacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboFechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.CboOficina = New System.Windows.Forms.ComboBox()
        Me.BtnApertura = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(373, 52)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Fecha Liquidacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Oficina a Liquidar"
        '
        'CboFechaApertura
        '
        Me.CboFechaApertura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CboFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CboFechaApertura.Location = New System.Drawing.Point(128, 74)
        Me.CboFechaApertura.Name = "CboFechaApertura"
        Me.CboFechaApertura.Size = New System.Drawing.Size(209, 20)
        Me.CboFechaApertura.TabIndex = 50
        '
        'CboOficina
        '
        Me.CboOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboOficina.FormattingEnabled = True
        Me.CboOficina.Location = New System.Drawing.Point(128, 109)
        Me.CboOficina.Name = "CboOficina"
        Me.CboOficina.Size = New System.Drawing.Size(209, 21)
        Me.CboOficina.TabIndex = 51
        '
        'BtnApertura
        '
        Me.BtnApertura.Location = New System.Drawing.Point(25, 148)
        Me.BtnApertura.Name = "BtnApertura"
        Me.BtnApertura.Size = New System.Drawing.Size(138, 28)
        Me.BtnApertura.TabIndex = 52
        Me.BtnApertura.Text = "&Apertura Liquidacion"
        Me.BtnApertura.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(199, 148)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(138, 28)
        Me.BtnCancelar.TabIndex = 53
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'FrmAperturaLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 184)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnApertura)
        Me.Controls.Add(Me.CboOficina)
        Me.Controls.Add(Me.CboFechaApertura)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmAperturaLiquidacion"
        Me.Text = "Apertura de Liquidacion de Oficina"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboFechaApertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboOficina As System.Windows.Forms.ComboBox
    Friend WithEvents BtnApertura As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
End Class
