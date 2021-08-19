Imports AccesoDatos
Public Class dtoconsulta_liquidaciones
#Region "Variables"
    Private ll_idagencia As Long
    Private vi_fecha_inicio As String
    Private vi_fecha_final As String
    Private ll_idtipo_consulta As Long
#End Region
#Region "Property"
    Public Property idtipo_consulta() As Long
        Get
            Return ll_idtipo_consulta
        End Get
        Set(ByVal value As Long)
            ll_idtipo_consulta = value
        End Set
    End Property
    Public Property fecha_final() As String
        Get
            Return vi_fecha_final
        End Get
        Set(ByVal value As String)
            vi_fecha_final = value
        End Set
    End Property
    Public Property fecha_inicio() As String
        Get
            Return vi_fecha_inicio
        End Get
        Set(ByVal value As String)
            vi_fecha_inicio = value
        End Set
    End Property
    Public Property idagencia() As Long
        Get
            Return ll_idagencia
        End Get
        Set(ByVal value As Long)
            ll_idagencia = value
        End Set
    End Property
#End Region
#Region "Procedimiento y Funciones"

    'Public Function fn_load2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"pkg_rep_guias_envio.sp_lista_liquidaciones", 8, _
    '                                                                                                      ll_idagencia, 1, _
    '                                                                                                      vi_fecha_inicio, 2, _
    '                                                                                                      vi_fecha_final, 2}
    '    ' 
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function fn_load() As DataSet
        'Dim ObjUnd2 As Object() = {"pkg_rep_guias_envio.sp_lista_liquidaciones", 8, ll_idagencia, 1, vi_fecha_inicio, 2, vi_fecha_final, 2}
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_rep_guias_envio.sp_lista_liquidaciones", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idagencias", ll_idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_liquidacion_consulta", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_lista_liquidaciones_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"pkg_rep_guias_envio.sp_get_cierres", 10, ll_idtipo_consulta, 1, ll_idagencia, 1, vi_fecha_inicio, 2, vi_fecha_final, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_lista_liquidaciones() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_rep_guias_envio.sp_get_cierres", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idtipo_consulta", ll_idtipo_consulta, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencias", ll_idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fec_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class

