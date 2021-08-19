<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenerarDescuentoVenta
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
        Me.txtMemo = New System.Windows.Forms.TextBox
        Me.lbMemo = New System.Windows.Forms.Label
        Me.txtPorcernt_Descuento = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lbFacturador = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtNroGuia = New System.Windows.Forms.TextBox
        Me.txtFormaPago = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSub_Total = New System.Windows.Forms.TextBox
        Me.txtMonto_IGV = New System.Windows.Forms.TextBox
        Me.txtCosto_Total = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOrigen = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCostoReal = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtLogin = New System.Windows.Forms.Label
        Me.txtFecha_Actualizacion = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.txtDestino = New System.Windows.Forms.TextBox
        Me.txtNroBultos = New System.Windows.Forms.TextBox
        Me.txtNroSobres = New System.Windows.Forms.TextBox
        Me.txtPeso = New System.Windows.Forms.TextBox
        Me.txtVolumen = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtFacturador = New System.Windows.Forms.TextBox
        Me.txtFacturada = New System.Windows.Forms.Label
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMemo
        '
        Me.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMemo.Location = New System.Drawing.Point(87, 163)
        Me.txtMemo.MaxLength = 15
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(138, 20)
        Me.txtMemo.TabIndex = 268
        '
        'lbMemo
        '
        Me.lbMemo.AutoSize = True
        Me.lbMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMemo.ForeColor = System.Drawing.Color.Maroon
        Me.lbMemo.Location = New System.Drawing.Point(32, 167)
        Me.lbMemo.Name = "lbMemo"
        Me.lbMemo.Size = New System.Drawing.Size(44, 13)
        Me.lbMemo.TabIndex = 264
        Me.lbMemo.Text = "MEMO"
        '
        'txtPorcernt_Descuento
        '
        Me.txtPorcernt_Descuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcernt_Descuento.Location = New System.Drawing.Point(87, 140)
        Me.txtPorcernt_Descuento.MaxLength = 15
        Me.txtPorcernt_Descuento.Name = "txtPorcernt_Descuento"
        Me.txtPorcernt_Descuento.Size = New System.Drawing.Size(64, 20)
        Me.txtPorcernt_Descuento.TabIndex = 267
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(157, 144)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 261
        Me.Label14.Text = "% (P/V)"
        '
        'lbFacturador
        '
        Me.lbFacturador.AutoSize = True
        Me.lbFacturador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFacturador.ForeColor = System.Drawing.Color.Maroon
        Me.lbFacturador.Location = New System.Drawing.Point(7, 118)
        Me.lbFacturador.Name = "lbFacturador"
        Me.lbFacturador.Size = New System.Drawing.Size(70, 13)
        Me.lbFacturador.TabIndex = 262
        Me.lbFacturador.Text = "Facturar A:"
        Me.lbFacturador.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Maroon
        Me.Label32.Location = New System.Drawing.Point(7, 144)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(68, 13)
        Me.Label32.TabIndex = 263
        Me.Label32.Text = "Descuento"
        '
        'txtNroGuia
        '
        Me.txtNroGuia.BackColor = System.Drawing.Color.Azure
        Me.txtNroGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroGuia.Location = New System.Drawing.Point(471, 10)
        Me.txtNroGuia.Name = "txtNroGuia"
        Me.txtNroGuia.ReadOnly = True
        Me.txtNroGuia.Size = New System.Drawing.Size(114, 20)
        Me.txtNroGuia.TabIndex = 279
        Me.txtNroGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFormaPago
        '
        Me.txtFormaPago.BackColor = System.Drawing.Color.Azure
        Me.txtFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormaPago.Location = New System.Drawing.Point(87, 33)
        Me.txtFormaPago.MaxLength = 30
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.ReadOnly = True
        Me.txtFormaPago.Size = New System.Drawing.Size(152, 20)
        Me.txtFormaPago.TabIndex = 260
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(407, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 275
        Me.Label4.Text = "Nro Doc:"
        '
        'txtSub_Total
        '
        Me.txtSub_Total.BackColor = System.Drawing.Color.Azure
        Me.txtSub_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSub_Total.Location = New System.Drawing.Point(472, 173)
        Me.txtSub_Total.MaxLength = 7
        Me.txtSub_Total.Name = "txtSub_Total"
        Me.txtSub_Total.ReadOnly = True
        Me.txtSub_Total.Size = New System.Drawing.Size(113, 20)
        Me.txtSub_Total.TabIndex = 270
        Me.txtSub_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonto_IGV
        '
        Me.txtMonto_IGV.BackColor = System.Drawing.Color.Azure
        Me.txtMonto_IGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonto_IGV.Location = New System.Drawing.Point(472, 199)
        Me.txtMonto_IGV.MaxLength = 7
        Me.txtMonto_IGV.Name = "txtMonto_IGV"
        Me.txtMonto_IGV.ReadOnly = True
        Me.txtMonto_IGV.Size = New System.Drawing.Size(113, 20)
        Me.txtMonto_IGV.TabIndex = 271
        Me.txtMonto_IGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCosto_Total
        '
        Me.txtCosto_Total.BackColor = System.Drawing.Color.Azure
        Me.txtCosto_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCosto_Total.Location = New System.Drawing.Point(472, 223)
        Me.txtCosto_Total.MaxLength = 7
        Me.txtCosto_Total.Name = "txtCosto_Total"
        Me.txtCosto_Total.ReadOnly = True
        Me.txtCosto_Total.Size = New System.Drawing.Size(113, 20)
        Me.txtCosto_Total.TabIndex = 269
        Me.txtCosto_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Maroon
        Me.Label27.Location = New System.Drawing.Point(383, 180)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 13)
        Me.Label27.TabIndex = 274
        Me.Label27.Text = "Sub Total"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Maroon
        Me.Label26.Location = New System.Drawing.Point(383, 204)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 273
        Me.Label26.Text = "IGV"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(384, 228)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 13)
        Me.Label18.TabIndex = 272
        Me.Label18.Text = "Total     (F9)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(7, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "F.de Pago:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(7, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 262
        Me.Label2.Text = "Cliente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.Color.Azure
        Me.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrigen.Location = New System.Drawing.Point(87, 7)
        Me.txtOrigen.MaxLength = 30
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(138, 20)
        Me.txtOrigen.TabIndex = 260
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(7, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 262
        Me.Label3.Text = "Origen"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(228, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Destino"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(7, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 262
        Me.Label5.Text = "Nro Bultos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(171, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 262
        Me.Label7.Text = "Nro Sobres"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(334, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 262
        Me.Label8.Text = "Peso"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(449, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 262
        Me.Label9.Text = "Volumen"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(383, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 272
        Me.Label10.Text = "T. Costo Real"
        '
        'txtCostoReal
        '
        Me.txtCostoReal.BackColor = System.Drawing.Color.Silver
        Me.txtCostoReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostoReal.Location = New System.Drawing.Point(472, 148)
        Me.txtCostoReal.MaxLength = 7
        Me.txtCostoReal.Name = "txtCostoReal"
        Me.txtCostoReal.ReadOnly = True
        Me.txtCostoReal.Size = New System.Drawing.Size(113, 20)
        Me.txtCostoReal.TabIndex = 269
        Me.txtCostoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.txtLogin)
        Me.GroupBox1.Controls.Add(Me.txtFecha_Actualizacion)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 183)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 65)
        Me.GroupBox1.TabIndex = 280
        Me.GroupBox1.TabStop = False
        '
        'txtLogin
        '
        Me.txtLogin.AutoSize = True
        Me.txtLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogin.Location = New System.Drawing.Point(145, 39)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(50, 16)
        Me.txtLogin.TabIndex = 277
        Me.txtLogin.Text = "jsalas"
        '
        'txtFecha_Actualizacion
        '
        Me.txtFecha_Actualizacion.AutoSize = True
        Me.txtFecha_Actualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha_Actualizacion.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtFecha_Actualizacion.Location = New System.Drawing.Point(120, 14)
        Me.txtFecha_Actualizacion.Name = "txtFecha_Actualizacion"
        Me.txtFecha_Actualizacion.Size = New System.Drawing.Size(132, 15)
        Me.txtFecha_Actualizacion.TabIndex = 276
        Me.txtFecha_Actualizacion.Text = "12/10/2007 5:30PM"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(4, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 15)
        Me.Label17.TabIndex = 275
        Me.Label17.Text = "Login Actualizacion:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(4, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 15)
        Me.Label15.TabIndex = 275
        Me.Label15.Text = "F.Actualizacion:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(277, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 274
        Me.Label12.Text = "[ ESC ] Salir"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(277, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 274
        Me.Label11.Text = "[ F5 ] Grabar"
        Me.Label11.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(407, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 275
        Me.Label13.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.Azure
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Location = New System.Drawing.Point(471, 34)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(114, 20)
        Me.txtFecha.TabIndex = 279
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDestino
        '
        Me.txtDestino.BackColor = System.Drawing.Color.Azure
        Me.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestino.Location = New System.Drawing.Point(281, 8)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.ReadOnly = True
        Me.txtDestino.Size = New System.Drawing.Size(120, 20)
        Me.txtDestino.TabIndex = 281
        '
        'txtNroBultos
        '
        Me.txtNroBultos.BackColor = System.Drawing.Color.Azure
        Me.txtNroBultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroBultos.Location = New System.Drawing.Point(87, 59)
        Me.txtNroBultos.Name = "txtNroBultos"
        Me.txtNroBultos.ReadOnly = True
        Me.txtNroBultos.Size = New System.Drawing.Size(72, 20)
        Me.txtNroBultos.TabIndex = 281
        '
        'txtNroSobres
        '
        Me.txtNroSobres.BackColor = System.Drawing.Color.Azure
        Me.txtNroSobres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroSobres.Location = New System.Drawing.Point(247, 59)
        Me.txtNroSobres.Name = "txtNroSobres"
        Me.txtNroSobres.ReadOnly = True
        Me.txtNroSobres.Size = New System.Drawing.Size(79, 20)
        Me.txtNroSobres.TabIndex = 282
        '
        'txtPeso
        '
        Me.txtPeso.BackColor = System.Drawing.Color.Azure
        Me.txtPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeso.Location = New System.Drawing.Point(376, 60)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.ReadOnly = True
        Me.txtPeso.Size = New System.Drawing.Size(65, 20)
        Me.txtPeso.TabIndex = 283
        '
        'txtVolumen
        '
        Me.txtVolumen.BackColor = System.Drawing.Color.Azure
        Me.txtVolumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVolumen.Location = New System.Drawing.Point(513, 59)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.ReadOnly = True
        Me.txtVolumen.Size = New System.Drawing.Size(71, 20)
        Me.txtVolumen.TabIndex = 284
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.Azure
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(87, 88)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(308, 20)
        Me.txtCliente.TabIndex = 285
        '
        'txtFacturador
        '
        Me.txtFacturador.BackColor = System.Drawing.Color.Azure
        Me.txtFacturador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFacturador.Location = New System.Drawing.Point(87, 115)
        Me.txtFacturador.Name = "txtFacturador"
        Me.txtFacturador.ReadOnly = True
        Me.txtFacturador.Size = New System.Drawing.Size(308, 20)
        Me.txtFacturador.TabIndex = 286
        '
        'txtFacturada
        '
        Me.txtFacturada.AutoSize = True
        Me.txtFacturada.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacturada.Location = New System.Drawing.Point(406, 101)
        Me.txtFacturada.Name = "txtFacturada"
        Me.txtFacturada.Size = New System.Drawing.Size(134, 24)
        Me.txtFacturada.TabIndex = 277
        Me.txtFacturada.Text = "FACTURADA"
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.Transparent
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.ForeColor = System.Drawing.Color.Maroon
        Me.btnGrabar.Location = New System.Drawing.Point(274, 11)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(82, 23)
        Me.btnGrabar.TabIndex = 278
        Me.btnGrabar.Text = "(F5) Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'FrmGenerarDescuentoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(588, 257)
        Me.Controls.Add(Me.txtFacturada)
        Me.Controls.Add(Me.txtFacturador)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtVolumen)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.txtNroSobres)
        Me.Controls.Add(Me.txtNroBultos)
        Me.Controls.Add(Me.txtDestino)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.lbMemo)
        Me.Controls.Add(Me.txtPorcernt_Descuento)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbFacturador)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtNroGuia)
        Me.Controls.Add(Me.txtOrigen)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtFormaPago)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSub_Total)
        Me.Controls.Add(Me.txtMonto_IGV)
        Me.Controls.Add(Me.txtCostoReal)
        Me.Controls.Add(Me.txtCosto_Total)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label18)
        Me.Name = "FrmGenerarDescuentoVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorizacion de Descuentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents lbMemo As System.Windows.Forms.Label
    Friend WithEvents txtPorcernt_Descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbFacturador As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtNroGuia As System.Windows.Forms.TextBox
    Friend WithEvents txtFormaPago As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSub_Total As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto_IGV As System.Windows.Forms.TextBox
    Friend WithEvents txtCosto_Total As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCostoReal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtNroBultos As System.Windows.Forms.TextBox
    Friend WithEvents txtNroSobres As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtFacturador As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFacturada As System.Windows.Forms.Label
    Friend WithEvents txtFecha_Actualizacion As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
End Class
