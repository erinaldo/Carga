Imports AccesoDatos
Public Class dtoSolRecojoBusqueda
    Private Stfila As Long
    Private Stidcliente As Integer
    Private Stiddireccion As Integer
    Private Stcliente As String
    Private StDireccion As String
    Private Stbusquedapor As Integer
    Private Stbusquedacliente As String
    Private Stbusquedadireccion As String
    Private iidpais As Integer
    Private iiddepartamento As Integer
    Private iidprovincia As Integer
    Private iiddistrito As Integer
    '
    Private ls_nro_documento As String
    Private ll_idagencia As Long
    Public Property Idagencia() As Long
        Get
            Return ll_idagencia
        End Get
        Set(ByVal value As Long)
            ll_idagencia = value
        End Set
    End Property
    Public Property nro_documento() As String
        Get
            Return ls_nro_documento
        End Get
        Set(ByVal value As String)
            ls_nro_documento = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return Stcliente
        End Get
        Set(ByVal value As String)
            Stcliente = value
        End Set
    End Property
    Public Property Idcliente() As Integer
        Get
            Return Stidcliente
        End Get
        Set(ByVal value As Integer)
            Stidcliente = value
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
    Public Property Iddireccion() As Integer
        Get
            Return Stiddireccion
        End Get
        Set(ByVal value As Integer)
            Stiddireccion = value
        End Set
    End Property
    Public Property Idpais() As Integer
        Get
            Return iidpais
        End Get
        Set(ByVal value As Integer)
            iidpais = value
        End Set
    End Property
    Public Property Iddepartamento() As Integer
        Get
            Return iiddepartamento
        End Get
        Set(ByVal value As Integer)
            iiddepartamento = value
        End Set
    End Property
    Public Property Idprovincia() As Integer
        Get
            Return iidprovincia
        End Get
        Set(ByVal value As Integer)
            iidprovincia = value
        End Set
    End Property
    Public Property Iddistrito() As Integer
        Get
            Return iiddistrito
        End Get
        Set(ByVal value As Integer)
            iiddistrito = value
        End Set
    End Property
    Public Property busquedapor() As Integer
        Get
            Return Stbusquedapor
        End Get
        Set(ByVal value As Integer)
            Stbusquedapor = value
        End Set
    End Property
    Public Property busquedacondicicionclte() As String
        Get
            Return Stbusquedacliente
        End Get
        Set(ByVal value As String)
            Stbusquedacliente = value
        End Set
    End Property
    Public Property busquedacondiciciondireccion() As String
        Get
            Return Stbusquedadireccion
        End Get
        Set(ByVal value As String)
            Stbusquedadireccion = value
        End Set
    End Property
    'Public Function BusquedaCliente_x_dcto() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_CLIENTE_dcto", 4, ls_nro_documento, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function

    'Public Function BusquedaCliente2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_CLIENTES", 4, Stbusquedacliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function

    Public Function BusquedaCliente() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_CLIENTES", CommandType.StoredProcedure)
            db.AsignarParametro("vi_busqueda", Stbusquedacliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCURSOR_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function BusquedaDireccion2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_DIRECCION", 6, Stidcliente, 1, iidprovincia, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function
    Public Function BusquedaDireccion() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_DIRECCION", CommandType.StoredProcedure)
            db.AsignarParametro("iidpersona", Stidcliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidprovincia", iidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCURSOR_cliente", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Busquedacontacto2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.Sp_get_contacto", 6, _
    '                              Stidcliente, 1, _
    '                              Stiddireccion, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function

    Public Function Busquedacontacto() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.Sp_get_contacto", CommandType.StoredProcedure)
            db.AsignarParametro("nidpersona", Stidcliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidireccion", Stiddireccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCURSOR_CONTACTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function BusquedaDireccion_agencia2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_direccion_xdistrito", 12, _
    '                                                                            Stidcliente, 1, _
    '                                                                            iidpais, 1, _
    '                                                                            iiddepartamento, 1, _
    '                                                                            iidprovincia, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function

    Public Function BusquedaDireccion_agencia() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_direccion_xdistrito", CommandType.StoredProcedure)
            db.AsignarParametro("iidpersona", Stidcliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidpais", iidpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iiddepartamento", iiddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidprovincia", iidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCURSOR_cliente", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function BusquedaCliente_direccion() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_direccion_busq", 8, _
    '                                                                  Stbusquedacliente, 2, _
    '                                                                  CType(Stidcliente, String), 2, _
    '                                                                  ll_idagencia, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function

End Class
