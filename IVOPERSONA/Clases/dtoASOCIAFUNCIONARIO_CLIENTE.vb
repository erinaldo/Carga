Imports AccesoDatos
Public Class dtoASOCIAFUNCIONARIO_CLIENTE
#Region " VALORES DE LA TABLA "
    'iCONTROL               IN NUMBER,
    'iIDFUNCIONARIO         IN T_FUNCIONARIO_PERSONA.IDFUNCIONARIO%TYPE,
    'iIDFUNCIONARIO_ACTUAL  IN T_FUNCIONARIO_PERSONA.IDFUNCIONARIO_ACTUAL%TYPE,
    'iTIPO_FUNIONARIO       IN T_FUNCIONARIO_PERSONA.TIPO_FUNIONARIO%TYPE,
    'iIDPERSONA             IN T_FUNCIONARIO_PERSONA.IDPERSONA%TYPE,
    'iIDUSUARIO_PERSONAL    IN T_FUNCIONARIO_PERSONA.IDUSUARIO_PERSONAL%TYPE,
    'iIDROL_USUARIO         IN T_FUNCIONARIO_PERSONA.IDROL_USUARIO%TYPE,
    'iIP                    IN T_FUNCIONARIO_PERSONA.IP%TYPE,
    'iIDESTADO_REGISTRO     IN T_FUNCIONARIO_PERSONA.IDESTADO_REGISTRO%TYPE,
    'oCUR_CONTROL           OUT TYPES.CURSOR_TYPE  
#End Region
    Private AsControl As Integer
    Private AsIDFuncionario As Integer
    Private AsIDFuncionarioActual As Integer
    Private AsTipoFuncionario As Integer
    Private AsIDPersona As String 'Es el codigo de la persona
    Private AsIDUsuarioPersona As Integer
    Private AsRolUsuario As Integer
    Private AsIP As String
    Private AsIDEstadoRegistro As Integer

    Public Property Control() As Integer
        Get
            Return AsControl
        End Get
        Set(ByVal value As Integer)
            AsControl = value
        End Set
    End Property

    Public Property IDFuncionario() As Integer
        Get
            Return AsIDFuncionario
        End Get
        Set(ByVal value As Integer)
            AsIDFuncionario = value
        End Set
    End Property

    Public Property IDFuncionarioActual() As Integer
        Get
            Return AsIDFuncionarioActual
        End Get
        Set(ByVal value As Integer)
            AsIDFuncionarioActual = value
        End Set
    End Property

    Public Property TipoFuncionario() As Integer
        Get
            Return AsTipoFuncionario
        End Get
        Set(ByVal value As Integer)
            AsTipoFuncionario = value
        End Set
    End Property

    Public Property IDPersona() As String
        Get
            Return AsIDPersona
        End Get
        Set(ByVal value As String)
            AsIDPersona = value
        End Set
    End Property

    Public Property IDUsuarioPersona() As Integer
        Get
            Return AsIDUsuarioPersona
        End Get
        Set(ByVal value As Integer)
            AsIDUsuarioPersona = value
        End Set
    End Property

    Public Property RolUsuario() As Integer
        Get
            Return AsRolUsuario
        End Get
        Set(ByVal value As Integer)
            AsRolUsuario = value
        End Set
    End Property

    Public Property IP() As String
        Get
            Return AsIP
        End Get
        Set(ByVal value As String)
            AsIP = value
        End Set
    End Property

    Public Property IDEstadoRegistro() As Integer
        Get
            Return AsIDEstadoRegistro
        End Get
        Set(ByVal value As Integer)
            AsIDEstadoRegistro = value
        End Set
    End Property
    Public Function AsociaFuncionarioJuridico() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_ASOCIA_FUNCLIE", CommandType.StoredProcedure)

            db.AsignarParametro("iCONTROL", AsControl, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDFUNCIONARIO", AsIDFuncionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDFUNCIONARIO_ACTUAL", AsIDFuncionarioActual, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTIPO_FUNIONARIO", AsTipoFuncionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPERSONA", AsIDPersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", AsIDUsuarioPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", AsRolUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", AsIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDESTADO_REGISTRO", AsIDEstadoRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function AsociaFuncionarioJuridicoPasa2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_ASOCIA_FUNCLIE_PASA", 20, _
    '    AsControl, 1, _
    '    AsIDFuncionario, 1, _
    '    AsIDFuncionarioActual, 1, _
    '    AsTipoFuncionario, 1, _
    '    AsIDPersona, 2, _
    '    AsIDUsuarioPersona, 1, _
    '    AsRolUsuario, 1, _
    '    AsIP, 2, _
    '    AsIDEstadoRegistro, 1}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function

    'Public Function AsociaFuncionarioJuridico2009() As ADODB.Recordset

    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_ASOCIA_FUNCLIE", 20, _
    '    AsControl, 1, _
    '    AsIDFuncionario, 1, _
    '    AsIDFuncionarioActual, 1, _
    '    AsTipoFuncionario, 1, _
    '    AsIDPersona, 2, _
    '    AsIDUsuarioPersona, 1, _
    '    AsRolUsuario, 1, _
    '    AsIP, 2, _
    '    AsIDEstadoRegistro, 1}

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function

    Public Function AsociaFuncionarioJuridicoPasa() As DataTable
        Try
            Dim db As New BaseDatos

            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_ASOCIA_FUNCLIE_PASA", CommandType.StoredProcedure)

            db.AsignarParametro("iCONTROL", AsControl, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDFUNCIONARIO", AsIDFuncionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDFUNCIONARIO_ACTUAL", AsIDFuncionarioActual, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTIPO_FUNIONARIO", AsTipoFuncionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPERSONA", AsIDPersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", AsIDUsuarioPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", AsRolUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", AsIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDESTADO_REGISTRO", OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
