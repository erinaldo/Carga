Imports System.IO
Imports System.Runtime.InteropServices
Imports AccesoDatos
Public Class dtoEntregaCarga
#Region "VARIABLES"
    Public IDPK As Integer
    Public IDDOC As Integer

    Public NRODOC As String
    Public Nro_Guia_Transportista As Integer
    Public Origen As String
    Public Destino As String
    Public FECHA As String
    Public Tipo_Entrega As String
    Public Tipo_Comprobante As String
    Public Nu_Docu_Suna As String
    Public Razon_Social As String
    Public Centro_Costo As String
    Public Remitente As String
    Public DNI_Remitente As String
    Public REM_Direccion As String
    Public Destinatario As String
    Public DNI_Destinatario As String
    Public Des_Direccion As String
    Public forma_pago As String
    Public Tipo_Pago As String
    Public Tarjeta As String
    Public Nrotarjeta As String
    Public Memo As String
    Public Porcent_Descuento As String
    Public Precio_x_Peso As String
    Public Precio_x_Volumen As String
    Public Precio_x_Sobre As String
    Public Cantidad_x_Peso As String
    Public Cantidad_x_Volumen As String
    Public Cantidad_x_Sobre As String
    Public Cantidad_x_Articulos As String
    Public Total_Peso As String
    Public Total_Volumen As String
    Public MONTO_SUB_TOTAL As String
    Public MONTO_IMPUESTO As String
    Public Monto_Base As String
    Public Total_Costo As String

    Public Nombre_Entrega As String
    Public Doc_Entrega As String
    Public Fecha_Entrega As String
    Public Hora_Entrega As String

    Public idEstadoGuiaTrans As Integer
    Public Estado_Documento As String
    Public idEstado_Documento As String
    Public v_Obs As String
    Public EstadoEnvio As String
    Public IdEstadoEnvio As Integer
    '02/10/2007 
    Public sidpersona As String
    Public lidtipo_comprobante As Long
    Public sidcomprobante As String
    'Public rst_tipo_entrega_o As New ADODB.Recordset
    'Public rst_direccion_entrega As New ADODB.Recordset
    '
    Public l_tipo_entrega As Long
    Public s_iddireccion_tipo_entrega As String
    Public s_direccion_tipo_entrega As String
    Public l_idusuario_personal As Long
    Public l_idrol_usuario As Long
    Public s_ip As String
    '15/01/2008
    Public l_por_entregar As Long
    Public l_entregado As Long
    Public l_idagencia As Long
    Public l_cantidad_total As Long
    '
    Public l_idagencia_destino As Long
    '
    Public Consignado As Integer
#End Region
#Region "Actualizar Datos"
    Public x_iControl As Integer
    Public x_idTipoDocumento As Integer
    Public x_idDOC_VENTA As Integer
    Public x_NOMBRES As String
    Public x_DOC_ENTREGA As String
    Public x_IP As String
    Public x_IDROL_USUARIO As Integer
    Public x_Idusuario_Personal As Integer
    Public x_FECHA_ENTREGA As String
    Public x_HORA_ENTREGA As String

    Public x_idtargeta As Integer
    Public x_Nrotarjeta As String

    Public l_idestado_envio As Long
    Public es_carga_asegurada As Long

    Public l_no_existe_gt As Long
    Public l_error As Long

#End Region

#Region " Filtro de Carga"
    Public c_iControl As Integer
    Public c_NroDoc As String
    Public c_Serie As String
    Public c_fecha_inicio As String
    Public c_fecha_fin As String
    Public c_idOrigen As Integer
    Public c_idDestino As Integer
    Public c_idusuariopersonal As Integer
    Public c_idestado_registro As Integer
    Public c_rucdni As String
    Public c_idpersona As Integer
    Public c_tipo_entrega As Integer
    Public c_tipo As Integer
    Public c_nombres As String
    'Public cur_datos As New ADODB.Recordset
#End Region

    'Public rst_tarjetas As New ADODB.Recordset
    Public col_tarjetas As New Collection
    'Public rst_tipo_pago As New ADODB.Recordset
    Public col_tipo_pago As New Collection
    '
    '***CambioR 10112011**
    Public IDComprobante As Integer
    Public Idtipo_Comprobante As Integer
    'Public rst_datos As New ADODB.Recordset
    'Public cur_Articulos As New ADODB.Recordset
    'Public cur_Documentos As New ADODB.Recordset
    'Public curr_error As New ADODB.Recordset
    'Public rst_control As New ADODB.Recordset
    'Public cur_Estados As New ADODB.Recordset
    '
    Public col_Estados As New Collection
    Public col_Responsable As New Collection
    Public cur_Estados_Entrega As New ADODB.Recordset
    Public col_Estados_Entrega As New Collection
#Region "Datatable"
    'Public dt_rst_control As New DataTable
    Public dt_cur_Articulos As New DataTable
    Public dt_cur_Documentos As New DataTable
    Public dt_cur_Estados_Entrega As New DataTable
    Public dtConsignado As New DataTable
    '
    Public dt_rst_lista_cambio_tipo_entrega As New DataTable
    Public dt_rst_tipo_entrega_o As New DataTable
    Public dt_rst_direccion_entrega As New DataTable
    '
#End Region
#Region "METODOS"
    Private Function strHoraFormato(ByVal str As String) As String
        Dim strVar As String = ""
        Try
            For i As Integer = 0 To str.Length - 4
                strVar = strVar & str.Chars(i)
            Next
            strVar = strVar & "m"
        Catch ex As Exception
            '
        End Try
        Return strVar
    End Function
    'Public Function fnINSERTAR_ENTREGA_CLIENTES_2009(ByVal xv_idEstadoRegistro As Integer) As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim strHora As String = strHoraFormato(x_HORA_ENTREGA)
    '        Dim strHora As String = x_HORA_ENTREGA
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_INSERTAR_ENTREGA_CLIENTES_I", 26, x_iControl, 1, x_idTipoDocumento, 1, x_idDOC_VENTA.ToString, 2, x_NOMBRES, 2, x_DOC_ENTREGA, 2, x_idtargeta, 1, x_Nrotarjeta, 2, x_IP, 2, x_IDROL_USUARIO, 1, x_Idusuario_Personal, 1, x_FECHA_ENTREGA, 2, strHora, 2}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_INSERTAR_ENTREGA_CLIEN_II", 28, x_iControl, 1, x_idTipoDocumento, 1, x_idDOC_VENTA.ToString, 2, x_NOMBRES, 2, x_DOC_ENTREGA, 2, x_idtargeta, 1, x_Nrotarjeta, 2, x_IP, 2, x_IDROL_USUARIO, 1, x_Idusuario_Personal, 1, x_FECHA_ENTREGA, 2, strHora, 2, v_Obs, 2}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_INSERTAR_ENTRE_CLIEN_III", 28, x_iControl, 1, x_idTipoDocumento, 1, x_idDOC_VENTA.ToString, 2, x_NOMBRES, 2, x_DOC_ENTREGA, 2, x_idtargeta, 1, x_Nrotarjeta, 2, x_IP, 2, xv_idEstadoRegistro, 1, x_Idusuario_Personal, 1, x_FECHA_ENTREGA, 2, strHora, 2, v_Obs, 2}           
    '        'Modificado el 16/01/2008 
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_INSERTAR_ENTRE_CLIEN_V", 32, _
    '                                                                      x_iControl, 1, _
    '                                                                      x_idTipoDocumento, 1, _
    '                                                                      x_idDOC_VENTA.ToString, 2, _
    '                                                                      x_NOMBRES, 2, _
    '                                                                      x_DOC_ENTREGA, 2, _
    '                                                                      x_idtargeta, 1, _
    '                                                                      x_Nrotarjeta, 2, _
    '                                                                      x_IP, 2, _
    '                                                                      xv_idEstadoRegistro, 1, _
    '                                                                      x_Idusuario_Personal, 1, _
    '                                                                      x_FECHA_ENTREGA, 2, _
    '                                                                      strHora, 2, _
    '                                                                      v_Obs, 2, _
    '                                                                      l_entregado, 1, _
    '                                                                      l_idagencia, 1}

    '        rst_control = Nothing
    '        rst_control = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_control.State = 1 Then
    '            If rst_control.BOF = False And rst_control.EOF = False Then
    '                MsgBox(rst_control.Fields.Item(0).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                If Int(rst_control.Fields.Item(1).Value) <> 1 Then
    '                    flat = False
    '                Else
    '                    x_idTipoDocumento = rst_control.Fields.Item(2).Value
    '                    x_idDOC_VENTA = rst_control.Fields.Item(3).Value
    '                End If
    '            Else
    '                flat = False
    '            End If
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnINSERTAR_ENTREGA_CLIENTES(ByVal xv_idEstadoRegistro As Integer) As Boolean
        Dim flat As Boolean = True
        Dim strHora As String = x_HORA_ENTREGA
        '''''''''''''''''''
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_INSERTAR_ENTRE_CLIEN_V", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", x_iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idTipo_Pago", x_idTipoDocumento, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xidDOC_VENTA", x_idDOC_VENTA.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NOMBRES", x_NOMBRES, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DOC_ENTREGA", x_DOC_ENTREGA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idtargeta", x_idtargeta, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Nrotarjeta", x_Nrotarjeta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IP", x_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDESTADO_REGISTRO", xv_idEstadoRegistro, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Idusuario_Personal", x_Idusuario_Personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_FECHA_ENTREGA", x_FECHA_ENTREGA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_HORA_ENTREGA", strHora, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Obs", v_Obs, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("n_entregado", l_entregado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("n_idagencia", l_idagencia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                MsgBox(lds_tmp.Tables(0).Rows(0).Item(0).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                If Int(lds_tmp.Tables(0).Rows(0).Item(1)) <> 1 Then
                    flat = False
                Else
                    x_idTipoDocumento = lds_tmp.Tables(0).Rows(0).Item(2)
                    x_idDOC_VENTA = lds_tmp.Tables(0).Rows(0).Item(3)
                End If
            Else
                flat = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flat = False
        End Try
        Return flat
    End Function
    'Public Function fnCONSULTA_CARGA_2009() As ADODB.Recordset
    '    ' la configuracion esta basade en dos campos importantes... el pktem que implica el tipo de tabla al que esta asociado el registro 
    '    ' 1 si esta en la tabla facturacion y 2 si esta en la tabla guia de envio..
    '    ' el segundo campo 
    '    Dim flat As Boolean = True
    '    Try
    '        c_NroDoc = IIf(c_NroDoc <> "", c_NroDoc, "-1")
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_CONSULTA_CARGA_I", 24, c_iControl, 1, c_NroDoc, 2, c_Serie, 2, c_fecha_inicio, 2, c_fecha_fin, 2, c_idOrigen, 1, c_idDestino, 1, c_idusuariopersonal, 1, c_idestado_registro, 1, c_rucdni, 2, c_idpersona, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return cur_datos
    'End Function


    Public Function fnCONSULTA_CARGA() As DataTable
        ' la configuracion esta basade en dos campos importantes... el pktem que implica el tipo de tabla al que esta asociado el registro 
        ' 1 si esta en la tabla facturacion y 2 si esta en la tabla guia de envio..
        ' el segundo campo 
        Dim flat As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_CONSULTA_CARGA_II", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iControl", c_iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NroDoc", c_NroDoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Serie", c_Serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_inicio", c_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_fin", c_fecha_fin, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idOrigen", c_idOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDestino", c_idDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idusuariopersonal", c_idusuariopersonal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idestado_registro", c_idestado_registro, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_rucdni", c_rucdni, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idpersona", c_idpersona, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_entrega", c_tipo_entrega, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp.Tables(0)
            '
        Catch ex As Excepcion
            flat = False
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnLoadTarjetas_2009() As ADODB.Recordset
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"select t_Tarjetas.Idtarjetas ,t_Tarjetas.Descripcion from t_Tarjetas where t_Tarjetas.Idestado_Registro=1 order by t_Tarjetas.Descripcion asc", 2}
    '        rst_tarjetas = Nothing
    '        rst_tarjetas = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return rst_tarjetas
    'End Function
    Public Function fnLoadTarjetas() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_GENERICO.sp_get_datos_para_venta", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("co_tarjetas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_tipo_pago", OracleClient.OracleType.Cursor)
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

    'Public Function fnTipoPagos_2009() As ADODB.Recordset
    '    ' Procedimiento unificado  con el de arriba (fnLoadTarjetas) - 14/09/2009 
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"select t_Tipo_Pago.Idtipo_Pago,t_Tipo_Pago.Tipo_Pago from t_Tipo_Pago where  t_Tipo_Pago.Idestado_Registro=1 order by t_Tipo_Pago.Tipo_Pago asc", 2}
    '        rst_tipo_pago = Nothing
    '        rst_tipo_pago = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return rst_tipo_pago
    'End Function
    'Public Function fnLoadDatos_2009(ByVal idControl As Integer, ByVal idDoc As Integer) As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_ENTREGA_CARGA_I", 6, idControl, 1, idDoc.ToString, 2}
    '        rst_datos = Nothing
    '        rst_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If rst_datos.State = 1 Then
    '            If rst_datos.BOF = False And rst_datos.EOF = False Then
    '                idDoc = rst_datos.Fields.Item("idDoc").Value
    '                NRODOC = rst_datos.Fields.Item("NRODOC").Value
    '                Nro_Guia_Transportista = rst_datos.Fields.Item("Nro_Guia_Transportista").Value
    '                Origen = rst_datos.Fields.Item("Origen").Value
    '                Destino = rst_datos.Fields.Item("Destino").Value
    '                FECHA = rst_datos.Fields.Item("FECHA").Value
    '                Tipo_Entrega = rst_datos.Fields.Item("Tipo_Entrega").Value
    '                Tipo_Comprobante = rst_datos.Fields.Item("Tipo_Comprobante").Value
    '                Nu_Docu_Suna = rst_datos.Fields.Item("Nu_Docu_Suna").Value
    '                Razon_Social = rst_datos.Fields.Item("Razon_Social").Value
    '                Centro_Costo = rst_datos.Fields.Item("Centro_Costo").Value
    '                Remitente = rst_datos.Fields.Item("Remitente").Value
    '                DNI_Remitente = rst_datos.Fields.Item("DNI_Remitente").Value
    '                REM_Direccion = rst_datos.Fields.Item("REM_Direccion").Value
    '                Destinatario = rst_datos.Fields.Item("Destinatario").Value
    '                DNI_Destinatario = rst_datos.Fields.Item("DNI_Destinatario").Value
    '                Des_Direccion = rst_datos.Fields.Item("Des_Direccion").Value
    '                forma_pago = rst_datos.Fields.Item("forma_pago").Value
    '                Tipo_Pago = rst_datos.Fields.Item("Tipo_Pago").Value
    '                Tarjeta = rst_datos.Fields.Item("Tarjeta").Value
    '                Nrotarjeta = rst_datos.Fields.Item("Nrotarjeta").Value
    '                Memo = rst_datos.Fields.Item("Memo").Value
    '                Porcent_Descuento = rst_datos.Fields.Item("Porcent_Descuento").Value
    '                Precio_x_Peso = rst_datos.Fields.Item("Precio_x_Peso").Value
    '                Precio_x_Volumen = rst_datos.Fields.Item("Precio_x_Volumen").Value
    '                Precio_x_Sobre = rst_datos.Fields.Item("Precio_x_Sobre").Value
    '                Cantidad_x_Peso = rst_datos.Fields.Item("Cantidad_x_Peso").Value
    '                Cantidad_x_Volumen = rst_datos.Fields.Item("Cantidad_x_Volumen").Value
    '                Cantidad_x_Sobre = rst_datos.Fields.Item("Cantidad_x_Sobre").Value
    '                Total_Peso = rst_datos.Fields.Item("Total_Peso").Value
    '                Total_Volumen = rst_datos.Fields.Item("Total_Volumen").Value
    '                MONTO_SUB_TOTAL = rst_datos.Fields.Item("MONTO_SUB_TOTAL").Value
    '                MONTO_IMPUESTO = rst_datos.Fields.Item("MONTO_IMPUESTO").Value
    '                Monto_Base = rst_datos.Fields.Item("Monto_Base").Value
    '                Total_Costo = rst_datos.Fields.Item("Total_Costo").Value
    '                Nombre_Entrega = rst_datos.Fields.Item("Nombre_Entrega").Value
    '                Doc_Entrega = rst_datos.Fields.Item("Doc_Entrega").Value
    '                Fecha_Entrega = rst_datos.Fields.Item("Fecha_Entrega").Value
    '                Hora_Entrega = rst_datos.Fields.Item("Hora_Entrega").Value
    '                idEstadoGuiaTrans = rst_datos.Fields.Item("idEstadoGuiaTrans").Value
    '                Estado_Documento = rst_datos.Fields.Item("Estado_Documento").Value
    '                idEstado_Documento = rst_datos.Fields.Item("idEstado_Documento").Value
    '                Cantidad_x_Articulos = rst_datos.Fields.Item("Cant_Art").Value
    '                EstadoEnvio = rst_datos.Fields.Item("EstadoEnvio").Value
    '                IdEstadoEnvio = rst_datos.Fields.Item("idEstadoEnvio").Value
    '                v_Obs = IIf(rst_datos.Fields.Item("v_Obs").Value <> " ", rst_datos.Fields.Item("v_Obs").Value, "")
    '                l_por_entregar = 0
    '                l_por_entregar = CType(rst_datos.Fields.Item("por_entregar").Value, Long)
    '                l_entregado = CType(rst_datos.Fields.Item("Tot_Entregado").Value, Long)
    '                l_cantidad_total = CType(rst_datos.Fields.Item("CANTIDAD_TOTAL").Value, Long)
    '                '
    '                cur_Articulos = rst_datos.NextRecordset
    '                cur_Documentos = rst_datos.NextRecordset
    '                cur_Estados_Entrega = rst_datos.NextRecordset
    '            Else
    '                flat = False
    '            End If
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnLoadDatos(ByVal idControl As Integer, ByVal idDoc As Integer) As Boolean
        Dim flat As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_cur_Articulos.Clear()
            dt_cur_Documentos.Clear()
            dt_cur_Estados_Entrega.Clear()
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_ENTREGA_CARGA_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", idControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xiIDDOC", idDoc.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Estados_Entrega", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                idDoc = lds_tmp.Tables(0).Rows(0).Item("idDoc")
                NRODOC = lds_tmp.Tables(0).Rows(0).Item("NRODOC")
                Nro_Guia_Transportista = lds_tmp.Tables(0).Rows(0).Item("Nro_Guia_Transportista")
                Origen = lds_tmp.Tables(0).Rows(0).Item("Origen")
                Destino = lds_tmp.Tables(0).Rows(0).Item("Destino")
                FECHA = lds_tmp.Tables(0).Rows(0).Item("FECHA")
                Tipo_Entrega = lds_tmp.Tables(0).Rows(0).Item("Tipo_Entrega")
                Tipo_Comprobante = lds_tmp.Tables(0).Rows(0).Item("Tipo_Comprobante")
                Nu_Docu_Suna = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")
                Razon_Social = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
                Centro_Costo = lds_tmp.Tables(0).Rows(0).Item("Centro_Costo")
                Remitente = lds_tmp.Tables(0).Rows(0).Item("Remitente")
                DNI_Remitente = lds_tmp.Tables(0).Rows(0).Item("DNI_Remitente")
                REM_Direccion = lds_tmp.Tables(0).Rows(0).Item("REM_Direccion")
                Destinatario = lds_tmp.Tables(0).Rows(0).Item("Destinatario")
                DNI_Destinatario = lds_tmp.Tables(0).Rows(0).Item("DNI_Destinatario")
                Des_Direccion = lds_tmp.Tables(0).Rows(0).Item("Des_Direccion")
                forma_pago = lds_tmp.Tables(0).Rows(0).Item("forma_pago")
                Tipo_Pago = lds_tmp.Tables(0).Rows(0).Item("Tipo_Pago")
                Tarjeta = lds_tmp.Tables(0).Rows(0).Item("Tarjeta")
                Nrotarjeta = lds_tmp.Tables(0).Rows(0).Item("Nrotarjeta")
                Memo = lds_tmp.Tables(0).Rows(0).Item("Memo")
                Porcent_Descuento = lds_tmp.Tables(0).Rows(0).Item("Porcent_Descuento")
                Precio_x_Peso = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Peso")
                Precio_x_Volumen = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Volumen")
                Precio_x_Sobre = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Sobre")
                Cantidad_x_Peso = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Peso")
                Cantidad_x_Volumen = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
                Cantidad_x_Sobre = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
                Total_Peso = lds_tmp.Tables(0).Rows(0).Item("Total_Peso")
                Total_Volumen = lds_tmp.Tables(0).Rows(0).Item("Total_Volumen")
                MONTO_SUB_TOTAL = lds_tmp.Tables(0).Rows(0).Item("MONTO_SUB_TOTAL")
                MONTO_IMPUESTO = lds_tmp.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
                Monto_Base = lds_tmp.Tables(0).Rows(0).Item("Monto_Base")
                Total_Costo = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
                Nombre_Entrega = lds_tmp.Tables(0).Rows(0).Item("Nombre_Entrega")
                Doc_Entrega = lds_tmp.Tables(0).Rows(0).Item("Doc_Entrega")
                Fecha_Entrega = lds_tmp.Tables(0).Rows(0).Item("Fecha_Entrega")
                Hora_Entrega = lds_tmp.Tables(0).Rows(0).Item("Hora_Entrega")
                idEstadoGuiaTrans = lds_tmp.Tables(0).Rows(0).Item("idEstadoGuiaTrans")
                Estado_Documento = lds_tmp.Tables(0).Rows(0).Item("Estado_Documento")
                idEstado_Documento = lds_tmp.Tables(0).Rows(0).Item("idEstado_Documento")
                Cantidad_x_Articulos = lds_tmp.Tables(0).Rows(0).Item("Cant_Art")
                EstadoEnvio = lds_tmp.Tables(0).Rows(0).Item("EstadoEnvio")
                IdEstadoEnvio = lds_tmp.Tables(0).Rows(0).Item("idEstadoEnvio")
                v_Obs = IIf(lds_tmp.Tables(0).Rows(0).Item("v_Obs") <> "", lds_tmp.Tables(0).Rows(0).Item("v_Obs"), "")
                l_por_entregar = 0
                l_por_entregar = CType(lds_tmp.Tables(0).Rows(0).Item("por_entregar"), Long)
                l_entregado = CType(lds_tmp.Tables(0).Rows(0).Item("Tot_Entregado"), Long)
                l_cantidad_total = CType(lds_tmp.Tables(0).Rows(0).Item("CANTIDAD_TOTAL"), Long)
                '
                dt_cur_Articulos = lds_tmp.Tables(1)
                dt_cur_Documentos = lds_tmp.Tables(2)
                dt_cur_Estados_Entrega = lds_tmp.Tables(3)
                '
                flat = True
            Else
                flat = False
            End If
            '
        Catch ex As Excepcion
            flat = False
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnEstadoRegistros_2009() As ADODB.Recordset
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_ESTADOS_ENVIO", 2}
    '        cur_Estados = Nothing
    '        cur_Estados = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return cur_Estados
    'End Function
    Public Function fnEstadoRegistros() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_ESTADOS_ENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Estados", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnLISTAR_RESPONSABLES_MOVIL_2009() As ADODB.Recordset
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTAR_RESPONSABLES_MOVIL", 4, dtoUSUARIOS.m_idciudad, 1}
    '        cur_Estados = Nothing
    '        cur_Estados = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return cur_Estados
    'End Function
    Public Function fnLISTAR_RESPONSABLES_MOVIL() As DataTable
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTAR_RESPONSABLES_MOVIL", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iCiudad", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_responsables", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnCONTROL_LLEGADAS_2009(ByVal IDCONTROL As Integer, ByVal IDCOMPROBANTE As String) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_CONTROL_LLEGADAS", 12, IDCONTROL, 1, IDCOMPROBANTE, 2, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1}
    '        cur_Estados = Nothing
    '        cur_Estados = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_Estados.State = 1 Then
    '            If cur_Estados.EOF = False And cur_Estados.BOF = False Then
    '                MsgBox(cur_Estados.Fields.Item("msgbox").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                l_idestado_envio = cur_Estados.Fields.Item("estado").Value
    '                l_no_existe_gt = cur_Estados.Fields.Item("esta_gt").Value
    '                l_error = cur_Estados.Fields.Item("error").Value
    '                flat = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnCONTROL_LLEGADAS(ByVal IDCONTROL As Integer, ByVal IDCOMPROBANTE As String) As Boolean
        Dim flat As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_CONTROL_LLEGADAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", IDCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ID", IDCOMPROBANTE, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idUsuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_rol", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("msgbox"), MsgBoxStyle.Information, "Seguridad Sistema")
                l_idestado_envio = ldt_tmp.Rows(0).Item("estado")
                l_no_existe_gt = ldt_tmp.Rows(0).Item("esta_gt")
                l_error = ldt_tmp.Rows(0).Item("error")
                flat = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnBuscarNroMovil_2009(ByVal IDUsuario As Integer) As String
    '    Dim flat As String = ""
    '    Try
    '        Dim varSP_OBJECT() As Object = {"select nvl(t_Usuario_Personal.Celular,'000*0000') Celular from t_Usuario_Personal where t_Usuario_Personal.Idusuario_Personal= " & IDUsuario.ToString(), 2}
    '        cur_Estados = Nothing
    '        cur_Estados = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_Estados.State = 1 Then
    '            If cur_Estados.EOF = False And cur_Estados.BOF = False Then
    '                flat = cur_Estados.Fields.Item("Celular").Value
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnBuscarNroMovil(ByVal IDUsuario As Integer) As String
        Dim flat As String = ""
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_GENERICO.sp_get_celular_usuario", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idusuario_personal", IDUsuario, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("co_get_celular", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                flat = ldt_tmp.Rows(0).Item("Celular")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnSP_ENVIO_MSM2_2009(ByVal iControl As Integer, ByVal NroMovil As String, ByVal msm2 As String) As String
    '    Dim flat As String = ""
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_ENVIO_MSM2", 8, iControl, 1, NroMovil, 2, msm2, 2}
    '        cur_Estados = Nothing
    '        cur_Estados = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_Estados.State = 1 Then
    '            If cur_Estados.EOF = False And cur_Estados.BOF = False Then
    '                MsgBox(cur_Estados.Fields.Item("msgbox").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_ENVIO_MSM2(ByVal iControl As Integer, ByVal NroMovil As String, ByVal msm2 As String)
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_ENVIO_MSM2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("NroMovil", NroMovil, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("msm2", msm2, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("msgbox"), MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnSP_LIST_CHECK_POINT_2009() As ADODB.Recordset
    '    Dim flat As String = "..."
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_LIST_CHECK_POINT", 6, IDPK, 1, IDDOC.ToString(), 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = "...xxx"
    '    End Try
    '    Return cur_datos
    'End Function
    Public Function fnSP_LIST_CHECK_POINT() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_LIST_CHECK_POINT", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idTipo_Comprobante", IDPK, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idComprobante", IDDOC.ToString(), OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_SELEC_VENTA_UBICA_2009(ByVal IDTIPO As Integer, ByVal IDCOMPROBANTE As String) As DataView
    '    Dim daControl_VENTA As New OleDb.OleDbDataAdapter
    '    Dim dtControl_VENTA As New System.Data.DataTable
    '    Dim dvControl_VENTA As System.Data.DataView
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_SELEC_VENTA_UBICA", 6, IDTIPO, 1, IDCOMPROBANTE, 2}
    '        dtControl_VENTA.Clear()
    '        daControl_VENTA.Fill(dtControl_VENTA, VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT))
    '        dvControl_VENTA = dtControl_VENTA.DefaultView
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return dvControl_VENTA
    'End Function
    Public Function SP_SELEC_VENTA_UBICA(ByVal IDTIPO As Integer, ByVal IDCOMPROBANTE As String) As DataView
        Dim dtControl_VENTA As New System.Data.DataTable
        Dim dvControl_VENTA As System.Data.DataView
        '---
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_SELEC_VENTA_UBICA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDCOMPROBANTE", IDCOMPROBANTE, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_SELEC_VENTA_UBICA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            dtControl_VENTA = db_bd.EjecutarDataTable
            dvControl_VENTA = dtControl_VENTA.DefaultView
            '
            Return dvControl_VENTA
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnCrearArchivo_Entrega_2009() As Boolean
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_CREAR_ARCHIVO_CARGOS", 14, 1, 1, c_rucdni, 2, c_idOrigen, 1, c_idDestino, 1, c_idestado_registro, 1, c_fecha_inicio, 2}
    '        cur_datos = Nothing
    '        Dim cur_FileName As ADODB.Recordset
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        cur_FileName = cur_datos.NextRecordset
    '        If cur_FileName.BOF = False And cur_FileName.EOF = False Then
    '            Dim fs As FileStream
    '            Dim strFile As String
    '            fs = File.Open("..\" & cur_FileName.Fields.Item("NOMBRE_FILE").Value.ToString() & "_ENTREGA.txt", FileMode.Create, FileAccess.Write)
    '            Dim s As New StreamWriter(fs)
    '            s.WriteLine("cia,tipdoc,documento,agen,hora,fecha")
    '            While cur_datos.BOF = False And cur_datos.EOF = False
    '                s.WriteLine(cur_datos.Fields.Item("Datos").Value.ToString())
    '                cur_datos.MoveNext()
    '            End While
    '            s.Flush()
    '            fs.Flush()
    '            s.Close()
    '            fs.Close()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return False
    'End Function
    Public Function fnCrearArchivo_Entrega() As Boolean
        Try
            Dim ll_control As Long = 1 ' Por defecto va hacer 1
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_CREAR_ARCHIVO_CARGOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_control", ll_control, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NunDocu_sunat", c_rucdni, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUnidad_Origen", c_idOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IdUnidad_Destino", c_idDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idestado_registro", c_idestado_registro, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Fecha", c_fecha_inicio, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_nombre_file", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(1).Rows.Count > 0 Then
                Dim fs As FileStream
                Dim strFile As String
                fs = File.Open("..\" & lds_tmp.Tables(1).Rows(0).Item("NOMBRE_FILE").ToString() & "_ENTREGA.txt", FileMode.Create, FileAccess.Write)
                Dim s As New StreamWriter(fs)
                s.WriteLine("cia,tipdoc,documento,agen,hora,fecha")
                For Each fila As DataRow In lds_tmp.Tables(0).Rows
                    s.WriteLine(fila.Item("Datos").ToString())
                Next
                s.Flush()
                fs.Flush()
                s.Close()
                fs.Close()
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return False
    End Function
    'Recupera de para el cambio del tipo de entrega 
    'Public Function fnrecupera_datos_tipo_entrega_2009() As DataTable
    '    Dim rst_lista_cambio_tipo_entrega As New ADODB.Recordset
    '    Dim dt_cambio_tipo_entrega As New DataTable
    '    Dim odbda_entrega As New OleDb.OleDbDataAdapter
    '    ' 
    '    Try
    '        dt_cambio_tipo_entrega = Nothing
    '        rst_lista_cambio_tipo_entrega = Nothing
    '        dt_cambio_tipo_entrega = New DataTable
    '        '
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.sp_lista_cambio_entrega", 8, _
    '                                                                     sidpersona, 2, _
    '                                                                     lidtipo_comprobante, 1, _
    '                                                                     sidcomprobante, 2}
    '        '
    '        rst_lista_cambio_tipo_entrega = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        rst_tipo_entrega_o = rst_lista_cambio_tipo_entrega.NextRecordset
    '        rst_direccion_entrega = rst_lista_cambio_tipo_entrega.NextRecordset
    '        '
    '        odbda_entrega.Fill(dt_cambio_tipo_entrega, rst_lista_cambio_tipo_entrega)
    '        '            
    '        ' 
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return dt_cambio_tipo_entrega
    'End Function
    'Recupera de para el cambio del tipo de entrega 
    Public Function fnrecupera_datos_tipo_entrega() As DataTable
        Dim dt_cambio_tipo_entrega As New DataTable
        Try

            '
            dt_rst_lista_cambio_tipo_entrega = Nothing
            dt_rst_tipo_entrega_o = Nothing
            dt_rst_direccion_entrega = Nothing
            '
            dt_rst_lista_cambio_tipo_entrega = New DataTable
            dt_rst_tipo_entrega_o = New DataTable
            dt_rst_direccion_entrega = New DataTable
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_lista_cambio_entrega", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idpersona", sidpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipocomprobante", lidtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idcomprobante", sidcomprobante, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_tipo_entrega", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_dire_destino", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet
            '
            dt_rst_lista_cambio_tipo_entrega = lds_tmp.Tables(0)
            dt_rst_tipo_entrega_o = lds_tmp.Tables(1)
            dt_rst_direccion_entrega = lds_tmp.Tables(2)
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return dt_rst_lista_cambio_tipo_entrega
    End Function
    'Cambia el tipo entrega 
    'Public Function fnactualiza_datos_tipo_entrega_2009() As ADODB.Recordset
    '    ' 
    '    Dim rst_mensaje As ADODB.Recordset
    '    Try

    '        rst_mensaje = Nothing
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.sp_act_tipo_entrega", 20, _
    '                                                                     lidtipo_comprobante, 1, _
    '                                                                     sidcomprobante, 2, _
    '                                                                     l_tipo_entrega, 1, _
    '                                                                     s_iddireccion_tipo_entrega, 2, _
    '                                                                     s_direccion_tipo_entrega, 2, _
    '                                                                     sidpersona, 2, _
    '                                                                     l_idusuario_personal, 1, _
    '                                                                     l_idrol_usuario, 1, _
    '                                                                     s_ip, 2}
    '        rst_mensaje = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '            
    '        ' 
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return rst_mensaje
    'End Function
    'Cambia el tipo entrega 
    Public Function fnactualiza_datos_tipo_entrega() As DataTable
        ' 
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_act_tipo_entrega", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idtipocomprobante", lidtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idcomprobante", sidcomprobante, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_entrega", l_tipo_entrega, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_iddireccion_consigna", s_iddireccion_tipo_entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_direccion_consigna", s_direccion_tipo_entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idpersona", sidpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_personal", l_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idRol", l_idrol_usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", s_ip, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    Public Function fnactualiza_datos_tipo_entrega_I(ByVal id_DepartamentoConsig As Integer, ByVal id_ProvinciaConsig As Integer, ByVal id_DistritoConsig As Integer, _
                                                     ByVal id_viaConsig As Integer, ByVal viaConsig As String, ByVal NumeroConsig As String, _
                                                     ByVal manzanaConsig As String, ByVal loteConsig As String, ByVal id_nivelConsig As Integer, _
                                                     ByVal nivelConsig As String, ByVal id_zonaConsig As Integer, ByVal zonaConsig As String, _
                                                     ByVal id_clasificacionConsig As Integer, ByVal clasificacionConsig As String, ByVal sReferencia As String, ByVal IDagenciaDestino As Integer) As DataTable
        ' 
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_act_tipo_entrega_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idtipocomprobante", lidtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idcomprobante", sidcomprobante, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idtipo_entrega", l_tipo_entrega, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_iddireccion_consigna", s_iddireccion_tipo_entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_direccion_consigna", s_direccion_tipo_entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_idpersona", sidpersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idunidad_agencia", IDagenciaDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idusuario_personal", l_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idRol", l_idrol_usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", s_ip, OracleClient.OracleType.VarChar)
            '----
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
            db_bd.AsignarParametro("v_Referencia", sReferencia, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro

            '----
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnSP_LIST_CHECK_POINT_2_2009() As ADODB.Recordset
    '    Dim flat As String = "..."
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_LIST_CHECK_POINT_2", 6, IDPK, 1, IDDOC.ToString(), 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = "...xxx"
    '    End Try
    '    Return cur_datos
    'End Function
    Public Function fnSP_LIST_CHECK_POINT_2() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_LIST_CHECK_POINT_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idTipo_Comprobante", IDPK, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idComprobante", IDDOC.ToString(), OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnLoadDatos2(ByVal idControl As Integer, ByVal idDoc As Integer) As Boolean
        Dim flat As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_cur_Articulos.Clear()
            dt_cur_Documentos.Clear()
            dt_cur_Estados_Entrega.Clear()
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_ENTREGA_CARGA_II", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", idControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("xiIDDOC", idDoc.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Estados_Entrega", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_consignado", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                idDoc = lds_tmp.Tables(0).Rows(0).Item("idDoc")
                NRODOC = lds_tmp.Tables(0).Rows(0).Item("NRODOC")
                Nro_Guia_Transportista = lds_tmp.Tables(0).Rows(0).Item("Nro_Guia_Transportista")
                Origen = lds_tmp.Tables(0).Rows(0).Item("Origen")
                Destino = lds_tmp.Tables(0).Rows(0).Item("Destino")
                FECHA = lds_tmp.Tables(0).Rows(0).Item("FECHA")
                Tipo_Entrega = lds_tmp.Tables(0).Rows(0).Item("Tipo_Entrega")
                Tipo_Comprobante = lds_tmp.Tables(0).Rows(0).Item("Tipo_Comprobante")
                Nu_Docu_Suna = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna")
                Razon_Social = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
                Centro_Costo = lds_tmp.Tables(0).Rows(0).Item("Centro_Costo")
                Remitente = lds_tmp.Tables(0).Rows(0).Item("Remitente")
                DNI_Remitente = lds_tmp.Tables(0).Rows(0).Item("DNI_Remitente")
                REM_Direccion = lds_tmp.Tables(0).Rows(0).Item("REM_Direccion")
                Destinatario = lds_tmp.Tables(0).Rows(0).Item("Destinatario")
                DNI_Destinatario = lds_tmp.Tables(0).Rows(0).Item("DNI_Destinatario")
                Des_Direccion = lds_tmp.Tables(0).Rows(0).Item("Des_Direccion")
                forma_pago = lds_tmp.Tables(0).Rows(0).Item("forma_pago")
                Tipo_Pago = lds_tmp.Tables(0).Rows(0).Item("Tipo_Pago")
                Tarjeta = lds_tmp.Tables(0).Rows(0).Item("Tarjeta")
                Nrotarjeta = lds_tmp.Tables(0).Rows(0).Item("Nrotarjeta")
                Memo = lds_tmp.Tables(0).Rows(0).Item("Memo")
                Porcent_Descuento = lds_tmp.Tables(0).Rows(0).Item("Porcent_Descuento")
                Precio_x_Peso = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Peso")
                Precio_x_Volumen = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Volumen")
                Precio_x_Sobre = lds_tmp.Tables(0).Rows(0).Item("Precio_x_Sobre")
                Cantidad_x_Peso = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Peso")
                Cantidad_x_Volumen = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Volumen")
                Cantidad_x_Sobre = lds_tmp.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
                Total_Peso = lds_tmp.Tables(0).Rows(0).Item("Total_Peso")
                Total_Volumen = lds_tmp.Tables(0).Rows(0).Item("Total_Volumen")
                MONTO_SUB_TOTAL = lds_tmp.Tables(0).Rows(0).Item("MONTO_SUB_TOTAL")
                MONTO_IMPUESTO = lds_tmp.Tables(0).Rows(0).Item("MONTO_IMPUESTO")
                Monto_Base = lds_tmp.Tables(0).Rows(0).Item("Monto_Base")
                Total_Costo = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
                Nombre_Entrega = lds_tmp.Tables(0).Rows(0).Item("Nombre_Entrega")
                Doc_Entrega = lds_tmp.Tables(0).Rows(0).Item("Doc_Entrega")
                Fecha_Entrega = lds_tmp.Tables(0).Rows(0).Item("Fecha_Entrega")
                Hora_Entrega = lds_tmp.Tables(0).Rows(0).Item("Hora_Entrega")
                idEstadoGuiaTrans = lds_tmp.Tables(0).Rows(0).Item("idEstadoGuiaTrans")
                Estado_Documento = lds_tmp.Tables(0).Rows(0).Item("Estado_Documento")
                idEstado_Documento = lds_tmp.Tables(0).Rows(0).Item("idEstado_Documento")
                Cantidad_x_Articulos = lds_tmp.Tables(0).Rows(0).Item("Cant_Art")
                EstadoEnvio = lds_tmp.Tables(0).Rows(0).Item("EstadoEnvio")
                IdEstadoEnvio = lds_tmp.Tables(0).Rows(0).Item("idEstadoEnvio")
                v_Obs = IIf(lds_tmp.Tables(0).Rows(0).Item("v_Obs") <> "", lds_tmp.Tables(0).Rows(0).Item("v_Obs"), "")
                l_por_entregar = 0
                l_por_entregar = CType(lds_tmp.Tables(0).Rows(0).Item("por_entregar"), Long)
                l_entregado = CType(lds_tmp.Tables(0).Rows(0).Item("Tot_Entregado"), Long)
                l_cantidad_total = CType(lds_tmp.Tables(0).Rows(0).Item("CANTIDAD_TOTAL"), Long)
                Consignado = lds_tmp.Tables(0).Rows(0).Item("consignado")

                '----CambioR 10112011---
                c_idpersona = lds_tmp.Tables(0).Rows(0).Item("Idpersona")
                l_idagencia_destino = lds_tmp.Tables(0).Rows(0).Item("Idunidad_Agencia")
                IDComprobante = lds_tmp.Tables(0).Rows(0).Item("IDComprobante")
                Idtipo_Comprobante = lds_tmp.Tables(0).Rows(0).Item("Idtipo_Comprobante")
                '-----------------------
                '
                dt_cur_Articulos = lds_tmp.Tables(1)
                dt_cur_Documentos = lds_tmp.Tables(2)
                dt_cur_Estados_Entrega = lds_tmp.Tables(3)
                dtConsignado = lds_tmp.Tables(4)
                '
                flat = True
            Else
                flat = False
            End If
            '
        Catch ex As Excepcion
            flat = False
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    Public Function Listar(usuario As Integer, ip As String) As DataTable
        ' la configuracion esta basade en dos campos importantes... el pktem que implica el tipo de tabla al que esta asociado el registro 
        ' 1 si esta en la tabla facturacion y 2 si esta en la tabla guia de envio..
        ' el segundo campo 
        Dim flat As Boolean = True
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_CONSULTA_CARGA_III", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iControl", c_iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_NroDoc", c_NroDoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Serie", c_Serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_inicio", c_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_fin", c_fecha_fin, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idOrigen", c_idOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDestino", c_idDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idusuariopersonal", c_idusuariopersonal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idestado_registro", c_idestado_registro, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_rucdni", c_rucdni, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idpersona", c_idpersona, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_entrega", c_tipo_entrega, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("ni_tipo", c_tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_nombres", c_nombres, OracleClient.OracleType.VarChar)

            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            'Variables de salidas 
            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp.Tables(0)
            '
        Catch ex As Excepcion
            flat = False
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarConsignado(tipo As Integer, comprobante As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet

            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_listar_consignado", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_comprobante", comprobante, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_consignado", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
End Class
