Imports INTEGRACION_EN
Imports AccesoDatos
Public Class Cls_TarifarioPerso_AD
    Public Sub F_InsTarifario_AD(ByVal tarifaCliente As Cls_TarifaPersona_EN)
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("SP_INS_TARIFA_CLIENTE", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idTarifaCliente", tarifaCliente.idTarifaCliente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTarifaClienteCargo", tarifaCliente.idTarifaClienteCardo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idOrigen", tarifaCliente.Origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDestino", tarifaCliente.Destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idCentroCosto", tarifaCliente.SubCuenta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idPersona", tarifaCliente.idPersona, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTipoTarifa", tarifaCliente.TipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idProducto", tarifaCliente.PROCESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Base", tarifaCliente.BASE, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_Peso", tarifaCliente.Peso, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_Volumen", tarifaCliente.Volumen, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_Sobre", tarifaCliente.Sobre, OracleClient.OracleType.Number)

            db_bd.AsignarParametro("ni_peso_minimo", tarifaCliente.PesoMinimo, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_peso_minimo_flete", tarifaCliente.PesoMinimoFlete, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_volumen_minimo", tarifaCliente.VolumenMinimo, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_volumen_minimo_flete", tarifaCliente.VolumenMinimoFlete, OracleClient.OracleType.Number)

            db_bd.AsignarParametro("v_fecha_Activacion", tarifaCliente.fechaActivacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Ip", tarifaCliente.iP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idUsuario", tarifaCliente.Usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim lds_tmp As New DataSet
            lds_tmp = db_bd.EjecutarDataSet

        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub
    Public Sub F_InsTarifario_Articulo_AD(ByVal tarifaClienteArticulo As Cls_TarifaClienteArticulo)
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("SP_INS_TARIFA_CLIENTE_ARTICULO", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idtarifa_cliente_articulo", tarifaClienteArticulo.idTarifaClienteArticulo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTarifaCliente", tarifaClienteArticulo.tarifaCliente.idTarifaCliente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idOrigen", tarifaClienteArticulo.tarifaCliente.Origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDestino", tarifaClienteArticulo.tarifaCliente.Destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idCentroCosto", tarifaClienteArticulo.tarifaCliente.SubCuenta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idPersona", tarifaClienteArticulo.tarifaCliente.idPersona, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idProducto", tarifaClienteArticulo.tarifaCliente.PROCESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idArticulo", tarifaClienteArticulo.idArticulo, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_importe", tarifaClienteArticulo.importe, OracleClient.OracleType.Number)

            db_bd.AsignarParametro("v_minimo", tarifaClienteArticulo.minimo, OracleClient.OracleType.Number)

            db_bd.AsignarParametro("v_fecha_Activacion", tarifaClienteArticulo.fechaActivacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Ip", tarifaClienteArticulo.tarifaCliente.iP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idUsuario", tarifaClienteArticulo.tarifaCliente.Usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_tarifaCliente", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim lds_tmp As New DataSet
            lds_tmp = db_bd.EjecutarDataSet

            If (lds_tmp.Tables(1).Rows.Count > 0) Then '-->Setea el id tarifaCliente que se aya generado
                tarifaClienteArticulo.tarifaCliente.idTarifaCliente = lds_tmp.Tables(1).Rows(0).Item(0)
            End If

        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub
    Public Sub F_InactivarTarifa_Cliente_AD(ByVal v_idTarifaClienteCargo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        Dim db_bd As New BaseDatos
        db_bd.Conectar()
        db_bd.CrearComando("SP_ANULAR_TARIFA_CLIENTE", CommandType.StoredProcedure)
        db_bd.AsignarParametro("v_idtarifa_cliente_cargo", v_idTarifaClienteCargo, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("v_idUsuario", idUsuario, OracleClient.OracleType.VarChar)
        db_bd.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)

        Dim lds_tmp As New DataSet
        lds_tmp = db_bd.EjecutarDataSet
    End Sub
    Public Sub F_InactivarTarifa_Cliente_Articulo_AD(ByVal v_idTarifaClArticulo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        Dim db_bd As New BaseDatos
        db_bd.Conectar()
        db_bd.CrearComando("SP_ANULAR_TARIFA_C_ARTICULO", CommandType.StoredProcedure)
        db_bd.AsignarParametro("v_idTarifaClArticulo", v_idTarifaClArticulo, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("v_idUsuario", idUsuario, OracleClient.OracleType.VarChar)
        db_bd.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)

        Dim lds_tmp As New DataSet
        lds_tmp = db_bd.EjecutarDataSet
    End Sub
    ''' <summary>
    ''' BUSCA TARIFARIO PERSONALISADO DE UN CLIENTE
    ''' </summary>
    ''' <param name="idPersona">Identificador del Cliente</param>
    ''' <param name="idOrigen">Identificador del Origen</param>
    ''' <param name="idDestino">Identificador del Destino</param>
    ''' <param name="idProducto">Idenficador del Producto</param>
    ''' <param name="idTipoTarifa">Idenficador del Tipo de tarifa</param>
    ''' <param name="idCentroCosto">Identificador del Centro de costo</param>
    ''' <returns>Listado de Tarifas (Objeto DataTable)</returns>
    Public Function BuscarTarifa(ByVal idPersona As String, Optional ByVal idOrigen As Integer = 0, Optional ByVal idDestino As Integer = 0, Optional ByVal idProducto As Integer = 0, _
                                    Optional ByVal idTipoTarifa As Integer = 0, Optional ByVal idCentroCosto As Integer = 0) As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("SP_TARIFA_CLIENTE", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_cliente", idPersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idOrigen", idOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDestino", idDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idProducto", idProducto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTipoTarifa", idTipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idCentrocosto", idCentroCosto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_cliente_tarifa", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos_tarifa", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet

            Return lds_tmp
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
