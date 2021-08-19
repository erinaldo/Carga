Imports AccesoDatos
Public Class dtoCTRL_MSG_CLIENTE
    Public V_ICONTROL As Integer
    Public v_IDCTRL_MSG_CLIENTE As String
    Public v_IDPERSONA As String
    Public v_IDPROCESOS As Integer
    Public v_IDESTADO_ENVIO As Integer
    Public v_ENVIO_MOVIL As Integer
    Public v_ENVIO_EMAIL As Integer
    Public v_ENVIO_CONSOLIDADO As Integer
    Public v_IDESTADO_REGISTRO As Integer
    '------------------------------------------------------------------------------
    Public v_Idtipo_Msg_Movil As String
    Public v_NRO_MOVIL As String
    Public v_IDTIPO_COMUNICACION As Integer
    '-------------------------------------------------------------------------------
    Public v_IDTIPO_MSG_MAIL As String
    Public v_E_MAIL As String
    '------------------------------------------------------------------------------
    '
    'Public cur_datos As New ADODB.Recordset
    '
    'Public Function fnISNUP_CTRL_MSG_CLIENTE_2009() As Boolean
    '    Try
    '        Dim varSP_OBJECT() As Object = {"SP_ISNUP_CTRL_MSG_CLIENTE", 34, V_ICONTROL, 1, v_IDCTRL_MSG_CLIENTE, 2, v_IDPERSONA, 2, v_IDPROCESOS, 1, v_IDESTADO_ENVIO, 1, v_ENVIO_MOVIL, 1, v_ENVIO_EMAIL, 1, v_ENVIO_CONSOLIDADO, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, v_IDESTADO_REGISTRO, 1, v_Idtipo_Msg_Movil, 2, v_NRO_MOVIL, 2, v_IDTIPO_COMUNICACION, 1, v_IDTIPO_MSG_MAIL, 2, v_E_MAIL, 2}
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            v_IDCTRL_MSG_CLIENTE = cur_datos.Fields.Item("v_IDCTRL").Value
    '            v_Idtipo_Msg_Movil = cur_datos.Fields.Item("v_IDTIPO_MOVIL").Value
    '            v_IDTIPO_MSG_MAIL = cur_datos.Fields.Item("v_IDTIPO_MAIL").Value
    '        End If
    '    Catch ex As Exception
    '        '
    '    End Try
    'End Function
    Public Function fnISNUP_CTRL_MSG_CLIENTE() As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable

            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("SP_ISNUP_CTRL_MSG_CLIENTE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("V_ICONTROL", V_ICONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDCTRL_MSG_CLIENTE", v_IDCTRL_MSG_CLIENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPROCESOS", v_IDPROCESOS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDESTADO_ENVIO", v_IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ENVIO_MOVIL", v_ENVIO_MOVIL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ENVIO_EMAIL", v_ENVIO_EMAIL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ENVIO_CONSOLIDADO", v_ENVIO_CONSOLIDADO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDESTADO_REGISTRO", v_IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Idtipo_Msg_Movil", v_Idtipo_Msg_Movil, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_MOVIL", v_NRO_MOVIL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_COMUNICACION", v_IDTIPO_COMUNICACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_MSG_MAIL", v_IDTIPO_MSG_MAIL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_E_MAIL", v_E_MAIL, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                v_IDCTRL_MSG_CLIENTE = ldt_tmp.Rows(0).Item("v_IDCTRL")
                v_Idtipo_Msg_Movil = ldt_tmp.Rows(0).Item("v_IDTIPO_MOVIL")
                v_IDTIPO_MSG_MAIL = ldt_tmp.Rows(0).Item("v_IDTIPO_MAIL")

            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
