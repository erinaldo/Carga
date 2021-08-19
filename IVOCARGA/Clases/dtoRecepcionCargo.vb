Imports AccesoDatos
Public Class dtoRecepcionCargo
    Public v_NRO_GUIA_ENVIO As String
    Public v_CARGO_DOC As Integer
    Public v_FECHA_DOC As String
    Public V_idtipo_recepcion_docu As String

    Public Razon_Social As String
    Public Nu_Docu_Suna As String
    Public Origen As String
    Public Destino As String

    Public Fecha_Guia As String
    Public Fecha_Doc As String
    Public Fecha_Despacho As String
    Public Fecha_Llegada As String
    Public Fecha_Entrega As String
    Public cantidad As Integer
    Public Total_Peso As Double
    Public Total_Volumen As Double
    Public Cantidad_Sobres As Integer
    Public UsuarioRegistro As String
    Public UsuarioDespacho As String
    Public UsuarioEntrega As String
    Public UsuarioDoc As String
    Public Estado_Registro As String
    Public EstadoEnvio As String
    '15/03/2008 
    Public pl_idtipo_comprobante As Long
    Public pl_idguia_envio As Long
    Public ps_nombre_entrega As String
    Public ps_doc_a_quien_se_entrega As String
    Public ps_tipo_comprobante As String
    Public ps_hora_entrega As String
    Public v_idtipo_comprobante As Long
    Public tipo_comprobante As String

    'hlamas 22-07-2015
    Public strCargo As String

    'hlamas 12-08-2019
    Public TipoFacturacion As Integer
    '
    '    Public cur_Datos As New ADODB.Recordset
    '   Public cur_control As New ADODB.Recordset
    '27/05/2008 
    Public obs_recep_docu As String
#Region "Datatables"
    Public dt_cur_Datos As New DataTable
    Public dt_cur_control As New DataTable
#End Region

    Public Function fnClear() As Boolean
        Razon_Social = ""
        Nu_Docu_Suna = ""
        Origen = ""
        Destino = ""
        Fecha_Guia = ""
        Fecha_Doc = ""
        Fecha_Despacho = ""
        Fecha_Llegada = ""
        Fecha_Entrega = ""
        cantidad = ""
        Total_Peso = ""
        Total_Volumen = ""
        Cantidad_Sobres = ""
        UsuarioRegistro = ""
        UsuarioEntrega = ""
        UsuarioDoc = ""
        Estado_Registro = ""
        EstadoEnvio = ""
        UsuarioDespacho = ""
        Return False
    End Function
    'Public Function fnRECEPCION_CARGO_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_RECEPCION_CARGO", 14, v_NRO_GUIA_ENVIO, 2, v_CARGO_DOC, 1, v_FECHA_DOC, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1}
    '        objLOG.fnLog("[dtoRecepcionGuias.fnRECEPCION_GUIAS_CARGO] " & fnLoagObj(varSP_OBJECT))
    '        cur_Datos = Nothing
    '        cur_control = Nothing
    '        cur_control = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        cur_Datos = cur_control.NextRecordset
    '        ' fnClear()
    '        If cur_control.State = 1 Then
    '            If cur_control.BOF = False And cur_control.EOF = False Then
    '                If cur_control.Fields.Item(0).Value > 0 Then
    '                    If cur_Datos.EOF = False And cur_Datos.BOF = False Then
    '                        flag = True
    '                        Razon_Social = cur_Datos.Fields.Item("Razon_Social").Value
    '                        Nu_Docu_Suna = cur_Datos.Fields.Item("Nu_Docu_Suna").Value
    '                        Origen = cur_Datos.Fields.Item("Origen").Value
    '                        Destino = cur_Datos.Fields.Item("Destino").Value
    '                        Fecha_Guia = cur_Datos.Fields.Item("Fecha_Guia").Value
    '                        Fecha_Doc = cur_Datos.Fields.Item("Fecha_Doc").Value
    '                        Fecha_Despacho = cur_Datos.Fields.Item("Fecha_Despacho").Value
    '                        Fecha_Llegada = cur_Datos.Fields.Item("Fecha_Llegada").Value
    '                        Fecha_Entrega = cur_Datos.Fields.Item("Fecha_Entrega").Value
    '                        cantidad = cur_Datos.Fields.Item("cantidad").Value
    '                        Total_Peso = cur_Datos.Fields.Item("Total_Peso").Value
    '                        Total_Volumen = cur_Datos.Fields.Item("Total_Volumen").Value
    '                        Cantidad_Sobres = cur_Datos.Fields.Item("Cantidad_Sobres").Value
    '                        UsuarioRegistro = cur_Datos.Fields.Item("UsuarioRegistro").Value
    '                        UsuarioDespacho = cur_Datos.Fields.Item("UsuarioDespacho").Value
    '                        UsuarioEntrega = cur_Datos.Fields.Item("UsuarioEntrega").Value
    '                        UsuarioDoc = cur_Datos.Fields.Item("UsuarioDoc").Value
    '                        Estado_Registro = cur_Datos.Fields.Item("Estado_Registro").Value
    '                        EstadoEnvio = cur_Datos.Fields.Item("EstadoEnvio").Value
    '                    End If
    '                Else
    '                    MsgBox(cur_control.Fields.Item(1).Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    '
    'Public Function fnRECEPCION_CARGO_SITU_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_RECEPCION_CARGO_SITU", 16, V_idtipo_recepcion_docu, 2, v_NRO_GUIA_ENVIO, 2, v_CARGO_DOC, 1, v_FECHA_DOC, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1}
    '        objLOG.fnLog("[dtoRecepcionGuias.fnRECEPCION_GUIAS_CARGO] " & fnLoagObj(varSP_OBJECT))
    '        cur_Datos = Nothing
    '        cur_control = Nothing
    '        cur_control = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        cur_Datos = cur_control.NextRecordset
    '        ' fnClear()
    '        If cur_control.State = 1 Then
    '            If cur_control.BOF = False And cur_control.EOF = False Then
    '                If cur_control.Fields.Item(0).Value > 0 Then
    '                    If cur_Datos.EOF = False And cur_Datos.BOF = False Then
    '                        flag = True
    '                        Razon_Social = cur_Datos.Fields.Item("Razon_Social").Value
    '                        Nu_Docu_Suna = cur_Datos.Fields.Item("Nu_Docu_Suna").Value
    '                        Origen = cur_Datos.Fields.Item("Origen").Value
    '                        Destino = cur_Datos.Fields.Item("Destino").Value
    '                        Fecha_Guia = cur_Datos.Fields.Item("Fecha_Guia").Value
    '                        Fecha_Doc = cur_Datos.Fields.Item("Fecha_Doc").Value
    '                        Fecha_Despacho = cur_Datos.Fields.Item("Fecha_Despacho").Value
    '                        Fecha_Llegada = cur_Datos.Fields.Item("Fecha_Llegada").Value
    '                        Fecha_Entrega = cur_Datos.Fields.Item("Fecha_Entrega").Value
    '                        cantidad = cur_Datos.Fields.Item("cantidad").Value
    '                        Total_Peso = cur_Datos.Fields.Item("Total_Peso").Value
    '                        Total_Volumen = cur_Datos.Fields.Item("Total_Volumen").Value
    '                        Cantidad_Sobres = cur_Datos.Fields.Item("Cantidad_Sobres").Value
    '                        UsuarioRegistro = cur_Datos.Fields.Item("UsuarioRegistro").Value
    '                        UsuarioDespacho = cur_Datos.Fields.Item("UsuarioDespacho").Value
    '                        UsuarioEntrega = cur_Datos.Fields.Item("UsuarioEntrega").Value
    '                        UsuarioDoc = cur_Datos.Fields.Item("UsuarioDoc").Value
    '                        Estado_Registro = cur_Datos.Fields.Item("Estado_Registro").Value
    '                        EstadoEnvio = cur_Datos.Fields.Item("EstadoEnvio").Value
    '                    End If
    '                Else
    '                    MsgBox(cur_control.Fields.Item(1).Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    ' - 15/03/2008 - Valida los datos de entrega 
    'Public Function fnRECEPCION_CARGO_Valida_datos_entrega_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.sp_get_datos_entrega", 4, v_NRO_GUIA_ENVIO, 2}
    '        cur_Datos = Nothing
    '        cur_Datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        ' fnClear()
    '        If cur_Datos.State = 1 Then
    '            If cur_Datos.EOF = False And cur_Datos.BOF = False Then
    '                flag = True
    '                pl_idguia_envio = CType(cur_Datos.Fields.Item("idguias_envio").Value, Long)
    '                If IsDBNull(cur_Datos.Fields.Item("Fecha_Entrega").Value) = True Then
    '                    Fecha_Entrega = ""
    '                Else
    '                    Fecha_Entrega = CType(cur_Datos.Fields.Item("Fecha_Entrega").Value, String)
    '                End If
    '                If IsDBNull(cur_Datos.Fields.Item("nombre_entrega").Value) = True Then
    '                    ps_nombre_entrega = ""
    '                Else
    '                    ps_nombre_entrega = cur_Datos.Fields.Item("nombre_entrega").Value
    '                End If
    '                If IsDBNull(cur_Datos.Fields.Item("doc_entrega").Value) = True Then
    '                    ps_doc_a_quien_se_entrega = ""
    '                Else
    '                    ps_doc_a_quien_se_entrega = CType(cur_Datos.Fields.Item("doc_entrega").Value, String)
    '                End If
    '                '
    '                ps_tipo_comprobante = CType(cur_Datos.Fields.Item("tipo_comprobante").Value, String)
    '                '
    '                If IsDBNull(cur_Datos.Fields.Item("hora_entrega").Value) = True Then
    '                    ps_hora_entrega = ""
    '                Else
    '                    ps_hora_entrega = CType(cur_Datos.Fields.Item("hora_entrega").Value, String)
    '                End If
    '                '
    '                If IsDBNull(cur_Datos.Fields.Item("idtipo_comprobante").Value) = True Then
    '                    pl_idtipo_comprobante = 0
    '                Else
    '                    pl_idtipo_comprobante = CType(cur_Datos.Fields.Item("idtipo_comprobante").Value, Long)
    '                End If

    '            Else
    '                MsgBox(" No se ha encontrado datos para está guía.", MsgBoxStyle.Information, "Seguridad Sistema")
    '                flag = False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    ' - 15/03/2008 - Valida los datos de entrega 
    'Public Function fnRECEPCION_CARGO_graba_datos_entrega_2009() As ADODB.Recordset
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.sp_act_datos_entrega", 20, _
    '                                                        pl_idtipo_comprobante, 1, _
    '                                                        CType(pl_idguia_envio, String), 2, _
    '                                                        ps_nombre_entrega, 2, _
    '                                                        ps_doc_a_quien_se_entrega, 2, _
    '                                                        Fecha_Entrega, 2, _
    '                                                        ps_hora_entrega, 2, _
    '                                                        dtoUSUARIOS.IdLogin, 1, _
    '                                                        dtoUSUARIOS.IP, 2, _
    '                                                         dtoUSUARIOS.IdRol, 1}
    '        '
    '        Return VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
    '    End Try
    'End Function
    ' - 15/03/2008 - Valida los datos de entrega 
    Public Function fnRECEPCION_CARGO_graba_datos_entrega() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_cur_Datos = Nothing
            dt_cur_control = Nothing
            '
            dt_cur_Datos = New DataTable
            dt_cur_control = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_act_datos_entrega", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("ni_idtipo_comprobante", pl_idtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_idguia_envio", CType(pl_idguia_envio, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_nombre_entrega", ps_nombre_entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_doc_entrega", ps_doc_a_quien_se_entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fecha_entrega", Fecha_Entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_hora_entrega", ps_hora_entrega, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    '07/04/2008 - Rgomez 
    'Public Function fnRECEPCION_CARGO_SITU_II_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_RECE_CARGO_SITU_II", 18, _
    '        V_idtipo_recepcion_docu, 2, _
    '        v_NRO_GUIA_ENVIO, 2, _
    '        v_CARGO_DOC, 1, _
    '        v_FECHA_DOC, 2, _
    '        dtoUSUARIOS.IdLogin, 1, _
    '        dtoUSUARIOS.IP, 2, _
    '        dtoUSUARIOS.IdRol, 1, _
    '        Me.v_idtipo_comprobante, 1}
    '        objLOG.fnLog("[dtoRecepcionGuias.fnRECEPCION_GUIAS_CARGO] " & fnLoagObj(varSP_OBJECT))
    '        cur_Datos = Nothing
    '        cur_control = Nothing
    '        cur_control = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        cur_Datos = cur_control.NextRecordset
    '        ' fnClear()
    '        If cur_control.State = 1 Then
    '            If cur_control.BOF = False And cur_control.EOF = False Then
    '                If cur_control.Fields.Item(0).Value > 0 Then
    '                    If cur_Datos.EOF = False And cur_Datos.BOF = False Then
    '                        flag = True
    '                        Razon_Social = cur_Datos.Fields.Item("Razon_Social").Value
    '                        Nu_Docu_Suna = cur_Datos.Fields.Item("Nu_Docu_Suna").Value
    '                        Origen = cur_Datos.Fields.Item("Origen").Value
    '                        Destino = cur_Datos.Fields.Item("Destino").Value
    '                        Fecha_Guia = cur_Datos.Fields.Item("Fecha_Guia").Value
    '                        Fecha_Doc = cur_Datos.Fields.Item("Fecha_Doc").Value
    '                        Fecha_Despacho = cur_Datos.Fields.Item("Fecha_Despacho").Value
    '                        Fecha_Llegada = cur_Datos.Fields.Item("Fecha_Llegada").Value
    '                        Fecha_Entrega = cur_Datos.Fields.Item("Fecha_Entrega").Value
    '                        cantidad = cur_Datos.Fields.Item("cantidad").Value
    '                        Total_Peso = cur_Datos.Fields.Item("Total_Peso").Value
    '                        Total_Volumen = cur_Datos.Fields.Item("Total_Volumen").Value
    '                        Cantidad_Sobres = cur_Datos.Fields.Item("Cantidad_Sobres").Value
    '                        UsuarioRegistro = cur_Datos.Fields.Item("UsuarioRegistro").Value
    '                        UsuarioDespacho = cur_Datos.Fields.Item("UsuarioDespacho").Value
    '                        UsuarioEntrega = cur_Datos.Fields.Item("UsuarioEntrega").Value
    '                        UsuarioDoc = cur_Datos.Fields.Item("UsuarioDoc").Value
    '                        Estado_Registro = cur_Datos.Fields.Item("Estado_Registro").Value
    '                        EstadoEnvio = cur_Datos.Fields.Item("EstadoEnvio").Value
    '                        tipo_comprobante = cur_Datos.Fields.Item("tipo_comprobante").Value
    '                    End If
    '                Else
    '                    MsgBox(cur_control.Fields.Item(1).Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    'Public Function fnRECEPCION_CARGO_SITU_III_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVORECEPCION_CARGA.SP_RECE_CARGO_SITU_III", 20, _
    '        V_idtipo_recepcion_docu, 2, _
    '        v_NRO_GUIA_ENVIO, 2, _
    '        v_CARGO_DOC, 1, _
    '        v_FECHA_DOC, 2, _
    '        dtoUSUARIOS.IdLogin, 1, _
    '        dtoUSUARIOS.IP, 2, _
    '        dtoUSUARIOS.IdRol, 1, _
    '        Me.v_idtipo_comprobante, 1, _
    '        Me.obs_recep_docu, 2}

    '        objLOG.fnLog("[dtoRecepcionGuias.fnRECEPCION_GUIAS_CARGO] " & fnLoagObj(varSP_OBJECT))

    '        cur_Datos = Nothing
    '        cur_control = Nothing
    '        cur_control = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        cur_Datos = cur_control.NextRecordset
    '        ' fnClear()
    '        If cur_control.State = 1 Then
    '            If cur_control.BOF = False And cur_control.EOF = False Then
    '                If cur_control.Fields.Item(0).Value > 0 Then
    '                    If cur_Datos.EOF = False And cur_Datos.BOF = False Then
    '                        flag = True
    '                        Razon_Social = cur_Datos.Fields.Item("Razon_Social").Value
    '                        Nu_Docu_Suna = cur_Datos.Fields.Item("Nu_Docu_Suna").Value
    '                        Origen = cur_Datos.Fields.Item("Origen").Value
    '                        Destino = cur_Datos.Fields.Item("Destino").Value
    '                        Fecha_Guia = cur_Datos.Fields.Item("Fecha_Guia").Value
    '                        Fecha_Doc = cur_Datos.Fields.Item("Fecha_Doc").Value
    '                        Fecha_Despacho = cur_Datos.Fields.Item("Fecha_Despacho").Value
    '                        Fecha_Llegada = cur_Datos.Fields.Item("Fecha_Llegada").Value
    '                        Fecha_Entrega = cur_Datos.Fields.Item("Fecha_Entrega").Value
    '                        cantidad = cur_Datos.Fields.Item("cantidad").Value
    '                        Total_Peso = cur_Datos.Fields.Item("Total_Peso").Value
    '                        Total_Volumen = cur_Datos.Fields.Item("Total_Volumen").Value
    '                        Cantidad_Sobres = cur_Datos.Fields.Item("Cantidad_Sobres").Value
    '                        UsuarioRegistro = cur_Datos.Fields.Item("UsuarioRegistro").Value
    '                        UsuarioDespacho = cur_Datos.Fields.Item("UsuarioDespacho").Value
    '                        UsuarioEntrega = cur_Datos.Fields.Item("UsuarioEntrega").Value
    '                        UsuarioDoc = cur_Datos.Fields.Item("UsuarioDoc").Value
    '                        Estado_Registro = cur_Datos.Fields.Item("Estado_Registro").Value
    '                        EstadoEnvio = cur_Datos.Fields.Item("EstadoEnvio").Value
    '                        tipo_comprobante = cur_Datos.Fields.Item("tipo_comprobante").Value
    '                        If cur_Datos.Fields.Item("obs_recep_docu").Value Is DBNull.Value Then
    '                            Me.obs_recep_docu = ""
    '                        Else
    '                            Me.obs_recep_docu = cur_Datos.Fields.Item("obs_recep_docu").Value
    '                        End If


    '                    End If
    '                Else
    '                    MsgBox(cur_control.Fields.Item(1).Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnRECEPCION_CARGO_SITU_III() As Boolean
        Dim flag As Boolean = False
        '''''''''''''''''''''''''''''''''''''''
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dt_cur_Datos = Nothing
            dt_cur_control = Nothing
            '
            dt_cur_Datos = New DataTable
            dt_cur_control = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            'db_bd.CrearComando("PKG_IVORECEPCION_CARGA.SP_RECE_CARGO_SITU_III", CommandType.StoredProcedure)
            db_bd.CrearComando("sp_recepcionar_cargo", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_idtipo_recepcion_docu", V_idtipo_recepcion_docu, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NRO_GUIA_ENVIO", v_NRO_GUIA_ENVIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_CARGO_DOC", v_CARGO_DOC, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_FECHA_DOC", v_FECHA_DOC, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUSUARIO_CARGO", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP_CARGO", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_comprobante", Me.v_idtipo_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_obs_recep_docu", Me.obs_recep_docu, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            ' 
            dt_cur_control = lds_tmp.Tables(0)
            dt_cur_Datos = lds_tmp.Tables(1)
            '
            If dt_cur_control.Rows.Count > 0 Then
                If dt_cur_Datos.Rows.Count > 0 Then
                    If dt_cur_Datos.Rows(0).Item(0) > 0 Then
                        flag = True
                        Razon_Social = dt_cur_Datos.Rows(0).Item("Razon_Social")
                        Nu_Docu_Suna = dt_cur_Datos.Rows(0).Item("Nu_Docu_Suna")
                        Origen = dt_cur_Datos.Rows(0).Item("Origen")
                        Destino = dt_cur_Datos.Rows(0).Item("Destino")
                        Fecha_Guia = dt_cur_Datos.Rows(0).Item("Fecha_Guia")
                        Fecha_Doc = dt_cur_Datos.Rows(0).Item("Fecha_Doc")
                        Fecha_Despacho = dt_cur_Datos.Rows(0).Item("Fecha_Despacho")
                        Fecha_Llegada = dt_cur_Datos.Rows(0).Item("Fecha_Llegada")
                        Fecha_Entrega = dt_cur_Datos.Rows(0).Item("Fecha_Entrega")
                        cantidad = dt_cur_Datos.Rows(0).Item("cantidad")
                        Total_Peso = dt_cur_Datos.Rows(0).Item("Total_Peso")
                        Total_Volumen = dt_cur_Datos.Rows(0).Item("Total_Volumen")
                        Cantidad_Sobres = dt_cur_Datos.Rows(0).Item("Cantidad_Sobres")
                        UsuarioRegistro = dt_cur_Datos.Rows(0).Item("UsuarioRegistro")
                        UsuarioDespacho = dt_cur_Datos.Rows(0).Item("UsuarioDespacho")
                        UsuarioEntrega = dt_cur_Datos.Rows(0).Item("UsuarioEntrega")
                        UsuarioDoc = dt_cur_Datos.Rows(0).Item("UsuarioDoc")
                        Estado_Registro = dt_cur_Datos.Rows(0).Item("Estado_Registro")
                        EstadoEnvio = dt_cur_Datos.Rows(0).Item("EstadoEnvio")
                        tipo_comprobante = dt_cur_Datos.Rows(0).Item("tipo_comprobante")
                        strCargo = dt_cur_Datos.Rows(0).Item("cargo")
                        TipoFacturacion = dt_cur_Datos.Rows(0).Item("Tipo_Facturacion")
                        If IsDBNull(dt_cur_Datos.Rows(0).Item("obs_recep_docu")) = True Then
                            Me.obs_recep_docu = ""
                        Else
                            Me.obs_recep_docu = dt_cur_Datos.Rows(0).Item("obs_recep_docu")
                        End If
                    Else
                        MsgBox(dt_cur_control.Rows(0).Item(0), MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                Else
                    MsgBox(dt_cur_control.Rows(0).Item(0), MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                End If
                '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            flag = False
        End Try
        '''''''''''''''
        Return flag
    End Function
    Public Function fnRECEPCION_CARGO_veirifica_existe_dcto() As Integer

        Dim li_nro_dcto As Int32 = 0
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'Dim cmd As New OracleClient.OracleCommand
            'cmd.CommandText = ""
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.Connection = cnn
            'cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_guia", OracleClient.OracleType.VarChar, 13)).Value = ObjRecepcionCargo.v_NRO_GUIA_ENVIO
            'cmd.Parameters.Add(New OracleClient.OracleParameter("v_cuantos", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

            'cmd.ExecuteNonQuery()
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVORECEPCION_CARGA.sp_si_mayor_que_uno", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("p_nro_guia", v_NRO_GUIA_ENVIO, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("v_cuantos", OracleClient.OracleType.Int32)
            '
            li_nro_dcto = db_bd.EjecutarEscalar()
            '
            db_bd.Desconectar()
            Return li_nro_dcto
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return li_nro_dcto
    End Function

    Shared Function ExisteGuiaEnvio(guia As String, tipo As Integer, recepcion As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("select PKG_IVORECEPCION_CARGA.sf_get_existe_ge('" & guia & "'," & tipo & ",'" & recepcion & "') from dual", CommandType.Text)
            Dim i As Integer = db.EjecutarEscalar
            Return IIf(i = 0, False, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
End Class
