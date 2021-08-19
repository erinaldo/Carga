Imports INTEGRACION_LN

Public Class frmEmisionFacturaAdicional
    Dim intModo As Integer
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

    Dim intComprobante As Integer
    Dim intCortesia As Integer = 0
    Dim strTipoPago As String = ""

#Region "Grid"
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
            Dim col_id_solicitud As New DataGridViewTextBoxColumn
            With col_id_solicitud
                .Name = "id_solicitud" : .DataPropertyName = "id_solicitud" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_solicitud"
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .HeaderText = "Fecha Sol." : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero_solicitud As New DataGridViewTextBoxColumn
            With col_numero_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .HeaderText = "Nº Sol." : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_total_solicitud As New DataGridViewTextBoxColumn
            With col_total_solicitud
                .Name = "total_solicitud" : .DataPropertyName = "total_solicitud"
                .DisplayIndex = x : .HeaderText = "Total" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_facturado As New DataGridViewTextBoxColumn
            With col_facturado
                .Name = "facturado" : .DataPropertyName = "facturado"
                .DisplayIndex = x : .HeaderText = "Facturado" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_facturado As New DataGridViewTextBoxColumn
            With col_id_facturado
                .Name = "id_facturado" : .DataPropertyName = "id_facturado" : .DisplayIndex = x : .HeaderText = "id_facturado" : .Visible = False
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .HeaderText = "Operación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_adicional As New DataGridViewTextBoxColumn
            With col_adicional
                .Name = "adicional" : .DataPropertyName = "adicional" : .DisplayIndex = x : .HeaderText = "adicional" : .Visible = False
            End With
            x += +1
            Dim col_factura_adicional As New DataGridViewTextBoxColumn
            With col_factura_adicional
                .Name = "factura_adicional" : .DataPropertyName = "factura_adicional"
                .DisplayIndex = x : .HeaderText = "Factura Adicional" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
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
                .DisplayIndex = x : .HeaderText = "Tipo" : .Visible = True
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
                .DisplayIndex = x : .HeaderText = "Nº Documento" : .Visible = True
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
            .Columns.AddRange(col_id_solicitud, col_fecha_solicitud, col_numero_solicitud, col_total_solicitud, col_facturado, col_id_facturado, col_operacion, col_adicional, col_factura_adicional, _
                              col_id, col_idtipo, col_fecha, col_tipo, col_comprobante, col_total, col_origen, col_destino, col_numero, col_cliente, _
                              col_remitente, col_consignado, col_idtipo_entrega, col_direccionEntrega, col_producto, col_direccion_origen)
        End With
    End Sub
    Sub FormatearDGVOperacion()
        With dgvOperacion
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
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total" : .DisplayIndex = x : .Visible = False : .HeaderText = "total"
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .HeaderText = "Operación" : .Visible = True
                .Width = 300 '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .HeaderText = "Monto" : .Visible = True
                .Width = 150 '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_idoperacion As New DataGridViewTextBoxColumn
            With col_idoperacion
                .Name = "idoperacion" : .DataPropertyName = "idoperacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "idoperacion"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_total, col_operacion, col_monto, col_idoperacion, col_estado)
        End With
    End Sub
#End Region

    Private Sub frmEmisionFacturaAdicional_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
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

        Dim obj2 As New Cls_Autorizacion_LN
        With Me.cboFormaPago
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj2.ListarFormaPago
            .SelectedValue = 1
        End With
        Dim obj3 As New Cls_FacturaAdicional_LN
        With Me.cboTarjeta
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj3.ListarTipoTarjeta
            .SelectedValue = 0
        End With

        FormatearDGVLista()
        FormatearDGVOperacion()

        Me.cboFacturado.SelectedIndex = 2

        LimpiarCliente()
        ActualizaNumeroComprobante(2)
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Public Function ValidaNroTexto2(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZñÑa-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNroTexto2 = True
        Else
            ValidaNroTexto2 = False
        End If
    End Function

    Public Function ValidaNumero2(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[-0-9\b]") '("^\d+$")  
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero2 = True
        Else
            ValidaNumero2 = False
        End If
    End Function

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
            Dim intFacturado As Integer
            If Me.cboFacturado.SelectedIndex = 0 Then
                intFacturado = -1
            ElseIf Me.cboFacturado.SelectedIndex = 1 Then
                intFacturado = 1
            Else
                intFacturado = 0
            End If

            Dim obj As New Cls_FacturaAdicional_LN
            Dim dt As DataTable = obj.BuscarComprobante(strInicio, strFin, Me.cboOrigen.SelectedValue, Me.cboDestino.SelectedValue, _
                                                      strNumero, strSerie, strNumeroDocumento, strCliente, intOpcion, Me.cboTipoComprobante.SelectedIndex, intFacturado)
            Me.dgvLista.DataSource = dt
            If Me.dgvLista.Rows.Count = 0 Then
                Me.btnAgregar.Enabled = False
                Me.btnConsultar.Enabled = False
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Emisión Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNumeroComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnBuscar_Click(Nothing, Nothing)
        Else
            If Me.ValidaNumero2(e.KeyChar) Then
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
            If Not Me.ValidaNroTexto2(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub Total(dt As DataTable)
        Dim dblTotal As Double, dblSubtotal As Double, dblImpuesto As Double
        If Me.dgvOperacion.CurrentRow.Cells("idoperacion").Value <> 17 Then
            dblTotal = IIf(IsDBNull(dt.Compute("sum(monto)", "")), 0, dt.Compute("sum(monto)", ""))
            dblSubtotal = dblTotal / 1.18
            dblImpuesto = dblTotal - dblSubtotal
        Else
            dblSubtotal = IIf(IsDBNull(dt.Compute("sum(monto)", "")), 0, dt.Compute("sum(monto)", ""))
            dblTotal = dblSubtotal * 1.18
            dblImpuesto = dblTotal - dblSubtotal
        End If

        Me.lblSubtotal.Text = Format(dblSubtotal, "###,###,###0.00")
        Me.lblImpuesto.Text = Format(dblImpuesto, "###,###,###0.00")
        Me.lblTotal.Text = Format(dblTotal, "###,###,###0.00")
    End Sub

    Sub ListarSolicitud(tipo As Integer, comprobante As Integer, facturado As Integer, Optional solicitud As Integer = 0)
        Dim obj As New Cls_FacturaAdicional_LN
        Dim dt As DataTable = obj.ListarSolicitud(tipo, comprobante, 2, facturado, solicitud)
        Me.dgvOperacion.DataSource = dt
        Total(dt)
    End Sub

    Sub Agregar(tipo As Integer, comprobante As Integer)
        tabFacturaAdicional.SelectedTab = tabFacturaAdicional.TabPages("tabEmision")
        Me.lblComprobante.Text = Me.dgvLista.CurrentRow.Cells("tipo").Value & " " & Me.dgvLista.CurrentRow.Cells("comprobante").Value

        Me.txtNumeroDocumento.Text = Me.dgvLista.CurrentRow.Cells("numero").Value

        Dim e As New KeyPressEventArgs(Chr(13))
        Me.txtNumeroDocumento_KeyPress(Nothing, e)

        ListarSolicitud(tipo, comprobante, 0)

        If Me.dgvOperacion.Rows.Count > 0 Then
            Me.grbCliente.Enabled = True
            Me.grbFormaPago.Enabled = True
            Me.grbOperacion.Enabled = True
            Me.btnGrabar.Enabled = True
        Else
            Me.grbCliente.Enabled = False
            Me.grbFormaPago.Enabled = False
            Me.grbOperacion.Enabled = False
            Me.btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            If Me.btnAgregar.Enabled Then
                Me.btnAgregar_Click(Nothing, Nothing)
            ElseIf Me.btnConsultar.Enabled Then
                Me.Consultar()
            End If
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
        objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
        objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
            MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        objLIQUI_TURNOS = Nothing

        Try
            If Me.txtNombre.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Cliente", "Emision Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNumeroComprobante.Focus()
                Return
            End If

            If Me.lblTipoComprobante.Text.Substring(0, 1).ToUpper = "F" Then
                If Me.cboDireccion.SelectedIndex = 0 Then
                    MessageBox.Show("Seleccione Dirección Legal", "Emision Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboDireccion.Focus()
                    Me.cboDireccion.DroppedDown = True
                    Return
                End If
            End If

            'hlamas 16-05-2017
            If Me.cboFormaPago.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Forma de Pago", "Emision Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboFormaPago.Focus()
                Me.cboFormaPago.DroppedDown = True
                Return
            End If

            If Me.cboFormaPago.SelectedValue = 2 Then
                If Me.cboTarjeta.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione Tipo de Tarjeta", "Emision Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboTarjeta.Focus()
                    Return
                Else
                    If Me.txtNumeroTarjeta.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Nº de Tarjeta", "Emision Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtNumeroTarjeta.Text = ""
                        Me.txtNumeroTarjeta.Focus()
                        Return
                    End If
                End If
            End If

            Me.Cursor = Cursors.WaitCursor

            Grabar()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarDireccion(cliente As Integer)
        Dim obj As New Cls_Autorizacion_LN

        dtDireccion = obj.ListarDireccion(cliente)
        With Me.cboDireccion
            .ValueMember = "id"
            .DisplayMember = "direccion"
            .DataSource = dtDireccion
            .SelectedValue = Me.dgvLista.CurrentRow.Cells("direccion_origen").Value
            If IsNothing(.SelectedValue) Then .SelectedValue = 0
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
        Me.txtNumeroDocumento.Text = dt.Rows(0).Item("nu_docu_suna").ToString.Trim
        Me.txtNombre.Text = dt.Rows(0).Item("razon_social").ToString.Trim

        MostrarDireccion(dt.Rows(0).Item("idpersona").ToString.Trim)
    End Sub

    Private Sub txtNumeroDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dim obj As New Cls_FacturaAdicional_LN
            Dim strNumeroDocumento As String

            strNumeroDocumento = Me.txtNumeroDocumento.Text.Trim
            Dim dt As DataTable = obj.BuscarCliente(strNumeroDocumento)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("El Cliente no Existe", "Emisión Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            intComprobante = IIf(fnValidarRUC(Me.txtNumeroDocumento.Text.Trim), 1, 2)
            ActualizaNumeroComprobante(intComprobante)
        End If
    End Sub

    Private Sub cboFormaPago_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboFormaPago.SelectedValueChanged
        If Me.cboFormaPago.SelectedValue = 2 Then
            Me.cboTarjeta.SelectedValue = 0
            Me.cboTarjeta.Enabled = True
            Me.txtNumeroTarjeta.Enabled = True
            Me.cboTarjeta.Focus()
        Else
            Me.cboTarjeta.SelectedValue = 0
            Me.cboTarjeta.Enabled = False
        End If
    End Sub

    Private Sub cboTarjeta_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboTarjeta.SelectedValueChanged
        If Me.cboTarjeta.SelectedValue > 0 Then
            Me.txtNumeroTarjeta.Text = ""
            Me.txtNumeroTarjeta.Enabled = True
            Me.txtNumeroTarjeta.Focus()
        Else
            Me.txtNumeroTarjeta.Text = ""
            Me.txtNumeroTarjeta.Enabled = False
        End If
    End Sub

    Sub ActualizaNumeroComprobante(tipo As Integer)
        Dim obj As New dtoVentaCargaContado
        If obj.fnNroDocuemnto(tipo, , 1) = True Then
            lblSerie.Text = RellenoRight(3, obj.Serie)
            lblNumero.Text = RellenoRight(7, obj.NroDoc)

            Me.lblTipoComprobante.Text = IIf(tipo = 1, "FACTURA", "BOLETA")
        Else
            Me.lblTipoComprobante.Text = "BOLETA"
            MessageBox.Show("Configure Serie y Número del Comprobante", "Emisión Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnGrabar.Enabled = False
        End If
    End Sub

    Sub LimpiarCliente()
        Me.txtNombre.Text = ""
        Me.cboTipoComprobante.SelectedIndex = 0

        Me.cboDireccion.DataSource = Nothing
        Me.cboDireccion.Items.Clear()
        Me.cboDireccion.Items.Add(" (SELECCIONE)")
        Me.cboDireccion.SelectedIndex = 0
        dtDireccion = Nothing

        Me.cboFormaPago.SelectedValue = 1
        Me.cboTarjeta.SelectedValue = 0

        'Me.lblSerie.Text = ""
        'Me.lblNumero.Text = ""
        'Me.lblTipoComprobante.Text = "BOLETA"
        'ActualizaNumeroComprobante(2)
    End Sub

    Private Sub txtNumeroDocumento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroDocumento.TextChanged
        LimpiarCliente()
    End Sub

    Sub CargarCliente(ByVal frm As FrmCliente2)
        'If frm.bClienteNuevo Then
        'Me.txtNumeroDocumento.Tag = 0
        'End If
        Me.txtNumeroDocumento.Text = frm.TxtNumero.Text.Trim
        Me.txtNombre.Text = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
        'Cliente
        With aCliente
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
            Me.cboDireccion.DataSource = Nothing
            Me.cboDireccion.Items.Clear()
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

            cboDireccion.DisplayMember = "direccion"
            cboDireccion.ValueMember = "id"
            Me.cboDireccion.DataSource = dtDireccion
            If cboDireccion.Items.Count > 1 Then
                Me.cboDireccion.SelectedIndex = 1
            Else
                Me.cboDireccion.SelectedIndex = 0
            End If
        End If
        intComprobante = IIf(fnValidarRUC(Me.txtNumeroDocumento.Text.Trim), 1, 2)
        ActualizaNumeroComprobante(intComprobante)
    End Sub

    Private Sub BtnCliente_Click(sender As System.Object, e As System.EventArgs) Handles BtnCliente.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim frm As New FrmCliente2
            frm.iFicha = 1
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

            If Me.txtNombre.Text.Trim.Length > 0 Then
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
                    Dim intFila As Integer = Me.cboDireccion.SelectedIndex
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

            'frm.bClienteNuevo = bClienteNuevo
            frm.intOpcion = 1
            frm.GrbCliente.Enabled = False
            frm.BtnNuevo.Enabled = False
            frm.GrbContacto.Enabled = False
            frm.txtrazon.Enabled = False
            frm.ChkTelefono.Checked = False
            'frm.bContactoNuevo = IIf(idcontacto > 0, False, True)
            'frm.iTipoComprobante = TipoComprobante
            frm.ShowDialog()
            Me.Cursor = Cursors.Default
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.AppStarting
                Me.CargarCliente(frm)
                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar()
        Try
            '-->Valida la configuarcion de la impresora - jabanto - 17/06/2016
            Dim dtImpresora As DataTable = FEManager.buscarPrint()
            If dtImpresora Is Nothing Then
                MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Cursor = Cursors.WaitCursor
            Dim tipo As Integer, id_original As Integer, cliente As Integer, tipo_documento As Integer, numero_documento As String, nombres As String, _
                ap As String, am As String, razon_social As String, telefono As String, email As String, iddireccion As Integer, direccion As String, _
                idvia As Integer, via As String, numero As String, manzana As String, lote As String, idnivel As Integer, nivel As String, _
                idzona As Integer, zona As String, idclasificacion As Integer, clasificacion As String, iddepartamento As Integer, _
                idprovincia As Integer, iddistrito As Integer, agencia As Integer, forma_pago As Integer, tipo_tarjeta As Integer, _
                tarjeta As String, subtotal As Double, impuesto As Double, total As Double,
                domicilio As Double, cargo As Double, fz As Double, _
                usuario As Integer, ip As String

            tipo = IIf(Me.lblTipoComprobante.Text.Trim.Substring(0, 1) = "F", 1, 2)
            id_original = Me.dgvLista.CurrentRow.Cells("id").Value
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

            With aDireccion
                'If IsNothing(dtDireccion) Then Return
                Try
                    Dim intFila As Integer
                    intFila = Me.cboDireccion.SelectedIndex
                    .id = dtDireccion.Rows(intFila).Item("id")
                    .direccion = dtDireccion.Rows(intFila).Item("direccion")
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
                    .iddepartamento = dtDireccion.Rows(intFila).Item("iddepartamento")
                    .idprovincia = dtDireccion.Rows(intFila).Item("idprovincia")
                    .iddistrito = dtDireccion.Rows(intFila).Item("iddistrito")
                Catch ex As Exception
                End Try

                iddireccion = .id
                direccion = .direccion
                idvia = .id_via
                via = .via
                numero = .numero
                manzana = .manzana
                lote = .lote
                idnivel = .id_nivel
                nivel = .nivel
                idzona = .id_zona
                zona = .zona
                idclasificacion = .id_clasificacion
                clasificacion = .clasificacion
                iddepartamento = .iddepartamento
                idprovincia = .idprovincia
                iddistrito = .iddistrito
                If direccion.Trim = "(SELECCIONE)" Then
                    iddireccion = -1
                End If
            End With
            agencia = dtoUSUARIOS.iIDAGENCIAS
            forma_pago = Me.cboFormaPago.SelectedValue
            tipo_tarjeta = Me.cboTarjeta.SelectedValue
            tarjeta = Me.txtNumeroTarjeta.Text.Trim
            subtotal = CType(Me.lblSubtotal.Text, Double)
            impuesto = CType(Me.lblImpuesto.Text, Double)
            total = CType(Me.lblTotal.Text, Double)

            With Me.dgvOperacion
                For Each row As DataGridViewRow In Me.dgvOperacion.Rows
                    Select Case row.Cells("idoperacion").Value
                        Case 16
                            domicilio = row.Cells("monto").Value
                        Case 15
                            cargo = row.Cells("monto").Value
                        Case 17
                            fz = row.Cells("monto").Value
                    End Select
                Next
            End With
            usuario = dtoUSUARIOS.IdLogin
            ip = dtoUSUARIOS.IP

            'hlamas 07-08-2018
            If total > 0 Then
                'hlamas 16-05-2017
                Dim dlgPago As New frmPagoContado
                dlgPago.Numero = txtNumeroDocumento.Text.Trim
                dlgPago.Cliente = txtNombre.Text.Trim
                dlgPago.TotalVenta = CType(lblTotal.Text, Double).ToString("0.00")
                If dlgPago.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim obj As New Cls_FacturaAdicional_LN
                    Dim dtfactura As DataTable = obj.GrabarFactura(tipo, id_original, cliente, tipo_documento, numero_documento, nombres, _
                                                                     ap, am, razon_social, telefono, email, iddireccion, direccion, _
                                                                     idvia, via, numero, manzana, lote, idnivel, nivel, _
                                                                     idzona, zona, idclasificacion, clasificacion, iddepartamento, _
                                                                     idprovincia, iddistrito, agencia, forma_pago, tipo_tarjeta, _
                                                                     tarjeta, subtotal, impuesto, total,
                                                                     domicilio, cargo, fz, _
                                                                     usuario, ip, Me.dgvLista.CurrentRow.Cells("id_solicitud").Value)
                    'hlamas 16-05-2017
                    'Grabar tipo de pagos
                    GrabarTipoPago(dlgPago, dtfactura.Rows(0).Item("id"))

                    'hlamas 16-05-2017
                    GrabarNotaCredito(dlgPago, cliente, dtImpresora)


                    '********************************************************************************
                    '-->Emision de la Factura/boleta electronica - jabanto - 17/05/2016
                    '********************************************************************************
                    'Dim numeroSerie As String = dtfactura.Rows(0)("serieComprobante")
                    'Dim numeroComprobante As String = dtfactura.Rows(0)("numeroComprobante")

                    'Dim fecliente As New FECliente
                    'fecliente.tipoDocumentoID = tipo_documento
                    'fecliente.numeroDocumento = numero_documento
                    'fecliente.nombres = razon_social
                    'fecliente.direccion = IIf(cboDireccion.SelectedValue > 0, cboDireccion.Text.Trim.ToUpper(), Nothing)

                    'Dim venta As New FEVenta
                    'venta.cliente = fecliente
                    'venta.numeroSerie = numeroSerie
                    'venta.numeroCorrelativo = numeroComprobante
                    'venta.fechaEmision = DateTime.Parse(FechaServidor()).ToString("dd/MM/yyyy HH:mm:ss")
                    'venta.tipoComprobanteID = tipo
                    'venta.opGravada = subtotal
                    'venta.igv = impuesto
                    'venta.total = total
                    'venta.totalLetras = ConvercionNroEnLetras(venta.total)
                    'venta.formaPago = cboFormaPago.Text.Trim().ToUpper()
                    ''hlamas 16-05-2017
                    'If intCortesia = 5 Then '-->Cortesia
                    '    venta.isCortesia = True
                    'End If
                    'venta.formaPago = strTipoPago

                    'Dim rowl As DataGridViewRow = dgvLista.CurrentRow
                    'venta.producto = IIf(IsDBNull(rowl.Cells("PRODUCTO").Value), Nothing, rowl.Cells("PRODUCTO").Value)
                    ''-->Para la impresion
                    'venta.origen = IIf(IsDBNull(rowl.Cells("ORIGEN").Value), Nothing, rowl.Cells("ORIGEN").Value)
                    'venta.destino = IIf(IsDBNull(rowl.Cells("DESTINO").Value), Nothing, rowl.Cells("DESTINO").Value)
                    'venta.remitenete = IIf(IsDBNull(rowl.Cells("REMITENTE").Value), Nothing, rowl.Cells("REMITENTE").Value)
                    'venta.consignado = IIf(IsDBNull(rowl.Cells("CONSIGNADO").Value), Nothing, rowl.Cells("CONSIGNADO").Value)
                    'venta.tipoEntrega = IIf(IsDBNull(rowl.Cells("IDTIPO_ENTREGA").Value), Nothing, IIf(rowl.Cells("IDTIPO_ENTREGA").Value = 1, "AGENCIA", "DOMICILIO"))
                    'venta.direccionEntrega = IIf(IsDBNull(rowl.Cells("IDTIPO_ENTREGA").Value), Nothing, IIf(rowl.Cells("IDTIPO_ENTREGA").Value = 1, Nothing, rowl.Cells("DIRECCION_ENTREGA").Value))
                    'venta.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
                    'venta.usuarioEmision = dtoUSUARIOS.NameLogin
                    'venta.id = dtfactura.Rows(0).Item("id")
                    'venta.tabla = "T_FACTURA_CONTADO"

                    'Dim listaDetalle As New List(Of FEDetalleVenta)
                    'For Each row As DataGridViewRow In dgvOperacion.Rows
                    '    Dim detalleVenta As New FEDetalleVenta
                    '    detalleVenta.descripcion = row.Cells("operacion").Value.ToString.Trim().ToUpper()
                    '    detalleVenta.cantidad = 1
                    '    detalleVenta.tarifa = CType(Me.lblTotal.Text, Double) 'row.Cells("monto").Value
                    '    detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD

                    '    listaDetalle.Add(detalleVenta)
                    'Next
                    'venta.detalleVenta = listaDetalle

                    ''Dim result = FEManager.result
                    'Dim result = FEManager.sendVentaSunat(venta, dtImpresora)
                    'If (result.IsCorrect) Then
                    '    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    '    Dim idFactura As Long = dtfactura.Rows(0).Item("id")
                    '    objFac.actualizarEmisonFE(idFactura, "T_FACTURA_CONTADO")
                    'End If
                    'MessageBox.Show(result.Message, "Emisión F.E.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Cursor = Cursors.Default
                    Me.tabFacturaAdicional.SelectedTab = Me.tabFacturaAdicional.TabPages("tabBuscar")
                    btnBuscar_Click(Nothing, Nothing)
                End If
            ElseIf Me.dgvOperacion.Rows(0).Cells("idoperacion").Value = 16 Then
                Dim obj As New Cls_FacturaAdicional_LN
                domicilio = 1
                Dim dtfactura As DataTable = obj.GrabarFactura(tipo, id_original, cliente, tipo_documento, numero_documento, nombres, _
                                                                 ap, am, razon_social, telefono, email, iddireccion, direccion, _
                                                                 idvia, via, numero, manzana, lote, idnivel, nivel, _
                                                                 idzona, zona, idclasificacion, clasificacion, iddepartamento, _
                                                                 idprovincia, iddistrito, agencia, forma_pago, tipo_tarjeta, _
                                                                 tarjeta, subtotal, impuesto, total,
                                                                 domicilio, cargo, fz, _
                                                                 usuario, ip, Me.dgvLista.CurrentRow.Cells("id_solicitud").Value)

                Me.Cursor = Cursors.Default
                Me.tabFacturaAdicional.SelectedTab = Me.tabFacturaAdicional.TabPages("tabBuscar")
                btnBuscar_Click(Nothing, Nothing)
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("El total del comprobante debe ser mayor a 0", "Emisión Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            btnBuscar_Click(Nothing, Nothing)
            MessageBox.Show(ex.Message, "Emisión Factura Adicional", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        intModo = 1
        Dim intTipo As Integer, intComprobante As Integer
        intTipo = Me.dgvLista.CurrentRow.Cells("idtipo").Value
        intComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
        Agregar(intTipo, intComprobante)
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        With Me.dgvLista
            If IsDBNull(.Rows(e.RowIndex).Cells("id_facturado").Value) Then Return 'adicional
            If .Rows(e.RowIndex).Cells("id_facturado").Value = 1 Then
                Me.btnAgregar.Enabled = False
                Me.btnConsultar.Enabled = True
            Else
                Me.btnAgregar.Enabled = True
                Me.btnConsultar.Enabled = False
            End If
        End With
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Sub Consultar()
        Dim obj As New Cls_FacturaAdicional_LN
        Dim dt As DataTable = obj.ListarFacturaAdicional(Me.dgvLista.CurrentRow.Cells("id").Value)

        intModo = 2
        Me.lblComprobante.Text = Me.dgvLista.CurrentRow.Cells("tipo").Value & " " & Me.dgvLista.CurrentRow.Cells("comprobante").Value
        If dt.Rows.Count > 0 Then
            Me.LblFechaServidor.Text = dt.Rows(0).Item("fecha")
            Me.lblSerie.Text = dt.Rows(0).Item("serie")
            Me.lblNumero.Text = dt.Rows(0).Item("numero")
            Me.txtNumeroDocumento.Text = dt.Rows(0).Item("numero_documento")
            Me.txtNombre.Text = dt.Rows(0).Item("nombres")

            MostrarDireccion(dt.Rows(0).Item("idpersona"))
            Me.cboDireccion.SelectedValue = dt.Rows(0).Item("direccion_origen")
            Me.cboFormaPago.SelectedValue = dt.Rows(0).Item("forma_pago")

            If Me.cboFormaPago.SelectedValue = 2 Then
                Me.cboTarjeta.SelectedValue = dt.Rows(0).Item("idtarjeta")
                Me.txtNumeroTarjeta.Text = dt.Rows(0).Item("tarjeta")
            Else
                Me.cboTarjeta.SelectedValue = 0
                Me.txtNumeroTarjeta.Text = ""
            End If

            ListarSolicitud(Me.dgvLista.CurrentRow.Cells("idtipo").Value, Me.dgvLista.CurrentRow.Cells("id").Value, 1, Me.dgvLista.CurrentRow.Cells("id_solicitud").Value)

            Me.grbCliente.Enabled = False
            Me.grbFormaPago.Enabled = False
            Me.grbOperacion.Enabled = False
            Me.btnGrabar.Enabled = False

            RemoveHandler tabFacturaAdicional.SelectedIndexChanged, AddressOf tabFacturaAdicional_SelectedIndexChanged
            Me.tabFacturaAdicional.SelectedTab = Me.tabFacturaAdicional.TabPages("tabEmision")
            AddHandler tabFacturaAdicional.SelectedIndexChanged, AddressOf tabFacturaAdicional_SelectedIndexChanged
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.tabFacturaAdicional.SelectedTab = Me.tabFacturaAdicional.TabPages("tabBuscar")
        Me.btnBuscar.Focus()
    End Sub

    Private Sub tabFacturaAdicional_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabFacturaAdicional.SelectedIndexChanged
        If tabFacturaAdicional.SelectedTab Is tabFacturaAdicional.TabPages("TabEmision") Then
            If Me.dgvLista.Rows.Count > 0 Then
                If Me.btnAgregar.Enabled Then
                    Me.btnAgregar_Click(Nothing, Nothing)
                Else
                    Me.btnConsultar_Click(Nothing, Nothing)
                End If
            Else
                Me.Limpiar()
            End If
            End If
    End Sub

    Sub Limpiar()
        Me.lblComprobante.Text = ""
        Me.txtNumeroDocumento.Text = ""
        Me.txtNombre.Text = ""
        Me.cboDireccion.DataSource = Nothing
        Me.cboFormaPago.SelectedValue = 1
        Me.cboTarjeta.SelectedValue = 0
        Me.txtNumeroTarjeta.Text = ""
        Me.lblSubtotal.Text = "0.00"
        Me.lblImpuesto.Text = "0.00"
        Me.lblTotal.Text = "0.00"

        Me.dgvOperacion.DataSource = Nothing
        Me.grbOperacion.Enabled = False

        Me.grbCliente.Enabled = False
        Me.grbFormaPago.Enabled = False
        Me.btnGrabar.Enabled = False

        'hlamas 16-05-2017
        intCortesia = 0
        strTipoPago = ""

        Me.btnCancelar.Focus()
    End Sub

    Sub GrabarTipoPago(ByVal frm As frmPagoContado, ByVal comprobante As Integer)
        Try
            Dim obj As New dtoVentaCargaContado

            With frm
                strTipoPago = ""
                For Each row As DataGridViewRow In .dgvPago.Rows
                    obj.GrabarTipoPago(comprobante, row.Cells("tipo_pago").Value, row.Cells("tipo_tarjeta").Value, row.Cells("afecto").Value, _
                                       row.Cells("pago").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, row.Cells("tarjeta").Value)
                    intCortesia = row.Cells("tipo_pago").Value
                    strTipoPago &= TipoPago(row.Cells("tipo_pago").Value) & ","
                Next
                If strTipoPago.Trim.Length > 0 Then
                    strTipoPago = strTipoPago.Substring(0, strTipoPago.Trim.Length - 1)
                End If
            End With
        Catch
        End Try
    End Sub

    Sub GrabarNotaCredito(ByVal frm As frmPagoContado, ByVal cliente As Integer, ByVal dtImpresora As DataTable)
        Try
            Dim intTipoPago As Integer = 0
            Dim dblPago As Double, dblCuota As Double, dblResultado As Double
            Dim intComprobanteOriginal As Integer, intTipo As Integer, strFecha As String, strSerie As String
            Dim dt As New DataTable, dtCtaCte As DataTable
            Dim obj As New dtoVentaCargaContado
            With frm
                For Each row As DataGridViewRow In .dgvPago.Rows 'buscar pago con nota de credito
                    If row.Cells("tipo_pago").Value = 6 Then 'si encuentra pago con nota de credito
                        dtCtaCte = obj.ListarCtaCteDetalle(cliente) 'lista de saldo cta cte por comprobante sin devolucion de dinero
                        If dtCtaCte.Rows.Count > 0 Then
                            dblResultado = row.Cells("pago").Value
                            For Each rowCtaCte As DataRow In dtCtaCte.Rows
                                intComprobanteOriginal = rowCtaCte.Item("comprobante")
                                intTipo = rowCtaCte.Item("tipo")
                                strFecha = rowCtaCte.Item("fecha")
                                strSerie = rowCtaCte.Item("serie")

                                dblCuota = rowCtaCte.Item("monto")
                                If dblResultado - dblCuota >= 0 Then
                                    dblPago = dblCuota
                                Else
                                    dblPago = dblResultado
                                End If
                                dblResultado = dblResultado - dblCuota
                                dt = obj.GrabarNotaCredito(intComprobanteOriginal, 30, row.Cells("pago").Value, dblPago, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, _
                                                      dtoUSUARIOS.IP)
                                'EnviarNotaCreditoSunat(dt.Rows(0), row.Cells("pago").Value, dblPago, intTipo, strSerie, strFecha, dtImpresora)

                                If dblResultado <= 0 Then
                                    Exit For
                                End If
                            Next
                        End If
                        Exit For
                    End If
                Next
            End With
        Catch
        End Try
    End Sub

    Private Sub EnviarNotaCreditoSunat(ByVal dataRowNota As DataRow, ByVal total As Double, ByVal pago As Double, ByVal tipo As Integer, ByVal comprobante As String, ByVal fecha As String, _
                                       ByVal dtImpresora As DataTable)
        Dim dblSubtotal As Double, dblImpuesto As Double
        Dim intOperacion As Integer
        Dim strGlosa As String

        dblSubtotal = Math.Round(pago / 1.18, 2)
        dblImpuesto = Math.Round(pago - dblSubtotal, 2)

        If total > pago Then
            intOperacion = 12
            strGlosa = "RETIRO TOTAL DE CARGA"
        Else
            intOperacion = 12
            strGlosa = "RETIRO TOTAL DE CARGA"
        End If

        '-->Nota de credito
        '******************************
        'Busca el Comprobante original
        Dim comprobanteReferenciaID As String = tipo
        Dim comprobanteReferenciaNumero As String = comprobante
        Dim comprobanteReferenciaFecha As String = fecha

        Dim fenote As FENota = Nothing
        If Not (dataRowNota Is Nothing) Then
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = dataRowNota("idtipo_doc_identidad").ToString
            fecliente.numeroDocumento = dataRowNota("nu_docu_suna").ToString
            fecliente.nombres = dataRowNota("razon_social").ToString
            fecliente.direccion = dataRowNota("direccionOrigen").ToString

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
            fenote.igv = dblImpuesto
            fenote.subTotal = dblSubtotal
            fenote.total = pago
            fenote.tipoNota = intOperacion 'Me.dgvLista.CurrentRow.Cells("codigo_sunat").Value 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("codigo_sunat")
            fenote.descripcionTipoNota = strGlosa 'Me.dgvLista.CurrentRow.Cells("descripcion_sunat").Value 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("descripcion_sunat")
            fenote.totalLentras = ConvercionNroEnLetras(fenote.total)
            fenote.descripcionSustento = strGlosa.Trim.ToUpper()
            'hlamas 12-04-2017
            fenote.agenciaId = dtoUSUARIOS.iIDAGENCIAS
            fenote.usuarioID = dtoUSUARIOS.IdLogin
            fenote.usuarioInsercion = dtoUSUARIOS.IdLogin
            fenote.usuarioModificacion = dtoUSUARIOS.IdLogin

            fenote.id = dataRowNota("idNotaCredito")
            fenote.tabla = "T_FACTURA_CONTADO"
            fenote.isMonedaSoles = True
        End If

        '-->Valida si solamente debe aplicar una nota de credito, mas no un nuevo comprobante
        If (Not fenote Is Nothing) Then
            Try
                '-->Aplica Solamente una nota de credito
                Dim result = FEManager.sendNota(fenote, True)
                If (result.isCorrect) Then
                    Dim idNotaCredito As Long = dataRowNota("idNotaCredito")
                    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_CONTADO")
                End If
                MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("La Nota de Crédito Electrónica no pudo ser registrada, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
