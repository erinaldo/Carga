Public Class FrmSalidaCarga
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Private Sub btnExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnExportar.Click
        fnEXCELGrid_ConFormato(dgvSalida)
    End Sub

    Sub FormatearGrid()
        With dgvSalida
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
            .AutoGenerateColumns = False
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

    Function EsCiudad(ciudad As String) As Boolean
        If ciudad.Trim.Substring(0, 1).ToUpper = "P" AndAlso IsNumeric(ciudad.Trim.Substring(1, 1)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function fnEXCELGrid_ConFormato(ByVal dGridView As DataGridView) As Boolean
        Try
            Dim xlApp As New Excel.Application()
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")
            '  Dim cVisibles As Integer = 0

            'For i = 0 To dGridView.Columns().Count - 1

            '    If dGridView.Columns().Item(i).Visible = True Then
            '        cVisibles = cVisibles + 1
            '    End If
            'Next

            For i = 0 To dGridView.Columns().Count - 1
                If dGridView.Columns().Item(i).Visible = True Then
                    colIndex = colIndex + 1
                    'xlApp.Cells(1, colIndex) = dGridView.Columns().Item(i).DataPropertyName
                    xlApp.Cells(1, colIndex) = dGridView.Columns().Item(i).HeaderText
                End If
            Next
            For i = 0 To dGridView.Rows().Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dGridView.Columns().Count - 1

                    If dGridView.Columns().Item(j).Visible = True Then
                        colIndex = colIndex + 1
                        xlApp.Cells(rowIndex, colIndex) = dGridView.Rows(i).Cells(j).Value
                    End If

                Next
            Next
            With xlSheet
                '.Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Arial"
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                '.Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1

            End With
            xlApp.Visible = True

        Catch ex As Exception
            MsgBox("Verifique sus Datos..", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function

    Sub ActualizaGrid(dt As DataTable)
        Dim strCiudad As String
        Dim dblPeso As Double
        Dim intCiudad As Integer
        For Each col As DataGridViewColumn In dgvSalida.Columns
            col.Visible = True
            strCiudad = col.DataPropertyName
            If EsCiudad(strCiudad) Then
                col.HeaderText = fnGetCiudad(strCiudad.Trim.Substring(1))
                dblPeso = IIf(IsDBNull(dt.Compute("sum(" & strCiudad & ")", "")), 0, dt.Compute("sum(" & strCiudad & ")", ""))
                If dblPeso = 0 Then
                    col.Visible = False
                End If
                'col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        If dgvSalida.Rows.Count > 0 Then
            If dgvSalida.Columns.Count > 4 Then
                For i As Integer = 5 To dgvSalida.Columns.Count - 1
                    dgvSalida.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvSalida.Columns(i).DefaultCellStyle.Format = "0.00"
                Next
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub FrmSalidaCarga_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        objgeneral.FN_L_UNIDAD_agencia_(Me.cboOrigen)
        objgeneral.FN_L_UNIDAD_agencia_(Me.cboDestino)
        Me.cboOrigen.SelectedValue = 0
        'objgeneral.FN_cmb_sp_L_tipo_servicio(Me.cboServicio)
        Me.cboServicio.SelectedIndex = 0
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltrar.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim intBus As Integer = IIf(Val(Me.txtBus.Text.Trim) > 0, Me.txtBus.Text.Trim, 0)
        Dim intServicio As Integer = Me.cboServicio.SelectedIndex
        Dim intOrigen As Integer = Me.cboOrigen.SelectedValue
        Dim intDestino As Integer = Me.cboDestino.SelectedValue
        Dim intOpcion As Integer = IIf(Me.rbtOrigen.Checked, 1, 2)
        Dim dt As DataTable = dtoCarga.SalidaCarga(dtpFechaInicio.Text, dtpFechaFin.Text, intBus, intServicio, intOrigen, intDestino, intOpcion)
        dgvSalida.DataSource = dt
        ActualizaGrid(dt)
        FormatearGrid()
        If dgvSalida.Rows.Count > 0 Then
            'Dim row As DataRow = dt.NewRow
            Dim dblPeso As Double = IIf(IsDBNull(dt.Compute("sum(peso)", "")), 0, dt.Compute("sum(peso)", ""))
            Dim dblVolumen As Double = IIf(IsDBNull(dt.Compute("sum(volumen)", "")), 0, dt.Compute("sum(volumen)", ""))

            Dim dblKg As Double = IIf(IsDBNull(dt.Compute("sum(kg)", "")), 0, dt.Compute("sum(kg)", ""))

            'Dim dblKm As Double = IIf(IsDBNull(dt.Compute("sum(km2)", "")), 0, dt.Compute("sum(km2)", ""))
            Dim dblKm As Double = dtoCarga.TotalKm(IIf(Me.rbtCompleto.Checked, 1, 0))
            Dim dblSoles As Double = IIf(IsDBNull(dt.Compute("sum(soles)", "")), 0, dt.Compute("sum(soles)", ""))

            'row("peso") = Format(dblPeso, "0.00")
            'row("volumen") = Format(dblVolumen, "0.00")
            'row("kg") = Format(dblKg, "0.00")
            'row("km") = Format(dblKm, "0.00")
            'row("soles") = Format(dblSoles, "0.00")
            'row("soleskm") = Math.Round(dblSoles / dblKm, 2)
            'row("soleskg") = Math.Round(dblSoles / dblKg, 2)
            'dt.Rows.Add(row)
            'dgvSalida.Rows(dgvSalida.Rows.Count - 1).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            'dgvSalida.Rows(dgvSalida.Rows.Count - 1).Visible = False

            Me.lblPeso.Text = Format(dblPeso, "0.00")
            Me.lblVolumen.Text = Format(dblVolumen, "0.00")
            Me.lblkg.Text = Format(dblKg, "0.00")
            Me.lblKm.Text = Format(IIf(dblKm = 1, 0, dblKm), "0.00")
            Me.lblSoles.Text = Format(dblSoles, "0.00")
            Me.lblSpk.Text = Format(Math.Round(dblSoles / dblKm, 2), "0.00")
            Me.lblSpkg.Text = Format(Math.Round(dblSoles / dblKg, 2), "0.00")
        Else
            Me.lblPeso.Text = "0.00"
            Me.lblVolumen.Text = "0.00"
            Me.lblKg.Text = "0.00"
            Me.lblKm.Text = "0.00"
            Me.lblSoles.Text = "0.00"
            Me.lblSpk.Text = "0.00"
            Me.lblSpkg.Text = "0.00"
        End If

        Me.btnExportar.Enabled = IIf(Me.dgvSalida.Rows.Count > 0, True, False)
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtBus_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBus.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub rbtOrigen_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtOrigen.CheckedChanged
        Me.dgvSalida.DataSource = Nothing
        Me.LimpiarTotales()
    End Sub

    Private Sub rbtCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtCompleto.CheckedChanged
        Me.dgvSalida.DataSource = Nothing
        Me.LimpiarTotales()
    End Sub

    Sub LimpiarTotales()
        Me.lblPeso.Text = "0.00"
        Me.lblVolumen.Text = "0.00"
        Me.lblKg.Text = "0.00"
        Me.lblKm.Text = "0.00"
        Me.lblSoles.Text = "0.00"
        Me.lblSpk.Text = "0.00"
        Me.lblSpkg.Text = "0.00"
    End Sub
End Class
