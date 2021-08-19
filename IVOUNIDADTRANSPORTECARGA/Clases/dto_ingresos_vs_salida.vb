Imports AccesoDatos
Public Class dto_ingresos_vs_salida
#Region "Variables"
    Dim ll_idagencia_origen As Long
    Dim ll_idagencia_destino As Long
    Dim ll_idunidad_origen As Long
    Dim ll_idunidad_destino As Long
    Dim ls_fecha_inicio As String
    Dim ls_fecha_final As String
#End Region
#Region "Propiedades"
    Public Property fecha_inicio() As String
        Get
            Return ls_fecha_inicio
        End Get
        Set(ByVal value As String)
            ls_fecha_inicio = value
        End Set
    End Property
    Public Property fecha_final() As String
        Get
            Return ls_fecha_final
        End Get
        Set(ByVal value As String)
            ls_fecha_final = value
        End Set
    End Property
    Public Property idciudad_origen() As Long
        Get
            Return ll_idunidad_origen
        End Get
        Set(ByVal value As Long)
            ll_idunidad_origen = value
        End Set
    End Property
    Public Property idunidad_destino() As Long
        Get
            Return ll_idunidad_destino
        End Get
        Set(ByVal value As Long)
            ll_idunidad_destino = value
        End Set
    End Property
    Public Property idagencia_origen() As Long
        Get
            Return ll_idagencia_origen
        End Get
        Set(ByVal value As Long)
            ll_idagencia_origen = value
        End Set
    End Property
    Public Property idagencia_destino() As Long
        Get
            Return ll_idagencia_destino
        End Get
        Set(ByVal value As Long)
            ll_idagencia_destino = value
        End Set
    End Property
#End Region
#Region "Funciones"
    'Public Function fn_carga_datos_datos_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_REP_GUIAS_ENVIO.sp_lista_ingreso_vs_salida", 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_carga_datos_datos() As DataSet
        '
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_lista_ingreso_vs_salida", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudades", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_recupera_consulta_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_REP_GUIAS_ENVIO.sp_get_bultos_x_agencia", 14, _
    '                                                    ll_idunidad_origen, 1, _
    '                                                    ll_idunidad_destino, 1, _
    '                                                    ll_idagencia_origen, 1, _
    '                                                    ll_idagencia_destino, 1, _
    '                                                    ls_fecha_inicio, 2, _
    '                                                    ls_fecha_final, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_recupera_consulta() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_get_bultos_x_agencia", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idunidad_agencia_ori", ll_idunidad_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_des", ll_idunidad_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia", ll_idagencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_destino", ll_idagencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", ls_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", ls_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function
#End Region
End Class