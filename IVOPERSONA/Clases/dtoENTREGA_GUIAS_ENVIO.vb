Imports AccesoDatos
Public Class dtoENTREGA_GUIAS_ENVIO
    'iCONTROL                        IN INTEGER,         
    'iIDENTREGA_GUIAS_ENVIO          IN T_ENTREGAS_GUIAS_ENVIO.IDENTREGA_GUIAS_ENVIO%TYPE,
    'iCODIGOPERSONA                  VARCHAR2,
    'iIDCENTRO_COSTO                 IN T_ENTREGAS_GUIAS_ENVIO.IDCENTRO_COSTO%TYPE,
    'iSERIE                          IN T_ENTREGAS_GUIAS_ENVIO.SERIE%TYPE:=NULL,
    'iNRO_INICIAL                    IN T_ENTREGAS_GUIAS_ENVIO.NRO_INICIAL%TYPE,
    'iNRO_FINAL                      IN T_ENTREGAS_GUIAS_ENVIO.NRO_FINAL%TYPE,
    'iIDUSUARIO_PERSONAL             IN T_ENTREGAS_GUIAS_ENVIO.IDUSUARIO_PERSONAL%TYPE,
    'iIDROL_USUARIO                  IN T_ENTREGAS_GUIAS_ENVIO.IDROL_USUARIO%TYPE,
    'iIP                             IN T_ENTREGAS_GUIAS_ENVIO.IP%TYPE,

    Private GeControl As Integer
    Private GeIDEntregaGuiasEnvio As Integer
    Private GeCodigoPersona As String
    Private GeIDCentroCosto As Integer
    Private GeSerie As Integer
    Private GeNroInicial As Long
    Private GeNroFinal As Long
    Private GeIDUsuarioPersonal As Integer
    Private GeIDRolUsuario As Integer
    Private GeIP As String


    Public Property Control() As Integer
        Get
            Return GeControl
        End Get
        Set(ByVal value As Integer)
            GeControl = value
        End Set
    End Property

    Public Property IDEntregaGuiasEnvio() As Integer
        Get
            Return GeIDEntregaGuiasEnvio
        End Get
        Set(ByVal value As Integer)
            GeIDEntregaGuiasEnvio = value
        End Set
    End Property

    Public Property CodigoPersona() As String
        Get
            Return GeCodigoPersona
        End Get
        Set(ByVal value As String)
            GeCodigoPersona = value
        End Set
    End Property

    Public Property IDCentroCosto() As Integer
        Get
            Return GeIDCentroCosto
        End Get
        Set(ByVal value As Integer)
            GeIDCentroCosto = value
        End Set
    End Property

    Public Property Serie() As Integer
        Get
            Return GeSerie
        End Get
        Set(ByVal value As Integer)
            GeSerie = value
        End Set
    End Property

    Public Property NroInicial() As Long
        Get
            Return GeNroInicial
        End Get
        Set(ByVal value As Long)
            GeNroInicial = value
        End Set
    End Property

    Public Property NroFinal() As Long
        Get
            Return GeNroFinal
        End Get
        Set(ByVal value As Long)
            GeNroFinal = value
        End Set
    End Property

    Public Property IDUsuarioPersonal() As Integer
        Get
            Return GeIDUsuarioPersonal
        End Get
        Set(ByVal value As Integer)
            GeIDUsuarioPersonal = value
        End Set
    End Property

    Public Property IDRolUsuario() As Integer
        Get
            Return GeIDRolUsuario
        End Get
        Set(ByVal value As Integer)
            GeIDRolUsuario = value
        End Set
    End Property

    Public Property IP() As String
        Get
            Return GeIP
        End Get
        Set(ByVal value As String)
            GeIP = value
        End Set
    End Property


    'Public Function GrabaEntregaGuias2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.ISNUPD_GUIASENVIO_PERSONA", 22, _
    '    GeControl, 1, _
    '    GeIDEntregaGuiasEnvio, 1, _
    '    GeCodigoPersona, 2, _
    '    GeIDCentroCosto, 1, _
    '    GeSerie, 1, _
    '    GeNroInicial, 1, _
    '    GeNroFinal, 1, _
    '    GeIDUsuarioPersonal, 1, _
    '    GeIDRolUsuario, 1, _
    '    GeIP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function
    Public Function GrabaEntregaGuias() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.ISNUPD_GUIASENVIO_PERSONA", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDENTREGA_GUIAS_ENVIO", OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOPERSONA", OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDCENTRO_COSTO", OracleClient.OracleType.Int32)
        db.AsignarParametro("iSERIE", OracleClient.OracleType.Int32)
        db.AsignarParametro("iNRO_INICIAL", OracleClient.OracleType.Int32)
        db.AsignarParametro("iNRO_FINAL", OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDUSUARIO_PERSONAL", OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDROL_USUARIO", OracleClient.OracleType.Int32)
        db.AsignarParametro("iIP", OracleClient.OracleType.VarChar)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class

