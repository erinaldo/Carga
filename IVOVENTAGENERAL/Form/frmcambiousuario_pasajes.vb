Public Class frmcambiousuario_pasajes
#Region "Variables"
    ' Variable publica, que interactua con el cambio de usuario, solo para uso para evaluar si refresca 
    Public pb_refresca As Boolean = False
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        pb_refresca = False
        Me.Close()
    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Dim lnromensaje As Long
        Dim smensaje As String
        Try
            ObjVentaPasaje.sidventa_pasajes = Me.txtidventa_pasaje.Text
            ObjVentaPasaje.lidusuario_personal = Int(ObjVentaPasaje.coll_Lista_Usuarios(Me.cmbusuario_nuevo.SelectedIndex.ToString))
            If Int(txtidusuario_personal_actual.Text) = ObjVentaPasaje.lidusuario_personal Then
                pb_refresca = False
                Me.Close()
            End If
            ObjVentaPasaje.sip = dtoUSUARIOS.IP
            ObjVentaPasaje.lidusuario_personal_mod = dtoUSUARIOS.IdLogin
            ObjVentaPasaje.lidrol_usuario = dtoUSUARIOS.m_iIdRol
            If ObjVentaPasaje.fnCambioUsuario Then
                'datahelper
                'lnromensaje = CType(ObjVentaPasaje.rst_cambio_usuario.Fields.Item("codsql").Value, Long)
                'smensaje = CType(ObjVentaPasaje.rst_cambio_usuario.Fields.Item("msjsql").Value, String)
                lnromensaje = CType(ObjVentaPasaje.rst_cambio_usuario.Rows(0).Item("codsql"), Long)
                smensaje = CType(ObjVentaPasaje.rst_cambio_usuario.Rows(0).Item("msjsql"), String)
                If lnromensaje <> 0 Then
                    MsgBox(smensaje, MsgBoxStyle.Exclamation, "Venta de Pasajes")
                    Exit Sub
                End If
            End If
            pb_refresca = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub frmcambiousuario_pasajes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmcambiousuario_pasajes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class