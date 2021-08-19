Public Class frmClienteCuentaCorriente
    Dim strTitulo As String

    Function EstadoLineaCredito(estado As Integer) As Integer
        Select Case estado
            Case 0
                Return -1
            Case 1
                Return 1
            Case 2
                Return 0
            Case 3
                Return 2
        End Select
    End Function

    Sub LimpiarGrid()
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Me.btnExportar.Enabled = False
        'Me.btnActualizarPagos.Enabled = False
    End Sub

    Sub Cabecera()
        Dim i As Integer = 0
        Dim strMes As String = ""
        With dgvResultado
            For Each col As DataGridViewColumn In .Columns
                Select Case i
                    Case 0 : col.HeaderText = "Funcionario"
                    Case 1 : col.HeaderText = "Ruc"
                    Case 2 : col.HeaderText = "Razón Social"
                    Case 3 : col.HeaderText = "Estado"
                    Case 4 : col.HeaderText = "Línea Crédito"
                    Case 5 : col.HeaderText = "Monto Deuda"
                End Select
                If i > 3 Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "###,###,###0.00"
                End If
                i += 1
            Next
        End With
    End Sub

    Sub FormatearGrid()
        With dgvResultado
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvSalida)
            '.Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            .ReadOnly = False
        End With
    End Sub

    Private Sub frmClienteCuentaCorriente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim tip As New ToolTip
        tip.ShowAlways = True
        tip.SetToolTip(Me.btnActualizarPagos, "Actualizar Pagos")

        Me.cboEstado.SelectedIndex = 0
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltrar.Click
        Filtrar()
    End Sub

    Sub Filtrar()
        Cursor = Cursors.AppStarting
        Try
            Dim intEstado As Integer = EstadoLineaCredito(Me.cboEstado.SelectedIndex)

            Dim obj As New dtoCuentaCorriente
            Dim dt As DataTable = obj.ListarDeudaCliente(0, intEstado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Me.dgvResultado.DataSource = dt
            Cabecera()
            FormatearGrid()
            If dgvResultado.Rows.Count = 0 Then
                LimpiarGrid()
            Else
                Me.dgvResultado.CurrentCell = Me.dgvResultado.Rows(0).Cells(1)
                Me.dgvResultado.SelectedRows(0).Selected = True
                Me.btnExportar.Enabled = True
                Me.btnActualizarPagos.Enabled = True
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnExportar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim xlApp As New Excel.Application()
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")

            For i = 0 To dgvResultado.Columns().Count - 1
                If dgvResultado.Columns().Item(i).Visible = True Then
                    colIndex = colIndex + 1
                    'xlApp.Cells(1, colIndex) = dgvResultado.Columns().Item(i).DataPropertyName
                    'If i > 3 Then
                    'xlApp.Cells(1, colIndex) = " " & dgvResultado.Columns().Item(i).HeaderText
                    'Else
                    xlApp.Cells(1, colIndex) = dgvResultado.Columns().Item(i).HeaderText
                    'End If
                End If
            Next
            For i = 0 To dgvResultado.Rows().Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dgvResultado.Columns().Count - 1

                    If dgvResultado.Columns().Item(j).Visible = True Then
                        colIndex = colIndex + 1
                        xlApp.Cells(rowIndex, colIndex) = dgvResultado.Rows(i).Cells(j).Value
                    End If
                Next
            Next
            With xlSheet
                '.Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Arial"
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                .Columns.AutoFit()
                '.Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1
            End With
            Cursor = Cursors.Default
            xlApp.Visible = True
            xlApp.UserControl = False

            xlSheet = Nothing
            xlBook = Nothing
            'xlApp.Quit()
            xlApp = Nothing

        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Verifique sus Datos..", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Sub Actualizar(cliente As String)
        Try
            Dim obj As New dtoCuentaCorriente
            Dim dr As System.Data.SqlClient.SqlDataReader = obj.ObtienePagosCliente(cnnSQL, cliente)
            Dim intOpcion As Integer, intRegistros As Integer = 0
            Do
                Do While dr.Read
                    intOpcion = dr(0)
                    If intOpcion = 1 Or intOpcion = 2 Then
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr(10), _
                        dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), dr(19), dr(20), _
                        dr(21), dr(22), dr(0))
                    ElseIf intOpcion = 3 Then
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), "", "", dr(5), dr(6), dr(7), dr(8), _
                        dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), _
                        dr(19), dr(20), dr(0))
                    ElseIf intOpcion = 4 Then
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), dr(5), "", dr(6), dr(7), dr(8), dr(9), _
                        dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), dr(19), _
                        dr(20), dr(21), dr(0))
                    ElseIf intOpcion = 5 Then
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), "", "", dr(5), dr(6), dr(7), dr(8), _
                        dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), _
                        dr(19), dr(20), dr(0))
                    End If
                    intRegistros += 1
                Loop
                dr.NextResult()
            Loop While dr.NextResult
            cnnSQL.Close()

            If intRegistros > 0 Then 'se exportaron pagos del ofisys
                dtoCuentaCorriente.ActualizaCuentaCorriente(cliente)
            End If

            Cursor = Cursors.Default
            Me.Text = strTitulo
            MessageBox.Show("Se Realizó la Actualización", "Actualizar Pagos", MessageBoxButtons.OK)
        Catch ex As Exception
            Me.Text = strTitulo
            Cursor = Cursors.Default
            cnnSQL.Close()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnActualizarPagos_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizarPagos.Click
        Try
            Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Realizar la Actualización?", "Actualizar Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.AppStarting
                'Dim intFila As Integer = Me.dgvResultado.CurrentCell.RowIndex
                Me.Text = Me.Text & Space(15) & "Procesando..."
                Dim strCliente As String = "" 'Me.dgvResultado.CurrentRow.Cells("ruc").Value
                Actualizar(strCliente)
                Filtrar()
                'Me.dgvResultado.CurrentCell = Me.dgvResultado.Rows(intFila).Cells(1)
                'Me.dgvResultado.Rows(intFila).Selected = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmClienteCuentaCorriente_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        strTitulo = Me.Text
    End Sub
End Class