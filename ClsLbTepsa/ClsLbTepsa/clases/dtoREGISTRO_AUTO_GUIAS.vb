Imports AccesoDatos
Public Class dtoREGISTRO_AUTO_GUIAS
    Dim Mynro_grupo As Long

    Dim Mydocu_clien As String

    Dim Myx_iIDCONTACTO_REMITENTE As String
    Dim Myx_iIDDIRECCION_REMITENTE As String
    Dim Myx_iIDTEFONO_REMITENTE As String
    Dim Myx_iIDCONTACTO_DESTINATARIO As String
    Dim Myx_iIDDIRECCION_DESTINATARIO As String
    Dim Myx_iIDTEFONO_CONSIGNADO As String
    '
    Dim MyCODIGO_CLIENTE As String
    Dim MyCODIGO_IATA As String
    Dim MyDIRECCION As String
    Dim MyNOMBRES_DESTI As String
    Dim MyNRODOCUMENTO_DESTI As String
    Dim MyDIRECCION_DESTI As String
    '
    Dim MyNROCOMUNICACION_CONTACTO_DESTI As String
    Dim MyNROCOMUNICACION_CONTACTO As String
    Dim MyNOMBRES_REMITENTE_ORI As String
    Dim MyNRODOCUMENTO_REMITENTE_ORI As String
    Dim MyIDCONTACTO_PERSONA As Long
    Dim MyIDTIPO_CONTACTO As Long
    Dim MyIDPERSONA As Long
    Dim MyAPEPAT As String
    Dim MyAPEMAT As String
    Dim MyEMAIL_CONTACTO As String
    Dim MyFECHA_REGISTRO As String
    Dim MyDEFECTO As Long
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyFECHA_NACIMIENTO As String
    Dim MyHORA_ENTREGA As String
    Dim MyIDUSUARIO_ENTREGA As Long
    Dim MyCARGO_DOC As Long
    Dim MyIDUSUARIO_CARGO As Long
    Dim MyCANTIDAD_TOTAL As Long
    Dim MyCANTIDAD_DESPACHADO As Long
    Dim MyCANTIDAD_ENTRE_DOMI As Long
    Dim MyCANTIDAD_PENDI_DOMI As Long
    Dim MyMENSAJE_ENVIADO As String
    Dim MyFECHA_REGISTRO_ENTREGA As String
    Dim MyMETRO_CUBICO As Double
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Long
    Dim MyIDAGENCIAS As Long
    Dim MyIDTIPO_ENTREGA_CARGA As Long
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDTARIFAS_CARGA As Long
    Dim MyFECHA_RECEPCION_DESTINO As String
    Dim MyFECHA_CARGOS As String
    Dim MyIDCIUDAD_TRANSITO As Long
    Dim MyTOTAL_VOLUMEN As Double
    Dim MyMONTO_BASE As Double
    Dim MyPRECIO_X_UNIDAD As Double
    Dim MyIDARTICULOS As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyTOTAL_COSTO As Double
    Dim MyIDFACTURA_CREDITO As Long
    Dim MyIDUSUARIO_REVISION As Long
    Dim MyIDIMPUESTO As Long
    Dim MyIDTEFONO_REMITENTE As Long
    Dim MyIDCONTACTO_DESTINATARIO As Long
    Dim MyMONTO_IMPUESTO As Double
    Dim MyCANTIDAD_X_UNIDAD_VOLUMEN As Double
    Dim MyNRO_REF_GUIA As String
    Dim MyLIQUIDADO As Double
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyIDTIPO_MONEDA As Long
    Dim MyID_REMITENTE As Long
    Dim MyPRECIO_X_PESO As Double
    Dim MyCANTIDAD_SOBRES As Long
    Dim MyPRECIO_SOBRES As Double
    Dim MySELECCIONAR_TO_FACTURA As Long
    Dim MyNOMBRES As String
    Dim MyIDTIPO_DOCUMENTO_CONTACTO As Long
    Dim MyNRODOCUMENTO As String
    Dim MySEXO As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIP As String
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIPMOD As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyESTADO_REGISTRO As Long
    Dim MyTELEFONO As String
    Dim MyDATOS_PERSONALES As String
    Dim MyIDESTADO_ENVIO As Long
    Dim MyIDAGENCIAS_DESTINO As Long
    Dim MyFECHA_DOC As String
    Dim MyIP_CARGO As String
    Dim MyCALCU_COMI As Long
    Dim MyBULTOS_EN_ALMACEN As Double
    Dim MyIMPUESTO As Double
    Dim MyIDGUIAS_ENVIO_REF As Long
    Dim MyOBS As String
    Dim MyIDGUIAS_ENVIO As Long
    Dim MyFECHA_GUIA As String
    Dim MyNRO_GUIA As String
    Dim MyIDDIRECCION_DESTINATARIO As Long
    Dim MyIDCONTACTO_REMITENTE As Long
    Dim MyIDTARIFAS_CARGA_CLIENTE As Long
    Dim MyFECHA_DESPACHO As String
    Dim MyFECHA_ENTREGA As String
    Dim MyTOTAL_PESO As Double
    Dim MyCANTIDAD As Long
    Dim MyNOMBRE_RECOJO As String
    Dim MyNOMBRE_ENTREGA As String
    Dim MyDOC_ENTREGA As String
    Dim MyFECHA_RECOJO As String
    Dim MyIDPREFACTURA As Long
    Dim MyIDROL_REVISION As Long
    Dim MyFECHA_REVISION As String
    Dim MySERIE_GUIA_ENVIO As Long
    Dim MyIDDIRECCION_REMITENTE As Long
    Dim MyIDTEFONO_CONSIGNADO As Long
    Dim MyCANTIDAD_X_UNIDAD_ARTI As Double
    Dim MyPRECIO_X_VOLUMEN As Double
    Dim MyIDCIERRES_LIQUIDACIONES As Long
    Dim MyCARGO As Long
    Dim MyFACTURADO As Long
    Dim MyTOTAL_ARTICULO As Double
    Dim MyIDCENTRO_COSTO As Long
    Dim MyIDSINO_SOBRES As Long
    Dim MyEXPORTADO As Double
    Public Property nro_grupo() As Long
        Get
            nro_grupo = Mynro_grupo
        End Get
        Set(ByVal value As Long)
            Mynro_grupo = value
        End Set
    End Property

    Public Property docu_clien() As String
        Get
            docu_clien = Mydocu_clien
        End Get
        Set(ByVal value As String)
            Mydocu_clien = value
        End Set
    End Property

    Public Property x_iIDTEFONO_REMITENTE() As String

        Get
            x_iIDTEFONO_REMITENTE = Myx_iIDTEFONO_REMITENTE
        End Get
        Set(ByVal value As String)
            Myx_iIDTEFONO_REMITENTE = value
        End Set
    End Property
    Public Property x_iIDCONTACTO_REMITENTE() As String

        Get
            x_iIDCONTACTO_REMITENTE = Myx_iIDCONTACTO_REMITENTE
        End Get
        Set(ByVal value As String)
            Myx_iIDCONTACTO_REMITENTE = value
        End Set
    End Property
    Public Property x_iIDDIRECCION_REMITENTE() As String

        Get
            x_iIDDIRECCION_REMITENTE = Myx_iIDDIRECCION_REMITENTE
        End Get
        Set(ByVal value As String)
            Myx_iIDDIRECCION_REMITENTE = value
        End Set
    End Property
    Public Property x_iIDCONTACTO_DESTINATARIO() As String

        Get
            x_iIDCONTACTO_DESTINATARIO = Myx_iIDCONTACTO_DESTINATARIO
        End Get
        Set(ByVal value As String)
            Myx_iIDCONTACTO_DESTINATARIO = value
        End Set
    End Property
    Public Property x_iIDDIRECCION_DESTINATARIO() As String

        Get
            x_iIDDIRECCION_DESTINATARIO = Myx_iIDDIRECCION_DESTINATARIO
        End Get
        Set(ByVal value As String)
            Myx_iIDDIRECCION_DESTINATARIO = value
        End Set
    End Property
    Public Property x_iIDTEFONO_CONSIGNADO() As String

        Get
            x_iIDTEFONO_CONSIGNADO = Myx_iIDTEFONO_CONSIGNADO
        End Get
        Set(ByVal value As String)
            Myx_iIDTEFONO_CONSIGNADO = value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String

        Get
            CODIGO_CLIENTE = MyCODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            MyCODIGO_CLIENTE = value
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
    Public Property DIRECCION_DESTI() As String

        Get
            DIRECCION_DESTI = MyDIRECCION_DESTI
        End Get
        Set(ByVal value As String)
            MyDIRECCION_DESTI = value
        End Set
    End Property

    Public Property NRODOCUMENTO_DESTI() As String

        Get
            NRODOCUMENTO_DESTI = MyNRODOCUMENTO_DESTI
        End Get
        Set(ByVal value As String)
            MyNRODOCUMENTO_DESTI = value
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

    Public Property DIRECCION() As String

        Get
            DIRECCION = MyDIRECCION
        End Get
        Set(ByVal value As String)
            MyDIRECCION = value
        End Set
    End Property


    Public Property NROCOMUNICACION_CONTACTO_DESTI() As String

        Get
            NROCOMUNICACION_CONTACTO_DESTI = MyNROCOMUNICACION_CONTACTO_DESTI
        End Get
        Set(ByVal value As String)
            MyNROCOMUNICACION_CONTACTO_DESTI = value
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


    Public Property NOMBRES_REMITENTE_ORI() As String

        Get
            NOMBRES_REMITENTE_ORI = MyNOMBRES_REMITENTE_ORI
        End Get
        Set(ByVal value As String)
            MyNOMBRES_REMITENTE_ORI = value
        End Set
    End Property

    Public Property NRODOCUMENTO_REMITENTE_ORI() As String

        Get
            NRODOCUMENTO_REMITENTE_ORI = MyNRODOCUMENTO_REMITENTE_ORI
        End Get
        Set(ByVal value As String)
            MyNRODOCUMENTO_REMITENTE_ORI = value
        End Set
    End Property
    Public Property IDTIPO_CONTACTO() As Long

        Get
            IDTIPO_CONTACTO = MyIDTIPO_CONTACTO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_CONTACTO = value
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
    Public Property NOMBRES() As String

        Get
            NOMBRES = MyNOMBRES
        End Get
        Set(ByVal value As String)
            MyNOMBRES = value
        End Set
    End Property
    Public Property APEPAT() As String

        Get
            APEPAT = MyAPEPAT
        End Get
        Set(ByVal value As String)
            MyAPEPAT = value
        End Set
    End Property
    Public Property APEMAT() As String

        Get
            APEMAT = MyAPEMAT
        End Get
        Set(ByVal value As String)
            MyAPEMAT = value
        End Set
    End Property
    Public Property EMAIL_CONTACTO() As String

        Get
            EMAIL_CONTACTO = MyEMAIL_CONTACTO
        End Get
        Set(ByVal value As String)
            MyEMAIL_CONTACTO = value
        End Set
    End Property
    Public Property SEXO() As String

        Get
            SEXO = MySEXO
        End Get
        Set(ByVal value As String)
            MySEXO = value
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
    Public Property FECHA_REGISTRO() As String

        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
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
    Public Property ESTADO_REGISTRO() As Long

        Get
            ESTADO_REGISTRO = MyESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyESTADO_REGISTRO = value
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
    Public Property IDUNIDAD_AGENCIA() As Long

        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = value
        End Set
    End Property
    Public Property FECHA_NACIMIENTO() As String

        Get
            FECHA_NACIMIENTO = MyFECHA_NACIMIENTO
        End Get
        Set(ByVal value As String)
            MyFECHA_NACIMIENTO = value
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
    Public Property IDUSUARIO_ENTREGA() As Long

        Get
            IDUSUARIO_ENTREGA = MyIDUSUARIO_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_ENTREGA = value
        End Set
    End Property
    Public Property CARGO_DOC() As Long

        Get
            CARGO_DOC = MyCARGO_DOC
        End Get
        Set(ByVal value As Long)
            MyCARGO_DOC = value
        End Set
    End Property
    Public Property FECHA_DOC() As String

        Get
            FECHA_DOC = MyFECHA_DOC
        End Get
        Set(ByVal value As String)
            MyFECHA_DOC = value
        End Set
    End Property
    Public Property IDUSUARIO_CARGO() As Long

        Get
            IDUSUARIO_CARGO = MyIDUSUARIO_CARGO
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_CARGO = value
        End Set
    End Property
    Public Property IP_CARGO() As String

        Get
            IP_CARGO = MyIP_CARGO
        End Get
        Set(ByVal value As String)
            MyIP_CARGO = value
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
    Public Property CANTIDAD_ENTRE_DOMI() As Long

        Get
            CANTIDAD_ENTRE_DOMI = MyCANTIDAD_ENTRE_DOMI
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_ENTRE_DOMI = value
        End Set
    End Property
    Public Property CANTIDAD_PENDI_DOMI() As Long

        Get
            CANTIDAD_PENDI_DOMI = MyCANTIDAD_PENDI_DOMI
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_PENDI_DOMI = value
        End Set
    End Property
    Public Property IMPUESTO() As Double

        Get
            IMPUESTO = MyIMPUESTO
        End Get
        Set(ByVal value As Double)
            MyIMPUESTO = value
        End Set
    End Property
    Public Property IDGUIAS_ENVIO() As Long

        Get
            IDGUIAS_ENVIO = MyIDGUIAS_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDGUIAS_ENVIO = value
        End Set
    End Property
    Public Property FECHA_GUIA() As String

        Get
            FECHA_GUIA = MyFECHA_GUIA
        End Get
        Set(ByVal value As String)
            MyFECHA_GUIA = value
        End Set
    End Property
    Public Property NRO_GUIA() As String

        Get
            NRO_GUIA = MyNRO_GUIA
        End Get
        Set(ByVal value As String)
            MyNRO_GUIA = value
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
    Public Property IDFORMA_PAGO() As Long

        Get
            IDFORMA_PAGO = MyIDFORMA_PAGO
        End Get
        Set(ByVal value As Long)
            MyIDFORMA_PAGO = value
        End Set
    End Property
    Public Property IDTARIFAS_CARGA_CLIENTE() As Long

        Get
            IDTARIFAS_CARGA_CLIENTE = MyIDTARIFAS_CARGA_CLIENTE
        End Get
        Set(ByVal value As Long)
            MyIDTARIFAS_CARGA_CLIENTE = value
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
    Public Property FECHA_ENTREGA() As String

        Get
            FECHA_ENTREGA = MyFECHA_ENTREGA
        End Get
        Set(ByVal value As String)
            MyFECHA_ENTREGA = value
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
    Public Property CANTIDAD() As Long

        Get
            CANTIDAD = MyCANTIDAD
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD = value
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
    Public Property MONTO_BASE() As Double

        Get
            MONTO_BASE = MyMONTO_BASE
        End Get
        Set(ByVal value As Double)
            MyMONTO_BASE = value
        End Set
    End Property
    Public Property NOMBRE_RECOJO() As String

        Get
            NOMBRE_RECOJO = MyNOMBRE_RECOJO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_RECOJO = value
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
    Public Property FECHA_RECOJO() As String

        Get
            FECHA_RECOJO = MyFECHA_RECOJO
        End Get
        Set(ByVal value As String)
            MyFECHA_RECOJO = value
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
    Public Property IDPREFACTURA() As Long

        Get
            IDPREFACTURA = MyIDPREFACTURA
        End Get
        Set(ByVal value As Long)
            MyIDPREFACTURA = value
        End Set
    End Property
    Public Property IDUSUARIO_REVISION() As Long

        Get
            IDUSUARIO_REVISION = MyIDUSUARIO_REVISION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_REVISION = value
        End Set
    End Property
    Public Property IDROL_REVISION() As Long

        Get
            IDROL_REVISION = MyIDROL_REVISION
        End Get
        Set(ByVal value As Long)
            MyIDROL_REVISION = value
        End Set
    End Property
    Public Property FECHA_REVISION() As String

        Get
            FECHA_REVISION = MyFECHA_REVISION
        End Get
        Set(ByVal value As String)
            MyFECHA_REVISION = value
        End Set
    End Property
    Public Property IDIMPUESTO() As Long

        Get
            IDIMPUESTO = MyIDIMPUESTO
        End Get
        Set(ByVal value As Long)
            MyIDIMPUESTO = value
        End Set
    End Property
    Public Property IDDIRECCION_REMITENTE() As Long

        Get
            IDDIRECCION_REMITENTE = MyIDDIRECCION_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_REMITENTE = value
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
    Public Property IDCONTACTO_DESTINATARIO() As Long

        Get
            IDCONTACTO_DESTINATARIO = MyIDCONTACTO_DESTINATARIO
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_DESTINATARIO = value
        End Set
    End Property
    Public Property CANTIDAD_X_UNIDAD_VOLUMEN() As Double

        Get
            CANTIDAD_X_UNIDAD_VOLUMEN = MyCANTIDAD_X_UNIDAD_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_UNIDAD_VOLUMEN = value
        End Set
    End Property
    Public Property LIQUIDADO() As Double

        Get
            LIQUIDADO = MyLIQUIDADO
        End Get
        Set(ByVal value As Double)
            MyLIQUIDADO = value
        End Set
    End Property
    Public Property FACTURADO() As Long

        Get
            FACTURADO = MyFACTURADO
        End Get
        Set(ByVal value As Long)
            MyFACTURADO = value
        End Set
    End Property
    Public Property ID_REMITENTE() As Long

        Get
            ID_REMITENTE = MyID_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyID_REMITENTE = value
        End Set
    End Property
    Public Property IDCENTRO_COSTO() As Long

        Get
            IDCENTRO_COSTO = MyIDCENTRO_COSTO
        End Get
        Set(ByVal value As Long)
            MyIDCENTRO_COSTO = value
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
    Public Property IDSINO_SOBRES() As Long

        Get
            IDSINO_SOBRES = MyIDSINO_SOBRES
        End Get
        Set(ByVal value As Long)
            MyIDSINO_SOBRES = value
        End Set
    End Property
    Public Property SELECCIONAR_TO_FACTURA() As Long

        Get
            SELECCIONAR_TO_FACTURA = MySELECCIONAR_TO_FACTURA
        End Get
        Set(ByVal value As Long)
            MySELECCIONAR_TO_FACTURA = value
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
    Public Property IDTIPO_DOCUMENTO_CONTACTO() As Long

        Get
            IDTIPO_DOCUMENTO_CONTACTO = MyIDTIPO_DOCUMENTO_CONTACTO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_DOCUMENTO_CONTACTO = value
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
    Public Property IDROL_USUARIO() As Long

        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIO = value
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
    Public Property IDROL_USUARIOMOD() As Long

        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIOMOD = value
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
    Public Property DEFECTO() As Long

        Get
            DEFECTO = MyDEFECTO
        End Get
        Set(ByVal value As Long)
            MyDEFECTO = value
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
    Public Property IDAGENCIAS_DESTINO() As Long

        Get
            IDAGENCIAS_DESTINO = MyIDAGENCIAS_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_DESTINO = value
        End Set
    End Property
    Public Property CANTIDAD_TOTAL() As Long

        Get
            CANTIDAD_TOTAL = MyCANTIDAD_TOTAL
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_TOTAL = value
        End Set
    End Property
    Public Property CANTIDAD_DESPACHADO() As Long

        Get
            CANTIDAD_DESPACHADO = MyCANTIDAD_DESPACHADO
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_DESPACHADO = value
        End Set
    End Property
    Public Property BULTOS_EN_ALMACEN() As Double

        Get
            BULTOS_EN_ALMACEN = MyBULTOS_EN_ALMACEN
        End Get
        Set(ByVal value As Double)
            MyBULTOS_EN_ALMACEN = value
        End Set
    End Property
    Public Property MENSAJE_ENVIADO() As String

        Get
            MENSAJE_ENVIADO = MyMENSAJE_ENVIADO
        End Get
        Set(ByVal value As String)
            MyMENSAJE_ENVIADO = value
        End Set
    End Property
    Public Property FECHA_REGISTRO_ENTREGA() As String

        Get
            FECHA_REGISTRO_ENTREGA = MyFECHA_REGISTRO_ENTREGA
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO_ENTREGA = value
        End Set
    End Property
    Public Property IDGUIAS_ENVIO_REF() As Long

        Get
            IDGUIAS_ENVIO_REF = MyIDGUIAS_ENVIO_REF
        End Get
        Set(ByVal value As Long)
            MyIDGUIAS_ENVIO_REF = value
        End Set
    End Property
    Public Property METRO_CUBICO() As Double

        Get
            METRO_CUBICO = MyMETRO_CUBICO
        End Get
        Set(ByVal value As Double)
            MyMETRO_CUBICO = value
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
    Public Property IDUNIDAD_AGENCIA_DESTINO() As Long

        Get
            IDUNIDAD_AGENCIA_DESTINO = MyIDUNIDAD_AGENCIA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA_DESTINO = value
        End Set
    End Property
    Public Property IDDIRECCION_DESTINATARIO() As Long

        Get
            IDDIRECCION_DESTINATARIO = MyIDDIRECCION_DESTINATARIO
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_DESTINATARIO = value
        End Set
    End Property
    Public Property IDCONTACTO_REMITENTE() As Long

        Get
            IDCONTACTO_REMITENTE = MyIDCONTACTO_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_REMITENTE = value
        End Set
    End Property
    Public Property IDTIPO_ENTREGA_CARGA() As Long

        Get
            IDTIPO_ENTREGA_CARGA = MyIDTIPO_ENTREGA_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_ENTREGA_CARGA = value
        End Set
    End Property
    Public Property IDTARIFAS_CARGA() As Long

        Get
            IDTARIFAS_CARGA = MyIDTARIFAS_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDTARIFAS_CARGA = value
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
    Public Property FECHA_CARGOS() As String

        Get
            FECHA_CARGOS = MyFECHA_CARGOS
        End Get
        Set(ByVal value As String)
            MyFECHA_CARGOS = value
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
    Public Property PRECIO_X_UNIDAD() As Double

        Get
            PRECIO_X_UNIDAD = MyPRECIO_X_UNIDAD
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_UNIDAD = value
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
    Public Property IDARTICULOS() As Long

        Get
            IDARTICULOS = MyIDARTICULOS
        End Get
        Set(ByVal value As Long)
            MyIDARTICULOS = value
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
    Public Property IDFACTURA_CREDITO() As Long

        Get
            IDFACTURA_CREDITO = MyIDFACTURA_CREDITO
        End Get
        Set(ByVal value As Long)
            MyIDFACTURA_CREDITO = value
        End Set
    End Property
    Public Property SERIE_GUIA_ENVIO() As Long

        Get
            SERIE_GUIA_ENVIO = MySERIE_GUIA_ENVIO
        End Get
        Set(ByVal value As Long)
            MySERIE_GUIA_ENVIO = value
        End Set
    End Property
    Public Property CANTIDAD_X_UNIDAD_ARTI() As Double

        Get
            CANTIDAD_X_UNIDAD_ARTI = MyCANTIDAD_X_UNIDAD_ARTI
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_UNIDAD_ARTI = value
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
    Public Property PRECIO_X_VOLUMEN() As Double

        Get
            PRECIO_X_VOLUMEN = MyPRECIO_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyPRECIO_X_VOLUMEN = value
        End Set
    End Property
    Public Property NRO_REF_GUIA() As String

        Get
            NRO_REF_GUIA = MyNRO_REF_GUIA
        End Get
        Set(ByVal value As String)
            MyNRO_REF_GUIA = value
        End Set
    End Property
    Public Property IDCIERRES_LIQUIDACIONES() As Long

        Get
            IDCIERRES_LIQUIDACIONES = MyIDCIERRES_LIQUIDACIONES
        End Get
        Set(ByVal value As Long)
            MyIDCIERRES_LIQUIDACIONES = value
        End Set
    End Property
    Public Property CARGO() As Long

        Get
            CARGO = MyCARGO
        End Get
        Set(ByVal value As Long)
            MyCARGO = value
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
    Public Property TOTAL_ARTICULO() As Double

        Get
            TOTAL_ARTICULO = MyTOTAL_ARTICULO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_ARTICULO = value
        End Set
    End Property
    Public Property CANTIDAD_SOBRES() As Long

        Get
            CANTIDAD_SOBRES = MyCANTIDAD_SOBRES
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_SOBRES = value
        End Set
    End Property
    Public Property PRECIO_SOBRES() As Double

        Get
            PRECIO_SOBRES = MyPRECIO_SOBRES
        End Get
        Set(ByVal value As Double)
            MyPRECIO_SOBRES = value
        End Set
    End Property
    Public Property EXPORTADO() As Double

        Get
            EXPORTADO = MyEXPORTADO
        End Get
        Set(ByVal value As Double)
            MyEXPORTADO = value
        End Set
    End Property
    'Public Function SP_INS_GUIAS_ENVIO_VII_2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOREGISTRO_AUTO_GUIAS.SP_INS_GUIAS_ENVIO_VII"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iCONTROL", OracleClient.OracleType.VarChar)).Value = 1
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("xiIDGUIAS_ENVIO", OracleClient.OracleType.VarChar)).Value = 0
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("sFECHA_GUIA", OracleClient.OracleType.VarChar)).Value = FECHA_GUIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("sNRO_GUIA", OracleClient.OracleType.VarChar)).Value = NRO_GUIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("xiIDPERSONA", OracleClient.OracleType.VarChar)).Value = IDPERSONA.ToString
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDTIPO_ENTREGA_CARGA", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA_CARGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDFORMA_PAGO", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDUNIDAD_AGENCIA", OracleClient.OracleType.Number)).Value = Me.IDUNIDAD_AGENCIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDCIUDAD_TRANSITO", OracleClient.OracleType.Number)).Value = Me.IDCIUDAD_TRANSITO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDUNIDAD_AGENCIA_DESTINO", OracleClient.OracleType.Number)).Value = Me.IDUNIDAD_AGENCIA_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDAGENCIAS", OracleClient.OracleType.Number)).Value = Me.IDAGENCIAS


    '        cmd.Parameters.Add(New OracleClient.OracleParameter("x_iIDCONTACTO_REMITENTE", OracleClient.OracleType.VarChar)).Value = x_iIDCONTACTO_REMITENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("x_iIDDIRECCION_REMITENTE", OracleClient.OracleType.VarChar)).Value = x_iIDDIRECCION_REMITENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("x_iIDTEFONO_REMITENTE", OracleClient.OracleType.VarChar)).Value = x_iIDTEFONO_REMITENTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("x_iIDCONTACTO_DESTINATARIO", OracleClient.OracleType.VarChar)).Value = x_iIDCONTACTO_DESTINATARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("x_iIDDIRECCION_DESTINATARIO", OracleClient.OracleType.VarChar)).Value = x_iIDDIRECCION_DESTINATARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("x_iIDTEFONO_CONSIGNADO", OracleClient.OracleType.VarChar)).Value = x_iIDTEFONO_CONSIGNADO



    '        cmd.Parameters.Add(New OracleClient.OracleParameter("dMONTO_BASE", OracleClient.OracleType.Number)).Value = Me.MONTO_BASE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("dTOTAL_PESO", OracleClient.OracleType.Number)).Value = Me.TOTAL_PESO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iCANTIDAD", OracleClient.OracleType.Number)).Value = Me.CANTIDAD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("dTOTAL_VOLUMEN", OracleClient.OracleType.Number)).Value = Me.TOTAL_VOLUMEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iCANTIDAD_X_UNIDAD_VOLUMEN", OracleClient.OracleType.Number)).Value = Me.CANTIDAD_X_UNIDAD_VOLUMEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iCANTIDAD_X_UNIDAD_ARTI", OracleClient.OracleType.Number)).Value = Me.CANTIDAD_X_UNIDAD_ARTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("dPRECIO_X_UNIDAD", OracleClient.OracleType.Number)).Value = Me.PRECIO_X_UNIDAD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("dIMPUESTO", OracleClient.OracleType.Number)).Value = Me.IMPUESTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("dMONTO_IMPUESTO", OracleClient.OracleType.Number)).Value = Me.MONTO_IMPUESTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("dTOTAL_COSTO", OracleClient.OracleType.Number)).Value = Me.TOTAL_COSTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = Me.IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDROL_USUARIO", OracleClient.OracleType.Number)).Value = Me.IDROL_USUARIO

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = Me.IDESTADO_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iNOMBRES_REMITENTE", OracleClient.OracleType.VarChar)).Value = NOMBRES
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iDNI_REMITENTE", OracleClient.OracleType.VarChar)).Value = NRODOCUMENTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iDIRECCION_REMITENTE", OracleClient.OracleType.VarChar)).Value = DIRECCION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iNOMBRES_DESTINATARIO", OracleClient.OracleType.VarChar)).Value = NOMBRES_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iDNI_DESTINATARIO", OracleClient.OracleType.VarChar)).Value = NRODOCUMENTO_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iDIRECCION_DESTINATARIO", OracleClient.OracleType.VarChar)).Value = DIRECCION_DESTI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iPrecio_x_Peso", OracleClient.OracleType.Number)).Value = PRECIO_X_PESO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iPrecio_x_Volumen", OracleClient.OracleType.Number)).Value = PRECIO_X_VOLUMEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iCARGO", OracleClient.OracleType.Number)).Value = CARGO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iTelefono_Remitente", OracleClient.OracleType.VarChar)).Value = "@"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iTelefono_Destinatario", OracleClient.OracleType.VarChar)).Value = "@"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("x_iID_REMITENTE", OracleClient.OracleType.VarChar)).Value = "0"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iREMITENTE", OracleClient.OracleType.VarChar)).Value = NOMBRES_REMITENTE_ORI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iNRODOC_REM", OracleClient.OracleType.VarChar)).Value = NRODOCUMENTO_REMITENTE_ORI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = IDCENTRO_COSTO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iCANTIDAD_SOBRES", OracleClient.OracleType.Number)).Value = CANTIDAD_SOBRES
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDSINO_SOBRES", OracleClient.OracleType.Number)).Value = IDSINO_SOBRES
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = IDAGENCIAS_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_docu_clien", OracleClient.OracleType.VarChar, 32767)).Value = docu_clien
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_grupo", OracleClient.OracleType.Number)).Value = nro_grupo
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("curr_datos_Guia_Envio", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("curr_error", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    Catch Oex As OracleClient.OracleException
    '        MsgBox(Oex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try
    'End Function
    Public Function SP_INS_GUIAS_ENVIO_VII() As Boolean
        Try
            Dim db As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            db.Conectar()
            db.CrearComando("PKG_IVOREGISTRO_AUTO_GUIAS.SP_INS_GUIAS_ENVIO_VII", CommandType.StoredProcedure)
            '
            db.AsignarParametro("iCONTROL", "1", OracleClient.OracleType.VarChar)
            db.AsignarParametro("xiIDGUIAS_ENVIO", "0", OracleClient.OracleType.VarChar)
            db.AsignarParametro("sFECHA_GUIA", FECHA_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("sNRO_GUIA", NRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("xiIDPERSONA", IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_ENTREGA_CARGA", IDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDFORMA_PAGO", IDFORMA_PAGO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDUNIDAD_AGENCIA", Me.IDUNIDAD_AGENCIA, OracleClient.OracleType.Number)

            db.AsignarParametro("iIDCIUDAD_TRANSITO", Me.IDCIUDAD_TRANSITO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", Me.IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDAGENCIAS", Me.IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("x_iIDCONTACTO_REMITENTE", x_iIDCONTACTO_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_REMITENTE", x_iIDDIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_REMITENTE", x_iIDTEFONO_REMITENTE, OracleClient.OracleType.VarChar)

            db.AsignarParametro("x_iIDCONTACTO_DESTINATARIO", x_iIDCONTACTO_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_DESTINATARIO", x_iIDDIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_CONSIGNADO", x_iIDTEFONO_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("dMONTO_BASE", Me.MONTO_BASE, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_PESO", Me.TOTAL_PESO, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD", Me.CANTIDAD, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_VOLUMEN", Me.TOTAL_VOLUMEN, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_VOLUMEN", Me.CANTIDAD_X_UNIDAD_VOLUMEN, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_ARTI", Me.CANTIDAD_X_UNIDAD_ARTI, OracleClient.OracleType.Number)
            db.AsignarParametro("dPRECIO_X_UNIDAD", Me.PRECIO_X_UNIDAD, OracleClient.OracleType.Number)
            db.AsignarParametro("dIMPUESTO", Me.IMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dMONTO_IMPUESTO", Me.MONTO_IMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_COSTO", Me.TOTAL_COSTO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", Me.IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDROL_USUARIO", Me.IDROL_USUARIO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDESTADO_REGISTRO", Me.IDESTADO_REGISTRO, OracleClient.OracleType.Number)
            db.AsignarParametro("iNOMBRES_REMITENTE", NOMBRES, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_REMITENTE", NRODOCUMENTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_REMITENTE", DIRECCION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNOMBRES_DESTINATARIO", NOMBRES_DESTI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_DESTINATARIO", NRODOCUMENTO_DESTI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_DESTINATARIO", DIRECCION_DESTI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iPrecio_x_Peso", PRECIO_X_PESO, OracleClient.OracleType.Number)
            db.AsignarParametro("iPrecio_x_Volumen", PRECIO_X_VOLUMEN, OracleClient.OracleType.Number)
            '
            db.AsignarParametro("iCARGO", CARGO, OracleClient.OracleType.Number)
            db.AsignarParametro("iTelefono_Remitente", "@", OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTelefono_Destinatario", "@", OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("x_iID_REMITENTE", "0", OracleClient.OracleType.VarChar)
            db.AsignarParametro("iREMITENTE", NOMBRES_REMITENTE_ORI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNRODOC_REM", NRODOCUMENTO_REMITENTE_ORI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDCENTRO_COSTO", IDCENTRO_COSTO, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD_SOBRES", CANTIDAD_SOBRES, OracleClient.OracleType.Number)

            db.AsignarParametro("iIDSINO_SOBRES", IDSINO_SOBRES, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDAGENCIAS_DESTINO", IDAGENCIAS_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("p_docu_clien", docu_clien, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_nro_grupo", nro_grupo, OracleClient.OracleType.Number)
            '
            db.AsignarParametro("curr_datos_Guia_Envio", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            lds_tmp = db.EjecutarDataSet
            '
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_recu_idunidad_agencia_2009(ByVal cnn As OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOREGISTRO_AUTO_GUIAS.sp_recu_idunidad_agencia"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_codigo_iata", OracleClient.OracleType.VarChar, 3)).Value = CODIGO_IATA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CURR_recu_idunidad_agencia", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Try
    '        Return ds.Tables(0).DefaultView
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_recu_idunidad_agencia() As DataView
        Try
            Dim ldt_tmp As New DataTable
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREGISTRO_AUTO_GUIAS.sp_recu_idunidad_agencia", CommandType.StoredProcedure)
            '
            db.AsignarParametro("p_codigo_iata", CODIGO_IATA, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("CURR_recu_idunidad_agencia", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable()
            '
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_recu_datos_cliente_2009(ByVal cnn As OracleClient.OracleConnection) As Long
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOREGISTRO_AUTO_GUIAS.sp_recu_datos_cliente"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_codigo_cliente", OracleClient.OracleType.VarChar, 20)).Value = CODIGO_CLIENTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("oP_idpersona", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '    cmd.ExecuteNonQuery()

    '    If Not cmd.Parameters("oP_idpersona").Value Is DBNull.Value Then
    '        Return cmd.Parameters("oP_idpersona").Value
    '    Else
    '        Return Nothing
    '    End If
    'End Function
    Public Function sp_recu_datos_cliente() As Long
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOREGISTRO_AUTO_GUIAS.sp_recu_datos_cliente", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input            
            db_bd.AsignarParametro("p_codigo_cliente", CODIGO_CLIENTE, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("oP_idpersona", OracleClient.OracleType.Number)
            '
            db_bd.EjecutarComando()
            If db_bd.Parametros.Length > 0 Then
                Return IIf(db_bd.Parametros(1) Is DBNull.Value, Nothing, db_bd.Parametros(1))
            Else
                Return Nothing
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Function
    'Public Sub sp_recupera_nro_grupo_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOREGISTRO_AUTO_GUIAS.sp_recupera_nro_grupo"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("op_nro_grupo", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '    cmd.ExecuteNonQuery()
    '    nro_grupo = cmd.Parameters("op_nro_grupo").Value
    'End Sub
    Public Sub sp_recupera_nro_grupo()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOREGISTRO_AUTO_GUIAS.sp_recupera_nro_grupo", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input            
            '
            'Variables de salidas 
            db_bd.AsignarParametro("op_nro_grupo", OracleClient.OracleType.Number)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                nro_grupo = IIf(db_bd.Parametros(1) Is DBNull.Value, Nothing, db_bd.Parametros(1))
            Else
                nro_grupo = 0
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
End Class
