Imports AccesoDatos
Public Class dtoCiudades
    Private StAccion As Integer
    Private StID As Integer
    Private StDist As Integer
    Private StProv As Integer
    Private StDepa As Integer
    Private StPais As Integer
    Private StNombre As String
    Private StIATA As String
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
    Public Property Distrito() As Integer
        Get
            Return StDist
        End Get
        Set(ByVal value As Integer)
            StDist = value
        End Set
    End Property
    Public Property Provincia() As Integer
        Get
            Return StProv
        End Get
        Set(ByVal value As Integer)
            StProv = value
        End Set
    End Property
    Public Property Departamento() As Integer
        Get
            Return Departamento
        End Get
        Set(ByVal value As Integer)
            StDepa = value
        End Set
    End Property
    Public Property Pais() As Integer
        Get
            Return StPais
        End Get
        Set(ByVal value As Integer)
            StPais = value
        End Set
    End Property
    Public Property NomCiudad() As String
        Get
            Return StNombre
        End Get
        Set(ByVal value As String)
            StNombre = value
        End Set
    End Property
    Public Property IATA() As String
        Get
            Return StIATA
        End Get
        Set(ByVal value As String)
            StIATA = value
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_UNIDADES", 0}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_UNIDADES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_pais", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_depar", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_prov", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_distrito", OracleClient.OracleType.Cursor)
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA", 24, StAccion, 1, StID, 1, StNombre, 2, StIATA, 2, StDist, 1, StProv, 1, StDepa, 1, StPais, 1, StUsuario, 1, StRol, 1, StIP, 2}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNOMBRE_UNIDAD", StNombre, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCODIGO_IATA", StIATA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDDISTRITO", StDist, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPROVINCIA", StProv, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDDEPARTAMENTO", StDepa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPAIS", StPais, OracleClient.OracleType.Int32)
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


