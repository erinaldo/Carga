Public Class frm_reparto_parcial
#Region "Variable publica"
    Public ps_idsolicitud_recojo_carga As String
    Public pb_cancelar As Boolean = True
    Public pb_idusuario_responsable As Long
    Public hnd As Long
#End Region
#Region "variable"
    Dim obj_repartoparcial As New dtorepartoparcial
    'Dim rst_recupera_datos As New ADODB.Recordset
    Dim bIngreso As Boolean = False
#End Region

#Region "Adicional"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region
#Region "Eventos"

    Private Sub frm_reparto_parcial_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_reparto_parcial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '
            Dim ldt_tmp As New DataTable
            obj_repartoparcial.idsolicitud_recojo_carga = ps_idsolicitud_recojo_carga
            '            
            'Mod.03/10/2009 -->Omendoza - Pasando al datahelper -              
            'rst_recupera_datos = obj_repartoparcial.fn_recupera_datos()
            ldt_tmp = obj_repartoparcial.fn_recupera_datos()
            '
            'Me.txt_responsable.Text = CType(rst_recupera_datos.Fields(0).Value, String)
            'Me.txt_cliente.Text = CType(rst_recupera_datos.Fields(1).Value, String)
            'Me.txt_consignado.Text = CType(rst_recupera_datos.Fields(2).Value, String)
            'Me.txt_nro_dcto.Text = CType(rst_recupera_datos.Fields(3).Value, String)
            'Me.lab_documento.Text = CType(rst_recupera_datos.Fields(4).Value, String)
            'Me.txt_tot_bultos_dcto.Text = CType(rst_recupera_datos.Fields(6).Value, String) ' Cantidad Total
            'Me.txt_entregado.Text = CType(rst_recupera_datos.Fields(7).Value, String) ' Cantidad Entregada 
            'Me.txt_por_entregar.Text = CType(rst_recupera_datos.Fields(8).Value, String) ' Cantidad x Entregar 
            'Me.txt_reparto.Text = CType(rst_recupera_datos.Fields(9).Value, String) ' Cantidad a Repartir
            'Me.txt_repartir.Text = CType(rst_recupera_datos.Fields(5).Value, String) 'Cantidad Reparto 
            '
            Me.txt_responsable.Text = CType(ldt_tmp.Rows(0).Item(0), String)
            Me.txt_cliente.Text = CType(ldt_tmp.Rows(0).Item(1), String)
            Me.txt_consignado.Text = CType(ldt_tmp.Rows(0).Item(2), String)
            Me.txt_nro_dcto.Text = CType(ldt_tmp.Rows(0).Item(3), String)
            Me.lab_documento.Text = CType(ldt_tmp.Rows(0).Item(4), String)
            Me.txt_tot_bultos_dcto.Text = CType(ldt_tmp.Rows(0).Item(6), String) ' Cantidad Total
            Me.txt_entregado.Text = CType(ldt_tmp.Rows(0).Item(7), String) ' Cantidad Entregada 
            Me.txt_por_entregar.Text = CType(ldt_tmp.Rows(0).Item(8), String) ' Cantidad x Entregar 
            Me.txt_reparto.Text = CType(ldt_tmp.Rows(0).Item(9), String) ' Cantidad a Repartir
            Me.txt_repartir.Text = CType(ldt_tmp.Rows(0).Item(5), String) 'Cantidad Reparto 
            ' 

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        pb_cancelar = True
        Me.Close()
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim rst_mensajes As New ADODB.Recordset
        Dim ls_mensaje As String
        Try
            obj_repartoparcial.cantidad_repartir = CType(Me.txt_repartir.Text, Long)
            obj_repartoparcial.idusuario_persona = pb_idusuario_responsable 'dtoUSUARIOS.IdLogin 'loco de mierda
            obj_repartoparcial.idsolicitud_recojo_carga = ps_idsolicitud_recojo_carga
            '  Grabar  
            'Mod.03/10/2009 -->Omendoza - Pasando al datahelper -  
            Dim ldt_tmp As New DataTable
            'rst_mensajes = obj_repartoparcial.fn_act_reparto
            ldt_tmp = obj_repartoparcial.fn_act_reparto
            ls_mensaje = CType(ldt_tmp.Rows(0).Item(1), String)
            If CType(ldt_tmp.Rows(0).Item(0).Value, Long) <> 0 Then
                MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Sistema de Reparto")
                Exit Sub
            End If
            pb_cancelar = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txt_repartir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_repartir.TextChanged
        Dim ll_entregado, ll_reparto, ll_tot_dcto As Long
        Try
            Me.btn_aceptar.Enabled = True
            If Me.txt_entregado.Text = "" Or Me.txt_entregado.Text = " " Then
                Me.txt_entregado.Text = "0"
            End If
            If Me.txt_reparto.Text = "" Or Me.txt_reparto.Text = " " Then
                Me.txt_reparto.Text = "0"
            End If
            If Me.txt_tot_bultos_dcto.Text = "" Or Me.txt_tot_bultos_dcto.Text = " " Then
                Me.txt_tot_bultos_dcto.Text = "0"
            End If
            '
            ll_entregado = CType(Me.txt_entregado.Text, Long) + CType(Me.txt_reparto.Text, Long)
            ll_tot_dcto = CType(Me.txt_tot_bultos_dcto.Text, Long)
            If ll_tot_dcto - ll_entregado < 1 Then
                MsgBox("El documento está entregado o en reparto", MsgBoxStyle.Information, "Sistema Reparto Móvil")
                Me.btn_aceptar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Eventos y Procedimientos"

#End Region


End Class