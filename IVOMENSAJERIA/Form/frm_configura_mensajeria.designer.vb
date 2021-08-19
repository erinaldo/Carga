<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_configura_mensajeria
    Inherits INTEGRACION.FrmPlantilla

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
        Me.dgv_parametros = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbestado_envio = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_mensaje_celular = New System.Windows.Forms.TextBox
        Me.txt_cab_email = New System.Windows.Forms.TextBox
        Me.txt_mensaje_email = New System.Windows.Forms.TextBox
        Me.txt_cab_cons_email = New System.Windows.Forms.TextBox
        Me.txt_mensaje_cons_email = New System.Windows.Forms.TextBox
        Me.dgv_mensaje = New System.Windows.Forms.DataGridView
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.txt_idconfig_mensajeria = New System.Windows.Forms.TextBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        CType(Me.dgv_parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_mensaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_idconfig_mensajeria)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_agregar)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgv_mensaje)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_mensaje_cons_email)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_cab_cons_email)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_mensaje_email)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_cab_email)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_mensaje_celular)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbestado_envio)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgv_parametros)
        Me.SplitContainer2.Panel2Collapsed = True
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.Location = New System.Drawing.Point(2, 5)
        Me.MyTreeView.Size = New System.Drawing.Size(767, 539)
        Me.MyTreeView.Visible = False
        '
        'dgv_parametros
        '
        Me.dgv_parametros.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgv_parametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_parametros.Location = New System.Drawing.Point(610, 45)
        Me.dgv_parametros.Name = "dgv_parametros"
        Me.dgv_parametros.Size = New System.Drawing.Size(148, 191)
        Me.dgv_parametros.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(610, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Parametros Mensajeria"
        '
        'cmbestado_envio
        '
        Me.cmbestado_envio.FormattingEnabled = True
        Me.cmbestado_envio.Location = New System.Drawing.Point(112, 23)
        Me.cmbestado_envio.Name = "cmbestado_envio"
        Me.cmbestado_envio.Size = New System.Drawing.Size(164, 21)
        Me.cmbestado_envio.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Estado Envio : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Mensaje Móvil : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Asunto E-Mail : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(12, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Mensaje E-mail :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Asunto Cons. E-mail :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(12, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Mens. Cons. E-mail :"
        '
        'txt_mensaje_celular
        '
        Me.txt_mensaje_celular.Location = New System.Drawing.Point(112, 70)
        Me.txt_mensaje_celular.MaxLength = 250
        Me.txt_mensaje_celular.Name = "txt_mensaje_celular"
        Me.txt_mensaje_celular.Size = New System.Drawing.Size(472, 20)
        Me.txt_mensaje_celular.TabIndex = 10
        '
        'txt_cab_email
        '
        Me.txt_cab_email.Location = New System.Drawing.Point(112, 108)
        Me.txt_cab_email.MaxLength = 100
        Me.txt_cab_email.Name = "txt_cab_email"
        Me.txt_cab_email.Size = New System.Drawing.Size(472, 20)
        Me.txt_cab_email.TabIndex = 11
        '
        'txt_mensaje_email
        '
        Me.txt_mensaje_email.Location = New System.Drawing.Point(112, 138)
        Me.txt_mensaje_email.MaxLength = 400
        Me.txt_mensaje_email.Name = "txt_mensaje_email"
        Me.txt_mensaje_email.Size = New System.Drawing.Size(472, 20)
        Me.txt_mensaje_email.TabIndex = 12
        '
        'txt_cab_cons_email
        '
        Me.txt_cab_cons_email.Location = New System.Drawing.Point(112, 179)
        Me.txt_cab_cons_email.MaxLength = 100
        Me.txt_cab_cons_email.Name = "txt_cab_cons_email"
        Me.txt_cab_cons_email.Size = New System.Drawing.Size(472, 20)
        Me.txt_cab_cons_email.TabIndex = 13
        '
        'txt_mensaje_cons_email
        '
        Me.txt_mensaje_cons_email.Location = New System.Drawing.Point(112, 216)
        Me.txt_mensaje_cons_email.MaxLength = 400
        Me.txt_mensaje_cons_email.Name = "txt_mensaje_cons_email"
        Me.txt_mensaje_cons_email.Size = New System.Drawing.Size(472, 20)
        Me.txt_mensaje_cons_email.TabIndex = 14
        '
        'dgv_mensaje
        '
        Me.dgv_mensaje.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgv_mensaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_mensaje.Location = New System.Drawing.Point(11, 269)
        Me.dgv_mensaje.Name = "dgv_mensaje"
        Me.dgv_mensaje.Size = New System.Drawing.Size(747, 265)
        Me.dgv_mensaje.TabIndex = 15
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.Transparent
        Me.btn_agregar.Location = New System.Drawing.Point(610, 240)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(72, 23)
        Me.btn_agregar.TabIndex = 16
        Me.btn_agregar.Text = "&Actualizar"
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'txt_idconfig_mensajeria
        '
        Me.txt_idconfig_mensajeria.Location = New System.Drawing.Point(484, 26)
        Me.txt_idconfig_mensajeria.Name = "txt_idconfig_mensajeria"
        Me.txt_idconfig_mensajeria.Size = New System.Drawing.Size(100, 20)
        Me.txt_idconfig_mensajeria.TabIndex = 17
        Me.txt_idconfig_mensajeria.Visible = False
        '
        'frm_configura_mensajeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "frm_configura_mensajeria"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        CType(Me.dgv_parametros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_mensaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbestado_envio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_parametros As System.Windows.Forms.DataGridView
    Friend WithEvents txt_mensaje_cons_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_cab_cons_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_mensaje_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_cab_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_mensaje_celular As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_mensaje As System.Windows.Forms.DataGridView
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_idconfig_mensajeria As System.Windows.Forms.TextBox

End Class
