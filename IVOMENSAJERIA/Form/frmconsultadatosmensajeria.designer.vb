<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconsultadatosmensajeria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmconsultadatosmensajeria))
        Me.txt_documento = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_consulta = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportarExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DTP_fec_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTP_fec_final = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnfiltrar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        CType(Me.dgv_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.btnfiltrar)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.DTP_fec_final)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.DTP_fec_inicio)
        Me.TabLista.Controls.Add(Me.dgv_consulta)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.txt_documento)
        '
        'txt_documento
        '
        Me.txt_documento.Location = New System.Drawing.Point(84, 18)
        Me.txt_documento.MaxLength = 13
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(100, 20)
        Me.txt_documento.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Documento : "
        '
        'dgv_consulta
        '
        Me.dgv_consulta.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgv_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_consulta.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv_consulta.Location = New System.Drawing.Point(0, 44)
        Me.dgv_consulta.Name = "dgv_consulta"
        Me.dgv_consulta.Size = New System.Drawing.Size(699, 415)
        Me.dgv_consulta.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarExcelToolStripMenuItem, Me.EliminarDocumentoToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(214, 92)
        '
        'ExportarExcelToolStripMenuItem
        '
        Me.ExportarExcelToolStripMenuItem.Name = "ExportarExcelToolStripMenuItem"
        Me.ExportarExcelToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ExportarExcelToolStripMenuItem.Text = "Exportar Excel"
        '
        'EliminarDocumentoToolStripMenuItem
        '
        Me.EliminarDocumentoToolStripMenuItem.Name = "EliminarDocumentoToolStripMenuItem"
        Me.EliminarDocumentoToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.EliminarDocumentoToolStripMenuItem.Text = "Eliminar Documento"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar todos Documentos"
        '
        'DTP_fec_inicio
        '
        Me.DTP_fec_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_fec_inicio.Location = New System.Drawing.Point(371, 16)
        Me.DTP_fec_inicio.Name = "DTP_fec_inicio"
        Me.DTP_fec_inicio.Size = New System.Drawing.Size(83, 20)
        Me.DTP_fec_inicio.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(301, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fec. Inicio : "
        '
        'DTP_fec_final
        '
        Me.DTP_fec_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_fec_final.Location = New System.Drawing.Point(522, 16)
        Me.DTP_fec_final.Name = "DTP_fec_final"
        Me.DTP_fec_final.Size = New System.Drawing.Size(83, 20)
        Me.DTP_fec_final.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(460, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fec. Final : "
        '
        'btnfiltrar
        '
        Me.btnfiltrar.BackColor = System.Drawing.Color.Transparent
        Me.btnfiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnfiltrar.ForeColor = System.Drawing.Color.Maroon
        Me.btnfiltrar.Image = CType(resources.GetObject("btnfiltrar.Image"), System.Drawing.Image)
        Me.btnfiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnfiltrar.Location = New System.Drawing.Point(616, 10)
        Me.btnfiltrar.Name = "btnfiltrar"
        Me.btnfiltrar.Size = New System.Drawing.Size(80, 28)
        Me.btnfiltrar.TabIndex = 44
        Me.btnfiltrar.Text = "&Cargar"
        Me.btnfiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnfiltrar.UseVisualStyleBackColor = False
        '
        'frmconsultadatosmensajeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(707, 490)
        Me.Name = "frmconsultadatosmensajeria"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        CType(Me.dgv_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents DTP_fec_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportarExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTP_fec_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnfiltrar As System.Windows.Forms.Button
    Friend WithEvents EliminarDocumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
