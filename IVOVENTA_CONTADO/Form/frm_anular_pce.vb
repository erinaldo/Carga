Public Class frm_anular_pce
#Region "Variables Públicas"
    Public ps_idfactura_contado As String
    Public ps_des_tipo_comprobante As String
    Public pb_cancelar As Boolean = True
#End Region
#Region "Variables"
    Dim obj_anula_pce As New dto_anula_pce
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
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Eventos"

    Private Sub frm_anular_pce_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_anular_pce_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim lrst_datos As New ADODB.Recordset
        Dim ldt_datos As New DataTable
        Try
            '
            Me.lab_tipo_comp.Text = ps_des_tipo_comprobante
            Me.txt_idfactura.Text = ps_idfactura_contado
            ' 
            obj_anula_pce.idfactura = ps_idfactura_contado
            ldt_datos = obj_anula_pce.fn_datos_pce_anular
            '            
            Me.txt_comprobante.Text = CType(ldt_datos.Rows(0).Item("nro_comprobante"), String)
            Me.txt_cliente.Text = CType(ldt_datos.Rows(0).Item("razon_social"), String)
            Me.txt_nu_documento.Text = CType(ldt_datos.Rows(0).Item("dcto_identidad_cliente"), String)
            Me.txt_ciudad_origen.Text = CType(ldt_datos.Rows(0).Item("ciudad_origen"), String)
            Me.txt_ciudad_destino.Text = CType(ldt_datos.Rows(0).Item("ciudad_destino"), String)
            Me.txt_agencia_origen.Text = CType(ldt_datos.Rows(0).Item("agencia_origen"), String)
            Me.txt_agencia_destino.Text = CType(ldt_datos.Rows(0).Item("agencia_destino"), String)
            Me.txt_consignado.Text = CType(ldt_datos.Rows(0).Item("consignado"), String)
            Me.txt_fecha_documento.Text = CType(ldt_datos.Rows(0).Item("fecha_factura"), String)
            Me.txt_fecha_registro.Text = CType(ldt_datos.Rows(0).Item("fecha_registro"), String)
            Me.txt_totales.Text = CType(ldt_datos.Rows(0).Item("Total_Costo"), String)
            '
            Me.txt_obs.Focus()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Try
            pb_cancelar = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        'Dim lrst_mensaje As New ADODB.Recordset
        Dim ldt_mensaje As New DataTable
        '
        Dim ll_codigo As Long
        Dim ls_mensaje As String
        Try
            ' 
            If Me.txt_obs.Text = "" Then
                MsgBox("Falta ingresar observación", MsgBoxStyle.Exclamation, "Anular PCE")
                Me.txt_obs.Focus()
                Exit Sub
            End If
            'Grabar 
            obj_anula_pce.idfactura = ps_idfactura_contado
            obj_anula_pce.observacion = Me.txt_obs.Text
            obj_anula_pce.idusuario_personal = dtoUSUARIOS.IdLogin
            obj_anula_pce.rol = dtoUSUARIOS.IdRol
            obj_anula_pce.ip = dtoUSUARIOS.IP
            'Mod.11/09/2009 -->Omendoza - Pasando al datahelper   
            'lrst_mensaje = obj_anula_pce.fn_grabar_pce_anular()
            ldt_mensaje = obj_anula_pce.fn_grabar_pce_anular()
            ll_codigo = CType(ldt_mensaje.Rows(0).Item("codigo"), Long)
            ls_mensaje = CType(ldt_mensaje.Rows(0).Item("mensaje"), String)
            '
            If ll_codigo <> 0 Then
                MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Anular PCE")
                Exit Sub
            End If
            MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Anular PCE")
            pb_cancelar = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Procedimientos y Funciones"
#End Region
End Class