Imports AccesoDatos
Public Class dto_actualiza_contado
#Region "Variables"
    Private ls_idpersona As String
    Private ls_idfactura As String
    Private ll_idunidad_agencia As Long
    Private ll_idagencia As Long
    Private ll_idunidad_agencia_origen As Long
    Private ll_idagencia_origen As Long
    Private ll_proceso As Long
    Private ls_fecha_documento As String
    Private ll_forma_pago As Long
    Private ldb_monto_sub_total As Double
    Private ldb_monto_impuesto As Double
    Private ldb_monto_total As Double
    Private ll_idusuario_personal As Long
    Private ls_ip As String
    Private ll_rol As Long
    Private ll_idtipo_comprobante As Long
#End Region
#Region "Property"
    Public Property idunidad_agencia_origen() As Long
        Get
            Return ll_idunidad_agencia_origen
        End Get
        Set(ByVal value As Long)
            ll_idunidad_agencia_origen = value
        End Set
    End Property
    Public Property idagencia_origen() As Long
        Get
            Return ll_idagencia_origen
        End Get
        Set(ByVal value As Long)
            ll_idagencia_origen = value
        End Set
    End Property

    Public Property idtipo_comprobante() As Long
        Get
            Return ll_idtipo_comprobante
        End Get
        Set(ByVal value As Long)
            ll_idtipo_comprobante = value
        End Set
    End Property
    Public Property rol() As Long
        Get
            Return ll_rol
        End Get
        Set(ByVal value As Long)
            ll_rol = value
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
    Public Property idusuario_personal() As Long
        Get
            Return ll_idusuario_personal
        End Get
        Set(ByVal value As Long)
            ll_idusuario_personal = value
        End Set
    End Property
    Public Property monto_total() As Double
        Get
            Return ldb_monto_total
        End Get
        Set(ByVal value As Double)
            ldb_monto_total = value
        End Set
    End Property
    Public Property monto_impuesto() As Double
        Get
            Return ldb_monto_impuesto
        End Get
        Set(ByVal value As Double)
            ldb_monto_impuesto = value
        End Set
    End Property
    Public Property monto_sub_total() As Double
        Get
            Return ldb_monto_sub_total
        End Get
        Set(ByVal value As Double)
            ldb_monto_sub_total = value
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
    Public Property idfactura() As String
        Get
            Return ls_idfactura
        End Get
        Set(ByVal value As String)
            ls_idfactura = value
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
    Public Property idagencia() As Long
        Get
            Return ll_idagencia
        End Get
        Set(ByVal value As Long)
            ll_idagencia = value
        End Set
    End Property
    Public Property fecha_documento() As String
        Get
            Return ls_fecha_documento
        End Get
        Set(ByVal value As String)
            ls_fecha_documento = value
        End Set
    End Property
    Public Property forma_pago() As Long
        Get
            Return ll_forma_pago
        End Get
        Set(ByVal value As Long)
            ll_forma_pago = value
        End Set
    End Property

    Public Property proceso() As Long
        Get
            Return ll_proceso
        End Get
        Set(ByVal value As Long)
            ll_proceso = value
        End Set
    End Property
#End Region
#Region "Funciones y Procedimientos"
    'Public Function fn_datos_cliente_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOVENTACARGA.sp_lista_for_act_dcto", 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_datos_cliente() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.sp_lista_for_act_dcto", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'No datos
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_forma_pago", OracleClient.OracleType.Cursor)
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
    'Public Function fn_actualiza_clientes_2009() As ADODB.Recordset
    '    '- 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOVENTACARGA.sp_actualiza_dcto", 30, _
    '                                                     ls_idfactura, 2, _
    '                                                     ll_idtipo_comprobante, 1, _
    '                                                     ll_idunidad_agencia, 1, _
    '                                                     ll_idagencia, 1, _
    '                                                     ls_fecha_documento, 2, _
    '                                                     ll_forma_pago, 1, _
    '                                                     ldb_monto_sub_total, 3, _
    '                                                     ldb_monto_impuesto, 3, _
    '                                                     ldb_monto_total, 3, _
    '                                                     ll_idusuario_personal, 1, _
    '                                                     ls_ip, 2, _
    '                                                     ll_rol, 1, _
    '                                                     ll_idunidad_agencia_origen, 1, _
    '                                                     ll_idagencia_origen, 1}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '- 
    'End Function
    Public Function fn_actualiza_clientes() As DataTable
        '- 
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 15-08-2010
            'db_bd.CrearComando("PKG_IVOVENTACARGA.sp_actualiza_dcto", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOVENTACARGA.sp_actualiza_dcto_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idfactura", ls_idfactura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_comprobante", ll_idtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia", ll_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencias", ll_idagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_documento", ls_fecha_documento, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_forma_pago", ll_forma_pago, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_monto_sub_total", ldb_monto_sub_total, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("ni_monto_impuesto", ldb_monto_impuesto, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("ni_monto_total", ldb_monto_total, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("ni_idusuario_personal", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ls_ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_rol", ll_rol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_age_origen", ll_idunidad_agencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_origen", ll_idagencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_proceso", ll_proceso, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
