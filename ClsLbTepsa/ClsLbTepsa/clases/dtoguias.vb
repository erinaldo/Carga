Imports AccesoDatos
Public Class dtoguias
#Region "VARIALES"
    Dim MyID_REMITENTE As Long
    Dim MyRETOR As Long
    Dim MyIDCENTRO_COSTO As Long
    Dim MyTOTAL_ARTICULO As Double
    Dim MyFACTURADO As Long
    Dim MyIDTIPO_MONEDA As Long
    Dim MyIDDIRECCION_REMITENTE As Long
    Dim MyIDTEFONO_REMITENTE As Long
    Dim MyIDTEFONO_CONSIGNADO As Long
    Dim MyIDCONTACTO_DESTINATARIO As Long
    Dim MyCANTIDAD_X_UNIDAD_ARTI As Long
    Dim MyMONTO_IMPUESTO As Long
    Dim MyPRECIO_X_VOLUMEN As Long
    Dim MyCANTIDAD_X_UNIDAD_VOLUMEN As Long
    Dim MyNRO_REF_GUIA As String
    Dim MyLIQUIDADO As Long
    Dim MyIDCIERRES_LIQUIDACIONES As Long
    Dim MyCARGO As Long
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyPRECIO_X_PESO As Long
    Dim MyIMPUESTO As Long
    Dim MyIDGUIAS_ENVIO_REF As Long
    Dim MyIDGUIAS_ENVIO As Long
    Dim MyFECHA_GUIA As String
    Dim MyNRO_GUIA As String
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Long
    Dim MyIDPERSONA As Long
    Dim MyIDAGENCIAS As Long
    Dim MyIDDIRECCION_DESTINATARIO As Long
    Dim MyIDCONTACTO_REMITENTE As Long
    Dim MyIDTIPO_ENTREGA_CARGA As Long
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDTARIFAS_CARGA_CLIENTE As Long
    Dim MyIDTARIFAS_CARGA As Long
    Dim MyFECHA_DESPACHO As String
    Dim MyFECHA_RECEPCION_DESTINO As String
    Dim MyFECHA_ENTREGA As String
    Dim MyFECHA_CARGOS As String
    Dim MyIDCIUDAD_TRANSITO As Long
    Dim MyTOTAL_PESO As Long
    Dim MyCANTIDAD As Long
    Dim MyTOTAL_VOLUMEN As Long
    Dim MyMONTO_BASE As Long
    Dim MyPRECIO_X_UNIDAD As Long
    Dim MyNOMBRE_RECOJO As String
    Dim MyNOMBRE_ENTREGA As String
    Dim MyDOC_ENTREGA As String
    Dim MyFECHA_RECOJO As String
    Dim MyIDARTICULOS As Long
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyTOTAL_COSTO As Long
    Dim MyIDPREFACTURA As Long
    Dim MyIDFACTURA_CREDITO As Long
    Dim MyIDUSUARIO_REVISION As Long
    Dim MyIDROL_REVISION As Long
    Dim MyFECHA_REVISION As String
    Dim MySERIE_GUIA_ENVIO As Long
    Dim MyIDIMPUESTO As Long
    Dim MyFECHA_INICIO As String
    Dim MyFECHA_FINAL As String
    '29/10/2007
    Dim MyIDTIPO_RECEPCION_DOCU As String
    '26/04/2008
    Dim Myidagencias_destino As Long
    Dim myIDTIPO_FACTURACION As Long
    '27/05/2008
    Dim myNRO_LIQUI_DEVO_CARGO As Long

    'hlamas 18-09-2013
    Dim MyDT As String
    Dim MyProducto As Integer

    'hlamas 24-10-2013
    Dim MySubcuenta As Integer

#End Region
#Region "PROPIEDADES"
    Public Property NRO_LIQUI_DEVO_CARGO() As Long
        Get
            NRO_LIQUI_DEVO_CARGO = myNRO_LIQUI_DEVO_CARGO
        End Get
        Set(ByVal value As Long)
            myNRO_LIQUI_DEVO_CARGO = value
        End Set
    End Property
    Public Property IDTIPO_FACTURACION() As Long
        Get
            IDTIPO_FACTURACION = myIDTIPO_FACTURACION
        End Get
        Set(ByVal value As Long)
            myIDTIPO_FACTURACION = value
        End Set
    End Property
    Public Property idagencias_destino() As Long
        Get
            idagencias_destino = Myidagencias_destino
        End Get
        Set(ByVal value As Long)
            Myidagencias_destino = value
        End Set
    End Property

    Public Property IDTIPO_RECEPCION_DOCU() As String
        Get
            IDTIPO_RECEPCION_DOCU = MyIDTIPO_RECEPCION_DOCU
        End Get
        Set(ByVal value As String)
            MyIDTIPO_RECEPCION_DOCU = value
        End Set
    End Property
    Public Property RETOR() As Long
        Get
            RETOR = MyRETOR
        End Get
        Set(ByVal value As Long)
            MyRETOR = value
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
    Public Property TOTAL_ARTICULO() As Double
        Get
            TOTAL_ARTICULO = MyTOTAL_ARTICULO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_ARTICULO = value
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
    Public Property FACTURADO() As Long
        Get
            FACTURADO = MyFACTURADO
        End Get
        Set(ByVal value As Long)
            MyFACTURADO = value
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
    Public Property CANTIDAD_X_UNIDAD_ARTI() As Long
        Get
            CANTIDAD_X_UNIDAD_ARTI = MyCANTIDAD_X_UNIDAD_ARTI
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_X_UNIDAD_ARTI = value
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
    Public Property PRECIO_X_VOLUMEN() As Long
        Get
            PRECIO_X_VOLUMEN = MyPRECIO_X_VOLUMEN
        End Get
        Set(ByVal value As Long)
            MyPRECIO_X_VOLUMEN = value
        End Set
    End Property
    Public Property CANTIDAD_X_UNIDAD_VOLUMEN() As Long
        Get
            CANTIDAD_X_UNIDAD_VOLUMEN = MyCANTIDAD_X_UNIDAD_VOLUMEN
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_X_UNIDAD_VOLUMEN = value
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
    Public Property LIQUIDADO() As Long
        Get
            LIQUIDADO = MyLIQUIDADO
        End Get
        Set(ByVal value As Long)
            MyLIQUIDADO = value
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
    Public Property PRECIO_X_PESO() As Long
        Get
            PRECIO_X_PESO = MyPRECIO_X_PESO
        End Get
        Set(ByVal value As Long)
            MyPRECIO_X_PESO = value
        End Set
    End Property
    Public Property IMPUESTO() As Long
        Get
            IMPUESTO = MyIMPUESTO
        End Get
        Set(ByVal value As Long)
            MyIMPUESTO = value
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
    Public Property IDGUIAS_ENVIO() As Long
        Get
            IDGUIAS_ENVIO = MyIDGUIAS_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDGUIAS_ENVIO = value
        End Set
    End Property
    Public Property FECHA_GUIA() As String 'NO_DEFINIDO 
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
    Public Property IDUNIDAD_AGENCIA() As Long
        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = value
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
    Public Property IDPERSONA() As Long
        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
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
    Public Property IDTARIFAS_CARGA() As Long
        Get
            IDTARIFAS_CARGA = MyIDTARIFAS_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDTARIFAS_CARGA = value
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
    Public Property IDCIUDAD_TRANSITO() As Long
        Get
            IDCIUDAD_TRANSITO = MyIDCIUDAD_TRANSITO
        End Get
        Set(ByVal value As Long)
            MyIDCIUDAD_TRANSITO = value
        End Set
    End Property
    Public Property TOTAL_PESO() As Long
        Get
            TOTAL_PESO = MyTOTAL_PESO
        End Get
        Set(ByVal value As Long)
            MyTOTAL_PESO = value
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
    Public Property TOTAL_VOLUMEN() As Long
        Get
            TOTAL_VOLUMEN = MyTOTAL_VOLUMEN
        End Get
        Set(ByVal value As Long)
            MyTOTAL_VOLUMEN = value
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
    Public Property PRECIO_X_UNIDAD() As Long
        Get
            PRECIO_X_UNIDAD = MyPRECIO_X_UNIDAD
        End Get
        Set(ByVal value As Long)
            MyPRECIO_X_UNIDAD = value
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
    Public Property DOC_ENTREGA() As String
        Get
            DOC_ENTREGA = MyDOC_ENTREGA
        End Get
        Set(ByVal value As String)
            MyDOC_ENTREGA = value
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
    Public Property IDARTICULOS() As Long
        Get
            IDARTICULOS = MyIDARTICULOS
        End Get
        Set(ByVal value As Long)
            MyIDARTICULOS = value
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
    Public Property IDESTADO_REGISTRO() As Long
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
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
    Public Property FECHA_ACTUALIZACION() As String
        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = value
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
    Public Property TOTAL_COSTO() As Long
        Get
            TOTAL_COSTO = MyTOTAL_COSTO
        End Get
        Set(ByVal value As Long)
            MyTOTAL_COSTO = value
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
    Public Property IDFACTURA_CREDITO() As Long
        Get
            IDFACTURA_CREDITO = MyIDFACTURA_CREDITO
        End Get
        Set(ByVal value As Long)
            MyIDFACTURA_CREDITO = value
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
    Public Property SERIE_GUIA_ENVIO() As Long
        Get
            SERIE_GUIA_ENVIO = MySERIE_GUIA_ENVIO
        End Get
        Set(ByVal value As Long)
            MySERIE_GUIA_ENVIO = value
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
    Public Property FECHA_INICIO() As String
        Get
            FECHA_INICIO = MyFECHA_INICIO
        End Get
        Set(ByVal value As String)
            MyFECHA_INICIO = value
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

    'hlamas 18-09-2013
    Public Property DT As String
        Get
            Return MyDT
        End Get
        Set(ByVal value As String)
            MyDT = value
        End Set
    End Property

    Private intDT As Integer
    Public Property DTFiltro() As Integer
        Get
            Return intDT
        End Get
        Set(ByVal value As Integer)
            intDT = value
        End Set
    End Property


    'hlamas 03-10-2013
    Public Property Producto As Integer
        Get
            Return MyProducto
        End Get
        Set(value As Integer)
            MyProducto = value
        End Set
    End Property

    'hlamas 24-10-2013
    Public Property Subcuenta As Integer
        Get
            Return MySubcuenta
        End Get
        Set(value As Integer)
            MySubcuenta = value
        End Set
    End Property

#End Region
#Region "FUNCIONES"
    'Public Function FN_in_guia_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_GUIAS", 14, _
    '        IDDIRECCION_REMITENTE, 1, IDTEFONO_REMITENTE, 1, IDTEFONO_CONSIGNADO, 1, IDCONTACTO_DESTINATARIO, 1, CANTIDAD_X_UNIDAD_ARTI, MONTO_IMPUESTO, 3, PRECIO_X_VOLUMEN, 3, _
    '      CANTIDAD_X_UNIDAD_VOLUMEN, 3, NRO_REF_GUIA, 2, LIQUIDADO, 1, IDCIERRES_LIQUIDACIONES, 1, CARGO, 1, IDTIPO_COMPROBANTE, 1, IDTIPO_MONEDA, 1, FACTURADO, 1, TOTAL_ARTICULO, 3, _
    '      ID_REMITENTE, 1, IDCENTRO_COSTO, 1, PRECIO_X_PESO, 3, _
    '      IMPUESTO, 3, _
    '      IDGUIAS_ENVIO_REF, 1, _
    '      IDGUIAS_ENVIO, 1, _
    '      FECHA_GUIA, 2, _
    '      NRO_GUIA, 2, _
    '      IDUNIDAD_AGENCIA, 1, _
    '      IDUNIDAD_AGENCIA_DESTINO, 1, _
    '      IDPERSONA, 1, _
    '      IDAGENCIAS, 1, _
    '      IDDIRECCION_DESTINATARIO, 1, _
    '      IDCONTACTO_REMITENTE, 1, _
    '      IDTIPO_ENTREGA_CARGA, 1, _
    '      IDFORMA_PAGO, 1, _
    '      IDTARIFAS_CARGA_CLIENTE, 1, _
    '      IDTARIFAS_CARGA, 1, _
    '      FECHA_DESPACHO, 2, _
    '      FECHA_RECEPCION_DESTINO, 2, _
    '      FECHA_ENTREGA, 2, _
    '      FECHA_CARGOS, 2, _
    '      IDCIUDAD_TRANSITO, 1, _
    '      TOTAL_PESO, 3, _
    '      CANTIDAD, 1, _
    '      TOTAL_VOLUMEN, 3, _
    '      MONTO_BASE, 3, _
    '      PRECIO_X_UNIDAD, 3, _
    '      NOMBRE_RECOJO, 2, _
    '      NOMBRE_ENTREGA, 2, _
    '      DOC_ENTREGA, 2, _
    '      FECHA_RECOJO, 2, _
    '      IDARTICULOS, 1, _
    '      IDUSUARIO_PERSONALMOD, 1, _
    '      IDROL_USUARIO, 1, _
    '      IDROL_USUARIOMOD, 1, _
    '      IP, 2, _
    '      IPMOD, 2, _
    '      IDESTADO_REGISTRO, 1, _
    '      FECHA_REGISTRO, 2, _
    '      FECHA_ACTUALIZACION, 2, _
    '      IDUSUARIO_PERSONAL, 1, _
    '      TOTAL_COSTO, 3, _
    '      IDPREFACTURA, 1, _
    '      IDFACTURA_CREDITO, 1, _
    '      IDUSUARIO_REVISION, 1, _
    '      IDROL_REVISION, 1, _
    '      FECHA_REVISION, 2, _
    '      SERIE_GUIA_ENVIO, 1, _
    '      IDIMPUESTO, 1}

    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView

    '        Return dv
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    'Public Function sp_l_RETOR_CARGA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_rep_general.sp_l_RETOR_CARGA"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_RETOR", OracleClient.OracleType.Number)).Value = RETOR
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = 0
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_NRO_GUIA", OracleClient.OracleType.VarChar)).Value = NRO_GUIA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_facturado", OracleClient.OracleType.VarChar)).Value = FACTURADO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = Me.IDTIPO_ENTREGA_CARGA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDTIPO_RECEPCION_DOCU", OracleClient.OracleType.VarChar)).Value = Me.IDTIPO_RECEPCION_DOCU

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_l_RETOR_CARGA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)


    '    Dim dv As New DataView


    '    Try

    '        dv = ds.Tables(0).DefaultView


    '        Return dv
    '        '' ''Dim dv As New DataView
    '        '' ''Dim Rst As New ADODB.Recordset
    '        '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
    '        '' ''1, 1, _
    '        '' ''Str(IDPERSONA), 2, _
    '        '' ''FECHA_INICIO, 2, _
    '        '' ''FECHA_FINAL, 2 _
    '        '' ''}

    '        '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        '' ''Dim DA As New OleDb.OleDbDataAdapter
    '        '' ''Dim DT As New DataTable
    '        '' ''DA.Fill(DT, Rst)
    '        '' ''dv = DT.DefaultView
    '        '' ''MsgBox(dv.Count)
    '        '' ''Return dv
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    '26/04/2008
    'Public Function sp_l_RETOR_CARGAII_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal FECHA_FILTRO As String) As DataView

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_rep_general.sp_l_RETOR_CARGAII"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_RETOR", OracleClient.OracleType.Number)).Value = RETOR

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FILTRO", OracleClient.OracleType.NVarChar)).Value = FECHA_FILTRO

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA_DESTINO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = Myidagencias_destino 'IDAGENCIAS_DESTINO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_FACTURACION", OracleClient.OracleType.Number)).Value = myIDTIPO_FACTURACION 'IDTIPO_FACTURACION

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = 0
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_NRO_GUIA", OracleClient.OracleType.VarChar)).Value = NRO_GUIA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_facturado", OracleClient.OracleType.VarChar)).Value = FACTURADO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = Me.IDTIPO_ENTREGA_CARGA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDTIPO_RECEPCION_DOCU", OracleClient.OracleType.VarChar)).Value = MyIDTIPO_RECEPCION_DOCU  'Me.IDTIPO_RECEPCION_DOCU


    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_l_RETOR_CARGA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)


    '    Dim dv As New DataView


    '    Try

    '        dv = ds.Tables(0).DefaultView


    '        Return dv
    '        '' ''Dim dv As New DataView
    '        '' ''Dim Rst As New ADODB.Recordset
    '        '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
    '        '' ''1, 1, _
    '        '' ''Str(IDPERSONA), 2, _
    '        '' ''FECHA_INICIO, 2, _
    '        '' ''FECHA_FINAL, 2 _
    '        '' ''}

    '        '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        '' ''Dim DA As New OleDb.OleDbDataAdapter
    '        '' ''Dim DT As New DataTable
    '        '' ''DA.Fill(DT, Rst)
    '        '' ''dv = DT.DefaultView
    '        '' ''MsgBox(dv.Count)
    '        '' ''Return dv
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_l_RETOR_CARGAIII_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal FECHA_FILTRO As String) As DataView



    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_rep_general.sp_l_RETOR_CARGAIII"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_RETOR", OracleClient.OracleType.Number)).Value = RETOR

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FILTRO", OracleClient.OracleType.NVarChar)).Value = FECHA_FILTRO

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_AGENCIA_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA_DESTINO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = idagencias_destino
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_FACTURACION", OracleClient.OracleType.Number)).Value = IDTIPO_FACTURACION

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = 0
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_NRO_GUIA", OracleClient.OracleType.VarChar)).Value = NRO_GUIA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_facturado", OracleClient.OracleType.VarChar)).Value = FACTURADO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = Me.IDTIPO_ENTREGA_CARGA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDTIPO_RECEPCION_DOCU", OracleClient.OracleType.VarChar)).Value = Me.IDTIPO_RECEPCION_DOCU
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_LIQUI_DEVO_CARGO", OracleClient.OracleType.Number)).Value = Me.NRO_LIQUI_DEVO_CARGO

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_l_RETOR_CARGA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)


    '    Dim dv As New DataView


    '    Try

    '        dv = ds.Tables(0).DefaultView


    '        Return dv


    '        '' ''Dim dv As New DataView
    '        '' ''Dim Rst As New ADODB.Recordset
    '        '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
    '        '' ''1, 1, _
    '        '' ''Str(IDPERSONA), 2, _
    '        '' ''FECHA_INICIO, 2, _
    '        '' ''FECHA_FINAL, 2 _
    '        '' ''}

    '        '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        '' ''Dim DA As New OleDb.OleDbDataAdapter
    '        '' ''Dim DT As New DataTable
    '        '' ''DA.Fill(DT, Rst)
    '        '' ''dv = DT.DefaultView
    '        '' ''MsgBox(dv.Count)
    '        '' ''Return dv


    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_l_RETOR_CARGAIII(ByVal FECHA_FILTRO As String) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_rep_general.sp_l_RETOR_CARGAIII", CommandType.StoredProcedure)
            db.AsignarParametro("P_FECHA_FILTRO", FECHA_FILTRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_RETOR", RETOR, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_AGENCIA", IDUNIDAD_AGENCIA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS_DESTINO", idagencias_destino, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDTIPO_FACTURACION", IDTIPO_FACTURACION, OracleClient.OracleType.Number)
            db.AsignarParametro("p_fecha_ini", Me.FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idforma_pago", 0, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idtipo_entrega", Me.IDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_NRO_GUIA", NRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_FACTURADO", FACTURADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_IDTIPO_RECEPCION_DOCU", Me.IDTIPO_RECEPCION_DOCU, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRO_LIQUI_DEVO_CARGO", Me.NRO_LIQUI_DEVO_CARGO, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_l_RETOR_CARGA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function FNLISTAR_GUIAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_GUIAS", 20, IDUNIDAD_AGENCIA, 1, IDUNIDAD_AGENCIA_DESTINO, 1, Str(IDPERSONA), 2, IDTIPO_MONEDA, 1, FECHA_INICIO, 2, FECHA_FINAL, 2, _
    '        LIQUIDADO, 1, _
    '        FACTURADO, 1, _
    '        IDCENTRO_COSTO, 1}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView

    '        Return dv
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function FNLISTAR_GUIAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_LISTAR_GUIAS", CommandType.StoredProcedure)
            db.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idunidad_agencia_destino", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", Str(IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_MONEDA", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_LIQUIDADO", LIQUIDADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FACTURADO", FACTURADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_Idcentro_Costo", IDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LISTAR_GUIAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet.Tables(0).DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function sp_l_RETOR_CARGAIV(ByVal FECHA_FILTRO As String) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("pkg_rep_general.sp_l_RETOR_CARGAIV", CommandType.StoredProcedure)
            db.CrearComando("pkg_rep_general.SP_L_RETOR_CARGAIV_CAR", CommandType.StoredProcedure)
            db.AsignarParametro("P_FECHA_FILTRO", FECHA_FILTRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_RETOR", RETOR, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_AGENCIA", IDUNIDAD_AGENCIA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS_DESTINO", idagencias_destino, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDTIPO_FACTURACION", IDTIPO_FACTURACION, OracleClient.OracleType.Number)
            db.AsignarParametro("p_fecha_ini", Me.FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idforma_pago", 0, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idtipo_entrega", Me.IDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_NRO_GUIA", NRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_FACTURADO", FACTURADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_IDTIPO_RECEPCION_DOCU", Me.IDTIPO_RECEPCION_DOCU, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRO_LIQUI_DEVO_CARGO", Me.NRO_LIQUI_DEVO_CARGO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_DT", Me.DT, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDCENTRO_COSTO", Me.MySubcuenta, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_dt", Me.DTFiltro, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_l_RETOR_CARGA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
