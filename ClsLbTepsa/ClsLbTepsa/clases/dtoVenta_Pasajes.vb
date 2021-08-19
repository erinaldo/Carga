'Imports System.Data.OracleClient
Imports AccesoDatos

Public Class dtoVenta_Pasajes
    Dim MyIDcobran_pasa As Long
    Dim MyAGENTE_RETENCION As Long
    Dim MyAPELLIDO_MATERNO As String
    Dim MyAPELLIDO_PATERNO As String
    Dim MyCALCU_COMI As Long
    Dim MyCALCU_COMI_FUNCI As Long
    Dim MyCANTIDAD As Long
    Dim MyCLIENTE_CORPORATIVO As Long
    Dim MyCODIGO_CLIENTE As String
    Dim MyCODIGO_CUENTA As String
    Dim MyCONDICION As String
    Dim MyCUENTA As String
    Dim MyDATOS_PERSONALES As String
    Dim MyEDAD As Long
    Dim MyEMAIL As String
    Dim MyESMENOREDAD As Long
    Dim MyESTADO_REGISTRO As String
    Dim MyES_FECHA_ABIERTA As Long
    Dim MyES_RESERVA As Long
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyFECHA_EMISION As String
    Dim MyFECHA_INGRESO As String
    Dim MyFECHA_NACIMIENTO As String
    Dim MyFECHA_REGISTRO As String
    'Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_VIAJE As String
    Dim MyGERENTE_GENERAL As String
    Dim MyHORA_EMISION As String
    Dim MyHORA_SALIDA As String
    Dim MyIDAGENCIAS As Long
    Dim MyIDAGENCIA_DESTINO As Long
    Dim MyIDAGENCIA_ORIGEN As Long
    Dim MyIDAGENCIA_VENTA As Long
    Dim MyIDCLASE As Long
    Dim MyIDCLASIFICACION_PERSONA As Long
    Dim MyIDCONDICION_ANTIGUA As Long
    Dim MyIDCONDICION_BOLETO As Long
    Dim MyIDDEPARTAMENTO As Long
    Dim MyIDDISTRITO As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDIGV As Long
    Dim MyIDOPERACION As String
    Dim MyIDPAIS As Long
    Dim MyIDPERSONA As Long
    Dim MyIDPERSONA_CUENTA As String
    Dim MyIDPERSONA_EMPRESA As Long
    Dim MyIDPROCESOS As Long
    Dim MyIDPROCESO_COMPROBANTE As Long
    Dim MyIDPROVINCIA As Long
    Dim MyIDPUNTO_EMBARQUE As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIDRUBRO As Long
    Dim MyIDRUTAS_ITINERARIO As Long
    Dim MyIDTARJETA As Long
    Dim MyIDTARJETAS As Long
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyIDTIPO_DOC_IDENTIDAD As Long
    Dim MyIDTIPO_FACTURACION As Long
    Dim MyIDTIPO_MONEDA As Long
    Dim MyIDTIPO_OPERACION As Long
    Dim MyIDTIPO_PERSONA As Long
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Long
    Dim MyIDUNIDAD_AGENCIA_ORIGEN As Long
    Dim MyIDUNIDAD_TRANSPORTE As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDUSUARIO_PERSONAL_MOD As Long
    Dim MyIDVENTAS_PASAJES_REF As Long
    Dim MyIDVENTA_PASAJES As Long
    Dim MyIGV As Long
    Dim MyIND_ASOCIA_CUENTA As String
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyLOGIN As String
    Dim MyMEMO As String
    Dim MyMONTO_BASE As Long
    Dim MyMONTO_DESCUENTO As Long
    Dim MyMONTO_IMPUESTO As Long
    Dim MyMONTO_PENALIDAD As Long
    Dim MyMONTO_RECARGO As Long
    Dim MyMONTO_RECUPERADO As Long
    Dim MyMONTO_TOTAL As Long
    Dim MyNOMPRE_PERSONA As String
    Dim MyNOMPRE_PERSONA1 As String
    Dim MyNRO_ASIENTO As Long
    Dim MyNRO_COMPROBANTE As String
    Dim MyNRO_COMPROBANTE_REF As Long
    Dim MyNU_DOCU_SUNA As String
    Dim MyNU_RETE_SUNA As String
    Dim MyPAGO_POST_FACTURACION As Long
    Dim MyPASSWORD As String
    Dim MyPESO As Long
    Dim MyPORCENTAGE_DESCUENTO As Long
    Dim MyPORCENT_DEVOLUCION As Long
    Dim MyPORC_DESCUENTO As Long
    Dim MyRAZON_SOCIAL As String
    Dim MyREPRESENTANTE_LEGAL As String
    Dim MySERIE_COMPROBANTE As String
    Dim MySERIE_COMPROBANTE_REF As Long
    Dim MySEXO_PERSONA As String
    Dim MyTELEFONO As String
    Dim MyTIPO_COMPROBANTE As String
    Dim MyFECHA_INI As String
    Dim MyFECHA_FINAL As String

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
    Public Property IDcobran_pasa() As String

        Get
            IDcobran_pasa = MyIDcobran_pasa
        End Get
        Set(ByVal value As String)
            MyIDcobran_pasa = value
        End Set
    End Property
    Public Property TIPO_COMPROBANTE() As String

        Get
            TIPO_COMPROBANTE = MyTIPO_COMPROBANTE
        End Get
        Set(ByVal value As String)
            MyTIPO_COMPROBANTE = value
        End Set
    End Property
    Public Property NU_DOCU_SUNA() As String

        Get
            NU_DOCU_SUNA = MyNU_DOCU_SUNA
        End Get
        Set(ByVal value As String)
            MyNU_DOCU_SUNA = value
        End Set
    End Property
    Public Property RAZON_SOCIAL() As String

        Get
            RAZON_SOCIAL = MyRAZON_SOCIAL
        End Get
        Set(ByVal value As String)
            MyRAZON_SOCIAL = value
        End Set
    End Property
    Public Property CONDICION() As String

        Get
            CONDICION = MyCONDICION
        End Get
        Set(ByVal value As String)
            MyCONDICION = value
        End Set
    End Property
    Public Property ESTADO_REGISTRO() As String

        Get
            ESTADO_REGISTRO = MyESTADO_REGISTRO
        End Get
        Set(ByVal value As String)
            MyESTADO_REGISTRO = value
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
    Public Property IDPERSONA() As Long

        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
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
    Public Property IDTIPO_COMPROBANTE() As Long

        Get
            IDTIPO_COMPROBANTE = MyIDTIPO_COMPROBANTE
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_COMPROBANTE = value
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
    Public Property IGV() As Long

        Get
            IGV = MyIGV
        End Get
        Set(ByVal value As Long)
            MyIGV = value
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
    Public Property NRO_ASIENTO() As Long

        Get
            NRO_ASIENTO = MyNRO_ASIENTO
        End Get
        Set(ByVal value As Long)
            MyNRO_ASIENTO = value
        End Set
    End Property
    Public Property MONTO_BASE() As Long

        Get
            MONTO_BASE = MyMONTO_BASE
        End Get
        Set(ByVal value As Long)
            MyMONTO_BASE = value
        End Set
    End Property
    Public Property MONTO_PENALIDAD() As Long

        Get
            MONTO_PENALIDAD = MyMONTO_PENALIDAD
        End Get
        Set(ByVal value As Long)
            MyMONTO_PENALIDAD = value
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
    Public Property MONTO_RECARGO() As Long

        Get
            MONTO_RECARGO = MyMONTO_RECARGO
        End Get
        Set(ByVal value As Long)
            MyMONTO_RECARGO = value
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
    Public Property IDTIPO_MONEDA() As Long

        Get
            IDTIPO_MONEDA = MyIDTIPO_MONEDA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_MONEDA = value
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
    Public Property IDCLASE() As Long

        Get
            IDCLASE = MyIDCLASE
        End Get
        Set(ByVal value As Long)
            MyIDCLASE = value
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
    Public Property IDAGENCIAS() As Long

        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = value
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
    Public Property ES_RESERVA() As Long

        Get
            ES_RESERVA = MyES_RESERVA
        End Get
        Set(ByVal value As Long)
            MyES_RESERVA = value
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
    Public Property IDIGV() As Long

        Get
            IDIGV = MyIDIGV
        End Get
        Set(ByVal value As Long)
            MyIDIGV = value
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
    Public Property NRO_COMPROBANTE() As String

        Get
            NRO_COMPROBANTE = MyNRO_COMPROBANTE
        End Get
        Set(ByVal value As String)
            MyNRO_COMPROBANTE = value
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
    Public Property SERIE_COMPROBANTE_REF() As Long

        Get
            SERIE_COMPROBANTE_REF = MySERIE_COMPROBANTE_REF
        End Get
        Set(ByVal value As Long)
            MySERIE_COMPROBANTE_REF = value
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
    Public Property FECHA_REGISTRO() As String

        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
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
    Public Property FECHA_VIAJE() As String

        Get
            FECHA_VIAJE = MyFECHA_VIAJE
        End Get
        Set(ByVal value As String)
            MyFECHA_VIAJE = value
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
    Public Property IDUNIDAD_AGENCIA_ORIGEN() As Long

        Get
            IDUNIDAD_AGENCIA_ORIGEN = MyIDUNIDAD_AGENCIA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA_ORIGEN = value
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
    Public Property IDAGENCIA_ORIGEN() As Long

        Get
            IDAGENCIA_ORIGEN = MyIDAGENCIA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIA_ORIGEN = value
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
    Public Property IDAGENCIA_VENTA() As Long

        Get
            IDAGENCIA_VENTA = MyIDAGENCIA_VENTA
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIA_VENTA = value
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
    Public Property CODIGO_CUENTA() As String

        Get
            CODIGO_CUENTA = MyCODIGO_CUENTA
        End Get
        Set(ByVal value As String)
            MyCODIGO_CUENTA = value
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
    Public Property MONTO_IMPUESTO() As Long

        Get
            MONTO_IMPUESTO = MyMONTO_IMPUESTO
        End Get
        Set(ByVal value As Long)
            MyMONTO_IMPUESTO = value
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
    Public Property MONTO_RECUPERADO() As Long

        Get
            MONTO_RECUPERADO = MyMONTO_RECUPERADO
        End Get
        Set(ByVal value As Long)
            MyMONTO_RECUPERADO = value
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
    Public Property MONTO_TOTAL() As Long

        Get
            MONTO_TOTAL = MyMONTO_TOTAL
        End Get
        Set(ByVal value As Long)
            MyMONTO_TOTAL = value
        End Set
    End Property
    Public Property PORC_DESCUENTO() As Long

        Get
            PORC_DESCUENTO = MyPORC_DESCUENTO
        End Get
        Set(ByVal value As Long)
            MyPORC_DESCUENTO = value
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
    Public Property IDCONDICION_BOLETO() As Long

        Get
            IDCONDICION_BOLETO = MyIDCONDICION_BOLETO
        End Get
        Set(ByVal value As Long)
            MyIDCONDICION_BOLETO = value
        End Set
    End Property
    Public Property PESO() As Long

        Get
            PESO = MyPESO
        End Get
        Set(ByVal value As Long)
            MyPESO = value
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
    Public Property DATOS_PERSONALES() As String

        Get
            DATOS_PERSONALES = MyDATOS_PERSONALES
        End Get
        Set(ByVal value As String)
            MyDATOS_PERSONALES = value
        End Set
    End Property
    Public Property PORCENT_DEVOLUCION() As Long

        Get
            PORCENT_DEVOLUCION = MyPORCENT_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyPORCENT_DEVOLUCION = value
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
    Public Property EDAD() As Long

        Get
            EDAD = MyEDAD
        End Get
        Set(ByVal value As Long)
            MyEDAD = value
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
    Public Property ES_FECHA_ABIERTA() As Long

        Get
            ES_FECHA_ABIERTA = MyES_FECHA_ABIERTA
        End Get
        Set(ByVal value As Long)
            MyES_FECHA_ABIERTA = value
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
    'Public Function SP_SELEC_BOLE_COBRA_CLIE_2009(ByVal cnn As OracleConnection) As DataView
    '    Dim cmd As New OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_REP_cobranza_pasajes"
    '    'cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_comprobante", OracleClient.OracleType.VarChar)).Value = NRO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleParameter("P_IDPERSONA", OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleParameter("P_FECHA_INI", OracleType.VarChar)).Value = FECHA_INI
    '    cmd.Parameters.Add(New OracleParameter("P_FECHA_FINAL", OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleParameter("cur_SELEC_BOLE_COBRA_CLIE", OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim DA As New OracleDataAdapter(cmd)

    '    Dim DT As New DataTable
    '    DA.Fill(DT)

    '    Dim dv As New DataView
    '    dv = DT.DefaultView

    '    If dv.Count >= 1 Then
    '        If Not dv.Table.Rows(0).IsNull("IDVENTA_PASAJES") Then IDVENTA_PASAJES = dv.Table.Rows(0)("IDVENTA_PASAJES") Else IDVENTA_PASAJES = 0
    '        If Not dv.Table.Rows(0).IsNull("nro_comprobante") Then NRO_COMPROBANTE = dv.Table.Rows(0)("nro_comprobante") Else NRO_COMPROBANTE = ""
    '        If Not dv.Table.Rows(0).IsNull("serie_comprobante") Then SERIE_COMPROBANTE = dv.Table.Rows(0)("serie_comprobante") Else SERIE_COMPROBANTE = ""
    '        If Not dv.Table.Rows(0).IsNull("razon_social") Then RAZON_SOCIAL = dv.Table.Rows(0)("razon_social") Else RAZON_SOCIAL = ""
    '        If Not dv.Table.Rows(0).IsNull("nu_docu_suna") Then NU_DOCU_SUNA = dv.Table.Rows(0)("nu_docu_suna") Else NU_DOCU_SUNA = ""
    '        If Not dv.Table.Rows(0).IsNull("fecha_emision") Then FECHA_EMISION = dv.Table.Rows(0)("fecha_emision") Else FECHA_EMISION = ""
    '        If Not dv.Table.Rows(0).IsNull("condicion") Then CONDICION = dv.Table.Rows(0)("condicion") Else CONDICION = ""
    '        If Not dv.Table.Rows(0).IsNull("monto_total") Then MONTO_TOTAL = dv.Table.Rows(0)("monto_total") Else MONTO_TOTAL = 0
    '        If Not dv.Table.Rows(0).IsNull("estado_registro") Then ESTADO_REGISTRO = dv.Table.Rows(0)("estado_registro") Else ESTADO_REGISTRO = ""
    '        If Not dv.Table.Rows(0).IsNull("idtipo_comprobante") Then IDTIPO_COMPROBANTE = dv.Table.Rows(0)("idtipo_comprobante") Else IDTIPO_COMPROBANTE = 0
    '        If Not dv.Table.Rows(0).IsNull("tipo_comprobante") Then TIPO_COMPROBANTE = dv.Table.Rows(0)("tipo_comprobante") Else TIPO_COMPROBANTE = 0
    '    End If

    '    Return dv

    'End Function
    'Public Function SP_LIST_cobranza_pasajes_2009(ByVal cnn As OracleConnection) As DataView
    '    Dim cmd As New OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_LIST_cobranza_pasajes"

    '    cmd.Parameters.Add(New OracleParameter("P_IDPERSONA", OracleType.VarChar)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleParameter("curr_LIST_cobranza_pasajes", OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim DA As New OracleDataAdapter(cmd)

    '    Dim DT As New DataTable

    '    DA.Fill(DT)

    '    Dim dv As New DataView

    '    dv = DT.DefaultView

    '    Return dv

    'End Function
    'Public Function SP_REP_cobranza_pasajes_2009(ByVal cnn As OracleConnection) As DataView
    '    Dim cmd As New OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_REP_cobranza_pasajes"
    '    'cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_comprobante", OracleClient.OracleType.VarChar)).Value = NRO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleParameter("P_IDPERSONA", OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleParameter("P_FECHA_INI", OracleType.VarChar)).Value = FECHA_INI
    '    cmd.Parameters.Add(New OracleParameter("P_FECHA_FINAL", OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleParameter("curr_REP_cobranza_pasajes", OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim DA As New OracleDataAdapter(cmd)

    '    Dim DT As New DataTable
    '    DA.Fill(DT)

    '    Dim dv As New DataView
    '    dv = DT.DefaultView

    '    Return dv

    'End Function

    Public Function SP_REP_cobranza_pasajes() As DataView
        Try
            Dim ds As DataSet
            Dim dv As DataView
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_REP_cobranza_pasajes", CommandType.StoredProcedure)
            db.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_fecha_ini", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IdUsuario_Personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("curr_REP_cobranza_pasajes", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            ds = db.EjecutarDataSet
            dv = ds.Tables(0).DefaultView
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_IUPD_cobranza_pasajes_2009(ByVal cnn As OracleConnection)
    '    Dim cmd As New OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_IUPD_cobranza_pasajes"

    '    cmd.Parameters.Add(New OracleParameter("P_IDPERSONA", OracleType.VarChar)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleParameter("curr_IUPD_cobranza_pasajes", OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim DA As New OracleDataAdapter(cmd)

    '    Dim DT As New DataTable

    '    DA.Fill(DT)

    '    IDcobran_pasa = DT.Rows(0)(0)

    'End Sub
    Public Sub SP_IUPD_cobranza_pasajes()
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_IUPD_cobranza_pasajes", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("curr_IUPD_cobranza_pasajes", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            IDcobran_pasa = dt.Rows(0)(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Sub SP_IUPD_cobranza_pasajes_deta_2009(ByVal cnn As OracleConnection)
    '    Dim cmd As New OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_IUPD_cobranza_pasajes_deta"

    '    cmd.Parameters.Add(New OracleParameter("p_IDcobran_pasa", OracleType.Number)).Value = IDcobran_pasa
    '    cmd.Parameters.Add(New OracleParameter("P_IDVENTA_PASAJES", OracleType.Number)).Value = IDVENTA_PASAJES

    '    cmd.ExecuteNonQuery()

    'End Sub
    Public Sub SP_IUPD_cobranza_pasajes_deta()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_IUPD_cobranza_pasajes_deta", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDcobran_pasa", IDcobran_pasa, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDVENTA_PASAJES", IDVENTA_PASAJES, OracleClient.OracleType.Number)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class