Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmBonoOperacion
    Private Sub ConfigurarDGVBono()
        With dgvBono
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
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
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_peso_in As New DataGridViewTextBoxColumn
            With col_peso_in
                .Name = "peso_in" : .DataPropertyName = "peso_in"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso IN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso_out As New DataGridViewTextBoxColumn
            With col_peso_out
                .Name = "peso_out" : .DataPropertyName = "peso_out"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso OUT"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso_total As New DataGridViewTextBoxColumn
            With col_peso_total
                .Name = "peso_total" : .DataPropertyName = "peso_total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_operacion1 As New DataGridViewTextBoxColumn
            With col_operacion1
                .Name = "operacion1" : .DataPropertyName = "operacion1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Recepción Carga"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_operacion2 As New DataGridViewTextBoxColumn
            With col_operacion2
                .Name = "operacion2" : .DataPropertyName = "operacion2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Asignación Móvil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_operacion3 As New DataGridViewTextBoxColumn
            With col_operacion3
                .Name = "operacion3" : .DataPropertyName = "operacion3"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Entrega Dom 24 Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_operacion4 As New DataGridViewTextBoxColumn
            With col_operacion4
                .Name = "operacion4" : .DataPropertyName = "operacion4"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Devolución Cargos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_operacion5 As New DataGridViewTextBoxColumn
            With col_operacion5
                .Name = "operacion5" : .DataPropertyName = "operacion5"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Confirmación Entrega Age"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_operacion6 As New DataGridViewTextBoxColumn
            With col_operacion6
                .Name = "operacion6" : .DataPropertyName = "operacion6"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Confirmación Entrega Dom"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_bono_oficina As New DataGridViewTextBoxColumn
            With col_bono_oficina
                .Name = "bono_oficina" : .DataPropertyName = "bono_oficina"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Oficina"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_bono_reparto As New DataGridViewTextBoxColumn
            With col_bono_reparto
                .Name = "bono_reparto" : .DataPropertyName = "bono_reparto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bono Reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso_reparto As New DataGridViewTextBoxColumn
            With col_peso_reparto
                .Name = "peso_reparto" : .DataPropertyName = "peso_reparto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso Reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_monto_reparto As New DataGridViewTextBoxColumn
            With col_monto_reparto
                .Name = "monto_reparto" : .DataPropertyName = "monto_reparto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_total_bono As New DataGridViewTextBoxColumn
            With col_total_bono
                .Name = "total_bono" : .DataPropertyName = "total_bono"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Bono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            .Columns.AddRange(col_ciudad, col_peso_in, col_peso_out, col_peso_total, _
                              col_operacion1, col_operacion2, col_operacion3, col_operacion4, col_operacion5, col_operacion6, _
                              col_bono_oficina, col_bono_reparto, col_peso_reparto, col_monto_reparto, col_total_bono)
        End With
    End Sub
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Sub Consultar()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Bono_LN
            Dim strFecha As String, strPeriodo As String

            strFecha = Me.dtpPeriodo.Value.ToShortDateString
            strPeriodo = "01/" & Format(CDate(strFecha), "MM/yyyy")

            Dim intCiudad As Integer = Me.cboCiudad.SelectedValue

            Dim dt As DataTable = obj.ListarBono(strPeriodo, intCiudad)
            Me.dgvBono.DataSource = dt

            Me.btnExportar.Enabled = Me.dgvBono.Rows.Count > 0

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmBonoOperacion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim obj As New Cls_Gasto_LN

        With cboCiudad
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad(1)
            .SelectedValue = dtoUSUARIOS.m_idciudad
            If Acceso.SiRol(G_Rol, Me, 1, 2) Then 'todo
                .Enabled = True
            Else
                .Enabled = False
            End If
        End With

        ConfigurarDGVBono()
    End Sub

    Private Sub btnExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnExportar.Click
        Cursor = Cursors.AppStarting
        Dim xlApp As New Excel.Application()
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim dblTotal As Double = 0, intColumna As Integer = 0
        Try
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")

            'detalle
            rowIndex = 1
            For i = 0 To dgvBono.Rows.Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dgvBono.Columns.Count - 1
                    If dgvBono.Columns(j).Visible Then
                        colIndex = colIndex + 1
                        xlApp.Cells(1, colIndex) = dgvBono.Columns(j).HeaderText.ToString.ToUpper
                        xlApp.Cells(rowIndex, colIndex) = dgvBono.Rows(i).Cells(j).Value
                        If j > 0 Then
                            xlSheet.Range(xlSheet.Cells(rowIndex, colIndex), xlSheet.Cells(rowIndex, colIndex)).NumberFormat = "###,###,###.00"
                            If dgvBono.Columns(j).Name.ToString.ToUpper = "MONTO" Then
                                intColumna = colIndex
                                dblTotal += dgvBono.Rows(i).Cells(j).Value
                            End If
                        End If
                    End If
                Next
            Next
            'xlApp.Cells(rowIndex + 1, intColumna - 1) = "TOTAL"
            'xlApp.Cells(rowIndex + 1, intColumna) = Format(dblTotal, "###,###,###0.00")

            xlSheet.Range(xlSheet.Cells(1, 1), xlSheet.Cells(1, colIndex)).Font.Bold = True
            'xlSheet.Range(xlSheet.Cells(rowIndex + 1, intColumna - 1), xlSheet.Cells(rowIndex + 1, intColumna)).Font.Bold = True
            xlSheet.Columns.AutoFit()

            Cursor = Cursors.Default
            xlApp.Visible = True
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xlApp.Quit()
            xlApp.Visible = False
        End Try

    End Sub
End Class