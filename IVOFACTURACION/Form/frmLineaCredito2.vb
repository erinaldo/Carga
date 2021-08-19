Public Class frmLineaCredito2
    Dim colCliente As New Collection
    Dim autoCliente As New AutoCompleteStringCollection

    Sub inicio()
        Dim obj As New dtoCuentaCorriente
        Dim dt As DataTable = obj.ListarCliente

        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtCliente, dt.DefaultView, colCliente, autoCliente, 0)

        Me.cboEstado.SelectedIndex = 0
    End Sub

    Private Sub frmLineaCredito2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        inicio()
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltrar.Click
        Filtrar()
    End Sub

    Function NombreMes(mes As Integer) As String
        Select Case mes
            Case 1
                Return "Ene"
            Case 2
                Return "Feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Abr"
            Case 5
                Return "May"
            Case 6
                Return "Jun"
            Case 7
                Return "Jul"
            Case 8
                Return "Ago"
            Case 9
                Return "Set"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dic"
        End Select
    End Function
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

    Sub Cabecera()
        Dim i As Integer = 0
        Dim strMes As String = ""
        With dgvResultado
            For Each col As DataGridViewColumn In .Columns
                If i > 3 Then
                    strMes = NombreMes(Val(col.HeaderText.Substring(1, 2))).ToUpper
                    col.HeaderText = strMes & " " & 2000 + Val(col.HeaderText.Substring(3, 2))
                    '.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Columns(i).DefaultCellStyle.Format = "0.00"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "###,###,###0.00"
                Else
                    If i = 2 Then
                        col.HeaderText = "LINEA CREDITO"
                        '.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(i).DefaultCellStyle.Format = "0.00"
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        col.DefaultCellStyle.Format = "###,###,###0.00"
                    End If
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
    End Sub

    Sub Filtrar()
        Cursor = Cursors.AppStarting
        Try
            LimpiarGrid()
            Dim strInicio As String, strFin As String
            Dim intCliente As Integer, intEstado As Integer = EstadoLineaCredito(Me.cboEstado.SelectedIndex)
            strInicio = "01/" & Me.dtpFechaInicio.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaInicio.Value.Year
            strFin = UltimoDiaMesAño(Me.dtpFechaFin.Value.Month, Me.dtpFechaFin.Value.Year).ToString.PadLeft(2, "0") & "/" & _
            Me.dtpFechaFin.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaFin.Value.Year

            If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
                intCliente = 0
            Else
                intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
            End If

            Dim obj As New dtoCuentaCorriente
            Dim dt As DataTable = obj.ListarLineaCredito(strInicio, strFin, intEstado, intCliente)
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
                    If i > 3 Then
                        xlApp.Cells(1, colIndex) = " " & dgvResultado.Columns().Item(i).HeaderText
                    Else
                        xlApp.Cells(1, colIndex) = dgvResultado.Columns().Item(i).HeaderText
                    End If
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
            xlApp.Visible = True
            Cursor = Cursors.Default
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

    Private Sub txtCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not autoCliente.IndexOf(txtCliente.Text) = -1 Then
                Dim ObjPersona As New ClsLbTepsa.dtoPersona
                With ObjPersona
                    .IDPERSONA = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
            Else
                Me.txtCodigoCliente.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                    Dim obj As New dtoCarga
                    Dim strCodigoCliente As String = Me.txtCodigoCliente.Text.Trim
                    Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
                    If dt.Rows.Count > 0 Then
                        Me.txtCliente.Text = dt.Rows(0).Item("cliente")
                    Else
                        MessageBox.Show("El Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As System.EventArgs) Handles txtCliente.TextChanged
        LimpiarGrid()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        LimpiarGrid()
    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As System.EventArgs) Handles dtpFechaFin.ValueChanged
        LimpiarGrid()
    End Sub

    Private Sub txtCodigoCliente_TextChanged(sender As Object, e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        LimpiarGrid()
    End Sub
End Class