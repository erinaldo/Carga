Imports AccesoDatos
Public Class dtoCONTACTO_CLIENTE
#Region " CAMPOS A INSERTAR "
    'iCONTROL               IN NUMBER,
    'iIDCONTACTO_PERSONA    IN T_CONTACTO_PERSONA.IDCONTACTO_PERSONA%TYPE,
    'iIDTIPO_CONTACTO       IN T_CONTACTO_PERSONA.IDTIPO_CONTACTO%TYPE,
    'iIDPERSONA             IN VARCHAR2,
    'iNOMBRES               IN T_CONTACTO_PERSONA.NOMBRES%TYPE,
    'iAPEPAT                IN T_CONTACTO_PERSONA.APEPAT%TYPE,
    'iAPEMAT                IN T_CONTACTO_PERSONA.APEMAT%TYPE,
    'iNRODOCUMENTO          IN T_CONTACTO_PERSONA.NRODOCUMENTO%TYPE,
    'iEMAIL_CONTACTO        IN T_CONTACTO_PERSONA.EMAIL_CONTACTO%TYPE,
    'iSEXO                  IN T_CONTACTO_PERSONA.SEXO%TYPE,
    'iIDUSUARIO_PERSONAL    IN T_CONTACTO_PERSONA.IDUSUARIO_PERSONAL%TYPE,
    'iIDROL_USUARIO         IN T_CONTACTO_PERSONA.IDROL_USUARIO%TYPE,
    'iIP                    IN T_CONTACTO_PERSONA.IP%TYPE,
    'oCUR_CONTROL           OUT TYPES.CURSOR_TYPE  
#End Region
    Private CnControl As Integer
    Private CnIDContactoPersona As Integer
    Private CnsIDContactoPersona As String
    Private CnIDTipoContacto As Integer
    Private CnIDPersona As String
    Private CnCentroCosto As Integer
    Private CnNombres As String
    Private CnApepat As String
    Private CnApemat As String
    Private CnIDTipoDocumentoContacto As Integer
    Private CnNumeroDoctumento As String
    Private CnEmailContacto As String
    Private CnSexo As String
    Private CnIDUsuariPersonal As Integer
    Private CnIDRolUsuario As Integer
    Private CnIP As String
    Private CnEstadoRegistro As Integer

    Public Property Control() As Integer
        Get
            Return CnControl
        End Get
        Set(ByVal value As Integer)
            CnControl = value
        End Set
    End Property

    Public Property IDContactoPersona() As Integer
        Get
            Return CnIDContactoPersona
        End Get
        Set(ByVal value As Integer)
            CnIDContactoPersona = value
        End Set
    End Property
    Public Property sIDContactoPersona() As String
        Get
            Return CnsIDContactoPersona
        End Get
        Set(ByVal value As String)
            CnsIDContactoPersona = value
        End Set
    End Property
    Public Property IDTipoContacto() As Integer
        Get
            Return CnIDTipoContacto
        End Get
        Set(ByVal value As Integer)
            CnIDTipoContacto = value
        End Set
    End Property

    Public Property IDPersona() As String
        Get
            Return CnIDPersona
        End Get
        Set(ByVal value As String)
            CnIDPersona = value
        End Set
    End Property

    Public Property CentroCosto() As Integer
        Get
            Return CnCentroCosto
        End Get
        Set(ByVal value As Integer)
            CnCentroCosto = value
        End Set
    End Property

    Public Property Nombres() As String
        Get
            Return CnNombres
        End Get
        Set(ByVal value As String)
            CnNombres = value
        End Set
    End Property

    Public Property Apepat() As String
        Get
            Return CnApepat
        End Get
        Set(ByVal value As String)
            CnApepat = value
        End Set
    End Property
    Public Property Apemat() As String
        Get
            Return CnApemat
        End Get
        Set(ByVal value As String)
            CnApemat = value
        End Set
    End Property
    Public Property IDTipoDocumentoContacto() As Integer
        Get
            Return CnIDTipoDocumentoContacto
        End Get
        Set(ByVal value As Integer)
            CnIDTipoDocumentoContacto = value
        End Set
    End Property
    Public Property NumeroDoctumento() As String
        Get
            Return CnNumeroDoctumento
        End Get
        Set(ByVal value As String)
            CnNumeroDoctumento = value
        End Set
    End Property
    Public Property EmailContacto() As String
        Get
            Return CnEmailContacto
        End Get
        Set(ByVal value As String)
            CnEmailContacto = value
        End Set
    End Property
    Public Property Sexo() As String
        Get
            Return CnSexo
        End Get
        Set(ByVal value As String)
            CnSexo = value
        End Set
    End Property
    Public Property IDUsuariPersonal() As Integer
        Get
            Return CnIDUsuariPersonal
        End Get
        Set(ByVal value As Integer)
            CnIDUsuariPersonal = value
        End Set
    End Property
    Public Property IDRolUsuario() As Integer
        Get
            Return CnIDRolUsuario
        End Get
        Set(ByVal value As Integer)
            CnIDRolUsuario = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return CnIP
        End Get
        Set(ByVal value As String)
            CnIP = value
        End Set
    End Property
    Public Property EstadoRegistro() As Integer
        Get
            Return CnEstadoRegistro
        End Get
        Set(ByVal value As Integer)
            CnEstadoRegistro = value
        End Set
    End Property
    'Public Function GrabaContacto2009() As ADODB.Recordset
    '    CnApepat = "NULL"
    '    CnApemat = "NULL"
    '    Dim MyObjeGrabar As Object() = {"SP_INSUPD_CONTACTO_2", 34, _
    '    CnControl, 1, _
    '    CnsIDContactoPersona, 2, _
    '    CnIDTipoContacto, 1, _
    '    CnIDPersona, 2, _
    '    CnCentroCosto, 1, _
    '    CnNombres, 2, _
    '    CnApepat, 2, _
    '    CnApemat, 2, _
    '    CnIDTipoDocumentoContacto, 1, _
    '    CnNumeroDoctumento, 2, _
    '    CnEmailContacto, 2, _
    '    CnSexo, 2, _
    '    CnIDUsuariPersonal, 1, _
    '    CnIDRolUsuario, 1, _
    '    CnIP, 2, _
    '    CnEstadoRegistro, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function
    Public Function GrabaContacto() As DataTable
        Try
            Dim db As New BaseDatos
            CnApepat = "NULL"
            CnApemat = "NULL"
            '
            db.Conectar()
            db.CrearComando("SP_INSUPD_CONTACTO_2", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", CnControl, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_IDCONTACTO_PERSONA", CnsIDContactoPersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_CONTACTO", CnIDTipoContacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPERSONA", CnIDPersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDCENTRO_COSTO", CnCentroCosto, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRES", CnNombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iAPEPAT", CnApepat, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iAPEMAT", CnApemat, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_DOCUMENTO_CONTACTO", CnIDTipoDocumentoContacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNRODOCUMENTO", CnNumeroDoctumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iEMAIL_CONTACTO", CnEmailContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iSEXO", CnSexo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", CnIDUsuariPersonal, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", CnIDRolUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", CnIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iESTADO_REGISTRO", CnEstadoRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function LISTA_TIPO_CONTACTO() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_TIPO_CONTACTO", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_TIPO_CONTACTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function INSUPD_CARGO_CONTACTO(ByVal vAccionRegistro As Integer, ByVal rubro As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_CARGO_CONTACTO", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRE_CARGO", rubro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_LISTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
