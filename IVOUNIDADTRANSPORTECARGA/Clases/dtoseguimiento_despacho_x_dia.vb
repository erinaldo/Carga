Imports AccesoDatos
Class dtoseguimiento_despacho_x_dia
#Region "Record set"
    'Public rst_ciudad As New ADODB.Recordset
    'Public rst_seg_despacho_x_fecha As New ADODB.Recordset
    'Public rst_saldo_despacho_x_dia As New ADODB.Recordset
    'Public rst_seg_despacho_x_fecha_destino As New ADODB.Recordset
    '
    Public dt_rst_ciudad As New DataTable
    Public dt_rst_seg_despacho_x_fecha As New DataTable
    Public dt_rst_saldo_despacho_x_dia As New DataTable
    Public dt_rst_seg_despacho_x_fecha_destino As New DataTable
    '
#End Region
#Region "Variables"
    Public sfecha_inicio As String
    Public sfecha_final As String
    Public lciudad_origen As Long
    Public lciudad_destino As Long
#End Region
    '--
#Region "Procedimientos y Funciones"
    'Public Function fn_load_guia_seguimiento_despacho_x_fecha_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_ciudad = Nothing
    '        ' 
    '        Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_lista_seguimiento_carga", 2}
    '        rst_ciudad = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_load_guia_seguimiento_despacho_x_fecha() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_ciudad = Nothing
            dt_rst_ciudad = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_lista_seguimiento_carga", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_tipo_servicio", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_estado", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_rst_ciudad = lds_tmp.Tables(0)
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_seg_despacho_dia_origen_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        '
    '        rst_seg_despacho_x_fecha = Nothing
    '        rst_saldo_despacho_x_dia = Nothing
    '        Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_despacho_dia_origen", 8, _
    '                                                                       sfecha_inicio, 2, _
    '                                                                       sfecha_final, 2, _
    '                                                                       lciudad_origen, 1}
    '        '
    '        rst_seg_despacho_x_fecha = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        rst_saldo_despacho_x_dia = rst_seg_despacho_x_fecha.NextRecordset()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_seg_despacho_dia_origen() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_seg_despacho_x_fecha = Nothing
            dt_rst_seg_despacho_x_fecha = New DataTable
            '
            dt_rst_saldo_despacho_x_dia = Nothing
            dt_rst_saldo_despacho_x_dia = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_despacho_dia_origen", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vfecha_inicial", sfecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("nidunidad_agencia", lciudad_origen, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_despacho", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_saldo", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_rst_seg_despacho_x_fecha = lds_tmp.Tables(0)
            dt_rst_saldo_despacho_x_dia = lds_tmp.Tables(1)
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_seg_despacho_destino_x_dia_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_seg_despacho_x_fecha_destino = Nothing
    '        ' 
    '        Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_despacho_destino_xdia", 6, _
    '                                                                       sfecha_inicio, 2, _
    '                                                                       lciudad_origen, 1}
    '        rst_seg_despacho_x_fecha_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_seg_despacho_destino_x_dia() As Boolean
        Dim flag As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            '
            dt_rst_seg_despacho_x_fecha_destino = Nothing
            dt_rst_seg_despacho_x_fecha_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_despacho_destino_xdia", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vfecha", sfecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("nidunidad_agencia", lciudad_origen, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_despacho", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rst_seg_despacho_x_fecha_destino = db_bd.EjecutarDataTable
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
#End Region
End Class
