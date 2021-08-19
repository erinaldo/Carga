Imports AccesoDatos
Public Class dtgrabarecojo
   
#Region "variables graba recojo"

    Private Cnidrecojo As Integer
    Private Idpersona As Integer
    Private CnControl As Integer
    Private IDCOMU As Integer


    Public Property Control() As Integer
        Get
            Return CnControl
        End Get
        Set(ByVal value As Integer)
            CnControl = value
        End Set
    End Property
    Public Property idrecojo() As Integer
        Get
            Return Cnidrecojo
        End Get
        Set(ByVal value As Integer)
            Cnidrecojo = value
        End Set
    End Property
    Public Property idpers() As Integer
        Get
            Return Idpersona
        End Get
        Set(ByVal value As Integer)
            Idpersona = value
        End Set
    End Property
    Public Property idcomuni() As Integer
        Get
            Return IDCOMU
        End Get
        Set(ByVal value As Integer)
            IDCOMU = value
        End Set
    End Property
#End Region

#Region "graba contacto"
    Private CnIDCONTACTO_PERSONA As Integer
    Public Property Idcontacto_persona() As Integer
        Get
            Return CnIDCONTACTO_PERSONA
        End Get
        Set(ByVal value As Integer)
            CnIDCONTACTO_PERSONA = value
        End Set
    End Property
#End Region

#Region "graba direccion"
    Private CnIDDIRECCION_CONSIGNADO As Integer
    Public Property iddir_consignado() As Integer
        Get
            Return CnIDDIRECCION_CONSIGNADO
        End Get
        Set(ByVal value As Integer)
            CnIDDIRECCION_CONSIGNADO = value
        End Set
    End Property
#End Region

#Region "Funcion Grabar"
    Private Cnidtipo_persona As Integer
    Private Cnrazon_social As String
    Private Cnapellido_paterno As String
    Private Cnapellido_materno As String
    Private Cnnombre As String
    Private Cntipo_doc_identidad As Integer
    Private Cnnu_docu_suna As String

    Private Cnnombres As String
    Private Cnidtipo_documento_contacto As Integer
    Private Cnnrodocumento As String
    Private Cnemail_contacto As String

    Private Cnnrocomunicacion_contacto_t As String
    Private Cnidtipo_comunicacion_t As Integer

    Private Cnnrocomunicacion_contacto_m As String
    Private Cnidtipo_comunicacion_m As Integer

    Private Cndireccion As String
    Private Cnreferencia As String
    Private Cnidpais As Integer
    Private Cniddepartamento As Integer
    Private Cnidprovincia As Integer
    Private Cniddistrito As Integer

    Private Cnestado As Integer
    Private Cnsolicitante As String
    Private Cnfecha As String
    Private Cnfecharecojo As Date
    Private Cnitem As Integer
    Private Cnhora_listo As String
    Private Cnhora_cierre As String
    Private Cnobservacion As String
    Private Cntipo_recojo As Integer
    Private Cnid_tipo_cliente As Integer

    Private Cnid_ciudad_destino As Integer
    Private CnBultos As Integer
    Private CnPeso As Integer
    Private CnVolumen As Integer

    Private Cnidpersona_p As Integer
    Private Cnidcontacto_persona_c As Integer
    Private Cniddireccio_consignado_d As Integer
    Private Cnidcomunicacion_contacto_t As Integer
    Private Cnidcomunicacion_contacto_m As Integer

    'PERSONA
    Private iModificado As Integer
    Public Property Modificado() As Integer
        Get
            Return iModificado
        End Get
        Set(ByVal value As Integer)
            iModificado = value
        End Set
    End Property

    Private iUsuario As Integer
    Public Property Usuario() As String
        Get
            Return iUsuario
        End Get
        Set(ByVal value As String)
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

    Private intRol As Integer
    Public Property Rol() As Integer
        Get
            Return intRol
        End Get
        Set(ByVal value As Integer)
            intRol = value
        End Set
    End Property

    Private iCiudad As Integer
    Public Property Ciudad() As Integer
        Get
            Return iCiudad
        End Get
        Set(ByVal value As Integer)
            iCiudad = value
        End Set
    End Property
    Private iAgencia As Integer
    Public Property Agencia() As Integer
        Get
            Return iAgencia
        End Get
        Set(ByVal value As Integer)
            iAgencia = value
        End Set
    End Property

    Public Property idtipo_persona() As Integer
        Get
            Return Cnidtipo_persona
        End Get
        Set(ByVal value As Integer)
            Cnidtipo_persona = value
        End Set
    End Property
    Public Property razon_social() As String
        Get
            Return Cnrazon_social
        End Get
        Set(ByVal value As String)
            Cnrazon_social = value
        End Set
    End Property
    Public Property apellido_paterno() As String
        Get
            Return Cnapellido_paterno
        End Get
        Set(ByVal value As String)
            Cnapellido_paterno = value
        End Set
    End Property
    Public Property apellido_materno() As String
        Get
            Return Cnapellido_materno
        End Get
        Set(ByVal value As String)
            Cnapellido_materno = value
        End Set
    End Property
    Public Property nombre() As String
        Get
            Return Cnnombre
        End Get
        Set(ByVal value As String)
            Cnnombre = value
        End Set
    End Property
    Public Property tipo_doc_identidad() As Integer
        Get
            Return Cntipo_doc_identidad
        End Get
        Set(ByVal value As Integer)
            Cntipo_doc_identidad = value
        End Set
    End Property
    Public Property nu_docu_suna() As String
        Get
            Return Cnnu_docu_suna
        End Get
        Set(ByVal value As String)
            Cnnu_docu_suna = value
        End Set
    End Property
    'CONTACTO
    Public Property nombres() As String
        Get
            Return Cnnombres
        End Get
        Set(ByVal value As String)
            Cnnombres = value
        End Set
    End Property
    Public Property idtipo_documento_contacto() As Integer
        Get
            Return Cnidtipo_documento_contacto
        End Get
        Set(ByVal value As Integer)
            Cnidtipo_documento_contacto = value
        End Set
    End Property
    Public Property nrodocumento() As String
        Get
            Return Cnnrodocumento
        End Get
        Set(ByVal value As String)
            Cnnrodocumento = value
        End Set
    End Property
    Public Property email_contacto() As String
        Get
            Return Cnemail_contacto
        End Get
        Set(ByVal value As String)
            Cnemail_contacto = value
        End Set
    End Property
    Public Property nrocomunicacion_contacto_t() As String
        Get
            Return Cnnrocomunicacion_contacto_t
        End Get
        Set(ByVal value As String)
            Cnnrocomunicacion_contacto_t = value
        End Set
    End Property
    Public Property idtipo_comunicacion_t() As Integer
        Get
            Return Cnidtipo_comunicacion_t
        End Get
        Set(ByVal value As Integer)
            Cnidtipo_comunicacion_t = value
        End Set
    End Property

    'MOVIL
    Public Property nrocomunicacion_contacto_m() As String
        Get
            Return Cnnrocomunicacion_contacto_m
        End Get
        Set(ByVal value As String)
            Cnnrocomunicacion_contacto_m = value
        End Set
    End Property
    Public Property idtipo_comunicacion_m() As Integer
        Get
            Return Cnidtipo_comunicacion_m
        End Get
        Set(ByVal value As Integer)
            Cnidtipo_comunicacion_m = value
        End Set
    End Property




    'DIRECCION
    Public Property direccion() As String
        Get
            Return Cndireccion
        End Get
        Set(ByVal value As String)
            Cndireccion = value
        End Set
    End Property
    Public Property referencia() As String
        Get
            Return Cnreferencia
        End Get
        Set(ByVal value As String)
            Cnreferencia = value
        End Set
    End Property
    Public Property idpais() As Integer
        Get
            Return Cnidpais
        End Get
        Set(ByVal value As Integer)
            Cnidpais = value
        End Set
    End Property
    Public Property iddepartamento() As Integer
        Get
            Return Cniddepartamento
        End Get
        Set(ByVal value As Integer)
            Cniddepartamento = value
        End Set
    End Property
    Public Property idprovincia() As Integer
        Get
            Return Cnidprovincia
        End Get
        Set(ByVal value As Integer)
            Cnidprovincia = value
        End Set
    End Property
    Public Property iddistrito() As Integer
        Get
            Return Cniddistrito
        End Get
        Set(ByVal value As Integer)
            Cniddistrito = value
        End Set
    End Property
    'recojo
    Public Property solicitante() As String
        Get
            Return Cnsolicitante
        End Get
        Set(ByVal value As String)
            Cnsolicitante = value
        End Set
    End Property

    Public Property fecha() As String
        Get
            Return Cnfecha
        End Get
        Set(ByVal value As String)
            Cnfecha = value
        End Set
    End Property
    Public Property fecharecojo() As Date
        Get
            Return Cnfecharecojo
        End Get
        Set(ByVal value As Date)
            Cnfecharecojo = value
        End Set
    End Property
    Public Property item() As Integer
        Get
            Return Cnitem
        End Get
        Set(ByVal value As Integer)
            Cnitem = value
        End Set
    End Property
    Public Property hora_listo() As String
        Get
            Return Cnhora_listo
        End Get
        Set(ByVal value As String)
            Cnhora_listo = value
        End Set
    End Property
    Public Property hora_cierre() As String
        Get
            Return Cnhora_cierre
        End Get
        Set(ByVal value As String)
            Cnhora_cierre = value
        End Set
    End Property
    Public Property observacion() As String
        Get
            Return Cnobservacion
        End Get
        Set(ByVal value As String)
            Cnobservacion = value
        End Set
    End Property
    Public Property tipo_recojo() As Integer
        Get
            Return Cntipo_recojo
        End Get
        Set(ByVal value As Integer)
            Cntipo_recojo = value
        End Set
    End Property
    Public Property id_tipo_cliente() As Integer
        Get
            Return Cnid_tipo_cliente
        End Get
        Set(ByVal value As Integer)
            Cnid_tipo_cliente = value
        End Set
    End Property

    Public Property id_ciudad_destino() As Integer
        Get
            Return Cnid_ciudad_destino
        End Get
        Set(ByVal value As Integer)
            Cnid_ciudad_destino = value
        End Set
    End Property
    Public Property Bultos() As Integer
        Get
            Return CnBultos
        End Get
        Set(ByVal value As Integer)
            CnBultos = value
        End Set
    End Property
    Public Property Peso() As Integer
        Get
            Return CnPeso
        End Get
        Set(ByVal value As Integer)
            CnPeso = value
        End Set
    End Property
    Public Property Volumen() As Integer
        Get
            Return CnVolumen
        End Get
        Set(ByVal value As Integer)
            CnVolumen = value
        End Set
    End Property
    Public Property estado() As Integer
        Get
            Return Cnestado
        End Get
        Set(ByVal value As Integer)
            Cnestado = value
        End Set
    End Property

    'id
    Public Property idpersona_p() As Integer
        Get
            Return Cnidpersona_p
        End Get
        Set(ByVal value As Integer)
            Cnidpersona_p = value
        End Set
    End Property
    Public Property idcontacto_persona_c() As Integer
        Get
            Return Cnidcontacto_persona_c
        End Get
        Set(ByVal value As Integer)
            Cnidcontacto_persona_c = value
        End Set
    End Property
    Public Property idcomunicacion_contacto_m() As Integer
        Get
            Return Cnidcomunicacion_contacto_m
        End Get
        Set(ByVal value As Integer)
            Cnidcomunicacion_contacto_m = value
        End Set
    End Property

    Public Property idcomunicacion_contacto_t() As Integer
        Get
            Return Cnidcomunicacion_contacto_t
        End Get
        Set(ByVal value As Integer)
            Cnidcomunicacion_contacto_t = value
        End Set
    End Property

    Public Property iddireccio_consignado_d() As Integer
        Get
            Return Cniddireccio_consignado_d
        End Get
        Set(ByVal value As Integer)
            Cniddireccio_consignado_d = value
        End Set
    End Property

    Private intIdVia As Integer
    Public Property IdVia() As Integer
        Get
            Return intIdVia
        End Get
        Set(ByVal value As Integer)
            intIdVia = value
        End Set
    End Property

    Private strVia As String
    Public Property Via() As String
        Get
            Return strVia
        End Get
        Set(ByVal value As String)
            strVia = value
        End Set
    End Property

    Private strNumero As String
    Public Property Numero() As String
        Get
            Return strNumero
        End Get
        Set(ByVal value As String)
            strNumero = value
        End Set
    End Property

    Private strManzana As String
    Public Property Manzana() As String
        Get
            Return strManzana
        End Get
        Set(ByVal value As String)
            strManzana = value
        End Set
    End Property

    Private strLote As String
    Public Property Lote() As String
        Get
            Return strLote
        End Get
        Set(ByVal value As String)
            strLote = value
        End Set
    End Property

    Private intIdNivel As Integer
    Public Property IdNivel() As Integer
        Get
            Return intIdNivel
        End Get
        Set(ByVal value As Integer)
            intIdNivel = value
        End Set
    End Property

    Private strNivel As String
    Public Property Nivel() As String
        Get
            Return strNivel
        End Get
        Set(ByVal value As String)
            strNivel = value
        End Set
    End Property

    Private intIdZona As Integer
    Public Property IdZona() As Integer
        Get
            Return intIdZona
        End Get
        Set(ByVal value As Integer)
            intIdZona = value
        End Set
    End Property

    Private strZona As String
    Public Property Zona() As String
        Get
            Return strZona
        End Get
        Set(ByVal value As String)
            strZona = value
        End Set
    End Property

    Private intIdClasificacion As Integer
    Public Property IdClasificacion() As Integer
        Get
            Return intIdClasificacion
        End Get
        Set(ByVal value As Integer)
            intIdClasificacion = value
        End Set
    End Property

    Private strClasificacion As String
    Public Property Clasificacion() As String
        Get
            Return strClasificacion
        End Get
        Set(ByVal value As String)
            strClasificacion = value
        End Set
    End Property

    Private intProducto As Integer
    Public Property Producto() As Integer
        Get
            Return intProducto
        End Get
        Set(ByVal value As Integer)
            intProducto = value
        End Set
    End Property

    Private strUrl As String
    Public Property Url() As String
        Get
            Return strUrl
        End Get
        Set(ByVal value As String)
            strUrl = value
        End Set
    End Property

    Private strLatitud As String
    Public Property Latitud() As String
        Get
            Return strLatitud
        End Get
        Set(ByVal value As String)
            strLatitud = value
        End Set
    End Property

    Private strLongitud As String
    Public Property Longitud() As String
        Get
            Return strLongitud
        End Get
        Set(ByVal value As String)
            strLongitud = value
        End Set
    End Property


#End Region

#Region "LISTAS PARA GRABAR"
    Function listar_grabar() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_listas_grabar", CommandType.StoredProcedure)
            db.AsignarParametro("cur_t_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_t_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_T_persona", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_t_recojo", OracleClient.OracleType.Cursor)
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

    Sub fn_grabadatos_recojo(ByVal CControl As Integer, ByVal Cnsolicitante As String, ByVal Cnitem As Integer, ByVal Cnid_persona As Integer, ByVal Cnid_direccion As Integer, ByVal Cnid_contacto As Integer, ByVal Cnhora_listo As String, ByVal Cnhora_cierre As String, ByVal Cnobservacion As String, ByVal Cntipo_recojo As Integer, ByVal Cnid_tipo_cliente As Integer, ByVal Cnid_estado_registro As Integer, ByVal Cnusuario_creacion As Integer, ByVal Cnip_creacion As String, ByVal Cnid_checkpoint As Integer)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_RECOJO.SP_INSUPD_RECOJO", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", CControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("iID_RECOJO", Cnidrecojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iSOLICITANTE", Cnsolicitante, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("iFECHA", Cnfecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iITEM", Cnitem, OracleClient.OracleType.Int32)
            db.AsignarParametro("iID_PERSONA", Cnid_persona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iID_DIRECCION", Cnid_direccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iID_CONTACTO", Cnid_contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("iHORA_LISTO", Cnhora_listo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iHORA_CIERRE", Cnhora_cierre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iOBSERVACION", Cnobservacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTIPO_RECOJO", Cntipo_recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iID_TIPO_CLIENTE", Cnid_tipo_cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iID_ESTADO_REGISTRO", Cnid_estado_registro, OracleClient.OracleType.Int32)
            'db.AsignarParametro("iFECHA_CREACION", Cnfecha_creacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUSUARIO_CREACION", Cnusuario_creacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP_CREACION", Cnip_creacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iID_CHECKPOINT", Cnid_checkpoint, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'graba direccion
    Sub fn_grabadatos_direccion(ByVal control As Integer, ByVal CnIDPERSONAD As Integer, ByVal CnDIRECCION As String, ByVal CnDE_REFERENCIA As String, ByVal CnIDUSUARIO_PERSONALMOD As Integer, ByVal CnIDROL_USUARIOMOD As Integer, ByVal CnIPMOD As String, ByVal CnIDPAIS As Integer, ByVal CnIDDEPA As Integer, ByVal CnIDPROV As Integer, ByVal CnIDDISTRI As Integer)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_insupd_direcciones", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", CnControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDIRECCION_CONSIGNADO", CnIDDIRECCION_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPERSONA", CnIDPERSONAD, OracleClient.OracleType.Int32)
            db.AsignarParametro("iDIRECCION", CnDIRECCION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDE_REFERENCIA", CnDE_REFERENCIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONALMOD", CnIDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIOMOD", CnIDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIPMOD", CnIPMOD, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("iFECHA_ACTUALIZACION", Cnsolicitante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDPAIS", CnIDPAIS, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", CnIDDEPA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPROVINCIA", CnIDPROV, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDISTRITO", CnIDDISTRI, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'graba contacto
    Sub fn_grabadatos_contacto(ByVal Ccontrol As Integer, ByVal CnIDTIPO_CONTACTO As Integer, ByVal CnIDPERSONA As Integer, ByVal CnNOMBRES As String, ByVal CnIDTIPO_DOCUMENTO_CONTACTO As Integer, ByVal CnNRODOCUMENTO As String, ByVal CnEMAIL_CONTACTO As String, ByVal CnIDUSUARIO_PERSONAL As Integer, ByVal CnIDROL_USUARIO As Integer, ByVal CnIP As String, ByVal CnESTADO_REGISTRO As Integer)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_RECOJO.SP_INSUPD_CONTACTOPERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", Ccontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCONTACTO_PERSONA", CnIDCONTACTO_PERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_CONTACTO", CnIDTIPO_CONTACTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPERSONA", CnIDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRES", CnNOMBRES, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_DOCUMENTO_CONTACTO", CnIDTIPO_DOCUMENTO_CONTACTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNRODOCUMENTO", CnNRODOCUMENTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iEMAIL_CONTACTO", CnEMAIL_CONTACTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", CnIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", CnIDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", CnIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iESTADO_REGISTRO", CnESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'graba comunicacion
    Sub fn_grabadatos_comunicacion(ByVal Ccontrol As Integer, ByVal nrocomu As String, ByVal tipocomu As Integer, ByVal idcontacto As Integer)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_insupd_comunicacion", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", Ccontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCOMUNICACION_CONTACTO", IDCOMU, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNROCOMUNICACION_CONTACTO", nrocomu, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_COMUNICACION", tipocomu, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCONTACTO_PERSONA", idcontacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'graba persona
    Sub fn_grabapersona(ByVal Ccontrol As Integer, ByVal Idtipopersona As Integer, ByVal corp As Integer, ByVal Razon As String, ByVal apep As String, ByVal apem As String, ByVal nom As String, ByVal idtipodoc As Integer, ByVal nudoc As String, ByVal reg As Integer, ByVal usuper As Integer, ByVal rolusu As Integer, ByVal ip As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_RECOJO.SP_INSUPD_PERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", Ccontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPERSONA", Idpersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_PERSONA", Idtipopersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("icliente_corporativo", corp, OracleClient.OracleType.Int32)
            db.AsignarParametro("iRAZON_SOCIAL", Razon, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iapellido_paterno", apep, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iapellido_materno", apem, OracleClient.OracleType.VarChar)
            db.AsignarParametro("inombre_persona", nom, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_DOC_IDENTIDAD", idtipodoc, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNU_DOCU_SUNA", nudoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidestado_registro", reg, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidusuario_personal", usuper, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidrol_usuario", rolusu, OracleClient.OracleType.Int32)
            db.AsignarParametro("iip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

#Region "Grabar"
    Function Fn_Grabar() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_RECOJO.SP_GRABAR_RECOJO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idtipo_persona", Cnidtipo_persona, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_razon_social", Cnrazon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_apellido_paterno", Cnapellido_paterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_apellido_materno", Cnapellido_materno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nombre", Cnnombre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_doc_identidad", Cntipo_doc_identidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nu_docu_suna", Cnnu_docu_suna, OracleClient.OracleType.VarChar)

            db.AsignarParametro("vi_nombres", Cnnombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_documento_contacto", Cnidtipo_documento_contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nrodocumento", Cnnrodocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_email_contacto", Cnemail_contacto, OracleClient.OracleType.VarChar)

            db.AsignarParametro("vi_nrocomunicacion_contacto_t", Cnnrocomunicacion_contacto_t, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comunicacion_t", Cnidtipo_comunicacion_t, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_nrocomunicacion_contacto_m", Cnnrocomunicacion_contacto_m, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comunicacion_m", Cnidtipo_comunicacion_m, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_direccion", Cndireccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_referencia", Cnreferencia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idpais", Cnidpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_iddepartamento", Cniddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idprovincia", Cnidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_iddistrito", Cniddistrito, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_solicitante", Cnsolicitante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha", Cnfecha, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("vi_fecharecojo", Cnfecharecojo, OracleClient.OracleType.DateTime)
            'db.AsignarParametro("vi_item", Cnitem, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_hora_listo", Cnhora_listo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora_cierre", Cnhora_cierre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_observacion", Cnobservacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_recojo", Cntipo_recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_id_tipo_cliente", Cnid_tipo_cliente, OracleClient.OracleType.Int32)

            'db.AsignarParametro("ni_id_ciudad_destino", Cnid_ciudad_destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_Bultos", CnBultos, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", CnPeso, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_volumen", CnVolumen, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_ciudad", iCiudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", iAgencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_producto", intProducto, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region "Grabar Existente"
    Function Fn_Grabar_Existente(Optional ByVal recojo As Integer = 0) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_RECOJO.SP_GRABAR_EXISTENTE", CommandType.StoredProcedure)
            db.AsignarParametro("ni_recojo", recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idpersona", Cnidpersona_p, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idcontacto_persona", Cnidcontacto_persona_c, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nombres", Cnnombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_documento_contacto", Cnidtipo_documento_contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nrodocumento", Cnnrodocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_email_contacto", Cnemail_contacto, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_idcomunicacion_contacto_t", Cnidcomunicacion_contacto_t, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nrocomunicacion_contacto_t", Cnnrocomunicacion_contacto_t, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comunicacion_t", Cnidtipo_comunicacion_t, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_idcomunicacion_contacto_m", Cnidcomunicacion_contacto_m, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nrocomunicacion_contacto_m", Cnnrocomunicacion_contacto_m, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comunicacion_m", Cnidtipo_comunicacion_m, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_iddireccion_consignado", Cniddireccio_consignado_d, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_direccion", Cndireccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_referencia", Cnreferencia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idpais", Cnidpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_iddepartamento", Cniddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idprovincia", Cnidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_iddistrito", Cniddistrito, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_id_via", intIdVia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_via", strVia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", strNumero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_manzana", strManzana, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_lote", strLote, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_id_nivel", intIdNivel, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nivel", strNivel, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_id_zona", intIdZona, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_zona", strZona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_id_clasificacion", intIdClasificacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_clasificacion", strClasificacion, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_estado", Cnestado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_solicitante", Cnsolicitante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha", Cnfecha, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("vi_fecharecojo", Cnfecharecojo, OracleClient.OracleType.DateTime)
            'db.AsignarParametro("vi_item", Cnitem, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_hora_listo", Cnhora_listo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora_cierre", Cnhora_cierre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_observacion", Cnobservacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_recojo", Cntipo_recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_id_tipo_cliente", Cnid_tipo_cliente, OracleClient.OracleType.Int32)
            'db.AsignarParametro("ni_id_ciudad_destino", Cnid_ciudad_destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_Bultos", CnBultos, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", CnPeso, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_volumen", CnVolumen, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", sIp, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_ciudad", iCiudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", iAgencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_producto", intProducto, OracleClient.OracleType.Int32)

            'hlamas 24-01-2020
            db.AsignarParametro("vi_url", Url, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_latitud", Latitud, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_longitud", Longitud, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub GrabarDestino(ByVal id As Integer, ByVal ciudad As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal opcion As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_grabar_recojo_destino", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
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

    Function GrabarRecojoAcordado(ByVal id As Integer, ByVal inicio As String) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_grabar_recojo_acordado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", idpers, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_direccion", iddir_consignado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_direccion", direccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_referencia", referencia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_pais", idpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_departamento", iddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_provincia", idprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_distrito", iddistrito, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_via", IdVia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_via", Via, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero", Numero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_manzana", Manzana, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_lote", Lote, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_id_nivel", IdNivel, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nivel", Nivel, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_id_zona", IdZona, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_zona", Zona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_id_clasificacion", IdClasificacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_clasificacion", Clasificacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", Ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", Agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_contacto", Idcontacto_persona, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nombres", nombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_documento_contacto", idtipo_documento_contacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nrodocumento", nrodocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_email_contacto", email_contacto, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_idcomunicacion_contacto_t", idcomunicacion_contacto_t, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nrocomunicacion_contacto_t", nrocomunicacion_contacto_t, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comunicacion_t", idtipo_comunicacion_t, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_idcomunicacion_contacto_m", idcomunicacion_contacto_m, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nrocomunicacion_contacto_m", nrocomunicacion_contacto_m, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comunicacion_m", idtipo_comunicacion_m, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)

            'hlamas 24-01-2020
            db.AsignarParametro("vi_url", Url, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_latitud", Latitud, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_longitud", Longitud, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_usuario", Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", Ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", Rol, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0).Rows(0).Item(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub GrabarRecojoAcordado(ByVal id As Integer, ByVal dia As Integer, ByVal hora_listo As String, ByVal hora_cierre As String, ByVal cantidad As Integer, ByVal peso As Double, ByVal volumen As Double, _
                             ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal opcion As Integer, ByVal id_det As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_RECOJO.sp_grabar_recojo_acordado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_dia", dia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_hora_listo", hora_listo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_hora_cierre", hora_cierre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_volumen", volumen, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_id_det", id_det, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
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

    Sub GrabarDireccionGps(ByVal id As Integer, ByVal url As String, ByVal latitud As String, ByVal longitud As String, _
                                ByVal usuario As Integer, ByVal ip As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_OPERACION_TERRESTRE.sp_grabar_dir_gps", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_url", url, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_latitud", latitud, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_longitud", longitud, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1))
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region

End Class
