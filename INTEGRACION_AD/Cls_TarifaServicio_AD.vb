Imports AccesoDatos
Imports INTEGRACION_EN
Public Class Cls_TarifaServicio_AD
    Public Function ListarUnidad() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOTARIFA_SERVICIO.sp_unidad_carga_sel", CommandType.StoredProcedure)
            db.AsignarParametro("co_unidad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
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

    Public Function ListarTarifaServicio(origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOTARIFA_SERVICIO.sp_tarifa_servicio_sel", CommandType.StoredProcedure)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", tipo_tarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_visibilidad", tipo_visibilidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_servicio", servicio, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_tarifa", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
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


    Public Function Grabar(ByVal Tarifa As Cls_TarifaServicio_EN) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOTARIFA_SERVICIO.sp_grabar_tarifa_servicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", Tarifa.Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idtarifa_servicio", Tarifa.IDTarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", Tarifa.Origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", Tarifa.Destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", Tarifa.Producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", Tarifa.TipoTarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_visibilidad", Tarifa.TipoVisibilidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_servicio", Tarifa.Servicio, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_unidad", Tarifa.Unidad, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_inicio", Tarifa.Inicio, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_fin", Tarifa.Fin, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_monto", Tarifa.Monto, OracleClient.OracleType.Number)
            db.AsignarParametro("di_fecha_activacion", Tarifa.FechaActivacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", Tarifa.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", Tarifa.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If

            Return Convert.ToInt32(IIf(IsDBNull(ds.Tables(0).Rows(0).Item(0)), 0, ds.Tables(0).Rows(0).Item(0)))
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarTarifaServicio(tarifa As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOTARIFA_SERVICIO.sp_tarifa_servicio_sel", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tarifa", tarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_tarifa_cab", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tarifa", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(2).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ExisteTarifaServicio(tarifa As Cls_TarifaServicio_EN) As Boolean
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim sql As String
            sql = "select PKG_IVOTARIFA_SERVICIO.sf_get_existe_tarifa_servicio (" & tarifa.Origen & "," & tarifa.Destino & "," & tarifa.Producto & ","
            sql = sql & "" & tarifa.TipoTarifa & "," & tarifa.TipoVisibilidad & "," & tarifa.Servicio & ") "
            sql = sql & "from dual"
            db.CrearComando(sql, CommandType.Text)
            Dim blnExiste As Boolean = IIf(db.EjecutarEscalar = 0, False, True)

            Return blnExiste
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub Anular(tarifa As Cls_TarifaServicio_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOTARIFA_SERVICIO.sp_anular_tarifa_servicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tarifa", tarifa.IDTarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", tarifa.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", tarifa.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim dt As DataTable
            dt = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString())
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ObtenerTarifaServicio(ByVal origen As Integer, ByVal destino As Integer, ByVal producto As Integer, ByVal tipo_tarifa As Integer, ByVal tipo_visibilidad As Integer, ByVal servicio As Integer, ByVal cliente As Integer, ByVal proceso As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOTARIFA_SERVICIO.sf_get_tarifa_servicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", tipo_tarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_visibilidad", tipo_visibilidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_servicio", servicio, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proceso", proceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_tarifa", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
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

    Function ObtenerMontoVenta(tipo As Integer, comprobante As Integer) As Double
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOTARIFA_SERVICIO.sp_monto_venta_servicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_servicio", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0).Rows(0).Item(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
End Class
