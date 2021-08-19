<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCierre_Liquidacion
    Inherits INTEGRACION.frmBaseVentas

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.DTPFECHAFINALGUIA = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHAINICIOGUIA = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTPFIN = New System.Windows.Forms.DateTimePicker
        Me.DTPINICIO = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox
        Me.cmbAgencia = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BTNSALI = New System.Windows.Forms.Button
        Me.BTNARQUE = New System.Windows.Forms.Button
        Me.BTNPRELI = New System.Windows.Forms.Button
        Me.BTNIMPRI = New System.Windows.Forms.Button
        Me.BTNANTE = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(755, 497)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(765, 521)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.GroupBox2)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Size = New System.Drawing.Size(757, 492)
        '
        'TabDatos
        '
        Me.TabDatos.Size = New System.Drawing.Size(757, 492)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(757, 492)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(757, 492)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.BTNMOSTRAR)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTPFIN)
        Me.GroupBox1.Controls.Add(Me.DTPINICIO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.Controls.Add(Me.cmbAgencia)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 113)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DTPFECHAFINALGUIA)
        Me.GroupBox4.Controls.Add(Me.DTPFECHAINICIOGUIA)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(741, 54)
        Me.GroupBox4.TabIndex = 68
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rango para fecha de guias.."
        '
        'DTPFECHAFINALGUIA
        '
        Me.DTPFECHAFINALGUIA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALGUIA.Location = New System.Drawing.Point(253, 19)
        Me.DTPFECHAFINALGUIA.Name = "DTPFECHAFINALGUIA"
        Me.DTPFECHAFINALGUIA.Size = New System.Drawing.Size(92, 20)
        Me.DTPFECHAFINALGUIA.TabIndex = 6
        '
        'DTPFECHAINICIOGUIA
        '
        Me.DTPFECHAINICIOGUIA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOGUIA.Location = New System.Drawing.Point(91, 19)
        Me.DTPFECHAINICIOGUIA.Name = "DTPFECHAINICIOGUIA"
        Me.DTPFECHAINICIOGUIA.Size = New System.Drawing.Size(92, 20)
        Me.DTPFECHAINICIOGUIA.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(181, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 71
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(4, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Fecha Inicio :"
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.Moccasin
        Me.BTNMOSTRAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(654, 18)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(79, 28)
        Me.BTNMOSTRAR.TabIndex = 4
        Me.BTNMOSTRAR.Text = "&Mostrar"
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(170, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Inicio"
        '
        'DTPFIN
        '
        Me.DTPFIN.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFIN.Location = New System.Drawing.Point(205, 23)
        Me.DTPFIN.Name = "DTPFIN"
        Me.DTPFIN.Size = New System.Drawing.Size(94, 20)
        Me.DTPFIN.TabIndex = 1
        '
        'DTPINICIO
        '
        Me.DTPINICIO.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPINICIO.Location = New System.Drawing.Point(68, 23)
        Me.DTPINICIO.Name = "DTPINICIO"
        Me.DTPINICIO.Size = New System.Drawing.Size(94, 20)
        Me.DTPINICIO.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(340, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(340, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Agencia"
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(396, 32)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(238, 21)
        Me.cmbUsuarios.TabIndex = 3
        '
        'cmbAgencia
        '
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(396, 7)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(238, 21)
        Me.cmbAgencia.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.DGV)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(737, 330)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        '
        'DGV
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.Location = New System.Drawing.Point(6, 19)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(634, 365)
        Me.DGV.TabIndex = 7
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.BTNSALI)
        Me.GroupBox3.Controls.Add(Me.BTNARQUE)
        Me.GroupBox3.Controls.Add(Me.BTNPRELI)
        Me.GroupBox3.Controls.Add(Me.BTNIMPRI)
        Me.GroupBox3.Controls.Add(Me.BTNANTE)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(643, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(90, 365)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Control"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 240)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 211)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'BTNSALI
        '
        Me.BTNSALI.BackColor = System.Drawing.Color.Moccasin
        Me.BTNSALI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNSALI.Location = New System.Drawing.Point(5, 153)
        Me.BTNSALI.Name = "BTNSALI"
        Me.BTNSALI.Size = New System.Drawing.Size(79, 28)
        Me.BTNSALI.TabIndex = 12
        Me.BTNSALI.Text = "&Salir"
        Me.BTNSALI.UseVisualStyleBackColor = False
        '
        'BTNARQUE
        '
        Me.BTNARQUE.BackColor = System.Drawing.Color.Moccasin
        Me.BTNARQUE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNARQUE.Location = New System.Drawing.Point(5, 119)
        Me.BTNARQUE.Name = "BTNARQUE"
        Me.BTNARQUE.Size = New System.Drawing.Size(79, 28)
        Me.BTNARQUE.TabIndex = 11
        Me.BTNARQUE.Text = "Cierre"
        Me.BTNARQUE.UseVisualStyleBackColor = False
        '
        'BTNPRELI
        '
        Me.BTNPRELI.BackColor = System.Drawing.Color.Moccasin
        Me.BTNPRELI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNPRELI.Location = New System.Drawing.Point(5, 85)
        Me.BTNPRELI.Name = "BTNPRELI"
        Me.BTNPRELI.Size = New System.Drawing.Size(79, 28)
        Me.BTNPRELI.TabIndex = 10
        Me.BTNPRELI.Text = "Preliminar"
        Me.BTNPRELI.UseVisualStyleBackColor = False
        '
        'BTNIMPRI
        '
        Me.BTNIMPRI.BackColor = System.Drawing.Color.Moccasin
        Me.BTNIMPRI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNIMPRI.Location = New System.Drawing.Point(5, 51)
        Me.BTNIMPRI.Name = "BTNIMPRI"
        Me.BTNIMPRI.Size = New System.Drawing.Size(79, 28)
        Me.BTNIMPRI.TabIndex = 9
        Me.BTNIMPRI.Text = "Imprimir"
        Me.BTNIMPRI.UseVisualStyleBackColor = False
        '
        'BTNANTE
        '
        Me.BTNANTE.BackColor = System.Drawing.Color.Moccasin
        Me.BTNANTE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNANTE.Location = New System.Drawing.Point(5, 17)
        Me.BTNANTE.Name = "BTNANTE"
        Me.BTNANTE.Size = New System.Drawing.Size(79, 28)
        Me.BTNANTE.TabIndex = 8
        Me.BTNANTE.Text = "&Anterior"
        Me.BTNANTE.UseVisualStyleBackColor = False
        '
        'FrmCierre_Liquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(753, 490)
        Me.Name = "FrmCierre_Liquidacion"
        Me.Text = " "
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNANTE As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents BTNSALI As System.Windows.Forms.Button
    Friend WithEvents BTNARQUE As System.Windows.Forms.Button
    Friend WithEvents BTNPRELI As System.Windows.Forms.Button
    Friend WithEvents BTNIMPRI As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPFIN As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPINICIO As System.Windows.Forms.DateTimePicker
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFECHAFINALGUIA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOGUIA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
