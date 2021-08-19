Imports AccesoDatos
Public Class dtrecojo

    Private iRecojo As Integer
    Public Property Recojo() As Integer
        Get
            Return iRecojo
        End Get
        Set(ByVal value As Integer)
            iRecojo = value
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

    Function listar_recojo() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            'Dim ds As DataSet = db.EjecutarDataSet()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function
    Function listar_codcliente() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_clientes", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function listar_pais() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_pais", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            ' Dim ds As DataSet = db.EjecutarDataSet()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function listar_departamento(ByVal pais As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_departa", CommandType.StoredProcedure)
            db.AsignarParametro("ni_departa", pais, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function listar_provincia(ByVal departamento As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_prov", CommandType.StoredProcedure)
            db.AsignarParametro("ni_provi", departamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function listar_distrito(ByVal provincia As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_distri", CommandType.StoredProcedure)
            db.AsignarParametro("ni_distri", provincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function Listar_cli(ByVal ndoc As String, Optional ByVal tipo_documento As Integer = 0, Optional ByVal funcionario As Integer = 0) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listcli", CommandType.StoredProcedure)
            db.AsignarParametro("vi_cliente", ndoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_documento", tipo_documento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function busca_cli(ByVal rsocial As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_buscacli", CommandType.StoredProcedure)
            db.AsignarParametro("vi_buscli", rsocial, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'buscadireccion
    Function busca_dir(ByVal bdir As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_buscadir", CommandType.StoredProcedure)
            db.AsignarParametro("vi_direccion", bdir, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'lista documentos
    Function listar_doc() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_doc", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            ' Dim ds As DataSet = db.EjecutarDataSet()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function
    'listamos medios de comunicacion
    Function listar_comu() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_comunicacion", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            ' Dim ds As DataSet = db.EjecutarDataSet()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    'contactos por nombre
    'Function ListarContactonom(ByVal contacto As String, ByVal cliente As Integer, ByVal documento As String) As DataSet
    '    Dim db As New BaseDatos
    '    Try
    '        db.Conectar()
    '        db.CrearComando("PKG_RECOJO.sp_contactonom", CommandType.StoredProcedure)
    '        db.AsignarParametro("vi_contactonom", contacto, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("vi_documento", documento, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
    '        db.Desconectar()
    '        Dim ds As DataSet = db.EjecutarDataSet()
    '        Return ds
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    Finally
    '        db.Desconectar()
    '    End Try
    'End Function
    'contactos por numero de documento
    Function ListarContactodoc(ByVal contactodoc As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_contactodoc", CommandType.StoredProcedure)
            db.AsignarParametro("vi_contactodoc", contactodoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function listar_estados() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_estado", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function InicioCalculadora() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_inicio_calculadora", CommandType.StoredProcedure)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ciudad2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo_entrega", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'va filtrar el codigo de direccion por persona'
    Function busca_dirxcod(ByVal bdirxcod As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listcodigod", CommandType.StoredProcedure)
            db.AsignarParametro("ni_codd", bdirxcod, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'va filtrar el codigo de Contacto por persona'
    Function busca_contxcod(ByVal bcontxcod As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listcodigoc", CommandType.StoredProcedure)
            db.AsignarParametro("ni_codc", bcontxcod, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'lista por numero de documento
    Function busca_nrodoc(ByVal nrodoc As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listtablas", CommandType.StoredProcedure)
            db.AsignarParametro("vi_num", nrodoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function ListarUbigeo() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_ubigeo", CommandType.StoredProcedure)
            db.AsignarParametro("co_pais", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_departamento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_provincia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_distrito", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarDireccion() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("co_pais", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_departamento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_provincia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_distrito", OracleClient.OracleType.Cursor)

            db.AsignarParametro("co_via", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_zona", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_nivel", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_clasificacion", OracleClient.OracleType.Cursor)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

#Region "lista Item"
    Function Lista_Item(ByVal codper As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_item", CommandType.StoredProcedure)
            db.AsignarParametro("ni_item", codper, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
#End Region

#Region "codxnomubigeo"
    Function Listacodxubigeo(ByVal nomdepa As String, ByVal nomprov As String, ByVal nomdist As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_codubigeos", CommandType.StoredProcedure)
            db.AsignarParametro("vi_nomdepa", nomdepa, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nomprov", nomprov, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nomdist", nomdist, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
#End Region

#Region "codxnomcontactos"
    Function Listacodxnomconta(ByVal nomconta As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_nomconta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_nomcont", nomconta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
#End Region

#Region "filtraultimoscontactos"
    Function ultimoscontactos(ByVal codigo As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_ultimocontacto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_persona", codigo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
#End Region

#Region "filtraultimadireccion"
    Function ultimadireccion(ByVal codigo As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_ultimadireccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_persona", codigo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
#End Region

    Function listar_Cliente(ByVal documento As String, ByVal ciudad As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_documento", documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_comunicacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_TipoCliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_comunicacion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarRecojo2() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_recojo2", CommandType.StoredProcedure)
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

    Function Listar_aGrabar(ByVal nrodocumento As String, ByVal ciudad As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listas_agrabar", CommandType.StoredProcedure)
            db.AsignarParametro("vi_documento", nrodocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_t_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_t_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_T_persona", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function listar_codComunicacion(ByVal codcontacto As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_comuniacionxcod", CommandType.StoredProcedure)
            db.AsignarParametro("ni_contacto", codcontacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_t_comunicacion_t", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_t_comunicacion_m", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Private sNU_DOCU_SUNAT As String
    Public Property CN_sNU_DOCU_SUNAT() As String
        Get
            Return sNU_DOCU_SUNAT
        End Get
        Set(ByVal value As String)
            sNU_DOCU_SUNAT = value
        End Set
    End Property

    Private iIDUNIDAD_AGENCIA_DESTINO As Integer
    Public Property CN_iIDUNIDAD_AGENCIA_DESTINO() As Integer
        Get
            Return iIDUNIDAD_AGENCIA_DESTINO
        End Get
        Set(ByVal value As Integer)
            iIDUNIDAD_AGENCIA_DESTINO = value
        End Set
    End Property

    Private iIDCENTRO_COSTO As Integer
    Public Property CN_iIDCENTRO_COSTO() As Integer
        Get
            Return iIDCENTRO_COSTO
        End Get
        Set(ByVal value As Integer)
            iIDCENTRO_COSTO = value
        End Set
    End Property
    Public iTarifa_Publica_Monto_Base As Integer
    Public iTarifa_Publica_Monto_Peso As Integer
    Public iTarifa_Publica_Monto_Volumen As Integer


    'Public Function fnLISTA_TARIFA_CLIENTE() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim db_bd As New BaseDatos
    '        Dim lds_tmp As New DataSet
    '        'conecta con la Bd
    '        db_bd.Conectar()
    '        '-- Invocando  al procedimiento almacenado 
    '        db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PERSONA_III", CommandType.StoredProcedure)
    '        'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
    '        db_bd.AsignarParametro("iNu_Docu_Suna", sNU_DOCU_SUNAT, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_ORIGEN", dtoUSUARIOS.m_idciudad.ToString, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("iIDCENTROCOSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
    '        'Variables de salidas 
    '        db_bd.AsignarParametro("curr_Tarifario", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("curr_Tarifario_config", OracleClient.OracleType.Cursor)
    '        'Desconectar 
    '        db_bd.Desconectar()
    '        '
    '        lds_tmp = db_bd.EjecutarDataSet
    '        ' 
    '        If lds_tmp.Tables(0).Rows.Count > 0 Then
    '            iTarifa_Publica_Monto_Base = Format(lds_tmp.Tables(0).Rows(0).Item(1), "##,###.00")
    '            iTarifa_Publica_Monto_Peso = Format(lds_tmp.Tables(0).Rows(0).Item(2), "##,###.00")
    '            iTarifa_Publica_Monto_Volumen = Format(lds_tmp.Tables(0).Rows(0).Item(3), "##,###.00")
    '            iTarifa_Publica_Monto_Base_Xpostal = Format(lds_tmp.Tables(0).Rows(0).Item(7), "##,###.00")
    '            iTarifa_Publica_Monto_Sobre = Format(IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), "##,###.00")
    '            dPRECIO_X_UNIDAD = Format(IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")))
    '            iTarifa = lds_tmp.Tables(0).Rows(0).Item("tarifa")
    '            '
    '            iPeso_Minimo = 0
    '            iPeso_Maximo = 0
    '            iPrecio_cond_Peso = 0
    '            iVol_Minimo = 0
    '            iVol_Maximo = 0
    '            iPrecio_cond_Vol = 0
    '            '
    '            If lds_tmp.Tables(1).Rows.Count > 0 Then
    '                'Debe hacer un for para que haga un tipo de "by-pass" y se quede con el último precio,como el último precio indicado   
    '                If lds_tmp.Tables(1).Rows(0).Item("UNIDAD") = "PESO" Then
    '                    iPeso_Minimo = lds_tmp.Tables(1).Rows(0).Item("INICIO")
    '                    iPeso_Maximo = lds_tmp.Tables(1).Rows(0).Item("FIN")
    '                    iPrecio_cond_Peso = lds_tmp.Tables(1).Rows(0).Item("PRECIO_FINAL")
    '                End If
    '                If lds_tmp.Tables(1).Rows(0).Item("UNIDAD") = "VOLUMEN" Then
    '                    iVol_Minimo = lds_tmp.Tables(1).Rows(0).Item("INICIO")
    '                    iVol_Maximo = lds_tmp.Tables(1).Rows(0).Item("FIN")
    '                    iPrecio_cond_Vol = lds_tmp.Tables(1).Rows(0).Item("PRECIO_FINAL")
    '                End If
    '            End If
    '            flag = True
    '        Else
    '            flag = False
    '        End If
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    '    Return flag
    'End Function

    Function InicioContacto() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_inicio_contacto", CommandType.StoredProcedure)
            db.AsignarParametro("cur_t_comunicacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_t_tipoDocumento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_t_tipoCliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function InicioCliente() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_inicio_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("co_pais", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_departamento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_provincia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_distrito", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_comunicacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipoDocumento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipoCliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub Anular(ByVal recojo As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_anular_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.EjecutarComando()
            db.Desconectar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function InicioRecojo() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_inicio_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("co_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipoCliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Shared Function TiempoListoCierre() As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_tiempo_listo_cierre", CommandType.StoredProcedure)
            db.AsignarParametro("co_tiempo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds.Tables(0).Rows(0).Item(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Listar_recojoxfec(ByVal inicio As String, ByVal fin As String, ByVal perfil As Integer, ByVal funcionario As Integer, ByVal ciudad As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_recojoxfec", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_perfil", perfil, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_recojo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Listar_recojoxfec(ByVal fecha As String, ByVal usuario As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_recojoxfec", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_recojo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarRecojoDestino(ByVal id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_recojo_destino", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
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

    Function ListarDireccion(ByVal documento As String, ByVal ciudad As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("vi_documento", documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
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

    Function ListarDireccion(ByVal direccion As String, ByVal documento As String, ByVal ciudad As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("vi_direccion", direccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_documento", documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
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

    Function ListarDireccion(ByVal id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
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

    Function ListarProducto(ByVal producto As Integer, ByVal tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_producto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
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

    Function ListarContactos(ByVal cadena As String, ByVal cliente As Integer, ByVal opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_contacto", CommandType.StoredProcedure)
            db.AsignarParametro("vi_cadena", cadena, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
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

    Function ListarRecojoAcordado(ByVal cliente As Integer, ByVal estado As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_recojo_acordado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
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

    Function ListarProgramacion(ByVal id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listar_programacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
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

    Sub DesactivarRecojo(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_desactivar_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
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
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class