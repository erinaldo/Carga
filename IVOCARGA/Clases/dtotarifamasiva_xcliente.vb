Imports AccesoDatos
Public Class dtotarifamasiva_xcliente
#Region "Variables"
    Private ll_control As Long
    Private ls_idpersona As String
    Private ls_idcuenta_subcliente As String
    Private ll_idcentro_costo As Long
    Private ll_idunidad_agencia As Long
    Private ll_idunidad_agencia_destino As Long
    Private ldb_precio_x_peso As Double
    Private ldb_precio_x_volumen As Double
    Private ldb_precio_x_sobre As Double
    Private ldb_monto_base As Double
    Private ll_es_vigente As Long
    Private ll_idtipo_moneda As Long
    Private ls_ip As String
    Private ll_idusuario_personal As Long
    Private ll_idestado_registro As Long
    Private ls_fecha_activacion As String
    Private ls_fecha_desactivacion As String
    Private ll_rol_usuario As Long
    Private ls_idtarifa_cliente As String
    Private ls_tipo_calculo As String

#End Region
#Region "Propiedades"
    Public Property tipo_calculo() As String
        Get
            Return ls_tipo_calculo
        End Get
        Set(ByVal value As String)
            ls_tipo_calculo = value
        End Set
    End Property
    Public Property idtarifa_cliente() As String
        Get
            Return ls_idtarifa_cliente
        End Get
        Set(ByVal value As String)
            ls_idtarifa_cliente = value
        End Set
    End Property

    Public Property rol_usuario() As Long
        Get
            Return ll_rol_usuario
        End Get
        Set(ByVal value As Long)
            ll_rol_usuario = value
        End Set
    End Property
    Public Property fecha_desactivacion() As String
        Get
            Return ls_fecha_desactivacion
        End Get
        Set(ByVal value As String)
            ls_fecha_desactivacion = value
        End Set
    End Property
    Public Property fecha_activacion() As String
        Get
            Return ls_fecha_activacion
        End Get
        Set(ByVal value As String)
            ls_fecha_activacion = value
        End Set
    End Property
    Public Property idestado_registro() As Long
        Get
            Return ll_idestado_registro
        End Get
        Set(ByVal value As Long)
            ll_idestado_registro = value
        End Set
    End Property
    Public Property idusuario_personal() As Long
        Get
            Return ll_idusuario_personal
        End Get
        Set(ByVal value As Long)
            ll_idusuario_personal = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return ls_ip
        End Get
        Set(ByVal value As String)
            ls_ip = value
        End Set
    End Property
    Public Property tipo_moneda() As Long
        Get
            Return ll_idtipo_moneda
        End Get
        Set(ByVal value As Long)
            ll_idtipo_moneda = value
        End Set
    End Property
    Public Property es_vigente() As Long
        Get
            Return ll_es_vigente
        End Get
        Set(ByVal value As Long)
            ll_es_vigente = value
        End Set
    End Property
    Public Property monto_base() As Double
        Get
            Return ldb_monto_base
        End Get
        Set(ByVal value As Double)
            ldb_monto_base = value
        End Set
    End Property
    Public Property precio_x_sobre() As Double
        Get
            Return ldb_precio_x_sobre
        End Get
        Set(ByVal value As Double)
            ldb_precio_x_sobre = value
        End Set
    End Property
    Public Property precio_x_volumen() As Double
        Get
            Return ldb_precio_x_volumen
        End Get
        Set(ByVal value As Double)
            ldb_precio_x_volumen = value
        End Set
    End Property
    Public Property precio_x_peso() As Double
        Get
            Return ldb_precio_x_peso
        End Get
        Set(ByVal value As Double)
            ldb_precio_x_peso = value
        End Set
    End Property

    Public Property idunidad_agencia_destino() As Long
        Get
            Return ll_idunidad_agencia_destino
        End Get
        Set(ByVal value As Long)
            ll_idunidad_agencia_destino = value
        End Set
    End Property
    Public Property idunidad_agencia() As Long
        Get
            Return ll_idunidad_agencia
        End Get
        Set(ByVal value As Long)
            ll_idunidad_agencia = value
        End Set
    End Property

    Public Property idcentro_costo() As Long
        Get
            Return ll_idcentro_costo
        End Get
        Set(ByVal value As Long)
            ll_idcentro_costo = value
        End Set
    End Property
    Public Property control() As Long
        Get
            Return ll_control
        End Get
        Set(ByVal value As Long)
            ll_control = value
        End Set
    End Property
    Public Property idpersona() As String
        Get
            Return ls_idpersona
        End Get
        Set(ByVal value As String)
            ls_idpersona = value
        End Set
    End Property
    Public Property idcuenta_subcliente() As String
        Get
            Return ls_idcuenta_subcliente
        End Get
        Set(ByVal value As String)
            ls_idcuenta_subcliente = value
        End Set
    End Property
#End Region
#Region "Procedimientos y Funciones"
    'Public Function lista_masiva_tarifa_2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.sp_get_lista_masiva_tarifa", 8, _
    '                                                                ll_control, 1, _
    '                                                                ls_idpersona, 2, _
    '                                                                ls_idcuenta_subcliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function
    Public Function lista_masiva_tarifa() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOPERSONA.sp_get_lista_masiva_tarifa", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_control", ll_control, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idpersona", ls_idpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idcuenta_subcliente", ls_idcuenta_subcliente, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_centro_costo", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_Agencia", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_ruta_para_tarifa", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function lista_masiva_subcta_tarifa_2009() As ADODB.Recordset
    '    '
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.sp_lista_masiva_ruta_subcta", 6, _
    '                                                                ls_idpersona, 2, _
    '                                                                ls_idcuenta_subcliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function
    Public Function lista_masiva_subcta_tarifa() As DataTable
        '
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOPERSONA.sp_lista_masiva_ruta_subcta", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idpersona", ls_idpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_centro_costo", ls_idpersona, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_ruta_tarifa", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function graba_tarifa_masiva_sub_cta_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_INSUPD_TARIFA_SUB_CUENTA", 40, _
    '                                                                ll_control, 1, _
    '                                                                ls_idcuenta_subcliente, 2, _
    '                                                                ls_idpersona, 2, _
    '                                                                ll_idcentro_costo, 1, _
    '                                                                ls_tipo_calculo, 2, _
    '                                                                ll_idunidad_agencia, 1, _
    '                                                                ll_idunidad_agencia_destino, 1, _
    '                                                                ldb_precio_x_peso, 3, _
    '                                                                ldb_precio_x_volumen, 3, _
    '                                                                ldb_precio_x_sobre, 3, _
    '                                                                ldb_monto_base, 3, _
    '                                                                ll_es_vigente, 1, _
    '                                                                ll_idtipo_moneda, 1, _
    '                                                                ls_ip, 2, _
    '                                                                ll_idusuario_personal, 1, _
    '                                                                ll_idestado_registro, 1, _
    '                                                                ls_fecha_activacion, 2, _
    '                                                                ls_fecha_desactivacion, 2, _
    '                                                                ll_rol_usuario, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function graba_tarifa_masiva_sub_cta() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOPERSONA.SP_INSUPD_TARIFA_SUB_CUENTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iControl", ll_control, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTARIFA_SUB_CUENTA", ls_idcuenta_subcliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPERSONA", ls_idpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCENTRO_COSTO", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_tipo_calculo", ls_tipo_calculo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_AGENCIA", ll_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_AGENCIA_DESTINO", ll_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", ldb_precio_x_peso, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", ldb_precio_x_volumen, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", ldb_precio_x_sobre, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", ldb_monto_base, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ES_VIGENTE", ll_es_vigente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", ll_idtipo_moneda, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", ls_ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDESTADO_REGISTRO", ll_idestado_registro, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_FECHA_ACTIVACION", ls_fecha_activacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_DESACTIVACION", ls_fecha_desactivacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", ll_rol_usuario, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function graba_tarifa_masiva_cliente_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.sp_act_tarifa_cliente", 40, _
    '                                                                ll_control, 1, _
    '                                                                ls_idpersona, 2, _
    '                                                                ls_idtarifa_cliente, 2, _
    '                                                                ls_tipo_calculo, 2, _
    '                                                                ll_idunidad_agencia, 1, _
    '                                                                ll_idunidad_agencia_destino, 1, _
    '                                                                ldb_monto_base, 3, _
    '                                                                ldb_precio_x_peso, 3, _
    '                                                                ldb_precio_x_volumen, 3, _
    '                                                                ldb_precio_x_sobre, 3, _
    '                                                                ll_idtipo_moneda, 1, _
    '                                                                ls_fecha_activacion, 2, _
    '                                                                ls_fecha_desactivacion, 2, _
    '                                                                ll_es_vigente, 1, _
    '                                                                ll_idestado_registro, 1, _
    '                                                                ll_idusuario_personal, 1, _
    '                                                                ll_rol_usuario, 1, _
    '                                                                ls_ip, 2, _
    '                                                                ll_idcentro_costo, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function
    Public Function graba_tarifa_masiva_cliente() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '           
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOPERSONA.sp_act_tarifa_cliente", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_CONTROL", ll_control, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idpersona", ls_idpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idtarifa_cliente", ls_idtarifa_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_tipo_calculo", ls_tipo_calculo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", ll_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", ll_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCG_MONTO_BASE", ldb_monto_base, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_PESO", ldb_precio_x_peso, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_VOLUMEN", ldb_precio_x_volumen, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_SOBRE", ldb_precio_x_sobre, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("ni_idtipo_moneda", ll_idtipo_moneda, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iFECHA_ACTIVACION", ls_fecha_activacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFECHA_DESACTIVACION", ls_fecha_desactivacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iES_VIGENTE", ll_es_vigente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", ll_idestado_registro, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", ll_rol_usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", ls_ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iicentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class

