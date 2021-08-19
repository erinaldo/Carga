Imports AccesoDatos
Class dtosalidamovil
#Region "Variables privadas"
    Private m_idagencia As Long
    Private m_sfecha As String
    'Variables para guardar 
    Private m_lcontrol As Long
    Private m_lidnro_salida As Long
    Private m_lidruta_horario As Long
    Private m_lidunidad_transporte As Long
    Private m_sfecha_salida As String
    Private m_shora_salida As String
    Private m_ltipo_servicio As Long
    Private m_liduni_agencia_origen As Long
    Private m_liduni_agencia_destino As Long
    Private m_liusuario_chofer As Long
    Private m_snom_tercero As String
    Private m_sruc As String
    Private m_snro_licencia As String
    Private m_smarca_bus As String
    Private m_splaca_bus As String
    Private m_lestado As Long
    Private m_sfecha_llegada As String
    Private m_sip As String
    Private m_lidusuario_personal As Long
    Private m_lidrol_usuario As Long
#End Region
#Region "Propiedades"
    Public Property control() As Long
        Get
            Return m_lcontrol
        End Get
        Set(ByVal value As Long)
            m_lcontrol = value
        End Set
    End Property
    Public Property idagencias() As Long
        Get
            Return m_idagencia
        End Get
        Set(ByVal value As Long)
            m_idagencia = value
        End Set
    End Property
    Public Property idnro_salida() As Long
        Get
            Return m_lidnro_salida
        End Get
        Set(ByVal value As Long)
            m_lidnro_salida = value
        End Set
    End Property
    Public Property idunidad_transporte() As Long
        Get
            Return m_lidunidad_transporte
        End Get
        Set(ByVal value As Long)
            m_lidunidad_transporte = value
        End Set
    End Property
    Public Property fecha_salida() As String
        Get
            Return m_sfecha_salida
        End Get
        Set(ByVal value As String)
            m_sfecha_salida = value
        End Set
    End Property
    Public Property hora_salida() As String
        Get
            Return m_shora_salida
        End Get
        Set(ByVal value As String)
            m_shora_salida = value
        End Set
    End Property
    Public Property tipo_servicio() As Long
        Get
            Return m_ltipo_servicio
        End Get
        Set(ByVal value As Long)
            m_ltipo_servicio = value
        End Set
    End Property
    Public Property iduni_agencia_origen() As Long
        Get
            Return m_liduni_agencia_origen
        End Get
        Set(ByVal value As Long)
            m_liduni_agencia_origen = value
        End Set
    End Property
    Public Property iduni_agencia_destino() As Long
        Get
            Return m_liduni_agencia_destino
        End Get
        Set(ByVal value As Long)
            m_liduni_agencia_destino = value
        End Set
    End Property
    Public Property usuario_chofer() As Long
        Get
            Return m_liusuario_chofer
        End Get
        Set(ByVal value As Long)
            m_liusuario_chofer = value
        End Set
    End Property
    Public Property nombre_tercero() As String
        Get
            Return m_snom_tercero
        End Get
        Set(ByVal value As String)
            m_snom_tercero = value
        End Set
    End Property
    Public Property ruc() As String
        Get
            Return m_sruc
        End Get
        Set(ByVal value As String)
            m_sruc = value
        End Set
    End Property
    Public Property nro_licencia() As String
        Get
            Return m_snro_licencia
        End Get
        Set(ByVal value As String)
            m_snro_licencia = value
        End Set
    End Property
    Public Property marca_bus() As String
        Get
            Return m_smarca_bus
        End Get
        Set(ByVal value As String)
            m_smarca_bus = value
        End Set
    End Property
    Public Property placa_bus() As String
        Get
            Return m_splaca_bus
        End Get
        Set(ByVal value As String)
            m_splaca_bus = value
        End Set
    End Property
    Public Property estado() As Long
        Get
            Return m_lestado
        End Get
        Set(ByVal value As Long)
            m_lestado = value
        End Set
    End Property
    Public Property fecha_llegada() As String
        Get
            Return m_sfecha_llegada
        End Get
        Set(ByVal value As String)
            m_sfecha_llegada = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return m_sip
        End Get
        Set(ByVal value As String)
            m_sip = value
        End Set
    End Property
    Public Property idusuario_personal() As Long
        Get
            Return m_lidusuario_personal
        End Get
        Set(ByVal value As Long)
            m_lidusuario_personal = value
        End Set
    End Property
    Public Property idrol_usuario() As Long
        Get
            Return m_lidusuario_personal
        End Get
        Set(ByVal value As Long)
            m_lidusuario_personal = value
        End Set
    End Property
    'Propiedades para el load
    Public Property idrutahorario() As Long
        Get
            Return m_lidruta_horario
        End Get
        Set(ByVal value As Long)
            m_lidruta_horario = value
        End Set
    End Property
    Public Property fecha() As String
        Get
            Return m_sfecha
        End Get
        Set(ByVal value As String)
            m_sfecha = value
        End Set
    End Property
#End Region
#Region "Variables publicas"
    'Cuando levanta el load del formulario  
    'Public cur_agencias As New ADODB.Recordset
    'Public cur_movil As New ADODB.Recordset

    'Public cur_usuario_personal As New ADODB.Recordset
    'Public cur_estado As New ADODB.Recordset
    'Public cur_salida_movil As New ADODB.Recordset
    ''Cuando Graba la hora de Salida
    'Public cur_graba As New ADODB.Recordset
    'Public cur_actualiza_estado As New ADODB.Recordset
    'Public cur_recupera_ciudad_destino As New ADODB.Recordset
    'Public cur_refresca_salida_movil As New ADODB.Recordset
    '
    Public dt_cur_agencias As New DataTable
    Public dt_cur_movil As New DataTable
    Public dt_cur_usuario_personal As New DataTable
    Public dt_cur_estado As New DataTable
    Public dt_cur_salida_movil As New DataTable
    Public dt_cur_graba As New DataTable
    Public dt_cur_actualiza_estado As New DataTable
    Public dt_cur_refresca_salida_movil As New DataTable
    '
#End Region
#Region "Funciones"
    'Public Function fnLoad_salida_movil_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_lista_salida_movil", 6, _
    '                                                m_idagencia, 1, _
    '                                                m_sfecha, 2}
    '        cur_agencias = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        cur_movil = cur_agencias.NextRecordset
    '        cur_usuario_personal = cur_agencias.NextRecordset
    '        cur_estado = cur_agencias.NextRecordset
    '        cur_salida_movil = cur_agencias.NextRecordset
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLoad_salida_movil() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_cur_agencias = Nothing
            dt_cur_agencias = New DataTable
            '
            dt_cur_movil = Nothing
            dt_cur_movil = New DataTable
            '
            dt_cur_usuario_personal = Nothing
            dt_cur_usuario_personal = New DataTable
            ' 
            dt_cur_estado = Nothing
            dt_cur_estado = New DataTable
            '
            dt_cur_salida_movil = Nothing
            dt_cur_salida_movil = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_lista_salida_movil", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidagencia", m_idagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifecha_actual", m_sfecha, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_movil", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_usuario_personal", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_estado", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_salida_movil", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet

            dt_cur_agencias = lds_tmp.Tables(0)
            dt_cur_movil = lds_tmp.Tables(1)
            dt_cur_usuario_personal = lds_tmp.Tables(2)
            dt_cur_estado = lds_tmp.Tables(3)
            dt_cur_salida_movil = lds_tmp.Tables(4)
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnLoad_graba_salida_movil_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_act_salida_movil", 22, _
    '                                                    m_lcontrol, 1, _
    '                                                    m_lidnro_salida, 1, _
    '                                                    m_lidunidad_transporte, 1, _
    '                                                    m_sfecha_salida, 2, _
    '                                                    m_shora_salida, 2, _
    '                                                    m_liusuario_chofer, 1, _
    '                                                    m_idagencia, 1, _
    '                                                    m_lestado, 1, _
    '                                                    m_sip, 2, _
    '                                                    m_lidusuario_personal, 1}
    '        cur_graba = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLoad_graba_salida_movil() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_cur_graba = Nothing
            dt_cur_graba = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_act_salida_movil", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_control", m_lcontrol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_transporte", m_lidunidad_transporte, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_salida", m_sfecha_salida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_hora_salida", m_shora_salida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_usuario_chofer", m_liusuario_chofer, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia", m_idagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_estado", m_lestado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", m_sip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_personal", m_lidusuario_personal, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_cur_graba = ldt_tmp
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnrecupera_salida_movil_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_movil = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_recupera_salida_movil", 6, _
    '                                                    m_idagencia, 1, _
    '                                                    m_sfecha_salida, 2}
    '        cur_salida_movil = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnrecupera_salida_movil() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_cur_salida_movil = Nothing
            dt_cur_salida_movil = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_recupera_salida_movil", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_agencia", m_idagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha", m_sfecha_salida, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_salida_movil", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_cur_salida_movil = ldt_tmp
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnactualiza_estado_salida_movil_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_movil = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_actualiza_eesalidamovil", 6, _
    '                                                    m_lidnro_salida, 1, _
    '                                                    m_lestado, 1}
    '        cur_actualiza_estado = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnactualiza_estado_salida_movil() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_cur_actualiza_estado = Nothing
            dt_cur_actualiza_estado = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_actualiza_eesalidamovil", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidestado", m_lestado, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_cur_actualiza_estado = ldt_tmp
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fn_refresca_movil_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_refresca_salida_movil = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.refresca_salida_movil", 4, _
    '                                                                      m_idagencia, 1}
    '        cur_refresca_salida_movil = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_refresca_movil() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_cur_refresca_salida_movil = Nothing
            dt_cur_refresca_salida_movil = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.refresca_salida_movil", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", m_idagencia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_cur_refresca_salida_movil = ldt_tmp
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function


    'Public Function fnget_ciudad_destino() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_movil = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_destino", 4, _
    '                                        m_lidnro_salida, 1}  ' Debe pasar como long 
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fninserta_ciudad_destino() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_movil = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_inserta_ciudad", 6, _
    '                                        m_lidnro_salida, 1, _
    '                                        m_liduni_agencia_destino, 1}  ' Debe pasar como long 
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnelimina_ciudad_destino() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_movil = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad", 6, _
    '                                        m_lidnro_salida, 1, _
    '                                        m_liduni_agencia_destino, 1}  ' Debe pasar como long 
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
#End Region
End Class