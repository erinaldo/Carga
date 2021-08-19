Imports INTEGRACION_LN
Public Class frmEntregaBonos
    Dim dtPeriodo As DataTable

#Region "Grid"
    Sub FormatearDGVBono()
        With dgvBono
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
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
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .HeaderText = "Agencia" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .HeaderText = "Usuario" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_periodo As New DataGridViewTextBoxColumn
            With col_periodo
                .Name = "periodo" : .DataPropertyName = "periodo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo"
            End With
            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_minutos As New DataGridViewTextBoxColumn
            With col_minutos
                .Name = "minutos" : .DataPropertyName = "minutos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Minutos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_segundos As New DataGridViewTextBoxColumn
            With col_segundos
                .Name = "segundos" : .DataPropertyName = "segundos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Segundos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_registros As New DataGridViewTextBoxColumn
            With col_registros
                .Name = "registros" : .DataPropertyName = "registros"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_objetivo As New DataGridViewTextBoxColumn
            With col_objetivo
                .Name = "objetivo" : .DataPropertyName = "objetivo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Objetivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_adicional As New DataGridViewTextBoxColumn
            With col_adicional
                .Name = "adicional" : .DataPropertyName = "adicional"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Adicional"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_adicional_pce As New DataGridViewTextBoxColumn
            With col_adicional_pce
                .Name = "adicional_pce" : .DataPropertyName = "adicional_pce"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Adicional PCE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_produccion As New DataGridViewTextBoxColumn
            With col_produccion
                .Name = "produccion" : .DataPropertyName = "produccion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Producción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_cumplimiento As New DataGridViewTextBoxColumn
            With col_cumplimiento
                .Name = "cumplimiento" : .DataPropertyName = "cumplimiento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cumplimiento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_bono As New DataGridViewTextBoxColumn
            With col_bono
                .Name = "bono" : .DataPropertyName = "bono"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            '.Columns.AddRange(col_agencia, col_operacion, col_usuario, col_periodo, col_objetivo, col_adicional, col_adicional_pce, col_produccion, col_cumplimiento, col_bono)
            .Columns.AddRange(col_agencia, col_operacion, col_periodo, col_objetivo, col_adicional, col_adicional_pce, col_produccion, col_cumplimiento, col_bono)
        End With
    End Sub
    Sub FormatearDGVBonoConsulta()
        With dgvBonoConsulta
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
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
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .HeaderText = "Agencia" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .HeaderText = "Usuario" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_periodo As New DataGridViewTextBoxColumn
            With col_periodo
                .Name = "periodo" : .DataPropertyName = "periodo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo"
            End With
            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_minutos As New DataGridViewTextBoxColumn
            With col_minutos
                .Name = "minutos" : .DataPropertyName = "minutos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Minutos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_segundos As New DataGridViewTextBoxColumn
            With col_segundos
                .Name = "segundos" : .DataPropertyName = "segundos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Segundos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_registros As New DataGridViewTextBoxColumn
            With col_registros
                .Name = "registros" : .DataPropertyName = "registros"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_objetivo As New DataGridViewTextBoxColumn
            With col_objetivo
                .Name = "objetivo" : .DataPropertyName = "objetivo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Objetivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_adicional As New DataGridViewTextBoxColumn
            With col_adicional
                .Name = "adicional" : .DataPropertyName = "adicional"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Adicional"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_adicional_pce As New DataGridViewTextBoxColumn
            With col_adicional_pce
                .Name = "adicional_pce" : .DataPropertyName = "adicional_pce"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Adicional PCE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_produccion As New DataGridViewTextBoxColumn
            With col_produccion
                .Name = "produccion" : .DataPropertyName = "produccion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Producción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_cumplimiento As New DataGridViewTextBoxColumn
            With col_cumplimiento
                .Name = "cumplimiento" : .DataPropertyName = "cumplimiento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cumplimiento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_bono As New DataGridViewTextBoxColumn
            With col_bono
                .Name = "bono" : .DataPropertyName = "bono"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            '.Columns.AddRange(col_agencia, col_operacion, col_usuario, col_periodo, col_objetivo, col_adicional, col_adicional_pce, col_produccion, col_cumplimiento, col_bono)
            .Columns.AddRange(col_agencia, col_operacion, col_periodo, col_objetivo, col_adicional, col_adicional_pce, col_produccion, col_cumplimiento, col_bono)
        End With
    End Sub

#End Region

    Sub Inicio()
        tool.Items(0).Enabled = False

        Dim objLN As New Cls_EntregaCarga_LN
        With cboAgencia
            .ValueMember = "id"
            .DisplayMember = "agencia"
            .DataSource = objLN.ListarAgencia(0)
            .SelectedValue = 51
        End With

        dtPeriodo = objLN.ListarPeriodo(1, Year(FechaServidor))
        With cboPeriodo
            .ValueMember = "id"
            .DisplayMember = "periodo"
            .DataSource = dtPeriodo

            Dim strInicio As String, strFin As String, intRegistros As Integer = 0
            Dim strFecha As String = FechaServidor.ToString.Substring(0, 10)
            Dim blnOK As Boolean = False
            For Each row As DataRow In dtPeriodo.Rows
                strInicio = IIf(IsDBNull(row.Item("fecha_inicio")), "", row.Item("fecha_inicio"))
                strFin = IIf(IsDBNull(row.Item("fecha_fin")), "", row.Item("fecha_fin"))
                If strInicio <> "" AndAlso strFin <> "" Then
                    blnOK = CDate(strFecha) >= CDate(strInicio) And CDate(strFecha) <= CDate(strFin)
                    Exit For
                End If
                intRegistros += 1
            Next
            If blnOK Then
                .SelectedValue = intRegistros
            Else
                .SelectedValue = 0
            End If

            .SelectedIndex = Me.cboPeriodo.Items.Count - 1
        End With

        Me.cboOperacion.SelectedIndex = 0
    End Sub

    Private Sub frmEntregaBonos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicio()
        FormatearDGVBono()
        FormatearDGVBonoConsulta()
    End Sub

    Private Sub btnCalcular_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcular.Click
        If Me.cboAgencia.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Agencia", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboAgencia.Focus()
            Me.cboAgencia.DroppedDown = True
            Return
        End If

        If Me.cboPeriodo.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Período", "Bonos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboPeriodo.Focus()
            Return
        End If

        If Me.cboOperacion.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Operación", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboOperacion.Focus()
            Me.cboOperacion.DroppedDown = True
            Return
        End If

        If Me.tabBono.SelectedIndex = 0 Then
            Calcular()
        Else
            Consultar()
        End If
    End Sub

    Sub Calcular()
        Try
            Cursor = Cursors.WaitCursor
            Dim intOperacion As Integer = Me.cboOperacion.SelectedIndex
            'If intOperacion > 0 Then intOperacion += 1

            Dim objLN As New Cls_EntregaCarga_LN
            Me.dgvBono.DataSource = objLN.CalcularBono(Me.cboAgencia.SelectedValue, Me.cboPeriodo.SelectedValue, _
                                                       intOperacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

            If Me.dgvBono.Rows.Count > 0 Then
                'If (Me.cboAgencia.SelectedValue = 0 Or Me.cboAgencia.SelectedValue = 51) And Me.cboOperacion.SelectedIndex = 0 Then
                If (Me.cboAgencia.SelectedValue > 0) And Me.cboOperacion.SelectedIndex > 0 Then
                    tool.Items(0).Enabled = True
                Else
                    tool.Items(0).Enabled = False
                End If
            Else
                tool.Items(0).Enabled = False
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Bonos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabBono_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabBono.SelectedIndexChanged
        If tabBono.SelectedIndex = 0 Then
            tool.Items(0).Visible = True
            tool.Items(1).Visible = False

            Me.btnCalcular.Text = "Calcular"
        Else
            tool.Items(0).Visible = False
            tool.Items(1).Visible = True
            tool.Items(1).Enabled = Me.dgvBonoConsulta.Rows.Count > 0

            Me.btnCalcular.Text = "Consultar"
        End If
    End Sub

    Private Sub cboAgencia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAgencia.SelectedIndexChanged
        If Me.tabBono.SelectedIndex = 0 Then
            Me.dgvBono.DataSource = Nothing
            tool.Items(0).Enabled = False
        Else
            Me.dgvBonoConsulta.DataSource = Nothing
        End If
    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        If Me.tabBono.SelectedIndex = 0 Then
            Me.dgvBono.DataSource = Nothing
            tool.Items(0).Enabled = False
        Else
            Me.dgvBonoConsulta.DataSource = Nothing
        End If
    End Sub

    Private Sub cboOperacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOperacion.SelectedIndexChanged
        If Me.tabBono.SelectedIndex = 0 Then
            Me.dgvBono.DataSource = Nothing
            tool.Items(0).Enabled = False
        Else
            Me.dgvBonoConsulta.DataSource = Nothing
        End If
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Grabar()
    End Sub

    Sub Grabar()
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Cls_EntregaCarga_LN
            obj.GrabarBono(Me.cboPeriodo.SelectedValue, Me.cboOperacion.SelectedIndex, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Cursor = Cursors.Default
            MessageBox.Show("Se Generó Archivo de Bonos", "Bonos", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Bonos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Consultar()
        Try
            Cursor = Cursors.WaitCursor
            Dim intOperacion As Integer = Me.cboOperacion.SelectedIndex
            'If intOperacion > 0 Then intOperacion += 1

            Dim objLN As New Cls_EntregaCarga_LN
            Me.dgvBonoConsulta.DataSource = objLN.ListarBono(Me.cboAgencia.SelectedValue, Me.cboPeriodo.SelectedValue, _
                                                       intOperacion)

            Me.tool.Items(1).Enabled = Me.dgvBonoConsulta.Rows.Count > 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Bonos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular el cálculo de bonos" & Chr(13) & "Período " & Me.cboPeriodo.Text & "?", "Bonos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Anular()
        End If
    End Sub

    Sub Anular()
        Try
            Dim obj As New Cls_EntregaCarga_LN
            obj.AnularBono(Me.cboPeriodo.SelectedValue, Me.cboOperacion.SelectedIndex, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Me.btnCalcular_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Bonos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class