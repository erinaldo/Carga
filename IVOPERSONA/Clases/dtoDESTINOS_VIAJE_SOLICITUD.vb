Imports AccesoDatos
Public Class dtoDESTINOS_VIAJE_SOLICITUD
    'iCONTROL                           IN INTEGER,
    'iIDDESTINOS_VIAJE                  IN T_DESTINOS_VIAJE_SOLICITUD.IDDESTINOS_VIAJE%TYPE,
    'iCODIGOCLIENTE                     IN VARCHAR2,    
    'iIDRUTA                            IN T_DESTINOS_VIAJE_SOLICITUD.IDRUTA%TYPE,
    'iNOMBRE_RUTA                       IN T_DESTINOS_VIAJE_SOLICITUD.NOMBRE_RUTA%TYPE,
    'iSELECCION                         IN T_DESTINOS_VIAJE_SOLICITUD.SELECCION%TYPE,
    'iORIGEN                            IN T_DESTINOS_VIAJE_SOLICITUD.ORIGEN%TYPE,
    'iDESTINO                           IN T_DESTINOS_VIAJE_SOLICITUD.DESTINO%TYPE,

    Private DvControl As Integer
    Private DvIDDestinosViaje As Integer
    Private DvCodigoCliente As String
    Private DvIDRuta As String
    Private DvNombreRuta As String
    Private DvSeleccion As String
    Private DvOrigen As String
    Private DvDestino As String

    Public Property Control() As Integer
        Get
            Return DvControl
        End Get
        Set(ByVal value As Integer)
            DvControl = value
        End Set
    End Property
    Public Property IDDestinosViaje() As Integer
        Get
            Return DvIDDestinosViaje
        End Get
        Set(ByVal value As Integer)
            DvIDDestinosViaje = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return DvCodigoCliente
        End Get
        Set(ByVal value As String)
            DvCodigoCliente = value
        End Set
    End Property
    Public Property IDRuta() As String
        Get
            Return DvIDRuta
        End Get
        Set(ByVal value As String)
            DvIDRuta = value
        End Set
    End Property
    Public Property NombreRuta() As String
        Get
            Return DvNombreRuta
        End Get
        Set(ByVal value As String)
            DvNombreRuta = value
        End Set
    End Property
    Public Property Seleccion() As String
        Get
            Return DvSeleccion
        End Get
        Set(ByVal value As String)
            DvSeleccion = value
        End Set
    End Property
    Public Property Origen() As String
        Get
            Return DvOrigen
        End Get
        Set(ByVal value As String)
            DvOrigen = value
        End Set
    End Property
    Public Property Destino() As String
        Get
            Return DvDestino
        End Get
        Set(ByVal value As String)
            DvDestino = value
        End Set
    End Property

    'Public Function GrabaDestinosViaje2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_DESTINOS_VIAJE", 20, _
    '    DvControl, 1, _
    '    DvIDDestinosViaje, 1, _
    '    DvCodigoCliente, 2, _
    '    DvIDRuta, 2, _
    '    DvNombreRuta, 2, _
    '    DvSeleccion, 2, _
    '    DvOrigen, 2, _
    '    DvDestino, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function

    Public Function GrabaDestinosViaje() As DataTable
        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DESTINOS_VIAJE", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", DvControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDESTINOS_VIAJE", DvIDDestinosViaje, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOCLIENTE", DvCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDRUTA", DvIDRuta, OracleClient.OracleType.Int32)
        db.AsignarParametro("iNOMBRE_RUTA", DvNombreRuta, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iSELECCION", DvSeleccion, OracleClient.OracleType.Int32)
        db.AsignarParametro("iORIGEN", DvOrigen, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iDESTINO", DvDestino, OracleClient.OracleType.VarChar)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class

