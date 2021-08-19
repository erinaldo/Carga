Imports AccesoDatos
Public Class dtoventapasaje
#Region "RECORDSET"
    ' Load 
    'Public rst_documento As New ADODB.Recordset
    Public rst_documento As DataTable

    'Public rst_condicion As New ADODB.Recordset
    Public rst_condicion As DataTable

    'Public rst_unidad_agencia As New ADODB.Recordset
    Public rst_unidad_agencia As DataTable

    'Public rst_agencias As New ADODB.Recordset
    Public rst_agencias As DataTable

    'Public rst_Lista_Unidades_Agencia As New ADODB.Recordset
    Public rst_Lista_Unidades_Agencia As DataTable

    'Public rstvtapasaje As New ADODB.Recordset
    Public rstvtapasaje As DataTable

    'Public rst_Lista_Usuarios As New ADODB.Recordset
    Public rst_Lista_Usuarios As DataTable

    'Public rst_edtventa_pasaje As New ADODB.Recordset
    Public rst_edtventa_pasaje As DataTable

    'Public rst_elimina_pasaje As New ADODB.Recordset
    Public rst_elimina_pasaje As DataTable

    'Public rst_tarjeta As New ADODB.Recordset
    Public rst_tarjeta As DataTable

    'Public rst_forma_pago As New ADODB.Recordset
    Public rst_forma_pago As DataTable

    'Public rst_valida_comprobante As New ADODB.Recordset
    Public rst_valida_comprobante As DataTable

    'Public rst_cambio_usuario As New ADODB.Recordset
    Public rst_cambio_usuario As DataTable

    '08/03/2008 Recupera el codigo de la agencia 
    'Public rst_codigo_cuenta_corriente As New ADODB.Recordset
    Public rst_codigo_cuenta_corriente As DataTable

    ' Filtro del cliente 
    'Public rst_recupera_cliente As New ADODB.Recordset
    Public rst_recupera_cliente As DataTable

    'Public rst_recupera_cliente_ruc As New ADODB.Recordset
    Public rst_recupera_cliente_ruc As DataTable

    'Recupera Documentos 

    'Public rst_NroDocumentos As New ADODB.Recordset
    Public rst_NroDocumentos As DataTable

    Public rstMensaje As DataTable

    Public Serie As String = ""
    Public NroDoc As String = ""
    ' Recupera el id de la venta de pasaje, se recomienda en string    
    Public sidventa_pasajes As String
    '
    Public iidtarjetas As Integer
    Public iidagencias_venta As Integer
    Public iidagencias_origen As Integer
    Public iIDAGENCIAS_DESTINO As Integer
    Public sNU_DOCU_SUNAT As String
    ' Id y Nombre de la persona (T_persona) 
    Public lidpersona As Long
    Public snombre_pasajero As String
    Public stelefono As String
    ' Id y Nombre de la empresa (T_persona) 
    Public snombre_empresa As String
    Public lidpersona_ruc As Long
    Public stelefono_ruc As String
    ' Variables para grabar 
    'Public rst_mensaje_oracle As ADODB.Recordset
    Public rst_mensaje_oracle As DataTable
    '
    Public icontrolbusqueda As Integer
    Public icontrol As Integer
    Public sidpersona_dni As String
    Public sapellidos_nombre_dni As String
    Public snrodctoidentidad_dni As String
    Public lidtipo_comprobante As Long
    Public sserie_comprobante As String
    Public snro_comprobante As String
    Public lidcondicion_boleto As Integer ' Long
    Public sidpersona_empresa As String
    Public srazon_social As String
    Public sruc As String
    Public sserie_comprobante_ref As String
    Public snro_comprobante_ref As String
    Public lidforma_pago As Integer 'Long
    Public lidtipo_moneda As Integer 'Long
    Public d_igv As Double
    Public d_tot_igv As Double   ' --- 3
    Public lidtipo_operacion As Integer 'Long
    Public lnro_asiento As Integer 'Long
    Public dmonto_base As Double
    Public dmonto_penalidad As Double
    Public dmonto_descuento As Double
    Public dmonto_recargo As Double
    Public dmonto_total As Double
    Public dporc_descuento As Double
    Public lidunidad_agencia_ori As Integer 'Long
    Public lidunidad_agencia_des As Integer 'Long
    Public liestado_registro As Integer 'Long
    Public sip As String
    Public sfecha_emision As String
    Public sfecha_viaje As String
    Public shora_salida As String
    Public smemo As String
    Public lidusuario_personal As Integer 'Long
    Public lidrol_usuario As Integer ' Long 
    Public ledad As Integer
    Public scodigo_cuenta As String
    Public sfecha_inicio As String
    Public sfecha_final As String
    Public srazon_social_cta As String
    '
    Public lidusuario_personal_mod As Integer
#End Region
#Region "Recupera Datos"
    Public sidventa_pasaje As String
    Public lidventa_pasajes As Long
    Public lidtipo_comprobante1 As Long
    Public sserie_comprobante1 As String
    Public snro_comprobante1 As String
    Public sserie_comprobante_ref1 As String
    Public snro_comprobante_ref1 As String
    Public lidunidad_agencia_origen As Long
    Public sorigen As String
    Public lidunidad_agencia_destino As Long
    Public sdestino As String
    Public lidagencia_origen1 As Long
    Public lidagencia_destino1 As Long
    Public lidcondicion_boleto1 As Long
    Public sfecha_emision1 As String
    Public sidpersona_cuenta As String
    Public lidpersona1 As Long
    Public sdni1 As String
    Public spasajero As String
    Public ledad1 As Long  'Es lo uno u otro (fecha nacimiento) 
    Public sfecha_nacimiento As String
    Public lidpersona_empresa1 As Long
    Public sruc1 As String
    Public srazon_social1 As String
    Public sfecha_viaje1 As String
    Public shora_salida1 As String
    Public lnro_asiento1 As Long
    Public dporc_descuento1 As Double
    Public smemo1 As String
    Public dmonto_total1 As Double
    Public scodigo_cuenta1 As String
    Public srazon_social_cta1 As String
    Public ll_es_fecha_abierta As Long
#End Region
#Region "COLLECTION"
    Public coll_documento As New Collection
    Public coll_condicion As New Collection
    Public coll_agencia As New Collection
    Public coll_Lista_Origen As New Collection
    Public coll_Lista_Destino As New Collection
    Public coll_Lista_Usuarios As New Collection
    Public coll_Lista_Agencias As New Collection
#End Region
    '
#Region "METODOS VENTA DE PASAJE"
    'Ref:
    'Define la lista inicial del formulario control...(frm...)
    'Public Function fnLISTA_INICIAL_VENTAPASAJE2009() As Boolean
    'Dim flat As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOVENTA_PASAJE.sp_lista_vtapasaje", 2}
    '    rst_documento = Nothing
    '    rst_condicion = Nothing
    '    rst_agencias = Nothing
    '    rst_tarjeta = Nothing
    '    rst_documento = Nothing
    '    rst_documento = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_documento.EOF = False And rst_documento.BOF = False Then
    '        rst_condicion = rst_documento.NextRecordset
    '        rst_unidad_agencia = rst_documento.NextRecordset
    '        rst_agencias = rst_documento.NextRecordset
    '        rst_tarjeta = rst_documento.NextRecordset
    '        rst_forma_pago = rst_documento.NextRecordset
    '    End If
    '    flat = True
    'Catch ex As Exception
    '    flat = False
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    objLOG.fnLogErr("[dtoventapasaje.fnLISTA_INICIAL_VENTAPASAJE] " & ex.ToString)
    'End Try
    'Return flat
    'End Function

    Public Function fnLISTA_INICIAL_VENTAPASAJE() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_lista_vtapasaje", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_documento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_condicion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_unidad_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_tarjeta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_forma_pago", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_documento = ds.Tables(0)
            If rst_documento.Rows.Count > 0 Then
                rst_condicion = ds.Tables(1)
                rst_unidad_agencia = ds.Tables(2)
                rst_agencias = ds.Tables(3)
                rst_tarjeta = ds.Tables(4)
                rst_forma_pago = ds.Tables(5)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnGetunidadagencia2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    'Dim rst_unidad_agencia_tmp As New ADODB.Recordset
    'Try
    '    Dim SQLQUERY As Object() = {"PKG_IVOVENTA_PASAJE.sp_get_descunidad_agencia", 4, idUnidadAge, 1}
    '    rst_unidad_agencia_tmp = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return rst_unidad_agencia_tmp
    'End Function

    Public Function fnGetunidadagencia(ByVal idUnidadAge As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_get_descunidad_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("iidunidad_agencia", idUnidadAge, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_unidada_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnGetAgencias2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    'Try
    '    Dim SQLQUERY As Object() = {"PKG_IVOVENTA_PASAJE.sp_lista_agencia", 4, idUnidadAge, 1}
    '    rst_agencias = Nothing
    '    rst_agencias = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return rst_agencias
    'End Function
    Public Function fnGetAgencias(ByVal idUnidadAge As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_lista_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("v_idUnidadAgencia", idUnidadAge, OracleClient.OracleType.Number)
            db.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_agencias = db.EjecutarDataTable
            Return rst_agencias
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function fnGetAgencias() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.SP_GET_AGENCIA", CommandType.StoredProcedure)
            'pyme
            'db.CrearComando("PKG_GENERICO.SP_GET_AGENCIA_1", CommandType.StoredProcedure)
            db.AsignarParametro("cur_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnLISTA_AGENCIAS_UNIDADES2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_LISTA_AGENCIAS_UNIDADES", 2}
    '    rst_Lista_Unidades_Agencia = Nothing
    '    rst_Lista_Unidades_Agencia = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_Lista_Unidades_Agencia.EOF = False And rst_Lista_Unidades_Agencia.EOF = False Then
    '        flag = True
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return flag
    'End Function

    Public Function fnLISTA_AGENCIAS_UNIDADES() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUUTILS.SP_LISTA_AGENCIAS_UNIDADES", CommandType.StoredProcedure)
            db.AsignarParametro("cur_LISTA_AGENCIAS_UNIDADES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_Lista_Unidades_Agencia = db.EjecutarDataTable
            If rst_Lista_Unidades_Agencia.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnFILTRO_USUARIO_X_AGENCIA2009(ByVal idAgencia As Integer) As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOVENTA_PASAJE.SP_FILTRO_USUARIO_X_AGENCIA", 4, idAgencia, 1}
    '    rst_Lista_Usuarios = Nothing
    '    rst_Lista_Usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_Lista_Usuarios.EOF = False And rst_Lista_Usuarios.EOF = False Then
    '        flag = True
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fnFILTRO_USUARIO_X_AGENCIA(ByVal idAgencia As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21-04-2010
            'db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_USUARIO_X_AGENCIA", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_USUARIO_X_AGENCIA_1", CommandType.StoredProcedure)
            db.AsignarParametro("idAgencia", idAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_Lista_Usuarios = db.EjecutarDataTable
            If rst_Lista_Usuarios.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnFILTRO_USUARIO_X_AGENCIA(ByVal idAgencia As Integer, inicio As String, fin As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21-04-2010
            'db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_USUARIO_X_AGENCIA", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_USUARIO_X_AGENCIA_1", CommandType.StoredProcedure)
            db.AsignarParametro("idAgencia", idAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_Lista_Usuarios = db.EjecutarDataTable
            If rst_Lista_Usuarios.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnNroDocumento2009(ByVal idDocumento As Integer) As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim SQLQuery As Object() = {"select t_Control_Comprobantes.Serie,t_Control_Comprobantes.Nro_Documento from  t_Control_Comprobantes where t_Control_Comprobantes.Ip='" & dtoUSUARIOS.IP & "' and t_Control_Comprobantes.Idtipo_Comprobante= " & idDocumento.ToString & "  and t_Control_Comprobantes.Idagencias=" & dtoUSUARIOS.m_iIdAgencia.ToString & " and t_Control_Comprobantes.Idestado_Registro=1", 2}
    '    rst_NroDocumentos = Nothing
    '    rst_NroDocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If rst_NroDocumentos.State = 1 Then
    '        If rst_NroDocumentos.EOF = False And rst_NroDocumentos.BOF = False Then
    '            Serie = rst_NroDocumentos.Fields.Item(0).Value.ToString
    '            NroDoc = rst_NroDocumentos.Fields.Item(1).Value.ToString
    '            If idDocumento = 3 Then
    '                NroDoc = fnGeneraDigitoChequeo(NroDoc)
    '            End If
    '            flag = True
    '        End If
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fnNroDocumento(ByVal idDocumento As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.sp_get_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comprobante", idDocumento.ToString, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idagencias", dtoUSUARIOS.m_iIdAgencia.ToString, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_NroDocumentos = db.EjecutarDataTable
            If rst_NroDocumentos.Rows.Count > 0 Then
                Serie = rst_NroDocumentos.Rows(0).Item(0).ToString
                NroDoc = rst_NroDocumentos.Rows(0).Item(1).ToString
                If idDocumento = 3 Then
                    NroDoc = fnGeneraDigitoChequeo(NroDoc)
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnLISTA_GET_CLIENTE2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOVENTA_PASAJE.sp_get_cliente", 4, sNU_DOCU_SUNAT, 2}
    '    ' Dim SQLQuery As Object() = {" select nvl(t_persona.idpersona,0) idpersona, nvl(t_persona.razon_social,'***') razon_social from  t_persona where t_persona.nu_docu_suna = '" + sNU_DOCU_SUNAT + "'", 2}

    '    ' Sirve para graba en un Log
    '    '' objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_TARIFA_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & iIDUNIDAD_AGENCIA.ToString & "," & iIDUNIDAD_AGENCIA_DESTINO.ToString)
    '    rst_recupera_cliente = Nothing
    '    rst_recupera_cliente = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If rst_recupera_cliente.EOF = False And rst_recupera_cliente.BOF = False Then
    '        snombre_pasajero = rst_recupera_cliente.Fields.Item(1).Value
    '        lidpersona = CType(rst_recupera_cliente.Fields.Item(0).Value, Long)
    '        ' stelefono = rst_recupera_cliente.Fields.Item(2).Value 
    '        flag = True
    '    End If
    'Catch ex As Exception
    '    flag = False
    '    ' Comentado para el log 
    '    ' objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_valida_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & ex.ToString)
    'End Try
    'Return flag
    'End Function

    Public Function fnLISTA_GET_CLIENTE() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_get_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("vnu_docu_suna", sNU_DOCU_SUNAT, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_persona", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_recupera_cliente = db.EjecutarDataTable
            If rst_recupera_cliente.Rows.Count > 0 Then
                snombre_pasajero = rst_recupera_cliente.Rows(0).Item(1)
                lidpersona = CType(rst_recupera_cliente.Rows(0).Item(0), Long)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnLISTA_GET_CLIENTE_RUC2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOVENTA_PASAJE.sp_get_cliente_ruc", 4, sNU_DOCU_SUNAT, 2}
    '    ' Sirve para graba en un Log
    '    '' objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_TARIFA_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & iIDUNIDAD_AGENCIA.ToString & "," & iIDUNIDAD_AGENCIA_DESTINO.ToString)
    '    rst_recupera_cliente_ruc = Nothing
    '    rst_recupera_cliente_ruc = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If rst_recupera_cliente_ruc.EOF = False And rst_recupera_cliente_ruc.BOF = False Then
    '        snombre_empresa = rst_recupera_cliente_ruc.Fields.Item(1).Value
    '        lidpersona_ruc = CType(rst_recupera_cliente_ruc.Fields.Item(0).Value, Long)
    '        'stelefono_ruc = rst_recupera_cliente.Fields.Item(2).Value
    '        flag = True
    '    End If
    'Catch ex As Exception
    '    flag = False
    '    ' Comentado para el log 
    '    ' objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_valida_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & ex.ToString)
    'End Try
    'Return flag
    'End Function

    Public Function fnLISTA_GET_CLIENTE_RUC() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_get_cliente_ruc", CommandType.StoredProcedure)
            db.AsignarParametro("vnu_docu_suna", sNU_DOCU_SUNAT, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_ruc", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_recupera_cliente_ruc = db.EjecutarDataTable
            If rst_recupera_cliente_ruc.Rows.Count > 0 Then
                snombre_empresa = rst_recupera_cliente_ruc.Rows(0).Item(1)
                lidpersona_ruc = CType(rst_recupera_cliente_ruc.Rows(0).Item(0), Long)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnIncrementarNroDoc2009(ByVal idTipoComprobante As Integer)
    'Dim flag As Boolean = False
    'Dim rstnrodocumentos As New ADODB.Recordset
    'Try
    '    Dim SQLQuery As Object() = {"sp_INCREMENTAR_NRO_DOCUMENTO", 8, dtoUSUARIOS.IP, 2, dtoUSUARIOS.m_iIdAgencia, 1, idTipoComprobante, 1}
    '    'objLOG.fnLog("[sp_INCREMENTAR_NRO_DOCUMENTO] " & fnLoagObj(SQLQuery))
    '    rstnrodocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If rstnrodocumentos.State = 1 Then
    '        If rstnrodocumentos.EOF = False And rstnrodocumentos.BOF = False Then
    '            flag = True
    '        End If
    '    End If
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fnIncrementarNroDoc(ByVal idTipoComprobante As Integer) As Boolean
        Dim db As New BaseDatos
        Dim lds_tmp As New DataSet
        Dim flag As Boolean = False
        '
        Try
            db.Conectar()
            db.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDAGENCIAS", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_COMPROBANTE", idTipoComprobante, OracleClient.OracleType.Int32)
            '
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            '
            lds_tmp = db.EjecutarDataSet
            '
            If lds_tmp.Tables(1).Rows.Count > 0 Then
                If lds_tmp.Tables(1).Rows(0).Item(0) = 0 Then
                    flag = True
                End If
            End If
            '
            'If db.EjecutarComando = 1 Then
            '    Return True
            'Else
            '    Return False
            'End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
        Return flag
    End Function

    'Public Function fnControlpasaje2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.SP_FILTRO_PASAJE", 22, _
    '                                                                  icontrol, 1, _
    '                                                                  lidunidad_agencia_ori, 1, _
    '                                                                  lidunidad_agencia_des, 1, _
    '                                                                  lidusuario_personal, 1, _
    '                                                                  iidagencias_origen, 1, _
    '                                                                  Serie, 2, _
    '                                                                  NroDoc, 2, _
    '                                                                  sapellidos_nombre_dni, 2, _
    '                                                                  sfecha_inicio, 2, _
    '                                                                  sfecha_final, 2}
    '    rstvtapasaje = Nothing
    '    rstvtapasaje = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fnControlpasaje() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_PASAJE", CommandType.StoredProcedure)
            db.AsignarParametro("ncontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("norigen", lidunidad_agencia_ori, OracleClient.OracleType.Int32)
            db.AsignarParametro("ndestino", lidunidad_agencia_des, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidUsuario", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidagencia", iidagencias_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("vserie", Serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnrodoc", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("npasajero", sapellidos_nombre_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rstvtapasaje = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnEDIT_ventapasaje2009()
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOVENTA_PASAJE.sp_edit_ventapasaje", 4, sidventa_pasajes.ToString, 2}
    '    rst_edtventa_pasaje = Nothing
    '    rst_edtventa_pasaje = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_edtventa_pasaje.State = 1 Then
    '        lidventa_pasajes = CType(rst_edtventa_pasaje.Fields.Item("idventa_pasajes").Value, Long)
    '        lidtipo_comprobante1 = CType(rst_edtventa_pasaje.Fields.Item("idtipo_comprobante").Value, Long)
    '        sserie_comprobante1 = CType(rst_edtventa_pasaje.Fields.Item("serie_comprobante").Value, String)
    '        snro_comprobante1 = CType(rst_edtventa_pasaje.Fields.Item("nro_comprobante").Value, String)
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("serie_comprobante_ref").Value) = True Then
    '            sserie_comprobante_ref1 = ""
    '        Else
    '            sserie_comprobante_ref1 = CType(rst_edtventa_pasaje.Fields.Item("serie_comprobante_ref").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("nro_comprobante_ref").Value) = True Then
    '            snro_comprobante_ref1 = ""
    '        Else
    '            snro_comprobante_ref1 = CType(rst_edtventa_pasaje.Fields.Item("nro_comprobante_ref").Value, String)
    '        End If
    '        lidunidad_agencia_origen = CType(rst_edtventa_pasaje.Fields.Item("idunidad_agencia_origen").Value, Long)
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("origen").Value) = True Then
    '            sorigen = ""
    '        Else
    '            sorigen = CType(rst_edtventa_pasaje.Fields.Item("origen").Value, String)
    '        End If
    '        lidunidad_agencia_destino = CType(rst_edtventa_pasaje.Fields.Item("idunidad_agencia_destino").Value, Long)
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("destino").Value) = True Then
    '            sdestino = ""
    '        Else
    '            sdestino = CType(rst_edtventa_pasaje.Fields.Item("destino").Value, String)
    '        End If
    '        lidagencia_origen1 = CType(rst_edtventa_pasaje.Fields.Item("idagencia_origen").Value, Long)
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("idagencia_destino").Value) = True Then
    '            lidagencia_destino1 = -666
    '        Else
    '            lidagencia_destino1 = CType(rst_edtventa_pasaje.Fields.Item("idagencia_destino").Value, Long)
    '        End If
    '        '
    '        lidcondicion_boleto1 = CType(rst_edtventa_pasaje.Fields.Item("idcondicion_boleto").Value, Long)
    '        '
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("fecha_emision").Value) = True Then
    '            sfecha_emision1 = ""
    '        Else
    '            sfecha_emision1 = CType(rst_edtventa_pasaje.Fields.Item("fecha_emision").Value, String)
    '        End If
    '        '
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("idpersona_cuenta").Value) = True Then
    '            sidpersona_cuenta = ""
    '        Else
    '            sidpersona_cuenta = CType(rst_edtventa_pasaje.Fields.Item("idpersona_cuenta").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("idpersona").Value) = True Then
    '            lidpersona1 = -666
    '        Else
    '            lidpersona1 = CType(rst_edtventa_pasaje.Fields.Item("idpersona").Value, Long)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("nu_docu_suna").Value) = True Then
    '            sdni1 = ""
    '        Else
    '            sdni1 = CType(rst_edtventa_pasaje.Fields.Item("nu_docu_suna").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("datos_personales").Value) = True Then
    '            spasajero = ""
    '        Else
    '            spasajero = CType(rst_edtventa_pasaje.Fields.Item("datos_personales").Value, String)
    '        End If
    '        'Calculo de la edad 
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("edad").Value) = True Then
    '            ledad1 = -666
    '        Else
    '            ledad1 = CType(rst_edtventa_pasaje.Fields.Item("edad").Value, Long)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("idpersona_empresa").Value) = True Then
    '            lidpersona_empresa1 = -666
    '        Else
    '            lidpersona_empresa1 = CType(rst_edtventa_pasaje.Fields.Item("idpersona_empresa").Value, Long)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("ruc").Value) = True Then
    '            sruc1 = ""
    '        Else
    '            sruc1 = CType(rst_edtventa_pasaje.Fields.Item("ruc").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("razon_social").Value) = True Then
    '            srazon_social1 = ""
    '        Else
    '            srazon_social1 = CType(rst_edtventa_pasaje.Fields.Item("razon_social").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("fecha_viaje").Value) = True Then
    '            sfecha_viaje1 = ""
    '        Else
    '            sfecha_viaje1 = CType(rst_edtventa_pasaje.Fields.Item("fecha_viaje").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("hora_salida").Value) = True Then
    '            shora_salida1 = ""
    '        Else
    '            shora_salida1 = CType(rst_edtventa_pasaje.Fields.Item("hora_salida").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("nro_asiento").Value) = True Then
    '            lnro_asiento1 = -1
    '        Else
    '            lnro_asiento1 = CType(rst_edtventa_pasaje.Fields.Item("nro_asiento").Value, Long)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("porc_descuento").Value) = True Then
    '            dporc_descuento1 = -1
    '        Else
    '            dporc_descuento1 = CType(rst_edtventa_pasaje.Fields.Item("porc_descuento").Value, Double)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("memo").Value) = True Then
    '            smemo1 = ""
    '        Else
    '            smemo1 = CType(rst_edtventa_pasaje.Fields.Item("memo").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("monto_total").Value) = True Then
    '            dmonto_total1 = 0
    '        Else
    '            dmonto_total1 = CType(rst_edtventa_pasaje.Fields.Item("monto_total").Value, Double)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("idtarjetas").Value) = True Then
    '            iidtarjetas = -666
    '        Else
    '            iidtarjetas = CType(rst_edtventa_pasaje.Fields.Item("idtarjetas").Value, Long)
    '        End If
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("idforma_pago").Value) = True Then
    '            lidforma_pago = -666
    '        Else
    '            lidforma_pago = CType(rst_edtventa_pasaje.Fields.Item("idforma_pago").Value, Double)
    '        End If
    '        '
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("codigo_cuenta").Value) = True Then
    '            scodigo_cuenta1 = ""
    '        Else
    '            scodigo_cuenta1 = CType(rst_edtventa_pasaje.Fields.Item("codigo_cuenta").Value, String)
    '        End If
    '        '
    '        If IsDBNull(rst_edtventa_pasaje.Fields.Item("razon_social_cta").Value) = True Then
    '            srazon_social_cta1 = ""
    '        Else
    '            srazon_social_cta1 = CType(rst_edtventa_pasaje.Fields.Item("razon_social_cta").Value, String)
    '        End If
    '    End If
    '    ll_es_fecha_abierta = CType(rst_edtventa_pasaje.Fields.Item("es_fecha_abierta").Value, Long)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fnEDIT_ventapasaje() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_edit_ventapasaje", CommandType.StoredProcedure)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasajes.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_venta_pasaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_edtventa_pasaje = db.EjecutarDataTable
            If rst_edtventa_pasaje.Rows.Count > 0 Then
                lidventa_pasajes = CType(rst_edtventa_pasaje.Rows(0).Item("idventa_pasajes"), Long)
                lidtipo_comprobante1 = CType(rst_edtventa_pasaje.Rows(0).Item("idtipo_comprobante"), Long)
                sserie_comprobante1 = CType(rst_edtventa_pasaje.Rows(0).Item("serie_comprobante"), String)
                snro_comprobante1 = CType(rst_edtventa_pasaje.Rows(0).Item("nro_comprobante"), String)
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("serie_comprobante_ref")) = True Then
                    sserie_comprobante_ref1 = ""
                Else
                    sserie_comprobante_ref1 = CType(rst_edtventa_pasaje.Rows(0).Item("serie_comprobante_ref"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("nro_comprobante_ref")) = True Then
                    snro_comprobante_ref1 = ""
                Else
                    snro_comprobante_ref1 = CType(rst_edtventa_pasaje.Rows(0).Item("nro_comprobante_ref"), String)
                End If
                lidunidad_agencia_origen = CType(rst_edtventa_pasaje.Rows(0).Item("idunidad_agencia_origen"), Long)
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("origen")) = True Then
                    sorigen = ""
                Else
                    sorigen = CType(rst_edtventa_pasaje.Rows(0).Item("origen"), String)
                End If
                lidunidad_agencia_destino = CType(rst_edtventa_pasaje.Rows(0).Item("idunidad_agencia_destino"), Long)
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("destino")) = True Then
                    sdestino = ""
                Else
                    sdestino = CType(rst_edtventa_pasaje.Rows(0).Item("destino"), String)
                End If
                lidagencia_origen1 = CType(rst_edtventa_pasaje.Rows(0).Item("idagencia_origen"), Long)
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("idagencia_destino")) = True Then
                    lidagencia_destino1 = -666
                Else
                    lidagencia_destino1 = CType(rst_edtventa_pasaje.Rows(0).Item("idagencia_destino"), Long)
                End If
                '
                lidcondicion_boleto1 = CType(rst_edtventa_pasaje.Rows(0).Item("idcondicion_boleto"), Long)
                '
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("fecha_emision")) = True Then
                    sfecha_emision1 = ""
                Else
                    sfecha_emision1 = CType(rst_edtventa_pasaje.Rows(0).Item("fecha_emision"), String)
                End If
                '
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("idpersona_cuenta")) = True Then
                    sidpersona_cuenta = ""
                Else
                    sidpersona_cuenta = CType(rst_edtventa_pasaje.Rows(0).Item("idpersona_cuenta"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("idpersona")) = True Then
                    lidpersona1 = -666
                Else
                    lidpersona1 = CType(rst_edtventa_pasaje.Rows(0).Item("idpersona"), Long)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("nu_docu_suna")) = True Then
                    sdni1 = ""
                Else
                    sdni1 = CType(rst_edtventa_pasaje.Rows(0).Item("nu_docu_suna"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("datos_personales")) = True Then
                    spasajero = ""
                Else
                    spasajero = CType(rst_edtventa_pasaje.Rows(0).Item("datos_personales"), String)
                End If
                'Calculo de la edad 
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("edad")) = True Then
                    ledad1 = -666
                Else
                    ledad1 = CType(rst_edtventa_pasaje.Rows(0).Item("edad"), Long)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("idpersona_empresa")) = True Then
                    lidpersona_empresa1 = -666
                Else
                    lidpersona_empresa1 = CType(rst_edtventa_pasaje.Rows(0).Item("idpersona_empresa"), Long)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("ruc")) = True Then
                    sruc1 = ""
                Else
                    sruc1 = CType(rst_edtventa_pasaje.Rows(0).Item("ruc"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("razon_social")) = True Then
                    srazon_social1 = ""
                Else
                    srazon_social1 = CType(rst_edtventa_pasaje.Rows(0).Item("razon_social"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("fecha_viaje")) = True Then
                    sfecha_viaje1 = ""
                Else
                    sfecha_viaje1 = CType(rst_edtventa_pasaje.Rows(0).Item("fecha_viaje"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("hora_salida")) = True Then
                    shora_salida1 = ""
                Else
                    shora_salida1 = CType(rst_edtventa_pasaje.Rows(0).Item("hora_salida"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("nro_asiento")) = True Then
                    lnro_asiento1 = -1
                Else
                    lnro_asiento1 = CType(rst_edtventa_pasaje.Rows(0).Item("nro_asiento"), Long)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("porc_descuento")) = True Then
                    dporc_descuento1 = -1
                Else
                    dporc_descuento1 = CType(rst_edtventa_pasaje.Rows(0).Item("porc_descuento"), Double)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("memo")) = True Then
                    smemo1 = ""
                Else
                    smemo1 = CType(rst_edtventa_pasaje.Rows(0).Item("memo"), String)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("monto_total")) = True Then
                    dmonto_total1 = 0
                Else
                    dmonto_total1 = CType(rst_edtventa_pasaje.Rows(0).Item("monto_total"), Double)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("idtarjetas")) = True Then
                    iidtarjetas = -666
                Else
                    iidtarjetas = CType(rst_edtventa_pasaje.Rows(0).Item("idtarjetas"), Long)
                End If
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("idforma_pago")) = True Then
                    lidforma_pago = -666
                Else
                    lidforma_pago = CType(rst_edtventa_pasaje.Rows(0).Item("idforma_pago"), Double)
                End If
                '
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("codigo_cuenta")) = True Then
                    scodigo_cuenta1 = ""
                Else
                    scodigo_cuenta1 = CType(rst_edtventa_pasaje.Rows(0).Item("codigo_cuenta"), String)
                End If
                '
                If IsDBNull(rst_edtventa_pasaje.Rows(0).Item("razon_social_cta")) = True Then
                    srazon_social_cta1 = ""
                Else
                    srazon_social_cta1 = CType(rst_edtventa_pasaje.Rows(0).Item("razon_social_cta"), String)
                End If
                ll_es_fecha_abierta = CType(rst_edtventa_pasaje.Rows(0).Item("es_fecha_abierta"), Long)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function

    'Public Function fnControl_recibocaja2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.SP_FILTRO_RECIBO_CAJA", 22, _
    '                                                                  icontrol, 1, _
    '                                                                  lidunidad_agencia_ori, 1, _
    '                                                                  lidunidad_agencia_des, 1, _
    '                                                                  lidusuario_personal, 1, _
    '                                                                  iidagencias_origen, 1, _
    '                                                                  Serie, 2, _
    '                                                                  NroDoc, 2, _
    '                                                                  sapellidos_nombre_dni, 2, _
    '                                                                  sfecha_inicio, 2, _
    '                                                                  sfecha_final, 2}
    '    rstvtapasaje = Nothing
    '    rstvtapasaje = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fnControl_recibocaja() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_RECIBO_CAJA", CommandType.StoredProcedure)
            db.AsignarParametro("ncontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("norigen", lidunidad_agencia_ori, OracleClient.OracleType.Int32)
            db.AsignarParametro("ndestino", lidunidad_agencia_des, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidUsuario", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidagencia", iidagencias_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("vserie", Serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnrodoc", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("npasajero", sapellidos_nombre_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rstvtapasaje = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnElimina_pasaje2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.sp_eliminar_pasaje", 4, _
    '                                                                 sidventa_pasajes, 2}
    '    rst_elimina_pasaje = Nothing
    '    rst_elimina_pasaje = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fnElimina_pasaje() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_eliminar_pasaje", CommandType.StoredProcedure)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasajes, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_elimina_pasaje = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnValida_comprobante2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.sp_valida_comprobante", 6, _
    '                                                                        Serie, 2, _
    '                                                                        NroDoc, 2}
    '    rst_valida_comprobante = Nothing
    '    rst_valida_comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fnValida_comprobante() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_valida_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("vserie_comprobante", Serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_comprobante", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_comprobante", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_valida_comprobante = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnCambioUsuario2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.sp_cambio_usuario", 10, _
    '                                      sidventa_pasajes, 2, _
    '                                      lidusuario_personal, 1, _
    '                                      sip, 2, _
    '                                      lidusuario_personal_mod, 1}
    '    rst_cambio_usuario = Nothing
    '    rst_cambio_usuario = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fnCambioUsuario() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_cambio_usuario", CommandType.StoredProcedure)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasajes, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vipmod", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidusuario_personal_mod", lidusuario_personal_mod, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_cambio_usuario = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fn_getcodigo_cuenta2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.sp_get_cuenta", 4, _
    '                                                                    snro_comprobante_ref, 2}
    '    rst_codigo_cuenta_corriente = Nothing
    '    rst_codigo_cuenta_corriente = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_codigo_cuenta_corriente.BOF = True And rst_codigo_cuenta_corriente.EOF = True Then
    '        flag = False
    '    Else
    '        flag = True
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fn_getcodigo_cuenta() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_get_cuenta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_nro_boleto_ref", snro_comprobante_ref, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_codigo_cuentas", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_codigo_cuenta_corriente = db.EjecutarDataTable
            If rst_codigo_cuenta_corriente.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fngraba_pasaje2009() As Boolean
    'Dim flag As Boolean = False
    'Try

    '    'Dim SQLQuery As Object() = {"PKG_IVOVENTA_PASAJE.sp_actualiza_pasaje", 84, _
    '    'Dim SQLQuery As Object() = {"PKG_IVOVENTA_PASAJE.sp_actualiza_pasaje_ii", 86, _
    '    Dim SQLQuery As Object() = {"PKG_IVOVENTA_PASAJE.sp_actualiza_pasaje_3", 88, _
    '                                                                icontrol, 1, _
    '                                                                sidventa_pasaje, 2, _
    '                                                                sidpersona_dni, 2, _
    '                                                                sapellidos_nombre_dni, 2, _
    '                                                                snrodctoidentidad_dni, 2, _
    '                                                                lidtipo_comprobante, 1, _
    '                                                                sserie_comprobante, 2, _
    '                                                                snro_comprobante, 2, _
    '                                                                lidcondicion_boleto, 1, _
    '                                                                sidpersona_empresa, 2, _
    '                                                                srazon_social, 2, _
    '                                                                sruc, 2, _
    '                                                                sserie_comprobante_ref, 2, _
    '                                                                snro_comprobante_ref, 2, _
    '                                                                lidforma_pago, 1, _
    '                                                                lidtipo_moneda, 1, _
    '                                                                d_igv, 3, _
    '                                                                lidtipo_operacion, 1, _
    '                                                                lnro_asiento, 1, _
    '                                                                dmonto_base, 3, _
    '                                                                dmonto_penalidad, 3, _
    '                                                                dmonto_descuento, 3, _
    '                                                                dmonto_recargo, 3, _
    '                                                                dmonto_total, 3, _
    '                                                                dporc_descuento, 3, _
    '                                                                iidagencias_venta, 1, _
    '                                                                iidagencias_origen, 1, _
    '                                                                iIDAGENCIAS_DESTINO, 1, _
    '                                                                lidunidad_agencia_ori, 1, _
    '                                                                lidunidad_agencia_des, 1, _
    '                                                                liestado_registro, 1, _
    '                                                                sip, 2, _
    '                                                                sfecha_emision, 2, _
    '                                                                sfecha_viaje, 2, _
    '                                                                shora_salida, 2, _
    '                                                                smemo, 2, _
    '                                                                scodigo_cuenta, 2, _
    '                                                                ledad, 1, _
    '                                                                lidusuario_personal, 1, _
    '                                                                lidrol_usuario, 1, _
    '                                                                iidtarjetas, 1, _
    '                                                                srazon_social_cta, 2, _
    '                                                                ll_es_fecha_abierta, 1}
    '    ' Sirve para graba en un Log
    '    '' objLOG.fnLog("[dtoGuiaEnvio.fnLISTA_TARIFA_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & iIDUNIDAD_AGENCIA.ToString & "," & iIDUNIDAD_AGENCIA_DESTINO.ToString)
    '    rst_mensaje_oracle = Nothing
    '    rst_mensaje_oracle = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    '
    '    flag = True
    'Catch ex As Exception
    '    flag = False
    '    ' Comentado para el log 
    '    ' objLOG.fnLogErr("[dtoGuiaEnvio.fnLISTA_valida_CLIENTE] " & sNU_DOCU_SUNAT.ToString & "," & ex.ToString)
    'End Try
    'Return flag
    'End Function

    Public Function fngraba_pasaje() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_actualiza_pasaje_3", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vidpersona", sidpersona_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnombre_apellidos", sapellidos_nombre_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnrodctoidentidad", snrodctoidentidad_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidtipo_comprobante", lidtipo_comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vserie_comprobante", sserie_comprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_comprobante", snro_comprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidcondicion_boleto", lidcondicion_boleto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vidpersona_empresa", sidpersona_empresa, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vrazon_social", srazon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vruc", sruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_comprobante_ref", sserie_comprobante_ref, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_comprobante_ref", snro_comprobante_ref, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidforma_pago", lidforma_pago, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidtipo_moneda", lidtipo_moneda, OracleClient.OracleType.Int32)
            db.AsignarParametro("nigv", d_igv, OracleClient.OracleType.Number)
            db.AsignarParametro("nidtipo_operacion", lidtipo_operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("nnro_asiento", lnro_asiento, OracleClient.OracleType.Int32)
            db.AsignarParametro("nmonto_base", dmonto_base, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_penalidad", dmonto_penalidad, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_descuento", dmonto_descuento, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_recargo", dmonto_recargo, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_total", dmonto_total, OracleClient.OracleType.Number)
            db.AsignarParametro("nporc_descuento", dporc_descuento, OracleClient.OracleType.Number)
            db.AsignarParametro("nidagencia_venta", iidagencias_venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidagencia_origen", iidagencias_origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidagencia_destino", iIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidunidad_agencia_ori", lidunidad_agencia_ori, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidunidad_agencia_dest", lidunidad_agencia_des, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidestado_registro", liestado_registro, OracleClient.OracleType.Int32)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_emision", sfecha_emision, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_viaje", sfecha_viaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vhora_salida", shora_salida, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmemo", smemo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vidpersona_cuenta", scodigo_cuenta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nedad", ledad, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidrol_usuario", lidrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidtarjeta", iidtarjetas, OracleClient.OracleType.Int32)
            db.AsignarParametro("vrazon_social_cta", srazon_social_cta, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_es_fecha_abiera", ll_es_fecha_abierta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_mensaje_oracle = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnAnularBoletoRecCaja() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.SP_ANULACION_BOLETO", CommandType.StoredProcedure)
            db.AsignarParametro("v_IdVentaPasajes", lidventa_pasajes, OracleClient.OracleType.Number)
            db.AsignarParametro("v_IdUsuario_Personal", lidpersona1, OracleClient.OracleType.Number)
            db.AsignarParametro("v_IP", lidpersona1, OracleClient.OracleType.Number)
            db.AsignarParametro("Cur_Error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rstMensaje = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
End Class
