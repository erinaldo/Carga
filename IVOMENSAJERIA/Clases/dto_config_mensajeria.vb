Imports AccesoDatos
Public Class dtoConfig_mensajeria
#Region "Variables"
    Dim Mycontrol As Long
    Dim MyIDCONFIG_TXT_MSG As Long
    Dim MyTXT_MSG_CONSOLIDADO_CAB As String
    Dim MyTXT_MSG_CONSOLIDADO As String
    Dim MyTXT_MSG_EMAIL_CAB As String
    Dim MyTXT_MSG_EMAIL As String
    Dim MyTXT_MSG_MOVIL As String
    Dim MyIP As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDESTADO_ENVIO As Long
#End Region
#Region "Get y Set"
    Public Property _Mycontrol() As Long
        Get
            Return Mycontrol
        End Get
        Set(ByVal value As Long)
            Mycontrol = value
        End Set
    End Property
    Public Property _MyIDCONFIG_TXT_MSG() As Long
        Get
            Return MyIDCONFIG_TXT_MSG
        End Get
        Set(ByVal value As Long)
            MyIDCONFIG_TXT_MSG = value
        End Set
    End Property
    Public Property _MyTXT_MSG_CONSOLIDADO_CAB() As String
        Get
            Return MyTXT_MSG_CONSOLIDADO_CAB
        End Get
        Set(ByVal value As String)
            MyTXT_MSG_CONSOLIDADO_CAB = value
        End Set
    End Property

    Public Property _MyTXT_MSG_CONSOLIDADO() As String
        Get
            Return MyTXT_MSG_CONSOLIDADO
        End Get
        Set(ByVal value As String)
            MyTXT_MSG_CONSOLIDADO = value
        End Set
    End Property
    Public Property _MyTXT_MSG_MOVIL() As String
        Get
            Return MyTXT_MSG_MOVIL
        End Get
        Set(ByVal value As String)
            MyTXT_MSG_MOVIL = value
        End Set
    End Property
    Public Property _MyTXT_MSG_EMAIL_CAB() As String
        Get
            Return MyTXT_MSG_EMAIL_CAB
        End Get
        Set(ByVal value As String)
            MyTXT_MSG_EMAIL_CAB = value
        End Set
    End Property
    Public Property _MyTXT_MSG_EMAIL() As String
        Get
            Return MyTXT_MSG_EMAIL
        End Get
        Set(ByVal value As String)
            MyTXT_MSG_EMAIL = value
        End Set
    End Property
    Public Property _MyIP() As String
        Get
            Return MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
    Public Property _MyIDUSUARIO_PERSONAL() As Long
        Get
            Return MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property _MyIDESTADO_REGISTRO() As Long
        Get
            Return MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    Public Property _MyIDESTADO_ENVIO() As Long
        Get
            Return MyIDESTADO_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_ENVIO = value
        End Set
    End Property
#End Region
#Region "Funciones y Procedimientos"

    'Public Function fn_Listar_Config_mensajeria2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"pk_ivomensajeria_2.sp_lista_config_mensajeria", 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_Listar_Config_mensajeria() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pk_ivomensajeria_2.sp_lista_config_mensajeria", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_estado_envio", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_parametros_msg", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_recupera_config", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_recupera_parametro_xestado_envio2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"pk_ivomensajeria_2.sp_obt_parametro_xestado_envio", 4, _
    '                                                                     MyIDESTADO_ENVIO, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_recupera_parametro_xestado_envio() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pk_ivomensajeria_2.sp_obt_parametro_xestado_envio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado_envio", MyIDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_parametro", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_datos_config_mensajeria", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_grabar_Config_mensajeria2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"pk_ivomensajeria_2.sp_graba_config_mensaje", 24, _
    '                                    Mycontrol, 1, _
    '                                    MyIDCONFIG_TXT_MSG, 1, _
    '                                    MyTXT_MSG_MOVIL, 2, _
    '                                    MyTXT_MSG_EMAIL, 2, _
    '                                    MyTXT_MSG_EMAIL_CAB, 2, _
    '                                    MyTXT_MSG_CONSOLIDADO_CAB, 2, _
    '                                    MyTXT_MSG_CONSOLIDADO, 2, _
    '                                    MyIDESTADO_ENVIO, 1, _
    '                                    MyIDUSUARIO_PERSONAL, 1, _
    '                                    MyIDESTADO_REGISTRO, 1, _
    '                                    MyIP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_grabar_Config_mensajeria() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pk_ivomensajeria_2.sp_graba_config_mensaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_control", Mycontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idconfig_txt_msg", MyIDCONFIG_TXT_MSG, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_txt_msg_movil", MyTXT_MSG_MOVIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_txt_msg_email", MyTXT_MSG_EMAIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_txt_msg_email_cab", MyTXT_MSG_EMAIL_CAB, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_txt_msg_consolidado_cab", MyTXT_MSG_CONSOLIDADO_CAB, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_txt_msg_consolidado", MyTXT_MSG_CONSOLIDADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idestado_envio", MyIDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idusuario_personal", MyIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idestado_registro", MyIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", MyIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_recupera_config", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_recupera_datos_config_mensajeria2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"pk_ivomensajeria_2.sp_obt_datos_config_mensajeria", 4, _
    '                                                                  MyIDESTADO_ENVIO, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function fn_recupera_datos_config_mensajeria() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pk_ivomensajeria_2.sp_obt_datos_config_mensajeria", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado_envio", MyIDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_datos_config_mensajeria", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class