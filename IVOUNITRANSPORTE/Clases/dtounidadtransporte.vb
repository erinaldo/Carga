Imports AccesoDatos
Public Class dtounitransporte
    Private icontrol As Integer
    Private idunitransporte As Integer
    Private inrounitransporte As Integer
    Private splaca As String
    Private inro_ejes As Integer
    Private iresponsable As Integer
    Private icapacidad As Integer
    Private idmodelo_unidad As Integer
    Private idtipo_unidad_transporte As Integer
    Private inro_pisos As Integer
    Private inro_televisores As Integer
    Private ipeso_vehiculo_toneladas As Double
    Private inro_banios As Integer
    Private ipeso_maximo_carga_kg As Double
    Private idrol_usuario As Integer
    Private iip As String
    Private iidusuario_personal As Integer
    Private nidestado_registro As Integer
    Private iiadagencia_unidad_transporte As Integer
    Private iiadagencia As Integer
    Private iactual As Integer
    Private scertificadohabilitavehicular As String
    Private iidtipo_servicio As Long
    Private iSimulado As Integer

    Public Property Simulado() As Integer
        Get
            Return iSimulado
        End Get
        Set(ByVal value As Integer)
            iSimulado = value
        End Set
    End Property

    Public Property idtipo_servicio() As Long
        Get
            Return iidtipo_servicio
        End Get
        Set(ByVal value As Long)
            iidtipo_servicio = value
        End Set
    End Property

    Public Property control() As Integer
        Get
            Return icontrol
        End Get
        Set(ByVal value As Integer)
            icontrol = value
        End Set
    End Property
    Public Property unitransporte() As Integer
        Get
            Return idunitransporte
        End Get
        Set(ByVal value As Integer)
            idunitransporte = value
        End Set
    End Property
    Public Property nrounitransporte() As Integer
        Get
            Return inrounitransporte
        End Get
        Set(ByVal value As Integer)
            inrounitransporte = value
        End Set
    End Property
    Public Property placa() As String
        Get
            Return splaca
        End Get
        Set(ByVal value As String)
            splaca = value
        End Set
    End Property
    Public Property certificadohabilitavehicular() As String
        Get
            Return scertificadohabilitavehicular
        End Get
        Set(ByVal value As String)
            scertificadohabilitavehicular = value
        End Set
    End Property
    Public Property nro_ejes() As Integer
        Get
            Return inro_ejes
        End Get
        Set(ByVal value As Integer)
            inro_ejes = value
        End Set
    End Property
    Public Property responsable() As Integer
        Get
            Return iresponsable
        End Get
        Set(ByVal value As Integer)
            iresponsable = value
        End Set
    End Property
    Public Property capacidad() As Integer
        Get
            Return icapacidad
        End Get
        Set(ByVal value As Integer)
            icapacidad = value
        End Set
    End Property
    Public Property modelo_unidad() As Integer
        Get
            Return idmodelo_unidad
        End Get
        Set(ByVal value As Integer)
            idmodelo_unidad = value
        End Set
    End Property
    Public Property tipo_unidad_transporte() As Integer
        Get
            Return idtipo_unidad_transporte
        End Get
        Set(ByVal value As Integer)
            idtipo_unidad_transporte = value
        End Set
    End Property
    Public Property nro_pisos() As Integer
        Get
            Return inro_pisos
        End Get
        Set(ByVal value As Integer)
            inro_pisos = value
        End Set
    End Property
    Public Property nro_televisores() As Integer
        Get
            Return inro_televisores
        End Get
        Set(ByVal value As Integer)
            inro_televisores = value
        End Set
    End Property
    Public Property peso_vehiculo_toneladas() As Double
        Get
            Return ipeso_vehiculo_toneladas
        End Get
        Set(ByVal value As Double)
            ipeso_vehiculo_toneladas = value
        End Set
    End Property
    Public Property nro_banios() As Integer
        Get
            Return inro_banios
        End Get
        Set(ByVal value As Integer)
            inro_banios = value
        End Set
    End Property
    Public Property peso_maximo_carga() As Double
        Get
            Return ipeso_maximo_carga_kg
        End Get
        Set(ByVal value As Double)
            ipeso_maximo_carga_kg = value
        End Set
    End Property
    Public Property rolusuario() As Integer
        Get
            Return idrol_usuario
        End Get
        Set(ByVal value As Integer)
            idrol_usuario = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return iip
        End Get
        Set(ByVal value As String)
            iip = value
        End Set
    End Property
    Public Property usuario_personal() As Integer
        Get
            Return iidusuario_personal
        End Get
        Set(ByVal value As Integer)
            iidusuario_personal = value
        End Set
    End Property
    Public Property estado_registro() As Integer
        Get
            Return nidestado_registro
        End Get
        Set(ByVal value As Integer)
            nidestado_registro = value
        End Set
    End Property
    Public Property agencia_unidad_transporte() As Integer
        Get
            Return iiadagencia_unidad_transporte
        End Get
        Set(ByVal value As Integer)
            iiadagencia_unidad_transporte = value
        End Set
    End Property
    Public Property agencia() As Integer
        Get
            Return iiadagencia
        End Get
        Set(ByVal value As Integer)
            iiadagencia = value
        End Set
    End Property
    Public Property actual() As Integer
        Get
            Return iactual
        End Get
        Set(ByVal value As Integer)
            iactual = value
        End Set
    End Property

    Private intRecojo As Integer
    Public Property Recojo() As Integer
        Get
            Return intRecojo
        End Get
        Set(ByVal value As Integer)
            intRecojo = value
        End Set
    End Property

    'Public Function getunidadtransporte2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.SP_GET_UNIDADTRANSPORTE", 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function getunidadtransporte() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.SP_GET_UNIDADTRANSPORTE", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_agencia_tree", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_unidadtransporte", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_responsable", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_tipo_unidad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_modelo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_servicio", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_refresca_unidad_movil2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.sp_refresca_unidad_movil", 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function sp_refresca_unidad_movil() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.sp_refresca_unidad_movil", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_unidad_transporte", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function actualizaunitransporte2009() As ADODB.Recordset
    '    'Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.sp_actualiza_unitransporte", 40, _
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.sp_actualiza_unitransporte_I", 42, _
    '                           icontrol, 1, _
    '                           idunitransporte, 1, _
    '                           inrounitransporte, 1, _
    '                           splaca, 2, _
    '                           inro_ejes, 1, _
    '                           iresponsable, 1, _
    '                           icapacidad, 1, _
    '                           idmodelo_unidad, 1, _
    '                           idtipo_unidad_transporte, 1, _
    '                           inro_pisos, 1, _
    '                           inro_televisores, 1, _
    '                           ipeso_vehiculo_toneladas, 3, _
    '                           inro_banios, 1, _
    '                           ipeso_maximo_carga_kg, 3, _
    '                           idrol_usuario, 1, _
    '                           iip, 2, _
    '                           iidusuario_personal, 1, _
    '                           nidestado_registro, 1, _
    '                           scertificadohabilitavehicular, 2, _
    '                           iidtipo_servicio, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    'Public Function actualizaagencia_unidadtransporte2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.sp_actualiza_agenciasasociadas", 20, _
    '                            icontrol, 1, _
    '                            iiadagencia_unidad_transporte, 1, _
    '                            iiadagencia, 1, _
    '                            idunitransporte, 1, _
    '                            iactual, 1, _
    '                            idrol_usuario, 1, _
    '                            iip, 2, _
    '                            iidusuario_personal, 1, _
    '                            nidestado_registro, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function

    Public Function actualizaagencia_unidadtransporte() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.sp_actualiza_agenciasasociadas", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidagencia_unidad_transporte", iiadagencia_unidad_transporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidagencias", iiadagencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidunidad_transporte",idunitransporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("iactual", iactual, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidrol_usuario", idrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iip", iip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidusuario_personal", iidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidestado_registro", nidestado_registro, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_MSG", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_oracle", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function get_unidad_xagencia2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.get_unidad_xagencia", 6, icontrol, 1, iiadagencia, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function

    Public Function sp_getagencias_asociadas() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.sp_get_agencia_asociada", CommandType.StoredProcedure)
            db.AsignarParametro("vidunidadtrans", idunitransporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_agencia_asociada", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function actualizaunitransporte22009() As ADODB.Recordset
    '    'Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.sp_actualiza_unitransporte", 40, _
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.sp_actualiza_unitransporte_II", 44, _
    '                           icontrol, 1, _
    '                           idunitransporte, 1, _
    '                           inrounitransporte, 1, _
    '                           splaca, 2, _
    '                           inro_ejes, 1, _
    '                           iresponsable, 1, _
    '                           icapacidad, 1, _
    '                           idmodelo_unidad, 1, _
    '                           idtipo_unidad_transporte, 1, _
    '                           inro_pisos, 1, _
    '                           inro_televisores, 1, _
    '                           ipeso_vehiculo_toneladas, 3, _
    '                           inro_banios, 1, _
    '                           ipeso_maximo_carga_kg, 3, _
    '                           idrol_usuario, 1, _
    '                           iip, 2, _
    '                           iidusuario_personal, 1, _
    '                           nidestado_registro, 1, _
    '                           scertificadohabilitavehicular, 2, _
    '                           iidtipo_servicio, 1, _
    '                           iSimulado, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function actualizaunitransporte2() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.sp_actualiza_unitransporte_II", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidunidad_transporte", idunitransporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("ninro_unidad_transporte", inrounitransporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("viplaca", splaca, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ninro_ejes", inro_ejes, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidresponsable", iresponsable, OracleClient.OracleType.Int32)
            db.AsignarParametro("nicapacidad", icapacidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidmodelo_unidad", idmodelo_unidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidtipo_unidad_transporte", idtipo_unidad_transporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("ninro_pisos", inro_pisos, OracleClient.OracleType.Int32)
            db.AsignarParametro("ninro_televisores", inro_televisores, OracleClient.OracleType.Int32)
            db.AsignarParametro("nipeso_vehiculo_toneladas", ipeso_vehiculo_toneladas, OracleClient.OracleType.Number)
            db.AsignarParametro("ninro_banios", inro_banios, OracleClient.OracleType.Int32)
            db.AsignarParametro("nipeso_maximo_carga_kg", ipeso_maximo_carga_kg, OracleClient.OracleType.Number)
            db.AsignarParametro("nidrol_usuario", idrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("nip", iip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidusurio_personal", iidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidestado_registro", nidestado_registro, OracleClient.OracleType.Int32)
            '
            db.AsignarParametro("vcerthabveh", scertificadohabilitavehicular, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("nidtipo_servicio", iidtipo_servicio, OracleClient.OracleType.Int32)
            db.AsignarParametro("nisimulado", iSimulado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_recojo", Recojo, OracleClient.OracleType.Int32)

            db.AsignarParametro("ocur_MSG", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
