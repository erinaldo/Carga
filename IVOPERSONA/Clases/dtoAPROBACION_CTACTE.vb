Imports AccesoDatos
Imports AccesoDatos.BaseDatos
Public Class dtoAPROBACION_CTACTE
    'iCONTROL                        IN INTEGER,
    'iCODIGOPERSONA                  IN VARCHAR2,
    'iIDCONFIG_CTACTE                IN T_CONFIGURACION_CTACTE.IDCONFIG_CTACTE%TYPE,
    'iNRO_CONTROL                    IN T_CONFIGURACION_CTACTE.NRO_CONTROL%TYPE,                            
    'iLINEA_SOLICITADA               IN T_CONFIGURACION_CTACTE.LINEA_SOLICITADA%TYPE,
    'iSOBREGIRO                      IN T_CONFIGURACION_CTACTE.SOBREGIRO%TYPE,
    'iTOTAL_ASIGNADO                 IN T_CONFIGURACION_CTACTE.TOTAL_ASIGNADO%TYPE,
    'iESTADO_REGISTRO                IN T_CONFIGURACION_CTACTE.ESTADO_REGISTRO%TYPE,
    'iIDUSUARIO_PERSONAL             IN T_CONFIGURACION_CTACTE.IDUSUARIO_PERSONAL%TYPE,
    'iIDROL_USUARIO                  IN T_CONFIGURACION_CTACTE.IDROL_USUARIO%TYPE,
    'iIP                             IN T_CONFIGURACION_CTACTE.IP%TYPE,

    Private ApControl As Integer
    Private ApCodigoPersona As String
    Private ApIDConfigCtaCte As Integer
    Private ApNumeroControl As String
    Private ApLineaOtorgada As Double
    Private ApSobreGiro As Double
    Private ApTotalAsignado As Double
    Private ApEstadoRegistro As Integer
    Private ApUsuarioPersonal As Integer
    Private ApIDRolUsuario As Integer
    Private APIP As String

    Public Property Control() As Integer
        Get
            Return ApControl
        End Get
        Set(ByVal value As Integer)
            ApControl = value
        End Set
    End Property
    Public Property CodigoPersona() As String
        Get
            Return ApCodigoPersona
        End Get
        Set(ByVal value As String)
            ApCodigoPersona = value
        End Set
    End Property
    Public Property IDConfigCtaCte() As Integer
        Get
            Return ApIDConfigCtaCte
        End Get
        Set(ByVal value As Integer)
            ApIDConfigCtaCte = value
        End Set
    End Property
    Public Property NumeroControl() As String
        Get
            Return ApNumeroControl
        End Get
        Set(ByVal value As String)
            ApNumeroControl = value
        End Set
    End Property
    Public Property LineaOtorgada() As Double
        Get
            Return ApLineaOtorgada
        End Get
        Set(ByVal value As Double)
            ApLineaOtorgada = value
        End Set
    End Property
    Public Property SobreGiro() As Double
        Get
            Return ApSobreGiro
        End Get
        Set(ByVal value As Double)
            ApSobreGiro = value
        End Set
    End Property
    Public Property TotalAsignado() As Double
        Get
            Return ApTotalAsignado
        End Get
        Set(ByVal value As Double)
            ApTotalAsignado = value
        End Set
    End Property
    Public Property EstadoRegistro() As Integer
        Get
            Return ApEstadoRegistro
        End Get
        Set(ByVal value As Integer)
            ApEstadoRegistro = value
        End Set
    End Property
    Public Property UsuarioPersonal() As Integer
        Get
            Return ApUsuarioPersonal
        End Get
        Set(ByVal value As Integer)
            ApUsuarioPersonal = value
        End Set
    End Property
    Public Property IDRolUsuario() As Integer
        Get
            Return ApIDRolUsuario
        End Get
        Set(ByVal value As Integer)
            ApIDRolUsuario = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return APIP
        End Get
        Set(ByVal value As String)
            APIP = value
        End Set
    End Property

    'Public Function GrabaAprobacion2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_CONFIG_CTACTE", 25, _
    '    ApControl, 1, _
    '    ApCodigoPersona, 2, _
    '    ApIDConfigCtaCte, 1, _
    '    ApNumeroControl, 2, _
    '    ApLineaOtorgada, 3, _
    '    ApSobreGiro, 3, _
    '    ApTotalAsignado, 3, _
    '    ApEstadoRegistro, 1, _
    '    ApUsuarioPersonal, 1, _
    '    ApIDRolUsuario, 1, _
    '    APIP, 2}

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    'End Function

    Public Function GrabaAprobacion() As DataTable
        Try
            Dim objBaseDatos As New BaseDatos
            objBaseDatos.Conectar()
            Dim sql As String = "PKG_IVOPERSONA.SP_INSUPD_CONFIG_CTACTE"
            objBaseDatos.CrearComando(sql, CommandType.StoredProcedure)
            objBaseDatos.AsignarParametro("iCONTROL", ApControl, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iCODIGOPERSONA", ApCodigoPersona, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("iIDCONFIG_CTACTE", ApIDConfigCtaCte, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("iNRO_CONTROL", ApNumeroControl, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("iLINEA_SOLICITADA", ApLineaOtorgada, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iSOBREGIRO", ApSobreGiro, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iTOTAL_ASIGNADO", ApTotalAsignado, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iESTADO_REGISTRO", ApEstadoRegistro, OracleClient.OracleType.Int16)
            objBaseDatos.AsignarParametro("iID_SOLICITUD_CREDITO", APIP, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iPORCENTAJE_SOBREGIRO", APIP, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iIDUSUARIO_PERSONAL", ApUsuarioPersonal, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iIDROL_USUARIO", ApIDRolUsuario, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iIP", APIP, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor, ParameterDirection.Output)
            objBaseDatos.Desconectar()
            Return objBaseDatos.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
