Public Class frmAnularAprobacion
    Dim blnSalir As Boolean

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dlgRespuesta As DialogResult
        Dim strMensaje As String, strTitulo As String

        If Me.rbtAutorizacion.Checked Then
            strTitulo = "Anular Autorización"
            strMensaje = "¿Está seguro de anular la Autorización?"
        Else
            strTitulo = "Anular Solicitud"
            strMensaje = "¿Está seguro de anular la Solicitud?"
        End If

        dlgRespuesta = MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.No Then
            blnSalir = False
        End If
    End Sub

    Private Sub frmAnularAprobacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAnularAprobacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        blnSalir = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        blnSalir = True
    End Sub
End Class