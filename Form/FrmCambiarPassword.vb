
Public Class FrmCambiarPassword
    Dim ObjValida As New ClsLbTepsa.dtoValida
    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Private Function VALIDAR() As Boolean
        VALIDAR = False
        If ObjValida.NO_BLANCO(Me.TXTPASSWORD, Me) = False Then Exit Function
        If ObjValida.NO_BLANCO(Me.TXTPASSWORD_NUEVO, Me) = False Then Exit Function
        If ObjValida.NO_BLANCO(Me.TXTPASSWORD_CONFIRMAR, Me) = False Then Exit Function

        If Me.TXTPASSWORD_NUEVO.Text <> Me.TXTPASSWORD_CONFIRMAR.Text Then
            MsgBox("La confirmación del password no coincide", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            Exit Function
        End If
        
        If Me.TXTPASSWORD.Text = Me.TXTPASSWORD_NUEVO.Text Then
            MsgBox("La confirmación del password no coincide", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            Exit Function
        End If


        VALIDAR = True
    End Function
    Private Sub BTNACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEP.Click
        If VALIDAR() = True Then
            ObjPersona.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjPersona.PASSWORD = Me.TXTPASSWORD.Text
            ObjPersona.PASSWORD_NUEVO = Me.TXTPASSWORD_NUEVO.Text
            'Datahelper
            ObjPersona.SP_CAMBIAR_PASSWORD()
            If ObjPersona.ESTADO = "CAMBI" Then
                Close()
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmCambiarPassword_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCambiarPassword_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        'Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmCambiarPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtlogin.Text = dtoUSUARIOS.iLOGIN
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub BTNCANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCE.Click
        Close()
    End Sub

    
End Class
