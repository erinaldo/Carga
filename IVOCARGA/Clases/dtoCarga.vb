Imports AccesoDatos

Public Class dtoCarga
    Shared Function SalidaCarga(inicio As String, fin As String, bus As Integer, servicio As Integer, origen As Integer, destino As Integer, opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Dim str As String = IIf(opcion = 2, "sp_salida_rep_2", "sp_salida_rep")
        Try
            db.Conectar()
            db.CrearComando(str, CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha_ini", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_bus", bus, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_servicio", servicio, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_salida", OracleClient.OracleType.Cursor)
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

    Shared Function TotalKm(Optional completo As Integer = 0) As Double
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("select sf_get_total_km('',0,0,0,0," & completo & ") from dual", CommandType.Text)
            Dim i As Double = db.EjecutarEscalar
            Return i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Function Inicio() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_inicio_nivel_servicio", CommandType.StoredProcedure)
            db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(4).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(4).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(4).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ObtieneCliente(documento As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_obtiene_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_numero_documento", documento, OracleClient.OracleType.VarChar)
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

    Function ActualizarNivelServicio(ByVal proceso1 As Integer, ByVal proceso2 As Integer, ByVal producto As Integer, ByVal origen As Integer, ByVal destino As Integer, _
                                     ByVal agencia_origen As Integer, ByVal agencia_destino As Integer, _
                                     ByVal fecha As String, ByVal cliente As Integer, ByVal fecha2 As String, ByVal funcionario As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal TipoEntrega As Integer, ByVal todo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_listar_nivel_servicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_proceso1", proceso1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proceso2", proceso2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_fin", fecha2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_origen", agencia_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_destino", agencia_destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_entrega", TipoEntrega, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_todo", todo, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_servicio", OracleClient.OracleType.Cursor)
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

    Function ListarNivelServicioDetalle(ByVal fecha As String, ByVal usuario As Integer, ByVal ip As String, ByVal TotalEnvios As Integer, ByVal todo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_listar_nivel_servicio_det", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_total_envios", TotalEnvios, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_todo", todo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_servicio", OracleClient.OracleType.Cursor)
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

    Function ListarAgencias(ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_listar_agencias", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_agencia", OracleClient.OracleType.Cursor)
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

    Function ListarInconsistencia(estado As Integer, usuario As Integer, ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_lista_nivel_servicio_inc", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_servicio", OracleClient.OracleType.Cursor)
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

    Sub LimpiarNivelServicio(usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_limpiar_nivel_servicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function prueba2(inicio As String, fin As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("sp_pivot_dinamico", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", Inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function prueba(estado As Integer, origen As Integer, destino As Integer, producto As Integer, inicio As String, fin As String, _
                    funcionario As Integer, segmento As Integer, cliente As Integer, entrega As Integer, _
                    Optional agencia_origen As Integer = 0, Optional agencia_destino As Integer = 0) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_listar_prueba", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_segmento", segmento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_entrega", entrega, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_origen", agencia_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_destino", agencia_destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_lista_detalle", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(2).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function InicioOperacion() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_inicio", CommandType.StoredProcedure)
            db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_segmento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(5).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(5).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(5).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarOperacionTercero(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA.sp_listar_operacion_tercero", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
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
End Class