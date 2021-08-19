Imports AccesoDatos
Public Class dtoCLIENTES_SOLICITUD

    Private PrControl As Integer
    Private PrIDClientesSolicitud As Integer
    Private PrCodigoCliente As String
    Private PrClientes As String
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
    Public Property IDClientesSolicitud() As Integer
        Get
            Return PrIDClientesSolicitud
        End Get
        Set(ByVal value As Integer)
            PrIDClientesSolicitud = value
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
    Public Property Clientes() As String
        Get
            Return PrClientes
        End Get
        Set(ByVal value As String)
            PrClientes = value
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
    'Public Function GrabaClientesSolicitud2009() As ADODB.Recordset
    '    'MessageBox.Show(PrControl, "PrControl")
    '    'MessageBox.Show(PrIDClientesSolicitud, "PrIDProveedorSolicitud")
    '    'MessageBox.Show(PrCodigoCliente, "PrCodigoCliente")
    '    'MessageBox.Show(PrClientes, "PrProveedor")
    '    'MessageBox.Show(PrTelefono, "PrTelefono")
    '    'MessageBox.Show(PrContacto, "PrContacto")
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_CLIE_SOLICITUD", 14, _
    '    PrControl, 1, _
    '    PrIDClientesSolicitud, 1, _
    '    PrCodigoCliente, 2, _
    '    PrClientes, 2, _
    '    PrTelefono, 2, _
    '    PrContacto, 2}

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    'End Function

    Public Function GrabaClientesSolicitud() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_CLIE_SOLICITUD", CommandType.StoredProcedure)

        db.AsignarParametro("iCONTROL", PrControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDCLIENTES_SOLICITUD", PrIDClientesSolicitud, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOCLIENTE", PrCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iCLIENTE", PrClientes, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONO", PrTelefono, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iCONTACTO", PrContacto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class
