<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocCliente
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnACEP = New System.Windows.Forms.Button()
        Me.TXTOBS = New System.Windows.Forms.RichTextBox()
        Me.CBIDTIPO_COMPROBANTE = New System.Windows.Forms.ComboBox()
        Me.CBIDTIPO_MONEDA = New System.Windows.Forms.ComboBox()
        Me.BTNCANCE = New System.Windows.Forms.Button()
        Me.MTBNRO_FACTURA = New System.Windows.Forms.MaskedTextBox()
        Me.TXTMONTO_SUB_TOTAL = New System.Windows.Forms.TextBox()
        Me.TXTMONTO_IMPUESTO = New System.Windows.Forms.TextBox()
        Me.TXTMONTO_TIPO_CAMBIO = New System.Windows.Forms.TextBox()
        Me.TXTTOTAL_COSTO = New System.Windows.Forms.TextBox()
        Me.TXTPORCEN = New System.Windows.Forms.TextBox()
        Me.TXTVALOR_CALCU = New System.Windows.Forms.TextBox()
        Me.BTNPRIME = New System.Windows.Forms.Button()
        Me.BTNANTE = New System.Windows.Forms.Button()
        Me.BTNSIGUI = New System.Windows.Forms.Button()
        Me.BTNULTI = New System.Windows.Forms.Button()
        Me.BTNNUE = New System.Windows.Forms.Button()
        Me.BTNELI = New System.Windows.Forms.Button()
        Me.txtCosto_TotalF = New System.Windows.Forms.TextBox()
        Me.txtMonto_IGVF = New System.Windows.Forms.TextBox()
        Me.txtSub_TotalF = New System.Windows.Forms.TextBox()
        Me.LBLCOTADOR = New System.Windows.Forms.Label()
        Me.DTPFECHA = New System.Windows.Forms.DateTimePicker()
        Me.grdAsegurado = New System.Windows.Forms.DataGridView()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        CType(Me.grdAsegurado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(408, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 21)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "%"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnACEP
        '
        Me.btnACEP.Enabled = False
        Me.btnACEP.Location = New System.Drawing.Point(869, 12)
        Me.btnACEP.Name = "btnACEP"
        Me.btnACEP.Size = New System.Drawing.Size(75, 31)
        Me.btnACEP.TabIndex = 20
        Me.btnACEP.Text = "Aceptar"
        Me.btnACEP.UseVisualStyleBackColor = True
        Me.btnACEP.Visible = False
        '
        'TXTOBS
        '
        Me.TXTOBS.Location = New System.Drawing.Point(618, 72)
        Me.TXTOBS.MaxLength = 200
        Me.TXTOBS.Name = "TXTOBS"
        Me.TXTOBS.Size = New System.Drawing.Size(222, 54)
        Me.TXTOBS.TabIndex = 6
        Me.TXTOBS.Text = ""
        '
        'CBIDTIPO_COMPROBANTE
        '
        Me.CBIDTIPO_COMPROBANTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIDTIPO_COMPROBANTE.FormattingEnabled = True
        Me.CBIDTIPO_COMPROBANTE.Location = New System.Drawing.Point(455, 26)
        Me.CBIDTIPO_COMPROBANTE.Name = "CBIDTIPO_COMPROBANTE"
        Me.CBIDTIPO_COMPROBANTE.Size = New System.Drawing.Size(138, 21)
        Me.CBIDTIPO_COMPROBANTE.TabIndex = 3
        '
        'CBIDTIPO_MONEDA
        '
        Me.CBIDTIPO_MONEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIDTIPO_MONEDA.FormattingEnabled = True
        Me.CBIDTIPO_MONEDA.Location = New System.Drawing.Point(12, 28)
        Me.CBIDTIPO_MONEDA.Name = "CBIDTIPO_MONEDA"
        Me.CBIDTIPO_MONEDA.Size = New System.Drawing.Size(209, 21)
        Me.CBIDTIPO_MONEDA.TabIndex = 0
        '
        'BTNCANCE
        '
        Me.BTNCANCE.Enabled = False
        Me.BTNCANCE.Location = New System.Drawing.Point(869, 49)
        Me.BTNCANCE.Name = "BTNCANCE"
        Me.BTNCANCE.Size = New System.Drawing.Size(75, 31)
        Me.BTNCANCE.TabIndex = 21
        Me.BTNCANCE.Text = "Cancelar"
        Me.BTNCANCE.UseVisualStyleBackColor = True
        Me.BTNCANCE.Visible = False
        '
        'MTBNRO_FACTURA
        '
        Me.MTBNRO_FACTURA.Location = New System.Drawing.Point(618, 28)
        Me.MTBNRO_FACTURA.Mask = "###-########"
        Me.MTBNRO_FACTURA.Name = "MTBNRO_FACTURA"
        Me.MTBNRO_FACTURA.Size = New System.Drawing.Size(93, 20)
        Me.MTBNRO_FACTURA.TabIndex = 4
        '
        'TXTMONTO_SUB_TOTAL
        '
        Me.TXTMONTO_SUB_TOTAL.Location = New System.Drawing.Point(15, 73)
        Me.TXTMONTO_SUB_TOTAL.Name = "TXTMONTO_SUB_TOTAL"
        Me.TXTMONTO_SUB_TOTAL.ReadOnly = True
        Me.TXTMONTO_SUB_TOTAL.Size = New System.Drawing.Size(100, 20)
        Me.TXTMONTO_SUB_TOTAL.TabIndex = 11
        Me.TXTMONTO_SUB_TOTAL.TabStop = False
        Me.TXTMONTO_SUB_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTMONTO_IMPUESTO
        '
        Me.TXTMONTO_IMPUESTO.Location = New System.Drawing.Point(121, 73)
        Me.TXTMONTO_IMPUESTO.Name = "TXTMONTO_IMPUESTO"
        Me.TXTMONTO_IMPUESTO.ReadOnly = True
        Me.TXTMONTO_IMPUESTO.Size = New System.Drawing.Size(100, 20)
        Me.TXTMONTO_IMPUESTO.TabIndex = 12
        Me.TXTMONTO_IMPUESTO.TabStop = False
        Me.TXTMONTO_IMPUESTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTMONTO_TIPO_CAMBIO
        '
        Me.TXTMONTO_TIPO_CAMBIO.Enabled = False
        Me.TXTMONTO_TIPO_CAMBIO.Location = New System.Drawing.Point(227, 28)
        Me.TXTMONTO_TIPO_CAMBIO.Name = "TXTMONTO_TIPO_CAMBIO"
        Me.TXTMONTO_TIPO_CAMBIO.Size = New System.Drawing.Size(94, 20)
        Me.TXTMONTO_TIPO_CAMBIO.TabIndex = 1
        Me.TXTMONTO_TIPO_CAMBIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTAL_COSTO
        '
        Me.TXTTOTAL_COSTO.Location = New System.Drawing.Point(227, 72)
        Me.TXTTOTAL_COSTO.MaxLength = 10
        Me.TXTTOTAL_COSTO.Name = "TXTTOTAL_COSTO"
        Me.TXTTOTAL_COSTO.Size = New System.Drawing.Size(100, 20)
        Me.TXTTOTAL_COSTO.TabIndex = 5
        Me.TXTTOTAL_COSTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPORCEN
        '
        Me.TXTPORCEN.Location = New System.Drawing.Point(344, 73)
        Me.TXTPORCEN.Name = "TXTPORCEN"
        Me.TXTPORCEN.ReadOnly = True
        Me.TXTPORCEN.Size = New System.Drawing.Size(57, 20)
        Me.TXTPORCEN.TabIndex = 14
        Me.TXTPORCEN.TabStop = False
        Me.TXTPORCEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTVALOR_CALCU
        '
        Me.TXTVALOR_CALCU.Location = New System.Drawing.Point(455, 73)
        Me.TXTVALOR_CALCU.Name = "TXTVALOR_CALCU"
        Me.TXTVALOR_CALCU.ReadOnly = True
        Me.TXTVALOR_CALCU.Size = New System.Drawing.Size(100, 20)
        Me.TXTVALOR_CALCU.TabIndex = 15
        Me.TXTVALOR_CALCU.TabStop = False
        Me.TXTVALOR_CALCU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BTNPRIME
        '
        Me.BTNPRIME.Enabled = False
        Me.BTNPRIME.Location = New System.Drawing.Point(986, 26)
        Me.BTNPRIME.Name = "BTNPRIME"
        Me.BTNPRIME.Size = New System.Drawing.Size(33, 23)
        Me.BTNPRIME.TabIndex = 2
        Me.BTNPRIME.Text = "<<"
        Me.BTNPRIME.UseVisualStyleBackColor = True
        '
        'BTNANTE
        '
        Me.BTNANTE.Enabled = False
        Me.BTNANTE.Location = New System.Drawing.Point(1022, 26)
        Me.BTNANTE.Name = "BTNANTE"
        Me.BTNANTE.Size = New System.Drawing.Size(33, 23)
        Me.BTNANTE.TabIndex = 3
        Me.BTNANTE.Text = "<"
        Me.BTNANTE.UseVisualStyleBackColor = True
        '
        'BTNSIGUI
        '
        Me.BTNSIGUI.Enabled = False
        Me.BTNSIGUI.Location = New System.Drawing.Point(1061, 26)
        Me.BTNSIGUI.Name = "BTNSIGUI"
        Me.BTNSIGUI.Size = New System.Drawing.Size(33, 23)
        Me.BTNSIGUI.TabIndex = 4
        Me.BTNSIGUI.Text = ">"
        Me.BTNSIGUI.UseVisualStyleBackColor = True
        '
        'BTNULTI
        '
        Me.BTNULTI.Enabled = False
        Me.BTNULTI.Location = New System.Drawing.Point(1095, 26)
        Me.BTNULTI.Name = "BTNULTI"
        Me.BTNULTI.Size = New System.Drawing.Size(33, 23)
        Me.BTNULTI.TabIndex = 5
        Me.BTNULTI.Text = ">>"
        Me.BTNULTI.UseVisualStyleBackColor = True
        '
        'BTNNUE
        '
        Me.BTNNUE.Enabled = False
        Me.BTNNUE.Location = New System.Drawing.Point(945, 7)
        Me.BTNNUE.Name = "BTNNUE"
        Me.BTNNUE.Size = New System.Drawing.Size(75, 23)
        Me.BTNNUE.TabIndex = 0
        Me.BTNNUE.Text = "Nuevo"
        Me.BTNNUE.UseVisualStyleBackColor = True
        Me.BTNNUE.Visible = False
        '
        'BTNELI
        '
        Me.BTNELI.Enabled = False
        Me.BTNELI.Location = New System.Drawing.Point(945, 49)
        Me.BTNELI.Name = "BTNELI"
        Me.BTNELI.Size = New System.Drawing.Size(75, 23)
        Me.BTNELI.TabIndex = 1
        Me.BTNELI.Text = "Eliminar"
        Me.BTNELI.UseVisualStyleBackColor = True
        Me.BTNELI.Visible = False
        '
        'txtCosto_TotalF
        '
        Me.txtCosto_TotalF.BackColor = System.Drawing.Color.Azure
        Me.txtCosto_TotalF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCosto_TotalF.Location = New System.Drawing.Point(726, 428)
        Me.txtCosto_TotalF.MaxLength = 7
        Me.txtCosto_TotalF.Name = "txtCosto_TotalF"
        Me.txtCosto_TotalF.ReadOnly = True
        Me.txtCosto_TotalF.Size = New System.Drawing.Size(114, 20)
        Me.txtCosto_TotalF.TabIndex = 19
        Me.txtCosto_TotalF.TabStop = False
        Me.txtCosto_TotalF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonto_IGVF
        '
        Me.txtMonto_IGVF.BackColor = System.Drawing.Color.Azure
        Me.txtMonto_IGVF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonto_IGVF.Location = New System.Drawing.Point(726, 404)
        Me.txtMonto_IGVF.MaxLength = 7
        Me.txtMonto_IGVF.Name = "txtMonto_IGVF"
        Me.txtMonto_IGVF.ReadOnly = True
        Me.txtMonto_IGVF.Size = New System.Drawing.Size(114, 20)
        Me.txtMonto_IGVF.TabIndex = 18
        Me.txtMonto_IGVF.TabStop = False
        Me.txtMonto_IGVF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSub_TotalF
        '
        Me.txtSub_TotalF.BackColor = System.Drawing.Color.Azure
        Me.txtSub_TotalF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSub_TotalF.Location = New System.Drawing.Point(726, 381)
        Me.txtSub_TotalF.MaxLength = 7
        Me.txtSub_TotalF.Name = "txtSub_TotalF"
        Me.txtSub_TotalF.ReadOnly = True
        Me.txtSub_TotalF.Size = New System.Drawing.Size(114, 20)
        Me.txtSub_TotalF.TabIndex = 17
        Me.txtSub_TotalF.TabStop = False
        Me.txtSub_TotalF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLCOTADOR
        '
        Me.LBLCOTADOR.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOTADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOTADOR.ForeColor = System.Drawing.Color.Red
        Me.LBLCOTADOR.Location = New System.Drawing.Point(1044, 5)
        Me.LBLCOTADOR.Name = "LBLCOTADOR"
        Me.LBLCOTADOR.Size = New System.Drawing.Size(87, 18)
        Me.LBLCOTADOR.TabIndex = 78
        Me.LBLCOTADOR.Text = "0/0"
        Me.LBLCOTADOR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPFECHA
        '
        Me.DTPFECHA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFECHA.Location = New System.Drawing.Point(341, 27)
        Me.DTPFECHA.Name = "DTPFECHA"
        Me.DTPFECHA.Size = New System.Drawing.Size(93, 20)
        Me.DTPFECHA.TabIndex = 2
        '
        'grdAsegurado
        '
        Me.grdAsegurado.BackgroundColor = System.Drawing.Color.Navy
        Me.grdAsegurado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAsegurado.Location = New System.Drawing.Point(12, 139)
        Me.grdAsegurado.Name = "grdAsegurado"
        Me.grdAsegurado.Size = New System.Drawing.Size(828, 237)
        Me.grdAsegurado.TabIndex = 81
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(11, 403)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(74, 29)
        Me.btnNuevo.TabIndex = 7
        Me.btnNuevo.Tag = ""
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(116, 403)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(74, 29)
        Me.btnModificar.TabIndex = 8
        Me.btnModificar.Tag = ""
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(636, 428)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 87
        Me.Label15.Text = "Total"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(636, 408)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "IGV"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(636, 388)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "Sub Total"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(326, 403)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 29)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Tag = ""
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(221, 403)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(74, 29)
        Me.btnGrabar.TabIndex = 9
        Me.btnGrabar.Tag = ""
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(431, 403)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(74, 29)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Tag = ""
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(9, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 94
        Me.Label16.Text = "Tipo Moneda:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(221, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 95
        Me.Label17.Text = "Tipo de Cambio:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(452, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(97, 13)
        Me.Label21.TabIndex = 98
        Me.Label21.Text = "Tipo Comprobante:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(615, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Nro. Comprobante:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(338, 10)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 13)
        Me.Label19.TabIndex = 102
        Me.Label19.Text = "Fecha:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(121, 57)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 13)
        Me.Label24.TabIndex = 105
        Me.Label24.Text = "Impuesto"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(224, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 13)
        Me.Label23.TabIndex = 104
        Me.Label23.Text = "Total Costo:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(12, 57)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 103
        Me.Label22.Text = "Sub Total:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(536, 403)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(74, 29)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Tag = ""
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(341, 57)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 110
        Me.Label25.Text = "Porcentaje:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(452, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(108, 13)
        Me.Label28.TabIndex = 112
        Me.Label28.Text = "Valor Calculado (S/.):"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(615, 57)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(81, 13)
        Me.Label29.TabIndex = 115
        Me.Label29.Text = "Observaciones:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblDescripcion)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.btnEliminar)
        Me.Panel1.Controls.Add(Me.btnGrabar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.btnModificar)
        Me.Panel1.Controls.Add(Me.btnNuevo)
        Me.Panel1.Controls.Add(Me.grdAsegurado)
        Me.Panel1.Controls.Add(Me.DTPFECHA)
        Me.Panel1.Controls.Add(Me.LBLCOTADOR)
        Me.Panel1.Controls.Add(Me.txtSub_TotalF)
        Me.Panel1.Controls.Add(Me.txtMonto_IGVF)
        Me.Panel1.Controls.Add(Me.txtCosto_TotalF)
        Me.Panel1.Controls.Add(Me.BTNELI)
        Me.Panel1.Controls.Add(Me.BTNNUE)
        Me.Panel1.Controls.Add(Me.BTNULTI)
        Me.Panel1.Controls.Add(Me.BTNSIGUI)
        Me.Panel1.Controls.Add(Me.BTNANTE)
        Me.Panel1.Controls.Add(Me.BTNPRIME)
        Me.Panel1.Controls.Add(Me.TXTVALOR_CALCU)
        Me.Panel1.Controls.Add(Me.TXTPORCEN)
        Me.Panel1.Controls.Add(Me.TXTTOTAL_COSTO)
        Me.Panel1.Controls.Add(Me.TXTMONTO_TIPO_CAMBIO)
        Me.Panel1.Controls.Add(Me.TXTMONTO_IMPUESTO)
        Me.Panel1.Controls.Add(Me.TXTMONTO_SUB_TOTAL)
        Me.Panel1.Controls.Add(Me.MTBNRO_FACTURA)
        Me.Panel1.Controls.Add(Me.BTNCANCE)
        Me.Panel1.Controls.Add(Me.CBIDTIPO_MONEDA)
        Me.Panel1.Controls.Add(Me.CBIDTIPO_COMPROBANTE)
        Me.Panel1.Controls.Add(Me.TXTOBS)
        Me.Panel1.Controls.Add(Me.btnACEP)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(850, 453)
        Me.Panel1.TabIndex = 8
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(9, 116)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(602, 20)
        Me.lblDescripcion.TabIndex = 116
        '
        'FrmDocCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 453)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDocCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga Asegurada"
        CType(Me.grdAsegurado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnACEP As System.Windows.Forms.Button
    Friend WithEvents TXTOBS As System.Windows.Forms.RichTextBox
    Friend WithEvents CBIDTIPO_COMPROBANTE As System.Windows.Forms.ComboBox
    Friend WithEvents CBIDTIPO_MONEDA As System.Windows.Forms.ComboBox
    Friend WithEvents BTNCANCE As System.Windows.Forms.Button
    Friend WithEvents MTBNRO_FACTURA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TXTMONTO_SUB_TOTAL As System.Windows.Forms.TextBox
    Friend WithEvents TXTMONTO_IMPUESTO As System.Windows.Forms.TextBox
    Friend WithEvents TXTMONTO_TIPO_CAMBIO As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTAL_COSTO As System.Windows.Forms.TextBox
    Friend WithEvents TXTPORCEN As System.Windows.Forms.TextBox
    Friend WithEvents TXTVALOR_CALCU As System.Windows.Forms.TextBox
    Friend WithEvents BTNPRIME As System.Windows.Forms.Button
    Friend WithEvents BTNANTE As System.Windows.Forms.Button
    Friend WithEvents BTNSIGUI As System.Windows.Forms.Button
    Friend WithEvents BTNULTI As System.Windows.Forms.Button
    Friend WithEvents BTNNUE As System.Windows.Forms.Button
    Friend WithEvents BTNELI As System.Windows.Forms.Button
    Friend WithEvents txtCosto_TotalF As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto_IGVF As System.Windows.Forms.TextBox
    Friend WithEvents txtSub_TotalF As System.Windows.Forms.TextBox
    Friend WithEvents LBLCOTADOR As System.Windows.Forms.Label
    Friend WithEvents DTPFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdAsegurado As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
End Class
