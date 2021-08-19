Imports AccesoDatos
Public Class dtoGuia
    Shared Function Inicio() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_inicio", CommandType.StoredProcedure)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(3).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(3).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(3).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarUsuario(ByVal agencia As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_usuario", CommandType.StoredProcedure)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_usuario", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal origen As Integer, _
                    ByVal destino As Integer, ByVal agencia As Integer, ByVal usuario As Integer, ByVal estado As Integer, _
                    Optional ByVal recojo As Integer = 0, Optional ByVal canjeado As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha1", fecha1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha2", fecha2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_recojo", recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_canjeado", canjeado, OracleClient.OracleType.Int32)
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

    Function Listar(ByVal guia As Long) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar", CommandType.StoredProcedure)
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

    Function Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal documento As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar", CommandType.StoredProcedure)
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

    Sub Devolver(ByVal comprobante As Integer, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String, ByVal porcentaje As Double, ByVal opcion As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_devolver", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_porcentaje", porcentaje, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_acceso", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Eliminar(ByVal comprobante As Integer, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_eliminar", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function ValidarAnulacion(comprobante As Integer, usuario As Integer, acceso As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_validar_anulacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_acceso", acceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    If ds.Tables(1).Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                    End If
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub AnularComprobante(ByVal comprobante As Integer, ByVal motivo As String, ByVal usuario As Integer, _
       ByVal rol As Integer, ByVal ip As String, Optional ByVal autoriza As Integer = 0)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_anular_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_motivo", motivo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", dtoUSUARIOS.iIDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_autoriza", autoriza, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Anular(ByVal comprobante As Integer, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String, ByVal acceso As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_anular", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_acceso", acceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Anular(ByVal estado As Integer, ByVal comprobante As Integer, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String, ByVal acceso As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_anular_guia_envio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado_registro", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_acceso", acceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CreditoContado(ByVal guia As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_credito_pce", CommandType.StoredProcedure)
            db.AsignarParametro("ni_guia", guia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function InicioGuia(ByVal vi_idusaurio_pesonal As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_Inicio_Guia", CommandType.StoredProcedure)
            'db.AsignarParametro("vi_idusaurio_pesonal", vi_idusaurio_pesonal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_Listado_Tipo", OracleClient.OracleType.Cursor)
            ''db.AsignarParametro("co_Listado_Producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Listado_Agencias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_t_Tipo_Entrega", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_SeleccionImpresion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_configuracion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            '--------Propagando el error----------------------------------
            If ds.Tables(5).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(5).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(5).Rows(0).Item(1))
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

    Function Buscar(ByVal item As String, ByVal opcion As Integer, ByVal origen As Integer, ByVal destino As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_Buscar", CommandType.StoredProcedure)
            db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_lineaCredito", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Descuento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_remitente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub Devolver(ByVal comprobante As Integer, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String, ByVal porcentaje As Double)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_devolver", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_porcentaje", porcentaje, OracleClient.OracleType.Number)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function ClienteSubcuenta(cliente As Integer, subcuenta1 As Integer, subcuenta2 As Integer) As Integer
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_GUIA_ENVIO_2.sf_get_cliente_subcuenta(" & cliente & "," & subcuenta1 & "," & subcuenta2 & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag

    End Function

    Shared Function MinimoPce(origen As Integer, destino As Integer, cliente As Integer) As Integer
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_GUIA_ENVIO_2.sf_get_minimo_pce(" & origen & "," & destino & "," & cliente & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Sub ActualizarFueraZona(ByVal id As Integer, ByVal monto As Double, ByVal impuesto As Double, ByVal total As Double, _
                                        ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_actualizar_fz", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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
    End Sub

    Public Sub ActualizarSeguro(ByVal id As Integer, ByVal monto As Double, ByVal impuesto As Double, ByVal total As Double, _
                                    ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_actualizar_seguro", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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
    End Sub

End Class
