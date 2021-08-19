Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_Contabilidad_AD
    Sub AnularTransferencia(ByVal id As Integer, ByVal origen As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_anular_transferencia", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.EjecutarEscalar()

            'Dim dt As DataTable = db.EjecutarDataTable
            'If dt.Rows.Count > 0 Then
            '    If Not IsDBNull(dt.Rows(0).Item(0)) Then
            '        Throw New Exception(dt.Rows(0).Item(1).ToString)
            '    End If
            'End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub AnularCuentaContable(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_anular_cuenta_contable", CommandType.StoredProcedure)
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

    Function ListarTipoComprobante(ByVal opcion As Integer, ByVal concepto As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_listar_tipo_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_concepto", concepto, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarLog(ByVal comprobante As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_listar_log", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function


    Function ListarVenta(ByVal inicio As String, ByVal fin As String, ByVal venta As Integer, ByVal transferido As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_listar_venta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_venta", venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_transferido", transferido, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarCuentaContable(ByVal venta As Integer, ByVal concepto As Integer, ByVal tipo_comprobante As Integer, ByVal tipo_afectacion As Integer, _
                                  ByVal moneda As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_listar_cuenta_contable", CommandType.StoredProcedure)
            db.AsignarParametro("ni_venta", venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_concepto", concepto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_comprobante", tipo_comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_afectacion", tipo_afectacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_moneda", moneda, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarSubtipo(ByVal concepto As Integer, ByVal tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_listar_subtipo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_concepto", concepto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function


    Sub GrabarCuentaContable(ByVal id As Integer, ByVal venta As Integer, ByVal concepto As Integer, ByVal tipo As Integer, ByVal subtipo As Integer, _
                             ByVal TipoAfectacion As Integer, ByVal moneda As Integer, ByVal CuentaCliente As String, ByVal CuentaImpuesto As String, _
                             ByVal CuentaVenta As String, ByVal CuentaCosto As String, ByVal actividad As String, ByVal MovimientoCliente As Integer, _
                             ByVal MovimientoImpuesto As Integer, ByVal MovimientoVenta As Integer, _
                             ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_MIGRACION_PYS.sp_grabar_cuenta_contable", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_venta", venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_concepto", concepto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_subtipo", subtipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_afectacion", TipoAfectacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_moneda", moneda, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_cuenta_cliente", CuentaCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_cuenta_impuesto", CuentaImpuesto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_cuenta_venta", CuentaVenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_cuenta_costo", CuentaCosto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_actividad", actividad, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_movimiento_cliente", MovimientoCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_movimiento_impuesto", MovimientoImpuesto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_movimiento_venta", MovimientoVenta, OracleClient.OracleType.Int32)

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
