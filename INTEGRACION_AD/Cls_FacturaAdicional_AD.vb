Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_FacturaAdicional_AD

    Function ListarSolicitud(tipo As Integer, comprobante As Integer, estado As Integer, facturado As Integer, Optional solicitud As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURA_ADICIONAL.sp_listar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_facturado", facturado, OracleClient.OracleType.Int32)
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

    Function ListarFacturaAdicional(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURA_ADICIONAL.sp_listar_factura_adicional", CommandType.StoredProcedure)
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

    Function GrabarFactura(ByVal tipo As Integer, ByVal id_original As Integer, _
                       ByVal cliente As Integer, ByVal tipo_documento As Integer, ByVal numero_documento As String, ByVal nombres As String, ByVal ap As String, ByVal am As String, ByVal razon_social As String, ByVal telefono As String, ByVal email As String, _
                       ByVal iddireccion As Integer, ByVal direccion As String, ByVal idvia As Integer, ByVal via As String, ByVal numero As String, ByVal manzana As String, ByVal lote As String, ByVal idnivel As Integer, ByVal nivel As String,
                       ByVal idzona As Integer, ByVal zona As String, ByVal idclasificacion As Integer, ByVal clasificacion As String, _
                       ByVal iddepartamento As Integer, ByVal idprovincia As Integer, ByVal iddistrito As Integer, _
                       ByVal agencia As Integer, ByVal forma_pago As Integer, ByVal tipo_tarjeta As Integer, ByVal tarjeta As String, _
                       ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double, _
                       ByVal domicilio As Double, ByVal cargo As Double, ByVal fz As Double, _
                       ByVal usuario As Integer, ByVal ip As String, ByVal solicitud As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURA_ADICIONAL.sp_grabar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_original", id_original, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_documento", tipo_documento, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_numero_documento", numero_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nombres", nombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ap", ap, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_am", am, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_telefono", telefono, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_email", email, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_direccion", iddireccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_direccion", direccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idvia", idvia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_via", via, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_manzana", manzana, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_lote", lote, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idnivel", idnivel, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nivel", nivel, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idzona", idzona, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_zona", zona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idclasificacion", idclasificacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_clasificacion", clasificacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_iddepartamento", iddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idprovincia", idprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_iddistrito", iddistrito, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_forma_pago", forma_pago, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarjeta", tipo_tarjeta, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_tarjeta", tarjeta, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_subtotal", subtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_domicilio", domicilio, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cargo", cargo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_fz", fz, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_version", 2, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", 1, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_solicitud", solicitud, OracleClient.OracleType.Int32)

            'db.AsignarParametro("co_idfactura", OracleClient.OracleType.Cursor)
            'db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            'Dim ds As DataSet = db.EjecutarDataSet
            'If ds.Tables(1).Rows.Count > 0 Then
            '    If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
            '        Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
            '    End If
            'End If

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_idfactura", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If

            Return ds.Tables(1)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function BuscarComprobante(inicio As String, fin As String, origen As Integer, destino As Integer, numero As String, serie As String, _
                           numero_documento As String, cliente As String, opcion As Integer, tipo As Integer, facturado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURA_ADICIONAL.sp_buscar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero_documento", numero_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_facturado", facturado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)

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

    Function BuscarCliente(numero_documento As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURA_ADICIONAL.sp_buscar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_numero_documento", numero_documento, OracleClient.OracleType.VarChar)

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

    Function ListarTipoTarjeta() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURA_ADICIONAL.sp_listar_tipo_tarjeta", CommandType.StoredProcedure)

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

    Function ComprobanteOperacion(comprobante As Integer) As String
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_IVOFACTURA_ADICIONAL.sf_get_comprobante_operacion(" & comprobante & ") from dual"
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

End Class
