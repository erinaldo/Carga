'Option Explicit On
'Imports Systsem
Imports AccesoDatos
'Imports System.Runtime.Serialization
'<Serializable()> _
Public Class dtoFACTURA
#Region "VARIABLES"
    Dim Myagencia_venta As Integer
    Dim MyPAGI As Char
    Dim MyRAZON_SOCIAL As String
    Dim MyIDAGENCIAS_DESTINO As Long
    Dim MyFECHA_ENTREGA As String

    Dim Myidtipo_entrega As Long
    Dim Myidprocesos As Integer
    Dim MyFACTURADO As Long

    Dim MyIDPREFACTURA As Long

    Dim MyCANTIDAD_X_UNIDAD_ARTI As Double
    Dim MyCANTIDAD_X_UNIDAD_VOLUMEN As Double

    Dim MyUserId As String
    Dim MyDataSource As String
    Dim MyPassword As String

    Dim MyFECHA_CARGO As String
    Dim MyCARGO As Long
    Dim MyOPE As Long
    Dim MyIDGUIAS_ENVIO As Long
    Dim MyIPMOD As String
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyFECHA_INICIO As String
    Dim MyFECHA_FINAL As String
    Dim MyIDAGENCIAS As Long
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDESTADO_ENVIO As Long
    Dim MyIDESTADO_FACTURA As Long
    Dim MyIDCIUDAD_TRANSITO As Long
    Dim MyCANTIDAD As Double
    Dim MyTOTAL_PESO As Double
    Dim MyTOTAL_VOLUMEN As Double
    Dim MyIDGUIA_TRANSPORTISTA As Long
    Dim MyIDGUIA_TRANSPORTISTA_UPD As Long
    Dim MyIDUNIDAD_ORIGEN As Long
    Dim MyIDUNIDAD_DESTINO As Long
    Dim MyIDDIREECION_ORIGEN As Long
    Dim MyIDDIREECION_DESTINO As Long
    Dim MyMONTO_TIPO_CAMBIO As Double
    Dim MyIDTIPO_MONEDA As Long
    Dim MyIDTIPO_SERVICIO_GIRO As Long
    Dim MyFECHA As String
    Dim MyFECHA_VENCIMIENTO As String
    Dim MyMEMO As String
    Dim MyIDPERSONA_ORIGEN As Long
    Dim MyIDPERSONA_DESTINO As Long
    Dim MyIDFACTURA As Long
    Dim MyIDPERSONA As Long
    Dim MySERIE_FACTURA As String
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyNRO_FACTURA As String
    Dim MyFECHA_REGISTRO As String
    Dim MyMONTO_IMPUESTO As Double
    Dim MyTOTAL_COSTO As Double
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDFUNCIONARIO_ACTUAL As Long
    Dim MyIP As String
    Dim MyIDROL_USUARIO As Long
    Dim MySELECCIONAR_TO_FACTURA As Long
    Dim MyNRO_PREFACTURA As String
    Dim MyIDTIPO_RECEPCION_DOCU As String
    '29/10/2007
    Dim Myidcentro_costo As Long
    Dim MyIDGUIAS_ENVIOS As String

    Dim MyNRO_GUIA As String
    Dim MySITU_IMPRESION As String
    Dim MyNRO_GRUPO As Long
    Dim Myes_refactura As Integer
    '27/05/2008 
    Dim MyNRO_LIQUI_DEVO_CARGO As Long
    Dim MyIdtipo_recep_docuS As String
    '
    Dim MYes_carga_asegurada As Long
    Dim MyIDTIPO_FACTURACION As Long
    '    
    Dim myidusuario_seleccion As Long
    Dim my_idfuncionarioNegocio As Long
    '
    'Add - 24/04/2009 
    Dim my_seleccion As Long
    '
    Dim Mymesaje As String
    '13/08/2010
    Dim my_carga_acompanada As Long
    Dim my_producto As Integer
#End Region
#Region "ATRIBUTOS"
    Public Property carga_acompanada() As Long
        Get
            carga_acompanada = my_carga_acompanada
        End Get
        Set(ByVal value As Long)
            my_carga_acompanada = value
        End Set
    End Property
    Public Property idseleccion() As Long
        Get
            idseleccion = my_seleccion
        End Get
        Set(ByVal value As Long)
            my_seleccion = value
        End Set
    End Property
    Public Property IDTIPO_FACTURACION() As Long
        Get
            IDTIPO_FACTURACION = MyIDTIPO_FACTURACION
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_FACTURACION = value
        End Set
    End Property

    Public Property IDPROCESOS() As Integer
        Get
            IDPROCESOS = Myidprocesos
        End Get
        Set(ByVal value As Integer)
            Myidprocesos = value
        End Set
    End Property

    Public Property ES_CARGA_ASEGURADA() As Long
        Get
            ES_CARGA_ASEGURADA = MYes_carga_asegurada
        End Get
        Set(ByVal value As Long)
            MYes_carga_asegurada = value
        End Set
    End Property
    Public Property IDGUIAS_ENVIOS() As String
        Get
            IDGUIAS_ENVIOS = MyIDGUIAS_ENVIOS
        End Get
        Set(ByVal value As String)
            MyIDGUIAS_ENVIOS = value
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

    Public Property SITU_IMPRESION() As String
        Get
            SITU_IMPRESION = MySITU_IMPRESION
        End Get
        Set(ByVal value As String)
            MySITU_IMPRESION = value
        End Set
    End Property

    Public Property NRO_GRUPO() As Long
        Get
            NRO_GRUPO = MyNRO_GRUPO
        End Get
        Set(ByVal value As Long)
            MyNRO_GRUPO = value
        End Set
    End Property
    Public Property idcentro_costo() As Long
        Get
            idcentro_costo = Myidcentro_costo
        End Get
        Set(ByVal value As Long)
            Myidcentro_costo = value
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
    Public Property agencia_venta() As Integer
        Get
            agencia_venta = Myagencia_venta
        End Get
        Set(ByVal value As Integer)
            Myagencia_venta = value
        End Set
    End Property
    Public Property IDFUNCIONARIO_ACTUAL() As Long
        Get
            IDFUNCIONARIO_ACTUAL = MyIDFUNCIONARIO_ACTUAL
        End Get
        Set(ByVal value As Long)
            MyIDFUNCIONARIO_ACTUAL = value
        End Set
    End Property
    Public Property IDTIPO_ENTREGA() As Long
        Get
            IDTIPO_ENTREGA = Myidtipo_entrega
        End Get
        Set(ByVal value As Long)
            Myidtipo_entrega = value
        End Set
    End Property

    Private intEstadoEnvio As Integer
    Public Property EstadoEnvio() As Integer
        Get
            Return intEstadoEnvio
        End Get
        Set(ByVal value As Integer)
            intEstadoEnvio = value
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
    Public Property SELECCIONAR_TO_FACTURA() As Long
        Get
            SELECCIONAR_TO_FACTURA = MySELECCIONAR_TO_FACTURA
        End Get
        Set(ByVal value As Long)
            MySELECCIONAR_TO_FACTURA = value
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
    Public Property IDPREFACTURA() As Long
        Get
            IDPREFACTURA = MyIDPREFACTURA
        End Get
        Set(ByVal value As Long)
            MyIDPREFACTURA = value
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
    Public Property CANTIDAD_X_UNIDAD_ARTI() As Double
        Get
            CANTIDAD_X_UNIDAD_ARTI = MyCANTIDAD_X_UNIDAD_ARTI
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD_X_UNIDAD_ARTI = value
        End Set
    End Property
    Public Property UserId() As String
        Get
            UserId = MyUserId
        End Get
        Set(ByVal value As String)
            MyUserId = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Password = MyPassword
        End Get
        Set(ByVal value As String)
            MyPassword = value
        End Set
    End Property
    Public Property DataSource() As String
        Get
            DataSource = MyDataSource
        End Get
        Set(ByVal value As String)
            MyDataSource = value
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
    Public Property PAGI() As String
        Get
            PAGI = MyPAGI
        End Get
        Set(ByVal value As String)
            MyPAGI = value
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

    Public Property CARGO() As Long
        Get
            CARGO = MyCARGO
        End Get
        Set(ByVal value As Long)
            MyCARGO = value
        End Set
    End Property
    Public Property OPE() As Long
        Get
            OPE = MyOPE
        End Get
        Set(ByVal value As Long)
            MyOPE = value
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
    Public Property IPMOD() As String
        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
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
    Public Property IDROL_USUARIOMOD() As Long
        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIOMOD = value
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
    Public Property IDAGENCIAS_DESTINO() As Long
        Get
            IDAGENCIAS_DESTINO = MyIDAGENCIAS_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_DESTINO = value
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
    Public Property CANTIDAD() As Double
        Get
            CANTIDAD = MyCANTIDAD
        End Get
        Set(ByVal value As Double)
            MyCANTIDAD = value
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
    Public Property FECHA() As String 'NO_DEFINIDO 
        Get
            FECHA = MyFECHA
        End Get
        Set(ByVal value As String)
            MyFECHA = value
        End Set
    End Property
    Public Property FECHA_VENCIMIENTO() As String 'NO_DEFINIDO 
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
    Public Property NRO_PREFACTURA() As String
        Get
            NRO_PREFACTURA = MyNRO_PREFACTURA
        End Get
        Set(ByVal value As String)
            MyNRO_PREFACTURA = value
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
    Public Property IDUSUARIO_PERSONAL() As Long
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
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
    Public Property mensaje() As String
        Get
            mensaje = Mymesaje
        End Get
        Set(ByVal value As String)
            Mymesaje = value
        End Set
    End Property

    Private intTipoCuenta As Integer
    Public Property TipoCuenta() As Integer
        Get
            Return intTipoCuenta
        End Get
        Set(ByVal value As Integer)
            intTipoCuenta = value
        End Set
    End Property

    Private strMotivo As String
    Public Property Motivo() As String
        Get
            Return strMotivo
        End Get
        Set(ByVal value As String)
            strMotivo = value
        End Set
    End Property

    Private intUsuario As Integer
    Public Property Usuario() As Integer
        Get
            Return intUsuario
        End Get
        Set(ByVal value As Integer)
            intUsuario = value
        End Set
    End Property

    Private intTipoAfectacion As Integer
    Public Property TipoAfectacion() As Integer
        Get
            Return intTipoAfectacion
        End Get
        Set(ByVal value As Integer)
            intTipoAfectacion = value
        End Set
    End Property

    Private strNumeroDocumento As String
    Public Property NumeroDocumento() As String
        Get
            Return strNumeroDocumento
        End Get
        Set(ByVal value As String)
            strNumeroDocumento = value
        End Set
    End Property

    Private strRazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return strRazonSocial
        End Get
        Set(ByVal value As String)
            strRazonSocial = value
        End Set
    End Property


#End Region
#Region "METODOS"
    Public Property idfuncionarioNegocio() As Long
        Get
            idfuncionarioNegocio = my_idfuncionarioNegocio
        End Get
        Set(ByVal value As Long)
            my_idfuncionarioNegocio = value
        End Set
    End Property
    Public Property idusuario_seleccion() As Long
        Get
            idusuario_seleccion = myidusuario_seleccion
        End Get
        Set(ByVal value As Long)
            myidusuario_seleccion = value
        End Set
    End Property
    Public Property Idtipo_recep_docuS() As String
        Get
            Idtipo_recep_docuS = MyIdtipo_recep_docuS
        End Get
        Set(ByVal value As String)
            MyIdtipo_recep_docuS = value
        End Set
    End Property
    Public Property NRO_LIQUI_DEVO_CARGO() As Long
        Get
            NRO_LIQUI_DEVO_CARGO = MyNRO_LIQUI_DEVO_CARGO
        End Get
        Set(ByVal value As Long)
            MyNRO_LIQUI_DEVO_CARGO = value
        End Set
    End Property
    Public Property es_refactura() As Double
        Get
            es_refactura = Myes_refactura
        End Get
        Set(ByVal value As Double)
            Myes_refactura = value
        End Set
    End Property

    Public Property Producto As Integer
        Get
            Return my_producto
        End Get
        Set(value As Integer)
            my_producto = value
        End Set
    End Property

    'Public Function FNINUPDE_FACTURA(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean

    '    FNINUPDE_FACTURA = True

    '    'Dim DT As New DataTable
    '    'Dim Rst As New ADODB.Recordset
    '    'Dim dv As New DataView
    '    'Dim DA As New OleDb.OleDbDataAdapter
    '    'Dim m As LONG

    '    'Dim a As LONG = 0
    '    'Try
    '    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA", 62, _
    '    '    1, 1, _
    '    '    IDFORMA_PAGO, 1, _
    '    '    IDESTADO_ENVIO, 1, _
    '    '    IDESTADO_FACTURA, 1, _
    '    '    IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), 1, _
    '    '    CANTIDAD, 3, _
    '    '    TOTAL_PESO, 3, _
    '    '    TOTAL_VOLUMEN, 3, _
    '    '    IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), 1, _
    '    '    IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), 1, _
    '    '    IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), 1, _
    '    '    IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), 1, _
    '    '    IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), 1, _
    '    '    IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), 1, _
    '    '    MONTO_TIPO_CAMBIO, 3, _
    '    '    IDTIPO_MONEDA, 1, _
    '    '    FECHA, 2, _
    '    '    FECHA_VENCIMIENTO, 2, _
    '    '    IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), 1, _
    '    '    IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), 1, _
    '    '    Str(IDPERSONA), 2, _
    '    '    IDTIPO_COMPROBANTE, 1, _
    '    '    MONTO_IMPUESTO, 3, _
    '    '    TOTAL_COSTO, 3, _
    '    '    IDAGENCIAS, 1, _
    '    '    IDUSUARIO_PERSONAL, 1, _
    '    '    IP, 2, _
    '    '    IDROL_USUARIO, 1, _
    '    '    CANTIDAD_X_UNIDAD_ARTI, 3, _
    '    '    CANTIDAD_X_UNIDAD_VOLUMEN, 3 _
    '    '    }

    '    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    '    DA.Fill(DT, Rst)
    '    '    dv = DT.DefaultView

    '    '    If Not dv.Count = 0 Then
    '    '        If Not dv.Table.Rows(0).IsNull(0) Then
    '    '            If dv.Table.Rows(0)(0) = -666 Then
    '    '                m = 1 / a
    '    '            End If
    '    '        End If
    '    '    End If

    '    '    IDFACTURA = dv.Table.Rows(0)(0)

    '    'Catch ex As System.Exception
    '    '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    'End Try


    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_INUPDE_FACTURA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OPE", OracleClient.OracleType.Int16)).Value = 1
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFORMA_PAGO", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_FACTURA", OracleClient.OracleType.Number)).Value = (IDESTADO_FACTURA)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCIUDAD_TRANSITO", OracleClient.OracleType.Number)).Value = IDCIUDAD_TRANSITO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CANTIDAD", OracleClient.OracleType.Number)).Value = (CANTIDAD)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_PESO", OracleClient.OracleType.Double)).Value = (TOTAL_PESO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_VOLUMEN", OracleClient.OracleType.Double)).Value = (TOTAL_VOLUMEN)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDGUIA_TRANSPORTISTA", OracleClient.OracleType.Number)).Value = IDGUIA_TRANSPORTISTA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDGUIA_TRANSPORTISTA_UPD", OracleClient.OracleType.Number)).Value = IDGUIA_TRANSPORTISTA_UPD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.Number)).Value = IDUNIDAD_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIREECION_ORIGEN", OracleClient.OracleType.Number)).Value = IDDIREECION_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIREECION_DESTINO", OracleClient.OracleType.Number)).Value = IDDIREECION_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_TIPO_CAMBIO", OracleClient.OracleType.Double)).Value = (MONTO_TIPO_CAMBIO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MONEDA", OracleClient.OracleType.Number)).Value = (IDTIPO_MONEDA)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA", OracleClient.OracleType.NVarChar)).Value = (FECHA)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_VENCIMIENTO", OracleClient.OracleType.NVarChar)).Value = (FECHA_VENCIMIENTO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA_ORIGEN", OracleClient.OracleType.Number)).Value = IDPERSONA_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA_DESTINO", OracleClient.OracleType.Number)).Value = IDPERSONA_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.NVarChar)).Value = (Str(IDPERSONA))
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = (IDTIPO_COMPROBANTE)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_IMPUESTO", OracleClient.OracleType.Double)).Value = (MONTO_IMPUESTO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_COSTO", OracleClient.OracleType.Double)).Value = (TOTAL_COSTO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = (IDAGENCIAS)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = (IDUSUARIO_PERSONAL)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.NVarChar)).Value = (IP)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = (IDROL_USUARIO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CANTIDAD_X_UNIDAD_ARTI", OracleClient.OracleType.Double)).Value = (CANTIDAD_X_UNIDAD_ARTI)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CANTIDAD_X_UNIDAD_VOLUMEN", OracleClient.OracleType.Double)).Value = (CANTIDAD_X_UNIDAD_VOLUMEN)

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_IDFACTURA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_ERR", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        Dim ds As New DataSet
    '        daora.Fill(ds)


    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView

    '        IDFACTURA = dv.Table.Rows(0)(0)

    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    'Public Function fn_INUPDE_FACTURA_FROM_PREFACT_2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fn_INUPDE_FACTURA_FROM_PREFACT_2009 = True

    '    Dim DT As New DataTable
    '    Dim Rst As New ADODB.Recordset
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Long

    '    Dim a As Long = 0
    '    Try

    '        'IDESTADO_FACTURA, 1, 
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA_FROM_PREFACT", 62, _
    '        1, 1, _
    '        IDFORMA_PAGO, 1, _
    '        IDESTADO_ENVIO, 1, _
    '        CType(IDESTADO_FACTURA, String), 2, _
    '        IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), 1, _
    '        CANTIDAD, 3, _
    '        TOTAL_PESO, 3, _
    '        TOTAL_VOLUMEN, 3, _
    '        IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), 1, _
    '        IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), 1, _
    '        IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), 1, _
    '        IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), 1, _
    '        IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), 1, _
    '        IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), 1, _
    '        MONTO_TIPO_CAMBIO, 3, _
    '        IDTIPO_MONEDA, 1, _
    '        FECHA, 2, _
    '        FECHA_VENCIMIENTO, 2, _
    '        IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), 1, _
    '        IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), 1, _
    '        IDPERSONA, 1, _
    '        IDTIPO_COMPROBANTE, 1, _
    '        MONTO_IMPUESTO, 3, _
    '        TOTAL_COSTO, 3, _
    '        IDAGENCIAS, 1, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IP, 2, _
    '        IDROL_USUARIO, 1, _
    '        CANTIDAD_X_UNIDAD_ARTI, 3, _
    '        CANTIDAD_X_UNIDAD_VOLUMEN, 3 _
    '        }
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView

    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If dv.Table.Rows(0)(0) = -666 Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        IDFACTURA = dv.Table.Rows(0)(0)

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    'Public Function FN_L_FACTURAS_FROM_PREFACTU_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        'IDPERSONA, 1, _
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_L_FACTURAS_FROM_PREFACTU", 10, _
    '        1, 1, _
    '        CType(IDPERSONA, String), 2, _
    '        FECHA_INICIO, 2, _
    '        FECHA_FINAL, 2 _
    '        }

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
    'Public Function FNPREFACTURAS_GUIAS2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        ' IDPREFACTURA, 1 _
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_PREFACTURAS_GUIAS", 4, _
    '        CType(IDPREFACTURA, String), 2 _
    '       }

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

    'Public Function FN_QUITAR_FACTURAS_PREFACTURAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        '
    '        'IDFACTURA 1 
    '        'IDPREFACTURA, 1
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_QUITAR_FACTURAS_PREFACTURAS", 14, _
    '        OPE, 1, _
    '        CType(IDPREFACTURA, String), 2, _
    '        CType(IDFACTURA, String), 2, _
    '        IPMOD, 2, _
    '        IDUSUARIO_PERSONALMOD, 1, _
    '        IDROL_USUARIOMOD, 1}
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
    'Public Function FN_CARGO_FACTU_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CARGO_FACTU", 10, _
    '        IDFACTURA.ToString, 2, _
    '        CARGO, 1, _
    '        IDPERSONA.ToString, 2, _
    '        FECHA_CARGO, 2}
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
    'Public Function FN_L_FACTU_AUTO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal VOCONTROLUSUARIO As Object, ByRef dv_L_GUIAS_COMPRO As DataView) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_L_FACTU_AUTO"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_FACTU_AUTO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_GUIAS_COMPRO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    '
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        dv_L_GUIAS_COMPRO = ds.Tables(1).DefaultView
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_ESTADO_IMPRESO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)

    '    Try

    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_ESTADO_IMPRESO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA

    '        cmd.ExecuteNonQuery()
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_ESTADO_IMPRESO()
        '
        Dim db As New BaseDatos
        '
        Try
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_ESTADO_IMPRESO", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_IDFACTURA", IDFACTURA, OracleClient.OracleType.Int32)
            'Parametro de Salida 
            '
            db.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'desconectar 
            db.Desconectar()
        End Try
    End Function
    'Public Function FN_ConsulFactuEmi_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulFactuEmi"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    '
    '    Try

    '        dv = ds.Tables(0).DefaultView


    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_ConsulFactuEmi() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmi", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Number) 'gunners
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Parametro de Salida 
            db.AsignarParametro("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)
            'desconectar 
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_CONSUL_GUIAS_EMI_DG_2009(ByVal VOCONTROLUSUARIO As Object) As DataView

    '    ''''''''''''''''''''''''''''''''''''''''
    '    'IIf(IDPERSONA = 0, -666,IDPERSONA), 1, _
    '    ''''''''''''''''''''''''''''''
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG", 16, _
    '    IIf(IDPERSONA = 0, "-666", CType(IDPERSONA, String)), 2, _
    '    IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), 1, _
    '    IIf(IDTIPO_MONEDA = 0, -666, IDTIPO_MONEDA), 1, _
    '    IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), 1, _
    '    IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    '
    '    DA.Fill(dT, Rst)
    '    '
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        '
    '        Return dv
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_CONSUL_GUIAS_EMI_DG__2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataView

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG_"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_CONSUL_GUIAS_EMI_DG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    '
    '    Try
    '        '
    '        dv = ds.Tables(0).DefaultView


    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try


    '    '  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '  Dim m As LONG
    '    '  Dim a As LONG = 0
    '    '  Dim dT As New DataTable
    '    '  Dim dv As New DataView
    '    '  Dim DA As New OleDb.OleDbDataAdapter
    '    '  Dim Rst As New ADODB.Recordset
    '    '  Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG_", 16, _
    '    '  IIf(IDPERSONA = 0, -666, Str(IDPERSONA)), 2, _
    '    'IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), 1, _
    '    'IIf(IDTIPO_MONEDA = 0, -666, IDTIPO_MONEDA), 1, _
    '    'IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), 1, _
    '    'IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), 1, _
    '    'FECHA_INICIO, 2, _
    '    'FECHA_FINAL, 2}
    '    '  Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    '  DA.Fill(dT, Rst)
    '    '  Try
    '    '      dv = dT.DefaultView
    '    '      If Not dv.Count = 0 Then
    '    '          If Not dv.Table.Rows(0).IsNull(0) Then
    '    '              If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '    '                  m = 1 / a
    '    '              End If
    '    '          End If
    '    '      End If
    '    '      Return dv
    'End Function
    'Public Function FN_ConsulPreFactuEmi_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulPreFactuEmi"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_PREFACTURA", OracleClient.OracleType.VarChar)).Value = NRO_PREFACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_FACTURADO", OracleClient.OracleType.VarChar)).Value = FACTURADO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_ConsulPreFactuEmi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    Public Function FN_ConsulPreFactuEmi() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_ConsulPreFactuEmi", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_facturado", FACTURADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_nro_prefactura", NRO_PREFACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Parametro de Salida 
            db.AsignarParametro("cur_ConsulPreFactuEmi", OracleClient.OracleType.Cursor)
            'desconectar 
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_ConsulPreFactuEmi__2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulPreFactuEmi_"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_PREFACTURA", OracleClient.OracleType.VarChar)).Value = NRO_PREFACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_FACTURADO", OracleClient.OracleType.VarChar)).Value = FACTURADO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_ConsulPreFactuEmi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

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
    Public Function FN_ConsulPreFactuEmi_() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_ConsulPreFactuEmi_", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_facturado", FACTURADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_nro_prefactura", NRO_PREFACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Parametro de Salida 
            db.AsignarParametro("cur_ConsulPreFactuEmi", OracleClient.OracleType.Cursor)
            'desconectar 
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        ''''
    End Function

    'Public Function FN_ConsulFactuEmiPorCobrar_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulFactuEmiPorCobrar"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    '
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_L_FACTU_AUTO_T3_2009(ByVal VOCONTROLUSUARIO As Object, ByRef DV_L_FACTU_AUTOT3 As DataView, ByRef dv_L_PREFACTU_COMPRO As DataView)

    '    Dim Rst As New ADODB.Recordset
    '    Dim Rst1 As New ADODB.Recordset
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim DT As New DataTable
    '    Dim A As Long = 0
    '    Dim M As Long

    '    DV_L_FACTU_AUTOT3 = New DataView
    '    dv_L_PREFACTU_COMPRO = New DataView

    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_L_FACTU_AUTOT3", 2}

    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        DA.Fill(DT, Rst)
    '        DV_L_FACTU_AUTOT3 = DT.DefaultView

    '        Rst1 = Rst.NextRecordset
    '        DT = New DataTable
    '        DA.Fill(DT, Rst1)
    '        DV_L_FACTU_AUTOT3 = DT.DefaultView


    '        If Not DV_L_FACTU_AUTOT3.Count = 0 Then
    '            If Not DV_L_FACTU_AUTOT3.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(DV_L_FACTU_AUTOT3.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    M = 1 / A
    '                End If
    '            End If
    '        End If
    '        Return DV_L_FACTU_AUTOT3
    '    Catch ex As System.Exception
    '        MsgBox(DV_L_FACTU_AUTOT3.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    '    Public Function FN_CONSUL_GUIAS_CARGO_DG(ByVal VOCONTROLUSUARIO As Object) As DataView
    '        Dim m As Long
    '        Dim a As Long = 0
    '        Dim dT As New DataTable
    '        Dim dv As New DataView
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_CARGO_DG", 18, _
    '        IIf(IDPERSONA = 0, -666, IDPERSONA), 1, _
    '      IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), 1, _
    '      IIf(IDTIPO_MONEDA = 0, -666, IDTIPO_MONEDA), 1, _
    '      IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), 1, _
    '      IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), 1, _
    'IIf(CARGO = 2, -666, CARGO), 1, _
    '      FECHA_INICIO, 2, _
    '      FECHA_FINAL, 2}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        DA.Fill(dT, Rst)
    '        Try
    '            dv = dT.DefaultView
    '            If Not dv.Count = 0 Then
    '                If Not dv.Table.Rows(0).IsNull(0) Then
    '                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                        m = 1 / a
    '                    End If
    '                End If
    '            End If
    '            Return dv
    '        Catch ex As System.Exception
    '            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Catch OEx As System.Data.OracleClient.OracleException
    '            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End Try
    '    End Function
    Public Function FN_CONSUL_GUIAS_CARGO_DG() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_CONSUL_GUIAS_CARGO_DG", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", IIf(IDPERSONA = 0, -666, IDPERSONA), OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idforma_pago", IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idtipo_moneda", IIf(IDTIPO_MONEDA = 0, -666, IDTIPO_MONEDA), OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idagencias", IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), OracleClient.OracleType.Int32)
            db.AsignarParametro("p_cargo", IIf(CARGO = 2, -666, CARGO), OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_CONSUL_CARGO_EMI_DG", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_CONSUL_GUIAS_EMI_DG2_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    '
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG2", 20, _
    '    CType(IDPERSONA, String), 2, _
    '  IDFORMA_PAGO, 1, _
    '  IDTIPO_MONEDA, 1, _
    '  IDAGENCIAS, 1, _
    '  IDUSUARIO_PERSONAL, 1, _
    '  FECHA_INICIO, 2, _
    '  FECHA_FINAL, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '            IDUNIDAD_DESTINO, 1}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_CONSUL_GUIAS_EMI_DG2() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG2", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", CType(IDPERSONA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idunidad_agencia", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idunidad_agencia_destino", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_CONSUL_GUIAS_EMI_DG", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_CONSUL_GUIAS_CARGO_docu_DG_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_CARGO_docu_DG", 18, _
    '    CType(IDPERSONA, String), 2, _
    '  IDFORMA_PAGO, 1, _
    '  IDTIPO_MONEDA, 1, _
    '  IDAGENCIAS, 1, _
    '  IDUSUARIO_PERSONAL, 1, _
    'CARGO, 1, _
    '  FECHA_INICIO, 2, _
    '  FECHA_FINAL, 2}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_CONSUL_GUIAS_CARGO_docu_DG() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_CONSUL_GUIAS_CARGO_docu_DG", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_cargo", CARGO, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Parametro de Salida 
            db.AsignarParametro("CUR_CONSUL_CARGO_EMI_DG", OracleClient.OracleType.Cursor)
            'desconectar 
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function SP_LIST_FACTURADOS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LIST_FACTURADOS", 8, _
    '  IDUSUARIO_PERSONAL, 1, _
    '  FECHA_INICIO, 2, _
    '  FECHA_FINAL, 2}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_LIST_FACTURADOS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 01-06-2014
            'db.CrearComando("PKG_IVOFACTURACION.SP_LIST_FACTURADOS", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOFACTURACION.SP_LIST_FACTURADOS_CAR", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LIST_FACTURADOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuEmiConta_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaII", 28, _
    '    IDPERSONA, 1, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    'Public Function SP_CONSUL_GUIAS_ETREGA_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    'IIf(IDPERSONA = 0, "-666", ctype(IDPERSONA,string), 1, _
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    'Ojo verificar 
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_ETREGA", 20, _
    '        IIf(CType(IDPERSONA, String) = "0", "-666", CType(IDPERSONA, String)), 2, _
    '        IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), 1, _
    '        IIf(IDTIPO_MONEDA = 0, -666, IDTIPO_MONEDA), 1, _
    '        IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), 1, _
    '        IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), 1, _
    '        FECHA_INICIO, 2, _
    '        FECHA_FINAL, 2, _
    '        IDUNIDAD_ORIGEN, 1, _
    '        IDUNIDAD_DESTINO, 1}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_CONSUL_GUIAS_ETREGA() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_CONSUL_GUIAS_ETREGA", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idunidad_agencia", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idunidad_agencia_destino", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            'Parametro de Salida 
            db.AsignarParametro("CUR_CONSUL_GUIAS_ETREGA", OracleClient.OracleType.Cursor)
            'desconectar 
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FNLISTAR_FACTURAS(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_LISTAR_FACTURAS"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_OPE", OracleClient.OracleType.Int32)).Value = 1
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_FACTURAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_ERR", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

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
    Public Function FNLISTAR_FACTURAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPE", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_FACTURAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet.Tables(0).DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_INUPDE_FACTURA_FROM_PREFAC_(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fn_INUPDE_FACTURA_FROM_PREFAC_ = True

    '    Dim DT As New DataTable
    '    Dim Rst As New ADODB.Recordset
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Long

    '    Dim a As Long = 0
    '    Try


    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA_FROM_PREFAC_", 62, _
    '        1, 1, _
    '        IDFORMA_PAGO, 1, _
    '        IDESTADO_ENVIO, 1, _
    '        IDESTADO_FACTURA, 1, _
    '        IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), 1, _
    '        CANTIDAD, 3, _
    '        TOTAL_PESO, 3, _
    '        TOTAL_VOLUMEN, 3, _
    '        IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), 1, _
    '        IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), 1, _
    '        IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), 1, _
    '        IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), 1, _
    '        IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), 1, _
    '        IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), 1, _
    '        MONTO_TIPO_CAMBIO, 3, _
    '        IDTIPO_MONEDA, 1, _
    '        FECHA, 2, _
    '        FECHA_VENCIMIENTO, 2, _
    '        IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), 1, _
    '        IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), 1, _
    '        Str(IDPERSONA), 2, _
    '        IDTIPO_COMPROBANTE, 1, _
    '        MONTO_IMPUESTO, 3, _
    '        TOTAL_COSTO, 3, _
    '        IDAGENCIAS, 1, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IP, 2, _
    '        IDROL_USUARIO, 1, _
    '        CANTIDAD_X_UNIDAD_ARTI, 3, _
    '        CANTIDAD_X_UNIDAD_VOLUMEN, 3 _
    '        }
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView

    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If dv.Table.Rows(0)(0) = -666 Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        IDFACTURA = dv.Table.Rows(0)(0)

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    'Public Function sp_l_desti_dife_carga_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_rep_general.sp_l_desti_dife_carga"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_l_desti_dife_carga", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


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
    '
    Public Function sp_l_desti_dife_carga() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("pkg_rep_general.sp_l_desti_dife_carga", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_FECHA_INI", Me.FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int16)
            db.AsignarParametro("p_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int16)
            'Parametro de Salida 
            db.AsignarParametro("cur_l_desti_dife_carga", OracleClient.OracleType.Cursor)
            'desconectar 
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    'Public Function sp_l_carga_conta_ge_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_rep_general.sp_l_carga_conta_ge"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_ORIGEN
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_DESTINO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFUNCIONARIO_ACTUAL", OracleClient.OracleType.VarChar)).Value = IDFUNCIONARIO_ACTUAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_l_carga_conta_ge", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


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

    'Public Function SP_ConsulFactuEmiContaIII_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIII", 28, _
    '    IDPERSONA.ToString, 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    Public Function SP_ConsulFactuEmiContaIII(ByVal P_ENTRE As Long) As DataView
        Try
            '
            Dim m As Long
            Dim a As Long = 0
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 06-01-2014
            'db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIII", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOFACTURACION.sp_consulta_venta_funcionario", CommandType.StoredProcedure)

            'db_bd.CrearComando("PKG_IVOFACTURACION.sp_list_deta_linea_credito_3_c", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_entre", P_ENTRE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_producto", Producto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_tipo_cartera", TipoCuenta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_usuario", Usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi_conta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dv = ldt_tmp.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If
            '
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function SP_ConsulFactuEmiContaIV_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    'IDPERSONA, 1, _
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIV", 28, _
    '    CType(IDPERSONA, String), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    IDESTADO_ENVIO, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_ConsulFactuEmiContaIV() As DataView
        'IDPERSONA, 1, _
        Dim m As Long
        Dim a As Long = 0
        Dim dv As New DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIV", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idestado_envio", IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi_conta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dv = ldt_tmp.DefaultView
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function sp_L_CARGA_CONTA_CHECK_PCE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.sp_L_CARGA_CONTA_CHECK_PCE"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_ENTREGA", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_SERIE_FACTURA", OracleClient.OracleType.VarChar)).Value = SERIE_FACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_FACTURA", OracleClient.OracleType.VarChar)).Value = NRO_FACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = IDAGENCIAS_DESTINO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_CARGA_CONTA_CHECK_PCE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function sp_L_CARGA_CONTA_CHECK_PCE() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.sp_L_CARGA_CONTA_CHECK_PCE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("P_FECHA_INI", Me.FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDTIPO_ENTREGA", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_SERIE_FACTURA", SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_NRO_FACTURA", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDAGENCIAS_DESTINO", IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_CARGA_CONTA_CHECK_PCE", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_ENTREGAR_BULTO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_ENTREGAR_BULTO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IPMOD", OracleClient.OracleType.VarChar)).Value = Me.IPMOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONALMOD", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONALMOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIOMOD", OracleClient.OracleType.Number)).Value = IDROL_USUARIOMOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ENTREGA", OracleClient.OracleType.VarChar)).Value = FECHA_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_ENTREGAR_BULTO()
        Dim db As New BaseDatos
        '
        Try
            db.Conectar()
            'Invocar al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_ENTREGAR_BULTO", CommandType.StoredProcedure)
            'Parametro de entrada 
            db.AsignarParametro("P_IPMOD", Me.IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_ENTREGA", FECHA_ENTREGA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDFACTURA", IDFACTURA, OracleClient.OracleType.Int32)
            'Parametro de Salida 
            '
            db.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'desconectar 
            db.Desconectar()
        End Try
    End Sub
    'Public Function SP_l_pasa_credi_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_l_pasa_credi"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INIcial", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_SERIE_comproBANTE", OracleClient.OracleType.VarChar)).Value = SERIE_FACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_COMPROBANTE", OracleClient.OracleType.VarChar)).Value = NRO_FACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_l_pasa_credi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
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
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_l_pasa_credi() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_l_pasa_credi", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("P_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FECHA_INIcial", Me.FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_serie_comprobante", SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_NRO_COMPROBANTE", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_l_pasa_credi", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function RGT_BUSCA_FECHA_PAGO_PCE_2009(ByVal cnnSQL As System.Data.SqlClient.SqlConnection) As DataView
    '    Dim cmd As New System.Data.SqlClient.SqlCommand
    '    cmd.Connection = cnnSQL
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "RGT_BUSCA_FECHA_PAGO_PCE"
    '    cmd.Parameters.Add(New SqlClient.SqlParameter("@P_SERIE", SqlDbType.BigInt)).Value = CLng(SERIE_FACTURA)
    '    cmd.Parameters.Add(New SqlClient.SqlParameter("@P_NUMERO", SqlDbType.BigInt)).Value = CLng(NRO_FACTURA)
    '    Dim daora As New System.Data.SqlClient.SqlDataAdapter(cmd)
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
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function RGT_BUSCA_FECHA_PAGO_PCE(ByVal cnnSQL As System.Data.SqlClient.SqlConnection) As DataView
        ' Usa una conexión con el ofisis 
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.Connection = cnnSQL
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "RGT_BUSCA_FECHA_PAGO_PCE"
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_SERIE", SqlDbType.BigInt)).Value = CLng(SERIE_FACTURA)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_NUMERO", SqlDbType.BigInt)).Value = CLng(NRO_FACTURA)
        Dim daora As New System.Data.SqlClient.SqlDataAdapter(cmd)
        Dim ds As New DataSet
        daora.Fill(ds)
        Dim dv As New DataView
        Try
            dv = ds.Tables(0).DefaultView
            Return dv
        Catch
            Throw
        End Try
    End Function

    'Public Sub sp_upda_fecha_entre_pce_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.sp_upda_fecha_entre_pce"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ENTREGA", OracleClient.OracleType.VarChar)).Value = FECHA_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA

    '        cmd.ExecuteNonQuery()

    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub sp_upda_fecha_entre_pce()
        Dim db_bd As New BaseDatos
        Try
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.sp_upda_fecha_entre_pce", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("P_IDFACTURA", IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FECHA_ENTREGA", FECHA_ENTREGA, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Function SP_L_VENTA_PAG_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_rep_general.SP_L_VENTA_PAG"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.VarChar)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RAZON_SOCIAL", OracleClient.OracleType.VarChar)).Value = RAZON_SOCIAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_PAGI", OracleClient.OracleType.VarChar)).Value = PAGI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFUNCIONARIO_ACTUAL", OracleClient.OracleType.VarChar)).Value = IDFUNCIONARIO_ACTUAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_VENTA_PAG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
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
    Public Function SP_L_VENTA_PAG() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("pkg_rep_general.SP_L_VENTA_PAG", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_RAZON_SOCIAL", OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_PAGI", OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_ini", OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idfuncionario_actual", OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idunidad_origen", OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idunidad_destino", OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idpersona", OracleClient.OracleType.Number)
            db.AsignarParametro("p_idtipo_comprobante", OracleClient.OracleType.Number)
            db.AsignarParametro("p_idforma_pago", OracleClient.OracleType.Number)
            db.AsignarParametro("p_idtipo_entrega", OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_L_VENTA_PAG", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuEmiContaPCE_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    'IDPERSONA, 2, _
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIIPCE", 28, _
    '    CType(IDPERSONA, String), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function SP_ConsulFactuEmiIIPCE_GERE_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    'IDPERSONA, 1, _ 
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiIIPCE_GERE", 28, _
    '    CType(IDPERSONA, String), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_ConsulFactuEmiIIPCE_GERE(ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dv As New DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmiIIPCE_GERE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", CStr(IDPERSONA), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_ENTRE", P_ENTRE, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi_conta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If
            '
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuEmiContav_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaV", 30, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    'Public Function SP_ConsulFactuEmiContaDescu_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaDescu", 30, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        '
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    '
    'End Function
    Public Function SP_ConsulFactuEmiContaDescu(ByVal P_ENTRE As Long) As DataView
        Try
            '
            Dim m As Long
            Dim a As Long = 0
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmiContaDescu", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_AGENCIA_VENTA", agencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idpersona", IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_entre", P_ENTRE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmiContaDescu", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dv = ldt_tmp.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If
            '
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_ConsulFactuEmiEntreManu_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.sp_ConsulFactuEmiEntreManu", 30, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    Public Function sp_ConsulFactuEmiEntreManu(ByVal P_ENTRE As Long) As DataView
        Try
            '
            Dim m As Long
            Dim a As Long = 0
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.sp_ConsulFactuEmiEntreManu", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_AGENCIA_VENTA", agencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idpersona", IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_entre", P_ENTRE, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmiContaDescu", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dv = ldt_tmp.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If
            '
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_Consul_GUIAS_RECEPCION_DOCU_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset

    '    Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.sp_Consul_GUIAS_RECEPCION_DOCU", 30, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    IDTIPO_RECEPCION_DOCU, 2}


    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_Consul_GUIAS_RECEPCION_DOCU(ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dv As New DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_Consul_GUIAS_RECEPCION_DOCU", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_AGENCIA_VENTA", agencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idpersona", CStr(IDPERSONA), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDTIPO_RECEPCION_DOCU", IDTIPO_RECEPCION_DOCU, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Consul_GUIAS_RECE_DOCU", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dv = ldt_tmp.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If
            '
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuDevoCargos_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuDevoCargos", 32, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1, _
    '    IDTIPO_RECEPCION_DOCU, 2}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    'Public Function SP_LIST_GUIAS_AUTO_GENE_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LIST_GUIAS_AUTO_GENE", 32, _
    '    IDPERSONA.ToString, 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    IDESTADO_ENVIO, 1, _
    '    NRO_GRUPO, 1, _
    '    SITU_IMPRESION, 2}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_LIST_GUIAS_AUTO_GENE() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_LIST_GUIAS_AUTO_GENE", CommandType.StoredProcedure)
            db.AsignarParametro("p_idpersona", IDPERSONA.ToString, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idestado_envio", IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_nro_grupo", NRO_GRUPO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_SITU_IMPRESION", SITU_IMPRESION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_LIST_GUIAS_AUTO_GENE", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LIST_GUIAS_IMPRE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_LIST_GUIAS_IMPRE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDGUIAS_ENVIO", OracleClient.OracleType.Number)).Value = IDGUIAS_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_GUIA", OracleClient.OracleType.VarChar)).Value = NRO_GUIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LIST_GUIAS_IMPRE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    Public Function SP_LIST_GUIAS_IMPRE() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_LIST_GUIAS_IMPRE", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NRO_GUIA", NRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LIST_GUIAS_IMPRE", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LIST_GUIAS_AUTO_GENE2_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    'IDPERSONA, 1, _
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LIST_GUIAS_AUTO_GENE2", 32, _
    '    CType(IDPERSONA, String), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    IDESTADO_ENVIO, 1, _
    '    NRO_GRUPO, 1, _
    '    SITU_IMPRESION, 2}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_LIST_GUIAS_AUTO_GENE2() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_LIST_GUIAS_AUTO_GENE2", CommandType.StoredProcedure)
            db.AsignarParametro("p_idpersona", CType(IDPERSONA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idestado_envio", IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_nro_grupo", NRO_GRUPO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_SITU_IMPRESION", SITU_IMPRESION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_LIST_GUIAS_AUTO_GENE", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub sp_confir_regis_pend_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.sp_confir_regis_pend"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDGUIAS_ENVIO", OracleClient.OracleType.Number)).Value = IDGUIAS_ENVIO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub sp_confir_regis_pend()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.sp_confir_regis_pend", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.Int32)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Function FN_ConsulFactuEmi_movi_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulFactuEmi_movi"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
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
    Public Function FN_ConsulFactuEmi_movi() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmi_movi", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    Public Function FN_ConsulFactuEmi_movi_2() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmi_movi_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function FN_CONSUL_GUIAS_EMI_DG_II_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataView

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG_II"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = idcentro_costo
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_CONSUL_GUIAS_EMI_DG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    Public Function FN_CONSUL_GUIAS_EMI_DG_II() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG_II", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", CStr(IDPERSONA), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDCENTRO_COSTO", idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_facturado", Facturado, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_CONSUL_GUIAS_EMI_DG", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuEmiContaVI_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaVI", 32, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1, _
    '    idcentro_costo, 1}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_list_deta_linea_credito_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataSet
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'cmd.CommandText = "PKG_IVOFACTURACION.sp_list_deta_linea_credito" 
    '    cmd.CommandText = "PKG_IVOFACTURACION.sp_list_deta_linea_credito_1"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_incial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idfuncionario", OracleClient.OracleType.Number)).Value = idfuncionarioNegocio
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idtipo_facturacion", OracleClient.OracleType.Number)).Value = IDTIPO_FACTURACION ' 30/03/2009 
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_guias", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_prefacturas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_facturas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_pagos", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_pendiente_pagos", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Return ds
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_list_deta_linea_credito() As DataSet
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 06-01-2014
            'db_bd.CrearComando("PKG_IVOFACTURACION.sp_list_deta_linea_credito_3", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOFACTURACION.sp_list_deta_linea_cre_3_car", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("p_fecha_incial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idfuncionario", idfuncionarioNegocio, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_idtipo_facturacion", IDTIPO_FACTURACION, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Number)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_guias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_prefacturas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_facturas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_pagos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_pendiente_pagos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Comentado 24/03/2009 
    'Public Function sp_list_deta_linea_credito(ByVal cnn As Data.OracleClient.OracleConnection) As DataSet
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.sp_list_deta_linea_credito"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_guias", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_prefacturas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_facturas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_pagos", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Return ds

    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    '
    'Public Function sp_busca_liente_fac_otro_2009(ByVal cnn As Data.OracleClient.OracleConnection, ByVal P_NU_DOCU_SUNA As String) As DataView
    '    Try
    '        Dim CMD As New System.Data.OracleClient.OracleCommand
    '        CMD.Connection = cnn
    '        CMD.CommandType = CommandType.StoredProcedure
    '        CMD.CommandText = "PKG_IVOFACTUACION_OTROS.sp_busca_liente_fac_otro"
    '        CMD.Parameters.Add(New OracleClient.OracleParameter("p_nu_docu_suna", OracleClient.OracleType.VarChar)).Value = P_NU_DOCU_SUNA
    '        CMD.Parameters.Add(New OracleClient.OracleParameter("cur_busca_cliente", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New OracleClient.OracleDataAdapter(CMD)

    '        Dim ds As New DataSet
    '        daora.Fill(ds)

    '        Return ds.Tables(0).DefaultView

    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    End Try
    'End Function
    Public Function sp_busca_liente_fac_otro(ByVal P_NU_DOCU_SUNA As String) As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTUACION_OTROS.sp_busca_liente_fac_otro", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_nu_docu_suna", P_NU_DOCU_SUNA, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_busca_cliente", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuDevoCargosII_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuDevoCargosIV", 32, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1, _
    '    IDTIPO_RECEPCION_DOCU, 2}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Sub sp_anula_refactura_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandText = "PKG_IVOREFACTURACION.sp_anula_refactura"
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idfactura", OracleClient.OracleType.Number)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_comprobante", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_es_refactura", OracleClient.OracleType.Number)).Value = es_refactura
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_FACTURA", OracleClient.OracleType.Number)).Value = IDESTADO_FACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_msg", OracleClient.OracleType.VarChar, 1000)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        MsgBox(cmd.Parameters("p_msg").Value, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub sp_anula_refactura()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOREFACTURACION.sp_anula_refactura", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idfactura", IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_es_refactura", es_refactura, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("P_IDESTADO_FACTURA", IDESTADO_FACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_motivo", Motivo, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("p_msg", 1000, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                mensaje = db_bd.Parametros(1).ToString
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Sub SP_INSUPD_DOCUMENTOS_FACBOL_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New OracleClient.OracleCommand
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Connection = cnn
    '        cmd.CommandText = "PKG_IVOCARGA.SP_INSUPD_DOCU_FACBOLIII"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iControl", OracleClient.OracleType.Number)).Value = 1
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("xiIdguias_Envio", OracleClient.OracleType.NVarChar)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iNro_Serie", OracleClient.OracleType.NVarChar)).Value = SERIE_FACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iNro_Docu", OracleClient.OracleType.NVarChar)).Value = NRO_FACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iidrol_usuario", OracleClient.OracleType.Number)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iidusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIP", OracleClient.OracleType.NVarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("iIdtipo_Comprobante", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        '
    '        cmd.ExecuteNonQuery()
    '    Catch OEx As OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    '
    'Public Function FN_ConsulFactuEmi_movi_Nota_credi_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulFactuEmi_movi_nc"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    Public Function FN_ConsulFactuEmi_movi_Nota_credi() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmi_movi_nc", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuDevoCargosVII_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuDevoCargosVII", 36, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1, _
    '    IDTIPO_RECEPCION_DOCU, 2, _
    '    NRO_LIQUI_DEVO_CARGO.ToString, 2, _
    '    Idtipo_recep_docuS, 2}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function fn_UPDATE_SELEC_TO_DEVO_2009(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        'cmd.CommandText = "PKG_IVOFACTURACION.SP_UPDATE_SELEC_TO_DEVO"
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_UPDATE_SELEC_TO_DEVO1"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idguias_envio", OracleClient.OracleType.Number)).Value = IDGUIAS_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_SELECCIONAR_TO_DEVO", OracleClient.OracleType.Number)).Value = SELECCIONAR_TO_FACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_SELECCIONA", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    Public Sub fn_UPDATE_SELEC_TO_DEVO()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_UPDATE_SELEC_TO_DEVO1", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Number)
            db.AsignarParametro("P_SELECCIONAR_TO_DEVO", SELECCIONAR_TO_FACTURA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUSUARIO_SELECCIONA", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Function SP_ConsulFactuEmiContaX_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    '
    '    Try
    '        '
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        'cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulFactuEmiContaXI"  ' 28/10/2008 - Modificado 
    '        'hlamas 07/11/2008
    '        'cmd.CommandText = "SP_ConsulFactuEmiContaXI"  ' 28/10/2008 - Modificado 
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_ConsulFactuEmiContaX"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_AGENCIA_VENTA", OracleClient.OracleType.Number)).Value = agencia_venta
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idpersona", OracleClient.OracleType.VarChar)).Value = IDPERSONA.ToString
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_moneda", OracleClient.OracleType.Number)).Value = IDTIPO_MONEDA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_inicial", OracleClient.OracleType.VarChar)).Value = FECHA_INICIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_fecha_final", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_factura", OracleClient.OracleType.VarChar)).Value = NRO_FACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idUNIDAD_ORIGEN", OracleClient.OracleType.Number)).Value = IDUNIDAD_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idUNIDAD_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idtipo_comprobante", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_entre", OracleClient.OracleType.Number)).Value = P_ENTRE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDCENTRO_COSTO", OracleClient.OracleType.Number)).Value = idcentro_costo
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_es_carga_asegurada", OracleClient.OracleType.Number)).Value = ES_CARGA_ASEGURADA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_ConsulFactuEmi_conta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Return ds.Tables(0).DefaultView
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_ConsulFactuEmiContaX(ByVal P_ENTRE As Long) As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            'db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmiContaX", CommandType.StoredProcedure)
            'Mod. 10/08/2010 
            '
            'db_bd.CrearComando("SP_ConsulFactuEmiConta_XI", CommandType.StoredProcedure)
            'db_bd.CrearComando("SP_ConsulFactuEmiConta_XII", CommandType.StoredProcedure)
            'db_bd.CrearComando("SP_ConsulFactuEmiConta_XIII", CommandType.StoredProcedure)
            db_bd.CrearComando("SP_ConsulFactuEmiConta_XIV", CommandType.StoredProcedure)
            'PKG_IVOFACTURACION.
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input

            db_bd.AsignarParametro("p_AGENCIA_VENTA", agencia_venta, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_idpersona", IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_entre", P_ENTRE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_IDCENTRO_COSTO", idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_es_carga_asegurada", ES_CARGA_ASEGURADA, OracleClient.OracleType.Int32)
            '13/08/2010 
            db_bd.AsignarParametro("ni_carga_acompanada", carga_acompanada, OracleClient.OracleType.Int32)
            '10-10-2017
            db_bd.AsignarParametro("vi_numero_documento", NumeroDocumento, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_razon_social", RazonSocial, OracleClient.OracleType.VarChar)
            'hlamas 08-09-2016
            db_bd.AsignarParametro("ni_usuario", Usuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_ip", IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi_conta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function
    'Public Function sp_listar_solicitu_credi_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    'Dim DT As New DataTable
    'Dim Rst As New ADODB.Recordset
    'Dim dv As New DataView
    'Dim DA As New OleDb.OleDbDataAdapter
    'Dim m As LONG
    '
    'Dim a As LONG = 0
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA", 62, _
    '    1, 1, _
    '    IDFORMA_PAGO, 1, _
    '    IDESTADO_ENVIO, 1, _
    '    IDESTADO_FACTURA, 1, _
    '    IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), 1, _
    '    CANTIDAD, 3, _
    '    TOTAL_PESO, 3, _
    '    TOTAL_VOLUMEN, 3, _
    '    IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), 1, _
    '    IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), 1, _
    '    IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), 1, _
    '    IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), 1, _
    '    IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), 1, _
    '    IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), 1, _
    '    MONTO_TIPO_CAMBIO, 3, _
    '    IDTIPO_MONEDA, 1, _
    '    FECHA, 2, _
    '    FECHA_VENCIMIENTO, 2, _
    '    IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), 1, _
    '    IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), 1, _
    '    Str(IDPERSONA), 2, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    MONTO_IMPUESTO, 3, _
    '    TOTAL_COSTO, 3, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    IP, 2, _
    '    IDROL_USUARIO, 1, _
    '    CANTIDAD_X_UNIDAD_ARTI, 3, _
    '    CANTIDAD_X_UNIDAD_VOLUMEN, 3 _
    '    }

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(DT, Rst)
    '    dv = DT.DefaultView

    '    If Not dv.Count = 0 Then
    '        If Not dv.Table.Rows(0).IsNull(0) Then
    '            If dv.Table.Rows(0)(0) = -666 Then
    '                m = 1 / a
    '            End If
    '        End If
    '    End If

    '    IDFACTURA = dv.Table.Rows(0)(0)

    'Catch ex As System.Exception
    '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    'End Try
    '
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivocuenta_corriente.sp_listar_solicitu_credi"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idusuario_personal", OracleClient.OracleType.Int16)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_facturacion", OracleClient.OracleType.Double)).Value = IDTIPO_FACTURACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_listar_solicitu_credi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Return ds.Tables(0).DefaultView
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_listar_solicitu_credi() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivocuenta_corriente.sp_listar_solicitu_credi", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_facturacion", IDTIPO_FACTURACION, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_listar_solicitu_credi", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_ConsulFactuDevoCargos8_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuDevoCargos8", 38, _
    '    agencia_venta, 1, _
    '    CStr(IDPERSONA), 2, _
    '    IDFORMA_PAGO, 1, _
    '    IDTIPO_MONEDA, 1, _
    '    IDAGENCIAS, 1, _
    '    IDUSUARIO_PERSONAL, 1, _
    '    FECHA_INICIO, 2, _
    '    FECHA_FINAL, 2, _
    '    NRO_FACTURA, 2, _
    '    IDUNIDAD_ORIGEN, 1, _
    '    IDUNIDAD_DESTINO, 1, _
    '    IDTIPO_COMPROBANTE, 1, _
    '    IDTIPO_ENTREGA, 1, _
    '    P_ENTRE, 1, _
    '    IDTIPO_RECEPCION_DOCU, 2, _
    '    NRO_LIQUI_DEVO_CARGO.ToString, 2, _
    '    Idtipo_recep_docuS, 2, _
    '    idusuario_seleccion, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_ConsulFactuDevoCargos8(ByVal P_ENTRE As Long) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuDevoCargos8", CommandType.StoredProcedure)
            db.AsignarParametro("p_AGENCIA_VENTA", agencia_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idpersona", CStr(IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_entre", P_ENTRE, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_IDTIPO_RECEPCION_DOCU", IDTIPO_RECEPCION_DOCU, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_NRO_LIQUI_DEVO_CARGO", NRO_LIQUI_DEVO_CARGO.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_Idtipo_recep_docuS", Idtipo_recep_docuS, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idusuario_seleccion", idusuario_seleccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("curr_ConsulFactuDevoCargos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    '29/10/2008
    'Public Function sp_cargar_direccion_cliente_2009(ByVal cnn As Data.OracleClient.OracleConnection, ByVal codigo As Integer) As DataView
    '    Try
    '        Dim CMD As New System.Data.OracleClient.OracleCommand
    '        CMD.Connection = cnn
    '        CMD.CommandType = CommandType.StoredProcedure
    '        CMD.CommandText = "sp_cargar_direccion_cliente"
    '        CMD.Parameters.Add(New OracleClient.OracleParameter("codigo", OracleClient.OracleType.Int32)).Value = codigo
    '        CMD.Parameters.Add(New OracleClient.OracleParameter("cur_direccion", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New OracleClient.OracleDataAdapter(CMD)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Return ds.Tables(0).DefaultView
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    End Try
    'End Function
    Public Function sp_cargar_direccion_cliente(ByVal codigo As Integer) As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("sp_cargar_direccion_cliente", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("codigo", codigo, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_direccion", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Adicioando 
    'Public Function sp_get_detalle_cuenta_corriente_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataSet
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    '
    '    cmd.CommandText = "PKG_IVOFACTURACION.sp_get_detalle_cta_corriente"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_seleccion", OracleClient.OracleType.Number)).Value = idseleccion
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_det_cta_corriente", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Return ds
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_get_detalle_cuenta_corriente() As DataSet
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            'db_bd.CrearComando("PKG_IVOFACTURACION.sp_get_detalle_cta_corriente", CommandType.StoredProcedure)
            '08-11-2010
            db_bd.CrearComando("PKG_IVOFACTURACION.sp_get_detalle_cta_corriente_3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("ni_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_seleccion", idseleccion, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_det_cta_corriente", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_get_cuenta_corriente_x_Fecha_vencimiento_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataSet
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOFACTURACION.sp_get_cta_corriente_x_vcto"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idfuncionario", OracleClient.OracleType.Number)).Value = idfuncionarioNegocio
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idtipo_facturacion", OracleClient.OracleType.Double)).Value = IDTIPO_FACTURACION
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_seleccion", OracleClient.OracleType.Double)).Value = idseleccion
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_pendiente_pago", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Return ds
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function sp_get_cuenta_corriente_x_Fecha_vencimiento() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.sp_get_cta_corriente_x_vcto_11", CommandType.StoredProcedure)
            db.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idfuncionario", idfuncionarioNegocio, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idtipo_facturacion", IDTIPO_FACTURACION, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_seleccion", idseleccion, OracleClient.OracleType.Double)
            db.AsignarParametro("ocur_pendiente_pago", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_get_linea_credito_resumen_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataSet
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOFACTURACION.sp_get_resumen_linea_credito"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_resumen", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Return ds
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_get_linea_credito_resumen() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.sp_get_resumen_linea_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", IDPERSONA, OracleClient.OracleType.Number)
            db.AsignarParametro("ocur_resumen", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function FNPREFACTURAS_GUIAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_PREFACTURAS_GUIAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPREFACTURA", CType(IDPREFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_PREFACTURAS_GUIAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)

            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            Dim dv As DataView = ds.Tables(0).DefaultView
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FNFACTURAS_GUIAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        'IDFACTURA, 1
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_FACTURAS_GUIAS", 4, _
    '        CType(IDFACTURA, String), 2 _
    '       }

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
    Public Function FNFACTURAS_GUIAS() As DataView
        Try
            Dim dv As New DataView
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_FACTURAS_GUIAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", CType(IDFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_FACTURAS_GUIAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim dt As DataTable = ds.Tables(0)
            dv = dt.DefaultView
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_LISTAR_PREFACTURAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_PREFACTURAS_", 12, Str(IDPERSONA), 2, IDTIPO_MONEDA, 1, FECHA_INICIO, 2, FECHA_FINAL, 2, _
    '        FACTURADO, 1}
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

    Public Function FN_LISTAR_PREFACTURAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_LISTAR_PREFACTURAS_", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", Str(IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_MONEDA", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FACTURADO", FACTURADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LISTAR_GUIAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds.Tables(0).DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fn_INUPDE_FACTURA_FROM_PREFAC__2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fn_INUPDE_FACTURA_FROM_PREFAC_ = True

    '    Dim DT As New DataTable
    '    Dim Rst As New ADODB.Recordset
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Long

    '    Dim a As Long = 0
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA_FROM_PREFAC_", 62, _
    '        1, 1, _
    '        IDFORMA_PAGO, 1, _
    '        IDESTADO_ENVIO, 1, _
    '        IDESTADO_FACTURA, 1, _
    '        IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), 1, _
    '        CANTIDAD, 3, _
    '        TOTAL_PESO, 3, _
    '        TOTAL_VOLUMEN, 3, _
    '        IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), 1, _
    '        IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), 1, _
    '        IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), 1, _
    '        IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), 1, _
    '        IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), 1, _
    '        IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), 1, _
    '        MONTO_TIPO_CAMBIO, 3, _
    '        IDTIPO_MONEDA, 1, _
    '        FECHA, 2, _
    '        FECHA_VENCIMIENTO, 2, _
    '        IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), 1, _
    '        IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), 1, _
    '        Str(IDPERSONA), 2, _
    '        IDTIPO_COMPROBANTE, 1, _
    '        MONTO_IMPUESTO, 3, _
    '        TOTAL_COSTO, 3, _
    '        IDAGENCIAS, 1, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IP, 2, _
    '        IDROL_USUARIO, 1, _
    '        CANTIDAD_X_UNIDAD_ARTI, 3, _
    '        CANTIDAD_X_UNIDAD_VOLUMEN, 3 _
    '        }
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView

    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If dv.Table.Rows(0)(0) = -666 Then
    '                    IDFACTURA = dv.Table.Rows(0)(0)
    '                    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '                    Return False
    '                End If
    '            End If
    '        End If

    '        IDFACTURA = dv.Table.Rows(0)(0)
    '        Return True
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function

    Public Function fn_INUPDE_FACTURA_FROM_PREFAC_() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_INUPDE_FACTURA_FROM_PREFAC_", CommandType.StoredProcedure)
            db.AsignarParametro("OPE", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDFORMA_PAGO", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_ENVIO", IDESTADO_ENVIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_FACTURA", IDESTADO_FACTURA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCIUDAD_TRANSITO", IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CANTIDAD", CANTIDAD, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_PESO", TOTAL_PESO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_VOLUMEN", TOTAL_VOLUMEN, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDGUIA_TRANSPORTISTA", IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDGUIA_TRANSPORTISTA_UPD", IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUNIDAD_ORIGEN", IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUNIDAD_DESTINO", IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDDIREECION_ORIGEN", IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDDIREECION_DESTINO", IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_MONTO_TIPO_CAMBIO", MONTO_TIPO_CAMBIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDTIPO_MONEDA", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA", FECHA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_VENCIMIENTO", FECHA_VENCIMIENTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDPERSONA_ORIGEN", IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA_DESTINO", IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", Str(IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_MONTO_IMPUESTO", MONTO_IMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_COSTO", TOTAL_COSTO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CANTIDAD_X_UNIDAD_ARTI", CANTIDAD_X_UNIDAD_ARTI, OracleClient.OracleType.Number)
            db.AsignarParametro("P_CANTIDAD_X_UNIDAD_VOLUMEN", CANTIDAD_X_UNIDAD_VOLUMEN, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_version_2", 1, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_tipo_afectacion", TipoAfectacion, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_IDFACTURA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim DT As New DataTable
            Dim dv As New DataView
            DT = db.EjecutarDataSet.Tables(0)
            dv = DT.DefaultView

            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If dv.Table.Rows(0)(0) = -666 Then
                        IDFACTURA = dv.Table.Rows(0)(0)
                        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
                        Return False
                    End If
                End If
            End If

            IDFACTURA = dv.Table.Rows(0)(0)
            Return True

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        'fn_INUPDE_FACTURA_FROM_PREFAC_ = True

        'Dim DT As New DataTable
        'Dim Rst As New ADODB.Recordset
        'Dim dv As New DataView
        'Dim DA As New OleDb.OleDbDataAdapter
        'Dim m As Long

        'Dim a As Long = 0
        'Try
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA_FROM_PREFAC_", 62, _
        '    1, 1, _
        '    IDFORMA_PAGO, 1, _
        '    IDESTADO_ENVIO, 1, _
        '    IDESTADO_FACTURA, 1, _
        '    IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), 1, _
        '    CANTIDAD, 3, _
        '    TOTAL_PESO, 3, _
        '    TOTAL_VOLUMEN, 3, _
        '    IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), 1, _
        '    IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), 1, _
        '    IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), 1, _
        '    IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), 1, _
        '    IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), 1, _
        '    IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), 1, _
        '    MONTO_TIPO_CAMBIO, 3, _
        '    IDTIPO_MONEDA, 1, _
        '    FECHA, 2, _
        '    FECHA_VENCIMIENTO, 2, _
        '    IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), 1, _
        '    IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), 1, _
        '    Str(IDPERSONA), 2, _
        '    IDTIPO_COMPROBANTE, 1, _
        '    MONTO_IMPUESTO, 3, _
        '    TOTAL_COSTO, 3, _
        '    IDAGENCIAS, 1, _
        '    IDUSUARIO_PERSONAL, 1, _
        '    IP, 2, _
        '    IDROL_USUARIO, 1, _
        '    CANTIDAD_X_UNIDAD_ARTI, 3, _
        '    CANTIDAD_X_UNIDAD_VOLUMEN, 3 _
        '    }
        '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        '    DA.Fill(DT, Rst)
        '    dv = DT.DefaultView

        '    If Not dv.Count = 0 Then
        '        If Not dv.Table.Rows(0).IsNull(0) Then
        '            If dv.Table.Rows(0)(0) = -666 Then
        '                IDFACTURA = dv.Table.Rows(0)(0)
        '                MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
        '                Return False
        '            End If
        '        End If
        '    End If

        '    IDFACTURA = dv.Table.Rows(0)(0)
        '    Return True
        'Catch ex As System.Exception
        '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try

    End Function
    'Public Function FN_L_FACTURAS_FROM_PREFACTU_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_L_FACTURAS_FROM_PREFACTU_", 10, _
    '        1, 1, _
    '        Str(IDPERSONA), 2, _
    '        FECHA_INICIO, 2, _
    '        FECHA_FINAL, 2 _
    '        }
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
    Public Function FN_L_FACTURAS_FROM_PREFACTU_() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_L_FACTURAS_FROM_PREFACTU_", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPE", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", Str(IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_L_FACTURAS_FROM_PREFACTU", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataSet.Tables(0)
            Dim dv As DataView = dt.DefaultView
            Return dv

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Try
        '    Dim dv As New DataView
        '    Dim Rst As New ADODB.Recordset
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_L_FACTURAS_FROM_PREFACTU_", 10, _
        '    1, 1, _
        '    Str(IDPERSONA), 2, _
        '    FECHA_INICIO, 2, _
        '    FECHA_FINAL, 2 _
        '    }

        '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        '    Dim DA As New OleDb.OleDbDataAdapter
        '    Dim DT As New DataTable
        '    DA.Fill(DT, Rst)
        '    dv = DT.DefaultView

        '    Return dv
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try
    End Function

    'Public Function FNFACTURAS_PREFACTURAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        'IDFACTURA, 1 _ Id. factura
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_FACTURAS_PREFACTURAS", 4, _
    '        CType(IDFACTURA, String), 2 _
    '       }
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView
    '        Return dv
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FNFACTURAS_PREFACTURAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_FACTURAS_PREFACTURAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", CType(IDFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_FACTURAS_PREFACTURAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet.Tables(0).DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FNANU_FACTURAS_PREFACTURAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        'IDFACTURA, 1,_  Se cambio este procedimiento  
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ANU_FACTURAS_PREFACTURAS", 10, _
    '    CType(IDFACTURA, String), 2, _
    '    IPMOD, 2, _
    '    IDUSUARIO_PERSONALMOD, 1, _
    '    IDROL_USUARIOMOD, 1}
    '        '
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView
    '        '
    '        Return dv
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FNANU_FACTURAS_PREFACTURAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_ANU_FACTURAS_PREFACTURAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", CType(IDFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FNELI_FACTURAS_PREFACTURAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        'IDFACTURA,2, 
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ELI_FACTURAS_PREFACTURAS", 10, _
    '    CType(IDFACTURA, String), 2, _
    '    IPMOD, 2, _
    '    IDUSUARIO_PERSONALMOD, 1, _
    '    IDROL_USUARIOMOD, 1}
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
    Public Function FNELI_FACTURAS_PREFACTURAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_ELI_FACTURAS_PREFACTURAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", CType(IDFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_UPDATE_SELEC_TO_FACTURA_2009(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_UPDATE_SELEC_TO_FACTURA"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idguias_envio", OracleClient.OracleType.Number)).Value = IDGUIAS_ENVIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_seleccionar_to_factura", OracleClient.OracleType.Number)).Value = SELECCIONAR_TO_FACTURA
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        'dv = ds.Tables(0).DefaultView
    '        'Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function fn_UPDATE_SELEC_TO_FACTURA()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_UPDATE_SELEC_TO_FACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_SELECCIONAR_TO_FACTURA", SELECCIONAR_TO_FACTURA, OracleClient.OracleType.Number)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Public Function FNINUPDE_FACTURA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_INUPDE_FACTURA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OPE", OracleClient.OracleType.Int16)).Value = 1
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFORMA_PAGO", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_FACTURA", OracleClient.OracleType.Number)).Value = (IDESTADO_FACTURA)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCIUDAD_TRANSITO", OracleClient.OracleType.Number)).Value = IDCIUDAD_TRANSITO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CANTIDAD", OracleClient.OracleType.Number)).Value = (CANTIDAD)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_PESO", OracleClient.OracleType.Double)).Value = (TOTAL_PESO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_VOLUMEN", OracleClient.OracleType.Double)).Value = (TOTAL_VOLUMEN)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDGUIA_TRANSPORTISTA", OracleClient.OracleType.Number)).Value = IDGUIA_TRANSPORTISTA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDGUIA_TRANSPORTISTA_UPD", OracleClient.OracleType.Number)).Value = IDGUIA_TRANSPORTISTA_UPD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.Number)).Value = IDUNIDAD_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.Number)).Value = IDUNIDAD_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIREECION_ORIGEN", OracleClient.OracleType.Number)).Value = IDDIREECION_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDDIREECION_DESTINO", OracleClient.OracleType.Number)).Value = IDDIREECION_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_TIPO_CAMBIO", OracleClient.OracleType.Double)).Value = (MONTO_TIPO_CAMBIO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_MONEDA", OracleClient.OracleType.Number)).Value = (IDTIPO_MONEDA)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA", OracleClient.OracleType.NVarChar)).Value = (FECHA)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_VENCIMIENTO", OracleClient.OracleType.NVarChar)).Value = (FECHA_VENCIMIENTO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA_ORIGEN", OracleClient.OracleType.Number)).Value = IDPERSONA_ORIGEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA_DESTINO", OracleClient.OracleType.Number)).Value = IDPERSONA_DESTINO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.NVarChar)).Value = (Str(IDPERSONA))
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = (IDTIPO_COMPROBANTE)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_IMPUESTO", OracleClient.OracleType.Double)).Value = (MONTO_IMPUESTO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_TOTAL_COSTO", OracleClient.OracleType.Double)).Value = (TOTAL_COSTO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = (IDAGENCIAS)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = (IDUSUARIO_PERSONAL)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.NVarChar)).Value = (IP)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = (IDROL_USUARIO)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CANTIDAD_X_UNIDAD_ARTI", OracleClient.OracleType.Double)).Value = (CANTIDAD_X_UNIDAD_ARTI)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CANTIDAD_X_UNIDAD_VOLUMEN", OracleClient.OracleType.Double)).Value = (CANTIDAD_X_UNIDAD_VOLUMEN)

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_IDFACTURA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_ERR", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        Dim ds As New DataSet
    '        daora.Fill(ds)


    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView

    '        IDFACTURA = dv.Table.Rows(0)(0)

    '        If IDFACTURA = -666 Then
    '            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '            Return (False)
    '        Else
    '            Return (True)
    '        End If

    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    Public Function FNINUPDE_FACTURA() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_INUPDE_FACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("OPE", 1, OracleClient.OracleType.Int16)
            db.AsignarParametro("P_IDFORMA_PAGO", IDFORMA_PAGO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDESTADO_ENVIO", IDESTADO_ENVIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDESTADO_FACTURA", IDESTADO_FACTURA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDCIUDAD_TRANSITO", IDCIUDAD_TRANSITO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_CANTIDAD", (CANTIDAD), OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_PESO", (TOTAL_PESO), OracleClient.OracleType.Double)
            db.AsignarParametro("P_TOTAL_VOLUMEN", (TOTAL_VOLUMEN), OracleClient.OracleType.Double)
            db.AsignarParametro("P_IDGUIA_TRANSPORTISTA", IDGUIA_TRANSPORTISTA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDGUIA_TRANSPORTISTA_UPD", IDGUIA_TRANSPORTISTA_UPD, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDDIREECION_ORIGEN", IDDIREECION_ORIGEN, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDDIREECION_DESTINO", IDDIREECION_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_MONTO_TIPO_CAMBIO", (MONTO_TIPO_CAMBIO), OracleClient.OracleType.Double)
            db.AsignarParametro("P_IDTIPO_MONEDA", (IDTIPO_MONEDA), OracleClient.OracleType.Number)
            db.AsignarParametro("P_FECHA", (FECHA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_VENCIMIENTO", (FECHA_VENCIMIENTO), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDPERSONA_ORIGEN", IDPERSONA_ORIGEN, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDPERSONA_DESTINO", IDPERSONA_DESTINO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDPERSONA", (Str(IDPERSONA)), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", (IDTIPO_COMPROBANTE), OracleClient.OracleType.Number)
            db.AsignarParametro("P_MONTO_IMPUESTO", (MONTO_IMPUESTO), OracleClient.OracleType.Double)
            db.AsignarParametro("P_TOTAL_COSTO", (TOTAL_COSTO), OracleClient.OracleType.Double)
            db.AsignarParametro("P_IDAGENCIAS", (IDAGENCIAS), OracleClient.OracleType.Number)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", (IDUSUARIO_PERSONAL), OracleClient.OracleType.Number)
            db.AsignarParametro("P_IP", (IP), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDROL_USUARIO", (IDROL_USUARIO), OracleClient.OracleType.Number)
            db.AsignarParametro("P_CANTIDAD_X_UNIDAD_ARTI", (CANTIDAD_X_UNIDAD_ARTI), OracleClient.OracleType.Double)
            db.AsignarParametro("P_CANTIDAD_X_UNIDAD_VOLUMEN", (CANTIDAD_X_UNIDAD_VOLUMEN), OracleClient.OracleType.Double)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version_2", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_afectacion", TipoAfectacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_IDFACTURA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dv As DataView = db.EjecutarDataSet.Tables(0).DefaultView
            IDFACTURA = dv.Table.Rows(0)(0)
            If IDFACTURA = -666 Then
                Throw New Exception(dv.Table.Rows(0)(2))
                'MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
                'Return (False)
            Else
                Return True
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function FNANU_FACTURAS_GUIAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_ANU_FACTURAS_GUIAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", CType(IDFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_motivo", Motivo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        End Try
    End Function
    'Public Function FNQUITAR_FACTURAS_GUIAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        ' se cambia el codigo (IDGUIAS_ENVIO, 1 ) 
    '        ' Se cambia el codigo (IDFACTURA, 1 ) 
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_QUITAR_FACTURAS_GUIAS", 14, _
    '        OPE, 1, _
    '        CType(IDGUIAS_ENVIO, String), 2, _
    '        CType(IDFACTURA, String), 2, _
    '        IPMOD, 2, _
    '        IDUSUARIO_PERSONALMOD, 1, _
    '        IDROL_USUARIOMOD, 1}
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

    Public Function FNQUITAR_FACTURAS_GUIAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_QUITAR_FACTURAS_GUIAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPE", OPE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDGUIAS_ENVIO", CType(IDGUIAS_ENVIO, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDFACTURA", CType(IDFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FNELI_FACTURAS_GUIAS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        'IDFACTURA, 1, _
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ELI_FACTURAS_GUIAS", 10, _
    '    CType(IDFACTURA, String), 2, _
    '    IPMOD, 2, _
    '    IDUSUARIO_PERSONALMOD, 1, _
    '    IDROL_USUARIOMOD, 1}

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
    Public Function FNELI_FACTURAS_GUIAS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_ELI_FACTURAS_GUIAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", CType(IDFACTURA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    '    Public Function FN_L_FACTURAS_SIN_CARGOS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        Dim A As Long = 0
    '        Dim M As Long
    '        Try
    '            Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_L_FACTURAS_SIN_CARGOS", 10, _
    '            IDPERSONA.ToString, 2, _
    'FECHA_INICIO, 2, _
    'FECHA_FINAL, 2, _
    'CARGO, 1}
    '            Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '            DA.Fill(DT, Rst)
    '            dv = DT.DefaultView
    '            '
    '            If Not dv.Count = 0 Then
    '                If Not dv.Table.Rows(0).IsNull(0) Then
    '                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                        M = 1 / A
    '                    End If
    '                End If
    '            End If
    '            Return dv
    '        Catch ex As Exception
    '            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End Try
    '    End Function
    Public Function FN_L_FACTURAS_SIN_CARGOS() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_L_FACTURAS_SIN_CARGOS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CARGO", CARGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_L_FACTURAS_SIN_CARGOS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet.Tables(0).DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_CARGO_FACTU_DEVO_FECHA_VENCI_2009(ByVal VOCONTROLUSUARIO As Object) As String
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CARGO_FACTU_DEVO_FV", 10, _
    '        IDFACTURA.ToString, 2, _
    '        CARGO, 1, _
    '        IDPERSONA.ToString, 2, _
    '        FECHA_CARGO, 2}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView
    '        If dv.Table.Rows(0).IsNull(1) Then
    '            Return ""
    '        Else
    '            Return dv.Table.Rows(0)(1)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_CARGO_FACTU_DEVO_FECHA_VENCI() As String
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_CARGO_FACTU_DEVO_FV", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", IDFACTURA.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CARGO", CARGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_CARGO", FECHA_CARGO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dv As DataView = db.EjecutarDataTable.DefaultView
            If dv.Table.Rows(0).IsNull(1) Then
                Return ""
            Else
                Return dv.Table.Rows(0)(1)
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function impri_factu_otro(ByVal idfactura_otro As Long) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_impri_factu_otro", CommandType.StoredProcedure)
            db.AsignarParametro("p_idfactura_otro", idfactura_otro, OracleClient.OracleType.Number)
            db.AsignarParametro("cur_impri_factu_otro", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function impri_factu_otro2(ByVal idfactura_otro As Long) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_impri_factu_otro", CommandType.StoredProcedure)
            db.AsignarParametro("p_idfactura_otro", idfactura_otro, OracleClient.OracleType.Number)
            db.AsignarParametro("cur_impri_factu_otro", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function Facturacion(ByVal id As Long) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_IMPRI_GUIA_FACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDFACTURA", id, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_IMPRI_GUIA_FACTURA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function PeriodoFacturacion(ByVal id As Long) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.sp_periodo_facturacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_factura", id, OracleClient.OracleType.Number)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    ''' <summary>
    ''' Actualiza el estado del documento, ha emitido electronicamente
    ''' </summary>
    ''' <param name="id">Identificador de la Entidad</param>
    ''' <param name="nameTable">Nombre de la tabla en donde debe impactar la actualizacion</param>
    Public Sub actualizarEmisonFE(id As Long, nameTable As String)
        Try
            Dim campoId As String = ""
            If (nameTable.ToUpper.Equals("T_FACTURA_OTRO")) Then
                campoId = "idfactura_otro"
            ElseIf (nameTable.ToUpper.Equals("T_FACTURA")) Then
                campoId = "idfactura"
            ElseIf (nameTable.ToUpper.Equals("T_FACTURA_CONTADO")) Then
                campoId = "idfactura"
            ElseIf (nameTable.ToUpper.Equals("T_VENTA_PASAJES")) Then
                campoId = "idventa_pasajes"
            End If
            Dim sql = "UPDATE " + nameTable + " SET N_EMIFE=1, D_FECEMIFE=SYSDATE WHERE " & campoId & "=" & id
            Dim db As New BaseDatos
            db.Conectar()
            Dim result As Integer = db.EjecutarComando(sql, CommandType.Text)
            db.Desconectar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Sub ActualizarGlosa(factura As Integer, glosa As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.sp_actualizar_glosa", CommandType.StoredProcedure)
            db.AsignarParametro("ni_factura", factura, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_glosa", glosa, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Public Function SP_ConsulFactuEmiContaPCE(ByVal P_ENTRE As Long, ByVal opcion As Integer, ByVal inicio As String, ByVal fin As String) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 13-08-2010
            'db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIIPCE", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIIPCE_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("p_idpersona", CStr(IDPERSONA), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idforma_pago", IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_moneda", IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inicial", FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_factura", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_idUNIDAD_ORIGEN", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idUNIDAD_DESTINO", IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idtipo_entrega", IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idprocesos", IDPROCESOS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_facturado", FACTURADO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_ENTRE", P_ENTRE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_opcion", opcion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_inicio", inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fin", fin, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_ConsulFactuEmi_conta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If
            '
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
