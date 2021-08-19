Imports AccesoDatos
Public Class dtoFiltrosEntregaRecojos
    '------------Programacion
    Public v_idProgramacion_Recojo As String
    Public v_Nombre_Cliente_Llamada As String
    '
    Public v_Idcontacto_Persona As String
    Public v_Contacto_Persona As String
    Public v_Iddireccion_Consignado As String
    Public v_Direccion_Consignado As String
    Public v_Hora_Ini As String
    Public v_Hora_Fin As String
    Public v_Peso_Kg As Double
    Public v_Volumen As Double
    Public v_Nro_Paquetes As Integer
    Public v_Iddistrito As Integer
    Public v_Observacion As String
    Public v_idDia As Integer
    Public v_DESTINO As String
    '-----------------
    Public v_IDCONTROL As Integer
    Public v_IDRUTA As String
    '
    Public v_FECHA_INICIO As String
    Public v_FECHA_FIN As String
    Public v_NRO_MOVIL As String
    Public v_NRO_SOLICITUD As String
    Public v_IDUSUARIO_RESPONSABLE As Integer
    Public v_IDESTADO_DOCUMENTO As Integer
    Public v_idUnidad_Agencia As Integer
    Public col_sino As New Collection
    Public v_iCiudad As Integer
    Public v_IDPERSONA As String
    '
    Public v_DISTRITO As String
    Public v_DIA As String
    Public coll_Lista_Agencias As New Collection
    Public col_tipo_operacion As New Collection
    Public coll_Responsables As New Collection
    Public coll_Atendido As New Collection
    Public coll_Procedencia As New Collection
    Public coll_Tipo_OPeracion As New Collection
    Public coll_Lista_Estados As New Collection
    Public coll_Control_Agencias As New Collection
#Region "Dataset y datatable"
    Public ds_cur_datos As New DataSet
    'Public CUR_DATOS As New ADODB.Recordset
#End Region
    'Public Function fnLISTA_ENTREGAS_RECOJOS_2009() As ADODB.Recordset
    '    v_IDCONTROL = 1
    '    v_IDRUTA = 0
    '    v_Iddistrito = 0
    '    v_FECHA_INICIO = "03/03/2007"
    '    v_FECHA_FIN = "03/03/2007"
    '    v_NRO_MOVIL = "000"
    '    v_NRO_SOLICITUD = "000"
    '    v_IDUSUARIO_RESPONSABLE = 901
    '    v_IDESTADO_DOCUMENTO = 15
    '    v_idUnidad_Agencia = dtoUSUARIOS.m_idciudad

    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTA_ENTREGAS_RECOJOS", 22, v_IDCONTROL, 1, v_IDRUTA, 2, v_Iddistrito, 1, v_FECHA_INICIO, 2, v_FECHA_FIN, 2, v_NRO_MOVIL, 2, v_NRO_SOLICITUD, 2, v_IDUSUARIO_RESPONSABLE, 1, v_IDESTADO_DOCUMENTO, 1, v_idUnidad_Agencia, 1}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_BUSCAR_DATOS_CLIENTE] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[dtoGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    'Public Function fnLISTA_SINO_TIPO_2009() As Boolean
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO", 2}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_LISTA_SINO_TIPO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return False
    'End Function
    Public Function fnLISTA_SINO_TIPO() As Boolean
        Dim ls_flat As Boolean = True
        Try
            '
            ds_cur_datos = Nothing
            ds_cur_datos = New DataSet
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_SINO", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_TIPO_OPer", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            ds_cur_datos = lds_tmp
            ls_flat = False
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return ls_flat
    End Function
    'Public Function fnLISTA_SINO_TIPO_MOVIL_2009() As Boolean
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_ASOCIACION_MOVIL", 4, dtoUSUARIOS.m_idciudad, 1}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_LISTA_SINO_TIPO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return False
    'End Function
    Public Function fnLISTA_SINO_TIPO_MOVIL() As Boolean
        Try
            '
            ds_cur_datos = Nothing
            ds_cur_datos = New DataSet
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_ASOCIACION_MOVIL", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iCiudad", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_responsables", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Atendido", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Tipo_operacion", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Agencias", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            ds_cur_datos = lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return False
    End Function
    'Public Function fnLISTA_CODIGO_MOVIL_2009(ByVal v_idResponsable As Integer) As Boolean

    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTA_CODIGO_MOVIL", 4, v_idResponsable, 1}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_LISTA_SINO_TIPO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return False
    'End Function
    Public Function fnLISTA_CODIGO_MOVIL(ByVal v_idResponsable As Integer) As Boolean
        Try
            '            
            ds_cur_datos = Nothing
            ds_cur_datos = New DataSet
            '
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTA_CODIGO_MOVIL", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idResponsable", dtoUSUARIOS, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            ds_cur_datos = lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try        
        Return False
    End Function
    'Public Function fnSP_CONTROL_RECOJOS_2009() As Boolean
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_RECOJOS", 6, dtoUSUARIOS.m_idciudad, 1, dtoUSUARIOS.IdLogin, 1}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_LISTA_SINO_TIPO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return False
    'End Function
    Public Function fnSP_CONTROL_RECOJOS() As Boolean
        Try
            '            
            ds_cur_datos = Nothing
            ds_cur_datos = New DataSet
            '
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_RECOJOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iCiudad", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idUsuario_Personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Lista_Personas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Estados", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_responsables", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_SINO", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_TIPO_OPer", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Distritos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            ds_cur_datos = lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return False
    End Function
    'Public Function fnSP_LISTA_JEFE_AREAMOVIL_2009() As Integer
    '    Dim idJefe As Integer = 0
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTA_JEFE_AREAMOVIL", 4, dtoUSUARIOS.m_idciudad, 1}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_LISTA_SINO_TIPO] " & fnLoagObj(varSP_OBJECT))
    '        rst = Nothing
    '        rst = New ADODB.Recordset
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst.EOF = False And rst.BOF = False Then
    '            idJefe = rst.Fields.Item("idResponsable").Value
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return idJefe
    'End Function
    Public Function fnSP_LISTA_JEFE_AREAMOVIL() As Integer
        Dim idJefe As Integer = 0
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTA_JEFE_AREAMOVIL", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idCiudad", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                idJefe = ldt_tmp.Rows(0).Item("idResponsable")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return idJefe
    End Function
    'Public Function fnHORA_FORMATO24_2009() As String
    '    Dim strHora As String = Now
    '    Dim varSP_OBJECT() As Object = {"select to_char(sysdate,'HH:mi') Hora from dual", 2}
    '    Try
    '        objLOG.fnLog("[....fnHORA_FORMATO24] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If CUR_DATOS.EOF = False And CUR_DATOS.BOF = False Then
    '            strHora = CUR_DATOS.Fields.Item("Hora").Value
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return strHora
    'End Function
    Public Function fnHORA_FORMATO24() As String
        Dim db_bd As New BaseDatos
        Dim strHora As String = Now
        Try
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select PKG_GENERICO.sf_get_hora_servidor_F24 from dual"
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            ' No tiens 
            'Variables de salidas 
            'No existe parametros de salida 
            strHora = db_bd.EjecutarEscalar()
            '            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return strHora
    End Function
    'Public Function fnSP_CONTROL_RESPONSABLES_2009() As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_RESPONSABLES", 4, v_iCiudad, 1}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_LISTA_SINO_TIPO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_CONTROL_RESPONSABLES() As DataTable
        Dim ldt_tmp As New DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_RESPONSABLES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iCiudad", v_iCiudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_responsables", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return ldt_tmp
    End Function
    'Public Function fnSP_LISTAR_AGENCIAS_2009() As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_LISTAR_AGENCIAS", 2}
    '    Try
    '        objLOG.fnLog("[dtoGuiaEnvio.SP_LISTA_SINO_TIPO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_LISTAR_AGENCIAS() As DataTable
        Dim ldt_tmp As New DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_LISTAR_AGENCIAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return ldt_tmp
    End Function
    'Public Function fnSP_BUSCAR_DATOS_SILICITUD_2009(ByVal idSolicitudRecojo As String) As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_SILICITUD", 6, idSolicitudRecojo, 2, dtoUSUARIOS.m_idciudad, 1}
    '    Try
    '        objLOG.fnLog("[fnSP_BUSCAR_DATOS_SILICITUD] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_BUSCAR_DATOS_SILICITUD(ByVal idSolicitudRecojo As String) As DataSet
        Dim lds_tmp As New DataSet
        Try
            '            
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_BUSCAR_DATOS_SILICITUD", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idsolicitud_recojo_carga", idSolicitudRecojo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_iCiudad", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Responsables", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function
    'Public Function fnSP_REASIGNAR_RESPONSABLE_2009(ByVal idSolicitudRecojo As String, ByVal idNuevoResponsable As Integer) As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_REASIGNAR_RESPONSABLE", 12, idSolicitudRecojo, 2, idNuevoResponsable, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1}
    '    Try
    '        objLOG.fnLog("[fnSP_REASIGNAR_RESPONSABLE] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            MsgBox(CUR_DATOS.Fields.Item("v_MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_REASIGNAR_RESPONSABLE(ByVal idSolicitudRecojo As String, ByVal idNuevoResponsable As Integer)
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_REASIGNAR_RESPONSABLE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idsolicitud_recojo_carga", idSolicitudRecojo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idNuevoResponsable", idNuevoResponsable, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idUsuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idrol", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("v_MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnSP_RECOJO_PROGRAMADO_2009(ByVal idControl As Integer) As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_RECOJO_PROGRAMADO", 8, idControl, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.m_idciudad, 1}
    '    Try
    '        objLOG.fnLog("[fnSP_RECOJO_PROGRAMADO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_RECOJO_PROGRAMADO(ByVal idControl As Integer) As DataSet
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_RECOJO_PROGRAMADO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iCONTROL", idControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUSUARIO", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDCIUDAD", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_CIUDAD", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_DISTRITO", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_DIAS", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnSP_CLIENTE_FUNCIONARIO_2009(ByVal idFuncionario As Integer) As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_CLIENTE_FUNCIONARIO", 4, idFuncionario, 1}
    '    Try
    '        objLOG.fnLog("[fnSP_RECOJO_PROGRAMADO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[PKG_IVOOPERACIONES_MOVILES.SP_LISTA_SINO_TIPO] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_CLIENTE_FUNCIONARIO(ByVal idFuncionario As Integer) As DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 06-01-2014
            'db_bd.CrearComando("AA_TEST.SP_CLIENTE_FUNCIONARIO", CommandType.StoredProcedure)
            db_bd.CrearComando("AA_TEST.SP_CLIENTE_FUNCIONARIO_CARTERA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idFuncionario", idFuncionario, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_CLIENTES", OracleClient.OracleType.Cursor)
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
    'Public Function fnSP_CONTROL_CLIENTES_2009() As ADODB.Recordset

    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_CONTROL_CLIENTES", 6, v_IDPERSONA, 2, dtoUSUARIOS.m_idciudad, 1}
    '    Try
    '        objLOG.fnLog("[fnSP_CONTROL_CLIENTES] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_CONTROL_CLIENTES] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_CONTROL_CLIENTES() As DataSet
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_CONTROL_CLIENTES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCIUIDAD", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_DIRECCION_PERSONA", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_CONTACTO_PERSONA", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnSP_RECOJOS_PROGRAMADOS_2009(ByVal Fecha_Recojo As String) As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_RECOJOS_PROGRAMADOS", 8, dtoUSUARIOS.m_idciudad, 1, dtoUSUARIOS.IdLogin, 1, Fecha_Recojo, 2}
    '    Try
    '        objLOG.fnLog("[fnSP_RECOJOS_PROGRAMADOS] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_RECOJOS_PROGRAMADOS] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_RECOJOS_PROGRAMADOS(ByVal Fecha_Recojo As String) As DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_RECOJOS_PROGRAMADOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDCIUDAD", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("V_IDRESPONSABLE", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_FECHA", Fecha_Recojo, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_RECOJO_PROGRAMADO", OracleClient.OracleType.Cursor)
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
    'Public Function fnSP_ASOCIACION_RECOJO_2009(ByVal idProgramacion_Recojo As String) As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_ASOCIACION_RECOJO", 10, idProgramacion_Recojo, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1}
    '    Try
    '        objLOG.fnLog("[fnSP_RECOJOS_PROGRAMADOS] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_ASOCIACION_RECOJO] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_ASOCIACION_RECOJO(ByVal idProgramacion_Recojo As String) As DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_ASOCIACION_RECOJO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDPROGRAMACION", idProgramacion_Recojo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDRESPONSABLE", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idRol", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
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
    'Public Function fnSP_INSUPD_RECOJOS_2009(ByVal x_iControl As Integer) As Boolean
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_INSUPD_RECOJOS", 42, x_iControl, 1, v_idProgramacion_Recojo, 2, v_Nombre_Cliente_Llamada, 2, v_IDPERSONA, 2, v_Idcontacto_Persona, 2, v_Contacto_Persona, 2, v_Iddireccion_Consignado, 2, v_Direccion_Consignado, 2, v_Hora_Ini, 2, v_Hora_Fin, 2, v_Peso_Kg, 3, v_Volumen, 3, v_Nro_Paquetes, 1, v_Iddistrito, 1, v_Observacion, 2, dtoUSUARIOS.m_idciudad, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1, v_idDia, 1}
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[fnSP_RECOJOS_PROGRAMADOS] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            MsgBox(CUR_DATOS.Fields.Item("msgbox").Value.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
    '            flag = IIf(CUR_DATOS.Fields.Item("CONTROL").Value = 0, True, False)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_ASOCIACION_RECOJO] " & ex.ToString)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnSP_INSUPD_RECOJOS_I_2009(ByVal x_iControl As Integer) As Boolean
    '    'Dim varSP_OBJECT() As Object = {"AA_TEST.SP_INSUPD_RECOJOS", 42, x_iControl, 1, v_idProgramacion_Recojo, 2, v_Nombre_Cliente_Llamada, 2, v_IDPERSONA, 2, v_Idcontacto_Persona, 2, v_Contacto_Persona, 2, v_Iddireccion_Consignado, 2, v_Direccion_Consignado, 2, v_Hora_Ini, 2, v_Hora_Fin, 2, v_Peso_Kg, 3, v_Volumen, 3, v_Nro_Paquetes, 1, v_Iddistrito, 1, v_Observacion, 2, dtoUSUARIOS.m_idciudad, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1, v_idDia, 1}
    '    'Dim varSP_OBJECT() As Object = {"AA_TEST.SP_INSUPD_RECOJOS_I", 22, x_iControl, 1, v_idProgramacion_Recojo, 2, v_Nombre_Cliente_Llamada, 2, v_IDPERSONA, 2, v_Idcontacto_Persona, 2, v_Contacto_Persona, 2, v_Iddireccion_Consignado, 2, v_Direccion_Consignado, 2, v_Hora_Ini, 2, v_Hora_Fin, 2} ', v_Peso_Kg, 3, v_Volumen, 3, v_Nro_Paquetes, 1, v_Iddistrito, 1, v_Observacion, 2, dtoUSUARIOS.m_idciudad, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1, v_idDia, 1}
    '    'Dim varSP_OBJECT() As Object = {"AA_TEST.SP_INSUPD_RECOJOS_I", 4, x_iControl, 1}
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_INSUPD_RECOJOS_I", 42, x_iControl, 1, v_idProgramacion_Recojo, 2, v_Nombre_Cliente_Llamada, 2, v_IDPERSONA, 2, v_Idcontacto_Persona, 2, v_Contacto_Persona, 2, v_Iddireccion_Consignado, 2, v_Direccion_Consignado, 2, v_Hora_Ini, 2, v_Hora_Fin, 2, v_Peso_Kg, 3, v_Volumen, 3, v_Nro_Paquetes, 1, v_Iddistrito, 1, v_Observacion, 2, dtoUSUARIOS.m_idciudad, 1, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1, v_idDia, 1}
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[fnSP_RECOJOS_PROGRAMADOS] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            MsgBox(CUR_DATOS.Fields.Item("msgbox").Value.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
    '            flag = IIf(CUR_DATOS.Fields.Item("CONTROL").Value = 0, True, False)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_ASOCIACION_RECOJO] " & ex.ToString)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnSP_INSUPD_RECOJOS_I(ByVal x_iControl As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_INSUPD_RECOJOS_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", x_iControl, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_idProgramacion_Recojo", v_idProgramacion_Recojo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Nombre_Cliente_Llamada", v_Nombre_Cliente_Llamada, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Idpersona", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Idcontacto_Persona", v_Idcontacto_Persona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Contacto_Persona", v_Contacto_Persona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Iddireccion_Consignado", v_Iddireccion_Consignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Direccion_Consignado", v_Direccion_Consignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Hora_Ini", v_Hora_Ini, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Hora_Fin", v_Hora_Fin, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Peso_Kg", v_Peso_Kg, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Volumen", v_Volumen, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_Nro_Paquetes", v_Volumen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Iddistrito", v_Iddistrito, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Observacion", v_Observacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Idunidad_Agencia", dtoUSUARIOS.m_idciudad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idUsuario_Personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idRol", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDia", v_idDia, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable

            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("msgbox").ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
                flag = IIf(ldt_tmp.Rows(0).Item("CONTROL") = 0, True, False)
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnSP_ELIMINACION_REGISTRO_2009(ByVal x_ID As String) As Boolean
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_ELIMINACION_REGISTRO", 10, x_ID, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IP, 2}
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[SP_ELIMINACION_REGISTRO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            MsgBox(CUR_DATOS.Fields.Item("MSGBOX").Value.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
    '            'flag = IIf(CUR_DATOS.Fields.Item("CONTROL").Value = 0, True, False)
    '            flag = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_ELIMINACION_REGISTRO] " & ex.ToString)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnSP_ELIMINACION_REGISTRO(ByVal x_ID As String) As Boolean
        Dim flag As Boolean = False
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_ELIMINACION_REGISTRO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idProgracion_Recvojo", x_ID, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdUsuario_Personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idRol_Usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("MSGBOX").ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
                flag = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnSP_LISTAR_UPDATE_RECOJO_2009(ByVal x_ID As String) As Boolean
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_LISTAR_UPDATE_RECOJO", 4, x_ID, 2}
    '    Dim flag As Boolean = False
    '    Try
    '        objLOG.fnLog("[SP_LISTAR_UPDATE_RECOJO] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then

    '            v_idProgramacion_Recojo = CUR_DATOS.Fields.Item("idprogramacion_recojos").Value
    '            v_Nombre_Cliente_Llamada = CUR_DATOS.Fields.Item("Contacto").Value
    '            v_Idcontacto_Persona = CUR_DATOS.Fields.Item("idcontacto_persona").Value
    '            v_Contacto_Persona = CUR_DATOS.Fields.Item("Contacto").Value

    '            v_Iddireccion_Consignado = CUR_DATOS.Fields.Item("Iddireccion_Consignado").Value
    '            v_Direccion_Consignado = CUR_DATOS.Fields.Item("Direccion").Value
    '            v_Hora_Ini = CUR_DATOS.Fields.Item("Hora_Ini").Value
    '            v_Hora_Fin = CUR_DATOS.Fields.Item("Hora_Fin").Value

    '            v_Peso_Kg = CUR_DATOS.Fields.Item("peso_kg").Value
    '            v_Volumen = CUR_DATOS.Fields.Item("volumen").Value
    '            v_Nro_Paquetes = CUR_DATOS.Fields.Item("nro_paquetes").Value
    '            v_Iddistrito = CUR_DATOS.Fields.Item("Iddistrito").Value

    '            v_Observacion = CUR_DATOS.Fields.Item("observacion").Value
    '            v_idDia = CUR_DATOS.Fields.Item("Iddias_Semana").Value
    '            v_DESTINO = CUR_DATOS.Fields.Item("destino").Value
    '            v_DISTRITO = CUR_DATOS.Fields.Item("Dsitrito").Value
    '            v_DIA = CUR_DATOS.Fields.Item("Dia_Semana").Value
    '            flag = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_LISTAR_UPDATE_RECOJO] " & ex.ToString)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnSP_LISTAR_UPDATE_RECOJO(ByVal x_ID As String) As Boolean
        Dim flag As Boolean = False
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_LISTAR_UPDATE_RECOJO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idprogramacion_recojos", x_ID, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                v_idProgramacion_Recojo = ldt_tmp.Rows(0).Item("idprogramacion_recojos")
                v_Nombre_Cliente_Llamada = ldt_tmp.Rows(0).Item("Contacto")
                v_Idcontacto_Persona = ldt_tmp.Rows(0).Item("idcontacto_persona")
                v_Contacto_Persona = ldt_tmp.Rows(0).Item("Contacto")
                v_Iddireccion_Consignado = ldt_tmp.Rows(0).Item("Iddireccion_Consignado")
                v_Direccion_Consignado = ldt_tmp.Rows(0).Item("Direccion")
                v_Hora_Ini = ldt_tmp.Rows(0).Item("Hora_Ini")
                v_Hora_Fin = ldt_tmp.Rows(0).Item("Hora_Fin")
                v_Peso_Kg = ldt_tmp.Rows(0).Item("peso_kg")
                v_Volumen = ldt_tmp.Rows(0).Item("volumen")
                v_Nro_Paquetes = ldt_tmp.Rows(0).Item("nro_paquetes")
                v_Iddistrito = ldt_tmp.Rows(0).Item("Iddistrito")
                v_Observacion = ldt_tmp.Rows(0).Item("observacion")
                v_idDia = ldt_tmp.Rows(0).Item("Iddias_Semana")
                v_DESTINO = ldt_tmp.Rows(0).Item("destino")
                v_DISTRITO = ldt_tmp.Rows(0).Item("Dsitrito")
                v_DIA = ldt_tmp.Rows(0).Item("Dia_Semana")
                flag = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnSP_LISTA_RECOJOS_PATRON_2009() As ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"AA_TEST.SP_LISTA_RECOJOS_PATRON", 4, v_IDPERSONA, 2}
    '    Try
    '        objLOG.fnLog("[SP_LISTA_RECOJOS_PATRON] " & fnLoagObj(varSP_OBJECT))
    '        CUR_DATOS = Nothing
    '        CUR_DATOS = New ADODB.Recordset
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        objLOG.fnLogErr("[AA_TEST.SP_LISTA_RECOJOS_PATRON] " & ex.ToString)
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_LISTA_RECOJOS_PATRON() As DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_LISTA_RECOJOS_PATRON", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
