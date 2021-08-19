<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeleventa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTeleventa))
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCartera = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboFuente = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtLlamada = New System.Windows.Forms.RadioButton()
        Me.rbtCierre = New System.Windows.Forms.RadioButton()
        Me.rbtConversion = New System.Windows.Forms.RadioButton()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.rbtDia = New System.Windows.Forms.RadioButton()
        Me.rbtResumen = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl34 = New System.Windows.Forms.Label()
        Me.lbl35 = New System.Windows.Forms.Label()
        Me.lbl36 = New System.Windows.Forms.Label()
        Me.lbl33 = New System.Windows.Forms.Label()
        Me.lbl32 = New System.Windows.Forms.Label()
        Me.lbl31 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl13 = New System.Windows.Forms.Label()
        Me.lbl14 = New System.Windows.Forms.Label()
        Me.lbl15 = New System.Windows.Forms.Label()
        Me.lbl12 = New System.Windows.Forms.Label()
        Me.lbl11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl23 = New System.Windows.Forms.Label()
        Me.lbl24 = New System.Windows.Forms.Label()
        Me.lbl25 = New System.Windows.Forms.Label()
        Me.lbl22 = New System.Windows.Forms.Label()
        Me.lbl21 = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbVer = New System.Windows.Forms.ToolStripButton()
        Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(80, 31)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaInicio.TabIndex = 3
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(11, 34)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(65, 13)
        Me.Label55.TabIndex = 4
        Me.Label55.Text = "Fecha Inicio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha Fin"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(308, 31)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaFin.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cartera"
        '
        'cboCartera
        '
        Me.cboCartera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCartera.DropDownWidth = 200
        Me.cboCartera.FormattingEnabled = True
        Me.cboCartera.Location = New System.Drawing.Point(80, 68)
        Me.cboCartera.Name = "cboCartera"
        Me.cboCartera.Size = New System.Drawing.Size(162, 21)
        Me.cboCartera.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(253, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fuente"
        '
        'cboFuente
        '
        Me.cboFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFuente.DropDownWidth = 200
        Me.cboFuente.FormattingEnabled = True
        Me.cboFuente.Location = New System.Drawing.Point(308, 68)
        Me.cboFuente.Name = "cboFuente"
        Me.cboFuente.Size = New System.Drawing.Size(162, 21)
        Me.cboFuente.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtLlamada)
        Me.GroupBox1.Controls.Add(Me.rbtCierre)
        Me.GroupBox1.Controls.Add(Me.rbtConversion)
        Me.GroupBox1.Location = New System.Drawing.Point(487, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 51)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta"
        '
        'rbtLlamada
        '
        Me.rbtLlamada.AutoSize = True
        Me.rbtLlamada.Location = New System.Drawing.Point(214, 21)
        Me.rbtLlamada.Name = "rbtLlamada"
        Me.rbtLlamada.Size = New System.Drawing.Size(65, 17)
        Me.rbtLlamada.TabIndex = 0
        Me.rbtLlamada.Text = "Llamada"
        Me.rbtLlamada.UseVisualStyleBackColor = True
        '
        'rbtCierre
        '
        Me.rbtCierre.AutoSize = True
        Me.rbtCierre.Location = New System.Drawing.Point(124, 21)
        Me.rbtCierre.Name = "rbtCierre"
        Me.rbtCierre.Size = New System.Drawing.Size(52, 17)
        Me.rbtCierre.TabIndex = 0
        Me.rbtCierre.Text = "Cierre"
        Me.rbtCierre.UseVisualStyleBackColor = True
        '
        'rbtConversion
        '
        Me.rbtConversion.AutoSize = True
        Me.rbtConversion.Checked = True
        Me.rbtConversion.Location = New System.Drawing.Point(13, 21)
        Me.rbtConversion.Name = "rbtConversion"
        Me.rbtConversion.Size = New System.Drawing.Size(78, 17)
        Me.rbtConversion.TabIndex = 0
        Me.rbtConversion.TabStop = True
        Me.rbtConversion.Text = "Conversión"
        Me.rbtConversion.UseVisualStyleBackColor = True
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(15, 113)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(897, 420)
        Me.dgvLista.TabIndex = 7
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(817, 41)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 43)
        Me.btnConsultar.TabIndex = 8
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'rbtDia
        '
        Me.rbtDia.AutoSize = True
        Me.rbtDia.Location = New System.Drawing.Point(500, 90)
        Me.rbtDia.Name = "rbtDia"
        Me.rbtDia.Size = New System.Drawing.Size(43, 17)
        Me.rbtDia.TabIndex = 0
        Me.rbtDia.Text = "Día"
        Me.rbtDia.UseVisualStyleBackColor = True
        '
        'rbtResumen
        '
        Me.rbtResumen.AutoSize = True
        Me.rbtResumen.Checked = True
        Me.rbtResumen.Location = New System.Drawing.Point(611, 90)
        Me.rbtResumen.Name = "rbtResumen"
        Me.rbtResumen.Size = New System.Drawing.Size(70, 17)
        Me.rbtResumen.TabIndex = 0
        Me.rbtResumen.TabStop = True
        Me.rbtResumen.Text = "Resumen"
        Me.rbtResumen.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.lbl34)
        Me.Panel3.Controls.Add(Me.lbl35)
        Me.Panel3.Controls.Add(Me.lbl36)
        Me.Panel3.Controls.Add(Me.lbl33)
        Me.Panel3.Controls.Add(Me.lbl32)
        Me.Panel3.Controls.Add(Me.lbl31)
        Me.Panel3.Location = New System.Drawing.Point(16, 538)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(894, 38)
        Me.Panel3.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(664, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Objetivo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(786, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Logro"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(464, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(126, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Nº Llamadas Convertidas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(311, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Nº Llamadas O/B"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(151, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Nº Llamadas I/B"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nº Llamadas"
        '
        'lbl34
        '
        Me.lbl34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl34.Location = New System.Drawing.Point(703, 12)
        Me.lbl34.Name = "lbl34"
        Me.lbl34.Size = New System.Drawing.Size(63, 16)
        Me.lbl34.TabIndex = 0
        Me.lbl34.Text = "0"
        Me.lbl34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl35
        '
        Me.lbl35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl35.Location = New System.Drawing.Point(820, 12)
        Me.lbl35.Name = "lbl35"
        Me.lbl35.Size = New System.Drawing.Size(63, 16)
        Me.lbl35.TabIndex = 0
        Me.lbl35.Text = "0.00"
        Me.lbl35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl36
        '
        Me.lbl36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl36.Location = New System.Drawing.Point(589, 12)
        Me.lbl36.Name = "lbl36"
        Me.lbl36.Size = New System.Drawing.Size(63, 16)
        Me.lbl36.TabIndex = 0
        Me.lbl36.Text = "0"
        Me.lbl36.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl33
        '
        Me.lbl33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl33.Location = New System.Drawing.Point(397, 12)
        Me.lbl33.Name = "lbl33"
        Me.lbl33.Size = New System.Drawing.Size(63, 16)
        Me.lbl33.TabIndex = 0
        Me.lbl33.Text = "0"
        Me.lbl33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl32
        '
        Me.lbl32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl32.Location = New System.Drawing.Point(233, 12)
        Me.lbl32.Name = "lbl32"
        Me.lbl32.Size = New System.Drawing.Size(63, 16)
        Me.lbl32.TabIndex = 0
        Me.lbl32.Text = "0"
        Me.lbl32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl31
        '
        Me.lbl31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl31.Location = New System.Drawing.Point(76, 12)
        Me.lbl31.Name = "lbl31"
        Me.lbl31.Size = New System.Drawing.Size(63, 16)
        Me.lbl31.TabIndex = 0
        Me.lbl31.Text = "0"
        Me.lbl31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lbl13)
        Me.Panel1.Controls.Add(Me.lbl14)
        Me.Panel1.Controls.Add(Me.lbl15)
        Me.Panel1.Controls.Add(Me.lbl12)
        Me.Panel1.Controls.Add(Me.lbl11)
        Me.Panel1.Location = New System.Drawing.Point(16, 537)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(894, 38)
        Me.Panel1.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(535, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Conversión S/."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(373, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Conversión %"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(701, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Conversión %"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(207, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Conversión Llamadas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Nº Llamadas (I/B-O/B)"
        '
        'lbl13
        '
        Me.lbl13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl13.Location = New System.Drawing.Point(445, 12)
        Me.lbl13.Name = "lbl13"
        Me.lbl13.Size = New System.Drawing.Size(63, 16)
        Me.lbl13.TabIndex = 0
        Me.lbl13.Text = "0.00"
        Me.lbl13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl14
        '
        Me.lbl14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl14.Location = New System.Drawing.Point(614, 12)
        Me.lbl14.Name = "lbl14"
        Me.lbl14.Size = New System.Drawing.Size(81, 16)
        Me.lbl14.TabIndex = 0
        Me.lbl14.Text = "0.00"
        Me.lbl14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl15
        '
        Me.lbl15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl15.Location = New System.Drawing.Point(769, 12)
        Me.lbl15.Name = "lbl15"
        Me.lbl15.Size = New System.Drawing.Size(63, 16)
        Me.lbl15.TabIndex = 0
        Me.lbl15.Text = "0.00"
        Me.lbl15.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl15.Visible = False
        '
        'lbl12
        '
        Me.lbl12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl12.Location = New System.Drawing.Point(304, 12)
        Me.lbl12.Name = "lbl12"
        Me.lbl12.Size = New System.Drawing.Size(63, 16)
        Me.lbl12.TabIndex = 0
        Me.lbl12.Text = "0"
        Me.lbl12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl11
        '
        Me.lbl11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl11.Location = New System.Drawing.Point(125, 12)
        Me.lbl11.Name = "lbl11"
        Me.lbl11.Size = New System.Drawing.Size(63, 16)
        Me.lbl11.TabIndex = 0
        Me.lbl11.Text = "0"
        Me.lbl11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.lbl23)
        Me.Panel2.Controls.Add(Me.lbl24)
        Me.Panel2.Controls.Add(Me.lbl25)
        Me.Panel2.Controls.Add(Me.lbl22)
        Me.Panel2.Controls.Add(Me.lbl21)
        Me.Panel2.Location = New System.Drawing.Point(16, 539)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(894, 38)
        Me.Panel2.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(535, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Venta Nueva S/."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(373, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Eficiencia %"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(731, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Logro %"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(207, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Cierre Clientes"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Prospectos Trabajados"
        '
        'lbl23
        '
        Me.lbl23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl23.Location = New System.Drawing.Point(445, 12)
        Me.lbl23.Name = "lbl23"
        Me.lbl23.Size = New System.Drawing.Size(63, 16)
        Me.lbl23.TabIndex = 0
        Me.lbl23.Text = "0.00"
        Me.lbl23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl24
        '
        Me.lbl24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl24.Location = New System.Drawing.Point(618, 12)
        Me.lbl24.Name = "lbl24"
        Me.lbl24.Size = New System.Drawing.Size(89, 16)
        Me.lbl24.TabIndex = 0
        Me.lbl24.Text = "0.00"
        Me.lbl24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl25
        '
        Me.lbl25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl25.Location = New System.Drawing.Point(779, 12)
        Me.lbl25.Name = "lbl25"
        Me.lbl25.Size = New System.Drawing.Size(63, 16)
        Me.lbl25.TabIndex = 0
        Me.lbl25.Text = "0.00"
        Me.lbl25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl22
        '
        Me.lbl22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl22.Location = New System.Drawing.Point(304, 12)
        Me.lbl22.Name = "lbl22"
        Me.lbl22.Size = New System.Drawing.Size(63, 16)
        Me.lbl22.TabIndex = 0
        Me.lbl22.Text = "0"
        Me.lbl22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl21
        '
        Me.lbl21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl21.Location = New System.Drawing.Point(125, 12)
        Me.lbl21.Name = "lbl21"
        Me.lbl21.Size = New System.Drawing.Size(63, 16)
        Me.lbl21.TabIndex = 0
        Me.lbl21.Text = "0"
        Me.lbl21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbAnular, Me.tsbVer, Me.tsbExportar, Me.tsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(928, 25)
        Me.tool.TabIndex = 10
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
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "Editar"
        Me.tsbEditar.Visible = False
        '
        'tsbAnular
        '
        Me.tsbAnular.Image = Global.INTEGRACION.My.Resources.Resources._1102
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(103, 22)
        Me.tsbAnular.Text = "Configuración"
        '
        'tsbVer
        '
        Me.tsbVer.Image = Global.INTEGRACION.My.Resources.Resources.delete_16
        Me.tsbVer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVer.Name = "tsbVer"
        Me.tsbVer.Size = New System.Drawing.Size(125, 22)
        Me.tsbVer.Text = "Llamadas Erróneas"
        '
        'tsbExportar
        '
        Me.tsbExportar.Enabled = False
        Me.tsbExportar.Image = CType(resources.GetObject("tsbExportar.Image"), System.Drawing.Image)
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(70, 22)
        Me.tsbExportar.Text = "Exportar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "Salir"
        '
        'cboGrupo
        '
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.DropDownWidth = 200
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Items.AddRange(New Object() {"Cartera", "Fuente"})
        Me.cboGrupo.Location = New System.Drawing.Point(695, 87)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(110, 21)
        Me.cboGrupo.TabIndex = 5
        Me.cboGrupo.Visible = False
        '
        'frmTeleventa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 582)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.rbtResumen)
        Me.Controls.Add(Me.rbtDia)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.dgvLista)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.cboFuente)
        Me.Controls.Add(Me.cboCartera)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "frmTeleventa"
        Me.Text = "Televentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCartera As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFuente As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtLlamada As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCierre As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConversion As System.Windows.Forms.RadioButton
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents rbtResumen As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDia As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl33 As System.Windows.Forms.Label
    Friend WithEvents lbl32 As System.Windows.Forms.Label
    Friend WithEvents lbl31 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl34 As System.Windows.Forms.Label
    Friend WithEvents lbl35 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbl14 As System.Windows.Forms.Label
    Friend WithEvents lbl15 As System.Windows.Forms.Label
    Friend WithEvents lbl12 As System.Windows.Forms.Label
    Friend WithEvents lbl11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbl13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbl23 As System.Windows.Forms.Label
    Friend WithEvents lbl24 As System.Windows.Forms.Label
    Friend WithEvents lbl25 As System.Windows.Forms.Label
    Friend WithEvents lbl22 As System.Windows.Forms.Label
    Friend WithEvents lbl21 As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbVer As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lbl36 As System.Windows.Forms.Label
End Class
