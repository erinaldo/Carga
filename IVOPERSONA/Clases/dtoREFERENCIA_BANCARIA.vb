Imports AccesoDatos
Public Class dtoREFERENCIA_BANCARIA
    'iCONTROL                           IN INTEGER,
    'iIDREFERENCIA_BANCARIA             IN T_REFERENCIA_BANCARIA.IDREFERENCIA_BANCARIA%TYPE,
    'iCODIGOCLIENTE                     IN VARCHAR2,      
    'iBANCO                             IN T_REFERENCIA_BANCARIA.BANCO%TYPE,
    'iCTACTE                            IN T_REFERENCIA_BANCARIA.CTACTE%TYPE,
    'iTELEFONOS                         IN T_REFERENCIA_BANCARIA.TELEFONOS%TYPE,
    'iSECTORISTA                        IN T_REFERENCIA_BANCARIA.SECTORISTA%TYPE,
    'oCUR_CONTROL                       OUT TYPES.CURSOR_TYPE  

    Private RbControl As Integer
    Private RbIDReferenciaBancaria As Integer
    Private RbCodigoCliente As String
    Private RbBanco As String
    Private RbCtaCte As String
    Private RbTelefonos As String
    Private RbSectorista As String

    Public Property Control() As Integer
        Get
            Return RbControl
        End Get
        Set(ByVal value As Integer)
            RbControl = value
        End Set
    End Property
    Public Property IDReferenciaBancaria() As Integer
        Get
            Return RbIDReferenciaBancaria
        End Get
        Set(ByVal value As Integer)
            RbIDReferenciaBancaria = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return RbCodigoCliente
        End Get
        Set(ByVal value As String)
            RbCodigoCliente = value
        End Set
    End Property
    Public Property Banco() As String
        Get
            Return RbBanco
        End Get
        Set(ByVal value As String)
            RbBanco = value
        End Set
    End Property
    Public Property CtaCte() As String
        Get
            Return RbCtaCte
        End Get
        Set(ByVal value As String)
            RbCtaCte = value
        End Set
    End Property
    Public Property Telefonos() As String
        Get
            Return RbTelefonos
        End Get
        Set(ByVal value As String)
            RbTelefonos = value
        End Set
    End Property
    Public Property Sectorista() As String
        Get
            Return RbSectorista
        End Get
        Set(ByVal value As String)
            RbSectorista = value
        End Set
    End Property

    'Public Function GrabaReferenciaBancaria2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_REF_BANCARIA", 16, _
    '    RbControl, 1, _
    '    RbIDReferenciaBancaria, 1, _
    '    RbCodigoCliente, 2, _
    '    RbBanco, 2, _
    '    RbCtaCte, 2, _
    '    RbTelefonos, 2, _
    '    RbSectorista, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function

    Public Function GrabaReferenciaBancaria() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_REF_BANCARIA", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", RbControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDREFERENCIA_BANCARIA", RbIDReferenciaBancaria, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOCLIENTE", RbCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iBANCO", RbBanco, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iCTACTE", RbCtaCte, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONOS", RbTelefonos, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iSECTORISTA", RbSectorista, OracleClient.OracleType.VarChar)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class
