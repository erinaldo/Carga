Imports AccesoDatos
Public Class dtorecepcion_quitar_bultos
#Region "variables"
    Dim ls_guia_transportista As String
    Dim ls_idguia_transp_detall As String
    Dim ll_idtipo_comprobante As Long
    Dim ls_idcomprobante As String
    Dim ll_cantidad As Long
    Dim ll_idusuario_personal As Long
    Dim ls_ip As String
    Dim ll_idagencia_recepcion As Long
    Dim ll_idunidad_agencia_destino As Long
    Dim ll_nro_unidad_transporte As Long
    Dim ll_idusuario_piloto As Long
    Dim ls_nro_dcto As String
    Dim ll_idagencia_ori_dcto As Long
    Dim ll_idagencia_des_dcto As Long
    Dim ll_idagencia_origen_gt As Long
    Dim ll_idunidad_age_recep As Long
    Dim ls_codigo_barra As String
#End Region
#Region "Property"
    Public Property codigo_barra() As String
        Get
            Return ls_codigo_barra
        End Get
        Set(ByVal value As String)
            ls_codigo_barra = value
        End Set
    End Property
    Public Property idunidad_age_recep() As Long
        Get
            Return ll_idunidad_age_recep
        End Get
        Set(ByVal value As Long)
            ll_idunidad_age_recep = value
        End Set
    End Property
    Public Property idagencia_origen_gt() As Long
        Get
            Return ll_idagencia_origen_gt
        End Get
        Set(ByVal value As Long)
            ll_idagencia_origen_gt = value
        End Set
    End Property
    Public Property idagencia_des_dcto() As Long
        Get
            Return ll_idagencia_des_dcto
        End Get
        Set(ByVal value As Long)
            ll_idagencia_des_dcto = value
        End Set
    End Property
    Public Property idagencia_ori_dcto() As Long
        Get
            Return ll_idagencia_ori_dcto
        End Get
        Set(ByVal value As Long)
            ll_idagencia_ori_dcto = value
        End Set
    End Property
    Public Property nro_dcto() As String
        Get
            Return ls_nro_dcto
        End Get
        Set(ByVal value As String)
            ls_nro_dcto = value
        End Set
    End Property
    Public Property idusuario_piloto() As Long
        Get
            Return ll_idusuario_piloto
        End Get
        Set(ByVal value As Long)
            ll_idusuario_piloto = value
        End Set
    End Property
    Public Property nro_unidad_transporte() As Long
        Get
            Return ll_nro_unidad_transporte
        End Get
        Set(ByVal value As Long)
            ll_nro_unidad_transporte = value
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
    Public Property idagencia_recepcion() As Long
        Get
            Return ll_idagencia_recepcion
        End Get
        Set(ByVal value As Long)
            ll_idagencia_recepcion = value
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
    Public Property cantidad() As Long
        Get
            Return ll_cantidad
        End Get
        Set(ByVal value As Long)
            ll_cantidad = value
        End Set
    End Property
    Public Property idcomprobante() As String
        Get
            Return ls_idcomprobante
        End Get
        Set(ByVal value As String)
            ls_idcomprobante = value
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
    Public Property idguia_transp_detall() As String
        Get
            Return ls_idguia_transp_detall
        End Get
        Set(ByVal value As String)
            ls_idguia_transp_detall = value
        End Set
    End Property
    Public Property guia_transportista() As String
        Get
            Return ls_guia_transportista
        End Get
        Set(ByVal value As String)
            ls_guia_transportista = value
        End Set
    End Property

    Private intTipoComprobante As Integer
    Public Property TipoComprobante() As Integer
        Get
            Return intTipoComprobante
        End Get
        Set(ByVal value As Integer)
            intTipoComprobante = value
        End Set
    End Property

#End Region
#Region "Procedimientos y Funciones"
    'Public Function fn_guia_transportista_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVODESPACHO_RECEPCION.sp_get_guia_transportista", 4, _
    '                                                        ls_guia_transportista, 2}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function fn_guia_transportista() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.sp_get_guia_transportista", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_guia_transportista", ls_guia_transportista, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_guia_transportista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_gt_detalle", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_actualiza_guia_transportista_det_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVODESPACHO_RECEPCION.sp_actualiza_guia_transp_det", 30, _
    '                                                               ls_idguia_transp_detall, 2, _
    '                                                               ls_guia_transportista, 2, _
    '                                                               ll_idtipo_comprobante, 1, _
    '                                                               ls_idcomprobante, 2, _
    '                                                               ll_cantidad, 1, _
    '                                                               ll_idusuario_personal, 1, _
    '                                                               ls_ip, 2, _
    '                                                               ll_idagencia_recepcion, 1, _
    '                                                               ll_idunidad_agencia_destino, 1, _
    '                                                               ll_nro_unidad_transporte, 1, _
    '                                                               ll_idusuario_piloto, 1, _
    '                                                               ls_nro_dcto, 2, _
    '                                                               ll_idagencia_origen_gt, 1, _
    '                                                               ll_idunidad_age_recep, 1}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function fn_actualiza_guia_transportista_det() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.sp_actualiza_guia_transp_det", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idguia_transp_detall", ls_idguia_transp_detall, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idguia_transportista", ls_guia_transportista, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_comprobante", ll_idtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idcomprobante", ls_idcomprobante, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_cantidad", ll_cantidad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idusuario_personal", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ls_ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_recepcion", ll_idagencia_recepcion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_destino", ll_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_nro_unidad_transporte", ll_nro_unidad_transporte, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idusuario_piloto", ll_idusuario_piloto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_nro_documento", ls_nro_dcto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_ori_gt", ll_idagencia_origen_gt, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_age_recep", ll_idunidad_age_recep, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_guia_trans_det", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_actualiza_gt_det_xcodigo_barra_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVODESPACHO_RECEPCION.sp_act_gt_det_xcod_barra", 30, _
    '                                                               ls_idguia_transp_detall, 2, _
    '                                                               ls_guia_transportista, 2, _
    '                                                               ll_idtipo_comprobante, 1, _
    '                                                               ls_idcomprobante, 2, _
    '                                                               ls_codigo_barra, 2, _
    '                                                               ll_idusuario_personal, 1, _
    '                                                               ls_ip, 2, _
    '                                                               ll_idagencia_recepcion, 1, _
    '                                                               ll_idunidad_agencia_destino, 1, _
    '                                                               ll_nro_unidad_transporte, 1, _
    '                                                               ll_idusuario_piloto, 1, _
    '                                                               ls_nro_dcto, 2, _
    '                                                               ll_idagencia_origen_gt, 1, _
    '                                                               ll_idunidad_age_recep, 1}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function fn_actualiza_gt_det_xcodigo_barra() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.sp_act_gt_det_xcod_barra", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idguia_transp_detall", ls_idguia_transp_detall, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idguia_transportista", ls_guia_transportista, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_comprobante", ll_idtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idcomprobante", ls_idcomprobante, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_codigo_barra", ls_codigo_barra, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_personal", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ls_ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_recepcion", ll_idagencia_recepcion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia_destino", ll_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_nro_unidad_transporte", ll_nro_unidad_transporte, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idusuario_piloto", ll_idusuario_piloto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_nro_documento", ls_nro_dcto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_ori_gt", ll_idagencia_origen_gt, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_age_recep", ll_idunidad_age_recep, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_guia_trans_det", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_recupera_gt_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVODESPACHO_RECEPCION.sp_get_dcto_x_gt", 4, _
    '                                                      ls_nro_dcto, 2}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function fn_recupera_gt() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.sp_get_dcto_x_gt", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_documento", ls_nro_dcto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_tipo", TipoComprobante, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_guia_transportista", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class