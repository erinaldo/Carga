<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_act_cliente_contado_credito
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
        Me.cmbProvincia = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbPais = New System.Windows.Forms.ComboBox
        Me.lblPais = New System.Windows.Forms.Label
        Me.GroupBoxUbicacion = New System.Windows.Forms.GroupBox
        Me.cmbdistrito = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_trazon_social = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_representante_legal = New System.Windows.Forms.TextBox
        Me.txt_gerente_general = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkPostFacturacion = New System.Windows.Forms.CheckBox
        Me.chkContadoCredito = New System.Windows.Forms.CheckBox
        Me.chkCorporativo = New System.Windows.Forms.CheckBox
        Me.chkAgenteRetencion = New System.Windows.Forms.CheckBox
        Me.cmbClasPersona = New System.Windows.Forms.ComboBox
        Me.lblClasPersona = New System.Windows.Forms.Label
        Me.cmbRubroEmpresarial = New System.Windows.Forms.ComboBox
        Me.lblRubroEmpresarial = New System.Windows.Forms.Label
        Me.cmbTipoFacturacion = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_idpersona = New System.Windows.Forms.TextBox
        Me.GroupBoxUbicacion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbProvincia
        '
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(279, 235)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(131, 21)
        Me.cmbProvincia.TabIndex = 95
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(279, 219)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Provincia :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(144, 235)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(131, 21)
        Me.cmbDepartamento.TabIndex = 93
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(144, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 13)
        Me.Label13.TabIndex = 97
        Me.Label13.Text = "Departamento :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPais
        '
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(8, 235)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(131, 21)
        Me.cmbPais.TabIndex = 91
        '
        'lblPais
        '
        Me.lblPais.BackColor = System.Drawing.Color.Transparent
        Me.lblPais.Location = New System.Drawing.Point(8, 219)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(92, 13)
        Me.lblPais.TabIndex = 99
        Me.lblPais.Text = "Pais :"
        Me.lblPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBoxUbicacion
        '
        Me.GroupBoxUbicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxUbicacion.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxUbicacion.Controls.Add(Me.cmbdistrito)
        Me.GroupBoxUbicacion.Controls.Add(Me.Label1)
        Me.GroupBoxUbicacion.ForeColor = System.Drawing.Color.Black
        Me.GroupBoxUbicacion.Location = New System.Drawing.Point(3, 202)
        Me.GroupBoxUbicacion.Name = "GroupBoxUbicacion"
        Me.GroupBoxUbicacion.Size = New System.Drawing.Size(562, 65)
        Me.GroupBoxUbicacion.TabIndex = 90
        Me.GroupBoxUbicacion.TabStop = False
        Me.GroupBoxUbicacion.Text = "Ubicacion Geografica"
        '
        'cmbdistrito
        '
        Me.cmbdistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbdistrito.FormattingEnabled = True
        Me.cmbdistrito.Location = New System.Drawing.Point(416, 33)
        Me.cmbdistrito.Name = "cmbdistrito"
        Me.cmbdistrito.Size = New System.Drawing.Size(131, 21)
        Me.cmbdistrito.TabIndex = 100
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(416, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Distrito :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(335, 273)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 100
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(472, 273)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 101
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(121, 35)
        Me.txt_codigo_cliente.MaxLength = 11
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.ReadOnly = True
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(100, 20)
        Me.txt_codigo_cliente.TabIndex = 102
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Código Cliente :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_trazon_social
        '
        Me.txt_trazon_social.Location = New System.Drawing.Point(121, 61)
        Me.txt_trazon_social.Name = "txt_trazon_social"
        Me.txt_trazon_social.Size = New System.Drawing.Size(418, 20)
        Me.txt_trazon_social.TabIndex = 104
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(6, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Razón Social :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_representante_legal
        '
        Me.txt_representante_legal.Location = New System.Drawing.Point(121, 113)
        Me.txt_representante_legal.Name = "txt_representante_legal"
        Me.txt_representante_legal.Size = New System.Drawing.Size(417, 20)
        Me.txt_representante_legal.TabIndex = 106
        '
        'txt_gerente_general
        '
        Me.txt_gerente_general.Location = New System.Drawing.Point(121, 87)
        Me.txt_gerente_general.Name = "txt_gerente_general"
        Me.txt_gerente_general.Size = New System.Drawing.Size(418, 20)
        Me.txt_gerente_general.TabIndex = 107
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 17)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Gerente General :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(6, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Representante Legal :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPostFacturacion
        '
        Me.chkPostFacturacion.AutoSize = True
        Me.chkPostFacturacion.BackColor = System.Drawing.Color.Transparent
        Me.chkPostFacturacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPostFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPostFacturacion.Location = New System.Drawing.Point(254, 148)
        Me.chkPostFacturacion.Name = "chkPostFacturacion"
        Me.chkPostFacturacion.Size = New System.Drawing.Size(143, 17)
        Me.chkPostFacturacion.TabIndex = 111
        Me.chkPostFacturacion.Text = "¿Pago Post Facturación?"
        Me.chkPostFacturacion.UseVisualStyleBackColor = False
        '
        'chkContadoCredito
        '
        Me.chkContadoCredito.AutoSize = True
        Me.chkContadoCredito.BackColor = System.Drawing.Color.Transparent
        Me.chkContadoCredito.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkContadoCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkContadoCredito.Location = New System.Drawing.Point(134, 148)
        Me.chkContadoCredito.Name = "chkContadoCredito"
        Me.chkContadoCredito.Size = New System.Drawing.Size(110, 17)
        Me.chkContadoCredito.TabIndex = 112
        Me.chkContadoCredito.Text = "¿Cliente Contado?"
        Me.chkContadoCredito.UseVisualStyleBackColor = False
        '
        'chkCorporativo
        '
        Me.chkCorporativo.AutoSize = True
        Me.chkCorporativo.BackColor = System.Drawing.Color.Transparent
        Me.chkCorporativo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCorporativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCorporativo.Location = New System.Drawing.Point(9, 148)
        Me.chkCorporativo.Name = "chkCorporativo"
        Me.chkCorporativo.Size = New System.Drawing.Size(103, 17)
        Me.chkCorporativo.TabIndex = 110
        Me.chkCorporativo.Text = "¿Cliente Crédito?"
        Me.chkCorporativo.UseVisualStyleBackColor = False
        '
        'chkAgenteRetencion
        '
        Me.chkAgenteRetencion.AutoSize = True
        Me.chkAgenteRetencion.BackColor = System.Drawing.Color.Transparent
        Me.chkAgenteRetencion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgenteRetencion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAgenteRetencion.Location = New System.Drawing.Point(403, 148)
        Me.chkAgenteRetencion.Name = "chkAgenteRetencion"
        Me.chkAgenteRetencion.Size = New System.Drawing.Size(136, 17)
        Me.chkAgenteRetencion.TabIndex = 113
        Me.chkAgenteRetencion.Text = "¿Es Agente Retención?"
        Me.chkAgenteRetencion.UseVisualStyleBackColor = False
        '
        'cmbClasPersona
        '
        Me.cmbClasPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClasPersona.FormattingEnabled = True
        Me.cmbClasPersona.Location = New System.Drawing.Point(415, 178)
        Me.cmbClasPersona.Name = "cmbClasPersona"
        Me.cmbClasPersona.Size = New System.Drawing.Size(132, 21)
        Me.cmbClasPersona.TabIndex = 115
        '
        'lblClasPersona
        '
        Me.lblClasPersona.BackColor = System.Drawing.Color.Transparent
        Me.lblClasPersona.Location = New System.Drawing.Point(295, 181)
        Me.lblClasPersona.Name = "lblClasPersona"
        Me.lblClasPersona.Size = New System.Drawing.Size(114, 13)
        Me.lblClasPersona.TabIndex = 117
        Me.lblClasPersona.Text = "Clasificacion Persona :"
        Me.lblClasPersona.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbRubroEmpresarial
        '
        Me.cmbRubroEmpresarial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubroEmpresarial.FormattingEnabled = True
        Me.cmbRubroEmpresarial.Location = New System.Drawing.Point(121, 177)
        Me.cmbRubroEmpresarial.Name = "cmbRubroEmpresarial"
        Me.cmbRubroEmpresarial.Size = New System.Drawing.Size(170, 21)
        Me.cmbRubroEmpresarial.TabIndex = 114
        '
        'lblRubroEmpresarial
        '
        Me.lblRubroEmpresarial.BackColor = System.Drawing.Color.Transparent
        Me.lblRubroEmpresarial.Location = New System.Drawing.Point(6, 181)
        Me.lblRubroEmpresarial.Name = "lblRubroEmpresarial"
        Me.lblRubroEmpresarial.Size = New System.Drawing.Size(109, 13)
        Me.lblRubroEmpresarial.TabIndex = 116
        Me.lblRubroEmpresarial.Text = "Rubro Empresarial :"
        Me.lblRubroEmpresarial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoFacturacion
        '
        Me.cmbTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFacturacion.FormattingEnabled = True
        Me.cmbTipoFacturacion.Location = New System.Drawing.Point(399, 33)
        Me.cmbTipoFacturacion.Name = "cmbTipoFacturacion"
        Me.cmbTipoFacturacion.Size = New System.Drawing.Size(139, 21)
        Me.cmbTipoFacturacion.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(279, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "Tipo de Facturación :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lblClasPersona)
        Me.Panel1.Controls.Add(Me.lblPais)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Controls.Add(Me.txt_gerente_general)
        Me.Panel1.Controls.Add(Me.cmbPais)
        Me.Panel1.Controls.Add(Me.cmbClasPersona)
        Me.Panel1.Controls.Add(Me.txt_trazon_social)
        Me.Panel1.Controls.Add(Me.cmbDepartamento)
        Me.Panel1.Controls.Add(Me.cmbRubroEmpresarial)
        Me.Panel1.Controls.Add(Me.cmbProvincia)
        Me.Panel1.Controls.Add(Me.lblRubroEmpresarial)
        Me.Panel1.Controls.Add(Me.chkPostFacturacion)
        Me.Panel1.Controls.Add(Me.chkContadoCredito)
        Me.Panel1.Controls.Add(Me.chkCorporativo)
        Me.Panel1.Controls.Add(Me.cmbTipoFacturacion)
        Me.Panel1.Controls.Add(Me.txt_idpersona)
        Me.Panel1.Controls.Add(Me.chkAgenteRetencion)
        Me.Panel1.Controls.Add(Me.txt_representante_legal)
        Me.Panel1.Controls.Add(Me.GroupBoxUbicacion)
        Me.Panel1.Controls.Add(Me.txt_codigo_cliente)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 311)
        Me.Panel1.TabIndex = 121
        '
        'txt_idpersona
        '
        Me.txt_idpersona.BackColor = System.Drawing.SystemColors.Info
        Me.txt_idpersona.Location = New System.Drawing.Point(9, 273)
        Me.txt_idpersona.Name = "txt_idpersona"
        Me.txt_idpersona.ReadOnly = True
        Me.txt_idpersona.Size = New System.Drawing.Size(100, 20)
        Me.txt_idpersona.TabIndex = 107
        Me.txt_idpersona.Visible = False
        '
        'frm_act_cliente_contado_credito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 311)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_act_cliente_contado_credito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualiza Cliente Contado - Crédito"
        Me.GroupBoxUbicacion.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents GroupBoxUbicacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbdistrito As System.Windows.Forms.ComboBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_trazon_social As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_representante_legal As System.Windows.Forms.TextBox
    Friend WithEvents txt_gerente_general As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkPostFacturacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkContadoCredito As System.Windows.Forms.CheckBox
    Friend WithEvents chkCorporativo As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgenteRetencion As System.Windows.Forms.CheckBox
    Friend WithEvents cmbClasPersona As System.Windows.Forms.ComboBox
    Friend WithEvents lblClasPersona As System.Windows.Forms.Label
    Friend WithEvents cmbRubroEmpresarial As System.Windows.Forms.ComboBox
    Friend WithEvents lblRubroEmpresarial As System.Windows.Forms.Label
    Friend WithEvents cmbTipoFacturacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_idpersona As System.Windows.Forms.TextBox
End Class
