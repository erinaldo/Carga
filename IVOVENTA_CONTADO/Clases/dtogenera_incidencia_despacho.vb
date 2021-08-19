Imports AccesoDatos
Public Class dtogenera_incidencia_despacho
#Region "Variables"
    Private ls_idpersona As String
    Private ll_idtipo_comprobante As Long
    Private ls_idcomprobante As String
    Private ll_idunidad_agencia_origen As Long
    Private ll_idunidad_agencia_destino As Long
    Private ls_nro_documento As String
    Private ll_idagencia_origen As Long
    Private ll_idagencia_destino As Long
    Private ll_idagencia As Long
    Private ls_ip As String
    Private ll_idusuario_personal As Long
    Private ls_fecha_incidente As String
    Private ll_idagencia_recep As Long
#End Region
#Region "Property"
    Public Property idagencia_recep() As Long
        Get
            Return ll_idagencia_recep
        End Get
        Set(ByVal value As Long)
            ll_idagencia_recep = value
        End Set
    End Property
    Public Property fecha_incidente() As String
        Get
            Return ls_fecha_incidente
        End Get
        Set(ByVal value As String)
            ls_fecha_incidente = value
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
    Public Property idagencia() As Long
        Get
            Return ll_idagencia
        End Get
        Set(ByVal value As Long)
            ll_idagencia = value
        End Set
    End Property
    Public Property idagencia_destino() As Long
        Get
            Return ll_idagencia_destino
        End Get
        Set(ByVal value As Long)
            ll_idagencia_destino = value
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
    Public Property nro_documento() As String
        Get
            Return ls_nro_documento
        End Get
        Set(ByVal value As String)
            ls_nro_documento = value
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
    Public Property idtipo_comprobante() As Long
        Get
            Return ll_idtipo_comprobante
        End Get
        Set(ByVal value As Long)
            ll_idtipo_comprobante = value
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
#End Region
#Region "Funciones y Procedimientos"
    'Public Function fn_valida_dcto_asocia_guia_gt_2009() As ADODB.Recordset
    '    '- 
    '    'Dim ObjUnd2 As Object() = {"PKG_IVORECEPCION_CARGA.sp_valida_dcto_asocia_guia_gt", 8, _
    '    '                                                                                                        ll_idtipo_comprobante, 1, _
    '    '                                                                                                         ls_idcomprobante, 2, _
    '    '                                                                                                         ll_idunidad_agencia_destino, 1}
    '    Dim ObjUnd2 As Object() = {"PKG_IVORECEPCION_CARGA.sp_valida_dcto_asocia_guiagt_1", 10, _
    '                                                               ll_idtipo_comprobante, 1, _
    '                                                               ls_idcomprobante, 2, _
    '                                                               ll_idunidad_agencia_destino, 1, _
    '                                                               ll_idagencia_recep, 1}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function
    Public Function fn_valida_dcto_asocia_guia_gt() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            Dim ll_idcomprobante As Int32 = CType(ls_idcomprobante, Int32)

            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_valida_dcto_asocia_guiagt_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idtipo_comprobante", ll_idtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idcomprobante", ll_idcomprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_cidudad_destino", ll_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_incidente", ll_idagencia_recep, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_genera_incidente_despacho_2009() As ADODB.Recordset
    '    '- 
    '    Dim ObjUnd2 As Object() = {"PKG_IVORECEPCION_CARGA.sp_genera_incidente_despacho", 20, _
    '                                                                                                                                       ll_idtipo_comprobante, 1, _
    '                                                                                                                                       ls_idcomprobante, 2, _
    '                                                                                                                                       ls_nro_documento, 2, _
    '                                                                                                                                       ll_idagencia_origen, 1, _
    '                                                                                                                                       ll_idagencia_destino, 1, _
    '                                                                                                                                       ll_idagencia, 1, _
    '                                                                                                                                       ls_ip, 2, _
    '                                                                                                                                       ll_idusuario_personal, 1, _
    '                                                                                                                                       ls_fecha_incidente, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    '    '
    'End Function
    Public Function fn_genera_incidente_despacho() As DataTable

        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            Dim ll_idcomprobante As Int32 = CType(ls_idcomprobante, Int32)
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_genera_incidente_despacho", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idtipo_comprobante", ll_idtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idcomprobante", ll_idcomprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_nro_documento", ls_nro_documento, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_ori", ll_idagencia_origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia_des", ll_idagencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencia", ll_idagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ls_ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_personal", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_fecha_incidencia", ls_fecha_incidente, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
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
