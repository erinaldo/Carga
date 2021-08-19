Imports AccesoDatos
Public Class dto_configura_sistema
#Region "Variables"
    Dim MyMONTO_MINIMO_PCE As Double
    Dim My_nro_meses_linea_credito As Integer
    Dim My_idusuario_personal As Long
    Dim My_idrol As Long
    Dim My_ip As String
#End Region
#Region "Propiedad"
    Public Property idusuario_personal() As Long
        Get
            idusuario_personal = My_idusuario_personal
        End Get
        Set(ByVal value As Long)
            My_idusuario_personal = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Long
        Get
            IDROL_USUARIO = My_idrol
        End Get
        Set(ByVal value As Long)
            My_idrol = value
        End Set
    End Property
    Public Property ip() As String
        Get
            ip = My_ip
        End Get
        Set(ByVal value As String)
            My_ip = value
        End Set
    End Property
    Public Property MONTO_MINIMO_PCE() As Double
        Get
            MONTO_MINIMO_PCE = MyMONTO_MINIMO_PCE
        End Get
        Set(ByVal value As Double)
            MyMONTO_MINIMO_PCE = value
        End Set
    End Property
    Public Property nro_meses_linea_credito() As Integer
        Get
            nro_meses_linea_credito = My_nro_meses_linea_credito
        End Get
        Set(ByVal value As Integer)
            My_nro_meses_linea_credito = value
        End Set
    End Property
#End Region
#Region "Métodos"
    'Public Sub get_configura_sistema_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivoconfig_sistema.SP_get_datos_config"
    '        '-- Invocando los parametros
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("no_Monto_Minimo_Pce", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("no_nro_meses_linea_credito", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        '
    '        cmd.ExecuteNonQuery()
    '        '
    '        If Not cmd.Parameters("no_Monto_Minimo_Pce").Value Is DBNull.Value Then
    '            Me.MONTO_MINIMO_PCE = cmd.Parameters("no_Monto_Minimo_Pce").Value
    '        End If
    '        '
    '        If Not cmd.Parameters("no_nro_meses_linea_credito").Value Is DBNull.Value Then
    '            Me.nro_meses_linea_credito = cmd.Parameters("no_nro_meses_linea_credito").Value
    '        End If
    '        '---
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
    '    End Try
    'End Sub
    Public Sub get_configura_sistema()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivoconfig_sistema.SP_get_datos_config", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input            
            '
            'Variables de salidas 
            db_bd.AsignarParametro("no_Monto_Minimo_Pce", OracleClient.OracleType.Number)
            db_bd.AsignarParametro("no_nro_meses_linea_credito", OracleClient.OracleType.Number)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                Me.MONTO_MINIMO_PCE = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                Me.nro_meses_linea_credito = IIf(db_bd.Parametros(2) Is DBNull.Value, 0, db_bd.Parametros(2))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Function SP_act_configuracion_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivoconfig_sistema.sp_act_cofiguracion"
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_personal", OracleClient.OracleType.Number)).Value = idusuario_personal
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_ip", OracleClient.OracleType.VarChar)).Value = ip
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idrol_usuario", OracleClient.OracleType.VarChar)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_monto_minimo", OracleClient.OracleType.Number)).Value = MONTO_MINIMO_PCE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_nro_meses_lc", OracleClient.OracleType.Number)).Value = nro_meses_linea_credito
    '        '
    '        cmd.ExecuteNonQuery()
    '        '
    '        Return True

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_act_configuracion() As Boolean
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivoconfig_sistema.sp_act_cofiguracion", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input            
            db_bd.AsignarParametro("ni_idusuario_personal", idusuario_personal, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idrol_usuario", IDROL_USUARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_monto_minimo", MONTO_MINIMO_PCE, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_nro_meses_lc", nro_meses_linea_credito, OracleClient.OracleType.Number)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            Return True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function
#End Region

End Class