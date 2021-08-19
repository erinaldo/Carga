Public Class frmRuta
    Dim dtDepartamento As DataTable, dtProvincia As DataTable, dtDistrito As DataTable
    Dim intOpcion As Integer

    Sub ConfigurardgvLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .HeaderText = "Nº"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_ruta As New DataGridViewTextBoxColumn
            With col_ruta
                .Name = "ruta" : .DataPropertyName = "ruta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ruta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_color As New DataGridViewTextBoxColumn
            With col_color
                .Name = "color" : .DataPropertyName = "color" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_strcolor As New DataGridViewTextBoxColumn
            With col_strcolor
                .Name = "strcolor" : .DataPropertyName = "strcolor"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Color"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_ruta, col_usuario, col_color, col_strcolor)
        End With
    End Sub

    Sub ConfigurardgvDetalle()
        With dgvDetalle
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .HeaderText = "id_det" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            x += +1
            Dim col_departamento As New DataGridViewTextBoxColumn
            With col_departamento
                .Name = "departamento" : .DataPropertyName = "departamento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Departamento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_provincia As New DataGridViewTextBoxColumn
            With col_provincia
                .Name = "provincia" : .DataPropertyName = "provincia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Provincia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_distrito As New DataGridViewTextBoxColumn
            With col_distrito
                .Name = "distrito" : .DataPropertyName = "distrito"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Distrito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_iddepartamento As New DataGridViewTextBoxColumn
            With col_iddepartamento
                .Name = "iddepartamento" : .DataPropertyName = "iddepartamento" : .DisplayIndex = x : .HeaderText = "iddepartamento" : .Visible = False
            End With

            x += +1
            Dim col_idprovincia As New DataGridViewTextBoxColumn
            With col_idprovincia
                .Name = "idprovincia" : .DataPropertyName = "idprovincia" : .DisplayIndex = x : .HeaderText = "idprovincia" : .Visible = False
            End With

            x += +1
            Dim col_iddistrito As New DataGridViewTextBoxColumn
            With col_iddistrito
                .Name = "iddistrito" : .DataPropertyName = "iddistrito" : .DisplayIndex = x : .HeaderText = "iddistrito" : .Visible = False
            End With

            .Columns.AddRange(col_id, col_id_det, col_departamento, col_provincia, col_distrito, col_iddepartamento, col_idprovincia, col_iddistrito)
        End With
    End Sub

    Private Sub frmRuta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim obj As New dtrecojo
        Dim dt As DataTable = ListarTipoControl(24, 2)
        With Me.cboColor
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "CODIGO"
            .DataSource = dt
            .SelectedValue = 0
        End With

        Dim ds As New DataSet
        ds = obj.ListarUbigeo
        dtDepartamento = ds.Tables(1)
        dtProvincia = ds.Tables(2)
        dtDistrito = ds.Tables(3)

        cboDepartamento.DataSource = dtDepartamento
        cboDepartamento.DisplayMember = "departamento"
        cboDepartamento.ValueMember = "iddepartamento"
        cboDepartamento.SelectedValue = 15

        cboProvincia.DataSource = dtProvincia
        cboProvincia.DisplayMember = "provincia"
        cboProvincia.ValueMember = "idprovincia"
        cboProvincia.SelectedValue = 17

        cboDistrito.DataSource = dtDistrito
        cboDistrito.DisplayMember = "dsitrito"
        cboDistrito.ValueMember = "iddistrito"

        Me.ConfigurardgvLista()
        Me.ConfigurardgvDetalle()
    End Sub

    Private Sub CboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.SelectedIndexChanged
        If Not CboDepartamento.SelectedValue Is Nothing And Not IsReference(CboDepartamento.SelectedValue) Then
            Try
                Dim iDepartamento As Integer = cboDepartamento.SelectedValue
                Dim sFiltro As String = "(iddepartamento=" & iDepartamento & " Or iddepartamento=0)"
                dtProvincia.DefaultView.RowFilter = sFiltro
                CboProvincia_SelectedIndexChanged(sender, e)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub CboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        If Not CboProvincia.SelectedValue Is Nothing And Not IsReference(CboProvincia.SelectedValue) Then
            Try
                Dim iprovincia As Integer = CboProvincia.SelectedValue
                Dim iDepartamento As Integer = cboDepartamento.SelectedValue
                Dim sFiltro As String = "(iddepartamento=" & iDepartamento & " or iddepartamento=0) and (idprovincia=" & iprovincia & " Or idprovincia=0)"
                dtDistrito.DefaultView.RowFilter = sFiltro
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New DtoRecojo
            Dim dt As DataTable = obj.ListarRuta(Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, dtoUSUARIOS.m_idciudad)
            Me.dgvLista.DataSource = dt

            If Me.dgvLista.Rows.Count = 0 Then
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            Else
                Me.tsbEditar.Enabled = True
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick

    End Sub

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        With Me.dgvLista
            Dim strFecha As String = .Rows(e.RowIndex).Cells("fecha").Value
            If CDate(strFecha) = Format(FechaServidor, "Short Date") Then
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbAnular.Enabled = False
            End If
        End With
    End Sub

    Sub Limpiar()
        'Me.lblFecha.Text = Now.ToShortDateString
        Me.dtpFecha.Value = Now.ToShortDateString
        Me.dtpFecha.Enabled = True
        Me.txtNombre.Text = ""
        Me.cboColor.SelectedValue = 0
        Me.cboDepartamento.SelectedValue = 15
        Me.cboProvincia.SelectedValue = 17
        Me.cboDistrito.SelectedValue = 0
        Me.dgvDetalle.Rows.Clear()
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Limpiar()
        intOpcion = 1
        Me.tabRuta.SelectedIndex = 1
        Me.txtNombre.Focus()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Limpiar()
        'Me.lblFecha.Text = Me.dgvLista.CurrentRow.Cells("fecha").Value
        Me.dtpFecha.Value = Me.dgvLista.CurrentRow.Cells("fecha").Value
        Me.dtpFecha.Enabled = False
        Me.txtNombre.Text = Me.dgvLista.CurrentRow.Cells("ruta").Value
        Me.cboColor.SelectedValue = Me.dgvLista.CurrentRow.Cells("color").Value

        Dim obj As New DtoRecojo
        Dim dt As DataTable = obj.ListarRutaDetalle(Me.dgvLista.CurrentRow.Cells("id").Value)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                With Me.dgvDetalle
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells("id").Value = row("id")
                    .Rows(.Rows.Count - 1).Cells("id_det").Value = row("id_det")
                    .Rows(.Rows.Count - 1).Cells("departamento").Value = row("departamento")
                    .Rows(.Rows.Count - 1).Cells("provincia").Value = row("provincia")
                    .Rows(.Rows.Count - 1).Cells("distrito").Value = row("distrito")
                    .Rows(.Rows.Count - 1).Cells("iddepartamento").Value = row("iddepartamento")
                    .Rows(.Rows.Count - 1).Cells("idprovincia").Value = row("idprovincia")
                    .Rows(.Rows.Count - 1).Cells("iddistrito").Value = row("iddistrito")
                End With
            Next
        End If
        intOpcion = 2
        Me.tabRuta.SelectedIndex = 1
    End Sub

    Private Sub tabRuta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabRuta.SelectedIndexChanged
        If tabRuta.SelectedIndex = 0 Then
            intOpcion = 0
            Me.tsbGrabar.Enabled = False
            If Me.dgvLista.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If CDate(Me.dgvLista.CurrentRow.Cells("fecha").Value) = Format(FechaServidor, "Short Date") Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            End If
        Else
            Me.tsbGrabar.Enabled = True
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            If intOpcion = 0 Then
                intOpcion = 1
                Me.tsbNuevo_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.txtNombre.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese nombre de la ruta", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombre.Text = ""
            Me.txtNombre.Focus()
            Return
        End If

        If Me.cboColor.SelectedValue = 0 Then
            MessageBox.Show("Seleccione color de la ruta", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboColor.DroppedDown = True
            Me.cboColor.Focus()
            Return
        End If

        If Me.dgvDetalle.Rows.Count = 0 Then
            MessageBox.Show("Debe ingresar al menos una ruta", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnAgregar.Focus()
            Return
        End If

        Grabar()
    End Sub

    Sub Agregar()
        With Me.dgvDetalle
            .Rows.Add()
            .Rows(.Rows.Count - 1).Cells("id").Value = 0
            .Rows(.Rows.Count - 1).Cells("id_det").Value = 0
            .Rows(.Rows.Count - 1).Cells("departamento").Value = Me.cboDepartamento.Text
            .Rows(.Rows.Count - 1).Cells("provincia").Value = Me.cboProvincia.Text
            .Rows(.Rows.Count - 1).Cells("distrito").Value = Me.cboDistrito.Text
            .Rows(.Rows.Count - 1).Cells("iddepartamento").Value = Me.cboDepartamento.SelectedValue
            .Rows(.Rows.Count - 1).Cells("idprovincia").Value = Me.cboProvincia.SelectedValue
            .Rows(.Rows.Count - 1).Cells("iddistrito").Value = Me.cboDistrito.SelectedValue
        End With
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Me.cboDepartamento.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el departamento", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboDepartamento.Focus()
            Me.cboDepartamento.DroppedDown = True
            Return
        End If
        If Me.cboProvincia.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la provincia", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboProvincia.Focus()
            Me.cboProvincia.DroppedDown = True
            Return
        End If
        If Me.cboDistrito.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el distrito", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboDistrito.Focus()
            Me.cboDistrito.DroppedDown = True
            Return
        End If

        If ValorGrid(Me.dgvDetalle, "iddistrito", Me.cboDistrito.SelectedValue) >= 0 Then
            MessageBox.Show("La ruta ya existe en la lista", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnAgregar.Focus()
            Return
        End If

        Agregar()
    End Sub

    Private Sub dgvDetalle_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvDetalle.RowsAdded
        Me.btnEliminar.Enabled = True
    End Sub

    Private Sub dgvDetalle_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvDetalle.RowsRemoved
        Me.btnEliminar.Enabled = Me.dgvDetalle.Rows.Count > 0
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar la ruta?", "Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Me.dgvDetalle.Rows.RemoveAt(Me.dgvDetalle.CurrentCell.RowIndex)
        End If
    End Sub

    Sub Grabar()
        Try
            Dim intID As Integer
            Dim obj As New DtoRecojo

            If intOpcion = 1 Then
                intID = 0
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            'intID = obj.GrabarRuta(intID, Me.lblFecha.Text, Me.txtNombre.Text.Trim, dtoUSUARIOS.m_idciudad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            intID = obj.GrabarRuta(intID, Me.dtpFecha.Text, Me.txtNombre.Text.Trim, dtoUSUARIOS.m_idciudad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, Me.cboColor.SelectedValue)
            For Each row As DataGridViewRow In Me.dgvDetalle.Rows
                obj.GrabarRutaDetalle(intID, row.Cells("iddepartamento").Value, row.Cells("idprovincia").Value, row.Cells("iddistrito").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Next

            Me.btnConsultar_Click(Nothing, Nothing)
            Me.tabRuta.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular la ruta?", "Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            AnularRuta(Me.dgvLista.CurrentRow.Cells("id").Value)
        End If
    End Sub

    Sub AnularRuta(ByVal id As Integer)
        Try
            Dim obj As New DtoRecojo
            obj.AnularRuta(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Me.btnConsultar_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class