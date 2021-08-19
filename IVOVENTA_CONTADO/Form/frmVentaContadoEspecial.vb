Public Class frmVentaContadoEspecial
    Dim dt As DataTable
    Dim intPerfil As Integer

#Region "Grid"
    Sub Configurardgv()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = False
            .RowHeadersWidth = 30
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .ValueType = Type.GetType("System.Double")
            End With

            x += +1
            Dim col_dias As New DataGridViewTextBoxColumn
            With col_dias
                .Name = "dias" : .DataPropertyName = "dias"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Días sin Cancelar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            'x += +1
            'Dim col_estado As New DataGridViewTextBoxColumn
            'With col_estado
            '    .Name = "estado" : .DataPropertyName = "estado"
            '    .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '    .ReadOnly = True
            'End With

            x += +1
            Dim col_cancelado As New DataGridViewCheckBoxColumn
            With col_cancelado
                '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                .HeaderText = "Cancelado"
                .Name = "cancelado"
                .DataPropertyName = "cancelado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.SortMode = DataGridViewColumnSortMode.Automatic
                .FalseValue = 0
                .TrueValue = 1
                '.ThreeState = True
                .ReadOnly = False : .DisplayIndex = x
            End With

            .Columns.AddRange(col_id, col_fecha, col_numero_documento, col_cliente, col_comprobante, col_origen, col_destino, col_total, col_dias, col_cancelado, col_id_estado)
        End With
    End Sub
#End Region

    Private Sub frmVentaContadoEspecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Configurardgv()
        Me.dtpInicio.Value = DateAdd(DateInterval.Month, -1, Me.dtpFin.Value)
        Me.cboEstado.SelectedIndex = 1

        If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            intPerfil = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            intPerfil = 2
        Else
            intPerfil = 0
        End If

        If intPerfil <> 1 Then
            Me.tsbLiquidar.Visible = False
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Sub Consultar()
        Cursor = Cursors.AppStarting
        Dim obj As New dtoVentaCargaContado
        Dim intUsuario As Integer = 0
        If intPerfil = 1 Then
            intUsuario = dtoUSUARIOS.IdLogin
        End If
        dt = obj.ListarVentaEspecial(Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, Me.cboEstado.SelectedIndex, intUsuario)
        Dim dt2 As DataTable
        dt2 = dt.Copy

        If Me.cboEstado.SelectedIndex > 0 Then
            Dim intCancelado As Integer = IIf(Me.cboEstado.SelectedIndex = 1, 0, 1)
            dt.DefaultView.RowFilter = "id_estado=" & intCancelado & ""
        End If
        Me.dgv.DataSource = dt
        dgv.Refresh()
        Total(dt2)
        Cursor = Cursors.Default
    End Sub

    Sub Total(ByVal dt As DataTable)
        Dim dblTotalVenta As Double = IIf(IsDBNull(dt.Compute("sum(total)", "")), 0, dt.Compute("sum(total)", ""))
        Dim dblTotalPagado As Double = IIf(IsDBNull(dt.Compute("sum(total)", "cancelado=1")), 0, dt.Compute("sum(total)", "cancelado=1"))
        Dim dblSaldo As Double = dblTotalVenta - dblTotalPagado

        Me.lblTotalVenta.Text = Format(dblTotalVenta, "###,###,###0.00")
        Me.lblTotalPagado.Text = Format(dblTotalPagado, "###,###,###0.00")
        Me.lblSaldo.Text = Format(dblSaldo, "###,###,###0.00")
    End Sub

    Function PuedeCancelar() As Boolean
        For Each row As DataGridViewRow In Me.dgv.Rows
            If row.Cells("id_estado").Value = 0 And row.Cells("cancelado").Value = 1 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub dgv_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If e.ColumnIndex < 9 Then Return

        Dim intEstado As Integer = dgv.Rows(e.RowIndex).Cells("id_estado").Value
        If intPerfil <> 1 Then
            dgv.Rows(e.RowIndex).Cells("cancelado").Value = intEstado
            Me.dgv.RefreshEdit()
            Return
        End If

        If intEstado = 0 Then
            If PuedeCancelar() Then
                Me.tsbLiquidar.Enabled = True
            Else
                Me.tsbLiquidar.Enabled = False
            End If
        Else
            dgv.Rows(e.RowIndex).Cells("cancelado").Value = 1
            Me.dgv.RefreshEdit()
        End If
    End Sub

    Private Sub dgv_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        If e.ColumnIndex < 9 Then Return

        Dim intEstado As Integer = dgv.Rows(e.RowIndex).Cells("id_estado").Value
        If intPerfil <> 1 Then
            dgv.Rows(e.RowIndex).Cells("cancelado").Value = intEstado
            Me.dgv.RefreshEdit()
            Return
        End If

        If intEstado = 0 Then
            If PuedeCancelar() Then
                Me.tsbLiquidar.Enabled = True
            Else
                Me.tsbLiquidar.Enabled = False
            End If
        Else
            dgv.Rows(e.RowIndex).Cells("cancelado").Value = 1
            Me.dgv.RefreshEdit()
        End If
    End Sub

    Private Sub dgv_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.CurrentCellDirtyStateChanged
        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub tsbLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLiquidar.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de liquidar los comprobantes seleccionados?", "Venta Contado Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Dim intCancelado As Integer, intIdEstado As Integer
            Dim intID As Integer
            Dim obj As New dtoVentaCargaContado
            For Each row As DataGridViewRow In Me.dgv.Rows
                intID = row.Cells("id").Value
                intCancelado = row.Cells("cancelado").Value
                intIdEstado = row.Cells("id_estado").Value
                If intCancelado = 1 And intIdEstado = 0 Then
                    obj.CancelarComprobante(intID, intCancelado)
                    Me.Consultar()
                    Me.tsbLiquidar.Enabled = PuedeCancelar()
                End If
            Next
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Function ExisteCheck(ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells("cancelado").Value) Then
                If row.Cells("cancelado").Value = 1 And row.Cells("id_estado").Value = 0 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer)
        Try
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells("id_estado").Value = 0 Then
                    row.Cells(col).Value = estado
                    Me.dgv.RefreshEdit()
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgv_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.tsbLiquidar.Visible = False Then
                Me.menu.Items(0).Visible = False
                Me.menu.Items(1).Visible = False
                Return
            End If
            If dgv.Rows.Count = 0 Or Not Me.ExisteCheck(dgv) Then
                Me.menu.Items(0).Visible = False
                Me.menu.Items(1).Visible = False
                If dgv.Rows.Count = 0 Then
                    Me.menu.Items(0).Visible = False
                    Me.menu.Items(1).Visible = False
                Else
                    Me.menu.Items(0).Visible = True
                    Me.menu.Items(1).Visible = True
                End If
            End If
            Me.Cursor = Cursors.AppStarting
            menu.Show(sender, e.X, e.Y)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub MnuContextSelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelTodo.Click
        SeleccionarCheckDgv(Me.dgv, 9, 1)
    End Sub

    Private Sub MnuContextSelEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelEliminar.Click
        SeleccionarCheckDgv(Me.dgv, 9, 0)
    End Sub
End Class