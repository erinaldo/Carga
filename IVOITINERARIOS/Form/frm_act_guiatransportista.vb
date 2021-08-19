Public Class frm_actualiza_gt
#Region "Variables publicas"
    Public pl_idguia_transportista As Long
    Public pl_nro_bus_ant As Long
    Public pl_idagencia As Long
    Public pb_cancelar As Boolean = False
    Public ps_serie_gt As String
    Public ps_nro_gt As String
#End Region
#Region "Variables privadas"
    Dim ls_nombre_agencia As String
    Dim lb_usa_correlativo As Boolean = False
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
#Region "Eventos adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region
#Region "Eventos"

    Private Sub frm_actualiza_gt_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frm_actualiza_gt_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'load
    Private Sub frm_actualiza_gt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If ps_serie_gt = "null" Or ps_nro_gt = "null" Or ps_serie_gt = "" Or ps_nro_gt = "" Then
                fnNroDocumento(8)
                lb_usa_correlativo = True
            Else
                Me.txt_serie.Text = ps_serie_gt
                Me.txt_nroguia.Text = ps_nro_gt
            End If
            '
            ls_nombre_agencia = fnGetAGENCIA(pl_idagencia)
            Me.txt_agencia.Text = ls_nombre_agencia
            Me.txt_nro_bus.Text = CType(pl_nro_bus_ant, String)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de seguridad")
        End Try
    End Sub
    'btn_cancelar
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Try
            pb_cancelar = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    'Aceptar
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim ldto_guia_transportista As New dtoGuiasTransp
        'Dim lrst_datos As New ADODB.Recordset
        Dim ldt_tmp As New DataTable
        Dim ll_codigo As Long
        Dim ls_mensaje As String
        Try
            If Me.txt_serie.Text = "" Then
                MsgBox("No a ingresado la serie de la guía de transportista", MsgBoxStyle.Information, "Actualización de guía transportista")
                Me.txt_serie.Focus()
                Exit Sub
            End If
            '
            If Me.txt_nroguia.Text = "" Then
                MsgBox("No a ingresado el nº de la guía de transportista", MsgBoxStyle.Information, "Actualización de guía transportista")
                Me.txt_nroguia.Focus()
                Exit Sub
            End If
            If Me.txt_nro_bus.Text = "" Then
                MsgBox("No a ingresado el nº de bus", MsgBoxStyle.Information, "Actualización de guía transportista")
                Me.txt_nroguia.Focus()
                Exit Sub
            End If
            'Verifica si cambia el cambio la guia de transportista
            If ps_serie_gt = "null" Or ps_serie_gt = "null" Then
                lb_usa_correlativo = True
            Else
                If Not (Me.txt_serie.Text = ps_serie_gt And Me.txt_nroguia.Text = ps_nro_gt) Then
                    lb_usa_correlativo = False
                End If
            End If
            ldto_guia_transportista.sid_guia_trans = CType(pl_idguia_transportista, String)
            ldto_guia_transportista.Serie = Me.txt_serie.Text
            ldto_guia_transportista.NroGuia = Me.txt_nroguia.Text
            ldto_guia_transportista.Bus_antiguo = pl_nro_bus_ant
            ldto_guia_transportista.Bus_nuevo = CType(Me.txt_nro_bus.Text, Long)
            'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
            'lrst_datos = ldto_guia_transportista.fn_act_gt_serie_y_nro()
            ldt_tmp = ldto_guia_transportista.fn_act_gt_serie_y_nro()
            '
            ll_codigo = CType(ldt_tmp.Rows(0).Item(0), Long)
            ls_mensaje = CType(ldt_tmp.Rows(0).Item(1), String)
            If ll_codigo <> 0 Then
                MsgBox(ls_mensaje, MsgBoxStyle.Information, "Actualización de guía transportista")
                If ll_codigo = 1 Then
                    Me.txt_nroguia.Focus()
                Else
                    Me.txt_nro_bus.Focus()
                End If
                Exit Sub
            Else
                If lb_usa_correlativo = True Then
                    'Dim lrst_incrementar_gt As New ADODB.Recordset
                    Dim lds_tmp As New DataSet
                    Dim clase As New dtoGuiasTransp
                    lds_tmp = clase.fnIncrementarNroDoc(8) ' GUIA REMISION DE TRANSPORTISTA
                End If
            End If
            MsgBox(ls_mensaje, MsgBoxStyle.Information, "Actualización de guía transportista")
            pb_cancelar = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Procedimientos yu funciones"
    ' Genera el nº de guía de transportista 
    Public Sub fnNroDocumento(ByVal idDocumento As Integer)
        Dim flag As Boolean = False
        ' Dim rstNroDocumentos As New ADODB.Recordset
        Dim ldt_tmp As New DataTable
        Dim clase As New dtoGuiasTransp
        Try
            Me.txt_serie.Text = ""
            Me.txt_nroguia.Text = ""
            ldt_tmp = clase.fnNroDocumento(idDocumento.ToString)
            If ldt_tmp.Rows.Count > 0 Then
                Me.txt_serie.Text = ldt_tmp.Rows(0).Item(0).ToString
                Me.txt_nroguia.Text = ldt_tmp.Rows(0).Item(1).ToString
                If idDocumento = 3 Then
                    Me.txt_nroguia.Text = fnGeneraDigitoChequeo(Me.txt_nroguia.Text)
                End If
            End If
            'Mod.29/09/2009 -->Omendoza - Pasando al datahelper -  
            'Dim SQLQuery As Object() = {"select t_Control_Comprobantes.Serie,t_Control_Comprobantes.Nro_Documento from  t_Control_Comprobantes where t_Control_Comprobantes.Ip='" & dtoUSUARIOS.IP & "' and t_Control_Comprobantes.Idtipo_Comprobante= " & idDocumento.ToString & "  and t_Control_Comprobantes.Idagencias=" & dtoUSUARIOS.m_iIdAgencia.ToString & " and t_Control_Comprobantes.Idestado_Registro=1", 2}
            'rstNroDocumentos = Nothing
            'rstNroDocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
            'If rstNroDocumentos.State = 1 Then
            '    If rstNroDocumentos.EOF = False And rstNroDocumentos.BOF = False Then
            '        Me.txt_serie.Text = rstNroDocumentos.Fields.Item(0).Value.ToString
            '        Me.txt_nroguia.Text = rstNroDocumentos.Fields.Item(1).Value.ToString
            '        If idDocumento = 3 Then
            '            '    NroDoc = NroDoc.Substring(2, NroDoc.Length - 2)
            '            Me.txt_nroguia.Text = fnGeneraDigitoChequeo(Me.txt_nroguia.Text)
            '        End If
            '    End If
            'End If
            '''''


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

#End Region

    
End Class