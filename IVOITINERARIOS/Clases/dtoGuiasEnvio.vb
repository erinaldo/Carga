Imports AccesoDatos
Public Class dtoGuiasEnvio
    Private StRuta As Integer
    Private StFecIni As String
    Private StFecFin As String
    Private StMovil As Integer
    Private StRuc As String
    Private StCliente As String
    Private StAccion As Integer
    Private StID As Integer
    Private StAgeOri As Integer
    Private StAgeDes As Integer
    Private StClase As Integer
    Private StVigente As Integer
    Private StHorIti As String
    Private StHorPar As String
    Private StHorLle As String
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIP As String
    Private StEstado As Integer
    Public Property Ruta() As Integer
        Get
            Return StRuta
        End Get
        Set(ByVal value As Integer)
            StRuta = value
        End Set
    End Property
    Public Property Fecha_Ini() As String
        Get
            Return StFecIni
        End Get
        Set(ByVal value As String)
            StFecIni = value
        End Set
    End Property
    Public Property Fecha_Fin() As String
        Get
            Return StFecFin
        End Get
        Set(ByVal value As String)
            StFecFin = value
        End Set
    End Property
    Public Property Movil() As Integer
        Get
            Return StMovil
        End Get
        Set(ByVal value As Integer)
            StMovil = value
        End Set
    End Property
    Public Property Ruc() As String
        Get
            Return StRuc
        End Get
        Set(ByVal value As String)
            StRuc = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return StCliente
        End Get
        Set(ByVal value As String)
            StCliente = value
        End Set
    End Property
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
    Public Property Clase() As Integer
        Get
            Return StClase
        End Get
        Set(ByVal value As Integer)
            StClase = value
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

    Public Property Hora_Ini() As String
        Get
            Return StHorIti
        End Get
        Set(ByVal value As String)
            StHorIti = value
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
    Public Property Hora_Lle() As String
        Get
            Return StHorLle
        End Get
        Set(ByVal value As String)
            StHorLle = value
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASENVIO", 0}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_GUIASENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'Variables de salidas 
            db_bd.AsignarParametro("cur_tarifas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_unidad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_moviles", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_detalle", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_tipo_entrega", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_forma_pago", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_und_medida", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_documentos", OracleClient.OracleType.Cursor)
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
        '
    End Function
    'Public Function BuscaCliente_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_CLIENTE_X_CODIGO", 4, StCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function BuscaCliente() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CLIENTE_X_CODIGO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCODIGO_CLIENTE", StCliente, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_clientes", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_cencos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_direccion", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_contacto", OracleClient.OracleType.Cursor)
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




    'Public Function Buscar() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_LISTA_CONSULTA_RECOJO_DET", 16, StMovil, 1, StRuta, 1, StEstado, 1, StRuc, 2, StCliente, 2, StFecIni, 2, StFecFin, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    'Public Function Grabar() As ADODB.Recordset
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_ITINERARIOS", 34, StAccion, 1, StID, 1, StAgeOri, 1, StAgeDes, 1, StClase, 1, StVigente, 1, StFecIti, 2, StHorIti, 2, StHorPar, 2, StFecLle, 2, StHorLle, 2, StRuta, 1, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    'Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

End Class
