Public Class frm_act_agencia_y_piloto
#Region "Variables Publicas"
    Public dt_ciudad, dt_agencia, dt_piloto As New DataTable
    Public dv_ciudad, dv_agencia, dv_piloto As New DataView
    Public l_idguia_transportista As Long
    Public l_idusuario_personal As Long
    Public s_ip As String
    Public hnd As Long
#End Region
#Region "Variables Privadas"
    Dim objguiatransportista As New dtoGuiasTransp
    Dim bIngreso As Boolean = False
#End Region
#Region "Control Panel"
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region
#Region "Eventos"

    Private Sub frm_act_agencia_y_piloto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frm_act_agencia_y_piloto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_act_agencia_y_piloto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub Btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MessageBox.Show("No actualizado los datos del manifiesto y/o guía de transportista", "Actualizando agencia y piloto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            If Me.cmb_agencia_destino.SelectedValue = -666 Then
                MessageBox.Show("No ha ingresado la agencia destino", "Actualizando agencia y piloto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmb_agencia_destino.Focus()
                Exit Sub
            End If
            If Me.cmb_piloto.SelectedValue = -666 Then
                MessageBox.Show("No ha ingresado al piloto de la móvil", "Actualizando agencia y piloto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmb_agencia_destino.Focus()
                Exit Sub
            End If
            objguiatransportista.sidguiatransportista = CType(l_idguia_transportista, String)
            objguiatransportista.idagencia_dest = CType(Me.cmb_agencia_destino.SelectedValue, Long)
            objguiatransportista.Chofer = CType(Me.cmb_piloto.SelectedValue, Integer)
            objguiatransportista.IP = s_ip
            objguiatransportista.Usuario = CType(l_idusuario_personal, Integer)
            'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
            'Dim rst_mensaje As New ADODB.Recordset
            'rst_mensaje = objguiatransportista.fn_act_guia_trans_agencia_destino()
            Dim s_mensaje As String
            Dim ldt_tmp As New DataTable
            '-- 
            ldt_tmp = objguiatransportista.fn_act_guia_trans_agencia_destino()
            If CType(ldt_tmp.Rows(0).Item(0), Long) <> 0 Then
                s_mensaje = CType(ldt_tmp.Rows(0).Item(1), String)
                MsgBox(s_mensaje, MsgBoxStyle.Critical, "Actualizando agencia y piloto")
                Exit Sub
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
#End Region


End Class