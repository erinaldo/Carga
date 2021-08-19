Public Class frm_genera_incidencia_despacho
#Region "Variables Publicas"
    Public ps_tipo_comprobante As String
    Public ps_idcomprobante As String
    Public pb_cancelar As Boolean
    Public pb_dtogenera_incidencia_despacho As New dtogenera_incidencia_despacho
    Public pdt_datos_generales As New DataTable
    Public pdt_agencias As New DataTable ' Para la agencia origen 
#End Region
#Region "Variables Privadas"
    'Dim odba_conecta As New OleDb.OleDbDataAdapter
    Dim ldt_agencia_destino As New DataTable
    Dim ldv_agencia_origen, ldv_agencia_destino As New DataView
    '
    Dim ll_tipo_comprobante As Long
    Dim ll_idcomprobante As Long
    Dim ll_idagencia_origen As Long
    Dim ll_idagencia_destino As Long
    Dim ls_dcto_cliente As String
    Dim ls_razon_cliente As String
    Dim ls_tipo_comprobante As String
    Dim ls_nro_dcto As String
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
#Region "Eventos Adicionales"
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

    Private Sub frm_genera_incidencia_despacho_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_genera_incidencia_despacho_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            ll_tipo_comprobante = CType(pdt_datos_generales.Rows(0).Item(1), Long)
            ll_idcomprobante = CType(pdt_datos_generales.Rows(0).Item(2), Long)
            ll_idagencia_origen = CType(pdt_datos_generales.Rows(0).Item(3), Long)
            ll_idagencia_destino = CType(pdt_datos_generales.Rows(0).Item(4), Long)
            '
            If IsDBNull(pdt_datos_generales.Rows(0).Item(5)) = True Then  '11/04/2008 - El dcto del cliente viene en nulo 
                ls_dcto_cliente = ""
            Else
                ls_dcto_cliente = CType(pdt_datos_generales.Rows(0).Item(5), String)
            End If
            'ls_dcto_cliente = CType(pdt_datos_generales.Rows(0).Item(5), String)
            ls_razon_cliente = CType(pdt_datos_generales.Rows(0).Item(6), String)
            ls_tipo_comprobante = CType(pdt_datos_generales.Rows(0).Item(7), String)
            ls_nro_dcto = CType(pdt_datos_generales.Rows(0).Item(8), String)
            ldt_agencia_destino = pdt_agencias.Copy
            'Pasando a los campos correspondiente  
            ldv_agencia_origen = CargarCombo(Me.cmb_agencia_origen, pdt_agencias, "nombre_agencia", "idagencias", ll_idagencia_origen)  ' Agencia Origen 
            ldv_agencia_destino = CargarCombo(Me.cmb_agencia_destino, ldt_agencia_destino, "nombre_agencia", "idagencias", dtoUSUARIOS.iIDAGENCIAS) 'll_idagencia_destino)  ' Agencia Destino 
            '
            Me.lab_tip_documento.Text = ls_tipo_comprobante
            Me.txt_dcto_cliente.Text = ls_dcto_cliente
            Me.txt_cliente.Text = ls_razon_cliente
            Me.txt_documento.Text = ls_nro_dcto
            '
            Me.dtp_fec_recepciona.Value = dtoUSUARIOS.m_sFecha
            '

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Try
            pb_cancelar = True
            pb_dtogenera_incidencia_despacho = Nothing
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        'Dim lrst_datos As New ADODB.Recordset
        Dim ldt_rst_datos As New DataTable
        Dim ll_codigo As Long
        Dim ls_mensaje As String

        Try
            pb_dtogenera_incidencia_despacho.idtipo_comprobante = ll_tipo_comprobante
            pb_dtogenera_incidencia_despacho.idcomprobante = ll_idcomprobante
            pb_dtogenera_incidencia_despacho.nro_documento = ls_nro_dcto
            pb_dtogenera_incidencia_despacho.idagencia_origen = Me.cmb_agencia_origen.SelectedValue
            pb_dtogenera_incidencia_despacho.idagencia_destino = Me.cmb_agencia_destino.SelectedValue
            pb_dtogenera_incidencia_despacho.idagencia = dtoUSUARIOS.iIDAGENCIAS
            pb_dtogenera_incidencia_despacho.ip = dtoUSUARIOS.IP
            pb_dtogenera_incidencia_despacho.idusuario_personal = dtoUSUARIOS.IdLogin
            pb_dtogenera_incidencia_despacho.fecha_incidente = CType(Me.dtp_fec_recepciona.Value, String)
            '
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            'lrst_datos = pb_dtogenera_incidencia_despacho.fn_genera_incidente_despacho()
            ldt_rst_datos = pb_dtogenera_incidencia_despacho.fn_genera_incidente_despacho()
            '
            ll_codigo = ldt_rst_datos.Rows(0).Item(0)
            ls_mensaje = ldt_rst_datos.Rows(0).Item(1)
            If ll_codigo <> 0 Then
                MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Genera incidente despacho")
                pb_cancelar = True
                Exit Sub
            Else
                pb_cancelar = False
            End If
            '
            pb_dtogenera_incidencia_despacho = Nothing
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Procedimientos y funciones"

#End Region

End Class