Imports AccesoDatos
Public Class dtoOpciones
    Dim MyIDPERSONA As Long
    Dim MyRANGO_MINIMO As Double
    Dim MyRANGO_MAXIMO As Double
    Dim MyPORCEN As Double

    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyMONTO_MINIMO_PCE As Double
    Dim MyMONTO_MINIMO As Double
    Dim MyFECHA_REGISTRO_ACTUALIZACION As String
    Dim MyIPMOD As String
    Dim MyFECHA_REGISTRO As String
    Dim MyPORCEN_IMPUESTO As Double
    Dim MyPORCEN_CARGA_ASE As Double
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIP As String
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyEXISTE_INFINITO As Boolean
    Public Property ExisteInfinito() As Boolean
        Get
            Return MyEXISTE_INFINITO
        End Get
        Set(ByVal value As Boolean)
            MyEXISTE_INFINITO = ExisteInfinito
        End Set
    End Property

    Public Property IDPERSONA() As Double

        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Double)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property PORCEN() As Double

        Get
            PORCEN = MyPORCEN
        End Get
        Set(ByVal value As Double)
            MyPORCEN = value
        End Set
    End Property
    Public Property RANGO_MINIMO() As Double

        Get
            RANGO_MINIMO = MyRANGO_MINIMO
        End Get
        Set(ByVal value As Double)
            MyRANGO_MINIMO = value
        End Set
    End Property
    Public Property RANGO_MAXIMO() As Double

        Get
            RANGO_MAXIMO = MyRANGO_MAXIMO
        End Get
        Set(ByVal value As Double)
            MyRANGO_MAXIMO = value
        End Set
    End Property



    Public Property FECHA_REGISTRO_ACTUALIZACION() As String

        Get
            FECHA_REGISTRO_ACTUALIZACION = MyFECHA_REGISTRO_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO_ACTUALIZACION = value
        End Set
    End Property
    Public Property PORCEN_IMPUESTO() As Double

        Get
            PORCEN_IMPUESTO = MyPORCEN_IMPUESTO
        End Get
        Set(ByVal value As Double)
            MyPORCEN_IMPUESTO = value
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
    Public Property MONTO_MINIMO() As Double

        Get
            MONTO_MINIMO = MyMONTO_MINIMO
        End Get
        Set(ByVal value As Double)
            MyMONTO_MINIMO = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Long

        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIO = value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Long

        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIOMOD = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Long

        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONALMOD = value
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
    Public Property PORCEN_CARGA_ASE() As Double

        Get
            PORCEN_CARGA_ASE = MyPORCEN_CARGA_ASE
        End Get
        Set(ByVal value As Double)
            MyPORCEN_CARGA_ASE = value
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
    Public Property IPMOD() As String

        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
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
    'Public Function SP_UP_CONFIGURACION_TITAN_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_UP_CONFIGURACION_TITAN"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.VarChar)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_MINIMO_PCE", OracleClient.OracleType.Number)).Value = MONTO_MINIMO_PCE
    '        cmd.ExecuteNonQuery()
    '        Return True
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_UP_CONFIGURACION_TITAN() As Boolean
        Dim db_bd As New BaseDatos
        Dim lb_flag As Boolean = False
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_UP_CONFIGURACION_TITAN", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_MONTO_MINIMO_PCE", MONTO_MINIMO_PCE, OracleClient.OracleType.Number)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            lb_flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return lb_flag
    End Function
    'Public Sub SP_RECUPERA_MONTO_MINIMO_PCE_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_MINI_PCE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Monto_Minimo_Pce", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()


    '        If Not cmd.Parameters("oP_Monto_Minimo_Pce").Value Is DBNull.Value Then
    '            Me.MONTO_MINIMO_PCE = cmd.Parameters("oP_Monto_Minimo_Pce").Value
    '        End If

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_RECUPERA_MONTO_MINIMO_PCE()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_MINI_PCE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("oP_Monto_Minimo_Pce", OracleClient.OracleType.Number)
            db_bd.EjecutarComando()

            If db_bd.Parametros.Length > 0 Then
                Me.MONTO_MINIMO_PCE = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Function sp_consul_montos_ca_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivocarga_asegurada.sp_consul_montos_ca"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_monto_minimo", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_consul_montos_ca", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        If Not cmd.Parameters("p_monto_minimo").Value Is DBNull.Value Then
    '            Me.MONTO_MINIMO = cmd.Parameters("p_monto_minimo").Value
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_consul_montos_ca() As DataView
        Dim db As New BaseDatos
        Dim ldt_tmp As New DataTable
        '
        'Dim dr As  = Me.ObjComando.ExecuteReader
        'Dim dt As New DataTable
        'Me.ObjComando.Parameters.Clear()
        'dt.Load(dr)
        'Return dt
        Try
            db.Conectar()
            '
            db.CrearComando("pkg_ivocarga_asegurada.sp_consul_montos_ca", CommandType.StoredProcedure)
            '
            db.AsignarParametro("p_monto_minimo", OracleClient.OracleType.Number)
            db.AsignarParametro("cur_consul_montos_ca", OracleClient.OracleType.Cursor)
            '
            db.EjecutarComando()
            '
            If db.Parametros.Length > 0 Then
                Me.MONTO_MINIMO = IIf(db.Parametros(1) Is DBNull.Value, 0, db.Parametros(1))
                ldt_tmp = IIf(db.Parametros(2) Is DBNull.Value, Nothing, db.Parametros(2))
            End If
            '
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'desconecta
            db.Desconectar()
        End Try
    End Function
    'Public Function SP_INUP_confi_carga_ase_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_INUP_confi_carga_ase"

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.VarChar)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RANGO_MINIMO", OracleClient.OracleType.Number)).Value = RANGO_MINIMO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RANGO_MAXIMO", OracleClient.OracleType.Number)).Value = RANGO_MAXIMO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_PORCEN", OracleClient.OracleType.Number)).Value = PORCEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_MINIMO", OracleClient.OracleType.Number)).Value = MONTO_MINIMO
    '        cmd.ExecuteNonQuery()
    '        Return True
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_INUP_confi_carga_ase() As Boolean
        Dim db_bd As New BaseDatos
        Dim lb_flag As Boolean = False
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_INUP_confi_carga_ase", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_RANGO_MINIMO", RANGO_MINIMO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_RANGO_MAXIMO", RANGO_MAXIMO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_PORCEN", PORCEN, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_MONTO_MINIMO", MONTO_MINIMO, OracleClient.OracleType.Number)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            lb_flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return lb_flag
    End Function
    'Public Function SP_de_confi_carga_ase_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_de_confi_carga_ase"
    '        '
    '        cmd.ExecuteNonQuery()
    '        '
    '        Return True
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_de_confi_carga_ase() As Boolean
        Dim db_bd As New BaseDatos
        Dim lb_flag As Boolean = False
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_de_confi_carga_ase", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            lb_flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar
            db_bd.Desconectar()
        End Try
        Return lb_flag
    End Function
    '    Public Function sp_consul_montos_ca_perso_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivocarga_asegurada.sp_consul_montos_ca_perso"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_monto_minimo", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_consul_montos_ca_perso", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    ''        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        Try
    '            dv = ds.Tables(0).DefaultView
    '            If Not cmd.Parameters("p_monto_minimo").Value Is DBNull.Value Then
    '                Me.MONTO_MINIMO = cmd.Parameters("p_monto_minimo").Value
    '            End If
    '            Return dv
    '        Catch ex As System.Exception
    '            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Catch OEx As System.Data.OracleClient.OracleException
    '            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End Try
    '    End Function
    Public Function sp_consul_montos_ca_perso() As DataView
        Dim db_bd As New BaseDatos
        Dim ldt_tmp As New DataTable
        '
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivocarga_asegurada.sp_consul_montos_ca_perso", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("p_monto_minimo", OracleClient.OracleType.Number)            
            db_bd.AsignarParametro("cur_consul_montos_ca_PERSO", OracleClient.OracleType.Cursor)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                Me.MONTO_MINIMO = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                ldt_tmp = IIf(db_bd.Parametros(2) Is DBNull.Value, Nothing, db_bd.Parametros(2))
            End If
            '
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Function
    'Public Function SP_de_confi_carga_ase_perso_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_de_confi_carga_ase_perso"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.ExecuteNonQuery()
    '        Return True
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_de_confi_carga_ase_perso() As Boolean
        Dim db_bd As New BaseDatos
        Dim lb_flag As Boolean = False
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_de_confi_carga_ase_perso", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            lb_flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar
            db_bd.Desconectar()
        End Try
        Return lb_flag
    End Function
    'Public Function SP_INUP_confi_carga_ase_perso_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_INUP_confi_carga_ase_perso"

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.VarChar)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RANGO_MINIMO", OracleClient.OracleType.Number)).Value = RANGO_MINIMO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RANGO_MAXIMO", OracleClient.OracleType.Number)).Value = RANGO_MAXIMO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_PORCEN", OracleClient.OracleType.Number)).Value = PORCEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_MINIMO", OracleClient.OracleType.Number)).Value = MONTO_MINIMO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA


    '        cmd.ExecuteNonQuery()

    '        Return True


    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_INUP_confi_carga_ase_perso() As Boolean
        Dim db_bd As New BaseDatos
        Dim lb_flag As Boolean = False
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_INUP_confi_carga_ase_perso", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_RANGO_MINIMO", RANGO_MINIMO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_RANGO_MAXIMO", RANGO_MAXIMO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_PORCEN", PORCEN, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_MONTO_MINIMO", MONTO_MINIMO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Number)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            lb_flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar
            db_bd.Desconectar()
        End Try
        Return lb_flag
    End Function
    'Public Function SP_BUSCA_INFINITO_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_BUSCA_INFINITO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("VALOR", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("VALOR").Value Is DBNull.Value Then
    '            Me.MyEXISTE_INFINITO = IIf(cmd.Parameters("VALOR").Value = 0, False, True)
    '        End If
    '        Return True

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_BUSCA_INFINITO() As Boolean
        Dim db_bd As New BaseDatos
        Dim lb_flat As Boolean = False
        Dim ll_valor As Integer = 0
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_BUSCA_INFINITO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("VALOR", OracleClient.OracleType.Number)
            db_bd.EjecutarComando()

            If db_bd.Parametros.Length > 0 Then
                ll_valor = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                Me.MyEXISTE_INFINITO = IIf(ll_valor = 0, False, True)
                lb_flat = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return lb_flat
    End Function
    'Public Function SP_BUSCA_INFINITO_CLIENTE_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_BUSCA_INFINITO_CLIENTE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CODIGO", OracleClient.OracleType.Number)).Value = MyIDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("VALOR", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("VALOR").Value Is DBNull.Value Then
    '            Me.MyEXISTE_INFINITO = IIf(cmd.Parameters("VALOR").Value = 0, False, True)
    '        End If
    '        Return True

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_BUSCA_INFINITO_CLIENTE() As Boolean
        Dim db_bd As New BaseDatos
        Dim lb_flat As Boolean = False
        Dim ll_valor As Integer = 0
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_BUSCA_INFINITO_CLIENTE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("CODIGO", MyIDPERSONA, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("VALOR", OracleClient.OracleType.Number)
            db_bd.EjecutarComando()

            If db_bd.Parametros.Length > 0 Then
                ll_valor = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                Me.MyEXISTE_INFINITO = IIf(ll_valor = 0, False, True)
                lb_flat = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return lb_flat
    End Function
    'Public Function SP_CLIENTE_TARIFA_ASEGURADA_2009(ByVal cnn As OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_CLIENTE_TARIFA_ASEGURADA"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_DATOS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)

    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_CLIENTE_TARIFA_ASEGURADA() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_CLIENTE_TARIFA_ASEGURADA", CommandType.StoredProcedure)
            '
            db.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function SP_BUSCA_INFINITO_CLIENTE(ByVal grd As System.Windows.Forms.DataGridView) As Boolean
        With grd
            For i As Integer = 0 To .RowCount - 1
                If .Item(1, i).Value = 0 Then
                    Me.MyEXISTE_INFINITO = True
                    Return True
                End If
            Next
            Me.MyEXISTE_INFINITO = False
            Return True
        End With
    End Function
    Public Function SP_BUSCA_INFINITO(ByVal grd As System.Windows.Forms.DataGridView) As Boolean
        With grd
            For i As Integer = 0 To .RowCount - 1
                If .Item(1, i).Value = 0 Then
                    Me.MyEXISTE_INFINITO = True
                    Return True
                End If
            Next
            Me.MyEXISTE_INFINITO = False
            Return True
        End With
    End Function

End Class
