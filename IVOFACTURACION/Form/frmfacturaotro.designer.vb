<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmfacturaotro
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmfacturaotro))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lbNroRegistro = New System.Windows.Forms.Label()
        Me.lbNroRegistros = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grpbotones = New System.Windows.Forms.GroupBox()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.btnVerData = New System.Windows.Forms.Button()
        Me.btnEmisionfe = New System.Windows.Forms.Button()
        Me.btnImprimirComprobante = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.dGVControl_otrafactura = New System.Windows.Forms.DataGridView()
        Me.CMS_estado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.txtNroSerieDoc = New System.Windows.Forms.TextBox()
        Me.CMBUSUARIOS = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtruc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.txtserie = New System.Windows.Forms.TextBox()
        Me.txtnro_factura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpfecha_emision = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbformapago = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtreferencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.txtimpuesto = New System.Windows.Forms.TextBox()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbtipofactura = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXTGLOSA_sub_total = New System.Windows.Forms.RichTextBox()
        Me.TXTGLOSA = New System.Windows.Forms.RichTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtpreciounitario = New System.Windows.Forms.TextBox()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtigv = New System.Windows.Forms.TextBox()
        Me.txttipo_cambio = New System.Windows.Forms.TextBox()
        Me.Labtipo_cambio = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Cmbmoneda = New System.Windows.Forms.ComboBox()
        Me.cboTipoAfectacion = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtidfactura_otra = New System.Windows.Forms.TextBox()
        Me.txtidpersona = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtdireccion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbrubro = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbDireccion = New System.Windows.Forms.ComboBox()
        Me.txtiddireccion_contacto = New System.Windows.Forms.TextBox()
        Me.txtrepresentante_legal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.grpbotones.SuspendLayout()
        CType(Me.dGVControl_otrafactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_estado.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.btnBuscar)
        Me.TabLista.Controls.Add(Me.dtFechaFin)
        Me.TabLista.Controls.Add(Me.dtFechaInicio)
        Me.TabLista.Controls.Add(Me.lbNroRegistro)
        Me.TabLista.Controls.Add(Me.lbNroRegistros)
        Me.TabLista.Controls.Add(Me.btnNuevo)
        Me.TabLista.Controls.Add(Me.grpbotones)
        Me.TabLista.Controls.Add(Me.dGVControl_otrafactura)
        Me.TabLista.Controls.Add(Me.Label24)
        Me.TabLista.Controls.Add(Me.Label21)
        Me.TabLista.Controls.Add(Me.Label31)
        Me.TabLista.Controls.Add(Me.GroupBox5)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.btnClientes)
        Me.TabDatos.Controls.Add(Me.Label18)
        Me.TabDatos.Controls.Add(Me.txtrepresentante_legal)
        Me.TabDatos.Controls.Add(Me.txtiddireccion_contacto)
        Me.TabDatos.Controls.Add(Me.cmbrubro)
        Me.TabDatos.Controls.Add(Me.Label13)
        Me.TabDatos.Controls.Add(Me.txtdireccion)
        Me.TabDatos.Controls.Add(Me.Label12)
        Me.TabDatos.Controls.Add(Me.txtidpersona)
        Me.TabDatos.Controls.Add(Me.txtidfactura_otra)
        Me.TabDatos.Controls.Add(Me.btngrabar)
        Me.TabDatos.Controls.Add(Me.btnSalir)
        Me.TabDatos.Controls.Add(Me.txtcliente)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.txtruc)
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.ForeColor = System.Drawing.Color.Maroon
        Me.btnCerrar.Location = New System.Drawing.Point(8, 351)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(72, 26)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.Text = "&Salir"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'lbNroRegistro
        '
        Me.lbNroRegistro.AutoSize = True
        Me.lbNroRegistro.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistro.Location = New System.Drawing.Point(669, 404)
        Me.lbNroRegistro.Name = "lbNroRegistro"
        Me.lbNroRegistro.Size = New System.Drawing.Size(14, 13)
        Me.lbNroRegistro.TabIndex = 73
        Me.lbNroRegistro.Text = "0"
        '
        'lbNroRegistros
        '
        Me.lbNroRegistros.AutoSize = True
        Me.lbNroRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lbNroRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroRegistros.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbNroRegistros.Location = New System.Drawing.Point(634, 382)
        Me.lbNroRegistros.Name = "lbNroRegistros"
        Me.lbNroRegistros.Size = New System.Drawing.Size(58, 13)
        Me.lbNroRegistros.TabIndex = 74
        Me.lbNroRegistros.Text = "Nro Reg."
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.ForeColor = System.Drawing.Color.Maroon
        Me.btnNuevo.Location = New System.Drawing.Point(616, 94)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 26)
        Me.btnNuevo.TabIndex = 72
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'grpbotones
        '
        Me.grpbotones.BackColor = System.Drawing.Color.Transparent
        Me.grpbotones.Controls.Add(Me.btn_modificar)
        Me.grpbotones.Controls.Add(Me.btnCerrar)
        Me.grpbotones.Controls.Add(Me.btnVerData)
        Me.grpbotones.Controls.Add(Me.btnEmisionfe)
        Me.grpbotones.Controls.Add(Me.btnImprimirComprobante)
        Me.grpbotones.Controls.Add(Me.btnImprimir)
        Me.grpbotones.Location = New System.Drawing.Point(610, 72)
        Me.grpbotones.Name = "grpbotones"
        Me.grpbotones.Size = New System.Drawing.Size(86, 383)
        Me.grpbotones.TabIndex = 75
        Me.grpbotones.TabStop = False
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btn_modificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_modificar.ForeColor = System.Drawing.Color.Maroon
        Me.btn_modificar.Location = New System.Drawing.Point(6, 54)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(72, 26)
        Me.btn_modificar.TabIndex = 57
        Me.btn_modificar.Text = "&Editar"
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'btnVerData
        '
        Me.btnVerData.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnVerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerData.ForeColor = System.Drawing.Color.Maroon
        Me.btnVerData.Location = New System.Drawing.Point(7, 263)
        Me.btnVerData.Name = "btnVerData"
        Me.btnVerData.Size = New System.Drawing.Size(72, 26)
        Me.btnVerData.TabIndex = 55
        Me.btnVerData.Text = "&Ver Data"
        Me.btnVerData.UseVisualStyleBackColor = False
        Me.btnVerData.Visible = False
        '
        'btnEmisionfe
        '
        Me.btnEmisionfe.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnEmisionfe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEmisionfe.ForeColor = System.Drawing.Color.Maroon
        Me.btnEmisionfe.Location = New System.Drawing.Point(6, 119)
        Me.btnEmisionfe.Name = "btnEmisionfe"
        Me.btnEmisionfe.Size = New System.Drawing.Size(72, 26)
        Me.btnEmisionfe.TabIndex = 56
        Me.btnEmisionfe.Text = "F.E."
        Me.btnEmisionfe.UseVisualStyleBackColor = False
        '
        'btnImprimirComprobante
        '
        Me.btnImprimirComprobante.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnImprimirComprobante.Enabled = False
        Me.btnImprimirComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirComprobante.ForeColor = System.Drawing.Color.Maroon
        Me.btnImprimirComprobante.Location = New System.Drawing.Point(3, 196)
        Me.btnImprimirComprobante.Name = "btnImprimirComprobante"
        Me.btnImprimirComprobante.Size = New System.Drawing.Size(81, 43)
        Me.btnImprimirComprobante.TabIndex = 56
        Me.btnImprimirComprobante.Text = "Imprimir Comprobante"
        Me.btnImprimirComprobante.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.ForeColor = System.Drawing.Color.Maroon
        Me.btnImprimir.Location = New System.Drawing.Point(6, 87)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(72, 26)
        Me.btnImprimir.TabIndex = 56
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'dGVControl_otrafactura
        '
        Me.dGVControl_otrafactura.BackgroundColor = System.Drawing.Color.White
        Me.dGVControl_otrafactura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dGVControl_otrafactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGVControl_otrafactura.ContextMenuStrip = Me.CMS_estado
        Me.dGVControl_otrafactura.GridColor = System.Drawing.SystemColors.Info
        Me.dGVControl_otrafactura.Location = New System.Drawing.Point(6, 78)
        Me.dGVControl_otrafactura.MultiSelect = False
        Me.dGVControl_otrafactura.Name = "dGVControl_otrafactura"
        Me.dGVControl_otrafactura.ReadOnly = True
        Me.dGVControl_otrafactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGVControl_otrafactura.Size = New System.Drawing.Size(598, 376)
        Me.dGVControl_otrafactura.TabIndex = 71
        Me.dGVControl_otrafactura.VirtualMode = True
        '
        'CMS_estado
        '
        Me.CMS_estado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem})
        Me.CMS_estado.Name = "CMS_estado"
        Me.CMS_estado.Size = New System.Drawing.Size(110, 26)
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Maroon
        Me.Label24.Location = New System.Drawing.Point(380, 20)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 13)
        Me.Label24.TabIndex = 70
        Me.Label24.Text = "Usuario"
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(107, 42)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(90, 20)
        Me.dtFechaFin.TabIndex = 1
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(107, 16)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(90, 20)
        Me.dtFechaInicio.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(550, 41)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 22)
        Me.btnBuscar.TabIndex = 66
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Maroon
        Me.Label20.Location = New System.Drawing.Point(338, 45)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 65
        Me.Label20.Text = "Nro. FAC/BOL:"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.Location = New System.Drawing.Point(18, 46)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 64
        Me.Label21.Text = "Fecha Fin"
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.ForeColor = System.Drawing.Color.Maroon
        Me.Label31.Location = New System.Drawing.Point(18, 20)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 13)
        Me.Label31.TabIndex = 63
        Me.Label31.Text = "Fecha Inicio"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.cboTipoComprobante)
        Me.GroupBox5.Controls.Add(Me.txtNroSerieDoc)
        Me.GroupBox5.Controls.Add(Me.CMBUSUARIOS)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(690, 73)
        Me.GroupBox5.TabIndex = 76
        Me.GroupBox5.TabStop = False
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"FACTURA", "BOLETA"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(235, 40)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(97, 21)
        Me.cboTipoComprobante.TabIndex = 66
        '
        'txtNroSerieDoc
        '
        Me.txtNroSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroSerieDoc.Location = New System.Drawing.Point(423, 42)
        Me.txtNroSerieDoc.MaxLength = 15
        Me.txtNroSerieDoc.Name = "txtNroSerieDoc"
        Me.txtNroSerieDoc.Size = New System.Drawing.Size(100, 20)
        Me.txtNroSerieDoc.TabIndex = 1
        '
        'CMBUSUARIOS
        '
        Me.CMBUSUARIOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBUSUARIOS.FormattingEnabled = True
        Me.CMBUSUARIOS.Location = New System.Drawing.Point(423, 16)
        Me.CMBUSUARIOS.Name = "CMBUSUARIOS"
        Me.CMBUSUARIOS.Size = New System.Drawing.Size(254, 21)
        Me.CMBUSUARIOS.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Maroon
        Me.Label19.Location = New System.Drawing.Point(202, 45)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Tipo"
        '
        'txtruc
        '
        Me.txtruc.Location = New System.Drawing.Point(90, 15)
        Me.txtruc.MaxLength = 11
        Me.txtruc.Name = "txtruc"
        Me.txtruc.Size = New System.Drawing.Size(85, 20)
        Me.txtruc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(11, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cliente : "
        '
        'txtcliente
        '
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(178, 15)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(282, 20)
        Me.txtcliente.TabIndex = 2
        '
        'txtserie
        '
        Me.txtserie.Location = New System.Drawing.Point(348, 15)
        Me.txtserie.MaxLength = 3
        Me.txtserie.Name = "txtserie"
        Me.txtserie.Size = New System.Drawing.Size(49, 20)
        Me.txtserie.TabIndex = 3
        '
        'txtnro_factura
        '
        Me.txtnro_factura.Location = New System.Drawing.Point(403, 15)
        Me.txtnro_factura.MaxLength = 7
        Me.txtnro_factura.Name = "txtnro_factura"
        Me.txtnro_factura.Size = New System.Drawing.Size(88, 20)
        Me.txtnro_factura.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(311, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nro.:"
        '
        'dtpfecha_emision
        '
        Me.dtpfecha_emision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha_emision.Location = New System.Drawing.Point(602, 17)
        Me.dtpfecha_emision.Name = "dtpfecha_emision"
        Me.dtpfecha_emision.Size = New System.Drawing.Size(85, 20)
        Me.dtpfecha_emision.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(517, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fec Emisión : "
        '
        'cmbformapago
        '
        Me.cmbformapago.Enabled = False
        Me.cmbformapago.FormattingEnabled = True
        Me.cmbformapago.Location = New System.Drawing.Point(103, 40)
        Me.cmbformapago.Name = "cmbformapago"
        Me.cmbformapago.Size = New System.Drawing.Size(172, 21)
        Me.cmbformapago.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(12, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Forma Pago :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(11, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Referencia : "
        '
        'txtreferencia
        '
        Me.txtreferencia.Location = New System.Drawing.Point(103, 70)
        Me.txtreferencia.Name = "txtreferencia"
        Me.txtreferencia.Size = New System.Drawing.Size(172, 20)
        Me.txtreferencia.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(102, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Glosa : "
        '
        'btngrabar
        '
        Me.btngrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btngrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngrabar.ForeColor = System.Drawing.Color.Maroon
        Me.btngrabar.Location = New System.Drawing.Point(482, 337)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(84, 34)
        Me.btngrabar.TabIndex = 103
        Me.btngrabar.Text = "Grabar (F5)"
        Me.btngrabar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Maroon
        Me.btnSalir.Location = New System.Drawing.Point(589, 337)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(84, 34)
        Me.btnSalir.TabIndex = 104
        Me.btnSalir.Text = "Salir (Esc)"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Location = New System.Drawing.Point(95, 208)
        Me.txtsubtotal.MaxLength = 10
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtsubtotal.TabIndex = 105
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtimpuesto
        '
        Me.txtimpuesto.BackColor = System.Drawing.SystemColors.Info
        Me.txtimpuesto.Location = New System.Drawing.Point(297, 208)
        Me.txtimpuesto.MaxLength = 10
        Me.txtimpuesto.Name = "txtimpuesto"
        Me.txtimpuesto.ReadOnly = True
        Me.txtimpuesto.Size = New System.Drawing.Size(100, 20)
        Me.txtimpuesto.TabIndex = 106
        Me.txtimpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.Location = New System.Drawing.Point(505, 208)
        Me.txttotal.MaxLength = 10
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(100, 20)
        Me.txttotal.TabIndex = 107
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(454, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Total :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(225, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "Impuesto :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(30, 214)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Sub Total :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(3, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Tipo Comprobante: "
        '
        'cmbtipofactura
        '
        Me.cmbtipofactura.FormattingEnabled = True
        Me.cmbtipofactura.Location = New System.Drawing.Point(103, 13)
        Me.cmbtipofactura.Name = "cmbtipofactura"
        Me.cmbtipofactura.Size = New System.Drawing.Size(172, 21)
        Me.cmbtipofactura.TabIndex = 112
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TXTGLOSA_sub_total)
        Me.GroupBox1.Controls.Add(Me.TXTGLOSA)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtpreciounitario)
        Me.GroupBox1.Controls.Add(Me.txtcantidad)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtigv)
        Me.GroupBox1.Controls.Add(Me.txttipo_cambio)
        Me.GroupBox1.Controls.Add(Me.Labtipo_cambio)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbtipofactura)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txttotal)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Cmbmoneda)
        Me.GroupBox1.Controls.Add(Me.txtimpuesto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTipoAfectacion)
        Me.GroupBox1.Controls.Add(Me.cmbformapago)
        Me.GroupBox1.Controls.Add(Me.dtpfecha_emision)
        Me.GroupBox1.Controls.Add(Me.txtsubtotal)
        Me.GroupBox1.Controls.Add(Me.txtnro_factura)
        Me.GroupBox1.Controls.Add(Me.txtserie)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtreferencia)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(698, 243)
        Me.GroupBox1.TabIndex = 113
        Me.GroupBox1.TabStop = False
        '
        'TXTGLOSA_sub_total
        '
        Me.TXTGLOSA_sub_total.Location = New System.Drawing.Point(510, 124)
        Me.TXTGLOSA_sub_total.MaxLength = 1000
        Me.TXTGLOSA_sub_total.Name = "TXTGLOSA_sub_total"
        Me.TXTGLOSA_sub_total.Size = New System.Drawing.Size(93, 78)
        Me.TXTGLOSA_sub_total.TabIndex = 123
        Me.TXTGLOSA_sub_total.Text = ""
        '
        'TXTGLOSA
        '
        Me.TXTGLOSA.Location = New System.Drawing.Point(95, 124)
        Me.TXTGLOSA.MaxLength = 1000
        Me.TXTGLOSA.Name = "TXTGLOSA"
        Me.TXTGLOSA.Size = New System.Drawing.Size(406, 78)
        Me.TXTGLOSA.TabIndex = 123
        Me.TXTGLOSA.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(613, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 13)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "Precio Unitario : "
        '
        'txtpreciounitario
        '
        Me.txtpreciounitario.Location = New System.Drawing.Point(609, 124)
        Me.txtpreciounitario.MaxLength = 10
        Me.txtpreciounitario.Name = "txtpreciounitario"
        Me.txtpreciounitario.Size = New System.Drawing.Size(83, 20)
        Me.txtpreciounitario.TabIndex = 124
        Me.txtpreciounitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcantidad
        '
        Me.txtcantidad.Location = New System.Drawing.Point(6, 124)
        Me.txtcantidad.MaxLength = 10
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(83, 20)
        Me.txtcantidad.TabIndex = 123
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(6, 108)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 13)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Cantidad : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(595, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Igv : "
        '
        'txtigv
        '
        Me.txtigv.Enabled = False
        Me.txtigv.Location = New System.Drawing.Point(630, 71)
        Me.txtigv.MaxLength = 8
        Me.txtigv.Name = "txtigv"
        Me.txtigv.Size = New System.Drawing.Size(52, 20)
        Me.txtigv.TabIndex = 116
        '
        'txttipo_cambio
        '
        Me.txttipo_cambio.Location = New System.Drawing.Point(584, 46)
        Me.txttipo_cambio.MaxLength = 10
        Me.txttipo_cambio.Name = "txttipo_cambio"
        Me.txttipo_cambio.Size = New System.Drawing.Size(100, 20)
        Me.txttipo_cambio.TabIndex = 114
        Me.txttipo_cambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Labtipo_cambio
        '
        Me.Labtipo_cambio.AutoSize = True
        Me.Labtipo_cambio.BackColor = System.Drawing.Color.Transparent
        Me.Labtipo_cambio.ForeColor = System.Drawing.Color.Maroon
        Me.Labtipo_cambio.Location = New System.Drawing.Point(507, 46)
        Me.Labtipo_cambio.Name = "Labtipo_cambio"
        Me.Labtipo_cambio.Size = New System.Drawing.Size(72, 13)
        Me.Labtipo_cambio.TabIndex = 115
        Me.Labtipo_cambio.Text = "Tipo Cambio :"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Maroon
        Me.Label22.Location = New System.Drawing.Point(282, 75)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 28)
        Me.Label22.TabIndex = 114
        Me.Label22.Text = "Tipo Afectación Igv"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(289, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "Moneda :"
        '
        'Cmbmoneda
        '
        Me.Cmbmoneda.FormattingEnabled = True
        Me.Cmbmoneda.Location = New System.Drawing.Point(348, 45)
        Me.Cmbmoneda.Name = "Cmbmoneda"
        Me.Cmbmoneda.Size = New System.Drawing.Size(153, 21)
        Me.Cmbmoneda.TabIndex = 114
        '
        'cboTipoAfectacion
        '
        Me.cboTipoAfectacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAfectacion.FormattingEnabled = True
        Me.cboTipoAfectacion.Location = New System.Drawing.Point(368, 71)
        Me.cboTipoAfectacion.Name = "cboTipoAfectacion"
        Me.cboTipoAfectacion.Size = New System.Drawing.Size(133, 21)
        Me.cboTipoAfectacion.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(680, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "%"
        '
        'txtidfactura_otra
        '
        Me.txtidfactura_otra.BackColor = System.Drawing.SystemColors.Info
        Me.txtidfactura_otra.Location = New System.Drawing.Point(5, 351)
        Me.txtidfactura_otra.Name = "txtidfactura_otra"
        Me.txtidfactura_otra.Size = New System.Drawing.Size(100, 20)
        Me.txtidfactura_otra.TabIndex = 114
        Me.txtidfactura_otra.Visible = False
        '
        'txtidpersona
        '
        Me.txtidpersona.BackColor = System.Drawing.SystemColors.Info
        Me.txtidpersona.Location = New System.Drawing.Point(111, 351)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(100, 20)
        Me.txtidpersona.TabIndex = 115
        Me.txtidpersona.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(14, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "Dirección : "
        '
        'txtdireccion
        '
        Me.txtdireccion.Enabled = False
        Me.txtdireccion.Location = New System.Drawing.Point(48, 403)
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(597, 20)
        Me.txtdireccion.TabIndex = 116
        Me.txtdireccion.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(468, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Rubro : "
        '
        'cmbrubro
        '
        Me.cmbrubro.Enabled = False
        Me.cmbrubro.FormattingEnabled = True
        Me.cmbrubro.Location = New System.Drawing.Point(512, 16)
        Me.cmbrubro.Name = "cmbrubro"
        Me.cmbrubro.Size = New System.Drawing.Size(175, 21)
        Me.cmbrubro.TabIndex = 118
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmbDireccion)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 64)
        Me.GroupBox2.TabIndex = 119
        Me.GroupBox2.TabStop = False
        '
        'cmbDireccion
        '
        Me.cmbDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDireccion.FormattingEnabled = True
        Me.cmbDireccion.Location = New System.Drawing.Point(88, 35)
        Me.cmbDireccion.Name = "cmbDireccion"
        Me.cmbDireccion.Size = New System.Drawing.Size(596, 21)
        Me.cmbDireccion.TabIndex = 0
        '
        'txtiddireccion_contacto
        '
        Me.txtiddireccion_contacto.BackColor = System.Drawing.SystemColors.Info
        Me.txtiddireccion_contacto.Location = New System.Drawing.Point(217, 351)
        Me.txtiddireccion_contacto.Name = "txtiddireccion_contacto"
        Me.txtiddireccion_contacto.Size = New System.Drawing.Size(100, 20)
        Me.txtiddireccion_contacto.TabIndex = 120
        Me.txtiddireccion_contacto.Visible = False
        '
        'txtrepresentante_legal
        '
        Me.txtrepresentante_legal.BackColor = System.Drawing.SystemColors.Info
        Me.txtrepresentante_legal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrepresentante_legal.Location = New System.Drawing.Point(5, 377)
        Me.txtrepresentante_legal.MaxLength = 100
        Me.txtrepresentante_legal.Name = "txtrepresentante_legal"
        Me.txtrepresentante_legal.Size = New System.Drawing.Size(311, 20)
        Me.txtrepresentante_legal.TabIndex = 121
        Me.txtrepresentante_legal.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(3, 327)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(161, 13)
        Me.Label18.TabIndex = 122
        Me.Label18.Text = "F6 - Mantenimiento de Clientes : "
        Me.Label18.Visible = False
        '
        'btnClientes
        '
        Me.btnClientes.BackColor = System.Drawing.Color.Transparent
        Me.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClientes.ForeColor = System.Drawing.Color.Maroon
        Me.btnClientes.Location = New System.Drawing.Point(6, 322)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(169, 23)
        Me.btnClientes.TabIndex = 123
        Me.btnClientes.Text = "(F6) Mantenimiento de Clientes"
        Me.btnClientes.UseVisualStyleBackColor = False
        '
        'frmfacturaotro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(707, 490)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmfacturaotro"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.grpbotones.ResumeLayout(False)
        CType(Me.dGVControl_otrafactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_estado.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbNroRegistro As System.Windows.Forms.Label
    Friend WithEvents lbNroRegistros As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents grpbotones As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnVerData As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents dGVControl_otrafactura As System.Windows.Forms.DataGridView
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtserie As System.Windows.Forms.TextBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtruc As System.Windows.Forms.TextBox
    Friend WithEvents dtpfecha_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnro_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbformapago As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtreferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents txtimpuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents cmbtipofactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cmbmoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txttipo_cambio As System.Windows.Forms.TextBox
    Friend WithEvents Labtipo_cambio As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents txtidfactura_otra As System.Windows.Forms.TextBox
    Friend WithEvents txtdireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbrubro As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtigv As System.Windows.Forms.TextBox
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtpreciounitario As System.Windows.Forms.TextBox
    Friend WithEvents txtiddireccion_contacto As System.Windows.Forms.TextBox
    Friend WithEvents txtrepresentante_legal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents CMS_estado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimirComprobante As System.Windows.Forms.Button
    Friend WithEvents CMBUSUARIOS As System.Windows.Forms.ComboBox
    Friend WithEvents txtNroSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents TXTGLOSA As System.Windows.Forms.RichTextBox
    Friend WithEvents TXTGLOSA_sub_total As System.Windows.Forms.RichTextBox
    Friend WithEvents cmbDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents btnClientes As System.Windows.Forms.Button
    Friend WithEvents btnEmisionfe As System.Windows.Forms.Button
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAfectacion As System.Windows.Forms.ComboBox

End Class
