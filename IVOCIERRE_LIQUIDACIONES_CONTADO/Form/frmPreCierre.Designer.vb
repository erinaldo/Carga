<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrecierre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrecierre))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabCabecera = New System.Windows.Forms.TabControl()
        Me.tabConsulta = New System.Windows.Forms.TabPage()
        Me.grbTotal = New System.Windows.Forms.GroupBox()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblRetiroTotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblRetiroDolar = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblRetiroSoles = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.tabDetalle = New System.Windows.Forms.TabControl()
        Me.tabCierre = New System.Windows.Forms.TabPage()
        Me.dgvMovimiento = New System.Windows.Forms.DataGridView()
        Me.tabRetiro = New System.Windows.Forms.TabPage()
        Me.dgvRetiro = New System.Windows.Forms.DataGridView()
        Me.tabBillete = New System.Windows.Forms.TabPage()
        Me.dgvBillete = New System.Windows.Forms.DataGridView()
        Me.tabComprobante = New System.Windows.Forms.TabPage()
        Me.dgvComprobante = New System.Windows.Forms.DataGridView()
        Me.cboUsuario = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUnidad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.tabPrecierre = New System.Windows.Forms.TabPage()
        Me.btnActualizarCierre = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grbRetiro = New System.Windows.Forms.GroupBox()
        Me.btnRetiroDolarCierre = New System.Windows.Forms.Button()
        Me.btnRetiroSolesCierre = New System.Windows.Forms.Button()
        Me.txtRetiroDolarCierre = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRetiroSolesCierre = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblHoraCierre = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblUsuarioCierre = New System.Windows.Forms.Label()
        Me.lblTotalEfectivoCierre = New System.Windows.Forms.Label()
        Me.lblTipoCambioCierre = New System.Windows.Forms.Label()
        Me.lblUnidadCierre = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFechaCierre = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvComprobanteCierre = New System.Windows.Forms.DataGridView()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbCambiar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabCabecera.SuspendLayout()
        Me.tabConsulta.SuspendLayout()
        Me.grbTotal.SuspendLayout()
        Me.tabDetalle.SuspendLayout()
        Me.tabCierre.SuspendLayout()
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRetiro.SuspendLayout()
        CType(Me.dgvRetiro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBillete.SuspendLayout()
        CType(Me.dgvBillete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabComprobante.SuspendLayout()
        CType(Me.dgvComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrecierre.SuspendLayout()
        Me.grbRetiro.SuspendLayout()
        CType(Me.dgvComprobanteCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabCabecera
        '
        Me.tabCabecera.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCabecera.Controls.Add(Me.tabConsulta)
        Me.tabCabecera.Controls.Add(Me.tabPrecierre)
        Me.tabCabecera.Location = New System.Drawing.Point(12, 36)
        Me.tabCabecera.Name = "tabCabecera"
        Me.tabCabecera.SelectedIndex = 0
        Me.tabCabecera.Size = New System.Drawing.Size(796, 512)
        Me.tabCabecera.TabIndex = 0
        '
        'tabConsulta
        '
        Me.tabConsulta.Controls.Add(Me.grbTotal)
        Me.tabConsulta.Controls.Add(Me.btnConsultar)
        Me.tabConsulta.Controls.Add(Me.tabDetalle)
        Me.tabConsulta.Controls.Add(Me.cboUsuario)
        Me.tabConsulta.Controls.Add(Me.Label2)
        Me.tabConsulta.Controls.Add(Me.cboUnidad)
        Me.tabConsulta.Controls.Add(Me.Label1)
        Me.tabConsulta.Controls.Add(Me.Label147)
        Me.tabConsulta.Controls.Add(Me.dtpFecha)
        Me.tabConsulta.Location = New System.Drawing.Point(4, 22)
        Me.tabConsulta.Name = "tabConsulta"
        Me.tabConsulta.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConsulta.Size = New System.Drawing.Size(788, 486)
        Me.tabConsulta.TabIndex = 0
        Me.tabConsulta.Text = "Consulta"
        Me.tabConsulta.UseVisualStyleBackColor = True
        '
        'grbTotal
        '
        Me.grbTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbTotal.Controls.Add(Me.lblSaldo)
        Me.grbTotal.Controls.Add(Me.Label16)
        Me.grbTotal.Controls.Add(Me.lblRetiroTotal)
        Me.grbTotal.Controls.Add(Me.Label14)
        Me.grbTotal.Controls.Add(Me.lblRetiroDolar)
        Me.grbTotal.Controls.Add(Me.Label12)
        Me.grbTotal.Controls.Add(Me.lblRetiroSoles)
        Me.grbTotal.Controls.Add(Me.Label8)
        Me.grbTotal.Controls.Add(Me.lblMonto)
        Me.grbTotal.Controls.Add(Me.Label6)
        Me.grbTotal.Location = New System.Drawing.Point(17, 417)
        Me.grbTotal.Name = "grbTotal"
        Me.grbTotal.Size = New System.Drawing.Size(755, 49)
        Me.grbTotal.TabIndex = 33
        Me.grbTotal.TabStop = False
        Me.grbTotal.Text = "Total"
        '
        'lblSaldo
        '
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(650, 22)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(81, 13)
        Me.lblSaldo.TabIndex = 35
        Me.lblSaldo.Text = "0.00"
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(613, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Saldo"
        '
        'lblRetiroTotal
        '
        Me.lblRetiroTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetiroTotal.Location = New System.Drawing.Point(513, 22)
        Me.lblRetiroTotal.Name = "lblRetiroTotal"
        Me.lblRetiroTotal.Size = New System.Drawing.Size(81, 13)
        Me.lblRetiroTotal.TabIndex = 36
        Me.lblRetiroTotal.Text = "0.00"
        Me.lblRetiroTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(450, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Total Retiro"
        '
        'lblRetiroDolar
        '
        Me.lblRetiroDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetiroDolar.Location = New System.Drawing.Point(363, 22)
        Me.lblRetiroDolar.Name = "lblRetiroDolar"
        Me.lblRetiroDolar.Size = New System.Drawing.Size(81, 13)
        Me.lblRetiroDolar.TabIndex = 37
        Me.lblRetiroDolar.Text = "0.00"
        Me.lblRetiroDolar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(303, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Retiro US$"
        '
        'lblRetiroSoles
        '
        Me.lblRetiroSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetiroSoles.Location = New System.Drawing.Point(215, 22)
        Me.lblRetiroSoles.Name = "lblRetiroSoles"
        Me.lblRetiroSoles.Size = New System.Drawing.Size(81, 13)
        Me.lblRetiroSoles.TabIndex = 29
        Me.lblRetiroSoles.Text = "0.00"
        Me.lblRetiroSoles.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(161, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Retiro S/."
        '
        'lblMonto
        '
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(52, 22)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(86, 13)
        Me.lblMonto.TabIndex = 33
        Me.lblMonto.Text = "0.00"
        Me.lblMonto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Monto"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(683, 17)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 38)
        Me.btnConsultar.TabIndex = 32
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tabDetalle
        '
        Me.tabDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDetalle.Controls.Add(Me.tabCierre)
        Me.tabDetalle.Controls.Add(Me.tabRetiro)
        Me.tabDetalle.Controls.Add(Me.tabBillete)
        Me.tabDetalle.Controls.Add(Me.tabComprobante)
        Me.tabDetalle.Location = New System.Drawing.Point(17, 123)
        Me.tabDetalle.Name = "tabDetalle"
        Me.tabDetalle.SelectedIndex = 0
        Me.tabDetalle.Size = New System.Drawing.Size(755, 288)
        Me.tabDetalle.TabIndex = 31
        '
        'tabCierre
        '
        Me.tabCierre.Controls.Add(Me.dgvMovimiento)
        Me.tabCierre.Location = New System.Drawing.Point(4, 22)
        Me.tabCierre.Name = "tabCierre"
        Me.tabCierre.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCierre.Size = New System.Drawing.Size(747, 262)
        Me.tabCierre.TabIndex = 0
        Me.tabCierre.Text = "Cierre"
        Me.tabCierre.UseVisualStyleBackColor = True
        '
        'dgvMovimiento
        '
        Me.dgvMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovimiento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMovimiento.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMovimiento.Location = New System.Drawing.Point(11, 13)
        Me.dgvMovimiento.Name = "dgvMovimiento"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovimiento.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMovimiento.Size = New System.Drawing.Size(727, 236)
        Me.dgvMovimiento.TabIndex = 0
        '
        'tabRetiro
        '
        Me.tabRetiro.Controls.Add(Me.dgvRetiro)
        Me.tabRetiro.Location = New System.Drawing.Point(4, 22)
        Me.tabRetiro.Name = "tabRetiro"
        Me.tabRetiro.Size = New System.Drawing.Size(747, 262)
        Me.tabRetiro.TabIndex = 2
        Me.tabRetiro.Text = "Retiro"
        Me.tabRetiro.UseVisualStyleBackColor = True
        '
        'dgvRetiro
        '
        Me.dgvRetiro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRetiro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRetiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRetiro.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRetiro.Location = New System.Drawing.Point(10, 13)
        Me.dgvRetiro.Name = "dgvRetiro"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRetiro.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRetiro.Size = New System.Drawing.Size(727, 236)
        Me.dgvRetiro.TabIndex = 1
        '
        'tabBillete
        '
        Me.tabBillete.Controls.Add(Me.dgvBillete)
        Me.tabBillete.Location = New System.Drawing.Point(4, 22)
        Me.tabBillete.Name = "tabBillete"
        Me.tabBillete.Size = New System.Drawing.Size(747, 262)
        Me.tabBillete.TabIndex = 3
        Me.tabBillete.Text = "Billete"
        Me.tabBillete.UseVisualStyleBackColor = True
        '
        'dgvBillete
        '
        Me.dgvBillete.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillete.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBillete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBillete.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvBillete.Location = New System.Drawing.Point(10, 13)
        Me.dgvBillete.Name = "dgvBillete"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillete.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvBillete.Size = New System.Drawing.Size(727, 236)
        Me.dgvBillete.TabIndex = 2
        '
        'tabComprobante
        '
        Me.tabComprobante.Controls.Add(Me.dgvComprobante)
        Me.tabComprobante.Location = New System.Drawing.Point(4, 22)
        Me.tabComprobante.Name = "tabComprobante"
        Me.tabComprobante.Padding = New System.Windows.Forms.Padding(3)
        Me.tabComprobante.Size = New System.Drawing.Size(747, 262)
        Me.tabComprobante.TabIndex = 1
        Me.tabComprobante.Text = "Comprobante"
        Me.tabComprobante.UseVisualStyleBackColor = True
        '
        'dgvComprobante
        '
        Me.dgvComprobante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobante.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvComprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComprobante.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvComprobante.Location = New System.Drawing.Point(10, 13)
        Me.dgvComprobante.Name = "dgvComprobante"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobante.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvComprobante.Size = New System.Drawing.Size(727, 236)
        Me.dgvComprobante.TabIndex = 2
        '
        'cboUsuario
        '
        Me.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuario.FormattingEnabled = True
        Me.cboUsuario.Location = New System.Drawing.Point(334, 76)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(424, 21)
        Me.cboUsuario.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(273, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Usuario"
        '
        'cboUnidad
        '
        Me.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidad.FormattingEnabled = True
        Me.cboUnidad.Items.AddRange(New Object() {"(TODO)", "CARGA", "PASAJES"})
        Me.cboUnidad.Location = New System.Drawing.Point(106, 74)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(134, 21)
        Me.cboUnidad.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Unidad"
        '
        'Label147
        '
        Me.Label147.AutoSize = True
        Me.Label147.Location = New System.Drawing.Point(36, 35)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(37, 13)
        Me.Label147.TabIndex = 28
        Me.Label147.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFecha.CustomFormat = ""
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(106, 32)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(92, 20)
        Me.dtpFecha.TabIndex = 29
        '
        'tabPrecierre
        '
        Me.tabPrecierre.Controls.Add(Me.btnActualizarCierre)
        Me.tabPrecierre.Controls.Add(Me.btnCerrar)
        Me.tabPrecierre.Controls.Add(Me.grbRetiro)
        Me.tabPrecierre.Controls.Add(Me.lblHoraCierre)
        Me.tabPrecierre.Controls.Add(Me.Label4)
        Me.tabPrecierre.Controls.Add(Me.lblUsuarioCierre)
        Me.tabPrecierre.Controls.Add(Me.lblTotalEfectivoCierre)
        Me.tabPrecierre.Controls.Add(Me.lblTipoCambioCierre)
        Me.tabPrecierre.Controls.Add(Me.lblUnidadCierre)
        Me.tabPrecierre.Controls.Add(Me.Label7)
        Me.tabPrecierre.Controls.Add(Me.lblFechaCierre)
        Me.tabPrecierre.Controls.Add(Me.Label13)
        Me.tabPrecierre.Controls.Add(Me.Label11)
        Me.tabPrecierre.Controls.Add(Me.Label5)
        Me.tabPrecierre.Controls.Add(Me.Label3)
        Me.tabPrecierre.Controls.Add(Me.dgvComprobanteCierre)
        Me.tabPrecierre.Location = New System.Drawing.Point(4, 22)
        Me.tabPrecierre.Name = "tabPrecierre"
        Me.tabPrecierre.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPrecierre.Size = New System.Drawing.Size(788, 486)
        Me.tabPrecierre.TabIndex = 1
        Me.tabPrecierre.Text = "Cierre"
        Me.tabPrecierre.UseVisualStyleBackColor = True
        '
        'btnActualizarCierre
        '
        Me.btnActualizarCierre.Location = New System.Drawing.Point(385, 94)
        Me.btnActualizarCierre.Name = "btnActualizarCierre"
        Me.btnActualizarCierre.Size = New System.Drawing.Size(76, 34)
        Me.btnActualizarCierre.TabIndex = 33
        Me.btnActualizarCierre.Text = "Actualizar"
        Me.btnActualizarCierre.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(674, 42)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(84, 52)
        Me.btnCerrar.TabIndex = 32
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'grbRetiro
        '
        Me.grbRetiro.Controls.Add(Me.btnRetiroDolarCierre)
        Me.grbRetiro.Controls.Add(Me.btnRetiroSolesCierre)
        Me.grbRetiro.Controls.Add(Me.txtRetiroDolarCierre)
        Me.grbRetiro.Controls.Add(Me.Label10)
        Me.grbRetiro.Controls.Add(Me.txtRetiroSolesCierre)
        Me.grbRetiro.Controls.Add(Me.Label9)
        Me.grbRetiro.Location = New System.Drawing.Point(27, 402)
        Me.grbRetiro.Name = "grbRetiro"
        Me.grbRetiro.Size = New System.Drawing.Size(504, 62)
        Me.grbRetiro.TabIndex = 31
        Me.grbRetiro.TabStop = False
        Me.grbRetiro.Text = "Retiro de Dinero"
        '
        'btnRetiroDolarCierre
        '
        Me.btnRetiroDolarCierre.Enabled = False
        Me.btnRetiroDolarCierre.Location = New System.Drawing.Point(440, 22)
        Me.btnRetiroDolarCierre.Name = "btnRetiroDolarCierre"
        Me.btnRetiroDolarCierre.Size = New System.Drawing.Size(28, 22)
        Me.btnRetiroDolarCierre.TabIndex = 31
        Me.btnRetiroDolarCierre.Text = "..."
        Me.btnRetiroDolarCierre.UseVisualStyleBackColor = True
        '
        'btnRetiroSolesCierre
        '
        Me.btnRetiroSolesCierre.Enabled = False
        Me.btnRetiroSolesCierre.Location = New System.Drawing.Point(180, 22)
        Me.btnRetiroSolesCierre.Name = "btnRetiroSolesCierre"
        Me.btnRetiroSolesCierre.Size = New System.Drawing.Size(28, 22)
        Me.btnRetiroSolesCierre.TabIndex = 31
        Me.btnRetiroSolesCierre.Text = "..."
        Me.btnRetiroSolesCierre.UseVisualStyleBackColor = True
        '
        'txtRetiroDolarCierre
        '
        Me.txtRetiroDolarCierre.Location = New System.Drawing.Point(338, 23)
        Me.txtRetiroDolarCierre.Name = "txtRetiroDolarCierre"
        Me.txtRetiroDolarCierre.ReadOnly = True
        Me.txtRetiroDolarCierre.Size = New System.Drawing.Size(100, 20)
        Me.txtRetiroDolarCierre.TabIndex = 30
        Me.txtRetiroDolarCierre.Text = "0.00"
        Me.txtRetiroDolarCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(268, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Monto US$"
        '
        'txtRetiroSolesCierre
        '
        Me.txtRetiroSolesCierre.Location = New System.Drawing.Point(78, 23)
        Me.txtRetiroSolesCierre.Name = "txtRetiroSolesCierre"
        Me.txtRetiroSolesCierre.ReadOnly = True
        Me.txtRetiroSolesCierre.Size = New System.Drawing.Size(100, 20)
        Me.txtRetiroSolesCierre.TabIndex = 30
        Me.txtRetiroSolesCierre.Text = "0.00"
        Me.txtRetiroSolesCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Monto S/."
        '
        'lblHoraCierre
        '
        Me.lblHoraCierre.AutoSize = True
        Me.lblHoraCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraCierre.Location = New System.Drawing.Point(298, 21)
        Me.lblHoraCierre.Name = "lblHoraCierre"
        Me.lblHoraCierre.Size = New System.Drawing.Size(67, 13)
        Me.lblHoraCierre.TabIndex = 29
        Me.lblHoraCierre.Text = "12:00 p.m."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Hora"
        '
        'lblUsuarioCierre
        '
        Me.lblUsuarioCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioCierre.Location = New System.Drawing.Point(272, 50)
        Me.lblUsuarioCierre.Name = "lblUsuarioCierre"
        Me.lblUsuarioCierre.Size = New System.Drawing.Size(375, 13)
        Me.lblUsuarioCierre.TabIndex = 29
        Me.lblUsuarioCierre.Text = "HUMBERTO LAMAS"
        '
        'lblTotalEfectivoCierre
        '
        Me.lblTotalEfectivoCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEfectivoCierre.Location = New System.Drawing.Point(661, 428)
        Me.lblTotalEfectivoCierre.Name = "lblTotalEfectivoCierre"
        Me.lblTotalEfectivoCierre.Size = New System.Drawing.Size(101, 13)
        Me.lblTotalEfectivoCierre.TabIndex = 29
        Me.lblTotalEfectivoCierre.Text = "0.00"
        Me.lblTotalEfectivoCierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipoCambioCierre
        '
        Me.lblTipoCambioCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCambioCierre.Location = New System.Drawing.Point(102, 80)
        Me.lblTipoCambioCierre.Name = "lblTipoCambioCierre"
        Me.lblTipoCambioCierre.Size = New System.Drawing.Size(75, 13)
        Me.lblTipoCambioCierre.TabIndex = 29
        Me.lblTipoCambioCierre.Text = "3.50"
        '
        'lblUnidadCierre
        '
        Me.lblUnidadCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadCierre.Location = New System.Drawing.Point(102, 50)
        Me.lblUnidadCierre.Name = "lblUnidadCierre"
        Me.lblUnidadCierre.Size = New System.Drawing.Size(75, 13)
        Me.lblUnidadCierre.TabIndex = 29
        Me.lblUnidadCierre.Text = "CARGA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(206, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Usuario"
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaCierre.Location = New System.Drawing.Point(102, 21)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(75, 13)
        Me.lblFechaCierre.TabIndex = 29
        Me.lblFechaCierre.Text = "17/07/2017"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(24, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Tipo Cambio"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(587, 428)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Total Efectivo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Unidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Fecha"
        '
        'dgvComprobanteCierre
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobanteCierre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvComprobanteCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComprobanteCierre.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvComprobanteCierre.Location = New System.Drawing.Point(27, 139)
        Me.dgvComprobanteCierre.Name = "dgvComprobanteCierre"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobanteCierre.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvComprobanteCierre.Size = New System.Drawing.Size(735, 251)
        Me.dgvComprobanteCierre.TabIndex = 0
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbCambiar, Me.tsbGrabar, Me.tsbAnular, Me.tsbImprimir, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(818, 25)
        Me.tool.TabIndex = 9
        Me.tool.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "Nuevo"
        Me.tsbNuevo.Visible = False
        '
        'tsbCambiar
        '
        Me.tsbCambiar.Image = CType(resources.GetObject("tsbCambiar.Image"), System.Drawing.Image)
        Me.tsbCambiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCambiar.Name = "tsbCambiar"
        Me.tsbCambiar.Size = New System.Drawing.Size(115, 22)
        Me.tsbCambiar.Text = "Cambiar Usuario"
        Me.tsbCambiar.Visible = False
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "Grabar"
        Me.tsbGrabar.Visible = False
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1321
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
        Me.tsbAnular.Text = "Anular"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'frmPrecierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 560)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.tabCabecera)
        Me.Name = "frmPrecierre"
        Me.Text = "Pre-Cierre de Caja"
        Me.tabCabecera.ResumeLayout(False)
        Me.tabConsulta.ResumeLayout(False)
        Me.tabConsulta.PerformLayout()
        Me.grbTotal.ResumeLayout(False)
        Me.grbTotal.PerformLayout()
        Me.tabDetalle.ResumeLayout(False)
        Me.tabCierre.ResumeLayout(False)
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRetiro.ResumeLayout(False)
        CType(Me.dgvRetiro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBillete.ResumeLayout(False)
        CType(Me.dgvBillete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabComprobante.ResumeLayout(False)
        CType(Me.dgvComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrecierre.ResumeLayout(False)
        Me.tabPrecierre.PerformLayout()
        Me.grbRetiro.ResumeLayout(False)
        Me.grbRetiro.PerformLayout()
        CType(Me.dgvComprobanteCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabCabecera As System.Windows.Forms.TabControl
    Friend WithEvents tabConsulta As System.Windows.Forms.TabPage
    Friend WithEvents tabPrecierre As System.Windows.Forms.TabPage
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabDetalle As System.Windows.Forms.TabControl
    Friend WithEvents tabCierre As System.Windows.Forms.TabPage
    Friend WithEvents tabComprobante As System.Windows.Forms.TabPage
    Friend WithEvents dgvMovimiento As System.Windows.Forms.DataGridView
    Friend WithEvents lblHoraCierre As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvComprobanteCierre As System.Windows.Forms.DataGridView
    Friend WithEvents lblUnidadCierre As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioCierre As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tabRetiro As System.Windows.Forms.TabPage
    Friend WithEvents grbRetiro As System.Windows.Forms.GroupBox
    Friend WithEvents txtRetiroDolarCierre As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRetiroSolesCierre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTotalEfectivoCierre As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnActualizarCierre As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnRetiroDolarCierre As System.Windows.Forms.Button
    Friend WithEvents btnRetiroSolesCierre As System.Windows.Forms.Button
    Friend WithEvents lblTipoCambioCierre As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgvRetiro As System.Windows.Forms.DataGridView
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dgvComprobante As System.Windows.Forms.DataGridView
    Friend WithEvents tabBillete As System.Windows.Forms.TabPage
    Friend WithEvents dgvBillete As System.Windows.Forms.DataGridView
    Friend WithEvents grbTotal As System.Windows.Forms.GroupBox
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblRetiroTotal As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblRetiroDolar As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRetiroSoles As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCambiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
