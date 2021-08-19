Imports AccesoDatos
Public Class dtoguia_transp_despacho_vs_recepcion
#Region "Datatasbles "
    'Public rst_ciudad As New ADODB.Recordset
    'Public rst_con_despacho_x_recepcion As New ADODB.Recordset
    'Public rst_con_despacho_x_recepcion_origen As New ADODB.Recordset
    '
    Public dt_rst_ciudad As New DataTable
    Public dt_rst_con_despacho_x_recepcion As New DataTable
    Public dt_rst_con_despacho_x_recepcion_origen As New DataTable
#End Region
#Region "Variables"
    Public sfecha_inicio As String
    Public sfecha_final As String
    Public lciudad_origen As Long
    Public lciudad_destino As Long
#End Region
    '--
#Region "Procedimientos y Funciones"
    'Public Function fn_load_guia_trans_despacho_vs_recepcion_2009() As Boolean
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
    Public Function fn_load_guia_trans_despacho_vs_recepcion() As Boolean
        Dim flag As Boolean = False
        '
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_con_despacho_x_recepcion = Nothing
            dt_rst_con_despacho_x_recepcion = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_lista_seguimiento_carga", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_tipo_servicio", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_estado", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            dt_rst_ciudad = lds_tmp.Tables(0)
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_destino_trans_despacho_vs_recepcion_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        '
    '        rst_con_despacho_x_recepcion = Nothing
    '        ' 
    '        Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_con_despacho_x_recepcion", 10, _
    '                                                                       sfecha_inicio, 2, _
    '                                                                       sfecha_final, 2, _
    '                                                                       lciudad_origen, 1, _
    '                                                                       lciudad_destino, 1}

    '        rst_con_despacho_x_recepcion = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_destino_trans_despacho_vs_recepcion() As Boolean
        Dim flag As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_rst_con_despacho_x_recepcion = Nothing
            dt_rst_con_despacho_x_recepcion = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_con_despacho_x_recepcion", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vfecha_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("niciudad_origen", lciudad_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("nciudad_destino", lciudad_destino, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_seguimiento", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rst_con_despacho_x_recepcion = db_bd.EjecutarDataTable
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        Return flag
    End Function
    'Public Function fn_origen_guia_trans_despacho_vs_recepcion_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_con_despacho_x_recepcion_origen = Nothing 'loco de m
    '        ' 
    '        'Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_con_despacho_x_recep_origen", 8, _ 
    '        Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_con_despacho_x_recep_orig_2", 10, _
    '                                                                       sfecha_inicio, 2, _
    '                                                                       sfecha_final, 2, _
    '                                                                       lciudad_destino, 1, _
    '                                                                       lciudad_origen, 1}
    '        rst_con_despacho_x_recepcion_origen = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_origen_guia_trans_despacho_vs_recepcion() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_rst_con_despacho_x_recepcion_origen = Nothing
            dt_rst_con_despacho_x_recepcion_origen = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_con_despacho_x_recep_orig_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vfecha_inicial", sfecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("nciudad_destino", lciudad_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("nciudad_origen", lciudad_origen, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_seguimiento", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rst_con_despacho_x_recepcion_origen = db_bd.EjecutarDataTable
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
#End Region
End Class
