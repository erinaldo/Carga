<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitudClienteCarteraFuncionario
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
        Me.lblRuc = New System.Windows.Forms.Label()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.grbSolicitud = New System.Windows.Forms.GroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblFuncionario = New System.Windows.Forms.Label()
        Me.lblNumeroSolicitud = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFuncionarioActual = New System.Windows.Forms.Label()
        Me.txtSustento = New System.Windows.Forms.TextBox()
        Me.grbLista = New System.Windows.Forms.GroupBox()
        Me.dgvSolicitud = New System.Windows.Forms.DataGridView()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grbSolicitud.SuspendLayout()
        Me.grbLista.SuspendLayout()
        CType(Me.dgvSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRuc
        '
        Me.lblRuc.AutoSize = True
        Me.lblRuc.Location = New System.Drawing.Point(9, 71)
        Me.lblRuc.Name = "lblRuc"
        Me.lblRuc.Size = New System.Drawing.Size(27, 13)
        Me.lblRuc.TabIndex = 0
        Me.lblRuc.Text = "Ruc"
        '
        'txtRuc
        '
        Me.txtRuc.Location = New System.Drawing.Point(62, 68)
        Me.txtRuc.MaxLength = 11
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(99, 20)
        Me.txtRuc.TabIndex = 0
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(161, 71)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(314, 13)
        Me.lblRazonSocial.TabIndex = 1
        '
        'grbSolicitud
        '
        Me.grbSolicitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbSolicitud.Controls.Add(Me.lblFecha)
        Me.grbSolicitud.Controls.Add(Me.lblFuncionario)
        Me.grbSolicitud.Controls.Add(Me.lblNumeroSolicitud)
        Me.grbSolicitud.Controls.Add(Me.Label7)
        Me.grbSolicitud.Controls.Add(Me.Label5)
        Me.grbSolicitud.Controls.Add(Me.Label4)
        Me.grbSolicitud.Controls.Add(Me.Label9)
        Me.grbSolicitud.Controls.Add(Me.Label1)
        Me.grbSolicitud.Controls.Add(Me.lblRuc)
        Me.grbSolicitud.Controls.Add(Me.lblFuncionarioActual)
        Me.grbSolicitud.Controls.Add(Me.lblRazonSocial)
        Me.grbSolicitud.Controls.Add(Me.txtSustento)
        Me.grbSolicitud.Controls.Add(Me.txtRuc)
        Me.grbSolicitud.Enabled = False
        Me.grbSolicitud.Location = New System.Drawing.Point(12, 12)
        Me.grbSolicitud.Name = "grbSolicitud"
        Me.grbSolicitud.Size = New System.Drawing.Size(780, 160)
        Me.grbSolicitud.TabIndex = 0
        Me.grbSolicitud.TabStop = False
        Me.grbSolicitud.Text = "Datos de la Solicitud"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(185, 24)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(75, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "10/12/2013"
        '
        'lblFuncionario
        '
        Me.lblFuncionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionario.Location = New System.Drawing.Point(364, 24)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(405, 13)
        Me.lblFuncionario.TabIndex = 0
        Me.lblFuncionario.Text = "JUAN ANTONIO BACA"
        '
        'lblNumeroSolicitud
        '
        Me.lblNumeroSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSolicitud.Location = New System.Drawing.Point(83, 24)
        Me.lblNumeroSolicitud.Name = "lblNumeroSolicitud"
        Me.lblNumeroSolicitud.Size = New System.Drawing.Size(42, 13)
        Me.lblNumeroSolicitud.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(295, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Solicitante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nº Solicitud"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Sustento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'lblFuncionarioActual
        '
        Me.lblFuncionarioActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFuncionarioActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuncionarioActual.ForeColor = System.Drawing.Color.Red
        Me.lblFuncionarioActual.Location = New System.Drawing.Point(469, 71)
        Me.lblFuncionarioActual.Name = "lblFuncionarioActual"
        Me.lblFuncionarioActual.Size = New System.Drawing.Size(307, 13)
        Me.lblFuncionarioActual.TabIndex = 1
        Me.lblFuncionarioActual.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSustento
        '
        Me.txtSustento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSustento.Location = New System.Drawing.Point(62, 98)
        Me.txtSustento.MaxLength = 255
        Me.txtSustento.Multiline = True
        Me.txtSustento.Name = "txtSustento"
        Me.txtSustento.Size = New System.Drawing.Size(712, 52)
        Me.txtSustento.TabIndex = 1
        '
        'grbLista
        '
        Me.grbLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbLista.Controls.Add(Me.dgvSolicitud)
        Me.grbLista.Location = New System.Drawing.Point(12, 199)
        Me.grbLista.Name = "grbLista"
        Me.grbLista.Size = New System.Drawing.Size(780, 268)
        Me.grbLista.TabIndex = 2
        Me.grbLista.TabStop = False
        '
        'dgvSolicitud
        '
        Me.dgvSolicitud.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSolicitud.Location = New System.Drawing.Point(6, 11)
        Me.dgvSolicitud.Name = "dgvSolicitud"
        Me.dgvSolicitud.Size = New System.Drawing.Size(768, 251)
        Me.dgvSolicitud.TabIndex = 8
        '
        'pnlBotones
        '
        Me.pnlBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBotones.Controls.Add(Me.btnSalir)
        Me.pnlBotones.Controls.Add(Me.btnAnular)
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.btnGrabar)
        Me.pnlBotones.Controls.Add(Me.btnModificar)
        Me.pnlBotones.Controls.Add(Me.btnNuevo)
        Me.pnlBotones.Location = New System.Drawing.Point(12, 470)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(774, 35)
        Me.pnlBotones.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(699, 3)
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
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Lista de Solicitudes"
        '
        'pnlEstado
        '
        Me.pnlEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEstado.Controls.Add(Me.cmbEstado)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Location = New System.Drawing.Point(566, 176)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(220, 27)
        Me.pnlEstado.TabIndex = 17
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"(TODOS)", "PENDIENTE", "APROBADO", "DESAPROBADO", "ANULADO"})
        Me.cmbEstado.Location = New System.Drawing.Point(51, 3)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(166, 21)
        Me.cmbEstado.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Estado"
        '
        'FrmSolicitudClienteCarteraFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 511)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.grbLista)
        Me.Controls.Add(Me.grbSolicitud)
        Me.Name = "FrmSolicitudClienteCarteraFuncionario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Cliente a Cuenta de Responsable"
        Me.grbSolicitud.ResumeLayout(False)
        Me.grbSolicitud.PerformLayout()
        Me.grbLista.ResumeLayout(False)
        CType(Me.dgvSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRuc As System.Windows.Forms.Label
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents grbSolicitud As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSustento As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblNumeroSolicitud As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFuncionario As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFuncionarioActual As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grbLista As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSolicitud As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
