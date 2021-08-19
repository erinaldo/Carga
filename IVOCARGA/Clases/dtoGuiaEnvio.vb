Imports AccesoDatos
Public Class dtoGuiaEnvio
    '********RICHARD*******************************************************
    Public TarifaPublica_ As Boolean
    Public TarifaPyme_ As Boolean
    Public TarifaBox_ As Boolean

    Public UnidadPeso_ As String
    Public UnidadVol_ As String
    Public TarifaMasiva_ As Boolean
    Public Unidad_ As String
    Public TipoTarifa_ As Integer
    Public TipoProducto_ As Integer
    Public CondicionTarifa_ As Boolean

#Region "CONTROL_GUIAS"
    Public iarticulo As Integer
    Public idCONTROL_GUIAS As Integer
    Public iCONTROL_Nro_Guia As String
    Public iCONTROL_Nro_RUC_RASON_SOCIAl As String
    Public iCONTROLIdagencias As Integer
    Public iCONTROLIdunidad_Origen As Integer
    Public iCONTROLIdunidad_Destino As Integer
    Public iCONTROLIdpersona As Integer
    Public iIRuc_Rason_Social As String
    Public iCONTROLFecha_Inicio As String
    Public iCONTROLFecha_Final As String
    Public iCONTROLIdrol_Usuariol As Integer
    Public iCONTROLIdIdestado_Registro As Integer
    Public iTarifa As Integer
    '
    Public iTarifa_Publica_Monto_Base_credito As Double
    Public iTarifa_Publica_Monto_Peso_credito As Double
    Public iTarifa_Publica_Monto_Volumen_credito As Double
    Public iTarifa_Publica_Monto_Base_Xpostal_credito As Double
    Public iTarifa_Publica_Monto_Sobre_Credito As Double
    '
#End Region
#Region "RECORSET"
    'Public cur_idtarifas_carga_cliente As New ADODB.Recordset
    'Public RST_VENTA_ARTICULOS As New ADODB.Recordset
    'Public cur_Lista_guias_Envio As New ADODB.Recordset
    'Public cur_Origen As New ADODB.Recordset
    'Public cur_Destino As New ADODB.Recordset
    'Public cur_control_Centro_Costo As New ADODB.Recordset
    '
    'Public rst_Lista_Personas As New ADODB.Recordset
    'Public rst_Tarifa_Publica_Carga As New ADODB.Recordset
    'Public rst_Tarifa_Cliente_Carga As New ADODB.Recordset
    '
    'Public rst_Lista_Unidades As New ADODB.Recordset
    'Public rst_Lista_Unidades_Agencia As New ADODB.Recordset
    'Public rst_Lista_Agencias As New ADODB.Recordset
    'Public rst_Lista_Usuarios As New ADODB.Recordset
    'Public rst_Lista_Estados As New ADODB.Recordset
    'Public rst_Lista_Forma_Pagos As New ADODB.Recordset
    'Public rst_Lista_Tipo_Entrega As New ADODB.Recordset
    '
    'Public rst_Articulos As New ADODB.Recordset
    'Public rst_Articulos_sub_cuenta As New ADODB.Recordset
    'Public rst_Control As New ADODB.Recordset
    'Public cur_Err As New ADODB.Recordset

    'Public cur_etiqueta As New ADODB.Recordset

    'Public rst_Lista_Documentos_Guia As New ADODB.Recordset
    'Public cur_Lista_Unidades_visor As New ADODB.Recordset

    Public coll_Lista_Unidades_Origen As New Collection
    Public coll_Lista_Unidades_Destino As New Collection

    Public coll_Lista_Origen As New Collection
    Public coll_Lista_Destino As New Collection
    Public Coll_IATA As New Collection

    Public coll_Lista_Agencias As New Collection
    Public coll_Lista_Usuarios As New Collection
    Public coll_Lista_Estados As New Collection
    Public coll_Lista_Forma_Pagos As New Collection
    Public coll_Lista_Tipo_Entrega As New Collection


    'Public cur_Cliente As New ADODB.Recordset
    'Public cur_CLIENTE_REMITENTE As New ADODB.Recordset
    'Public cur_Sub_Cuenta As New ADODB.Recordset
    'Public cur_Nombres_Remitente As New ADODB.Recordset
    'Public cur_Direccion_Remitente As New ADODB.Recordset
    'Public cur_Telefono_Remitente As New ADODB.Recordset
    'Public cur_Nombres_Destinatario As New ADODB.Recordset
    'Public cur_Direccion_Destinatario As New ADODB.Recordset
    'Public cur_Telefono_Destinatario As New ADODB.Recordset
    'Public cur_Documentos_Adjuntos As New ADODB.Recordset
    'Public cur_Pagos As New ADODB.Recordset

    'Public curr_datos_Guia_Envio As New ADODB.Recordset
    'Public curr_Error_datos As New ADODB.Recordset
    Public coll_Cliente As New Collection
    Public coll_Sub_Cuenta As New Collection
    Public coll_Nombres_CLIENTE_REMITENTE As New Collection
    Public coll_Nombres_Remitente As New Collection
    Public coll_Direccion_Remitente As New Collection
    Public coll_Telefono_Remitente As New Collection
    Public coll_Nombres_Destinatario As New Collection
    Public coll_Direccion_Destinatario As New Collection
    Public coll_Telefono_Destinatario As New Collection

    Public coll_Documentos_Adjuntos As New Collection
    Public coll_Pagos As New Collection

    Public coll_Err As New Collection

    Public iCANTIDAD_SOBRES As Integer = 0
    Public iIDSINO_SOBRES As Integer = 0

    Public iPeso_Minimo As Double = 0
    Public iPeso_Maximo As Double = 0
    Public iPrecio_cond_Peso As Double = 0

    Public iVol_Minimo As Double = 0
    Public iVol_Maximo As Double = 0
    Public iPrecio_cond_Vol As Double = 0



    'Public curr_Cond_Pagos As New ADODB.Recordset

    Public iControl_Guias_Existe As Integer = 0

    Public iControl_Busqueda As Integer = 0
    'Public cur_codBarras As New ADODB.Recordset
    '
#End Region
#Region "DataTable"
    Public dt_cur_idtarifas_carga_cliente As New DataTable
    Public dt_Lista_Personas As New DataTable
    Public dt_cur_Origen As New DataTable
    Public dt_cur_Destino As New DataTable
    Public dt_Lista_Unidades As New DataTable
    Public dt_Lista_Agencias As New DataTable
    Public dt_Lista_Usuarios As New DataTable
    Public dt_Lista_Estados As New DataTable
    Public dt_Lista_Forma_Pagos As New DataTable
    Public dt_Lista_Tipo_Entrega As New DataTable
    Public dt_Lista_Unidades_Agencia As New DataTable
    '
    Public dt_cur_Sub_Cuenta As New DataTable
    Public dt_cur_Sub_Cuenta_Destino As New DataTable
    Public dt_cur_Nombres_Remitente As New DataTable
    Public dt_cur_Direccion_Remitente As New DataTable
    Public dt_cur_Telefono_Remitente As New DataTable
    Public dt_Nombres_Destinatario As New DataTable
    Public dt_cur_Nombres_Destinatario As New DataTable
    Public dt_cur_Direccion_Destinatario As New DataTable
    Public dt_cur_Telefono_Destinatario As New DataTable
    Public dt_cur_Documentos_Adjuntos As New DataTable
    Public dt_cur_Pagos As New DataTable
    Public dt_cur_Err As New DataTable
    Public dt_rst_Articulos As New DataTable
    Public dt_rst_Control As New DataTable
    Public dt_cur_control_Centro_Costo As New DataTable
    '
    Public dt_cur_codBarras As New DataTable
    Public dt_cur_Lista_guias_Envio As New DataTable
    Public dt_rst_Articulos_sub_cuenta As New DataTable
    ' 
    Public dt_cur_edtguia_documentos As New DataTable
    '
    Public dt_cur_edtguia_envio As New DataTable
    Public dt_cur_edtguia_articulos As New DataTable
    Public dt_cur_CLIENTE_REMITENTE As New DataTable
    Public dt_RST_VENTA_ARTICULOS As New DataTable
    Public dt_rst_Lista_Documentos_Guia As New DataTable
    '
    Public dt_cur_etiqueta As New DataTable
    '
#End Region
#Region "DTO GUIAS DE ENVIO"

    Public IDCENTRO_COSTO As Integer
    Public iCONTROL As Integer
    Public iIDGUIAS_ENVIO As Integer
    Public sFECHA_GUIA As String
    Public sNRO_GUIA As String
    Public sRASON_SOCIAL As String
    Public sNU_DOCU_SUNAT As String
    Public iIDUNIDAD_AGENCIA As Integer
    Public iIDUNIDAD_AGENCIA_DESTINO As Integer
    Public iIDPERSONA As Integer
    Public iIDAGENCIAS As Integer
    Public iIDAGENCIAS_DESTINO As Integer
    Public iIDDIRECCION_CONSIGNADO As Integer
    Public iIDCONTACTO_PERSONA As Integer
    Public iIDTIPO_ENTREGA_CARGA As Integer
    Public iIDFORMA_PAGO As Integer
    Public iIDTARIFAS_CARGA_CLIENTE As Integer
    Public iIDTARIFAS_CARGA As Integer
    Public sFECHA_DESPACHO As String
    Public sFECHA_RECEPCION_DESTINO As String
    Public sFECHA_ENTREGA As String
    Public sFECHA_CARGOS As String
    Public iIDCIUDAD_TRANSITO As Integer
    Public dTOTAL_PESO As Double
    Public iCANTIDAD As Integer
    Public dTOTAL_VOLUMEN As Double
    Public dMONTO_BASE As Double
    Public dPRECIO_X_UNIDAD As Double
    Public dPrecio_xUnidad2 As Double
    Public sNOMBRE_RECOJO As String
    Public sNOMBRE_ENTREGA As String
    Public sDOC_ENTREGA As String
    Public sFECHA_RECOJO As String

    'Public IDARTICULOS              NUMBER(10),
    Public iIDUSUARIO_PERSONALMOD As Integer
    Public iIDROL_USUARIO As Integer
    Public iIDROL_USUARIOMOD As Integer
    Public sIP As String
    Public iIDESTADO_REGISTRO As Integer
    Public sFECHA_REGISTRO As String
    Public sFECHA_ACTUALIZACION As String
    Public iIDUSUARIO_PERSONAL As Integer
    Public dTOTAL_COSTO As Double
    Public iIDPREFACTURA As Integer
    Public iIDFACTURA_CREDITO As Integer
    Public iIDCENTRO_COSTO As Integer = 999
    Public iIPRODUCTO As Integer
    Public iTipo As Integer
    Public iIDUSUARIO_REVISION As Integer
    Public iIDROL_REVISION As Integer
    Public sFECHA_REVISION As String
    Public sSERIE_GUIA_ENVIO As String
    Public iIDIMPUESTO As Integer
    Public dIMPUESTO As Double
    Public iIDDIRECCION_REMITENTE As Integer
    Public iNRO_DOC_REMITENTE As String
    Public iNRO_DOC_DESTINATARIO As String
    Public iIDCONTACTO_DESTINATARIO As Integer
    Public iIDTipoFacturacion As Integer

    Public iIDDIRECCION_DESTINATARIO As Integer
    Public iIDCONTACTO_REMITENTE As Integer

    Public iCANTIDAD_X_UNIDAD_VOLUMEN As Integer
    Public iCANTIDAD_X_UNIDAD_ARTI As Integer
    Public dMONTO_IMPUESTO As Double
    Public iIDTEFONO_REMITENTE As Integer
    Public iIDTEFONO_CONSIGNADO As Integer

    Public iTarifa_Publica_Monto_Base As Double
    Public iTarifa_Publica_Monto_Base1 As Double
    Public iTarifa_Publica_Monto_Peso As Double
    Public iTarifa_Publica_Monto_Volumen As Double
    Public iTarifa_Publica_Monto_Sobre As Double
    Public iTarifa_Publica_Monto_Base_Xpostal As Double
    Public iMonto25 As Double
    Public iMonto40 As Double


    Public sDireccion_Remitente As String
    Public sTelefono_Remitente As String

    Public sNombres_Destinatario As String
    Public sDireccion_Destinatario As String
    Public sTelefono_Destinatario As String

    Public iNOMBRES_REMITENTE As String
    Public iDNI_REMITENTE As String
    Public iDIRECCION_REMITENTE As String
    Public iNOMBRES_DESTINATARIO As String
    Public iDNI_DESTINATARIO As String
    Public iDIRECCION_DESTINATARIO As String

    Public iPrecio_x_Peso As Double = 1.1
    Public iPrecio_x_Volumen As Double = 1.3
    Public iCARGO As Integer

    Public iID_REMITENTE As Integer
    Public iREMITENTE As String
    Public iNRODOC_REM As String
    Public iNOMBRE_UNIDAD_ORIGEN As String
    Public iNOMBRE_UNIDAD_DESTINO As String

    Public FEC_MAX_APERTURA_LIQ As String
    Public FEC_MAX_CIERRE_LIQ As String

    Public V_IDTIPO_COMPROBANTE As Integer = 3

    Public iDescuento As Double
    Public sAutoriza As String

    Public bContado As Boolean
    '
    Public total_bultos As Long ' Creado por la reimpresión de etiquetas 
    '

    Public intTarifaPersonalizada As Integer
    Public guia As String
    Public barra As String
#End Region
#Region "DETALLE DOCUMENTOS"

    Public iControl_Documentos As Integer
    Public iNro_Serie As String
    Public iNro_Docu As String

#End Region
#Region "METODOS GUIAS DE ENVIO"
    'Ref:
    'Define la lista inicial del formulario control...(frm...)
    'Public Function fnLISTA_INICIAL_GUIAS_ENVIO_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_INICIAL_GUIAS_ENVIO", 4, 4, 1}
    '        rst_Lista_Unidades = Nothing
    '        rst_Lista_Agencias = Nothing
    '        rst_Lista_Usuarios = Nothing
    '        rst_Lista_Estados = Nothing
    '        rst = Nothing
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        rst_Lista_Unidades = rst
    '        If rst.EOF = False And rst.BOF = False Then
    '            rst_Lista_Agencias = rst.NextRecordset
    '            rst_Lista_Usuarios = rst.NextRecordset
    '            rst_Lista_Estados = rst.NextRecordset
    '            rst_Lista_Forma_Pagos = rst.NextRecordset
    '            rst_Lista_Tipo_Entrega = rst.NextRecordset
    '        End If
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_INICIAL_GUIAS_ENVIO] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function
    Public Function fnFILTRO_USUARIO_X_AGENCIA_2(ByVal idAgencia As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            'acceso 21/04/2010
            'db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_FILTRO_USUARIO_X_AGENCIA", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_VENTACONTADO.SP_FILTRO_USUARIO_X_AGENCIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("idAgencia", idAgencia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            dt_Lista_Usuarios = ldt_tmp
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function fnLISTA_INICIAL_GUIAS_ENVIO() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            Dim li_idproceso As Integer
            'Por defecto 4 Guias de Envio 
            li_idproceso = 4
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_LISTA_INICIAL_GUIAS_ENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("idProceso", li_idproceso, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Lista_Unidades", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Lista_Agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Lista_Estados", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Lista_Forma_Pagos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Lista_Tipo_Entrega", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Lista_Unidades_visor", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                dt_Lista_Unidades = lds_tmp.Tables(0)
                dt_Lista_Agencias = lds_tmp.Tables(1)
                dt_Lista_Usuarios = lds_tmp.Tables(2)
                dt_Lista_Estados = lds_tmp.Tables(3)
                dt_Lista_Forma_Pagos = lds_tmp.Tables(4)
                dt_Lista_Tipo_Entrega = lds_tmp.Tables(5)
                flat = True
            Else
                flat = False
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnLISTA_AGENCIA_USUARIOS_2009(ByVal idAgencia As Integer) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_AGENCIA_USUARIOS", 4, 4, 1}
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_AGENCIA_USUARIOS] " & fnLoagObj(varSP_OBJECT))
    '        rst_Lista_Usuarios = Nothing
    '        rst_Lista_Usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_AGENCIA_USUARIOS] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function
    '    Public Function fnCONTROL_GUIAS_ENVIO_DOC_2009() As Boolean
    '        Dim flat As Boolean = False
    '        Try
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 10, iCONTROL, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}

    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 14, iControl_Busqueda, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 14, iCONTROL, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}

    '            '            Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CONTROL_GUIAS_ENVIO_DOC_I", 14, iControl_Busqueda, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}
    '            Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CONTROL_GUIAS_ENVIO_DOC_II", 14, iControl_Busqueda, 1, iIDPERSONA.ToString, 2, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}
    '            objLOG.fnLog("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & fnLoagObj(varSP_OBJECT))
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 10, 1, 1, 1, 1, "0086109", 2, 1, 1}
    '            cur_Cliente = Nothing
    '            cur_Sub_Cuenta = Nothing
    '            cur_Nombres_Remitente = Nothing
    '            cur_Direccion_Remitente = Nothing
    '            cur_Telefono_Remitente = Nothing
    '            cur_Nombres_Destinatario = Nothing
    '            cur_Direccion_Destinatario = Nothing
    '            cur_Telefono_Destinatario = Nothing
    '            cur_Documentos_Adjuntos = Nothing

    '            rst_Articulos = Nothing
    '            rst_Control = Nothing
    '            cur_Cliente = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '            'If IsDBNull(cur_Cliente) = False Then
    '            '    flat = False
    '            '    GoTo SALIDA
    '            'End If
    '            ' Seteando valores de Clientes...con cuentas corrientes
    '            If cur_Cliente.State = 1 Then
    '                If cur_Cliente.EOF = False And cur_Cliente.BOF = False Then
    '                    iIDPERSONA = Int(cur_Cliente.Fields.Item(0).Value.ToString())
    '                    sNU_DOCU_SUNAT = cur_Cliente.Fields.Item(1).Value.ToString()
    '                    sRASON_SOCIAL = cur_Cliente.Fields.Item(2).Value.ToString()
    '                    sFECHA_GUIA = cur_Cliente.Fields.Item(3).Value.ToString()
    '                    iIDTipoFacturacion = cur_Cliente.Fields.Item(4).Value.ToString()

    '                    cur_Sub_Cuenta = cur_Cliente.NextRecordset
    '                    cur_Nombres_Remitente = cur_Cliente.NextRecordset
    '                    cur_Direccion_Remitente = cur_Cliente.NextRecordset
    '                    cur_Telefono_Remitente = cur_Cliente.NextRecordset
    '                    cur_Nombres_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Direccion_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Telefono_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Documentos_Adjuntos = cur_Cliente.NextRecordset
    '                    cur_Pagos = cur_Cliente.NextRecordset
    '                    cur_Err = cur_Cliente.NextRecordset
    '                    rst_Articulos = cur_Cliente.NextRecordset
    '                    rst_Control = cur_Cliente.NextRecordset
    '                    cur_control_Centro_Costo = cur_Cliente.NextRecordset
    '                    If cur_control_Centro_Costo.State = 1 Then
    '                        iIDCENTRO_COSTO = Int(cur_control_Centro_Costo.Fields.Item(0).Value.ToString)
    '                    End If
    '                    flat = True
    '                Else
    '                    flat = False
    '                End If
    '            Else
    '                cur_Sub_Cuenta = cur_Cliente.NextRecordset
    '                cur_Nombres_Remitente = cur_Cliente.NextRecordset
    '                cur_Direccion_Remitente = cur_Cliente.NextRecordset
    '                cur_Telefono_Remitente = cur_Cliente.NextRecordset
    '                cur_Nombres_Destinatario = cur_Cliente.NextRecordset
    '                cur_Direccion_Destinatario = cur_Cliente.NextRecordset
    '                cur_Telefono_Destinatario = cur_Cliente.NextRecordset
    '                cur_Documentos_Adjuntos = cur_Cliente.NextRecordset
    '                cur_Pagos = cur_Cliente.NextRecordset
    '                cur_Err = cur_Cliente.NextRecordset
    '                rst_Articulos = cur_Cliente.NextRecordset
    '                rst_Control = cur_Cliente.NextRecordset
    '                If rst_Control.State = 1 Then

    '                    iControl_Guias_Existe = Int(rst_Control.Fields.Item(0).Value.ToString)
    '                    If Int(rst_Control.Fields.Item(0).Value.ToString) = 2 Then
    '                        'MsgBox(rst_Control.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")

    '                    Else
    '                        MsgBox(rst_Control.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")

    '                    End If

    '                End If
    '                flat = False
    '            End If

    'SALIDA:
    '        Catch ex As Exception
    '            flat = False
    '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            objLOG.fnLogErr("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & ex.ToString)
    '        End Try
    '        Return flat
    '    End Function
    Public Function fnCONTROL_GUIAS_ENVIO_DOC() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            ''
            dt_cur_Sub_Cuenta = Nothing
            dt_cur_Sub_Cuenta = New DataTable
            '
            dt_cur_Nombres_Remitente = Nothing
            dt_cur_Nombres_Remitente = New DataTable
            '
            dt_cur_Direccion_Remitente = Nothing
            dt_cur_Direccion_Remitente = New DataTable
            '
            dt_cur_Telefono_Remitente = Nothing
            dt_cur_Telefono_Remitente = New DataTable
            '
            dt_cur_Nombres_Destinatario = Nothing
            dt_cur_Nombres_Destinatario = New DataTable
            '
            dt_cur_Direccion_Destinatario = Nothing
            dt_cur_Direccion_Destinatario = New DataTable
            '
            dt_cur_Telefono_Destinatario = Nothing
            dt_cur_Telefono_Destinatario = New DataTable
            '
            dt_cur_Documentos_Adjuntos = Nothing
            dt_cur_Documentos_Adjuntos = New DataTable
            '
            dt_cur_Pagos = Nothing
            dt_cur_Pagos = New DataTable
            '
            dt_cur_Err = Nothing
            dt_cur_Err = New DataTable
            '
            dt_rst_Articulos = Nothing
            dt_rst_Articulos = New DataTable
            '
            dt_rst_Control = Nothing
            dt_rst_Control = New DataTable
            '
            dt_cur_control_Centro_Costo = Nothing
            dt_cur_control_Centro_Costo = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            'hlamas 03-11-2008
            db_bd.CrearComando("PKG_UTILITARIOS.SP_CONTROL_GUIAS_ENVIO_DOC_II", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iControl_Busqueda, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("x_iIDPERSONA", iIDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNRO_GUIA", sNRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDGUIAS_ENVIO", iIDGUIAS_ENVIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idOrigen", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idDestino", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_Cliente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Sub_Cuenta", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Nombres_Remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Direccion_Remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Telefono_Remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Nombres_Destinatario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Direccion_Destinatario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Telefono_Destinatario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Documentos_Adjuntos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Pagos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_control_Centro_Costo", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet            ' 
            dt_cur_Sub_Cuenta = lds_tmp.Tables(1)
            dt_cur_Nombres_Remitente = lds_tmp.Tables(2)
            dt_cur_Direccion_Remitente = lds_tmp.Tables(3)
            dt_cur_Telefono_Remitente = lds_tmp.Tables(4)
            dt_cur_Nombres_Destinatario = lds_tmp.Tables(5)
            dt_cur_Direccion_Destinatario = lds_tmp.Tables(6)
            dt_cur_Telefono_Destinatario = lds_tmp.Tables(7)
            dt_cur_Documentos_Adjuntos = lds_tmp.Tables(8)
            dt_cur_Pagos = lds_tmp.Tables(9)
            dt_cur_Err = lds_tmp.Tables(10)
            dt_rst_Articulos = lds_tmp.Tables(11)
            dt_rst_Control = lds_tmp.Tables(12)
            dt_cur_control_Centro_Costo = lds_tmp.Tables(13)
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                iIDPERSONA = Int(lds_tmp.Tables(0).Rows(0).Item(0).ToString())
                sNU_DOCU_SUNAT = lds_tmp.Tables(0).Rows(0).Item(1)
                sRASON_SOCIAL = lds_tmp.Tables(0).Rows(0).Item(2)
                sFECHA_GUIA = lds_tmp.Tables(0).Rows(0).Item(3)
                iIDTipoFacturacion = lds_tmp.Tables(0).Rows(0).Item(4)
                '
                If lds_tmp.Tables(13).Rows.Count > 0 Then
                    If IsDBNull(lds_tmp.Tables(13).Rows(0).Item(0)) = False Then
                        iIDCENTRO_COSTO = Int(lds_tmp.Tables(13).Rows(0).Item(0).ToString)
                    Else
                        iIDCENTRO_COSTO = 999  ' Por defecto va hacer generico 
                    End If
                End If
                flat = True
            Else
                If lds_tmp.Tables(12).Rows.Count > 0 Then
                    iControl_Guias_Existe = Int(lds_tmp.Tables(12).Rows(0).Item(0).ToString)
                    If iControl_Guias_Existe <> 2 Then
                        MsgBox(lds_tmp.Tables(12).Rows(0).Item(1).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
                flat = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function Grabar_2009() As Boolean
    '    '
    '    Dim flag As Boolean = False
    '    If dTOTAL_COSTO <= 0 Then
    '        MsgBox("No Puede Realizar esta Operacion, No tiene Monto de Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
    '        Return False
    '    End If
    '    '
    '    Try
    '        'iCONTROL = 1
    '        'iIDGUIAS_ENVIO = 1
    '        'sFECHA_GUIA = "17/01/2007"
    '        'sNRO_GUIA = 1400000
    '        'iIDPERSONA = 824
    '        'iIDTIPO_ENTREGA_CARGA = 1
    '        'iIDFORMA_PAGO = 1
    '        'iIDUNIDAD_AGENCIA = 537
    '        'iIDCIUDAD_TRANSITO = 537
    '        'iIDUNIDAD_AGENCIA_DESTINO = 501
    '        'iIDAGENCIAS = 1

    '        iIDCONTACTO_REMITENTE = IIf(iIDCONTACTO_REMITENTE <= 0, 0, iIDCONTACTO_REMITENTE)
    '        iIDDIRECCION_REMITENTE = IIf(iIDDIRECCION_REMITENTE <= 0, 0, iIDDIRECCION_REMITENTE)
    '        iIDTEFONO_REMITENTE = IIf(iIDTEFONO_REMITENTE <= 0, 0, iIDTEFONO_REMITENTE)
    '        iIDCONTACTO_DESTINATARIO = IIf(iIDCONTACTO_DESTINATARIO <= 0, 0, iIDCONTACTO_DESTINATARIO)
    '        iIDDIRECCION_DESTINATARIO = IIf(iIDDIRECCION_DESTINATARIO <= 0, 0, iIDDIRECCION_DESTINATARIO)
    '        iIDTEFONO_CONSIGNADO = IIf(iIDTEFONO_CONSIGNADO <= 0, 0, iIDTEFONO_CONSIGNADO)

    '        sTelefono_Remitente = IIf(sTelefono_Remitente <> "NULL", sTelefono_Remitente, "@")
    '        sTelefono_Destinatario = IIf(sTelefono_Destinatario <> "NULL", sTelefono_Destinatario, "@")

    '        'sTelefono_Remitente = "@"
    '        'sTelefono_Destinatario = "@"

    '        'dMONTO_BASE = 0
    '        'dTOTAL_PESO = 0
    '        'iCANTIDAD = 0
    '        'dTOTAL_VOLUMEN = 0
    '        'iCANTIDAD_X_UNIDAD_VOLUMEN = 0
    '        'iCANTIDAD_X_UNIDAD_ARTI = 0
    '        'dPRECIO_X_UNIDAD = 0
    '        'dIMPUESTO = 0
    '        'dMONTO_IMPUESTO = 0
    '        'dTOTAL_COSTO = 0
    '        'iIDUSUARIO_PERSONAL = 481
    '        'iIDROL_USUARIO = 1
    '        sIP = dtoUSUARIOS.IP
    '        'iIDESTADO_REGISTRO = 1
    '        Dim flat As Boolean = False

    '        'iNOMBRES_REMITENTE = "@var"
    '        'iDNI_REMITENTE = "@var111"
    '        'iDIRECCION_REMITENTE = "@var3"

    '        'iNOMBRES_DESTINATARIO = "@var4"
    '        'iDNI_DESTINATARIO = "@var5"
    '        'iDIRECCION_DESTINATARIO = "@var6"

    '        iPrecio_x_Peso = iTarifa_Publica_Monto_Peso
    '        iPrecio_x_Volumen = iTarifa_Publica_Monto_Volumen
    '        ' iIDGUIAS_ENVIO()
    '        'sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2
    '        iIDESTADO_REGISTRO = 18 'Para el Control de Administracion de datos y correlativos 
    '        sFECHA_GUIA = Format("MM/DD/YYYY", sFECHA_GUIA)
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO", 86, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2}
    '        iID_REMITENTE = iIDPERSONA
    '        'iREMITENTE = "JUAN PERES"
    '        'iNRODOC_REM = "454545455"
    '        iID_REMITENTE = 0

    '        'iCANTIDAD_SOBRES = 0
    '        'iIDSINO_SOBRES = 0

    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO_II", 98, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1}

    '        'Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_INS_GUIAS_ENVIO_III", 98, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INS_GUIAS_ENVIO_IV", 98, iCONTROL, 1, iIDGUIAS_ENVIO.ToString, 2, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INS_GUIAS_ENVIO_V", 100, iCONTROL, 1, iIDGUIAS_ENVIO.ToString, 2, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1, iIDAGENCIAS_DESTINO, 1}
    '        ' Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INS_GUIAS_ENVIO_VI", 100, iCONTROL, 1, iIDGUIAS_ENVIO.ToString, 2, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA.ToString, 2, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1, iIDAGENCIAS_DESTINO, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INS_GUIAS_ENVIO_VII", 100, iCONTROL, 1, iIDGUIAS_ENVIO.ToString, 2, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA.ToString, 2, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE.ToString(), 2, iIDDIRECCION_REMITENTE.ToString(), 2, iIDTEFONO_REMITENTE.ToString(), 2, iIDCONTACTO_DESTINATARIO.ToString(), 2, iIDDIRECCION_DESTINATARIO.ToString(), 2, iIDTEFONO_CONSIGNADO.ToString(), 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE.ToString(), 2, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1, iIDAGENCIAS_DESTINO, 1}

    '        'hlamas 03-11-2008
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INS_GUIAS_ENVIO_IX", 100, iCONTROL, 1, iIDGUIAS_ENVIO.ToString, 2, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA.ToString, 2, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE.ToString(), 2, iIDDIRECCION_REMITENTE.ToString(), 2, iIDTEFONO_REMITENTE.ToString(), 2, iIDCONTACTO_DESTINATARIO.ToString(), 2, iIDDIRECCION_DESTINATARIO.ToString(), 2, iIDTEFONO_CONSIGNADO.ToString(), 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE.ToString(), 2, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1, iIDAGENCIAS_DESTINO, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INS_GUIAS_ENVIO_X", 102, iCONTROL, 1, iIDGUIAS_ENVIO.ToString, 2, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA.ToString, 2, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE.ToString(), 2, iIDDIRECCION_REMITENTE.ToString(), 2, iIDTEFONO_REMITENTE.ToString(), 2, iIDCONTACTO_DESTINATARIO.ToString(), 2, iIDDIRECCION_DESTINATARIO.ToString(), 2, iIDTEFONO_CONSIGNADO.ToString(), 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE.ToString(), 2, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1, iIDAGENCIAS_DESTINO, 1, iPRECIO_SOBRE, 3}
    '        objLOG.fnLog("[dtoGuiaEnvio.Editar] " & fnLoagObj(varSP_OBJECT))
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO_II", 92, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO_II", 86, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2}
    '        curr_datos_Guia_Envio = Nothing
    '        curr_datos_Guia_Envio = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        Dim cantidad As Integer = varSP_OBJECT.Length
    '        If curr_datos_Guia_Envio.EOF = False And curr_datos_Guia_Envio.BOF = False Then
    '            MsgBox(curr_datos_Guia_Envio.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            If Int(curr_datos_Guia_Envio.Fields.Item(0).Value.ToString) > 0 Then
    '                iIDGUIAS_ENVIO = Int(curr_datos_Guia_Envio.Fields.Item(0).Value.ToString)
    '                cur_codBarras = curr_datos_Guia_Envio.NextRecordset
    '                flag = True
    '                Try
    '                    ObjWebService.fnWebService(3, iIDGUIAS_ENVIO, 18)
    '                Catch ex As Exception
    '                End Try
    '            End If
    '        Else
    '            curr_Error_datos = Nothing
    '            curr_Error_datos = curr_datos_Guia_Envio.NextRecordset
    '            If curr_Error_datos.EOF = False And curr_Error_datos.BOF = False Then
    '                'MsgBox("Nro Error" & curr_datos_Guia_Envio.Fields.Item(0).Value.ToString & "  MSG:" & curr_datos_Guia_Envio.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Segirdad Sistema")
    '                MsgBox("  MSG:" & curr_Error_datos.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Segirdad Sistema")
    '            Else
    '                MsgBox("No se Registro, Revise sus Datos...,error interno", MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        curr_datos_Guia_Envio = curr_datos_Guia_Envio.NextRecordset
    '        If curr_datos_Guia_Envio.EOF = False And curr_datos_Guia_Envio.BOF = False Then
    '            MsgBox("Nro Error" & curr_datos_Guia_Envio.Fields.Item(0).Value.ToString & "  MSG:" & curr_datos_Guia_Envio.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Segirdad Sistema")
    '        End If
    '        flag = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.Grabar] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function Grabar() As Boolean
        '
        Dim flag As Boolean = False
        If dTOTAL_COSTO <= 0 Then
            MsgBox("No Puede Realizar está operación, no tiene monto de operación", MsgBoxStyle.Information, "Seguridad Sistema")
            Return False
        End If
        '
        iIDCONTACTO_REMITENTE = IIf(iIDCONTACTO_REMITENTE <= 0, 0, iIDCONTACTO_REMITENTE)
        iIDDIRECCION_REMITENTE = IIf(iIDDIRECCION_REMITENTE <= 0, 0, iIDDIRECCION_REMITENTE)
        iIDTEFONO_REMITENTE = IIf(iIDTEFONO_REMITENTE <= 0, 0, iIDTEFONO_REMITENTE)
        iIDCONTACTO_DESTINATARIO = IIf(iIDCONTACTO_DESTINATARIO <= 0, 0, iIDCONTACTO_DESTINATARIO)
        iIDDIRECCION_DESTINATARIO = IIf(iIDDIRECCION_DESTINATARIO <= 0, 0, iIDDIRECCION_DESTINATARIO)
        iIDTEFONO_CONSIGNADO = IIf(iIDTEFONO_CONSIGNADO <= 0, 0, iIDTEFONO_CONSIGNADO)
        '
        sTelefono_Remitente = IIf(sTelefono_Remitente <> "NULL", sTelefono_Remitente, "@")
        sTelefono_Destinatario = IIf(sTelefono_Destinatario <> "NULL", sTelefono_Destinatario, "@")
        '
        sIP = dtoUSUARIOS.IP
        '
        Dim flat As Boolean = False
        '
        iPrecio_x_Peso = iTarifa_Publica_Monto_Peso
        iPrecio_x_Volumen = iTarifa_Publica_Monto_Volumen
        ' iIDGUIAS_ENVIO()
        'sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2
        iIDESTADO_REGISTRO = 18 'Para el Control de Administracion de datos y correlativos 
        sFECHA_GUIA = Format("MM/DD/YYYY", sFECHA_GUIA)
        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO", 86, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2}
        iID_REMITENTE = iIDPERSONA
        '
        iID_REMITENTE = 0
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            'hlamas 03-11-2008
            db_bd.CrearComando("PKG_IVOCARGA.SP_INS_GUIAS_ENVIO_IX", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("xiIDGUIAS_ENVIO", iIDGUIAS_ENVIO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("sFECHA_GUIA", sFECHA_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("sNRO_GUIA", sNRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("xiIDPERSONA", iIDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDTIPO_ENTREGA_CARGA", iIDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDFORMA_PAGO", iIDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDCIUDAD_TRANSITO", iIDCIUDAD_TRANSITO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_iIDCONTACTO_REMITENTE", iIDCONTACTO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("x_iIDDIRECCION_REMITENTE", iIDDIRECCION_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("x_iIDTEFONO_REMITENTE", iIDTEFONO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("x_iIDCONTACTO_DESTINATARIO", iIDCONTACTO_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("x_iIDDIRECCION_DESTINATARIO", iIDDIRECCION_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("x_iIDTEFONO_CONSIGNADO", iIDTEFONO_CONSIGNADO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("dMONTO_BASE", dMONTO_BASE, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("dTOTAL_PESO", dTOTAL_PESO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iCANTIDAD", iCANTIDAD, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("dTOTAL_VOLUMEN", dTOTAL_VOLUMEN, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iCANTIDAD_X_UNIDAD_VOLUMEN", iCANTIDAD_X_UNIDAD_VOLUMEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCANTIDAD_X_UNIDAD_ARTI", iCANTIDAD_X_UNIDAD_ARTI, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("dPRECIO_X_UNIDAD", dPRECIO_X_UNIDAD, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("dIMPUESTO", dIMPUESTO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("dMONTO_IMPUESTO", dMONTO_IMPUESTO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("dTOTAL_COSTO", dTOTAL_COSTO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", sIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNOMBRES_REMITENTE", iNOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            'db_bd.AsignarParametro("iDNI_REMITENTE", iIDTEFONO_CONSIGNADO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iDNI_REMITENTE", iDNI_REMITENTE, OracleClient.OracleType.VarChar)

            db_bd.AsignarParametro("iDIRECCION_REMITENTE", iDIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNOMBRES_DESTINATARIO", iNOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iDNI_DESTINATARIO", iDNI_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iDIRECCION_DESTINATARIO", iDIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iPrecio_x_Peso", iPrecio_x_Peso, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iPrecio_x_Volumen", iPrecio_x_Volumen, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iCARGO", iCARGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iTelefono_Remitente", sTelefono_Remitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iTelefono_Destinatario", sTelefono_Destinatario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("x_iID_REMITENTE", iID_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iREMITENTE", iREMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNRODOC_REM", iNRODOC_REM, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDCENTRO_COSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCANTIDAD_SOBRES", iCANTIDAD_SOBRES, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDSINO_SOBRES", iIDSINO_SOBRES, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDAGENCIAS_DESTINO", iIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            '
            '  Observación 
            ' Falta pasar el parámetro de precio por sobre para que quede en la guia de envio 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("curr_datos_Guia_Envio", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 And IsDBNull(lds_tmp.Tables(0).Rows(0).Item(0)) = False Then
                '
                MsgBox(lds_tmp.Tables(0).Rows(0).Item(1).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                '
                If lds_tmp.Tables(0).Rows(0).Item(0) > 0 Then
                    '
                    iIDGUIAS_ENVIO = lds_tmp.Tables(0).Rows(0).Item(0)
                    '
                    dt_cur_codBarras = lds_tmp.Tables(1)
                    flag = True
                    '
                    Try
                        ObjWebService.fnWebService(3, iIDGUIAS_ENVIO, 18)
                    Catch ex As Exception
                    End Try
                    '
                End If
            Else
                If lds_tmp.Tables(1).Rows.Count > 0 Then
                    MsgBox("Msg: " & lds_tmp.Tables(1).Rows(0).Item(1).ToString, MsgBoxStyle.Information, "Segirdad Sistema")
                Else
                    MsgBox("No se registro, revise sus datos...,error interno", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        '
        Return flag
    End Function
    'Public Function Editar_2009() As Boolean
    '    Dim flag As Boolean = False
    '    If dTOTAL_COSTO <= 0 Then
    '        MsgBox("No Puede Realizar esta Operacion, No tiene Monto de Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
    '        Return False
    '    End If
    '    Try
    '        iCONTROL = 2
    '        'iIDGUIAS_ENVIO = 1
    '        'sFECHA_GUIA = "17/01/2007"
    '        'sNRO_GUIA = 1400000
    '        'iIDPERSONA = 824
    '        'iIDTIPO_ENTREGA_CARGA = 1
    '        'iIDFORMA_PAGO = 1
    '        'iIDUNIDAD_AGENCIA = 537
    '        'iIDCIUDAD_TRANSITO = 537
    '        'iIDUNIDAD_AGENCIA_DESTINO = 501
    '        'iIDAGENCIAS = 1
    '        iIDCONTACTO_REMITENTE = IIf(iIDCONTACTO_REMITENTE <= 0, 0, iIDCONTACTO_REMITENTE)
    '        iIDDIRECCION_REMITENTE = IIf(iIDDIRECCION_REMITENTE <= 0, 0, iIDDIRECCION_REMITENTE)
    '        iIDTEFONO_REMITENTE = IIf(iIDTEFONO_REMITENTE <= 0, 0, iIDTEFONO_REMITENTE)
    '        iIDCONTACTO_DESTINATARIO = IIf(iIDCONTACTO_DESTINATARIO <= 0, 0, iIDCONTACTO_DESTINATARIO)
    '        iIDDIRECCION_DESTINATARIO = IIf(iIDDIRECCION_DESTINATARIO <= 0, 0, iIDDIRECCION_DESTINATARIO)
    '        iIDTEFONO_CONSIGNADO = IIf(iIDTEFONO_CONSIGNADO <= 0, 0, iIDTEFONO_CONSIGNADO)
    '        sTelefono_Remitente = IIf(sTelefono_Remitente <> "NULL", sTelefono_Remitente, "@")
    '        sTelefono_Destinatario = IIf(sTelefono_Destinatario <> "NULL", sTelefono_Destinatario, "@")
    '        'sTelefono_Remitente = "@"
    '        'sTelefono_Destinatario = "@"
    '        'dMONTO_BASE = 0
    '        'dTOTAL_PESO = 0
    '        'iCANTIDAD = 0
    '        'dTOTAL_VOLUMEN = 0
    '        'iCANTIDAD_X_UNIDAD_VOLUMEN = 0
    '        'iCANTIDAD_X_UNIDAD_ARTI = 0
    '        'dPRECIO_X_UNIDAD = 0
    '        'dIMPUESTO = 0
    '        'dMONTO_IMPUESTO = 0
    '        'dTOTAL_COSTO = 0
    '        'iIDUSUARIO_PERSONAL = 481
    '        'iIDROL_USUARIO = 1
    '        sIP = dtoUSUARIOS.IP
    '        'iIDESTADO_REGISTRO = 1
    '        Dim flat As Boolean = False
    '        'iNOMBRES_REMITENTE = "@var"
    '        'iDNI_REMITENTE = "@var111"
    '        'iDIRECCION_REMITENTE = "@var3"
    '        'iNOMBRES_DESTINATARIO = "@var4"
    '        'iDNI_DESTINATARIO = "@var5"
    '        'iDIRECCION_DESTINATARIO = "@var6"
    '        iPrecio_x_Peso = iTarifa_Publica_Monto_Peso
    '        iPrecio_x_Volumen = iTarifa_Publica_Monto_Volumen
    '        ' iIDGUIAS_ENVIO()
    '        'sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2
    '        iIDESTADO_REGISTRO = 18 'Para el Control de Administracion de datos y correlativos 
    '        sFECHA_GUIA = Format("MM/DD/YYYY", sFECHA_GUIA)
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO", 86, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2}
    '        iID_REMITENTE = iIDPERSONA
    '        'iREMITENTE = "JUAN PERES"
    '        'iNRODOC_REM = "454545455"
    '        iID_REMITENTE = 0
    '        'iCANTIDAD_SOBRES = 0
    '        'iIDSINO_SOBRES = 0
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO_II", 98, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1}
    '        Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_INS_GUIAS_ENVIO_III", 98, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2, iIDCENTRO_COSTO, 1, iCANTIDAD_SOBRES, 1, iIDSINO_SOBRES, 1}
    '        objLOG.fnLog("[dtoGuiaEnvio.Editar] " & fnLoagObj(varSP_OBJECT))
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO_II", 92, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2, iID_REMITENTE, 1, iREMITENTE, 2, iNRODOC_REM, 2}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INS_GUIAS_ENVIO_II", 86, iCONTROL, 1, iIDGUIAS_ENVIO, 1, sFECHA_GUIA, 2, sNRO_GUIA, 2, iIDPERSONA, 1, iIDTIPO_ENTREGA_CARGA, 1, iIDFORMA_PAGO, 1, iIDUNIDAD_AGENCIA, 1, iIDCIUDAD_TRANSITO, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDAGENCIAS, 1, iIDCONTACTO_REMITENTE, 1, iIDDIRECCION_REMITENTE, 1, iIDTEFONO_REMITENTE, 1, iIDCONTACTO_DESTINATARIO, 1, iIDDIRECCION_DESTINATARIO, 1, iIDTEFONO_CONSIGNADO, 1, dMONTO_BASE, 3, dTOTAL_PESO, 3, iCANTIDAD, 1, dTOTAL_VOLUMEN, 3, iCANTIDAD_X_UNIDAD_VOLUMEN, 1, iCANTIDAD_X_UNIDAD_ARTI, 1, dPRECIO_X_UNIDAD, 3, dIMPUESTO, 3, dMONTO_IMPUESTO, 3, dTOTAL_COSTO, 3, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, sIP, 2, iIDESTADO_REGISTRO, 1, iNOMBRES_REMITENTE, 2, iDNI_REMITENTE, 2, iDIRECCION_REMITENTE, 2, iNOMBRES_DESTINATARIO, 2, iDNI_DESTINATARIO, 2, iDIRECCION_DESTINATARIO, 2, iPrecio_x_Peso, 3, iPrecio_x_Volumen, 3, iCARGO, 1, sTelefono_Remitente, 2, sTelefono_Destinatario, 2}
    '        curr_datos_Guia_Envio = Nothing
    '        curr_datos_Guia_Envio = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        Dim cantidad As Integer = varSP_OBJECT.Length
    '        If curr_datos_Guia_Envio.EOF = False And curr_datos_Guia_Envio.BOF = False Then
    '            MsgBox(curr_datos_Guia_Envio.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            If Int(curr_datos_Guia_Envio.Fields.Item(0).Value.ToString) > 0 Then
    '                iIDGUIAS_ENVIO = Int(curr_datos_Guia_Envio.Fields.Item(0).Value.ToString)
    '                flag = True
    '            End If
    '        Else
    '            curr_Error_datos = Nothing
    '            curr_Error_datos = curr_datos_Guia_Envio.NextRecordset
    '            If curr_Error_datos.EOF = False And curr_Error_datos.BOF = False Then
    '                'MsgBox("Nro Error" & curr_datos_Guia_Envio.Fields.Item(0).Value.ToString & "  MSG:" & curr_datos_Guia_Envio.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Segirdad Sistema")
    '                MsgBox("  MSG:" & curr_Error_datos.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Segirdad Sistema")
    '            Else
    '                MsgBox("No se Registro, Revice sus Datos...,error interno", MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        curr_datos_Guia_Envio = curr_datos_Guia_Envio.NextRecordset
    '        If curr_datos_Guia_Envio.EOF = False And curr_datos_Guia_Envio.BOF = False Then
    '            MsgBox("Nro Error" & curr_datos_Guia_Envio.Fields.Item(0).Value.ToString & "  MSG:" & curr_datos_Guia_Envio.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Segirdad Sistema")
    '        End If
    '        flag = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.Editar] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnLISTA_PERSONAS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_PERSONAS] ")
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_PERSONAS", 2}
    '        rst_Lista_Personas = Nothing
    '        rst_Lista_Personas = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_PERSONAS] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function
    'Public Function fnINSUPD_DOCUMENTOS_GUIAS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INSUPD_DOCUMENTOS_GUIAS", 16, iControl_Documentos, 1, iIDGUIAS_ENVIO, 1, iNro_Serie, 2, iNro_Docu, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INSUPD_DOCUMENTOS_GUIAS", 16, iControl_Documentos, 1, iIDGUIAS_ENVIO.ToString, 2, iNro_Serie, 2, iNro_Docu, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}

    '        objLOG.fnLog("[dtoGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS] " & iControl_Documentos.ToString & "," & iIDGUIAS_ENVIO.ToString & "," & iNro_Serie.ToString & "," & iNro_Docu.ToString)
    '        rst_Lista_Documentos_Guia = Nothing
    '        rst_Lista_Documentos_Guia = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Lista_Documentos_Guia.EOF = False And rst_Lista_Documentos_Guia.BOF = False Then
    '            flat = True
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function
    Public Function fnINSUPD_DOCUMENTOS_GUIAS() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSUPD_DOCUMENTOS_GUIAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl_Documentos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xiIdguias_Envio", iIDGUIAS_ENVIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNro_Serie", iNro_Serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNro_Docu", iNro_Docu, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidusuario_personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flat = True
            Else
                flat = False
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    Public Function fnINSUPD_DOCUMENTOS_GUIAS_I() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSUPD_DOCUMENTOS_GUIAS_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl_Documentos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xiIdguias_Envio", iIDGUIAS_ENVIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNro_Serie", iNro_Serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNro_Docu", iNro_Docu, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidusuario_personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flat = True
            Else
                flat = False
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function


    Public Function Limpiar_Objetos() As Boolean
        Try
            'objLOG.fnLog("[dtoGuiaEnvio.Limpiar_Objetos] ")
            iCONTROL = 0
            iIDGUIAS_ENVIO = 0
            sFECHA_GUIA = ""
            sNRO_GUIA = ""
            sRASON_SOCIAL = ""
            sNU_DOCU_SUNAT = ""
            iIDUNIDAD_AGENCIA = 0
            iIDUNIDAD_AGENCIA_DESTINO = 0
            iIDPERSONA = 0
            iIDAGENCIAS = 0
            iIDDIRECCION_CONSIGNADO = 0
            iIDCONTACTO_PERSONA = 0
            iIDTIPO_ENTREGA_CARGA = 0
            iIDFORMA_PAGO = 0
            iIDTARIFAS_CARGA_CLIENTE = 0
            iIDTARIFAS_CARGA = 0
            sFECHA_DESPACHO = ""
            sFECHA_RECEPCION_DESTINO = ""
            sFECHA_ENTREGA = ""
            sFECHA_CARGOS = ""
            iIDCIUDAD_TRANSITO = 0
            dTOTAL_PESO = 0
            iCANTIDAD = 0
            dTOTAL_VOLUMEN = 0
            dMONTO_BASE = 0
            dPRECIO_X_UNIDAD = 0
            sNOMBRE_RECOJO = ""
            sNOMBRE_ENTREGA = ""
            sDOC_ENTREGA = ""
            sFECHA_RECOJO = ""
            'Public IDARTICULOS              NUMBER(10),
            iIDUSUARIO_PERSONALMOD = 0
            iIDROL_USUARIO = 0
            iIDROL_USUARIOMOD = 0
            sIP = ""
            iIDESTADO_REGISTRO = 0
            sFECHA_REGISTRO = ""
            sFECHA_ACTUALIZACION = ""
            iIDUSUARIO_PERSONAL = 0
            dTOTAL_COSTO = 0
            iIDPREFACTURA = 0
            iIDFACTURA_CREDITO = 0
            iIDUSUARIO_REVISION = 0
            iIDROL_REVISION = 0
            sFECHA_REVISION = ""
            sSERIE_GUIA_ENVIO = ""
            iIDIMPUESTO = 0
            dIMPUESTO = 0
            iIDDIRECCION_REMITENTE = 0
            iNRO_DOC_REMITENTE = ""
            iNRO_DOC_DESTINATARIO = ""
            iIDCONTACTO_DESTINATARIO = 0

            iIDDIRECCION_DESTINATARIO = 0
            iIDCONTACTO_REMITENTE = 0

            iCANTIDAD_X_UNIDAD_VOLUMEN = 0
            iCANTIDAD_X_UNIDAD_ARTI = 0
            dMONTO_IMPUESTO = 0
            iIDTEFONO_REMITENTE = 0
            iIDTEFONO_CONSIGNADO = 0

            iTarifa_Publica_Monto_Base = 0
            iTarifa_Publica_Monto_Peso = 0
            iTarifa_Publica_Monto_Volumen = 0

            iNOMBRES_REMITENTE = ""
            iDNI_REMITENTE = ""
            iDIRECCION_REMITENTE = ""

            iNOMBRES_DESTINATARIO = ""
            iDNI_DESTINATARIO = ""
            iDIRECCION_DESTINATARIO = ""

            iCANTIDAD_SOBRES = 0
            iIDSINO_SOBRES = 0

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            'objLOG.fnLogErr("[dtoGuiaEnvio.Limpiar_Objetos] " & ex.ToString)
        End Try
    End Function
    'Public Function fnLISTA_AGENCIA_USUARIOS_2009()
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_AGENCIA_USUARIOS] " & iCONTROL.ToString & "," & dtoUSUARIOS.m_iIdAgencia.ToString)
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_AGENCIA_USUARIOS", 8, iCONTROL, 1, dtoUSUARIOS.m_iIdAgencia, 1, 21, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_AGENCIA_USUARIOS", 8, 1, 1, 1, 1, 21, 1}
    '        rst_Lista_Usuarios = Nothing
    '        rst_Lista_Unidades = Nothing

    '        rst_Lista_Usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Lista_Usuarios.EOF = False And rst_Lista_Usuarios.BOF = False Then
    '            rst_Lista_Unidades = rst_Lista_Usuarios.NextRecordset
    '            flag = True
    '        Else
    '            flag = False
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_AGENCIA_USUARIOS] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnLISTA_TARIFA_CLIENTE_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_TARIFA_PERSONA", 8, sNU_DOCU_SUNAT, 2, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_TARIFA_PERSONA_II", 8, sNU_DOCU_SUNAT, 2, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_TARIFA_PERSONA_III", 10, sNU_DOCU_SUNAT, 2, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDCENTRO_COSTO, 1}
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_TARIFA_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & iIDUNIDAD_AGENCIA.ToString & "," & iIDUNIDAD_AGENCIA_DESTINO.ToString)

    '        rst_Tarifa_Cliente_Carga = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Tarifa_Cliente_Carga.EOF = False And rst_Tarifa_Cliente_Carga.BOF = False Then
    '            'A.CG_MONTO_BASE,A.CG_X_PESO,A.CG_X_VOLUMEN,
    '            iTarifa_Publica_Monto_Base = Format(rst_Tarifa_Cliente_Carga.Fields.Item(1).Value, "##,###.00")
    '            iTarifa_Publica_Monto_Peso = Format(rst_Tarifa_Cliente_Carga.Fields.Item(2).Value, "##,###.00")
    '            iTarifa_Publica_Monto_Volumen = Format(rst_Tarifa_Cliente_Carga.Fields.Item(3).Value, "##,###.00")
    '            '19/03/2008 - Se a modificado la línea de abajo 
    '            iTarifa_Publica_Monto_Base_Xpostal = Format(rst_Tarifa_Cliente_Carga.Fields.Item(7).Value, "##,###.00")
    '            'iTarifa_Publica_Monto_Base_Xpostal = Format(rst_Tarifa_Publica_Carga.Fields.Item("PO_MONTO_BASE").Value, "##,###.00")
    '            '
    '            'iTarifa_Publica_Monto_Sobre = Format(rst_Tarifa_Cliente_Carga.Fields.Item("CG_X_SOBRE").Value, "##,###.00")
    '            'dPRECIO_X_UNIDAD = Format(rst_Tarifa_Cliente_Carga.Fields.Item("CG_X_SOBRE").Value, "##,###.00")
    '            iTarifa_Publica_Monto_Sobre = Format(IIf(IsDBNull(rst_Tarifa_Cliente_Carga.Fields.Item("CG_X_SOBRE").Value), 0, rst_Tarifa_Cliente_Carga.Fields.Item("CG_X_SOBRE").Value), "##,###.00")
    '            dPRECIO_X_UNIDAD = Format(IIf(IsDBNull(rst_Tarifa_Cliente_Carga.Fields.Item("CG_X_SOBRE").Value), 0, rst_Tarifa_Cliente_Carga.Fields.Item("CG_X_SOBRE").Value), "##,###.00")
    '            '--
    '            'Modificado 02/01/2008 - No se considera esto. 
    '            '--
    '            'If iTarifa_Publica_Monto_Base_Xpostal <= 0 Then
    '            '    iTarifa_Publica_Monto_Base_Xpostal = Format(iTarifa_Publica_Monto_Base, "##,###.00")
    '            'End If

    '            iTarifa = rst_Tarifa_Cliente_Carga.Fields.Item("tarifa").Value

    '            curr_Cond_Pagos = Nothing
    '            curr_Cond_Pagos = rst_Tarifa_Cliente_Carga.NextRecordset

    '            iPeso_Minimo = 0
    '            iPeso_Maximo = 0
    '            iPrecio_cond_Peso = 0

    '            iVol_Minimo = 0
    '            iVol_Maximo = 0
    '            iPrecio_cond_Vol = 0

    '            If curr_Cond_Pagos.State = 1 Then
    '                While curr_Cond_Pagos.EOF = False And curr_Cond_Pagos.BOF = False
    '                    If curr_Cond_Pagos.Fields.Item("UNIDAD").Value = "PESO" Then
    '                        iPeso_Minimo = curr_Cond_Pagos.Fields.Item("INICIO").Value
    '                        iPeso_Maximo = curr_Cond_Pagos.Fields.Item("FIN").Value
    '                        iPrecio_cond_Peso = curr_Cond_Pagos.Fields.Item("PRECIO_FINAL").Value
    '                    End If
    '                    If curr_Cond_Pagos.Fields.Item("UNIDAD").Value = "VOLUMEN" Then
    '                        iVol_Minimo = curr_Cond_Pagos.Fields.Item("INICIO").Value
    '                        iVol_Maximo = curr_Cond_Pagos.Fields.Item("FIN").Value
    '                        iPrecio_cond_Vol = curr_Cond_Pagos.Fields.Item("PRECIO_FINAL").Value
    '                    End If
    '                    curr_Cond_Pagos.MoveNext()
    '                End While
    '            End If

    '            flag = True
    '        Else
    '            flag = False
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_TARIFA_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLISTA_TARIFA_CLIENTE() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ''db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PERSONA_III", CommandType.StoredProcedure) 'Comentado por Diego Zegarra T.
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PER_VC", CommandType.StoredProcedure)   'Nueva Tarifa 2013
            db_bd.AsignarParametro("iIDPROCESO", iIPRODUCTO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_ORIGEN", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNu_Docu_Suna", sNU_DOCU_SUNAT, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDCENTROCOSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPOTARIFA", TipoTarifa_, OracleClient.OracleType.Int32)

            'Variables de salidas 
            db_bd.AsignarParametro("curr_Tarifario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_SubCuentaDestino", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_SubcuentaOrigen", OracleClient.OracleType.Cursor)
            ' db_bd.AsignarParametro("curr_Tarifario_config", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet

            dt_cur_Sub_Cuenta = lds_tmp.Tables(2) '-->Carga la subCuenta Origen
            dt_cur_Sub_Cuenta_Destino = lds_tmp.Tables(1) '-->Carga la subCuenta Destino



            If lds_tmp.Tables(0).Rows.Count > 0 Then
                'If TarifaBox_ = True Then
                '    iTarifa_Publica_Monto_Base = 0
                '    iTarifa_Publica_Monto_Peso = Format(lds_tmp.Tables(0).Rows(0).Item(13), "##,###.00")
                '    iTarifa_Publica_Monto_Volumen = Format(lds_tmp.Tables(0).Rows(0).Item(14), "##,###.00")
                '    iTarifa_Publica_Monto_Base_Xpostal = 0
                '    iTarifa_Publica_Monto_Sobre = 0
                '    dPRECIO_X_UNIDAD = 0
                'Else
                Dim rowTc As DataRow
                rowTc = lds_tmp.Tables(0).Rows(0)
                iTarifa_Publica_Monto_Base = IIf(IsDBNull(rowTc("N_BASE")), 0, rowTc("N_BASE"))
                iTarifa_Publica_Monto_Peso = IIf(IsDBNull(rowTc("N_PESO")), 0, rowTc("N_PESO"))
                iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(rowTc("N_VOLUMEN")), 0, rowTc("N_VOLUMEN"))
                iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(rowTc("N_SOBRE")), 0, rowTc("N_SOBRE"))
                iTarifa_Publica_Monto_Sobre = IIf(IsDBNull(rowTc("N_SOBRE")), 0, rowTc("N_SOBRE"))
                dPRECIO_X_UNIDAD = IIf(IsDBNull(rowTc("N_SOBRE")), 0, rowTc("N_SOBRE"))


                'iTarifa_Publica_Monto_Base = Format(lds_tmp.Tables(0).Rows(0).Item(1), "##,###.00")
                'iTarifa_Publica_Monto_Peso = Format(lds_tmp.Tables(0).Rows(0).Item(2), "##,###.00")
                'iTarifa_Publica_Monto_Volumen = Format(lds_tmp.Tables(0).Rows(0).Item(3), "##,###.00")
                'iTarifa_Publica_Monto_Base_Xpostal = Format(lds_tmp.Tables(0).Rows(0).Item(7), "##,###.00")
                '' iTarifa_Publica_Monto_Sobre = Format(IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), "##,###.00")
                '' dPRECIO_X_UNIDAD = Format(IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")))
                'iTarifa_Publica_Monto_Sobre = Format(IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), "##,###.00")
                'dPRECIO_X_UNIDAD = Format(IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")))
                'End If
                'iTarifa = lds_tmp.Tables(0).Rows(0).Item("tarifa")

                'hlamas 09-05-2015
                Try
                    iPeso_Minimo = 0
                    iPeso_Maximo = IIf(IsDBNull(rowTc("PESO_MINIMO")), 0, rowTc("PESO_MINIMO"))
                    iPrecio_cond_Peso = IIf(IsDBNull(rowTc("PESO_MINIMO_FLETE")), 0, rowTc("PESO_MINIMO_FLETE"))
                    iVol_Minimo = 0
                    iVol_Maximo = IIf(IsDBNull(rowTc("VOLUMEN_MINIMO")), 0, rowTc("VOLUMEN_MINIMO"))
                    iPrecio_cond_Vol = IIf(IsDBNull(rowTc("VOLUMEN_MINIMO_FLETE")), 0, rowTc("VOLUMEN_MINIMO_FLETE"))
                Catch
                    iPeso_Minimo = 0 : iPeso_Maximo = 0 : iPrecio_cond_Peso = 0 : iVol_Minimo = 0 : iVol_Maximo = 0 : iPrecio_cond_Vol = 0
                End Try

                'If lds_tmp.Tables(1).Rows.Count > 0 Then

                '    'Debe hacer un for para que haga un tipo de "by-pass" y se quede con el último precio,como el último precio indicado   
                '    If lds_tmp.Tables(1).Rows(0).Item("UNIDAD") = "PESO" Then
                '        iPeso_Minimo = lds_tmp.Tables(1).Rows(0).Item("INICIO")
                '        iPeso_Maximo = lds_tmp.Tables(1).Rows(0).Item("FIN")
                '        iPrecio_cond_Peso = lds_tmp.Tables(1).Rows(0).Item("PRECIO_FINAL")
                '    End If
                '    If lds_tmp.Tables(1).Rows(0).Item("UNIDAD") = "VOLUMEN" Then
                '        iVol_Minimo = lds_tmp.Tables(1).Rows(0).Item("INICIO")
                '        iVol_Maximo = lds_tmp.Tables(1).Rows(0).Item("FIN")
                '        iPrecio_cond_Vol = lds_tmp.Tables(1).Rows(0).Item("PRECIO_FINAL")
                '    End If
                'End If
                If iTipo = 2 And iIPRODUCTO = 8 Then
                    intTarifaPersonalizada = rowTc("opcion")
                    If intTarifaPersonalizada = 0 Then
                        flag = False
                    Else
                        flag = True
                    End If
                Else
                    flag = True
                End If
            Else
                flag = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    'Public Function fnTARIFA_PUBLICA_CARGA_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        iTarifa_Publica_Monto_Base = 0.0
    '        iTarifa_Publica_Monto_Peso = 0.0
    '        iTarifa_Publica_Monto_Volumen = 0.0
    '        objLOG.fnLog("[dtoGuiaEnvio.fnTARIFA_PUBLICA_CARGA] " & iIDUNIDAD_AGENCIA.ToString & "," & iIDUNIDAD_AGENCIA_DESTINO.ToString)
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA", 6, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA2", 6, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1}
    '        '-- Modificado 29/12/2008 - Se le agrega el campo sNU_DOCU_SUNAT (Codigo Cliente) 
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", 8, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, sNU_DOCU_SUNAT, 2}

    '        rst_Tarifa_Publica_Carga = Nothing
    '        rst_Tarifa_Publica_Carga = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If rst_Tarifa_Publica_Carga.EOF = False And rst_Tarifa_Publica_Carga.BOF = False Then
    '            If Int(rst_Tarifa_Publica_Carga.Fields.Item(0).Value.ToString) > 0 Then
    '                iTarifa_Publica_Monto_Base = rst_Tarifa_Publica_Carga.Fields.Item(4).Value
    '                iTarifa_Publica_Monto_Peso = rst_Tarifa_Publica_Carga.Fields.Item(5).Value
    '                iTarifa_Publica_Monto_Volumen = rst_Tarifa_Publica_Carga.Fields.Item(6).Value
    '                iTarifa_Publica_Monto_Base_Xpostal = rst_Tarifa_Publica_Carga.Fields.Item(10).Value
    '                dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
    '                ' 
    '                'Modificado - 02/01/2008 - 
    '                '
    '                'If iTarifa_Publica_Monto_Base_Xpostal <= 0 Then
    '                '    iTarifa_Publica_Monto_Base_Xpostal = iTarifa_Publica_Monto_Base
    '                'End If
    '                flat = True
    '            Else
    '                flat = False
    '            End If
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnTARIFA_PUBLICA_CARGA] " & ex.ToString)
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnTARIFA_PUBLICA_CARGA() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_codigo_cliente", sNU_DOCU_SUNAT, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                '
                If CType(lds_tmp.Tables(0).Rows(0)(0), Long) > 0 Then
                    iTarifa_Publica_Monto_Base = lds_tmp.Tables(0).Rows(0)(4)
                    iTarifa_Publica_Monto_Peso = lds_tmp.Tables(0).Rows(0)(5)
                    iTarifa_Publica_Monto_Volumen = lds_tmp.Tables(0).Rows(0)(6)
                    iTarifa_Publica_Monto_Base_Xpostal = lds_tmp.Tables(0).Rows(0)(10)
                    dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
                    flat = True
                Else
                    flat = False
                End If
            Else
                flat = False
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnCONTROL_GUIAS_ENVIO_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        'cur_Lista_guias_Envio = Nothing
    '        'cur_Lista_guias_Envio = New ADODB.Recordset

    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO", 24, idCONTROL_GUIAS, 1, iCONTROL_Nro_Guia, 2, iCONTROLIdagencias, 1, iCONTROLIdunidad_Origen, 1, iCONTROLIdunidad_Destino, 1, iCONTROLIdpersona, 1, iCONTROL_Nro_RUC_RASON_SOCIAl, 2, iCONTROLFecha_Inicio, 2, iCONTROLFecha_Final, 2, iCONTROLIdrol_Usuariol, 1, iCONTROLIdIdestado_Registro, 1}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO", 24, 3, 1, "100009", 2, iCONTROLIdagencias, 1, iCONTROLIdunidad_Origen, 1, iCONTROLIdunidad_Destino, 1, iCONTROLIdpersona, 1, iCONTROL_Nro_RUC_RASON_SOCIAl, 2, iCONTROLFecha_Inicio, 2, iCONTROLFecha_Final, 2, iCONTROLIdrol_Usuariol, 1, iCONTROLIdIdestado_Registro, 1}
    '        cur_Lista_guias_Envio = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        objLOG.fnLog("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO] " & iCONTROL_Nro_Guia.ToString & "," & iCONTROLIdagencias.ToString & "," & iCONTROLIdunidad_Origen.ToString & "," & iCONTROLIdunidad_Destino.ToString & "," & iCONTROLIdpersona.ToString & "," & iCONTROL_Nro_RUC_RASON_SOCIAl.ToString & "," & iCONTROLFecha_Inicio.ToString & "," & iCONTROLFecha_Final.ToString & "," & iCONTROLIdrol_Usuariol.ToString & "," & iCONTROLIdIdestado_Registro.ToString)
    '        'If cur_Lista_guias_Envio.BOF = False And cur_Lista_guias_Envio.EOF = False Then
    '        If True Then
    '            '   var = Nothing
    '            'rst.MoveFirst()
    '            'MsgBox(cur_Lista_guias_Envio.Fields.Item(0).Value.ToString)
    '            '  MsgBox(cur_Lista_guias_Envio.RecordCount)
    '            flag = True
    '        Else
    '            MsgBox("No existe Resultados Para esta Busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function fnCONTROL_GUIAS_ENVIO() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("idCONTROL", idCONTROL_GUIAS, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iNro_Guia", iCONTROL_Nro_Guia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIdagencias", iCONTROLIdagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIdunidad_Origen", iCONTROLIdunidad_Origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIdunidad_Destino", iCONTROLIdunidad_Destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIdpersona", iCONTROLIdpersona, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIRuc_Rason_Social", iCONTROL_Nro_RUC_RASON_SOCIAl, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFecha_Inicio", iCONTROLFecha_Inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFecha_Final", iCONTROLFecha_Final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIdrol_Usuariol", iCONTROLIdrol_Usuariol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIdestado_Registro", iCONTROLIdIdestado_Registro, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Lista_guias_Envio", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            If ldt_tmp.Rows.Count > 0 Then
                dt_cur_Lista_guias_Envio = ldt_tmp
                flag = True
            Else
                flag = False
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnFILTRO_USUARIO_X_AGENCIA_2009(ByVal idAgencia As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_FILTRO_USUARIO_X_AGENCIA", 4, idAgencia, 1}
    '        rst_Lista_Usuarios = Nothing
    '        rst_Lista_Usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        objLOG.fnLog("[dtoGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA] " & idAgencia.ToString)
    '        If rst_Lista_Usuarios.EOF = False And rst_Lista_Usuarios.EOF = False Then
    '            flag = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA] " & ex.ToString)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnFILTRO_USUARIO_X_AGENCIA(ByVal idAgencia As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            'acceso 21/04/2010
            'db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_FILTRO_USUARIO_X_AGENCIA", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_FILTRO_USUARIO_X_AGENCIA_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("idAgencia", idAgencia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            dt_Lista_Usuarios = ldt_tmp
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnANULAR_GUIA_ENVIO_2009(ByVal idGuia As Integer, ByVal iEstado As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnANULAR_GUIA_ENVIO] " & idGuia.ToString & iEstado.ToString)
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_ANULAR_GUIA_ENVIO", 12, idGuia, 1, iEstado, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IP, 2}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_ANULAR_GUIA_ENVIO", 12, idGuia.ToString, 2, iEstado, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IP, 2}
    '        rst = Nothing
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst.EOF = False And rst.EOF = False Then
    '            flag = True
    '        End If
    '        rst = Nothing
    '    Catch ex As Exception
    '        MsgBox("OPERACION CANCELADA..., CONSULTE CON SISTEMAS", MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnANULAR_GUIA_ENVIO] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function

    Public Function fnANULAR_GUIA_ENVIO(ByVal idGuia As Integer, ByVal iEstado As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_ANULAR_GUIA_ENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("xiIdguias_Envio", idGuia.ToString, OracleClient.OracleType.VarChar)

            db_bd.AsignarParametro("iIdestado_Registro", iEstado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIdusuario_Personalmod", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIdrol_Usuariomod", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIpmod", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If IsDBNull(ldt_tmp.Rows(0)(0)) = True Then
                flag = False
            Else
                flag = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnLISTA_AGENCIAS_UNIDADES_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_AGENCIAS_UNIDADES] ")
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_LISTA_AGENCIAS_UNIDADES", 2}
    '        rst_Lista_Unidades_Agencia = Nothing
    '        rst_Lista_Unidades_Agencia = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Lista_Unidades_Agencia.EOF = False And rst_Lista_Unidades_Agencia.EOF = False Then
    '            flag = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_AGENCIAS_UNIDADES] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLISTA_AGENCIAS_UNIDADES() As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOUUTILS.SP_LISTA_AGENCIAS_UNIDADES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_LISTA_AGENCIAS_UNIDADES", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dt_Lista_Unidades_Agencia = ldt_tmp
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnLISTA_ORIGEN_DESTINO_2009()
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_ORIGEN_DESTINO] ")
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_ORIGEN_DESTINO", 2}
    '        cur_Origen = Nothing
    '        cur_Destino = Nothing
    '        cur_Origen = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        cur_Destino = cur_Origen.NextRecordset
    '        flag = True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_ORIGEN_DESTINO] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLISTA_ORIGEN_DESTINO()
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_LISTA_ORIGEN_DESTINO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Origen", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            dt_cur_Origen = lds_tmp.Tables(0)
            dt_cur_Destino = lds_tmp.Tables(1)
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

#End Region
#Region "MODIFICACION GUIA ENVIO"

    'Public cur_edtguia_envio As New ADODB.Recordset
    'Public cur_edtguia_documentos As New ADODB.Recordset
    'Public cur_edtguia_articulos As New ADODB.Recordset
    'Public Function fnEDIT_GUIAS_EMVIO_2009()
    '    Dim flag As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_EDIT_GUIAS_EMVIO", 4, iIDGUIAS_ENVIO, 1}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_EDIT_GUIAS_EMVIOII", 4, iIDGUIAS_ENVIO.ToString, 2}
    '        '
    '        objLOG.fnLog("[dtoGuiaEnvio.fnEDIT_GUIAS_EMVIO] " & iIDGUIAS_ENVIO.ToString)
    '        '
    '        cur_edtguia_envio = Nothing
    '        cur_edtguia_documentos = Nothing
    '        cur_edtguia_articulos = Nothing
    '        cur_edtguia_envio = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_edtguia_envio.State = 1 Then
    '            sFECHA_GUIA = cur_edtguia_envio.Fields.Item("fecha_guia").Value
    '            sNRO_GUIA = cur_edtguia_envio.Fields.Item("nro_guia").Value
    '            sRASON_SOCIAL = cur_edtguia_envio.Fields.Item("Razon_Social").Value
    '            sNU_DOCU_SUNAT = cur_edtguia_envio.Fields.Item("Nu_Docu_Suna").Value
    '            iNOMBRE_UNIDAD_ORIGEN = cur_edtguia_envio.Fields.Item("Unidad_Origen").Value
    '            iNOMBRE_UNIDAD_DESTINO = cur_edtguia_envio.Fields.Item("Unidad_Destino").Value
    '            iIDUNIDAD_AGENCIA = cur_edtguia_envio.Fields.Item("Idunidad_Agencia").Value
    '            iIDUNIDAD_AGENCIA_DESTINO = cur_edtguia_envio.Fields.Item("idunidad_agencia_destino").Value
    '            iIDPERSONA = cur_edtguia_envio.Fields.Item("idpersona").Value
    '            iIDAGENCIAS = cur_edtguia_envio.Fields.Item("idagencias").Value
    '            iIDTIPO_ENTREGA_CARGA = cur_edtguia_envio.Fields.Item("idtipo_entrega_carga").Value
    '            iIDFORMA_PAGO = cur_edtguia_envio.Fields.Item("Idforma_Pago").Value
    '            iIDTARIFAS_CARGA_CLIENTE = cur_edtguia_envio.Fields.Item("idtarifas_carga_cliente").Value
    '            iIDTARIFAS_CARGA = cur_edtguia_envio.Fields.Item("idtarifas_carga").Value
    '            iIDCIUDAD_TRANSITO = cur_edtguia_envio.Fields.Item("idciudad_transito").Value
    '            iIDCONTACTO_REMITENTE = cur_edtguia_envio.Fields.Item("id_remitente").Value
    '            iIDCONTACTO_PERSONA = cur_edtguia_envio.Fields.Item("idcontacto_remitente").Value
    '            iIDDIRECCION_REMITENTE = cur_edtguia_envio.Fields.Item("iddireccion_remitente").Value
    '            iIDTEFONO_REMITENTE = cur_edtguia_envio.Fields.Item("idtefono_remitente").Value
    '            iIDCONTACTO_DESTINATARIO = cur_edtguia_envio.Fields.Item("idcontacto_remitente").Value
    '            iIDDIRECCION_DESTINATARIO = cur_edtguia_envio.Fields.Item("iddireccion_destinatario").Value
    '            iIDTEFONO_CONSIGNADO = cur_edtguia_envio.Fields.Item("idtefono_consignado").Value
    '            iPrecio_x_Peso = cur_edtguia_envio.Fields.Item("precio_x_peso").Value
    '            iPrecio_x_Volumen = cur_edtguia_envio.Fields.Item("precio_x_volumen").Value
    '            dPRECIO_X_UNIDAD = cur_edtguia_envio.Fields.Item("precio_x_unidad").Value
    '            iCARGO = cur_edtguia_envio.Fields.Item("cargo").Value
    '            dMONTO_BASE = cur_edtguia_envio.Fields.Item("monto_base").Value
    '            dTOTAL_COSTO = cur_edtguia_envio.Fields.Item("total_costo").Value
    '            dMONTO_IMPUESTO = cur_edtguia_envio.Fields.Item("monto_impuesto").Value
    '            dTOTAL_PESO = cur_edtguia_envio.Fields.Item("total_peso").Value
    '            dTOTAL_VOLUMEN = cur_edtguia_envio.Fields.Item("total_volumen").Value
    '            iCANTIDAD = cur_edtguia_envio.Fields.Item("cantidad").Value
    '            iCANTIDAD_X_UNIDAD_VOLUMEN = cur_edtguia_envio.Fields.Item("Cantidad_x_Unidad_Volumen").Value
    '            iCANTIDAD_X_UNIDAD_ARTI = cur_edtguia_envio.Fields.Item("Cantidad_x_Unidad_Arti").Value
    '            iNOMBRES_REMITENTE = cur_edtguia_envio.Fields.Item("cont_Remitente").Value
    '            iDNI_REMITENTE = cur_edtguia_envio.Fields.Item("cont_DNI_Remitente").Value
    '            iDIRECCION_REMITENTE = cur_edtguia_envio.Fields.Item("dir_Remitente").Value
    '            iNOMBRES_DESTINATARIO = cur_edtguia_envio.Fields.Item("cont_Destinatario").Value
    '            iDNI_DESTINATARIO = cur_edtguia_envio.Fields.Item("cont_DNI_Destinatario").Value
    '            iDIRECCION_DESTINATARIO = cur_edtguia_envio.Fields.Item("dir_Destinatario").Value
    '            iID_REMITENTE = cur_edtguia_envio.Fields.Item("id_remitente").Value
    '            iREMITENTE = cur_edtguia_envio.Fields.Item("cliente_remitente").Value
    '            iNRODOC_REM = cur_edtguia_envio.Fields.Item("nro_Cliente_Remitente").Value
    '            sTelefono_Remitente = cur_edtguia_envio.Fields.Item("tel_remitente").Value
    '            sTelefono_Destinatario = cur_edtguia_envio.Fields.Item("tel_destinatario").Value
    '            iCANTIDAD_SOBRES = cur_edtguia_envio.Fields.Item("CANTIDAD_SOBRES").Value
    '            iIDSINO_SOBRES = cur_edtguia_envio.Fields.Item("IDSINO_SOBRES").Value
    '            iIDCENTRO_COSTO = cur_edtguia_envio.Fields.Item("idCentro_Costo").Value
    '            iIDAGENCIAS_DESTINO = cur_edtguia_envio.Fields.Item("idagencias_destino").Value
    '        End If
    '        cur_edtguia_documentos = cur_edtguia_envio.NextRecordset
    '        cur_edtguia_articulos = cur_edtguia_envio.NextRecordset
    '        cur_Sub_Cuenta = cur_edtguia_envio.NextRecordset
    '        flag = True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnEDIT_GUIAS_EMVIO] " & ex.ToString)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnEDIT_GUIAS_EMVIO()
        '
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_EDIT_GUIAS_EMVIOII", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("xiidguias_envio", iIDGUIAS_ENVIO.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_guia_envio", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_guia_documentos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_guia_articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_centro_costo", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                sFECHA_GUIA = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("fecha_guia")) = True, "", lds_tmp.Tables(0).Rows(0).Item("fecha_guia"))
                sNRO_GUIA = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("nro_guia")) = True, "", lds_tmp.Tables(0).Rows(0).Item("nro_guia"))
                sRASON_SOCIAL = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Razon_Social")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Razon_Social"))
                sNU_DOCU_SUNAT = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna"))
                iNOMBRE_UNIDAD_ORIGEN = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Unidad_Origen")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Unidad_Origen"))
                iNOMBRE_UNIDAD_DESTINO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Unidad_Destino")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Unidad_Destino"))
                iIDUNIDAD_AGENCIA = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Idunidad_Agencia")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("Idunidad_Agencia"))
                iIDUNIDAD_AGENCIA_DESTINO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idunidad_agencia_destino")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idunidad_agencia_destino"))
                iIDPERSONA = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idpersona")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idpersona"))
                iIDAGENCIAS = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idagencias")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idagencias"))
                iIDTIPO_ENTREGA_CARGA = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idtipo_entrega_carga")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idtipo_entrega_carga"))
                iIDFORMA_PAGO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Idforma_Pago")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("Idforma_Pago"))
                iIDTARIFAS_CARGA_CLIENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idtarifas_carga_cliente")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idtarifas_carga_cliente"))
                iIDTARIFAS_CARGA = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idtarifas_carga")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idtarifas_carga"))
                iIDCIUDAD_TRANSITO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idciudad_transito")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idciudad_transito"))
                iIDCONTACTO_REMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("id_remitente")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("id_remitente"))
                iIDCONTACTO_PERSONA = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idcontacto_remitente")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idcontacto_remitente"))
                iIDDIRECCION_REMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("iddireccion_remitente")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("iddireccion_remitente"))
                iIDTEFONO_REMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idtefono_remitente")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idtefono_remitente"))
                iIDCONTACTO_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idcontacto_destinatario")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idcontacto_destinatario")) ' Estaba como idcontacto_remitente
                iIDDIRECCION_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("iddireccion_destinatario")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("iddireccion_destinatario"))
                iIDTEFONO_CONSIGNADO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idtefono_consignado")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idtefono_consignado"))
                iPrecio_x_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("precio_x_peso")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("precio_x_peso"))
                iPrecio_x_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("precio_x_volumen")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("precio_x_volumen"))
                dPRECIO_X_UNIDAD = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("precio_x_unidad")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("precio_x_unidad"))
                iCARGO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("precio_x_unidad")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("cargo"))
                dMONTO_BASE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("monto_base")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("monto_base"))
                dTOTAL_COSTO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("total_costo")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("total_costo"))
                dMONTO_IMPUESTO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("monto_impuesto")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("monto_impuesto"))
                dTOTAL_PESO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("total_peso")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("total_peso"))
                dTOTAL_VOLUMEN = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("total_volumen")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("total_volumen"))
                iCANTIDAD = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cantidad")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("cantidad"))
                iCANTIDAD_X_UNIDAD_VOLUMEN = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Unidad_Volumen")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Unidad_Volumen"))
                iCANTIDAD_X_UNIDAD_ARTI = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Unidad_Arti")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Unidad_Arti"))
                iNOMBRES_REMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cont_Remitente")) = True, "", lds_tmp.Tables(0).Rows(0).Item("cont_Remitente"))
                iDNI_REMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cont_DNI_Remitente")) = True, "", lds_tmp.Tables(0).Rows(0).Item("cont_DNI_Remitente"))
                iDIRECCION_REMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("dir_Remitente")) = True, "", lds_tmp.Tables(0).Rows(0).Item("dir_Remitente"))
                iNOMBRES_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cont_Destinatario")) = True, "", lds_tmp.Tables(0).Rows(0).Item("cont_Destinatario"))
                iDNI_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cont_DNI_Destinatario")) = True, "", lds_tmp.Tables(0).Rows(0).Item("cont_DNI_Destinatario"))
                iDIRECCION_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("dir_Destinatario")) = True, "", lds_tmp.Tables(0).Rows(0).Item("dir_Destinatario"))
                iID_REMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("id_remitente")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("id_remitente"))
                iREMITENTE = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cliente_remitente")) = True, "", lds_tmp.Tables(0).Rows(0).Item("cliente_remitente"))
                iNRODOC_REM = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("nro_Cliente_Remitente")) = True, "", lds_tmp.Tables(0).Rows(0).Item("nro_Cliente_Remitente"))
                sTelefono_Remitente = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("tel_remitente")) = True, "", lds_tmp.Tables(0).Rows(0).Item("tel_remitente"))
                sTelefono_Destinatario = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("tel_destinatario")) = True, "", lds_tmp.Tables(0).Rows(0).Item("tel_destinatario"))
                iCANTIDAD_SOBRES = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CANTIDAD_SOBRES")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("CANTIDAD_SOBRES"))
                iIDSINO_SOBRES = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("IDSINO_SOBRES")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("IDSINO_SOBRES"))
                iIDCENTRO_COSTO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idCentro_Costo")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idCentro_Costo"))
                iIDAGENCIAS_DESTINO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idagencias_destino")) = True, 0, lds_tmp.Tables(0).Rows(0).Item("idagencias_destino"))
            End If
            dt_cur_edtguia_envio = lds_tmp.Tables(0)
            dt_cur_edtguia_documentos = lds_tmp.Tables(1)
            dt_cur_edtguia_articulos = lds_tmp.Tables(2)
            dt_cur_Sub_Cuenta = lds_tmp.Tables(3)
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Dim rst_del_doc_guias As New ADODB.Recordset
    'Public Function fnELIMINAR_DOC_GUIAS_2009(ByVal idGuias As Integer) As Boolean
    '    Dim flag As Boolean = False

    '    objLOG.fnLog("[dtoGuiaEnvio.fnELIMINAR_DOC_GUIAS] " & idGuias.ToString)
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_ELIMINAR_DOC_GUIAS", 4, idGuias, 1}
    '        rst_del_doc_guias = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_del_doc_guias.State = 1 Then
    '            flag = True
    '        Else
    '            flag = False
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnELIMINAR_DOC_GUIAS] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function fnELIMINAR_DOC_GUIASII(ByVal idGuias As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_ELIMINAR_DOC_GUIAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIdguia_Envio", idGuias, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                flag = True
            Else
                flag = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnControlEdicion_2009(ByVal nroGuia As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnControlEdicion] " & nroGuia)
    '        Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CONTROL_EDICION_GUIA", 4, nroGuia, 1}
    '        Dim rstControl As New ADODB.Recordset
    '        rstControl = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rstControl.State = 1 Then

    '            'If Int(rstControl.Fields.Item(0).Value.ToString) = 1 Or Int(rstControl.Fields.Item(1).Value.ToString) = 1 Then
    '            '    flag = True
    '            'Else
    '            '    flag = False
    '            'End If

    '            If Int(rstControl.Fields.Item(3).Value.ToString) > 0 Or Int(rstControl.Fields.Item(4).Value.ToString) > 0 Then
    '                flag = True
    '            Else
    '                flag = False
    '            End If
    '        Else
    '            flag = False
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Revisar datos...", MsgBoxStyle.Information, "Seguridad Datos")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnControlEdicion] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function fnControlEdicion(ByVal nroGuia As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_UTILITARIOS.SP_CONTROL_EDICION_GUIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idGuia_Envio", iControl_Documentos, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                If Int(ldt_tmp.Rows(0).Item(3)) > 0 Or Int(ldt_tmp.Rows(0).Item(4)) > 0 Then
                    flag = True
                Else
                    flag = False
                End If
            Else
                flag = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnSQLLIQUIDACIONES_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT As Object() = {"select to_char(coalesce(max(C.FECHA_LIQUIDACION_APER),sysdate),'DD/MM/YYYY') max_fecha_Apertura from t_cierres_liquidaciones C  Where  C.estado_aperturado_cierre=0 and C.IDUSUARIO_PERSONAL=" & dtoUSUARIOS.IdLogin.ToString, 2}
    '        Dim rstControl As New ADODB.Recordset
    '        rstControl = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rstControl.State = 1 Then
    '            FEC_MAX_APERTURA_LIQ = rstControl.Fields.Item("max_fecha_Apertura").Value
    '        End If
    '        rstControl = Nothing
    '        Dim varSP_OBJECT_1 As Object() = {"select to_char(coalesce(max(C.Fecha_Liquidacion_Cierre),sysdate),'DD/MM/YYYY') max_fecha_Cierre from t_cierres_liquidaciones C  Where  C.estado_aperturado_cierre=1 and C.IDUSUARIO_PERSONAL=" & dtoUSUARIOS.IdLogin.ToString, 2}
    '        rstControl = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT_1)
    '        If rstControl.State = 1 Then
    '            FEC_MAX_CIERRE_LIQ = rstControl.Fields.Item("max_fecha_Cierre").Value
    '        End If
    '        rstControl = Nothing
    '        flag = True
    '    Catch ex As Exception
    '        MsgBox("Datos No validos de Fecha de Apertura y Cierre de Liquidaciones...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return False
    'End Function
    Public Function fnSQLLIQUIDACIONES() As Boolean
        Dim flag As Boolean = False
        '
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            Dim ls_mensaje As String
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_GENERICO.sp_get_liquidacion_max_cred", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idusuario_personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("co_max_apetura", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_max_cierre", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            'Ejecutando dataset 
            lds_tmp = db_bd.EjecutarDataSet()
            '           
            FEC_MAX_APERTURA_LIQ = lds_tmp.Tables(0).Rows(0).Item("max_fecha_Apertura")
            FEC_MAX_CIERRE_LIQ = lds_tmp.Tables(1).Rows(0).Item("max_fecha_Cierre")
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnIATA_2009(ByVal idUnidadCiudad As Integer) As String
    '    Dim flag As String = "..."
    '    Try
    '        Dim varSP_OBJECT As Object() = {"select t_Unidad_Agencia.Codigo_Iata from t_Unidad_Agencia where t_Unidad_Agencia.Idunidad_Agencia=" & idUnidadCiudad.ToString, 2}
    '        Dim rstControl As New ADODB.Recordset
    '        rstControl = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rstControl.State = 1 Then
    '            flag = rstControl.Fields.Item("Codigo_Iata").Value
    '        Else
    '            flag = ""
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Mes válido revise sus datos...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = "..."
    '    End Try
    '    Return flag
    'End Function
    Public Function fnIATA(ByVal idUnidadCiudad As Integer) As String
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select sf_get_ciudad_iata(" & idUnidadCiudad & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'db_bd.AsignarParametro("ni_idunidad_agencia", idUnidadCiudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            flag = db_bd.EjecutarEscalar()
            'Desconectar 
            db_bd.Desconectar()
            'Ejecutando el escalar 
            'Return db_bd.EjecutarEscalar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnControlGuiasImpresas_2009(ByVal nroGuia As String) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        nroGuia = nroGuia.Substring(0, nroGuia.Length - 1)
    '        Dim varSP_OBJECT As Object() = {"PKG_UTILITARIOS.SP_DATOS_GUIAS_PRE", 4, nroGuia, 2}
    '        Dim rstControl As New ADODB.Recordset
    '        rstControl = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rstControl.State = 1 Then
    '            If rstControl.EOF = False And rstControl.BOF = False Then
    '                iIDPERSONA = rstControl.Fields.Item("Idpersona").Value
    '                sNU_DOCU_SUNAT = rstControl.Fields.Item("Nu_Docu_Suna").Value
    '                iIDUNIDAD_AGENCIA = rstControl.Fields.Item("Idagencias_Ori").Value
    '                iIDUNIDAD_AGENCIA_DESTINO = rstControl.Fields.Item("Idagencias_Desti").Value
    '                iNOMBRE_UNIDAD_ORIGEN = rstControl.Fields.Item("origen").Value
    '                iNOMBRE_UNIDAD_DESTINO = rstControl.Fields.Item("destino").Value
    '                iIDTIPO_ENTREGA_CARGA = rstControl.Fields.Item("Idtipo_Entrega_Carga").Value
    '                iIDCENTRO_COSTO = rstControl.Fields.Item("Idcentro_Costo").Value
    '                sRASON_SOCIAL = rstControl.Fields.Item("razon_social").Value
    '                flag = True
    '            End If

    '        Else
    '            flag = False
    '        End If

    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnControlGuiasImpresas(ByVal nroGuia As String) As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_UTILITARIOS.SP_DATOS_GUIAS_PRE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("nroGuia", iControl_Documentos, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                '
                iIDPERSONA = ldt_tmp.Rows(0).Item("Idpersona")
                sNU_DOCU_SUNAT = ldt_tmp.Rows(0).Item("Nu_Docu_Suna")
                iIDUNIDAD_AGENCIA = ldt_tmp.Rows(0).Item("Idagencias_Ori")
                iIDUNIDAD_AGENCIA_DESTINO = ldt_tmp.Rows(0).Item("Idagencias_Desti")
                iNOMBRE_UNIDAD_ORIGEN = ldt_tmp.Rows(0).Item("origen")
                iNOMBRE_UNIDAD_DESTINO = ldt_tmp.Rows(0).Item("destino")
                iIDTIPO_ENTREGA_CARGA = ldt_tmp.Rows(0).Item("Idtipo_Entrega_Carga")
                iIDCENTRO_COSTO = ldt_tmp.Rows(0).Item("Idcentro_Costo")
                sRASON_SOCIAL = ldt_tmp.Rows(0).Item("razon_social")
                '
                flat = True
            Else
                flat = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
#End Region

    'Public Function fnSP_INSUPD_DOCUMENTOS_FACBOL_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INSUPD_DOCUMENTOS_GUIAS", 16, iControl_Documentos, 1, iIDGUIAS_ENVIO, 1, iNro_Serie, 2, iNro_Docu, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INSUPD_DOCUMENTOS_FACBOL", 18, iControl_Documentos, 1, iIDGUIAS_ENVIO.ToString, 2, iNro_Serie, 2, iNro_Docu, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, V_IDTIPO_COMPROBANTE, 1}
    '        objLOG.fnLog("[dtoGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS] " & iControl_Documentos.ToString & "," & iIDGUIAS_ENVIO.ToString & "," & iNro_Serie.ToString & "," & iNro_Docu.ToString)
    '        rst_Lista_Documentos_Guia = Nothing
    '        rst_Lista_Documentos_Guia = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Lista_Documentos_Guia.EOF = False And rst_Lista_Documentos_Guia.BOF = False Then
    '            flat = True
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_INSUPD_DOCUMENTOS_FACBOL() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSUPD_DOCUMENTOS_FACBOL", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl_Documentos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xiIdguias_Envio", iIDGUIAS_ENVIO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNro_Serie", iNro_Serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNro_Docu", iNro_Docu, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidusuario_personal", IIf(iIDUSUARIO_PERSONAL = 0, dtoUSUARIOS.IdLogin, iIDUSUARIO_PERSONAL), OracleClient.OracleType.Int32) 'dtoUSUARIOS.IdLogin 'USUARIO REMOTO
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIdtipo_Comprobante", V_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                dt_rst_Lista_Documentos_Guia = lds_tmp.Tables(0)
                flat = True
            Else
                flat = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function


    Public Function fnSP_INSUPD_DOCUMENTOS_FACBOL_I() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSUPD_DOCUMENTOS_FACBOL_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl_Documentos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xiIdguias_Envio", iIDGUIAS_ENVIO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNro_Serie", iNro_Serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNro_Docu", iNro_Docu, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidusuario_personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIdtipo_Comprobante", V_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                dt_rst_Lista_Documentos_Guia = lds_tmp.Tables(0)
                flat = True
            Else
                flat = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    'Public Function fnSP_CONSULTA_ARTI_SUB_CUENTA_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INSUPD_DOCUMENTOS_GUIAS", 16, iControl_Documentos, 1, iIDGUIAS_ENVIO, 1, iNro_Serie, 2, iNro_Docu, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CONSULTA_ARTI_SUB_CUENTA", 10, iIDCENTRO_COSTO, 1, _
    '        iIDUNIDAD_AGENCIA, 1, _
    '        iIDUNIDAD_AGENCIA_DESTINO, 1, _
    '        Str(iIDPERSONA), 2}
    '        rst_Articulos_sub_cuenta = Nothing
    '        rst_Articulos_sub_cuenta = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Articulos_sub_cuenta.EOF = False And rst_Articulos_sub_cuenta.BOF = False Then
    '            flat = True
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_CONSULTA_ARTI_SUB_CUENTA() As Boolean
        '        
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_UTILITARIOS.SP_CONSULTA_ARTI_SUB_CUENTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDCENTRO_COSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDPERSONA", iIDPERSONA.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_ARTICULOS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                dt_rst_Articulos_sub_cuenta = ldt_tmp
                flat = True
            Else
                flat = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function SP_SI_VENTA_ARTICULOS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INSUPD_DOCUMENTOS_GUIAS", 16, iControl_Documentos, 1, iIDGUIAS_ENVIO, 1, iNro_Serie, 2, iNro_Docu, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_SI_VENTA_ARTICULOS", 4, _
    '        Str(iIDGUIAS_ENVIO), 2}
    '        RST_VENTA_ARTICULOS = Nothing
    '        RST_VENTA_ARTICULOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If RST_VENTA_ARTICULOS.EOF = False And RST_VENTA_ARTICULOS.BOF = False Then
    '            flat = True
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function SP_SI_VENTA_ARTICULOS() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_SI_VENTA_ARTICULOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDGUIAS_ENVIO", iIDGUIAS_ENVIO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_SI_VENTA_ARTICULOS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                dt_RST_VENTA_ARTICULOS = ldt_tmp
                flat = True
            Else
                flat = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function SP_SUB_CUENTAS_TARIFAS_2009(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean

    '    Try
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOPERSONA.SP_SUB_CUENTAS_TARIFAS", 4, _
    '        iIRuc_Rason_Social, 2}

    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dvListar_forma_pago = DT.DefaultView

    '        With Cmb
    '            .DataSource = dvListar_forma_pago
    '            .DisplayMember = "CENTRO_COSTO"
    '            .ValueMember = "IDCENTRO_COSTO"
    '        End With
    '        '
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    'End Function
    Public Function SP_SUB_CUENTAS_TARIFAS(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOPERSONA.SP_SUB_CUENTAS_TARIFAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCODIGOCLIENTE", iIRuc_Rason_Social, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("oCUR_SUB_CUENTA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dvListar_forma_pago = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dvListar_forma_pago
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
    'Public Function sp_busca_dtarifa_carga_cli_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INSUPD_DOCUMENTOS_GUIAS", 16, iControl_Documentos, 1, iIDGUIAS_ENVIO, 1, iNro_Serie, 2, iNro_Docu, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOPERSONA.sp_busca_dtarifa_carga_cli", 12, _
    '        iIDCENTRO_COSTO, 1, _
    '        iIDUNIDAD_AGENCIA, 1, _
    '        iIDUNIDAD_AGENCIA_DESTINO, 1, _
    '        iarticulo, 1, _
    '        iIRuc_Rason_Social, 2}

    '        cur_idtarifas_carga_cliente = Nothing

    '        cur_idtarifas_carga_cliente = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If cur_idtarifas_carga_cliente.EOF = False And cur_idtarifas_carga_cliente.BOF = False Then
    '            flat = True
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function sp_busca_dtarifa_carga_cli() As Boolean
        Dim flat As Boolean = False
        Dim ldt_tmp As New DataTable
        Try
            '
            dt_cur_idtarifas_carga_cliente = Nothing
            dt_cur_idtarifas_carga_cliente = New DataTable
            '
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOPERSONA.sp_busca_dtarifa_carga_cli", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("p_idcentro_costo", iIDCENTRO_COSTO, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_idunidad_agencia", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_articulo", iarticulo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCODIGOCLIENTE", iIRuc_Rason_Social, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("oCUR_TARIFA_CLIENTE", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            'Validando que tenga datos 
            If ldt_tmp.Rows.Count > 0 Then
                '
                dt_cur_idtarifas_carga_cliente = ldt_tmp
                '
                flat = True
            Else
                flat = False
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            '
        End Try
        Return flat
    End Function
    '    Public Function fnCONTROL_GUIAS_ENVIO_DOC_CC_2009() As Boolean
    '        Dim flat As Boolean = False
    '        Try
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 10, iCONTROL, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}

    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 14, iControl_Busqueda, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 14, iCONTROL, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}

    '            '            Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CONTROL_GUIAS_ENVIO_DOC_I", 14, iControl_Busqueda, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}
    '            'Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CTRL_GUIAS_ENVIO_DOC_IIcc", 16, iControl_Busqueda, 1, iIDPERSONA.ToString, 2, 'sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1, objGuiaEnvio.iIDCENTRO_COSTO, 1}
    '            '20/02/2008 < - >  Las variables no se considera el objecto  en los parametros  
    '            Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CTRL_GUIAS_ENVIO_DOC_IIcc", 16, iControl_Busqueda, 1, iIDPERSONA.ToString, 2, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1, iIDCENTRO_COSTO, 1}
    '            '
    '            objLOG.fnLog("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & fnLoagObj(varSP_OBJECT))
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 10, 1, 1, 1, 1, "0086109", 2, 1, 1}
    '            cur_Cliente = Nothing
    '            cur_CLIENTE_REMITENTE = Nothing
    '            cur_Sub_Cuenta = Nothing
    '            cur_Nombres_Remitente = Nothing
    '            cur_Direccion_Remitente = Nothing
    '            cur_Telefono_Remitente = Nothing
    '            cur_Nombres_Destinatario = Nothing
    '            cur_Direccion_Destinatario = Nothing
    '            cur_Telefono_Destinatario = Nothing
    '            cur_Documentos_Adjuntos = Nothing
    '            rst_Articulos = Nothing
    '            rst_Control = Nothing
    '            cur_Cliente = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '            'If IsDBNull(cur_Cliente) = False Then
    '            '    flat = False
    '            '    GoTo SALIDA
    '            'End If
    '            ' Seteando valores de Clientes...con cuentas corrientes
    '            If cur_Cliente.State = 1 Then
    '                If cur_Cliente.EOF = False And cur_Cliente.BOF = False Then
    '                    iIDPERSONA = Int(cur_Cliente.Fields.Item(0).Value.ToString())
    '                    sNU_DOCU_SUNAT = cur_Cliente.Fields.Item(1).Value.ToString()
    '                    sRASON_SOCIAL = cur_Cliente.Fields.Item(2).Value.ToString()
    '                    sFECHA_GUIA = cur_Cliente.Fields.Item(3).Value.ToString()
    '                    iIDTipoFacturacion = cur_Cliente.Fields.Item(4).Value.ToString()

    '                    cur_CLIENTE_REMITENTE = cur_Cliente.NextRecordset
    '                    cur_Sub_Cuenta = cur_Cliente.NextRecordset
    '                    cur_Nombres_Remitente = cur_Cliente.NextRecordset
    '                    cur_Direccion_Remitente = cur_Cliente.NextRecordset
    '                    cur_Telefono_Remitente = cur_Cliente.NextRecordset
    '                    cur_Nombres_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Direccion_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Telefono_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Documentos_Adjuntos = cur_Cliente.NextRecordset
    '                    cur_Pagos = cur_Cliente.NextRecordset
    '                    cur_Err = cur_Cliente.NextRecordset
    '                    rst_Articulos = cur_Cliente.NextRecordset
    '                    rst_Control = cur_Cliente.NextRecordset
    '                    cur_control_Centro_Costo = cur_Cliente.NextRecordset
    '                    'If cur_control_Centro_Costo.State = 1 Then
    '                    'iIDCENTRO_COSTO = Int(cur_control_Centro_Costo.Fields.Item(0).Value.ToString)
    '                    'End If
    '                    flat = True
    '                Else
    '                    flat = False
    '                End If
    '            Else
    '                cur_Sub_Cuenta = cur_Cliente.NextRecordset
    '                cur_Nombres_Remitente = cur_Cliente.NextRecordset
    '                cur_Direccion_Remitente = cur_Cliente.NextRecordset
    '                cur_Telefono_Remitente = cur_Cliente.NextRecordset
    '                cur_Nombres_Destinatario = cur_Cliente.NextRecordset
    '                cur_Direccion_Destinatario = cur_Cliente.NextRecordset
    '                cur_Telefono_Destinatario = cur_Cliente.NextRecordset
    '                cur_Documentos_Adjuntos = cur_Cliente.NextRecordset
    '                cur_Pagos = cur_Cliente.NextRecordset
    '                cur_Err = cur_Cliente.NextRecordset
    '                rst_Articulos = cur_Cliente.NextRecordset
    '                rst_Control = cur_Cliente.NextRecordset
    '                If rst_Control.State = 1 Then
    '                    iControl_Guias_Existe = Int(rst_Control.Fields.Item(0).Value.ToString)
    '                    If Int(rst_Control.Fields.Item(0).Value.ToString) = 2 Then
    '                        'MsgBox(rst_Control.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                    Else
    '                        MsgBox(rst_Control.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")

    '                    End If
    '                End If
    '                flat = False
    '            End If
    'SALIDA:
    '        Catch ex As Exception
    '            flat = False
    '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            objLOG.fnLogErr("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & ex.ToString)
    '        End Try

    '        Return flat
    '    End Function
    Public Function fnCONTROL_GUIAS_ENVIO_DOC_CC() As Boolean
        Dim flat As Boolean = False
        Dim ldt_tmp As DataSet
        Try
            Dim ls_mensaje As String
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_UTILITARIOS.SP_CTRL_GUIAS_ENVIO_DOC_IIcc", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iControl_Busqueda, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("x_iIDPERSONA", iIDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iNRO_GUIA", sNRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDGUIAS_ENVIO", iIDGUIAS_ENVIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idOrigen", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idDestino", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDCENTRO_COSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_Cliente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_cliente_remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Sub_Cuenta", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Nombres_Remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Direccion_Remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Telefono_Remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Nombres_Destinatario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Direccion_Destinatario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Telefono_Destinatario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Documentos_Adjuntos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Pagos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_control_Centro_Costo", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataSet()
            'Validando que tenga datos 
            If ldt_tmp.Tables(0).Rows.Count > 0 Then
                iIDPERSONA = CType(ldt_tmp.Tables(0).Rows(0).Item(0), Long)
                sNU_DOCU_SUNAT = CType(ldt_tmp.Tables(0).Rows(0).Item(1), String)
                sRASON_SOCIAL = CType(ldt_tmp.Tables(0).Rows(0).Item(2), String)
                sFECHA_GUIA = CType(ldt_tmp.Tables(0).Rows(0).Item(3), String)
                iIDTipoFacturacion = CType(ldt_tmp.Tables(0).Rows(0).Item(4), Long)
                '
                dt_cur_CLIENTE_REMITENTE = ldt_tmp.Tables(1)
                dt_cur_Sub_Cuenta = ldt_tmp.Tables(2)
                dt_cur_Nombres_Remitente = ldt_tmp.Tables(3)
                dt_cur_Direccion_Remitente = ldt_tmp.Tables(4)
                dt_cur_Telefono_Remitente = ldt_tmp.Tables(5)
                dt_cur_Nombres_Destinatario = ldt_tmp.Tables(6)
                dt_cur_Direccion_Destinatario = ldt_tmp.Tables(7)
                dt_cur_Telefono_Destinatario = ldt_tmp.Tables(8)
                dt_cur_Documentos_Adjuntos = ldt_tmp.Tables(9)
                dt_cur_Pagos = ldt_tmp.Tables(10)
            Else
                If ldt_tmp.Tables(2).Rows.Count > 0 Then
                    dt_cur_Nombres_Remitente = ldt_tmp.Tables(3)
                    dt_cur_Direccion_Remitente = ldt_tmp.Tables(4)
                    dt_cur_Telefono_Remitente = ldt_tmp.Tables(5)
                    dt_cur_Nombres_Destinatario = ldt_tmp.Tables(6)
                    dt_cur_Direccion_Destinatario = ldt_tmp.Tables(7)
                    dt_cur_Telefono_Destinatario = ldt_tmp.Tables(8)
                    dt_cur_Documentos_Adjuntos = ldt_tmp.Tables(9)
                    dt_cur_Pagos = ldt_tmp.Tables(10)
                    dt_cur_Err = ldt_tmp.Tables(11)
                    dt_rst_Articulos = ldt_tmp.Tables(12)
                    If ldt_tmp.Tables(13).Rows.Count > 0 Then
                        dt_rst_Control = ldt_tmp.Tables(13)
                        iControl_Guias_Existe = Int(ldt_tmp.Tables(13).Rows(0).Item(0).ToString)
                        If iControl_Guias_Existe <> 2 Then
                            MsgBox(ldt_tmp.Tables(13).Rows(0).Item(0).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                    End If
                End If
            End If
            Return True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            Return False
            '
        End Try
    End Function
    '    Public Function fnCONTROL_GUIAS_ENVIO_DOC_CC() As Boolean
    '        Dim flat As Boolean = False
    '        Try
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 10, iCONTROL, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}

    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 14, iControl_Busqueda, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 14, iCONTROL, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}

    '            '            Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CONTROL_GUIAS_ENVIO_DOC_I", 14, iControl_Busqueda, 1, iIDPERSONA, 1, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1}
    '            Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_CTRL_GUIAS_ENVIO_DOC_IIcc", 16, iControl_Busqueda, 1, iIDPERSONA.ToString, 2, sNRO_GUIA, 2, iIDGUIAS_ENVIO, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA, 1, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, 1, objGuiaEnvio.iIDCENTRO_COSTO, 1}
    '            objLOG.fnLog("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & fnLoagObj(varSP_OBJECT))
    '            'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CONTROL_GUIAS_ENVIO_DOC", 10, 1, 1, 1, 1, "0086109", 2, 1, 1}
    '            cur_Cliente = Nothing
    '            cur_CLIENTE_REMITENTE = Nothing
    '            cur_Sub_Cuenta = Nothing
    '            cur_Nombres_Remitente = Nothing
    '            cur_Direccion_Remitente = Nothing
    '            cur_Telefono_Remitente = Nothing
    '            cur_Nombres_Destinatario = Nothing
    '            cur_Direccion_Destinatario = Nothing
    '            cur_Telefono_Destinatario = Nothing
    '            cur_Documentos_Adjuntos = Nothing

    '            rst_Articulos = Nothing
    '            rst_Control = Nothing
    '            cur_Cliente = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '            'If IsDBNull(cur_Cliente) = False Then
    '            '    flat = False
    '            '    GoTo SALIDA
    '            'End If
    '            ' Seteando valores de Clientes...con cuentas corrientes
    '            If cur_Cliente.State = 1 Then
    '                If cur_Cliente.EOF = False And cur_Cliente.BOF = False Then
    '                    iIDPERSONA = Int(cur_Cliente.Fields.Item(0).Value.ToString())
    '                    sNU_DOCU_SUNAT = cur_Cliente.Fields.Item(1).Value.ToString()
    '                    sRASON_SOCIAL = cur_Cliente.Fields.Item(2).Value.ToString()
    '                    sFECHA_GUIA = cur_Cliente.Fields.Item(3).Value.ToString()
    '                    iIDTipoFacturacion = cur_Cliente.Fields.Item(4).Value.ToString()

    '                    cur_CLIENTE_REMITENTE = cur_Cliente.NextRecordset
    '                    cur_Sub_Cuenta = cur_Cliente.NextRecordset
    '                    cur_Nombres_Remitente = cur_Cliente.NextRecordset
    '                    cur_Direccion_Remitente = cur_Cliente.NextRecordset
    '                    cur_Telefono_Remitente = cur_Cliente.NextRecordset
    '                    cur_Nombres_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Direccion_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Telefono_Destinatario = cur_Cliente.NextRecordset
    '                    cur_Documentos_Adjuntos = cur_Cliente.NextRecordset
    '                    cur_Pagos = cur_Cliente.NextRecordset
    '                    cur_Err = cur_Cliente.NextRecordset
    '                    rst_Articulos = cur_Cliente.NextRecordset
    '                    rst_Control = cur_Cliente.NextRecordset
    '                    cur_control_Centro_Costo = cur_Cliente.NextRecordset
    '                    If cur_control_Centro_Costo.State = 1 Then
    '                        iIDCENTRO_COSTO = Int(cur_control_Centro_Costo.Fields.Item(0).Value.ToString)
    '                    End If
    '                    flat = True
    '                Else
    '                    flat = False
    '                End If
    '            Else
    '                cur_Sub_Cuenta = cur_Cliente.NextRecordset
    '                cur_Nombres_Remitente = cur_Cliente.NextRecordset
    '                cur_Direccion_Remitente = cur_Cliente.NextRecordset
    '                cur_Telefono_Remitente = cur_Cliente.NextRecordset
    '                cur_Nombres_Destinatario = cur_Cliente.NextRecordset
    '                cur_Direccion_Destinatario = cur_Cliente.NextRecordset
    '                cur_Telefono_Destinatario = cur_Cliente.NextRecordset
    '                cur_Documentos_Adjuntos = cur_Cliente.NextRecordset
    '                cur_Pagos = cur_Cliente.NextRecordset
    '                cur_Err = cur_Cliente.NextRecordset
    '                rst_Articulos = cur_Cliente.NextRecordset
    '                rst_Control = cur_Cliente.NextRecordset
    '                If rst_Control.State = 1 Then

    '                    iControl_Guias_Existe = Int(rst_Control.Fields.Item(0).Value.ToString)
    '                    If Int(rst_Control.Fields.Item(0).Value.ToString) = 2 Then
    '                        'MsgBox(rst_Control.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")

    '                    Else
    '                        MsgBox(rst_Control.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")

    '                    End If

    '                End If
    '                flat = False
    '            End If

    'SALIDA:
    '        Catch ex As Exception
    '            flat = False
    '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            objLOG.fnLogErr("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & ex.ToString)
    '        End Try

    '        Return flat
    '    End Function
    'Public Function fnLISTA_PERSONASII_2009(ByVal P_IDUSUARIO_PERSONAL As String) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_PERSONAS] ")
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_PERSONASII", 4, P_IDUSUARIO_PERSONAL, 2}
    '        rst_Lista_Personas = Nothing
    '        rst_Lista_Personas = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_PERSONAS] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function
    Public Function fnLISTA_PERSONASII(ByVal P_IDUSUARIO_PERSONAL As String) As Boolean
        Dim flat As Boolean = False
        Dim ldt_tmp As DataTable
        Try

            Dim ls_mensaje As String
            Dim db_bd As New BaseDatos
            '
            dt_Lista_Personas = Nothing
            dt_Lista_Personas = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_LISTA_PERSONASII", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("p_idusaurio_pesonal", P_IDUSUARIO_PERSONAL, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Lista_Personas", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_Lista_Personas = db_bd.EjecutarDataTable()
            '
            Return True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            Return False
            '
        End Try
    End Function
    ' 19/01/2009 - Carga Publica
    'Public Function fnTARIFA_PUBLICA_CARGA1_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        iTarifa_Publica_Monto_Base = 0.0
    '        iTarifa_Publica_Monto_Peso = 0.0
    '        iTarifa_Publica_Monto_Volumen = 0.0
    '        objLOG.fnLog("[dtoGuiaEnvio.fnTARIFA_PUBLICA_CARGA1] " & iIDUNIDAD_AGENCIA.ToString & "," & iIDUNIDAD_AGENCIA_DESTINO.ToString)
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA1", 6, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1}
    '        'Dim varSP_OBJECT() As Object = {"SP_TARIFA_PUBLICA_CARGA1", 6, iIDUNIDAD_AGENCIA, 1, iIDUNIDAD_AGENCIA_DESTINO, 1}
    '        rst_Tarifa_Publica_Carga = Nothing
    '        rst_Tarifa_Publica_Carga = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If rst_Tarifa_Publica_Carga.EOF = False And rst_Tarifa_Publica_Carga.BOF = False Then
    '            If Int(rst_Tarifa_Publica_Carga.Fields.Item(0).Value.ToString) > 0 Then
    '                iTarifa_Publica_Monto_Base = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_MONTO_BASE").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_MONTO_BASE").Value)
    '                iTarifa_Publica_Monto_Peso = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_X_PESO").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_X_PESO").Value)
    '                iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_X_VOLUMEN").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_X_VOLUMEN").Value)
    '                iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_X_SOBRE").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_X_SOBRE").Value)
    '                dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
    '                bContado = IIf(rst_Tarifa_Publica_Carga.Fields.Item("CONTADO").Value = 1, True, False)

    '                iTarifa_Publica_Monto_Base_credito = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_MONTO_BASE_CREDITO").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_MONTO_BASE_CREDITO").Value)
    '                iTarifa_Publica_Monto_Peso_credito = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_X_PESO_CREDITO").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_X_PESO_CREDITO").Value)
    '                iTarifa_Publica_Monto_Volumen_credito = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_X_VOLUMEN_CREDITO").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_X_VOLUMEN_CREDITO").Value)
    '                iTarifa_Publica_Monto_Base_Xpostal_credito = IIf(IsDBNull(rst_Tarifa_Publica_Carga.Fields.Item("CG_X_SOBRE_CREDITO").Value), 0, rst_Tarifa_Publica_Carga.Fields.Item("CG_X_SOBRE_CREDITO").Value)

    '                If bContado = 0 Then
    '                    If iTarifa_Publica_Monto_Base_Xpostal <= 0 Then
    '                        iTarifa_Publica_Monto_Base_Xpostal = iTarifa_Publica_Monto_Base
    '                    End If
    '                End If
    '                flat = True
    '            Else
    '                flat = False
    '            End If
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnTARIFA_PUBLICA_CARGA] " & ex.ToString)
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnTARIFA_PUBLICA_CARGA1() As Boolean
        Dim flat As Boolean = False
        iTarifa_Publica_Monto_Base = 0.0
        iTarifa_Publica_Monto_Peso = 0.0
        iTarifa_Publica_Monto_Volumen = 0.0
        Try
            Dim ls_mensaje As String
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            Dim lds_tmp As New DataSet
            lds_tmp = db_bd.EjecutarDataSet()
            '
            If CType(lds_tmp.Tables(1).Rows(0).Item(0), Long) <> 0 Then
                ls_mensaje = CType(lds_tmp.Tables(1).Rows(0).Item(1), String)
                MsgBox("Error Oracle " & ls_mensaje & " fn_tarifa_carga1", MsgBoxStyle.Critical)
                Return flat
            End If
            '
            ' Ejecuta lo que se ha recuperado, como estaba en el procedimiento actual  
            If lds_tmp.Tables(0).Rows.Count = 1 And lds_tmp.Tables(0).Rows(0).Item(0) = 1 Then
                iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE"))
                iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO"))
                iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN"))
                iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE"))
                dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
                bContado = IIf(lds_tmp.Tables(0).Rows(0).Item("CONTADO") = 1, True, False)
                '
                'Verifica si es producto pyme
                If bPyme Then
                    If iProceso = 7 Then
                        iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO"))
                        iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO"))
                        iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO"))
                        iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO"))
                        dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
                    End If
                End If

                'Dim db As New BaseDatos
                'db.Conectar()
                'db_bd.CrearComando("select sf_get_tipo_agencia(" & ObjVentaCargaContado.v_IDAGENCIAS & ") from dual", CommandType.Text)
                'Dim iTipoAgencia As Integer = db_bd.EjecutarEscalar
                'If iTipoAgencia = 7 Then
                '    iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO"))
                '    iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO"))
                '    iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO"))
                '    iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO"))
                '    dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
                'End If
                'db.Desconectar()

                iTarifa_Publica_Monto_Base_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO"))
                iTarifa_Publica_Monto_Peso_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO"))
                iTarifa_Publica_Monto_Volumen_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO"))
                iTarifa_Publica_Monto_Base_Xpostal_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO"))
                '
                If bContado = 0 Then
                    If iTarifa_Publica_Monto_Base_Xpostal <= 0 Then
                        iTarifa_Publica_Monto_Base_Xpostal = iTarifa_Publica_Monto_Base
                    End If
                End If
                flat = True
            Else
                If lds_tmp.Tables(0).Rows.Count > 1 Then
                    ls_mensaje = "Se encontró más de una tarifa para está ruta"
                Else
                    ls_mensaje = "No se encontró ninguna tarifa para está ruta"
                End If
                MsgBox(ls_mensaje, MsgBoxStyle.Information)
            End If
            '
            '--
            'Manejo de errores 
            Return flat
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            Return False
        End Try
    End Function
    'Public Function fnActualizaReimpresion_2009(ByVal tipo As Integer, ByVal documento As String, ByVal codigo As String, ByVal motivo As String, ByVal fecha As String, ByVal usuario As Integer, ByVal hora As String, ByVal correlativo As String) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"SP_REIMPRESION_ETIQUETA", 18, tipo, 1, documento, 2, codigo, 2, motivo, 2, fecha, 2, usuario, 1, hora, 2, correlativo, 2}
    '        VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnActualizaReimpresion(ByVal tipo As Integer, ByVal documento As String, ByVal codigo As String, ByVal motivo As String, ByVal fecha As String, ByVal usuario As Integer, ByVal hora As String, ByVal correlativo As String) As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("SP_REIMPRESION_ETIQUETA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_documento", CType(documento, Int32), OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_codigo", codigo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_motivo", motivo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_usuario", usuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_hora", hora, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_correlativo", CType(correlativo, Int32), OracleClient.OracleType.Int32)
            'Variables de salidas 
            'No tiene 
            db_bd.EjecutarEscalar()
            'Desconectar 
            db_bd.Desconectar()
            flat = True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            '
        End Try
        Return flat
    End Function
    'Public Function fnEtiquetaImpresa_2009(ByVal tipo As Integer, ByVal documento As String) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_ETIQUETA_IMPRESA", 6, tipo, 1, documento, 2}
    '        cur_etiqueta = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnEtiquetaImpresa(ByVal tipo As Integer, ByVal documento As String) As Boolean
        Dim flat As Boolean = False
        '
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_ETIQUETA_IMPRESA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_documento", CType(documento, Int32), OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            '            
            If ldt_tmp.Rows.Count > 0 Then
                dt_cur_etiqueta = ldt_tmp
                flat = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            '
        End Try
        Return flat
    End Function
    Public Sub get_nro_bultos_x_reimpresion()
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.sp_nro_bultos", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("p_idguias_envio", iIDGUIAS_ENVIO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_nro_bultos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            '            
            total_bultos = ldt_tmp.Rows(0)(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            '
        End Try

    End Sub
    Function sp_linea_credito() As DataTable
        Try
            Dim ls_sql As String
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As DataTable            'conecta con la Bd
            '
            db_bd.Conectar()
            db_bd.CrearComando("sp_linea_credito", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idpersona", iIDPERSONA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Shared Function AccesoPyme(ByVal ip As String) As Integer
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("select sf_get_pyme('" & ip & "') from dual", CommandType.Text)
            Dim iPyme As Integer = db.EjecutarEscalar
            Return iPyme
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    'Dim db As New BaseDatos
    'db.Conectar()
    'db_bd.CrearComando("select sf_get_tipo_agencia(" & ObjVentaCargaContado.v_IDAGENCIAS & ") from dual", CommandType.Text)
    'Dim iTipoAgencia As Integer = db_bd.EjecutarEscalar
    'If iTipoAgencia = 7 Then
    '    iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO"))
    '    iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO"))
    '    iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO"))
    '    iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO"))
    '    dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
    'End If
    'db.Desconectar()

    'Public Function fnTARIFA_PUBLICA_CARGA2() As Boolean
    '    Dim flat As Boolean = False
    '    iTarifa_Publica_Monto_Base = 0.0
    '    iTarifa_Publica_Monto_Peso = 0.0
    '    iTarifa_Publica_Monto_Volumen = 0.0
    '    Try
    '        Dim ls_mensaje As String = ""
    '        Dim db_bd As New BaseDatos
    '        Dim lds_tmp As New DataSet
    '        'conecta con la Bd
    '        db_bd.Conectar()
    '        db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", CommandType.StoredProcedure)
    '        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("ni_producto", TipoProducto_, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("ni_tarifa", TipoTarifa_, OracleClient.OracleType.Int32)
    '        'Variables de salidas 
    '        db_bd.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
    '        'Desconectar 
    '        db_bd.Desconectar()
    '        lds_tmp = db_bd.EjecutarDataSet()


    '        If lds_tmp.Tables(1).Rows.Count > 0 Then
    '            If lds_tmp.Tables(1).Rows(0).Item(0) IsNot System.DBNull.Value Then
    '                Unidad_ = lds_tmp.Tables(1).Rows(0).Item("UNIDAD")
    '                iPeso_Minimo = lds_tmp.Tables(1).Rows(0).Item("INICIO")
    '                iPeso_Maximo = lds_tmp.Tables(1).Rows(0).Item("FIN")
    '                iPrecio_cond_Peso = lds_tmp.Tables(1).Rows(0).Item("MONTO")
    '                TipoTarifa_ = lds_tmp.Tables(1).Rows(0).Item("TIPO_TARIFA")
    '                TipoProducto_ = lds_tmp.Tables(1).Rows(0).Item("ID_PRODUCTO")
    '                CondicionTarifa_ = True '--> t_condicion_tarifa_Publica
    '            Else
    '                CondicionTarifa_ = False
    '            End If
    '        Else
    '            CondicionTarifa_ = False
    '        End If



    '        If lds_tmp.Tables(0).Rows.Count = 1 And lds_tmp.Tables(0).Rows(0).Item(0) = 1 Then
    '            If TipoTarifa_ = 0 Then '---> TARIFA 48 HORAS
    '                iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE"))
    '                iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO"))
    '                iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN"))
    '                iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE"))
    '                dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
    '                bContado = IIf(lds_tmp.Tables(0).Rows(0).Item("CONTADO") = 1, True, False)

    '                If TarifaPyme_ Then
    '                    iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_BASE_CONTADO"))
    '                    iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_PESO_CONTADO"))
    '                    iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO"))
    '                    iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO"))
    '                    dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
    '                    TarifaPyme_ = False
    '                ElseIf TarifaMasiva_ Then
    '                    iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma48_BASE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma48_BASE_CONTADO"))
    '                    iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma48_PESO_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma48_PESO_CONTADO"))
    '                    iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma48_VOLUMEN_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma48_VOLUMEN_CONTADO"))
    '                    iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma48_SOBRE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma48_SOBRE_CONTADO"))
    '                    iTarifa_Publica_Monto_Base = 0
    '                    TarifaMasiva_ = False
    '                End If
    '            Else '----------------------> TARIFA 24 HORAS
    '                If TarifaMasiva_ Then
    '                    iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma24_BASE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma24_BASE_CONTADO"))
    '                    iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma24_PESO_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma24_PESO_CONTADO"))
    '                    iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma24_VOLUMEN_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma24_VOLUMEN_CONTADO"))
    '                    iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ma24_SOBRE_CONTADO")), 0, lds_tmp.Tables(0).Rows(0).Item("ma24_SOBRE_CONTADO"))
    '                    TarifaMasiva_ = False
    '                Else
    '                    iTarifa_Publica_Monto_Base = 0
    '                    iTarifa_Publica_Monto_Peso = 0
    '                    iTarifa_Publica_Monto_Volumen = 0
    '                    iTarifa_Publica_Monto_Base_Xpostal = 0
    '                End If
    '            End If


    '            iTarifa_Publica_Monto_Base_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO"))
    '            iTarifa_Publica_Monto_Peso_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO"))
    '            iTarifa_Publica_Monto_Volumen_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO"))
    '            iTarifa_Publica_Monto_Base_Xpostal_credito = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO")), 0, lds_tmp.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO"))
    '            '
    '            If bContado = 0 Then
    '                If iTarifa_Publica_Monto_Base_Xpostal <= 0 Then
    '                    iTarifa_Publica_Monto_Base_Xpostal = iTarifa_Publica_Monto_Base
    '                End If
    '            End If
    '            flat = True
    '        End If
    '        Return flat
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '        Return False
    '    End Try
    'End Function

    Public Function fnTARIFA_PUBLICA_CARGA2() As Boolean
        Dim flat As Boolean = False
        iTarifa_Publica_Monto_Base = 0.0
        iTarifa_Publica_Monto_Peso = 0.0
        iTarifa_Publica_Monto_Volumen = 0.0
        iTarifa_Publica_Monto_Base_Xpostal = 0.0

        Try
            Dim ls_mensaje As String = ""
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()

            'db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", CommandType.StoredProcedure)
            db_bd.CrearComando("SP_TARIFA_CLIENTE_VC", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPERSONA", iIDPERSONA, OracleClient.OracleType.Int32)
            'db_bd.AsignarParametro("ni_producto", TipoProducto_, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIPROCESO", TipoProducto_, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tarifa", TipoTarifa_, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet()


            If lds_tmp.Tables(1).Rows.Count > 0 Then
                If lds_tmp.Tables(1).Rows(0).Item(0) IsNot System.DBNull.Value Then
                    '----Peso----
                    UnidadPeso_ = IIf(IsDBNull(lds_tmp.Tables(1).Rows(0).Item("UNIDAD")), "", lds_tmp.Tables(1).Rows(0).Item("UNIDAD"))
                    iPeso_Minimo = IIf(IsDBNull(lds_tmp.Tables(1).Rows(0).Item("INICIO")), "", lds_tmp.Tables(1).Rows(0).Item("INICIO"))
                    iPeso_Maximo = IIf(IsDBNull(lds_tmp.Tables(1).Rows(0).Item("FIN")), "", lds_tmp.Tables(1).Rows(0).Item("FIN"))
                    iPrecio_cond_Peso = IIf(IsDBNull(lds_tmp.Tables(1).Rows(0).Item("MONTO")), "", lds_tmp.Tables(1).Rows(0).Item("MONTO"))

                    '----Volumen----    
                    UnidadVol_ = IIf(IsDBNull(lds_tmp.Tables(1).Rows(1).Item("UNIDAD")), "", lds_tmp.Tables(1).Rows(1).Item("UNIDAD"))
                    iVol_Minimo = IIf(IsDBNull(lds_tmp.Tables(1).Rows(1).Item("INICIO")), "", lds_tmp.Tables(1).Rows(1).Item("INICIO"))
                    iVol_Maximo = IIf(IsDBNull(lds_tmp.Tables(1).Rows(1).Item("FIN")), "", lds_tmp.Tables(1).Rows(1).Item("FIN"))
                    iPrecio_cond_Vol = IIf(IsDBNull(lds_tmp.Tables(1).Rows(1).Item("MONTO")), 0, lds_tmp.Tables(1).Rows(1).Item("MONTO"))


                    TipoTarifa_ = lds_tmp.Tables(1).Rows(0).Item("TIPO_TARIFA")
                    TipoProducto_ = lds_tmp.Tables(1).Rows(0).Item("ID_PRODUCTO")
                    CondicionTarifa_ = True '--> t_condicion_tarifa_Publica
                Else
                    CondicionTarifa_ = False
                End If
            Else
                CondicionTarifa_ = False
            End If

            ' Nuevo Tepsa Box trae 2 valores

            If (lds_tmp.Tables(0).Rows.Count <> 0) Then

                If (lds_tmp.Tables(0).Rows.Count = 1 Or lds_tmp.Tables(0).Rows.Count = 2) And lds_tmp.Tables(0).Rows(0).Item(0) = 1 Then
                    If TipoTarifa_ = 1 Then '---> ESTANDAR - TARIFA PUBLICA NORMALIZADA 
                        iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_BASE"))
                        iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_PERSO")), 0, lds_tmp.Tables(0).Rows(0).Item("N_PERSO"))
                        iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN")), 0, lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN"))
                        iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_SOBRE"))
                        dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
                        'bContado = IIf(lds_tmp.Tables(0).Rows(0).Item("CONTADO") = 1, True, False)

                        If TarifaBox_ Then

                            iMonto25 = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_BASE"))
                            iMonto40 = IIf(IsDBNull(lds_tmp.Tables(0).Rows(1).Item("N_BASE")), 0, lds_tmp.Tables(0).Rows(1).Item("N_BASE"))
                            iTarifa_Publica_Monto_Base = 0
                            iTarifa_Publica_Monto_Base_Xpostal = 0
                            'dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
                            'dPrecio_xUnidad2 = iTarifa_Publica_Monto_Volumen


                        ElseIf TarifaPyme_ Then
                            iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_BASE"))
                            iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_PERSO")), 0, lds_tmp.Tables(0).Rows(0).Item("N_PERSO"))
                            iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN")), 0, lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN"))
                            iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_SOBRE"))
                            dPRECIO_X_UNIDAD = iTarifa_Publica_Monto_Base
                            TarifaPyme_ = False
                        ElseIf TarifaMasiva_ Then
                            iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_BASE"))
                            iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_PERSO")), 0, lds_tmp.Tables(0).Rows(0).Item("N_PERSO"))
                            iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN")), 0, lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN"))
                            iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_SOBRE"))
                            iTarifa_Publica_Monto_Base = 0
                            TarifaMasiva_ = False
                        End If
                    Else '----------------------> TARIFA URGENTES
                        If TarifaMasiva_ Then
                            iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_BASE"))
                            iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_PERSO")), 0, lds_tmp.Tables(0).Rows(0).Item("N_PERSO"))
                            iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN")), 0, lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN"))
                            iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_SOBRE"))
                            TarifaMasiva_ = False
                        Else
                            iTarifa_Publica_Monto_Base = 0
                            iTarifa_Publica_Monto_Peso = 0
                            iTarifa_Publica_Monto_Volumen = 0
                            iTarifa_Publica_Monto_Base_Xpostal = 0
                        End If
                    End If


                    iTarifa_Publica_Monto_Base = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_BASE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_BASE"))
                    iTarifa_Publica_Monto_Peso = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_PERSO")), 0, lds_tmp.Tables(0).Rows(0).Item("N_PERSO"))
                    iTarifa_Publica_Monto_Volumen = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN")), 0, lds_tmp.Tables(0).Rows(0).Item("N_VOLUMEN"))
                    iTarifa_Publica_Monto_Base_Xpostal = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("N_SOBRE")), 0, lds_tmp.Tables(0).Rows(0).Item("N_SOBRE"))
                    '
                Else

                    ' Se valida que si trae valores ceros le ponga cero a los montos

                    iTarifa_Publica_Monto_Base = 0.0
                    iTarifa_Publica_Monto_Peso = 0.0
                    iTarifa_Publica_Monto_Volumen = 0.0
                    iTarifa_Publica_Monto_Base_Xpostal = 0.0

                End If


                If bContado = 0 Then
                    If iTarifa_Publica_Monto_Base_Xpostal <= 0 Then
                        iTarifa_Publica_Monto_Base_Xpostal = iTarifa_Publica_Monto_Base
                    End If
                End If
                flat = True
            End If
            Return flat
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            Return False
        End Try
    End Function

    'Public Function GrabarGuiaCredito(ByVal IDGUIAS_ENVIO As String, ByVal sFECHA_GUIA As String, ByVal sNRO_GUIA As String, _
    '                                  ByVal iIDTIPO_ENTREGA_CARGA As Integer, ByVal iIDFORMA_PAGO As Integer, ByVal iIDUNIDAD_AGENCIA As Integer, _
    '                                  ByVal iIDCIUDAD_TRANSITO As Integer, ByVal iIDUNIDAD_AGENCIA_DESTINO As Integer, ByVal iIDAGENCIAS As Integer, _
    '                                  ByVal iIDCONTACTO_REMITENTE As String, ByVal iIDDIRECCION_REMITENTE As String, ByVal iIDTELEFONO_REMITENTE As String, _
    '                                  ByVal iIDCONTACTO_DESTINATARIO As String, ByVal iIDDIRECCION_DESTINATARIO As String, ByVal iIDTELEFONO_CONSIGNADO As String, _
    '                                  ByVal dMONTO_BASE As Double, ByVal dTOTAL_PESO As Double, ByVal iCANTIDAD As Integer, ByVal dTOTAL_VOLUMEN As Double, _
    '                                  ByVal iCANTIDAD_X_UNIDAD_VOLUMEN As Integer, ByVal iCANTIDAD_X_UNIDAD_ARTI As Integer, ByVal dPRECIO_X_UNIDAD As Double, _
    '                                  ByVal dIMPUESTO As Double, ByVal dMONTO_IMPUESTO As Double, ByVal dTOTAL_COSTO As Double, ByVal iIDUSUARIO_PERSONAL As Integer, _
    '                                  ByVal iIDROL_USUARIO As Integer, ByVal sIP As String, ByVal iIDESTADO_REGISTRO As Integer, ByVal iNOMBRES_REMITENTE As String, _
    '                                  ByVal iDNI_REMITENTE As String, ByVal iDIRECCION_REMITENTE As String, ByVal iNOMBRES_DESTINATARIO As String, _
    '                                  ByVal iDNI_DESTINATARIO As String, ByVal iDIRECCION_DESTINATARIO As String, ByVal dPrecio_x_Volumen As Double, _
    '                                  ByVal dPrecio_x_Peso As Double, ByVal iCARGO As Integer, ByVal sTelefono_Remitente As Integer, _
    '                                  ByVal sTelefono_Destinatario As String, ByVal iID_REMITENTE As String, ByVal iREMITENTE As String, _
    '                                  ByVal iNRODOC_REM As String, ByVal iIDCENTRO_COSTO As Integer, ByVal iCANTIDAD_SOBRES As Integer, _
    '                                  ByVal iIDSINO_SOBRES As Integer, ByVal iIDAGENCIAS_DESTINO As Integer, ByVal ClienteModificado As Integer, _
    '                                  ByVal iIDPERSONA As Integer, ByVal sNombresCliente As String, ByVal sNumeroDocumentoCliente As String, ByVal iIDTipoDocumentoCliente As Integer, _
    '                                  ByVal sNombreCliente As String, ByVal sApellidoPaternoCliente As String, ByVal sApellidoMaternoCliente As String, ByVal sTelefonoCliente As String, _
    '                                  ByVal RemitenteModificado As Integer, ByVal iIDRemitente As Integer, ByVal sNombresRemitente As String, _
    '                                  ByVal sNumeroDocumentoRemitente As String, ByVal iIDTipoDocumentoRemitente As Integer, ByVal sNombreRemitente As String, _
    '                                  ByVal sApellidoPaternoRemitente As String, ByVal sApellidoMaternoRemitente As String, _
    '                                  ByVal ContactoModificado As Integer, ByVal iIDcontacto As Integer, ByVal sNombresContacto As String, _
    '                                  ByVal sNumeroDocumentoContacto As String, ByVal iIDTipoDocumentoContacto As Integer, ByVal sNombreContacto As String, _
    '                                  ByVal sApellidoPaternoContacto As String, ByVal sApellidoMaternoContacto As String, _
    '                                  ByVal ConsignadoModificado As Integer, ByVal iIDConsignado As Integer, ByVal sNombresConsignado As String, _
    '                                  ByVal sNumeroDocumentoConsignado As String, ByVal iIDTipoDocumentoConsignado As Integer, ByVal sNombreConsignado As String, _
    '                                  ByVal sApellidoPaternoConsignado As String, ByVal sApellidoMaternoConsignado As String, ByVal sTelefonoConsignado As String, _
    '                                  ByVal DireccionCliente_Mod As Integer, ByVal id_DepartamentoCli As Integer, ByVal id_ProvinciaCli As Integer, _
    '                                  ByVal id_DistritoCli As Integer, ByVal id_viaCli As Integer, ByVal viaCli As String, ByVal NumeroCli As String, ByVal manzanaCli As String, _
    '                                  ByVal loteCli As String, ByVal id_nivelCli As Integer, ByVal nivelCli As String, ByVal id_zonaCli As Integer, ByVal zonaCli As String, _
    '                                  ByVal id_clasificacionCli As Integer, ByVal clasificacionCli As String, _
    '                                  ByVal DireccionConsignado_Mod As Integer, ByVal id_DepartamentoConsig As Integer, ByVal id_ProvinciaConsig As Integer, _
    '                                  ByVal id_DistritoConsig As Integer, ByVal id_viaConsig As Integer, ByVal viaConsig As String, ByVal NumeroConsig As String, _
    '                                  ByVal manzanaConsig As String, ByVal loteConsig As String, ByVal id_nivelConsig As Integer, ByVal nivelConsig As String, _
    '                                  ByVal id_zonaConsig As Integer, ByVal zonaConsig As String, ByVal id_clasificacionConsig As Integer, _
    '                                  ByVal clasificacionConsig As String, ByVal sEmail As String, ByVal sReferencia As String, ByVal iMETROCUBICO As Integer,
    '                                  Optional ByVal iControl As Integer = 1) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim db As New BaseDatos
    '        db.Conectar()
    '        db.CrearComando("PKG_GUIA_ENVIO_2.SP_INS_GUIAS_ENVIO_IX", CommandType.StoredProcedure)
    '        db.AsignarParametro("ni_control", iControl, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("xiIDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("sFECHA_GUIA", sFECHA_GUIA, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("sNRO_GUIA", sNRO_GUIA, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iIDTIPO_ENTREGA_CARGA", iIDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDFORMA_PAGO", iIDFORMA_PAGO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDCIUDAD_TRANSITO", iIDCIUDAD_TRANSITO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("x_iIDCONTACTO_REMITENTE", iIDCONTACTO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("x_iIDDIRECCION_REMITENTE", iIDDIRECCION_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("x_iIDTEFONO_REMITENTE", iIDTELEFONO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("x_iIDCONTACTO_DESTINATARIO", iIDCONTACTO_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("x_iIDDIRECCION_DESTINATARIO", iIDDIRECCION_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("x_iIDTEFONO_CONSIGNADO", iIDTELEFONO_CONSIGNADO.ToString(), OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("dMONTO_BASE", dMONTO_BASE, OracleClient.OracleType.Number)
    '        db.AsignarParametro("dTOTAL_PESO", dTOTAL_PESO, OracleClient.OracleType.Number)
    '        db.AsignarParametro("iCANTIDAD", iCANTIDAD, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("dTOTAL_VOLUMEN", dTOTAL_VOLUMEN, OracleClient.OracleType.Number)
    '        db.AsignarParametro("iCANTIDAD_X_UNIDAD_VOLUMEN", iCANTIDAD_X_UNIDAD_VOLUMEN, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iCANTIDAD_X_UNIDAD_ARTI", iCANTIDAD_X_UNIDAD_ARTI, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("dPRECIO_X_UNIDAD", dPRECIO_X_UNIDAD, OracleClient.OracleType.Number)
    '        db.AsignarParametro("dIMPUESTO", dIMPUESTO, OracleClient.OracleType.Number)
    '        db.AsignarParametro("dMONTO_IMPUESTO", dMONTO_IMPUESTO, OracleClient.OracleType.Number)
    '        db.AsignarParametro("dTOTAL_COSTO", dTOTAL_COSTO, OracleClient.OracleType.Number)
    '        db.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIP", sIP, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iNOMBRES_REMITENTE", iNOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iDNI_REMITENTE", iDNI_REMITENTE, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iDIRECCION_REMITENTE", iDIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iNOMBRES_DESTINATARIO", iNOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iDNI_DESTINATARIO", iDNI_DESTINATARIO, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iDIRECCION_DESTINATARIO", iDIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iPrecio_x_Peso", dPrecio_x_Peso, OracleClient.OracleType.Number)
    '        db.AsignarParametro("iPrecio_x_Volumen", dPrecio_x_Volumen, OracleClient.OracleType.Number)
    '        db.AsignarParametro("iCARGO", iCARGO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iTelefono_Remitente", "@", OracleClient.OracleType.VarChar) 'sTelefono_Remitente
    '        db.AsignarParametro("iTelefono_Destinatario", "@", OracleClient.OracleType.VarChar) 'sTelefono_Destinatario
    '        db.AsignarParametro("x_iID_REMITENTE", iID_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iREMITENTE", iREMITENTE, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iNRODOC_REM", iNRODOC_REM, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("iIDCENTRO_COSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iCANTIDAD_SOBRES", iCANTIDAD_SOBRES, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDSINO_SOBRES", iIDSINO_SOBRES, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iIDAGENCIAS_DESTINO", iIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_MetroCubico", iMETROCUBICO, OracleClient.OracleType.Int32)

    '        '--Nuevos Parametros---
    '        '===CLIENTE==== 
    '        db.AsignarParametro("ni_ClienteModificado", ClienteModificado, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("xiIDPERSONA", iIDPERSONA, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombresCliente", sNombresCliente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_NumeroDocumentoCliente", sNumeroDocumentoCliente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_IDTipoDocumentoCliente", iIDTipoDocumentoCliente, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombreCliente", sNombreCliente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoPaternoCliente", sApellidoPaternoCliente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoMaternoCliente", sApellidoMaternoCliente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_TelefonoCliente", sTelefonoCliente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_Email", sEmail, OracleClient.OracleType.VarChar) '07092011 Nuevo Parametro
    '        '===REMITENTE==     
    '        db.AsignarParametro("ni_RemitenteModificado", RemitenteModificado, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_IDRemitente", iIDRemitente, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombresRemitente", sNombresRemitente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_NumeroDocumentoRemitente", sNumeroDocumentoRemitente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_IDTipoDocumentoRemitente", iIDTipoDocumentoRemitente, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombreRemitente", sNombreRemitente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoPaternoRemitente", sApellidoPaternoRemitente, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoMaternoRemitente", sApellidoMaternoRemitente, OracleClient.OracleType.VarChar)

    '        '==CONTACTO====
    '        db.AsignarParametro("ni_ContactoModificado", ContactoModificado, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_IDContacto", iIDcontacto, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombresContacto", sNombresContacto, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_NumeroDocumentoContacto", sNumeroDocumentoContacto, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_IDTipoDocumentoContacto", iIDTipoDocumentoContacto, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombreContacto", sNombreContacto, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoPaternoContacto", sApellidoPaternoContacto, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoMaternoContacto", sApellidoMaternoContacto, OracleClient.OracleType.VarChar)
    '        '==CONSIGNADO==     
    '        db.AsignarParametro("ni_ConsignadoModificado", ConsignadoModificado, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_IDConsignado", iIDConsignado, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombresConsignado", sNombresConsignado, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_NumeroDocumentoConsignado", sNumeroDocumentoConsignado, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_IDTipoDocumentoConsignado", iIDTipoDocumentoConsignado, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_NombreConsignado", sNombreConsignado, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoPaternoConsignado", sApellidoPaternoConsignado, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_apellidoMaternoConsignado", sApellidoMaternoConsignado, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_TelefonoConsignado", sTelefonoConsignado, OracleClient.OracleType.VarChar)

    '        '==DIRECCION ESTRUCTURADA CLIENTE (REMITENTE)      
    '        db.AsignarParametro("ni_DireccionCliente_Mod", DireccionCliente_Mod, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)

    '        'DIRECCION ESTRUCTURADA CONSIGNADO (DESTINATARIO)       
    '        db.AsignarParametro("ni_DireccionConsignado_Mod", DireccionConsignado_Mod, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
    '        '-----
    '        db.AsignarParametro("curr_datos_Guia_Envio", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
    '        db.Desconectar()
    '        Dim ds As DataSet = db.EjecutarDataSet

    '        '===Codigo de barras======
    '        If ds.Tables(0).Rows.Count > 0 And IsDBNull(ds.Tables(0).Rows(0).Item(0)) = False Then
    '            MessageBox.Show(ds.Tables(0).Rows(0).Item(1).ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            If ds.Tables(0).Rows(0).Item(0) > 0 Then
    '                iIDGUIAS_ENVIO = ds.Tables(0).Rows(0).Item(0)
    '                dt_cur_codBarras = ds.Tables(1)
    '                flat = True
    '            End If
    '        End If

    '        '===Propagando el error===
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
    '                If ds.Tables(1).Rows(0).Item(0) = -20000 Then
    '                    Throw New Excepcion(ds.Tables(1).Rows(0).Item(1))
    '                    flat = False
    '                End If
    '            End If
    '        End If
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    '    Return flat
    'End Function


    'BUSCAR CLIENTE CREDITO
    Function BuscarClienteCredito(ByVal item As String, ByVal opcion As Integer, ByVal origen As Integer, ByVal destino As Integer, Optional ByVal centroCosto As Integer = 999) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_BuscarClienteCredito_I", CommandType.StoredProcedure)
            db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idcentrocostro", centroCosto, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor)
            'db.AsignarParametro("co_subcuentaOrigen", OracleClient.OracleType.Cursor)
            'db.AsignarParametro("co_subcuenta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function BuscarClienteCredito(ByVal item As String) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_BuscarClienteCredito", CommandType.StoredProcedure)
            db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    'CONSULTAR X SUBCUENTA
    Function BuscarClienteCredito(ByVal cliente As Integer, ByVal origen As Integer, ByVal destino As Integer, ByVal IDCentroCosto As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_BuscarClienteCredito", CommandType.StoredProcedure)
            db.AsignarParametro("vi_IDCentroCosto", IDCentroCosto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    'RECUPERACION DE VENTA CREDITO
    Function RecuperarVentaCredito(ByVal iIDGuia_Envio As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.SP_RecuperarVentaCredito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idguias_envio", iIDGuia_Envio, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_Guia_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_Guia_Volumetrico", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Guia_documentos", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_Guia_articulos", OracleClient.OracleType.Cursor) '3
            db.AsignarParametro("co_Guia_SubCuenta", OracleClient.OracleType.Cursor) '4
            db.AsignarParametro("co_Consignado", OracleClient.OracleType.Cursor) '5
            db.AsignarParametro("co_Guia_SubCuenta_origen", OracleClient.OracleType.Cursor) '6
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '7
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    'RECUPERACION DE VENTA CONTADO
    Public Function RecuperarVentaContado(ByVal iIDGuia_Envio As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            Dim ds As New DataSet
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.SP_VER_VENTACONTADO_II", CommandType.StoredProcedure)
            db.AsignarParametro("vi_Idfactura", iIDGuia_Envio.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_data", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Volumetrico", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_Documentos", OracleClient.OracleType.Cursor) '3
            db.AsignarParametro("co_condicion_tarifa", OracleClient.OracleType.Cursor) '4
            db.AsignarParametro("co_Consignado", OracleClient.OracleType.Cursor) '5
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '6
            db.Desconectar()
            ds = db.EjecutarDataSet

            '--------Propagando el error----------------------------------
            If ds.Tables(6).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(6).Rows(0).Item(0)) Then
                    If ds.Tables(6).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(6).Rows(0).Item(1))
                    End If
                End If
            End If
            '-------------------------------------------------------------1
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function GrabarGuiaCredito(ByVal IDGUIAS_ENVIO As String, ByVal sFECHA_GUIA As String, ByVal sNRO_GUIA As String, _
                                      ByVal iIDTIPO_ENTREGA_CARGA As Integer, ByVal iIDFORMA_PAGO As Integer, ByVal iIDUNIDAD_AGENCIA As Integer, _
                                      ByVal iIDCIUDAD_TRANSITO As Integer, ByVal iIDUNIDAD_AGENCIA_DESTINO As Integer, ByVal iIDAGENCIAS As Integer, _
                                      ByVal iIDCONTACTO_REMITENTE As String, ByVal iIDDIRECCION_REMITENTE As String, ByVal iIDTELEFONO_REMITENTE As String, _
                                      ByVal iIDCONTACTO_DESTINATARIO As String, ByVal iIDDIRECCION_DESTINATARIO As String, ByVal iIDTELEFONO_CONSIGNADO As String, _
                                      ByVal dMONTO_BASE As Double, ByVal dTOTAL_PESO As Double, ByVal iCANTIDAD As Integer, ByVal dTOTAL_VOLUMEN As Double, _
                                      ByVal iCANTIDAD_X_UNIDAD_VOLUMEN As Integer, ByVal iCANTIDAD_X_UNIDAD_ARTI As Integer, ByVal dPRECIO_X_UNIDAD As Double, _
                                      ByVal dIMPUESTO As Double, ByVal dMONTO_IMPUESTO As Double, ByVal dTOTAL_COSTO As Double, ByVal iIDUSUARIO_PERSONAL As Integer, _
                                      ByVal iIDROL_USUARIO As Integer, ByVal sIP As String, ByVal iIDESTADO_REGISTRO As Integer, ByVal sNOMBRES_REMITENTE As String, _
                                      ByVal iDNI_REMITENTE As String, ByVal iDIRECCION_REMITENTE As String, ByVal iNOMBRES_DESTINATARIO As String, _
                                      ByVal sDNI_DESTINATARIO As String, ByVal sDIRECCION_DESTINATARIO As String, ByVal dPrecio_x_Volumen As Double, _
                                      ByVal dPrecio_x_Peso As Double, ByVal dPrecioSobre As Double, ByVal iCARGO As Integer, ByVal sTelefono_Remitente As String, _
                                      ByVal sTelefono_Destinatario As String, ByVal sID_REMITENTE As String, ByVal sREMITENTE As String, _
                                      ByVal iNRODOC_REM As String, ByVal iIDCENTRO_COSTO As Integer, ByVal iCANTIDAD_SOBRES As Integer, _
                                      ByVal iIDSINO_SOBRES As Integer, ByVal iIDAGENCIAS_DESTINO As Integer, ByVal ClienteModificado As Integer, _
                                      ByVal iIDPERSONA As Integer, ByVal sNombresCliente As String, ByVal sNumeroDocumentoCliente As String, ByVal iIDTipoDocumentoCliente As Integer, _
                                      ByVal sNombreCliente As String, ByVal sApellidoPaternoCliente As String, ByVal sApellidoMaternoCliente As String, ByVal sTelefonoCliente As String, _
                                      ByVal RemitenteModificado As Integer, ByVal iIDRemitente As Integer, ByVal sNombresRemitente As String, _
                                      ByVal sNumeroDocumentoRemitente As String, ByVal iIDTipoDocumentoRemitente As Integer, ByVal sNombreRemitente As String, _
                                      ByVal sApellidoPaternoRemitente As String, ByVal sApellidoMaternoRemitente As String, _
                                      ByVal ContactoModificado As Integer, ByVal iIDcontacto As Integer, ByVal sNombresContacto As String, _
                                      ByVal sNumeroDocumentoContacto As String, ByVal iIDTipoDocumentoContacto As Integer, ByVal sNombreContacto As String, _
                                      ByVal sApellidoPaternoContacto As String, ByVal sApellidoMaternoContacto As String, _
                                      ByVal ConsignadoModificado As String, ByVal iIDConsignado As String, ByVal sNombresConsignado As String, _
                                      ByVal sNumeroDocumentoConsignado As String, ByVal iIDTipoDocumentoConsignado As String, ByVal sNombreConsignado As String, _
                                      ByVal sApellidoPaternoConsignado As String, ByVal sApellidoMaternoConsignado As String, ByVal sTelefonoConsignado As String, _
                                      ByVal DireccionCliente_Mod As Integer, ByVal id_DepartamentoCli As Integer, ByVal id_ProvinciaCli As Integer, _
                                      ByVal id_DistritoCli As Integer, ByVal id_viaCli As Integer, ByVal viaCli As String, ByVal NumeroCli As String, ByVal manzanaCli As String, _
                                      ByVal loteCli As String, ByVal id_nivelCli As Integer, ByVal nivelCli As String, ByVal id_zonaCli As Integer, ByVal zonaCli As String, _
                                      ByVal id_clasificacionCli As Integer, ByVal clasificacionCli As String, _
                                      ByVal DireccionConsignado_Mod As Integer, ByVal id_DepartamentoConsig As Integer, ByVal id_ProvinciaConsig As Integer, _
                                      ByVal id_DistritoConsig As Integer, ByVal id_viaConsig As Integer, ByVal viaConsig As String, ByVal NumeroConsig As String, _
                                      ByVal manzanaConsig As String, ByVal loteConsig As String, ByVal id_nivelConsig As Integer, ByVal nivelConsig As String, _
                                      ByVal id_zonaConsig As Integer, ByVal zonaConsig As String, ByVal id_clasificacionConsig As Integer, _
                                      ByVal clasificacionConsig As String, ByVal sEmail As String, ByVal sReferencia As String, ByVal iMETROCUBICO As Integer, _
                                      ByVal iDescuento As Double, ByVal sAutoriza As String, ByVal TipoTarifa As Integer, ByVal ObservacionCargo As String, _
                                      Optional ByVal iControl As Integer = 1, _
                                      Optional ByVal idProcesos As Integer = 0, _
                                      Optional ByVal iDT As String = "", _
                                      Optional ByVal iIDCENTRO_COSTO_ORIGEN As Integer = 0, _
                                      Optional ByVal FechaRecojo As String = "") As Boolean
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 22-02-2019
            'db.CrearComando("PKG_GUIA_ENVIO_2.SP_INS_GUIAS_ENVIO_XII", CommandType.StoredProcedure)
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_grabar_ge", CommandType.StoredProcedure)
            db.AsignarParametro("iIDPROCESOS", idProcesos, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_control", iControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("xiIDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("sFECHA_GUIA", sFECHA_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("sNRO_GUIA", sNRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_ENTREGA_CARGA", iIDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDFORMA_PAGO", iIDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCIUDAD_TRANSITO", iIDCIUDAD_TRANSITO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)

            '-->Para el dt de quimimca siuza - 10/09/2013
            db.AsignarParametro("iIDT", iDT, OracleClient.OracleType.VarChar)
            '-->Para la subCuenta Origen Eckerd - 14/09/2013
            db.AsignarParametro("iIDCENTRO_COSTO_ORIGEN", iIDCENTRO_COSTO_ORIGEN, OracleClient.OracleType.Int32)

            db.AsignarParametro("x_iIDCONTACTO_REMITENTE", iIDCONTACTO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_REMITENTE", iIDDIRECCION_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_REMITENTE", iIDTELEFONO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDCONTACTO_DESTINATARIO", iIDCONTACTO_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_DESTINATARIO", iIDDIRECCION_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_CONSIGNADO", iIDTELEFONO_CONSIGNADO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("dMONTO_BASE", dMONTO_BASE, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_PESO", dTOTAL_PESO, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD", iCANTIDAD, OracleClient.OracleType.Int32)
            db.AsignarParametro("dTOTAL_VOLUMEN", dTOTAL_VOLUMEN, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_VOLUMEN", iCANTIDAD_X_UNIDAD_VOLUMEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_ARTI", iCANTIDAD_X_UNIDAD_ARTI, OracleClient.OracleType.Int32)
            db.AsignarParametro("dPRECIO_X_UNIDAD", dPRECIO_X_UNIDAD, OracleClient.OracleType.Number)
            db.AsignarParametro("dIMPUESTO", dIMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dMONTO_IMPUESTO", dMONTO_IMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_COSTO", dTOTAL_COSTO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRES_REMITENTE", sNOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_REMITENTE", iDNI_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_REMITENTE", iDIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNOMBRES_DESTINATARIO", iNOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_DESTINATARIO", sDNI_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_DESTINATARIO", sDIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iPrecio_x_Peso", dPrecio_x_Peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_PrecioSobre", dPrecioSobre, OracleClient.OracleType.Number)
            db.AsignarParametro("iPrecio_x_Volumen", dPrecio_x_Volumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iCARGO", iCARGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTelefono_Remitente", "@", OracleClient.OracleType.VarChar) 'sTelefono_Remitente
            db.AsignarParametro("iTelefono_Destinatario", "@", OracleClient.OracleType.VarChar) 'sTelefono_Destinatario
            db.AsignarParametro("x_iID_REMITENTE", sID_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("iREMITENTE", sREMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNRODOC_REM", iNRODOC_REM, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDCENTRO_COSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCANTIDAD_SOBRES", iCANTIDAD_SOBRES, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDSINO_SOBRES", iIDSINO_SOBRES, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDAGENCIAS_DESTINO", iIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MetroCubico", iMETROCUBICO, OracleClient.OracleType.Int32)

            '--Nuevos Parametros---
            '===CLIENTE==== 
            db.AsignarParametro("ni_ClienteModificado", ClienteModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("xiIDPERSONA", iIDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresCliente", sNombresCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoCliente", sNumeroDocumentoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoCliente", iIDTipoDocumentoCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreCliente", sNombreCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoCliente", sApellidoPaternoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoCliente", sApellidoMaternoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelefonoCliente", sTelefonoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Email", sEmail, OracleClient.OracleType.VarChar) '07092011 Nuevo Parametro
            '===REMITENTE==     
            db.AsignarParametro("ni_RemitenteModificado", RemitenteModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDRemitente", iIDRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresRemitente", sNombresRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoRemitente", sNumeroDocumentoRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoRemitente", iIDTipoDocumentoRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreRemitente", sNombreRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoRemitente", sApellidoPaternoRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoRemitente", sApellidoMaternoRemitente, OracleClient.OracleType.VarChar)

            '==CONTACTO====
            db.AsignarParametro("ni_ContactoModificado", ContactoModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDContacto", iIDcontacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresContacto", sNombresContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoContacto", sNumeroDocumentoContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoContacto", iIDTipoDocumentoContacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreContacto", sNombreContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoContacto", sApellidoPaternoContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoContacto", sApellidoMaternoContacto, OracleClient.OracleType.VarChar)
            '==CONSIGNADO==     
            db.AsignarParametro("v_IDConsignado", iIDConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombresConsignado", sNombresConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombreConsignado", sNombreConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoConsignado", sApellidoPaternoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoConsignado", sApellidoMaternoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoConsignado", sNumeroDocumentoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoConsignado", iIDTipoDocumentoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelefonoConsignado", sTelefonoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ConsignadoModificado", ConsignadoModificado, OracleClient.OracleType.VarChar)

            '==DIRECCION ESTRUCTURADA CLIENTE (REMITENTE)      
            db.AsignarParametro("ni_DireccionCliente_Mod", DireccionCliente_Mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)

            'DIRECCION ESTRUCTURADA CONSIGNADO (DESTINATARIO)       
            db.AsignarParametro("ni_DireccionConsignado_Mod", DireccionConsignado_Mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            db.AsignarParametro("ni_descuento", iDescuento, OracleClient.OracleType.Number) '07092011  Nuevo Parametro
            db.AsignarParametro("vi_autoriza", sAutoriza, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            '-----
            'hlamas 24-04-2014
            db.AsignarParametro("ni_tipo_tarifa", TipoTarifa, OracleClient.OracleType.Int32) '2404201  Nuevo Parametro
            'hlamas 26-08-2015
            db.AsignarParametro("vi_observacion_cargo", ObservacionCargo, OracleClient.OracleType.VarChar) '2404201  Nuevo Parametro
            'hlamas 07-02-2019
            db.AsignarParametro("vi_fecha_recojo", FechaRecojo, OracleClient.OracleType.VarChar) '2404201  Nuevo Parametro

            db.AsignarParametro("curr_datos_Guia_Envio", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            '===Codigo de barras======
            If ds.Tables(0).Rows.Count > 0 And IsDBNull(ds.Tables(0).Rows(0).Item(0)) = False Then
                MessageBox.Show(ds.Tables(0).Rows(0).Item(1).ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If ds.Tables(0).Rows(0).Item(0) > 0 Then
                    iIDGUIAS_ENVIO = ds.Tables(0).Rows(0).Item(0)
                    guia = ds.Tables(0).Rows(0).Item(2)
                    barra = ds.Tables(0).Rows(0).Item(3)
                    dt_cur_codBarras = ds.Tables(1)
                    flat = True
                End If
            End If

            '===Propagando el error===
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    If ds.Tables(1).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(1).Rows(0).Item(1))
                        flat = False
                    End If
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    Public Function GrabarGuiaCredito_I(ByVal IDGUIAS_ENVIO As String, ByVal sFECHA_GUIA As String, ByVal sNRO_GUIA As String, _
                                      ByVal iIDTIPO_ENTREGA_CARGA As Integer, ByVal iIDFORMA_PAGO As Integer, ByVal iIDUNIDAD_AGENCIA As Integer, _
                                      ByVal iIDCIUDAD_TRANSITO As Integer, ByVal iIDUNIDAD_AGENCIA_DESTINO As Integer, ByVal iIDAGENCIAS As Integer, _
                                      ByVal iIDCONTACTO_REMITENTE As String, ByVal iIDDIRECCION_REMITENTE As String, ByVal iIDTELEFONO_REMITENTE As String, _
                                      ByVal iIDCONTACTO_DESTINATARIO As String, ByVal iIDDIRECCION_DESTINATARIO As String, ByVal iIDTELEFONO_CONSIGNADO As String, _
                                      ByVal dMONTO_BASE As Double, ByVal dTOTAL_PESO As Double, ByVal iCANTIDAD As Integer, ByVal dTOTAL_VOLUMEN As Double, _
                                      ByVal iCANTIDAD_X_UNIDAD_VOLUMEN As Integer, ByVal iCANTIDAD_X_UNIDAD_ARTI As Integer, ByVal dPRECIO_X_UNIDAD As Double, _
                                      ByVal dIMPUESTO As Double, ByVal dMONTO_IMPUESTO As Double, ByVal dTOTAL_COSTO As Double, ByVal iIDUSUARIO_PERSONAL As Integer, _
                                      ByVal iIDROL_USUARIO As Integer, ByVal sIP As String, ByVal iIDESTADO_REGISTRO As Integer, ByVal sNOMBRES_REMITENTE As String, _
                                      ByVal iDNI_REMITENTE As String, ByVal iDIRECCION_REMITENTE As String, ByVal iNOMBRES_DESTINATARIO As String, _
                                      ByVal sDNI_DESTINATARIO As String, ByVal sDIRECCION_DESTINATARIO As String, ByVal dPrecio_x_Volumen As Double, _
                                      ByVal dPrecio_x_Peso As Double, ByVal dPrecioSobre As Double, ByVal iCARGO As Integer, ByVal sTelefono_Remitente As String, _
                                      ByVal sTelefono_Destinatario As String, ByVal sID_REMITENTE As String, ByVal sREMITENTE As String, _
                                      ByVal iNRODOC_REM As String, ByVal iIDCENTRO_COSTO As Integer, ByVal iCANTIDAD_SOBRES As Integer, _
                                      ByVal iIDSINO_SOBRES As Integer, ByVal iIDAGENCIAS_DESTINO As Integer, ByVal ClienteModificado As Integer, _
                                      ByVal iIDPERSONA As Integer, ByVal sNombresCliente As String, ByVal sNumeroDocumentoCliente As String, ByVal iIDTipoDocumentoCliente As Integer, _
                                      ByVal sNombreCliente As String, ByVal sApellidoPaternoCliente As String, ByVal sApellidoMaternoCliente As String, ByVal sTelefonoCliente As String, _
                                      ByVal RemitenteModificado As Integer, ByVal iIDRemitente As Integer, ByVal sNombresRemitente As String, _
                                      ByVal sNumeroDocumentoRemitente As String, ByVal iIDTipoDocumentoRemitente As Integer, ByVal sNombreRemitente As String, _
                                      ByVal sApellidoPaternoRemitente As String, ByVal sApellidoMaternoRemitente As String, _
                                      ByVal ContactoModificado As Integer, ByVal iIDcontacto As Integer, ByVal sNombresContacto As String, _
                                      ByVal sNumeroDocumentoContacto As String, ByVal iIDTipoDocumentoContacto As Integer, ByVal sNombreContacto As String, _
                                      ByVal sApellidoPaternoContacto As String, ByVal sApellidoMaternoContacto As String, _
                                      ByVal ConsignadoModificado As String, ByVal iIDConsignado As String, ByVal sNombresConsignado As String, _
                                      ByVal sNumeroDocumentoConsignado As String, ByVal iIDTipoDocumentoConsignado As String, ByVal sNombreConsignado As String, _
                                      ByVal sApellidoPaternoConsignado As String, ByVal sApellidoMaternoConsignado As String, ByVal sTelefonoConsignado As String, _
                                      ByVal DireccionCliente_Mod As Integer, ByVal id_DepartamentoCli As Integer, ByVal id_ProvinciaCli As Integer, _
                                      ByVal id_DistritoCli As Integer, ByVal id_viaCli As Integer, ByVal viaCli As String, ByVal NumeroCli As String, ByVal manzanaCli As String, _
                                      ByVal loteCli As String, ByVal id_nivelCli As Integer, ByVal nivelCli As String, ByVal id_zonaCli As Integer, ByVal zonaCli As String, _
                                      ByVal id_clasificacionCli As Integer, ByVal clasificacionCli As String, _
                                      ByVal DireccionConsignado_Mod As Integer, ByVal id_DepartamentoConsig As Integer, ByVal id_ProvinciaConsig As Integer, _
                                      ByVal id_DistritoConsig As Integer, ByVal id_viaConsig As Integer, ByVal viaConsig As String, ByVal NumeroConsig As String, _
                                      ByVal manzanaConsig As String, ByVal loteConsig As String, ByVal id_nivelConsig As Integer, ByVal nivelConsig As String, _
                                      ByVal id_zonaConsig As Integer, ByVal zonaConsig As String, ByVal id_clasificacionConsig As Integer, _
                                      ByVal clasificacionConsig As String, ByVal sEmail As String, ByVal sReferencia As String, ByVal iMETROCUBICO As Integer, _
                                      ByVal iDescuento As Double, ByVal sAutoriza As String, ByVal iIDUsuarioRemoto As Integer, ByVal TipoTarifa As Integer, _
                                      Optional ByVal iControl As Integer = 1, Optional ByVal iIDProcesos As Integer = 0, _
                                      Optional ByVal iDT As String = "", _
                                      Optional ByVal iIDCENTRO_COSTO_ORIGEN As Integer = 0, _
                                      Optional ByVal FechaRecojo As String = "") As Boolean
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 11-03-2019
            'db.CrearComando("PKG_GUIA_ENVIO_2.SP_INS_GUIAS_ENVIO_XI", CommandType.StoredProcedure)
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_grabar_ge_man", CommandType.StoredProcedure)
            db.AsignarParametro("iIDPROCESOS", iIDProcesos, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_control", iControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("xiIDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("sFECHA_GUIA", sFECHA_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("sNRO_GUIA", sNRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_ENTREGA_CARGA", iIDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDFORMA_PAGO", iIDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCIUDAD_TRANSITO", iIDCIUDAD_TRANSITO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)

            '-->Para el dt de quimimca siuza - 10/09/2013
            db.AsignarParametro("iIDT", iDT, OracleClient.OracleType.VarChar)
            '-->Para la subCuenta Origen Eckerd - 14/09/2013
            db.AsignarParametro("iIDCENTRO_COSTO_ORIGEN", iIDCENTRO_COSTO_ORIGEN, OracleClient.OracleType.Int32)

            db.AsignarParametro("x_iIDCONTACTO_REMITENTE", iIDCONTACTO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_REMITENTE", iIDDIRECCION_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_REMITENTE", iIDTELEFONO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDCONTACTO_DESTINATARIO", iIDCONTACTO_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_DESTINATARIO", iIDDIRECCION_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_CONSIGNADO", iIDTELEFONO_CONSIGNADO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("dMONTO_BASE", dMONTO_BASE, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_PESO", dTOTAL_PESO, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD", iCANTIDAD, OracleClient.OracleType.Int32)
            db.AsignarParametro("dTOTAL_VOLUMEN", dTOTAL_VOLUMEN, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_VOLUMEN", iCANTIDAD_X_UNIDAD_VOLUMEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_ARTI", iCANTIDAD_X_UNIDAD_ARTI, OracleClient.OracleType.Int32)
            db.AsignarParametro("dPRECIO_X_UNIDAD", dPRECIO_X_UNIDAD, OracleClient.OracleType.Number)
            db.AsignarParametro("dIMPUESTO", dIMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dMONTO_IMPUESTO", dMONTO_IMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_COSTO", dTOTAL_COSTO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRES_REMITENTE", sNOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_REMITENTE", iDNI_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_REMITENTE", iDIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNOMBRES_DESTINATARIO", iNOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_DESTINATARIO", sDNI_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_DESTINATARIO", sDIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iPrecio_x_Peso", dPrecio_x_Peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_PrecioSobre", dPrecioSobre, OracleClient.OracleType.Number)
            db.AsignarParametro("iPrecio_x_Volumen", dPrecio_x_Volumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iCARGO", iCARGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTelefono_Remitente", "@", OracleClient.OracleType.VarChar) 'sTelefono_Remitente
            db.AsignarParametro("iTelefono_Destinatario", "@", OracleClient.OracleType.VarChar) 'sTelefono_Destinatario
            db.AsignarParametro("x_iID_REMITENTE", sID_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("iREMITENTE", sREMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNRODOC_REM", iNRODOC_REM, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDCENTRO_COSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCANTIDAD_SOBRES", iCANTIDAD_SOBRES, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDSINO_SOBRES", iIDSINO_SOBRES, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDAGENCIAS_DESTINO", iIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MetroCubico", iMETROCUBICO, OracleClient.OracleType.Int32)

            '--Nuevos Parametros---
            '===CLIENTE==== 
            db.AsignarParametro("ni_ClienteModificado", ClienteModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("xiIDPERSONA", iIDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresCliente", sNombresCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoCliente", sNumeroDocumentoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoCliente", iIDTipoDocumentoCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreCliente", sNombreCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoCliente", sApellidoPaternoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoCliente", sApellidoMaternoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelefonoCliente", sTelefonoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Email", sEmail, OracleClient.OracleType.VarChar) '07092011 Nuevo Parametro
            '===REMITENTE==     
            db.AsignarParametro("ni_RemitenteModificado", RemitenteModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDRemitente", iIDRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresRemitente", sNombresRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoRemitente", sNumeroDocumentoRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoRemitente", iIDTipoDocumentoRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreRemitente", sNombreRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoRemitente", sApellidoPaternoRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoRemitente", sApellidoMaternoRemitente, OracleClient.OracleType.VarChar)

            '==CONTACTO====
            db.AsignarParametro("ni_ContactoModificado", ContactoModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDContacto", iIDcontacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresContacto", sNombresContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoContacto", sNumeroDocumentoContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoContacto", iIDTipoDocumentoContacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreContacto", sNombreContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoContacto", sApellidoPaternoContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoContacto", sApellidoMaternoContacto, OracleClient.OracleType.VarChar)
            '==CONSIGNADO==     
            db.AsignarParametro("v_IDConsignado", iIDConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombresConsignado", sNombresConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombreConsignado", sNombreConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoConsignado", sApellidoPaternoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoConsignado", sApellidoMaternoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoConsignado", sNumeroDocumentoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoConsignado", iIDTipoDocumentoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelefonoConsignado", sTelefonoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ConsignadoModificado", ConsignadoModificado, OracleClient.OracleType.VarChar)

            '==DIRECCION ESTRUCTURADA CLIENTE (REMITENTE)      
            db.AsignarParametro("ni_DireccionCliente_Mod", DireccionCliente_Mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)

            'DIRECCION ESTRUCTURADA CONSIGNADO (DESTINATARIO)
            db.AsignarParametro("ni_DireccionConsignado_Mod", DireccionConsignado_Mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            db.AsignarParametro("ni_descuento", iDescuento, OracleClient.OracleType.Number) '07092011  Nuevo Parametro
            db.AsignarParametro("vi_autoriza", sAutoriza, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            db.AsignarParametro("ni_IDUsuarioRemoto", iIDUsuarioRemoto, OracleClient.OracleType.Int32)
            '-----
            'hlamas 24-04-2014
            db.AsignarParametro("ni_tipo_tarifa", TipoTarifa, OracleClient.OracleType.Int32) '2404201  Nuevo Parametro
            'hlamas 07-02-2019
            db.AsignarParametro("vi_fecha_recojo", FechaRecojo, OracleClient.OracleType.VarChar) '2404201  Nuevo Parametro

            db.AsignarParametro("curr_datos_Guia_Envio", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            '===Codigo de barras======
            If ds.Tables(0).Rows.Count > 0 And IsDBNull(ds.Tables(0).Rows(0).Item(0)) = False Then
                MessageBox.Show(ds.Tables(0).Rows(0).Item(1).ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If ds.Tables(0).Rows(0).Item(0) > 0 Then
                    iIDGUIAS_ENVIO = ds.Tables(0).Rows(0).Item(0)
                    dt_cur_codBarras = ds.Tables(1)
                    flat = True
                End If
            End If

            '===Propagando el error===
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    If ds.Tables(1).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(1).Rows(0).Item(1))
                        flat = False
                    End If
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    Public Function ActualizarCredito(ByVal IDGUIAS_ENVIO As String, ByVal sFECHA_GUIA As String, ByVal sNRO_GUIA As String, _
                                      ByVal iIDTIPO_ENTREGA_CARGA As Integer, ByVal iIDFORMA_PAGO As Integer, ByVal iIDUNIDAD_AGENCIA As Integer, _
                                      ByVal iIDCIUDAD_TRANSITO As Integer, ByVal iIDUNIDAD_AGENCIA_DESTINO As Integer, ByVal iIDAGENCIAS As Integer, _
                                      ByVal iIDCONTACTO_REMITENTE As String, ByVal iIDDIRECCION_REMITENTE As String, ByVal iIDTELEFONO_REMITENTE As String, _
                                      ByVal iIDCONTACTO_DESTINATARIO As String, ByVal iIDDIRECCION_DESTINATARIO As String, ByVal iIDTELEFONO_CONSIGNADO As String, _
                                      ByVal dMONTO_BASE As Double, ByVal dTOTAL_PESO As Double, ByVal iCANTIDAD As Integer, ByVal dTOTAL_VOLUMEN As Double, _
                                      ByVal iCANTIDAD_X_UNIDAD_VOLUMEN As Integer, ByVal iCANTIDAD_X_UNIDAD_ARTI As Integer, ByVal dPRECIO_X_UNIDAD As Double, _
                                      ByVal dIMPUESTO As Double, ByVal dMONTO_IMPUESTO As Double, ByVal dTOTAL_COSTO As Double, ByVal iIDUSUARIO_PERSONAL As Integer, _
                                      ByVal iIDROL_USUARIO As Integer, ByVal sIP As String, ByVal iIDESTADO_REGISTRO As Integer, ByVal sNOMBRES_REMITENTE As String, _
                                      ByVal iDNI_REMITENTE As String, ByVal iDIRECCION_REMITENTE As String, ByVal iNOMBRES_DESTINATARIO As String, _
                                      ByVal sDNI_DESTINATARIO As String, ByVal sDIRECCION_DESTINATARIO As String, ByVal dPrecio_x_Volumen As Double, _
                                      ByVal dPrecio_x_Peso As Double, ByVal dPrecioSobre As Double, ByVal iCARGO As Integer, ByVal sTelefono_Remitente As String, _
                                      ByVal sTelefono_Destinatario As String, ByVal sID_REMITENTE As String, ByVal sREMITENTE As String, _
                                      ByVal iNRODOC_REM As String, ByVal iIDCENTRO_COSTO As Integer, ByVal iCANTIDAD_SOBRES As Integer, _
                                      ByVal iIDSINO_SOBRES As Integer, ByVal iIDAGENCIAS_DESTINO As Integer, ByVal ClienteModificado As Integer, _
                                      ByVal iIDPERSONA As Integer, ByVal sNombresCliente As String, ByVal sNumeroDocumentoCliente As String, ByVal iIDTipoDocumentoCliente As Integer, _
                                      ByVal sNombreCliente As String, ByVal sApellidoPaternoCliente As String, ByVal sApellidoMaternoCliente As String, ByVal sTelefonoCliente As String, _
                                      ByVal RemitenteModificado As Integer, ByVal iIDRemitente As Integer, ByVal sNombresRemitente As String, _
                                      ByVal sNumeroDocumentoRemitente As String, ByVal iIDTipoDocumentoRemitente As Integer, ByVal sNombreRemitente As String, _
                                      ByVal sApellidoPaternoRemitente As String, ByVal sApellidoMaternoRemitente As String, _
                                      ByVal ContactoModificado As Integer, ByVal iIDcontacto As Integer, ByVal sNombresContacto As String, _
                                      ByVal sNumeroDocumentoContacto As String, ByVal iIDTipoDocumentoContacto As Integer, ByVal sNombreContacto As String, _
                                      ByVal sApellidoPaternoContacto As String, ByVal sApellidoMaternoContacto As String, _
                                      ByVal ConsignadoModificado As String, ByVal iIDConsignado As String, ByVal sNombresConsignado As String, _
                                      ByVal sNumeroDocumentoConsignado As String, ByVal iIDTipoDocumentoConsignado As String, ByVal sNombreConsignado As String, _
                                      ByVal sApellidoPaternoConsignado As String, ByVal sApellidoMaternoConsignado As String, ByVal sTelefonoConsignado As String, ByVal sIDVentaConsignado As String, _
                                      ByVal DireccionCliente_Mod As Integer, ByVal id_DepartamentoCli As Integer, ByVal id_ProvinciaCli As Integer, _
                                      ByVal id_DistritoCli As Integer, ByVal id_viaCli As Integer, ByVal viaCli As String, ByVal NumeroCli As String, ByVal manzanaCli As String, _
                                      ByVal loteCli As String, ByVal id_nivelCli As Integer, ByVal nivelCli As String, ByVal id_zonaCli As Integer, ByVal zonaCli As String, _
                                      ByVal id_clasificacionCli As Integer, ByVal clasificacionCli As String, _
                                      ByVal DireccionConsignado_Mod As Integer, ByVal id_DepartamentoConsig As Integer, ByVal id_ProvinciaConsig As Integer, _
                                      ByVal id_DistritoConsig As Integer, ByVal id_viaConsig As Integer, ByVal viaConsig As String, ByVal NumeroConsig As String, _
                                      ByVal manzanaConsig As String, ByVal loteConsig As String, ByVal id_nivelConsig As Integer, ByVal nivelConsig As String, _
                                      ByVal id_zonaConsig As Integer, ByVal zonaConsig As String, ByVal id_clasificacionConsig As Integer, _
                                      ByVal clasificacionConsig As String, ByVal sEmail As String, ByVal sReferencia As String, ByVal iMETROCUBICO As Integer, ByVal TipoTarifa As Integer, _
                                      Optional ByVal iControl As Integer = 1) As Boolean
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.SP_ACTUALIZAR_CREDITO", CommandType.StoredProcedure)
            'db.AsignarParametro("ni_control", iControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("xiIDGUIAS_ENVIO", IDGUIAS_ENVIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("sFECHA_GUIA", sFECHA_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("sNRO_GUIA", sNRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_ENTREGA_CARGA", iIDTIPO_ENTREGA_CARGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDFORMA_PAGO", iIDFORMA_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA", iIDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCIUDAD_TRANSITO", iIDCIUDAD_TRANSITO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", iIDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("x_iIDCONTACTO_REMITENTE", iIDCONTACTO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_REMITENTE", iIDDIRECCION_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_REMITENTE", iIDTELEFONO_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDCONTACTO_DESTINATARIO", iIDCONTACTO_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDDIRECCION_DESTINATARIO", iIDDIRECCION_DESTINATARIO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("x_iIDTEFONO_CONSIGNADO", iIDTELEFONO_CONSIGNADO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("dMONTO_BASE", dMONTO_BASE, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_PESO", dTOTAL_PESO, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD", iCANTIDAD, OracleClient.OracleType.Int32)
            db.AsignarParametro("dTOTAL_VOLUMEN", dTOTAL_VOLUMEN, OracleClient.OracleType.Number)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_VOLUMEN", iCANTIDAD_X_UNIDAD_VOLUMEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCANTIDAD_X_UNIDAD_ARTI", iCANTIDAD_X_UNIDAD_ARTI, OracleClient.OracleType.Int32)
            db.AsignarParametro("dPRECIO_X_UNIDAD", dPRECIO_X_UNIDAD, OracleClient.OracleType.Number)
            db.AsignarParametro("dIMPUESTO", dIMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dMONTO_IMPUESTO", dMONTO_IMPUESTO, OracleClient.OracleType.Number)
            db.AsignarParametro("dTOTAL_COSTO", dTOTAL_COSTO, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRES_REMITENTE", sNOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_REMITENTE", iDNI_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_REMITENTE", iDIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNOMBRES_DESTINATARIO", iNOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI_DESTINATARIO", sDNI_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDIRECCION_DESTINATARIO", sDIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iPrecio_x_Peso", dPrecio_x_Peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_PrecioSobre", dPrecioSobre, OracleClient.OracleType.Number)
            db.AsignarParametro("iPrecio_x_Volumen", dPrecio_x_Volumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iCARGO", iCARGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTelefono_Remitente", "@", OracleClient.OracleType.VarChar) 'sTelefono_Remitente
            db.AsignarParametro("iTelefono_Destinatario", "@", OracleClient.OracleType.VarChar) 'sTelefono_Destinatario
            db.AsignarParametro("x_iID_REMITENTE", sID_REMITENTE.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("iREMITENTE", sREMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNRODOC_REM", iNRODOC_REM, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDCENTRO_COSTO", iIDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCANTIDAD_SOBRES", iCANTIDAD_SOBRES, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDSINO_SOBRES", iIDSINO_SOBRES, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDAGENCIAS_DESTINO", iIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MetroCubico", iMETROCUBICO, OracleClient.OracleType.Int32)

            '--Nuevos Parametros---
            '===CLIENTE==== 
            db.AsignarParametro("ni_ClienteModificado", ClienteModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("xiIDPERSONA", iIDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresCliente", sNombresCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoCliente", sNumeroDocumentoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoCliente", iIDTipoDocumentoCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreCliente", sNombreCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoCliente", sApellidoPaternoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoCliente", sApellidoMaternoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelefonoCliente", sTelefonoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Email", sEmail, OracleClient.OracleType.VarChar) '07092011 Nuevo Parametro
            '===REMITENTE==     
            db.AsignarParametro("ni_RemitenteModificado", RemitenteModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDRemitente", iIDRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresRemitente", sNombresRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoRemitente", sNumeroDocumentoRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoRemitente", iIDTipoDocumentoRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreRemitente", sNombreRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoRemitente", sApellidoPaternoRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoRemitente", sApellidoMaternoRemitente, OracleClient.OracleType.VarChar)

            '==CONTACTO====
            db.AsignarParametro("ni_ContactoModificado", ContactoModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDContacto", iIDcontacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresContacto", sNombresContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoContacto", sNumeroDocumentoContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoContacto", iIDTipoDocumentoContacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreContacto", sNombreContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoContacto", sApellidoPaternoContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoContacto", sApellidoMaternoContacto, OracleClient.OracleType.VarChar)
            '==CONSIGNADO==     
            db.AsignarParametro("v_IDConsignado", iIDConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombresConsignado", sNombresConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombreConsignado", sNombreConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoPaternoConsignado", sApellidoPaternoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoConsignado", sApellidoMaternoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumentoConsignado", sNumeroDocumentoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocumentoConsignado", iIDTipoDocumentoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelefonoConsignado", sTelefonoConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDVentaConsignado", sIDVentaConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ConsignadoModificado", ConsignadoModificado, OracleClient.OracleType.VarChar)

            '==DIRECCION ESTRUCTURADA CLIENTE (REMITENTE)      
            db.AsignarParametro("ni_DireccionCliente_Mod", DireccionCliente_Mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)

            'DIRECCION ESTRUCTURADA CONSIGNADO (DESTINATARIO)       
            db.AsignarParametro("ni_DireccionConsignado_Mod", DireccionConsignado_Mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            db.AsignarParametro("v_tipo_tarifa", TipoTarifa, OracleClient.OracleType.Int32) '07092011  Nuevo Parametro
            '-----
            db.AsignarParametro("curr_datos_Guia_Envio", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            '===Codigo de barras======
            If ds.Tables(0).Rows.Count > 0 And IsDBNull(ds.Tables(0).Rows(0).Item(0)) = False Then
                MessageBox.Show(ds.Tables(0).Rows(0).Item(1).ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If ds.Tables(0).Rows(0).Item(0) > 0 Then
                    iIDGUIAS_ENVIO = ds.Tables(0).Rows(0).Item(0)
                    dt_cur_codBarras = ds.Tables(1)
                    flat = True
                End If
            End If

            '===Propagando el error===
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    If ds.Tables(1).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(1).Rows(0).Item(1))
                        flat = False
                    End If
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    'RECUPERACION DE PRE GUIA VENTA
    Function RecuperarPreGuiaVenta(ByVal NroGuiaEnvio As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOIMPRE_PRE_GUIAS.SP_RecuperarPreGuiaEnvio", CommandType.StoredProcedure)
            db.AsignarParametro("Nro_Guias_Envio", NroGuiaEnvio, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_Pre_Guia_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '6
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ValidarGuiaEnvioRetornoCliente(ByVal IdUnidadDestino As Integer, ByVal IdPersona As Integer, ByVal IdCentroCosto As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.SP_VALIDAR_GUIA_ENVIO_CLIENTE", CommandType.StoredProcedure)
            db.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", IdUnidadDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPERSONA", IdPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCENTRO_COSTO", IdCentroCosto, OracleClient.OracleType.Int32)
            db.AsignarParametro("CO_GUIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CO_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    ''' <summary>
    ''' OBTIENE LAS TARIFAS CREDITO
    ''' </summary>
    ''' <param name="idUnidadOrigen">Identificador de la ciudad origen</param>
    ''' <param name="idUnidadDestino">Identificador dela ciudad destino</param>
    ''' <param name="idTipoPorducto">Identificador del tipo de producto</param>
    ''' <param name="idTipoTarifa">Identificador del tipo de tarifa</param>
    ''' <returns>Objeto tarifa</returns>
    Public Function obtenerTarifas(ByVal idUnidadOrigen As Integer, ByVal idUnidadDestino As Integer, ByVal idPersona As Integer, _
                                   ByVal idTipoProducto As Integer, ByVal idTipoTarifa As Integer) As INTEGRACION_EN.Cls_TarifaClienteCargo
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        Dim PROCESO_TEPSA_BOX As Integer = 81
        db_bd.Conectar()

        db_bd.CrearComando("SP_TARIFA_PUBLICA_VC", CommandType.StoredProcedure)
        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", idUnidadOrigen, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", idUnidadDestino, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIDPERSONA", idPersona, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIPROCESO", idTipoProducto, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("ni_tarifa", idTipoTarifa, OracleClient.OracleType.Int32)
        'Variables de salidas 
        db_bd.AsignarParametro("cur_Tarifa_cliente", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
        'Desconectar
        db_bd.Desconectar()
        lds_tmp = db_bd.EjecutarDataSet()

        Dim tarifasClienteCargo As New INTEGRACION_EN.Cls_TarifaClienteCargo

        For Each rowTC As DataRow In lds_tmp.Tables(0).Rows
            tarifasClienteCargo.idTarifaCliente = rowTC("IDTARIFA_CLIENTE")
            tarifasClienteCargo.precioBase = IIf(IsDBNull(rowTC("N_BASE")), 0.0, rowTC("N_BASE"))
            tarifasClienteCargo.precioPeso = IIf(IsDBNull(rowTC("N_PESO")), 0.0, rowTC("N_PESO"))
            tarifasClienteCargo.precioVolumen = IIf(IsDBNull(rowTC("N_VOLUMEN")), 0.0, rowTC("N_VOLUMEN"))
            tarifasClienteCargo.precioSobre = IIf(IsDBNull(rowTC("N_SOBRE")), 0.0, rowTC("N_SOBRE"))
            tarifasClienteCargo.estadoTarifa = IIf(IsDBNull(rowTC("N_ESTADO_TARIFA")), 0, rowTC("N_ESTADO_TARIFA"))
            tarifasClienteCargo.idProceso = IIf(IsDBNull(rowTC("IDPROCEOS")), 0, rowTC("IDPROCEOS"))
        Next

        '--> Si no encuentra resultados
        If (lds_tmp.Tables(0).Rows.Count <= 0) Then tarifasClienteCargo = Nothing

        Return tarifasClienteCargo
    End Function

    Public Function ClienteDireccion(cliente As Integer, origen As Integer, destino As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_cliente_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ClientePersonalizado(cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_cliente_personalizado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Shared Function VenderEnCiudad(cliente As Integer, origen As Integer, destino As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("select sf_get_vender_en_ciudad(" & cliente & "," & origen & "," & destino & ") from dual", CommandType.Text)
            Dim intValor As Integer = db.EjecutarEscalar
            Return IIf(intValor = 1, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Sub CanjearRecojo(ByVal tipo As Integer, ByVal comprobante As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_recojo.sp_canjear_recojo", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

End Class

