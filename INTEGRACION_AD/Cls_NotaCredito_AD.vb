Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_NotaCredito_AD
    Function ListarComprobante(tipo As Integer, comprobante As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_comprobante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_nc", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_nuevo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(3).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(3).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(3).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarComprobante(comprobante As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)

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

    Sub AnularNotaCredito(tipo As Integer, comprobante As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_anular_nota_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
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

    Function ListarNotaCredito(inicio As String, fin As String, tipo As Integer, serie As String, numero As String, opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_listar_nota_credito", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
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


    Function ListarOperacion(tipo_registro As Integer, tipo As Integer, tipo_servicio As Integer, tipo_comprobante As Integer, _
                             tipo_emision As Integer, modo As Integer, rol As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_listar_operacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo_registro", tipo_registro, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_servicio", tipo_servicio, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_comprobante", tipo_comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_emision", tipo_emision, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_modo", modo, OracleClient.OracleType.Int32)
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

    Function ListarComprobante(tipo As Integer, comprobante As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_buscar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
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

    Function GrabarNotaCredito(ByVal tipo As Integer, ByVal id_original As Integer, ByVal fecha As String, ByVal operacion As Integer, ByVal glosa As String, _
                          ByVal agencia As Integer, ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double, _
                          ByVal usuario As Integer, ByVal ip As String, Optional ByVal cuenta_corriente As Integer = 0) As DataRow
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_grabar_nota_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id_original", id_original, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_glosa", glosa, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_subtotal", subtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            'hlamas 16-05-2017
            'db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 2, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_cuenta_corriente", cuenta_corriente, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet


            '-->recupera el Numero de la nota de credito que se haya generado.
            Dim datarow As DataRow = ds.Tables(0).Rows(0)
            'Dim numeroNotaCredito As String = datarow("n_serie_comprobante").ToString() & "-" & datarow("n_numero_comprobante").ToString()


            '-->Por si retorne algun error
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If

            Return datarow
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function GrabarFactura(tipo As Integer, id_original As Integer, fecha As String, glosa As String, _
                           cliente As Integer, tipo_documento As Integer, numero_documento As String, nombres As String, ap As String, am As String, razon_social As String, telefono As String, email As String, _
                           iddireccion As Integer, direccion As String, idvia As Integer, via As String, numero As String, manzana As String, lote As String, idnivel As Integer, nivel As String,
                           idzona As Integer, zona As String, idclasificacion As Integer, clasificacion As String, _
                           iddepartamento As Integer, idprovincia As Integer, iddistrito As Integer, referencia As String, _
                           agencia As Integer, subtotal As Double, impuesto As Double, total As Double, operacion As Integer, origen As Integer, usuario As Integer, ip As String) As DataRow
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_grabar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_original", id_original, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_glosa", glosa, OracleClient.OracleType.VarChar)


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
            db.AsignarParametro("vi_referencia", referencia, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_subtotal", subtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)

            'hlamas 16-05-2017
            'db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 2, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet

            '-->recupera el Numero de la nota de credito que se haya generado.
            Dim datarow As DataRow = ds.Tables(0).Rows(0)
            'Dim numeroComprobante As String = datarow("n_serie_comprobante").ToString() & "-" & datarow("n_numero_comprobante").ToString()

            '-->Por si ocurra algun error
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If

            Return datarow
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub AmarrarComprobante(id As Integer, id_ref As Integer, operacion As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOAUTORIZACION.sp_amarrar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_ref", id_ref, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
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

    Function EmiteComprobante(fecha1 As String, fecha2 As String) As Integer
        Dim flag As Integer = 0
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_IVONOTA_CREDITO.sf_get_emision_comprobante('" & fecha1 & "','" & fecha2 & "') from dual"
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

    Sub AnularComprobante(comprobante As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_anular_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
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

    Function BuscarComprobante(inicio As String, fin As String, origen As Integer, destino As Integer, numero As String, serie As String, _
                       numero_documento As String, cliente As String, opcion As Integer, tipo As Integer, estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_buscar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero_documento", numero_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
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

    Function ListarDatosComprobante(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTA_CREDITO.sp_listar_datos_comprobante", CommandType.StoredProcedure)
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

    Function ObtieneSaldoCuentaCorriente(ByVal numero As String) As Double
        Dim flag As Double = 0
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_IVONOTA_CREDITO.sf_get_saldo_ctacte('" & numero & "') from dual"
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
