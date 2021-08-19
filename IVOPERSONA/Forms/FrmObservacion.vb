Public Class FrmObservacion

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If TxtObservaciones.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe Ingresar una Observación.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtObservaciones.Text = ""
            Me.TxtObservaciones.Focus()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub FrmObservacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK And Me.TxtObservaciones.Text.Trim.Length = 0 Then
            e.Cancel = True
        End If
    End Sub
End Class