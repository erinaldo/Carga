Imports AccesoDatos
Class dtosalidavehiculo
#Region "Variables privadas"
    Private m_idunidad_agencia_origen As Long
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
    Private m_margen As String
    Private m_kilometros As Double
    Private m_simulado As Integer
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
    Public Property idnro_salida() As Long
        Get
            Return m_lidnro_salida
        End Get
        Set(ByVal value As Long)
            m_lidnro_salida = value
        End Set
    End Property
    Public Property idunidad_agencia_origen() As Long
        Get
            Return m_idunidad_agencia_origen
        End Get
        Set(ByVal value As Long)
            m_idunidad_agencia_origen = value
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
    '25/04/2009
    Public Property idrol_usuario() As Long
        Get
            Return m_lidrol_usuario
        End Get
        Set(ByVal value As Long)
            m_lidrol_usuario = value
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
    Public Property margen() As String
        Get
            Return m_margen
        End Get
        Set(ByVal value As String)
            m_margen = value
        End Set
    End Property

    Public Property kilometros() As Double
        Get
            Return m_kilometros
        End Get
        Set(ByVal value As Double)
            m_kilometros = value
        End Set
    End Property

    Public Property simulado() As Integer
        Get
            Return m_simulado
        End Get
        Set(ByVal value As Integer)
            m_simulado = value
        End Set
    End Property
#End Region
#Region "Variables publicas"
    Public dtOrigen As New DataTable
    Public dtRuta As New DataTable
    Public dtBus As New DataTable
    Public dtTipoServicio As DataTable
    Public dtEstado As DataTable
    Public dtUsuarioPersonal As DataTable
    Public dtSalidaVehiculo As DataTable

    'Cuando Graba la hora de Salida
    Public dt_cur_graba As DataTable
    Public dt_cur_actualiza_estado As DataTable
    Public dt_cur_recupera_ciudad_destino As DataTable
    Public dt_cur_datos As New DataTable
    Public dt_cur_kilometros As New DataTable
    Public dt_cur_kilometros2 As New DataTable

#End Region
#Region "Funciones"
    'Public Function fnLoad_salida_vehiculo_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_lista_salida_vehiculo", 6, _
    '                                                m_idunidad_agencia_origen, 1, _
    '                                                m_sfecha, 2}
    '        cur_origen = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        cur_tipo_servicio = cur_origen.NextRecordset
    '        cur_ruta = cur_origen.NextRecordset
    '        cur_bus = cur_origen.NextRecordset
    '        cur_usuario_personal = cur_origen.NextRecordset
    '        cur_estado = cur_origen.NextRecordset
    '        cur_salida_vehiculo = cur_origen.NextRecordset
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLoad_salida_vehiculo() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet

            db_bd.Conectar()

            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_lista_salida_vehiculo", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iidagencia_origen", m_idunidad_agencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifecha_actual", m_sfecha, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ocur_origen", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_tipo_servicio", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_ruta", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_bus", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_usuario_personal", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_estado", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_salida_vehiculo", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()

            lds_tmp = db_bd.EjecutarDataSet

            dtOrigen = lds_tmp.Tables(0)
            dtTipoServicio = lds_tmp.Tables(1)
            dtRuta = lds_tmp.Tables(2)
            dtBus = lds_tmp.Tables(3)
            dtUsuarioPersonal = lds_tmp.Tables(4)
            dtEstado = lds_tmp.Tables(5)
            dtSalidaVehiculo = lds_tmp.Tables(6)

            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnLoad_graba_salida_vehiculo_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Dim ls_idnro_salida As String
    '    Dim ls_idruta_horario As String

    '    Try
    '        cur_recupera_ciudad_destino = Nothing
    '        cur_recupera_ciudad_destino = New ADODB.Recordset
    '        ' Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_actualiza_salida_veh", 42, _
    '        '26/03/2008 - m_lidnro_salida, 1, _
    '        '                        m_lidruta_horario, 1, _ 
    '        If m_lidnro_salida = -666 Then
    '            ls_idnro_salida = "null"
    '        Else
    '            ls_idnro_salida = CType(m_lidnro_salida, String)

    '        End If
    '        If m_lidruta_horario = -666 Then
    '            ls_idruta_horario = "null"
    '        Else
    '            ls_idruta_horario = CType(m_lidruta_horario, String)
    '        End If
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_actualiza_salida_veh3", 46, _
    '                                                    m_lcontrol, 1, _
    '                                                    ls_idnro_salida, 2, _
    '                                                    ls_idruta_horario, 2, _
    '                                                    m_lidunidad_transporte, 1, _
    '                                                    m_sfecha_salida, 2, _
    '                                                    m_shora_salida, 2, _
    '                                                    m_ltipo_servicio, 1, _
    '                                                    m_liduni_agencia_origen, 1, _
    '                                                    m_liduni_agencia_destino, 1, _
    '                                                    m_liusuario_chofer, 1, _
    '                                                    m_snom_tercero, 2, _
    '                                                    m_sruc, 2, _
    '                                                    m_snro_licencia, 2, _
    '                                                    m_smarca_bus, 2, _
    '                                                    m_splaca_bus, 2, _
    '                                                    m_lestado, 1, _
    '                                                    m_sfecha_llegada, 2, _
    '                                                    m_sip, 2, _
    '                                                    m_lidusuario_personal, 1, _
    '                                                    m_lidrol_usuario, 1, _
    '                                                    m_margen, 2, _
    '                                                    m_kilometros, 3}
    '        cur_graba = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        cur_recupera_ciudad_destino = cur_graba.NextRecordset
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLoad_graba_salida_vehiculo() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_cur_graba = Nothing
            dt_cur_graba = New DataTable
            '
            dt_cur_recupera_ciudad_destino = Nothing
            dt_cur_recupera_ciudad_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_actualiza_salida_veh3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("icontrol", m_lcontrol, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidruta_horario", m_lidruta_horario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidunidad_transporte", m_lidunidad_transporte, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifecha_salida", m_sfecha_salida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ihora_salida", m_shora_salida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_servicio", m_ltipo_servicio, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidagencia_origen", m_liduni_agencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidagencia_destino", m_liduni_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iusuario_chofer", m_liusuario_chofer, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("inom_tercero", m_snom_tercero, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iruc_tercero", m_sruc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("inro_licencia", m_snro_licencia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("imarca_bus", m_smarca_bus, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iplaca_bus", m_splaca_bus, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iestado", m_lestado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifecha_llegada", m_sfecha_llegada, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iip", m_sip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidusuario_personal", m_lidusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidrol_usuario", m_lidrol_usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("margen", m_margen, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ikilometros", m_kilometros, OracleClient.OracleType.Double)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_ciudad", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            dt_cur_graba = lds_tmp.Tables(0)
            dt_cur_recupera_ciudad_destino = lds_tmp.Tables(1)
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnrecupera_salida_vehiculo_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_recupera_salida_vehiculo", 6, _
    '                                                    m_liduni_agencia_origen, 1, _
    '                                                    m_sfecha_salida, 2}
    '        cur_salida_vehiculo = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function fnrecupera_salida_vehiculo() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet

            dtRuta = Nothing
            dtRuta = New DataTable

            dtSalidaVehiculo = Nothing
            dtSalidaVehiculo = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_recupera_salida_vehiculo_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidagencia_origen", m_liduni_agencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("dfecha", m_sfecha_salida, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_salida_vehiculo", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_ruta", OracleClient.OracleType.Cursor)

            'Desconectar 
            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet

            dtSalidaVehiculo = lds_tmp.Tables(0)
            dtRuta = lds_tmp.Tables(1)

            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnactualiza_estado_salida_vehiculo_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        'Salida --> m_lidnro_salida, 1, _
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_actualiza_eesalidavehiculo", 6, _
    '                                                                CType(m_lidnro_salida, String), 2, _
    '                                                                m_lestado, 1}
    '        cur_actualiza_estado = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnactualiza_estado_salida_vehiculo(usuario As Integer, ip As String) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_actualiza_estado = Nothing
            dt_cur_actualiza_estado = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_actualiza_eesalidavehiculo", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidestado", m_lestado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_cur_actualiza_estado = db_bd.EjecutarDataTable
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnget_ciudad_destino_vacio_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_destino_vacio", 2}
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function    

    'Public Function fnget_ciudad_destino_2_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        ' 26/03/2008 - m_lidnro_salida, 1
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_destino_2", 6, _
    '                                                              CType(m_lidnro_salida, String), 2, _
    '                                                              m_idunidad_agencia_origen, 1}
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnget_ciudad_destino_2() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_recupera_ciudad_destino = Nothing
            dt_cur_recupera_ciudad_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_destino_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iiorigen", m_idunidad_agencia_origen, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad_destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_cur_recupera_ciudad_destino = db_bd.EjecutarDataTable
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fninserta_ciudad_destino_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        '26/03/2008  - m_lidnro_salida , 1 
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_inserta_ciudad", 6, _
    '                                                              CType(m_lidnro_salida, String), 2, _
    '                                        m_liduni_agencia_destino, 1}  ' Debe pasar como long 
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnelimina_ciudad_destino_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        '26/03/2008  m_lidnro_salida , 1 
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad", 6, _
    '                                        CType(m_lidnro_salida, String), 2, _
    '                                        m_liduni_agencia_destino, 1}  ' Debe pasar como long 
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fn_verifica_salida_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_datos = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_verifica_nro_salida", 6, _
    '                                                             CType(m_lidnro_salida, String), 2, _
    '                                                             m_sfecha_salida, 2}
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fn_verifica_salida() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_datos = Nothing
            dt_cur_datos = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_verifica_nro_salida", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idnro_salida", CType(m_lidnro_salida, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_sistema", m_sfecha_salida, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_cur_datos = db_bd.EjecutarDataTable
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fninserta_ciudad_destino_2_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        '26/03/2008  - m_lidnro_salida , 1 
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_inserta_ciudad_2", 8, _
    '                                        CType(m_lidnro_salida, String), 2, _
    '                                        m_liduni_agencia_destino, 1, _
    '                                        m_liduni_agencia_origen, 1}  ' Debe pasar como long 
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fninserta_ciudad_destino_2() As Boolean
        Dim flag As Boolean = False
        '
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_recupera_ciudad_destino = Nothing
            dt_cur_recupera_ciudad_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_inserta_ciudad_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidunidad_agencia", m_liduni_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iiorigen", m_liduni_agencia_origen, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad_destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_cur_recupera_ciudad_destino = db_bd.EjecutarDataTable
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnget_ciudad_destino_vacio_2_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_destino_vacio_2", 2}
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnget_ciudad_destino_vacio_2() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_recupera_ciudad_destino = Nothing
            dt_cur_recupera_ciudad_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_destino_vacio_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad_destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_cur_recupera_ciudad_destino = db_bd.EjecutarDataTable
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnget_kilometros_2009(ByVal m_cadena As String) As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_kilometros = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_get_kilometros", 4, _
    '                                                             m_cadena, 2}
    '        cur_kilometros = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnget_kilometros(ByVal m_cadena As String) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_kilometros = Nothing
            dt_cur_kilometros = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_get_kilometros", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("scadena", m_cadena, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_kilometros", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_cur_kilometros = db_bd.EjecutarDataTable
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnelimina_ciudad_destino_2_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        '26/03/2008  m_lidnro_salida , 1 
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_2", 8, _
    '                                        CType(m_lidnro_salida, String), 2, _
    '                                        m_liduni_agencia_destino, 1, _
    '                                        m_idunidad_agencia_origen, 1}  ' Debe pasar como long 
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnelimina_ciudad_destino_2() As Boolean
        Dim flag As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_recupera_ciudad_destino = Nothing
            dt_cur_recupera_ciudad_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidunidad_agencia", m_liduni_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iiorigen", m_idunidad_agencia_origen, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad_destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            dt_cur_recupera_ciudad_destino = db_bd.EjecutarDataTable
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnelimina_ciudad_3_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        '26/03/2008  m_lidnro_salida , 1 
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_3", 8, _
    '                                        CType(m_lidnro_salida, String), 2, _
    '                                        m_idunidad_agencia_origen, 1, _
    '                                        m_liduni_agencia_destino, 1}
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnelimina_ciudad_3() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_recupera_ciudad_destino = Nothing
            dt_cur_recupera_ciudad_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_3", CommandType.StoredProcedure)

            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iiorigen", m_idunidad_agencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidestino", m_liduni_agencia_destino, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad_destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            dt_cur_recupera_ciudad_destino = db_bd.EjecutarDataTable
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnelimina_ciudad_4_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        '26/03/2008  m_lidnro_salida , 1 
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_4", 8, _
    '                                        CType(m_lidnro_salida, String), 2, _
    '                                        m_idunidad_agencia_origen, 1, _
    '                                        m_liduni_agencia_destino, 1}
    '        cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnelimina_ciudad_4() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_recupera_ciudad_destino = Nothing
            dt_cur_recupera_ciudad_destino = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_4", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("iidnro_salida", m_lidnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iiorigen", m_idunidad_agencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidestino", m_liduni_agencia_destino, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ciudad_destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            dt_cur_recupera_ciudad_destino = db_bd.EjecutarDataTable
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnActualiza_Destino_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        'cur_salida_vehiculo = Nothing
    '        ' 26/03/2008 - m_lidnro_salida, 1
    '        If m_lidnro_salida > 0 Then
    '            Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_actualiza_destino", 4, _
    '                                                                  CType(m_lidnro_salida, String), 2}
    '            'm_idunidad_agencia_origen, 1}
    '            'cur_recupera_ciudad_destino = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '            VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnLoad_salida_vehiculo2_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_lista_salida_vehiculo2", 8, _
    '                                                m_idunidad_agencia_origen, 1, _
    '                                                m_sfecha, 2, _
    '                                                m_simulado, 1}
    '        cur_origen = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        cur_tipo_servicio = cur_origen.NextRecordset
    '        cur_ruta = cur_origen.NextRecordset
    '        cur_bus = cur_origen.NextRecordset
    '        cur_usuario_personal = cur_origen.NextRecordset
    '        cur_estado = cur_origen.NextRecordset
    '        cur_salida_vehiculo = cur_origen.NextRecordset
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnrecupera_salida_vehiculo2_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_salida_vehiculo = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_recupera_salida_vehiculo2", 8, _
    '                                                    m_liduni_agencia_origen, 1, _
    '                                                    m_sfecha_salida, 2, _
    '                                                    m_simulado, 1}
    '        cur_salida_vehiculo = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnLoad_graba_salida_vehiculo2_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Dim ls_idnro_salida As String
    '    Dim ls_idruta_horario As String

    '    Try
    '        cur_recupera_ciudad_destino = Nothing
    '        cur_recupera_ciudad_destino = New ADODB.Recordset
    '        ' Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_actualiza_salida_veh", 42, _
    '        '26/03/2008 - m_lidnro_salida, 1, _
    '        '                        m_lidruta_horario, 1, _ 
    '        If m_lidnro_salida = -666 Then
    '            ls_idnro_salida = "null"
    '        Else
    '            ls_idnro_salida = CType(m_lidnro_salida, String)

    '        End If
    '        If m_lidruta_horario = -666 Then
    '            ls_idruta_horario = "null"
    '        Else
    '            ls_idruta_horario = CType(m_lidruta_horario, String)
    '        End If
    '        Dim SQLQuery As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_actualiza_salida_veh4", 48, _
    '                                                    m_lcontrol, 1, _
    '                                                    ls_idnro_salida, 2, _
    '                                                    ls_idruta_horario, 2, _
    '                                                    m_lidunidad_transporte, 1, _
    '                                                    m_sfecha_salida, 2, _
    '                                                    m_shora_salida, 2, _
    '                                                    m_ltipo_servicio, 1, _
    '                                                    m_liduni_agencia_origen, 1, _
    '                                                    m_liduni_agencia_destino, 1, _
    '                                                    m_liusuario_chofer, 1, _
    '                                                    m_snom_tercero, 2, _
    '                                                    m_sruc, 2, _
    '                                                    m_snro_licencia, 2, _
    '                                                    m_smarca_bus, 2, _
    '                                                    m_splaca_bus, 2, _
    '                                                    m_lestado, 1, _
    '                                                    m_sfecha_llegada, 2, _
    '                                                    m_sip, 2, _
    '                                                    m_lidusuario_personal, 1, _
    '                                                    m_lidrol_usuario, 1, _
    '                                                    m_margen, 2, _
    '                                                    m_kilometros, 3, _
    '                                                    m_simulado, 1}
    '        cur_graba = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        cur_recupera_ciudad_destino = cur_graba.NextRecordset
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnKilometros_2009(ByVal origen As Integer, ByVal destino As Integer) As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        cur_kilometros2 = Nothing
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_KILOMETROS", 6, _
    '                                                   origen, 1, _
    '                                                    destino, 1}
    '        cur_kilometros2 = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If cur_kilometros2.BOF = False And cur_kilometros2.EOF = False Then
    '            flag = True
    '        Else
    '            flag = False
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnKilometros(ByVal origen As Integer, ByVal destino As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            '
            dt_cur_kilometros2 = Nothing
            dt_cur_kilometros2 = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGESTION.SP_KILOMETROS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("origen", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("destino", destino, OracleClient.OracleType.Int32)

            'Variables de salidas 
            db_bd.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            dt_cur_kilometros2 = db_bd.EjecutarDataTable
            '
            flag = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function sp_valida_ciudad_asocia_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataTable
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOTRANSPORTE_CARGA.sp_valida_ciudad_asocia"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idnro_salida", OracleClient.OracleType.Number)).Value = idnro_salida
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = iduni_agencia_destino
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_valida_ciudad_asocia", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dt As New DataTable
    '        dt = ds.Tables(0)
    '        '
    '        Return dt
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_valida_ciudad_asocia() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_valida_ciudad_asocia", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("ni_idnro_salida", idnro_salida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia", iduni_agencia_destino, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("co_valida_ciudad_asocia", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class