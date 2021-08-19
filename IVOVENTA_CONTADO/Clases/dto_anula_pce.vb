Imports AccesoDatos
'
Public Class dto_anula_pce
#Region "Variables"
    Private ls_idpersona As String
    Private ls_idfactura As String
    Private ll_idunidad_agencia As Long
    Private ll_idagencia As Long
    Private ll_idunidad_agencia_origen As Long
    Private ll_idagencia_origen As Long
    Private ls_fecha_documento As String
    Private ll_forma_pago As Long
    Private ldb_monto_sub_total As Double
    Private ldb_monto_impuesto As Double
    Private ldb_monto_total As Double
    Private ll_idusuario_personal As Long
    Private ls_ip As String
    Private ll_rol As Long
    Private ll_idtipo_comprobante As Long
    Private ls_obs As String
#End Region
#Region "Property"
    Public Property observacion() As String
        Get
            Return ls_obs
        End Get
        Set(ByVal value As String)
            ls_obs = value
        End Set
    End Property
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
#End Region
#Region "Funciones y Procedimientos"
    '
    'Public Function fn_datos_pce_anular_2009() As ADODB.Recordset
    '    '- 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOVENTACARGA.sp_get_datos_pce_anular", 4, _
    '                                                              ls_idfactura, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '- 
    'End Function
    Public Function fn_datos_pce_anular() As DataTable
        '
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.sp_get_datos_pce_anular", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idfactura", ls_idfactura, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
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
    'Public Function fn_grabar_pce_anular_2009() As ADODB.Recordset
    '    '- 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOVENTACARGA.sp_anula_pce", 12, _
    '                                                                                                                                     ls_idfactura, 2, _
    '                                                                                                                                     ls_obs, 2, _
    '                                                                                                                                     ll_idusuario_personal, 1, _
    '                                                                                                                                     ll_rol, 1, _
    '                                                                                                                                     ls_ip, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '- 
    'End Function
    Public Function fn_grabar_pce_anular() As DataTable
        '-         
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.sp_anula_pce", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idfactura", ls_idfactura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_obs", ls_obs, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_personal", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idrol", ll_rol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ls_ip, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
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