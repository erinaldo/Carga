Imports AccesoDatos
Imports System.Data.Odbc

Public Class dtoWebService
    Dim cnn As OdbcConnection '-> Conexion Mysql

    'Dim rst_WS As New ADODB.Recordset
    Dim rst_NroClaro As DataTable

    'Dim rst_Mensajes As New ADODB.Recordset
    'Dim rst_Datos As New ADODB.Recordset
    Dim rst_Llegada As DataTable

    Dim Msgbox_control As String = ""
    Dim Celular_control As String = ""
    Public WSMsg As New WSclaro.SWPush()
    Dim LicenseKey As String = ""
    Public m_idTipo_Comprobante As Integer
    Public m_idComprobante As String

    'Public Function fnWebService_2009(ByVal x_idTipo_Comprobante As Integer, ByVal x_idComprobante As String, ByVal x_Estado As Integer) As Boolean
    'Dim strSW As String = "0000"
    'Try
    '    '3:          CEL(CLARO)
    '    '6:          CEL(TELEFONICA)
    '    '2:          FAX()
    '    '5:          NEXTEL()
    '    '4:          RPM()
    '    '1:          TELEFONO()
    '    Dim varSP_OBJECT() As Object = {"SP_CONTROL_MSG_MOVIL", 10, x_idTipo_Comprobante, 1, x_idComprobante, 2, x_Estado, 1, 3, 1}
    '    rst_Mensajes = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_Mensajes.Fields.Count > 0 Then
    '        If rst_Mensajes.EOF = False And rst_Mensajes.BOF = False Then
    '            Msgbox_control = rst_Mensajes.Fields.Item("MSG_CELULAR").Value.ToString()
    '            rst_NroClaro = rst_Mensajes.NextRecordset
    '            Celular_control = ""
    '            While rst_NroClaro.BOF = False And rst_NroClaro.EOF = False
    '                If Celular_control = "" Then
    '                    Celular_control = rst_NroClaro.Fields.Item("NRO_MOVIL").Value.ToString()
    '                Else
    '                    Celular_control = Celular_control & vbCrLf & rst_NroClaro.Fields.Item("NRO_MOVIL").Value.ToString()
    '                End If
    '                rst_NroClaro.MoveNext()
    '            End While
    '        End If
    '        LicenseKey = fnMD5("E90110")
    '        Dim fecha As Date = dtoUSUARIOS.m_sFecha
    '        Dim strvar As String = WSMsg.RecibirMensajes("E90110", LicenseKey, Msgbox_control & vbCrLf & Celular_control, fecha, 1)
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return False
    'End Function
    Public Function fnWebService(ByVal x_idTipo_Comprobante As Integer, ByVal x_idComprobante As String, ByVal x_Estado As Integer) As Boolean
        Dim strSW As String = "0000"
        '3:          CEL(CLARO)
        '6:          CEL(TELEFONICA)
        '2:          FAX()
        '5:          NEXTEL()
        '4:          RPM()
        '1:          TELEFONO()
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            Dim li_idtipo_movil As Integer = 3 ' Para Claro 
            'conecta con la Bd                    
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            'db_bd.CrearComando("SP_CONTROL_MSG_MOVIL", CommandType.Text)
            db_bd.CrearComando("SP_CONTROL_MSG_MOVIL_DH", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", x_idTipo_Comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_IDCOMPROBANTE", x_idComprobante, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_ESTADO_ENVIO", x_Estado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("V_TIPO_MOVIL", li_idtipo_movil, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_msg", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet()
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                Msgbox_control = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("MSG_CELULAR")) = True, "", lds_tmp.Tables(0).Rows(0).Item("MSG_CELULAR").ToString())
                If Msgbox_control = "" Then
                    Return False
                End If
                Celular_control = ""
                If lds_tmp.Tables(1).Rows.Count > 0 Then
                    For Each row As DataRow In lds_tmp.Tables(1).Rows
                        If Celular_control = "" Then
                            Celular_control = row.Item("NRO_MOVIL").ToString()
                        Else
                            Celular_control = Celular_control & vbCrLf & row.Item("NRO_MOVIL").ToString()
                        End If
                    Next
                End If
                ' Enviado a claro
                LicenseKey = fnMD5("E90110")
                Dim fecha As Date = dtoUSUARIOS.m_sFecha
                '
                'Comentado - 20/11/2009 para lo que es claro
                'Dim strvar As String = WSMsg.RecibirMensajes("E90110", LicenseKey, Msgbox_control & vbCrLf & Celular_control, fecha, 1)
                '                 
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return False
    End Function
    '    Public Function fnWebServiceLlegada2009(ByVal x_idGuia_Trans_Detall As String) As Boolean
    'Try
    '    Dim varSP_OBJECT() As Object = {"SP_MSG_LLEGADA_WS", 4, x_idGuia_Trans_Detall.ToString(), 2}
    '    rst_Llegada = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_Llegada.EOF = False And rst_Llegada.BOF = False Then
    '        Msgbox_control = rst_Llegada.Fields.Item("MSG_CELULAR").Value.ToString()
    '        rst_NroClaro = rst_Llegada.NextRecordset
    '        Celular_control = ""
    '        While rst_NroClaro.BOF = False And rst_NroClaro.EOF = False
    '            If Celular_control = "" Then
    '                Celular_control = rst_NroClaro.Fields.Item("NRO_MOVIL").Value.ToString()
    '            Else
    '                Celular_control = Celular_control & vbCrLf & rst_NroClaro.Fields.Item("NRO_MOVIL").Value.ToString()
    '            End If
    '            rst_NroClaro.MoveNext()
    '        End While
    '    End If
    '    LicenseKey = fnMD5("E90110")
    '    Dim fecha As Date = dtoUSUARIOS.m_sFecha
    '    Dim strvar As String = WSMsg.RecibirMensajes("E90110", LicenseKey, Msgbox_control & vbCrLf & Celular_control, fecha, 1)
    'Catch ex As Exception
    '    'MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema...")
    'End Try
    'End Function

    Public Function fnWebServiceLlegada(ByVal x_idGuia_Trans_Detall As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_MSG_LLEGADA_WS", CommandType.StoredProcedure)
            db.AsignarParametro("x_IDGUIA_TRANS_DETALL", x_idGuia_Trans_Detall.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_msg", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            rst_Llegada = ds.Tables(0)
            If rst_Llegada.Rows.Count > 0 Then
                Msgbox_control = rst_Llegada.Rows.Item("MSG_CELULAR").ToString()
                rst_NroClaro = ds.Tables(1)
                Celular_control = ""
                For Each row As DataRow In rst_NroClaro.Rows
                    If Celular_control = "" Then
                        Celular_control = row.Item("NRO_MOVIL").ToString()
                    Else
                        Celular_control = Celular_control & vbCrLf & row.Item("NRO_MOVIL").ToString()
                    End If
                Next
            End If
            LicenseKey = fnMD5("E90110")
            Dim fecha As Date = dtoUSUARIOS.m_sFecha
            Dim strvar As String = WSMsg.RecibirMensajes("E90110", LicenseKey, Msgbox_control & vbCrLf & Celular_control, fecha, 1)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            'MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema...")
        End Try
    End Function

    'Public Function fnMD52009(ByVal strCodigo As String) As String
    'Dim strSW As String = "0000"
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_MD5", 4, strCodigo, 2}
    '    rst_WS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_WS.EOF = False And rst_WS.BOF = False Then
    '        strSW = rst_WS.Fields.Item("clave").Value.ToString()
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return strSW
    'End Function

    Public Function fnMD5(ByVal strCodigo As String) As String
        Dim strSW As String = "0000"
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_MD5", CommandType.StoredProcedure)
            'db.AsignarParametro("hexkey", strCodigo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("passwd_string", strCodigo, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                strSW = dt.Rows(0).Item("clave").ToString()
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return strSW
    End Function

    Private Function ObtieneDT(ByVal sql As String) As DataTable
        Dim cmd As New OdbcCommand
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        cmd.Connection = cnn
        Dim da As New OdbcDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function


    Function Listar(fecha As String) As DataTable
        'hlamas 07-04-2014 CA coneccion a MYSQL
        'coneccion a athenea (vyr)
        'cnn = New Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=Tepsa;UID=ventas;PWD=10913035110;OPTION=18475")
        Dim dt As DataTable
        Dim sql As String

        cnn = New Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.50.51;DATABASE=ccvox-io-2-0-0-0;UID=usr_tepsa;PWD=guest321x;OPTION=18475")
        'sql = "select * from cdr where Year(fecha)='2015' And queue = 3"
        sql = "select * from cdr where fecha='" & fecha & "' And queue = 3"
        dt = ObtieneDT(sql)
        Return dt
    End Function

    Sub GrabarLLamada(id As Integer, queue As Integer, fecha As String, duration As Integer, dcontext As String, agente As Integer, clid As String, _
                  anexo As String, inicio_conversacion As String, fin_conversacion As String, uniqueid As String)
        ', queue As Integer, fecha As String, duration As Integer, dcontext As String, agente As Integer, clid As String, _
        'anexo As String, inicio_conversacion As String, fin_conversacion As String, uniqueid As String)
        Dim db As New BaseDatos

        Try
            db.Conectar()
            db.CrearComando("PKG_IVOMIGRACION_DATOS.sp_grabar_llamada", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_queue", queue, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_duration", duration, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_dcontext", dcontext, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agente", agente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_clid", clid, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_anexo", anexo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_inicio_conversacion", inicio_conversacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin_conversacion", fin_conversacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_uniqueid", uniqueid, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            'db.EjecutarComando()

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If

        Catch ex As Excepcion
            Throw New Excepcion(ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

End Class
