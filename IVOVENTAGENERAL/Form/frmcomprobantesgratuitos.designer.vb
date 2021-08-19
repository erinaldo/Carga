<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcomprobantesgratuitos
    Inherits INTEGRACION.FrmPlantillaFacturacion

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
        Me.DTPFECHAFINALFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.DTPFECHAINICIOFACTURA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.grbbox_parametro = New System.Windows.Forms.GroupBox()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.txtmemo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbcondicion = New System.Windows.Forms.ComboBox()
        Me.RB_Carga = New System.Windows.Forms.RadioButton()
        Me.Rb_pasajes = New System.Windows.Forms.RadioButton()
        Me.DGV_comprobante = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.grbbox_parametro.SuspendLayout()
        CType(Me.DGV_comprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.DGV_comprobante)
        Me.Panel.Size = New System.Drawing.Size(705, 349)
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.DTPFECHAFINALFACTURA)
        Me.TabLista.Controls.Add(Me.DTPFECHAINICIOFACTURA)
        Me.TabLista.Controls.Add(Me.Label12)
        Me.TabLista.Controls.Add(Me.Label13)
        Me.TabLista.Controls.Add(Me.grbbox_parametro)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.grbbox_parametro, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label13, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DTPFECHAINICIOFACTURA, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DTPFECHAFINALFACTURA, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        '
        'DTPFECHAFINALFACTURA
        '
        Me.DTPFECHAFINALFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAFINALFACTURA.Location = New System.Drawing.Point(259, 18)
        Me.DTPFECHAFINALFACTURA.Name = "DTPFECHAFINALFACTURA"
        Me.DTPFECHAFINALFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAFINALFACTURA.TabIndex = 2
        Me.DTPFECHAFINALFACTURA.Value = New Date(2007, 3, 3, 0, 0, 0, 0)
        '
        'DTPFECHAINICIOFACTURA
        '
        Me.DTPFECHAINICIOFACTURA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHAINICIOFACTURA.Location = New System.Drawing.Point(103, 18)
        Me.DTPFECHAINICIOFACTURA.Name = "DTPFECHAINICIOFACTURA"
        Me.DTPFECHAINICIOFACTURA.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHAINICIOFACTURA.TabIndex = 0
        Me.DTPFECHAINICIOFACTURA.Value = New Date(2007, 3, 3, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(193, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(26, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Fecha Inicio :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(354, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Agencia :"
        '
        'cmbAgencia
        '
        Me.cmbAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(409, 12)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(131, 21)
        Me.cmbAgencia.TabIndex = 3
        '
        'grbbox_parametro
        '
        Me.grbbox_parametro.BackColor = System.Drawing.Color.Transparent
        Me.grbbox_parametro.Controls.Add(Me.lblRegistros)
        Me.grbbox_parametro.Controls.Add(Me.txtmemo)
        Me.grbbox_parametro.Controls.Add(Me.Label2)
        Me.grbbox_parametro.Controls.Add(Me.Button3)
        Me.grbbox_parametro.Controls.Add(Me.Label1)
        Me.grbbox_parametro.Controls.Add(Me.cmbcondicion)
        Me.grbbox_parametro.Controls.Add(Me.RB_Carga)
        Me.grbbox_parametro.Controls.Add(Me.Rb_pasajes)
        Me.grbbox_parametro.Controls.Add(Me.cmbAgencia)
        Me.grbbox_parametro.Controls.Add(Me.Label6)
        Me.grbbox_parametro.Location = New System.Drawing.Point(15, 6)
        Me.grbbox_parametro.Name = "grbbox_parametro"
        Me.grbbox_parametro.Size = New System.Drawing.Size(705, 66)
        Me.grbbox_parametro.TabIndex = 83
        Me.grbbox_parametro.TabStop = False
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(253, 43)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 13)
        Me.lblRegistros.TabIndex = 91
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtmemo
        '
        Me.txtmemo.AcceptsReturn = True
        Me.txtmemo.AcceptsTab = True
        Me.txtmemo.CharacterCasing = Global.INTEGRACION.My.MySettings.Default.mayuscula
        Me.txtmemo.Location = New System.Drawing.Point(409, 38)
        Me.txtmemo.MaxLength = 30
        Me.txtmemo.Name = "txtmemo"
        Me.txtmemo.Size = New System.Drawing.Size(131, 20)
        Me.txtmemo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(371, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Por : "
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(569, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 84
        Me.Button3.Text = "Filtrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(11, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Condición :"
        '
        'cmbcondicion
        '
        Me.cmbcondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcondicion.FormattingEnabled = True
        Me.cmbcondicion.Location = New System.Drawing.Point(88, 38)
        Me.cmbcondicion.Name = "cmbcondicion"
        Me.cmbcondicion.Size = New System.Drawing.Size(159, 21)
        Me.cmbcondicion.TabIndex = 4
        '
        'RB_Carga
        '
        Me.RB_Carga.AutoSize = True
        Me.RB_Carga.Location = New System.Drawing.Point(646, 41)
        Me.RB_Carga.Name = "RB_Carga"
        Me.RB_Carga.Size = New System.Drawing.Size(53, 17)
        Me.RB_Carga.TabIndex = 83
        Me.RB_Carga.TabStop = True
        Me.RB_Carga.Text = "Carga"
        Me.RB_Carga.UseVisualStyleBackColor = True
        '
        'Rb_pasajes
        '
        Me.Rb_pasajes.AutoSize = True
        Me.Rb_pasajes.Location = New System.Drawing.Point(569, 41)
        Me.Rb_pasajes.Name = "Rb_pasajes"
        Me.Rb_pasajes.Size = New System.Drawing.Size(62, 17)
        Me.Rb_pasajes.TabIndex = 82
        Me.Rb_pasajes.TabStop = True
        Me.Rb_pasajes.Text = "Pasajes"
        Me.Rb_pasajes.UseVisualStyleBackColor = True
        '
        'DGV_comprobante
        '
        Me.DGV_comprobante.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DGV_comprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_comprobante.Location = New System.Drawing.Point(0, 0)
        Me.DGV_comprobante.Name = "DGV_comprobante"
        Me.DGV_comprobante.Size = New System.Drawing.Size(705, 347)
        Me.DGV_comprobante.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 430)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 84
        '
        'frmcomprobantesgratuitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "frmcomprobantesgratuitos"
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
        Me.Panel.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.grbbox_parametro.ResumeLayout(False)
        Me.grbbox_parametro.PerformLayout()
        CType(Me.DGV_comprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DTPFECHAFINALFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHAINICIOFACTURA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents grbbox_parametro As System.Windows.Forms.GroupBox
    Friend WithEvents RB_Carga As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_pasajes As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbcondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DGV_comprobante As System.Windows.Forms.DataGridView
    Friend WithEvents txtmemo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

    Friend WithEvents lblRegistros As System.Windows.Forms.Label

End Class
