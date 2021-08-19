Public Class frmAceptarsinHuella
    Dim blnSalir As Boolean

    Private Sub frmAceptarsinHuella_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAceptarsinHuella_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        blnSalir = True
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtMotivo.Text.Trim.Length <= 5 Then
            MessageBox.Show("Ingrese el Motivo", "Huella", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMotivo.Text = Me.txtMotivo.Text.Trim
            Me.txtMotivo.Focus()
            blnSalir = False
            Return
        End If

    End Sub

    Private Sub txtMotivo_Enter(sender As Object, e As System.EventArgs) Handles txtMotivo.Enter
        Me.txtMotivo.SelectAll()
    End Sub

    Private Sub txtMotivo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtMotivo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMotivo.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class