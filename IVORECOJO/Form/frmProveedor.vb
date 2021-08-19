Public Class frmProveedor
    Dim intOperacion As Operacion
    Dim intOperacionChofer As Operacion
    Dim intOperacionAyudante As Operacion
    Dim intOperacionMovil As Operacion

    Private Sub ConfigurarDGVListaProveedor()
        With dgvListaProveedor
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Documento" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razon Social" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(col_id, col_tipo, col_ruc, col_razon_social, col_id_estado, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVListaChofer()
        With dgvListaChofer
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_apellido_paterno As New DataGridViewTextBoxColumn
            With col_apellido_paterno
                .Name = "apellido_paterno" : .DataPropertyName = "apellido_paterno"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Apellido Paterno" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_apellido_materno As New DataGridViewTextBoxColumn
            With col_apellido_materno
                .Name = "apellido_materno" : .DataPropertyName = "apellido_materno"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Apellido Materno" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_licencia As New DataGridViewTextBoxColumn
            With col_licencia
                .Name = "licencia" : .DataPropertyName = "licencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Licencia" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario" : .DisplayIndex = x : .Visible = False : .HeaderText = "usuario"
            End With
            x += +1
            Dim col_contraseña As New DataGridViewTextBoxColumn
            With col_contraseña
                .Name = "contraseña" : .DataPropertyName = "contraseña" : .DisplayIndex = x : .Visible = False : .HeaderText = "contraseña"
            End With

            .Columns.AddRange(col_id, col_nombres, col_apellido_paterno, col_apellido_materno, col_licencia, col_id_estado, col_estado, col_usuario, col_contraseña)
        End With
    End Sub
    Private Sub ConfigurarDGVListaAyudante()
        With dgvListaAyudante
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_apellidos As New DataGridViewTextBoxColumn
            With col_apellidos
                .Name = "apellidos" : .DataPropertyName = "apellidos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Apellidos" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(col_id, col_nombres, col_apellidos, col_id_estado, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVListaMovil()
        With dgvListaMovil
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_placa As New DataGridViewTextBoxColumn
            With col_placa
                .Name = "placa" : .DataPropertyName = "placa"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Placa" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_capacidad As New DataGridViewTextBoxColumn
            With col_capacidad
                .Name = "capacidad" : .DataPropertyName = "capacidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Capacidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_modelo As New DataGridViewTextBoxColumn
            With col_modelo
                .Name = "modelo" : .DataPropertyName = "modelo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Modelo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_idmodelo As New DataGridViewTextBoxColumn
            With col_idmodelo
                .Name = "idmodelo" : .DataPropertyName = "idmodelo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idmodelo"
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(col_id, col_placa, col_capacidad, col_tipo, col_modelo, col_idtipo, col_idmodelo, col_id_estado, col_estado)
        End With
    End Sub

    Private Sub frmProveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ConfigurarDGVListaProveedor()
        Me.ConfigurarDGVListaChofer()
        Me.ConfigurarDGVListaAyudante()
        Me.ConfigurarDGVListaMovil()

        Me.ListarTipoUnidad()
        Me.ListarModeloUnidad()

        Me.cboEstadoProveedor.SelectedIndex = 1

        RemoveHandler cboEstadoChofer.SelectedIndexChanged, AddressOf cboEstadoChofer_SelectedIndexChanged
        Me.cboEstadoChofer.SelectedIndex = 1
        AddHandler cboEstadoChofer.SelectedIndexChanged, AddressOf cboEstadoChofer_SelectedIndexChanged

        RemoveHandler cboEstadoAyudante.SelectedIndexChanged, AddressOf cboEstadoAyudante_SelectedIndexChanged
        Me.cboEstadoAyudante.SelectedIndex = 1
        AddHandler cboEstadoAyudante.SelectedIndexChanged, AddressOf cboEstadoAyudante_SelectedIndexChanged

        RemoveHandler cboEstadoMovil.SelectedIndexChanged, AddressOf cboEstadoMovil_SelectedIndexChanged
        Me.cboEstadoMovil.SelectedIndex = 1
        AddHandler cboEstadoMovil.SelectedIndexChanged, AddressOf cboEstadoMovil_SelectedIndexChanged

        ActivaDesactivaProveedor(0)
        ActivaDesactivaChofer(0)
        ActivaDesactivaAyudante(0)
        ActivaDesactivaMovil(0)
    End Sub

    Sub ActivaDesactivaProveedor(ByVal estado As Integer)
        Me.txtRucProveedor.Enabled = False
        Me.txtRazonSocialProveedor.Enabled = False
        Me.chkActivoProveedor.Enabled = False
        If estado = 0 Then
            Me.btnNuevoProveedor.Enabled = True
            Me.btnModificarProveedor.Enabled = Me.dgvListaProveedor.Rows.Count > 0
            Me.btnGrabarProveedor.Enabled = False
            Me.btnCancelarProveedor.Enabled = False
        ElseIf estado = 1 Then
            Me.txtRucProveedor.Enabled = True
            Me.txtRazonSocialProveedor.Enabled = True
            Me.chkActivoProveedor.Enabled = True

            Me.btnNuevoProveedor.Enabled = False
            Me.btnModificarProveedor.Enabled = False
            Me.btnGrabarProveedor.Enabled = True
            Me.btnCancelarProveedor.Enabled = True
        ElseIf estado = 2 Then
            Me.txtRazonSocialProveedor.Enabled = True
            Me.chkActivoProveedor.Enabled = True

            Me.btnNuevoProveedor.Enabled = False
            Me.btnModificarProveedor.Enabled = False
            Me.btnGrabarProveedor.Enabled = True
            Me.btnCancelarProveedor.Enabled = True
        ElseIf estado = 3 Then
            Me.btnNuevoProveedor.Enabled = True
            Me.btnModificarProveedor.Enabled = True
            Me.btnGrabarProveedor.Enabled = False
            Me.btnCancelarProveedor.Enabled = False
        End If
    End Sub

    Sub LimpiarProveedor()
        Me.txtRucProveedor.Text = ""
        Me.txtRazonSocialProveedor.Text = ""
        Me.chkActivoProveedor.Checked = True
    End Sub

    Private Sub btnNuevoProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoProveedor.Click
        intOperacion = Operacion.Nuevo
        Me.LimpiarProveedor()
        ActivaDesactivaProveedor(1)
        Me.txtRucProveedor.Focus()
    End Sub

    Private Sub btnCancelarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarProveedor.Click
        LimpiarProveedor()
        ActivaDesactivaProveedor(0)
        If Me.dgvListaProveedor.Rows.Count > 0 Then
            Dim intFila As Integer = Me.dgvListaProveedor.CurrentCell.RowIndex
            MostrarProveedor(intFila)
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoProveedor.Focus()
        Else
            btnModificarProveedor.Focus()
        End If
    End Sub

    Private Sub btnGrabarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarProveedor.Click
        If Not fnValidarRUC(Me.txtRucProveedor.Text) Then
            MessageBox.Show("Ingrese un RUC válido", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRucProveedor.Focus()
            Return
        End If

        If txtRazonSocialProveedor.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la razón social del proveedor", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRazonSocialProveedor.Text = ""
            Me.txtRazonSocialProveedor.Focus()
            Return
        End If

        GrabarProveedor()
    End Sub

    Sub GrabarProveedor()
        Try
            Cursor = Cursors.AppStarting
            Dim intID As Integer
            Dim obj As New DtoRecojo

            If intOperacion = Operacion.Nuevo Then
                intID = 0
            Else
                intID = Me.dgvListaProveedor.CurrentRow.Cells("id").Value
            End If
            obj.GrabarProveedor(intID, Me.txtRucProveedor.Text.Trim, Me.txtRazonSocialProveedor.Text.Trim, dtoUSUARIOS.m_idciudad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, IIf(Me.chkActivoProveedor.Checked, 1, 2))
            Me.cboEstadoProveedor_SelectedIndexChanged(Nothing, Nothing)
            ActivaDesactivaProveedor(3)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarProveedor(ByVal estado As Integer)
        Dim obj As New DtoRecojo
        Dim dt As DataTable = obj.ListarProveedor(dtoUSUARIOS.m_idciudad, estado)
        Me.dgvListaProveedor.DataSource = dt
    End Sub

    Private Sub cboEstadoProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoProveedor.SelectedIndexChanged
        ListarProveedor(cboEstadoProveedor.SelectedIndex)
        Me.ActivaDesactivaProveedor(0)
        If Me.dgvListaProveedor.Rows.Count = 0 Then
            Me.LimpiarProveedor()
            Me.btnNuevoProveedor.Focus()
        End If
    End Sub

    Sub MostrarProveedor(ByVal fila As Integer)
        Me.txtRucProveedor.Text = Me.dgvListaProveedor.Rows(fila).Cells("ruc").Value
        Me.txtRazonSocialProveedor.Text = Me.dgvListaProveedor.Rows(fila).Cells("razon_social").Value
        Me.chkActivoProveedor.Checked = Me.dgvListaProveedor.Rows(fila).Cells("id_estado").Value = 1
    End Sub

    Private Sub dgvListaProveedor_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaProveedor.RowEnter
        If IsReference(dgvListaProveedor.Rows(e.RowIndex).Cells("id").Value) Then Return
        intOperacion = Operacion.Modificar
        MostrarProveedor(e.RowIndex)
    End Sub

    Private Sub btnModificarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarProveedor.Click
        intOperacion = Operacion.Modificar
        ActivaDesactivaProveedor(2)
        Me.txtRazonSocialProveedor.Focus()
    End Sub

    Private Sub txtRucProveedor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedor.Enter
        Me.txtRucProveedor.SelectAll()
    End Sub

    Private Sub txtRucProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtRazonSocialProveedor.Focus()
        Else
            e.Handled = Not ValidarNumero(e.KeyChar)
        End If
    End Sub

    Private Sub txtRazonSocialProveedor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedor.Enter
        Me.txtRazonSocialProveedor.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnGrabarProveedor.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Sub ActivaDesactivaChofer(ByVal estado As Integer)
        Me.txtNombresChofer.Enabled = False
        Me.txtApellidoPaterno.Enabled = False
        Me.txtApellidoMaterno.Enabled = False
        Me.txtLicenciaChofer.Enabled = False
        Me.chkActivoChofer.Enabled = False
        Me.txtUsuario.Enabled = False
        Me.txtContraseña.Enabled = False
        If estado = 0 Then
            Me.btnNuevoChofer.Enabled = Me.dgvListaProveedor.Rows.Count > 0
            Me.btnModificarChofer.Enabled = Me.dgvListaChofer.Rows.Count > 0
            Me.btnGrabarChofer.Enabled = False
            Me.btnCancelarChofer.Enabled = False
        ElseIf estado = 1 Then
            Me.txtNombresChofer.Enabled = True
            Me.txtApellidoPaterno.Enabled = True
            Me.txtApellidoMaterno.Enabled = True
            Me.txtLicenciaChofer.Enabled = True
            Me.chkActivoChofer.Enabled = True
            Me.txtUsuario.Enabled = True
            Me.txtContraseña.Enabled = True

            Me.btnNuevoChofer.Enabled = False
            Me.btnModificarChofer.Enabled = False
            Me.btnGrabarChofer.Enabled = True
            Me.btnCancelarchofer.Enabled = True
        ElseIf estado = 2 Then
            Me.txtNombresChofer.Enabled = True
            Me.txtApellidoPaterno.Enabled = True
            Me.txtApellidoMaterno.Enabled = True
            Me.txtLicenciaChofer.Enabled = True
            Me.chkActivoChofer.Enabled = True
            Me.txtUsuario.Enabled = True
            Me.txtContraseña.Enabled = True

            Me.btnNuevoChofer.Enabled = False
            Me.btnModificarChofer.Enabled = False
            Me.btnGrabarChofer.Enabled = True
            Me.btnCancelarchofer.Enabled = True
        ElseIf estado = 3 Then
            Me.btnNuevoChofer.Enabled = True
            Me.btnModificarChofer.Enabled = True
            Me.btnGrabarChofer.Enabled = False
            Me.btnCancelarchofer.Enabled = False
        End If
    End Sub

    Sub LimpiarChofer()
        Me.txtNombresChofer.Text = ""
        Me.txtApellidoPaterno.Text = ""
        Me.txtApellidoMaterno.Text = ""
        Me.txtLicenciaChofer.Text = ""
        Me.chkActivoChofer.Checked = True
        Me.txtUsuario.Text = ""
        Me.txtContraseña.Text = ""
    End Sub

    Sub MostrarChofer(ByVal fila As Integer)
        Me.txtNombresChofer.Text = Me.dgvListaChofer.Rows(fila).Cells("nombres").Value
        Me.txtApellidoPaterno.Text = Me.dgvListaChofer.Rows(fila).Cells("apellido_paterno").Value
        Me.txtApellidoMaterno.Text = Me.dgvListaChofer.Rows(fila).Cells("apellido_materno").Value
        Me.txtLicenciaChofer.Text = Me.dgvListaChofer.Rows(fila).Cells("licencia").Value
        Me.chkActivoChofer.Checked = Me.dgvListaChofer.Rows(fila).Cells("id_estado").Value = 1
        Me.txtUsuario.Text = Me.dgvListaChofer.Rows(fila).Cells("usuario").Value()
        Me.txtContraseña.Text = Me.dgvListaChofer.Rows(fila).Cells("contraseña").Value()
    End Sub

    Private Sub btnNuevoChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoChofer.Click
        intOperacionChofer = Operacion.Nuevo
        Me.LimpiarChofer()
        ActivaDesactivaChofer(1)
        Me.txtNombresChofer.Focus()
    End Sub

    Private Sub btnModificarChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarChofer.Click
        intOperacionChofer = Operacion.Modificar
        ActivaDesactivaChofer(2)
        Me.txtNombresChofer.Focus()
    End Sub

    Private Sub btnCancelarChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarChofer.Click
        LimpiarChofer()
        ActivaDesactivaChofer(0)
        If Me.dgvListaChofer.Rows.Count > 0 Then
            Dim intFila As Integer = Me.dgvListaChofer.CurrentCell.RowIndex
            MostrarChofer(intFila)
        End If
        If intOperacionChofer = Operacion.Nuevo Then
            btnNuevoChofer.Focus()
        Else
            btnModificarChofer.Focus()
        End If
    End Sub

    Private Sub btnGrabarChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarChofer.Click
        If txtNombresChofer.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese nombres del chofer", "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombresChofer.Text = ""
            Me.txtNombresChofer.Focus()
            Return
        End If

        If txtApellidoPaterno.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese apellido paterno del chofer", "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtApellidoPaterno.Text = ""
            Me.txtApellidoPaterno.Focus()
            Return
        End If
        If txtApellidoMaterno.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese apellido materno del chofer", "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtApellidoMaterno.Text = ""
            Me.txtApellidoMaterno.Focus()
            Return
        End If

        If txtLicenciaChofer.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nº de licencia del chofer", "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtLicenciaChofer.Text = ""
            Me.txtLicenciaChofer.Focus()
            Return
        End If

        If Me.txtUsuario.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese usuario", "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtUsuario.Text = ""
            Me.txtUsuario.Focus()
            Return
        End If

        If Me.txtContraseña.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese contraseña", "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtContraseña.Text = ""
            Me.txtContraseña.Focus()
            Return
        End If

        GrabarChofer()
    End Sub

    Sub ListarChofer(ByVal estado As Integer)
        Dim obj As New DtoRecojo

        If Me.dgvListaProveedor.Rows.Count > 0 Then
            Dim intProveedor As Integer = Me.dgvListaProveedor.CurrentRow.Cells("id").Value
            Dim dt As DataTable = obj.ListarChofer(dtoUSUARIOS.m_idciudad, intProveedor, estado)
            Me.dgvListaChofer.DataSource = dt
        Else
            Me.dgvListaChofer.DataSource = Nothing
        End If
    End Sub

    Private Sub cboEstadoChofer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoChofer.SelectedIndexChanged
        ListarChofer(cboEstadoChofer.SelectedIndex)
        Me.ActivaDesactivaChofer(0)
        If Me.dgvListaChofer.Rows.Count = 0 Then
            Me.LimpiarChofer()
            Me.btnNuevoChofer.Focus()
        End If
    End Sub

    Private Sub dgvListaChofer_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaChofer.RowEnter
        If IsReference(dgvListaChofer.Rows(e.RowIndex).Cells("id").Value) Then Return
        intOperacionChofer = Operacion.Modificar
        MostrarChofer(e.RowIndex)
    End Sub

    Sub GrabarChofer()
        Try
            Cursor = Cursors.AppStarting
            Dim intID As Integer, intUsuarioPersonal As Integer
            Dim obj As New DtoRecojo

            If intOperacionChofer = Operacion.Nuevo Then
                intID = 0
                intUsuarioPersonal = 0
            Else
                intID = Me.dgvListaChofer.CurrentRow.Cells("id").Value
                intUsuarioPersonal = Me.dgvListaChofer.CurrentRow.Cells("idusuario_personal").Value
            End If
            Dim intProveedor As Integer = Me.dgvListaProveedor.CurrentRow.Cells("id").Value
            obj.GrabarChofer(intID, Me.txtNombresChofer.Text.Trim, Me.txtApellidoPaterno.Text.Trim, Me.txtApellidoMaterno.Text.Trim, Me.txtLicenciaChofer.Text.Trim, dtoUSUARIOS.m_idciudad, intProveedor, dtoUSUARIOS.IdLogin, _
                             dtoUSUARIOS.IP, IIf(Me.chkActivoChofer.Checked, 1, 2), intUsuarioPersonal, Me.txtUsuario.Text.Trim, Me.txtContraseña.Text.Trim)
            Me.cboEstadoChofer_SelectedIndexChanged(Nothing, Nothing)
            ActivaDesactivaChofer(3)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNombresChofer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombresChofer.Enter
        Me.txtNombresChofer.SelectAll()
    End Sub

    Private Sub txtNombresChofer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombresChofer.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtApellidoPaterno.Focus()
        End If
    End Sub

    Private Sub txtApellidoPaterno_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApellidoPaterno.Enter
        Me.txtApellidoPaterno.SelectAll()
    End Sub

    Private Sub txtApellidoPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidoPaterno.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtApellidoMaterno.Focus()
        End If
    End Sub

    Private Sub txtLicenciaChofer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLicenciaChofer.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtUsuario.Focus()
        End If
    End Sub

    Sub LimpiarAyudante()
        Me.txtNombresAyudante.Text = ""
        Me.txtApellidosAyudante.Text = ""
        Me.chkActivoAyudante.Checked = True
    End Sub

    Sub ActivaDesactivaAyudante(ByVal estado As Integer)
        Me.txtNombresAyudante.Enabled = False
        Me.txtApellidosAyudante.Enabled = False
        Me.chkActivoAyudante.Enabled = False
        If estado = 0 Then
            Me.btnNuevoAyudante.Enabled = Me.dgvListaProveedor.Rows.Count > 0
            Me.btnModificarAyudante.Enabled = Me.dgvListaAyudante.Rows.Count > 0
            Me.btnGrabarAyudante.Enabled = False
            Me.btnCancelarAyudante.Enabled = False
        ElseIf estado = 1 Then
            Me.txtNombresAyudante.Enabled = True
            Me.txtApellidosAyudante.Enabled = True
            Me.chkActivoAyudante.Enabled = True

            Me.btnNuevoAyudante.Enabled = False
            Me.btnModificarAyudante.Enabled = False
            Me.btnGrabarAyudante.Enabled = True
            Me.btnCancelarAyudante.Enabled = True
        ElseIf estado = 2 Then
            Me.txtNombresAyudante.Enabled = True
            Me.txtApellidosAyudante.Enabled = True
            Me.chkActivoAyudante.Enabled = True

            Me.btnNuevoAyudante.Enabled = False
            Me.btnModificarAyudante.Enabled = False
            Me.btnGrabarAyudante.Enabled = True
            Me.btnCancelarAyudante.Enabled = True
        ElseIf estado = 3 Then
            Me.btnNuevoAyudante.Enabled = True
            Me.btnModificarAyudante.Enabled = True
            Me.btnGrabarAyudante.Enabled = False
            Me.btnCancelarAyudante.Enabled = False
        End If
    End Sub

    Sub MostrarAyudante(ByVal fila As Integer)
        Me.txtNombresAyudante.Text = Me.dgvListaAyudante.Rows(fila).Cells("nombres").Value
        Me.txtApellidosAyudante.Text = Me.dgvListaAyudante.Rows(fila).Cells("apellidos").Value
        Me.chkActivoAyudante.Checked = Me.dgvListaAyudante.Rows(fila).Cells("id_estado").Value = 1
    End Sub

    Private Sub btnNuevoAyudante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoAyudante.Click
        intOperacionAyudante = Operacion.Nuevo
        Me.LimpiarAyudante()
        ActivaDesactivaAyudante(1)
        Me.txtNombresAyudante.Focus()
    End Sub

    Private Sub btnModificarAyudante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarAyudante.Click
        intOperacionAyudante = Operacion.Modificar
        ActivaDesactivaAyudante(2)
        Me.txtNombresAyudante.Focus()
    End Sub

    Private Sub btnCancelarAyudante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarAyudante.Click
        LimpiarAyudante()
        ActivaDesactivaAyudante(0)
        If Me.dgvListaAyudante.Rows.Count > 0 Then
            Dim intFila As Integer = Me.dgvListaAyudante.CurrentCell.RowIndex
            MostrarAyudante(intFila)
        End If
        If intOperacionAyudante = Operacion.Nuevo Then
            btnNuevoAyudante.Focus()
        Else
            btnModificarAyudante.Focus()
        End If
    End Sub

    Private Sub btnGrabarAyudante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarAyudante.Click
        If txtNombresAyudante.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese nombres del ayudante", "Ayudante", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombresAyudante.Text = ""
            Me.txtNombresAyudante.Focus()
            Return
        End If

        If txtApellidosAyudante.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese apellidos del ayudante", "Ayudante", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtApellidosAyudante.Text = ""
            Me.txtApellidosAyudante.Focus()
            Return
        End If

        GrabarAyudante()
    End Sub

    Sub GrabarAyudante()
        Try
            Cursor = Cursors.AppStarting
            Dim intID As Integer
            Dim obj As New DtoRecojo

            Dim intProveedor As Integer = Me.dgvListaProveedor.CurrentRow.Cells("id").Value
            If intOperacionAyudante = Operacion.Nuevo Then
                intID = 0
            Else
                intID = Me.dgvListaAyudante.CurrentRow.Cells("id").Value
            End If
            obj.GrabarAyudante(intID, Me.txtNombresAyudante.Text.Trim, Me.txtApellidosAyudante.Text.Trim, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, IIf(Me.chkActivoAyudante.Checked, 1, 2), dtoUSUARIOS.m_idciudad, intProveedor)
            Me.cboEstadoAyudante_SelectedIndexChanged(Nothing, Nothing)
            ActivaDesactivaAyudante(3)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Ayudante", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarAyudante(ByVal estado As Integer)
        Dim obj As New DtoRecojo

        If Me.dgvListaProveedor.Rows.Count > 0 Then
            Dim intProveedor As Integer = Me.dgvListaProveedor.CurrentRow.Cells("id").Value
            Dim dt As DataTable = obj.ListarAyudante(estado, dtoUSUARIOS.m_idciudad, intProveedor)
            Me.dgvListaAyudante.DataSource = dt
        Else
            Me.dgvListaAyudante.DataSource = Nothing
        End If
    End Sub

    Private Sub cboEstadoAyudante_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEstadoAyudante.SelectedIndexChanged
        ListarAyudante(cboEstadoAyudante.SelectedIndex)
        Me.ActivaDesactivaAyudante(0)
        If Me.dgvListaAyudante.Rows.Count = 0 Then
            Me.LimpiarAyudante()
            Me.btnNuevoAyudante.Focus()
        End If
    End Sub

    Private Sub dgvListaAyudante_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaAyudante.RowEnter
        If IsReference(dgvListaAyudante.Rows(e.RowIndex).Cells("id").Value) Then Return
        intOperacionAyudante = Operacion.Modificar
        MostrarAyudante(e.RowIndex)
    End Sub

    Private Sub txtNombresAyudante_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombresAyudante.Enter
        Me.txtNombresAyudante.SelectAll()
    End Sub

    Private Sub txtApellidosAyudante_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApellidosAyudante.Enter
        Me.txtApellidosAyudante.SelectAll()
    End Sub

    Private Sub txtNombresAyudante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombresAyudante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtApellidosAyudante.Focus()
        End If
    End Sub

    Private Sub txtApellidosAyudante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidosAyudante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnGrabarAyudante.Focus()
        End If
    End Sub

    Sub LimpiarMovil()
        Me.txtPlacaMovil.Text = ""
        Me.txtCapacidadMovil.Text = ""
        Me.cboTipoMovil.SelectedValue = 0
        Me.cboModeloMovil.SelectedValue = 0
        Me.chkActivoMovil.Checked = True
    End Sub

    Sub ActivaDesactivaMovil(ByVal estado As Integer)
        Me.txtPlacaMovil.Enabled = False
        Me.txtCapacidadMovil.Enabled = False
        Me.cboTipoMovil.Enabled = False
        Me.cboModeloMovil.Enabled = False
        Me.chkActivoMovil.Enabled = False
        If estado = 0 Then
            Me.btnNuevoMovil.Enabled = Me.dgvListaProveedor.Rows.Count > 0
            Me.btnModificarMovil.Enabled = Me.dgvListaMovil.Rows.Count > 0
            Me.btnGrabarMovil.Enabled = False
            Me.btnCancelarMovil.Enabled = False
        ElseIf estado = 1 Then
            Me.txtPlacaMovil.Enabled = True
            Me.txtCapacidadMovil.Enabled = True
            Me.cboTipoMovil.Enabled = True
            Me.cboModeloMovil.Enabled = True
            Me.chkActivoMovil.Enabled = True

            Me.btnNuevoMovil.Enabled = False
            Me.btnModificarMovil.Enabled = False
            Me.btnGrabarMovil.Enabled = True
            Me.btnCancelarMovil.Enabled = True
        ElseIf estado = 2 Then
            'Me.txtPlacaMovil.Enabled = True
            Me.txtCapacidadMovil.Enabled = True
            Me.cboTipoMovil.Enabled = True
            Me.cboModeloMovil.Enabled = True
            Me.chkActivoMovil.Enabled = True

            Me.btnNuevoMovil.Enabled = False
            Me.btnModificarMovil.Enabled = False
            Me.btnGrabarMovil.Enabled = True
            Me.btnCancelarMovil.Enabled = True
        ElseIf estado = 3 Then
            Me.btnNuevoMovil.Enabled = True
            Me.btnModificarMovil.Enabled = True
            Me.btnGrabarMovil.Enabled = False
            Me.btnCancelarMovil.Enabled = False
        End If
    End Sub

    Sub MostrarMovil(ByVal fila As Integer)
        Me.txtPlacaMovil.Text = Me.dgvListaMovil.Rows(fila).Cells("placa").Value
        Me.txtCapacidadMovil.Text = Me.dgvListaMovil.Rows(fila).Cells("capacidad").Value
        Me.cboTipoMovil.SelectedValue = Me.dgvListaMovil.Rows(fila).Cells("idtipo").Value
        Me.cboModeloMovil.SelectedValue = Me.dgvListaMovil.Rows(fila).Cells("idmodelo").Value
        Me.chkActivoMovil.Checked = Me.dgvListaMovil.Rows(fila).Cells("id_estado").Value = 1
    End Sub

    Private Sub btnNuevoMovil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoMovil.Click
        intOperacionMovil = Operacion.Nuevo
        Me.LimpiarMovil()
        ActivaDesactivaMovil(1)
        Me.txtPlacaMovil.Focus()
    End Sub

    Private Sub btnModificarMovil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarMovil.Click
        intOperacionMovil = Operacion.Modificar
        ActivaDesactivaMovil(2)
        Me.txtPlacaMovil.Focus()
    End Sub

    Private Sub btnCancelarMovil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarMovil.Click
        LimpiarMovil()
        ActivaDesactivaMovil(0)
        If Me.dgvListaMovil.Rows.Count > 0 Then
            Dim intFila As Integer = Me.dgvListaMovil.CurrentCell.RowIndex
            MostrarMovil(intFila)
        End If
        If intOperacionMovil = Operacion.Nuevo Then
            btnNuevoMovil.Focus()
        Else
            btnModificarMovil.Focus()
        End If
    End Sub

    Private Sub btnGrabarMovil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarMovil.Click
        If txtPlacaMovil.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nº de placa", "Móvil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPlacaMovil.Text = ""
            Me.txtPlacaMovil.Focus()
            Return
        End If

        If Me.cboTipoMovil.SelectedValue = 0 Then
            MessageBox.Show("Seleccione tipo de móvil", "Móvil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoMovil.Focus()
            Me.cboTipoMovil.DroppedDown = True
            Return
        End If

        If Me.cboModeloMovil.SelectedValue = 0 Then
            MessageBox.Show("Seleccione modelo de la móvil", "Móvil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboModeloMovil.Focus()
            Me.cboModeloMovil.DroppedDown = True
            Return
        End If

        GrabarMovil()
    End Sub

    Sub GrabarMovil()
        Try
            Cursor = Cursors.AppStarting
            Dim intID As Integer
            Dim obj As New DtoRecojo
            Dim intProveedor As Integer = Me.dgvListaProveedor.CurrentRow.Cells("id").Value

            If intOperacionMovil = Operacion.Nuevo Then
                intID = 0
            Else
                intID = Me.dgvListaMovil.CurrentRow.Cells("id").Value
            End If
            obj.GrabarMovil(intID, dtoUSUARIOS.m_idciudad, Me.txtPlacaMovil.Text.Trim, Me.txtCapacidadMovil.Text.Trim, cboTipoMovil.SelectedValue, cboModeloMovil.SelectedValue, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, IIf(Me.chkActivoMovil.Checked, 1, 2), intProveedor)
            Me.cboEstadoMovil_SelectedIndexChanged(Nothing, Nothing)
            ActivaDesactivaMovil(3)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarMovil(ByVal estado As Integer)
        Dim obj As New DtoRecojo
        If Me.dgvListaProveedor.Rows.Count > 0 Then
            Dim intProveedor As Integer = Me.dgvListaProveedor.CurrentRow.Cells("id").Value
            Dim dt As DataTable = obj.ListarMovil(dtoUSUARIOS.m_idciudad, intProveedor, estado)
            Me.dgvListaMovil.DataSource = dt
        Else
            Me.dgvListaMovil.DataSource = Nothing
        End If
    End Sub

    Private Sub cboEstadoMovil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoMovil.SelectedIndexChanged
        ListarMovil(cboEstadoMovil.SelectedIndex)
        Me.ActivaDesactivaMovil(0)
        If Me.dgvListaMovil.Rows.Count = 0 Then
            Me.LimpiarMovil()
            Me.btnNuevoMovil.Focus()
        End If
    End Sub

    Private Sub dgvListaMovil_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaMovil.RowEnter
        If IsReference(dgvListaMovil.Rows(e.RowIndex).Cells("id").Value) Then Return
        intOperacionMovil = Operacion.Modificar
        MostrarMovil(e.RowIndex)
    End Sub

    Private Sub txtPlacaMovil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlacaMovil.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtCapacidadMovil.Focus()
        End If
    End Sub

    Private Sub txtCapacidadMovil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCapacidadMovil.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.cboTipoMovil.Focus()
        Else
            e.Handled = Not ValidarNumero(e.KeyChar)
        End If
    End Sub

    Private Sub cboTipoMovil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoMovil.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.cboModeloMovil.Focus()
        End If
    End Sub

    Private Sub cboModeloMovil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboModeloMovil.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnGrabarMovil.Focus()
        End If
    End Sub

    Sub ListarTipoUnidad()
        Dim obj As New DtoRecojo
        Dim dt As DataTable = obj.ListarTipoUnidad
        With Me.cboTipoMovil
            .ValueMember = "id"
            .DisplayMember = "tipo"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarModeloUnidad()
        Dim obj As New DtoRecojo
        Dim dt As DataTable = obj.ListarModeloUnidad
        With Me.cboModeloMovil
            .ValueMember = "id"
            .DisplayMember = "modelo"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub tabProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabProveedor.SelectedIndexChanged
        If tabProveedor.SelectedIndex = 1 Then
            Me.cboEstadoMovil_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabProveedor.SelectedIndex = 2 Then
            Me.cboEstadoChofer_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabProveedor.SelectedIndex = 3 Then
            Me.cboEstadoAyudante_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtUsuario_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario.Enter
        Me.txtUsuario.SelectAll()
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtContraseña.Focus()
        End If
    End Sub

    Private Sub txtContraseña_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContraseña.Enter
        Me.txtContraseña.SelectAll()
    End Sub

    Private Sub txtContraseña_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContraseña.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnGrabarChofer.Focus()
        End If
    End Sub

    Private Sub txtApellidoMaterno_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApellidoMaterno.Enter
        Me.txtApellidoMaterno.SelectAll()
    End Sub

    Private Sub txtApellidoMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidoMaterno.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtLicenciaChofer.Focus()
        End If
    End Sub

    Private Sub txtCapacidadMovil_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCapacidadMovil.TextChanged

    End Sub
End Class