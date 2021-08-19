Public Class frm_recepcion_quitarbultos
#Region "Variables"
    Dim obj_recepcion_quitar_bultos As New dtorecepcion_quitar_bultos
    'Dim odba_gt As New OleDb.OleDbDataAdapter
    Dim dt_guia_transp, dt_guia_transp_det As New DataTable
    Dim dv_guia_transp, dv_guia_transp_det As New DataView
    '    
    Dim ll_idusuario_piloto As Long
    Dim ll_idagencia_origen_gt As Long
    Dim lb_actuliza_grilla As Boolean
    Dim lb_paso As Boolean
    Dim bIngreso As Boolean = False
    Public hnd As Long
    '
#End Region
#Region "Evento Adicionales"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Evento"

    Private Sub frm_recepcion_quitarbultos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frm_recepcion_quitarbultos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    ' Load 
    Private Sub frm_recepcion_quitarbultos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.cboTipoComprobante.SelectedIndex = 0
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "Sacar bultos Enviados" & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            ToolStripMenuItem1.Text = "&Guia Transportista"
            SelectMenu(0)
            fnload_grilla()
            lb_actuliza_grilla = False
            lb_paso = False
            '
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    'txt_dcto
    Private Sub txt_dcto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dcto.Leave
        'Dim lrst_gt As New ADODB.Recordset
        Dim dt_gt As New DataTable
        Try
            If Me.txt_dcto.Text <> "" Then
                '
                obj_recepcion_quitar_bultos.nro_dcto = txt_dcto.Text
                obj_recepcion_quitar_bultos.TipoComprobante = Me.cboTipoComprobante.SelectedIndex
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'lrst_gt = obj_recepcion_quitar_bultos.fn_recupera_gt()
                'odba_gt.Fill(dt_gt, lrst_gt)
                '
                dt_gt = obj_recepcion_quitar_bultos.fn_recupera_gt()
                If dt_gt.Rows.Count < 1 Then
                    MsgBox("No se encontró documento asociado a la guía de transportista", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                    Me.txt_dcto.Text = ""
                End If
                '
                If dt_gt.Rows.Count = 1 Then
                    txt_guia_transportista.Text = CType(dt_gt.Rows(0)(1), String)
                    recupera_datos()
                End If
                If dt_gt.Rows.Count > 1 Then
                    Dim obj_get_gt As New frmrecuperaguias_transportista
                    'recupera la  lista de guia de transportista 
                    obj_get_gt.dt_gt = dt_gt.Copy
                    'obj_get_gt.ShowDialog()
                    Acceso.Asignar(obj_get_gt, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        obj_get_gt.ShowDialog()
                    Else
                        MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    If Not obj_get_gt.lb_cancela Then
                        txt_guia_transportista.Text = obj_get_gt.ls_idguia_transportista
                        recupera_datos()
                    End If
                End If
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    'Txt_guia_transportista 
    Private Sub txt_guia_transportista_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_guia_transportista.Leave
        'Dim lrst_guia_transportista, lrst_guia_transportista_det As New ADODB.Recordset
        Try
            'Recupera los datos de la guia de transportista
            If txt_guia_transportista.Text <> "" And Len(txt_guia_transportista.Text) > 0 Then
                '
                recupera_datos()
                'limpia_cabecera()
                ''
                'dt_guia_transp = Nothing
                'dt_guia_transp_det = Nothing
                ''
                'dv_guia_transp = Nothing
                'dv_guia_transp_det = Nothing
                ''
                'dt_guia_transp = New DataTable
                'dt_guia_transp_det = New DataTable
                ''
                'dv_guia_transp = New DataView
                'dv_guia_transp_det = New DataView
                ''
                'obj_recepcion_quitar_bultos.guia_transportista = txt_guia_transportista.Text
                'lrst_guia_transportista = obj_recepcion_quitar_bultos.fn_guia_transportista
                'lrst_guia_transportista_det = lrst_guia_transportista.NextRecordset
                ''
                'odba_gt.Fill(dt_guia_transp, lrst_guia_transportista)
                ''
                'fnload_grilla()
                'If dt_guia_transp.Rows.Count < 1 Then
                '    MsgBox("No se encontró la guía de transportista", MsgBoxStyle.Information, "Sistema de Recepción")
                '    Me.txt_guia_transportista.Text = ""
                '    Me.txt_guia_transportista.Focus()
                'End If
                ''
                ''Recupera cabecera
                'recupera_cabecera(dt_guia_transp)
                'odba_gt.Fill(dt_guia_transp_det, lrst_guia_transportista_det)
                ''
                'dv_guia_transp_det = dt_guia_transp_det.DefaultView
                'fnload_grilla()
                'DGV_gt_det.DataSource = dv_guia_transp_det
                '
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de seguridad")
        End Try
    End Sub
    Private Sub DGV_gt_det_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_gt_det.CellEndEdit
        Try
            'Dim dgvr As New DataGridViewRow
            'Dim fila As New Integer
            'dgvr = Me.DGV_gt_det.CurrentRow
            'fila = dgvr.Index
            '
            If e.ColumnIndex = 4 Then
                If lb_actuliza_grilla = True Then
                    fnload_grilla()
                    DGV_gt_det.DataSource = dv_guia_transp_det
                    '                    DGV_gt_det.CurrentCell = DGV_gt_det.Rows(fila).Cells()
                End If
                lb_actuliza_grilla = False
            End If
            If e.ColumnIndex = 9 Then
                If lb_actuliza_grilla = True Then
                    fnload_grilla()
                    DGV_gt_det.DataSource = dv_guia_transp_det
                    ' DGV_gt_det.CurrentCell = DGV_gt_det.Rows(fila).Cells() 
                End If
                lb_actuliza_grilla = False
            End If
            '''
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DGV_gt_det_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_gt_det.CellValidated
        Dim dgrv0 As DataGridViewRow
        Dim ll_idtipo_comprobante As Long
        Dim ll_cantidad As Long
        Dim ls_idcomprobante As String
        ' Dim lrst_actualiza, lrst_datos As New ADODB.Recordset
        Dim ls_idguia_transportista_det As String
        Dim ls_codigo, ls_mensaje As String
        Dim ll_cantidad_quita, ll_cantidad_1 As Long
        Dim ls_idguia_transportista As String
        '
        Try
            If Me.DGV_gt_det.Rows.Count < 1 Then
                MsgBox("No se encontro ningún registro", MsgBoxStyle.Information, "Bajar bultos")
                Exit Sub
            End If
            dgrv0 = Me.DGV_gt_det.CurrentRow()
            'If Not DGV_gt_det.CurrentCell.ColumnIndex = 5 Then
            '    Exit Sub
            'End If
            'Quitar paquete - la cantidad del documento 
            If e.ColumnIndex = 4 And Not (lb_actuliza_grilla) Then  ' Valida por la cantidad que va reccepcionar 
                ''
                If IsDBNull(dgrv0.Cells("cantidad_recepcionada").Value) = False Then
                    ' 5 - 6
                    ll_cantidad_quita = CType(dgrv0.Cells("cantidad_recepcionada").Value, Long)
                    ll_cantidad_1 = CType(dgrv0.Cells("cantidad").Value, Long)
                    If ll_cantidad_quita > ll_cantidad_1 Then
                        MsgBox("La cantidad a quitar debe ser menor o igual a la cantidad enviada", MsgBoxStyle.Information, "Bajar bultos")
                        dgrv0.Cells("cantidad_recepcionada").Value = ""
                        Exit Sub
                    End If
                    ll_idtipo_comprobante = CType(dgrv0.Cells("idtipo_comprobante").Value, Long)
                    ls_idcomprobante = CType(dgrv0.Cells("idcomprobante").Value, String)
                    ls_idguia_transportista = CType(dgrv0.Cells("idguia_transportista").Value, String)
                    ls_idguia_transportista_det = CType(dgrv0.Cells("idguia_transportista_detall").Value, String)
                    obj_recepcion_quitar_bultos.idagencia_origen_gt = ll_idagencia_origen_gt
                    obj_recepcion_quitar_bultos.idguia_transp_detall = ls_idguia_transportista_det
                    obj_recepcion_quitar_bultos.guia_transportista = ls_idguia_transportista
                    obj_recepcion_quitar_bultos.idtipo_comprobante = ll_idtipo_comprobante
                    obj_recepcion_quitar_bultos.idcomprobante = ls_idcomprobante
                    obj_recepcion_quitar_bultos.cantidad = CType(dgrv0.Cells("cantidad_recepcionada").Value, Long)
                    obj_recepcion_quitar_bultos.idusuario_personal = dtoUSUARIOS.IdLogin
                    obj_recepcion_quitar_bultos.ip = dtoUSUARIOS.IP
                    obj_recepcion_quitar_bultos.idagencia_recepcion = dtoUSUARIOS.m_iIdAgencia 'Agencia que recepciona 
                    obj_recepcion_quitar_bultos.idunidad_agencia_destino = CType(Me.txt_idunidad_destino.Text, Long)
                    obj_recepcion_quitar_bultos.nro_unidad_transporte = CType(Me.txt_idunidad_transporte.Text, Long)
                    obj_recepcion_quitar_bultos.idusuario_piloto = ll_idusuario_piloto
                    obj_recepcion_quitar_bultos.nro_dcto = CType(dgrv0.Cells("documento").Value, String)
                    obj_recepcion_quitar_bultos.idunidad_age_recep = dtoUSUARIOS.m_idciudad
                    '
                    'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                    '
                    'lrst_actualiza = obj_recepcion_quitar_bultos.fn_actualiza_guia_transportista_det()
                    'ls_codigo = CType(lrst_actualiza.Fields.Item(0).Value, String)
                    'ls_mensaje = CType(lrst_actualiza.Fields.Item(1).Value, String)
                    'lrst_datos = lrst_actualiza.NextRecordset
                    'If ls_codigo <> "0" Then
                    '    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Sistema de Recepción")
                    '    Exit Sub
                    'End If
                    ''
                    'dt_guia_transp_det = Nothing
                    'dt_guia_transp_det = New DataTable
                    'dv_guia_transp_det = Nothing
                    'dv_guia_transp_det = New DataView
                    ''
                    'odba_gt.Fill(dt_guia_transp_det, lrst_datos)

                    Dim lds_tmp As New DataSet
                    lds_tmp = obj_recepcion_quitar_bultos.fn_actualiza_guia_transportista_det()
                    '
                    ls_codigo = CType(lds_tmp.Tables(0).Rows(0).Item(0), String)
                    ls_mensaje = CType(lds_tmp.Tables(0).Rows(0).Item(1), String)
                    If ls_codigo <> "0" Then
                        MsgBox(ls_mensaje, MsgBoxStyle.Information, "Sistema de Recepción")
                        Exit Sub
                    End If
                    ''
                    dt_guia_transp_det = Nothing
                    dt_guia_transp_det = New DataTable
                    dt_guia_transp_det = lds_tmp.Tables(1)
                    dv_guia_transp_det = Nothing
                    dv_guia_transp_det = New DataView
                    '
                    dv_guia_transp_det = dt_guia_transp_det.DefaultView
                    '
                    'DGV_gt_det.Update()
                    'fnload_grilla()
                    'DGV_gt_det.DataSource = dv_guia_transp_det
                    lb_actuliza_grilla = True
                End If
            End If
            'Quitar Bulto - Codigo Barra 
            If e.ColumnIndex = 9 And Not (lb_actuliza_grilla) Then ' Valida por el codigo de barra 
                If IsDBNull(dgrv0.Cells("codigo_barra").Value) = False Then
                    ll_idtipo_comprobante = CType(dgrv0.Cells("idtipo_comprobante").Value, Long)
                    ls_idcomprobante = CType(dgrv0.Cells("idcomprobante").Value, String)
                    ls_idguia_transportista = CType(dgrv0.Cells("idguia_transportista").Value, String)
                    ls_idguia_transportista_det = CType(dgrv0.Cells("idguia_transportista_detall").Value, String)
                    '
                    obj_recepcion_quitar_bultos.idagencia_origen_gt = ll_idagencia_origen_gt
                    obj_recepcion_quitar_bultos.idguia_transp_detall = ls_idguia_transportista_det
                    obj_recepcion_quitar_bultos.guia_transportista = ls_idguia_transportista
                    obj_recepcion_quitar_bultos.idtipo_comprobante = ll_idtipo_comprobante
                    obj_recepcion_quitar_bultos.idcomprobante = ls_idcomprobante
                    obj_recepcion_quitar_bultos.codigo_barra = CType(dgrv0.Cells("codigo_barra").Value, String)
                    obj_recepcion_quitar_bultos.idusuario_personal = dtoUSUARIOS.IdLogin
                    obj_recepcion_quitar_bultos.ip = dtoUSUARIOS.IP
                    obj_recepcion_quitar_bultos.idagencia_recepcion = dtoUSUARIOS.m_iIdAgencia 'Agencia que recepciona 
                    obj_recepcion_quitar_bultos.idunidad_agencia_destino = CType(Me.txt_idunidad_destino.Text, Long)
                    obj_recepcion_quitar_bultos.nro_unidad_transporte = CType(Me.txt_idunidad_transporte.Text, Long)
                    obj_recepcion_quitar_bultos.idusuario_piloto = ll_idusuario_piloto
                    obj_recepcion_quitar_bultos.nro_dcto = CType(dgrv0.Cells("documento").Value, String)
                    obj_recepcion_quitar_bultos.idunidad_age_recep = dtoUSUARIOS.m_idciudad
                    '
                    dt_guia_transp_det = Nothing
                    dt_guia_transp_det = New DataTable
                    dv_guia_transp_det = Nothing
                    dv_guia_transp_det = New DataView
                    '
                    'lrst_actualiza = obj_recepcion_quitar_bultos.fn_actualiza_gt_det_xcodigo_barra()
                    'ls_codigo = CType(lrst_actualiza.Fields.Item(0).Value, String)
                    'ls_mensaje = CType(lrst_actualiza.Fields.Item(1).Value, String)
                    '
                    'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                    '
                    Dim lds_tmp As New DataSet
                    '
                    lds_tmp = obj_recepcion_quitar_bultos.fn_actualiza_gt_det_xcodigo_barra()
                    ls_codigo = CType(lds_tmp.Tables(0).Rows(0).Item(0), String)
                    ls_mensaje = CType(lds_tmp.Tables(0).Rows(0).Item(1), String)
                    '
                    If ls_codigo <> "0" Then
                        MsgBox(ls_mensaje, MsgBoxStyle.Information, "Sistema de Recepción")
                        dgrv0.Cells("codigo_barra").Value = ""
                        Exit Sub
                    End If
                    ' lrst_datos = lrst_actualiza.NextRecordset
                    ' odba_gt.Fill(dt_guia_transp_det, lrst_datos)
                    '
                    'fnload_grilla()
                    'dt_guia_transp_det = Nothing
                    'dt_guia_transp_det = New DataTable
                    'dv_guia_transp_det = Nothing
                    'dv_guia_transp_det = New DataView
                    ''

                    dt_guia_transp_det = lds_tmp.Tables(1)
                    dv_guia_transp_det = dt_guia_transp_det.DefaultView
                    ''
                    'DGV_gt_det.DataSource = dv_guia_transp_det
                    lb_actuliza_grilla = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema...")
        End Try
    End Sub
#End Region
#Region "Procedimiento y Funciones"
    Sub fnload_grilla()
        '
        Try
            DGV_gt_det.Columns.Clear()
            With DGV_gt_det
                .AllowUserToAddRows = False
                '.AllowUserToDeleteRows = False
                '.AllowUserToOrderColumns = True
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            '
            Dim tipo_comprobante As New DataGridViewTextBoxColumn
            With tipo_comprobante '0
                .DisplayIndex = 0
                .DataPropertyName = "tipo_comprobante"
                .Name = "tipo_comprobante"
                .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_gt_det.Columns.Add(tipo_comprobante)
            '
            Dim documento As New DataGridViewTextBoxColumn
            With documento '1
                .DisplayIndex = 1
                .DataPropertyName = "documento"
                .Name = "documento"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_gt_det.Columns.Add(documento)
            '
            Dim ciudad_destino As New DataGridViewTextBoxColumn
            With ciudad_destino  '2
                .DisplayIndex = 2
                .DataPropertyName = "ciudad_destino"
                .Name = "ciudad_destino"
                .HeaderText = "Ciudad Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_gt_det.Columns.Add(ciudad_destino)
            '
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad ' 3
                .DisplayIndex = 3
                .DataPropertyName = "cantidad"
                .Name = "cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_gt_det.Columns.Add(cantidad)
            '
            Dim cantidad_recepcionada As New DataGridViewTextBoxColumn
            With cantidad_recepcionada ' 4
                .DisplayIndex = 4
                .DataPropertyName = "cantidad_recepcionada"
                .Name = "cantidad_recepcionada"
                .HeaderText = "Cant. Recepcionar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = True
                .MaxInputLength = 12
            End With
            DGV_gt_det.Columns.Add(cantidad_recepcionada)
            '
            Dim idtipo_comprobante As New DataGridViewTextBoxColumn
            With idtipo_comprobante ' 5
                .DisplayIndex = 5
                .DataPropertyName = "idtipo_comprobante"
                .Name = "idtipo_comprobante"
                .HeaderText = "Id Tip Comp."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DGV_gt_det.Columns.Add(idtipo_comprobante)
            '
            Dim idcomprobante As New DataGridViewTextBoxColumn
            With idcomprobante '6 
                .DisplayIndex = 6
                .DataPropertyName = "idcomprobante"
                .Name = "idcomprobante"
                .HeaderText = "Id. Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DGV_gt_det.Columns.Add(idcomprobante)
            '
            Dim colTipo_Comprobante As New DataGridViewTextBoxColumn
            With colTipo_Comprobante  '7
                .DisplayIndex = 7
                .DataPropertyName = "Tipo_Comprobante"
                .Name = "Tipo_Comprobante"
                .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DGV_gt_det.Columns.Add(colTipo_Comprobante)
            '
            Dim idciudad_destino As New DataGridViewTextBoxColumn
            With idciudad_destino '8
                .DisplayIndex = 8
                .DataPropertyName = "idciudad_destino"
                .Name = "idciudad_destino"
                .HeaderText = "Id. Ciudad Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DGV_gt_det.Columns.Add(idciudad_destino)
            '
            Dim lscodigo_barra As New DataGridViewTextBoxColumn
            With lscodigo_barra '9
                .DisplayIndex = 9
                .DataPropertyName = "codigo_barra"
                .Name = "codigo_barra"
                .HeaderText = "Codigo Barra"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = True
                .MaxInputLength = 13
            End With
            DGV_gt_det.Columns.Add(lscodigo_barra)
            '  
            '
            Dim idguia_transportista As New DataGridViewTextBoxColumn
            With idguia_transportista '10
                .DisplayIndex = 10
                .DataPropertyName = "idguia_transportista"
                .Name = "idguia_transportista"
                .HeaderText = "idguia_transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = False
            End With
            DGV_gt_det.Columns.Add(idguia_transportista)
            '
            Dim idguia_transportista_detall As New DataGridViewTextBoxColumn
            With idguia_transportista_detall  '11
                .DisplayIndex = 11
                .DataPropertyName = "idguia_transportista_detall"
                .Name = "idguia_transportista_detall"
                .HeaderText = "id guia_transportista_detall"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = False
            End With
            DGV_gt_det.Columns.Add(idguia_transportista_detall)
            '
            Dim cantidad_bajada As New DataGridViewTextBoxColumn
            With cantidad_bajada '12
                .DisplayIndex = 12
                .DataPropertyName = "cantidad_bajada"
                .Name = "cantidad_bajada"
                .HeaderText = "Cantidad Bajada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = True
            End With
            DGV_gt_det.Columns.Add(cantidad_bajada)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub recupera_cabecera(ByVal dt_cabecera As DataTable)
        Try
            '
            If dt_cabecera.Rows.Count > 0 Then
                Me.txt_origen.Text = CType(dt_cabecera.Rows(0)(1), String)
                Me.txt_destino.Text = CType(dt_cabecera.Rows(0)(3), String)
                '
                Me.txt_idunidad_destino.Text = CType(dt_cabecera.Rows(0)(2), String)
                '
                Me.txt_estado.Text = CType(dt_cabecera.Rows(0)(6), String)
                Me.txt_agencia_origen.Text = CType(dt_cabecera.Rows(0)(4), String)
                Me.dtp_fec_salida.Value = CType(dt_cabecera.Rows(0)(7), String)
                Me.txt_idunidad_transporte.Text = CType(dt_cabecera.Rows(0)(8), String)
                ll_idusuario_piloto = CType(dt_cabecera.Rows(0)(9), Long)
                ll_idagencia_origen_gt = CType(dt_cabecera.Rows(0)(10), Long)
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Sub limpia_cabecera()
        Try
            '
            Me.txt_origen.Text = ""
            Me.txt_destino.Text = ""
            Me.txt_estado.Text = ""
            '
            Me.txt_agencia_origen.Text = ""
            Me.txt_idunidad_destino.Text = ""
            Me.txt_idunidad_transporte.Text = ""
            '
            ll_idusuario_piloto = 0
            Me.dtp_fec_salida.Value = dtoUSUARIOS.dfecha_sistema
            ll_idagencia_origen_gt = 0
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Sub recupera_datos()
        ' Dim lrst_guia_transportista, lrst_guia_transportista_det As New ADODB.Recordset
        Try
            limpia_cabecera()
            '
            dt_guia_transp = Nothing
            dt_guia_transp_det = Nothing
            '
            dv_guia_transp = Nothing
            dv_guia_transp_det = Nothing
            '
            dt_guia_transp = New DataTable
            dt_guia_transp_det = New DataTable
            '
            dv_guia_transp = New DataView
            dv_guia_transp_det = New DataView
            '
            obj_recepcion_quitar_bultos.guia_transportista = txt_guia_transportista.Text
            'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
            'lrst_guia_transportista = obj_recepcion_quitar_bultos.fn_guia_transportista
            'lrst_guia_transportista_det = lrst_guia_transportista.NextRecordset
            'odba_gt.Fill(dt_guia_transp, lrst_guia_transportista)
            'odba_gt.Fill(dt_guia_transp_det, lrst_guia_transportista_det)
            '
            Dim lds_tmp As New DataSet
            lds_tmp = obj_recepcion_quitar_bultos.fn_guia_transportista
            dt_guia_transp = lds_tmp.Tables(0)
            dt_guia_transp_det = lds_tmp.Tables(1)
            '
            fnload_grilla()
            If dt_guia_transp.Rows.Count < 1 Then
                MsgBox("No se encontró la guía de transportista", MsgBoxStyle.Information, "Sistema de Recepción")
                Me.txt_guia_transportista.Text = ""
                Me.txt_guia_transportista.Focus()
            End If
            '
            'Recupera cabecera
            recupera_cabecera(dt_guia_transp)
            '
            dv_guia_transp_det = dt_guia_transp_det.DefaultView
            fnload_grilla()
            DGV_gt_det.DataSource = dv_guia_transp_det
        Catch ex As Exception

        End Try
    End Sub
#End Region

    'Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged
    '   If bIngreso Then
    'Acceso.VerificaCambio(sender, e)
    '  End If
    'End Sub

    Private Sub txt_dcto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_dcto.TextChanged

    End Sub
End Class
