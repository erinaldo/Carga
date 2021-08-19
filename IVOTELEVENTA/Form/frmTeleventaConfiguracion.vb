Imports INTEGRACION_LN

Public Class frmTeleventaConfiguracion
    Dim blNuevo As Boolean
    Sub FormatearDgv()
        With dgv
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Período" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_agente As New DataGridViewTextBoxColumn
            With col_agente
                .Name = "agente" : .DataPropertyName = "agente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_valor As New DataGridViewTextBoxColumn
            With col_valor
                .Name = "valor" : .DataPropertyName = "valor"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Valor" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_id_agente As New DataGridViewTextBoxColumn
            With col_id_agente
                .Name = "id_agente" : .DataPropertyName = "id_agente" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.AddRange(col_fecha, col_tipo, col_agente, col_valor, col_id_tipo, col_id_agente, col_id)
        End With
    End Sub

    Sub Inicio()
        Dim obj As New Cls_Televenta_LN
        With Me.cboAgente
            .DisplayMember = "nombre"
            .ValueMember = "id"
            .DataSource = obj.ListarUsuario
            .SelectedValue = 0
        End With

        With Me.cboTipoObjetivo
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub frmTeleventaConfiguracion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
        Mostrar()
    End Sub

    Sub Mostrar()
        Try
            Dim dt As DataTable
            Dim intValor As Integer
            Dim obj As New Cls_Televenta_LN

            dt = obj.ListarParametro(7, 1)
            intValor = CType(dt.Rows(0).Item(0).ToString, Integer)
            Me.txtLlamadaI.Text = intValor

            dt = obj.ListarParametro(7, 3)
            intValor = CType(dt.Rows(0).Item(0).ToString, Integer)
            Me.txtLlamadaO.Text = intValor

            dt = obj.ListarParametro(7, 2)
            intValor = CType(dt.Rows(0).Item(0).ToString, Integer)
            Me.txtValorLlamada.Text = intValor

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGrabarLlamada_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarLlamada.Click
        Try
            Dim obj As New Cls_Televenta_LN

            If Me.txtLlamadaI.Text.Trim.Length > 0 Then
                obj.GrabarParametro(7, 1, CType(Me.txtLlamadaI.Text, Integer))
            End If
            If Me.txtLlamadaO.Text.Trim.Length > 0 Then
                obj.GrabarParametro(7, 3, CType(Me.txtLlamadaO.Text, Integer))
            End If
            If Me.txtValorLlamada.Text.Trim.Length > 0 Then
                obj.GrabarParametro(7, 2, CType(Me.txtValorLlamada.Text, Integer))
            End If

            MessageBox.Show("Configuración actualizada", "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtLlamadaI_Enter(sender As Object, e As System.EventArgs) Handles txtLlamadaI.Enter
        Me.txtLlamadaI.SelectAll()
    End Sub

    Private Sub txtLlamadaO_Enter(sender As Object, e As System.EventArgs) Handles txtLlamadaO.Enter
        Me.txtLlamadaO.SelectAll()
    End Sub

    Private Sub txtValorLlamada_Enter(sender As Object, e As System.EventArgs) Handles txtValorLlamada.Enter
        Me.txtValorLlamada.SelectAll()
    End Sub

    Private Sub txtLlamadaI_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLlamadaI.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLlamadaO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLlamadaO.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtValorLlamada_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorLlamada.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If Me.cboTipoObjetivo.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione tipo de objetivo", "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoObjetivo.Focus()
            Me.cboTipoObjetivo.DroppedDown = True
            Return
        End If

        If Me.cboAgente.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Agente", "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboAgente.Focus()
            Me.cboAgente.DroppedDown = True
            Return
        End If

        If Val(Me.txtValor.Text) = 0 Then
            MessageBox.Show("Ingrese Valor", "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtValor.Focus()
            Return
        End If

        Grabar()
    End Sub

    Sub Grabar()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Televenta_LN
            Dim intId As Integer, dblValor As Double

            If blNuevo Then
                intId = 0
            Else
                intId = Me.dgv.CurrentRow.Cells("id").Value
            End If

            dblValor = CType(Me.txtValor.Text, Double)

            obj.GrabarObjetivo(intId, Me.dtpFecha.Value.ToShortDateString, Me.cboAgente.SelectedValue, dblValor, Me.cboTipoObjetivo.SelectedIndex)
            Me.ListarObjetivo()
            tabObjetivos.SelectedTab = tabObjetivos.TabPages("tablista")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarObjetivo()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Televenta_LN
            Dim dt As DataTable
            dt = obj.ListarObjetivo
            dgv.DataSource = dt

            Me.btnModificar.Enabled = Me.dgv.Rows.Count > 0
            Me.btnAnular.Enabled = Me.dgv.Rows.Count > 0

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabConfiguracion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabConfiguracion.SelectedIndexChanged
        If tabConfiguracion.SelectedTab Is tabConfiguracion.TabPages("tabObjetivo") Then
            FormatearDgv()
            ListarObjetivo()
        End If
    End Sub

    Sub Limpiar()
        Me.dtpFecha.Value = FechaServidor()
        Me.cboTipoObjetivo.SelectedIndex = 0
        Me.cboAgente.SelectedValue = 0
        Me.txtValor.Text = ""
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        Limpiar()
        Controla(True)
        tabObjetivos.SelectedTab = tabObjetivos.TabPages("tabMantenimiento")
        Me.dtpFecha.Focus()
    End Sub

    Private Sub txtValor_Enter(sender As Object, e As System.EventArgs) Handles txtValor.Enter
        Me.txtValor.SelectAll()
    End Sub

    Private Sub txtValor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        blNuevo = False
        Editar()
        Controla(False)
    End Sub

    Sub Editar()
        Limpiar()

        With Me.dgv
            Me.dtpFecha.Value = .CurrentRow.Cells("fecha").Value
            Me.cboTipoObjetivo.SelectedIndex = .CurrentRow.Cells("id_tipo").Value
            Me.cboAgente.SelectedValue = .CurrentRow.Cells("id_agente").Value
            Me.txtValor.Text = Format(.CurrentRow.Cells("valor").Value, "###,###,###0.00")
        End With

        tabObjetivos.SelectedTab = tabObjetivos.TabPages("tabMantenimiento")
        Me.txtValor.Focus()
        Me.txtValor.SelectAll()
    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As System.EventArgs) Handles dgv.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            btnModificar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub Controla(bln As Boolean)
        Me.dtpFecha.Enabled = bln
        Me.cboTipoObjetivo.Enabled = bln
        Me.cboAgente.Enabled = bln
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        tabObjetivos.SelectedTab = tabObjetivos.TabPages("tablista")
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de Anular el Objetivo seleccionado?", "Televentas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Anular()
            Me.ListarObjetivo()
        End If
    End Sub

    Sub Anular()
        Try
            Dim obj As New Cls_Televenta_LN
            Dim int_id As Integer = Me.dgv.CurrentRow.Cells("id").Value

            obj.AnularObjetivo(int_id)
            Me.ListarObjetivo()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub tabObjetivos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabObjetivos.SelectedIndexChanged
        If tabObjetivos.SelectedTab Is tabObjetivos.TabPages("tabMantenimiento") Then
            If blNuevo Then
                Me.btnNuevo_Click(Nothing, Nothing)
            End If
        Else
            blNuevo = True
        End If
    End Sub

    Private Sub txtValor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtValor.TextChanged

    End Sub
End Class