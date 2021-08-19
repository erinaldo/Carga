Imports AccesoDatos
Public Class dtoSOLICITUD_CREDITO

    'iCONTROL                           IN INTEGER,
    'iIDSOLICITUD_CREDITO               IN T_SOLICITUD_CREDITO.IDSOLICITUD_CREDITO%TYPE,
    'iCODIGO_PERSONA                    IN T_SOLICITUD_CREDITO.CODIGO_PERSONA%TYPE,
    'iNOMBRE_PERSONA                    IN T_SOLICITUD_CREDITO.NOMBRE_PERSONA%TYPE,
    'iDIRECCION_LEGAL                   IN T_SOLICITUD_CREDITO.DIRECCION_LEGAL%TYPE,
    'iTELEFONO_DIRECCION                IN T_SOLICITUD_CREDITO.TELEFONO_DIRECCION%TYPE,
    'iFAX_DIRECCION                     IN T_SOLICITUD_CREDITO.FAX_DIRECCION%TYPE,
    'iREP_LEGAL                         IN T_SOLICITUD_CREDITO.REP_LEGAL%TYPE,
    'iEMAIL_REP_LEGAL                   IN T_SOLICITUD_CREDITO.EMAIL_REP_LEGAL%TYPE,
    'iTELEFONO_REP_LEGAL                IN T_SOLICITUD_CREDITO.TELEFONO_REP_LEGAL%TYPE,
    'iMOVIL_REP_LEGAL                   IN T_SOLICITUD_CREDITO.MOVIL_REP_LEGAL%TYPE,
    'iGERENTE_FINANCIERO                IN T_SOLICITUD_CREDITO.GERENTE_FINANCIERO%TYPE,
    'iEMAIL_GERENTE_FINANCIERO          IN T_SOLICITUD_CREDITO.EMAIL_GERENTE_FINANCIERO%TYPE,
    'iTELEFONO_GERENTE_FINANCIERO       IN T_SOLICITUD_CREDITO.TELEFONO_GERENTE_FINANCIERO%TYPE,
    'iMOVIL_GERENTE_FINANCIERO          IN T_SOLICITUD_CREDITO.MOVIL_GERENTE_FINANCIERO%TYPE,
    'iGIRO_NEGOCIO                      IN T_SOLICITUD_CREDITO.GIRO_NEGOCIO%TYPE,
    'iENCARGADO_PAGOS                   IN T_SOLICITUD_CREDITO.ENCARGADO_PAGOS%TYPE,
    'iEMAIL_ENCARGADO_PAGOS             IN T_SOLICITUD_CREDITO.EMAIL_ENCARGADO_PAGOS%TYPE,
    'iTELEFONO_ENCARGADO_PAGOS          IN T_SOLICITUD_CREDITO.TELEFONO_ENCARGADO_PAGOS%TYPE,
    'iMOVIL_ENCARGADO_PAGOS             IN T_SOLICITUD_CREDITO.MOVIL_ENCARGADO_PAGOS%TYPE,
    'iPERSONA_CONTACTO                  IN T_SOLICITUD_CREDITO.PERSONA_CONTACTO%TYPE,
    'iEMAIL_PERSONA_CONTACTO            IN T_SOLICITUD_CREDITO.EMAIL_PERSONA_CONTACTO%TYPE,
    'iTELEFONO_PERSONA_CONTACTO         IN T_SOLICITUD_CREDITO.TELEFONO_PERSONA_CONTACTO%TYPE,
    'iMOVIL_PERSONA_CONTACTO            IN T_SOLICITUD_CREDITO.MOVIL_PERSONA_CONTACTO%TYPE,
    'iIDUSUARIO_PERSONAL                IN T_SOLICITUD_CREDITO.IDUSUARIO_PERSONAL%TYPE,
    'iIDROL_USUARIO                     IN T_SOLICITUD_CREDITO.IDROL_USUARIO%TYPE,
    'iIP                                IN T_SOLICITUD_CREDITO.IP%TYPE,
    'oCUR_CONTROL                       OUT TYPES.CURSOR_TYPE    

    Private SlControl As Integer
    Private SlIDSolicitudCredito As Integer
    Private SlCodigoPersona As String
    Private SlNombreCliente As String
    Private SlDireccionLegal As String
    Private SlTelefonoDireccion As String
    Private SlFaxDireccion As String
    Private SlRepresentanteLegal As String
    Private SlEmailRepresentanteLegal As String
    Private SlTelefonoRepresentanteLegal As String
    Private SlMovilRepresentanteLegal As String
    Private SlGerenteFinanciero As String
    Private SlEmailGerenteFinanciero As String
    Private SlTelefonoGerenteFinanciero As String
    Private SlMovilGerenteFinanciero As String
    Private SlGironegocio As String
    Private SlEncargadoPagos As String
    Private SlEmailEncargadoPagos As String
    Private SlTelefonoEncargadoPagos As String
    Private SlMovilEncargadoPagos As String
    Private SlPersonaContacto As String
    Private SlEmailPersonaContacto As String
    Private SlTelefonoPersonaContacto As String
    Private SlMovilPersonaContacto As String
    Private SlUsuarioPersonal As Integer
    Private SlRolUusario As Integer
    Private SlIP As String
    Private SlLineaSolicitada As Double

    Private CsPeriodoPago As Integer
    Private CsDiasPago As String
    Private CsFecha1 As Integer
    Private CsFecha2 As Integer
    Private CsFecha3 As Integer
    Private CsFecha4 As Integer
    Private CsHoraPagoIni As String
    Private CsHoraPagoFin As String
    Private CsTipoPago As Integer
    Private CsObservaciones As String

    Public Property Control() As Integer
        Get
            Return SlControl
        End Get
        Set(ByVal value As Integer)
            SlControl = value
        End Set
    End Property
    Public Property IDSolicitudCredito() As Integer
        Get
            Return SlIDSolicitudCredito
        End Get
        Set(ByVal value As Integer)
            SlIDSolicitudCredito = value
        End Set
    End Property
    Public Property CodigoPersona() As String
        Get
            Return SlCodigoPersona
        End Get
        Set(ByVal value As String)
            SlCodigoPersona = value
        End Set
    End Property
    Public Property NombreCliente() As String
        Get
            Return SlNombreCliente
        End Get
        Set(ByVal value As String)
            SlNombreCliente = value
        End Set
    End Property
    Public Property DireccionLegal() As String
        Get
            Return SlDireccionLegal
        End Get
        Set(ByVal value As String)
            SlDireccionLegal = value
        End Set
    End Property
    Public Property TelefonoDireccion() As String
        Get
            Return SlTelefonoDireccion
        End Get
        Set(ByVal value As String)
            SlTelefonoDireccion = value
        End Set
    End Property
    Public Property FaxDireccion() As String
        Get
            Return SlFaxDireccion
        End Get
        Set(ByVal value As String)
            SlFaxDireccion = value
        End Set
    End Property
    Public Property RepresentanteLegal() As String
        Get
            Return SlRepresentanteLegal
        End Get
        Set(ByVal value As String)
            SlRepresentanteLegal = value
        End Set
    End Property
    Public Property EmailRepresentanteLegal() As String
        Get
            Return SlEmailRepresentanteLegal
        End Get
        Set(ByVal value As String)
            SlEmailRepresentanteLegal = value
        End Set
    End Property
    Public Property TelefonoRepresentanteLegal() As String
        Get
            Return SlTelefonoRepresentanteLegal
        End Get
        Set(ByVal value As String)
            SlTelefonoRepresentanteLegal = value
        End Set
    End Property
    Public Property MovilRepresentanteLegal() As String
        Get
            Return SlMovilRepresentanteLegal
        End Get
        Set(ByVal value As String)
            SlMovilRepresentanteLegal = value
        End Set
    End Property
    Public Property GerenteFinanciero() As String
        Get
            Return SlGerenteFinanciero
        End Get
        Set(ByVal value As String)
            SlGerenteFinanciero = value
        End Set
    End Property
    Public Property EmailGerenteFinanciero() As String
        Get
            Return SlEmailGerenteFinanciero
        End Get
        Set(ByVal value As String)
            SlEmailGerenteFinanciero = value
        End Set
    End Property
    Public Property TelefonoGerenteFinanciero() As String
        Get
            Return SlTelefonoGerenteFinanciero
        End Get
        Set(ByVal value As String)
            SlTelefonoGerenteFinanciero = value
        End Set
    End Property
    Public Property MovilGerenteFinanciero() As String
        Get
            Return SlMovilGerenteFinanciero
        End Get
        Set(ByVal value As String)
            SlMovilGerenteFinanciero = value
        End Set
    End Property
    Public Property Gironegocio() As String
        Get
            Return SlGironegocio
        End Get
        Set(ByVal value As String)
            SlGironegocio = value
        End Set
    End Property
    Public Property EncargadoPagos() As String
        Get
            Return SlEncargadoPagos
        End Get
        Set(ByVal value As String)
            SlEncargadoPagos = value
        End Set
    End Property
    Public Property EmailEncargadoPagos() As String
        Get
            Return SlEmailEncargadoPagos
        End Get
        Set(ByVal value As String)
            SlEmailEncargadoPagos = value
        End Set
    End Property
    Public Property TelefonoEncargadoPagos() As String
        Get
            Return SlTelefonoEncargadoPagos
        End Get
        Set(ByVal value As String)
            SlTelefonoEncargadoPagos = value
        End Set
    End Property
    Public Property MovilEncargadoPagos() As String
        Get
            Return SlMovilEncargadoPagos
        End Get
        Set(ByVal value As String)
            SlMovilEncargadoPagos = value
        End Set
    End Property
    Public Property PersonaContacto() As String
        Get
            Return SlPersonaContacto
        End Get
        Set(ByVal value As String)
            SlPersonaContacto = value
        End Set
    End Property
    Public Property EmailPersonaContacto() As String
        Get
            Return SlEmailPersonaContacto
        End Get
        Set(ByVal value As String)
            SlEmailPersonaContacto = value
        End Set
    End Property
    Public Property TelefonoPersonaContacto() As String
        Get
            Return SlTelefonoPersonaContacto
        End Get
        Set(ByVal value As String)
            SlTelefonoPersonaContacto = value
        End Set
    End Property
    Public Property MovilPersonaContacto() As String
        Get
            Return SlMovilPersonaContacto
        End Get
        Set(ByVal value As String)
            SlMovilPersonaContacto = value
        End Set
    End Property
    Public Property UsuarioPersonal() As Integer
        Get
            Return SlUsuarioPersonal
        End Get
        Set(ByVal value As Integer)
            SlUsuarioPersonal = value
        End Set
    End Property
    Public Property RolUusario() As Integer
        Get
            Return SlRolUusario
        End Get
        Set(ByVal value As Integer)
            SlRolUusario = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return SlIP
        End Get
        Set(ByVal value As String)
            SlIP = value
        End Set
    End Property
    Public Property LineaSolicitada() As Double
        Get
            Return SlLineaSolicitada
        End Get
        Set(ByVal value As Double)
            SlLineaSolicitada = value
        End Set
    End Property


    Public Property PeriodoPago() As Integer
        Get
            Return CsPeriodoPago
        End Get
        Set(ByVal value As Integer)
            CsPeriodoPago = value
        End Set
    End Property
    Public Property DiasPago() As String
        Get
            Return CsDiasPago
        End Get
        Set(ByVal value As String)
            CsDiasPago = value
        End Set
    End Property
    Public Property Fecha1() As Integer
        Get
            Return CsFecha1
        End Get
        Set(ByVal value As Integer)
            CsFecha1 = value
        End Set
    End Property
    Public Property Fecha2() As Integer
        Get
            Return CsFecha2
        End Get
        Set(ByVal value As Integer)
            CsFecha2 = value
        End Set
    End Property
    Public Property Fecha3() As Integer
        Get
            Return CsFecha3
        End Get
        Set(ByVal value As Integer)
            CsFecha3 = value
        End Set
    End Property
    Public Property Fecha4() As Integer
        Get
            Return CsFecha4
        End Get
        Set(ByVal value As Integer)
            CsFecha4 = value
        End Set
    End Property
    Public Property HoraPagoIni() As String
        Get
            Return CsHoraPagoIni
        End Get
        Set(ByVal value As String)
            CsHoraPagoIni = value
        End Set
    End Property
    Public Property HoraPagoFin() As String
        Get
            Return CsHoraPagoFin
        End Get
        Set(ByVal value As String)
            CsHoraPagoFin = value
        End Set
    End Property
    Public Property TipoPago() As Integer
        Get
            Return CsTipoPago
        End Get
        Set(ByVal value As Integer)
            CsTipoPago = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return CsObservaciones
        End Get
        Set(ByVal value As String)
            CsObservaciones = value
        End Set
    End Property
    'Public Function GrabaSolicitud2009() As ADODB.Recordset
    '    If SlTelefonoDireccion = "" Then
    '        SlTelefonoDireccion = "null"
    '    End If
    '    If SlFaxDireccion = "" Then
    '        SlFaxDireccion = "null"
    '    End If
    '    If SlRepresentanteLegal = "" Then
    '        SlRepresentanteLegal = "null"
    '    End If
    '    If SlEmailRepresentanteLegal = "" Then
    '        SlEmailRepresentanteLegal = "null"
    '    End If
    '    If SlEmailRepresentanteLegal = "" Then
    '        SlEmailRepresentanteLegal = "null"
    '    End If
    '    If SlTelefonoRepresentanteLegal = "" Then
    '        SlTelefonoRepresentanteLegal = "null"
    '    End If
    '    If SlMovilRepresentanteLegal = "" Then
    '        SlMovilRepresentanteLegal = "null"
    '    End If
    '    If SlGerenteFinanciero = "" Then
    '        SlGerenteFinanciero = "null"
    '    End If
    '    If SlGerenteFinanciero = "" Then
    '        SlGerenteFinanciero = "null"
    '    End If
    '    If SlEmailGerenteFinanciero = "" Then
    '        SlEmailGerenteFinanciero = "null"
    '    End If
    '    If SlTelefonoGerenteFinanciero = "" Then
    '        SlTelefonoGerenteFinanciero = "null"
    '    End If

    '    If SlMovilGerenteFinanciero = "" Then
    '        SlMovilGerenteFinanciero = "null"
    '    End If
    '    If SlEmailEncargadoPagos = "" Then
    '        SlEmailEncargadoPagos = "null"
    '    End If
    '    If SlEmailPersonaContacto = "" Then
    '        SlEmailPersonaContacto = "null"
    '    End If
    '    If SlTelefonoPersonaContacto = "" Then
    '        SlTelefonoPersonaContacto = "null"
    '    End If
    '    If SlEncargadoPagos = "" Then
    '        SlEncargadoPagos = "null"
    '    End If
    '    If SlTelefonoEncargadoPagos = "" Then
    '        SlTelefonoEncargadoPagos = "null"
    '    End If
    '    If SlMovilEncargadoPagos = "" Then
    '        SlMovilEncargadoPagos = "null"
    '    End If
    '    If SlPersonaContacto = "" Then
    '        SlPersonaContacto = "null"
    '    End If
    '    If CsObservaciones = "" Then
    '        CsObservaciones = "null"
    '    End If
    '    If SlMovilPersonaContacto = "" Then
    '        SlMovilPersonaContacto = "null"
    '    End If

    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_SOLICITUD_CREDITO", 78, _
    '    SlControl, 1, _
    '    SlIDSolicitudCredito, 1, _
    '    SlCodigoPersona, 2, _
    '    SlNombreCliente, 2, _
    '    SlDireccionLegal, 2, _
    '    SlTelefonoDireccion, 2, _
    '    SlFaxDireccion, 2, _
    '    SlRepresentanteLegal, 2, _
    '    SlEmailRepresentanteLegal, 2, _
    '    SlTelefonoRepresentanteLegal, 2, _
    '    SlMovilRepresentanteLegal, 2, _
    '    SlGerenteFinanciero, 2, _
    '    SlEmailGerenteFinanciero, 2, _
    '    SlTelefonoGerenteFinanciero, 2, _
    '    SlMovilGerenteFinanciero, 2, _
    '    SlGironegocio, 2, _
    '    SlEncargadoPagos, 2, _
    '    SlEmailEncargadoPagos, 2, _
    '    SlTelefonoEncargadoPagos, 2, _
    '    SlMovilEncargadoPagos, 2, _
    '    SlPersonaContacto, 2, _
    '    SlEmailPersonaContacto, 2, _
    '    SlTelefonoPersonaContacto, 2, _
    '    SlMovilPersonaContacto, 2, _
    '    SlUsuarioPersonal, 1, _
    '    SlRolUusario, 1, _
    '    SlIP, 2, _
    '    SlLineaSolicitada, 3, _
    '    CsPeriodoPago, 1, _
    '    CsDiasPago, 2, _
    '    CsFecha1, 1, _
    '    CsFecha2, 1, _
    '    CsFecha3, 1, _
    '    CsFecha4, 1, _
    '    CsHoraPagoIni, 2, _
    '    CsHoraPagoFin, 2, _
    '    CsTipoPago, 1, _
    '    CsObservaciones, 2}

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    'End Function


    Public Function GrabaSolicitud() As DataTable
        If SlTelefonoDireccion = "" Then
            SlTelefonoDireccion = "null"
        End If
        If SlFaxDireccion = "" Then
            SlFaxDireccion = "null"
        End If
        If SlRepresentanteLegal = "" Then
            SlRepresentanteLegal = "null"
        End If
        If SlEmailRepresentanteLegal = "" Then
            SlEmailRepresentanteLegal = "null"
        End If
        If SlEmailRepresentanteLegal = "" Then
            SlEmailRepresentanteLegal = "null"
        End If
        If SlTelefonoRepresentanteLegal = "" Then
            SlTelefonoRepresentanteLegal = "null"
        End If
        If SlMovilRepresentanteLegal = "" Then
            SlMovilRepresentanteLegal = "null"
        End If
        If SlGerenteFinanciero = "" Then
            SlGerenteFinanciero = "null"
        End If
        If SlGerenteFinanciero = "" Then
            SlGerenteFinanciero = "null"
        End If
        If SlEmailGerenteFinanciero = "" Then
            SlEmailGerenteFinanciero = "null"
        End If
        If SlTelefonoGerenteFinanciero = "" Then
            SlTelefonoGerenteFinanciero = "null"
        End If

        If SlMovilGerenteFinanciero = "" Then
            SlMovilGerenteFinanciero = "null"
        End If
        If SlEmailEncargadoPagos = "" Then
            SlEmailEncargadoPagos = "null"
        End If
        If SlEmailPersonaContacto = "" Then
            SlEmailPersonaContacto = "null"
        End If
        If SlTelefonoPersonaContacto = "" Then
            SlTelefonoPersonaContacto = "null"
        End If
        If SlEncargadoPagos = "" Then
            SlEncargadoPagos = "null"
        End If
        If SlTelefonoEncargadoPagos = "" Then
            SlTelefonoEncargadoPagos = "null"
        End If
        If SlMovilEncargadoPagos = "" Then
            SlMovilEncargadoPagos = "null"
        End If
        If SlPersonaContacto = "" Then
            SlPersonaContacto = "null"
        End If
        If CsObservaciones = "" Then
            CsObservaciones = "null"
        End If
        If SlMovilPersonaContacto = "" Then
            SlMovilPersonaContacto = "null"
        End If

        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_SOLICITUD_CREDITO", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", SlControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDSOLICITUD_CREDITO", SlIDSolicitudCredito, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGO_PERSONA", SlCodigoPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iNOMBRE_PERSONA", SlNombreCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iDIRECCION_LEGAL", SlDireccionLegal, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONO_DIRECCION", SlTelefonoDireccion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iFAX_DIRECCION", SlFaxDireccion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iREP_LEGAL", SlRepresentanteLegal, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iEMAIL_REP_LEGAL", SlEmailRepresentanteLegal, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONO_REP_LEGAL", SlTelefonoRepresentanteLegal, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iMOVIL_REP_LEGAL", SlMovilRepresentanteLegal, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iGERENTE_FINANCIERO", SlGerenteFinanciero, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iEMAIL_GERENTE_FINANCIERO", SlEmailGerenteFinanciero, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONO_GERENTE_FINANCIERO", SlTelefonoGerenteFinanciero, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iMOVIL_GERENTE_FINANCIERO", SlMovilGerenteFinanciero, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iGIRO_NEGOCIO", SlGironegocio, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iENCARGADO_PAGOS", SlEncargadoPagos, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iEMAIL_ENCARGADO_PAGOS", SlEmailEncargadoPagos, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONO_ENCARGADO_PAGOS", SlTelefonoEncargadoPagos, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iMOVIL_ENCARGADO_PAGOS", SlMovilEncargadoPagos, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iPERSONA_CONTACTO", SlPersonaContacto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iEMAIL_PERSONA_CONTACTO", SlEmailPersonaContacto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTELEFONO_PERSONA_CONTACTO", SlTelefonoPersonaContacto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iMOVIL_PERSONA_CONTACTO", SlMovilPersonaContacto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDUSUARIO_PERSONAL", SlUsuarioPersonal, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDROL_USUARIO", SlRolUusario, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIP", SlIP, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iLINEASOLICITADA", SlLineaSolicitada, OracleClient.OracleType.Number)
        db.AsignarParametro("iPERIODO_PAGO", CsPeriodoPago, OracleClient.OracleType.Int32)
        db.AsignarParametro("iDIA_PAGO", CsDiasPago, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iFECHA1", CsFecha1, OracleClient.OracleType.Int32)
        db.AsignarParametro("iFECHA2", CsFecha2, OracleClient.OracleType.Int32)
        db.AsignarParametro("iFECHA3", CsFecha3, OracleClient.OracleType.Int32)
        db.AsignarParametro("iFECHA4", CsFecha4, OracleClient.OracleType.Int32)
        db.AsignarParametro("iHORARIO_PAGO_INI", CsHoraPagoIni, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iHORARIO_PAGO_FIN", CsHoraPagoFin, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iTIPO_PAGO", CsTipoPago, OracleClient.OracleType.Int32)
        db.AsignarParametro("iOBSERVACIONES", CsObservaciones, OracleClient.OracleType.VarChar)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
        'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_SOLICITUD_CREDITO", 78, _
        'SlControl, 1, _
        'SlIDSolicitudCredito, 1, _
        'SlCodigoPersona, 2, _
        'SlNombreCliente, 2, _
        'SlDireccionLegal, 2, _
        'SlTelefonoDireccion, 2, _
        'SlFaxDireccion, 2, _
        'SlRepresentanteLegal, 2, _
        'SlEmailRepresentanteLegal, 2, _
        'SlTelefonoRepresentanteLegal, 2, _
        'SlMovilRepresentanteLegal, 2, _
        'SlGerenteFinanciero, 2, _
        'SlEmailGerenteFinanciero, 2, _
        'SlTelefonoGerenteFinanciero, 2, _
        'SlMovilGerenteFinanciero, 2, _
        'SlGironegocio, 2, _
        'SlEncargadoPagos, 2, _
        'SlEmailEncargadoPagos, 2, _
        'SlTelefonoEncargadoPagos, 2, _
        'SlMovilEncargadoPagos, 2, _
        'SlPersonaContacto, 2, _
        'SlEmailPersonaContacto, 2, _
        'SlTelefonoPersonaContacto, 2, _
        'SlMovilPersonaContacto, 2, _
        'SlUsuarioPersonal, 1, _
        'SlRolUusario, 1, _
        'SlIP, 2, _
        'SlLineaSolicitada, 3, _
        'CsPeriodoPago, 1, _
        'CsDiasPago, 2, _
        'CsFecha1, 1, _
        'CsFecha2, 1, _
        'CsFecha3, 1, _
        'CsFecha4, 1, _
        'CsHoraPagoIni, 2, _
        'CsHoraPagoFin, 2, _
        'CsTipoPago, 1, _
        'CsObservaciones, 2}

        'Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    End Function

End Class
