Imports AccesoDatos
Public Class dtoSolicitudRecojoEntrega
    Public v_Control As Integer
    Public v_Idsolicitud_Recojo_Carga As String
    Public v_idPersona As String
    Public v_idAgencias As Integer
    Public v_Operador_Cliente As String
    Public v_idOperador_Cliente As String
    Public v_fecha_OPeracion As String
    Public v_idEstado_Carga As Integer
    Public v_idDireccion_Recojo As String
    Public v_Direccion_Recojo As String
    Public v_Referencia_Lugar As String
    Public v_idUnidad_Agencia As Integer
    Public v_idDistrito As String
    Public v_Hora_Incio As String
    Public v_Hora_Final As String
    Public v_Atemdido As String ', ---- A := Antendido  N := No Antendido
    Public v_Tipo_Operacion As String ' ---- R := Recojo E := Entrega
    Public v_Idunidad_Transporte As Integer
    Public v_idUsuario_Responsable As Integer
    Public v_IdPersonal_Recojo As Integer
    Public v_idTipo_Comprobante As Integer
    Public v_idComprobante As String
    '
    Public v_Peso_Recojo As Double
    Public v_Cantidad_Recojo As Integer
    Public v_Observacion As String
    Public v_Destino As String
    '
    'Public cur_datos As New ADODB.Recordset
    '*----------------------------------------------------------
    'Public cur_Cliente As New ADODB.Recordset
    'Public cur_Nombres_Remitente As New ADODB.Recordset
    'Public cur_Direccion_Remitente As New ADODB.Recordset
    'Public cur_Telefono_Remitente As New ADODB.Recordset
    '
    Public coll_Nombres_Remitente As New Collection
    Public coll_Direccion_Remitente As New Collection
#Region "Datatable"
    Public dt_cur_Cliente As New DataTable
    Public dt_cur_Nombres_Remitente As New DataTable
    Public dt_cur_Direccion_Remitente As New DataTable
    Public dt_cur_Telefono_Remitente As New DataTable
#End Region
    'Public Function fnSP_SOLICITUD_DATOS_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnSP_SOLICITUD_DATOS]" & dtoUSUARIOS.m_iIdAgencia.ToString)
    '        '            Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_SOLICITUD_DATOS", 44, v_Control, 1, v_Idsolicitud_Recojo_Carga, 2, v_idPersona, 2, v_idAgencias, 1, v_Operador_Cliente, 2, v_idOperador_Cliente, 2, v_fecha_OPeracion, 2, v_idEstado_Carga, 1, v_idDireccion_Recojo, 2, v_Direccion_Recojo, 2, v_Referencia_Lugar, 2, v_idUnidad_Agencia, 1, v_idDistrito, 2, v_Hora_Incio, 2, v_Hora_Final, 2, v_Atemdido, 2, v_Tipo_Operacion, 2, dtoUSUARIOS.IP, 2, v_IdPersonal_Recojo, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_SOLICITUD_DATOS_I", 52, v_Control, 1, v_Idsolicitud_Recojo_Carga, 2, v_idPersona, 2, v_idAgencias, 1, v_Operador_Cliente, 2, v_idOperador_Cliente, 2, v_fecha_OPeracion, 2, v_idEstado_Carga, 1, v_idDireccion_Recojo, 2, v_Direccion_Recojo, 2, v_Referencia_Lugar, 2, v_idUnidad_Agencia, 1, v_idDistrito, 2, v_Hora_Incio, 2, v_Hora_Final, 2, v_Atemdido, 2, v_Tipo_Operacion, 2, dtoUSUARIOS.IP, 2, v_IdPersonal_Recojo, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1, v_Peso_Recojo, 3, v_Cantidad_Recojo, 1, v_Observacion, 2, v_Destino, 2}

    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            flag = True
    '            MsgBox(cur_datos.Fields.Item("MSG").Value, MsgBoxStyle.Information, "Seguiradad Sistema")
    '        Else
    '            flag = False
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_AGENCIA_USUARIOS] " & ex.ToString)
    '    End Try
    '    Return flag
    'End Function
    Public Function fnSP_SOLICITUD_DATOS() As Boolean
        Dim flag As Boolean = False
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_SOLICITUD_DATOS_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_Control", v_Control, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_Idsolicitud_Recojo_Carga", v_Idsolicitud_Recojo_Carga, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idPersona", v_idPersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idAgencias", v_idAgencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Operador_Cliente", v_Operador_Cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idOperador_Cliente", v_idOperador_Cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_OPeracion", v_fecha_OPeracion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idEstado_Carga", v_idEstado_Carga, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDireccion_Recojo", v_idDireccion_Recojo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Direccion_Recojo", v_Direccion_Recojo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Referencia_Lugar", v_Referencia_Lugar, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idUnidad_Agencia", v_idUnidad_Agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDistrito", v_idDistrito, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Hora_Incio", v_Hora_Incio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Hora_Final", v_Hora_Final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Atemdido", v_Atemdido, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Tipo_Operacion", v_Tipo_Operacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdPersonal_Recojo", v_IdPersonal_Recojo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IdUsuario_personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idRol_Usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Peso_Recojo", v_Peso_Recojo, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Cantidad_Recojo", v_Cantidad_Recojo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Observacion", v_Observacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Destino", v_Destino, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
                MsgBox(lds_tmp.Tables(0).Rows(0).Item("MSG"), MsgBoxStyle.Information, "Seguiradad Sistema")
            Else
                flag = False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnSP_BUSCAR_DATOS_SILICITUD_2009(ByVal idSolicitud As String) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.fnSP_BUSCAR_DATOS_SILICITUD]" & dtoUSUARIOS.m_iIdAgencia.ToString)
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_SILICITUD", 4, idSolicitud, 2, dtoUSUARIOS.m_idciudad, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flag = False
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_AGENCIA_USUARIOS] " & ex.ToString)
    '    End Try

    '    Return flag
    'End Function
    '    Public Function fnBUSCAR_DATOS_CLIENTE_2009(ByVal iControl As Integer, ByVal cidPersona As String, ByVal idOrigen As Integer) As Boolean
    '        Dim flat As Boolean = False
    '        Try
    '            Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_CLIENTE", 14, iControl, 1, cidPersona, 2, idOrigen, 1}
    '            objLOG.fnLog("[dtoGuiaEnvio.SP_BUSCAR_DATOS_CLIENTE] " & fnLoagObj(varSP_OBJECT))
    '            cur_Cliente = Nothing
    '            cur_Nombres_Remitente = Nothing
    '            cur_Direccion_Remitente = Nothing
    '            cur_Telefono_Remitente = Nothing

    '            cur_Cliente = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '            If cur_Cliente.State = 1 Then
    '                If cur_Cliente.EOF = False And cur_Cliente.BOF = False Then
    '                    cur_Nombres_Remitente = cur_Cliente.NextRecordset
    '                    cur_Direccion_Remitente = cur_Cliente.NextRecordset
    '                    cur_Telefono_Remitente = cur_Cliente.NextRecordset
    '                    flat = True
    '                End If
    '            End If

    'SALIDA:
    '        Catch ex As Exception
    '            flat = False
    '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            objLOG.fnLogErr("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & ex.ToString)
    '        End Try
    '        Return flat
    '    End Function
    Public Function fnBUSCAR_DATOS_CLIENTE(ByVal iControl As Integer, ByVal cidPersona As String, ByVal idOrigen As Integer) As Boolean
        Dim flat As Boolean = False
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_CLIENTE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("cidPersona", cidPersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("idOrigen", idOrigen, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_Persoan", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_Nombres_Remitente", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Direccion_Remitente", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                dt_cur_Cliente = lds_tmp.Tables(0)
                dt_cur_Nombres_Remitente = lds_tmp.Tables(1)
                dt_cur_Direccion_Remitente = lds_tmp.Tables(2)
                ' dt_cur_Telefono_Remitente = lds_tmp.Tables(3) ' No recupera telefono  
                flat = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    '    Public Function fnASOCIACION_MOVIL_CARGA_2009() As Boolean
    '        Dim flat As Boolean = False
    '        Try
    '            v_Control = 1
    '            v_Idunidad_Transporte = 571
    '            v_idUsuario_Responsable = 660
    '            v_Idsolicitud_Recojo_Carga = 0
    '            'dtoUSUARIOS.IdLogin = 0
    '            'dtoUSUARIOS.m_idciudad = 0
    '            'dtoUSUARIOS.m_iIdAgencia = 0
    '            v_Atemdido = "N"
    '            v_Tipo_Operacion = "E"
    '            v_idTipo_Comprobante = 1
    '            v_idComprobante = 215
    '            v_idPersona = 1212

    '            Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_ASOCIACION_MOVIL_CARGA", 30, v_Control, 1, v_idPersona, 2, v_Idunidad_Transporte, 1, v_idUsuario_Responsable, 1, v_Idsolicitud_Recojo_Carga, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.m_idciudad, 1, dtoUSUARIOS.m_iIdAgencia, 1, v_Atemdido, 2, v_Tipo_Operacion, 2, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1, v_idTipo_Comprobante, 1, v_idComprobante, 2}
    '            cur_datos = Nothing
    '            cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '            If cur_datos.State = 1 Then
    '                If cur_datos.EOF = False And cur_datos.BOF = False Then
    '                    flat = True
    '                    MsgBox(cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                End If
    '            End If
    'SALIDA:
    '        Catch ex As Exception
    '            flat = False
    '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            objLOG.fnLogErr("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & ex.ToString)
    '        End Try

    '        Return flat
    '    End Function
    Public Sub fnClear()
        v_Control = 0
        v_Idsolicitud_Recojo_Carga = 0
        v_idPersona = 0
        v_idAgencias = dtoUSUARIOS.m_iIdAgencia
        v_Operador_Cliente = ""
        v_idOperador_Cliente = 0
        v_fecha_OPeracion = ""
        v_idEstado_Carga = 0
        v_idDireccion_Recojo = 0
        v_Direccion_Recojo = ""
        v_Referencia_Lugar = ""
        v_idUnidad_Agencia = 0
        v_idDistrito = 0
        v_Hora_Incio = ""
        v_Hora_Final = ""
        v_Atemdido = "" ', ---- A := Antendido  N := No Antendido
        v_Tipo_Operacion = "" ' ---- R := Recojo E := Entrega
        v_Idunidad_Transporte = 0
        v_idUsuario_Responsable = 0
    End Sub

    Sub HojaRutaEmision(inicio As String, fin As String, responsable As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOOPERACIONES_MOVILES.sp_actualiza_hora_hoja_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_responsable", responsable, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class
