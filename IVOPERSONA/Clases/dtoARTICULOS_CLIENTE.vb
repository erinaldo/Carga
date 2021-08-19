Imports AccesoDatos
Public Class dtoARTICULOS_CLIENTE

    'iCONTROL                        IN INTEGER,
    'iCODIGOPERSONA                  IN VARCHAR2,
    'iORIGEN                         IN INTEGER,
    'iDESTINO                        IN INTEGER,    
    'iIDARTICULOS_CLIENTE             IN T_ARTICULOS_CLIENTE.IDARTICULOS_CLIENTE%TYPE,
    'iARTICULO                        IN T_ARTICULOS_CLIENTE.ARTICULO%TYPE,
    'iPRECIO_FINAL                    IN T_ARTICULOS_CLIENTE.PRECIO_FINAL%TYPE,
    'oCUR_CONTROL                    OUT TYPES.CURSOR_TYPE        
    Private ArCENTRO_COSTO As Integer
    Private ArControl As Integer
    Private ArCodigoCliente As String
    Private ArOrigen As Integer
    Private ArDestino As Integer
    Private ArIDArticulosCliente As Integer
    Private ArArticulo As Integer
    Private ArPrecioFinal As Double

    Private arIDTARIFA_CARGA_CLIENTE As String

    Public Property IDTARIFA_CARGA_CLIENTE() As String
        Get
            Return arIDTARIFA_CARGA_CLIENTE
        End Get
        Set(ByVal value As String)
            arIDTARIFA_CARGA_CLIENTE = value
        End Set
    End Property
    Public Property CENTRO_COSTO() As Integer
        Get
            Return ArCENTRO_COSTO
        End Get
        Set(ByVal value As Integer)
            ArCENTRO_COSTO = value
        End Set
    End Property

    Public Property Control() As Integer
        Get
            Return ArControl
        End Get
        Set(ByVal value As Integer)
            ArControl = value
        End Set
    End Property
    Public Property CodigoCliente() As String
        Get
            Return ArCodigoCliente
        End Get
        Set(ByVal value As String)
            ArCodigoCliente = value
        End Set
    End Property
    Public Property Origen() As Integer
        Get
            Return ArOrigen
        End Get
        Set(ByVal value As Integer)
            ArOrigen = value
        End Set
    End Property
    Public Property Destino() As Integer
        Get
            Return ArDestino
        End Get
        Set(ByVal value As Integer)
            ArDestino = value
        End Set
    End Property
    Public Property IDArticulosCliente() As Integer
        Get
            Return ArIDArticulosCliente
        End Get
        Set(ByVal value As Integer)
            ArIDArticulosCliente = value
        End Set
    End Property
    Public Property Articulo() As Integer
        Get
            Return ArArticulo
        End Get
        Set(ByVal value As Integer)
            ArArticulo = value
        End Set
    End Property
    Public Property PrecioFinal() As Double
        Get
            Return ArPrecioFinal
        End Get
        Set(ByVal value As Double)
            ArPrecioFinal = value
        End Set
    End Property


    'Public Function GrabaArticulos() As ADODB.Recordset

    '    'MessageBox.Show(ArControl, "ArControl")
    '    'MessageBox.Show(ArCodigoCliente, "ArCodigoCliente")
    '    'MessageBox.Show(ArOrigen, "ArOrigen")
    '    'MessageBox.Show(ArDestino, "ArDestino")
    '    'MessageBox.Show(ArIDArticulosCliente, "ArIDArticulosCliente")
    '    'MessageBox.Show(ArArticulo, "ArArticulo")
    '    'MessageBox.Show(ArPrecioFinal, "ArPrecioFinal")

    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_ARTICULOS_CLIENTE", 20, _
    '    ArControl, 1, _
    '    ArCodigoCliente, 2, _
    '    ArOrigen, 1, _
    '    ArDestino, 1, _
    '    ArIDArticulosCliente, 1, _
    '    ArArticulo, 1, _
    '    ArPrecioFinal, 3}

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    'End Function


    Public Function GrabaArticulos_CC() As DataTable
        Try
            Dim db As New BaseDatos

            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_ARTICULOS_CLIENTE_CC", CommandType.StoredProcedure)

            db.AsignarParametro("P_IDTARIFA_CARGA_CLIENTE", arIDTARIFA_CARGA_CLIENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDCENTRO_COSTO", ArCENTRO_COSTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCONTROL", ArControl, OracleClient.OracleType.Int16)
            db.AsignarParametro("iCODIGOPERSONA", ArCodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iORIGEN", ArOrigen, OracleClient.OracleType.Int32)
            db.AsignarParametro("iDESTINO", ArDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDARTICULOS_CLIENTE", ArIDArticulosCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iARTICULO", ArArticulo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iPRECIO_FINAL", ArPrecioFinal, OracleClient.OracleType.Number)

            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable()

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function GrabaArticulos_CC2009() As ADODB.Recordset

    '    'MessageBox.Show(ArControl, "ArControl")
    '    'MessageBox.Show(ArCodigoCliente, "ArCodigoCliente")
    '    'MessageBox.Show(ArOrigen, "ArOrigen")
    '    'MessageBox.Show(ArDestino, "ArDestino")
    '    'MessageBox.Show(ArIDArticulosCliente, "ArIDArticulosCliente")
    '    'MessageBox.Show(ArArticulo, "ArArticulo")
    '    'MessageBox.Show(ArPrecioFinal, "ArPrecioFinal")

    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_ARTICULOS_CLIENTE_CC", 20, _
    '    arIDTARIFA_CARGA_CLIENTE, 2, _
    '    ArCENTRO_COSTO, 1, _
    '    ArControl, 1, _
    '    ArCodigoCliente, 2, _
    '    ArOrigen, 1, _
    '    ArDestino, 1, _
    '    ArIDArticulosCliente, 1, _
    '    ArArticulo, 1, _
    '    ArPrecioFinal, 3}

    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

    'End Function

End Class
