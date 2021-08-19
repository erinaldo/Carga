<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoraExtraPlan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvHora = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCompensacion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMotivo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTipoDia = New System.Windows.Forms.Label()
        Me.lblHoras = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblIngreso = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtActividad = New System.Windows.Forms.TextBox()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblSalida = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTotalCosto = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblcosto100 = New System.Windows.Forms.Label()
        Me.lblhora100 = New System.Windows.Forms.Label()
        Me.lblcosto35 = New System.Windows.Forms.Label()
        Me.lblhora35 = New System.Windows.Forms.Label()
        Me.lblcosto25 = New System.Windows.Forms.Label()
        Me.lblhora25 = New System.Windows.Forms.Label()
        Me.lblTotalHoras = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboEstadoFiltro = New System.Windows.Forms.ComboBox()
        Me.lblEstadoFiltro = New System.Windows.Forms.Label()
        Me.lblAccion = New System.Windows.Forms.Label()
        CType(Me.dgvHora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(193, 455)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 31)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(396, 455)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 31)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dtpInicio
        '
        Me.dtpInicio.CustomFormat = "HH:mm"
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(70, 68)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(72, 20)
        Me.dtpInicio.TabIndex = 2
        '
        'dtpFin
        '
        Me.dtpFin.CustomFormat = "HH:mm"
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFin.Location = New System.Drawing.Point(216, 68)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(72, 20)
        Me.dtpFin.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Fin"
        '
        'dgvHora
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHora.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHora.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvHora.Location = New System.Drawing.Point(12, 219)
        Me.dgvHora.Name = "dgvHora"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHora.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvHora.Size = New System.Drawing.Size(644, 161)
        Me.dgvHora.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(321, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Compensación"
        '
        'cboCompensacion
        '
        Me.cboCompensacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompensacion.FormattingEnabled = True
        Me.cboCompensacion.Items.AddRange(New Object() {"(SELECCIONE)", "EFECTIVO", "DESCANSO"})
        Me.cboCompensacion.Location = New System.Drawing.Point(402, 35)
        Me.cboCompensacion.Name = "cboCompensacion"
        Me.cboCompensacion.Size = New System.Drawing.Size(221, 21)
        Me.cboCompensacion.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Motivo"
        '
        'cboMotivo
        '
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.FormattingEnabled = True
        Me.cboMotivo.Items.AddRange(New Object() {"(SELECCIONE)", "EFECTIVO", "DESCANSO"})
        Me.cboMotivo.Location = New System.Drawing.Point(71, 35)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(216, 21)
        Me.cboMotivo.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Fecha"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(68, 10)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(86, 13)
        Me.lblFecha.TabIndex = 18
        Me.lblFecha.Text = "01/06/2018"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(186, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Tipo"
        '
        'lblTipoDia
        '
        Me.lblTipoDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDia.Location = New System.Drawing.Point(227, 10)
        Me.lblTipoDia.Name = "lblTipoDia"
        Me.lblTipoDia.Size = New System.Drawing.Size(61, 13)
        Me.lblTipoDia.TabIndex = 18
        Me.lblTipoDia.Text = "SIMPLE"
        '
        'lblHoras
        '
        Me.lblHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoras.Location = New System.Drawing.Point(400, 71)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(55, 13)
        Me.lblHoras.TabIndex = 23
        Me.lblHoras.Text = "10"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(321, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Nº Horas"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(321, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Horario"
        '
        'lblIngreso
        '
        Me.lblIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIngreso.Location = New System.Drawing.Point(453, 10)
        Me.lblIngreso.Name = "lblIngreso"
        Me.lblIngreso.Size = New System.Drawing.Size(44, 13)
        Me.lblIngreso.TabIndex = 18
        Me.lblIngreso.Text = "00:00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(173, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Detalle de las actividades a realizar"
        '
        'txtActividad
        '
        Me.txtActividad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActividad.Location = New System.Drawing.Point(12, 117)
        Me.txtActividad.MaxLength = 500
        Me.txtActividad.Multiline = True
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.Size = New System.Drawing.Size(676, 61)
        Me.txtActividad.TabIndex = 4
        '
        'lblCosto
        '
        Me.lblCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCosto.Location = New System.Drawing.Point(538, 71)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(81, 13)
        Me.lblCosto.TabIndex = 27
        Me.lblCosto.Text = "100.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(481, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Costo"
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(308, 187)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(77, 27)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 196)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Lista"
        '
        'lblSalida
        '
        Me.lblSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalida.Location = New System.Drawing.Point(585, 10)
        Me.lblSalida.Name = "lblSalida"
        Me.lblSalida.Size = New System.Drawing.Size(44, 13)
        Me.lblSalida.TabIndex = 18
        Me.lblSalida.Text = "00:00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(400, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Ingreso"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(538, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Salida"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.INTEGRACION.My.Resources.Resources._001
        Me.btnNuevo.Location = New System.Drawing.Point(660, 220)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(28, 24)
        Me.btnNuevo.TabIndex = 5
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.INTEGRACION.My.Resources.Resources._1325
        Me.btnEliminar.Location = New System.Drawing.Point(660, 250)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(28, 24)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblTotalCosto)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblcosto100)
        Me.GroupBox1.Controls.Add(Me.lblhora100)
        Me.GroupBox1.Controls.Add(Me.lblcosto35)
        Me.GroupBox1.Controls.Add(Me.lblhora35)
        Me.GroupBox1.Controls.Add(Me.lblcosto25)
        Me.GroupBox1.Controls.Add(Me.lblhora25)
        Me.GroupBox1.Controls.Add(Me.lblTotalHoras)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(12, 383)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 63)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(29, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "Costo"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(28, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Horas"
        '
        'lblTotalCosto
        '
        Me.lblTotalCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCosto.Location = New System.Drawing.Point(462, 41)
        Me.lblTotalCosto.Name = "lblTotalCosto"
        Me.lblTotalCosto.Size = New System.Drawing.Size(95, 17)
        Me.lblTotalCosto.TabIndex = 27
        Me.lblTotalCosto.Text = "0.00"
        Me.lblTotalCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(519, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 13)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Total"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(392, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "100%"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(275, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "35%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(155, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "25%"
        '
        'lblcosto100
        '
        Me.lblcosto100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcosto100.Location = New System.Drawing.Point(328, 41)
        Me.lblcosto100.Name = "lblcosto100"
        Me.lblcosto100.Size = New System.Drawing.Size(95, 17)
        Me.lblcosto100.TabIndex = 27
        Me.lblcosto100.Text = "0.00"
        Me.lblcosto100.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblhora100
        '
        Me.lblhora100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhora100.Location = New System.Drawing.Point(328, 24)
        Me.lblhora100.Name = "lblhora100"
        Me.lblhora100.Size = New System.Drawing.Size(95, 17)
        Me.lblhora100.TabIndex = 27
        Me.lblhora100.Text = "0.00"
        Me.lblhora100.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblcosto35
        '
        Me.lblcosto35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcosto35.Location = New System.Drawing.Point(208, 41)
        Me.lblcosto35.Name = "lblcosto35"
        Me.lblcosto35.Size = New System.Drawing.Size(95, 17)
        Me.lblcosto35.TabIndex = 27
        Me.lblcosto35.Text = "0.00"
        Me.lblcosto35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblhora35
        '
        Me.lblhora35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhora35.Location = New System.Drawing.Point(208, 24)
        Me.lblhora35.Name = "lblhora35"
        Me.lblhora35.Size = New System.Drawing.Size(95, 17)
        Me.lblhora35.TabIndex = 27
        Me.lblhora35.Text = "0.00"
        Me.lblhora35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblcosto25
        '
        Me.lblcosto25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcosto25.Location = New System.Drawing.Point(88, 41)
        Me.lblcosto25.Name = "lblcosto25"
        Me.lblcosto25.Size = New System.Drawing.Size(95, 17)
        Me.lblcosto25.TabIndex = 27
        Me.lblcosto25.Text = "0.00"
        Me.lblcosto25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblhora25
        '
        Me.lblhora25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhora25.Location = New System.Drawing.Point(88, 24)
        Me.lblhora25.Name = "lblhora25"
        Me.lblhora25.Size = New System.Drawing.Size(95, 17)
        Me.lblhora25.TabIndex = 27
        Me.lblhora25.Text = "0.00"
        Me.lblhora25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalHoras
        '
        Me.lblTotalHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHoras.Location = New System.Drawing.Point(462, 24)
        Me.lblTotalHoras.Name = "lblTotalHoras"
        Me.lblTotalHoras.Size = New System.Drawing.Size(95, 17)
        Me.lblTotalHoras.TabIndex = 27
        Me.lblTotalHoras.Text = "0.00"
        Me.lblTotalHoras.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(518, 94)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(173, 13)
        Me.lblEstado.TabIndex = 18
        Me.lblEstado.Text = "PENDIENTE"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEstadoFiltro
        '
        Me.cboEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoFiltro.FormattingEnabled = True
        Me.cboEstadoFiltro.Items.AddRange(New Object() {"PENDIENTE", "DESAPROBADO"})
        Me.cboEstadoFiltro.Location = New System.Drawing.Point(535, 191)
        Me.cboEstadoFiltro.Name = "cboEstadoFiltro"
        Me.cboEstadoFiltro.Size = New System.Drawing.Size(121, 21)
        Me.cboEstadoFiltro.TabIndex = 29
        '
        'lblEstadoFiltro
        '
        Me.lblEstadoFiltro.AutoSize = True
        Me.lblEstadoFiltro.Location = New System.Drawing.Point(488, 196)
        Me.lblEstadoFiltro.Name = "lblEstadoFiltro"
        Me.lblEstadoFiltro.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoFiltro.TabIndex = 18
        Me.lblEstadoFiltro.Text = "Estado"
        '
        'lblAccion
        '
        Me.lblAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccion.Location = New System.Drawing.Point(305, 97)
        Me.lblAccion.Name = "lblAccion"
        Me.lblAccion.Size = New System.Drawing.Size(109, 14)
        Me.lblAccion.TabIndex = 71
        Me.lblAccion.Text = "AGREGANDO"
        Me.lblAccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmHoraExtraPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 493)
        Me.Controls.Add(Me.lblAccion)
        Me.Controls.Add(Me.cboEstadoFiltro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lblCosto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtActividad)
        Me.Controls.Add(Me.lblHoras)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboMotivo)
        Me.Controls.Add(Me.cboCompensacion)
        Me.Controls.Add(Me.dgvHora)
        Me.Controls.Add(Me.lblEstadoFiltro)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSalida)
        Me.Controls.Add(Me.lblIngreso)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblTipoDia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFin)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHoraExtraPlan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Horas Extras"
        CType(Me.dgvHora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvHora As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCompensacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTipoDia As System.Windows.Forms.Label
    Friend WithEvents lblHoras As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblIngreso As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtActividad As System.Windows.Forms.TextBox
    Friend WithEvents lblCosto As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblSalida As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCosto As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblcosto100 As System.Windows.Forms.Label
    Friend WithEvents lblhora100 As System.Windows.Forms.Label
    Friend WithEvents lblcosto35 As System.Windows.Forms.Label
    Friend WithEvents lblhora35 As System.Windows.Forms.Label
    Friend WithEvents lblcosto25 As System.Windows.Forms.Label
    Friend WithEvents lblhora25 As System.Windows.Forms.Label
    Friend WithEvents lblTotalHoras As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cboEstadoFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstadoFiltro As System.Windows.Forms.Label
    Friend WithEvents lblAccion As System.Windows.Forms.Label
End Class
