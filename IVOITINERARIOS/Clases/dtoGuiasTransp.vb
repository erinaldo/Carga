Imports AccesoDatos
Public Class dtoGuiasTransp
    Private Stidguia As String
    Private StAccion As Integer
    Private StId As Long
    Private StSerie As String
    Private StNroGuia As String
    Private StFecGuia As String
    Private StCiuOri As Integer
    Private StCiuDes As Integer
    Private StBus As Integer
    Private StChofer As Integer
    Private StTipSer As Integer
    Private StNroSalida As String
    Private StMarca As String
    Private StPlaca As String
    Private StLicencia As String
    Private StRUCTerc As String
    Private StNomTerc As String
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIP As String
    Private StEstado As Integer
    Private StIATA As String
    Private StIATADes As String
    Private StFecIni As String
    Private StFecFin As String
    'Creado por Tepsa 11/11/2006
    Private Stinrosalida As Long
    Private lidagencia As Long
    Private lidagencia_destino As Long
    Private stipo_guia As String
    Private StBus_act As Integer
    Private StBus_old As Integer
    Private stid_guia_trans As String
    Private strFechaPartida As String
    Private strHoraPartida As String
    Private intCa As Integer

    Private intSalida As Integer
    Public Property Salida() As Integer
        Get
            Return intSalida
        End Get
        Set(ByVal value As Integer)
            intSalida = value
        End Set
    End Property

    Public Property Ca() As Integer
        Get
            Return intCa
        End Get
        Set(ByVal value As Integer)
            intCa = value
        End Set
    End Property

    Private intTipoCarga As Integer
    Public Property TipoCarga() As Integer
        Get
            Return intTipoCarga
        End Get
        Set(ByVal value As Integer)
            intTipoCarga = value
        End Set
    End Property

    Public Property HoraPartida() As String
        Get
            Return strHoraPartida
        End Get
        Set(ByVal value As String)
            strHoraPartida = value
        End Set
    End Property

    Public Property FechaPartida() As String
        Get
            Return strFechaPartida
        End Get
        Set(ByVal value As String)
            strFechaPartida = value
        End Set
    End Property

    Public Property sid_guia_trans() As String
        Get
            Return stid_guia_trans
        End Get
        Set(ByVal value As String)
            stid_guia_trans = value
        End Set
    End Property
    Public Property idagencia_ori() As Long
        Get
            Return lidagencia
        End Get
        Set(ByVal value As Long)
            lidagencia = value
        End Set
    End Property
    Public Property idagencia_dest() As Long
        Get
            Return lidagencia_destino
        End Get
        Set(ByVal value As Long)
            lidagencia_destino = value
        End Set
    End Property
    Public Property Accion() As Integer
        Get
            Return StAccion
        End Get
        Set(ByVal value As Integer)
            StAccion = value
        End Set
    End Property
    Public Property ID() As Long
        Get
            Return StId
        End Get
        Set(ByVal value As Long)
            StId = value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return StSerie
        End Get
        Set(ByVal value As String)
            StSerie = value
        End Set
    End Property
    Public Property NroGuia() As String
        Get
            Return StNroGuia
        End Get
        Set(ByVal value As String)
            StNroGuia = value
        End Set
    End Property
    Public Property FechaGuia() As String
        Get
            Return StFecGuia
        End Get
        Set(ByVal value As String)
            StFecGuia = value
        End Set
    End Property
    Public Property sidguiatransportista() As String
        Get
            Return Stidguia
        End Get
        Set(ByVal value As String)
            Stidguia = value
        End Set
    End Property
    Public Property s_stipo_guia() As String
        Get
            Return stipo_guia
        End Get
        Set(ByVal value As String)
            stipo_guia = value
        End Set
    End Property

    Public Property CiuOrigen() As Integer
        Get
            Return StCiuOri
        End Get
        Set(ByVal value As Integer)
            StCiuOri = value
        End Set
    End Property
    Public Property CiuDestino() As Integer
        Get
            Return StCiuDes
        End Get
        Set(ByVal value As Integer)
            StCiuDes = value
        End Set
    End Property
    Public Property Bus_nuevo() As Integer
        Get
            Return StBus_act
        End Get
        Set(ByVal value As Integer)
            StBus_act = value
        End Set
    End Property
    Public Property Bus_antiguo() As Integer
        Get
            Return StBus_old
        End Get
        Set(ByVal value As Integer)
            StBus_old = value
        End Set
    End Property
    Public Property Bus() As Integer
        Get
            Return StBus
        End Get
        Set(ByVal value As Integer)
            StBus = value
        End Set
    End Property
    Public Property Chofer() As Integer
        Get
            Return StChofer
        End Get
        Set(ByVal value As Integer)
            StChofer = value
        End Set
    End Property
    Public Property TipoServicio() As Integer
        Get
            Return StTipSer
        End Get
        Set(ByVal value As Integer)
            StTipSer = value
        End Set
    End Property
    Public Property NroSalida() As String
        Get
            Return StNroSalida
        End Get
        Set(ByVal value As String)
            StNroSalida = value
        End Set
    End Property
    Public Property Marca() As String
        Get
            Return StMarca
        End Get
        Set(ByVal value As String)
            StMarca = value
        End Set
    End Property
    Public Property Placa() As String
        Get
            Return StPlaca
        End Get
        Set(ByVal value As String)
            StPlaca = value
        End Set
    End Property
    Public Property Licencia() As String
        Get
            Return StLicencia
        End Get
        Set(ByVal value As String)
            StLicencia = value
        End Set
    End Property
    Public Property RUCTercero() As String
        Get
            Return StRUCTerc
        End Get
        Set(ByVal value As String)
            StRUCTerc = value
        End Set
    End Property
    Public Property NomTercero() As String
        Get
            Return StNomTerc
        End Get
        Set(ByVal value As String)
            StNomTerc = value
        End Set
    End Property
    Public Property Usuario() As Integer
        Get
            Return StUsuario
        End Get
        Set(ByVal value As Integer)
            StUsuario = value
        End Set
    End Property
    Public Property Rol() As Integer
        Get
            Return StRol
        End Get
        Set(ByVal value As Integer)
            StRol = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return StIP
        End Get
        Set(ByVal value As String)
            StIP = value
        End Set
    End Property
    Public Property Estado() As Integer
        Get
            Return StEstado
        End Get
        Set(ByVal value As Integer)
            StEstado = value
        End Set
    End Property
    Public Property IATA() As String
        Get
            Return StIATA
        End Get
        Set(ByVal value As String)
            StIATA = value
        End Set
    End Property
    Public Property IATADes() As String
        Get
            Return StIATADes
        End Get
        Set(ByVal value As String)
            StIATADes = value
        End Set
    End Property
    Public Property FecIni() As String
        Get
            Return StFecIni
        End Get
        Set(ByVal value As String)
            StFecIni = value
        End Set
    End Property
    Public Property Fecfin() As String
        Get
            Return StFecFin
        End Get
        Set(ByVal value As String)
            StFecFin = value
        End Set
    End Property
    Public Property nrosalida_real() As Long
        Get
            Return Stinrosalida
        End Get
        Set(ByVal value As Long)
            Stinrosalida = value
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

    Private intAgenciaOrigen As Integer
    Public Property AgenciaOrigen() As Integer
        Get
            Return intAgenciaOrigen
        End Get
        Set(ByVal value As Integer)
            intAgenciaOrigen = value
        End Set
    End Property

    Private intAgenciaDestino As Integer
    Public Property AgenciaDestino() As Integer
        Get
            Return intAgenciaDestino
        End Get
        Set(ByVal value As Integer)
            intAgenciaDestino = value
        End Set
    End Property


    'Public Function Lista_2009() As ADODB.Recordset
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP", 0}  'Original Eduardo 18/12/2006
    '    ' Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP_NEW", 4, dtoUSUARIOS.m_idciudad, 1}
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP_NEW_II", 4, dtoUSUARIOS.m_idciudad, 1}
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP_NEW_3", 4, dtoUSUARIOS.m_idciudad, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Lista() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP_NEW_3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidunidad_agencia", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_unidad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_moviles", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_detalle", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_bus", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_tiposervicio", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_agencias_all", OracleClient.OracleType.Cursor)
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
    'Public Function BuscaItinerario_2009() As ADODB.Recordset
    '    'Stinrosalida, 1,
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_BUSCA_ITINERARIOS", 10, StCiuOri, 1, StCiuDes, 1, StIATA, 2, StIATADes, 2}
    '    '04/12/2007 - Modificado 
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_BUSCA_ITINERARIOS_2", 10, StCiuOri, 1, StCiuDes, 1, StIATA, 2, StIATADes, 2}
    '    '        
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    'Public Function Buscar_2009() As ADODB.Recordset
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP2", 10, StCiuOri, 1, StCiuDes, 1, StFecIni, 2, StFecFin, 2}
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP3", 12, StCiuOri, 1, StCiuDes, 1, lidagencia, 1, StFecIni, 2, StFecFin, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Buscar() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StCiuOri, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", StCiuDes, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidagencias", lidagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iFECHA_INI", StFecIni, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFECHA_FIN", StFecFin, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_origen", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function BuscaSalidas_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_BUSCA_SALIDAS", 4, StNroSalida, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    'Public Function Grabar_2009() As ADODB.Recordset
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANSPORTISTA", 42, _
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANS_NEW_1", 46, _
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANS_NEW_1", 48, _
    '    ' donde se convierte en cadena el campo ctype(StId,String), 2
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANS_NEW_2", 48, _
    '                                                                      StAccion, 1, _
    '                                                                      CType(StId, String), 2, _
    '                                                                      StSerie, 2, _
    '                                                                      StNroGuia, 2, _
    '                                                                      StFecGuia, 2, _
    '                                                                      StCiuOri, 1, _
    '                                                                      StCiuDes, 1, _
    '                                                                      StBus, 1, _
    '                                                                      StChofer, 1, _
    '                                                                      StTipSer, 1, _
    '                                                                      StNroSalida, 2, _
    '                                                                      StMarca, 2, _
    '                                                                      StPlaca, 2, _
    '                                                                      StLicencia, 2, _
    '                                                                      StRUCTerc, 2, _
    '                                                                      StNomTerc, 2, _
    '                                                                      StEstado, 1, _
    '                                                                      StUsuario, 1, _
    '                                                                      StRol, 1, _
    '                                                                      StIP, 2, _
    '                                                                      lidagencia, 1, _
    '                                                                      lidagencia_destino, 1, _
    '                                                                      stipo_guia, 2}
    '    '--   stipo_guia, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Grabar() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANS_NEW_2", CommandType.StoredProcedure)
            'db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANS_NEW_3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("viIDGUIA_TRANSPORTISTA", CType(StId, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iSERIE_GUIA_TRANSPORTISTA", CType(StSerie, Int32), OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNRO_GUIA_TRANSPORTISTA", CType(StNroGuia, Int32), OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iFECHA_SALIDA", StFecGuia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StCiuOri, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", StCiuDes, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_TRANSPORTE", StBus, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL_PILOTO", StChofer, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPO_SERVICIO", StTipSer, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNRO_SALIDA", StNroSalida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iMARCA_BUS", StMarca, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iPLACA_BUS", StPlaca, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNRO_LICENCIA", StLicencia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iRUC_TERCERO", StRUCTerc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOM_TERCERO", StNomTerc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidagencia", lidagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidagencia_destino", lidagencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidtipo_guia", stipo_guia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_tipo_carga", TipoCarga, OracleClient.OracleType.Int32)
            'db_bd.AsignarParametro("ispk", ispk, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_lista", OracleClient.OracleType.Cursor)
            'Desconectar 
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
    'Public Function BuscaGuiasEnvio_2009() As ADODB.Recordset '17/03/2007
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_BUSCA_GUIAS_ENVIO", 4, StNroGuia, 2}
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_BUSCA_GUIAS_ENVIO_I", 4, StNroGuia, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function BuscaGuiasEnvio() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_BUSCA_GUIAS_ENVIO_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iNRO_GUIA", StNroGuia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_tipo", TipoComprobante, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_documentos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function BuscaGuiasEnvio_zonal() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            'db_bd.CrearComando("PKG_IVOITINERARIOS.SP_BUSCA_DCTO_trans_zonal", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_BUSCA_DCTO_trans_zonal_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_nro_comprobante", StNroGuia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idciudad_destino", StCiuDes, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo", TipoComprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_agencia", AgenciaOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_agencia_destino", AgenciaDestino, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("co_cur_documentos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function valida_guiatransportista_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_VERIFICA_GUIATRANSPORTISTA", 6, _
    '                                                               StSerie, 2, _
    '                                                               StNroGuia, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function valida_guiatransportista() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_VERIFICA_GUIATRANSPORTISTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iSERIE_GUIA_TRANSPORTISTA", StNroGuia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNRO_GUIA_TRANSPORTISTA", StNroGuia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_guiatransportista", OracleClient.OracleType.Cursor)
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
    'Public Function fn_sp_recupera_destino_bus_2009() As ADODB.Recordset
    '    Dim ls_nrosalida As String
    '    '
    '    If Stinrosalida = -666 Then
    '        ls_nrosalida = "null"
    '    Else
    '        ls_nrosalida = CType(Stinrosalida, String)
    '    End If
    '    '
    '    'Recupera los destinos por donde va a pasar el bus 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_recupera_destino_bus", 4, _
    '                                                               ls_nrosalida, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    'Public Function fn_sp_recupera_nrosalida_2009() As ADODB.Recordset
    '    'Recupera los al momento de editar 
    '    Dim ls_nro_salida As String
    '    If Stinrosalida = -666 Then
    '        ls_nro_salida = "null"
    '    Else
    '        ls_nro_salida = CType(Stinrosalida, String)
    '    End If

    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.sp_get_nrosalida_guiatrans", 4, _
    '                                                               ls_nro_salida, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_sp_recupera_nrosalida() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.sp_get_nrosalida_guiatrans", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidnro_salida", Stinrosalida, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_bus", OracleClient.OracleType.Cursor)
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
    'Public Function fn_sp_recupera_detalle_blanco_2009() As ADODB.Recordset
    '    'Recupera cada vez q' cambia se reseta 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.sp_recupera_det_blanco", 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_sp_recupera_detalle_blanco() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.sp_recupera_det_blanco", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_detalle", OracleClient.OracleType.Cursor)
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
    'Public Function fn_sp_verifica_estado_bus_2009() As ADODB.Recordset
    '    Dim ls_nro_salida As String
    '    If Stinrosalida = -666 Then
    '        ls_nro_salida = "null"
    '    Else
    '        ls_nro_salida = CType(Stinrosalida, String)
    '    End If
    '    'Verifica el estado del bus
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.sp_verifica_busdespacho", 4, ls_nro_salida, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    'Public Function fnIncrementarNroDoc_2009(ByVal idTipoComprobante As Integer) As ADODB.Recordset

    '    Dim SQLQuery As Object() = {"sp_INCREMENTAR_NRO_DOCUMENTO", 8, _
    '                                                dtoUSUARIOS.IP, 2, _
    '                                                dtoUSUARIOS.m_iIdAgencia, 1, _
    '                                                idTipoComprobante, 1}
    '    objLOG.fnLog("[sp_INCREMENTAR_NRO_DOCUMENTO] " & fnLoagObj(SQLQuery))
    '    Return VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'End Function
    Public Function fnIncrementarNroDoc(ByVal idTipoComprobante As Integer) As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDAGENCIAS", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPO_COMPROBANTE", idTipoComprobante, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
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
    Public Function fnNroDocumento(ByVal idTipoComprobante As Integer) As DataTable
        Dim ldt_tmp As DataTable
        Try
            Dim ls_sql As String
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_GENERICO.sp_get_comprobante", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_comprobante", idTipoComprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencias", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            '
        End Try
    End Function
    'Public Function fnanulaguiatransportista_2009() As ADODB.Recordset
    '    'Dim SQLQuery As Object() = {"", 18, _
    '    '                                            CType(StId, String), 2, _
    '    '                                            StIP, 2, _
    '    '                                            StRol, 1, _
    '    '                                            StUsuario, 1, _
    '    '                                            StCiuOri, 1, _
    '    '                                            StCiuDes, 1, _
    '    '                                            StFecIni, 2, _
    '    '                                            StFecFin, 2}
    '    Dim SQLQuery As Object() = {"PKG_IVOITINERARIOS.sp_anula_guia_trans1", 18, _
    '                                                CType(StId, String), 2, _
    '                                                StIP, 2, _
    '                                                StRol, 1, _
    '                                                StUsuario, 1, _
    '                                                StCiuOri, 1, _
    '                                                StCiuDes, 1, _
    '                                                StFecIni, 2, _
    '                                                StFecFin, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'End Function
    Public Function fnanulaguiatransportista() As DataTable
        Dim ldt_tmp As DataTable
        Try
            Dim ls_sql As String
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOITINERARIOS.sp_anula_guia_trans1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("viidnro_guia_trans", CType(StId, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iipmod", StIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidrol_usuariomod", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidusuario_personalmod", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StCiuOri, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", StCiuDes, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iFECHA_INI", StFecIni, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFECHA_FIN", StFecFin, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_origen", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            '
        End Try
    End Function
    'Public Function fn_act_guia_trans_agencia_destino_2009() As ADODB.Recordset
    '    Dim SQLQuery As Object() = {"PKG_IVOITINERARIOS.sp_act_guiatrans_agen_destino", 12, _
    '                                                Stidguia, 2, _
    '                                                lidagencia_destino, 1, _
    '                                                StChofer, 1, _
    '                                                StIP, 2, _
    '                                                StUsuario, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'End Function
    Public Function fn_act_guia_trans_agencia_destino() As DataTable
        '
        Dim ldt_tmp As DataTable
        Try
            Dim ls_sql As String
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOITINERARIOS.sp_act_guiatrans_agen_destino", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idguia_transportista", Stidguia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_destino", lidagencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idpiloto", StChofer, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", StIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_personal", StUsuario, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
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
    'Public Function BuscaItinerario_2_2009() As ADODB.Recordset
    '    'Stinrosalida, 1,
    '    '04/12/2007 - Modificado 
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_BUSCA_ITINERARIOS_2", 10, StCiuOri, 1, StCiuDes, 1, StIATA, 2, StIATADes, 2 }
    '    '11/08/2009 - Modificado 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_BUSCA_ITINERARIOS_3", 12, StCiuOri, 1, StCiuDes, 1, StIATA, 2, StIATADes, 2, lidagencia, 1}
    '    '        
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function BuscaItinerario_2(Optional ByVal salida As Integer = 0) As DataSet
        Dim lds_tmp As DataSet
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_BUSCA_ITINERARIOS_5", CommandType.StoredProcedure)
            'db_bd.CrearComando("PKG_IVOITINERARIOS.SP_BUSCA_ITINERARIOS_4", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StCiuOri, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", StCiuDes, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCODIGO_IATA_ORIGEN", StIATA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCODIGO_IATA_DESTINO", StIATADes, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("n_idagencia_origen", lidagencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_ca", intCa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_Fecha_partida", strFechaPartida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_hora_partida", strHoraPartida, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_salida", salida, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_itinera", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_documentos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_hora_salida", OracleClient.OracleType.Cursor)
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
    'Public Function fn_act_gt_serie_y_nro_2009() As ADODB.Recordset
    '    'Stinrosalida, 1,
    '    '04/12/2007 - Modificado 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.sp_actualiza_gt_serie_nro", 12, sid_guia_trans, 2, StSerie, 2, StNroGuia, 2, StBus_old, 1, StBus_act, 1}
    '    '        
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_act_gt_serie_y_nro() As DataTable
        Dim ldt_tmp As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOITINERARIOS.sp_actualiza_gt_serie_nro", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idguia_transportista", sid_guia_trans, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_serie_guia", StSerie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_nro_guia", StNroGuia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_nro_bus_ant", StBus_old, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_nro_bus_act", StBus_act, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)

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

    Public Function Guia_Transportista(ByVal id As Integer) As DataTable
        Dim ldt_tmp As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.SP_GUIA_TRANSPORTISTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDGUIA_TRANSPORTISTA", id, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_guias_transportista", OracleClient.OracleType.Cursor)

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

    Public Function Manifiesto(ByVal id As Integer) As DataTable
        Dim ldt_tmp As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.SP_GUIA_TRANSPORTISTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDGUIA_TRANSPORTISTA", id, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_guias_transportista", OracleClient.OracleType.Cursor)

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

    Public Sub GuiaTransportistaImpresa(id As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_REP_GUIAS_ENVIO.sp_guia_transportista_impresa", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function ListarGrt(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOITINERARIOS.sp_listar_grt", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarComprobante(ByVal tipo As Integer, ByVal id As Integer, Optional ByVal opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOITINERARIOS.sp_listar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Public Function fn_sp_recupera_destino_bus(Optional ByVal opcion As Integer = 0) As DataTable
        Try

            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_recupera_destino_bus", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iidnro_salida", Stinrosalida, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_destinos", OracleClient.OracleType.Cursor)
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

End Class
