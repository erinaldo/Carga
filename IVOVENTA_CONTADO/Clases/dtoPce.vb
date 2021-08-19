Imports AccesoDatos
Public Class dtoPce
#Region "MODULO GUIA DE ENVIO"
    Public Function FnLoadIniciarGuiaEnvio(ByVal vi_idusaurio_pesonal As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_IniciarGuiaEnvio", CommandType.StoredProcedure)
            db.AsignarParametro("vi_idusaurio_pesonal", vi_idusaurio_pesonal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_Listado_Tipo", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_Listado_Producto", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Listado_Agencias", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_t_Tipo_Entrega", OracleClient.OracleType.Cursor) '3
            db.AsignarParametro("co_SeleccionImpresion", OracleClient.OracleType.Cursor) '4
            db.AsignarParametro("co_ListarPersonas", OracleClient.OracleType.Cursor) '5
            db.AsignarParametro("co_Recupera_Monto_Minimo_PCE", OracleClient.OracleType.Cursor) '6
            db.AsignarParametro("co_Monto_Factor", OracleClient.OracleType.Cursor) '7
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '8
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            '--------Propagando el error----------------------------------
            If ds.Tables(8).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(8).Rows(0).Item(0)) Then
                    If ds.Tables(8).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(8).Rows(0).Item(1))
                    End If
                End If
            End If
            '-------------------------------------------------------------
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function fnLISTA_TARIFA_CLIENTE(ByVal sNU_DOCU_SUNAT As String, ByVal iIDUNIDAD_AGENCIA As Integer, ByVal iIDUNIDAD_AGENCIA_DESTINO As Integer, ByVal iIDCENTRO_COSTO As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.Conectar()
            db.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PERSONA_III", CommandType.StoredProcedure)
            db.AsignarParametro("iNu_Docu_Suna", sNU_DOCU_SUNAT, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_ORIGEN", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCENTROCOSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("curr_Tarifario", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("curr_Tarifario_config", OracleClient.OracleType.Cursor) '1
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnTARIFA_PUBLICA_CARGA1(ByVal iIDUNIDAD_AGENCIA As Integer, ByVal iIDUNIDAD_AGENCIA_DESTINO As Integer, ByVal TipoProducto_ As Integer, ByVal TipoTarifa_ As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", CommandType.StoredProcedure)
            db.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", TipoProducto_, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tarifa", TipoTarifa_, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)     '2       
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()

            '--------Propagando el error----------------------------------
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    If ds.Tables(2).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(2).Rows(0).Item(1))
                    End If
                End If
            End If
            '-------------------------------------------------------------          
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    '*****INSERCION DE N REGISTROS VOLUMETRICO*********
    Public Function FNinsert_Volumetrico(ByVal Limpiar As Integer, ByVal ID_VOLUMETRICO As Integer, ByVal v_ID_FACTURA As Integer, ByVal v_ITEM As Integer, ByVal v_CANTIDAD As Integer, _
                                         ByVal v_ALTURA As Double, ByVal v_ANCHO As Double, ByVal v_LARGO As Double, _
                                         ByVal v_PESO_KG As Double, ByVal v_FACTOR As Double, ByVal v_PRECIO_COSTO As Double)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_Ins_Volumetrico", CommandType.StoredProcedure)
            db.AsignarParametro("vi_LimpiarDatos", Limpiar, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ID_VOLUMETRICO", ID_VOLUMETRICO, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ID_FACTURA", v_ID_FACTURA, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_ITEM", v_ITEM, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_CANTIDAD", v_CANTIDAD, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_ALTURA", v_ALTURA, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_ANCHO", v_ANCHO, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_LARGO", v_LARGO, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_PESO_KG", v_PESO_KG, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_FACTOR", v_FACTOR, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_PRECIO_COSTO", v_PRECIO_COSTO, OracleClient.OracleType.Double)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '0         
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable

            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function FnDatosVolumetrico(ByVal vi_idFactura As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_IniciarGuiaEnvio", CommandType.StoredProcedure)
            db.AsignarParametro("vi_idusaurio_pesonal", vi_idFactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_Listado_Tipo", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_Listado_Producto", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Listado_Agencias", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_t_Tipo_Entrega", OracleClient.OracleType.Cursor) '3
            db.AsignarParametro("co_SeleccionImpresion", OracleClient.OracleType.Cursor) '4
            db.AsignarParametro("co_ListarPersonas", OracleClient.OracleType.Cursor) '5
            db.AsignarParametro("co_Recupera_Monto_Minimo_PCE", OracleClient.OracleType.Cursor) '6
            db.AsignarParametro("co_Monto_Factor", OracleClient.OracleType.Cursor) '7
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '8
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            '--------Propagando el error----------------------------------
            If ds.Tables(8).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(8).Rows(0).Item(0)) Then
                    If ds.Tables(8).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(8).Rows(0).Item(1))
                    End If
                End If
            End If
            '-------------------------------------------------------------
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "FRM CANCELAR PCE Y CA"
    '******INICIO*********************************************************
    Shared Function FnInicioPCE() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_inicioPCE", CommandType.StoredProcedure)
            'db.AsignarParametro("vi_idagencias", vi_idAgencia, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("vi_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_agencia", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor) '2

            'db.AsignarParametro("co_t_tipo_comprobante", OracleClient.OracleType.Cursor) '3
            'db.AsignarParametro("co_t_Tipo_Entrega", OracleClient.OracleType.Cursor) '4     
            'db.AsignarParametro("co_Tipo_Pago", OracleClient.OracleType.Cursor) '5
            'db.AsignarParametro("co_T_TARJETAS", OracleClient.OracleType.Cursor) '6
            'db.AsignarParametro("co_Listado_Producto", OracleClient.OracleType.Cursor) '7
            'db.AsignarParametro("co_factor_m3_kg", OracleClient.OracleType.Cursor) '8
            'db.AsignarParametro("co_control_version", OracleClient.OracleType.Cursor) '9
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor) '10
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '11
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            '--------Propagando el error----------------------------------
            If ds.Tables(4).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(4).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(4).Rows(0).Item(1))
                End If
            End If
            '-------------------------------------------------------------
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        End Try
    End Function

    '******LISTAR X FECHAS,AGENCIAS,USUARIO, ESTADO***********************
    Function Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal origen As Integer, _
                    ByVal destino As Integer, ByVal agencia As Integer, ByVal usuario As Integer, ByVal estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_listarPCE", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha1", fecha1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha2", fecha2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_guia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    '******LISTAR X NRO NRO DOCUMENTO*************************************
    Function Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal documento As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_listarPCE", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha1", fecha1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha2", fecha2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_documento", documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_guia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    '******LISTAR X NRO GUIA**********************************************
    Function Listar(ByVal guia As Long) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_listarPCE", CommandType.StoredProcedure)
            db.AsignarParametro("ni_guia", guia, OracleClient.OracleType.Number)
            db.AsignarParametro("co_guia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    '******LISTAR EL CLIENTE SELECCIONADO FRM BUSCAR CLIENTE**************
    Function Listar(ByVal i_Control As Integer, ByVal NroDoc As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_listarPCE", CommandType.StoredProcedure)
            db.AsignarParametro("n_control", i_Control, OracleClient.OracleType.Int32)
            db.AsignarParametro("nrodoc", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_guia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

#End Region

#Region "FRM BUSCAR CLIENTE/CONSIGNADO "

    '-----BUSQUEDA X CONSIGNADO----
    Public Function fnBuscarConsignado(ByVal Control As Integer, ByVal fecha_inicio As String, ByVal fecha_final As String, ByVal RAZON_SOCIAL As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.Sp_Filtro_Consignado", CommandType.StoredProcedure)
            db.AsignarParametro("vi_Control", Control, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_final", fecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nombres", RAZON_SOCIAL, OracleClient.OracleType.VarChar)
            db.Desconectar()
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    '------BUSQUEDA X CLIENTE----
    Public Function fnBuscarCliente(ByVal Control As Integer, ByVal iControl As Integer, ByVal fecha_inicio As String, ByVal fecha_final As String, ByVal RUCDNI As String, _
                                     ByVal RAZON_SOCIAL As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.Sp_Filtro_Cliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_Control", Control, OracleClient.OracleType.Int32)
            db.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int16)
            db.AsignarParametro("vi_fecha_inicio", fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_final", fecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ruc_Dni", RUCDNI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Razon_Social", RAZON_SOCIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("Co_Datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region "FRM CONSULTA GENERAL"
    Shared Function fnCargarProducto() As DataTable
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_GUIA_ENVIO_2.sp_Producto", CommandType.StoredProcedure)
            db_bd.AsignarParametro("Co_Productos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region


End Class
