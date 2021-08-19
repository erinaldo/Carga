Imports AccesoDatos
Public Class dtoPROVEEDORES_SOLICITUD
    'iCONTROL                           IN INTEGER,
    'iIDPROVEEDOR_SOLICITUD             IN T_PROVEEDORES_SOLICITUD.IDPROVEEDOR_SOLICITUD%TYPE,
    'iCODIGOCLIENTE                     IN VARCHAR2,  
    'iPROVEEDOR                         IN T_PROVEEDORES_SOLICITUD.PROVEEDOR%TYPE,
    'iTELEFONO                          IN T_PROVEEDORES_SOLICITUD.TELEFONO%TYPE,
    'iCONTACTO                          IN T_PROVEEDORES_SOLICITUD.CONTACTO%TYPE,
    'oCUR_CONTROL                       OUT TYPES.CURSOR_TYPE  

    Private PrControl As Integer
    Private PrIDProveedorSolicitud As Integer
    Private PrCodigoCliente As String
    Private PrProveedor As String
    Private PrTelefono As String
    Private PrContacto As String

    Public Property Control() As Integer
        Get
            Return PrControl
        End Get
        Set(ByVal value As Integer)
            PrControl = value
        End Set
    End Property
    Public Property IDProveedorSolicitud() As Integer
        Get
            Return PrIDProveedorSolicitud
        End Get
        Set(ByVal value As Integer)
            PrIDProveedorSolicitud = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return PrCodigoCliente
        End Get
        Set(ByVal value As String)
            PrCodigoCliente = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return PrProveedor
        End Get
        Set(ByVal value As String)
            PrProveedor = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return PrTelefono
        End Get
        Set(ByVal value As String)
            PrTelefono = value
        End Set
    End Property
    Public Property Contacto() As String
        Get
            Return PrContacto
        End Get
        Set(ByVal value As String)
            PrContacto = value
        End Set
    End Property

    'Public Function GrabaProveedoresSolicitud2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_PROV_SOLICITUD", 14, _
    '    PrControl, 1, _
    '    PrIDProveedorSolicitud, 1, _
    '    PrCodigoCliente, 2, _
    '    PrProveedor, 2, _
    '    PrTelefono, 2, _
    '    PrContacto, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function

    Public Function GrabaProveedoresSolicitud() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_PROV_SOLICITUD", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", PrControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDPROVEEDOR_SOLICITUD", PrIDProveedorSolicitud, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOCLIENTE", PrCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iPROVEEDOR", PrProveedor, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONO", PrTelefono, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iCONTACTO", PrContacto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class
