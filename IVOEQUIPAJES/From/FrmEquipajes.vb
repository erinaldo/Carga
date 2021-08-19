Imports AccesoDatos
Public Class frmEquipajes
#Region "VARIABLES PRIVADAS"
    '-->Tipos de comprobantes
    Private LABEL_TIPOCOMPROBANTE_TICKET As String = "EQUIPAJE"
    Private LABEL_TIPOCOMPROBANTE_BOLETA As String = "BOLETA"
    Private LABEL_TIPOCOMPROBANTE_FACTURA As String = "FACTURA"
    Private LABEL_TIPOCOMPROBANTE_PCE As String = "P.C.E"
    '-->labes 
    Private LABEL_TIPO_PRODUCTO_CA As String = "CARGA ACOMPAÑADA"
    '-->Tipo entrega
    Private LABEL_TIPO_ENTREGA_AGENCIA As String = "AGENCIA"
    '-->Objetos DT
    Private DT_UNIDADES_AGENCIAS As DataTable = Nothing
    'Private DT_DIRECCIONES_CLIENTE As DataTable = Nothing
    '-->Objetos
    Private ventaContado As New dtoVentaCargaContado
    Private boleto As Boleto = Nothing
    Dim print_fact_bol As New dtoIMPRESIONFACT_BOL
    '-->Otras variables
    Property hnd As Long
    Dim xIMPRESORA As Integer
    Dim BCol_ As Integer, BRow_ As Integer
    Dim pesoMaxEquipaje As Double = 20
    Dim tipos As String() = {"[CA] - PESO", "[CA] - VOLUMEN", "EQUIPAJE"}
    'Dim iDepartamentoCli, iProvinciaCli, iDistritoCli, IDviaCli, id_NivelCli, id_ZonaCli, id_ClasificacionCli, FormatoCli As Integer
    'Dim ViaCli, ManzanaCli, loteCli, NivelCli, ZonaCli, NroCli, ClasificacionCli As String
    Dim bDireccionModificada As Boolean = False
    '-->Eventos
    Private WithEvents celda As DataGridViewTextBoxEditingControl

    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()

    Dim blnEquipaje As Boolean = False
    Dim intUsuarioEquipaje As Integer = 0
    Dim strMotivoEquipaje As String = ""
    Dim intNivelEquipaje As Integer

    Dim dtBoleto As DataTable
    Dim strTipoPago As String = ""
#End Region
#Region "Grid"
    Sub ConfigurardgvCategoria()
        With dgvCategoria
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeRows = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            x += +1
            Dim col_bulto As New DataGridViewTextBoxColumn
            With col_bulto
                .Name = "bulto" : .DataPropertyName = "bulto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_categoria As New DataGridViewTextBoxColumn
            With col_categoria
                .Name = "categoria" : .DataPropertyName = "categoria"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Categoria"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_idcategoria As New DataGridViewTextBoxColumn
            With col_idcategoria
                .Name = "idcategoria" : .DataPropertyName = "idcategoria"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Categoria"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            .Columns.AddRange(col_bulto, col_categoria, col_idcategoria)
        End With
    End Sub
#End Region
#Region "IDENTIFICADORES EN RELACION CON LA BASE DE DATOS EN TITAN"
    '-->Identificadores del tipo de comprobante
    Private ID_TIPOCOMPROBANTE_TICKET As Integer = 4
    Private ID_TIPOCOMPROBANTE_BOLETA As Integer = 2
    Private ID_TIPOCOMPROBANTE_FACTURA As Integer = 1
    Private ID_TIPOCOMPROBANTE_PCE As Integer = 3
    '-->Identificadores de la foma de pago.
    Private ID_FORMA_PAGO_CONTADO As Integer = 1
    Private ID_FORMA_PAGO_PCE As Integer = 2
    '-->Identificadores del tipo de pago
    Private ID_TIPO_PAGO_TARJETA As Integer = 2
    Private ID_TIPO_PAGO_CORTESIA As Integer = 5
    '-->Identificadores del tipo producto
    Private ID_PRODUCTO_EQUIPAJE As Integer = 11
    Private ID_PRODUCTO_CA As Integer = 6
    '-->Identificador del tipo de entrega
    Private ID_TIPOENTREGA_AGENCIA As Integer = 1
    '-->Identificador del tipo de los tipos de tarifa
    Dim ID_TIPO_TARIFA_ESTANDAR As Integer = 1
#End Region
#Region "FUNCONES/METODOS"
    Private Sub celda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles celda.KeyPress
        e.Handled = Me.Numero(e, celda)
    End Sub
    Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If dgDetalleEquipaje.CurrentCell.ColumnIndex = col_PesoVolumen.Index Then '----->Campo [Peso/Volumen]            
            If UCase(e.KeyChar) Like "[!0-9.]" Then
                If Not Asc(e.KeyChar) = Keys.Back Then
                    Return True
                End If
            End If

            Dim c As Short = 0
            If UCase(e.KeyChar) Like "[.]" Then
                If InStr(cajasTexto.Text, ".") > 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        ElseIf dgDetalleEquipaje.CurrentCell.ColumnIndex = col_Bulto.Index Then '-->Campo [Bulto]
            If UCase(e.KeyChar) Like "[!0-9]" Then
                If Not Asc(e.KeyChar) = Keys.Back Then
                    Return True
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Limpia los datos del formulario
    ''' </summary>
    Private Sub clearFrom(Optional ByVal isClearBoleto As Boolean = True)
        If (isClearBoleto) Then mtbBoleto.Text = ""
        rbBusqDoct.Checked = True
        txtBusqCliente.Text = ""

        'lblTipoComprobante.Text = ""
        'lblSerie.Text = ""
        'lblNumeroComprobante.Text = ""
        lblCiudadOrigen.Text = ""
        lblAgenciaOrigen.Text = ""
        lblCiudadDestino.Text = ""
        'lblAgenciaDestino.Text = ""
        Me.cboAgenciaDestino.SelectedValue = 0
        lblTipoEntrega.Text = ""
        If (cmbFormaPago.Items.Count > 0) Then
            cmbFormaPago.SelectedIndex = 0
        End If
        If (cmbTarjeta.Items.Count > 0) Then
            cmbTarjeta.SelectedIndex = 0
        End If

        txtNumeroTarjeta.Text = ""
        lblNumeroDocumento.Text = ""
        lblNombres.Text = ""

        For Each row As DataGridViewRow In dgDetalleEquipaje.Rows
            row.Cells(col_Bulto.Index).Value = ""
            row.Cells(col_PesoVolumen.Index).Value = 0.0
            row.Cells(col_costo.Index).Value = 0.0
            row.Cells(col_subNeto.Index).Value = 0.0
        Next

        cmbDireccion.DataSource = Nothing
        cmbDireccion.Items.Clear()

        txtTotal.Text = "0.00"
        txtImpuesto.Text = "0.00"
        txtSubTotal.Text = "0.00"
        blnEquipaje = False
        intUsuarioEquipaje = 0
        strMotivoEquipaje = ""
        intNivelEquipaje = 0

        LimpiarDescuento()

        chbxPagoContraEntrega.Checked = False
        Me.LblPasajero.Visible = False

        Me.tsbCorregir.Enabled = False
        Me.tsbVer.Enabled = False
        dtBoleto = Nothing

        'hlamas 16-05-2017
        intCortesia = 0
        strTipoPago = ""
        Me.txtSustento.Text = ""

        'hlamas 27-06-2019
        Me.btnAgregar.Enabled = False
        Me.btnEliminar.Enabled = False
        Me.dgvCategoria.Rows.Clear()
    End Sub
    ''' <summary>
    ''' Carga los diferentes tipos o formas de enviao (PESO, VOLUMEN, EQUIPAJE)
    ''' </summary>
    Private Sub loadTiposDataGridview()
        For Each tipo As String In tipos
            Dim row As DataGridViewRow = dgDetalleEquipaje.Rows(dgDetalleEquipaje.Rows.Add(New DataGridViewRow))
            row.Cells(col_tipo.Index).Value = tipo
            row.Cells(col_PesoVolumen.Index).Value = 0.0
            row.Cells(col_costo.Index).Value = 0.0
            row.Cells(col_subNeto.Index).Value = 0.0
        Next
        dgDetalleEquipaje.AllowUserToAddRows = False

    End Sub
    ''' <summary>
    ''' Carga los parametros basicos para registrar los equipajes
    ''' </summary>
    ''' <param name="IdAgencia_">Identificador de la agencias que va registrar la recepcion de los equipajes</param>
    ''' <returns>true (Si los parametros se cargaron correctamente, false (lo contrario))</returns>
    Private Function loadPameters(ByVal IdAgencia_ As Integer) As Boolean
        Dim flag As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_INICIAR_VENTA_CONTADO2", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_idagencias", IdAgencia_, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            '
            db_bd.AsignarParametro("cur_t_tipo_comprobante", OracleClient.OracleType.Cursor) '0
            db_bd.AsignarParametro("cur_UNIDAD_AGENCIAS", OracleClient.OracleType.Cursor) '1
            db_bd.AsignarParametro("cur_t_Tipo_Entrega", OracleClient.OracleType.Cursor) '2
            db_bd.AsignarParametro("cur_t_Forma_Pago", OracleClient.OracleType.Cursor) '3
            db_bd.AsignarParametro("cur_T_TARJETAS", OracleClient.OracleType.Cursor) '4
            db_bd.AsignarParametro("cur_Tipo_Pago", OracleClient.OracleType.Cursor) '5
            'nuevos cursores
            'db_bd.AsignarParametro("cur_Listado_Producto", OracleClient.OracleType.Cursor) '6
            db_bd.AsignarParametro("cur_factor_m3_kg", OracleClient.OracleType.Cursor) '7
            db_bd.AsignarParametro("cur_control_version", OracleClient.OracleType.Cursor) '8           
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor) '9


            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet


            '-->Cargando el tipo de pago
            Dim dt_formaPagos As New DataTable
            dt_formaPagos.Columns.Add("id")
            dt_formaPagos.Columns.Add("name")
            dt_formaPagos.Rows.Add(0, "SELECCIONE")
            For Each dr_formaPago As DataRow In lds_tmp.Tables(5).Rows
                dt_formaPagos.Rows.Add(dr_formaPago(0), dr_formaPago(1))
            Next

            cmbFormaPago.DisplayMember = "name"
            cmbFormaPago.ValueMember = "id"
            cmbFormaPago.DataSource = dt_formaPagos

            '-->Cargando tarjetas
            Dim dt_tarjetas As New DataTable
            dt_tarjetas.Columns.Add("id")
            dt_tarjetas.Columns.Add("name")
            dt_tarjetas.Rows.Add(0, "SELECCIONE")
            For Each dr_tarjeta As DataRow In lds_tmp.Tables(4).Rows
                dt_tarjetas.Rows.Add(dr_tarjeta(0), dr_tarjeta(1))
            Next
            cmbTarjeta.DataSource = dt_tarjetas
            cmbTarjeta.DisplayMember = "name"
            cmbTarjeta.ValueMember = "id"


            '
            'dt_cur_t_tipo_comprobante = lds_tmp.Tables(0)
            DT_UNIDADES_AGENCIAS = lds_tmp.Tables(1)
            'dt_cur_t_Tipo_Entrega = lds_tmp.Tables(2)
            'dt_cur_t_Forma_Pago = lds_tmp.Tables(3)
            'dt_cur_T_TARJETAS = lds_tmp.Tables(4)
            'dt_cur_Tipo_Pago = lds_tmp.Tables(5)
            '


            If lds_tmp.Tables(8).Rows.Count > 0 Then
                Impresora = lds_tmp.Tables(8).Rows(0).Item("IMPRESION")
                NOMBRE_IMPRESORA = lds_tmp.Tables(8).Rows(0).Item("Control_Impresoras")
            Else
                Impresora = 0
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function
    ''' <summary>
    ''' Realiza la busqueda del boleto para validar si esta ya fue registrado.
    ''' </summary>
    ''' <param name="boleto">Numero de boleto</param>
    ''' <returns>DataTable con la info del comprobante asociado al boleto</returns>
    Private Function boletoIsAsociado(ByVal boleto As String) As DataTable
        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_boleto_asociado", CommandType.StoredProcedure)
        db.AsignarParametro("vi_boleto", boleto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
        db.Desconectar()

        Return db.EjecutarDataTable
    End Function
    ''' <summary>
    ''' Realiza la busqueda del pasajero/cliente en la base de datos Titan.
    ''' </summary>
    ''' <param name="searchBy">Indica si la busqueda debe ser por numero de documento (1), o por nombres (2)</param>
    ''' <param name="valorParameter">Valor a buscar (numero de documento o nombres del pasajero/cliente)</param>
    Private Function getPax_titan(ByVal searchBy As Integer, ByVal valorParameter As String) As Boolean
        '--> Buscando el pasajero en el titan
        Dim ds_cliente As DataSet = ventaContado.Buscar(valorParameter, searchBy, dtoUSUARIOS.m_idciudad, boleto.idCiudadDestino)
        If (ds_cliente.Tables(0).Rows.Count > 0) Then
            Dim dt_cliente As DataTable = ds_cliente.Tables(0)
            Dim rw_cliente As DataRow = dt_cliente.Rows(0)
            If (rw_cliente.Table.Columns.Count > 1) Then
                If Not IsDBNull(rw_cliente.Item("NU_DOCU_SUNA")) Then
                    boleto.numeroDocumento = rw_cliente.Item("NU_DOCU_SUNA")
                Else
                    boleto.numeroDocumento = ""
                End If
                If Not IsDBNull(rw_cliente.Item("AP")) Then
                    boleto.apellidoPaterno = rw_cliente.Item("AP")
                Else
                    boleto.apellidoPaterno = ""
                End If
                If Not IsDBNull(rw_cliente.Item("AM")) Then
                    boleto.apellidoMaterno = rw_cliente.Item("AM")
                Else
                    boleto.apellidoMaterno = ""
                End If
                boleto.nombes = IIf(String.IsNullOrEmpty(rw_cliente.Item("RAZON_SOCIAL").ToString.Trim), rw_cliente.Item("NOMBRES"), rw_cliente.Item("RAZON_SOCIAL"))
                boleto.titan_idPersona = rw_cliente.Item("IDPERSONA")
                boleto.titan_idTipoDocumento = rw_cliente.Item("TIPO")
                boleto.titan_rw_cliente = rw_cliente
                showPax(boleto)


                '-->Direccion del Remitenete
                With Me.cmbDireccion
                    .DataSource = ds_cliente.Tables(1)
                    .DisplayMember = "direccion"
                    .ValueMember = "iddireccion_consignado"

                    If .Items.Count > 2 Then
                        .SelectedIndex = 0
                        .DroppedDown = True
                        .Focus()
                    ElseIf .Items.Count = 1 Then
                        .SelectedIndex = 0
                        .Focus()
                    Else
                        .SelectedIndex = 1
                        .Focus()
                    End If
                End With

                Return True
            End If
        End If

        '-->Si no existe direccion alguna registrada
        If (cmbDireccion.DataSource Is Nothing) Then
            

            Dim dt_direccion As DataTable = getInstanceDataTableDireccion()
            Dim dr_direccion As DataRow = dt_Direccion.NewRow
            dr_direccion("direccion") = " (SELECCIONE)"
            dt_Direccion.Rows.Add(dr_direccion)
            Me.cmbDireccion.DataSource = dt_Direccion
            cmbDireccion.DisplayMember = "direccion"
            cmbDireccion.ValueMember = "iddireccion_consignado"
            cmbDireccion.SelectedIndex = 0
        End If


        Return False
    End Function
    Private Function getInstanceDataTableDireccion() As DataTable
        Dim dt_Direccion As New DataTable
        dt_Direccion.Columns.Add(New DataColumn("iddireccion_consignado", GetType(Integer)))
        dt_Direccion.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("id_via", GetType(Integer)))
        dt_Direccion.Columns.Add(New DataColumn("via", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("numero", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("manzana", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("lote", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("id_nivel", GetType(Integer)))
        dt_Direccion.Columns.Add(New DataColumn("nivel", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("id_zona", GetType(Integer)))
        dt_Direccion.Columns.Add(New DataColumn("zona", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("id_clasificacion", GetType(Integer)))
        dt_Direccion.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt_Direccion.Columns.Add(New DataColumn("iddepartamento", GetType(Integer)))
        dt_Direccion.Columns.Add(New DataColumn("idprovincia", GetType(Integer)))
        dt_Direccion.Columns.Add(New DataColumn("iddistrito", GetType(Integer)))

        Return dt_Direccion
    End Function
    ''' <summary>
    ''' Muestra los datos del pasajero
    ''' </summary>
    ''' <param name="boleto">object Boleto</param>
    Private Sub showPax(ByVal boleto As Boleto)
        lblNumeroDocumento.Text = boleto.numeroDocumento
        'lblNombres.Text = boleto.apellidoPaterno & " " & boleto.apellidoMaterno & " " & boleto.nombes
        lblNombres.Text = boleto.nombes
    End Sub
    ''' <summary>
    ''' Muestra los datos del Boleto
    ''' </summary>
    Private Sub showBoleto()
        '-->Primero limpia y deshabilita algunos controles.
        clearFrom(False)
        cmbFormaPago.Enabled = False
        dgDetalleEquipaje.Enabled = False
        btnGuardar.Enabled = False
        txtBusqCliente.Enabled = False
        btnBusqCliente.Enabled = False

        'Formatea el boleto ingresado
        Dim sDoc As String = Me.mtbBoleto.Text.Trim
        Dim iPos As Integer = sDoc.IndexOf("-")
        Dim sIzquierda As String = "", sDerecha As String = ""
        'Dim sIzquierda As String = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
        'Dim sDerecha As String = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
        'sDoc = sIzquierda & "-" & sDerecha

        If iPos > 0 Then
            If sDoc.Substring(0, 1) = "F" Or sDoc.Substring(0, 1) = "B" Then 'electronico
                sIzquierda = sDoc.Substring(0, iPos).Trim.PadLeft(4, "0")
                sDerecha = sDoc.Substring(iPos + 1).Trim.PadLeft(8, "0")
                sDoc = sIzquierda & "-" & sDerecha
            Else 'manual
                sIzquierda = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
                sDerecha = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
                sDoc = sIzquierda & "-" & sDerecha
            End If
        End If
        Me.mtbBoleto.Text = sDoc

        '-->Busca el boleto
        boleto = getBoleto()
        If Not (boleto Is Nothing) Then
            pesoMaxEquipaje = IIf(boleto.frecuente = 0, 20, 30)
            Me.LblPasajero.Text = IIf(boleto.frecuente = 0, "", "FRECUENTE")
            Me.LblPasajero.Visible = True

            lblTipoEntrega.Text = LABEL_TIPO_ENTREGA_AGENCIA
            lblCiudadOrigen.Text = boleto.ciudadOrigen
            lblAgenciaOrigen.Text = boleto.agenciaOrigen
            lblCiudadDestino.Text = boleto.ciudadDestino
            'lblAgenciaDestino.Text = boleto.agenciaDestino
            If Not String.IsNullOrEmpty(boleto.numeroDocumento) Then
                If Not (getPax_titan(1, boleto.numeroDocumento)) Then
                    showPax(boleto)
                End If
            Else
                showPax(boleto)
            End If
            '-->Busca el tarifario
            Dim tarifasCargo As dtoTarifasCargo = getTarifas(ID_PRODUCTO_CA)
            '-->Carga tarifario en el DataGridView
            If Not (tarifasCargo Is Nothing) Then
                dgDetalleEquipaje(col_PesoVolumen.Index, 0).Value = 0.0
                dgDetalleEquipaje(col_PesoVolumen.Index, 1).Value = 0.0
                dgDetalleEquipaje(col_PesoVolumen.Index, 2).Value = 0.0
                dgDetalleEquipaje(col_costo.Index, 0).Value = FormatNumber(tarifasCargo.precioPeso, 2)
                dgDetalleEquipaje(col_costo.Index, 1).Value = FormatNumber(tarifasCargo.precioVolumen, 2)
                dgDetalleEquipaje(col_costo.Index, 2).Value = 0.0
                dgDetalleEquipaje(col_subNeto.Index, 0).Value = 0.0
                dgDetalleEquipaje(col_subNeto.Index, 1).Value = 0.0
                dgDetalleEquipaje(col_subNeto.Index, 2).Value = 0.0
            Else
                dgDetalleEquipaje(col_PesoVolumen.Index, 0).Value = 0.0
                dgDetalleEquipaje(col_PesoVolumen.Index, 1).Value = 0.0
                dgDetalleEquipaje(col_PesoVolumen.Index, 2).Value = 0.0
                dgDetalleEquipaje(col_costo.Index, 0).Value = 0.0
                dgDetalleEquipaje(col_costo.Index, 1).Value = 0.0
                dgDetalleEquipaje(col_subNeto.Index, 0).Value = 0.0
                dgDetalleEquipaje(col_subNeto.Index, 1).Value = 0.0
                dgDetalleEquipaje(col_subNeto.Index, 2).Value = 0.0
            End If

            'Recupera comprobantes de boleto
            If Me.tsbVer.Enabled Then
                Dim obj As New dtoVentaCargaContado
                dtBoleto = obj.ListarBoleto(mtbBoleto.Text.Trim, 1)
            End If

            loadCorrelativo(True)

            '-->Habilita controles
            enabledContros(True)
            'cmbFormaPago.Enabled = True
            dgDetalleEquipaje.Enabled = True
            'btnGuardar.Enabled = True
            'txtBusqCliente.Enabled = True
            'btnBusqCliente.Enabled = True
        Else
            dtBoleto = Nothing
        End If
    End Sub
    ''' <summary>
    ''' Busca el Boleto en el Sisvyr
    ''' </summary>
    Function getBoleto() As Boleto
        Dim boleto As New Boleto

        '-->Validando si el Boleto de Viaje ya fue utilizado
        Dim dt_boletoAsociado As DataTable = boletoIsAsociado(mtbBoleto.Text.Trim)
        If dt_boletoAsociado.Rows.Count > 0 Then
            Dim tipoComprobante As String = dt_boletoAsociado.Rows(0).Item(0)
            Dim numCmoprobante As String = dt_boletoAsociado.Rows(0).Item(1)
            'MessageBox.Show("El Boleto " & mtbBoleto.Text & " está asociado a:" & Chr(13) & Chr(13) & tipoComprobante & " " & numCmoprobante, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim dlgRespuesta As DialogResult = MessageBox.Show("El Boleto " & mtbBoleto.Text & " está asociado a:" & Chr(13) & Chr(13) & tipoComprobante & " " & _
                                                               numCmoprobante & Chr(13) & Chr(13) & "¿Desea abrir el Boleto de Viaje?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If dlgRespuesta = Windows.Forms.DialogResult.No Then
                boleto = Nothing
                mtbBoleto.Text = ""
                Me.tsbVer.Enabled = False
                mtbBoleto.Focus()
                Exit Function
            Else
                Me.tsbVer.Enabled = True
            End If
        End If

        '==================================================================>
        '--- BUSCANDO EL BOLETO EN SISVYR
        '==================================================================>
        Dim obj As New dto_CargaAcompañada
        Dim dt_boleto As DataTable = obj.BuscarBoleto(mtbBoleto.Text.Trim)
        If dt_boleto.Rows.Count > 0 Then
            Dim dr_boleto As DataRow = dt_boleto.Rows(0)
            boleto.numeroBoleto = mtbBoleto.Text
            '-->Ciudad origen
            boleto.idCiudadOrigen = dtoUSUARIOS.m_idciudad 'dtoUSUARIOS.m_iIdUnidadAgencia
            boleto.ciudadOrigen = dtoUSUARIOS.m_iNombreUnidadAgencia
            '-->Agencia origen
            boleto.idAgenciaOrigen = dtoUSUARIOS.m_iIdAgencia
            boleto.agenciaOrigen = dtoUSUARIOS.m_iNombreAgencia

            '-->Buscando la ciudad destino
            Dim rw_ciudadDestino As DataRow() = DT_UNIDADES_AGENCIAS.Select("IDUNIDAD_AGENCIA='" & dr_boleto.Item("ID_CIUDADDESTINO") & "'")
            If (rw_ciudadDestino.Length > 0) Then
                boleto.ciudadDestino = rw_ciudadDestino(0).Item(1)
                boleto.idCiudadDestino = rw_ciudadDestino(0).Item(0)
            End If

            '-->Buscando agencia destino
            Dim dt_agenciasDestino As DataTable = ObjVentaCargaContado.fnGetAgencias(dr_boleto.Item("ID_CIUDADDESTINO"), , True)
            Dim dtAgencia As New DataTable
            If dr_boleto.Item("ID_CIUDADDESTINO") <> 5100 Then 'Bus e intermedio
                Dim rw_agenciaDestino As DataRow() = dt_agenciasDestino.Select("COD_AGE_SISVYR=" & dr_boleto.Item("ID_AGEDESTINO"))
                If (rw_agenciaDestino.Length > 0) Then
                    boleto.idAgenciaDestino = rw_agenciaDestino(0).Item(0)
                    boleto.agenciaDestino = rw_agenciaDestino(0).Item(1)
                End If
                dtAgencia.Columns.Add("id")
                dtAgencia.Columns.Add("agencia")
                dtAgencia.Rows.Add(0, "SELECCIONE")
                dtAgencia.Rows.Add(rw_agenciaDestino(0).Item(0), rw_agenciaDestino(0).Item(1))
            Else 'Retorno
                Dim intItinerario As Integer = dr_boleto.Item("ITINERARIO")
                Dim dtPuntoDesembarque As DataTable = obj.ListarPuntoDesembarque(intItinerario)
                dtAgencia.Columns.Add("id")
                dtAgencia.Columns.Add("agencia")
                dtAgencia.Rows.Add(0, "SELECCIONE")

                For Each dr As DataRow In dtPuntoDesembarque.Rows
                    Dim rw As DataRow() = dt_agenciasDestino.Select("COD_AGE_SISVYR=" & dr(0))
                    If rw.Length > 0 Then
                        dtAgencia.Rows.Add(rw(0).Item(0), rw(0).Item(1))
                    End If
                Next
            End If
            With cboAgenciaDestino
                .DisplayMember = "agencia"
                .ValueMember = "id"
                .DataSource = dtAgencia
                Dim intNumero As Integer = dtAgencia.Rows.Count
                If intNumero = 2 Then
                    .SelectedIndex = 1
                Else
                    .SelectedIndex = 0
                End If
            End With

            '-->Datos del pasajero
            boleto.titan_idTipoDocumento = dr_boleto.Item("IDTIPODOCUMENTO")
            boleto.numeroDocumento = dr_boleto.Item("NRODOCUMENTO")
            boleto.apellidoPaterno = dr_boleto.Item("APE_PAT")
            boleto.apellidoMaterno = dr_boleto.Item("APE_MAT")
            boleto.nombes = dr_boleto.Item("NOMBRES")
            boleto.fechaPartida = dr_boleto.Item("FECHAPARTIDA")
            boleto.horaPartida = dr_boleto.Item("HORAPARTIDA")
            boleto.servicio = dr_boleto.Item("SERVICIO")
            boleto.frecuente = dr_boleto.Item("PasajeroFrecuente")
            boleto.asiento = dr_boleto.Item("NROASIENTO")
            boleto.total_boleto = dr_boleto.Item("TOTAL_BOLETO")
        Else
            boleto = Nothing
            MessageBox.Show("El Boleto " & Me.mtbBoleto.Text.Trim & " no existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mtbBoleto.Text = ""
            mtbBoleto.Focus()
        End If

            Return boleto
    End Function
    ''' <summary>
    ''' Realiza la busqueda del tarifario
    ''' </summary>
    ''' <param name="idProducto">Identificador del producto</param>
    ''' <returns>Object dtoTarifasCargo</returns>
    Private Function getTarifas(ByVal idProducto As Integer) As dtoTarifasCargo
        Dim flag As Boolean = False
        '--===>Consulta tarifario
        Dim tarifasCargo As New dtoTarifasCargo
        tarifasCargo = ObjVentaCargaContado.obtenerTarifas(boleto.idCiudadOrigen, boleto.idCiudadDestino, idProducto, ID_TIPO_TARIFA_ESTANDAR, ID_TIPOENTREGA_AGENCIA)

        Return tarifasCargo
    End Function
    ''' <summary>
    ''' Realiza el redondeo para evitar dencimos.
    ''' </summary>
    ''' <param name="monto">Monto a dedondear</param>
    ''' <returns>Monto redondeado</returns>
    Public Function round(ByVal monto As String) As String
        Dim monto_total As String = monto
        Try
            Dim varMonto() As String = Split(monto_total, ".")
            If varMonto.Length > 1 Then
                If Val(varMonto(1).ToString) < 50 Then '12/03/2008 - Puedo modificarse acá poniendo igual 
                    monto_total = varMonto(0) & ".50"
                Else
                    Dim Entero As String() = Split(varMonto(0).ToString, ",")
                    Dim i As Integer = 0
                    monto_total = varMonto(0).ToString
                    If Entero.Length >= 1 Then
                        monto_total = ""
                    End If
                    For i = 0 To Entero.Length - 1
                        monto_total = monto_total & Entero(i).ToString
                    Next
                    'monto_total = Val(monto_total) + 1   -- 01/09/2010 
                    If Val(varMonto(1)) > 500 Then
                        monto_total = Val(monto_total) + 1
                    Else
                        monto_total = Val(monto_total) + 0.5
                    End If
                    ' monto_total = monto_total.ToString & ".00"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        If monto Mod 0.5 = 0 Then
            Return monto
        Else
            Return monto_total
        End If
    End Function
    ''' <summary>
    ''' Resetea las variables antes de guardar la venta
    ''' </summary>
    Private Sub resetearVariables()
        ObjVentaCargaContado.DirecCli_mod = 0
        ObjVentaCargaContado.id_DepartamentoCli = 0
        ObjVentaCargaContado.id_ProvinciaCli = 0
        ObjVentaCargaContado.id_DistritoCli = 0
        ObjVentaCargaContado.id_viaCli = 0
        ObjVentaCargaContado.viaCli = 0
        ObjVentaCargaContado.NumeroCli = 0
        ObjVentaCargaContado.manzanaCli = 0
        ObjVentaCargaContado.loteCli = 0
        ObjVentaCargaContado.id_nivelCli = 0
        ObjVentaCargaContado.nivelCli = 0
        ObjVentaCargaContado.id_zonaCli = 0
        ObjVentaCargaContado.zonaCli = 0
        ObjVentaCargaContado.id_clasificacionCli = 0
        ObjVentaCargaContado.clasificacionCli = 0
        ObjVentaCargaContado.formatoCli = 0
        '=====DATOS CONTACTO (no es necesario)
        ObjVentaCargaContado.v_IDPERSONA_ORIGEN = -1
        ObjVentaCargaContado.v_NOMBRES_REMITENTE = "@"
        ObjVentaCargaContado.contacto_mod = 0
        ObjVentaCargaContado.v_NRO_DOC_REMITENTE = "@"
        ObjVentaCargaContado.ID_TipoDocCont = 0
        ObjVentaCargaContado.NombreCont = ""
        ObjVentaCargaContado.apellPatCont = ""
        ObjVentaCargaContado.apellMatCont = ""
        '--DIRECCION ESTRUCTURADA CONSIGNADO (No hay entrega a domicilio)
        ObjVentaCargaContado.v_IDDIREECION_DESTINO = -1
        ObjVentaCargaContado.DirecConsignado_mod = 0
        ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = "@"
        ObjVentaCargaContado.id_DepartamentoConsig = 0
        ObjVentaCargaContado.id_ProvinciaConsig = 0
        ObjVentaCargaContado.id_DistritoConsig = 0
        ObjVentaCargaContado.id_viaConsig = 0
        ObjVentaCargaContado.viaConsig = 0
        ObjVentaCargaContado.NumeroConsig = ""
        ObjVentaCargaContado.manzanaConsig = ""
        ObjVentaCargaContado.loteConsig = ""
        ObjVentaCargaContado.id_nivelConsig = 0
        ObjVentaCargaContado.nivelConsig = ""
        ObjVentaCargaContado.id_zonaConsig = 0
        ObjVentaCargaContado.zonaConsig = ""
        ObjVentaCargaContado.id_clasificacionConsig = 0
        ObjVentaCargaContado.clasificacionConsig = ""
        ObjVentaCargaContado.formatoConsig = 0
        ObjVentaCargaContado.sReferencia = ""
        '---Nuevos Parametros a agregar---
        ObjVentaCargaContado.TarifarioGeneral = 1
        ObjVentaCargaContado.Contado = 1
        ObjVentaCargaContado.v_OTRAS_AGENCIAS = True
        '====PARAMETRO v_cargo
        ObjVentaCargaContado.v_cargo = False
        ObjVentaCargaContado.v_idagencia_venta = 0
        ObjVentaCargaContado.v_idciudad_venta = 0
        '-->
        ObjVentaCargaContado.v_MEMO = "@"
        ObjVentaCargaContado.v_MONTO_DESCUENTO = 0
        ObjVentaCargaContado.v_CANTIDAD_X_PESO = 0
        ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = 0
        ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = 0
        ObjVentaCargaContado.v_TOTAL_PESO = 0
        ObjVentaCargaContado.v_TOTAL_VOLUMEN = 0
        ObjVentaCargaContado.v_MotivoDescuento = ""
        '-->
        ObjVentaCargaContado.v_MONTO_PENALIDAD = 0
        ObjVentaCargaContado.v_IDFUNCIONARIO_AUTORIZACION = 0
        ObjVentaCargaContado.v_PORCENT_DEVOLUCION = 0
        ObjVentaCargaContado.v_PORCENT_DESCUENTO = 0
        ObjVentaCargaContado.v_MONTO_RECARGO = 0
        '-->
        ObjVentaCargaContado.v_MONTO_BASE = 0
        ObjVentaCargaContado.v_MONTO_PENALIDAD = 0
        ObjVentaCargaContado.v_MONTO_RECARGO = 0
        ObjVentaCargaContado.MontoEntregaDomicilio = 0
        ObjVentaCargaContado.MontoDC = 0
        ObjVentaCargaContado.ObservacionCargo = ""
        ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles
    End Sub
    Public Function getParamametersVenta(ByVal idTipoProducto As Integer, Optional ByVal equipaje As Boolean = False) As dtoVentaCargaContado
        Try
            '-->Resetenado variables
            resetearVariables()
            '-->Solo para hacegurarme
            If (boleto.titan_idPersona = 0 AndAlso Not String.IsNullOrEmpty(lblNumeroDocumento.Text)) Then
                getPax_titan(1, lblNumeroDocumento.Text)
            End If

            '--->PARAMETRO TIPO_COMPROBANTE
            If (idTipoProducto = ID_PRODUCTO_CA) Then
                If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA)) Then
                    ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_BOLETA
                ElseIf (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA)) Then
                    ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_FACTURA
                ElseIf (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_PCE)) Then
                    ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_PCE
                End If
            Else
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_TICKET
            End If

            If Not equipaje Then
                '-->Vuelve a cargar el correlativo, en funcion al tipo de comprobante
                loadCorrelativo(True, ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
            End If

            '-->Validando si no es un PCE
            If (ObjVentaCargaContado.v_IDTIPO_COMPROBANTE <> ID_TIPOCOMPROBANTE_PCE) Then
                ObjVentaCargaContado.v_SERIE_FACTURA = lblSerie.Text.Trim
                ObjVentaCargaContado.v_NRO_FACTURA = lblNumeroComprobante.Text
                If equipaje Then
                    If ventaContado.fnNroDocuemnto(4, 0, 1) = True Then
                        ObjVentaCargaContado.v_SERIE_FACTURA = RellenoRight(3, ventaContado.Serie)
                        ObjVentaCargaContado.v_NRO_FACTURA = RellenoRight(3, ventaContado.NroDoc)
                    End If
                End If
            Else
                'ObjVentaCargaContado.v_NRO_GUIA = lblNumeroComprobante.Text
                ObjVentaCargaContado.v_SERIE_FACTURA = "000"
                ObjVentaCargaContado.v_NRO_FACTURA = lblNumeroComprobante.Text
            End If

            '-->Hay que eveluarlo
            ObjVentaCargaContado.bOrigenDiferente = False
            '----------------------------------------------
            ObjVentaCargaContado.v_TIPO_DOCUMENTO = boleto.titan_idTipoDocumento
            ObjVentaCargaContado.v_nroboleto = boleto.numeroBoleto
            'ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_iIdAgencia
            'ObjVentaCargaContado.v_idciudad_venta = dtoUSUARIOS.m_idciudad
            ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            ObjVentaCargaContado.v_iProceso = idTipoProducto
            ObjVentaCargaContado.TipoTarifa = ID_TIPO_TARIFA_ESTANDAR
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
            ObjVentaCargaContado.v_IDAGENCIAS = boleto.idAgenciaOrigen
            ObjVentaCargaContado.v_IDUNIDAD_DESTINO = boleto.idCiudadDestino
            ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = cboAgenciaDestino.SelectedValue 'boleto.idAgenciaDestino
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = ID_TIPOENTREGA_AGENCIA '-->Para este caso no hay a domicilio

            ObjVentaCargaContado.v_idagencia_venta = boleto.idAgenciaOrigen 'dtoUSUARIOS.m_iIdAgencia
            ObjVentaCargaContado.v_idciudad_venta = dtoUSUARIOS.m_idciudad

            ObjVentaCargaContado.v_MONTO_MINIMOs = 20

            If lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_TICKET) Then
                ObjVentaCargaContado.v_IDTIPO_PAGO = 1
            Else
                ObjVentaCargaContado.v_IDTIPO_PAGO = IIf(cmbFormaPago.SelectedIndex <= 0, 1, cmbFormaPago.SelectedValue) '-->Si no ha seleccionado el tipo de pago por defecto(efectivo"1"). Solo se de cumplir para los equipajes, ya que aqui es opcional.
            End If

            ObjVentaCargaContado.v_IDTARJETAS = IIf(ObjVentaCargaContado.v_IDTIPO_PAGO = 2, cmbTarjeta.SelectedValue, 0)
            ObjVentaCargaContado.v_NROTARJETA = IIf(txtNumeroTarjeta.Text <> "", txtNumeroTarjeta.Text, "@")
            '=====CLIENTE
            ObjVentaCargaContado.v_IDPERSONA = 0
            If (boleto.titan_idPersona > 0) Then ObjVentaCargaContado.v_IDPERSONA = boleto.titan_idPersona
            ObjVentaCargaContado.v_NRO_DNI_RUC = IIf(lblNumeroDocumento.Text <> "", lblNumeroDocumento.Text, "@")
            ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL = IIf(lblNombres.Text <> "", lblNombres.Text, "@")
            ObjVentaCargaContado.Cliente_mod = 0 '-->Ya no se permite la modificacion de los datos del cliente
            ObjVentaCargaContado.ID_TipoDocCli = boleto.titan_idTipoDocumento
            ObjVentaCargaContado.NombresCliente = boleto.nombes
            ObjVentaCargaContado.apellPatCli = boleto.apellidoPaterno
            ObjVentaCargaContado.apellMatCli = boleto.apellidoMaterno
            ObjVentaCargaContado.TelefCliente = "@"

            '=======REMITENTE
            ObjVentaCargaContado.iIDRemitente = 0
            If Not String.IsNullOrEmpty(boleto.numeroDocumento) Then
                Dim dt_ventaContado As DataTable = ventaContado.BuscarContacto(boleto.numeroDocumento)
                If (dt_ventaContado.Rows.Count > 0) Then
                    ObjVentaCargaContado.iIDRemitente = dt_ventaContado.Rows(0).Item("IDCONTACTO_PERSONA")
                End If
            End If
            ObjVentaCargaContado.sNombresRemitente = lblNombres.Text.Trim
            ObjVentaCargaContado.sNombreRemitente = boleto.nombes
            ObjVentaCargaContado.sApellidoPaternoRemitente = boleto.apellidoPaterno
            ObjVentaCargaContado.sApellidoMaternoRemitente = boleto.apellidoMaterno
            ObjVentaCargaContado.sNumeroDocumento = lblNumeroDocumento.Text
            ObjVentaCargaContado.iID_TipoDocumentoRemitente = boleto.titan_idTipoDocumento
            ObjVentaCargaContado.iRemitenteModificado = 0

            '=======CONTACTO
            ObjVentaCargaContado.v_IDPERSONA_ORIGEN = ObjVentaCargaContado.iIDRemitente
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = lblNombres.Text.Trim
            ObjVentaCargaContado.contacto_mod = 0
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = lblNumeroDocumento.Text
            ObjVentaCargaContado.ID_TipoDocCont = boleto.titan_idTipoDocumento
            ObjVentaCargaContado.NombreCont = boleto.nombes
            ObjVentaCargaContado.apellPatCont = boleto.apellidoPaterno
            ObjVentaCargaContado.apellMatCont = boleto.apellidoMaterno


            '=====DIRECCION ORIGEN
            ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
            If Me.cmbDireccion.SelectedIndex = 0 Then
                ObjVentaCargaContado.v_IDDIREECION_ORIGEN = -1
            End If
            ObjVentaCargaContado.v_DIRECCION_REMITENTE = IIf(ObjVentaCargaContado.v_IDDIREECION_ORIGEN = -1, "@", Me.cmbDireccion.Text)
            '--DIRECCION ESTRUCTURADO DEL CLIENTE    
            If (cmbDireccion.SelectedIndex > 0) Then
                Dim dr_direccion As DataRowView = cmbDireccion.SelectedItem
                ObjVentaCargaContado.DirecCli_mod = IIf(bDireccionModificada, 1, 0)
                ObjVentaCargaContado.id_DepartamentoCli = dr_direccion("iddepartamento")
                ObjVentaCargaContado.id_ProvinciaCli = dr_direccion("idprovincia")
                ObjVentaCargaContado.id_DistritoCli = dr_direccion("iddistrito")
                ObjVentaCargaContado.id_viaCli = dr_direccion("id_via")
                ObjVentaCargaContado.viaCli = IIf(IsDBNull(dr_direccion("via")), "", dr_direccion("via"))
                ObjVentaCargaContado.NumeroCli = IIf(IsDBNull(dr_direccion("numero")), "", dr_direccion("numero"))
                ObjVentaCargaContado.manzanaCli = IIf(IsDBNull(dr_direccion("manzana")), "", dr_direccion("manzana"))
                ObjVentaCargaContado.loteCli = IIf(IsDBNull(dr_direccion("lote")), "", dr_direccion("lote"))
                ObjVentaCargaContado.id_nivelCli = dr_direccion("id_nivel")
                ObjVentaCargaContado.nivelCli = IIf(IsDBNull(dr_direccion("nivel")), "", dr_direccion("nivel"))
                ObjVentaCargaContado.id_zonaCli = dr_direccion("id_zona")
                ObjVentaCargaContado.zonaCli = IIf(IsDBNull(dr_direccion("zona")), "", dr_direccion("zona"))
                ObjVentaCargaContado.id_clasificacionCli = dr_direccion("id_clasificacion")
                ObjVentaCargaContado.clasificacionCli = IIf(IsDBNull(dr_direccion("clasificacion")), "", dr_direccion("clasificacion"))
                ObjVentaCargaContado.formatoCli = 0 'FormatoCli
            End If
            '-->buscando el consignado
            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0 & ";"
            If Not String.IsNullOrEmpty(boleto.numeroDocumento) Then
                Dim dt_ventaContado As DataTable = ventaContado.BuscarContacto(boleto.numeroDocumento)
                If (dt_ventaContado.Rows.Count > 0) Then
                    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = dt_ventaContado.Rows(0).Item("IDCONTACTO_PERSONA") & ";"
                End If
            End If
            ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = lblNombres.Text.Trim & ";"
            ObjVentaCargaContado.NombreConsignado = boleto.nombes & ";"
            ObjVentaCargaContado.apellPatConsig = boleto.apellidoPaterno & ";"
            ObjVentaCargaContado.apellMatConsig = boleto.apellidoMaterno & ";"
            ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = lblNumeroDocumento.Text & ";"
            ObjVentaCargaContado.ID_TipoDocConsig = boleto.titan_idTipoDocumento & ";"
            ObjVentaCargaContado.TelfConsignado = "" & ";"
            ObjVentaCargaContado.NombConsignado_mod = 0 & ";"
            '-->Auditoria
            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjVentaCargaContado.v_IP = dtoUSUARIOS.IP
            ObjVentaCargaContado.v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjVentaCargaContado.v_IGV = dtoUSUARIOS.iIGV

            Dim row_peso As DataGridViewRow = dgDetalleEquipaje.Rows(0)
            Dim row_volumen As DataGridViewRow = dgDetalleEquipaje.Rows(1)
            Dim row_equipaje As DataGridViewRow = dgDetalleEquipaje.Rows(2)
            '=====>>PARAMETROS PARA CARGA ACOMPAÑADA
            If idTipoProducto = ID_PRODUCTO_CA Then
                '******Grid Bultos
                'Validacion Peso
                If IsDBNull(row_peso.Cells(col_PesoVolumen.Index)) = False _
                    AndAlso Not String.IsNullOrEmpty(row_peso.Cells(col_PesoVolumen.Index).Value) _
                    AndAlso row_peso.Cells(col_PesoVolumen.Index).Value > 0 Then
                    '-->Peso
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = row_peso.Cells(col_Bulto.Index).Value
                    ObjVentaCargaContado.v_TOTAL_PESO = row_peso.Cells(col_PesoVolumen.Index).Value
                End If
                '-->Valida si hay exceso en el peso de equipaje para que le sume al peso actual
                If IsDBNull(row_equipaje.Cells(col_PesoVolumen.Index)) = False _
                    AndAlso Not String.IsNullOrEmpty(row_equipaje.Cells(col_PesoVolumen.Index).Value) _
                    AndAlso row_equipaje.Cells(col_PesoVolumen.Index).Value > 0 Then
                    '-->Peso Equipaje
                    Dim pesoEquipaje As Double = row_equipaje.Cells(col_PesoVolumen.Index).Value
                    'If (pesoEquipaje > pesoMaxEquipaje) Then
                    'ObjVentaCargaContado.v_TOTAL_PESO += pesoEquipaje - pesoMaxEquipaje 'hlamas 12-12-2017
                    ObjVentaCargaContado.v_TOTAL_PESO += pesoEquipaje  'hlamas 12-12-2017
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO += row_equipaje.Cells(col_Bulto.Index).Value
                    'End If
                End If

                'Validacion Volumen
                If IsDBNull(row_volumen.Cells(col_PesoVolumen.Index)) = False _
                    AndAlso Not String.IsNullOrEmpty(row_volumen.Cells(col_PesoVolumen.Index).Value) _
                    AndAlso row_volumen.Cells(col_PesoVolumen.Index).Value > 0 Then
                    '-->Volumen
                    ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = row_volumen.Cells(col_Bulto.Index).Value
                    ObjVentaCargaContado.v_TOTAL_VOLUMEN = row_volumen.Cells(col_PesoVolumen.Index).Value
                End If
                '-->Precios 
                ObjVentaCargaContado.v_PRECIO_X_PESO = row_peso.Cells(col_costo.Index).Value
                ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = row_volumen.Cells(col_costo.Index).Value
                ObjVentaCargaContado.v_MONTO_SUB_TOTAL = txtSubTotal.Text
                ObjVentaCargaContado.v_MONTO_IMPUESTO = txtImpuesto.Text
                ObjVentaCargaContado.v_TOTAL_COSTO = txtTotal.Text

                '-->Descuento
                ObjVentaCargaContado.v_MEMO = IIf(Trim(txtDescDescto.Text) <> "", txtDescDescto.Text, "@")
                ObjVentaCargaContado.v_MONTO_DESCUENTO = IIf(Val(TxtDescuento.Text) <> 0, TxtDescuento.Text, 0)
                ObjVentaCargaContado.v_PORCENT_DESCUENTO = Format(Val(TxtDescuento.Text), "###.00")
                ObjVentaCargaContado.v_MotivoDescuento = IIf(Val(TxtDescuento.Text) <> 0, Me.txtSustento.Text, "")

                '-->Totales
                'ObjVentaCargaContado.v_SUB_TOTAL_CA = Double.Parse(txtTotal.Text)
                'ObjVentaCargaContado.v_IMPUESTO_CA = Double.Parse(txtImpuesto.Text)
                'ObjVentaCargaContado.v_TOTAL_CA = Double.Parse(txtSubTotal.Text)
                'ObjVentaCargaContado.v_carga_acompañada = 1

                '-->Pasando parametros para la impresion del comprobante
                print_fact_bol.fnClear()
                print_fact_bol.xMonto_Sub_Total_Peso = row_peso.Cells(col_subNeto.Index).Value
                print_fact_bol.xMonto_Sub_Total_Vol = row_volumen.Cells(col_subNeto.Index).Value
                print_fact_bol.xCantidad_Peso = ObjVentaCargaContado.v_CANTIDAD_X_PESO
                print_fact_bol.xCantidad_Sobre = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
                print_fact_bol.xCantidad_Vol = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
                ''--->
                'ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
                'ObjCODIGOBARRA.NroDOC = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
                'ObjCODIGOBARRA.AGEDOM = Mid(lblTipoEntrega.Text, 1, 3)
                '-->
                print_fact_bol.xDestino = lblCiudadDestino.Text
                print_fact_bol.xNRODOCFAC_BOL = lblSerie.Text & "-" & Me.lblNumeroComprobante.Text
                print_fact_bol.xRazonSocial = lblNombres.Text.Trim
                print_fact_bol.xDireccionRemitente = IIf(cmbDireccion.SelectedIndex > 0, cmbDireccion.Text.Trim, "")
                print_fact_bol.xRuc = lblNumeroDocumento.Text.Trim
                print_fact_bol.xConsignado = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO
                print_fact_bol.xDireccionConsignado = lblTipoEntrega.Text.Trim
                print_fact_bol.xfecha_factura = lblFecha.Text
                print_fact_bol.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
                print_fact_bol.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
                print_fact_bol.xTotalSobres = 0
                print_fact_bol.xNroRef = lblSerie.Text & "-" & lblNumeroComprobante.Text
                print_fact_bol.xMemo = ""
                print_fact_bol.xMonto_Sub_Total = txtSubTotal.Text
                print_fact_bol.xMonto_Impuesto = txtImpuesto.Text
                print_fact_bol.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
                print_fact_bol.xDescuento = ""
                'print_fact_bol.xAgenciaDestino = lblAgenciaDestino.Text
                print_fact_bol.xAgenciaDestino = cboAgenciaDestino.Text
                print_fact_bol.xTIPO_ENTREGA = lblTipoEntrega.Text
            Else
                '-->Validacion Solo equipajes
                If IsDBNull(row_equipaje.Cells(col_PesoVolumen.Index)) = False _
                    AndAlso Not String.IsNullOrEmpty(row_equipaje.Cells(col_PesoVolumen.Index).Value) _
                    AndAlso row_equipaje.Cells(col_PesoVolumen.Index).Value > 0 Then
                    '-->Solo equipajes
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = row_equipaje.Cells(col_Bulto.Index).Value
                    ObjVentaCargaContado.v_TOTAL_PESO = row_equipaje.Cells(col_PesoVolumen.Index).Value
                    If (ObjVentaCargaContado.v_TOTAL_PESO > pesoMaxEquipaje) Then
                        ObjVentaCargaContado.v_TOTAL_PESO = pesoMaxEquipaje
                    End If
                Else
                    If row_peso.Cells(col_PesoVolumen.Index).Value > 0 Then
                        ObjVentaCargaContado.v_CANTIDAD_X_PESO = row_peso.Cells(col_Bulto.Index).Value
                        ObjVentaCargaContado.v_TOTAL_PESO = row_peso.Cells(col_PesoVolumen.Index).Value
                    End If
                    If row_volumen.Cells(col_PesoVolumen.Index).Value > 0 Then
                        ObjVentaCargaContado.v_CANTIDAD_X_PESO = row_volumen.Cells(col_Bulto.Index).Value
                        ObjVentaCargaContado.v_TOTAL_PESO = row_volumen.Cells(col_PesoVolumen.Index).Value
                    End If
                End If
                '-->Precios 
                ObjVentaCargaContado.v_PRECIO_X_PESO = 0
                ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = 0
                ObjVentaCargaContado.v_MONTO_SUB_TOTAL = 0.0
                ObjVentaCargaContado.v_MONTO_IMPUESTO = 0.0
                ObjVentaCargaContado.v_TOTAL_COSTO = 0.0
                '-->Totales
                ObjVentaCargaContado.v_SUB_TOTAL_CA = 0
                ObjVentaCargaContado.v_IMPUESTO_CA = 0
                ObjVentaCargaContado.v_TOTAL_CA = 0
                ObjVentaCargaContado.v_carga_acompañada = 0
            End If

            ObjVentaCargaContado.v_FechaPartida = boleto.fechaPartida
            ObjVentaCargaContado.v_HoraPartida = boleto.horaPartida
            ObjVentaCargaContado.v_servicio = boleto.servicio
            'ObjVentaCargaContado.v_asiento = boleto.asiento
            'ObjVentaCargaContado.v_total_boleto = boleto.total_boleto

            If blnEquipaje Then
                ObjVentaCargaContado.v_equipaje = 1
                ObjVentaCargaContado.v_MotivoEquipaje = strMotivoEquipaje
                ObjVentaCargaContado.v_UsuarioEquipaje = intUsuarioEquipaje
                ObjVentaCargaContado.v_NivelEquipaje = intNivelEquipaje
            Else
                ObjVentaCargaContado.v_equipaje = 0
                ObjVentaCargaContado.v_MotivoEquipaje = ""
                ObjVentaCargaContado.v_UsuarioEquipaje = 0
                ObjVentaCargaContado.v_NivelEquipaje = intNivelEquipaje
            End If

            '--->
            ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            ObjCODIGOBARRA.NroDOC = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
            ObjCODIGOBARRA.AGEDOM = Mid(lblTipoEntrega.Text, 1, 3)
            ObjVentaCargaContado.v_version = 2

            ObjVentaCargaContado.ObjCODIGOBARRA_2 = ObjCODIGOBARRA
            Return ObjVentaCargaContado
        Catch ex As Exception
            Throw New Excepcion(ex.Message)
        End Try
    End Function
    ''' <summary>
    ''' Carga el correlativo
    ''' </summary>
    ''' <param name="forceSearch">True para forzar la consulta del correlativo, false evalua si es necesario consultar</param>
    ''' <param name="idTipoComprobanteSearch">Identificador del tipo de comprobante, cuando se desea forsar la busqueda del correlativo por este identificador</param>
    Private Sub loadCorrelativo(Optional ByVal forceSearch As Boolean = False, Optional ByVal idTipoComprobanteSearch As Integer = 0)

        '-->Para evitar consultar por lo mismo
        If (Not forceSearch) Then
            If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_TICKET) AndAlso Double.Parse(txtTotal.Text) = 0) Then
                Return
            ElseIf (Not lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_TICKET) AndAlso Double.Parse(txtTotal.Text) > 0) Then
                Return
            End If
        End If

        Dim DIJITOS_SERIE As Integer = DIJITOS_SERIE, DIJITOS_COMPROBANTE As Integer = 7
        Dim idTipoComprobante As Integer = 0
        lblSerie.Text = ""
        lblNumeroComprobante.Text = ""

        If (idTipoComprobanteSearch = 0) Then
            chbxPagoContraEntrega.Checked = False
            '-> Validando el tipo de comprobante
            If (Double.Parse(txtTotal.Text) = 0) Then
                idTipoComprobante = ID_TIPOCOMPROBANTE_TICKET
                chbxPagoContraEntrega.Enabled = False
            Else
                'chbxPagoContraEntrega.Enabled = True
                If Not (chbxPagoContraEntrega.Checked) Then
                    If (boleto.titan_idTipoDocumento = 1) Then '--> SI ES RUC
                        idTipoComprobante = ID_TIPOCOMPROBANTE_FACTURA
                    Else
                        idTipoComprobante = ID_TIPOCOMPROBANTE_BOLETA
                    End If
                Else
                    idTipoComprobante = ID_TIPOCOMPROBANTE_PCE
                End If
            End If
        Else
            idTipoComprobante = idTipoComprobanteSearch
        End If

        '--> para mostrar el nombre del tipo de comprobante, en funcion al idTipoComprobante
        Select Case idTipoComprobante
            Case ID_TIPOCOMPROBANTE_TICKET
                lblTipoComprobante.Text = LABEL_TIPOCOMPROBANTE_TICKET
            Case ID_TIPOCOMPROBANTE_BOLETA
                lblTipoComprobante.Text = LABEL_TIPOCOMPROBANTE_BOLETA
            Case ID_TIPOCOMPROBANTE_FACTURA
                lblTipoComprobante.Text = LABEL_TIPOCOMPROBANTE_FACTURA
            Case ID_TIPOCOMPROBANTE_PCE
                lblTipoComprobante.Text = LABEL_TIPOCOMPROBANTE_PCE
        End Select

        If idTipoComprobante = ID_TIPOCOMPROBANTE_PCE Then
            Me.lblNumeroComprobante.Left = 719
            Me.lblNumeroComprobante.Width = 140
        Else
            Me.lblNumeroComprobante.Left = 789 '764
            Me.lblNumeroComprobante.Width = 95
        End If

        '-->Buscando la especie valorada
        If ventaContado.fnNroDocuemnto(idTipoComprobante, 0, IIf(idTipoComprobante = 3, 0, 1)) = True Then
            lblSerie.Text = RellenoRight(3, ventaContado.Serie)
            lblNumeroComprobante.Text = RellenoRight(DIJITOS_COMPROBANTE, ventaContado.NroDoc)
            If idTipoComprobante = ID_TIPOCOMPROBANTE_PCE Then
                lblNumeroComprobante.Text = RellenoRight(13, ventaContado.NroDoc)
            End If
        Else
            MessageBox.Show("Configure Serie y Número para el comprobante " + lblTipoComprobante.Text, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
    ''' <summary>
    ''' Habilita y/o deshabilita los controles
    ''' </summary>
    ''' <param name="enabled">True Habilita los controles, false Deshabilita los controles. </param>
    Private Sub enabledContros(ByVal enabled As Boolean)
        cmbFormaPago.Enabled = enabled
        If (enabled AndAlso cmbFormaPago.SelectedValue = ID_TIPO_PAGO_TARJETA) Then
            cmbTarjeta.Enabled = enabled
            txtNumeroTarjeta.Enabled = enabled
        ElseIf (Not enabled) Then
            cmbTarjeta.Enabled = enabled
            txtNumeroTarjeta.Enabled = enabled
        End If
        rbBusqDoct.Enabled = enabled
        rbBusqNombre.Enabled = enabled
        txtBusqCliente.Enabled = enabled
        btnBusqCliente.Enabled = enabled
        cmbDireccion.Enabled = enabled

        If (dgDetalleEquipaje.Rows.Count >= 1) Then dgDetalleEquipaje.Rows(0).ReadOnly = Not enabled '-->Peso
        If (dgDetalleEquipaje.Rows.Count >= 2) Then dgDetalleEquipaje.Rows(1).ReadOnly = Not enabled '-->Volumen
        If (dgDetalleEquipaje.Rows.Count >= 3) Then dgDetalleEquipaje.Rows(2).ReadOnly = Not enabled '-->Equipaje

        If (chbxPagoContraEntrega.Enabled) Then chbxPagoContraEntrega.Enabled = False
        btnGuardar.Enabled = enabled
    End Sub
#End Region
#Region "IMPRESION DE BOLETAS/FACTURAS"
    Private Function ImprimirFactura() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim blnCortesia As Boolean

        Dim flag As Boolean = False
        iSubTotal = 0
        iImpuesto = 0
        iTotal = 0
        Dim obj As New Imprimir
        Try
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

            Dim montoLetras As String = ConvercionNroEnLetras(print_fact_bol.xTotal_Costo)
            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim glosa3 As String = ""
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 1, ID_PRODUCTO_CA)
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                obj.Inicializar()
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda
                obj.Impresora = sImpresora

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                Dim iLong As Integer

                Dim sConsignado As String = print_fact_bol.xConsignado.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)


                iLong = IIf(iTamaño = 0, 36, iTamaño)
                y = iLong * pagina + 4
                y += 1
                i += 1

                blnCortesia = False
                If cmbFormaPago.SelectedValue = ID_TIPO_PAGO_CORTESIA Then
                    blnCortesia = True
                End If

                obj.EscribirLinea(y + 1, 70, LABEL_TIPO_PRODUCTO_CA) 'cambio 

                'If es_carga_asegurada Then
                '    obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                'Else
                obj.EscribirLinea(y + 1, 48, print_fact_bol.xAgenciaDestino)
                'End If

                obj.EscribirLinea(y, 48, print_fact_bol.xNRODOCFAC_BOL)
                obj.EscribirLinea(y + 2, 53, fnGetHora())

                obj.EscribirLinea(y + 4, 8, dia)
                obj.EscribirLinea(y + 4, 23, Mes)
                obj.EscribirLinea(y + 4, 42, Anio)

                obj.EscribirLinea(y + 5, 13, print_fact_bol.xRazonSocial)
                obj.EscribirLinea(y + 6, 13, print_fact_bol.xDireccionRemitente)
                obj.EscribirLinea(y + 7, 13, print_fact_bol.xOrigen)
                obj.EscribirLinea(y + 8, 13, sConsignado)
                obj.EscribirLinea(y + 9, 13, print_fact_bol.xDireccionConsignado)

                obj.EscribirLinea(y + 5, 66, print_fact_bol.xRuc)
                obj.EscribirLinea(y + 7, 66, print_fact_bol.xDestino)

                obj.EscribirLinea(y + 5, 105, print_fact_bol.xNroRef)
                obj.EscribirLinea(y + 7, 105, print_fact_bol.xFormaPago)
                obj.EscribirLinea(y + 8, 105, print_fact_bol.xTIPO_ENTREGA)

                If Not CDbl(print_fact_bol.xMonto_Sub_Total_Peso) = 0 Then
                    obj.EscribirLinea(y + 12, 13, print_fact_bol.xCantidad_Peso)
                    obj.EscribirLinea(y + 12, 23, "BULTOS")
                    obj.EscribirLinea(y + 12, 92, print_fact_bol.xTotalPeso)
                End If
                If Not CDbl(print_fact_bol.xMonto_Sub_Total_Vol) = 0 Then
                    obj.EscribirLinea(y + 13, 13, print_fact_bol.xCantidad_Vol)
                    obj.EscribirLinea(y + 13, 23, "BULTOS (V.)")
                    obj.EscribirLinea(y + 13, 92, print_fact_bol.xTotalVolumen)
                End If

                If CDbl(print_fact_bol.xMonto_Sub_Total_Sobre + print_fact_bol.xCantidad_Sobre) > 0 Then
                    obj.EscribirLinea(y + 14, 13, print_fact_bol.xCantidad_Sobre)
                    obj.EscribirLinea(y + 14, 23, "SOBRES")
                End If

                'If es_carga_asegurada Then
                '    ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                '    If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                '        iSubTotal = iSubTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                '    End If
                '    iSubTotal = FormatNumber(iSubTotal, 2)
                '    obj.EscribirLinea(y + 15, 23, "SEGURO CARGA")
                '    obj.EscribirLinea(y + 15, 110, Format(CDbl(iSubTotal.ToString.ToString), "####,###,###0.00").PadLeft(10, " "))
                '    Dim isub As String
                '    isub = Format(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total - iSubTotal, "0.00")
                '    obj.EscribirLinea(y + 12, 110, isub.ToString.PadLeft(10, " "))
                'Else
                obj.EscribirLinea(y + 12, 110, Format(CDbl(print_fact_bol.xMonto_Sub_Total.ToString), "####,###,###0.00").PadLeft(10, " "))
                'End If

                If CDbl(print_fact_bol.xTotal_Costo.ToString) > 400 Then
                    glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                    "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                    "Nº 033-2006-MTC." & Chr(13) & _
                    "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."

                    obj.EscribirLinea(y + 16, 23, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON")
                    obj.EscribirLinea(y + 17, 23, "EL GOBIERNO CENTRAL,SEGÚN D.L. Nº 940 - R.S. Nº 158 -2006-SUNAT/D.S.")
                    obj.EscribirLinea(y + 18, 23, "Nº 033-2006-MTC.")
                    obj.EscribirLinea(y + 19, 23, "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829.")
                ElseIf blnCortesia Then 'Me.grbPromocion.Visible Then  'hlamas 12-02-2014
                    obj.EscribirLinea(y + 16, 23, "CORTESIA")
                    obj.EscribirLinea(y + 17, 23, "CORTESIA")
                End If

                If Not blnCortesia Then
                    obj.EscribirLinea(y + 21, 11, "Son:  " & montoLetras)
                    obj.EscribirLinea(y + 23, 54, dtoUSUARIOS.iLOGIN)

                    obj.EscribirLinea(y + 21, 85, "S/.")
                    obj.EscribirLinea(y + 22, 85, "S/.")
                    obj.EscribirLinea(y + 23, 85, "S/.")

                    obj.EscribirLinea(y + 21, 110, print_fact_bol.xMonto_Sub_Total.PadLeft(10, " "))
                    obj.EscribirLinea(y + 22, 110, Format(CDbl(print_fact_bol.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 23, 110, Format(CDbl(print_fact_bol.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))
                Else
                    obj.EscribirLinea(y + 21, 11, "SERVICIOS PERSTADOS A TITULO GRATUITO")
                    obj.EscribirLinea(y + 22, 11, "(SON: CERO y 0/100 SOLES)")
                    obj.EscribirLinea(y + 23, 54, dtoUSUARIOS.iLOGIN)

                    obj.EscribirLinea(y + 21, 85, "S/.")
                    obj.EscribirLinea(y + 22, 85, "S/.")
                    obj.EscribirLinea(y + 23, 85, "S/.")

                    obj.EscribirLinea(y + 21, 110, "0.00")
                    obj.EscribirLinea(y + 22, 110, "0.00")
                    obj.EscribirLinea(y + 23, 110, "0.00")
                End If


                '-------------------------------------
                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = iLong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = iLong
                'frm.Documento = 1
                'frm.Text = "Factura"
                'frm.ShowDialog()
                '********************************************
                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar()
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function
    Public Function ImprimirBoleta() As Boolean
        Dim obj As New Imprimir
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim blnCortesia As Boolean
        Try
            Dim HoraSistema As String = fnGetHora()
            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""

            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim glosa3 As String = ""
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 2, ID_PRODUCTO_CA)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim flag As Boolean
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0

                Dim ilong As Integer
                Dim sConsignado As String = print_fact_bol.xConsignado.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)


                ilong = IIf(iTamaño = 0, 18, iTamaño)
                y = ilong * pagina + 4
                y += 1
                i += 1

                blnCortesia = False
                If cmbFormaPago.SelectedValue = ID_TIPO_PAGO_CORTESIA Then
                    blnCortesia = True
                End If

                obj.EscribirLinea(0, 20, LABEL_TIPO_PRODUCTO_CA) 'cambio

                obj.EscribirLinea(y, 6, print_fact_bol.xOrigen)
                obj.EscribirLinea(y + 1, 6, print_fact_bol.xfecha_factura)
                obj.EscribirLinea(y + 2, 6, print_fact_bol.xRazonSocial)
                obj.EscribirLinea(y + 3, 6, sConsignado)
                obj.EscribirLinea(y + 4, 6, print_fact_bol.xDireccionConsignado)
                obj.EscribirLinea(y, 30, print_fact_bol.xDestino)

                'If es_carga_asegurada Then
                '    obj.EscribirLinea(0, 30, v_ca)
                'End If

                obj.EscribirLinea(y + 1, 30, HoraSistema)
                obj.EscribirLinea(y + 1, 53, print_fact_bol.xFormaPago)
                obj.EscribirLinea(y, 52, print_fact_bol.xTIPO_ENTREGA)

                'y+7=12
                obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(print_fact_bol.xCantidad_Peso) + Val(print_fact_bol.xCantidad_Vol)).ToString)
                obj.EscribirLinea(y + 7, 46, print_fact_bol.xTotalPeso)
                obj.EscribirLinea(y + 7, 56, print_fact_bol.xTotalVolumen)
                'If es_carga_asegurada Then
                '    obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                'Else
                obj.EscribirLinea(y + 7, 67, Format(CDbl(print_fact_bol.xTotal_Costo), "###,###,###.00"))
                'End If

                obj.EscribirLinea(y + 7, 84, "BULTOS   " & Val(Val(print_fact_bol.xCantidad_Peso) + Val(print_fact_bol.xCantidad_Vol)).ToString)
                obj.EscribirLinea(y + 7, 105, print_fact_bol.xTotalVolumen)
                obj.EscribirLinea(y + 7, 112, print_fact_bol.xTotalPeso)
                'If es_carga_asegurada Then
                '    obj.EscribirLinea(y + 7, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                'Else
                obj.EscribirLinea(y + 7, 121, Format(CDbl(print_fact_bol.xTotal_Costo), "###,###,###.00"))
                'End If

                obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(print_fact_bol.xCantidad_Sobre).ToString)
                obj.EscribirLinea(y + 8, 84, "SOBRES   " & Val(print_fact_bol.xCantidad_Sobre).ToString)

                If Not blnCortesia Then
                    obj.EscribirLinea(y + 10, 67, Format(CDbl(print_fact_bol.xTotal_Costo), "###,###,###.00"))
                    obj.EscribirLinea(y + 10, 121, Format(CDbl(print_fact_bol.xTotal_Costo), "###,###,###.00"))
                Else
                    obj.EscribirLinea(y + 10, 67, "0.00")
                    obj.EscribirLinea(y + 10, 121, "0.00")
                End If

                obj.EscribirLinea(0, 16, dtoUSUARIOS.iLOGIN)


                If blnCortesia Then
                    obj.EscribirLinea(0, 90, "CORTESIA")
                    obj.EscribirLinea(0, 81, "CORTESIA")
                Else
                    obj.EscribirLinea(0, 90, dtoUSUARIOS.iLOGIN)
                End If

                'If es_carga_asegurada Then
                '    ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                '    iTotal = FormatNumber(iTotal, 2)
                '    If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                '        iTotal = iTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                '    End If

                '    obj.EscribirLinea(y + 9, 16, "SEGURO CARGA")
                '    obj.EscribirLinea(y + 9, 67, Format(CDbl(iTotal), "###,###,###.00"))

                '    obj.EscribirLinea(y + 9, 84, "SEGURO CARGA")
                '    obj.EscribirLinea(y + 9, 121, Format(CDbl(iTotal), "###,###,###.00"))
                'End If

                obj.EscribirLinea(3, 33, print_fact_bol.xNRODOCFAC_BOL)
                obj.EscribirLinea(y, 89, print_fact_bol.xOrigen)
                obj.EscribirLinea(y + 1, 89, print_fact_bol.xfecha_factura)
                obj.EscribirLinea(y + 2, 89, print_fact_bol.xRazonSocial)
                obj.EscribirLinea(y + 3, 89, sConsignado)
                obj.EscribirLinea(y + 4, 89, print_fact_bol.xDireccionConsignado)
                obj.EscribirLinea(y, 105, print_fact_bol.xDestino)
                obj.EscribirLinea(y + 1, 114, HoraSistema)

                obj.EscribirLinea(y + 1, 105, print_fact_bol.xFormaPago)
                obj.EscribirLinea(y, 120, print_fact_bol.xTIPO_ENTREGA)


                obj.EscribirLinea(0, 0, print_fact_bol.xIdFactura)
                obj.EscribirLinea(4, 30, print_fact_bol.xAgenciaDestino)
                obj.EscribirLinea(3, 82, print_fact_bol.xNRODOCFAC_BOL)
                obj.EscribirLinea(0, 82, print_fact_bol.xIdFactura)
                obj.EscribirLinea(4, 82, print_fact_bol.xAgenciaDestino)
                obj.EscribirLinea(0, 80, LABEL_TIPO_PRODUCTO_CA) 'cambio

                If blnCortesia Then
                    obj.EscribirLinea(y + 9, 30, "SERVICIOS PRESTADOS A TITULO GRATUITO")
                    obj.EscribirLinea(y + 11, 30, "(SON: CERO y 0/100 SOLES)")
                End If


                '----------------------
                obj.Comprimido = True
                obj.Tamaño = ilong
                obj.Imprimir()
                obj.Finalizar()

                '**********************************************
                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = ilong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = ilong
                'frm.Documento = 1
                'frm.Text = "Boleta"
                'frm.ShowDialog()
            End If

        Catch ex As Excepcion
            obj.Finalizar()
            Throw New Excepcion(ex.Message)
        End Try
        Return False
    End Function
#End Region
#Region "IMPRESION ETIQUETAS"
    Public Function GC420Encomienda(ByVal ObjVentaCargaContado As dtoVentaCargaContado) As Boolean
        Dim flag As Boolean = True
        Try
            Dim ObjCODIGOBARRA As dtoCODIGOBARRA = ObjVentaCargaContado.ObjCODIGOBARRA_2
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strProducto As String, strHoraPartida As String
            Dim strComprobante As String

            If ObjVentaCargaContado.v_iProceso = 6 Then
                strComprobante = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            Else
                strComprobante = ObjVentaCargaContado.v_nroboleto & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            End If

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            If ObjVentaCargaContado.v_iProceso = 11 Then
                ObjCODIGOBARRA.Destino = fnGetCiudad(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            Else
                'ObjCODIGOBARRA.Destino = fnGetCiudad(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
                ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            End If
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 0
            Dim j As Int16
            j = 1

            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String = "", strFecha As String
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                strProducto = ObtieneProducto(ObjVentaCargaContado.v_iProceso) '& " " & ObjVentaCargaContado.v_HoraPartida
                strHoraPartida = ObjVentaCargaContado.v_HoraPartida
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,9,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                'prn.EscribeLinea("A30,47,0,3,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")

                'hlamas 04-03-2017
                'prn.EscribeLinea("A30,47,0,3,1,1,N,""" & strComprobante & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                'prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,37,0,4,1,1,N,""" & strComprobante & """")
                prn.EscribeLinea("A310,37,0,3,1,1,N,""" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")

                'prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
                prn.EscribeLinea("A30,118,0,3,1,1,N,""" & strHoraPartida & """")
                Dim a As String = ObjVentaCargaContado.v_NRO_FACTURA

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,148,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,148,0,1,1,1,N,""JOTASYS""")
                prn.EscribeLinea("A350,148,0,4,1,1,N,""" & strProducto & """") '290

                'hlamas 15-05-2017
                If ObjVentaCargaContado.v_iProceso = 11 Then
                    'prn.EscribeLinea("A150,85,0,2,1,1,N,""" & ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & """")
                    prn.EscribeLinea("A30,85,0,2,1,1,N,""" & ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & """")
                    prn.EscribeLinea("A30,167,0,2,1,1,N,""" & ObjCODIGOBARRA.Origen & "- """)
                    prn.EscribeLinea("A85,167,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                Else
                    prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & " - """)
                    prn.EscribeLinea("A89,75,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                End If

                prn.EscribeLinea("B162,69,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """") '148
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetas(ByVal ObjVentaCargaContado As dtoVentaCargaContado) As Boolean
        Dim flag As Boolean = True
        Try
            Dim ObjCODIGOBARRA As dtoCODIGOBARRA = ObjVentaCargaContado.ObjCODIGOBARRA_2
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)

            If ObjVentaCargaContado.v_iProceso = 11 Then
                ObjCODIGOBARRA.Destino = fnGetCiudad(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            Else
                ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            End If
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim i As Int16 = 0
            Dim j As Int16
            j = 1

            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String = "", strFecha As String
            Dim strProducto As String
            Dim strHoraPartida As String
            Dim strComprobante As String

            If ObjVentaCargaContado.v_iProceso = 6 Then
                strComprobante = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            Else
                strComprobante = ObjVentaCargaContado.v_nroboleto & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            End If

            While i <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                strProducto = ObtieneProducto(ObjVentaCargaContado.v_iProceso)
                strHoraPartida = ObjVentaCargaContado.v_HoraPartida
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(i)(0).ToString
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")

                'hlamas 14-03-2017
                'prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                prn.EscribeLinea("^FT15,82^A0N,28,28^FH\^FD " & strComprobante & "         " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "^FS")

                prn.EscribeLinea("^FT14,39^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,134^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                'prn.EscribeLinea("^FT17,131^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                'prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")

                'If ObjVentaCargaContado.v_iProceso = 11 Then
                'prn.EscribeLinea("^FT96,132^A0N,18,10^FH\^FD" & ObjCODIGOBARRA.Destino2 & " ^FS")
                'Else
                'prn.EscribeLinea("^FT96,132^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                'End If
                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")

                prn.EscribeLinea("^FT21,155^AAN,18,10^FH\^FD" & strHoraPartida & "^FS")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("^FT21,178^AAN,18,10^FH\^FD" & strFecha & "^FS")
                prn.EscribeLinea("^FT255,178^AAN,18,10^FH\^FDTEPSA^FS")
                'prn.EscribeLinea("^FT345,188^AAN,18,10^FH\^FD" & strCargo & "^FS")
                'prn.EscribeLinea("^FT300,188^A0N,20,12^FH\^FD" & strProducto & "^FS")
                prn.EscribeLinea("^FT340,178^AAN,18,10^FH\^FD" & strProducto & "^FS") '300 20

                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")

                'hlamas 15-05-2017
                If ObjVentaCargaContado.v_iProceso = 11 Then
                    prn.EscribeLinea("^FT17,131^AAN,18,10^FH\^FD" & ObjVentaCargaContado.v_SERIE_FACTURA & " - " & ObjVentaCargaContado.v_NRO_FACTURA & " /^FS")
                    prn.EscribeLinea("^FT17,203^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                    prn.EscribeLinea("^FT96,203^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")

                    'prn.EscribeLinea("^FT17,131^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                    'prn.EscribeLinea("^FT96,132^A0N,18,10^FH\^FD" & ObjCODIGOBARRA.Destino2 & " ^FS")
                    'prn.EscribeLinea("^FT150,198^AAN,18,10^FH\^FD" & ObjVentaCargaContado.v_SERIE_FACTURA & " - " & ObjVentaCargaContado.v_NRO_FACTURA & "")
                Else
                    prn.EscribeLinea("^FT17,131^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                    prn.EscribeLinea("^FT96,132^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                End If

                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                j = j + 1
                i += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetasFAC_II(ByVal ObjVentaCargaContado As dtoVentaCargaContado) As Boolean
        Dim flag As Boolean = True
        Try
            Dim ObjCODIGOBARRA As dtoCODIGOBARRA = ObjVentaCargaContado.ObjCODIGOBARRA_2
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 0
            Dim j As Int16
            'If iRango = 1 Then
            '    j = 1
            'ElseIf iRango = 2 Then
            '    j = correlativo_inicial
            'Else
            j = 1
            'End If


            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()

            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("<STX><ESC>C0<ETX>")
                prn.EscribeLinea("<STX><ESC>k<ETX>")
                prn.EscribeLinea("<STX><SI>N60<ETX>")
                prn.EscribeLinea("<STX><SI>L197<ETX>")
                prn.EscribeLinea("<STX><SI>S20<ETX>")
                prn.EscribeLinea("<STX><SI>d0<ETX>")
                prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
                prn.EscribeLinea("<STX><SI>l8<ETX>")
                prn.EscribeLinea("<STX><SI>I3<ETX>")
                prn.EscribeLinea("<STX><SI>F20<ETX>")
                prn.EscribeLinea("<STX><SI>D0<ETX>")
                prn.EscribeLinea("<STX><SI>t0<ETX>")
                prn.EscribeLinea("<STX><SI>W394<ETX>")
                prn.EscribeLinea("<STX><SI>g1,567<ETX>")
                prn.EscribeLinea("<STX><ESC>P<ETX>")
                prn.EscribeLinea("<STX>E*;F*;<ETX>")
                prn.EscribeLinea("<STX>L1;<ETX>")
                prn.EscribeLinea("<STX>D0;<ETX>")
                prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
                prn.EscribeLinea("<STX>D1;<ETX>")
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
                prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
                prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
                prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
                prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
                prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
                prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
                prn.EscribeLinea("<STX>R<ETX>")
                prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
                prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")
                '
                prn.EscribeLinea(cadena)
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

#End Region
    Private Sub frmEquipajes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub frmEquipajes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmEquipajes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            'SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmEquipajes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            clearFrom()
            enabledContros(False)
            ConfigurardgvCategoria()

            '-->Cargando parametros del sistema
            If Not (loadPameters(dtoUSUARIOS.m_iIdAgencia)) Then
                MessageBox.Show("Ha ocurrido un error al cargar algunos parámetros basicos del sistema. Por favor vuelva a intentarlo.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

            '-->Carga el correlativo
            loadCorrelativo()

            lblFecha.Text = dtoUSUARIOS.m_sFecha
            loadTiposDataGridview()
            ObjVentaCargaContado = Nothing
            ObjVentaCargaContado = New dtoVentaCargaContado

            xIMPRESORA = fnSeleccionImpresion()

            Me.grbCategoria.Enabled = dtoUSUARIOS.FormatoTicket = 2

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub mtbBoleto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mtbBoleto.KeyDown
        Try

            If (e.KeyCode = Keys.Enter) Then btnBuscarBoleto_Click(Nothing, Nothing)

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnBuscarBoleto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarBoleto.Click
        Try
            If (mtbBoleto.Text.Trim.Length > 1) Then
                Me.Cursor = Cursors.WaitCursor

                showBoleto()

                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbFormaPago_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedValueChanged
        Try
            If IsNumeric(cmbFormaPago.SelectedValue) AndAlso cmbFormaPago.SelectedValue = ID_TIPO_PAGO_TARJETA Then
                cmbTarjeta.SelectedIndex = 0
                cmbTarjeta.Enabled = True
                txtNumeroTarjeta.Enabled = True
            Else
                If (cmbTarjeta.Items.Count > 0) Then cmbTarjeta.SelectedIndex = 0
                cmbTarjeta.Enabled = False
                txtNumeroTarjeta.Enabled = False
                txtNumeroTarjeta.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtBusqCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqCliente.KeyDown
        Try
            If (e.KeyCode = Keys.Enter AndAlso txtBusqCliente.Text.Trim.Length > 0) Then
                Cursor = Cursors.WaitCursor

                '-->Limpiando propiedades del pasajero
                boleto.titan_rw_cliente = Nothing
                boleto.numeroDocumento = ""
                boleto.apellidoPaterno = ""
                boleto.apellidoMaterno = ""
                boleto.nombes = ""
                boleto.titan_idPersona = 0
                boleto.titan_idTipoDocumento = 0
                Me.cmbDireccion.DataSource = Nothing
                cmbDireccion.Items.Clear()

                Dim searhBy As Integer = IIf(rbBusqDoct.Checked, 1, 2)

                If Not (getPax_titan(searhBy, txtBusqCliente.Text.Trim)) Then
                    lblNumeroDocumento.Text = ""
                    lblNombres.Text = ""
                    boleto.nombes = ""
                    boleto.apellidoPaterno = ""
                    boleto.apellidoMaterno = ""
                    MessageBox.Show("El Cliente no existe", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnBusqCliente_Click(Nothing, Nothing)
                Else
                    '-->Por si es Ruc y se debe cambiar a facttura
                    loadCorrelativo(True)
                End If

                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dgDetalleEquipaje_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetalleEquipaje.CellEndEdit
        Try
            Dim row As DataGridViewRow = dgDetalleEquipaje.CurrentRow
            Dim dblDescuento As Double
            Select Case e.ColumnIndex
                Case col_Bulto.Index '-->Bulto
                    Dim bulto As Integer = row.Cells(e.ColumnIndex).Value
                    If (bulto <= 0) Then
                        row.Cells(e.ColumnIndex).Value = ""
                    End If
                Case col_PesoVolumen.Index '-->Peso/Volumen
                    Dim pesoVol As Double = IIf(String.IsNullOrEmpty(row.Cells(e.ColumnIndex).Value.ToString.Trim), 0, row.Cells(e.ColumnIndex).Value)

                    'hlamas 08-02-2017
                    pesoVol = RedondearMas(pesoVol)
                    dgDetalleEquipaje(e.ColumnIndex, row.Index).Value = pesoVol

                    Dim subNeto As Double = 0.0
                    If (row.Cells(col_tipo.Index).Value.Equals(tipos(2))) Then '-->Si es equipaje
                        '-->Valida el peso maximo permitido en equipaje
                        Dim dblMontoBoleto As Double
                        dblMontoBoleto = MontoBoleto(e.RowIndex + 3)
                        If dblMontoBoleto > 0 Then
                            If pesoVol = 0 Then
                                dblMontoBoleto = 0
                            Else
                                If dblMontoBoleto > pesoMaxEquipaje Then
                                    dblMontoBoleto = pesoMaxEquipaje
                                End If
                            End If
                        End If
                        If (pesoVol + dblMontoBoleto) > pesoMaxEquipaje Then
                            Dim tarifaPesoVol As Double = dgDetalleEquipaje(col_costo.Index, 0).Value
                            Dim exceso As Double = pesoVol + dblMontoBoleto - pesoMaxEquipaje
                            subNeto = exceso * tarifaPesoVol
                            row.Cells(col_costo.Index).Value = FormatNumber(tarifaPesoVol, 2)
                        Else
                            row.Cells(col_costo.Index).Value = FormatNumber(0, 2)
                        End If
                    Else
                        Dim tarifa As Double = row.Cells(col_costo.Index).Value
                        subNeto = pesoVol * tarifa
                    End If
                    row.Cells(col_subNeto.Index).Value = FormatNumber(subNeto, 2)
                    row.Cells(e.ColumnIndex).Value = FormatNumber(pesoVol, 2)


                    '-->Calcula totales
                    Dim total As Double = 0.0
                    For Each rowF As DataGridViewRow In dgDetalleEquipaje.Rows
                        total += rowF.Cells(col_subNeto.Index).Value
                    Next

                    'Descuento
                    If Me.GrpDescuento.Enabled AndAlso Val(Me.TxtDescuento.Text) > 0 Then
                        dblDescuento = CType(Me.TxtDescuento.Text, Double)
                        total = total * (1 - dblDescuento / 100)
                    End If

                    Dim impuesto As Double = (total / (dtoUSUARIOS.vImpuesto + 1) * dtoUSUARIOS.vImpuesto)
                    Dim subTotal As Double = total - impuesto
                    txtTotal.Text = FormatNumber(total, 2)
                    txtImpuesto.Text = FormatNumber(impuesto, 2)
                    txtSubTotal.Text = FormatNumber(subTotal, 2)

                    MontoMinimoPCE()

                    If Val(txtTotal.Text) = 0 Then
                        Me.cmbFormaPago.SelectedValue = 0
                        Me.tsbCorregir.Enabled = False
                    Else
                        Me.tsbCorregir.Enabled = True
                    End If
                    Descuento()
                    blnEquipaje = False

                    '-->Es necesario para determinar el tipo de comprobante a emitir(Bol, Fac, Ticket, ect)
                    loadCorrelativo()
            End Select

            'hlamas 03-07-2019
            Dim intBultos As Integer
            intBultos = getCantidad() 'Val(Me.dgDetalleEquipaje.Rows(2).Cells(1).Value)
            Me.btnAgregar.Enabled = intBultos > 0

        Catch ex As Exception
        End Try
    End Sub

    Sub MontoMinimoPCE()
        If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_PCE)) Then
            Dim total As Double
            If Val(Me.txtTotal.Text) = 0 Then
                total = 0
            Else
                total = CType(Me.txtTotal.Text, Double)
            End If
            If dtoGuia.MinimoPce(dtoUSUARIOS.m_idciudad, ObjVentaCargaContado.v_IDUNIDAD_DESTINO, ObjVentaCargaContado.v_IDPERSONA) = 1 Then
                If total < 20 Then
                    total = 20

                    Dim impuesto As Double = (total / (dtoUSUARIOS.vImpuesto + 1) * dtoUSUARIOS.vImpuesto)
                    Dim subTotal As Double = total - impuesto
                    txtTotal.Text = FormatNumber(total, 2)
                    txtImpuesto.Text = FormatNumber(impuesto, 2)
                    txtSubTotal.Text = FormatNumber(subTotal, 2)
                End If
            End If
        End If
    End Sub

    Private Sub dgDetalleEquipaje_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgDetalleEquipaje.EditingControlShowing
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
    End Sub
    Private Sub dgDetalleEquipaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetalleEquipaje.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                SendKeys.Send("{Tab}")
                e.SuppressKeyPress = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgDetalleEquipaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetalleEquipaje.LostFocus
        dgDetalleEquipaje.ClearSelection()
    End Sub
    'Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    '    Try
    '        Dim blnPago As Boolean = False
    '        Dim dtImpresora As DataTable = FEManager.buscarPrint()
    '        If dtImpresora Is Nothing Then
    '            MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Return
    '        End If

    '        If Me.lblNombres.Text.ToString.Trim.Length = 0 Then
    '            MessageBox.Show("Debe de seleccionar el Pasajero", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            txtBusqCliente.Focus()
    '            Return
    '        End If

    '        If cboAgenciaDestino.SelectedValue = 0 Then
    '            MessageBox.Show("Debe de seleccionar la Agencia Destino", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            cboAgenciaDestino.Focus()
    '            cboAgenciaDestino.DroppedDown = True
    '            Return
    '        End If

    '        'hlamas 16-05-2017
    '        'If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA)) AndAlso cmbFormaPago.SelectedIndex <= 0 Then
    '        '    MessageBox.Show("Debe de seleccionar la Forma de Pago.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        '    cmbFormaPago.Focus()
    '        '    Return
    '        'End If
    '        If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA)) And (cmbTarjeta.Enabled AndAlso cmbTarjeta.SelectedIndex <= 0) Then
    '            MessageBox.Show("Debe de seleccionar el tipo de tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            cmbTarjeta.Focus()
    '            Return
    '        End If
    '        If cmbTarjeta.SelectedIndex > 0 Then
    '            If Me.txtNumeroTarjeta.Text.Trim.Length = 0 Then
    '                MessageBox.Show("Ingres Número de Tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                txtNumeroTarjeta.Text = ""
    '                txtNumeroTarjeta.Focus()
    '                Return
    '            End If
    '        End If

    '        If lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA) Then
    '            If Me.cmbDireccion.SelectedIndex = 0 Then
    '                MessageBox.Show("Debe de seleccionar la Dirección Fiscal", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.cmbDireccion.Focus()
    '                Return
    '            End If
    '        End If
    '        If (boleto Is Nothing) Then
    '            MessageBox.Show("Debe de Ingresar el Boleto.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            mtbBoleto.Focus()
    '            Return
    '        End If
    '        If Val(Me.TxtDescuento.Text) <> 0 Then
    '            Dim iDescuento As Integer = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text.Trim, 0)
    '            If iDescuento > 0 Then
    '                If iDescuento < -100 Or iDescuento > 100 Then
    '                    MessageBox.Show("Ingrese un Monto de Descuento Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Me.TxtDescuento.Focus()
    '                    Me.TxtDescuento.SelectAll()
    '                    Return
    '                ElseIf Me.txtDescDescto.Text.Trim.Length = 0 Then
    '                    MessageBox.Show("Ingrese Nombre de la Persona que Autoriza el Descuento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    txtDescDescto.Text = ""
    '                    txtDescDescto.Focus()
    '                    txtDescDescto.SelectAll()
    '                    Return
    '                ElseIf Me.txtSustento.Text.Trim.Length = 0 Then
    '                    MessageBox.Show("Ingrese el Sustento del Descuento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    txtSustento.Text = ""
    '                    txtSustento.Focus()
    '                    txtSustento.SelectAll()
    '                    Return
    '                End If
    '            End If
    '        End If

    '        '-->Validando el ingreso de bultos y peso
    '        For Each row As DataGridViewRow In dgDetalleEquipaje.Rows
    '            '-->Validando que al ingresar la cantidad de bultos tambien se haya ingresado el peso/volumen
    '            If (Not String.IsNullOrEmpty(row.Cells(col_Bulto.Index).Value.ToString.Trim) AndAlso _
    '                (Double.Parse(row.Cells(col_PesoVolumen.Index).Value) <= 0)) Then
    '                MessageBox.Show("Debe de ingresar el " & row.Cells(col_tipo.Index).Value, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                row.Cells(col_PesoVolumen.Index).Selected = True
    '                Exit Sub
    '            ElseIf (String.IsNullOrEmpty(row.Cells(col_Bulto.Index).Value.ToString.Trim) AndAlso _
    '                    Double.Parse(row.Cells(col_PesoVolumen.Index).Value) > 0) Then
    '                '-->Validando que al ingresar el peso/volumen tambien se haya ingresado los numeros de bultos.
    '                MessageBox.Show("Debe de ingresar la cantidad de Bultos en el " & row.Cells(col_tipo.Index).Value, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                row.Cells(col_Bulto.Index).Selected = True
    '                Exit Sub
    '            End If
    '        Next

    '        '-->Validando que se haya ingresado el equipaje
    '        If (String.IsNullOrEmpty(dgDetalleEquipaje(col_Bulto.Index, 2).Value) AndAlso Double.Parse(txtTotal.Text) <= 0) Then
    '            MessageBox.Show("Debe de ingresar el equipaje del Pasajero", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            dgDetalleEquipaje(col_Bulto.Index, 2).Selected = True
    '            Return
    '        End If

    '        If (MessageBox.Show("¿Desea registrar el Equipaje y/o Carga Acompañada?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
    '            Me.Cursor = Cursors.WaitCursor

    '            'Obtiene numero de operacion
    '            intNivelEquipaje = NivelEquipaje(boleto.numeroBoleto)

    '            Dim lstVenta As New List(Of dtoVentaCargaContado)
    '            If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_TICKET)) Then
    '                '-->Solo Equipaje
    '                ObjVentaCargaContado = New dtoVentaCargaContado
    '                Dim venta_EQUIPAJE As dtoVentaCargaContado = getParamametersVenta(ID_PRODUCTO_EQUIPAJE)
    '                lstVenta.Add(venta_EQUIPAJE)
    '            Else
    '                'hlamas 12-12-2017
    '                '-->Luego el equipaje, pero antes valida que este exista
    '                'If (dgDetalleEquipaje(col_PesoVolumen.Index, 2).Value > 0) Then
    '                '    ObjVentaCargaContado = New dtoVentaCargaContado
    '                '    Dim venta_EQUIPAJE As dtoVentaCargaContado = getParamametersVenta(ID_PRODUCTO_EQUIPAJE, True)
    '                '    lstVenta.Add(venta_EQUIPAJE)
    '                'End If

    '                '-->Primero guarda la Carga Acompañada
    '                ObjVentaCargaContado = New dtoVentaCargaContado
    '                Dim venta_CA As dtoVentaCargaContado = getParamametersVenta(ID_PRODUCTO_CA)
    '                lstVenta.Add(venta_CA)
    '            End If


    '            'hlamas 16-05-2017
    '            'si es carga acompañada solicita tipo de pago
    '            Dim dlgPago As New frmPagoContado
    '            If Val(Me.txtTotal.Text) > 0 And (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA)) Then
    '                dlgPago.Numero = Me.lblNumeroDocumento.Text.Trim
    '                dlgPago.Cliente = Me.lblNombres.Text.Trim
    '                dlgPago.TotalVenta = CType(txtTotal.Text, Double).ToString("0.00")
    '                If dlgPago.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
    '                    blnPago = False
    '                    Cursor = Cursors.Default
    '                    Return
    '                Else
    '                    blnPago = True
    '                End If
    '            End If

    '            Dim idTipoComprobante As Long = 0
    '            Dim message As String = ""
    '            Dim intFila As Integer = 0
    '            Dim intCliente As Integer = 0
    '            '-->Impacta en la Base de Datos.
    '            For Each ventaContado As dtoVentaCargaContado In lstVenta
    '                intFila += 1
    '                If intFila = 2 Then 'equiáje y comprobante
    '                    ventaContado.v_IDPERSONA = intCliente
    '                End If
    '                '-->Guarda la venta y valida si esta se realizo correctamente
    '                If ventaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_PCE Then
    '                    ventaContado.v_IDTIPO_COMPROBANTE = 85
    '                    If ObjVentaCargaContado.GrabarVII() Then
    '                        ventaContado.v_IDTIPO_COMPROBANTE = 3
    '                        '-->Imprimiendo los codigos de barra.
    '                        If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
    '                            fnImprimirEtiquetas(ventaContado)
    '                        ElseIf xIMPRESORA = 2 Then
    '                            fnImprimirEtiquetasFAC_II(ventaContado)
    '                        Else
    '                            fnImprimirEtiquetasFAC_III(ventaContado)
    '                        End If
    '                        ImprimirGuiaEnvio()
    '                    Else
    '                        message = "No se pudo registrar el " & LABEL_TIPOCOMPROBANTE_PCE
    '                        message += " Nro. " & ventaContado.v_SERIE_FACTURA & " - " & ventaContado.v_NRO_FACTURA
    '                        MessageBox.Show(message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                Else
    '                    If (ventaContado.GrabarX(False)) Then
    '                        'hlamas 16-05-2017
    '                        'Grabar tipo de pagos
    '                        If ventaContado.v_iProceso = ID_PRODUCTO_CA AndAlso blnPago Then
    '                            GrabarTipoPago(dlgPago, ventaContado.v_IDFACTURA)
    '                            GrabarNotaCredito(dlgPago, ObjVentaCargaContado.v_IDPERSONA, dtImpresora)
    '                        End If

    '                        intCliente = ventaContado.v_IDPERSONA
    '                        '-->Validando si es CA.
    '                        If (ventaContado.v_iProceso = ID_PRODUCTO_CA) Then
    '                            idTipoComprobante = ventaContado.v_IDTIPO_COMPROBANTE
    '                            print_fact_bol.xIdFactura = ventaContado.v_IDFACTURA.ToString
    '                        End If

    '                        '-->Imprimiendo los codigos de barra.
    '                        If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
    '                            fnImprimirEtiquetas(ventaContado)
    '                        ElseIf xIMPRESORA = 2 Then
    '                            fnImprimirEtiquetasFAC_II(ventaContado)
    '                        Else
    '                            fnImprimirEtiquetasFAC_III(ventaContado)
    '                        End If
    '                    Else
    '                        Select Case ventaContado.v_IDTIPO_COMPROBANTE
    '                            Case ID_TIPOCOMPROBANTE_BOLETA
    '                                message = "No se pudo registrar la " & LABEL_TIPOCOMPROBANTE_BOLETA
    '                            Case ID_TIPOCOMPROBANTE_FACTURA
    '                                message = "No se pudo registrar la " & LABEL_TIPOCOMPROBANTE_FACTURA
    '                            Case ID_TIPOCOMPROBANTE_PCE
    '                                message = "No se pudo registrar el " & LABEL_TIPOCOMPROBANTE_PCE
    '                            Case ID_TIPOCOMPROBANTE_TICKET
    '                                message = "no se pudo registrar el " & LABEL_TIPOCOMPROBANTE_TICKET
    '                        End Select
    '                        If (ventaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_PCE) Then
    '                            message += " Nro. " & ventaContado.v_SERIE_FACTURA & " - " & ventaContado.v_NRO_FACTURA
    '                        Else
    '                            message += " Nro. " & ventaContado.v_NRO_GUIA
    '                        End If
    '                        MessageBox.Show(message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                End If
    '            Next
    '            '-->Ticket resumen
    '            'hlamas 08-05-2017
    '            'If lstVenta.Count <= 1 Then
    '            '    ImprimirTicket(lstVenta(0), dtImpresora)
    '            'Else
    '            '    ImprimirTicket(lstVenta(0), dtImpresora, lstVenta(1))
    '            'End If

    '            For Each ventaContado As dtoVentaCargaContado In lstVenta
    '                If ventaContado.v_iProceso = ID_PRODUCTO_CA Then
    '                    ImprimirTicket(ventaContado, dtImpresora)
    '                ElseIf ventaContado.v_iProceso = ID_PRODUCTO_EQUIPAJE Then
    '                    Dim obj As New dtoVentaCargaContado
    '                    Dim intCantidad As Integer = ventaContado.v_CANTIDAD_X_PESO
    '                    Dim intCodigoBarra As Integer = 0
    '                    For i As Integer = 1 To intCantidad
    '                        Dim strCodigo As String = obj.ListarCodigo(ventaContado.v_IDFACTURA, i)
    '                        ImprimirTicketEquipaje(ventaContado, dtImpresora, intCantidad, i, strCodigo)
    '                        'i = 1
    '                    Next
    '                End If
    '            Next

    '            enabledContros(False)
    '            MessageBox.Show("Registrado correctamente.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            btnGuardar.Enabled = False

    '            '*******************************************************************
    '            '-->EMISON DE LA FACTURA/BOLETA ELECTRONICA - HLAMAS - 09/02/2017
    '            '*******************************************************************
    '            If lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA) Then
    '                Try
    '                    Dim numeroComprobante As String = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
    '                    Emisionfe(numeroComprobante, dtImpresora)
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try
    '                '===================================================================
    '            End If
    '            tsbNuevo_Click(Nothing, Nothing)
    '        End If

    '        Me.Cursor = Cursors.Default
    '    Catch ex As Exception
    '        Me.Cursor = Cursors.Default
    '        MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim blnPago As Boolean = False
            Dim dtImpresora As DataTable = FEManager.buscarPrint()
            If dtImpresora Is Nothing Then
                MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If Me.lblNombres.Text.ToString.Trim.Length = 0 Then
                MessageBox.Show("Debe de seleccionar el Pasajero", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBusqCliente.Focus()
                Return
            End If

            If cboAgenciaDestino.SelectedValue = 0 Then
                MessageBox.Show("Debe de seleccionar la Agencia Destino", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboAgenciaDestino.Focus()
                cboAgenciaDestino.DroppedDown = True
                Return
            End If

            'hlamas 16-05-2017
            'If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA)) AndAlso cmbFormaPago.SelectedIndex <= 0 Then
            '    MessageBox.Show("Debe de seleccionar la Forma de Pago.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    cmbFormaPago.Focus()
            '    Return
            'End If
            If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA)) And (cmbTarjeta.Enabled AndAlso cmbTarjeta.SelectedIndex <= 0) Then
                MessageBox.Show("Debe de seleccionar el tipo de tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbTarjeta.Focus()
                Return
            End If
            If cmbTarjeta.SelectedIndex > 0 Then
                If Me.txtNumeroTarjeta.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingres Número de Tarjeta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNumeroTarjeta.Text = ""
                    txtNumeroTarjeta.Focus()
                    Return
                End If
            End If

            If lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA) Then
                If Me.cmbDireccion.SelectedIndex = 0 Then
                    MessageBox.Show("Debe de seleccionar la Dirección Fiscal", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cmbDireccion.Focus()
                    Return
                End If
            End If
            If (boleto Is Nothing) Then
                MessageBox.Show("Debe de Ingresar el Boleto.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mtbBoleto.Focus()
                Return
            End If
            If Val(Me.TxtDescuento.Text) <> 0 Then
                Dim iDescuento As Integer = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text.Trim, 0)
                If iDescuento > 0 Then
                    If iDescuento < -100 Or iDescuento > 100 Then
                        MessageBox.Show("Ingrese un Monto de Descuento Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtDescuento.Focus()
                        Me.TxtDescuento.SelectAll()
                        Return
                    ElseIf Me.txtDescDescto.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Nombre de la Persona que Autoriza el Descuento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtDescDescto.Text = ""
                        txtDescDescto.Focus()
                        txtDescDescto.SelectAll()
                        Return
                    ElseIf Me.txtSustento.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese el Sustento del Descuento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtSustento.Text = ""
                        txtSustento.Focus()
                        txtSustento.SelectAll()
                        Return
                    End If
                End If
            End If

            '-->Validando el ingreso de bultos y peso
            For Each row As DataGridViewRow In dgDetalleEquipaje.Rows
                '-->Validando que al ingresar la cantidad de bultos tambien se haya ingresado el peso/volumen
                If (Not String.IsNullOrEmpty(row.Cells(col_Bulto.Index).Value.ToString.Trim) AndAlso _
                    (Double.Parse(row.Cells(col_PesoVolumen.Index).Value) <= 0)) Then
                    MessageBox.Show("Debe de ingresar el " & row.Cells(col_tipo.Index).Value, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    row.Cells(col_PesoVolumen.Index).Selected = True
                    Exit Sub
                ElseIf (String.IsNullOrEmpty(row.Cells(col_Bulto.Index).Value.ToString.Trim) AndAlso _
                        Double.Parse(row.Cells(col_PesoVolumen.Index).Value) > 0) Then
                    '-->Validando que al ingresar el peso/volumen tambien se haya ingresado los numeros de bultos.
                    MessageBox.Show("Debe de ingresar la cantidad de Bultos en el " & row.Cells(col_tipo.Index).Value, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    row.Cells(col_Bulto.Index).Selected = True
                    Exit Sub
                End If
            Next

            '-->Validando que se haya ingresado el equipaje
            If (String.IsNullOrEmpty(dgDetalleEquipaje(col_Bulto.Index, 2).Value) AndAlso Double.Parse(txtTotal.Text) <= 0) Then
                MessageBox.Show("Debe de ingresar el equipaje del Pasajero", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgDetalleEquipaje(col_Bulto.Index, 2).Selected = True
                Return
            End If

            'hlamas 27-06-2019
            If dtoUSUARIOS.FormatoTicket = 2 Then
                If Not (Me.dgvCategoria.Rows.Count = getCantidad()) Then
                    MessageBox.Show("Debe asignar a cada equipaje una categoría", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnAgregar.Focus()
                    Return
                End If
            End If

            If (MessageBox.Show("¿Desea registrar el Equipaje y/o Carga Acompañada?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Me.Cursor = Cursors.WaitCursor

                'Obtiene numero de operacion
                intNivelEquipaje = NivelEquipaje(boleto.numeroBoleto)

                Dim lstVenta As New List(Of dtoVentaCargaContado)
                If (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_TICKET)) Then
                    '-->Solo Equipaje
                    ObjVentaCargaContado = New dtoVentaCargaContado
                    Dim venta_EQUIPAJE As dtoVentaCargaContado = getParamametersVenta(ID_PRODUCTO_EQUIPAJE)
                    lstVenta.Add(venta_EQUIPAJE)
                Else
                    'hlamas 12-12-2017
                    '-->Luego el equipaje, pero antes valida que este exista
                    'If (dgDetalleEquipaje(col_PesoVolumen.Index, 2).Value > 0) Then
                    '    ObjVentaCargaContado = New dtoVentaCargaContado
                    '    Dim venta_EQUIPAJE As dtoVentaCargaContado = getParamametersVenta(ID_PRODUCTO_EQUIPAJE, True)
                    '    lstVenta.Add(venta_EQUIPAJE)
                    'End If

                    '-->Primero guarda la Carga Acompañada
                    ObjVentaCargaContado = New dtoVentaCargaContado
                    Dim venta_CA As dtoVentaCargaContado = getParamametersVenta(ID_PRODUCTO_CA)
                    lstVenta.Add(venta_CA)
                End If


                'hlamas 16-05-2017
                'si es carga acompañada solicita tipo de pago
                Dim dlgPago As New frmPagoContado
                If Val(Me.txtTotal.Text) > 0 And (lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA)) Then
                    dlgPago.Numero = Me.lblNumeroDocumento.Text.Trim
                    dlgPago.Cliente = Me.lblNombres.Text.Trim
                    dlgPago.TotalVenta = CType(txtTotal.Text, Double).ToString("0.00")
                    If dlgPago.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        blnPago = False
                        Cursor = Cursors.Default
                        Return
                    Else
                        blnPago = True
                    End If
                End If

                Dim idTipoComprobante As Long = 0
                Dim message As String = ""
                Dim intFila As Integer = 0
                Dim intCliente As Integer = 0
                '-->Impacta en la Base de Datos.
                For Each ventaContado As dtoVentaCargaContado In lstVenta
                    intFila += 1
                    If intFila = 2 Then 'equiáje y comprobante
                        ventaContado.v_IDPERSONA = intCliente
                    End If
                    '-->Guarda la venta y valida si esta se realizo correctamente
                    If ventaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_PCE Then
                        ventaContado.v_IDTIPO_COMPROBANTE = 85
                        If ObjVentaCargaContado.GrabarVII() Then
                            ventaContado.v_IDTIPO_COMPROBANTE = 3
                            '-->Imprimiendo los codigos de barra.
                            If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                                fnImprimirEtiquetas(ventaContado)
                            ElseIf xIMPRESORA = 2 Then
                                fnImprimirEtiquetasFAC_II(ventaContado)
                            Else
                                If dtoUSUARIOS.FormatoTicket = 2 Then
                                    GC420Exceso(ventaContado)
                                Else
                                    GC420Encomienda(ventaContado)
                                End If
                            End If
                            ImprimirGuiaEnvio()
                        Else
                            message = "No se pudo registrar el " & LABEL_TIPOCOMPROBANTE_PCE
                            message += " Nro. " & ventaContado.v_SERIE_FACTURA & " - " & ventaContado.v_NRO_FACTURA
                            MessageBox.Show(message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        If (ventaContado.GrabarX(False)) Then
                            'hlamas 16-05-2017
                            'Grabar tipo de pagos
                            If ventaContado.v_iProceso = ID_PRODUCTO_CA AndAlso blnPago Then
                                GrabarTipoPago(dlgPago, ventaContado.v_IDFACTURA)
                                GrabarNotaCredito(dlgPago, ObjVentaCargaContado.v_IDPERSONA, dtImpresora)
                            End If

                            intCliente = ventaContado.v_IDPERSONA
                            '-->Validando si es CA.
                            If (ventaContado.v_iProceso = ID_PRODUCTO_CA) Then
                                idTipoComprobante = ventaContado.v_IDTIPO_COMPROBANTE
                                print_fact_bol.xIdFactura = ventaContado.v_IDFACTURA.ToString
                            End If

                            'hlamas 17-06-2019
                            'Graba categoria de equipajes
                            If dtoUSUARIOS.FormatoTicket = 2 Then
                                With Me.dgvCategoria
                                    If .Rows.Count > 0 Then
                                        Dim intCategoria As Integer, intBulto As Integer
                                        For i As Integer = 0 To .Rows.Count - 1
                                            intCategoria = .Rows(i).Cells("idcategoria").Value
                                            intBulto = .Rows(i).Cells("bulto").Value
                                            ObjVentaCargaContado.GrabarBultoCategoria(ventaContado.v_IDTIPO_COMPROBANTE, ventaContado.v_IDFACTURA, _
                                                                                      intCategoria, intBulto, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                                        Next
                                    End If
                                End With
                            End If

                            '-->Imprimiendo los codigos de barra.
                            If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                                fnImprimirEtiquetas(ventaContado)
                            ElseIf xIMPRESORA = 2 Then
                                fnImprimirEtiquetasFAC_II(ventaContado)
                            Else
                                If dtoUSUARIOS.FormatoTicket = 2 Then
                                    GC420Exceso(ventaContado)
                                Else
                                    GC420Encomienda(ventaContado)
                                End If
                            End If
                        Else
                            Select Case ventaContado.v_IDTIPO_COMPROBANTE
                                Case ID_TIPOCOMPROBANTE_BOLETA
                                    message = "No se pudo registrar la " & LABEL_TIPOCOMPROBANTE_BOLETA
                                Case ID_TIPOCOMPROBANTE_FACTURA
                                    message = "No se pudo registrar la " & LABEL_TIPOCOMPROBANTE_FACTURA
                                Case ID_TIPOCOMPROBANTE_PCE
                                    message = "No se pudo registrar el " & LABEL_TIPOCOMPROBANTE_PCE
                                Case ID_TIPOCOMPROBANTE_TICKET
                                    message = "no se pudo registrar el " & LABEL_TIPOCOMPROBANTE_TICKET
                            End Select
                            If (ventaContado.v_IDTIPO_COMPROBANTE = ID_TIPOCOMPROBANTE_PCE) Then
                                message += " Nro. " & ventaContado.v_SERIE_FACTURA & " - " & ventaContado.v_NRO_FACTURA
                            Else
                                message += " Nro. " & ventaContado.v_NRO_GUIA
                            End If
                            MessageBox.Show(message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        End If
                Next
                '-->Ticket resumen
                'hlamas 08-05-2017
                'If lstVenta.Count <= 1 Then
                '    ImprimirTicket(lstVenta(0), dtImpresora)
                'Else
                '    ImprimirTicket(lstVenta(0), dtImpresora, lstVenta(1))
                'End If

                For Each ventaContado As dtoVentaCargaContado In lstVenta
                    If ventaContado.v_iProceso = ID_PRODUCTO_CA Then
                        ImprimirTicket(ventaContado, dtImpresora)
                    ElseIf ventaContado.v_iProceso = ID_PRODUCTO_EQUIPAJE Then
                        Dim obj As New dtoVentaCargaContado
                        Dim intCantidad As Integer = ventaContado.v_CANTIDAD_X_PESO
                        Dim intCodigoBarra As Integer = 0
                        For i As Integer = 1 To intCantidad
                            Dim strCodigo As String = obj.ListarCodigo(ventaContado.v_IDFACTURA, i)
                            ImprimirTicketEquipaje(ventaContado, dtImpresora, intCantidad, i, strCodigo)
                            'i = 1
                        Next
                    End If
                Next

                enabledContros(False)
                MessageBox.Show("Registrado correctamente.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnGuardar.Enabled = False

                '*******************************************************************
                '-->EMISON DE LA FACTURA/BOLETA ELECTRONICA - HLAMAS - 09/02/2017
                '*******************************************************************
                If lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Or lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA) Then
                    Try
                        Dim numeroComprobante As String = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
                        Emisionfe(numeroComprobante, dtImpresora)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    '===================================================================
                End If
                tsbNuevo_Click(Nothing, Nothing)
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnBusqCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusqCliente.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.Cursor = Cursors.AppStarting
            Dim frm As New FrmCliente2
            frm.iProducto = 0
            frm.iFicha = 1
            Dim iFila As Integer = 0
            Dim sNumero As String = ""
            Dim iTipo As Integer = 0, iDepartamento As Integer = 0, iProvincia As Integer = 0, iDistrito As Integer = 0, iId_via As Integer = 0
            Dim sVia As String = "", sNumero2 As String = "", sManzana As String = "", sLote As String = ""
            Dim iId_Nivel As Integer = 0, iId_Zona As Integer = 0, iId_Clasificacion As Integer = 0, iTipo2 As Integer = 0
            Dim sNivel As String = "", sZona As String = ""
            Dim sClasificacion As String = "", sNumero3 As String = "", sContacto As String = "", sNombresCont As String = "", sApCont As String = "", sAmCont As String = ""
            Dim bEsCliente As Boolean = False
            Dim sEmail As String = "", sTelfCliente As String = "", sNombresCli As String = "", sApCli As String = "", sAmCli As String = "", sCliente As String = ""


            frm.bClienteNuevo = True
            If Me.lblNumeroDocumento.Text.Trim.Length > 0 Or Me.lblNombres.Text.Trim.Length > 0 Then
                If Not (IsNothing(boleto.titan_rw_cliente)) AndAlso boleto.titan_rw_cliente.Table.Rows.Count > 0 Then '->Si no es nuevo
                    frm.bClienteNuevo = False
                    sNumero = boleto.numeroDocumento
                    sCliente = IIf(IsDBNull(boleto.titan_rw_cliente.Item("razon_social")), "", boleto.titan_rw_cliente.Item("razon_social"))
                    iTipo = IIf(IsDBNull(boleto.titan_rw_cliente.Item("tipo")), "", boleto.titan_rw_cliente.Item("tipo"))
                    sEmail = IIf(IsDBNull(boleto.titan_rw_cliente.Item("email")), "", boleto.titan_rw_cliente.Item("email"))
                    sTelfCliente = IIf(IsDBNull(boleto.titan_rw_cliente.Item("telefono")), "", boleto.titan_rw_cliente.Item("telefono"))
                    If Not iTipo = 1 Then
                        sNombresCli = boleto.nombes
                        sApCli = boleto.apellidoPaterno
                        sAmCli = boleto.apellidoMaterno
                        If sNombresCli.Trim.Length = 0 Then
                            sNombresCli = sCliente
                        End If
                    End If

                    Dim dtDireccion As DataTable = cmbDireccion.DataSource

                    iFila = Me.cmbDireccion.SelectedIndex
                    iDepartamento = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddepartamento")), 0, dtDireccion.Rows(iFila).Item("iddepartamento"))
                    iProvincia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("idprovincia")), 0, dtDireccion.Rows(iFila).Item("idprovincia"))
                    iDistrito = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddistrito")), 0, dtDireccion.Rows(iFila).Item("iddistrito"))
                    iId_via = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_via")), 0, dtDireccion.Rows(iFila).Item("id_via"))
                    sVia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("via")), "", dtDireccion.Rows(iFila).Item("via"))
                    sNumero2 = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("numero")), "", dtDireccion.Rows(iFila).Item("numero"))
                    sManzana = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("manzana")), "", dtDireccion.Rows(iFila).Item("manzana"))
                    sLote = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("lote")), "", dtDireccion.Rows(iFila).Item("lote"))
                    iId_Nivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_nivel")), 0, dtDireccion.Rows(iFila).Item("id_nivel"))
                    sNivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("nivel")), "", dtDireccion.Rows(iFila).Item("nivel"))
                    iId_Zona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_zona")), 0, dtDireccion.Rows(iFila).Item("id_zona"))
                    sZona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("zona")), "", dtDireccion.Rows(iFila).Item("zona"))
                    iId_Clasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion.Rows(iFila).Item("Id_Clasificacion"))
                    sClasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("Clasificacion")), "", dtDireccion.Rows(iFila).Item("Clasificacion"))
                End If
            End If

            frm.cargar(sNumero, sCliente, iTipo, sNombresCli, sApCli, sAmCli, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                       sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, _
                       sClasificacion, iTipo2, sNumero3, sContacto, sNombresCont, sApCont, sAmCont, sTelfCliente, bEsCliente, sEmail, False)

            frm.bContactoNuevo = False
            frm.ShowDialog()
            Me.Cursor = Cursors.Default
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.AppStarting
                If frm.TabCliente.SelectedIndex = 0 Then
                    getPax_titan(1, frm.txtnrodocumento.Text)
                    showPax(boleto)
                Else
                    '-->Valida si se ha ingreso un nuevo cliente
                    If (frm.bClienteNuevo) Then
                        boleto.titan_idPersona = 0

                        boleto.titan_idTipoDocumento = frm.CboTipoDocumento.SelectedValue
                        boleto.numeroDocumento = frm.TxtNumero.Text
                        If (frm.CboTipoDocumento.SelectedValue = 1) Then
                            boleto.nombes = frm.TxtCliente.Text.Trim
                            boleto.apellidoPaterno = ""
                            boleto.apellidoMaterno = ""
                        Else
                            boleto.apellidoMaterno = frm.TxtAMCliente.Text
                            boleto.apellidoPaterno = frm.TxtAPCliente.Text
                            boleto.nombes = frm.TxtCliente.Text
                        End If
                        '-->
                        showPax(boleto)
                    End If

                    If (frm.bDireccionModificada Or cmbDireccion.DataSource Is Nothing) Then
                        bDireccionModificada = frm.bDireccionModificada
                        Dim dt_Direccion As DataTable = getInstanceDataTableDireccion()
                        Dim dr_direccion As DataRow = dt_Direccion.NewRow
                        dr_direccion("direccion") = " (SELECCIONE)"
                        dt_Direccion.Rows.Add(dr_direccion)

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
                        dr_direccion = dt_Direccion.NewRow
                        dr_direccion("iddireccion_consignado") = -1
                        dr_direccion("direccion") = sDireccion.Trim
                        dr_direccion("id_via") = frm.CboVia.SelectedValue
                        dr_direccion("via") = frm.TxtVia.Text.Trim
                        dr_direccion("numero") = frm.TxtNumero2.Text.Trim
                        dr_direccion("manzana") = frm.TxtManzana.Text.Trim
                        dr_direccion("lote") = frm.TxtLote.Text.Trim
                        dr_direccion("id_nivel") = frm.CboNivel.SelectedValue
                        dr_direccion("nivel") = frm.TxtNivel.Text.Trim
                        dr_direccion("id_zona") = frm.CboZona.SelectedValue
                        dr_direccion("zona") = frm.TxtZona.Text.Trim
                        dr_direccion("id_clasificacion") = frm.CboClasificacion.SelectedValue
                        dr_direccion("clasificacion") = frm.TxtClasificacion.Text.Trim
                        dr_direccion("iddepartamento") = frm.CboDepartamento.SelectedValue
                        dr_direccion("idprovincia") = frm.CboProvincia.SelectedValue
                        dr_direccion("iddistrito") = frm.CboDistrito.SelectedValue
                        dt_Direccion.Rows.Add(dr_direccion)

                        Me.cmbDireccion.DataSource = dt_Direccion
                        cmbDireccion.DisplayMember = "direccion"
                        cmbDireccion.ValueMember = "iddireccion_consignado"
                        cmbDireccion.SelectedIndex = 1
                    End If
                    loadCorrelativo(True)
                End If

                Me.Cursor = Cursors.Default
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mtbBoleto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtbBoleto.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf Asc(e.KeyChar.ToString.ToUpper) >= 65 And Asc(e.KeyChar.ToString.ToUpper) <= 90 Then 'e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Dim intCortesia As Integer = 0
    Private Sub Emisionfe(ByVal numeroComprobante As String, ByVal dtImpresora As DataTable)
        If dtoUSUARIOS.IP = "192.168.50.47" Then
            Return
        End If

        Try
            '-->Dando formati al numero de comprobante
            Dim _numeroComprobante() As String = numeroComprobante.Split("-")
            Dim serie As String = _numeroComprobante(0)
            Dim correlativo As String = _numeroComprobante(1)
            Dim idProducto As Integer = ID_PRODUCTO_CA 'DirectCast(CboProducto.SelectedItem, DataRowView)(0)

            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = boleto.titan_idTipoDocumento 'iID_TipoDocCli
            fecliente.numeroDocumento = lblNumeroDocumento.Text 'TxtNroDocCliente.Text.Trim()
            fecliente.nombres = lblNombres.Text.Trim 'TxtNomCliente.Text.Trim.ToUpper()

            If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
                fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim
            Else
                fecliente.direccion = IIf(cmbDireccion.SelectedValue > 0, cmbDireccion.Text.Trim.ToUpper(), Nothing) 'IIf(CboDireccion.SelectedIndex > 0, CboDireccion.Text.Trim.ToUpper(), Nothing)
            End If
            Dim venta As New FEVenta
            venta.cliente = fecliente
            venta.numeroSerie = serie 'LblSerie.Text.Trim()
            venta.numeroCorrelativo = correlativo 'LblNroBoletaFact.Text.Trim()
            venta.fechaEmision = FechaServidor()
            venta.tipoComprobanteID = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE 'IIf(lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA), 2, 1)
            venta.opGravada = txtSubTotal.Text.Trim()
            venta.igv = txtImpuesto.Text.Trim()
            venta.total = txtTotal.Text.Trim()
            venta.totalLetras = ConvercionNroEnLetras(venta.total)
            venta.formaPago = cmbFormaPago.Text.Trim.ToUpper
            'hlamas 16-05-2017
            'Dim formaPagoID As Integer = ObjVentaCargaContado.v_IDTIPO_PAGO
            'If (formaPagoID = 5) Then '-->Cortesia
            '    venta.isCortesia = True
            'End If
            If intCortesia = 5 Then '-->Cortesia
                venta.isCortesia = True
            End If
            venta.formaPago = strTipoPago

            '-->Para la impresion
            venta.producto = LABEL_TIPO_PRODUCTO_CA 'CboProducto.Text.Trim
            venta.origen = Me.lblCiudadOrigen.Text.Trim.ToUpper 'LblCiudad.Text.Trim.ToUpper()
            venta.destino = Me.lblCiudadDestino.Text.Trim.ToUpper 'TxtCiudadDestino.Text.Trim.ToUpper()
            venta.remitenete = fecliente.nombres
            '->Consigando
            Dim consignado As String = lblNombres.Text.Trim '""
            'For Each row As DataGridViewRow In GrdNConsignado.Rows
            '    If (Not row Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells("Nombres").Value.ToString.Trim)) Then
            '        consignado += row.Cells("Nombres").Value
            '    End If
            'Next
            venta.consignado = consignado
            venta.tipoEntrega = "AGENCIA" 'CboTipoEntrega.Text.Trim.ToUpper()
            venta.direccionEntrega = "AGENCIA" 'CboDireccion2.Text.Trim.ToUpper()
            venta.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
            venta.usuarioEmision = dtoUSUARIOS.NameLogin
            venta.detalleVenta = FEManager.crearDetalleVentaCA(dgDetalleEquipaje, venta.total, False, False, idProducto, 2, pesoMaxEquipaje)
            venta.id = ObjVentaCargaContado.v_IDFACTURA
            venta.tabla = "T_FACTURA_CONTADO"

            'Dim result = FEManager.result
            Dim result = FEManager.sendVentaSunat(venta, dtImpresora)
            If (result.IsCorrect) Then
                Dim objFac As New ClsLbTepsa.dtoFACTURA
                objFac.actualizarEmisonFE(ObjVentaCargaContado.v_IDFACTURA, "T_FACTURA_CONTADO")
            End If
            MessageBox.Show(result.Message, "Emisión F.E.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            dtoVentaCargaContado.ActualizarElectronico(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE, ObjVentaCargaContado.v_IDFACTURA, ex.Message, 3)
        End Try
    End Sub

    Private Sub chbxPagoContraEntrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxPagoContraEntrega.CheckedChanged
        Dim dblDescuento As Double

        loadCorrelativo(True, IIf(Me.chbxPagoContraEntrega.Checked, 3, 0))

        '-->Calcula totales
        Dim total As Double = 0.0
        For Each rowF As DataGridViewRow In dgDetalleEquipaje.Rows
            total += rowF.Cells(col_subNeto.Index).Value
        Next

        'Descuento
        If Me.GrpDescuento.Enabled AndAlso Val(Me.TxtDescuento.Text) > 0 Then
            dblDescuento = CType(Me.TxtDescuento.Text, Double)
            total = total * (1 - dblDescuento / 100)
        End If

        Dim impuesto As Double = (total / (dtoUSUARIOS.vImpuesto + 1) * dtoUSUARIOS.vImpuesto)
        Dim subTotal As Double = total - impuesto
        txtTotal.Text = FormatNumber(total, 2)
        txtImpuesto.Text = FormatNumber(impuesto, 2)
        txtSubTotal.Text = FormatNumber(subTotal, 2)

        MontoMinimoPCE()
    End Sub

    Dim p_agencia, v_iDestino, v_iCredito, v_iDomicilio, v_iAgencia, p_domicilio, p_contado, p_destino, p_credito As String
    Public Function ImprimirGuiaEnvio() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim obj As New Imprimir
        Try
            ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
            'Dim objImpresora As New dtoVentaCargaContado
            If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3
            End If

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 3)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim flag As Boolean
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

            y = iLong * pagina + 2
            i += 1

            If flag Then
                '21-10-2011 
                Dim sConsignado As String = Me.lblNombres.Text.Trim 'ObjRptGuiaEnvio.P_NOMBRES_DESTI.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)
                'ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI.Replace(";", ",")
                ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = "" 'ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI.Replace(";", " ")

                'EliminarCaracter(ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI.Length)
                'EliminarCaracter(ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI.Length)
                '========================================================

                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

                obj.EscribirLinea(y, 22, Me.lblNumeroComprobante.Text.Trim)

                obj.EscribirLinea(y + 0, 60, LABEL_TIPO_PRODUCTO_CA) 'cambio 
                'obj.EscribirLinea(y, 82, ObjRptGuiaEnvio.p_codigo_iata_ori)
                obj.EscribirLinea(y, 82, objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN))
                'obj.EscribirLinea(y, 92, ObjRptGuiaEnvio.p_codigo_iata_desti)
                obj.EscribirLinea(y, 92, objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO))
                obj.EscribirLinea(y + 2, 0, Me.lblNumeroDocumento.Text.Trim)
                obj.EscribirLinea(y + 5, 0, Me.lblNombres.Text.Trim)

                'If ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Length > 40 Then
                Dim strDireccion As String = Me.cmbDireccion.Text.Trim
                If strDireccion.Length > 40 Then
                    obj.EscribirLinea(y + 3, 0, strDireccion.Substring(0, 41))
                    obj.EscribirLinea(y + 4, 0, strDireccion.Substring(41))
                Else
                    If Trim(strDireccion) <> "(SELECCIONE)" Then
                        obj.EscribirLinea(y + 6, 0, strDireccion)
                    End If
                End If
                obj.EscribirLinea(y + 5, 59, sConsignado)
                obj.EscribirLinea(y + 6, 59, "AGENCIA")

                obj.EscribirLinea(y + 2, 33, "")
                obj.EscribirLinea(y + 2, 43, "X")
                obj.EscribirLinea(y + 2, 54, "")
                obj.EscribirLinea(y + 2, 64, "X")
                obj.EscribirLinea(y + 2, 76, "")

                'obj.EscribirLinea(ObjRptGuiaEnvio.P_CARGO)
                obj.EscribirLinea(y + 9, 0, Me.lblNombres.Text.Trim)
                'obj.EscribirLinea(y + 9, 0, "FACTURAR A: " & ObjRptGuiaEnvio.P_NOMBRES_DESTI)

                obj.EscribirLinea(y + 8, 29, "")
                obj.EscribirLinea(y + 8, 59, Me.cboAgenciaDestino.Text)
                obj.EscribirLinea(y + 8, 84, "")

                'If Not (strNroGuias_Remision Is Nothing) Then
                '    If Val(strNroGuias_Remision.Trim.Length) < 126 Then
                '        strNroGuias_Remision = strNroGuias_Remision & Space(126 - Len(strNroGuias_Remision.Trim))
                '    End If
                '    strNroGuias_Remision = Mid(strNroGuias_Remision.Trim, 1, 126)

                '    Dim iGuiones As Integer
                '    iGuiones = DevuelveGuiones(strNroGuias_Remision)
                '    If iGuiones >= 7 Then       '3 lineas
                '        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                '        obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                '        obj.EscribirLinea(y + 13, 0, Trim(Mid(strNroGuias_Remision, 86, 42)))
                '    ElseIf iGuiones >= 4 Then   '2 lineas
                '        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                '        obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                '    Else                        '1 linea
                '        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                '    End If
                'End If

                'obj.EscribirLinea(y + 17, 26, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))
                obj.EscribirLinea(y + 17, 26, Format(CDate(FechaServidor.ToString.Substring(0, 10)), "dd     MM      yy"))

                obj.EscribirLinea(y + 13, 26, FormatNumber(CDbl(ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN), 2))
                obj.EscribirLinea(y + 13, 34, FormatNumber(CDbl(ObjVentaCargaContado.v_TOTAL_PESO), 2))
                obj.EscribirLinea(y + 13, 42, FormatNumber(CDbl(ObjVentaCargaContado.v_TOTAL_VOLUMEN), 2))
                obj.EscribirLinea(y + 13, 55, FechaServidor.ToString.Substring(0, 10))
                obj.EscribirLinea(y + 13, 69, ObjRptGuiaEnvio.p_Hora_Guia)

                'If ObjRptGuiaEnvio.P_TOTAL_SOBRES > 0 Then
                '    obj.EscribirLinea(y + 14, 57, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)
                'End If
                obj.EscribirLinea(y + 13, 10, "TOTAL A PAGAR S/. " & FormatNumber(CDbl(Me.txtTotal.Text), 2))


                '******************************
                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar() 'axl

                '******************************
                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = iLong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = iLong
                'frm.Documento = 1
                'frm.Text = "GE"
                'frm.ShowDialog()

            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Sub ImprimirTicket(ByVal venta As dtoVentaCargaContado, ByVal impresora As DataTable, Optional ByVal venta2 As dtoVentaCargaContado = Nothing)
        Dim prn As New FEManager
        Dim feventa As New FEVenta
        Dim fecliente As New FECliente

        fecliente.tipoDocumentoID = venta.ID_TipoDocCli
        fecliente.numeroDocumento = venta.v_NRO_DNI_RUC
        fecliente.nombres = venta.v_NOMBRES_RASONSOCIAL

        'If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
        'fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim.ToUpper
        'Else
        fecliente.direccion = IIf(cmbDireccion.SelectedIndex > 0, cmbDireccion.Text.Trim.ToUpper(), "")
        'End If
        feventa.cliente = fecliente

        Dim strSerie As String
        If lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Then
            strSerie = "B"
        ElseIf lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA) Then
            strSerie = "F"
        Else
            strSerie = ""
        End If

        feventa.numeroSerie = "" 'strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
        feventa.numeroCorrelativo = "" 'Me.lblNumeroComprobante.Text 'venta.v_NRO_FACTURA 'lblNumeroComprobante.Text.Trim

        feventa.cliente.direccion = venta.v_SERIE_FACTURA & "-" & venta.v_NRO_FACTURA
        If Not (venta2 Is Nothing) Then
            feventa.cliente.direccion = feventa.cliente.direccion & "  " & venta2.v_SERIE_FACTURA & "-" & venta2.v_NRO_FACTURA
        End If

        feventa.fechaEmision = FechaServidor()
        feventa.tipoComprobanteID = venta.v_IDTIPO_COMPROBANTE
        feventa.opGravada = 0
        feventa.igv = 0
        feventa.total = 0
        feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
        feventa.formaPago = IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
        Dim formaPagoID As Integer = cmbFormaPago.SelectedValue
        If (formaPagoID = 5) Then '-->Cortesia
            feventa.isCortesia = True
        End If

        '-->Para la impresion
        feventa.producto = IIf(venta.v_iProceso = 11, "EQUIPAJE", "CARGA ACOMPAÑADA")
        feventa.origen = lblCiudadOrigen.Text.Trim.ToUpper()
        feventa.destino = lblCiudadDestino.Text.Trim.ToUpper()
        feventa.remitenete = fecliente.nombres
        feventa.consignado = Me.lblNombres.Text.Trim.ToUpper
        feventa.tipoEntrega = "AGENCIA"
        feventa.direccionEntrega = "AGENCIA"
        feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
        feventa.usuarioEmision = dtoUSUARIOS.NameLogin
        feventa.detalleVenta = FEManager.CrearDetalleVenta(dgDetalleEquipaje, 0, False, False, venta.v_iProceso, 1)
        feventa.id = ObjVentaCargaContado.v_IDFACTURA
        feventa.tabla = "T_FACTURA_CONTADO"

        Dim result As New servicefe.Result
        'Dim result As New feserviceDesarrollo.Result
        prn.Print(feventa, "04", impresora, result, 1)
    End Sub

    Function ObtieneTipoComprobante(ByVal tipo As Integer) As String
        Select Case tipo
            Case 1
                Return "FAC"
            Case 2
                Return "BOL"
            Case 85
                Return "PCE"
        End Select
    End Function

    Function ObtieneProducto(ByVal producto As Integer) As String
        Select Case producto
            Case 0
                Return ""
            Case 6
                Return "CA"
            Case 8
                Return "TC"
            Case 10
                Return "SOB"
            Case 11
                Return "EQ"
            Case 81
                Return "BOX"
        End Select
    End Function

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        'If Val(Me.txtTotal.Text) = 0 Then
        '    If Me.cmbFormaPago.SelectedValue = 1 Or Me.cmbFormaPago.SelectedValue = 2 Then
        '        Me.cmbFormaPago.SelectedValue = 0
        '    End If
        'End If
        Descuento()
    End Sub

    Sub LimpiarDescuento()
        GrpDescuento.Enabled = False
        Me.TxtDescuento.Text = ""
        Me.txtDescDescto.Text = ""
    End Sub

    Sub Descuento()
        Dim dblTotal As Double
        dblTotal = IIf(Val(txtTotal.Text) = 0, 0, CType(Me.txtTotal.Text, Double))
        If dblTotal = 0 Then
            LimpiarDescuento()
        Else
            Me.GrpDescuento.Enabled = True
        End If

        Return
        'If IsReference(Me.cmbFormaPago.SelectedValue) Then Return
        If cmbFormaPago.SelectedValue > 0 Then
            If Me.cmbFormaPago.SelectedValue = 5 Then
                LimpiarDescuento()
            Else
                'LimpiarDescuento()
                If Val(Me.txtTotal.Text > 0) Then
                    Me.GrpDescuento.Enabled = True
                End If
            End If
        Else
            LimpiarDescuento()
        End If
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        Dim frm As New frmUsuarioDescuento
        frm.Venta = 2
        frm.Descuento = Me.TxtDescuento.Text
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtDescDescto.Text = frm.cboUsuario.Text
        End If
    End Sub

    Private Sub TxtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescuento.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = "." Then
                If Not (tb.SelectedText = ".") Then
                    e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "-" Then
                If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                    e.Handled = True
                End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescuento.TextChanged
        Try
            If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                txtDescDescto.Text = ""
                'hlamas 07-12-2015
                'txtDescDescto.Enabled = True
                'TxtDescuento.ReadOnly = False
                If Val(TxtDescuento.Text) > 0 Then
                    Me.btnAutorizar.Enabled = True
                    txtDescDescto.Enabled = False
                Else
                    Me.btnAutorizar.Enabled = False
                    txtDescDescto.Enabled = True
                    TxtDescuento.ReadOnly = False
                End If
            Else
                'hlamas 07-12-2015
                Me.btnAutorizar.Enabled = False
                txtDescDescto.Enabled = False
                txtDescDescto.Text = ""
            End If

            Dim ee As New DataGridViewCellEventArgs(2, 0)
            dgDetalleEquipaje_CellEndEdit(Nothing, ee)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Try
            boleto = Nothing
            clearFrom(True)
            loadCorrelativo(True, ID_TIPOCOMPROBANTE_TICKET)
            enabledContros(False)
            mtbBoleto.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCorregir.Click

        Dim frm As New frmCorregirEquipaje
        frm.TipoComprobante = Me.lblTipoComprobante.Text
        frm.NumeroComprobante = Me.lblSerie.Text & "-" & Me.lblNumeroComprobante.Text
        frm.Origen = Me.lblCiudadOrigen.Text
        frm.Destino = Me.lblCiudadDestino.Text
        'Acceso.Asignar(frm)
        'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim total As Double = CDbl(frm.txtMonto.Text)
            Dim impuesto As Double = (total / (dtoUSUARIOS.vImpuesto + 1) * dtoUSUARIOS.vImpuesto)
            Dim subTotal As Double = total - impuesto
            txtTotal.Text = FormatNumber(total, 2)
            txtImpuesto.Text = FormatNumber(impuesto, 2)
            txtSubTotal.Text = FormatNumber(subTotal, 2)
            blnEquipaje = True
            intUsuarioEquipaje = frm.intUsuario
            strMotivoEquipaje = frm.txtMotivo.Text

            loadCorrelativo()
        End If
        '
        'MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub tsbVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbVer.Click
        Dim frm As New frmBoletoComprobante
        frm.Boleto = mtbBoleto.Text.Trim
        frm.ShowDialog()
    End Sub

    Function MontoBoleto(ByVal opcion As Integer)
        If dtBoleto Is Nothing Then
            Return 0
        Else
            Return IIf(IsNothing(dtBoleto.Rows(0).Item(opcion)), 0, dtBoleto.Rows(0).Item(opcion))
        End If
    End Function

    Private Sub dgDetalleEquipaje_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetalleEquipaje.CellContentClick

    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Function NivelEquipaje(ByVal boleto As String) As Integer
        Dim obj As New dtoVentaCargaContado
        Return obj.NivelEquipaje(boleto)
    End Function

    Sub ImprimirTicketEquipaje(ByVal venta As dtoVentaCargaContado, ByVal impresora As DataTable, ByVal cantidad As Integer, ByVal item As Integer, ByVal codigo As String)
        Dim prn As New FEManager
        Dim feventa As New FEVenta
        Dim fecliente As New FECliente

        fecliente.tipoDocumentoID = venta.ID_TipoDocCli
        fecliente.numeroDocumento = venta.v_NRO_DNI_RUC
        fecliente.nombres = venta.v_NOMBRES_RASONSOCIAL
        fecliente.direccion = IIf(cmbDireccion.SelectedIndex > 0, cmbDireccion.Text.Trim.ToUpper(), "")
        feventa.cliente = fecliente

        Dim strSerie As String
        If lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Then
            strSerie = "B"
        ElseIf lblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA) Then
            strSerie = "F"
        Else
            strSerie = ""
        End If
        feventa.numeroSerie = "" 'strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
        feventa.numeroCorrelativo = "" 'Me.lblNumeroComprobante.Text 'venta.v_NRO_FACTURA 'lblNumeroComprobante.Text.Trim

        feventa.cliente.direccion = codigo 'venta.v_SERIE_FACTURA & "-" & venta.v_NRO_FACTURA
        'If Not (venta2 Is Nothing) Then
        'feventa.cliente.direccion = feventa.cliente.direccion & "  " & venta2.v_SERIE_FACTURA & "-" & venta2.v_NRO_FACTURA
        'End If

        feventa.fechaEmision = FechaServidor()
        feventa.tipoComprobanteID = venta.v_IDTIPO_COMPROBANTE
        feventa.opGravada = 0
        feventa.igv = 0
        feventa.total = 0
        feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
        feventa.formaPago = IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
        Dim formaPagoID As Integer = cmbFormaPago.SelectedValue
        If (formaPagoID = 5) Then '-->Cortesia
            feventa.isCortesia = True
        End If
        feventa.formaPago = venta.v_SERIE_FACTURA & "-" & venta.v_NRO_FACTURA

        '-->Para la impresion
        feventa.producto = IIf(venta.v_iProceso = 11, "EQUIPAJE", "CARGA ACOMPAÑADA")
        'feventa.origen = lblCiudadOrigen.Text.Trim.ToUpper()
        feventa.origen = Me.cboAgenciaDestino.Text
        feventa.destino = lblCiudadDestino.Text.Trim.ToUpper()

        'feventa.remitenete = fecliente.nombres
        feventa.remitenete = item.ToString.Trim & "/" & cantidad.ToString.Trim

        'feventa.consignado = Me.lblNombres.Text.Trim.ToUpper
        feventa.consignado = venta.v_servicio

        'feventa.tipoEntrega = "AGENCIA"
        'feventa.direccionEntrega = "AGENCIA"
        feventa.tipoEntrega = venta.v_FechaPartida
        feventa.direccionEntrega = venta.v_HoraPartida

        feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
        feventa.usuarioEmision = dtoUSUARIOS.NameLogin
        feventa.detalleVenta = FEManager.CrearDetalleVenta(dgDetalleEquipaje, 0, False, False, venta.v_iProceso, 1)
        feventa.id = ObjVentaCargaContado.v_IDFACTURA
        feventa.tabla = "T_FACTURA_CONTADO"

        Dim result As New servicefe.Result
        'Dim result As New feserviceDesarrollo.Result
        'result.barcode = codigo
        prn.Print(feventa, "04", impresora, result)
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
                                EnviarNotaCreditoSunat(dt.Rows(0), row.Cells("pago").Value, dblPago, intTipo, strSerie, strFecha, dtImpresora)

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

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim frm As New frmCategoriaEquipaje
        Dim intBultos As Integer

        frm.Tipo = 1
        frm.Inicio = Me.dgvCategoria.Rows.Count + 1

        intBultos = getCantidad() 'Integer.Parse(Me.dgDetalleEquipaje.Rows(2).Cells(1).Value)
        frm.Fin = intBultos
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            AgregarBulto(Integer.Parse(frm.cboBulto.Text), frm.cboCategoria.Text, frm.cboCategoria.SelectedValue)
            Me.btnAgregar.Enabled = Not (Me.dgvCategoria.Rows.Count = intBultos)
        End If
    End Sub

    Sub AgregarBulto(ByVal cantidad As Integer, ByVal categoria As String, ByVal idcategoria As Integer)
        Dim intFilas As Integer, intCantidad As Integer
        With Me.dgvCategoria
            intFilas = .Rows.Count
            For i As Integer = intFilas To cantidad - 1
                .Rows.Add()
                .Rows(i).Cells("bulto").Value = i + 1
                .Rows(i).Cells("categoria").Value = categoria
                .Rows(i).Cells("idcategoria").Value = idcategoria
            Next
        End With
    End Sub

    Private Sub dgvCategoria_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvCategoria.RowsAdded
        Me.btnEliminar.Enabled = True
    End Sub

    Private Sub dgvCategoria_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvCategoria.RowsRemoved
        Dim intBultos As Integer = getCantidad() 'Integer.Parse(Me.dgDetalleEquipaje.Rows(2).Cells(1).Value)
        Me.btnAgregar.Enabled = intBultos > 0
        Me.btnEliminar.Enabled = Me.dgvCategoria.Rows.Count > 0
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar el item seleccionado?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Me.dgvCategoria.Rows.RemoveAt(Me.dgvCategoria.CurrentCell.RowIndex)
            If Me.dgvCategoria.Rows.Count > 0 Then
                For i As Integer = 0 To Me.dgvCategoria.Rows.Count - 1
                    Me.dgvCategoria.Rows(i).Cells("bulto").Value = i + 1
                Next
            End If
        End If
    End Sub

    Private Function getCantidad() As Integer
        Dim cantidad As Integer = 0
        With dgDetalleEquipaje
            For Each row As DataGridViewRow In .Rows
                cantidad += Val(row.Cells(1).Value)
            Next
        End With
        Return cantidad
    End Function
    Function getCentrar(ByVal s As String, ByVal longitud As Integer) As String
        Dim l As Integer
        l = (longitud - s.Length) / 2
        If l < 0 Then
            l = 0
        End If
        Return Space(l) & s & Space(l)
    End Function

    Function getRecortar(ByVal s As String, ByVal longitud As Integer) As String
        If longitud >= s.Length Then
            Return s
        Else
            Return s.Substring(0, longitud)
        End If
    End Function

    Public Function GC420Exceso(ByVal ObjVentaCargaContado As dtoVentaCargaContado) As Boolean
        Dim flag As Boolean = True
        Try
            Dim ObjCODIGOBARRA As dtoCODIGOBARRA = ObjVentaCargaContado.ObjCODIGOBARRA_2
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strProducto As String

            Dim strHoraPartida As String, strFechaPartida As String
            Dim strAgenciaEmbarque As String, strAgenciaDesembarque As String

            Dim strComprobante As String

            If ObjVentaCargaContado.v_iProceso = 6 Then
                strComprobante = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            Else
                strComprobante = ObjVentaCargaContado.v_nroboleto & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            End If

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            If ObjVentaCargaContado.v_iProceso = 11 Then
                ObjCODIGOBARRA.Destino = fnGetCiudad(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            Else
                ObjCODIGOBARRA.Destino = fnGetCiudad(ObjVentaCargaContado.v_IDUNIDAD_DESTINO) 'objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            End If
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 0
            Dim j As Int16
            j = 1

            Dim dtBultoCategoria As DataTable = ObjVentaCargaContado.ListarBultoCategoria(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE, ObjVentaCargaContado.v_IDFACTURA)
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String = "", strFecha As String, strCategoria As String = ""
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                'hlamas 06-07-2019
                strFechaPartida = ObjVentaCargaContado.v_FechaPartida 'Me.DgvLista.CurrentRow.Cells("fecha_partida").Value
                strHoraPartida = ObjVentaCargaContado.v_HoraPartida
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString

                prn.EscribeLinea("N")
                prn.EscribeLinea("N")

                prn.EscribeLinea("A30,10,0,4,2,1,N,""JOTASYS""")
                If ObjVentaCargaContado.v_iProceso = 11 Then
                    prn.EscribeLinea("A30,50,0,2,1,1,N,""N.EQUIPAJE""")
                Else
                    prn.EscribeLinea("A490,10,0,4,2,1,N,""CA""")
                    prn.EscribeLinea("A30,50,0,2,1,1,N,""N.COMPROB.""")
                End If
                prn.EscribeLinea("A200,50,0,2,1,1,N,""PESO""")
                prn.EscribeLinea("A280,50,0,2,1,1,N,""PRECIO""")
                prn.EscribeLinea("A400,50,0,2,1,1,N,""EQUIPAJE""")

                prn.EscribeLinea("A30,70,0,3,1,1,N,""" & ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & """")
                prn.EscribeLinea("A210,70,0,3,1,1,N,""" & ObjVentaCargaContado.v_TOTAL_PESO & """")
                prn.EscribeLinea("A280,70,0,3,1,1,N,""" & Format(boleto.total_boleto, "0.00") & """")
                prn.EscribeLinea("A420,70,0,3,1,1,N,""" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")

                prn.EscribeLinea("A30,110,0,2,1,1,N,""N.BOLETO""")
                prn.EscribeLinea("A230,110,0,2,1,1,N,""F.VIAJE""")
                prn.EscribeLinea("A410,110,0,2,1,1,N,""HORA""")
                prn.EscribeLinea("A490,110,0,2,1,1,N,""ASIENTO""")

                prn.EscribeLinea("A30,130,0,3,1,1,N,""" & ObjVentaCargaContado.v_nroboleto & """")
                prn.EscribeLinea("A230,130,0,3,1,1,N,""" & strFechaPartida & """")
                prn.EscribeLinea("A390,130,0,4,2,2,N,""" & strHoraPartida & """")
                prn.EscribeLinea("A515,130,0,3,1,1,N,""" & boleto.asiento & """")

                prn.EscribeLinea("A30,190,0,4,1,1,N,""" & getCentrar(ObjCODIGOBARRA.clinte, 33) & """")
                prn.EscribeLinea("A30,220,0,4,2,2,N,""" & getCentrar(ObjCODIGOBARRA.Destino, 18) & """")

                prn.EscribeLinea("B370,300,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")

                If ObjVentaCargaContado.v_iProceso = 11 Then
                    prn.EscribeLinea("A30,300,0,2,1,1,N,""TIPO EQU:""")
                Else
                    prn.EscribeLinea("A30,300,0,2,1,1,N,""TIPO CAR:""")
                End If
                prn.EscribeLinea("A30,330,0,2,1,1,N,""EMBARQUE:""")
                prn.EscribeLinea("A30,360,0,2,1,1,N,""DESEMBAR:""")

                strCategoria = dtBultoCategoria.Rows(I).Item("categoria")
                'prn.EscribeLinea("A135,300,0,3,1,1,N,""" & getRecortar(fila("categoria"), 16) & """")
                prn.EscribeLinea("A135,300,0,3,1,1,N,""" & getRecortar(strCategoria, 16) & """")
                prn.EscribeLinea("A135,330,0,3,1,1,N,""" & getRecortar(boleto.agenciaOrigen, 16) & """")
                prn.EscribeLinea("A135,360,0,3,1,1,N,""" & getRecortar(boleto.agenciaDestino, 16) & """")


                '---------------------------------------------------------------------------------------------------------------
                'strProducto = ObtieneProducto(ObjVentaCargaContado.v_iProceso)
                'strHoraPartida = ObjVentaCargaContado.v_HoraPartida
                'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                'prn.EscribeLinea("N")
                'prn.EscribeLinea("N")
                'prn.EscribeLinea("A30,9,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")

                ''hlamas 04-03-2017
                'prn.EscribeLinea("A30,37,0,4,1,1,N,""" & strComprobante & """")
                'prn.EscribeLinea("A310,37,0,3,1,1,N,""" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")

                'prn.EscribeLinea("A30,118,0,3,1,1,N,""" & strHoraPartida & """")
                'Dim a As String = ObjVentaCargaContado.v_NRO_FACTURA

                'strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                'prn.EscribeLinea("A30,148,0,1,1,1,N,""" & strFecha & """")
                'prn.EscribeLinea("A230,148,0,1,1,1,N,""TEPSA""")
                'prn.EscribeLinea("A350,148,0,4,1,1,N,""" & strProducto & """") '290

                ''hlamas 15-05-2017
                'If ObjVentaCargaContado.v_iProceso = 11 Then
                '    prn.EscribeLinea("A30,85,0,2,1,1,N,""" & ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & """")
                '    prn.EscribeLinea("A30,167,0,2,1,1,N,""" & ObjCODIGOBARRA.Origen & "- """)
                '    prn.EscribeLinea("A85,167,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                'Else
                '    prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & " - """)
                '    prn.EscribeLinea("A89,75,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                'End If

                'prn.EscribeLinea("B162,69,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """") '148

                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetasFAC_III(ByVal ObjVentaCargaContado As dtoVentaCargaContado) As Boolean
        Dim flag As Boolean = True
        Try
            Dim ObjCODIGOBARRA As dtoCODIGOBARRA = ObjVentaCargaContado.ObjCODIGOBARRA_2
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strProducto As String, strHoraPartida As String
            Dim strComprobante As String

            If ObjVentaCargaContado.v_iProceso = 6 Then
                strComprobante = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            Else
                strComprobante = ObjVentaCargaContado.v_nroboleto & "  " & dtoVentaCargaContado.AgenciaNombreCorto(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            End If

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            If ObjVentaCargaContado.v_iProceso = 11 Then
                ObjCODIGOBARRA.Destino = fnGetCiudad(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            Else
                'ObjCODIGOBARRA.Destino = fnGetCiudad(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
                ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            End If
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 0
            Dim j As Int16
            j = 1

            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String = "", strFecha As String
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                strProducto = ObtieneProducto(ObjVentaCargaContado.v_iProceso) '& " " & ObjVentaCargaContado.v_HoraPartida
                strHoraPartida = ObjVentaCargaContado.v_HoraPartida
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,9,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                'prn.EscribeLinea("A30,47,0,3,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")

                'hlamas 04-03-2017
                'prn.EscribeLinea("A30,47,0,3,1,1,N,""" & strComprobante & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                'prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,37,0,4,1,1,N,""" & strComprobante & """")
                prn.EscribeLinea("A310,37,0,3,1,1,N,""" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")

                'prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
                prn.EscribeLinea("A30,118,0,3,1,1,N,""" & strHoraPartida & """")
                Dim a As String = ObjVentaCargaContado.v_NRO_FACTURA

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,148,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,148,0,1,1,1,N,""JOTASYS""")
                prn.EscribeLinea("A350,148,0,4,1,1,N,""" & strProducto & """") '290

                'hlamas 15-05-2017
                If ObjVentaCargaContado.v_iProceso = 11 Then
                    'prn.EscribeLinea("A150,85,0,2,1,1,N,""" & ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & """")
                    prn.EscribeLinea("A30,85,0,2,1,1,N,""" & ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA & """")
                    prn.EscribeLinea("A30,167,0,2,1,1,N,""" & ObjCODIGOBARRA.Origen & "- """)
                    prn.EscribeLinea("A85,167,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                Else
                    prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & " - """)
                    prn.EscribeLinea("A89,75,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                End If

                prn.EscribeLinea("B162,69,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """") '148
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
End Class
