Imports AccesoDatos
Public Class dtoGiros
    'alter table t_factura_contado add( pregunta_giro varchar2(50)
    ',respuesta_giro  varchar2(50)
    ',respuesta_ente_giro  varchar2(50))

    Dim MyFLAG_SOLICITUD_ENCONTRADA As Integer
    Dim Mynro_solicitud_giros As String
    Dim MyDNI_RESPONSABLE As String
    Dim MyNOMBRE_RESPONSABLE As String

    Dim Mypregunta_giro As String
    Dim MyHASH_MD5 As String
    Dim Myrespuesta_giro As String
    Dim Myrespuesta_entre_giro As String

    Dim MyENTRE_DEVO As String
    Dim MyPASSWORD_GIRO As String
    Dim MyOBS As String
    Dim MyIDTIPO_TARIFAS_GIROS As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDUSUARIO_PERSONAL_MOD As Long
    Dim MyTIPO_CAMBIO As Double
    Dim MyMONTO_MINIMO As Double
    Dim MyFECHA_REGISTRO As String
    Dim MyIDTIPO_CAMBIO As Long
    Dim MyFECHA As String
    Dim MyMONTO_MAXIMO As Double
    Dim MyMONTO_INICIAL As Double
    Dim MyIP As String
    Dim MyIDTARIFA_MONTO_GIRO As Long
    Dim MyMONTO_FINAL As Double
    Dim MyABRE As String
    Dim MyMONTO_BASE As Double
    Dim MyIDROL As Long
    Dim MyMONTO_FLETE As Double
    Dim MyTIPO_TARIFAS_GIROS As String
    Dim MyIDROL_MOD As Long
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIP_MOD As String
    Dim MyVIGENTE As Long


    '


    Dim MyIDDIRECCION_CONSIGNADO_REMI As Long
    Dim MyDIRECCION_REMI As String
    Dim MyNRODOCUMENTO As String
    Dim MyIDCONTACTO_PERSONA_DESTI As Long
    Dim MyNOMBRES_DESTI As String
    Dim MyIDDIRECCION_CONSIGNADO_DESTI As Long
    Dim MyDIRECCION_DESTI As String

    Dim MyTELEFONO_DESTI As String
    Dim MyNU_DOCU_SUNA As String
    Dim MyOPE As Integer
    Dim MyCOMUNICACION_CONTACTO_REMI As String
    Dim MyCOMUNICACION_CONTACTO_DESTI As String
    Dim MyNOMBRE_PERSONA_DESTI As String
    Dim MyNRO_DOCU_IDEN_REMI As String
    Dim MyNRO_DOCU_IDEN_DESTI As String
    Dim MyDIRECCION_REMITENTE As String
    Dim MyDIRECCION_CONSIGNADO As String
    Dim MyRAZON_SOCIAL As String
    Dim MyFECHA_ACTUALZIACION As String
    Dim MyAPEMAT As String
    Dim MyAPEPAT As String
    Dim MyBILLETE_DE_PAGO As Long
    Dim MyCALCU_COMI As Long
    Dim MyCALCU_COMI_FUNCI As Long
    Dim MyCANTIDAD_X_PESO As Long
    Dim MyCANTIDAD_X_SOBRE As Long
    Dim MyCANTIDAD_X_VOLUMEN As Long
    Dim MyCARGO As Long
    Dim MyCODIGO_UBIGEO As String
    Dim MyCONCEPTO_CONTROL As String
    Dim MyCONTROL_CONTABLE As Long
    Dim MyCO_UBIC_GEOG As String
    Dim MyDATOS_PERSONALES As String
    Dim MyDEFECTO As Long
    Dim MyDE_REFERENCIA As String
    Dim MyDIRECCION As String
    Dim MyDIRECCION_FACTURACION As Long
    Dim MyDOC_ENTREGA As String
    Dim MyEMAIL_CONTACTO As String
    Dim MyESTADO_REGISTRO As Long
    Dim MyEXPORTADO As Long

    Dim MyFECHA_ANULACION As String
    Dim MyFECHA_CARGO As String
    Dim MyFECHA_CARGOS As String
    Dim MyFECHA_CIERRE As String
    Dim MyFECHA_DESPACHO As String
    Dim MyFECHA_DEVOLUCION As String
    Dim MyFECHA_ENTREGA As String
    Dim MyFECHA_FACTURA As String
    Dim MyFECHA_NACIMIENTO As String
    Dim MyFECHA_RECEPCION_DESTINO As String

    Dim MyFECHA_REGISTRO_ACTUALIZACION As String
    Dim MyFECHA_VENCIMIENTO As String
    Dim MyHORA_ENTREGA As String
    Dim MyHORA_ENTREGA_FIN As String
    Dim MyHORA_ENTREGA_INICIO As String
    Dim MyHORA_RECOJO_FIN As String
    Dim MyHORA_RECOJO_INICIO As String
    Dim MyIDAGENCIAS As Long
    Dim MyIDAGENCIAS_DESTINO As Long
    Dim MyIDCIUDAD_TRANSITO As Long
    Dim MyIDCOMUNICACION_CONTACTO As Long
    Dim MyIDCONDI_GIRO As String
    Dim MyIDCONTACTO_DESTINO As Long
    Dim MyIDCONTACTO_PERSONA As Long
    Dim MyIDDEPARTAMENTO As Long
    Dim MyIDDESCUENTO_GIRO As String
    Dim MyIDDIRECCION_CONSIGNADO As Long
    Dim MyIDDIREECION_DESTINO As Long
    Dim MyIDDIREECION_ORIGEN As Long
    Dim MyIDDISTRITO As Long
    Dim MyIDESTADO_ENVIO As Long
    Dim MyIDESTADO_FACTURA As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDFACTURA As Long
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDFUNCIONARIO_AUTORIZACION As Long
    Dim MyIDGUIA_TRANSPORTISTA As Long
    Dim MyIDGUIA_TRANSPORTISTA_UPD As Long
    Dim MyIDLIQUIDAQCION_OFICINA As Long
    Dim MyIDLIQUI_TURNOS As Long
    Dim MyIDPAIS As Long
    Dim MyIDPERSONA As Long
    Dim MyIDPERSONA_DESTINO As Long
    Dim MyIDPERSONA_ORIGEN As Long
    Dim MyIDPROCESOS As Long
    Dim MyIDPROVINCIA As Long
    Dim MyIDREMITENTE As Long
    Dim MyIDROL_ANULACION As Long
    Dim MyIDROL_DEVOLUCION As Long
    Dim MyIDROL_ENTREGA As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIDTARJETAS As Long
    Dim MyIDTEFONO_CONSIGNADO As Long
    Dim MyIDTEFONO_REMITENTE As Long
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyIDTIPO_COMUNICACION As Long
    Dim MyIDTIPO_CONTACTO As Long
    Dim MyIDTIPO_DIRECCION As Long
    Dim MyIDTIPO_DOCUMENTO_CONTACTO As Long
    Dim MyIDTIPO_ENTREGA As Long
    Dim MyIDTIPO_GIRO As String
    Dim MyIDTIPO_MONEDA As Long
    Dim MyIDTIPO_PAGO As Long
    Dim MyIDTIPO_SERVICIO_GIRO As Long
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyIDUNIDAD_DESTINO As Long
    Dim MyIDUNIDAD_ORIGEN As Long
    Dim MyIDUSUARIO_ANULACION As Long
    Dim MyIDUSUARIO_DEVOLUCION As Long
    Dim MyIDUSUARIO_ENTREGA As Long

    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIGV As Double
    Dim MyIMPRESO As Long

    Dim MyIPMOD As String
    Dim MyLIQUIDADO As Long
    Dim MyMEMO As String

    Dim MyMONTO_DESCUENTO As Double
    Dim MyMONTO_IMPUESTO As Double
    Dim MyMONTO_PENALIDAD As Double
    Dim MyMONTO_RECARGO As Double
    Dim MyMONTO_SUB_TOTAL As Double
    Dim MyMONTO_TIPO_CAMBIO As Double
    Dim MyNOMBRES As String
    Dim MyNOMBRE_ENTREGA As String
    Dim MyNROCOMUNICACION_CONTACTO As String
    Dim MyNROTARJETA As String
    Dim MyNRO_FACTURA As String
    Dim MyPORCENT_DESCUENTO As Double
    Dim MyPORCENT_DEVOLUCION As Double
    Dim MyPRECIO_X_PESO As Double
    Dim MyPRECIO_X_SOBRE As Double
    Dim MyPRECIO_X_UNIDAD As Double
    Dim MyPRECIO_X_VOLUMEN As Double
    Dim MyREF_IDFACTURA As Long
    Dim MySERIE_FACTURA As String
    Dim MySEXO As String
    Dim MyTELEFONO As String
    Dim MyTOTAL_COSTO As Double
    Dim MyTOTAL_PESO As Double
    Dim MyTOTAL_VOLUMEN As Double
    Dim MyMONTO_GIRADO As Double

    Dim MyFECHA_INI As String
    Dim MyFECHA_FINAL As String



    Public Property FLAG_SOLICITUD_ENCONTRADA() As Integer

        Get
            FLAG_SOLICITUD_ENCONTRADA = MyFLAG_SOLICITUD_ENCONTRADA
        End Get
        Set(ByVal value As Integer)
            MyFLAG_SOLICITUD_ENCONTRADA = value
        End Set
    End Property


    Public Property nro_solicitud_giros() As String

        Get
            nro_solicitud_giros = Mynro_solicitud_giros
        End Get
        Set(ByVal value As String)
            Mynro_solicitud_giros = value
        End Set
    End Property



    Public Property DNI_RESPONSABLE() As String

        Get
            DNI_RESPONSABLE = MyDNI_RESPONSABLE
        End Get
        Set(ByVal value As String)
            MyDNI_RESPONSABLE = value
        End Set
    End Property



    Public Property NOMBRE_RESPONSABLE() As String

        Get
            NOMBRE_RESPONSABLE = MyNOMBRE_RESPONSABLE
        End Get
        Set(ByVal value As String)
            MyNOMBRE_RESPONSABLE = value
        End Set
    End Property



    Public Property HASH_MD5() As String

        Get
            HASH_MD5 = MyHASH_MD5
        End Get
        Set(ByVal value As String)
            MyHASH_MD5 = value
        End Set
    End Property


    Public Property pregunta_giro() As String

        Get
            pregunta_giro = Mypregunta_giro
        End Get
        Set(ByVal value As String)
            Mypregunta_giro = value
        End Set
    End Property
    Public Property respuesta_giro() As String

        Get
            respuesta_giro = Myrespuesta_giro
        End Get
        Set(ByVal value As String)
            Myrespuesta_giro = value
        End Set
    End Property
    Public Property respuesta_entre_giro() As String

        Get
            respuesta_entre_giro = Myrespuesta_entre_giro
        End Get
        Set(ByVal value As String)
            Myrespuesta_entre_giro = value
        End Set
    End Property



    Public Property ENTRE_DEVO() As String

        Get
            ENTRE_DEVO = MyENTRE_DEVO
        End Get
        Set(ByVal value As String)
            MyENTRE_DEVO = value
        End Set
    End Property
    Public Property PASSWORD_GIRO() As String

        Get
            PASSWORD_GIRO = MyPASSWORD_GIRO
        End Get
        Set(ByVal value As String)
            MyPASSWORD_GIRO = value
        End Set
    End Property
    Public Property OBS() As String

        Get
            OBS = MyOBS
        End Get
        Set(ByVal value As String)
            MyOBS = value
        End Set
    End Property

    Public Property MONTO_MAXIMO() As Double

        Get
            MONTO_MAXIMO = MyMONTO_MAXIMO
        End Get
        Set(ByVal value As Double)
            MyMONTO_MAXIMO = value
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
    Public Property MONTO_INICIAL() As Double

        Get
            MONTO_INICIAL = MyMONTO_INICIAL
        End Get
        Set(ByVal value As Double)
            MyMONTO_INICIAL = value
        End Set
    End Property
    Public Property TIPO_CAMBIO() As Double

        Get
            TIPO_CAMBIO = MyTIPO_CAMBIO
        End Get
        Set(ByVal value As Double)
            MyTIPO_CAMBIO = value
        End Set
    End Property
    Public Property MONTO_MINIMO() As Double

        Get
            MONTO_MINIMO = MyMONTO_MINIMO
        End Get
        Set(ByVal value As Double)
            MyMONTO_MINIMO = value
        End Set
    End Property
    Public Property IP_MOD() As String

        Get
            IP_MOD = MyIP_MOD
        End Get
        Set(ByVal value As String)
            MyIP_MOD = value
        End Set
    End Property
    Public Property TIPO_TARIFAS_GIROS() As String

        Get
            TIPO_TARIFAS_GIROS = MyTIPO_TARIFAS_GIROS
        End Get
        Set(ByVal value As String)
            MyTIPO_TARIFAS_GIROS = value
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
    Public Property MONTO_FLETE() As Double

        Get
            MONTO_FLETE = MyMONTO_FLETE
        End Get
        Set(ByVal value As Double)
            MyMONTO_FLETE = value
        End Set
    End Property
    Public Property ABRE() As String

        Get
            ABRE = MyABRE
        End Get
        Set(ByVal value As String)
            MyABRE = value
        End Set
    End Property

    Public Property IDTIPO_TARIFAS_GIROS() As String

        Get
            IDTIPO_TARIFAS_GIROS = MyIDTIPO_TARIFAS_GIROS
        End Get
        Set(ByVal value As String)
            MyIDTIPO_TARIFAS_GIROS = value
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
    Public Property IDTARIFA_MONTO_GIRO() As Long

        Get
            IDTARIFA_MONTO_GIRO = MyIDTARIFA_MONTO_GIRO
        End Get
        Set(ByVal value As Long)
            MyIDTARIFA_MONTO_GIRO = value
        End Set
    End Property
    Public Property IDTIPO_CAMBIO() As Long

        Get
            IDTIPO_CAMBIO = MyIDTIPO_CAMBIO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_CAMBIO = value
        End Set
    End Property
    Public Property VIGENTE() As Long

        Get
            VIGENTE = MyVIGENTE
        End Get
        Set(ByVal value As Long)
            MyVIGENTE = value
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

    Public Property MONTO_FINAL() As Double

        Get
            MONTO_FINAL = MyMONTO_FINAL
        End Get
        Set(ByVal value As Double)
            MyMONTO_FINAL = value
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
    Public Property FECHA_INI() As String

        Get
            FECHA_INI = MyFECHA_INI
        End Get
        Set(ByVal value As String)
            MyFECHA_INI = value
        End Set
    End Property


    Public Property MONTO_GIRADO() As Double

        Get
            MONTO_GIRADO = MyMONTO_GIRADO
        End Get
        Set(ByVal value As Double)
            MyMONTO_GIRADO = value
        End Set
    End Property



    Public Property IDDIRECCION_CONSIGNADO_REMI() As Long

        Get
            IDDIRECCION_CONSIGNADO_REMI = MyIDDIRECCION_CONSIGNADO_REMI
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_CONSIGNADO_REMI = value
        End Set
    End Property

    Public Property DIRECCION_REMI() As String

        Get
            DIRECCION_REMI = MyDIRECCION_REMI
        End Get
        Set(ByVal value As String)
            MyDIRECCION_REMI = value
        End Set
    End Property

    Public Property NRODOCUMENTO() As String

        Get
            NRODOCUMENTO = MyNRODOCUMENTO
        End Get
        Set(ByVal value As String)
            MyNRODOCUMENTO = value
        End Set
    End Property
    Public Property TELEFONO_DESTI() As String

        Get
            TELEFONO_DESTI = MyTELEFONO_DESTI
        End Get
        Set(ByVal value As String)
            MyTELEFONO_DESTI = value
        End Set
    End Property



    Public Property IDCONTACTO_PERSONA_DESTI() As Long

        Get
            IDCONTACTO_PERSONA_DESTI = MyIDCONTACTO_PERSONA_DESTI
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_PERSONA_DESTI = value
        End Set
    End Property



    Public Property NOMBRES_DESTI() As String

        Get
            NOMBRES_DESTI = MyNOMBRES_DESTI
        End Get
        Set(ByVal value As String)
            MyNOMBRES_DESTI = value
        End Set
    End Property



    Public Property IDDIRECCION_CONSIGNADO_DESTI() As Long

        Get
            IDDIRECCION_CONSIGNADO_DESTI = MyIDDIRECCION_CONSIGNADO_DESTI
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_CONSIGNADO_DESTI = value
        End Set
    End Property


    Public Property DIRECCION_DESTI() As String

        Get
            DIRECCION_DESTI = MyDIRECCION_DESTI
        End Get
        Set(ByVal value As String)
            MyDIRECCION_DESTI = value
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
    Public Property TELEFONO() As String

        Get
            TELEFONO = MyTELEFONO
        End Get
        Set(ByVal value As String)
            MyTELEFONO = value
        End Set
    End Property
    Public Property OPE() As Integer

        Get
            OPE = MyOPE
        End Get
        Set(ByVal value As Integer)
            MyOPE = value
        End Set
    End Property

    Public Property COMUNICACION_CONTACTO_DESTI() As String

        Get
            COMUNICACION_CONTACTO_DESTI = MyCOMUNICACION_CONTACTO_DESTI
        End Get
        Set(ByVal value As String)
            MyCOMUNICACION_CONTACTO_DESTI = value
        End Set
    End Property
    Public Property COMUNICACION_CONTACTO_REMI() As String

        Get
            COMUNICACION_CONTACTO_REMI = MyCOMUNICACION_CONTACTO_REMI
        End Get
        Set(ByVal value As String)
            MyCOMUNICACION_CONTACTO_REMI = value
        End Set
    End Property
    Public Property NOMBRE_PERSONA_DESTI() As String

        Get
            NOMBRE_PERSONA_DESTI = MyNOMBRE_PERSONA_DESTI
        End Get
        Set(ByVal value As String)
            MyNOMBRE_PERSONA_DESTI = value
        End Set
    End Property
    Public Property NRO_DOCU_IDEN_REMI() As String

        Get
            NRO_DOCU_IDEN_REMI = MyNRO_DOCU_IDEN_REMI
        End Get
        Set(ByVal value As String)
            MyNRO_DOCU_IDEN_REMI = value
        End Set
    End Property

    Public Property NRO_DOCU_IDEN_DESTI() As String

        Get
            NRO_DOCU_IDEN_DESTI = MyNRO_DOCU_IDEN_DESTI
        End Get
        Set(ByVal value As String)
            MyNRO_DOCU_IDEN_DESTI = value
        End Set
    End Property


    Public Property IDCOMUNICACION_CONTACTO() As Long

        Get
            IDCOMUNICACION_CONTACTO = MyIDCOMUNICACION_CONTACTO
        End Get
        Set(ByVal value As Long)
            MyIDCOMUNICACION_CONTACTO = value
        End Set
    End Property

    Public Property DIRECCION_CONSIGNADO() As String

        Get
            DIRECCION_CONSIGNADO = MyDIRECCION_CONSIGNADO
        End Get
        Set(ByVal value As String)
            MyDIRECCION_CONSIGNADO = value
        End Set
    End Property

    Public Property DIRECCION_REMITENTE() As String

        Get
            DIRECCION_REMITENTE = MyDIRECCION_REMITENTE
        End Get
        Set(ByVal value As String)
            MyDIRECCION_REMITENTE = value
        End Set
    End Property


    Public Property NROCOMUNICACION_CONTACTO() As String

        Get
            NROCOMUNICACION_CONTACTO = MyNROCOMUNICACION_CONTACTO
        End Get
        Set(ByVal value As String)
            MyNROCOMUNICACION_CONTACTO = value
        End Set
    End Property
    Public Property IDTIPO_COMUNICACION() As Long

        Get
            IDTIPO_COMUNICACION = MyIDTIPO_COMUNICACION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_COMUNICACION = value
        End Set
    End Property
    Public Property IDCONTACTO_PERSONA() As Long

        Get
            IDCONTACTO_PERSONA = MyIDCONTACTO_PERSONA
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_PERSONA = value
        End Set
    End Property
    Public Property IDDIRECCION_CONSIGNADO() As Long

        Get
            IDDIRECCION_CONSIGNADO = MyIDDIRECCION_CONSIGNADO
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_CONSIGNADO = value
        End Set
    End Property
    Public Property IDTIPO_DIRECCION() As Long

        Get
            IDTIPO_DIRECCION = MyIDTIPO_DIRECCION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_DIRECCION = value
        End Set
    End Property

    Public Property DIRECCION() As String

        Get
            DIRECCION = MyDIRECCION
        End Get
        Set(ByVal value As String)
            MyDIRECCION = value
        End Set
    End Property
    Public Property DE_REFERENCIA() As String

        Get
            DE_REFERENCIA = MyDE_REFERENCIA
        End Get
        Set(ByVal value As String)
            MyDE_REFERENCIA = value
        End Set
    End Property
    Public Property CO_UBIC_GEOG() As String

        Get
            CO_UBIC_GEOG = MyCO_UBIC_GEOG
        End Get
        Set(ByVal value As String)
            MyCO_UBIC_GEOG = value
        End Set
    End Property
    Public Property DIRECCION_FACTURACION() As Long

        Get
            DIRECCION_FACTURACION = MyDIRECCION_FACTURACION
        End Get
        Set(ByVal value As Long)
            MyDIRECCION_FACTURACION = value
        End Set
    End Property
    Public Property CODIGO_UBIGEO() As String

        Get
            CODIGO_UBIGEO = MyCODIGO_UBIGEO
        End Get
        Set(ByVal value As String)
            MyCODIGO_UBIGEO = value
        End Set
    End Property
    Public Property HORA_RECOJO_INICIO() As String

        Get
            HORA_RECOJO_INICIO = MyHORA_RECOJO_INICIO
        End Get
        Set(ByVal value As String)
            MyHORA_RECOJO_INICIO = value
        End Set
    End Property
    Public Property HORA_RECOJO_FIN() As String

        Get
            HORA_RECOJO_FIN = MyHORA_RECOJO_FIN
        End Get
        Set(ByVal value As String)
            MyHORA_RECOJO_FIN = value
        End Set
    End Property
    Public Property HORA_ENTREGA_INICIO() As String

        Get
            HORA_ENTREGA_INICIO = MyHORA_ENTREGA_INICIO
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA_INICIO = value
        End Set
    End Property
    Public Property HORA_ENTREGA_FIN() As String

        Get
            HORA_ENTREGA_FIN = MyHORA_ENTREGA_FIN
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA_FIN = value
        End Set
    End Property




    Public Property FECHA_ACTUALZIACION() As String

        Get
            FECHA_ACTUALZIACION = MyFECHA_ACTUALZIACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALZIACION = value
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
    Public Property IDDEPARTAMENTO() As Long

        Get
            IDDEPARTAMENTO = MyIDDEPARTAMENTO
        End Get
        Set(ByVal value As Long)
            MyIDDEPARTAMENTO = value
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
    Public Property IDDISTRITO() As Long

        Get
            IDDISTRITO = MyIDDISTRITO
        End Get
        Set(ByVal value As Long)
            MyIDDISTRITO = value
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
    Public Property IDUNIDAD_AGENCIA() As Long

        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = value
        End Set
    End Property
    Public Property CALCU_COMI() As Double

        Get
            CALCU_COMI = MyCALCU_COMI
        End Get
        Set(ByVal value As Double)
            MyCALCU_COMI = value
        End Set
    End Property
    Public Property CALCU_COMI_FUNCI() As Double

        Get
            CALCU_COMI_FUNCI = MyCALCU_COMI_FUNCI
        End Get
        Set(ByVal value As Double)
            MyCALCU_COMI_FUNCI = value
        End Set
    End Property
    Public Property IDTIPO_GIRO() As String

        Get
            IDTIPO_GIRO = MyIDTIPO_GIRO
        End Get
        Set(ByVal value As String)
            MyIDTIPO_GIRO = value
        End Set
    End Property
    Public Property IDDESCUENTO_GIRO() As String

        Get
            IDDESCUENTO_GIRO = MyIDDESCUENTO_GIRO
        End Get
        Set(ByVal value As String)
            MyIDDESCUENTO_GIRO = value
        End Set
    End Property
    Public Property IDCONDI_GIRO() As String

        Get
            IDCONDI_GIRO = MyIDCONDI_GIRO
        End Get
        Set(ByVal value As String)
            MyIDCONDI_GIRO = value
        End Set
    End Property
    Public Property IDFACTURA() As Long

        Get
            IDFACTURA = MyIDFACTURA
        End Get
        Set(ByVal value As Long)
            MyIDFACTURA = value
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
    Public Property SERIE_FACTURA() As String

        Get
            SERIE_FACTURA = MySERIE_FACTURA
        End Get
        Set(ByVal value As String)
            MySERIE_FACTURA = value
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
    Public Property NRO_FACTURA() As String

        Get
            NRO_FACTURA = MyNRO_FACTURA
        End Get
        Set(ByVal value As String)
            MyNRO_FACTURA = value
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
    Public Property MONTO_IMPUESTO() As Double

        Get
            MONTO_IMPUESTO = MyMONTO_IMPUESTO
        End Get
        Set(ByVal value As Double)
            MyMONTO_IMPUESTO = value
        End Set
    End Property
    Public Property TOTAL_COSTO() As Double

        Get
            TOTAL_COSTO = MyTOTAL_COSTO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_COSTO = value
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
    Public Property IDESTADO_ENVIO() As Long
        Get
            IDESTADO_ENVIO = MyIDESTADO_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_ENVIO = value
        End Set
    End Property
    Public Property IDESTADO_FACTURA() As Long
        Get
            IDESTADO_FACTURA = MyIDESTADO_FACTURA
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_FACTURA = value
        End Set
    End Property
    Public Property IDCIUDAD_TRANSITO() As Long
        Get
            IDCIUDAD_TRANSITO = MyIDCIUDAD_TRANSITO
        End Get
        Set(ByVal value As Long)
            MyIDCIUDAD_TRANSITO = value
        End Set
    End Property
    Public Property CANTIDAD_X_PESO() As Double
        Get
            CANTIDAD_X_PESO = MyCANTIDAD_X_PESO
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_PESO = value
        End Set
    End Property
    Public Property TOTAL_PESO() As Double
        Get
            TOTAL_PESO = MyTOTAL_PESO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_PESO = value
        End Set
    End Property
    Public Property TOTAL_VOLUMEN() As Double
        Get
            TOTAL_VOLUMEN = MyTOTAL_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyTOTAL_VOLUMEN = value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA() As Long
        Get
            IDGUIA_TRANSPORTISTA = MyIDGUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA = value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA_UPD() As Long
        Get
            IDGUIA_TRANSPORTISTA_UPD = MyIDGUIA_TRANSPORTISTA_UPD
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA_UPD = value
        End Set
    End Property
    Public Property IDUNIDAD_ORIGEN() As Long
        Get
            IDUNIDAD_ORIGEN = MyIDUNIDAD_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_ORIGEN = value
        End Set
    End Property
    Public Property IDUNIDAD_DESTINO() As Long
        Get
            IDUNIDAD_DESTINO = MyIDUNIDAD_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_DESTINO = value
        End Set
    End Property
    Public Property IDDIREECION_ORIGEN() As Long
        Get
            IDDIREECION_ORIGEN = MyIDDIREECION_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDDIREECION_ORIGEN = value
        End Set
    End Property
    Public Property IDDIREECION_DESTINO() As Long

        Get
            IDDIREECION_DESTINO = MyIDDIREECION_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDDIREECION_DESTINO = value
        End Set
    End Property
    Public Property MONTO_TIPO_CAMBIO() As Double

        Get
            MONTO_TIPO_CAMBIO = MyMONTO_TIPO_CAMBIO
        End Get
        Set(ByVal value As Double)
            MyMONTO_TIPO_CAMBIO = value
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
    Public Property IDTIPO_SERVICIO_GIRO() As Long

        Get
            IDTIPO_SERVICIO_GIRO = MyIDTIPO_SERVICIO_GIRO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_SERVICIO_GIRO = value
        End Set
    End Property
    Public Property FECHA_FACTURA() As String

        Get
            FECHA_FACTURA = MyFECHA_FACTURA
        End Get
        Set(ByVal value As String)
            MyFECHA_FACTURA = value
        End Set
    End Property
    Public Property FECHA_VENCIMIENTO() As String

        Get
            FECHA_VENCIMIENTO = MyFECHA_VENCIMIENTO
        End Get
        Set(ByVal value As String)
            MyFECHA_VENCIMIENTO = value
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
    Public Property IDPERSONA_ORIGEN() As Long

        Get
            IDPERSONA_ORIGEN = MyIDPERSONA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA_ORIGEN = value
        End Set
    End Property
    Public Property IDPERSONA_DESTINO() As Long

        Get
            IDPERSONA_DESTINO = MyIDPERSONA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA_DESTINO = value
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
    Public Property IDUSUARIO_PERSONAL() As Long

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
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
    Public Property IP() As String

        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
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
    Public Property IPMOD() As String

        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
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
    Public Property FECHA_REGISTRO_ACTUALIZACION() As String

        Get
            FECHA_REGISTRO_ACTUALIZACION = MyFECHA_REGISTRO_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO_ACTUALIZACION = value
        End Set
    End Property
    Public Property IMPRESO() As Long

        Get
            IMPRESO = MyIMPRESO
        End Get
        Set(ByVal value As Long)
            MyIMPRESO = value
        End Set
    End Property
    Public Property FECHA_CARGO() As String

        Get
            FECHA_CARGO = MyFECHA_CARGO
        End Get
        Set(ByVal value As String)
            MyFECHA_CARGO = value
        End Set
    End Property
    Public Property CARGO() As Double

        Get
            CARGO = MyCARGO
        End Get
        Set(ByVal value As Double)
            MyCARGO = value
        End Set
    End Property
    Public Property CANTIDAD_X_VOLUMEN() As Double

        Get
            CANTIDAD_X_VOLUMEN = MyCANTIDAD_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_VOLUMEN = value
        End Set
    End Property
    Public Property CANTIDAD_X_SOBRE() As Double

        Get
            CANTIDAD_X_SOBRE = MyCANTIDAD_X_SOBRE
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_SOBRE = value
        End Set
    End Property
    Public Property PRECIO_X_PESO() As Double

        Get
            PRECIO_X_PESO = MyPRECIO_X_PESO
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_PESO = value
        End Set
    End Property
    Public Property PRECIO_X_VOLUMEN() As Double
        Get
            PRECIO_X_VOLUMEN = MyPRECIO_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_VOLUMEN = value
        End Set
    End Property
    Public Property PRECIO_X_UNIDAD() As Double

        Get
            PRECIO_X_UNIDAD = MyPRECIO_X_UNIDAD
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_UNIDAD = value
        End Set
    End Property
    Public Property IDPROCESOS() As Long

        Get
            IDPROCESOS = MyIDPROCESOS
        End Get
        Set(ByVal value As Long)
            MyIDPROCESOS = value
        End Set
    End Property
    Public Property LIQUIDADO() As Long

        Get
            LIQUIDADO = MyLIQUIDADO
        End Get
        Set(ByVal value As Long)
            MyLIQUIDADO = value
        End Set
    End Property
    Public Property FECHA_CIERRE() As String

        Get
            FECHA_CIERRE = MyFECHA_CIERRE
        End Get
        Set(ByVal value As String)
            MyFECHA_CIERRE = value
        End Set
    End Property
    Public Property IDAGENCIAS_DESTINO() As Long

        Get
            IDAGENCIAS_DESTINO = MyIDAGENCIAS_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_DESTINO = value
        End Set
    End Property
    Public Property IDTEFONO_REMITENTE() As Long

        Get
            IDTEFONO_REMITENTE = MyIDTEFONO_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDTEFONO_REMITENTE = value
        End Set
    End Property
    Public Property IDTEFONO_CONSIGNADO() As Long

        Get
            IDTEFONO_CONSIGNADO = MyIDTEFONO_CONSIGNADO
        End Get
        Set(ByVal value As Long)
            MyIDTEFONO_CONSIGNADO = value
        End Set
    End Property
    Public Property MONTO_DESCUENTO() As Double

        Get
            MONTO_DESCUENTO = MyMONTO_DESCUENTO
        End Get
        Set(ByVal value As Double)
            MyMONTO_DESCUENTO = value
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
    Public Property REF_IDFACTURA() As Long

        Get
            REF_IDFACTURA = MyREF_IDFACTURA
        End Get
        Set(ByVal value As Long)
            MyREF_IDFACTURA = value
        End Set
    End Property
    Public Property IDFUNCIONARIO_AUTORIZACION() As Long

        Get
            IDFUNCIONARIO_AUTORIZACION = MyIDFUNCIONARIO_AUTORIZACION
        End Get
        Set(ByVal value As Long)
            MyIDFUNCIONARIO_AUTORIZACION = value
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
    Public Property PORCENT_DEVOLUCION() As Double

        Get
            PORCENT_DEVOLUCION = MyPORCENT_DEVOLUCION
        End Get
        Set(ByVal value As Double)
            MyPORCENT_DEVOLUCION = value
        End Set
    End Property
    Public Property PORCENT_DESCUENTO() As Double

        Get
            PORCENT_DESCUENTO = MyPORCENT_DESCUENTO
        End Get
        Set(ByVal value As Double)
            MyPORCENT_DESCUENTO = value
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
    Public Property BILLETE_DE_PAGO() As Double

        Get
            BILLETE_DE_PAGO = MyBILLETE_DE_PAGO
        End Get
        Set(ByVal value As Double)
            MyBILLETE_DE_PAGO = value
        End Set
    End Property
    Public Property CONTROL_CONTABLE() As Long

        Get
            CONTROL_CONTABLE = MyCONTROL_CONTABLE
        End Get
        Set(ByVal value As Long)
            MyCONTROL_CONTABLE = value
        End Set
    End Property
    Public Property IDREMITENTE() As Long

        Get
            IDREMITENTE = MyIDREMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDREMITENTE = value
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
    Public Property CONCEPTO_CONTROL() As String

        Get
            CONCEPTO_CONTROL = MyCONCEPTO_CONTROL
        End Get
        Set(ByVal value As String)
            MyCONCEPTO_CONTROL = value
        End Set
    End Property
    Public Property FECHA_ANULACION() As String

        Get
            FECHA_ANULACION = MyFECHA_ANULACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ANULACION = value
        End Set
    End Property
    Public Property FECHA_DEVOLUCION() As String

        Get
            FECHA_DEVOLUCION = MyFECHA_DEVOLUCION
        End Get
        Set(ByVal value As String)
            MyFECHA_DEVOLUCION = value
        End Set
    End Property
    Public Property IDUSUARIO_ANULACION() As Long

        Get
            IDUSUARIO_ANULACION = MyIDUSUARIO_ANULACION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_ANULACION = value
        End Set
    End Property
    Public Property IDUSUARIO_DEVOLUCION() As Long

        Get
            IDUSUARIO_DEVOLUCION = MyIDUSUARIO_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_DEVOLUCION = value
        End Set
    End Property
    Public Property IDROL_ANULACION() As Long

        Get
            IDROL_ANULACION = MyIDROL_ANULACION
        End Get
        Set(ByVal value As Long)
            MyIDROL_ANULACION = value
        End Set
    End Property
    Public Property IDROL_DEVOLUCION() As Long

        Get
            IDROL_DEVOLUCION = MyIDROL_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyIDROL_DEVOLUCION = value
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
    Public Property NROTARJETA() As String

        Get
            NROTARJETA = MyNROTARJETA
        End Get
        Set(ByVal value As String)
            MyNROTARJETA = value
        End Set
    End Property
    Public Property IDTIPO_PAGO() As Double

        Get
            IDTIPO_PAGO = MyIDTIPO_PAGO
        End Get
        Set(ByVal value As Double)
            MyIDTIPO_PAGO = value
        End Set
    End Property
    Public Property PRECIO_X_SOBRE() As Double

        Get
            PRECIO_X_SOBRE = MyPRECIO_X_SOBRE
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_SOBRE = value
        End Set
    End Property
    Public Property MONTO_SUB_TOTAL() As Double

        Get
            MONTO_SUB_TOTAL = MyMONTO_SUB_TOTAL
        End Get
        Set(ByVal value As Double)
            MyMONTO_SUB_TOTAL = value
        End Set
    End Property
    Public Property IDCONTACTO_DESTINO() As Long

        Get
            IDCONTACTO_DESTINO = MyIDCONTACTO_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_DESTINO = value
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
    Public Property IDLIQUI_TURNOS() As Long

        Get
            IDLIQUI_TURNOS = MyIDLIQUI_TURNOS
        End Get
        Set(ByVal value As Long)
            MyIDLIQUI_TURNOS = value
        End Set
    End Property
    Public Property IDLIQUIDAQCION_OFICINA() As Long

        Get
            IDLIQUIDAQCION_OFICINA = MyIDLIQUIDAQCION_OFICINA
        End Get
        Set(ByVal value As Long)
            MyIDLIQUIDAQCION_OFICINA = value
        End Set
    End Property
    Public Property IDTIPO_ENTREGA() As Long

        Get
            IDTIPO_ENTREGA = MyIDTIPO_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_ENTREGA = value
        End Set
    End Property
    Public Property FECHA_DESPACHO() As String

        Get
            FECHA_DESPACHO = MyFECHA_DESPACHO
        End Get
        Set(ByVal value As String)
            MyFECHA_DESPACHO = value
        End Set
    End Property
    Public Property FECHA_RECEPCION_DESTINO() As String

        Get
            FECHA_RECEPCION_DESTINO = MyFECHA_RECEPCION_DESTINO
        End Get
        Set(ByVal value As String)
            MyFECHA_RECEPCION_DESTINO = value
        End Set
    End Property
    Public Property FECHA_ENTREGA() As String

        Get
            FECHA_ENTREGA = MyFECHA_ENTREGA
        End Get
        Set(ByVal value As String)
            MyFECHA_ENTREGA = value
        End Set
    End Property
    Public Property FECHA_CARGOS() As String

        Get
            FECHA_CARGOS = MyFECHA_CARGOS
        End Get
        Set(ByVal value As String)
            MyFECHA_CARGOS = value
        End Set
    End Property
    Public Property EXPORTADO() As Long

        Get
            EXPORTADO = MyEXPORTADO
        End Get
        Set(ByVal value As Long)
            MyEXPORTADO = value
        End Set
    End Property
    Public Property NOMBRE_ENTREGA() As String

        Get
            NOMBRE_ENTREGA = MyNOMBRE_ENTREGA
        End Get
        Set(ByVal value As String)
            MyNOMBRE_ENTREGA = value
        End Set
    End Property
    Public Property DOC_ENTREGA() As String

        Get
            DOC_ENTREGA = MyDOC_ENTREGA
        End Get
        Set(ByVal value As String)
            MyDOC_ENTREGA = value
        End Set
    End Property
    Public Property IDUSUARIO_ENTREGA() As Long

        Get
            IDUSUARIO_ENTREGA = MyIDUSUARIO_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_ENTREGA = value
        End Set
    End Property
    Public Property IDROL_ENTREGA() As Long

        Get
            IDROL_ENTREGA = MyIDROL_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDROL_ENTREGA = value
        End Set
    End Property
    Public Property HORA_ENTREGA() As String

        Get
            HORA_ENTREGA = MyHORA_ENTREGA
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA = value
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
    'Public Function InUpDe_factura_giro_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGIROS.InUpDe_factura_giro"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OPE", OracleClient.OracleType.Double)).Value = OPE '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RAZON_SOCIAL", OracleClient.OracleType.NVarChar)).Value = RAZON_SOCIAL '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_telefono", OracleClient.OracleType.NVarChar)).Value = "@" 'TELEFONO 
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_nu_docu_suna", OracleClient.OracleType.NVarChar)).Value = NU_DOCU_SUNA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIRECCION_CONSIGNADO_REMI", OracleClient.OracleType.Number)).Value = IDDIRECCION_CONSIGNADO_REMI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_DIRECCION_REMI", OracleClient.OracleType.NVarChar)).Value = DIRECCION_REMI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRODOCUMENTO", OracleClient.OracleType.NVarChar)).Value = NRODOCUMENTO 'DOCUMENTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONTACTO_PERSONA_DESTI", OracleClient.OracleType.Number)).Value = IDCONTACTO_PERSONA_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NOMBRES_DESTI", OracleClient.OracleType.NVarChar)).Value = NOMBRES_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIRECCION_CONSIGNADO_DESTI", OracleClient.OracleType.Number)).Value = IDDIRECCION_CONSIGNADO_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_DIRECCION_DESTI", OracleClient.OracleType.NVarChar)).Value = DIRECCION_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_telefono_desti", OracleClient.OracleType.NVarChar)).Value = TELEFONO_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFORMA_PAGO", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MONEDA", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.Number)).Value = IDUNIDAD_ORIGEN '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_DESTINO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = IDAGENCIAS_DESTINO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.NVarChar)).Value = IP '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = IDROL_USUARIO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_GIRO", OracleClient.OracleType.NVarChar)).Value = IDTIPO_GIRO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONDI_GIRO", OracleClient.OracleType.NVarChar)).Value = IDCONDI_GIRO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FACTURA", OracleClient.OracleType.NVarChar)).Value = FECHA_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_SERIE_FACTURA", OracleClient.OracleType.NVarChar)).Value = SERIE_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_FACTURA", OracleClient.OracleType.NVarChar)).Value = NRO_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MEMO", OracleClient.OracleType.VarChar)).Value = MEMO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_DESCUENTO", OracleClient.OracleType.Double)).Value = MONTO_DESCUENTO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_COSTO", OracleClient.OracleType.Double)).Value = TOTAL_COSTO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_IMPUESTO", OracleClient.OracleType.Double)).Value = MONTO_IMPUESTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_GIRADO", OracleClient.OracleType.Double)).Value = MONTO_GIRADO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_BASE", OracleClient.OracleType.Double)).Value = MONTO_BASE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_ENTREGA", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA '

    '        cmd.ExecuteNonQuery()

    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)


    '        'Dim dv As New DataView

    '        'dv = ds.Tables(0).DefaultView

    '        'IDFACTURA = dv.Table.Rows(0)(0)

    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try






    'Dim DT As New DataTable
    'Dim Rst As New ADODB.Recordset
    'Dim dv As New DataView
    'Dim DA As New OleDb.OleDbDataAdapter
    'Dim m As Integer

    'Dim a As Integer = 0


    'Try

    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGIROS.InUpDe_factura_giro", 68, _
    '      OPE, 1, _
    'IDPERSONA, 1, _
    'RAZON_SOCIAL, 2, _
    'TELEFONO, 2, _
    'NU_DOCU_SUNA, 2, _
    'IDDIRECCION_CONSIGNADO_REMI, 1, _
    'DIRECCION_REMI, 1, _
    'NRODOCUMENTO, 2, _
    'IDCONTACTO_PERSONA_DESTI, 1, _
    'NOMBRES_DESTI, 2, _
    'IDDIRECCION_CONSIGNADO_DESTI, 1, _
    'DIRECCION_DESTI, 1, _
    'TELEFONO_DESTI, 2, _
    'IDFORMA_PAGO, 1, _
    'IDTIPO_MONEDA, 1, _
    'IDUNIDAD_ORIGEN, 1, _
    'IDUNIDAD_DESTINO, 1, _
    'IDAGENCIAS, 1, _
    'IDAGENCIAS_DESTINO, 1, _
    'IP, 2, _
    'IDUSUARIO_PERSONAL, 1, _
    'IDROL_USUARIO, 1, _
    'IDTIPO_GIRO, 1, _
    'IDCONDI_GIRO, 1, _
    'FECHA_FACTURA, 1, _
    'SERIE_FACTURA, 1, _
    'NRO_FACTURA, 1, _
    'MEMO, 1, _
    'MONTO_DESCUENTO, 1, _
    'TOTAL_COSTO, 1, _
    'MONTO_IMPUESTO, 1, _
    'MONTO_GIRADO, 1, _
    'MONTO_BASE}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)



    '    DA.Fill(DT, Rst)

    '    dv = DT.DefaultView

    '    If Not dv.Count = 0 Then
    '        If Not dv.Table.Rows(0).IsNull(0) Then
    '            If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                m = 1 / a
    '            End If
    '        End If
    '    End If



    '    Return dv

    'Catch ex As Exception
    '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    'End Try
    'End Function
    Public Function InUpDe_factura_giro() As DataView
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGIROS.InUpDe_factura_giro", CommandType.StoredProcedure)
            db.AsignarParametro("OPE", OPE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDFACTURA", IDFACTURA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_RAZON_SOCIAL", RAZON_SOCIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_telefono", "@", OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_nu_docu_suna", NU_DOCU_SUNA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDDIRECCION_CONSIGNADO_REMI", IDDIRECCION_CONSIGNADO_REMI, OracleClient.OracleType.Number)
            db.AsignarParametro("P_DIRECCION_REMI", DIRECCION_REMI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRODOCUMENTO", NRODOCUMENTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDCONTACTO_PERSONA_DESTI", IDCONTACTO_PERSONA_DESTI, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NOMBRES_DESTI", NOMBRES_DESTI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDDIRECCION_CONSIGNADO_DESTI", IDDIRECCION_CONSIGNADO_DESTI, OracleClient.OracleType.Number)
            db.AsignarParametro("P_DIRECCION_DESTI", DIRECCION_DESTI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_telefono_desti", TELEFONO_DESTI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDFORMA_PAGO", IDFORMA_PAGO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDTIPO_MONEDA", IDTIPO_MONEDA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS_DESTINO", IDAGENCIAS_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDTIPO_GIRO", IDTIPO_GIRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDCONDI_GIRO", IDCONDI_GIRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FACTURA", FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_SERIE_FACTURA", SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRO_FACTURA", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_MEMO", MEMO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_MONTO_DESCUENTO", MONTO_DESCUENTO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_COSTO", TOTAL_COSTO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_MONTO_IMPUESTO", MONTO_IMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_MONTO_GIRADO", MONTO_GIRADO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_MONTO_BASE", MONTO_BASE, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDTIPO_ENTREGA", IDTIPO_ENTREGA, OracleClient.OracleType.Number)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Public Function SP_LIST_TOTAL_PASA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGIROS.SP_LIST_TOTAL_PASA_II"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_ini", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LIST_TOTAL_PASA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_LIST_TOTAL_PASA() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGIROS.SP_LIST_TOTAL_PASA_II", CommandType.StoredProcedure)
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_LIST_TOTAL_PASA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_CONSUL_CRUCE_BOLE_PASA(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGIROS.SP_CONSUL_CRUCE_BOLE_PASA"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_ini", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_CONSUL_CRUCE_BOLE_PASA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_CONSUL_CRUCE_BOLE_PASA() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGIROS.SP_CONSUL_CRUCE_BOLE_PASA", CommandType.StoredProcedure)
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_CONSUL_CRUCE_BOLE_PASA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_SELEC_CONTROL_GIROS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOVENTAGIROS.SP_SELEC_CONTROL_GIROS"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_CONTROL_GIROS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("MONTO_MAXIMO") Then MONTO_MAXIMO = dv.Table.Rows(0)("MONTO_MAXIMO") Else MONTO_MAXIMO = 0
    '        If Not dv.Table.Rows(0).IsNull("MONTO_MINIMO") Then MONTO_MINIMO = dv.Table.Rows(0)("MONTO_MINIMO") Else MONTO_MINIMO = 0
    '        If Not dv.Table.Rows(0).IsNull("MONTO_BASE") Then MONTO_BASE = dv.Table.Rows(0)("MONTO_BASE") Else MONTO_BASE = 0
    '        If Not dv.Table.Rows(0).IsNull("IDTIPO_TARIFAS_GIROS") Then IDTIPO_TARIFAS_GIROS = dv.Table.Rows(0)("IDTIPO_TARIFAS_GIROS") Else IDTIPO_TARIFAS_GIROS = ""
    '        If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL_MOD") Then IDUSUARIO_PERSONAL_MOD = dv.Table.Rows(0)("IDUSUARIO_PERSONAL_MOD") Else IDUSUARIO_PERSONAL_MOD = 0
    '        If Not dv.Table.Rows(0).IsNull("IDROL") Then IDROL = dv.Table.Rows(0)("IDROL") Else IDROL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDROL_MOD") Then IDROL_MOD = dv.Table.Rows(0)("IDROL_MOD") Else IDROL_MOD = 0
    '        If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '        If Not dv.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dv.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
    '        If Not dv.Table.Rows(0).IsNull("IP") Then IP = dv.Table.Rows(0)("IP") Else IP = ""
    '        If Not dv.Table.Rows(0).IsNull("IP_MOD") Then IP_MOD = dv.Table.Rows(0)("IP_MOD") Else IP_MOD = ""
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Function SP_SELEC_TARIFAS_GIROS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOVENTAGIROS.SP_SELEC_TARIFAS_GIROS"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_GIRADO", OracleClient.OracleType.Number)).Value = MONTO_GIRADO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_TARIFAS_GIROS", OracleClient.OracleType.VarChar)).Value = IDTIPO_TARIFAS_GIROS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_TARIFAS_GIROS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If dv.Count <= 0 Then
    '            MsgBox("No existe tarifas para este monto", MsgBoxStyle.Exclamation, "Seguridad del sistema..")
    '            Return False
    '        End If

    '        If Not dv.Table.Rows(0).IsNull("IDTARIFA_MONTO_GIRO") Then IDTARIFA_MONTO_GIRO = dv.Table.Rows(0)("IDTARIFA_MONTO_GIRO") Else IDTARIFA_MONTO_GIRO = 0
    '        If Not dv.Table.Rows(0).IsNull("IDTIPO_TARIFAS_GIROS") Then IDTIPO_TARIFAS_GIROS = dv.Table.Rows(0)("IDTIPO_TARIFAS_GIROS") Else IDTIPO_TARIFAS_GIROS = ""
    '        If Not dv.Table.Rows(0).IsNull("MONTO_INICIAL") Then MONTO_INICIAL = dv.Table.Rows(0)("MONTO_INICIAL") Else MONTO_INICIAL = 0
    '        If Not dv.Table.Rows(0).IsNull("MONTO_FINAL") Then MONTO_FINAL = dv.Table.Rows(0)("MONTO_FINAL") Else MONTO_FINAL = 0
    '        If Not dv.Table.Rows(0).IsNull("MONTO_FLETE") Then MONTO_FLETE = dv.Table.Rows(0)("MONTO_FLETE") Else MONTO_FLETE = 0
    '        If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL_MOD") Then IDUSUARIO_PERSONAL_MOD = dv.Table.Rows(0)("IDUSUARIO_PERSONAL_MOD") Else IDUSUARIO_PERSONAL_MOD = 0
    '        If Not dv.Table.Rows(0).IsNull("IDROL") Then IDROL = dv.Table.Rows(0)("IDROL") Else IDROL = 0
    '        If Not dv.Table.Rows(0).IsNull("IDROL_MOD") Then IDROL_MOD = dv.Table.Rows(0)("IDROL_MOD") Else IDROL_MOD = 0
    '        If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '        If Not dv.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dv.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
    '        If Not dv.Table.Rows(0).IsNull("IP") Then IP = dv.Table.Rows(0)("IP") Else IP = ""
    '        If Not dv.Table.Rows(0).IsNull("IP_MOD") Then IP_MOD = dv.Table.Rows(0)("IP_MOD") Else IP_MOD = ""
    '        Return True
    '    Catch
    '        Throw
    '    End Try
    'End Function
    'Public Function InUpDe_factura_giroII_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGIROS.InUpDe_factura_giroII"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OPE", OracleClient.OracleType.Double)).Value = OPE '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RAZON_SOCIAL", OracleClient.OracleType.NVarChar)).Value = RAZON_SOCIAL '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_telefono", OracleClient.OracleType.NVarChar)).Value = "@" 'TELEFONO 
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_nu_docu_suna", OracleClient.OracleType.NVarChar)).Value = NU_DOCU_SUNA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIRECCION_CONSIGNADO_REMI", OracleClient.OracleType.Number)).Value = IDDIRECCION_CONSIGNADO_REMI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_DIRECCION_REMI", OracleClient.OracleType.NVarChar)).Value = DIRECCION_REMI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRODOCUMENTO", OracleClient.OracleType.NVarChar)).Value = NRODOCUMENTO 'DOCUMENTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONTACTO_PERSONA_DESTI", OracleClient.OracleType.Number)).Value = IDCONTACTO_PERSONA_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NOMBRES_DESTI", OracleClient.OracleType.NVarChar)).Value = NOMBRES_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIRECCION_CONSIGNADO_DESTI", OracleClient.OracleType.Number)).Value = IDDIRECCION_CONSIGNADO_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_DIRECCION_DESTI", OracleClient.OracleType.NVarChar)).Value = DIRECCION_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_telefono_desti", OracleClient.OracleType.NVarChar)).Value = TELEFONO_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFORMA_PAGO", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MONEDA", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.Number)).Value = IDUNIDAD_ORIGEN '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_DESTINO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = IDAGENCIAS_DESTINO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.NVarChar)).Value = IP '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = IDROL_USUARIO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_GIRO", OracleClient.OracleType.NVarChar)).Value = IDTIPO_GIRO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONDI_GIRO", OracleClient.OracleType.NVarChar)).Value = IDCONDI_GIRO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FACTURA", OracleClient.OracleType.NVarChar)).Value = FECHA_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_SERIE_FACTURA", OracleClient.OracleType.NVarChar)).Value = SERIE_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_FACTURA", OracleClient.OracleType.NVarChar)).Value = NRO_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MEMO", OracleClient.OracleType.VarChar)).Value = MEMO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_DESCUENTO", OracleClient.OracleType.Double)).Value = MONTO_DESCUENTO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_COSTO", OracleClient.OracleType.Double)).Value = TOTAL_COSTO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_IMPUESTO", OracleClient.OracleType.Double)).Value = MONTO_IMPUESTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_GIRADO", OracleClient.OracleType.Double)).Value = MONTO_GIRADO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_BASE", OracleClient.OracleType.Double)).Value = MONTO_BASE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_ENTREGA", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA '
    '        '
    '        cmd.ExecuteNonQuery()
    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'IDFACTURA = dv.Table.Rows(0)(0)
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    'Dim DT As New DataTable
    '    'Dim Rst As New ADODB.Recordset
    '    'Dim dv As New DataView
    '    'Dim DA As New OleDb.OleDbDataAdapter
    '    'Dim m As Integer
    '    'Dim a As Integer = 0
    '    'Try
    '    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGIROS.InUpDe_factura_giro", 68, _
    '    '      OPE, 1, _
    '    'IDPERSONA, 1, _
    '    'RAZON_SOCIAL, 2, _
    '    'TELEFONO, 2, _
    '    'NU_DOCU_SUNA, 2, _
    '    'IDDIRECCION_CONSIGNADO_REMI, 1, _
    '    'DIRECCION_REMI, 1, _
    '    'NRODOCUMENTO, 2, _
    '    'IDCONTACTO_PERSONA_DESTI, 1, _
    '    'NOMBRES_DESTI, 2, _
    '    'IDDIRECCION_CONSIGNADO_DESTI, 1, _
    '    'DIRECCION_DESTI, 1, _
    '    'TELEFONO_DESTI, 2, _
    '    'IDFORMA_PAGO, 1, _
    '    'IDTIPO_MONEDA, 1, _
    '    'IDUNIDAD_ORIGEN, 1, _
    '    'IDUNIDAD_DESTINO, 1, _
    '    'IDAGENCIAS, 1, _
    '    'IDAGENCIAS_DESTINO, 1, _
    '    'IP, 2, _
    '    'IDUSUARIO_PERSONAL, 1, _
    '    'IDROL_USUARIO, 1, _
    '    'IDTIPO_GIRO, 1, _
    '    'IDCONDI_GIRO, 1, _
    '    'FECHA_FACTURA, 1, _
    '    'SERIE_FACTURA, 1, _
    '    'NRO_FACTURA, 1, _
    '    'MEMO, 1, _
    '    'MONTO_DESCUENTO, 1, _
    '    'TOTAL_COSTO, 1, _
    '    'MONTO_IMPUESTO, 1, _
    '    'MONTO_GIRADO, 1, _
    '    'MONTO_BASE}

    '    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)



    '    '    DA.Fill(DT, Rst)

    '    '    dv = DT.DefaultView

    '    '    If Not dv.Count = 0 Then
    '    '        If Not dv.Table.Rows(0).IsNull(0) Then
    '    '            If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '    '                m = 1 / a
    '    '            End If
    '    '        End If
    '    '    End If



    '    '    Return dv

    '    'Catch ex As Exception
    '    '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    'End Try
    'End Function
    'Public Function InUpDe_factura_giroIII_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGIROS2.InUpDe_factura_giroIII"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OPE", OracleClient.OracleType.Double)).Value = OPE '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RAZON_SOCIAL", OracleClient.OracleType.NVarChar)).Value = RAZON_SOCIAL '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_telefono", OracleClient.OracleType.NVarChar)).Value = TELEFONO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_nu_docu_suna", OracleClient.OracleType.NVarChar)).Value = NU_DOCU_SUNA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIRECCION_CONSIGNADO_REMI", OracleClient.OracleType.Number)).Value = IDDIRECCION_CONSIGNADO_REMI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_DIRECCION_REMI", OracleClient.OracleType.NVarChar)).Value = DIRECCION_REMI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRODOCUMENTO", OracleClient.OracleType.NVarChar)).Value = NRODOCUMENTO 'DOCUMENTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONTACTO_PERSONA_DESTI", OracleClient.OracleType.Number)).Value = IDCONTACTO_PERSONA_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NOMBRES_DESTI", OracleClient.OracleType.NVarChar)).Value = NOMBRES_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIRECCION_CONSIGNADO_DESTI", OracleClient.OracleType.Number)).Value = IDDIRECCION_CONSIGNADO_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_DIRECCION_DESTI", OracleClient.OracleType.NVarChar)).Value = DIRECCION_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_telefono_desti", OracleClient.OracleType.NVarChar)).Value = TELEFONO_DESTI '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFORMA_PAGO", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MONEDA", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.Number)).Value = IDUNIDAD_ORIGEN '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_DESTINO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = IDAGENCIAS_DESTINO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.NVarChar)).Value = IP '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = IDROL_USUARIO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_GIRO", OracleClient.OracleType.NVarChar)).Value = IDTIPO_GIRO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCONDI_GIRO", OracleClient.OracleType.NVarChar)).Value = IDCONDI_GIRO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FACTURA", OracleClient.OracleType.NVarChar)).Value = FECHA_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_SERIE_FACTURA", OracleClient.OracleType.NVarChar)).Value = SERIE_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_FACTURA", OracleClient.OracleType.NVarChar)).Value = NRO_FACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MEMO", OracleClient.OracleType.VarChar)).Value = MEMO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_DESCUENTO", OracleClient.OracleType.Double)).Value = MONTO_DESCUENTO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_COSTO", OracleClient.OracleType.Double)).Value = TOTAL_COSTO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_IMPUESTO", OracleClient.OracleType.Double)).Value = MONTO_IMPUESTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_GIRADO", OracleClient.OracleType.Double)).Value = MONTO_GIRADO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_BASE", OracleClient.OracleType.Double)).Value = MONTO_BASE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_ENTREGA", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_TARIFAS_GIROS", OracleClient.OracleType.VarChar, 4)).Value = IDTIPO_TARIFAS_GIROS '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_password_giro", OracleClient.OracleType.VarChar, 15)).Value = PASSWORD_GIRO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_pregunta_giro", OracleClient.OracleType.VarChar, 50)).Value = pregunta_giro '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_respuesta_giro", OracleClient.OracleType.VarChar, 50)).Value = respuesta_giro '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_respuesta_entre_giro", OracleClient.OracleType.VarChar, 50)).Value = respuesta_entre_giro '
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_solicitud_giros", OracleClient.OracleType.VarChar, 12)).Value = nro_solicitud_giros '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_DNI_RESPONSABLE", OracleClient.OracleType.VarChar, 15)).Value = DNI_RESPONSABLE '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_NOMBRE_RESPONSABLE", OracleClient.OracleType.VarChar, 100)).Value = NOMBRE_RESPONSABLE '
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idtipo_Pago", OracleClient.OracleType.Number)).Value = IDTIPO_PAGO '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idtarjetas", OracleClient.OracleType.Number)).Value = IDTARJETAS '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Nrotarjeta", OracleClient.OracleType.VarChar, 15)).Value = NROTARJETA '
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idtipo_Comprobante", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oMsg", OracleClient.OracleType.VarChar, 500)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oCodigo", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oIDPERSONA", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("oMsg").Value Is DBNull.Value Then
    '            MsgBox(cmd.Parameters("oMsg").Value, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End If

    '        If Not cmd.Parameters("oIDPERSONA").Value Is DBNull.Value Then
    '            IDPERSONA = cmd.Parameters("oIDPERSONA").Value
    '        End If

    '        If cmd.Parameters("oCodigo").Value = 0 Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    'Dim DT As New DataTable
    '    'Dim Rst As New ADODB.Recordset
    '    'Dim dv As New DataView
    '    'Dim DA As New OleDb.OleDbDataAdapter
    '    'Dim m As Integer

    '    'Dim a As Integer = 0


    '    'Try

    '    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGIROS.InUpDe_factura_giro", 68, _
    '    '      OPE, 1, _
    '    'IDPERSONA, 1, _
    '    'RAZON_SOCIAL, 2, _
    '    'TELEFONO, 2, _
    '    'NU_DOCU_SUNA, 2, _
    '    'IDDIRECCION_CONSIGNADO_REMI, 1, _
    '    'DIRECCION_REMI, 1, _
    '    'NRODOCUMENTO, 2, _
    '    'IDCONTACTO_PERSONA_DESTI, 1, _
    '    'NOMBRES_DESTI, 2, _
    '    'IDDIRECCION_CONSIGNADO_DESTI, 1, _
    '    'DIRECCION_DESTI, 1, _
    '    'TELEFONO_DESTI, 2, _
    '    'IDFORMA_PAGO, 1, _
    '    'IDTIPO_MONEDA, 1, _
    '    'IDUNIDAD_ORIGEN, 1, _
    '    'IDUNIDAD_DESTINO, 1, _
    '    'IDAGENCIAS, 1, _
    '    'IDAGENCIAS_DESTINO, 1, _
    '    'IP, 2, _
    '    'IDUSUARIO_PERSONAL, 1, _
    '    'IDROL_USUARIO, 1, _
    '    'IDTIPO_GIRO, 1, _
    '    'IDCONDI_GIRO, 1, _
    '    'FECHA_FACTURA, 1, _
    '    'SERIE_FACTURA, 1, _
    '    'NRO_FACTURA, 1, _
    '    'MEMO, 1, _
    '    'MONTO_DESCUENTO, 1, _
    '    'TOTAL_COSTO, 1, _
    '    'MONTO_IMPUESTO, 1, _
    '    'MONTO_GIRADO, 1, _
    '    'MONTO_BASE}

    '    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)



    '    '    DA.Fill(DT, Rst)

    '    '    dv = DT.DefaultView

    '    '    If Not dv.Count = 0 Then
    '    '        If Not dv.Table.Rows(0).IsNull(0) Then
    '    '            If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '    '                m = 1 / a
    '    '            End If
    '    '        End If
    '    '    End If



    '    '    Return dv

    '    'Catch ex As Exception
    '    '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    'End Try
    'End Function
    'Public Function sp_entrega_giro_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGIROS2.sp_entrega_giro"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idfactura", OracleClient.OracleType.Number)).Value = IDFACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_doc_entrega", OracleClient.OracleType.VarChar)).Value = DOC_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_nombre_entrega", OracleClient.OracleType.VarChar)).Value = NOMBRE_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ENTREGA", OracleClient.OracleType.VarChar)).Value = FECHA_ENTREGA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_obs", OracleClient.OracleType.VarChar)).Value = OBS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_hora_entrega", OracleClient.OracleType.VarChar)).Value = HORA_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_ENTREGA", OracleClient.OracleType.VarChar)).Value = IDUSUARIO_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oMsg", OracleClient.OracleType.VarChar, 500)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oCodigo", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("oMsg").Value Is DBNull.Value Then
    '            MsgBox(cmd.Parameters("oMsg").Value, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End If

    '        If Not cmd.Parameters("oCodigo").Value = 1 Then
    '            Return False
    '        Else
    '            Return True
    '        End If


    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'IDFACTURA = dv.Table.Rows(0)(0)
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_entrega_giroII_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGIROS2.sp_entrega_giroII"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ENTRE_DEVO", OracleClient.OracleType.VarChar, 4)).Value = ENTRE_DEVO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idfactura", OracleClient.OracleType.Number)).Value = IDFACTURA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_doc_entrega", OracleClient.OracleType.VarChar)).Value = DOC_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_nombre_entrega", OracleClient.OracleType.VarChar)).Value = NOMBRE_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ENTREGA", OracleClient.OracleType.VarChar)).Value = FECHA_ENTREGA '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_obs", OracleClient.OracleType.VarChar)).Value = OBS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_hora_entrega", OracleClient.OracleType.VarChar)).Value = HORA_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_ENTREGA", OracleClient.OracleType.VarChar)).Value = IDUSUARIO_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oMsg", OracleClient.OracleType.VarChar, 500)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oCodigo", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("oMsg").Value Is DBNull.Value Then
    '            MsgBox(cmd.Parameters("oMsg").Value, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End If

    '        If Not cmd.Parameters("oCodigo").Value = 1 Then
    '            Return False
    '        Else
    '            Return True
    '        End If


    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)


    '        'Dim dv As New DataView

    '        'dv = ds.Tables(0).DefaultView

    '        'IDFACTURA = dv.Table.Rows(0)(0)

    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Sub SP_OBTENER_HASH_MD5_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure

    '        cmd.CommandText = "SP_OBTENER_HASH_MD5"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TEXTO", OracleClient.OracleType.VarChar, 32)).Value = HASH_MD5
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OP_HASH_MD5", OracleClient.OracleType.VarChar, 32)).Direction = ParameterDirection.Output


    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("OP_HASH_MD5").Value Is DBNull.Value Then
    '            HASH_MD5 = cmd.Parameters("OP_HASH_MD5").Value
    '        End If
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    'Public Sub SP_BUSCA_SOLICITUD_GIRO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGIROS2.SP_BUSCA_SOLICITUD_GIRO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_SOLICITUD_GIROS", OracleClient.OracleType.Number)).Value = CType(nro_solicitud_giros, Long)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OFLAG_SOLICITUD_ENCONTRADA", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        FLAG_SOLICITUD_ENCONTRADA = cmd.Parameters("OFLAG_SOLICITUD_ENCONTRADA").Value
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    'Public Sub SP_BUSCA_LIQUIDACIONES_PEND_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCIERRE_LIQUIDACIONES.SP_BUSCA_LIQUIDACIONES_PEND"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar, 10)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar, 10)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_DOCUMENTOS", OracleClient.OracleType.VarChar, 32767)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("oP_DOCUMENTOS").Value Is DBNull.Value Then
    '            MsgBox(cmd.Parameters("oP_DOCUMENTOS").Value, MsgBoxStyle.Information, "Seguridad del sistema...")
    '        End If

    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_BUSCA_LIQUIDACIONES_PEND()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_BUSCA_LIQUIDACIONES_PEND", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oP_DOCUMENTOS", 32767, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.EjecutarComando()
            If db.Parametros.Length > 0 Then
                If Not db.Parametros(1) Is DBNull.Value Then
                    MsgBox(db.Parametros(1), MsgBoxStyle.Information, "Seguridad del sistema...")
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class

