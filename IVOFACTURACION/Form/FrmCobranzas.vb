Public Class LblNc
    Public sFactura As String
    Public sFecha As String
    Public iTotal As Double
    Public iAcuenta As Double
    Public iSaldo As Double
    Public iFactura As Integer
    Dim BlnInicio As Boolean = True
    Dim iTipo2 As Integer = 0

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Close()
    End Sub

    Private Sub LblNc_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FrmCobranzas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblNumero.Text = sFactura
        Me.LblFecha.Text = sFecha
        Me.LblTotal.Text = Format(iTotal, "#,###,###0.00")
        Me.LblAcuenta.Text = Format(iAcuenta, "#,###,###0.00")
        Me.LblSaldo.Text = Format(iSaldo, "#,###,###0.00")

        'FormatoBanco()

        Dim s As New RadioButton
        's.Name = "rbttodo"
        'Visualiza(s, e)
        Me.RbtTodo.Checked = True

        Dim obj As New dtoCobranza
        Dim dt As DataTable = obj.TotalCobranza(iFactura).Tables(0)
        Total(dt)

        obj = Nothing
    End Sub

    Sub Visualiza(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtBanco.CheckedChanged, RbtCredito.CheckedChanged, RbtCaja.CheckedChanged, RbtAnticipo.CheckedChanged, RbtCanje.CheckedChanged, RbtTodo.CheckedChanged
        Try
            Me.Cursor = Cursors.AppStarting
            Me.dgvCobranza.DataSource = Nothing
            If BlnInicio Then
                'BlnInicio = False
                'Return
            End If
            Dim iTipo As Integer
            Select Case CType(sender, RadioButton).Name.ToLower
                Case "rbttodo"
                    If RbtTodo.Checked Then
                        iTipo = 0
                        Formato()
                    Else
                        Return
                    End If
                Case "rbtbanco"
                    If RbtBanco.Checked Then
                        iTipo = 1
                        FormatoBanco()
                    Else
                        Return
                    End If
                Case "rbtcredito"
                    If RbtCredito.Checked Then
                        iTipo = 2
                        FormatoCredito()
                    Else
                        Return
                    End If
                Case "rbtcaja"
                    If RbtCaja.Checked Then
                        iTipo = 3
                        FormatoCaja()
                    Else
                        Return
                    End If
                Case "rbtanticipo"
                    If RbtAnticipo.Checked Then
                        iTipo = 4
                        FormatoAnticipo()
                    Else
                        Return
                    End If
                Case "rbtcanje"
                    If RbtCanje.Checked Then
                        iTipo = 5
                        FormatoCanje()
                    Else
                        Return
                    End If
            End Select

            'If iTipo = iTipo2 Then Return
            'iTipo2 = iTipo

            Dim ObjCobranza As New dtoCobranza
            Dim ds As DataSet = ObjCobranza.CargarCobranza(iTipo, iFactura)
            Me.dgvCobranza.DataSource = ds.Tables(0)

            Me.DgvHistorico.DataSource = Nothing
            If dgvCobranza.Rows.Count > 0 Then
                VisualizaHistorico()
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvCobranza_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCobranza.CellClick
        VisualizaHistorico()
    End Sub

    Private Sub dgvCobranza_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCobranza.CellContentClick

    End Sub

    Sub VisualizaHistorico()
        Try
            Dim iTipo As Integer
            If Me.RbtTodo.Checked Then
                iTipo = 0
                FormatoH()
            ElseIf Me.RbtBanco.Checked Then
                iTipo = 1
                FormatoBancoH()
            ElseIf Me.RbtCredito.Checked Then
                iTipo = 2
                FormatoCreditoH()
            ElseIf Me.RbtCaja.Checked Then
                iTipo = 3
                FormatoCajaH()
            ElseIf Me.RbtAnticipo.Checked Then
                iTipo = 4
                FormatoAnticipoH()
            ElseIf Me.RbtCanje.Checked Then
                iTipo = 5
                FormatoCanjeH()
            End If

            Dim objHistorico As New dtoCobranza
            Dim ds As DataSet
            With dgvCobranza.CurrentRow
                If iTipo = 0 Then
                    ds = objHistorico.CargarHistoricoTodo(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(5).Value _
                    , .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(3).Value)
                ElseIf iTipo = 1 Then
                    ds = objHistorico.CargarHistorico(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value _
                    , .Cells(4).Value, .Cells(5).Value, .Cells(6).Value)
                ElseIf iTipo = 2 Then
                    ds = objHistorico.CargarHistorico(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value _
                    , .Cells(4).Value)
                ElseIf iTipo = 3 Then
                    ds = objHistorico.CargarHistorico(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value _
                    , .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, 1, 1)
                ElseIf iTipo = 4 Then
                    ds = objHistorico.CargarHistorico(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value _
                    , .Cells(4).Value, 1, "a", 1)
                ElseIf iTipo = 5 Then
                    ds = objHistorico.CargarHistorico(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value _
                    , .Cells(4).Value, .Cells(5).Value)
                End If
            End With
            DgvHistorico.DataSource = ds.Tables(0)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Total(ByVal dt As DataTable)
        For Each row As DataRow In dt.Rows
            Select Case row("num")
                Case 1
                    Me.LblBanco.Text = Format(row("total"), "#,###,###0.00")
                Case 2
                    Me.LblCredito.Text = Format(row("total"), "#,###,###0.00")
                Case 3
                    Me.LblCaja.Text = Format(row("total"), "#,###,###0.00")
                Case 4
                    Me.LblAnticipo.Text = Format(row("total"), "#,###,###0.00")
                Case 5
                    Me.LblCanje.Text = Format(row("total"), "#,###,###0.00")
            End Select
        Next
    End Sub

    Sub FormatoBanco()
        With dgvCobranza
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_BANC As New DataGridViewTextBoxColumn
        With CO_BANC
            .HeaderText = "Banco"
            .Name = ""
            .DataPropertyName = "co_banc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim AA_BNCO As New DataGridViewTextBoxColumn
        With AA_BNCO
            .HeaderText = "Año"
            .Name = ""
            .DataPropertyName = "aa_bnco"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim MM_BNCO As New DataGridViewTextBoxColumn
        With MM_BNCO
            .HeaderText = "Mes"
            .Name = ""
            .DataPropertyName = "mm_bnco"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim TI_MOVI_BANC As New DataGridViewTextBoxColumn
        With TI_MOVI_BANC
            .HeaderText = "Mov."
            .Name = ""
            .DataPropertyName = "ti_movi_banc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_COMP_BANC As New DataGridViewTextBoxColumn
        With NU_COMP_BANC
            .HeaderText = "Nº Comprob"
            .Name = ""
            .DataPropertyName = "NU_COMP_BANC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_OPER As New DataGridViewTextBoxColumn
        With FE_OPER
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_OPER"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_DETA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With dgvCobranza
            .Columns.AddRange(CO_EMPR, CO_BANC, AA_BNCO, MM_BNCO, TI_MOVI_BANC, NU_COMP_BANC, NU_SECU, FE_OPER, IM_DETA)
        End With
    End Sub

    Sub FormatoCredito()
        With dgvCobranza
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_UNID_CONC As New DataGridViewTextBoxColumn
        With CO_UNID_CONC
            .HeaderText = "Unidad"
            .Name = ""
            .DataPropertyName = "CO_UNID_CONC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_AMAR As New DataGridViewTextBoxColumn
        With NU_AMAR
            .HeaderText = "Nº Amarre"
            .Name = ""
            .DataPropertyName = "NU_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_AMAR As New DataGridViewTextBoxColumn
        With FE_AMAR
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_PAGA As New DataGridViewTextBoxColumn
        With IM_PAGA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_COBR_DEST"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With dgvCobranza
            .Columns.AddRange(CO_EMPR, CO_UNID_CONC, NU_AMAR, FE_AMAR, NU_SECU, IM_PAGA)
        End With
    End Sub

    Sub FormatoCaja()
        With dgvCobranza
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_CAJA As New DataGridViewTextBoxColumn
        With CO_CAJA
            .HeaderText = "Caja"
            .Name = ""
            .DataPropertyName = "CO_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim AA_CAJA As New DataGridViewTextBoxColumn
        With AA_CAJA
            .HeaderText = "Año"
            .Name = ""
            .DataPropertyName = "AA_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim MM_CAJA As New DataGridViewTextBoxColumn
        With MM_CAJA
            .HeaderText = "Mes"
            .Name = ""
            .DataPropertyName = "MM_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim TI_MOVI As New DataGridViewTextBoxColumn
        With TI_MOVI
            .HeaderText = "Mov."
            .Name = ""
            .DataPropertyName = "TI_MOVI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_COMP_CAJA As New DataGridViewTextBoxColumn
        With NU_COMP_CAJA
            .HeaderText = "Nº Comprob"
            .Name = ""
            .DataPropertyName = "NU_COMP_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_OPER As New DataGridViewTextBoxColumn
        With FE_OPER
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_OPER"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_DETA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With dgvCobranza
            .Columns.AddRange(CO_EMPR, CO_CAJA, AA_CAJA, MM_CAJA, TI_MOVI, NU_COMP_CAJA, NU_SECU, FE_OPER, IM_DETA)
        End With
    End Sub

    Sub FormatoAnticipo()
        With dgvCobranza
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_UNID_CONC As New DataGridViewTextBoxColumn
        With CO_UNID_CONC
            .HeaderText = "Unidad"
            .Name = ""
            .DataPropertyName = "CO_UNID_CONC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_AMAR As New DataGridViewTextBoxColumn
        With NU_AMAR
            .HeaderText = "Nº Amarre"
            .Name = ""
            .DataPropertyName = "NU_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_AMAR As New DataGridViewTextBoxColumn
        With FE_AMAR
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_DETA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With dgvCobranza
            .Columns.AddRange(CO_EMPR, CO_UNID_CONC, NU_AMAR, FE_AMAR, NU_SECU, IM_DETA)
        End With
    End Sub

    Sub FormatoCanje()
        With dgvCobranza
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_UNID_CONC As New DataGridViewTextBoxColumn
        With CO_UNID_CONC
            .HeaderText = "Unidad"
            .Name = ""
            .DataPropertyName = "CO_UNID_CONC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_CANJ As New DataGridViewTextBoxColumn
        With NU_CANJ
            .HeaderText = "Nº Canje"
            .Name = ""
            .DataPropertyName = "NU_CANJ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_CANJ As New DataGridViewTextBoxColumn
        With FE_CANJ
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_CANJ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU_CANJ As New DataGridViewTextBoxColumn
        With NU_SECU_CANJ
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU_CANJ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_PAGA As New DataGridViewTextBoxColumn
        With IM_PAGA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_PAGA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With dgvCobranza
            .Columns.AddRange(CO_EMPR, CO_UNID_CONC, NU_CANJ, FE_CANJ, NU_SECU_CANJ, IM_PAGA)
        End With
    End Sub

    Sub FormatoBancoH()
        With DgvHistorico
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_BANC As New DataGridViewTextBoxColumn
        With CO_BANC
            .HeaderText = "Banco"
            .Name = ""
            .DataPropertyName = "co_banc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim AA_BNCO As New DataGridViewTextBoxColumn
        With AA_BNCO
            .HeaderText = "Año"
            .Name = ""
            .DataPropertyName = "aa_bnco"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim MM_BNCO As New DataGridViewTextBoxColumn
        With MM_BNCO
            .HeaderText = "Mes"
            .Name = ""
            .DataPropertyName = "mm_bnco"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim TI_MOVI_BANC As New DataGridViewTextBoxColumn
        With TI_MOVI_BANC
            .HeaderText = "Mov."
            .Name = ""
            .DataPropertyName = "ti_movi_banc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_COMP_BANC As New DataGridViewTextBoxColumn
        With NU_COMP_BANC
            .HeaderText = "Nº Comprob"
            .Name = ""
            .DataPropertyName = "NU_COMP_BANC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_OPER As New DataGridViewTextBoxColumn
        With FE_OPER
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_OPER"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_DETA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TI_SITU As New DataGridViewTextBoxColumn
        With TI_SITU
            .HeaderText = "Estado"
            .Name = ""
            .DataPropertyName = "TI_SITU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With


        With DgvHistorico
            .Columns.AddRange(CO_EMPR, CO_BANC, AA_BNCO, MM_BNCO, TI_MOVI_BANC, NU_COMP_BANC, NU_SECU, FE_OPER, IM_DETA, TI_SITU)
        End With
    End Sub

    Sub FormatoCreditoH()
        With DgvHistorico
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_UNID_CONC As New DataGridViewTextBoxColumn
        With CO_UNID_CONC
            .HeaderText = "Unidad"
            .Name = ""
            .DataPropertyName = "CO_UNID_CONC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_AMAR As New DataGridViewTextBoxColumn
        With NU_AMAR
            .HeaderText = "Nº Amarre"
            .Name = ""
            .DataPropertyName = "NU_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_AMAR As New DataGridViewTextBoxColumn
        With FE_AMAR
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_PAGA As New DataGridViewTextBoxColumn
        With IM_PAGA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_COBR_DEST"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TI_SITU As New DataGridViewTextBoxColumn
        With TI_SITU
            .HeaderText = "Estado"
            .Name = ""
            .DataPropertyName = "TI_SITU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DgvHistorico
            .Columns.AddRange(CO_EMPR, CO_UNID_CONC, NU_AMAR, FE_AMAR, NU_SECU, IM_PAGA, TI_SITU)
        End With
    End Sub

    Sub FormatoCajaH()
        With DgvHistorico
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_CAJA As New DataGridViewTextBoxColumn
        With CO_CAJA
            .HeaderText = "Caja"
            .Name = ""
            .DataPropertyName = "CO_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim AA_CAJA As New DataGridViewTextBoxColumn
        With AA_CAJA
            .HeaderText = "Año"
            .Name = ""
            .DataPropertyName = "AA_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim MM_CAJA As New DataGridViewTextBoxColumn
        With MM_CAJA
            .HeaderText = "Mes"
            .Name = ""
            .DataPropertyName = "MM_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim TI_MOVI As New DataGridViewTextBoxColumn
        With TI_MOVI
            .HeaderText = "Mov."
            .Name = ""
            .DataPropertyName = "TI_MOVI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_COMP_CAJA As New DataGridViewTextBoxColumn
        With NU_COMP_CAJA
            .HeaderText = "Nº Comprob"
            .Name = ""
            .DataPropertyName = "NU_COMP_CAJA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_OPER As New DataGridViewTextBoxColumn
        With FE_OPER
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_OPER"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_DETA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TI_SITU As New DataGridViewTextBoxColumn
        With TI_SITU
            .HeaderText = "Estado"
            .Name = ""
            .DataPropertyName = "TI_SITU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DgvHistorico
            .Columns.AddRange(CO_EMPR, CO_CAJA, AA_CAJA, MM_CAJA, TI_MOVI, NU_COMP_CAJA, NU_SECU, FE_OPER, IM_DETA, TI_SITU)
        End With
    End Sub

    Sub FormatoAnticipoH()
        With DgvHistorico
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_UNID_CONC As New DataGridViewTextBoxColumn
        With CO_UNID_CONC
            .HeaderText = "Unidad"
            .Name = ""
            .DataPropertyName = "CO_UNID_CONC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_AMAR As New DataGridViewTextBoxColumn
        With NU_AMAR
            .HeaderText = "Nº Amarre"
            .Name = ""
            .DataPropertyName = "NU_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_AMAR As New DataGridViewTextBoxColumn
        With FE_AMAR
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_AMAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU As New DataGridViewTextBoxColumn
        With NU_SECU
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_DETA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TI_SITU As New DataGridViewTextBoxColumn
        With TI_SITU
            .HeaderText = "Estado"
            .Name = ""
            .DataPropertyName = "TI_SITU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DgvHistorico
            .Columns.AddRange(CO_EMPR, CO_UNID_CONC, NU_AMAR, FE_AMAR, NU_SECU, IM_DETA, TI_SITU)
        End With
    End Sub

    Sub FormatoCanjeH()
        With DgvHistorico
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim CO_EMPR As New DataGridViewTextBoxColumn
        With CO_EMPR
            .HeaderText = "Empresa"
            .Name = ""
            .DataPropertyName = "co_empr"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CO_UNID_CONC As New DataGridViewTextBoxColumn
        With CO_UNID_CONC
            .HeaderText = "Unidad"
            .Name = ""
            .DataPropertyName = "CO_UNID_CONC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_CANJ As New DataGridViewTextBoxColumn
        With NU_CANJ
            .HeaderText = "Nº Canje"
            .Name = ""
            .DataPropertyName = "NU_CANJ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FE_CANJ As New DataGridViewTextBoxColumn
        With FE_CANJ
            .HeaderText = "Fecha"
            .Name = ""
            .DataPropertyName = "FE_CANJ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NU_SECU_CANJ As New DataGridViewTextBoxColumn
        With NU_SECU_CANJ
            .HeaderText = "Sec."
            .Name = ""
            .DataPropertyName = "NU_SECU_CANJ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IM_PAGA As New DataGridViewTextBoxColumn
        With IM_PAGA
            .HeaderText = "Monto"
            .Name = ""
            .DataPropertyName = "IM_PAGA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TI_SITU As New DataGridViewTextBoxColumn
        With TI_SITU
            .HeaderText = "Estado"
            .Name = ""
            .DataPropertyName = "TI_SITU"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DgvHistorico
            .Columns.AddRange(CO_EMPR, CO_UNID_CONC, NU_CANJ, FE_CANJ, NU_SECU_CANJ, IM_PAGA, TI_SITU)
        End With
    End Sub

    Sub Formato()
        With dgvCobranza
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim a As New DataGridViewTextBoxColumn
        With a
            .HeaderText = "Empresa"
            .Name = "a"
            .DataPropertyName = "a"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim b As New DataGridViewTextBoxColumn
        With b
            .HeaderText = "Descripción"
            .Name = "b"
            .DataPropertyName = "b"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim c As New DataGridViewTextBoxColumn
        With c
            .HeaderText = "Nº Comprob"
            .Name = "c"
            .DataPropertyName = "c"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim d As New DataGridViewTextBoxColumn
        With d
            .HeaderText = "Fecha"
            .Name = "d"
            .DataPropertyName = "d"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim e As New DataGridViewTextBoxColumn
        With e
            .HeaderText = "Monto"
            .Name = "e"
            .DataPropertyName = "e"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim cc As New DataGridViewTextBoxColumn
        With cc
            .HeaderText = "cc"
            .Name = "cc"
            .DataPropertyName = "cc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        Dim dd As New DataGridViewTextBoxColumn
        With dd
            .HeaderText = "dd"
            .Name = "dd"
            .DataPropertyName = "dd"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        Dim ee As New DataGridViewTextBoxColumn
        With ee
            .HeaderText = "ee"
            .Name = "ee"
            .DataPropertyName = "ee"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        Dim ff As New DataGridViewTextBoxColumn
        With ff
            .HeaderText = "ff"
            .Name = "ff"
            .DataPropertyName = "ff"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        Dim gg As New DataGridViewTextBoxColumn
        With gg
            .HeaderText = "gg"
            .Name = "gg"
            .DataPropertyName = "gg"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        With dgvCobranza
            .Columns.AddRange(a, b, c, d, e, cc, dd, ee, ff, gg)
        End With
    End Sub

    Sub FormatoH()
        With DgvHistorico
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With

        Dim a As New DataGridViewTextBoxColumn
        With a
            .HeaderText = "Empresa"
            .Name = "a"
            .DataPropertyName = "a"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim b As New DataGridViewTextBoxColumn
        With b
            .HeaderText = "Descripción"
            .Name = "b"
            .DataPropertyName = "b"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim c As New DataGridViewTextBoxColumn
        With c
            .HeaderText = "Nº Comprob"
            .Name = "c"
            .DataPropertyName = "c"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim d As New DataGridViewTextBoxColumn
        With d
            .HeaderText = "Fecha"
            .Name = "d"
            .DataPropertyName = "d"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim e As New DataGridViewTextBoxColumn
        With e
            .HeaderText = "Monto"
            .Name = "e"
            .DataPropertyName = "e"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With DgvHistorico
            .Columns.AddRange(a, b, c, d, e)
        End With
    End Sub

End Class