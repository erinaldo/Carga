Imports AccesoDatos
Public Class dto_pce_a_guia_envio
#Region "Variables"
    Private ls_idfactura_contado As String
    Private ls_idpersona As String
    Private ls_idremitente As String
    Private ls_remitente As String
    Private ls_nro_doc_remitente As String
    Private ls_idcontacto_destinatario As String
    Private ls_destinatario As String
    Private ls_nro_doc_destinatario As String
    Private ls_iddireccion_remitente As String
    Private ls_direccion_remitente As String
    Private ls_iddir_destinatario As String
    Private ls_direccion_destinatario As String
    Private ls_idtelefono_remite As String
    Private ls_telefono_remite As String
    Private ls_idTelefono_Destinatario As String
    Private ls_telefono_destinatario As String
    Private ls_idcontacto_remite As String
    Private ll_idtipo_entrega_carga As Long
    Private ll_idcentro_costo As Long
    Private ll_rol_usuario As Long
    Private ll_idusuario_personal As Long
    Private ls_ip As String
#End Region
#Region "Propiedades"
    Public Property telefono_remite() As String
        Get
            Return ls_telefono_remite
        End Get
        Set(ByVal value As String)
            ls_telefono_remite = value
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
    Public Property rol_usuario() As Long
        Get
            Return ll_rol_usuario
        End Get
        Set(ByVal value As Long)
            ll_rol_usuario = value
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
    Public Property idtipo_entrega_carga() As Long
        Get
            Return ll_idtipo_entrega_carga
        End Get
        Set(ByVal value As Long)
            ll_idtipo_entrega_carga = value
        End Set
    End Property
    Public Property idcontacto_remite() As String
        Get
            Return ls_idcontacto_remite
        End Get
        Set(ByVal value As String)
            ls_idcontacto_remite = value
        End Set
    End Property
    Public Property telefono_destinatario() As String
        Get
            Return ls_telefono_destinatario
        End Get
        Set(ByVal value As String)
            ls_telefono_destinatario = value
        End Set
    End Property
    Public Property idTelefono_Destinatario() As String
        Get
            Return ls_idTelefono_Destinatario
        End Get
        Set(ByVal value As String)
            ls_idTelefono_Destinatario = value
        End Set
    End Property
    Public Property idtelefono_remite() As String
        Get
            Return ls_idtelefono_remite
        End Get
        Set(ByVal value As String)
            ls_idtelefono_remite = value
        End Set
    End Property
    Public Property direccion_destinatario() As String
        Get
            Return ls_direccion_destinatario
        End Get
        Set(ByVal value As String)
            ls_direccion_destinatario = value
        End Set
    End Property
    Public Property iddir_destinatario() As String
        Get
            Return ls_iddir_destinatario
        End Get
        Set(ByVal value As String)
            ls_iddir_destinatario = value
        End Set
    End Property
    Public Property direccion_remitente() As String
        Get
            Return ls_direccion_remitente
        End Get
        Set(ByVal value As String)
            ls_direccion_remitente = value
        End Set
    End Property
    Public Property iddireccion_remitente() As String
        Get
            Return ls_iddireccion_remitente
        End Get
        Set(ByVal value As String)
            ls_iddireccion_remitente = value
        End Set
    End Property
    Public Property nro_doc_destinatario() As String
        Get
            Return ls_nro_doc_destinatario
        End Get
        Set(ByVal value As String)
            ls_nro_doc_destinatario = value
        End Set
    End Property
    Public Property destinatario() As String
        Get
            Return ls_destinatario
        End Get
        Set(ByVal value As String)
            ls_destinatario = value
        End Set
    End Property
    Public Property idcontacto_destinatario() As String
        Get
            Return ls_idcontacto_destinatario
        End Get
        Set(ByVal value As String)
            ls_idcontacto_destinatario = value
        End Set
    End Property
    Public Property nro_doc_remitente() As String
        Get
            Return ls_nro_doc_remitente
        End Get
        Set(ByVal value As String)
            ls_nro_doc_remitente = value
        End Set
    End Property
    Public Property remitente() As String
        Get
            Return ls_remitente
        End Get
        Set(ByVal value As String)
            ls_remitente = value
        End Set
    End Property
    Public Property idremitente() As String
        Get
            Return ls_idremitente
        End Get
        Set(ByVal value As String)
            ls_idremitente = value
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
    Public Property idfactura_contado() As String
        Get
            Return ls_idfactura_contado
        End Get
        Set(ByVal value As String)
            ls_idfactura_contado = value
        End Set
    End Property
#End Region
#Region "Procedimientos y Funciones"
    'Function fn_get_pce_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOVENTACARGA.sp_get_datos_pce", 4, _
    '                                                     ls_idfactura_contado, 2}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Function fn_get_pce() As DataSet
        '
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.sp_get_datos_pce", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idfactura_contado", ls_idfactura_contado, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_tipo_entrega", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        '
    End Function
    'Function fn_actualiza_pce_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOVENTACARGA.sp_graba_pce_credito", 44, _
    '                                                     ls_idfactura_contado, 2, _
    '                                                     ls_idpersona, 2, _
    '                                                     ls_idremitente, 2, _
    '                                                     ls_remitente, 2, _
    '                                                     ls_nro_doc_remitente, 2, _
    '                                                     ls_idcontacto_destinatario, 2, _
    '                                                     ls_destinatario, 2, _
    '                                                     ls_nro_doc_destinatario, 2, _
    '                                                     ls_iddireccion_remitente, 2, _
    '                                                     ls_direccion_remitente, 2, _
    '                                                     ls_iddir_destinatario, 2, _
    '                                                     ls_direccion_destinatario, 2, _
    '                                                     ls_idtelefono_remite, 2, _
    '                                                     ls_telefono_remite, 2, _
    '                                                     ls_idTelefono_Destinatario, 2, _
    '                                                     ls_telefono_destinatario, 2, _
    '                                                     ll_idtipo_entrega_carga, 1, _
    '                                                    ll_idcentro_costo, 1, _
    '                                                    ll_rol_usuario, 1, _
    '                                                    ll_idusuario_personal, 1, _
    '                                                    ls_ip, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Function fn_actualiza_pce() As DataTable
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.sp_graba_pce_credito", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idfactura", ls_idfactura_contado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idpersona", ls_idpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idremitente", ls_idremitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_remitente", ls_remitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_nro_doc_remitente", ls_nro_doc_remitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idcontacto_destinatario", ls_idcontacto_destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_destinatario", ls_destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_nro_doc_destinatario", ls_nro_doc_destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_iddireccion_remitente", ls_iddireccion_remitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_direccion_remitente", ls_direccion_remitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_iddir_destinatario", ls_iddir_destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_direccion_destinatario", ls_direccion_destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idtelefono_remite", ls_idtelefono_remite, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_telefono_remite", ls_telefono_remite, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idTelefono_Destinatario", ls_idTelefono_Destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_telefono_destinatario", ls_telefono_destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_entrega_carga", ll_idtipo_entrega_carga, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idrol_usuario", ll_rol_usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idusuario_personal", ll_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ls_ip, OracleClient.OracleType.VarChar)
            '
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