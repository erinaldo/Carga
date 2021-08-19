Imports AccesoDatos
Public Class dtoguia_transp_xdcto
#Region "Record set"
    'Public rst_ciudad As New ADODB.Recordset
    'Public rst_tipo_servicio As New ADODB.Recordset
    'Public rst_estado As New ADODB.Recordset
    'Public rst_seguimiento_carga As New ADODB.Recordset
    ' 
    Public dt_rst_ciudad As New DataTable
    Public dt_rst_tipo_servicio As New DataTable
    Public dt_rst_estado As New DataTable
    Public dt_rst_seguimiento_carga As New DataTable
    '
#End Region
#Region "Variables"
    Public sfecha_inicio As String
    Public sfecha_final As String
    Public lciudad_origen As Long
    Public lciudad_destino As Long
    Public lidtipo_servicio As Long
    Public lnro_unidad_transporte As Long
    Public lidestado As Long
    Public srazon_social As String
#End Region
    '--
#Region "Procedimientos y Funciones"
    'Public Function fn_load_seguimiento_carga_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_ciudad = Nothing
    '        rst_tipo_servicio = Nothing
    '        rst_estado = Nothing
    '        ' 
    '        Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_lista_seguimiento_carga", 2}
    '        rst_ciudad = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        rst_tipo_servicio = rst_ciudad.NextRecordset
    '        rst_estado = rst_ciudad.NextRecordset
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_load_seguimiento_carga() As Boolean
        Dim flag As Boolean = False
        ''
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_ciudad = Nothing
            dt_rst_ciudad = New DataTable

            dt_rst_tipo_servicio = Nothing
            dt_rst_tipo_servicio = New DataTable

            dt_rst_estado = Nothing
            dt_rst_estado = New DataTable
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
            dt_rst_tipo_servicio = lds_tmp.Tables(1)
            dt_rst_estado = lds_tmp.Tables(2)
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_get_seguimiento_carga_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_seguimiento_carga = Nothing
    '        Dim SQLQuery As Object() = {"PKG_REP_GUIAS_ENVIO.sp_get_seguimiento_carga", 18, _
    '                                                                     sfecha_inicio, 2, _
    '                                                                     sfecha_final, 2, _
    '                                                                     lciudad_origen, 1, _
    '                                                                     lciudad_destino, 1, _
    '                                                                     lidtipo_servicio, 1, _
    '                                                                     lnro_unidad_transporte, 1, _
    '                                                                     lidestado, 1, _
    '                                                                     srazon_social, 2}
    '        rst_seguimiento_carga = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_get_seguimiento_carga() As Boolean
        Dim flag As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            '
            dt_rst_seguimiento_carga = Nothing
            dt_rst_seguimiento_carga = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_get_seguimiento_carga", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vfecha_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("niciudad_origen", lciudad_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("nciudad_destino", lciudad_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("nidtipo_servicio", lidtipo_servicio, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("nnro_unidad_transporte", lnro_unidad_transporte, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("nidestado", lidestado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vrazon_social", srazon_social, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_seguimiento", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rst_seguimiento_carga = db_bd.EjecutarDataTable
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
#End Region
End Class