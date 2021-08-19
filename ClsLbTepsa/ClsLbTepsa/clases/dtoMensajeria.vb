Imports AccesoDatos
Public Class dtoMensajeria
    Inherits dtoFACTURA
    Dim Myenvio_mensageria As Long
    Dim MyIDCTRL_MSG As Long
    Dim MyENVIO_EMAIL As Long
    Dim MyENVIO_CONSOLIDADO As Long
    Dim MyIDCTRL_MSG_CLIENTE As Long
    Dim MyIDUSUARIO_PERSONAL As Long

    Dim MyIDCONFIG_TXT_MSG As Long
    Dim MyIDPERSONA As Long
    Dim MyTXT_MSG As String
    Dim MyFECHA_REGISTRO As String
    Dim MyIDTIPO_MSG_MAIL As Long
    Dim MyIP As String
    Dim MyIDPROCESOS As Long

    Dim MyIDTIPO_MSG_MOVIL As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyENVIO_MOVIL As Long
    Dim MyIDESTADO_ENVIO As Long

    Dim MyIDTIPO_COMUNICACION2 As Long
    Dim MyE_MAIL2 As String
    Dim MyNRO_MOVIL2 As String

    Dim MyIDTIPO_COMUNICACION As Long
    Dim MyE_MAIL As String
    Dim MyNRO_MOVIL As String

    Dim MyConSinMsg As Integer
    '29/10/2007
    Dim myidcentro_costo As Long
    Public Property idcentro_costo() As Long
        Get
            idcentro_costo = myidcentro_costo
        End Get
        Set(ByVal value As Long)
            myidcentro_costo = value
        End Set
    End Property
    Public Property ConSinMsg() As Integer

        Get
            ConSinMsg = MyConSinMsg
        End Get
        Set(ByVal value As Integer)
            MyConSinMsg = value
        End Set
    End Property

    Public Property envio_mensageria() As Long

        Get
            envio_mensageria = Myenvio_mensageria
        End Get
        Set(ByVal value As Long)
            Myenvio_mensageria = value
        End Set
    End Property
    Public Property IDTIPO_MSG_MAIL() As Long

        Get
            IDTIPO_MSG_MAIL = MyIDTIPO_MSG_MAIL
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_MSG_MAIL = value
        End Set
    End Property
    Public Property E_MAIL() As String
        Get
            E_MAIL = MyE_MAIL
        End Get
        Set(ByVal value As String)
            MyE_MAIL = value
        End Set
    End Property
    Public Property E_MAIL2() As String
        Get
            E_MAIL2 = MyE_MAIL2
        End Get
        Set(ByVal value As String)
            MyE_MAIL2 = value
        End Set
    End Property
    Public Property IDESTADO_ENVIO() As Long
        Get
            IDESTADO_ENVIO = MyIDESTADO_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_ENVIO = value
        End Set
    End Property
    Public Property TXT_MSG() As String
        Get
            TXT_MSG = MyTXT_MSG
        End Get
        Set(ByVal value As String)
            MyTXT_MSG = value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Long
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property IDCTRL_MSG_CLIENTE() As Long

        Get
            IDCTRL_MSG_CLIENTE = MyIDCTRL_MSG_CLIENTE
        End Get
        Set(ByVal value As Long)
            MyIDCTRL_MSG_CLIENTE = value
        End Set
    End Property
    Public Property IDTIPO_MSG_MOVIL() As Long

        Get
            IDTIPO_MSG_MOVIL = MyIDTIPO_MSG_MOVIL
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_MSG_MOVIL = value
        End Set
    End Property
    Public Property IDCONFIG_TXT_MSG() As Long

        Get
            IDCONFIG_TXT_MSG = MyIDCONFIG_TXT_MSG
        End Get
        Set(ByVal value As Long)
            MyIDCONFIG_TXT_MSG = value
        End Set
    End Property
    Public Property IDCTRL_MSG() As Long

        Get
            IDCTRL_MSG = MyIDCTRL_MSG
        End Get
        Set(ByVal value As Long)
            MyIDCTRL_MSG = value
        End Set
    End Property
    Public Property IDTIPO_COMUNICACION() As Long

        Get
            IDTIPO_COMUNICACION = MyIDTIPO_COMUNICACION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_COMUNICACION = value
        End Set
    End Property

    Public Property IDTIPO_COMUNICACION2() As Long

        Get
            IDTIPO_COMUNICACION2 = MyIDTIPO_COMUNICACION2
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_COMUNICACION2 = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Long
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDPERSONA() As Long
        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property NRO_MOVIL() As String

        Get
            NRO_MOVIL = MyNRO_MOVIL
        End Get
        Set(ByVal value As String)
            MyNRO_MOVIL = value
        End Set
    End Property

    Public Property NRO_MOVIL2() As String

        Get
            NRO_MOVIL2 = MyNRO_MOVIL2
        End Get
        Set(ByVal value As String)
            MyNRO_MOVIL2 = value
        End Set
    End Property
    Public Property IP() As String
        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
    Public Property IDPROCESOS() As Long

        Get
            IDPROCESOS = MyIDPROCESOS
        End Get
        Set(ByVal value As Long)
            MyIDPROCESOS = value
        End Set
    End Property
    Public Property ENVIO_MOVIL() As Long

        Get
            ENVIO_MOVIL = MyENVIO_MOVIL
        End Get
        Set(ByVal value As Long)
            MyENVIO_MOVIL = value
        End Set
    End Property
    Public Property ENVIO_CONSOLIDADO() As Long

        Get
            ENVIO_CONSOLIDADO = MyENVIO_CONSOLIDADO
        End Get
        Set(ByVal value As Long)
            MyENVIO_CONSOLIDADO = value
        End Set
    End Property
    Public Property ENVIO_EMAIL() As Long

        Get
            ENVIO_EMAIL = MyENVIO_EMAIL
        End Get
        Set(ByVal value As Long)
            MyENVIO_EMAIL = value
        End Set
    End Property
    'Public Sub SP_IN_T_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_T_TIPO_MSG_MAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MAIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleClient.OracleType.VarChar)).Value = E_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_UP_T_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UP_T_TIPO_MSG_MAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MAIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleClient.OracleType.VarChar)).Value = E_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_DE_T_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_DE_T_TIPO_MSG_MAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MAIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleClient.OracleType.VarChar)).Value = E_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_IN_T_CTRL_MSG_CLIENTE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_T_CTRL_MSG_CLIENTE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPROCESOS", OracleClient.OracleType.Number)).Value = IDPROCESOS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_MOVIL", OracleClient.OracleType.Number)).Value = ENVIO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_EMAIL", OracleClient.OracleType.Number)).Value = ENVIO_EMAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_DE_T_CTRL_MSG_CLIENTE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_DE_T_CTRL_MSG_CLIENTE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_DE_T_CTRL_MSG_CLIENTE()
        Dim db As New BaseDatos
        Try
            'Connectar 
            db.Conectar()
            'Invocando al procedimiento 
            db.CrearComando("pkg_IVOMENSAJERIA.SP_DE_T_CTRL_MSG_CLIENTE", CommandType.StoredProcedure)
            'Parametro Ingreso 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            'Parametro de Salida
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Sub SP_IN_T_CONFIG_TXT_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_T_CONFIG_TXT_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONFIG_TXT_MSG", OracleClient.OracleType.Number)).Value = IDCONFIG_TXT_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TXT_MSG", OracleClient.OracleType.VarChar)).Value = TXT_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_UP_T_CONFIG_TXT_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UP_T_CONFIG_TXT_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONFIG_TXT_MSG", OracleClient.OracleType.Number)).Value = IDCONFIG_TXT_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TXT_MSG", OracleClient.OracleType.VarChar)).Value = TXT_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_DE_T_CONFIG_TXT_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_DE_T_CONFIG_TXT_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONFIG_TXT_MSG", OracleClient.OracleType.Number)).Value = IDCONFIG_TXT_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TXT_MSG", OracleClient.OracleType.VarChar)).Value = TXT_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_IN_T_TIPO_MSG_MOVIL(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_T_TIPO_MSG_MOVIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MOVIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION", OracleClient.OracleType.Number)).Value = IDTIPO_COMUNICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL", OracleClient.OracleType.VarChar)).Value = NRO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_UP_T_TIPO_MSG_MOVIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UP_T_TIPO_MSG_MOVIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MOVIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION", OracleClient.OracleType.Number)).Value = IDTIPO_COMUNICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL", OracleClient.OracleType.VarChar)).Value = NRO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_DE_T_TIPO_MSG_MOVIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_DE_T_TIPO_MSG_MOVIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MOVIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION", OracleClient.OracleType.Number)).Value = IDTIPO_COMUNICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL", OracleClient.OracleType.VarChar)).Value = NRO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_IN_T_CTRL_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_T_CTRL_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG", OracleClient.OracleType.Number)).Value = IDCTRL_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPROCESOS", OracleClient.OracleType.Number)).Value = IDPROCESOS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_MOVIL", OracleClient.OracleType.Number)).Value = ENVIO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_EMAIL", OracleClient.OracleType.Number)).Value = ENVIO_EMAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_UP_T_CTRL_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UP_T_CTRL_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG", OracleClient.OracleType.Number)).Value = IDCTRL_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPROCESOS", OracleClient.OracleType.Number)).Value = IDPROCESOS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_MOVIL", OracleClient.OracleType.Number)).Value = ENVIO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_EMAIL", OracleClient.OracleType.Number)).Value = ENVIO_EMAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_UP_T_CTRL_MSG()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_UP_T_CTRL_MSG", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDCTRL_MSG", IDCTRL_MSG, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPROCESOS", IDPROCESOS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_ENVIO", IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ENVIO_MOVIL", ENVIO_MOVIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ENVIO_EMAIL", ENVIO_EMAIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_REGISTRO", FECHA_REGISTRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDESTADO_REGISTRO", IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            'Parametro Salida
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Sub SP_DE_T_CTRL_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_DE_T_CTRL_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG", OracleClient.OracleType.Number)).Value = IDCTRL_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPROCESOS", OracleClient.OracleType.Number)).Value = IDPROCESOS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_MOVIL", OracleClient.OracleType.Number)).Value = ENVIO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_EMAIL", OracleClient.OracleType.Number)).Value = ENVIO_EMAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_SELEC_T_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_TIPO_MSG_MAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MAIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_TIPO_MSG_MAIL", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("IDTIPO_MSG_MAIL") Then IDTIPO_MSG_MAIL = dv.Table.Rows(0)("IDTIPO_MSG_MAIL") Else IDTIPO_MSG_MAIL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDCTRL_MSG_CLIENTE") Then IDCTRL_MSG_CLIENTE = dv.Table.Rows(0)("IDCTRL_MSG_CLIENTE") Else IDCTRL_MSG_CLIENTE = 0
    '        If Not dv.Table.Rows(0).IsNull("E_MAIL") Then E_MAIL = dv.Table.Rows(0)("E_MAIL") Else E_MAIL = ""
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dv.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_SELEC_T_CTRL_MSG_CLIENTE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_CTRL_MSG_CLIENTE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_CTRL_MSG_CLIENTE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("IDCTRL_MSG_CLIENTE") Then IDCTRL_MSG_CLIENTE = dv.Table.Rows(0)("IDCTRL_MSG_CLIENTE") Else IDCTRL_MSG_CLIENTE = 0
    '        If Not dv.Table.Rows(0).IsNull("IDPERSONA") Then IDPERSONA = dv.Table.Rows(0)("IDPERSONA") Else IDPERSONA = 0
    '        If Not dv.Table.Rows(0).IsNull("IDPROCESOS") Then IDPROCESOS = dv.Table.Rows(0)("IDPROCESOS") Else IDPROCESOS = 0
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_ENVIO") Then IDESTADO_ENVIO = dv.Table.Rows(0)("IDESTADO_ENVIO") Else IDESTADO_ENVIO = 0
    '        If Not dv.Table.Rows(0).IsNull("ENVIO_MOVIL") Then ENVIO_MOVIL = dv.Table.Rows(0)("ENVIO_MOVIL") Else ENVIO_MOVIL = 0
    '        If Not dv.Table.Rows(0).IsNull("ENVIO_EMAIL") Then ENVIO_EMAIL = dv.Table.Rows(0)("ENVIO_EMAIL") Else ENVIO_EMAIL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '        If Not dv.Table.Rows(0).IsNull("IP") Then IP = dv.Table.Rows(0)("IP") Else IP = ""
    '        If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dv.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_SELEC_T_CONFIG_TXT_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_CONFIG_TXT_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONFIG_TXT_MSG", OracleClient.OracleType.Number)).Value = IDCONFIG_TXT_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_CONFIG_TXT_MSG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("IDCONFIG_TXT_MSG") Then IDCONFIG_TXT_MSG = dv.Table.Rows(0)("IDCONFIG_TXT_MSG") Else IDCONFIG_TXT_MSG = 0
    '        If Not dv.Table.Rows(0).IsNull("TXT_MSG") Then TXT_MSG = dv.Table.Rows(0)("TXT_MSG") Else TXT_MSG = ""
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_ENVIO") Then IDESTADO_ENVIO = dv.Table.Rows(0)("IDESTADO_ENVIO") Else IDESTADO_ENVIO = 0
    '        If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dv.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '        If Not dv.Table.Rows(0).IsNull("IP") Then IP = dv.Table.Rows(0)("IP") Else IP = ""
    '        If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_SELEC_T_TIPO_MSG_MOVIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_TIPO_MSG_MOVIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MOVIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_TIPO_MSG_MOVIL", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("IDTIPO_MSG_MOVIL") Then IDTIPO_MSG_MOVIL = dv.Table.Rows(0)("IDTIPO_MSG_MOVIL") Else IDTIPO_MSG_MOVIL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDCTRL_MSG_CLIENTE") Then IDCTRL_MSG_CLIENTE = dv.Table.Rows(0)("IDCTRL_MSG_CLIENTE") Else IDCTRL_MSG_CLIENTE = 0
    '        If Not dv.Table.Rows(0).IsNull("IDTIPO_COMUNICACION") Then IDTIPO_COMUNICACION = dv.Table.Rows(0)("IDTIPO_COMUNICACION") Else IDTIPO_COMUNICACION = 0
    '        If Not dv.Table.Rows(0).IsNull("NRO_MOVIL") Then NRO_MOVIL = dv.Table.Rows(0)("NRO_MOVIL") Else NRO_MOVIL = ""
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dv.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_SELEC_T_CTRL_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_CTRL_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG", OracleClient.OracleType.Number)).Value = IDCTRL_MSG
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_CTRL_MSG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("IDCTRL_MSG") Then IDCTRL_MSG = dv.Table.Rows(0)("IDCTRL_MSG") Else IDCTRL_MSG = 0
    '        If Not dv.Table.Rows(0).IsNull("IDPROCESOS") Then IDPROCESOS = dv.Table.Rows(0)("IDPROCESOS") Else IDPROCESOS = 0
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_ENVIO") Then IDESTADO_ENVIO = dv.Table.Rows(0)("IDESTADO_ENVIO") Else IDESTADO_ENVIO = 0
    '        If Not dv.Table.Rows(0).IsNull("ENVIO_MOVIL") Then ENVIO_MOVIL = dv.Table.Rows(0)("ENVIO_MOVIL") Else ENVIO_MOVIL = 0
    '        If Not dv.Table.Rows(0).IsNull("ENVIO_EMAIL") Then ENVIO_EMAIL = dv.Table.Rows(0)("ENVIO_EMAIL") Else ENVIO_EMAIL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '        If Not dv.Table.Rows(0).IsNull("IP") Then IP = dv.Table.Rows(0)("IP") Else IP = ""
    '        If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '        If Not dv.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dv.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '    Catch
    '        Throw
    '    End Try

    'End Sub
    'Public Function F_LISTAR_T_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_TIPO_MSG_MAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_TIPO_MSG_MAIL", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function

    'Public Function F_LISTAR_T_CTRL_MSG_CLIENTE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_CTRL_MSG_CLIENTE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_CTRL_MSG_CLIENTE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    'Public Function F_LISTAR_T_CONFIG_TXT_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_CONFIG_TXT_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_CONFIG_TXT_MSG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    'Public Function F_LISTAR_T_TIPO_MSG_MOVIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_TIPO_MSG_MOVIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_TIPO_MSG_MOVIL", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    'Public Function F_LISTAR_T_CTRL_MSG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DE_T_CTRL_MSG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_T_CTRL_MSG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    'Public Function SP_LISTAR_ESTADOS_ENVIO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivomensajeria.SP_LISTAR_ESTADOS_ENVIO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPROCESOS", OracleClient.OracleType.Number)).Value = IDPROCESOS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_ESTADOS_ENVIO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_LISTAR_ESTADOS_ENVIO() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_ivomensajeria.SP_LISTAR_ESTADOS_ENVIO", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDPROCESOS", IDPROCESOS, OracleClient.OracleType.Int16)
            'Parametro Salida
            db.AsignarParametro("CUR_LISTAR_ESTADOS_ENVIO", OracleClient.OracleType.Cursor)
            'Desconnectar
            db.Desconectar()
            '
            Return db.EjecutarDataTable().DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LISTAR_EST_ENVIO_PERSONA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        'cmd.CommandText = "pkg_ivomensajeria.SP_LISTAR_EST_ENVIO_PERSONA"
    '        cmd.CommandText = "pkg_ivomensajeria.LIS_EST_ENVIO_PERSONA_SUBCTA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPROCESOS", OracleClient.OracleType.Number)).Value = IDPROCESOS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_MOVIL", OracleClient.OracleType.Number)).Value = ENVIO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_EMAIL", OracleClient.OracleType.Number)).Value = ENVIO_EMAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = idcentro_costo
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_CTRL_MSG_CLIENTE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_LISTAR_EST_ENVIO_PERSONA() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_ivomensajeria.LIS_EST_ENVIO_PERSONA_SUBCTA", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDCTRL_MSG_CLIENTE", IDCTRL_MSG_CLIENTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPROCESOS", IDPROCESOS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_ENVIO", IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ENVIO_MOVIL", ENVIO_MOVIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ENVIO_EMAIL", ENVIO_EMAIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_REGISTRO", FECHA_REGISTRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDESTADO_REGISTRO", IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCENTRO_COSTO", idcentro_costo, OracleClient.OracleType.Int32)
            'Parametro Salida
            db.AsignarParametro("CUR_CTRL_MSG_CLIENTE", OracleClient.OracleType.Cursor)
            'Desconnectar
            db.Desconectar()
            '
            Return db.EjecutarDataTable().DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LISTAR_T_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        '
    '        '19/10/2007 
    '        '
    '        'cmd.CommandText = "pkg_ivomensajeria.SP_LISTAR_T_TIPO_MSG_MAIL"
    '        cmd.CommandText = "pkg_ivomensajeria.SP_LISTAR_TIPO_MSG_MAIL_SUBCTA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = idcentro_costo
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_T_TIPO_MSG_MAIL", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_LISTAR_T_TIPO_MSG_MAIL() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_ivomensajeria.SP_LISTAR_TIPO_MSG_MAIL_SUBCTA", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCENTRO_COSTO", idcentro_costo, OracleClient.OracleType.Int32)
            'Parametro Salida
            db.AsignarParametro("CUR_T_TIPO_MSG_MAIL", OracleClient.OracleType.Cursor)
            'Desconnectar
            db.Desconectar()
            '
            Return db.EjecutarDataTable().DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LISTAR_T_TIPO_MSG_MOVIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        '29/10/2007
    '        'cmd.CommandText = "pkg_ivomensajeria.SP_LISTAR_T_TIPO_MSG_MOVIL"
    '        cmd.CommandText = "pkg_ivomensajeria.SP_LISTAR_TIP_MSG_MOVIL_SUBCTA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = idcentro_costo
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_T_TIPO_MSG_MOVIL", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_LISTAR_T_TIPO_MSG_MOVIL() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_ivomensajeria.SP_LISTAR_TIP_MSG_MOVIL_SUBCTA", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCENTRO_COSTO", idcentro_costo, OracleClient.OracleType.Int32)
            'Parametro Salida
            db.AsignarParametro("CUR_T_TIPO_MSG_MOVIL", OracleClient.OracleType.Cursor)
            'Desconnectar
            db.Desconectar()
            '
            Return db.EjecutarDataTable().DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_UP_T_CTRL_MSG_CLIENTE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UP_T_CTRL_MSG_CLIENTE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCTRL_MSG_CLIENTE", OracleClient.OracleType.Number)).Value = IDCTRL_MSG_CLIENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPROCESOS", OracleClient.OracleType.Number)).Value = IDPROCESOS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_MOVIL", OracleClient.OracleType.Number)).Value = ENVIO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_EMAIL", OracleClient.OracleType.Number)).Value = ENVIO_EMAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_CONSOLIDADO", OracleClient.OracleType.Number)).Value = ENVIO_CONSOLIDADO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()

    '    Catch Ox As OracleClient.OracleException
    '        MsgBox(Ox.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_UP_T_CTRL_MSG_CLIENTE()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_UP_T_CTRL_MSG_CLIENTE", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDCTRL_MSG_CLIENTE", IDCTRL_MSG_CLIENTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPROCESOS", IDPROCESOS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_ENVIO", IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ENVIO_MOVIL", ENVIO_MOVIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ENVIO_EMAIL", ENVIO_EMAIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ENVIO_CONSOLIDADO", ENVIO_CONSOLIDADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_REGISTRO", FECHA_REGISTRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDESTADO_REGISTRO", IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            'Parametro Salida
            db.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconnectar
            db.Desconectar()
        End Try
    End Sub
    'Public Sub SP_IN_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_TIPO_MSG_MAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MAIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleClient.OracleType.VarChar)).Value = E_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_IN_TIPO_MSG_MOVIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        ' cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_TIPO_MSG_MOVIL"
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_TIPO_MSG_MOVIL_SUBCTA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL", OracleClient.OracleType.VarChar)).Value = NRO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MOVIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION", OracleClient.OracleType.Number)).Value = IDTIPO_COMUNICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = idcentro_costo
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_IN_TIPO_MSG_MOVIL()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_IN_TIPO_MSG_MOVIL_SUBCTA", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_NRO_MOVIL", NRO_MOVIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDESTADO_REGISTRO", IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_MSG_MOVIL", IDTIPO_MSG_MOVIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_COMUNICACION", IDTIPO_COMUNICACION, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCENTRO_COSTO", idcentro_costo, OracleClient.OracleType.Int32)

            'Parametro Salida
            '
            db.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconnectar
            db.Desconectar()
        End Try
    End Sub
    'Public Sub SP_DE_TIPO_MSG_MAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_DE_TIPO_MSG_MAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MAIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MAIL
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_DE_TIPO_MSG_MAIL()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_DE_TIPO_MSG_MAIL", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDTIPO_MSG_MAIL", IDTIPO_MSG_MAIL, OracleClient.OracleType.Int32)
            'Parametro Salida
            '
            db.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconnectar
            db.Desconectar()
        End Try
    End Sub
    'Public Sub SP_DE_TIPO_MSG_MOVIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_DE_TIPO_MSG_MOVIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MOVIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MOVIL
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_DE_TIPO_MSG_MOVIL()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_DE_TIPO_MSG_MOVIL", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDTIPO_MSG_MOVIL", IDTIPO_MSG_MOVIL, OracleClient.OracleType.Int32)
            'Parametro Salida
            '
            db.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconnectar
            db.Desconectar()
        End Try
    End Sub
    'Public Function FN_cmb_listar_tipo_comunicacion_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_IVOMENSAJERIA.sp_listar_tipo_comunicacion"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_listar_tipo_comunicacion", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)


    '    Dim dv As New DataView


    '    Try

    '        dv = ds.Tables(0).DefaultView


    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "TIPO_COMUNICACION"
    '            .ValueMember = "IDTIPO_COMUNICACION"
    '        End With

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_cmb_listar_tipo_comunicacion(ByVal Cmb As System.Windows.Forms.ComboBox) As DataView
        Try
            Dim db As New BaseDatos
            Dim lds_tmp As New DataSet
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.sp_listar_tipo_comunicacion", CommandType.StoredProcedure)
            '
            db.AsignarParametro("cur_listar_tipo_comunicacion", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
            With Cmb
                .DataSource = lds_tmp.Tables(0).DefaultView
                .DisplayMember = "TIPO_COMUNICACION"
                .ValueMember = "IDTIPO_COMUNICACION"
            End With
            Return lds_tmp.Tables(0).DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function SP_SI_ENVIO_MENSAJERIA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_SI_ENVIO_MENSAJERIA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_SI_ENVIO_MENSAJERIA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)

    '        Return ds.Tables(0).DefaultView

    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_SI_ENVIO_MENSAJERIA() As DataView
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_SI_ENVIO_MENSAJERIA", CommandType.StoredProcedure)
            'Asigna Parametros 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            'Parametro Salida
            db.AsignarParametro("CUR_SI_ENVIO_MENSAJERIA", OracleClient.OracleType.Cursor)
            '
            Return db.EjecutarDataTable.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconnectar
            db.Desconectar()
        End Try
    End Function
    'Public Sub SP_UP_SI_ENVIO_MENSAJERIA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UP_SI_ENVIO_MENSAJERIA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_envio_mensageria", OracleClient.OracleType.Number)).Value = envio_mensageria
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_UP_SI_ENVIO_MENSAJERIA()
        Dim db As New BaseDatos
        Try
            'Connectar 
            db.Conectar()
            'Invocando al procedimiento 
            db.CrearComando("pkg_IVOMENSAJERIA.SP_UP_SI_ENVIO_MENSAJERIA", CommandType.StoredProcedure)
            'Parametro Ingreso 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_envio_mensageria", envio_mensageria, OracleClient.OracleType.Int32)
            'Parametro de Salida
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Sub SP_SELEC_MOVIL_EMAIL_PERSO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_SELEC_MOVIL_EMAIL_PERSO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENVIO_MENSAGERIA", OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleType.VarChar, 60)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL", OracleType.VarChar, 15)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION", OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()
    '        If Not cmd.Parameters("P_ENVIO_MENSAGERIA").Value = Nothing Then
    '            envio_mensageria = cmd.Parameters("P_ENVIO_MENSAGERIA").Value

    '        End If
    '        If Not cmd.Parameters("P_E_MAIL").Value Is DBNull.Value Then
    '            E_MAIL = cmd.Parameters("P_E_MAIL").Value
    '        End If
    '        If Not cmd.Parameters("P_NRO_MOVIL").Value Is DBNull.Value Then
    '            NRO_MOVIL = cmd.Parameters("P_NRO_MOVIL").Value
    '        End If
    '        If Not cmd.Parameters("P_IDTIPO_COMUNICACION").Value Is DBNull.Value Then
    '            IDTIPO_COMUNICACION = cmd.Parameters("P_IDTIPO_COMUNICACION").Value
    '        End If
    '        If Not cmd.Parameters("P_ENVIO_MENSAGERIA").Value Is DBNull.Value Then
    '            envio_mensageria = cmd.Parameters("P_ENVIO_MENSAGERIA").Value
    '        End If

    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_SELEC_MOVIL_EMAIL_PERSO()
        Dim db As New BaseDatos
        Try
            'Connectar 
            db.Conectar()
            'Invocando al procedimiento 
            db.CrearComando("pkg_IVOMENSAJERIA.SP_SELEC_MOVIL_EMAIL_PERSO", CommandType.StoredProcedure)
            'Parametro Ingreso 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            'Parametro de Salida
            db.AsignarParametro("P_ENVIO_MENSAGERIA", OracleClient.OracleType.Int32, ParameterDirection.Output)
            db.AsignarParametro("P_E_MAIL", 60, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("P_NRO_MOVIL", 15, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("P_IDTIPO_COMUNICACION", OracleClient.OracleType.Int32, ParameterDirection.Output)
            db.EjecutarComando()
            If db.Parametros.Length > 0 Then
                envio_mensageria = IIf(db.Parametros(1) Is DBNull.Value, "", db.Parametros(1))
                E_MAIL = IIf(db.Parametros(2) Is DBNull.Value, "", db.Parametros(2))
                NRO_MOVIL = IIf(db.Parametros(3) Is DBNull.Value, "", db.Parametros(3))
                IDTIPO_COMUNICACION = IIf(db.Parametros(4) Is DBNull.Value, "", db.Parametros(4))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    'Public Sub SP_UPDATE_MOVIL_EMAIL_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UPDATE_MOVIL_EMAIL"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleType.VarChar)).Value = E_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL", OracleType.VarChar)).Value = NRO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION", OracleType.VarChar)).Value = IDTIPO_COMUNICACION
    '        cmd.ExecuteNonQuery()
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_UPDATE_MOVIL_EMAIL()
        Dim db As New BaseDatos
        Try
            'Connectar 
            db.Conectar()
            'Invocando al procedimiento 
            db.CrearComando("pkg_IVOMENSAJERIA.SP_UPDATE_MOVIL_EMAIL", CommandType.StoredProcedure)
            'Parametro Ingreso 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_E_MAIL", E_MAIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRO_MOVIL", NRO_MOVIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_COMUNICACION", IDTIPO_COMUNICACION, OracleClient.OracleType.VarChar)
            'Parametro de Salida
            '
            db.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Function SP_CONSUL_SOLICI_ENVIO_MENSA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_CONSUL_SOLICI_ENVIO_MENSA"

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_ConSinMsg", OracleClient.OracleType.Int16)).Value = ConSinMsg
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_comunicacion", OracleClient.OracleType.Number)).Value = IDTIPO_COMUNICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idUNIDAD_ORIGEN", OracleClient.OracleType.Number)).Value = IDUNIDAD_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idUNIDAD_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idtipo_comprobante", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA


    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_CONSUL_SOLICI_ENVIO_MENSA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)

    '        Return ds.Tables(0).DefaultView

    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_CONSUL_SOLICI_ENVIO_MENSA() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_CONSUL_SOLICI_ENVIO_MENSA", CommandType.StoredProcedure)
            db.AsignarParametro("p_ConSinMsg", ConSinMsg, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idtipo_comunicacion", IDTIPO_COMUNICACION, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Number)
            db.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Number)
            db.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_CONSUL_SOLICI_ENVIO_MENSA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_SELEC_MOVIL_EMAIL_PERSOII_2009(ByRef DV_EMAIL As DataView, ByRef DV_MOVIL As DataView, ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try

    '        DV_EMAIL = New DataView
    '        DV_MOVIL = New DataView

    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_SELEC_MOVIL_EMAIL_PERSOII"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_SELEC_MOVIL_PERSOII", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_SELEC_MAIL_PERSOII", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)


    '        DV_MOVIL = ds.Tables("table").DefaultView
    '        DV_EMAIL = ds.Tables("table1").DefaultView



    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_SELEC_MOVIL_EMAIL_PERSOII(ByRef DV_EMAIL As DataView, ByRef DV_MOVIL As DataView)
        Try
            DV_EMAIL = New DataView
            DV_MOVIL = New DataView
            '
            Dim db As New BaseDatos
            Dim lds_tmp As New DataSet
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_SELEC_MOVIL_EMAIL_PERSOII", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            'Asigna Parametros de Salida
            db.AsignarParametro("cur_SELEC_MOVIL_PERSOII", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_SELEC_MAIL_PERSOII", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
            '
            DV_MOVIL = lds_tmp.Tables(0).DefaultView
            DV_EMAIL = lds_tmp.Tables(1).DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_UPDATE_MOVIL_EMAILII_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_UPDATE_MOVIL_EMAILII"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleType.VarChar)).Value = E_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL", OracleType.VarChar)).Value = NRO_MOVIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION", OracleType.VarChar)).Value = IDTIPO_COMUNICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL2", OracleType.VarChar)).Value = E_MAIL2
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_MOVIL2", OracleType.VarChar)).Value = NRO_MOVIL2
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMUNICACION2", OracleType.VarChar)).Value = IDTIPO_COMUNICACION2
    '        cmd.ExecuteNonQuery()
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_UPDATE_MOVIL_EMAILII()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_UPDATE_MOVIL_EMAILII", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_E_MAIL", E_MAIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRO_MOVIL", NRO_MOVIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_COMUNICACION", IDTIPO_COMUNICACION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_E_MAIL2", E_MAIL2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRO_MOVIL2", NRO_MOVIL2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_COMUNICACION2", IDTIPO_COMUNICACION2, OracleClient.OracleType.VarChar)
            'Asigna Parametros de Salida
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    '29/10/2007 - Recupera las sub cuenta asociada al cliente 
    'Public Function SP_recupera_centro_costo_m_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataTable
    '    Dim dt_table As New DataTable
    '    Try

    '        dt_table = New DataTable
    '        'sp_recupera_centro_costo_m(vi_idpersona in varchar2, 
    '        '                                     ocur_centro_costo out types.cursor_type)
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_recupera_centro_costo_m"
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_idpersona", OracleClient.OracleType.VarChar)).Value = CType(IDPERSONA, String)
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_centro_costo", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        daora.Fill(dt_table)
    '        Return dt_table
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_recupera_centro_costo_m() As DataTable
        Try
            Dim db As New BaseDatos
            Dim lds_tmp As New DataSet
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_recupera_centro_costo_m", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("vi_idpersona", CType(IDPERSONA, String), OracleClient.OracleType.VarChar)
            'Asigna Parametros de Salida
            db.AsignarParametro("ocur_centro_costo", OracleClient.OracleType.Cursor)
            'Desconectar
            db.Desconectar()
            Return db.EjecutarDataTable
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_IN_TIPO_MSG_MAIL_subcta_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_IVOMENSAJERIA.SP_IN_TIPO_MSG_MAIL_SUBCTA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MSG_MAIL", OracleClient.OracleType.Number)).Value = IDTIPO_MSG_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_E_MAIL", OracleClient.OracleType.VarChar)).Value = E_MAIL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = idcentro_costo
    '        '
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_IN_TIPO_MSG_MAIL_subcta()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_IVOMENSAJERIA.SP_IN_TIPO_MSG_MAIL_SUBCTA", CommandType.StoredProcedure)
            'Parametro Entrada
            db.AsignarParametro("P_IDTIPO_MSG_MAIL", IDTIPO_MSG_MAIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_E_MAIL", E_MAIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDESTADO_REGISTRO", IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCENTRO_COSTO", idcentro_costo, OracleClient.OracleType.Int32)
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Function sp_listar_CODIGO_POSTAL_CEL_2009(ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean

    '    sp_listar_CODIGO_POSTAL_CEL = True
    '    Try
    '        Dim Rstlistar_tipo_comprobante As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.sp_listar_COD_POSTAL", 2}
    '        Rstlistar_tipo_comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rstlistar_tipo_comprobante)


    '        With Cmb
    '            .DataSource = DT.DefaultView
    '            .DisplayMember = "DEPARTAMENTO"
    '            .ValueMember = "COD_POSTAL"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        sp_listar_CODIGO_POSTAL_CEL = False
    '    End Try
    'End Function
    Public Function sp_listar_CODIGO_POSTAL_CEL(ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        sp_listar_CODIGO_POSTAL_CEL = True
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_listar_COD_POSTAL", CommandType.StoredProcedure)
            '
            db.AsignarParametro("cur_sp_listar_COD_POSTAL", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataSet.Tables(0).DefaultView
                .DisplayMember = "DEPARTAMENTO"
                .ValueMember = "COD_POSTAL"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Sub GrabarSMSMotivo(ByVal tipo As Integer, ByVal comprobante As Integer, ByVal motivo As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOSMS.sp_grabar_sms_motivo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_motivo", motivo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub GrabarNumeroSMS(tipo As Integer, comprobante As Integer, numero As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOSMS.sp_grabar_numero_sms", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function Listar(ByVal fecha_inicio As String, ByVal fecha_fin As String, ByVal cliente As Integer, ByVal tipo As Integer, ByVal origen As Integer, ByVal agencia_origen As Integer, _
                    ByVal destino As Integer, ByVal tipo_entrega As Integer, ByVal forma_pago As Integer, ByVal opcion As Integer, ByVal estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOSMS.sp_listar", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha_inicio", fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_fin", fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_origen", agencia_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_entrega", tipo_entrega, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_forma_pago", forma_pago, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
End Class
