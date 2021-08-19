Imports AccesoDatos

Public Class clsFacturacionEspecial

#Region "Variables y Propiedades"
    Dim MyIdPersona As Integer = 0
    Dim MyRazonSocial As String = String.Empty
    Dim MyIdUsuario_Personal As Integer = 0
    Dim MyFechaInicio As String
    Dim MyFechaFinal As String

    Dim MyFacturaFechaInicio As String
    Dim MyFacturaFechaFinal As String

    Dim MyIdFactura As Integer = 0

    Public Property ID_PERSONA As Integer
        Get
            ID_PERSONA = MyIdPersona
        End Get
        Set(value As Integer)
            MyIdPersona = value
        End Set
    End Property
    Public Property RAZON_SOCIAL As String
        Get
            RAZON_SOCIAL = MyRazonSocial
        End Get
        Set(value As String)
            MyRazonSocial = value
        End Set
    End Property
    Public Property ID_USUARIO_PERSONAL As Integer
        Get
            ID_USUARIO_PERSONAL = MyIdUsuario_Personal
        End Get
        Set(value As Integer)
            MyIdUsuario_Personal = value
        End Set
    End Property
    Public Property FECHA_INICIO As String
        Get
            FECHA_INICIO = MyFechaInicio
        End Get
        Set(value As String)
            MyFechaInicio = value
        End Set
    End Property
    Public Property FECHA_FINAL As String
        Get
            FECHA_FINAL = MyFechaFinal
        End Get
        Set(value As String)
            MyFechaFinal = value
        End Set
    End Property

    Public Property FECHA_FACTURA_INICIO As String
        Get
            FECHA_FACTURA_INICIO = MyFacturaFechaInicio
        End Get
        Set(value As String)
            MyFacturaFechaInicio = value
        End Set
    End Property
    Public Property FECHA_FACTURA_FINAL As String
        Get
            FECHA_FACTURA_FINAL = MyFacturaFechaFinal
        End Get
        Set(value As String)
            MyFacturaFechaFinal = value
        End Set
    End Property

    Public Property ID_FACTURA As Integer
        Get
            ID_FACTURA = MyIdFactura
        End Get
        Set(value As Integer)
            MyIdFactura = value
        End Set
    End Property
#End Region

#Region "Funciones y Procedimiento"
    Public Function FNLISTAR_PERSONA_1_Y_2() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_PERSONA_1_Y_2", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", ID_PERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CODIGO_CLIENTE", RAZON_SOCIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_PERSONA_1_Y_2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function FNLISTAR_GUIAS_PENDIENTES() As DataSet
        Dim db As New BaseDatos
        Dim ds As DataSet
        Try

            db.Conectar()
            db.CrearComando("PKG_PRUEBA.SP_PRORATEO_GUIAS_ENVIO", CommandType.StoredProcedure)
            db.AsignarParametro("P_FECHA_INICIO", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", ID_USUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", ID_PERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_GUIAS_ENVIO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            ds = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function FNLISTAR_FACTURAS() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_PRUEBA.SP_LISTAR_FACTURA_ESPECIAL", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPE", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", ID_PERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_FACTURA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FACTURA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_FACTURAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function FNFACTURAS_GUIAS() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_PRUEBA.SP_FACTURAS_GUIAS_ESPECIAL", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", ID_FACTURA, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_FACTURAS_GUIAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function FNCARGAR_DIRECCION_CLIENTE() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_cargar_direccion_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("codigo", ID_PERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_direccion", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region



End Class
