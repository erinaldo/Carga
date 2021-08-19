Imports AccesoDatos
Public Class dtoVentaCargaContado
#Region "VARIBLES"
    Public iCONTROL As Integer
    Public v_IDFACTURA As Integer
    Public v_IDTIPO_COMPROBANTE As Integer
    Public v_SERIE_FACTURA As String
    Public v_NRO_FACTURA As String
    Public v_FECHA_FACTURA As String
    Public v_IDTIPO_PAGO As Integer
    Public v_IDFORMA_PAGO As Integer
    Public v_IDTARJETAS As Integer
    Public v_NROTARJETA As String
    Public v_IDUNIDAD_ORIGEN As Integer
    Public v_IDAGENCIAS As Integer
    Public v_IDUNIDAD_DESTINO As Integer
    Public v_IDAGENCIAS_DESTINO As Integer
    Public v_IDPERSONA As Integer
    Public v_NOMBRES_RASONSOCIAL As String
    Public v_NRO_DNI_RUC As String
    Public v_IDPROCESOS As Integer
    Public v_GUIA As String

    Public dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double

    Public v_IDPERSONA_ORIGEN As Integer
    Public v_Email As String
    Public v_Referencia As String
    Public v_NOMBRES_REMITENTE As String
    Public v_NRO_DOC_REMITENTE As String
    Public v_IDDIREECION_ORIGEN As Integer
    Public v_DIRECCION_REMITENTE As String
    Public v_TELEFONO_REMITENTE As String
    Public v_IDCONTACTO_DESTINO As String
    Public v_NRO_DOC_DESTINATARIO As String
    Public v_NOMBRES_DESTINATARIO As String
    Public v_DIRECCION_DESTINATARIO As String
    Public v_IDDIREECION_DESTINO As Integer
    Public v_TELEFONO_DESTINATARIO As String
    Public v_MEMO As String
    Public v_MONTO_DESCUENTO As Double
    Public v_CANTIDAD_X_PESO As Integer
    Public v_CANTIDAD_X_VOLUMEN As Integer
    Public v_CANTIDAD_X_SOBRE As Integer
    Public v_MONTO_BASE As Double
    Public v_PRECIO_X_PESO As Double
    Public v_PRECIO_X_VOLUMEN As Double
    Public v_PRECIO_X_SOBRE As Double

    Public v_TOTAL_PESO As Double
    Public v_TOTAL_VOLUMEN As Double

    Public v_MONTO_SUB_TOTAL As Double
    Public v_MONTO_IMPUESTO As Double
    Public v_TOTAL_COSTO As Double
    Public v_IDTIPO_MONEDA As Integer
    Public v_IDUSUARIO_PERSONAL As Integer
    Public iIDUsuarioRemoto As Integer
    Public v_IP As String

    Public v_IDROL_USUARIO As Integer

    Public v_MONTO_PENALIDAD As Double
    Public v_IDFUNCIONARIO_AUTORIZACION As Integer

    Public v_IGV As Double
    Public v_PORCENT_DEVOLUCION As Double
    Public v_PORCENT_DESCUENTO As Double
    Public v_MONTO_RECARGO As Double
    Public v_IDTIPO_ENTREGA As Integer
    Public v_CANTIDAD_ETIQUETAS As Integer = 0

    Public v_NRO_GUIA As String

    'Public Cur_CODIGOBARRAS As New ADODB.Recordset
    'Public Cur_DATOS_VENTA As New ADODB.Recordset
    '------Datos de Reporte
    Public v_UNIDAD_ORIGEN As String
    Public v_UNIDAD_DESTINO As String

    Public v_CONTROL_ANUDEV As String = 0
    'Public Cur_Control_VERSIONES As New ADODB.Recordset
    Public tipo_bole_impre As String
    Public tipo_factu_impre As String
    Public v_CANTIDAD_X_ARTICULO As String
    Public IDVentaConsignado As String

    Public v_IDNOMBRES_CONTROL As String
    Public v_DNI_CONTROL As String
    Public v_TIPO_DOCUMENTO As Integer
    Public v_NOMBRES_CONTROL As String
    Public v_NROGUIA_VIGENTE As String
    Public V_CONTROL_PCE As Boolean = False
    Public pl_cargo As Long
    '04/04/2008 - Creando varibles para carga asegurada 
    '
    Public v_ID_GUIAS_ENVIO_DOCs As String
    Public v_FECHAs As String
    Public v_MONTO_TIPO_CAMBIOs As String
    Public v_IDTIPO_MONEDAs As String
    Public v_IDTIPO_COMPROBANTEs As String
    Public v_NRO_SERIEs As String
    Public v_NRO_DOCUs As String
    Public v_TOTAL_COSTOs As String
    Public v_MONTO_IMPUESTOs As String
    Public v_PORCENs As String
    Public v_OBSs As String
    Public v_TIPOs As String
    Public v_PROCEDENCIAs As String
    Public v_SUB_TOTAL_CA As Double
    Public v_IMPUESTO_CA As Double
    Public v_TOTAL_CA As Double
    '--
    Public dv_Cur_CODIGOBARRAS As New DataView
    Public dv_rstVarGrabarEditar As New DataView
    Public dtVenta As DataTable

    Public v_cargo As Long

    'hlamas 06-08-2010 carga acompañada
    Public v_nroboleto As String
    Public v_carga_acompañada As Integer
    Public v_idagencia_venta As Integer
    Public v_idciudad_venta As Integer
    Public v_proceso As Integer
    Public v_facturado As Integer
    Public bOrigenDiferente As Boolean
    Public v_idpersona_cli As Integer
    Public v_idpersona_ori As Integer
    Public v_idpersona_des As Integer

    Public v_Impresora As String
    Public v_MONTO_MINIMOs As Double
    Public v_OTRAS_AGENCIAS As Boolean
    'Public rstVarUnidad As New ADODB.Recordset
    '13/11/2008
    Public bControlFiscalizacion As Boolean
    Public bControlFiscalizacion_graba As Boolean
    Public UsuarioEtiqueta As Integer
    '25/08/2009
    'Public rstFechaRegistro As New ADODB.Recordset
    'Dim rstNroDocumentos As New ADODB.Recordset

    Public Cliente_mod As Integer
    Public DirecCli_mod As Integer
    Public contacto1_mod As Integer
    Public contacto_mod As Integer
    Public NombConsignado_mod As String
    Public DirecConsignado_mod As Integer

    '*****RICHARD *********************************************************************************************   
    Public v_iProceso As Integer
    Public v_METROCUBICO As Integer
    Public v_ALTURA As Double
    Public v_LARGO As Double
    Public v_ANCHO As Double
    Public v_PESO_KG As Double
    Public v_FACTOR As Double
    Public TarifarioGeneral As Integer
    Public Contado As Integer
    Public TipoTarifa As Integer

    'variables Cliente Direccion Estructurado
    Public id_DepartamentoCli, id_ProvinciaCli, id_DistritoCli, id_viaConsig, id_nivelConsig, id_zonaConsig, id_clasificacionConsig, formatoConsig As Integer
    Public viaConsig, NumeroConsig, manzanaConsig, loteConsig, nivelConsig, zonaConsig, clasificacionConsig As String

    'variables Consignado Direccion Estructurado
    Public id_DepartamentoConsig, id_ProvinciaConsig, id_DistritoConsig, id_viaCli, id_nivelCli, id_zonaCli, id_clasificacionCli, formatoCli As Integer
    Public viaCli, NumeroCli, manzanaCli, loteCli, nivelCli, zonaCli, clasificacionCli, sReferencia As String

    'variables cliente Modificado
    Public NombresCliente, apellPatCli, apellMatCli, TelefCliente, sEmail As String
    Public ID_TipoDocCli As Integer
    'variables REMITENTE    
    Public iIDRemitente, iRemitenteModificado, iID_TipoDocumentoRemitente As Integer
    Public sNumeroDocumento, sNombresRemitente, sNombreRemitente, sApellidoPaternoRemitente, sApellidoMaternoRemitente As String
    'variables contacto Modificado
    Public NombreCont, apellPatCont, apellMatCont As String
    Public ID_TipoDocCont As Integer
    'variables contacto Consignado
    Public NombreConsignado, apellPatConsig, apellMatConsig, TelfConsignado As String
    Public ID_TipoDocConsig As String
    Public MontoDC As Double
    Public intCancelaPCE As Integer


    Public dt_curListAgenciasOrigDest As DataTable
    Public dt_curListAgenciaOrigen As DataTable
    Public dt_curlistaEstado As DataTable
    'Public dt_cur_Articulos1 As New DataTable
    'Public dt_cur_Volumetrico As New DataTable

    'new
    'Public dt_cur_CondicionTarifa As New DataTable
    '---news
    Public v_TIPODOC_CONSIGNADO As Integer
    Public v_NOMBRE_CONSIGNADO As String
    Public v_APEPAT_CONSIGNADO As String
    Public v_APEMAT_CONSIGNADO As String
    '-----

    Public coll_OrigDest As New Collection
    Public coll_AgenciaOrigen As New Collection
    Public coll_Estados As New Collection
    '
    Public cur_Listado_Producto As New DataTable
    Public VFactor_ As Double
    Public VMontoMinimoPYME As Double
    Public Agencia_ As String
    Public Ciudad_ As String

    'hlamas 19-11-2013
    Public MontoEntregaDomicilio As Double

    'hlamas 26-08-2015
    Public ObservacionCargo As String

    '-->jabanto 04/12/2015
    Public Property ObjCODIGOBARRA_2 As dtoCODIGOBARRA

    'hlamas 21-01-2016
    Public dtTarifaArticuloPublico As DataTable

    'hlamas 06/09/2016
    Public v_direccion As String

    'hlamas 27/02/2017
    Public v_FechaPartida As String
    Public v_HoraPartida As String
    Public v_servicio As String

    Public v_equipaje As Integer
    Public v_MotivoEquipaje As String
    Public v_UsuarioEquipaje As Integer
    Public v_NivelEquipaje As Integer
    Public v_version As Integer

    'hlamas 25/09/2018
    Public v_MotivoDescuento As String

    'hlamas 03-07-2019
    Public v_asiento As Integer
    Public v_total_boleto As Double

#End Region
#Region "Datatable"
    Public dt_rstFechaRegistro As New DataTable
    Public dt_cur_codBarras As New DataTable
    Public dt_Cur_DATOS_VENTA As New DataTable
    Public dt_Cur_CODIGOBARRAS As New DataTable
    '
    Public dt_cur_t_tipo_comprobante As New DataTable
    Public dt_cur_UNIDAD_AGENCIAS As New DataTable
    Public dt_cur_t_Tipo_Entrega As New DataTable
    Public dt_cur_t_Forma_Pago As New DataTable
    Public dt_cur_T_TARJETAS As New DataTable
    Public dt_cur_Tipo_Pago As New DataTable
    '
    Public dt_VarAgencias As New DataTable    
    Public dt_rstVarGrabarEditar As New DataTable
    '
    Public dt_cur_Articulos As New DataTable
    Public dt_cur_Documentos As New DataTable
    '
    Public dt_cur_persona As New DataTable
    Public dt_cur_cont_origen As New DataTable
    Public dt_cur_cont_destino As New DataTable
    Public dt_cur_dire_origen As New DataTable
    Public dt_cur_dire_destino As New DataTable
    '
    Public dt_rstVarAgencias_2 As New DataTable
    Public dt_rstVarUnidad As New DataTable
    Public dt_rstAgencias As New DataTable
    Public dt_rstVarAgencias_1 As New DataTable
    '
#End Region
#Region "CONTROL ACCESOS"

    'Public cur_persona As New ADODB.Recordset
    'Public cur_cont_origen As New ADODB.Recordset
    'Public cur_cont_destino As New ADODB.Recordset
    'Public cur_dire_origen As New ADODB.Recordset
    'Public cur_dire_destino As New ADODB.Recordset
    'Public cur_datos_eliminacion As New ADODB.Recordset
    'Public cur_Articulos As New ADODB.Recordset
    'Public cur_Documentos As New ADODB.Recordset
#End Region
#Region "VALORES NUMERICOS"
    Public Serie As String = ""
    Public NroDoc As String = ""
#End Region
#Region "FUNCIONES"
    'Public cur_t_tipo_comprobante As New ADODB.Recordset
    'Public cur_UNIDAD_AGENCIAS As New ADODB.Recordset
    'Public cur_t_Tipo_Entrega As New ADODB.Recordset
    'Public cur_t_Forma_Pago As New ADODB.Recordset
    'Public cur_T_TARJETAS As New ADODB.Recordset
    'Public cur_Tipo_Pago As New ADODB.Recordset
    'Public cur_AgenciasVenta As New ADODB.Recordset

    Public coll_t_tipo_comprobante As New Collection
    Public coll_UNIDAD_AGENCIAS As New Collection
    Public coll_t_Tipo_Entrega As New Collection
    Public coll_t_Forma_Pago As New Collection
    Public coll_T_TARJETAS As New Collection
    Public coll_Tipo_Pago As New Collection
    Public coll_AgenciasVenta As New Collection
    Public coll_AgenciasOrigen As New Collection
    Public coll_Origen As New Collection

    Public rstVarAgencias As New ADODB.Recordset
    Public rstVarAgencias_1 As New ADODB.Recordset
    Public rstAgencias As New ADODB.Recordset
    Public rstVarAgencias_2 As New ADODB.Recordset

    Public rstVarGrabarEditar As New ADODB.Recordset

    Public rstEstadoReg As New ADODB.Recordset

#End Region
    'Public Function fnLoadVentaCarga_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_INICIAR_VENTA_CONT", 2}
    '        cur_t_tipo_comprobante = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        cur_UNIDAD_AGENCIAS = cur_t_tipo_comprobante.NextRecordset
    '        cur_t_Tipo_Entrega = cur_t_tipo_comprobante.NextRecordset
    '        cur_t_Forma_Pago = cur_t_tipo_comprobante.NextRecordset
    '        cur_T_TARJETAS = cur_t_tipo_comprobante.NextRecordset
    '        cur_Tipo_Pago = cur_t_tipo_comprobante.NextRecordset

    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnLoadVentaCarga() As Boolean
        Dim flag As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 18/08/2010
            'db_bd.CrearComando("PKG_IVOVENTACARGA.SP_INICIAR_VENTA_CONT", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_INICIAR_VENTA_CONT_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_t_tipo_comprobante", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_UNIDAD_AGENCIAS", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_t_Tipo_Entrega", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_t_Forma_Pago", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_T_TARJETAS", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Tipo_Pago", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_cur_t_tipo_comprobante = lds_tmp.Tables(0)
            dt_cur_UNIDAD_AGENCIAS = lds_tmp.Tables(1)
            dt_cur_t_Tipo_Entrega = lds_tmp.Tables(2)
            dt_cur_t_Forma_Pago = lds_tmp.Tables(3)
            dt_cur_T_TARJETAS = lds_tmp.Tables(4)
            dt_cur_Tipo_Pago = lds_tmp.Tables(5)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    Public Function ACTUALIZAR() As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        Try
            'objLOG.fnLog("entrando grabarII")
            iCONTROL = 1
            '
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If


            db_bd.Conectar()
            '*******richard*****
            db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            'db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            'db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", 1, OracleClient.OracleType.Int32) 'agregado 1 por default
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPERSONA_ORIGEN", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double) 'hgh
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)

            '*****Parametros Nuevos*****  
            db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '
            db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_contacto1_mod", contacto1_mod, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32)

            '
            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(lds_tmp.Tables(2).Rows(0).Item(0)) Then
                    If lds_tmp.Tables(2).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion("El Comprobante de Venta Tiene Cierre Contable. No Podrá Ser Modificado.")
                    Else
                        Throw New Excepcion(lds_tmp.Tables(2).Rows(0).Item(1))
                    End If
                End If
            End If
            '
            dv_rstVarGrabarEditar = lds_tmp.Tables(0).DefaultView
            '
            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                dv_Cur_CODIGOBARRAS = lds_tmp.Tables(1).DefaultView
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                MsgBox(dv_rstVarGrabarEditar.Table.Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                            ObjVentaCargaContado.fnIncrementarNroDoc(3)

                        End If
                    Else
                        ObjVentaCargaContado.fnIncrementarNroDoc(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If

                'End If
            Else
                Throw New Exception("Verifique sus datos...No ha sido Grabado")
                'MsgBox("Verifique sus datos...No ha sido Grabado", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            'objLOG.fnLog("saliendo grabarII")
            '
            flag = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnGetIDGuiaEnvio(ByVal Idguias_Envio As Integer, ByVal Idarticulos As Integer) As Integer
        Dim db_bd As New BaseDatos
        Try
            '
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select PKG_VENTACONTADO.sf_IDGuiaEnvioArticulos(" & Idguias_Envio & ",'" & Idarticulos & "') from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)

            Return db_bd.EjecutarEscalar
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Public Function fnLoadManteVenta() As Boolean
        Dim flag As Boolean = True
        Try
            Dim Impresora As Integer = 1
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_INICIAR_MANTEN_CONTADO", CommandType.StoredProcedure)
            '
            db_bd.AsignarParametro("cur_LISTA_AGENCIAS_UNIDADES", OracleClient.OracleType.Cursor) '0
            db_bd.AsignarParametro("cur_listaAgenOrigen", OracleClient.OracleType.Cursor) '1
            db_bd.AsignarParametro("cur_listaEstado", OracleClient.OracleType.Cursor) '2

            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet

            dt_curListAgenciasOrigDest = lds_tmp.Tables(0)
            dt_curListAgenciaOrigen = lds_tmp.Tables(1)
            dt_curlistaEstado = lds_tmp.Tables(2)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnLoadVentaCarga1(ByVal IdAgencia_ As Integer) As Boolean
        Dim flag As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_INICIAR_VENTA_CONTADO2", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_idagencias", IdAgencia_, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            '
            db_bd.AsignarParametro("cur_t_tipo_comprobante", OracleClient.OracleType.Cursor) '0
            db_bd.AsignarParametro("cur_UNIDAD_AGENCIAS", OracleClient.OracleType.Cursor) '1
            db_bd.AsignarParametro("cur_t_Tipo_Entrega", OracleClient.OracleType.Cursor) '2
            db_bd.AsignarParametro("cur_t_Forma_Pago", OracleClient.OracleType.Cursor) '3
            db_bd.AsignarParametro("cur_T_TARJETAS", OracleClient.OracleType.Cursor) '4
            db_bd.AsignarParametro("cur_Tipo_Pago", OracleClient.OracleType.Cursor) '5
            'nuevos cursores
            'db_bd.AsignarParametro("cur_Listado_Producto", OracleClient.OracleType.Cursor) '6
            db_bd.AsignarParametro("cur_factor_m3_kg", OracleClient.OracleType.Cursor) '7
            db_bd.AsignarParametro("cur_control_version", OracleClient.OracleType.Cursor) '8           
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor) '9


            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet

            '
            dt_cur_t_tipo_comprobante = lds_tmp.Tables(0)
            dt_cur_UNIDAD_AGENCIAS = lds_tmp.Tables(1)
            dt_cur_t_Tipo_Entrega = lds_tmp.Tables(2)
            dt_cur_t_Forma_Pago = lds_tmp.Tables(3)
            dt_cur_T_TARJETAS = lds_tmp.Tables(4)
            dt_cur_Tipo_Pago = lds_tmp.Tables(5)
            '
            'cur_Listado_Producto = lds_tmp.Tables(6)
            '********
            If lds_tmp.Tables(6).Rows.Count > 0 Then
                If lds_tmp.Tables(6).Rows(0).Item(0) IsNot System.DBNull.Value Then
                    VFactor_ = lds_tmp.Tables(6).Rows(0).Item("FACTOR_M3_KG")
                    '-===AGREGADO MONTO MINIMO PYME-====
                    VMontoMinimoPYME = lds_tmp.Tables(6).Rows(0).Item("monto_minimo_pyme")
                End If
            End If
            '**********
            If lds_tmp.Tables(7).Rows.Count > 0 Then
                tipo_bole_impre = lds_tmp.Tables(7).Rows(0).Item("tipo_bole_impre")
                tipo_factu_impre = lds_tmp.Tables(7).Rows(0).Item("tipo_factu_impre")
            Else
                'MsgBox("No se ha podido encontrar ningún registro...", MsgBoxStyle.Information, "Seguridad Sistema")
                tipo_bole_impre = ""
                tipo_factu_impre = ""
            End If
            '************
            'If lds_tmp.Tables(9).Rows.Count > 0 Then
            '    If lds_tmp.Tables(9).Rows(0).Item(0) IsNot System.DBNull.Value Then
            '        Agencia_ = lds_tmp.Tables(9).Rows(0).Item("NOMBRE_AGENCIA")
            '    End If
            'End If

            ''**************
            'If lds_tmp.Tables(10).Rows.Count > 0 Then
            '    If lds_tmp.Tables(10).Rows(0).Item(0) IsNot System.DBNull.Value Then
            '        Ciudad_ = lds_tmp.Tables(10).Rows(0).Item("NOMBRE_UNIDAD")
            '    End If
            'End If
            '**************
            If lds_tmp.Tables(8).Rows.Count > 0 Then
                Impresora = lds_tmp.Tables(8).Rows(0).Item("IMPRESION")
                NOMBRE_IMPRESORA = lds_tmp.Tables(8).Rows(0).Item("Control_Impresoras")
            Else
                Impresora = 0
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    'Public Function fnGetAgencias_2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD", 4, idUnidadAge, 1}
    '        rstVarAgencias = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return rstVarAgencias
    'End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="idUnidadAge"></param>
    ''' <param name="opcion"></param>
    ''' <param name="isGetCodAgeSisvyr">Cuando es necesario recuperar además el codigo de la agencia asociado al sisvyr (true)</param> '-->param add jabanto(21/11/2015)
    Public Function fnGetAgencias(ByVal idUnidadAge As Integer, Optional ByVal opcion As Integer = 0, Optional ByVal isGetCodAgeSisvyr As Boolean = False) As DataTable
        Dim ldt_tmp As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim _isGetCodAgeSisvyr As Integer = IIf(isGetCodAgeSisvyr, 1, 0)
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idUnidadAgencia", idUnidadAge, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_isGetCodAgeSisvyr", _isGetCodAgeSisvyr, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos_Agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_VarAgencias = db_bd.EjecutarDataTable
            Return dt_VarAgencias
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function Grabar() As Boolean
        Dim flag As Boolean = False
        Try
            '
            bControlFiscalizacion_graba = False
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            '
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If
            '
            If v_MEMO <> "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                    v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                End If
            End If
            '
            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("SP_VENTA_CONTADO_CARGA_III", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 

            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", v_IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPERSONA_ORIGEN", v_IDPERSONA_ORIGEN.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", v_CANTIDAD_X_VOLUMEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", v_CANTIDAD_X_SOBRE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IDROL_USUARIO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_cargo", pl_cargo, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                dt_Cur_CODIGOBARRAS = lds_tmp.Tables(1)
                v_IDFACTURA = lds_tmp.Tables(0).Rows(0).Item(0)
                v_CANTIDAD_ETIQUETAS = lds_tmp.Tables(0).Rows(0).Item(2)
                v_IDPERSONA = lds_tmp.Tables(0).Rows(0).Item("IDPERSONA")
                MsgBox(lds_tmp.Tables(0).Rows(0).Item(1).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                'Nuevo valores 
                If lds_tmp.Tables(0).Rows(0).Item(0) <> 0 Then
                    bControlFiscalizacion_graba = True
                End If
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try
                '
                If bControlFiscalizacion Then
                    flag = False
                Else
                    flag = True
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                            ObjVentaCargaContado.fnIncrementarNroDoc(3)
                        End If
                    Else
                        ObjVentaCargaContado.fnIncrementarNroDoc(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If
            Else
                MsgBox("Vefique sus datos...No ha Grabado", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        '
        Return flag
    End Function
    Public Function fnListarEstadoFactura() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_GENERICO.sp_get_estado_comprobante", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("co_get_estado", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnNroDocuemnto(ByVal idDocumento As Integer, Optional ByVal proceso As Integer = 0, Optional ByVal version As Integer = 0, Optional ByVal agencia As Integer = 0) As Boolean
        Dim flat As Boolean = False
        Dim ldt_tmp As DataTable
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            'hlamas 15-04-2016
            db_bd.CrearComando("PKG_GENERICO.sp_get_comprobante", CommandType.StoredProcedure)
            db_bd.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_comprobante", idDocumento, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_proceso", proceso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idagencias", IIf(agencia = 0, dtoUSUARIOS.iIDAGENCIAS, agencia), OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_version", version, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable

            If ldt_tmp.Rows.Count > 0 Then
                Serie = ldt_tmp.Rows(0).Item(0).ToString
                NroDoc = ldt_tmp.Rows(0).Item(1).ToString
                If idDocumento = 3 Then
                    NroDoc = fnGeneraDigitoChequeo(NroDoc)
                End If
                Return True
            Else
                Serie = 0
                NroDoc = 0
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            Return False
            '
        End Try
        Return flat
    End Function

    Public Function fnIncrementarNroDoc(ByVal idTipoComprobante As Integer)
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet            'conecta con la Bd
            db_bd.Conectar()
            'db_bd.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO", CommandType.StoredProcedure)
            db_bd.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDAGENCIAS", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPO_COMPROBANTE", idTipoComprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_proceso", iProceso, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    Public Function fnANULDEVVENAS(ByVal iControlANUDEV As Integer, ByVal x_IDFACTURA As Integer, ByVal x_PORCENT_DEVOLUCION As Double) As Boolean
        '
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOLOG.SP_ANUL_DEVO_VENTA_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControlANUDEV, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Porcent_Devolucion", x_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Idusuario_Personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_controldatos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                MsgBox(lds_tmp.Tables(0).Rows(0).Item(0).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                v_CONTROL_ANUDEV = lds_tmp.Tables(0).Rows(0).Item(1)
                flag = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnVERDATA(ByVal x_IDFACTURA As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    '
    '    Try
    '        Dim db_bd As New BaseDatos
    '        Dim lds_tmp As DataSet            'conecta con la Bd
    '        db_bd.Conectar()
    '        db_bd.CrearComando("PKG_IVOVENTACARGA.SP_VER_VENTACONTADO_I", CommandType.StoredProcedure)
    '        'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
    '        db_bd.AsignarParametro("x_Idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
    '        'Variables de salidas 
    '        db_bd.AsignarParametro("cur_data", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
    '        'Desconectar 
    '        db_bd.Desconectar()
    '        '
    '        lds_tmp = db_bd.EjecutarDataSet
    '        ' 
    '        If lds_tmp.Tables(0).Rows.Count > 0 Then
    '            flag = True
    '            '
    '            v_IDTIPO_COMPROBANTE = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Comprobante")
    '            v_NRO_GUIA = lds_tmp.Tables(0).Rows(0).Item("Nro_Guia")
    '            v_SERIE_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Serie_Factura")
    '            v_NRO_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Nro_Factura")
    '            v_UNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("origen")
    '            v_IDUNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("iddestino")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino") '
    '            v_UNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("destino")
    '            v_IDTIPO_ENTREGA = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Entrega")
    '            v_IDFORMA_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idforma_Pago")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino")
    '            v_FECHA_FACTURA = lds_tmp.Tables(0).Rows(0).Item("FECHA_FACTURA")
    '            v_IDTIPO_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Pago")
    '            v_IDTARJETAS = lds_tmp.Tables(0).Rows(0).Item("Idtarjetas")

    '            v_IDUNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("Idunidad_Origen")
    '            v_IDAGENCIAS = lds_tmp.Tables(0).Rows(0).Item("Idagencias")

    '            v_NROTARJETA = lds_tmp.Tables(0).Rows(0).Item("NROTARJETA")
    '            v_NRO_DNI_RUC = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")
    '            v_NOMBRES_RASONSOCIAL = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")

    '            v_DIRECCION_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("DirOrigen")
    '            v_DIRECCION_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("DirDestino")
    '            v_TELEFONO_REMITENTE = IIf(lds_tmp.Tables(0).Rows(0).Item("telefono") = " ", "", lds_tmp.Tables(0).Rows(0).Item("telefono"))
    '            v_PORCENT_DESCUENTO = lds_tmp.Tables(0).Rows(0).Item("Porcent_Descuento")
    '            v_MEMO = lds_tmp.Tables(0).Rows(0).Item("Memo")
    '            v_NOMBRES_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("remitente")
    '            v_NRO_DOC_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("dniremitente")
    '            v_NOMBRES_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("Destinatario")
    '            v_NRO_DOC_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("dniDestinatario")
    '            v_TOTAL_PESO = lds_tmp.Tables(0).Rows(0).Item("Total_Peso")
    '            v_TOTAL_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Total_Volumen")
    '            v_CANTIDAD_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Peso")
    '            v_CANTIDAD_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
    '            v_CANTIDAD_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
    '            v_PRECIO_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Peso")
    '            v_PRECIO_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Volumen")
    '            v_PRECIO_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Sobre")
    '            v_MONTO_BASE = lds_tmp.Tables(0).Rows(0).Item("Monto_Base")
    '            v_MONTO_SUB_TOTAL = lds_tmp.Tables(0).Rows(0).Item("Monto_Sub_Total")
    '            v_MONTO_IMPUESTO = lds_tmp.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
    '            v_TOTAL_COSTO = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
    '            v_CANTIDAD_X_ARTICULO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Articulos")
    '            '
    '            dt_cur_Articulos = lds_tmp.Tables(1)
    '            dt_cur_Documentos = lds_tmp.Tables(2)

    '        End If
    '        '
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    '    Return flag
    'End Function
    
    Public Function fnClearOBJ(ByVal var As Integer) As Boolean
        Try
            v_SERIE_FACTURA = ""
            If var <> 1 Then
                v_NRO_GUIA = ""
            End If

            v_NRO_FACTURA = ""
            v_UNIDAD_ORIGEN = ""
            v_UNIDAD_DESTINO = ""
            v_IDTIPO_ENTREGA = 0
            v_IDFORMA_PAGO = 0
            v_IDUNIDAD_DESTINO = 0
            v_IDAGENCIAS_DESTINO = 0
            v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            v_IDTIPO_PAGO = 0
            v_IDTARJETAS = 0
            v_NROTARJETA = ""
            v_NRO_DNI_RUC = ""
            v_NOMBRES_RASONSOCIAL = ""

            v_DIRECCION_REMITENTE = ""
            v_DIRECCION_DESTINATARIO = ""
            v_TELEFONO_REMITENTE = ""
            v_PORCENT_DESCUENTO = 0
            v_MEMO = ""
            v_NOMBRES_REMITENTE = ""
            v_NRO_DOC_REMITENTE = ""
            v_NOMBRES_DESTINATARIO = ""
            v_NRO_DOC_DESTINATARIO = ""
            v_TOTAL_PESO = 0
            v_TOTAL_VOLUMEN = 0
            v_CANTIDAD_X_PESO = 0
            v_CANTIDAD_X_VOLUMEN = 0
            v_CANTIDAD_X_SOBRE = 0
            v_PRECIO_X_PESO = 0
            v_PRECIO_X_VOLUMEN = 0
            v_PRECIO_X_SOBRE = 0
            v_MONTO_BASE = 0
            v_MONTO_SUB_TOTAL = 0
            v_MONTO_IMPUESTO = 0
            v_TOTAL_COSTO = 0
            v_IDTIPO_COMPROBANTE = 0
            v_IDUNIDAD_ORIGEN = 0
            v_IDAGENCIAS = 0

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    ' Dim rstControlProceso As New ADODB.Recordset
    'Public Function fnValidarProceso_2009(ByVal x_idFactura As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"select coalesce(count(*),0) VALIDAR from t_factura_contado  where t_factura_contado.idfactura=" & x_idFactura.ToString & " and t_factura_contado .idestado_factura = 27 ", 2}
    '        rstControlProceso = Nothing
    '        rstControlProceso = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstControlProceso.State = 1 Then
    '            If rstControlProceso.EOF = False And rstControlProceso.BOF = False Then
    '                If rstControlProceso.Fields.Item("VALIDAR").Value = 1 Then
    '                    flag = True
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flag
    'End Function
    Public Function fnValidarProceso(ByVal x_idFactura As Integer) As Boolean
        Dim flag As Boolean = False
        '
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As DataTable            'conecta con la Bd
            '
            db_bd.Conectar()
            db_bd.CrearComando("PKG_GENERICO.sp_get_nro_comprobante", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idfactura", x_idFactura, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("co_nro_comprobante", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                If ldt_tmp.Rows(0).Item("VALIDAR") = 1 Then
                    flag = True
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    Public Function fnBuscarCliente(ByVal iControl As Integer, ByVal NroDoc As String, ByVal RasonSocial As String, ByVal idOrigen As Integer, ByVal idDestino As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet            'conecta con la Bd
            '
            dt_cur_persona = Nothing
            dt_cur_cont_origen = Nothing
            dt_cur_cont_destino = Nothing
            dt_cur_dire_origen = Nothing
            dt_cur_dire_destino = Nothing
            ' 
            dt_cur_persona = New DataTable
            dt_cur_cont_origen = New DataTable
            dt_cur_cont_destino = New DataTable
            dt_cur_dire_origen = New DataTable
            dt_cur_dire_destino = New DataTable
            '
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_FILTRO_CLIENTES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nu_docu_suna", NroDoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_razon_social", RasonSocial, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUnidadOrigen", idOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IdUnidadDestino", idDestino, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_persona", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_cont_origen", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_cont_destino", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_dire_origen", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_dire_destino", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            '
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_cur_persona = lds_tmp.Tables(0)
            dt_cur_cont_origen = lds_tmp.Tables(1)
            dt_cur_cont_destino = lds_tmp.Tables(2)
            dt_cur_dire_origen = lds_tmp.Tables(3)
            dt_cur_dire_destino = lds_tmp.Tables(4)
            dt_cur_Articulos = lds_tmp.Tables(5)
            '
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        '
        Return flag
    End Function
    Public Function fnREIMPRESIONCODIGOS(ByVal iControl As Integer, ByVal x_IDFACTURA As String) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet            'conecta con la Bd
            '
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_REIMPRESION_CODIGO_BARRAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xidComprobante", x_IDFACTURA, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cabecera", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codigos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                '
                flag = True
                ObjCODIGOBARRA.clinte = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
                ObjCODIGOBARRA.Cantidad = lds_tmp.Tables(0).Rows(0).Item("Cantidad")
                ObjCODIGOBARRA.NroDOC = lds_tmp.Tables(0).Rows(0).Item("NroDoc")
                ObjCODIGOBARRA.Origen = lds_tmp.Tables(0).Rows(0).Item("Origen")
                ObjCODIGOBARRA.Destino = lds_tmp.Tables(0).Rows(0).Item("Destino")
                ObjCODIGOBARRA.CodigoBarra = ""
                ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
                ObjCODIGOBARRA.HoraImpresion = ObjCODIGOBARRA.fnGetHora()
                ObjCODIGOBARRA.AGEDOM = lds_tmp.Tables(0).Rows(0).Item("Tipo_Entrega")
                ObjVentaCargaContado.dt_Cur_CODIGOBARRAS = lds_tmp.Tables(1)
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnELIMINAR_DOCUMENTO_2009(ByVal v_idFactura As String) As Boolean
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_ELIMINAR_FACTURA", 8, v_idFactura, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        cur_datos_eliminacion = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If cur_datos_eliminacion.State = 1 Then
    '            If cur_datos_eliminacion.EOF = False And cur_datos_eliminacion.BOF = False Then
    '                MsgBox(cur_datos_eliminacion.Fields.Item(0).Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        Else
    '            MsgBox("No se ha podido eliminar el registro...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return False
    'End Function
    Public Function fnELIMINAR_DOCUMENTO(ByVal v_idFactura As String) As Boolean
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet            'conecta con la Bd
            '
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_ELIMINAR_FACTURA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idFactura", v_idFactura.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idUsuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(1).Rows.Count > 0 Then
                MsgBox(lds_tmp.Tables(1).Rows(0).Item(1), MsgBoxStyle.Information, "Seguridad Sistema")
                If lds_tmp.Tables(1).Rows(0).Item(0) = 0 Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnCONTROL_VERSIONES_2009() As Boolean
    '    Try
    '        Dim SQLQuery As Object() = {"select t_Agencias.tipo_bole_impre,tipo_factu_impre from t_Agencias where t_Agencias.Idagencias=" & dtoUSUARIOS.m_iIdAgencia, 2}
    '        Cur_Control_VERSIONES = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If Cur_Control_VERSIONES.State = 1 Then
    '            If Cur_Control_VERSIONES.EOF = False And Cur_Control_VERSIONES.BOF = False Then
    '                tipo_bole_impre = Cur_Control_VERSIONES.Fields.Item("tipo_bole_impre").Value
    '                tipo_factu_impre = Cur_Control_VERSIONES.Fields.Item("tipo_factu_impre").Value
    '            End If
    '        Else
    '            MsgBox("No se ha podido encontrar ningun registro...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return True
    'End Function
    Public Function fnCONTROL_VERSIONES() As Boolean
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As DataTable            'conecta con la Bd
            '
            db_bd.Conectar()
            db_bd.CrearComando("PKG_GENERICO.sp_get_Control_Version_agencia", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idagencias", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("co_control_version", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                tipo_bole_impre = ldt_tmp.Rows(0).Item("tipo_bole_impre")
                tipo_factu_impre = ldt_tmp.Rows(0).Item("tipo_factu_impre")
            Else
                MsgBox("No se ha podido encontrar ningún registro...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '
            Return True
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnUPDCARGA_CONTADO(ByVal x_IDFACTURA As Integer, ByVal x_fecha As String, ByVal x_Monto_Total As Double) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As DataTable
            'conecta con la Bd            
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTA.SP_UPDCARGA_CONTADO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idcomprobante", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha", x_fecha, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_total_costo", x_Monto_Total, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_idUsuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("MSGBOX").ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                flag = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function fnSP_VALIDAR_GUIAPCE(ByVal x_IDFACTURA As String) As Boolean
        Dim flag As Boolean = False
        Try           
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As DataTable
            'conecta con la Bd            
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_VALIDAR_GUIAPCE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("NRO_GUIA", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDAGENCIA_ORIGEN", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                Dim varGUIA As Integer = ldt_tmp.Rows(0).Item("CNTGUIA")
                Dim varFACT As Integer = ldt_tmp.Rows(0).Item("CNTFACT")
                If varGUIA >= 1 And varFACT = 1 Then
                    flag = False
                ElseIf (varGUIA >= 1) And varFACT = 0 Then
                    flag = True
                ElseIf varGUIA = 0 And varFACT = 0 Then
                    flag = False
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnSP_Buscar_Impresora_2009(ByVal iDocumento As Integer, ByVal ip As String) As Boolean
    '    Dim Flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"SP_BUSCAR_IMPRESORA", 6, iDocumento, 1, ip, 2}
    '        Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If Cur_DATOS_VENTA.BOF = False And Cur_DATOS_VENTA.EOF = False Then
    '            v_Impresora = IIf(IsDBNull(Cur_DATOS_VENTA.Fields.Item("impresora").Value), "", Cur_DATOS_VENTA.Fields.Item("impresora").Value)
    '            If v_Impresora.Length > 0 Then
    '                Flag = True
    '            Else
    '                Flag = False
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        Flag = False
    '    End Try
    '    Return Flag
    'End Function
    Public Function fnSP_Buscar_Impresora(ByVal iDocumento As Integer, ByVal ip As String) As Boolean
        Dim Flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            Dim li_idproceso As Integer
            'Por defecto 4 Guias de Envio 
            li_idproceso = 4
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("SP_BUSCAR_IMPRESORA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IdTipoComprobante", iDocumento, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_Cur_DATOS_VENTA = db_bd.EjecutarDataTable
            ' 
            If dt_Cur_DATOS_VENTA.Rows.Count > 0 Then
                v_Impresora = IIf(IsDBNull(dt_Cur_DATOS_VENTA.Rows(0).Item("impresora")), "", dt_Cur_DATOS_VENTA.Rows(0).Item("impresora"))
                If v_Impresora.Length > 0 Then
                    Flag = True
                Else
                    Flag = False
                End If
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return Flag
    End Function
    'Public Function fnSP_BUSCAR_PERSONA_2009(ByVal vDNIRUC As String) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        If vDNIRUC <> "" Then
    '            Dim SQLQuery As Object() = {"AA_TEST.SP_BUSCAR_PERSONA", 6, vDNIRUC, 2, ObjVentaCargaContado.v_IDUNIDAD_ORIGEN, 1}
    '            Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '            If Cur_DATOS_VENTA.BOF = False And Cur_DATOS_VENTA.EOF = False Then
    '                flag = True
    '                'v_IDPERSONA = Cur_DATOS_VENTA.Fields.Item("idpersona").Value
    '                'v_NOMBRES_RASONSOCIAL = Cur_DATOS_VENTA.Fields.Item("razon_social").Value
    '                'v_NRO_DNI_RUC = Cur_DATOS_VENTA.Fields.Item("nu_docu_suna").Value
    '                v_IDNOMBRES_CONTROL = Cur_DATOS_VENTA.Fields.Item("idpersona").Value
    '                v_NOMBRES_CONTROL = Cur_DATOS_VENTA.Fields.Item("razon_social").Value
    '                v_DNI_CONTROL = Cur_DATOS_VENTA.Fields.Item("nu_docu_suna").Value
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnSP_BUSCAR_PERSONA(ByVal vDNIRUC As String) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("AA_TEST.SP_BUSCAR_PERSONA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_DNIRUC", vDNIRUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUnidad_Agencia", ObjVentaCargaContado.v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Direcciones", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            If ldt_tmp.Rows.Count > 0 Then
                flag = True
                v_IDNOMBRES_CONTROL = ldt_tmp.Rows(0).Item("idpersona")
                v_NOMBRES_CONTROL = ldt_tmp.Rows(0).Item("razon_social")
                v_DNI_CONTROL = ldt_tmp.Rows(0).Item("nu_docu_suna")
                v_TELEFONO_REMITENTE = IIf(ldt_tmp.Rows(0).Item("telefono") = " ", "", ldt_tmp.Rows(0).Item("telefono"))
                v_TIPO_DOCUMENTO = IIf(IsDBNull(ldt_tmp.Rows(0).Item("tipo")), 9, ldt_tmp.Rows(0).Item("tipo"))
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function fnSP_BUSCAR_PERSONACONTACTOS(ByVal vDNIRUC As String) As Boolean
        Dim flag As Boolean = False
        ''''
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("AA_TEST.SP_BUSCAR_PERSONACONTACTOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_DNIRUC", vDNIRUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUnidad_Agencia", ObjVentaCargaContado.v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Direcciones", OracleClient.OracleType.Cursor)  '-- No es usado cur_Direcciones
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
                v_IDNOMBRES_CONTROL = lds_tmp.Tables(0).Rows(0).Item("Idcontacto_Persona")
                v_NOMBRES_CONTROL = lds_tmp.Tables(0).Rows(0).Item("Nombres")
                v_DNI_CONTROL = lds_tmp.Tables(0).Rows(0).Item("Nrodocumento")
                v_TIPO_DOCUMENTO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idtipo_documento_contacto")), 9, lds_tmp.Tables(0).Rows(0).Item("idtipo_documento_contacto"))
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function fnREIMPRESIONCODIGOSII(ByVal iControl As Integer, ByVal x_IDFACTURA As String, ByVal correlativo_inicial As Long, ByVal correlativo_final As Long) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet

            dt_Cur_DATOS_VENTA = Nothing
            dt_Cur_DATOS_VENTA = New DataTable
            '
            dt_Cur_CODIGOBARRAS = Nothing
            dt_Cur_CODIGOBARRAS = New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_REIMPRESION_CODIGO_BARRASII", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("p_nro_correlativoini", correlativo_inicial, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_nro_correlativofinal", correlativo_final, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xidComprobante", x_IDFACTURA, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cabecera", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codigos", OracleClient.OracleType.Cursor)
            '
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True

                ObjCODIGOBARRA.clinte = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
                ObjCODIGOBARRA.Cantidad = lds_tmp.Tables(0).Rows(0).Item("Cantidad")
                ObjCODIGOBARRA.NroDOC = lds_tmp.Tables(0).Rows(0).Item("NroDoc")
                ObjCODIGOBARRA.Origen = lds_tmp.Tables(0).Rows(0).Item("Origen")
                ObjCODIGOBARRA.Destino = lds_tmp.Tables(0).Rows(0).Item("Destino")
                ObjCODIGOBARRA.Destino2 = lds_tmp.Tables(0).Rows(0).Item("Destino2")
                ObjCODIGOBARRA.CodigoBarra = ""
                ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
                ObjCODIGOBARRA.HoraImpresion = ObjCODIGOBARRA.fnGetHora()
                ObjCODIGOBARRA.AGEDOM = lds_tmp.Tables(0).Rows(0).Item("Tipo_Entrega")
                ObjCODIGOBARRA.AgenciaEmbarque = "" & lds_tmp.Tables(0).Rows(0).Item("agencia_embarque")
                ObjCODIGOBARRA.AgenciaDesembarque = "" & lds_tmp.Tables(0).Rows(0).Item("agencia_desembarque")
                ObjCODIGOBARRA.peso = lds_tmp.Tables(0).Rows(0).Item("peso")
                ObjCODIGOBARRA.asiento = lds_tmp.Tables(0).Rows(0).Item("asiento")
                ObjCODIGOBARRA.TotalBoleto = lds_tmp.Tables(0).Rows(0).Item("total_boleto")
                ObjCODIGOBARRA.FechaPartida = "" & lds_tmp.Tables(0).Rows(0).Item("fecha_partida")
                ObjCODIGOBARRA.HoraPartida = "" & lds_tmp.Tables(0).Rows(0).Item("hora_partida")

                dt_Cur_DATOS_VENTA = lds_tmp.Tables(0)
                dt_Cur_CODIGOBARRAS = lds_tmp.Tables(1)
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnVERDATA_IV(ByVal x_IDFACTURA As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim db_bd As New BaseDatos
    '        Dim lds_tmp As New DataSet
    '        'conecta con la Bd
    '        db_bd.Conectar()
    '        '-- Invocando  al procedimiento almacenado 
    '        db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_VER_VENTACONTADO_I", CommandType.StoredProcedure)
    '        'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
    '        db_bd.AsignarParametro("x_Idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
    '        'Variables de salidas 
    '        db_bd.AsignarParametro("cur_data", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
    '        'Desconectar 
    '        db_bd.Desconectar()
    '        '
    '        lds_tmp = db_bd.EjecutarDataSet
    '        If lds_tmp.Tables(0).Rows.Count > 0 Then
    '            flag = True
    '            v_IDTIPO_COMPROBANTE = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Comprobante")
    '            v_NRO_GUIA = lds_tmp.Tables(0).Rows(0).Item("Nro_Guia")
    '            v_SERIE_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Serie_Factura")
    '            v_NRO_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Nro_Factura")
    '            v_UNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("origen")
    '            v_IDUNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("iddestino")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino") '
    '            v_UNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("destino")
    '            v_IDTIPO_ENTREGA = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Entrega")
    '            v_IDFORMA_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idforma_Pago")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino")
    '            v_FECHA_FACTURA = lds_tmp.Tables(0).Rows(0).Item("FECHA_FACTURA")
    '            v_IDTIPO_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Pago")
    '            v_IDTARJETAS = lds_tmp.Tables(0).Rows(0).Item("Idtarjetas")
    '            '
    '            v_IDUNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("Idunidad_Origen")
    '            v_IDAGENCIAS = lds_tmp.Tables(0).Rows(0).Item("Idagencias")
    '            '
    '            v_NROTARJETA = lds_tmp.Tables(0).Rows(0).Item("NROTARJETA")
    '            v_NRO_DNI_RUC = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")
    '            v_NOMBRES_RASONSOCIAL = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
    '            '
    '            v_DIRECCION_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("DirOrigen")
    '            v_DIRECCION_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("DirDestino")
    '            v_TELEFONO_REMITENTE = IIf(lds_tmp.Tables(0).Rows(0).Item("telefono") = " ", "", lds_tmp.Tables(0).Rows(0).Item("telefono"))
    '            v_PORCENT_DESCUENTO = lds_tmp.Tables(0).Rows(0).Item("Porcent_Descuento")
    '            v_MEMO = lds_tmp.Tables(0).Rows(0).Item("Memo")
    '            v_NOMBRES_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("remitente")
    '            v_NRO_DOC_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("dniremitente")
    '            v_NOMBRES_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("Destinatario")
    '            v_NRO_DOC_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("dniDestinatario")

    '            v_TELEFONO_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Tel_destino")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Tel_destino"))  '23/11/2009 

    '            v_TOTAL_PESO = lds_tmp.Tables(0).Rows(0).Item("Total_Peso")
    '            v_TOTAL_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Total_Volumen")
    '            v_CANTIDAD_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Peso")
    '            v_CANTIDAD_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
    '            v_CANTIDAD_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
    '            v_PRECIO_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Peso")
    '            v_PRECIO_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Volumen")
    '            v_PRECIO_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Sobre")
    '            v_MONTO_BASE = lds_tmp.Tables(0).Rows(0).Item("Monto_Base")
    '            v_MONTO_SUB_TOTAL = lds_tmp.Tables(0).Rows(0).Item("Monto_Sub_Total")
    '            v_MONTO_IMPUESTO = lds_tmp.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
    '            v_TOTAL_COSTO = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
    '            v_CANTIDAD_X_ARTICULO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Articulos")
    '            v_MONTO_MINIMOs = lds_tmp.Tables(0).Rows(0).Item("Monto_Minimo")
    '            v_cargo = lds_tmp.Tables(0).Rows(0).Item("cargo")
    '            'hlamas 06-08-2010 carga acompañada
    '            v_nroboleto = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("nroboleto")), "", lds_tmp.Tables(0).Rows(0).Item("nroboleto"))
    '            v_proceso = lds_tmp.Tables(0).Rows(0).Item("proceso")
    '            v_facturado = lds_tmp.Tables(0).Rows(0).Item("facturado")
    '            v_idpersona_cli = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cli")), 9, lds_tmp.Tables(0).Rows(0).Item("cli"))
    '            v_idpersona_ori = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ori")), 9, lds_tmp.Tables(0).Rows(0).Item("ori"))
    '            v_idpersona_des = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("des")), 9, lds_tmp.Tables(0).Rows(0).Item("des"))
    '            '
    '            dt_cur_Articulos = lds_tmp.Tables(1)
    '            dt_cur_Documentos = lds_tmp.Tables(2)
    '            '
    '        End If
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    '    Return flag
    'End Function

    'Public Function fnVERDATA_V(ByVal x_IDFACTURA As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim db_bd As New BaseDatos
    '        Dim lds_tmp As New DataSet
    '        'conecta con la Bd
    '        db_bd.Conectar()
    '        '-- Invocando  al procedimiento almacenado 
    '        db_bd.CrearComando("PKG_VENTACONTADO.SP_VER_VENTACONTADO_I", CommandType.StoredProcedure)
    '        'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
    '        db_bd.AsignarParametro("x_Idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
    '        'Variables de salidas 
    '        db_bd.AsignarParametro("cur_data", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
    '        'Desconectar 
    '        db_bd.Desconectar()
    '        '
    '        lds_tmp = db_bd.EjecutarDataSet
    '        If lds_tmp.Tables(0).Rows.Count > 0 Then
    '            flag = True
    '            v_IDTIPO_COMPROBANTE = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Comprobante")
    '            v_NRO_GUIA = lds_tmp.Tables(0).Rows(0).Item("Nro_Guia")
    '            v_SERIE_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Serie_Factura")
    '            v_NRO_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Nro_Factura")
    '            v_UNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("origen")
    '            v_IDUNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("iddestino")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino") '
    '            v_UNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("destino")
    '            v_IDTIPO_ENTREGA = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Entrega")
    '            v_IDFORMA_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idforma_Pago")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino")
    '            v_FECHA_FACTURA = lds_tmp.Tables(0).Rows(0).Item("FECHA_FACTURA")
    '            v_IDTIPO_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Pago")
    '            v_IDTARJETAS = lds_tmp.Tables(0).Rows(0).Item("Idtarjetas")
    '            '
    '            v_IDUNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("Idunidad_Origen")
    '            v_IDAGENCIAS = lds_tmp.Tables(0).Rows(0).Item("Idagencias")
    '            '
    '            v_NROTARJETA = lds_tmp.Tables(0).Rows(0).Item("NROTARJETA")
    '            v_NRO_DNI_RUC = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")
    '            v_NOMBRES_RASONSOCIAL = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
    '            '
    '            v_DIRECCION_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("DirOrigen")
    '            v_DIRECCION_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("DirDestino")
    '            v_IDCONTACTO_DESTINO = lds_tmp.Tables(0).Rows(0).Item("IDCONTACTO_DESTINO") 'nuevo
    '            v_IDDIREECION_DESTINO = lds_tmp.Tables(0).Rows(0).Item("iddireecion_destino") 'nuevo
    '            v_IDDIREECION_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("iddireecion_origen") 'nuevo
    '            v_METROCUBICO = lds_tmp.Tables(0).Rows(0).Item("METRO_CUBICO") 'nuevo                   
    '            v_ALTURA = lds_tmp.Tables(0).Rows(0).Item("ALTURA") 'nuevo 
    '            v_ANCHO = lds_tmp.Tables(0).Rows(0).Item("ANCHO") 'nuevo 
    '            v_LARGO = lds_tmp.Tables(0).Rows(0).Item("LARGO") 'nuevo 
    '            v_PESO_KG = lds_tmp.Tables(0).Rows(0).Item("PESO_KG") 'nuevo                 
    '            v_TELEFONO_REMITENTE = IIf(lds_tmp.Tables(0).Rows(0).Item("telefono") = " ", "", lds_tmp.Tables(0).Rows(0).Item("telefono"))
    '            v_PORCENT_DESCUENTO = lds_tmp.Tables(0).Rows(0).Item("Porcent_Descuento")
    '            v_MEMO = lds_tmp.Tables(0).Rows(0).Item("Memo")
    '            v_NOMBRES_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("remitente")
    '            v_NRO_DOC_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("dniremitente")
    '            v_NOMBRES_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("Destinatario")
    '            v_NRO_DOC_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("dniDestinatario")

    '            v_TELEFONO_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Tel_destino")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Tel_destino"))  '23/11/2009 

    '            v_TOTAL_PESO = lds_tmp.Tables(0).Rows(0).Item("Total_Peso")
    '            v_TOTAL_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Total_Volumen")
    '            v_CANTIDAD_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Peso")
    '            v_CANTIDAD_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
    '            v_CANTIDAD_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
    '            v_PRECIO_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Peso")
    '            v_PRECIO_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Volumen")
    '            v_PRECIO_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Sobre")
    '            v_MONTO_BASE = lds_tmp.Tables(0).Rows(0).Item("Monto_Base")
    '            v_MONTO_SUB_TOTAL = lds_tmp.Tables(0).Rows(0).Item("Monto_Sub_Total")
    '            v_MONTO_IMPUESTO = lds_tmp.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
    '            v_TOTAL_COSTO = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
    '            v_CANTIDAD_X_ARTICULO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Articulos")
    '            v_MONTO_MINIMOs = lds_tmp.Tables(0).Rows(0).Item("Monto_Minimo")
    '            v_cargo = lds_tmp.Tables(0).Rows(0).Item("cargo")
    '            'hlamas 06-08-2010 carga acompañada
    '            v_nroboleto = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("nroboleto")), "", lds_tmp.Tables(0).Rows(0).Item("nroboleto"))
    '            v_proceso = lds_tmp.Tables(0).Rows(0).Item("proceso")
    '            v_facturado = lds_tmp.Tables(0).Rows(0).Item("facturado")
    '            v_idpersona_cli = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cli")), 9, lds_tmp.Tables(0).Rows(0).Item("cli"))
    '            v_idpersona_ori = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ori")), 9, lds_tmp.Tables(0).Rows(0).Item("ori"))
    '            v_idpersona_des = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("des")), 9, lds_tmp.Tables(0).Rows(0).Item("des"))
    '            '

    '            dt_cur_Articulos1 = lds_tmp.Tables(1)
    '            dt_cur_Documentos = lds_tmp.Tables(2)
    '            '
    '        End If
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    '    Return flag
    'End Function

    Public Function GrabarII() As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        Try
            'objLOG.fnLog("entrando grabarII")
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    If bOrigenDiferente = False Then
                        v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                        v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If
                End If
            End If
            '
            'conecta con la Bd
            '
            db_bd.Conectar()
            'hlamas
            '-- Invocando  al procedimiento almacenado - 16/09/2009  - 
            '-- hlamas 24-10-2008
            'db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_VENTA_CONTADO_CARGA_V", CommandType.StoredProcedure)
            '-- hlamas 06-08-2010
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure)
            '
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", v_IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPERSONA_ORIGEN", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows(0)(0) = 0 Then
                MsgBox(lds_tmp.Tables(0).Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                flag = False
                Return flag
            End If
            '
            dv_rstVarGrabarEditar = lds_tmp.Tables(0).DefaultView
            '
            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                'If rstVarGrabarEditar.BOF = False And rstVarGrabarEditar.EOF = False Then
                'Cur_CODIGOBARRAS = rstVarGrabarEditar.NextRecordset

                dv_Cur_CODIGOBARRAS = lds_tmp.Tables(1).DefaultView
                '
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                MsgBox(dv_rstVarGrabarEditar.Table.Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                            ObjVentaCargaContado.fnIncrementarNroDoc(3)

                        End If
                    Else
                        ObjVentaCargaContado.fnIncrementarNroDoc(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If

                'End If
            Else
                MsgBox("Vefique sus datos...No ha sido Grabado", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            'objLOG.fnLog("saliendo grabarII")
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End Try
        Return flag
    End Function
    'Public Function fnUPDMONTO_MINIMO_2009(ByVal x_IDFACTURA As Integer, ByVal x_Monto_Total As Double) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOCARGA_ASEGURADA.SP_UPDMONTO_MINIMO", 6, x_IDFACTURA.ToString, 2, x_Monto_Total, 3}

    '        Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        'objLOG.fnLog("[dtoVentaCargaContado.fnUPDCARGA_CONTADO]" & fnLoagObj(SQLQuery))
    '        If Cur_DATOS_VENTA.State = 1 Then
    '            If Cur_DATOS_VENTA.EOF = False And Cur_DATOS_VENTA.BOF = False Then
    '                MsgBox(Cur_DATOS_VENTA.Fields.Item("MSGBOX").Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                flag = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnUPDMONTO_MINIMO(ByVal x_IDFACTURA As Integer, ByVal x_Monto_Total As Double) As Boolean
        Dim db_bd As New BaseDatos
        Dim flag As Boolean = False
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_UPDMONTO_MINIMO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idcomprobante", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Monto_Minimo", x_Monto_Total, OracleClient.OracleType.Double)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            'Desconectar 
            db_bd.Desconectar()
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return flag
    End Function

    'Public Function fnGetAgencias_1_2009() As ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD_1", 2}
    '        rstVarAgencias_1 = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return rstVarAgencias_1
    'End Function
    Public Function fnGetAgencias_1() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos_Agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rstVarAgencias_1 = db_bd.EjecutarDataTable
            Return dt_rstVarAgencias_1
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGetUnidadAgencia_2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTACARGA. SP_BUSCA_UNIDAD_AGENCIA", 4, idUnidadAge, 1}
    '        rstAgencias = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return rstAgencias
    'End Function
    Public Function fnGetUnidadAgencia(ByVal idUnidadAge As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_BUSCA_UNIDAD_AGENCIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idAgencia", idUnidadAge, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos_Agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rstAgencias = db_bd.EjecutarDataTable
            Return dt_rstAgencias
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGetAgencias_2_2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTACARGA.SP_GET_NOMBRE_AGENCIA", 4, idUnidadAge, 1}
    '        rstVarAgencias_2 = (VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY))
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Function
    Public Function fnGetAgencias_2(ByVal idUnidadAge As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_GET_NOMBRE_AGENCIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idAgencia", idUnidadAge, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos_Agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rstVarAgencias_2 = db_bd.EjecutarDataTable
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnNombreUnidadAgencia_2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTACARGA.SP_NOMBRE_UNIDAD_AGENCIA", 4, idUnidadAge, 1}
    '        rstVarUnidad = (VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY))
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Function
    Public Function fnNombreUnidadAgencia(ByVal idUnidadAge As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_NOMBRE_UNIDAD_AGENCIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idAgencia", idUnidadAge, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos_Agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rstVarUnidad = db_bd.EjecutarDataTable
            Return dt_rstVarUnidad
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnFechaRegistro_2009(ByVal tipo As Integer, ByVal doc As String) As ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"SP_FECHA_HORA_REGISTRO", 6, tipo, 1, doc, 2}
    '        rstFechaRegistro = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Function
    Public Function fnFechaRegistro(ByVal tipo As Integer, ByVal doc As String) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("SP_FECHA_HORA_REGISTRO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idtipo_comprobante", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idcomprobante", doc, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dt_rstFechaRegistro = db_bd.EjecutarDataTable
            Return dt_rstFechaRegistro
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function fn_SP_VER_VENTACONTADO_I(ByVal x_idfactura As Integer) As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("SP_VER_VENTACONTADO_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("x_Idfactura", x_idfactura, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_data", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
            '
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

    Sub AuditoriaReimpresion(tipo As Integer, comprobante As Integer, usuario As Integer, ip As String)
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_VENTACONTADO.sp_auditoria_reimpresion", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            '
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Public Function fn_SP_VER_VENTACONTADO_II(ByVal x_idComprobante As Integer, ByVal x_idfactura As Integer, rol As Integer) As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_VENTACONTADO.SP_VER_VENTA_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("x_IdComprobante", x_idComprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_Idfactura", x_idfactura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_data", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
            '
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Dim a As String = ex.Message
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Sub ActualizaCargaAcompañada(ByVal doc As Integer, ByVal boleto As String, ByVal t1 As String, ByVal t11 As TextBox, ByVal t2 As String, ByVal t22 As TextBox, ByVal t3 As String, ByVal t33 As TextBox, ByVal telefono1 As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_actualiza_carga_acompanada", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", doc, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nroboleto", boleto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_remitente1", t2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_remitente2", IIf(t22.Tag.ToString.Length = 0, 9, t22.Tag), OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_remitente3", t22.Text, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_consignado1", t1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_consignado2", IIf(t11.Tag.ToString.Length = 0, 9, t11.Tag), OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_consignado3", t11.Text, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_cliente1", t3, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_cliente2", IIf(t33.Tag.ToString.Length = 0, 9, t33.Tag), OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_cliente3", t33.Text, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_telefono1", telefono1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_proceso", IIf(boleto = "", 0, 6), OracleClient.OracleType.VarChar)
            db.EjecutarComando()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Sub ActualizaCargaAcompañada(ByVal doc As Integer, ByVal boleto As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_actualiza_carga_acompanada", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", doc, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_nroboleto", boleto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_proceso", IIf(boleto = "", 0, 6), OracleClient.OracleType.VarChar)
            db.EjecutarComando()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function fnLoadVentaCarga1(ByVal IdAgencia_ As Integer, ByVal IdUnidadAgen_ As Integer) As Boolean
        Dim flag As Boolean = True
        Try
            Dim Impresora As Integer = 1
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_INICIAR_VENTA_CONTADO", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_idagencias", IdAgencia_, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idunidad_agencia", IdUnidadAgen_, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            '
            db_bd.AsignarParametro("cur_t_tipo_comprobante", OracleClient.OracleType.Cursor) '0
            db_bd.AsignarParametro("cur_UNIDAD_AGENCIAS", OracleClient.OracleType.Cursor) '1
            db_bd.AsignarParametro("cur_t_Tipo_Entrega", OracleClient.OracleType.Cursor) '2
            db_bd.AsignarParametro("cur_t_Forma_Pago", OracleClient.OracleType.Cursor) '3
            db_bd.AsignarParametro("cur_T_TARJETAS", OracleClient.OracleType.Cursor) '4
            db_bd.AsignarParametro("cur_Tipo_Pago", OracleClient.OracleType.Cursor) '5
            'nuevos cursores
            db_bd.AsignarParametro("cur_Listado_Producto", OracleClient.OracleType.Cursor) '6
            db_bd.AsignarParametro("cur_factor_m3_kg", OracleClient.OracleType.Cursor) '7
            db_bd.AsignarParametro("cur_control_version", OracleClient.OracleType.Cursor) '8
            db_bd.AsignarParametro("cur_NombreAgencia", OracleClient.OracleType.Cursor) '9
            db_bd.AsignarParametro("cur_NombreCiudad", OracleClient.OracleType.Cursor) '10
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor) '11


            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet

            '
            dt_cur_t_tipo_comprobante = lds_tmp.Tables(0)
            dt_cur_UNIDAD_AGENCIAS = lds_tmp.Tables(1)
            dt_cur_t_Tipo_Entrega = lds_tmp.Tables(2)
            dt_cur_t_Forma_Pago = lds_tmp.Tables(3)
            dt_cur_T_TARJETAS = lds_tmp.Tables(4)
            dt_cur_Tipo_Pago = lds_tmp.Tables(5)
            '
            cur_Listado_Producto = lds_tmp.Tables(6)
            '********
            If lds_tmp.Tables(7).Rows.Count > 0 Then
                If lds_tmp.Tables(7).Rows(0).Item(0) IsNot System.DBNull.Value Then
                    VFactor_ = lds_tmp.Tables(7).Rows(0).Item("FACTOR_M3_KG")
                End If
            End If
            '**********
            If lds_tmp.Tables(8).Rows.Count > 0 Then
                tipo_bole_impre = lds_tmp.Tables(8).Rows(0).Item("tipo_bole_impre")
                tipo_factu_impre = lds_tmp.Tables(8).Rows(0).Item("tipo_factu_impre")
            Else
                MsgBox("No se ha podido encontrar ningún registro...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '************
            If lds_tmp.Tables(9).Rows.Count > 0 Then
                If lds_tmp.Tables(9).Rows(0).Item(0) IsNot System.DBNull.Value Then
                    Agencia_ = lds_tmp.Tables(9).Rows(0).Item("NOMBRE_AGENCIA")
                End If
            End If

            '**************
            If lds_tmp.Tables(10).Rows.Count > 0 Then
                If lds_tmp.Tables(10).Rows(0).Item(0) IsNot System.DBNull.Value Then
                    Ciudad_ = lds_tmp.Tables(10).Rows(0).Item("NOMBRE_UNIDAD")
                End If
            End If
            '**************
            If lds_tmp.Tables(11).Rows.Count > 0 Then
                Impresora = lds_tmp.Tables(11).Rows(0).Item("IMPRESION")
                NOMBRE_IMPRESORA = lds_tmp.Tables(11).Rows(0).Item("Control_Impresoras")
            Else
                Impresora = 0
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    Public Function ListarProceso() As DataTable
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("sp_Listar_Proceso", CommandType.StoredProcedure)
            db_bd.AsignarParametro("co_proceso", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim ds As DataSet = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Public Function ListarProceso(ByVal opcion As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            'db_bd.CrearComando("sp_Listar_Proceso_1", CommandType.StoredProcedure)
            db_bd.CrearComando("sp_Listar_Proceso_2", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_rol", G_Rol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_proceso", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim ds As DataSet = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function
    Public Function BuscarCliente(ByVal iControl As Integer, ByVal NroDoc As String, ByVal idOrigen As Integer, ByVal idDestino As Integer, ByVal producto As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet
            '
            dt_cur_persona = Nothing
            dt_cur_cont_origen = Nothing
            dt_cur_cont_destino = Nothing
            dt_cur_dire_origen = Nothing
            dt_cur_dire_destino = Nothing
            dt_cur_Articulos = Nothing
            ' 
            dt_cur_persona = New DataTable
            dt_cur_cont_origen = New DataTable
            dt_cur_cont_destino = New DataTable
            dt_cur_dire_origen = New DataTable
            dt_cur_dire_destino = New DataTable
            dt_cur_Articulos = New DataTable
            '
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_FILTRO_CLIENTES_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nu_docu_suna", NroDoc, OracleClient.OracleType.VarChar)
            'db_bd.AsignarParametro("v_razon_social", RasonSocial, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUnidadOrigen", idOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IdUnidadDestino", idDestino, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)

            'Variables de salidas 
            db_bd.AsignarParametro("cur_persona", OracleClient.OracleType.Cursor)
            'db_bd.AsignarParametro("cur_cont_origen", OracleClient.OracleType.Cursor)
            'db_bd.AsignarParametro("cur_cont_destino", OracleClient.OracleType.Cursor)
            'db_bd.AsignarParametro("cur_dire_origen", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_dire_destino", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            '
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_cur_persona = lds_tmp.Tables(0)
            'dt_cur_cont_origen = lds_tmp.Tables(1)
            'dt_cur_cont_destino = lds_tmp.Tables(1)
            'dt_cur_dire_origen = lds_tmp.Tables(3)
            dt_cur_dire_destino = lds_tmp.Tables(1)
            dt_cur_Articulos = lds_tmp.Tables(2)
            '
            Dim cantArti_ As Integer = dt_cur_Articulos.Rows.Count()
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function fnSP_BUSCAR_ULTIMAPERSONACONTACTO(ByVal vDNIRUC As String, ByVal v_IDPersona As Integer, ByVal IDUNIDAD_ORIGEN As Integer) As Boolean
        Dim flag As Boolean = False
        ''''
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_BUSCAR_ULTIMOCONTACTO", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_DNIRUC", vDNIRUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPersona", v_IDPersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUnidad_Agencia", IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet

            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
                v_IDNOMBRES_CONTROL = lds_tmp.Tables(0).Rows(0).Item("Idcontacto_Persona")
                v_NOMBRES_CONTROL = lds_tmp.Tables(0).Rows(0).Item("Nombres")
                v_DNI_CONTROL = lds_tmp.Tables(0).Rows(0).Item("Nrodocumento")
                v_TIPO_DOCUMENTO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("idtipo_documento_contacto")), 9, lds_tmp.Tables(0).Rows(0).Item("idtipo_documento_contacto"))
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function GrabarIII() As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        Try
            'objLOG.fnLog("entrando grabarII")
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    If bOrigenDiferente = False Then
                        v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                        v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If
                End If
            End If
            '
            'conecta con la Bd
            '
            db_bd.Conectar()
            'hlamas
            '-- Invocando  al procedimiento almacenado - 16/09/2009  - 
            '-- hlamas 24-10-2008
            'db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_VENTA_CONTADO_CARGA_V", CommandType.StoredProcedure)
            '-- hlamas 06-08-2010
            'db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure)

            '*******richard*****
            '30/05/20011
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure)        
            db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VIII", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", 1, OracleClient.OracleType.Int32) 'agregado 1 por default
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPERSONA_ORIGEN", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar) '
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)

            '*****Parametros Nuevos*****  
            db_bd.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db_bd.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)

            '            
            db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_contacto1_mod", contacto1_mod, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32)

            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows(0)(0) = 0 Then
                'MsgBox(lds_tmp.Tables(0).Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                MsgBox("NO PUEDE REALIZAR ESTA OPERACION, DOC. YA EXISTE", MsgBoxStyle.Information, "Seguridad Sistema")
                flag = False
                Return flag
            End If
            '
            dv_rstVarGrabarEditar = lds_tmp.Tables(0).DefaultView
            '
            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                'If rstVarGrabarEditar.BOF = False And rstVarGrabarEditar.EOF = False Then
                'Cur_CODIGOBARRAS = rstVarGrabarEditar.NextRecordset

                dv_Cur_CODIGOBARRAS = lds_tmp.Tables(1).DefaultView
                '
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                MsgBox(dv_rstVarGrabarEditar.Table.Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                            ObjVentaCargaContado.fnIncrementarNroDoc(3)

                        End If
                    Else
                        ObjVentaCargaContado.fnIncrementarNroDoc(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If

                'End If
            Else
                MsgBox("Vefique sus datos...No ha sido Grabado", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            'objLOG.fnLog("saliendo grabarII")
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnIncrementarNroDocR(ByVal idTipoComprobante As Integer)
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet            'conecta con la Bd
            db_bd.Conectar()
            'db_bd.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO", CommandType.StoredProcedure)
            db_bd.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDAGENCIAS", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTIPO_COMPROBANTE", idTipoComprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_proceso", v_iProceso, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Function Buscar(ByVal item As String, ByVal opcion As Integer, ByVal origen As Integer, ByVal destino As Integer, Optional ByVal modo As Integer = 0, Optional ByVal producto As Integer = 0, Optional ByVal mantenimiento As Integer = 0, Optional ByVal cliente As Integer = 0) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_Buscar", CommandType.StoredProcedure)
            db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_modo", modo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_mantenimiento", mantenimiento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_lineaCredito", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Descuento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Inicio(ByVal agencia As Integer, Optional ByVal opcion As Integer = 0, Optional origen As Integer = 0) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_inicio_2", CommandType.StoredProcedure)
            'db.CrearComando("PKG_VENTACONTADO.sp_inicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_via", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_zona", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_nivel", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_clasificacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_departamento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_provincia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_distrito", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo_documento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    'Function BuscarDireccion(ByVal cliente As Integer) As DataSet
    '    Dim db As New BaseDatos
    '    Try
    '        db.Conectar()
    '        db.CrearComando("PKG_VENTACONTADO.sp_BuscarDireccion", CommandType.StoredProcedure)
    '        db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
    '        db.Desconectar()
    '        Return db.EjecutarDataSet

    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    Finally
    '        db.Desconectar()
    '    End Try
    'End Function

    'Function BuscarContacto(ByVal item As String, ByVal opcion As Integer, ByVal ciudad As Integer) As DataSet
    '    Dim db As New BaseDatos
    '    Try
    '        db.Conectar()
    '        db.CrearComando("PKG_VENTACONTADO.sp_BuscarContacto", CommandType.StoredProcedure)
    '        db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
    '        db.Desconectar()
    '        Return db.EjecutarDataSet

    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    Finally
    '        db.Desconectar()
    '    End Try
    'End Function

    Function BuscarConsignado(ByVal item As String, ByVal opcion As Integer, ByVal ciudad As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_BuscarConsignado", CommandType.StoredProcedure)
            db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_consignado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function BuscarConsignado(ByVal id As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_BuscarConsignado", CommandType.StoredProcedure)
            db.AsignarParametro("ni_consignado", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_consignado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function BuscarCliente(ByVal item As String, ByVal opcion As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_BuscarCliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
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

    Function ListarProducto() As DataTable
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_GUIA_ENVIO_2.sp_Producto", CommandType.StoredProcedure)
            db_bd.AsignarParametro("Co_Productos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarProducto(tipo As Integer, Optional todo As Integer = 0) As DataTable
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_GUIA_ENVIO_2.sp_Producto", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_todo", todo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("Co_Productos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnVERDATA_VI(ByVal x_IDFACTURA As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim db_bd As New BaseDatos
    '        Dim lds_tmp As New DataSet
    '        db_bd.Conectar()
    '        db_bd.CrearComando("PKG_VENTACONTADO.SP_VER_VENTACONTADO_I", CommandType.StoredProcedure)
    '        db_bd.AsignarParametro("vi_Idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("co_data", OracleClient.OracleType.Cursor) '0
    '        db_bd.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor) '1
    '        db_bd.AsignarParametro("co_Volumetrico", OracleClient.OracleType.Cursor) '2
    '        db_bd.AsignarParametro("co_Documentos", OracleClient.OracleType.Cursor) '3
    '        db_bd.Desconectar()
    '        '
    '        lds_tmp = db_bd.EjecutarDataSet
    '        If lds_tmp.Tables(0).Rows.Count > 0 Then
    '            flag = True
    '            v_IDTIPO_COMPROBANTE = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Comprobante")
    '            v_NRO_GUIA = lds_tmp.Tables(0).Rows(0).Item("Nro_Guia")
    '            v_SERIE_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Serie_Factura")
    '            v_NRO_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Nro_Factura")
    '            v_UNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("origen")
    '            v_IDUNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("iddestino")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino") '
    '            v_UNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("destino")
    '            v_IDTIPO_ENTREGA = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Entrega")
    '            v_IDFORMA_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idforma_Pago")
    '            v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino")
    '            v_FECHA_FACTURA = lds_tmp.Tables(0).Rows(0).Item("FECHA_FACTURA")
    '            v_IDTIPO_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Pago")
    '            v_IDTARJETAS = lds_tmp.Tables(0).Rows(0).Item("Idtarjetas")
    '            '
    '            v_IDUNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("Idunidad_Origen")
    '            v_IDAGENCIAS = lds_tmp.Tables(0).Rows(0).Item("Idagencias")
    '            '
    '            v_NROTARJETA = lds_tmp.Tables(0).Rows(0).Item("NROTARJETA")
    '            v_NRO_DNI_RUC = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")
    '            v_NOMBRES_RASONSOCIAL = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
    '            '
    '            v_DIRECCION_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("DirOrigen")
    '            v_DIRECCION_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("DirDestino")
    '            v_IDCONTACTO_DESTINO = lds_tmp.Tables(0).Rows(0).Item("IDCONTACTO_DESTINO") 'nuevo
    '            v_IDDIREECION_DESTINO = lds_tmp.Tables(0).Rows(0).Item("iddireecion_destino") 'nuevo
    '            v_IDDIREECION_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("iddireecion_origen") 'nuevo
    '            v_METROCUBICO = lds_tmp.Tables(0).Rows(0).Item("METRO_CUBICO") 'nuevo                   
    '            v_TELEFONO_REMITENTE = IIf(lds_tmp.Tables(0).Rows(0).Item("telefono") = " ", "", lds_tmp.Tables(0).Rows(0).Item("telefono"))
    '            v_PORCENT_DESCUENTO = lds_tmp.Tables(0).Rows(0).Item("Porcent_Descuento")
    '            v_MEMO = lds_tmp.Tables(0).Rows(0).Item("Memo")
    '            v_NOMBRES_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("remitente")
    '            v_NRO_DOC_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("dniremitente")
    '            v_NOMBRES_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("Destinatario")
    '            v_NRO_DOC_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("dniDestinatario")

    '            v_TELEFONO_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Tel_destino")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Tel_destino"))  '23/11/2009 

    '            v_TOTAL_PESO = lds_tmp.Tables(0).Rows(0).Item("Total_Peso")
    '            v_TOTAL_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Total_Volumen")
    '            v_CANTIDAD_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Peso")
    '            v_CANTIDAD_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
    '            v_CANTIDAD_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
    '            v_PRECIO_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Peso")
    '            v_PRECIO_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Volumen")
    '            v_PRECIO_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Sobre")
    '            v_MONTO_BASE = lds_tmp.Tables(0).Rows(0).Item("Monto_Base")
    '            v_MONTO_SUB_TOTAL = lds_tmp.Tables(0).Rows(0).Item("Monto_Sub_Total")
    '            v_MONTO_IMPUESTO = lds_tmp.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
    '            v_TOTAL_COSTO = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
    '            v_CANTIDAD_X_ARTICULO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Articulos")
    '            v_MONTO_MINIMOs = lds_tmp.Tables(0).Rows(0).Item("Monto_Minimo")
    '            v_cargo = lds_tmp.Tables(0).Rows(0).Item("cargo")
    '            v_nroboleto = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("nroboleto")), "", lds_tmp.Tables(0).Rows(0).Item("nroboleto"))
    '            v_proceso = lds_tmp.Tables(0).Rows(0).Item("proceso")
    '            v_facturado = lds_tmp.Tables(0).Rows(0).Item("facturado")
    '            v_idpersona_cli = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cli")), 9, lds_tmp.Tables(0).Rows(0).Item("cli"))
    '            v_idpersona_ori = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ori")), 9, lds_tmp.Tables(0).Rows(0).Item("ori"))
    '            v_idpersona_des = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("des")), 9, lds_tmp.Tables(0).Rows(0).Item("des"))
    '            '
    '            dt_cur_Articulos1 = lds_tmp.Tables(1)
    '            dt_cur_Volumetrico = lds_tmp.Tables(2)
    '            dt_cur_Documentos = lds_tmp.Tables(3)
    '            '
    '        End If
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    '    Return flag
    'End Function

    Public Function fnBuscarCliente(ByVal iControl As Integer, ByVal NroDoc As String, ByVal idOrigen As Integer, ByVal idDestino As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As DataSet
            '
            dt_cur_persona = Nothing
            dt_cur_cont_origen = Nothing
            dt_cur_cont_destino = Nothing
            dt_cur_dire_origen = Nothing
            dt_cur_dire_destino = Nothing
            dt_cur_Articulos = Nothing
            ' 
            dt_cur_persona = New DataTable
            dt_cur_cont_origen = New DataTable
            dt_cur_cont_destino = New DataTable
            dt_cur_dire_origen = New DataTable
            dt_cur_dire_destino = New DataTable
            dt_cur_Articulos = New DataTable
            '
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_FILTRO_CLIENTES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nu_docu_suna", NroDoc, OracleClient.OracleType.VarChar)
            'db_bd.AsignarParametro("v_razon_social", RasonSocial, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUnidadOrigen", idOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IdUnidadDestino", idDestino, OracleClient.OracleType.Int32)
            ' db_bd.AsignarParametro("ni_idCentroCostro", idCentroCosto, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_persona", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_cont_origen", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_cont_destino", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_dire_origen", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_dire_destino", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            '
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_cur_persona = lds_tmp.Tables(0)
            dt_cur_cont_origen = lds_tmp.Tables(1)
            dt_cur_cont_destino = lds_tmp.Tables(2)
            dt_cur_dire_origen = lds_tmp.Tables(3)
            dt_cur_dire_destino = lds_tmp.Tables(4)
            dt_cur_Articulos = lds_tmp.Tables(5)
            '
            Dim cantArti_ As Integer = dt_cur_Articulos.Rows.Count()
            flag = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    'Public Function GrabarIV() As Boolean
    '    Dim flag As Boolean = False
    '    Dim db_bd As New BaseDatos
    '    Dim ds As New DataSet
    '    Try
    '        iCONTROL = 1
    '        v_IDFACTURA = 0
    '        '
    '        v_IDTIPO_MONEDA = 1
    '        v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '        v_IP = dtoUSUARIOS.IP
    '        v_IDROL_USUARIO = dtoUSUARIOS.IdRol
    '        '
    '        v_IDFUNCIONARIO_AUTORIZACION = 0
    '        v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
    '        '
    '        If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
    '            v_NRO_GUIA = "NULL"
    '        End If

    '        If v_IDTIPO_COMPROBANTE = 3 Then
    '            v_IDTIPO_COMPROBANTE = 85
    '        End If

    '        '
    '        If v_MEMO = "" Then
    '            v_MEMO = "@"
    '        End If
    '        '
    '        If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
    '            v_NRO_DNI_RUC = "@"
    '        End If

    '        If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
    '            v_NRO_DOC_DESTINATARIO = "@"
    '        End If

    '        If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
    '            v_NRO_DOC_REMITENTE = "@"
    '        End If

    '        If V_CONTROL_PCE = False Then
    '            v_NRO_GUIA = "NULL"
    '        End If

    '        If V_CONTROL_PCE = False Then
    '            If v_OTRAS_AGENCIAS = False Then
    '                If bOrigenDiferente = False Then
    '                    v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
    '                    v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
    '                End If
    '            End If
    '        End If
    '        db_bd.Conectar()

    '        '*******richard*****          1020799  
    '        'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure) ------>   '19/07/2011
    '        db_bd.CrearComando("PKG_VENTACONTADO.SP_VENTA_CONTADO_CARGA_VIIII", CommandType.StoredProcedure)
    '        db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDFORMA_PAGO", 1, OracleClient.OracleType.Int32) 'agregado 1 por default
    '        db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@
    '        db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
    '        db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
    '        'objLOG.fnLog("antes p_TIPOs")
    '        db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
    '        'objLOG.fnLog("despues p_TIPOs")
    '        db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
    '        'hlamas 06-08-2010 carga acompañada 
    '        db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_carga_acompañada", v_carga_acompañada, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
    '        '
    '        db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

    '        db_bd.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
    '        db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
    '        '---
    '        db_bd.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)

    '        '==============Variables nuevas==============
    '        db_bd.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
    '        '******variables nombre Modificado Cliente************************           
    '        db_bd.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32) '---------->agregar
    '        db_bd.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_email", sEmail, OracleClient.OracleType.VarChar)

    '        '******variables nombre Contacto Cliente*************************    
    '        db_bd.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32) '------------>agregar
    '        db_bd.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
    '        '******variables nombre Consignado *******************************  
    '        db_bd.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.Int32) '-------->agregar
    '        db_bd.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)

    '        '******variables Direccion estructurada Cliente*******************          
    '        db_bd.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

    '        '******variables Direccion estructurada Consig************   
    '        db_bd.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("v_referencia", sReferencia, OracleClient.OracleType.VarChar)
    '        '--Cliente------    
    '        db_bd.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32) 'L
    '        db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32) 'L
    '        db_bd.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)
    '        '--Consignado---
    '        db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32) 'L
    '        '==================================

    '        ''Variables de salidas 
    '        db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
    '        db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
    '        '135 parametros
    '        db_bd.Desconectar()
    '        ds = db_bd.EjecutarDataSet
    '        If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
    '            Throw New Exception(ds.Tables(2).Rows(0).Item(1))
    '        End If
    '        dv_rstVarGrabarEditar = ds.Tables(0).DefaultView

    '        V_CONTROL_PCE = False
    '        v_CANTIDAD_ETIQUETAS = 0
    '        If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
    '            dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
    '            '
    '            v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
    '            v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
    '            v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
    '            MessageBox.Show(dv_rstVarGrabarEditar.Table.Rows(0)(1), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            'validacion para el correlativo de guias de envio...   
    '            'Try
    '            '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
    '            'Catch ex As Exception
    '            'End Try

    '            If v_IDFACTURA = 0 Then
    '                flag = False
    '            Else
    '                flag = True
    '                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
    '                    If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
    '                        ObjVentaCargaContado.fnIncrementarNroDocR(3)
    '                    End If
    '                Else
    '                    ObjVentaCargaContado.fnIncrementarNroDocR(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
    '                End If
    '                v_NROGUIA_VIGENTE = ""
    '                v_NRO_GUIA = ""
    '            End If
    '        End If
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    '*****INSERCION DE N REGISTROS VOLUMETRICO*********
    Public Sub FNinsert_Volumetrico(ByVal Limpiar As Integer, ByVal ID_VOLUMETRICO As Integer, ByVal v_ID_FACTURA As Integer, ByVal v_ITEM As Integer, ByVal v_CANTIDAD As Integer, _
                                         ByVal v_ALTURA As Double, ByVal v_ANCHO As Double, ByVal v_LARGO As Double, _
                                         ByVal v_PESO_KG As Double, ByVal v_FACTOR As Double, ByVal v_PRECIO_COSTO As Double)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_Ins_Volumetrico", CommandType.StoredProcedure)
            db.AsignarParametro("vi_LimpiarDatos", Limpiar, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ID_VOLUMETRICO", ID_VOLUMETRICO, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ID_FACTURA", v_ID_FACTURA, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_ITEM", v_ITEM, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_CANTIDAD", v_CANTIDAD, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_ALTURA", v_ALTURA, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_ANCHO", v_ANCHO, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_LARGO", v_LARGO, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_PESO_KG", v_PESO_KG, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_FACTOR", v_FACTOR, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_PRECIO_COSTO", v_PRECIO_COSTO, OracleClient.OracleType.Double)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '0         
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable

            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Public Function ActualizarVenta() As Boolean
        Dim flag As Boolean = False
        Dim db As New BaseDatos
        Try
            iCONTROL = 1
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            If v_MEMO = "" Then
                v_MEMO = "@"
            End If

            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            db.Conectar()
            '*******richard*****
            db.CrearComando("PKG_VENTACONTADO.SP_VENTA_CONTADO_UPDATE_I", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDFORMA_PAGO", 1, OracleClient.OracleType.Int32) 'agregado 1 por default
            db.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@                        
            db.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
            db.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada 
            db.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            db.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)

            '==============Variables nuevas==============
            db.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
            '******variables nombre Modificado Cliente************************           
            db.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32) '---------->agregar
            db.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_email", sEmail, OracleClient.OracleType.VarChar)

            '******variables nombre Contacto**********************************    
            db.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
            '******variables nombre Consignado ******************************* 
            db.AsignarParametro("v_IDVentaConsignado", IDVentaConsignado.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.VarChar)
            '******variables Direccion estructurada Cliente*******************          
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
            db.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

            '******variables Direccion estructurada Consig************   
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
            db.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_referencia", sReferencia, OracleClient.OracleType.VarChar)
            '--Cliente------    
            db.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32) 'L
            db.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32) 'L
            db.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)
            '--Consignado---            
            db.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32) 'L
            '==================================

            ''Variables de salidas 
            db.AsignarParametro("datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor) '1            
            db.AsignarParametro("co_venta", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor) '3
            '
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            '***************PROPAGANDO EL ERROR*********
            If ds.Tables(3).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(3).Rows(0).Item(0)) Then
                    If ds.Tables(3).Rows(0).Item(0) = -20001 Then
                        Throw New Excepcion("El Comprobante de Venta está Liquidado")
                    ElseIf ds.Tables(3).Rows(0).Item(0) = -20002 Then
                        Throw New Excepcion("El Comprobante de Venta Tiene Cierre Contable")
                    Else
                        Throw New Excepcion(ds.Tables(3).Rows(0).Item(1))
                    End If
                End If
            End If
                '*****************************************

                dv_rstVarGrabarEditar = ds.Tables(0).DefaultView
                '
                V_CONTROL_PCE = False
                v_CANTIDAD_ETIQUETAS = 0

                If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                    dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
                    dtVenta = ds.Tables(2)
                    v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                    v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                    v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                    MsgBox(dv_rstVarGrabarEditar.Table.Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                Else
                    Throw New Exception("Verifique sus datos...No ha sido Grabado")
                End If
                flag = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flag = False
        End Try
        Return flag
    End Function

    Public Function TarifaGeneral(ByVal iNu_Docu_Suna As String, ByVal iAGENCIA_ORIGEN As Integer, _
                               ByVal iAGENCIA_DESTINO As Integer, ByVal iIDCENTROCOSTO As Integer) As Integer
        Dim db_bd As New BaseDatos
        Try
            Dim ls_sql As String
            ls_sql = "select PKG_VENTACONTADO.sf_TarifarioGeneral(" & iNu_Docu_Suna & ",'" & iAGENCIA_ORIGEN & "','" & _
                                                                 iAGENCIA_DESTINO & "','" & iIDCENTROCOSTO & "') from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)

            Try
                Return db_bd.EjecutarEscalar
            Catch
            End Try

        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function Listar(ByVal i_Control As Integer, ByVal NroDoc As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_GUIA_ENVIO_2.sp_listarPCE", CommandType.StoredProcedure)
            db.AsignarParametro("n_control", i_Control, OracleClient.OracleType.Int32)
            db.AsignarParametro("nrodoc", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_guia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Buscar(ByVal idpersona As String, ByVal origen As Integer, ByVal destino As Integer) As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_Buscar", CommandType.StoredProcedure)
            db.AsignarParametro("vi_idpersona", idpersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_lineaCredito", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Descuento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function fnVERDATA_VI(ByVal x_IDFACTURA As Integer) As DataSet
        'Dim flag As Boolean = False
        Try
            Dim db As New BaseDatos
            Dim ds As New DataSet
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.SP_VER_VENTACONTADO_I", CommandType.StoredProcedure)
            db.AsignarParametro("vi_Idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_data", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_Articulos", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Volumetrico", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_Documentos", OracleClient.OracleType.Cursor) '3
            db.AsignarParametro("co_condicion_tarifa", OracleClient.OracleType.Cursor) '4
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '5
            db.Desconectar()
            ds = db.EjecutarDataSet

            '--------Propagando el error----------------------------------
            If ds.Tables(5).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(5).Rows(0).Item(0)) Then
                    If ds.Tables(5).Rows(0).Item(0) = -20000 Then
                        Throw New Excepcion(ds.Tables(5).Rows(0).Item(1))
                    End If
                End If
            End If
            '-------------------------------------------------------------1

            If ds.Tables(0).Rows.Count > 0 Then
                'flag = True
                '--Producto--
                v_proceso = ds.Tables(0).Rows(0).Item("proceso")
                '--TipoTarifa--
                TipoTarifa = ds.Tables(0).Rows(0).Item("tipo_tarifa")
                v_IDTIPO_COMPROBANTE = ds.Tables(0).Rows(0).Item("Idtipo_Comprobante")
                v_NRO_GUIA = ds.Tables(0).Rows(0).Item("Nro_Guia")
                v_SERIE_FACTURA = ds.Tables(0).Rows(0).Item("Serie_Factura")
                v_NRO_FACTURA = ds.Tables(0).Rows(0).Item("Nro_Factura")
                v_IDTIPO_ENTREGA = ds.Tables(0).Rows(0).Item("Idtipo_Entrega")
                v_IDFORMA_PAGO = ds.Tables(0).Rows(0).Item("Idforma_Pago")                
                v_FECHA_FACTURA = ds.Tables(0).Rows(0).Item("FECHA_FACTURA")
                v_IDTIPO_PAGO = ds.Tables(0).Rows(0).Item("Idtipo_Pago")
                v_IDTARJETAS = ds.Tables(0).Rows(0).Item("Idtarjetas")

                'AGENCIA ORIGEN
                v_UNIDAD_ORIGEN = ds.Tables(0).Rows(0).Item("origen")
                v_IDUNIDAD_ORIGEN = ds.Tables(0).Rows(0).Item("Idunidad_Origen")
                v_IDAGENCIAS = ds.Tables(0).Rows(0).Item("Idagencias")

                'AGENCIA DESTINO
                v_UNIDAD_DESTINO = ds.Tables(0).Rows(0).Item("destino")
                v_IDUNIDAD_DESTINO = ds.Tables(0).Rows(0).Item("iddestino")
                v_IDAGENCIAS_DESTINO = ds.Tables(0).Rows(0).Item("Idagencias_Destino") '

                v_NROTARJETA = ds.Tables(0).Rows(0).Item("NROTARJETA")
                v_NRO_DNI_RUC = ds.Tables(0).Rows(0).Item("Nu_Docu_Suna").ToString.Trim
                v_NOMBRES_RASONSOCIAL = ds.Tables(0).Rows(0).Item("Razon_Social")                               
                v_DIRECCION_REMITENTE = ds.Tables(0).Rows(0).Item("DirOrigen")
                v_DIRECCION_DESTINATARIO = ds.Tables(0).Rows(0).Item("DirDestino")
                v_IDCONTACTO_DESTINO = ds.Tables(0).Rows(0).Item("IDCONTACTO_DESTINO") 'nuevo
                v_IDDIREECION_DESTINO = ds.Tables(0).Rows(0).Item("iddireecion_destino") 'nuevo
                v_IDDIREECION_ORIGEN = ds.Tables(0).Rows(0).Item("iddireecion_origen") 'nuevo
                v_METROCUBICO = ds.Tables(0).Rows(0).Item("METRO_CUBICO") 'nuevo                   
                v_TELEFONO_REMITENTE = IIf(ds.Tables(0).Rows(0).Item("telefono") = " ", "", ds.Tables(0).Rows(0).Item("telefono"))
                v_PORCENT_DESCUENTO = ds.Tables(0).Rows(0).Item("Porcent_Descuento")
                v_MEMO = ds.Tables(0).Rows(0).Item("Memo")
                v_NOMBRES_REMITENTE = ds.Tables(0).Rows(0).Item("remitente")
                v_NRO_DOC_REMITENTE = ds.Tables(0).Rows(0).Item("dniremitente").ToString.Trim

                '*****DATOS CONTACTO*******************

                '*****DATOS CONSIGNADO*****************
                v_TIPODOC_CONSIGNADO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idTipoDocConsig")), 9, ds.Tables(0).Rows(0).Item("idTipoDocConsig"))
                v_NRO_DOC_DESTINATARIO = ds.Tables(0).Rows(0).Item("dniDestinatario").ToString.Trim
                v_NOMBRES_DESTINATARIO = ds.Tables(0).Rows(0).Item("Nombres")
                v_NOMBRE_CONSIGNADO = ds.Tables(0).Rows(0).Item("Nombre")
                v_APEPAT_CONSIGNADO = ds.Tables(0).Rows(0).Item("Apepat")
                v_APEMAT_CONSIGNADO = ds.Tables(0).Rows(0).Item("Apemat")


                v_TELEFONO_DESTINATARIO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Tel_destino")) = True, "", ds.Tables(0).Rows(0).Item("Tel_destino"))  '23/11/2009 

                v_TOTAL_PESO = ds.Tables(0).Rows(0).Item("Total_Peso")
                v_TOTAL_VOLUMEN = ds.Tables(0).Rows(0).Item("Total_Volumen")
                v_CANTIDAD_X_PESO = ds.Tables(0).Rows(0).Item("Cantidad_x_Peso")
                v_CANTIDAD_X_VOLUMEN = ds.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
                v_CANTIDAD_X_SOBRE = ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
                v_PRECIO_X_PESO = ds.Tables(0).Rows(0).Item("Precio_x_Peso")
                v_PRECIO_X_VOLUMEN = ds.Tables(0).Rows(0).Item("Precio_x_Volumen")
                v_PRECIO_X_SOBRE = ds.Tables(0).Rows(0).Item("Precio_x_Sobre")
                v_MONTO_BASE = ds.Tables(0).Rows(0).Item("Monto_Base")
                v_MONTO_SUB_TOTAL = ds.Tables(0).Rows(0).Item("Monto_Sub_Total")
                v_MONTO_IMPUESTO = ds.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
                v_TOTAL_COSTO = ds.Tables(0).Rows(0).Item("Total_Costo")
                v_CANTIDAD_X_ARTICULO = ds.Tables(0).Rows(0).Item("Cantidad_x_Articulos")
                v_MONTO_MINIMOs = ds.Tables(0).Rows(0).Item("Monto_Minimo")
                v_cargo = ds.Tables(0).Rows(0).Item("cargo")
                v_nroboleto = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nroboleto")), "", ds.Tables(0).Rows(0).Item("nroboleto"))
                v_facturado = ds.Tables(0).Rows(0).Item("facturado")
                v_IDPERSONA = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idpersona")), 9, ds.Tables(0).Rows(0).Item("idpersona"))
                v_idpersona_cli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("cli")), 9, ds.Tables(0).Rows(0).Item("cli"))
                v_IDPERSONA_ORIGEN = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idpersona_origen")), 9, ds.Tables(0).Rows(0).Item("idpersona_origen"))

                v_Email = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Email")), "", ds.Tables(0).Rows(0).Item("Email"))
                v_Referencia = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nroboleto")), "", ds.Tables(0).Rows(0).Item("nroboleto"))
                '
                'dt_cur_Articulos1 = ds.Tables(1)
                'dt_cur_Volumetrico = ds.Tables(2)
                'dt_cur_Documentos = ds.Tables(3)
                'dt_cur_CondicionTarifa = ds.Tables(4)
                '           
                Return ds
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Return flag
    End Function

    Function BuscarContacto(ByVal cliente As String, ByVal contacto As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_buscar_contacto", CommandType.StoredProcedure)
            db.AsignarParametro("vi_cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_contacto", contacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function BuscarContacto(ByVal contacto As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_buscar_contacto", CommandType.StoredProcedure)
            db.AsignarParametro("vi_contacto", contacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Shared Function BuscarCliente(ByVal item As String) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_BuscarCliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_item", item, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0).Item("idpersona")) Then
                    Return 0
                Else
                    Return dt.Rows(0).Item("idpersona")
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function GrabarVII() As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim ds As New DataSet
        Try
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            'If v_IDTIPO_COMPROBANTE = 3 Then
            '    v_IDTIPO_COMPROBANTE = 85
            'End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    If bOrigenDiferente = False Then
                        v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                        v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If
                End If
            End If

            If v_MONTO_SUB_TOTAL + v_MONTO_IMPUESTO <> v_TOTAL_COSTO Then
                v_MONTO_SUB_TOTAL = FormatNumber(Format(v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
                v_MONTO_IMPUESTO = FormatNumber(Format(0.18 * v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
            End If

            db_bd.Conectar()
            '*******richard*****          1020799  
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure) ------>   '19/07/2011
            'db_bd.CrearComando("PKG_VENTACONTADO.SP_VENTA_CONTADO_CARGA_VIIII", CommandType.StoredProcedure)
            'db_bd.CrearComando("PKG_GUIA_ENVIO_2.SP_VENTA_CONTADO_CARGA_VIIII", CommandType.StoredProcedure)
            'db_bd.CrearComando("PKG_GUIA_ENVIO_2.SP_VENTA_CONTADO_CARGA_X", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_GUIA_ENVIO_2.SP_GRABAR_PCE", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", 3, OracleClient.OracleType.Int32) 'agregado 1 por default
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@                        
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada 
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db_bd.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db_bd.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MontoMinimo", v_MONTO_MINIMOs, OracleClient.OracleType.Int32) '->nuevo parametro

            '==============Variables=============
            db_bd.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
            '******variables nombre  CLIENTE********************************           
            db_bd.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Email", sEmail, OracleClient.OracleType.VarChar) '07092011 Nuevo Parametro

            '******variables nombre REMITENTE******************************** nuevo           
            db_bd.AsignarParametro("ni_RemitenteModificado", iRemitenteModificado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDRemitente", iIDRemitente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombresRemitente", sNombresRemitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NumeroDocumento", sNumeroDocumento, OracleClient.OracleType.VarChar) 'juridico
            db_bd.AsignarParametro("v_ID_TipoDocumentoRemitente", iID_TipoDocumentoRemitente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombreRemitente", sNombreRemitente, OracleClient.OracleType.VarChar) 'nombre
            db_bd.AsignarParametro("v_apellidoPaternoRemitente", sApellidoPaternoRemitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellidoMaternoRemitente", sApellidoMaternoRemitente, OracleClient.OracleType.VarChar)
            '******variables nombre CONTACTO*********************************    
            db_bd.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
            '******variables nombre CONSIGNADO****************************** NUEVO
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.VarChar)

            '******variables Direccion estructurada Cliente*******************          
            db_bd.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

            '******variables Direccion estructurada Consig************   
            db_bd.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            '--Cliente------    
            db_bd.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)

            '--Consignado---            
            db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32) 'L
            '==================================
            db_bd.AsignarParametro("ni_MontoEntregaDomicilio", MontoEntregaDomicilio, OracleClient.OracleType.Number) 'L
            db_bd.AsignarParametro("ni_MontoDevolucionCargo", MontoDC, OracleClient.OracleType.Number) 'L
            db_bd.AsignarParametro("vi_observacion_cargo", ObservacionCargo, OracleClient.OracleType.VarChar) 'L

            db_bd.AsignarParametro("vi_fecha_partida", v_FechaPartida, OracleClient.OracleType.VarChar) 'L
            db_bd.AsignarParametro("vi_hora_partida", v_HoraPartida, OracleClient.OracleType.VarChar) 'L

            db_bd.AsignarParametro("ni_equipaje", v_equipaje, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("vi_motivo_equipaje", v_MotivoEquipaje, OracleClient.OracleType.VarChar) 'L
            db_bd.AsignarParametro("ni_usuario_equipaje", v_UsuarioEquipaje, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_nivel_equipaje", v_NivelEquipaje, OracleClient.OracleType.Int32) 'L

            db_bd.AsignarParametro("vi_servicio", v_servicio, OracleClient.OracleType.VarChar) 'L

            db_bd.AsignarParametro("vi_motivo_descuento", v_MotivoDescuento, OracleClient.OracleType.VarChar) 'L

            db_bd.AsignarParametro("ni_formato", 1, OracleClient.OracleType.Int32) 'L

            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '135 parametros
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet

            If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                Throw New Exception(ds.Tables(2).Rows(0).Item(1))
            End If
            dv_rstVarGrabarEditar = ds.Tables(0).DefaultView

            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
                '
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                v_GUIA = dv_rstVarGrabarEditar.Table.Rows(0)(4)
                MsgBox(dv_rstVarGrabarEditar.Table.Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        'If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                        ObjVentaCargaContado.fnIncrementarNroDocR(3)
                        'End If
                    ElseIf ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        ObjVentaCargaContado.fnIncrementarNroDocR(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    'Actualizar PCEContado
    Public Function ActualizarPCEContado() As Boolean
        Dim flag As Boolean = False
        Dim db As New BaseDatos
        Try
            iCONTROL = 1
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            If v_MEMO = "" Then
                v_MEMO = "@"
            End If

            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            db.Conectar()
            '*******richard*****
            db.CrearComando("PKG_GUIA_ENVIO_2.SP_ActualizarPCEContado", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDFORMA_PAGO", 1, OracleClient.OracleType.Int32) 'agregado 1 por default
            db.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@                        
            db.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
            db.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada 
            db.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            db.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)

            '==============Variables nuevas==============
            db.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
            '******variables nombre Modificado Cliente************************           
            db.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_email", sEmail, OracleClient.OracleType.VarChar)

            '******variables nombre REMITENTE******************************** nuevo           
            db.AsignarParametro("ni_RemitenteModificado", iRemitenteModificado, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDRemitente", iIDRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombresRemitente", sNombresRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NumeroDocumento", sNumeroDocumento, OracleClient.OracleType.VarChar) 'juridico
            db.AsignarParametro("v_ID_TipoDocumentoRemitente", iID_TipoDocumentoRemitente, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreRemitente", sNombreRemitente, OracleClient.OracleType.VarChar) 'nombre
            db.AsignarParametro("v_apellidoPaternoRemitente", sApellidoPaternoRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellidoMaternoRemitente", sApellidoMaternoRemitente, OracleClient.OracleType.VarChar)
            '******variables nombre Contacto Cliente*************************    
            db.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
            '******variables nombre Consignado ******************************* 
            db.AsignarParametro("v_IDVentaConsignado", IDVentaConsignado.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.VarChar)

            '******variables Direccion estructurada Cliente*******************          
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
            db.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

            '******variables Direccion estructurada Consig************   
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
            db.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar)

            '--Cliente------    
            db.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)
            '--Consignado---            
            db.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32)
            '==================================

            ''Variables de salidas 
            db.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_venta", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            '***************PROPAGANDO EL ERROR*********
            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    If ds.Tables(2).Rows(0).Item(0) = -20000 Then
                        '    Throw New Excepcion("El Comprobante de Venta Tiene Cierre Contable. No Podrá Ser Modificado.")
                        'Else
                        Throw New Excepcion(ds.Tables(2).Rows(0).Item(1))
                    End If
                End If
            End If
            '*****************************************


            'ObjVentaCargaContado.NombConsignado_mod &= GrdNConsignado("Modificado", i).Value & ";"

            dv_rstVarGrabarEditar = ds.Tables(0).DefaultView
            '
            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0

            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
                dtVenta = ds.Tables(3)
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                MsgBox(IIf(IsDBNull(dv_rstVarGrabarEditar.Table.Rows(0)(1)), ds.Tables(2).Rows(0)(0).ToString, dv_rstVarGrabarEditar.Table.Rows(0)(1)), MsgBoxStyle.Information, "Seguridad Sistema")
            Else
                Throw New Exception("Verifique sus datos...No ha sido Grabado")
            End If
            flag = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flag = False
        End Try
        Return flag
    End Function

    Public Function GrabarIV() As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim ds As New DataSet
        Try
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    If bOrigenDiferente = False Then
                        v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                        v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If
                End If
            End If
            db_bd.Conectar()

            '*******richard*****          1020799  
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure) ------>   '19/07/2011
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_VIII", CommandType.StoredProcedure)
            'hlamas 15-04-2016
            'db_bd.CrearComando("pkg_ventacontado.SP_GRABAR_CANCELAR_PCE", CommandType.StoredProcedure)
            'hlamas 22-10-2016
            'db_bd.CrearComando("pkg_ventacontado.sp_grabar_venta_contado", CommandType.StoredProcedure)
            db_bd.CrearComando("pkg_ventacontado.sp_cancelar_pce", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", 1, OracleClient.OracleType.Int32) 'agregado 1 por default
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@                        
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada 
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db_bd.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db_bd.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)

            '==============Variables nuevas==============
            db_bd.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
            '******variables nombre Modificado Cliente************************           
            db_bd.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32) '---------->agregar
            db_bd.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_email", sEmail, OracleClient.OracleType.VarChar)

            '******variables nombre Contacto**********************************    
            db_bd.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
            '******variables nombre Consignado ******************************* 
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.VarChar)
            '******variables Direccion estructurada Cliente*******************          
            db_bd.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

            '******variables Direccion estructurada Consig************   
            db_bd.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_referencia", sReferencia, OracleClient.OracleType.VarChar)
            '--Cliente------    
            db_bd.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)
            '--Consignado---            
            db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32) 'L
            '==================================
            'hlamas 04-12-2013
            db_bd.AsignarParametro("ni_MontoEntregaDomicilio", MontoEntregaDomicilio, OracleClient.OracleType.Number) 'L

            db_bd.AsignarParametro("ni_MontoDevolucionCargo", MontoDC, OracleClient.OracleType.Number) 'L

            db_bd.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32) 'L

            db_bd.AsignarParametro("ni_cancela_pce", intCancelaPCE, OracleClient.OracleType.Int32) 'L

            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '135 parametros
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                Throw New Exception(ds.Tables(2).Rows(0).Item(1))
            End If
            dv_rstVarGrabarEditar = ds.Tables(0).DefaultView

            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
                '
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")

                '-->##Begin 27/05/2016 - jabanto
                v_SERIE_FACTURA = dv_rstVarGrabarEditar.Table.Rows(0)("serieComprobante")
                v_NRO_FACTURA = dv_rstVarGrabarEditar.Table.Rows(0)("numeroComprobante")
                v_direccion = dv_rstVarGrabarEditar.Table.Rows(0)("direccion")
                '-->##End begin 

                MessageBox.Show(dv_rstVarGrabarEditar.Table.Rows(0)(1), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                            ObjVentaCargaContado.fnIncrementarNroDocR(3)
                        End If
                    ElseIf intCancelaPCE = 0 Then
                        ObjVentaCargaContado.fnIncrementarNroDocR(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnVERDATA_IV(ByVal x_IDFACTURA As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_VER_VENTACONTADO_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("x_Idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_data", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
                v_IDTIPO_COMPROBANTE = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Comprobante")
                v_NRO_GUIA = lds_tmp.Tables(0).Rows(0).Item("Nro_Guia")
                v_SERIE_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Serie_Factura")
                v_NRO_FACTURA = lds_tmp.Tables(0).Rows(0).Item("Nro_Factura")
                v_UNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("origen")
                v_IDUNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("iddestino")
                v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino") '
                v_UNIDAD_DESTINO = lds_tmp.Tables(0).Rows(0).Item("destino")
                v_IDTIPO_ENTREGA = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Entrega")
                v_IDFORMA_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idforma_Pago")
                v_IDAGENCIAS_DESTINO = lds_tmp.Tables(0).Rows(0).Item("Idagencias_Destino")
                v_FECHA_FACTURA = lds_tmp.Tables(0).Rows(0).Item("FECHA_FACTURA")
                v_IDTIPO_PAGO = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Pago")
                v_IDTARJETAS = lds_tmp.Tables(0).Rows(0).Item("Idtarjetas")
                '
                v_IDUNIDAD_ORIGEN = lds_tmp.Tables(0).Rows(0).Item("Idunidad_Origen")
                v_IDAGENCIAS = lds_tmp.Tables(0).Rows(0).Item("Idagencias")
                '
                v_NROTARJETA = lds_tmp.Tables(0).Rows(0).Item("NROTARJETA")
                v_NRO_DNI_RUC = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")
                v_NOMBRES_RASONSOCIAL = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
                '
                v_DIRECCION_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("DirOrigen")
                v_DIRECCION_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("DirDestino")
                v_TELEFONO_REMITENTE = IIf(lds_tmp.Tables(0).Rows(0).Item("telefono") = " ", "", lds_tmp.Tables(0).Rows(0).Item("telefono"))
                v_PORCENT_DESCUENTO = lds_tmp.Tables(0).Rows(0).Item("Porcent_Descuento")
                v_MEMO = lds_tmp.Tables(0).Rows(0).Item("Memo")
                v_NOMBRES_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("remitente")
                v_NRO_DOC_REMITENTE = lds_tmp.Tables(0).Rows(0).Item("dniremitente")
                v_NOMBRES_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("Destinatario")
                v_NRO_DOC_DESTINATARIO = lds_tmp.Tables(0).Rows(0).Item("dniDestinatario")

                v_TELEFONO_DESTINATARIO = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("Tel_destino")) = True, "", lds_tmp.Tables(0).Rows(0).Item("Tel_destino"))  '23/11/2009 

                v_TOTAL_PESO = lds_tmp.Tables(0).Rows(0).Item("Total_Peso")
                v_TOTAL_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Total_Volumen")
                v_CANTIDAD_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Peso")
                v_CANTIDAD_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
                v_CANTIDAD_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
                v_PRECIO_X_PESO = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Peso")
                v_PRECIO_X_VOLUMEN = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Volumen")
                v_PRECIO_X_SOBRE = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Sobre")
                v_MONTO_BASE = lds_tmp.Tables(0).Rows(0).Item("Monto_Base")
                v_MONTO_SUB_TOTAL = lds_tmp.Tables(0).Rows(0).Item("Monto_Sub_Total")
                v_MONTO_IMPUESTO = lds_tmp.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
                v_TOTAL_COSTO = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
                v_CANTIDAD_X_ARTICULO = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Articulos")
                v_MONTO_MINIMOs = lds_tmp.Tables(0).Rows(0).Item("Monto_Minimo")
                v_cargo = lds_tmp.Tables(0).Rows(0).Item("cargo")
                'hlamas 06-08-2010 carga acompañada
                v_nroboleto = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("nroboleto")), "", lds_tmp.Tables(0).Rows(0).Item("nroboleto"))
                v_proceso = lds_tmp.Tables(0).Rows(0).Item("proceso")
                v_facturado = lds_tmp.Tables(0).Rows(0).Item("facturado")
                v_idpersona_cli = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("cli")), 9, lds_tmp.Tables(0).Rows(0).Item("cli"))
                v_idpersona_ori = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("ori")), 9, lds_tmp.Tables(0).Rows(0).Item("ori"))
                v_idpersona_des = IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item("des")), 9, lds_tmp.Tables(0).Rows(0).Item("des"))
                '
                dt_cur_Articulos = lds_tmp.Tables(1)
                dt_cur_Documentos = lds_tmp.Tables(2)
                '
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    Public Function ListarOpciones() As DataSet
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_PRUEBA.SP_LISTAROPCIONES_I", CommandType.StoredProcedure)
            db_bd.AsignarParametro("co_LISTAR_PRODUCTO", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_LISTAR_FUNCIONARIO", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_LISTAR_COMPROBANTE", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim ds As DataSet = db_bd.EjecutarDataSet
            If ds.Tables(3).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(3).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(3).Rows(0).Item(2))
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function


    'CambioR 10112011
    Function TipoDocumento() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_TipoDocumentos", CommandType.StoredProcedure)
            db.AsignarParametro("co_tipo_documento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    'CambioR 10112011
    Public Sub GrabarConsignado(ByVal IDConsignado As String, ByVal IDComprobante As Integer, ByVal IDTipoComprobante As Integer, _
                               ByVal IDUnidadDestino As Integer, ByVal IDPERSONA As String, ByVal IDUSUARIO_PERSONAL As Integer, _
                                ByVal IDROL_USUARIO As Integer, ByVal IP As String, _
                                         ByVal Nombres As String, ByVal Nombre As String, ByVal apellPaterno As String, _
                                         ByVal apellMaterno As String, ByVal NroDocumento As String, ByVal IDTipoDocumento As String, _
                                         ByVal Telefono As String, ByVal existe As Integer)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_PRUEBA.SP_Grabar_Consignado2", CommandType.StoredProcedure)
            db.AsignarParametro("v_IDConsignado", IDConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDFACTURA", IDComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IDTIPO_COMPROBANTE", IDTipoComprobante, OracleClient.OracleType.Int32)

            db.AsignarParametro("v_IDUNIDAD_DESTINO", IDUnidadDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_cliente", IDPERSONA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombresConsignado", Nombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NombreConsignado", Nombre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellPatConsig", apellPaterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apellMatConsig", apellMaterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_NRO_DOC_DESTINATARIO", NroDocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IDTipoDocConsig", IDTipoDocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_TelfConsig", Telefono, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_existe", existe, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor) '0         
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '1        
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Function ListaConsignado(ByVal idControl As Integer, ByVal idDoc As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_CARGA.SP_ListaConsignado", CommandType.StoredProcedure)
            db.AsignarParametro("iControl", idControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("xiIDDOC", idDoc.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas            
            db.AsignarParametro("co_consignado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarContacto(ByVal contacto As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_PRUEBA.sp_ListarContacto", CommandType.StoredProcedure)
            db.AsignarParametro("vi_contacto", contacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Direccion(ByVal IDDireccionDestino As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_Direccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDDireccion", IDDireccionDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Direccion_I(ByVal idpersona As Integer, ByVal idagenciaDestino As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_Direccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", idpersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_Destino", idagenciaDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function fnVERDATA_VII(ByVal x_IDFACTURA As Integer) As DataSet
        'Dim flag As Boolean = False
        Try
            Dim db As New BaseDatos
            Dim ds As New DataSet
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.SP_VER_VENTACONTADO_II", CommandType.StoredProcedure)
            db.AsignarParametro("vi_Idfactura", x_IDFACTURA.ToString, OracleClient.OracleType.VarChar)
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

            If ds.Tables(0).Rows.Count > 0 Then
                'flag = True
                '--Producto--
                v_proceso = ds.Tables(0).Rows(0).Item("proceso")
                '--TipoTarifa--
                TipoTarifa = ds.Tables(0).Rows(0).Item("tipo_tarifa")
                v_IDTIPO_COMPROBANTE = ds.Tables(0).Rows(0).Item("Idtipo_Comprobante")
                v_NRO_GUIA = ds.Tables(0).Rows(0).Item("Nro_Guia")
                v_SERIE_FACTURA = ds.Tables(0).Rows(0).Item("Serie_Factura")
                v_NRO_FACTURA = ds.Tables(0).Rows(0).Item("Nro_Factura")
                v_UNIDAD_ORIGEN = ds.Tables(0).Rows(0).Item("origen")
                v_IDUNIDAD_DESTINO = ds.Tables(0).Rows(0).Item("iddestino")
                v_IDAGENCIAS_DESTINO = ds.Tables(0).Rows(0).Item("Idagencias_Destino") '
                v_UNIDAD_DESTINO = ds.Tables(0).Rows(0).Item("destino")
                v_IDTIPO_ENTREGA = ds.Tables(0).Rows(0).Item("Idtipo_Entrega")
                v_IDFORMA_PAGO = ds.Tables(0).Rows(0).Item("Idforma_Pago")
                v_IDAGENCIAS_DESTINO = ds.Tables(0).Rows(0).Item("Idagencias_Destino")
                v_FECHA_FACTURA = ds.Tables(0).Rows(0).Item("FECHA_FACTURA")
                v_IDTIPO_PAGO = ds.Tables(0).Rows(0).Item("Idtipo_Pago")
                v_IDTARJETAS = ds.Tables(0).Rows(0).Item("Idtarjetas")
                '
                v_IDUNIDAD_ORIGEN = ds.Tables(0).Rows(0).Item("Idunidad_Origen")
                v_IDAGENCIAS = ds.Tables(0).Rows(0).Item("Idagencias")
                '
                v_NROTARJETA = ds.Tables(0).Rows(0).Item("NROTARJETA")
                v_NRO_DNI_RUC = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Nu_Docu_Suna")), "", ds.Tables(0).Rows(0).Item("Nu_Docu_Suna"))
                v_NOMBRES_RASONSOCIAL = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Razon_Social")), "", ds.Tables(0).Rows(0).Item("Razon_Social"))
                '                
                v_DIRECCION_REMITENTE = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("DirOrigen")), "", ds.Tables(0).Rows(0).Item("DirOrigen"))
                v_DIRECCION_DESTINATARIO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("DirDestino")), "", ds.Tables(0).Rows(0).Item("DirDestino"))
                v_IDDIREECION_DESTINO = ds.Tables(0).Rows(0).Item("iddireecion_destino")
                v_IDDIREECION_ORIGEN = ds.Tables(0).Rows(0).Item("iddireecion_origen")
                v_METROCUBICO = ds.Tables(0).Rows(0).Item("METRO_CUBICO")
                v_TELEFONO_REMITENTE = IIf(ds.Tables(0).Rows(0).Item("telefono") = " ", "", ds.Tables(0).Rows(0).Item("telefono"))
                v_PORCENT_DESCUENTO = ds.Tables(0).Rows(0).Item("Porcent_Descuento")
                v_MEMO = ds.Tables(0).Rows(0).Item("Memo")
                v_NOMBRES_REMITENTE = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombresRemitente")), "", ds.Tables(0).Rows(0).Item("NombresRemitente"))
                v_NRO_DOC_REMITENTE = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniContacto")), "", ds.Tables(0).Rows(0).Item("dniContacto"))

                '*****DATOS CONTACTO*******************

                '*****DATOS CONSIGNADO*****************
                v_IDCONTACTO_DESTINO = ds.Tables(0).Rows(0).Item("IDCONTACTO_DESTINO")
                v_TELEFONO_DESTINATARIO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Tel_destino")), "", ds.Tables(0).Rows(0).Item("Tel_destino"))
                v_NOMBRES_DESTINATARIO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Nombres")), "", ds.Tables(0).Rows(0).Item("Nombres"))
                v_NOMBRE_CONSIGNADO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Nombre")), "", ds.Tables(0).Rows(0).Item("Nombre"))
                v_APEPAT_CONSIGNADO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Apepat")), "", ds.Tables(0).Rows(0).Item("Apepat"))
                v_APEMAT_CONSIGNADO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Apemat")), "", ds.Tables(0).Rows(0).Item("Apemat"))
                v_NRO_DOC_DESTINATARIO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniDestinatario")), "", ds.Tables(0).Rows(0).Item("dniDestinatario"))
                v_TIPODOC_CONSIGNADO = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idTipoDocConsig")), 9, ds.Tables(0).Rows(0).Item("idTipoDocConsig"))



                v_TOTAL_PESO = ds.Tables(0).Rows(0).Item("Total_Peso")
                v_TOTAL_VOLUMEN = ds.Tables(0).Rows(0).Item("Total_Volumen")
                v_CANTIDAD_X_PESO = ds.Tables(0).Rows(0).Item("Cantidad_x_Peso")
                v_CANTIDAD_X_VOLUMEN = ds.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
                v_CANTIDAD_X_SOBRE = ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
                v_PRECIO_X_PESO = ds.Tables(0).Rows(0).Item("Precio_x_Peso")
                v_PRECIO_X_VOLUMEN = ds.Tables(0).Rows(0).Item("Precio_x_Volumen")
                v_PRECIO_X_SOBRE = ds.Tables(0).Rows(0).Item("Precio_x_Sobre")
                v_MONTO_BASE = ds.Tables(0).Rows(0).Item("Monto_Base")
                v_MONTO_SUB_TOTAL = ds.Tables(0).Rows(0).Item("Monto_Sub_Total")
                v_MONTO_IMPUESTO = ds.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
                v_TOTAL_COSTO = ds.Tables(0).Rows(0).Item("Total_Costo")
                v_CANTIDAD_X_ARTICULO = ds.Tables(0).Rows(0).Item("Cantidad_x_Articulos")
                v_MONTO_MINIMOs = ds.Tables(0).Rows(0).Item("Monto_Minimo")
                v_cargo = ds.Tables(0).Rows(0).Item("cargo")
                v_nroboleto = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nroboleto")), "", ds.Tables(0).Rows(0).Item("nroboleto"))
                v_facturado = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("facturado")), 0, ds.Tables(0).Rows(0).Item("facturado"))
                v_IDPERSONA = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idpersona")), 9, ds.Tables(0).Rows(0).Item("idpersona"))
                v_idpersona_cli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("cli")), 9, ds.Tables(0).Rows(0).Item("cli"))
                v_IDPERSONA_ORIGEN = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ID_Contacto")), 9, ds.Tables(0).Rows(0).Item("ID_Contacto"))

                v_Email = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Email")), "", ds.Tables(0).Rows(0).Item("Email"))
                v_Referencia = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("De_Referencia")), "", ds.Tables(0).Rows(0).Item("De_Referencia"))

                MontoEntregaDomicilio = ds.Tables(0).Rows(0).Item("monto_entrega_domicilio")
                Return ds
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Return flag
    End Function

    Public Function ListarUsuarios(ByVal idunidadOrigen As Integer, ByVal usuario As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_ListaUsuarios", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_idunidadOrigen", idunidadOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_ListaUsuarios", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim ds As DataSet = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    'USUARIO REMOTO
    Public Function GrabarV() As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim ds As New DataSet
        Try
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            v_IDTIPO_MONEDA = 1
            'v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    If bOrigenDiferente = False Then
                        v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                        v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If
                End If
            End If

            'If v_MONTO_SUB_TOTAL + v_MONTO_IMPUESTO <> v_TOTAL_COSTO Then
            '    v_MONTO_SUB_TOTAL = FormatNumber(Format(v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
            '    v_MONTO_IMPUESTO = FormatNumber(Format(0.18 * v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
            'End If

            db_bd.Conectar()
            '*******richard*****          1020799  
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure) ------>   '19/07/2011
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_IX", CommandType.StoredProcedure)
            'hlamas 15-04-2016
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_IX_2", CommandType.StoredProcedure)
            db_bd.CrearComando("pkg_ventacontado.sp_grabar_venta_contado_man", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", 1, OracleClient.OracleType.Int32) 'agregado 1 por default
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@                        
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32) 'iIDUsuarioRemoto
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada 
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db_bd.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db_bd.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_IDUsuarioRemoto", iIDUsuarioRemoto, OracleClient.OracleType.Int32) 'v_IDUSUARIO_PERSONAL

            '==============Variables nuevas==============
            db_bd.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
            '******variables nombre Modificado Cliente************************           
            db_bd.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32) '---------->agregar
            db_bd.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_email", sEmail, OracleClient.OracleType.VarChar)

            '******variables nombre Contacto**********************************    
            db_bd.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
            '******variables nombre Consignado ******************************* 
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.VarChar)
            '******variables Direccion estructurada Cliente*******************          
            db_bd.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

            '******variables Direccion estructurada Consig************   
            db_bd.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_referencia", sReferencia, OracleClient.OracleType.VarChar)
            '--Cliente------    
            db_bd.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)
            '--Consignado---            
            db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32) 'L
            '==================================
            db_bd.AsignarParametro("ni_MontoEntregaDomicilio", MontoEntregaDomicilio, OracleClient.OracleType.Number) 'L
            db_bd.AsignarParametro("ni_MontoDevolucionCargo", MontoDC, OracleClient.OracleType.Number) 'L

            db_bd.AsignarParametro("vi_observacion_cargo", ObservacionCargo, OracleClient.OracleType.VarChar) 'L

            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '135 parametros
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                Throw New Exception(ds.Tables(2).Rows(0).Item(1))
            End If
            dv_rstVarGrabarEditar = ds.Tables(0).DefaultView

            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
                '
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                MessageBox.Show(dv_rstVarGrabarEditar.Table.Rows(0)(1), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                            ObjVentaCargaContado.fnIncrementarNroDocR(3)
                        End If
                        'hlamas 15-04-2016
                        'Else
                        'ObjVentaCargaContado.fnIncrementarNroDocR(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    'USUARIO REMOTO
    Public Function GrabarVIII() As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim ds As New DataSet
        Try
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            v_IDTIPO_MONEDA = 1
            'v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            'If v_IDTIPO_COMPROBANTE = 3 Then
            '    v_IDTIPO_COMPROBANTE = 85
            'End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    If bOrigenDiferente = False Then
                        v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                        v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If
                End If
            End If

            If v_MONTO_SUB_TOTAL + v_MONTO_IMPUESTO <> v_TOTAL_COSTO Then
                v_MONTO_SUB_TOTAL = FormatNumber(Format(v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
                v_MONTO_IMPUESTO = FormatNumber(Format(0.18 * v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
            End If

            db_bd.Conectar()
            '*******richard*****          1020799  
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure) ------>   '19/07/2011
            'db_bd.CrearComando("PKG_VENTACONTADO.SP_VENTA_CONTADO_CARGA_VIIII", CommandType.StoredProcedure)
            'db_bd.CrearComando("PKG_GUIA_ENVIO_2.SP_VENTA_CONTADO_CARGA_IX", CommandType.StoredProcedure)
            'hlamas 11-03-2019
            'db_bd.CrearComando("PKG_GUIA_ENVIO_2.SP_VENTA_CONTADO_CARGA_IX_2", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_GUIA_ENVIO_2.sp_grabar_pce_man", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", 3, OracleClient.OracleType.Int32) 'agregado 1 por default
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@                        
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada 
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db_bd.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db_bd.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MontoMinimo", v_MONTO_MINIMOs, OracleClient.OracleType.Int32) '->nuevo parametro
            db_bd.AsignarParametro("ni_IDUsuarioRemoto", iIDUsuarioRemoto, OracleClient.OracleType.Int32)
            '==============Variables=============
            db_bd.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
            '******variables nombre  CLIENTE********************************           
            db_bd.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Email", sEmail, OracleClient.OracleType.VarChar) '07092011 Nuevo Parametro

            '******variables nombre REMITENTE******************************** nuevo           
            db_bd.AsignarParametro("ni_RemitenteModificado", iRemitenteModificado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDRemitente", iIDRemitente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombresRemitente", sNombresRemitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NumeroDocumento", sNumeroDocumento, OracleClient.OracleType.VarChar) 'juridico
            db_bd.AsignarParametro("v_ID_TipoDocumentoRemitente", iID_TipoDocumentoRemitente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombreRemitente", sNombreRemitente, OracleClient.OracleType.VarChar) 'nombre
            db_bd.AsignarParametro("v_apellidoPaternoRemitente", sApellidoPaternoRemitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellidoMaternoRemitente", sApellidoMaternoRemitente, OracleClient.OracleType.VarChar)
            '******variables nombre CONTACTO*********************************    
            db_bd.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
            '******variables nombre CONSIGNADO****************************** NUEVO
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.VarChar)

            '******variables Direccion estructurada Cliente*******************          
            db_bd.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

            '******variables Direccion estructurada Consig************   
            db_bd.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            '--Cliente------    
            db_bd.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)
            '--Consignado---            
            db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32) 'L
            '==================================
            db_bd.AsignarParametro("ni_monto_entrega_domicilio", MontoEntregaDomicilio, OracleClient.OracleType.Number) 'L
            db_bd.AsignarParametro("ni_monto_devolucion_cargo", MontoDC, OracleClient.OracleType.Number) 'L

            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '135 parametros
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet

            If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                Throw New Exception(ds.Tables(2).Rows(0).Item(1))
            End If
            dv_rstVarGrabarEditar = ds.Tables(0).DefaultView

            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
                '
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                MsgBox(dv_rstVarGrabarEditar.Table.Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                    '    If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                    '        ObjVentaCargaContado.fnIncrementarNroDocR(3)
                    '    End If
                    'Else
                    '    ObjVentaCargaContado.fnIncrementarNroDocR(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                    'End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function
    Public Function ListaDatosLiquidacion(ByVal IDAgencia As Integer, ByVal iIDLiquidacion As Integer, ByVal Fecha As String, ByVal Opcion As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_DatosLiquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDLiquidacion", iIDLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDAgencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Fecha", Fecha, OracleClient.OracleType.VarChar)
            'hlamas 16-05-2017
            If CDate(Fecha) >= CDate("19/06/2017") Then
                db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            End If
            db.AsignarParametro("Co_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("Co_GastosLiquidacion", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function ListaReporteLiquidacion(ByVal IDAgencia As Integer, ByVal iIDLiquidacion As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_ReporteLiquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDLiquidacion", iIDLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDAgencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("Co_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("Co_GastosLiquidacion", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function ListaDatosAperturaCarga(ByVal IDUsuario As String, ByVal IDAgencia As Integer, ByVal iIDLiquidacion As Integer, ByVal Fecha As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_DETALLE_CARGA", CommandType.StoredProcedure)
            db.AsignarParametro("vi_Usuario", IDUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_IDLiquidacion", iIDLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDAgencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Fecha", Fecha, OracleClient.OracleType.VarChar)
            'hlamas 16-05-20167
            If CDate(Fecha) >= CDate("19/06/2017") Then
                db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            End If
            db.AsignarParametro("Co_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("Co_GastosLiquidacion", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Correlativo", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    ''' <summary>
    ''' OBTIENE LAS TARIFAS
    ''' </summary>
    ''' <param name="idUnidadOrigen">Identificador de la ciudad origen</param>
    ''' <param name="idUnidadDestino">Identificador dela ciudad destino</param>
    ''' <param name="idTipoPorducto">Identificador del tipo de producto</param>
    ''' <param name="idTipoTarifa">Identificador del tipo de tarifa</param>
    ''' <returns>Objeto tarifa</returns>
    Public Function obtenerTarifas(ByVal idUnidadOrigen As Integer, ByVal idUnidadDestino As Integer, ByVal idTipoProducto As Integer, ByVal idTipoTarifa As Integer, Optional tipo_entrega As Integer = 0) As dtoTarifasCargo
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        Dim PROCESO_TEPSA_BOX As Integer = 81
        db_bd.Conectar()

        'db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", CommandType.StoredProcedure)
        db_bd.CrearComando("SP_TARIFA_PUBLICA_VC", CommandType.StoredProcedure)
        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", idUnidadOrigen, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", idUnidadDestino, OracleClient.OracleType.Int32)
        'db_bd.AsignarParametro("ni_producto", TipoProducto_, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIPROCESO", idTipoProducto, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("ni_tarifa", idTipoTarifa, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("ni_TIPO_ENTREGA", tipo_entrega, OracleClient.OracleType.Int32)
        'Variables de salidas 
        db_bd.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
        'Desconectar
        db_bd.Desconectar()
        lds_tmp = db_bd.EjecutarDataSet()

        Dim tarifasCargo As New dtoTarifasCargo
        For Each rowTC As DataRow In lds_tmp.Tables(0).Rows
            If (rowTC("IDPROCESOS") = PROCESO_TEPSA_BOX) Then '-->TEPSA BOX (XARTICULO)
                Dim ID_ARTICULO_CAJA10_KLS As Integer = 342
                Dim ID_ARTICULO_CAJA05_KLS As Integer = 341

                If (rowTC("IDARTICULOS") = ID_ARTICULO_CAJA05_KLS) Then
                    tarifasCargo.importeArticulo_Caja5 = IIf(IsDBNull(rowTC("IMPORTE")), 0.0, rowTC("IMPORTE"))
                ElseIf (rowTC("IDARTICULOS") = ID_ARTICULO_CAJA10_KLS) Then
                    tarifasCargo.importeArticulo_Caja10 = IIf(IsDBNull(rowTC("IMPORTE")), 0.0, rowTC("IMPORTE"))
                End If
            Else
                tarifasCargo.precioBase = IIf(IsDBNull(rowTC("N_BASE")), 0.0, rowTC("N_BASE"))
                tarifasCargo.precioPeso = IIf(IsDBNull(rowTC("N_PESO")), 0.0, rowTC("N_PESO"))
                tarifasCargo.precioVolumen = IIf(IsDBNull(rowTC("N_VOLUMEN")), 0.0, rowTC("N_VOLUMEN"))
                tarifasCargo.precioSobre = IIf(IsDBNull(rowTC("N_SOBRE")), 0.0, rowTC("N_SOBRE"))
                tarifasCargo.estadoTarifa = IIf(IsDBNull(rowTC("N_ESTADO_TARIFA")), 0, rowTC("N_ESTADO_TARIFA"))
                tarifasCargo.fleteMinimoPeso = IIf(IsDBNull(rowTC("N_FLETE_MIN")), 0.0, rowTC("N_FLETE_MIN"))
                tarifasCargo.pesoMinimo = IIf(IsDBNull(rowTC("N_PESO_MIN")), 0.0, rowTC("N_PESO_MIN"))
                tarifasCargo.fleteMinimoVolumen = IIf(IsDBNull(rowTC("N_FLETE_MIN_VOL")), 0.0, rowTC("N_FLETE_MIN_VOL"))
                tarifasCargo.volumnenMinimo = IIf(IsDBNull(rowTC("N_VOL_MIN")), 0.0, rowTC("N_VOL_MIN"))
                tarifasCargo.cargoXReparto = IIf(IsDBNull(rowTC("N_CARGO_REPARTO")), 0.0, rowTC("N_CARGO_REPARTO"))
            End If
        Next

        '--> Si no encuentra resultados
        If (lds_tmp.Tables(0).Rows.Count <= 0) Then tarifasCargo = Nothing
        Return tarifasCargo
    End Function

    Public Function ObtenerTarifaPublica(ByVal idUnidadOrigen As Integer, ByVal idUnidadDestino As Integer, ByVal idTipoProducto As Integer, ByVal idTipoTarifa As Integer, Optional tipo_entrega As Integer = 0) As dtoTarifasCargo
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        Dim PROCESO_TEPSA_BOX As Integer = 81
        Dim PROCESO_TEPSA_BOX_10 As Integer = 82
        db_bd.Conectar()

        'db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", CommandType.StoredProcedure)
        'db_bd.CrearComando("SP_TARIFA_PUBLICA_VC", CommandType.StoredProcedure)
        'db_bd.CrearComando("SP_TARIFA_PUBLICA_VC_2", CommandType.StoredProcedure)
        db_bd.CrearComando("SP_TARIFA_PUBLICA_VC_3", CommandType.StoredProcedure)
        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", idUnidadOrigen, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", idUnidadDestino, OracleClient.OracleType.Int32)
        'db_bd.AsignarParametro("ni_producto", TipoProducto_, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIPROCESO", idTipoProducto, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("ni_tarifa", idTipoTarifa, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("ni_TIPO_ENTREGA", tipo_entrega, OracleClient.OracleType.Int32)
        'Variables de salidas 
        db_bd.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("cur_tarifa_articulo", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
        'Desconectar
        db_bd.Desconectar()
        lds_tmp = db_bd.EjecutarDataSet()

        Dim tarifasCargo As New dtoTarifasCargo
        For Each rowTC As DataRow In lds_tmp.Tables(0).Rows
            If (rowTC("IDPROCESOS") = PROCESO_TEPSA_BOX) Then '-->TEPSA BOX (XARTICULO)
                Dim ID_ARTICULO_CAJA10_KLS As Integer = 342
                Dim ID_ARTICULO_CAJA05_KLS As Integer = 341

                If (rowTC("IDARTICULOS") = ID_ARTICULO_CAJA05_KLS) Then
                    tarifasCargo.importeArticulo_Caja5 = IIf(IsDBNull(rowTC("IMPORTE")), 0.0, rowTC("IMPORTE"))
                ElseIf (rowTC("IDARTICULOS") = ID_ARTICULO_CAJA10_KLS) Then
                    tarifasCargo.importeArticulo_Caja10 = IIf(IsDBNull(rowTC("IMPORTE")), 0.0, rowTC("IMPORTE"))
                End If
            ElseIf (rowTC("IDPROCESOS") = PROCESO_TEPSA_BOX_10) Then '-->TEPSA BOX (XARTICULO)
                Dim ID_ARTICULO_CAJA10_KLS As Integer = 342
                Dim ID_ARTICULO_CAJA05_KLS As Integer = 341

                If (rowTC("IDARTICULOS") = ID_ARTICULO_CAJA05_KLS) Then
                    tarifasCargo.importeArticulo_Caja5 = IIf(IsDBNull(rowTC("IMPORTE")), 0.0, rowTC("IMPORTE"))
                ElseIf (rowTC("IDARTICULOS") = ID_ARTICULO_CAJA10_KLS) Then
                    tarifasCargo.importeArticulo_Caja10 = IIf(IsDBNull(rowTC("IMPORTE")), 0.0, rowTC("IMPORTE"))
                End If
            Else
                tarifasCargo.precioBase = IIf(IsDBNull(rowTC("N_BASE")), 0.0, rowTC("N_BASE"))
                tarifasCargo.precioPeso = IIf(IsDBNull(rowTC("N_PESO")), 0.0, rowTC("N_PESO"))
                tarifasCargo.precioVolumen = IIf(IsDBNull(rowTC("N_VOLUMEN")), 0.0, rowTC("N_VOLUMEN"))
                tarifasCargo.precioSobre = IIf(IsDBNull(rowTC("N_SOBRE")), 0.0, rowTC("N_SOBRE"))
                tarifasCargo.estadoTarifa = IIf(IsDBNull(rowTC("N_ESTADO_TARIFA")), 0, rowTC("N_ESTADO_TARIFA"))
                tarifasCargo.fleteMinimoPeso = IIf(IsDBNull(rowTC("N_FLETE_MIN")), 0.0, rowTC("N_FLETE_MIN"))
                tarifasCargo.pesoMinimo = IIf(IsDBNull(rowTC("N_PESO_MIN")), 0.0, rowTC("N_PESO_MIN"))
                tarifasCargo.fleteMinimoVolumen = IIf(IsDBNull(rowTC("N_FLETE_MIN_VOL")), 0.0, rowTC("N_FLETE_MIN_VOL"))
                tarifasCargo.volumnenMinimo = IIf(IsDBNull(rowTC("N_VOL_MIN")), 0.0, rowTC("N_VOL_MIN"))
                tarifasCargo.cargoXReparto = IIf(IsDBNull(rowTC("N_CARGO_REPARTO")), 0.0, rowTC("N_CARGO_REPARTO"))
            End If
        Next

        '--> Si no encuentra resultados
        If (lds_tmp.Tables(0).Rows.Count <= 0) Then tarifasCargo = Nothing
        'hlamas 21-01-2016
        dtTarifaArticuloPublico = lds_tmp.Tables(1)

        Return tarifasCargo
    End Function


    Public Shared Function ListarSubcuentas(cliente As Integer, ByVal ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_LIST_SUBCUENTAS_UNIDAD", CommandType.StoredProcedure)
            db.AsignarParametro("v_cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idUnidadAgencia", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_datos_Subcuentas", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function GrabarX(Optional ByVal showMessageConfirm As Boolean = True, Optional ByVal FormaPago As Integer = 1) As Boolean
        Dim flag As Boolean = False
        Dim db_bd As New BaseDatos
        Dim ds As New DataSet
        Try
            iCONTROL = 1
            v_IDFACTURA = 0
            '
            v_IDTIPO_MONEDA = 1
            v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            v_IP = dtoUSUARIOS.IP
            v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            '
            v_IDFUNCIONARIO_AUTORIZACION = 0
            v_NRO_DOC_DESTINATARIO = IIf(v_NRO_DOC_DESTINATARIO = "", "@", v_NRO_DOC_DESTINATARIO)
            '
            If v_NRO_GUIA = "" Or v_NRO_GUIA = "0" Or v_NRO_GUIA = " " Then
                v_NRO_GUIA = "NULL"
            End If

            If v_IDTIPO_COMPROBANTE = 3 Then
                v_IDTIPO_COMPROBANTE = 85
            End If

            '
            If v_MEMO = "" Then
                v_MEMO = "@"
            End If
            '
            If v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "" Or v_NRO_DNI_RUC = "NULL" Then
                v_NRO_DNI_RUC = "@"
            End If

            If v_NRO_DOC_DESTINATARIO = "" Or v_NRO_DOC_DESTINATARIO = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_DESTINATARIO = "@"
            End If

            If v_NRO_DOC_REMITENTE = "" Or v_NRO_DOC_REMITENTE = " " Or v_NRO_DOC_DESTINATARIO = "NULL" Then
                v_NRO_DOC_REMITENTE = "@"
            End If

            If V_CONTROL_PCE = False Then
                v_NRO_GUIA = "NULL"
            End If

            If V_CONTROL_PCE = False Then
                If v_OTRAS_AGENCIAS = False Then
                    If bOrigenDiferente = False Then
                        v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                        v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If
                End If
            End If
            db_bd.Conectar()

            If v_MONTO_SUB_TOTAL + v_MONTO_IMPUESTO <> v_TOTAL_COSTO Then
                v_MONTO_SUB_TOTAL = FormatNumber(Format(v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
                v_MONTO_IMPUESTO = FormatNumber(Format(0.18 * v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
            End If

            '*******richard*****          1020799  
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_CARGA_VII", CommandType.StoredProcedure) ------>   '19/07/2011
            'hlamas 15/04/2016
            'db_bd.CrearComando("pkg_ventacontado.SP_VENTA_CONTADO_X", CommandType.StoredProcedure)
            db_bd.CrearComando("pkg_ventacontado.sp_grabar_venta_contado", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDTIPO_COMPROBANTE", v_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_SERIE_FACTURA", v_SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_FACTURA", v_NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FACTURA", v_FECHA_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTIPO_PAGO", v_IDTIPO_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDFORMA_PAGO", FormaPago, OracleClient.OracleType.Int32) 'agregado 1 por default
            db_bd.AsignarParametro("v_IDTARJETAS", v_IDTARJETAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NROTARJETA", v_NROTARJETA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUNIDAD_ORIGEN", v_IDUNIDAD_ORIGEN, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS", v_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_DESTINO", v_IDUNIDAD_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDAGENCIAS_DESTINO", v_IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_RASONSOCIAL", v_NOMBRES_RASONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DNI_RUC", v_NRO_DNI_RUC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_IDCONTACTO_PERSONA", v_IDPERSONA_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_REMITENTE", v_NOMBRES_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_REMITENTE", v_NRO_DOC_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_ORIGEN", v_IDDIREECION_ORIGEN.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DIRECCION_REMITENTE", v_DIRECCION_REMITENTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_REMITENTE", v_TELEFONO_REMITENTE, OracleClient.OracleType.VarChar) '@                        
            db_bd.AsignarParametro("v_DIRECCION_DESTINATARIO", v_DIRECCION_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDDIREECION_DESTINO", v_IDDIREECION_DESTINO.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TELEFONO_DESTINATARIO", v_TELEFONO_DESTINATARIO, OracleClient.OracleType.VarChar) '@
            db_bd.AsignarParametro("v_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_MONTO_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_PESO", v_CANTIDAD_X_PESO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_CANTIDAD_X_VOLUMEN", CType(v_CANTIDAD_X_VOLUMEN, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_CANTIDAD_X_SOBRE", CType(v_CANTIDAD_X_SOBRE, Double), OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_PESO", v_TOTAL_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_VOLUMEN", v_TOTAL_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_SUB_TOTAL", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_IMPUESTO", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MONTO_PENALIDAD", v_MONTO_PENALIDAD, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDFUNCIONARIO_AUTORIZACION", v_IDFUNCIONARIO_AUTORIZACION, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IGV", v_IGV, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DEVOLUCION", v_PORCENT_DEVOLUCION, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PORCENT_DESCUENTO", v_PORCENT_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_RECARGO", v_MONTO_RECARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IDTIPO_ENTREGA", v_IDTIPO_ENTREGA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_ID_GUIAS_ENVIO_DOCs", IIf(v_ID_GUIAS_ENVIO_DOCs Is Nothing, "", v_ID_GUIAS_ENVIO_DOCs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_FECHAs", IIf(v_FECHAs Is Nothing, "", v_FECHAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_TIPO_CAMBIOs", IIf(v_MONTO_TIPO_CAMBIOs Is Nothing, "", v_MONTO_TIPO_CAMBIOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_MONEDAs", IIf(v_IDTIPO_MONEDAs Is Nothing, "", v_IDTIPO_MONEDAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_IDTIPO_COMPROBANTEs", IIf(v_IDTIPO_COMPROBANTEs Is Nothing, "", v_IDTIPO_COMPROBANTEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_SERIEs", IIf(v_NRO_SERIEs Is Nothing, "", v_NRO_SERIEs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_NRO_DOCUs", IIf(v_NRO_DOCUs Is Nothing, "", v_NRO_DOCUs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_MONTO_IMPUESTOs", IIf(v_MONTO_IMPUESTOs Is Nothing, "", v_MONTO_IMPUESTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_TOTAL_COSTOs", IIf(v_TOTAL_COSTOs Is Nothing, "", v_TOTAL_COSTOs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_PORCENs", IIf(v_PORCENs Is Nothing, "", v_PORCENs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_OBSs", IIf(v_OBSs Is Nothing, "", v_OBSs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("antes p_TIPOs")
            db_bd.AsignarParametro("p_TIPOs", IIf(v_TIPOs Is Nothing, "", v_TIPOs), OracleClient.OracleType.VarChar)
            'objLOG.fnLog("despues p_TIPOs")
            db_bd.AsignarParametro("p_PROCEDENCIAs", IIf(v_PROCEDENCIAs Is Nothing, "", v_PROCEDENCIAs), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_cargo", Abs(v_cargo), OracleClient.OracleType.Int32)
            'hlamas 06-08-2010 carga acompañada 
            db_bd.AsignarParametro("p_nroboleto", v_nroboleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_carga_acompanada", v_carga_acompañada, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencia_venta", v_idagencia_venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_TIPO_DOCUMENTO", v_TIPO_DOCUMENTO, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("P_SUB_TOTAL_CA", v_SUB_TOTAL_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_IMPUESTO_CA", v_IMPUESTO_CA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("P_TOTAL_CA", v_TOTAL_CA, OracleClient.OracleType.Double)

            db_bd.AsignarParametro("v_IdProceso", v_iProceso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_MetroCubico", v_METROCUBICO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Altura", v_ALTURA, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_largo", v_LARGO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ancho", v_ANCHO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Peso_Kg", v_PESO_KG, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Factor", v_FACTOR, OracleClient.OracleType.Double)
            '---
            db_bd.AsignarParametro("v_TarifarioGeneral", TarifarioGeneral, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Contado", Contado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_TipoTarifa", TipoTarifa, OracleClient.OracleType.Int32)

            '==============Variables nuevas==============
            db_bd.AsignarParametro("v_idciudad_venta", v_idciudad_venta, OracleClient.OracleType.Int32)
            '******variables nombre Modificado Cliente************************           
            db_bd.AsignarParametro("v_IDTipoDocCli", ID_TipoDocCli, OracleClient.OracleType.Int32) '---------->agregar
            db_bd.AsignarParametro("v_NombresCliente", NombresCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPat", apellPatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMat", apellMatCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfCli", TelefCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_email", sEmail, OracleClient.OracleType.VarChar)

            '******variables nombre Contacto**********************************    
            db_bd.AsignarParametro("v_IDtipoDocCont", ID_TipoDocCont, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NombreCont", NombreCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatCont", apellPatCont, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatCont", apellMatCont, OracleClient.OracleType.VarChar)
            '******variables nombre Consignado ******************************* 
            db_bd.AsignarParametro("v_IDCONTACTO_DESTINO", v_IDCONTACTO_DESTINO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES_DESTINATARIO", v_NOMBRES_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NombreConsignado", NombreConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellPatConsig", apellPatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_apellMatConsig", apellMatConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_DOC_DESTINATARIO", v_NRO_DOC_DESTINATARIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDTipoDocConsig", ID_TipoDocConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_TelfConsig", TelfConsignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_NombConsignado_mod", NombConsignado_mod, OracleClient.OracleType.VarChar)
            '******variables Direccion estructurada Cliente*******************          
            db_bd.AsignarParametro("v_id_DepartamentoCli", id_DepartamentoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaCli", id_ProvinciaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoCli", id_DistritoCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaCli", id_viaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaCli", viaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroCli", NumeroCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaCli", manzanaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteCli", loteCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelCli", id_nivelCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelCli", nivelCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaCli", id_zonaCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaCli", zonaCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionCli", id_clasificacionCli, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionCli", clasificacionCli, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoCli", formatoCli, OracleClient.OracleType.Int32)

            '******variables Direccion estructurada Consig************   
            db_bd.AsignarParametro("v_id_DepartamentoConsig", id_DepartamentoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_ProvinciaConsig", id_ProvinciaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_DistritoConsig", id_DistritoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_id_viaConsig", id_viaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_viaConsig", viaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_numeroConsig", NumeroConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_manzanaConsig", manzanaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_loteConsig", loteConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_nivelConsig", id_nivelConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_nivelConsig", nivelConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_zonaConsig", id_zonaConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_zonaConsig", zonaConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_id_clasificacionConsig", id_clasificacionConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_clasificacionConsig", clasificacionConsig, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_formatoConsig", formatoConsig, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_referencia", sReferencia, OracleClient.OracleType.VarChar)
            '--Cliente------    
            db_bd.AsignarParametro("ni_Cliente_mod", Cliente_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_DirecCli_mod", DirecCli_mod, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_contacto1_mod", contacto_mod, OracleClient.OracleType.Int32)
            '--Consignado---            
            db_bd.AsignarParametro("ni_DirecConsignado_mod", DirecConsignado_mod, OracleClient.OracleType.Int32) 'L
            '==================================
            db_bd.AsignarParametro("ni_MontoEntregaDomicilio", MontoEntregaDomicilio, OracleClient.OracleType.Number) 'L

            db_bd.AsignarParametro("ni_MontoDevolucionCargo", MontoDC, OracleClient.OracleType.Number) 'L

            db_bd.AsignarParametro("vi_observacion_cargo", ObservacionCargo, OracleClient.OracleType.VarChar) 'L

            db_bd.AsignarParametro("ni_version", v_version, OracleClient.OracleType.Number) 'L

            db_bd.AsignarParametro("vi_fecha_partida", v_FechaPartida, OracleClient.OracleType.VarChar) 'L
            db_bd.AsignarParametro("vi_hora_partida", v_HoraPartida, OracleClient.OracleType.VarChar) 'L

            db_bd.AsignarParametro("ni_equipaje", v_equipaje, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("vi_motivo_equipaje", v_MotivoEquipaje, OracleClient.OracleType.VarChar) 'L
            db_bd.AsignarParametro("ni_usuario_equipaje", v_UsuarioEquipaje, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_nivel_equipaje", v_NivelEquipaje, OracleClient.OracleType.Int32) 'L

            db_bd.AsignarParametro("vi_motivo_descuento", v_MotivoDescuento, OracleClient.OracleType.VarChar) 'L

            db_bd.AsignarParametro("vi_servicio", v_servicio, OracleClient.OracleType.VarChar) 'L
            db_bd.AsignarParametro("ni_asiento", v_asiento, OracleClient.OracleType.Int32) 'L
            db_bd.AsignarParametro("ni_total_boleto", v_total_boleto, OracleClient.OracleType.Number) 'L

            ''Variables de salidas 
            db_bd.AsignarParametro("datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_codbarra", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '135 parametros
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                Dim message As String = ds.Tables(2).Rows(0).Item(1)
                Throw New Excepcion(message)
            End If
            dv_rstVarGrabarEditar = ds.Tables(0).DefaultView

            V_CONTROL_PCE = False
            v_CANTIDAD_ETIQUETAS = 0
            If dv_rstVarGrabarEditar.Table.Rows.Count > 0 Then
                dv_Cur_CODIGOBARRAS = ds.Tables(1).DefaultView
                '
                v_IDFACTURA = dv_rstVarGrabarEditar.Table.Rows(0)(0)
                v_CANTIDAD_ETIQUETAS = dv_rstVarGrabarEditar.Table.Rows(0)(2)
                v_IDPERSONA = dv_rstVarGrabarEditar.Table.Rows(0)("idpersona")
                '-->##Begin 27/05/2016 - jabanto
                v_SERIE_FACTURA = dv_rstVarGrabarEditar.Table.Rows(0)("serieComprobante")
                v_NRO_FACTURA = dv_rstVarGrabarEditar.Table.Rows(0)("numeroComprobante")
                v_direccion = dv_rstVarGrabarEditar.Table.Rows(0)("direccion")
                '-->##End begin 

                v_MONTO_SUB_TOTAL = dv_rstVarGrabarEditar.Table.Rows(0)("subtotal")
                v_MONTO_IMPUESTO = dv_rstVarGrabarEditar.Table.Rows(0)("impuesto")

                If (showMessageConfirm) Then
                    MessageBox.Show(dv_rstVarGrabarEditar.Table.Rows(0)(1), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'validacion para el correlativo de guias de envio...   
                'Try
                '    ObjWebService.fnWebService(v_IDTIPO_COMPROBANTE, v_IDFACTURA, 18)
                'Catch ex As Exception
                'End Try

                If v_IDFACTURA = 0 Then
                    flag = False
                Else
                    flag = True
                    '-->Modificado 04/12/2015 - jabanto
                    If (v_IDTIPO_COMPROBANTE = 85 Or v_IDTIPO_COMPROBANTE = 3) Then
                        If Int(v_NROGUIA_VIGENTE) = Int(v_NRO_FACTURA) Then
                            fnIncrementarNroDocR(3)
                        End If
                    Else
                        'hlamas 15-04-2016
                        'fnIncrementarNroDocR(v_IDTIPO_COMPROBANTE)
                    End If
                    v_NROGUIA_VIGENTE = ""
                    v_NRO_GUIA = ""
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
            flag = False
        End Try
        Return flag
    End Function

    Public Function ObtieneDatosDescuento(comprobante As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_DESCUENTO_VENTA", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_descuento", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim ds As DataSet = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Public Function ObtienePromocion(nuevo As Integer, origen As Integer, destino As Integer, cliente As Integer, peso As Double, numero As String, Optional tipo As Integer = 0) As DataTable
        Dim db_bd As New BaseDatos
        Dim dt As DataTable
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOPROMOCION.sp_cliente_promocion", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_nuevo", nuevo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("vi_numero_documento", numero, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_tipo_documento", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_promocion", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            dt = db_bd.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Return dt
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Public Sub GrabaPromocion(promocion As Integer, cliente As Integer, descuento As Integer, envio As Integer, venta As Integer)
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOPROMOCION.sp_grabar_promocion", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_promocion", promocion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_descuento", descuento, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_envio", envio, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_venta", venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim dt As DataTable = db_bd.EjecutarDataTable
            If dT.Rows.Count > 0 Then
                If Not IsDBNull(dT.Rows(0).Item(0)) Then
                    Throw New Exception(dT.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Public Sub ActualizaClientePromocionEnvio(venta As Integer)
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOPROMOCION.sp_actualizar_cliente", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_venta", venta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim dt As DataTable = db_bd.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Public Shared Function MontoDevolucionCargo(Optional producto As Integer = 0, Optional cliente As Integer = 0) As Double
        Try
            Dim db As New BaseDatos
            Dim intValor As Integer = IIf(producto = 0, 1, 2)
            db.Conectar()
            db.CrearComando("select SF_TIPO_CONTROL(4," & intValor & ",1," & cliente & ") from dual", CommandType.Text)
            Dim dblMonto As Double = db.EjecutarEscalar
            Return dblMonto
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function ObtenerTarifa(cliente As String, origen As Integer, destino As Integer, tipo_entrega As Integer, producto As Integer, tipo_tarifa As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Dim dt As DataTable
        Try
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.sp_tarifa", CommandType.StoredProcedure)
            db_bd.AsignarParametro("vi_cliente", cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_entrega", tipo_entrega, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_tarifa", tipo_tarifa, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            dt = db_bd.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Return dt
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Public Function ObtenerTarifa(cliente As Integer, origen As Integer, destino As Integer, tipo_entrega As Integer, producto As Integer, tipo_tarifa As Integer, subcuenta As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("sp_tarifa_privada", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_entrega", tipo_entrega, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_tarifa", tipo_tarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_subcuenta", subcuenta, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If

            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Shared Sub ActualizarElectronico(tipo As Integer, comprobante As Integer, mensaje As String, origen As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_actualizar_electronico", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_mensaje", mensaje, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Shared Function ClienteConsignado(ByVal cliente As String, ByVal consignado As String) As Integer
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_VENTACONTADO.sf_get_cliente_consignado('" & cliente & "','" & consignado & "') from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag

    End Function

    Public Function ListarBoleto(ByVal boleto As String, Optional ByVal opcion As Integer = 0, Optional ByVal nivel As Integer = 0, Optional ByVal comprobante As Integer = 0) As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_boleto", CommandType.StoredProcedure)
            db_bd.AsignarParametro("vi_boleto", boleto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_nivel", nivel, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If

            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function NivelEquipaje(ByVal boleto As String) As Integer
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_VENTACONTADO.sf_get_nivel_equipaje('" & boleto & "') from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Shared Function AgenciaNombreCorto(ByVal agencia As Integer) As String
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_VENTACONTADO.sf_get_agencia_corto(" & agencia & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Shared Function ObtieneComprobante(ByVal tipo As Integer, ByVal id As Integer) As String
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select SF_GET_COMPROBANTE(" & tipo & "," & id & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Function ListarTipoPago() As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_tipo_pago", CommandType.StoredProcedure)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function ListarCodigo(ByVal comprobante As Integer, ByVal item As Integer) As String
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_codigo", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_item", item, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0).Rows(0).Item(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function ListarTipoTarjeta() As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_tipo_tarjeta", CommandType.StoredProcedure)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Sub GrabarTipoPago(ByVal comprobante As Integer, ByVal tipo_pago As Integer, ByVal tipo_tarjeta As Integer, ByVal afecto As Double, _
                       ByVal pago As Double, ByVal usuario As Integer, ByVal ip As String, ByVal tarjeta As Integer)
        Dim db_bd As New BaseDatos
        Dim dt As DataTable
        Try
            db_bd.CrearComando("pkg_ventacontado.sp_grabar_tipo_pago", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_pago", tipo_pago, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_tarjeta", tipo_tarjeta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_afecto", afecto, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_pago", pago, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_tarjeta", tarjeta, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            dt = db_bd.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Function GrabarNotaCredito(ByVal comprobante As Integer, ByVal tipo As Integer, ByVal total As Double, ByVal pago As Double, _
                   ByVal agencia As Integer, ByVal usuario As Integer, ByVal ip As String) As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.CrearComando("pkg_ventacontado.sp_grabar_nota_credito", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_pago", pago, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db_bd.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function ListarCtaCteDetalle(ByVal cliente As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_ctacte_detalle", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function ListarPago(ByVal comprobante As Integer, Optional ByVal opcion As Integer = 0) As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_pago", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Shared Sub GrabarCorrelativoTmp(ByVal tipo As Integer, ByVal comprobante As Integer, ByVal serie As String, ByVal numero As String)
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("sp_grabar_correlativo_tmp", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_numero", numero, OracleClient.OracleType.VarChar)
            'db_bd.Desconectar()
            'ds = db_bd.EjecutarDataSet
            db_bd.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Shared Function ListarCorrelativoTmp() As DataTable
        Dim db_bd As New BaseDatos
        Dim dt As DataTable
        Try
            db_bd.Conectar()
            db_bd.CrearComando("sp_listar_correlativo_tmp", CommandType.StoredProcedure)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            dt = db_bd.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function ListarPagoResumen(ByVal comprobante As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_pago_resumen", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Function ListarTarjeta(ByVal tipo_tarjeta As Integer) As DataTable
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_tarjeta", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_tipo_tarjeta", tipo_tarjeta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Shared Function CiudadComprobante(ByVal tipo As Integer, ByVal comprobante As Integer, ByVal opcion As Integer) As String
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select sf_get_ciudad_comprobante(" & tipo & "," & comprobante & "," & opcion & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    Public Function ListaDatosLiquidacionUsuario(ByVal IDAgencia As Integer, ByVal iIDLiquidacion As Integer, ByVal Fecha As String, ByVal Opcion As Integer, ByVal usuario As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_DatosLiquidacionUsuario", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDLiquidacion", iIDLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDAgencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Fecha", Fecha, OracleClient.OracleType.VarChar)
            'hlamas 16-05-2017
            If CDate(Fecha) >= CDate("19/06/2017") Then
                db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            End If
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("Co_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("Co_GastosLiquidacion", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Sub ActualizarDescuento(ByVal comprobante As Integer, ByVal total As Double, ByVal subtotal As Double, ByVal impuesto As Double, _
                            ByVal descuento As Double, ByVal autoriza As String)
        Dim db_bd As New BaseDatos
        Dim ds As DataSet
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_actualizar_descuento", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_subtotal", subtotal, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_descuento", descuento, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("vi_autoriza", autoriza, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            'db_bd.Desconectar()
            'ds = db_bd.EjecutarDataSet
            db_bd.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Shared Function AgenciaAbreviado(ByVal agencia As Integer) As String
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_VENTACONTADO.sf_get_agencia_abreviado(" & agencia & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Shared Function FormaPagoEspecial(ByVal cliente As Integer) As Boolean
        Dim flag As Integer
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_CONTADO_ESPECIAL.sf_get_pago_especial(" & cliente & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return IIf(flag = 0, False, True)
    End Function

    Shared Function PagoPendiente(ByVal cliente As Integer) As Boolean
        Dim flag As Integer
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_CONTADO_ESPECIAL.sf_get_pago_pendiente(" & cliente & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return IIf(flag = 0, False, True)
    End Function

    Function ListarVentaEspecial(ByVal inicio As String, ByVal fin As String, ByVal estado As Integer, Optional ByVal usuario As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_CONTADO_ESPECIAL.sp_listar_venta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub CancelarComprobante(ByVal id As Integer, ByVal cancelado As Integer)
        Dim db_bd As New BaseDatos
        Dim dt As DataTable
        Try
            db_bd.CrearComando("PKG_CONTADO_ESPECIAL.sp_cancelar_comprobante", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_cancelado", cancelado, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            dt = db_bd.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Function ListarCategoria(ByVal tipo As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_listar_categoria", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarBultoCategoria(ByVal tipo As Integer, ByVal comprobante As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_listar_bulto_categoria", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet()
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Sub GrabarBultoCategoria(ByVal tipo As Integer, ByVal comprobante As Integer, ByVal categoria As Integer, ByVal bulto As Integer, _
                                    ByVal usuario As Integer, ByVal ip As String)
        Dim db_bd As New BaseDatos
        Try
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_grabar_bulto_categoria", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_categoria", categoria, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_bulto", bulto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim ds As DataSet = db_bd.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Function ListarCiudad() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_listar_ciudad", CommandType.StoredProcedure)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarAgencia(ByVal ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_listar_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ResumenVentas(ByVal inicio As String, ByVal fin As String, ByVal ciudad As Integer, ByVal agencia As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_VENTACONTADO.sp_resumen_ventas", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function


End Class


