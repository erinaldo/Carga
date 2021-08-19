Public Class frmVentasGEFactura
    Function UltimoDiaMesAño(mes As Integer, año As Integer) As Integer
        Select Case mes
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31
            Case 4, 6, 9, 11
                Return 30
            Case Else
                If año Mod 4 = 0 Then
                    Return 29
                Else
                    Return 28
                End If
        End Select
    End Function

    Sub LimpiarGrid()
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Me.btnExportar.Enabled = False
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
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
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

    Sub Cabecera()
        Dim i As Integer = 0
        Dim strMes As String = ""
        With dgvResultado
            For Each col As DataGridViewColumn In .Columns
                Select Case i
                    Case 0 : col.HeaderText = "Factura"
                    Case 1 : col.HeaderText = "Ruc"
                    Case 2 : col.HeaderText = "Razón Social"
                    Case 3 : col.HeaderText = "Tipo Facturación"
                    Case 4 : col.HeaderText = "Producto"
                    Case 5 : col.Visible = False
                    Case 6 : col.HeaderText = "Nº Guía"
                    Case 7 : col.HeaderText = "Fecha Guía"
                    Case 8 : col.HeaderText = "Subtotal"
                    Case 9 : col.HeaderText = "Impuesto"
                    Case 10 : col.HeaderText = "Total"
                End Select
                If i > 7 Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "###,###,###0.00"
                End If
                i += 1
            Next
        End With
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltrar.Click
        Filtrar()
    End Sub

    Sub Filtrar()
        Cursor = Cursors.AppStarting
        Try
            Dim strInicio As String, strFin As String, strInicio2 As String, strFin2 As String
            strInicio = "01/" & Me.dtpFechaInicio.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaInicio.Value.Year
            strFin = UltimoDiaMesAño(Me.dtpFechaInicio.Value.Month, Me.dtpFechaInicio.Value.Year).ToString.PadLeft(2, "0") & "/" & _
            Me.dtpFechaInicio.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaInicio.Value.Year

            strInicio2 = Me.dtpInicio.Value.ToShortDateString
            strfin2 = Me.dtpFin.Value.ToShortDateString

            Dim obj As New dtoCuentaCorriente
            Dim dt As DataTable = obj.ListarGEFacturadas(strInicio, strFin, strInicio2, strFin2)
            Me.dgvResultado.DataSource = dt
            Cabecera()
            FormatearGrid()
            If dgvResultado.Rows.Count = 0 Then
                LimpiarGrid()
            Else
                Me.btnExportar.Enabled = True
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
                .Range(.Cells(1, 1), .Cells(1, colIndex)).NumberFormat = "###,###,###0.00"
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
            MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        LimpiarGrid()
        Me.dtpInicio.Value = "01/" & dtpFechaInicio.Value.Month.ToString.PadLeft(2, "0") & "/" & dtpFechaInicio.Value.Year
        Me.dtpFin.Value = UltimoDiaMesAño(Me.dtpFechaInicio.Value.Month, Me.dtpFechaInicio.Value.Year).ToString.PadLeft(2, "0") & "/" & _
        Me.dtpFechaInicio.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaInicio.Value.Year
    End Sub

    Private Sub frmVentasGEFactura_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dtpFechaInicio.Value = Now
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInicio.ValueChanged
        LimpiarGrid()
    End Sub

    Private Sub dtpFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFin.ValueChanged
        LimpiarGrid()
    End Sub
End Class