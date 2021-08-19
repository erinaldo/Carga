Imports AccesoDatos
Public Class dto_consulta_dctos
#Region "Variables"
    Private ls_fecha_inicio As String
    Private ls_fecha_final As String
    Private ll_idestado_envio As Long
    Private ll_idunidad_agencia_ori As Long
    Private ll_idunidad_agencia_des As Long
    Private ll_idagencia_ori As Long
    Private ll_idagencia_des As Long

#End Region
#Region "Propiedades"
    Public Property idagencia_des() As Long
        Get
            Return ll_idagencia_des
        End Get
        Set(ByVal value As Long)
            ll_idagencia_des = value
        End Set
    End Property
    Public Property idagencia_ori() As Long
        Get
            Return ll_idagencia_ori
        End Get
        Set(ByVal value As Long)
            ll_idagencia_ori = value
        End Set
    End Property
    Public Property idunidad_agencia_des() As Long
        Get
            Return ll_idunidad_agencia_des
        End Get
        Set(ByVal value As Long)
            ll_idunidad_agencia_des = value
        End Set
    End Property
    Public Property idunidad_agencia_ori() As Long
        Get
            Return ll_idunidad_agencia_ori
        End Get
        Set(ByVal value As Long)
            ll_idunidad_agencia_ori = value
        End Set
    End Property
    Public Property idestado_envio() As Long
        Get
            Return ll_idestado_envio
        End Get
        Set(ByVal value As Long)
            ll_idestado_envio = value
        End Set
    End Property
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
#End Region
#Region "Funciones y procedimientos"
    'Public Function fn_carga_datos_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_REP_GUIAS_ENVIO.sp_lista_seguimiento_dcto", 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_carga_datos() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_lista_seguimiento_dcto", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_agencia", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_estado", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_estado_gt", OracleClient.OracleType.Cursor)
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
    'Public Function fn_recupera_datos_dctos_registrados_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_REP_GUIAS_ENVIO.sp_get_carga_registrada", 16, _
    '                                                    ls_fecha_inicio, 2, _
    '                                                    ls_fecha_final, 2, _
    '                                                    ll_idestado_envio, 1, _
    '                                                    ll_idunidad_agencia_ori, 1, _
    '                                                    ll_idunidad_agencia_des, 1, _
    '                                                    ll_idagencia_ori, 1, _
    '                                                    ll_idagencia_des, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_recupera_datos_dctos_registrados() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_get_carga_registrada", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_fecha_incio", ls_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", ls_fecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idestado_envio", ll_idestado_envio, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_ori", ll_idunidad_agencia_ori, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_des", ll_idunidad_agencia_des, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_ori", ll_idagencia_ori, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_des", ll_idagencia_des, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_carga_entregada", OracleClient.OracleType.Cursor)
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
    'Public Function fn_recupera_datos_dctos_despachados_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_REP_GUIAS_ENVIO.sp_verifica_dctos_despachado", 16, _
    '                                                    ls_fecha_inicio, 2, _
    '                                                    ls_fecha_final, 2, _
    '                                                    ll_idestado_envio, 1, _
    '                                                    ll_idunidad_agencia_ori, 1, _
    '                                                    ll_idunidad_agencia_des, 1, _
    '                                                    ll_idagencia_ori, 1, _
    '                                                    ll_idagencia_des, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_recupera_datos_dctos_despachados() As DataTable        
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_verifica_dctos_despachado", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_fecha_incio", ls_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", ls_fecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_recepcionado", ll_idestado_envio, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_ori", ll_idunidad_agencia_ori, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_des", ll_idunidad_agencia_des, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_ori", ll_idagencia_ori, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_des", ll_idagencia_des, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_carga_despachada", OracleClient.OracleType.Cursor)
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
    'Public Function fn_recupera_datos_dctos_entregado_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_REP_GUIAS_ENVIO.sp_verifica_dctos_entregado", 16, _
    '                                                    ls_fecha_inicio, 2, _
    '                                                    ls_fecha_final, 2, _
    '                                                    ll_idestado_envio, 1, _
    '                                                    ll_idunidad_agencia_ori, 1, _
    '                                                    ll_idunidad_agencia_des, 1, _
    '                                                    ll_idagencia_ori, 1, _
    '                                                    ll_idagencia_des, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_recupera_datos_dctos_entregado() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_verifica_dctos_entregado", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_fecha_incio", ls_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", ls_fecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_ind_entregado", ll_idestado_envio, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_ori", ll_idunidad_agencia_ori, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_des", ll_idunidad_agencia_des, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_ori", ll_idagencia_ori, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_des", ll_idagencia_des, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_carga_entregada", OracleClient.OracleType.Cursor)
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