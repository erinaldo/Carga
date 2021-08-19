Imports AccesoDatos

Public Class dtoProgramacionVehiculo

    '------------------------------------------------------------
    '--------- Variables para generar la salida de buses --------
    '------------------------------------------------------------
    Private iOperacion As Integer = 0
    Private iSalidaBus As Integer
    Private iRutaHorario As Integer
    Private iUnidadTransporte As Integer
    Private strFechaSalida As String = String.Empty
    Private strHoraSalida As String = String.Empty
    Private iTipoServicio As Integer
    Private iUnidadAgenciaOrigen As Integer
    Private iUnidadAgenciaDestino As Integer
    Private iUsuarioChofer As Integer
    Private strNombreTercero As String = String.Empty
    Private strRucTercero As String = String.Empty
    Private strNumeroLicencia As String = String.Empty
    Private strMarcaBus As String = String.Empty
    Private strPlacaBus As String = String.Empty
    Private strFechaLlegada As String = String.Empty
    Private iMargenError As String = String.Empty
    Private iKilometros As Integer
    Private iAgenciaFinal As Integer
    Private strHorasViaje As String = String.Empty
    Private iEstadoBus As Integer

    '-----------------------------------------------------------
    '------- Propiedades para generar la salida de buses -------
    '-----------------------------------------------------------
    Public Property Operacion As Integer
        Get
            Operacion = iOperacion
        End Get
        Set(value As Integer)
            iOperacion = value
        End Set
    End Property

    Public Property SalidaBus As Integer
        Get
            SalidaBus = iSalidaBus
        End Get
        Set(value As Integer)
            iSalidaBus = value
        End Set
    End Property

    Public Property RutaHorario As Integer
        Get
            RutaHorario = iRutaHorario
        End Get
        Set(value As Integer)
            iRutaHorario = value
        End Set
    End Property

    Public Property UnidadTransporte As Integer
        Get
            UnidadTransporte = iUnidadTransporte
        End Get
        Set(value As Integer)
            iUnidadTransporte = value
        End Set
    End Property

    Public Property FechaSalida As String
        Get
            FechaSalida = strFechaSalida
        End Get
        Set(value As String)
            strFechaSalida = value
        End Set
    End Property

    Public Property HoraSalida As String
        Get
            HoraSalida = strHoraSalida
        End Get
        Set(value As String)
            strHoraSalida = value
        End Set
    End Property

    Public Property TipoServicio As Integer
        Get
            TipoServicio = iTipoServicio
        End Get
        Set(value As Integer)
            iTipoServicio = value
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

    Public Property UsuarioChofer As Integer
        Get
            UsuarioChofer = iUsuarioChofer
        End Get
        Set(value As Integer)
            iUsuarioChofer = value
        End Set
    End Property

    Public Property NombreTercero As String
        Get
            NombreTercero = strNombreTercero
        End Get
        Set(value As String)
            strNombreTercero = value
        End Set
    End Property

    Public Property RucTercero As String
        Get
            RucTercero = strRucTercero
        End Get
        Set(value As String)
            strRucTercero = value
        End Set
    End Property

    Public Property NumeroLicencia As String
        Get
            NumeroLicencia = strNumeroLicencia
        End Get
        Set(value As String)
            strNumeroLicencia = value
        End Set
    End Property

    Public Property MarcaBus As String
        Get
            MarcaBus = strMarcaBus
        End Get
        Set(value As String)
            strMarcaBus = value
        End Set
    End Property

    Public Property PlacaBus As String
        Get
            PlacaBus = strPlacaBus
        End Get
        Set(value As String)
            strPlacaBus = value
        End Set
    End Property

    Public Property FechaLlegada As String
        Get
            FechaLlegada = strFechaLlegada
        End Get
        Set(value As String)
            strFechaLlegada = value
        End Set
    End Property

    Public Property MargenError As String
        Get
            MargenError = iMargenError
        End Get
        Set(value As String)
            iMargenError = value
        End Set
    End Property

    Public Property Kilometros As Integer
        Get
            Kilometros = iKilometros
        End Get
        Set(value As Integer)
            iKilometros = value
        End Set
    End Property

    Public Property AgenciaFinal As Integer
        Get
            AgenciaFinal = iAgenciaFinal
        End Get
        Set(value As Integer)
            iAgenciaFinal = value
        End Set
    End Property

    Public Property HorasViaje As String
        Get
            HorasViaje = strHorasViaje
        End Get
        Set(value As String)
            strHorasViaje = value
        End Set
    End Property

    Public Property Estado As Integer
        Get
            Estado = iEstadoBus
        End Get
        Set(value As Integer)
            iEstadoBus = value
        End Set
    End Property

    '------------------------------------------------------------------------
    '------- Procedimientos y Metodos para generar la salida de buses -------
    '------------------------------------------------------------------------
    Public Function fncListarUnidadOrigen() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_LISTAR_UNIDAD_ORIGEN", CommandType.StoredProcedure)
            db_bd.AsignarParametro("CUR_ORIGEN", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncListarSalidaVehiculo() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_LISTAR_PROGRAMACION_BUSES", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_ORIGEN", UnidadAgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FECHA_SALIDA", FechaSalida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("CUR_SALIDA_VEHICULO", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncListarDatosGeneralesBuses() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_LISTAR_DATOS_BUSES", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_ORIGEN", UnidadAgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CUR_BUS", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_SERVICIO", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_RUTA", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_CHOFER", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncObtenerKilometroHoraViaje() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_OBTENER_KM_HORA_VIAJE", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_ORIGEN", UnidadAgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", UnidadAgenciaDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CUR_KM", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncListarRutaBus() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_LISTAR_RUTAS_BUS", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDNRO_SALIDA", SalidaBus, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CUR_CONTROL", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncListarCiudadesGuiaTransportista() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_LISTAR_CIUDADES_GUIA_TRANS", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDNRO_SALIDA", SalidaBus, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CUR_CIUDADES", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncInsertarProgramacionBus() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_INSERTAR_PROGRAMACION_BUS", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_OPERACION", Operacion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDNRO_SALIDA", SalidaBus, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDRUTA_HORARIO", RutaHorario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_TRANSPORTE", UnidadTransporte, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FECHA_SALIDA", FechaSalida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_HORA_SALIDA", HoraSalida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDTIPO_SERVICIO", TipoServicio, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_ORIGEN", UnidadAgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", iUnidadAgenciaDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_USUARIO_CHOFER", UsuarioChofer, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_NOMBRE_TERCERO", NombreTercero, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_RUC_TERCERO", RucTercero, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_NRO_LICENCIA", NumeroLicencia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_MARCA_BUS", MarcaBus, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_PLACA_BUS", PlacaBus, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_LLEGADA", FechaLlegada, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IP", dtoUSUARIOS.IPReal, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", dtoUSUARIOS.IdLoginReal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDROL_USUARIO", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_MARGEN_ERROR", MargenError, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_NRO_KILOMETROS", Kilometros, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CUR_CONTROL", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncInsertarDestinoBus() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_INSERTAR_RUTAS_BUS", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_OPERACION", Operacion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDNRO_SALIDA", SalidaBus, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", UnidadAgenciaDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_AGENCIA_FINAL", AgenciaFinal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_MARGEN_ERROR", MargenError, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_NRO_KILOMETROS", Kilometros, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_HORAS_DE_VIAJE", HorasViaje, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("CUR_CONTROL", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fncActualizarEstadoBus() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.SP_ACTUALIZA_ESTADO_SALIDA_VEH", CommandType.StoredProcedure)
            db_bd.AsignarParametro("P_IDNRO_SALIDA", SalidaBus, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_ESTADO", UnidadAgenciaDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CUR_CONTROL", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


End Class
