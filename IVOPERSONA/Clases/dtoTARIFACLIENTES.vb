Imports AccesoDatos
Imports System.Data.OracleClient
Public Class dtoTARIFACLIENTES
    'iCONTROL                        IN INTEGER,         
    'iCODIGOPERSONA                  IN VARCHAR2,
    'iIDUNIDAD_AGENCIA               IN T_TARIFAS_CARGA_CLIENTE.IDUNIDAD_AGENCIA%TYPE,
    'iIDUNIDAD_AGENCIA_DESTINO       IN T_TARIFAS_CARGA_CLIENTE.IDUNIDAD_AGENCIA_DESTINO%TYPE,
    'iCG_MONTO_BASE                  IN T_TARIFAS_CARGA_CLIENTE.CG_MONTO_BASE%TYPE,
    'iCG_X_PESO                      IN T_TARIFAS_CARGA_CLIENTE.CG_X_PESO%TYPE,
    'iCG_X_VOLUMEN                   IN T_TARIFAS_CARGA_CLIENTE.CG_X_VOLUMEN%TYPE,
    'iEC_MONTO_BASE                  IN T_TARIFAS_CARGA_CLIENTE.EC_MONTO_BASE%TYPE,
    'iEC_X_PESO                      IN T_TARIFAS_CARGA_CLIENTE.EC_X_PESO%TYPE,
    'iEC_X_VOLUMEN                   IN T_TARIFAS_CARGA_CLIENTE.EC_X_VOLUMEN%TYPE,
    'iPO_MONTO_BASE                  IN T_TARIFAS_CARGA_CLIENTE.PO_MONTO_BASE%TYPE,
    'iPO_X_PESO                      IN T_TARIFAS_CARGA_CLIENTE.PO_X_PESO%TYPE,
    'iPO_X_VOLUMEN                   IN T_TARIFAS_CARGA_CLIENTE.PO_X_VOLUMEN%TYPE,
    'iGI_MONTO_BASE                  IN T_TARIFAS_CARGA_CLIENTE.GI_MONTO_BASE%TYPE,
    'iGI_NORMAL                      IN T_TARIFAS_CARGA_CLIENTE.GI_NORMAL%TYPE,
    'iGI_TELEFONICO                  IN T_TARIFAS_CARGA_CLIENTE.GI_TELEFONICO%TYPE,
    'iFECHA_ACTIVACION               IN VARCHAR2,
    'iFECHA_DESACTIVACION            IN VARCHAR2,
    'iES_VIGENTE                     IN T_TARIFAS_CARGA_CLIENTE.ES_VIGENTE%TYPE,
    'iIDESTADO_REGISTRO              IN T_TARIFAS_CARGA_CLIENTE.IDESTADO_REGISTRO%TYPE,
    'iIDUSUARIO_PERSONAL             IN T_TARIFAS_CARGA_CLIENTE.IDUSUARIO_PERSONAL%TYPE,
    'iIDROL_USUARIO                  IN T_TARIFAS_CARGA_CLIENTE.IDROL_USUARIO%TYPE,
    'iIP                             IN T_TARIFAS_CARGA_CLIENTE.IP%TYPE,
    Private TrControl As Integer
    Private TrIDTarifaCargaCLiente As Integer
    Private TrCodigoCliente As String
    Private TrIDCiudadOrigen As Integer
    Private TrIDCiudadDestino As Integer
    Private TrCargaMontoBase As Double
    Private TrCargaPeso As Double
    Private TrCargaVolumen As Double
    Private TrEncomiendaMontoBase As Double
    Private TrEncomiendaPeso As Double
    Private TrEncomiendaVolumen As Double
    Private TrPostalMontoBase As Double
    Private TrPostalPeso As Double
    Private TrPostalVolumen As Double
    Private TrGiroMontoBase As Double
    Private TrNormalGiroPeso As Double
    Private TrTelefonoGiroVolumen As Double
    Private TrFechaActivacion As String
    Private TrFechaDesactivacion As String
    Private TrEsVigente As Integer
    Private TrEstadoRegistro As Integer
    Private TrUsuarioPersonal As Integer
    Private TrRolUsuario As Integer
    Private TrIP As String
    Private TrCENTRO_COSTO As Integer
    Private trsobre_xcarga As Double

    Public Property sobre_xcarga() As Double
        Get
            Return trsobre_xcarga
        End Get
        Set(ByVal value As Double)
            trsobre_xcarga = value
        End Set
    End Property
    Public Property CENTRO_COSTO() As Integer
        Get
            Return TrCENTRO_COSTO
        End Get
        Set(ByVal value As Integer)
            TrCENTRO_COSTO = value
        End Set
    End Property

    Public Property Control() As Integer
        Get
            Return TrControl
        End Get
        Set(ByVal value As Integer)
            TrControl = value
        End Set
    End Property
    Public Property IDTarifaCargaCLiente() As Integer
        Get
            Return TrIDTarifaCargaCLiente
        End Get
        Set(ByVal value As Integer)
            TrIDTarifaCargaCLiente = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return TrCodigoCliente
        End Get
        Set(ByVal value As String)
            TrCodigoCliente = value
        End Set
    End Property
    Public Property IDCiudadOrigen() As Integer
        Get
            Return TrIDCiudadOrigen
        End Get
        Set(ByVal value As Integer)
            TrIDCiudadOrigen = value
        End Set
    End Property
    Public Property IDCiudadDestino() As Integer
        Get
            Return TrIDCiudadDestino
        End Get
        Set(ByVal value As Integer)
            TrIDCiudadDestino = value
        End Set
    End Property
    Public Property CargaMontoBase() As Double
        Get
            Return TrCargaMontoBase
        End Get
        Set(ByVal value As Double)
            TrCargaMontoBase = value
        End Set
    End Property
    Public Property CargaPeso() As Double
        Get
            Return TrCargaPeso
        End Get
        Set(ByVal value As Double)
            TrCargaPeso = value
        End Set
    End Property
    Public Property CargaVolumen() As Double
        Get
            Return TrCargaVolumen
        End Get
        Set(ByVal value As Double)
            TrCargaVolumen = value
        End Set
    End Property
    Public Property EncomiendaMontoBase() As Double
        Get
            Return TrEncomiendaMontoBase
        End Get
        Set(ByVal value As Double)
            TrEncomiendaMontoBase = value
        End Set
    End Property
    Public Property EncomiendaPeso() As Double
        Get
            Return TrEncomiendaPeso
        End Get
        Set(ByVal value As Double)
            TrEncomiendaPeso = value
        End Set
    End Property
    Public Property EncomiendaVolumen() As Double
        Get
            Return TrEncomiendaVolumen
        End Get
        Set(ByVal value As Double)
            TrEncomiendaVolumen = value
        End Set
    End Property
    Public Property PostalMontoBase() As Double
        Get
            Return TrPostalMontoBase
        End Get
        Set(ByVal value As Double)
            TrPostalMontoBase = value
        End Set
    End Property
    Public Property PostalPeso() As Double
        Get
            Return TrPostalPeso
        End Get
        Set(ByVal value As Double)
            TrPostalPeso = value
        End Set
    End Property
    Public Property PostalVolumen() As Double
        Get
            Return TrPostalVolumen
        End Get
        Set(ByVal value As Double)
            TrPostalVolumen = value
        End Set
    End Property
    Public Property GiroMontoBase() As Double
        Get
            Return TrGiroMontoBase
        End Get
        Set(ByVal value As Double)
            TrGiroMontoBase = value
        End Set
    End Property
    Public Property NormalGiroPeso() As Double
        Get
            Return TrNormalGiroPeso
        End Get
        Set(ByVal value As Double)
            TrNormalGiroPeso = value
        End Set
    End Property
    Public Property TelefonoGiroVolumen() As Double
        Get
            Return TrTelefonoGiroVolumen
        End Get
        Set(ByVal value As Double)
            TrTelefonoGiroVolumen = value
        End Set
    End Property
    Public Property FechaActivacion() As String
        Get
            Return TrFechaActivacion
        End Get
        Set(ByVal value As String)
            TrFechaActivacion = value
        End Set
    End Property
    Public Property FechaDesactivacion() As String
        Get
            Return TrFechaDesactivacion
        End Get
        Set(ByVal value As String)
            TrFechaDesactivacion = value
        End Set
    End Property
    Public Property EsVigente() As Integer
        Get
            Return TrEsVigente
        End Get
        Set(ByVal value As Integer)
            TrEsVigente = value
        End Set
    End Property
    Public Property EstadoRegistro() As Integer
        Get
            Return TrEstadoRegistro
        End Get
        Set(ByVal value As Integer)
            TrEstadoRegistro = value
        End Set
    End Property
    Public Property UsuarioPersonal() As Integer
        Get
            Return TrUsuarioPersonal
        End Get
        Set(ByVal value As Integer)
            TrUsuarioPersonal = value
        End Set
    End Property
    Public Property RolUsuario() As Integer
        Get
            Return TrRolUsuario
        End Get
        Set(ByVal value As Integer)
            TrRolUsuario = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return TrIP
        End Get
        Set(ByVal value As String)
            TrIP = value
        End Set
    End Property

    'Public Function GrabaTarifarios_eliminarlo() As ADODB.Recordset
    '    'MessageBox.Show(TrControl, "TrControl")
    '    'MessageBox.Show(TrIDTarifaCargaCLiente, "TrIDTarifaCargaCLiente")
    '    'MessageBox.Show(TrCodigoCliente, "TrCodigoCliente")
    '    'MessageBox.Show(TrIDCiudadOrigen, "TrIDCiudadOrigen")
    '    'MessageBox.Show(TrIDCiudadDestino, "TrIDCiudadDestino")
    '    'MessageBox.Show(TrCargaMontoBase, "TrCargaMontoBase")
    '    'MessageBox.Show(TrCargaPeso, "TrCargaPeso")
    '    'MessageBox.Show(TrCargaVolumen, "TrCargaVolumen")
    '    'MessageBox.Show(TrEncomiendaMontoBase, "TrEncomiendaMontoBase")
    '    'MessageBox.Show(TrEncomiendaPeso, "TrEncomiendaPeso")
    '    'MessageBox.Show(TrEncomiendaVolumen, "TrEncomiendaVolumen")
    '    'MessageBox.Show(TrPostalMontoBase, "TrPostalMontoBase")
    '    'MessageBox.Show(TrPostalPeso, "TrPostalPeso")
    '    'MessageBox.Show(TrPostalVolumen, "TrPostalVolumen")
    '    'MessageBox.Show(TrGiroMontoBase, "TrGiroMontoBase")
    '    'MessageBox.Show(TrNormalGiroPeso, "TrNormalGiroPeso")
    '    'MessageBox.Show(TrTelefonoGiroVolumen, "TrTelefonoGiroVolumen")
    '    'MessageBox.Show(TrFechaActivacion, "TrFechaActivacion")
    '    'MessageBox.Show(TrFechaDesactivacion, "TrFechaDesactivacion")
    '    'MessageBox.Show(TrEsVigente, "TrEsVigente")
    '    'MessageBox.Show(TrEstadoRegistro, "TrEstadoRegistro")
    '    'MessageBox.Show(TrUsuarioPersonal, "TrUsuarioPersonal")
    '    'MessageBox.Show(TrRolUsuario, "TrRolUsuario")
    '    'MessageBox.Show(TrIP, "TrIP")

    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_TARIFA_CLIENTE", 50, _
    '    TrControl, 1, _
    '    TrIDTarifaCargaCLiente, 1, _
    '    TrCodigoCliente, 2, _
    '    TrIDCiudadOrigen, 1, _
    '    TrIDCiudadDestino, 1, _
    '    TrCargaMontoBase, 3, _
    '    TrCargaPeso, 3, _
    '    TrCargaVolumen, 3, _
    '    TrEncomiendaMontoBase, 3, _
    '    TrEncomiendaPeso, 3, _
    '    TrEncomiendaVolumen, 3, _
    '    TrPostalMontoBase, 3, _
    '    TrPostalPeso, 3, _
    '    TrPostalVolumen, 3, _
    '    TrGiroMontoBase, 3, _
    '    TrNormalGiroPeso, 3, _
    '    TrTelefonoGiroVolumen, 3, _
    '    TrFechaActivacion, 2, _
    '    TrFechaDesactivacion, 2, _
    '    TrEsVigente, 1, _
    '    TrEstadoRegistro, 1, _
    '    TrUsuarioPersonal, 1, _
    '    TrRolUsuario, 1, _
    '    TrIP, 2}

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    'End Function

    'Public Function GrabaTarifarios_RGT2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_TARIFA_CLIENTE_RGT1", 54, _
    '    TrCENTRO_COSTO, 1, _
    '    TrControl, 1, _
    '    TrIDTarifaCargaCLiente.ToString, 2, _
    '    TrCodigoCliente, 2, _
    '    TrIDCiudadOrigen, 1, _
    '    TrIDCiudadDestino, 1, _
    '    TrCargaMontoBase, 3, _
    '    TrCargaPeso, 3, _
    '    TrCargaVolumen, 3, _
    '    TrEncomiendaMontoBase, 3, _
    '    TrEncomiendaPeso, 3, _
    '    TrEncomiendaVolumen, 3, _
    '    TrPostalMontoBase, 3, _
    '    TrPostalPeso, 3, _
    '    TrPostalVolumen, 3, _
    '    TrGiroMontoBase, 3, _
    '    TrNormalGiroPeso, 3, _
    '    TrTelefonoGiroVolumen, 3, _
    '    TrFechaActivacion, 2, _
    '    TrFechaDesactivacion, 2, _
    '    TrEsVigente, 1, _
    '    TrEstadoRegistro, 1, _
    '    TrUsuarioPersonal, 1, _
    '    TrRolUsuario, 1, _
    '    TrIP, 2, _
    '    trsobre_xcarga, 3}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function

    Public Function GrabaTarifarios_RGT() As DataTable
        Try
            Dim db As New BaseDatos
            Dim da As OracleDataAdapter = New OracleDataAdapter()


            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_TARIFA_CLIENTE_RGT1", CommandType.StoredProcedure)
            db.AsignarParametro("iicentro_costo", TrCENTRO_COSTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCONTROL", TrControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTARIFAS_CARGA_CLIENTE", TrIDTarifaCargaCLiente.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCODIGOPERSONA", TrCodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUNIDAD_AGENCIA", TrIDCiudadOrigen, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", TrIDCiudadDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCG_MONTO_BASE", TrCargaMontoBase, OracleClient.OracleType.Number)
            db.AsignarParametro("iCG_X_PESO", TrCargaPeso, OracleClient.OracleType.Number)
            db.AsignarParametro("iCG_X_VOLUMEN", TrCargaVolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iEC_MONTO_BASE", TrEncomiendaMontoBase, OracleClient.OracleType.Number)
            db.AsignarParametro("iEC_X_PESO", TrEncomiendaPeso, OracleClient.OracleType.Number)
            db.AsignarParametro("iEC_X_VOLUMEN", TrEncomiendaVolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iPO_MONTO_BASE", TrPostalMontoBase, OracleClient.OracleType.Number)
            db.AsignarParametro("iPO_X_PESO", TrPostalPeso, OracleClient.OracleType.Number)
            db.AsignarParametro("iPO_X_VOLUMEN", TrPostalVolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iGI_MONTO_BASE", TrGiroMontoBase, OracleClient.OracleType.Number)
            db.AsignarParametro("iGI_NORMAL", TrNormalGiroPeso, OracleClient.OracleType.Number)
            db.AsignarParametro("iGI_TELEFONICO", TrTelefonoGiroVolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iFECHA_ACTIVACION", TrFechaActivacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHA_DESACTIVACION", TrFechaDesactivacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iES_VIGENTE", TrEsVigente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDESTADO_REGISTRO", TrEstadoRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", TrUsuarioPersonal, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", TrIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCG_X_Sobre", trsobre_xcarga, OracleClient.OracleType.Number)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function CARGA_TARIFA_PUBLICA(ByVal origen As Integer, ByVal destino As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CARGA_TARIFA_PUBLICA", CommandType.StoredProcedure)
            db.AsignarParametro("iORIGEN", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("iDESTINO", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function LIMPIA_ARTICULOS(ByVal codigo As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LIMPIA_ARTICULOS", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOPERSONA", codigo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_RESULTADO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
