<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCreaRelaCobra
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
        Me.DTPFECHA_FINAL = New System.Windows.Forms.DateTimePicker
        Me.DTPFECHA_INI = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Panel = New System.Windows.Forms.Panel
        Me.tc = New System.Windows.Forms.TabControl
        Me.tp2 = New System.Windows.Forms.TabPage
        Me.lab_total_reg = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_total_costo = New System.Windows.Forms.TextBox
        Me.BtnImpri = New System.Windows.Forms.Button
        Me.BtnBuscarLista = New System.Windows.Forms.Button
        Me.BtnBuscarCliente = New System.Windows.Forms.Button
        Me.Txtrazon_social = New System.Windows.Forms.TextBox
        Me.Txtnu_docu_suna = New System.Windows.Forms.TextBox
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnCancelar = New System.Windows.Forms.Button
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.tc.SuspendLayout()
        Me.tp2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DTPFECHA_FINAL
        '
        Me.DTPFECHA_FINAL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHA_FINAL.Location = New System.Drawing.Point(240, 20)
        Me.DTPFECHA_FINAL.Name = "DTPFECHA_FINAL"
        Me.DTPFECHA_FINAL.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHA_FINAL.TabIndex = 65
        '
        'DTPFECHA_INI
        '
        Me.DTPFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFECHA_INI.Location = New System.Drawing.Point(84, 20)
        Me.DTPFECHA_INI.Name = "DTPFECHA_INI"
        Me.DTPFECHA_INI.Size = New System.Drawing.Size(84, 20)
        Me.DTPFECHA_INI.TabIndex = 64
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(174, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "Fecha Fin :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(7, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Fecha Inicio :"
        '
        'DGV2
        '
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(6, 50)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.Size = New System.Drawing.Size(708, 402)
        Me.DGV2.TabIndex = 3
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.tc)
        Me.Panel.Controls.Add(Me.BtnBuscarCliente)
        Me.Panel.Controls.Add(Me.Txtrazon_social)
        Me.Panel.Controls.Add(Me.Txtnu_docu_suna)
        Me.Panel.Controls.Add(Me.BtnSalir)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.BtnCancelar)
        Me.Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(736, 607)
        Me.Panel.TabIndex = 1
        '
        'tc
        '
        Me.tc.Controls.Add(Me.tp2)
        Me.tc.Location = New System.Drawing.Point(4, 51)
        Me.tc.Name = "tc"
        Me.tc.SelectedIndex = 0
        Me.tc.Size = New System.Drawing.Size(728, 520)
        Me.tc.TabIndex = 0
        '
        'tp2
        '
        Me.tp2.Controls.Add(Me.lab_total_reg)
        Me.tp2.Controls.Add(Me.Label1)
        Me.tp2.Controls.Add(Me.txt_total_costo)
        Me.tp2.Controls.Add(Me.BtnImpri)
        Me.tp2.Controls.Add(Me.DTPFECHA_FINAL)
        Me.tp2.Controls.Add(Me.DTPFECHA_INI)
        Me.tp2.Controls.Add(Me.BtnBuscarLista)
        Me.tp2.Controls.Add(Me.Label12)
        Me.tp2.Controls.Add(Me.Label13)
        Me.tp2.Controls.Add(Me.DGV2)
        Me.tp2.Location = New System.Drawing.Point(4, 22)
        Me.tp2.Name = "tp2"
        Me.tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.tp2.Size = New System.Drawing.Size(720, 494)
        Me.tp2.TabIndex = 1
        Me.tp2.Text = "Crear..."
        Me.tp2.UseVisualStyleBackColor = True
        '
        'lab_total_reg
        '
        Me.lab_total_reg.AutoSize = True
        Me.lab_total_reg.BackColor = System.Drawing.Color.Transparent
        Me.lab_total_reg.Location = New System.Drawing.Point(7, 468)
        Me.lab_total_reg.Name = "lab_total_reg"
        Me.lab_total_reg.Size = New System.Drawing.Size(0, 13)
        Me.lab_total_reg.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(571, 466)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Total :"
        '
        'txt_total_costo
        '
        Me.txt_total_costo.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total_costo.Location = New System.Drawing.Point(612, 462)
        Me.txt_total_costo.Name = "txt_total_costo"
        Me.txt_total_costo.Size = New System.Drawing.Size(100, 20)
        Me.txt_total_costo.TabIndex = 68
        Me.txt_total_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnImpri
        '
        Me.BtnImpri.BackColor = System.Drawing.Color.Transparent
        Me.BtnImpri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImpri.Location = New System.Drawing.Point(622, 17)
        Me.BtnImpri.Name = "BtnImpri"
        Me.BtnImpri.Size = New System.Drawing.Size(92, 27)
        Me.BtnImpri.TabIndex = 5
        Me.BtnImpri.Text = "Imprimir"
        Me.BtnImpri.UseVisualStyleBackColor = False
        '
        'BtnBuscarLista
        '
        Me.BtnBuscarLista.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscarLista.Location = New System.Drawing.Point(340, 13)
        Me.BtnBuscarLista.Name = "BtnBuscarLista"
        Me.BtnBuscarLista.Size = New System.Drawing.Size(92, 27)
        Me.BtnBuscarLista.TabIndex = 5
        Me.BtnBuscarLista.Text = "Buscar"
        Me.BtnBuscarLista.UseVisualStyleBackColor = False
        '
        'BtnBuscarCliente
        '
        Me.BtnBuscarCliente.Location = New System.Drawing.Point(444, 23)
        Me.BtnBuscarCliente.Name = "BtnBuscarCliente"
        Me.BtnBuscarCliente.Size = New System.Drawing.Size(75, 23)
        Me.BtnBuscarCliente.TabIndex = 6
        Me.BtnBuscarCliente.Text = "..."
        Me.BtnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Txtrazon_social
        '
        Me.Txtrazon_social.BackColor = System.Drawing.SystemColors.Info
        Me.Txtrazon_social.Enabled = False
        Me.Txtrazon_social.Location = New System.Drawing.Point(110, 25)
        Me.Txtrazon_social.Name = "Txtrazon_social"
        Me.Txtrazon_social.Size = New System.Drawing.Size(330, 20)
        Me.Txtrazon_social.TabIndex = 5
        '
        'Txtnu_docu_suna
        '
        Me.Txtnu_docu_suna.BackColor = System.Drawing.SystemColors.Info
        Me.Txtnu_docu_suna.Enabled = False
        Me.Txtnu_docu_suna.Location = New System.Drawing.Point(4, 25)
        Me.Txtnu_docu_suna.Name = "Txtnu_docu_suna"
        Me.Txtnu_docu_suna.Size = New System.Drawing.Size(100, 20)
        Me.Txtnu_docu_suna.TabIndex = 5
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.Transparent
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Location = New System.Drawing.Point(636, 577)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(92, 27)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(107, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Razon Social"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "R.U.C."
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelar.Location = New System.Drawing.Point(538, 577)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(92, 27)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'FrmCreaRelaCobra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 607)
        Me.Controls.Add(Me.Panel)
        Me.Name = "FrmCreaRelaCobra"
        Me.Text = "Crear relación de cobranza por cliente..."
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.tc.ResumeLayout(False)
        Me.tp2.ResumeLayout(False)
        Me.tp2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents DTPFECHA_FINAL As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFECHA_INI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tc As System.Windows.Forms.TabControl
    Friend WithEvents tp2 As System.Windows.Forms.TabPage
    Friend WithEvents BtnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Txtrazon_social As System.Windows.Forms.TextBox
    Friend WithEvents Txtnu_docu_suna As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnImpri As System.Windows.Forms.Button
    Friend WithEvents BtnBuscarLista As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents lab_total_reg As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_total_costo As System.Windows.Forms.TextBox

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        '
        total()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
