Imports AccesoDatos
Public Class dtoControl_Impresora

    Public v_control As Integer
    Public v_IdControl_Inpresoras As String
    Public v_Control_Inpresoras As String
    Public v_Estado_Impresion As Integer
    Public v_Idtipo_Impresora As Integer

    Public rst_cur_datos As New ADODB.Recordset
    'Public Function fnGetTipo_Impresora2009() As ADODB.Recordset
    '    Dim SQLQuery As Object() = {"PKG_UTILITARIOS.SP_CONTROL_INIT_IMPRESORAS", 6, 1, 1, dtoUSUARIOS.m_sIP, 2}
    '    'Dim rst_cur_datos As New ADODB.Recordset
    '    'rst_cur_datos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Return VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'End Function

    Public Function fnGetTipo_Impresora() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_UTILITARIOS.SP_CONTROL_INIT_IMPRESORAS", CommandType.StoredProcedure)
            db.AsignarParametro("iControl", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IP", dtoUSUARIOS.m_sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_TIPO_IMPRESORAS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnINSUP_CONTRO_IMPRESORAS2009() As ADODB.Recordset
    '    Dim SQLQuery As Object() = {"PKG_UTILITARIOS.SP_INSUP_CONTRO_IMPRESORAS", 16, v_control, 1, v_IdControl_Inpresoras, 2, v_Control_Inpresoras, 2, dtoUSUARIOS.m_sIP, 2, dtoUSUARIOS.IdLogin, 1, 1, 1, v_Idtipo_Impresora, 1}
    '    'rst_cur_datos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Return VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'End Function

    Public Function fnINSUP_CONTRO_IMPRESORAS() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_UTILITARIOS.SP_INSUP_CONTRO_IMPRESORAS", CommandType.StoredProcedure)
            db.AsignarParametro("v_control", v_control, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IdControl_Inpresoras", v_IdControl_Inpresoras, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Control_Inpresoras", v_Control_Inpresoras, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_ip", dtoUSUARIOS.m_sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idUsuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Estado_Impresion", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_Idtipo_Impresora", v_Idtipo_Impresora, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
