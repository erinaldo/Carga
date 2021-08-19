Imports AccesoDatos
Public Class dtoconsulta_giro

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

#End Region
#Region "ATRIBUTOS"

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


#End Region
#Region "METODOS"
    'Public Function FNINUPDE_FACTURA(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean

    '    FNINUPDE_FACTURA = True

    'Dim DT As New DataTable
    'Dim Rst As New ADODB.Recordset
    'Dim dv As New DataView
    'Dim DA As New OleDb.OleDbDataAdapter
    'Dim m As LONG

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
    'Public Function fn_INUPDE_FACTURA_FROM_PREFACT(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fn_INUPDE_FACTURA_FROM_PREFACT = True

    '    Dim DT As New DataTable
    '    Dim Rst As New ADODB.Recordset
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Long

    '    Dim a As Long = 0
    '    Try


    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA_FROM_PREFACT", 62, _
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
    '    Public Function FN_L_FACTURAS_SIN_CARGOS(ByVal VOCONTROLUSUARIO As Object) As DataView
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
    'Public Function FN_L_FACTURAS_FROM_PREFACTU(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_L_FACTURAS_FROM_PREFACTU", 10, _
    '        1, 1, _
    '        IDPERSONA, 1, _
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
    'Public Function FN_L_FACTURAS_FROM_PREFACTU_(ByVal VOCONTROLUSUARIO As Object) As DataView
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
    'Public Function FNFACTURAS_GUIAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_FACTURAS_GUIAS", 4, _
    '        IDFACTURA, 1 _
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
    'Public Function FNFACTURAS_PREFACTURAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_FACTURAS_PREFACTURAS", 4, _
    '        IDFACTURA, 1 _
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
    'Public Function FNPREFACTURAS_GUIAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_PREFACTURAS_GUIAS", 4, _
    '        IDPREFACTURA, 1 _
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
    'Public Function FNANU_FACTURAS_GUIAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ANU_FACTURAS_GUIAS", 10, _
    '    IDFACTURA, 1, _
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
    'Public Function FNANU_FACTURAS_PREFACTURAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ANU_FACTURAS_PREFACTURAS", 10, _
    '    IDFACTURA, 1, _
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

    'Public Function FNQUITAR_FACTURAS_GUIAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_QUITAR_FACTURAS_GUIAS", 14, _
    '        OPE, 1, _
    '        IDGUIAS_ENVIO, 1, _
    '        IDFACTURA, 1, _
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
    'Public Function FN_QUITAR_FACTURAS_PREFACTURAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_QUITAR_FACTURAS_PREFACTURAS", 14, _
    '        OPE, 1, _
    '        IDPREFACTURA, 1, _
    '        IDFACTURA, 1, _
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
    'Public Function FN_CARGO_FACTU(ByVal VOCONTROLUSUARIO As Object) As DataView
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

    'Public Function FN_L_FACTU_AUTO(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal VOCONTROLUSUARIO As Object, ByRef dv_L_GUIAS_COMPRO As DataView) As DataView

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


    '    Dim dv As New DataView


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
    'Public Function FN_ESTADO_IMPRESO(ByVal cnn As System.Data.OracleClient.OracleConnection)

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
    'Public Function FN_ConsulFactuEmi(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
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
    'Public Function FN_CONSUL_GUIAS_EMI_DG(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG", 16, _
    '    IIf(IDPERSONA = 0, -666, IDPERSONA), 1, _
    '  IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), 1, _
    '  IIf(IDTIPO_MONEDA = 0, -666, IDTIPO_MONEDA), 1, _
    '  IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), 1, _
    '  IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), 1, _
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
    'Public Function FN_CONSUL_GUIAS_EMI_DG_(ByVal cnn As Data.OracleClient.OracleConnection) As DataView

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
    'Public Function FN_ConsulPreFactuEmi(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    'Public Function FN_ConsulPreFactuEmi_(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView

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


    'Public Function FN_LISTAR_PREFACTURAS(ByVal VOCONTROLUSUARIO As Object) As DataView
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


    'Public Function FN_ConsulFactuEmiPorCobrar(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
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

    'Public Function FN_L_FACTU_AUTO_T3(ByVal VOCONTROLUSUARIO As Object, ByRef DV_L_FACTU_AUTOT3 As DataView, ByRef dv_L_PREFACTU_COMPRO As DataView)
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

    'Public Function FN_CONSUL_GUIAS_CARGO_docu_DG(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_CARGO_docu_DG", 18, _
    '    IDPERSONA, 1, _
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
    'Public Function FN_CONSUL_GUIAS_EMI_DG2(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Long
    '    Dim a As Long = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_EMI_DG2", 20, _
    '    IDPERSONA, 1, _
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
    'Public Function fn_UPDATE_SELEC_TO_FACTURA(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection)
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

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '  Dim m As LONG
    '    '  Dim a As LONG = 0
    '    '  Dim dT As New DataTable
    '    '  Dim dv As New DataView
    '    '  Dim DA As New OleDb.OleDbDataAdapter
    '    '  Dim Rst As New ADODB.Recordset
    '    '  Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_UPDATE_SELEC_TO_FACTURA", 6, _
    '    '  IDGUIAS_ENVIO, 1, _
    '    'SELECCIONAR_TO_FACTURA, 1}


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

    '    '  Catch ex As System.Exception
    '    '      MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    '  Catch OEx As System.Data.OracleClient.OracleException
    '    '      MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    '  End Try
    'End Function

    'Public Function FNELI_FACTURAS_GUIAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ELI_FACTURAS_GUIAS", 10, _
    '    IDFACTURA, 1, _
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


    'Public Function FNELI_FACTURAS_PREFACTURAS(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ELI_FACTURAS_PREFACTURAS", 10, _
    '    IDFACTURA, 1, _
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

    'Public Function SP_LIST_FACTURADOS(ByVal VOCONTROLUSUARIO As Object) As DataView
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

    Public Function SP_ConsulFactuEmiConta(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaII", 28, _
        IDPERSONA, 1, _
        IDFORMA_PAGO, 1, _
        IDTIPO_MONEDA, 1, _
        IDAGENCIAS, 1, _
        IDUSUARIO_PERSONAL, 1, _
        FECHA_INICIO, 2, _
        FECHA_FINAL, 2, _
        NRO_FACTURA, 2, _
        IDUNIDAD_ORIGEN, 1, _
        IDUNIDAD_DESTINO, 1, _
        IDTIPO_COMPROBANTE, 1, _
        IDTIPO_ENTREGA, 1, _
        P_ENTRE, 1}

        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        DA.Fill(dT, Rst)

        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If

            Return dv

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function
    Public Function SP_CONSUL_GUIAS_ETREGA(ByVal VOCONTROLUSUARIO As Object) As DataView

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_CONSUL_GUIAS_ETREGA", 20, _
        IIf(IDPERSONA = 0, -666, IDPERSONA), 1, _
      IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), 1, _
      IIf(IDTIPO_MONEDA = 0, -666, IDTIPO_MONEDA), 1, _
      IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), 1, _
      IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), 1, _
      FECHA_INICIO, 2, _
      FECHA_FINAL, 2, _
IDUNIDAD_ORIGEN, 1, _
IDUNIDAD_DESTINO, 1}


        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)


        DA.Fill(dT, Rst)



        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If
            Return dv
        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
    'Public Function FNLISTAR_FACTURAS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
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
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function fn_INUPDE_FACTURA_FROM_PREFAC_(ByVal VOCONTROLUSUARIO As Object) As Boolean
        fn_INUPDE_FACTURA_FROM_PREFAC_ = True

        Dim DT As New DataTable
        Dim Rst As New ADODB.Recordset
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim m As Long

        Dim a As Long = 0
        Try


            Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_INUPDE_FACTURA_FROM_PREFAC_", 62, _
            1, 1, _
            IDFORMA_PAGO, 1, _
            IDESTADO_ENVIO, 1, _
            IDESTADO_FACTURA, 1, _
            IIf(IDCIUDAD_TRANSITO = 0, -666, IDCIUDAD_TRANSITO), 1, _
            CANTIDAD, 3, _
            TOTAL_PESO, 3, _
            TOTAL_VOLUMEN, 3, _
            IIf(IDGUIA_TRANSPORTISTA = 0, -666, IDGUIA_TRANSPORTISTA), 1, _
            IIf(IDGUIA_TRANSPORTISTA_UPD = 0, -666, IDGUIA_TRANSPORTISTA_UPD), 1, _
            IIf(IDUNIDAD_ORIGEN = 0, -666, IDUNIDAD_ORIGEN), 1, _
            IIf(IDUNIDAD_DESTINO = 0, -666, IDUNIDAD_DESTINO), 1, _
            IIf(IDDIREECION_ORIGEN = 0, -666, IDDIREECION_ORIGEN), 1, _
            IIf(IDDIREECION_DESTINO = 0, -666, IDDIREECION_DESTINO), 1, _
            MONTO_TIPO_CAMBIO, 3, _
            IDTIPO_MONEDA, 1, _
            FECHA, 2, _
            FECHA_VENCIMIENTO, 2, _
            IIf(IDPERSONA_ORIGEN = 0, -666, IDPERSONA_ORIGEN), 1, _
            IIf(IDPERSONA_DESTINO = 0, -666, IDPERSONA_DESTINO), 1, _
            Str(IDPERSONA), 2, _
            IDTIPO_COMPROBANTE, 1, _
            MONTO_IMPUESTO, 3, _
            TOTAL_COSTO, 3, _
            IDAGENCIAS, 1, _
            IDUSUARIO_PERSONAL, 1, _
            IP, 2, _
            IDROL_USUARIO, 1, _
            CANTIDAD_X_UNIDAD_ARTI, 3, _
            CANTIDAD_X_UNIDAD_VOLUMEN, 3 _
            }
            Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            DA.Fill(DT, Rst)
            dv = DT.DefaultView

            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If dv.Table.Rows(0)(0) = -666 Then
                        m = 1 / a
                    End If
                End If
            End If

            IDFACTURA = dv.Table.Rows(0)(0)

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function
    Public Function sp_l_desti_dife_carga(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView



        Dim cmd As New System.Data.OracleClient.OracleCommand
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "pkg_rep_general.sp_l_desti_dife_carga"
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_l_desti_dife_carga", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

        Dim ds As New DataSet
        daora.Fill(ds)


        Dim dv As New DataView


        Try

            dv = ds.Tables(0).DefaultView


            Return dv
            '' ''Dim dv As New DataView
            '' ''Dim Rst As New ADODB.Recordset
            '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
            '' ''1, 1, _
            '' ''Str(IDPERSONA), 2, _
            '' ''FECHA_INICIO, 2, _
            '' ''FECHA_FINAL, 2 _
            '' ''}

            '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            '' ''Dim DA As New OleDb.OleDbDataAdapter
            '' ''Dim DT As New DataTable
            '' ''DA.Fill(DT, Rst)
            '' ''dv = DT.DefaultView
            '' ''MsgBox(dv.Count)
            '' ''Return dv
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
    Public Function sp_l_carga_conta_ge(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView



        Dim cmd As New System.Data.OracleClient.OracleCommand
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "pkg_rep_general.sp_l_carga_conta_ge"
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_ORIGEN
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_DESTINO
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFUNCIONARIO_ACTUAL", OracleClient.OracleType.VarChar)).Value = IDFUNCIONARIO_ACTUAL
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
        cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_l_carga_conta_ge", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

        Dim ds As New DataSet
        daora.Fill(ds)


        Dim dv As New DataView


        Try

            dv = ds.Tables(0).DefaultView


            Return dv
            '' ''Dim dv As New DataView
            '' ''Dim Rst As New ADODB.Recordset
            '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
            '' ''1, 1, _
            '' ''Str(IDPERSONA), 2, _
            '' ''FECHA_INICIO, 2, _
            '' ''FECHA_FINAL, 2 _
            '' ''}

            '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            '' ''Dim DA As New OleDb.OleDbDataAdapter
            '' ''Dim DT As New DataTable
            '' ''DA.Fill(DT, Rst)
            '' ''dv = DT.DefaultView
            '' ''MsgBox(dv.Count)
            '' ''Return dv
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function

    Public Function SP_ConsulFactuEmiContaIII06012014(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIII", 28, _
        IDPERSONA, 1, _
        IDFORMA_PAGO, 1, _
        IDTIPO_MONEDA, 1, _
        IDAGENCIAS, 1, _
        IDUSUARIO_PERSONAL, 1, _
        FECHA_INICIO, 2, _
        FECHA_FINAL, 2, _
        NRO_FACTURA, 2, _
        IDUNIDAD_ORIGEN, 1, _
        IDUNIDAD_DESTINO, 1, _
        IDTIPO_COMPROBANTE, 1, _
        IDTIPO_ENTREGA, 1, _
        P_ENTRE, 1}

        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        DA.Fill(dT, Rst)

        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If

            Return dv

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function

    Public Function SP_ConsulFactuEmiContaIV(ByVal VOCONTROLUSUARIO As Object) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaIV", 28, _
        IDPERSONA, 1, _
        IDFORMA_PAGO, 1, _
        IDTIPO_MONEDA, 1, _
        IDAGENCIAS, 1, _
        IDUSUARIO_PERSONAL, 1, _
        FECHA_INICIO, 2, _
        FECHA_FINAL, 2, _
        NRO_FACTURA, 2, _
        IDUNIDAD_ORIGEN, 1, _
        IDUNIDAD_DESTINO, 1, _
        IDTIPO_COMPROBANTE, 1, _
        IDTIPO_ENTREGA, 1, _
        IDESTADO_ENVIO, 1}

        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        DA.Fill(dT, Rst)

        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If

            Return dv

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function
    Public Function sp_L_CARGA_CONTA_CHECK_PCE(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView



        Dim cmd As New System.Data.OracleClient.OracleCommand
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PKG_IVOFACTURACION.sp_L_CARGA_CONTA_CHECK_PCE"
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_ENTREGA", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_SERIE_FACTURA", OracleClient.OracleType.VarChar)).Value = SERIE_FACTURA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_FACTURA", OracleClient.OracleType.VarChar)).Value = NRO_FACTURA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS_DESTINO", OracleClient.OracleType.Number)).Value = IDAGENCIAS_DESTINO

        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_CARGA_CONTA_CHECK_PCE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

        Dim ds As New DataSet
        daora.Fill(ds)


        Dim dv As New DataView


        Try

            dv = ds.Tables(0).DefaultView


            Return dv
            '' ''Dim dv As New DataView
            '' ''Dim Rst As New ADODB.Recordset
            '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
            '' ''1, 1, _
            '' ''Str(IDPERSONA), 2, _
            '' ''FECHA_INICIO, 2, _
            '' ''FECHA_FINAL, 2 _
            '' ''}

            '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            '' ''Dim DA As New OleDb.OleDbDataAdapter
            '' ''Dim DT As New DataTable
            '' ''DA.Fill(DT, Rst)
            '' ''dv = DT.DefaultView
            '' ''MsgBox(dv.Count)
            '' ''Return dv
        Catch
            Throw
        End Try
    End Function

    Public Sub SP_ENTREGAR_BULTO(ByVal cnn As System.Data.OracleClient.OracleConnection)
        Try
            Dim cmd As New System.Data.OracleClient.OracleCommand
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "PKG_IVOFACTURACION.SP_ENTREGAR_BULTO"
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IPMOD", OracleClient.OracleType.VarChar)).Value = Me.IPMOD
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONALMOD", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONALMOD
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIOMOD", OracleClient.OracleType.Number)).Value = IDROL_USUARIOMOD
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ENTREGA", OracleClient.OracleType.VarChar)).Value = FECHA_ENTREGA
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA

            cmd.ExecuteNonQuery()

        Catch
            Throw
        End Try
    End Sub
    Public Function SP_l_pasa_credi(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView



        Dim cmd As New System.Data.OracleClient.OracleCommand
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PKG_IVOFACTURACION.SP_l_pasa_credi"
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idpersona", OracleClient.OracleType.Number)).Value = IDPERSONA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INIcial", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_SERIE_comproBANTE", OracleClient.OracleType.VarChar)).Value = SERIE_FACTURA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_COMPROBANTE", OracleClient.OracleType.VarChar)).Value = NRO_FACTURA
        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_l_pasa_credi", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

        Dim ds As New DataSet
        daora.Fill(ds)


        Dim dv As New DataView


        Try

            dv = ds.Tables(0).DefaultView


            Return dv
            '' ''Dim dv As New DataView
            '' ''Dim Rst As New ADODB.Recordset
            '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
            '' ''1, 1, _
            '' ''Str(IDPERSONA), 2, _
            '' ''FECHA_INICIO, 2, _
            '' ''FECHA_FINAL, 2 _
            '' ''}

            '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            '' ''Dim DA As New OleDb.OleDbDataAdapter
            '' ''Dim DT As New DataTable
            '' ''DA.Fill(DT, Rst)
            '' ''dv = DT.DefaultView
            '' ''MsgBox(dv.Count)
            '' ''Return dv
        Catch
            Throw
        End Try
    End Function
    Public Function RGT_BUSCA_FECHA_PAGO_PCE(ByVal cnnSQL As System.Data.SqlClient.SqlConnection) As DataView



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
            '' ''Dim dv As New DataView
            '' ''Dim Rst As New ADODB.Recordset
            '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
            '' ''1, 1, _
            '' ''Str(IDPERSONA), 2, _
            '' ''FECHA_INICIO, 2, _
            '' ''FECHA_FINAL, 2 _
            '' ''}

            '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            '' ''Dim DA As New OleDb.OleDbDataAdapter
            '' ''Dim DT As New DataTable
            '' ''DA.Fill(DT, Rst)
            '' ''dv = DT.DefaultView
            '' ''MsgBox(dv.Count)
            '' ''Return dv
        Catch
            Throw
        End Try
    End Function


    Public Sub sp_upda_fecha_entre_pce(ByVal cnn As System.Data.OracleClient.OracleConnection)
        Try
            Dim cmd As New System.Data.OracleClient.OracleCommand
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "PKG_IVOFACTURACION.sp_upda_fecha_entre_pce"
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ENTREGA", OracleClient.OracleType.VarChar)).Value = FECHA_ENTREGA
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.Number)).Value = IDFACTURA

            cmd.ExecuteNonQuery()

        Catch
            Throw
        End Try
    End Sub
    Public Function SP_L_VENTA_PAG(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView

        Try

            Dim cmd As New System.Data.OracleClient.OracleCommand
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "pkg_rep_general.SP_L_VENTA_PAG"
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFACTURA", OracleClient.OracleType.VarChar)).Value = IDFACTURA
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_RAZON_SOCIAL", OracleClient.OracleType.VarChar)).Value = RAZON_SOCIAL
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_PAGI", OracleClient.OracleType.VarChar)).Value = PAGI
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = Me.FECHA_INICIO
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_ORIGEN", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_ORIGEN
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUNIDAD_DESTINO", OracleClient.OracleType.VarChar)).Value = IDUNIDAD_DESTINO
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDFUNCIONARIO_ACTUAL", OracleClient.OracleType.VarChar)).Value = IDFUNCIONARIO_ACTUAL
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
            cmd.Parameters.Add(New OracleClient.OracleParameter("p_idforma_pago", OracleClient.OracleType.Number)).Value = IDFORMA_PAGO
            cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_entrega", OracleClient.OracleType.Number)).Value = IDTIPO_ENTREGA
            cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_VENTA_PAG", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


            Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)


            Dim ds As New DataSet
            daora.Fill(ds)


            Dim dv As New DataView



            dv = ds.Tables(0).DefaultView


            Return dv
            '' ''Dim dv As New DataView
            '' ''Dim Rst As New ADODB.Recordset
            '' ''Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_LISTAR_FACTURAS", 10, _
            '' ''1, 1, _
            '' ''Str(IDPERSONA), 2, _
            '' ''FECHA_INICIO, 2, _
            '' ''FECHA_FINAL, 2 _
            '' ''}

            '' ''Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            '' ''Dim DA As New OleDb.OleDbDataAdapter
            '' ''Dim DT As New DataTable
            '' ''DA.Fill(DT, Rst)
            '' ''dv = DT.DefaultView
            '' ''MsgBox(dv.Count)
            '' ''Return dv
        Catch
            Throw
        End Try
    End Function
    Public Function SP_ConsulFactuEmiIIPCE_GERE(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiIIPCE_GERE", 28, _
        IDPERSONA, 1, _
        IDFORMA_PAGO, 1, _
        IDTIPO_MONEDA, 1, _
        IDAGENCIAS, 1, _
        IDUSUARIO_PERSONAL, 1, _
        FECHA_INICIO, 2, _
        FECHA_FINAL, 2, _
        NRO_FACTURA, 2, _
        IDUNIDAD_ORIGEN, 1, _
        IDUNIDAD_DESTINO, 1, _
        IDTIPO_COMPROBANTE, 1, _
        IDTIPO_ENTREGA, 1, _
        P_ENTRE, 1}

        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        DA.Fill(dT, Rst)

        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If

            Return dv

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function
    Public Function SP_ConsulFactuEmiContav(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaV", 30, _
        agencia_venta, 1, _
        CStr(IDPERSONA), 2, _
        IDFORMA_PAGO, 1, _
        IDTIPO_MONEDA, 1, _
        IDAGENCIAS, 1, _
        IDUSUARIO_PERSONAL, 1, _
        FECHA_INICIO, 2, _
        FECHA_FINAL, 2, _
        NRO_FACTURA, 2, _
        IDUNIDAD_ORIGEN, 1, _
        IDUNIDAD_DESTINO, 1, _
        IDTIPO_COMPROBANTE, 1, _
        IDTIPO_ENTREGA, 1, _
        P_ENTRE, 1}

        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        DA.Fill(dT, Rst)

        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If

            Return dv

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function
    Public Function SP_ConsulFactuEmiContaDescu(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_ConsulFactuEmiContaDescu", 30, _
        agencia_venta, 1, _
        CStr(IDPERSONA), 2, _
        IDFORMA_PAGO, 1, _
        IDTIPO_MONEDA, 1, _
        IDAGENCIAS, 1, _
        IDUSUARIO_PERSONAL, 1, _
        FECHA_INICIO, 2, _
        FECHA_FINAL, 2, _
        NRO_FACTURA, 2, _
        IDUNIDAD_ORIGEN, 1, _
        IDUNIDAD_DESTINO, 1, _
        IDTIPO_COMPROBANTE, 1, _
        IDTIPO_ENTREGA, 1, _
        P_ENTRE, 1}

        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        DA.Fill(dT, Rst)

        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If

            Return dv

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function

    Public Function sp_ConsulFactuEmiEntreManu(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.sp_ConsulFactuEmiEntreManu", 30, _
        agencia_venta, 1, _
        CStr(IDPERSONA), 2, _
        IDFORMA_PAGO, 1, _
        IDTIPO_MONEDA, 1, _
        IDAGENCIAS, 1, _
        IDUSUARIO_PERSONAL, 1, _
        FECHA_INICIO, 2, _
        FECHA_FINAL, 2, _
        NRO_FACTURA, 2, _
        IDUNIDAD_ORIGEN, 1, _
        IDUNIDAD_DESTINO, 1, _
        IDTIPO_COMPROBANTE, 1, _
        IDTIPO_ENTREGA, 1, _
        P_ENTRE, 1}

        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        DA.Fill(dT, Rst)

        Try

            dv = dT.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
                        m = 1 / a
                    End If
                End If
            End If

            Return dv

        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function

    Public Function SP_Consultagiro(ByVal VOCONTROLUSUARIO As Object, ByVal P_ENTRE As Long) As DataView
        Dim m As Long
        Dim a As Long = 0
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        Dim Rst As New ADODB.Recordset
        '
        Dim varSP_OBJECT() As Object = {"PKG_IVOGIROS.SP_ConsultaGiro", 20, _
          CType(IDPERSONA, String), 2, _
          IDFORMA_PAGO, 1, _
          IDTIPO_MONEDA, 1, _
          IDAGENCIAS, 1, _
          IDAGENCIAS_DESTINO, 1, _
          FECHA_INICIO, 2, _
          FECHA_FINAL, 2, _
          NRO_FACTURA, 2, _
          P_ENTRE, 1}
        ' 
        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        DA.Fill(dT, Rst)
        Try
            dv = dT.DefaultView
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
        Catch ex As System.Exception
            MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
#End Region

End Class