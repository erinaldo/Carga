Imports AccesoDatos
Public Class dtoCOMUNICACION_CONTACTO
#Region " CAMPOS A INSERTAR "
    'iCONTROL                        IN INTEGER,         
    'iIDCOMUNICACION_CONTACTO        IN T_COMUNICACION_CONTACTO.IDCOMUNICACION_CONTACTO%TYPE,
    'iNROCOMUNICACION_CONTACTO       IN T_COMUNICACION_CONTACTO.NROCOMUNICACION_CONTACTO%TYPE,
    'iIDTIPO_COMUNICACION            IN T_COMUNICACION_CONTACTO.IDTIPO_COMUNICACION%TYPE,
    'iCODIGOPERSONA                  IN VARCHAR2,
    'oCUR_CONTROL                    OUT TYPES.CURSOR_TYPE    
#End Region
    Private CmControl As Integer
    Private CmIDComunicacionContacto As Integer
    Private CmNumeroComunicacion As String
    Private CmTipoComunicacion As String
    Private CmCodigoPersona As String
    Private CmMyNumDoctoContacto As String
    Public Property Control() As Integer
        Get
            Return CmControl
        End Get
        Set(ByVal value As Integer)
            CmControl = value
        End Set
    End Property
    Public Property IDComunicacionContacto() As Integer
        Get
            Return CmIDComunicacionContacto
        End Get
        Set(ByVal value As Integer)
            CmIDComunicacionContacto = value
        End Set
    End Property
    Public Property NumeroComunicacion() As String
        Get
            Return CmNumeroComunicacion
        End Get
        Set(ByVal value As String)
            CmNumeroComunicacion = value
        End Set
    End Property
    Public Property TipoComunicacion() As String
        Get
            Return CmTipoComunicacion
        End Get
        Set(ByVal value As String)
            CmTipoComunicacion = value
        End Set
    End Property

    Public Property CodigoPersona() As String
        Get
            Return CmCodigoPersona
        End Get
        Set(ByVal value As String)
            CmCodigoPersona = value
        End Set
    End Property

    Public Property MyNumDoctoContacto() As String
        Get
            Return CmMyNumDoctoContacto
        End Get
        Set(ByVal value As String)
            CmMyNumDoctoContacto = value
        End Set
    End Property
    'Public Function GrabaComunicacion2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_COMUNICONTACTO", 14, _
    '    CmControl, 1, _
    '    CmNumeroComunicacion, 2, _
    '    CmTipoComunicacion, 2, _
    '    CmCodigoPersona, 2, _
    '    CmMyNumDoctoContacto, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function

    Public Function GrabaComunicacion() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_COMUNICONTACTO", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", CmControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iNROCOMUNICACION_CONTACTO", CmNumeroComunicacion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDTIPO_COMUNICACION", CmTipoComunicacion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iCODIGOPERSONA", CmCodigoPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iMYNUMDOCTOCONTACTO", CmMyNumDoctoContacto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class
