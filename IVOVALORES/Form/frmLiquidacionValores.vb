Imports INTEGRACION_LN
Public Class frmLiquidacionValores

#Region "Precierre"
#Region "Grid"
    Sub FormateardgvMovimiento()
        With dgvMovimiento
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha/Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_soles As New DataGridViewTextBoxColumn
            With col_soles
                .Name = "soles" : .DataPropertyName = "soles"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Retiro Soles" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_dolar As New DataGridViewTextBoxColumn
            With col_dolar
                .Name = "dolar" : .DataPropertyName = "dolar"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Retiro Dólar" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_tc As New DataGridViewTextBoxColumn
            With col_tc
                .Name = "tipo_cambio" : .DataPropertyName = "tipo_cambio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "T.C." : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_saldo As New DataGridViewTextBoxColumn
            With col_saldo
                .Name = "saldo" : .DataPropertyName = "saldo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Saldo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_id, col_fecha, col_agencia, col_usuario, col_monto, col_soles, col_dolar, col_tc, col_total, col_saldo)
        End With
    End Sub
    Sub FormateardgvRetiro()
        With dgvRetiro
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cambio As New DataGridViewTextBoxColumn
            With col_cambio
                .Name = "cambio" : .DataPropertyName = "cambio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Cambio" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With

            .Columns.AddRange(col_id, col_codigo, col_moneda, col_monto, col_cambio, col_total, col_estado, col_idestado)
        End With
    End Sub
    'Sub FormateardgvBillete()
    '    With dgvBillete
    '        'utilitario.FormatDataGridView(dgv1)
    '        .Columns.Clear()
    '        '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
    '        '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.False
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        '.VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .ScrollBars = ScrollBars.Both
    '        .ReadOnly = True
    '        '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
    '        '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '        '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
    '        '.DefaultCellStyle.SelectionForeColor = Color.Blacks
    '        '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

    '        Dim x As Integer = 0
    '        Dim col_id As New DataGridViewTextBoxColumn
    '        With col_id
    '            .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
    '        End With

    '        x += +1
    '        Dim col_tipo As New DataGridViewTextBoxColumn
    '        With col_tipo
    '            .Name = "tipo" : .DataPropertyName = "tipo"
    '            .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
    '            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        End With

    '        x += +1
    '        Dim col_moneda As New DataGridViewTextBoxColumn
    '        With col_moneda
    '            .Name = "moneda" : .DataPropertyName = "moneda"
    '            .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
    '            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        End With

    '        x += +1
    '        Dim col_valor As New DataGridViewTextBoxColumn
    '        With col_valor
    '            .Name = "valor" : .DataPropertyName = "valor"
    '            .DisplayIndex = x : .Visible = True : .HeaderText = "Valor" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
    '        End With

    '        x += +1
    '        Dim col_cantidad As New DataGridViewTextBoxColumn
    '        With col_cantidad
    '            .Name = "cantidad" : .DataPropertyName = "cantidad"
    '            .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
    '        End With

    '        .Columns.AddRange(col_id, col_tipo, col_moneda, col_valor, col_cantidad)
    '    End With
    'End Sub
    Sub FormateardgvComprobante()
        With dgvComprobante
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_unidad As New DataGridViewTextBoxColumn
            With col_unidad
                .Name = "unidad" : .DataPropertyName = "unidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Unidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_id, col_unidad, col_comprobante, col_monto)
        End With
    End Sub
    Sub FormateardgvComprobanteCierre()
        With dgvComprobanteCierre
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            Dim col_id_unidad As New DataGridViewTextBoxColumn
            With col_id_unidad
                .Name = "id_unidad" : .DataPropertyName = "id_unidad" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_unidad"
            End With

            x += +1
            Dim col_unidad As New DataGridViewTextBoxColumn
            With col_unidad
                .Name = "unidad" : .DataPropertyName = "unidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Unidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_efectivo As New DataGridViewTextBoxColumn
            With col_efectivo
                .Name = "efectivo" : .DataPropertyName = "efectivo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_usuario As New DataGridViewTextBoxColumn
            With col_id_usuario
                .Name = "id_usuario" : .DataPropertyName = "id_usuario"
                .DisplayIndex = x : .HeaderText = "id_usuario" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id_unidad, col_unidad, col_tipo, col_comprobante, col_total, col_efectivo, col_id_usuario, col_id, col_usuario)
        End With
    End Sub
#End Region
#Region "Variable"
    Dim dblTipoCambio As Double
    Dim dtSoles As DataTable, dtDolares As DataTable
    Dim dblSaldo As Double = 0
#End Region
#Region "Procedimiento"
    Sub ListarAgencia()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboAgencia
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarAgencia()
            .SelectedValue = dtoUSUARIOS.iIDAGENCIAS
        End With
    End Sub
    Function TotalGrid(ByVal dgv As DataGridView, ByVal columna As String, Optional ByVal fila As Integer = -1) As Double
        Dim dblMonto As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            If fila = -1 Then
                dblMonto += row.Cells(columna).Value
            Else
                If row.Index <> fila Then
                    dblMonto += row.Cells(columna).Value
                End If
            End If
        Next
        Return dblMonto
    End Function
    Function MontoCaja(ByVal moneda As Integer) As Double
        Dim dblSoles As Double, dblDolares As Double, dblTC As Double, dblRetiroSoles As Double, dblRetiroDolares As Double

        dblSoles = CDbl(IIf(Val(Me.lblTotalEfectivoCierre.Text) = 0, 0, Me.lblTotalEfectivoCierre.Text)) '+ dblSaldo
        dblDolares = CDbl(IIf(Val(Me.lblTotalEfectivoCierre.Text) = 0, 0, Me.lblTotalEfectivoCierre.Text))
        dblTC = CDbl(Me.lblTipoCambioCierre.Text)
        dblRetiroSoles = CDbl(IIf(Val(Me.txtRetiroSolesCierre.Text) = 0, 0, Me.txtRetiroSolesCierre.Text))
        dblRetiroDolares = CDbl(IIf(Val(Me.txtRetiroDolarCierre.Text) = 0, 0, Me.txtRetiroDolarCierre.Text))
        If moneda = 1 Then 'soles
            Return dblSoles - (dblRetiroDolares * dblTC)
        Else
            Return (dblSoles - dblRetiroSoles) / dblTC
        End If
    End Function
    Sub MostrarComprobante(ByVal dt As DataTable, ByVal unidad As Integer)
        With Me.dgvComprobanteCierre
            Dim blnProcesa As Boolean
            Dim intFila As Integer = .Rows.Count - 1
            Dim dblTotal As Double
            Dim obj As New Cls_LiquidacionValor_LN
            For Each row As DataRow In dt.Rows
                blnProcesa = True
                dblTotal = 0
                If unidad = 2 Then
                    Dim intExiste As Integer = obj.ExisteComprobante(row.Item("id"), 2, row.Item("opcion"))
                    If intExiste = 1 Then
                        blnProcesa = False
                    Else
                        If row.Item("total") = 0 Then
                            dblTotal = obj.ComprobanteOriginal(row.Item("id"), 2)
                        End If
                    End If
                End If
                If blnProcesa Then
                    intFila += 1
                    .Rows.Add()
                    .Rows(intFila).Cells("id_unidad").Value = row.Item("id_unidad")
                    .Rows(intFila).Cells("unidad").Value = row.Item("unidad")
                    .Rows(intFila).Cells("usuario").Value = dtoUSUARIOS.NameLogin
                    .Rows(intFila).Cells("tipo").Value = row.Item("tipo")
                    .Rows(intFila).Cells("comprobante").Value = row.Item("comprobante")
                    If dblTotal = 0 Then
                        .Rows(intFila).Cells("total").Value = row.Item("total")
                        .Rows(intFila).Cells("efectivo").Value = row.Item("efectivo")
                    Else
                        .Rows(intFila).Cells("total").Value = dblTotal
                        .Rows(intFila).Cells("efectivo").Value = dblTotal
                    End If
                    .Rows(intFila).Cells("id").Value = row.Item("id")
                    .Rows(intFila).Cells("id_usuario").Value = dtoUSUARIOS.IdLogin
                End If
            Next
        End With
    End Sub
    Sub ActualizarComprobante()
        Try
            'Me.lblFechaCierre.Text = "30/07/2017"
            Cursor = Cursors.AppStarting
            Me.dgvComprobanteCierre.Rows.Clear()
            Dim dblTotalEfectivoCierre As Double
            Dim intUsuario As Integer, strUsuario As String
            Dim obj As New Cls_LiquidacionValor_LN

            If intPortavalor = 1 Then
                intUsuario = dtoUSUARIOS.IdLogin
                strUsuario = dtoUSUARIOS.LoginPasaje
            Else
                intUsuario = 0
                strUsuario = "X"
            End If
            Dim ds As DataSet = obj.ListarComprobante(dtoUSUARIOS.iIDAGENCIAS, Me.dtpFechaCierre.Value.ToShortDateString, intUsuario, dtoUSUARIOS.Unidad)
            If ds.Tables(0).Rows.Count > 0 Then
                MostrarComprobante(ds.Tables(0), 1)
            End If
            'Dim objVYR As New dtoValor
            'Dim dt As DataTable = objVYR.LeerVenta(dtoUSUARIOS.codAgenciaSisvyr, Me.dtpFechaCierre.Value.ToShortDateString, strUsuario)
            'If dt.Rows.Count > 0 Then
            '    MostrarComprobante(dt, 2)
            'End If

            dblSaldo = ds.Tables(1).Rows(0).Item("saldo")
            dblTotalEfectivoCierre = TotalGrid(Me.dgvComprobanteCierre, "efectivo") + dblSaldo
            Me.lblTotalEfectivoCierre.Text = Format(dblTotalEfectivoCierre, "###,###,###0.00")
            If intPortavalor = 1 Then
                Me.btnRetiroSolesCierre.Enabled = dblTotalEfectivoCierre > 0
                Me.btnRetiroDolarCierre.Enabled = dblTotalEfectivoCierre > 0 And dblTipoCambio > 0
            Else
                Me.txtRetiroSolesCierre.Text = dblTotalEfectivoCierre
                Me.txtRetiroSolesCierre_LostFocus(Nothing, Nothing)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub ImprimirTicket(ByVal impresora As Integer, ByVal codigo As String, ByVal monto As Double, ByVal moneda As Integer, Optional ByVal opcion As Integer = 0)
        Dim strCadena As String = "", strUsuario As String, strMonto As String
        Dim prn As New PrinterTxt.PrintTxt
        prn.Nombre_impresora = NOMBRE_IMPRESORA
        Dim EXISTE As Boolean = prn.SetearImpresora()

        If opcion = 0 Then
            strCadena = CDate(FechaServidor()).ToShortDateString
            strUsuario = dtoUSUARIOS.NameLogin.Trim
        Else
            strCadena = CDate(Me.dgvMovimiento.CurrentRow.Cells("fecha").Value).ToShortDateString
            strUsuario = Me.dgvMovimiento.CurrentRow.Cells("usuario").Value
        End If
        If impresora = 1 Or impresora = 4 Then
            prn.EscribeLinea("^XA")
            prn.EscribeLinea("^PW400")

            If dtoUSUARIOS.NameLogin.Trim.Length <= 27 Then
                prn.EscribeLinea("^FT14,39^A0N,28,28^FH\^FD" & strUsuario & "^FS")
            Else
                prn.EscribeLinea("^FT14,39^A0N,28,28^FH\^FD" & strUsuario.Substring(0, 27) & "^FS")
            End If
            prn.EscribeLinea("^FT14,79^A0N,28,28^FH\^FD " & fnGetAGENCIA(dtoUSUARIOS.iIDAGENCIAS) & "^FS")
           
            prn.EscribeLinea("^FT14,119^A0N,28,28^FH\^FD " & strCadena & "^FS")

            strMonto = IIf(moneda = 1, "S/.", "US$") & " " & Format(monto, "###,###,###0.00")
            prn.EscribeLinea("^FT14,159^A0N,28,28^FH\^FD " & strMonto & "^FS")

            prn.EscribeLinea("^BY2,2,46^FT185,154^BEN,,Y,N^FD" & codigo & "^FS")

            prn.EscribeLinea("^PQ1,0,1,Y")
            prn.EscribeLinea("^XZ")
            prn.FinDoc()
        Else
            prn.EscribeLinea("N")
            prn.EscribeLinea("N")

            If dtoUSUARIOS.NameLogin.Trim.Length <= 27 Then
                prn.EscribeLinea("A24,3,0,3,1,1,N,""" & strUsuario & """")
            Else
                prn.EscribeLinea("A24,3,0,3,1,1,N,""" & strUsuario.Substring(0, 27) & """")
            End If
            prn.EscribeLinea("A24,33,0,3,1,1,N,""" & fnGetAGENCIA(dtoUSUARIOS.iIDAGENCIAS) & """")

            'strCadena = CDate(FechaServidor()).ToShortDateString '& "   " & IIf(dtoUSUARIOS.Unidad = 1, "CARGA", "PASAJES")
            prn.EscribeLinea("A24,63,0,3,1,1,N,""" & strCadena & """")

            strMonto = IIf(moneda = 1, "S/.", "US$") & " " & Format(monto, "###,###,###0.00")
            prn.EscribeLinea("A174,63,0,3,1,1,N,""" & strMonto & """")

            'codigo = "0010209610771"
            prn.EscribeLinea("B140,92,0,E30,2,2,59,B,""" & codigo & """")
            'prn.EscribeLinea("B162,69,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """") 'b148

            prn.EscribeLinea("P1")
            prn.EscribeLinea("N")
            prn.FinDoc()
        End If
    End Sub
    Sub LimpiarCerrar()
        Me.dgvComprobanteCierre.Rows.Clear()
        Me.txtRetiroSolesCierre.Text = "0.00"
        Me.txtRetiroDolarCierre.Text = "0.00"
        btnRetiroSolesCierre.Enabled = False
        btnRetiroDolarCierre.Enabled = False
        Me.lblTotalEfectivoCierre.Text = "0.00"
        dtSoles = Nothing
        dtDolares = Nothing
        dblSaldo = 0
        Me.tsbAnular.Enabled = False
        Me.tsbImprimir.Enabled = False
    End Sub
    Sub Cerrar(ByVal mensaje As String)
        Try
            Cursor = Cursors.WaitCursor
            Dim strFecha As String, dblTotalEfectivo As Double, dblTC As Double, dblRetiroSoles As Double, dblRetiroDolar As Double
            Dim obj As New Cls_LiquidacionValor_LN
            Dim intComprobante As Integer, intId As Integer, intIdSoles As Integer, intIdDolar As Integer
            Dim strComprobante As String, strTipo As String, dblMonto As Double, intUnidad As Integer
            Dim strCodigoSoles As String, strCodigoDolar As String

            If dtoUSUARIOS.Portavalor = 1 Then
                strFecha = Me.dtpFechaCierre.Value.ToShortDateString 'CDate(FechaServidor()).ToShortDateString
            Else
                strFecha = Me.dtpFechaCierre.Value.ToShortDateString
            End If
            dblTotalEfectivo = CType(Me.lblTotalEfectivoCierre.Text, Double)
            dblTC = CType(Me.lblTipoCambioCierre.Text, Double)
            dblRetiroSoles = IIf(Val(Me.txtRetiroSolesCierre.Text) = 0, 0, CType(Me.txtRetiroSolesCierre.Text, Double))
            dblRetiroDolar = IIf(Val(Me.txtRetiroDolarCierre.Text) = 0, 0, CType(Me.txtRetiroDolarCierre.Text, Double))

            Dim dt As DataTable = obj.CerrarCaja(strFecha, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, dblTotalEfectivo, dblTC, _
                           dblRetiroSoles, dblRetiroDolar, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
            If dt.Rows.Count > 0 Then
                intId = CType(dt.Rows(0).Item("id").ToString, Integer)
                For Each row As DataGridViewRow In Me.dgvComprobanteCierre.Rows
                    intComprobante = row.Cells("id").Value
                    strComprobante = row.Cells("comprobante").Value
                    strTipo = row.Cells("tipo").Value
                    intUnidad = IIf(row.Cells("unidad").Value = "CARGA", 1, 2)
                    dblMonto = row.Cells("efectivo").Value
                    obj.GrabarComprobante(intId, intComprobante, strComprobante, strTipo, dblMonto, intUnidad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, 0)
                Next

                If intPortavalor = 2 Then
                    If dblRetiroSoles <> 0 Then
                        GrabarRemesa(1, dblRetiroSoles, dt)
                    End If
                Else
                    'Imprimir ticket con codigo de barras
                    Dim xImpresora As Integer
                    xImpresora = fnSeleccionImpresion()
                    If dblRetiroSoles > 0 Then
                        strCodigoSoles = dt.Rows(0).Item("codigo_soles")
                        ImprimirTicket(xImpresora, strCodigoSoles, dblRetiroSoles, 1)
                    End If
                    If dblRetiroDolar > 0 Then
                        strCodigoDolar = dt.Rows(0).Item("codigo_dolar")
                        ImprimirTicket(xImpresora, strCodigoDolar, dblRetiroDolar, 2)
                    End If
                End If

                Cursor = Cursors.Default
                MessageBox.Show("Se realizó el " & mensaje, mensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCerrar()
                Me.tabCabecera.SelectedTab = Me.tabCabecera.TabPages("tabConsulta")
                Me.btnConsultarPrecierre_Click(Nothing, Nothing)
                Me.btnConsultarPrecierre.Focus()
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Pre-Cierre", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Sub AnularRetiro()
        Try
            Dim intID As Integer = Me.dgvRetiro.CurrentRow.Cells("id").Value
            Dim obj As New Cls_LiquidacionValor_LN
            obj.AnularRetiro(intID, Me.dgvMovimiento.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub AnularCierre()
        Try
            Dim intID As Integer = Me.dgvMovimiento.CurrentRow.Cells("id").Value
            Dim obj As New Cls_LiquidacionValor_LN
            obj.AnularCierre(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub ListarCierre()
        Try
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable = obj.ListarCierre(Me.dtpFechaInicio.Value.ToShortDateString, Me.dtpFechaFin.Value.ToShortDateString, Me.cboAgencia.SelectedValue, Me.cboUsuario.SelectedValue)
            Me.dgvMovimiento.DataSource = dt
            TotalPrecierre()
            If Me.dgvMovimiento.Rows.Count = 0 Then
                Me.tsbAnular.Enabled = False
                Me.tsbImprimir.Enabled = False
                Me.dgvRetiro.DataSource = Nothing
                'Me.dgvBillete.DataSource = Nothing
                Me.dgvComprobante.DataSource = Nothing
            Else
                Me.tsbImprimir.Enabled = Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabRetiro")
                If Me.tsbAnular.Enabled Then
                    Me.tsbAnular.Enabled = Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabCierre")
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub LimpiarPrecierre()
        Me.dgvMovimiento.DataSource = Nothing
        Me.dgvRetiro.DataSource = Nothing
        'Me.dgvBillete.DataSource = Nothing
        Me.dgvComprobante.DataSource = Nothing
        'Me.cboUsuario.DataSource = Nothing
        Me.lblMonto.Text = "0.00"
        Me.lblRetiroSoles.Text = "0.00"
        Me.lblRetiroDolar.Text = "0.00"
        Me.lblRetiroTotal.Text = "0.00"
        Me.lblSaldo.Text = "0.00"

        Me.tsbAnular.Enabled = False
    End Sub
    Sub TotalPrecierre()
        Dim dt As DataTable
        Dim dblMonto As Double, dblRetiroSoles As Double, dblRetiroDolar As Double, dblRetiroTotal As Double, dblSaldo As Double, dblTC As Double
        Dim intMoneda As Integer

        If Me.dgvMovimiento.Rows.Count > 0 Then
            dt = Me.dgvMovimiento.DataSource
            dblMonto = IIf(IsDBNull(dt.Compute("sum(monto)", "")), 0, dt.Compute("sum(monto)", ""))
            dblRetiroSoles = IIf(IsDBNull(dt.Compute("sum(soles)", "")), 0, dt.Compute("sum(soles)", ""))
            dblRetiroDolar = IIf(IsDBNull(dt.Compute("sum(dolar)", "")), 0, dt.Compute("sum(dolar)", ""))
            dblRetiroTotal = IIf(IsDBNull(dt.Compute("sum(total)", "")), 0, dt.Compute("sum(total)", ""))
            dblSaldo = dblMonto - dblRetiroTotal
        End If
        Me.lblMonto.Text = Format(dblMonto, "###,###,###0.00")
        Me.lblRetiroSoles.Text = Format(dblRetiroSoles, "###,###,###0.00")
        Me.lblRetiroDolar.Text = Format(dblRetiroDolar, "###,###,###0.00")
        Me.lblRetiroTotal.Text = Format(dblRetiroTotal, "###,###,###0.00")
        Me.lblSaldo.Text = Format(dblSaldo, "###,###,###0.00")
    End Sub
    Function Saldo(ByVal fecha As String, ByVal agencia As Integer, ByVal usuario As Integer) As Double
        Dim obj As New Cls_LiquidacionValor_LN
        Dim dblSaldo As Double = obj.ObtieneSaldo(fecha, agencia, usuario)
        Return dblSaldo
    End Function
#End Region
#Region "Control"
    Private Sub btnActualizarCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarCierre.Click
        Try
            Cursor = Cursors.WaitCursor
            ActualizarComprobante()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRetiroSolesCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetiroSolesCierre.Click
        Dim frm As New frmBillete
        frm.Moneda = 1
        frm.MontoCaja = MontoCaja(1) 'Me.lblTotalEfectivoCierre.Text
        frm.Text = "Billetes en Soles"
        frm.dt = dtSoles
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtRetiroSolesCierre.Text = frm.txtBillete.Text
            Me.dgvComprobanteCierre.DataSource = Nothing
            dtSoles = frm.dgvBillete.DataSource
        Else
            dtSoles = frm.dtBillete
        End If
    End Sub
    Private Sub btnRetiroDolarCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetiroDolarCierre.Click
        Dim frm As New frmBillete
        frm.Moneda = 2
        frm.MontoCaja = MontoCaja(2) 'CDbl(Me.lblTotalEfectivoCierre.Text) / CDbl(Me.lblTipoCambioCierre.Text)
        frm.TipoCambio = CDbl(Me.lblTipoCambioCierre.Text)
        frm.Text = "Billetes en Dólares - Tipo de Cambio : " & Me.lblTipoCambioCierre.Text
        frm.dt = dtDolares
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtRetiroDolarCierre.Text = frm.txtBillete.Text
            dtDolares = frm.dgvBillete.DataSource
        End If
    End Sub
    Private Sub ListarUsuario()
        Try
            LimpiarPrecierre()
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable = obj.ListarUsuario(Me.dtpFechaInicio.Value.ToShortDateString, Me.dtpFechaFin.Value.ToShortDateString, _
                                                    Me.cboAgencia.SelectedValue, intNivel, IIf(intNivel = 1, dtoUSUARIOS.IdLogin, Me.cboUsuario.SelectedValue))
            With Me.cboUsuario
                .DisplayMember = "descripcion"
                .ValueMember = "id"
                .DataSource = dt
                .SelectedValue = 0
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Listar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub btnConsultarPrecierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarPrecierre.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarCierre()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub dgvMovimiento_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMovimiento.RowEnter
        Try
            Dim intID As Integer
            Dim obj As New Cls_LiquidacionValor_LN

            intID = Me.dgvMovimiento.Rows(e.RowIndex).Cells("id").Value
            Dim dt As DataTable = obj.ListarRetiro(intID)
            Me.dgvRetiro.DataSource = dt

            dt = obj.ListarComprobante(intID)
            Me.dgvComprobante.DataSource = dt

            'Activa anular si algun retiros del pre-cierre tienen el estado en bolsa
            Dim blnAnular As Boolean = True
            If Me.dgvRetiro.Rows.Count > 0 Then
                For Each row As DataGridViewRow In Me.dgvRetiro.Rows
                    If row.Cells("idestado").Value <> 1 Then
                        blnAnular = False
                    End If
                Next
            Else
                blnAnular = False
            End If
            Me.tsbAnular.Enabled = blnAnular

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    'Private Sub dgvRetiro_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiro.RowEnter
    '    Try
    '        Dim intID As Integer
    '        Dim obj As New Cls_LiquidacionValor_LN

    '        intID = Me.dgvRetiro.Rows(e.RowIndex).Cells("id").Value
    '        Dim dt As DataTable = obj.ListarBilletes(intID)
    '        Me.dgvBillete.DataSource = dt

    '        'Activa anular si retiro tiene el estado en bolsa
    '        Dim blnAnular As Boolean = Me.dgvRetiro.Rows(e.RowIndex).Cells("idestado").Value = 1
    '        Me.tsbAnular.Enabled = blnAnular

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try
    'End Sub
    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicio.ValueChanged, dtpFechaFin.ValueChanged
        LimpiarPrecierre()
        If intNivel = 2 Or intNivel = 3 Then
            Try
                Dim obj As New Cls_LiquidacionValor_LN
                Dim dt As DataTable = obj.ListarUsuario(Me.dtpFechaInicio.Value.ToShortDateString, Me.dtpFechaFin.Value.ToShortDateString, Me.cboAgencia.SelectedValue, intNivel, dtoUSUARIOS.IdLogin)
                With Me.cboUsuario
                    .DisplayMember = "descripcion"
                    .ValueMember = "id"
                    .DataSource = dt
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Listar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
    Private Sub cboUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuario.SelectedIndexChanged
        LimpiarPrecierre()
    End Sub
    Private Sub cboAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgencia.SelectedIndexChanged
        LimpiarPrecierre()
        ListarUsuario()
    End Sub
    Private Sub txtRetiroSolesCierre_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRetiroSolesCierre.Enter
        'Me.txtRetiroSolesCierre.Text = ""
        Me.txtRetiroSolesCierre.SelectAll()
    End Sub

    Private Sub txtRetiroSolesCierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetiroSolesCierre.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtRetiroDolarCierre.Focus()
        Else
            If Not ValidarNumeroReal(e.KeyChar, Me.txtRetiroSolesCierre.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRetiroSolesCierre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRetiroSolesCierre.LostFocus
        If Val(Me.txtRetiroSolesCierre.Text) = 0 Then
            Me.txtRetiroSolesCierre.Text = "0.00"
        Else
            Me.txtRetiroSolesCierre.Text = Format(CType(Me.txtRetiroSolesCierre.Text, Double), "0.00")
        End If
    End Sub

    Private Sub txtRetiroDolarCierre_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRetiroDolarCierre.Enter
        Me.txtRetiroDolarCierre.SelectAll()
    End Sub

    Private Sub txtRetiroDolarCierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetiroDolarCierre.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtRetiroSolesCierre.Focus()
        Else
            If Not ValidarNumeroReal(e.KeyChar, Me.txtRetiroDolarCierre.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRetiroDolarCierre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRetiroDolarCierre.LostFocus
        If Val(Me.txtRetiroDolarCierre.Text) = 0 Then
            Me.txtRetiroDolarCierre.Text = "0.00"
        Else
            Me.txtRetiroDolarCierre.Text = Format(CType(Me.txtRetiroDolarCierre.Text, Double), "0.00")
        End If
    End Sub
#End Region
#Region "Tab"
    Private Sub tabCabecera_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCabecera.SelectedIndexChanged
        Me.tsbImprimir.Enabled = False
        If tabCabecera.SelectedTab Is tabCabecera.TabPages("tabConsulta") Then
            Me.tsbGrabar.Enabled = False
            If Me.dgvMovimiento.Rows.Count = 0 Then
                Me.tsbAnular.Enabled = False
            Else
                tabDetalle_SelectedIndexChanged(Nothing, Nothing)
            End If
        Else
            Me.tsbGrabar.Enabled = intNivel = 1 Or intNivel = 5 Or (intNivel = 2 And intPortavalor = 2)
            Me.tsbAnular.Enabled = False
            LimpiarCerrar()
            Dim strFecha As String = FechaServidor()
            dblTipoCambio = Cls_LiquidacionValor_LN.ObtieneTipoCambio(CDate(strFecha).ToShortDateString)

            Me.dtpFechaCierre.Value = CDate(strFecha).ToShortDateString
            Me.lblHoraCierre.Text = CDate(strFecha).ToShortTimeString
            Me.lblUsuarioCierre.Text = dtoUSUARIOS.NameLogin

            Me.lblTipoCambioCierre.Text = Format(dblTipoCambio, "0.00")
            dblSaldo = Saldo(Me.dtpFechaCierre.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin)
            Me.lblTotalEfectivoCierre.Text = Format(dblSaldo, "###,###,###0.00")
            Me.btnRetiroSolesCierre.Enabled = dblSaldo > 0
            Me.btnRetiroDolarCierre.Enabled = dblSaldo > 0 And dblTipoCambio > 0

            If intPortavalor = 2 Then
                'Desactiva grabar y cerrar si existe remesa para fecha y oficina
                Dim blnActivo As Boolean = True
                Dim obj As New Cls_LiquidacionValor_LN
                blnActivo = obj.ExisteRemesa(Me.dtpFechaCierre.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, 1)
                Me.tsbGrabar.Enabled = Not blnActivo
                Me.btnActualizarCierre.Enabled = Not blnActivo
            End If
        End If
    End Sub
    Private Sub tabDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabDetalle.SelectedIndexChanged
        If Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabCierre") Then
            Me.tsbImprimir.Enabled = False
            If Me.dgvMovimiento.Rows.Count = 0 Then
                Me.tsbAnular.Enabled = False
            Else
                'Activa anular si algun retiros del pre-cierre tienen el estado en bolsa
                Dim blnAnular As Boolean = True
                If Me.dgvRetiro.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In Me.dgvRetiro.Rows
                        If row.Cells("idestado").Value <> 1 Then
                            blnAnular = False
                        End If
                    Next
                Else
                    blnAnular = False
                End If
                Me.tsbAnular.Enabled = blnAnular
            End If
        ElseIf Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabRetiro") Then 'Reimprime retiro de dinero
            If Me.dgvRetiro.Rows.Count > 0 Then
                Me.tsbImprimir.Enabled = True
                Me.tsbAnular.Enabled = Me.dgvRetiro.CurrentRow.Cells("idestado").Value = 1
            Else
                Me.tsbImprimir.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
        Else
            Me.tsbAnular.Enabled = False
            Me.tsbImprimir.Enabled = False
        End If
    End Sub
#End Region
#End Region

#Region "Generar Remesa"
#Region "Grid"
    Sub FormateardgvListaGenerar()
        With dgvListaGenerar
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = True : .HeaderText = "Número"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Liquidación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With

            x += +1
            Dim col_id_agencia As New DataGridViewTextBoxColumn
            With col_id_agencia
                .Name = "id_agencia" : .DataPropertyName = "id_agencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_agencia"
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_banco As New DataGridViewTextBoxColumn
            With col_banco
                .Name = "banco" : .DataPropertyName = "banco" : .DisplayIndex = x : .Visible = False : .HeaderText = "banco"
            End With

            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente" : .DisplayIndex = x : .Visible = False : .HeaderText = "cuenta_corriente"
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante" : .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idportavalor As New DataGridViewTextBoxColumn
            With col_idportavalor
                .Name = "idportavalor" : .DataPropertyName = "idportavalor" : .DisplayIndex = x : .Visible = False : .HeaderText = "idportavalor"
            End With

            x += +1
            Dim col_dni As New DataGridViewTextBoxColumn
            With col_dni
                .Name = "dni" : .DataPropertyName = "dni"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dni"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_portavalor As New DataGridViewTextBoxColumn
            With col_portavalor
                .Name = "portavalor" : .DataPropertyName = "portavalor"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Portavalor"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = False : .HeaderText = "codigo"
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado_registro As New DataGridViewTextBoxColumn
            With col_id_estado_registro
                .Name = "id_estado_registro" : .DataPropertyName = "id_estado_registro" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado_registro"
            End With

            x += +1
            Dim col_fecha_remesa As New DataGridViewTextBoxColumn
            With col_fecha_remesa
                .Name = "fecha_remesa" : .DataPropertyName = "fecha_remesa"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Remesa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With


            .Columns.AddRange(col_id, col_agencia, col_fecha, col_id_agencia, col_moneda, col_monto, col_banco, col_cuenta_corriente, col_comprobante, _
                              col_idportavalor, col_dni, col_portavalor, col_codigo, col_id_estado, col_estado, col_observacion, col_id_estado_registro, col_fecha_remesa)
        End With
    End Sub
    Sub FormateardgvBolsa()
        With dgvBolsa
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id_preliq" : .DataPropertyName = "id_preliq" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliq"
            End With

            x += +1
            Dim col_id_cab As New DataGridViewTextBoxColumn
            With col_id_cab
                .Name = "id_preliq_det" : .DataPropertyName = "id_preliq_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliq_det"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha/Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_remesa As New DataGridViewTextBoxColumn
            With col_id_remesa
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_det"
            End With

            x += +1
            Dim col_fecha_liquidacion As New DataGridViewTextBoxColumn
            With col_fecha_liquidacion
                .Name = "fecha_liquidacion" : .DataPropertyName = "fecha_liquidacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Liquidación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_id_cab, col_fecha, col_codigo, col_moneda, col_monto, col_usuario, col_id_remesa, col_id_det, col_fecha_liquidacion)
        End With
    End Sub
#End Region
#Region "Variable"
    Dim dtProveedor As DataTable, dtCuentaCorriente As DataTable
    Dim intOperacion As Operacion
    Dim blnInicioRemesa As Boolean, blnDisponible As Boolean
    Dim toolTip As New ToolTip()
#End Region
#Region "Procedimiento"
    Sub ListarBanco()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboBanco
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarBanco()
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarProveedor(ByVal dni As String, ByRef id As Integer, ByRef nombres As String, ByRef codigo As String)
        Dim obj As New Cls_LiquidacionValor_LN
        dtProveedor = obj.ListarProveedor(dni)
        If dtProveedor.Rows.Count > 0 Then
            id = dtProveedor.Rows(0).Item("id").ToString
            nombres = dtProveedor.Rows(0).Item("nombres").ToString
            codigo = dtProveedor.Rows(0).Item("codigo").ToString
        Else
            id = 0
            nombres = ""
            codigo = ""
        End If
    End Sub
    Sub ListarCuentaCorriente(ByVal banco As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboCuentaCorriente
            dtCuentaCorriente = obj.ListarCuentaCorriente(banco)
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dtCuentaCorriente
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarRemesaGenerar()
        Dim strInicio As String = Me.dtpInicio.Value.ToShortDateString
        Dim strFin As String = Me.dtpFin.Value.ToShortDateString
        Dim intAgencia As Integer = Me.cboAgenciaGenerar.SelectedValue

        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarRemesa(strInicio, strFin, intAgencia)
        Me.dgvListaGenerar.DataSource = dt

        If dt.Rows.Count = 0 Then
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        Else
            blnInicioRemesa = False
        End If
        TotalListaRemesa()
    End Sub
    Sub ListarAgenciaGenerar()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboAgenciaGenerar
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarAgencia()
            If intNivel = 3 Or intNivel = 5 Then
                .SelectedValue = 0
            Else
                .SelectedValue = dtoUSUARIOS.iIDAGENCIAS
            End If
        End With
    End Sub
    Sub PrepararBolsa(ByVal codigo As String, ByVal moneda As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim ds As DataSet = obj.RetirarBolsa(codigo, moneda, dtoUSUARIOS.IdLogin, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Dim dtLista As DataTable = ds.Tables(0)
        Dim dtEstado As DataTable = ds.Tables(1)

        Dim intEstado As Integer = dtEstado.Rows(0).Item("idestado")
        If intEstado = -1 Then
            MessageBox.Show("La Bolsa con Código " & codigo & " no existe", "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If intPortavalor = 1 Then
            If intEstado <> 2 Then
                MessageBox.Show("La Bolsa con Código " & codigo & " no está en el Cofre", "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Else
            If intEstado <> 1 Then
                MessageBox.Show("La Bolsa con Código " & codigo & " no está en el Cofre", "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If
        If dtLista.Rows.Count > 0 Then
            If Not (ExisteValorGrid(Me.dgvBolsa, 3, dtLista.Rows(0).Item("codigo"))) Then
                AgregarBolsa(dtLista)
            Else
                MessageBox.Show("La Bolsa con Código " & codigo & " ya se encuentra en la lista", "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.txtCodigo.Focus()
        End If
    End Sub
    Sub AgregarBolsa(ByVal dt As DataTable)
        Dim intFila As Integer
        For Each row As DataRow In dt.Rows
            With Me.dgvBolsa
                .Rows.Add()
                intFila = .Rows.Count - 1
                .Rows(intFila).Cells("id_preliq_det").Value = row.Item("id_preliq_det")
                .Rows(intFila).Cells("id_preliq").Value = row.Item("id_preliq")
                .Rows(intFila).Cells("fecha").Value = row.Item("fecha")
                .Rows(intFila).Cells("codigo").Value = row.Item("codigo")
                .Rows(intFila).Cells("moneda").Value = row.Item("moneda")
                .Rows(intFila).Cells("monto").Value = row.Item("monto")
                .Rows(intFila).Cells("usuario").Value = row.Item("usuario")
                .Rows(intFila).Cells("id").Value = row.Item("id")
                .Rows(intFila).Cells("id_det").Value = row.Item("id_det")
                .Rows(intFila).Cells("fecha_liquidacion").Value = "" & row.Item("fecha_liquidacion")
            End With
        Next
        TotalRemesa()
    End Sub
    Sub TotalRemesa()
        If Me.dgvBolsa.Rows.Count > 0 Then
            Dim intBolsa As Integer = 0, dblSoles As Double = 0, dblDolar As Double = 0
            For Each row As DataGridViewRow In Me.dgvBolsa.Rows
                intBolsa += 1
                If row.Cells("moneda").Value = "SOLES" Then
                    dblSoles = dblSoles + row.Cells("monto").Value
                End If
                If row.Cells("moneda").Value = "DOLAR" Then
                    dblDolar = dblDolar + row.Cells("monto").Value
                End If
            Next
            Me.lblBolsas.Text = intBolsa
            Me.lblSoles.Text = Format(dblSoles, "###,###,###0.00")
            Me.lblDolar.Text = Format(dblDolar, "###,###,###0.00")
        Else
            Me.lblBolsas.Text = "0"
            Me.lblSoles.Text = "0.00"
            Me.lblDolar.Text = "0.00"
        End If
    End Sub
    Sub GrabarRemesa(ByVal moneda As Integer, ByVal monto As Double, ByVal dt As DataTable)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim strFecha As String, intMoneda As Integer, dblMonto As Double, strComprobante As String
        Dim intPortavalor As Integer, strObservacion As String, intBanco As Integer, intCuentaCorriente As Integer
        Dim intID As Integer, intIDAnterior As Integer, intIDDetAnterior As Integer
        Dim strDni As String, strNombres As String, strCodigo As String

        intID = 0 : intIDAnterior = 0
        'strFecha = CDate(FechaServidor()).ToShortDateString
        strFecha = Me.dtpFechaCierre.Value.ToShortDateString
        intMoneda = moneda
        dblMonto = monto
        strComprobante = ""
        intPortavalor = dtoUSUARIOS.IdLogin : strDni = dtoUSUARIOS.DNI : strNombres = dtoUSUARIOS.NameLogin : strCodigo = ""
        strObservacion = "" : intBanco = 0 : intCuentaCorriente = 0

        intID = obj.GrabarRemesa(intID, strFecha, dtoUSUARIOS.iIDAGENCIAS, intMoneda, dblMonto, strComprobante,
                         intPortavalor, strDni, strNombres, strCodigo, _
                         strObservacion, intBanco, intCuentaCorriente, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Dim intIdPreliquidacion As Integer
        With dt
            For Each row As DataRow In dt.Rows
                intIdPreliquidacion = row.Item("soles")
                intIDDetAnterior = 0 'row.Item("id_det")
                obj.GrabarRemesa(intID, intIdPreliquidacion, intIDAnterior, intIDDetAnterior, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
            Next
        End With
    End Sub
    Sub GrabarGenerar()
        Try
            Dim obj As New Cls_LiquidacionValor_LN
            Dim strFecha As String, intMoneda As Integer, dblMonto As Double, strComprobante As String
            Dim intPortavalor As Integer, strObservacion As String, intBanco As Integer, intCuentaCorriente As Integer
            Dim intID As Integer, intIDAnterior As Integer, intIDDetAnterior As Integer
            Dim strDni As String, strNombres As String, strCodigo As String

            intPortavalor = dtoUSUARIOS.Portavalor
            If intPortavalor = 1 Then
                Dim intBolsasCofre As Integer = obj.BolsasenCofre(dtoUSUARIOS.iIDAGENCIAS, dtCuentaCorriente.Rows(Me.cboCuentaCorriente.SelectedIndex).Item("moneda"))
                Dim intBolsasRemesa As Integer = Me.dgvBolsa.Rows.Count
                If intBolsasCofre > intBolsasRemesa Then
                    Dim dlgRespuesta As DialogResult
                    Dim strMensaje As String
                    strMensaje = "El Cofre tiene mas bolsas que las leídas en la Remesa" & Chr(13) & Chr(13)
                    strMensaje = strMensaje & "Nº Bolsas Cofre : " & intBolsasCofre & Chr(13)
                    strMensaje = strMensaje & "Nº Bolsas Remesa : " & intBolsasRemesa & Chr(13) & Chr(13)
                    strMensaje = strMensaje & "¿Desea Continuar?"
                    dlgRespuesta = MessageBox.Show(strMensaje, "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRespuesta = Windows.Forms.DialogResult.No Then
                        Return
                    End If
                End If
            End If

            intID = 0
            intIDAnterior = 0
            If intOperacion = Operacion.Nuevo Then
                intID = 0
                intIDAnterior = 0
            Else
                intID = Me.dgvListaGenerar.CurrentRow.Cells("id").Value
                intIDAnterior = Me.dgvListaGenerar.CurrentRow.Cells("id").Value
            End If

            strFecha = CDate(FechaServidor()).ToShortDateString
            If Me.cboCuentaCorriente.SelectedIndex > 0 Then
                intMoneda = dtCuentaCorriente.Rows(Me.cboCuentaCorriente.SelectedIndex).Item("moneda")
            Else
                intMoneda = IIf(Me.dgvListaGenerar.CurrentRow.Cells("moneda").Value.ToString.Substring(0, 1) = "S", 1, 2)
            End If
            If intMoneda = 1 Then
                dblMonto = CType(Me.lblSoles.Text, Double)
            Else
                dblMonto = CType(Me.lblDolar.Text, Double)
            End If
            intBanco = Me.cboBanco.SelectedValue
            intCuentaCorriente = Me.cboCuentaCorriente.SelectedValue
            strComprobante = Me.txtComprobante.Text.Trim
            strObservacion = Me.txtObservacion.Text.Trim

            If intPortavalor = 1 Then
                intPortavalor = IIf(IsNothing(Me.txtDniPortavalor.Tag), 0, Val(Me.txtDniPortavalor.Tag))
            Else
                intPortavalor = Me.txtCodigoPortavalor.Text.Trim
            End If
            strDni = Me.txtDniPortavalor.Text.Trim
            strNombres = Me.txtNombresPortavalor.Text.Trim
            strCodigo = Me.txtCodigoPortavalor.Text.Trim

            intID = obj.GrabarRemesa(intID, strFecha, dtoUSUARIOS.iIDAGENCIAS, intMoneda, dblMonto, strComprobante,
                                     intPortavalor, strDni, strNombres, strCodigo, _
                                     strObservacion, intBanco, intCuentaCorriente, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
            Dim intIdPreliquidacion As Integer
            With Me.dgvBolsa
                For Each row As DataGridViewRow In Me.dgvBolsa.Rows
                    intIdPreliquidacion = row.Cells("id_preliq_det").Value
                    intIDDetAnterior = row.Cells("id_det").Value
                    obj.GrabarRemesa(intID, intIdPreliquidacion, intIDAnterior, intIDDetAnterior, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                Next
            End With
            Me.LimpiarRemesa()
            intOperacion = Operacion.Nuevo
            ListarRemesaGenerar()
            Me.tabRemesas.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub LimpiarRemesa()
        Me.cboBanco.SelectedValue = 0
        Me.cboCuentaCorriente.SelectedValue = 0
        If intPortavalor = 1 Then
            Me.txtDniPortavalor.Text = ""
            Me.txtNombresPortavalor.Text = ""
            Me.txtCodigoPortavalor.Text = ""
        Else
            Me.txtDniPortavalor.Text = dtoUSUARIOS.DNI
            Me.txtNombresPortavalor.Text = dtoUSUARIOS.NameLogin
            Me.txtCodigoPortavalor.Text = dtoUSUARIOS.IdLogin
        End If
        Me.txtComprobante.Text = ""
        Me.txtObservacion.Text = ""
        Me.dgvBolsa.Rows.Clear()
        'Me.lblSolesLista.Text = "0.00"
        'Me.lblDolarLista.Text = "0.00"
        'Me.lblBolsasLista.Text = "0"
        Me.lblSoles.Text = "0.00"
        Me.lblDolar.Text = "0.00"
        Me.lblBolsas.Text = "0"
        Me.btnRetirar.Enabled = False
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Text = ""
    End Sub
    Sub ListarBolsa(ByVal id As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarBolsa(id)
        AgregarBolsa(dt)
    End Sub
    Sub AnularRemesa()
        Dim intID As Integer = Me.dgvListaGenerar.CurrentRow.Cells("id").Value
        Dim obj As New Cls_LiquidacionValor_LN
        obj.AnularRemesa(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, intPortavalor)
    End Sub
    Sub TotalListaRemesa()
        If Me.dgvListaGenerar.Rows.Count > 0 Then
            Dim intBolsa As Integer = 0, dblSoles As Double = 0, dblDolar As Double = 0
            For Each row As DataGridViewRow In Me.dgvListaGenerar.Rows
                intBolsa += 1
                If row.Cells("moneda").Value = "SOLES" Then
                    dblSoles = dblSoles + row.Cells("monto").Value
                End If
                If row.Cells("moneda").Value = "DOLAR" Then
                    dblDolar = dblDolar + row.Cells("monto").Value
                End If
            Next
            Me.lblBolsasLista.Text = intBolsa
            Me.lblSolesLista.Text = Format(dblSoles, "###,###,###0.00")
            Me.lblDolarLista.Text = Format(dblDolar, "###,###,###0.00")
        Else
            Me.lblBolsasLista.Text = "0"
            Me.lblSolesLista.Text = "0.00"
            Me.lblDolarLista.Text = "0.00"
        End If
    End Sub
    Sub CargarPortavalor()
        Dim obj As New Cls_LiquidacionValor_LN
        Dim strPortavalor As String = obj.ObtienePortavalorRemesa(lblFecha.Text, dtoUSUARIOS.iIDAGENCIAS)
        If strPortavalor.Trim.Length > 0 Then
            Me.txtDniPortavalor.Text = strPortavalor
            txtDniPortavalor_LostFocus(Nothing, Nothing)
        End If
    End Sub
#End Region
#Region "Control"
    Private Sub txtCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.GotFocus
        Me.txtCodigo.SelectAll()
    End Sub
    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCodigo.SelectionStart = 0
            Me.txtCodigo.SelectionLength = Me.txtCodigo.Text.Length
        End If
    End Sub
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                If Val(Me.txtCodigo.Text) = 0 Then Return
                Cursor = Cursors.WaitCursor
                Dim intMoneda As Integer = dtCuentaCorriente.Rows(Me.cboCuentaCorriente.SelectedIndex).Item("moneda")
                If intPortavalor = 2 And intMoneda = 0 Then
                    If Me.dgvBolsa.Rows.Count > 0 Then
                        intMoneda = IIf(Me.dgvBolsa.Rows(0).Cells("moneda").Value.ToString.Substring(0, 1) = "S", 1, 2)
                    End If
                End If
                PrepararBolsa(Me.txtCodigo.Text.Trim, intMoneda)
                Cursor = Cursors.Default
            Else
                If Not ValidarNumero(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBanco.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
    Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.SelectedIndexChanged
        Dim intBanco As Integer
        intBanco = Me.cboBanco.SelectedValue
        ListarCuentaCorriente(intBanco)
    End Sub
    Private Sub txtComprobante_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobante.Enter
        Me.txtComprobante.SelectAll()
    End Sub
    Private Sub txtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacion.Enter
        Me.txtObservacion.SelectAll()
    End Sub
    Private Sub txtDniPortavalor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDniPortavalor.Enter
        Me.txtDniPortavalor.SelectAll()
    End Sub
    Private Sub txtDniPortavalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDniPortavalor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtDniPortavalor_LostFocus(Nothing, Nothing)
            If Me.txtNombresPortavalor.Enabled Then
                Me.txtNombresPortavalor.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtDniPortavalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDniPortavalor.LostFocus
        If Me.txtDniPortavalor.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strNombres As String = "", strDni As String, strCodigo As String
            strDni = Me.txtDniPortavalor.Text.Trim
            ListarProveedor(strDni, intId, strNombres, strCodigo)
            If intId > 0 Then
                Me.txtDniPortavalor.Tag = intId
                Me.txtNombresPortavalor.Text = strNombres
                Me.txtCodigoPortavalor.Text = strCodigo
                Me.txtNombresPortavalor.Enabled = False
                Me.txtCodigoPortavalor.Enabled = False
            Else
                Me.txtDniPortavalor.Tag = ""
                Me.txtNombresPortavalor.Text = ""
                Me.txtNombresPortavalor.Enabled = True
                Me.txtCodigoPortavalor.Enabled = True
                Me.txtNombresPortavalor.Focus()
            End If
        End If
    End Sub
    Private Sub txtDniPortavalor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDniPortavalor.TextChanged
        Me.txtDniPortavalor.Tag = ""
        Me.txtNombresPortavalor.Text = ""
        Me.txtCodigoPortavalor.Text = ""
        Me.txtNombresPortavalor.Enabled = True
        Me.txtCodigoPortavalor.Enabled = True
    End Sub
    Private Sub txtNombresPortavalor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombresPortavalor.Enter
        Me.txtNombresPortavalor.SelectAll()
    End Sub
    Private Sub txtNombresPortavalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombresPortavalor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarLetra(e.KeyChar)
        End If
    End Sub
    Private Sub txtCodigoPortavalor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoPortavalor.Enter
        Me.txtCodigoPortavalor.SelectAll()
    End Sub
    Private Sub txtCodigoPortavalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoPortavalor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
            'Else
            'e.Handled = Not ValidarNumero(e.KeyChar)
        End If
    End Sub
    Private Sub txtComprobante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
    Private Sub btnConsultarRemesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarRemesa.Click
        Try
            Cursor = Cursors.AppStarting
            ListarRemesaGenerar()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Listar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRetirar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetirar.Click
        Try
            If intOperacion = Operacion.Modificar Then
                If Me.dgvBolsa.Rows.Count = 1 Then
                    MessageBox.Show("La Remesa no puede quedarse sin bolsas. Anule la Remesa", "Retirar Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnRetirar.Focus()
                    Return
                End If
            End If

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de retirar la bolsa?", "Retirar Bolsa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                If intOperacion = Operacion.Modificar Then
                    Dim IntID As Integer = Me.dgvBolsa.CurrentRow.Cells("id_preliq_det").Value
                    Dim obj As New Cls_LiquidacionValor_LN
                    obj.RetornarBolsa(IntID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                End If
                Me.dgvBolsa.Rows.Remove(Me.dgvBolsa.CurrentRow)
                TotalRemesa()
                Me.txtCodigo.Text = ""
                Me.txtCodigo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Retirar Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvBolsa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBolsa.KeyDown
        If Me.btnRetirar.Enabled Then
            If e.KeyCode = Keys.Delete Then
                Me.btnRetirar_Click(Nothing, Nothing)
            End If
        End If
    End Sub
    Private Sub dgvBolsa_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvBolsa.RowsAdded
        Me.btnRetirar.Enabled = True
    End Sub
    Private Sub dgvBolsa_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvBolsa.RowsRemoved
        Me.btnRetirar.Enabled = Me.dgvBolsa.Rows.Count > 0
    End Sub
    Private Sub dgvListaGenerar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaGenerar.DoubleClick
        If Me.dgvListaGenerar.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub cboCuentaCorriente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCuentaCorriente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
    Private Sub dgvListaGenerar_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaGenerar.RowEnter
        If dgvListaGenerar.Rows(e.RowIndex).Cells("id_estado").Value = 0 Then
            Me.tsbEditar.Enabled = intNivel = 2 Or intNivel = 5

            Dim strFecha As String = Me.dgvListaGenerar.Rows(e.RowIndex).Cells("fecha_remesa").Value
            strFechaServidor = CDate(FechaServidor()).ToShortDateString
            If CDate(strFecha) = CDate(strFechaServidor) Then
                Me.tsbAnular.Enabled = intNivel = 2 Or intNivel = 5
                blnDisponible = intNivel = 2 Or intNivel = 5
            Else
                Me.tsbAnular.Enabled = False
                blnDisponible = False
            End If
        Else
            blnDisponible = False
            Me.tsbEditar.Enabled = True
            Me.tsbAnular.Enabled = False
        End If
    End Sub
    Private Sub cboCuentaCorriente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuentaCorriente.SelectedIndexChanged
        Me.txtCodigo.Text = ""
        Me.dgvBolsa.Rows.Clear()
        If Me.cboCuentaCorriente.SelectedValue = 0 Then
            Me.txtCodigo.Enabled = False
        Else
            Me.txtCodigo.Enabled = True
        End If
    End Sub
#End Region
#Region "Tab"
    Private Sub tabRemesas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabRemesas.SelectedIndexChanged
        If tabRemesas.SelectedIndex = 0 Then
            Me.tsbNuevo.Enabled = intNivel = 2 Or intNivel = 5
            Me.tsbGrabar.Enabled = False
            If Me.dgvListaGenerar.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = intNivel = 2 Or intNivel = 5
                Me.tsbAnular.Enabled = intNivel = 2 Or intNivel = 5
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
        Else
            Me.tsbNuevo.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvListaGenerar.Rows.Count > 0 And blnInicioRemesa = False Then
                Me.tsbGrabar.Enabled = intNivel = 2 Or intNivel = 5
                Me.tsbEditar_Click(Nothing, Nothing)
            Else
                Me.tsbGrabar.Enabled = intNivel = 2 Or intNivel = 5
                Me.tsbNuevo_Click(Nothing, Nothing)
            End If
        End If
        blnInicioRemesa = False
    End Sub
#End Region
#End Region

#Region "Liquidar Remesa"
#Region "Grid"
    Sub FormateardgvListaLiquidar()
        With dgvListaLiquidar
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .RowHeadersWidth = 20
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nº"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            Dim col_id_agencia As New DataGridViewTextBoxColumn
            With col_id_agencia
                .Name = "id_agencia" : .DataPropertyName = "id_agencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_agencia"
                .ReadOnly = True
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_liquidado As New DataGridViewTextBoxColumn
            With col_liquidado
                .Name = "liquidado" : .DataPropertyName = "liquidado"
                .DisplayIndex = x : .Visible = True : .HeaderText = IIf(AdminPortavalorInt, "Monto Depositado", "Monto Liquidado")
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
                .ReadOnly = True
            End With

            x += +1
            Dim col_pendiente As New DataGridViewTextBoxColumn
            With col_pendiente
                .Name = "pendiente" : .DataPropertyName = "pendiente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Pendiente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_estado_registro As New DataGridViewTextBoxColumn
            With col_id_estado_registro
                .Name = "id_estado_registro" : .DataPropertyName = "id_estado_registro" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado_registro"
                .ReadOnly = True
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_estado As New DataGridViewCheckBoxColumn
            With col_id_estado
                '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                .HeaderText = IIf(AdminPortavalorInt, "Depositado", "Liquidado")
                .Name = "id_estado"
                .DataPropertyName = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.Automatic
                .FalseValue = 0
                .TrueValue = 1
                '.ThreeState = True
                .ReadOnly = False : .DisplayIndex = x
            End With

            x += +1
            Dim col_fecha_operacion As New DataGridViewTextBoxColumn
            With col_fecha_operacion
                .Name = "fecha_operacion" : .DataPropertyName = "fecha_operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_numero_operacion As New DataGridViewTextBoxColumn
            With col_numero_operacion
                .Name = "numero_operacion" : .DataPropertyName = "numero_operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_banco_d As New DataGridViewTextBoxColumn
            With col_banco_d
                .Name = "banco_d" : .DataPropertyName = "banco_d"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Banco"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cuenta_corriente_d As New DataGridViewTextBoxColumn
            With col_cuenta_corriente_d
                .Name = "cuenta_corriente_d" : .DataPropertyName = "cuenta_corriente_d"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Cuenta Corriente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_banco As New DataGridViewTextBoxColumn
            With col_banco
                .Name = "banco" : .DataPropertyName = "banco" : .DisplayIndex = x : .Visible = False : .HeaderText = "banco" : .ReadOnly = True
            End With

            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente" : .DisplayIndex = x : .Visible = False : .HeaderText = "cuenta_corriente" : .ReadOnly = True
            End With

            x += +1
            Dim col_portavalor As New DataGridViewTextBoxColumn
            With col_portavalor
                .Name = "portavalor" : .DataPropertyName = "portavalor" : .DisplayIndex = x : .Visible = False : .HeaderText = "portavalor" : .ReadOnly = True
            End With

            x += +1
            Dim col_monto_parcial As New DataGridViewTextBoxColumn
            With col_monto_parcial
                .Name = "monto_parcial" : .DataPropertyName = "monto_parcial" : .DisplayIndex = x : .Visible = False : .HeaderText = "monto_parcial" : .ReadOnly = True
            End With

            x += +1
            Dim col_monto_depositado As New DataGridViewTextBoxColumn
            With col_monto_depositado
                .Name = "monto_depositado" : .DataPropertyName = "monto_depositado" : .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Depositado" : .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
                .ReadOnly = True
            End With

            .Columns.AddRange(col_id, col_fecha, col_id_agencia, col_agencia, col_moneda, col_monto, col_liquidado, col_pendiente, _
                              col_id_estado_registro, col_estado, col_id_estado, _
                              col_fecha_operacion, col_numero_operacion, col_banco_d, col_cuenta_corriente_d, _
                              col_banco, col_cuenta_corriente, col_portavalor, col_monto_parcial, col_monto_depositado)
        End With
    End Sub
    Sub FormateardgvDetalle()
        With dgvDetalle
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            '.RowHeadersWidth = 22
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
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_det"
            End With

            x += +1
            Dim col_id_preliq As New DataGridViewTextBoxColumn
            With col_id_preliq
                .Name = "id_preliq" : .DataPropertyName = "id_preliq" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliq"
            End With

            x += +1
            Dim col_id_preliq_det As New DataGridViewTextBoxColumn
            With col_id_preliq_det
                .Name = "id_preliq_det" : .DataPropertyName = "id_preliq_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliq_det"
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            'x += +1
            'Dim col_monto_depositado As New DataGridViewTextBoxColumn
            'With col_monto_depositado
            '    .Name = "monto_depositado" : .DataPropertyName = "monto_depositado" : .ReadOnly = True
            '    .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Liquidado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            'End With

            'x += +1
            'Dim col_monto_pendiente As New DataGridViewTextBoxColumn
            'With col_monto_pendiente
            '    .Name = "saldo" : .DataPropertyName = "saldo" : .ReadOnly = True
            '    .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Pendiente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            'End With

            x += +1
            Dim col_fecha_liquidacion As New DataGridViewTextBoxColumn
            With col_fecha_liquidacion
                .Name = "fecha_liquidacion" : .DataPropertyName = "fecha_liquidacion" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Liquidación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With


            x += +1
            Dim col_estado As New DataGridViewCheckBoxColumn
            With col_estado
                .HeaderText = IIf(AdminPortavalorInt, "Depositado", "Liquidado")
                .Name = "estado"
                .DataPropertyName = "estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.Automatic
                .FalseValue = 0
                .TrueValue = 1
                '.ThreeState = True
                .ReadOnly = False
            End With

            'x += +1
            'Dim col_estado2 As New DataGridViewCheckBoxColumn
            'With col_estado2
            '    .HeaderText = "Liquidado con Incidencia"
            '    .Name = "estado2"
            '    .DataPropertyName = "estado2"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    '.SortMode = DataGridViewColumnSortMode.NotSortable
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    .SortMode = DataGridViewColumnSortMode.Automatic
            '    .FalseValue = 0
            '    .TrueValue = 1
            '    '.ThreeState = True
            '    .ReadOnly = False
            'End With

            .Columns.AddRange(col_id, col_id_det, col_id_preliq, col_id_preliq_det, col_codigo, col_usuario, _
                              col_moneda, col_monto, col_fecha_liquidacion, col_estado)
        End With
    End Sub
    Sub FormateardgvIncidencia()
        With dgvIncidencia
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .RowHeadersWidth = 15
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id_remesa As New DataGridViewTextBoxColumn
            With col_id_remesa
                .Name = "id_remesa" : .DataPropertyName = "id_remesa" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_remesa"
            End With

            x += +1
            Dim col_id_remesa_det As New DataGridViewTextBoxColumn
            With col_id_remesa_det
                .Name = "id_remesa_det" : .DataPropertyName = "id_remesa_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_remesa_det"
            End With

            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_id_incidencia As New DataGridViewTextBoxColumn
            With col_id_incidencia
                .Name = "id_incidencia" : .DataPropertyName = "id_incidencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_incidencia"
            End With

            x += +1
            Dim col_incidencia As New DataGridViewTextBoxColumn
            With col_incidencia
                .Name = "incidencia" : .DataPropertyName = "incidencia" : .DisplayIndex = x : .Visible = True : .HeaderText = "Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto" : .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id_remesa, col_id_remesa_det, col_id, col_id_incidencia, col_incidencia, col_monto, col_observacion)
        End With
    End Sub
    Sub FormateardgvListaIncidencia()
        With dgvListaIncidencia
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .RowHeadersWidth = 22
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "Nº Remesa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_det"
            End With

            x += +1
            Dim col_id_preliqdet As New DataGridViewTextBoxColumn
            With col_id_preliqdet
                .Name = "id_preliqdet" : .DataPropertyName = "id_preliqdet" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliqdet"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_monto_depositado As New DataGridViewTextBoxColumn
            With col_monto_depositado
                .Name = "monto_depositado" : .DataPropertyName = "monto_depositado" : .ReadOnly = True
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Depositado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_monto_pendiente As New DataGridViewTextBoxColumn
            With col_monto_pendiente
                .Name = "saldo" : .DataPropertyName = "saldo" : .ReadOnly = True
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Pendiente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_id_incidencia As New DataGridViewTextBoxColumn
            With col_id_incidencia
                .Name = "id_incidencia" : .DataPropertyName = "id_incidencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_incidencia"
            End With

            x += +1
            Dim col_incidencia As New DataGridViewTextBoxColumn
            With col_incidencia
                .Name = "incidencia" : .DataPropertyName = "incidencia" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto_incidencia As New DataGridViewTextBoxColumn
            With col_monto_incidencia
                .Name = "monto_incidencia" : .DataPropertyName = "monto_incidencia" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Incidencia" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With

            x += +1
            Dim col_fecha_operacion As New DataGridViewTextBoxColumn
            With col_fecha_operacion
                .Name = "fecha_operacion" : .DataPropertyName = "fecha_operacion" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_numero_operacion As New DataGridViewTextBoxColumn
            With col_numero_operacion
                .Name = "numero_operacion" : .DataPropertyName = "numero_operacion" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_banco As New DataGridViewTextBoxColumn
            With col_banco
                .Name = "banco" : .DataPropertyName = "banco" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Banco"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Cuenta Corriente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_id_det, col_id_preliqdet, col_fecha, col_agencia, col_usuario, col_codigo, _
                              col_moneda, col_monto, col_monto_depositado, col_monto_pendiente, col_id_incidencia, col_incidencia, col_monto_incidencia, _
                              col_estado, col_idestado, col_fecha_operacion, col_numero_operacion, col_banco, col_cuenta_corriente)
        End With
    End Sub
    Sub FormateardgvIncidenciaDetalle()
        With dgvIncidenciaDetalle
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .RowHeadersWidth = 22
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
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idIncidencia As New DataGridViewTextBoxColumn
            With col_idIncidencia
                .Name = "idIncidencia" : .DataPropertyName = "idIncidencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "idIncidencia"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_idIncidencia, col_fecha, col_estado, col_idestado, col_observacion)
        End With
    End Sub
    Sub FormateardgvParcial()
        With dgvParcial
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            .RowHeadersWidth = 15
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id_remesa As New DataGridViewTextBoxColumn
            With col_id_remesa
                .Name = "id_remesa" : .DataPropertyName = "id_remesa" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_remesa"
            End With

            x += +1
            Dim col_id_remesa_det As New DataGridViewTextBoxColumn
            With col_id_remesa_det
                .Name = "id_remesa_det" : .DataPropertyName = "id_remesa_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_remesa_det"
            End With

            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto" : .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_banco As New DataGridViewTextBoxColumn
            With col_banco
                .Name = "banco" : .DataPropertyName = "banco" : .DisplayIndex = x : .Visible = True : .HeaderText = "Banco"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Cuenta Corriente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idbanco As New DataGridViewTextBoxColumn
            With col_idbanco
                .Name = "idbanco" : .DataPropertyName = "idbanco" : .DisplayIndex = x : .Visible = False : .HeaderText = "idbanco"
            End With

            x += +1
            Dim col_idcuenta_corriente As New DataGridViewTextBoxColumn
            With col_idcuenta_corriente
                .Name = "idcuenta_corriente" : .DataPropertyName = "idcuenta_corriente" : .DisplayIndex = x : .Visible = False : .HeaderText = "idcuenta_corriente"
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id_remesa, col_id_remesa_det, col_id, col_fecha, col_numero, col_monto, col_banco, col_cuenta_corriente, col_idbanco, col_idcuenta_corriente, col_observacion)
        End With
    End Sub
#End Region
#Region "Variable"
    Dim ObjIncidencia As New dtoValor
    Dim aIncidencia As New ArrayList
    Dim blnInicioLiquidarRemesa As Boolean
    Dim strFechaOperacion As String, strNumeroOperacion As String, intBanco As Integer, intCuentaCorriente As Integer
    Dim blnMonto As Boolean, dblMonto As Double

    Dim ObjParcial As New dtoParcial
    Dim aParcial As New ArrayList
#End Region
#Region "Procedimiento"
    Sub ListarAgenciaLiquidar()
        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable
        With Me.cboAgenciaLiquidar
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            dt = obj.ListarAgencia()
            .DataSource = dt
            If AdminPortavalorInt() Then
                .SelectedValue = dtoUSUARIOS.iIDAGENCIAS
                .Enabled = False
            Else
                .SelectedValue = 0
                .Enabled = True
            End If
        End With
        RemoveHandler Me.cboAgenciaIncidencia.SelectedIndexChanged, AddressOf Me.cboAgenciaIncidencia_SelectedIndexChanged
        With Me.cboAgenciaIncidencia
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dt.Copy
            .SelectedValue = 0
        End With
        AddHandler Me.cboAgenciaIncidencia.SelectedIndexChanged, AddressOf Me.cboAgenciaIncidencia_SelectedIndexChanged

    End Sub
    Sub ListarRemesaLiquidar()
        Dim strInicio As String = Me.dtpInicioLiquidar.Value.ToShortDateString
        Dim strFin As String = Me.dtpFinLiquidar.Value.ToShortDateString
        Dim intAgencia As Integer = Me.cboAgenciaLiquidar.SelectedValue
        Dim intEstado As Integer = Me.cboEstado.SelectedIndex - 1
        'If AdminPortavalorInt() AndAlso intEstado = 1 Then
        'intEstado = 2
        'End If

        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarRemesa(strInicio, strFin, intAgencia, intEstado, IIf(AdminPortavalorInt, 2, 1))
        Me.dgvListaLiquidar.DataSource = dt

        If dt.Rows.Count = 0 Then
            Me.tsbEditar.Enabled = False
        Else
            Me.tsbEditar.Enabled = True
        End If
    End Sub
    Sub ListarDetalle(ByVal id As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarBolsa(id)
        Me.dgvDetalle.DataSource = dt
    End Sub
    Sub Limpiar()
        Me.lblFechaLiquidar.Text = ""
        Me.lblAgencia.Text = ""
        Me.lblNumero.Text = ""
        Me.btnAgregarParcial.Enabled = Me.dgvDetalle.Rows.Count > 0
        Me.btnAgregarIncidencia.Enabled = Me.dgvDetalle.Rows.Count > 0
        Me.dgvDetalle.DataSource = Nothing
        Me.dgvIncidencia.Rows.Clear()
        Me.dgvParcial.Rows.Clear()
    End Sub
    Function BolsaTieneIncidencia(ByVal remesa_det As Integer) As Boolean
        Dim obj As dtoValor
        For Each obj In aIncidencia
            If obj.IdRemesaDet = remesa_det Then
                Return True
            End If
        Next
        Return False
    End Function
    Function BolsaTieneParcial(ByVal remesa_det As Integer) As Boolean
        Dim obj As dtoParcial
        For Each obj In aParcial
            If obj.IdRemesaDet = remesa_det Then
                Return True
            End If
        Next
        Return False
    End Function

    Function Validar() As Boolean
        If intPortavalor = 1 Then Return True
        Dim i As Integer = 0
        With Me.dgvDetalle
            For Each row As DataGridViewRow In .Rows
                If row.Cells("estado").Value = 0 And Not BolsaTieneParcial(row.Cells("id_det").Value) Then
                    MessageBox.Show("El retiro debe ser marcado como un depósito o una incidencia", "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .CurrentCell = .Rows(i).Cells("codigo")
                    Me.btnAgregarIncidencia.Focus()
                    Return False
                    'End If
                End If
                i += 1
            Next
        End With
        Return True
    End Function
    Sub CargarIncidencia(ByVal id As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarIncidencia(id)
        aIncidencia = New ArrayList
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                ObjIncidencia = Nothing
                ObjIncidencia = New dtoValor
                ObjIncidencia.IdRemesa = row.Item("id_remesa")
                ObjIncidencia.IdRemesaDet = row.Item("id_remesa_det")
                ObjIncidencia.Id = row.Item("id")
                ObjIncidencia.IdIncidencia = row.Item("id_incidencia")
                ObjIncidencia.Incidencia = row.Item("incidencia")
                ObjIncidencia.Monto = row.Item("monto")
                ObjIncidencia.Observacion = row.Item("observacion")
                aIncidencia.Add(ObjIncidencia)
            Next
        End If
    End Sub
    Sub CargarParcial(ByVal id As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarParcial(id)
        Dim i As Integer = 0
        aParcial = New ArrayList
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                ObjParcial = Nothing
                ObjParcial = New dtoParcial
                ObjParcial.IdRemesa = row.Item("id_remesa")
                ObjParcial.IdRemesaDet = row.Item("id_remesa_det")
                ObjParcial.Id = row.Item("id")
                ObjParcial.IDBanco = row.Item("idbanco")
                ObjParcial.IDCuentaCorriente = row.Item("idcuenta_corriente")
                ObjParcial.Banco = row.Item("banco")
                ObjParcial.CuentaCorriente = row.Item("cuenta_corriente")
                ObjParcial.Fecha = row.Item("fecha")
                ObjParcial.Numero = row.Item("numero")
                ObjParcial.Monto = row.Item("monto")
                ObjParcial.Observacion = row.Item("observacion")
                ObjParcial.Fila = i
                aParcial.Add(ObjParcial)
                i += 1
            Next
        End If
    End Sub
    Function ValorGrid(ByVal dgv As DataGridView) As Integer
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("estado").Value = 0 Then
                Return row.Index
            End If
        Next
        Return -1
    End Function
    Sub GrabarLiquidar()
        Try
            Cursor = Cursors.AppStarting
            Dim intId As Integer, intId_det As Integer, intId_Preliq As Integer, intId_preliq_det As Integer, intEstado As Integer, strEstado As String
            Dim intTipoMoneda As Integer
            Dim obj As New Cls_LiquidacionValor_LN

            With Me.dgvDetalle
                Dim intCheck As Integer = ValorGrid(Me.dgvDetalle)
                If intCheck = -1 Then
                    intTipoMoneda = IIf(Me.dgvListaLiquidar.CurrentRow.Cells("moneda").Value.ToString.Substring(0, 1) = "S", 1, 2)
                    Dim frm As New frmLiquidarRemesa
                    If Me.dgvParcial.Rows.Count > 0 Then
                        intBanco = Me.dgvParcial.Rows(Me.dgvParcial.Rows.Count - 1).Cells("idbanco").Value
                        intCuentaCorriente = Me.dgvParcial.Rows(Me.dgvParcial.Rows.Count - 1).Cells("idcuenta_corriente").Value
                        strFechaOperacion = Me.dgvParcial.Rows(Me.dgvParcial.Rows.Count - 1).Cells("fecha").Value
                        strNumeroOperacion = Me.dgvParcial.Rows(Me.dgvParcial.Rows.Count - 1).Cells("numero").Value
                        frm.cboBanco.Enabled = False : frm.cboCuentaCorriente.Enabled = False
                        frm.dtpFecha.Enabled = False : frm.txtNumero.Enabled = False
                    Else
                        'strFechaOperacion = "" : strNumeroOperacion = ""
                        intBanco = IIf(IsDBNull(dgvListaLiquidar.CurrentRow.Cells("banco").Value), 0, dgvListaLiquidar.CurrentRow.Cells("banco").Value)
                        intCuentaCorriente = IIf(IsDBNull(dgvListaLiquidar.CurrentRow.Cells("cuenta_corriente").Value), 0, dgvListaLiquidar.CurrentRow.Cells("cuenta_corriente").Value)
                        strFechaOperacion = IIf(IsDBNull(dgvListaLiquidar.CurrentRow.Cells("fecha_operacion").Value), "", dgvListaLiquidar.CurrentRow.Cells("fecha_operacion").Value)
                        strNumeroOperacion = IIf(IsDBNull(dgvListaLiquidar.CurrentRow.Cells("numero_operacion").Value), "", dgvListaLiquidar.CurrentRow.Cells("numero_operacion").Value)
                    End If
                    frm.intTipoMoneda = intTipoMoneda
                    frm.intBanco = intBanco
                    frm.intCuentaCorriente = intCuentaCorriente
                    frm.strFecha = strFechaOperacion
                    frm.strNumero = strNumeroOperacion
                    frm.intIncidencia = 0
                    frm.Text = IIf(AdminPortavalorInt, "Depósito de Remesa", "Liquidación de Remesa")
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        intBanco = frm.cboBanco.SelectedValue
                        intCuentaCorriente = frm.cboCuentaCorriente.SelectedValue
                        strFechaOperacion = frm.dtpFecha.Value.ToShortDateString
                        strNumeroOperacion = frm.txtNumero.Text
                    Else
                        intBanco = 0 : intCuentaCorriente = 0
                        strFechaOperacion = "" : strNumeroOperacion = ""
                        Cursor = Cursors.Default
                        Return
                    End If
                End If

                Dim blnIncidencia As Boolean
                Dim intRegistro As Integer = 0
                strEstado = Me.dgvListaLiquidar.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1)
                For Each row As DataGridViewRow In .Rows
                    intRegistro += 1
                    intId = row.Cells("id").Value
                    intId_det = row.Cells("id_det").Value
                    intId_Preliq = row.Cells("id_preliq").Value
                    intId_preliq_det = row.Cells("id_preliq_det").Value

                    Dim intEstado2 As Integer = row.Cells("estado").Value
                    If intEstado2 >= 1 Then
                        If AdminPortavalorInt() Then
                            intEstado2 = 2
                        End If
                        blnIncidencia = BolsaTieneIncidencia(intId_det)
                        If blnIncidencia Then
                            intEstado = IIf(intEstado2 = 1, 4, 7) '2
                        Else
                            intEstado = IIf(AdminPortavalorInt, 2, 1) '1
                        End If
                    Else
                        intEstado = 0
                    End If
                    obj.LiquidarRemesa(intId, intId_det, intId_Preliq, intId_preliq_det, intBanco, intCuentaCorriente, strFechaOperacion, strNumeroOperacion, intEstado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, intRegistro, IIf(AdminPortavalorInt, 2, 1), IIf(strEstado = "P", 0, 1))
                Next

                If Me.dgvParcial.Visible Then
                    'Graba Deposito parcial
                    Dim op As dtoParcial
                    intRegistro = 0
                    For Each op In aParcial
                        intRegistro += 1
                        obj.GrabarParcial(op.IdRemesa, op.IdRemesaDet, op.IDBanco, op.IDCuentaCorriente, op.Fecha, op.Numero, op.Monto, op.Observacion, intRegistro, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                    Next
                End If

                'Graba Incidencia
                Dim o As dtoValor
                intRegistro = 0
                For Each o In aIncidencia
                    intRegistro += 1
                    obj.GrabarIncidencia(o.IdRemesa, o.IdRemesaDet, o.IdIncidencia, o.Monto, o.Observacion, intRegistro, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                Next

                'Finalización de la Grabacion
                strFechaOperacion = "" : strNumeroOperacion = ""
                tabRemesasLiquidar.SelectedIndex = 0
                btnConsultarLiquidar_click(Nothing, Nothing)
                Me.btnConsultarLiquidar.Focus()
            End With
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub AgregarIncidencia(ByVal frm As frmIncidenciaValor, ByVal nuevo As Boolean, Optional ByVal fila As Integer = -1)
        ObjIncidencia = Nothing
        ObjIncidencia = New dtoValor
        ObjIncidencia.IdRemesa = Me.dgvDetalle.CurrentRow.Cells("id").Value
        ObjIncidencia.IdRemesaDet = Me.dgvDetalle.CurrentRow.Cells("id_det").Value
        If nuevo Then
            ObjIncidencia.Id = 0
        Else
            ObjIncidencia.Id = Me.dgvIncidencia.CurrentRow.Cells("id_incidencia").Value
        End If
        ObjIncidencia.IdIncidencia = frm.cboIncidencia.SelectedValue
        ObjIncidencia.Incidencia = frm.cboIncidencia.Text
        ObjIncidencia.Monto = CType(frm.txtMonto.Text, Double)
        ObjIncidencia.Observacion = frm.txtObservacion.Text.Trim
        If nuevo Then
            ObjIncidencia.Fila = aIncidencia.Count
            aIncidencia.Add(ObjIncidencia)
        End If

        If Not nuevo Then
            With Me.dgvIncidencia.CurrentRow
                Dim intPosicion As Integer = 0
                Dim obj As dtoValor
                For Each obj In aIncidencia
                    If obj.IdRemesaDet = .Cells("id_remesa_det").Value And obj.Fila = fila Then 'obj.IdIncidencia = .Cells("id_incidencia").Value Then
                        aIncidencia(intPosicion).monto = CType(frm.txtMonto.Text, Double)
                        aIncidencia(intPosicion).observacion = frm.txtObservacion.Text.Trim
                        Return
                    End If
                    intPosicion += 1
                Next
            End With
        End If
    End Sub
    Sub MostrarIncidencia(ByVal remesa As Integer)
        Dim intFila As Integer
        Dim intIdRemesaDet As Integer = remesa
        Dim obj As dtoValor
        dgvIncidencia.Rows.Clear()
        For Each obj In aIncidencia
            With Me.dgvIncidencia
                If obj.IdRemesaDet = intIdRemesaDet Then
                    .Rows.Add()
                    intFila = .Rows.Count - 1
                    .Rows(intFila).Cells("id_remesa").Value = obj.IdRemesa
                    .Rows(intFila).Cells("id_remesa_det").Value = obj.IdRemesaDet
                    .Rows(intFila).Cells("id").Value = obj.Id
                    .Rows(intFila).Cells("id_incidencia").Value = obj.IdIncidencia
                    .Rows(intFila).Cells("incidencia").Value = obj.Incidencia
                    .Rows(intFila).Cells("monto").Value = obj.Monto
                    .Rows(intFila).Cells("observacion").Value = obj.Observacion
                End If
            End With
        Next
        Me.btnEliminarIncidencia.Enabled = Me.dgvIncidencia.Rows.Count > 0 And Me.tsbGrabar.Enabled
    End Sub
    Sub EliminarIncidencia(ByVal remesadet As Integer, ByVal fila As Integer)
        Dim intPosicion As Integer = 0
        Dim obj As dtoValor
        For Each obj In aIncidencia
            If obj.IdRemesaDet = remesadet And obj.Fila = fila Then 'obj.IdIncidencia = incidencia Then
                aIncidencia.RemoveAt(intPosicion)
                ActualizarFilaDeposito()
                Exit For
            End If
            intPosicion += 1
        Next
        Me.btnAgregarIncidencia.Enabled = True
        Me.btnAgregarParcial.Enabled = True
    End Sub
    Sub TotalLiquidar()
        Dim dblSolesLiquidado As Double = 0, dblDolarLiquidado As Double = 0, dblSoles As Double = 0, dblDolar As Double = 0
        Dim dblSolesPendiente As Double = 0, dblDolarPendiente As Double = 0, dblSolesDepositado As Double = 0, dblDolarDepositado As Double = 0
        If Me.dgvListaLiquidar.Rows.Count > 0 Then
            For Each row As DataGridViewRow In Me.dgvListaLiquidar.Rows
                If row.Cells("moneda").Value = "SOLES" Then
                    dblSoles += row.Cells("monto").Value
                    dblSolesLiquidado += row.Cells("liquidado").Value
                    dblSolesPendiente += row.Cells("pendiente").Value
                End If
                If row.Cells("moneda").Value = "DOLAR" Then
                    dblDolar += row.Cells("monto").Value
                    dblDolarLiquidado += row.Cells("liquidado").Value
                    dblDolarPendiente += row.Cells("pendiente").Value
                End If
            Next
            Me.lblSolesRemesa.Text = Format(dblSoles, "###,###,###0.00")
            Me.lblDolarRemesa.Text = Format(dblDolar, "###,###,###0.00")
            Me.lblSolesLiquidado.Text = Format(dblSolesLiquidado, "###,###,###0.00")
            Me.lblDolarLiquidado.Text = Format(dblDolarLiquidado, "###,###,###0.00")
            Me.lblSolesPendiente.Text = Format(dblSolesPendiente, "###,###,###0.00")
            Me.lblDolarPendiente.Text = Format(dblDolarPendiente, "###,###,###0.00")
        Else
            Me.lblSolesRemesa.Text = "0.00"
            Me.lblDolarRemesa.Text = "0.00"
            Me.lblSolesLiquidado.Text = "0.00"
            Me.lblDolarLiquidado.Text = "0.00"
            Me.lblSolesPendiente.Text = "0.00"
            Me.lblDolarPendiente.Text = "0.00"
        End If
    End Sub
    Sub LiquidarRemesa(ByVal id As Integer, ByVal estado As Integer, ByVal estado_parcial As String, ByVal estado_actual As Integer, ByVal monto As Double)
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New Cls_LiquidacionValor_LN
            obj.LiquidarRemesa(id, intBanco, intCuentaCorriente, strFechaOperacion, strNumeroOperacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, estado, estado_parcial, estado_actual, monto)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Function TotalMontoDepositado(ByVal dgv As DataGridView) As Double
        Dim dblMonto As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            dblMonto += row.Cells("monto").Value
        Next
        Return dblMonto
    End Function
    Sub ActualizarFilaDeposito()
        Dim obj As dtoValor
        Dim intPosicion As Integer = 0
        For Each obj In aIncidencia
            aIncidencia(intPosicion).fila = intPosicion
            intPosicion += 1
        Next
    End Sub
    Sub ActualizarFilaDepositoParcial()
        Dim obj As dtoParcial
        Dim intPosicion As Integer = 0
        For Each obj In aParcial
            aParcial(intPosicion).fila = intPosicion
            intPosicion += 1
        Next
    End Sub
    'Sub ActualizarParcial(ByVal fila As Integer)
    '    Return
    '    Dim dblMontoTotal As Double, dblMontoDepositado As Double, dblSaldo As Double, dblMonto As Double
    '    With Me.dgvDetalle
    '        If .Rows(fila).Cells("estado").Value >= 1 Then
    '            If Me.dgvIncidencia.Rows.Count > 0 Then
    '                dblMontoTotal = .Rows(fila).Cells("monto").Value
    '                dblMontoDepositado = TotalGrid(Me.dgvIncidencia, "monto")
    '                dblSaldo = dblMontoTotal - dblMontoDepositado
    '                .Rows(fila).Cells("monto_depositado").Value = dblMontoDepositado
    '                .Rows(fila).Cells("saldo").Value = dblSaldo
    '                .Rows(fila).Cells("estado").Value = dblSaldo = 0
    '                .RefreshEdit()
    '            End If
    '            Return
    '        End If
    '        dblMontoTotal = .Rows(fila).Cells("monto").Value
    '        dblMonto = TotalGrid(Me.dgvIncidencia, "monto")
    '        If dblMonto > 0 Then
    '            dblMontoDepositado = dblMontoTotal - dblMonto
    '        Else
    '            dblMontoDepositado = 0
    '        End If
    '        dblSaldo = dblMontoTotal - dblMontoDepositado
    '        .Rows(fila).Cells("monto_depositado").Value = dblMontoDepositado
    '        .Rows(fila).Cells("saldo").Value = dblSaldo
    '        .Rows(fila).Cells("estado").Value = dblSaldo = 0
    '        .RefreshEdit()
    '    End With
    'End Sub
#End Region
#Region "Control"
    Private Sub MnuContextSelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelTodo.Click
        Try
            Dim obj As New DtoRecojo
            SeleccionarCheckDgv(Me.dgvDetalle, 8, 1)
            Me.dgvDetalle.RefreshEdit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MnuContextSelEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelEliminar.Click
        Try
            SeleccionarCheckDgv(Me.dgvDetalle, 8, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnConsultarLiquidar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarLiquidar.Click
        Try
            Cursor = Cursors.AppStarting
            ListarRemesaLiquidar()
            TotalLiquidar()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Listar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
        If e.ColumnIndex < 9 Then Return
        Dim intEstado As Integer = dgvDetalle.Rows(e.RowIndex).Cells("estado").Value
        Dim strEstado As String = Me.dgvListaLiquidar.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1)
        If strEstado = "D" Or strEstado = "L" Then
            dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = 1
            Me.dgvDetalle.RefreshEdit()
            Return
        End If
        Dim blnParcial As Boolean = dgvListaLiquidar.CurrentRow.Cells("monto_parcial").Value > 0
        If Not Me.tsbGrabar.Enabled Then
            If blnParcial Then
                dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = IIf(intEstado = 0, 1, 0)
            Else
                dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = IIf(strEstado = "P", 0, 1)
            End If
            Me.dgvDetalle.RefreshEdit()
        Else
            If Me.dgvParcial.Rows.Count > 0 Then
                dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = IIf(intEstado = 0, 1, 0)
                Me.dgvDetalle.RefreshEdit()
            Else
                If intEstado = 0 Then
                    If Me.dgvIncidencia.Rows.Count > 0 Then
                        Dim dlgRespuesta As DialogResult
                        dlgRespuesta = MessageBox.Show("Se encontraron Incidencias ¿Está seguro de continuar?", "Liquidar Remesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                            For Each row As DataGridViewRow In Me.dgvIncidencia.Rows
                                aIncidencia.Clear()
                            Next
                            MostrarIncidencia(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
                        Else
                            dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = 1
                            Me.dgvDetalle.RefreshEdit()
                            Return
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvDetalle_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentDoubleClick
        If e.ColumnIndex < 9 Then Return
        Dim intEstado As Integer = dgvDetalle.Rows(e.RowIndex).Cells("estado").Value
        Dim strEstado As String = Me.dgvListaLiquidar.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1)
        If strEstado = "D" Or strEstado = "L" Then
            dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = 1
            Me.dgvDetalle.RefreshEdit()
            Return
        End If
        Dim blnParcial As Boolean = dgvListaLiquidar.CurrentRow.Cells("monto_parcial").Value > 0
        If Not Me.tsbGrabar.Enabled Then
            If blnParcial Then
                dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = IIf(intEstado = 0, 1, 0)
            Else
                dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = IIf(strEstado = "P", 0, 1)
            End If
            Me.dgvDetalle.RefreshEdit()
        Else
            If Me.dgvParcial.Rows.Count > 0 Or blnParcial Then
                dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = IIf(intEstado = 0, 1, 0)
                Me.dgvDetalle.RefreshEdit()
            Else
                If intEstado = 0 Then
                    If Me.dgvIncidencia.Rows.Count > 0 Then
                        Dim dlgRespuesta As DialogResult
                        dlgRespuesta = MessageBox.Show("Se encontraron Incidencias ¿Está seguro de continuar?", "Liquidar Remesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                            For Each row As DataGridViewRow In Me.dgvIncidencia.Rows
                                aIncidencia.Clear()
                            Next
                            MostrarIncidencia(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
                        Else
                            dgvDetalle.Rows(e.RowIndex).Cells("estado").Value = 1
                            Me.dgvDetalle.RefreshEdit()
                            Return
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub dgvDetalle_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle.CurrentCellDirtyStateChanged
        dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub
    Private Sub dgvDetalle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvDetalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.tsbGrabar.Enabled AndAlso Me.dgvDetalle.Rows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                ContextMenuStrip1.Show(sender, e.X, e.Y)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub dgvListaLiquidar_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaLiquidar.CurrentCellDirtyStateChanged
        dgvListaLiquidar.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub
    Private Sub dgvListaLiquidar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaLiquidar.DoubleClick
        If Me.dgvListaLiquidar.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub dgvIncidencia_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvIncidencia.DoubleClick
        If Me.dgvIncidencia.Rows.Count > 0 Then
            Dim dblMontoTotal As Double, dblMontoDepositado As Double, dblMontoDepositadoTmp As Double, dblMonto As Double, dblMontoParcial As Double
            Dim frm As New frmIncidenciaValor
            frm.Nuevo = False
            frm.Incidencia = Me.dgvIncidencia.CurrentRow.Cells("id_incidencia").Value
            dblMontoParcial = TotalGrid(Me.dgvParcial, "monto")
            If dblMontoParcial > 0 Then
                dblMontoTotal = dblMontoParcial
            Else
                dblMontoTotal = Me.dgvDetalle.CurrentRow.Cells("monto").Value
            End If
            dblMonto = TotalGrid(Me.dgvIncidencia, "monto")
            If dblMonto > 0 Then
                dblMontoDepositado = dblMontoTotal - dblMonto
            Else
                dblMontoDepositado = 0
            End If
            dblMontoDepositadoTmp = TotalGrid(Me.dgvIncidencia, "monto", Me.dgvIncidencia.CurrentCell.RowIndex)
            frm.MontoTotal = dblMontoTotal
            frm.MontoDepositado = dblMontoDepositado
            frm.MontoDepositadoTmp = dblMontoDepositadoTmp
            frm.Monto = Me.dgvIncidencia.CurrentRow.Cells("monto").Value
            frm.Observacion = Me.dgvIncidencia.CurrentRow.Cells("observacion").Value
            frm.Editable = Me.tsbGrabar.Enabled
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                AgregarIncidencia(frm, False, Me.dgvIncidencia.CurrentCell.RowIndex)
                MostrarIncidencia(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
                dblMonto = TotalGrid(Me.dgvIncidencia, "monto")
                Me.btnAgregarIncidencia.Enabled = dblMontoTotal > dblMonto 'Me.dgvDetalle.CurrentRow.Cells("saldo").Value <> 0
            End If
        End If
    End Sub
    Private Sub btnAgregarIncidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarIncidencia.Click
        Dim dblMontoTotal As Double, dblMontoDepositado As Double, dblMonto As Double, dblMontoParcial As Double
        Dim frm As New frmIncidenciaValor
        frm.Nuevo = True
        dblMontoParcial = TotalGrid(Me.dgvParcial, "monto")
        If dblMontoParcial > 0 Then
            dblMontoTotal = dblMontoParcial
        Else
            If Me.dgvDetalle.Rows.Count = 0 Then
                dblMonto = 0
            Else
                dblMontoTotal = Me.dgvDetalle.CurrentRow.Cells("monto").Value
            End If
        End If
        dblMonto = TotalGrid(Me.dgvIncidencia, "monto")
        If dblMonto > 0 Then
            dblMontoDepositado = dblMontoTotal - dblMonto
        Else
            dblMontoDepositado = 0
        End If
        frm.MontoTotal = dblMontoTotal
        frm.MontoDepositado = dblMontoDepositado
        frm.MontoDepositadoTmp = dblMonto
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If Not ExisteValorGrid(Me.dgvIncidencia, 3, frm.cboIncidencia.SelectedValue) Then
                ''Valida si monto depositado es menor a monto con incidencia
                'If Me.dgvParcial.Rows.Count > 0 Then
                '    Dim dblMontoIncidencia As Double = TotalGrid(Me.dgvIncidencia, "monto")
                '    Dim dblMontoParcial2 As Double = TotalGrid(Me.dgvParcial, "monto")
                '    Dim dblMonto2 As Double = CType(frm.txtMonto.Text, Double)
                '    If (dblMontoIncidencia + dblMonto2) > dblMontoParcial2 Then
                '        MessageBox.Show("El Monto con Incidencia no debe ser mayor al Monto Depositado", "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        Me.btnAgregarIncidencia.Focus()
                '        Return
                '    End If
                'End If
                AgregarIncidencia(frm, True)
                MostrarIncidencia(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
                dblMonto = TotalGrid(Me.dgvIncidencia, "monto")
                Me.btnAgregarIncidencia.Enabled = dblMontoTotal > dblMonto
                Me.dgvDetalle.CurrentRow.Cells("estado").Value = True 'Me.dgvParcial.Rows.Count = 0
                Me.dgvDetalle.RefreshEdit()
            Else
                MessageBox.Show("La incidencia ya existe en la lista", "Liquidación de Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub btnEliminarIncidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarIncidencia.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar la Incidencia?", "Eliminar Incidencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                EliminarIncidencia(Me.dgvIncidencia.CurrentRow.Cells("id_remesa_det").Value, Me.dgvIncidencia.CurrentCell.RowIndex)
                MostrarIncidencia(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
                If Me.dgvIncidencia.Rows.Count = 0 Then
                    Me.dgvDetalle.CurrentRow.Cells("estado").Value = Me.dgvParcial.Rows.Count > 0
                    Me.dgvDetalle.RefreshEdit()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Eliminar Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvListaLiquidar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaLiquidar.CellContentClick
        If e.ColumnIndex <> 10 Then Return
        Dim dlgRespuesta As DialogResult
        Dim strMensaje As String
        Dim intEstado As Integer = dgvListaLiquidar.Rows(e.RowIndex).Cells("id_estado").Value
        If intEstado = 0 Then
            dgvListaLiquidar.Rows(e.RowIndex).Cells("id_estado").Value = 1
            dgvListaLiquidar.RefreshEdit()
            Return
        End If
        Dim dblPendiente As Double = dgvListaLiquidar.Rows(e.RowIndex).Cells("pendiente").Value
        Dim intPortavalor As Integer = dgvListaLiquidar.Rows(e.RowIndex).Cells("portavalor").Value
        Dim strEstado As String = dgvListaLiquidar.Rows(e.RowIndex).Cells("estado").Value.ToString.Substring(0, 1)
        Dim blnParcial As Boolean = dgvListaLiquidar.Rows(e.RowIndex).Cells("monto_parcial").Value > 0
        Dim blnOK As Boolean = True
        If AdminPortavalorInt() Then 'administrador
            If strEstado <> "P" Or blnParcial Then
                blnOK = False
            End If
        Else
            If Not (strEstado = "P" Or strEstado = "D" Or strEstado = "L") Or blnParcial Then
                blnOK = False
            Else
                If intPortavalor = 2 And strEstado = "P" Then
                    blnOK = False
                End If
            End If
        End If
        If Not blnOK Then
            'Dim dblMontoDepositado As Double = IIf(IsDBNull(dgvListaLiquidar.Rows(e.RowIndex).Cells("monto_depositado").Value), 0, dgvListaLiquidar.Rows(e.RowIndex).Cells("monto_depositado").Value)
            'If dblMontoDepositado = 0 Then
            dgvListaLiquidar.Rows(e.RowIndex).Cells("id_estado").Value = 0
            dgvListaLiquidar.RefreshEdit()
            Return
            'End If
        End If

        Dim intNumero As Integer = dgvListaLiquidar.Rows(e.RowIndex).Cells("id").Value
        Dim frm As New frmLiquidarRemesa
        If dgvListaLiquidar.Rows(e.RowIndex).Cells("estado").Value.ToString.Substring(0, 1) = "Z" Then
            frm.strFecha = ""
            frm.strNumero = ""
        Else
            frm.intBanco = IIf(IsDBNull(dgvListaLiquidar.Rows(e.RowIndex).Cells("banco").Value), 0, dgvListaLiquidar.Rows(e.RowIndex).Cells("banco").Value)
            frm.intCuentaCorriente = IIf(IsDBNull(dgvListaLiquidar.Rows(e.RowIndex).Cells("cuenta_corriente").Value), 0, dgvListaLiquidar.Rows(e.RowIndex).Cells("cuenta_corriente").Value)
            frm.strFecha = IIf(IsDBNull(dgvListaLiquidar.Rows(e.RowIndex).Cells("fecha_operacion").Value), "", dgvListaLiquidar.Rows(e.RowIndex).Cells("fecha_operacion").Value)
            frm.strNumero = IIf(IsDBNull(dgvListaLiquidar.Rows(e.RowIndex).Cells("numero_operacion").Value), "", dgvListaLiquidar.Rows(e.RowIndex).Cells("numero_operacion").Value)
        End If
        frm.intTipoMoneda = IIf(Me.dgvListaLiquidar.Rows(e.RowIndex).Cells("moneda").Value.ToString.Substring(0, 1) = "S", 1, 2)
        frm.intIncidencia = 0
        frm.Text = IIf(AdminPortavalorInt, "Depósito de Remesa", "Liquidación de Remesa")
        If AdminPortavalorInt() Then
            frm.chkMonto.Visible = True
            frm.txtMonto.Visible = True
            frm.dblMonto = dgvListaLiquidar.Rows(e.RowIndex).Cells("monto").Value
        End If
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            intBanco = frm.cboBanco.SelectedValue
            intCuentaCorriente = frm.cboCuentaCorriente.SelectedValue
            strFechaOperacion = frm.dtpFecha.Value.ToShortDateString
            strNumeroOperacion = frm.txtNumero.Text
            blnMonto = frm.chkMonto.Checked
            If blnMonto Then
                dblMonto = CType(frm.txtMonto.Text, Double)
            Else
                dblMonto = 0
            End If
            LiquidarRemesa(intNumero, IIf(AdminPortavalorInt, 6, 5), strEstado, IIf(strEstado = "P", 0, 1), dblMonto)
            btnConsultarLiquidar_click(Nothing, Nothing)
        Else
            dgvListaLiquidar.Rows(e.RowIndex).Cells("id_estado").Value = 0
            dgvListaLiquidar.RefreshEdit()
        End If
        intBanco = 0
        intCuentaCorriente = 0
        strFechaOperacion = ""
        strNumeroOperacion = ""
    End Sub
#End Region
#Region "Tab"
    Private Sub tabRemesasLiquidar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabRemesasLiquidar.SelectedIndexChanged
        If tabRemesasLiquidar.SelectedTab Is tabRemesasLiquidar.TabPages("tabListaLiquidar") Then
            If Me.dgvListaLiquidar.Rows.Count = 0 Then
                Me.tsbEditar.Enabled = False

            Else
                Me.tsbEditar.Enabled = True
                tsbAnular.Enabled = AdminPortavalorInt() And Me.dgvListaLiquidar.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1) = "D"
            End If
            Me.tsbGrabar.Enabled = False
        ElseIf tabRemesasLiquidar.SelectedTab Is tabRemesasLiquidar.TabPages("tabRemesaLiquidar") Then
            blnInicioLiquidarRemesa = True
            Me.tsbGrabar.Enabled = False
            Me.tsbAnular.Enabled = False
            Limpiar()
            Me.tsbEditar.Enabled = False
            If Me.dgvListaLiquidar.Rows.Count > 0 Then
                Me.tsbEditar_Click(Nothing, Nothing)
                blnInicioLiquidarRemesa = False
                If Me.dgvListaLiquidar.CurrentRow.Cells("portavalor").Value = 1 Then
                    Me.dgvParcial.Visible = False
                    Me.btnAgregarParcial.Visible = False
                    Me.btnEliminarParcial.Visible = False
                    Me.lblDeposito.Visible = False
                    If Me.WindowState = FormWindowState.Maximized Then
                        Me.dgvIncidencia.Width = Me.Width - 80
                    Else
                        Me.dgvIncidencia.Width = Me.Width - 80
                    End If
                Else
                    Me.dgvIncidencia.Width = IIf(Me.WindowState = FormWindowState.Maximized, 478, 478)
                    Me.dgvParcial.Visible = True
                    Me.btnAgregarParcial.Visible = AdminPortavalorInt()
                    Me.btnEliminarParcial.Visible = AdminPortavalorInt()
                    Me.lblDeposito.Visible = True
                End If
            End If
        Else
            Me.tsbEditar.Enabled = False
            If Me.dgvListaIncidencia.Rows.Count > 0 Then
                Me.tsbGrabar.Enabled = Me.dgvListaIncidencia.CurrentRow.Cells("idestado").Value <> 4
            Else
                Me.tsbGrabar.Enabled = False
            End If
        End If
    End Sub
#End Region
#End Region

#Region "Incidencia"
    Sub ListarIncidencia(ByVal dgv As DataGridView)
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable
            dt = obj.ListarIncidencia(Me.dtpInicioIncidencia.Value.ToShortDateString, Me.dtpFinIncidencia.Value.ToShortDateString, _
                                      Me.cboAgenciaIncidencia.SelectedValue, Me.cboUsuarioIncidencia.SelectedValue, Me.cboEstadoIncidencia.SelectedIndex, Me.cboIncidencia.SelectedValue)
            dgv.DataSource = dt
            If dgv.Rows.Count > 0 Then
                Me.tsbGrabar.Enabled = dgv.CurrentRow.Cells("idestado").Value <> 4
                Me.btnAgregarEstado.Enabled = dgv.CurrentRow.Cells("idestado").Value <> 4
            Else
                Me.tsbGrabar.Enabled = False
                Me.btnAgregarEstado.Enabled = False
                Me.dgvIncidenciaDetalle.Rows.Clear()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnConsultarIncidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarIncidencia.Click
        ListarIncidencia(Me.dgvListaIncidencia)
    End Sub

    Sub ListarUsuarioIncidencia(ByVal cbo As ComboBox)
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable
            dt = obj.ListarUsuarioIncidencia(Me.dtpInicioIncidencia.Value.ToShortDateString, Me.dtpFinIncidencia.Value.ToShortDateString, _
                                      Me.cboAgenciaIncidencia.SelectedValue, Me.cboEstadoIncidencia.SelectedIndex)
            With cbo
                .DisplayMember = "usuario"
                .ValueMember = "id"
                .DataSource = dt
                .SelectedValue = 0
            End With
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpInicioIncidencia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicioIncidencia.ValueChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidencia)
    End Sub

    Private Sub dtpFinIncidencia_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFinIncidencia.ValueChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidencia)
    End Sub

    Private Sub cboAgenciaIncidencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgenciaIncidencia.SelectedIndexChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidencia)
    End Sub

    Private Sub cboEstadoIncidencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoIncidencia.SelectedIndexChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidencia)
    End Sub

    Private Sub dgvDetalle_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.RowEnter
        MostrarIncidencia(Me.dgvDetalle.Rows(e.RowIndex).Cells("id_det").Value)
        MostrarParcial(Me.dgvDetalle.Rows(e.RowIndex).Cells("id_det").Value)
        If Not Me.tsbGrabar.Enabled Then
            Me.btnAgregarIncidencia.Enabled = False
            Me.btnEliminarIncidencia.Enabled = False
            Return
        Else
            Me.btnAgregarIncidencia.Enabled = True
        End If
    End Sub

    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer)
        For Each row As DataGridViewRow In dgv.Rows
            If estado = 1 Then
                row.Cells(col).Value = estado
            Else
                If Not BolsaTieneIncidencia(row.Cells("id_det").Value) Then
                    row.Cells(col).Value = estado
                End If
            End If
        Next
    End Sub

    Sub ListarTipoIncidencia(ByVal cbo As ComboBox)
        Dim obj As New UtilData_LN
        Dim dt As DataTable = obj.TipoControl(17, 1)
        With cbo
            .DisplayMember = "descripcion"
            .ValueMember = "codigo"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Sub AgregarEstado(ByVal frm As frmEstadoIncidencia, Optional ByVal fila As Integer = -1)
        Dim intFila As Integer
        With Me.dgvIncidenciaDetalle
            If fila = -1 Then
                .Rows.Add()
                intFila = .Rows.Count - 1
            Else
                intFila = fila
            End If
            .Rows(intFila).Cells("id").Value = 0
            .Rows(intFila).Cells("idincidencia").Value = Me.dgvListaIncidencia.CurrentRow.Cells("id_incidencia").Value
            .Rows(intFila).Cells("fecha").Value = frm.dtpFecha.Value.ToShortDateString
            .Rows(intFila).Cells("estado").Value = frm.cboEstado.Text
            .Rows(intFila).Cells("idestado").Value = frm.cboEstado.SelectedIndex
            .Rows(intFila).Cells("observacion").Value = frm.txtObservacion.Text.Trim
        End With
    End Sub

    Private Sub btnAgregarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarEstado.Click
        Dim frm As New frmEstadoIncidencia
        frm.Nuevo = True
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If Not ExisteValorGrid(Me.dgvIncidenciaDetalle, 4, frm.cboEstado.SelectedIndex) Then
                AgregarEstado(frm)
            Else
                MessageBox.Show("El estado ya existe en la lista", "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnEliminarEstado.Focus()
            End If
        End If
    End Sub

    Private Sub btnEliminarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarEstado.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar el estado?", "Incidencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Me.dgvIncidenciaDetalle.Rows.RemoveAt(Me.dgvIncidenciaDetalle.CurrentCell.RowIndex)
            Me.btnEliminarEstado.Enabled = Me.dgvIncidenciaDetalle.Rows.Count > 0
        End If
    End Sub

    Sub GrabarEstadoIncidencia()
        Try
            Cursor = Cursors.AppStarting
            Dim intId As Integer, intIDIncidencia As Integer, intRemesa As Integer, intEstado As Integer, intRegistro As Integer = 0
            Dim strFecha As String, strObservacion As String
            Dim strFechaOperacion As String, strNumeroOperacion As String, intBanco As Integer, intCuentaCorriente As Integer
            If ExisteValorGrid(Me.dgvIncidenciaDetalle, 4, 4) Then
                Dim frm As New frmLiquidarRemesa
                frm.strFecha = "" : frm.strNumero = ""
                frm.intTipoMoneda = IIf(Me.dgvListaIncidencia.CurrentRow.Cells("moneda").Value.ToString.Substring(0, 1) = "S", 1, 2)
                frm.intIncidencia = 1
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    intBanco = frm.cboBanco.SelectedValue
                    intCuentaCorriente = frm.cboCuentaCorriente.SelectedValue
                    strFechaOperacion = frm.dtpFecha.Value.ToShortDateString
                    strNumeroOperacion = frm.txtNumero.Text.Trim
                    intIncidenciaEstado = 0
                Else
                    Cursor = Cursors.Default
                    Return
                End If
            End If

            Dim blnIncidenciaEstado As Boolean = True
            If intIncidenciaEstado > 0 Then
                If intIncidenciaEstado = Me.dgvIncidenciaDetalle.Rows.Count Then
                    blnIncidenciaEstado = False
                Else
                    blnIncidenciaEstado = True
                End If
            End If
            If blnIncidenciaEstado Then
                Dim obj As New Cls_LiquidacionValor_LN
                With Me.dgvIncidenciaDetalle
                    For Each row As DataGridViewRow In .Rows
                        intRegistro += 1
                        intId = Me.dgvListaIncidencia.CurrentRow.Cells("id_preliqdet").Value
                        intIDIncidencia = row.Cells("idincidencia").Value
                        intRemesa = Me.dgvListaIncidencia.CurrentRow.Cells("id").Value

                        strFecha = row.Cells("fecha").Value
                        intEstado = row.Cells("idestado").Value
                        strObservacion = row.Cells("observacion").Value
                        obj.GrabarEstadoIncidencia(intId, intIDIncidencia, intRemesa, strFecha, intEstado, strObservacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, intRegistro, strFechaOperacion, strNumeroOperacion, intBanco, intCuentaCorriente)
                        intIncidenciaEstado = Me.dgvIncidenciaDetalle.Rows.Count
                    Next
                End With
            End If
            btnConsultarIncidencia_Click(Nothing, Nothing)
            Me.btnConsultarIncidencia.Focus()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvListaIncidencia_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaIncidencia.RowEnter
        Dim obj As New Cls_LiquidacionValor_LN
        Dim intEstado As Integer = Me.dgvListaIncidencia.Rows(e.RowIndex).Cells("idestado").Value
        If intEstado = 4 Then
            Me.btnAgregarEstado.Enabled = False
            Me.btnEliminarEstado.Enabled = False
            Me.tsbGrabar.Enabled = False
        Else
            Me.btnAgregarEstado.Enabled = True
            Me.tsbGrabar.Enabled = True
        End If

        Dim intId As Integer = Me.dgvListaIncidencia.Rows(e.RowIndex).Cells("id_incidencia").Value
        Dim dt As DataTable = obj.ListarEstadoIncidencia(intId)
        If dt.Rows.Count > 0 Then
            Dim intFila As Integer = 0
            With Me.dgvIncidenciaDetalle
                .Rows.Clear()
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    .Rows(intFila).Cells("id").Value = row.Item("id")
                    .Rows(intFila).Cells("idincidencia").Value = row.Item("idincidencia")
                    .Rows(intFila).Cells("fecha").Value = CDate(row.Item("fecha")).ToShortDateString
                    .Rows(intFila).Cells("estado").Value = row.Item("estado")
                    .Rows(intFila).Cells("idestado").Value = row.Item("idestado")
                    .Rows(intFila).Cells("observacion").Value = row.Item("observacion")
                    intFila = intFila + 1
                Next
            End With
            Me.btnEliminarEstado.Enabled = Me.dgvIncidenciaDetalle.Rows(0).Cells("idestado").Value <> 1
        End If
    End Sub

    Private Sub dgvIncidenciaDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvIncidenciaDetalle.DoubleClick
        Dim frm As New frmEstadoIncidencia
        frm.Nuevo = False
        frm.Fecha = Me.dgvIncidenciaDetalle.CurrentRow.Cells("fecha").Value
        frm.Estado = Me.dgvIncidenciaDetalle.CurrentRow.Cells("idestado").Value
        frm.Observacion = Me.dgvIncidenciaDetalle.CurrentRow.Cells("observacion").Value
        frm.Liquidado = Me.dgvListaIncidencia.CurrentRow.Cells("idestado").Value = 4
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            AgregarEstado(frm, Me.dgvIncidenciaDetalle.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub dgvIncidenciaDetalle_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIncidenciaDetalle.RowEnter
        Me.btnEliminarEstado.Enabled = Me.btnAgregarEstado.Enabled AndAlso Me.dgvIncidenciaDetalle.Rows(e.RowIndex).Cells("idestado").Value <> 1
    End Sub

    Private Sub txtComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComprobante.TextChanged

    End Sub

    Private Sub txtCodigoPortavalor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoPortavalor.TextChanged

    End Sub

    Private Sub dgvListaIncidencia_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaIncidencia.CellContentClick

    End Sub

#End Region

#Region "Consulta"
    Sub ListarAgenciaDeposito()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboAgenciaDeposito
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarAgencia
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarAgenciaOperacion()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboAgenciaConsulta
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarAgenciaOperacion(Me.cboOperacionConsulta.SelectedIndex)
            .SelectedValue = IIf(intNivel = 2, dtoUSUARIOS.iIDAGENCIAS, 0)
        End With
    End Sub
    Sub ListarUsuarioAgencia(ByVal fecha As String, ByVal agencia As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboUsuarioConsulta
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarUsuarioAgencia(fecha, agencia)
            .SelectedValue = 0
        End With
    End Sub
#End Region

#Region "Seguimiento"
#Region "Grid"
    Sub FormateardgvSeguimiento()
        With dgvSeguimiento
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .RowHeadersWidth = 30
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = .ColumnHeadersHeight * 2
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
                .Frozen = True
            End With

            x += +1
            Dim col_cofre As New DataGridViewTextBoxColumn
            With col_cofre
                .Name = "cofre" : .DataPropertyName = "cofre"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fuera Cofre" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_bolsa1 As New DataGridViewTextBoxColumn
            With col_bolsa1
                .Name = "bolsa1" : .DataPropertyName = "bolsa1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "S/." : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_bolsa2 As New DataGridViewTextBoxColumn
            With col_bolsa2
                .Name = "bolsa2" : .DataPropertyName = "bolsa2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "US$" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cofre1 As New DataGridViewTextBoxColumn
            With col_cofre1
                .Name = "cofre1" : .DataPropertyName = "cofre1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "S/." : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cofre2 As New DataGridViewTextBoxColumn
            With col_cofre2
                .Name = "cofre2" : .DataPropertyName = "cofre2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "US$" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_lugar As New DataGridViewTextBoxColumn
            With col_lugar
                .Name = "lugar" : .DataPropertyName = "lugar"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Lugar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_portavalor1 As New DataGridViewTextBoxColumn
            With col_portavalor1
                .Name = "portavalor1" : .DataPropertyName = "portavalor1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "S/." : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_portavalor2 As New DataGridViewTextBoxColumn
            With col_portavalor2
                .Name = "portavalor2" : .DataPropertyName = "portavalor2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "US$" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_incidencia1 As New DataGridViewTextBoxColumn
            With col_incidencia1
                .Name = "incidencia1" : .DataPropertyName = "incidencia1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "S/." : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_incidencia2 As New DataGridViewTextBoxColumn
            With col_incidencia2
                .Name = "incidencia2" : .DataPropertyName = "incidencia2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "US$" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cuenta1 As New DataGridViewTextBoxColumn
            With col_cuenta1
                .Name = "cuenta1" : .DataPropertyName = "cuenta1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "S/." : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cuenta2 As New DataGridViewTextBoxColumn
            With col_cuenta2
                .Name = "cuenta2" : .DataPropertyName = "cuenta2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "US$" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_liquidado As New DataGridViewTextBoxColumn
            With col_liquidado
                .Name = "liquidado" : .DataPropertyName = "liquidado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Liquidado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_sin_liquidar As New DataGridViewTextBoxColumn
            With col_sin_liquidar
                .Name = "sin_liquidar" : .DataPropertyName = "sin_liquidar"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto sin Liquidar" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_fecha, col_agencia, col_usuario, col_monto, col_cofre, col_bolsa1, col_bolsa2, col_cofre1, col_cofre2,col_lugar, _
                              col_portavalor1, col_portavalor2, col_incidencia1, col_incidencia2, col_cuenta1, col_cuenta2, col_liquidado, col_sin_liquidar)
        End With
    End Sub
#End Region
#Region "Procedimiento"
    Sub ListarAgenciaSeguimiento()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboAgenciaSeguimiento
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarAgencia(Me.cboTipo.SelectedIndex)
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarEstadoSeguimiento()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboEstadoSeguimiento
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarEstado
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarSeguimiento()
        Try
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable = obj.ListarSeguimiento(Me.dtpInicioSeguimiento.Value.ToShortDateString, Me.dtpFinSeguimiento.Value.ToShortDateString, _
                                                        Me.cboAgenciaSeguimiento.SelectedValue, Me.cboEstadoSeguimiento.SelectedValue, dtoUSUARIOS.IP, Me.cboTipo.SelectedIndex)
            Me.dgvSeguimiento.DataSource = dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub TotalSeguimiento()
        If Me.dgvSeguimiento.Rows.Count > 0 Then
            Dim dblSoles As Double = 0, dblDolar As Double = 0, dblSolesLiquidado As Double = 0, dblDolarLiquidado As Double = 0, dblFueraCofre As Double = 0
            Dim dblSolesSinLiquidar As Double = 0, dblDolarSinLiquidar As Double = 0
            For Each row As DataGridViewRow In Me.dgvSeguimiento.Rows
                dblSoles = dblSoles + row.Cells("monto").Value
                dblFueraCofre = dblFueraCofre + row.Cells("cofre").Value
                dblSolesLiquidado = dblSolesLiquidado + row.Cells("liquidado").Value
                dblSolesSinLiquidar = dblSolesSinLiquidar + row.Cells("sin_liquidar").Value
            Next
            Me.lblMontoTotal.Text = Format(dblSoles, "###,###,###0.00")
            Me.lblMontoFueraCofre.Text = Format(dblFueraCofre, "###,###,###0.00")
            Me.lblMontoLiquidado.Text = Format(dblSolesLiquidado, "###,###,###0.00")
            Me.lblMontosinLiquidar.Text = Format(dblSolesSinLiquidar, "###,###,###0.00")
        Else
            Me.lblMontoTotal.Text = "0.00"
            Me.lblMontoFueraCofre.Text = "0.00"
            Me.lblMontoLiquidado.Text = "0.00"
            Me.lblMontosinLiquidar.Text = "0.00"
        End If
    End Sub
#End Region
#Region "Control"
    Private Sub btnConsultarSeguimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarSeguimiento.Click
        Try
            Cursor = Cursors.AppStarting
            ListarSeguimiento()
            TotalSeguimiento()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Seguimiento", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvSeguimiento_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvSeguimiento.CellPainting
        'If e.RowIndex = -1 Or e.ColumnIndex > -1 Then
        '    Dim r2 As Rectangle = e.CellBounds
        '    r2.Y += e.CellBounds.Height / 2
        '    r2.Height = e.CellBounds.Height / 2

        '    e.PaintBackground(r2, True)

        '    e.PaintContent(r2)
        '    e.Handled = True
        'End If
    End Sub

    Private Sub dgvSeguimiento_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSeguimiento.ColumnWidthChanged
        'Dim rtHeader As Rectangle = Me.dgvSeguimiento.DisplayRectangle
        'rtHeader.Height = Me.dgvSeguimiento.ColumnHeadersHeight / 2
        'Me.dgvSeguimiento.Invalidate(rtHeader)
    End Sub

    Private Sub dgvSeguimiento_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dgvSeguimiento.Paint
        With Me.dgvSeguimiento
            Dim monthes As String() = {"Bolsa", "Cofre", "Bóveda", "Incidencia", "Cuenta"}

            Dim j As Integer = 0
            While j < 10
                Dim r1 As Rectangle = .GetCellDisplayRectangle(j + 5, -1, True)
                r1.X += 1
                If j >= 4 Then
                    r1.X += 42
                End If
                r1.Y += 1
                r1.Width = r1.Width * 2 ' - 2
                r1.Height = r1.Height / 2 ' - 2

                'e.Graphics.FillRectangle(New SolidBrush(.ColumnHeadersDefaultCellStyle.BackColor), r1)
                e.Graphics.FillRectangle(New SolidBrush(Me.dgvSeguimiento.RowsDefaultCellStyle.BackColor), r1)

                Dim format As New StringFormat()
                format.Alignment = StringAlignment.Center
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(monthes(j \ 2), .ColumnHeadersDefaultCellStyle.Font, _
                                      New SolidBrush(.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
                j += 2
            End While
        End With
    End Sub

    Private Sub dgvSeguimiento_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvSeguimiento.Scroll
        Dim rtHeader As Rectangle = Me.dgvSeguimiento.DisplayRectangle
        rtHeader.Height = Me.dgvSeguimiento.ColumnHeadersHeight / 2
        Me.dgvSeguimiento.Invalidate(rtHeader)
    End Sub
#End Region
#End Region

#Region "Publico"
#Region "Inicio"
    Private Sub frmLiquidacionValores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strFechaServidor = CDate(FechaServidor()).ToShortDateString
        intPortavalor = dtoUSUARIOS.Portavalor '1 con portavalor 2 sin portavalor
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            intNivel = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            intNivel = 2
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
            intNivel = 3
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
            intNivel = 4
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 5) Then
            intNivel = 5
        Else
            intNivel = 0
        End If
        If intNivel = 1 Then
            If intPortavalor = 2 Then
                intNivel = 0
            End If
        End If
        If intNivel = 1 Then 'counter
            InicioPrecierre()
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab2"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab3"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab4"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab5"))
        ElseIf intNivel = 2 Then 'administrador de oficina
            InicioSeguimiento()
            InicioRemesa()
            InicioPrecierre()
            If intPortavalor = 1 Then
                Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab3"))
                Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab5"))
            Else
                InicioLiquidar()
                Me.tabRemesasLiquidar.TabPages.Remove(tabIncidenciaLiquidar)
                Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab5"))
            End If
        ElseIf intNivel = 3 Then 'administrador
            InicioSeguimiento()
            InicioRemesa()
            InicioPrecierre()
            InicioConsulta()

            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab3"))
        ElseIf intNivel = 4 Then 'fiscalizacion
            InicioSeguimiento()
            InicioLiquidar()
            InicioConsulta()
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab1"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab2"))
            Me.tabConsultas.TabPages.Remove(Me.tabConsultas.TabPages("tabEficiencia"))
        ElseIf intNivel = 5 Then 'sistemas
            InicioSeguimiento()
            InicioLiquidar()
            InicioRemesa()
            InicioPrecierre()
            InicioConsulta()
        Else 'otros
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab1"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab2"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab3"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab4"))
            Me.tabLiquidacion.TabPages.Remove(Me.tabLiquidacion.TabPages("tab5"))
        End If
    End Sub
#End Region
#Region "Variable"
    Dim strFechaServidor As String
    Dim intNivel As Integer
    Dim intPortavalor As Integer
    Dim intIncidenciaEstado As Integer
#End Region
#Region "Procedimiento"
    Sub InicioPrecierre()
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False
        Me.tsbImprimir.Enabled = False

        FormateardgvMovimiento()
        FormateardgvComprobanteCierre()
        FormateardgvRetiro()
        'FormateardgvBillete()
        FormateardgvComprobante()
        ListarAgencia()
        ListarUsuario()
        Me.dtpFechaInicio.Value = strFechaServidor

        If intNivel = 1 Then
            Me.cboUsuario.SelectedValue = dtoUSUARIOS.IdLogin
            If IsNothing(Me.cboUsuario.SelectedValue) Then
                Me.cboUsuario.SelectedValue = 0
            End If
            Me.cboUsuario.Enabled = False
            Me.cboAgencia.Enabled = False
        ElseIf intNivel = 2 Then
            Me.cboUsuario.SelectedValue = 0
            Me.cboUsuario.Enabled = True
            Me.cboAgencia.Enabled = False
            If intPortavalor = 1 Then
                Me.btnActualizarCierre.Enabled = False
                Me.btnRetiroSolesCierre.Enabled = False
                Me.btnRetiroDolarCierre.Enabled = False
            End If
        ElseIf intNivel = 3 Or intNivel = 5 Then
            Me.cboUsuario.SelectedValue = 0
            Me.cboUsuario.Enabled = True
            Me.cboAgencia.SelectedValue = 0
            Me.cboAgencia.Enabled = True
            Me.btnActualizarCierre.Enabled = False
            Me.btnRetiroSolesCierre.Enabled = False
            Me.btnRetiroDolarCierre.Enabled = False
            Else
                Me.cboUsuario.SelectedValue = -1
                Me.cboUsuario.Enabled = False
                Me.btnActualizarCierre.Enabled = False
                Me.btnRetiroSolesCierre.Enabled = False
                Me.btnRetiroDolarCierre.Enabled = False
            End If
    End Sub
    Sub InicioRemesa()
        Me.tsbNuevo.Enabled = True
        blnInicioRemesa = True
        toolTip.SetToolTip(Me.btnRetirar, "Retirar Bolsa")
        FormateardgvListaGenerar()
        FormateardgvBolsa()
        ListarAgenciaGenerar()
        ListarBanco()
        Me.lblFecha.Text = strFechaServidor
        Me.cboAgenciaGenerar.Enabled = intNivel = 3 Or intNivel = 5
        'If intPortavalor = 2 Then
        'Me.cboBanco.Enabled = False
        'Me.cboCuentaCorriente.Enabled = False
        'End If
    End Sub
    Sub InicioLiquidar()
        With Me.cboEstado
            .Items.Add("(TODO)") '-1
            .Items.Add("PENDIENTE") '0
            If Not AdminPortavalorInt() Then
                .Items.Add("DEPOSITADO") '1
                .Items.Add("PARCIAL") '2
                .Items.Add("LIQUIDADO") '3
            Else
                .Items.Add("DEPOSITADO")
                .Items.Add("PARCIAL")
                .Items.Add("LIQUIDADO")
            End If
        End With
        FormateardgvListaLiquidar()
        FormateardgvDetalle()
        FormateardgvIncidencia()
        FormateardgvParcial()
        FormateardgvListaIncidencia()
        FormateardgvIncidenciaDetalle()
        ListarAgenciaLiquidar()
        ListarTipoIncidencia(Me.cboIncidencia)
        Me.dtpInicioLiquidar.Value = DateAdd(DateInterval.Day, -7, Me.dtpFin.Value)
        Me.cboEstado.SelectedIndex = 1
        Me.cboEstadoIncidencia.SelectedIndex = 1
        Me.cboAgenciaIncidencia.SelectedValue = 0
        Me.lblLiquidado.Text = IIf(AdminPortavalorInt, "Depositado", "Liquidado")
        tabLiquidacion.TabPages("tab3").Text = IIf(AdminPortavalorInt, "Depositar Remesa", "Liquidar Remesa")
    End Sub
    Sub InicioConsulta()
        Dim obj As New Cls_LiquidacionValor_LN

        LimpiarConsulta()
        FormateardgvConsulta()
        FormateardgvDeposito()
        FormateardgvConsultaIncidencia()
        ListarAgenciaDeposito()
        Me.cboEstadoDeposito.SelectedIndex = 0
        Me.cboOperacionConsulta.SelectedIndex = 0
        If intNivel = 2 Then
            Me.cboOperacionConsulta.Enabled = False
            Me.cboOperacionConsulta.SelectedIndex = obj.ObtieneAgenciaPortavalor(dtoUSUARIOS.iIDAGENCIAS)
            Me.cboAgenciaConsulta.Enabled = False
        Else
            Me.cboOperacionConsulta.Enabled = True
            Me.cboAgenciaConsulta.Enabled = True
        End If

        With Me.cboAgenciaIncidenciaConsulta
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarAgencia()
            .SelectedValue = 0
        End With
        ListarTipoIncidencia(Me.cboIncidenciaConsulta)
        Me.cboEstadoIncidenciaConsulta.SelectedIndex = 1
        Me.cboAgenciaIncidenciaConsulta.SelectedValue = 0
    End Sub
    Sub InicioSeguimiento()
        FormateardgvSeguimiento()
        'ListarAgenciaSeguimiento()
        ListarEstadoSeguimiento()
        Me.cboTipo.SelectedIndex = 0
        If intNivel = 2 Then
            Me.cboAgenciaSeguimiento.SelectedValue = dtoUSUARIOS.iIDAGENCIAS
            Me.cboAgenciaSeguimiento.Enabled = False
        Else
            Me.cboAgenciaSeguimiento.SelectedValue = 0
            Me.cboAgenciaSeguimiento.Enabled = True
        End If
    End Sub
    Function AdminPortavalorInt() As Boolean
        If intNivel = 2 And intPortavalor = 2 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "Control"
#End Region
#Region "Tab"
    Private Sub tabLiquidacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabLiquidacion.SelectedIndexChanged
        If tabLiquidacion.SelectedTab Is tabLiquidacion.TabPages("tab1") Then
            'InicioPrecierre()
            'Me.btnConsultarPrecierre_Click(Nothing, Nothing)
            If intNivel = 1 Then
                Me.cboUsuario.SelectedValue = dtoUSUARIOS.IdLogin
                If IsNothing(Me.cboUsuario.SelectedValue) Then
                    Me.cboUsuario.SelectedValue = 0
                End If
                Me.cboUsuario.Enabled = False
                Me.cboAgencia.Enabled = False
            ElseIf intNivel = 2 Then
                Me.cboUsuario.SelectedValue = 0
                Me.cboUsuario.Enabled = True
                Me.cboAgencia.Enabled = False
                If intPortavalor = 1 Then
                    Me.btnActualizarCierre.Enabled = False
                    Me.btnRetiroSolesCierre.Enabled = False
                    Me.btnRetiroDolarCierre.Enabled = False
                End If
            ElseIf intNivel = 3 Or intNivel = 5 Then
                Me.cboUsuario.SelectedValue = 0
                Me.cboUsuario.Enabled = True
                Me.cboAgencia.SelectedValue = 0
                Me.cboAgencia.Enabled = True
                Me.btnActualizarCierre.Enabled = False
                Me.btnRetiroSolesCierre.Enabled = False
                Me.btnRetiroDolarCierre.Enabled = False
            Else
                Me.cboUsuario.SelectedValue = -1
                Me.cboUsuario.Enabled = False
                Me.btnActualizarCierre.Enabled = False
                Me.btnRetiroSolesCierre.Enabled = False
                Me.btnRetiroDolarCierre.Enabled = False
            End If
        ElseIf tabLiquidacion.SelectedTab Is tabLiquidacion.TabPages("tab2") Then
            If Me.tabRemesas.SelectedTab Is Me.tabRemesas.TabPages("tabRemesa") Then
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
                Me.tsbImprimir.Enabled = False
                Me.tsbGrabar.Enabled = intNivel = 2 Or intNivel = 5
            Else
                Me.tsbImprimir.Enabled = False
                If intNivel = 2 Or intNivel = 5 Then
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    If dgvListaGenerar.Rows.Count > 0 Then
                        tsbEditar.Enabled = True
                        tsbAnular.Enabled = Me.dgvListaGenerar.CurrentRow.Cells("id_estado").Value = 0
                    Else
                        tsbEditar.Enabled = False
                        tsbAnular.Enabled = False
                    End If
                Else
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbAnular.Enabled = False
                End If
            End If
        ElseIf tabLiquidacion.SelectedTab Is tabLiquidacion.TabPages("tab3") Then
            Me.tsbNuevo.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbImprimir.Enabled = False
            If Me.tabRemesasLiquidar.SelectedTab Is Me.tabRemesasLiquidar.TabPages("tabRemesaLiquidar") Then
                Me.tsbEditar.Enabled = False
                If dgvListaLiquidar.Rows.Count > 0 Then
                    Me.tsbGrabar.Enabled = Me.dgvDetalle.CurrentRow.Cells("estado").Value = 0
                Else
                    Me.tsbGrabar.Enabled = False
                End If
            ElseIf Me.tabRemesasLiquidar.SelectedTab Is Me.tabRemesasLiquidar.TabPages("tabIncidenciaLiquidar") Then
                Me.tsbEditar.Enabled = False
                If dgvListaIncidencia.Rows.Count > 0 Then
                    Me.tsbGrabar.Enabled = Me.dgvListaIncidencia.CurrentRow.Cells("idestado").Value <> 4
                Else
                    Me.tsbGrabar.Enabled = False
                End If
            Else
                If dgvListaLiquidar.Rows.Count > 0 Then
                    tsbEditar.Enabled = True
                    tsbAnular.Enabled = AdminPortavalorInt() And Me.dgvListaLiquidar.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1) = "D"
                Else
                    tsbEditar.Enabled = False
                End If
            End If
        ElseIf tabLiquidacion.SelectedTab Is tabLiquidacion.TabPages("tab4") Then
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbImprimir.Enabled = False
        End If
    End Sub
#End Region
#Region "Menu"
    Private Sub tsbNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo
        If Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab1") Then
        ElseIf Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab2") Then
            blnInicioRemesa = True
            Me.grbDestino.Enabled = True
            Me.grbPortavalor.Enabled = intPortavalor = 1
            Me.grbDatos.Enabled = True
            Me.txtCodigo.Enabled = True
            Me.LimpiarRemesa()
            CargarPortavalor()
            tsbGrabar.Enabled = intNivel = 2 Or intNivel = 5
            Me.tsbEditar.Enabled = False
            tabRemesas.SelectedIndex = 1
            Me.txtCodigo.Focus()
        End If
    End Sub
    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Try
            Cursor = Cursors.AppStarting
            If Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab1") Then
            ElseIf Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab2") Then
                With dgvListaGenerar
                    intOperacion = Operacion.Modificar
                    blnInicioRemesa = False
                    Me.LimpiarRemesa()
                    Me.cboBanco.SelectedValue = .CurrentRow.Cells("banco").Value
                    Me.cboCuentaCorriente.SelectedValue = .CurrentRow.Cells("cuenta_corriente").Value
                    If IsNothing(Me.cboBanco.SelectedValue) Then Me.cboBanco.SelectedValue = 0
                    If IsNothing(Me.cboCuentaCorriente.SelectedValue) Then Me.cboCuentaCorriente.SelectedValue = 0

                    Me.txtDniPortavalor.Text = IIf(IsDBNull(.CurrentRow.Cells("dni").Value), "", .CurrentRow.Cells("dni").Value)
                    If Not IsDBNull(.CurrentRow.Cells("idportavalor").Value) Then
                        Me.txtDniPortavalor.Tag = IIf(.CurrentRow.Cells("idportavalor").Value = 0, "", (.CurrentRow.Cells("idportavalor").Value))
                    Else
                        Me.txtDniPortavalor.Tag = 0
                    End If
                    Me.txtNombresPortavalor.Text = IIf(IsDBNull(.CurrentRow.Cells("portavalor").Value), "", .CurrentRow.Cells("portavalor").Value)
                    Me.txtCodigoPortavalor.Text = IIf(IsDBNull(.CurrentRow.Cells("codigo").Value), "", .CurrentRow.Cells("codigo").Value)
                    Me.txtNombresPortavalor.Enabled = False
                    Me.txtCodigoPortavalor.Enabled = False

                    Me.txtComprobante.Text = IIf(IsDBNull(.CurrentRow.Cells("comprobante").Value), "", .CurrentRow.Cells("comprobante").Value)
                    Me.txtObservacion.Text = IIf(IsDBNull(.CurrentRow.Cells("observacion").Value), "", .CurrentRow.Cells("observacion").Value)

                    Dim intID As Integer = Me.dgvListaGenerar.CurrentRow.Cells("id").Value
                    ListarBolsa(intID)

                    If blnDisponible Then
                        Me.tsbGrabar.Enabled = True
                        Me.grbDestino.Enabled = True
                        Me.grbPortavalor.Enabled = intPortavalor = 1
                        Me.grbDatos.Enabled = True
                        Me.txtCodigo.Enabled = True
                    Else
                        Me.tsbGrabar.Enabled = False
                        Me.grbDestino.Enabled = False
                        Me.grbPortavalor.Enabled = False
                        Me.grbDatos.Enabled = False
                        Me.txtCodigo.Enabled = False
                        Me.btnRetirar.Enabled = False
                    End If

                    Cursor = Cursors.Default
                    tabRemesas.SelectedIndex = 1
                    Me.tsbEditar.Enabled = False
                    Me.txtCodigo.Focus()
                End With
            ElseIf Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab3") Then
                blnInicioLiquidarRemesa = True
                Limpiar()
                Dim intID As Integer = Me.dgvListaLiquidar.CurrentRow.Cells("id").Value
                With Me.dgvListaLiquidar
                    If .CurrentRow.Cells("id_estado").Value = 0 Then
                        Dim intPortavalor As Integer = dgvListaLiquidar.CurrentRow.Cells("portavalor").Value
                        Dim strEstado As String = dgvListaLiquidar.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1)
                        Dim blnParcial As Boolean = dgvListaLiquidar.CurrentRow.Cells("monto_parcial").Value > 0
                        Me.btnAgregarParcial.Enabled = AdminPortavalorInt()
                        If blnParcial And AdminPortavalorInt() = False And strEstado = "L" Then
                            Me.tsbGrabar.Enabled = False
                        ElseIf blnParcial And AdminPortavalorInt() = False Then
                            Me.tsbGrabar.Enabled = False
                            Me.btnAgregarIncidencia.Enabled = False
                            Me.btnEliminarIncidencia.Enabled = False
                            Me.btnAgregarParcial.Enabled = False
                            Me.btnEliminarParcial.Enabled = False
                        ElseIf AdminPortavalorInt() = False And intPortavalor = 2 And strEstado = "P" Then
                            Me.tsbGrabar.Enabled = False
                        ElseIf strEstado = "L" Then
                            Me.tsbGrabar.Enabled = False
                        Else
                            If AdminPortavalorInt() Then
                                Me.btnAgregarIncidencia.Enabled = False : Me.btnEliminarIncidencia.Enabled = False
                                Me.btnAgregarIncidencia.Visible = False : Me.btnEliminarIncidencia.Visible = False
                            End If
                            Me.tsbGrabar.Enabled = True
                            dgvDetalle.Columns("estado").ReadOnly = False
                        End If
                    Else
                            Me.tsbGrabar.Enabled = False
                            dgvDetalle.Columns("estado").ReadOnly = True
                            Me.btnAgregarIncidencia.Enabled = False
                            Me.btnEliminarIncidencia.Enabled = False
                            Me.btnAgregarParcial.Enabled = False
                            Me.btnEliminarParcial.Enabled = False
                    End If
                End With
                If Me.dgvListaLiquidar.Rows.Count > 0 Then
                    Me.lblFechaLiquidar.Text = Me.dgvListaLiquidar.CurrentRow.Cells("fecha").Value
                    Me.lblAgencia.Text = Me.dgvListaLiquidar.CurrentRow.Cells("agencia").Value
                    Me.lblNumero.Text = Me.dgvListaLiquidar.CurrentRow.Cells("id").Value
                End If

                CargarParcial(intID)
                CargarIncidencia(intID)
                ListarDetalle(intID)

                Cursor = Cursors.Default
                tabRemesasLiquidar.SelectedIndex = 1
                Me.tsbEditar.Enabled = False

            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Editar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab1") Then
            If Val(Me.txtRetiroSolesCierre.Text) + Val(Me.txtRetiroDolarCierre.Text) = 0 Then
                MessageBox.Show("Ingrese monto a Retirar", "Retiro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRetiroSolesCierre.Focus()
                Return
            End If

            Dim strMensaje As String = IIf(Me.dgvComprobanteCierre.Rows.Count = 0, "Retiro", "Pre-cierre")
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de realizar el " & strMensaje & "?", strMensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Cerrar(strMensaje)
            End If
        ElseIf Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab2") Then
            If intPortavalor = 1 Then
                If Me.cboBanco.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione el banco", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboBanco.Focus()
                    Return
                End If

                If Me.cboCuentaCorriente.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione la cuenta corriente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboCuentaCorriente.Focus()
                    Return
                End If
            End If

            If Me.txtDniPortavalor.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese DNI del portavalor", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtDniPortavalor.Focus()
                Return
            End If

            If Me.txtDniPortavalor.Text.Trim.Length <> 8 Then
                MessageBox.Show("Ingrese un DNI válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtDniPortavalor.Focus()
                Return
            End If

            If Me.txtNombresPortavalor.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese nombres del portavalor", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNombresPortavalor.Text = ""
                Me.txtNombresPortavalor.Focus()
                Return
            End If

            If intPortavalor = 1 Then
                If Me.txtCodigoPortavalor.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese código del portavalor", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtCodigoPortavalor.Focus()
                    Return
                End If
            End If

            If Me.dgvBolsa.RowCount = 0 Then
                MessageBox.Show("Ingrese las Bolsas", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtCodigo.Focus()
                Return
            End If
            GrabarGenerar()

            ElseIf Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab3") Then
                If Me.tabRemesasLiquidar.SelectedTab Is Me.tabRemesasLiquidar.TabPages("tabRemesaLiquidar") Then
                    If Validar() Then
                        GrabarLiquidar()
                    End If
                ElseIf Me.tabRemesasLiquidar.SelectedTab Is Me.tabRemesasLiquidar.TabPages("tabIncidenciaLiquidar") Then
                    GrabarEstadoIncidencia()
                End If
            End If
    End Sub
    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        If Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab1") Then
            If Me.tabCabecera.SelectedTab Is Me.tabCabecera.TabPages("tabConsulta") Then
                If Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabRetiro") Then
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show("¿Desea Imprimir ticket del monto retirado?", "Imprimir Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                        'Reimprime ticket con codigo de barras
                        With Me.dgvRetiro
                            Dim strCodigo As String, dblRetiro As Double, intMoneda As Integer
                            Dim xImpresora As Integer
                            xImpresora = fnSeleccionImpresion()
                            intMoneda = IIf(.CurrentRow.Cells("moneda").Value = "SOLES", 1, 2)
                            strCodigo = .CurrentRow.Cells("codigo").Value ' dt.Rows(0).Item("codigo_soles")
                            dblRetiro = .CurrentRow.Cells("monto").Value ' dt.Rows(0).Item("codigo_soles")
                            ImprimirTicket(xImpresora, strCodigo, dblRetiro, intMoneda, 1)
                        End With
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            If Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab1") Then
                If Me.tabCabecera.SelectedTab Is Me.tabCabecera.TabPages("tabConsulta") Then
                    If Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabCierre") Then
                        dlgRespuesta = MessageBox.Show("¿Está seguro de anular el pre-cierre?", "Anular Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                            AnularCierre()
                            ListarCierre()
                            Me.btnConsultarPrecierre.Focus()
                        End If
                    ElseIf Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabRetiro") Then
                        dlgRespuesta = MessageBox.Show("¿Está seguro de anular el retiro?", "Anular Retiro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                            AnularRetiro()
                            Dim obj As New Cls_LiquidacionValor_LN
                            Dim intID As Integer = Me.dgvMovimiento.CurrentRow.Cells("id").Value
                            Dim dt As DataTable = obj.ListarRetiro(intID)
                            Me.dgvRetiro.DataSource = dt
                            Me.btnConsultarPrecierre_Click(Nothing, Nothing)
                            If Me.dgvRetiro.Rows.Count > 0 Then
                                Me.tsbAnular.Enabled = Me.dgvRetiro.CurrentRow.Cells("idestado").Value = 1
                            Else
                                Me.tsbAnular.Enabled = False
                                Me.tsbImprimir.Enabled = False
                            End If
                            Me.btnConsultarPrecierre.Focus()
                        End If
                    End If
                End If
            ElseIf Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab2") Then
                dlgRespuesta = MessageBox.Show("¿Está seguro de anular la Remesa?", "Anular Remesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    AnularRemesa()
                    ListarRemesaGenerar()
                    Me.btnConsultarRemesa.Focus()
                End If
            ElseIf Me.tabLiquidacion.SelectedTab Is Me.tabLiquidacion.TabPages("tab3") Then
                dlgRespuesta = MessageBox.Show("¿Está seguro de anular el Depósito?", "Anular Depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    AnularDeposito()
                    ListarRemesaLiquidar()
                    Me.btnConsultarLiquidar.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Anular Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub
#End Region
#End Region

    Sub FormateardgvConsulta()
        With dgvConsulta
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº de Depósitos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_en_tiempo As New DataGridViewTextBoxColumn
            With col_en_tiempo
                .Name = "en_tiempo" : .DataPropertyName = "en_tiempo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "En Tiempo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_fuera_tiempo As New DataGridViewTextBoxColumn
            With col_fuera_tiempo
                .Name = "fuera_tiempo" : .DataPropertyName = "fuera_tiempo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fuera Tiempo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_eficiencia As New DataGridViewTextBoxColumn
            With col_eficiencia
                .Name = "eficiencia" : .DataPropertyName = "eficiencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "% Eficiencia" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_fecha, col_numero, col_en_tiempo, col_fuera_tiempo, col_eficiencia)
        End With
    End Sub

    Sub LimpiarConsulta()
        Me.dgvConsulta.DataSource = Nothing
        Me.lblNumeroConsulta.Text = "0"
        Me.lblEnTiempoConsulta.Text = "0"
        Me.lblFueraTiempoConsulta.Text = "0"
        Me.lblEficienciaConsulta.Text = "0.00"
    End Sub

    Private Sub dtpFechaConsulta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LimpiarConsulta()
        ListarUsuarioAgencia(Me.dtpInicioConsulta.Value.ToShortDateString, Me.cboAgenciaConsulta.SelectedValue)
    End Sub

    Private Sub cboAgenciaConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgenciaConsulta.SelectedIndexChanged
        LimpiarConsulta()
        ListarUsuarioAgencia(Me.dtpInicioConsulta.Value.ToShortDateString, Me.cboAgenciaConsulta.SelectedValue)
    End Sub

    Sub TotalConsulta()
        Dim dt As DataTable
        Dim intNumero As Integer, intEnTiempo As Integer, intFueraTiempo As Integer, dblEficiencia As Double

        If Me.dgvConsulta.Rows.Count > 0 Then
            dt = Me.dgvConsulta.DataSource
            intNumero = IIf(IsDBNull(dt.Compute("sum(numero)", "")), 0, dt.Compute("sum(numero)", ""))
            intEnTiempo = IIf(IsDBNull(dt.Compute("sum(en_tiempo)", "")), 0, dt.Compute("sum(en_tiempo)", ""))
            intFueraTiempo = IIf(IsDBNull(dt.Compute("sum(fuera_tiempo)", "")), 0, dt.Compute("sum(fuera_tiempo)", ""))
        End If
        Me.lblNumeroConsulta.Text = intNumero
        Me.lblEnTiempoConsulta.Text = intEnTiempo
        Me.lblFueraTiempoConsulta.Text = intFueraTiempo
        dblEficiencia = intEnTiempo / intNumero * 100
        Me.lblEficienciaConsulta.Text = Format(dblEficiencia, "###,###,###0.00")
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable = obj.ListarEficiencia(Me.dtpInicioConsulta.Value.ToShortDateString, Me.dtpFinConsulta.Value.ToShortDateString, _
                                                     Me.cboAgenciaConsulta.SelectedValue, Me.cboUsuarioConsulta.SelectedValue, Me.cboOperacionConsulta.SelectedIndex)
            With Me.dgvConsulta
                .DataSource = dt
            End With
            TotalConsulta()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboOperacionConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOperacionConsulta.SelectedIndexChanged
        LimpiarConsulta()
        ListarAgenciaOperacion()
    End Sub

    Private Sub cboUsuarioConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuarioConsulta.SelectedIndexChanged
        LimpiarConsulta()
    End Sub

    Sub AgregarParcial(ByVal frm As frmLiquidacionParcial, ByVal nuevo As Boolean, Optional ByVal fila As Integer = -1)
        ObjParcial = Nothing
        ObjParcial = New dtoParcial
        ObjParcial.IdRemesa = Me.dgvDetalle.CurrentRow.Cells("id").Value
        ObjParcial.IdRemesaDet = Me.dgvDetalle.CurrentRow.Cells("id_det").Value
        If nuevo Then
            ObjParcial.Id = 0
        Else
            ObjParcial.Id = Me.dgvParcial.CurrentRow.Cells("id").Value
        End If
        ObjParcial.IDBanco = frm.cboBanco.SelectedValue
        ObjParcial.IDCuentaCorriente = frm.cboCuentaCorriente.SelectedValue
        ObjParcial.Banco = frm.cboBanco.Text
        ObjParcial.CuentaCorriente = frm.cboCuentaCorriente.Text
        ObjParcial.Fecha = frm.dtpFecha.Value.ToShortDateString
        ObjParcial.Numero = frm.txtNumero.Text
        ObjParcial.Monto = CType(frm.txtMonto.Text, Double)
        ObjParcial.Observacion = frm.txtObservacion.Text.Trim
        If nuevo Then
            ObjParcial.Fila = aParcial.Count
            aParcial.Add(ObjParcial)
        End If

        If Not nuevo Then
            With Me.dgvParcial.CurrentRow
                Dim intPosicion As Integer = 0
                Dim obj As dtoParcial
                For Each obj In aParcial
                    If obj.IdRemesaDet = .Cells("id_remesa_det").Value And obj.Fila = fila Then 'obj.IdIncidencia = .Cells("id_incidencia").Value Then
                        aParcial(intPosicion).idbanco = frm.cboBanco.SelectedValue
                        aParcial(intPosicion).idcuentacorriente = frm.cboCuentaCorriente.SelectedValue
                        aParcial(intPosicion).banco = frm.cboBanco.Text
                        aParcial(intPosicion).cuentacorriente = frm.cboCuentaCorriente.Text
                        aParcial(intPosicion).fecha = frm.dtpFecha.Value.ToShortDateString
                        aParcial(intPosicion).numero = frm.txtNumero.Text
                        aParcial(intPosicion).monto = CType(frm.txtMonto.Text, Double)
                        aParcial(intPosicion).observacion = frm.txtObservacion.Text.Trim
                        Return
                    End If
                    intPosicion += 1
                Next
            End With
        End If
    End Sub
    Sub MostrarParcial(ByVal remesa As Integer)
        Dim intFila As Integer
        Dim intIdRemesaDet As Integer = remesa
        Dim obj As dtoParcial
        dgvParcial.Rows.Clear()
        For Each obj In aParcial
            With Me.dgvParcial
                If obj.IdRemesaDet = intIdRemesaDet Then
                    .Rows.Add()
                    intFila = .Rows.Count - 1
                    .Rows(intFila).Cells("id_remesa").Value = obj.IdRemesa
                    .Rows(intFila).Cells("id_remesa_det").Value = obj.IdRemesaDet
                    .Rows(intFila).Cells("id").Value = obj.Id
                    .Rows(intFila).Cells("fecha").Value = obj.Fecha
                    .Rows(intFila).Cells("numero").Value = obj.Numero
                    .Rows(intFila).Cells("monto").Value = obj.Monto
                    .Rows(intFila).Cells("banco").Value = obj.Banco
                    .Rows(intFila).Cells("cuenta_corriente").Value = obj.CuentaCorriente
                    .Rows(intFila).Cells("idbanco").Value = obj.IDBanco
                    .Rows(intFila).Cells("idcuenta_corriente").Value = obj.IDCuentaCorriente
                    .Rows(intFila).Cells("observacion").Value = obj.Observacion
                End If
            End With
        Next
        Me.btnEliminarParcial.Enabled = Me.dgvParcial.Rows.Count > 0 And Me.tsbGrabar.Enabled
    End Sub
    Sub EliminarParcial(ByVal remesadet As Integer, ByVal fila As Integer)
        Dim intPosicion As Integer = 0
        Dim obj As dtoParcial
        For Each obj In aParcial
            If obj.IdRemesaDet = remesadet And obj.Fila = fila Then 'obj.IdIncidencia = incidencia Then
                aParcial.RemoveAt(intPosicion)
                ActualizarFilaDepositoParcial()
                Exit For
            End If
            intPosicion += 1
        Next
        Me.btnAgregarParcial.Enabled = True
        Me.btnAgregarIncidencia.Enabled = True
    End Sub
    Private Sub btnAgregarParcial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarParcial.Click
        Dim dblMontoTotal As Double, dblMontoDepositado As Double, dblMonto As Double, dblMontoParcial As Double
        Dim frm As New frmLiquidacionParcial
        frm.Nuevo = True
        dblMonto = TotalGrid(Me.dgvIncidencia, "monto")
        dblMontoTotal = Me.dgvDetalle.CurrentRow.Cells("monto").Value ' - dblMonto
        dblMontoDepositado = TotalGrid(Me.dgvParcial, "monto")
        frm.MontoTotal = dblMontoTotal
        frm.MontoDepositado = dblMontoDepositado
        frm.MontoDepositadoTmp = dblMontoDepositado
        frm.intTipoMoneda = IIf(Me.dgvDetalle.CurrentRow.Cells("moneda").Value.ToString.Substring(0, 1) = "S", 1, 2)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            dblMontoParcial = TotalGrid(Me.dgvParcial, "monto") 'monto parcial
            dblMontoParcial += CType(frm.txtMonto.Text, Double)
            'Valida si monto depositado es menor a monto con incidencia
            If Me.dgvIncidencia.Rows.Count > 0 Then
                Dim dblMontoIncidencia As Double
                dblMontoIncidencia = dblMonto
                If dblMontoIncidencia > dblMontoParcial Then
                    MessageBox.Show("El Monto Depositado no debe ser menor al Monto con Incidencia", "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnAgregarParcial.Focus()
                    Return
                End If
            End If
            AgregarParcial(frm, True)
            MostrarParcial(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
            Me.btnAgregarParcial.Enabled = Math.Round(dblMontoTotal, 2) > Math.Round(dblMontoParcial, 2)
            Me.dgvDetalle.CurrentRow.Cells("estado").Value = Math.Round(dblMontoParcial, 2) >= Math.Round(dblMontoTotal, 2)
            Me.dgvDetalle.RefreshEdit()
        End If
    End Sub

    Private Sub dgvParcial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvParcial.DoubleClick
        If Me.dgvParcial.Rows.Count > 0 Then
            Dim dblMontoTotal As Double, dblMontoDepositado As Double, dblMontoDepositadoTmp As Double, dblMonto As Double
            Dim frm As New frmLiquidacionParcial
            frm.Nuevo = False
            frm.Fecha = Me.dgvParcial.CurrentRow.Cells("fecha").Value
            frm.Numero = Me.dgvParcial.CurrentRow.Cells("numero").Value

            dblMonto = TotalGrid(Me.dgvIncidencia, "monto")
            dblMontoTotal = Me.dgvDetalle.CurrentRow.Cells("monto").Value '- dblMonto
            dblMontoDepositado = TotalGrid(Me.dgvParcial, "monto")
            dblMontoDepositadoTmp = TotalGrid(Me.dgvParcial, "monto", Me.dgvParcial.CurrentCell.RowIndex)
            frm.MontoTotal = dblMontoTotal
            frm.MontoDepositado = dblMontoDepositado
            frm.MontoDepositadoTmp = dblMontoDepositadoTmp
            frm.Monto = Me.dgvParcial.CurrentRow.Cells("monto").Value
            frm.Observacion = Me.dgvParcial.CurrentRow.Cells("observacion").Value
            frm.Editable = Me.tsbGrabar.Enabled
            frm.intTipoMoneda = IIf(Me.dgvDetalle.CurrentRow.Cells("moneda").Value.ToString.Substring(0, 1) = "S", 1, 2)
            frm.Banco = Me.dgvParcial.CurrentRow.Cells("idbanco").Value
            frm.CuentaCorriente = Me.dgvParcial.CurrentRow.Cells("idcuenta_corriente").Value
            If Not AdminPortavalorInt() Then
                'frm.cboBanco.Enabled = False
                'frm.cboCuentaCorriente.Enabled = False
                'frm.dtpFecha.Enabled = False
                'frm.txtNumero.Enabled = False
                frm.txtMonto.Enabled = False
                frm.txtObservacion.Enabled = False
                'frm.btnAceptar.Enabled = False
            End If
            If Me.tsbGrabar.Enabled = False Then
                frm.cboBanco.Enabled = False
                frm.cboCuentaCorriente.Enabled = False
            End If
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                'Valida si monto depositado es menor a monto con incidencia
                If Me.dgvIncidencia.Rows.Count > 0 Then
                    Dim dblMontoIncidencia As Double
                    dblMontoIncidencia = dblMonto
                    dblMonto = TotalGrid(Me.dgvParcial, "monto", Me.dgvParcial.CurrentCell.RowIndex) 'monto parcial
                    dblMonto += CType(frm.txtMonto.Text, Double)
                    If dblMontoIncidencia > dblMonto Then
                        MessageBox.Show("El Monto Depositado no debe ser menor al Monto con Incidencia", "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.btnAgregarParcial.Focus()
                        Return
                    End If
                End If
                AgregarParcial(frm, False, Me.dgvParcial.CurrentCell.RowIndex)
                MostrarParcial(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
                dblMonto = TotalGrid(Me.dgvParcial, "monto")
                Me.btnAgregarParcial.Enabled = Math.Round(dblMontoTotal, 2) > Math.Round(dblMonto, 2)
                Me.dgvDetalle.CurrentRow.Cells("estado").Value = Math.Round(dblMonto, 2) >= Math.Round(dblMontoTotal, 2)
                Me.dgvDetalle.RefreshEdit()
            End If
        End If
    End Sub

    Private Sub btnEliminarParcial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarParcial.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar el Depósito Parcial?", "Eliminar Depósito Parcial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                'Valida si monto depositado es menor a monto con incidencia
                If Me.dgvIncidencia.Rows.Count > 0 And Me.dgvParcial.Rows.Count > 1 Then
                    Dim dblMontoIncidencia As Double = TotalGrid(Me.dgvIncidencia, "monto")
                    Dim dblMontoParcial As Double = TotalGrid(Me.dgvParcial, "monto")
                    Dim dblMonto As Double = Me.dgvParcial.CurrentRow.Cells("monto").Value
                    If dblMontoIncidencia > (dblMontoParcial - dblMonto) Then
                        MessageBox.Show("El Monto Depositado no debe ser menor al Monto con Incidencia", "Liquidar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.btnEliminarParcial.Focus()
                        Return
                    End If
                End If
                EliminarParcial(Me.dgvParcial.CurrentRow.Cells("id_remesa_det").Value, Me.dgvParcial.CurrentCell.RowIndex)
                MostrarParcial(Me.dgvDetalle.CurrentRow.Cells("id_det").Value)
                If Me.dgvParcial.Rows.Count = 0 Then
                    Me.dgvDetalle.CurrentRow.Cells("estado").Value = Me.dgvIncidencia.Rows.Count > 0
                    Me.dgvDetalle.RefreshEdit()
                Else
                    Me.dgvDetalle.CurrentRow.Cells("estado").Value = 0
                    Me.dgvDetalle.RefreshEdit()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Eliminar Depósito Parcial", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvIncidencia_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIncidencia.CellContentClick

    End Sub

    Private Sub dgvIncidencia_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvIncidencia.SizeChanged

    End Sub

    Private Sub frmLiquidacionValores_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.dgvParcial.Visible = False Then
            Me.dgvIncidencia.Width = Me.Width - 80
        End If
    End Sub

    Private Sub GrabarRemesa(ByVal p1 As Integer, ByVal dblRetiroSoles As Double)
        Throw New NotImplementedException
    End Sub

    Private Sub dtpFechaCierre_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaCierre.ValueChanged
        Me.dgvComprobanteCierre.Rows.Clear()
        Me.txtRetiroSolesCierre.Text = "0.00"
        Me.txtRetiroDolarCierre.Text = "0.00"
        Me.btnRetiroSolesCierre.Enabled = False
        Me.btnRetiroDolarCierre.Enabled = False
        Me.lblTotalEfectivoCierre.Text = "0.00"
        If intPortavalor = 2 Then
            Me.dtpFechaCierre.Enabled = True
            Me.txtRetiroSolesCierre.Enabled = False
            Me.txtRetiroDolarCierre.Enabled = False

            'Desactiva grabar y cerrar si existe remesa para fecha y oficina
            Dim blnActivo As Boolean = True
            Dim obj As New Cls_LiquidacionValor_LN
            blnActivo = obj.ExisteRemesa(Me.dtpFechaCierre.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, 1)
            Me.tsbGrabar.Enabled = Not blnActivo
            Me.btnActualizarCierre.Enabled = Not blnActivo
        Else
            Me.dtpFechaCierre.Enabled = True
            Me.tsbGrabar.Enabled = True
            Me.btnActualizarCierre.Enabled = True
        End If
    End Sub

    Sub FormateardgvDeposito()
        With dgvDeposito
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto_total As New DataGridViewTextBoxColumn
            With col_monto_total
                .Name = "monto_total" : .DataPropertyName = "monto_total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_fecha, col_agencia, col_usuario, col_monto_total, col_monto, col_estado)
        End With
    End Sub

    Sub FormateardgvConsultaIncidencia()
        With dgvConsultaIncidencia
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .RowHeadersWidth = 22
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "Nº Remesa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_det"
            End With

            x += +1
            Dim col_id_preliqdet As New DataGridViewTextBoxColumn
            With col_id_preliqdet
                .Name = "id_preliqdet" : .DataPropertyName = "id_preliqdet" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliqdet"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_monto_depositado As New DataGridViewTextBoxColumn
            With col_monto_depositado
                .Name = "monto_depositado" : .DataPropertyName = "monto_depositado" : .ReadOnly = True
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Depositado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_monto_pendiente As New DataGridViewTextBoxColumn
            With col_monto_pendiente
                .Name = "saldo" : .DataPropertyName = "saldo" : .ReadOnly = True
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Pendiente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_id_incidencia As New DataGridViewTextBoxColumn
            With col_id_incidencia
                .Name = "id_incidencia" : .DataPropertyName = "id_incidencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_incidencia"
            End With

            x += +1
            Dim col_incidencia As New DataGridViewTextBoxColumn
            With col_incidencia
                .Name = "incidencia" : .DataPropertyName = "incidencia" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto_incidencia As New DataGridViewTextBoxColumn
            With col_monto_incidencia
                .Name = "monto_incidencia" : .DataPropertyName = "monto_incidencia" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Incidencia" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With

            x += +1
            Dim col_fecha_operacion As New DataGridViewTextBoxColumn
            With col_fecha_operacion
                .Name = "fecha_operacion" : .DataPropertyName = "fecha_operacion" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_numero_operacion As New DataGridViewTextBoxColumn
            With col_numero_operacion
                .Name = "numero_operacion" : .DataPropertyName = "numero_operacion" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_banco As New DataGridViewTextBoxColumn
            With col_banco
                .Name = "banco" : .DataPropertyName = "banco" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Banco"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente" : .ReadOnly = True
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Cuenta Corriente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_id_det, col_id_preliqdet, col_fecha, col_agencia, col_usuario, col_codigo, _
                              col_moneda, col_monto, col_monto_depositado, col_monto_pendiente, col_id_incidencia, col_incidencia, col_monto_incidencia, _
                              col_estado, col_idestado, col_fecha_operacion, col_numero_operacion, col_banco, col_cuenta_corriente)
        End With
    End Sub
    Private Sub btnConsultarDeposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarDeposito.Click
        Try
            Cursor = Cursors.AppStarting
            Dim intEstado As Integer = Me.cboEstadoDeposito.SelectedIndex
            Dim dbl1 As Double = 0, dbl2 As Double = 0, dbl3 As Double = 0, dbl4 As Double = 0, dbl5 As Double = 0
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable = obj.ListarDeposito(Me.dtpInicioDeposito.Value.ToShortDateString, Me.dtpFinDeposito.Value.ToShortDateString, _
                                                     Me.cboAgenciaDeposito.SelectedValue, intEstado, dtoUSUARIOS.IP)
            With Me.dgvDeposito
                .DataSource = dt
            End With

            Dim dt2 As DataTable = obj.TotalDeposito(dtoUSUARIOS.IP)
            If dt2.Rows.Count > 0 Then
                dbl1 = dt2.Rows(0).Item("monto")
                dbl2 = IIf(IsDBNull(dt.Compute("sum(monto)", "estado='PENDIENTE'")), 0, dt.Compute("sum(monto)", "estado='PENDIENTE'"))
                dbl3 = IIf(IsDBNull(dt.Compute("sum(monto)", "estado='DEPOSITADO'")), 0, dt.Compute("sum(monto)", "estado='DEPOSITADO'"))
                dbl4 = IIf(IsDBNull(dt.Compute("sum(monto)", "estado='PARCIAL'")), 0, dt.Compute("sum(monto)", "estado='PARCIAL'"))
                dbl5 = IIf(IsDBNull(dt.Compute("sum(monto)", "estado='LIQUIDADO'")), 0, dt.Compute("sum(monto)", "estado='LIQUIDADO'"))
            End If
            Me.lblm1.Text = Format(dbl1, "###,###,###0.00")
            Me.lblm2.Text = Format(dbl2, "###,###,###0.00")
            Me.lblm3.Text = Format(dbl3, "###,###,###0.00")
            Me.lblm4.Text = Format(dbl4, "###,###,###0.00")
            Me.lblm5.Text = Format(dbl5, "###,###,###0.00")

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dtpInicioIncidenciaConsulta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicioIncidenciaConsulta.ValueChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidenciaConsulta)
    End Sub

    Private Sub cboIncidencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIncidencia.SelectedIndexChanged

    End Sub

    Private Sub cboUsuarioIncidencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuarioIncidencia.SelectedIndexChanged

    End Sub

    Private Sub dtpFinIncidenciaConsulta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFinIncidenciaConsulta.ValueChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidenciaConsulta)
    End Sub

    Private Sub cboAgenciaIncidenciaConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgenciaIncidenciaConsulta.SelectedIndexChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidenciaConsulta)
    End Sub

    Private Sub cboEstadoIncidenciaConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoIncidenciaConsulta.SelectedIndexChanged
        ListarUsuarioIncidencia(Me.cboUsuarioIncidenciaConsulta)
    End Sub

    Private Sub btnConsultaIncidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaIncidencia.Click
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable
            dt = obj.ListarIncidencia(Me.dtpInicioIncidenciaConsulta.Value.ToShortDateString, Me.dtpFinIncidenciaConsulta.Value.ToShortDateString, _
                                      Me.cboAgenciaConsulta.SelectedValue, Me.cboUsuarioIncidenciaConsulta.SelectedValue, Me.cboEstadoIncidenciaConsulta.SelectedIndex, Me.cboIncidenciaConsulta.SelectedValue)
            dgvConsultaIncidencia.DataSource = dt
            If dt.Rows.Count > 0 Then
                Dim dblMonto As Double = IIf(IsDBNull(dt.Compute("sum(monto)", "")), 0, dt.Compute("sum(monto)", ""))
                Me.lblMontoIncidencia.Text = Format(dblMonto, "###,###,###0.00")
            Else
                Me.lblMontoIncidencia.Text = "0.00"
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Incidencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvListaLiquidar_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaLiquidar.RowEnter
        If AdminPortavalorInt() Then
            If Me.dgvListaLiquidar.Rows(e.RowIndex).Cells("estado").Value.ToString.Substring(0, 1) = "D" Then
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbAnular.Enabled = False
            End If
        End If
    End Sub

    Sub AnularDeposito()
        Dim intID As Integer = Me.dgvListaLiquidar.CurrentRow.Cells("id").Value
        Dim strFecha As String = Me.dgvListaLiquidar.CurrentRow.Cells("fecha").Value
        Dim intAgencia As Integer = Me.dgvListaLiquidar.CurrentRow.Cells("id_agencia").Value
        Dim obj As New Cls_LiquidacionValor_LN
        obj.AnularDeposito(strFecha, intAgencia, intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        ListarAgenciaSeguimiento()
    End Sub

    Private Sub dgvBolsa_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBolsa.CellContentClick

    End Sub

    Private Sub dgvParcial_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvParcial.CellContentClick

    End Sub
End Class