Imports AccesoDatos

Public Class dtoGuiaRemisionTransportista

    '-------------------------------------------------------------------------
    '--------- Variables para generar la Guía Remisión Transportista  --------
    '-------------------------------------------------------------------------
    Private iOperacion As Integer
    Private iUnidadAgenciaOrigen As Integer
    Private iUnidadAgenciaDestino As Integer
    Private iAgenciaOrigen As Integer
    Private strFechaInicio As String = String.Empty
    Private strFechaFinal As String = String.Empty
    Private iIdTipo_Comprobante As Integer

    '-------------------------------------------------------------------------
    '------- Propiedades para generar la Guía Remisión Transportista  --------
    '-------------------------------------------------------------------------
    Public Property Operacion As Integer
        Get
            Operacion = iOperacion
        End Get
        Set(value As Integer)
            iOperacion = value
        End Set
    End Property

    Public Property UnidadAgenciaOrigen As Integer
        Get
            UnidadAgenciaOrigen = iUnidadAgenciaOrigen
        End Get
        Set(value As Integer)
            iUnidadAgenciaOrigen = value
        End Set
    End Property

    Public Property UnidadAgenciaDestino As Integer
        Get
            UnidadAgenciaDestino = iUnidadAgenciaDestino
        End Get
        Set(value As Integer)
            iUnidadAgenciaDestino = value
        End Set
    End Property

    Public Property AgenciaOrigen As Integer
        Get
            AgenciaOrigen = iAgenciaOrigen
        End Get
        Set(value As Integer)
            iAgenciaOrigen = value
        End Set
    End Property

    Public Property FechaInicio As String
        Get
            FechaInicio = strFechaInicio
        End Get
        Set(value As String)
            strFechaInicio = value
        End Set
    End Property

    Public Property FechaFinal As String
        Get
            FechaFinal = strFechaFinal
        End Get
        Set(value As String)
            strFechaFinal = value
        End Set
    End Property

    Public Property IdTipo_Comprobante As Integer
        Get
            IdTipo_Comprobante = iIdTipo_Comprobante
        End Get
        Set(value As Integer)
            iIdTipo_Comprobante = value
        End Set
    End Property

    '------------------------------------------------------------------------------------
    '------- Procedimientos y Metodos para generar la Guía Remisión Transportista -------
    '------------------------------------------------------------------------------------
    Public Function fncListarUnidadOrigen() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_L_UNIDAD_AGENCIA", CommandType.StoredProcedure)
            db_bd.AsignarParametro("CUR_L_UNIDAD_AGENCIA", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncListarAgenciaOrigen() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_LISTAR_AGENCIA", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA", UnidadAgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CUR_AGENCIA", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncListarGuiaRemision() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_GUIA_TRANSPORTE", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_ORIGEN", UnidadAgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", UnidadAgenciaDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDAGENCIAS", AgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FECHA_INICIO", FechaInicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", FechaFinal, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("CUR_GUIA", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncObtenerCorrelativoGuiaRemision() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_GET_COMPROBANTE", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDTIPO_COMPROBANTE", IdTipo_Comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDAGENCIAS", dtoUSUARIOS.m_iIdAgenciaReal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


End Class
