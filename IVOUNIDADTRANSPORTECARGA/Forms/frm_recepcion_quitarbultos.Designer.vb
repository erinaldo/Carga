<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_recepcion_quitarbultos
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
        Me.txt_guia_transportista = New System.Windows.Forms.TextBox()
        Me.txt_destino = New System.Windows.Forms.TextBox()
        Me.txt_origen = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fec_salida = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_agencia_origen = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.txt_dcto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_idunidad_transporte = New System.Windows.Forms.TextBox()
        Me.txt_idunidad_destino = New System.Windows.Forms.TextBox()
        Me.txt_estado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DGV_gt_det = New System.Windows.Forms.DataGridView()
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
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV_gt_det, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer2.Panel1Collapsed = True
        Me.SplitContainer2.Panel1MinSize = 0
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Size = New System.Drawing.Size(770, 520)
        '
        'TabMante
        '
        Me.TabMante.Size = New System.Drawing.Size(768, 515)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.DGV_gt_det)
        Me.TabLista.Controls.Add(Me.Label5)
        Me.TabLista.Controls.Add(Me.txt_agencia_origen)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.dtp_fec_salida)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.txt_origen)
        Me.TabLista.Controls.Add(Me.txt_destino)
        Me.TabLista.Controls.Add(Me.txt_guia_transportista)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Size = New System.Drawing.Size(760, 486)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_guia_transportista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_destino, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_origen, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.dtp_fec_salida, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txt_agencia_origen, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label5, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DGV_gt_det, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Size = New System.Drawing.Size(760, 486)
        '
        'DataGridLista
        '
        Me.DataGridLista.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridLista.Location = New System.Drawing.Point(697, 439)
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(733, 4)
        Me.TxtBusca.Size = New System.Drawing.Size(19, 20)
        Me.TxtBusca.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(760, 486)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(760, 486)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        '
        'txt_guia_transportista
        '
        Me.txt_guia_transportista.Location = New System.Drawing.Point(143, 8)
        Me.txt_guia_transportista.MaxLength = 15
        Me.txt_guia_transportista.Name = "txt_guia_transportista"
        Me.txt_guia_transportista.Size = New System.Drawing.Size(112, 20)
        Me.txt_guia_transportista.TabIndex = 2
        '
        'txt_destino
        '
        Me.txt_destino.BackColor = System.Drawing.SystemColors.Info
        Me.txt_destino.Location = New System.Drawing.Point(595, 8)
        Me.txt_destino.Name = "txt_destino"
        Me.txt_destino.ReadOnly = True
        Me.txt_destino.Size = New System.Drawing.Size(113, 20)
        Me.txt_destino.TabIndex = 3
        '
        'txt_origen
        '
        Me.txt_origen.BackColor = System.Drawing.SystemColors.Info
        Me.txt_origen.Location = New System.Drawing.Point(374, 6)
        Me.txt_origen.Name = "txt_origen"
        Me.txt_origen.ReadOnly = True
        Me.txt_origen.Size = New System.Drawing.Size(113, 20)
        Me.txt_origen.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Guía de Transportista : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(18, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Fecha Salidas : "
        '
        'dtp_fec_salida
        '
        Me.dtp_fec_salida.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtp_fec_salida.CalendarTitleBackColor = System.Drawing.SystemColors.Info
        Me.dtp_fec_salida.CalendarTitleForeColor = System.Drawing.SystemColors.Info
        Me.dtp_fec_salida.CalendarTrailingForeColor = System.Drawing.SystemColors.Info
        Me.dtp_fec_salida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fec_salida.Location = New System.Drawing.Point(143, 36)
        Me.dtp_fec_salida.Name = "dtp_fec_salida"
        Me.dtp_fec_salida.Size = New System.Drawing.Size(112, 20)
        Me.dtp_fec_salida.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(321, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Origen : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(516, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Destino : "
        '
        'txt_agencia_origen
        '
        Me.txt_agencia_origen.BackColor = System.Drawing.SystemColors.Info
        Me.txt_agencia_origen.Location = New System.Drawing.Point(374, 36)
        Me.txt_agencia_origen.Name = "txt_agencia_origen"
        Me.txt_agencia_origen.ReadOnly = True
        Me.txt_agencia_origen.Size = New System.Drawing.Size(113, 20)
        Me.txt_agencia_origen.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(279, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Agencia Origen : "
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cboTipoComprobante)
        Me.GroupBox1.Controls.Add(Me.txt_dcto)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_idunidad_transporte)
        Me.GroupBox1.Controls.Add(Me.txt_idunidad_destino)
        Me.GroupBox1.Controls.Add(Me.txt_estado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(2, -3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(754, 93)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"(TODO)", "FACTURA", "BOLETA"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(141, 64)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(112, 21)
        Me.cboTipoComprobante.TabIndex = 17
        '
        'txt_dcto
        '
        Me.txt_dcto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_dcto.Location = New System.Drawing.Point(373, 65)
        Me.txt_dcto.MaxLength = 13
        Me.txt_dcto.Name = "txt_dcto"
        Me.txt_dcto.Size = New System.Drawing.Size(112, 20)
        Me.txt_dcto.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(295, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Documento : "
        '
        'txt_idunidad_transporte
        '
        Me.txt_idunidad_transporte.BackColor = System.Drawing.SystemColors.Info
        Me.txt_idunidad_transporte.Location = New System.Drawing.Point(634, 11)
        Me.txt_idunidad_transporte.Name = "txt_idunidad_transporte"
        Me.txt_idunidad_transporte.ReadOnly = True
        Me.txt_idunidad_transporte.Size = New System.Drawing.Size(113, 20)
        Me.txt_idunidad_transporte.TabIndex = 16
        Me.txt_idunidad_transporte.Visible = False
        '
        'txt_idunidad_destino
        '
        Me.txt_idunidad_destino.BackColor = System.Drawing.SystemColors.Info
        Me.txt_idunidad_destino.Location = New System.Drawing.Point(649, 36)
        Me.txt_idunidad_destino.Name = "txt_idunidad_destino"
        Me.txt_idunidad_destino.ReadOnly = True
        Me.txt_idunidad_destino.Size = New System.Drawing.Size(113, 20)
        Me.txt_idunidad_destino.TabIndex = 15
        Me.txt_idunidad_destino.Visible = False
        '
        'txt_estado
        '
        Me.txt_estado.BackColor = System.Drawing.SystemColors.Info
        Me.txt_estado.Location = New System.Drawing.Point(593, 36)
        Me.txt_estado.MaxLength = 15
        Me.txt_estado.Name = "txt_estado"
        Me.txt_estado.ReadOnly = True
        Me.txt_estado.Size = New System.Drawing.Size(112, 20)
        Me.txt_estado.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(514, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Estado  : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(16, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Tipo Comprobante"
        '
        'DGV_gt_det
        '
        Me.DGV_gt_det.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGV_gt_det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_gt_det.Location = New System.Drawing.Point(2, 96)
        Me.DGV_gt_det.Name = "DGV_gt_det"
        Me.DGV_gt_det.Size = New System.Drawing.Size(754, 382)
        Me.DGV_gt_det.TabIndex = 14
        '
        'frm_recepcion_quitarbultos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "frm_recepcion_quitarbultos"
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_gt_det, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_origen As System.Windows.Forms.TextBox
    Friend WithEvents txt_destino As System.Windows.Forms.TextBox
    Friend WithEvents txt_guia_transportista As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_fec_salida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV_gt_det As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_agencia_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_estado As System.Windows.Forms.TextBox
    Friend WithEvents txt_idunidad_destino As System.Windows.Forms.TextBox
    Friend WithEvents txt_idunidad_transporte As System.Windows.Forms.TextBox
    Friend WithEvents txt_dcto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
