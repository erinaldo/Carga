Imports AccesoDatos
Public Class dtoRutas
    Private StAccion As Integer
    Private StID As Integer
    Private StNomRuta As String
    Private StKilometros As Decimal
    Private StHoras As String
    Private StDias As Integer
    Private StErrorHor As Double
    Private StOrigen As Integer
    Private StDestino As Integer
    Private StVigente As Integer
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIP As String
    Private StEstado As Integer
    Public Property Accion() As Integer
        Get
            Return StAccion
        End Get
        Set(ByVal value As Integer)
            StAccion = value
        End Set
    End Property
    Public Property ID() As Integer
        Get
            Return StID
        End Get
        Set(ByVal value As Integer)
            StID = value
        End Set
    End Property
    Public Property NomRuta() As String
        Get
            Return StNomRuta
        End Get
        Set(ByVal value As String)
            StNomRuta = value
        End Set
    End Property
    Public Property Kilometros() As Decimal
        Get
            Return StKilometros
        End Get
        Set(ByVal value As Decimal)
            StKilometros = value
        End Set
    End Property
    Public Property Horas() As String
        Get
            Return StHoras
        End Get
        Set(ByVal value As String)
            StHoras = value
        End Set
    End Property
    Public Property Dias() As Integer
        Get
            Return StDias
        End Get
        Set(ByVal value As Integer)
            StDias = value
        End Set
    End Property
    Public Property ErrorHor() As Double
        Get
            Return StErrorHor
        End Get
        Set(ByVal value As Double)
            StErrorHor = value
        End Set
    End Property
    Public Property Origen() As Integer
        Get
            Return StOrigen
        End Get
        Set(ByVal value As Integer)
            StOrigen = value
        End Set
    End Property
    Public Property Destino() As Integer
        Get
            Return StDestino
        End Get
        Set(ByVal value As Integer)
            StDestino = value
        End Set
    End Property
    Public Property Vigente() As Integer
        Get
            Return StVigente
        End Get
        Set(ByVal value As Integer)
            StVigente = value
        End Set
    End Property
    Public Property Usuario() As Integer
        Get
            Return StUsuario
        End Get
        Set(ByVal value As Integer)
            StUsuario = value
        End Set
    End Property
    Public Property Rol() As Integer
        Get
            Return StRol
        End Get
        Set(ByVal value As Integer)
            StRol = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return StIP
        End Get
        Set(ByVal value As String)
            StIP = value
        End Set
    End Property
    Public Property Estado() As Integer
        Get
            Return StEstado
        End Get
        Set(ByVal value As Integer)
            StEstado = value
        End Set
    End Property
    'Public Function Lista_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_RUTAS", 0}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Lista() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_RUTAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas             
            db_bd.AsignarParametro("cur_rutas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_ciudades", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_estados", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_ciudades2", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Grabar_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_RUTAS", 30, StAccion, 1, StID, 1, StNomRuta, 2, StKilometros, 1, StHoras, 2, StDias, 1, StVigente, 1, StErrorHor, 3, StEstado, 1, StOrigen, 1, StDestino, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Grabar() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_RUTAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDRUTAS", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNOMBRE_RUTA", StNomRuta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNROKILOMETROS", StKilometros, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iHORAS_VIAJE", StHoras, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iDIAS_VIAJE", StDias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iES_VIGENTE", StVigente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iMARGEN_ERROR_HORAS", StErrorHor, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", StDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_lista", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Shared Function ExisteRuta(origen As Integer, destino As Integer) As Boolean
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select sf_get_existe_ruta (" & origen & "," & destino & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return IIf(db.EjecutarEscalar() = 0, False, True)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
End Class
