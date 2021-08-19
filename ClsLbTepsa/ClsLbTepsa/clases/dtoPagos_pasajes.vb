Imports AccesoDatos
Public Class dtoPagos_pasajes
    Dim MyFECHA_INI As String
    Dim MyFECHA_FINAL As String
    Dim MyIDCABE_PAGOS_PASAJES As Long
    Dim MyIDVENTA_PASAJES_STRING As String
    Dim MyIDROL As Long
    Dim MyIDROL_MOD As Long
    Dim MyACU As Double
    Dim MyCALCU_COMI As Long
    Dim MyCALCU_COMI_FUNCI As Long
    Dim MyCANTIDAD As Long
    Dim MyCODIGO_CUENTA As String
    Dim MyDATOS_PERSONALES As String
    Dim MyEDAD As Long
    Dim MyES_FECHA_ABIERTA As Long
    Dim MyES_RESERVA As Long
    Dim MyFECHA As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyFECHA_BLOQUEO As String
    Dim MyFECHA_EMISION As String
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_VIAJE As String
    Dim MyHORA_EMISION As String
    Dim MyHORA_SALIDA As String
    Dim MyIDAGENCIAS As Long
    Dim MyIDAGENCIA_DESTINO As Long
    Dim MyIDAGENCIA_ORIGEN As Long
    Dim MyIDAGENCIA_VENTA As Long
    Dim MyIDCLASE As Double
    Dim MyIDCONDICION_BOLETO As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDESTA_PAGO_PASA As String
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDIGV As Long
    Dim MyIDPAGOS_PASAJES As Long
    Dim MyIDPERSONA As Long
    Dim MyIDPERSONA_CUENTA As String
    Dim MyIDPERSONA_EMPRESA As Long
    Dim MyIDPUNTO_EMBARQUE As Long
    Dim MyIDRUTAS_ITINERARIO As Long
    Dim MyIDTARJETAS As Long
    Dim MyIDTIPOS_PAGOS_CREDI As String
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyIDTIPO_MONEDA As Long
    Dim MyIDTIPO_OPERACION As Long
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Long
    Dim MyIDUNIDAD_AGENCIA_ORIGEN As Long
    Dim MyIDUNIDAD_TRANSPORTE As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDUSUARIO_PERSONAL_MOD As Long
    Dim MyIDVENTAS_PASAJES_REF As Long
    Dim MyIDVENTA_PASAJES As Long
    Dim MyIGV As Double
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyMEMO As String
    Dim MyMONTO As Double
    Dim MyMONTO_BASE As Double
    Dim MyMONTO_DESCUENTO As Long
    Dim MyMONTO_IMPUESTO As Double
    Dim MyMONTO_PENALIDAD As Double
    Dim MyMONTO_RECARGO As Double
    Dim MyMONTO_RECUPERADO As Long
    Dim MyMONTO_TOTAL As Double
    Dim MyNRO_ASIENTO As Long
    Dim MyNRO_COMPROBANTE As String
    Dim MyNRO_COMPROBANTE_REF As Long
    Dim MyOPERACION As String
    Dim MyPESO As Double
    Dim MyPORCENT_DEVOLUCION As Double
    Dim MyPORC_DESCUENTO As Double
    Dim MySERIE_COMPROBANTE As String
    Dim MySERIE_COMPROBANTE_REF As Long
    Dim MyTIPO_CAMBI As Double
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
    Public Property IDCABE_PAGOS_PASAJES() As Long

        Get
            IDCABE_PAGOS_PASAJES = MyIDCABE_PAGOS_PASAJES
        End Get
        Set(ByVal value As Long)
            MyIDCABE_PAGOS_PASAJES = value
        End Set
    End Property
    Public Property IDVENTA_PASAJES_STRING() As String

        Get
            IDVENTA_PASAJES_STRING = MyIDVENTA_PASAJES_STRING
        End Get
        Set(ByVal value As String)
            MyIDVENTA_PASAJES_STRING = value
        End Set
    End Property
    Public Property IDROL() As Long

        Get
            IDROL = MyIDROL
        End Get
        Set(ByVal value As Long)
            MyIDROL = value
        End Set
    End Property
    Public Property IDROL_MOD() As Long

        Get
            IDROL_MOD = MyIDROL_MOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_MOD = value
        End Set
    End Property
    Public Property ACU() As Double

        Get
            ACU = MyACU
        End Get
        Set(ByVal value As Double)
            MyACU = value
        End Set
    End Property
    Public Property CALCU_COMI() As Long

        Get
            CALCU_COMI = MyCALCU_COMI
        End Get
        Set(ByVal value As Long)
            MyCALCU_COMI = value
        End Set
    End Property
    Public Property CALCU_COMI_FUNCI() As Long

        Get
            CALCU_COMI_FUNCI = MyCALCU_COMI_FUNCI
        End Get
        Set(ByVal value As Long)
            MyCALCU_COMI_FUNCI = value
        End Set
    End Property
    Public Property CANTIDAD() As Long

        Get
            CANTIDAD = MyCANTIDAD
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD = value
        End Set
    End Property
    Public Property CODIGO_CUENTA() As String

        Get
            CODIGO_CUENTA = MyCODIGO_CUENTA
        End Get
        Set(ByVal value As String)
            MyCODIGO_CUENTA = value
        End Set
    End Property
    Public Property DATOS_PERSONALES() As String

        Get
            DATOS_PERSONALES = MyDATOS_PERSONALES
        End Get
        Set(ByVal value As String)
            MyDATOS_PERSONALES = value
        End Set
    End Property
    Public Property EDAD() As Long

        Get
            EDAD = MyEDAD
        End Get
        Set(ByVal value As Long)
            MyEDAD = value
        End Set
    End Property
    Public Property ES_FECHA_ABIERTA() As Long

        Get
            ES_FECHA_ABIERTA = MyES_FECHA_ABIERTA
        End Get
        Set(ByVal value As Long)
            MyES_FECHA_ABIERTA = value
        End Set
    End Property
    Public Property ES_RESERVA() As Long

        Get
            ES_RESERVA = MyES_RESERVA
        End Get
        Set(ByVal value As Long)
            MyES_RESERVA = value
        End Set
    End Property
    Public Property FECHA() As String

        Get
            FECHA = MyFECHA
        End Get
        Set(ByVal value As String)
            MyFECHA = value
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
    Public Property FECHA_BLOQUEO() As String

        Get
            FECHA_BLOQUEO = MyFECHA_BLOQUEO
        End Get
        Set(ByVal value As String)
            MyFECHA_BLOQUEO = value
        End Set
    End Property
    Public Property FECHA_EMISION() As String

        Get
            FECHA_EMISION = MyFECHA_EMISION
        End Get
        Set(ByVal value As String)
            MyFECHA_EMISION = value
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
    Public Property FECHA_VIAJE() As String

        Get
            FECHA_VIAJE = MyFECHA_VIAJE
        End Get
        Set(ByVal value As String)
            MyFECHA_VIAJE = value
        End Set
    End Property
    Public Property HORA_EMISION() As String

        Get
            HORA_EMISION = MyHORA_EMISION
        End Get
        Set(ByVal value As String)
            MyHORA_EMISION = value
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
    Public Property IDAGENCIAS() As Long

        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = value
        End Set
    End Property
    Public Property IDAGENCIA_DESTINO() As Long

        Get
            IDAGENCIA_DESTINO = MyIDAGENCIA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIA_DESTINO = value
        End Set
    End Property
    Public Property IDAGENCIA_ORIGEN() As Long

        Get
            IDAGENCIA_ORIGEN = MyIDAGENCIA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIA_ORIGEN = value
        End Set
    End Property
    Public Property IDAGENCIA_VENTA() As Long

        Get
            IDAGENCIA_VENTA = MyIDAGENCIA_VENTA
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIA_VENTA = value
        End Set
    End Property
    Public Property IDCLASE() As Double

        Get
            IDCLASE = MyIDCLASE
        End Get
        Set(ByVal value As Double)
            MyIDCLASE = value
        End Set
    End Property
    Public Property IDCONDICION_BOLETO() As Long

        Get
            IDCONDICION_BOLETO = MyIDCONDICION_BOLETO
        End Get
        Set(ByVal value As Long)
            MyIDCONDICION_BOLETO = value
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
    Public Property IDESTA_PAGO_PASA() As String

        Get
            IDESTA_PAGO_PASA = MyIDESTA_PAGO_PASA
        End Get
        Set(ByVal value As String)
            MyIDESTA_PAGO_PASA = value
        End Set
    End Property
    Public Property IDFORMA_PAGO() As Long

        Get
            IDFORMA_PAGO = MyIDFORMA_PAGO
        End Get
        Set(ByVal value As Long)
            MyIDFORMA_PAGO = value
        End Set
    End Property
    Public Property IDIGV() As Long

        Get
            IDIGV = MyIDIGV
        End Get
        Set(ByVal value As Long)
            MyIDIGV = value
        End Set
    End Property
    Public Property IDPAGOS_PASAJES() As Long

        Get
            IDPAGOS_PASAJES = MyIDPAGOS_PASAJES
        End Get
        Set(ByVal value As Long)
            MyIDPAGOS_PASAJES = value
        End Set
    End Property
    Public Property IDPERSONA() As Long

        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property IDPERSONA_CUENTA() As String

        Get
            IDPERSONA_CUENTA = MyIDPERSONA_CUENTA
        End Get
        Set(ByVal value As String)
            MyIDPERSONA_CUENTA = value
        End Set
    End Property
    Public Property IDPERSONA_EMPRESA() As Long

        Get
            IDPERSONA_EMPRESA = MyIDPERSONA_EMPRESA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA_EMPRESA = value
        End Set
    End Property
    Public Property IDPUNTO_EMBARQUE() As Long

        Get
            IDPUNTO_EMBARQUE = MyIDPUNTO_EMBARQUE
        End Get
        Set(ByVal value As Long)
            MyIDPUNTO_EMBARQUE = value
        End Set
    End Property
    Public Property IDRUTAS_ITINERARIO() As Long

        Get
            IDRUTAS_ITINERARIO = MyIDRUTAS_ITINERARIO
        End Get
        Set(ByVal value As Long)
            MyIDRUTAS_ITINERARIO = value
        End Set
    End Property
    Public Property IDTARJETAS() As Long

        Get
            IDTARJETAS = MyIDTARJETAS
        End Get
        Set(ByVal value As Long)
            MyIDTARJETAS = value
        End Set
    End Property
    Public Property IDTIPOS_PAGOS_CREDI() As String

        Get
            IDTIPOS_PAGOS_CREDI = MyIDTIPOS_PAGOS_CREDI
        End Get
        Set(ByVal value As String)
            MyIDTIPOS_PAGOS_CREDI = value
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
    Public Property IDTIPO_MONEDA() As Long

        Get
            IDTIPO_MONEDA = MyIDTIPO_MONEDA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_MONEDA = value
        End Set
    End Property
    Public Property IDTIPO_OPERACION() As Long

        Get
            IDTIPO_OPERACION = MyIDTIPO_OPERACION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_OPERACION = value
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
    Public Property IDUNIDAD_AGENCIA_ORIGEN() As Long

        Get
            IDUNIDAD_AGENCIA_ORIGEN = MyIDUNIDAD_AGENCIA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA_ORIGEN = value
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
    Public Property IDUSUARIO_PERSONAL() As Long

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL_MOD() As Long

        Get
            IDUSUARIO_PERSONAL_MOD = MyIDUSUARIO_PERSONAL_MOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL_MOD = value
        End Set
    End Property
    Public Property IDVENTAS_PASAJES_REF() As Long

        Get
            IDVENTAS_PASAJES_REF = MyIDVENTAS_PASAJES_REF
        End Get
        Set(ByVal value As Long)
            MyIDVENTAS_PASAJES_REF = value
        End Set
    End Property
    Public Property IDVENTA_PASAJES() As Long

        Get
            IDVENTA_PASAJES = MyIDVENTA_PASAJES
        End Get
        Set(ByVal value As Long)
            MyIDVENTA_PASAJES = value
        End Set
    End Property
    Public Property IGV() As Double

        Get
            IGV = MyIGV
        End Get
        Set(ByVal value As Double)
            MyIGV = value
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
    Public Property IPMOD() As String

        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
        End Set
    End Property
    Public Property MEMO() As String

        Get
            MEMO = MyMEMO
        End Get
        Set(ByVal value As String)
            MyMEMO = value
        End Set
    End Property
    Public Property MONTO() As Double

        Get
            MONTO = MyMONTO
        End Get
        Set(ByVal value As Double)
            MyMONTO = value
        End Set
    End Property
    Public Property MONTO_BASE() As Double

        Get
            MONTO_BASE = MyMONTO_BASE
        End Get
        Set(ByVal value As Double)
            MyMONTO_BASE = value
        End Set
    End Property
    Public Property MONTO_DESCUENTO() As Long

        Get
            MONTO_DESCUENTO = MyMONTO_DESCUENTO
        End Get
        Set(ByVal value As Long)
            MyMONTO_DESCUENTO = value
        End Set
    End Property
    Public Property MONTO_IMPUESTO() As Double

        Get
            MONTO_IMPUESTO = MyMONTO_IMPUESTO
        End Get
        Set(ByVal value As Double)
            MyMONTO_IMPUESTO = value
        End Set
    End Property
    Public Property MONTO_PENALIDAD() As Double

        Get
            MONTO_PENALIDAD = MyMONTO_PENALIDAD
        End Get
        Set(ByVal value As Double)
            MyMONTO_PENALIDAD = value
        End Set
    End Property
    Public Property MONTO_RECARGO() As Double

        Get
            MONTO_RECARGO = MyMONTO_RECARGO
        End Get
        Set(ByVal value As Double)
            MyMONTO_RECARGO = value
        End Set
    End Property
    Public Property MONTO_RECUPERADO() As Long

        Get
            MONTO_RECUPERADO = MyMONTO_RECUPERADO
        End Get
        Set(ByVal value As Long)
            MyMONTO_RECUPERADO = value
        End Set
    End Property
    Public Property MONTO_TOTAL() As Double

        Get
            MONTO_TOTAL = MyMONTO_TOTAL
        End Get
        Set(ByVal value As Double)
            MyMONTO_TOTAL = value
        End Set
    End Property
    Public Property NRO_ASIENTO() As Long

        Get
            NRO_ASIENTO = MyNRO_ASIENTO
        End Get
        Set(ByVal value As Long)
            MyNRO_ASIENTO = value
        End Set
    End Property
    Public Property NRO_COMPROBANTE() As String

        Get
            NRO_COMPROBANTE = MyNRO_COMPROBANTE
        End Get
        Set(ByVal value As String)
            MyNRO_COMPROBANTE = value
        End Set
    End Property
    Public Property NRO_COMPROBANTE_REF() As Long

        Get
            NRO_COMPROBANTE_REF = MyNRO_COMPROBANTE_REF
        End Get
        Set(ByVal value As Long)
            MyNRO_COMPROBANTE_REF = value
        End Set
    End Property
    Public Property OPERACION() As String

        Get
            OPERACION = MyOPERACION
        End Get
        Set(ByVal value As String)
            MyOPERACION = value
        End Set
    End Property
    Public Property PESO() As Double

        Get
            PESO = MyPESO
        End Get
        Set(ByVal value As Double)
            MyPESO = value
        End Set
    End Property
    Public Property PORCENT_DEVOLUCION() As Double

        Get
            PORCENT_DEVOLUCION = MyPORCENT_DEVOLUCION
        End Get
        Set(ByVal value As Double)
            MyPORCENT_DEVOLUCION = value
        End Set
    End Property
    Public Property PORC_DESCUENTO() As Double

        Get
            PORC_DESCUENTO = MyPORC_DESCUENTO
        End Get
        Set(ByVal value As Double)
            MyPORC_DESCUENTO = value
        End Set
    End Property
    Public Property SERIE_COMPROBANTE() As String

        Get
            SERIE_COMPROBANTE = MySERIE_COMPROBANTE
        End Get
        Set(ByVal value As String)
            MySERIE_COMPROBANTE = value
        End Set
    End Property
    Public Property SERIE_COMPROBANTE_REF() As Long

        Get
            SERIE_COMPROBANTE_REF = MySERIE_COMPROBANTE_REF
        End Get
        Set(ByVal value As Long)
            MySERIE_COMPROBANTE_REF = value
        End Set
    End Property
    Public Property TIPO_CAMBI() As Double

        Get
            TIPO_CAMBI = MyTIPO_CAMBI
        End Get
        Set(ByVal value As Double)
            MyTIPO_CAMBI = value
        End Set
    End Property
    'Public Sub SP_IN_PASA_CREDI_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try


    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_IN_T_PAGOS_PASAJES"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPAGOS_PASAJES", OracleClient.OracleType.Number)).Value = IDPAGOS_PASAJES
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDVENTA_PASAJES", OracleClient.OracleType.Number)).Value = IDVENTA_PASAJES
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA", OracleClient.OracleType.VarChar)).Value = FECHA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO", OracleClient.OracleType.Number)).Value = MONTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_OPERACION", OracleClient.OracleType.VarChar)).Value = OPERACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TIPO_CAMBI", OracleClient.OracleType.Number)).Value = TIPO_CAMBI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ACTUALIZACION", OracleClient.OracleType.VarChar)).Value = FECHA_ACTUALIZACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IPMOD", OracleClient.OracleType.VarChar)).Value = IPMOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL_MOD", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL", OracleClient.OracleType.Number)).Value = IDROL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_MOD", OracleClient.OracleType.Number)).Value = IDROL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPOS_PAGOS_CREDI", OracleClient.OracleType.VarChar)).Value = IDTIPOS_PAGOS_CREDI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDVENTA_PASAJES_STRING", OracleClient.OracleType.VarChar)).Value = IDVENTA_PASAJES_STRING

    '        cmd.ExecuteNonQuery()

    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_IN_PASA_CREDI()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivopagopasajes.SP_IN_T_PAGOS_PASAJES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDPAGOS_PASAJES", IDPAGOS_PASAJES, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDVENTA_PASAJES", IDVENTA_PASAJES, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_FECHA", FECHA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_MONTO", MONTO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_OPERACION", OPERACION, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_TIPO_CAMBI", TIPO_CAMBI, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_FECHA_REGISTRO", FECHA_REGISTRO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_ACTUALIZACION", FECHA_ACTUALIZACION, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL_MOD", IDUSUARIO_PERSONAL_MOD, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDROL", IDROL, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDROL_MOD", IDROL_MOD, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("P_IDTIPOS_PAGOS_CREDI", IDTIPOS_PAGOS_CREDI, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDVENTA_PASAJES_STRING", IDVENTA_PASAJES_STRING, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Function SP_L_PASA_CREDI_AMOR_2009(ByVal cnn As OracleConnection) As DataView
    '    Dim cmd As New OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivopagopasajes.SP_L_PASA_CREDI_AMOR"
    '    cmd.Parameters.Add(New OracleParameter("P_FECHA_INI", OracleType.VarChar)).Value = FECHA_INI
    '    cmd.Parameters.Add(New OracleParameter("P_FECHA_FINAL", OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleParameter("P_IDTIPOS_PAGOS_CREDI", OracleType.VarChar)).Value = IDTIPOS_PAGOS_CREDI
    '    cmd.Parameters.Add(New OracleParameter("CUR_L_PASA_CREDI_AMOR", OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim DA As New OracleDataAdapter(cmd)
    '    Dim DT As New DataTable
    '    DA.Fill(DT)
    '    Dim dv As New DataView
    '    dv = DT.DefaultView
    '    Return dv
    'End Function
    '
    Public Function SP_L_PASA_CREDI_AMOR() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            db.Conectar()
            db.CrearComando("pkg_ivopagopasajes.SP_L_PASA_CREDI_AMOR", CommandType.StoredProcedure)
            '
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPOS_PAGOS_CREDI", IDTIPOS_PAGOS_CREDI, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("CUR_L_PASA_CREDI_AMOR", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_L_PASA_CREDI_AMOR_DETA_2009(ByVal cnn As OracleConnection) As DataView
    '    Dim cmd As New OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivopagopasajes.SP_L_PASA_CREDI_AMOR_DETA"

    '    cmd.Parameters.Add(New OracleParameter("P_IDCABE_PAGOS_PASAJES", OracleType.Number)).Value = IDCABE_PAGOS_PASAJES
    '    cmd.Parameters.Add(New OracleParameter("CUR_L_PASA_CREDI_AMOR_DETA", OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim DA As New OracleDataAdapter(cmd)

    '    Dim DT As New DataTable

    '    DA.Fill(DT)

    '    Dim dv As New DataView

    '    dv = DT.DefaultView

    '    Return dv
    'End Function
    Public Function SP_L_PASA_CREDI_AMOR_DETA() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_ivopagopasajes.SP_L_PASA_CREDI_AMOR_DETA", CommandType.StoredProcedure)
            '
            db.AsignarParametro("P_IDCABE_PAGOS_PASAJES", IDCABE_PAGOS_PASAJES, OracleClient.OracleType.Number)
            '
            db.AsignarParametro("CUR_L_PASA_CREDI_AMOR_DETA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_DELE_PASA_CREDI_AMOR_DETA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivopagopasajes.SP_DELE_PASA_CREDI_AMOR_DETA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCABE_PAGOS_PASAJES", OracleClient.OracleType.Number)).Value = IDCABE_PAGOS_PASAJES
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_DELE_PASA_CREDI_AMOR_DETA()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivopagopasajes.SP_DELE_PASA_CREDI_AMOR_DETA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDCABE_PAGOS_PASAJES", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub

End Class
