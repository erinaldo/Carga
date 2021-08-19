Imports AccesoDatos
Public Class dtocomprobantegratuitos
    'Public rst_agencias_10 As New ADODB.Recordset
    Public rst_agencias_10 As DataTable

    'Public rst_condicion As New ADODB.Recordset
    Public rst_condicion As DataTable

    'Public rst_comprobante As New ADODB.Recordset
    Public rst_comprobante As DataTable
    '
    Public iidagencias As Long
    Public iidcondicion As Long
    Public sfecha_inicio As String
    Public sfecha_final As String
    Public smemo As String
    'Public Function fnLISTA_INICIAL_COMPROBANTE_GRATUITO2009() As Boolean
    'Dim flat As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PK_REP_VENTA_PASAJE.sp_listar_dctos_gratuitos", 2}
    '    rst_agencias_10 = Nothing
    '    rst_condicion = Nothing
    '    rst_agencias_10 = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_agencias_10.EOF = False And rst_agencias_10.BOF = False Then
    '        rst_condicion = rst_agencias_10.NextRecordset
    '    End If
    '    flat = True
    'Catch ex As Exception
    '    flat = False
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return flat
    'End Function
    Public Function fnLISTA_INICIAL_COMPROBANTE_GRATUITO() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PK_REP_VENTA_PASAJE.sp_listar_dctos_gratuitos", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_condiciones", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_agencias_10 = ds.Tables(0)
            If rst_agencias_10.Rows.Count > 0 Then
                rst_condicion = ds.Tables(1)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Sub fn_pasajes_asumidos_xempresa2009()
    '    Try
    '        rst_comprobante = Nothing
    '        Dim varSP_OBJECT() As Object = {"PK_REP_VENTA_PASAJE.sp_pasajes_asumidos_xemp", 12, _
    '                                                             iidagencias, 1, _
    '                                                             sfecha_inicio, 2, _
    '                                                             sfecha_final, 2, _
    '                                                             iidcondicion, 1, _
    '                                                             smemo, 2}
    '        rst_comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub

    Sub fn_pasajes_asumidos_xempresa()
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PK_REP_VENTA_PASAJE.sp_pasajes_asumidos_xemp", CommandType.StoredProcedure)
            db.AsignarParametro("nidagencia", iidagencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("vfec_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfec_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ncondicion", iidcondicion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vmemo", smemo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_comprobante = db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Sub fn_carga_asumidos_xempresa2009()
    'Try
    '    '
    '    rst_comprobante = Nothing
    '    Dim varSP_OBJECT() As Object = {"PKG_REP_FACTURACION.sp_carga_asumida_xemp", 8, _
    '                                                         iidagencias, 1, _
    '                                                         sfecha_inicio, 2, _
    '                                                         sfecha_final, 2}
    '    rst_comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'End Sub
    Sub fn_carga_asumidos_xempresa()
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_REP_FACTURACION.sp_carga_asumida_xemp", CommandType.StoredProcedure)
            db.AsignarParametro("nidagencia", iidagencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("vfec_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfec_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_comprobante = db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
End Class
