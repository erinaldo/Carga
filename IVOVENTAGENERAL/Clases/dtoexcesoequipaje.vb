Imports AccesoDatos
Public Class dtoexcesoequipaje
#Region "RECORDSET"
    ' Load 
    'Public rst_documento As New ADODB.Recordset
    Public rst_documento As DataTable

    'Public rst_Lista_Unidades_Agencia As New ADODB.Recordset
    Public rst_Lista_Unidades_Agencia As DataTable

    'Public rst_Lista_Usuarios As New ADODB.Recordset
    Public rst_Lista_Usuarios As DataTable

    'Public rst_recupera_cliente As New ADODB.Recordset
    Public rst_recupera_cliente As DataTable

    'Public rst_edtventa_exceso As New ADODB.Recordset    '
    Public rst_edtventa_exceso As DataTable

    'Public rst_unidad_agencia As New ADODB.Recordset
    Public rst_unidad_agencia As DataTable

    'Public rst_agencias As New ADODB.Recordset
    Public rst_agencias As DataTable

    'Public rstvtaexceso As New ADODB.Recordset
    Public rstvtaexceso As DataTable

    'Public rst_elimina_exceso As New ADODB.Recordset
    Public rst_elimina_exceso As DataTable

    'Public rst_anular_exceso As New ADODB.Recordset
    Public rst_anular_exceso As DataTable

    'Public rst_tarjeta_credito As New ADODB.Recordset
    Public rst_tarjeta_credito As DataTable
    Public rst_tipo_comprobante As DataTable

    '
    'Recupera Documentos 
    'Public rst_NroDocumentos As New ADODB.Recordset
    Public rst_NroDocumentos As DataTable

    Public Serie As String = ""
    Public NroDoc As String = ""
    ' Recupera el id de la venta de pasaje, se recomienda en string    
    Public sidventa_pasaje As String
    '
    Public iidagencias As Integer
    Public iIDAGENCIAS_DESTINO As Integer
    Public sNU_DOCU_SUNAT As String
    ' Control 
    Public sfecha_inicio As String
    Public sfecha_final As String
    '
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
    Public dt_datosVenta As DataTable
    '
    Public icontrol As Integer
    Public sidventa_pasajes As String
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
    Public lcantidad As Long
    Public dpeso As Integer 'double
    Public lidusuario_personal As Integer 'Long
    Public lidrol_usuario As Integer ' Long
    Public litarjeta As Long
    '
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
#Region "Recupera Datos"
    Public lidventa_pasajes As Long
    Public lidtipo_comprobante1 As Long
    Public sserie_comprobante1 As String
    Public snro_comprobante1 As String
    Public lidunidad_agencia_origen As Long
    Public sorigen As String
    Public lidunidad_agencia_destino As Long
    Public sdestino As String
    Public lidagencia_origen1 As Long
    Public lidagencia_destino1 As Long
    Public lidcondicion_boleto1 As Long
    Public sfecha_emision1 As String
    Public lidpersona1 As Long
    Public sdni1 As String
    Public spasajero As String
    Public sfecha_nacimiento As String
    Public lidpersona_empresa1 As Long
    Public sfecha_viaje1 As String
    Public shora_salida1 As String
    Public lnro_asiento1 As Long
    Public dporc_descuento1 As Double
    Public dmonto_total1 As Double
    Public lidtarjeta1 As Long
    Public ll_idtipo_comprobante_d As Long
#End Region
#Region "METODOS EXCESO EQUIPAJE"
    'Ref:

    'Define la lista inicial del formulario control...(frm...)
    'Public Function fnLISTA_INICIAL_exceso_equipaje2009() As Boolean
    'Dim flat As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOVENTA_PASAJE.sp_lista_excesoequipaje", 2}
    '    rst_documento = Nothing
    '    ' rst_condicion = Nothing
    '    rst_agencias = Nothing
    '    rst_tarjeta_credito = Nothing
    '    rst_documento = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_documento.EOF = False And rst_documento.BOF = False Then
    '        ' rst_condicion = rst_documento.NextRecordset
    '        rst_unidad_agencia = rst_documento.NextRecordset
    '        rst_agencias = rst_documento.NextRecordset
    '        rst_tarjeta_credito = rst_documento.NextRecordset
    '    End If
    '    flat = True
    'Catch ex As Exception
    '    flat = False
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    objLOG.fnLogErr("[dtoventapasaje.fnLISTA_INICIAL_VENTAPASAJE] " & ex.ToString)
    'End Try
    'Return flat
    'End Function

    'Define la lista inicial del formulario control...(frm...)
    Public Function fnLISTA_INICIAL_exceso_equipaje() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_lista_excesoequipaje_1", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_documento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_unidad_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_tarjeta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_tipo_comprobante", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_documento = ds.Tables(0)
            If rst_documento.Rows.Count > 0 Then
                rst_unidad_agencia = ds.Tables(1)
                rst_agencias = ds.Tables(2)
                rst_tarjeta_credito = ds.Tables(3)
                rst_tipo_comprobante = ds.Tables(4)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnGetAgencias2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    'Try
    '    Dim SQLQUERY As Object() = {"PKG_IVOVENTA_PASAJE.sp_lista_agencia", 4, idUnidadAge, 1}
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
            db.AsignarParametro("v_idUnidadAgencia", idUnidadAge, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_agencias", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_agencias = db.EjecutarDataTable
            Return rst_agencias
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
            db.CrearComando("select t_Control_Comprobantes.Serie,t_Control_Comprobantes.Nro_Documento from  t_Control_Comprobantes where t_Control_Comprobantes.Ip='" & dtoUSUARIOS.IP & "' and t_Control_Comprobantes.Idtipo_Comprobante= " & idDocumento.ToString & "  and t_Control_Comprobantes.Idagencias=" & dtoUSUARIOS.m_iIdAgencia.ToString & " and t_Control_Comprobantes.Idestado_Registro=1", CommandType.Text)
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
    '    rst_recupera_cliente = Nothing
    '    rst_recupera_cliente = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If rst_recupera_cliente.EOF = False And rst_recupera_cliente.BOF = False Then
    '        snombre_pasajero = rst_recupera_cliente.Fields.Item(1).Value
    '        lidpersona = CType(rst_recupera_cliente.Fields.Item(0).Value, Long)
    '        stelefono = rst_recupera_cliente.Fields.Item(2).Value
    '        flag = True
    '    End If
    'Catch ex As Exception
    '    flag = False
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
                stelefono = rst_recupera_cliente.Rows(0).Item(2)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnIncrementarNroDoc2009(ByVal idTipoComprobante As Integer)
    '    Dim flag As Boolean = False
    '    Dim rstnrodocumentos As New ADODB.Recordset
    '    Try
    '        Dim SQLQuery As Object() = {"sp_INCREMENTAR_NRO_DOCUMENTO", 8, dtoUSUARIOS.IP, 2, dtoUSUARIOS.m_iIdAgencia, 1, idTipoComprobante, 1}
    '        'objLOG.fnLog("[sp_INCREMENTAR_NRO_DOCUMENTO] " & fnLoagObj(SQLQuery))
    '        rstnrodocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstnrodocumentos.State = 1 Then
    '            If rstnrodocumentos.EOF = False And rstnrodocumentos.BOF = False Then
    '                flag = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function fnIncrementarNroDoc(ByVal idTipoComprobante As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDAGENCIAS", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_COMPROBANTE", idTipoComprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            If db.EjecutarComando() > 0 Then
                Return True
            Else
                Return False
            End If
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

    'Public Function fnFILTRO_USUARIO_X_AGENCIA_exceso2009(ByVal idAgencia As Integer) As Boolean
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

    Public Function fnFILTRO_USUARIO_X_AGENCIA_exceso(ByVal idAgencia As Integer, inicio As String, fin As String) As Boolean
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
    'Public Function fnControlexceso2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    'Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.SP_FILTRO_EXCESO", 20, _
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.SP_FILTRO_EXCESO_II", 22, _
    '                                                                  icontrol, 1, _
    '                                                                  lidunidad_agencia_ori, 1, _
    '                                                                  lidunidad_agencia_des, 1, _
    '                                                                  lidagencia_origen1, 1, _
    '                                                                  lidusuario_personal, 1, _
    '                                                                  Serie, 2, _
    '                                                                  NroDoc, 2, _
    '                                                                  sapellidos_nombre_dni, 2, _
    '                                                                  sfecha_inicio, 2, _
    '                                                                  sfecha_final, 2}
    '    rstvtaexceso = Nothing
    '    rstvtaexceso = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function fnControlexceso() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_EXCESO_II", CommandType.StoredProcedure)
            db.AsignarParametro("ncontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("norigen", lidunidad_agencia_ori, OracleClient.OracleType.Int32)
            db.AsignarParametro("ndestino", lidunidad_agencia_des, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidagencia", lidagencia_origen1, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidUsuario", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vserie", Serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnrodoc", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("npasajero", sapellidos_nombre_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rstvtaexceso = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGetunidadagencia2009(ByVal idUnidadAge As Integer) As ADODB.Recordset
    '    Dim rst_unidad_agencia_tmp As New ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTA_PASAJE.sp_get_descunidad_agencia", 4, idUnidadAge, 1}
    '        rst_unidad_agencia_tmp = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return rst_unidad_agencia_tmp
    'End Function
    Public Function fnGetunidadagencia(ByVal idUnidadAge As Integer) As DataTable
        Dim rst_unidad_agencia_tmp As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_get_descunidad_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("iidunidad_agencia", idUnidadAge, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_unidada_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_unidad_agencia_tmp = db.EjecutarDataTable
            Return rst_unidad_agencia_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnEDIT_ventaexceso2009()
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOVENTA_PASAJE.sp_edit_ventaexceso", 4, sidventa_pasajes.ToString, 2}
    '    rst_edtventa_exceso = Nothing
    '    rst_edtventa_exceso = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_edtventa_exceso.State = 1 Then
    '        lidventa_pasajes = CType(rst_edtventa_exceso.Fields.Item("idventa_pasajes").Value, Long)
    '        lidtipo_comprobante1 = CType(rst_edtventa_exceso.Fields.Item("idtipo_comprobante").Value, Long)
    '        sserie_comprobante1 = CType(rst_edtventa_exceso.Fields.Item("serie_comprobante").Value, String)
    '        snro_comprobante1 = CType(rst_edtventa_exceso.Fields.Item("nro_comprobante").Value, String)

    '        lidunidad_agencia_origen = CType(rst_edtventa_exceso.Fields.Item("idunidad_agencia_origen").Value, Long)
    '        sorigen = CType(rst_edtventa_exceso.Fields.Item("origen").Value, String)
    '        lidunidad_agencia_destino = CType(rst_edtventa_exceso.Fields.Item("idunidad_agencia_destino").Value, Long)
    '        sdestino = CType(rst_edtventa_exceso.Fields.Item("destino").Value, String)
    '        lidagencia_origen1 = CType(rst_edtventa_exceso.Fields.Item("idagencia_origen").Value, Long)
    '        lidagencia_destino1 = CType(rst_edtventa_exceso.Fields.Item("idagencia_destino").Value, Long)
    '        ' lidcondicion_boleto1 = CType(rst_edtventa_exceso.Fields.Item("idcondicion_boleto").Value, Long)
    '        sfecha_emision1 = CType(rst_edtventa_exceso.Fields.Item("fecha_emision").Value, String)
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("idpersona").Value) = True Then
    '            lidpersona1 = -666
    '        Else
    '            lidpersona1 = CType(rst_edtventa_exceso.Fields.Item("idpersona").Value, Long)
    '        End If
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("nu_docu_suna").Value) = True Then
    '            sdni1 = ""
    '        Else
    '            sdni1 = CType(rst_edtventa_exceso.Fields.Item("nu_docu_suna").Value, String)
    '        End If
    '        spasajero = CType(rst_edtventa_exceso.Fields.Item("datos_personales").Value, String)
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("fecha_viaje").Value) = True Then
    '            sfecha_viaje1 = ""
    '        Else
    '            sfecha_viaje1 = CType(rst_edtventa_exceso.Fields.Item("fecha_viaje").Value, String)
    '        End If
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("hora_salida").Value) = True Then
    '            shora_salida1 = ""
    '        Else
    '            shora_salida1 = CType(rst_edtventa_exceso.Fields.Item("hora_salida").Value, String)
    '        End If

    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("porc_descuento").Value) = True Then
    '            dporc_descuento1 = -1
    '        Else
    '            dporc_descuento1 = CType(rst_edtventa_exceso.Fields.Item("porc_descuento").Value, Double)
    '        End If
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("monto_total").Value) = True Then
    '            dmonto_total1 = 0
    '        Else
    '            dmonto_total1 = CType(rst_edtventa_exceso.Fields.Item("monto_total").Value, Double)
    '        End If
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("cantidad").Value) = True Then
    '            lcantidad = 0
    '        Else
    '            lcantidad = CType(rst_edtventa_exceso.Fields.Item("cantidad").Value, Long)
    '        End If
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("peso").Value) = True Then
    '            dpeso = 0.0
    '        Else
    '            dpeso = CType(rst_edtventa_exceso.Fields.Item("peso").Value, Double)
    '        End If
    '        ' Recupera si pago con tarjeta  
    '        If IsDBNull(rst_edtventa_exceso.Fields.Item("idtarjetas").Value) = True Then
    '            litarjeta = -666
    '        Else
    '            litarjeta = rst_edtventa_exceso.Fields.Item("idtarjetas").Value
    '        End If
    '        flag = True
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fnEDIT_ventaexceso() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_edit_ventaexceso", CommandType.StoredProcedure)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasajes.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_venta_pasaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_edtventa_exceso = db.EjecutarDataTable
            If rst_edtventa_exceso.Rows.Count > 0 Then
                lidventa_pasajes = CType(rst_edtventa_exceso.Rows(0).Item("idventa_pasajes"), Long)
                lidtipo_comprobante1 = CType(rst_edtventa_exceso.Rows(0).Item("idtipo_comprobante"), Long)
                sserie_comprobante1 = CType(rst_edtventa_exceso.Rows(0).Item("serie_comprobante"), String)
                snro_comprobante1 = CType(rst_edtventa_exceso.Rows(0).Item("nro_comprobante"), String)

                lidunidad_agencia_origen = CType(rst_edtventa_exceso.Rows(0).Item("idunidad_agencia_origen"), Long)
                sorigen = CType(rst_edtventa_exceso.Rows(0).Item("origen"), String)
                lidunidad_agencia_destino = CType(rst_edtventa_exceso.Rows(0).Item("idunidad_agencia_destino"), Long)
                sdestino = CType(rst_edtventa_exceso.Rows(0).Item("destino"), String)
                lidagencia_origen1 = CType(rst_edtventa_exceso.Rows(0).Item("idagencia_origen"), Long)
                lidagencia_destino1 = CType(rst_edtventa_exceso.Rows(0).Item("idagencia_destino"), Long)
                ' lidcondicion_boleto1 = CType(rst_edtventa_exceso.Fields.Item("idcondicion_boleto").Value, Long)
                sfecha_emision1 = CType(rst_edtventa_exceso.Rows(0).Item("fecha_emision"), String)
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("idpersona")) = True Then
                    lidpersona1 = -666
                Else
                    lidpersona1 = CType(rst_edtventa_exceso.Rows(0).Item("idpersona"), Long)
                End If
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("nu_docu_suna")) = True Then
                    sdni1 = ""
                Else
                    sdni1 = CType(rst_edtventa_exceso.Rows(0).Item("nu_docu_suna"), String)
                End If
                spasajero = CType(rst_edtventa_exceso.Rows(0).Item("datos_personales"), String)
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("fecha_viaje")) = True Then
                    sfecha_viaje1 = ""
                Else
                    sfecha_viaje1 = CType(rst_edtventa_exceso.Rows(0).Item("fecha_viaje"), String)
                End If
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("hora_salida")) = True Then
                    shora_salida1 = ""
                Else
                    shora_salida1 = CType(rst_edtventa_exceso.Rows(0).Item("hora_salida"), String)
                End If

                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("porc_descuento")) = True Then
                    dporc_descuento1 = -1
                Else
                    dporc_descuento1 = CType(rst_edtventa_exceso.Rows(0).Item("porc_descuento"), Double)
                End If
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("monto_total")) = True Then
                    dmonto_total1 = 0
                Else
                    dmonto_total1 = CType(rst_edtventa_exceso.Rows(0).Item("monto_total"), Double)
                End If
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("cantidad")) = True Then
                    lcantidad = 0
                Else
                    lcantidad = CType(rst_edtventa_exceso.Rows(0).Item("cantidad"), Long)
                End If
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("peso")) = True Then
                    dpeso = 0.0
                Else
                    dpeso = CType(rst_edtventa_exceso.Rows(0).Item("peso"), Double)
                End If
                ' Recupera si pago con tarjeta  
                If IsDBNull(rst_edtventa_exceso.Rows(0).Item("idtarjetas")) = True Then
                    litarjeta = -666
                Else
                    litarjeta = rst_edtventa_exceso.Rows(0).Item("idtarjetas")
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnElimina_exceso2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.sp_eliminar_pasaje", 4, _
    '                                                                 sidventa_pasaje, 2}
    '    rst_elimina_exceso = Nothing
    '    rst_elimina_exceso = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fnElimina_exceso() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_eliminar_pasaje", CommandType.StoredProcedure)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_elimina_exceso = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnanular_exceso2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOVENTA_PASAJE.sp_anular_exceso", 4, _
    '                                                              sidventa_pasaje, 2}
    '    rst_anular_exceso = Nothing
    '    rst_anular_exceso = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    flag = True
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fnanular_exceso() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_anular_exceso", CommandType.StoredProcedure)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_anular_exceso = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fngraba_exceso2009() As Boolean
    'Dim flag As Boolean = False
    'Try
    '    'Dim SQLQuery As Object() = {"PKG_IVOVENTA_PASAJE.sp_actualiza_exceso", 60, _
    '    Dim SQLQuery As Object() = {"PKG_IVOVENTA_PASAJE.sp_actualiza_exceso", 62, _
    '                                                                        icontrol, 1, _
    '                                                                        sidventa_pasaje, 2, _
    '                                                                        sidpersona_dni, 2, _
    '                                                                        sapellidos_nombre_dni, 2, _
    '                                                                        snrodctoidentidad_dni, 2, _
    '                                                                        lidtipo_comprobante, 1, _
    '                                                                        sserie_comprobante, 2, _
    '                                                                        snro_comprobante, 2, _
    '                                                                        lidforma_pago, 1, _
    '                                                                        d_igv, 3, _
    '                                                                        dmonto_base, 3, _
    '                                                                        dmonto_penalidad, 3, _
    '                                                                        dmonto_descuento, 3, _
    '                                                                        dmonto_recargo, 3, _
    '                                                                        dmonto_total, 3, _
    '                                                                        dporc_descuento, 3, _
    '                                                                        iidagencias, 1, _
    '                                                                        iIDAGENCIAS_DESTINO, 1, _
    '                                                                        lidunidad_agencia_ori, 1, _
    '                                                                        lidunidad_agencia_des, 1, _
    '                                                                        liestado_registro, 1, _
    '                                                                        sip, 2, _
    '                                                                        sfecha_emision, 2, _
    '                                                                        sfecha_viaje, 2, _
    '                                                                        shora_salida, 2, _
    '                                                                        lidusuario_personal, 1, _
    '                                                                        lidrol_usuario, 1, _
    '                                                                        lcantidad, 1, _
    '                                                                        dpeso, 3, _
    '                                                                        lidtarjeta1, 1}
    '    rst_mensaje_oracle = Nothing
    '    rst_mensaje_oracle = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    '
    '    flag = True
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fngraba_exceso() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 18-06-2016
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_grabar_otros_ingresos", CommandType.StoredProcedure)
            'db.CrearComando("PKG_IVOVENTA_PASAJE.sp_actualiza_exceso", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vidventa_pasajes", sidventa_pasaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vidpersona", sidpersona_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnombre_apellidos", sapellidos_nombre_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnrodctoidentidad", snrodctoidentidad_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidtipo_comprobante", lidtipo_comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vserie_comprobante", sserie_comprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_comprobante", snro_comprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidforma_pago", lidforma_pago, OracleClient.OracleType.Int32)
            db.AsignarParametro("nigv", d_igv, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_base", dmonto_base, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_penalidad", dmonto_penalidad, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_descuento", dmonto_descuento, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_recargo", dmonto_recargo, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_total", dmonto_total, OracleClient.OracleType.Number)
            db.AsignarParametro("nporc_descuento", dporc_descuento, OracleClient.OracleType.Number)
            db.AsignarParametro("nidagencia_origen", iidagencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidagencia_destino", iIDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidunidad_agencia_ori", lidunidad_agencia_ori, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidunidad_agencia_dest", lidunidad_agencia_des, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidestado_registro", liestado_registro, OracleClient.OracleType.Int32)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_emision", sfecha_emision, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_viaje", sfecha_viaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vhora_salida", shora_salida, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidrol_usuario", lidrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ncantidad", lcantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("npeso", dpeso, OracleClient.OracleType.Number)
            db.AsignarParametro("nidtarjeta", lidtarjeta1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", ll_idtipo_comprobante_d, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)

            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_err", OracleClient.OracleType.Cursor)

            db.Desconectar()
            'rst_mensaje_oracle = db.EjecutarDataTable

            Dim dataset As DataSet = db.EjecutarDataSet
            rst_mensaje_oracle = dataset.Tables(1)
            dt_datosVenta = dataset.Tables(0)

            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function get_agencia() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.sp_get_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("cur_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function FnControl_Delivery() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.SP_FILTRO_Delivery", CommandType.StoredProcedure)
            db.AsignarParametro("ncontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("norigen", lidunidad_agencia_ori, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidagencia", lidagencia_origen1, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidUsuario", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vserie", Serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnrodoc", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("npasajero", sapellidos_nombre_dni, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("fecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rstvtaexceso = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function GrabarNotaCredito(ByVal tipo As Integer, ByVal id_original As Integer, ByVal fecha As String, ByVal operacion As Integer, ByVal glosa As String, _
                          ByVal agencia As Integer, ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double, _
                          ByVal usuario As Integer, ByVal ip As String) As DataRow

        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOVENTA_PASAJE.sp_grabar_nota_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id", id_original, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_glosa", glosa, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_subtotal", subtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_impuesto", impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_total", total, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet


            '-->recupera el Numero de la nota de credito que se haya generado.
            Dim datarow As DataRow = ds.Tables(0).Rows(0)
            'Dim numeroNotaCredito As String = datarow("n_serie_comprobante").ToString() & "-" & datarow("n_numero_comprobante").ToString()


            '-->Por si retorne algun error
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If

            Return datarow
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try

    End Function
#End Region
End Class
