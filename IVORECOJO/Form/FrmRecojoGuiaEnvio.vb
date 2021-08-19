Public Class FrmRecojoGuiaEnvio
    Dim dgv As DataGridView
    Dim bCambio As Boolean = False
    Dim bInicio As Boolean = True
    Public bCambio2 As Boolean = False

    Sub FormatoDgv()
        With DgvComprobante
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            'Dim col_seleccion As New DataGridViewCheckBoxColumn
            'With col_seleccion
            '    .HeaderText = "Sel."
            '    .Name = "sel"
            '    '.DataPropertyName = "id_persona"
            '    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    '.SortMode = DataGridViewColumnSortMode.NotSortable
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    .Width = 35
            '    .SortMode = DataGridViewColumnSortMode.Automatic
            '    .FalseValue = 0
            '    .TrueValue = 1
            'End With

            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .HeaderText = "Fecha"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .HeaderText = "Id"
                .Name = "id"
                .DataPropertyName = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .HeaderText = "Id Tipo Doc"
                .Name = "id_tipo"
                .DataPropertyName = "id_tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .HeaderText = "Tipo Doc"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_documento As New DataGridViewTextBoxColumn
            With col_documento
                .HeaderText = "Nº Doc"
                .Name = "documento"
                .DataPropertyName = "documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .HeaderText = "Orígen"
                .Name = "origen"
                .DataPropertyName = "origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .HeaderText = "Destino"
                .Name = "destino"
                .DataPropertyName = "destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_origen2 As New DataGridViewTextBoxColumn
            With col_origen2
                .HeaderText = "Ag Orígen"
                .Name = "origen2"
                .DataPropertyName = "origen2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_destino2 As New DataGridViewTextBoxColumn
            With col_destino2
                .HeaderText = "Ag Destino"
                .Name = "destino2"
                .DataPropertyName = "destino2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 200
            End With

            Dim col_s As New DataGridViewTextBoxColumn
            With col_s
                .HeaderText = "Subtotal"
                .Name = "subtotal"
                .DataPropertyName = "monto_sub_total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###0.00"
            End With

            Dim col_i As New DataGridViewTextBoxColumn
            With col_i
                .HeaderText = "Impuesto"
                .Name = "impuesto"
                .DataPropertyName = "monto_impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###0.00"
            End With

            Dim col_t As New DataGridViewTextBoxColumn
            With col_t
                .HeaderText = "Total"
                .Name = "total"
                .DataPropertyName = "total_costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###0.00"
            End With

            .Columns.AddRange(col_fecha, col_id_tipo, col_id, col_tipo, col_documento, col_origen, col_origen2, col_destino, _
            col_destino2, col_cliente, col_s, col_i, col_t)
        End With
    End Sub

    Sub FormatoDgvRecojo()
        With DgvRecojo
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                '.DataPropertyName = "cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.Width = 200
            End With

            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .HeaderText = "Dirección"
                .Name = "direccion"
                '.DataPropertyName = "direccion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_hora_listo As New DataGridViewTextBoxColumn
            With col_hora_listo
                .HeaderText = "Hora Listo"
                .Name = "hora_listo"
                '.DataPropertyName = "hora_listo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 54
            End With

            Dim col_hora_cierre As New DataGridViewTextBoxColumn
            With col_hora_cierre
                .HeaderText = "Hora Cierre"
                .Name = "hora_cierre"
                '.DataPropertyName = "hora_cierre"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 54
            End With

            Dim col_tipo_recojo As New DataGridViewTextBoxColumn
            With col_tipo_recojo
                .HeaderText = "Tipo Recojo"
                .Name = "tipo_recojo"
                '.DataPropertyName = "tipo_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 58
                .Visible = False
            End With

            Dim col_ruta As New DataGridViewTextBoxColumn
            With col_ruta
                .HeaderText = "Ruta"
                .Name = "ruta"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.DataPropertyName = "id_ruta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.DisplayStyleForCurrentCellOnly = True
                .ReadOnly = True
            End With

            Dim col_id_recojo As New DataGridViewTextBoxColumn
            With col_id_recojo
                .HeaderText = "Nº"
                .Name = "id_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.DataPropertyName = "id_recojo"
                '.Visible = False
            End With

            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .HeaderText = "Móvil"
                .Name = "movil"
                '.DataPropertyName = "movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_chofer As New DataGridViewTextBoxColumn
            With col_chofer
                .HeaderText = "Chofer"
                .Name = "chofer"
                '.DataPropertyName = "chofer"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            .Columns.AddRange(col_id_recojo, col_cliente, col_direccion, col_hora_listo, col_hora_cierre, _
            col_ruta, col_movil, col_chofer, col_tipo_recojo)
        End With
    End Sub

    Sub Inicio(ByVal dgv As DataGridView)
        Me.dgv = dgv
    End Sub

    Private Sub FrmAsociacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub FrmAsociacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bInicio = True
            bCambio2 = False
            Me.FormatoDgvRecojo()
            Me.FormatoDgv()
            CargarRecojos()
            ListarComprobante(Me.DgvRecojo.CurrentRow.Cells("id_recojo").Value)
            bInicio = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarRecojos()
        Try
            With Me.DgvRecojo
                For Each row As DataGridViewRow In dgv.Rows
                    If CType(row.Cells(0).Value, Boolean) Then
                        .Rows.Add(row.Cells("id_recojo").Value, row.Cells("cliente").Value, row.Cells("direccion").Value, _
                        row.Cells("hora_listo").Value, row.Cells("hora_cierre").Value, _
                        DtoRecojo.ObtieneRuta(row.Cells("ruta").Value), row.Cells("movil").Value, row.Cells("chofer").Value, _
                        row.Cells("tipo_recojo").Value, row.Cells("id_recojo").Value)
                    End If
                Next
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function ExisteEnGrid(ByVal tipo As Integer, ByVal id As Integer) As Boolean
        For Each row As DataGridViewRow In Me.DgvComprobante.Rows
            If row.Cells("id_tipo").Value = tipo And row.Cells("id").Value = id Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim frm As New FrmComprobante
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            With Me.DgvComprobante
                For Each row As DataGridViewRow In cRows
                    If Not ExisteEnGrid(row.Cells("id_tipo").Value, row.Cells("id").Value) Then
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = row.Cells(0).Value
                        .Rows(.Rows.Count - 1).Cells(1).Value = row.Cells(1).Value
                        .Rows(.Rows.Count - 1).Cells(2).Value = row.Cells(2).Value
                        .Rows(.Rows.Count - 1).Cells(3).Value = row.Cells(3).Value
                        .Rows(.Rows.Count - 1).Cells(4).Value = row.Cells(4).Value
                        .Rows(.Rows.Count - 1).Cells(5).Value = row.Cells(5).Value
                        .Rows(.Rows.Count - 1).Cells(6).Value = row.Cells(6).Value
                        .Rows(.Rows.Count - 1).Cells(7).Value = row.Cells(7).Value
                        .Rows(.Rows.Count - 1).Cells(8).Value = row.Cells(8).Value
                        .Rows(.Rows.Count - 1).Cells(9).Value = row.Cells(9).Value
                        .Rows(.Rows.Count - 1).Cells(10).Value = row.Cells(10).Value
                        .Rows(.Rows.Count - 1).Cells(11).Value = row.Cells(11).Value
                        .Rows(.Rows.Count - 1).Cells(12).Value = row.Cells(12).Value
                        .Rows(.Rows.Count - 1).Cells("id_tipo").Value = row.Cells("id_tipo").Value
                        .Rows(.Rows.Count - 1).Cells("id").Value = row.Cells("id").Value
                    End If
                Next
                Me.Cursor = Cursors.Default
            End With
        End If
    End Sub

    Private Sub ToolSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSalir.Click
        Close()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If Me.DgvComprobante.Rows.Count = 1 Or Me.DgvComprobante.SelectedRows.Count = Me.DgvComprobante.Rows.Count Then
            Dim dlgRespuesta As DialogResult
            Dim sMensaje As String = "Eliminará Asociación a Comprobantes de Venta." & Chr(13) & _
            "¿Está Seguro de Continuar?"
            dlgRespuesta = MessageBox.Show(sMensaje, "Recojos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Grabar(Me.DgvRecojo.CurrentRow.Cells("id_recojo").Value, 1)
                bCambio2 = True
                Me.ToolGrabar.Enabled = False
            Else
                bInicio = True
                ListarComprobante(Me.DgvRecojo.CurrentRow.Cells("id_recojo").Value)
                bInicio = False
                Return
            End If
        End If

        For Each row As DataGridViewRow In Me.DgvComprobante.SelectedRows
            Me.DgvComprobante.Rows.Remove(row)
        Next
    End Sub

    Private Sub DgvComprobante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvComprobante.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.BtnEliminar_Click(sender, e)
        End If
    End Sub

    Private Sub ToolGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolGrabar.Click
        Try
            If Me.DgvComprobante.Rows.Count = 0 Then
                MessageBox.Show("Seleccione al menos un Comprobante de Venta a Asociar.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnAgregar.Focus()
                Return
            End If
            Me.Cursor = Cursors.AppStarting
            Grabar(Me.DgvRecojo.CurrentRow.Cells("id_recojo").Value)
            bCambio2 = True
            Me.ToolGrabar.Enabled = False
            Me.Cursor = Cursors.Default
            MessageBox.Show("Recojo Asociado.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar(ByVal id As Integer, Optional ByVal eliminar As Integer = 0)
        Try
            Dim obj As New DtoAsociacion
            Dim iRecojo, iTipo, iNumero, i As Integer
            Dim iEstado = RECOJO.COMPLETADO
            Dim iEstado2 = RECOJO.ATENDIDO
            With Me.DgvComprobante
                iRecojo = id
                For Each row As DataGridViewRow In .Rows
                    iTipo = row.Cells("id_tipo").Value
                    iNumero = row.Cells("id").Value
                    i += 1
                    obj.Grabar(iRecojo, iTipo, iNumero, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, iEstado, i, eliminar, iEstado2)
                Next
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ListarComprobante(ByVal recojo As Integer)
        Dim obj As New DtoAsociacion
        Dim dt As DataTable = obj.Buscar(recojo)

        With Me.DgvComprobante
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = row(0)
                    .Rows(.Rows.Count - 1).Cells(1).Value = row(1)
                    .Rows(.Rows.Count - 1).Cells(2).Value = row(2)
                    .Rows(.Rows.Count - 1).Cells(3).Value = row(3)
                    .Rows(.Rows.Count - 1).Cells(4).Value = row(4)
                    .Rows(.Rows.Count - 1).Cells(5).Value = row(5)
                    .Rows(.Rows.Count - 1).Cells(6).Value = row(6)
                    .Rows(.Rows.Count - 1).Cells(7).Value = row(7)
                    .Rows(.Rows.Count - 1).Cells(8).Value = row(8)
                    .Rows(.Rows.Count - 1).Cells(9).Value = row(9)
                    .Rows(.Rows.Count - 1).Cells(10).Value = row(10)
                    .Rows(.Rows.Count - 1).Cells(11).Value = row(11)
                    .Rows(.Rows.Count - 1).Cells(12).Value = row(12)
                    .Rows(.Rows.Count - 1).Cells("id_tipo").Value = row("id_tipo")
                    .Rows(.Rows.Count - 1).Cells("id").Value = row("id")
                Next
            End If
            Me.Cursor = Cursors.Default
        End With

    End Sub

    Private Sub DgvComprobante_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvComprobante.RowsAdded
        If Me.DgvComprobante.Rows.Count = 0 Then
            Me.BtnEliminar.Enabled = False
        Else
            Me.BtnEliminar.Enabled = True
        End If
        If Not bInicio Then
            If Me.DgvComprobante.Rows.Count > 0 Then
                bCambio = True
                Me.ToolGrabar.Enabled = True
            Else
                bCambio = False
                Me.ToolGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub DgvComprobante_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvComprobante.RowsRemoved
        If Me.DgvComprobante.Rows.Count = 0 Then
            Me.BtnEliminar.Enabled = False
        Else
            Me.BtnEliminar.Enabled = True
        End If
        If Not bInicio Then
            If Me.DgvComprobante.Rows.Count > 0 Then
                bCambio = True
                Me.ToolGrabar.Enabled = True
            Else
                bCambio = False
                Me.ToolGrabar.Enabled = False
            End If
        End If
    End Sub
End Class