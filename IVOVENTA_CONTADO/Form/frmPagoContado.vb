Imports INTEGRACION_LN
Public Class frmPagoContado
    Dim blnSalir As Boolean
    Dim blnEdita As Boolean = False
    Dim blnCompleto As Boolean = False
    Dim blnEditar As Boolean = True
    Dim intTiempo As Integer = 0
    Dim intColumna As Integer = 0, intFila As Integer = 0
    Dim intRow As Integer = 0
    Dim toolTip As New ToolTip()
    Dim dblTipoCambio As Double = 0
    Public intCuentaCorriente As Integer = 1

#Region "Propiedades"
    Private strNumero As String
    Public Property Numero() As String
        Get
            Return strNumero
        End Get
        Set(ByVal value As String)
            strNumero = value
        End Set
    End Property

    Private strCliente As String
    Public Property Cliente() As String
        Get
            Return strCliente
        End Get
        Set(ByVal value As String)
            strCliente = value
        End Set
    End Property


    Private dblTotalVenta As Double
    Public Property TotalVenta() As Double
        Get
            Return dblTotalVenta
        End Get
        Set(ByVal value As Double)
            dblTotalVenta = value
        End Set
    End Property

#End Region

    Sub FormatearDgvPago()
        With dgvPago
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.RowTemplate.Height = 30
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersVisible = False

            Dim obj As New dtoVentaCargaContado

            Dim x As Integer = 0
            Dim col_tipo_pago As New DataGridViewComboBoxColumn
            With col_tipo_pago
                .Name = "tipo_pago" : .DataPropertyName = "tipo_pago"
                .DisplayIndex = x : .HeaderText = "Tipo Pago" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DisplayStyleForCurrentCellOnly = True

                .DataSource = obj.ListarTipoPago
                .DisplayMember = "tipo_pago"
                .ValueMember = "id"
            End With

            x += +1
            Dim col_tipo_tarjeta As New DataGridViewComboBoxColumn
            With col_tipo_tarjeta
                .Name = "tipo_tarjeta" : .DataPropertyName = "tipo_tarjeta"
                .DisplayIndex = x : .HeaderText = "T. Tarjeta" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DisplayStyleForCurrentCellOnly = True
                .ReadOnly = True
                '.DataSource = obj.ListarTipoTarjeta
                '.DisplayMember = "tipo_tarjeta"
                '.ValueMember = "id"
            End With

            x += +1
            Dim col_tarjeta As New DataGridViewComboBoxColumn
            With col_tarjeta
                .Name = "tarjeta" : .DataPropertyName = "tarjeta"
                .DisplayIndex = x : .HeaderText = "Tarjeta" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DisplayStyleForCurrentCellOnly = True
                .ReadOnly = True
                '.DataSource = obj.ListarTipoTarjeta
                '.DisplayMember = "tipo_tarjeta"
                '.ValueMember = "id"
            End With

            x += +1
            Dim col_soles As New DataGridViewTextBoxColumn
            With col_soles
                .Name = "soles" : .DataPropertyName = "soles"
                .DisplayIndex = x : .HeaderText = "Soles" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With

            x += +1
            Dim col_dolares As New DataGridViewTextBoxColumn
            With col_dolares
                .Name = "dolares" : .DataPropertyName = "dolares"
                .DisplayIndex = x : .HeaderText = "Dólares" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With

            x += +1
            Dim col_tc As New DataGridViewTextBoxColumn
            With col_tc
                .Name = "tc" : .DataPropertyName = "tc"
                .DisplayIndex = x : .HeaderText = "T. Cambio" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,###,###,###0.00" : .ReadOnly = dtoUSUARIOS.iIDAGENCIAS = 51
            End With

            x += +1
            Dim col_afecto As New DataGridViewTextBoxColumn
            With col_afecto
                .Name = "afecto" : .DataPropertyName = "afecto"
                .DisplayIndex = x : .HeaderText = "Afecto" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,###,###,###0.00" : .ReadOnly = True
                .DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel)
                .DefaultCellStyle.NullValue = ""
            End With

            x += +1
            Dim col_pago As New DataGridViewTextBoxColumn
            With col_pago
                .Name = "pago" : .DataPropertyName = "pago"
                .DisplayIndex = x : .HeaderText = "Pago" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,###,###,###0.00" : .ReadOnly = True
                .DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel)
                .DefaultCellStyle.NullValue = ""
            End With


            .Columns.AddRange(col_tipo_pago, col_tipo_tarjeta, col_tarjeta, col_soles, col_dolares, col_tc, col_afecto, col_pago)
        End With
    End Sub

    Private Sub frmPagoContado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If blnCompleto Then
            Me.btnAceptar.Focus()
        Else
            Me.dgvPago.Focus()
        End If
    End Sub
    Private Sub frmPagoContado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmPagoContado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        Dim strFecha As String = FechaServidor()
        If dtoUSUARIOS.iIDAGENCIAS = 51 Then
            dblTipoCambio = Cls_LiquidacionValor_LN.ObtieneTipoCambio(CDate(strFecha).ToShortDateString)
            Dim strCadena As String = "Tipo Cambio : " & Format(dblTipoCambio, "0.00")
            Me.Text = Me.Text & strCadena.PadLeft(110, " ")
        Else
            dblTipoCambio = 0
        End If

        FormatearDgvPago()

        toolTip.SetToolTip(Me.btnActualizarCtaCte, "Actualizar Cuenta Corriente")

        'Numero = "12345678"
        'Cliente = "PRUEBA"
        'TotalVenta = 17

        Me.lblCliente.Text = Numero & "  " & Cliente
        Me.lblTotalVenta.Text = TotalVenta.ToString("###,###,###0.00")

        If intCuentaCorriente = 1 Then
            Dim dblSaldo As Double = ObtieneSaldoCuentaCorriente(Numero)
            Me.lblSaldo.Text = dblSaldo.ToString("###,###,###0.00")
            If dblSaldo = 0 Then
                AgregarItem()
                Me.btnActualizarCtaCte.Enabled = False
            Else
                AgregarItem(3, , dblSaldo)
                Me.btnActualizarCtaCte.Enabled = True
            End If
        Else
            AgregarItem()
            Me.btnActualizarCtaCte.Enabled = False
        End If

        CalculaTotal()
    End Sub

    Function ObtieneSaldoCuentaCorriente(ByVal numero As String) As Double
        Dim obj As New Cls_NotaCredito_LN
        Return obj.ObtieneSaldoCuentaCorriente(numero)
    End Function

    Private Sub dgvPago_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPago.CellBeginEdit
        blnEdita = True
        intRow = Me.dgvPago.CurrentCell.RowIndex
    End Sub

    Function Pagado() As Boolean
        Dim dblVenta As Double, dblPago As Double
        dblVenta = IIf(Val(Me.lblTotalVenta.Text) = 0, 0, Me.lblTotalVenta.Text)
        dblPago = IIf(Val(Me.lblTotalPago.Text) = 0, 0, Me.lblTotalPago.Text)
        Return dblPago >= dblVenta
    End Function

    Private Sub dgvPago_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPago.CurrentCellDirtyStateChanged
        'If dgvPago.IsCurrentCellDirty Then
        dgvPago.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True
        'Dim c As Control = dgvPago.EditingControl
        'Dim blnCombo As Boolean = False

        'If TypeOf c Is ComboBox Then
        '    Dim cbo As ComboBox = CType(c, ComboBox)
        '    blnCombo = True
        'End If

        If msg.WParam.ToInt32 = Keys.Enter And (Me.dgvPago.Focused Or blnEdita) Then
            If dgvPago.CurrentCell.RowIndex = dgvPago.Rows.Count - 1 And dgvPago.CurrentCell.ColumnIndex = dgvPago.Columns.Count - 1 And Me.btnAgregar.Enabled Then
                If blnEdita = False Then
                    'SendKeys.Send(vbTab)
                    AgregarItem(, True)
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
                'ElseIf Pagado() Then
                'btnAceptar.Focus()
            Else
                SendKeys.Send(vbTab)
                'flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        ElseIf (msg.WParam.ToInt32 = Keys.Insert Or (msg.WParam.ToInt32 = Keys.Down And Me.btnAgregar.Enabled And dgvPago.CurrentCell.RowIndex = dgvPago.Rows.Count - 1)) Then
            AgregarItem(, True)
        ElseIf msg.WParam.ToInt32 = Keys.Up And dgvPago.CurrentCell.RowIndex = dgvPago.Rows.Count - 1 And RegistroCompleto(dgvPago.Rows.Count - 1) = False And Me.dgvPago.Focused And Me.dgvPago.Rows.Count > 1 Then
            EliminarItem(dgvPago.Rows.Count - 1)
        ElseIf msg.WParam.ToInt32 = Keys.Delete And Me.dgvPago.Focused And Me.btnEliminar.Enabled Then
            btnEliminar_Click(Nothing, Nothing)
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function

    Private Sub dgvPago_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPago.EditingControlShowing
        Try
            If TypeOf e.Control Is ComboBox Then
                Dim combo As ComboBox = CType(e.Control, ComboBox)
                If (combo IsNot Nothing) Then
                    RemoveHandler combo.SelectedIndexChanged, New EventHandler(AddressOf SelectedValueChanged)
                    AddHandler combo.SelectedIndexChanged, New EventHandler(AddressOf SelectedValueChanged)
                End If
            ElseIf TypeOf e.Control Is TextBox Then
                Dim validar As TextBox = CType(e.Control, TextBox)
                AddHandler validar.KeyPress, AddressOf Validar_KeyPress
            End If
        Catch
        End Try
    End Sub

    Sub Validar_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim intColumna As Integer = Me.dgvPago.CurrentCell.ColumnIndex
        Dim chrCaracter As Char = e.KeyChar

        If intColumna >= 3 Then
            Dim txt As TextBox = CType(sender, TextBox)
            If Not ValidarNumeroReal(chrCaracter, txt.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Sub ActivarDesactivar(ByVal estado As Boolean, Optional ByVal limpiar As Boolean = False, Optional ByVal primero As Boolean = False)
        If primero Then
            TryCast(dgvPago("tipo_pago", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell).ReadOnly = estado
        End If
        TryCast(dgvPago("tipo_tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell).ReadOnly = estado
        TryCast(dgvPago("tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell).ReadOnly = estado
        TryCast(dgvPago("soles", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).ReadOnly = estado
        TryCast(dgvPago("dolares", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).ReadOnly = estado
        TryCast(dgvPago("tc", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).ReadOnly = estado
        'TryCast(dgvPago("afecto", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).ReadOnly = estado
        If limpiar Then
            TryCast(dgvPago("tipo_tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell).Value = Nothing
            TryCast(dgvPago("tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell).Value = Nothing
            TryCast(dgvPago("soles", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).Value = ""
            TryCast(dgvPago("dolares", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).Value = ""
            TryCast(dgvPago("tc", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).Value = ""
            TryCast(dgvPago("afecto", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).Value = ""
            TryCast(dgvPago("pago", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell).Value = ""
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregarItem(, False)
    End Sub

    Function RegistroCompleto(ByVal fila As Integer) As Boolean
        Dim colAfecto As DataGridViewTextBoxCell
        Dim colTipoPago As DataGridViewComboBoxCell, colTipoTarjeta As DataGridViewComboBoxCell, colTarjeta As DataGridViewComboBoxCell

        With Me.dgvPago
            colAfecto = TryCast(dgvPago("afecto", fila), DataGridViewTextBoxCell)
            colTipoPago = TryCast(dgvPago("tipo_pago", fila), DataGridViewComboBoxCell)
            colTipoTarjeta = TryCast(dgvPago("tipo_tarjeta", fila), DataGridViewComboBoxCell)
            colTarjeta = TryCast(dgvPago("tarjeta", fila), DataGridViewComboBoxCell)
            If Val(colAfecto.Value) = 0 Then 'fila no tiene monto afecto
                Return False
            Else
                If colTipoPago.Value = 2 Then
                    If colTipoTarjeta.Value = 0 Then
                        Return False
                    End If
                    If colTarjeta.Value = 0 Then
                        Return False
                    End If
                End If
            End If
        End With
        Return True
    End Function

    Function ValidaFila(Optional ByVal sinMensaje As Boolean = False) As Boolean
        Dim colAfecto As DataGridViewTextBoxCell, colSoles As DataGridViewTextBoxCell, colDolares As DataGridViewTextBoxCell, colTC As DataGridViewTextBoxCell
        Dim colTipoPago As DataGridViewComboBoxCell, colTipoTarjeta As DataGridViewComboBoxCell, colTarjeta As DataGridViewComboBoxCell

        With Me.dgvPago
            For Each row As DataGridViewRow In .Rows
                colAfecto = TryCast(dgvPago("afecto", row.Index), DataGridViewTextBoxCell)
                colTipoPago = TryCast(dgvPago("tipo_pago", row.Index), DataGridViewComboBoxCell)
                colTipoTarjeta = TryCast(dgvPago("tipo_tarjeta", row.Index), DataGridViewComboBoxCell)
                colTarjeta = TryCast(dgvPago("tarjeta", row.Index), DataGridViewComboBoxCell)
                colSoles = TryCast(dgvPago("soles", row.Index), DataGridViewTextBoxCell)
                colDolares = TryCast(dgvPago("dolares", row.Index), DataGridViewTextBoxCell)
                colTC = TryCast(dgvPago("tc", row.Index), DataGridViewTextBoxCell)

                If Val(colAfecto.Value) = 0 Then 'fila no tiene monto afecto
                    If colTipoPago.Value = 1 Or colTipoPago.Value = 2 Then 'efectivo
                        If colTipoPago.Value = 2 Then
                            If colTipoTarjeta.Value = 0 Then
                                If Not sinMensaje Then
                                    MessageBox.Show("Seleccione Tipo de Tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    .CurrentCell = row.Cells("tipo_tarjeta")
                                End If
                                Return False
                            End If
                            If colTarjeta.Value = 0 Then
                                If Not sinMensaje Then
                                    MessageBox.Show("Seleccione la Tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    .CurrentCell = row.Cells("tarjeta")
                                End If
                                Return False
                            End If
                        End If
                        If Val(colSoles.Value) = 0 And Val(colDolares.Value) = 0 And Val(colTC.Value) = 0 Then
                            If Not sinMensaje Then
                                MessageBox.Show("Ingrese el Monto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                .CurrentCell = row.Cells("soles")
                            End If
                        ElseIf Val(colSoles.Value) = 0 And Val(colDolares.Value) > 0 Then
                            If Not sinMensaje Then
                                MessageBox.Show("Ingrese el Monto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            .CurrentCell = row.Cells("tc")
                        ElseIf Val(colSoles.Value) = 0 And Val(colDolares.Value) = 0 And Val(colTC.Value) > 0 Then
                            If Not sinMensaje Then
                                MessageBox.Show("Ingrese el Monto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                .CurrentCell = row.Cells("dolares")
                            End If
                        End If
                    End If
                    '.BeginEdit(True)
                    Return False
                Else
                    If colTipoPago.Value = 2 Then
                        If colTipoTarjeta.Value = 0 Then
                            If Not sinMensaje Then
                                MessageBox.Show("Seleccione Tipo de Tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                .CurrentCell = row.Cells("tipo_tarjeta")
                            End If
                            Return False
                        End If
                        If colTarjeta.Value = 0 Then
                            If Not sinMensaje Then
                                MessageBox.Show("Seleccione la Tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                .CurrentCell = row.Cells("tarjeta")
                            End If
                            Return False
                        End If
                    End If

                    If Val(Me.lblSaldo.Text) > 0 Then 'tiene saldo cuenta corriente y solo puede emitir nc y cortesia
                        If Not (TienePago(6) Or TienePago(5)) Then
                            If Not sinMensaje Then
                                MessageBox.Show("El cliente tiene saldo en su Cuenta Corriente" & Chr(13) & "Sólo puede pagar con Nota Crédito o Cortesia" _
                                                , "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.btnActualizarCtaCte_Click(Nothing, Nothing)
                            End If
                            Return False
                        End If
                    End If
                End If
            Next
        End With
        Return True
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvPago.Rows.Count > 0 Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar el Pago?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                EliminarItem(dgvPago.CurrentCell.RowIndex)

                'Recalcula cuando hay pago efectivo y el total del pago es mayor al de la venta
                Dim dblMontoNoEfectivo As Double, dblAfecto As Double, blnEfectivo As Boolean
                Dim intFila As Integer
                ObtieneTotalNoEfectivo(dblMontoNoEfectivo, dblAfecto, intFila, blnEfectivo)
                'If (dblMontoNoEfectivo + dblTotal > dblTotalVenta) Then
                If dblAfecto > dblTotalVenta And blnEfectivo Then
                    If dblTotalVenta - dblMontoNoEfectivo > 0 Then
                        dgvPago.Rows(intFila).Cells(7).Value = dblTotalVenta - dblMontoNoEfectivo
                    ElseIf dblTotalVenta - dblMontoNoEfectivo = 0 Then
                        EliminarItem(intFila)
                    Else
                        dgvPago.Rows(intFila).Cells(7).Value = dgvPago.Rows(intFila).Cells(6).Value
                    End If
                Else
                    If intFila = 0 Then
                        dgvPago.Rows(intFila).Cells(7).Value = dgvPago.Rows(intFila).Cells(6).Value 'dblTotal
                    Else
                        dgvPago.Rows(intFila).Cells(7).Value = dgvPago.Rows(intFila).Cells(6).Value
                    End If
                End If

                Me.dgvPago.Focus()
            End If
        End If
    End Sub

    Sub EliminarItem(ByVal fila As Integer)
        With Me.dgvPago
            .Rows.RemoveAt(fila)
            If .Rows.Count = 0 Then
                AgregarItem()
            End If
            CalculaTotal()
        End With
    End Sub

    Function TotalTipoPago(ByVal tipo As Integer) As Double
        Dim colTipoPago As DataGridViewComboBoxCell
        Dim dblTotal As Double = 0
        With Me.dgvPago
            Dim intFila As Integer = .CurrentCell.RowIndex
            colTipoPago = TryCast(dgvPago("tipo_pago", .CurrentRow.Index), DataGridViewComboBoxCell)
            For Each row As DataGridViewRow In .Rows
                If row.Cells("tipo_pago").Value = tipo Then
                    dblTotal += IIf(Val(row.Cells("afecto").Value) = 0, 0, row.Cells("afecto").Value)
                End If
            Next
            Return dblTotal
        End With
    End Function

    Private Sub dgvPago_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPago.MouseClick
        If dgvPago.CurrentCell.RowIndex < dgvPago.Rows.Count - 1 And RegistroCompleto(dgvPago.Rows.Count - 1) = False And Me.dgvPago.Focused And dgvPago.Rows.Count > 1 Then
            EliminarItem(dgvPago.Rows.Count - 1)
        End If
    End Sub

    Private Sub dgvPago_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPago.RowEnter
        Dim colTipoPago As DataGridViewComboBoxCell
        colTipoPago = TryCast(dgvPago("tipo_pago", e.RowIndex), DataGridViewComboBoxCell)
        If colTipoPago.Value = 6 Then
            Me.btnEliminar.Enabled = False
        Else
            Me.btnEliminar.Enabled = True
        End If
    End Sub

    Function TienePago(ByVal pago) As Boolean
        For Each row As DataGridViewRow In dgvPago.Rows
            If row.Cells("tipo_pago").Value = pago Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub lblTotalPago_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTotalPago.TextChanged
        Dim dblVenta As Double, dblPago As Double
        dblVenta = IIf(Val(Me.lblTotalVenta.Text) = 0, 0, Me.lblTotalVenta.Text)
        dblPago = IIf(Val(Me.lblTotalPago.Text) = 0, 0, Me.lblTotalPago.Text)
        If TienePago(1) Then
            Dim dblVuelto As Double = dblPago - dblVenta
            If dblVuelto > 0 Then
                Me.lblVuelto.Text = dblVuelto.ToString("###,###,###0.00")
            Else
                Me.lblVuelto.Text = "0.00"
            End If
        Else
            Me.lblVuelto.Text = "0.00"
        End If
        If dblPago + dblVenta = 0 Then Return
        If dblPago >= dblVenta Then
            Me.btnAgregar.Enabled = False
            Me.btnAceptar.Enabled = True
        Else
            Me.btnAgregar.Enabled = True
            Me.btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub dgvPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPago.LostFocus
        dgvPago.ClearSelection()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de realizar el Pago?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgRespuesta = Windows.Forms.DialogResult.No Then
            Me.dgvPago.Focus()
            blnSalir = False
        Else
            If Not ValidaFila() Then
                dgvPago.Focus()
                blnSalir = False
            End If
        End If
    End Sub

    Function SiguienteValorDisponible() As Integer
        Dim colTipoPago As DataGridViewComboBoxCell, colTipoTarjeta As DataGridViewComboBoxCell
        Dim IntEfectivo As Integer = 0, IntTarjeta As Integer = 0
        With Me.dgvPago
            Dim intFila As Integer = .CurrentCell.RowIndex
            colTipoPago = TryCast(dgvPago("tipo_pago", .CurrentRow.Index), DataGridViewComboBoxCell)
            colTipoTarjeta = TryCast(dgvPago("tipo_tarjeta", .CurrentRow.Index), DataGridViewComboBoxCell)
            For Each row As DataGridViewRow In .Rows
                If intFila <> row.Index Then
                    If row.Cells("tipo_pago").Value = 1 Then 'efectivo
                        IntEfectivo = 1
                    End If
                    If row.Cells("tipo_pago").Value = 2 Then 'tarjeta
                        IntTarjeta += 1
                    End If
                End If
            Next
            If IntEfectivo = 0 Then
                Return 0
            ElseIf IntTarjeta <= 1 Then
                Return 1
            Else
                Return 1
            End If
        End With
    End Function

    Sub AgregarItem(Optional ByVal item As Integer = 0, Optional ByVal mensaje As Boolean = False, Optional ByVal saldo As Double = 0)
        With Me.dgvPago
            If .Rows.Count > 0 Then
                If Not ValidaFila(mensaje) Then
                    Return
                End If
            End If

            Me.dgvPago.Rows.Add()
            Me.dgvPago.CurrentCell = Me.dgvPago.Rows(Me.dgvPago.Rows.Count - 1).Cells(item)
            'Me.dgvPago.BeginEdit(True)

            Me.dgvPago.CurrentCell = Me.dgvPago.Rows(Me.dgvPago.Rows.Count - 1).Cells(0)

            Dim col As DataGridViewComboBoxCell = TryCast(dgvPago("tipo_pago", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell)
            Dim row As DataRowView
            'row = col.Items(item)
            If saldo = 0 Then
                'col.Value = row.Item(0)
                Dim intValor As Integer
                If item = 2 Then
                    intValor = item
                Else
                    intValor = SiguienteValorDisponible()
                End If
                If intValor = 2 Then
                    Dim colAfecto As DataGridViewTextBoxCell = TryCast(dgvPago("afecto", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)
                    Dim colSoles As DataGridViewTextBoxCell = TryCast(dgvPago("soles", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)

                    row = col.Items(intValor)
                    col.Value = row.Item(0)

                    colSoles.Value = CType(Me.lblTotalVenta.Text, Double)
                    colAfecto.Value = CType(Me.lblTotalVenta.Text, Double)
                    .CommitEdit(DataGridViewDataErrorContexts.Commit)

                    Me.btnAceptar.Focus()

                ElseIf intValor > -1 Then
                    row = col.Items(intValor)
                    col.Value = row.Item(0)

                    If intValor = 1 Then 'si es tarjeta
                        Dim colTarjeta As DataGridViewComboBoxCell = TryCast(dgvPago("tipo_tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell)
                        Dim obj As New dtoVentaCargaContado
                        With Me.dgvPago
                            colTarjeta.DataSource = obj.ListarTipoTarjeta
                            colTarjeta.DisplayMember = "tipo_tarjeta"
                            colTarjeta.ValueMember = "id"

                            Dim row1 As DataRowView
                            row1 = colTarjeta.Items(0)
                            colTarjeta.Value = row1.Item(0)
                            colTarjeta.ReadOnly = False
                        End With
                    End If
                Else
                    dgvPago.Rows.RemoveAt(dgvPago.Rows.Count - 1)
                End If
            Else
                row = col.Items(item)
                col.Value = row.Item(0)
                Dim colNC As DataGridViewTextBoxCell = TryCast(dgvPago("soles", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)
                Dim colAfecto As DataGridViewTextBoxCell = TryCast(dgvPago("afecto", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)
                Dim colPago As DataGridViewTextBoxCell = TryCast(dgvPago("pago", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)
                If saldo >= TotalVenta Then
                    saldo = TotalVenta
                    Me.btnAgregar.Enabled = False
                    Me.btnEliminar.Enabled = False
                    blnCompleto = True
                End If
                colNC.Value = saldo
                colAfecto.Value = saldo
                colPago.Value = saldo
                ActivarDesactivar(True, , False)
                If Not blnCompleto Then
                    AgregarItem()
                End If
            End If
        End With
    End Sub
    Private Sub SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim cbo As ComboBox = CType(sender, ComboBox)
            If IsReference(cbo.SelectedValue) Then Return

            If Me.dgvPago.Rows.Count > 1 AndAlso EsRepetido(cbo.SelectedValue) Then
                MessageBox.Show("El Tipo de Pago es repetido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvPago.RefreshEdit()
                Return
            End If

            If cbo.DisplayMember = "tipo_pago" Then
                ActivarDesactivar(False, True)
            Else
                ActivarDesactivar(False)
            End If
            Dim col As DataGridViewComboBoxCell, col2 As DataGridViewComboBoxCell
            If cbo.DisplayMember = "tipo_pago" Then
                col = TryCast(dgvPago("tipo_tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell)
                col2 = TryCast(dgvPago("tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell)
                If cbo.SelectedValue = 2 Then 'tarjeta
                    Dim obj As New dtoVentaCargaContado
                    With Me.dgvPago
                        col.DataSource = obj.ListarTipoTarjeta
                        col.DisplayMember = "tipo_tarjeta"
                        col.ValueMember = "id"

                        Dim row As DataRowView
                        row = col.Items(0)
                        col.Value = row.Item(0)

                    End With
                    col.ReadOnly = False
                    col2.ReadOnly = False
                ElseIf cbo.SelectedValue = 5 Then
                    Dim col1 As DataGridViewComboBoxCell = TryCast(dgvPago("tipo_pago", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell)
                    Dim colAfecto As DataGridViewTextBoxCell = TryCast(dgvPago("afecto", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)
                    Dim colSoles As DataGridViewTextBoxCell = TryCast(dgvPago("soles", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)
                    Dim colPago As DataGridViewTextBoxCell = TryCast(dgvPago("pago", dgvPago.CurrentRow.Index), DataGridViewTextBoxCell)

                    Dim row As DataRowView
                    row = col1.Items(2)
                    col1.Value = row.Item(0)

                    colSoles.Value = CType(Me.lblTotalVenta.Text, Double)
                    colAfecto.Value = CType(Me.lblTotalVenta.Text, Double)
                    colPago.Value = CType(Me.lblTotalVenta.Text, Double)
                    ActivarDesactivar(True)
                    intTiempo = 1
                    tiempo.Enabled = True

                ElseIf cbo.SelectedValue = 6 Then
                    MessageBox.Show("El Pago con Nota de Crédito no está disponible", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cbo.SelectedIndex = SiguienteValorDisponible()
                Else
                    col.Value = Nothing
                    col.ReadOnly = True
                    col2.Value = Nothing
                    col2.ReadOnly = True
                End If
            ElseIf cbo.DisplayMember = "tipo_tarjeta" Then
                col = TryCast(dgvPago("tarjeta", dgvPago.CurrentRow.Index), DataGridViewComboBoxCell)
                'Dim cmb As ComboBox = dgvPago.EditingControl
                'cmb.DroppedDown = True

                If cbo.SelectedValue > 0 Then 'tarjeta
                    Dim obj As New dtoVentaCargaContado
                    With Me.dgvPago
                        col.DataSource = obj.ListarTarjeta(cbo.SelectedValue)
                        col.DisplayMember = "descripcion"
                        col.ValueMember = "id"
                        col.DropDownWidth = 160

                        Dim row As DataRowView
                        row = col.Items(0)
                        col.Value = row.Item(0)
                    End With
                    col.ReadOnly = False
                End If
            End If

            CalculaTotal()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function EsRepetido(ByVal ColTipoPago As Integer) As Boolean
        'Dim colTipoPago As DataGridViewComboBoxCell
        Dim colTipoTarjeta As DataGridViewComboBoxCell
        Dim intEfectivo As Integer = 0, intTarjeta As Integer = 0, intT1 As Integer = 0, intT2 As Integer = 0

        'valida si existe tipo de pago similar
        With Me.dgvPago
            Dim intFila As Integer = .CurrentCell.RowIndex
            'colTipoPago = TryCast(dgvPago("tipo_pago", .CurrentRow.Index), DataGridViewComboBoxCell)
            colTipoTarjeta = TryCast(dgvPago("tipo_tarjeta", .CurrentRow.Index), DataGridViewComboBoxCell)
            Dim a = colTipoTarjeta.Value

            For Each row As DataGridViewRow In .Rows
                If intFila <> row.Index Then
                    If ColTipoPago = 1 Then
                        If ColTipoPago = row.Cells("tipo_pago").Value Then
                            intEfectivo = 1
                        End If
                    ElseIf ColTipoPago = 2 Then
                        'If ColTipoPago = row.Cells("tipo_pago").Value Then
                        'intTarjeta += 1
                        'End If
                    Else
                        If row.Cells("tipo_tarjeta").Value = colTipoTarjeta.Value AndAlso row.Cells("tarjeta").Value = ColTipoPago Then
                            intT1 += 1
                        End If
                        'If ColTipoPago = 19 Or ColTipoPago = 21 Then
                        '    If row.Cells("tipo_tarjeta").Value = 19 Then
                        '        intT1 += 1
                        '    End If
                        '    If row.Cells("tipo_tarjeta").Value = 21 Then
                        '        intT2 += 1
                        '    End If
                        'End If
                    End If
                End If
            Next
            If ColTipoPago = 1 Then
                If intEfectivo = 0 Then
                    Return 0
                Else
                    Return 1
                End If
            ElseIf ColTipoPago = 2 Then
                If intTarjeta <= 1 Then
                    Return 0
                Else
                    Return 1
                End If
            Else
                If intT1 = 0 Then
                    Return 0
                Else
                    Return 1
                End If
                'ElseIf ColTipoPago = 19 Then
                '    If intT1 = 0 Then
                '        Return 0
                '    Else
                '        Return 1
                '    End If
                'ElseIf ColTipoPago = 21 Then
                '    If intT2 = 0 Then
                '        Return 0
                '    Else
                '        Return 1
                '    End If
            End If
        End With
    End Function

    Sub ObtieneTotalNoEfectivo(ByRef total As Double, ByRef afecto As Double, ByRef fila As Integer, ByRef efectivo As Boolean)
        Dim dblTotal As Double = 0
        Dim blnEfectivo As Boolean = False
        Dim intFila As Integer = 0
        Dim dblAfecto As Double = 0
        For Each row As DataGridViewRow In Me.dgvPago.Rows
            If row.Cells(0).Value <> 1 Then
                dblTotal += row.Cells("afecto").Value
            Else
                blnEfectivo = True
                intFila = row.Index
            End If
            dblAfecto += row.Cells("afecto").Value
        Next
        total = IIf(blnEfectivo, dblTotal, 0)
        fila = intFila
        afecto = dblAfecto
        efectivo = blnEfectivo
    End Sub

    Private Sub dgvPago_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPago.CellEndEdit
        With dgvPago
            Dim dblMonto As Double, dblTc As Double, dblTotal As Double, dblTotalVenta As Double, dblTotalPago As Double
            Dim intCol As Integer = dgvPago.CurrentCell.ColumnIndex

            dblTotalVenta = CType(Me.lblTotalVenta.Text, Double)
            dblTotalPago = CType(Me.lblTotalPago.Text, Double)
            If intCol = 3 Or intCol = 4 Or intCol = 5 Then
                If intCol = 3 Then
                    dblMonto = IIf(Val(.CurrentRow.Cells(intCol).Value) = 0, 0, .CurrentRow.Cells(intCol).Value)
                    dblTotal = dblMonto
                    .CurrentRow.Cells(3).Value = dblTotal
                    .CurrentRow.Cells(4).Value = ""
                    .CurrentRow.Cells(5).Value = ""
                    .CurrentRow.Cells(6).Value = dblTotal
                    .CurrentRow.Cells(7).Value = dblTotal
                ElseIf intCol = 4 Or intCol = 5 Then
                    dblMonto = IIf(Val(.CurrentRow.Cells(4).Value) = 0, 0, .CurrentRow.Cells(4).Value)
                    If dtoUSUARIOS.iIDAGENCIAS = 51 Then
                        dblTc = IIf(dblMonto = 0, 0, dblTipoCambio)
                    Else
                        dblTc = IIf(Val(.CurrentRow.Cells(5).Value) = 0, 0, .CurrentRow.Cells(5).Value)
                    End If
                    dblTotal = dblMonto * dblTc
                    If dblMonto + dblTc > 0 Then
                        .CurrentRow.Cells(4).Value = dblMonto
                        .CurrentRow.Cells(5).Value = dblTc
                        .CurrentRow.Cells(3).Value = ""
                        .CurrentRow.Cells(6).Value = dblTotal
                        .CurrentRow.Cells(7).Value = dblTotal
                    Else
                        .CurrentRow.Cells(4).Value = dblMonto
                        .CurrentRow.Cells(5).Value = dblTc
                        .CurrentRow.Cells(6).Value = dblTotal
                        .CurrentRow.Cells(7).Value = dblTotal
                    End If
                End If

                    'Recalcula cuando hay pago efectivo y el total del pago es mayor al de la venta
                    Dim dblMontoNoEfectivo As Double, dblAfecto As Double, blnEfectivo As Boolean
                    Dim intFila As Integer
                    ObtieneTotalNoEfectivo(dblMontoNoEfectivo, dblAfecto, intFila, blnEfectivo)
                    'If (dblMontoNoEfectivo + dblTotal > dblTotalVenta) Then
                    If dblAfecto > dblTotalVenta And blnEfectivo Then
                        If dblTotalVenta - dblMontoNoEfectivo > 0 Then
                            .Rows(intFila).Cells(7).Value = dblTotalVenta - dblMontoNoEfectivo
                        ElseIf dblTotalVenta - dblMontoNoEfectivo = 0 Then
                            intTiempo = 3
                            tiempo.Enabled = True
                        Else
                            .Rows(intFila).Cells(7).Value = .Rows(intFila).Cells(6).Value
                        End If
                    Else
                        If intFila = 0 Then
                            .Rows(intFila).Cells(7).Value = .Rows(intFila).Cells(6).Value 'dblTotal
                        Else
                            .Rows(intFila).Cells(7).Value = .Rows(intFila).Cells(6).Value
                        End If
                    End If
            End If
            If Me.dgvPago.Item(0, e.RowIndex).Value >= 2 Then
                dblMonto = IIf(Val(.CurrentRow.Cells(intCol).Value) = 0, 0, .CurrentRow.Cells(intCol).Value)
                dblTotal = dblMonto
                dblTotal = TotalTipoPago(2)
                dblTotal += TotalTipoPago(6)
                If dblTotal > dblTotalVenta Then
                    MessageBox.Show("El monto de los pagos con Tarjeta no puede ser mayor al Total del Comprobante", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dblTotal = 0
                    dblMonto = 0
                    .CurrentRow.Cells(3).Value = ""
                    .CurrentRow.Cells(4).Value = ""
                    .CurrentRow.Cells(5).Value = ""
                    .CurrentRow.Cells(6).Value = ""
                    .CurrentRow.Cells(7).Value = ""
                    intColumna = intCol
                    intFila = .CurrentCell.RowIndex
                    intTiempo = 2
                    tiempo.Enabled = True
                End If
            End If
        End With
        CalculaTotal()
        blnEdita = False
    End Sub

    Sub LimpiarGrid(Optional ByVal fila As Integer = -1)
        With Me.dgvPago
            If fila = -1 Then
                .Rows.Clear()
            Else
                For i As Integer = .Rows.Count - 1 To 0 Step -1
                    If i <> fila Then
                        .Rows.RemoveAt(i)
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo.Tick
        If intTiempo = 1 Then
            If Me.dgvPago.CurrentRow.Cells(0).Value = 5 Then
                LimpiarGrid(Me.dgvPago.CurrentCell.RowIndex)
                tiempo.Enabled = False
                intTiempo = 0
            End If
        ElseIf intTiempo = 2 Then
            Me.dgvPago.CurrentCell = Me.dgvPago(intColumna, intFila)
            tiempo.Enabled = False
            intTiempo = 0
            intColumna = 0
        ElseIf intTiempo = 3 Then
            LimpiarGrid(intRow)
            CalculaTotal()
            tiempo.Enabled = False
            intTiempo = 0
        End If
    End Sub

    Sub CalculaTotal()
        Dim dblTotal As Double = 0
        For Each row As DataGridViewRow In Me.dgvPago.Rows
            dblTotal += IIf(Val(row.Cells("afecto").Value) = 0, 0, row.Cells("afecto").Value)
        Next
        Me.lblTotalPago.Text = dblTotal.ToString("###,###,###0.00")
    End Sub

    Private Sub btnActualizarCtaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarCtaCte.Click
        LimpiarGrid()
        AgregarItem(3, , CType(Me.lblSaldo.Text, Double))
        CalculaTotal()
    End Sub

    Private Sub dgvPago_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPago.CellEnter
        'Me.dgvPago.BeginEdit(False)
        'If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then  ' <<<< Aquí pones el nº de columna del Combo
        '    If Not IsNothing(dgvPago.EditingControl) Then
        '        Dim cmb As ComboBox = dgvPago.EditingControl
        '        cmb.DroppedDown = True
        '    End If
        'End If
    End Sub

    Private Sub dgvPago_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPago.CellContentClick

    End Sub
End Class
