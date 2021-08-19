Imports AccesoDatos
Public Class Dto_Ubigeo
#Region "Variables"
    Dim my_fact As Integer
    Dim my_idpais As Int32
    Dim my_pais As String
    Dim my_iddepartamento As Int32
    Dim my_departamento As String
    Dim my_idprovincia As Int32
    Dim my_provincia As String
    Dim my_iddistrito As Int32
    Dim my_distrito As String

#End Region
#Region "Propiedades"
    Public Property iddistrito() As Int32
        Get
            iddistrito = my_iddistrito
        End Get
        Set(ByVal value As Int32)
            my_iddistrito = value
        End Set
    End Property
    Public Property distrito() As String
        Get
            distrito = my_distrito
        End Get
        Set(ByVal value As String)
            my_distrito = value
        End Set
    End Property
    Public Property idprovincia() As Int32
        Get
            idprovincia = my_idprovincia
        End Get
        Set(ByVal value As Int32)
            my_idprovincia = value
        End Set
    End Property
    Public Property provincia() As String
        Get
            provincia = my_provincia
        End Get
        Set(ByVal value As String)
            my_provincia = value
        End Set
    End Property

    Public Property iddepartamento() As Int32
        Get
            iddepartamento = my_iddepartamento
        End Get
        Set(ByVal value As Int32)
            my_iddepartamento = value
        End Set
    End Property
    Public Property departamento() As String
        Get
            departamento = my_departamento
        End Get
        Set(ByVal value As String)
            my_departamento = value
        End Set
    End Property
    Public Property pais() As String
        Get
            pais = my_pais
        End Get
        Set(ByVal value As String)
            my_pais = value
        End Set
    End Property
    Public Property Fact() As Integer
        Get
            Fact = my_fact
        End Get
        Set(ByVal value As Integer)
            my_fact = value
        End Set
    End Property
    Public Property idpais() As Int32
        Get
            idpais = my_idpais
        End Get
        Set(ByVal value As Int32)
            my_idpais = value
        End Set
    End Property
#End Region
#Region "Métodos"
    Public Function FN_Grilla_Ubicacion_II() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_GRILLASUBICACION_II", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_PAIS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DEPARTAMENTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PROVINCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DISTRITO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            '
            Return db.EjecutarDataSet
            '   
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function cargar_datos(ByVal _SPLista As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando(_SPLista, CommandType.StoredProcedure)

            db.AsignarParametro("oCUR_PAIS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DEPARTAMENTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PROVINCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DISTRITO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function grabar_pais(ByVal _SPGraba As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando(_SPGraba, CommandType.StoredProcedure)
            '
            db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPAIS", idpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iPAIS", pais, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function grabar_departamento() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DEPARTAMENTO", CommandType.StoredProcedure)
            '
            db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", iddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPAIS", idpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iDEPARTAMENTO", departamento, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function grabar_provincia() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_PROVINCIA", CommandType.StoredProcedure)
            '
            db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPROVINCIA", idprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", iddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPAIS", idpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iPROVINCIA", provincia, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            '
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function grabar_distrito() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DISTRITO", CommandType.StoredProcedure)
            '
            db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDISTRITO", iddistrito, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPROVINCIA", idprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", iddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPAIS", idpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iDISTRITO", distrito, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class