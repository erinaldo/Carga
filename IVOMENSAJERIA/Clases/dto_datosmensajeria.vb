Imports AccesoDatos
Public Class dto_datosmensajeria
#Region "Variables"
    Dim ls_fecha_venta As String
    '
    Dim ls_fec_inicio As String
    Dim ls_fec_final As String
    '
    Dim ls_nro_documento As String
    Dim ll_idusuario_venta As Long
#End Region
#Region "Property"
    Public Property fecha_final() As String
        Get
            Return ls_fec_final
        End Get
        Set(ByVal value As String)
            ls_fec_final = value
        End Set
    End Property
    Public Property fecha_inicio() As String
        Get
            Return ls_fec_inicio
        End Get
        Set(ByVal value As String)
            ls_fec_inicio = value
        End Set
    End Property
    Public Property fecha_venta() As String
        Get
            Return ls_fecha_venta
        End Get
        Set(ByVal value As String)
            ls_fecha_venta = value
        End Set
    End Property
    Public Property idusuario_venta() As Long
        Get
            Return ll_idusuario_venta
        End Get
        Set(ByVal value As Long)
            ll_idusuario_venta = value
        End Set
    End Property
    Public Property nro_documento() As String
        Get
            Return ls_nro_documento
        End Get
        Set(ByVal value As String)
            ls_nro_documento = value
        End Set
    End Property
#End Region
#Region "Funciones y Procedimientos"
    'Public Function fn_Listar_documentos2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"pkg_IVOMENSAJERIA.sp_get_datos_seleccionados", 6, _
    '                                                      ll_idusuario_venta, 1, _
    '                                                      ls_fecha_venta, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function fn_Listar_documentos() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.sp_get_datos_seleccionados", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idusuario_personal", ll_idusuario_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_consulta", ls_fecha_venta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_actualizar_datos2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"pkg_IVOMENSAJERIA.sp_get_datos_mensajeria", 8, _
    '                                                      ls_nro_documento, 2, _
    '                                                      ll_idusuario_venta, 1, _
    '                                                      ls_fecha_venta, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function fn_actualizar_datos() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.sp_get_datos_mensajeria", CommandType.StoredProcedure)
            db.AsignarParametro("vi_nro_documento", ls_nro_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idusuario_personal", ll_idusuario_venta, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fecha_consulta", ls_fecha_venta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_verificar_datos2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"pkg_IVOMENSAJERIA.sp_verifica_datos", 6, _
    '                                                      ls_nro_documento, 2, _
    '                                                      ll_idusuario_venta, 1}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function
    Public Function fn_verificar_datos() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.sp_verifica_datos", CommandType.StoredProcedure)
            db.AsignarParametro("vi_nro_documento", ls_nro_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idusuario", ll_idusuario_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fn_get_datos_mensajeria2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"pkg_IVOMENSAJERIA.sp_get_filtro_mensajeria", 8, _
    '                                                      ll_idusuario_venta, 1, _
    '                                                      ls_fec_inicio, 2, _
    '                                                      ls_fec_final, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function

    Public Function fn_get_datos_mensajeria() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.sp_get_filtro_mensajeria", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idusuario_personal", ll_idusuario_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fec_inicio", ls_fec_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_final", ls_fec_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fn_elimina_registro_mensajeria2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"pkg_IVOMENSAJERIA.sp_borra_dato_comprobante", 10, _
    '                                                      ls_nro_documento, 2, _
    '                                                      ll_idusuario_venta, 1, _
    '                                                      ls_fec_inicio, 2, _
    '                                                      ls_fec_final, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function

    Public Function fn_elimina_registro_mensajeria() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.sp_borra_dato_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("vi_documento", ls_nro_documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idusuario_personal", ll_idusuario_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fec_inicio", ls_fec_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_final", ls_fec_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fn_elimina_todos_registros_mensajeria2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"pkg_IVOMENSAJERIA.sp_borra_todos_dato", 8, _
    '                                                      ll_idusuario_venta, 1, _
    '                                                      ls_fec_inicio, 2, _
    '                                                      ls_fec_final, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function

    Public Function fn_elimina_todos_registros_mensajeria() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.sp_borra_todos_dato", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idusuario_personal", ll_idusuario_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fec_inicio", ls_fec_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_final", ls_fec_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
End Class
