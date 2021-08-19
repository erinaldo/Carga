Imports AccesoDatos
Public Class dtoAgencias
    Private StAccion As Integer
    Private StID As Integer
    Private StDist As Integer
    Private StProv As Integer
    Private StDepa As Integer
    Private StPais As Integer
    Private StNomAge As String
    Private StApePat As String
    Private StApeMat As String
    Private StContac As String
    Private StCelular As String
    Private StTele1 As String
    Private StTele2 As String
    Private StFax1 As String
    Private StFax2 As String
    Private StMail As String
    Private StRPM1 As String
    Private StRPM2 As String
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIP As String
    Private StEstado As Integer
    Private StCorto As String
    Private StUnidad As Integer
    Private StCodAge As String
    Private StDireccion As String
    Private li_es_terminal As Int16
    Public Property es_terminal() As Int32
        Get
            Return li_es_terminal
        End Get
        Set(ByVal value As Int32)
            li_es_terminal = value
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
    Public Property NomAgencia() As String
        Get
            Return StNomAge
        End Get
        Set(ByVal value As String)
            StNomAge = value
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
    Public Property Telefono1() As String
        Get
            Return StTele1
        End Get
        Set(ByVal value As String)
            StTele1 = value
        End Set
    End Property
    Public Property Telefono2() As String
        Get
            Return StTele2
        End Get
        Set(ByVal value As String)
            StTele2 = value
        End Set
    End Property
    Public Property Fax1() As String
        Get
            Return StFax1
        End Get
        Set(ByVal value As String)
            StFax1 = value
        End Set
    End Property
    Public Property Fax2() As String
        Get
            Return StFax2
        End Get
        Set(ByVal value As String)
            StFax2 = value
        End Set
    End Property
    Public Property E_Mail() As String
        Get
            Return StMail
        End Get
        Set(ByVal value As String)
            StMail = value
        End Set
    End Property
    Public Property RPM1() As String
        Get
            Return StRPM1
        End Get
        Set(ByVal value As String)
            StRPM1 = value
        End Set
    End Property
    Public Property RPM2() As String
        Get
            Return StRPM2
        End Get
        Set(ByVal value As String)
            StRPM2 = value
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
    Public Property Unidad() As String
        Get
            Return StUnidad
        End Get
        Set(ByVal value As String)
            StUnidad = value
        End Set
    End Property
    Public Property CodAgencia() As String
        Get
            Return StCodAge
        End Get
        Set(ByVal value As String)
            StCodAge = value
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

    Private intPortavalor As Integer
    Public Property Portavalor() As Integer
        Get
            Return intPortavalor
        End Get
        Set(ByVal value As Integer)
            intPortavalor = value
        End Set
    End Property


    'Public Function Lista_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_AGENCIAS", 0}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_AGENCIAS_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas
            db_bd.AsignarParametro("cur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_unidad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_pais", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_depar", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_prov", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_distrito", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_estados", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_unidad2", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_tipo_agencia", OracleClient.OracleType.Cursor)
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_AGENCIAS", 51, StAccion, 1, StID, 1, StDist, 1, StProv, 1, StDepa, 1, StPais, 1, StNomAge, 2, StApePat, 2, StApeMat, 2, StContac, 2, StDireccion, 2, StCelular, 2, StTele1, 2, StTele2, 2, StFax1, 2, StFax2, 2, StMail, 2, StRPM1, 2, StRPM2, 2, StUsuario, 1, StRol, 1, StIP, 2, StCorto, 2, StUnidad, 1, StEstado, 1}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_AGENCIAS_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDAGENCIAS", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDDISTRITO", StDist, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPROVINCIA", StProv, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDDEPARTAMENTO", StDepa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPAIS", StPais, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNOMBRE_AGENCIA", StNomAge, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_CONTACTO_APEPAT", StApePat, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_CONTACTO_APEMAT", StApeMat, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_CONTACTO", StContac, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iDIRECCION_AGENCIA", StDireccion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCELULAR", StCelular, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iTELEFONO1", StTele1, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iTELEFONO2", StTele2, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFAX1", StFax1, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFAX2", StFax2, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iE_MAIL", StMail, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iRPM1", StRPM1, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iRPM2", StRPM2, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_CORTO", StCorto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StUnidad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idtipo_agencia", li_es_terminal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_portavalor", Portavalor, OracleClient.OracleType.Int32)
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
    Public Function verifica_tipo_agencia() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.sp_ciudad_agencia_terminal", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idunidad_agencia", StUnidad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("co_agencia_terminal", OracleClient.OracleType.Cursor)
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