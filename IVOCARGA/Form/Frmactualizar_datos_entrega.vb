Public Class Frmactualizar_datos_entrega
#Region "Variables Publicas"
    Public pb_cancelar As Boolean = True
    Public ps_idguias_envio As String
    Public ps_nro_guia As String
    Public ps_persona_entrega As String
    Public ps_doc_quien_entrega As String
    Public ps_fecha_entrega As String
    Public ps_tipo_comprobante As String
    Public pl_idtipo_comprobante As Long
    Public ps_hora_entrega As String
#End Region
#Region "Variables Formulario"
    Dim lobj_recepcion_cargo As New dtoRecepcionCargo

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
    Private Sub Frmactualizar_datos_entrega_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.txt_comprobante.Text = ps_nro_guia
            Me.lab_tipo_comprobante.Text = ps_tipo_comprobante
            Me.txt_entregado.Text = ps_persona_entrega
            Me.txt_dcto_identidad.Text = ps_doc_quien_entrega
            If ps_fecha_entrega <> "" Then
                Me.dtp_fecha_entrega.Value = CType(ps_fecha_entrega, Date)
            Else
                Me.dtp_fecha_entrega.Value = CType(dtoUSUARIOS.dfecha_sistema, Date)
            End If
            '
            If ps_hora_entrega <> "" Then
                Me.DTp_hora_entrega.Text = ps_hora_entrega
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim ldt_mensaje As New DataTable
        Dim ll_codigo As Long
        Dim ls_mensaje As String
        Try
            '
            If Me.txt_entregado.Text = "" Then
                MsgBox("Falta ingresar el nombre de la persona que se le a entregado", MsgBoxStyle.Information, "Actualizar datos entrega")
                Me.txt_entregado.Focus()
                Exit Sub
            End If
            '
            If Me.txt_dcto_identidad.Text = "" Then
                MsgBox("Falta ingresar el documento de identidad de la persona que se le entrego", MsgBoxStyle.Information, "Actualizar datos entrega")
                Me.txt_dcto_identidad.Focus()
                Exit Sub
            End If
            '
            lobj_recepcion_cargo.pl_idtipo_comprobante = pl_idtipo_comprobante
            '
            lobj_recepcion_cargo.pl_idguia_envio = CType(ps_idguias_envio, Long)
            lobj_recepcion_cargo.ps_nombre_entrega = Me.txt_entregado.Text
            lobj_recepcion_cargo.ps_doc_a_quien_se_entrega = Me.txt_dcto_identidad.Text
            lobj_recepcion_cargo.Fecha_Entrega = CType(Me.dtp_fecha_entrega.Value, String)
            lobj_recepcion_cargo.ps_hora_entrega = CType(Me.DTp_hora_entrega.Value, String)
            'Mod. 10/09/2009 - x data-helper 
            ldt_mensaje = lobj_recepcion_cargo.fnRECEPCION_CARGO_graba_datos_entrega
            '
            ll_codigo = CType(ldt_mensaje.Rows(0).Item(0), Long)
            ls_mensaje = CType(ldt_mensaje.Rows(0).Item(1), String)
            '
            MsgBox(ls_mensaje, MsgBoxStyle.Information, "Actualizar datos entrega")
            If ll_codigo = 0 Then
                pb_cancelar = False
                Me.Close()
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        pb_cancelar = True
        Me.Close()
    End Sub
    Private Sub txt_dcto_identidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dcto_identidad.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
#End Region
#Region "Procedimientos y eventos"

#End Region
End Class