<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOpciones
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
        Me.gbpagocontraentre = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMONTO_MINIMO_PCE = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkInfinito = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTPORCEN = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTRANGO_MAXIMO = New System.Windows.Forms.TextBox
        Me.TXTRANGO_MINIMO = New System.Windows.Forms.TextBox
        Me.btnEli = New System.Windows.Forms.Button
        Me.BtnAge = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMONTO_MINIMO = New System.Windows.Forms.TextBox
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkInfinito2 = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTPORCEN_PERSO = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTRANGO_MAXIMO_PERSO = New System.Windows.Forms.TextBox
        Me.TXTRANGO_MINIMO_PERSO = New System.Windows.Forms.TextBox
        Me.btnEli_PERSO = New System.Windows.Forms.Button
        Me.BtnAge_PERSO = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMONTO_MINIMO_PERSO = New System.Windows.Forms.TextBox
        Me.DGV4 = New System.Windows.Forms.DataGridView
        Me.Txtnu_docu_suna = New System.Windows.Forms.TextBox
        Me.Txtrazon_social = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.BtnBuscarCliente = New System.Windows.Forms.Button
        Me.dgvClienteTarifa = New System.Windows.Forms.DataGridView
        Me.Label11 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.gbpagocontraentre.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvClienteTarifa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Size = New System.Drawing.Size(897, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(897, 35)
        '
        'SplitContainer2
        '
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(829, 552)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(41, 16)
        Me.Panel1.Size = New System.Drawing.Size(772, 520)
        '
        'TabMante
        '
        Me.TabMante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabMante.Size = New System.Drawing.Size(851, 493)
        '
        'TabLista
        '
        Me.TabLista.Size = New System.Drawing.Size(843, 464)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.GroupBox1)
        Me.TabDatos.Size = New System.Drawing.Size(843, 464)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.dgvClienteTarifa)
        Me.TabPage1.Controls.Add(Me.BtnBuscarCliente)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Txtrazon_social)
        Me.TabPage1.Controls.Add(Me.Txtnu_docu_suna)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Size = New System.Drawing.Size(843, 464)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(843, 464)
        '
        'TabPage3
        '
        Me.TabPage3.Size = New System.Drawing.Size(843, 464)
        '
        'TabPage4
        '
        Me.TabPage4.Size = New System.Drawing.Size(843, 464)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Size = New System.Drawing.Size(32767, 539)
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.Transparent
        Me.Panel.Controls.Add(Me.gbpagocontraentre)
        Me.Panel.Location = New System.Drawing.Point(8, 6)
        Me.Panel.Size = New System.Drawing.Size(848, 468)
        '
        'gbpagocontraentre
        '
        Me.gbpagocontraentre.Controls.Add(Me.Label1)
        Me.gbpagocontraentre.Controls.Add(Me.txtMONTO_MINIMO_PCE)
        Me.gbpagocontraentre.Location = New System.Drawing.Point(8, 7)
        Me.gbpagocontraentre.Name = "gbpagocontraentre"
        Me.gbpagocontraentre.Size = New System.Drawing.Size(181, 52)
        Me.gbpagocontraentre.TabIndex = 1
        Me.gbpagocontraentre.TabStop = False
        Me.gbpagocontraentre.Text = "Pago contra entrega.."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Monto Mínimo por Pago Contra Entrega:"
        '
        'txtMONTO_MINIMO_PCE
        '
        Me.txtMONTO_MINIMO_PCE.Location = New System.Drawing.Point(121, 19)
        Me.txtMONTO_MINIMO_PCE.Name = "txtMONTO_MINIMO_PCE"
        Me.txtMONTO_MINIMO_PCE.Size = New System.Drawing.Size(55, 20)
        Me.txtMONTO_MINIMO_PCE.TabIndex = 0
        Me.txtMONTO_MINIMO_PCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkInfinito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXTPORCEN)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TXTRANGO_MAXIMO)
        Me.GroupBox1.Controls.Add(Me.TXTRANGO_MINIMO)
        Me.GroupBox1.Controls.Add(Me.btnEli)
        Me.GroupBox1.Controls.Add(Me.BtnAge)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMONTO_MINIMO)
        Me.GroupBox1.Controls.Add(Me.DGV)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(407, 268)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Carga Asegurada"
        '
        'chkInfinito
        '
        Me.chkInfinito.AutoSize = True
        Me.chkInfinito.Location = New System.Drawing.Point(209, 243)
        Me.chkInfinito.Name = "chkInfinito"
        Me.chkInfinito.Size = New System.Drawing.Size(109, 17)
        Me.chkInfinito.TabIndex = 12
        Me.chkInfinito.Text = "¿Infinito Positivo?"
        Me.chkInfinito.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(206, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Porcentaje:"
        '
        'TXTPORCEN
        '
        Me.TXTPORCEN.Location = New System.Drawing.Point(275, 215)
        Me.TXTPORCEN.MaxLength = 6
        Me.TXTPORCEN.Name = "TXTPORCEN"
        Me.TXTPORCEN.Size = New System.Drawing.Size(55, 20)
        Me.TXTPORCEN.TabIndex = 9
        Me.TXTPORCEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Monto Mínimo Final:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Monto Mínimo Inicial:"
        '
        'TXTRANGO_MAXIMO
        '
        Me.TXTRANGO_MAXIMO.Location = New System.Drawing.Point(123, 241)
        Me.TXTRANGO_MAXIMO.MaxLength = 6
        Me.TXTRANGO_MAXIMO.Name = "TXTRANGO_MAXIMO"
        Me.TXTRANGO_MAXIMO.Size = New System.Drawing.Size(55, 20)
        Me.TXTRANGO_MAXIMO.TabIndex = 6
        Me.TXTRANGO_MAXIMO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRANGO_MINIMO
        '
        Me.TXTRANGO_MINIMO.Location = New System.Drawing.Point(123, 215)
        Me.TXTRANGO_MINIMO.MaxLength = 6
        Me.TXTRANGO_MINIMO.Name = "TXTRANGO_MINIMO"
        Me.TXTRANGO_MINIMO.Size = New System.Drawing.Size(55, 20)
        Me.TXTRANGO_MINIMO.TabIndex = 5
        Me.TXTRANGO_MINIMO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEli
        '
        Me.btnEli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEli.Location = New System.Drawing.Point(377, 26)
        Me.btnEli.Name = "btnEli"
        Me.btnEli.Size = New System.Drawing.Size(22, 20)
        Me.btnEli.TabIndex = 4
        Me.btnEli.Text = "-"
        Me.btnEli.UseVisualStyleBackColor = True
        '
        'BtnAge
        '
        Me.BtnAge.Location = New System.Drawing.Point(373, 214)
        Me.BtnAge.Name = "BtnAge"
        Me.BtnAge.Size = New System.Drawing.Size(26, 20)
        Me.BtnAge.TabIndex = 4
        Me.BtnAge.Text = "+"
        Me.BtnAge.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 30)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Monto Mínimo por Carga Asegurada:"
        '
        'txtMONTO_MINIMO
        '
        Me.txtMONTO_MINIMO.Location = New System.Drawing.Point(126, 19)
        Me.txtMONTO_MINIMO.MaxLength = 6
        Me.txtMONTO_MINIMO.Name = "txtMONTO_MINIMO"
        Me.txtMONTO_MINIMO.Size = New System.Drawing.Size(55, 20)
        Me.txtMONTO_MINIMO.TabIndex = 2
        Me.txtMONTO_MINIMO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(9, 49)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(390, 160)
        Me.DGV.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.chkInfinito2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TXTPORCEN_PERSO)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TXTRANGO_MAXIMO_PERSO)
        Me.GroupBox2.Controls.Add(Me.TXTRANGO_MINIMO_PERSO)
        Me.GroupBox2.Controls.Add(Me.btnEli_PERSO)
        Me.GroupBox2.Controls.Add(Me.BtnAge_PERSO)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtMONTO_MINIMO_PERSO)
        Me.GroupBox2.Controls.Add(Me.DGV4)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 268)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Carga Asegurada"
        '
        'chkInfinito2
        '
        Me.chkInfinito2.AutoSize = True
        Me.chkInfinito2.Location = New System.Drawing.Point(207, 241)
        Me.chkInfinito2.Name = "chkInfinito2"
        Me.chkInfinito2.Size = New System.Drawing.Size(109, 17)
        Me.chkInfinito2.TabIndex = 13
        Me.chkInfinito2.Text = "¿Infinito Positivo?"
        Me.chkInfinito2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(204, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Porcentaje:"
        '
        'TXTPORCEN_PERSO
        '
        Me.TXTPORCEN_PERSO.Location = New System.Drawing.Point(273, 215)
        Me.TXTPORCEN_PERSO.MaxLength = 6
        Me.TXTPORCEN_PERSO.Name = "TXTPORCEN_PERSO"
        Me.TXTPORCEN_PERSO.Size = New System.Drawing.Size(55, 20)
        Me.TXTPORCEN_PERSO.TabIndex = 9
        Me.TXTPORCEN_PERSO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Monto Mínimo Final:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 219)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 17)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Monto Mínimo Inicial:"
        '
        'TXTRANGO_MAXIMO_PERSO
        '
        Me.TXTRANGO_MAXIMO_PERSO.Location = New System.Drawing.Point(123, 241)
        Me.TXTRANGO_MAXIMO_PERSO.MaxLength = 6
        Me.TXTRANGO_MAXIMO_PERSO.Name = "TXTRANGO_MAXIMO_PERSO"
        Me.TXTRANGO_MAXIMO_PERSO.Size = New System.Drawing.Size(55, 20)
        Me.TXTRANGO_MAXIMO_PERSO.TabIndex = 6
        Me.TXTRANGO_MAXIMO_PERSO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRANGO_MINIMO_PERSO
        '
        Me.TXTRANGO_MINIMO_PERSO.Location = New System.Drawing.Point(123, 215)
        Me.TXTRANGO_MINIMO_PERSO.MaxLength = 6
        Me.TXTRANGO_MINIMO_PERSO.Name = "TXTRANGO_MINIMO_PERSO"
        Me.TXTRANGO_MINIMO_PERSO.Size = New System.Drawing.Size(55, 20)
        Me.TXTRANGO_MINIMO_PERSO.TabIndex = 5
        Me.TXTRANGO_MINIMO_PERSO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEli_PERSO
        '
        Me.btnEli_PERSO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEli_PERSO.Location = New System.Drawing.Point(377, 26)
        Me.btnEli_PERSO.Name = "btnEli_PERSO"
        Me.btnEli_PERSO.Size = New System.Drawing.Size(22, 20)
        Me.btnEli_PERSO.TabIndex = 4
        Me.btnEli_PERSO.Text = "-"
        Me.btnEli_PERSO.UseVisualStyleBackColor = True
        '
        'BtnAge_PERSO
        '
        Me.BtnAge_PERSO.Location = New System.Drawing.Point(373, 214)
        Me.BtnAge_PERSO.Name = "BtnAge_PERSO"
        Me.BtnAge_PERSO.Size = New System.Drawing.Size(26, 20)
        Me.BtnAge_PERSO.TabIndex = 4
        Me.BtnAge_PERSO.Text = "+"
        Me.BtnAge_PERSO.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(11, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 30)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Monto Mínimo por Carga Asegurada:"
        '
        'txtMONTO_MINIMO_PERSO
        '
        Me.txtMONTO_MINIMO_PERSO.Location = New System.Drawing.Point(126, 19)
        Me.txtMONTO_MINIMO_PERSO.MaxLength = 6
        Me.txtMONTO_MINIMO_PERSO.Name = "txtMONTO_MINIMO_PERSO"
        Me.txtMONTO_MINIMO_PERSO.Size = New System.Drawing.Size(55, 20)
        Me.txtMONTO_MINIMO_PERSO.TabIndex = 2
        Me.txtMONTO_MINIMO_PERSO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DGV4
        '
        Me.DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV4.Location = New System.Drawing.Point(9, 49)
        Me.DGV4.Name = "DGV4"
        Me.DGV4.Size = New System.Drawing.Size(390, 160)
        Me.DGV4.TabIndex = 0
        '
        'Txtnu_docu_suna
        '
        Me.Txtnu_docu_suna.BackColor = System.Drawing.SystemColors.Window
        Me.Txtnu_docu_suna.Location = New System.Drawing.Point(59, 16)
        Me.Txtnu_docu_suna.MaxLength = 11
        Me.Txtnu_docu_suna.Name = "Txtnu_docu_suna"
        Me.Txtnu_docu_suna.ReadOnly = True
        Me.Txtnu_docu_suna.Size = New System.Drawing.Size(69, 20)
        Me.Txtnu_docu_suna.TabIndex = 5
        '
        'Txtrazon_social
        '
        Me.Txtrazon_social.BackColor = System.Drawing.SystemColors.Window
        Me.Txtrazon_social.Location = New System.Drawing.Point(125, 16)
        Me.Txtrazon_social.Name = "Txtrazon_social"
        Me.Txtrazon_social.ReadOnly = True
        Me.Txtrazon_social.Size = New System.Drawing.Size(262, 20)
        Me.Txtrazon_social.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(11, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Cliente:"
        '
        'BtnBuscarCliente
        '
        Me.BtnBuscarCliente.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscarCliente.Location = New System.Drawing.Point(393, 15)
        Me.BtnBuscarCliente.Name = "BtnBuscarCliente"
        Me.BtnBuscarCliente.Size = New System.Drawing.Size(27, 20)
        Me.BtnBuscarCliente.TabIndex = 10
        Me.BtnBuscarCliente.Text = "..."
        Me.BtnBuscarCliente.UseVisualStyleBackColor = False
        '
        'dgvClienteTarifa
        '
        Me.dgvClienteTarifa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClienteTarifa.Location = New System.Drawing.Point(430, 34)
        Me.dgvClienteTarifa.Name = "dgvClienteTarifa"
        Me.dgvClienteTarifa.Size = New System.Drawing.Size(330, 416)
        Me.dgvClienteTarifa.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(427, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(264, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Clientes con Tarifa de Carga Asegurada Personalizada"
        '
        'FrmOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(897, 623)
        Me.ControlBox = True
        Me.Name = "FrmOpciones"
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
        Me.TabDatos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel.ResumeLayout(False)
        Me.gbpagocontraentre.ResumeLayout(False)
        Me.gbpagocontraentre.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvClienteTarifa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbpagocontraentre As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMONTO_MINIMO_PCE As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTPORCEN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTRANGO_MAXIMO As System.Windows.Forms.TextBox
    Friend WithEvents TXTRANGO_MINIMO As System.Windows.Forms.TextBox
    Friend WithEvents btnEli As System.Windows.Forms.Button
    Friend WithEvents BtnAge As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMONTO_MINIMO As System.Windows.Forms.TextBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTPORCEN_PERSO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTRANGO_MAXIMO_PERSO As System.Windows.Forms.TextBox
    Friend WithEvents TXTRANGO_MINIMO_PERSO As System.Windows.Forms.TextBox
    Friend WithEvents btnEli_PERSO As System.Windows.Forms.Button
    Friend WithEvents BtnAge_PERSO As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMONTO_MINIMO_PERSO As System.Windows.Forms.TextBox
    Friend WithEvents DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txtrazon_social As System.Windows.Forms.TextBox
    Friend WithEvents Txtnu_docu_suna As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents chkInfinito As System.Windows.Forms.CheckBox
    Friend WithEvents dgvClienteTarifa As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkInfinito2 As System.Windows.Forms.CheckBox

End Class
