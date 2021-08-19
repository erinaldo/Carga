<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeleventaConfiguracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTeleventaConfiguracion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLlamadaO = New System.Windows.Forms.TextBox()
        Me.txtLlamadaI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtValorLlamada = New System.Windows.Forms.TextBox()
        Me.btnGrabarLlamada = New System.Windows.Forms.Button()
        Me.tabConfiguracion = New System.Windows.Forms.TabControl()
        Me.tabLlamada = New System.Windows.Forms.TabPage()
        Me.tabObjetivo = New System.Windows.Forms.TabPage()
        Me.tabObjetivos = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.tabMantenimiento = New System.Windows.Forms.TabPage()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.cboTipoObjetivo = New System.Windows.Forms.ComboBox()
        Me.cboAgente = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabConfiguracion.SuspendLayout()
        Me.tabLlamada.SuspendLayout()
        Me.tabObjetivo.SuspendLayout()
        Me.tabObjetivos.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMantenimiento.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLlamadaO)
        Me.GroupBox1.Controls.Add(Me.txtLlamadaI)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(152, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 102)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Llamada Válida (Segundos)"
        '
        'txtLlamadaO
        '
        Me.txtLlamadaO.Location = New System.Drawing.Point(76, 67)
        Me.txtLlamadaO.MaxLength = 5
        Me.txtLlamadaO.Name = "txtLlamadaO"
        Me.txtLlamadaO.Size = New System.Drawing.Size(89, 20)
        Me.txtLlamadaO.TabIndex = 1
        '
        'txtLlamadaI
        '
        Me.txtLlamadaI.Location = New System.Drawing.Point(76, 30)
        Me.txtLlamadaI.MaxLength = 5
        Me.txtLlamadaI.Name = "txtLlamadaI"
        Me.txtLlamadaI.Size = New System.Drawing.Size(89, 20)
        Me.txtLlamadaI.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Outbound"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inbound"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtValorLlamada)
        Me.GroupBox2.Location = New System.Drawing.Point(460, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 102)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Llamada Conversión (Horas)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Valor"
        '
        'txtValorLlamada
        '
        Me.txtValorLlamada.Location = New System.Drawing.Point(75, 45)
        Me.txtValorLlamada.MaxLength = 5
        Me.txtValorLlamada.Name = "txtValorLlamada"
        Me.txtValorLlamada.Size = New System.Drawing.Size(89, 20)
        Me.txtValorLlamada.TabIndex = 2
        '
        'btnGrabarLlamada
        '
        Me.btnGrabarLlamada.Image = CType(resources.GetObject("btnGrabarLlamada.Image"), System.Drawing.Image)
        Me.btnGrabarLlamada.Location = New System.Drawing.Point(381, 241)
        Me.btnGrabarLlamada.Name = "btnGrabarLlamada"
        Me.btnGrabarLlamada.Size = New System.Drawing.Size(67, 45)
        Me.btnGrabarLlamada.TabIndex = 3
        Me.btnGrabarLlamada.Text = "Grabar"
        Me.btnGrabarLlamada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGrabarLlamada.UseVisualStyleBackColor = True
        '
        'tabConfiguracion
        '
        Me.tabConfiguracion.Controls.Add(Me.tabLlamada)
        Me.tabConfiguracion.Controls.Add(Me.tabObjetivo)
        Me.tabConfiguracion.Location = New System.Drawing.Point(8, 19)
        Me.tabConfiguracion.Name = "tabConfiguracion"
        Me.tabConfiguracion.SelectedIndex = 0
        Me.tabConfiguracion.Size = New System.Drawing.Size(802, 471)
        Me.tabConfiguracion.TabIndex = 4
        '
        'tabLlamada
        '
        Me.tabLlamada.Controls.Add(Me.btnGrabarLlamada)
        Me.tabLlamada.Controls.Add(Me.GroupBox2)
        Me.tabLlamada.Controls.Add(Me.GroupBox1)
        Me.tabLlamada.Location = New System.Drawing.Point(4, 22)
        Me.tabLlamada.Name = "tabLlamada"
        Me.tabLlamada.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLlamada.Size = New System.Drawing.Size(794, 445)
        Me.tabLlamada.TabIndex = 0
        Me.tabLlamada.Text = "Llamada"
        Me.tabLlamada.UseVisualStyleBackColor = True
        '
        'tabObjetivo
        '
        Me.tabObjetivo.Controls.Add(Me.tabObjetivos)
        Me.tabObjetivo.Location = New System.Drawing.Point(4, 22)
        Me.tabObjetivo.Name = "tabObjetivo"
        Me.tabObjetivo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabObjetivo.Size = New System.Drawing.Size(794, 445)
        Me.tabObjetivo.TabIndex = 1
        Me.tabObjetivo.Text = "Objetivo"
        Me.tabObjetivo.UseVisualStyleBackColor = True
        '
        'tabObjetivos
        '
        Me.tabObjetivos.Controls.Add(Me.tabLista)
        Me.tabObjetivos.Controls.Add(Me.tabMantenimiento)
        Me.tabObjetivos.Location = New System.Drawing.Point(10, 10)
        Me.tabObjetivos.Name = "tabObjetivos"
        Me.tabObjetivos.SelectedIndex = 0
        Me.tabObjetivos.Size = New System.Drawing.Size(773, 426)
        Me.tabObjetivos.TabIndex = 2
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.btnAnular)
        Me.tabLista.Controls.Add(Me.btnModificar)
        Me.tabLista.Controls.Add(Me.btnNuevo)
        Me.tabLista.Controls.Add(Me.dgv)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(765, 400)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.Location = New System.Drawing.Point(382, 363)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(75, 30)
        Me.btnAnular.TabIndex = 2
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(130, 363)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 30)
        Me.btnModificar.TabIndex = 2
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(8, 363)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 30)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(8, 8)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(748, 347)
        Me.dgv.TabIndex = 1
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.Controls.Add(Me.dtpFecha)
        Me.tabMantenimiento.Controls.Add(Me.btnCancelar)
        Me.tabMantenimiento.Controls.Add(Me.btnGrabar)
        Me.tabMantenimiento.Controls.Add(Me.txtValor)
        Me.tabMantenimiento.Controls.Add(Me.cboTipoObjetivo)
        Me.tabMantenimiento.Controls.Add(Me.cboAgente)
        Me.tabMantenimiento.Controls.Add(Me.Label7)
        Me.tabMantenimiento.Controls.Add(Me.Label6)
        Me.tabMantenimiento.Controls.Add(Me.Label5)
        Me.tabMantenimiento.Controls.Add(Me.Label4)
        Me.tabMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMantenimiento.Size = New System.Drawing.Size(765, 400)
        Me.tabMantenimiento.TabIndex = 1
        Me.tabMantenimiento.Text = "Objetivo"
        Me.tabMantenimiento.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "MMM - yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(308, 65)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(99, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(417, 246)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 35)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(248, 246)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 35)
        Me.btnGrabar.TabIndex = 4
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(308, 180)
        Me.txtValor.MaxLength = 7
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(100, 20)
        Me.txtValor.TabIndex = 3
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTipoObjetivo
        '
        Me.cboTipoObjetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoObjetivo.FormattingEnabled = True
        Me.cboTipoObjetivo.Items.AddRange(New Object() {"(SELECCIONE)", "SOLES", "LLAMADAS"})
        Me.cboTipoObjetivo.Location = New System.Drawing.Point(308, 101)
        Me.cboTipoObjetivo.Name = "cboTipoObjetivo"
        Me.cboTipoObjetivo.Size = New System.Drawing.Size(171, 21)
        Me.cboTipoObjetivo.TabIndex = 1
        '
        'cboAgente
        '
        Me.cboAgente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgente.FormattingEnabled = True
        Me.cboAgente.Location = New System.Drawing.Point(308, 139)
        Me.cboAgente.Name = "cboAgente"
        Me.cboAgente.Size = New System.Drawing.Size(255, 21)
        Me.cboAgente.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(218, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tipo Objetivo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(218, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Valor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Agente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha"
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.Controls.Add(Me.btnSalir)
        Me.Panel11.Location = New System.Drawing.Point(732, 2)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(78, 31)
        Me.Panel11.TabIndex = 5
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(5, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(69, 31)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmTeleventaConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 496)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.tabConfiguracion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTeleventaConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabConfiguracion.ResumeLayout(False)
        Me.tabLlamada.ResumeLayout(False)
        Me.tabObjetivo.ResumeLayout(False)
        Me.tabObjetivos.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabMantenimiento.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLlamadaO As System.Windows.Forms.TextBox
    Friend WithEvents txtLlamadaI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValorLlamada As System.Windows.Forms.TextBox
    Friend WithEvents btnGrabarLlamada As System.Windows.Forms.Button
    Friend WithEvents tabConfiguracion As System.Windows.Forms.TabControl
    Friend WithEvents tabLlamada As System.Windows.Forms.TabPage
    Friend WithEvents tabObjetivo As System.Windows.Forms.TabPage
    Friend WithEvents tabObjetivos As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents tabMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents cboAgente As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cboTipoObjetivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
