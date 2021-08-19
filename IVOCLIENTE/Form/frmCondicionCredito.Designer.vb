<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCondicionCredito
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
        Me.grbSolicitudFacturacion = New System.Windows.Forms.GroupBox()
        Me.lblFuncionario = New System.Windows.Forms.Label()
        Me.cboCondicionCredito = New System.Windows.Forms.ComboBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblNumeroSolicitud = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.grbSolicitud = New System.Windows.Forms.GroupBox()
        Me.dgvSolicitud = New System.Windows.Forms.DataGridView()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grbSolicitudFacturacion.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.grbSolicitud.SuspendLayout()
        CType(Me.dgvSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSolicitudFacturacion
        '
        Me.grbSolicitudFacturacion.Controls.Add(Me.lblFuncionario)
        Me.grbSolicitudFacturacion.Controls.Add(Me.cboCondicionCredito)
        Me.grbSolicitudFacturacion.Controls.Add(Me.Label107)
        Me.grbSolicitudFacturacion.Controls.Add(Me.txtObservacion)
        Me.grbSolicitudFacturacion.Controls.Add(Me.lblNumeroSolicitud)
        Me.grbSolicitudFacturacion.Controls.Add(Me.lblFecha)
        Me.grbSolicitudFacturacion.Controls.Add(Me.Label110)
        Me.grbSolicitudFacturacion.Controls.Add(Me.Label112)
        Me.grbSolicitudFacturacion.Controls.Add(Me.Label114)
        Me.grbSolicitudFacturacion.Controls.Add(Me.lblCliente)
        Me.grbSolicitudFacturacion.Controls.Add(Me.Label117)
        Me.grbSolicitudFacturacion.Controls.Add(Me.Label118)
        Me.grbSolicitudFacturacion.Location = New System.Drawing.Point(12, 12)
        Me.grbSolicitudFacturacion.Name = "grbSolicitudFacturacion"
        Me.grbSolicitudFacturacion.Size = New System.Drawing.Size(570, 207)
        Me.grbSolicitudFacturacion.TabIndex = 1
        Me.grbSolicitudFacturacion.TabStop = False
        Me.grbSolicitudFacturacion.Text = "Datos de la Solicitud"
        '
        'lblFuncionario
        '
        Me.lblFuncionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionario.Location = New System.Drawing.Point(323, 27)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(238, 13)
        Me.lblFuncionario.TabIndex = 15
        Me.lblFuncionario.Text = "JUAN ANTONIO BACA"
        '
        'cboCondicionCredito
        '
        Me.cboCondicionCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicionCredito.FormattingEnabled = True
        Me.cboCondicionCredito.Location = New System.Drawing.Point(90, 75)
        Me.cboCondicionCredito.Name = "cboCondicionCredito"
        Me.cboCondicionCredito.Size = New System.Drawing.Size(238, 21)
        Me.cboCondicionCredito.TabIndex = 0
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(6, 112)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(78, 13)
        Me.Label107.TabIndex = 8
        Me.Label107.Text = "Observaciones"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(90, 114)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(471, 83)
        Me.txtObservacion.TabIndex = 1
        '
        'lblNumeroSolicitud
        '
        Me.lblNumeroSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSolicitud.Location = New System.Drawing.Point(87, 27)
        Me.lblNumeroSolicitud.Name = "lblNumeroSolicitud"
        Me.lblNumeroSolicitud.Size = New System.Drawing.Size(42, 13)
        Me.lblNumeroSolicitud.TabIndex = 7
        Me.lblNumeroSolicitud.Text = "1"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(174, 27)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(75, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "10/12/2013"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Location = New System.Drawing.Point(258, 27)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(56, 13)
        Me.Label110.TabIndex = 4
        Me.Label110.Text = "Solicitante"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Location = New System.Drawing.Point(132, 27)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(37, 13)
        Me.Label112.TabIndex = 2
        Me.Label112.Text = "Fecha"
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Location = New System.Drawing.Point(6, 27)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(62, 13)
        Me.Label114.TabIndex = 3
        Me.Label114.Text = "Nº Solicitud"
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(87, 53)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(476, 13)
        Me.lblCliente.TabIndex = 1
        Me.lblCliente.Text = "Cliente"
        '
        'Label117
        '
        Me.Label117.Location = New System.Drawing.Point(6, 76)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(72, 34)
        Me.Label117.TabIndex = 1
        Me.Label117.Text = "Condición Crédito"
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Location = New System.Drawing.Point(6, 53)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(39, 13)
        Me.Label118.TabIndex = 1
        Me.Label118.Text = "Cliente"
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.cboEstado)
        Me.Panel14.Controls.Add(Me.Label104)
        Me.Panel14.Location = New System.Drawing.Point(355, 224)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(220, 27)
        Me.Panel14.TabIndex = 27
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"(TODOS)", "PENDIENTE", "APROBADO", "DESAPROBADO", "ANULADO"})
        Me.cboEstado.Location = New System.Drawing.Point(51, 3)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(166, 21)
        Me.cboEstado.TabIndex = 8
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(5, 6)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(40, 13)
        Me.Label104.TabIndex = 17
        Me.Label104.Text = "Estado"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(18, 234)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(98, 13)
        Me.Label105.TabIndex = 26
        Me.Label105.Text = "Lista de Solicitudes"
        '
        'grbSolicitud
        '
        Me.grbSolicitud.Controls.Add(Me.dgvSolicitud)
        Me.grbSolicitud.Location = New System.Drawing.Point(12, 251)
        Me.grbSolicitud.Name = "grbSolicitud"
        Me.grbSolicitud.Size = New System.Drawing.Size(570, 164)
        Me.grbSolicitud.TabIndex = 28
        Me.grbSolicitud.TabStop = False
        '
        'dgvSolicitud
        '
        Me.dgvSolicitud.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSolicitud.Location = New System.Drawing.Point(6, 11)
        Me.dgvSolicitud.Name = "dgvSolicitud"
        Me.dgvSolicitud.Size = New System.Drawing.Size(558, 147)
        Me.dgvSolicitud.TabIndex = 9
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.btnSalir)
        Me.Panel13.Controls.Add(Me.btnAnular)
        Me.Panel13.Controls.Add(Me.btnCancelar)
        Me.Panel13.Controls.Add(Me.btnGrabar)
        Me.Panel13.Controls.Add(Me.btnModificar)
        Me.Panel13.Controls.Add(Me.btnNuevo)
        Me.Panel13.Location = New System.Drawing.Point(18, 422)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(564, 35)
        Me.Panel13.TabIndex = 2
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(483, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 29)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.Location = New System.Drawing.Point(329, 3)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(75, 29)
        Me.btnAnular.TabIndex = 6
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(248, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(167, 3)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 29)
        Me.btnGrabar.TabIndex = 4
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(86, 3)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 29)
        Me.btnModificar.TabIndex = 3
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(5, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 29)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmCondicionCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 465)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.grbSolicitud)
        Me.Controls.Add(Me.Panel14)
        Me.Controls.Add(Me.Label105)
        Me.Controls.Add(Me.grbSolicitudFacturacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCondicionCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Solicitud Cambio Condicion de Credito"
        Me.grbSolicitudFacturacion.ResumeLayout(False)
        Me.grbSolicitudFacturacion.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.grbSolicitud.ResumeLayout(False)
        CType(Me.dgvSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbSolicitudFacturacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblFuncionario As System.Windows.Forms.Label
    Friend WithEvents cboCondicionCredito As System.Windows.Forms.ComboBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroSolicitud As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents grbSolicitud As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSolicitud As System.Windows.Forms.DataGridView
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
