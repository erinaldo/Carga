Imports AccesoDatos
Public Class dtoDIRECCIONES_CLIENTE
#Region " CAMPOS A INSERTAR "
    'iCONTROL                        IN INTEGER,         
    'iIDDIRECCION_CONSIGNADO         IN T_DIRECCION_CONSIGNADO.IDDIRECCION_CONSIGNADO%TYPE,
    'iIDTIPO_DIRECCION               IN T_DIRECCION_CONSIGNADO.IDTIPO_DIRECCION%TYPE,
    'iCODIGOPERSONA                  IN VARCHAR2,
    'iDIRECCION                      IN T_DIRECCION_CONSIGNADO.DIRECCION%TYPE,
    'iDE_REFERENCIA                  IN T_DIRECCION_CONSIGNADO.DE_REFERENCIA%TYPE,
    'iCO_UBIC_GEOG                   IN T_DIRECCION_CONSIGNADO.CO_UBIC_GEOG%TYPE,
    'iDIRECCION_FACTURACION          IN T_DIRECCION_CONSIGNADO.DIRECCION_FACTURACION%TYPE,
    'iCODIGO_UBIGEO                  IN T_DIRECCION_CONSIGNADO.CODIGO_UBIGEO%TYPE,
    'iHORA_RECOJO_INICIO             IN T_DIRECCION_CONSIGNADO.HORA_RECOJO_INICIO%TYPE,
    'iHORA_RECOJO_FIN                IN T_DIRECCION_CONSIGNADO.HORA_RECOJO_FIN%TYPE,
    'iHORA_ENTREGA_INICIO            IN T_DIRECCION_CONSIGNADO.HORA_ENTREGA_INICIO%TYPE,
    'iHORA_ENTREGA_FIN               IN T_DIRECCION_CONSIGNADO.HORA_ENTREGA_FIN%TYPE,
    'iIDUSUARIO_PERSONAL             IN T_DIRECCION_CONSIGNADO.IDUSUARIO_PERSONAL%TYPE,
    'iIDROL_USUARIO                  IN T_DIRECCION_CONSIGNADO.IDROL_USUARIO%TYPE, 
    'iIP                             IN T_DIRECCION_CONSIGNADO.IP%TYPE,
    'iIDPAIS                         IN T_DIRECCION_CONSIGNADO.IDPAIS%TYPE,
    'iIDDEPARTAMENTO                 IN T_DIRECCION_CONSIGNADO.IDDEPARTAMENTO%TYPE,
    'iIDPROVINCIA                    IN T_DIRECCION_CONSIGNADO.IDPROVINCIA%TYPE,
    'iIDDISTRITO                     IN T_DIRECCION_CONSIGNADO.IDDISTRITO%TYPE,
    'oCUR_CONTROL                    OUT TYPES.CURSOR_TYPE    
#End Region

    Private DrControl As Integer
    Private DrIDDireccion As Integer
    Private DrIDTipoDireccion As Integer
    Private DrCodigoPersona As String
    Private DrDireccion As String
    Private DrReferencia As String
    Private DrCodigoUbicGeografica As String
    Private DrDireccionFacturacion As Integer
    Private DrCodigoUbigeio As String
    Private DrHoraRecojoIni As String
    Private DrHoraRecojoFin As String
    Private DrHoraEntregaIni As String
    Private DrHoraEntregaFin As String
    Private DrUsuarioPersonal As Integer
    Private DrRolUsuario As Integer
    Private DrIP As String
    Private DrPais As Integer
    Private DrDepartamento As Integer
    Private DrProvincia As Integer
    Private DrDistrito As Integer

    Private As_IDContacto As Integer
    Private As_SIDContacto As String
    Private As_IDCentroCosto As Integer
    'hlamas
    Private As_IDDireccionConsignado As Integer
    Private As_Seleccionado As Integer

    Public Property Control() As Integer
        Get
            Return DrControl
        End Get
        Set(ByVal value As Integer)
            DrControl = value
        End Set
    End Property

    Public Property IDDireccion() As Integer
        Get
            Return DrIDDireccion
        End Get
        Set(ByVal value As Integer)
            DrIDDireccion = value
        End Set
    End Property

    Public Property IDTipoDireccion() As Integer
        Get
            Return DrIDTipoDireccion
        End Get
        Set(ByVal value As Integer)
            DrIDTipoDireccion = value
        End Set
    End Property

    Public Property CodigoPersona() As String
        Get
            Return DrCodigoPersona
        End Get
        Set(ByVal value As String)
            DrCodigoPersona = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return DrDireccion
        End Get
        Set(ByVal value As String)
            DrDireccion = value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return DrReferencia
        End Get
        Set(ByVal value As String)
            DrReferencia = value
        End Set
    End Property

    Public Property CodigoUbicGeografica() As String
        Get
            Return DrCodigoUbicGeografica
        End Get
        Set(ByVal value As String)
            DrCodigoUbicGeografica = value
        End Set
    End Property

    Public Property DireccionFacturacion() As Integer
        Get
            Return DrDireccionFacturacion
        End Get
        Set(ByVal value As Integer)
            DrDireccionFacturacion = value
        End Set
    End Property

    Public Property CodigoUbigeio() As String
        Get
            Return DrCodigoUbigeio
        End Get
        Set(ByVal value As String)
            DrCodigoUbigeio = value
        End Set
    End Property

    Public Property HoraRecojoIni() As String
        Get
            Return DrHoraRecojoIni
        End Get
        Set(ByVal value As String)
            DrHoraRecojoIni = value
        End Set
    End Property

    Public Property HoraRecojoFin() As String
        Get
            Return DrHoraRecojoFin
        End Get
        Set(ByVal value As String)
            DrHoraRecojoFin = value
        End Set
    End Property

    Public Property HoraEntregaIni() As String
        Get
            Return DrHoraEntregaIni
        End Get
        Set(ByVal value As String)
            DrHoraEntregaIni = value
        End Set
    End Property

    Public Property HoraEntregaFin() As String
        Get
            Return DrHoraEntregaFin
        End Get
        Set(ByVal value As String)
            DrHoraEntregaFin = value
        End Set
    End Property

    Public Property UsuarioPersonal() As Integer
        Get
            Return DrUsuarioPersonal
        End Get
        Set(ByVal value As Integer)
            DrUsuarioPersonal = value
        End Set
    End Property

    Public Property RolUsuario() As Integer
        Get
            Return DrRolUsuario
        End Get
        Set(ByVal value As Integer)
            DrRolUsuario = value
        End Set
    End Property

    Public Property IP() As String
        Get
            Return DrIP
        End Get
        Set(ByVal value As String)
            DrIP = value
        End Set
    End Property

    Public Property Pais() As Integer
        Get
            Return DrPais
        End Get
        Set(ByVal value As Integer)
            DrPais = value
        End Set
    End Property

    Public Property Departamento() As Integer
        Get
            Return DrDepartamento
        End Get
        Set(ByVal value As Integer)
            DrDepartamento = value
        End Set
    End Property

    Public Property Provincia() As Integer
        Get
            Return DrProvincia
        End Get
        Set(ByVal value As Integer)
            DrProvincia = value
        End Set
    End Property

    Public Property Distrito() As Integer
        Get
            Return DrDistrito
        End Get
        Set(ByVal value As Integer)
            DrDistrito = value
        End Set
    End Property

    Public Property _IDContacto() As Integer
        Get
            Return As_IDContacto
        End Get
        Set(ByVal value As Integer)
            As_IDContacto = value
        End Set
    End Property
    Public Property _SIDContacto() As String
        Get
            Return As_SIDContacto
        End Get
        Set(ByVal value As String)
            As_SIDContacto = value
        End Set
    End Property

    Public Property _IDCentroCosto() As Integer
        Get
            Return As_IDCentroCosto
        End Get
        Set(ByVal value As Integer)
            As_IDCentroCosto = value
        End Set
    End Property

    Public Property _IDDireccionConsignado() As Integer
        Get
            Return As_IDDireccionConsignado
        End Get
        Set(ByVal value As Integer)
            As_IDDireccionConsignado = value
        End Set
    End Property

    Public Property _Seleccionado() As Integer
        Get
            Return As_Seleccionado
        End Get
        Set(ByVal value As Integer)
            As_Seleccionado = value
        End Set
    End Property
    'Public Function GrabaDireccion2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"SP_INSUPD_DIRECCIONES", 42, _
    '    DrControl, 1, _
    '    DrIDDireccion.ToString, 2, _
    '    DrIDTipoDireccion, 1, _
    '    DrCodigoPersona, 2, _
    '    DrDireccion, 2, _
    '    DrReferencia, 2, _
    '    DrCodigoUbicGeografica, 2, _
    '    DrDireccionFacturacion, 1, _
    '    DrCodigoUbigeio, 2, _
    '    DrHoraRecojoIni, 2, _
    '    DrHoraRecojoFin, 2, _
    '    DrHoraEntregaIni, 2, _
    '    DrHoraEntregaFin, 2, _
    '    DrUsuarioPersonal, 1, _
    '    DrRolUsuario, 1, _
    '    DrIP, 2, _
    '    DrPais, 1, _
    '    DrDepartamento, 1, _
    '    DrProvincia, 1, _
    '    DrDistrito, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function
    Public Function GrabaDireccion() As DataTable
        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("SP_INSUPD_DIRECCIONES", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", DrControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDIRECCION_CONSIGNADO", DrIDDireccion, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDTIPO_DIRECCION", DrIDTipoDireccion, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOPERSONA", DrCodigoPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iDIRECCION", DrDireccion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iDE_REFERENCIA", DrReferencia, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iCO_UBIC_GEOG", DrCodigoUbicGeografica, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iDIRECCION_FACTURACION", DrDireccionFacturacion, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGO_UBIGEO", DrCodigoUbigeio, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iHORA_RECOJO_INICIO", DrHoraRecojoIni, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iHORA_RECOJO_FIN", DrHoraRecojoFin, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iHORA_ENTREGA_INICIO", DrHoraEntregaIni, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iHORA_ENTREGA_FIN", DrHoraEntregaFin, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDUSUARIO_PERSONAL", DrUsuarioPersonal, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDROL_USUARIO", DrRolUsuario, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIP", DrIP, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDPAIS", DrPais, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDEPARTAMENTO", DrDepartamento, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDPROVINCIA", DrProvincia, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDISTRITO", DrDistrito, OracleClient.OracleType.Int32)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
    'Public Function AsociaTripode2009() As ADODB.Recordset
    '    Dim MyObjeGrabarTripode As Object() = {"PKG_IVOPERSONA.SP_DIRECCION_CONT_COSTO_1", 16, _
    '    DrControl, 1, _
    '    DrCodigoPersona, 2, _
    '    DrIP, 2, _
    '    As_SIDContacto, 2, _
    '    As_IDCentroCosto, 1, IIf(DrControl = 2, As_IDDireccionConsignado.ToString, "0"), 2, As_Seleccionado, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabarTripode)
    'End Function
    Public Function AsociaTripode() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_DIRECCION_CONT_COSTO_1", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", DrControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOPERSONA", DrCodigoPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIP", DrIP, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDCONTACTO", As_SIDContacto, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDCENTRO_COSTO", As_IDCentroCosto, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDIRECCION_CONSIGNADO", IIf(DrControl = 2, As_IDDireccionConsignado.ToString, "0"), OracleClient.OracleType.Int32)
        db.AsignarParametro("iSELECCIONADO", As_Seleccionado, OracleClient.OracleType.Int32)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Return db.EjecutarDataTable
    End Function

    'Public Function AsociaTripodePasajes_RGT2009() As ADODB.Recordset
    '    Dim MyObjeGrabarTripode As Object() = {"PKG_IVOPERSONA.SP_DIRECCION_CONT_COSTO", 12, _
    '    DrControl, 1, _
    '    DrCodigoPersona, 2, _
    '    DrIP, 2, _
    '    _IDContacto.ToString, 2, _
    '    _IDCentroCosto, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabarTripode)
    'End Function

    Public Function AsociaTripodePasajes_RGT() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_DIRECCION_CONT_COSTO", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", DrControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOPERSONA", DrCodigoPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIP", DrIP, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDCONTACTO", _IDContacto, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDCENTRO_COSTO", _IDCentroCosto, OracleClient.OracleType.Int32)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class