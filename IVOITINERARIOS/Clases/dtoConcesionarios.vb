Imports AccesoDatos
Public Class dtoConcesionarios
    Private StAccion As Integer
    Private StID As Integer
    Private StDist As Integer
    Private StProv As Integer
    Private StDepa As Integer
    Private StPais As Integer
    Private StNomEmp As String
    Private StCorto As String
    Private StRUC As String
    Private StContac As String
    Private StApePat As String
    Private StApeMat As String
    Private StDireccion As String
    Private StTelefono As String
    Private StCelular As String
    Private StFax As String
    Private StRPM As String
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIP As String
    Private StEstado As Integer
    Private StFiltro As Integer
    Private StAgencia As Integer
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
    Public Property NomEmpresa() As String
        Get
            Return StNomEmp
        End Get
        Set(ByVal value As String)
            StNomEmp = value
        End Set
    End Property
    Public Property ApePatCto() As String
        Get
            Return StApePat
        End Get
        Set(ByVal value As String)
            StApePat = value
        End Set
    End Property
    Public Property ApeMatCto() As String
        Get
            Return StApeMat
        End Get
        Set(ByVal value As String)
            StApeMat = value
        End Set
    End Property
    Public Property Contacto() As String
        Get
            Return StContac
        End Get
        Set(ByVal value As String)
            StContac = value
        End Set
    End Property
    Public Property Celular() As String
        Get
            Return StCelular
        End Get
        Set(ByVal value As String)
            StCelular = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return StTelefono
        End Get
        Set(ByVal value As String)
            StTelefono = value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return StFax
        End Get
        Set(ByVal value As String)
            StFax = value
        End Set
    End Property
    Public Property RUC() As String
        Get
            Return StRUC
        End Get
        Set(ByVal value As String)
            StRUC = value
        End Set
    End Property
    Public Property RPM() As String
        Get
            Return StRPM
        End Get
        Set(ByVal value As String)
            StRPM = value
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
    Public Property NomCorto() As String
        Get
            Return StCorto
        End Get
        Set(ByVal value As String)
            StCorto = value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return StDireccion
        End Get
        Set(ByVal value As String)
            StDireccion = value
        End Set
    End Property
    Public Property Filtro() As Integer
        Get
            Return StFiltro
        End Get
        Set(ByVal value As Integer)
            StFiltro = value
        End Set
    End Property
    Public Property Agencia() As Integer
        Get
            Return StAgencia
        End Get
        Set(ByVal value As Integer)
            StAgencia = value
        End Set
    End Property
    'Public Function Lista_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_CONCESIONARIOS", 0}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Lista() As DataSet
        'Dim ObjUnd2 As Object() = {"", 0}
        'Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_CONCESIONARIOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_concesionarios", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_pais", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_depar", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_prov", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_distrito", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_estados", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_unidad2", OracleClient.OracleType.Cursor)
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
    'Public Function Grabar_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_CONCESIONARIOS", 46, StAccion, 1, StID, 1, StDist, 1, StProv, 1, StDepa, 1, StPais, 1, StNomEmp, 2, StCorto, 2, StRUC, 2, StContac, 2, StApePat, 2, StApeMat, 2, StDireccion, 2, StTelefono, 2, StCelular, 2, StFax, 2, StRPM, 2, StUsuario, 1, StRol, 1, StIP, 2, StEstado, 1}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_CONCESIONARIOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDEMPRESAS_CONCESION", StID, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("iIDDISTRITO", StDist, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPROVINCIA", StProv, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDDEPARTAMENTO", StDepa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPAIS", StPais, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNOMBRE_EMPRESA", StNomEmp, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_CORTO", StCorto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iRUC", StRUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_CONTACTO", StContac, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iAPEPAT_CONTACTO", StApePat, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iAPEMAT_CONTACTO", StApeMat, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iDIRECCION", StDireccion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iTELEFONO", StTelefono, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCELULAR", StCelular, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFAX", StFax, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCELULAR", StCelular, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iRPM", StRPM, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_lista", OracleClient.OracleType.Cursor)
            '
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
    'Public Function AgenciasAsociadas_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_AGENCIAS_CONCESION", 4, StFiltro, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function AgenciasAsociadas() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_AGENCIAS_CONCESION", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            db_bd.AsignarParametro("iIDEMPRESAS_CONCESION", StFiltro, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_agencias_disponibles", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_agencias_asociadas", OracleClient.OracleType.Cursor)
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
    'Public Function GrabaAgenciasAsociadas_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_AGENCIA_CONCESION", 8, StAccion, 1, StID, 1, StAgencia, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function GrabaAgenciasAsociadas() As DataTable
        '
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_AGENCIA_CONCESION", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDEMPRESAS_CONCESION", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDAGENCIAS", StAgencia, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            '
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
