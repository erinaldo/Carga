Imports AccesoDatos
Public Class dtoAprobacion
    Private ApControl As Integer
    Private ApCodigoPersona As String
    Private ApIDConfigCtaCte As Integer
    Private ApNumeroControl As String
    Private ApLineaOtorgada As Double
    Private ApSobreGiro As Double
    Private ApTotalAsignado As Double
    Private ApEstadoRegistro As Integer
    Private ApUsuarioPersonal As Integer
    Private ApIDRolUsuario As Integer
    Private APIP As String
    Private AID_SOLICITUD_CREDITO As Integer
    Private APORCENTAJE_SOBREGIRO As Double

    Public Property Control() As Integer
        Get
            Return ApControl
        End Get
        Set(ByVal value As Integer)
            ApControl = value
        End Set
    End Property
    Public Property CodigoPersona() As String
        Get
            Return ApCodigoPersona
        End Get
        Set(ByVal value As String)
            ApCodigoPersona = value
        End Set
    End Property
    Public Property IDConfigCtaCte() As Integer
        Get
            Return ApIDConfigCtaCte
        End Get
        Set(ByVal value As Integer)
            ApIDConfigCtaCte = value
        End Set
    End Property
    Public Property NumeroControl() As String
        Get
            Return ApNumeroControl
        End Get
        Set(ByVal value As String)
            ApNumeroControl = value
        End Set
    End Property
    Public Property LineaOtorgada() As Double
        Get
            Return ApLineaOtorgada
        End Get
        Set(ByVal value As Double)
            ApLineaOtorgada = value
        End Set
    End Property
    Public Property SobreGiro() As Double
        Get
            Return ApSobreGiro
        End Get
        Set(ByVal value As Double)
            ApSobreGiro = value
        End Set
    End Property
    Public Property TotalAsignado() As Double
        Get
            Return ApTotalAsignado
        End Get
        Set(ByVal value As Double)
            ApTotalAsignado = value
        End Set
    End Property
    Public Property EstadoRegistro() As Integer
        Get
            Return ApEstadoRegistro
        End Get
        Set(ByVal value As Integer)
            ApEstadoRegistro = value
        End Set
    End Property
    Public Property UsuarioPersonal() As Integer
        Get
            Return ApUsuarioPersonal
        End Get
        Set(ByVal value As Integer)
            ApUsuarioPersonal = value
        End Set
    End Property
    Public Property IDRolUsuario() As Integer
        Get
            Return ApIDRolUsuario
        End Get
        Set(ByVal value As Integer)
            ApIDRolUsuario = value
        End Set
    End Property
    Public Property ID_SOLICITUD_CREDITO() As Integer
        Get
            Return AID_SOLICITUD_CREDITO
        End Get
        Set(ByVal value As Integer)
            AID_SOLICITUD_CREDITO = value
        End Set
    End Property

    Public Property PORCENTAJE_SOBREGIRO() As Double
        Get
            Return APORCENTAJE_SOBREGIRO
        End Get
        Set(ByVal value As Double)
            APORCENTAJE_SOBREGIRO = value
        End Set
    End Property

    Public Property IP() As String
        Get
            Return APIP
        End Get
        Set(ByVal value As String)
            APIP = value
        End Set
    End Property

    Sub Aprobar(ByVal id As Integer, ByVal estado As Integer, Optional ByVal monto As Double = 0, Optional ByVal observaciones As String = "")
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_UPD_APROBAR_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDSOLICITUD_CREDITO", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observaciones", observaciones, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fecha", Date.Now.ToShortDateString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db = Nothing
        End Try
    End Sub

    Public Function GrabaAprobacion() As DataTable
        Try
            Dim objBaseDatos As New BaseDatos
            objBaseDatos.Conectar()
            Dim sql As String = "PKG_IVOPERSONA.SP_INSUPD_CONFIG_CTACTE"
            objBaseDatos.CrearComando(sql, CommandType.StoredProcedure)
            objBaseDatos.AsignarParametro("iCONTROL", ApControl, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iCODIGOPERSONA", ApCodigoPersona, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("iIDCONFIG_CTACTE", ApIDConfigCtaCte, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("iNRO_CONTROL", ApNumeroControl, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("iLINEA_SOLICITADA", ApLineaOtorgada, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iSOBREGIRO", ApSobreGiro, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iTOTAL_ASIGNADO", ApTotalAsignado, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iESTADO_REGISTRO", ApEstadoRegistro, OracleClient.OracleType.Int16)
            objBaseDatos.AsignarParametro("iID_SOLICITUD_CREDITO", AID_SOLICITUD_CREDITO, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iPORCENTAJE_SOBREGIRO", APORCENTAJE_SOBREGIRO, OracleClient.OracleType.Number)
            objBaseDatos.AsignarParametro("iIDUSUARIO_PERSONAL", ApUsuarioPersonal, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iIDROL_USUARIO", ApIDRolUsuario, OracleClient.OracleType.Int32)
            objBaseDatos.AsignarParametro("iIP", APIP, OracleClient.OracleType.VarChar)
            objBaseDatos.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor, ParameterDirection.Output)
            objBaseDatos.Desconectar()
            Return objBaseDatos.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Shared Function CondicionPago(ByVal id As Integer) As String
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select sf_get_condicion_pago(" & id & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'db_bd.AsignarParametro("ni_idunidad_agencia", idUnidadCiudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            flag = db_bd.EjecutarEscalar()
            'Desconectar 
            db_bd.Desconectar()
            'Ejecutando el escalar 
            'Return db_bd.EjecutarEscalar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Sub DesactivarCtaCte(ByVal cliente As Integer, ByVal usuario As Integer, ByVal rol As Integer, ByVal ip As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_DESACTIVAR_CTACTE", CommandType.StoredProcedure)
            db.AsignarParametro("iIDPERSONA", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", ip, OracleClient.OracleType.VarChar)
            db.EjecutarComando()
            db.Desconectar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Function Solicitud(ByVal estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_SOLICITUD_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("NI_ESTADO", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function
    Function Solicitud(ByVal estado As Integer, ByVal usuario As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_SOLICITUD_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("NI_ESTADO", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("NI_USUARIO", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

    Function HistorialCredito(ByVal cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_HISTORIAL_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("NI_CLIENTE", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

End Class
