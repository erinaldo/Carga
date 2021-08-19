Imports INTEGRACION_LN

Public Class frmNotaCreditoCanje
#Region "Formatear Grid"
    Sub FormatearDGVDetalle()
        With dgvDetalle
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Fecha" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "Tipo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .HeaderText = "Nº Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .HeaderText = "Total" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_fecha, col_tipo, col_comprobante, col_total)
        End With
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
            Dim col_numero_solicitud As New DataGridViewTextBoxColumn
            With col_numero_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Fecha" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "Tipo" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .HeaderText = "Nº Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .HeaderText = "Origen" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .HeaderText = "Destino" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .HeaderText = "Nº Documento" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .HeaderText = "Cliente" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_adicional As New DataGridViewTextBoxColumn
            With col_adicional
                .Name = "adicional" : .DataPropertyName = "adicional" : .DisplayIndex = x : .HeaderText = "adicional" : .Visible = False
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .HeaderText = "Operación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idoperacion As New DataGridViewTextBoxColumn
            With col_idoperacion
                .Name = "idoperacion" : .DataPropertyName = "idoperacion"
                .DisplayIndex = x : .HeaderText = "idoperación" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_comprobante_final As New DataGridViewTextBoxColumn
            With col_tipo_comprobante_final
                .Name = "tipo_comprobante_final" : .DataPropertyName = "tipo_comprobante_final"
                .DisplayIndex = x : .HeaderText = "tipo_comprobante_final" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_operacion As New DataGridViewTextBoxColumn
            With col_tipo_operacion
                .Name = "tipo_operacion" : .DataPropertyName = "tipo_operacion"
                .DisplayIndex = x : .HeaderText = "tipo_operacion" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_codigo_sunat As New DataGridViewTextBoxColumn
            With col_codigo_sunat
                .Name = "codigo_sunat" : .DataPropertyName = "codigo_sunat"
                .DisplayIndex = x : .HeaderText = "codigo_sunat" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_descripcion_sunat As New DataGridViewTextBoxColumn
            With col_descripcion_sunat
                .Name = "descripcion_sunat" : .DataPropertyName = "descripcion_sunat"
                .DisplayIndex = x : .HeaderText = "descripcion_sunat" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .HeaderText = "Estado" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .HeaderText = "idestado" : .Visible = False
            End With
            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .HeaderText = "id_det" : .Visible = False
            End With
            x += +1
            Dim col_id_solicitud As New DataGridViewTextBoxColumn
            With col_id_solicitud
                .Name = "id_solicitud" : .DataPropertyName = "id_solicitud" : .DisplayIndex = x : .HeaderText = "id_solicitud" : .Visible = False
            End With
            x += +1
            Dim col_remitente As New DataGridViewTextBoxColumn
            With col_remitente
                .Name = "remitente" : .DataPropertyName = "remitente" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_consignado As New DataGridViewTextBoxColumn
            With col_consignado
                .Name = "consignado" : .DataPropertyName = "consignado" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_idtipo_entrega As New DataGridViewTextBoxColumn
            With col_idtipo_entrega
                .Name = "idtipo_entrega" : .DataPropertyName = "idtipo_entrega" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_direccionEntrega As New DataGridViewTextBoxColumn
            With col_direccionEntrega
                .Name = "direccion_Entrega" : .DataPropertyName = "direccion_Entrega" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_direccion_origen As New DataGridViewTextBoxColumn
            With col_direccion_origen
                .Name = "direccion_origen" : .DataPropertyName = "direccion_origen" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_idpersona As New DataGridViewTextBoxColumn
            With col_idpersona
                .Name = "idpersona" : .DataPropertyName = "idpersona" : .DisplayIndex = x : .HeaderText = "idpersona" : .Visible = False
            End With
            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente" : .DisplayIndex = x : .HeaderText = "cuenta_corriente" : .Visible = False
            End With

            .Columns.AddRange(col_id, col_numero_solicitud, col_idtipo, col_fecha, col_tipo, col_comprobante, col_total, col_origen, col_destino, col_numero, col_cliente, col_adicional, col_operacion, col_idoperacion, _
                              col_remitente, col_consignado, col_idtipo_entrega, col_direccionEntrega, col_producto, col_direccion_origen, _
                              col_tipo_comprobante_final, col_tipo_operacion, col_codigo_sunat, col_descripcion_sunat, col_estado, col_idestado, col_id_det, col_id_solicitud, col_idpersona, col_cuenta_corriente)
        End With
    End Sub
#End Region

    Private Sub frmNotaCreditoCanje_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Sub Limpiar()
        Me.cboTipoComprobante.SelectedIndex = 0
        Me.cboEstado.SelectedIndex = 1
        Me.btnCanjear.Enabled = False
    End Sub

    Sub Inicio()
        Dim obj As New UtilData_LN
        Dim dt As DataTable

        dt = obj.ListarCiudad()
        With cboOrigen
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "nombre_unidad"
            .ValueMember = "idunidad_agencia"
            .SelectedValue = dtoUSUARIOS.IdUnidadAgenciaReal
        End With

        With cboDestino
            .DataSource = Nothing
            .DataSource = dt.Copy
            .DisplayMember = "nombre_unidad"
            .ValueMember = "idunidad_agencia"
            .SelectedValue = 0
        End With

        FormatearDGVLista()
        FormatearDGVDetalle()

        Limpiar()
        'ActualizaNumeroComprobante(2)
    End Sub

    Sub Buscar()
        Try
            Cursor = Cursors.WaitCursor
            Dim strInicio As String, strFin As String, strSerie As String, strNumero As String, strNumeroDocumento As String, strCliente As String
            Dim intOpcion As Integer = 0

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
            strNumeroDocumento = IIf(Me.txtCodigoCliente.Text.Trim <> "", Me.txtCodigoCliente.Text.Trim, "0")
            strCliente = IIf(Me.txtCliente.Text.Trim <> "", Me.txtCliente.Text.Trim, "")
            If Val(strNumero.Trim) > 0 Then
                intOpcion = 1
            End If

            Dim intEstado As Integer = Me.cboEstado.SelectedIndex - 1
            Dim obj As New Cls_NotaCredito_LN
            Dim dt As DataTable = obj.BuscarComprobante(strInicio, strFin, Me.cboOrigen.SelectedValue, Me.cboDestino.SelectedValue, _
                                                      strNumero, strSerie, strNumeroDocumento, strCliente, intOpcion, Me.cboTipoComprobante.SelectedIndex, intEstado)
            Me.dgvLista.DataSource = dt

            If Me.dgvLista.Rows.Count = 0 Then
                Me.btnCanjear.Enabled = False
                Me.dgvDetalle.DataSource = Nothing
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub txtNumeroComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnBuscar_Click(Nothing, Nothing)
        Else
            If ValidaNumero2(e.KeyChar) Then
                e.Handled = False
            ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnBuscar_Click(Nothing, Nothing)
        Else
            If Not ValidaNumero2(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub ListarComprobante(comprobante As Integer)
        Dim obj As New Cls_NotaCredito_LN
        With Me.dgvDetalle
            .DataSource = obj.ListarComprobante(comprobante)
        End With
    End Sub

    Function ListarDetalle(id As Integer, operacion As Integer) As DataTable
        Try
            Dim obj As New Cls_Autorizacion_LN
            Return obj.ListarDatos(id, operacion)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub AnularComprobante(ByVal comprobante As String, motivo As String, ByVal usuario As Integer, ByVal rol As Integer, ip As String)
        Try
            Dim obj As New dtoGuia
            obj.AnularComprobante(comprobante, motivo, usuario, rol, ip)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnCanjear_Click(sender As System.Object, e As System.EventArgs) Handles btnCanjear.Click
        Try
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            objLIQUI_TURNOS = Nothing

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("Comprobante " & Me.dgvLista.CurrentRow.Cells("tipo").Value & " " & Me.dgvLista.CurrentRow.Cells("comprobante").Value & _
                                           Chr(13) & Chr(13) & _
                                         "¿Está seguro de realizar el Canje?", "Canje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Canjear()
                Me.btnBuscar_Click(Nothing, Nothing)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Canjear()
        Try
            Dim dtImpresora As DataTable = Nothing
            '->Valida si va a emitir un comprobante adicional
            If dgvLista.CurrentRow.Cells("tipo_operacion").Value = 3 And dgvLista.CurrentRow.Cells("tipo_comprobante_final").Value > 0 Then 'tabComprobante.TabPages.IndexOf(tabComprobanteNuevo) > -1 Then
                '-->Valida la configuarcion de la impresora - jabanto
                dtImpresora = FEManager.buscarPrint()
                'If dtImpresora Is Nothing Then
                'Cursor = Cursors.Default
                'MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Exit Sub
                'End If
            End If

            Dim intComprobante As Integer, strFecha As String, intOperacion As Integer, strGlosa As String
            Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double
            Dim obj As New Cls_NotaCredito_LN
            Dim dataRowNota
            Dim noteTotal As Double
            Dim noteSubTotal As Double
            Dim noteImpuesto As Double
            Dim intUsuario As Integer, intAgencia As Integer, strIp As String
            intUsuario = dtoUSUARIOS.IdLogin 'Me.dgvLista.CurrentRow.Cells("usuario_liquidacion").Value
            intAgencia = dtoUSUARIOS.iIDAGENCIAS 'Me.dgvLista.CurrentRow.Cells("idagencia").Value
            strIp = dtoUSUARIOS.IP 'Me.dgvLista.CurrentRow.Cells("ip").Value

            'Determina si se emite Nota de Credito o Baja segun fecha de comprobante
            'Si fecha del servidor-fecha de comprobante es menor o igual a 3 dias baja si no nota de credito
            Dim intOrigen As Integer
            Dim strFechaComprobante As String = Me.dgvLista.CurrentRow.Cells("fecha").Value 'Me.lblFechaComprobanteAprobacion.Text 
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
            Dim strMotivo As String = ""
            If intOrigen = 2 Then 'Nota de Credito
                'Genera Nota de credito
                intComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
                strFecha = Format(Now, "dd/MM/yyyy")
                intOperacion = Me.dgvLista.CurrentRow.Cells("idoperacion").Value
                strGlosa = Me.dgvLista.CurrentRow.Cells("operacion").Value

                dblTotal = Me.dgvLista.CurrentRow.Cells("total").Value
                dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                dblImpuesto = dblTotal - dblSubtotal

                dblTotal = Format(dblTotal * -1, "0.00")
                dblSubtotal = Format(dblSubtotal * -1, "0.00")
                dblImpuesto = Format(dblImpuesto * -1, "0.00")

                noteTotal = dblTotal * -1
                noteSubTotal = dblSubtotal * -1
                noteImpuesto = dblImpuesto * -1
                dataRowNota = obj.GrabarNotaCredito(30, intComprobante, strFecha, intOperacion, _
                                      strGlosa, intAgencia, dblSubtotal, dblImpuesto, dblTotal, _
                                      intUsuario, strIp, Me.dgvLista.CurrentRow.Cells("cuenta_corriente").Value)
            ElseIf intOrigen = 1 Then 'Baja
                'hlamas 01-06-2016
                'Valida si comprobante puede ser anulado
                strMotivo = Me.dgvLista.CurrentRow.Cells("operacion").Value
                Dim strComprobante As String = Me.dgvLista.CurrentRow.Cells("comprobante").Value
                Dim intPosicion As Integer = InStr(strComprobante, "-")
                'Dim strSerie As String = IIf(iTipo = 1, "F", "B") & strComprobante.Substring(0, intPosicion - 1)
                Dim strSerie As String = strComprobante.Substring(0, intPosicion - 1)
                Dim strNumero As String = strComprobante.Substring(intPosicion)
                strNumero = strNumero.PadLeft(8, "0")
                Dim intTipo As Integer = Me.dgvLista.CurrentRow.Cells("idtipo").Value
                Dim strTipo As String = IIf(intTipo = 1, "01", "03")
                Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFechaComprobante, strSerie, strNumero, strMotivo)
                If Not blnAnulable Then
                    Cursor = Cursors.Default
                    'MessageBox.Show("El Comprobante no puede ser Anulado F.E.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Throw New Exception("El Comprobante no puede ser Anulado F.E.")
                    Return
                End If
            End If

            'Genera Comprobante adicional
            Dim dataRowFactura As DataRow
            With Me.dgvLista
                If dgvLista.CurrentRow.Cells("tipo_operacion").Value = 3 Then 'para operaciones que generan refacturacion
                    If dgvLista.CurrentRow.Cells("tipo_comprobante_final").Value > 0 Then 'si operacion aun no genera comprobante adicional
                        Dim dt As DataTable = ListarDetalle(.CurrentRow.Cells("id_det").Value, .CurrentRow.Cells("idoperacion").Value)
                        If dt.Rows.Count > 0 Then
                            intComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
                            intOperacion = Me.dgvLista.CurrentRow.Cells("idoperacion").Value
                            dblTotal = Me.dgvLista.CurrentRow.Cells("total").Value
                            dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                            dblImpuesto = dblTotal - dblSubtotal
                            dblTotal = Format(dblTotal, "0.00")
                            dblSubtotal = Format(dblSubtotal, "0.00")
                            dblImpuesto = Format(dblImpuesto, "0.00")
                            If dgvLista.CurrentRow.Cells("idoperacion").Value = 6 Then 'cambio razon social
                                dataRowFactura = obj.GrabarFactura(Me.dgvLista.CurrentRow.Cells("idtipo").Value, Me.dgvLista.CurrentRow.Cells("id").Value, Format(Now, "dd/MM/yyyy"), "", _
                                dt.Rows(1).Item("id"), 0, "", "", "", "", dt.Rows(1).Item("dato"), "", "", _
                                0, "", 0, "", "", "", "", 0, "", 0, "", 0, "", 0, 0, 0, "", intAgencia, dblSubtotal, dblImpuesto, dblTotal, _
                                .CurrentRow.Cells("idoperacion").Value, intOrigen, intUsuario, strIp)
                            ElseIf dgvLista.CurrentRow.Cells("idoperacion").Value = 11 Then 'cambio direccion cliente
                                dataRowFactura = obj.GrabarFactura(Me.dgvLista.CurrentRow.Cells("idtipo").Value, Me.dgvLista.CurrentRow.Cells("id").Value, Format(Now, "dd/MM/yyyy"), "", _
                                Me.dgvLista.CurrentRow.Cells("idpersona").Value, 0, "", "", "", "", "", "", "", _
                                -1, dt.Rows(1).Item("dato"), 0, "", "", "", "", 0, "", 0, "", 0, "", dt.Rows(3).Item("id"), dt.Rows(4).Item("id"), dt.Rows(5).Item("id"), _
                                dt.Rows(2).Item("dato"), intAgencia, dblSubtotal, dblImpuesto, dblTotal, _
                                .CurrentRow.Cells("idoperacion").Value, intOrigen, intUsuario, strIp)
                            End If
                        End If
                    Else 'operacion con comprobante adicional ya generado
                        intComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
                        intOperacion = Me.dgvLista.CurrentRow.Cells("idoperacion").Value
                        Dim dt As DataTable = ListarDetalle(.CurrentRow.Cells("id_det").Value, .CurrentRow.Cells("idoperacion").Value)
                        If dt.Rows.Count > 0 Then
                            Dim intComprobanteRef As Integer
                            intComprobanteRef = CType(dt.Rows(3).Item("id"), Integer)
                            obj.AmarrarComprobante(intComprobante, intComprobanteRef, intOperacion)
                        End If
                    End If
                End If
            End With

            If intOrigen = 1 Then 'Genera Baja
                intComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
                'obj.AnularComprobante(intComprobante, intUsuario, strIp)
                AnularComprobante(intComprobante, strMotivo, intUsuario, dtoUSUARIOS.m_iIdRol, dtoUSUARIOS.IP)
            End If

            ActualizarSolicitud(dgvLista.CurrentRow.Cells("id_solicitud").Value)

            Return
            If dtoUSUARIOS.IP = "192.168.50.47" Then
                Return
            End If

            '========================================================================================
            '-->GENERA LA NOTA DE CREDITO Y LA FACTURA Y/O BOLETA ELECTRONICA - jabanto - 07/06/2016
            '========================================================================================
            'Busca el Comprobante original
            Dim comprobanteReferenciaID As String = dgvLista.CurrentRow.Cells("idtipo").Value
            Dim comprobanteReferenciaNumero As String = dgvLista.CurrentRow.Cells("comprobante").Value
            Dim comprobanteReferenciaFecha As String = dgvLista.CurrentRow.Cells("fecha").Value

            '-->Nota de credito
            '******************************
            Dim fenote As FENota = Nothing
            If Not (dataRowNota Is Nothing) Then
                Dim fecliente As New FECliente
                fecliente.tipoDocumentoID = dataRowNota(3).ToString
                fecliente.numeroDocumento = dataRowNota(4).ToString
                fecliente.nombres = dataRowNota(5).ToString
                If Not (IsDBNull(dataRowNota(6))) Then _
                    fecliente.direccion = dataRowNota(6).ToString

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
                fenote.igv = noteImpuesto
                fenote.subTotal = noteSubTotal
                fenote.total = noteTotal
                fenote.tipoNota = Me.dgvLista.CurrentRow.Cells("codigo_sunat").Value 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("codigo_sunat")
                fenote.descripcionTipoNota = Me.dgvLista.CurrentRow.Cells("descripcion_sunat").Value 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("descripcion_sunat")
                fenote.totalLentras = ConvercionNroEnLetras(fenote.total)
                fenote.descripcionSustento = strGlosa.Trim.ToUpper()
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
                    '**********************************************************************
                    Dim feventa As FEVenta = Nothing
                    If Not (dataRowFactura Is Nothing) Then
                        Dim FECliente As New FECliente
                        FECliente.tipoDocumentoID = dataRowFactura(3).ToString()
                        FECliente.numeroDocumento = dataRowFactura(4).ToString()
                        FECliente.nombres = dataRowFactura(5).ToString()
                        If Not (IsDBNull(dataRowFactura(6))) Then _
                            FECliente.direccion = dataRowFactura(6).ToString()

                        feventa = New FEVenta
                        feventa.cliente = FECliente
                        feventa.isCredito = False
                        feventa.numeroSerie = dataRowFactura(0).ToString()
                        feventa.numeroCorrelativo = dataRowFactura(1).ToString()
                        feventa.isMonedaSoles = True
                        feventa.fechaEmision = FechaServidor()
                        feventa.tipoComprobanteID = dataRowFactura(7).ToString()
                        feventa.opGravada = Convert.ToDouble(dblTotal)
                        feventa.igv = Convert.ToDouble(dblImpuesto)
                        feventa.total = Convert.ToDouble(dblTotal)
                        feventa.totalLetras = ConvercionNroEnLetras(feventa.total)
                        feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
                        feventa.usuarioEmision = dtoUSUARIOS.NameLogin
                        feventa.id = dataRowFactura(2)
                        feventa.tabla = "T_FACTURA_CONTADO"

                        '-->Basicamente para completar la impresion
                        Dim obj2 As New Cls_NotaCredito_LN
                        Dim dt2 As DataTable = obj2.ListarDatosComprobante(feventa.id)
                        If dt2.Rows.Count > 0 Then
                            feventa.remitenete = dt2.Rows(0).Item("razon_social")
                            feventa.origen = dt2.Rows(0).Item("origen")
                            feventa.destino = dt2.Rows(0).Item("destino")
                            feventa.consignado = dt2.Rows(0).Item("consignado")
                            feventa.tipoEntrega = dt2.Rows(0).Item("tipo_entrega")
                            feventa.direccionEntrega = dt2.Rows(0).Item("direccion_entrega")
                            feventa.formaPago = dt2.Rows(0).Item("tipo_pago")
                        End If

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

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        Dim intComprobante As Integer = Me.dgvLista.Rows(e.RowIndex).Cells("id").Value
        ListarComprobante(intComprobante)
        Me.btnCanjear.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("idestado").Value = 0
    End Sub

    Sub ActualizarSolicitud(ByVal solicitud As Integer)
        Dim obj As New Cls_Autorizacion_LN
        obj.ActualizarSolicitud(solicitud, 1)
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub dgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick

    End Sub

    Private Sub txtNumeroComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroComprobante.TextChanged

    End Sub
End Class