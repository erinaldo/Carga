Imports System.Data.OracleClient
Imports AccesoDatos
Public Class dtoLiquiOficinaSisVyr
#Region "CONEXION"
    Dim cnn As New OracleConnection("data source=SISVYR; password=ventas5110; user id=vyr") '==>Produccion
    'Dim cnn As New OracleConnection("data source=VYR-DESA; password=ventas5110; user id=vyr") '==>Desarrollo
    Dim dataAdapter As OracleDataAdapter
#End Region
    ''' <summary>
    ''' CREA EL COMANDO
    ''' </summary>
    ''' <param name="commandContex">Nombre del PKG Y/O SP</param>
    ''' <returns>command</returns>
    Private Function command(ByVal commandContex As String)

        Dim cmd As New OracleCommand
        cnn.Open() '-->Abre la conexión
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = commandContex
        dataAdapter = New OracleDataAdapter(cmd)
        cnn.Close() '-->Cierra la conexión
        Return cmd
    End Function
    ''' <summary>
    ''' Busca el estado de las cajas, según parámetros enviados.
    ''' </summary>
    ''' <param name="fechaLiquidacion">Fecha de la Liquidación</param>
    ''' <param name="codigoAgencia">Código de la agencia asociada al de la Agencia del Sisvyr</param>
    ''' <returns>Lista de estados de las cajas</returns>
    Public Function buscarEstadoLiquidaciones(ByVal fechaLiquidacion As String, ByVal codigoAgencia As String) As DataSet
        With command("PKG_LIQOFI_TITAN.SP_ESTADO_LIQ")
            .Parameters.Add(New OracleClient.OracleParameter("V_FECHALIQ", OracleClient.OracleType.NVarChar)).Value = fechaLiquidacion
            .Parameters.Add(New OracleClient.OracleParameter("v_codigoAgencia", OracleClient.OracleType.NVarChar)).Value = codigoAgencia
            .Parameters.Add(New OracleClient.OracleParameter("CUR_ESTADO_LIQ", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim ds As New DataSet
        dataAdapter.Fill(ds)

        Return ds
    End Function
    ''' <summary>
    ''' Busca las liquidaciones cerras,segun fecha de liquidacion, pero que aun estan pendientes por asocial a la liquidacion de oficina.
    ''' </summary>
    ''' <param name="fechaLiquidacion">Fecha de la Liquidación</param>
    ''' <param name="codigoAgencia">Código de la agencia asociada al de la Agencia del Sisvyr</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function buscarLiquidacionCerradasXAsociar(ByVal fechaLiquidacion As String, ByVal codigoAgencia As Integer) As DataSet
        With command("PKG_LIQOFI_TITAN.SP_LIQ_CERRADA_X_ASO_OFI")
            .Parameters.Add(New OracleClient.OracleParameter("V_FECHALIQ", OracleClient.OracleType.NVarChar)).Value = fechaLiquidacion
            .Parameters.Add(New OracleClient.OracleParameter("v_codigoAgencia", OracleClient.OracleType.NVarChar)).Value = codigoAgencia
            .Parameters.Add(New OracleClient.OracleParameter("CUR_LIQ_CERRADA_X_ASOCIAR_OFI", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim ds As New DataSet
        dataAdapter.Fill(ds)

        Return ds
    End Function
    ''' <summary>
    ''' Realiza la busqueda de las ventas para luego transferir al TITAN - vrttrans_ventas_tmp
    ''' </summary>
    ''' <param name="idLiquidacion">Identificador de la liquidacion</param>
    ''' <returns>Lista de ventas</returns>
    Public Function buscarVentasTrans(ByVal idLiquidacion As Integer) As DataSet
        With command("PKG_LIQOFI_TITAN.SP_BUSCA_VENTAS_TRANS")
            .Parameters.Add(New OracleClient.OracleParameter("v_idLiquidacion", OracleClient.OracleType.Number)).Value = idLiquidacion
            .Parameters.Add(New OracleClient.OracleParameter("cur_ventas_trans", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
            .Parameters.Add(New OracleClient.OracleParameter("cur_gastos", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
            .Parameters.Add(New OracleClient.OracleParameter("cur_liquidacion", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
            .Parameters.Add(New OracleClient.OracleParameter("co_error", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim ds As New DataSet
        dataAdapter.Fill(ds)

        Return ds
    End Function
    ''' <summary>
    ''' REALIZA LA TRANSFERENCIA DE LAS VENTAS AL TITAN A LA TABLA TEMPORAL DENOMINADA "vrttrans_ventas_tmp"
    ''' </summary>
    ''' <param name="idVenta">Identificador de la Venta</param>
    ''' <param name="idPasajero">Identificador del pasajero</param>
    ''' <param name="apellidoPaternoPax">Apellido paterno del pasajero</param>
    ''' <param name="apellidoMaternoPx">Apellido materno del pasajero</param>
    ''' <param name="nombre1Pax">Primer nombre del pasajero</param>
    ''' <param name="nombres2Pax">Segundo nombre del pasajero</param>
    ''' <param name="nroDocumentoPax">Número de documento del pasajero</param>
    ''' <param name="idTipoDocumentoPax">Identificador del tipo de documento del pasajero</param>
    ''' <param name="idTipoComprobante">Identificador del tipo de comprobante "Boleto,Recivo de caja,etc" </param>
    ''' <param name="idFormaPago">Identificador de la forma de pago</param>
    ''' <param name="idTipoFormaPago">Identificador del tipo de form ad epago</param>
    ''' <param name="nroAsiento">Número de asiento</param>
    ''' <param name="montoBase">Monto base, que vendria a ser la tarifa del servicio</param>
    ''' <param name="recargo">Monto decargo</param>
    ''' <param name="descuento">Monto descuento</param>
    ''' <param name="penalidad">Monto penalidad</param>
    ''' <param name="montoTotal">Monto total, que vendria a ser el importe pagado por el Pasajero</param>
    ''' <param name="montoEfectivo_mixto">Monto pagado en efectivo, cuando es un pago mixto</param>
    ''' <param name="montoTarjeta_mixto">Monto pagado con tarjeta, cuando es un pago mixto</param>
    ''' <param name="idClase">Identificador de la clase, (Presidencial, Precidencial 40, etc.)</param>
    ''' <param name="codigoAgenciaVenta">Código de la agencia venta, es el código con el que se asocia la tabla Agencia del sisvyr con la del Titan.</param>
    ''' <param name="codigoAgenciaEmbarque">Código de la agencia donde se embarca el pasajero, es el código con el que se asocia la tabla Agencia del sisvyr con la del Titan.</param>
    ''' <param name="idOpeTarjeta">Identificador del operador de la tarjeta (Visa, MasterdCard, etc.)</param>
    ''' <param name="serie">Número de serie del boleto</param>
    ''' <param name="numeroBoleto">Número del boleto</param>
    ''' <param name="serieRef">Número de serie del boleto referencial o anterior</param>
    ''' <param name="numeroBoletoRef">Número de boleto referencial o anterior</param>
    ''' <param name="idCliente">Identificador del Cliente</param>
    ''' <param name="ruc">Número de ruc del cliente, solo cuando el boleto es impreso con RUC</param>
    ''' <param name="razonSocial">Razón social del cliente, solo cuando el boleto es impreso con RUC</param>
    ''' <param name="fechaVenta">Fecha en que se realiza la venta</param>
    ''' <param name="horaVenta">Hora en que se realiza la venta</param>
    ''' <param name="fechaViaje">Fecha en que el pasajero realizara el viaje</param>
    ''' <param name="horaSalida">Hora en que el pasajero realizara el viaje</param>
    ''' <param name="idUnidadOrigen">Identificador de la unidad agencia origen, a travez de este identificador se asocian las tablas Localidades en el Sisvyr y T_UnidadAgencia en el Titan.</param>
    ''' <param name="idUnidadDestino">Identificador de la unidad agencia destino, a travez de este identificador se asocian las tablas Localidades en el Sisvyr y T_UnidadAgencia en el Titan.</param>
    ''' <param name="codigoAgenciaOrigen">Código de la Agencia origen, es el código con el que se asocia la tabla Agencia del sisvyr con la del Titan.</param>
    ''' <param name="codigoAgenciaDestino">Código de la Agencia destino, es el código con el que se asocia la tabla Agencia del sisvyr con la del Titan.</param>
    ''' <param name="idUsuarioPersonal">Identificador del usuario que realiza la venta</param>
    ''' <param name="loginUsuario">Login del usuario que realiza la venta</param>
    ''' <param name="apellidoPartenoUsuario">Apellido paterbo del usuario que realiza la venta</param>
    ''' <param name="apellidoMaternoUsuario">Apellido materno del usuario que realiza la venta</param>
    ''' <param name="nombreUsuario">Nombres del usuario que realiza la venta</param>
    ''' <param name="codigoCuenta">Representa el RUC de la agencia o cliente credito</param>
    ''' <param name="idTipoMovimiento">Identificador del tipo de movimineto</param>
    ''' <param name="porcentajeDevo">Indica el porcentaje a la que equivale la devolución (80 100) </param>
    ''' <param name="esfechaAbirta">Indica si es un afecha abierta o una venta normal (1=fecha abierta;0=Venta normal)</param>
    ''' <param name="idPromocion">Identificador de la promocion</param>
    ''' <param name="idLiquidacion">Idenitificacior de la liquidacion</param>
    ''' <returns>Retona algun error que puede surjir durante la ejecucion del SP</returns>
    Public Function transfiereVentasTmp_Titan(ByVal idVenta As Long, ByVal idPasajero As Long, ByVal apellidoPaternoPax As String, ByVal apellidoMaternoPx As String, ByVal nombre1Pax As String,
                                     ByVal nombres2Pax As String, ByVal nroDocumentoPax As String, ByVal idTipoDocumentoPax As Integer, ByVal idTipoComprobante As Integer, ByVal idFormaPago As Integer,
                                     ByVal idTipoFormaPago As Integer, ByVal nroAsiento As Integer, ByVal montoBase As Double, ByVal recargo As Double, ByVal descuento As Double, ByVal penalidad As Double, ByVal montoTotal As Double,
                                     ByVal montoEfectivo_mixto As Double, ByVal montoTarjeta_mixto As Double, ByVal idClase As Integer, ByVal codigoAgenciaVenta As String, ByVal codigoAgenciaEmbarque As String,
                                     ByVal idOpeTarjeta As Integer, ByVal serie As String, ByVal numeroBoleto As String, ByVal serieRef As String, ByVal numeroBoletoRef As String, ByVal idCliente As Long, ByVal ruc As String, ByVal razonSocial As String,
                                     ByVal fechaVenta As String, ByVal horaVenta As String, ByVal fechaViaje As String, ByVal horaSalida As String, ByVal idUnidadOrigen As Integer, ByVal idUnidadDestino As String,
                                     ByVal codigoAgenciaOrigen As String, ByVal codigoAgenciaDestino As String, ByVal idUsuarioPersonal As Long, ByVal loginUsuario As String, ByVal apellidoPartenoUsuario As String,
                                     ByVal apellidoMaternoUsuario As String, ByVal nombreUsuario As String, ByVal codigoCuenta As String, ByVal idTipoMovimiento As Integer, ByVal porcentajeDevo As Integer,
                                     ByVal esfechaAbirta As Integer, ByVal idPromocion As Long, ByVal idLiquidacion As Long, ByVal igv As Double, ByVal imppagdif As Double) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_INS_VYRTRANS_VENTAS_TMP", CommandType.StoredProcedure)
            db.AsignarParametro("v_idVenta", idVenta, OracleClient.OracleType.Double)
            db.AsignarParametro("v_idPasajero", idPasajero, OracleClient.OracleType.Double)
            db.AsignarParametro("v_apellidoPartenoPax", apellidoPaternoPax, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoPx", apellidoMaternoPx, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_nombresPax1", nombre1Pax, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_nombresPax2", nombres2Pax, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_nroDocumentoPax", nroDocumentoPax, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idTipoDocPax", idTipoDocumentoPax, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_idTipoComprobante", idTipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_idFormaPago", idFormaPago, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_idTipoFormaPago", idTipoFormaPago, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nroAsiento", nroAsiento, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MontoBase", montoBase, OracleClient.OracleType.Double)
            db.AsignarParametro("v_recargo", recargo, OracleClient.OracleType.Double)
            db.AsignarParametro("v_descuento", descuento, OracleClient.OracleType.Double)
            db.AsignarParametro("v_penalidad", penalidad, OracleClient.OracleType.Double)
            db.AsignarParametro("v_montoTotal", montoTotal, OracleClient.OracleType.Double)
            db.AsignarParametro("v_montoEfectivo_mixto", montoEfectivo_mixto, OracleClient.OracleType.Double)
            db.AsignarParametro("v_montoTarjeta_mixto", montoTarjeta_mixto, OracleClient.OracleType.Double)
            db.AsignarParametro("v_idClase", idClase, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_codigoAgenciaVenta", codigoAgenciaVenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_codigoAgenciaEmbarque", codigoAgenciaEmbarque, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idOpeTarjeta", idOpeTarjeta, OracleClient.OracleType.Double)
            db.AsignarParametro("v_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroBoleto", numeroBoleto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_serieRef", serieRef, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroBoletoRef", numeroBoletoRef, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idCliente", idCliente, OracleClient.OracleType.Double)
            db.AsignarParametro("v_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_razonSocial", razonSocial, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_fechaVenta", fechaVenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_horaVenta", horaVenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_fechaViaje", fechaViaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_horaSalida", horaSalida, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idUnidadOrigen", idUnidadOrigen, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_idUnidadDestino", idUnidadDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_codigoAgenciaOrigen", codigoAgenciaOrigen, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_codigoAgenciaDestino", codigoAgenciaDestino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idUsuarioPersonal", idUsuarioPersonal, OracleClient.OracleType.Double)
            db.AsignarParametro("v_loginUsuario", loginUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apepatUsuario", apellidoPartenoUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apematUsuario", apellidoMaternoUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_nombreUsuario", nombreUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_codigoCuenta", codigoCuenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idTipomovimiento", idTipoMovimiento, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_porcentajeDevo", porcentajeDevo, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_esFechaAbierta", esfechaAbirta, OracleClient.OracleType.Double)
            db.AsignarParametro("v_idPromocion", idPromocion, OracleClient.OracleType.Double)
            db.AsignarParametro("v_idLiquidacion", idLiquidacion, OracleClient.OracleType.Double)
            db.AsignarParametro("v_igv", igv, OracleClient.OracleType.Double)
            db.AsignarParametro("v_imppagdif", imppagdif, OracleClient.OracleType.Double)
            db.AsignarParametro("Co_Error", OracleClient.OracleType.Cursor)

            '-->Por si ocuerre algun error
            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString())
                End If
            End If

            ' Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    ''' <summary>
    ''' REALIZA LA TRANSFERENCIA DE LA TABLA TEMPORAL "vrttrans_ventas_tmp" A LA TABLA T_VENTA_PASAJES
    ''' </summary>
    ''' <param name="fechaLiquidacion">Fecha de la liquidacion</param>
    ''' <param name="codigoAgenciaVenta">Código de la agencia donde se a realizado las ventas, es el código con el que se asocia la tabla Agencia del sisvyr con la del Titan.</param>
    ''' <returns>Retona algun error que puede surjir durante la ejecucion del SP</returns>
    Public Function procesarVentasTransferidas_titan(ByVal fechaLiquidacion As String, ByVal codigoAgenciaVenta As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_INS_TRANS_VTAPASAJES", CommandType.StoredProcedure)
            db.AsignarParametro("v_fechaLiquidacion", fechaLiquidacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_codigoAgenciaVenta", codigoAgenciaVenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("Co_Error", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)

            'Dim ds As DataSet = db.EjecutarDataSet
            '-->Por si ocuerre algun error
            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString())
                End If
            End If

            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    ''' <summary>
    ''' REALIZA LA TRANSFERENCIA DE LOS GASTOS DEL SISVYR AL TITAN
    ''' </summary>
    ''' <param name="idLiquidacionOficina">Identificador de la liquidacion de oficina, registrada en el TITAN</param>
    ''' <param name="idGastoSisyr">Identificador de la liquidacion de turno del Sisvyr</param>
    ''' <param name="idTipoGasto">Identificador del Gasto</param>
    ''' <param name="monto">Monto que asciende el gasto</param>
    ''' <param name="numeroDocumento">Numero de documento, si este es un peaje u otro sustendato con nro de documento</param>
    ''' <param name="nombrePiloto">nombre del pilo. Para los pasos de los peajes.</param>
    ''' <param name="codigoBus">Código de bus. Para el caso de los peajes</param>
    ''' <param name="consignado">Nombre del consignado. Es para los caso de pago de giros.</param>
    ''' <param name="observaciones">Observaciones sobre el gasto</param>
    ''' <param name="horaRegistro">Hora en se realiza el registro del gasto</param>
    ''' <param name="horaActualizacion">Hora en que se realiza la modificacion del gasto.</param>
    ''' <param name="fechaOperacion">Fecha a la que corresponde el gasto. Se toma de la fecha de la Liquidacion</param>
    ''' <param name="login">Login del usuario al que pertenece la liquidacion de turno</param>
    ''' <returns>Retona algun error que puede surjir durante la ejecucion del SP</returns>
    Public Function transfiereGastos_titan(ByVal idLiquidacionOficina As Long, ByVal idGastoSisyr As Long, ByVal idTipoGasto As Integer,
                                                    ByVal monto As Double, ByVal numeroDocumento As String, ByVal nombrePiloto As String,
                                                    ByVal codigoBus As String, ByVal consignado As String, ByVal observaciones As String,
                                                    ByVal horaRegistro As String, ByVal horaActualizacion As String,
                                                    ByVal fechaOperacion As String, ByVal login As String, ByVal idliquidacion_vyr As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_INS_VYRTRANS_GATOS", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDLiquidacionOficina", idLiquidacionOficina, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_IDGastos", idGastoSisyr, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_IDTipoGasto", idTipoGasto, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_Monto", monto, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_Nro_Documento", numeroDocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_Piloto", nombrePiloto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Nro_Bus", codigoBus, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Consignado", consignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Observaciones", observaciones, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Hora_Registro", horaRegistro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Hora_actualizacion", horaActualizacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Fecha_Operacion", fechaOperacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Login", login, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idliquidacion_vyr", idliquidacion_vyr, OracleClient.OracleType.VarChar)
            db.AsignarParametro("Co_Error", OracleClient.OracleType.Cursor)

            'Dim ds As DataSet = db.EjecutarDataSet
            '-->Por si ocurre algun error
            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString())
                End If
            End If

            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        End Try
    End Function
    ''' <summary>
    ''' Actualiza le campo fecha transferencia (d_fectra) en las tabla vrtvenpas en el Sisvyr
    ''' </summary>
    ''' <param name="idLiquidacion"></param>
    ''' <returns>Retona algun error que puede surjir durante la ejecucion del SP</returns>
    Public Function actualizaFechaTransSisvyr(ByVal idLiquidacion As Long)
        With command("PKG_LIQOFI_TITAN.SP_ACTUALIZA_VENTAS")
            .Parameters.Add(New OracleClient.OracleParameter("v_idLiquidacion", OracleClient.OracleType.Number)).Value = idLiquidacion
            .Parameters.Add(New OracleClient.OracleParameter("co_error", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim ds As New DataSet
        dataAdapter.Fill(ds)

        Return ds
    End Function
    ''' <summary>
    ''' Actualiza los campos que guardan las cantidades y totales de la venta de seguros en el TITAN
    ''' </summary>
    ''' <param name="idLiquidacion">Identificador de la liquidacion del Sisvyr</param>
    ''' <param name="cantidadPaxFree">Cantidad de ventas realizadas a Pasajeros Frecuentes</param>
    ''' <param name="cantidadPaxNor">Cantidad de ventas realizadas a Pasajeros normales</param>
    ''' <param name="totalPaxFree">Monto Total de ventas realizadas a Pasajeros Frecuentes</param>
    ''' <param name="totalPaxNor">Monto Total de ventas realizadas a Pasajeros normales</param>
    ''' <returns></returns>
    Public Function actuliazaVentaSeguros(ByVal idLiquidacion As Long, ByVal cantidadPaxFree As Integer, ByVal cantidadPaxNor As Integer,
                                    ByVal totalPaxFree As Double, ByVal totalPaxNor As Double) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_UPDATE_VENTA_SEGURO", CommandType.StoredProcedure)
            db.AsignarParametro("v_idLiquSisvyr", idLiquidacion, OracleClient.OracleType.Double)
            db.AsignarParametro("v_cantidadPaxFree", cantidadPaxFree, OracleClient.OracleType.Number)
            db.AsignarParametro("v_cantidadPaxNor", cantidadPaxNor, OracleClient.OracleType.Number)
            db.AsignarParametro("v_totalPaxfree", totalPaxFree, OracleClient.OracleType.Double)
            db.AsignarParametro("v_totalPaxNor", totalPaxNor, OracleClient.OracleType.Double)
            db.AsignarParametro("Co_Error", OracleClient.OracleType.Cursor)

            '-->Por si ocurre algun error
            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString())
                End If
            End If

            Return ds
        Catch ex As Exception
            Throw New Excepcion(ex.Message)
        End Try
    End Function

    Public Function buscarVentasPool(ByVal idLiquidacion As Long) As DataSet
        Try
            With command("PKG_LIQOFI_TITAN.SP_BUSCAR_VENTAS_POOL")
                .Parameters.Add(New OracleClient.OracleParameter("v_idLiquidacion", OracleClient.OracleType.Number)).Value = idLiquidacion
                .Parameters.Add(New OracleClient.OracleParameter("cur_ventas_pool", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
                .Parameters.Add(New OracleClient.OracleParameter("co_error", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
            End With

            Dim ds As New DataSet
            dataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            Throw New Excepcion(ex.Message)
        End Try
    End Function
    Public Sub actualizarVentasPool_Titan(idLiquidacion As Long, cantidadEfectivo As Integer, cantidadVisa As Integer, cantidadMastercard As Integer, montoEfectivo As Double, montoVisa As Double, montoMastercard As Double)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_UPDATE_VENTA_POOL", CommandType.StoredProcedure)
            db.AsignarParametro("v_idLiquSisvyr", idLiquidacion, OracleClient.OracleType.Double)
            db.AsignarParametro("v_cantidadEfectivo", cantidadEfectivo, OracleClient.OracleType.Number)
            db.AsignarParametro("v_cantidadVisa", cantidadVisa, OracleClient.OracleType.Number)
            db.AsignarParametro("v_cantidadMastercard", cantidadMastercard, OracleClient.OracleType.Number)
            db.AsignarParametro("v_montoEfectivo", montoEfectivo, OracleClient.OracleType.Double)
            db.AsignarParametro("v_montoVisa", montoVisa, OracleClient.OracleType.Double)
            db.AsignarParametro("v_montoMastercard", montoMastercard, OracleClient.OracleType.Double)
            db.AsignarParametro("Co_Error", OracleClient.OracleType.Cursor)

            '-->Por si ocurre algun error
            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString())
                End If
            End If

        Catch ex As Exception
            Throw New Excepcion(ex.Message)
        End Try

    End Sub
End Class
