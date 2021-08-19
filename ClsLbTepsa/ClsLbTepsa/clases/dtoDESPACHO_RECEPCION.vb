Imports AccesoDatos
Public Class dtoDESPACHO_RECEPCION
    Dim MyIDPERSONA As Long
    Dim MyIDCOMPROBANTE As Long
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyIDAGENCIAS As Long
    Dim MyFECHA_INI As String
    Dim MyFECHA_FINAL As String
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Long
    Dim MyHORA_SALIDA As String
    Dim MyRUC_TERCERO As String
    Dim MyNRO_LICENCIA As String
    Dim MyPLACA_BUS As String
    Dim MyNRO_TELEVISORES As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyMARCA_BUS As String
    Dim MyNOMBRE_UNIDAD As String
    Dim MyIDDEPARTAMENTO As Long
    Dim MyPESO_VEHICULO_TONELADAS As Double
    Dim MyNRO_BANIOS As Long
    Dim MyDESTINO As String
    Dim MyHORAS_VIAJE As String
    Dim MyMARGEN_ERROR_HORAS As Double
    Dim MyIDRUTA_HORARIO As Long
    Dim MyHORA As String
    Dim MyUSUARIO_CHOFER As Long
    Dim MyIDRUTAVR As Double
    Dim MyHORAS_DE_VIAJE As String
    Dim MyIDRUTAS As Long
    Dim MyIPMOD As String
    Dim MyFECHA_REGISTRO As String
    Dim MyNOM_TERCERO As String
    Dim MyCODIGO_IATA As String
    Dim MyNRO_EJES As Long
    Dim MyHORASVIAJE As Double
    Dim MyNROKILOMETROS As Double
    Dim MyIDNRO_SALIDA As Long
    Dim MyESTADO As String
    Dim MyFECHA_LLEGADA As String
    Dim MyPLACA As String
    Dim MyIDRESPONSABLE As Long
    Dim MyCERTIFICA_HABILITA_VEH As String
    Dim MyCAPACIDAD As Long
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIP As String
    Dim MyFECHA_SALIDA As String
    Dim MyIDUNIDAD_AGENCIA_ORIGEN As Long
    Dim MyTIPO_SERVICIO As String
    Dim MyIDPROVINCIA As Long
    Dim MyIDPAIS As Long
    Dim MyIDMODELO_UNIDAD As Long
    Dim MyNOMBRE_RUTA As String
    Dim MyDIAS_VIAJE As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyNRO_SALIDA As Long
    Dim MyIDUNIDAD_TRANSPORTE As Long
    Dim MyIDDISTRITO As Long
    Dim MyIDTIPO_UNIDAD_TRANSPORTE As Long
    Dim MyNRO_PISOS As Long
    Dim MyPESO_MAXIMO_CARGA_KG As Double
    Dim MyNOMBRE_UNIDAD_ORI As String
    Dim MyES_VIGENTE As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDTIPO_SERVICIO As Long
    Dim MyNRO_UNIDAD_TRANSPORTE As Long
    Public Property IDPERSONA() As Long

        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property IDCOMPROBANTE() As Long

        Get
            IDCOMPROBANTE = MyIDCOMPROBANTE
        End Get
        Set(ByVal value As Long)
            MyIDCOMPROBANTE = value
        End Set
    End Property
    Public Property IDTIPO_COMPROBANTE() As Long

        Get
            IDTIPO_COMPROBANTE = MyIDTIPO_COMPROBANTE
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_COMPROBANTE = value
        End Set
    End Property
    Public Property IDAGENCIAS() As Long

        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = value
        End Set
    End Property
    Public Property FECHA_INI() As String

        Get
            FECHA_INI = MyFECHA_INI
        End Get
        Set(ByVal value As String)
            MyFECHA_INI = value
        End Set
    End Property
    Public Property FECHA_FINAL() As String

        Get
            FECHA_FINAL = MyFECHA_FINAL
        End Get
        Set(ByVal value As String)
            MyFECHA_FINAL = value
        End Set
    End Property
    Public Property NOMBRE_UNIDAD_ORI() As String

        Get
            NOMBRE_UNIDAD_ORI = MyNOMBRE_UNIDAD_ORI
        End Get
        Set(ByVal value As String)
            MyNOMBRE_UNIDAD_ORI = value
        End Set
    End Property
    Public Property DESTINO() As String

        Get
            DESTINO = MyDESTINO
        End Get
        Set(ByVal value As String)
            MyDESTINO = value
        End Set
    End Property

    Public Property PLACA_BUS() As String

        Get
            PLACA_BUS = MyPLACA_BUS
        End Get
        Set(ByVal value As String)
            MyPLACA_BUS = value
        End Set
    End Property
    Public Property TIPO_SERVICIO() As String

        Get
            TIPO_SERVICIO = MyTIPO_SERVICIO
        End Get
        Set(ByVal value As String)
            MyTIPO_SERVICIO = value
        End Set
    End Property
    Public Property CODIGO_IATA() As String

        Get
            CODIGO_IATA = MyCODIGO_IATA
        End Get
        Set(ByVal value As String)
            MyCODIGO_IATA = value
        End Set
    End Property
    Public Property NRO_PISOS() As Long

        Get
            NRO_PISOS = MyNRO_PISOS
        End Get
        Set(ByVal value As Long)
            MyNRO_PISOS = value
        End Set
    End Property
    Public Property NRO_BANIOS() As Long

        Get
            NRO_BANIOS = MyNRO_BANIOS
        End Get
        Set(ByVal value As Long)
            MyNRO_BANIOS = value
        End Set
    End Property
    Public Property NOMBRE_RUTA() As String

        Get
            NOMBRE_RUTA = MyNOMBRE_RUTA
        End Get
        Set(ByVal value As String)
            MyNOMBRE_RUTA = value
        End Set
    End Property
    Public Property MARGEN_ERROR_HORAS() As Double

        Get
            MARGEN_ERROR_HORAS = MyMARGEN_ERROR_HORAS
        End Get
        Set(ByVal value As Double)
            MyMARGEN_ERROR_HORAS = value
        End Set
    End Property
    Public Property IDNRO_SALIDA() As Long

        Get
            IDNRO_SALIDA = MyIDNRO_SALIDA
        End Get
        Set(ByVal value As Long)
            MyIDNRO_SALIDA = value
        End Set
    End Property
    Public Property FECHA_LLEGADA() As String

        Get
            FECHA_LLEGADA = MyFECHA_LLEGADA
        End Get
        Set(ByVal value As String)
            MyFECHA_LLEGADA = value
        End Set
    End Property
    Public Property HORA() As String

        Get
            HORA = MyHORA
        End Get
        Set(ByVal value As String)
            MyHORA = value
        End Set
    End Property
    Public Property FECHA_SALIDA() As String

        Get
            FECHA_SALIDA = MyFECHA_SALIDA
        End Get
        Set(ByVal value As String)
            MyFECHA_SALIDA = value
        End Set
    End Property
    Public Property IDTIPO_SERVICIO() As Long

        Get
            IDTIPO_SERVICIO = MyIDTIPO_SERVICIO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_SERVICIO = value
        End Set
    End Property
    Public Property NOM_TERCERO() As String

        Get
            NOM_TERCERO = MyNOM_TERCERO
        End Get
        Set(ByVal value As String)
            MyNOM_TERCERO = value
        End Set
    End Property
    Public Property RUC_TERCERO() As String

        Get
            RUC_TERCERO = MyRUC_TERCERO
        End Get
        Set(ByVal value As String)
            MyRUC_TERCERO = value
        End Set
    End Property
    Public Property NOMBRE_UNIDAD() As String

        Get
            NOMBRE_UNIDAD = MyNOMBRE_UNIDAD
        End Get
        Set(ByVal value As String)
            MyNOMBRE_UNIDAD = value
        End Set
    End Property
    Public Property NRO_EJES() As Long

        Get
            NRO_EJES = MyNRO_EJES
        End Get
        Set(ByVal value As Long)
            MyNRO_EJES = value
        End Set
    End Property
    Public Property IDMODELO_UNIDAD() As Long

        Get
            IDMODELO_UNIDAD = MyIDMODELO_UNIDAD
        End Get
        Set(ByVal value As Long)
            MyIDMODELO_UNIDAD = value
        End Set
    End Property
    Public Property ES_VIGENTE() As Long

        Get
            ES_VIGENTE = MyES_VIGENTE
        End Get
        Set(ByVal value As Long)
            MyES_VIGENTE = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA_DESTINO() As Long

        Get
            IDUNIDAD_AGENCIA_DESTINO = MyIDUNIDAD_AGENCIA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA_DESTINO = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Long

        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIO = value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Long

        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIOMOD = value
        End Set
    End Property

    Public Property NRO_SALIDA() As Long

        Get
            NRO_SALIDA = MyNRO_SALIDA
        End Get
        Set(ByVal value As Long)
            MyNRO_SALIDA = value
        End Set
    End Property
    Public Property IDRESPONSABLE() As Long

        Get
            IDRESPONSABLE = MyIDRESPONSABLE
        End Get
        Set(ByVal value As Long)
            MyIDRESPONSABLE = value
        End Set
    End Property
    Public Property IDTIPO_UNIDAD_TRANSPORTE() As Long

        Get
            IDTIPO_UNIDAD_TRANSPORTE = MyIDTIPO_UNIDAD_TRANSPORTE
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_UNIDAD_TRANSPORTE = value
        End Set
    End Property
    Public Property NROKILOMETROS() As Double

        Get
            NROKILOMETROS = MyNROKILOMETROS
        End Get
        Set(ByVal value As Double)
            MyNROKILOMETROS = value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Long

        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Long

        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONALMOD = value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String

        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property PLACA() As String

        Get
            PLACA = MyPLACA
        End Get
        Set(ByVal value As String)
            MyPLACA = value
        End Set
    End Property
    Public Property PESO_MAXIMO_CARGA_KG() As Double

        Get
            PESO_MAXIMO_CARGA_KG = MyPESO_MAXIMO_CARGA_KG
        End Get
        Set(ByVal value As Double)
            MyPESO_MAXIMO_CARGA_KG = value
        End Set
    End Property
    Public Property HORAS_DE_VIAJE() As String

        Get
            HORAS_DE_VIAJE = MyHORAS_DE_VIAJE
        End Get
        Set(ByVal value As String)
            MyHORAS_DE_VIAJE = value
        End Set
    End Property
    Public Property HORASVIAJE() As Double

        Get
            HORASVIAJE = MyHORASVIAJE
        End Get
        Set(ByVal value As Double)
            MyHORASVIAJE = value
        End Set
    End Property
    Public Property DIAS_VIAJE() As Long

        Get
            DIAS_VIAJE = MyDIAS_VIAJE
        End Get
        Set(ByVal value As Long)
            MyDIAS_VIAJE = value
        End Set
    End Property
    Public Property IDRUTA_HORARIO() As Long

        Get
            IDRUTA_HORARIO = MyIDRUTA_HORARIO
        End Get
        Set(ByVal value As Long)
            MyIDRUTA_HORARIO = value
        End Set
    End Property
    Public Property IDUNIDAD_TRANSPORTE() As Long

        Get
            IDUNIDAD_TRANSPORTE = MyIDUNIDAD_TRANSPORTE
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_TRANSPORTE = value
        End Set
    End Property
    Public Property USUARIO_CHOFER() As Long

        Get
            USUARIO_CHOFER = MyUSUARIO_CHOFER
        End Get
        Set(ByVal value As Long)
            MyUSUARIO_CHOFER = value
        End Set
    End Property
    Public Property IDDISTRITO() As Long

        Get
            IDDISTRITO = MyIDDISTRITO
        End Get
        Set(ByVal value As Long)
            MyIDDISTRITO = value
        End Set
    End Property
    Public Property NRO_TELEVISORES() As Long

        Get
            NRO_TELEVISORES = MyNRO_TELEVISORES
        End Get
        Set(ByVal value As Long)
            MyNRO_TELEVISORES = value
        End Set
    End Property
    Public Property CERTIFICA_HABILITA_VEH() As String

        Get
            CERTIFICA_HABILITA_VEH = MyCERTIFICA_HABILITA_VEH
        End Get
        Set(ByVal value As String)
            MyCERTIFICA_HABILITA_VEH = value
        End Set
    End Property
    Public Property CAPACIDAD() As Long

        Get
            CAPACIDAD = MyCAPACIDAD
        End Get
        Set(ByVal value As Long)
            MyCAPACIDAD = value
        End Set
    End Property
    Public Property IDRUTAVR() As Double

        Get
            IDRUTAVR = MyIDRUTAVR
        End Get
        Set(ByVal value As Double)
            MyIDRUTAVR = value
        End Set
    End Property
    Public Property IDRUTAS() As Long

        Get
            IDRUTAS = MyIDRUTAS
        End Get
        Set(ByVal value As Long)
            MyIDRUTAS = value
        End Set
    End Property
    Public Property HORAS_VIAJE() As String

        Get
            HORAS_VIAJE = MyHORAS_VIAJE
        End Get
        Set(ByVal value As String)
            MyHORAS_VIAJE = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA() As Long

        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Long

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IPMOD() As String

        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
        End Set
    End Property
    Public Property FECHA_ACTUALIZACION() As String

        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = value
        End Set
    End Property
    Public Property HORA_SALIDA() As String

        Get
            HORA_SALIDA = MyHORA_SALIDA
        End Get
        Set(ByVal value As String)
            MyHORA_SALIDA = value
        End Set
    End Property
    Public Property IDPROVINCIA() As Long

        Get
            IDPROVINCIA = MyIDPROVINCIA
        End Get
        Set(ByVal value As Long)
            MyIDPROVINCIA = value
        End Set
    End Property
    Public Property IDDEPARTAMENTO() As Long

        Get
            IDDEPARTAMENTO = MyIDDEPARTAMENTO
        End Get
        Set(ByVal value As Long)
            MyIDDEPARTAMENTO = value
        End Set
    End Property
    Public Property IP() As String

        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA_ORIGEN() As Long

        Get
            IDUNIDAD_AGENCIA_ORIGEN = MyIDUNIDAD_AGENCIA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA_ORIGEN = value
        End Set
    End Property
    Public Property NRO_LICENCIA() As String

        Get
            NRO_LICENCIA = MyNRO_LICENCIA
        End Get
        Set(ByVal value As String)
            MyNRO_LICENCIA = value
        End Set
    End Property
    Public Property MARCA_BUS() As String

        Get
            MARCA_BUS = MyMARCA_BUS
        End Get
        Set(ByVal value As String)
            MyMARCA_BUS = value
        End Set
    End Property
    Public Property ESTADO() As String

        Get
            ESTADO = MyESTADO
        End Get
        Set(ByVal value As String)
            MyESTADO = value
        End Set
    End Property
    Public Property IDPAIS() As Long

        Get
            IDPAIS = MyIDPAIS
        End Get
        Set(ByVal value As Long)
            MyIDPAIS = value
        End Set
    End Property
    Public Property NRO_UNIDAD_TRANSPORTE() As Long

        Get
            NRO_UNIDAD_TRANSPORTE = MyNRO_UNIDAD_TRANSPORTE
        End Get
        Set(ByVal value As Long)
            MyNRO_UNIDAD_TRANSPORTE = value
        End Set
    End Property
    Public Property PESO_VEHICULO_TONELADAS() As Double

        Get
            PESO_VEHICULO_TONELADAS = MyPESO_VEHICULO_TONELADAS
        End Get
        Set(ByVal value As Double)
            MyPESO_VEHICULO_TONELADAS = value
        End Set
    End Property
    'Public Function SP_L_V_L_SALIDA_VEHICULO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '        '    cmd.Connection = cnn
    '        '    cmd.CommandType = CommandType.StoredProcedure
    '        '    cmd.CommandText = "pkg_ivodespacho_recepcion.SP_L_V_L_SALIDA_VEHICULO"
    '        '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA
    '        '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA_DESTINO
    '        '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_UNIDAD_TRANSPORTE", OracleClient.OracleType.Number)).Value = NRO_UNIDAD_TRANSPORTE
    '        '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_L_V_L_SALIDA_VEHICULO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '    Dim ds As New DataSet
    '        '    daora.Fill(ds)
    '        '    Dim dv As New DataView
    '        '    dv = ds.Tables(0).DefaultView
    '        '    Return dv
    '        'Catch
    '        '    Throw
    '        'End Try
    '        '
    '        ' Modificado 21/05/2008 - Rgomez 
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivodespacho_recepcion.SP_L_V_L_SALIDA_VEHICULO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_UNIDAD_TRANSPORTE", OracleClient.OracleType.Number)).Value = NRO_UNIDAD_TRANSPORTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_L_V_L_SALIDA_VEHICULO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_L_V_L_SALIDA_VEHICULO() As DataView       
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivodespacho_recepcion.SP_L_V_L_SALIDA_VEHICULO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA", IDUNIDAD_AGENCIA, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_NRO_UNIDAD_TRANSPORTE", NRO_UNIDAD_TRANSPORTE, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_L_V_L_SALIDA_VEHICULO", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_L_V_L_DESPACHOS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    'Try
    '    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    '    cmd.Connection = cnn
    '    '    cmd.CommandType = CommandType.StoredProcedure
    '    '    cmd.CommandText = "PKG_IVODESPACHO_RECEPCION.SP_L_V_L_DESPACHOS"
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA_DESTI", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA_DESTINO
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_V_L_DESPACHOS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '    Dim ds As New DataSet
    '    '    daora.Fill(ds)
    '    '    Dim dv As New DataView
    '    '    dv = ds.Tables(0).DefaultView
    '    '    Return dv
    '    'Catch
    '    '    Throw
    '    'End Try
    '    '
    '    ' Modificado 21/05/2008 - Rgomez 
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVODESPACHO_RECEPCION.SP_L_V_L_DESPACHOS"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDNRO_SALIDA", OracleClient.OracleType.Number)).Value = NRO_SALIDA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA_DESTI", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_V_L_DESPACHOS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_L_V_L_DESPACHOS() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.SP_L_V_L_DESPACHOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDNRO_SALIDA", NRO_SALIDA, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTI", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_V_L_DESPACHOS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_L_V_L_DESPACHOS_PERSO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVODESPACHO_RECEPCION.SP_L_V_L_DESPACHOS_PERSO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_V_L_DESPACHOS_PERSO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_L_V_L_DESPACHOS_PERSO() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 01-06-2014
            'db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.SP_L_V_L_DESPACHOS_PERSO", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.SP_L_V_L_DESPACHOS_PERSO_CAR", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_V_L_DESPACHOS_PERSO", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_L_V_L_BULTOS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivodespacho_recepcion.SP_L_V_L_BULTOS"

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCOMPROBANTE", OracleClient.OracleType.Number)).Value = IDCOMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_V_L_BULTOS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_L_V_L_BULTOS() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivodespacho_recepcion.SP_L_V_L_BULTOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDCOMPROBANTE", IDCOMPROBANTE, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_V_L_BULTOS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_con_x_recep_vista_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_rep_general.sp_con_x_recep_vista"

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_inicio", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("niciudad_origen", OracleClient.OracleType.Number)).Value = Me.IDUNIDAD_AGENCIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("nciudad_destino", OracleClient.OracleType.Number)).Value = Me.IDUNIDAD_AGENCIA_DESTINO


    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_seguimiento", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function sp_con_x_recep_vista() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_rep_general.sp_con_x_recep_vista", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vfecha_inicio", FECHA_INI, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("niciudad_origen", Me.IDUNIDAD_AGENCIA, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("nciudad_destino", Me.IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_seguimiento", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_con_x_entre_domi_vista_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_rep_general.sp_con_x_entre_domi_vista"

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_inicio", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("niciudad_origen", OracleClient.OracleType.Number)).Value = Me.IDUNIDAD_AGENCIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("nciudad_destino", OracleClient.OracleType.Number)).Value = Me.IDUNIDAD_AGENCIA_DESTINO


    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_seguimiento", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function sp_con_x_entre_domi_vista() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_rep_general.sp_con_x_entre_domi_vista", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vfecha_inicio", FECHA_INI, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("niciudad_origen", Me.IDUNIDAD_AGENCIA, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("nciudad_destino", Me.IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_seguimiento", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LISTA_COMPARA_SALIDAS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVODESPACHO_RECEPCION.SP_LISTA_COMPARA_SALIDAS"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTA_COMPARA_SALIDAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_LISTA_COMPARA_SALIDAS() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVODESPACHO_RECEPCION.SP_LISTA_COMPARA_SALIDAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_LISTA_COMPARA_SALIDAS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
