Imports AccesoDatos
Public Class dtoCPU
    Private StAccion As Integer
    Private StIP As String
    Private StArea As Integer
    Private StTipoMaq As Integer
    Private StNomEquipo As String
    Private StNomRed As String
    Private StRamMb As Integer
    Private StParticion As Integer
    Private StHDGb As Integer
    Private StReloj As Decimal
    Private StServidor As Integer
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIPReg As String
    Private StEstado As Integer
    Private StAgencia As Integer
    Private StComputador As Integer
    Private StTipoIp As Integer
    Private intTipoAlmacen As Integer
    Public Property Computador() As Integer
        Get
            Return StComputador
        End Get
        Set(ByVal value As Integer)
            StComputador = value
        End Set
    End Property

    Public Property TipoIp() As Integer
        Get
            Return StTipoIp
        End Get
        Set(ByVal value As Integer)
            StTipoIp = value
        End Set
    End Property

    Public Property TipoAlmacen() As Integer
        Get
            Return intTipoAlmacen
        End Get
        Set(ByVal value As Integer)
            intTipoAlmacen = value
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
    Public Property IP() As String
        Get
            Return StIP
        End Get
        Set(ByVal value As String)
            StIP = value
        End Set
    End Property
    Public Property Area() As Integer
        Get
            Return StArea
        End Get
        Set(ByVal value As Integer)
            StArea = value
        End Set
    End Property
    Public Property TipoMaq() As Integer
        Get
            Return StTipoMaq
        End Get
        Set(ByVal value As Integer)
            StTipoMaq = value
        End Set
    End Property
    Public Property NomEquipo() As String
        Get
            Return StNomEquipo
        End Get
        Set(ByVal value As String)
            StNomEquipo = value
        End Set
    End Property
    Public Property NomRed() As String
        Get
            Return StNomRed
        End Get
        Set(ByVal value As String)
            StNomRed = value
        End Set
    End Property
    Public Property RAM_Mb() As Integer
        Get
            Return StRamMb
        End Get
        Set(ByVal value As Integer)
            StRamMb = value
        End Set
    End Property
    Public Property Particiones() As Integer
        Get
            Return StParticion
        End Get
        Set(ByVal value As Integer)
            StParticion = value
        End Set
    End Property
    Public Property HD_Gb() As Integer
        Get
            Return StHDGb
        End Get
        Set(ByVal value As Integer)
            StHDGb = value
        End Set
    End Property
    Public Property Frec_Reloj() As Decimal
        Get
            Return StReloj
        End Get
        Set(ByVal value As Decimal)
            StReloj = value
        End Set
    End Property
    Public Property Servidor() As Integer
        Get
            Return StServidor
        End Get
        Set(ByVal value As Integer)
            StServidor = value
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
    Public Property IP_Reg() As String
        Get
            Return StIPReg
        End Get
        Set(ByVal value As String)
            StIPReg = value
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
    Public Property Agencia() As Integer
        Get
            Return StAgencia
        End Get
        Set(ByVal value As Integer)
            StAgencia = value
        End Set
    End Property
    'Public Function Lista_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_CPU", 0}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_CPU_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cpu", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_agencias_tree", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_areas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_maquinas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_estados", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_computador", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_tipo_ip", OracleClient.OracleType.Cursor)
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
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_CPU", 32, StAccion, 1, StIP, 2, StNomEquipo, 2, StNomRed, 2, StArea, 1, StTipoMaq, 1, StReloj, 1, StRamMb, 1, StParticion, 1, StHDGb, 1, StServidor, 1, StUsuario, 1, StRol, 1, StIPReg, 2, StAgencia, 1}
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
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_CPU_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_EQUIPO", StNomEquipo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRE_RED", StNomRed, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDDEPARTAMENTO_OFICINA", StArea, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPO_MAQUINA", StTipoMaq, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iFRECUENCIA_RELOJ", StReloj, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iRAM_MB", StRamMb, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNRO_PARTICIONES", StParticion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iMEMORIA_DISCO_DURO_GB", StHDGb, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iES_SERVIDOR", StServidor, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIPREGISTRO", StIPReg, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDAGENCIAS", StAgencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPO_COMPUTADOR", StComputador, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPO_IP", StTipoIp, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_almacen", TipoAlmacen, OracleClient.OracleType.Int32)

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

End Class
