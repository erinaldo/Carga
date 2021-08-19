Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmBonoEntrega
    Dim intObjetivo As Integer = 0
    Dim intOpcion As Integer

    Dim blnEditaBono As Boolean = False
    Dim intFilasBono As Integer = 0

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
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Operación" : .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsç
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .HeaderText = "Fecha Activación" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 200
            End With
            .Columns.AddRange(col_id, col_operacion, col_fecha)
        End With
    End Sub
    Private Sub ConfigurarDGVBono()
        With dgvBono
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

    Private Sub frmBonoEntrega_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
    End Sub

    Sub Inicio()
        ConfigurarDGVLista()
        ConfigurarDGVBono()

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

        Me.dgvBono.DataSource = Nothing
        Me.dgvBono.Rows.Clear()
        Me.AgregarBono()
    End Sub

    Sub ActivarDesactivar(estado As Boolean)
        Me.cboOperacion2.Enabled = estado
    End Sub

    Sub Nuevo()
        intOpcion = 1
        intObjetivo = 0
        Me.Limpiar()

        Me.tabBonoEntrega.SelectedIndex = 1
        ActivarDesactivar(True)
        Me.cboOperacion2.Focus()
    End Sub

    Sub AgregarBono()
        With dgvBono
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

    Sub QuitarBono()
        dgvBono.Rows.RemoveAt(dgvBono.Rows.Count - 1)
    End Sub

    Private Sub dgvBono_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBono.CellBeginEdit
        If e.ColumnIndex > 0 Then
            Dim dblTarifaOld As Double
            If IsNothing(dgvBono.CurrentRow.Tag) Then
                dblTarifaOld = dgvBono.CurrentRow.Cells("inicio").Value + dgvBono.CurrentRow.Cells("fin").Value + dgvBono.CurrentRow.Cells("valor").Value
                dgvBono.CurrentRow.Tag = dblTarifaOld
            End If
        End If
        blnEditaBono = True
    End Sub

    Private Sub dgvBono_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBono.CellEndEdit
        If e.ColumnIndex > 0 Then
            If IsDBNull(dgvBono(e.ColumnIndex, e.RowIndex).Value) Then
                dgvBono.CurrentRow.Cells(e.ColumnIndex).Value = "0.00"
            Else
                If dgvBono(e.ColumnIndex, e.RowIndex).Value.ToString.Trim.Length >= 12 Then
                    Dim strValor As String = dgvBono(e.ColumnIndex, e.RowIndex).Value
                    strValor = strValor.Trim.Substring(0, 10) & ".00"
                    dgvBono(e.ColumnIndex, e.RowIndex).Value = strValor
                End If
            End If
        End If

        If e.ColumnIndex > 0 And dgvBono.CurrentRow.Cells("modificado").Value <> 2 Then
            Dim dblTarifaNew As Double
            dblTarifaNew = dgvBono.CurrentRow.Cells("inicio").Value + dgvBono.CurrentRow.Cells("fin").Value + dgvBono.CurrentRow.Cells("valor").Value
            If dblTarifaNew <> dgvBono.CurrentRow.Tag Then
                dgvBono.CurrentRow.Cells("modificado").Value = 1
            Else
                dgvBono.CurrentRow.Cells("modificado").Value = Nothing
            End If
        End If
        blnEditaBono = False
    End Sub

    Private Sub dgvBono_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvBono.CurrentCellDirtyStateChanged
        dgvBono.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvBono_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvBono.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            Dim validar As TextBox = CType(e.Control, TextBox)
            AddHandler validar.KeyPress, AddressOf Validar_KeyPress
        End If
    End Sub

    Sub Validar_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim intColumna As Integer = Me.dgvBono.CurrentCell.ColumnIndex
        Dim chrCaracter As Char = e.KeyChar

        If intColumna >= 1 Then
            Dim txt As TextBox = CType(sender, TextBox)

            If Not ValidarNumeroReal(chrCaracter, txt.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvBono_LostFocus(sender As Object, e As System.EventArgs) Handles dgvBono.LostFocus
        Me.dgvBono.ClearSelection()
    End Sub

    Private Sub dgvBono_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvBono.MouseClick
        If dgvBono.CurrentCell.RowIndex < dgvBono.Rows.Count - 1 And Me.RegistroCompleto(dgvBono.Rows.Count - 1) = False And Me.dgvBono.Focused And dgvBono.Rows.Count > 1 Then
            QuitarBono()
        End If
    End Sub

    Sub EliminarBono()
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Eliminar el Bono Seleccionado?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            With dgvBono
                If .Rows.Count > 0 Then
                    .Rows.RemoveAt(.CurrentCell.RowIndex)
                    If .Rows.Count = 0 Then
                        AgregarBono()
                    End If
                End If
            End With
        End If
    End Sub

    Function RegistroCompleto(fila As Integer) As Boolean
        With dgvBono
            If IsDBNull(dgvBono.CurrentCell.Value) Then
                dgvBono.CurrentCell.Value = "0.00"
            End If
            If .Rows(fila).Cells("inicio").Value > 0 And .Rows(fila).Cells("fin").Value > 0 And .Rows(fila).Cells("valor").Value > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function


    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True

        If msg.WParam.ToInt32 = Keys.Enter And (Me.dgvBono.Focused Or blnEditaBono) Then
            If dgvBono.CurrentCell.RowIndex = dgvBono.Rows.Count - 1 And dgvBono.CurrentCell.ColumnIndex = 3 Then
                If blnEditaBono = False Then
                    SendKeys.Send(vbTab)
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf (msg.WParam.ToInt32 = Keys.Insert Or (msg.WParam.ToInt32 = Keys.Down And dgvBono.CurrentCell.RowIndex = dgvBono.Rows.Count - 1)) Then
            AgregarBono()
        ElseIf msg.WParam.ToInt32 = Keys.Up And dgvBono.CurrentCell.RowIndex = dgvBono.Rows.Count - 1 And Me.RegistroCompleto(dgvBono.CurrentCell.RowIndex) = False And Me.dgvBono.Focused Then
            QuitarBono()
        ElseIf msg.WParam.ToInt32 = Keys.Delete And Me.dgvBono.Focused Then
            EliminarBono()
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.tabBonoEntrega.SelectedIndex = 0
        Me.btnConsultar.Focus()
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        Try
            Me.Editar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarBono()
        Dim obj As New Cls_EntregaCarga_LN

        Me.dgvLista.DataSource = obj.ListarBono(ObtieneOperacion(Me.cboOperacion.SelectedIndex), 1)
        If Me.dgvLista.Rows.Count = 0 Then
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        Else
            Me.tsbEditar.Enabled = True
            Me.tsbAnular.Enabled = True
        End If
    End Sub

    Sub ListarBono(operacion As Integer)
        Try
            Me.ConfigurarDGVBono()
            Dim objBono As New Cls_EntregaCarga_LN
            Dim dt As DataTable = objBono.ListarBono(operacion, 0)

            'Visualiza Detalle
            With dt
                If .Rows.Count > 0 Then
                    'Visualiza Cabecera
                    Me.cboOperacion2.SelectedIndex = dt.Rows(0).Item("operacion") '- 1
                    Me.dtpFechaActivacion.Value = dt.Rows(0).Item("fecha")
                    strFechaActivacion = Me.dtpFechaActivacion.Value.ToShortDateString

                    dgvBono.DataSource = Nothing
                    Dim i As Integer
                    For Each row As DataRow In dt.Rows
                        dgvBono.Rows.Add()
                        dgvBono.Rows(i).Cells(0).Value = row.Item("id")
                        dgvBono.Rows(i).Cells(1).Value = row.Item("inicio")
                        dgvBono.Rows(i).Cells(2).Value = row.Item("fin")
                        dgvBono.Rows(i).Cells(3).Value = row.Item("valor")
                        i += 1
                    Next
                End If
                intFilasBono = dgvBono.Rows.Count - 1
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub Editar()
        intOpcion = 2

        intObjetivo = Me.dgvLista.CurrentRow.Cells("id").Value
        Me.ListarBono(intObjetivo)

        ActivarDesactivar(False)

        RemoveHandler tabBonoEntrega.SelectedIndexChanged, AddressOf tabBonoEntrega_SelectedIndexChanged
        Me.tabBonoEntrega.SelectedIndex = 1
        AddHandler tabBonoEntrega.SelectedIndexChanged, AddressOf tabBonoEntrega_SelectedIndexChanged

        Me.dgvBono.Focus()
    End Sub

    Private Sub tabBonoEntrega_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabBonoEntrega.SelectedIndexChanged
        If tabBonoEntrega.SelectedIndex = 1 Then
            Me.tsbNuevo_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Try
            Me.ListarBono()
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
        Return operacion
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

    Function BonoExiste() As Boolean
        Try
            Dim objLN As New Cls_EntregaCarga_LN
            Dim objEN As New Cls_EntregaCarga_EN

            objEN.Operacion = Me.cboOperacion2.SelectedIndex
            Return objLN.ExisteBono(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Function BonoCruzado() As Integer
        With dgvBono
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

    Function BonoModificado() As Boolean
        With dgvBono
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
            MessageBox.Show("Seleccione la Operación", "Bonos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboOperacion2.Focus()
            Me.cboOperacion2.DroppedDown = True
            Return blnValidar
        End If

        If intOpcion = 1 Then
            If BonoExiste() Then
                Dim strMensaje As String
                strMensaje = "Ya existe un Registro de Bonos para la Operación " & Me.cboOperacion2.Text & Chr(13)
                MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboOperacion2.Focus()
                cboOperacion2.DroppedDown = True
                Return blnValidar
            End If
        End If

        Dim dblInicio As Double, dblFin As Double, dblMonto As Double
        Dim intEstado As Int16 = 0, intFila As Integer = 0, intColumna As Integer = 0, intAcumulado As Integer = 0
        With dgvBono
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
                    strMensaje = "Ingrese los Bonos"
                    intFila = 0
                    intColumna = 1
                End If
                MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvBono.Focus()
                Me.dgvBono.CurrentCell = Me.dgvBono.Rows(intFila).Cells(intColumna)
                Return blnValidar
            End If

            Dim intBonoCruzado As Integer = BonoCruzado()
            If intBonoCruzado > 0 Then
                MessageBox.Show("Rango Incorrecto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvBono.Focus()
                Me.dgvBono.CurrentCell = Me.dgvBono.Rows(intBonoCruzado - 1).Cells("inicio")
                Return blnValidar
            End If

            If intOpcion = 2 Then
                Dim blnFechaActivacionMod As Boolean = False
                If strFechaActivacion <> Me.dtpFechaActivacion.Value.Date.ToShortDateString Then
                    blnFechaActivacionMod = True
                End If
                If BonoModificado() = False And intFilasBono = dgvBono.Rows.Count - 1 And blnFechaActivacionMod = False Then
                    MessageBox.Show("Modifique los Bonos", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dgvBono.Focus()
                    Me.dgvBono.CurrentCell = Me.dgvBono.Rows(0).Cells("inicio")
                    Return blnValidar
                End If
            End If
        End With

        blnValidar = True
        Return blnValidar
    End Function

    Function ValidaItem(a As Integer, b As Integer, c As Integer) As Boolean
        If a = 0 Then
            Return False
        ElseIf b = 0 Then
            Return False
        ElseIf c = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub Grabar()
        Try
            Dim objLN As New Cls_EntregaCarga_LN
            Dim dblInicio As Double = 0, dblFin As Double, dblValor As Double, intID As Integer = dgvBono.Rows(0).Cells("id").Value, intOpcion2 As Integer = 0
            For Each row As DataGridViewRow In dgvBono.Rows
                If row.Cells("valor").Value > 0 Then
                    intOpcion2 += 1
                    dblInicio = row.Cells("inicio").Value
                    dblFin = row.Cells("fin").Value
                    dblValor = row.Cells("valor").Value
                    intID = objLN.GrabarBono(intOpcion2, intID, Me.cboOperacion2.SelectedIndex, dblInicio, dblFin, dblValor, Me.dtpFechaActivacion.Value.ToShortDateString)
                End If
            Next
            MessageBox.Show("Bono Actualizado", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ListarBono()
            Me.tabBonoEntrega.SelectedIndex = 0

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Anular(operacion As Integer)
        Dim obj As New Cls_EntregaCarga_LN

        obj.AnularBono(operacion)
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular los Bonos para la Categoria " & Me.dgvLista.CurrentRow.Cells("operacion").Value & "?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Anular(Me.dgvLista.CurrentRow.Cells("id").Value)
                MessageBox.Show("Bono Anulado", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ListarBono()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvLista_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick

    End Sub

    Private Sub dgvBono_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBono.CellContentClick

    End Sub
End Class