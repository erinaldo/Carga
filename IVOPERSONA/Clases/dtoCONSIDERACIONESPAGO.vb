Imports AccesoDatos
Public Class dtoCONSIDERACIONESPAGO
    'iCONTROL                           IN INTEGER,
    'iCODIGOCLIENTE                     IN VARCHAR2,
    'iIDCONSIDERACIONES_PAGO            IN T_CONSIDERACIONES_PAGO.IDCONSIDERACIONES_PAGO%TYPE,
    'iPERIODO_PAGO                      IN T_CONSIDERACIONES_PAGO.PERIODO_PAGO%TYPE,
    'iDIA_PAGO                          IN T_CONSIDERACIONES_PAGO.DIA_PAGO%TYPE,
    'iFECHA1                            IN T_CONSIDERACIONES_PAGO.FECHA1%TYPE,
    'iFECHA2                            IN T_CONSIDERACIONES_PAGO.FECHA2%TYPE,
    'iFECHA3                            IN T_CONSIDERACIONES_PAGO.FECHA3%TYPE,
    'iFECHA4                            IN T_CONSIDERACIONES_PAGO.FECHA4%TYPE,
    'iHORARIO_PAGO_INI                  IN T_CONSIDERACIONES_PAGO.HORARIO_PAGO_INI%TYPE,
    'iHORARIO_PAGO_FIN                  IN T_CONSIDERACIONES_PAGO.HORARIO_PAGO_FIN%TYPE,
    'iTIPO_PAGO                         IN T_CONSIDERACIONES_PAGO.TIPO_PAGO%TYPE,
    'iOBSERVACIONES                     IN T_CONSIDERACIONES_PAGO.OBSERVACIONES%TYPE,

    Private CsControl As Integer
    Private CsCodigoCliente As String
    Private CsIDConsideracionesPago As Integer
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
            Return CsControl
        End Get
        Set(ByVal value As Integer)
            CsControl = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return CsCodigoCliente
        End Get
        Set(ByVal value As String)
            CsCodigoCliente = value
        End Set
    End Property
    Public Property IDConsideracionesPago() As Integer
        Get
            Return CsIDConsideracionesPago
        End Get
        Set(ByVal value As Integer)
            CsIDConsideracionesPago = value
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
    'Public Function GrabaConsideracionPago2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_CONSIDER_PAGOS", 30, _
    '    CsControl, 1, _
    '    CsCodigoCliente, 2, _
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

    '    'CsIDConsideracionesPago, 1, _

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    'End Function

    Public Function GrabaConsideracionPago() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_CONSIDER_PAGOS", CommandType.StoredProcedure)

        db.AsignarParametro("iCONTROL", CsControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOCLIENTE", CsCodigoCliente, OracleClient.OracleType.VarChar)
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

    End Function

End Class
