<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoCargoFacturacion
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
        Me.components = New System.ComponentModel.Container
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtidpersona = New System.Windows.Forms.TextBox
        Me.RBTodos = New System.Windows.Forms.RadioButton
        Me.RBRecep = New System.Windows.Forms.RadioButton
        Me.RBSinRecep = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSinRango = New System.Windows.Forms.CheckBox
        Me.dtpfecha_final = New System.Windows.Forms.DateTimePicker
        Me.dtpfecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SeleccionarNingunoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InvertirSeleccionarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dtpfecha_cargo = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txttotal_costo = New System.Windows.Forms.TextBox
        Me.txtsub_total = New System.Windows.Forms.TextBox
        Me.txtmonto_impuesto = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnagre_modi = New System.Windows.Forms.Button
        Me.btnquitar = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.btnquitar)
        Me.TabLista.Controls.Add(Me.btnagre_modi)
        Me.TabLista.Controls.Add(Me.txttotal_costo)
        Me.TabLista.Controls.Add(Me.txtsub_total)
        Me.TabLista.Controls.Add(Me.txtmonto_impuesto)
        Me.TabLista.Controls.Add(Me.Label9)
        Me.TabLista.Controls.Add(Me.Label10)
        Me.TabLista.Controls.Add(Me.Label14)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.dtpfecha_cargo)
        Me.TabLista.Controls.Add(Me.GroupBox1)
        Me.TabLista.Controls.Add(Me.RBSinRecep)
        Me.TabLista.Controls.Add(Me.RBRecep)
        Me.TabLista.Controls.Add(Me.RBTodos)
        Me.TabLista.Controls.Add(Me.Button1)
        Me.TabLista.Controls.Add(Me.txtCodigoCliente)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.txtidpersona)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtidpersona, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtCodigoCliente, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Button1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBTodos, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBRecep, 0)
        Me.TabLista.Controls.SetChildIndex(Me.RBSinRecep, 0)
        Me.TabLista.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.dtpfecha_cargo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label14, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label10, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label9, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtmonto_impuesto, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txtsub_total, 0)
        Me.TabLista.Controls.SetChildIndex(Me.txttotal_costo, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnagre_modi, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnquitar, 0)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.DGV1)
        Me.Panel.Location = New System.Drawing.Point(2, 133)
        Me.Panel.Size = New System.Drawing.Size(728, 287)
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(438, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 23)
        Me.Button1.TabIndex = 68
        Me.Button1.Text = "Filtrar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCliente.Location = New System.Drawing.Point(6, 26)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoCliente.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Codigo Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(103, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Cliente :"
        '
        'txtidpersona
        '
        Me.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidpersona.Location = New System.Drawing.Point(106, 26)
        Me.txtidpersona.Name = "txtidpersona"
        Me.txtidpersona.Size = New System.Drawing.Size(312, 20)
        Me.txtidpersona.TabIndex = 63
        '
        'RBTodos
        '
        Me.RBTodos.AutoSize = True
        Me.RBTodos.BackColor = System.Drawing.Color.Transparent
        Me.RBTodos.Location = New System.Drawing.Point(6, 52)
        Me.RBTodos.Name = "RBTodos"
        Me.RBTodos.Size = New System.Drawing.Size(55, 17)
        Me.RBTodos.TabIndex = 71
        Me.RBTodos.Text = "Todos"
        Me.RBTodos.UseVisualStyleBackColor = False
        '
        'RBRecep
        '
        Me.RBRecep.AutoSize = True
        Me.RBRecep.BackColor = System.Drawing.Color.Transparent
        Me.RBRecep.Location = New System.Drawing.Point(6, 75)
        Me.RBRecep.Name = "RBRecep"
        Me.RBRecep.Size = New System.Drawing.Size(100, 17)
        Me.RBRecep.TabIndex = 72
        Me.RBRecep.Text = "Recepcionados"
        Me.RBRecep.UseVisualStyleBackColor = False
        '
        'RBSinRecep
        '
        Me.RBSinRecep.AutoSize = True
        Me.RBSinRecep.BackColor = System.Drawing.Color.Transparent
        Me.RBSinRecep.Checked = True
        Me.RBSinRecep.Location = New System.Drawing.Point(6, 98)
        Me.RBSinRecep.Name = "RBSinRecep"
        Me.RBSinRecep.Size = New System.Drawing.Size(104, 17)
        Me.RBSinRecep.TabIndex = 73
        Me.RBSinRecep.TabStop = True
        Me.RBSinRecep.Text = "Sin Recepcionar"
        Me.RBSinRecep.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkSinRango)
        Me.GroupBox1.Controls.Add(Me.dtpfecha_final)
        Me.GroupBox1.Controls.Add(Me.dtpfecha_inicio)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(116, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 63)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'chkSinRango
        '
        Me.chkSinRango.AutoSize = True
        Me.chkSinRango.Location = New System.Drawing.Point(190, 35)
        Me.chkSinRango.Name = "chkSinRango"
        Me.chkSinRango.Size = New System.Drawing.Size(126, 17)
        Me.chkSinRango.TabIndex = 75
        Me.chkSinRango.Text = "Sin Rango de fechas"
        Me.chkSinRango.UseVisualStyleBackColor = True
        '
        'dtpfecha_final
        '
        Me.dtpfecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha_final.Location = New System.Drawing.Point(99, 34)
        Me.dtpfecha_final.Name = "dtpfecha_final"
        Me.dtpfecha_final.Size = New System.Drawing.Size(84, 20)
        Me.dtpfecha_final.TabIndex = 74
        '
        'dtpfecha_inicio
        '
        Me.dtpfecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha_inicio.Location = New System.Drawing.Point(9, 34)
        Me.dtpfecha_inicio.Name = "dtpfecha_inicio"
        Me.dtpfecha_inicio.Size = New System.Drawing.Size(84, 20)
        Me.dtpfecha_inicio.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(96, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Fecha Fin :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Fecha Inicio :"
        '
        'DGV1
        '
        Me.DGV1.BackgroundColor = System.Drawing.Color.White
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV1.Location = New System.Drawing.Point(0, 0)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.Size = New System.Drawing.Size(728, 287)
        Me.DGV1.TabIndex = 53
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarTodoToolStripMenuItem, Me.SeleccionarNingunoToolStripMenuItem, Me.InvertirSeleccionarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 70)
        '
        'SeleccionarTodoToolStripMenuItem
        '
        Me.SeleccionarTodoToolStripMenuItem.Name = "SeleccionarTodoToolStripMenuItem"
        Me.SeleccionarTodoToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SeleccionarTodoToolStripMenuItem.Text = "Seleccionar Todo"
        '
        'SeleccionarNingunoToolStripMenuItem
        '
        Me.SeleccionarNingunoToolStripMenuItem.Name = "SeleccionarNingunoToolStripMenuItem"
        Me.SeleccionarNingunoToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SeleccionarNingunoToolStripMenuItem.Text = "Seleccionar Ninguno"
        '
        'InvertirSeleccionarToolStripMenuItem
        '
        Me.InvertirSeleccionarToolStripMenuItem.Name = "InvertirSeleccionarToolStripMenuItem"
        Me.InvertirSeleccionarToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.InvertirSeleccionarToolStripMenuItem.Text = "Invertir Seleccionar"
        '
        'dtpfecha_cargo
        '
        Me.dtpfecha_cargo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha_cargo.Location = New System.Drawing.Point(642, 24)
        Me.dtpfecha_cargo.Name = "dtpfecha_cargo"
        Me.dtpfecha_cargo.Size = New System.Drawing.Size(84, 20)
        Me.dtpfecha_cargo.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(639, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Fecha Cargo :"
        '
        'txttotal_costo
        '
        Me.txttotal_costo.Location = New System.Drawing.Point(630, 436)
        Me.txttotal_costo.Name = "txttotal_costo"
        Me.txttotal_costo.ReadOnly = True
        Me.txttotal_costo.Size = New System.Drawing.Size(100, 20)
        Me.txttotal_costo.TabIndex = 79
        Me.txttotal_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsub_total
        '
        Me.txtsub_total.Location = New System.Drawing.Point(421, 436)
        Me.txtsub_total.Name = "txtsub_total"
        Me.txtsub_total.ReadOnly = True
        Me.txtsub_total.Size = New System.Drawing.Size(100, 20)
        Me.txtsub_total.TabIndex = 78
        Me.txtsub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmonto_impuesto
        '
        Me.txtmonto_impuesto.Location = New System.Drawing.Point(524, 436)
        Me.txtmonto_impuesto.Name = "txtmonto_impuesto"
        Me.txtmonto_impuesto.ReadOnly = True
        Me.txtmonto_impuesto.Size = New System.Drawing.Size(100, 20)
        Me.txtmonto_impuesto.TabIndex = 77
        Me.txtmonto_impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(418, 423)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 13)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Sub Total"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(521, 423)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "Monto Impuesto"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(627, 423)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "Total Costo"
        '
        'btnagre_modi
        '
        Me.btnagre_modi.BackColor = System.Drawing.Color.Transparent
        Me.btnagre_modi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnagre_modi.Location = New System.Drawing.Point(524, 92)
        Me.btnagre_modi.Name = "btnagre_modi"
        Me.btnagre_modi.Size = New System.Drawing.Size(100, 23)
        Me.btnagre_modi.TabIndex = 83
        Me.btnagre_modi.Text = "Agregar cargos"
        Me.btnagre_modi.UseVisualStyleBackColor = False
        '
        'btnquitar
        '
        Me.btnquitar.BackColor = System.Drawing.Color.Transparent
        Me.btnquitar.Enabled = False
        Me.btnquitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnquitar.Location = New System.Drawing.Point(630, 92)
        Me.btnquitar.Name = "btnquitar"
        Me.btnquitar.Size = New System.Drawing.Size(100, 23)
        Me.btnquitar.TabIndex = 83
        Me.btnquitar.Text = "Quitar cargos"
        Me.btnquitar.UseVisualStyleBackColor = False
        '
        'FrmIngresoCargoFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 616)
        Me.Name = "FrmIngresoCargoFacturacion"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.Panel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtidpersona As System.Windows.Forms.TextBox
    Friend WithEvents RBSinRecep As System.Windows.Forms.RadioButton
    Friend WithEvents RBRecep As System.Windows.Forms.RadioButton
    Friend WithEvents RBTodos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSinRango As System.Windows.Forms.CheckBox
    Friend WithEvents dtpfecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeleccionarNingunoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertirSeleccionarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpfecha_cargo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txttotal_costo As System.Windows.Forms.TextBox
    Friend WithEvents txtsub_total As System.Windows.Forms.TextBox
    Friend WithEvents txtmonto_impuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnagre_modi As System.Windows.Forms.Button
    Friend WithEvents btnquitar As System.Windows.Forms.Button

End Class
