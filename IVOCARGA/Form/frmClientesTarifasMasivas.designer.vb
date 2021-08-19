<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesTarifasMasivas
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtidpersona = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_razonsocial = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.CbDesMas = New System.Windows.Forms.ComboBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.CbOriMas = New System.Windows.Forms.ComboBox
        Me.DataGridRutas = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rgt_descuento = New System.Windows.Forms.RadioButton
        Me.Rgt_monto = New System.Windows.Forms.RadioButton
        Me.txtsubcuenta = New System.Windows.Forms.TextBox
        Me.btn_desmarcar_rutas = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtidsubcuenta = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmb_centro_costo = New System.Windows.Forms.ComboBox
        Me.btn_marcar_rutas = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.txt_precio_sobre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtMMbC = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtMpvC = New System.Windows.Forms.TextBox
        Me.TxtPppC = New System.Windows.Forms.TextBox
        Me.TxtMppC = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TxtPpvC = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TxtPMbC = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridRutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtidpersona)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_razonsocial)
        Me.Panel1.Controls.Add(Me.Label42)
        Me.Panel1.Controls.Add(Me.CbDesMas)
        Me.Panel1.Controls.Add(Me.Label41)
        Me.Panel1.Controls.Add(Me.CbOriMas)
        Me.Panel1.Controls.Add(Me.DataGridRutas)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(632, 501)
        Me.Panel1.TabIndex = 0
        '
        'txtidpersona
        '
        Me.txtidpersona.BackColor = System.Drawing.SystemColors.Info
        Me.txtidpersona.Location = New System.Drawing.Point(527, 22)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(84, 20)
        Me.txtidpersona.TabIndex = 152
        Me.txtidpersona.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Razón Social : "
        '
        'txt_razonsocial
        '
        Me.txt_razonsocial.BackColor = System.Drawing.SystemColors.Info
        Me.txt_razonsocial.Location = New System.Drawing.Point(118, 22)
        Me.txt_razonsocial.Name = "txt_razonsocial"
        Me.txt_razonsocial.Size = New System.Drawing.Size(493, 20)
        Me.txt_razonsocial.TabIndex = 150
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Maroon
        Me.Label42.Location = New System.Drawing.Point(239, 72)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(50, 13)
        Me.Label42.TabIndex = 142
        Me.Label42.Text = "Destino"
        '
        'CbDesMas
        '
        Me.CbDesMas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDesMas.FormattingEnabled = True
        Me.CbDesMas.Location = New System.Drawing.Point(204, 91)
        Me.CbDesMas.Name = "CbDesMas"
        Me.CbDesMas.Size = New System.Drawing.Size(121, 21)
        Me.CbDesMas.TabIndex = 141
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Maroon
        Me.Label41.Location = New System.Drawing.Point(67, 72)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(44, 13)
        Me.Label41.TabIndex = 140
        Me.Label41.Text = "Origen"
        '
        'CbOriMas
        '
        Me.CbOriMas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbOriMas.FormattingEnabled = True
        Me.CbOriMas.Location = New System.Drawing.Point(32, 91)
        Me.CbOriMas.Name = "CbOriMas"
        Me.CbOriMas.Size = New System.Drawing.Size(121, 21)
        Me.CbOriMas.TabIndex = 139
        '
        'DataGridRutas
        '
        Me.DataGridRutas.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridRutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridRutas.Location = New System.Drawing.Point(21, 123)
        Me.DataGridRutas.Name = "DataGridRutas"
        Me.DataGridRutas.Size = New System.Drawing.Size(320, 369)
        Me.DataGridRutas.TabIndex = 103
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(622, 53)
        Me.GroupBox1.TabIndex = 154
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(525, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = "Id Persona : "
        Me.Label2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rgt_descuento)
        Me.GroupBox2.Controls.Add(Me.Rgt_monto)
        Me.GroupBox2.Controls.Add(Me.txtsubcuenta)
        Me.GroupBox2.Controls.Add(Me.btn_desmarcar_rutas)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtidsubcuenta)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.btn_marcar_rutas)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_aceptar)
        Me.GroupBox2.Controls.Add(Me.GroupBox14)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(622, 436)
        Me.GroupBox2.TabIndex = 155
        Me.GroupBox2.TabStop = False
        '
        'rgt_descuento
        '
        Me.rgt_descuento.AutoSize = True
        Me.rgt_descuento.ForeColor = System.Drawing.Color.Maroon
        Me.rgt_descuento.Location = New System.Drawing.Point(515, 105)
        Me.rgt_descuento.Name = "rgt_descuento"
        Me.rgt_descuento.Size = New System.Drawing.Size(88, 17)
        Me.rgt_descuento.TabIndex = 152
        Me.rgt_descuento.TabStop = True
        Me.rgt_descuento.Text = "% Descuento"
        Me.rgt_descuento.UseVisualStyleBackColor = True
        '
        'Rgt_monto
        '
        Me.Rgt_monto.AutoSize = True
        Me.Rgt_monto.ForeColor = System.Drawing.Color.Maroon
        Me.Rgt_monto.Location = New System.Drawing.Point(353, 105)
        Me.Rgt_monto.Name = "Rgt_monto"
        Me.Rgt_monto.Size = New System.Drawing.Size(55, 17)
        Me.Rgt_monto.TabIndex = 151
        Me.Rgt_monto.TabStop = True
        Me.Rgt_monto.Text = "Monto"
        Me.Rgt_monto.UseVisualStyleBackColor = True
        '
        'txtsubcuenta
        '
        Me.txtsubcuenta.BackColor = System.Drawing.SystemColors.Info
        Me.txtsubcuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubcuenta.Location = New System.Drawing.Point(353, 299)
        Me.txtsubcuenta.Name = "txtsubcuenta"
        Me.txtsubcuenta.Size = New System.Drawing.Size(257, 20)
        Me.txtsubcuenta.TabIndex = 125
        Me.txtsubcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtsubcuenta.Visible = False
        '
        'btn_desmarcar_rutas
        '
        Me.btn_desmarcar_rutas.ForeColor = System.Drawing.Color.Maroon
        Me.btn_desmarcar_rutas.Location = New System.Drawing.Point(510, 27)
        Me.btn_desmarcar_rutas.Name = "btn_desmarcar_rutas"
        Me.btn_desmarcar_rutas.Size = New System.Drawing.Size(99, 23)
        Me.btn_desmarcar_rutas.TabIndex = 150
        Me.btn_desmarcar_rutas.Text = "Desmarcar Todos"
        Me.btn_desmarcar_rutas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(456, 278)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = "idsubcuenta"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(290, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Monto"
        '
        'txtidsubcuenta
        '
        Me.txtidsubcuenta.BackColor = System.Drawing.SystemColors.Info
        Me.txtidsubcuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidsubcuenta.Location = New System.Drawing.Point(538, 276)
        Me.txtidsubcuenta.Name = "txtidsubcuenta"
        Me.txtidsubcuenta.Size = New System.Drawing.Size(71, 20)
        Me.txtidsubcuenta.TabIndex = 126
        Me.txtidsubcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtidsubcuenta.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmb_centro_costo)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(341, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(275, 41)
        Me.GroupBox3.TabIndex = 147
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Centro Costo"
        '
        'cmb_centro_costo
        '
        Me.cmb_centro_costo.FormattingEnabled = True
        Me.cmb_centro_costo.Location = New System.Drawing.Point(7, 14)
        Me.cmb_centro_costo.Name = "cmb_centro_costo"
        Me.cmb_centro_costo.Size = New System.Drawing.Size(262, 21)
        Me.cmb_centro_costo.TabIndex = 0
        '
        'btn_marcar_rutas
        '
        Me.btn_marcar_rutas.ForeColor = System.Drawing.Color.Maroon
        Me.btn_marcar_rutas.Location = New System.Drawing.Point(341, 27)
        Me.btn_marcar_rutas.Name = "btn_marcar_rutas"
        Me.btn_marcar_rutas.Size = New System.Drawing.Size(101, 23)
        Me.btn_marcar_rutas.TabIndex = 146
        Me.btn_marcar_rutas.Text = "Marcar Todos"
        Me.btn_marcar_rutas.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_cancelar.Location = New System.Drawing.Point(530, 395)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 1
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_aceptar.Location = New System.Drawing.Point(438, 395)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 0
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.txt_precio_sobre)
        Me.GroupBox14.Controls.Add(Me.Label5)
        Me.GroupBox14.Controls.Add(Me.TxtMMbC)
        Me.GroupBox14.Controls.Add(Me.Label27)
        Me.GroupBox14.Controls.Add(Me.TxtMpvC)
        Me.GroupBox14.Controls.Add(Me.TxtPppC)
        Me.GroupBox14.Controls.Add(Me.TxtMppC)
        Me.GroupBox14.Controls.Add(Me.Label29)
        Me.GroupBox14.Controls.Add(Me.TxtPpvC)
        Me.GroupBox14.Controls.Add(Me.Label28)
        Me.GroupBox14.Controls.Add(Me.TxtPMbC)
        Me.GroupBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox14.Location = New System.Drawing.Point(341, 145)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(268, 125)
        Me.GroupBox14.TabIndex = 133
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Carga"
        '
        'txt_precio_sobre
        '
        Me.txt_precio_sobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_sobre.Location = New System.Drawing.Point(180, 87)
        Me.txt_precio_sobre.MaxLength = 12
        Me.txt_precio_sobre.Name = "txt_precio_sobre"
        Me.txt_precio_sobre.Size = New System.Drawing.Size(72, 20)
        Me.txt_precio_sobre.TabIndex = 126
        Me.txt_precio_sobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(16, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Precio x Sobre"
        '
        'TxtMMbC
        '
        Me.TxtMMbC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMMbC.Location = New System.Drawing.Point(180, 13)
        Me.TxtMMbC.MaxLength = 12
        Me.TxtMMbC.Name = "TxtMMbC"
        Me.TxtMMbC.Size = New System.Drawing.Size(72, 20)
        Me.TxtMMbC.TabIndex = 120
        Me.TxtMMbC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(16, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(74, 13)
        Me.Label27.TabIndex = 113
        Me.Label27.Text = "Monto Base"
        '
        'TxtMpvC
        '
        Me.TxtMpvC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMpvC.Location = New System.Drawing.Point(180, 61)
        Me.TxtMpvC.MaxLength = 12
        Me.TxtMpvC.Name = "TxtMpvC"
        Me.TxtMpvC.Size = New System.Drawing.Size(72, 20)
        Me.TxtMpvC.TabIndex = 124
        Me.TxtMpvC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPppC
        '
        Me.TxtPppC.BackColor = System.Drawing.SystemColors.Info
        Me.TxtPppC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPppC.Location = New System.Drawing.Point(134, 37)
        Me.TxtPppC.Name = "TxtPppC"
        Me.TxtPppC.Size = New System.Drawing.Size(40, 20)
        Me.TxtPppC.TabIndex = 105
        Me.TxtPppC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPppC.Visible = False
        '
        'TxtMppC
        '
        Me.TxtMppC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMppC.Location = New System.Drawing.Point(180, 37)
        Me.TxtMppC.MaxLength = 12
        Me.TxtMppC.Name = "TxtMppC"
        Me.TxtMppC.Size = New System.Drawing.Size(72, 20)
        Me.TxtMppC.TabIndex = 122
        Me.TxtMppC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(16, 40)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(85, 13)
        Me.Label29.TabIndex = 114
        Me.Label29.Text = "Precio x Peso"
        '
        'TxtPpvC
        '
        Me.TxtPpvC.BackColor = System.Drawing.SystemColors.Info
        Me.TxtPpvC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPpvC.Location = New System.Drawing.Point(134, 61)
        Me.TxtPpvC.Name = "TxtPpvC"
        Me.TxtPpvC.Size = New System.Drawing.Size(40, 20)
        Me.TxtPpvC.TabIndex = 106
        Me.TxtPpvC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPpvC.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(16, 64)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(105, 13)
        Me.Label28.TabIndex = 117
        Me.Label28.Text = "Precio x Volumen"
        '
        'TxtPMbC
        '
        Me.TxtPMbC.BackColor = System.Drawing.SystemColors.Info
        Me.TxtPMbC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPMbC.Location = New System.Drawing.Point(134, 13)
        Me.TxtPMbC.Name = "TxtPMbC"
        Me.TxtPMbC.Size = New System.Drawing.Size(40, 20)
        Me.TxtPMbC.TabIndex = 104
        Me.TxtPMbC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPMbC.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Maroon
        Me.Label34.Location = New System.Drawing.Point(523, 129)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(70, 13)
        Me.Label34.TabIndex = 145
        Me.Label34.Text = "    Monto   "
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.SystemColors.Info
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(480, 129)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(16, 13)
        Me.Label33.TabIndex = 144
        Me.Label33.Text = "%"
        Me.Label33.Visible = False
        '
        'frmClientesTarifasMasivas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 502)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmClientesTarifasMasivas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarifa Masiva"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridRutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents CbDesMas As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents CbOriMas As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridRutas As System.Windows.Forms.DataGridView
    Friend WithEvents txt_razonsocial As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_marcar_rutas As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtsubcuenta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMMbC As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtMpvC As System.Windows.Forms.TextBox
    Friend WithEvents TxtPppC As System.Windows.Forms.TextBox
    Friend WithEvents TxtMppC As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtPpvC As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtPMbC As System.Windows.Forms.TextBox
    Friend WithEvents txtidsubcuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_desmarcar_rutas As System.Windows.Forms.Button
    Friend WithEvents cmb_centro_costo As System.Windows.Forms.ComboBox
    Friend WithEvents txt_precio_sobre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rgt_descuento As System.Windows.Forms.RadioButton
    Friend WithEvents Rgt_monto As System.Windows.Forms.RadioButton
End Class
