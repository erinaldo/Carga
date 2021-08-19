Imports AccesoDatos
Public Class dtoTarifaPasaje
    Private StAccion As Integer
    Private StID As Integer
    Private StRuta As Integer
    Private StClase As Integer
    Private StFecTar As String
    Private StHorTar As String
    Private StPasaje As Double
    Private StFecIni As String
    Private StFecFin As String
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
    Public Property Ruta() As Integer
        Get
            Return StRuta
        End Get
        Set(ByVal value As Integer)
            StRuta = value
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
    Public Property Fecha_Tar() As String
        Get
            Return StFecTar
        End Get
        Set(ByVal value As String)
            StFecTar = value
        End Set
    End Property
    Public Property Hora_Tar() As String
        Get
            Return StHorTar
        End Get
        Set(ByVal value As String)
            StHorTar = value
        End Set
    End Property
    Public Property Pasaje() As Double
        Get
            Return StPasaje
        End Get
        Set(ByVal value As Double)
            StPasaje = value
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_TARIFAPASAJE", 0}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_TARIFAPASAJE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas             
            db_bd.AsignarParametro("cur_tarifas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_unidad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_servicios", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_rutas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_detalle", OracleClient.OracleType.Cursor)
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
    'Public Function Buscar_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_TARIFAPASAJE2", 6, StRuta, 1, StClase, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Buscar() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_TARIFAPASAJE2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDRUTAS", StRuta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDCLASE", StClase, OracleClient.OracleType.Int32)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_tarifas", OracleClient.OracleType.Cursor)
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_TARIFAPASAJE", 30, StAccion, 1, StID, 1, StRuta, 1, StClase, 1, StFecTar, 2, StHorTar, 2, StPasaje, 3, StFecIni, 2, StFecFin, 2, StVigente, 1, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_TARIFAPASAJE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDTARIFAS_RUTAS", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDRUTAS", StRuta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDCLASE", StClase, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iFECHA_TARIFA", StFecTar, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iHORA_TARIFA", StHorTar, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iVALOR_PASAJE", StPasaje, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iFECHA_ACTIVACION", StFecIni, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFECHA_DESACTIVACION", StFecFin, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iES_VIGENTE", StVigente, OracleClient.OracleType.Int32)
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

End Class
