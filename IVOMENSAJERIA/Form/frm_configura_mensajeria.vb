Public Class frm_configura_mensajeria
#Region "Variables"
    'Connexion a la BD 
    'Dim odbda As New OleDb.OleDbDataAdapter
    'Clase - Dto 
    Dim obj_config_mensajeria As New dtoConfig_mensajeria
    '
    'Dim rst_estado_envio, rst_parametros_msg, rst_recupera_config As New ADODB.Recordset
    Dim dt_estado_envio, dt_parametros_msg, dt_recupera_config As New DataTable
    Dim dv_estado_envio, dv_parametros_msg, dv_recupera_config As New DataView
    ' 
    Dim li_ubica_focus As Integer
    Dim li_control As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long
    '
#End Region
#Region "Eventos"

    Private Sub frm_configura_mensajeria_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frm_configura_mensajeria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'Load 
    Private Sub frm_configura_mensajeria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Oculta el trevieew 
            Me.MyTreeView.Visible = False
            'Contrae el Treview ocultar 
            SplitContainer2.Panel1Collapsed = False
            ' 
            MenuStrip1.Items(0).Enabled = False
            MenuStrip1.Items(1).Enabled = False
            MenuStrip1.Items(2).Enabled = False
            MenuStrip1.Items(3).Enabled = False
            MenuStrip1.Items(4).Enabled = False

            '
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "CONFIG. MENSAJERIA [" & dtoUSUARIOS.iLOGIN & " ] Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            Me.ShadowLabel1.Text = "Configuración Mensajería"
            ' 
            'datahelper
            'rst_estado_envio = obj_config_mensajeria.fn_Listar_Config_mensajeria
            'rst_parametros_msg = rst_estado_envio.NextRecordset
            'rst_recupera_config = rst_estado_envio.NextRecordset
            'odbda.Fill(dt_estado_envio, rst_estado_envio)
            'odbda.Fill(dt_parametros_msg, rst_parametros_msg)
            'dv_parametros_msg = dt_parametros_msg.DefaultView
            'odbda.Fill(dt_recupera_config, rst_recupera_config)
            'dv_recupera_config = dt_recupera_config.DefaultView
            Dim ds As DataSet = obj_config_mensajeria.fn_Listar_Config_mensajeria
            dt_estado_envio = ds.Tables(0)
            dt_parametros_msg = ds.Tables(1)
            dt_recupera_config = ds.Tables(2)
            dv_parametros_msg = dt_parametros_msg.DefaultView
            dv_recupera_config = dt_recupera_config.DefaultView
            ' Llenando el combox 
            dv_estado_envio = CargarCombo(Me.cmbestado_envio, dt_estado_envio, "ESTADO_REGISTRO", "IDESTADO_REGISTRO", 18)  ' Por defecto 18 Registrado  
            '
            Call grilla_parametros()
            Call grilla_config_mensaje()
            '
            Me.dgv_parametros.DataSource = dv_parametros_msg
            Me.dgv_mensaje.DataSource = dv_recupera_config
            ' 
            fn_obt_estado(18) ' Por defecto mostrara el campo 18 
            '                        
            li_ubica_focus = 0 ' No está en ningún campo especifico   
            '0

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            '
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    'Salir 
    Private Sub frm_configura_mensajeria_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub
    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        'Graba e invoca a lectura de la configuración 
        actualizando_datos()
    End Sub
    Private Sub txt_mensaje_celular_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mensaje_celular.GotFocus
        li_ubica_focus = 1
    End Sub
    Private Sub txt_mensaje_celular_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mensaje_celular.TextChanged
        li_ubica_focus = 1
        Me.btn_agregar.Enabled = True
    End Sub
    'txt_cab_email
    Private Sub txt_cab_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cab_email.GotFocus
        li_ubica_focus = 2
    End Sub
    Private Sub txt_cab_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cab_email.TextChanged
        li_ubica_focus = 2
        Me.btn_agregar.Enabled = True
    End Sub
    'txt_mensaje_email
    Private Sub txt_mensaje_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mensaje_email.GotFocus
        li_ubica_focus = 3
    End Sub
    Private Sub txt_mensaje_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mensaje_email.TextChanged
        li_ubica_focus = 3
        Me.btn_agregar.Enabled = True
    End Sub
    'txt_cab_cons_email
    Private Sub txt_cab_cons_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cab_cons_email.GotFocus
        li_ubica_focus = 4
    End Sub
    Private Sub txt_cab_cons_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cab_cons_email.TextChanged
        li_ubica_focus = 4
        Me.btn_agregar.Enabled = True
    End Sub
    'txt_mensaje_cons_email
    Private Sub txt_mensaje_cons_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mensaje_cons_email.GotFocus
        li_ubica_focus = 5
    End Sub
    Private Sub txt_mensaje_cons_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mensaje_cons_email.TextChanged
        li_ubica_focus = 5
        Me.btn_agregar.Enabled = True
    End Sub
    ' cmbestado_envio
    Private Sub cmbestado_envio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbestado_envio.SelectedIndexChanged
        Try
            Dim ll_estado_envio As Long
            'Dim lrst_datos_config_mensajeria As New ADODB.Recordset
            Dim ldt_datos_config_mensajeria As New DataTable
            '
            Me.btn_agregar.Enabled = False
            '
            'Recupera información si existe 
            If cmbestado_envio.SelectedIndex >= 0 Then
                fn_obt_estado(CType(cmbestado_envio.SelectedValue, Long))
                'll_estado_envio = CType(cmbestado_envio.SelectedValue, Long)
                'Me.dgv_parametros.Columns.Clear()  ' Limpiando mantenimiento 
                'dt_parametros_msg = Nothing
                'dv_parametros_msg = Nothing
                'dt_parametros_msg = New DataTable
                'dv_parametros_msg = New DataView
                ''Recupera los parametros 
                'obj_config_mensajeria._MyIDESTADO_ENVIO = ll_estado_envio
                'rst_parametros_msg = obj_config_mensajeria.fn_recupera_parametro_xestado_envio()
                'lrst_datos_config_mensajeria = rst_parametros_msg.NextRecordset
                ''
                'odbda.Fill(dt_parametros_msg, rst_parametros_msg)
                'odbda.Fill(ldt_datos_config_mensajeria, lrst_datos_config_mensajeria)
                ''
                'dv_parametros_msg = dt_parametros_msg.DefaultView
                'grilla_parametros()
                ''Recuperado los nuevos parametros 
                'Me.dgv_parametros.DataSource = dv_parametros_msg
                'recupera_campos_configuracion(ldt_datos_config_mensajeria)

                '
            End If
        Catch ex As Exception
        End Try
    End Sub
    'dgv_Parametros 
    Private Sub dgv_parametros_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_parametros.DoubleClick
        Try
            Dim ls_mensaje As String
            Dim lli_ubica_focus As Integer
            Dim dgvr As DataGridViewRow
            'Recuperando el valor del dato  
            dgvr = Me.dgv_parametros.CurrentRow
            If IsDBNull(dgvr) = False Then
                If IsDBNull(dgvr.Cells("parametro_msg").Value) = False Then
                    ls_mensaje = " " + CType(dgvr.Cells("parametro_msg").Value, String) + " "
                End If
            Else
                MsgBox("No se ha seleccionado el parámetro correspondiente", MsgBoxStyle.Information, "Sistema configuración de Mensajería")
                Exit Sub
            End If
            '
            lli_ubica_focus = li_ubica_focus
            li_ubica_focus = 0
            '
            If lli_ubica_focus = 1 Then
                Me.txt_mensaje_celular.Text = Me.txt_mensaje_celular.Text + ls_mensaje
                Me.txt_mensaje_celular.Focus()
                Exit Sub
            End If
            If lli_ubica_focus = 2 Then
                Me.txt_cab_email.Text = Me.txt_cab_email.Text + ls_mensaje
                Me.txt_cab_email.Focus()
                Exit Sub
            End If
            If lli_ubica_focus = 3 Then
                Me.txt_mensaje_email.Text = Me.txt_mensaje_email.Text + ls_mensaje
                Me.txt_mensaje_email.Focus()
                Exit Sub
            End If
            If lli_ubica_focus = 4 Then
                Me.txt_cab_cons_email.Text = Me.txt_cab_cons_email.Text + ls_mensaje
                Me.txt_cab_cons_email.Focus()
                Exit Sub
            End If
            '
            If lli_ubica_focus = 5 Then
                Me.txt_mensaje_cons_email.Text = Me.txt_mensaje_cons_email.Text + ls_mensaje
                Me.txt_mensaje_cons_email.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    'dgv_mensaje
    Private Sub dgv_mensaje_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_mensaje.DoubleClick
        Try
            Dim ll_idestado_envio As Long
            'datahelper
            'Dim lrst_datos_config_mensajeria As New ADODB.Recordset
            Dim lrst_datos_config_mensajeria As DataTable
            Dim ldt_datos_config_mensajeria As New DataTable
            Dim dgvr As DataGridViewRow
            'Recuperando el valor del dato  
            dgvr = Me.dgv_mensaje.CurrentRow
            If IsDBNull(dgvr) = True Then
                MsgBox("No se ha seleccionado ningún estado para su configuración", MsgBoxStyle.Information, "Sistema configuración de Mensajería")
                Exit Sub
            End If
            '
            Me.btn_agregar.Enabled = False
            '
            'If IsDBNull(dgvr.Cells("parametro_msg").Value) = False Then
            ll_idestado_envio = CType(dgvr.Cells("idestado_envio").Value, Long)
            Me.cmbestado_envio.SelectedValue = ll_idestado_envio
            obj_config_mensajeria._MyIDESTADO_ENVIO = ll_idestado_envio
            'datahelper
            'lrst_datos_config_mensajeria = obj_config_mensajeria.fn_recupera_datos_config_mensajeria()
            'odbda.Fill(ldt_datos_config_mensajeria, lrst_datos_config_mensajeria)
            'recupera_campos_configuracion(ldt_datos_config_mensajeria)
            lrst_datos_config_mensajeria = obj_config_mensajeria.fn_recupera_datos_config_mensajeria()
            ldt_datos_config_mensajeria = lrst_datos_config_mensajeria
            recupera_campos_configuracion(ldt_datos_config_mensajeria)
            ' 
            'End If
        Catch ex As Exception
            '
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Sub grilla_parametros()
        Try
            Me.dgv_parametros.Columns.Clear()
            With Me.dgv_parametros
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .ReadOnly = False
                .AutoGenerateColumns = False
                ' .DataSource = DvDetaDoc 
                '.DataSource = DvDetalle
                .VirtualMode = True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim sparametro_msg As New DataGridViewTextBoxColumn
            With sparametro_msg
                .DataPropertyName = "parametro_msg"
                .Name = "parametro_msg"
                .HeaderText = "Parámetro"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = True
            End With
            Me.dgv_parametros.Columns.Add(sparametro_msg)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .DataPropertyName = "idparametros_msg"
                .Name = "idparametros_msg"
                .HeaderText = "Id Parámetro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = True
                .Visible = False
            End With
            Me.dgv_parametros.Columns.Add(col1)
        Catch ex As Exception
            MsgBox("Error al configurar los parámetros de mensajeria", MsgBoxStyle.Exclamation, "Configuración Mensajeria")
        End Try
    End Sub
    Sub grilla_config_mensaje()
        Try
            Me.dgv_mensaje.Columns.Clear()
            With Me.dgv_mensaje
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = DvDetalle
                .VirtualMode = True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With

            Dim sestado_registro As New DataGridViewTextBoxColumn
            With sestado_registro
                .DataPropertyName = "estado_registro"
                .Name = "estado_registro"
                .HeaderText = "Estado"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = True
            End With
            Me.dgv_mensaje.Columns.Add(sestado_registro)

            Dim stxt_msg_movil As New DataGridViewTextBoxColumn
            With stxt_msg_movil
                .DataPropertyName = "txt_msg_movil"
                .Name = "txt_msg_movil"
                .HeaderText = "Mensaje Móvil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet 'FILL
                .ReadOnly = True
            End With
            Me.dgv_mensaje.Columns.Add(stxt_msg_movil)
            '
            Dim stxt_msg_email_cab As New DataGridViewTextBoxColumn
            With stxt_msg_email_cab
                .DataPropertyName = "txt_msg_email_cab"
                .Name = "txt_msg_email_cab"
                .HeaderText = "Asunto Mail"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                '.Visible = False
            End With
            Me.dgv_mensaje.Columns.Add(stxt_msg_email_cab)
            '
            Dim stxt_msg_email As New DataGridViewTextBoxColumn
            With stxt_msg_email
                .DataPropertyName = "txt_msg_email"
                .Name = "txt_msg_email"
                .HeaderText = "Mensaje Mail"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            Me.dgv_mensaje.Columns.Add(stxt_msg_email)
            '
            Dim stxt_msg_consolidado_cab As New DataGridViewTextBoxColumn
            With stxt_msg_consolidado_cab
                .DataPropertyName = "txt_msg_consolidado_cab"
                .Name = "txt_msg_consolidado_cab"
                .HeaderText = "Asunto Consolidado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            Me.dgv_mensaje.Columns.Add(stxt_msg_consolidado_cab)
            '
            Dim stxt_msg_consolidado As New DataGridViewTextBoxColumn
            With stxt_msg_consolidado
                .DataPropertyName = "txt_msg_consolidado"
                .Name = "txt_msg_consolidado"
                .HeaderText = "Mensaje consolidado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            Me.dgv_mensaje.Columns.Add(stxt_msg_consolidado)
            '
            Dim sidconfig_txt_msg As New DataGridViewCheckBoxColumn
            With sidconfig_txt_msg
                .DataPropertyName = "idconfig_txt_msg"
                .Name = "idconfig_txt_msg"
                .HeaderText = "Id Configuración"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = True
                .Visible = False
            End With
            Me.dgv_mensaje.Columns.Add(sidconfig_txt_msg)

            Dim sidestado_envio As New DataGridViewCheckBoxColumn
            With sidestado_envio
                .DataPropertyName = "idestado_envio"
                .Name = "idestado_envio"
                .HeaderText = "Id Envío"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = True
                .Visible = False
            End With
            Me.dgv_mensaje.Columns.Add(sidestado_envio)

        Catch ex As Exception

        End Try
    End Sub
    Sub recupera_campos_configuracion(ByVal adv_parametros_msg As DataTable)
        Try
            li_control = 0
            If adv_parametros_msg.Rows.Count > 1 Then
                MsgBox("Existen muchos registros, comunicarse con sistemas.", MsgBoxStyle.Information, "Sistema Configuración Mensajeria")
                Exit Sub
            End If
            If adv_parametros_msg.Rows.Count = 1 Then
                If IsDBNull(adv_parametros_msg.Rows(0)(0)) = True Then
                    Me.txt_mensaje_celular.Text = ""
                Else
                    Me.txt_mensaje_celular.Text = CType(adv_parametros_msg.Rows(0)(0), String)
                End If
                '
                If IsDBNull(adv_parametros_msg.Rows(0)(1)) = True Then
                    Me.txt_cab_email.Text = ""
                Else
                    Me.txt_cab_email.Text = CType(adv_parametros_msg.Rows(0)(1), String)
                End If
                '
                If IsDBNull(adv_parametros_msg.Rows(0)(2)) = True Then
                    Me.txt_mensaje_email.Text = ""
                Else
                    Me.txt_mensaje_email.Text = CType(adv_parametros_msg.Rows(0)(2), String)
                End If
                If IsDBNull(adv_parametros_msg.Rows(0)(3)) = True Then
                    Me.txt_cab_cons_email.Text = ""
                Else
                    Me.txt_cab_cons_email.Text = CType(adv_parametros_msg.Rows(0)(3), String)
                End If

                If IsDBNull(adv_parametros_msg.Rows(0)(4)) = True Then
                    Me.txt_mensaje_cons_email.Text = ""
                Else
                    Me.txt_mensaje_cons_email.Text = CType(adv_parametros_msg.Rows(0)(4), String)
                End If
                Me.txt_idconfig_mensajeria.Text = CType(adv_parametros_msg.Rows(0)(5), String)
                li_control = 2
            Else ' En caso Contrario Limpiar parámetros 
                Me.txt_cab_email.Text = ""
                Me.txt_mensaje_email.Text = ""
                Me.txt_cab_cons_email.Text = ""
                Me.txt_mensaje_cons_email.Text = ""
                Me.txt_mensaje_celular.Text = ""
                Me.txt_idconfig_mensajeria.Text = ""
                li_control = 1
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    Sub limpiar_variables()
        Me.txt_cab_email.Text = ""
        Me.txt_mensaje_email.Text = ""
        Me.txt_cab_cons_email.Text = ""
        Me.txt_mensaje_cons_email.Text = ""
        Me.txt_mensaje_celular.Text = ""
        Me.txt_idconfig_mensajeria.Text = ""
    End Sub
    Sub actualizando_datos()
        Try
            Dim ls_mensaje As String
            Dim ll_cod_mensaje As Long
            'datahelper
            'Dim lrst_graba As New ADODB.Recordset
            Dim lrst_graba As DataTable

            Dim dv_estado_envio, dv_parametros_msg, dv_recupera_config As New DataView
            '
            If Me.txt_cab_cons_email.Text = "" Then
                obj_config_mensajeria._MyTXT_MSG_CONSOLIDADO_CAB = "null"
            Else
                obj_config_mensajeria._MyTXT_MSG_CONSOLIDADO_CAB = Me.txt_cab_cons_email.Text
            End If
            If Me.txt_mensaje_cons_email.Text = "" Then
                obj_config_mensajeria._MyTXT_MSG_CONSOLIDADO = "null"
            Else
                obj_config_mensajeria._MyTXT_MSG_CONSOLIDADO = Me.txt_mensaje_cons_email.Text
            End If
            If Me.txt_cab_email.Text = "" Then
                obj_config_mensajeria._MyTXT_MSG_EMAIL_CAB = "null"
            Else
                obj_config_mensajeria._MyTXT_MSG_EMAIL_CAB = Me.txt_cab_email.Text
            End If
            If Me.txt_mensaje_email.Text = "" Then
                obj_config_mensajeria._MyTXT_MSG_EMAIL = "null"
            Else
                obj_config_mensajeria._MyTXT_MSG_EMAIL = Me.txt_mensaje_email.Text
            End If
            If Me.txt_mensaje_celular.Text = "" Then
                obj_config_mensajeria._MyTXT_MSG_MOVIL = "null"
            Else
                obj_config_mensajeria._MyTXT_MSG_MOVIL = Me.txt_mensaje_celular.Text
            End If
            If Me.txt_idconfig_mensajeria.Text = "" Then
                obj_config_mensajeria._MyIDCONFIG_TXT_MSG = -666
                obj_config_mensajeria._Mycontrol = 1
            Else
                obj_config_mensajeria._MyIDCONFIG_TXT_MSG = CType(Me.txt_idconfig_mensajeria.Text, Long)
                obj_config_mensajeria._Mycontrol = 2
            End If
            '
            obj_config_mensajeria._MyIDESTADO_ENVIO = Me.cmbestado_envio.SelectedValue
            obj_config_mensajeria._MyIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            obj_config_mensajeria._MyIP = dtoUSUARIOS.IP
            obj_config_mensajeria._MyIDESTADO_REGISTRO = 1 'Siempre va hacer activo (1)
            ' 
            'datahelper
            'lrst_graba = obj_config_mensajeria.fn_grabar_Config_mensajeria()
            Dim ds As DataSet = obj_config_mensajeria.fn_grabar_Config_mensajeria()
            lrst_graba = ds.Tables(0)
            'datahelper
            'If IsDBNull(lrst_graba.Fields.Item("cod_mensaje").Value) = True Then
            'End If
            'll_cod_mensaje = CType(lrst_graba.Fields.Item("cod_mensaje").Value, Long)
            'ls_mensaje = CType(lrst_graba.Fields.Item("mensaje").Value, String)
            If IsDBNull(lrst_graba.Rows(0).Item("cod_mensaje")) = True Then
            End If
            ll_cod_mensaje = CType(lrst_graba.Rows(0).Item("cod_mensaje"), Long)
            ls_mensaje = CType(lrst_graba.Rows(0).Item("mensaje"), String)

            If ll_cod_mensaje <> 0 Then
                MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Sistema Configuración Mensaje")
                Exit Sub
            Else
                'datahelper
                'rst_recupera_config = lrst_graba.NextRecordset
                dt_recupera_config = Nothing
                dt_recupera_config = ds.Tables(1)
                dv_recupera_config = Nothing
                'dt_recupera_config = New DataTable
                dv_recupera_config = New DataView
                'datahelper
                'odbda.Fill(dt_recupera_config, rst_recupera_config)
                dv_recupera_config = dt_recupera_config.DefaultView
                Call grilla_config_mensaje()
                '
                Me.dgv_mensaje.DataSource = dv_recupera_config
                '
                'limpiar_variables()
                MessageBox.Show("Datos actualizados", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btn_agregar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    'Recupera el estado 
    Sub fn_obt_estado(ByVal all_estado_envio As Long)
        Try
            '
            Dim ll_estado_envio As Long
            'Dim lrst_datos_config_mensajeria As New ADODB.Recordset
            Dim ldt_datos_config_mensajeria As New DataTable
            '
            ll_estado_envio = all_estado_envio
            Me.dgv_parametros.Columns.Clear()  ' Limpiando mantenimiento 
            dt_parametros_msg = Nothing
            dv_parametros_msg = Nothing
            dt_parametros_msg = New DataTable
            dv_parametros_msg = New DataView
            'Recupera los parametros 
            obj_config_mensajeria._MyIDESTADO_ENVIO = ll_estado_envio
            'datahelper
            'rst_parametros_msg = obj_config_mensajeria.fn_recupera_parametro_xestado_envio()
            Dim ds As DataSet = obj_config_mensajeria.fn_recupera_parametro_xestado_envio()
            dt_parametros_msg = ds.Tables(0)
            'datahelper
            'lrst_datos_config_mensajeria = rst_parametros_msg.NextRecordset
            ldt_datos_config_mensajeria = ds.Tables(1)
            '
            dv_parametros_msg = dt_parametros_msg.DefaultView
            grilla_parametros()
            'Recuperado los nuevos parametros 
            Me.dgv_parametros.DataSource = dv_parametros_msg
            recupera_campos_configuracion(ldt_datos_config_mensajeria)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
#End Region
End Class
