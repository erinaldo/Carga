Public Class frmCargoValidacion

    Private Sub frmCargoValidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim strMensaje As String

        strMensaje = "El Comprobante no tiene Cargo(s)"
        strMensaje = strMensaje & Chr(13) & Chr(13) & "¿Ingresará los Cargos?"

        Me.txtMensaje.Text = strMensaje
    End Sub

    Private Sub rbtSi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSi.CheckedChanged
        Me.txtMotivo.Text = ""
        Me.txtMotivo.Enabled = False
        Me.btnAceptar.Focus()
    End Sub

    Private Sub rbtNo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNo.CheckedChanged
        Me.txtMotivo.Text = ""
        Me.txtMotivo.Enabled = True
        Me.txtMotivo.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.rbtNo.Checked Then
            If Me.txtMotivo.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Motivo", "Ingresar Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMotivo.Text = ""
                Me.txtMotivo.Focus()
                Return
            End If
        End If
        Me.Close()
    End Sub

    Private Sub txtMotivo_Enter(sender As Object, e As System.EventArgs) Handles txtMotivo.Enter
        txtMotivo.SelectAll()
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

    Private Sub frmCargoValidacion_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.btnAceptar.Focus()
    End Sub
End Class