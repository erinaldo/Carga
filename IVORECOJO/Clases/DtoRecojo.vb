Imports AccesoDatos
Public Class DtoRecojo
#Region "Propiedad"
    Private sAtendidoPor As String
    Public Property AtendidoPor() As String
        Get
            Return sAtendidoPor
        End Get
        Set(ByVal value As String)
            sAtendidoPor = value
        End Set
    End Property

    Private sFechaAtencion As String
    Public Property FechaAtencion() As String
        Get
            Return sFechaAtencion
        End Get
        Set(ByVal value As String)
            sFechaAtencion = value
        End Set
    End Property

    Private sHoraAtencion As String
    Public Property HoraAtencion() As String
        Get
            Return sHoraAtencion
        End Get
        Set(ByVal value As String)
            sHoraAtencion = value
        End Set
    End Property

    Private iAtendido As Integer
    Public Property Atendido() As Integer
        Get
            Return iAtendido
        End Get
        Set(ByVal value As Integer)
            iAtendido = value
        End Set
    End Property
    Private iTipo As Integer
    Public Property Tipo() As Integer
        Get
            Return iTipo
        End Get
        Set(ByVal value As Integer)
            iTipo = value
        End Set
    End Property

    Private iIncidencia As Integer
    Public Property Incidencia() As Integer
        Get
            Return iIncidencia
        End Get
        Set(ByVal value As Integer)
            iIncidencia = value
        End Set
    End Property

    Private iParcial As Integer
    Public Property Parcial() As Integer
        Get
            Return iParcial
        End Get
        Set(ByVal value As Integer)
            iParcial = value
        End Set
    End Property

    Private iCiudad As Integer
    Public Property Ciudad() As Integer
        Get
            Return iCiudad
        End Get
        Set(ByVal value As Integer)
            iCiudad = value
        End Set
    End Property

    Private iAgencia As Integer
    Public Property Agencia() As Integer
        Get
            Return iAgencia
        End Get
        Set(ByVal value As Integer)
            iAgencia = value
        End Set
    End Property

    Private iAgenciaOrigen As Integer
    Public Property AgenciaOrigen() As Integer
        Get
            Return iAgenciaOrigen
        End Get
        Set(ByVal value As Integer)
            iAgenciaOrigen = value
        End Set
    End Property

    Private iTipoComprobante As Integer
    Public Property TipoComprobante() As Integer
        Get
            Return iTipoComprobante
        End Get
        Set(ByVal value As Integer)
            iTipoComprobante = value
        End Set
    End Property

    Private sSerie As String
    Public Property Serie() As String
        Get
            Return sSerie
        End Get
        Set(ByVal value As String)
            sSerie = value
        End Set
    End Property

    Private sNumero As String
    Public Property Numero() As String
        Get
            Return sNumero
        End Get
        Set(ByVal value As String)
            sNumero = value
        End Set
    End Property

    Private sGuia As String
    Public Property Guia() As String
        Get
            Return sGuia
        End Get
        Set(ByVal value As String)
            sGuia = value
        End Set
    End Property

    Private iCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return iCliente
        End Get
        Set(ByVal value As Integer)
            iCliente = value
        End Set
    End Property

    Private iProceso As Integer
    Public Property Proceso() As Integer
        Get
            Return iProceso
        End Get
        Set(ByVal value As Integer)
            iProceso = value
        End Set
    End Property

    Private iCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return iCantidad
        End Get
        Set(ByVal value As Integer)
            iCantidad = value
        End Set
    End Property

    Private sObservacion As String
    Public Property Observacion() As String
        Get
            Return sObservacion
        End Get
        Set(ByVal value As String)
            sObservacion = value
        End Set
    End Property

    Private sFecha As String
    Public Property Fecha() As String
        Get
            Return sFecha
        End Get
        Set(ByVal value As String)
            sFecha = value
        End Set
    End Property

    Private sFechaRecojo As String
    Public Property FechaRecojo() As String
        Get
            Return sFechaRecojo
        End Get
        Set(ByVal value As String)
            sFechaRecojo = value
        End Set
    End Property

    Private iTipoRecojo As Integer
    Public Property Tiporecojo() As Integer
        Get
            Return iTipoRecojo
        End Get
        Set(ByVal value As Integer)
            iTipoRecojo = value
        End Set
    End Property

    Private iEstado As Integer
    Public Property Estado() As Integer
        Get
            Return iEstado
        End Get
        Set(ByVal value As Integer)
            iEstado = value
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

    Private iRecojo As Integer
    Public Property Recojo() As Integer
        Get
            Return iRecojo
        End Get
        Set(ByVal value As Integer)
            iRecojo = value
        End Set
    End Property

    Private sHoraListo As String
    Public Property HoraListo() As String
        Get
            Return sHoraListo
        End Get
        Set(ByVal value As String)
            sHoraListo = value
        End Set
    End Property

    Private sHoraCierre As String
    Public Property HoraCierre() As String
        Get
            Return sHoraCierre
        End Get
        Set(ByVal value As String)
            sHoraCierre = value
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
    Private intSituacion As Integer
    Public Property Situacion() As Integer
        Get
            Return intSituacion
        End Get
        Set(ByVal value As Integer)
            intSituacion = value
        End Set
    End Property


#End Region
    Function ListarEstado(Optional ByVal estado As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_estado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int16)
            db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    'Function ListarEstado() As DataTable
    '    Dim db As New BaseDatos
    '    Try
    '        db.Conectar()
    '        db.CrearComando("PKG_RECOJO_1.sp_listar_estado", CommandType.StoredProcedure)
    '        db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
    '        Dim ds As DataSet = db.EjecutarDataSet
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
    '                Throw New Exception(ds.Tables(1).Rows(0).Item(1))
    '            End If
    '        End If
    '        Return ds.Tables(0)
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    Finally
    '        db.Desconectar()
    '    End Try
    'End Function

    Function ListarRuta(Optional ByVal opcion As Integer = 0, Optional ByVal tipo As Integer = 0) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_ciudad", Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_ruta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    'Function ListarRuta(Optional ByVal opcion As Integer = 0) As DataTable
    '    Dim db As New BaseDatos
    '    Try
    '        db.Conectar()
    '        db.CrearComando("PKG_RECOJO_1.sp_listar_ruta", CommandType.StoredProcedure)
    '        db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int16)
    '        db.AsignarParametro("co_ruta", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
    '        Dim ds As DataSet = db.EjecutarDataSet
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
    '                Throw New Exception(ds.Tables(1).Rows(0).Item(1))
    '            End If
    '        End If
    '        Return ds.Tables(0)
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    Finally
    '        db.Desconectar()
    '    End Try
    'End Function

    Function ListarMovil() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_movil", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ruta", iRuta, OracleClient.OracleType.Int16)
            db.AsignarParametro("co_movil", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub ActualizarSeleccion(ByVal id As Integer, ByVal estado As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_actualizar_seleccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int16)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable()
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ListarRecojo(ByVal FechaHora As String, Optional ByVal opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_recojo", iTipoRecojo, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_checkpoint", iEstado, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_ruta", iRuta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha_hora", FechaHora, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_recojo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Function ActualizarRuta() As String
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_actualizar_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_registro", OracleClient.OracleType.Cursor)
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

    Function ActualizarRuta(ByVal FechaHora As String, Optional ByVal opcion As Integer = 0) As Integer
        Dim db As New BaseDatos

        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_actualizar_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int16)
            db.AsignarParametro("vi_fecha_hora", FechaHora, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_registro", OracleClient.OracleType.Cursor)
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

    Function ActualizarProgramacion(ByVal programacion As Integer, ByVal fecha As String, ByVal ruta As Integer, ByVal recojo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_actualizar_programacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_programacion", programacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ruta", ruta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_recojo", recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_movil", OracleClient.OracleType.Cursor)
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

    Sub CambiarEstado(Optional ByVal opcion As Integer = 0)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_aprobar", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", iRecojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", sObservacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", iEstado, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable()
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ListarRecojo(ByVal opcion As Integer, Optional ByVal tipo As Integer = 0) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", Fecha, OracleClient.OracleType.VarChar)
            '            db.AsignarParametro("vi_fechaRecojo", FechaRecojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_recojo", iTipoRecojo, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_checkpoint", iEstado, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_ruta", iRuta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_ruta", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_situacion", Situacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_recojo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_modificado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(2).Rows(0).Item(1))
                End If
            End If
            Dim d As DataTable = ds.Tables(1)
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function ListarRecojo() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", iRecojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_recojo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub GenerarIncidencia()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_generar_incidencia", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", iRecojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_observacion", sObservacion, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("vi_fecha_atencion", sFechaAtencion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_atendido", iAtendido, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", iTipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_incidencia", iIncidencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub Atender()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_atender", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", iRecojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_atendido_por", sAtendidoPor, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_observacion", sObservacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_atendido", iAtendido, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_parcial", iParcial, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", iEstado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_ciudad", iCiudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", iAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", iTipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_serie", sSerie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", sNumero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_guia", sGuia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_cliente", iCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_origen", iAgenciaOrigen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proceso", iProceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cantidad", iCantidad, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Public Shared Function ObtieneRuta(ByVal iruta As Integer) As String
        Dim db_bd As New BaseDatos
        Dim s As String
        Try
            Dim ls_sql As String
            ls_sql = "select sf_get_ruta (" & iruta & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            s = CType(db_bd.EjecutarEscalar(), String)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return s
    End Function

    Shared Function InicioAtendido() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_inicio_atendido", CommandType.StoredProcedure)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(3).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(3).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(3).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub ActualizarModificado(ByVal fecha As String, ByVal modificado As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_actualizar_modificado", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_modificado", modificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Function ListarRutaDetalle() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_ruta_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ruta", iRuta, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_detalle", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub Reprogramar(Optional ByVal Reprogramar As Integer = 0, Optional ByVal Reasignar As Integer = 0, Optional ByVal opcion As Integer = 0)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_reprogramar", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", iRecojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora_listo", sHoraListo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora_cierre", sHoraCierre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ruta", iRuta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_reprogramar", Reprogramar, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_reasignar", Reasignar, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable()
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    'Sub Reprogramar()
    '    Dim db As New BaseDatos
    '    Try
    '        db.Conectar()
    '        db.CrearComando("PKG_RECOJO_1.sp_reprogramar", CommandType.StoredProcedure)
    '        db.AsignarParametro("ni_recojo", iRecojo, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("vi_hora_listo", sHoraListo, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("vi_hora_cierre", sHoraCierre, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
    '        db.Desconectar()
    '        Dim dt As DataTable = db.EjecutarDataTable()
    '        If dt.Rows.Count > 0 Then
    '            If Not IsDBNull(dt.Rows(0).Item(0)) Then
    '                Throw New Exception(dt.Rows(0).Item(1))
    '            End If
    '        End If
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    Finally
    '        db.Desconectar()
    '    End Try
    'End Sub

    Function Inicio() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_inicio_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_estado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ruta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(3).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(3).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(3).Rows(0).Item(1))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarRutaDetalle(ByVal ruta As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_ruta_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ruta", ruta, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Function ListarRuta(ByVal inicio As String, ByVal fin As String, ByVal ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Function GrabarRuta(ByVal id As Integer, ByVal fecha As String, ByVal ruta As String, ByVal origen As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal color As Integer) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ruta", ruta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_color", color, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
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

    Sub GrabarRutaDetalle(ByVal id As Integer, ByVal departamento As Integer, ByVal provincia As Integer, ByVal distrito As Integer, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_ruta_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_departamento", departamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_provincia", provincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_distrito", distrito, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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

    Sub AnularRuta(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_anular_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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

    Function ListarProveedor(ByVal ciudad As Integer, ByVal estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_proveedor", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub GrabarProveedor(ByVal id As Integer, ByVal ruc As String, ByVal razon_social As String, ByVal ciudad As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal estado As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_proveedor", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_razon_social", razon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
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

    Function ListarChofer(ByVal ciudad As Integer, ByVal proveedor As Integer, ByVal estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_chofer", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub GrabarChofer(ByVal id As Integer, ByVal nombres As String, ByVal ApellidoPaterno As String, ByVal ApellidoMaterno As String, ByVal licencia As String, ByVal ciudad As Integer, ByVal proveedor As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal estado As Integer, ByVal UsuarioPersonal As Integer, ByVal login As String, ByVal contraseña As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_chofer", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nombres", nombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_apellido_paterno", ApellidoPaterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_apellido_materno", ApellidoMaterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_licencia", licencia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario_personal", UsuarioPersonal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_usuario", login, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_contraseña", contraseña, OracleClient.OracleType.VarChar)

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

    Function ListarAyudante(ByVal estado As Integer, ByVal ciudad As Integer, ByVal proveedor As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_ayudante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub GrabarAyudante(ByVal id As Integer, ByVal nombres As String, ByVal apellidos As String, ByVal usuario As Integer, ByVal ip As String, ByVal estado As Integer, ByVal ciudad As Integer, ByVal proveedor As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_ayudante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nombres", nombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_apellidos", apellidos, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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

    Function ListarMovil(ByVal ciudad As Integer, ByVal proveedor As Integer, ByVal estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_movil", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Sub GrabarMovil(ByVal id As Integer, ByVal ciudad As Integer, ByVal placa As String, ByVal capacidad As Integer, ByVal tipo As Integer, ByVal modelo As Integer, _
                    ByVal usuario As Integer, ByVal ip As String, ByVal estado As Integer, ByVal proveedor As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_grabar_movil", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_placa", placa, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_capacidad", capacidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_modelo", modelo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_proveedor", proveedor, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
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

    Function ListarTipoUnidad() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_tipo_unidad", CommandType.StoredProcedure)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Function ListarModeloUnidad() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_modelo_unidad", CommandType.StoredProcedure)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Public Shared Function RecojoRuta(ByVal recojo As Integer, ByVal ruta As Integer) As Boolean
        Dim db_bd As New BaseDatos
        Dim i As Integer
        Try
            Dim ls_sql As String
            ls_sql = "select PKG_RECOJO_1.sf_get_recojo_ruta (" & recojo & "," & ruta & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            i = db_bd.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return i
    End Function

    Function ListarRecojo(ByVal fecha As String, ByVal tipo_recojo As Integer, ByVal estado As Integer, ByVal ruta As Integer, _
                          ByVal tipo_ruta As Integer, ByVal situacion As Integer, ByVal funcionario As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_recojo", tipo_recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_checkpoint", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ruta", ruta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_ruta", tipo_ruta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_situacion", situacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Function ListarCliente(ByVal funcionario As Integer, ByVal perfil As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_perfil", perfil, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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

    Public Shared Function ProgramacionRecojo(ByVal id As Integer, ByVal id_det As Integer, ByVal dia As Integer) As String
        Dim db_bd As New BaseDatos
        Dim s As Integer
        Try
            Dim ls_sql As String
            ls_sql = "select pkg_recojo_1.sf_get_programacion_recojo (" & id & "," & id_det & "," & dia & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            s = db_bd.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return IIf(s = 1, True, False)
    End Function

    Shared Function AnularDiaProgramado(ByVal id As Integer, ByVal id_det As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_anular_dia_programado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_det", id_det, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarComprobante(ByVal recojo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO_1.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", recojo, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
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
