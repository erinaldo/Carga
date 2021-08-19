Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_Gasto_AD
    Function ListarPeriodo(tipo As Integer, año As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_periodo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_anio", año, OracleClient.OracleType.Int32)
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

    Function ListarCiudad(Optional opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_ciudad", CommandType.StoredProcedure)
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

    Function ListarCiudadTipoPago() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_tipo_pago_ciudad", CommandType.StoredProcedure)
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

    Function ListarAgencia() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_agencia", CommandType.StoredProcedure)
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
            db.CrearComando("PKG_IVOGASTO.sp_listar_agencia", CommandType.StoredProcedure)
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

    Function CalcularGasto(ciudad As Integer, fecha_inicio As String, fecha_fin As String, opcion As Integer, usuario As Integer, ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_calcular_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", -1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_centro_costo", 0, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Sub GrabarGasto(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", obj.FechaFin, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_proveedor", obj.Proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", obj.Ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", obj.RazonSocial, OracleClient.OracleType.VarChar)

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

    Sub GrabarTarifa(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_tarifa", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", obj.TipoTarifa, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_tipo_pago", obj.TipoGasto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", obj.Monto, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fecha", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_bono", obj.Bono, OracleClient.OracleType.Int32)

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

    Sub GrabarCiudadTipoPago(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_ciudad_tipo_pago", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_pago", obj.TipoGasto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_activacion", obj.FechaInicio, OracleClient.OracleType.VarChar)

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

    Function ListarTarifa(obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_tarifa", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", obj.TipoTarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_pago", obj.TipoGasto, OracleClient.OracleType.Int32)
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

    Function ListarGasto(obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", obj.FechaFin, OracleClient.OracleType.VarChar)
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

    Function ListarGasto(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_gasto", CommandType.StoredProcedure)
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
    Sub AnularGasto(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", obj.FechaFin, OracleClient.OracleType.VarChar)
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

    Sub AnularCiudadTipoPago(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_ciudad_tipo_pago", CommandType.StoredProcedure)
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

    Function ObtieneNumeroSolicitud() As Integer
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGASTO.sf_get_Numero_Solicitud from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarHojaRuta(ByVal obj As Cls_Gasto_EN, ByVal opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try '5360 16-03-2017 3 0 0 15939 192.168.50.47
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_hoja_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", obj.TipoGasto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable", obj.Responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_reparto", obj.Reparto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
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

    Function ListarReparto(obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_reparto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_mixto", obj.Mixto, OracleClient.OracleType.Int32)
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

    Function ObtieneTarifaGasto(ciudad As Integer, tipo As Integer) As Double
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGASTO.sf_get_Tarifa_Gasto(" & ciudad & "," & tipo & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function GrabarSolicitud(obj As Cls_Gasto_EN) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", obj.Agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_solicitud", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_operacion", obj.FechaOperacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_solicitante", obj.Solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tiempo1", obj.Tiempo1, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_tiempo2", obj.Tiempo2, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_monto_agencia", obj.MontoAgencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_monto", obj.Monto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_tipo_gasto", obj.TipoGasto, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_tipo_gasto_adicional", obj.TipoGastoAdicional, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable_adicional", obj.ResponsableAdicional, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_reparto", obj.Reparto, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", obj.Proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", obj.Ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", obj.RazonSocial, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_gasto_adicional", obj.GastoAdicional, OracleClient.OracleType.Int32)

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

    Function ListarSolicitud(obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_solicitud_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", obj.FechaFin, OracleClient.OracleType.VarChar)

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

    Function GrabarSolicitudDetalle(obj As Cls_Gasto_EN) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_gasto", obj.ID2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable", obj.Responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tiempo1", obj.Tiempo1, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_tiempo2", obj.Tiempo2, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_peso", obj.Peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", obj.Cantidad, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fecha_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_fin", obj.FechaFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tiempo", obj.Tiempo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_entrega", obj.Entrega, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If

            'Return ds

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub AnularSolicitud(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_solicitud", obj.ID, OracleClient.OracleType.Int32)
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

    Sub AnularTarifa(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_tarifa", CommandType.StoredProcedure)
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

    Function ListarTipoGasto(obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_tipo_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            'db.AsignarParametro("vi_fecha", obj.FechaInicio, OracleClient.OracleType.VarChar)
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

    Sub AprobarSolicitud(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_aprobar_solicitud_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)

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

    Function InicioResumen() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_inicio_resumen", CommandType.StoredProcedure)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_concepto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_centro_costo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo_entrega", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(5).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(5).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(5).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarResumen(obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_resumen", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_concepto", obj.Concepto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_centro_costo", obj.CentroCosto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", obj.Producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_fin", obj.FechaFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

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

    Sub AprobarTipoGasto(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_aprobar_tipo_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", obj.Agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable", obj.Responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_gasto", obj.TipoGasto, OracleClient.OracleType.Int32)

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

    Function ListarTipoGasto(tipo_gasto As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_tipo_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo_gasto", tipo_gasto, OracleClient.OracleType.Int32)
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

    Function ListarTipoPago(opcion As Integer, Optional tipo As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_tipo_pago", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
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

    Function ListarResponsable(obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_responsable", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)

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

    Function ListarReparto(ciudad As Integer, fecha As String, responsable As Integer, reparto As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_reparto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_responsable", responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_reparto", reparto, OracleClient.OracleType.Int32)

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

    Function ListarHojaRuta(ciudad As Integer, fecha As String, responsable As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_hoja_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_responsable", responsable, OracleClient.OracleType.Int32)

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

    Function GrabarSolicitudTipoGasto(obj As Cls_Gasto_EN) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable", obj.Responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_solicitud", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_operacion", obj.FechaOperacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_solicitante", obj.Solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_gasto", obj.TipoGasto, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function TipoGasto(ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_tipo_gasto", CommandType.StoredProcedure)
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

    Function ListarSolicitudTipoGasto(estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_solicitud_tipo_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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


    Function ListarSolicitudTipoGasto(ciudad As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_solicitud_tipo_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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

    Sub AnularSolicitudTipoGasto(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_solicitud_tipo_gasto", CommandType.StoredProcedure)
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

    Sub AprobarSolicitudTipoGasto(obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_aprobar_sol_tipo_gasto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)

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

    Function ListarProveedor(ruc As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_proveedor", CommandType.StoredProcedure)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)

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

    Function ListarFactura(inicio As String, fin As String, ruc As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)

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

    Function ListarFactura(ByVal ciudad As Integer, ByVal inicio As String, ByVal fin As String, ByVal rol As Integer, ByVal rol2 As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol2", rol2, OracleClient.OracleType.Int32)

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

    Function ListarFactura(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_factura_detalle", CommandType.StoredProcedure)
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

    Function ListarGastoAprobado(ByVal obj As Cls_Gasto_EN, ByVal rol As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_gasto_aprobado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", obj.FechaFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_concepto", obj.Concepto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", obj.Proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)

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

    Function GrabarFactura(ByVal fecha As String, ByVal serie As String, ByVal numero As String, ByVal ruc As String, ByVal razon_social As String, _
                           ByVal ciudad As Integer, ByVal agencia As Integer, ByVal concepto As String,
                           ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double, _
                           ByVal id As Integer, ByVal solicitud As Integer, _
                           ByVal usuario As Integer, ByVal ip As String, ByVal TipoAfectacion As Integer) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_concepto", concepto, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_subtotal", subtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_tipo_afectacion", TipoAfectacion, OracleClient.OracleType.Int32)

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

    Function ObtieneTipoPago(ciudad As Integer) As Integer
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGASTO.sf_get_tipo_pago(" & ciudad & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function LiquidarFactura(id As Integer, usuario As Integer, ip As String) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_liquidar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_numero", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0).Rows(0).Item("numero").ToString

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    '--------------------------------- Recojo -------------------------------------

    Function ListarSolicitudRecojo(ByVal ciudad As Integer, ByVal estado As Integer, ByVal inicio As String, ByVal fin As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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

    Function ListarRecojo(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_recojo", CommandType.StoredProcedure)
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

    Function ListarGrtRecojo(ByVal serie As Integer, ByVal numero As Integer, ByVal usuario As Integer, ByVal ip As String, Optional ByVal opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_grt_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_serie", serie, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero", numero, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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


    Function ListarRecojoDetalle(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal formato As Integer, ByVal mixto As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_recojo_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_formato", formato, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_mixto", mixto, OracleClient.OracleType.Int32)

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

    Function ListarRecojoDetalle(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_recojo_detalle", CommandType.StoredProcedure)
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

    Function ListarDisponible(serie As String, numero As String, tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_disponible", CommandType.StoredProcedure)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
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

    Function ListarDisponibleEstiba(ByVal serie As String, ByVal numero As String, ByVal tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_disponible_estiba", CommandType.StoredProcedure)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
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

    Sub AnularSolicitudRecojo(id As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Sub AprobarSolicitudRecojo(id As Integer, observacion As String, estado As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_aprobar_solicitud_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Function GrabarSolicitudRecojo(ByVal id As Integer, ByVal id_2 As Integer, ByVal ciudad As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer, _
                              ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, _
                              ByVal tipo As Integer, ByVal comprobante As Integer, ByVal fecha As String, ByVal origen As Integer, ByVal destino As Integer, ByVal cliente As Integer, _
                              ByVal peso As Double, ByVal cantidad As Integer, ByVal producto As Integer, ByVal estado As Integer, ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                              ByVal usuario As Integer, ByVal ip As String, ByVal tipo_gasto As Integer, ByVal monto_tarifa As Double) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_2", id_2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_operacion", fecha_operacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_solicitante", solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_tipo_gasto", tipo_gasto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto_tarifa", monto_tarifa, OracleClient.OracleType.Number)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
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

    Function GrabarSolicitudRecojo(ByVal id As Integer, ByVal ciudad As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer,
                                   ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                                   ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, ByVal peso As Double, ByVal cantidad As Integer, _
                                   ByVal grt As Integer, ByVal estado As Integer, _
                                   ByVal usuario As Integer, ByVal ip As String, ByVal tipo_gasto As Integer, ByVal monto_tarifa As Double) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_operacion", fecha_operacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_solicitante", solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_grt", grt, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_tipo_gasto", tipo_gasto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto_tarifa", monto_tarifa, OracleClient.OracleType.Number)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
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
    Function GrabarSolicitudEstiba(ByVal id As Integer, ByVal id_2 As Integer, ByVal ciudad As Integer, ByVal operacion As Integer, ByVal hora_inicio As String, _
                                   ByVal hora_fin As String, ByVal numero_estiba As Integer, _
                                   ByVal fecha_operacion As String, ByVal agencia As Integer, ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, _
                          ByVal tipo As Integer, ByVal comprobante As Integer, ByVal fecha As String, ByVal origen As Integer, ByVal destino As Integer, ByVal cliente As Integer, _
                          ByVal peso As Double, ByVal cantidad As Integer, ByVal producto As Integer, ByVal estado As Integer, ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                          ByVal usuario As Integer, ByVal ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_estiba", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_2", id_2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_hora_inicio", hora_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora_fin", hora_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_numero_estiba", numero_estiba, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_fecha_operacion", fecha_operacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_solicitante", solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
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

    '----------------------------------------------------- ESTIBA -----------------------------------------------------
    Sub AprobarSolicitudEstiba(id As Integer, observacion As String, estado As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_aprobar_solicitud_estiba", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Sub AnularSolicitudEstiba(id As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_estiba", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Sub LimpiarEstiba(usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_limpiar_estiba", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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


    Function ListarEstibaDetalle(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal formato As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_estiba_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_formato", formato, OracleClient.OracleType.Int32)

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

    Function ListarEstiba(ByVal ciudad As Integer, ByVal estado As Integer, ByVal inicio As String, ByVal fin As String, Optional ByVal comprobante As String = "") As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_estiba", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_comprobante", comprobante, OracleClient.OracleType.VarChar)

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

    Function ListarGrt(ByVal serie As Integer, ByVal numero As Integer, ByVal operacion As Integer, ByVal usuario As Integer, ByVal ip As String, Optional ByVal opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_grt", CommandType.StoredProcedure)
            db.AsignarParametro("ni_serie", serie, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero", numero, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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

    Function GrabarSolicitudEstiba(id As Integer, ciudad As Integer, operacion As Integer, fecha_operacion As String, agencia As Integer,
                                   proveedor As Integer, ruc As String, razon_social As String, _
                                   solicitante As Integer, observacion As String, monto As Double, peso As Double, cantidad As Integer, _
                                   numero_estiba As Integer, hora_inicio As String, hora_fin As String, grt As Integer, estado As Integer, _
                                   usuario As Integer, ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_estiba", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_operacion", fecha_operacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_solicitante", solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero_estiba", numero_estiba, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_hora_inicio", hora_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora_fin", hora_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_grt", grt, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
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


    Function ListarGastoProveedor(ciudad As Integer, inicio As String, fin As String, concepto As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_gasto_proveedor", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_concepto", concepto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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

    Function ListarProvision(inicio As String, fin As String, ciudad As Integer, concepto As Integer, usuario As Integer, ip As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_provision_2", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_concepto", concepto, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function EstadoProvision(inicio As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_estado_provision", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor)
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

    Function ConsultarProvision(ByVal inicio As String, ByVal ciudad As Integer, ByVal concepto As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_consultar_provision", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_concepto", concepto, OracleClient.OracleType.VarChar)
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

    Function CerrarProvision(ByVal id As Integer, ByVal fecha As String, ByVal fecha_cierre As String, ByVal ciudad As Integer, _
                             ByVal proveedor As Integer, ByVal factura As String, ByVal solicitud As Integer, _
                             ByVal concepto As String, ByVal monto As Double, _
                             ByVal usuario As Integer, ByVal ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_cerrar_provision", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_cierre", fecha_cierre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_factura", factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_concepto", concepto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_registro", OracleClient.OracleType.Cursor)
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

    Function InicioProvision() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_inicio_provision", CommandType.StoredProcedure)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_concepto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(2).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function


    '------------------------------------------------------- TRASLADO ----------------------------------------------------------------------

    Function ListarTraslado(ByVal ciudad As Integer, ByVal estado As Integer, ByVal inicio As String, ByVal fin As String, Optional ByVal comprobante As String = "") As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_traslado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_comprobante", comprobante, OracleClient.OracleType.VarChar)
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

    Function ListarGrtTraslado(serie As Integer, numero As Integer, usuario As Integer, ip As String, Optional opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_grt_traslado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_serie", serie, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero", numero, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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

    Function ListarTrasladoDetalle(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal formato As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_traslado_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_formato", formato, OracleClient.OracleType.Int32)

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

    Sub AprobarSolicitudTraslado(id As Integer, observacion As String, estado As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_aprobar_solicitud_traslado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Sub AnularSolicitudTraslado(id As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_traslado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Function GrabarSolicitudTraslado(id As Integer, ciudad As Integer, fecha_operacion As String, agencia As Integer,
                                   proveedor As Integer, ruc As String, razon_social As String, _
                                   solicitante As Integer, observacion As String, monto As Double, peso As Double, cantidad As Integer, _
                                   grt As Integer, estado As Integer, _
                                   usuario As Integer, ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_traslado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_operacion", fecha_operacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_solicitante", solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_grt", grt, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
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

    Function GrabarSolicitudTraslado(ByVal id As Integer, ByVal id_2 As Integer, ByVal ciudad As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer, _
                                   ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, _
                                   ByVal tipo As Integer, ByVal comprobante As Integer, ByVal fecha As String, ByVal origen As Integer, ByVal destino As Integer, ByVal cliente As Integer, _
                                   ByVal peso As Double, ByVal cantidad As Integer, ByVal producto As Integer, ByVal estado As Integer, _
                                   ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                                   ByVal usuario As Integer, ByVal ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_traslado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_2", id_2, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_operacion", fecha_operacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_solicitante", solicitante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
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

    '-------------------------------------------------PROVEEDOR---------------------------------------------------
    Function ObtieneProveedor(ByVal ciudad As Integer, ByVal operacion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_obtiene_proveedor", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
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

    Function InicioProveedor() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_inicio_proveedor", CommandType.StoredProcedure)
            db.AsignarParametro("co_operacion", OracleClient.OracleType.Cursor)
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

    Function ListarProveedorOperacion(ByVal ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_proveedor_operacion", CommandType.StoredProcedure)
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

    Sub GrabarProveedorOperacion(ByVal id As Integer, ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                                     ByVal ciudad As Integer, ByVal operacion As Integer, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_proveedor_operacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Function ListarGRT(ByVal id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_grt", CommandType.StoredProcedure)
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

    Function ListarDisponibleTraslado(ByVal serie As String, ByVal numero As String, ByVal tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_disponible_traslado", CommandType.StoredProcedure)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
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

    Function ListarSolicitudRepartoRecojo(ByVal obj As Cls_Gasto_EN) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_listar_solicitud_rep_rec", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", obj.Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", obj.FechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", obj.FechaFin, OracleClient.OracleType.VarChar)

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

    Sub GrabarSolicitudCabecera(ByVal id As Integer, ByVal reparto As Integer, ByVal recojo As Integer, ByVal ciudad As Integer, _
                                     ByVal FechaOperacion As String, ByVal monto As Double, ByVal observacion As String, ByVal proveedor As Integer, _
                                     ByVal TipoGasto As Integer, ByVal peso As Double, ByVal cantidad As Integer, _
                                     ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal MontoTarifa As Double)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_grabar_solicitud_cabecera", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_reparto", reparto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_recojo", recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_operacion", FechaOperacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_gasto", TipoGasto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_monto_tarifa", MontoTarifa, OracleClient.OracleType.Number)

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

    Sub AnularSolicitudCabecera(ByVal id As Integer, ByVal reparto As Integer, ByVal recojo As Integer, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_anular_solicitud_cabecera", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_reparto", reparto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_recojo", recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

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

    Function RecuperarReparto(ByVal id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_recuperar_reparto", CommandType.StoredProcedure)
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

    Sub AprobarSolicitudCabecera(ByVal obj As Cls_Gasto_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGASTO.sp_aprobar_solicitud_cabecera", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_reparto", obj.Rep, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_recojo", obj.Rec, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)

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

    Function ValidaRepartoRecojo(ByVal ciudad As Integer, ByVal fecha_operacion As String) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGASTO.sf_get_valida_reparto_recojo(" & ciudad & ",'" & fecha_operacion & "') from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return IIf(db.EjecutarEscalar = 0, False, True)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ExisteComprobanteRecojo(ByVal tipo As Integer, ByVal comprobante As Integer) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        'strCadena = "select PKG_IVOGASTO.sf_get_Tarifa_Gasto(" & ciudad & "," & tipo & ") from dual"
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGASTO.sf_get_comprobante_recojo(" & tipo & "," & comprobante & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return IIf(db.EjecutarEscalar() = 0, False, True)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

End Class
