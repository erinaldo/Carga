Public Class frm_pce_a_credito
#Region "Variables Publicas"
    Public pl_idfactura_contado As Long
    Public ps_idpersona As String
    Public ps_nro_guia_envio As String
    Public pb_cancelar As Boolean
    Public hnd As Long
    '

#End Region
#Region "Variables"
    'Dim daoldb As New OleDb.OleDbDataAdapter
    '
    Dim l_objGuiaEnvio As New dtoGuiaEnvio
    '
    Dim l_obj_pce_credito As New dto_pce_a_guia_envio
    Dim l_coll_Lista_Personas As New Collection
    Dim l_coll_iOrigen As New Collection
    Dim l_coll_iDestino As New Collection
    '
    Dim l_iWinPersona As New AutoCompleteStringCollection
    Dim l_iWinPersonaRUC As New AutoCompleteStringCollection
    Dim l_iWinOrigen As New AutoCompleteStringCollection
    Dim l_iWinDestino As New AutoCompleteStringCollection
    Dim l_iWinContacto_Remitente As New AutoCompleteStringCollection
    Dim l_iWinPerosaDNI_Remite As New AutoCompleteStringCollection
    Dim l_iWinDireccion_Remitente As New AutoCompleteStringCollection
    Dim l_iWinContacto_Destinatario As New AutoCompleteStringCollection
    Dim l_iWinPerosaDNI_Destino As New AutoCompleteStringCollection
    Dim l_iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Dim l_iWinTelefono_Remitente As New AutoCompleteStringCollection
    Dim l_iWinTelefono_Destinatario As New AutoCompleteStringCollection
    '
    'Dim dt_centro_costo
    Dim dt_tipo_entrega, dt_agencia_origen, dt_agencia_destino As New DataTable
    'Dim dv_centro_costo
    Dim dv_tipo_entrega, dv_agencia_origen, dv_agencia_destino As New DataView
    'Variables  datos 
    Dim ll_idunidad_agencia_origen, ll_idunidad_agencia_destino As Long
    Dim ls_idpersona_origen, ls_idpersona_destino As String
    Dim ls_nombre_cliente_contado As String
    Dim bIngreso As Boolean = False
    '
#End Region
#Region "eventos adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Eventos"

    Private Sub frm_pce_a_credito_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frm_pce_a_credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_pce_a_credito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Recupera la guía pce a pasar 
            fn_lee_datos_iniciales()
            '
            'Recupera cliente credito 
            'Mod. 22/08/2009 -->Omendoza - Pasando al datahelper   
            If l_objGuiaEnvio.fnLISTA_PERSONASII(dtoUSUARIOS.IdLogin) = True Then
                fnCargar_iWin2(Me.txt_razon_social, l_objGuiaEnvio.dt_Lista_Personas, l_coll_Lista_Personas, l_iWinPersona, 0, l_iWinPersonaRUC)
            End If
            'Mod. 25/08/2009 -->Omendoza - Pasando al datahelper   
            If l_objGuiaEnvio.fnLISTA_ORIGEN_DESTINO() = True Then
                '
                fnCargar_iWin_dt(Me.txt_ciudad_origen, l_objGuiaEnvio.dt_cur_Origen, l_coll_iOrigen, l_iWinOrigen, ll_idunidad_agencia_origen)
                fnCargar_iWin_dt(Me.txt_ciudad_destino, l_objGuiaEnvio.dt_cur_Destino, l_coll_iDestino, l_iWinDestino, ll_idunidad_agencia_destino)
                '
            End If
            '
            Me.txt_razon_social.Text = ls_nombre_cliente_contado
            '
            ' Recupera las guías de envio 
            'If objGuiaEnvio.fnLISTA_AGENCIAS_UNIDADES() = True Then
            '    ModuUtil.LlenarComboIDs2(objGuiaEnvio.rst_Lista_Unidades_Agencia, cmbOrigen, objGuiaEnvio.coll_Lista_Origen, 9999, cmbDestino, objGuiaEnvio.coll_Lista_Destino, 9999)
            'End If
            '                
            '            ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'cancelar
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Try
            Me.Close()
            pb_cancelar = True
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub txt_razon_social_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_razon_social.Leave
        Try
            Dim indexof As Integer = 0
            '
            If l_iWinPersona.Count > 0 Then
                indexof = IIf(l_iWinPersona.IndexOf(Me.txt_razon_social.Text) >= 0, l_iWinPersona.IndexOf(txt_razon_social.Text), -1)
                l_objGuiaEnvio.iIDPERSONA = -1
                Me.txt_idpersona.Text = "-1"
                If indexof >= 0 Then
                    l_objGuiaEnvio.iIDPERSONA = Int(l_coll_Lista_Personas(indexof.ToString))
                    l_objGuiaEnvio.iCONTROLIdpersona = l_objGuiaEnvio.iIDPERSONA
                    '
                    Me.txt_idpersona.Text = CType(l_objGuiaEnvio.iIDPERSONA, Long)
                    '
                    If indexof <= l_iWinPersonaRUC.Count Then
                        Me.txt_vcodigo_cliente.Text = l_iWinPersonaRUC.Item(indexof)
                        Me.txt_remitente.Text = Me.txt_razon_social.Text
                        Me.txt_doc_remitente.Text = Me.txt_vcodigo_cliente.Text
                        llenar_collections()
                        '
                        If BuscarClientesGuia_Envio() = True Then
                            'txtCliente_Remitente.Focus()
                            'txtCliente_Remitente.SelectAll()
                            'txtDestinatario.Focus()
                            'txtDestinatario.SelectAll()
                            SendKeys.Send("{Tab}")
                        End If
                        '
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txt_remitente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_remitente.Leave
        Dim indexof As Integer = 0
        Try
            Me.txt_doc_remitente.Text = ""
            indexof = IIf(l_iWinContacto_Remitente.IndexOf(Me.txt_remitente.Text) >= 0, l_iWinContacto_Remitente.IndexOf(Me.txt_remitente.Text), -1)
            l_objGuiaEnvio.iIDCONTACTO_REMITENTE = -1
            If indexof >= 0 Then
                l_objGuiaEnvio.iIDCONTACTO_REMITENTE = Int(l_objGuiaEnvio.coll_Nombres_Remitente(indexof.ToString))
                If indexof <= l_iWinPerosaDNI_Remite.Count Then
                    Me.txt_doc_remitente.Text = l_iWinPerosaDNI_Remite.Item(indexof)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txt_consignado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_consignado.Leave
        Dim indexof As Integer = 0
        Try
            Me.txtnrodoc_destinatario.Text = ""
            indexof = IIf(l_iWinContacto_Destinatario.IndexOf(txt_consignado.Text) >= 0, l_iWinContacto_Destinatario.IndexOf(Me.txt_consignado.Text), -1)
            l_objGuiaEnvio.iIDCONTACTO_PERSONA = -1
            If indexof >= 0 Then
                l_objGuiaEnvio.iIDCONTACTO_PERSONA = Int(l_objGuiaEnvio.coll_Nombres_Destinatario(indexof.ToString))
                If indexof <= l_iWinPerosaDNI_Destino.Count Then
                    Me.txtnrodoc_destinatario.Text = l_iWinPerosaDNI_Destino.Item(indexof)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        'Dim lrst_datos As New ADODB.Recordset
        Dim ldt_datos As New DataTable
        Dim ls_mensaje As String
        Dim ll_cod_mensaje As String
        '
        Try
            '
            l_obj_pce_credito.idfactura_contado = CType(pl_idfactura_contado, String)
            '
            If CType(Me.txt_idpersona.Text, Long) < 1 Then
                MsgBox("Cliente no tiene línea de crédito", MsgBoxStyle.Information, "Sistema de Seguridad")
            End If
            '
            l_obj_pce_credito.idpersona = CType(Me.txt_idpersona.Text, String)
            l_obj_pce_credito.idremitente = CType(l_objGuiaEnvio.iIDCONTACTO_REMITENTE, String)
            l_obj_pce_credito.remitente = Me.txt_remitente.Text
            If Me.txt_doc_remitente.Text = "" Then
                l_obj_pce_credito.nro_doc_remitente = "null"
            Else
                l_obj_pce_credito.nro_doc_remitente = Me.txt_doc_remitente.Text
            End If
            l_obj_pce_credito.idcontacto_destinatario = CType(l_objGuiaEnvio.iIDCONTACTO_PERSONA, String)
            l_obj_pce_credito.destinatario = CType(Me.txt_consignado.Text, String)
            'l_obj_pce_credito.nro_doc_destinatario = CType(Me.txt_nro_doc_contacto.Text, String)
            l_obj_pce_credito.iddireccion_remitente = CType(l_objGuiaEnvio.iIDDIRECCION_REMITENTE, String)
            l_obj_pce_credito.direccion_remitente = CType(Me.txt_direccion_remitente.Text, String)
            l_obj_pce_credito.iddir_destinatario = CType(l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO, String)
            l_obj_pce_credito.direccion_destinatario = CType(Me.txt_direccion_destinatario.Text, String)
            l_obj_pce_credito.idtelefono_remite = CType(l_objGuiaEnvio.iIDTEFONO_REMITENTE, String)
            '
            If Me.txtnrodoc_destinatario.Text = "" Then '11/04/2008
                l_obj_pce_credito.nro_doc_destinatario = "null"
            Else
                l_obj_pce_credito.nro_doc_destinatario = Me.txtnrodoc_destinatario.Text
            End If
            '
            If Me.txt_telefono_remitente.Text = "" Then
                l_obj_pce_credito.telefono_remite = "null"
            Else
                l_obj_pce_credito.telefono_remite = Me.txt_telefono_remitente.Text
            End If

            l_obj_pce_credito.idTelefono_Destinatario = CType(l_objGuiaEnvio.iIDTEFONO_CONSIGNADO, String)
            '
            If Me.txt_telefono_destinatario.Text = "" Then
                l_obj_pce_credito.telefono_destinatario = "null"
            Else
                l_obj_pce_credito.telefono_destinatario = CType(Me.txt_telefono_destinatario.Text, String)
            End If
            '
            l_obj_pce_credito.idtipo_entrega_carga = CType(Me.cmb_tipo_entrega.SelectedValue, Long)
            Try
                l_obj_pce_credito.idcentro_costo = Int(l_objGuiaEnvio.coll_Sub_Cuenta.Item(Me.cmb_sub_cuenta.SelectedIndex.ToString))
            Catch ex As Exception
                MsgBox("No ha seleccionado la subcuenta", MsgBoxStyle.Information, "Sistema de Seguridad")
                Me.cmb_sub_cuenta.Focus()
                Exit Sub
            End Try

            ' CType(Me.cmb_sub_cuenta.SelectedValue, Long)
            '
            l_obj_pce_credito.rol_usuario = dtoUSUARIOS.m_iIdRol
            l_obj_pce_credito.idusuario_personal = dtoUSUARIOS.IdLogin
            l_obj_pce_credito.ip = dtoUSUARIOS.IP

            Me.Cursor = Cursors.AppStarting
            ldt_datos = l_obj_pce_credito.fn_actualiza_pce

            ll_cod_mensaje = CType(ldt_datos.Rows(0).Item(0), Long)
            ls_mensaje = CType(ldt_datos.Rows(0).Item(1), String)
            '
            If ll_cod_mensaje <> 0 Then
                Me.Cursor = Cursors.Default
                MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                Exit Sub
            End If
            '
            pb_cancelar = False
            Me.Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de seguridad")
        End Try
        '
    End Sub
    '
    Private Sub txt_direccion_destinatario_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_direccion_destinatario.Leave
        Dim idTipoDire As Integer = CType(Me.cmb_tipo_entrega.SelectedValue, Integer)
        Dim indexof As Long
        Try
            indexof = IIf(l_iWinDireccion_Destinatario.IndexOf(txt_direccion_destinatario.Text) >= 0, l_iWinDireccion_Destinatario.IndexOf(txt_direccion_destinatario.Text), -1)
            l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
            If indexof >= 0 Then
                l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(l_objGuiaEnvio.coll_Direccion_Destinatario(indexof.ToString))
            Else
                l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txt_direccion_remitente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_direccion_remitente.Leave
        Dim indexof As Long
        Try
            indexof = IIf(l_iWinDireccion_Remitente.IndexOf(Me.txt_direccion_remitente.Text) >= 0, l_iWinDireccion_Remitente.IndexOf(Me.txt_direccion_remitente.Text), -1)
            l_objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
            If indexof >= 0 Then
                l_objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(l_objGuiaEnvio.coll_Direccion_Remitente(indexof.ToString))
            Else
                l_objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Sub fn_lee_datos_iniciales()
        Dim lds_datos As New DataSet
        ' Dim lrst_datos_pce, lrst_agencias, lrst_tipo_entrega As New ADODB.Recordset
        Dim ldt_datos_pce, ldt_agencias, ldt_tipo_entrega As New DataTable
        '
        Dim ll_idtipo_entrega As Long
        '
        Dim lid_agencia_origen, lid_agencia_destino As Long
        Try
            l_obj_pce_credito.idfactura_contado = CType(pl_idfactura_contado, String)
            
            'lrst_datos_pce = l_obj_pce_credito.fn_get_pce()
            'lrst_agencias = lrst_datos_pce.NextRecordset
            'lrst_tipo_entrega = lrst_datos_pce.NextRecordset 
            '
            'Mod.11/09/2009 -->Omendoza - Pasando al datahelper   
            '
            lds_datos = l_obj_pce_credito.fn_get_pce()
            '
            ldt_datos_pce = lds_datos.Tables(0)
            ldt_agencias = lds_datos.Tables(1)
            ldt_tipo_entrega = lds_datos.Tables(2)
            '
            'daoldb.Fill(ldt_datos_pce, lrst_datos_pce)
            'daoldb.Fill(dt_agencia_origen, lrst_agencias)
            'daoldb.Fill(dt_tipo_entrega, lrst_tipo_entrega)
            'Recupera data de los diversos items
            Me.txt_idpersona.Text = CType(ldt_datos_pce.Rows(0)(0), String)
            Me.txt_razon_social.Text = CType(ldt_datos_pce.Rows(0)(1), String)
            ls_nombre_cliente_contado = CType(ldt_datos_pce.Rows(0)(1), String)
            Me.txt_vcodigo_cliente.Text = CType(ldt_datos_pce.Rows(0)(2), String)
            '
            ll_idunidad_agencia_origen = CType(ldt_datos_pce.Rows(0)(3), Long)
            Me.txt_ciudad_origen.Text = CType(ldt_datos_pce.Rows(0)(4), String)
            ll_idunidad_agencia_destino = CType(ldt_datos_pce.Rows(0)(5), Long)
            Me.txt_ciudad_destino.Text = CType(ldt_datos_pce.Rows(0)(6), String)
            '
            lid_agencia_origen = CType(ldt_datos_pce.Rows(0)(7), Long)
            lid_agencia_destino = CType(ldt_datos_pce.Rows(0)(8), Long)
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(9)) = True Then
                ls_idpersona_origen = "null"
            Else
                ls_idpersona_origen = CType(ldt_datos_pce.Rows(0)(9), String)
            End If
            If IsDBNull(ldt_datos_pce.Rows(0)(10)) = True Then
                Me.txt_remitente.Text = ""
            Else
                Me.txt_remitente.Text = CType(ldt_datos_pce.Rows(0)(10), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(11)) = True Then
                Me.txt_doc_remitente.Text = ""
            Else
                Me.txt_doc_remitente.Text = CType(ldt_datos_pce.Rows(0)(11), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(12)) = True Then
                Me.txt_direccion_remitente.Text = ""
            Else
                Me.txt_direccion_remitente.Text = CType(ldt_datos_pce.Rows(0)(12), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(13)) = True Then
                Me.txt_telefono_remitente.Text = ""
            Else
                Me.txt_telefono_remitente.Text = CType(ldt_datos_pce.Rows(0)(13), String)
            End If

            If IsDBNull(ldt_datos_pce.Rows(0)(14)) = True Then
                ls_idpersona_destino = ""
            Else
                ls_idpersona_destino = CType(ldt_datos_pce.Rows(0)(14), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(15)) = True Then
                Me.txt_consignado.Text = ""
            Else
                Me.txt_consignado.Text = CType(ldt_datos_pce.Rows(0)(15), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(16)) = True Then
                Me.txtnrodoc_destinatario.Text = ""
            Else
                Me.txtnrodoc_destinatario.Text = CType(ldt_datos_pce.Rows(0)(16), String)
            End If
            If IsDBNull(ldt_datos_pce.Rows(0)(17)) = True Then
                Me.txt_direccion_destinatario.Text = ""
            Else
                Me.txt_direccion_destinatario.Text = CType(ldt_datos_pce.Rows(0)(17), String)
            End If
            If IsDBNull(ldt_datos_pce.Rows(0)(18)) = True Then
                Me.txt_telefono_destinatario.Text = ""
            Else
                Me.txt_telefono_destinatario.Text = CType(ldt_datos_pce.Rows(0)(18), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(19)) = True Then
                Me.txt_nro_bultos.Text = "0"
            Else
                Me.txt_nro_bultos.Text = CType(ldt_datos_pce.Rows(0)(19), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(20)) = True Then
                Me.txt_tot_peso.Text = "0"
            Else
                Me.txt_tot_peso.Text = CType(ldt_datos_pce.Rows(0)(20), String)
            End If
            If IsDBNull(ldt_datos_pce.Rows(0)(21)) = True Then
                Me.txt_volumen.Text = "0"
            Else
                Me.txt_volumen.Text = CType(ldt_datos_pce.Rows(0)(21), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(22)) = True Then
                Me.txt_sub_total.Text = "0.00"
            Else
                Me.txt_sub_total.Text = CType(ldt_datos_pce.Rows(0)(22), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(23)) = True Then
                Me.txt_igv.Text = "0.00"
            Else
                Me.txt_igv.Text = CType(ldt_datos_pce.Rows(0)(23), String)
            End If
            '
            If IsDBNull(ldt_datos_pce.Rows(0)(24)) = True Then
                Me.txt_total.Text = "0.00"
            Else
                Me.txt_total.Text = CType(ldt_datos_pce.Rows(0)(24), String)
            End If
            '
            ll_idtipo_entrega = CType(ldt_datos_pce.Rows(0)(25), String)
            Me.txt_nro_guia.Text = ps_nro_guia_envio
            'Llenar el datatable y el dataview 
            dt_agencia_destino = ldt_agencias.Copy
            '
            dv_agencia_origen = CargarCombo(Me.cmb_agencia_origen, ldt_agencias, "nombre_agencia", "idagencias", lid_agencia_origen)  ' Agencias  Origen
            dv_agencia_destino = CargarCombo(Me.cmb_agencia_destino, dt_agencia_destino, "nombre_agencia", "idagencias", lid_agencia_destino)  ' Agencias Destino 
            '
            dv_tipo_entrega = CargarCombo(Me.cmb_tipo_entrega, ldt_tipo_entrega, "tipo_entrega", "idtipo_entrega", ll_idtipo_entrega)  ' Tipo Entrega 
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Function fnTarifario() As Boolean
        Dim flag As Boolean = False
        Dim bControl_Tarifas As Boolean
        Dim tarifa_Peso As Double = 0
        Dim tarifa_Volumen As Double = 0
        Dim tarifa_Articulo As Double = 0
        Dim Monto_Base As Double = 0
        Dim tarifa_Sobre As Double = 0
        Try
            'Para Traer en una sola la tarifa Origen Destino
            bControl_Tarifas = False
            ' Recupera la ciudad 
            Dim idOrigenvar As Integer = ll_idunidad_agencia_origen
            Dim idDestinovar As Integer = ll_idunidad_agencia_destino
            '
            l_objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.txt_vcodigo_cliente.Text <> "", Me.txt_vcodigo_cliente.Text, "@")
            l_objGuiaEnvio.iIDUNIDAD_AGENCIA = ll_idunidad_agencia_origen
            l_objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = ll_idunidad_agencia_destino
            Try
                objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(Me.cmb_sub_cuenta.SelectedIndex.ToString))
            Catch ex As Exception
                l_objGuiaEnvio.iIDCENTRO_COSTO = 0
            End Try
            'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
            If l_objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                tarifa_Peso = l_objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = l_objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = l_objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = l_objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = l_objGuiaEnvio.iTarifa_Publica_Monto_Sobre
                ' Se debe asiginar los nuevos montos  a la guía de envío 
                flag = True
                bControl_Tarifas = True
            ElseIf l_objGuiaEnvio.fnTARIFA_PUBLICA_CARGA() = True Then 'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
                flag = True
                bControl_Tarifas = True
            Else
                flag = False
                MsgBox("NO EXISTE TARIFA PARA ESTE ORIGEN Y DESTINO, NI ASOCIADO A UNA TARIFA DEL CLIENTE", MsgBoxStyle.Information, "REVISE SUS DATOS")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flag
    End Function
    Private Sub llenar_collections()
        Dim flag As Boolean = False
        Dim mostrar_pre_guias As Boolean

        Try
            '
            l_objGuiaEnvio.iControl_Busqueda = 2 ' Recupera los datos existentes del cliente
            l_objGuiaEnvio.sNRO_GUIA = CType(Me.txt_nro_guia.Text, String)
            l_objGuiaEnvio.iIDUNIDAD_AGENCIA = ll_idunidad_agencia_origen
            l_objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = ll_idunidad_agencia_destino
            l_objGuiaEnvio.iIDCENTRO_COSTO = 999 ' Por defecto se pondrá el generico  
            'Mod. 22/08/2009 -->Omendoza - Pasando al datahelper   
            If l_objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC_CC() = True Then
                flag = True
                Me.txt_vcodigo_cliente.Text = l_objGuiaEnvio.sNU_DOCU_SUNAT.ToString
                Me.txt_razon_social.Text = l_objGuiaEnvio.sRASON_SOCIAL.ToString
                '
                Me.txt_remitente.Text = Me.txt_razon_social.Text
                Me.txt_doc_remitente.Text = Me.txt_vcodigo_cliente.Text
                '
                lab_tipo_facturacion.Text = "Facturación Tipo : " + l_objGuiaEnvio.iIDTipoFacturacion.ToString
                '
                If l_objGuiaEnvio.iCARGO = 1 Then
                    Me.chk_cargo.Checked = True
                Else
                    Me.chk_cargo.Checked = False
                End If
                '
                'If mostrar_pre_guias = True Then
                'If l_objGuiaEnvio.cur_Sub_Cuenta.EOF = False And l_objGuiaEnvio.cur_Sub_Cuenta.BOF = False Then
                If l_objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                    'Por defecto toma este valor 
                    'dv_centro_costo = CargarCombo(Me.cmb_sub_cuenta, dt_centro_costo, "Centro_Costo ", "Idcentro_Costo", 999)
                    '
                    'ModuUtil.LlenarComboIDs(l_objGuiaEnvio.cur_Sub_Cuenta, Me.cmb_sub_cuenta, l_objGuiaEnvio.coll_Sub_Cuenta, l_objGuiaEnvio.IDCENTRO_COSTO)
                    ModuUtil.LlenarComboIDs_dt(l_objGuiaEnvio.dt_cur_Sub_Cuenta, Me.cmb_sub_cuenta, l_objGuiaEnvio.coll_Sub_Cuenta, l_objGuiaEnvio.IDCENTRO_COSTO)
                    Me.cmb_sub_cuenta.SelectedIndex = 0
                End If
                'End If
                'Obtiene los datos del Contacto corriente 
                'If l_objGuiaEnvio.cur_Nombres_Remitente.BOF = False And l_objGuiaEnvio.cur_Nombres_Remitente.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDCONTACTO_PERSONA = Int(l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    Me.txt_remitente.Text = l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    Me.txt_doc_remitente.Text = l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                    fnCargar_iWin2_dt2(Me.txt_remitente, l_objGuiaEnvio.dt_cur_Nombres_Remitente, l_objGuiaEnvio.coll_Nombres_Remitente, l_iWinContacto_Remitente, l_objGuiaEnvio.iIDCONTACTO_PERSONA, l_iWinPerosaDNI_Remite)
                Else
                    l_objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    Me.txt_remitente.Text = ""
                    Me.txt_doc_remitente.Text = ""
                End If
                '//CONTACTO DIRECCIONES
                'If l_objGuiaEnvio.cur_Direccion_Remitente.BOF = False And l_objGuiaEnvio.cur_Direccion_Remitente.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    '
                    l_objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    Me.txt_direccion_remitente.Text = l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    fnCargar_iWin_dt(Me.txt_direccion_remitente, l_objGuiaEnvio.dt_cur_Direccion_Remitente, l_objGuiaEnvio.coll_Direccion_Remitente, l_iWinDireccion_Remitente, l_objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Else
                    Me.txt_direccion_remitente.Text = ""
                    l_objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                End If

                Me.txt_telefono_remitente.Text = ""
                l_objGuiaEnvio.iIDTEFONO_REMITENTE = -1

                '//DESTINATARIO DESTINATARIO
                'If l_objGuiaEnvio.cur_Nombres_Destinatario.BOF = False And l_objGuiaEnvio.cur_Nombres_Destinatario.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(l_objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                    Me.txt_consignado.Text = l_objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                    Me.txt_direccion_destinatario.Text = l_objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                    fnCargar_iWin2_dt2(Me.txt_consignado, l_objGuiaEnvio.dt_cur_Nombres_Destinatario, l_objGuiaEnvio.coll_Nombres_Destinatario, l_iWinContacto_Destinatario, l_objGuiaEnvio.iIDCONTACTO_DESTINATARIO, l_iWinPerosaDNI_Destino)
                Else
                    l_objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                    Me.txt_consignado.Text = ""
                    Me.txtnrodoc_destinatario.Text = ""
                End If

                '1 Agencia
                '2 Domicilio

                'Dim idTipoDire As Integer = Me.cmb_tipo_entrega.SelectedValue
                'If idTipoDire = 2 Then
                'If l_objGuiaEnvio.cur_Direccion_Destinatario.BOF = False And l_objGuiaEnvio.cur_Direccion_Destinatario.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                    Me.txt_direccion_destinatario.Text = l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                    fnCargar_iWin_dt(Me.txt_direccion_destinatario, l_objGuiaEnvio.dt_cur_Direccion_Destinatario, l_objGuiaEnvio.coll_Direccion_Destinatario, l_iWinDireccion_Destinatario, l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                Else
                    l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                    Me.txt_direccion_destinatario.Text = ""
                End If
                ' End If
                '
                Me.txt_telefono_destinatario.Text = ""
                l_objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Function BuscarClientesGuia_Envio() As Boolean
        Dim flag As Boolean = False
        Dim indexof As Integer = 0
        ''
        Try
            ' Como se encontro el id de la persona 
            ' Estos son los datos del cliente 
            '
            'l_objGuiaEnvio.idpersona 
            'l_objGuiaEnvio.iIDUNIDAD_AGENCIA()
            '
            l_objGuiaEnvio.iCONTROL = 2 ' Se tiene los datos del cliente 
            'Mod. 28/08/2009 -->Omendoza - Pasando al datahelper
            If l_objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC() = True Then
                '//CONTACTO REMITENTE
                'If l_objGuiaEnvio.cur_Nombres_Remitente.BOF = False And l_objGuiaEnvio.cur_Nombres_Remitente.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDCONTACTO_PERSONA = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0)) = True, -1, Int(l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString))
                    Me.txt_remitente.Text = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1)) = True, "", l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString)
                    Me.txt_doc_remitente.Text = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2)) = True, "", l_objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString)
                    '
                    fnCargar_iWin2(txt_remitente, l_objGuiaEnvio.dt_cur_Nombres_Remitente, l_objGuiaEnvio.coll_Nombres_Remitente, l_iWinContacto_Remitente, l_objGuiaEnvio.iIDCONTACTO_PERSONA, l_iWinPerosaDNI_Remite)
                Else
                    l_objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    Me.txt_remitente.Text = ""
                    Me.txt_doc_remitente.Text = ""
                End If
                '//CONTACTO DIRECCIONES
                'If l_objGuiaEnvio.cur_Direccion_Remitente.BOF = False And l_objGuiaEnvio.cur_Direccion_Remitente.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDDIRECCION_REMITENTE = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString) = True, -1, Int(l_objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString))
                    Me.txt_direccion_remitente.Text = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString) = True, -1, l_objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString)
                    fnCargar_iWin_dt(Me.txt_direccion_remitente, l_objGuiaEnvio.dt_cur_Direccion_Remitente, l_objGuiaEnvio.coll_Direccion_Remitente, l_iWinDireccion_Remitente, l_objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Else
                    Me.txt_direccion_remitente.Text = ""
                    l_objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                End If

                '//CONTACTO TELEFONOS
                'If l_objGuiaEnvio.cur_Telefono_Remitente.BOF = False And l_objGuiaEnvio.cur_Telefono_Remitente.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Telefono_Remitente.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDTEFONO_REMITENTE = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Telefono_Remitente.Rows(0).Item(0)) = True, -1, Int(l_objGuiaEnvio.dt_cur_Telefono_Remitente.Rows(0).Item(0).ToString))
                    Me.txt_telefono_remitente.Text = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Telefono_Remitente.Rows(0).Item(1)) = True, "", l_objGuiaEnvio.dt_cur_Telefono_Remitente.Rows(0).Item(1).ToString)
                    fnCargar_iWin_dt(Me.txt_telefono_remitente, l_objGuiaEnvio.dt_cur_Telefono_Remitente, l_objGuiaEnvio.coll_Telefono_Remitente, l_iWinTelefono_Remitente, l_objGuiaEnvio.iIDTEFONO_REMITENTE)
                Else
                    Me.txt_telefono_remitente.Text = ""
                    l_objGuiaEnvio.iIDTEFONO_REMITENTE = -1
                End If

                ''//DESTINATARIO DESTINATARIO
                'If l_objGuiaEnvio.cur_Nombres_Destinatario.BOF = False And l_objGuiaEnvio.cur_Nombres_Destinatario.EOF = False Then
                '    l_objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(l_objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(0).Value.ToString)
                '    txtDestinatario.Text = objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(1).Value.ToString
                '    txtDNIDestinatario.Text = objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(2).Value.ToString
                '    fnCargar_iWin(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContato_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO)
                '    fnCargar_iWin2(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
                'Else
                '    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                '    txtDestinatario.Text = ""
                '    txtDNIDestinatario.Text = ""
                'End If


                'If l_objGuiaEnvio.cur_Direccion_Destinatario.BOF = False And l_objGuiaEnvio.cur_Direccion_Destinatario.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0)) = True, -1, Int(l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString))
                    Me.txt_direccion_destinatario.Text = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1)) = True, "", l_objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString)
                    fnCargar_iWin_dt(Me.txt_direccion_destinatario, l_objGuiaEnvio.dt_cur_Direccion_Destinatario, l_objGuiaEnvio.coll_Direccion_Destinatario, l_iWinDireccion_Destinatario, l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                Else
                    l_objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                    Me.txt_direccion_destinatario.Text = ""
                End If
                '
                'If l_objGuiaEnvio.cur_Telefono_Destinatario.BOF = False And l_objGuiaEnvio.cur_Telefono_Destinatario.EOF = False Then
                If l_objGuiaEnvio.dt_cur_Telefono_Destinatario.Rows.Count > 0 Then
                    l_objGuiaEnvio.iIDTEFONO_CONSIGNADO = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Telefono_Destinatario.Rows(0).Item(0)) = True, -1, Int(l_objGuiaEnvio.dt_cur_Telefono_Destinatario.Rows(0).Item(0).ToString))
                    Me.txt_telefono_destinatario.Text = IIf(IsDBNull(l_objGuiaEnvio.dt_cur_Telefono_Destinatario.Rows(0).Item(1)) = True, "", l_objGuiaEnvio.dt_cur_Telefono_Destinatario.Rows(0).Item(1).ToString)
                    fnCargar_iWin_dt(Me.txt_telefono_destinatario, l_objGuiaEnvio.dt_cur_Telefono_Destinatario, l_objGuiaEnvio.coll_Telefono_Destinatario, l_iWinTelefono_Destinatario, l_objGuiaEnvio.iIDTEFONO_CONSIGNADO)
                Else
                    l_objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
                    Me.txt_telefono_destinatario.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error Interno...Verificar Datos", MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End Try
        Return flag
    End Function
#End Region
End Class