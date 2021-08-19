<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRutas
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
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKilo = New System.Windows.Forms.TextBox()
        Me.CbOrigen = New System.Windows.Forms.ComboBox()
        Me.CbDestino = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtError = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtDias = New System.Windows.Forms.TextBox()
        Me.TxtTimeHor = New System.Windows.Forms.MaskedTextBox()
        Me.ChkVigente = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CbEstado = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.CbStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataGridViewLista = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 35)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(546, 503)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(544, 495)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.DataGridViewLista)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.Label21)
        Me.TabLista.Controls.Add(Me.CbEstado)
        Me.TabLista.Size = New System.Drawing.Size(536, 466)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.CbEstado, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label21, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridViewLista, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.Label22)
        Me.TabDatos.Controls.Add(Me.CbStatus)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.Label8)
        Me.TabDatos.Controls.Add(Me.ChkVigente)
        Me.TabDatos.Controls.Add(Me.TxtDias)
        Me.TabDatos.Controls.Add(Me.Label7)
        Me.TabDatos.Controls.Add(Me.TxtTimeHor)
        Me.TabDatos.Controls.Add(Me.TxtError)
        Me.TabDatos.Controls.Add(Me.Label5)
        Me.TabDatos.Controls.Add(Me.Label6)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Controls.Add(Me.CbDestino)
        Me.TabDatos.Controls.Add(Me.CbOrigen)
        Me.TabDatos.Controls.Add(Me.Label3)
        Me.TabDatos.Controls.Add(Me.TxtKilo)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.TxtID)
        Me.TabDatos.Size = New System.Drawing.Size(536, 466)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtID, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtKilo, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbOrigen, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbDestino, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label6, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtError, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtTimeHor, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label7, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtDias, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.ChkVigente, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label8, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.TxtMensaje, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.CbStatus, 0)
        Me.TabDatos.Controls.SetChildIndex(Me.Label22, 0)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridLista.Location = New System.Drawing.Point(249, 172)
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(92, 34)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(536, 466)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(536, 466)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'TxtID
        '
        Me.TxtID.Location = New System.Drawing.Point(276, 109)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(44, 20)
        Me.TxtID.TabIndex = 0
        Me.TxtID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(109, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(109, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Unidad Origen"
        '
        'TxtKilo
        '
        Me.TxtKilo.Location = New System.Drawing.Point(276, 210)
        Me.TxtKilo.Name = "TxtKilo"
        Me.TxtKilo.Size = New System.Drawing.Size(59, 20)
        Me.TxtKilo.TabIndex = 3
        Me.TxtKilo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CbOrigen
        '
        Me.CbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbOrigen.FormattingEnabled = True
        Me.CbOrigen.Location = New System.Drawing.Point(276, 142)
        Me.CbOrigen.Name = "CbOrigen"
        Me.CbOrigen.Size = New System.Drawing.Size(143, 21)
        Me.CbOrigen.Sorted = True
        Me.CbOrigen.TabIndex = 1
        '
        'CbDestino
        '
        Me.CbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDestino.FormattingEnabled = True
        Me.CbDestino.Location = New System.Drawing.Point(276, 176)
        Me.CbDestino.Name = "CbDestino"
        Me.CbDestino.Size = New System.Drawing.Size(143, 21)
        Me.CbDestino.Sorted = True
        Me.CbDestino.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(109, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Unidad Destino"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(109, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Nro.Kilometros"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(109, 279)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Horas de Viaje"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(109, 311)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Margen Error Horas"
        '
        'TxtError
        '
        Me.TxtError.Location = New System.Drawing.Point(276, 309)
        Me.TxtError.Name = "TxtError"
        Me.TxtError.Size = New System.Drawing.Size(41, 20)
        Me.TxtError.TabIndex = 6
        Me.TxtError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(109, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Vigente"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(109, 245)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Dias de Viaje"
        '
        'TxtDias
        '
        Me.TxtDias.Location = New System.Drawing.Point(276, 243)
        Me.TxtDias.Name = "TxtDias"
        Me.TxtDias.Size = New System.Drawing.Size(41, 20)
        Me.TxtDias.TabIndex = 4
        Me.TxtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTimeHor
        '
        Me.TxtTimeHor.Location = New System.Drawing.Point(276, 276)
        Me.TxtTimeHor.Mask = "00:00"
        Me.TxtTimeHor.Name = "TxtTimeHor"
        Me.TxtTimeHor.Size = New System.Drawing.Size(41, 20)
        Me.TxtTimeHor.TabIndex = 5
        '
        'ChkVigente
        '
        Me.ChkVigente.AutoSize = True
        Me.ChkVigente.Location = New System.Drawing.Point(276, 344)
        Me.ChkVigente.Name = "ChkVigente"
        Me.ChkVigente.Size = New System.Drawing.Size(15, 14)
        Me.ChkVigente.TabIndex = 16
        Me.ChkVigente.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(337, 36)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Estado"
        '
        'CbEstado
        '
        Me.CbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEstado.FormattingEnabled = True
        Me.CbEstado.Location = New System.Drawing.Point(394, 33)
        Me.CbEstado.Name = "CbEstado"
        Me.CbEstado.Size = New System.Drawing.Size(121, 21)
        Me.CbEstado.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(109, 376)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Estado"
        '
        'CbStatus
        '
        Me.CbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbStatus.FormattingEnabled = True
        Me.CbStatus.Location = New System.Drawing.Point(276, 373)
        Me.CbStatus.Name = "CbStatus"
        Me.CbStatus.Size = New System.Drawing.Size(121, 21)
        Me.CbStatus.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(18, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Buscar"
        '
        'DataGridViewLista
        '
        Me.DataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLista.Location = New System.Drawing.Point(21, 75)
        Me.DataGridViewLista.Name = "DataGridViewLista"
        Me.DataGridViewLista.Size = New System.Drawing.Size(494, 368)
        Me.DataGridViewLista.TabIndex = 15
        '
        'FrmRutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "FrmRutas"
        Me.Text = "FrmRutas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents CbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtKilo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtError As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtDias As System.Windows.Forms.TextBox
    Friend WithEvents TxtTimeHor As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ChkVigente As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewLista As System.Windows.Forms.DataGridView
End Class
