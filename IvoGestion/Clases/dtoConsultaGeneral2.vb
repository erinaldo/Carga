Imports AccesoDatos
Public Class dtoConsultaGeneral2
#Region "Variables"
    'Public cur_tipo_facturacion As New ADODB.Recordset
    Public cur_tipo_facturacion As DataTable
    'Public cur_tipo_entrega As New ADODB.Recordset
    Public cur_tipo_entrega As DataTable
    'Public cur_unidad_agencia_origen As New ADODB.Recordset
    Public cur_unidad_agencia_origen As DataTable
    'Public cur_unidad_agencia_destino As New ADODB.Recordset
    Public cur_unidad_agencia_destino As DataTable
    '
    'Public cur_tipo_comprobante As New ADODB.Recordset
    Public cur_tipo_comprobante As DataTable

    'Public cur_tipo_cliente As New ADODB.Recordset
    Public cur_tipo_cliente As DataTable

    'Public cur_tarjeta As New ADODB.Recordset
    Public cur_tarjeta As DataTable

    'Public cur_funcionario As New ADODB.Recordset
    Public cur_funcionario As DataTable

    'Public cur_funcionario_cliente As New ADODB.Recordset
    Public cur_funcionario_cliente As DataTable

    'Public cur_agencia As New ADODB.Recordset
    Public cur_agencia As DataTable

    'Public cur_datos As New ADODB.Recordset

    'Public cur_subcuenta As New ADODB.Recordset
    Public cur_subcuenta As DataTable

    'Public cur_cliente As New ADODB.Recordset
    Public cur_cliente As DataTable

    'Public cur_direccion1 As New ADODB.Recordset
    Public cur_direccion1 As DataTable

    'Public cur_consignado As New ADODB.Recordset
    Public cur_consignado As DataTable

    'Public cur_direccion2 As New ADODB.Recordset
    Public cur_direccion2 As DataTable

    'Public cur_contacto As New ADODB.Recordset
    Public cur_contacto As DataTable

    'Public cur_personas As New ADODB.Recordset
    Public cur_personas As DataTable

    'Public cur_usuarios As New ADODB.Recordset
    Public cur_usuarios As DataTable

    Public coll_Tipo_Facturacion As New Collection
    Public coll_Tipo_Entrega As New Collection
    Public coll_Tipo_Comprobante As New Collection
    Public coll_Tipo_Cliente As New Collection
    Public coll_Unidad_Agencia_Origen As New Collection
    Public coll_Unidad_Agencia_Destino As New Collection
    Public coll_Tarjeta As New Collection
    Public coll_Funcionario As New Collection

    Public sFuncionario As String
    Public v_IDPERSONA As String

    'Public curVenta As New ADODB.Recordset
    Public curVenta As DataTable

    Private sUsuarioEstado As String
    Private sFechaInicio As String
    Private sFechaFin As String
    Private sTipoFacturacion As String
    Private sTipoEntrega As String
    Private sOrigen As String
    Private sDestino As String
    Private sTipoComprobante As String
    Private sAgenciaOrigen As String
    Private sAgenciaDestino As String
    Private sTipoPersona As String
    Private sTipoTarjeta As String
    Private sNumeroTarjeta As String

    Private sRemitente As String
    Private sConsignado As String
    Private sDir1 As String
    Private sDir2 As String
    Public sContacto As String

    Private sSubcuenta As String
    Private sEstado As String

    Private sPrefactura As String
    Private sFactura As String
    Private sGrt As String
    Private sCargo As String
    Private sDevCargo As String
    Private sArticulo As String
    Private sSeguro As String
    Private sDescuento As String
    Private sEstados As String
    Private sFecha As String
    Private sAcompanada As Long
    Private iPyme As Integer
    Private iTe As Integer

    Dim ControlError As Integer
#End Region

#Region "Constructor"
    Public Sub New()

    End Sub

#End Region

#Region "Metodos"

    'Public Function fnCARGAR_USUARIOS2009(ByVal p_Agencia As String) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnCARGAR_USUARIOS] ")
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_CARGAR_USUARIOS", 4, p_Agencia, 2}
    '        cur_usuarios = Nothing
    '        cur_usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnCARGAR_USUARIOS] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function

    Public Function fnCARGAR_USUARIOS(ByVal p_Agencia As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGUIAS_ENVIO.SP_CARGAR_USUARIOS", CommandType.StoredProcedure)
            db.AsignarParametro("ni_agencia", p_Agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("cur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_usuarios = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnLISTA_PERSONAS2009(ByVal P_IDUSUARIO_PERSONAL As String) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_PERSONAS] ")
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_LISTA_PERSONASIV", 2}
    '        cur_personas = Nothing
    '        cur_personas = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_PERSONAS] " & ex.ToString)
    '    End Try
    '    Return flat
    'End Function
    Public Function fnLISTA_PERSONAS(ByVal P_IDUSUARIO_PERSONAL As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGUIAS_ENVIO.SP_LISTA_PERSONASIV", CommandType.StoredProcedure)
            db.AsignarParametro("cur_Lista_Personas", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_personas = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Iniciar2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"SP_INICIAR", 2}
    '    cur_tipo_facturacion = VOCONTROLUSUARIO.fnsqlquery(SQLQuery)
    '    cur_tipo_entrega = cur_tipo_facturacion.NextRecordset
    '    cur_unidad_agencia_origen = cur_tipo_facturacion.NextRecordset
    '    cur_unidad_agencia_destino = cur_tipo_facturacion.NextRecordset
    '    cur_tipo_comprobante = cur_tipo_facturacion.NextRecordset
    '    cur_tipo_cliente = cur_tipo_facturacion.NextRecordset
    '    cur_tarjeta = cur_tipo_facturacion.NextRecordset
    '    cur_funcionario = cur_tipo_facturacion.NextRecordset
    '    cur_agencia = cur_tipo_facturacion.NextRecordset

    'Catch ex As Exception
    '    flag = False
    'End Try

    'Return flag
    'End Function
    Public Function Iniciar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_INICIAR", CommandType.StoredProcedure)
            db.AsignarParametro("cur_tipo_facturacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_tipo_entrega", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_unidad_agencia_origen", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_unidad_agencia_destino", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_tipo_comprobante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_tipo_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_tarjeta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_funcionario", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_tipo_facturacion = ds.Tables(0)
            cur_tipo_entrega = ds.Tables(1)
            cur_unidad_agencia_origen = ds.Tables(2)
            cur_unidad_agencia_destino = ds.Tables(3)
            cur_tipo_comprobante = ds.Tables(4)
            cur_tipo_cliente = ds.Tables(5)
            cur_tarjeta = ds.Tables(6)
            cur_funcionario = ds.Tables(7)
            cur_agencia = ds.Tables(8)
            Return True

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        End Try
    End Function


    'Public Function LlenarComboIDs(ByVal rst As ADODB.Recordset, ByRef cLista As ComboBox, ByRef id As Collection, ByRef idSel As Integer, ByRef bTodo As Boolean) As Integer
    'Try
    '    Dim index As Integer
    '    Dim indexSeleccion As Integer
    '    index = 0
    '    indexSeleccion = 0
    '    cLista.DropDownStyle = ComboBoxStyle.DropDownList
    '    cLista.Controls.Clear()
    '    cLista.Items.Clear()
    '    id = Nothing
    '    id = New Collection()
    '    '
    '    If Not (rst Is Nothing) Then
    '        While rst.BOF = False And rst.EOF = False
    '            '
    '            If bTodo And index = 0 Then
    '                cLista.Items.Insert(index, " -TODOS-")
    '                id.Add("-1", index.ToString())
    '                index += 1
    '            End If

    '            cLista.Items.Insert(index, rst.Fields(1).Value)
    '            id.Add(rst.Fields(0).Value, index.ToString())
    '            If idSel = rst.Fields(0).Value Then
    '                indexSeleccion = index
    '            End If
    '            rst.MoveNext()
    '            index = index + 1
    '        End While
    '    End If
    '    ' 
    '    If cLista.Items.Count > 0 Then
    '        cLista.SelectedIndex = indexSeleccion
    '    Else
    '        cLista.SelectedIndex = -1
    '    End If
    '    ControlError = 1
    'Catch ex As Exception
    '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
    '    ControlError = 0
    'End Try
    'Return ControlError
    'End Function
    'Public Function ObtieneFuncionario2009(ByVal sPersona As String) As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"sp_obtiene_funcionario", 4, sPersona, 2}
    '        cur_funcionario_cliente = VOCONTROLUSUARIO.fnsqlquery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function ObtieneFuncionario(ByVal sPersona As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("sp_obtiene_funcionario", CommandType.StoredProcedure)
            db.CrearComando("sp_obtiene_funcionario_cartera", CommandType.StoredProcedure)
            db.AsignarParametro("id", sPersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_funcionario", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_funcionario_cliente = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        End Try
    End Function
    'Public Function fnSP_CENTRO_COSTO2009() As ADODB.Recordset
    '    'Dim flat As String = "..."
    '    'Try
    '    '    Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_CENTRO_COSTO_1", 4, v_IDPERSONA, 2}
    '    '    cur_datos = Nothing
    '    '    cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'Catch ex As Exception
    '    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    '    flat = "...xxx"
    '    'End Try
    '    'Return cur_datos
    'End Function

    Public Function fnSP_CENTRO_COSTO() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA.SP_CENTRO_COSTO_1", CommandType.StoredProcedure)
            db.AsignarParametro("v_idPersona", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function CargarDatos2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"SP_CLIENTE_DATOS", 4, v_IDPERSONA, 2}
    '    cur_cliente = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    'If cur_cliente.BOF = False And cur_cliente.EOF = False Then
    '    cur_subcuenta = cur_cliente.NextRecordset
    '    cur_direccion1 = cur_cliente.NextRecordset
    '    cur_consignado = cur_cliente.NextRecordset
    '    cur_direccion2 = cur_cliente.NextRecordset
    '    cur_contacto = cur_cliente.NextRecordset
    '    'End If
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function CargarDatos() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_CLIENTE_DATOS", CommandType.StoredProcedure)
            db.AsignarParametro("idcliente", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_remitente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_subcuenta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_direccion1", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_consignado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_cliente = ds.Tables(0)
            cur_subcuenta = ds.Tables(1)
            cur_direccion1 = ds.Tables(2)
            cur_consignado = ds.Tables(3)
            cur_direccion2 = ds.Tables(4)
            cur_contacto = ds.Tables(5)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function CargarDatos22009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"SP_CLIENTE_DATOS_1", 4, v_IDPERSONA, 2}
    '    cur_direccion1 = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If cur_direccion1.BOF = False And cur_direccion1.EOF = False Then
    '        cur_consignado = cur_direccion1.NextRecordset
    '        cur_direccion2 = cur_direccion1.NextRecordset
    '        cur_contacto = cur_direccion1.NextRecordset
    '    End If
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function CargarDatos2() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_CLIENTE_DATOS_1", CommandType.StoredProcedure)
            db.AsignarParametro("idcliente", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_direccion1", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_consignado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_direccion2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_contacto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_direccion1 = ds.Tables(0)
            If cur_direccion1.Rows.Count > 0 Then
                cur_consignado = ds.Tables(1)
                cur_direccion2 = ds.Tables(2)
                cur_contacto = ds.Tables(3)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Ejecutar2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"SP_CONSULTA_VENTAS_2", 66, ObtieneEstado(), 2, sUsuarioEstado, 2, _
    '                                                                 sFechaInicio, 2, _
    '                                                                 sFechaFin, 2, _
    '                                                                 sTipoFacturacion, 2, _
    '                                                                 sTipoEntrega, 2, _
    '                                                                 sOrigen, 2, _
    '                                                                 sDestino, 2, _
    '                                                                 sTipoComprobante, 2, _
    '                                                                 sAgenciaOrigen, 2, _
    '                                                                 sAgenciaDestino, 2, _
    '                                                                 sTipoPersona, 2, _
    '                                                                 sTipoTarjeta, 2, _
    '                                                                 v_IDPERSONA, 2, _
    '                                                                 sRemitente, 2, _
    '                                                                 sConsignado, 2, _
    '                                                                 sDir1, 2, _
    '                                                                 sDir2, 2, _
    '                                                                 sSubcuenta, 2, _
    '                                                                 sPrefactura, 2, _
    '                                                                 sFactura, 2, _
    '                                                                 sGrt, 2, _
    '                                                                 sCargo, 2, _
    '                                                                 sDevCargo, 2, _
    '                                                                 sArticulo, 2, _
    '                                                                 sSeguro, 2, _
    '                                                                 sDescuento, 2, _
    '                                                                 sContacto, 2, _
    '                                                                 sFuncionario, 2, _
    '                                                                 sNumeroTarjeta, 2, _
    '                                                                 sEstados, 2, _
    '                                                                 sFecha, 2 _
    '                                                                 }
    '    curVenta = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If curVenta.BOF = False And curVenta.EOF = False Then
    '        'curVenta = curVenta.NextRecordset
    '    End If
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function Ejecutar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'db.CrearComando("SP_CONSULTA_VENTAS_2", CommandType.StoredProcedure) - 06/08/2010 - Cuando pase a producción eliminar el procedimiento 
            'db.CrearComando("SP_CONSULTA_VENTAS_3", CommandType.StoredProcedure) - 15/10/2010
            'db.CrearComando("SP_CONSULTA_VENTAS_4", CommandType.StoredProcedure)
            db.CrearComando("SP_CONSULTA_VENTAS_5", CommandType.StoredProcedure)
            db.AsignarParametro("estado", ObtieneEstado(), OracleClient.OracleType.VarChar)
            db.AsignarParametro("usuario_estado", sUsuarioEstado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_inicio", sFechaInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_fin", sFechaFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("tipo_facturacion", sTipoFacturacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("tipo_entrega", sTipoEntrega, OracleClient.OracleType.VarChar)
            db.AsignarParametro("origen", sOrigen, OracleClient.OracleType.VarChar)
            db.AsignarParametro("destino", sDestino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("tipo_documento", sTipoComprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("agencia_origen", sAgenciaOrigen, OracleClient.OracleType.VarChar)
            db.AsignarParametro("agencia_destino", sAgenciaDestino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("tipo_persona", sTipoPersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("tipo_tarjeta", sTipoTarjeta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("id_persona", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("idremitente", sRemitente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("idconsignado", sConsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iddir1", sDir1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iddir2", sDir2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("subcuenta", sSubcuenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("prefactura", sPrefactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("factura", sFactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("grt", sGrt, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cargos", sCargo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("dev_cargo", sDevCargo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("articulo", sArticulo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("carga_asegurada", sSeguro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("descuento", sDescuento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("contacto", sContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("funcionario", sFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("numero_tarjeta", sNumeroTarjeta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("estado2", sEstados, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha", sFecha, OracleClient.OracleType.VarChar)
            '06/08/2010 - Carga Acompañada 
            db.AsignarParametro("ni_acompanada", sAcompanada, OracleClient.OracleType.Number)
            '10/10/2010 - Carga Pyme
            db.AsignarParametro("ni_pyme", iPyme, OracleClient.OracleType.Number)
            '13/05/2011 - Carga Tepsa Encomiendas
            db.AsignarParametro("ni_te", iTe, OracleClient.OracleType.Number)

            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            curVenta = ds.Tables(0)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function LlenarComboIDs(ByVal rst As DataTable, ByRef cLista As ComboBox, ByRef id As Collection, ByRef idSel As Integer, ByRef bTodo As Boolean) As Integer
        Try
            Dim index As Integer
            Dim indexSeleccion As Integer
            index = 0
            indexSeleccion = 0
            cLista.DropDownStyle = ComboBoxStyle.DropDownList
            '
            cLista.Controls.Clear()
            cLista.Items.Clear()
            '
            id = Nothing
            id = New Collection()
            '
            If rst.Rows.Count > 0 Then
                For Each obj As DataRow In rst.Rows
                    If bTodo And index = 0 Then
                        cLista.Items.Insert(index, " -TODOS-")
                        id.Add("-1", index.ToString())
                        index += 1
                    End If

                    cLista.Items.Insert(index, obj.Item(1))
                    id.Add(obj.Item(0), index.ToString())
                    If idSel = obj.Item(0) Then
                        indexSeleccion = index
                    End If
                    index = index + 1
                Next
            End If
            '
            'If Not (rst Is Nothing) Then
            '    While rst.BOF = False And rst.EOF = False
            '        '
            '        If bTodo And index = 0 Then
            '            cLista.Items.Insert(index, " -TODOS-")
            '            id.Add("-1", index.ToString())
            '            index += 1
            '        End If

            '        cLista.Items.Insert(index, rst.Fields(1).Value)
            '        id.Add(rst.Fields(0).Value, index.ToString())
            '        If idSel = rst.Fields(0).Value Then
            '            indexSeleccion = index
            '        End If

            '        rst.MoveNext()
            '        index = index + 1
            '    End While
            'End If
            ' 
            If cLista.Items.Count > 0 Then
                cLista.SelectedIndex = indexSeleccion
            Else
                cLista.SelectedIndex = -1
            End If
            ControlError = 1
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
            ControlError = 0
        End Try
        Return ControlError
    End Function
#End Region

#Region "Propiedades"
    Public Property UsuarioEstado() As String
        Get
            Return sUsuarioEstado
        End Get
        Set(ByVal value As String)
            sUsuarioEstado = value
        End Set
    End Property

    Public Property FechaInicio() As String
        Get
            Return sFechaInicio
        End Get
        Set(ByVal value As String)
            sFechaInicio = value
        End Set
    End Property

    Public Property FechaFin() As String
        Get
            Return sFechaFin
        End Get
        Set(ByVal value As String)
            sFechaFin = value
        End Set
    End Property

    Public Property TipoFacturacion() As String
        Get
            Return sTipoFacturacion
        End Get
        Set(ByVal value As String)
            sTipoFacturacion = value
        End Set
    End Property

    Public Property TipoEntrega() As String
        Get
            Return sTipoEntrega
        End Get
        Set(ByVal value As String)
            sTipoEntrega = value
        End Set
    End Property

    Public Property Origen() As String
        Get
            Return sOrigen
        End Get
        Set(ByVal value As String)
            sOrigen = value
        End Set
    End Property

    Public Property Destino() As String
        Get
            Return sDestino
        End Get
        Set(ByVal value As String)
            sDestino = value
        End Set
    End Property

    Public Property TipoComprobante() As String
        Get
            Return sTipoComprobante
        End Get
        Set(ByVal value As String)
            sTipoComprobante = value
        End Set
    End Property

    Public Property AgenciaOrigen() As String
        Get
            Return sAgenciaOrigen
        End Get
        Set(ByVal value As String)
            sAgenciaOrigen = value
        End Set
    End Property

    Public Property AgenciaDestino() As String
        Get
            Return sAgenciaDestino
        End Get
        Set(ByVal value As String)
            sAgenciaDestino = value
        End Set
    End Property

    Public Property TipoPersona() As String
        Get
            Return sTipoPersona
        End Get
        Set(ByVal value As String)
            sTipoPersona = value
        End Set
    End Property

    Public Property TipoTarjeta() As String
        Get
            Return sTipoTarjeta
        End Get
        Set(ByVal value As String)
            sTipoTarjeta = value
        End Set
    End Property

    Public Property Remitente() As String
        Get
            Return sRemitente
        End Get
        Set(ByVal value As String)
            sRemitente = value
        End Set
    End Property

    Public Property Consignado() As String
        Get
            Return sConsignado
        End Get
        Set(ByVal value As String)
            sConsignado = value
        End Set
    End Property

    Public Property Dir1() As String
        Get
            Return sDir1
        End Get
        Set(ByVal value As String)
            sDir1 = value
        End Set
    End Property

    Public Property Dir2() As String
        Get
            Return sDir2
        End Get
        Set(ByVal value As String)
            sDir2 = value
        End Set
    End Property

    Public Property Subcuenta() As String
        Get
            Return sSubcuenta
        End Get
        Set(ByVal value As String)
            sSubcuenta = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return sEstado
        End Get
        Set(ByVal value As String)
            sEstado = value
        End Set
    End Property

    Private Function ObtieneEstado() As String
        '-TODOS-
        'REGISTRO()
        'DESPACHO()
        'DESPACHO(PARCIAL)
        'RECEPCION()
        'RECEPCION(PARCIAL)
        'REPARTO()
        'ENTREGA()
        'CARGOS()

        Select Case sEstado
            Case 1
                ObtieneEstado = "18"
            Case 2
                ObtieneEstado = "19"
            Case 3
                ObtieneEstado = "41"
            Case 4
                ObtieneEstado = "20"
            Case 5
                ObtieneEstado = "40"
            Case 6
                ObtieneEstado = "47"
            Case 7
                ObtieneEstado = "21"
            Case 8
                ObtieneEstado = "-1"
            Case Else
                ObtieneEstado = "-1"
        End Select
    End Function

    Public Property Prefactura() As String
        Get
            Return sPrefactura
        End Get
        Set(ByVal value As String)
            sPrefactura = value
        End Set
    End Property

    Public Property Factura() As String
        Get
            Return sFactura
        End Get
        Set(ByVal value As String)
            sFactura = value
        End Set
    End Property

    Public Property Grt() As String
        Get
            Return sGrt
        End Get
        Set(ByVal value As String)
            sGrt = value
        End Set
    End Property

    Public Property Cargo() As String
        Get
            Return sCargo
        End Get
        Set(ByVal value As String)
            sCargo = value
        End Set
    End Property

    Public Property DevCargo() As String
        Get
            Return sDevCargo
        End Get
        Set(ByVal value As String)
            sDevCargo = value
        End Set
    End Property

    Public Property Articulo() As String
        Get
            Return sArticulo
        End Get
        Set(ByVal value As String)
            sArticulo = value
        End Set
    End Property

    Public Property Seguro() As String
        Get
            Return sSeguro
        End Get
        Set(ByVal value As String)
            sSeguro = value
        End Set
    End Property

    Public Property Descuento() As String
        Get
            Return sDescuento
        End Get
        Set(ByVal value As String)
            sDescuento = value
        End Set
    End Property

    Public Property Contacto() As String
        Get
            Return sContacto
        End Get
        Set(ByVal value As String)
            sContacto = value
        End Set
    End Property

    Public Property Funcionario() As String
        Get
            Return sFuncionario
        End Get
        Set(ByVal value As String)
            sFuncionario = value
        End Set
    End Property

    Public Property NumeroTarjeta() As String
        Get
            Return sNumeroTarjeta
        End Get
        Set(ByVal value As String)
            sNumeroTarjeta = value
        End Set
    End Property

    Public Property Estados() As String
        Get
            Return sEstados
        End Get
        Set(ByVal value As String)
            sEstados = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return sFecha
        End Get
        Set(ByVal value As String)
            sFecha = value
        End Set
    End Property
    Public Property acompanada() As Long
        Get
            Return sAcompanada
        End Get
        Set(ByVal value As Long)
            sAcompanada = value
        End Set
    End Property
    Public Property Pyme() As Integer
        Get
            Return iPyme
        End Get
        Set(ByVal value As Integer)
            iPyme = value
        End Set
    End Property
    Public Property Te() As Integer
        Get
            Return iTe
        End Get
        Set(ByVal value As Integer)
            iTe = value
        End Set
    End Property
#End Region
End Class
