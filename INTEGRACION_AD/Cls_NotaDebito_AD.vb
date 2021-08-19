Imports AccesoDatos
Imports INTEGRACION_EN

Public Class Cls_NotaDebito_AD
    Function ListarOperacion() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTADEBITO.sp_listar_operacion", CommandType.StoredProcedure)
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
    Function ListarComprobante(ByVal tipo As Integer, ByVal serie As String, ByVal numero As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTADEBITO.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)

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

    Function ListarNotaDebito(ByVal inicio As String, ByVal fin As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVONOTADEBITO.sp_listar_nota_debito", CommandType.StoredProcedure)
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

    Function GrabarNotaDebito(ByVal id As Integer, ByVal serie As String, ByVal numero As String, ByVal fecha As String, ByVal glosa As String, _
                              ByVal impuesto As Double, ByVal total As Double, ByVal operacion As Integer, ByVal agencia As Integer, ByVal tipo As Integer, _
                              ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVONOTADEBITO.sp_nd_otro", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_glosa", glosa, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", 92, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            's_cod_mensaje = ds.Tables(1).Rows(0)(0)
            's_mensaje = ds.Tables(1).Rows(0)(1)
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
