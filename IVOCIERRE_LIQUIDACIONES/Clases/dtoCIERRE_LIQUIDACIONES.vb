Imports AccesoDatos
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.Shared

Public Class dtoCIERRE_LIQUIDACIONES
#Region "RECORSERT"
    'Public cur_Lista_Usuarios As New ADODB.Recordset
    'Public cur_Lista_Agencias As New ADODB.Recordset
    Public cur_Lista_Usuarios As New DataTable
    Public cur_Lista_Agencias As New DataTable

    Public coll_Lista_Usuarios As New Collection
    Public coll_Lista_Agencias As New Collection

    'Public cur_listar_liquidaciones As New ADODB.Recordset
    Public cur_listar_liquidaciones As New DataTable
    Public coll_listar_liquidaciones As New Collection

    'Public cur_listar_ARQUEOS As New ADODB.Recordset
    Public cur_listar_ARQUEOS As New DataTable
    Public coll_listar_ARQUEOS As New Collection

#End Region
#Region "PROPIEDADES"
    Dim MyIDUSUARIO_PERSONAL As Integer
    Dim MyESTADO_APERTURADO_CIERRE As Integer
    Dim MyIDAGENCIAS As Integer
    Dim MyFECHA_LIQUIDACION_CIERRE As String
    Dim MyIDCIERRES_LIQUIDACIONES As Integer
    Dim MyIDUSUARIO_PERSONALMOD As Integer
    Dim MyIDROL_USUARIO As Integer
    Dim MyIDROL_USUARIOMOD As Integer
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyFECHA_REGISTRO As String
    Dim MyIDESTADO_REGISTRO As Integer
    Dim MyFECHA_LIQUIDACION_APER As String

    Dim MyID_CIERRE_LIQUI_DETA As Integer
    Dim MyIDPROCESOS As Integer
    Dim MySERIE As Integer
    Dim MyINICIO As String
    Dim MyFIN As String
    Dim MyCORTE As Integer
    Dim MyOBSER As String

    Dim MyFECHA_FIN As String
    Dim MyFECHA_INICIO As String
    Public Property FECHA_FIN() As String
        Get
            FECHA_FIN = MyFECHA_FIN
        End Get
        Set(ByVal value As String)
            MyFECHA_FIN = value
        End Set
    End Property
    Public Property FECHA_INICIO() As String
        Get
            FECHA_INICIO = MyFECHA_INICIO
        End Get
        Set(ByVal value As String)
            MyFECHA_INICIO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Integer
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONAL = Value
        End Set
    End Property
    Public Property ESTADO_APERTURADO_CIERRE() As Integer
        Get
            ESTADO_APERTURADO_CIERRE = MyESTADO_APERTURADO_CIERRE
        End Get
        Set(ByVal value As Integer)
            MyESTADO_APERTURADO_CIERRE = Value
        End Set
    End Property
    Public Property IDAGENCIAS() As Integer
        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Integer)
            MyIDAGENCIAS = Value
        End Set
    End Property
    Public Property FECHA_LIQUIDACION_CIERRE() As String
        Get
            FECHA_LIQUIDACION_CIERRE = MyFECHA_LIQUIDACION_CIERRE
        End Get
        Set(ByVal value As String)
            MyFECHA_LIQUIDACION_CIERRE = Value
        End Set
    End Property
    Public Property IDCIERRES_LIQUIDACIONES() As Integer
        Get
            IDCIERRES_LIQUIDACIONES = MyIDCIERRES_LIQUIDACIONES
        End Get
        Set(ByVal value As Integer)
            MyIDCIERRES_LIQUIDACIONES = Value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Integer
        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONALMOD = Value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Integer
        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Integer)
            MyIDROL_USUARIO = Value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Integer
        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Integer)
            MyIDROL_USUARIOMOD = Value
        End Set
    End Property
    Public Property IP() As String
        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = Value
        End Set
    End Property
    Public Property IPMOD() As String
        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = Value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = Value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Integer
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Integer)
            MyIDESTADO_REGISTRO = Value
        End Set
    End Property
    Public Property FECHA_LIQUIDACION_APER() As String
        Get
            FECHA_LIQUIDACION_APER = MyFECHA_LIQUIDACION_APER
        End Get
        Set(ByVal value As String)
            MyFECHA_LIQUIDACION_APER = Value
        End Set
    End Property
    Public Property ID_CIERRE_LIQUI_DETA() As Integer
        Get
            ID_CIERRE_LIQUI_DETA = MyID_CIERRE_LIQUI_DETA
        End Get
        Set(ByVal value As Integer)
            MyID_CIERRE_LIQUI_DETA = Value
        End Set
    End Property
    
    Public Property IDPROCESOS() As Integer
        Get
            IDPROCESOS = MyIDPROCESOS
        End Get
        Set(ByVal value As Integer)
            MyIDPROCESOS = Value
        End Set
    End Property
    Public Property SERIE() As Integer
        Get
            SERIE = MySERIE
        End Get
        Set(ByVal value As Integer)
            MySERIE = Value
        End Set
    End Property
    Public Property INICIO() As String
        Get
            INICIO = MyINICIO
        End Get
        Set(ByVal value As String)
            MyINICIO = Value
        End Set
    End Property
    Public Property FIN() As String
        Get
            FIN = MyFIN
        End Get
        Set(ByVal value As String)
            MyFIN = Value
        End Set
    End Property
    Public Property CORTE() As Integer
        Get
            CORTE = MyCORTE
        End Get
        Set(ByVal value As Integer)
            MyCORTE = Value
        End Set
    End Property
    Public Property OBSER() As String
        Get
            OBSER = MyOBSER
        End Get
        Set(ByVal value As String)
            MyOBSER = Value
        End Set
    End Property
    
#End Region

#Region "METODOS"
    Public Function fnCIERRE_LIQUIDACIONES() As Boolean
        Dim flag As Boolean = True
        Try

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            flag = False
        End Try
        Return flag
    End Function

    'Public curr_abrir_liquidaciones As New ADODB.Recordset
    Public curr_abrir_liquidaciones As New DataTable
    Public coll_abrir_liquidaciones As New Collection

    'Public curr_listar_guias_liquidadas As New ADODB.Recordset
    Public coll_listar_guias_liquidadas As New Collection
    Public Function fnLISTAR_GUIAS_LIQUIDADAS2009() As Boolean
        'Dim flat As Boolean = True
        'Try
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_GUIAS_LIQUIDADAS", 4, Me.IDCIERRES_LIQUIDACIONES, 1}
        '    curr_listar_guias_liquidadas = Nothing
        '    curr_listar_guias_liquidadas = VOCONTROLUSUARIO.fnsqlquery(varSP_OBJECT)
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        '    flat = False
        'End Try
        'Return flat
    End Function


    Function SP_SI_LIQUIDACION_ABIERTA2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
        Dim cmd As New System.Data.OracleClient.OracleCommand
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PKG_IVOCIERRE_LIQUIDACIONES.SP_SI_LIQUIDACION_ABIERTA"
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = IDROL_USUARIO
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
        cmd.Parameters.Add(New OracleClient.OracleParameter("CURR_SI_LIQUIDACION_ABIERTA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

        Dim ds As New DataSet
        daora.Fill(ds)


        Dim dv As New DataView

        dv = ds.Tables(0).DefaultView

        Return dv

        Try
        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function

    'Public Function fnLISTA_AGENCIA_USUARIOS2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_AGENCIA_USUARIOS", 2}
    '        cur_Lista_Usuarios = Nothing
    '        cur_Lista_Agencias = Nothing

    '        cur_Lista_Agencias = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnLISTA_AGENCIA_USUARIOS() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_AGENCIA_USUARIOS", CommandType.StoredProcedure)
            db.AsignarParametro("cur_Lista_Agencias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_Lista_Agencias = ds.Tables(0)
            flat = True
        Catch ex As Exception
            flat = False
        End Try
        Return flat
    End Function

    'Public Function fnLISTA_USUARIOS2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS", 6, 21, 1, dtoUSUARIOS.m_iIdAgencia, 1}
    '        cur_Lista_Usuarios = Nothing
    '        cur_Lista_Usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fnLISTA_USUARIOS() As Boolean
        Dim flat As Boolean = False
        Try
            'Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS", 6, 21, 1, dtoUSUARIOS.m_iIdAgencia, 1}
            'cur_Lista_Usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS_1", CommandType.StoredProcedure)
            db.AsignarParametro("idRol_Usuario", 21, OracleClient.OracleType.Int16)
            db.AsignarParametro("idAgencia", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_Lista_Usuarios = ds.Tables(0)

            flat = True
        Catch ex As Exception
            flat = False
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
    'Public Function fnLISTAR_Liquidaciones2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUIDACIONES", 10, IDAGENCIAS, 1, IDUSUARIO_PERSONAL, 1, FECHA_INICIO, 2, FECHA_FIN, 2}
    '        cur_listar_liquidaciones = Nothing
    '        cur_listar_liquidaciones = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fnLISTAR_Liquidaciones() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUIDACIONES", CommandType.StoredProcedure)
            db.AsignarParametro("p_IDAgencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("FECHAINICIO", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("FECHAFIN", FECHA_FIN, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTA_LIQUIDACIONES", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_listar_liquidaciones = ds.Tables(0)
            flat = True
            'End If 
        Catch ex As Exception
            flat = False
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
    'Public Function fnLISTAR_ARQUEOS2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_ARQUEOS", 26, Me.IDCIERRES_LIQUIDACIONES, 1, Me.IDUSUARIO_PERSONAL, 1, Me.IDAGENCIAS, 1, Me.IDUSUARIO_PERSONALMOD, 1, Me.IDPROCESOS, 1, Me.IDESTADO_REGISTRO, 1, Me.IPMOD, 2, Me.IDROL_USUARIOMOD, 1, Me.OBSER, 2, Me.ESTADO_APERTURADO_CIERRE, 1, FECHA_INICIO, 2, FECHA_FIN, 2}
    '        ' Modificado 05/06/2008 
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_ARQUEOS", 26, CType(Me.IDCIERRES_LIQUIDACIONES, String), 2, Me.IDUSUARIO_PERSONAL, 1, Me.IDAGENCIAS, 1, Me.IDUSUARIO_PERSONALMOD, 1, Me.IDPROCESOS, 1, Me.IDESTADO_REGISTRO, 1, Me.IPMOD, 2, Me.IDROL_USUARIOMOD, 1, Me.OBSER, 2, Me.ESTADO_APERTURADO_CIERRE, 1, FECHA_INICIO, 2, FECHA_FIN, 2}
    '        cur_listar_ARQUEOS = Nothing
    '        cur_listar_ARQUEOS = VOCONTROLUSUARIO.fnsqlquery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fnLISTAR_ARQUEOS() As Boolean
        Dim flat As Boolean = True
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_ARQUEOS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDCIERRES_LIQUIDACIONES", CType(Me.IDCIERRES_LIQUIDACIONES, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", Me.IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", Me.IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", Me.IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPROCESOS", Me.IDPROCESOS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_REGISTRO", Me.IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IPMOD", Me.IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDROL_USUARIOMOD", Me.IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_obser", Me.OBSER, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_ESTADO_APERTURADO_CIERRE", Me.ESTADO_APERTURADO_CIERRE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIO", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FIN, OracleClient.OracleType.VarChar)
            db.AsignarParametro("curr_Listar_Arqueo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_listar_ARQUEOS = ds.Tables(0)
        Catch ex As Exception
            flat = False
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
        Return flat
    End Function

    Public Total_venta_Credito As Double
    Public Function fnLISTAR_ARQUEOS_I() As Boolean
        Dim flat As Boolean = True
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_ARQUEOS_I", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDCIERRES_LIQUIDACIONES", CType(Me.IDCIERRES_LIQUIDACIONES, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", Me.IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", Me.IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", Me.IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPROCESOS", Me.IDPROCESOS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_REGISTRO", Me.IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IPMOD", Me.IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDROL_USUARIOMOD", Me.IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_obser", Me.OBSER, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_ESTADO_APERTURADO_CIERRE", Me.ESTADO_APERTURADO_CIERRE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIO", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FIN, OracleClient.OracleType.VarChar)
            '--
            db.AsignarParametro("P_Total_venta_Credito", Total_venta_Credito, OracleClient.OracleType.VarChar)
            '--
            db.AsignarParametro("curr_Listar_Arqueo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_listar_ARQUEOS = ds.Tables(0)
        Catch ex As Exception
            flat = False
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
        Return flat
    End Function

    'Public Function fnABRIR_LIQUIDACIONES2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_ABRIR_LIQUIDACIONES", 12, Me.IDUSUARIO_PERSONAL, 1, Me.IDAGENCIAS, 1, Me.IDROL_USUARIO, 1, Me.IP, 2}
    '        curr_abrir_liquidaciones = Nothing
    '        curr_abrir_liquidaciones = VOCONTROLUSUARIO.fnsqlquery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnABRIR_LIQUIDACIONES() As Boolean
        Dim flat As Boolean = True
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_ABRIR_LIQUIDACIONES", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", Me.IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", Me.IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIO", Me.IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", Me.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("curr_usuario_perso", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            curr_abrir_liquidaciones = ds.Tables(0)

        Catch ex As Excepcion
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            flat = False
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    'Public Function fnABRIR_LIQUIDACIONES_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_ABRIR_LIQUIDACIONES_", 14, Me.FECHA_LIQUIDACION_APER, 2, Me.IDUSUARIO_PERSONAL, 1, Me.IDAGENCIAS, 1, Me.IDROL_USUARIO, 1, Me.IP, 2}
    '        curr_abrir_liquidaciones = Nothing
    '        curr_abrir_liquidaciones = VOCONTROLUSUARIO.fnsqlquery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function

    Public Function fnABRIR_LIQUIDACIONES_() As Boolean
        Dim flat As Boolean = True
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_ABRIR_LIQUIDACIONES_", CommandType.StoredProcedure)
            db.AsignarParametro("P_fecha_liquidacion_aper", Me.FECHA_LIQUIDACION_APER, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", Me.IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", Me.IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIO", Me.IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", Me.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("curr_usuario_perso", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            curr_abrir_liquidaciones = ds.Tables(0)

        Catch ex As Excepcion
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            flat = False
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    'Function SP_ESTADO_LIQUI_CREDI(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCIERRE_LIQUIDACIONES.SP_ESTADO_LIQUI_CREDI"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_FECHA_LIQUIDACION_APER", OracleClient.OracleType.VarChar, 20)).Direction = ParameterDirection.Output


    '        cmd.ExecuteNonQuery()

    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)


    '        'Dim dv As New DataView

    '        'dv = ds.Tables(0).DefaultView

    '        'Return dv
    '        If Not cmd.Parameters("oP_FECHA_LIQUIDACION_APER").Value Is DBNull.Value Then
    '            MsgBox("Usted tiene una apertura del día " + cmd.Parameters("oP_FECHA_LIQUIDACION_APER").Value.ToString + " le aconsejamos que cierre esta liquidación y continúe con sus operaciones...", MsgBoxStyle.Critical, "Seguridad del Sistema")
    '        End If



    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Function SP_ESTADO_LIQUI_CREDI()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_ESTADO_LIQUI_CREDI", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("oP_FECHA_LIQUIDACION_APER", 20, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.EjecutarComando()
            If db.Parametros.Length > 0 Then
                If Not db.Parametros(1) Is DBNull.Value Then
                    MsgBox("Usted tiene una apertura del día " + db.Parametros(1).ToString + " le aconsejamos que cierre esta liquidación y continúe con sus operaciones...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                End If
            End If
            'If Not cmd.Parameters("oP_FECHA_LIQUIDACION_APER").Value Is DBNull.Value Then
            'MsgBox("Usted tiene una apertura del día " + cmd.Parameters("oP_FECHA_LIQUIDACION_APER").Value.ToString + " le aconsejamos que cierre esta liquidación y continúe con sus operaciones...", MsgBoxStyle.Critical, "Seguridad del Sistema")
            'End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function SP_SI_LIQUIDACION_ABIERTA_(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
        Dim cmd As New System.Data.OracleClient.OracleCommand
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PKG_IVOCIERRE_LIQUIDACIONES.SP_SI_LIQUIDACION_ABIERTA_"
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_LIQUIDACION_APER", OracleClient.OracleType.VarChar)).Value = FECHA_LIQUIDACION_APER
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = IDROL_USUARIO
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
        cmd.Parameters.Add(New OracleClient.OracleParameter("CURR_SI_LIQUIDACION_ABIERTA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

        Dim ds As New DataSet
        daora.Fill(ds)


        Dim dv As New DataView

        dv = ds.Tables(0).DefaultView

        Return dv

        Try
        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function

    'Function SP_SI_LIQUIDACION_ABIERTA_() As DataView
    Function SP_SI_LIQUIDACION_ABIERTA_() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_SI_LIQUIDACION_ABIERTA_", CommandType.StoredProcedure)
            db.AsignarParametro("P_FECHA_LIQUIDACION_APER", FECHA_LIQUIDACION_APER, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CURR_SI_LIQUIDACION_ABIERTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            'Return db.EjecutarDataTable.DefaultView
            Return db.EjecutarDataTable
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarLiquidacionTurno(ByVal id As Integer, ByVal fecha As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 16-05-2017
            'If CDate(fecha) <= CDate("18/06/2017") Then
            'db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LIST_VENTAS_LIQUI_TURNO_2", CommandType.StoredProcedure)
            'Else
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.sp_listar_cierre_2", CommandType.StoredProcedure)
            'End If
            db.AsignarParametro("P_IDLIQUI_TURNOS", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IMPRESO", 0, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LIST_VENTAS_LIQUI_TURNO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_RESUMEN", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_MOVIMIENTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarLiquidacionTurno(ByVal id As Integer, ByVal agencia As Integer, ByVal ini As String, ByVal fin As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 16-05-2017
            If CDate(ini) <= CDate("18/06/2017") Then
                db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LIST_VENTAS_PRELI_TURNO_3", CommandType.StoredProcedure)
            Else
                db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.sp_listar_preliminar_cierre_2", CommandType.StoredProcedure)
            End If
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", ini, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_resumen", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_LIST_VENTAS_PRELI_TURNO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_movimiento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarLiquidacionTurnoCredito(ByVal id As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_GUIAS_LIQUIDADAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDCIERRES_LIQUIDACIONES", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("curr_LISTAR_GUIAS_LIQUIDADAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarLiquidacionTurnoCredito(ByVal id As Integer, ByVal agencia As Integer, ByVal ini As String, ByVal fin As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_GUIAS_POR_LIQUIDAR", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIO", ini, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("curr_LISTAR_GUIAS_POR_LIQUIDAR", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function fnLISTA_USUARIOS(ByVal opcion As Integer, ByVal fechaInicio As String, ByVal fechaFin As String) As Boolean
        Dim flat As Boolean = False
        Try
            'Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS", 6, 21, 1, dtoUSUARIOS.m_iIdAgencia, 1}
            'cur_Lista_Usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS", CommandType.StoredProcedure)
            'db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS_1", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTA_USUARIOS_3", CommandType.StoredProcedure)

            '   db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_idAgencia", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_fechaInicio", fechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_fechaFin", fechaFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_Lista_Usuarios = ds.Tables(0)

            flat = True
        Catch ex As Exception
            flat = False
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    Public Function Listar_Tipo_Tarjeta() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.sp_listar_tipo_tarjeta", CommandType.StoredProcedure)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarTipoPago() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.sp_listar_tipo_pago", CommandType.StoredProcedure)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Public Function ListarLiquidacion(inicio As String, fin As String, agencia As Integer, usuario As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.sp_listar_liquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub ActualizarComprobante(ByVal comprobante As Integer, ByVal pago As Integer, ByVal tipo_pago As Integer, ByVal tipo_tarjeta As Integer, ByVal tarjeta As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.sp_actualizar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_pago", pago, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_pago", tipo_pago, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarjeta", tipo_tarjeta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tarjeta", tarjeta, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
#End Region
End Class
