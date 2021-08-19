Imports AccesoDatos
Public Class dtoCONDICIONALES_TARIFA
    'iCONTROL                        IN INTEGER,
    'iCODIGOPERSONA                  IN VARCHAR2,
    'iORIGEN                         IN INTEGER,
    'iDESTINO                        IN INTEGER,
    'iIDCONDICIONAL                  IN T_CONDICIONALES_TARIFA.IDCONDICIONAL%TYPE,
    'iCONCEPTO                       IN T_CONDICIONALES_TARIFA.CONCEPTO%TYPE,
    'iUNIDAD                         IN T_CONDICIONALES_TARIFA.UNIDAD%TYPE,
    'iINICIO                         IN T_CONDICIONALES_TARIFA.INICIO%TYPE,
    'iFIN                            IN T_CONDICIONALES_TARIFA.FIN%TYPE,
    'iPRECIO_FINAL                   IN T_CONDICIONALES_TARIFA.PRECIO_FINAL%TYPE,

    Private CdControl As Integer
    Private CdCodigoCliente As String
    Private CdOrigen As Integer
    Private CdDestino As Integer
    Private CdIDCondicional As Integer
    Private CdConcepto As String
    Private CdUnidad As String
    Private CdInicio As Double
    Private CdFin As Double
    Private CdPrecioFinal As Double

    Public Property Control() As Integer
        Get
            Return CdControl
        End Get
        Set(ByVal value As Integer)
            CdControl = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return CdCodigoCliente
        End Get
        Set(ByVal value As String)
            CdCodigoCliente = value
        End Set
    End Property
    Public Property Origen() As Integer
        Get
            Return CdOrigen
        End Get
        Set(ByVal value As Integer)
            CdOrigen = value
        End Set
    End Property
    Public Property Destino() As Integer
        Get
            Return CdDestino
        End Get
        Set(ByVal value As Integer)
            CdDestino = value
        End Set
    End Property
    Public Property IDCondicional() As Integer
        Get
            Return CdIDCondicional
        End Get
        Set(ByVal value As Integer)
            CdIDCondicional = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return CdConcepto
        End Get
        Set(ByVal value As String)
            CdConcepto = value
        End Set
    End Property
    Public Property Unidad() As String
        Get
            Return CdUnidad
        End Get
        Set(ByVal value As String)
            CdUnidad = value
        End Set
    End Property
    Public Property Inicio() As Double
        Get
            Return CdInicio
        End Get
        Set(ByVal value As Double)
            CdInicio = value
        End Set
    End Property
    Public Property Fin() As Double
        Get
            Return CdFin
        End Get
        Set(ByVal value As Double)
            CdFin = value
        End Set
    End Property
    Public Property PrecioFinal() As Double
        Get
            Return CdPrecioFinal
        End Get
        Set(ByVal value As Double)
            CdPrecioFinal = value
        End Set
    End Property
    'Public Function GrabaCondicionales2009() As ADODB.Recordset
    '    'MessageBox.Show(CdControl, "CdControl")
    '    'MessageBox.Show(CdCodigoCliente, "CdCodigoCliente")
    '    'MessageBox.Show(CdOrigen, "CdOrigen")
    '    'MessageBox.Show(CdDestino, "CdDestino")
    '    'MessageBox.Show(CdIDCondicional, "CdIDCondicional")
    '    'MessageBox.Show(CdConcepto, "CdConcepto")
    '    'MessageBox.Show(CdUnidad, "CdUnidad")
    '    'MessageBox.Show(CdInicio, "CdInicio")
    '    'MessageBox.Show(CdFin, "CdFin")
    '    'MessageBox.Show(CdPrecioFinal, "CdPrecioFinal")
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_CONDICIONALES", 22, _
    '    CdControl, 1, _
    '    CdCodigoCliente, 2, _
    '    CdOrigen, 1, _
    '    CdDestino, 1, _
    '    CdIDCondicional, 1, _
    '    CdConcepto, 2, _
    '    CdUnidad, 2, _
    '    CdInicio, 3, _
    '    CdFin, 3, _
    '    CdPrecioFinal, 3}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function
    Public Function GrabaCondicionales() As DataTable
        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_CONDICIONALES", CommandType.StoredProcedure)
        db.AsignarParametro("iCONTROL", CdControl, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGOPERSONA", CdCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iORIGEN", CdOrigen, OracleClient.OracleType.Int32)
        db.AsignarParametro("iDESTINO", CdDestino, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDCONDICIONAL", CdIDCondicional, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCONCEPTO", CdConcepto, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iUNIDAD", CdUnidad, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iINICIO", CdInicio, OracleClient.OracleType.Number)
        db.AsignarParametro("iFIN", CdFin, OracleClient.OracleType.Number)
        db.AsignarParametro("iPRECIO_FINAL", CdPrecioFinal, OracleClient.OracleType.Number)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Return db.EjecutarDataTable
    End Function
End Class
