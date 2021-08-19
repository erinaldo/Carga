<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetaItinerarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetaItinerarios))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CbAge1 = New System.Windows.Forms.ComboBox
        Me.CbAge2 = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.CbRuta = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtHorViaje = New System.Windows.Forms.TextBox
        Me.BtnAyuRut = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.BtnAyuAge1 = New System.Windows.Forms.Button
        Me.BtnAyuAge2 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.CbAge1)
        Me.Panel1.Controls.Add(Me.CbAge2)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.CbRuta)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(419, 280)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(215, 230)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 31)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(111, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 31)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Grabar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CbAge1
        '
        Me.CbAge1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAge1.FormattingEnabled = True
        Me.CbAge1.Location = New System.Drawing.Point(162, 129)
        Me.CbAge1.Name = "CbAge1"
        Me.CbAge1.Size = New System.Drawing.Size(177, 21)
        Me.CbAge1.TabIndex = 18
        '
        'CbAge2
        '
        Me.CbAge2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAge2.FormattingEnabled = True
        Me.CbAge2.Location = New System.Drawing.Point(162, 160)
        Me.CbAge2.Name = "CbAge2"
        Me.CbAge2.Size = New System.Drawing.Size(177, 21)
        Me.CbAge2.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(57, 164)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Agencia Destino"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(57, 132)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Agencia Origen"
        '
        'CbRuta
        '
        Me.CbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbRuta.FormattingEnabled = True
        Me.CbRuta.Location = New System.Drawing.Point(162, 60)
        Me.CbRuta.Name = "CbRuta"
        Me.CbRuta.Size = New System.Drawing.Size(177, 21)
        Me.CbRuta.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnAyuAge2)
        Me.GroupBox1.Controls.Add(Me.BtnAyuAge1)
        Me.GroupBox1.Controls.Add(Me.TxtHorViaje)
        Me.GroupBox1.Controls.Add(Me.BtnAyuRut)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(48, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 165)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'TxtHorViaje
        '
        Me.TxtHorViaje.BackColor = System.Drawing.SystemColors.Window
        Me.TxtHorViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtHorViaje.Location = New System.Drawing.Point(230, 53)
        Me.TxtHorViaje.Name = "TxtHorViaje"
        Me.TxtHorViaje.ReadOnly = True
        Me.TxtHorViaje.Size = New System.Drawing.Size(61, 20)
        Me.TxtHorViaje.TabIndex = 26
        Me.TxtHorViaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAyuRut
        '
        Me.BtnAyuRut.AutoSize = True
        Me.BtnAyuRut.Image = CType(resources.GetObject("BtnAyuRut.Image"), System.Drawing.Image)
        Me.BtnAyuRut.Location = New System.Drawing.Point(295, 16)
        Me.BtnAyuRut.Name = "BtnAyuRut"
        Me.BtnAyuRut.Size = New System.Drawing.Size(28, 24)
        Me.BtnAyuRut.TabIndex = 32
        Me.BtnAyuRut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Horas de Viaje"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(9, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Ruta"
        '
        'BtnAyuAge1
        '
        Me.BtnAyuAge1.AutoSize = True
        Me.BtnAyuAge1.Image = CType(resources.GetObject("BtnAyuAge1.Image"), System.Drawing.Image)
        Me.BtnAyuAge1.Location = New System.Drawing.Point(295, 83)
        Me.BtnAyuAge1.Name = "BtnAyuAge1"
        Me.BtnAyuAge1.Size = New System.Drawing.Size(28, 24)
        Me.BtnAyuAge1.TabIndex = 33
        Me.BtnAyuAge1.UseVisualStyleBackColor = True
        '
        'BtnAyuAge2
        '
        Me.BtnAyuAge2.AutoSize = True
        Me.BtnAyuAge2.Image = CType(resources.GetObject("BtnAyuAge2.Image"), System.Drawing.Image)
        Me.BtnAyuAge2.Location = New System.Drawing.Point(295, 115)
        Me.BtnAyuAge2.Name = "BtnAyuAge2"
        Me.BtnAyuAge2.Size = New System.Drawing.Size(28, 24)
        Me.BtnAyuAge2.TabIndex = 34
        Me.BtnAyuAge2.UseVisualStyleBackColor = True
        '
        'FrmDetaItinerarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 282)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmDetaItinerarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Tramo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CbAge1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CbAge2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CbRuta As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtHorViaje As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAyuRut As System.Windows.Forms.Button
    Friend WithEvents BtnAyuAge2 As System.Windows.Forms.Button
    Friend WithEvents BtnAyuAge1 As System.Windows.Forms.Button
End Class
