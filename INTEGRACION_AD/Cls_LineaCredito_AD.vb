Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_LineaCredito_AD
    Function ListarCondicionCredito() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_condicion_credito", CommandType.StoredProcedure)
            db.AsignarParametro("co_condicion", OracleClient.OracleType.Cursor)
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

    Function ListarContacto(cliente As Integer, lista As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_contacto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_lista", lista, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
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

    Function ListarLineaCredito(cliente As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_linea_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_credito", OracleClient.OracleType.Cursor)
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

    Shared Function LineaCredito(cliente As Integer) As Integer
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sf_get_linea_credito (" & cliente & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarSolicitud(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_responsable", responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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

    Sub GrabarSolicitud(obj As Cls_LineaCredito_EN, solicitud As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_solicitud_linea_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", obj.Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_direccion", obj.Direccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_contacto_comercial", obj.ContactoComercial, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_contacto_pago", obj.ContactoPagos, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_monto_solicitado", obj.MontoSolicitado, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_condicion_cobranza", obj.CondicionCobranza, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_dia_pago", obj.DiaPago, OracleClient.OracleType.VarChar)

            db.AsignarParametro("vi_fecha1", obj.Fecha1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha2", obj.Fecha2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha3", obj.Fecha3, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha4", obj.Fecha4, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_dia1", obj.Dia1, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia2", obj.Dia2, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia3", obj.Dia3, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia4", obj.Dia4, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia5", obj.Dia5, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia6", obj.Dia6, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia7", obj.Dia7, OracleClient.OracleType.Int16)

            db.AsignarParametro("vi_horario_pago_ini", obj.HorarioPagoInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_horario_pago_fin", obj.HorarioPagoFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_pago", obj.TipoPago, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_producto", obj.Producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_facturacion", obj.TipoFacturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_producto", obj.SolicitudProducto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_tipo_facturacion", obj.SolicitudTipoFacturacion, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_contado", obj.Contado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_contacto_facturacion", obj.Contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_orden_compra", obj.OrdenCompra, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_liquidacion_documento", obj.LiquidacionDocumento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_concepto_credito", obj.ConceptoCredito, OracleClient.OracleType.Int32)

            'hlamas 08-04-2016
            db.AsignarParametro("ni_forma_pago", obj.FormaPago, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_corte", obj.FechaCorte, OracleClient.OracleType.VarChar)

            db.AsignarParametro("vi_fecha1_facturacion", obj.Fecha1Facturacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha2_facturacion", obj.Fecha2Facturacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha3_facturacion", obj.Fecha3Facturacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha4_facturacion", obj.Fecha4Facturacion, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_dia1_facturacion", obj.Dia1Facturacion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia2_facturacion", obj.Dia2Facturacion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia3_facturacion", obj.Dia3Facturacion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia4_facturacion", obj.Dia4Facturacion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia5_facturacion", obj.Dia5Facturacion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia6_facturacion", obj.Dia6Facturacion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia7_facturacion", obj.Dia7Facturacion, OracleClient.OracleType.Int16)

            db.AsignarParametro("vi_horario_facturacion_ini", obj.HorarioFacturacionInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_horario_facturacion_fin", obj.HorarioFacturacionFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_periodo_facturacion", obj.PeriodoFacturacion, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
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
    Sub AnularSolicitud(obj As Cls_LineaCredito_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_anular_solicitud_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
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

    Function ExisteSolicitud(obj As Cls_LineaCredito_EN) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sf_get_existe_solicitud_credit (" & obj.Cliente & "," & obj.Estado & ") "
            strCadena &= "from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Dim intestado As Integer = db.EjecutarEscalar()
            If intestado = 0 Then
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

    Function ListarSolicitud(obj As Cls_LineaCredito_EN, Optional fecha1 As String = "", Optional fecha2 As String = "") As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha1", fecha1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha2", fecha2, OracleClient.OracleType.VarChar)
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

    Sub Preaprobar(solicitud As Integer, estado As Integer, monto As Double, usuario As Integer, ip As String, Optional observacion As String = "")
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_preaprobar_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
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

    Sub Aprobar(solicitud As Integer, cliente As Integer, numero_documento As String, estado As Integer, _
                monto As Double, sobregiro As Double, total As Double, porcentaje_sobregiro As Double, _
                usuario As Integer, ip As String, Optional observacion As String = "")
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_aprobar_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_numero_documento", numero_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_sobregiro", sobregiro, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_porcentaje_sobregiro", porcentaje_sobregiro, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
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

    Function EstadoActual(cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_linea_credito_estado_actual", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
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

    Function ListarClienteCredito() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente_credito", CommandType.StoredProcedure)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
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

    Sub ActivarDesactivar(id As Integer, cliente As Integer, estado As Integer, usuario As Integer, ip As String, Optional monto As Double = 0)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_ActivaDesactiva_Credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
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

    Sub AnularSolicitudCondicionCredito(obj As Cls_LineaCredito_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_anular_solicitud_condicion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
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

    Function ListarSolicitudCondicionCredito(estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud_condicion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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


    Function ListarSolicitudCondicionCredito(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud_condicion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_responsable", responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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

    Function ExisteSolicitudCondicionCredito(obj As Cls_LineaCredito_EN) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sf_get_existe_sol_condicion (" & obj.Cliente & "," & obj.Estado & ") "
            strCadena &= "from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Dim intestado As Integer = db.EjecutarEscalar()
            If intestado = 0 Then
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

    Public Sub GrabarSolicitudCondicionCredito(obj As Cls_LineaCredito_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_solicitud_cliente_condicion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero_solicitud", obj.NumeroSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_condicion", obj.CondicionCobranza, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha", obj.Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
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

    Sub AprobarSolicitudCondicionCredito(obj As Cls_LineaCredito_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_aprobar_solicitud_condicion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_condicion", obj.CondicionCobranza, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", obj.Fecha, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
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

    Sub DesaprobarSolicitudCondicionCredito(obj As Cls_LineaCredito_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_desaprobar_sol_condicion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", obj.Observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
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

    Function ListarLineaCreditoUltima(cliente As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_linea_credito_ult", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_credito", OracleClient.OracleType.Cursor)
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

    Function ListarConceptoCredito() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_concepto_credito", CommandType.StoredProcedure)
            db.AsignarParametro("co_concepto", OracleClient.OracleType.Cursor)
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
End Class
