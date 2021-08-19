Imports AccesoDatos
Public Class dtoFueraZona
    Function ListarCliente()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
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

    Function ListarFactura(oficina As Integer, inicio As String, fin As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("ni_oficina", oficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
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

    Function ListarFactura(inicio As String, fin As String, ruc As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
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

    Function ListarFactura(id As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_factura_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
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

    Function ListarFueraZonaAprobados(oficina As Integer, inicio As String, fin As String, estado As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_fz_aprobados", CommandType.StoredProcedure)
            db.AsignarParametro("ni_oficina", oficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
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

    Function ListarGuiaEnvio(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_zona_ge", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
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

    Function ListarGuiaEnvio(cliente As Integer, agencia_destino As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_guia_envio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_destino", agencia_destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_guia", OracleClient.OracleType.Cursor)
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

    Function ListarComprobante(cliente As Integer, agencia_destino As Integer, tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_destino", agencia_destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_comprobante", OracleClient.OracleType.Cursor)
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

    Shared Function ExisteSolicitud(cliente As Integer, estado As Integer) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sf_get_existe_solicitud_fz (" & cliente & "," & estado & ") "
            strCadena &= "from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Dim intEstado As Integer = db.EjecutarEscalar()
            If intEstado = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarSolicitud(ByVal estado As String, ByVal agencia As Integer, ByVal funcionario As Integer, ByVal nivel As Integer, _
                             ByVal inicio As String, ByVal fin As String, ByVal ciudad As Integer, Optional ByVal opcion As Integer = 0, _
                             Optional ByVal comprobante As String = "") As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("vi_estado", estado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_nivel", nivel, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_comprobante", comprobante, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_solicitud", OracleClient.OracleType.Cursor)
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

    Shared Function ObtieneNumeroSolicitud(agencia As Integer) As Integer
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_GUIA_ENVIO.sf_get_Numero_Solicitud (" & agencia & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub AceptarSolicitud(id As Integer, estado As Integer, usuario As Integer, ip As String, _
                         Optional precio As Double = 0, Optional observacion As String = "", Optional contacto As Integer = 0)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_aceptar_solicitud_fz", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_precio", precio, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_contacto", contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub AprobarSolicitud(id As Integer, estado As Integer, usuario As Integer, ip As String, _
                        Optional precio As Double = 0, Optional observacion As String = "")
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_aprobar_fuera_zona", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_precio", precio, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub AnularSolicitud(id As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_anular_solicitud_fz", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function GrabarSolicitud(id As Integer, NumeroSolicitud As Integer, cliente As Integer, observacion As String, costo As Double, _
                             ciudad As Integer, agencia As Integer, km As Double, hora As String, localidad As String, _
                             proveedor As Integer, ruc As String, razon_social As String, _
                             fecha As String, usuario As Integer, ip As String, agencia_gasto As Integer) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_grabar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero_solicitud", NumeroSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_costo", costo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_km", km, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_hora", hora, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_localidad", localidad, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia_gasto", agencia_gasto, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0).Rows(0).Item("id").ToString

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Sub GrabarGuiaEnvio(ByVal id As Integer, ByVal idfz As Integer, ByVal fecha As String, ByVal tipo As Integer, ByVal ge As Integer, ByVal estado As Integer, ByVal origen As String, ByVal destino As String, ByVal total_costo As Double, ByVal guia As String, _
                           ByVal agencia_origen As Integer, ByVal agencia_destino As Integer, ByVal cantidad As Integer, ByVal peso As Double, ByVal direccion As String, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_grabar_fz_ge", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_fz", idfz, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ge", ge, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_origen", origen, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_destino", destino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_total_costo", total_costo, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_guia", guia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idagencias", agencia_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idagencias_destino", agencia_destino, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_direccion", direccion, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function GrabarFactura(fecha As String, serie As String, numero As String, ruc As String, razon_social As String, agencia As Integer, _
                           subtotal As Double, impuesto As Double, total As Double, _
                           id As Integer, solicitud As Integer, _
                           usuario As Integer, ip As String) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_grabar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_subtotal", subtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_factura", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0).Rows(0).Item("id").ToString

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarProveedor(inicio As String, fin As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_proveedor", CommandType.StoredProcedure)
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

    Function ListarFueraZonaAprobados(inicio As String, fin As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_fz_aprobados", CommandType.StoredProcedure)
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

    Function ComprobanteDisponible(tipo As Integer, comprobante As Integer) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_GUIA_ENVIO.sf_get_disponible_fz (" & tipo & "," & comprobante & ") "
            strCadena &= "from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Dim intEstado As Integer = db.EjecutarEscalar()
            If intEstado = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarComprobanteEmbalaje(ByVal cliente As Integer, ByVal agencia_destino As Integer, ByVal tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_comprobante_embalaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_destino", agencia_destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_comprobante", OracleClient.OracleType.Cursor)
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

    Function ListarSolicitudEmbalaje(ByVal estado As String, ByVal agencia As Integer, ByVal funcionario As Integer, ByVal nivel As Integer, _
                             ByVal inicio As String, ByVal fin As String, ByVal ciudad As Integer, Optional ByVal opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_solicitud_embalaje", CommandType.StoredProcedure)
            db.AsignarParametro("vi_estado", estado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_nivel", nivel, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_solicitud", OracleClient.OracleType.Cursor)
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

    Function GrabarSolicitudEmbalaje(ByVal id As Integer, ByVal NumeroSolicitud As Integer, ByVal cliente As Integer, ByVal observacion As String, ByVal costo As Double, _
                             ByVal ciudad As Integer, ByVal agencia As Integer, _
                             ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                             ByVal fecha As String, ByVal usuario As Integer, ByVal ip As String, ByVal agencia_gasto As Integer) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_grabar_solicitud_embalaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero_solicitud", NumeroSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_costo", costo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia_gasto", agencia_gasto, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0).Rows(0).Item("id").ToString

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Sub GrabarGuiaEnvioEmbalaje(ByVal id As Integer, ByVal idfz As Integer, ByVal fecha As String, ByVal tipo As Integer, ByVal ge As Integer, ByVal estado As Integer, ByVal origen As String, ByVal destino As String, ByVal total_costo As Double, ByVal guia As String, _
                           ByVal agencia_origen As Integer, ByVal agencia_destino As Integer, ByVal cantidad As Integer, ByVal peso As Double, ByVal direccion As String, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_grabar_embalaje_ge", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_fz", idfz, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ge", ge, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_origen", origen, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_destino", destino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_total_costo", total_costo, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_guia", guia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idagencias", agencia_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idagencias_destino", agencia_destino, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_direccion", direccion, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub AceptarSolicitudEmbalaje(ByVal id As Integer, ByVal estado As Integer, ByVal usuario As Integer, ByVal ip As String, _
                         Optional ByVal precio As Double = 0, Optional ByVal observacion As String = "")
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_aceptar_solicitud_embalaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_precio", precio, OracleClient.OracleType.Number)

            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub AprobarSolicitudEmbalaje(ByVal id As Integer, ByVal estado As Integer, ByVal usuario As Integer, ByVal ip As String, _
                    Optional ByVal precio As Double = 0, Optional ByVal observacion As String = "")
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_aprobar_embalaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_precio", precio, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ListarGuiaEnvioEmbalaje(ByVal id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_listar_embalaje_ge", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
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

    Shared Function ObtieneNumeroSolicitudEmbalaje(ByVal agencia As Integer) As Integer
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_GUIA_ENVIO.sf_get_numero_embalaje (" & agencia & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub AnularSolicitudEmbalaje(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO.sp_anular_solicitud_embalaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

End Class

