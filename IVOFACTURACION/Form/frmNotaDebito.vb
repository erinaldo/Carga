Imports INTEGRACION_LN

Public Class frmNotaDebito
    Dim dtOperacion As DataTable
    Dim dtComprobante As DataTable
    Dim digv As Double = dtoUSUARIOS.iIGV  ' Pasar el parámetro de IGV

    Sub ConfigurarGrid()
        Try
            dgvLista.Columns.Clear()
            With dgvLista
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AutoGenerateColumns = False
                '.BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '.DataSource = dvrefactura
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                '.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            'dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)

            Dim idfactura As New DataGridViewTextBoxColumn
            With idfactura '7
                .DisplayIndex = 0
                .DataPropertyName = "idfactura"
                .Name = "idfactura"
                .HeaderText = "idfactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = False
                .Width = 0
            End With
            dgvLista.Columns.Add(idfactura)

            Dim srefactura As New DataGridViewTextBoxColumn
            With srefactura '0
                .DisplayIndex = 1
                .DataPropertyName = "refactura"
                .Name = "refactura"
                .HeaderText = "Nota Débito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvLista.Columns.Add(srefactura)
            '
            Dim sfecha_refactura As New DataGridViewTextBoxColumn
            With sfecha_refactura '1
                .DisplayIndex = 2
                .DataPropertyName = "fecha_refactura"
                .Name = "fecha_refactura"
                .HeaderText = "Fecha Nota Débito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvLista.Columns.Add(sfecha_refactura)
            '
            Dim slogin As New DataGridViewTextBoxColumn
            With slogin '2
                .DisplayIndex = 3
                .DataPropertyName = "login"
                .Name = "login"
                .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgvLista.Columns.Add(slogin)
            '
            Dim sfacturaoriginal As New DataGridViewTextBoxColumn
            With sfacturaoriginal ' 3
                .DisplayIndex = 4
                .DataPropertyName = "factura_original"
                .Name = "factura_original"
                .HeaderText = "Factura Original"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvLista.Columns.Add(sfacturaoriginal)
            '
            Dim sfecha_original As New DataGridViewTextBoxColumn
            With sfecha_original ' 4
                .DisplayIndex = 5
                .DataPropertyName = "fecha_original"
                .Name = "sfecha_original"
                .HeaderText = "Fecha Original"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            dgvLista.Columns.Add(sfecha_original)
            '
            Dim nsub_total As New DataGridViewTextBoxColumn
            With nsub_total ' 5
                .DisplayIndex = 6
                .DataPropertyName = "sub_total"
                .Name = "nsub_total"
                .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            dgvLista.Columns.Add(nsub_total)
            '
            Dim nmonto_impuesto As New DataGridViewTextBoxColumn
            With nmonto_impuesto '6 
                .DisplayIndex = 7
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            dgvLista.Columns.Add(nmonto_impuesto)
            '
            Dim ntotal_costo As New DataGridViewTextBoxColumn
            With ntotal_costo '7
                .DisplayIndex = 8
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            dgvLista.Columns.Add(ntotal_costo)

            Dim estado_registro As New DataGridViewTextBoxColumn
            With estado_registro  '2
                .DisplayIndex = 9
                .DataPropertyName = "estado_registro"
                .Name = "estado_registro"
                .HeaderText = "Estado Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgvLista.Columns.Add(estado_registro)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Sub Limpiar(Optional ByVal estado As Integer = 0)
        Try
            If estado = 0 Then
                Me.rbtOtros.Checked = True
            End If
            If estado = 0 Or estado = 2 Then
                Me.txtSerie.Text = ""
                Me.txtNumero.Text = ""
            End If
            Me.lblFecha.Text = ""
            Me.lblMoneda.Text = ""
            Me.lblSubtotal.Text = ""
            Me.lblImpuesto.Text = ""
            Me.lblTotal.Text = ""
            Me.lblNumeroDocumento.Text = ""
            Me.lblRazonSocial.Text = ""
            Me.cboOperacion.SelectedValue = 0
            Me.lblSerieDebito.Text = ""
            Me.lblNumeroDebito.Text = ""
            Me.dtpFechaDebito.Value = FechaServidor()
            Me.txtGlosa.Text = ""
            Me.txtSubtotal.Text = "0.00"
            Me.lblImpuestoDebito.Text = "0.00"
            Me.lblTotalDebito.Text = "0.00"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Enter
        Me.txtNumero.SelectAll()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            BuscarComprobante()
        ElseIf ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub frmNotaDebito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ConfigurarGrid()
        ListarOperacion()
    End Sub

    Sub ListarOperacion()
        Dim obj As New Cls_NotaDebito_LN
        dtOperacion = obj.ListarOperacion
        With Me.cboOperacion
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = dtOperacion
            .SelectedValue = 0
        End With
    End Sub

    Sub BuscarComprobante()
        Try
            Dim intTipo As Integer
            Dim strSerie As String, strNumero As String

            If Me.rbtOtros.Checked Then
                intTipo = 2
            Else
                intTipo = 1
            End If
            strSerie = Me.txtSerie.Text.Trim
            strNumero = Me.txtNumero.Text.Trim

            Dim obj As New Cls_NotaDebito_LN
            Dim dt As DataTable = obj.ListarComprobante(intTipo, strSerie, strNumero)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("estado") = 2 Then
                    MessageBox.Show("El comprobante está anulado", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                If dt.Rows(0).Item("nc") > 0 Then
                    MessageBox.Show("El comprobante está cancelado por una nota de crédito", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                If dt.Rows(0).Item("enviado") = 0 Then
                    MessageBox.Show("El comprobante no ha sido enviado a Sunat", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Me.txtSerie.Text = dt.Rows(0).Item("serie")
                Me.txtNumero.Text = dt.Rows(0).Item("numero")
                Me.lblFecha.Text = dt.Rows(0).Item("fecha")
                Me.lblMoneda.Text = IIf(dt.Rows(0).Item("moneda") = 1, "SOLES", "DOLAR")
                Me.lblSubtotal.Text = FormatNumber(dt.Rows(0).Item("subtotal"), 2)
                Me.lblImpuesto.Text = FormatNumber(dt.Rows(0).Item("impuesto"), 2)
                Me.lblTotal.Text = FormatNumber(dt.Rows(0).Item("total"), 2)
                Me.lblNumeroDocumento.Text = dt.Rows(0).Item("numero_documento")
                Me.lblRazonSocial.Text = dt.Rows(0).Item("cliente")
                dtComprobante = dt

                Me.cboOperacion.Focus()
            Else
                MessageBox.Show("El comprobante no existe", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.txtSerie.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese serie del comprobante", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtSerie.Focus()
            Return
        End If
        If Me.txtNumero.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nº del comprobante", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Return
        End If
        If Val(Me.lblTotal.Text) = 0 Then
            MessageBox.Show("Ingrese comprobante válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtSerie.Focus()
            Return
        End If
        If Me.cboOperacion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la operación", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboOperacion.Focus()
            Return
        End If
        If Me.txtGlosa.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la glosa", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGlosa.Focus()
            Return
        End If
        If Val(Me.txtSubtotal.Text) = 0 Then
            MessageBox.Show("Ingrese monto de la nota de débito", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtSubtotal.Focus()
            Return
        End If

        If MessageBox.Show("¿Está seguro de grabar la nota de débito?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Grabar()
        End If
    End Sub

    Private Sub txtSerie_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerie.Enter
        Me.txtSerie.SelectAll()
    End Sub

    Private Sub txtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboOperacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOperacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFechaDebito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaDebito.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtGlosa_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGlosa.Enter
        Me.txtGlosa.SelectAll()
    End Sub

    Private Sub txtGlosa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGlosa.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtGlosa_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGlosa.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSubtotal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubtotal.Enter
        Me.txtSubtotal.SelectAll()
    End Sub

    Private Sub txtSubtotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubtotal.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumeroReal(e.KeyChar, Me.txtSubtotal.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Sub Grabar()
        Try
            Cursor = Cursors.WaitCursor
            Dim intId As Integer, strSerie As String, strNumero As String, strFecha As String, strGlosa As String, strComprobante As String
            Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double, intOperacion As Integer, intTipo As Integer
            Dim obj As New Cls_NotaDebito_LN

            intId = dtComprobante.Rows(0).Item("id")
            strSerie = Me.txtSerie.Text.Trim
            strNumero = Me.txtNumero.Text.Trim
            strComprobante = strSerie & "-" & strNumero
            strFecha = Me.dtpFechaDebito.Text
            strGlosa = Me.txtGlosa.Text.Trim
            intOperacion = Me.cboOperacion.SelectedValue
            intTipo = 92
            dblSubtotal = Convert.ToDouble(Me.txtSubtotal.Text)
            dblImpuesto = Convert.ToDouble(Me.lblImpuestoDebito.Text)
            dblTotal = Convert.ToDouble(Me.lblTotalDebito.Text)

            Me.txtSubtotal.Text = "2372.03"
            Me.lblImpuestoDebito.Text = "0.00"
            Me.lblTotalDebito.Text = "2372.03"

            dblSubtotal = "2372.03"
            dblImpuesto = "0.00"
            dblTotal = "2372.03"

            Dim dataTableNota As DataTable = obj.GrabarNotaDebito(intId, strSerie, strNumero, strFecha, strGlosa, dblImpuesto, dblTotal, intOperacion, _
                                 dtoUSUARIOS.iIDAGENCIAS, intTipo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

            Cursor = Cursors.Default
            MessageBox.Show("Nota de Débito registrada", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor = Cursors.WaitCursor

            '*****************************************************************
            '-->Emision del comprobante electronico
            '*****************************************************************
            If Not (dataTableNota Is Nothing) Then
                Dim dataRowNota As DataRow = dataTableNota.Rows(0)
                'NOTA DE DEBITO
                '******************************
                Dim fecliente As New FECliente
                fecliente.tipoDocumentoID = dtComprobante.Rows(0).Item("tipo_documento")
                fecliente.numeroDocumento = dtComprobante.Rows(0).Item("numero_documento")
                fecliente.nombres = dtComprobante.Rows(0).Item("cliente")
                fecliente.direccion = dtComprobante.Rows(0).Item("direccion")

                'Dim dtorefacturacion_ As dtorefacturacion = txtnrofactura_actual.Tag

                Dim documentoReferencia As New FEDocumentoReferencia
                documentoReferencia.tipoDocumentoID = dtComprobante.Rows(0).Item("tipo")
                documentoReferencia.numeroDocumento = strComprobante
                documentoReferencia.fechaEmision = dtComprobante.Rows(0).Item("fecha")

                Dim fenote As New FENota
                fenote.numeroSerie = dataRowNota.Item("serie").ToString()
                fenote.numeroCorrelativo = dataRowNota.Item("correlativo").ToString()
                fenote.cliente = fecliente
                fenote.documentoReferencia = documentoReferencia
                fenote.fechaEmison = dataRowNota.Item("fechaNota")

                fenote.igv = dblImpuesto
                fenote.subTotal = dblSubtotal
                fenote.total = dblTotal

                fenote.tipoNota = dtOperacion.Rows(cboOperacion.SelectedIndex).Item("codigo")
                fenote.descripcionTipoNota = dtOperacion.Rows(cboOperacion.SelectedIndex).Item("descripcion")
                fenote.totalLentras = ConvercionNroEnLetras(fenote.total, dtComprobante.Rows(0).Item("moneda"))
                fenote.descripcionSustento = strGlosa

                fenote.agenciaId = dtoUSUARIOS.iIDAGENCIAS
                fenote.usuarioID = dtoUSUARIOS.IdLogin
                fenote.usuarioInsercion = dtoUSUARIOS.IdLogin
                fenote.usuarioModificacion = dtoUSUARIOS.IdLogin

                If Me.rbtCredito.Checked Then
                    fenote.tipoVenta = FEManager.TIPO_VENTA_CREDITO
                Else
                    fenote.tipoVenta = FEManager.TIPO_VENTA_ESPECIAL
                End If

                fenote.id = dataRowNota.Item("notaDebitoID")
                fenote.tabla = "T_FACTURA_OTRO"

                'hlamas 07-10-2016
                fenote.isMonedaSoles = dtComprobante.Rows(0).Item("moneda") = 1

                Try
                    '-->Aplica Solamente una nota de credito
                    Dim result = FEManager.sendNota(fenote, False)
                    If (result.isCorrect) Then
                        Dim idNotaDebito As Long = dataRowNota.Item("notaDebitoID")
                        Dim objFac As New ClsLbTepsa.dtoFACTURA
                        If Me.rbtCredito.Checked Then
                            objFac.actualizarEmisonFE(idNotaDebito, "T_FACTURA")
                        Else
                            objFac.actualizarEmisonFE(idNotaDebito, "T_FACTURA_OTRO")
                        End If
                    End If
                    MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Cursor = Cursors.Default

                Catch ex As Exception
                    Cursor = Cursors.Default
                    MessageBox.Show("La Nota de Débito Electrónica no pudo ser registrada, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            Cursor = Cursors.Default
            Limpiar()
            Me.tabNotaDebito.SelectedTab = Me.tabNotaDebito.TabPages("tabLista")
            Me.btnBuscar.Focus()
            Me.btnBuscar_Click(Nothing, Nothing)

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabNotaDebito_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabNotaDebito.SelectedIndexChanged
        If tabNotaDebito.SelectedTab Is tabNotaDebito.TabPages("tabEmision") Then
            Limpiar()
            Me.txtSerie.Focus()
        End If
    End Sub

    Private Sub rbtCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtCredito.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtOtros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtOtros.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtSubtotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubtotal.LostFocus
        If Val(Me.txtSubtotal.Text) = 0 Then
            Me.txtSubtotal.Text = "0.00"
        Else
            Me.txtSubtotal.Text = FormatNumber(Me.txtSubtotal.Text, 2)
        End If
    End Sub

    Private Sub txtSubtotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubtotal.TextChanged
        'Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double

        'If Val(Me.txtSubtotal.Text) = 0 Then
        '    dblSubtotal = 0
        'Else
        '    dblSubtotal = Me.txtSubtotal.Text
        'End If
        'dblTotal = dblSubtotal * (1 + digv / 100)
        'dblImpuesto = dblSubtotal * (digv / 100)

        'Me.lblImpuestoDebito.Text = FormatNumber(dblImpuesto, 2)
        'Me.lblTotalDebito.Text = FormatNumber(dblTotal, 2)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.tabNotaDebito.SelectedTab = Me.tabNotaDebito.TabPages("tabLista")
        Me.btnBuscar.Focus()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim obj As New Cls_NotaDebito_LN

        Dim dt As DataTable = obj.ListarNotaDebito(Me.dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString)
        With dgvLista
            .DataSource = dt
        End With
    End Sub

    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.TextChanged, txtNumero.TextChanged
        Limpiar(1)
    End Sub

    Private Sub rbtOtros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtOtros.CheckedChanged, rbtCredito.CheckedChanged
        Limpiar(2)
    End Sub
End Class