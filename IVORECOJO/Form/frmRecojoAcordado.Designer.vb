<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecojoAcordado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecojoAcordado))
        Me.tabRecojoAcordado = New System.Windows.Forms.TabControl()
        Me.tabCliente = New System.Windows.Forms.TabPage()
        Me.dgvCliente = New System.Windows.Forms.DataGridView()
        Me.tabRecojo = New System.Windows.Forms.TabPage()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.labnroidentidad = New System.Windows.Forms.Label()
        Me.txtdist = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtpro = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtdepar = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtref = New System.Windows.Forms.TextBox()
        Me.txtmovil = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txttel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.dgvProgramacion = New System.Windows.Forms.DataGridView()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.btnDireccion = New System.Windows.Forms.Button()
        Me.btnContacto = New System.Windows.Forms.Button()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.Tsbeditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGrabar = New System.Windows.Forms.ToolStripButton()
        Me.Tsbanular = New System.Windows.Forms.ToolStripButton()
        Me.Tsbactualizar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCalaculadora = New System.Windows.Forms.ToolStripButton()
        Me.TsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tabRecojoAcordado.SuspendLayout()
        Me.tabCliente.SuspendLayout()
        CType(Me.dgvCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRecojo.SuspendLayout()
        Me.Panel16.SuspendLayout()
        CType(Me.dgvProgramacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabRecojoAcordado
        '
        Me.tabRecojoAcordado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabRecojoAcordado.Controls.Add(Me.tabCliente)
        Me.tabRecojoAcordado.Controls.Add(Me.tabRecojo)
        Me.tabRecojoAcordado.Location = New System.Drawing.Point(1, 29)
        Me.tabRecojoAcordado.Name = "tabRecojoAcordado"
        Me.tabRecojoAcordado.SelectedIndex = 0
        Me.tabRecojoAcordado.Size = New System.Drawing.Size(1024, 535)
        Me.tabRecojoAcordado.TabIndex = 0
        '
        'tabCliente
        '
        Me.tabCliente.Controls.Add(Me.dgvCliente)
        Me.tabCliente.Location = New System.Drawing.Point(4, 22)
        Me.tabCliente.Name = "tabCliente"
        Me.tabCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCliente.Size = New System.Drawing.Size(1016, 509)
        Me.tabCliente.TabIndex = 0
        Me.tabCliente.Text = "Cliente"
        Me.tabCliente.UseVisualStyleBackColor = True
        '
        'dgvCliente
        '
        Me.dgvCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCliente.Location = New System.Drawing.Point(6, 5)
        Me.dgvCliente.Name = "dgvCliente"
        Me.dgvCliente.Size = New System.Drawing.Size(993, 501)
        Me.dgvCliente.TabIndex = 0
        '
        'tabRecojo
        '
        Me.tabRecojo.Controls.Add(Me.cboEstado)
        Me.tabRecojo.Controls.Add(Me.btnEliminar)
        Me.tabRecojo.Controls.Add(Me.btnAgregar)
        Me.tabRecojo.Controls.Add(Me.TxtNumero)
        Me.tabRecojo.Controls.Add(Me.labnroidentidad)
        Me.tabRecojo.Controls.Add(Me.txtdist)
        Me.tabRecojo.Controls.Add(Me.Label9)
        Me.tabRecojo.Controls.Add(Me.txtpro)
        Me.tabRecojo.Controls.Add(Me.Label12)
        Me.tabRecojo.Controls.Add(Me.txtdepar)
        Me.tabRecojo.Controls.Add(Me.Label11)
        Me.tabRecojo.Controls.Add(Me.Label14)
        Me.tabRecojo.Controls.Add(Me.txtref)
        Me.tabRecojo.Controls.Add(Me.txtmovil)
        Me.tabRecojo.Controls.Add(Me.Label7)
        Me.tabRecojo.Controls.Add(Me.txttel)
        Me.tabRecojo.Controls.Add(Me.Label2)
        Me.tabRecojo.Controls.Add(Me.Label8)
        Me.tabRecojo.Controls.Add(Me.txtemail)
        Me.tabRecojo.Controls.Add(Me.Panel16)
        Me.tabRecojo.Controls.Add(Me.txtObservacion)
        Me.tabRecojo.Controls.Add(Me.dgvProgramacion)
        Me.tabRecojo.Controls.Add(Me.dgvLista)
        Me.tabRecojo.Controls.Add(Me.Label3)
        Me.tabRecojo.Controls.Add(Me.Label5)
        Me.tabRecojo.Controls.Add(Me.Label4)
        Me.tabRecojo.Controls.Add(Me.Label21)
        Me.tabRecojo.Controls.Add(Me.dtpInicio)
        Me.tabRecojo.Controls.Add(Me.lblCliente)
        Me.tabRecojo.Controls.Add(Me.btnDireccion)
        Me.tabRecojo.Controls.Add(Me.btnContacto)
        Me.tabRecojo.Controls.Add(Me.txtDireccion)
        Me.tabRecojo.Controls.Add(Me.Label1)
        Me.tabRecojo.Controls.Add(Me.txtContacto)
        Me.tabRecojo.Controls.Add(Me.Label13)
        Me.tabRecojo.Controls.Add(Me.Label6)
        Me.tabRecojo.Controls.Add(Me.Label10)
        Me.tabRecojo.Location = New System.Drawing.Point(4, 22)
        Me.tabRecojo.Name = "tabRecojo"
        Me.tabRecojo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRecojo.Size = New System.Drawing.Size(1016, 509)
        Me.tabRecojo.TabIndex = 1
        Me.tabRecojo.Text = "Recojo"
        Me.tabRecojo.UseVisualStyleBackColor = True
        '
        'cboEstado
        '
        Me.cboEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"(TODO)", "ACTIVO", "INACTIVO"})
        Me.cboEstado.Location = New System.Drawing.Point(878, 271)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(129, 21)
        Me.cboEstado.TabIndex = 219
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.INTEGRACION.My.Resources.Resources._1325
        Me.btnEliminar.Location = New System.Drawing.Point(979, 6)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(28, 24)
        Me.btnEliminar.TabIndex = 218
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(941, 6)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(28, 24)
        Me.btnAgregar.TabIndex = 217
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'TxtNumero
        '
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Location = New System.Drawing.Point(75, 53)
        Me.TxtNumero.MaxLength = 20
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.ReadOnly = True
        Me.TxtNumero.Size = New System.Drawing.Size(122, 20)
        Me.TxtNumero.TabIndex = 215
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(6, 56)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(45, 13)
        Me.labnroidentidad.TabIndex = 216
        Me.labnroidentidad.Text = "Nº Doc."
        '
        'txtdist
        '
        Me.txtdist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdist.Location = New System.Drawing.Point(393, 151)
        Me.txtdist.Name = "txtdist"
        Me.txtdist.ReadOnly = True
        Me.txtdist.Size = New System.Drawing.Size(110, 20)
        Me.txtdist.TabIndex = 214
        Me.txtdist.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(355, 154)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 213
        Me.Label9.Text = "Distrito"
        '
        'txtpro
        '
        Me.txtpro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpro.Location = New System.Drawing.Point(243, 151)
        Me.txtpro.Name = "txtpro"
        Me.txtpro.ReadOnly = True
        Me.txtpro.Size = New System.Drawing.Size(110, 20)
        Me.txtpro.TabIndex = 212
        Me.txtpro.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(190, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 211
        Me.Label12.Text = "Provincia"
        '
        'txtdepar
        '
        Me.txtdepar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdepar.Location = New System.Drawing.Point(75, 151)
        Me.txtdepar.Name = "txtdepar"
        Me.txtdepar.ReadOnly = True
        Me.txtdepar.Size = New System.Drawing.Size(110, 20)
        Me.txtdepar.TabIndex = 210
        Me.txtdepar.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 156)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Depart."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 131)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 207
        Me.Label14.Text = "Referencia"
        '
        'txtref
        '
        Me.txtref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtref.Location = New System.Drawing.Point(75, 129)
        Me.txtref.Name = "txtref"
        Me.txtref.ReadOnly = True
        Me.txtref.Size = New System.Drawing.Size(428, 20)
        Me.txtref.TabIndex = 208
        Me.txtref.TabStop = False
        '
        'txtmovil
        '
        Me.txtmovil.Location = New System.Drawing.Point(313, 76)
        Me.txtmovil.Name = "txtmovil"
        Me.txtmovil.ReadOnly = True
        Me.txtmovil.Size = New System.Drawing.Size(122, 20)
        Me.txtmovil.TabIndex = 205
        Me.txtmovil.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(265, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 203
        Me.Label7.Text = "Móvil"
        '
        'txttel
        '
        Me.txttel.Location = New System.Drawing.Point(75, 76)
        Me.txttel.Name = "txttel"
        Me.txttel.ReadOnly = True
        Me.txttel.Size = New System.Drawing.Size(122, 20)
        Me.txttel.TabIndex = 206
        Me.txttel.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "Tel. Fijo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(265, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 201
        Me.Label8.Text = "Email"
        '
        'txtemail
        '
        Me.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtemail.Location = New System.Drawing.Point(313, 53)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.ReadOnly = True
        Me.txtemail.Size = New System.Drawing.Size(190, 20)
        Me.txtemail.TabIndex = 204
        Me.txtemail.TabStop = False
        '
        'Panel16
        '
        Me.Panel16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel16.Controls.Add(Me.btnCancelar)
        Me.Panel16.Controls.Add(Me.btnGrabar)
        Me.Panel16.Controls.Add(Me.btnModificar)
        Me.Panel16.Controls.Add(Me.btnNuevo)
        Me.Panel16.Location = New System.Drawing.Point(2, 469)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(1006, 35)
        Me.Panel16.TabIndex = 200
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(276, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelar.TabIndex = 24
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(183, 3)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 29)
        Me.btnGrabar.TabIndex = 23
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(93, 3)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 29)
        Me.btnModificar.TabIndex = 22
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(5, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 29)
        Me.btnNuevo.TabIndex = 21
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(74, 205)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(458, 56)
        Me.txtObservacion.TabIndex = 4
        '
        'dgvProgramacion
        '
        Me.dgvProgramacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProgramacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProgramacion.Location = New System.Drawing.Point(538, 33)
        Me.dgvProgramacion.Name = "dgvProgramacion"
        Me.dgvProgramacion.Size = New System.Drawing.Size(469, 228)
        Me.dgvProgramacion.TabIndex = 198
        '
        'dgvLista
        '
        Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(7, 298)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.Size = New System.Drawing.Size(1000, 167)
        Me.dgvLista.TabIndex = 198
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(828, 275)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 196
        Me.Label3.Text = "Estado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 275)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 196
        Me.Label5.Text = "Lista de Recojos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 196
        Me.Label4.Text = "Observación"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 183)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 196
        Me.Label21.Text = "Fecha Inicio"
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.dtpInicio.CustomFormat = ""
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(75, 181)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(110, 20)
        Me.dtpInicio.TabIndex = 2
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(75, 11)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(457, 15)
        Me.lblCliente.TabIndex = 195
        Me.lblCliente.Text = "CLIENTE"
        '
        'btnDireccion
        '
        Me.btnDireccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDireccion.Location = New System.Drawing.Point(506, 106)
        Me.btnDireccion.Name = "btnDireccion"
        Me.btnDireccion.Size = New System.Drawing.Size(26, 21)
        Me.btnDireccion.TabIndex = 1
        Me.btnDireccion.Text = "..."
        Me.btnDireccion.UseVisualStyleBackColor = True
        '
        'btnContacto
        '
        Me.btnContacto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContacto.Location = New System.Drawing.Point(506, 31)
        Me.btnContacto.Name = "btnContacto"
        Me.btnContacto.Size = New System.Drawing.Size(26, 21)
        Me.btnContacto.TabIndex = 0
        Me.btnContacto.Text = "..."
        Me.btnContacto.UseVisualStyleBackColor = True
        '
        'txtDireccion
        '
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.Location = New System.Drawing.Point(75, 107)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(428, 20)
        Me.txtDireccion.TabIndex = 194
        Me.txtDireccion.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Dirección"
        '
        'txtContacto
        '
        Me.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContacto.Location = New System.Drawing.Point(75, 31)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(428, 20)
        Me.txtContacto.TabIndex = 194
        Me.txtContacto.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Contacto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(538, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Programación"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Cliente"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsbeditar, Me.TsbNuevo, Me.TSBGrabar, Me.Tsbanular, Me.Tsbactualizar, Me.TSBCalaculadora, Me.TsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(10)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1026, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TsbNuevo
        '
        Me.TsbNuevo.Image = CType(resources.GetObject("TsbNuevo.Image"), System.Drawing.Image)
        Me.TsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbNuevo.Name = "TsbNuevo"
        Me.TsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.TsbNuevo.Text = "Nuevo"
        Me.TsbNuevo.Visible = False
        '
        'Tsbeditar
        '
        Me.Tsbeditar.Enabled = False
        Me.Tsbeditar.Image = CType(resources.GetObject("Tsbeditar.Image"), System.Drawing.Image)
        Me.Tsbeditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbeditar.Name = "Tsbeditar"
        Me.Tsbeditar.Size = New System.Drawing.Size(57, 22)
        Me.Tsbeditar.Text = "Editar"
        '
        'TSBGrabar
        '
        Me.TSBGrabar.Image = CType(resources.GetObject("TSBGrabar.Image"), System.Drawing.Image)
        Me.TSBGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGrabar.Name = "TSBGrabar"
        Me.TSBGrabar.Size = New System.Drawing.Size(62, 22)
        Me.TSBGrabar.Text = "Grabar"
        Me.TSBGrabar.Visible = False
        '
        'Tsbanular
        '
        Me.Tsbanular.Enabled = False
        Me.Tsbanular.Image = CType(resources.GetObject("Tsbanular.Image"), System.Drawing.Image)
        Me.Tsbanular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbanular.Name = "Tsbanular"
        Me.Tsbanular.Size = New System.Drawing.Size(81, 22)
        Me.Tsbanular.Text = "Desactivar"
        '
        'Tsbactualizar
        '
        Me.Tsbactualizar.Enabled = False
        Me.Tsbactualizar.Image = CType(resources.GetObject("Tsbactualizar.Image"), System.Drawing.Image)
        Me.Tsbactualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbactualizar.Name = "Tsbactualizar"
        Me.Tsbactualizar.Size = New System.Drawing.Size(79, 22)
        Me.Tsbactualizar.Text = "Actualizar"
        Me.Tsbactualizar.Visible = False
        '
        'TSBCalaculadora
        '
        Me.TSBCalaculadora.Image = CType(resources.GetObject("TSBCalaculadora.Image"), System.Drawing.Image)
        Me.TSBCalaculadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCalaculadora.Name = "TSBCalaculadora"
        Me.TSBCalaculadora.Size = New System.Drawing.Size(90, 22)
        Me.TSBCalaculadora.Text = "Calculadora"
        Me.TSBCalaculadora.Visible = False
        '
        'TsbSalir
        '
        Me.TsbSalir.Image = CType(resources.GetObject("TsbSalir.Image"), System.Drawing.Image)
        Me.TsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbSalir.Name = "TsbSalir"
        Me.TsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.TsbSalir.Text = "Salir"
        '
        'frmRecojoAcordado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 564)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.tabRecojoAcordado)
        Me.Name = "frmRecojoAcordado"
        Me.Text = "Recojo Acordado"
        Me.tabRecojoAcordado.ResumeLayout(False)
        Me.tabCliente.ResumeLayout(False)
        CType(Me.dgvCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRecojo.ResumeLayout(False)
        Me.tabRecojo.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        CType(Me.dgvProgramacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabRecojoAcordado As System.Windows.Forms.TabControl
    Friend WithEvents tabCliente As System.Windows.Forms.TabPage
    Friend WithEvents tabRecojo As System.Windows.Forms.TabPage
    Friend WithEvents dgvCliente As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbeditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbanular As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbactualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCalaculadora As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents btnDireccion As System.Windows.Forms.Button
    Friend WithEvents btnContacto As System.Windows.Forms.Button
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents dgvProgramacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtmovil As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txttel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents txtdist As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtpro As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtdepar As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
