Public Class FrmPassCierreLiqui
    Dim contador As Integer = 0
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub BtnAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcep.Click
        Try

            If dtoUSUARIOS.m_sPassword = Me.TBPass.Text Then

                If MsgBox("Seguro que desea realizar el cierre", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    flag_Salir = False
                    Close()
                Else
                    Close()
                End If

            Else

                If contador = 2 Then
                    MsgBox("Clave incorrecta, contactese con el administrador del sistema", MsgBoxStyle.Information, "Seguridad Sistema")
                    flag_Salir = True
                    Close()
                Else
                    MsgBox("Clave incorrecta", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                contador += 1
            End If



        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub BtnCance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCance.Click
        Close()
        flag_Salir = True
    End Sub

    Private Sub FrmPassCierreLiqui_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Me.TBPass.Focus()
    End Sub

    Private Sub FrmPassCierreLiqui_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            flag_Salir = False
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub TBPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBPass.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub
End Class