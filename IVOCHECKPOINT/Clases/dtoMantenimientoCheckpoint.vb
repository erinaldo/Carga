Imports AccesoDatos

Public Class dtoMantenimientoCheckpoint

    '-------------------------------------------------------
    '--------- Variables para generar un checkpoint --------
    '-------------------------------------------------------
    Private iCheckpoint As Integer = 0
    Private iCheckpointPredecesor As Integer = 0
    Private iTipoCheckpoint As Integer = 0
    Private iProceso As Integer = 0
    Private strAbreviatura As String = String.Empty
    Private strNombreCheckpoint As String = String.Empty
    Private iVisibleUsuario As Integer = 0
    Private iVisibleCliente As Integer = 0
    Private strDescripcionWeb As String = String.Empty
    Private strDescripcionUsuario As String = String.Empty
    Private iMarca As Integer = 0

    Private iOperacion As Integer = 0

    Private iComprobante As Integer = 0
    Private iTipoComprobante As Integer = 0
    Private iCantidadBultos As Integer = 0

    '------------------------------------------------------
    '------- Propiedades para generar un checkpoint -------
    '------------------------------------------------------
    Public Property Checkpoint() As Integer
        Get
            Checkpoint = iCheckpoint
        End Get
        Set(value As Integer)
            iCheckpoint = value
        End Set
    End Property

    Public Property CheckpointPredecesor() As Integer
        Get
            CheckpointPredecesor = iCheckpointPredecesor
        End Get
        Set(value As Integer)
            iCheckpointPredecesor = value
        End Set
    End Property

    Public Property TipoCheckpoint() As Integer
        Get
            TipoCheckpoint = iTipoCheckpoint
        End Get
        Set(value As Integer)
            iTipoCheckpoint = value
        End Set
    End Property

    Public Property ProcesoCheckpoint() As Integer
        Get
            ProcesoCheckpoint = iProceso
        End Get
        Set(value As Integer)
            iProceso = value
        End Set
    End Property

    Public Property AbreviaturaCheckpoint() As String
        Get
            AbreviaturaCheckpoint = strAbreviatura
        End Get
        Set(value As String)
            strAbreviatura = value
        End Set
    End Property

    Public Property NombreCheckpoint() As String
        Get
            NombreCheckpoint = strNombreCheckpoint
        End Get
        Set(value As String)
            strNombreCheckpoint = value
        End Set
    End Property

    Public Property VisibleUsuario() As Integer
        Get
            VisibleUsuario = iVisibleUsuario
        End Get
        Set(value As Integer)
            iVisibleUsuario = value
        End Set
    End Property

    Public Property VisibleCliente() As Integer
        Get
            VisibleCliente = iVisibleCliente
        End Get
        Set(value As Integer)
            iVisibleCliente = value
        End Set
    End Property

    Public Property DescripcionWeb() As String
        Get
            DescripcionWeb = strDescripcionWeb
        End Get
        Set(value As String)
            strDescripcionWeb = value
        End Set
    End Property

    Public Property DescripcionUsuario() As String
        Get
            DescripcionUsuario = strDescripcionUsuario
        End Get
        Set(value As String)
            strDescripcionUsuario = value
        End Set
    End Property

    Public Property Marca() As Integer
        Get
            Marca = iMarca
        End Get
        Set(value As Integer)
            iMarca = value
        End Set
    End Property

    Public Property Operacion() As Integer
        Get
            Operacion = iOperacion
        End Get
        Set(value As Integer)
            iOperacion = value
        End Set
    End Property

    Public Property Comprobante() As Integer
        Get
            Comprobante = iComprobante
        End Get
        Set(value As Integer)
            iComprobante = value
        End Set
    End Property

    Public Property TipoComprobante() As Integer
        Get
            TipoComprobante = iTipoComprobante
        End Get
        Set(value As Integer)
            iTipoComprobante = value
        End Set
    End Property

    Public Property CantidadBultos() As Integer
        Get
            CantidadBultos = iCantidadBultos
        End Get
        Set(value As Integer)
            iCantidadBultos = value
        End Set
    End Property

    '-------------------------------------------------------------------
    '------- Procedimientos y Metodos para generar un checkpoint -------
    '-------------------------------------------------------------------
    Public Function fncListarTipoCheckpoint() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_TIPO_CHECKPOINT", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTAR_TIPO_CHECKPOINT", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_LISTAR_PROCESO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function fncListarCheckpoint() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_CHECKPOINT", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPERACION", Operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCHECKPOINT", Checkpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LISTAR_CHECKPOINT", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function fncInsertarCheckpoint() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_INSERTAR_CHECKPOINT", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPERACION", Operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCHECKPOINT", Checkpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_CHECKPOINT", TipoCheckpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPROCESO", ProcesoCheckpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", dtoUSUARIOS.IdLoginReal, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ABREVCHECKPOINT", AbreviaturaCheckpoint, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NOMBRE_CHECKPOINT", NombreCheckpoint, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_VISIBLE_CLIENTE", VisibleCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_VISIBLE_USUARIO", VisibleUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_NOMBRE_WEB", DescripcionWeb, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NOMBRE_USUARIO", DescripcionUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IP", dtoUSUARIOS.IPReal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function fncInsertarCheckpointPredecesor() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_INS_CHECKPOINT_PREDECESOR", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPERACION", Operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCHECKPOINT", Checkpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCHECKPOINT_PREDECESOR", CheckpointPredecesor, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", dtoUSUARIOS.IdLoginReal, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", dtoUSUARIOS.IPReal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_MARCA", Marca, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function fncListarCheckpointConfigurados() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_CHECKPOINT_CONFIG", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDCHECKPOINT", Checkpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LISTAR_CHECKPOINTCONFIG", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function fncInsertarTrackingCheckpoint() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_INSERTAR_TRACKING", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDCOMPROBANTE", Comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", TipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCHECKPOINT", Checkpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUNIDAD_AGENCIA", dtoUSUARIOS.IdUnidadAgenciaReal, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIA", dtoUSUARIOS.IdAgenciaReal, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", dtoUSUARIOS.IdLoginReal, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CANTIDAD_BULTOS", CantidadBultos, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", dtoUSUARIOS.IPReal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
End Class
