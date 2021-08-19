Public Class dtoProgracion_Recojo

    Dim MyIDAGENCIAS As Long
    Dim MyIDDISTRITO As Long
    Dim MyNOMBRE_AGENCIA As String
    Dim MyNOMBRE_CONTACTO_APEMAT As String
    Dim MyNOMBRE_CONTACTO As String
    Dim MyCELULAR As String
    Dim MyTELEFONO1 As String
    Dim MyTELEFONO2 As String
    Dim MyFAX1 As String
    Dim MyFAX2 As String
    Dim MyRPM2 As String
    Dim MyFECHA_REGISTRO As String
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyNOMBRE_CORTO As String
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyIDTIPO_COMI_AGEN As String
    Dim MyIDAGENCIAS_COMI As Long
    Dim MyCODAGENCIA As String
    Dim MyDIRECCION_AGENCIA As String
    Dim MyCODIGO_AGENCIA As String
    Dim MyTIPO_BOLE_IMPRE As String
    Dim MyTIPO_FACTU_IMPRE As String
    Dim MyES_TERMINAL As Long
    Dim MyDEFECTO As Long
    Dim MyFECHA_NACIMIENTO As String
    Dim MyIDCONTACTO_PERSONA As Long
    Dim MyIDTIPO_CONTACTO As Long
    Dim MyIDPERSONA As Long
    Dim MyAPEPAT As String
    Dim MyAPEMAT As String
    Dim MyEMAIL_CONTACTO As String
    Dim MyIDDIRECCION_CONSIGNADO As Long
    Dim MyIDTIPO_DIRECCION As Long
    Dim MyDE_REFERENCIA As String
    Dim MyDIRECCION_FACTURACION As Long
    Dim MyHORA_RECOJO_INICIO As String
    Dim MyHORA_RECOJO_FIN As String
    Dim MyHORA_ENTREGA_FIN As String
    Dim MyFECHA_ACTUALZIACION As String
    Dim MyDSITRITO As String
    Dim MyCANTIDAD_ENTRE_DOMI As Long
    Dim MyCANTIDAD_PENDI_DOMI As Long
    Dim MyCANTIDAD_TOTAL As Long
    Dim MyCANTIDAD_DESPACHADO As Long
    Dim MyMONTO_GIRADO As Double
    Dim MyFECHA_BLOQUEO As String
    Dim MyFECHA_ENTREGA_HISTORICO As String
    Dim MyIDTIPO_ENTREGA As Long
    Dim MyFECHA_DEVOLUCION As String
    Dim MyIDTARJETAS As Long
    Dim MyMONTO_SUB_TOTAL As Double
    Dim MyMONTO_BASE As Double
    Dim MyIDLIQUI_TURNOS As Long
    Dim MyFECHA_RECEPCION_DESTINO As String
    Dim MyFECHA_CARGOS As String
    Dim MyEXPORTADO As Long
    Dim MyIDUSUARIO_ENTREGA As Long
    Dim MyHORA_ENTREGA As String
    Dim MyIDDESCUENTO_GIRO As String
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyNRO_FACTURA As String
    Dim MyMONTO_IMPUESTO As Double
    Dim MyTOTAL_COSTO As Double
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDCIUDAD_TRANSITO As Long
    Dim MyTOTAL_VOLUMEN As Double
    Dim MyIDGUIA_TRANSPORTISTA_UPD As Long
    Dim MyIDUNIDAD_ORIGEN As Long
    Dim MyIDUNIDAD_DESTINO As Long
    Dim MyMONTO_TIPO_CAMBIO As Double
    Dim MyIDTIPO_MONEDA As Long
    Dim MyIDTIPO_SERVICIO_GIRO As Long
    Dim MyFECHA_VENCIMIENTO As String
    Dim MyMEMO As String
    Dim MyIDPERSONA_ORIGEN As Long
    Dim MyIDPERSONA_DESTINO As Long
    Dim MyFECHA_REGISTRO_ACTUALIZACION As String
    Dim MyIMPRESO As Long
    Dim MyFECHA_CARGO As String
    Dim MyCANTIDAD_X_VOLUMEN As Double
    Dim MyPRECIO_X_PESO As Double
    Dim MyPRECIO_X_UNIDAD As Double
    Dim MyLIQUIDADO As Double
    Dim MyFECHA_CIERRE As String
    Dim MyIDTEFONO_REMITENTE As Long
    Dim MyMONTO_DESCUENTO As Double
    Dim MyREF_IDFACTURA As Long
    Dim MyPORCENT_DEVOLUCION As Double
    Dim MyCARGO_DOC As Long
    Dim MyIDUSUARIO_CARGO As Long
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Long
    Dim MyIDTIPO_ENTREGA_CARGA As Long
    Dim MyIDTARIFAS_CARGA As Long
    Dim MyIDARTICULOS As Long
    Dim MyIDFACTURA_CREDITO As Long
    Dim MyIDUSUARIO_REVISION As Long
    Dim MyIDIMPUESTO As Long
    Dim MyIDCONTACTO_DESTINATARIO As Long
    Dim MyCANTIDAD_X_UNIDAD_VOLUMEN As Double
    Dim MyNRO_REF_GUIA As String
    Dim MyID_REMITENTE As Long
    Dim MyCANTIDAD_SOBRES As Long
    Dim MyPRECIO_SOBRES As Double
    Dim MySELECCIONAR_TO_FACTURA As Long
    Dim MyIDMOTIVOS_NO_ATENCION As Long
    Dim MyTIPO_OPERACION As String
    Dim MyPORCENTAGE_DESCUENTO As Double
    Dim MyLOGIN As String
    Dim MyGERENTE_GENERAL As String
    Dim MyFECHA_INGRESO As String
    Dim MyPAGO_POST_FACTURACION As Long
    Dim MyEMAIL As String
    Dim MyAPELLIDO_MATERNO As String
    Dim MyNOMPRE_PERSONA1 As String
    Dim MySEXO_PERSONA As String
    Dim MyESMENOREDAD As Long
    Dim MyAGENTE_RETENCION As Long
    Dim MyIDCLASIFICACION_PERSONA As Long
    Dim MyIDSOLICITUD_RECOJO_CARGA As Long
    Dim MyNOMBRE_CLIENTE_LLAMADA As String
    Dim MyNRO_PAQUETES As Long
    Dim MyPESO_KG_RECOJIDOS As Double
    Dim MyCIERRE_SOLICITUD As Long
    Dim MyVOLUMEN As Double
    Dim MyIDTIPO_OBSERVACION As Double
    Dim MyIDUNIDAD_TRANSPORTE As Long
    Dim MyATENDIDO As String
    Dim MyHORA_ATENCION As String
    Dim MyROL_USUARIO As String
    'Dim MyFECHA_ACTUALIZACION As NO_DEFINIDO
    Dim MyORDENAR_FISCA As Long
    Dim MyORDERNAR_FISCA_LIQUI As Double
    Dim MyPLACA As String
    Dim MyIDRESPONSABLE As Long
    Dim MyIDTIPO_UNIDAD_TRANSPORTE As Long
    Dim MyNRO_PISOS As Long
    Dim MyNRO_TELEVISORES As Long
    Dim MyPESO_MAXIMO_CARGA_KG As Double
    Dim MyCERTIFICA_HABILITA_VEH As String
    Dim MyCAPACIDAD As Long
    Dim MyNRO_LICENCIA As String
    Dim MyFAX As String
    Dim MyIDUSUARIO_MODIFICADOR As Long
    Dim MyID_COMI_FUNCI As String
    Dim MyTRABAJA_EN As String
    Dim MyNRODOC As String
    Dim MyIDTIPO_USUARIO_PERSONAL As Long
    Dim MyIDAREA_SISTEMA As Long
    Dim MyIDSEXO As Long
    Dim MyIDUBIGEO As Long
    Dim MyIDESTADO_CIVIL As Long
    Dim MyIDPROVINCIA As Long
    Dim MyIDDEPARTAMENTO As Long
    Dim MyIDPAIS As Long
    Dim MyIDAGENCIA_CONCESIONARIOS As Long
    Dim MyNOMBRE_CONTACTO_APEPAT As String
    Dim MyE_MAIL As String
    Dim MyRPM1 As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIP As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIPMOD As String
    Dim MyNU_DOCU_SUNA As String
    Dim MyIDEMPRESAS_CONCESION As Long
    Dim MyIDAGENCIAS_UNIX As Long
    Dim MyTIPO_GUIA_TRANSPOR_IMPRE As String
    Dim MyESTADO_REGISTRO As Long
    Dim MyTELEFONO As String
    Dim MyDATOS_PERSONALES As String
    Dim MyNOMBRES As String
    Dim MyIDTIPO_DOCUMENTO_CONTACTO As Long
    Dim MyNRODOCUMENTO As String
    Dim MySEXO As String
    Dim MyIDDIAS_SEMANA As Long
    Dim MyDIA_SEMANA As String
    Dim MyDIRECCION As String
    Dim MyCO_UBIC_GEOG As String
    Dim MyCODIGO_UBIGEO As String
    Dim MyHORA_ENTREGA_INICIO As String
    'Dim MyESTADO_REGISTRO As String
    Dim MyIDPROCESOS As Long
    Dim MyTOTAL_PESO_X_ARTICULO As Double
    Dim MyIDCONDI_GIRO As String
    Dim MyTELE_DESTI As String
    Dim MyOBS As String
    Dim MyCANTIDAD_X_ARTICULO As Double
    Dim MyMONTO_RECARGO As Double
    Dim MyBILLETE_DE_PAGO As Double
    Dim MyCONTROL_CONTABLE As Long
    Dim MyIDREMITENTE As Long
    'Dim MyFECHA_ACTUALIZACION As String
    Dim MyCONCEPTO_CONTROL As String
    Dim MyIDLIQUIDAQCION_OFICINA As Long
    Dim MyFECHA_ANULACION As String
    Dim MyIDUSUARIO_ANULACION As Long
    Dim MyIDUSUARIO_DEVOLUCION As Long
    Dim MyIDROL_ANULACION As Long
    Dim MyIDROL_DEVOLUCION As Long
    Dim MyIDTIPO_PAGO As Long
    Dim MyNROTARJETA As String
    Dim MyPRECIO_X_SOBRE As Double
    Dim MyIDCONTACTO_DESTINO As Long
    Dim MyFECHA_DESPACHO As String
    Dim MyFECHA_ENTREGA As String
    Dim MyNOMBRE_ENTREGA As String
    Dim MyDOC_ENTREGA As String
    Dim MyIDROL_ENTREGA As Long
    Dim MyFECHA_REVISION As String
    Dim MyFECHA_RECOJO As String
    Dim MyCALCU_COMI As Long
    Dim MyCALCU_COMI_FUNCI As Long
    Dim MyIDTIPO_GIRO As String
    Dim MyIDFACTURA As Long
    Dim MySERIE_FACTURA As String
    'Dim MyFECHA_REGISTRO As String
    Dim MyIDESTADO_ENVIO As Long
    Dim MyIDESTADO_FACTURA As Long
    Dim MyCANTIDAD_X_PESO As Long
    Dim MyTOTAL_PESO As Double
    Dim MyIDGUIA_TRANSPORTISTA As Long
    Dim MyIDDIREECION_ORIGEN As Long
    Dim MyIDDIREECION_DESTINO As Long
    Dim MyFECHA_FACTURA As String
    Dim MyCARGO As Double
    Dim MyCANTIDAD_X_SOBRE As Double
    Dim MyPRECIO_X_VOLUMEN As Double
    Dim MyIDAGENCIAS_DESTINO As Long
    Dim MyIDTEFONO_CONSIGNADO As Long
    Dim MyMONTO_PENALIDAD As Double
    Dim MyIDFUNCIONARIO_AUTORIZACION As Long
    Dim MyIGV As Double
    Dim MyPORCENT_DESCUENTO As Double
    Dim MyFECHA_DOC As String
    Dim MyIP_CARGO As String
    Dim MyIMPUESTO As Double
    Dim MyIDGUIAS_ENVIO_REF As Long
    Dim MyIDGUIAS_ENVIO As Long
    Dim MyFECHA_GUIA As String
    Dim MyNRO_GUIA As String
    Dim MyIDDIRECCION_DESTINATARIO As Long
    Dim MyIDCONTACTO_REMITENTE As Long
    Dim MyIDTARIFAS_CARGA_CLIENTE As Long
    Dim MyCANTIDAD As Long
    Dim MyNOMBRE_RECOJO As String
    Dim MyIDPREFACTURA As Long
    Dim MyIDROL_REVISION As Long
    Dim MySERIE_GUIA_ENVIO As Long
    Dim MyIDDIRECCION_REMITENTE As Long
    Dim MyCANTIDAD_X_UNIDAD_ARTI As Double
    Dim MyIDCIERRES_LIQUIDACIONES As Long
    'Dim MyCARGO As Long
    Dim MyFACTURADO As Long
    Dim MyTOTAL_ARTICULO As Double
    Dim MyIDCENTRO_COSTO As Long
    Dim MyIDSINO_SOBRES As Long
    'Dim MyEXPORTADO As Double
    Dim MyMOTIVOS_NO_ATENCION As String
    Dim MyFECHA_ANTIGUEDAD_COMISION As String
    Dim MyFECHA_ANTI_COMI As String
    'Dim MyMONTO_BASE As Long
    Dim MyPASSWORD As String
    Dim MyIDTIPO_PERSONA As Long
    Dim MyCODIGO_CLIENTE As String
    Dim MyCLIENTE_CORPORATIVO As Long
    Dim MyRAZON_SOCIAL As String
    Dim MyREPRESENTANTE_LEGAL As String
    Dim MyAPELLIDO_PATERNO As String
    Dim MyNOMPRE_PERSONA As String
    Dim MyIDTIPO_DOC_IDENTIDAD As Long
    Dim MyNU_RETE_SUNA As String
    Dim MyIDRUBRO As Long
    Dim MyIDTIPO_FACTURACION As Long
    Dim MyHORA_INI As String
    Dim MyHORA_FIN As String
    Dim MyPESO_KG As Double
    Dim MyOBSERVACION As String
    Dim MyIDPERSONA_RECOJO As Double
    Dim MyNRO_PAQUETES_RECOJIDOS As Long
    Dim MyIDESTADO_RECOJO As Long
    'Dim MyFECHA_CIERRE As NO_DEFINIDO
    Dim MyVOLUMEN_RECOGIDO As Double
    Dim MyIDRUTA_ENTREGA_RECOJO As Long
    Dim MyAPROBADO As Long
    Dim MyDESTINO As String
    Dim MyNRO_GUIA_ENVIO As String
    Dim MyIDCOMPROBANTE As Long
    Dim MyIDMODULO As Long
    Dim MyIDOPERACION_CARGA As Long
    Dim MyNOMBRE_RUTA_ENTREGA_RECOJO As String
    'Dim MyFECHA_REGISTRO As NO_DEFINIDO
    Dim MyTIPO_COMPROBANTE As String
    Dim MyAFEC_COMI As Double
    Dim MyCUENTA As String
    Dim MyTIPO_COMPROBANTE_COMISION As String
    'Dim MyIDTIPO_OBSERVACION As Long
    'Dim MyIPMOD As Long
    Dim MyNRO_UNIDAD_TRANSPORTE As Long
    Dim MyNRO_EJES As Long
    Dim MyIDMODELO_UNIDAD As Long
    Dim MyPESO_VEHICULO_TONELADAS As Double
    Dim MyNRO_BANIOS As Long
    Dim MyRPM As String
    Dim MyNOMPER As String
    Dim MyIDUSUARIO_CREADOR As Long
    Dim MyIDROL_CREADOR As Long
    'Dim MyFOTO As NO_DEFINIDO
    Public Property IDAGENCIAS() As Long

        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = Value
        End Set
    End Property
    Public Property IDPROVINCIA() As Long

        Get
            IDPROVINCIA = MyIDPROVINCIA
        End Get
        Set(ByVal value As Long)
            MyIDPROVINCIA = Value
        End Set
    End Property
    Public Property IDDEPARTAMENTO() As Long

        Get
            IDDEPARTAMENTO = MyIDDEPARTAMENTO
        End Get
        Set(ByVal value As Long)
            MyIDDEPARTAMENTO = Value
        End Set
    End Property
    Public Property IDAGENCIA_CONCESIONARIOS() As Long

        Get
            IDAGENCIA_CONCESIONARIOS = MyIDAGENCIA_CONCESIONARIOS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIA_CONCESIONARIOS = Value
        End Set
    End Property
    Public Property NOMBRE_CONTACTO_APEPAT() As String

        Get
            NOMBRE_CONTACTO_APEPAT = MyNOMBRE_CONTACTO_APEPAT
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CONTACTO_APEPAT = Value
        End Set
    End Property
    Public Property TELEFONO1() As String

        Get
            TELEFONO1 = MyTELEFONO1
        End Get
        Set(ByVal value As String)
            MyTELEFONO1 = Value
        End Set
    End Property
    Public Property TELEFONO2() As String

        Get
            TELEFONO2 = MyTELEFONO2
        End Get
        Set(ByVal value As String)
            MyTELEFONO2 = Value
        End Set
    End Property
    Public Property FAX2() As String

        Get
            FAX2 = MyFAX2
        End Get
        Set(ByVal value As String)
            MyFAX2 = Value
        End Set
    End Property
    Public Property E_MAIL() As String

        Get
            E_MAIL = MyE_MAIL
        End Get
        Set(ByVal value As String)
            MyE_MAIL = Value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Long

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = Value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String

        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = Value
        End Set
    End Property
    Public Property FECHA_ACTUALIZACION() As String

        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = Value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Long

        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = Value
        End Set
    End Property
    Public Property NOMBRE_CORTO() As String

        Get
            NOMBRE_CORTO = MyNOMBRE_CORTO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CORTO = Value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Long

        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONALMOD = Value
        End Set
    End Property
    'Public Property IPMOD() As String

    '    Get
    '        IPMOD = MyIPMOD
    '    End Get
    '    Set(ByVal value As String)
    '        MyIPMOD = Value
    '    End Set
    'End Property
    Public Property IDUNIDAD_AGENCIA() As Long

        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = Value
        End Set
    End Property
    Public Property IDTIPO_COMI_AGEN() As String

        Get
            IDTIPO_COMI_AGEN = MyIDTIPO_COMI_AGEN
        End Get
        Set(ByVal value As String)
            MyIDTIPO_COMI_AGEN = Value
        End Set
    End Property
    Public Property IDAGENCIAS_COMI() As Long

        Get
            IDAGENCIAS_COMI = MyIDAGENCIAS_COMI
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_COMI = Value
        End Set
    End Property
    Public Property CODAGENCIA() As String

        Get
            CODAGENCIA = MyCODAGENCIA
        End Get
        Set(ByVal value As String)
            MyCODAGENCIA = Value
        End Set
    End Property
    Public Property DIRECCION_AGENCIA() As String

        Get
            DIRECCION_AGENCIA = MyDIRECCION_AGENCIA
        End Get
        Set(ByVal value As String)
            MyDIRECCION_AGENCIA = Value
        End Set
    End Property
    Public Property IDEMPRESAS_CONCESION() As Long

        Get
            IDEMPRESAS_CONCESION = MyIDEMPRESAS_CONCESION
        End Get
        Set(ByVal value As Long)
            MyIDEMPRESAS_CONCESION = Value
        End Set
    End Property
    Public Property CODIGO_AGENCIA() As String

        Get
            CODIGO_AGENCIA = MyCODIGO_AGENCIA
        End Get
        Set(ByVal value As String)
            MyCODIGO_AGENCIA = Value
        End Set
    End Property
    Public Property IDAGENCIAS_UNIX() As Long

        Get
            IDAGENCIAS_UNIX = MyIDAGENCIAS_UNIX
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_UNIX = Value
        End Set
    End Property
    Public Property TIPO_FACTU_IMPRE() As String

        Get
            TIPO_FACTU_IMPRE = MyTIPO_FACTU_IMPRE
        End Get
        Set(ByVal value As String)
            MyTIPO_FACTU_IMPRE = Value
        End Set
    End Property
    Public Property TIPO_GUIA_TRANSPOR_IMPRE() As String

        Get
            TIPO_GUIA_TRANSPOR_IMPRE = MyTIPO_GUIA_TRANSPOR_IMPRE
        End Get
        Set(ByVal value As String)
            MyTIPO_GUIA_TRANSPOR_IMPRE = Value
        End Set
    End Property
    Public Property ES_TERMINAL() As Long

        Get
            ES_TERMINAL = MyES_TERMINAL
        End Get
        Set(ByVal value As Long)
            MyES_TERMINAL = Value
        End Set
    End Property
    'Public Property ESTADO_REGISTRO() As Long

    '    Get
    '        ESTADO_REGISTRO = MyESTADO_REGISTRO
    '    End Get
    '    Set(ByVal value As Long)
    '        MyESTADO_REGISTRO = Value
    '    End Set
    'End Property
    Public Property TELEFONO() As String

        Get
            TELEFONO = MyTELEFONO
        End Get
        Set(ByVal value As String)
            MyTELEFONO = Value
        End Set
    End Property
    Public Property FECHA_NACIMIENTO() As String

        Get
            FECHA_NACIMIENTO = MyFECHA_NACIMIENTO
        End Get
        Set(ByVal value As String)
            MyFECHA_NACIMIENTO = Value
        End Set
    End Property
    Public Property IDTIPO_CONTACTO() As Long

        Get
            IDTIPO_CONTACTO = MyIDTIPO_CONTACTO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_CONTACTO = Value
        End Set
    End Property
    Public Property IDPERSONA() As Long

        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = Value
        End Set
    End Property
    Public Property NOMBRES() As String

        Get
            NOMBRES = MyNOMBRES
        End Get
        Set(ByVal value As String)
            MyNOMBRES = Value
        End Set
    End Property
    Public Property APEPAT() As String

        Get
            APEPAT = MyAPEPAT
        End Get
        Set(ByVal value As String)
            MyAPEPAT = Value
        End Set
    End Property
    Public Property APEMAT() As String

        Get
            APEMAT = MyAPEMAT
        End Get
        Set(ByVal value As String)
            MyAPEMAT = Value
        End Set
    End Property
    Public Property EMAIL_CONTACTO() As String

        Get
            EMAIL_CONTACTO = MyEMAIL_CONTACTO
        End Get
        Set(ByVal value As String)
            MyEMAIL_CONTACTO = Value
        End Set
    End Property
    Public Property SEXO() As String

        Get
            SEXO = MySEXO
        End Get
        Set(ByVal value As String)
            MySEXO = Value
        End Set
    End Property
    Public Property IDTIPO_DIRECCION() As Long

        Get
            IDTIPO_DIRECCION = MyIDTIPO_DIRECCION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_DIRECCION = Value
        End Set
    End Property
    Public Property DE_REFERENCIA() As String

        Get
            DE_REFERENCIA = MyDE_REFERENCIA
        End Get
        Set(ByVal value As String)
            MyDE_REFERENCIA = Value
        End Set
    End Property
    Public Property CO_UBIC_GEOG() As String

        Get
            CO_UBIC_GEOG = MyCO_UBIC_GEOG
        End Get
        Set(ByVal value As String)
            MyCO_UBIC_GEOG = Value
        End Set
    End Property
    Public Property DIRECCION_FACTURACION() As Long

        Get
            DIRECCION_FACTURACION = MyDIRECCION_FACTURACION
        End Get
        Set(ByVal value As Long)
            MyDIRECCION_FACTURACION = Value
        End Set
    End Property
    Public Property CODIGO_UBIGEO() As String

        Get
            CODIGO_UBIGEO = MyCODIGO_UBIGEO
        End Get
        Set(ByVal value As String)
            MyCODIGO_UBIGEO = Value
        End Set
    End Property
    Public Property HORA_ENTREGA_INICIO() As String

        Get
            HORA_ENTREGA_INICIO = MyHORA_ENTREGA_INICIO
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA_INICIO = Value
        End Set
    End Property
    Public Property FECHA_ACTUALZIACION() As String

        Get
            FECHA_ACTUALZIACION = MyFECHA_ACTUALZIACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALZIACION = Value
        End Set
    End Property
    Public Property DSITRITO() As String

        Get
            DSITRITO = MyDSITRITO
        End Get
        Set(ByVal value As String)
            MyDSITRITO = Value
        End Set
    End Property
    Public Property ESTADO_REGISTRO() As String

        Get
            ESTADO_REGISTRO = MyESTADO_REGISTRO
        End Get
        Set(ByVal value As String)
            MyESTADO_REGISTRO = Value
        End Set
    End Property
    Public Property CANTIDAD_ENTRE_DOMI() As Long

        Get
            CANTIDAD_ENTRE_DOMI = MyCANTIDAD_ENTRE_DOMI
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_ENTRE_DOMI = Value
        End Set
    End Property
    Public Property CANTIDAD_PENDI_DOMI() As Long

        Get
            CANTIDAD_PENDI_DOMI = MyCANTIDAD_PENDI_DOMI
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_PENDI_DOMI = Value
        End Set
    End Property
    Public Property TOTAL_PESO_X_ARTICULO() As Double

        Get
            TOTAL_PESO_X_ARTICULO = MyTOTAL_PESO_X_ARTICULO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_PESO_X_ARTICULO = Value
        End Set
    End Property
    Public Property MONTO_GIRADO() As Double

        Get
            MONTO_GIRADO = MyMONTO_GIRADO
        End Get
        Set(ByVal value As Double)
            MyMONTO_GIRADO = Value
        End Set
    End Property
    Public Property TELE_DESTI() As String

        Get
            TELE_DESTI = MyTELE_DESTI
        End Get
        Set(ByVal value As String)
            MyTELE_DESTI = Value
        End Set
    End Property
    Public Property FECHA_ENTREGA_HISTORICO() As String

        Get
            FECHA_ENTREGA_HISTORICO = MyFECHA_ENTREGA_HISTORICO
        End Get
        Set(ByVal value As String)
            MyFECHA_ENTREGA_HISTORICO = Value
        End Set
    End Property
    Public Property CANTIDAD_X_ARTICULO() As Double

        Get
            CANTIDAD_X_ARTICULO = MyCANTIDAD_X_ARTICULO
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_ARTICULO = Value
        End Set
    End Property
    Public Property MONTO_RECARGO() As Double

        Get
            MONTO_RECARGO = MyMONTO_RECARGO
        End Get
        Set(ByVal value As Double)
            MyMONTO_RECARGO = Value
        End Set
    End Property
    Public Property BILLETE_DE_PAGO() As Double

        Get
            BILLETE_DE_PAGO = MyBILLETE_DE_PAGO
        End Get
        Set(ByVal value As Double)
            MyBILLETE_DE_PAGO = Value
        End Set
    End Property
    Public Property CONTROL_CONTABLE() As Long

        Get
            CONTROL_CONTABLE = MyCONTROL_CONTABLE
        End Get
        Set(ByVal value As Long)
            MyCONTROL_CONTABLE = Value
        End Set
    End Property
    Public Property IDREMITENTE() As Long

        Get
            IDREMITENTE = MyIDREMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDREMITENTE = Value
        End Set
    End Property
    Public Property CONCEPTO_CONTROL() As String

        Get
            CONCEPTO_CONTROL = MyCONCEPTO_CONTROL
        End Get
        Set(ByVal value As String)
            MyCONCEPTO_CONTROL = Value
        End Set
    End Property
    Public Property IDTIPO_ENTREGA() As Long

        Get
            IDTIPO_ENTREGA = MyIDTIPO_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_ENTREGA = Value
        End Set
    End Property
    Public Property FECHA_DEVOLUCION() As String

        Get
            FECHA_DEVOLUCION = MyFECHA_DEVOLUCION
        End Get
        Set(ByVal value As String)
            MyFECHA_DEVOLUCION = Value
        End Set
    End Property
    Public Property IDUSUARIO_DEVOLUCION() As Long

        Get
            IDUSUARIO_DEVOLUCION = MyIDUSUARIO_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_DEVOLUCION = Value
        End Set
    End Property
    Public Property IDROL_ANULACION() As Long

        Get
            IDROL_ANULACION = MyIDROL_ANULACION
        End Get
        Set(ByVal value As Long)
            MyIDROL_ANULACION = Value
        End Set
    End Property
    Public Property NROTARJETA() As String

        Get
            NROTARJETA = MyNROTARJETA
        End Get
        Set(ByVal value As String)
            MyNROTARJETA = Value
        End Set
    End Property
    Public Property IDCONTACTO_DESTINO() As Long

        Get
            IDCONTACTO_DESTINO = MyIDCONTACTO_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_DESTINO = Value
        End Set
    End Property
    'Public Property MONTO_BASE() As Double

    '    Get
    '        MONTO_BASE = MyMONTO_BASE
    '    End Get
    '    Set(ByVal value As Double)
    '        MyMONTO_BASE = Value
    '    End Set
    'End Property
    Public Property IDLIQUI_TURNOS() As Long

        Get
            IDLIQUI_TURNOS = MyIDLIQUI_TURNOS
        End Get
        Set(ByVal value As Long)
            MyIDLIQUI_TURNOS = Value
        End Set
    End Property
    Public Property FECHA_DESPACHO() As String

        Get
            FECHA_DESPACHO = MyFECHA_DESPACHO
        End Get
        Set(ByVal value As String)
            MyFECHA_DESPACHO = Value
        End Set
    End Property
    Public Property FECHA_ENTREGA() As String

        Get
            FECHA_ENTREGA = MyFECHA_ENTREGA
        End Get
        Set(ByVal value As String)
            MyFECHA_ENTREGA = Value
        End Set
    End Property
    'Public Property EXPORTADO() As Long

    '    Get
    '        EXPORTADO = MyEXPORTADO
    '    End Get
    '    Set(ByVal value As Long)
    '        MyEXPORTADO = Value
    '    End Set
    'End Property
    Public Property NOMBRE_ENTREGA() As String

        Get
            NOMBRE_ENTREGA = MyNOMBRE_ENTREGA
        End Get
        Set(ByVal value As String)
            MyNOMBRE_ENTREGA = Value
        End Set
    End Property
    Public Property IDUSUARIO_ENTREGA() As Long

        Get
            IDUSUARIO_ENTREGA = MyIDUSUARIO_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_ENTREGA = Value
        End Set
    End Property
    Public Property FECHA_REVISION() As String

        Get
            FECHA_REVISION = MyFECHA_REVISION
        End Get
        Set(ByVal value As String)
            MyFECHA_REVISION = Value
        End Set
    End Property
    Public Property FECHA_RECOJO() As String

        Get
            FECHA_RECOJO = MyFECHA_RECOJO
        End Get
        Set(ByVal value As String)
            MyFECHA_RECOJO = Value
        End Set
    End Property
    Public Property CALCU_COMI() As Long

        Get
            CALCU_COMI = MyCALCU_COMI
        End Get
        Set(ByVal value As Long)
            MyCALCU_COMI = Value
        End Set
    End Property
    Public Property IDDESCUENTO_GIRO() As String

        Get
            IDDESCUENTO_GIRO = MyIDDESCUENTO_GIRO
        End Get
        Set(ByVal value As String)
            MyIDDESCUENTO_GIRO = Value
        End Set
    End Property
    Public Property IDFORMA_PAGO() As Long

        Get
            IDFORMA_PAGO = MyIDFORMA_PAGO
        End Get
        Set(ByVal value As Long)
            MyIDFORMA_PAGO = Value
        End Set
    End Property
    Public Property IDESTADO_ENVIO() As Long

        Get
            IDESTADO_ENVIO = MyIDESTADO_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_ENVIO = Value
        End Set
    End Property
    Public Property IDESTADO_FACTURA() As Long

        Get
            IDESTADO_FACTURA = MyIDESTADO_FACTURA
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_FACTURA = Value
        End Set
    End Property
    Public Property IDCIUDAD_TRANSITO() As Long

        Get
            IDCIUDAD_TRANSITO = MyIDCIUDAD_TRANSITO
        End Get
        Set(ByVal value As Long)
            MyIDCIUDAD_TRANSITO = Value
        End Set
    End Property
    Public Property CANTIDAD_X_PESO() As Long

        Get
            CANTIDAD_X_PESO = MyCANTIDAD_X_PESO
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_X_PESO = Value
        End Set
    End Property
    Public Property TOTAL_VOLUMEN() As Double

        Get
            TOTAL_VOLUMEN = MyTOTAL_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyTOTAL_VOLUMEN = Value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA() As Long

        Get
            IDGUIA_TRANSPORTISTA = MyIDGUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA = Value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA_UPD() As Long

        Get
            IDGUIA_TRANSPORTISTA_UPD = MyIDGUIA_TRANSPORTISTA_UPD
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA_UPD = Value
        End Set
    End Property
    Public Property IDUNIDAD_ORIGEN() As Long

        Get
            IDUNIDAD_ORIGEN = MyIDUNIDAD_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_ORIGEN = Value
        End Set
    End Property
    Public Property IDDIREECION_ORIGEN() As Long

        Get
            IDDIREECION_ORIGEN = MyIDDIREECION_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDDIREECION_ORIGEN = Value
        End Set
    End Property
    Public Property IDDIREECION_DESTINO() As Long

        Get
            IDDIREECION_DESTINO = MyIDDIREECION_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDDIREECION_DESTINO = Value
        End Set
    End Property
    Public Property MONTO_TIPO_CAMBIO() As Double

        Get
            MONTO_TIPO_CAMBIO = MyMONTO_TIPO_CAMBIO
        End Get
        Set(ByVal value As Double)
            MyMONTO_TIPO_CAMBIO = Value
        End Set
    End Property
    Public Property IDTIPO_SERVICIO_GIRO() As Long

        Get
            IDTIPO_SERVICIO_GIRO = MyIDTIPO_SERVICIO_GIRO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_SERVICIO_GIRO = Value
        End Set
    End Property
    Public Property IDPERSONA_ORIGEN() As Long

        Get
            IDPERSONA_ORIGEN = MyIDPERSONA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA_ORIGEN = Value
        End Set
    End Property
    Public Property IDPERSONA_DESTINO() As Long

        Get
            IDPERSONA_DESTINO = MyIDPERSONA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA_DESTINO = Value
        End Set
    End Property
    Public Property FECHA_REGISTRO_ACTUALIZACION() As String

        Get
            FECHA_REGISTRO_ACTUALIZACION = MyFECHA_REGISTRO_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO_ACTUALIZACION = Value
        End Set
    End Property
    Public Property IMPRESO() As Long

        Get
            IMPRESO = MyIMPRESO
        End Get
        Set(ByVal value As Long)
            MyIMPRESO = Value
        End Set
    End Property
    Public Property FECHA_CARGO() As String

        Get
            FECHA_CARGO = MyFECHA_CARGO
        End Get
        Set(ByVal value As String)
            MyFECHA_CARGO = Value
        End Set
    End Property
    'Public Property CARGO() As Double

    '    Get
    '        CARGO = MyCARGO
    '    End Get
    '    Set(ByVal value As Double)
    '        MyCARGO = Value
    '    End Set
    'End Property
    Public Property CANTIDAD_X_SOBRE() As Double

        Get
            CANTIDAD_X_SOBRE = MyCANTIDAD_X_SOBRE
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_SOBRE = Value
        End Set
    End Property
    Public Property PRECIO_X_PESO() As Double

        Get
            PRECIO_X_PESO = MyPRECIO_X_PESO
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_PESO = Value
        End Set
    End Property
    Public Property LIQUIDADO() As Double

        Get
            LIQUIDADO = MyLIQUIDADO
        End Get
        Set(ByVal value As Double)
            MyLIQUIDADO = Value
        End Set
    End Property
    Public Property IDTEFONO_REMITENTE() As Long

        Get
            IDTEFONO_REMITENTE = MyIDTEFONO_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDTEFONO_REMITENTE = Value
        End Set
    End Property
    Public Property IDTEFONO_CONSIGNADO() As Long

        Get
            IDTEFONO_CONSIGNADO = MyIDTEFONO_CONSIGNADO
        End Get
        Set(ByVal value As Long)
            MyIDTEFONO_CONSIGNADO = Value
        End Set
    End Property
    Public Property MONTO_DESCUENTO() As Double

        Get
            MONTO_DESCUENTO = MyMONTO_DESCUENTO
        End Get
        Set(ByVal value As Double)
            MyMONTO_DESCUENTO = Value
        End Set
    End Property
    Public Property IDFUNCIONARIO_AUTORIZACION() As Long

        Get
            IDFUNCIONARIO_AUTORIZACION = MyIDFUNCIONARIO_AUTORIZACION
        End Get
        Set(ByVal value As Long)
            MyIDFUNCIONARIO_AUTORIZACION = Value
        End Set
    End Property
    Public Property IGV() As Double

        Get
            IGV = MyIGV
        End Get
        Set(ByVal value As Double)
            MyIGV = Value
        End Set
    End Property
    Public Property CARGO_DOC() As Long

        Get
            CARGO_DOC = MyCARGO_DOC
        End Get
        Set(ByVal value As Long)
            MyCARGO_DOC = Value
        End Set
    End Property
    Public Property FECHA_DOC() As String

        Get
            FECHA_DOC = MyFECHA_DOC
        End Get
        Set(ByVal value As String)
            MyFECHA_DOC = Value
        End Set
    End Property
    Public Property IDUSUARIO_CARGO() As Long

        Get
            IDUSUARIO_CARGO = MyIDUSUARIO_CARGO
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_CARGO = Value
        End Set
    End Property
    Public Property IP_CARGO() As String

        Get
            IP_CARGO = MyIP_CARGO
        End Get
        Set(ByVal value As String)
            MyIP_CARGO = Value
        End Set
    End Property
    Public Property IMPUESTO() As Double

        Get
            IMPUESTO = MyIMPUESTO
        End Get
        Set(ByVal value As Double)
            MyIMPUESTO = Value
        End Set
    End Property
    Public Property IDGUIAS_ENVIO() As Long

        Get
            IDGUIAS_ENVIO = MyIDGUIAS_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDGUIAS_ENVIO = Value
        End Set
    End Property
    Public Property FECHA_GUIA() As String

        Get
            FECHA_GUIA = MyFECHA_GUIA
        End Get
        Set(ByVal value As String)
            MyFECHA_GUIA = Value
        End Set
    End Property
    Public Property NRO_GUIA() As String

        Get
            NRO_GUIA = MyNRO_GUIA
        End Get
        Set(ByVal value As String)
            MyNRO_GUIA = Value
        End Set
    End Property
    Public Property IDTARIFAS_CARGA_CLIENTE() As Long

        Get
            IDTARIFAS_CARGA_CLIENTE = MyIDTARIFAS_CARGA_CLIENTE
        End Get
        Set(ByVal value As Long)
            MyIDTARIFAS_CARGA_CLIENTE = Value
        End Set
    End Property
    Public Property CANTIDAD() As Long

        Get
            CANTIDAD = MyCANTIDAD
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD = Value
        End Set
    End Property
    Public Property NOMBRE_RECOJO() As String

        Get
            NOMBRE_RECOJO = MyNOMBRE_RECOJO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_RECOJO = Value
        End Set
    End Property
    Public Property IDPREFACTURA() As Long

        Get
            IDPREFACTURA = MyIDPREFACTURA
        End Get
        Set(ByVal value As Long)
            MyIDPREFACTURA = Value
        End Set
    End Property
    Public Property IDUSUARIO_REVISION() As Long

        Get
            IDUSUARIO_REVISION = MyIDUSUARIO_REVISION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_REVISION = Value
        End Set
    End Property
    Public Property IDROL_REVISION() As Long

        Get
            IDROL_REVISION = MyIDROL_REVISION
        End Get
        Set(ByVal value As Long)
            MyIDROL_REVISION = Value
        End Set
    End Property
    Public Property IDIMPUESTO() As Long

        Get
            IDIMPUESTO = MyIDIMPUESTO
        End Get
        Set(ByVal value As Long)
            MyIDIMPUESTO = Value
        End Set
    End Property
    Public Property IDDIRECCION_REMITENTE() As Long

        Get
            IDDIRECCION_REMITENTE = MyIDDIRECCION_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_REMITENTE = Value
        End Set
    End Property
    Public Property IDCONTACTO_DESTINATARIO() As Long

        Get
            IDCONTACTO_DESTINATARIO = MyIDCONTACTO_DESTINATARIO
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_DESTINATARIO = Value
        End Set
    End Property
    Public Property CANTIDAD_X_UNIDAD_VOLUMEN() As Double

        Get
            CANTIDAD_X_UNIDAD_VOLUMEN = MyCANTIDAD_X_UNIDAD_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_UNIDAD_VOLUMEN = Value
        End Set
    End Property
    Public Property FACTURADO() As Long

        Get
            FACTURADO = MyFACTURADO
        End Get
        Set(ByVal value As Long)
            MyFACTURADO = Value
        End Set
    End Property
    Public Property ID_REMITENTE() As Long

        Get
            ID_REMITENTE = MyID_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyID_REMITENTE = Value
        End Set
    End Property
    Public Property IDCENTRO_COSTO() As Long

        Get
            IDCENTRO_COSTO = MyIDCENTRO_COSTO
        End Get
        Set(ByVal value As Long)
            MyIDCENTRO_COSTO = Value
        End Set
    End Property
    Public Property IDSINO_SOBRES() As Long

        Get
            IDSINO_SOBRES = MyIDSINO_SOBRES
        End Get
        Set(ByVal value As Long)
            MyIDSINO_SOBRES = Value
        End Set
    End Property
    Public Property SELECCIONAR_TO_FACTURA() As Long

        Get
            SELECCIONAR_TO_FACTURA = MySELECCIONAR_TO_FACTURA
        End Get
        Set(ByVal value As Long)
            MySELECCIONAR_TO_FACTURA = Value
        End Set
    End Property
    Public Property IDMOTIVOS_NO_ATENCION() As Long

        Get
            IDMOTIVOS_NO_ATENCION = MyIDMOTIVOS_NO_ATENCION
        End Get
        Set(ByVal value As Long)
            MyIDMOTIVOS_NO_ATENCION = Value
        End Set
    End Property
    Public Property TIPO_OPERACION() As String

        Get
            TIPO_OPERACION = MyTIPO_OPERACION
        End Get
        Set(ByVal value As String)
            MyTIPO_OPERACION = Value
        End Set
    End Property
    Public Property FECHA_ANTI_COMI() As String

        Get
            FECHA_ANTI_COMI = MyFECHA_ANTI_COMI
        End Get
        Set(ByVal value As String)
            MyFECHA_ANTI_COMI = Value
        End Set
    End Property
    Public Property PASSWORD() As String

        Get
            PASSWORD = MyPASSWORD
        End Get
        Set(ByVal value As String)
            MyPASSWORD = Value
        End Set
    End Property
    Public Property CODIGO_CLIENTE() As String

        Get
            CODIGO_CLIENTE = MyCODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            MyCODIGO_CLIENTE = Value
        End Set
    End Property
    Public Property CLIENTE_CORPORATIVO() As Long

        Get
            CLIENTE_CORPORATIVO = MyCLIENTE_CORPORATIVO
        End Get
        Set(ByVal value As Long)
            MyCLIENTE_CORPORATIVO = Value
        End Set
    End Property
    Public Property GERENTE_GENERAL() As String

        Get
            GERENTE_GENERAL = MyGERENTE_GENERAL
        End Get
        Set(ByVal value As String)
            MyGERENTE_GENERAL = Value
        End Set
    End Property
    Public Property FECHA_INGRESO() As String

        Get
            FECHA_INGRESO = MyFECHA_INGRESO
        End Get
        Set(ByVal value As String)
            MyFECHA_INGRESO = Value
        End Set
    End Property
    Public Property APELLIDO_PATERNO() As String

        Get
            APELLIDO_PATERNO = MyAPELLIDO_PATERNO
        End Get
        Set(ByVal value As String)
            MyAPELLIDO_PATERNO = Value
        End Set
    End Property
    Public Property APELLIDO_MATERNO() As String

        Get
            APELLIDO_MATERNO = MyAPELLIDO_MATERNO
        End Get
        Set(ByVal value As String)
            MyAPELLIDO_MATERNO = Value
        End Set
    End Property
    Public Property NOMPRE_PERSONA1() As String

        Get
            NOMPRE_PERSONA1 = MyNOMPRE_PERSONA1
        End Get
        Set(ByVal value As String)
            MyNOMPRE_PERSONA1 = Value
        End Set
    End Property
    Public Property ESMENOREDAD() As Long

        Get
            ESMENOREDAD = MyESMENOREDAD
        End Get
        Set(ByVal value As Long)
            MyESMENOREDAD = Value
        End Set
    End Property
    Public Property IDTIPO_DOC_IDENTIDAD() As Long

        Get
            IDTIPO_DOC_IDENTIDAD = MyIDTIPO_DOC_IDENTIDAD
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_DOC_IDENTIDAD = Value
        End Set
    End Property
    Public Property NU_RETE_SUNA() As String

        Get
            NU_RETE_SUNA = MyNU_RETE_SUNA
        End Get
        Set(ByVal value As String)
            MyNU_RETE_SUNA = Value
        End Set
    End Property
    Public Property IDRUBRO() As Long

        Get
            IDRUBRO = MyIDRUBRO
        End Get
        Set(ByVal value As Long)
            MyIDRUBRO = Value
        End Set
    End Property
    Public Property IDCLASIFICACION_PERSONA() As Long

        Get
            IDCLASIFICACION_PERSONA = MyIDCLASIFICACION_PERSONA
        End Get
        Set(ByVal value As Long)
            MyIDCLASIFICACION_PERSONA = Value
        End Set
    End Property
    Public Property IDTIPO_FACTURACION() As Long

        Get
            IDTIPO_FACTURACION = MyIDTIPO_FACTURACION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_FACTURACION = Value
        End Set
    End Property
    Public Property NRO_PAQUETES() As Long

        Get
            NRO_PAQUETES = MyNRO_PAQUETES
        End Get
        Set(ByVal value As Long)
            MyNRO_PAQUETES = Value
        End Set
    End Property
    Public Property PESO_KG() As Double

        Get
            PESO_KG = MyPESO_KG
        End Get
        Set(ByVal value As Double)
            MyPESO_KG = Value
        End Set
    End Property
    Public Property OBSERVACION() As String

        Get
            OBSERVACION = MyOBSERVACION
        End Get
        Set(ByVal value As String)
            MyOBSERVACION = Value
        End Set
    End Property
    Public Property NRO_PAQUETES_RECOJIDOS() As Long

        Get
            NRO_PAQUETES_RECOJIDOS = MyNRO_PAQUETES_RECOJIDOS
        End Get
        Set(ByVal value As Long)
            MyNRO_PAQUETES_RECOJIDOS = Value
        End Set
    End Property
    Public Property PESO_KG_RECOJIDOS() As Double

        Get
            PESO_KG_RECOJIDOS = MyPESO_KG_RECOJIDOS
        End Get
        Set(ByVal value As Double)
            MyPESO_KG_RECOJIDOS = Value
        End Set
    End Property
    Public Property IDESTADO_RECOJO() As Long

        Get
            IDESTADO_RECOJO = MyIDESTADO_RECOJO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_RECOJO = Value
        End Set
    End Property
    'Public Property FECHA_CIERRE() As NO_DEFINIDO

    '    Get
    '        FECHA_CIERRE = MyFECHA_CIERRE
    '    End Get
    '    Set(ByVal value As NO_DEFINIDO)
    '        MyFECHA_CIERRE = Value
    '    End Set
    'End Property
    Public Property CIERRE_SOLICITUD() As Long

        Get
            CIERRE_SOLICITUD = MyCIERRE_SOLICITUD
        End Get
        Set(ByVal value As Long)
            MyCIERRE_SOLICITUD = Value
        End Set
    End Property
    Public Property IDRUTA_ENTREGA_RECOJO() As Long

        Get
            IDRUTA_ENTREGA_RECOJO = MyIDRUTA_ENTREGA_RECOJO
        End Get
        Set(ByVal value As Long)
            MyIDRUTA_ENTREGA_RECOJO = Value
        End Set
    End Property
    Public Property ATENDIDO() As String

        Get
            ATENDIDO = MyATENDIDO
        End Get
        Set(ByVal value As String)
            MyATENDIDO = Value
        End Set
    End Property
    Public Property HORA_ATENCION() As String

        Get
            HORA_ATENCION = MyHORA_ATENCION
        End Get
        Set(ByVal value As String)
            MyHORA_ATENCION = Value
        End Set
    End Property
    Public Property IDCOMPROBANTE() As Long

        Get
            IDCOMPROBANTE = MyIDCOMPROBANTE
        End Get
        Set(ByVal value As Long)
            MyIDCOMPROBANTE = Value
        End Set
    End Property
    Public Property ROL_USUARIO() As String

        Get
            ROL_USUARIO = MyROL_USUARIO
        End Get
        Set(ByVal value As String)
            MyROL_USUARIO = Value
        End Set
    End Property
    Public Property IDMODULO() As Long

        Get
            IDMODULO = MyIDMODULO
        End Get
        Set(ByVal value As Long)
            MyIDMODULO = Value
        End Set
    End Property
    Public Property IDOPERACION_CARGA() As Long

        Get
            IDOPERACION_CARGA = MyIDOPERACION_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDOPERACION_CARGA = Value
        End Set
    End Property
    'Public Property FECHA_REGISTRO() As NO_DEFINIDO

    '    Get
    '        FECHA_REGISTRO = MyFECHA_REGISTRO
    '    End Get
    '    Set(ByVal value As NO_DEFINIDO)
    '        MyFECHA_REGISTRO = Value
    '    End Set
    'End Property
    Public Property TIPO_COMPROBANTE() As String

        Get
            TIPO_COMPROBANTE = MyTIPO_COMPROBANTE
        End Get
        Set(ByVal value As String)
            MyTIPO_COMPROBANTE = Value
        End Set
    End Property
    Public Property AFEC_COMI() As Double

        Get
            AFEC_COMI = MyAFEC_COMI
        End Get
        Set(ByVal value As Double)
            MyAFEC_COMI = Value
        End Set
    End Property
    Public Property PLACA() As String

        Get
            PLACA = MyPLACA
        End Get
        Set(ByVal value As String)
            MyPLACA = Value
        End Set
    End Property
    Public Property NRO_EJES() As Long

        Get
            NRO_EJES = MyNRO_EJES
        End Get
        Set(ByVal value As Long)
            MyNRO_EJES = Value
        End Set
    End Property
    Public Property IDMODELO_UNIDAD() As Long

        Get
            IDMODELO_UNIDAD = MyIDMODELO_UNIDAD
        End Get
        Set(ByVal value As Long)
            MyIDMODELO_UNIDAD = Value
        End Set
    End Property
    Public Property NRO_PISOS() As Long

        Get
            NRO_PISOS = MyNRO_PISOS
        End Get
        Set(ByVal value As Long)
            MyNRO_PISOS = Value
        End Set
    End Property
    Public Property NRO_BANIOS() As Long

        Get
            NRO_BANIOS = MyNRO_BANIOS
        End Get
        Set(ByVal value As Long)
            MyNRO_BANIOS = Value
        End Set
    End Property
    Public Property PESO_MAXIMO_CARGA_KG() As Double

        Get
            PESO_MAXIMO_CARGA_KG = MyPESO_MAXIMO_CARGA_KG
        End Get
        Set(ByVal value As Double)
            MyPESO_MAXIMO_CARGA_KG = Value
        End Set
    End Property
    Public Property ID_COMI_FUNCI() As String

        Get
            ID_COMI_FUNCI = MyID_COMI_FUNCI
        End Get
        Set(ByVal value As String)
            MyID_COMI_FUNCI = Value
        End Set
    End Property
    Public Property TRABAJA_EN() As String

        Get
            TRABAJA_EN = MyTRABAJA_EN
        End Get
        Set(ByVal value As String)
            MyTRABAJA_EN = Value
        End Set
    End Property
    Public Property NOMPER() As String

        Get
            NOMPER = MyNOMPER
        End Get
        Set(ByVal value As String)
            MyNOMPER = Value
        End Set
    End Property
    Public Property NRODOC() As String

        Get
            NRODOC = MyNRODOC
        End Get
        Set(ByVal value As String)
            MyNRODOC = Value
        End Set
    End Property
    Public Property IDUSUARIO_CREADOR() As Long

        Get
            IDUSUARIO_CREADOR = MyIDUSUARIO_CREADOR
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_CREADOR = Value
        End Set
    End Property
    Public Property IDROL_CREADOR() As Long

        Get
            IDROL_CREADOR = MyIDROL_CREADOR
        End Get
        Set(ByVal value As Long)
            MyIDROL_CREADOR = Value
        End Set
    End Property
    Public Property IDSEXO() As Long

        Get
            IDSEXO = MyIDSEXO
        End Get
        Set(ByVal value As Long)
            MyIDSEXO = Value
        End Set
    End Property
    Public Property IDUBIGEO() As Long

        Get
            IDUBIGEO = MyIDUBIGEO
        End Get
        Set(ByVal value As Long)
            MyIDUBIGEO = Value
        End Set
    End Property
    Public Property IDESTADO_CIVIL() As Long

        Get
            IDESTADO_CIVIL = MyIDESTADO_CIVIL
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_CIVIL = Value
        End Set
    End Property
    'Public Property FOTO() As NO_DEFINIDO

    '    Get
    '        FOTO = MyFOTO
    '    End Get
    '    Set(ByVal value As NO_DEFINIDO)
    '        MyFOTO = Value
    '    End Set
    'End Property
    Public Property IDDISTRITO() As Long

        Get
            IDDISTRITO = MyIDDISTRITO
        End Get
        Set(ByVal value As Long)
            MyIDDISTRITO = Value
        End Set
    End Property
    Public Property IDPAIS() As Long

        Get
            IDPAIS = MyIDPAIS
        End Get
        Set(ByVal value As Long)
            MyIDPAIS = Value
        End Set
    End Property
    Public Property NOMBRE_AGENCIA() As String

        Get
            NOMBRE_AGENCIA = MyNOMBRE_AGENCIA
        End Get
        Set(ByVal value As String)
            MyNOMBRE_AGENCIA = Value
        End Set
    End Property
    Public Property NOMBRE_CONTACTO_APEMAT() As String

        Get
            NOMBRE_CONTACTO_APEMAT = MyNOMBRE_CONTACTO_APEMAT
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CONTACTO_APEMAT = Value
        End Set
    End Property
    Public Property NOMBRE_CONTACTO() As String

        Get
            NOMBRE_CONTACTO = MyNOMBRE_CONTACTO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CONTACTO = Value
        End Set
    End Property
    Public Property CELULAR() As String

        Get
            CELULAR = MyCELULAR
        End Get
        Set(ByVal value As String)
            MyCELULAR = Value
        End Set
    End Property
    Public Property FAX1() As String

        Get
            FAX1 = MyFAX1
        End Get
        Set(ByVal value As String)
            MyFAX1 = Value
        End Set
    End Property
    Public Property RPM1() As String

        Get
            RPM1 = MyRPM1
        End Get
        Set(ByVal value As String)
            MyRPM1 = Value
        End Set
    End Property
    Public Property RPM2() As String

        Get
            RPM2 = MyRPM2
        End Get
        Set(ByVal value As String)
            MyRPM2 = Value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Long

        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIO = Value
        End Set
    End Property
    Public Property IP() As String

        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = Value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Long

        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIOMOD = Value
        End Set
    End Property
    Public Property NU_DOCU_SUNA() As String

        Get
            NU_DOCU_SUNA = MyNU_DOCU_SUNA
        End Get
        Set(ByVal value As String)
            MyNU_DOCU_SUNA = Value
        End Set
    End Property
    Public Property TIPO_BOLE_IMPRE() As String

        Get
            TIPO_BOLE_IMPRE = MyTIPO_BOLE_IMPRE
        End Get
        Set(ByVal value As String)
            MyTIPO_BOLE_IMPRE = Value
        End Set
    End Property
    Public Property DATOS_PERSONALES() As String

        Get
            DATOS_PERSONALES = MyDATOS_PERSONALES
        End Get
        Set(ByVal value As String)
            MyDATOS_PERSONALES = Value
        End Set
    End Property
    Public Property DEFECTO() As Long

        Get
            DEFECTO = MyDEFECTO
        End Get
        Set(ByVal value As Long)
            MyDEFECTO = Value
        End Set
    End Property
    Public Property IDCONTACTO_PERSONA() As Long

        Get
            IDCONTACTO_PERSONA = MyIDCONTACTO_PERSONA
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_PERSONA = Value
        End Set
    End Property
    Public Property IDTIPO_DOCUMENTO_CONTACTO() As Long

        Get
            IDTIPO_DOCUMENTO_CONTACTO = MyIDTIPO_DOCUMENTO_CONTACTO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_DOCUMENTO_CONTACTO = Value
        End Set
    End Property
    Public Property NRODOCUMENTO() As String

        Get
            NRODOCUMENTO = MyNRODOCUMENTO
        End Get
        Set(ByVal value As String)
            MyNRODOCUMENTO = Value
        End Set
    End Property
    Public Property IDDIAS_SEMANA() As Long

        Get
            IDDIAS_SEMANA = MyIDDIAS_SEMANA
        End Get
        Set(ByVal value As Long)
            MyIDDIAS_SEMANA = Value
        End Set
    End Property
    Public Property DIA_SEMANA() As String

        Get
            DIA_SEMANA = MyDIA_SEMANA
        End Get
        Set(ByVal value As String)
            MyDIA_SEMANA = Value
        End Set
    End Property
    Public Property IDDIRECCION_CONSIGNADO() As Long

        Get
            IDDIRECCION_CONSIGNADO = MyIDDIRECCION_CONSIGNADO
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_CONSIGNADO = Value
        End Set
    End Property
    Public Property DIRECCION() As String

        Get
            DIRECCION = MyDIRECCION
        End Get
        Set(ByVal value As String)
            MyDIRECCION = Value
        End Set
    End Property
    Public Property HORA_RECOJO_INICIO() As String

        Get
            HORA_RECOJO_INICIO = MyHORA_RECOJO_INICIO
        End Get
        Set(ByVal value As String)
            MyHORA_RECOJO_INICIO = Value
        End Set
    End Property
    Public Property HORA_RECOJO_FIN() As String

        Get
            HORA_RECOJO_FIN = MyHORA_RECOJO_FIN
        End Get
        Set(ByVal value As String)
            MyHORA_RECOJO_FIN = Value
        End Set
    End Property
    Public Property HORA_ENTREGA_FIN() As String

        Get
            HORA_ENTREGA_FIN = MyHORA_ENTREGA_FIN
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA_FIN = Value
        End Set
    End Property
    Public Property IDPROCESOS() As Long

        Get
            IDPROCESOS = MyIDPROCESOS
        End Get
        Set(ByVal value As Long)
            MyIDPROCESOS = Value
        End Set
    End Property
    Public Property CANTIDAD_TOTAL() As Long

        Get
            CANTIDAD_TOTAL = MyCANTIDAD_TOTAL
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_TOTAL = Value
        End Set
    End Property
    Public Property CANTIDAD_DESPACHADO() As Long

        Get
            CANTIDAD_DESPACHADO = MyCANTIDAD_DESPACHADO
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_DESPACHADO = Value
        End Set
    End Property
    Public Property IDCONDI_GIRO() As String

        Get
            IDCONDI_GIRO = MyIDCONDI_GIRO
        End Get
        Set(ByVal value As String)
            MyIDCONDI_GIRO = Value
        End Set
    End Property
    Public Property FECHA_BLOQUEO() As String

        Get
            FECHA_BLOQUEO = MyFECHA_BLOQUEO
        End Get
        Set(ByVal value As String)
            MyFECHA_BLOQUEO = Value
        End Set
    End Property
    Public Property OBS() As String

        Get
            OBS = MyOBS
        End Get
        Set(ByVal value As String)
            MyOBS = Value
        End Set
    End Property
    Public Property IDLIQUIDAQCION_OFICINA() As Long

        Get
            IDLIQUIDAQCION_OFICINA = MyIDLIQUIDAQCION_OFICINA
        End Get
        Set(ByVal value As Long)
            MyIDLIQUIDAQCION_OFICINA = Value
        End Set
    End Property
    Public Property FECHA_ANULACION() As String

        Get
            FECHA_ANULACION = MyFECHA_ANULACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ANULACION = Value
        End Set
    End Property
    Public Property IDUSUARIO_ANULACION() As Long

        Get
            IDUSUARIO_ANULACION = MyIDUSUARIO_ANULACION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_ANULACION = Value
        End Set
    End Property
    Public Property IDROL_DEVOLUCION() As Long

        Get
            IDROL_DEVOLUCION = MyIDROL_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyIDROL_DEVOLUCION = Value
        End Set
    End Property
    Public Property IDTARJETAS() As Long

        Get
            IDTARJETAS = MyIDTARJETAS
        End Get
        Set(ByVal value As Long)
            MyIDTARJETAS = Value
        End Set
    End Property
    Public Property IDTIPO_PAGO() As Long

        Get
            IDTIPO_PAGO = MyIDTIPO_PAGO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_PAGO = Value
        End Set
    End Property
    Public Property PRECIO_X_SOBRE() As Double

        Get
            PRECIO_X_SOBRE = MyPRECIO_X_SOBRE
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_SOBRE = Value
        End Set
    End Property
    Public Property MONTO_SUB_TOTAL() As Double

        Get
            MONTO_SUB_TOTAL = MyMONTO_SUB_TOTAL
        End Get
        Set(ByVal value As Double)
            MyMONTO_SUB_TOTAL = Value
        End Set
    End Property
    Public Property FECHA_RECEPCION_DESTINO() As String

        Get
            FECHA_RECEPCION_DESTINO = MyFECHA_RECEPCION_DESTINO
        End Get
        Set(ByVal value As String)
            MyFECHA_RECEPCION_DESTINO = Value
        End Set
    End Property
    Public Property FECHA_CARGOS() As String

        Get
            FECHA_CARGOS = MyFECHA_CARGOS
        End Get
        Set(ByVal value As String)
            MyFECHA_CARGOS = Value
        End Set
    End Property
    Public Property DOC_ENTREGA() As String

        Get
            DOC_ENTREGA = MyDOC_ENTREGA
        End Get
        Set(ByVal value As String)
            MyDOC_ENTREGA = Value
        End Set
    End Property
    Public Property IDROL_ENTREGA() As Long

        Get
            IDROL_ENTREGA = MyIDROL_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDROL_ENTREGA = Value
        End Set
    End Property
    Public Property HORA_ENTREGA() As String

        Get
            HORA_ENTREGA = MyHORA_ENTREGA
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA = Value
        End Set
    End Property
    Public Property CALCU_COMI_FUNCI() As Long

        Get
            CALCU_COMI_FUNCI = MyCALCU_COMI_FUNCI
        End Get
        Set(ByVal value As Long)
            MyCALCU_COMI_FUNCI = Value
        End Set
    End Property
    Public Property IDTIPO_GIRO() As String

        Get
            IDTIPO_GIRO = MyIDTIPO_GIRO
        End Get
        Set(ByVal value As String)
            MyIDTIPO_GIRO = Value
        End Set
    End Property
    Public Property IDFACTURA() As Long

        Get
            IDFACTURA = MyIDFACTURA
        End Get
        Set(ByVal value As Long)
            MyIDFACTURA = Value
        End Set
    End Property
    Public Property SERIE_FACTURA() As String

        Get
            SERIE_FACTURA = MySERIE_FACTURA
        End Get
        Set(ByVal value As String)
            MySERIE_FACTURA = Value
        End Set
    End Property
    Public Property IDTIPO_COMPROBANTE() As Long

        Get
            IDTIPO_COMPROBANTE = MyIDTIPO_COMPROBANTE
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_COMPROBANTE = Value
        End Set
    End Property
    Public Property NRO_FACTURA() As String

        Get
            NRO_FACTURA = MyNRO_FACTURA
        End Get
        Set(ByVal value As String)
            MyNRO_FACTURA = Value
        End Set
    End Property
    Public Property MONTO_IMPUESTO() As Double

        Get
            MONTO_IMPUESTO = MyMONTO_IMPUESTO
        End Get
        Set(ByVal value As Double)
            MyMONTO_IMPUESTO = Value
        End Set
    End Property
    Public Property TOTAL_COSTO() As Double

        Get
            TOTAL_COSTO = MyTOTAL_COSTO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_COSTO = Value
        End Set
    End Property
    Public Property TOTAL_PESO() As Double

        Get
            TOTAL_PESO = MyTOTAL_PESO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_PESO = Value
        End Set
    End Property
    Public Property IDUNIDAD_DESTINO() As Long

        Get
            IDUNIDAD_DESTINO = MyIDUNIDAD_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_DESTINO = Value
        End Set
    End Property
    Public Property IDTIPO_MONEDA() As Long

        Get
            IDTIPO_MONEDA = MyIDTIPO_MONEDA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_MONEDA = Value
        End Set
    End Property
    Public Property FECHA_FACTURA() As String

        Get
            FECHA_FACTURA = MyFECHA_FACTURA
        End Get
        Set(ByVal value As String)
            MyFECHA_FACTURA = Value
        End Set
    End Property
    Public Property FECHA_VENCIMIENTO() As String

        Get
            FECHA_VENCIMIENTO = MyFECHA_VENCIMIENTO
        End Get
        Set(ByVal value As String)
            MyFECHA_VENCIMIENTO = Value
        End Set
    End Property
    Public Property MEMO() As String

        Get
            MEMO = MyMEMO
        End Get
        Set(ByVal value As String)
            MyMEMO = Value
        End Set
    End Property
    Public Property CANTIDAD_X_VOLUMEN() As Double

        Get
            CANTIDAD_X_VOLUMEN = MyCANTIDAD_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_VOLUMEN = Value
        End Set
    End Property
    Public Property PRECIO_X_VOLUMEN() As Double

        Get
            PRECIO_X_VOLUMEN = MyPRECIO_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_VOLUMEN = Value
        End Set
    End Property
    Public Property PRECIO_X_UNIDAD() As Double

        Get
            PRECIO_X_UNIDAD = MyPRECIO_X_UNIDAD
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_UNIDAD = Value
        End Set
    End Property
    Public Property FECHA_CIERRE() As String

        Get
            FECHA_CIERRE = MyFECHA_CIERRE
        End Get
        Set(ByVal value As String)
            MyFECHA_CIERRE = Value
        End Set
    End Property
    Public Property IDAGENCIAS_DESTINO() As Long

        Get
            IDAGENCIAS_DESTINO = MyIDAGENCIAS_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_DESTINO = Value
        End Set
    End Property
    Public Property MONTO_PENALIDAD() As Double

        Get
            MONTO_PENALIDAD = MyMONTO_PENALIDAD
        End Get
        Set(ByVal value As Double)
            MyMONTO_PENALIDAD = Value
        End Set
    End Property
    Public Property REF_IDFACTURA() As Long

        Get
            REF_IDFACTURA = MyREF_IDFACTURA
        End Get
        Set(ByVal value As Long)
            MyREF_IDFACTURA = Value
        End Set
    End Property
    Public Property PORCENT_DEVOLUCION() As Double

        Get
            PORCENT_DEVOLUCION = MyPORCENT_DEVOLUCION
        End Get
        Set(ByVal value As Double)
            MyPORCENT_DEVOLUCION = Value
        End Set
    End Property
    Public Property PORCENT_DESCUENTO() As Double

        Get
            PORCENT_DESCUENTO = MyPORCENT_DESCUENTO
        End Get
        Set(ByVal value As Double)
            MyPORCENT_DESCUENTO = Value
        End Set
    End Property
    Public Property IDGUIAS_ENVIO_REF() As Long

        Get
            IDGUIAS_ENVIO_REF = MyIDGUIAS_ENVIO_REF
        End Get
        Set(ByVal value As Long)
            MyIDGUIAS_ENVIO_REF = Value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA_DESTINO() As Long

        Get
            IDUNIDAD_AGENCIA_DESTINO = MyIDUNIDAD_AGENCIA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA_DESTINO = Value
        End Set
    End Property
    Public Property IDDIRECCION_DESTINATARIO() As Long

        Get
            IDDIRECCION_DESTINATARIO = MyIDDIRECCION_DESTINATARIO
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_DESTINATARIO = Value
        End Set
    End Property
    Public Property IDCONTACTO_REMITENTE() As Long

        Get
            IDCONTACTO_REMITENTE = MyIDCONTACTO_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_REMITENTE = Value
        End Set
    End Property
    Public Property IDTIPO_ENTREGA_CARGA() As Long

        Get
            IDTIPO_ENTREGA_CARGA = MyIDTIPO_ENTREGA_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_ENTREGA_CARGA = Value
        End Set
    End Property
    Public Property IDTARIFAS_CARGA() As Long

        Get
            IDTARIFAS_CARGA = MyIDTARIFAS_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDTARIFAS_CARGA = Value
        End Set
    End Property
    Public Property IDARTICULOS() As Long

        Get
            IDARTICULOS = MyIDARTICULOS
        End Get
        Set(ByVal value As Long)
            MyIDARTICULOS = Value
        End Set
    End Property
    Public Property IDFACTURA_CREDITO() As Long

        Get
            IDFACTURA_CREDITO = MyIDFACTURA_CREDITO
        End Get
        Set(ByVal value As Long)
            MyIDFACTURA_CREDITO = Value
        End Set
    End Property
    Public Property SERIE_GUIA_ENVIO() As Long

        Get
            SERIE_GUIA_ENVIO = MySERIE_GUIA_ENVIO
        End Get
        Set(ByVal value As Long)
            MySERIE_GUIA_ENVIO = Value
        End Set
    End Property
    Public Property CANTIDAD_X_UNIDAD_ARTI() As Double

        Get
            CANTIDAD_X_UNIDAD_ARTI = MyCANTIDAD_X_UNIDAD_ARTI
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_UNIDAD_ARTI = Value
        End Set
    End Property
    Public Property NRO_REF_GUIA() As String

        Get
            NRO_REF_GUIA = MyNRO_REF_GUIA
        End Get
        Set(ByVal value As String)
            MyNRO_REF_GUIA = Value
        End Set
    End Property
    Public Property IDCIERRES_LIQUIDACIONES() As Long

        Get
            IDCIERRES_LIQUIDACIONES = MyIDCIERRES_LIQUIDACIONES
        End Get
        Set(ByVal value As Long)
            MyIDCIERRES_LIQUIDACIONES = Value
        End Set
    End Property
    Public Property CARGO() As Long

        Get
            CARGO = MyCARGO
        End Get
        Set(ByVal value As Long)
            MyCARGO = Value
        End Set
    End Property
    Public Property TOTAL_ARTICULO() As Double

        Get
            TOTAL_ARTICULO = MyTOTAL_ARTICULO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_ARTICULO = Value
        End Set
    End Property
    Public Property CANTIDAD_SOBRES() As Long

        Get
            CANTIDAD_SOBRES = MyCANTIDAD_SOBRES
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_SOBRES = Value
        End Set
    End Property
    Public Property PRECIO_SOBRES() As Double

        Get
            PRECIO_SOBRES = MyPRECIO_SOBRES
        End Get
        Set(ByVal value As Double)
            MyPRECIO_SOBRES = Value
        End Set
    End Property
    Public Property EXPORTADO() As Double

        Get
            EXPORTADO = MyEXPORTADO
        End Get
        Set(ByVal value As Double)
            MyEXPORTADO = Value
        End Set
    End Property
    Public Property MOTIVOS_NO_ATENCION() As String

        Get
            MOTIVOS_NO_ATENCION = MyMOTIVOS_NO_ATENCION
        End Get
        Set(ByVal value As String)
            MyMOTIVOS_NO_ATENCION = Value
        End Set
    End Property
    Public Property FECHA_ANTIGUEDAD_COMISION() As String

        Get
            FECHA_ANTIGUEDAD_COMISION = MyFECHA_ANTIGUEDAD_COMISION
        End Get
        Set(ByVal value As String)
            MyFECHA_ANTIGUEDAD_COMISION = Value
        End Set
    End Property
    Public Property PORCENTAGE_DESCUENTO() As Double

        Get
            PORCENTAGE_DESCUENTO = MyPORCENTAGE_DESCUENTO
        End Get
        Set(ByVal value As Double)
            MyPORCENTAGE_DESCUENTO = Value
        End Set
    End Property
    Public Property MONTO_BASE() As Long

        Get
            MONTO_BASE = MyMONTO_BASE
        End Get
        Set(ByVal value As Long)
            MyMONTO_BASE = Value
        End Set
    End Property
    Public Property LOGIN() As String

        Get
            LOGIN = MyLOGIN
        End Get
        Set(ByVal value As String)
            MyLOGIN = Value
        End Set
    End Property
    Public Property IDTIPO_PERSONA() As Long

        Get
            IDTIPO_PERSONA = MyIDTIPO_PERSONA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_PERSONA = Value
        End Set
    End Property
    Public Property RAZON_SOCIAL() As String

        Get
            RAZON_SOCIAL = MyRAZON_SOCIAL
        End Get
        Set(ByVal value As String)
            MyRAZON_SOCIAL = Value
        End Set
    End Property
    Public Property REPRESENTANTE_LEGAL() As String

        Get
            REPRESENTANTE_LEGAL = MyREPRESENTANTE_LEGAL
        End Get
        Set(ByVal value As String)
            MyREPRESENTANTE_LEGAL = Value
        End Set
    End Property
    Public Property PAGO_POST_FACTURACION() As Long

        Get
            PAGO_POST_FACTURACION = MyPAGO_POST_FACTURACION
        End Get
        Set(ByVal value As Long)
            MyPAGO_POST_FACTURACION = Value
        End Set
    End Property
    Public Property EMAIL() As String

        Get
            EMAIL = MyEMAIL
        End Get
        Set(ByVal value As String)
            MyEMAIL = Value
        End Set
    End Property
    Public Property NOMPRE_PERSONA() As String

        Get
            NOMPRE_PERSONA = MyNOMPRE_PERSONA
        End Get
        Set(ByVal value As String)
            MyNOMPRE_PERSONA = Value
        End Set
    End Property
    Public Property SEXO_PERSONA() As String

        Get
            SEXO_PERSONA = MySEXO_PERSONA
        End Get
        Set(ByVal value As String)
            MySEXO_PERSONA = Value
        End Set
    End Property
    Public Property AGENTE_RETENCION() As Long

        Get
            AGENTE_RETENCION = MyAGENTE_RETENCION
        End Get
        Set(ByVal value As Long)
            MyAGENTE_RETENCION = Value
        End Set
    End Property
    Public Property IDSOLICITUD_RECOJO_CARGA() As Long

        Get
            IDSOLICITUD_RECOJO_CARGA = MyIDSOLICITUD_RECOJO_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDSOLICITUD_RECOJO_CARGA = Value
        End Set
    End Property
    Public Property NOMBRE_CLIENTE_LLAMADA() As String

        Get
            NOMBRE_CLIENTE_LLAMADA = MyNOMBRE_CLIENTE_LLAMADA
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CLIENTE_LLAMADA = Value
        End Set
    End Property
    Public Property HORA_INI() As String

        Get
            HORA_INI = MyHORA_INI
        End Get
        Set(ByVal value As String)
            MyHORA_INI = Value
        End Set
    End Property
    Public Property HORA_FIN() As String

        Get
            HORA_FIN = MyHORA_FIN
        End Get
        Set(ByVal value As String)
            MyHORA_FIN = Value
        End Set
    End Property
    Public Property IDPERSONA_RECOJO() As Double

        Get
            IDPERSONA_RECOJO = MyIDPERSONA_RECOJO
        End Get
        Set(ByVal value As Double)
            MyIDPERSONA_RECOJO = Value
        End Set
    End Property
    Public Property VOLUMEN() As Double

        Get
            VOLUMEN = MyVOLUMEN
        End Get
        Set(ByVal value As Double)
            MyVOLUMEN = Value
        End Set
    End Property
    Public Property VOLUMEN_RECOGIDO() As Double

        Get
            VOLUMEN_RECOGIDO = MyVOLUMEN_RECOGIDO
        End Get
        Set(ByVal value As Double)
            MyVOLUMEN_RECOGIDO = Value
        End Set
    End Property
    'Public Property IDTIPO_OBSERVACION() As Double

    '    Get
    '        IDTIPO_OBSERVACION = MyIDTIPO_OBSERVACION
    '    End Get
    '    Set(ByVal value As Double)
    '        MyIDTIPO_OBSERVACION = Value
    '    End Set
    'End Property
    Public Property IDUNIDAD_TRANSPORTE() As Long

        Get
            IDUNIDAD_TRANSPORTE = MyIDUNIDAD_TRANSPORTE
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_TRANSPORTE = Value
        End Set
    End Property
    Public Property APROBADO() As Long

        Get
            APROBADO = MyAPROBADO
        End Get
        Set(ByVal value As Long)
            MyAPROBADO = Value
        End Set
    End Property
    Public Property DESTINO() As String

        Get
            DESTINO = MyDESTINO
        End Get
        Set(ByVal value As String)
            MyDESTINO = Value
        End Set
    End Property
    Public Property NRO_GUIA_ENVIO() As String

        Get
            NRO_GUIA_ENVIO = MyNRO_GUIA_ENVIO
        End Get
        Set(ByVal value As String)
            MyNRO_GUIA_ENVIO = Value
        End Set
    End Property
    Public Property NOMBRE_RUTA_ENTREGA_RECOJO() As String

        Get
            NOMBRE_RUTA_ENTREGA_RECOJO = MyNOMBRE_RUTA_ENTREGA_RECOJO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_RUTA_ENTREGA_RECOJO = Value
        End Set
    End Property
    'Public Property FECHA_ACTUALIZACION() As NO_DEFINIDO

    '    Get
    '        FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
    '    End Get
    '    Set(ByVal value As NO_DEFINIDO)
    '        MyFECHA_ACTUALIZACION = Value
    '    End Set
    'End Property
    Public Property CUENTA() As String

        Get
            CUENTA = MyCUENTA
        End Get
        Set(ByVal value As String)
            MyCUENTA = Value
        End Set
    End Property
    Public Property ORDENAR_FISCA() As Long

        Get
            ORDENAR_FISCA = MyORDENAR_FISCA
        End Get
        Set(ByVal value As Long)
            MyORDENAR_FISCA = value
        End Set
    End Property
    Public Property TIPO_COMPROBANTE_COMISION() As String

        Get
            TIPO_COMPROBANTE_COMISION = MyTIPO_COMPROBANTE_COMISION
        End Get
        Set(ByVal value As String)
            MyTIPO_COMPROBANTE_COMISION = value
        End Set
    End Property
    Public Property ORDERNAR_FISCA_LIQUI() As Double

        Get
            ORDERNAR_FISCA_LIQUI = MyORDERNAR_FISCA_LIQUI
        End Get
        Set(ByVal value As Double)
            MyORDERNAR_FISCA_LIQUI = value
        End Set
    End Property
    Public Property IDTIPO_OBSERVACION() As Long

        Get
            IDTIPO_OBSERVACION = MyIDTIPO_OBSERVACION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_OBSERVACION = value
        End Set
    End Property
    Public Property IPMOD() As Long

        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As Long)
            MyIPMOD = value
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
    Public Property NRO_TELEVISORES() As Long

        Get
            NRO_TELEVISORES = MyNRO_TELEVISORES
        End Get
        Set(ByVal value As Long)
            MyNRO_TELEVISORES = value
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
    Public Property NRO_LICENCIA() As String

        Get
            NRO_LICENCIA = MyNRO_LICENCIA
        End Get
        Set(ByVal value As String)
            MyNRO_LICENCIA = value
        End Set
    End Property
    Public Property FAX() As String

        Get
            FAX = MyFAX
        End Get
        Set(ByVal value As String)
            MyFAX = value
        End Set
    End Property
    Public Property RPM() As String

        Get
            RPM = MyRPM
        End Get
        Set(ByVal value As String)
            MyRPM = value
        End Set
    End Property
    Public Property IDUSUARIO_MODIFICADOR() As Long

        Get
            IDUSUARIO_MODIFICADOR = MyIDUSUARIO_MODIFICADOR
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_MODIFICADOR = value
        End Set
    End Property
    Public Property IDTIPO_USUARIO_PERSONAL() As Long

        Get
            IDTIPO_USUARIO_PERSONAL = MyIDTIPO_USUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_USUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDAREA_SISTEMA() As Long

        Get
            IDAREA_SISTEMA = MyIDAREA_SISTEMA
        End Get
        Set(ByVal value As Long)
            MyIDAREA_SISTEMA = value
        End Set
    End Property
End Class
