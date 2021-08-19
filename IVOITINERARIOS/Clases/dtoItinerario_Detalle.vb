Imports AccesoDatos
Public Class dtoItinerario_Detalle
    Private StAccion As Integer
    Private StID As Integer
    Private StRuta As Integer
    Private StItinerario As Integer
    Private StItem As Integer
    Private StFecPar As String
    Private StHorPar As String
    Private StFecLle As String
    Private StHorLle As String
    Private StAgeOri As Integer
    Private StAgeDes As Integer
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
    Public Property Ruta() As Integer
        Get
            Return StRuta
        End Get
        Set(ByVal value As Integer)
            StRuta = value
        End Set
    End Property
    Public Property Itinerario() As Integer
        Get
            Return StItinerario
        End Get
        Set(ByVal value As Integer)
            StItinerario = value
        End Set
    End Property
    Public Property Item() As Integer
        Get
            Return StItem
        End Get
        Set(ByVal value As Integer)
            StItem = value
        End Set
    End Property

    Public Property Fecha_Par() As String
        Get
            Return StFecPar
        End Get
        Set(ByVal value As String)
            StFecPar = value
        End Set
    End Property
    Public Property Hora_Par() As String
        Get
            Return StHorPar
        End Get
        Set(ByVal value As String)
            StHorPar = value
        End Set
    End Property
    Public Property Fecha_Lle() As String
        Get
            Return StFecLle
        End Get
        Set(ByVal value As String)
            StFecLle = value
        End Set
    End Property
    Public Property Hora_lle() As String
        Get
            Return StHorLle
        End Get
        Set(ByVal value As String)
            StHorLle = value
        End Set
    End Property
    Public Property AgeOrigen() As Integer
        Get
            Return StAgeOri
        End Get
        Set(ByVal value As Integer)
            StAgeOri = value
        End Set
    End Property
    Public Property AgeDestino() As Integer
        Get
            Return StAgeDes
        End Get
        Set(ByVal value As Integer)
            StAgeDes = value
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_ITINERARIO_DETALLE", 4, StID, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Lista() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_ITINERARIO_DETALLE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDITINERARIOS", StID, OracleClient.OracleType.Int32)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_detalle", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Grabar_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_ITINERARIOS_DETALLE", 31, StAccion, 1, StID, 1, StRuta, 1, StItinerario, 1, StItem, 1, StFecPar, 2, StHorPar, 2, StFecLle, 2, StHorLle, 2, StAgeOri, 1, StAgeDes, 1, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_ITINERARIOS_DETALLE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDRUTAS_ITINERARIOS", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDRUTAS", StRuta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDITINERARIOS", StItinerario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iITEM", StItem, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iFECHA_PARTIDA", StFecPar, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iHORA_PARTIDA", StHorPar, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFECHA_LLEGADA", StFecLle, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iHORA_LLEGADA", StHorLle, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDAGENCIA_ORIGEN", StAgeOri, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDAGENCIA_DESTINO", StAgeDes, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
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
    'Public Function Eliminar_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_DEL_ITINERARIOS_DETALLE", 12, StID, 1, StItinerario, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Eliminar() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_DEL_ITINERARIOS_DETALLE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDRUTAS_ITINERARIOS", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDITINERARIOS", StItinerario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
