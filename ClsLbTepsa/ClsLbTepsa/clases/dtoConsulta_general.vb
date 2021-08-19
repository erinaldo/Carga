'Option Explicit On
Imports AccesoDatos
'Imports Systsem
'Imports System.Runtime.Serialization
'<Serializable()> _
Public Class dtoConsulta_general
#Region "VARIABLES"
    Dim Myagencia_venta As Integer
    Dim MyPAGI As Char
    Dim MyRAZON_SOCIAL As String
    Dim MyIDAGENCIAS_DESTINO As Long
    Dim MyFECHA_ENTREGA As String
    Dim Myidtipo_entrega As Long
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
    Dim mytipo_consulta As Long
    '13/08/2010 
    Dim mycarga_acompanada As Long

#End Region
#Region "ATRIBUTOS"
    Public Property tipo_consulta() As Long
        Get
            tipo_consulta = mytipo_consulta
        End Get
        Set(ByVal value As Long)
            mytipo_consulta = value
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
    Public Property carga_acompanada() As Long
        Get
            IDROL_USUARIO = mycarga_acompanada
        End Get
        Set(ByVal value As Long)
            mycarga_acompanada = value
        End Set
    End Property
#End Region
    'Public Function sp_ConsulFactuEmiEntreManu_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_Consulta_General_1", 34, _
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
    '    tipo_consulta, 1, _
    '    MyIDAGENCIAS_DESTINO, 1}
    '    '
    '    '14/04/2008 
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    '
    '    DA.Fill(dT, Rst)
    '    '
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
    '        '
    '        Return dv
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_ConsulFactuEmiEntreManu(ByVal P_ENTRE As Long) As DataView
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
            '13/08/2010 
            'db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_Consulta_General_1", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_Consulta_General_2", CommandType.StoredProcedure)
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
            db_bd.AsignarParametro("p_entre", P_ENTRE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_tipo_consulta", tipo_consulta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idagencia_destino", MyIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_carga_acompanada", mycarga_acompanada, OracleClient.OracleType.Int32)
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

End Class
