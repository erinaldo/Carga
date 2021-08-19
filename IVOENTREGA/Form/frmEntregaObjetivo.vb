Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmEntregaObjetivo
    Dim intObjetivo As Integer = 0
    Dim intOpcion As Integer

    Dim blnEditaObjetivo As Boolean = False
    Dim intFilasObjetivo As Integer = 0

    Dim strFechaActivacion As String

    Private Sub ConfigurarDGVLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgvBono)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            'Dim x As Integer = 0
            'Dim col_idunidad As New DataGridViewTextBoxColumn
            'With col_idunidad
            '    .Name = "idunidad" : .DataPropertyName = "idunidad"
            '    .DisplayIndex = x : .Visible = True
            'End With

            'x += +1
            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id" : .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsç
                '.Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_operacion As New DataGridViewTextBoxColumn
            With col_tipo_operacion
                .Name = "tipo_operacion" : .DataPropertyName = "tipo_operacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_operacion"
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Operación" : .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_adicional As New DataGridViewTextBoxColumn
            With col_adicional
                .Name = "adicional" : .DataPropertyName = "adicional"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Adicional" : .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                '.Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_adicional_pce As New DataGridViewTextBoxColumn
            With col_adicional_pce
                .Name = "adicional_pce" : .DataPropertyName = "adicional_pce"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Adicional PCE" : .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                '.Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .HeaderText = "Fecha Activación" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                '.Width = 200
            End With
            .Columns.AddRange(col_id, col_tipo_operacion, col_operacion, col_adicional, col_adicional_pce, col_fecha)
        End With
    End Sub
    Private Sub ConfigurarDGVObjetivo()
        With dgvObjetivo
            'utilitario.FormatDataGridView(dgvBono)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            'Dim x As Integer = 0
            'Dim col_idunidad As New DataGridViewTextBoxColumn
            'With col_idunidad
            '    .Name = "idunidad" : .DataPropertyName = "idunidad"
            '    .DisplayIndex = x : .Visible = True
            'End With

            'x += +1
            Dim x As Integer = 0
            Dim col_id As New DataGridViewComboBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id" ': .ReadOnly = True
                .DisplayStyleForCurrentCellOnly = True
            End With
            x += +1
            Dim col_inicio As New DataGridViewTextBoxColumn
            With col_inicio
                .Name = "inicio" : .DataPropertyName = "inicio" : .HeaderText = "Inicio"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .MaxInputLength = 12
                .ValueType = GetType(System.Double) : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            x += +1
            Dim col_fin As New DataGridViewTextBoxColumn
            With col_fin
                .Name = "fin" : .DataPropertyName = "fin" : .HeaderText = "Fin"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .MaxInputLength = 12
                .ValueType = GetType(System.Double) : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            x += +1
            Dim col_valor As New DataGridViewTextBoxColumn
            With col_valor
                .Name = "valor" : .DataPropertyName = "valor" : .HeaderText = "Valor"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .MaxInputLength = 12
                .ValueType = GetType(System.Double) : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            x += 1
            Dim col_modificacion As New DataGridViewTextBoxColumn
            With col_modificacion
                .Name = "modificado" : .HeaderText = "Modificado"
                .DisplayIndex = x : .Visible = False : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            .Columns.AddRange(col_id, col_inicio, col_fin, col_valor, col_modificacion)
        End With
    End Sub

    Private Sub frmEntregaObjetivo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
    End Sub

    Sub Inicio()
        ConfigurarDGVLista()
        ConfigurarDGVObjetivo()

        Me.cboOperacion.SelectedIndex = 0
        Me.cboOperacion2.SelectedIndex = 0
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        Try
            Me.Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Limpiar()
        Me.cboOperacion2.SelectedIndex = 0
        Me.txtAdicional.Text = ""
        Me.txtAdicionalPCE.Text = ""

        Me.dgvObjetivo.DataSource = Nothing
        Me.dgvObjetivo.Rows.Clear()
        Me.AgregarObjetivo()
    End Sub

    Sub ActivarDesactivar(estado As Boolean)
        Me.cboOperacion2.Enabled = estado
    End Sub

    Sub Nuevo()
        intOpcion = 1
        intObjetivo = 0
        Me.Limpiar()

        Me.tabObjetivoEntrega.SelectedIndex = 1
        ActivarDesactivar(True)
        Me.cboOperacion2.Focus()
    End Sub

    Sub AgregarObjetivo()
        With dgvObjetivo
            Dim intUltimaFila As Integer
            If .Rows.Count = 0 Then
                .Rows.Add()
            Else
                intUltimaFila = .Rows.Count - 1
                If RegistroCompleto(intUltimaFila) Then
                    .Rows.Add()
                    intUltimaFila = .Rows.Count - 1
                    .CurrentCell = .Rows(intUltimaFila).Cells(1)
                Else
                    Return
                End If
            End If
            .Rows(intUltimaFila).Cells("id").Value = Nothing
            .Rows(intUltimaFila).Cells("inicio").Value = 0
            .Rows(intUltimaFila).Cells("fin").Value = 0
            .Rows(intUltimaFila).Cells("valor").Value = 0
            .Rows(intUltimaFila).Cells("modificado").Value = 2
        End With
    End Sub

    Sub QuitarObjetivo()
        dgvObjetivo.Rows.RemoveAt(dgvObjetivo.Rows.Count - 1)
    End Sub

    Private Sub dgvObjetivo_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvObjetivo.CellBeginEdit
        If e.ColumnIndex > 0 Then
            Dim dblTarifaOld As Double
            If IsNothing(dgvObjetivo.CurrentRow.Tag) Then
                dblTarifaOld = dgvObjetivo.CurrentRow.Cells("inicio").Value + dgvObjetivo.CurrentRow.Cells("fin").Value + dgvObjetivo.CurrentRow.Cells("valor").Value
                dgvObjetivo.CurrentRow.Tag = dblTarifaOld
            End If
        End If
        blnEditaObjetivo = True
    End Sub

    Private Sub dgvObjetivo_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvObjetivo.CellEndEdit
        If e.ColumnIndex > 0 Then
            If IsDBNull(dgvObjetivo(e.ColumnIndex, e.RowIndex).Value) Then
                dgvObjetivo.CurrentRow.Cells(e.ColumnIndex).Value = "0.00"
            Else
                If dgvObjetivo(e.ColumnIndex, e.RowIndex).Value.ToString.Trim.Length >= 12 Then
                    Dim strValor As String = dgvObjetivo(e.ColumnIndex, e.RowIndex).Value
                    strValor = strValor.Trim.Substring(0, 10) & ".00"
                    dgvObjetivo(e.ColumnIndex, e.RowIndex).Value = strValor
                End If
            End If
        End If

        If e.ColumnIndex > 0 And dgvObjetivo.CurrentRow.Cells("modificado").Value <> 2 Then
            Dim dblTarifaNew As Double
            dblTarifaNew = dgvObjetivo.CurrentRow.Cells("inicio").Value + dgvObjetivo.CurrentRow.Cells("fin").Value + dgvObjetivo.CurrentRow.Cells("valor").Value
            If dblTarifaNew <> dgvObjetivo.CurrentRow.Tag Then
                dgvObjetivo.CurrentRow.Cells("modificado").Value = 1
            Else
                dgvObjetivo.CurrentRow.Cells("modificado").Value = Nothing
            End If
        End If
        blnEditaObjetivo = False
    End Sub

    Private Sub dgvObjetivo_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvObjetivo.CurrentCellDirtyStateChanged
        dgvObjetivo.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvObjetivo_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvObjetivo.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            Dim validar As TextBox = CType(e.Control, TextBox)
            AddHandler validar.KeyPress, AddressOf Validar_KeyPress
        End If
    End Sub

    Private Sub dgvObjetivo_LostFocus(sender As Object, e As System.EventArgs) Handles dgvObjetivo.LostFocus
        Me.dgvObjetivo.ClearSelection()
    End Sub

    Private Sub dgvObjetivo_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvObjetivo.MouseClick
        If dgvObjetivo.CurrentCell.RowIndex < dgvObjetivo.Rows.Count - 1 And Me.RegistroCompleto(dgvObjetivo.Rows.Count - 1) = False And Me.dgvObjetivo.Focused And dgvObjetivo.Rows.Count > 1 Then
            QuitarObjetivo()
        End If
    End Sub

    Sub EliminarObjetivo()
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Eliminar el Objetivo Seleccionado?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            With dgvObjetivo
                If .Rows.Count > 0 Then
                    .Rows.RemoveAt(.CurrentCell.RowIndex)
                    If .Rows.Count = 0 Then
                        AgregarObjetivo()
                    End If
                End If
            End With
        End If
    End Sub

    Function RegistroCompleto(fila As Integer) As Boolean
        With dgvObjetivo
            If IsDBNull(dgvObjetivo.CurrentCell.Value) Then
                dgvObjetivo.CurrentCell.Value = "0.00"
            End If
            If .Rows(fila).Cells("inicio").Value > 0 And .Rows(fila).Cells("fin").Value >= 0 And .Rows(fila).Cells("valor").Value > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Sub Validar_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim intColumna As Integer = Me.dgvObjetivo.CurrentCell.ColumnIndex
        Dim chrCaracter As Char = e.KeyChar

        If intColumna >= 1 Then
            Dim txt As TextBox = CType(sender, TextBox)

            If Not ValidarNumeroReal(chrCaracter, txt.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True

        If msg.WParam.ToInt32 = Keys.Enter And (Me.dgvObjetivo.Focused Or blnEditaObjetivo) Then
            If dgvObjetivo.CurrentCell.RowIndex = dgvObjetivo.Rows.Count - 1 And dgvObjetivo.CurrentCell.ColumnIndex = 3 Then
                If blnEditaObjetivo = False Then
                    SendKeys.Send(vbTab)
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf (msg.WParam.ToInt32 = Keys.Insert Or (msg.WParam.ToInt32 = Keys.Down And dgvObjetivo.CurrentCell.RowIndex = dgvObjetivo.Rows.Count - 1)) Then
            AgregarObjetivo()
        ElseIf msg.WParam.ToInt32 = Keys.Up And dgvObjetivo.CurrentCell.RowIndex = dgvObjetivo.Rows.Count - 1 And Me.RegistroCompleto(dgvObjetivo.CurrentCell.RowIndex) = False And Me.dgvObjetivo.Focused And Me.dgvObjetivo.Rows.Count > 1 Then
            QuitarObjetivo()
        ElseIf msg.WParam.ToInt32 = Keys.Delete And Me.dgvObjetivo.Focused Then
            EliminarObjetivo()
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.tabObjetivoEntrega.SelectedIndex = 0
        Me.btnConsultar.Focus()
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        Try
            Me.Editar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarObjetivo()
        Dim obj As New Cls_EntregaCarga_LN

        Me.dgvLista.DataSource = obj.ListarObjetivo(Me.cboOperacion.SelectedIndex, 1)
        If Me.dgvLista.Rows.Count = 0 Then
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        Else
            Me.tsbEditar.Enabled = True
            Me.tsbAnular.Enabled = True
        End If
    End Sub

    Sub ListarObjetivo(operacion As Integer)
        Try
            Me.ConfigurarDGVObjetivo()
            Dim objObjetivo As New Cls_EntregaCarga_LN
            Dim dt As DataTable = objObjetivo.ListarObjetivo(operacion, 0)

            'Visualiza Detalle
            With dt
                If .Rows.Count > 0 Then
                    'Visualiza Cabecera
                    Me.cboOperacion2.SelectedIndex = dt.Rows(0).Item("tipo_operacion")
                    Me.dtpFechaActivacion.Value = dt.Rows(0).Item("fecha")
                    strFechaActivacion = Me.dtpFechaActivacion.Value.ToShortDateString
                    Me.txtAdicional.Text = dt.Rows(0).Item("adicional")
                    Me.txtAdicionalPCE.Text = dt.Rows(0).Item("adicional_pce")

                    dgvObjetivo.DataSource = Nothing
                    Dim i As Integer
                    For Each row As DataRow In dt.Rows
                        dgvObjetivo.Rows.Add()
                        dgvObjetivo.Rows(i).Cells(0).Value = row.Item("id")
                        dgvObjetivo.Rows(i).Cells(1).Value = row.Item("inicio")
                        dgvObjetivo.Rows(i).Cells(2).Value = row.Item("fin")
                        dgvObjetivo.Rows(i).Cells(3).Value = row.Item("valor")
                        i += 1
                    Next
                End If
                intFilasObjetivo = dgvObjetivo.Rows.Count - 1
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub Editar()
        intOpcion = 2

        intObjetivo = Me.dgvLista.CurrentRow.Cells("id").Value
        Me.ListarObjetivo(intObjetivo)

        ActivarDesactivar(False)

        RemoveHandler tabObjetivoEntrega.SelectedIndexChanged, AddressOf tabObjetivoEntrega_SelectedIndexChanged
        Me.tabObjetivoEntrega.SelectedIndex = 1
        AddHandler tabObjetivoEntrega.SelectedIndexChanged, AddressOf tabObjetivoEntrega_SelectedIndexChanged

        Me.dgvObjetivo.Focus()
    End Sub

    Private Sub tabObjetivoEntrega_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabObjetivoEntrega.SelectedIndexChanged
        If tabObjetivoEntrega.SelectedIndex = 1 Then
            Me.tsbNuevo_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Try
            Me.ListarObjetivo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Function ObtieneOperacion(operacion As Integer) As Integer
        If operacion = 0 Then
            Return 0
        Else
            Return operacion + 1
        End If
    End Function

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Validar() Then
                Grabar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ObjetivoExiste() As Boolean
        Try
            Dim objLN As New Cls_EntregaCarga_LN
            Dim objEN As New Cls_EntregaCarga_EN

            Dim intOperacion As Integer = Me.cboOperacion2.SelectedIndex
            Return objLN.ExisteObjetivo(intOperacion)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Function ObjetivoCruzado() As Integer
        With dgvObjetivo
            If .Rows.Count > 1 Then
                Dim x As Integer = 0, dblFin As Double = 0
                For Each row As DataGridViewRow In .Rows
                    x += 1
                    For i As Integer = x To .Rows.Count - 1
                        'If row.Cells("idunidad").Value = .Rows(i).Cells("idunidad").Value Then
                        dblFin = If(row.Cells("fin").Value = 0, 99999999999, row.Cells("fin").Value)
                        If .Rows(i).Cells("inicio").Value >= row.Cells("inicio").Value And .Rows(i).Cells("inicio").Value <= dblFin Then
                            Return i + 1
                        End If
                        'End If
                    Next
                Next
            End If
            Return 0
        End With
    End Function

    Function ObjetivoModificado() As Boolean
        With dgvObjetivo
            For Each row As DataGridViewRow In .Rows
                If Not IsNothing(row.Cells("modificado").Value) Then
                    Return True
                End If
            Next
            Return False
        End With
    End Function

    Function Validar() As Boolean
        Dim blnValidar As Boolean

        blnValidar = False
        If Me.cboOperacion2.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Operación", "Objetivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboOperacion2.Focus()
            Me.cboOperacion2.DroppedDown = True
            Return blnValidar
        End If

        If intOpcion = 1 Then
            If ObjetivoExiste() Then
                Dim strMensaje As String
                strMensaje = "Ya existe un Registro de Objetivo para la Operación " & Me.cboOperacion2.Text & Chr(13)
                MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboOperacion2.Focus()
                cboOperacion2.DroppedDown = True
                Return blnValidar
            End If
        End If

        Dim dblInicio As Double, dblFin As Double, dblMonto As Double
        Dim intEstado As Int16 = 0, intFila As Integer = 0, intColumna As Integer = 0, intAcumulado As Integer = 0
        With dgvObjetivo
            For Each row As DataGridViewRow In .Rows
                intFila += 1
                dblInicio = IIf(IsDBNull(row.Cells("inicio").Value), 0, row.Cells("inicio").Value)
                dblFin = IIf(IsDBNull(row.Cells("fin").Value), 0, row.Cells("fin").Value)
                dblMonto = IIf(IsDBNull(row.Cells("valor").Value), 0, row.Cells("valor").Value)

                'intAcumulado += IIf(dblInicio = 0 And dblFin = 0 And dblMonto = 0, 0, 1)
                intAcumulado += IIf(dblInicio = 0 And dblMonto = 0, 0, 1)

                If Me.ValidaItem(dblInicio, dblFin, dblMonto) = False Then
                    If dblInicio = 0 Then
                        intEstado = 1
                    ElseIf dblFin = 0 Then
                        intEstado = 2
                    ElseIf dblMonto = 0 Then
                        intEstado = 3
                    End If
                    Exit For
                End If
                If (dblFin > 0) AndAlso (dblInicio > dblFin) Then
                    intEstado = 4
                    Exit For
                End If
            Next
            If intEstado > 0 Or intAcumulado = 0 Then
                intFila -= 1
                Dim strMensaje As String = ""
                If intEstado = 1 Then
                    strMensaje = "Ingrese Valor Inicio"
                    intColumna = 1
                ElseIf intEstado = 2 Then
                    strMensaje = "Ingrese Valor Fin"
                    intColumna = 2
                ElseIf intEstado = 3 Then
                    strMensaje = "Ingrese Valor Monto"
                    intColumna = 3
                ElseIf intEstado = 4 Then
                    strMensaje = "El Valor Inicio no debe ser mayor al Valor Fin"
                    intColumna = 1
                ElseIf intAcumulado = 0 Then
                    strMensaje = "Ingrese los Objetivos"
                    intFila = 0
                    intColumna = 1
                End If
                MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvObjetivo.Focus()
                Me.dgvObjetivo.CurrentCell = Me.dgvObjetivo.Rows(intFila).Cells(intColumna)
                Return blnValidar
            End If

            Dim intObjetivoCruzado As Integer = ObjetivoCruzado()
            If intObjetivoCruzado > 0 Then
                MessageBox.Show("Rango Incorrecto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvObjetivo.Focus()
                Me.dgvObjetivo.CurrentCell = Me.dgvObjetivo.Rows(intObjetivoCruzado - 1).Cells("inicio")
                Return blnValidar
            End If

            If intOpcion = 2 Then
                Dim blnFechaActivacionMod As Boolean = False
                If strFechaActivacion <> Me.dtpFechaActivacion.Value.Date.ToShortDateString Then
                    blnFechaActivacionMod = True
                End If
                'If ObjetivoModificado() = False And intFilasObjetivo = dgvObjetivo.Rows.Count - 1 And blnFechaActivacionMod = False Then
                '    MessageBox.Show("Modifique los Objetivos", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.dgvObjetivo.Focus()
                '    Me.dgvObjetivo.CurrentCell = Me.dgvObjetivo.Rows(0).Cells("inicio")
                '    Return blnValidar
                'End If
            End If
        End With

        blnValidar = True
        Return blnValidar
    End Function

    Function ValidaItem(a As Integer, b As Integer, c As Integer) As Boolean
        If a = 0 Then
            Return False
            'ElseIf b = 0 Then
            'Return False
        ElseIf c = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub Grabar()
        Try
            Dim objLN As New Cls_EntregaCarga_LN
            Dim dblInicio As Double = 0, dblFin As Double, dblValor As Double, intID As Integer = 0
            Dim intOpcion2 As Integer = intOpcion
            Dim dblAdicional As Double, dblAdicional_PCE As Double

            dblAdicional = IIf(Me.txtAdicional.Text = "", 0, Me.txtAdicional.Text)
            dblAdicional_PCE = IIf(Me.txtAdicionalPCE.Text = "", 0, Me.txtAdicionalPCE.Text)

            If dgvLista.Rows.Count > 0 Then
                intID = dgvLista.CurrentRow.Cells("id").Value
            End If

            For Each row As DataGridViewRow In dgvObjetivo.Rows
                If row.Cells("valor").Value > 0 Then
                    dblInicio = row.Cells("inicio").Value
                    dblFin = row.Cells("fin").Value
                    dblValor = row.Cells("valor").Value
                    intID = objLN.GrabarObjetivo(intOpcion2, intID, Me.cboOperacion2.SelectedIndex, dblAdicional, dblAdicional_PCE, dblInicio, dblFin, dblValor, Me.dtpFechaActivacion.Value.ToShortDateString)
                    intOpcion2 = 9
                End If
            Next
            MessageBox.Show("Objetivo Actualizado", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ListarObjetivo()
            Me.tabObjetivoEntrega.SelectedIndex = 0

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Anular(operacion As Integer)
        Dim obj As New Cls_EntregaCarga_LN

        obj.AnularObjetivo(operacion)
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular los Objetivos para la Categoria " & Me.dgvLista.CurrentRow.Cells("operacion").Value & "?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Anular(Me.dgvLista.CurrentRow.Cells("tipo_operacion").Value)
                MessageBox.Show("Objetivo Anulado", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ListarObjetivo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtAdicional_Enter(sender As Object, e As System.EventArgs) Handles txtAdicional.Enter
        Me.txtAdicional.SelectAll()
    End Sub

    Private Sub txtAdicional_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdicional.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If (Not ValidarNumero(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAdicionalPCE_Enter(sender As Object, e As System.EventArgs) Handles txtAdicionalPCE.Enter
        Me.txtAdicionalPCE.SelectAll()
    End Sub

    Private Sub txtAdicionalPCE_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdicionalPCE.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If (Not ValidarNumero(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvObjetivo_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvObjetivo.CellContentClick

    End Sub

    Private Sub cboOperacion2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOperacion2.SelectedIndexChanged

    End Sub
End Class