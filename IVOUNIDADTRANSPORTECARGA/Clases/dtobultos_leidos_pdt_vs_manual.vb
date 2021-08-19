Imports AccesoDatos
Public Class dtobultos_leidos_pdt_vs_manual
#Region "variables"
    '
    'Public rst_agencia As New ADODB.Recordset
    'Public rst_bultos_leidos_pdt_vs_manual As New ADODB.Recordset
    '
    ' Reemplaza a los record set 
    Public dt_rst_agencia As New DataTable
    Public dt_rst_bultos_leidos_pdt_vs_manual As New DataTable
    '---
    Public li_idagencias As Long
    Public vi_fecha_inicio As String
    Public vi_fecha_final As String
    ' --- 
#End Region
#Region "Funciones"
    'Public Function fn_load_bultos_leidos_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_agencia = Nothing
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_lista_lee_bultos_vs_manual", 8, _
    '                                                               li_idagencias, 1, _
    '                                                               vi_fecha_inicio, 2, _
    '                                                               vi_fecha_final, 2}
    '        ' 
    '        rst_agencia = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        rst_bultos_leidos_pdt_vs_manual = rst_agencia.NextRecordset
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    '    '
    'End Function
    Public Function fn_load_bultos_leidos_pdt_vs_manual() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_agencia = Nothing
            dt_rst_agencia = New DataTable
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_lista_lee_bultos_vs_manual", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            dt_rst_agencia = lds_tmp.Tables(0)
            dt_rst_bultos_leidos_pdt_vs_manual = lds_tmp.Tables(1)
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
        '
    End Function
    'Public Function fn_bultos_leidos_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_bultos_leidos", 8, _
    '                                                   li_idagencias, 1, _
    '                                                   vi_fecha_inicio, 2, _
    '                                                   vi_fecha_final, 2}
    '        ' 
    '        rst_bultos_leidos_pdt_vs_manual = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    '    '
    'End Function
    Public Function fn_bultos_leidos_pdt_vs_manual() As Boolean
        Dim flag As Boolean = False
        Try
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_bultos_leidos", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_rst_bultos_leidos_pdt_vs_manual = ldt_tmp
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
        '
    End Function
    'Public Function fn_load_bultos_leidos_recepcion_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_agencia = Nothing
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_get_leebulto_recep_x_manual", 8, _
    '                                                                                                                                      li_idagencias, 1, _
    '                                                                                                                                      vi_fecha_inicio, 2, _
    '                                                                                                                                      vi_fecha_final, 2}
    '        ' 
    '        rst_agencia = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        rst_bultos_leidos_pdt_vs_manual = rst_agencia.NextRecordset
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_load_bultos_leidos_recepcion_pdt_vs_manual() As Boolean
        Dim flag As Boolean = False
        Try
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_agencia = Nothing
            dt_rst_agencia = New DataTable
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_get_leebulto_recep_x_manual", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_rst_agencia = lds_tmp.Tables(0)
            dt_rst_bultos_leidos_pdt_vs_manual = lds_tmp.Tables(1)
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_bultos_leidos_recepcion_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_bultos_leidos_recepcion", 8, _
    '                                                   li_idagencias, 1, _
    '                                                   vi_fecha_inicio, 2, _
    '                                                   vi_fecha_final, 2}
    '        ' 
    '        rst_bultos_leidos_pdt_vs_manual = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    '    '
    'End Function
    Public Function fn_bultos_leidos_recepcion_pdt_vs_manual() As Boolean
        Dim flag As Boolean = False
        Try
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_bultos_leidos_recepcion", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_rst_bultos_leidos_pdt_vs_manual = ldt_tmp
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
        '
    End Function
    'Public Function fn_load_bultos_leidos_reparto_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_agencia = Nothing
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_getleebulto_reparto_manual", 8, _
    '                                                                                                                             li_idagencias, 1, _
    '                                                                                                                          vi_fecha_inicio, 2, _
    '                                                                                                                            vi_fecha_final, 2}
    '        ' 
    '        rst_agencia = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        rst_bultos_leidos_pdt_vs_manual = rst_agencia.NextRecordset
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_load_bultos_leidos_reparto_pdt_vs_manual() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_agencia = Nothing
            dt_rst_agencia = New DataTable
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_getleebulto_reparto_manual", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_rst_agencia = lds_tmp.Tables(0)
            dt_rst_bultos_leidos_pdt_vs_manual = lds_tmp.Tables(1)
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_bultos_leidos_reparto_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_bultos_leidos_reparto", 8, _
    '                                                   li_idagencias, 1, _
    '                                                   vi_fecha_inicio, 2, _
    '                                                   vi_fecha_final, 2}
    '        ' 
    '        rst_bultos_leidos_pdt_vs_manual = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    '    '
    'End Function
    Public Function fn_bultos_leidos_reparto_pdt_vs_manual() As Boolean
        Dim flag As Boolean = False
        Try
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_bultos_leidos_reparto", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_rst_bultos_leidos_pdt_vs_manual = ldt_tmp
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        '
        Return flag
        '
    End Function
    'Public Function fn_load_bultos_leidos_almacen_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        rst_agencia = Nothing
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_get_leebulto_almac_x_manual", 8, _
    '                                                                                                                                      li_idagencias, 1, _
    '                                                                                                                                      vi_fecha_inicio, 2, _
    '                                                                                                                                      vi_fecha_final, 2}
    '        ' 
    '        rst_agencia = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        rst_bultos_leidos_pdt_vs_manual = rst_agencia.NextRecordset
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_load_bultos_leidos_almacen_pdt_vs_manual() As Boolean
        Dim flag As Boolean = False
        Try
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_rst_agencia = Nothing
            dt_rst_agencia = New DataTable
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_get_leebulto_almac_x_manual", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_rst_agencia = lds_tmp.Tables(0)
            dt_rst_bultos_leidos_pdt_vs_manual = lds_tmp.Tables(1)

            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_bultos_leidos_almacen_pdt_vs_manual_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        '
    '        rst_bultos_leidos_pdt_vs_manual = Nothing
    '        ' 
    '        Dim SQLQuery() As Object = {"pkg_ivobultos.sp_bultos_leidos_almacen", 8, _
    '                                                                                                                   li_idagencias, 1, _
    '                                                                                                                   vi_fecha_inicio, 2, _
    '                                                                                                                   vi_fecha_final, 2}
    '        ' 
    '        rst_bultos_leidos_pdt_vs_manual = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        '
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    '    '
    'End Function
    Public Function fn_bultos_leidos_almacen_pdt_vs_manual() As Boolean
        Dim flag As Boolean = True
        Try
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_rst_bultos_leidos_pdt_vs_manual = Nothing
            dt_rst_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_bultos_leidos_almacen", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", li_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_inicio", vi_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_final", vi_fecha_final, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_bultos_leidos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_rst_bultos_leidos_pdt_vs_manual = ldt_tmp
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
        '
    End Function
#End Region
    '
End Class