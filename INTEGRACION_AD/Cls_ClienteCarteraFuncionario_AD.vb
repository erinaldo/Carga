Imports AccesoDatos
Imports INTEGRACION_EN
Public Class Cls_ClienteCarteraFuncionario_AD
    Public Function ObtieneCliente(numero_documento As String) As DataTable
        Dim DB As New BaseDatos
        Try
            DB.Conectar()
            DB.CrearComando("PKG_IVOGESTION_CLIENTE.sp_obtiene_cliente", CommandType.StoredProcedure)
            DB.AsignarParametro("vi_numero_documento", numero_documento, OracleClient.OracleType.VarChar)
            DB.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            DB.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = DB.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            DB.Desconectar()
        End Try
    End Function

    Public Sub GrabarSolicitud(obj As Cls_ClienteCarteraFuncionario_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_solicitud_cliente_cuenta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_numero_solicitud", obj.NumeroSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_sustento", obj.Sustento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha", obj.Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_responsable_actual", obj.ResponsableActual, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", obj.ResponsableFechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_cuenta", obj.TipoCuenta, OracleClient.OracleType.Int32)
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

    Function ListarSolicitud(responsable As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_responsable", responsable, OracleClient.OracleType.Int32)
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
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_solicitud", CommandType.StoredProcedure)
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

    Sub Anular(obj As Cls_ClienteCarteraFuncionario_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_anular_solicitud", CommandType.StoredProcedure)
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

    Function ExisteSolicitud(obj As Cls_ClienteCarteraFuncionario_EN) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sf_get_existe_solicitud (" & obj.Cliente & "," & obj.Estado & ") "
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

    Sub AprobarSolicitud(obj As Cls_ClienteCarteraFuncionario_EN, opcion As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_aprobar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_solicitante", obj.Responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", obj.Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_observaciones", obj.Observaciones, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_responsable_actual", obj.ResponsableActual, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_fin", obj.ResponsableFechaFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_cuenta", obj.TipoCuenta, OracleClient.OracleType.Int32)

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

    Function ListarFuncionario() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_funcionario_carga", CommandType.StoredProcedure)
            db.AsignarParametro("co_funcionario", OracleClient.OracleType.Cursor)
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

    Function ListarCartera(funcionario As Integer, Optional credito As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cartera", CommandType.StoredProcedure)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_credito", credito, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cartera", OracleClient.OracleType.Cursor)
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

    Sub TranseferirCuenta(obj As Cls_ClienteCarteraFuncionario_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_transferir_cuenta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable_actual", obj.ResponsableActual, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable", obj.Responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_inicio", obj.Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_fin", obj.ResponsableFechaFin, OracleClient.OracleType.VarChar)
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

    Sub RetirarClienteCartera(obj As Cls_ClienteCarteraFuncionario_EN, desactiva As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_retirar_cliente_cartera", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_responsable", obj.ResponsableActual, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_fin", obj.ResponsableFechaFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_desactiva_lc", desactiva, OracleClient.OracleType.Int16)
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
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ListarCarteraNoCorporativo(funcionario As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cartera_nocorp", CommandType.StoredProcedure)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cartera", OracleClient.OracleType.Cursor)
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

    Function ListarTipoCartera(opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_tipo_cartera", CommandType.StoredProcedure)
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

    Function ListarGC1(usuario As Integer, ip As String, inicio As String, fin As String, responsable As Integer, fecha As String, _
                       opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_gc_1", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_responsable", responsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
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
End Class
