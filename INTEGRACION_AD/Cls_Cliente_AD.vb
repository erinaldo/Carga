Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_Cliente_AD
    Function ListarClasificacion() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_clasificacion_cli", CommandType.StoredProcedure)
            db.AsignarParametro("co_clasificacion", OracleClient.OracleType.Cursor)
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
    Function ListarDocumentoIdentidad() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_documento_identidad", CommandType.StoredProcedure)
            db.AsignarParametro("co_tipo", OracleClient.OracleType.Cursor)
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
    Function ListarRubro() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_rubro_empresa", CommandType.StoredProcedure)
            db.AsignarParametro("co_rubro", OracleClient.OracleType.Cursor)
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

    Function ObtieneCliente(cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_obtiene_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
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

    Function BuscarCliente(cliente As String, opcion As Integer, Optional usuario As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_Buscar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
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

    Sub Grabar(tipo_persona As Integer, tipo_documento As Integer, numero_documento As String, razon_social As String, _
               nombre As String, apellido_paterno As String, apellido_materno As String, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_grabar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo_persona", tipo_persona, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_doc", tipo_documento, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_num_doc", numero_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nombre", nombre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ap", apellido_paterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_am", apellido_materno, OracleClient.OracleType.VarChar)
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
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub Grabar(obj As Cls_Cliente_EN)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_grabar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", obj.ID, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_persona", obj.TipoPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_doc", obj.TipoDocumento, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_num_doc", obj.NumeroDocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", obj.RazonSocial, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nombre", obj.Nombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ap", obj.ApellidoPaterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_am", obj.ApellidoMaterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_ingreso", obj.FechaIngreso, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_gerente_general", obj.GerenteGeneral, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_representante_legal", obj.RepresentanteLegal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_pagina_web", obj.PaginaWeb, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_nacimiento", obj.FechaNacimiento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_sexo", obj.Sexo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_email", obj.Email, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agente_retencion", obj.AgenteRetencion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_pago_postfacturacion", obj.PagoPostFacturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rubro_empresa", obj.RubroEmpresarial, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_clasificacion_empresa", obj.ClasificacionEmpresa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_fuente", obj.Fuente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_descuento", obj.Descuento, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_digitos_serie", obj.DigitosSerie, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_usuario_web", obj.UsuarioWeb, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_password_web", obj.Contraseña, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", obj.Producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_consignado", obj.Consignado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", obj.Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", obj.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_base_articulo", obj.BaseArticulo, OracleClient.OracleType.Int32)
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

    Function ConsultaCliente(cliente As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_consulta_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(3).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(3).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(3).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ConsultaClienteDetalle(cliente As Integer, Optional opcion As Integer = 0, Optional estado As Integer = 1, _
                                    Optional estado1 As Integer = 1, Optional estado2 As Integer = 1, Optional estado3 As Integer = 1) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_consulta_cliente_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado1", estado1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado2", estado2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado3", estado3, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cartera", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_credito", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_facturacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(4).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(4).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(4).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    '-------------------------------------------------CLIENTE NO CORPORATIVO----------------------------------------------------
    Function BuscarClienteNoCorporativo(cliente As String, opcion As Integer, Optional usuario As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_Buscar_cli_nocorporativo", CommandType.StoredProcedure)
            db.AsignarParametro("vi_cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
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

    Function ObtieneSituacionCliente(cliente As Integer, funcionario As Integer) As Integer
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_IVOGESTION_CLIENTE.sf_get_situacion_cliente(" & cliente & "," & funcionario & ") from dual"
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

    Sub AsociarCliente(cliente As Integer, producto As Integer, funcionario As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_asociar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)

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
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class
