Imports AccesoDatos
Public Class DtoProgramacion
    Private sFecha As String

    Private iId As Integer
    Public Property id() As Integer
        Get
            Return iId
        End Get
        Set(ByVal value As Integer)
            iId = value
        End Set
    End Property


    Public Property Fecha() As String
        Get
            Return sFecha
        End Get
        Set(ByVal value As String)
            sFecha = value
        End Set
    End Property

    Private sHora As String
    Public Property Hora() As String
        Get
            Return sHora
        End Get
        Set(ByVal value As String)
            sHora = value
        End Set
    End Property
    Private iUsuario As Integer
    Public Property Usuario() As Integer
        Get
            Return iUsuario
        End Get
        Set(ByVal value As Integer)
            iUsuario = value
        End Set
    End Property
    Private sIp As String
    Public Property Ip() As String
        Get
            Return sIp
        End Get
        Set(ByVal value As String)
            sIp = value
        End Set
    End Property
    Private iRuta As Integer
    Public Property Ruta() As Integer
        Get
            Return iRuta
        End Get
        Set(ByVal value As Integer)
            iRuta = value
        End Set
    End Property
    Private iMovil As Integer
    Public Property Movil() As Integer
        Get
            Return iMovil
        End Get
        Set(ByVal value As Integer)
            iMovil = value
        End Set
    End Property
    Private iChofer As Integer
    Public Property Chofer() As Integer
        Get
            Return iChofer
        End Get
        Set(ByVal value As Integer)
            iChofer = value
        End Set
    End Property

    Private iAyudante As Integer
    Public Property Ayudante() As Integer
        Get
            Return iAyudante
        End Get
        Set(ByVal value As Integer)
            iAyudante = value
        End Set
    End Property

    Private intProveedor As Integer
    Public Property Proveedor() As Integer
        Get
            Return intProveedor
        End Get
        Set(ByVal value As Integer)
            intProveedor = value
        End Set
    End Property

    Private strNumeroMovil As String
    Public Property NumeroMovil() As String
        Get
            Return strNumeroMovil
        End Get
        Set(ByVal value As String)
            strNumeroMovil = value
        End Set
    End Property


    Function Inicio(ByVal ciudad As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_inicio_programacion", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_ruta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_proveedor", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Inicio2(ByVal ciudad As Integer, ByVal proveedor As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_inicio_programacion_2", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_movil", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_chofer", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ayudante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Grabar(ByVal opcion As Integer) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_programacion_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_id", iId, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora", sHora, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ruta", iRuta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_movil", iMovil, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_chofer", iChofer, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", intProveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_numero_movil", strNumeroMovil, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_programacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0).Rows(0).Item(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Listar(ByVal inicio As String, ByVal fin As String, ByVal tipo As Integer, ByVal ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_programacion_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_programacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub GrabarAyudante()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_programa_ayudante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ayudante", iAyudante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_programacion", iId, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function Listar(ByVal id As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_programacion_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_programacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ayudante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(2).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarTipo() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_tipo", CommandType.StoredProcedure)
            db.AsignarParametro("co_tipo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(2).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarRuta(ByVal id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_programacion_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_programacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ayudante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(2).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub Anular(ByVal id As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_anular", CommandType.StoredProcedure)
            db.AsignarParametro("ni_programacion", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function SugerirNmeroMovil(ByVal chofer As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_sugerir_numero_movil", CommandType.StoredProcedure)
            db.AsignarParametro("ni_chofer", chofer, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

End Class
