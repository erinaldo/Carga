Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_ClienteTipoFacturacion_AD
    Function ListarTipoFacturacion(cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente_facturacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_facturacion", OracleClient.OracleType.Cursor)
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

    Function ListarSolicitud(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud_tipo_fac", CommandType.StoredProcedure)
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

    Function ListarSolicitud(estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud_tipo_fac", CommandType.StoredProcedure)
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

    Function ExisteSolicitud(obj As Cls_ClienteTipoFacturacion_EN) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sf_get_existe_solicitud_fac (" & obj.Cliente & "," & obj.Estado & ") "
            strCadena &= "from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Dim intEstado As Integer = db.EjecutarEscalar()
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

    Function ExisteTipoFacturacion(obj As Cls_ClienteTipoFacturacion_EN) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sp_existe_tipo_facturacion (" & obj.Cliente & "," & obj.TipoFacturacion & ") "
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

    Public Sub GrabarSolicitud(obj As Cls_ClienteTipoFacturacion_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_solicitud_cliente_tipo_fac", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero_solicitud", obj.NumeroSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_facturacion", obj.TipoFacturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_contacto", obj.Contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_orden_compra", obj.OrdenCompra, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_liquidacion_documento", obj.LiquidacionDocumento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_forma_facturacion", obj.FormaFacturacion, OracleClient.OracleType.Int32)
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

    Sub Anular(obj As Cls_ClienteTipoFacturacion_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_anular_solicitud_factura", CommandType.StoredProcedure)
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

    Sub AprobarSolicitud(obj As Cls_ClienteTipoFacturacion_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_aprobar_solicitud_tipo_fac", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_facturacion", obj.TipoFacturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", obj.Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_contacto", obj.Contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_orden_compra", obj.OrdenCompra, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_liquidacion_documento", obj.LiquidacionDocumento, OracleClient.OracleType.Int32)

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

    Sub DesaprobarSolicitud(obj As Cls_ClienteTipoFacturacion_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_desaprueba_sol_tipo_fac", CommandType.StoredProcedure)
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

    Function ListarCargos() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cargos", CommandType.StoredProcedure)
            db.AsignarParametro("co_cargo", OracleClient.OracleType.Cursor)
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

    Function ListarCargos(cliente As Integer, opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente_cargo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cargo", OracleClient.OracleType.Cursor)
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

    Public Sub GrabarCargo(id As Integer, cliente As Integer, subcuenta As Integer, cargo As Integer, estado As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_grabar_cargo_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_subcuenta", subcuenta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cargo", cargo, OracleClient.OracleType.Int32)
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

    Function ListarFormaFacturacion() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_forma_facturacion", CommandType.StoredProcedure)
            db.AsignarParametro("co_forma", OracleClient.OracleType.Cursor)
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

    Function ListarClienteCargo(cliente As Integer, opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente_cargo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cargo", OracleClient.OracleType.Cursor)
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

    Function ListarClienteCargos(cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente_cargos", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cargo", OracleClient.OracleType.Cursor)
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

End Class
