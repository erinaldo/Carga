Imports AccesoDatos
Public Class dtoEntrega_Recojo
    'Public cur_datos As New ADODB.Recordset
    '
    Public dt_cur_datos As New DataTable
    '
    Public coll_Lista_rutas As New Collection
    Public coll_Lista_Tipo_Operacion As New Collection
    Public coll_Lista_Distritos As New Collection

    Public coll_Lista_Motivos As New Collection

    Public v_IDCONTROL As Integer
    Public v_IDTIPO_OPERACION As String
    Public v_IDATENDIDO As Integer
    Public v_FECHA_INICIO As String
    Public v_FECHA_FIN As String
    Public v_NRO_MOVIL As String
    Public v_NRO_SOLICITUD As String
    Public v_RUC_RAZONSOCIAL As String
    Public v_IDUSUARIO_RESPONSABLE As Integer
    Public v_IDESTADO_DOCUMENTO As Integer
    Public v_idUnidad_Agencia As Integer
    Public v_idProcedencia As Integer

    Public v_idTipo_Comprobante As Integer
    Public v_idComprobante As String
    Public v_idtipoOPeracion As Integer
    Public v_Atendido As Integer
    Public v_serie As String = "00"
    Public v_nroDoc As String = "00"
    Public v_idEstado_Envio As Integer
    Public v_idSolicitudEntrega As String
    Public TipoComprobante As Integer
    'confirmacion de Entregas
    Public x_Cliente As String
    Public x_Consignado As String
    Public x_NroDoc As String
    Public x_Fecha As String
    Public x_Atendido As String
    Public x_Cantidad As String
    Public x_NroSobres As String
    Public x_Origen As String
    Public x_Destino As String
    Public x_Direccion As String
    Public x_Hora_Entrega As String
    Public x_DNI_Entrega As String
    Public x_Nombres_Entrega As String
    Public x_Responsable As String
    Public x_Estado As String
    Public x_Tipo_comprobante As String
    Public x_Idmotivos_No_Atencion As Integer
    Public x_obs As String
    Public x_Idpersona_Recojo As String
    '-----
    Public x_Idpersona As Integer
    Public x_idagencia_destino As Integer
    Public x_idComprobante As Integer
    Public x_Idtipo_Comprobante As Integer
    '-----
    '-- iNICIANDO
    Public R_CodigoUsuario As String = ""
    Public R_NumeroSolicitud As String = ""
    Public R_TipoOperacion As String = "" '(varchar2, --E - -R)
    Public R_EstadoFinal As String = ""
    Public R_NroGuiaEnvio As String = ""
    Public R_IataDestino As String = ""
    Public R_TipoEntrega As String = ""
    Public R_NumeroBultos As Integer = 0
    Public R_NumeroSobres As Integer = 0
    Public R_Peso As Double = 0
    Public R_Volumen As Double = 0
    Public R_DniCliente As String = ""
    Public R_NombreCliente As String = ""
    Public R_Observación As String = ""
    Public R_CodigoMotNoAtencion As String = ""
    Public R_Fecha_Atencion As String = ""
    Public R_hora_Atencion As String = ""
    Public R_Direccion_Entrega As String = ""
    Public Sub fnClearEntrega()
        R_CodigoUsuario = ""
        R_NumeroSolicitud = ""
        R_TipoOperacion = "E" '(varchar2, --E - -R)
        R_EstadoFinal = ""
        R_NroGuiaEnvio = ""
        R_IataDestino = ""
        R_TipoEntrega = ""
        R_NumeroBultos = 0
        R_NumeroSobres = 0
        R_Peso = 0
        R_Volumen = 0
        R_DniCliente = ""
        R_NombreCliente = ""
        R_Observación = ""
        R_CodigoMotNoAtencion = ""
        R_Fecha_Atencion = ""
        R_hora_Atencion = ""
        R_Direccion_Entrega = ""
    End Sub
    'Public Sub fnRegistrarEstado_2009()
    '    Try
    '        If R_Observación = "" Then
    '            R_Observación = "NULL"
    '        End If
    '        'R_Observación = "NULL"
    '        If R_CodigoMotNoAtencion = "999" Then
    '            R_CodigoMotNoAtencion = "NULL"
    '        End If
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_UPD_ENTREGA_CARGA", 24, R_CodigoUsuario, 2, R_NumeroSolicitud, 2, R_EstadoFinal, 2, R_DniCliente, 2, R_NombreCliente, 2, R_Observación, 2, R_NumeroBultos, 1, R_CodigoMotNoAtencion, 2, R_Fecha_Atencion, 2, R_hora_Atencion, 2, R_Direccion_Entrega, 2}
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_UPD_ENTREGA_CARGA1", 30, R_CodigoUsuario, 2, R_NumeroSolicitud, 2, R_EstadoFinal, 2, R_DniCliente, 2, R_NombreCliente, 2, R_Observación, 2, R_NumeroBultos, 1, R_CodigoMotNoAtencion, 2, R_Fecha_Atencion, 2, R_hora_Atencion, 2, R_Direccion_Entrega, 2, dtoUSUARIOS.iIDAGENCIAS, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdLogin, 1}
    '        '29/01/2008 
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_UPD_ENTREGA_CARGA2", 30, R_CodigoUsuario, 2, R_NumeroSolicitud, 2, R_EstadoFinal, 2, R_DniCliente, 2, R_NombreCliente, 2, R_Observación, 2, R_NumeroBultos, 1, R_CodigoMotNoAtencion, 2, R_Fecha_Atencion, 2, R_hora_Atencion, 2, R_Direccion_Entrega, 2, dtoUSUARIOS.iIDAGENCIAS, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdLogin, 1}
    '        '
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            MsgBox(cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Sub fnRegistrarEstado()
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            If R_Observación = "" Then
                R_Observación = "NULL"
            End If
            '
            If R_CodigoMotNoAtencion = "999" Then
                R_CodigoMotNoAtencion = "NULL"
            End If
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_UPD_ENTREGA_CARGA2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("CodigoUsuario", R_CodigoUsuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("NumeroSolicitud", R_NumeroSolicitud, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("EstadoFinal", R_EstadoFinal, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("DniCliente", R_DniCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("NombreCliente", R_NombreCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("Observacion", R_Observación, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("NumeroBultos", R_NumeroBultos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CodigoMotNoAtencion", R_CodigoMotNoAtencion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("Fecha_Atencion", R_Fecha_Atencion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("hora_Atencion", R_hora_Atencion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("Direccion_Entrega", R_Direccion_Entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_reg", dtoUSUARIOS.iIDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_persona", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                'MsgBox(ldt_tmp.Rows(0).Item("MGSBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                MsgBox(ldt_tmp.Rows(0).Item(0), MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Sub fnSP_LISTAR_MOTIVOS_2009()
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTAR_MOTIVOS", 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Function fnSP_LISTAR_MOTIVOS() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '29/09/2011 hlamas
            'db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTAR_MOTIVOS", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTAR_MOTIVOS_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("co_motivo", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub fnBUSCAR_DATOS_SOLICITUD_2009(ByVal idSolicitud As Integer)
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_SOLICITUD", 4, idSolicitud.ToString, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            x_Cliente = cur_datos.Fields.Item("razon_social").Value
    '            x_Consignado = cur_datos.Fields.Item("Consignado").Value
    '            x_NroDoc = cur_datos.Fields.Item("NroDoc").Value
    '            x_Fecha = cur_datos.Fields.Item("Fecha_Doc").Value
    '            x_Atendido = cur_datos.Fields.Item("Atendido").Value
    '            x_Cantidad = cur_datos.Fields.Item("Cantidad").Value
    '            x_NroSobres = cur_datos.Fields.Item("Sobres").Value
    '            x_Origen = cur_datos.Fields.Item("Origen").Value
    '            x_Destino = cur_datos.Fields.Item("Destino").Value
    '            x_Direccion = cur_datos.Fields.Item("Direccion").Value
    '            x_Hora_Entrega = cur_datos.Fields.Item("hora_entrega").Value
    '            x_DNI_Entrega = cur_datos.Fields.Item("DNI").Value
    '            x_Nombres_Entrega = cur_datos.Fields.Item("nombre_entrega").Value
    '            x_Responsable = cur_datos.Fields.Item("Responsable").Value
    '            x_Estado = cur_datos.Fields.Item("EstadoEnvio").Value
    '            x_Tipo_comprobante = cur_datos.Fields.Item("tipo_comprobante").Value

    '            x_Idmotivos_No_Atencion = cur_datos.Fields.Item("Idmotivos_No_Atencion").Value
    '            x_obs = cur_datos.Fields.Item("Obs").Value
    '            x_Idpersona_Recojo = cur_datos.Fields.Item("Idpersona_Recojo").Value
    '        Else
    '            MsgBox("Revice sus datos...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Sub fnBUSCAR_DATOS_SOLICITUD(ByVal idSolicitud As Integer)
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_SOLICITUD", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idSolicitud", idSolicitud.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                x_Cliente = ldt_tmp.Rows(0).Item("razon_social")
                x_Consignado = ldt_tmp.Rows(0).Item("Consignado")
                x_NroDoc = ldt_tmp.Rows(0).Item("NroDoc")
                x_Fecha = ldt_tmp.Rows(0).Item("Fecha_Doc")
                x_Atendido = ldt_tmp.Rows(0).Item("Atendido")
                x_Cantidad = ldt_tmp.Rows(0).Item("Cantidad")
                x_NroSobres = ldt_tmp.Rows(0).Item("Sobres")
                x_Origen = ldt_tmp.Rows(0).Item("Origen")
                x_Destino = ldt_tmp.Rows(0).Item("Destino")
                x_Direccion = ldt_tmp.Rows(0).Item("Direccion")
                x_Hora_Entrega = ldt_tmp.Rows(0).Item("hora_entrega")
                x_DNI_Entrega = ldt_tmp.Rows(0).Item("DNI")
                x_Nombres_Entrega = ldt_tmp.Rows(0).Item("nombre_entrega")
                x_Responsable = ldt_tmp.Rows(0).Item("Responsable")
                x_Estado = ldt_tmp.Rows(0).Item("EstadoEnvio")
                x_Tipo_comprobante = ldt_tmp.Rows(0).Item("tipo_comprobante")
                x_Idmotivos_No_Atencion = ldt_tmp.Rows(0).Item("Idmotivos_No_Atencion")
                x_obs = ldt_tmp.Rows(0).Item("Obs")
                x_Idpersona_Recojo = ldt_tmp.Rows(0).Item("Idpersona_Recojo")
            Else
                MsgBox("No se encontro el documento en el reparto y/o recojo", MsgBoxStyle.Information, "Seguridad Sistema")
                'MsgBox("Revice sus datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Sub fnCANCELACION_ENTREGA_2009()
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_CANCELACION_ENTREGA", 4, v_idSolicitudEntrega, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Sub fnCANCELACION_ENTREGA()
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_CANCELACION_ENTREGA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idSolicitudEntrega", v_idSolicitudEntrega, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Sub fnASOCIAR_MOVIL_ENTREGA_2009()
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_ASOCIAR_MOVIL_ENTREGA", 22, v_IDCONTROL, 1, v_idTipo_Comprobante, 1, v_idComprobante, 2, v_IDUSUARIO_RESPONSABLE, 1, v_idtipoOPeracion, 1, v_Atendido, 1, v_serie, 2, v_nroDoc, 2, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdLogin, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Function fnASOCIAR_MOVIL_ENTREGA() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_ASOCIAR_MOVIL_ENTREGA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_control", v_IDCONTROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_idTipo_Comprobante", v_idTipo_Comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_idComprobante", v_idComprobante, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idUsuario_responsable", v_IDUSUARIO_RESPONSABLE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idtipoOPeracion", v_idtipoOPeracion, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Atendido", v_Atendido, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_serie", v_serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_nroDoc", v_nroDoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idUsuario_Personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub fnSP_CONTROL_OPERACIONES_2009()
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_OPERACIONES", 4, dtoUSUARIOS.m_idciudad, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    'End Sub
    Public Function fnSP_CONTROL_OPERACIONES() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_OPERACIONES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idUnidad_Agencia", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Estados", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Tipo_Operacion", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Atendido", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Unidad_Agencia", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Operacion", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnLISTA_ENTREGAS_RECOJOS_2009() As Boolean
    '    Dim flat As Boolean = True
    '    v_IDCONTROL = 1
    '    v_IDTIPO_OPERACION = 1
    '    v_IDATENDIDO = 1
    '    'v_FECHA_INICIO = "02/02/2007"
    '    'v_FECHA_FIN = "02/02/2007"
    '    v_NRO_MOVIL = "LIM10001"
    '    v_NRO_SOLICITUD = "124"
    '    'v_RUC_RAZONSOCIAL = "40020851"
    '    v_IDUSUARIO_RESPONSABLE = 150
    '    'v_IDESTADO_DOCUMENTO = 35
    '    v_idUnidad_Agencia = dtoUSUARIOS.m_idciudad

    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTA_ENTREGAS_RECOJOS", 26, v_IDCONTROL, 1, v_IDTIPO_OPERACION, 2, v_IDATENDIDO, 1, v_FECHA_INICIO, 2, v_FECHA_FIN, 2, v_NRO_MOVIL, 2, v_NRO_SOLICITUD, 2, v_RUC_RAZONSOCIAL, 2, v_IDUSUARIO_RESPONSABLE, 1, v_IDESTADO_DOCUMENTO, 1, v_idUnidad_Agencia, 1, v_idProcedencia, 1}
    '    Try
    '        cur_datos = Nothing
    '        cur_datos = New ADODB.Recordset
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        'Dim varSP_OBJECT() As Object = {"select t_agencias.idagencias,t_agencias.nombre_agencia from t_agencias where t_agencias.idestado_registro=1", 1}
    '        'cur_datos = New ADODB.Recordset
    '        'cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return False
    'End Function
    Public Function fnLISTA_ENTREGAS_RECOJOS() As Boolean
        Dim flat As Boolean = False
        Try
            '
            v_IDCONTROL = 1
            v_IDTIPO_OPERACION = 1
            v_IDATENDIDO = 1
            v_NRO_MOVIL = "LIM10001"
            v_NRO_SOLICITUD = "124"
            v_IDUSUARIO_RESPONSABLE = 150
            v_idUnidad_Agencia = dtoUSUARIOS.m_idciudad
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTA_ENTREGAS_RECOJOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDCONTROL", v_IDCONTROL, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_IDTIPO_OPERACION", v_IDTIPO_OPERACION, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDATENDIDO", v_IDATENDIDO, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_FECHA_INICIO", v_FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_FIN", v_FECHA_FIN, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_MOVIL", v_NRO_MOVIL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_SOLICITUD", v_NRO_SOLICITUD, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_RUC_RAZONSOCIAL", v_RUC_RAZONSOCIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUSUARIO_RESPONSABLE", v_IDUSUARIO_RESPONSABLE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDESTADO_DOCUMENTO", v_IDESTADO_DOCUMENTO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idUnidad_Agencia", v_idUnidad_Agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idUnidad_Procedencia", v_idProcedencia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            flat = True
            '
            dt_cur_datos = Nothing
            dt_cur_datos = New DataTable
            ' 
            dt_cur_datos = ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnSP_DISTRITOS_RUTAS_2009(ByVal idRuta_Entrega As Integer) As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_DISTRITOS_RUTAS", 6, idRuta_Entrega, 1, dtoUSUARIOS.m_idciudad, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    'Public Function fnLISTA_ENTREGAS_RECOJO_2009() As Boolean
    '    Dim flat As Boolean = True

    '    'v_IDUSUARIO_RESPONSABLE = 901
    '    'v_FECHA_INICIO = "21/03/2007"
    '    'v_FECHA_FIN = "21/03/2007"

    '    v_IDTIPO_OPERACION = 1
    '    v_IDATENDIDO = 0
    '    v_idEstado_Envio = 47

    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.RPT_LISTA_ENTREGAS_RECOJO", 16,v_IDUSUARIO_RESPONSABLE, 1, v_FECHA_INICIO, 2, v_FECHA_FIN, 2, Int(v_IDTIPO_OPERACION), 1,v_IDATENDIDO, 1, v_idEstado_Envio, 1, dtoUSUARIOS.IdLogin, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnLISTA_ENTREGAS_RECOJO() As Boolean
        Dim flat As Boolean = False
        '
        'v_IDTIPO_OPERACION = 1
        'v_IDATENDIDO = 0
        'v_idEstado_Envio = 47
        '
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.RPT_LISTA_ENTREGAS_RECOJO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input - solo usa los 3 primeros parametros 
            db_bd.AsignarParametro("v_idPersona_Responsable", v_IDUSUARIO_RESPONSABLE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_fecha_Inicio", v_FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_Final", v_FECHA_FIN, OracleClient.OracleType.VarChar)
            '''''''''''''''''''''''''''
            db_bd.AsignarParametro("v_tipo_Operacion", Int(v_IDTIPO_OPERACION), OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Atendido", v_IDATENDIDO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idEstado_Envio", v_idEstado_Envio, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idLogin", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dt_cur_datos = Nothing
            dt_cur_datos = New DataTable
            ' 
            dt_cur_datos = ldt_tmp
            flat = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnSP_LISTA_GUIAS_ENVIO_2009(ByVal idControl As Integer, ByVal Codigo_Solicitud As String) As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTA_GUIAS_ENVIO", 6, idControl, 1, Codigo_Solicitud, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_LISTA_GUIAS_ENVIO(ByVal idControl As Integer, ByVal Codigo_Solicitud As String) As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTA_GUIAS_ENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", idControl, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("codigoSolicitud", Codigo_Solicitud, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dt_cur_datos = Nothing
            dt_cur_datos = New DataTable
            ' 
            dt_cur_datos = ldt_tmp
            flat = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnSP_LISTAFUNCIONARIO_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOPERSONA.SP_LISTAFUNCIONARIO", 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function

    Public Sub fnRegistrarEstado(ByVal i As Integer)
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            If R_Observación = "" Then
                R_Observación = "NULL"
            End If
            '
            If R_CodigoMotNoAtencion = "999" Then
                R_CodigoMotNoAtencion = "NULL"
            End If
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_UPD_ENTREGA_CARGA2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("CodigoUsuario", R_CodigoUsuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("NumeroSolicitud", R_NumeroSolicitud, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("EstadoFinal", R_EstadoFinal, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("DniCliente", R_DniCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("NombreCliente", R_NombreCliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("Observacion", R_Observación, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("NumeroBultos", R_NumeroBultos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("CodigoMotNoAtencion", R_CodigoMotNoAtencion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("Fecha_Atencion", R_Fecha_Atencion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("hora_Atencion", R_hora_Atencion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("Direccion_Entrega", R_Direccion_Entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idagencia_reg", dtoUSUARIOS.iIDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_persona", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                'MsgBox(ldt_tmp.Rows(0).Item("MGSBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                'MsgBox(ldt_tmp.Rows(0).Item(0), MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Public Function fnBUSCAR_DATOS_SOLICITUD_2(ByVal idSolicitud As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dt As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_SOLICITUD_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idSolicitud", idSolicitud.ToString, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_consignado", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            Dim ds As DataSet = db_bd.EjecutarDataSet
            ldt_tmp = ds.Tables(0)
            '
            If ldt_tmp.Rows.Count > 0 Then
                x_Cliente = ldt_tmp.Rows(0).Item("razon_social")
                x_Consignado = ldt_tmp.Rows(0).Item("Consignado")
                x_NroDoc = ldt_tmp.Rows(0).Item("NroDoc")
                x_Fecha = ldt_tmp.Rows(0).Item("Fecha_Doc")
                x_Atendido = ldt_tmp.Rows(0).Item("Atendido")
                x_Cantidad = ldt_tmp.Rows(0).Item("Cantidad")
                x_NroSobres = ldt_tmp.Rows(0).Item("Sobres")
                x_Origen = ldt_tmp.Rows(0).Item("Origen")
                x_Destino = ldt_tmp.Rows(0).Item("Destino")
                x_Direccion = ldt_tmp.Rows(0).Item("Direccion")
                x_Hora_Entrega = ldt_tmp.Rows(0).Item("hora_entrega")
                x_DNI_Entrega = ldt_tmp.Rows(0).Item("DNI")
                x_Nombres_Entrega = ldt_tmp.Rows(0).Item("nombre_entrega")
                x_Responsable = ldt_tmp.Rows(0).Item("Responsable")
                x_Estado = ldt_tmp.Rows(0).Item("EstadoEnvio")
                x_Tipo_comprobante = ldt_tmp.Rows(0).Item("tipo_comprobante")
                x_Idmotivos_No_Atencion = ldt_tmp.Rows(0).Item("Idmotivos_No_Atencion")
                x_obs = ldt_tmp.Rows(0).Item("Obs")
                x_Idpersona_Recojo = ldt_tmp.Rows(0).Item("Idpersona_Recojo")

                'CambioR 17112011-------------------
                x_Idpersona = ldt_tmp.Rows(0).Item("IDPersona")
                x_idagencia_destino = ldt_tmp.Rows(0).Item("IDAgenciaDestino")
                x_idComprobante = ldt_tmp.Rows(0).Item("IDComprobante")
                x_Idtipo_Comprobante = ldt_tmp.Rows(0).Item("IDTipoComprobante")
                '---------------------------

                Return ds.Tables(1)
            Else
                MsgBox("No se encontro el documento en el reparto y/o recojo", MsgBoxStyle.Information, "Seguridad Sistema")
                'MsgBox("Revice sus datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListaConsignado(ByVal idSolicitud As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_ListaConsignado", CommandType.StoredProcedure)
            db.AsignarParametro("v_idSolicitud", idSolicitud.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_consignado", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
