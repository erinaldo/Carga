Imports INTEGRACION_LN

Public Class frmReparto
    Dim intOperacion As Operacion
    Dim intLlamada As Integer
    Private Sub ConfigurarDGVLista()
        With dgvLista
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
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .Name = "movil" : .DataPropertyName = "movil"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Móvil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_responsable As New DataGridViewTextBoxColumn
            With col_responsable
                .Name = "responsable" : .DataPropertyName = "responsable"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Responsable"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_hora_salida As New DataGridViewTextBoxColumn
            With col_hora_salida
                .Name = "hora_salida" : .DataPropertyName = "hora_salida"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_id_ciudad As New DataGridViewTextBoxColumn
            With col_id_ciudad
                .Name = "id_ciudad" : .DataPropertyName = "id_ciudad" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_ciudad"
            End With
            x += +1
            Dim col_id_responsable As New DataGridViewTextBoxColumn
            With col_id_responsable
                .Name = "id_responsable" : .DataPropertyName = "id_responsable" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_responsable"
            End With
            x += +1
            Dim col_id_movil As New DataGridViewTextBoxColumn
            With col_id_movil
                .Name = "id_movil" : .DataPropertyName = "id_movil" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_movil"
            End With
            .Columns.AddRange(col_id, col_numero, col_fecha, col_ciudad, col_movil, col_responsable, col_hora_salida, col_id_ciudad, col_id_responsable, col_id_movil)
        End With
    End Sub
    Private Sub ConfigurarDGVReparto()
        With dgvReparto
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cantidad_total As New DataGridViewTextBoxColumn
            With col_cantidad_total
                .Name = "cantidad_total" : .DataPropertyName = "cantidad_total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cantidad_entrega As New DataGridViewTextBoxColumn
            With col_cantidad_entrega
                .Name = "cantidad_entrega" : .DataPropertyName = "cantidad_entrega"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Cantidad Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cantidad_reparto As New DataGridViewTextBoxColumn
            With col_cantidad_reparto
                .Name = "cantidad_reparto" : .DataPropertyName = "cantidad_reparto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Cantidad Reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With
            x += +1
            Dim col_id_comprobante As New DataGridViewTextBoxColumn
            With col_id_comprobante
                .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
            End With
            x += +1
            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .Name = "id_tipo" : .DataPropertyName = "id_tipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
            End With

            .Columns.AddRange(col_id, col_fecha, col_tipo, col_comprobante, col_origen, col_destino, col_cliente, _
                              col_cantidad_total, col_cantidad_entrega, col_cantidad_reparto, col_peso, col_estado, col_id_comprobante, col_id_tipo)
        End With
    End Sub

    Sub Inicio()
        Dim obj As New Cls_Reparto_LN
        Dim dtCiudad As DataTable

        intLlamada = 0
        Me.cboTipoComprobante.SelectedIndex = 0
        dtCiudad = obj.ListarCiudad
        With cboCiudadLista
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dtCiudad
            .SelectedValue = dtoUSUARIOS.m_idciudad
        End With

        With cboCiudad
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dtCiudad.Copy
            .SelectedValue = dtoUSUARIOS.m_idciudad
        End With

        ConfigurarDGVLista()
        ConfigurarDGVReparto()

        Me.btnFiltrar_Click(Nothing, Nothing)
        Controla()
    End Sub

    Private Sub frmReparto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Sub ListarMovil(ciudad As Integer, cbo As ComboBox, opcion As Integer)
        Dim obj As New Cls_Reparto_LN
        With cbo
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarMovil(ciudad, opcion)
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarResponsable(ciudad As Integer, cbo As ComboBox, opcion As Integer)
        Dim obj As New Cls_Reparto_LN
        With cbo
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarResponsable(ciudad, opcion)
            .SelectedValue = 0
        End With
    End Sub

    Private Sub cboCiudad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCiudad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboCiudad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCiudad.SelectedIndexChanged
        ListarMovil(Me.cboCiudad.SelectedValue, Me.cboMovil, 0)
        ListarResponsable(Me.cboCiudad.SelectedValue, Me.cboResponsable, 0)
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Try
            If Me.txtComprobante.Text.Trim.Length = 0 Then Return

            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Reparto_LN
            Dim strNroDoc As String() = Split(txtComprobante.Text, "-")

            If strNroDoc.Length > 1 Then
                If strNroDoc(0).Trim.Length > 1 And Val(strNroDoc(1)) > 0 Then
                    ObjEntrega_Recojo.v_serie = strNroDoc(0)
                    ObjEntrega_Recojo.v_nroDoc = strNroDoc(1)
                Else
                    ObjEntrega_Recojo.v_serie = "0"
                    ObjEntrega_Recojo.v_nroDoc = "0"
                End If
            Else
                If strNroDoc.Length = 1 Then
                    ObjEntrega_Recojo.v_serie = "-1"
                    ObjEntrega_Recojo.v_nroDoc = strNroDoc(0)
                Else
                    ObjEntrega_Recojo.v_serie = "0"
                    ObjEntrega_Recojo.v_nroDoc = "0"
                End If
            End If

            Dim dt As DataTable = obj.ListarDisponible(ObjEntrega_Recojo.v_serie, ObjEntrega_Recojo.v_nroDoc, Me.cboTipoComprobante.SelectedIndex)
            If dt.Rows.Count > 0 Then
                If Not ExisteValorGrid(Me.dgvReparto, Me.dgvReparto.Columns("id_comprobante").Index, dt.Rows(0).Item("id_comprobante")) Then
                    Agregar(dt, dgvReparto, 0)
                    Me.txtComprobante.Focus()
                    Me.txtComprobante.SelectAll()
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show("El Comprobante ya existe en la Lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComprobante.Focus()
                    Me.txtComprobante.SelectAll()
                End If
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Reparto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtComprobante.Focus()
            Me.txtComprobante.SelectAll()
        End Try
    End Sub

    Sub Agregar(dt As DataTable, dgv As DataGridView, Optional fila As Integer = 0)
        With dgv
            Dim intRegistro As Integer = dgv.Rows.Count
            .Rows.Add()
            dgv(0, .Rows.Count - 1).Value = 0
            dgv(1, .Rows.Count - 1).Value = CDate(dt.Rows(fila).Item("fecha"))
            dgv(2, .Rows.Count - 1).Value = dt.Rows(fila).Item("tipo")
            dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("comprobante")
            dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
            dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
            dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("cliente")
            dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad_total")
            dgv(8, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad_entrega")
            dgv(9, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad_reparto")
            dgv(10, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
            dgv(11, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado")
            dgv(12, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_comprobante")
            dgv(13, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_tipo")
        End With
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        Nuevo()
        Me.cboMovil.Focus()
        Me.cboMovil.DroppedDown = True
    End Sub

    Sub Limpiar()
        Me.lblFecha.Text = Format(Now, "dd/MM/yyyy")
        'Me.lblFecha.Text = "01/04/2015"
        Me.lblNumero.Text = ""
        Me.cboCiudad.SelectedValue = dtoUSUARIOS.m_idciudad
        Me.cboMovil.SelectedValue = 0
        Me.cboResponsable.SelectedValue = 0
        Me.dtpHoraSalida.Value = Now
        Me.txtComprobante.Text = ""

        Me.cboCiudad.Enabled = True
        Me.cboMovil.Enabled = True
        Me.cboResponsable.Enabled = True
        Me.dtpHoraSalida.Enabled = True

        Me.txtComprobante.Enabled = True
        Me.btnAgregar.Enabled = True

        Me.dgvReparto.Rows.Clear()
    End Sub

    Sub Nuevo()
        intOperacion = Operacion.Nuevo
        intLlamada = 1
        tabReparto.SelectedIndex = 1
        Limpiar()

        Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = True : Me.tsbAnular.Enabled = False : Me.tsbImprimir.Enabled = False
    End Sub

    Private Sub txtComprobante_Enter(sender As Object, e As System.EventArgs) Handles txtComprobante.Enter
        Me.txtComprobante.SelectAll()
    End Sub

    Private Sub txtComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregar_Click(Nothing, Nothing)
        ElseIf ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        Editar()
    End Sub

    Sub Editar()
        Try
            Cursor = Cursors.WaitCursor
            intOperacion = Operacion.Modificar
            intLlamada = 1
            Limpiar()
            With Me.dgvLista
                Me.lblFecha.Text = .CurrentRow.Cells("fecha").Value
                Me.lblNumero.Text = .CurrentRow.Cells("numero").Value
                Me.cboCiudad.SelectedValue = .CurrentRow.Cells("id_ciudad").Value
                Me.cboMovil.SelectedValue = .CurrentRow.Cells("id_movil").Value
                Me.cboResponsable.SelectedValue = .CurrentRow.Cells("id_responsable").Value
                Me.dtpHoraSalida.Value = .CurrentRow.Cells("hora_salida").Value

                ListarReparto(.CurrentRow.Cells("id").Value)
            End With

            Me.cboCiudad.Enabled = False
            Me.cboMovil.Enabled = False
            Me.cboResponsable.Enabled = False
            Me.dtpHoraSalida.Enabled = False

            tabReparto.SelectedIndex = 1

            If Me.lblFecha.Text = FechaServidor().ToString.Substring(0, 10) Then
                Me.tsbGrabar.Enabled = True
            Else
                'Me.tsbGrabar.Enabled = False
                'Me.txtComprobante.Enabled = False
                'Me.btnAgregar.Enabled = False
            End If

            Me.txtComprobante.Focus()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Editar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboResponsable_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboResponsable.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpHoraSalida_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpHoraSalida.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        If Me.cboMovil.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Móvil", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboMovil.Focus()
            Me.cboMovil.DroppedDown = True
            Return
        End If

        If Me.cboResponsable.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Responsable", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboResponsable.Focus()
            Me.cboResponsable.DroppedDown = True
            Return
        End If

        If Me.dgvReparto.Rows.Count = 0 Then
            MessageBox.Show("Ingrese Carga a Repartir", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtComprobante.Focus()
            Me.txtComprobante.SelectAll()
            Return
        End If

        Grabar()
    End Sub

    Sub Grabar()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Reparto_LN
            Dim intID As Integer, intCiudad As Integer, intCantidadReparto As Integer, intTipo As Integer, intComprobante As Integer

            If intOperacion = Operacion.Nuevo Then
                intID = 0
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            intCiudad = Me.cboCiudad.SelectedValue

            With Me.dgvReparto
                For Each row As DataGridViewRow In .Rows
                    intCantidadReparto = row.Cells("cantidad_reparto").Value
                    intTipo = row.Cells("id_tipo").Value
                    intComprobante = row.Cells("id_comprobante").Value

                    intID = obj.Grabar(intID, intCiudad, Me.lblFecha.Text, Me.cboMovil.SelectedValue, Me.cboResponsable.SelectedValue, Me.dtpHoraSalida.Value.ToString, _
                                       intCantidadReparto, intTipo, intComprobante, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                Next
                Me.ListarReparto()
                Me.tabReparto.SelectedIndex = 0
                Me.btnFiltrar.Focus()
            End With
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        ListarReparto()
        Controla()
    End Sub

    Sub ListarReparto(id As Integer)
        Try
            Cursor = Cursors.WaitCursor
            Dim intFila As Integer = 0
            Dim obj As New Cls_Reparto_LN
            With Me.dgvReparto
                Dim dt As DataTable = obj.ListarReparto(id)
                For Each row As DataRow In dt.Rows
                    Agregar(dt, dgvReparto, intFila)
                    intFila += 1
                Next
            End With
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarReparto()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Reparto_LN
            With Me.dgvLista
                .DataSource = obj.ListarReparto(Me.cboCiudadLista.SelectedValue, Me.dtpFechaLista.Value.ToShortDateString, Me.cboMovilLista.SelectedValue, _
                                                Me.cboResponsableLista.SelectedValue)
            End With
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboCiudadLista_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCiudadLista.SelectedIndexChanged
        ListarMovil(Me.cboCiudadLista.SelectedValue, Me.cboMovilLista, 1)
        ListarResponsable(Me.cboCiudadLista.SelectedValue, Me.cboResponsableLista, 1)
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Sub Controla()
        If Me.tabReparto.SelectedIndex = 0 Then
            Me.tsbNuevo.Enabled = True
            Me.tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0
            Me.tsbGrabar.Enabled = False
            Me.tsbAnular.Enabled = Me.dgvLista.Rows.Count > 0
            Me.tsbImprimir.Enabled = Me.dgvLista.Rows.Count > 0
        Else
            Me.tsbNuevo.Enabled = True
            Me.tsbEditar.Enabled = False
            Me.tsbGrabar.Enabled = True

            Me.tsbAnular.Enabled = False
            Me.tsbImprimir.Enabled = False
        End If
    End Sub

    Private Sub tabReparto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabReparto.SelectedIndexChanged
        If tabReparto.SelectedIndex = 1 Then
            If intLlamada = 0 Then
                If Me.dgvLista.Rows.Count > 0 Then
                    Me.tsbEditar_Click(Nothing, Nothing)
                Else
                    Nuevo()
                    Me.cboCiudad.Focus()
                    SendKeys.Send(vbTab)
                End If
            Else
                intLlamada = 0
            End If
        End If
        Controla()
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
        Imprimir()
    End Sub

    Sub Imprimir()
        Dim ObjReport As New ClsLbTepsa.dtoFrmReport
        Try
            Try
                ObjReport.Dispose()
            Catch
            End Try
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            ObjReport.printrptB(False, "", "MOV020-1.rpt", "ni_id;" & Me.dgvLista.CurrentRow.Cells("id").Value, _
                                "hora;" & Me.dgvLista.CurrentRow.Cells("hora_salida").Value, _
                                "numero;" & Me.dgvLista.CurrentRow.Cells("numero").Value)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboMovil_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboMovil.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged

    End Sub
End Class