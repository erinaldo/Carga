Imports AccesoDatos
Imports INTEGRACION_EN
Public Class Cls_Autorizacion_AD
    Function ListarCiudad() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_ciudad", CommandType.StoredProcedure)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarAgencia(ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarDireccion(ByVal cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try

    End Function

    Sub AnularSolicitud(obj As Cls_Autorizacion_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_anular_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ListarComprobante(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function BuscarComprobante(comprobante As String, tipo As Integer, Optional opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("vi_comprobante", comprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarSolicitud(ByVal ciudad As Integer, ByVal agencia As Integer, ByVal estado As Integer, ByVal opcion As Integer, ByVal rol As Integer, _
                             ByVal inicio As String, ByVal fin As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarOperacion(solicitud As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_operacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarDatos(id As Integer, operacion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_datos", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function GrabarSolicitud(obj As Cls_Autorizacion_EN) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_grabar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", obj.Tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", obj.Comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_total", obj.Total, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_solicitante", obj.Solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", obj.Agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_operacion", obj.TipoOperacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario_liquidacion", obj.UsuarioLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cuenta_corriente", obj.CuentaCorriente, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return CType(ds.Tables(0).Rows(0).Item(0), Integer)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function GrabarSolicitudDetalle(obj As Cls_Autorizacion_EN) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_grabar_solicitud_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_cab", obj.ID2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", obj.Operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", obj.Total, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return CType(ds.Tables(0).Rows(0).Item(0).ToString, Integer)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub GrabarDato(obj As Cls_Autorizacion_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_grabar_dato", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id_cab", obj.ID2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", obj.Operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_dato", obj.Dato, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", obj.Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub AprobarSolicitud(obj As Cls_Autorizacion_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_aprobar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", obj.Opcion, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_operacion", obj.Operacion, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ListarArticulo(id As Integer, cliente As Integer, origen As Integer, destino As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_articulo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarVenta(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_venta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarTarifa(producto As Integer, origen As Integer, destino As Integer, cliente As Integer, tipo_tarifa As Integer, _
                          tipo_visibilidad As Integer, tipo_entrega As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_tarifa", CommandType.StoredProcedure)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", tipo_tarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_visibilidad", tipo_visibilidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_entrega", tipo_entrega, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarFormaPago() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_tipo_pago", CommandType.StoredProcedure)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarUsuario(ciudad As Integer, agencia As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_listar_USUARIO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub ActualizarSolicitud(ByVal id As Integer, ByVal estado As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAutorizacion.sp_actualizar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_solicitud", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class
