Imports AccesoDatos
Public Class dtoDOCUMENTOS_SOLICITUD
    'iCONTROL                           IN INTEGER,
    'iIDDOCUMENTOS_SOLICITUD            IN T_DOCUMENTOS_SOLICITUD.IDDOCUMENTOS_SOLICITUD%TYPE,
    'iCODIGOCLIENTE                     IN VARCHAR2,        
    'iDOCUMENTOS                        IN T_DOCUMENTOS_SOLICITUD.DOCUMENTOS%TYPE,
    'iSELECCION                         IN T_DOCUMENTOS_SOLICITUD.SELECCION%TYPE,

    Private DsControl As Integer
    Private DsIDDocumentosSolicitud As Integer
    Private DsCodigoCliente As String
    Private DsDocumentos As String
    Private DsSeleccion As String

    Public Property Control() As Integer
        Get
            Return DsControl
        End Get
        Set(ByVal value As Integer)
            DsControl = value
        End Set
    End Property
    Public Property IDDocumentosSolicitud() As Integer
        Get
            Return DsIDDocumentosSolicitud
        End Get
        Set(ByVal value As Integer)
            DsIDDocumentosSolicitud = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return DsCodigoCliente
        End Get
        Set(ByVal value As String)
            DsCodigoCliente = value
        End Set
    End Property
    Public Property Documentos() As String
        Get
            Return DsDocumentos
        End Get
        Set(ByVal value As String)
            DsDocumentos = value
        End Set
    End Property
    Public Property Seleccion() As String
        Get
            Return DsSeleccion
        End Get
        Set(ByVal value As String)
            DsSeleccion = value
        End Set
    End Property
    'Public Function GrabaReferenciaBancaria2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_DOC_RECIBIDOS", 16, _
    '    DsControl, 1, _
    '    DsIDDocumentosSolicitud, 1, _
    '    DsCodigoCliente, 2, _
    '    DsDocumentos, 2, _
    '    DsSeleccion, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function
    Public Function GrabaReferenciaBancaria() As DataTable
        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DOC_RECIBIDOS", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", DsControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDOCUMENTOS_SOLICITUD", DsIDDocumentosSolicitud, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOCLIENTE", DsCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iDOCUMENTOS", DsDocumentos, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iSELECCION", DsSeleccion, OracleClient.OracleType.Int32)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class
