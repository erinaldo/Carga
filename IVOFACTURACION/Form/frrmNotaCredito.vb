Imports INTEGRACION_LN
Public Class frmNotaCredito
    Structure Cliente
        Dim id As Integer
        Dim razon_social As String
        Dim tipo_documento As Integer
        Dim numero_documento As String
        Dim nombres As String
        Dim ap As String
        Dim am As String
        Dim telefono As String
        Dim email As String
    End Structure
    Structure Direccion
        Dim id As Integer
        Dim direccion As String
        Dim id_via As Integer
        Dim via As String
        Dim numero As String
        Dim manzana As String
        Dim lote As String
        Dim id_nivel As Integer
        Dim nivel As String
        Dim id_zona As Integer
        Dim zona As String
        Dim id_clasificacion As Integer
        Dim clasificacion As String
        Dim iddepartamento As Integer
        Dim idprovincia As Integer
        Dim iddistrito As Integer
    End Structure

    Dim aCliente As Cliente
    Dim aDireccion As New Direccion
    Dim dtDireccion As DataTable

    Dim dtOperacion As DataTable
    Dim tabComprobanteNuevo As TabPage
    ''' <summary>
    ''' Realiza la emision de los comprobantes electronicos - jabanto - 07/06/2016
    ''' </summary>
    ''' <param name="dataRowNota">Objeto DataRow que retorna el metodo que guarda la nota de credito en titan.</param>
    ''' <param name="dataRowFactura">Objeto DataRow que retorna el metodo que guarda la la factura/boleta en titan.</param>
    ''' <param name="tipo_documentoID">Identificador del tipo de documento del cliente, para la emision de la factura o boleta</param>
    ''' <param name="numero_documento">Numero de documento del cliente, para la emsion de la factura o boleta</param>
    ''' <param name="razon_social">Razon social del cliente, para emitir la factura o boleta.</param>
    ''' <param name="tipo_comprobanteId">Identificador del tipo de comprobante, para la emision de la factura o la boleta</param>
    Private Sub emitirComprobantesElectronicos(dataRowNota As DataRow, dataRowFactura As DataRow, tipo_documentoID As String _
                                               , numero_documento As String, razon_social As String, tipo_comprobanteId As String _
                                               , dtImpresora As DataTable)

        If (grbComprobante.Tag Is Nothing) Then _
            Return

        Dim datarowCompReferencial As DataRow = grbComprobante.Tag
        Dim comprobanteReferenciaID As String = datarowCompReferencial("idtipo_comprobante").ToString()
        Dim comprobanteReferenciaNumero As String = datarowCompReferencial("serie_factura").ToString() & "-" & datarowCompReferencial("nro_factura").ToString()
        Dim comprobanteReferenciaFecha As String = datarowCompReferencial("fecha").ToString()

        '-->Nota de credito
        '******************************
        Dim fenote As FENota = Nothing
        If Not (dataRowNota Is Nothing) Then
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = datarowCompReferencial("idtipo_doc_identidad").ToString()
            fecliente.numeroDocumento = datarowCompReferencial("numero_documento").ToString()
            fecliente.nombres = datarowCompReferencial("razon_social").ToString()
            'fecliente.direccion =

            Dim documentoReferencia As New FEDocumentoReferencia
            documentoReferencia.tipoDocumentoID = comprobanteReferenciaID
            documentoReferencia.numeroDocumento = comprobanteReferenciaNumero
            documentoReferencia.fechaEmision = comprobanteReferenciaFecha

            fenote = New FENota
            fenote.numeroSerie = dataRowNota(0).ToString()
            fenote.numeroCorrelativo = dataRowNota(1).ToString()
            fenote.cliente = fecliente
            fenote.documentoReferencia = documentoReferencia
            fenote.fechaEmison = FechaServidor()
            fenote.igv = Convert.ToDouble(txtImpuesto.Text) * -1
            fenote.subTotal = Convert.ToDouble(txtSubtotal.Text) * -1
            fenote.total = Convert.ToDouble(txtTotal.Text) * -1
            fenote.tipoNota = DirectCast(cboOperacion.SelectedItem, DataRowView)("codigo").ToString()
            fenote.descripcionTipoNota = DirectCast(cboOperacion.SelectedItem, DataRowView)("descripcion_sunat").ToString()
            fenote.totalLentras = ConvercionNroEnLetras(fenote.total)
            fenote.descripcionSustento = txtGlosaNotaCredito.Text.Trim.ToUpper()
            'hlamas 12-04-2017
            fenote.agenciaId = dtoUSUARIOS.iIDAGENCIAS
            fenote.usuarioID = dtoUSUARIOS.IdLogin
            fenote.usuarioInsercion = dtoUSUARIOS.IdLogin
            fenote.usuarioModificacion = dtoUSUARIOS.IdLogin
            fenote.id = dataRowNota(2)
            fenote.tabla = "T_FACTURA_CONTADO"
            fenote.isMonedaSoles = True
        End If
        

        '-->Valida si solamente debe aplicar una nota de credito, mas no un nuevo comprobante
        If (dataRowFactura Is Nothing AndAlso Not fenote Is Nothing) Then
            Try
                '-->Aplica Solamente una nota de credito
                Dim result = FEManager.sendNota(fenote, True)
                If (result.isCorrect) Then
                    Dim idNotaCredito As Long = dataRowNota(2)
                    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_CONTADO")
                End If
                MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("La Nota de Crédito Electrónica no pudo ser registrada, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                '-->Aplica la Nota de credito y el nuevo comprobante (Factura/Boleta)
                '******************************
                Dim feventa As FEVenta = Nothing
                If Not (dataRowFactura Is Nothing) Then
                    Dim fecliente As New FECliente
                    fecliente.tipoDocumentoID = tipo_documentoID
                    fecliente.tipoDocumento = DirectCast(grbCliente.Tag, DataRow)("tipo_doc_identidad")
                    fecliente.numeroDocumento = numero_documento
                    fecliente.nombres = razon_social
                    fecliente.direccion = IIf(cboDireccionNuevo.SelectedIndex > 0, cboDireccionNuevo.Text.Trim(), Nothing)

                    feventa = New FEVenta
                    feventa.cliente = fecliente
                    feventa.isCredito = False
                    feventa.numeroSerie = dataRowFactura(0).ToString()
                    feventa.numeroCorrelativo = dataRowFactura(1).ToString()
                    feventa.isMonedaSoles = True
                    feventa.fechaEmision = FechaServidor()
                    feventa.tipoComprobanteID = tipo_comprobanteId
                    feventa.opGravada = Convert.ToDouble(txtSubtotalNuevo.Text.Trim)
                    feventa.igv = Convert.ToDouble(txtImpuestoNuevo.Text.Trim)
                    feventa.total = Convert.ToDouble(txtTotalNuevo.Text.Trim)
                    feventa.totalLetras = ConvercionNroEnLetras(feventa.total)
                    feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
                    feventa.usuarioEmision = dtoUSUARIOS.NameLogin
                    feventa.id = dataRowFactura(2)
                    feventa.tabla = "T_FACTURA_CONTADO"

                    '-->Basicamente para completar la impresion
                    If Not (IsDBNull(datarowCompReferencial("razon_social"))) Then _
                        feventa.remitenete = datarowCompReferencial("razon_social").ToString()
                    If Not (IsDBNull(datarowCompReferencial("origen"))) Then _
                        feventa.origen = datarowCompReferencial("origen").ToString()
                    If Not (IsDBNull(datarowCompReferencial("destino"))) Then _
                        feventa.destino = datarowCompReferencial("destino").ToString()
                    If Not (IsDBNull(datarowCompReferencial("consignado"))) Then _
                        feventa.consignado = datarowCompReferencial("consignado").ToString()
                    If Not (IsDBNull(datarowCompReferencial("tipoEntrega"))) Then _
                        feventa.tipoEntrega = datarowCompReferencial("tipoEntrega").ToString()
                    If Not (IsDBNull(datarowCompReferencial("direccionEntrega"))) Then _
                        feventa.direccionEntrega = datarowCompReferencial("direccionEntrega").ToString()
                    If Not (IsDBNull(datarowCompReferencial("tipoPago"))) Then _
                        feventa.formaPago = datarowCompReferencial("tipoPago").ToString()
                    'Este documento permite al servcio web, buscar el detalle y la informacion adicional del documento en referencia para 
                    'copiar el detalle a este nuevo comprobante
                    Dim documentoReferenciaVenta As New FEDocumentoReferencia
                    documentoReferenciaVenta.tipoDocumentoID = comprobanteReferenciaID
                    documentoReferenciaVenta.numeroDocumento = comprobanteReferenciaNumero
                    feventa.documentoReferencia = documentoReferenciaVenta
                End If

                '-->Valida si debe emitir la nota de credito y el nuevo comprobante
                Dim result = Nothing
                If Not fenote Is Nothing AndAlso Not feventa Is Nothing Then
                    '-->Emite ambos comprobantes
                    result = FEManager.sendNotaVenta(fenote, True, feventa, dtImpresora)
                ElseIf Not feventa Is Nothing Then
                    '-->Emite solamente la factura
                    result = FEManager.sendVentaSunat(feventa, dtImpresora)
                End If

                If Not result Is Nothing Then
                    If (result.IsCorrect) Then
                        '-->Actualiza la nota de credito como emitido electronicamente
                        If Not dataRowNota Is Nothing Then
                            Dim idNotaCredito As Long = dataRowNota(2)
                            Dim objFac As New ClsLbTepsa.dtoFACTURA
                            objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_CONTADO")
                        End If
                        
                        If Not dataRowFactura Is Nothing Then
                            Dim objFac As New ClsLbTepsa.dtoFACTURA
                            '-->Actualiza la factura/boleta como emitido electronicamente
                            Dim idFactura As Long = dataRowFactura(2)
                            objFac.actualizarEmisonFE(idFactura, "T_FACTURA_CONTADO")
                        End If
                    End If
                    MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show("No se pudierón Generar los comprobantes electrónicos, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
    Sub FormatearDGVLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
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
            Dim col_fecha_co As New DataGridViewTextBoxColumn
            With col_fecha_co
                .Name = "fecha_co" : .DataPropertyName = "fecha_co"
                .DisplayIndex = x : .HeaderText = "Fecha Original" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_co As New DataGridViewTextBoxColumn
            With col_tipo_co
                .Name = "tipo_co" : .DataPropertyName = "tipo_co"
                .DisplayIndex = x : .HeaderText = "Tipo Original" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_co As New DataGridViewTextBoxColumn
            With col_co
                .Name = "co" : .DataPropertyName = "co"
                .DisplayIndex = x : .HeaderText = "Nº Comprobante Original" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_total_co As New DataGridViewTextBoxColumn
            With col_total_co
                .Name = "total_co" : .DataPropertyName = "total_co"
                .DisplayIndex = x : .HeaderText = "Total Original" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo"
            End With
            x += +1
            Dim col_fecha_nc As New DataGridViewTextBoxColumn
            With col_fecha_nc
                .Name = "fecha_nc" : .DataPropertyName = "fecha_nc"
                .DisplayIndex = x : .HeaderText = "Fecha" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_nc As New DataGridViewTextBoxColumn
            With col_tipo_nc
                .Name = "tipo_nc" : .DataPropertyName = "tipo_nc"
                .DisplayIndex = x : .HeaderText = "Tipo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_nc As New DataGridViewTextBoxColumn
            With col_nc
                .Name = "nc" : .DataPropertyName = "nc"
                .DisplayIndex = x : .HeaderText = "Nº Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .HeaderText = "Subtotal" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .HeaderText = "Impuesto" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .HeaderText = "Total" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .HeaderText = "Estado" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_es_refactura As New DataGridViewTextBoxColumn
            With col_es_refactura
                .Name = "es_refactura" : .DataPropertyName = "es_refactura"
                .DisplayIndex = x : .HeaderText = "¿Es Refactura?" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .HeaderText = "Operacion" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_ref As New DataGridViewTextBoxColumn
            With col_id_ref
                .Name = "id_ref" : .DataPropertyName = "id_ref" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_ref"
            End With
            x += +1
            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
            End With

            .Columns.AddRange(col_id, col_fecha_co, col_tipo_co, col_co, col_total_co, col_tipo, col_fecha_nc, col_tipo_nc, col_nc, col_subtotal, col_impuesto, col_total, _
                              col_estado, col_es_refactura, col_operacion, col_id_ref, col_id_tipo)
        End With
    End Sub
    Private Sub frmNotaCredito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FormatearDGVLista()
        Me.tabComprobanteNuevo = Me.tabComprobante.TabPages("tabFactura")
        Limpiar()
        'ListarOperacion(2, 0, 1, 3)
        Me.tabNotaCredito_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cboTipoComprobante_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoComprobante.SelectedIndexChanged
        Try
            Me.LimpiarComprobante()
            Me.LimpiarNotaCredito()
            Me.LimpiarComprobanteNuevo()

            ListarOperacion(2, 0, 1, Me.cboTipoComprobante.SelectedIndex + 1, 1, G_Rol)
            If Me.cboOperacion.Items.Count > 0 Then
                Me.cboOperacion.SelectedIndex = 0
            End If

            Me.txtComprobante.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtComprobante_Enter(sender As Object, e As System.EventArgs) Handles txtComprobante.Enter
        Me.txtComprobante.SelectAll()
    End Sub

    Private Sub txtComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            BuscarCliente(Me.cboTipoComprobante.SelectedIndex + 1, Me.txtComprobante.Text.Trim)
        ElseIf ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub Limpiar()
        Me.cboTipoComprobante.SelectedIndex = 0
        Me.txtComprobante.Text = ""
        Me.txtComprobante.Tag = Nothing
        LimpiarComprobante()

        Me.cboTipoComprobanteNuevo.SelectedIndex = 0
    End Sub

    Sub LimpiarComprobante()
        Me.lblFecha.Text = ""
        Me.lblSubtotal.Text = "0.00"
        Me.lblImpuesto.Text = "0.00"
        Me.lblTotal.Text = "0.00"
        Me.lblNumeroDocumento.Text = ""
        Me.lblRazonSocial.Text = ""

    End Sub

    Sub BuscarCliente(tipo As Integer, comprobante As String)
        Cursor = Cursors.WaitCursor
        Dim obj As New Cls_NotaCredito_LN
        Dim dt As DataTable = obj.BuscarComprobante(tipo, comprobante)
        With dt
            If .Rows.Count > 0 Then
                Me.txtComprobante.Tag = .Rows(0).Item("id")
                Me.grbComprobante.Tag = dt.Rows(0)
                Me.lblFecha.Text = .Rows(0).Item("fecha")
                Me.lblSubtotal.Text = Format(.Rows(0).Item("subtotal"), "###,###,###0.00")
                Me.lblImpuesto.Text = Format(.Rows(0).Item("impuesto"), "###,###,###0.00")
                Me.lblTotal.Text = Format(.Rows(0).Item("total"), "###,###,###0.00")

                Me.lblNumeroDocumento.Text = .Rows(0).Item("numero_documento")
                Me.lblRazonSocial.Text = .Rows(0).Item("razon_social")

                'Dim strFecha As String = DateAdd(DateInterval.Day, 1, .Rows(0).Item("fecha"))
                'Dim strFechaServidor As String = FechaServidor(1)
                'Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))
                'If dias <= 3 Then 'si no esta dentro de los 10 dias habiles
                '    Cursor = Cursors.Default
                '    MessageBox.Show("La Nota de Crédito debe Emitirse después de 3 dias, según la fecha de Comprobante", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.LimpiarComprobante()
                '    Me.LimpiarNotaCredito()
                '    Me.LimpiarComprobanteNuevo()
                '    Me.txtComprobante.Focus()
                '    Me.txtComprobante.SelectAll()
                '    Return
                'End If
                If dt.Rows(0).Item("emite_nc") = 0 Then 'si no esta dentro de los 10 dias habiles
                    MessageBox.Show("El Comprobante excede Plazo para ser Anulado" & Chr(13) & "No está dentro de los 10 dias hábiles", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComprobante.Focus()
                    Me.LimpiarComprobante()
                    Me.LimpiarNotaCredito()
                    Me.LimpiarComprobanteNuevo()
                    Me.txtComprobante.Focus()
                    Me.txtComprobante.SelectAll()
                    Return
                End If

                'Determina si se emite Nota de Credito o Baja segun fecha de comprobante
                'Si fecha del servidor-fecha de comprobante es menor o igual a 3 dias baja si no nota de credito
                Dim intOrigen As Integer
                Dim strFechaComprobante As String = .Rows(0).Item("fecha") 'DateAdd(DateInterval.Day, 1, CType(.Rows(0).Item("fecha"), Date))
                Dim strFechaServidor As String = FechaServidor(1)
                Dim dias As Long = DateDiff(DateInterval.Day, CType(strFechaComprobante, Date), CType(strFechaServidor, Date))
                If dias <= 3 Then 'validar si mes de comprobante es diferente a mes del sistema
                    If DatePart(DateInterval.Month, CDate(strFechaComprobante)) <> DatePart(DateInterval.Month, CDate(strFechaServidor)) Then
                        intOrigen = 2
                    Else
                        intOrigen = 2
                    End If
                Else
                    intOrigen = 2
                End If
                'Dim intOrigen As Integer = IIf(dias > 3, 2, 1) '1=baja 2=nc
                If intOrigen = 1 Then 'Baja
                    If tabComprobante.TabPages.IndexOf(tabNC) > -1 Then
                        Me.tabComprobante.TabPages.Remove(Me.tabComprobante.TabPages("tabNC"))
                    End If
                Else 'Nota Credito
                    If tabComprobante.TabPages.IndexOf(tabFactura) > -1 Then
                        Me.tabComprobante.TabPages.Remove(Me.tabComprobante.TabPages("tabFactura"))
                    End If
                    If tabComprobante.TabPages.IndexOf(tabNC) = -1 Then
                        Me.tabComprobante.TabPages.Add(tabNC)
                    End If
                    If tabComprobante.TabPages.IndexOf(tabFactura) = -1 Then
                        Me.tabComprobante.TabPages.Add(tabFactura)
                    End If
                End If

                Me.cboOperacion.Focus()
                Me.cboOperacion.DroppedDown = True

                Cursor = Cursors.Default
            Else
                Cursor = Cursors.Default
                MessageBox.Show("La " & Me.cboTipoComprobante.Text & " " & Me.txtComprobante.Text.Trim & " no existe o no está Disponible", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtComprobante.Focus()
                Me.txtComprobante.SelectAll()
            End If
        End With
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged
        LimpiarComprobante()
        LimpiarNotaCredito()
        LimpiarComprobanteNuevo()
    End Sub

    Sub ListarOperacion(tipo_registro As Integer, tipo As Integer, tipo_servicio As Integer, tipo_comprobante As Integer, modo As Integer, rol As Integer)
        Dim obj As New Cls_NotaCredito_LN
        dtOperacion = obj.ListarOperacion(tipo_registro, tipo, tipo_servicio, tipo_comprobante, 2, modo, rol)
        With Me.cboOperacion
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = dtOperacion
            .SelectedValue = 0
        End With
    End Sub

    Sub ActualizaNumeroComprobante(tipo As Integer, Optional opcion As Integer = 1)
        Dim obj As New dtoVentaCargaContado

        If opcion = 1 Then
            Dim strCar As Char = IIf(Me.cboTipoComprobante.SelectedIndex = 0, "F", "B")
            If obj.fnNroDocuemnto(tipo, , 1) = True Then
                lblSerie.Text = RellenoRight(3, obj.Serie)
                lblNumero.Text = RellenoRight(7, obj.NroDoc)
            Else
                MessageBox.Show("Configure Serie y Número del Comprobante", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Dim strCar As Char = IIf(Me.cboTipoComprobanteNuevo.SelectedIndex = 1, "F", "B")
            If obj.fnNroDocuemnto(tipo, , 1) = True Then
                lblSerieNuevo.Text = RellenoRight(3, obj.Serie)
                lblNumeroNuevo.Text = RellenoRight(7, obj.NroDoc)
            Else
                MessageBox.Show("Configure Serie y Número del Comprobante", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
        objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
        objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
            MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        objLIQUI_TURNOS = Nothing

        If CType(Me.lblTotal.Text, Double) = 0 Then
            MessageBox.Show("Ingrese Comprobante", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabNC")
            Me.txtComprobante.Focus()
            Return
        End If

        If CType(Me.txtTotal.Text, Double) = 0 Then
            MessageBox.Show("Seleccione Operación de Nota de Crédito", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabNC")
            Me.cboOperacion.Focus()
            Me.cboOperacion.DroppedDown = True
            Return
        End If

        If tabComprobante.TabPages.IndexOf(tabNC) > -1 Then 'si se emite nota de credito
            If Me.txtGlosaNotaCredito.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Glosa", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabNC")
                Me.txtGlosaNotaCredito.Text = Me.txtGlosaNotaCredito.Text.Trim
                Me.txtGlosaNotaCredito.Focus()
                Return
            End If
        End If

        If tabComprobante.TabPages.IndexOf(tabFactura) > -1 Then 'si se emite comprobante adicional
            If Me.cboTipoComprobanteNuevo.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione Operación", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
                Me.cboOperacion.Focus()
                Me.cboOperacion.DroppedDown = True
                Return
            End If

            If Me.cboTipoComprobanteNuevo.SelectedIndex = 1 Then
                If Me.cboDireccionNuevo.SelectedIndex = 0 Then
                    MessageBox.Show("Seleccione Dirección Fiscal", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
                    Me.cboDireccionNuevo.Focus()
                    Me.cboDireccionNuevo.DroppedDown = True
                    Return
                End If
            End If
        End If

        If Me.txtNombreNuevo.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Cliente", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
            Me.txtNumeroDocumentoNuevo.Focus()
            Return
        End If

        If CType(Me.txtTotalNuevo.Text, Double) = 0 Then
            MessageBox.Show("Seleccione Operación", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
            Me.cboOperacion.Focus()
            Me.cboOperacion.DroppedDown = True
            Return
        End If


        If Not ValidaOperacion(Me.cboOperacion.SelectedValue) Then
            Return
        End If

        Grabar()
    End Sub

    Function ValidaOperacion(operacion As Integer) As Boolean
        If operacion = 1 Then 'factura a boleta
            If Me.txtNumeroDocumentoNuevo.Text.Trim.Length <> 8 Then 'obligatorio dni
                MessageBox.Show("Ingrese DNI", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
                Me.txtNumeroDocumentoNuevo.Focus()
                Return False
            End If
        ElseIf operacion = 2 Then 'boleta a factura
            If Me.txtNumeroDocumentoNuevo.Text.Trim.Length <> 11 Then 'obligatorio ruc
                MessageBox.Show("Ingrese RUC", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
                Me.txtNumeroDocumentoNuevo.Focus()
                Return False
            End If
        ElseIf operacion = 5 Then 'cambio de ruc
            If Me.txtNumeroDocumentoNuevo.Text.Trim.Length <> 11 Then 'obligatorio ruc
                MessageBox.Show("Ingrese RUC", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
                Me.txtNumeroDocumentoNuevo.Focus()
                Return False
            End If
            If Me.txtNumeroDocumentoNuevo.Text.Trim = Me.lblNumeroDocumento.Text.Trim Then 'cambio de  ruc
                MessageBox.Show("Ingrese nuevo RUC", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
                Me.txtNumeroDocumentoNuevo.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Sub LimpiarNotaCredito()
        Me.dtpFechaNotaCredito.Value = Now
        Me.txtGlosaNotaCredito.Text = ""
        Me.txtSubtotal.Text = "0.00"
        Me.txtImpuesto.Text = "0.00"
        Me.txtTotal.Text = "0.00"
        Me.lblSerie.Text = ""
        Me.lblNumero.Text = ""
    End Sub

    Sub ActualizarTotal(opcion As Integer)
        If Me.cboOperacion.SelectedValue > 0 Then
            Dim dblTotal As Double, dblSubtotal As Double, dblImpuesto As Double
            If opcion = 1 Then
                Me.txtTotal.Text = Format(CType(Me.lblTotal.Text, Double) * -1, "0.00")
                Me.txtImpuesto.Text = Format(CType(Me.lblImpuesto.Text, Double) * -1, "0.00")
                Me.txtSubtotal.Text = Format(CType(Me.lblSubtotal.Text, Double) * -1, "0.00")
            Else
                If Me.cboOperacion.SelectedValue = 1 Then
                    'dblTotal = Me.lblSubtotal.Text
                    'dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                    'dblImpuesto = dblTotal - dblSubtotal
                    dblTotal = CType(Me.lblTotal.Text, Double)
                    dblSubtotal = CType(Me.lblSubtotal.Text, Double)
                    dblImpuesto = CType(Me.lblImpuesto.Text, Double)
                    Me.txtTotalNuevo.Text = Format(dblTotal, "0.00")
                    Me.txtSubtotalNuevo.Text = Format(dblSubtotal, "0.00")
                    Me.txtImpuestoNuevo.Text = Format(dblImpuesto, "0.00")
                ElseIf Me.cboOperacion.SelectedValue = 2 Then
                    'dblTotal = Me.lblTotal.Text
                    'dblTotal = dblTotal * (1 + (dtoUSUARIOS.iIGV / 100))
                    'dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                    'dblImpuesto = dblTotal - dblSubtotal
                    dblTotal = CType(Me.lblTotal.Text, Double)
                    dblSubtotal = CType(Me.lblSubtotal.Text, Double)
                    dblImpuesto = CType(Me.lblImpuesto.Text, Double)
                    Me.txtTotalNuevo.Text = Format(dblTotal, "0.00")
                    Me.txtSubtotalNuevo.Text = Format(dblSubtotal, "0.00")
                    Me.txtImpuestoNuevo.Text = Format(dblImpuesto, "0.00")
                Else
                    Me.txtTotalNuevo.Text = Me.lblTotal.Text
                    Me.txtImpuestoNuevo.Text = Me.lblImpuesto.Text
                    Me.txtSubtotalNuevo.Text = Me.lblSubtotal.Text
                End If
            End If
        End If
    End Sub

    Sub LimpiarComprobanteNuevo()
        Me.cboTipoComprobanteNuevo.SelectedIndex = 0
        Me.dtpFechaNuevo.Value = Now
        Me.txtSubtotalNuevo.Text = ""
        Me.txtImpuestoNuevo.Text = ""
        Me.txtTotalNuevo.Text = ""
        Me.lblSerieNuevo.Text = ""
        Me.lblNumeroNuevo.Text = ""
        Me.txtNumeroDocumentoNuevo.Text = ""
        Me.txtNombreNuevo.Text = ""

        Me.cboDireccionNuevo.SelectedIndex = -1
        Me.cboDireccionNuevo.DataSource = Nothing
        Me.cboDireccionNuevo.Items.Clear()
        Me.cboDireccionNuevo.Items.Add(" (SELECCIONE)")
        Me.cboDireccionNuevo.SelectedIndex = 0
        dtDireccion = Nothing
    End Sub

    Private Sub cboOperacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOperacion.SelectedIndexChanged
        Try
            Cursor = Cursors.WaitCursor
            LimpiarNotaCredito()
            ActualizarTotal(1)

            Me.LimpiarComprobanteNuevo()
            ActualizarTotal(2)

            If Me.cboOperacion.SelectedValue > 0 Then
                Dim intTipoComprobante As Integer, intTipo As Integer
                intTipo = dtOperacion.Rows(Me.cboOperacion.SelectedIndex).Item("tipo")
                If intTipo = 3 Then
                    If tabComprobante.TabPages.IndexOf(tabComprobanteNuevo) = -1 Then
                        Me.tabComprobante.TabPages.Add(tabComprobanteNuevo)
                    End If
                Else
                    If tabComprobante.TabPages.IndexOf(tabComprobanteNuevo) > -1 Then
                        Me.tabComprobante.TabPages.Remove(Me.tabComprobante.TabPages("tabFactura"))
                    End If
                End If

                intTipoComprobante = dtOperacion.Rows(Me.cboOperacion.SelectedIndex).Item("tipo_comprobante_final")
                If intTipoComprobante = 3 Then
                    Me.cboTipoComprobanteNuevo.SelectedValue = 0
                    Me.cboTipoComprobanteNuevo.Enabled = True
                    Me.cboTipoComprobanteNuevo.Focus()
                    Me.cboTipoComprobanteNuevo.DroppedDown = True
                Else
                    Me.cboTipoComprobanteNuevo.SelectedIndex = intTipoComprobante
                    Me.cboTipoComprobanteNuevo.Enabled = False
                End If
                ActualizaNumeroComprobante(30)
            Else
                If tabComprobante.TabPages.IndexOf(tabComprobanteNuevo) > -1 Then
                    Me.tabComprobante.TabPages.Remove(Me.tabComprobante.TabPages("tabFactura"))
                End If
            End If

            If Me.tabComprobante.SelectedTab Is Me.tabComprobante.TabPages("tabNC") Then
                'Me.txtGlosaNotaCredito.Focus()
            ElseIf Me.tabComprobante.SelectedTab Is Me.tabComprobante.TabPages("tabFactura") Then
                Me.dtpFechaNuevo.Focus()
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtGlosaNotaCredito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGlosaNotaCredito.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If tabComprobante.TabPages.IndexOf(tabComprobanteNuevo) > -1 Then
                Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabFactura")
            Else
                If Me.tsbGrabar.Enabled Then
                    Me.tsbGrabar_Click(Nothing, Nothing)
                End If
            End If
        End If
    End Sub

    Private Sub txtGlosaNotaCredito_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtGlosaNotaCredito.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tabComprobante_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabComprobante.SelectedIndexChanged
        If Me.tabComprobante.SelectedTab Is Me.tabComprobante.TabPages("tabFactura") Then
            Dim intTipoComprobante As Integer
            intTipoComprobante = dtOperacion.Rows(Me.cboOperacion.SelectedIndex).Item("tipo_comprobante_final")
            If intTipoComprobante = 3 Then
                Me.cboTipoComprobanteNuevo.SelectedValue = 0
                Me.cboTipoComprobanteNuevo.Enabled = True
                Me.cboTipoComprobanteNuevo.Focus()
                Me.cboTipoComprobanteNuevo.DroppedDown = True
            ElseIf intTipoComprobante > 0 Then
                Me.cboTipoComprobanteNuevo.SelectedIndex = intTipoComprobante
                Me.cboTipoComprobanteNuevo.Enabled = False
                Me.dtpFechaNuevo.Focus()
            End If
        End If
    End Sub

    Private Sub cboTipoComprobanteNuevo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoComprobanteNuevo.SelectedIndexChanged
        ActualizaNumeroComprobante(cboTipoComprobanteNuevo.SelectedIndex, 2)
        If Me.cboTipoComprobanteNuevo.SelectedIndex = 0 Then
            Me.lblComprobanteNuevo.Text = ""
        Else
            Me.lblComprobanteNuevo.Text = IIf(Me.cboTipoComprobanteNuevo.SelectedIndex = 1, "FACTURA", "BOLETA")
        End If
    End Sub

    Sub CargarCliente(ByVal frm As FrmCliente2)
        'If frm.bClienteNuevo Then
        'Me.txtNumeroDocumento.Tag = 0
        'End If
        Me.txtNumeroDocumentoNuevo.Text = frm.TxtNumero.Text.Trim
        Me.txtNombreNuevo.Text = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
        'Cliente
        With aCliente
            If frm.bClienteNuevo Then
                .id = -1
            End If
            .tipo_documento = frm.CboTipoDocumento.SelectedValue
            .numero_documento = frm.TxtNumero.Text.Trim
            .nombres = frm.TxtCliente.Text
            .razon_social = frm.TxtCliente.Text
            .ap = frm.TxtAPCliente.Text
            .am = frm.TxtAMCliente.Text
            .telefono = frm.txtTelefono.Text
            .email = frm.TxtEmail.Text
        End With

        'Direccion
        With aDireccion
            .iddepartamento = frm.CboDepartamento.SelectedValue
            .idprovincia = frm.CboProvincia.SelectedValue
            .iddistrito = frm.CboDistrito.SelectedValue
            .id_via = frm.CboVia.SelectedValue
            .via = frm.TxtVia.Text
            .numero = frm.TxtNumero2.Text
            .manzana = frm.TxtManzana.Text
            .lote = frm.TxtLote.Text
            .id_nivel = frm.CboNivel.SelectedValue
            .nivel = frm.TxtNivel.Text
            .id_zona = frm.CboZona.SelectedValue
            .zona = frm.TxtZona.Text
            .id_clasificacion = frm.CboClasificacion.SelectedValue
            .clasificacion = frm.TxtClasificacion.Text
        End With

        'Dirección
        Dim sDireccion As String = IIf(frm.CboVia.SelectedValue = 0, "", frm.CboVia.Text) & " " & IIf(frm.CboVia.SelectedValue = 0, "", frm.TxtVia.Text.Trim) & " " 'Cambio 03102011
        If frm.CboVia.SelectedValue > 0 And frm.TxtNumero2.Text.Trim.Length > 0 Then
            sDireccion &= frm.TxtNumero2.Text.Trim & " "
        End If
        If frm.TxtManzana.Text.Trim.Length > 0 Then
            sDireccion &= "MZ " & frm.TxtManzana.Text.Trim & " LT " & frm.TxtLote.Text.Trim & " "
        End If
        If frm.CboNivel.SelectedValue > 0 Then
            sDireccion &= frm.CboNivel.Text & " " & frm.TxtNivel.Text.Trim & " "
        End If
        If frm.CboZona.SelectedValue > 0 Then
            sDireccion &= frm.CboZona.Text & " " & frm.TxtZona.Text.Trim & " "
        End If
        If frm.CboClasificacion.SelectedValue > 0 Then
            sDireccion &= frm.CboClasificacion.Text & " " & frm.TxtClasificacion.Text.Trim & " "
        End If
        If frm.CboDistrito.SelectedValue > 0 Then
            sDireccion &= frm.CboDistrito.Text
        End If
        aDireccion.direccion = sDireccion.Trim

        If frm.bDireccionModificada Or dtDireccion Is Nothing Then
            Dim dr As DataRow
            Me.cboDireccionNuevo.DataSource = Nothing
            Me.cboDireccionNuevo.Items.Clear()
            dtDireccion = New DataTable
            dtDireccion.Columns.Add(New DataColumn("iddireccion_consignado", GetType(Integer)))
            dtDireccion.Columns.Add(New DataColumn("direccion", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("id_via", GetType(Integer)))
            dtDireccion.Columns.Add(New DataColumn("via", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("numero", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("manzana", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("lote", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("id_nivel", GetType(Integer)))
            dtDireccion.Columns.Add(New DataColumn("nivel", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("id_zona", GetType(Integer)))
            dtDireccion.Columns.Add(New DataColumn("zona", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("id_clasificacion", GetType(Integer)))
            dtDireccion.Columns.Add(New DataColumn("clasificacion", GetType(String)))
            dtDireccion.Columns.Add(New DataColumn("iddepartamento", GetType(Integer)))
            dtDireccion.Columns.Add(New DataColumn("idprovincia", GetType(Integer)))
            dtDireccion.Columns.Add(New DataColumn("iddistrito", GetType(Integer)))

            dr = dtDireccion.NewRow
            dr("iddireccion_consignado") = 0
            dr("direccion") = " (SELECCIONE)"
            dr("id_via") = 0
            dr("via") = ""
            dr("numero") = ""
            dr("manzana") = ""
            dr("lote") = ""
            dr("id_nivel") = 0
            dr("nivel") = ""
            dr("id_zona") = 0
            dr("zona") = ""
            dr("id_clasificacion") = 0
            dr("clasificacion") = ""
            dr("iddepartamento") = 0
            dr("idprovincia") = 0
            dr("iddistrito") = 0
            dtDireccion.Rows.Add(dr)

            If frm.bDireccionModificada Then
                dr = dtDireccion.NewRow
                dr("iddireccion_consignado") = -1
                dr("direccion") = sDireccion.Trim
                dr("id_via") = frm.CboVia.SelectedValue
                dr("via") = frm.TxtVia.Text.Trim
                dr("numero") = frm.TxtNumero2.Text.Trim
                dr("manzana") = frm.TxtManzana.Text.Trim
                dr("lote") = frm.TxtLote.Text.Trim
                dr("id_nivel") = frm.CboNivel.SelectedValue
                dr("nivel") = frm.TxtNivel.Text.Trim
                dr("id_zona") = frm.CboZona.SelectedValue
                dr("zona") = frm.TxtZona.Text.Trim
                dr("id_clasificacion") = frm.CboClasificacion.SelectedValue
                dr("clasificacion") = frm.TxtClasificacion.Text.Trim
                dr("iddepartamento") = frm.CboDepartamento.SelectedValue
                dr("idprovincia") = frm.CboProvincia.SelectedValue
                dr("iddistrito") = frm.CboDistrito.SelectedValue
                dtDireccion.Rows.Add(dr)
            End If

            cboDireccionNuevo.DisplayMember = "direccion"
            cboDireccionNuevo.ValueMember = "id"
            Me.cboDireccionNuevo.DataSource = dtDireccion
            If cboDireccionNuevo.Items.Count > 1 Then
                Me.cboDireccionNuevo.SelectedIndex = 1
            Else
                Me.cboDireccionNuevo.SelectedIndex = 0
            End If
        End If
        'intComprobante = IIf(fnValidarRUC(Me.txtNumeroDocumento.Text.Trim), 1, 2)
        'ActualizaNumeroComprobante(intComprobante)
    End Sub
    Private Sub btnCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnCliente.Click
        Dim iFila As Integer = 0
        Dim sNumero As String = ""
        Dim iTipo As Integer
        Dim iDepartamento As Integer
        Dim iProvincia As Integer
        Dim iDistrito As Integer
        Dim iId_via As Integer
        Dim sVia As String = ""
        Dim sNumero2 As String = ""
        Dim sManzana As String = ""
        Dim sLote As String = ""
        Dim iId_Nivel As Integer
        Dim sNivel As String = ""
        Dim iId_Zona As Integer
        Dim sZona As String = ""
        Dim iId_Clasificacion As Integer
        Dim sClasificacion As String = ""
        Dim iTipo2 As Integer
        Dim sNumero3 As String = ""
        Dim sContacto As String = ""
        Dim sNombresCont As String = ""
        Dim sApCont As String = ""
        Dim sAmCont As String = ""
        Dim sCliente As String, sNombresCli As String, sApCli As String, sAmCli As String, sTelfCliente As String, sEmail As String
        Dim bEsCliente As Boolean = False

        Dim intOperacion As Integer = Me.cboOperacion.SelectedValue
        Dim frm As New FrmCliente2
        frm.iFicha = 1

        If Me.txtNombreNuevo.Text.Trim.Length > 0 Then
            With aCliente
                sNumero = .numero_documento
                sCliente = .razon_social
                iTipo = .tipo_documento
                sNombresCli = .nombres
                sApCli = .ap
                sAmCli = .am
                sTelfCliente = .telefono
                sEmail = .email
            End With
            With aDireccion
                Dim intFila As Integer = Me.cboDireccionNuevo.SelectedIndex
                .iddepartamento = dtDireccion.Rows(intFila).Item("iddepartamento")
                .idprovincia = dtDireccion.Rows(intFila).Item("idprovincia")
                .iddistrito = dtDireccion.Rows(intFila).Item("iddistrito")
                .id_via = dtDireccion.Rows(intFila).Item("id_via")
                .via = IIf(IsDBNull(dtDireccion.Rows(intFila).Item("via")), "", dtDireccion.Rows(intFila).Item("via"))
                .numero = IIf(IsDBNull(dtDireccion.Rows(intFila).Item("numero")), "", dtDireccion.Rows(intFila).Item("numero"))
                .manzana = IIf(IsDBNull(dtDireccion.Rows(intFila).Item("manzana")), "", dtDireccion.Rows(intFila).Item("manzana"))
                .lote = IIf(IsDBNull(dtDireccion.Rows(intFila).Item("lote")), "", dtDireccion.Rows(intFila).Item("lote"))
                .id_nivel = dtDireccion.Rows(intFila).Item("id_nivel")
                .nivel = IIf(IsDBNull(dtDireccion.Rows(intFila).Item("nivel")), "", dtDireccion.Rows(intFila).Item("nivel"))
                .id_zona = dtDireccion.Rows(intFila).Item("id_zona")
                .zona = IIf(IsDBNull(dtDireccion.Rows(intFila).Item("zona")), "", dtDireccion.Rows(intFila).Item("zona"))
                .id_clasificacion = dtDireccion.Rows(intFila).Item("id_clasificacion")
                .clasificacion = IIf(IsDBNull(dtDireccion.Rows(intFila).Item("clasificacion")), "", dtDireccion.Rows(intFila).Item("clasificacion"))
            End With
        End If
        frm.cargar(sNumero, sCliente, iTipo, sNombresCli, sApCli, sAmCli, aDireccion.iddepartamento, aDireccion.idprovincia, aDireccion.iddistrito, aDireccion.id_via, aDireccion.via, aDireccion.numero, _
                   aDireccion.manzana, aDireccion.lote, aDireccion.id_nivel, aDireccion.nivel, aDireccion.id_zona, aDireccion.zona, aDireccion.id_clasificacion, _
                   aDireccion.clasificacion, iTipo2, sNumero3, sContacto, sNombresCont, sApCont, sAmCont, sTelfCliente, bEsCliente, sEmail, False)

        frm.bClienteNuevo = Me.txtNombreNuevo.Text.Trim.Length = 0
        frm.bContactoNuevo = IIf(idcontacto > 0, False, True)
        'frm.iTipoComprobante = TipoComprobante

        frm.bContactoNuevo = False
        frm.BtnNuevo.Enabled = False
        frm.ChkTelefono.Checked = False
        frm.txtrazon.Enabled = False
        frm.intOpcion = 1

        If intOperacion = 1 Then
            frm.TipoDocumento = 3
        ElseIf intOperacion = 2 Then
            frm.TipoDocumento = 1
        ElseIf intOperacion = 5 Then
            frm.TipoDocumento = 1
        End If
        frm.CboTipoDocumento.Enabled = False

        frm.ShowDialog()
        Me.Cursor = Cursors.Default
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.AppStarting
            Me.CargarCliente(frm)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Sub Grabar()
        Try
            Dim dtImpresora As DataTable = Nothing
            '->Valida si va a emitir un comprobante adicional
            If tabComprobante.TabPages.IndexOf(tabComprobanteNuevo) > -1 Then
                '-->Valida la configuarcion de la impresora - jabanto
                dtImpresora = FEManager.buscarPrint()
                If dtImpresora Is Nothing Then
                    MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Cursor = Cursors.WaitCursor
            Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double, intComprobante As Integer

            Dim tipo As Integer, id_original As Integer, cliente As Integer, tipo_documento As Integer, numero_documento As String, nombres As String, _
                ap As String, am As String, razon_social As String, telefono As String, email As String, iddireccion As Integer, direccion As String, _
                idvia As Integer, via As String, numero As String, manzana As String, lote As String, idnivel As Integer, nivel As String, _
                idzona As Integer, zona As String, idclasificacion As Integer, clasificacion As String, iddepartamento As Integer, _
                idprovincia As Integer, iddistrito As Integer, agencia As Integer, forma_pago As Integer, tipo_tarjeta As Integer, _
                tarjeta As String, subtotal As Double, impuesto As Double, total As Double,
                domicilio As Double, cargo As Double, fz As Double, _
                usuario As Integer, ip As String
            Dim strMotivo As String

            Dim obj As New Cls_NotaCredito_LN
            Dim dataRowNota As DataRow
            intComprobante = Me.txtComprobante.Tag
            If tabComprobante.TabPages.IndexOf(tabNC) > -1 Then ' Emite Nota de credito
                dblSubtotal = CType(Me.txtSubtotal.Text, Double)
                dblImpuesto = CType(Me.txtImpuesto.Text, Double)
                dblTotal = CType(Me.txtTotal.Text, Double)
                dataRowNota = obj.GrabarNotaCredito(30, intComprobante, Me.dtpFechaNotaCredito.Value.ToShortDateString, Me.cboOperacion.SelectedValue, _
                                      Me.txtGlosaNotaCredito.Text.Trim, dtoUSUARIOS.iIDAGENCIAS, dblSubtotal, dblImpuesto, dblTotal, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Else 'Baja
                'hlamas 01-06-2016
                'Valida si comprobante puede ser anulado
                strMotivo = Me.cboOperacion.Text
                Dim strFechaComprobante As String = Me.lblFecha.Text 'DateAdd(DateInterval.Day, 1, CType(Me.lblFecha.Text, Date))
                Dim strComprobante As String = Me.txtComprobante.Text.Trim
                Dim intPosicion As Integer = InStr(strComprobante, "-")
                'Dim strSerie As String = IIf(iTipo = 1, "F", "B") & strComprobante.Substring(0, intPosicion - 1)
                Dim strSerie As String = strComprobante.Substring(0, intPosicion - 1)
                Dim strNumero As String = strComprobante.Substring(intPosicion)
                strNumero = strNumero.PadLeft(8, "0")
                Dim intTipo As Integer = IIf(Me.cboTipoComprobante.SelectedIndex = 0, 1, 2)
                Dim strTipo As String = IIf(intTipo = 1, "01", "03")
                Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFechaComprobante, strSerie, strNumero, strMotivo)
                If Not blnAnulable Then
                    Cursor = Cursors.Default
                    MessageBox.Show("El Comprobante no puede ser Anulado F.E.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End If

            tipo = Me.cboTipoComprobanteNuevo.SelectedIndex
            With aCliente
                cliente = aCliente.id
                tipo_documento = aCliente.tipo_documento
                numero_documento = aCliente.numero_documento
                nombres = aCliente.nombres
                ap = aCliente.ap
                am = aCliente.am
                razon_social = aCliente.razon_social
                telefono = aCliente.telefono
                email = aCliente.email
            End With

            'Verifica si operacion es por refacturacion
            Dim dataRowFactura As DataRow = Nothing
            If tabComprobante.TabPages.IndexOf(tabComprobanteNuevo) > -1 Then
                tipo = Me.cboTipoComprobanteNuevo.SelectedIndex
                With aCliente
                    cliente = aCliente.id
                    tipo_documento = aCliente.tipo_documento
                    numero_documento = aCliente.numero_documento
                    nombres = aCliente.nombres
                    ap = aCliente.ap
                    am = aCliente.am
                    razon_social = aCliente.razon_social
                    telefono = aCliente.telefono
                    email = aCliente.email
                End With

                dblSubtotal = CType(Me.txtSubtotalNuevo.Text, Double)
                dblImpuesto = CType(Me.txtImpuestoNuevo.Text, Double)
                dblTotal = CType(Me.txtTotalNuevo.Text, Double)

                dataRowFactura = obj.GrabarFactura(Me.cboTipoComprobanteNuevo.SelectedIndex, intComprobante, Me.dtpFechaNotaCredito.Value.ToShortDateString, "", _
                cliente, tipo_documento, numero_documento, nombres, ap, am, razon_social, telefono, email, _
                0, "", 0, "", "", "", "", 0, "", 0, "", 0, "", 0, 0, 0, "", dtoUSUARIOS.iIDAGENCIAS, dblSubtotal, dblImpuesto, dblTotal, Me.cboOperacion.SelectedValue, 2, _
                dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            End If

            If tabComprobante.TabPages.IndexOf(tabNC) = -1 Then 'Genera Baja
                'obj.AnularComprobante(intComprobante, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                AnularComprobante(intComprobante, strMotivo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.m_iIdRol, dtoUSUARIOS.IP)
            End If

            If dtoUSUARIOS.IP = "192.168.50.47" Then
                Cursor = Cursors.Default
                Return
            End If

            '========================================================================================
            '-->GENERA LA NOTA DE CREDITO Y LA FACTURA Y/O BOLETA ELECTRONICA - jabanto -07/06/2016
            '========================================================================================
            'emitirComprobantesElectronicos(dataRowNota, dataRowFactura, tipo_documento, numero_documento, razon_social, tipo, dtImpresora)

            Cursor = Cursors.Default
            Me.tabNotaCredito.SelectedTab = Me.tabNotaCredito.TabPages("tabLista")
            Me.BuscarNotaCredito()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AnularComprobante(ByVal comprobante As String, motivo As String, ByVal usuario As Integer, ByVal rol As Integer, ip As String)
        Try
            Dim obj As New dtoGuia
            obj.AnularComprobante(comprobante, motivo, usuario, rol, ip)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        BuscarNotaCredito()
    End Sub

    Sub BuscarNotaCredito()
        Try
            Cursor = Cursors.WaitCursor
            Dim strInicio As String, strFin As String, strSerie As String, strNumero As String, strNumeroDocumento As String, strCliente As String
            Dim intOpcion As Integer = 0, intTipo As Integer

            intTipo = IIf(Me.rbtFactura.Checked, 1, 2)
            Dim strNroDoc As String() = Split(Me.txtNumeroComprobante.Text.Trim, "-")
            If strNroDoc.Length > 1 Then
                If strNroDoc(0).Trim.Length > 1 And Val(strNroDoc(1)) > 0 Then
                    strSerie = strNroDoc(0)
                    strNumero = strNroDoc(1)
                Else
                    strSerie = "0"
                    strNumero = "0"
                End If
            Else
                If strNroDoc.Length = 1 Then
                    strSerie = "0"
                    strNumero = strNroDoc(0)
                    If strNumero = "" Then strNumero = "0"
                Else
                    strSerie = "0"
                    strNumero = "0"
                End If
            End If
            strInicio = Me.dtpFechaInicio.Value.ToShortDateString
            strFin = Me.dtpFechaFin.Value.ToShortDateString
            If Val(strNumero.Trim) > 0 Then
                intOpcion = 1
            End If

            Dim obj As New Cls_NotaCredito_LN
            Dim dt As DataTable = obj.ListarNotaCredito(strInicio, strFin, intTipo, strSerie, strNumero, intOpcion)
            Me.dgvLista.DataSource = dt

            Me.tsbConsultar.Enabled = Me.dgvLista.Rows.Count > 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub rbtFactura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtFactura.CheckedChanged
        Me.txtNumeroComprobante.Focus()
    End Sub

    Private Sub rbtBoleta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtBoleta.CheckedChanged
        Me.txtNumeroComprobante.Focus()
    End Sub

    Sub LimpiarCliente()
        Me.txtNombreNuevo.Text = ""

        Me.cboDireccionNuevo.DataSource = Nothing
        Me.cboDireccionNuevo.Items.Clear()
        Me.cboDireccionNuevo.Items.Add(" (SELECCIONE)")
        Me.cboDireccionNuevo.SelectedIndex = 0
        dtDireccion = Nothing
    End Sub

    Sub MostrarCliente(dt As DataTable)
        With aCliente
            .id = dt.Rows(0).Item("idpersona").ToString
            .razon_social = dt.Rows(0).Item("razon_social").ToString.Trim
            .tipo_documento = dt.Rows(0).Item("tipo").ToString
            .numero_documento = dt.Rows(0).Item("nu_docu_suna").ToString
            .nombres = dt.Rows(0).Item("nombres").ToString
            .ap = dt.Rows(0).Item("ap").ToString
            .am = dt.Rows(0).Item("am").ToString
            .telefono = dt.Rows(0).Item("telefono").ToString
            .email = dt.Rows(0).Item("email").ToString
        End With
        Me.txtNumeroDocumentoNuevo.Text = dt.Rows(0).Item("nu_docu_suna").ToString.Trim
        Me.txtNombreNuevo.Text = dt.Rows(0).Item("razon_social").ToString.Trim

        MostrarDireccion(dt.Rows(0).Item("idpersona").ToString.Trim)

        grbCliente.Tag = dt.Rows(0) '-->Gurda el objeto dataRow con todos sus atributos - jabanto - 07/06/2015
    End Sub

    Sub MostrarDireccion(cliente As Integer)
        Dim obj As New Cls_Autorizacion_LN

        dtDireccion = obj.ListarDireccion(cliente)
        With Me.cboDireccionNuevo
            .ValueMember = "id"
            .DisplayMember = "direccion"
            .DataSource = dtDireccion
            .SelectedValue = 0
        End With

        With aDireccion
            .id = dtDireccion.Rows(0).Item("id")
            .direccion = dtDireccion.Rows(0).Item("direccion")
            .id_via = dtDireccion.Rows(0).Item("id_via")
            .via = IIf(IsDBNull(dtDireccion.Rows(0).Item("via")), "", dtDireccion.Rows(0).Item("via"))
            .numero = IIf(IsDBNull(dtDireccion.Rows(0).Item("numero")), "", dtDireccion.Rows(0).Item("numero"))
            .manzana = IIf(IsDBNull(dtDireccion.Rows(0).Item("manzana")), "", dtDireccion.Rows(0).Item("manzana"))
            .lote = IIf(IsDBNull(dtDireccion.Rows(0).Item("lote")), "", dtDireccion.Rows(0).Item("lote"))
            .id_nivel = dtDireccion.Rows(0).Item("id_nivel")
            .nivel = IIf(IsDBNull(dtDireccion.Rows(0).Item("nivel")), "", dtDireccion.Rows(0).Item("nivel"))
            .id_zona = dtDireccion.Rows(0).Item("id_zona")
            .zona = IIf(IsDBNull(dtDireccion.Rows(0).Item("zona")), "", dtDireccion.Rows(0).Item("zona"))
            .id_clasificacion = dtDireccion.Rows(0).Item("id_clasificacion")
            .clasificacion = IIf(IsDBNull(dtDireccion.Rows(0).Item("clasificacion")), "", dtDireccion.Rows(0).Item("clasificacion"))
            .iddepartamento = dtDireccion.Rows(0).Item("iddepartamento")
            .idprovincia = dtDireccion.Rows(0).Item("idprovincia")
            .iddistrito = dtDireccion.Rows(0).Item("iddistrito")
        End With
    End Sub

    Private Sub txtNumeroDocumentoNuevo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDocumentoNuevo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dim obj As New Cls_FacturaAdicional_LN
            Dim strNumeroDocumento As String

            strNumeroDocumento = Me.txtNumeroDocumentoNuevo.Text.Trim
            Dim dt As DataTable = obj.BuscarCliente(strNumeroDocumento)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("El Cliente no Existe", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.LimpiarCliente()
                Dim frm As FrmCliente2 = New FrmCliente2
                'bClienteCredito = False
                frm.bClienteNuevo = True 'bClienteNuevo
                frm.iFicha = 1
                frm.TxtNumero.Text = Me.txtNumeroDocumento.Text.Trim
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.LimpiarCliente()
                    CargarCliente(frm)
                End If
            Else
                MostrarCliente(dt)
            End If
            'intComprobante = IIf(fnValidarRUC(Me.txtNumeroDocumento.Text.Trim), 1, 2)
            'ActualizaNumeroComprobante(intComprobante)
        End If

    End Sub

    Private Sub txtNumeroDocumentoNuevo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroDocumentoNuevo.TextChanged
        LimpiarCliente()
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        With Me.dgvLista
            Dim strTipo As String = .CurrentRow.Cells("tipo_nc").Value
            Dim strComprobante As String = .CurrentRow.Cells("nc").Value

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de anular el comprobante " & strTipo & " " & strComprobante & "?", "Nota de Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Anular(.CurrentRow.Cells("id_tipo").Value, .CurrentRow.Cells("id_ref").Value)
            End If
        End With
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbConsultar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        Me.tsbAnular.Enabled = dgvLista.Rows(e.RowIndex).Cells("id_tipo").Value = 30
    End Sub

    Sub Anular(tipo As Integer, comprobante As Integer)
        Try
            Dim obj As New Cls_NotaCredito_LN
            obj.AnularNotaCredito(tipo, comprobante, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            BuscarNotaCredito()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbConsultar_Click(sender As System.Object, e As System.EventArgs) Handles tsbConsultar.Click
        Dim intTipo As Integer, intComprobante As Integer

        intTipo = Me.dgvLista.CurrentRow.Cells("tipo").Value
        intComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
        Consultar(intTipo, intComprobante)
    End Sub

    Sub Consultar(tipo As Integer, comprobante As Integer)
        Try
            Me.LimpiarComprobante()
            Me.LimpiarNotaCredito()
            Me.LimpiarComprobanteNuevo()

            Dim obj As New Cls_NotaCredito_LN
            Dim ds As DataSet = obj.ListarComprobante(tipo, comprobante)
            Mostrar(ds)

            Me.tsbConsultar.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.cboOperacion.Enabled = False
            Me.cboTipoComprobante.Enabled = False
            Me.txtComprobante.Enabled = False
            Me.dtpFechaNotaCredito.Enabled = False
            Me.txtGlosaNotaCredito.Enabled = False
            Me.grbClienteNuevo.Enabled = False
            Me.dtpFechaNuevo.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Mostrar(ds As DataSet)
        With ds.Tables(0)
            Me.cboTipoComprobante.SelectedIndex = .Rows(0).Item("tipo") - 1
            Me.txtComprobante.Text = .Rows(0).Item("comprobante")
            Me.lblFecha.Text = .Rows(0).Item("fecha")
            Me.lblSubtotal.Text = Format(.Rows(0).Item("subtotal"), "###,###,###0.00")
            Me.lblImpuesto.Text = Format(.Rows(0).Item("impuesto"), "###,###,###0.00")
            Me.lblTotal.Text = Format(.Rows(0).Item("total"), "###,###,###0.00")
            Me.lblNumeroDocumento.Text = .Rows(0).Item("numero_documento")
            Me.lblRazonSocial.Text = .Rows(0).Item("razon_social")
        End With

        With ds.Tables(1)
            Me.cboOperacion.SelectedValue = .Rows(0).Item("operacion")
            Me.dtpFechaNotaCredito.Value = .Rows(0).Item("fecha")
            Me.lblSerie.Text = .Rows(0).Item("serie")
            Me.lblNumero.Text = .Rows(0).Item("numero")
            Me.txtGlosaNotaCredito.Text = .Rows(0).Item("glosa")
            Me.txtSubtotal.Text = Format(.Rows(0).Item("subtotal"), "###,###,###0.00")
            Me.txtImpuesto.Text = Format(.Rows(0).Item("impuesto"), "###,###,###0.00")
            Me.txtTotal.Text = Format(.Rows(0).Item("total"), "###,###,###0.00")
        End With

        If ds.Tables(2).Rows.Count > 0 Then
            With ds.Tables(2)
                Me.cboTipoComprobanteNuevo.SelectedIndex = .Rows(0).Item("tipo")
                Me.dtpFechaNuevo.Value = .Rows(0).Item("fecha")
                Me.lblSerieNuevo.Text = .Rows(0).Item("serie")
                Me.lblNumeroNuevo.Text = .Rows(0).Item("numero")
                Me.txtNumeroDocumentoNuevo.Text = .Rows(0).Item("numero_documento")
                Me.txtNombreNuevo.Text = .Rows(0).Item("razon_social")
                Me.cboDireccionNuevo.SelectedValue = .Rows(0).Item("direccion")

                Me.txtSubtotalNuevo.Text = Format(.Rows(0).Item("subtotal"), "###,###,###0.00")
                Me.txtImpuestoNuevo.Text = Format(.Rows(0).Item("impuesto"), "###,###,###0.00")
                Me.txtTotalNuevo.Text = Format(.Rows(0).Item("total"), "###,###,###0.00")
            End With
        End If
        RemoveHandler Me.tabNotaCredito.SelectedIndexChanged, AddressOf Me.tabNotaCredito_SelectedIndexChanged
        Me.tabNotaCredito.SelectedTab = Me.tabNotaCredito.TabPages("tabEmision")
        Me.tabComprobante.SelectedTab = Me.tabComprobante.TabPages("tabNC")
        AddHandler Me.tabNotaCredito.SelectedIndexChanged, AddressOf Me.tabNotaCredito_SelectedIndexChanged
    End Sub

    Private Sub tabNotaCredito_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabNotaCredito.SelectedIndexChanged
        If tabNotaCredito.SelectedTab Is tabNotaCredito.TabPages("tabLista") Then
            Me.tsbGrabar.Enabled = False
            Me.tsbConsultar.Enabled = Me.dgvLista.Rows.Count > 0
            Me.tsbAnular.Enabled = Me.dgvLista.Rows.Count > 0
        ElseIf tabNotaCredito.SelectedTab Is tabNotaCredito.TabPages("tabEmision") Then
            Me.cboOperacion.Enabled = True
            Me.cboTipoComprobante.Enabled = True
            Me.txtComprobante.Enabled = True
            Me.dtpFechaNotaCredito.Enabled = True
            Me.txtGlosaNotaCredito.Enabled = True
            Me.grbClienteNuevo.Enabled = True
            Me.dtpFechaNuevo.Enabled = True

            Me.Limpiar()
            Me.LimpiarComprobante()
            Me.LimpiarNotaCredito()
            Me.LimpiarComprobanteNuevo()

            Me.tsbGrabar.Enabled = True
            Me.tsbConsultar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.txtComprobante.Focus()
        End If
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        If tabNotaCredito.SelectedTab Is tabNotaCredito.TabPages("tabLista") Then
            tabNotaCredito.SelectedTab = Me.tabNotaCredito.TabPages("tabEmision")
        Else
            tabNotaCredito_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Public Function ValidaNumero2(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[-0-9\b]") '("^\d+$")  
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero2 = True
        Else
            ValidaNumero2 = False
        End If
    End Function

    Private Sub txtNumeroComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroComprobante.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroComprobante.TextChanged

    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaInicio.ValueChanged

    End Sub

    Private Sub txtGlosaNotaCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGlosaNotaCredito.TextChanged

    End Sub
End Class
